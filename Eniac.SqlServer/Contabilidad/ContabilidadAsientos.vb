Public Class ContabilidadAsientos
   Inherits Comunes

   Public Sub New(da As Datos.DataAccess)
      MyBase.New(da)
   End Sub

   Public Function Asiento_GetDetalle(idEjercicio As Integer, idPlanCuenta As Integer, idAsiento As Integer) As DataTable
      Dim stb = New StringBuilder()
      With stb
         .AppendFormatLine("SELECT AC.IdEjercicio")
         .AppendFormatLine("     , AC.IdPlanCuenta")
         .AppendFormatLine("     , AC.IdAsiento ")
         .AppendFormatLine("     , AC.IdCuenta")
         .AppendFormatLine("     , STR(AC.IdCuenta) + ' - ' + C.NombreCuenta as Cuenta")
         .AppendFormatLine("     , AC.IdRenglon")
         .AppendFormatLine("     , CASE WHEN AC.Debe  = 0 THEN NULL ELSE AC.Debe  END Debe")
         .AppendFormatLine("     , CASE WHEN AC.Haber = 0 THEN NULL ELSE AC.Haber END Haber")
         .AppendFormatLine("     , AC.IdTipoReferencia")
         .AppendFormatLine("     , AC.Referencia")
         .AppendFormatLine("     , AC.IdCentroCosto")
         .AppendFormatLine("     , CCC.NombreCentroCosto")
         .AppendFormatLine("  FROM ContabilidadAsientosCuentas AC")
         .AppendFormatLine(" INNER JOIN ContabilidadCuentas C ON C.IdCuenta = AC.IdCuenta")
         .AppendFormatLine("  LEFT JOIN ContabilidadCentrosCostos CCC ON CCC.IdCentroCosto = AC.IdCentroCosto")
         .AppendFormatLine(" WHERE IdEjercicio = {0}", idEjercicio)
         .AppendFormatLine("   AND IdPlanCuenta = {0}", idPlanCuenta)
         .AppendFormatLine("   AND IdAsiento = {0}", idAsiento)
      End With

      Return GetDataTable(stb)
   End Function

   Public Function Asiento_GetIdMaximo(idEjercicio As Integer, idPlanCuenta As Integer) As Integer
      Return GetCodigoMaximo("maximo", "vw_ContabilidadAsientosIDMaximo",
                             String.Format("IdEjercicio = {0} AND IdPlanCuenta = {1}", idEjercicio, idPlanCuenta)).ToInteger()
   End Function

   Private Sub SelectTexto(stb As StringBuilder)
      With stb
         .AppendFormatLine("SELECT A.IdEjercicio")
         .AppendFormatLine("     , A.IdPlanCuenta")
         .AppendFormatLine("     , PL.NombrePlanCuenta")
         .AppendFormatLine("     , A.IdAsiento")
         .AppendFormatLine("     , A.NombreAsiento")
         .AppendFormatLine("     , A.FechaAsiento")
         .AppendFormatLine("     , A.IdTipoDoc")
         .AppendFormatLine("     , A.IdSucursal")
         .AppendFormatLine("     , S.Nombre AS NombreSucursal")
         .AppendFormatLine("     , A.SubsiAsiento ")
         .AppendFormatLine("     , A.EsManual")
         .AppendFormatLine("     , A.FechaExportacion")
         .AppendFormatLine("     , A.IdEstadoAsiento")
         .AppendFormatLine("     , A.TipoAsiento")
         .AppendFormatLine("     , EA.NombreEstadoAsiento")
         .AppendFormatLine("  FROM ContabilidadAsientos A ")
         .AppendFormatLine(" INNER JOIN ContabilidadPlanes PL on PL.IdPlanCuenta = A.IdPlanCuenta")
         .AppendFormatLine(" INNER JOIN Sucursales S on S.IdSucursal = A.IdSucursal")
         .AppendFormatLine(" INNER JOIN ContabilidadEstadosAsientos EA ON EA.IdEstadoAsiento = A.IdEstadoAsiento")
      End With
   End Sub

   Public Overloads Function Buscar(columna As String, valor As String, idEstadoAsiento As Integer) As DataTable
      Return Buscar(columna, valor, Sub(stb) SelectTexto(stb), "A.",
                    New Dictionary(Of String, String) From {{"NombrePlanCuenta", "PL.NombrePlanCuenta"},
                                                            {"NombreSucursal", "S.Nombre"},
                                                            {"NombreEstadoAsiento", "EA.NombreEstadoAsiento"}},
                    mapearColumnaCustom:=Nothing,
                    agregarCondicionAdicional:=
                    Sub(stb)
                       If idEstadoAsiento <> 0 Then
                          stb.AppendFormatLine("   AND A.IdEstadoAsiento = {0}", idEstadoAsiento)
                       End If
                    End Sub)
   End Function

   Public Function Asientos_GA() As DataTable
      Return Asientos_GA(meses:=Nothing, idEstadoAsiento:=0)
   End Function

   Private Function Asientos_G(meses As Integer?, idEjercicio As Integer?, idPlanCuenta As Integer?, idAsiento As Integer?, nombreAsiento As String, manual As Boolean?, vinculado As Boolean?,
                               idEstadoAsiento As Integer) As DataTable
      Dim stb = New StringBuilder()
      With stb
         SelectTexto(stb)
         .AppendFormatLine(" WHERE 1 = 1")
         If meses.HasValue Then
            .AppendFormatLine("   AND FechaAsiento >= '{0}'", ObtenerFecha(Today.AddMonths(meses.Value * -1), False))
         End If

         If idEjercicio.HasValue Then
            .AppendFormatLine("   AND A.IdEjercicio = {0}", idEjercicio.Value)
         End If
         If idPlanCuenta.HasValue Then
            .AppendFormatLine("   AND A.IdPlanCuenta = {0}", idPlanCuenta.Value)
         End If
         If idAsiento.HasValue Then
            .AppendFormatLine("   AND A.IdAsiento = {0}", idAsiento.Value)
         End If

         If Not String.IsNullOrWhiteSpace(nombreAsiento) Then
            .AppendFormatLine("   AND A.NombreAsiento LIKE '%{0}%'", nombreAsiento)
         End If

         If manual.HasValue Then
            .AppendFormatLine("   AND A.EsManual = {0}", GetStringFromBoolean(manual.Value))
         End If

         If idEstadoAsiento <> 0 Then
            .AppendFormatLine("   AND A.IdEstadoAsiento = {0}", idEstadoAsiento)
         End If

         If vinculado.HasValue Then
            .AppendFormatLine("   AND {0} EXISTS(SELECT * FROM ContabilidadAsientosTmp AT", If(vinculado.Value, "", "NOT"))
            .AppendFormatLine("                   WHERE AT.IdEjercicioDefinitivo = A.IdEjercicio")
            .AppendFormatLine("                     AND AT.IdPlanCuentaDefinitivo = A.IdPlanCuenta")
            .AppendFormatLine("                     AND AT.IdAsientoDefinitivo = A.IdAsiento)")
         End If

         .Append("  ORDER BY A.NombreAsiento")
      End With
      Return GetDataTable(stb)
   End Function


   Public Function Asientos_GA(meses As Integer?, idEstadoAsiento As Integer) As DataTable
      Return Asientos_G(meses:=meses, idEjercicio:=Nothing, idPlanCuenta:=Nothing, idAsiento:=Nothing, nombreAsiento:=String.Empty, manual:=Nothing, vinculado:=Nothing, idEstadoAsiento)
   End Function

   Public Function Asientos_G1(idEjercicio As Integer, idPlanCuenta As Integer, idAsiento As Integer) As DataTable
      Return Asientos_G(meses:=Nothing, idEjercicio:=idEjercicio, idPlanCuenta:=idPlanCuenta, idAsiento:=idAsiento, nombreAsiento:=String.Empty, manual:=Nothing, vinculado:=Nothing, idEstadoAsiento:=0)
   End Function

   Public Function Asientos_GA(idEjercicio As Integer?, idPlanCuenta As Integer?, idAsiento As Integer?) As DataTable
      Return Asientos_G(meses:=Nothing, idEjercicio:=idEjercicio, idPlanCuenta:=idPlanCuenta, idAsiento:=idAsiento, nombreAsiento:=String.Empty, manual:=Nothing, vinculado:=Nothing, idEstadoAsiento:=0)
   End Function

   Public Function GetPorNombre(nombreAsiento As String) As DataTable
      Return Asientos_G(meses:=Nothing, idEjercicio:=Nothing, idPlanCuenta:=Nothing, idAsiento:=Nothing, nombreAsiento:=nombreAsiento, manual:=Nothing, vinculado:=Nothing, idEstadoAsiento:=0)
   End Function

   Public Function Asientos_GA(idPlanCuenta As Integer?, idAsiento As Integer?, nombreAsiento As String, manual As Boolean?, vinculado As Boolean?) As DataTable
      Return Asientos_G(meses:=Nothing, idEjercicio:=Nothing, idPlanCuenta:=idPlanCuenta, idAsiento:=idAsiento, nombreAsiento:=nombreAsiento, manual:=manual, vinculado:=vinculado, idEstadoAsiento:=0)
   End Function

   Public Sub Asiento_I(idEjercicio As Integer,
                        idPlanCuenta As Integer,
                        idAsiento As Integer,
                        fechaAsiento As Date,
                        nombreAsiento As String,
                        idTipoDoc As Integer,
                        idSucursal As Integer,
                        subsiAsiento As String,
                        esManual As Boolean,
                        fechaExportacion As Date,
                        idEstadoAsiento As Integer,
                        tipoAsiento As String)
      Dim stb = New StringBuilder()
      With stb
         .AppendLine("INSERT INTO ContabilidadAsientos")
         .AppendLine("   (IdEjercicio")
         .AppendLine("   ,IdPlanCuenta")
         .AppendLine("   ,IdAsiento")
         .AppendLine("   ,NombreAsiento")
         .AppendLine("   ,FechaAsiento")
         .AppendLine("   ,IdTipoDoc")
         .AppendLine("   ,idSucursal")
         .AppendLine("   ,SubsiAsiento")
         .AppendLine("   ,EsManual")
         .AppendLine("   ,FechaExportacion")
         .AppendLine("   ,IdEstadoAsiento")
         .AppendLine("   ,TipoAsiento")

         .AppendFormatLine(" ) VALUES ( ")
         .AppendFormatLine("     {0} ", idEjercicio)
         .AppendFormatLine("   , {0} ", idPlanCuenta)
         .AppendFormatLine("   , {0} ", idAsiento)
         .AppendFormatLine("   ,'{0}'", nombreAsiento.ToString())
         .AppendFormatLine("   ,'{0}'", ObtenerFecha(fechaAsiento, False))
         .AppendFormatLine("   , {0} ", idTipoDoc)
         .AppendFormatLine("   , {0} ", idSucursal)
         .AppendFormatLine("   ,'{0}'", subsiAsiento)
         .AppendFormatLine("   , {0} ", GetStringFromBoolean(esManual))
         If fechaExportacion <> Nothing Then
            .AppendFormatLine("   ,'{0}'", ObtenerFecha(fechaExportacion, True))
         Else
            .AppendFormatLine("   ,NULL")
         End If
         .AppendFormatLine("   , {0} ", idEstadoAsiento)
         .AppendFormatLine("   , '{0}' ", tipoAsiento)

         .AppendFormatLine(")")
      End With
      Execute(stb)
   End Sub

   Public Sub Asiento_I_Detalle(idEjercicio As Integer, idPlanCuenta As Integer, idAsiento As Integer, dtDetalle As DataTable)
      Dim renglon As Integer = 0
      For Each fila As DataRow In dtDetalle.Rows
         Dim stb = New StringBuilder()
         With stb
            .AppendLine("INSERT INTO ContabilidadAsientosCuentas")
            .AppendLine("    (IdEjercicio")
            .AppendLine("    ,IdPlanCuenta")
            .AppendLine("    ,IdAsiento")
            .AppendLine("    ,IdCuenta")
            .AppendLine("    ,IdRenglon")
            .AppendLine("    ,Debe")
            .AppendLine("    ,Haber")
            .AppendLine("    ,IdTipoReferencia")
            .AppendLine("    ,Referencia")
            .AppendLine("    ,IdCentroCosto")

            .AppendLine(" ) VALUES ( ")
            .AppendFormatLine("     {0}", idEjercicio)
            .AppendFormatLine("    ,{0}", idPlanCuenta)
            .AppendFormatLine("    ,{0}", idAsiento)
            .AppendFormatLine("    ,{0}", fila("IdCuenta"))
            .AppendFormatLine("    ,{0}", renglon)

            .AppendFormatLine("    ,{0}", If(IsDBNull(fila("Debe")), 0, fila("Debe")))
            .AppendFormatLine("    ,{0}", If(IsDBNull(fila("Haber")), 0, fila("Haber")))


            If Not String.IsNullOrWhiteSpace(fila("IdTipoReferencia").ToString()) Then
               .AppendFormatLine("    ,'{0}'", fila("IdTipoReferencia"))
            Else
               .AppendFormatLine("    ,NULL")
            End If
            If Not String.IsNullOrWhiteSpace(fila("Referencia").ToString()) Then
               .AppendFormatLine("    ,'{0}'", fila("Referencia"))
            Else
               .AppendFormatLine("    ,NULL")
            End If
            If IsNumeric(fila("IdCentroCosto")) AndAlso Integer.Parse(fila("IdCentroCosto").ToString()) > 0 Then
               .AppendFormatLine("    ,{0}", fila("IdCentroCosto"))
            Else
               .AppendLine(" ,NULL")
            End If
            .AppendLine(")")

         End With

         Execute(stb)

         renglon += 1
      Next

   End Sub

   Public Sub Asiento_U(idEjercicio As Integer,
                        idPlanCuenta As Integer,
                        idAsiento As Integer,
                        fechaAsiento As Date,
                        nombreAsiento As String,
                        idTipoDoc As Integer,
                        idSucursal As Integer,
                        subsiAsiento As String,
                        esManual As Boolean,
                        fechaExportacion As Date,
                        idEstadoAsiento As Integer,
                        tipoAsiento As String)
      Dim stb = New StringBuilder()
      With stb
         .AppendFormatLine("UPDATE ContabilidadAsientos SET ")
         .AppendFormatLine("    NombreAsiento = '{0}'", nombreAsiento)
         .AppendFormatLine("   ,FechaAsiento = '{0}'", Me.ObtenerFecha(fechaAsiento, False))
         .AppendFormatLine("   ,IdSucursal = {0}", idSucursal)
         .AppendFormatLine("   ,SubsiAsiento = '{0}'", subsiAsiento)
         .AppendFormatLine("   ,EsManual = {0}", GetStringFromBoolean(esManual))
         If fechaExportacion = New Date Then
            .AppendLine("   ,FechaExportacion = NULL")
         Else
            .AppendFormatLine("   ,FechaExportacion = '{0}¡", Me.ObtenerFecha(fechaExportacion, False))
         End If
         .AppendFormatLine("   ,IdEstadoAsiento = {0}", idEstadoAsiento)
         .AppendFormatLine("   ,TipoAsiento = '{0}'", tipoAsiento)
         .AppendFormatLine(" WHERE IdEjercicio = {0}", idEjercicio)
         .AppendFormatLine("   AND IdPlanCuenta = {0}", idPlanCuenta)
         .AppendFormatLine("   AND idAsiento = {0}", idAsiento)
      End With
      Execute(stb)
   End Sub

   Public Sub Asiento_UFechaExportacion(idEjercicio As Integer,
                                        idPlanCuenta As Integer,
                                        idAsiento As Integer, fechaExportacion As Date)
      Dim stb = New StringBuilder()
      With stb
         .AppendFormatLine("UPDATE ContabilidadAsientos")
         .AppendFormatLine("   SET FechaExportacion = '{0}'", ObtenerFecha(fechaExportacion, True))
         .AppendFormatLine(" WHERE IdEjercicio = {0}", idEjercicio)
         .AppendFormatLine("   AND IdPlanCuenta = {0}", idPlanCuenta)
         .AppendFormatLine("   AND idAsiento = {0}", idAsiento)
         .AppendFormatLine("   AND FechaExportacion is NULL ")
      End With
      Execute(stb)
   End Sub

   Public Sub Asiento_U_Detalle(idEjercicio As Integer, idPlanCuenta As Integer, idAsiento As Integer, dtDetalle As DataTable)
      Dim stb = New StringBuilder()
      'Dim renglon As Integer = 0

      ' primero borro todo, luego inserto.
      Asiento_D_Detalle(idEjercicio, idPlanCuenta, idAsiento)
      Asiento_I_Detalle(idEjercicio, idPlanCuenta, idAsiento, dtDetalle)
   End Sub

   Public Sub Asiento_D_Detalle(idEjercicio As Integer, idPlanCuenta As Integer, idAsiento As Integer)
      Dim stb = New StringBuilder()
      With stb
         .AppendFormatLine("DELETE FROM ContabilidadAsientosCuentas")
         .AppendFormatLine(" WHERE IdEjercicio = {0}", idEjercicio)
         .AppendFormatLine("   AND IdPlanCuenta = {0}", idPlanCuenta)
         .AppendFormatLine("   AND idAsiento = {0}", idAsiento)
      End With
      Execute(stb)
   End Sub

   Public Sub Asiento_D(idEjercicio As Integer, idPlanCuenta As Integer, idAsiento As Integer)
      Dim stb = New StringBuilder()
      With stb
         .AppendFormatLine("DELETE FROM ContabilidadAsientos")
         .AppendFormatLine(" WHERE IdEjercicio = {0}", idEjercicio)
         .AppendFormatLine("   AND IdPlanCuenta = {0}", idPlanCuenta)
         .AppendFormatLine("   AND idAsiento = {0}", idAsiento)
      End With
      Execute(stb)
   End Sub

   Public Function GetModelos(idPlanCuenta As Integer, modelo As String, busquedaParcial As Boolean) As DataTable
      'Optional BusquedaParcial As Boolean = True

      Dim stbQuery = New StringBuilder()
      Dim dt As New DataTable()
      With stbQuery
         If modelo <> String.Empty Then
            .AppendLine("SELECT M.nombreAsiento,M.idAsiento,C.IdCuenta, C.NombreCuenta")
            .AppendLine(" FROM ContabilidadCuentas C, ContabilidadAsientosModelo M")
            .AppendLine(" WHERE C.IdCuenta = M.idCuenta")
            .AppendLine("   AND M.idPlanCuenta = " & idPlanCuenta.ToString)
            .AppendLine("   AND M.nombreAsiento = '" & modelo & "'")
            dt = GetDataTable(stbQuery.ToString())
         End If
      End With

      If (dt Is Nothing OrElse dt.Rows.Count = 0) And busquedaParcial Then
         stbQuery.Length = 0

         With stbQuery
            .AppendLine("SELECT  M.nombreAsiento,M.idAsiento,C.IdCuenta, C.NombreCuenta ")
            .AppendLine(" FROM ContabilidadCuentas C, ContabilidadAsientosModelo M")
            .AppendLine(" WHERE C.IdCuenta = M.idCuenta")
            .AppendLine("   AND M.idPlanCuenta = " & idPlanCuenta.ToString)
            .AppendLine("   AND M.nombreAsiento  LIKE '%" & modelo & "%' ")
            .AppendLine(" ORDER BY C.NombreCuenta ")
         End With
         dt = GetDataTable(stbQuery.ToString())
      End If

      Return dt
   End Function

   Public Function GetAsientosAExportar(idPlanCuenta As Integer, fechaDesde As Date, fechaHasta As Date,
                                        exportados As String, fechaExport As Date, subsistemas As IList) As DataTable

      Dim stbQuery = New StringBuilder()

      Dim stbProcesos = New StringBuilder()
      For Each proceso As KeyValuePair(Of Object, String) In subsistemas
         stbProcesos.AppendFormat("'{0}',", proceso.Key.ToString())
      Next
      'For Each proceso As Entidades.ContabilidadProceso.Procesos In subsistemas
      '   stbProcesos.AppendFormat("'{0}',", proceso.ToString())
      'Next

      With stbQuery
         .AppendLine("SELECT CA.*, AFIP.IdAFIPTipoComprobante FROM (")
         .AppendLine("SELECT CA.IdPlanCuenta ")
         .AppendLine("		,CA.IdAsiento ")
         .AppendLine("		,CA.IdEjercicio ")
         .AppendLine("		,CA.NombreAsiento ")
         .AppendLine("		,CA.FechaAsiento ")
         .AppendLine("		,CAC.IdCuenta ")
         .AppendLine("     ,CC.NombreCuenta")
         .AppendLine("		,CAC.IdRenglon ")
         .AppendLine("		,CAC.Debe ")
         .AppendLine("		,CAC.Haber ")
         .AppendLine("     ,CA.EsManual")
         .AppendLine("     ,CAC.IdTipoReferencia")
         .AppendLine("     ,CAC.Referencia")
         .AppendLine("     ,CASE WHEN CAC.IdTipoReferencia = 'C' THEN CL.CodigoCliente WHEN CAC.IdTipoReferencia = 'P' THEN PR.CodigoProveedor ELSE NULL END AS CodigoReferencia")
         .AppendLine("     ,CASE WHEN CAC.IdTipoReferencia = 'C' THEN CL.NombreCliente WHEN CAC.IdTipoReferencia = 'P' THEN PR.NombreProveedor ELSE NULL END AS NombreReferencia")
         .AppendLine("     ,CA.FechaExportacion")
         .AppendLine("     ,CA.SubsiAsiento")


         .AppendFormatLine("      ,CASE WHEN Ventas.IdSucursal IS NOT NULL THEN Ventas.IdSucursal ELSE").AppendLine()
         .AppendFormatLine("       CASE WHEN CuentasCorrientes.IdSucursal IS NOT NULL THEN CuentasCorrientes.IdSucursal ELSE").AppendLine()
         .AppendFormatLine("       CASE WHEN Compras.IdSucursal IS NOT NULL THEN Compras.IdSucursal ELSE").AppendLine()
         .AppendFormatLine("       CASE WHEN CuentasCorrientesProv.IdSucursal IS NOT NULL THEN CuentasCorrientesProv.IdSucursal ELSE").AppendLine()
         .AppendFormatLine("       NULL END END END END AS IdSucursal").AppendLine()

         .AppendFormatLine("      ,CASE WHEN Ventas.IdSucursal IS NOT NULL THEN Ventas.IdTipoComprobante ELSE").AppendLine()
         .AppendFormatLine("       CASE WHEN CuentasCorrientes.IdSucursal IS NOT NULL THEN CuentasCorrientes.IdTipoComprobante ELSE").AppendLine()
         .AppendFormatLine("       CASE WHEN Compras.IdSucursal IS NOT NULL THEN Compras.IdTipoComprobante ELSE").AppendLine()
         .AppendFormatLine("       CASE WHEN CuentasCorrientesProv.IdSucursal IS NOT NULL THEN CuentasCorrientesProv.IdTipoComprobante ELSE").AppendLine()
         .AppendFormatLine("       NULL END END END END AS IdTipoComprobante").AppendLine()

         .AppendFormatLine("      ,CASE WHEN Ventas.IdSucursal IS NOT NULL THEN Ventas.Letra ELSE").AppendLine()
         .AppendFormatLine("       CASE WHEN CuentasCorrientes.IdSucursal IS NOT NULL THEN CuentasCorrientes.Letra ELSE").AppendLine()
         .AppendFormatLine("       CASE WHEN Compras.IdSucursal IS NOT NULL THEN Compras.Letra ELSE").AppendLine()
         .AppendFormatLine("       CASE WHEN CuentasCorrientesProv.IdSucursal IS NOT NULL THEN CuentasCorrientesProv.Letra ELSE").AppendLine()
         .AppendFormatLine("       NULL END END END END AS Letra").AppendLine()

         .AppendFormatLine("      ,CASE WHEN Ventas.IdSucursal IS NOT NULL THEN Ventas.CentroEmisor ELSE").AppendLine()
         .AppendFormatLine("       CASE WHEN CuentasCorrientes.IdSucursal IS NOT NULL THEN CuentasCorrientes.CentroEmisor ELSE").AppendLine()
         .AppendFormatLine("       CASE WHEN Compras.IdSucursal IS NOT NULL THEN Compras.CentroEmisor ELSE").AppendLine()
         .AppendFormatLine("       CASE WHEN CuentasCorrientesProv.IdSucursal IS NOT NULL THEN CuentasCorrientesProv.CentroEmisor ELSE").AppendLine()
         .AppendFormatLine("       NULL END END END END AS CentroEmisor").AppendLine()

         .AppendFormatLine("      ,CASE WHEN Ventas.IdSucursal IS NOT NULL THEN Ventas.NumeroComprobante ELSE").AppendLine()
         .AppendFormatLine("       CASE WHEN CuentasCorrientes.IdSucursal IS NOT NULL THEN CuentasCorrientes.NumeroComprobante ELSE").AppendLine()
         .AppendFormatLine("       CASE WHEN Compras.IdSucursal IS NOT NULL THEN Compras.NumeroComprobante ELSE").AppendLine()
         .AppendFormatLine("       CASE WHEN CuentasCorrientesProv.IdSucursal IS NOT NULL THEN CuentasCorrientesProv.NumeroComprobante ELSE").AppendLine()
         .AppendFormatLine("       NULL END END END END AS NumeroComprobante").AppendLine()

         .AppendFormatLine("      ,CASE WHEN Ventas.IdSucursal IS NOT NULL THEN CuentasCorrientesV.FechaVencimiento ELSE").AppendLine()
         .AppendFormatLine("       CASE WHEN CuentasCorrientes.IdSucursal IS NOT NULL THEN CuentasCorrientes.FechaVencimiento ELSE").AppendLine()
         .AppendFormatLine("       CASE WHEN Compras.IdSucursal IS NOT NULL THEN CuentasCorrientesC.FechaVencimiento ELSE").AppendLine()
         .AppendFormatLine("       CASE WHEN CuentasCorrientesProv.IdSucursal IS NOT NULL THEN CuentasCorrientesProv.FechaVencimiento ELSE").AppendLine()
         .AppendFormatLine("       NULL END END END END AS FechaVencimiento").AppendLine()

         .AppendFormatLine("      ,CASE WHEN Ventas.IdSucursal IS NOT NULL THEN Ventas.Fecha ELSE").AppendLine()
         .AppendFormatLine("       CASE WHEN CuentasCorrientes.IdSucursal IS NOT NULL THEN CuentasCorrientes.Fecha ELSE").AppendLine()
         .AppendFormatLine("       CASE WHEN Compras.IdSucursal IS NOT NULL THEN Compras.Fecha ELSE").AppendLine()
         .AppendFormatLine("       CASE WHEN CuentasCorrientesProv.IdSucursal IS NOT NULL THEN CuentasCorrientesProv.Fecha ELSE").AppendLine()
         .AppendFormatLine("       NULL END END END END AS FechaComprobante").AppendLine()


         .AppendLine(" FROM ContabilidadAsientos CA")
         .AppendLine(" INNER JOIN ContabilidadAsientosCuentas CAC ON CA.IdEjercicio = CAC.IdEjercicio AND CA.IdPlanCuenta = CAC.IdPlanCuenta AND CA.IdAsiento = CAC.IdAsiento")
         .AppendLine(" INNER JOIN ContabilidadCuentas CC ON CC.IdCuenta = CAC.IdCuenta")
         .AppendLine("  LEFT JOIN Clientes AS CL ON CL.IdCliente = CONVERT(bigint, CAC.Referencia)")
         .AppendLine("  LEFT JOIN Proveedores AS PR ON PR.IdProveedor = CONVERT(bigint, CAC.Referencia)")

         .AppendFormatLine("  LEFT JOIN Ventas ON Ventas.IdAsiento = CA.IdAsiento AND Ventas.IdPlanCuenta = CA.IdPlanCuenta")

         .AppendFormatLine("  LEFT JOIN CuentasCorrientes AS CuentasCorrientesV ON CuentasCorrientesV.IdSucursal = Ventas.IdSucursal")
         .AppendFormatLine("                                                   AND CuentasCorrientesV.IdTipoComprobante = Ventas.IdTipoComprobante")
         .AppendFormatLine("                                                   AND CuentasCorrientesV.Letra = Ventas.Letra")
         .AppendFormatLine("                                                   AND CuentasCorrientesV.CentroEmisor = Ventas.CentroEmisor")
         .AppendFormatLine("                                                   AND CuentasCorrientesV.NumeroComprobante = Ventas.NumeroComprobante")

         .AppendFormatLine("  LEFT JOIN CuentasCorrientes ON CuentasCorrientes.IdAsiento = CA.IdAsiento AND CuentasCorrientes.IdPlanCuenta = CA.IdPlanCuenta")
         .AppendFormatLine("  LEFT JOIN Compras ON Compras.IdAsiento = CA.IdAsiento AND Compras.IdPlanCuenta = CA.IdPlanCuenta")

         .AppendFormatLine("  LEFT JOIN CuentasCorrientesProv AS CuentasCorrientesC ON CuentasCorrientesC.IdSucursal = Ventas.IdSucursal")
         .AppendFormatLine("                                                       AND CuentasCorrientesC.IdTipoComprobante = Ventas.IdTipoComprobante")
         .AppendFormatLine("                                                       AND CuentasCorrientesC.Letra = Ventas.Letra")
         .AppendFormatLine("                                                       AND CuentasCorrientesC.CentroEmisor = Ventas.CentroEmisor")
         .AppendFormatLine("                                                       AND CuentasCorrientesC.NumeroComprobante = Ventas.NumeroComprobante")
         .AppendFormatLine("                                                       AND CuentasCorrientesC.IdProveedor = Ventas.IdProveedor")

         .AppendFormatLine("  LEFT JOIN CuentasCorrientesProv ON CuentasCorrientesProv.IdAsiento = CA.IdAsiento AND CuentasCorrientesProv.IdPlanCuenta = CA.IdPlanCuenta")

         If exportados <> "SI" Then
            .AppendFormatLine(" WHERE CA.FechaAsiento BETWEEN '{0} 00:00:00' AND '{1} 23:59:59'", fechaDesde.ToString("yyyyMMdd"), fechaHasta.ToString("yyyyMMdd"))
         Else
            .AppendFormatLine(" WHERE 1=1")
         End If
         .AppendFormatLine(" AND CA.IdPlanCuenta = {0}", idPlanCuenta)
         If exportados <> "TODOS" Then
            .AppendLine("      AND CA.FechaExportacion " & IIf(exportados = "SI", "= '" & fechaExport & "'", " IS NULL").ToString())
         End If
         .AppendFormatLine(" AND CA.SubsiAsiento IN ({0})", stbProcesos.ToString().Trim(","c))
         .AppendFormatLine(") AS CA")
         .AppendLine("  LEFT JOIN AFIPTiposComprobantesTiposCbtes AS AFIP ON CA.IdTipoComprobante = AFIP.IdTipoComprobante AND CA.Letra = AFIP.Letra")
         .AppendLine(" ORDER BY CA.IdPlanCuenta, CA.IdAsiento ")
      End With

      Return GetDataTable(stbQuery)

   End Function

   Public Function GetFechasExportacion() As DataTable
      Dim stbQuery = New StringBuilder()
      With stbQuery
         .Append("SELECT DISTINCT FechaExportacion ")
         .Append(" FROM ContabilidadAsientos WHERE FechaExportacion IS NOT NULL")
         .Append(" ORDER BY FechaExportacion DESC")

      End With
      Return GetDataTable(stbQuery)
   End Function


   Public Sub EjecutaRenumerarAsientos(idEjercicio As Integer, idPlanCuenta As Integer)

      _da.Command.CommandText = "EXECUTE dbo.ContabilidadRenumerarAsientos @IdEjercicio, @IdPlanCuenta"
      _da.Command.CommandType = CommandType.Text

      _da.Command.Parameters.Clear()
      _da.LoadParameter("@IdEjercicio", ParameterDirection.Input, DbType.Int32, idEjercicio)
      _da.LoadParameter("@IdPlanCuenta", ParameterDirection.Input, DbType.Int32, idPlanCuenta)

      _da.Command.Connection = _da.Connection
      _da.ExecuteNonQuery(_da.Command)
   End Sub


End Class