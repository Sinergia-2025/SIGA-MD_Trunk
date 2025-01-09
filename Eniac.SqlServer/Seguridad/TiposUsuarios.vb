Public Class TiposUsuarios
   Inherits Comunes

   Public Sub New(da As Datos.DataAccess)
      MyBase.New(da)
   End Sub

   Public Sub TiposUsuarios_I(idTipoUsuario As Integer, nombreTipoUsuario As String, esDeProceso As Boolean)
      Dim query As StringBuilder = New StringBuilder()
      With query

         .AppendFormatLine("INSERT INTO TiposUsuarios(")
         .AppendFormatLine("            IdTipoUsuario")
         .AppendFormatLine("           ,NombreTipoUsuario")
         .AppendFormatLine("           ,EsDeProceso")
         .AppendFormatLine(" ) VALUES (")

         .AppendFormatLine("  {0}", idTipoUsuario)
         .AppendFormatLine(",'{0}'", nombreTipoUsuario)
         .AppendFormatLine(", {0} ", GetStringFromBoolean(esDeProceso))
         .AppendLine(")")

      End With
      Me.Execute(query.ToString())
   End Sub

   Public Sub TiposUsuarios_U(idTipoUsuario As Integer, nombreTipoUsuario As String, esDeProceso As Boolean)
      Dim query As StringBuilder = New StringBuilder()

      With query
         .AppendFormatLine("UPDATE TiposUsuarios SET")
         .AppendFormatLine("       NombreTipoUsuario = '{0}'", nombreTipoUsuario)
         .AppendFormatLine("     , EsDeProceso =  {0} ", GetStringFromBoolean(esDeProceso))

         .AppendFormatLine(" WHERE IdTipoUsuario = {0}", idTipoUsuario)
      End With

      Me.Execute(query.ToString())
   End Sub

   Public Sub TiposUsuarios_D(idTipoUsuario As Integer)
      Dim query As StringBuilder = New StringBuilder()

      With query
         .AppendFormat("DELETE FROM TiposUsuarios WHERE IdTipoUsuario = {0}", idTipoUsuario)
      End With

      Me.Execute(query.ToString())
   End Sub

   Private Sub SelectTexto(stb As StringBuilder)
      With stb
         .AppendLine("SELECT C.*")
         .AppendLine("  FROM TiposUsuarios C")
      End With
   End Sub

   Public Function TiposUsuarios_GA() As DataTable
      Dim query As StringBuilder = New StringBuilder()
      With query
         Me.SelectTexto(query)
         .AppendLine("  ORDER BY C.NombreTipoUsuario")
      End With

      Return Me.GetDataTable(query.ToString())
   End Function

   Public Function TiposUsuarios_G1(idTipoUsuario As Integer) As DataTable
      Dim query As StringBuilder = New StringBuilder()
      With query
         Me.SelectTexto(query)
         .AppendFormat(" WHERE IdTipoUsuario = {0}", idTipoUsuario)
      End With

      Return Me.GetDataTable(query.ToString())
   End Function

   Public Overloads Function Buscar(columna As String, valor As String) As DataTable

      'columna = "TND." + columna

      Dim query As StringBuilder = New StringBuilder()
      With query
         Me.SelectTexto(query)
         .AppendLine(" WHERE " & columna & " LIKE '%" & valor & "%'")
      End With

      Return Me.GetDataTable(query.ToString())
   End Function

   Public Overloads Function GetCodigoMaximo() As Integer
      Return Integer.Parse(MyBase.GetCodigoMaximo("IdTipoUsuario", "TiposUsuarios").ToString())
   End Function

End Class