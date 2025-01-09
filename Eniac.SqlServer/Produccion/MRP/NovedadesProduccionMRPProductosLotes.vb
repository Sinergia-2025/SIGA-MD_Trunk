Imports Eniac.Entidades

Public Class NovedadesProduccionMRPProductosLotes
   Inherits Comunes

   Public Sub New(da As Datos.DataAccess)
      MyBase.New(da)
   End Sub

   Public Sub NovedadesProduccionMRPProductosLotes_I(numeroNovedadesProducccion As Integer, codigoOperacion As String, idProducto As String,
                                                     EsProductoNecesario As Boolean, idLotes As String, cantidad As Decimal)
      Dim myQuery = New StringBuilder()
      With myQuery
         .AppendFormatLine("INSERT INTO {0} ({1}, {2}, {3}, {4}, {5}, {6})",
                                 NovedadProduccionMRPProductoLote.NombreTabla,
                                 NovedadProduccionMRPProductoLote.Columnas.NumeroNovedadesProducccion.ToString(),
                                 NovedadProduccionMRPProductoLote.Columnas.CodigoOperacion.ToString(),
                                 NovedadProduccionMRPProductoLote.Columnas.IdProducto.ToString(),
                                 NovedadProduccionMRPProductoLote.Columnas.EsProductoNecesario.ToString(),
                                 NovedadProduccionMRPProductoLote.Columnas.IdLote.ToString(),
                                 NovedadProduccionMRPProductoLote.Columnas.Cantidad.ToString())
         .AppendFormatLine(" VALUES ({0}, '{1}', '{2}', {3}, '{4}', {5})",
                                 numeroNovedadesProducccion,
                                 codigoOperacion,
                                 idProducto,
                                 GetStringFromBoolean(EsProductoNecesario),
                                 idLotes,
                                 cantidad)
      End With
      Execute(myQuery)
   End Sub

   Private Sub SelectTexto(stb As StringBuilder)
      With stb
         .AppendFormatLine("SELECT NPL.*", Entidades.NovedadProduccionMRPProductoLote.NombreTabla)
         .AppendFormatLine("  FROM {0} AS NPL", Entidades.NovedadProduccionMRPProductoLote.NombreTabla)
      End With
   End Sub


   Public Function NovedadesProduccionMRPProductosLotes_G(numeroNovedadesProducccion As Integer, codigoOperacion As String, idProducto As String, idLotes As String) As DataTable
      Dim myQuery = New StringBuilder()
      With myQuery
         SelectTexto(myQuery)
         .AppendLine(" WHERE 1 = 1")
         If numeroNovedadesProducccion > 0 Then
            .AppendFormatLine("   AND NPL.NumeroNovedadesProducccion = {0}", numeroNovedadesProducccion)
         End If
         If Not String.IsNullOrWhiteSpace(codigoOperacion) Then
            .AppendFormatLine("   AND NPL.CodigoOperacion = '{0}'", codigoOperacion)
         End If
         If Not String.IsNullOrWhiteSpace(idProducto) Then
            .AppendFormatLine("   AND NPL.IdProducto = '{0}'", idProducto)
         End If
         If Not String.IsNullOrWhiteSpace(idLotes) Then
            .AppendFormatLine("   AND NPL.IdLote = '{0}'", idLotes)
         End If
         .AppendFormatLine(" ORDER BY NPL.IdLote")
      End With
      Return GetDataTable(myQuery)
   End Function
   Public Function NovedadesProduccionMRPProductosLotes_GA(numeroNovedadesProducccion As Integer, codigoOperacion As String, idProducto As String) As DataTable
      Return NovedadesProduccionMRPProductosLotes_G(numeroNovedadesProducccion, codigoOperacion, idProducto, idLotes:=String.Empty)
   End Function

   Public Function NovedadesProduccionMRPProductosLotes_G1(numeroNovedadesProducccion As Integer, codigoOperacion As String, idProducto As String, idLotes As String) As DataTable
      Return NovedadesProduccionMRPProductosLotes_G(numeroNovedadesProducccion, codigoOperacion, idProducto, idLotes)
   End Function


End Class