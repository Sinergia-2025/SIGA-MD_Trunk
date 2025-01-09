Public Class PedidosProductosFormulas
   Inherits Comunes

   Public Sub New(da As Datos.DataAccess)
      MyBase.New(da)
   End Sub

   Public Sub PedidosProductosFormulas_I(idSucursal As Integer, idTipoComprobante As String, letra As String, centroEmisor As Integer, numeroPedido As Long,
                                         idProducto As String, orden As Integer,
                                         idProductoElaborado As String, idUnicoNodoProductoElaborado As String,
                                         idProductoComponente As String, idUnicoNodoProductoComponente As String,
                                         idFormula As Integer, secuenciaFormula As Integer,
                                         nombreProductoElaborado As String, nombreProductoComponente As String,
                                         nombreFormula As String,
                                         precioCosto As Decimal, precioVenta As Decimal,
                                         cantidad As Decimal, cantidadEnFormula As Decimal,
                                         segunCalculoForma As Boolean,
                                         importeCosto As Decimal, importeVenta As Decimal,
                                         formulaCalculoKilaje As String)
      Dim myQuery As StringBuilder = New StringBuilder()
      With myQuery
         .AppendFormatLine("INSERT INTO {0} (", Entidades.PedidoProductoFormula.NombreTabla)
         .AppendFormatLine("            {0}", Entidades.PedidoProductoFormula.Columnas.IdSucursal.ToString())
         .AppendFormatLine("           ,{0}", Entidades.PedidoProductoFormula.Columnas.IdTipoComprobante.ToString())
         .AppendFormatLine("           ,{0}", Entidades.PedidoProductoFormula.Columnas.Letra.ToString())
         .AppendFormatLine("           ,{0}", Entidades.PedidoProductoFormula.Columnas.CentroEmisor.ToString())
         .AppendFormatLine("           ,{0}", Entidades.PedidoProductoFormula.Columnas.NumeroPedido.ToString())
         .AppendFormatLine("           ,{0}", Entidades.PedidoProductoFormula.Columnas.IdProducto.ToString())
         .AppendFormatLine("           ,{0}", Entidades.PedidoProductoFormula.Columnas.Orden.ToString())
         .AppendFormatLine("           ,{0}", Entidades.PedidoProductoFormula.Columnas.IdProductoElaborado.ToString())
         .AppendFormatLine("           ,{0}", Entidades.PedidoProductoFormula.Columnas.IdUnicoNodoProductoElaborado.ToString())
         .AppendFormatLine("           ,{0}", Entidades.PedidoProductoFormula.Columnas.IdProductoComponente.ToString())
         .AppendFormatLine("           ,{0}", Entidades.PedidoProductoFormula.Columnas.IdUnicoNodoProductoComponente.ToString())
         .AppendFormatLine("           ,{0}", Entidades.PedidoProductoFormula.Columnas.IdFormula.ToString())
         .AppendFormatLine("           ,{0}", Entidades.PedidoProductoFormula.Columnas.SecuenciaFormula.ToString())
         .AppendFormatLine("           ,{0}", Entidades.PedidoProductoFormula.Columnas.NombreProductoElaborado.ToString())
         .AppendFormatLine("           ,{0}", Entidades.PedidoProductoFormula.Columnas.NombreProductoComponente.ToString())
         .AppendFormatLine("           ,{0}", Entidades.PedidoProductoFormula.Columnas.NombreFormula.ToString())
         .AppendFormatLine("           ,{0}", Entidades.PedidoProductoFormula.Columnas.PrecioCosto.ToString())
         .AppendFormatLine("           ,{0}", Entidades.PedidoProductoFormula.Columnas.PrecioVenta.ToString())
         .AppendFormatLine("           ,{0}", Entidades.PedidoProductoFormula.Columnas.Cantidad.ToString())
         .AppendFormatLine("           ,{0}", Entidades.PedidoProductoFormula.Columnas.CantidadEnFormula.ToString())
         .AppendFormatLine("           ,{0}", Entidades.PedidoProductoFormula.Columnas.SegunCalculoForma.ToString())
         .AppendFormatLine("           ,{0}", Entidades.PedidoProductoFormula.Columnas.ImporteCosto.ToString())
         .AppendFormatLine("           ,{0}", Entidades.PedidoProductoFormula.Columnas.ImporteVenta.ToString())
         .AppendFormatLine("           ,{0}", Entidades.PedidoProductoFormula.Columnas.FormulaCalculoKilaje.ToString())

         .AppendFormatLine("           ) VALUES (")
         .AppendFormatLine("             {0} ", idSucursal)
         .AppendFormatLine("           ,'{0}'", idTipoComprobante)
         .AppendFormatLine("           ,'{0}'", letra)
         .AppendFormatLine("           , {0} ", centroEmisor)
         .AppendFormatLine("           , {0} ", numeroPedido)
         .AppendFormatLine("           ,'{0}'", idProducto)
         .AppendFormatLine("           , {0} ", orden)
         .AppendFormatLine("           ,'{0}'", idProductoElaborado)
         .AppendFormatLine("           ,'{0}'", idUnicoNodoProductoElaborado)
         .AppendFormatLine("           ,'{0}'", idProductoComponente)
         .AppendFormatLine("           ,'{0}'", idUnicoNodoProductoComponente)
         .AppendFormatLine("           , {0} ", idFormula)
         .AppendFormatLine("           , {0} ", secuenciaFormula)
         .AppendFormatLine("           ,'{0}'", nombreProductoElaborado)
         .AppendFormatLine("           ,'{0}'", nombreProductoComponente)
         .AppendFormatLine("           ,'{0}'", nombreFormula)
         .AppendFormatLine("           , {0} ", precioCosto)
         .AppendFormatLine("           , {0} ", precioVenta)
         .AppendFormatLine("           , {0} ", cantidad)
         .AppendFormatLine("           , {0} ", cantidadEnFormula)
         .AppendFormatLine("           , {0} ", GetStringFromBoolean(segunCalculoForma))
         .AppendFormatLine("           , {0} ", importeCosto)
         .AppendFormatLine("           , {0} ", importeVenta)
         .AppendFormatLine("           ,'{0}'", formulaCalculoKilaje)
         .AppendFormatLine("           )")
      End With
      Me.Execute(myQuery.ToString())
   End Sub

   Public Sub PedidosProductosFormulas_D(idSucursal As Integer, idTipoComprobante As String, letra As String, centroEmisor As Integer, numeroPedido As Long,
                                         idProducto As String, orden As Integer?,
                                         idProductoElaborado As String, idUnicoNodoProductoElaborado As String,
                                         idProductoComponente As String, idUnicoNodoProductoComponente As String,
                                         idFormula As Integer, secuenciaFormula As Integer)
      Dim myQuery As StringBuilder = New StringBuilder()
      With myQuery
         .AppendFormatLine("DELETE FROM {0} ", Entidades.PedidoProductoFormula.NombreTabla)
         .AppendFormatLine(" WHERE {0} =  {1} ", Entidades.PedidoProductoFormula.Columnas.IdSucursal.ToString(), idSucursal)
         .AppendFormatLine("   AND {0} = '{1}'", Entidades.PedidoProductoFormula.Columnas.IdTipoComprobante.ToString(), idTipoComprobante)
         .AppendFormatLine("   AND {0} = '{1}'", Entidades.PedidoProductoFormula.Columnas.Letra.ToString(), letra)
         .AppendFormatLine("   AND {0} =  {1} ", Entidades.PedidoProductoFormula.Columnas.CentroEmisor.ToString(), centroEmisor)
         .AppendFormatLine("   AND {0} =  {1} ", Entidades.PedidoProductoFormula.Columnas.NumeroPedido.ToString(), numeroPedido)
         If Not String.IsNullOrWhiteSpace(idProducto) Then
            .AppendFormatLine("   AND {0} = '{1}'", Entidades.PedidoProductoFormula.Columnas.IdProducto.ToString(), idProducto)
         End If
         If orden.HasValue Then
            .AppendFormatLine("   AND {0} =  {1} ", Entidades.PedidoProductoFormula.Columnas.Orden.ToString(), orden.Value)
         End If
         If Not String.IsNullOrWhiteSpace(idProductoElaborado) Then
            .AppendFormatLine("   AND {0} = '{1}'", Entidades.PedidoProductoFormula.Columnas.IdProductoElaborado.ToString(), idProductoElaborado)
         End If
         If Not String.IsNullOrWhiteSpace(idUnicoNodoProductoElaborado) Then
            .AppendFormatLine("   AND {0} = '{1}'", Entidades.PedidoProductoFormula.Columnas.IdUnicoNodoProductoElaborado.ToString(), idUnicoNodoProductoElaborado)
         End If
         If Not String.IsNullOrWhiteSpace(idProductoComponente) Then
            .AppendFormatLine("   AND {0} = '{1}'", Entidades.PedidoProductoFormula.Columnas.IdProductoComponente.ToString(), idProductoComponente)
         End If
         If Not String.IsNullOrWhiteSpace(idUnicoNodoProductoComponente) Then
            .AppendFormatLine("   AND {0} = '{1}'", Entidades.PedidoProductoFormula.Columnas.IdUnicoNodoProductoComponente.ToString(), idUnicoNodoProductoComponente)
         End If
         If idFormula <> 0 Then
            .AppendFormatLine("   AND {0} =  {1} ", Entidades.PedidoProductoFormula.Columnas.IdFormula.ToString(), idFormula)
         End If
         If secuenciaFormula <> 0 Then
            .AppendFormatLine("   AND {0} =  {1} ", Entidades.PedidoProductoFormula.Columnas.SecuenciaFormula.ToString(), secuenciaFormula)
         End If
      End With
      Execute(myQuery)
   End Sub

   Private Sub SelectTexto(stb As StringBuilder)
      With stb
         .AppendFormatLine("SELECT PPF.*")
         .AppendFormatLine("     , PPF.PrecioVenta * PPF.Cantidad AS ImporteVenta")
         .AppendFormatLine("     , P.IdDepositoDefecto")
         .AppendFormatLine("     , P.IdUbicacionDefecto")
         .AppendFormatLine("  FROM {0} AS PPF", Entidades.PedidoProductoFormula.NombreTabla)
         .AppendFormatLine(" INNER JOIN ProductosSucursales P ON P.IdProducto = PPF.IdProducto AND P.IdSucursal = PPF.IdSucursal")
      End With
   End Sub

   Public Function PedidosProductosFormulas_GA(idSucursal As Integer, idTipoComprobante As String, letra As String, centroEmisor As Integer, numeroPedido As Long,
                                               idProducto As String, orden As Integer) As DataTable
      Return PedidosProductosFormulas_G(idSucursal, idTipoComprobante, letra, centroEmisor, numeroPedido,
                                        idProducto, orden,
                                        idProductoElaborado:=Nothing, idUnicoNodoProductoElaborado:=Nothing,
                                        idProductoComponente:=Nothing, idUnicoNodoProductoComponente:=Nothing,
                                        idFormula:=0, secuenciaFormula:=0)
   End Function
   Private Function PedidosProductosFormulas_G(idSucursal As Integer, idTipoComprobante As String, letra As String, centroEmisor As Integer, numeroPedido As Long,
                                               idProducto As String, orden As Integer,
                                               idProductoElaborado As String, idUnicoNodoProductoElaborado As String,
                                               idProductoComponente As String, idUnicoNodoProductoComponente As String,
                                               idFormula As Integer, secuenciaFormula As Integer) As DataTable
      Dim myQuery = New StringBuilder()
      With myQuery
         SelectTexto(myQuery)
         .AppendLine(" WHERE 1 = 1")
         If idSucursal > 0 Then
            .AppendFormatLine("   AND PPF.{0} = {1}", Entidades.PedidoProductoFormula.Columnas.IdSucursal.ToString(), idSucursal)
         End If
         If Not String.IsNullOrWhiteSpace(idTipoComprobante) Then
            .AppendFormatLine("   AND PPF.{0} = '{1}'", Entidades.PedidoProductoFormula.Columnas.IdTipoComprobante.ToString(), idTipoComprobante)
         End If
         If Not String.IsNullOrWhiteSpace(letra) Then
            .AppendFormatLine("   AND PPF.{0} = '{1}'", Entidades.PedidoProductoFormula.Columnas.Letra.ToString(), letra)
         End If
         If centroEmisor > 0 Then
            .AppendFormatLine("   AND PPF.{0} = {1}", Entidades.PedidoProductoFormula.Columnas.CentroEmisor.ToString(), centroEmisor)
         End If
         If numeroPedido > 0 Then
            .AppendFormatLine("   AND PPF.{0} = {1}", Entidades.PedidoProductoFormula.Columnas.NumeroPedido.ToString(), numeroPedido)
         End If
         If Not String.IsNullOrWhiteSpace(idProducto) Then
            .AppendFormatLine("   AND PPF.{0} = '{1}'", Entidades.PedidoProductoFormula.Columnas.IdProducto.ToString(), idProducto)
         End If
         If orden > 0 Then
            .AppendFormatLine("   AND PPF.{0} = {1}", Entidades.PedidoProductoFormula.Columnas.Orden.ToString(), orden)
         End If
         If Not String.IsNullOrWhiteSpace(idProductoElaborado) Then
            .AppendFormatLine("   AND PPF.{0} = '{1}'", Entidades.PedidoProductoFormula.Columnas.IdProductoElaborado.ToString(), idProductoElaborado)
         End If
         If Not String.IsNullOrWhiteSpace(idUnicoNodoProductoElaborado) Then
            .AppendFormatLine("   AND PPF.{0} = '{1}'", Entidades.PedidoProductoFormula.Columnas.IdUnicoNodoProductoElaborado.ToString(), idUnicoNodoProductoElaborado)
         End If
         If Not String.IsNullOrWhiteSpace(idProductoComponente) Then
            .AppendFormatLine("   AND PPF.{0} = '{1}'", Entidades.PedidoProductoFormula.Columnas.IdProductoComponente.ToString(), idProductoComponente)
         End If
         If Not String.IsNullOrWhiteSpace(idUnicoNodoProductoComponente) Then
            .AppendFormatLine("   AND PPF.{0} = '{1}'", Entidades.PedidoProductoFormula.Columnas.IdUnicoNodoProductoComponente.ToString(), idUnicoNodoProductoComponente)
         End If
         If idFormula > 0 Then
            .AppendFormatLine("   AND PPF.{0} = {1}", Entidades.PedidoProductoFormula.Columnas.IdFormula.ToString(), idFormula)
         End If
         If secuenciaFormula > 0 Then
            .AppendFormatLine("   AND PPF.{0} = {1}", Entidades.PedidoProductoFormula.Columnas.SecuenciaFormula.ToString(), secuenciaFormula)
         End If

      End With
      Return GetDataTable(myQuery)
   End Function

   Public Function PedidosProductosFormulas_G1(idSucursal As Integer, idTipoComprobante As String, letra As String, centroEmisor As Integer, numeroPedido As Long,
                                               idProducto As String, orden As Integer,
                                               idProductoElaborado As String, idUnicoNodoProductoElaborado As String,
                                               idProductoComponente As String, idUnicoNodoProductoComponente As String,
                                               idFormula As Integer, secuenciaFormula As Integer) As DataTable
      Return PedidosProductosFormulas_G(idSucursal, idTipoComprobante, letra, centroEmisor, numeroPedido,
                                        idProducto, orden,
                                        idProductoElaborado, idUnicoNodoProductoElaborado,
                                        idProductoComponente, idUnicoNodoProductoComponente,
                                        idFormula, secuenciaFormula)
   End Function

   Public Overloads Function Buscar(columna As String, valor As String) As DataTable
      Return Buscar(columna, valor, Sub(stb) SelectTexto(stb), "PPF.")
   End Function

End Class