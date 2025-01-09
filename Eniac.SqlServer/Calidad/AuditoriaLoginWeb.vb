Public Class AuditoriaLoginWeb
   Inherits Comunes

   Public Sub New(da As Eniac.Datos.DataAccess)
      MyBase.New(da)
   End Sub

   Public Sub AuditoriaLoginWeb_I(ByVal en As Entidades.AuditoriaLoginWeb)
      Dim myQuery As StringBuilder = New StringBuilder("")

      With myQuery
         .Length = 0
         .AppendFormat("INSERT INTO CalidadAuditoriaLoginWebPaneles ({0}, {1}, {2}, {3}, {4}, {5}, {6}, {7}, {8}, {9}, {10})",
                          Entidades.AuditoriaLoginWeb.Columnas.Id.ToString(),
                          Entidades.AuditoriaLoginWeb.Columnas.sincronizado.ToString(),
                          Entidades.AuditoriaLoginWeb.Columnas.id_usuario.ToString(),
                          Entidades.AuditoriaLoginWeb.Columnas.nombre_usuario.ToString(),
                          Entidades.AuditoriaLoginWeb.Columnas.ip.ToString(),
                          Entidades.AuditoriaLoginWeb.Columnas.pais_code.ToString(),
                          Entidades.AuditoriaLoginWeb.Columnas.pais.ToString(),
                          Entidades.AuditoriaLoginWeb.Columnas.login.ToString(),
                          Entidades.AuditoriaLoginWeb.Columnas.logout.ToString(),
                          Entidades.AuditoriaLoginWeb.Columnas.navegador.ToString(),
                          Entidades.AuditoriaLoginWeb.Columnas.estado_registro.ToString()).AppendLine()
         .AppendFormat("     VALUES ({0}, '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}', {8}, '{9}', '{10}')",
                          en.Id, en.sincronizado, en.id_usuario, en.nombre_usuario, en.ip, en.pais_code, en.pais,
                          Me.ObtenerFecha(en.login, True), Me.ObtenerFecha(en.logout, True), en.navegador, en.estado_registro)
      End With

      Me.Execute(myQuery.ToString())
   End Sub

   'Public Sub Sectores_U(ByVal en As Entidades.Sector)
   '   Dim myQuery As StringBuilder = New StringBuilder("")

   '   With myQuery
   '      .Length = 0
   '      .AppendLine("UPDATE Sectores ")
   '      .AppendFormat("   SET {0} = '{1}',", Entidades.Sector.Columnas.NombreSector.ToString(), en.NombreSector).AppendLine()
   '      .AppendFormat("       {0} =  {1} ,", Entidades.Sector.Columnas.IdAreaComun.ToString(), IIf(String.IsNullOrWhiteSpace(en.IdAreaComun), "NULL", "'" + en.IdAreaComun + "'")).AppendLine()
   '      .AppendFormat("       {0} = '{1}' ", Entidades.Sector.Columnas.Observaciones.ToString(), en.Observaciones).AppendLine()
   '      .AppendFormat(" WHERE {0} =  {1}  ", Entidades.Sector.Columnas.IdSector.ToString(), en.IdSector)
   '   End With

   '   Me.Execute(myQuery.ToString())
   'End Sub

   Public Sub AuditoriaLoginWeb_D(ByVal id As Long?)
      Dim myQuery As StringBuilder = New StringBuilder("")

      With myQuery
         .AppendLine("DELETE FROM CalidadAuditoriaLoginWebPaneles ")
         .AppendFormat(" WHERE {0} =  {1} ", Entidades.AuditoriaLoginWeb.Columnas.Id.ToString(), id)
      End With

      Me.Execute(myQuery.ToString())
   End Sub

   Private Sub SelectTexto(stb As StringBuilder)
      With stb
         .AppendFormatLine("SELECT * ")
         .AppendFormatLine("  FROM {0} AS CA", Entidades.AuditoriaLoginWeb.NombreTabla)
      End With
   End Sub

   Public Function AuditoriaLoginWeb_GA() As DataTable
      Dim myQuery As StringBuilder = New StringBuilder("")
      With myQuery
         Me.SelectTexto(myQuery)
         .AppendFormat(" ORDER BY {0}.{1}", "CA", Entidades.AuditoriaLoginWeb.Columnas.Id.ToString())
      End With
      Return Me.GetDataTable(myQuery.ToString())
   End Function

   Public Function AuditoriaLoginWeb_G1(ByVal id As Long) As DataTable
      Dim stb As StringBuilder = New StringBuilder("")
      With stb
         Me.SelectTexto(stb)
         .AppendFormat(" WHERE {0}.{1} = {2} ", "CA", Entidades.AuditoriaLoginWeb.Columnas.Id.ToString(), id)
      End With
      Return Me.GetDataTable(stb.ToString())
   End Function

   Public Function GetAuditoriasLoginWeb(Login As DateTime, Logout As DateTime, Usuario As String) As DataTable
      Dim myQuery As StringBuilder = New StringBuilder("")
      With myQuery
         Me.SelectTexto(myQuery)
         .AppendFormat(" WHERE {0}.{1} > '{2}' ", "CA", Entidades.AuditoriaLoginWeb.Columnas.login.ToString(), Me.ObtenerFecha(Login, True))
         .AppendFormat(" AND {0}.{1} < '{2}' ", "CA", Entidades.AuditoriaLoginWeb.Columnas.login.ToString(), Me.ObtenerFecha(Logout, True))
         If Not String.IsNullOrEmpty(Usuario) Then
            .AppendFormat(" AND {0}.{1} = '{2}' ", "CA", Entidades.AuditoriaLoginWeb.Columnas.nombre_usuario.ToString(), Usuario)
         End If
         .AppendFormat(" ORDER BY {0}.{1}", "CA", Entidades.AuditoriaLoginWeb.Columnas.Id.ToString())
      End With
      Return Me.GetDataTable(myQuery.ToString())
   End Function

   Public Function GetUsuariosAuditoriasLoginWeb() As DataTable
      Dim myQuery As StringBuilder = New StringBuilder("")
      With myQuery
         .AppendFormat(" SELECT DISTINCT nombre_usuario FROM CalidadAuditoriaLoginWebPaneles")
      End With
      Return Me.GetDataTable(myQuery.ToString())
   End Function

   Public Overloads Function Buscar(ByVal columna As String, ByVal valor As String) As DataTable
      columna = "S." + columna
      Dim stb As StringBuilder = New StringBuilder("")
      With stb
         Me.SelectTexto(stb)
         .AppendFormat(" WHERE {0} LIKE '%{1}%'", columna, valor).AppendLine()
      End With
      Return Me.GetDataTable(stb.ToString())
   End Function

End Class