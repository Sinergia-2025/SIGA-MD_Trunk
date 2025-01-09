Public Class Usuarios
   Inherits Comunes

   Public Sub New(da As Datos.DataAccess)
      MyBase.New(da)
   End Sub

   Public Sub Usuarios_I(id As String,
                         nombre As String,
                         clave As String,
                         correoElectronico As String,
                         fechaUltimaModContraseña As Date,
                         activo As Boolean,
                         nivelAutorizacion As Short,
                         mailServidorSMTP As String,
                         mailPuertoSalida As Integer,
                         mailDireccion As String,
                         mailUsuario As String,
                         mailPassword As String,
                         mailRequiereSSL As Boolean,
                         mailRequiereAutenticacion As Boolean,
                         mailCantxHora As Integer,
                         mailCantxMinuto As Integer,
                         utilizaComoPredeterminado As Boolean,
                         tipousuario As Integer)
      Dim stb = New StringBuilder()
      With stb
         .AppendLine("INSERT INTO Usuarios")
         .AppendLine("           (Id")
         .AppendLine("           ,Nombre")
         .AppendLine("           ,Clave")
         .AppendLine("           ,CorreoElectronico")
         .AppendLine("           ,FechaUltimaModContraseña")
         .AppendLine("           ,Activo")
         .AppendLine("           ,TipoUsuario")
         .AppendLine("           ,NivelAutorizacion")
         .AppendLine("           ,MailServidorSMTP")
         .AppendLine("           ,MailPuertoSalida")
         .AppendLine("           ,MailDireccion")
         .AppendLine("           ,MailUsuario")
         .AppendLine("           ,MailPassword")
         .AppendLine("           ,MailRequiereSSL")
         .AppendLine("           ,MailRequiereAutenticacion")
         .AppendLine("           ,MailCantxHora")
         .AppendLine("           ,MailCantxMinuto")
         .AppendLine("           ,UtilizaComoPredeterminado")
         .AppendLine(" )    VALUES")
         .AppendFormatLine("           ('{0}'", id)
         .AppendFormatLine("           ,'{0}'", nombre)
         .AppendFormatLine("           ,'{0}'", clave)
         .AppendFormatLine("           ,'{0}'", correoElectronico)
         .AppendFormatLine("           ,'{0}'", fechaUltimaModContraseña.ToString("yyyyMMdd HH:mm:ss"))
         .AppendFormatLine("           ,'{0}'", activo)
         .AppendFormatLine("           ,'{0}'", tipousuario)
         .AppendFormatLine("           , {0} ", nivelAutorizacion)
         .AppendFormatLine("      ,'{0}'", mailServidorSMTP)
         .AppendFormatLine("      ,'{0}'", mailPuertoSalida)
         .AppendFormatLine("      ,'{0}'", mailDireccion)
         .AppendFormatLine("      ,'{0}'", mailUsuario)
         .AppendFormatLine("      ,'{0}'", mailPassword)
         .AppendFormatLine("      ,'{0}'", mailRequiereSSL)
         .AppendFormatLine("      ,'{0}'", mailRequiereAutenticacion)
         If mailCantxHora <> 0 Then
            .AppendFormatLine("      ,{0}", mailCantxHora)
         Else
            .AppendLine("   ,Null")
         End If
         If mailCantxMinuto <> 0 Then
            .AppendFormatLine("      ,{0}", mailCantxMinuto)
         Else
            .AppendLine("   ,Null")
         End If

         .AppendFormatLine("      ,'{0}'", utilizaComoPredeterminado)
         .AppendLine("  )")
      End With

      Me.Execute(stb.ToString())
   End Sub

   Public Sub Usuarios_U(id As String,
                         nombre As String,
                         clave As String,
                         correoElectronico As String,
                         fechaUltimaModContraseña As Date,
                         activo As Boolean,
                         nivelAutorizacion As Short,
                         mailServidorSMTP As String,
                         mailPuertoSalida As Integer,
                         mailDireccion As String,
                         mailUsuario As String,
                         mailPassword As String,
                         mailRequiereSSL As Boolean,
                         mailRequiereAutenticacion As Boolean,
                         mailCantxHora As Integer,
                         mailCantxMinuto As Integer,
                         utilizaComoPredeterminado As Boolean,
                         tipousuario As Integer)
      Dim stb = New StringBuilder()
      With stb
         .AppendLine("UPDATE Usuarios")
         .AppendFormatLine("   SET ")
         .AppendFormatLine("      Nombre = '{0}'", nombre)
         .AppendFormatLine("      ,Clave = '{0}'", clave)
         .AppendFormatLine("      ,CorreoElectronico = '{0}'", correoElectronico)
         .AppendFormatLine("      ,FechaUltimaModContraseña = '{0}'", fechaUltimaModContraseña.ToString("yyyyMMdd HH:mm:ss"))
         .AppendFormatLine("      ,Activo = '{0}'", activo)
         .AppendFormatLine("      ,TipoUsuario = '{0}'", tipousuario)
         .AppendFormatLine("      ,NivelAutorizacion = {0}", nivelAutorizacion)
         .AppendFormatLine("      ,MailServidorSMTP = '{0}'", mailServidorSMTP)
         .AppendFormatLine("      ,MailPuertoSalida = '{0}'", mailPuertoSalida)
         .AppendFormatLine("      ,MailDireccion = '{0}'", mailDireccion)
         .AppendFormatLine("      ,MailUsuario = '{0}'", mailUsuario)
         .AppendFormatLine("      ,MailPassword = '{0}'", mailPassword)
         .AppendFormatLine("      ,MailRequiereSSL = '{0}'", mailRequiereSSL)
         .AppendFormatLine("      ,MailRequiereAutenticacion = '{0}'", mailRequiereAutenticacion)
         .AppendFormatLine("      ,MailCantxHora = {0}", mailCantxHora)
         .AppendFormatLine("      ,MailCantxMinuto = {0}", mailCantxMinuto)
         .AppendFormatLine("      ,UtilizaComoPredeterminado = '{0}'", utilizaComoPredeterminado)
         .AppendFormatLine(" WHERE Id = '{0}'", id)
      End With

      Me.Execute(stb.ToString())
   End Sub

   Public Sub Usuarios_D(id As String)
      Dim stb = New StringBuilder()

      'por las dudas antes de eliminar el usuario elimino la tabla de UsuariosClaves
      With stb
         .Length = 0
         .Append("DELETE FROM UsuariosClaves")
         .AppendFormat(" WHERE IdUsuario = '{0}'", id)
      End With

      Me.Execute(stb.ToString())

      'aca elimino el usuario
      With stb
         .Length = 0
         .Append("DELETE FROM Usuarios")
         .AppendFormat(" WHERE Id = '{0}'", id)
      End With

      Me.Execute(stb.ToString())
   End Sub

   Public Sub ActualizaPassword(id As String, claveNueva As String)

      Dim stb = New StringBuilder()
      With stb
         .Length = 0
         .AppendLine("UPDATE Usuarios")
         .AppendFormatLine("   SET Clave = '{0}'", claveNueva)
         .AppendFormatLine("      ,FechaUltimaModContraseña = '{0}'", Me.ObtenerFecha(Date.Now, True))
         .AppendFormatLine(" WHERE Id = '{0}'", id)
      End With

      Me.Execute(stb.ToString())

   End Sub

   Public Sub ActualizarMail(id As String,
                             mailServidorSMTP As String,
                             mailPuertoSalida As Integer,
                             mailDireccion As String,
                             mailUsuario As String,
                             mailPassword As String,
                             mailRequiereSSL As Boolean,
                             mailRequiereAutenticacion As Boolean,
                             mailCantxHora As Integer,
                             mailCantxMinuto As Integer,
                             utilizaComoPredeterminado As Boolean)
      Dim stb = New StringBuilder()
      With stb
         .AppendLine("UPDATE Usuarios")
         .AppendFormatLine("   SET ")
         .AppendFormatLine("      MailServidorSMTP = '{0}'", mailServidorSMTP)
         .AppendFormatLine("      ,MailPuertoSalida = '{0}'", mailPuertoSalida)
         .AppendFormatLine("      ,MailDireccion = '{0}'", mailDireccion)
         .AppendFormatLine("      ,MailUsuario = '{0}'", mailUsuario)
         .AppendFormatLine("      ,MailPassword = '{0}'", mailPassword)
         .AppendFormatLine("      ,MailRequiereSSL = '{0}'", mailRequiereSSL)
         .AppendFormatLine("      ,MailRequiereAutenticacion = '{0}'", mailRequiereAutenticacion)
         .AppendFormatLine("      ,MailCantxHora = {0}", mailCantxHora)
         .AppendFormatLine("      ,MailCantxMinuto = {0}", mailCantxMinuto)
         .AppendFormatLine("      ,UtilizaComoPredeterminado = '{0}'", utilizaComoPredeterminado)
         .AppendFormatLine(" WHERE Id = '{0}'", id)
      End With

      Execute(stb)
   End Sub

   Private Sub SelectTexto(stb As StringBuilder)
      With stb
         .Append("SELECT U.*, TU.NombreTipoUsuario")
         .Append("  FROM Usuarios U ")
         .Append("  INNER JOIN TiposUsuarios AS TU ON U.TipoUsuario = TU.idTipoUsuario")
      End With
   End Sub

   Public Function Usuarios_GA(activo As Boolean?, usuarioActual As String) As DataTable
      Dim stb = New StringBuilder()
      With stb
         SelectTexto(stb)
         .AppendFormatLine(" WHERE 1 = 1")
         If activo.HasValue Then
            .AppendFormat("   AND (U.Activo = {0}", GetStringFromBoolean(activo.Value))
            If Not String.IsNullOrWhiteSpace(usuarioActual) Then
               .AppendFormat("        OR U.Id = '{0}'", usuarioActual)
            End If
            .AppendFormatLine(")")
         End If
         .Append("  ORDER BY U.Nombre")
      End With

      Return GetDataTable(stb)
   End Function

   Public Function Usuarios_G1(id As String) As DataTable
      Dim stb = New StringBuilder()
      With stb
         Me.SelectTexto(stb)
         .AppendFormat(" WHERE U.Id = '{0}'", id)
      End With

      Return Me.GetDataTable(stb.ToString())
   End Function

   Public Function GetUnoConMail(idUsuario As String) As DataTable
      Dim stb = New StringBuilder()
      With stb
         .AppendLine("SELECT U.*")
         .AppendLine("  FROM Usuarios U ")
         .AppendFormatLine(" WHERE U.Id = '{0}'", idUsuario)
      End With

      Return Me.GetDataTable(stb.ToString())
   End Function

   Public Function Buscar(columna As String, valor As String) As DataTable
      columna = "U." + columna
      'If columna = "D.NombreLocalidad" Then columna = columna.Replace("D.", "L.")
      Dim stb = New StringBuilder()
      With stb
         Me.SelectTexto(stb)
         .AppendFormatLine("  WHERE {0} LIKE '%{1}%'", columna, valor)
      End With
      Return Me.GetDataTable(stb.ToString())
   End Function

   Public Function EsUsuarioActivo(usuario As String) As Boolean
      Dim stbQuery = New StringBuilder()

      With stbQuery
         .AppendFormat("SELECT U.Activo FROM Usuarios U WHERE U.Id = '{0}'", usuario)
      End With

      Dim dt As DataTable = Me.GetDataTable(stbQuery.ToString())

      If dt.Rows.Count > 0 Then
         If Boolean.Parse(dt.Rows(0)("Activo").ToString()) Then
            Return True
         End If
      End If
      Return False
   End Function

   Public Overloads Function ObtenerFunciones(usuario As String, sucursal As Integer, padre As String) As DataTable
      Dim stbQuery = New StringBuilder()
      With stbQuery
         .Append(" SELECT F.*")
         .Append(" FROM Funciones F, RolesFunciones RF, UsuariosRoles UR  ")
         .Append(" WHERE UR.IdRol = RF.IdRol ")
         .Append(" AND RF.IdFuncion = F.Id ")
         .Append(" AND UR.IdUsuario = '" & usuario & "'")
         .Append(" AND UR.IdSucursal = " & sucursal.ToString() & "")
         If String.IsNullOrEmpty(padre) Then
            .Append(" AND F.IdPadre is null ")
         Else
            .Append(" AND F.IdPadre = '" & padre & "'")
         End If
         .Append(" ORDER BY Posicion Asc")
      End With
      Return GetDataTable(stbQuery)
   End Function

   Public Overloads Function ObtenerFuncionesParaMenu(usuario As String, sucursal As Integer) As DataTable
      Dim stbQuery = New StringBuilder()
      With stbQuery
         .AppendFormatLine("SELECT F.*, CONVERT(bit, 0) Procesado")
         .AppendFormatLine("  FROM Funciones AS F")
         .AppendFormatLine(" WHERE EXISTS(SELECT RF.IdFuncion")
         .AppendFormatLine("                FROM UsuariosRoles AS UR")
         .AppendFormatLine("               INNER JOIN RolesFunciones AS RF ON UR.IdRol = RF.IdRol")
         .AppendFormatLine("         WHERE RF.IdFuncion = F.Id")
         .AppendFormatLine("                 AND UR.IdUsuario = '{0}'", usuario)
         .AppendFormatLine("                 AND UR.IdSucursal = {0})", sucursal)
         '.AppendFormatLine("  FROM UsuariosRoles AS UR")
         '.AppendFormatLine(" INNER JOIN RolesFunciones AS RF ON UR.IdRol = RF.IdRol")
         '.AppendFormatLine(" INNER JOIN Funciones AS F ON RF.IdFuncion = F.Id")
         '.AppendFormatLine(" WHERE UR.IdUsuario = '{0}'", usuario)
         '.AppendFormatLine("   AND UR.IdSucursal = {0}", sucursal)
         .AppendFormatLine(" ORDER BY IdPadre, Posicion Asc")
      End With
      Return GetDataTable(stbQuery)
   End Function

   Public Function UsuarioEsDeProceso(idUsuario As String) As Boolean
      Dim stb = New StringBuilder()
      With stb
         .AppendFormatLine("SELECT 1")
         .AppendFormatLine("  FROM Usuarios U")
         .AppendFormatLine(" INNER JOIN TiposUsuarios TU ON TU.IdTipoUsuario = U.TipoUsuario")
         .AppendFormatLine(" WHERE U.Id = '{0}'", idUsuario)
         .AppendFormatLine("   AND TU.EsDeProceso = 'True'")
      End With
      Return GetDataTable(stb).Count > 0
   End Function

End Class