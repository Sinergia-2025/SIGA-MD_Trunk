Imports Eniac.Entidades

Public Class ProductosLinks
   Inherits Comunes

   Public Sub New(ByVal da As Eniac.Datos.DataAccess)
      MyBase.New(da)
   End Sub

   Public Sub ProductosLinks_I(IdProducto As String,
                               ItemLink As Integer,
                               Descripcion As String,
                               Link As String,
                               idTipoAdjunto As Integer)

      Dim myQuery As StringBuilder = New StringBuilder()

      With myQuery
         .AppendFormat("INSERT INTO ProductosLinks ({0}, {1}, {2}, {3}, {4})",
                       Entidades.ProductoLinks.Columnas.IdProducto.ToString(),
                       Entidades.ProductoLinks.Columnas.ItemLink.ToString(),
                       Entidades.ProductoLinks.Columnas.Descripcion.ToString(),
                       Entidades.ProductoLinks.Columnas.Link.ToString(),
                       Entidades.ProductoLinks.Columnas.IdTipoAdjunto.ToString()).AppendLine()
         .AppendFormat("     VALUES ('{0}', {1}, '{2}', '{3}', {4})",
                       IdProducto, ItemLink, Descripcion, Link, IIf(idTipoAdjunto = 0, "NULL", idTipoAdjunto))
      End With

      Me.Execute(myQuery.ToString())
   End Sub

   Public Sub ProductosLinks_U(IdProducto As String,
                               ItemLink As Integer,
                               Descripcion As String,
                               Link As String,
                               idTipoAdjunto As Integer)

      Dim myQuery As StringBuilder = New StringBuilder()

      With myQuery
         .AppendLine("UPDATE ProductosLinks ")
         .AppendFormat("   SET {0} = '{1}'", Entidades.ProductoLinks.Columnas.Descripcion.ToString(), Descripcion).AppendLine()
         .AppendFormat("      ,{0} = '{1}'", Entidades.ProductoLinks.Columnas.Link.ToString(), Link).AppendLine()
         .AppendFormat("      ,{0} =  {1} ", Entidades.ProductoLinks.Columnas.IdTipoAdjunto.ToString(), IIf(idTipoAdjunto = 0, "NULL", idTipoAdjunto)).AppendLine()
         .AppendFormat(" WHERE {0} = '{1}'", Entidades.ProductoLinks.Columnas.IdProducto.ToString(), IdProducto)
         .AppendFormat(" AND {0} = {1}", Entidades.ProductoLinks.Columnas.ItemLink.ToString(), ItemLink)
      End With

      Me.Execute(myQuery.ToString())
   End Sub

   Public Sub ProductosLinks_D(IdProducto As String, ItemLink As Integer)

      Dim myQuery As StringBuilder = New StringBuilder()

      With myQuery
         .AppendLine("DELETE FROM ProductosLinks ")
         .AppendFormat(" WHERE {0} = '{1}'", Entidades.Producto.Columnas.IdProducto.ToString(), IdProducto)
         If ItemLink > 0 Then
            .AppendFormat(" AND {0} = {1}", Entidades.ProductoLinks.Columnas.ItemLink.ToString(), ItemLink)
         End If
      End With

      Me.Execute(myQuery.ToString())
   End Sub

   Private Sub SelectTexto(stb As StringBuilder)
      With stb
         .AppendFormat("SELECT PL.*, TA.NombreTipoAdjunto FROM ProductosLinks AS PL LEFT JOIN TiposAdjuntos TA ON PL.IdTipoAdjunto = TA.IdTipoAdjunto").AppendLine()
      End With
   End Sub

   Public Function ProductosLinks_GA(IdProducto As String) As DataTable
      Dim myQuery As StringBuilder = New StringBuilder()
      With myQuery
         Me.SelectTexto(myQuery)

         .AppendFormat(" WHERE {0} = '{1}'", Entidades.Producto.Columnas.IdProducto.ToString(), IdProducto)

         .AppendFormat(" ORDER BY PL.ItemLink")
      End With
      Return Me.GetDataTable(myQuery.ToString())
   End Function

   Public Function ProductosLinks_G1(IdProducto As String, ItemLink As Integer) As DataTable
      Dim myQuery As StringBuilder = New StringBuilder()
      With myQuery
         Me.SelectTexto(myQuery)

         .AppendFormat(" WHERE {0} = '{1}'", Entidades.Producto.Columnas.IdProducto.ToString(), IdProducto)
         .AppendFormat(" AND {0} = {1}", Entidades.ProductoLinks.Columnas.ItemLink.ToString(), ItemLink)

         .AppendFormat(" ORDER BY PL.ItemLink")
      End With
      Return Me.GetDataTable(myQuery.ToString())
   End Function

   Public Overloads Function GetCodigoMaximo(ByVal IdProducto As String) As Integer
      Return Convert.ToInt32(GetCodigoMaximo("ItemLink", "ProductosLinks", " IdProducto = '" & IdProducto & "'"))
   End Function

   'Public Overloads Function GetCodigoMaximo(ByVal Campo As String) As Integer
   '   Dim result As Integer = 0
   '   Dim columnAlias As String = "Maximo"
   '   Dim dt As DataTable = Me.GetDataTable(String.Format("SELECT MAX(ItemLink) AS {0} FROM ProductosLinks WHERE IdProducto = {1}", columnAlias, Campo))
   '   If dt.Rows.Count > 0 AndAlso dt.Columns.Contains(columnAlias) Then
   '      If Not IsDBNull(dt.Rows(0)(columnAlias)) AndAlso Not String.IsNullOrWhiteSpace(dt.Rows(0)(columnAlias).ToString()) Then
   '         If Not Integer.TryParse(dt.Rows(0)(columnAlias).ToString(), result) Then
   '            result = 0
   '         End If
   '      End If
   '   End If

   '   Return result
   'End Function

End Class