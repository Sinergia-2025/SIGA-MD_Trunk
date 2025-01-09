Partial Class Ventas

#Region "Get Consolidado"
   Public Function GetConsolidadoComprobantePorProductos(IdSucursal As Integer,
                                     Desde As Date,
                                     Hasta As Date,
                                     Optional IdVendedor As Integer = 0,
                                     Optional GrabaLibro As String = "TODOS",
                                     Optional IdCliente As Long = 0,
                                     Optional AfectaCaja As String = "TODOS",
                                     Optional TipoComprobante As String = "",
                                     Optional NumeroComprobante As Long = 0,
                                     Optional IdFormasPago As Integer = 0,
                                     Optional IdUsuario As String = "",
                                     Optional IdEstadoComprobante As String = "",
                                     Optional PorcUtilidadDesde As Decimal = -1,
                                     Optional PorcUtilidadHasta As Decimal = -1,
                                     Optional MercDespachada As String = "TODOS",
                                     Optional Comercial As String = "TODOS",
                                     Optional IdCategoria As Integer = 0,
                                     Optional idZonaGeografica As String = "") As DataTable

      Dim oCategoriaFiscalEmpresa As Entidades.CategoriaFiscal = New Reglas.CategoriasFiscales(Me.da)._GetUno(Publicos.CategoriaFiscalEmpresa)

      Dim stb As StringBuilder = New StringBuilder("")

      With stb
         .Length = 0
         .AppendLine("SELECT V.Fecha ")
         .AppendLine("	,V.IdSucursal")
         .AppendLine("	,V.IdTipoComprobante")
         .AppendLine("	,TC.DescripcionAbrev ")
         .AppendLine("	,V.Letra ")
         .AppendLine("	,V.CentroEmisor ")
         .AppendLine("	,V.NumeroComprobante ")
         .AppendLine("	,V.IdVendedor ")
         .AppendLine("  ,E.NombreEmpleado as NombreVendedor")
         .AppendLine("	,C.NombreCliente ")
         .AppendLine("	,C.CodigoCliente ")
         .AppendLine("	,C.IdCliente ")
         .AppendLine("	,V.IdCliente ")
         .AppendLine("  ,C.Direccion")
         .AppendLine("	,V.ImporteBruto ")
         .AppendLine("	,V.DescuentoRecargoPorc ")
         .AppendLine("	,V.DescuentoRecargo ")
         .AppendLine("	,CF.NombreCategoriaFiscalAbrev NombreCategoriaFiscal ")
         .AppendLine("   ,I.IdImpresora")
         .AppendLine("   ,I.TipoImpresora")
         .AppendLine("   ,V.IdEstadoComprobante")
         .AppendLine("   ,V.Kilos")
         .AppendLine("   ,C.Cuit")
         .AppendLine("   ,VFP.DescripcionFormasPago as FormaDePago")
         .AppendLine("   ,V.IdFormasPago")
         .AppendLine("   ,V.ImportePesos")
         .AppendLine("   ,V.ImporteTickets")
         .AppendLine("   ,V.ImporteTarjetas")
         .AppendLine("   ,V.ImporteCheques")
         .AppendLine("   ,V.CantidadInvocados")
         .AppendLine("   ,V.CantidadLotes")
         .AppendLine("   ,V.Usuario")
         .AppendLine("   ,V.FechaAlta")
         .AppendLine("   ,V.CAE")
         .AppendLine("   ,V.CAEVencimiento")
         .AppendLine("   ,V.Observacion")

         'RI
         If oCategoriaFiscalEmpresa.IvaDiscriminado Then

            .AppendLine("	,V.SubTotal")
            .AppendLine("	,V.TotalImpuestos")
            .AppendLine("  ,V.TotalImpuestoInterno")
            .AppendLine("	,V.ImporteTotal")
            .AppendLine("  ,V.Utilidad")

            'Monotributo
         Else

            .AppendLine("  ,V.ImporteTotal AS Subtotal ")
            .AppendLine("	,0 AS TotalImpuestos ")
            .AppendLine("  ,0 AS TotalImpuestoInterno")
            .AppendLine("	,V.ImporteTotal")
            .AppendLine("  ,V.Utilidad + V.TotalImpuestos + V.TotalImpuestoInterno as Utilidad ")

         End If

         .AppendLine("  ,V.SubTotal-V.Utilidad AS Costo")
         .AppendLine("   ,V.FechaTransmisionAFIP")
         .AppendLine("   ,TC.EsElectronico")
         .AppendLine("   ,V.MercDespachada")
         .AppendLine("   ,V.FechaActualizacion")
         .AppendLine("     ,ZG.NombreZonaGeografica")
         .AppendLine("	FROM Ventas V")

         .AppendLine("	 LEFT JOIN CategoriasFiscales CF ON V.IdCategoriaFiscal=CF.IdCategoriaFiscal ")
         .AppendLine("	 LEFT JOIN Impresoras I ON V.CentroEmisor = I.CentroEmisor AND V.IdSucursal = I.IdSucursal")
         .AppendLine("	 LEFT JOIN TiposComprobantes TC ON  V.IdTipoComprobante=TC.IdTipoComprobante ")
         .AppendLine("	 LEFT JOIN VentasFormasPago VFP ON V.IdFormasPago = VFP.IdFormasPago ")
         .AppendLine("	 LEFT JOIN Clientes C ON V.IdCliente = C.IdCliente ")
         .AppendLine("   LEFT JOIN ZonasGeograficas ZG ON C.IdZonaGeografica = ZG.IdZonaGeografica")
         .AppendLine("  INNER JOIN Empleados E ON V.IdVendedor = E.IdEmpleado ")

         .AppendLine("  WHERE V.IdSucursal = " & IdSucursal.ToString())
         .AppendLine("	  AND V.Fecha >= '" & Desde.ToString("yyyyMMdd HH:mm:ss") & "'")
         .AppendLine("	  AND V.Fecha <= '" & Hasta.ToString("yyyyMMdd HH:mm:ss") & "'")
         .AppendLine("    AND TC.AfectaCaja = 'True'")
         .AppendLine("    AND TC.EsComercial = 'True'")   'Con esto solo alcanzaria, pero por ahora dejamos ambos.

         If IdVendedor > 0 Then
            .AppendLine("	 AND V.IdVendedor = " & IdVendedor)
         End If

         If IdCliente <> 0 Then
            .AppendLine("	 AND C.IdCliente = " & IdCliente)
         End If

         If GrabaLibro <> "TODOS" Then
            .AppendLine("      AND TC.GrabaLibro = " & IIf(GrabaLibro = "SI", "1", "0").ToString())
         End If

         If AfectaCaja <> "TODOS" Then
            .AppendLine("      AND TC.AfectaCaja = " & IIf(AfectaCaja = "SI", "1", "0").ToString())
         End If

         If Comercial <> "TODOS" Then
            .AppendLine("   AND TC.EsComercial = '" & IIf(Comercial = "SI", "True", "False").ToString() & "' ")
         End If

         If Not String.IsNullOrEmpty(TipoComprobante) Then
            .AppendLine("	 AND V.IdTipoComprobante = '" & TipoComprobante & "'")
         End If

         If NumeroComprobante > 0 Then
            .AppendLine("	 AND V.NumeroComprobante = " & NumeroComprobante.ToString())
         End If

         If IdFormasPago > 0 Then
            .AppendLine("	 AND V.IdFormasPago = " & IdFormasPago.ToString())
         End If

         If Not String.IsNullOrEmpty(IdUsuario) Then
            .AppendLine("	 AND V.Usuario = '" & IdUsuario & "'")
         End If

         If Not String.IsNullOrEmpty(IdEstadoComprobante) Then
            'Si lo grabariamos de entrada cuando se genera el remito, sacamos el if y dejamos el filtro.
            If IdEstadoComprobante = "PENDIENTE" Then
               .AppendLine("   AND (V.IdEstadoComprobante IS NULL OR V.IdEstadoComprobante = 'INVOCO')")
            ElseIf IdEstadoComprobante = "NO ANULADO" Then
               .AppendLine("   AND (IdEstadoComprobante IS NULL OR IdEstadoComprobante <> 'ANULADO') ")
            Else
               .AppendLine("   AND V.IdEstadoComprobante = '" & IdEstadoComprobante & "'")
            End If
         End If

         If PorcUtilidadDesde >= 0 Then
            .AppendLine("	AND ROUND(V.Utilidad/V.SubTotal*100,2) BETWEEN " & PorcUtilidadDesde.ToString() & " AND " & PorcUtilidadHasta.ToString())
         End If

         If MercDespachada <> "TODOS" Then
            .AppendLine("      AND V.MercDespachada = " & IIf(MercDespachada = "SI", "1", "0").ToString())
         End If

         If IdCategoria > 0 Then
            .AppendLine("	 AND C.IdCategoria = " & IdCategoria.ToString())
         End If

         If Not String.IsNullOrEmpty(idZonaGeografica) Then
            .AppendLine(" AND ZG.IdZonaGeografica = '" & idZonaGeografica & "'")
         End If

         .AppendLine("  AND (V.IdEstadoComprobante IS NULL OR IdEstadoComprobante <> 'ANULADO') ")

         .AppendLine("	ORDER BY V.fecha")

      End With

      Return Me.da.GetDataTable(stb.ToString())

   End Function
   Private Sub GetConsolidadoSelect(stb As StringBuilder)

      With stb
         .Length = 0
      End With
   End Sub

   Public Function GetConsolidadoComprobantePorReparto(IdSucursal As Integer, NroReparto As Integer, NroRepartoMasivo As Integer) As DataTable

      Dim oCategoriaFiscalEmpresa = New CategoriasFiscales(Me.da)._GetUno(Publicos.CategoriaFiscalEmpresa)
      Dim stb = New StringBuilder("")

      With stb
         .Length = 0

         .AppendLine("SELECT V.Fecha ")
         .AppendLine("	,V.IdSucursal")
         .AppendLine("	,V.IdTipoComprobante")
         .AppendLine("	,TC.DescripcionAbrev ")
         .AppendLine("	,V.Letra ")
         .AppendLine("	,V.CentroEmisor ")
         .AppendLine("	,V.NumeroComprobante ")
         .AppendLine("	,V.IdVendedor ")
         .AppendLine("  ,E.NombreEmpleado as NombreVendedor")
         .AppendLine("	,C.NombreCliente ")
         .AppendLine("	,C.CodigoCliente ")
         .AppendLine("	,C.IdCliente ")
         .AppendLine("	,V.IdCliente ")
         .AppendLine("  ,V.Direccion")
         .AppendLine("	,V.ImporteBruto ")
         .AppendLine("	,V.DescuentoRecargoPorc ")
         .AppendLine("	,V.DescuentoRecargo ")
         .AppendLine("	,CF.NombreCategoriaFiscalAbrev NombreCategoriaFiscal ")
         .AppendLine("   ,I.IdImpresora")
         .AppendLine("   ,I.TipoImpresora")
         .AppendLine("   ,V.IdEstadoComprobante")
         .AppendLine("   ,V.Kilos")
         .AppendLine("   ,C.Cuit")
         .AppendLine("   ,VFP.DescripcionFormasPago as FormaDePago")
         .AppendLine("   ,V.IdFormasPago")
         .AppendLine("   ,V.ImportePesos")
         .AppendLine("   ,V.ImporteTickets")
         .AppendLine("   ,V.ImporteTarjetas")
         .AppendLine("   ,V.ImporteCheques")
         .AppendLine("   ,V.CantidadInvocados")
         .AppendLine("   ,V.CantidadLotes")
         .AppendLine("   ,V.Usuario")
         .AppendLine("   ,V.FechaAlta")
         .AppendLine("   ,V.CAE")
         .AppendLine("   ,V.CAEVencimiento")
         .AppendLine("   ,V.Observacion")
         'RI
         If oCategoriaFiscalEmpresa.IvaDiscriminado Then
            .AppendLine("	,V.SubTotal")
            .AppendLine("	,V.TotalImpuestos")
            .AppendLine("  ,V.TotalImpuestoInterno")
            .AppendLine("	,V.ImporteTotal")
            .AppendLine("  ,V.Utilidad")
            'Monotributo
         Else
            .AppendLine("  ,V.ImporteTotal AS Subtotal ")
            .AppendLine("	,0 AS TotalImpuestos ")
            .AppendLine("  ,0 AS TotalImpuestoInterno")
            .AppendLine("	,V.ImporteTotal")
            .AppendLine("  ,V.Utilidad + V.TotalImpuestos + V.TotalImpuestoInterno as Utilidad ")
         End If
         .AppendLine("  ,V.SubTotal-V.Utilidad AS Costo")
         .AppendLine("   ,V.FechaTransmisionAFIP")
         .AppendLine("   ,TC.EsElectronico")
         .AppendLine("   ,V.MercDespachada")
         .AppendLine("   ,V.FechaActualizacion")
         .AppendLine("	FROM Ventas V")

         .AppendLine("	 LEFT JOIN CategoriasFiscales CF ON V.IdCategoriaFiscal=CF.IdCategoriaFiscal ")
         .AppendLine("	 LEFT JOIN Impresoras I ON V.CentroEmisor = I.CentroEmisor And V.IdSucursal = I.IdSucursal")
         .AppendLine("	 LEFT JOIN TiposComprobantes TC ON  V.IdTipoComprobante=TC.IdTipoComprobante ")
         .AppendLine("	 LEFT JOIN VentasFormasPago VFP ON V.IdFormasPago = VFP.IdFormasPago ")
         .AppendLine("	 LEFT JOIN Clientes C ON V.IdCliente = C.IdCliente ")
         .AppendLine("  INNER JOIN Empleados E ON V.IdVendedor = E.IdEmpleado ")

         .AppendLine("  WHERE V.IdSucursal = " & IdSucursal.ToString())

         If NroReparto > 0 Then
            .AppendLine("    AND V.NumeroReparto = " & NroReparto.ToString())
         End If

         If NroRepartoMasivo > 0 Then
            .AppendLine("    AND V.NroRepartoInvocacionMasiva = " & NroRepartoMasivo.ToString())
         End If

         .AppendLine("	ORDER BY V.fecha")
      End With

      Return Me.da.GetDataTable(stb.ToString())

   End Function

