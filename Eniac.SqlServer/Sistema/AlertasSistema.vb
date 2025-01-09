Imports Eniac.Entidades.SistemaE
Namespace Sistema
   Public Class AlertasSistema
      Inherits Comunes

      Public Sub New(da As Datos.DataAccess)
         MyBase.New(da)
      End Sub

      Public Sub AlertasSistema_I(idAlertaSistema As Integer,
                                  tituloAlerta As String,
                                  consultaAlerta As String,
                                  permisosCondicion As CondicionesPermisoAlerta,
                                  idFuncionClick As String,
                                  parametrosPantalla As String,
                                  utilizaConsultaGenerica As Boolean)
         Dim myQuery = New StringBuilder()
         With myQuery
            .AppendFormatLine("INSERT INTO {0} (", AlertaSistema.NombreTabla)
            .AppendFormatLine("            {0}", AlertaSistema.Columnas.IdAlertaSistema.ToString())
            .AppendFormatLine("          , {0}", AlertaSistema.Columnas.TituloAlerta.ToString())
            .AppendFormatLine("          , {0}", AlertaSistema.Columnas.ConsultaAlerta.ToString())
            .AppendFormatLine("          , {0}", AlertaSistema.Columnas.PermisosCondicion.ToString())
            .AppendFormatLine("          , {0}", AlertaSistema.Columnas.IdFuncionClick.ToString())
            .AppendFormatLine("          , {0}", AlertaSistema.Columnas.ParametrosPantalla.ToString())
            .AppendFormatLine("          , {0}", AlertaSistema.Columnas.UtilizaConsultaGenerica.ToString())

            .AppendFormatLine(" ) VALUES ( ")

            .AppendFormatLine("             {0} ", idAlertaSistema)
            .AppendFormatLine("          , '{0}'", tituloAlerta)
            .AppendFormatLine("          , ''")
            .AppendFormatLine("          , '{0}'", permisosCondicion.ToString())
            .AppendFormatLine("          ,  {0} ", GetStringParaQueryConComillas(idFuncionClick))
            .AppendFormatLine("          , '{0}'", parametrosPantalla)
            .AppendFormatLine("          ,  {0} ", GetStringFromBoolean(utilizaConsultaGenerica))

            .AppendLine(")")
         End With

         Execute(myQuery)
         AlertasSistema_U_Consulta(idAlertaSistema, consultaAlerta)
      End Sub

      Public Sub AlertasSistema_U(idAlertaSistema As Integer,
                                  tituloAlerta As String,
                                  consultaAlerta As String,
                                  permisosCondicion As CondicionesPermisoAlerta,
                                  idFuncionClick As String,
                                  parametrosPantalla As String,
                                  utilizaConsultaGenerica As Boolean)
         Dim myQuery = New StringBuilder()
         With myQuery
            .AppendFormatLine("UPDATE {0} ", AlertaSistema.NombreTabla)
            .AppendFormatLine("   SET {0} = '{1}'", AlertaSistema.Columnas.TituloAlerta.ToString(), tituloAlerta)
            '.AppendFormatLine("     , {0} = '{1}'", AlertaSistema.Columnas.ConsultaAlerta.ToString(), consultaAlerta)
            .AppendFormatLine("     , {0} = '{1}'", AlertaSistema.Columnas.PermisosCondicion.ToString(), permisosCondicion.ToString())
            .AppendFormatLine("     , {0} =  {1} ", AlertaSistema.Columnas.IdFuncionClick.ToString(), GetStringParaQueryConComillas(idFuncionClick))
            .AppendFormatLine("     , {0} = '{1}'", AlertaSistema.Columnas.ParametrosPantalla.ToString(), parametrosPantalla)
            .AppendFormatLine("     , {0} =  {1} ", AlertaSistema.Columnas.UtilizaConsultaGenerica.ToString(), GetStringFromBoolean(utilizaConsultaGenerica))
            .AppendFormatLine(" WHERE {0} =  {1} ", AlertaSistema.Columnas.IdAlertaSistema.ToString(), idAlertaSistema)
         End With
         Execute(myQuery)
         AlertasSistema_U_Consulta(idAlertaSistema, consultaAlerta)
      End Sub

      Public Sub AlertasSistema_U_Consulta(idAlertaSistema As Integer, consultaAlerta As String)
         Dim myQuery = New StringBuilder()

         With myQuery
            .AppendFormatLine("UPDATE {0} ", AlertaSistema.NombreTabla)
            .AppendFormatLine("   SET {0} = @consultaAlerta", AlertaSistema.Columnas.ConsultaAlerta.ToString())
            .AppendFormatLine(" WHERE {0} = @idAlertaSistema", AlertaSistema.Columnas.IdAlertaSistema.ToString())
         End With

         ''Aquí defino el parámetro
         _da.Command.CommandText = myQuery.ToString()
         _da.Command.CommandType = CommandType.Text
         _da.Command.AddParameter("@idAlertaSistema", idAlertaSistema)
         _da.Command.AddParameter("@consultaAlerta", consultaAlerta)
         _da.Command.Connection = _da.Connection

         _da.ExecuteNonQuery(_da.Command)
      End Sub

      Public Sub AlertasSistema_D(idAlertaSistema As Integer)
         Dim myQuery = New StringBuilder()
         With myQuery
            .AppendFormatLine("DELETE FROM {0}", AlertaSistema.NombreTabla)
            .AppendFormatLine(" WHERE {0} =  {1} ", AlertaSistema.Columnas.IdAlertaSistema.ToString(), idAlertaSistema)
         End With
         Execute(myQuery)
      End Sub

      Private Sub SelectTexto(stb As StringBuilder)
         With stb
            .AppendFormatLine("SELECT A.*, F.Nombre NombreFuncionClick")
            .AppendFormatLine("  FROM {0} AS A", AlertaSistema.NombreTabla)
            .AppendFormatLine("  LEFT JOIN Funciones F ON A.IdFuncionClick = F.Id")
         End With
      End Sub

      Public Function AlertasSistema_GA() As DataTable
         Return AlertasSistema_G(idAlertaSistema:=0, idUsuario:=String.Empty)
      End Function
      Public Function AlertasSistema_GA(idUsuario As String) As DataTable
         Return AlertasSistema_G(idAlertaSistema:=0, idUsuario)
      End Function
      Private Function AlertasSistema_G(idAlertaSistema As Integer, idUsuario As String) As DataTable
         Dim myQuery = New StringBuilder()
         With myQuery
            SelectTexto(myQuery)
            If Not String.IsNullOrWhiteSpace(idUsuario) Then
               .AppendFormatLine("  LEFT JOIN AlertasSistemaUsuarios AU ON AU.IdAlertaSistema = A.IdAlertaSistema")
               .AppendFormatLine("  LEFT JOIN AlertasSistemaRoles    AR ON AR.IdAlertaSistema = A.IdAlertaSistema")
               .AppendFormatLine("  LEFT JOIN (SELECT * FROM UsuariosRoles WHERE IdSucursal = 1) UR ON UR.IdRol = AR.IdRol")
            End If
            .AppendFormatLine(" WHERE 1 = 1")
            If idAlertaSistema <> 0 Then
               .AppendFormatLine("   AND A.{0} =  {1} ", AlertaSistema.Columnas.IdAlertaSistema.ToString(), idAlertaSistema)
            End If
            If Not String.IsNullOrWhiteSpace(idUsuario) Then
               .AppendFormatLine("   AND (AU.IdUsuario = '{0}' OR AU.IdUsuario IS NULL)", idUsuario)
               .AppendFormatLine("   AND (UR.IdUsuario = '{0}' OR UR.IdUsuario IS NULL)", idUsuario)
            End If
         End With
         Return GetDataTable(myQuery)
      End Function

      Public Function AlertasSistema_G1(idAlertaSistema As Integer) As DataTable
         Return AlertasSistema_G(idAlertaSistema, idUsuario:=String.Empty)
      End Function

      Public Overloads Function Buscar(columna As String, valor As String) As DataTable
         Return Buscar(columna, valor, Sub(stb) SelectTexto(stb), "A.",
                       New Dictionary(Of String, String) From {{"NombreFuncionClick", "F.Nombre"}})
      End Function

      Public Overloads Function GetCodigoMaximo() As Integer
         Return GetCodigoMaximo(AlertaSistema.Columnas.IdAlertaSistema.ToString(), AlertaSistema.NombreTabla).ToInteger()
      End Function

   End Class
End Namespace