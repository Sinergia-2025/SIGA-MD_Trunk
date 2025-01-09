Public Class ProductosProveedores
   Inherits Comunes

   Public Sub New(da As Datos.DataAccess)
      MyBase.New(da)
   End Sub

   Public Sub ProductosProveedores_I(idProveedor As Long, idProducto As String, codigoProductoProveedor As String,
                                     ultimoPrecioCompra As Decimal, ultimaFechaCompra As Date, ultimoPrecioFabrica As Decimal,
                                     descuentoRecargoPorc1 As Decimal,
                                     descuentoRecargoPorc2 As Decimal,
                                     descuentoRecargoPorc3 As Decimal,
                                     descuentoRecargoPorc4 As Decimal,
                                     descuentoRecargoPorc5 As Decimal,
                                     descuentoRecargoPorc6 As Decimal)
      Dim myQuery = New StringBuilder()
      With myQuery
         .AppendFormatLine("MERGE INTO ProductosProveedores AS D")
         .AppendFormatLine("        USING (SELECT {0} IdProveedor, '{1}' IdProducto, '{2}' CodigoProductoProveedor, {3} UltimoPrecioCompra, {4} UltimaFechaCompra, {5} UltimoPrecioFabrica, {6} DescuentoRecargoPorc1, {7} DescuentoRecargoPorc2, {8} DescuentoRecargoPorc3, {9} DescuentoRecargoPorc4, {10} DescuentoRecargoPorc5, {11} DescuentoRecargoPorc6) AS O",
                           idProveedor, idProducto, codigoProductoProveedor,
                           ultimoPrecioCompra, If(ultimaFechaCompra > New Date, GetStringParaQueryConComillas(ObtenerFecha(ultimaFechaCompra, True)), "NULL"), ultimoPrecioFabrica,
                           descuentoRecargoPorc1, descuentoRecargoPorc2, descuentoRecargoPorc3, descuentoRecargoPorc4, descuentoRecargoPorc5, descuentoRecargoPorc6)
         .AppendFormatLine("           ON D.IdProducto = O.IdProducto AND D.IdProveedor = O.IdProveedor")
         .AppendFormatLine("    WHEN NOT MATCHED THEN ")
         .AppendFormatLine("        INSERT (  IdProveedor,   IdProducto,   CodigoProductoProveedor,   UltimoPrecioCompra,   UltimaFechaCompra,   UltimoPrecioFabrica,   DescuentoRecargoPorc1,   DescuentoRecargoPorc2,   DescuentoRecargoPorc3,   DescuentoRecargoPorc4,   DescuentoRecargoPorc5,   DescuentoRecargoPorc6) ")
         .AppendFormatLine("        VALUES (O.IdProveedor, O.IdProducto, O.CodigoProductoProveedor, O.UltimoPrecioCompra, O.UltimaFechaCompra, O.UltimoPrecioFabrica, O.DescuentoRecargoPorc1, O.DescuentoRecargoPorc2, O.DescuentoRecargoPorc3, O.DescuentoRecargoPorc4, O.DescuentoRecargoPorc5, O.DescuentoRecargoPorc6)")
         .AppendFormatLine(";")
      End With

      Execute(myQuery)
      Sincroniza_I(myQuery.ToString(), "ProductosProveedores")
   End Sub

   Public Sub ProductosProveedores_M(drCol As List(Of DataRow))
      If drCol.Any() Then
         Dim selects = String.Join(" UNION ALL ",
                                   drCol.ConvertAll(
                                   Function(dr)
                                      Return String.Format("{0} SELECT {1} IdProveedor, '{2}' IdProducto, '{3}' CodigoProductoProveedor, {4} UltimoPrecioCompra, {5} UltimaFechaCompra, {6} UltimoPrecioFabrica, {7} DescuentoRecargoPorc1, {8} DescuentoRecargoPorc2, {9} DescuentoRecargoPorc3, {10} DescuentoRecargoPorc4, {11} DescuentoRecargoPorc5, {12} DescuentoRecargoPorc6",
                                                           Environment.NewLine,
                                                           dr.Field(Of Long)(Entidades.ProductoProveedor.Columnas.IdProveedor.ToString()),
                                                           dr.Field(Of String)(Entidades.ProductoProveedor.Columnas.IdProducto.ToString()),
                                                           dr.Field(Of String)(Entidades.ProductoProveedor.Columnas.CodigoProductoProveedor.ToString()),
                                                           dr.Field(Of Decimal)(Entidades.ProductoProveedor.Columnas.UltimoPrecioCompra.ToString()),
                                                           ObtenerFecha(dr.Field(Of Date?)(Entidades.ProductoProveedor.Columnas.UltimaFechaCompra.ToString()), True),
                                                           dr.Field(Of Decimal)(Entidades.ProductoProveedor.Columnas.UltimoPrecioFabrica),
                                                           dr.Field(Of Decimal)(Entidades.ProductoProveedor.Columnas.DescuentoRecargoPorc1),
                                                           dr.Field(Of Decimal)(Entidades.ProductoProveedor.Columnas.DescuentoRecargoPorc2),
                                                           dr.Field(Of Decimal)(Entidades.ProductoProveedor.Columnas.DescuentoRecargoPorc3),
                                                           dr.Field(Of Decimal)(Entidades.ProductoProveedor.Columnas.DescuentoRecargoPorc4),
                                                           dr.Field(Of Decimal)(Entidades.ProductoProveedor.Columnas.DescuentoRecargoPorc5),
                                                           dr.Field(Of Decimal)(Entidades.ProductoProveedor.Columnas.DescuentoRecargoPorc6))
                                   End Function))
         Dim myQuery = New StringBuilder()
         With myQuery
            .AppendFormatLine("MERGE INTO ProductosProveedores AS D")
            .AppendFormatLine("        USING ({0}) AS O", selects)
            .AppendFormatLine("           ON D.IdProducto = O.IdProducto AND D.IdProveedor = O.IdProveedor")
            .AppendFormatLine("    WHEN NOT MATCHED THEN ")
            .AppendFormatLine("        INSERT (  IdProveedor,   IdProducto,   CodigoProductoProveedor,   UltimoPrecioCompra,   UltimaFechaCompra,   UltimoPrecioFabrica,   DescuentoRecargoPorc1,   DescuentoRecargoPorc2,   DescuentoRecargoPorc3,   DescuentoRecargoPorc4,   DescuentoRecargoPorc5,   DescuentoRecargoPorc6) ")
            .AppendFormatLine("        VALUES (O.IdProveedor, O.IdProducto, O.CodigoProductoProveedor, O.UltimoPrecioCompra, O.UltimaFechaCompra, O.UltimoPrecioFabrica, O.DescuentoRecargoPorc1, O.DescuentoRecargoPorc2, O.DescuentoRecargoPorc3, O.DescuentoRecargoPorc4, O.DescuentoRecargoPorc5, O.DescuentoRecargoPorc6)")
            .AppendFormatLine(";")
         End With

         Execute(myQuery)
         Sincroniza_I(myQuery.ToString(), "ProductosProveedores")
      End If
   End Sub

   Public Sub ProductosProveedores_D(idProveedor As Long, idProducto As String)
      Dim myQuery = New StringBuilder()
      With myQuery
         .AppendFormatLine("DELETE FROM ProductosProveedores")
         .AppendFormatLine(" WHERE 1 = 1")
         If idProveedor > 0 Then
            .AppendFormatLine("   AND IdProveedor = {0}", idProveedor)
         End If
         If Not String.IsNullOrWhiteSpace(idProducto) Then
            .AppendFormatLine("   AND IdProducto = '{0}'", idProducto)
         End If
      End With

      Execute(myQuery)
      Sincroniza_I(myQuery.ToString(), "ProductosProveedores")
   End Sub

   Public Sub ProductosProveedores_D(idProveedor As Long)
      ProductosProveedores_D(idProveedor:=idProveedor, idProducto:=String.Empty)
   End Sub

   Public Sub ProductosProveedores_DPorProducto(idProducto As String)
      ProductosProveedores_D(idProveedor:=0, idProducto:=idProducto)
   End Sub

   Public Sub ActualizaPrecioUltimaCompra(idProveedor As Long,
                                          idProducto As String,
                                          precio As Decimal,
                                          fecha As Date)
      Dim myQuery = New StringBuilder()
      With myQuery
         .AppendFormatLine("UPDATE ProductosProveedores  ")
         .AppendFormatLine("   SET UltimoPrecioCompra = {0}", precio)
         .AppendFormatLine("      ,UltimaFechaCompra = '{0}'", Me.ObtenerFecha(fecha, True))
         .AppendFormatLine(" WHERE IdProveedor = {0}", idProveedor)
         .AppendFormatLine("   AND IdProducto =  '{0}'", idProducto)
      End With

      Execute(myQuery)
      Sincroniza_I(myQuery.ToString(), "ProductosProveedores")
   End Sub
   Public Sub ActualizaCodigoProductoProveedor(idProveedor As Long,
                                       idProducto As String,
                                       codigoProductoProveedor As String)
      Dim myQuery = New StringBuilder()
      With myQuery
         .AppendFormatLine("UPDATE ProductosProveedores  ")
         .AppendFormatLine("   SET CodigoProductoProveedor = '{0}'", codigoProductoProveedor)
         .AppendFormatLine(" WHERE IdProveedor = {0}", idProveedor)
         .AppendFormatLine("   AND IdProducto =  '{0}'", idProducto)
      End With

      Execute(myQuery)
      Sincroniza_I(myQuery.ToString(), "ProductosProveedores")
   End Sub

   Private Sub SelectTexto(stb As StringBuilder, proveedorHabitual As Boolean)
      With stb
         .AppendFormatLine("SELECT PP.{0}, PP.{1}, PP.{2}, PP.{3}, PP.{4}, PP.{5}, PP.{6}, PP.{7}, PP.{8}, PP.{9}, PP.{10}, PP.{11}, PV.{12}, PV.{13}, PR.{14}, PR.{15}, PR.{16}, M.{17}, R.{18}, SR.{19}, SSR.{20}, MO.{21}, PR.{22}",
                           Entidades.ProductoProveedor.Columnas.IdProveedor.ToString(),
                           Entidades.ProductoProveedor.Columnas.IdProducto.ToString(),
                           Entidades.ProductoProveedor.Columnas.CodigoProductoProveedor.ToString(),
                           Entidades.ProductoProveedor.Columnas.UltimoPrecioCompra.ToString(),
                           Entidades.ProductoProveedor.Columnas.UltimaFechaCompra.ToString(),
                           Entidades.ProductoProveedor.Columnas.UltimoPrecioFabrica.ToString(),
                           Entidades.ProductoProveedor.Columnas.DescuentoRecargoPorc1.ToString(),
                           Entidades.ProductoProveedor.Columnas.DescuentoRecargoPorc2.ToString(),
                           Entidades.ProductoProveedor.Columnas.DescuentoRecargoPorc3.ToString(),
                           Entidades.ProductoProveedor.Columnas.DescuentoRecargoPorc4.ToString(),
                           Entidades.ProductoProveedor.Columnas.DescuentoRecargoPorc5.ToString(),
                           Entidades.ProductoProveedor.Columnas.DescuentoRecargoPorc6.ToString(),
                           Entidades.Proveedor.Columnas.CodigoProveedor.ToString(),
                           Entidades.Proveedor.Columnas.NombreProveedor.ToString(),
                           Entidades.Producto.Columnas.NombreProducto.ToString(),
                           Entidades.Producto.Columnas.IdMarca.ToString(),
                           Entidades.Producto.Columnas.IdRubro.ToString(),
                           Entidades.Marca.Columnas.NombreMarca.ToString(),
                           Entidades.Rubro.Columnas.NombreRubro.ToString(),
                           Entidades.SubRubro.Columnas.NombreSubRubro.ToString(),
                           Entidades.SubSubRubro.Columnas.NombreSubSubRubro.ToString(),
                           Entidades.Moneda.Columnas.NombreMoneda.ToString(),
                           Entidades.Producto.Columnas.PermiteModificarDescripcion.ToString())
         .AppendLine("  FROM ProductosProveedores PP ")

         .AppendFormatLine(" INNER JOIN Productos PR ON PR.{0} = PP.{1}", Entidades.Producto.Columnas.IdProducto.ToString(), Entidades.ProductoProveedor.Columnas.IdProducto.ToString())

         If proveedorHabitual Then
            .AppendFormatLine(" LEFT JOIN Proveedores PV ON PV.IdProveedor = PR.IdProveedor")
         Else
            .AppendFormatLine(" INNER JOIN Proveedores PV ON PP.{0} = PV.{1}", Entidades.Proveedor.Columnas.IdProveedor.ToString(), Entidades.ProductoProveedor.Columnas.IdProveedor.ToString())
         End If

         .AppendFormatLine("  LEFT JOIN Marcas M ON M.{0} = PR.{1}", Entidades.Marca.Columnas.IdMarca.ToString(), Entidades.Producto.Columnas.IdMarca.ToString())
         .AppendFormatLine("  LEFT JOIN Rubros R ON R.{0} = PR.{1}", Entidades.Rubro.Columnas.IdRubro.ToString(), Entidades.Producto.Columnas.IdRubro.ToString())
         .AppendFormatLine("  LEFT JOIN SubRubros SR ON SR.{0} = PR.{1}", Entidades.SubRubro.Columnas.IdSubRubro.ToString(), Entidades.Producto.Columnas.IdSubRubro.ToString())
         .AppendFormatLine("  LEFT JOIN SubSubRubros SSR ON SSR.{0} = PR.{1}", Entidades.SubSubRubro.Columnas.IdSubSubRubro.ToString(), Entidades.Producto.Columnas.IdSubSubRubro.ToString())
         .AppendFormatLine("  LEFT JOIN Monedas MO ON MO.{0} = PR.{1}", Entidades.Moneda.Columnas.IdMoneda.ToString(), Entidades.Producto.Columnas.IdMoneda.ToString())
      End With
   End Sub

   Public Function ProductosProveedores_GA(idProveedor As Long?,
                                        idProducto As String,
                                        ordenardoPor As String,
                                        descendente As Boolean) As DataTable
      Dim habitual As Boolean = False
      Return ProductosProveedores_GA(idProveedor, habitual, idProducto, idMarca:=0, rubros:=Nothing, subrubros:=Nothing,
                                     subsubRubros:=Nothing, fechaDesde:=Nothing, fechaHasta:=Nothing, ordenardoPor:=ordenardoPor,
                                     descendente:=descendente, ordenardoPor2:=String.Empty, descendente2:=False, idMoneda:=0)
   End Function

   Public Function ProductosProveedores_GA(idProveedor As Long?,
                                           habitual As Boolean,
                                           idProducto As String,
                                           idMarca As Integer,
                                           rubros As Entidades.Rubro(),
                                           subrubros As Entidades.SubRubro(),
                                           subsubRubros As Entidades.SubSubRubro(),
                                           fechaDesde As Date,
                                           fechaHasta As Date,
                                           ordenardoPor As String,
                                           descendente As Boolean,
                                           ordenardoPor2 As String,
                                           descendente2 As Boolean,
                                           idMoneda As Integer) As DataTable
      Dim stb = New StringBuilder()
      SelectTexto(stb, habitual)
      With stb
         .AppendLine(" WHERE 1 = 1")
         If idProveedor.HasValue Then
            If idProveedor.Value <> 0 Then
               .AppendFormatLine("   AND PP.{0} = {1}", Entidades.ProductoProveedor.Columnas.IdProveedor.ToString(), idProveedor.Value)
               If habitual Then .AppendFormatLine("   AND PV.IdProveedor = {0}", idProveedor)
            End If
         End If
         If Not String.IsNullOrWhiteSpace(idProducto) Then
            .AppendFormatLine("   AND PP.{0} = '{1}'", Entidades.ProductoProveedor.Columnas.IdProducto.ToString(), idProducto)
         End If

         If idMarca <> 0 Then
            .AppendFormatLine("	AND PR.IdMarca = {0}", idMarca)
         End If

         If idMoneda <> 0 Then
            .AppendFormatLine("	AND PR.IdMoneda = {0}", idMoneda)
         End If
         'If idRubro <> 0 Then
         '   .AppendFormatLine("	AND PR.IdRubro = {0}", idRubro)
         'End If

         GetListaRubrosMultiples(stb, rubros, "PR")
         GetListaSubRubrosMultiples(stb, subrubros, "PR")
         GetListaSubSubRubrosMultiples(stb, subsubRubros, "PR")

         If fechaDesde.Year > 1 Then
            .AppendFormatLine("    AND PP.UltimaFechaCompra >= '{0}'", ObtenerFecha(fechaDesde, True))
            .AppendFormatLine("    AND PP.UltimaFechaCompra <= '{0}'", ObtenerFecha(fechaHasta, True))
         End If

         If Not String.IsNullOrWhiteSpace(ordenardoPor) Then
            If ordenardoPor.Split("."c).Length = 1 Then ordenardoPor = String.Format("PP.{0}", ordenardoPor)
            .AppendFormat(" ORDER BY {0}", ordenardoPor)
            If descendente Then
               .AppendFormatLine(" DESC")
            Else
               .AppendLine()
            End If
         End If
         If Not String.IsNullOrWhiteSpace(ordenardoPor2) Then
            If ordenardoPor2.Split("."c).Length = 1 Then ordenardoPor2 = String.Format("PP.{0}", ordenardoPor2)
            .AppendFormat(" ,{0}", ordenardoPor2)
            If descendente2 Then
               .AppendFormatLine(" DESC")
            Else
               .AppendLine()
            End If
         End If
      End With
      Return GetDataTable(stb)
   End Function

   Public Function ProductosProveedores_G1(idProveedor As Long, idProducto As String) As DataTable
      Return ProductosProveedores_GA(idProveedor:=idProveedor, habitual:=False, idProducto:=idProducto, idMarca:=0, rubros:=Nothing, subrubros:=Nothing, subsubRubros:=Nothing,
                                     fechaDesde:=Nothing, fechaHasta:=Nothing, ordenardoPor:=String.Empty, descendente:=False, ordenardoPor2:=String.Empty, descendente2:=False, idMoneda:=0)
   End Function

   Public Function GetInforme(idProveedor As Long, habitual As Boolean, idProducto As String,
                              idMarca As Integer, rubros As Entidades.Rubro(), subrubros As Entidades.SubRubro(), subsubrubros As Entidades.SubSubRubro(),
                              fechaDesde As Date, fechaHasta As Date, idMoneda As Integer) As DataTable
      Return ProductosProveedores_GA(idProveedor, habitual, idProducto,
                                     idMarca, rubros,
                                     subrubros, subsubrubros, fechaDesde, fechaHasta,
                                     "PV.NombreProveedor", False, "PR.NombreProducto", False, idMoneda)
   End Function

End Class