#End Region

#Region "Get Kilos"
   Public Function GetKilosTotalesPorVendedor(sucursales As Entidades.Sucursal(),
                                             Desde As Date,
                                             Hasta As Date,
                                             TipoKilos As String,
                                             Optional IdVendedor As Integer = 0,
                                             Optional IdCliente As Long = 0,
                                             Optional idZonaGeografica As String = "",
                                             Optional IdLocalidad As Integer = 0,
                                             Optional TotalesPorSucursal As Boolean = False) As DataTable

      Dim stb As StringBuilder = New StringBuilder("")

      Dim oCategoriaFiscalEmpresa As Entidades.CategoriaFiscal = New Reglas.CategoriasFiscales(Me.da)._GetUno(Publicos.CategoriaFiscalEmpresa)


      With stb
         .Length = 0
         .AppendLine("SELECT")
         .AppendLine("    V.IdVendedor,")
         .AppendLine("    E.NombreEmpleado as NombreVendedor,")

         If oCategoriaFiscalEmpresa.IvaDiscriminado Then
            .AppendLine("    SUM(VP.ImporteTotalNeto) as Total, ")
         Else
            .AppendLine("    SUM(VP.ImporteTotalNeto+VP.ImporteImpuesto) as Total, ")
         End If

         .AppendLine("    SUM(VP.Kilos) as Kilos")

         If TotalesPorSucursal Then
            .AppendLine("    ,V.IdSucursal") 'PE-31377
         Else
            .AppendLine("     ,NULL as IdSucursal")
         End If

         .AppendLine(" FROM Ventas V")
         .AppendLine(" INNER JOIN VentasProductos VP ON V.IdSucursal = VP.IdSucursal ")
         .AppendLine(" AND V.IdTipoComprobante = VP.IdTipoComprobante ")
         .AppendLine(" AND V.Letra = VP.Letra ")
         .AppendLine(" AND V.CentroEmisor = VP.CentroEmisor ")
         .AppendLine(" AND V.NumeroComprobante = VP.NumeroComprobante ")

         If TipoKilos = "CON KILOS" Then
            .AppendLine(" AND VP.Kilos <> 0")
         ElseIf TipoKilos = "SIN KILOS" Then
            .AppendLine(" AND VP.Kilos = 0")
         End If
         .AppendLine(" INNER JOIN Clientes C ON V.IdCliente = C.IdCliente ")
         .AppendLine(" INNER JOIN Empleados E ON V.IdVendedor = E.IdEmpleado ")
         .AppendLine(" INNER JOIN TiposComprobantes TC ON V.IdTipoComprobante = TC.IdTipoComprobante ")
         .AppendLine(" INNER JOIN ZonasGeograficas ZG ON C.IdZonaGeografica = ZG.IdZonaGeografica")

         '-. PE-31377 .-
         .AppendLine("  WHERE 1 = 1")
         SqlServer.Comunes.GetListaSucursalesMultiples(stb, sucursales, "V")

         .AppendLine("   AND CONVERT(varchar(11), V.fecha, 120) >= '" & Desde.ToString("yyyy-MM-dd") & "'")
         .AppendLine("   AND CONVERT(varchar(11), V.fecha, 120) <= '" & Hasta.ToString("yyyy-MM-dd") & "'")

         .AppendLine("   AND TC.AfectaCaja = 'True'")
         .AppendLine("   AND TC.EsComercial = 'True'")   'Con esto solo alcanzaria, pero por ahora dejamos ambos.

         If IdVendedor > 0 Then
            .AppendLine("	AND V.IdVendedor = " & IdVendedor)
         End If

         If IdCliente <> 0 Then
            .AppendLine("	AND C.IdCliente = " & IdCliente)
         End If

         If Not String.IsNullOrEmpty(idZonaGeografica) Then
            .AppendLine(" AND ZG.IdZonaGeografica = '" & idZonaGeografica & "'")
         End If

         If IdLocalidad > 0 Then
            .AppendLine(" AND C.IdLocalidad = " & IdLocalidad.ToString())
         End If

         '.AppendLine("GROUP BY V.IdVendedor, NombreEmpleado, V.IdSucursal")

         If TotalesPorSucursal Then
            .AppendLine(" GROUP BY V.IdVendedor, NombreEmpleado, V.IdSucursal")
         Else
            .AppendLine(" GROUP BY V.IdVendedor, NombreEmpleado")
         End If

         .AppendLine("ORDER BY Kilos DESC, Total DESC")
      End With

      Return Me.da.GetDataTable(stb.ToString())

   End Function

   Public Function GetKilosTotalesPorCliente(sucursales As Entidades.Sucursal(),
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
                                             TotalesPorSucursal As Boolean) As DataTable
      Dim oCategoriaFiscalEmpresa As Entidades.CategoriaFiscal = New Reglas.CategoriasFiscales(Me.da)._GetUno(Publicos.CategoriaFiscalEmpresa)
      Return New SqlServer.Ventas(da).GetKilosTotalesPorCliente(sucursales,
                                                                oCategoriaFiscalEmpresa.IvaDiscriminado,
                                                                desde,
                                                                hasta,
                                                                tipoKilos,
                                                                IdVendedor,
                                                                idCliente,
                                                                marcas,
                                                                rubros,
                                                                subRubros,
                                                                idZonaGeografica,
                                                                idLocalidad,
                                                                incluyeClientesSinMovimiento,
                                                                TotalesPorSucursal)
   End Function

   Public Function GetKilosComisionesCategoriaClientes(sucursales As Entidades.Sucursal(),
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

      Dim oCategoriaFiscalEmpresa As Entidades.CategoriaFiscal = New Reglas.CategoriasFiscales(Me.da)._GetUno(Publicos.CategoriaFiscalEmpresa)
      Dim dt As DataTable

      dt = New SqlServer.Ventas(da).GetKilosComisionesCategoriasClientes(sucursales,
                                                                oCategoriaFiscalEmpresa.IvaDiscriminado,
                                                                desde,
                                                                hasta,
                                                                IdCategoria,
                                                                IdVendedor,
                                                                idCliente,
                                                                categorias,
                                                                rubros,
                                                                subRubros,
                                                                subSubrubros,
                                                                marcas,
                                                                idZonaGeografica,
                                                                idLocalidad,
                                                                IdTransportista,
                                                                categoria)
      For Each dc As DataColumn In dt.Columns
         If dc.ColumnName.StartsWith("ki_") Or dc.ColumnName.StartsWith("co_") Then
            For Each lis As Entidades.Categoria In categorias
               If dc.ColumnName.Equals(String.Format("ki_{0}", lis.IdCategoria)) Then
                  dc.Caption = String.Format("{0}", lis.NombreCategoria)
               End If
               If dc.ColumnName.Equals(String.Format("co_{0}", lis.IdCategoria)) Then
                  dc.Caption = String.Format("Porc. {0}: {1} %", lis.NombreCategoria, lis.Comisiones)
               End If
            Next
         End If
      Next
      Return dt
   End Function

   Public Function GetKilosTotalesPorMarcas(sucursales As Entidades.Sucursal(),
                                             Desde As Date,
                                             Hasta As Date,
                                             TipoKilos As String,
                                             Optional IdVendedor As Integer = 0,
                                             Optional IdCliente As Long = 0,
                                             Optional IdMarca As Integer = 0,
                                             Optional IdRubro As Integer = 0,
                                             Optional idZonaGeografica As String = "",
                                             Optional IdLocalidad As Integer = 0,
                                             Optional TotalesPorSucursal As Boolean = False) As DataTable

      Dim stb As StringBuilder = New StringBuilder("")

      Dim oCategoriaFiscalEmpresa As Entidades.CategoriaFiscal = New Reglas.CategoriasFiscales(Me.da)._GetUno(Publicos.CategoriaFiscalEmpresa)

      With stb
         .Length = 0
         .AppendLine("SELECT")
         'PE-31376
         If TotalesPorSucursal Then
            .AppendLine("    IdSucursal,")
         Else
            .AppendLine("     NULL as IdSucursal,")
         End If
         .AppendLine("    IdMarca,")
         .AppendLine("    NombreMarca,")
         .AppendLine("    SUM(TotalDetalle) AS Total,")
         .AppendLine("    SUM(KilosDetalle) AS Kilos")
         .AppendLine(" FROM")
         .AppendLine("(")
         .AppendLine("SELECT")
         .AppendLine("    V.IdSucursal,") 'PE-31376
         .AppendLine("       M.IdMarca,")
         .AppendLine("       M.NombreMarca,")

         If oCategoriaFiscalEmpresa.IvaDiscriminado Then
            .AppendLine("       SUM(VP.ImporteTotalNeto) as TotalDetalle,")
         Else
            .AppendLine("       SUM(VP.ImporteTotalNeto+VP.ImporteImpuesto) as TotalDetalle,")
         End If

         .AppendLine("       SUM(VP.Kilos) as KilosDetalle")
         .AppendLine(" FROM Ventas V")
         .AppendLine(" INNER JOIN TiposComprobantes TC ON V.IdTipoComprobante = TC.IdTipoComprobante ")
         .AppendLine(" INNER JOIN VentasProductos VP ON V.IdSucursal=VP.IdSucursal ")
         .AppendLine("                              AND V.IdTipoComprobante=VP.IdTipoComprobante")
         .AppendLine("                              AND V.Letra=VP.Letra")
         .AppendLine("                              AND V.CentroEmisor=VP.CentroEmisor")
         .AppendLine("                              AND V.NumeroComprobante=VP.NumeroComprobante")
         .AppendLine("  INNER JOIN Productos P ON VP.IdProducto = P.IdProducto ")
         .AppendLine("  INNER JOIN Marcas M ON P.IdMarca = M.IdMarca ")
         .AppendLine("  INNER JOIN Clientes C ON V.IdCliente = C.IdCliente")
         .AppendLine("  INNER JOIN ZonasGeograficas ZG ON C.IdZonaGeografica = ZG.IdZonaGeografica")

         .AppendLine("  WHERE 1 = 1")

         SqlServer.Comunes.GetListaSucursalesMultiples(stb, sucursales, "V")

         '.AppendLine("   WHERE V.IdSucursal = " & IdSucursal.ToString())
         '.AppendLine("                      AND V.IdSucursal = VP.IdSucursal")


         .AppendLine("   AND CONVERT(varchar(11), V.fecha, 120) >= '" & Desde.ToString("yyyy-MM-dd") & "'")
         .AppendLine("   AND CONVERT(varchar(11), V.fecha, 120) <= '" & Hasta.ToString("yyyy-MM-dd") & "'")

         .AppendLine("   AND TC.AfectaCaja = 'True'")
         .AppendLine("   AND TC.EsComercial = 'True'")   'Con esto solo alcanzaria, pero por ahora dejamos ambos.

         'Filtro el Detalle, no tengo que hacerlo aca.
         '.AppendLine("   AND VP.Kilos <> 0")

         If IdVendedor > 0 Then
            .AppendLine("	AND V.IdVendedor = " & IdVendedor)
         End If

         If IdCliente > 0 Then
            .AppendLine("	AND C.IdCliente = " & IdCliente)
         End If

         If Not String.IsNullOrEmpty(idZonaGeografica) Then
            .AppendFormat(" AND ZG.IdZonaGeografica = '{0}'", idZonaGeografica)
         End If

         If IdMarca > 0 Then
            .AppendLine("   AND P.IdMarca = " & IdMarca.ToString())
         End If

         If IdRubro > 0 Then
            .AppendLine("   AND P.IdRubro = " & IdRubro.ToString())
         End If

         If IdLocalidad > 0 Then
            .AppendLine(" AND C.IdLocalidad = " & IdLocalidad.ToString())
         End If

         .AppendLine(" GROUP BY M.IdMarca, M.NombreMarca, V.IdFormasPago, V.IdSucursal")

         .AppendLine(") Detalle")
         'PE-31376
         If TotalesPorSucursal Then
            .AppendLine(" GROUP BY IdMarca, NombreMarca, IdSucursal")
         Else
            .AppendLine(" GROUP BY IdMarca, NombreMarca")
         End If

         If TipoKilos = "CON KILOS" Then
            .AppendLine(" HAVING SUM(KilosDetalle) <> 0")
         ElseIf TipoKilos = "SIN KILOS" Then
            .AppendLine(" HAVING SUM(KilosDetalle) = 0")
         End If

         .AppendLine("ORDER BY Kilos DESC, Total DESC")
      End With

      Return Me.da.GetDataTable(stb.ToString())

   End Function

   Public Function GetKilosDetalladoPorProductos(sucursales As Entidades.Sucursal(), desde As Date, hasta As Date, tipoKilos As String,
                                                 idVendedor As Integer, idCliente As Long,
                                                 marcas As Entidades.Marca(), modelos As Entidades.Modelo(),
                                                 rubros As Entidades.Rubro(), subrubros As Entidades.SubRubro(), subSubRubros As Entidades.SubSubRubro(),
                                                 idProducto As String, idZonaGeografica As String, idLocalidad As Integer) As DataTable
      Dim oCategoriaFiscalEmpresa = New CategoriasFiscales(da)._GetUno(Publicos.CategoriaFiscalEmpresa)
      Return New SqlServer.Ventas(da).
                  GetKilosDetalladoPorProductos(sucursales, desde, hasta, tipoKilos,
                                                idVendedor, idCliente,
                                                marcas, modelos, rubros, subrubros, subSubRubros,
                                                idProducto, idZonaGeografica, idLocalidad,
                                                oCategoriaFiscalEmpresa.IvaDiscriminado)
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
      Try
         Me.da.OpenConection()
         Dim sql As SqlServer.Ventas = New SqlServer.Ventas(Me.da)
         Dim dt As DataTable
         dt = sql.GetKilosCompMensualPorCliente(sucursales,
                                                desde, hasta,
                                                IdVendedor,
                                                idCliente,
                                                marcas, modelos, rubros, subRubros, subSubRubros,
                                                idProducto,
                                                idZonaGeografica,
                                                idLocalidad,
                                                tipoInforme,
                                                conIva,
                                                idClienteVinculado)
         Return dt
      Finally
         Me.da.CloseConection()
      End Try
   End Function

   Public Function GetKilosCompMarcasPorCliente(sucursales As Entidades.Sucursal(),
                                                Desde As Date,
                                                Hasta As Date,
                                                idMarca1 As Integer,
                                                idMarca2 As Integer,
                                                idMarca3 As Integer,
                                                idMarca4 As Integer,
                                                idMarca5 As Integer,
                                                idRubro As Integer,
                                                IdVendedor As Integer,
                                                idZonaGeografica As String,
                                                IdCliente As Long,
                                                IdLocalidad As Integer) As DataTable

      Dim sql As SqlServer.Ventas
      Dim dt As DataTable



      Try
         Me.da.OpenConection()
         Me.da.BeginTransaction()

         sql = New SqlServer.Ventas(Me.da)

         dt = sql.GetKilosCompMarcasPorCliente(sucursales,
                                                Desde, Hasta,
                                                idMarca1, idMarca2, idMarca3, idMarca4, idMarca5,
                                                idRubro,
                                                IdVendedor,
                                                idZonaGeografica,
                                                IdCliente,
                                                IdLocalidad)

         dt.Columns.Add("PorcMarca1", System.Type.GetType("System.Decimal"))
         dt.Columns.Add("PorcMarca2", System.Type.GetType("System.Decimal"))
         dt.Columns.Add("PorcMarca3", System.Type.GetType("System.Decimal"))
         dt.Columns.Add("PorcMarca4", System.Type.GetType("System.Decimal"))
         dt.Columns.Add("PorcMarca5", System.Type.GetType("System.Decimal"))
         dt.Columns.Add("Promedio", System.Type.GetType("System.Decimal"))

         'El promedio es Horizontal, NO Vertical.
         'Dim sumaMarca1 As Decimal = 0, sumaMarca2 As Decimal = 0, sumaMarca3 As Decimal = 0, sumaMarca4 As Decimal = 0, sumaMarca5 As Decimal = 0
         'For Each dr As DataRow In dt.Rows
         '   sumaMarca1 += Decimal.Parse(dr("Marca1").ToString())
         '   sumaMarca2 += Decimal.Parse(dr("Marca2").ToString())
         '   sumaMarca3 += Decimal.Parse(dr("Marca3").ToString())
         'Next

         Dim DividePromedio As Integer = 2   'Integer.Parse(IIf(idMarca3 = 0, 2, 3).ToString())
         If idMarca3 > 0 Then DividePromedio += 1
         If idMarca4 > 0 Then DividePromedio += 1
         If idMarca4 > 0 Then DividePromedio += 1


         For Each dr As DataRow In dt.Rows
            If Decimal.Parse(dr("Total").ToString()) <> 0 Then
               dr("PorcMarca1") = Decimal.Round(Decimal.Parse(dr("Marca1").ToString()) / Decimal.Parse(dr("Total").ToString()) * 100, 2)
               dr("PorcMarca2") = Decimal.Round(Decimal.Parse(dr("Marca2").ToString()) / Decimal.Parse(dr("Total").ToString()) * 100, 2)
               dr("PorcMarca3") = Decimal.Round(Decimal.Parse(dr("Marca3").ToString()) / Decimal.Parse(dr("Total").ToString()) * 100, 2)
               dr("PorcMarca4") = Decimal.Round(Decimal.Parse(dr("Marca4").ToString()) / Decimal.Parse(dr("Total").ToString()) * 100, 2)
               dr("PorcMarca5") = Decimal.Round(Decimal.Parse(dr("Marca5").ToString()) / Decimal.Parse(dr("Total").ToString()) * 100, 2)
            Else
               dr("PorcMarca1") = 0
               dr("PorcMarca2") = 0
               dr("PorcMarca3") = 0
               dr("PorcMarca4") = 0
               dr("PorcMarca5") = 0
            End If
            dr("Promedio") = Decimal.Round((Decimal.Parse(dr("Marca1").ToString()) + Decimal.Parse(dr("Marca2").ToString()) + Decimal.Parse(dr("Marca3").ToString()) + Decimal.Parse(dr("Marca4").ToString()) + Decimal.Parse(dr("Marca5").ToString())) / DividePromedio, 2)
         Next

         Me.da.CommitTransaction()

         Return dt
      Catch ex As Exception
         Me.da.RollbakTransaction()
         Throw
      Finally
         Me.da.CloseConection()
      End Try
   End Function

#End Region

End Class
