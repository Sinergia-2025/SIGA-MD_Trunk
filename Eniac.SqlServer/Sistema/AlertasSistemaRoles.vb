Imports Eniac.Entidades.SistemaE
Namespace Sistema
   Public Class AlertasSistemaRoles
      Inherits Comunes

      Public Sub New(da As Datos.DataAccess)
         MyBase.New(da)
      End Sub

      Public Sub AlertasSistemaRoles_I(idAlertaSistema As Integer, idRol As String)
         Dim myQuery = New StringBuilder()
         With myQuery
            .AppendFormatLine("INSERT INTO {0} (", AlertaSistemaRol.NombreTabla)
            .AppendFormatLine("            {0}", AlertaSistemaRol.Columnas.IdAlertaSistema.ToString())
            .AppendFormatLine("          , {0}", AlertaSistemaRol.Columnas.IdRol.ToString())

            .AppendFormatLine(" ) VALUES ( ")

            .AppendFormatLine("             {0} ", idAlertaSistema)
            .AppendFormatLine("          , '{0}'", idRol)

            .AppendLine(")")
         End With
         Execute(myQuery)
      End Sub

      Public Sub AlertasSistemaRoles_U(idAlertaSistema As Integer, idRol As String)
         Throw New NotImplementedException()
         ''''Dim myQuery = New StringBuilder()
         ''''With myQuery
         ''''   .AppendFormatLine("UPDATE {0} ", AlertaSistemaRol.NombreTabla)
         ''''   '.AppendFormatLine("   SET {0} = '{1}'", AlertaSistemaRol.Columnas.CondicionCount.ToString(), condicionCount.ToString())
         ''''   .AppendFormatLine(" WHERE {0} =  {1} ", AlertaSistemaRol.Columnas.IdAlertaSistema.ToString(), idAlertaSistema)
         ''''   .AppendFormatLine("   AND {0} = '{1}'", AlertaSistemaRol.Columnas.idRol.ToString(), idRol)
         ''''End With
         ''''Execute(myQuery)
      End Sub

      Public Sub AlertasSistemaRoles_D(idAlertaSistema As Integer, idRol As String)
         Dim myQuery = New StringBuilder()
         With myQuery
            .AppendFormatLine("DELETE FROM {0}", AlertaSistemaRol.NombreTabla)
            .AppendFormatLine(" WHERE {0} =  {1} ", AlertaSistemaRol.Columnas.IdAlertaSistema.ToString(), idAlertaSistema)
            If Not String.IsNullOrWhiteSpace(idRol) Then
               .AppendFormatLine("   AND {0} = '{1}'", AlertaSistemaRol.Columnas.IdRol.ToString(), idRol)
            End If
         End With
         Execute(myQuery)
      End Sub

      Private Sub SelectTexto(stb As StringBuilder)
         With stb
            .AppendFormatLine("SELECT AR.*, R.Nombre NombreRol")
            .AppendFormatLine("  FROM {0} AS AR", AlertaSistemaRol.NombreTabla)
            .AppendFormatLine(" INNER JOIN Roles R ON R.Id = AR.IdRol")
         End With
      End Sub

      Public Function AlertasSistemaRoles_GA() As DataTable
         Return AlertasSistemaRoles_G(idAlertaSistema:=0, idRol:=String.Empty)
      End Function
      Public Function AlertasSistemaRoles_GA(idAlertaSistema As Integer) As DataTable
         Return AlertasSistemaRoles_G(idAlertaSistema, idRol:=String.Empty)
      End Function
      Private Function AlertasSistemaRoles_G(idAlertaSistema As Integer, idRol As String) As DataTable
         Dim myQuery = New StringBuilder()
         With myQuery
            SelectTexto(myQuery)
            .AppendFormatLine(" WHERE 1 = 1")
            If idAlertaSistema <> 0 Then
               .AppendFormatLine("   AND AR.{0} =  {1} ", AlertaSistemaRol.Columnas.IdAlertaSistema.ToString(), idAlertaSistema)
            End If
            If Not String.IsNullOrWhiteSpace(idRol) Then
               .AppendFormatLine("   AND AR.{0} = '{1}'", AlertaSistemaRol.Columnas.IdRol.ToString(), idRol)
            End If
         End With
         Return GetDataTable(myQuery)
      End Function

      Public Function AlertasSistemaRoles_G1(idAlertaSistema As Integer, idRol As String) As DataTable
         Return AlertasSistemaRoles_G(idAlertaSistema, idRol)
      End Function

      Public Overloads Function Buscar(columna As String, valor As String) As DataTable
         Return Buscar(columna, valor, Sub(stb) SelectTexto(stb), "AR.")
      End Function

   End Class
End Namespace