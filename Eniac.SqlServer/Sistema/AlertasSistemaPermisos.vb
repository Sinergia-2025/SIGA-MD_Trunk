Imports Eniac.Entidades.SistemaE
Namespace Sistema
   Public Class AlertasSistemaPermisos
      Inherits Comunes

      Public Sub New(da As Datos.DataAccess)
         MyBase.New(da)
      End Sub

      Public Sub AlertasSistemaPermisos_I(idAlertaSistema As Integer, idFuncion As String)
         Dim myQuery = New StringBuilder()
         With myQuery
            .AppendFormatLine("INSERT INTO {0} (", AlertaSistemaPermiso.NombreTabla)
            .AppendFormatLine("            {0}", AlertaSistemaPermiso.Columnas.IdAlertaSistema.ToString())
            .AppendFormatLine("          , {0}", AlertaSistemaPermiso.Columnas.IdFuncion.ToString())

            .AppendFormatLine(" ) VALUES ( ")

            .AppendFormatLine("             {0} ", idAlertaSistema)
            .AppendFormatLine("          , '{0}'", idFuncion)

            .AppendLine(")")
         End With
         Execute(myQuery)
      End Sub

      Public Sub AlertasSistemaPermisos_U(idAlertaSistema As Integer, idFuncion As String)
         Throw New NotImplementedException()
         ''''Dim myQuery = New StringBuilder()
         ''''With myQuery
         ''''   .AppendFormatLine("UPDATE {0} ", AlertaSistemaPermiso.NombreTabla)
         ''''   '.AppendFormatLine("   SET {0} = '{1}'", AlertaSistemaPermiso.Columnas.CondicionCount.ToString(), condicionCount.ToString())
         ''''   .AppendFormatLine(" WHERE {0} =  {1} ", AlertaSistemaPermiso.Columnas.IdAlertaSistema.ToString(), idAlertaSistema)
         ''''   .AppendFormatLine("   AND {0} = '{1}'", AlertaSistemaPermiso.Columnas.IdFuncion.ToString(), idFuncion)
         ''''End With
         ''''Execute(myQuery)
      End Sub

      Public Sub AlertasSistemaPermisos_D(idAlertaSistema As Integer, idFuncion As String)
         Dim myQuery = New StringBuilder()
         With myQuery
            .AppendFormatLine("DELETE FROM {0}", AlertaSistemaPermiso.NombreTabla)
            .AppendFormatLine(" WHERE {0} =  {1} ", AlertaSistemaPermiso.Columnas.IdAlertaSistema.ToString(), idAlertaSistema)
            If Not String.IsNullOrWhiteSpace(idFuncion) Then
               .AppendFormatLine("   AND {0} = '{1}'", AlertaSistemaPermiso.Columnas.IdFuncion.ToString(), idFuncion)
            End If
         End With
         Execute(myQuery)
      End Sub

      Private Sub SelectTexto(stb As StringBuilder)
         With stb
            .AppendFormatLine("SELECT AP.*")
            .AppendFormatLine("     , F.Nombre NombreFuncion, F.IdPadre IdFuncionPadre, FP.Nombre NombreFuncionPadre, F.Posicion, F.Archivo, F.Pantalla")
            .AppendFormatLine("  FROM {0} AS AP", AlertaSistemaPermiso.NombreTabla)
            .AppendFormatLine(" INNER JOIN Funciones F ON F.Id = AP.IdFuncion")
            .AppendFormatLine("  LEFT JOIN Funciones FP ON FP.Id = F.IdPadre")
         End With
      End Sub

      Public Function AlertasSistemaPermisos_GA() As DataTable
         Return AlertasSistemaPermisos_G(idAlertaSistema:=0, idFuncion:=String.Empty)
      End Function
      Public Function AlertasSistemaPermisos_GA(idAlertaSistema As Integer) As DataTable
         Return AlertasSistemaPermisos_G(idAlertaSistema, idFuncion:=String.Empty)
      End Function
      Private Function AlertasSistemaPermisos_G(idAlertaSistema As Integer, idFuncion As String) As DataTable
         Dim myQuery = New StringBuilder()
         With myQuery
            SelectTexto(myQuery)
            .AppendFormatLine(" WHERE 1 = 1")
            If idAlertaSistema <> 0 Then
               .AppendFormatLine("   AND AP.{0} =  {1} ", AlertaSistemaPermiso.Columnas.IdAlertaSistema.ToString(), idAlertaSistema)
            End If
            If Not String.IsNullOrWhiteSpace(idFuncion) Then
               .AppendFormatLine("   AND AP.{0} = '{1}'", AlertaSistemaPermiso.Columnas.IdFuncion.ToString(), idFuncion)
            End If
         End With
         Return GetDataTable(myQuery)
      End Function

      Public Function AlertasSistemaPermisos_G1(idAlertaSistema As Integer, idFuncion As String) As DataTable
         Return AlertasSistemaPermisos_G(idAlertaSistema, idFuncion)
      End Function

      Public Overloads Function Buscar(columna As String, valor As String) As DataTable
         Return Buscar(columna, valor, Sub(stb) SelectTexto(stb), "AP.")
      End Function

   End Class
End Namespace