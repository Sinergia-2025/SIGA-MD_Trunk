Public Class VentasProductosFormulas
   Inherits Comunes

   Public Sub New(da As Datos.DataAccess)
      MyBase.New(da)
   End Sub

   Public Sub VentasProductosFormulas_I(idSucursal As Integer, idTipoComprobante As String, letra As String, centroEmisor As Integer, numeroComprobante As Long,
                                        idProducto As String, orden As Integer, idProductoComponente As String, idFormula As Integer,
                                        nombreProductoComponente As String, nombreFormula As String,
                                        precioCosto As Decimal, precioVenta As Decimal,
                                        cantidad As Decimal, segunCalculoForma As Boolean)
      Dim myQuery = New StringBuilder()
      With myQuery
         .AppendFormatLine("INSERT INTO {0} (", Entidades.VentaProductoFormula.NombreTabla)
         .AppendFormatLine("            {0}", Entidades.VentaProductoFormula.Columnas.IdSucursal.ToString())
         .AppendFormatLine("           ,{0}", Entidades.VentaProductoFormula.Columnas.IdTipoComprobante.ToString())
         .AppendFormatLine("           ,{0}", Entidades.VentaProductoFormula.Columnas.Letra.ToString())
         .AppendFormatLine("           ,{0}", Entidades.VentaProductoFormula.Columnas.CentroEmisor.ToString())
         .AppendFormatLine("           ,{0}", Entidades.VentaProductoFormula.Columnas.NumeroComprobante.ToString())
         .AppendFormatLine("           ,{0}", Entidades.VentaProductoFormula.Columnas.IdProducto.ToString())
         .AppendFormatLine("           ,{0}", Entidades.VentaProductoFormula.Columnas.Orden.ToString())
         .AppendFormatLine("           ,{0}", Entidades.VentaProductoFormula.Columnas.IdProductoComponente.ToString())
         .AppendFormatLine("           ,{0}", Entidades.VentaProductoFormula.Columnas.IdFormula.ToString())
         .AppendFormatLine("           ,{0}", Entidades.VentaProductoFormula.Columnas.NombreProductoComponente.ToString())
         .AppendFormatLine("           ,{0}", Entidades.VentaProductoFormula.Columnas.NombreFormula.ToString())
         .AppendFormatLine("           ,{0}", Entidades.VentaProductoFormula.Columnas.PrecioCosto.ToString())
         .AppendFormatLine("           ,{0}", Entidades.VentaProductoFormula.Columnas.PrecioVenta.ToString())
         .AppendFormatLine("           ,{0}", Entidades.VentaProductoFormula.Columnas.Cantidad.ToString())
         .AppendFormatLine("           ,{0}", Entidades.VentaProductoFormula.Columnas.SegunCalculoForma.ToString())
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
         .AppendFormatLine("           ,'{0}'", nombreProductoComponente)
         .AppendFormatLine("           ,'{0}'", nombreFormula)
         .AppendFormatLine("           , {0} ", precioCosto)
         .AppendFormatLine("           , {0} ", precioVenta)
         .AppendFormatLine("           , {0} ", cantidad)
         .AppendFormatLine("           , {0} ", GetStringFromBoolean(segunCalculoForma))
         .AppendFormatLine("           )")
      End With
      Execute(myQuery)
   End Sub

   Public Sub VentasProductosFormulas_D(idSucursal As Integer, idTipoComprobante As String, letra As String, centroEmisor As Integer, numeroComprobante As Long,
                                        idProducto As String, orden As Integer?, idProductoComponente As String, idFormula As Integer)
      Dim myQuery = New StringBuilder()
      With myQuery
         .AppendFormat("DELETE FROM {0} ", Entidades.VentaProductoFormula.NombreTabla)
         .AppendFormat(" WHERE {0} =  {1} ", Entidades.VentaProductoFormula.Columnas.IdSucursal.ToString(), idSucursal)
         .AppendFormat("   AND {0} = '{1}'", Entidades.VentaProductoFormula.Columnas.IdTipoComprobante.ToString(), idTipoComprobante)
         .AppendFormat("   AND {0} = '{1}'", Entidades.VentaProductoFormula.Columnas.Letra.ToString(), letra)
         .AppendFormat("   AND {0} =  {1} ", Entidades.VentaProductoFormula.Columnas.CentroEmisor.ToString(), centroEmisor)
         .AppendFormat("   AND {0} =  {1} ", Entidades.VentaProductoFormula.Columnas.NumeroComprobante.ToString(), numeroComprobante)
         If Not String.IsNullOrWhiteSpace(idProducto) Then
            .AppendFormat("   AND {0} = '{1}'", Entidades.VentaProductoFormula.Columnas.IdProducto.ToString(), idProducto)
         End If
         If orden.HasValue Then
            .AppendFormat("   AND {0} =  {1} ", Entidades.VentaProductoFormula.Columnas.Orden.ToString(), orden.Value)
         End If
         If Not String.IsNullOrWhiteSpace(idProductoComponente) Then
            .AppendFormat("   AND {0} = '{1}'", Entidades.VentaProductoFormula.Columnas.IdProductoComponente.ToString(), idProductoComponente)
         End If
         If idFormula <> 0 Then
            .AppendFormat("   AND {0} =  {1} ", Entidades.VentaProductoFormula.Columnas.IdFormula.ToString(), idFormula)
         End If
      End With
      Execute(myQuery)
   End Sub

   Private Sub SelectTexto(stb As StringBuilder)
      With stb
         .AppendFormatLine("SELECT VPF.*, VPF.PrecioVenta * VPF.Cantidad AS ImporteVenta")
         .AppendFormatLine("  FROM {0} AS VPF", Entidades.VentaProductoFormula.NombreTabla)
      End With
   End Sub

   Public Function VentasProductosFormulas_GA(idSucursal As Integer, idTipoComprobante As String, letra As String, centroEmisor As Integer, numeroComprobante As Long,
                                              idProducto As String, orden As Integer) As DataTable
      Return VentasProductosFormulas_G(idSucursal, idTipoComprobante, letra, centroEmisor, numeroComprobante,
                                       idProducto, orden, idProductoComponente:=Nothing, idFormula:=0)
   End Function
   Private Function VentasProductosFormulas_G(idSucursal As Integer, idTipoComprobante As String, letra As String, centroEmisor As Integer, numeroComprobante As Long,
                                              idProducto As String, orden As Integer, idProductoComponente As String, idFormula As Integer) As DataTable
      Dim myQuery = New StringBuilder()
      With myQuery
         SelectTexto(myQuery)
         .AppendLine(" WHERE 1 = 1")
         If idSucursal > 0 Then
            .AppendFormat("   AND VPF.{0} = {1}", Entidades.VentaProductoFormula.Columnas.IdSucursal.ToString(), idSucursal).AppendLine()
         End If
         If Not String.IsNullOrWhiteSpace(idTipoComprobante) Then
            .AppendFormat("   AND VPF.{0} = '{1}'", Entidades.VentaProductoFormula.Columnas.IdTipoComprobante.ToString(), idTipoComprobante).AppendLine()
         End If
         If Not String.IsNullOrWhiteSpace(letra) Then
            .AppendFormat("   AND VPF.{0} = '{1}'", Entidades.VentaProductoFormula.Columnas.Letra.ToString(), letra).AppendLine()
         End If
         If centroEmisor > 0 Then
            .AppendFormat("   AND VPF.{0} = {1}", Entidades.VentaProductoFormula.Columnas.CentroEmisor.ToString(), centroEmisor).AppendLine()
         End If
         If numeroComprobante > 0 Then
            .AppendFormat("   AND VPF.{0} = {1}", Entidades.VentaProductoFormula.Columnas.NumeroComprobante.ToString(), numeroComprobante).AppendLine()
         End If
         If Not String.IsNullOrWhiteSpace(idProducto) Then
            .AppendFormat("   AND VPF.{0} = '{1}'", Entidades.VentaProductoFormula.Columnas.IdProducto.ToString(), idProducto).AppendLine()
         End If
         If orden > 0 Then
            .AppendFormat("   AND VPF.{0} = {1}", Entidades.VentaProductoFormula.Columnas.Orden.ToString(), orden).AppendLine()
         End If
         If Not String.IsNullOrWhiteSpace(idProductoComponente) Then
            .AppendFormat("   AND VPF.{0} = '{1}'", Entidades.VentaProductoFormula.Columnas.IdProductoComponente.ToString(), idProductoComponente).AppendLine()
         End If
         If idFormula > 0 Then
            .AppendFormat("   AND VPF.{0} = {1}", Entidades.VentaProductoFormula.Columnas.IdFormula.ToString(), idFormula).AppendLine()
         End If

      End With
      Return GetDataTable(myQuery)
   End Function

   Public Function VentasProductosFormulas_G1(idSucursal As Integer, idTipoComprobante As String, letra As String, centroEmisor As Integer, numeroComprobante As Long,
                                              idProducto As String, orden As Integer, idProductoComponente As String, idFormula As Integer) As DataTable
      Return VentasProductosFormulas_G(idSucursal, idTipoComprobante, letra, centroEmisor, numeroComprobante, idProducto, orden, idProductoComponente, idFormula)
   End Function

   Public Overloads Function Buscar(columna As String, valor As String) As DataTable
      columna = "VPF." + columna
      Dim stb As StringBuilder = New StringBuilder()
      With stb
         SelectTexto(stb)
         .AppendFormatLine(" WHERE {0} LIKE '%{0}%'", columna, valor)
      End With
      Return Me.GetDataTable(stb.ToString())
   End Function

End Class