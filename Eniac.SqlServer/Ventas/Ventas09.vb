Partial Class Ventas
#Region "Get Utilidades"
   Public Function GetUtilidadesPor(xTipo As Entidades.Venta.TipoUtilidad,
                                    sucursales As Entidades.Sucursal(),
                                    agruparSucursales As Boolean,
                                    desde As Date,
                                    hasta As Date,
                                    nivelAutorizacion As Short,
                                    IdVendedor As Integer,
                                    idRubro As Integer,
                                    idSubrubro As Integer,
                                    idCliente As Long,
                                    idProducto As String,
                                    idZonaGeografica As String,
                                    idLocalidad As Integer,
                                    idListaDePrecios As Integer,
                                    idMarca As Integer,
                                    mostrarProveedorHabitual As Boolean,
                                    idProveedorHabitual As Long,
                                    esComercial As Entidades.Publicos.SiNoTodos,
                                    listaComprobantes As List(Of Entidades.TipoComprobante),
                                    grabaLibro As String,
                                    grupos As Entidades.Grupo()) As DataTable
      'oCategoriaFiscalEmpresa As Entidades.CategoriaFiscal) As DataTable

      Dim stb = New StringBuilder()

      With stb
         If xTipo = Entidades.Venta.TipoUtilidad.MARCA Then
            .AppendLine("SELECT M.IdMarca ")
            .AppendLine("      ,M.NombreMarca")
         ElseIf xTipo = Entidades.Venta.TipoUtilidad.RUBRO Then
            .AppendLine("SELECT R.IdRubro ")
            .AppendLine("      ,R.NombreRubro")
         ElseIf xTipo = Entidades.Venta.TipoUtilidad.PRODUCTO Then
            .AppendLine("SELECT VP.IdProducto")
            .AppendLine("      ,VP.NombreProducto")
            .AppendLine("      ,PS.Stock")
         ElseIf xTipo = Entidades.Venta.TipoUtilidad.CLIENTE Then
            .AppendLine("SELECT C.IdCliente")
            .AppendLine("      ,C.CodigoCliente")
            .AppendLine("      ,C.NombreCliente")
         ElseIf xTipo = Entidades.Venta.TipoUtilidad.LISTAPRECIOS Then
            .AppendLine("SELECT VP.IdListaPrecios")
            .AppendLine("      ,VP.NombreListaPrecios")
         End If

         If Not agruparSucursales Then
            .AppendLine("      ,V.IdSucursal")
         Else
            .AppendLine("      ,0 AS IdSucursal") ' Se ingresa cero porque se necesita el dato en la Grilla
         End If

         'Valores Sin Impuestos
         .AppendLine("      ,SUM((VP.Costo * VP.Cantidad)) AS Costo ")
         .AppendLine("      ,SUM(VP.Cantidad) AS Cantidad")
         .AppendLine("      ,SUM(VP.ImporteTotalNeto) AS Total ")
         .AppendLine("      ,SUM(VP.Utilidad) AS Utilidad ")
         .AppendLine("      ,SUM(VP.ImporteTotalNeto + VP.ImporteImpuesto + VP.ImporteImpuestoInterno) AS TotalConImpuestos ")

         .AppendFormat("      ,SUM(({0} * VP.Cantidad)) AS CostoConImpuestos ",
               CalculosImpositivos.ObtenerPrecioConImpuestos("VP.Costo", "VP.AlicuotaImpuesto",
                                                            "VP.PorcImpuestoInterno",
                                                            "P.ImporteImpuestoInterno", "VP.OrigenPorcImpInt")).AppendLine()
         .AppendFormat("      ,SUM({0}) AS UtilidadConImpuestos",
                     CalculosImpositivos.ObtenerPrecioConImpuestos("VP.Utilidad", "VP.AlicuotaImpuesto",
                                                                  "VP.PorcImpuestoInterno",
                                                                  "P.ImporteImpuestoInterno", "VP.OrigenPorcImpInt")).AppendLine()

         'Valores con Impuestos
         If mostrarProveedorHabitual Then
            '.AppendLine("      ,PR.CodigoProveedor As CodigoProveedorHabitual")
            .AppendLine("      ,PR.NombreProveedor As NombreProveedorHabitual")
         End If


         .AppendLine("    FROM Ventas V")
         .AppendLine("   INNER JOIN TiposComprobantes TC ON TC.IdTipoComprobante = V.IdTipoComprobante")
         .AppendLine("   INNER JOIN VentasProductos VP ON VP.IdSucursal = V.IdSucursal")
         .AppendLine("                                AND VP.IdTipoComprobante = V.IdTipoComprobante")
         .AppendLine("                                AND VP.Letra = V.Letra")
         .AppendLine("                                AND VP.CentroEmisor = V.CentroEmisor")
         .AppendLine("                                AND VP.NumeroComprobante = V.NumeroComprobante")
         .AppendLine("   INNER JOIN Productos P ON P.IdProducto = VP.IdProducto")
         .AppendLine("   INNER JOIN Clientes C ON C.IdCliente = V.IdCliente")
         .AppendLine("   INNER JOIN Categorias CA ON CA.IdCategoria = C.IdCategoria")


         'If idProveedorHabitual > 0 Then
         '   .AppendLine("	LEFT JOIN ProductosProveedores PP On PP.IdProducto=P.IdProducto ")
         'End If
         If mostrarProveedorHabitual Then
            'If idProveedorHabitual = 0 Then
            '   .AppendLine("	LEFT JOIN ProductosProveedores PP On PP.IdProducto=P.IdProducto ")
            'End If
            .AppendLine("	LEFT JOIN Proveedores PR ON PR.IdProveedor = P.IdProveedor")
         End If

         If xTipo = Entidades.Venta.TipoUtilidad.MARCA Then
            .AppendLine("   INNER JOIN Marcas M ON M.IdMarca = P.IdMarca")
         ElseIf xTipo = Entidades.Venta.TipoUtilidad.RUBRO Then
            .AppendLine("   INNER JOIN Rubros R ON R.IdRubro = P.IdRubro")
         ElseIf xTipo = Entidades.Venta.TipoUtilidad.CLIENTE Then

         ElseIf xTipo = Entidades.Venta.TipoUtilidad.LISTAPRECIOS Then
            'Tomo el valor que tiene en VentasProductos por si se dio de baja la Lista de Precios.
            '.AppendLine("   INNER JOIN ListasDePrecios LP ON LP.IdListaPrecios = VP.IdListaPrecios")
         ElseIf xTipo = Entidades.Venta.TipoUtilidad.PRODUCTO Then
            .AppendLine("   LEFT JOIN ProductosSucursales PS ON PS.IdProducto = VP.IdProducto and PS.IdSucursal = VP.IdSucursal")
         End If


         .AppendLine(" WHERE TC.AfectaCaja = 'True' ")    'Contemplo solo aquellos comprobantes que manejan dinero

         .AppendLine("   AND TC.EsComercial = 'True' ")   'Contemplo solo aquellos comprobantes que son reales (excluyo la ND por Cheq. Rechazado)

         NivelAutorizacionClienteTipoComprobante(stb, "C", "CA", "TC", nivelAutorizacion)

         GetListaSucursalesMultiples(stb, sucursales, "V")
         .AppendFormat("   AND V.fecha >= '{0}'", ObtenerFecha(desde, False)).AppendLine()
         .AppendFormat("   AND V.fecha <= '{0}'", ObtenerFecha(hasta.Date.AddDays(1).AddSeconds(-1), True)).AppendLine()

         If IdVendedor > 0 Then
            .AppendLine("	AND V.IdVendedor = " & IdVendedor)
         End If

         If idRubro > 0 Then
            .AppendLine("   AND P.IdRubro = " & idRubro.ToString())
         End If

         If idSubrubro > 0 Then
            .AppendLine("   AND P.IdSubRubro = " & idSubrubro.ToString())
         End If

         If esComercial <> Entidades.Publicos.SiNoTodos.TODOS Then
            .AppendFormatLine("   AND P.EsComercial = '{0}'", If(esComercial = Entidades.Publicos.SiNoTodos.SI, "True", "False"))
         End If

         If idCliente <> 0 Then
            .AppendLine("	AND V.IdCliente = " & idCliente)
         End If

         If Not String.IsNullOrEmpty(idZonaGeografica) Then
            .AppendFormat(" AND C.IdZonaGeografica = '{0}'", idZonaGeografica)
         End If

         If idLocalidad > 0 Then
            .AppendLine(" AND C.IdLocalidad = " & idLocalidad.ToString())
         End If

         If Not String.IsNullOrWhiteSpace(idProducto) Then
            .AppendFormat("	AND VP.IdProducto = '{0}'", idProducto).AppendLine()
         End If

         If idListaDePrecios > -1 Then
            .AppendFormatLine("	AND VP.IdListaPrecios = {0}", idListaDePrecios)
         End If

         If idMarca > 0 Then
            .AppendFormatLine("   AND P.IdMarca = {0}", idMarca.ToString())
         End If

         If idProveedorHabitual > 0 Then
            .AppendLine("   AND P.IdProveedor = " & idProveedorHabitual.ToString())
         End If
         'If mostrarProveedorHabitual Then
         '   .AppendLine("   AND PP.IdProducto = P.IdProducto AND PP.IdProveedor=PR.IdProveedor")
         'End If

         If listaComprobantes IsNot Nothing Then
            If listaComprobantes.Count > 0 Then
               .Append(" AND V.IdTipoComprobante IN (")
               For Each tc As Entidades.TipoComprobante In listaComprobantes
                  If tc IsNot Nothing Then
                     .AppendFormat(" '{0}',", tc.IdTipoComprobante)
                  End If
               Next
               .Remove(.Length - 1, 1)
               .Append(")")
            End If
         End If
         If grabaLibro <> "TODOS" Then
            .AppendLine("  AND TC.GrabaLibro = " & IIf(grabaLibro = "SI", "1", "0").ToString())
         End If

         GetListaMultiples(stb, grupos, "TC")

         If xTipo = Entidades.Venta.TipoUtilidad.MARCA Then
            .AppendLine(" GROUP BY M.IdMarca, M.NombreMarca ")
         ElseIf xTipo = Entidades.Venta.TipoUtilidad.RUBRO Then
            .AppendLine(" GROUP BY R.IdRubro, R.NombreRubro  ")
         ElseIf xTipo = Entidades.Venta.TipoUtilidad.PRODUCTO Then
            .AppendLine(" GROUP BY VP.IdProducto, VP.NombreProducto  ")
            .AppendLine(" ,PS.Stock")
         ElseIf xTipo = Entidades.Venta.TipoUtilidad.CLIENTE Then
            .AppendLine(" GROUP BY C.IdCliente, C.CodigoCliente, C.NombreCliente ")
         ElseIf xTipo = Entidades.Venta.TipoUtilidad.LISTAPRECIOS Then
            .AppendLine(" GROUP BY VP.IdListaPrecios,VP.NombreListaPrecios")
         End If

         If Not agruparSucursales Then
            .AppendLine(", V.IdSucursal")
         End If
         If mostrarProveedorHabitual Then
            .AppendLine(" ,PR.NombreProveedor")
         End If

         .AppendLine(" ORDER BY Utilidad DESC")
      End With

      Return GetDataTable(stb.ToString())

   End Function
