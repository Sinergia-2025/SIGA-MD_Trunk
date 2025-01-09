Imports Eniac.Entidades.SistemaE
Namespace Sistema
   Public Class AlertasSistemaUsuarios
      Inherits Comunes

      Public Sub New(da As Datos.DataAccess)
         MyBase.New(da)
      End Sub

      Public Sub AlertasSistemaUsuarios_I(idAlertaSistema As Integer, idUsuario As String)
         Dim myQuery = New StringBuilder()
         With myQuery
            .AppendFormatLine("INSERT INTO {0} (", AlertaSistemaUsuario.NombreTabla)
            .AppendFormatLine("            {0}", AlertaSistemaUsuario.Columnas.IdAlertaSistema.ToString())
            .AppendFormatLine("          , {0}", AlertaSistemaUsuario.Columnas.IdUsuario.ToString())

            .AppendFormatLine(" ) VALUES ( ")

            .AppendFormatLine("             {0} ", idAlertaSistema)
            .AppendFormatLine("          , '{0}'", idUsuario)

            .AppendLine(")")
         End With
         Execute(myQuery)
      End Sub

      Public Sub AlertasSistemaUsuarios_U(idAlertaSistema As Integer, idUsuario As String)
         Throw New NotImplementedException()
         ''''Dim myQuery = New StringBuilder()
         ''''With myQuery
         ''''   .AppendFormatLine("UPDATE {0} ", AlertaSistemaUsuario.NombreTabla)
         ''''   '.AppendFormatLine("   SET {0} = '{1}'", AlertaSistemaUsuario.Columnas.CondicionCount.ToString(), condicionCount.ToString())
         ''''   .AppendFormatLine(" WHERE {0} =  {1} ", AlertaSistemaUsuario.Columnas.IdAlertaSistema.ToString(), idAlertaSistema)
         ''''   .AppendFormatLine("   AND {0} = '{1}'", AlertaSistemaUsuario.Columnas.idUsuario.ToString(), idUsuario)
         ''''End With
         ''''Execute(myQuery)
      End Sub

      Public Sub AlertasSistemaUsuarios_D(idAlertaSistema As Integer, idUsuario As String)
         Dim myQuery = New StringBuilder()
         With myQuery
            .AppendFormatLine("DELETE FROM {0}", AlertaSistemaUsuario.NombreTabla)
            .AppendFormatLine(" WHERE {0} =  {1} ", AlertaSistemaUsuario.Columnas.IdAlertaSistema.ToString(), idAlertaSistema)
            If Not String.IsNullOrWhiteSpace(idUsuario) Then
               .AppendFormatLine("   AND {0} = '{1}'", AlertaSistemaUsuario.Columnas.IdUsuario.ToString(), idUsuario)
            End If
         End With
         Execute(myQuery)
      End Sub

      Private Sub SelectTexto(stb As StringBuilder)
         With stb
            .AppendFormatLine("SELECT AU.*, U.Nombre NombreUsuario")
            .AppendFormatLine("  FROM {0} AS AU", AlertaSistemaUsuario.NombreTabla)
            .AppendFormatLine(" INNER JOIN Usuarios U ON U.Id = AU.IdUsuario")
         End With
      End Sub

      Public Function AlertasSistemaUsuarios_GA() As DataTable
         Return AlertasSistemaUsuarios_G(idAlertaSistema:=0, idUsuario:=String.Empty)
      End Function
      Public Function AlertasSistemaUsuarios_GA(idAlertaSistema As Integer) As DataTable
         Return AlertasSistemaUsuarios_G(idAlertaSistema, idUsuario:=String.Empty)
      End Function
      Private Function AlertasSistemaUsuarios_G(idAlertaSistema As Integer, idUsuario As String) As DataTable
         Dim myQuery = New StringBuilder()
         With myQuery
            SelectTexto(myQuery)
            .AppendFormatLine(" WHERE 1 = 1")
            If idAlertaSistema <> 0 Then
               .AppendFormatLine("   AND AU.{0} =  {1} ", AlertaSistemaUsuario.Columnas.IdAlertaSistema.ToString(), idAlertaSistema)
            End If
            If Not String.IsNullOrWhiteSpace(idUsuario) Then
               .AppendFormatLine("   AND AU.{0} = '{1}'", AlertaSistemaUsuario.Columnas.IdUsuario.ToString(), idUsuario)
            End If
         End With
         Return GetDataTable(myQuery)
      End Function

      Public Function AlertasSistemaUsuarios_G1(idAlertaSistema As Integer, idUsuario As String) As DataTable
         Return AlertasSistemaUsuarios_G(idAlertaSistema, idUsuario)
      End Function

      Public Overloads Function Buscar(columna As String, valor As String) As DataTable
         Return Buscar(columna, valor, Sub(stb) SelectTexto(stb), "AU.")
      End Function

   End Class
End Namespace