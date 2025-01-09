Partial Class Ventas

#Region "Get Consolidado"

#End Region

#Region "Get Kilos"
   Public Function GetKilosTotalesPorCliente(sucursales As Entidades.Sucursal(),
                                             empresaIvaDiscriminado As Boolean,
                                             desde As Date,
                                             hasta As Date,
                                             tipoKilos As String,
                                             IdVendedor As Integer,
                                             idCliente As Long,
                                             marcas As Entidades.Marca(),
                                             rubros As Entidades.Rubro(),
                                             subRubros As Entidades.SubRubro(),
                                             idZonaGeografica As String,
                                             idLocalidad As Integer,
                                             incluyeClientesSinMovimiento As Boolean,
                                             Optional ByVal TotalesPorSucursal As Boolean = False) As DataTable

      Dim stb As StringBuilder = New StringBuilder()

      With stb
         .AppendLine("SELECT V.IdCliente")
         .AppendLine("    ,C.CodigoCliente")
         .AppendLine("      ,C.NombreCliente")
         .AppendLine("      ,C.IdZonaGeografica")
         .AppendLine("      ,ZG.NombreZonaGeografica")
         .AppendLine("      ,L.NombreLocalidad")

         If empresaIvaDiscriminado Then
            .AppendLine("    ,SUM(VP.ImporteTotalNeto) as Total")
         Else
            .AppendLine("    ,SUM(VP.ImporteTotalNeto+VP.ImporteImpuesto) as Total")
         End If

         .AppendLine("    ,SUM(VP.Kilos) as Kilos")

         .AppendLine("    ,SUM(VP.Cantidad) AS Cantidad")

         'PE-31378
         If TotalesPorSucursal Then
            .AppendLine("    ,V.IdSucursal")
         Else
            .AppendLine("    ,NULL as IdSucursal")
         End If

         .AppendLine(" FROM Ventas V")
         .AppendLine(" INNER JOIN VentasProductos VP ON V.IdSucursal=VP.IdSucursal ")
         .AppendLine("                              AND V.IdTipoComprobante=VP.IdTipoComprobante")
         .AppendLine("                              AND V.Letra=VP.Letra")
         .AppendLine("                              AND V.CentroEmisor=VP.CentroEmisor")
         .AppendLine("                              AND V.NumeroComprobante=VP.NumeroComprobante")
         .AppendLine(" INNER JOIN Clientes C ON V.IdCliente = C.IdCliente")
         .AppendLine(" INNER JOIN TiposComprobantes TC ON V.IdTipoComprobante = TC.IdTipoComprobante ")
         .AppendLine(" INNER JOIN ZonasGeograficas ZG ON C.IdZonaGeografica = ZG.IdZonaGeografica")
         .AppendLine(" INNER JOIN Localidades L ON C.IdLocalidad = L.IdLocalidad")
         .AppendLine("  INNER JOIN Productos P ON VP.IdProducto = P.IdProducto")

         .AppendLine("   WHERE 1 = 1")
         GetListaSucursalesMultiples(stb, sucursales, "V")

         .AppendLine("   AND CONVERT(varchar(11), V.fecha, 120) >= '" & desde.ToString("yyyy-MM-dd") & "'")
         .AppendLine("   AND CONVERT(varchar(11), V.fecha, 120) <= '" & hasta.ToString("yyyy-MM-dd") & "'")

         .AppendLine("   AND TC.AfectaCaja = 'True'")
         .AppendLine("   AND TC.EsComercial = 'True'")   'Con esto solo alcanzaria, pero por ahora dejamos ambos.

         If tipoKilos = "CON KILOS" Then
            .AppendLine(" AND VP.Kilos <> 0")
         ElseIf tipoKilos = "SIN KILOS" Then
            .AppendLine(" AND VP.Kilos = 0")
         End If

         If IdVendedor > 0 Then
            .AppendLine("	AND V.IdVendedor = " & IdVendedor)
         End If

         If idCliente > 0 Then
            .AppendLine("	AND C.IdCliente = " & idCliente.ToString())
         End If

         GetListaMarcasMultiples(stb, marcas, "P")
         GetListaRubrosMultiples(stb, rubros, "P")
         GetListaSubRubrosMultiples(stb, subRubros, "P")

         If Not String.IsNullOrEmpty(idZonaGeografica) Then
            .AppendFormat(" AND C.IdZonaGeografica = '{0}'", idZonaGeografica)
         End If

         If idLocalidad > 0 Then
            .AppendLine(" AND C.IdLocalidad = " & idLocalidad.ToString())
         End If

         'PE-31378
         If TotalesPorSucursal Then
            .AppendLine("GROUP BY V.IdCliente, C.CodigoCliente, C.NombreCliente, C.IdZonaGeografica, ZG.NombreZonaGeografica, L.NombreLocalidad, V.IdSucursal")
         Else
            .AppendLine("GROUP BY V.IdCliente, C.CodigoCliente, C.NombreCliente, C.IdZonaGeografica, ZG.NombreZonaGeografica, L.NombreLocalidad")
         End If

         If incluyeClientesSinMovimiento Then

            .AppendLine("UNION")

            .AppendLine("SELECT C.IdCliente AS IdCliente")
            .AppendLine("  ,C.CodigoCliente")
            .AppendLine("      ,C.NombreCliente")
            .AppendLine("      ,C.IdZonaGeografica")
            .AppendLine("      ,ZG.NombreZonaGeografica")
            .AppendLine("      ,L.NombreLocalidad")
            .AppendLine("      ,0 as Total")
            .AppendLine("      ,0 as Kilos")
            .AppendLine("      ,0 AS Cantidad")
            .AppendLine(" FROM Clientes C ")
            .AppendLine(" INNER JOIN ZonasGeograficas ZG ON C.IdZonaGeografica = ZG.IdZonaGeografica")
            .AppendLine(" INNER JOIN Localidades L ON C.IdLocalidad = L.IdLocalidad")
            .AppendLine(" WHERE C.Activo = 'True' ")

            If IdVendedor > 0 Then
               .AppendLine("	AND C.IdVendedor = " & IdVendedor)
            End If

            .AppendLine("   AND NOT EXISTS ")
            .AppendLine(" ( SELECT * FROM Ventas V")
            .AppendLine(" INNER JOIN VentasProductos VP ON V.IdSucursal=VP.IdSucursal ")
            .AppendLine("                              AND V.IdTipoComprobante=VP.IdTipoComprobante")
            .AppendLine("                              AND V.Letra=VP.Letra")
            .AppendLine("                              AND V.CentroEmisor=VP.CentroEmisor")
            .AppendLine("                              AND V.NumeroComprobante=VP.NumeroComprobante")
            .AppendLine("   INNER JOIN TiposComprobantes TC ON V.IdTipoComprobante = TC.IdTipoComprobante ")
            .AppendLine("   WHERE 1 = 1")

            GetListaSucursalesMultiples(stb, sucursales, "V")

            .AppendLine("   AND CONVERT(varchar(11), V.fecha, 120) >= '" & desde.ToString("yyyy-MM-dd") & "'")
            .AppendLine("   AND CONVERT(varchar(11), V.fecha, 120) <= '" & hasta.ToString("yyyy-MM-dd") & "'")

            .AppendLine("   AND TC.AfectaCaja = 'True'")
            .AppendLine("   AND TC.EsComercial = 'True'")   'Con esto solo alcanzaria, pero por ahora dejamos ambos.

            If tipoKilos = "CON KILOS" Then
               .AppendLine(" AND VP.Kilos <> 0")
            ElseIf tipoKilos = "SIN KILOS" Then
               .AppendLine(" AND VP.Kilos = 0")
            End If

            If idCliente > 0 Then
               .AppendLine("	AND C.IdCliente = " & idCliente.ToString())
            End If

            .AppendLine("  AND V.IdCliente = C.IdCliente ")

            .AppendLine(" )")

            If Not String.IsNullOrEmpty(idZonaGeografica) Then
               .AppendFormat(" AND C.IdZonaGeografica = '{0}'", idZonaGeografica)
            End If

            If idLocalidad > 0 Then
               .AppendLine(" AND C.IdLocalidad = " & idLocalidad.ToString())
            End If

         End If

         .AppendLine("ORDER BY NombreLocalidad, NombreCliente")

      End With

      Return GetDataTable(stb.ToString())
   End Function

   Public Function GetKilosComisionesCategoriasClientes(sucursales As Entidades.Sucursal(),
                                              empresaIvaDiscriminado As Boolean,
                                              desde As Date,
                                              hasta As Date,
                                              IdCategoria As Integer,
                                              IdVendedor As Integer,
                                              idCliente As Long,
                                              categorias As List(Of Entidades.Categoria),
                                              rubros As Entidades.Rubro(),
                                              subRubros As Entidades.SubRubro(),
                                              subSubrubros As Entidades.SubSubRubro(),
                                              marcas As Entidades.Marca(),
                                              idZonaGeografica As String,
                                              idLocalidad As Integer,
                                              IdTransportista As Integer,
                                                categoria As Entidades.OrigenFK) As DataTable

      Dim stb As StringBuilder = New StringBuilder()

      With stb

         .AppendFormat("SELECT PV1.Fecha, 0.00 as TotalComision, 0.00 as TotalKilos").AppendLine()
         For Each lis As Entidades.Categoria In categorias
            .AppendFormat("      ,SUM(ki_{0}) ki_{0},MAX(co_{0}) * SUM(ki_{0}/100)  co_{0}", lis.IdCategoria).AppendLine()
         Next

         .AppendLine(" FROM (SELECT convert(date, V.Fecha,120) as Fecha ")

         If categoria = Entidades.OrigenFK.Actual Then
            .AppendLine("  ,C.IdCategoria ")
         Else
            .AppendLine("  ,V.IdCategoria ")
         End If

         .AppendLine(" ,CA.Comisiones")
         .AppendLine(" ,VP.Kilos ")
         .AppendLine(" , CA.DescuentoRecargo * VP.Kilos AS Importe ")

         If categoria = Entidades.OrigenFK.Actual Then
            .AppendLine(" ,'ki_' + CONVERT(VARCHAR(MAX), C.IdCategoria) AS IdCategoria_pv ")
            .AppendLine(" ,'co_' + CONVERT(VARCHAR(MAX), C.IdCategoria) AS IdCategoria_fa ")
         Else
            .AppendLine(" ,'ki_' + CONVERT(VARCHAR(MAX), V.IdCategoria) AS IdCategoria_pv ")
            .AppendLine(" ,'co_' + CONVERT(VARCHAR(MAX), V.IdCategoria) AS IdCategoria_fa ")
         End If


         '.AppendLine("    ,SUM(VP.Kilos) as Kilos")

         .AppendLine(" FROM Ventas V")
         .AppendLine(" INNER JOIN VentasProductos VP ON V.IdSucursal=VP.IdSucursal ")
         .AppendLine("                              AND V.IdTipoComprobante=VP.IdTipoComprobante")
         .AppendLine("                              AND V.Letra=VP.Letra")
         .AppendLine("                              AND V.CentroEmisor=VP.CentroEmisor")
         .AppendLine("                              AND V.NumeroComprobante=VP.NumeroComprobante")
         .AppendLine(" INNER JOIN Clientes C ON V.IdCliente = C.IdCliente")
         .AppendLine(" INNER JOIN TiposComprobantes TC ON V.IdTipoComprobante = TC.IdTipoComprobante ")
         .AppendLine(" INNER JOIN ZonasGeograficas ZG ON C.IdZonaGeografica = ZG.IdZonaGeografica")
         .AppendLine(" INNER JOIN Localidades L ON C.IdLocalidad = L.IdLocalidad")
         .AppendLine("  INNER JOIN Productos P ON VP.IdProducto = P.IdProducto")

         If categoria = Entidades.OrigenFK.Actual Then
            .AppendLine("  INNER JOIN Categorias CA ON CA.IdCategoria = C.IdCategoria")
         Else
            .AppendLine("  INNER JOIN Categorias CA ON CA.IdCategoria = V.IdCategoria")
         End If

         .AppendLine("   WHERE 1 = 1")
         GetListaSucursalesMultiples(stb, sucursales, "V")

         .AppendLine("   AND V.fecha >= '" & ObtenerFecha(desde, False) & "'")
         .AppendLine("   AND V.fecha <= '" & ObtenerFecha(hasta.UltimoSegundoDelDia(), True) & "'")

         If IdVendedor > 0 Then
            .AppendLine("	AND V.IdVendedor = " & IdVendedor)
         End If

         If idCliente > 0 Then
            .AppendLine("	AND C.IdCliente = " & idCliente.ToString())
         End If

         'If IdCategoria > 0 Then
         '   .AppendLine("	AND C.IdCategoria = " & IdCategoria.ToString())
         'End If

         If IdTransportista > 0 Then
            .AppendLine("	AND V.IdTransportista = " & IdTransportista.ToString())
         End If

         GetListaMarcasMultiples(stb, marcas, "P")
         GetListaRubrosMultiples(stb, rubros, "P")
         GetListaSubRubrosMultiples(stb, subRubros, "P")
         GetListaSubSubRubrosMultiples(stb, subSubrubros, "P")

         If Not String.IsNullOrEmpty(idZonaGeografica) Then
            .AppendFormat(" AND C.IdZonaGeografica = '{0}'", idZonaGeografica)
         End If

         If idLocalidad > 0 Then
            .AppendLine(" AND C.IdLocalidad = " & idLocalidad.ToString())
         End If

         If IdCategoria > 0 Then
            If categoria = Entidades.OrigenFK.Actual Then
               .AppendLine("   AND C.IdCategoria = " & IdCategoria.ToString())
            Else
               .AppendLine("   AND V.IdCategoria = " & IdCategoria.ToString())
            End If
         End If
         .AppendLine("   AND TC.EsRemitoTransportista = 'False'")

         .AppendFormat("    ) AS V").AppendLine()
         .AppendFormat("PIVOT").AppendLine()
         .AppendFormat(" (").AppendLine()
         .AppendFormat("   SUM(Kilos) FOR IdCategoria_pv IN (")
         Dim primero As Boolean = True
         For Each lis As Entidades.Categoria In categorias
            If Not primero Then .AppendFormat(",")
            primero = False
            .AppendFormat("[ki_{0}]", lis.IdCategoria)
         Next
         .AppendFormat(")").AppendLine()
         .AppendFormat(" ) AS pv1").AppendLine()
         .AppendFormat("PIVOT").AppendLine()
         .AppendFormat(" (").AppendLine()
         .AppendFormat("   MAX(Comisiones) FOR IdCategoria_fa IN (")
         primero = True
         For Each lis As Entidades.Categoria In categorias
            If Not primero Then .AppendFormat(",")
            primero = False
            .AppendFormat("[co_{0}]", lis.IdCategoria)
         Next
         .AppendFormat(")").AppendLine()
         .AppendFormat(" ) AS pv1").AppendLine()
         .AppendFormat(" GROUP BY PV1.Fecha").AppendLine()

         '.AppendLine("GROUP BY convert(varchar, V.Fecha,101)  ,C.IdCategoria ,CA.DescuentoRecargo")


         .AppendLine("ORDER BY PV1.Fecha")

      End With

      Return GetDataTable(stb.ToString())
   End Function

   Public Function GetKilosCompMensualPorCliente(sucursales As Entidades.Sucursal(),
                                              desde As Date,
                                              hasta As Date,
                                              IdVendedor As Integer,
                                              idCliente As Long,
                                              marcas As List(Of Entidades.Marca), modelos As List(Of Entidades.Modelo),
                                              rubros As List(Of Entidades.Rubro), subRubros As List(Of Entidades.SubRubro), subSubRubros As List(Of Entidades.SubSubRubro),
                                              idProducto As String,
                                              idZonaGeografica As String,
                                              idLocalidad As Integer,
                                              tipoInforme As String,
                                              conIva As Boolean,
                                              idClienteVinculado As Long) As DataTable

      Dim CantPeriodos As Integer
      CantPeriodos = ((hasta.Year - desde.Year) * 12) + (hasta.Month - desde.Month) + 1

      Dim Periodo As Date = desde

      Dim QueSuma As String

      If tipoInforme = "KILOS" Then
         QueSuma = "VP.Kilos"

      Else  'Por Montos
         If conIva Then
            QueSuma = "VP.ImporteTotalNeto+VP.ImporteImpuesto"
         Else
            QueSuma = "VP.ImporteTotalNeto"
         End If
      End If


      Dim stb As StringBuilder = New StringBuilder("")
      Dim Mes1 As Date
      Dim Mes2 As Date
      Dim Mes3 As Date
      Dim Mes4 As Date
      Dim Mes5 As Date
      Dim Mes6 As Date
      Dim Mes7 As Date
      Dim Mes8 As Date
      Dim Mes9 As Date
      Dim Mes10 As Date
      Dim Mes11 As Date
      Dim Mes12 As Date

      With stb
         .Length = 0
         .AppendLine("SELECT IdSucursal, IdCliente, CodigoCliente, NombreCliente, NombreLocalidad, ")

         If 1 <= CantPeriodos Then
            Mes1 = desde
            .AppendLine(" SUM(Mes1) AS '" & Mes1.ToString("yyyyMM") & "',")
         End If

         If 2 <= CantPeriodos Then
            Mes2 = Mes1.AddMonths(1)
            .AppendLine(" SUM(Mes2) AS '" & Mes2.ToString("yyyyMM") & "',")
         End If

         If 3 <= CantPeriodos Then
            Mes3 = Mes2.AddMonths(1)
            .AppendLine(" SUM(Mes3) AS '" & Mes3.ToString("yyyyMM") & "',")
         End If

         If 4 <= CantPeriodos Then
            Mes4 = Mes3.AddMonths(1)
            .AppendLine(" SUM(Mes4) AS '" & Mes4.ToString("yyyyMM") & "',")
         End If

         If 5 <= CantPeriodos Then
            Mes5 = Mes4.AddMonths(1)
            .AppendLine(" SUM(Mes5) AS '" & Mes5.ToString("yyyyMM") & "',")
         End If

         If 6 <= CantPeriodos Then
            Mes6 = Mes5.AddMonths(1)
            .AppendLine(" SUM(Mes6) AS '" & Mes6.ToString("yyyyMM") & "',")
         End If

         If 7 <= CantPeriodos Then
            Mes7 = Mes6.AddMonths(1)
            .AppendLine(" SUM(Mes7) AS '" & Mes7.ToString("yyyyMM") & "',")
         End If

         If 8 <= CantPeriodos Then
            Mes8 = Mes7.AddMonths(1)
            .AppendLine(" SUM(Mes8) AS '" & Mes8.ToString("yyyyMM") & "',")
         End If

         If 9 <= CantPeriodos Then
            Mes9 = Mes8.AddMonths(1)
            .AppendLine(" SUM(Mes9) AS '" & Mes9.ToString("yyyyMM") & "',")
         End If

         If 10 <= CantPeriodos Then
            Mes10 = Mes9.AddMonths(1)
            .AppendLine(" SUM(Mes10) AS '" & Mes10.ToString("yyyyMM") & "',")
         End If

         If 11 <= CantPeriodos Then
            Mes11 = Mes10.AddMonths(1)
            .AppendLine(" SUM(Mes11) AS '" & Mes11.ToString("yyyyMM") & "',")
         End If

         If 12 <= CantPeriodos Then
            Mes12 = Mes11.AddMonths(1)
            .AppendLine(" SUM(Mes12) AS '" & Mes12.ToString("yyyyMM") & "',")
         End If

         '.AppendLine("       SUM(Mes1) AS Mes1, SUM(Mes2) AS Mes2, SUM(Mes3) AS Mes3,")
         '.AppendLine("       SUM(Mes4) AS Mes4, SUM(Mes5) AS Mes5, SUM(Mes6) AS Mes6, SUM(Mes7) AS Mes7,")
         '.AppendLine("       SUM(Mes8) AS Mes8, SUM(Mes9) AS Mes9, SUM(Mes10) AS Mes10,")
         '.AppendLine("       SUM(Mes11) AS Mes11, SUM(Mes12) AS Mes12,")
         .AppendLine("       SUM(MesActual) AS MesActual,")
         .AppendLine("       SUM(Mes1+Mes2+Mes3+Mes4+Mes5+Mes6+Mes7+Mes8+Mes9+Mes10+Mes11+Mes12) AS Total,")
         .AppendLine("       ROUND(SUM(Mes1+Mes2+Mes3+Mes4+Mes5+Mes6+Mes7+Mes8+Mes9+Mes10+Mes11+Mes12)/" & CantPeriodos.ToString() & ",2) AS Promedio")

         .AppendLine("  FROM")
         .AppendLine("( ")
         .AppendLine("SELECT V.IdSucursal, V.IdCliente, C.CodigoCliente, C.NombreCliente, L.NombreLocalidad")

         For Cont As Long = 1 To CantPeriodos
            .AppendLine(" ,CASE YEAR(fecha)*100+MONTH(fecha)")
            .AppendLine("      WHEN " & Periodo.ToString("yyyyMM") & " Then SUM(" & QueSuma & ")")
            .AppendLine("      ELSE 0 ")
            .AppendLine(" END Mes" & Cont.ToString())
            Periodo = Periodo.AddMonths(1)
         Next

         .AppendLine(" ,CASE YEAR(fecha)*100+MONTH(fecha)")
         .AppendLine("      WHEN " & Date.Now.ToString("yyyyMM") & " Then SUM(" & QueSuma & ")")
         .AppendLine("      ELSE 0 ")
         .AppendLine(" END MesActual")

         For Cont As Long = CantPeriodos + 1 To 12
            .AppendLine(" ,0 AS Mes" & Cont.ToString())
         Next

         .AppendLine(" FROM VentasProductos VP")
         .AppendLine(" INNER JOIN Ventas V ON VP.IdSucursal = V.IdSucursal")
         .AppendLine("                    AND VP.IdTipoComprobante = V.IdTipoComprobante")
         .AppendLine("                    AND VP.Letra = V.Letra")
         .AppendLine("                    AND VP.CentroEmisor = V.CentroEmisor")
         .AppendLine("                    AND VP.NumeroComprobante = V.NumeroComprobante")
         .AppendLine(" INNER JOIN TiposComprobantes TC ON V.IdTipoComprobante = TC.IdTipoComprobante")
         .AppendLine(" INNER JOIN VentasFormasPago VFP ON V.IdFormasPago = VFP.IdFormasPago")
         .AppendLine(" INNER JOIN Productos P ON VP.IdProducto = P.IdProducto")
         .AppendLine(" INNER JOIN Marcas M ON P.IdMarca = M.IdMarca")
         .AppendLine(" INNER JOIN Rubros R ON P.IdRubro = R.IdRubro")
         .AppendLine(" LEFT JOIN Clientes C ON V.IdCliente = C.IdCliente")
         .AppendLine(" INNER JOIN ZonasGeograficas ZG ON C.IdZonaGeografica = ZG.IdZonaGeografica")
         .AppendLine(" INNER JOIN Localidades L ON C.IdLocalidad = L.IdLocalidad")

         '.AppendLine(" WHERE V.IdSucursal = " & idSucursal.ToString())

         .AppendLine("   WHERE TC.AfectaCaja = 'True'")
         .AppendLine("   AND TC.EsComercial = 'True'")   'Con esto solo alcanzaria, pero por ahora dejamos ambos.
         '  .AppendLine("   AND VP.Kilos<>0")

         .AppendLine("   AND ( (YEAR(V.Fecha)*100+MONTH(fecha) >= '" & desde.ToString("yyyyMM") & "'")
         .AppendLine("        AND YEAR(V.Fecha)*100+MONTH(fecha) <= '" & hasta.ToString("yyyyMM") & "')")
         .AppendLine("        OR YEAR(V.Fecha)*100+MONTH(fecha) = '" & Date.Now.ToString("yyyyMM") & "')")

         GetListaSucursalesMultiples(stb, sucursales, "V")

         If IdVendedor > 0 Then
            .AppendLine("	AND V.IdVendedor = " & IdVendedor)
         End If

         If idCliente <> 0 Then
            .AppendLine("	AND C.IdCliente = " & idCliente)
         End If
         If idClienteVinculado <> 0 Then
            .AppendLine("	AND V.IdClienteVinculado = " & idClienteVinculado)
         End If

         'If idMarca > 0 Then
         '   .AppendLine("   AND P.IdMarca = " & idMarca.ToString())
         'End If

         'If idRubro > 0 Then
         '   .AppendLine("   AND P.IdRubro = " & idRubro.ToString())
         'End If

         If Not String.IsNullOrEmpty(idProducto) Then
            .AppendLine("	AND VP.IdProducto = '" & idProducto & "'")
         End If

         If Not String.IsNullOrEmpty(idZonaGeografica) Then
            .AppendFormat(" AND ZG.IdZonaGeografica = '{0}'", idZonaGeografica)
         End If

         If idLocalidad > 0 Then
            .AppendLine(" AND C.IdLocalidad = " & idLocalidad.ToString())
         End If

         GetListaMarcasMultiples(stb, marcas, "P")
         GetListaModelosMultiples(stb, modelos, "P")
         GetListaRubrosMultiples(stb, rubros, "P")
         GetListaSubRubrosMultiples(stb, subRubros, "P")
         GetListaSubSubRubrosMultiples(stb, subSubRubros, "P")

         .AppendLine(" GROUP BY V.IdCliente, C.CodigoCliente, C.NombreCliente, L.NombreLocalidad, V.Fecha, V.IdSucursal")
         .AppendLine(") Detalle")
         .AppendLine("GROUP BY IdCliente, CodigoCliente, NombreCliente, NombreLocalidad, IdSucursal")
         .AppendLine("ORDER BY NombreCliente, CodigoCliente")

      End With

      Return Me.GetDataTable(stb.ToString())

   End Function

   Public Function GetKilosCompMarcasPorCliente(sucursales As Entidades.Sucursal(),
                                             ByVal Desde As Date,
                                             ByVal Hasta As Date,
                                             ByVal idMarca1 As Integer,
                                             ByVal idMarca2 As Integer,
                                             ByVal idMarca3 As Integer,
                                             ByVal idMarca4 As Integer,
                                             ByVal idMarca5 As Integer,
                                             ByVal idRubro As Integer,
                                             ByVal IdVendedor As Integer,
                                             ByVal idZonaGeografica As String,
                                             ByVal IdCliente As Long,
                                             ByVal IdLocalidad As Integer) As DataTable


      Dim stb As StringBuilder = New StringBuilder("")

      With stb
         .Length = 0
         .AppendLine("SELECT IdSucursal, IdCliente, CodigoCliente, NombreCliente, NombreLocalidad,")
         .AppendLine("       SUM(Marca1) AS Marca1, SUM(Marca2) AS Marca2, SUM(Marca3) AS Marca3,")
         .AppendLine("       SUM(Marca4) AS Marca4, SUM(Marca5) AS Marca5,")
         .AppendLine("       SUM(Marca1+Marca2+Marca3+Marca4+Marca5) AS Total")
         .AppendLine("  FROM")
         .AppendLine("( ")
         .AppendLine("SELECT V.IdSucursal, V.IdCliente, C.CodigoCliente, C.NombreCliente, L.NombreLocalidad,")
         .AppendLine(" CASE P.IdMarca")
         .AppendLine("      WHEN " & idMarca1.ToString() & " Then SUM(VP.Kilos)")
         .AppendLine("      ELSE 0 ")
         .AppendLine(" END Marca1,")
         .AppendLine(" CASE P.IdMarca")
         .AppendLine("      WHEN " & idMarca2.ToString() & " Then SUM(VP.Kilos)")
         .AppendLine("      ELSE 0 ")
         .AppendLine(" END Marca2,")
         '---Si no hay marca 3,4 o 5... nunca va a encontrar una con valor 0.
         .AppendLine(" CASE P.IdMarca")
         .AppendLine("      WHEN " & idMarca3.ToString() & " Then SUM(VP.Kilos)")
         .AppendLine("      ELSE 0 ")
         .AppendLine(" END Marca3,")
         .AppendLine(" CASE P.IdMarca")
         .AppendLine("      WHEN " & idMarca4.ToString() & " Then SUM(VP.Kilos)")
         .AppendLine("      ELSE 0 ")
         .AppendLine(" END Marca4,")
         .AppendLine(" CASE P.IdMarca")
         .AppendLine("      WHEN " & idMarca5.ToString() & " Then SUM(VP.Kilos)")
         .AppendLine("      ELSE 0 ")
         .AppendLine(" END Marca5")
         .AppendLine(" FROM VentasProductos VP")
         .AppendLine(" INNER JOIN Ventas V ON VP.IdSucursal = V.IdSucursal")
         .AppendLine("                    AND VP.IdTipoComprobante = V.IdTipoComprobante")
         .AppendLine("                    AND VP.Letra = V.Letra")
         .AppendLine("                    AND VP.CentroEmisor = V.CentroEmisor")
         .AppendLine("                    AND VP.NumeroComprobante = V.NumeroComprobante")
         .AppendLine(" INNER JOIN Productos P ON VP.IdProducto = P.IdProducto")
         .AppendLine(" INNER JOIN Clientes C ON V.IdCliente = C.IdCliente")
         .AppendLine(" INNER JOIN TiposComprobantes TC ON VP.IdTipoComprobante = TC.IdTipoComprobante ")
         .AppendLine(" INNER JOIN ZonasGeograficas ZG ON C.IdZonaGeografica = ZG.IdZonaGeografica")
         .AppendLine(" INNER JOIN Localidades L ON C.IdLocalidad = L.IdLocalidad")

         .AppendLine(" WHERE P.IdMarca in (" & idMarca1.ToString() & ", " & idMarca2.ToString() & ", " & idMarca3.ToString() & ", " & idMarca4.ToString() & ", " & idMarca5.ToString() & ")")

         '.AppendLine("   AND V.IdSucursal = " & idSucursal.ToString())

         .AppendLine("   AND CONVERT(varchar(11), V.Fecha, 120) >= '" & Desde.ToString("yyyy-MM-dd") & "'")
         .AppendLine("   AND CONVERT(varchar(11), V.Fecha, 120) <= '" & Hasta.ToString("yyyy-MM-dd") & "'")

         GetListaSucursalesMultiples(stb, sucursales, "V")

         .AppendLine("   AND TC.AfectaCaja = 'True'")
         .AppendLine("   AND TC.EsComercial = 'True'")   'Con esto solo alcanzaria, pero por ahora dejamos ambos.

         If idRubro > 0 Then
            .AppendLine("   AND P.IdRubro = " & idRubro.ToString())
         End If

         If IdVendedor > 0 Then
            .AppendLine("	AND V.IdVendedor = " & IdVendedor)
         End If

         If Not String.IsNullOrEmpty(idZonaGeografica) Then
            .AppendFormat(" AND ZG.IdZonaGeografica = '{0}'", idZonaGeografica)
         End If

         If IdCliente > 0 Then
            .AppendLine("	AND C.IdCliente = " & IdCliente)
         End If

         If IdLocalidad > 0 Then
            .AppendLine(" AND C.IdLocalidad = " & IdLocalidad.ToString())
         End If

         .AppendLine(" GROUP BY V.IdCliente, C.CodigoCliente, C.NombreCliente, L.NombreLocalidad, P.IdMarca, V.IdSucursal")
         .AppendLine(") Detalle")
         .AppendLine(" GROUP BY IdCliente, CodigoCliente, NombreCliente, NombreLocalidad, IdSucursal")
         .AppendLine(" ORDER BY NombreCliente, CodigoCliente ")

      End With

      Return Me.GetDataTable(stb.ToString())

   End Function


   Public Function GetKilosDetalladoPorProductos(sucursales As Entidades.Sucursal(), desde As Date, hasta As Date, tipoKilos As String,
                                                 idVendedor As Integer, idCliente As Long,
                                                 marcas As Entidades.Marca(), modelos As Entidades.Modelo(),
                                                 rubros As Entidades.Rubro(), subrubros As Entidades.SubRubro(), subSubRubros As Entidades.SubSubRubro(),
                                                 idProducto As String, idZonaGeografica As String, idLocalidad As Integer,
                                                 ivaDiscriminado As Boolean) As DataTable
      Dim stb = New StringBuilder()
      With stb
         .AppendFormatLine("SELECT V.IdVendedor")
         .AppendFormatLine("     , V.Fecha")
         .AppendFormatLine("     , V.IdTipoComprobante")
         .AppendFormatLine("     , TC.DescripcionAbrev")
         .AppendFormatLine("     , V.Letra")
         .AppendFormatLine("     , V.CentroEmisor")
         .AppendFormatLine("     , V.NumeroComprobante")
         .AppendFormatLine("     , V.IdFormasPago")
         .AppendFormatLine("     , VFP.DescripcionFormasPago AS FormaPago")
         .AppendFormatLine("     , V.IdCliente")
         .AppendFormatLine("     , C.CodigoCliente")
         .AppendFormatLine("     , C.NombreCliente")
         .AppendFormatLine("     , C.IdZonaGeografica")
         .AppendFormatLine("     , ZG.NombreZonaGeografica")
         .AppendFormatLine("     , L.NombreLocalidad")
         .AppendFormatLine("     , VP.IdProducto")
         .AppendFormatLine("     , VP.NombreProducto")
         .AppendFormatLine("     , P.Tamano")
         .AppendFormatLine("     , P.IdUnidadDeMedida")
         .AppendFormatLine("     , P.IdMarca")
         .AppendFormatLine("     , M.NombreMarca")
         .AppendFormatLine("     , P.IdModelo")
         .AppendFormatLine("     , Mo.NombreModelo")
         .AppendFormatLine("     , P.IdRubro")
         .AppendFormatLine("     , R.NombreRubro")
         .AppendFormatLine("     , P.IdSubRubro")
         .AppendFormatLine("     , SR.NombreSubRubro")
         .AppendFormatLine("     , P.IdSubSubRubro")
         .AppendFormatLine("     , SSR.NombreSubSubRubro")
         .AppendFormatLine("     , VP.Cantidad")
         If ivaDiscriminado Then
            .AppendFormatLine("     , VP.ImporteTotalNeto")
         Else
            .AppendFormatLine("     , VP.ImporteTotalNeto+VP.ImporteImpuesto as ImporteTotalNeto")
         End If
         .AppendFormatLine("     , VP.Kilos")
         .AppendFormatLine("     , V.IdSucursal")

         .AppendFormatLine("  FROM Ventas V")
         .AppendFormatLine(" INNER JOIN VentasProductos VP")
         .AppendFormatLine("         ON V.IdSucursal = VP.IdSucursal")
         .AppendFormatLine("        AND V.IdTipoComprobante=VP.IdTipoComprobante")
         .AppendFormatLine("        AND V.Letra=VP.Letra")
         .AppendFormatLine("        AND V.CentroEmisor=VP.CentroEmisor")
         .AppendFormatLine("        AND V.NumeroComprobante=VP.NumeroComprobante")
         .AppendFormatLine(" INNER JOIN TiposComprobantes TC ON V.IdTipoComprobante = TC.IdTipoComprobante")
         .AppendFormatLine(" INNER JOIN VentasFormasPago VFP ON V.IdFormasPago = VFP.IdFormasPago")
         .AppendFormatLine(" INNER JOIN Productos P ON VP.IdProducto = P.IdProducto")
         .AppendFormatLine(" INNER JOIN Marcas M ON P.IdMarca = M.IdMarca")
         .AppendFormatLine("  LEFT JOIN Modelos Mo ON Mo.IdModelo = P.IdModelo")
         .AppendFormatLine(" INNER JOIN Rubros R ON P.IdRubro = R.IdRubro")
         .AppendFormatLine("  LEFT JOIN SubRubros SR ON SR.IdSubRubro = P.IdSubRubro")
         .AppendFormatLine("  LEFT JOIN SubSubRubros SSR ON SSR.IdSubSubRubro = P.IdSubSubRubro")
         .AppendFormatLine(" INNER JOIN Clientes C ON V.IdCliente = C.IdCliente ")
         .AppendFormatLine(" INNER JOIN ZonasGeograficas ZG ON C.IdZonaGeografica = ZG.IdZonaGeografica")
         .AppendFormatLine(" INNER JOIN Localidades L ON C.IdLocalidad = L.IdLocalidad")

         .AppendFormatLine(" WHERE 1 = 1")

         GetListaSucursalesMultiples(stb, sucursales, "V")

         .AppendFormatLine("   AND V.fecha >= '{0}'", ObtenerFecha(desde, False))
         .AppendFormatLine("   AND V.fecha <= '{0}'", ObtenerFecha(hasta.UltimoSegundoDelDia, True))

         .AppendFormatLine("   AND TC.AfectaCaja = 'True'")
         .AppendFormatLine("   AND TC.EsComercial = 'True'")   'Con esto solo alcanzaria, pero por ahora dejamos ambos.

         If tipoKilos = "CON KILOS" Then
            .AppendFormatLine("   AND VP.Kilos <> 0")
         ElseIf tipoKilos = "SIN KILOS" Then
            .AppendFormatLine("   AND VP.Kilos = 0")
         End If

         If idVendedor > 0 Then
            .AppendFormatLine("	AND V.IdVendedor = {0}", idVendedor)
         End If

         If idCliente > 0 Then
            .AppendFormatLine("	AND C.IdCliente = {0}", idCliente.ToString())
         End If

         GetListaMarcasMultiples(stb, marcas, "P")
         GetListaModelosMultiples(stb, modelos, "P")
         GetListaRubrosMultiples(stb, rubros, "P")
         GetListaSubRubrosMultiples(stb, subrubros, "P")
         GetListaSubSubRubrosMultiples(stb, subSubRubros, "P")

         If Not String.IsNullOrEmpty(idProducto) Then
            .AppendFormatLine("	AND VP.IdProducto = '{0}'", idProducto)
         End If

         If Not String.IsNullOrEmpty(idZonaGeografica) Then
            .AppendFormatLine("   AND ZG.IdZonaGeografica = '{0}'", idZonaGeografica)
         End If

         If idLocalidad > 0 Then
            .AppendFormatLine("   AND C.IdLocalidad = {0}", idLocalidad)
         End If

         'Se creo el IX_Ventas_Fecha para mejorar (notablemente) el tiempo de la consulta
         ''Le quito la hora, por aquellos comprobantes que puedo hacer con fecha atrasada, los ordenaria distinto
         '.AppendLine("ORDER BY CONVERT(varchar(11), V.fecha, 120),")
         '.AppendLine("         TC.DescripcionAbrev,")
         '.AppendLine("         V.Letra,")
         '.AppendLine("         V.CentroEmisor,")
         '.AppendLine("         V.NumeroComprobante")

         .AppendLine("	ORDER BY V.Fecha")
      End With
      Return GetDataTable(stb)
   End Function
#End Region
End Class