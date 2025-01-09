Public Class CategoriasMercadoLibre
   Inherits Comunes

   Public Sub New(ByVal da As Eniac.Datos.DataAccess)
      MyBase.New(da)
   End Sub

   Public Sub CategoriasMercadoLibre_I(idCategoria As String,
                                       nombreCategoria As String,
                                       activoCategoria As Integer)
      Dim myQuery As StringBuilder = New StringBuilder()
      With myQuery
         .AppendFormat("INSERT INTO {0} ({1}, {2}, {3})",
                       Entidades.CategoriasMercadoLibre.NombreTabla,
                       Entidades.CategoriasMercadoLibre.Columnas.IdCategoria.ToString(),
                       Entidades.CategoriasMercadoLibre.Columnas.NombreCategoria.ToString(),
                       Entidades.CategoriasMercadoLibre.Columnas.ActivoCategoria.ToString()).AppendLine()
         .AppendFormat("     VALUES ('{1}', '{2}', {3}",
                       Entidades.CategoriasMercadoLibre.NombreTabla, idCategoria, nombreCategoria, GetStringFromBoolean(activoCategoria = Entidades.Publicos.SiNoTodos.SI))
         .AppendLine(")")
      End With
      Me.Execute(myQuery.ToString())
   End Sub

   Public Sub CategoriasMercadoLibre_U(idCategoria As String,
                               nombreCategoria As String,
                               activoCategoria As Integer)
      Dim myQuery As StringBuilder = New StringBuilder()
      With myQuery
         .AppendFormat("UPDATE {0}", Entidades.CategoriasMercadoLibre.NombreTabla).AppendLine()
         .AppendFormat("   SET {0} = '{1}'", Entidades.CategoriasMercadoLibre.Columnas.NombreCategoria.ToString(), nombreCategoria).AppendLine()
         .AppendFormat("   ,{0} = {1}", Entidades.CategoriasMercadoLibre.Columnas.ActivoCategoria.ToString(), activoCategoria).AppendLine()
         .AppendFormat(" WHERE {0} =  {1} ", Entidades.CategoriasMercadoLibre.Columnas.IdCategoria.ToString(), idCategoria).AppendLine()
      End With
      Me.Execute(myQuery.ToString())
   End Sub
   Public Sub CategoriasMercadoLibre_A(Activos As Entidades.Publicos.SiNoTodos)

      Dim myQuery As StringBuilder = New StringBuilder()
      With myQuery.AppendFormat("UPDATE {0}", Entidades.CategoriasMercadoLibre.NombreTabla).AppendLine()
         .AppendFormat("   SET {0} = '{1}'", Entidades.CategoriasMercadoLibre.Columnas.ActivoCategoria.ToString(), GetStringFromBoolean(Activos = Entidades.Publicos.SiNoTodos.SI)).AppendLine()
      End With
      Me.Execute(myQuery.ToString())
   End Sub

   Public Function ExisteCategoria(id As String) As Boolean
      Dim query As StringBuilder = New StringBuilder
      With query
         SelectTexto(query)
         .AppendFormatLine("WHERE IdCategoria = '{0}' ", id)
      End With
      Return Me.GetDataTable(query.ToString()).Rows.Count > 0
   End Function


   Public Sub CategoriasMercadoLibre_D(idCategoria As String)
      Dim myQuery As StringBuilder = New StringBuilder()
      With myQuery
         .AppendFormat("DELETE FROM {0} WHERE {1} = {2}", Entidades.CategoriasMercadoLibre.NombreTabla, Entidades.CategoriasMercadoLibre.Columnas.IdCategoria.ToString(), idCategoria)
      End With
      Me.Execute(myQuery.ToString())
   End Sub

   Private Sub SelectTexto(ByVal stb As StringBuilder)
      With stb
         .AppendFormat("SELECT CML.* FROM {0} AS CML", Entidades.CategoriasMercadoLibre.NombreTabla).AppendLine()
      End With
   End Sub

   Public Function CategoriasMercadoLibre_GA(Activos As Entidades.Publicos.SiNoTodos) As DataTable

      Dim myQuery As StringBuilder = New StringBuilder("")
      With myQuery
         SelectTexto(myQuery)

         If Activos <> Entidades.Publicos.SiNoTodos.TODOS Then
            .AppendFormatLine(" WHERE CML.ActivoCategoria = {0}", GetStringFromBoolean(Activos = Entidades.Publicos.SiNoTodos.SI))
         End If

      End With
      Return Me.GetDataTable(myQuery.ToString())

   End Function

End Class