#End Region

#Region "Get Comisiones"

   Public Function GetComisionesTotalesClientesPorVendedor(Sucursales As Entidades.Sucursal(),
                                                           Desde As Date,
                                                           Hasta As Date,
                                                           ConComision As String,
                                                           UnificarMarcas As Boolean,
                                                           oCategoriaFiscalEmpresa As Entidades.CategoriaFiscal,
                                                           strCalculoComisionVendedor As String,
                                                           comisionVendedor As String,
                                                           IdVendedor As Integer,
                                                           IdCliente As Long,
                                                           IdMarca As Integer,
                                                           IdRubro As Integer,
                                                           IdSubrubro As Integer,
                                                           idZonaGeografica As String,
                                                           ConIva As Boolean,
                                                           listaComprobantes As List(Of Entidades.TipoComprobante),
                                                           grabaLibro As String,
                                                           grupo As String) As DataTable



      Dim QueSuma As String
      If oCategoriaFiscalEmpresa.IvaDiscriminado Then
         If ConIva Then
            QueSuma = "(VP.ImporteTotalNeto+VP.ImporteImpuesto)"
         Else
            QueSuma = "VP.ImporteTotalNeto"
         End If

      Else
         QueSuma = "(VP.ImporteTotalNeto+VP.ImporteImpuesto)"
      End If

      Dim stb = New StringBuilder()

      With stb
         .Length = 0
         .AppendLine("SELECT")
         .AppendLine("     IdEmpleado, NombreEmpleado, CodigoCliente,  NombreCliente, NombreZonaGeografica, NombreLocalidad, NombreProvincia,")

         If Not UnificarMarcas Then
            .AppendLine("    IdSucursal,")
         Else
            .AppendLine("     0 AS IdSucursal,")
         End If

         .AppendLine("    SUM(TotalContado) AS TotalContado,")
         .AppendLine("    SUM(TotalCtaCte) AS TotalCtaCte,")
         .AppendLine("    SUM(TotalContado+TotalCtaCte) AS Total,")
         .AppendLine("    SUM(ComisionContado+ComisionCtaCte) AS Comision")
         .AppendLine(" FROM")
         .AppendLine("(")
         .AppendLine("SELECT")
         .AppendLine("      E.IdEmpleado, E.NombreEmpleado, C.CodigoCliente, V.NombreCliente, ZG.NombreZonaGeografica, L.NombreLocalidad, PRO.NombreProvincia,  ")

         If Not UnificarMarcas Then
            .AppendLine("       V.IdSucursal,")
         End If


         .AppendFormatLine("       SUM(CASE VFP.Dias WHEN 0 Then {0} ELSE 0 END) TotalContado,", QueSuma)
         .AppendFormatLine("       SUM(CASE VFP.Dias WHEN 0 Then 0 ELSE {0} END) TotalCtaCte,", QueSuma)


         '----------------------------------------------------------------------------------------
         If strCalculoComisionVendedor = "FACTURACION" Then
            .AppendLine("           SUM(ROUND(CASE WHEN VFP.Dias = 0 THEN VP.ComisionVendedor ELSE 0 END, 2)) ComisionContado,")
         Else  'LISTADO
            .AppendFormatLine("       SUM(ROUND(")
            Ayudante.Comisiones.Calculo(String.Format("CASE WHEN VFP.Dias = 0 THEN {0} ELSE 0 END", QueSuma), "E", "ECP", "ECPP", "R", "ECR", "ECRP", "ECSR", "ECSSR", "M", "ECM", "ECMP", "P", comisionVendedor, stb)
            .AppendFormatLine("              , 2)) ComisionContado,")
         End If

         '-----------------------------------------------------------------------------------------
         If strCalculoComisionVendedor = "FACTURACION" Then
            .AppendLine("           SUM(ROUND(CASE WHEN VFP.Dias = 0 THEN 0 ELSE VP.ComisionVendedor END, 2)) ComisionCtaCte")
         Else  'LISTADO
            .AppendFormatLine("       SUM(ROUND(")
            Ayudante.Comisiones.Calculo(String.Format("CASE WHEN VFP.Dias = 0 THEN 0 ELSE {0} END", QueSuma), "E", "ECP", "ECPP", "R", "ECR", "ECRP", "ECSR", "ECSSR", "M", "ECM", "ECMP", "P", comisionVendedor, stb)
            .AppendFormatLine("              , 2)) ComisionCtaCte")
         End If




         '.AppendLine("       CASE VFP.Dias")
         '.AppendLine("           WHEN 0 Then SUM(" & QueSuma & ")")
         '.AppendLine("           ELSE 0")
         '.AppendLine("       END TotalContado,")
         '.AppendLine("       CASE VFP.Dias")
         '.AppendLine("           WHEN 0 Then 0")
         '.AppendLine("           ELSE SUM(" & QueSuma & ")")
         '.AppendLine("       END TotalCtaCte,")

         '.AppendLine("       CASE VFP.Dias")
         'If strCalculoComisionVendedor = "FACTURACION" Then
         '   .AppendLine("           WHEN 0 Then ROUND(SUM(VP.ComisionVendedor),2)")
         'Else  'LISTADO
         '   .AppendLine("           WHEN 0 Then CASE WHEN E.ComisionPorVenta <> 0 then ROUND(SUM(" & QueSuma & "*E.ComisionPorVenta/100),2) Else")

         '   If comisionVendedor = "VENDEDORRUBROMARCA" Then
         '      .AppendLine(" CASE WHEN R.ComisionPorVenta <> 0 THEN 0 ELSE ROUND(SUM(" & QueSuma & " * M.ComisionPorVenta / 100), 2) END END")
         '   Else
         '      .AppendLine(" CASE WHEN M.ComisionPorVenta <> 0 THEN ROUND(SUM(" & QueSuma & " * M.ComisionPorVenta / 100), 2) ELSE 0 END END")
         '   End If
         '   '  .AppendLine("           WHEN 0 Then CASE WHEN E.ComisionPorVenta <> 0 then ROUND(SUM(" & QueSuma & "*E.ComisionPorVenta/100),2) Else ROUND(SUM(" & QueSuma & " * M.ComisionPorVenta / 100), 2)  END")

         'End If
         '.AppendLine("           ELSE 0")
         '.AppendLine("       END ComisionContado,")

         '.AppendLine("       CASE VFP.Dias")
         '.AppendLine("           WHEN 0 Then 0")

         'If strCalculoComisionVendedor = "FACTURACION" Then
         '   .AppendLine("           ELSE ROUND(SUM(VP.ComisionVendedor),2)")
         'Else  'LISTADO
         '   .AppendLine("           ELSE CASE WHEN E.ComisionPorVenta <> 0 then ROUND(SUM(" & QueSuma & "*E.ComisionPorVenta/100),2) Else")

         '   If comisionVendedor = "VENDEDORRUBROMARCA" Then
         '      .AppendLine(" CASE WHEN R.ComisionPorVenta <> 0 THEN 0 ELSE ROUND(SUM(" & QueSuma & " * M.ComisionPorVenta / 100), 2) END END")
         '   Else
         '      .AppendLine(" CASE WHEN M.ComisionPorVenta <> 0 THEN ROUND(SUM(" & QueSuma & " * M.ComisionPorVenta / 100), 2) ELSE 0 END END")
         '   End If
         '   '    .AppendLine("           ELSE CASE WHEN E.ComisionPorVenta <> 0 then ROUND(SUM(" & QueSuma & "*E.ComisionPorVenta/100),2) Else  
         '   'ROUND(SUM(" & QueSuma & " * M.ComisionPorVenta / 100), 2)  END")

         'End If
         '.AppendLine("       END ComisionCtaCte")

         .AppendLine("FROM Ventas V")
         .AppendLine(" INNER JOIN Empleados E ON V.IdVendedor = E.IdEmpleado ")
         .AppendLine(" INNER JOIN TiposComprobantes TC ON V.IdTipoComprobante = TC.IdTipoComprobante ")
         .AppendLine(" INNER JOIN VentasProductos VP ON V.IdSucursal=VP.IdSucursal ")
         .AppendLine("                            AND V.IdTipoComprobante=VP.IdTipoComprobante")
         .AppendLine("                            AND V.Letra=VP.Letra")
         .AppendLine("                            AND V.CentroEmisor=VP.CentroEmisor")
         .AppendLine("                            AND V.NumeroComprobante=VP.NumeroComprobante")
         .AppendLine(" INNER JOIN Productos P ON VP.IdProducto = P.IdProducto ")
         .AppendLine(" INNER JOIN Marcas M ON P.IdMarca = M.IdMarca ")
         .AppendLine(" INNER JOIN Rubros R ON P.IdRubro = R.IdRubro")
         .AppendLine(" INNER JOIN Clientes C ON V.IdCliente = C.IdCliente ")
         .AppendLine(" INNER JOIN ZonasGeograficas ZG ON C.IdZonaGeografica = ZG.IdZonaGeografica")
         .AppendLine(" INNER JOIN VentasFormasPago VFP ON V.IdFormasPago = VFP.IdFormasPago")
         .AppendLine(" INNER JOIN Localidades L ON C.IdLocalidad = L.IdLocalidad")
         .AppendLine(" INNER JOIN Provincias PRO ON PRO.IdProvincia = L.IdProvincia")

         .AppendLine("  LEFT JOIN EmpleadosComisionesMarcas ECM ON ECM.IdMarca = M.IdMarca AND ECM.IdEmpleado = E.IdEmpleado ")
         .AppendLine("  LEFT JOIN EmpleadosComisionesRubros ECR ON ECR.IdRubro = R.IdRubro AND ECR.IdEmpleado = E.IdEmpleado ")
         .AppendLine("  LEFT JOIN EmpleadosComisionesSubRubros ECSR ON ECSR.IdSubRubro = P.IdSubRubro AND ECSR.IdEmpleado = E.IdEmpleado ")
         .AppendLine("  LEFT JOIN EmpleadosComisionesSubSubRubros ECSSR ON ECSSR.IdSubSubRubro = P.IdSubSubRubro AND ECSSR.IdEmpleado = E.IdEmpleado ")
         .AppendLine("  LEFT JOIN EmpleadosComisionesProductos ECP ON ECP.IdProducto = P.IdProducto AND ECP.IdEmpleado = E.IdEmpleado ")
         .AppendLine("  LEFT JOIN EmpleadosComisionesProductosPrecios ECPP ON ECPP.IdProducto = P.IdProducto AND ECPP.IdEmpleado = E.IdEmpleado AND ECPP.IdListaPrecios = VP.IdListaPrecios")


         .AppendLine("  LEFT JOIN EmpleadosComisionesMarcasPrecios ECMP ON ECMP.IdMarca = M.IdMarca AND ECMP.IdEmpleado = E.IdEmpleado AND ECMP.IdListaPrecios = VP.IdListaPrecios")
         .AppendLine("  LEFT JOIN EmpleadosComisionesRubrosPrecios ECRP ON ECRP.IdRubro = R.IdRubro AND ECRP.IdEmpleado = E.IdEmpleado AND ECRP.IdListaPrecios = VP.IdListaPrecios")

         .AppendLine(" WHERE 1=1")
         GetListaSucursalesMultiples(stb, Sucursales, "V")

         .AppendLine("   AND V.Fecha >= '" & Desde.ToString("yyyyMMdd HH:mm:ss") & "'")
         .AppendLine("   AND V.Fecha <= '" & Hasta.ToString("yyyyMMdd HH:mm:ss") & "'")

         .AppendLine("   AND TC.AfectaCaja = 'True'")
         .AppendLine("   AND TC.EsComercial = 'True'")   'Con esto solo alcanzaria, pero por ahora dejamos ambos.

         'If ConComision = "SI" Then
         '   .AppendLine("     AND M.ComisionPorVenta > 0 ")
         'ElseIf ConComision = "NO" Then
         '   .AppendLine("     AND M.ComisionPorVenta = 0")
         'End If

         If strCalculoComisionVendedor = "FACTURACION" Then
            If ConComision = "SI" Then
               .AppendLine("     AND VP.ComisionVendedor <> 0 ")
            ElseIf ConComision = "NO" Then
               .AppendLine("     AND VP.ComisionVendedor = 0")
            End If
         Else  'LISTADO
            If ConComision = "SI" Then
               .AppendLine("     AND ")
               Ayudante.Comisiones.Calculo(QueSuma, "E", "ECP", "ECPP", "R", "ECR", "ECRP", "ECSR", "ECSSR", "M", "ECM", "ECMP", "P", comisionVendedor, stb)
               .AppendLine("                 <> 0 ")
            ElseIf ConComision = "NO" Then
               .AppendLine("     AND ")
               Ayudante.Comisiones.Calculo(QueSuma, "E", "ECP", "ECPP", "R", "ECR", "ECRP", "ECSR", "ECSSR", "M", "ECM", "ECMP", "P", comisionVendedor, stb)
               .AppendLine("                 = 0 ")
            End If
         End If

         'If strCalculoComisionVendedor = "FACTURACION" Then
         '   If ConComision = "SI" Then
         '      .AppendLine("     AND VP.ComisionVendedor <> 0 ")
         '   ElseIf ConComision = "NO" Then
         '      .AppendLine("     AND VP.ComisionVendedor = 0")
         '   End If
         'Else  'LISTADO

         '   If ConComision = "SI" Then
         '      .AppendLine("     AND CASE WHEN E.ComisionPorVenta <> 0 then ROUND(" & QueSuma & "*E.ComisionPorVenta/100,2) Else")
         '      If comisionVendedor = "VENDEDORRUBROMARCA" Then
         '         .AppendLine(" CASE WHEN R.ComisionPorVenta <> 0 THEN 0 ELSE ROUND(" & QueSuma & "*M.ComisionPorVenta/100,2) END END <> 0")
         '      Else
         '         .AppendLine(" CASE WHEN M.ComisionPorVenta <> 0 THEN ROUND(" & QueSuma & "*M.ComisionPorVenta/100,2) ELSE 0 END END <> 0")
         '      End If
         '   ElseIf ConComision = "NO" Then
         '      .AppendLine("     AND CASE WHEN E.ComisionPorVenta <> 0 then ROUND(" & QueSuma & "*E.ComisionPorVenta/100,2) Else")
         '      If comisionVendedor = "VENDEDORRUBROMARCA" Then
         '         .AppendLine(" CASE WHEN R.ComisionPorVenta <> 0 THEN 0 ELSE ROUND(" & QueSuma & "*M.ComisionPorVenta/100,2) END END = 0")
         '      Else
         '         .AppendLine(" CASE WHEN M.ComisionPorVenta <> 0 THEN ROUND(" & QueSuma & "*M.ComisionPorVenta/100,2) ELSE 0 END END = 0")
         '      End If
         '   End If
         '   'If ConComision = "SI" Then
         '   '    .AppendLine("     AND CASE WHEN E.ComisionPorVenta <> 0 then ROUND(" & QueSuma & "*E.ComisionPorVenta/100,2) Else  ROUND(" & QueSuma & " * M.ComisionPorVenta / 100, 2)  END > 0 ")
         '   'ElseIf ConComision = "NO" Then
         '   '    .AppendLine("     AND CASE WHEN E.ComisionPorVenta <> 0 then ROUND(" & QueSuma & "*E.ComisionPorVenta/100,2) Else  ROUND(" & QueSuma & " * M.ComisionPorVenta / 100, 2)  END = 0")
         '   'End If
         'End If
         '---------------------------------------------------------------------------------------------------------

         If IdVendedor > 0 Then
            .AppendLine("	AND V.IdVendedor = " & IdVendedor)
         End If

         If IdCliente > 0 Then
            .AppendLine("	AND C.IdCliente = " & IdCliente.ToString())
         End If

         If IdMarca > 0 Then
            .AppendLine("   AND P.IdMarca = " & IdMarca.ToString())
         End If

         If IdRubro > 0 Then
            .AppendLine("   AND P.IdRubro = " & IdRubro.ToString())
         End If

         If IdSubrubro > 0 Then
            .AppendLine("   AND P.IdSubRubro = " & IdSubrubro.ToString())
         End If

         If Not String.IsNullOrEmpty(idZonaGeografica) Then
            .AppendFormat(" AND ZG.IdZonaGeografica = '{0}'", idZonaGeografica)
         End If

         If listaComprobantes.Count > 0 Then

            .Append(" AND V.IdTipoComprobante IN (")
            For Each tc As Entidades.TipoComprobante In listaComprobantes
               If tc IsNot Nothing Then
                  .AppendFormat(" '{0}',", tc.IdTipoComprobante)
               End If
            Next
            .Remove(.Length - 1, 1)
            .Append(")")

         End If
         If grabaLibro <> "TODOS" Then
            .AppendLine("  AND TC.GrabaLibro = " & IIf(grabaLibro = "SI", "1", "0").ToString())
         End If

         If Not String.IsNullOrEmpty(grupo) Then
            .AppendLine("	AND TC.Grupo = '" & grupo & "'")
         End If

         .AppendLine(" GROUP BY E.IdEmpleado, E.NombreEmpleado, C.CodigoCliente, V.NombreCliente,  V.IdSucursal, ZG.NombreZonaGeografica, L.NombreLocalidad, PRO.NombreProvincia, VFP.Dias, E.ComisionPorVenta, M.ComisionPorVenta, R.ComisionPorVenta")
         .AppendLine(") Detalle")

         .AppendLine("GROUP BY IdEmpleado, NombreEmpleado, CodigoCliente,  NombreCliente, NombreZonaGeografica, NombreLocalidad, NombreProvincia")

         If Not UnificarMarcas Then
            .AppendLine(", IdSucursal")
         End If

         .AppendLine(" ORDER BY NombreEmpleado, NombreCliente, Comision  DESC, Total DESC")
      End With

      Return Me.GetDataTable(stb.ToString())

   End Function

   Public Function GetComprobantesTotalesClientesPorVendedor(sucursales As Entidades.Sucursal(),
                                                             fechaDesde As Date,
                                                             fechaHasta As Date,
                                                             idVendedor As Integer,
                                                             oCategoriaFiscalEmpresa As Entidades.CategoriaFiscal,
                                                             ConIva As Boolean,
                                                             strCalculoComisionVendedor As String,
                                                             comisionVendedor As String,
                                                             conComision As String,
                                                             idCliente As Long,
                                                             idMarca As Integer,
                                                             idRubro As Integer,
                                                             idSubRubro As Integer,
                                                             idZonaGeografica As String,
                                                             listaComprobantes As List(Of Entidades.TipoComprobante),
                                                             grabaLibro As String,
                                                             grupo As String) As DataTable

      Dim QueSuma As String
      If oCategoriaFiscalEmpresa.IvaDiscriminado Then
         If ConIva Then
            QueSuma = "(VP.ImporteTotalNeto+VP.ImporteImpuesto)"
         Else
            QueSuma = "VP.ImporteTotalNeto"
         End If

      Else
         QueSuma = "(VP.ImporteTotalNeto+VP.ImporteImpuesto)"
      End If

      Dim query As StringBuilder = New StringBuilder
      With query
         .AppendLine("        SELECT IdSucursal")
         .AppendLine(",Fecha ")
         .AppendLine(",IdTipoComprobante ")
         .AppendLine(",Letra ")
         .AppendLine(",CentroEmisor ")
         .AppendLine(",NumeroComprobante ")
         .AppendLine(",IdVendedor ")
         .AppendLine(",NombreEmpleado ")
         .AppendLine(",IdCliente ")
         .AppendLine(",CodigoCliente ")
         .AppendLine(",NombreCliente")
         .AppendLine(",SUM(ComisionContado + ComisionCtaCte) Comision")

         .AppendLine("FROM (")
         .AppendLine("SELECT")
         .AppendLine("       V.IdSucursal	")
         .AppendLine("      ,V.Fecha ")
         .AppendLine("      ,V.IdTipoComprobante ")
         .AppendLine("      ,V.Letra ")
         .AppendLine("      ,V.CentroEmisor ")
         .AppendLine("      ,V.NumeroComprobante ")
         .AppendLine("      ,V.IdVendedor ")
         .AppendLine("      ,E.NombreEmpleado ")
         .AppendLine("      ,V.IdCliente ")
         .AppendLine("      ,C.CodigoCliente ")
         .AppendLine("      ,C.NombreCliente,")

         .AppendLine("       CASE VFP.Dias")
         .AppendLine("           WHEN 0 Then SUM(" & QueSuma & ")")
         .AppendLine("           ELSE 0")
         .AppendLine("       END TotalContado,")
         .AppendLine("       CASE VFP.Dias")
         .AppendLine("           WHEN 0 Then 0")
         .AppendLine("           ELSE SUM(" & QueSuma & ")")
         .AppendLine("       END TotalCtaCte,")

         .AppendLine("       CASE VFP.Dias")
         If strCalculoComisionVendedor = "FACTURACION" Then
            .AppendLine("           WHEN 0 Then ROUND(SUM(VP.ComisionVendedor),2)")
         Else  'LISTADO
            .AppendLine("           WHEN 0 Then CASE WHEN E.ComisionPorVenta <> 0 then ROUND(SUM(" & QueSuma & "*E.ComisionPorVenta/100),2) Else")

            If comisionVendedor = "VENDEDORRUBROMARCA" Then
               .AppendLine(" CASE WHEN R.ComisionPorVenta <> 0 THEN 0 ELSE ROUND(SUM(" & QueSuma & " * M.ComisionPorVenta / 100), 2) END END")
            Else
               .AppendLine(" CASE WHEN M.ComisionPorVenta <> 0 THEN ROUND(SUM(" & QueSuma & " * M.ComisionPorVenta / 100), 2) ELSE 0 END END")
            End If

         End If
         .AppendLine("           ELSE 0")
         .AppendLine("       END ComisionContado,")

         .AppendLine("       CASE VFP.Dias")
         .AppendLine("           WHEN 0 Then 0")

         If strCalculoComisionVendedor = "FACTURACION" Then
            .AppendLine("           ELSE ROUND(SUM(VP.ComisionVendedor),2)")
         Else  'LISTADO
            .AppendLine("           ELSE CASE WHEN E.ComisionPorVenta <> 0 then ROUND(SUM(" & QueSuma & "*E.ComisionPorVenta/100),2) Else")

            If comisionVendedor = "VENDEDORRUBROMARCA" Then
               .AppendLine(" CASE WHEN R.ComisionPorVenta <> 0 THEN 0 ELSE ROUND(SUM(" & QueSuma & " * M.ComisionPorVenta / 100), 2) END END")
            Else
               .AppendLine(" CASE WHEN M.ComisionPorVenta <> 0 THEN ROUND(SUM(" & QueSuma & " * M.ComisionPorVenta / 100), 2) ELSE 0 END END")
            End If

         End If
         .AppendLine("       END ComisionCtaCte")

         .AppendLine("FROM Ventas V")
         .AppendLine("INNER JOIN Empleados E ON V.IdVendedor = E.IdEmpleado ")
         .AppendLine("INNER JOIN TiposComprobantes TC ON V.IdTipoComprobante = TC.IdTipoComprobante ")
         .AppendLine("INNER JOIN VentasProductos VP ON V.IdSucursal=VP.IdSucursal ")
         .AppendLine("                           AND V.IdTipoComprobante=VP.IdTipoComprobante")
         .AppendLine("                           AND V.Letra=VP.Letra")
         .AppendLine("                           AND V.CentroEmisor=VP.CentroEmisor")
         .AppendLine("                           AND V.NumeroComprobante=VP.NumeroComprobante")
         .AppendLine("INNER JOIN Productos P ON VP.IdProducto = P.IdProducto ")
         .AppendLine("INNER JOIN Marcas M ON P.IdMarca = M.IdMarca ")
         .AppendLine("INNER JOIN Rubros R ON P.IdRubro = R.IdRubro")
         .AppendLine("INNER JOIN Clientes C ON V.IdCliente = C.IdCliente ")
         .AppendLine("INNER JOIN ZonasGeograficas ZG ON C.IdZonaGeografica = ZG.IdZonaGeografica")
         .AppendLine("INNER JOIN VentasFormasPago VFP ON V.IdFormasPago = VFP.IdFormasPago")
         .AppendLine("INNER JOIN Localidades L ON C.IdLocalidad = L.IdLocalidad")
         .AppendLine("INNER JOIN Provincias PRO ON PRO.IdProvincia = L.IdProvincia")
         .AppendLine(" WHERE 1 = 1")

         GetListaSucursalesMultiples(query, sucursales, "V")

         .AppendLine("	   AND TC.AfectaCaja = 'True'")
         .AppendLine("	   AND TC.EsComercial = 'True'")

         .AppendFormatLine("     AND V.Fecha >= '{0}'", ObtenerFecha(fechaDesde, True))
         .AppendFormatLine("	   AND V.Fecha <= '{0}'", ObtenerFecha(fechaHasta, True))

         If strCalculoComisionVendedor = "FACTURACION" Then
            If conComision = "SI" Then
               .AppendLine("     AND VP.ComisionVendedor <> 0 ")
            ElseIf conComision = "NO" Then
               .AppendLine("     AND VP.ComisionVendedor = 0")
            End If
         Else  'LISTADO

            If conComision = "SI" Then
               .AppendLine("     AND CASE WHEN E.ComisionPorVenta <> 0 then ROUND(" & QueSuma & "*E.ComisionPorVenta/100,2) Else")
               If comisionVendedor = "VENDEDORRUBROMARCA" Then
                  .AppendLine(" CASE WHEN R.ComisionPorVenta <> 0 THEN 0 ELSE ROUND(" & QueSuma & "*M.ComisionPorVenta/100,2) END END <> 0")
               Else
                  .AppendLine(" CASE WHEN M.ComisionPorVenta <> 0 THEN ROUND(" & QueSuma & "*M.ComisionPorVenta/100,2) ELSE 0 END END <> 0")
               End If
            ElseIf conComision = "NO" Then
               .AppendLine("     AND CASE WHEN E.ComisionPorVenta <> 0 then ROUND(" & QueSuma & "*E.ComisionPorVenta/100,2) Else")
               If comisionVendedor = "VENDEDORRUBROMARCA" Then
                  .AppendLine(" CASE WHEN R.ComisionPorVenta <> 0 THEN 0 ELSE ROUND(" & QueSuma & "*M.ComisionPorVenta/100,2) END END = 0")
               Else
                  .AppendLine(" CASE WHEN M.ComisionPorVenta <> 0 THEN ROUND(" & QueSuma & "*M.ComisionPorVenta/100,2) ELSE 0 END END = 0")
               End If
            End If

         End If

         '###############################################
         '#                INICIO FILTROS               #
         '###############################################
         If idVendedor > 0 Then
            .AppendFormatLine("	AND V.IdVendedor = {0}", idVendedor)
         End If

         If idCliente > 0 Then
            .AppendFormatLine("	AND C.IdCliente = {0}", idCliente)
         End If

         If idMarca > 0 Then
            .AppendFormatLine("   AND P.IdMarca = {0}", idMarca)
         End If

         If idRubro > 0 Then
            .AppendFormatLine("   AND P.IdRubro = {0}", idRubro)
         End If

         If idSubRubro > 0 Then
            .AppendFormatLine("   AND P.IdSubRubro = {0}", idSubRubro)
         End If

         If Not String.IsNullOrEmpty(idZonaGeografica) Then
            .AppendFormat(" AND ZG.IdZonaGeografica = '{0}'", idZonaGeografica)
         End If

         If listaComprobantes.Count > 0 Then

            .Append(" AND V.IdTipoComprobante IN (")
            For Each tc As Entidades.TipoComprobante In listaComprobantes
               If tc IsNot Nothing Then
                  .AppendFormat(" '{0}',", tc.IdTipoComprobante)
               End If
            Next
            .Remove(.Length - 1, 1)
            .Append(")")

         End If
         If grabaLibro <> "TODOS" Then
            .AppendLine("  AND TC.GrabaLibro = " & IIf(grabaLibro = "SI", "1", "0").ToString())
         End If

         If Not String.IsNullOrEmpty(grupo) Then
            .AppendLine("	AND TC.Grupo = '" & grupo & "'")
         End If
         '###############################################
         '#                FIN FILTROS                  #
         '###############################################

         .AppendLine("GROUP BY V.IdSucursal, V.Fecha, V.IdTipoComprobante, V.Letra, V.CentroEmisor, V.NumeroComprobante, V.IdVendedor, E.NombreEmpleado, V.IdCliente")
         .AppendLine("		 , C.CodigoCliente, C.NombreCliente, E.NombreEmpleado, C.CodigoCliente, V.NombreCliente, L.NombreLocalidad")
         .AppendLine("		 , VFP.Dias, E.ComisionPorVenta, R.ComisionPorVenta, M.ComisionPorVenta) D")
         .AppendLine("   GROUP BY IdSucursal")
         .AppendLine(" ,Fecha ")
         .AppendLine(" ,IdTipoComprobante ")
         .AppendLine(" ,Letra ")
         .AppendLine(" ,CentroEmisor ")
         .AppendLine(" ,NumeroComprobante ")
         .AppendLine(" ,IdVendedor ")
         .AppendLine(" ,NombreEmpleado ")
         .AppendLine(" ,IdCliente ")
         .AppendLine(" ,CodigoCliente ")
         .AppendLine(" ,NombreCliente")
         .AppendLine(" ,NombreEmpleado")
         .AppendLine(" ,CodigoCliente")
         .AppendLine(" ,NombreCliente ")

      End With

      Return Me.GetDataTable(query.ToString())

   End Function

   Public Function GetComisionesTotalesPorVendedor(sucursales As Entidades.Sucursal(),
                                                   desde As Date,
                                                   hasta As Date,
                                                   conComision As String,
                                                   idCliente As Long,
                                                   idZonaGeografica As String,
                                                   afectaCaja As String,
                                                   conIVA As Boolean,
                                                   unificarComisiones As Boolean,
                                                   ivaDiscriminado As Boolean,
                                                   strCalculoComisionVendedor As String,
                                                   comisionVendedor As String,
                                                   activaObjetivo As Boolean,
                                                   listaComprobantes As IEnumerable(Of Entidades.TipoComprobante),
                                                   grabaLibro As String,
                                                   grupos As Entidades.Grupo(),
                                                   IdVendedor As Integer,
                                                   tipoVendedor As Entidades.OrigenFK) As DataTable
      Dim queSuma As String
      If ivaDiscriminado Then
         If conIVA Then
            queSuma = "(VP.ImporteTotalNeto+VP.ImporteImpuesto)"
         Else
            queSuma = "VP.ImporteTotalNeto"
         End If
      Else
         queSuma = "(VP.ImporteTotalNeto+VP.ImporteImpuesto)"
      End If

      Dim stb = New StringBuilder()
      With stb
         .AppendLine("SELECT")
         .AppendLine("    IdEmpleado as IdVendedor,")
         .AppendLine("    NombreEmpleado as NombreVendedor,")

         If Not unificarComisiones Then
            .AppendLine("    IdSucursal,")
         Else
            .AppendLine("    0 AS IdSucursal,") ' Se Pasa con Cero porque se necesita en la Grilla
         End If

         .AppendLine("    SUM(CantComprobantes) AS CantComprobantes,")
         .AppendLine("    SUM(CantItems) AS CantItems,")
         .AppendLine("    SUM(TotalContado) AS TotalContado,")
         .AppendLine("    SUM(TotalCtaCte) AS TotalCtaCte,")
         .AppendLine("    SUM(TotalContado+TotalCtaCte) AS Total,")
         .AppendLine("    SUM(ComisionContado+ComisionCtaCte) AS Comision")
         If activaObjetivo Then
            .AppendLine("   ,ISNULL(ImporteObjetivo, 0) AS ImporteObjetivo")
            .AppendLine("   ,CASE WHEN ImporteObjetivo IS NULL THEN 0 ELSE SUM(TotalContado+TotalCtaCte)/ImporteObjetivo*100 END AS PorcObjetivo")

         Else
            .AppendLine("   , 0 AS ImporteObjetivo")
            .AppendLine("   , 0 AS PorcObjetivo")
         End If

         .AppendLine(" FROM")
         .AppendLine("(")
         .AppendLine("SELECT")
         .AppendLine("       E.IdEmpleado,")
         .AppendLine("       E.NombreEmpleado,")

         If Not unificarComisiones Then
            .AppendLine("       V.IdSucursal,")
         End If

         .AppendFormatLine("       SUM(CASE VFP.Dias WHEN 0 Then {0} ELSE 0 END) TotalContado,", queSuma)
         .AppendFormatLine("       SUM(CASE VFP.Dias WHEN 0 Then 0 ELSE {0} END) TotalCtaCte,", queSuma)


         '----------------------------------------------------------------------------------------
         If strCalculoComisionVendedor = "FACTURACION" Then
            .AppendLine("           SUM(ROUND(CASE WHEN VFP.Dias = 0 THEN VP.ComisionVendedor ELSE 0 END, 2)) ComisionContado,")
         Else  'LISTADO
            .AppendFormatLine("       SUM(ROUND(")
            Ayudante.Comisiones.Calculo(String.Format("CASE WHEN VFP.Dias = 0 THEN {0} ELSE 0 END", queSuma), "E", "ECP", "ECPP", "R", "ECR", "ECRP", "ECSR", "ECSSR", "M", "ECM", "ECMP", "P", comisionVendedor, stb)
            .AppendFormatLine("              , 2)) ComisionContado,")
         End If

         '-----------------------------------------------------------------------------------------
         If strCalculoComisionVendedor = "FACTURACION" Then
            .AppendLine("           SUM(ROUND(CASE WHEN VFP.Dias = 0 THEN 0 ELSE VP.ComisionVendedor END, 2)) ComisionCtaCte,")
         Else  'LISTADO
            .AppendFormatLine("       SUM(ROUND(")
            Ayudante.Comisiones.Calculo(String.Format("CASE WHEN VFP.Dias = 0 THEN 0 ELSE {0} END", queSuma), "E", "ECP", "ECPP", "R", "ECR", "ECRP", "ECSR", "ECSSR", "M", "ECM", "ECMP", "P", comisionVendedor, stb)
            .AppendFormatLine("              , 2)) ComisionCtaCte,")
         End If


         .AppendLine("       COUNT(*) AS CantItems")
         If activaObjetivo Then
            .AppendLine("       , EO.ImporteObjetivo")
         End If

         .AppendLine("    FROM Ventas V")
         .AppendLine("   INNER JOIN Clientes C ON V.IdCliente = C.IdCliente")
         .AppendFormatLine("   INNER JOIN Empleados E ON {0}.IdVendedor = E.IdEmpleado ", If(tipoVendedor = Entidades.OrigenFK.Movimiento, "V", "C"))
         .AppendLine("   INNER JOIN TiposComprobantes TC ON V.IdTipoComprobante = TC.IdTipoComprobante ")
         .AppendLine("   INNER JOIN VentasProductos VP ON V.IdSucursal=VP.IdSucursal ")
         .AppendLine("                              AND V.IdTipoComprobante=VP.IdTipoComprobante")
         .AppendLine("                              AND V.Letra=VP.Letra")
         .AppendLine("                              AND V.CentroEmisor=VP.CentroEmisor")
         .AppendLine("                              AND V.NumeroComprobante=VP.NumeroComprobante")
         .AppendLine("   INNER JOIN Productos P ON VP.IdProducto = P.IdProducto ")
         .AppendLine("   INNER JOIN Marcas M ON P.IdMarca = M.IdMarca ")
         .AppendLine("   INNER JOIN Rubros R ON P.IdRubro = R.IdRubro")
         .AppendLine("   INNER JOIN ZonasGeograficas ZG ON C.IdZonaGeografica = ZG.IdZonaGeografica")
         .AppendLine("   INNER JOIN VentasFormasPago VFP ON V.IdFormasPago = VFP.IdFormasPago")

         .AppendLine("  LEFT JOIN EmpleadosComisionesMarcas ECM ON ECM.IdMarca = M.IdMarca AND ECM.IdEmpleado = E.IdEmpleado ")
         .AppendLine("  LEFT JOIN EmpleadosComisionesRubros ECR ON ECR.IdRubro = R.IdRubro AND ECR.IdEmpleado = E.IdEmpleado ")
         .AppendLine("  LEFT JOIN EmpleadosComisionesSubRubros ECSR ON ECSR.IdSubRubro = P.IdSubRubro AND ECSR.IdEmpleado = E.IdEmpleado ")
         .AppendLine("  LEFT JOIN EmpleadosComisionesSubSubRubros ECSSR ON ECSSR.IdSubSubRubro = P.IdSubSubRubro AND ECSSR.IdEmpleado = E.IdEmpleado ")
         .AppendLine("  LEFT JOIN EmpleadosComisionesProductos ECP ON ECP.IdProducto = P.IdProducto AND ECP.IdEmpleado = E.IdEmpleado ")
         .AppendLine("  LEFT JOIN EmpleadosComisionesProductosPrecios ECPP ON ECPP.IdProducto = P.IdProducto AND ECPP.IdEmpleado = E.IdEmpleado AND ECPP.IdListaPrecios = VP.IdListaPrecios")


         If activaObjetivo Then
            Dim periodo As Integer = Integer.Parse(desde.ToString("yyyyMM"))
            .AppendFormatLine("   LEFT JOIN EmpleadosObjetivos EO ON  EO.IdEmpleado = E.IdEmpleado AND EO.PeriodoFiscal = '{0}'", periodo)
         End If

         .AppendLine("  LEFT JOIN EmpleadosComisionesMarcasPrecios ECMP ON ECMP.IdMarca = M.IdMarca AND ECMP.IdEmpleado = E.IdEmpleado AND ECMP.IdListaPrecios = VP.IdListaPrecios")
         .AppendLine("  LEFT JOIN EmpleadosComisionesRubrosPrecios ECRP ON ECRP.IdRubro = R.IdRubro AND ECRP.IdEmpleado = E.IdEmpleado AND ECRP.IdListaPrecios = VP.IdListaPrecios")

         .AppendLine("   WHERE 1=1")
         SqlServer.Comunes.GetListaSucursalesMultiples(stb, sucursales, "V")
         .AppendFormatLine("     AND V.Fecha >= '{0}'", ObtenerFecha(desde, True))
         .AppendFormatLine("     AND V.Fecha <= '{0}'", ObtenerFecha(hasta, True))

         If afectaCaja = "SI" Then
            .AppendLine("     AND TC.AfectaCaja = 'True'")
            .AppendLine("     AND TC.EsComercial = 'True'")   'Con esto solo alcanzaria, pero por ahora dejamos ambos.
         ElseIf afectaCaja = "NO" Then
            .AppendLine("     AND TC.AfectaCaja = 'False'")
         End If

         If strCalculoComisionVendedor = "FACTURACION" Then
            If conComision = "SI" Then
               .AppendLine("     AND VP.ComisionVendedor <> 0 ")
            ElseIf conComision = "NO" Then
               .AppendLine("     AND VP.ComisionVendedor = 0")
            End If
         Else  'LISTADO
            If conComision = "SI" Then
               .AppendLine("     AND ")
               Ayudante.Comisiones.Calculo(queSuma, "E", "ECP", "ECPP", "R", "ECR", "ECRP", "ECSR", "ECSSR", "M", "ECM", "ECMP", "P", comisionVendedor, stb)
               .AppendLine("                 <> 0 ")
            ElseIf conComision = "NO" Then
               .AppendLine("     AND ")
               Ayudante.Comisiones.Calculo(queSuma, "E", "ECP", "ECPP", "R", "ECR", "ECRP", "ECSR", "ECSSR", "M", "ECM", "ECMP", "P", comisionVendedor, stb)
               .AppendLine("                 = 0 ")
            End If

            ''If conComision = "SI" Then
            ''   .AppendLine("     AND CASE WHEN E.ComisionPorVenta <> 0 then ROUND(" & queSuma & "*E.ComisionPorVenta/100,2) Else")
            ''   If comisionVendedor = "VENDEDORRUBROMARCA" Then
            ''      .AppendLine(" CASE WHEN R.ComisionPorVenta <> 0 THEN ROUND(" & queSuma & "*R.ComisionPorVenta/100,2) ELSE ROUND(" & queSuma & "*M.ComisionPorVenta/100,2) END END <> 0")
            ''   Else
            ''      .AppendLine(" CASE WHEN M.ComisionPorVenta <> 0 THEN ROUND(" & queSuma & "*M.ComisionPorVenta/100,2) ELSE ROUND(" & queSuma & "*R.ComisionPorVenta/100,2) END END <> 0")
            ''   End If
            ''ElseIf conComision = "NO" Then
            ''   .AppendLine("     AND CASE WHEN E.ComisionPorVenta <> 0 then ROUND(" & queSuma & "*E.ComisionPorVenta/100,2) Else")
            ''   If comisionVendedor = "VENDEDORRUBROMARCA" Then
            ''      .AppendLine(" CASE WHEN R.ComisionPorVenta <> 0 THEN ROUND(" & queSuma & "*R.ComisionPorVenta/100,2) ELSE ROUND(" & queSuma & "*M.ComisionPorVenta/100,2) END END = 0")
            ''   Else
            ''      .AppendLine(" CASE WHEN M.ComisionPorVenta <> 0 THEN ROUND(" & queSuma & "*M.ComisionPorVenta/100,2) ELSE ROUND(" & queSuma & "*R.ComisionPorVenta/100,2) END END = 0")
            ''   End If
            ''End If

            'If ConComision = "SI" Then
            '    .AppendLine("     AND CASE WHEN E.ComisionPorVenta <> 0 then ROUND(" & QueSuma & "*E.ComisionPorVenta/100,2) Else  ROUND(" & QueSuma & " * M.ComisionPorVenta / 100, 2)  END > 0 ")
            'ElseIf ConComision = "NO" Then
            '    .AppendLine("     AND CASE WHEN E.ComisionPorVenta <> 0 then ROUND(" & QueSuma & "*E.ComisionPorVenta/100,2) Else  ROUND(" & QueSuma & " * M.ComisionPorVenta / 100, 2)  END = 0")
            'End If
         End If
         '---------------------------------------------------------------------------------------------------------

         If idCliente > 0 Then
            .AppendLine("     AND C.IdCliente = " & idCliente.ToString())
         End If

         If IdVendedor > 0 Then
            .AppendFormatLine("	AND {0}.IdVendedor = {1}", If(tipoVendedor = Entidades.OrigenFK.Movimiento, "V", "C"), IdVendedor)
         End If

         If Not String.IsNullOrEmpty(idZonaGeografica) Then
            .AppendFormat("     AND ZG.IdZonaGeografica = '{0}'", idZonaGeografica)
         End If

         If listaComprobantes.Count > 0 Then

            .Append(" AND V.IdTipoComprobante IN (")
            For Each tc As Entidades.TipoComprobante In listaComprobantes
               If tc IsNot Nothing Then
                  .AppendFormat(" '{0}',", tc.IdTipoComprobante)
               End If
            Next
            .Remove(.Length - 1, 1)
            .Append(")")

         End If
         If grabaLibro <> "TODOS" Then
            .AppendLine("  AND TC.GrabaLibro = " & IIf(grabaLibro = "SI", "1", "0").ToString())
         End If

         GetListaMultiples(stb, grupos, "TC")

         '.AppendLine("     GROUP BY E.IdEmpleado, E.NroDocEmpleado, E.NombreEmpleado, V.IdSucursal, V.IdFormasPago, VFP.Dias, E.ComisionPorVenta, R.ComisionPorVenta, M.ComisionPorVenta")
         .AppendLine("     GROUP BY E.IdEmpleado, E.NombreEmpleado, V.IdSucursal")
         If activaObjetivo Then
            .AppendLine("      , EO.ImporteObjetivo")
         End If
         .AppendLine(") Detalle,")
         .AppendLine("(")
         .AppendFormatLine("SELECT {0}.IdVendedor", If(tipoVendedor = Entidades.OrigenFK.Movimiento, "V", "C"))
         .AppendLine("      ,COUNT(*) AS CantComprobantes")
         .AppendLine("  FROM Ventas V")
         .AppendLine("   INNER JOIN Clientes C ON V.IdCliente = C.IdCliente ")
         .AppendFormatLine("   INNER JOIN Empleados E ON {0}.IdVendedor = E.IdEmpleado ", If(tipoVendedor = Entidades.OrigenFK.Movimiento, "V", "C"))
         .AppendFormat("   INNER JOIN TiposComprobantes TC ON V.IdTipoComprobante = TC.IdTipoComprobante ")
         'Por ahora el total de comprobantes es sin filtrar esto
         '.AppendLine("   INNER JOIN VentasProductos VP ON V.IdSucursal=VP.IdSucursal ")
         '.AppendLine("                              AND V.IdTipoComprobante=VP.IdTipoComprobante")
         '.AppendLine("                              AND V.Letra=VP.Letra")
         '.AppendLine("                              AND V.CentroEmisor=VP.CentroEmisor")
         '.AppendLine("                              AND V.NumeroComprobante=VP.NumeroComprobante")
         '.AppendLine("   INNER JOIN Productos P ON VP.IdProducto = P.IdProducto ")
         '.AppendLine("   INNER JOIN Marcas M ON P.IdMarca = M.IdMarca ")
         .AppendLine("   INNER JOIN ZonasGeograficas ZG ON C.IdZonaGeografica = ZG.IdZonaGeografica")
         .AppendLine("   WHERE 1=1")
         SqlServer.Comunes.GetListaSucursalesMultiples(stb, sucursales, "V")
         .AppendLine("     AND V.Fecha >= '" & desde.ToString("yyyyMMdd HH:mm:ss") & "'")
         .AppendLine("     AND V.Fecha <= '" & hasta.ToString("yyyyMMdd HH:mm:ss") & "'")

         If afectaCaja = "SI" Then
            .AppendLine("     AND TC.AfectaCaja = 'True'")
            .AppendLine("     AND TC.EsComercial = 'True'")   'Con esto solo alcanzaria, pero por ahora dejamos ambos.
         ElseIf afectaCaja = "NO" Then
            .AppendLine("     AND TC.AfectaCaja = 'False'")
         End If

         'If ConComision = "SI" Then
         '   .AppendLine("     AND M.ComisionPorVenta > 0 ")
         'ElseIf ConComision = "NO" Then
         '   .AppendLine("     AND M.ComisionPorVenta = 0")
         'End If

         If idCliente <> 0 Then
            .AppendLine("     AND C.IdCliente = " & idCliente)
         End If
         If Not String.IsNullOrEmpty(idZonaGeografica) Then
            .AppendFormat("     AND ZG.IdZonaGeografica = '{0}'", idZonaGeografica)
         End If

         If listaComprobantes.Count > 0 Then

            .Append(" AND V.IdTipoComprobante IN (")
            For Each tc As Entidades.TipoComprobante In listaComprobantes
               If tc IsNot Nothing Then
                  .AppendFormat(" '{0}',", tc.IdTipoComprobante)
               End If
            Next
            .Remove(.Length - 1, 1)
            .Append(")")

         End If
         If grabaLibro <> "TODOS" Then
            .AppendLine("  AND TC.GrabaLibro = " & IIf(grabaLibro = "SI", "1", "0").ToString())
         End If

         GetListaMultiples(stb, grupos, "TC")

         .AppendFormatLine(" GROUP BY {0}.IdVendedor", If(tipoVendedor = Entidades.OrigenFK.Movimiento, "V", "C"))
         .AppendLine(") DetCantComprob")
         .AppendLine(" WHERE Detalle.IdEmpleado = DetCantComprob.IdVendedor")
         .AppendLine(" GROUP BY IdEmpleado, NombreEmpleado")
         If activaObjetivo Then
            .AppendLine("      , ImporteObjetivo")
         End If
         If Not unificarComisiones Then
            .AppendLine(" ,IdSucursal")
         End If
         .AppendLine(" ORDER BY Comision DESC, Total DESC")
      End With

      Return GetDataTable(stb.ToString())

   End Function

   Public Function GetComisionesTotalesMarcasPorVendedor(sucursales As Entidades.Sucursal(),
                                                         desde As Date,
                                                         hasta As Date,
                                                         oCategoriaFiscalEmpresa As Entidades.CategoriaFiscal,
                                                         strCalculoComisionVendedor As String,
                                                         comisionVendedor As String,
                                                         conComision As String,
                                                         unificarMarcas As Boolean,
                                                         idVendedor As Integer,
                                                         idCliente As Long,
                                                         marcas As Entidades.Marca(),
                                                         rubros As Entidades.Rubro(),
                                                         subrubros As Entidades.SubRubro(),
                                                         idZonaGeografica As String,
                                                         conIva As Boolean,
                                                         listaComprobantes As List(Of Entidades.TipoComprobante),
                                                         grabaLibro As String,
                                                         grupo As String,
                                                         IdFormaPago As Integer,
                                                         IdListaPrecios As Integer) As DataTable

      Dim QueSuma As String
      If oCategoriaFiscalEmpresa.IvaDiscriminado Then
         If conIva Then
            QueSuma = "(VP.ImporteTotalNeto+VP.ImporteImpuesto)"
         Else
            QueSuma = "VP.ImporteTotalNeto"
         End If

      Else
         QueSuma = "(VP.ImporteTotalNeto+VP.ImporteImpuesto)"
      End If


      Dim stb = New StringBuilder()

      With stb
         .Length = 0
         .AppendLine("SELECT")
         .AppendLine("    IdMarca,")
         .AppendLine("    NombreMarca,")

         If Not unificarMarcas Then
            .AppendLine("    IdSucursal,")
         Else
            .AppendLine("     0 AS IdSucursal,")
         End If

         .AppendLine("    SUM(TotalContado) AS TotalContado,")
         .AppendLine("    SUM(TotalCtaCte) AS TotalCtaCte,")
         .AppendLine("    SUM(TotalContado+TotalCtaCte) AS Total,")
         .AppendLine("    SUM(ComisionContado+ComisionCtaCte) AS Comision")
         .AppendLine(" FROM")
         .AppendLine("(")
         .AppendLine("SELECT")
         .AppendLine("       M.IdMarca,")
         .AppendLine("       M.NombreMarca,")

         If Not unificarMarcas Then
            .AppendLine("       V.IdSucursal,")
         End If




         .AppendFormatLine("       SUM(CASE VFP.Dias WHEN 0 Then {0} ELSE 0 END) TotalContado,", QueSuma)
         .AppendFormatLine("       SUM(CASE VFP.Dias WHEN 0 Then 0 ELSE {0} END) TotalCtaCte,", QueSuma)


         '----------------------------------------------------------------------------------------
         If strCalculoComisionVendedor = "FACTURACION" Then
            .AppendLine("           SUM(ROUND(CASE WHEN VFP.Dias = 0 THEN VP.ComisionVendedor ELSE 0 END, 2)) ComisionContado,")
         Else  'LISTADO
            .AppendFormatLine("       SUM(ROUND(")
            Ayudante.Comisiones.Calculo(String.Format("CASE WHEN VFP.Dias = 0 THEN {0} ELSE 0 END", QueSuma), "E", "ECP", "ECPP", "R", "ECR", "ECRP", "ECSR", "ECSSR", "M", "ECM", "ECMP", "P", comisionVendedor, stb)
            .AppendFormatLine("              , 2)) ComisionContado,")
         End If

         '-----------------------------------------------------------------------------------------
         If strCalculoComisionVendedor = "FACTURACION" Then
            .AppendLine("           SUM(ROUND(CASE WHEN VFP.Dias = 0 THEN 0 ELSE VP.ComisionVendedor END, 2)) ComisionCtaCte")
         Else  'LISTADO
            .AppendFormatLine("       SUM(ROUND(")
            Ayudante.Comisiones.Calculo(String.Format("CASE WHEN VFP.Dias = 0 THEN 0 ELSE {0} END", QueSuma), "E", "ECP", "ECPP", "R", "ECR", "ECRP", "ECSR", "ECSSR", "M", "ECM", "ECMP", "P", comisionVendedor, stb)
            .AppendFormatLine("              , 2)) ComisionCtaCte")
         End If

         .AppendLine("  FROM Ventas V")
         .AppendLine(" INNER JOIN Empleados E ON V.IdVendedor = E.IdEmpleado ")
         .AppendLine(" INNER JOIN TiposComprobantes TC ON V.IdTipoComprobante = TC.IdTipoComprobante ")
         .AppendLine(" INNER JOIN VentasProductos VP ON V.IdSucursal=VP.IdSucursal ")
         .AppendLine("                            AND V.IdTipoComprobante=VP.IdTipoComprobante")
         .AppendLine("                            AND V.Letra=VP.Letra")
         .AppendLine("                            AND V.CentroEmisor=VP.CentroEmisor")
         .AppendLine("                            AND V.NumeroComprobante=VP.NumeroComprobante")
         .AppendLine(" INNER JOIN Productos P ON VP.IdProducto = P.IdProducto ")
         .AppendLine(" INNER JOIN Marcas M ON P.IdMarca = M.IdMarca ")
         .AppendLine(" INNER JOIN Rubros R ON P.IdRubro = R.IdRubro")
         .AppendLine(" INNER JOIN Clientes C ON V.IdCliente = C.IdCliente ")
         .AppendLine(" INNER JOIN ZonasGeograficas ZG ON C.IdZonaGeografica = ZG.IdZonaGeografica")
         .AppendLine(" INNER JOIN VentasFormasPago VFP ON V.IdFormasPago = VFP.IdFormasPago")


         .AppendLine("  LEFT JOIN EmpleadosComisionesMarcas ECM ON ECM.IdMarca = M.IdMarca AND ECM.IdEmpleado = E.IdEmpleado ")
         .AppendLine("  LEFT JOIN EmpleadosComisionesRubros ECR ON ECR.IdRubro = R.IdRubro AND ECR.IdEmpleado = E.IdEmpleado ")
         .AppendLine("  LEFT JOIN EmpleadosComisionesSubRubros ECSR ON ECSR.IdSubRubro = P.IdSubRubro AND ECSR.IdEmpleado = E.IdEmpleado ")
         .AppendLine("  LEFT JOIN EmpleadosComisionesSubSubRubros ECSSR ON ECSSR.IdSubSubRubro = P.IdSubSubRubro AND ECSSR.IdEmpleado = E.IdEmpleado ")
         .AppendLine("  LEFT JOIN EmpleadosComisionesProductos ECP ON ECP.IdProducto = P.IdProducto AND ECP.IdEmpleado = E.IdEmpleado ")
         .AppendLine("  LEFT JOIN EmpleadosComisionesProductosPrecios ECPP ON ECPP.IdProducto = P.IdProducto AND ECPP.IdEmpleado = E.IdEmpleado AND ECPP.IdListaPrecios = VP.IdListaPrecios")


         .AppendLine("  LEFT JOIN EmpleadosComisionesMarcasPrecios ECMP ON ECMP.IdMarca = M.IdMarca AND ECMP.IdEmpleado = E.IdEmpleado AND ECMP.IdListaPrecios = VP.IdListaPrecios")
         .AppendLine("  LEFT JOIN EmpleadosComisionesRubrosPrecios ECRP ON ECRP.IdRubro = R.IdRubro AND ECRP.IdEmpleado = E.IdEmpleado AND ECRP.IdListaPrecios = VP.IdListaPrecios")


         .AppendLine("   WHERE 1=1")
         GetListaSucursalesMultiples(stb, sucursales, "V")

         .AppendLine("   AND V.Fecha >= '" & desde.ToString("yyyyMMdd HH:mm:ss") & "'")
         .AppendLine("   AND V.Fecha <= '" & hasta.ToString("yyyyMMdd HH:mm:ss") & "'")

         .AppendLine("   AND TC.AfectaCaja = 'True'")
         .AppendLine("   AND TC.EsComercial = 'True'")   'Con esto solo alcanzaria, pero por ahora dejamos ambos.


         If strCalculoComisionVendedor = "FACTURACION" Then
            If conComision = "SI" Then
               .AppendLine("     AND VP.ComisionVendedor <> 0 ")
            ElseIf conComision = "NO" Then
               .AppendLine("     AND VP.ComisionVendedor = 0")
            End If
         Else  'LISTADO
            If conComision = "SI" Then
               .AppendLine("     AND ")
               Ayudante.Comisiones.Calculo(QueSuma, "E", "ECP", "ECPP", "R", "ECR", "ECRP", "ECSR", "ECSSR", "M", "ECM", "ECMP", "P", comisionVendedor, stb)
               .AppendLine("                 <> 0 ")
            ElseIf conComision = "NO" Then
               .AppendLine("     AND ")
               Ayudante.Comisiones.Calculo(QueSuma, "E", "ECP", "ECPP", "R", "ECR", "ECRP", "ECSR", "ECSSR", "M", "ECM", "ECMP", "P", comisionVendedor, stb)
               .AppendLine("                 = 0 ")
            End If
         End If

         '---------------------------------------------------------------------------------------------------------

         If idVendedor > 0 Then
            .AppendLine("	AND V.IdVendedor = " & idVendedor)
         End If

         If idCliente > 0 Then
            .AppendLine("	AND C.IdCliente = " & idCliente.ToString())
         End If

         GetListaMarcasMultiples(stb, marcas, "P")
         GetListaRubrosMultiples(stb, rubros, "P")
         GetListaSubRubrosMultiples(stb, subrubros, "P")
         'If idMarca > 0 Then
         '   .AppendLine("   AND P.IdMarca = " & idMarca.ToString())
         'End If

         'If idRubro > 0 Then
         '   .AppendLine("   AND P.IdRubro = " & idRubro.ToString())
         'End If

         'If idSubrubro > 0 Then
         '   .AppendLine("   AND P.IdSubRubro = " & idSubrubro.ToString())
         'End If

         If Not String.IsNullOrEmpty(idZonaGeografica) Then
            .AppendFormat(" AND ZG.IdZonaGeografica = '{0}'", idZonaGeografica)
         End If

         If listaComprobantes.Count > 0 Then

            .Append(" AND V.IdTipoComprobante IN (")
            For Each tc As Entidades.TipoComprobante In listaComprobantes
               If tc IsNot Nothing Then
                  .AppendFormat(" '{0}',", tc.IdTipoComprobante)
               End If
            Next
            .Remove(.Length - 1, 1)
            .Append(")")

         End If
         If grabaLibro <> "TODOS" Then
            .AppendLine("  AND TC.GrabaLibro = " & IIf(grabaLibro = "SI", "1", "0").ToString())
         End If

         If Not String.IsNullOrEmpty(grupo) Then
            .AppendLine("	AND TC.Grupo = '" & grupo & "'")
         End If

         If IdFormaPago > 0 Then
            .AppendLine("	AND V.IdFormasPago = " & IdFormaPago)
         End If

         If IdListaPrecios > 0 Then
            .AppendLine("	AND VP.IdListaPrecios = " & IdListaPrecios)
         End If

         .AppendLine(" GROUP BY M.IdMarca, M.NombreMarca, V.IdSucursal, V.IdFormasPago, VFP.Dias, E.ComisionPorVenta, M.ComisionPorVenta, R.ComisionPorVenta")
         .AppendLine(") Detalle")

         .AppendLine("GROUP BY IdMarca, NombreMarca")

         If Not unificarMarcas Then
            .AppendLine(", IdSucursal")
         End If

         .AppendLine(" ORDER BY Comision DESC, Total DESC")
      End With

      Return GetDataTable(stb.ToString())

   End Function


   Public Function GetComisionesDetalladoPorProductos(idSucursal As Integer,
                                                      desde As Date,
                                                      hasta As Date,
                                                      oCategoriaFiscalEmpresa As Entidades.CategoriaFiscal,
                                                      strCalculoComisionVendedor As String,
                                                      comisionVendedor As String,
                                                      conComision As String,
                                                      idVendedor As Integer,
                                                      idCliente As Long,
                                                      idMarca As Integer,
                                                      idRubro As Integer,
                                                      idSubRubro As Integer,
                                                      idProducto As String,
                                                      idZonaGeografica As String,
                                                      conIva As Boolean) As DataTable

      Dim QueSuma As String
      If oCategoriaFiscalEmpresa.IvaDiscriminado Then
         If conIva Then
            QueSuma = "(VP.ImporteTotalNeto+VP.ImporteImpuesto)"
         Else
            QueSuma = "VP.ImporteTotalNeto"
         End If

      Else
         QueSuma = "(VP.ImporteTotalNeto+VP.ImporteImpuesto)"
      End If

      Dim stb = New StringBuilder()
      With stb
         .AppendLine("SELECT  V.IdVendedor,")
         .AppendLine("        V.Fecha,")
         .AppendLine("        TC.DescripcionAbrev,")
         .AppendLine("        V.Letra,")
         .AppendLine("        V.CentroEmisor,")
         .AppendLine("        V.NumeroComprobante,")
         .AppendLine("        VFP.DescripcionFormasPago AS FormaPago,")
         .AppendLine("        V.IdCliente,")
         .AppendLine("        C.NombreCliente,")
         .AppendLine("        VP.IdProducto,")
         '.AppendLine("        P.NombreProducto,")
         .AppendLine("        VP.NombreProducto,")
         .AppendLine("        M.NombreMarca,")
         .AppendLine("        R.NombreRubro,")
         .AppendLine("        VP.Cantidad,")

         .AppendLine("      " & QueSuma & " as ImporteTotalNeto, ")

         If strCalculoComisionVendedor = "FACTURACION" Then
            .AppendLine("        VP.ComisionVendedorPorc AS PorcComision,")
            .AppendLine("        ROUND(VP.ComisionVendedor,2) AS Comision")
         Else  'LISTADO

            '.AppendLine("       CASE WHEN E.ComisionPorVenta <> 0 THEN E.ComisionPorVenta ELSE")
            'If comisionVendedor = "VENDEDORRUBROMARCA" Then
            '   .AppendLine(" CASE WHEN R.ComisionPorVenta <> 0 THEN R.ComisionPorVenta ELSE M.ComisionPorVenta END END AS PorcComision ,")
            'Else
            '   .AppendLine(" CASE WHEN M.ComisionPorVenta <> 0 THEN M.ComisionPorVenta ELSE R.ComisionPorVenta END END AS PorcComision ,")
            'End If

            '.AppendLine("     CASE WHEN E.ComisionPorVenta <> 0 THEN ROUND(" & QueSuma & "*E.ComisionPorVenta/100,2) ELSE")
            Ayudante.Comisiones.Calculo("100", "E", "ECP", "ECPP", "R", "ECR", "ECRP", "ECSR", "ECSSR", "M", "ECM", "ECMP", "P", comisionVendedor, stb)
            .AppendFormatLine(" PorcComision,")

            .AppendFormatLine("       ROUND(")
            Ayudante.Comisiones.Calculo(QueSuma, "E", "ECP", "ECPP", "R", "ECR", "ECRP", "ECSR", "ECSSR", "M", "ECM", "ECMP", "P", comisionVendedor, stb)
            .AppendFormatLine("              , 2) AS Comision")

            'If Publicos.ComisionVendedor = "VENDEDORRUBROMARCA" Then
            '   .AppendLine(" CASE WHEN R.ComisionPorVenta <> 0 THEN ROUND(" & QueSuma & "*R.ComisionPorVenta/100,2) ELSE ROUND(" & QueSuma & "*M.ComisionPorVenta/100,2) END END AS Comision")
            'Else
            '   .AppendLine(" CASE WHEN M.ComisionPorVenta <> 0 THEN ROUND(" & QueSuma & "*M.ComisionPorVenta/100,2) ELSE ROUND(" & QueSuma & "*R.ComisionPorVenta/100,2) END END AS Comision")
            'End If

         End If

         .AppendLine("  FROM Ventas V")
         .AppendLine("   INNER JOIN Empleados E ON V.IdVendedor = E.IdEmpleado ")
         .AppendLine("  INNER JOIN VentasProductos VP ON V.IdSucursal = VP.IdSucursal")
         .AppendLine("  AND V.IdTipoComprobante=VP.IdTipoComprobante")
         .AppendLine("  AND V.Letra=VP.Letra")
         .AppendLine("  AND V.CentroEmisor=VP.CentroEmisor")
         .AppendLine("  AND V.NumeroComprobante=VP.NumeroComprobante")
         .AppendLine("  INNER JOIN TiposComprobantes TC ON V.IdTipoComprobante = TC.IdTipoComprobante")
         .AppendLine("  INNER JOIN VentasFormasPago VFP ON V.IdFormasPago = VFP.IdFormasPago")
         .AppendLine("  INNER JOIN Productos P ON VP.IdProducto = P.IdProducto")
         .AppendLine("  INNER JOIN Marcas M ON P.IdMarca = M.IdMarca")
         .AppendLine("  INNER JOIN Rubros R ON P.IdRubro = R.IdRubro")
         .AppendLine("  INNER JOIN Clientes C ON V.IdCliente = C.IdCliente")
         .AppendLine("  INNER JOIN ZonasGeograficas ZG ON C.IdZonaGeografica = ZG.IdZonaGeografica")

         .AppendLine("  LEFT JOIN EmpleadosComisionesMarcas ECM ON ECM.IdMarca = M.IdMarca AND ECM.IdEmpleado = E.IdEmpleado ")
         .AppendLine("  LEFT JOIN EmpleadosComisionesRubros ECR ON ECR.IdRubro = R.IdRubro AND ECR.IdEmpleado = E.IdEmpleado ")
         .AppendLine("  LEFT JOIN EmpleadosComisionesSubRubros ECSR ON ECSR.IdSubRubro = P.IdSubRubro AND ECSR.IdEmpleado = E.IdEmpleado ")
         .AppendLine("  LEFT JOIN EmpleadosComisionesSubSubRubros ECSSR ON ECSSR.IdSubSubRubro = P.IdSubSubRubro AND ECSSR.IdEmpleado = E.IdEmpleado ")
         .AppendLine("  LEFT JOIN EmpleadosComisionesProductos ECP ON ECP.IdProducto = P.IdProducto AND ECP.IdEmpleado = E.IdEmpleado ")
         .AppendLine("  LEFT JOIN EmpleadosComisionesProductosPrecios ECPP ON ECPP.IdProducto = P.IdProducto AND ECPP.IdEmpleado = E.IdEmpleado AND ECPP.IdListaPrecios = VP.IdListaPrecios")


         .AppendLine("  LEFT JOIN EmpleadosComisionesMarcasPrecios ECMP ON ECMP.IdMarca = M.IdMarca AND ECMP.IdEmpleado = E.IdEmpleado AND ECMP.IdListaPrecios = VP.IdListaPrecios")
         .AppendLine("  LEFT JOIN EmpleadosComisionesRubrosPrecios ECRP ON ECRP.IdRubro = R.IdRubro AND ECRP.IdEmpleado = E.IdEmpleado AND ECRP.IdListaPrecios = VP.IdListaPrecios")

         .AppendLine(" WHERE V.IdSucursal = " & idSucursal.ToString())
         .AppendLine("   AND V.Fecha >= '" & desde.ToString("yyyyMMdd HH:mm:ss") & "'")
         .AppendLine("   AND V.Fecha <= '" & hasta.ToString("yyyyMMdd HH:mm:ss") & "'")

         .AppendLine("   AND TC.AfectaCaja = 'True'")
         .AppendLine("   AND TC.EsComercial = 'True'")   'Con esto solo alcanzaria, pero por ahora dejamos ambos.


         If strCalculoComisionVendedor = "FACTURACION" Then

            If conComision = "SI" Then
               .AppendLine("     AND VP.ComisionVendedor <> 0 ")
            ElseIf conComision = "NO" Then
               .AppendLine("     AND VP.ComisionVendedor = 0")
            End If

         Else  'LISTADO

            If conComision = "SI" Then
               .AppendLine("     AND ")
               Ayudante.Comisiones.Calculo(QueSuma, "E", "ECP", "ECPP", "R", "ECR", "ECRP", "ECSR", "ECSSR", "M", "ECM", "ECMP", "P", comisionVendedor, stb)
               .AppendLine("                 <> 0 ")
            ElseIf conComision = "NO" Then
               .AppendLine("     AND ")
               Ayudante.Comisiones.Calculo(QueSuma, "E", "ECP", "ECPP", "R", "ECR", "ECRP", "ECSR", "ECSSR", "M", "ECM", "ECMP", "P", comisionVendedor, stb)
               .AppendLine("                 = 0 ")
            End If

         End If
         '---------------------------------------------------------------------------------------------------------

         If idVendedor > 0 Then
            .AppendLine("	AND V.IdVendedor = " & idVendedor)
         End If

         If idCliente > 0 Then
            .AppendLine("	AND C.IdCliente = " & idCliente.ToString())
         End If

         If idMarca > 0 Then
            .AppendLine("   AND P.IdMarca = " & idMarca.ToString())
         End If

         If idRubro > 0 Then
            .AppendLine("   AND P.IdRubro = " & idRubro.ToString())
         End If

         If idSubRubro > 0 Then
            .AppendLine("   AND P.IdSubRubro = " & idSubRubro.ToString())
         End If

         If Not String.IsNullOrEmpty(idProducto) Then
            .AppendLine("	AND VP.IdProducto = '" & idProducto & "'")
         End If

         If Not String.IsNullOrEmpty(idZonaGeografica) Then
            .AppendFormat(" AND ZG.IdZonaGeografica = '{0}'", idZonaGeografica)
         End If

         .AppendLine("	ORDER BY V.Fecha")
      End With

      Return GetDataTable(stb.ToString())

   End Function
#End Region

End Class