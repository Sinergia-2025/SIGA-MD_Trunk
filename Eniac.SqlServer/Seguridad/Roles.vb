Public Class Roles
   Inherits Comunes

   Public Sub New(da As Datos.DataAccess)
      MyBase.New(da)
   End Sub

   Public Sub Roles_I(id As String, nombre As String, descripcion As String)
      Dim myQuery = New StringBuilder()
      With myQuery
         .AppendFormatLine("INSERT INTO {0} (", Entidades.Rol.NombreTabla)
         .AppendFormatLine("     {0}", Entidades.Rol.Columnas.Id.ToString())
         .AppendFormatLine("  ,  {0}", Entidades.Rol.Columnas.Nombre.ToString())
         .AppendFormatLine("  ,  {0}", Entidades.Rol.Columnas.Descripcion.ToString())
         .AppendFormatLine(" ) VALUES ( ")
         .AppendFormatLine("    '{0}'", id)
         .AppendFormatLine("  , '{0}'", nombre)
         .AppendFormatLine("  , '{0}'", descripcion)
         .AppendFormatLine("  )")
      End With
      Execute(myQuery)
   End Sub

   Public Sub Roles_U(id As String, nombre As String, descripcion As String)
      Dim myQuery = New StringBuilder()
      With myQuery
         .AppendFormatLine("UPDATE {0}", Entidades.Rol.NombreTabla)
         .AppendFormatLine("   SET {0} = '{1}'", Entidades.Rol.Columnas.Nombre.ToString(), nombre)
         .AppendFormatLine("     , {0} = '{1}'", Entidades.Rol.Columnas.Descripcion.ToString(), descripcion)
         .AppendFormatLine(" WHERE {0} = '{1}'", Entidades.Rol.Columnas.Id.ToString(), id)
      End With
      Execute(myQuery)
   End Sub

   Public Sub Roles_D(id As String)
      Dim stb = New StringBuilder()

      With stb
         .AppendFormatLine("DELETE FROM {0}", Entidades.Rol.NombreTabla)
         .AppendFormatLine(" WHERE Id = '{0}' ", id)
      End With

      Execute(stb)
   End Sub

   Private Sub SelectTexto(stb As StringBuilder)
      With stb
         .AppendFormatLine("SELECT R.*")
         .AppendFormatLine("  FROM Roles R")
      End With
   End Sub

   Public Function Roles_GA() As DataTable
      Return Roles_G(id:=String.Empty, idVacioTodos:=True)
   End Function
   Public Function Roles_G1(id As String) As DataTable
      Return Roles_G(id, idVacioTodos:=False)
   End Function

   Public Function Roles_G(id As String, idVacioTodos As Boolean) As DataTable
      Dim stb = New StringBuilder()
      With stb
         SelectTexto(stb)
         .AppendFormatLine(" WHERE 1 = 1")
         If Not String.IsNullOrWhiteSpace(id) And Not idVacioTodos Then
            .AppendFormatLine("   AND R.Id = '{0}'", id)
         End If
         .AppendLine(" ORDER BY R.Id")
      End With

      Return GetDataTable(stb)
   End Function

   Public Overloads Function Buscar(columna As String, valor As String) As DataTable
      Return Buscar(columna, valor, Sub(stb) SelectTexto(stb), "R.")
   End Function

End Class