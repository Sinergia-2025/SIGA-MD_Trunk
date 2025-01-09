Public Class ContabilidadReportes
   Inherits Comunes

   Public Sub New(da As Datos.DataAccess)
      MyBase.New(da)
   End Sub

   Public Function Asiento_GetDetalle(idSucursales As Integer(), idPlan As Integer, idAsiento As Integer, idCentroCosto As Integer?,
                                      fechaDesde As Date?, fechaHasta As Date?,
                                      tipoRegistro As Entidades.ContabilidadReporte.TipoRegistro,
                                      exportados As Entidades.Publicos.SiNoTodos) As DataTable
      Dim stb = New StringBuilder()
      With stb
         .AppendLine(" SELECT AC.idAsiento ")
         .AppendLine("      , C.NombreCuenta AS cuenta ")
         .AppendLine("      , idRenglon ")
         .AppendLine("      , CASE WHEN debe = 0 THEN NULL ELSE debe END debe")
         .AppendLine("      , CASE WHEN haber = 0 THEN NULL ELSE haber END haber ")

         .AppendLine("      , AC.IdCuenta ")
         .AppendLine("      , A.FechaAsiento")
         .AppendLine("      , A.NombreAsiento")
         .AppendLine("      , AC.IdTipoReferencia")
         .AppendLine("      , AC.Referencia")
         .AppendLine("      , CASE WHEN AC.IdTipoReferencia = 'C' THEN CL.CodigoCliente WHEN AC.IdTipoReferencia = 'P' THEN PR.CodigoProveedor ELSE NULL END AS CodigoReferencia")
         .AppendLine("      , CASE WHEN AC.IdTipoReferencia = 'C' THEN CL.NombreCliente WHEN AC.IdTipoReferencia = 'P' THEN PR.NombreProveedor ELSE NULL END AS NombreReferencia")

         .AppendLine("      , AC.IdCentroCosto")
         .AppendLine("      , CCC.NombreCentroCosto")

         .Append("  FROM")
         If tipoRegistro = Entidades.ContabilidadReporte.TipoRegistro.DEFINITIVO Then
            .AppendLine(" ContabilidadAsientosCuentas AC")
            .AppendLine("  LEFT JOIN ContabilidadAsientos A ON A.IdEjercicio = AC.IdEjercicio AND A.IdPlanCuenta = AC.IdPlanCuenta AND A.IdAsiento = AC.IdAsiento")
         Else
            .AppendLine(" ContabilidadAsientosCuentasTmp AC")
            .AppendLine("  LEFT JOIN ContabilidadAsientosTmp A ON A.IdEjercicio = AC.IdEjercicio AND A.IdPlanCuenta = AC.IdPlanCuenta AND A.IdAsiento = AC.IdAsiento")
         End If
         .AppendLine("  LEFT JOIN ContabilidadPlanes Pl ON AC.IdPlanCuenta = PL.IdPlanCuenta")
         '.AppendLine("  LEFT JOIN ContabilidadPlanesCuentas PC ON A.IdPlanCuenta = PC.IdPlanCuenta AND AC.IdCuenta = PC.Idcuenta")
         .AppendLine("  LEFT JOIN ContabilidadCuentas C ON AC.IdCuenta = C.IdCuenta ")
         .AppendLine("  LEFT JOIN Clientes AS CL ON CL.IdCliente = CONVERT(BIGINT, AC.Referencia)")
         .AppendLine("  LEFT JOIN Proveedores AS PR ON PR.IdProveedor = CONVERT(BIGINT, AC.Referencia)")
         .AppendLine("  LEFT JOIN ContabilidadCentrosCostos CCC ON CCC.IdCentroCosto = AC.IdCentroCosto")

         .AppendLine(" WHERE 1 = 1 ")

         If tipoRegistro = Entidades.ContabilidadReporte.TipoRegistro.TEMPORAL Then
            .AppendLine("   AND (A.IdAsientoDefinitivo IS NULL OR A.IdAsientoDefinitivo = 0)")
         End If

         If idPlan <> -1 Then
            .AppendFormatLine("   AND A.IdPlanCuenta = {0}", idPlan)
         End If

         If idSucursales.Length = 1 Then
            .AppendFormatLine("   AND A.IdSucursal = {0}", idSucursales(0))
         ElseIf idSucursales.Length > 1 Then
            .Append("   AND A.IdSucursal IN (")
            For Each suc As Integer In idSucursales
               .AppendFormat("{0},", suc)
            Next
            .Remove(.Length - 1, 1)
            .AppendLine(")")
         End If

         If idAsiento <> -1 Then
            .AppendFormatLine("   AND A.idAsiento = {0}", idAsiento)
         End If

         If fechaDesde.HasValue Then
            .AppendFormatLine("   AND A.fechaAsiento >= '{0}'", Me.ObtenerFecha(fechaDesde.Value, False))
         End If
         If fechaHasta.HasValue Then
            .AppendFormatLine("   AND A.fechaAsiento <= '{0}'", Me.ObtenerFecha(fechaHasta.Value, False))
         End If

         If exportados = Entidades.Publicos.SiNoTodos.SI Then
            .AppendLine("   AND A.FechaExportacion IS NOT NULL")
         ElseIf exportados = Entidades.Publicos.SiNoTodos.NO Then
            .AppendLine("   AND A.FechaExportacion IS NULL")
         End If

         If idCentroCosto.HasValue AndAlso idCentroCosto.Value > 0 Then
            .AppendFormatLine("   AND AC.IdCentroCosto = {0}", idCentroCosto.Value)
         End If

      End With
      Return GetDataTable(stb)
   End Function

   Public Function LibroMayor(fdesde As Date?,
                              fhasta As Date?,
                              IdCuenta As Integer?,
                              IdCuentaHasta As Integer?,
                              idPlan As Integer?,
                              Sucursales As Integer(),
                              tipoReferencia As String,
                              referencia As String,
                              mostrarComprobanteOrigen As Boolean,
                              saldoInicial As Boolean,
                              idCentroCosto As Integer?,
                              mostrarCentroCosto As Boolean) As DataTable

      Dim stb As StringBuilder

      '---- INI - OBTENGO LA LISTA DE CUENTAS HIJAS DE LA CUENTA SELECCIONADA INCLUYENDO A ELLA MISMA
      Dim cuentas As StringBuilder = New StringBuilder()
      If IdCuenta.HasValue AndAlso Not IdCuentaHasta.HasValue Then
         stb = New StringBuilder()

         With stb
            .AppendFormat("WITH tree (IdCuenta, IdCuentaPadre, level, NombreCuenta, rn) as ").AppendLine()
            .AppendFormat("(").AppendLine()
            .AppendFormat("   SELECT IdCuenta, IdCuentaPadre, 0 as level, NombreCuenta,").AppendLine()
            .AppendFormat("       convert(varchar(max),right(row_number() over (order by IdCuenta),10)) rn").AppendLine()
            .AppendFormat("   FROM ContabilidadCuentas").AppendLine()
            .AppendFormat("   WHERE IdCuenta = {0}", IdCuenta.Value).AppendLine()
            .AppendFormat("   UNION ALL").AppendLine()
            .AppendFormat("   SELECT c2.IdCuenta, c2.IdCuentaPadre, tree.level + 1, c2.NombreCuenta,").AppendLine()
            .AppendFormat("       rn + '/' + convert(varchar(max),right(row_number() over (order by tree.IdCuenta),10))").AppendLine()
            .AppendFormat("   FROM ContabilidadCuentas c2 ").AppendLine()
            .AppendFormat("     INNER JOIN tree ON tree.IdCuenta = c2.IdCuentaPadre").AppendLine()
            .AppendFormat(")").AppendLine()
            .AppendFormat("SELECT * FROM tree ORDER BY RN").AppendLine()

            Dim dt As DataTable = GetDataTable(stb)

            For Each dr As DataRow In dt.Rows
               cuentas.AppendFormat("{0},", dr("IdCuenta"))
            Next
         End With
      End If
      '---- FIN - OBTENGO LA LISTA DE CUENTAS HIJAS DE LA CUENTA SELECCIONADA INCLUYENDO A ELLA MISMA

      stb = New StringBuilder()
      With stb
         .AppendFormat("SELECT Libro.Orden").AppendLine()
         .AppendFormat("      ,Libro.IdAsiento").AppendLine()
         .AppendFormat("      ,CASE WHEN Libro.Debe = 0 THEN NULL ELSE Libro.Debe END Debe").AppendLine()
         .AppendFormat("      ,CASE WHEN Libro.Haber = 0 THEN NULL ELSE Libro.Haber END Haber").AppendLine()
         .AppendFormat("      ,Libro.Saldo").AppendLine()
         .AppendFormat("      ,Libro.IdCuenta").AppendLine()
         .AppendFormat("      ,Libro.NombreCuenta").AppendLine()
         .AppendFormat("      ,Libro.FechaAsiento").AppendLine()
         .AppendFormat("      ,Libro.NombreAsiento").AppendLine()
         .AppendFormat("      ,Libro.IdTipoReferencia").AppendLine()
         .AppendFormat("      ,Libro.Referencia").AppendLine()
         .AppendFormat("      ,Libro.CodigoReferencia").AppendLine()
         .AppendFormat("      ,Libro.NombreReferencia").AppendLine()

         If mostrarComprobanteOrigen Then
            .AppendFormat("      ,CASE WHEN Ventas.IdSucursal IS NOT NULL THEN Ventas.IdSucursal ELSE").AppendLine()
            .AppendFormat("       CASE WHEN CuentasCorrientes.IdSucursal IS NOT NULL THEN CuentasCorrientes.IdSucursal ELSE").AppendLine()
            .AppendFormat("       CASE WHEN Compras.IdSucursal IS NOT NULL THEN Compras.IdSucursal ELSE").AppendLine()
            .AppendFormat("       CASE WHEN CuentasCorrientesProv.IdSucursal IS NOT NULL THEN CuentasCorrientesProv.IdSucursal ELSE").AppendLine()
            .AppendFormat("       NULL END END END END AS IdSucursal").AppendLine()

            .AppendFormat("      ,CASE WHEN Ventas.IdSucursal IS NOT NULL THEN Ventas.IdTipoComprobante ELSE").AppendLine()
            .AppendFormat("       CASE WHEN CuentasCorrientes.IdSucursal IS NOT NULL THEN CuentasCorrientes.IdTipoComprobante ELSE").AppendLine()
            .AppendFormat("       CASE WHEN Compras.IdSucursal IS NOT NULL THEN Compras.IdTipoComprobante ELSE").AppendLine()
            .AppendFormat("       CASE WHEN CuentasCorrientesProv.IdSucursal IS NOT NULL THEN CuentasCorrientesProv.IdTipoComprobante ELSE").AppendLine()
            .AppendFormat("       NULL END END END END AS IdTipoComprobante").AppendLine()

            .AppendFormat("      ,CASE WHEN Ventas.IdSucursal IS NOT NULL THEN Ventas.Letra ELSE").AppendLine()
            .AppendFormat("       CASE WHEN CuentasCorrientes.IdSucursal IS NOT NULL THEN CuentasCorrientes.Letra ELSE").AppendLine()
            .AppendFormat("       CASE WHEN Compras.IdSucursal IS NOT NULL THEN Compras.Letra ELSE").AppendLine()
            .AppendFormat("       CASE WHEN CuentasCorrientesProv.IdSucursal IS NOT NULL THEN CuentasCorrientesProv.Letra ELSE").AppendLine()
            .AppendFormat("       NULL END END END END AS Letra").AppendLine()

            .AppendFormat("      ,CASE WHEN Ventas.IdSucursal IS NOT NULL THEN Ventas.CentroEmisor ELSE").AppendLine()
            .AppendFormat("       CASE WHEN CuentasCorrientes.IdSucursal IS NOT NULL THEN CuentasCorrientes.CentroEmisor ELSE").AppendLine()
            .AppendFormat("       CASE WHEN Compras.IdSucursal IS NOT NULL THEN Compras.CentroEmisor ELSE").AppendLine()
            .AppendFormat("       CASE WHEN CuentasCorrientesProv.IdSucursal IS NOT NULL THEN CuentasCorrientesProv.CentroEmisor ELSE").AppendLine()
            .AppendFormat("       NULL END END END END AS CentroEmisor").AppendLine()

            .AppendFormat("      ,CASE WHEN Ventas.IdSucursal IS NOT NULL THEN Ventas.NumeroComprobante ELSE").AppendLine()
            .AppendFormat("       CASE WHEN CuentasCorrientes.IdSucursal IS NOT NULL THEN CuentasCorrientes.NumeroComprobante ELSE").AppendLine()
            .AppendFormat("       CASE WHEN Compras.IdSucursal IS NOT NULL THEN Compras.NumeroComprobante ELSE").AppendLine()
            .AppendFormat("       CASE WHEN CuentasCorrientesProv.IdSucursal IS NOT NULL THEN CuentasCorrientesProv.NumeroComprobante ELSE").AppendLine()
            .AppendFormat("       NULL END END END END AS NumeroComprobante").AppendLine()
         End If
         If mostrarCentroCosto Then
            .AppendFormat("      ,Libro.IdCentroCosto")
            .AppendFormat("      ,Libro.NombreCentroCosto")
         End If

         .AppendFormat("  FROM (")
         If saldoInicial Then

            .AppendFormat("        SELECT SaldoInicial.Orden").AppendLine()
            .AppendFormat("              ,SaldoInicial.IdPlanCuenta").AppendLine()
            .AppendFormat("              ,SaldoInicial.IdAsiento").AppendLine()
            .AppendFormat("              ,CONVERT(DECIMAL(12,2), CASE WHEN SaldoInicial.Debe > SaldoInicial.Haber THEN SaldoInicial.Debe - SaldoInicial.Haber ELSE 0 END) AS Debe").AppendLine()
            .AppendFormat("              ,CONVERT(DECIMAL(12,2), CASE WHEN SaldoInicial.Debe < SaldoInicial.Haber THEN SaldoInicial.Haber - SaldoInicial.Debe ELSE 0 END) AS Haber").AppendLine()
            .AppendFormat("              ,SaldoInicial.Saldo").AppendLine()
            .AppendFormat("              ,SaldoInicial.IdCuenta").AppendLine()
            .AppendFormat("              ,SaldoInicial.NombreCuenta").AppendLine()
            .AppendFormat("              ,SaldoInicial.FechaAsiento").AppendLine()
            .AppendFormat("              ,SaldoInicial.NombreAsiento").AppendLine()
            .AppendFormat("              ,NULL AS IdTipoReferencia").AppendLine()
            .AppendFormat("              ,NULL AS Referencia").AppendLine()
            .AppendFormat("              ,NULL AS CodigoReferencia").AppendLine()
            .AppendFormat("              ,NULL AS NombreReferencia").AppendLine()
            If mostrarCentroCosto Then
               .AppendFormat("              ,SaldoInicial.IdCentroCosto")
               .AppendFormat("              ,SaldoInicial.NombreCentroCosto")
            End If
            .AppendFormat("          FROM (SELECT 0 AS Orden ").AppendLine()
            .AppendFormat("                      ,AC.IdPlanCuenta").AppendLine()
            .AppendFormat("                      ,NULL AS IdAsiento ").AppendLine()
            .AppendFormat("                      ,SUM(Debe) AS Debe").AppendLine()
            .AppendFormat("                      ,SUM(Haber) AS Haber").AppendLine()
            .AppendFormat("                      ,SUM(CONVERT(DECIMAL(12,2), 0)) AS Saldo").AppendLine()
            .AppendFormat("                      ,AC.IdCuenta").AppendLine()
            .AppendFormat("                      ,CC.NombreCuenta").AppendLine()
            .AppendFormat("                      ,NULL AS FechaAsiento").AppendLine()
            .AppendFormat("                      ,'SALDO INICIAL AL {0}' AS NombreAsiento", fdesde.Value.ToString("dd/MM/yyyy")).AppendLine()
            If mostrarCentroCosto Then
               .AppendFormat("                      ,AC.IdCentroCosto")
               .AppendFormat("                      ,CCC.NombreCentroCosto")
            End If
            .AppendFormatLine("                  FROM ContabilidadAsientosCuentas AS AC")
            .AppendFormatLine("                 INNER JOIN ContabilidadAsientos AS A ON A.IdEjercicio = AC.IdEjercicio AND A.IdPlanCuenta = AC.IdPlanCuenta AND A.IdAsiento = AC.IdAsiento")
            .AppendFormatLine("                 INNER JOIN ContabilidadCuentas AS CC ON AC.IdCuenta = CC.IdCuenta")
            If mostrarCentroCosto Then
               .AppendFormat("                 INNER JOIN ContabilidadCentrosCostos AS CCC ON AC.IdCentroCosto = CCC.IdCentroCosto")
            End If
            .AppendFormat("                 WHERE 1 = 1").AppendLine()
            If idPlan.HasValue And idPlan.Value > 0 Then
               .AppendFormat("                   AND A.IdPlanCuenta = {0}", idPlan.Value).AppendLine()
            End If
            If Sucursales.Length > 0 Then
               Dim suc As StringBuilder = New StringBuilder()
               For Each s As Integer In Sucursales
                  suc.AppendFormat("{0},", s)
               Next
               .AppendFormat("                   AND A.IdSucursal IN ({0})", suc.ToString().Trim(","c)).AppendLine()
            End If

            If IdCuenta.HasValue AndAlso IdCuentaHasta.HasValue Then
               .AppendFormat("                   AND AC.IdCuenta >= {0}", IdCuenta.Value).AppendLine()
               .AppendFormat("                   AND AC.IdCuenta <= {0}", IdCuentaHasta.Value).AppendLine()
            ElseIf IdCuenta.HasValue Then
               '.AppendFormat("                   AND AC.IdCuenta = {0}", IdCuenta.Value).AppendLine()
               .AppendFormat("                   AND AC.IdCuenta IN ({0})", cuentas.ToString().Trim(","c)).AppendLine()
            End If

            If fdesde.HasValue Then
               .AppendFormat("                   AND A.FechaAsiento >= (SELECT FechaDesde FROM ContabilidadEjercicios WHERE FechaDesde <= '{0}' AND FechaHasta >= '{0}')", ObtenerFecha(fdesde.Value, False)).AppendLine()
               .AppendFormat("                   AND A.FechaAsiento < '{0}'", ObtenerFecha(fdesde.Value, False)).AppendLine()
            End If

            If Not String.IsNullOrWhiteSpace(tipoReferencia) And Not String.IsNullOrWhiteSpace(referencia) Then
               .AppendFormat("                   AND AC.IdTipoReferencia = '{0}'", tipoReferencia).AppendLine()
               .AppendFormat("                   AND AC.Referencia = '{0}'", referencia).AppendLine()
            End If

            If idCentroCosto.HasValue AndAlso idCentroCosto.Value > 0 Then
               .AppendFormat("           AND AC.IdCentroCosto = {0}", idCentroCosto.Value).AppendLine()
            End If

            .AppendFormat("                 GROUP BY AC.IdPlanCuenta, AC.IdCuenta, CC.NombreCuenta").AppendLine()
            If mostrarCentroCosto Then
               .AppendFormat("                         , AC.IdCentroCosto, CCC.NombreCentroCosto").AppendLine()
            End If
            .AppendFormat("                 ) AS SaldoInicial").AppendLine()
            .AppendFormat("        UNION ALL").AppendLine()

         End If


         .AppendFormat("        SELECT 1 AS Orden").AppendLine()
         .AppendFormat("              ,AC.IdPlanCuenta").AppendLine()
         .AppendFormat("              ,AC.IdAsiento").AppendLine()
         .AppendFormat("              ,SUM(Debe) as Debe").AppendLine()
         .AppendFormat("              ,SUM(Haber) as Haber").AppendLine()
         .AppendFormat("              ,CONVERT(DECIMAL(12,2), 0) AS Saldo").AppendLine()
         .AppendFormat("              ,AC.IdCuenta").AppendLine()
         .AppendFormat("              ,CC.NombreCuenta").AppendLine()
         .AppendFormat("              ,A.FechaAsiento").AppendLine()
         .AppendFormat("              ,A.NombreAsiento").AppendLine()
         .AppendFormat("              ,AC.IdTipoReferencia").AppendLine()
         .AppendFormat("              ,AC.Referencia").AppendLine()
         .AppendFormat("              ,CASE WHEN AC.IdTipoReferencia = 'C' THEN CL.CodigoCliente WHEN AC.IdTipoReferencia = 'P' THEN PR.CodigoProveedor ELSE NULL END AS CodigoReferencia").AppendLine()
         .AppendFormat("              ,CASE WHEN AC.IdTipoReferencia = 'C' THEN CL.NombreCliente WHEN AC.IdTipoReferencia = 'P' THEN PR.NombreProveedor ELSE NULL END AS NombreReferencia").AppendLine()
         If mostrarCentroCosto Then
            .AppendFormat("              ,AC.IdCentroCosto")
            .AppendFormat("              ,CCC.NombreCentroCosto")
         End If
         .AppendFormatLine("          FROM ContabilidadAsientosCuentas AS AC")
         .AppendFormatLine("         INNER JOIN ContabilidadAsientos AS A ON A.IdEjercicio = AC.IdEjercicio AND A.IdPlanCuenta = AC.IdPlanCuenta AND A.IdAsiento = AC.IdAsiento")
         .AppendFormatLine("         INNER JOIN ContabilidadCuentas AS CC ON AC.IdCuenta = CC.IdCuenta")
         .AppendFormatLine("         LEFT JOIN Clientes AS CL ON CL.IdCliente = CONVERT(bigint, AC.Referencia)")
         .AppendFormatLine("         LEFT JOIN Proveedores AS PR ON PR.IdProveedor = CONVERT(bigint, AC.Referencia)")
         If mostrarCentroCosto Then
            .AppendFormat("        INNER JOIN ContabilidadCentrosCostos AS CCC ON AC.IdCentroCosto = CCC.IdCentroCosto")
         End If
         .AppendFormat("         WHERE 1 = 1").AppendLine()


         If idPlan.HasValue And idPlan.Value > 0 Then
            .AppendFormat("           AND A.IdPlanCuenta = {0}", idPlan.Value).AppendLine()
         End If
         If Sucursales.Length > 0 Then
            Dim suc As StringBuilder = New StringBuilder()
            For Each s As Integer In Sucursales
               suc.AppendFormat("{0},", s)
            Next
            .AppendFormat("           AND A.IdSucursal IN ({0})", suc.ToString().Trim(","c)).AppendLine()
         End If
         If IdCuenta.HasValue AndAlso IdCuentaHasta.HasValue Then
            .AppendFormat("           AND AC.IdCuenta >= {0}", IdCuenta.Value).AppendLine()
            .AppendFormat("           AND AC.IdCuenta <= {0}", IdCuentaHasta.Value).AppendLine()
         ElseIf IdCuenta.HasValue Then
            '.AppendFormat("           AND AC.IdCuenta = {0}", IdCuenta.Value).AppendLine()
            .AppendFormat("           AND AC.IdCuenta IN ({0})", cuentas.ToString().Trim(","c)).AppendLine()
         End If

         If fdesde.HasValue Then
            .AppendFormat("           AND A.FechaAsiento >= '{0}'", ObtenerFecha(fdesde.Value, False)).AppendLine()
         End If

         If fhasta.HasValue Then
            .AppendFormat("           AND A.FechaAsiento <= '{0}'", ObtenerFecha(fhasta.Value, False)).AppendLine()
         End If

         If Not String.IsNullOrWhiteSpace(tipoReferencia) And Not String.IsNullOrWhiteSpace(referencia) Then
            .AppendFormat("           AND AC.IdTipoReferencia = '{0}'", tipoReferencia).AppendLine()
            .AppendFormat("           AND AC.Referencia = '{0}'", referencia).AppendLine()
         End If

         If idCentroCosto.HasValue AndAlso idCentroCosto.Value > 0 Then
            .AppendFormat("           AND AC.IdCentroCosto = {0}", idCentroCosto.Value).AppendLine()
         End If
         .AppendFormat("         GROUP BY AC.IdPlanCuenta, AC.IdAsiento, AC.IdCuenta, CC.NombreCuenta, A.FechaAsiento, A.NombreAsiento, AC.IdTipoReferencia")
         .AppendFormat("                , AC.Referencia, CL.CodigoCliente, PR.CodigoProveedor, CL.NombreCliente, PR.NombreProveedor")
         If mostrarCentroCosto Then
            .AppendFormat("                , AC.IdCentroCosto, CCC.NombreCentroCosto")
         End If
         .AppendLine(") AS Libro")

         If mostrarComprobanteOrigen Then
            .AppendFormat("  LEFT JOIN Ventas ON Ventas.IdAsiento = Libro.IdAsiento AND Ventas.IdPlanCuenta = Libro.IdPlanCuenta")
            .AppendFormat("  LEFT JOIN CuentasCorrientes ON CuentasCorrientes.IdAsiento = Libro.IdAsiento AND CuentasCorrientes.IdPlanCuenta = Libro.IdPlanCuenta")
            .AppendFormat("  LEFT JOIN Compras ON Compras.IdAsiento = Libro.IdAsiento AND Compras.IdPlanCuenta = Libro.IdPlanCuenta")
            .AppendFormat("  LEFT JOIN CuentasCorrientesProv ON CuentasCorrientesProv.IdAsiento = Libro.IdAsiento AND CuentasCorrientesProv.IdPlanCuenta = Libro.IdPlanCuenta")
         End If

         .AppendFormat(" ORDER BY Libro.Orden, Libro.FechaAsiento, Libro.IdAsiento, Libro.NombreAsiento").AppendLine()
         If mostrarCentroCosto Then
            .AppendFormat("      , Libro.NombreCentroCosto, Libro.IdCentroCosto").AppendLine()
         End If

      End With

      Return GetDataTable(stb)

   End Function


   Public Function Balance(fHasta As Date,
                           idPlan As Integer,
                           idSucursales As Integer()) As DataTable

      Dim stb As StringBuilder = New StringBuilder()

      With stb
         If idPlan = -1 Then ' esto se usa para el consolidado
            .AppendLine("select X.IdCuenta,x.NombreCuenta  ,sum(x.saldoCuenta )as saldoCuenta  from (")
         End If
         .AppendLine(" select pc.IdPlanCuenta,pl.NombrePlanCuenta ")
         .AppendLine(" ,c.IdCuenta,c.NombreCuenta ")
         .AppendLine(" ,SUM(ac.debe)-SUM(ac.haber) as saldoCuenta ")
         '.AppendLine(" ,SUM(ac.debe) as debe,SUM(ac.haber) As haber ")
         .AppendLine(" FROM ContabilidadAsientos A, ")
         .AppendLine("      ContabilidadAsientosCuentas AC, ")
         .AppendLine("      ContabilidadCuentas C, ")
         .AppendLine("      ContabilidadPlanesCuentas PC, ")
         .AppendLine("      ContabilidadPlanes Pl ")
         .AppendLine(" WHERE A.IdEjercicio = AC.IdEjercicio")
         .AppendLine("   AND A.IdPlanCuenta = AC.IdPlanCuenta")
         .AppendLine("   AND a.idAsiento=ac.idAsiento ")
         .AppendLine("   and ac.IdCuenta=c.IdCuenta ")
         .AppendLine("   and c.IdCuenta=pc.IdCuenta ")
         .AppendLine("   and A.IdPlanCuenta=pc.IdPlanCuenta ")
         .AppendLine("   and PC.IdPlanCuenta=PL.IdPlanCuenta ")
         .AppendLine("   and c.nivel=4")
         .AppendLine("   and substring(str(ac.IdCuenta),3,1)<>'4' ") '-- todas las ContabilidadCuentas menos las de Resultado 
         .AppendLine("   and a.fechaAsiento <= '" & Me.ObtenerFecha(fHasta, False) & "'")

         If idPlan <> -1 Then
            .AppendLine(" and A.IdPlanCuenta=  " & idPlan.ToString)
         End If

         If idSucursales.Length = 1 Then
            .AppendLine("	and A.IdSucursal = " & idSucursales(0).ToString())
         ElseIf idSucursales.Length > 1 Then
            .AppendLine("	And A.IdSucursal IN (")
            For Each suc As Integer In idSucursales
               .AppendFormat("{0},", suc)
            Next
            .Remove(.Length - 1, 1)
            .AppendLine(")")
         End If

         .AppendLine(" group by pc.IdPlanCuenta,pl.NombrePlanCuenta ")
         .AppendLine(" ,c.IdCuenta,c.NombreCuenta,ac.IdCuenta ")

         If idPlan = -1 Then
            .AppendLine(" ) X group by X.IdCuenta,x.NombreCuenta ")
         End If

      End With

      Return GetDataTable(stb)

   End Function

   Public Function BlanceNivel4(fHasta As Date,
                                idplan As Integer,
                                mesDia As String,
                                idSucursales As Integer()) As DataTable

      Dim stb As StringBuilder = New StringBuilder()
      With stb
         If idplan = -1 Then ' esto se usa para el consolidado
            .AppendLine("select X.IdCuenta,x.NombreCuenta  ,sum(x.saldoCuenta ) as saldoCuenta  from (")
         End If
         .AppendLine("select pc.IdPlanCuenta,pl.NombrePlanCuenta ")
         .AppendLine(" ,c.IdCuenta,c.NombreCuenta ")
         .AppendLine(" ,SUM(ac.debe)-SUM(ac.haber) as saldoCuenta ")
         '.AppendLine(" ,SUM(ac.debe) as debe,SUM(ac.haber) As haber ")
         .AppendLine(" from ")
         .AppendLine(" ContabilidadAsientos A, ")
         .AppendLine(" ContabilidadAsientosCuentas AC, ")
         .AppendLine(" ContabilidadCuentas C, ")
         .AppendLine(" ContabilidadPlanesCuentas PC, ")
         .AppendLine(" ContabilidadPlanes Pl ")
         .AppendLine(" WHERE A.IdEjercicio = AC.IdEjercicio")
         .AppendLine("   AND A.IdPlanCuenta = AC.IdPlanCuenta")
         .AppendLine("   AND a.idAsiento=ac.idAsiento ")
         .AppendLine(" and ac.IdCuenta=c.IdCuenta ")
         .AppendLine(" and c.IdCuenta=pc.IdCuenta ")
         .AppendLine(" and A.IdPlanCuenta=pc.IdPlanCuenta ")
         .AppendLine(" and PC.IdPlanCuenta=PL.IdPlanCuenta ")

         .AppendLine(" and c.nivel=4 ")

         .AppendLine(" and substring(str(ac.IdCuenta),3,1)='4'  ") '-- todas las cuentas  de Resultado

         '  .AppendLine(" and a.fechaAsiento between '01/01/" & fHasta.Year.ToString & "' and '" & Me.ObtenerFecha(fHasta, False) & "'")
         '.AppendLine(" and a.fechaAsiento between '" & mesDia & "/" & fHasta.Year.ToString & "' and '" & Me.ObtenerFecha(fHasta, False) & "'")

         .AppendLine(" and a.fechaAsiento between '" & fHasta.Year.ToString() & mesDia & "' and '" & fHasta.ToString("yyyyMMdd") & "'")

         If idplan <> -1 Then
            .AppendLine(" and A.IdPlanCuenta=  " & idplan.ToString())
         End If

         If idSucursales.Length = 1 Then
            .AppendLine("	and A.IdSucursal = " & idSucursales(0).ToString())
         ElseIf idSucursales.Length > 1 Then
            .AppendLine("	And A.IdSucursal IN (")
            For Each suc As Integer In idSucursales
               .AppendFormat("{0},", suc)
            Next
            .Remove(.Length - 1, 1)
            .AppendLine(")")
         End If


         .AppendLine(" group by pc.IdPlanCuenta,pl.NombrePlanCuenta ")
         .AppendLine(" ,c.IdCuenta,c.NombreCuenta,ac.IdCuenta ")

         If idplan = -1 Then
            .AppendLine(" ) X group by X.IdCuenta,x.NombreCuenta ")
         End If
         '.AppendLine(" order by c.IdCuenta,c.NombreCuenta")
      End With

      Return GetDataTable(stb)

   End Function

   Public Function BalanceN4Anterior(fHasta As Date,
                                     idplan As Integer,
                                     mesDia As String,
                                     idSucursales As Integer()) As DataTable

      Dim stb As StringBuilder = New StringBuilder()
      With stb
         .AppendLine(" select ISNULL(SUM(x.Saldocuenta),0) as SaldoAnterior from (")
         .AppendLine("select pc.IdPlanCuenta,pl.NombrePlanCuenta ")
         .AppendLine(" ,c.IdCuenta,c.NombreCuenta ")
         .AppendLine(" ,SUM(ac.debe)-SUM(ac.haber) as saldoCuenta ")
         ' .AppendLine(" ,SUM(ac.debe) as debe,SUM(ac.haber) As haber ")
         .AppendLine(" from ContabilidadAsientos A, ")
         .AppendLine(" ContabilidadAsientosCuentas AC, ")
         .AppendLine(" ContabilidadCuentas C, ")
         .AppendLine(" ContabilidadPlanesCuentas PC, ")
         .AppendLine(" ContabilidadPlanes Pl ")
         .AppendLine(" WHERE A.IdEjercicio = AC.IdEjercicio")
         .AppendLine("   AND A.IdPlanCuenta = AC.IdPlanCuenta")
         .AppendLine("   AND a.idAsiento=ac.idAsiento ")
         .AppendLine(" and ac.IdCuenta=c.IdCuenta ")
         .AppendLine(" and c.IdCuenta=pc.IdCuenta ")
         .AppendLine(" and A.IdPlanCuenta=pc.IdPlanCuenta ")
         .AppendLine(" and PC.IdPlanCuenta=PL.IdPlanCuenta ")

         '.AppendLine(" a.idAsiento=ac.idAsiento ")
         '.AppendLine(" and ac.IdCuenta=c.IdCuenta ")
         '.AppendLine(" and c.IdCentroCosto=cc.IdCentroCosto ")
         .AppendLine(" and c.nivel=4 ")
         .AppendLine(" and substring(str(ac.IdCuenta),3,1)='4' ") ' -- todas las cuentas de Resultado

         '  .AppendLine(" and a.fechaAsiento <= '31/12/" & fHasta.AddYears(-1).Year.ToString & "'") '--- and '09/10/2011'
         '.AppendLine(" and a.fechaAsiento <= '" & diaMes & "/" & fHasta.AddYears(-1).Year.ToString & "'") '--- and '09/10/2011'
         .AppendLine(" and a.fechaAsiento <= '" & fHasta.AddYears(-1).Year.ToString() & mesDia & "'") '--- and 'aaaa/mm/dd'

         If idplan <> -1 Then
            .AppendLine(" and a.IdPlanCuenta=  " & idplan.ToString)
         End If

         If idSucursales.Length = 1 Then
            .AppendLine("	and A.IdSucursal = " & idSucursales(0).ToString())
         ElseIf idSucursales.Length > 1 Then
            .AppendLine("	And A.IdSucursal IN (")
            For Each suc As Integer In idSucursales
               .AppendFormat("{0},", suc)
            Next
            .Remove(.Length - 1, 1)
            .AppendLine(")")
         End If

         .AppendLine(" group by pc.IdPlanCuenta,pl.NombrePlanCuenta  ")
         .AppendLine(" ,c.IdCuenta,c.NombreCuenta,ac.IdCuenta ")
         .AppendLine(" ) x ")

      End With

      Return GetDataTable(stb)

   End Function

   Public Function LibroDiario(fDesde As Date?,
                               fHasta As Date?,
                               idPlan As Integer,
                               idSucursales As Integer()) As DataTable

      Dim stb As StringBuilder = New StringBuilder()
      With stb
         .AppendLine("SELECT AC.IdAsiento ")
         .AppendLine("      ,AC.Debe ")
         .AppendLine("      ,AC.Haber ")
         .AppendLine("      ,AC.IdCuenta ")
         .AppendLine("      ,C.NombreCuenta ")
         .AppendLine("      ,A.FechaAsiento")
         .AppendLine("      ,A.NombreAsiento")
         .AppendLine("  FROM ContabilidadAsientos AS A")
         .AppendLine(" INNER JOIN ContabilidadAsientosCuentas AS AC ON AC.IdEjercicio = A.IdEjercicio AND AC.IdPlanCuenta = A.IdPlanCuenta AND AC.IdAsiento = A.IdAsiento")
         .AppendLine(" INNER JOIN ContabilidadPlanesCuentas AS PC ON PC.IdPlanCuenta = AC.IdPlanCuenta AND PC.IdCuenta = AC.IdCuenta")
         .AppendLine(" INNER JOIN ContabilidadPlanes AS PL ON PL.IdPlanCuenta = PC.IdPlanCuenta")
         .AppendLine(" INNER JOIN ContabilidadCuentas AS C ON C.IdCuenta = AC.IdCuenta")

         .AppendLine(" WHERE 1 = 1")

         If idPlan <> -1 Then
            .AppendLine(" and A.IdPlanCuenta = " & idPlan.ToString)
         End If

         If idSucursales.Length = 1 Then
            .AppendLine("	and A.IdSucursal = " & idSucursales(0).ToString())
         ElseIf idSucursales.Length > 1 Then
            .AppendLine("	And A.IdSucursal IN (")
            For Each suc As Integer In idSucursales
               .AppendFormat("{0},", suc)
            Next
            .Remove(.Length - 1, 1)
            .AppendLine(")")
         End If

         'If IdCuenta <> -1 Then
         '    .AppendLine(" AND AC.IdCuenta=" & IdCuenta.ToString)
         'End If

         'If fdesde <> Date.MinValue Then
         '    .AppendLine(" AND A.fechaAsiento >='" & Me.ObtenerFecha(fdesde, False) & "'")
         'End If
         If fDesde.HasValue Then
            .AppendLine(" AND A.fechaAsiento >='" & Me.ObtenerFecha(fDesde.Value, False) & "'")
         End If
         If fHasta.HasValue Then
            .AppendLine(" AND A.fechaAsiento <='" & Me.ObtenerFecha(fHasta.Value, False) & "'")
         End If

      End With

      Return GetDataTable(stb)

   End Function

   Public Function LibroDiarioRefundicion(fhasta As Date,
                                          idPlan As Integer,
                                          idSucursales As Integer(),
                                          mesdia As String) As DataTable

      Dim stb As StringBuilder = New StringBuilder()
      With stb
         .AppendLine("SELECT AC.idAsiento ")
         .AppendLine(",Debe ")
         .AppendLine(",Haber ")
         .AppendLine(",AC.IdCuenta ")
         .AppendLine(",c.NombreCuenta")
         .AppendLine(",A.fechaAsiento")
         .AppendLine(",A.NombreAsiento")

         .AppendLine("FROM ContabilidadAsientosCuentas AC, ContabilidadAsientos A ")
         .AppendLine(" ,ContabilidadPlanesCuentas PC ")
         .AppendLine(" ,ContabilidadPlanes Pl ")
         .AppendLine(" ,ContabilidadCuentas C ")

         .AppendLine(" WHERE A.IdEjercicio = AC.IdEjercicio")
         .AppendLine("   AND A.IdPlanCuenta = AC.IdPlanCuenta")
         .AppendLine("   AND a.idAsiento=ac.idAsiento ")
         .AppendLine(" and ac.IdCuenta=c.IdCuenta ")
         .AppendLine(" and c.IdCuenta=pc.IdCuenta ")
         .AppendLine(" and A.IdPlanCuenta=pc.IdPlanCuenta ")
         .AppendLine(" and PC.IdPlanCuenta=PL.IdPlanCuenta ")

         If idPlan <> -1 Then
            .AppendLine(" and A.IdPlanCuenta = " & idPlan.ToString)
         End If

         If idSucursales.Length = 1 Then
            .AppendLine("	and A.IdSucursal = " & idSucursales(0).ToString())
         ElseIf idSucursales.Length > 1 Then
            .AppendLine("	And A.IdSucursal IN (")
            For Each suc As Integer In idSucursales
               .AppendFormat("{0},", suc)
            Next
            .Remove(.Length - 1, 1)
            .AppendLine(")")
         End If

         .AppendLine(" and c.nivel=4 ")

         .AppendLine(" and substring(str(ac.IdCuenta),3,1)='4'  ") '-- todas las cuentas  de Resultado

         'If fdesde <> Date.MinValue Then
         '    .AppendLine(" AND A.fechaAsiento >='" & Me.ObtenerFecha(fdesde, False) & "'")
         'End If
         If fhasta <> Date.MinValue Then
            ' .AppendLine(" AND A.fechaAsiento <='" & Me.ObtenerFecha(fhasta, False) & "'")

            .AppendLine(" and a.fechaAsiento between '" & fhasta.Year.ToString() & mesdia & "' and '" & fhasta.ToString("yyyyMMdd") & "'")


         End If

      End With

      Return GetDataTable(stb)

   End Function

   Public Function LibroDiarioAperturaYCierre(fdesde As Date,
                                              fhasta As Date,
                                              IdCuenta As Integer,
                                              idPlan As Integer,
                                              idSucursales As Integer()) As DataTable
      Dim stb As StringBuilder = New StringBuilder()
      With stb
         .AppendLine("  select X.IdCuenta,x.NombreCuenta  ,sum(x.saldoCuenta ) as saldoCuenta  from ( ")
         .AppendLine(" SELECT AC.idAsiento  ")
         '  .AppendLine(" --,debe  ")
         ' .AppendLine(" --,haber ")
         .AppendLine(" ,AC.IdCuenta")
         .AppendLine(" ,c.NombreCuenta")
         .AppendLine(" ,SUM(ac.debe)-SUM(ac.haber) as saldoCuenta ")
         '  .AppendLine(" --,A.fechaAsiento")
         ' .AppendLine(" --,A.NombreAsiento")
         .AppendLine(" FROM ContabilidadAsientosCuentas AC, ContabilidadAsientos A ")
         .AppendLine(" ,ContabilidadPlanesCuentas PC ")
         .AppendLine(" ,ContabilidadPlanes Pl ")
         .AppendLine(" ,ContabilidadCuentas C ")
         .AppendLine(" WHERE A.IdEjercicio = AC.IdEjercicio")
         .AppendLine(" AND A.IdPlanCuenta = AC.IdPlanCuenta")
         .AppendLine(" AND a.idAsiento=ac.idAsiento ")
         .AppendLine(" and ac.IdCuenta=c.IdCuenta ")
         .AppendLine(" and c.IdCuenta=pc.IdCuenta ")
         .AppendLine(" and A.IdPlanCuenta=pc.IdPlanCuenta ")
         .AppendLine(" and PC.IdPlanCuenta=PL.IdPlanCuenta ")

         If idPlan <> -1 Then
            .AppendLine(" and A.IdPlanCuenta = " & idPlan.ToString)
         End If

         If idSucursales.Length = 1 Then
            .AppendLine("	and A.IdSucursal = " & idSucursales(0).ToString())
         ElseIf idSucursales.Length > 1 Then
            .AppendLine("	And A.IdSucursal IN (")
            For Each suc As Integer In idSucursales
               .AppendFormat("{0},", suc)
            Next
            .Remove(.Length - 1, 1)
            .AppendLine(")")
         End If

         If fdesde <> Date.MinValue Then
            .AppendLine(" AND A.fechaAsiento >='" & Me.ObtenerFecha(fdesde, False) & "'")
         End If
         If fhasta <> Date.MinValue Then
            .AppendLine(" AND A.fechaAsiento <='" & Me.ObtenerFecha(fhasta, False) & "'")
         End If

         .AppendLine(" and c.nivel=4 ")
         .AppendLine(" and substring(str(ac.IdCuenta),3,1)<>'4' ") '-- todas las cuentas NO de Resultado")
         .AppendLine(" group by ac.IdAsiento,pc.IdPlanCuenta,pl.NombrePlanCuenta ")
         .AppendLine(" ,c.NombreCuenta,ac.IdCuenta ")
         .AppendLine(" ) X group by X.IdCuenta,x.NombreCuenta ")


      End With

      Return GetDataTable(stb)

   End Function



   Public Function BalanceGral(fHasta As Date,
                               idPlan As Integer,
                               idSucursales As Integer()) As DataTable
      Dim stb As StringBuilder = New StringBuilder()
      With stb
         .AppendLine("  select y.*, ")
         .AppendLine(" cn2.nombreCuenta from  ")
         .AppendLine(" ( ")
         .AppendLine(" select x.IdPlanCuenta,x.NombrePlanCuenta,  ")
         .AppendLine(" sum(x.saldoCuenta) saldoCuenta ")
         .AppendLine(" ,substring(str(x.IdCuenta),3,3)+'00000' idCuenta from  ")
         .AppendLine(" ( ")
         .AppendLine(" select pc.IdPlanCuenta,pl.NombrePlanCuenta  ")
         .AppendLine(" ,c.IdCuenta,c.NombreCuenta ,c.Nivel ")
         .AppendLine(" ,SUM(ac.debe)-SUM(ac.haber) as saldoCuenta  ")
         .AppendLine(" FROM ContabilidadAsientos A,  ")
         .AppendLine(" ContabilidadAsientosCuentas AC,  ")
         .AppendLine(" ContabilidadCuentas C,  ")
         .AppendLine(" ContabilidadPlanesCuentas PC,  ")
         .AppendLine(" ContabilidadPlanes Pl  ")
         .AppendLine(" WHERE A.IdEjercicio = AC.IdEjercicio")
         .AppendLine(" AND A.IdPlanCuenta = AC.IdPlanCuenta")
         .AppendLine(" AND a.idAsiento=ac.idAsiento  ")
         .AppendLine(" and ac.IdCuenta=c.IdCuenta  ")
         .AppendLine(" and c.IdCuenta=pc.IdCuenta  ")
         .AppendLine(" and A.IdPlanCuenta=pc.IdPlanCuenta  ")
         .AppendLine(" and PC.IdPlanCuenta=PL.IdPlanCuenta  ")
         .AppendLine(" and c.nivel=4 ")
         .AppendLine(" and substring(str(ac.IdCuenta),3,1)<>'4'  ")
         .AppendLine("   and a.fechaAsiento <= '" & Me.ObtenerFecha(fHasta, False) & "'")
         If idPlan <> -1 Then
            .AppendLine(" and A.IdPlanCuenta=  " & idPlan.ToString)
         End If

         If idSucursales.Length = 1 Then
            .AppendLine("	and A.IdSucursal = " & idSucursales(0).ToString())
         ElseIf idSucursales.Length > 1 Then
            .AppendLine("	And A.IdSucursal IN (")
            For Each suc As Integer In idSucursales
               .AppendFormat("{0},", suc)
            Next
            .Remove(.Length - 1, 1)
            .AppendLine(")")
         End If
         .AppendLine(" group by pc.IdPlanCuenta,pl.NombrePlanCuenta  ")
         .AppendLine(" ,c.IdCuenta,c.NombreCuenta,ac.IdCuenta ,c.Nivel ")
         .AppendLine(" ) x ")
         .AppendLine(" group by x.IdPlanCuenta,x.NombrePlanCuenta, ")
         .AppendLine(" substring(str(x.IdCuenta),3,3) ")
         .AppendLine(" )y ")
         .AppendLine(" ,ContabilidadCuentas cn2  ")
         .AppendLine(" where cn2.IdCuenta=y.idcuenta ")

      End With

      Return GetDataTable(stb)

   End Function


   Public Function BalanceGralActivoCorriente(fHasta As Date,
                                              idPlan As Integer,
                                              idSucursales As Integer()) As DataTable
      Dim stb As StringBuilder = New StringBuilder()
      With stb
         .AppendLine("  select '1' as codGrupo, 'ACTIVO' as grupo, '1' AS codTipo,'ACTIVO CORRIENTE' as tipo,y.*, ")
         .AppendLine(" cn2.nombreCuenta from  ")
         .AppendLine(" ( ")
         .AppendLine(" select x.IdPlanCuenta,x.NombrePlanCuenta,  ")
         .AppendLine(" sum(x.saldoCuenta) saldoCuenta ")
         .AppendLine(" ,substring(str(x.IdCuenta),3,3)+'00000' idCuenta from  ")
         .AppendLine(" ( ")
         .AppendLine(" select pc.IdPlanCuenta,pl.NombrePlanCuenta  ")
         .AppendLine(" ,c.IdCuenta,c.NombreCuenta ,c.Nivel ")
         .AppendLine(" ,SUM(ac.debe)-SUM(ac.haber) as saldoCuenta  ")
         .AppendLine(" FROM ContabilidadAsientos A,  ")
         .AppendLine(" ContabilidadAsientosCuentas AC,  ")
         .AppendLine(" ContabilidadCuentas C,  ")
         .AppendLine(" ContabilidadPlanesCuentas PC,  ")
         .AppendLine(" ContabilidadPlanes Pl  ")
         .AppendLine(" WHERE A.IdEjercicio = AC.IdEjercicio")
         .AppendLine(" AND A.IdPlanCuenta = AC.IdPlanCuenta")
         .AppendLine(" AND a.idAsiento=ac.idAsiento  ")
         .AppendLine(" and ac.IdCuenta=c.IdCuenta  ")
         .AppendLine(" and c.IdCuenta=pc.IdCuenta  ")
         .AppendLine(" and A.IdPlanCuenta=pc.IdPlanCuenta  ")
         .AppendLine(" and PC.IdPlanCuenta=PL.IdPlanCuenta  ")
         .AppendLine(" and c.nivel=4 ")
         .AppendLine(" and substring(str(ac.IdCuenta),3,1)='1'  ")
         .AppendLine("   and a.fechaAsiento <= '" & Me.ObtenerFecha(fHasta, False) & "'")
         If idPlan <> -1 Then
            .AppendLine(" and A.IdPlanCuenta=  " & idPlan.ToString)
         End If

         If idSucursales.Length = 1 Then
            .AppendLine("	and A.IdSucursal = " & idSucursales(0).ToString())
         ElseIf idSucursales.Length > 1 Then
            .AppendLine("	And A.IdSucursal IN (")
            For Each suc As Integer In idSucursales
               .AppendFormat("{0},", suc)
            Next
            .Remove(.Length - 1, 1)
            .AppendLine(")")
         End If
         .AppendLine(" group by pc.IdPlanCuenta,pl.NombrePlanCuenta  ")
         .AppendLine(" ,c.IdCuenta,c.NombreCuenta,ac.IdCuenta ,c.Nivel ")
         .AppendLine(" ) x ")
         .AppendLine(" group by x.IdPlanCuenta,x.NombrePlanCuenta, ")
         .AppendLine(" substring(str(x.IdCuenta),3,3) ")
         .AppendLine(" )y ")
         .AppendLine(" ,ContabilidadCuentas cn2  ")
         .AppendLine(" where cn2.IdCuenta=y.idcuenta ")
         .AppendLine(" and substring(str(y.IdCuenta),3,3) between '101' and '106'")

      End With

      Return GetDataTable(stb)

   End Function

   Public Function BalanceGralActivoNoCorriente(fHasta As Date,
                                                idPlan As Integer,
                                                idSucursales As Integer()) As DataTable
      Dim stb As StringBuilder = New StringBuilder()
      With stb
         .AppendLine("  select '1' as codGrupo, 'ACTIVO' as grupo,'2' AS codTipo,'ACTIVO NO CORRIENTE' as tipo,y.*, ")
         .AppendLine(" cn2.nombreCuenta from  ")
         .AppendLine(" ( ")
         .AppendLine(" select x.IdPlanCuenta,x.NombrePlanCuenta,  ")
         .AppendLine(" sum(x.saldoCuenta) saldoCuenta ")
         .AppendLine(" ,substring(str(x.IdCuenta),3,3)+'00000' idCuenta from  ")
         .AppendLine(" ( ")
         .AppendLine(" select pc.IdPlanCuenta,pl.NombrePlanCuenta  ")
         .AppendLine(" ,c.IdCuenta,c.NombreCuenta ,c.Nivel ")
         .AppendLine(" ,SUM(ac.debe)-SUM(ac.haber) as saldoCuenta  ")
         .AppendLine(" FROM ContabilidadAsientos A,  ")
         .AppendLine(" ContabilidadAsientosCuentas AC,  ")
         .AppendLine(" ContabilidadCuentas C,  ")
         .AppendLine(" ContabilidadPlanesCuentas PC,  ")
         .AppendLine(" ContabilidadPlanes Pl  ")
         .AppendLine(" WHERE A.IdEjercicio = AC.IdEjercicio")
         .AppendLine(" AND A.IdPlanCuenta = AC.IdPlanCuenta")
         .AppendLine(" AND a.idAsiento=ac.idAsiento  ")
         .AppendLine(" and ac.IdCuenta=c.IdCuenta  ")
         .AppendLine(" and c.IdCuenta=pc.IdCuenta  ")
         .AppendLine(" and A.IdPlanCuenta=pc.IdPlanCuenta  ")
         .AppendLine(" and PC.IdPlanCuenta=PL.IdPlanCuenta  ")
         .AppendLine(" and c.nivel=4 ")
         .AppendLine(" and substring(str(ac.IdCuenta),3,1)='1'  ")
         .AppendLine("   and a.fechaAsiento <= '" & Me.ObtenerFecha(fHasta, False) & "'")
         If idPlan <> -1 Then
            .AppendLine(" and A.IdPlanCuenta=  " & idPlan.ToString)
         End If

         If idSucursales.Length = 1 Then
            .AppendLine("	and A.IdSucursal = " & idSucursales(0).ToString())
         ElseIf idSucursales.Length > 1 Then
            .AppendLine("	And A.IdSucursal IN (")
            For Each suc As Integer In idSucursales
               .AppendFormat("{0},", suc)
            Next
            .Remove(.Length - 1, 1)
            .AppendLine(")")
         End If
         .AppendLine(" group by pc.IdPlanCuenta,pl.NombrePlanCuenta  ")
         .AppendLine(" ,c.IdCuenta,c.NombreCuenta,ac.IdCuenta ,c.Nivel ")
         .AppendLine(" ) x ")
         .AppendLine(" group by x.IdPlanCuenta,x.NombrePlanCuenta, ")
         .AppendLine(" substring(str(x.IdCuenta),3,3) ")
         .AppendLine(" )y ")
         .AppendLine(" ,ContabilidadCuentas cn2  ")
         .AppendLine(" where cn2.IdCuenta=y.idcuenta ")
         .AppendLine(" and substring(str(y.IdCuenta),3,3) between '107' and '115'")

      End With

      Return GetDataTable(stb)

   End Function


   Public Function BalanceGralPasivoCorriente(fHasta As Date,
                                              idPlan As Integer,
                                              idSucursales As Integer()) As DataTable
      Dim stb As StringBuilder = New StringBuilder()
      With stb
         .AppendLine("  select '2' as codGrupo, 'PASIVO' as grupo, '3' as codTipo,'PASIVO CORRIENTE' as tipo,y.*, ")
         .AppendLine(" cn2.nombreCuenta from  ")
         .AppendLine(" ( ")
         .AppendLine(" select x.IdPlanCuenta,x.NombrePlanCuenta,  ")
         .AppendLine(" sum(x.saldoCuenta) saldoCuenta ")
         .AppendLine(" ,substring(str(x.IdCuenta),3,3)+'00000' idCuenta from  ")
         .AppendLine(" ( ")
         .AppendLine(" select pc.IdPlanCuenta,pl.NombrePlanCuenta  ")
         .AppendLine(" ,c.IdCuenta,c.NombreCuenta ,c.Nivel ")
         .AppendLine(" ,SUM(ac.debe)-SUM(ac.haber) as saldoCuenta  ")
         .AppendLine(" FROM ContabilidadAsientos A,  ")
         .AppendLine(" ContabilidadAsientosCuentas AC,  ")
         .AppendLine(" ContabilidadCuentas C,  ")
         .AppendLine(" ContabilidadPlanesCuentas PC,  ")
         .AppendLine(" ContabilidadPlanes Pl  ")
         .AppendLine(" WHERE A.IdEjercicio = AC.IdEjercicio")
         .AppendLine(" AND A.IdPlanCuenta = AC.IdPlanCuenta")
         .AppendLine(" AND a.idAsiento=ac.idAsiento  ")
         .AppendLine(" and ac.IdCuenta=c.IdCuenta  ")
         .AppendLine(" and c.IdCuenta=pc.IdCuenta  ")
         .AppendLine(" and A.IdPlanCuenta=pc.IdPlanCuenta  ")
         .AppendLine(" and PC.IdPlanCuenta=PL.IdPlanCuenta  ")
         .AppendLine(" and c.nivel=4 ")
         .AppendLine(" and substring(str(ac.IdCuenta),3,1)='2'  ")
         .AppendLine("   and a.fechaAsiento <= '" & Me.ObtenerFecha(fHasta, False) & "'")
         If idPlan <> -1 Then
            .AppendLine(" and A.IdPlanCuenta=  " & idPlan.ToString)
         End If

         If idSucursales.Length = 1 Then
            .AppendLine("	and A.IdSucursal = " & idSucursales(0).ToString())
         ElseIf idSucursales.Length > 1 Then
            .AppendLine("	And A.IdSucursal IN (")
            For Each suc As Integer In idSucursales
               .AppendFormat("{0},", suc)
            Next
            .Remove(.Length - 1, 1)
            .AppendLine(")")
         End If
         .AppendLine(" group by pc.IdPlanCuenta,pl.NombrePlanCuenta  ")
         .AppendLine(" ,c.IdCuenta,c.NombreCuenta,ac.IdCuenta ,c.Nivel ")
         .AppendLine(" ) x ")
         .AppendLine(" group by x.IdPlanCuenta,x.NombrePlanCuenta, ")
         .AppendLine(" substring(str(x.IdCuenta),3,3) ")
         .AppendLine(" )y ")
         .AppendLine(" ,ContabilidadCuentas cn2  ")
         .AppendLine(" where cn2.IdCuenta=y.idcuenta ")
         .AppendLine(" and substring(str(y.IdCuenta),3,3) between '201' and '208'")
      End With

      Return GetDataTable(stb)

   End Function

   Public Function BalanceGralPasivoNoCorriente(fHasta As Date,
                                                idPlan As Integer,
                                                idSucursales As Integer()) As DataTable
      Dim stb As StringBuilder = New StringBuilder()
      With stb
         .AppendLine("  select  '2' as codGrupo, 'PASIVO' as grupo, '4' as codTipo,'PASIVO NO CORRIENTE' as tipo,y.*, ")
         .AppendLine(" cn2.nombreCuenta from  ")
         .AppendLine(" ( ")
         .AppendLine(" select x.IdPlanCuenta,x.NombrePlanCuenta,  ")
         .AppendLine(" sum(x.saldoCuenta) saldoCuenta ")
         .AppendLine(" ,substring(str(x.IdCuenta),3,3)+'00000' idCuenta from  ")
         .AppendLine(" ( ")
         .AppendLine(" select pc.IdPlanCuenta,pl.NombrePlanCuenta  ")
         .AppendLine(" ,c.IdCuenta,c.NombreCuenta ,c.Nivel ")
         .AppendLine(" ,SUM(ac.debe)-SUM(ac.haber) as saldoCuenta  ")
         .AppendLine(" FROM ContabilidadAsientos A,  ")
         .AppendLine(" ContabilidadAsientosCuentas AC,  ")
         .AppendLine(" ContabilidadCuentas C,  ")
         .AppendLine(" ContabilidadPlanesCuentas PC,  ")
         .AppendLine(" ContabilidadPlanes Pl  ")
         .AppendLine(" WHERE A.IdEjercicio = AC.IdEjercicio")
         .AppendLine(" AND A.IdPlanCuenta = AC.IdPlanCuenta")
         .AppendLine(" AND a.idAsiento=ac.idAsiento  ")
         .AppendLine(" and ac.IdCuenta=c.IdCuenta  ")
         .AppendLine(" and c.IdCuenta=pc.IdCuenta  ")
         .AppendLine(" and A.IdPlanCuenta=pc.IdPlanCuenta  ")
         .AppendLine(" and PC.IdPlanCuenta=PL.IdPlanCuenta  ")
         .AppendLine(" and c.nivel=4 ")
         .AppendLine(" and substring(str(ac.IdCuenta),3,1)='2'  ")
         .AppendLine("   and a.fechaAsiento <= '" & Me.ObtenerFecha(fHasta, False) & "'")
         If idPlan <> -1 Then
            .AppendLine(" and A.IdPlanCuenta=  " & idPlan.ToString)
         End If

         If idSucursales.Length = 1 Then
            .AppendLine("	and A.IdSucursal = " & idSucursales(0).ToString())
         ElseIf idSucursales.Length > 1 Then
            .AppendLine("	And A.IdSucursal IN (")
            For Each suc As Integer In idSucursales
               .AppendFormat("{0},", suc)
            Next
            .Remove(.Length - 1, 1)
            .AppendLine(")")
         End If
         .AppendLine(" group by pc.IdPlanCuenta,pl.NombrePlanCuenta  ")
         .AppendLine(" ,c.IdCuenta,c.NombreCuenta,ac.IdCuenta ,c.Nivel ")
         .AppendLine(" ) x ")
         .AppendLine(" group by x.IdPlanCuenta,x.NombrePlanCuenta, ")
         .AppendLine(" substring(str(x.IdCuenta),3,3) ")
         .AppendLine(" )y ")
         .AppendLine(" ,ContabilidadCuentas cn2  ")
         .AppendLine(" where cn2.IdCuenta=y.idcuenta ")
         .AppendLine(" and substring(str(y.IdCuenta),3,3) between '209' and '216'")
      End With

      Return GetDataTable(stb)

   End Function

   Public Function BalanceGralPatrimonioNeto(fHasta As Date,
                                             idPlan As Integer,
                                             idSucursales As Integer()) As DataTable
      Dim stb As StringBuilder = New StringBuilder()
      With stb
         .AppendLine("  select  '3' as codGrupo, 'PATRIMONIO NETO' as grupo,'5' as codTipo,'PATRIMONIO NETO' as tipo,y.*, ")
         .AppendLine(" cn2.nombreCuenta from  ")
         .AppendLine(" ( ")
         .AppendLine(" select x.IdPlanCuenta,x.NombrePlanCuenta,  ")
         .AppendLine(" sum(x.saldoCuenta) saldoCuenta ")
         .AppendLine(" ,substring(str(x.IdCuenta),3,3)+'00000' idCuenta from  ")
         .AppendLine(" ( ")
         .AppendLine(" select pc.IdPlanCuenta,pl.NombrePlanCuenta  ")
         .AppendLine(" ,c.IdCuenta,c.NombreCuenta ,c.Nivel ")
         .AppendLine(" ,SUM(ac.debe)-SUM(ac.haber) as saldoCuenta  ")
         .AppendLine(" FROM ContabilidadAsientos A,  ")
         .AppendLine(" ContabilidadAsientosCuentas AC,  ")
         .AppendLine(" ContabilidadCuentas C,  ")
         .AppendLine(" ContabilidadPlanesCuentas PC,  ")
         .AppendLine(" ContabilidadPlanes Pl  ")
         .AppendLine(" WHERE A.IdEjercicio = AC.IdEjercicio")
         .AppendLine(" AND A.IdPlanCuenta = AC.IdPlanCuenta")
         .AppendLine(" AND a.idAsiento=ac.idAsiento  ")
         .AppendLine(" and ac.IdCuenta=c.IdCuenta  ")
         .AppendLine(" and c.IdCuenta=pc.IdCuenta  ")
         .AppendLine(" and A.IdPlanCuenta=pc.IdPlanCuenta  ")
         .AppendLine(" and PC.IdPlanCuenta=PL.IdPlanCuenta  ")
         .AppendLine(" and c.nivel=4 ")
         .AppendLine(" and substring(str(ac.IdCuenta),3,1)in ('3','4') ")
         .AppendLine("   and a.fechaAsiento <= '" & Me.ObtenerFecha(fHasta, False) & "'")
         If idPlan <> -1 Then
            .AppendLine(" and A.IdPlanCuenta=  " & idPlan.ToString)
         End If

         If idSucursales.Length = 1 Then
            .AppendLine("	and A.IdSucursal = " & idSucursales(0).ToString())
         ElseIf idSucursales.Length > 1 Then
            .AppendLine("	And A.IdSucursal IN (")
            For Each suc As Integer In idSucursales
               .AppendFormat("{0},", suc)
            Next
            .Remove(.Length - 1, 1)
            .AppendLine(")")
         End If
         .AppendLine(" group by pc.IdPlanCuenta,pl.NombrePlanCuenta  ")
         .AppendLine(" ,c.IdCuenta,c.NombreCuenta,ac.IdCuenta ,c.Nivel ")
         .AppendLine(" ) x ")
         .AppendLine(" group by x.IdPlanCuenta,x.NombrePlanCuenta, ")
         .AppendLine(" substring(str(x.IdCuenta),3,3) ")
         .AppendLine(" )y ")
         .AppendLine(" ,ContabilidadCuentas cn2  ")
         .AppendLine(" where cn2.IdCuenta=y.idcuenta ")

      End With

      Return GetDataTable(stb)

   End Function

   Public Function BlanceNivel4Gral(fHasta As Date,
                                    idplan As Integer,
                                    mesDia As String,
                                    idSucursales As Integer()) As DataTable
      Dim stb As StringBuilder = New StringBuilder()
      With stb
         If idplan = -1 Then ' esto se usa para el consolidado
            .AppendLine("select X.IdCuenta,x.NombreCuenta  ,sum(x.saldoCuenta ) as saldoCuenta  from (")
         End If

         .AppendLine("  select y.*, ")
         .AppendLine(" cn2.nombreCuenta from  ")
         .AppendLine(" ( ")
         .AppendLine(" select x.IdPlanCuenta,x.NombrePlanCuenta,  ")
         .AppendLine(" sum(x.saldoCuenta) saldoCuenta ")
         .AppendLine(" ,substring(str(x.IdCuenta),3,3)+'00000' idCuenta from  ")
         .AppendLine(" ( ")

         .AppendLine("select pc.IdPlanCuenta,pl.NombrePlanCuenta ")
         .AppendLine(" ,c.IdCuenta,c.NombreCuenta ")
         .AppendLine(" ,SUM(ac.debe)-SUM(ac.haber) as saldoCuenta ")
         '.AppendLine(" ,SUM(ac.debe) as debe,SUM(ac.haber) As haber ")
         .AppendLine(" from ")
         .AppendLine(" ContabilidadAsientos A, ")
         .AppendLine(" ContabilidadAsientosCuentas AC, ")
         .AppendLine(" ContabilidadCuentas C, ")
         .AppendLine(" ContabilidadPlanesCuentas PC, ")
         .AppendLine(" ContabilidadPlanes Pl ")
         .AppendLine(" WHERE A.IdEjercicio = AC.IdEjercicio")
         .AppendLine("   AND A.IdPlanCuenta = AC.IdPlanCuenta")
         .AppendLine("   AND a.idAsiento=ac.idAsiento ")
         .AppendLine(" and ac.IdCuenta=c.IdCuenta ")
         .AppendLine(" and c.IdCuenta=pc.IdCuenta ")
         .AppendLine(" and A.IdPlanCuenta=pc.IdPlanCuenta ")
         .AppendLine(" and PC.IdPlanCuenta=PL.IdPlanCuenta ")

         .AppendLine(" and c.nivel=4 ")

         .AppendLine(" and substring(str(ac.IdCuenta),3,1)='4'  ") '-- todas las cuentas  de Resultado

         '  .AppendLine(" and a.fechaAsiento between '01/01/" & fHasta.Year.ToString & "' and '" & Me.ObtenerFecha(fHasta, False) & "'")
         '.AppendLine(" and a.fechaAsiento between '" & mesDia & "/" & fHasta.Year.ToString & "' and '" & Me.ObtenerFecha(fHasta, False) & "'")

         .AppendLine(" and a.fechaAsiento between '" & fHasta.Year.ToString() & mesDia & "' and '" & fHasta.ToString("yyyyMMdd") & "'")

         If idplan <> -1 Then
            .AppendLine(" and A.IdPlanCuenta=  " & idplan.ToString())
         End If

         If idSucursales.Length = 1 Then
            .AppendLine("	and A.IdSucursal = " & idSucursales(0).ToString())
         ElseIf idSucursales.Length > 1 Then
            .AppendLine("	And A.IdSucursal IN (")
            For Each suc As Integer In idSucursales
               .AppendFormat("{0},", suc)
            Next
            .Remove(.Length - 1, 1)
            .AppendLine(")")
         End If


         .AppendLine(" group by pc.IdPlanCuenta,pl.NombrePlanCuenta ")
         .AppendLine(" ,c.IdCuenta,c.NombreCuenta,ac.IdCuenta ")

         If idplan = -1 Then
            .AppendLine(" ) X group by X.IdCuenta,x.NombreCuenta ")
         End If

         .AppendLine(" ) x ")
         .AppendLine(" group by x.IdPlanCuenta,x.NombrePlanCuenta, ")
         .AppendLine(" substring(str(x.IdCuenta),3,3) ")
         .AppendLine(" )y ")
         .AppendLine(" ,ContabilidadCuentas cn2  ")
         .AppendLine(" where cn2.IdCuenta=y.idcuenta ")

         '.AppendLine(" order by c.IdCuenta,c.NombreCuenta")
      End With

      Return GetDataTable(stb)

   End Function


   Public Function BalanceN4AnteriorGral(fHasta As Date,
                                         idplan As Integer,
                                         mesDia As String,
                                         idSucursales As Integer()) As DataTable
      Dim stb As StringBuilder = New StringBuilder()
      With stb
         .AppendLine(" select ISNULL(SUM(x.Saldocuenta),0) as SaldoAnterior from (")
         .AppendLine("select pc.IdPlanCuenta,pl.NombrePlanCuenta ")
         .AppendLine(" ,c.IdCuenta,c.NombreCuenta ")
         .AppendLine(" ,SUM(ac.debe)-SUM(ac.haber) as saldoCuenta ")
         ' .AppendLine(" ,SUM(ac.debe) as debe,SUM(ac.haber) As haber ")
         .AppendLine(" from ContabilidadAsientos A, ")
         .AppendLine(" ContabilidadAsientosCuentas AC, ")
         .AppendLine(" ContabilidadCuentas C, ")
         .AppendLine(" ContabilidadPlanesCuentas PC, ")
         .AppendLine(" ContabilidadPlanes Pl ")
         .AppendLine(" WHERE A.IdEjercicio = AC.IdEjercicio")
         .AppendLine("   AND A.IdPlanCuenta = AC.IdPlanCuenta")
         .AppendLine("   AND a.idAsiento=ac.idAsiento ")
         .AppendLine(" and ac.IdCuenta=c.IdCuenta ")
         .AppendLine(" and c.IdCuenta=pc.IdCuenta ")
         .AppendLine(" and A.IdPlanCuenta=pc.IdPlanCuenta ")
         .AppendLine(" and PC.IdPlanCuenta=PL.IdPlanCuenta ")

         '.AppendLine(" a.idAsiento=ac.idAsiento ")
         '.AppendLine(" and ac.IdCuenta=c.IdCuenta ")
         '.AppendLine(" and c.IdCentroCosto=cc.IdCentroCosto ")
         .AppendLine(" and c.nivel=4 ")
         .AppendLine(" and substring(str(ac.IdCuenta),3,1)='4' ") ' -- todas las cuentas de Resultado

         '  .AppendLine(" and a.fechaAsiento <= '31/12/" & fHasta.AddYears(-1).Year.ToString & "'") '--- and '09/10/2011'
         '.AppendLine(" and a.fechaAsiento <= '" & diaMes & "/" & fHasta.AddYears(-1).Year.ToString & "'") '--- and '09/10/2011'
         .AppendLine(" and a.fechaAsiento <= '" & fHasta.AddYears(-1).Year.ToString() & mesDia & "'") '--- and 'aaaa/mm/dd'

         If idplan <> -1 Then
            .AppendLine(" and a.IdPlanCuenta=  " & idplan.ToString)
         End If

         If idSucursales.Length = 1 Then
            .AppendLine("	and A.IdSucursal = " & idSucursales(0).ToString())
         ElseIf idSucursales.Length > 1 Then
            .AppendLine("	And A.IdSucursal IN (")
            For Each suc As Integer In idSucursales
               .AppendFormat("{0},", suc)
            Next
            .Remove(.Length - 1, 1)
            .AppendLine(")")
         End If

         .AppendLine(" group by pc.IdPlanCuenta,pl.NombrePlanCuenta  ")
         .AppendLine(" ,c.IdCuenta,c.NombreCuenta,ac.IdCuenta ")
         .AppendLine(" ) x ")

      End With

      Return GetDataTable(stb)

   End Function



   Public Function BalanceNuevo(fDesdePeriodo As Date,
                                fHasta As Date,
                                idplan As Integer?,
                                idSucursales As Integer(),
                                incluirCuentasSinMovimientos As Boolean) As DataTable

      'mesDiaPrimer As String,
      'mesDiaUtimo As String,

      Dim sucs As String = String.Empty
      If idSucursales.Length > 0 Then
         Dim suc As StringBuilder = New StringBuilder()
         For Each s As Integer In idSucursales
            suc.AppendFormat("{0},", s)
         Next
         sucs = suc.ToString().Trim(","c)
      End If

      Dim stb As StringBuilder = New StringBuilder("")
      With stb
         .AppendLine("SELECT B.IdCuenta ,B.NombreCuenta ,B.IdCuentaPadre")
         .AppendLine("      ,CASE WHEN B.debeSumas  = 0 THEN NULL ELSE B.debeSumas  END debeSumas")
         .AppendLine("      ,CASE WHEN B.haberSumas = 0 THEN NULL ELSE B.haberSumas END haberSumas")
         .AppendLine("      ,CASE WHEN B.debeSaldos = 0 THEN NULL ELSE B.debeSaldos END debeSaldos")
         .AppendLine("      ,CASE WHEN B.haberSaldos = 0 THEN NULL ELSE B.haberSaldos END haberSaldos")
         .AppendLine("      ,CASE WHEN B.saldos = 0 THEN NULL ELSE B.saldos END saldos")
         .AppendLine("  FROM (")
         .AppendLine("SELECT B.IdCuenta ,B.NombreCuenta ,B.IdCuentaPadre")
         .AppendLine("      ,SUM(B.debeSumas) AS debeSumas")
         .AppendLine("      ,SUM(B.haberSumas) AS haberSumas")
         .AppendLine("      ,SUM(B.debeSaldos) AS debeSaldos")
         .AppendLine("      ,SUM(B.haberSaldos) AS haberSaldos")
         .AppendLine("      ,SUM(B.saldos) AS saldos")
         .AppendLine("  FROM (")

         '.AppendLine("SELECT B.IdPlanCuenta ,B.NombrePlanCuenta")
         .AppendLine("SELECT B.IdCuenta ,B.NombreCuenta")
         .AppendLine("      ,B.IdCuentaPadre")
         .AppendLine("      ,B.debeSumas")
         .AppendLine("      ,B.haberSumas")
         .AppendLine("      ,CASE WHEN B.debeSumas > B.haberSumas THEN B.debeSumas - B.haberSumas ELSE 0 END debeSaldos")
         .AppendLine("      ,CASE WHEN B.debeSumas < B.haberSumas THEN B.haberSumas - B.debeSumas ELSE 0 END haberSaldos")
         .AppendLine("      ,B.debeSumas - B.haberSumas saldos")
         .AppendLine("  FROM (SELECT c.IdCuenta, c.NombreCuenta, C.IdCuentaPadre, SUM(ac.debe) AS debeSumas, SUM(ac.haber) AS haberSumas")
         .AppendLine("          FROM ContabilidadAsientosCuentas AS AC")
         .AppendLine("         INNER JOIN ContabilidadAsientos AS A ON A.IdEjercicio = AC.IdEjercicio AND A.IdPlanCuenta = AC.IdPlanCuenta AND A.idAsiento = AC.idAsiento")
         .AppendLine("         INNER JOIN ContabilidadCuentas AS C ON C.IdCuenta = AC.IdCuenta")
         '.AppendLine("         INNER JOIN ContabilidadPlanesCuentas AS PC ON PC.IdPlanCuenta = AC.IdPlanCuenta AND PC.IdCuenta = AC.IdCuenta")
         '.AppendLine("         INNER JOIN ContabilidadPlanes AS PL ON PL.IdPlanCuenta=PC.IdPlanCuenta")
         .AppendLine("         WHERE 1 = 1")
         .AppendLine("           AND C.Esimputable = 1")
         .AppendFormat("           AND a.fechaAsiento BETWEEN '{0}' AND '{1}'", ObtenerFecha(fDesdePeriodo, False), ObtenerFecha(fHasta, False)).AppendLine()
         If idplan.HasValue Then
            .AppendFormat("           AND AC.IdPlanCuenta = {0}", idplan.Value).AppendLine()
         End If
         If Not String.IsNullOrWhiteSpace(sucs) Then
            .AppendFormat("           AND A.IdSucursal IN ({0})", sucs).AppendLine()
         End If
         .AppendLine("         GROUP BY c.IdCuenta, c.NombreCuenta, C.IdCuentaPadre, ac.IdCuenta) AS B")

         If incluirCuentasSinMovimientos Then
            .AppendLine(" UNION ")
            .AppendLine("SELECT C.IdCuenta ,C.NombreCuenta ,C.IdCuentaPadre")
            .AppendLine("      ,0 AS debeSumas")
            .AppendLine("      ,0 AS haberSumas")
            .AppendLine("      ,0 AS debeSaldos")
            .AppendLine("      ,0 AS haberSaldos")
            .AppendLine("      ,0 AS saldos")
            .AppendLine("  FROM ContabilidadCuentas AS C")
            .AppendLine(" WHERE C.EsImputable = 1")
         End If
         .AppendLine(" ) AS B")
         .AppendLine(" GROUP BY B.IdCuenta ,B.NombreCuenta ,B.IdCuentaPadre")
         .AppendLine(" ) AS B")

         .AppendLine(" ORDER BY B.IdCuenta")

      End With

      Return GetDataTable(stb)

   End Function


   Public Function BalanceSumaSaldoPorPeriodo(idSucursales As IEnumerable(Of Integer), fechaDesde As Date, fechaHasta As Date,
                                              idplan As Integer?, incluirCuentasSinMovimientos As Boolean,
                                              idEjercicio As Integer, periodos As IEnumerable(Of String)) As DataTable
      Dim stb = New StringBuilder()
      With stb
         .AppendFormatLine("SELECT T.IdEjercicio")
         .AppendFormatLine("     , T.IdCuenta")
         .AppendFormatLine("     , T.NombreCuenta")
         .AppendFormatLine("     , {0}", String.Join(", ", periodos.ToList().ConvertAll(Function(p) String.Format("SUM(T.[{0}]) [{0}]", p))))
         .AppendFormatLine("     , SUM(T.SaldoTotal) AS SaldoTotal")
         .AppendFormatLine("  FROM (")
         .AppendFormatLine("SELECT CP.IdEjercicio, CP.IdPeriodo, C.IdCuenta, C.NombreCuenta, SUM(ac.debe - ac.haber) Saldo, SUM(ac.debe - ac.haber) SaldoTotal")
         .AppendFormatLine("  FROM ContabilidadAsientosCuentas AS AC")
         .AppendFormatLine(" INNER JOIN ContabilidadAsientos AS A ON A.IdEjercicio = AC.IdEjercicio AND A.IdPlanCuenta = AC.IdPlanCuenta AND A.idAsiento = AC.idAsiento")
         .AppendFormatLine(" INNER JOIN ContabilidadCuentas AS C ON C.IdCuenta = AC.IdCuenta")
         .AppendFormatLine(" INNER JOIN ContabilidadPeriodosEjercicios CP")
         .AppendFormatLine("         ON CP.IdEjercicio = A.IdEjercicio")
         .AppendFormatLine("        AND CP.IdPeriodo = RIGHT('0' + CONVERT(varchar(MAX), MONTH(A.FechaAsiento)), 2) + '/' + RIGHT('0000' + CONVERT(varchar(MAX), YEAR(A.FechaAsiento)), 4)")
         .AppendFormatLine(" WHERE C.Esimputable = 1")
         .AppendFormatLine("   AND A.fechaAsiento BETWEEN '{0}' AND '{1}'", ObtenerFecha(fechaDesde, False), ObtenerFecha(fechaHasta.UltimoSegundoDelDia(), True))
         .AppendFormatLine("   AND A.IdSucursal IN ({0})", String.Join(",", idSucursales))
         If idplan.HasValue Then
            .AppendFormatLine("   AND AC.IdPlanCuenta = {0}", idplan.Value)
         End If
         .AppendFormatLine(" GROUP BY CP.IdEjercicio, CP.IdPeriodo, c.IdCuenta, c.NombreCuenta")

         If incluirCuentasSinMovimientos Then
            .AppendFormatLine(" UNION ALL")

            .AppendFormatLine("SELECT PE.IdEjercicio, PE.IdPeriodo, CC1.IdCuenta ,CC1.NombreCuenta, NULL Saldo, NULL SaldoTotal")
            .AppendFormatLine("  FROM ContabilidadCuentas CC1")
            .AppendFormatLine(" CROSS JOIN (SELECT * FROM ContabilidadPeriodosEjercicios WHERE IdEjercicio = {0}) PE", idEjercicio)
            .AppendFormatLine(" WHERE CC1.EsImputable = 'True'")
         End If

         .AppendFormatLine(") A1")
         .AppendFormatLine("PIVOT (SUM(Saldo) FOR IdPeriodo IN ({0})) T", String.Join(",", periodos.ToList().ConvertAll(Function(p) String.Format("[{0}]", p))))
         .AppendFormatLine("GROUP BY IdEjercicio, IdCuenta, NombreCuenta")

      End With
      Return GetDataTable(stb)
   End Function
End Class