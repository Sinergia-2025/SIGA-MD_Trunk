Public Class TiposComprobantesProductos
   Inherits Comunes
   Public Sub New(ByVal da As Eniac.Datos.DataAccess)
      MyBase.New(da)
   End Sub
#Region "Insert/Update/Merge/Delete"

   Public Sub TiposComprobantesProductos_I(idTipoComprobante As String,
                                           idProducto As String,
                                           cantidad As Decimal)
      Dim myQuery As StringBuilder = New StringBuilder()
      With myQuery
         .AppendFormatLine("INSERT INTO  {0} (", Entidades.TipoComprobanteProducto.NombreTabla)
         .AppendFormatLine("             {0} ", Entidades.TipoComprobanteProducto.Columnas.IdTipoComprobante.ToString())
         .AppendFormatLine("           , {0} ", Entidades.TipoComprobanteProducto.Columnas.IdProducto.ToString())
         .AppendFormatLine("           , {0} ", Entidades.TipoComprobanteProducto.Columnas.Cantidad.ToString())
         .AppendFormatLine("           ) VALUES (")
         .AppendFormatLine("            '{0}'", idTipoComprobante)
         .AppendFormatLine("           ,'{0}'", idProducto)
         .AppendFormatLine("           ,'{0}'", cantidad)
         .AppendFormatLine("           )")
      End With
      Me.Execute(myQuery.ToString())
   End Sub
   Public Sub TiposComprobantesProductos_U(idTipoComprobante As String,
                                           idProducto As String,
                                           cantidad As Decimal)
      Dim myQuery As StringBuilder = New StringBuilder()
      With myQuery
         .AppendFormatLine("UPDATE {0}", Entidades.TipoComprobanteProducto.NombreTabla)
         .AppendFormatLine("   SET {0} = '{1}'", Entidades.TipoComprobanteProducto.Columnas.IdProducto.ToString(), idProducto)
         .AppendFormatLine("   SET {0} = '{1}'", Entidades.TipoComprobanteProducto.Columnas.Cantidad.ToString(), cantidad)
         .AppendFormatLine(" WHERE {0} = '{1}'", Entidades.TipoComprobanteProducto.Columnas.IdTipoComprobante.ToString(), idTipoComprobante)
      End With
      Me.Execute(myQuery.ToString())
   End Sub
   Public Sub TiposComprobantesProductos_D(idTipoComprobante As String, idProducto As String)
      Dim myQuery As StringBuilder = New StringBuilder()
      With myQuery
         .AppendFormatLine("DELETE FROM {0} ", Entidades.TipoComprobanteProducto.NombreTabla)
         .AppendFormatLine(" WHERE {0} = '{1}'", Entidades.TipoComprobanteProducto.Columnas.IdTipoComprobante.ToString(), idTipoComprobante)
         If Not String.IsNullOrWhiteSpace(idProducto) Then
            .AppendFormatLine("   AND {0} = '{1}'", Entidades.TipoComprobanteProducto.Columnas.IdProducto.ToString(), idProducto)
         End If
      End With
      Me.Execute(myQuery.ToString())
   End Sub
#End Region
   Private Sub SelectTexto(ByVal stb As StringBuilder)
      With stb
         .AppendFormatLine("SELECT TP.*, P.NombreProducto")
         .AppendFormatLine("  FROM {0} AS TP ", Entidades.TipoComprobanteProducto.NombreTabla)
         .AppendFormatLine(" INNER JOIN Productos AS P ON TP.IdProducto = P.IdProducto ")
      End With
   End Sub
#Region "GetAll"
   Private Function TiposComprobantesProductos_G(idTipoComprobante As String, idproducto As String) As DataTable
      Dim myQuery As StringBuilder = New StringBuilder()
      With myQuery
         Me.SelectTexto(myQuery)
         .AppendLine(" WHERE 1 = 1")
         If idTipoComprobante <> String.Empty Then
            .AppendFormatLine("   AND TP.{0} = '{1}'", Entidades.TipoComprobanteProducto.Columnas.IdTipoComprobante.ToString(), idTipoComprobante)
         End If
         If idproducto <> String.Empty Then
            .AppendFormatLine("   AND TP.{0} = '{1}'", Entidades.TipoComprobanteProducto.Columnas.IdProducto.ToString(), idproducto)
         End If
      End With
      Return Me.GetDataTable(myQuery.ToString())
   End Function
   Public Function TiposComprobantesProductos_GA() As DataTable
      Return TiposComprobantesProductos_G(idTipoComprobante:=String.Empty, idproducto:=String.Empty)
   End Function
   Public Function TiposComprobantesProductos_GA(idTipoComprobante As String) As DataTable
      Return TiposComprobantesProductos_G(idTipoComprobante, idproducto:=String.Empty)
   End Function
   Public Function TiposComprobantesProductos_G1(idTipoComprobante As String, idproducto As String) As DataTable
      Return TiposComprobantesProductos_G(idTipoComprobante, idproducto)
   End Function
   Public Overloads Function Buscar(ByVal columna As String, ByVal valor As String) As DataTable
      columna = "TP." + columna
      Dim stb As StringBuilder = New StringBuilder()
      With stb
         Me.SelectTexto(stb)
         .AppendFormatLine(" WHERE {0} LIKE '%{1}%'", columna, valor)
      End With
      Return Me.GetDataTable(stb.ToString())
   End Function
#End Region

End Class