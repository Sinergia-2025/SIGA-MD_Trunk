Public Class VentasProductosFormulasLotes
   Inherits Comunes

   Public Sub New(da As Datos.DataAccess)
      MyBase.New(da)
   End Sub

   Public Sub VentasProductosFormulasLotes_I(idSucursal As Integer, idTipoComprobante As String, letra As String, centroEmisor As Integer, numeroComprobante As Long,
                                             idProducto As String, orden As Integer, idProductoComponente As String, idFormula As Integer,
                                             idLote As String, fechaVencimiento As Date?,
                                             cantidad As Decimal,
                                             idDeposito As Integer, idUbicacion As Integer)
      Dim myQuery = New StringBuilder()
      With myQuery
         .AppendFormatLine("INSERT INTO {0} (", Entidades.VentaProductoFormulaLote.NombreTabla)
         .AppendFormatLine("            {0}", Entidades.VentaProductoFormulaLote.Columnas.IdSucursal.ToString())
         .AppendFormatLine("           ,{0}", Entidades.VentaProductoFormulaLote.Columnas.IdTipoComprobante.ToString())
         .AppendFormatLine("           ,{0}", Entidades.VentaProductoFormulaLote.Columnas.Letra.ToString())
         .AppendFormatLine("           ,{0}", Entidades.VentaProductoFormulaLote.Columnas.CentroEmisor.ToString())
         .AppendFormatLine("           ,{0}", Entidades.VentaProductoFormulaLote.Columnas.NumeroComprobante.ToString())
         .AppendFormatLine("           ,{0}", Entidades.VentaProductoFormulaLote.Columnas.IdProducto.ToString())
         .AppendFormatLine("           ,{0}", Entidades.VentaProductoFormulaLote.Columnas.Orden.ToString())
         .AppendFormatLine("           ,{0}", Entidades.VentaProductoFormulaLote.Columnas.IdProductoComponente.ToString())
         .AppendFormatLine("           ,{0}", Entidades.VentaProductoFormulaLote.Columnas.IdFormula.ToString())
         .AppendFormatLine("           ,{0}", Entidades.VentaProductoFormulaLote.Columnas.IdLote.ToString())
         .AppendFormatLine("           ,{0}", Entidades.VentaProductoFormulaLote.Columnas.FechaVencimiento.ToString())
         .AppendFormatLine("           ,{0}", Entidades.VentaProductoFormulaLote.Columnas.Cantidad.ToString())
         .AppendFormatLine("           ,{0}", Entidades.VentaProductoFormulaLote.Columnas.IdDeposito.ToString())
         .AppendFormatLine("           ,{0}", Entidades.VentaProductoFormulaLote.Columnas.IdUbicacion.ToString())
         .AppendFormatLine("           ) VALUES (")
         .AppendFormatLine("             {0} ", idSucursal)
         .AppendFormatLine("           ,'{0}'", idTipoComprobante)
         .AppendFormatLine("           ,'{0}'", letra)
         .AppendFormatLine("           , {0} ", centroEmisor)
         .AppendFormatLine("           , {0} ", numeroComprobante)
         .AppendFormatLine("           ,'{0}'", idProducto)
         .AppendFormatLine("           , {0} ", orden)
         .AppendFormatLine("           ,'{0}'", idProductoComponente)
         .AppendFormatLine("           , {0} ", idFormula)
         .AppendFormatLine("           ,'{0}'", idLote)
         .AppendFormatLine("           ,'{0}'", fechaVencimiento)
         .AppendFormatLine("           , {0} ", cantidad)
         .AppendFormatLine("           , {0} ", idDeposito)
         .AppendFormatLine("           , {0} ", idUbicacion)
         .AppendFormatLine("           )")
      End With
      Execute(myQuery)
   End Sub

   Public Sub VentasProductosFormulasLotes_D(idSucursal As Integer, idTipoComprobante As String, letra As String, centroEmisor As Integer, numeroComprobante As Long,
                                             idProducto As String, orden As Integer?, idProductoComponente As String, idFormula As Integer, idLote As String)
      Dim myQuery = New StringBuilder()
      With myQuery
         .AppendFormatLine("DELETE FROM {0} ", Entidades.VentaProductoFormulaLote.NombreTabla)
         .AppendFormatLine(" WHERE {0} =  {1} ", Entidades.VentaProductoFormulaLote.Columnas.IdSucursal.ToString(), idSucursal)
         .AppendFormatLine("   AND {0} = '{1}'", Entidades.VentaProductoFormulaLote.Columnas.IdTipoComprobante.ToString(), idTipoComprobante)
         .AppendFormatLine("   AND {0} = '{1}'", Entidades.VentaProductoFormulaLote.Columnas.Letra.ToString(), letra)
         .AppendFormatLine("   AND {0} =  {1} ", Entidades.VentaProductoFormulaLote.Columnas.CentroEmisor.ToString(), centroEmisor)
         .AppendFormatLine("   AND {0} =  {1} ", Entidades.VentaProductoFormulaLote.Columnas.NumeroComprobante.ToString(), numeroComprobante)
         If Not String.IsNullOrWhiteSpace(idProducto) Then
            .AppendFormatLine("   AND {0} = '{1}'", Entidades.VentaProductoFormulaLote.Columnas.IdProducto.ToString(), idProducto)
         End If
         If orden.HasValue Then
            .AppendFormatLine("   AND {0} =  {1} ", Entidades.VentaProductoFormulaLote.Columnas.Orden.ToString(), orden.Value)
         End If
         If Not String.IsNullOrWhiteSpace(idProductoComponente) Then
            .AppendFormatLine("   AND {0} = '{1}'", Entidades.VentaProductoFormulaLote.Columnas.IdProductoComponente.ToString(), idProductoComponente)
         End If
         If idFormula <> 0 Then
            .AppendFormatLine("   AND {0} =  {1} ", Entidades.VentaProductoFormulaLote.Columnas.IdFormula.ToString(), idFormula)
         End If
         If Not String.IsNullOrWhiteSpace(idLote) Then
            .AppendFormatLine("   AND {0} =  {1} ", Entidades.VentaProductoFormulaLote.Columnas.IdLote.ToString(), idLote)
         End If
      End With
      Execute(myQuery)
   End Sub

   Private Sub SelectTexto(stb As StringBuilder)
      With stb
         .AppendFormatLine("SELECT VPFL.*")
         .AppendFormatLine("  FROM {0} AS VPFL", Entidades.VentaProductoFormulaLote.NombreTabla)
      End With
   End Sub

   Public Function VentasProductosFormulasLotes_GA(idSucursal As Integer, idTipoComprobante As String, letra As String, centroEmisor As Integer, numeroComprobante As Long,
                                                   idProducto As String, orden As Integer, idProductoComponente As String, idFormula As Integer) As DataTable
      Return VentasProductosFormulasLotes_G(idSucursal, idTipoComprobante, letra, centroEmisor, numeroComprobante,
                                            idProducto, orden, idProductoComponente, idFormula, idLote:=String.Empty)
   End Function
   Private Function VentasProductosFormulasLotes_G(idSucursal As Integer, idTipoComprobante As String, letra As String, centroEmisor As Integer, numeroComprobante As Long,
                                                   idProducto As String, orden As Integer, idProductoComponente As String, idFormula As Integer, idLote As String) As DataTable
      Dim myQuery = New StringBuilder()
      With myQuery
         SelectTexto(myQuery)
         .AppendLine(" WHERE 1 = 1")
         If idSucursal > 0 Then
            .AppendFormatLine("   AND VPFL.{0} = {1}", Entidades.VentaProductoFormulaLote.Columnas.IdSucursal.ToString(), idSucursal)
         End If
         If Not String.IsNullOrWhiteSpace(idTipoComprobante) Then
            .AppendFormatLine("   AND VPFL.{0} = '{1}'", Entidades.VentaProductoFormulaLote.Columnas.IdTipoComprobante.ToString(), idTipoComprobante)
         End If
         If Not String.IsNullOrWhiteSpace(letra) Then
            .AppendFormatLine("   AND VPFL.{0} = '{1}'", Entidades.VentaProductoFormulaLote.Columnas.Letra.ToString(), letra)
         End If
         If centroEmisor > 0 Then
            .AppendFormatLine("   AND VPFL.{0} = {1}", Entidades.VentaProductoFormulaLote.Columnas.CentroEmisor.ToString(), centroEmisor)
         End If
         If numeroComprobante > 0 Then
            .AppendFormatLine("   AND VPFL.{0} = {1}", Entidades.VentaProductoFormulaLote.Columnas.NumeroComprobante.ToString(), numeroComprobante)
         End If
         If Not String.IsNullOrWhiteSpace(idProducto) Then
            .AppendFormatLine("   AND VPFL.{0} = '{1}'", Entidades.VentaProductoFormulaLote.Columnas.IdProducto.ToString(), idProducto)
         End If
         If orden > 0 Then
            .AppendFormatLine("   AND VPFL.{0} = {1}", Entidades.VentaProductoFormulaLote.Columnas.Orden.ToString(), orden)
         End If
         If Not String.IsNullOrWhiteSpace(idProductoComponente) Then
            .AppendFormatLine("   AND VPFL.{0} = '{1}'", Entidades.VentaProductoFormulaLote.Columnas.IdProductoComponente.ToString(), idProductoComponente)
         End If
         If idFormula > 0 Then
            .AppendFormatLine("   AND VPFL.{0} = {1}", Entidades.VentaProductoFormulaLote.Columnas.IdFormula.ToString(), idFormula)
         End If
         If Not String.IsNullOrWhiteSpace(idLote) Then
            .AppendFormatLine("   AND VPFL.{0} = '{1}'", Entidades.VentaProductoFormulaLote.Columnas.IdLote.ToString(), idLote)
         End If

      End With
      Return GetDataTable(myQuery)
   End Function

   Public Function VentasProductosFormulasLotes_G1(idSucursal As Integer, idTipoComprobante As String, letra As String, centroEmisor As Integer, numeroComprobante As Long,
                                                   idProducto As String, orden As Integer, idProductoComponente As String, idFormula As Integer, idLote As String) As DataTable
      Return VentasProductosFormulasLotes_G(idSucursal, idTipoComprobante, letra, centroEmisor, numeroComprobante,
                                            idProducto, orden, idProductoComponente, idFormula, idLote)
   End Function

End Class