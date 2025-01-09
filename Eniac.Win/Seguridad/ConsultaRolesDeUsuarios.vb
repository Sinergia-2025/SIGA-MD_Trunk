Public Class ConsultaRolesDeUsuarios

#Region "Overrides"

   Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)
      MyBase.OnLoad(e)

      Me.CargaPantalla()
   End Sub

#End Region

#Region "Metodos"

   Private Sub CargaPantalla()
      Dim oUsu As Reglas.Usuarios = New Reglas.Usuarios()
      With Me.dgvUsuarios
         .DataSource = oUsu.GetAll("CadenaSegura")
      End With
      Me.FormatearGrillaUsuarios()

   End Sub
   Private Sub CargarUsuariosRoles()
      Dim oUsuRol As Reglas.UsuariosRoles = New Reglas.UsuariosRoles()
      With Me.dgvRoles
         If Me.dgvUsuarios.SelectedRows.Count > 0 Then
            .DataSource = oUsuRol.GetRolesdeUsuarios(Me.dgvUsuarios.SelectedRows(0).Cells("Id").Value.ToString())
         End If
      End With
      Me.FormatearGrillaRoles()
   End Sub
   Private Sub FormatearGrillaRoles()
      With Me.dgvRoles
         .Columns("Nombre").HeaderText = "Nombre"
         .Columns("Nombre").Width = 90

         .Columns("IdRol").HeaderText = "Rol"
         .Columns("IdRol").Width = 60

         .Columns("Descripcion").HeaderText = "Descripción"
         .Columns("Descripcion").Width = 130

      End With
   End Sub
   Private Sub FormatearGrillaUsuarios()
      With Me.dgvUsuarios
         .Columns("Id").HeaderText = "Id"
         .Columns("Id").Width = 60

         .Columns("Nombre").HeaderText = "Nombre"
         .Columns("Nombre").Width = 150

         .Columns("Clave").Visible = False
      End With
   End Sub
   Private Sub dgvUsuarios_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgvUsuarios.SelectionChanged
      Me.CargarUsuariosRoles()
   End Sub

#End Region

#Region "Eventos"

   Private Sub tsbSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbSalir.Click
      Me.Close()
   End Sub
   Private Sub tsbRefrescar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbRefrescar.Click
      Me.CargaPantalla()
   End Sub

#End Region

End Class