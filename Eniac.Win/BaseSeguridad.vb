Public Class BaseSeguridad

#Region "Overrides"
   Protected Overrides Sub OnClosing(e As System.ComponentModel.CancelEventArgs)
      MyBase.OnClosing(e)
      If DialogResult = Windows.Forms.DialogResult.OK Or DialogResult = Windows.Forms.DialogResult.Cancel Then
         e.Cancel = False
      Else
         e.Cancel = True
      End If
   End Sub
#End Region

#Region "Eventos"
   Private Sub txtPwd_GotFocus(sender As Object, e As EventArgs) Handles txtPwd.GotFocus
      txtPwd.SelectAll()
   End Sub
   Private Sub txtUsuario_GotFocus(sender As Object, e As EventArgs) Handles txtUsuario.GotFocus
      txtUsuario.SelectAll()
   End Sub

   Private Sub btnLogin_Click(sender As Object, e As EventArgs) Handles btnAceptar.Click
      TryCatched(
      Sub()
         DialogResult = DialogResult.Retry

         If String.IsNullOrWhiteSpace(txtUsuario.Text) Then
            ShowMessage("Debe ingresar un usuario para loguearse")
            txtUsuario.Focus()
         End If

         If String.IsNullOrWhiteSpace(txtPwd.Text) Then
            ShowMessage("Debe ingresar una contraseña para loguearse")
            txtPwd.Focus()
         End If

         If Not ValidarUsuario() Then
            ShowMessage("Usuario Inexistente")
            txtUsuario.Focus()
            Exit Sub
         End If

         If Not ValidarClave() Then
            RegistrarAcceso(False, String.Format("Autorizando a Usuario: {0}. Clave Incorrecta", actual.Nombre))
            ShowMessage("Clave Incorrecta")
            txtPwd.Focus()
            Exit Sub
         End If

         DialogResult = DialogResult.OK

         RegistrarAcceso(True, String.Format("Autorizando a Usuario: {0}. OK !!", actual.Nombre))
         Close()
      End Sub)
   End Sub
   Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
      DialogResult = Windows.Forms.DialogResult.Cancel
   End Sub
#End Region

#Region "Metodos"
   Private Function ValidarUsuario() As Boolean
      Dim rUsuarios = New Reglas.Usuarios()
      Return Not IsNothing(rUsuarios.GetUno(txtUsuario.Text))
   End Function

   Private Function ValidarClave() As Boolean
      Dim rUsuarios = New Reglas.Usuarios()
      Return rUsuarios.EsValido(txtUsuario.Text, txtPwd.Text)
   End Function

   Public Shared Function ControloPermisos(idSucursal As Integer, idUsuario As String, idFuncion1 As String, idFuncion2 As String, idPadre As String) As Boolean
      Dim rUsuario = New Reglas.Usuarios()
      Return If(Not rUsuario.TienePermisos(idUsuario, idSucursal, idFuncion1) AndAlso Not rUsuario.TienePermisos(idUsuario, idSucursal, idFuncion2), ControloPermisos(idSucursal, idUsuario, idFuncion2), True)

   End Function
   Public Shared Function ControloPermisos(idFuncion As String) As Boolean
      Return ControloPermisos(actual.Sucursal.Id, Ayudantes.Common.usuario, idFuncion)
   End Function
   Public Shared Function ControloPermisos(idSucursal As Integer, idUsuario As String, idFuncion As String, idPadre As String) As Boolean
      Return ControloPermisos(idSucursal, idUsuario, idFuncion)
   End Function
   Public Shared Function ControloPermisos(idSucursal As Integer, idUsuario As String, idFuncion As String) As Boolean
      Dim rUsuario = New Reglas.Usuarios()
      Dim tiene = rUsuario.TienePermisos(idUsuario, idSucursal, idFuncion)
      If Not tiene Then
         Using frm = New BaseSeguridad()
            If frm.ShowDialog() = Windows.Forms.DialogResult.OK Then
               tiene = rUsuario.TienePermisos(frm.txtUsuario.Text, idSucursal, idFuncion)
            End If
         End Using
      End If
      Return tiene
   End Function

   Private Sub RegistrarAcceso(fueExitoso As Boolean, comentario As String)
      Dim oUsuarioAcceso = New Entidades.UsuarioAcceso() With
         {
            .IdSucursal = actual.Sucursal.IdSucursal,
            .Usuario = txtUsuario.Text,
            .FechaAcceso = New Reglas.Generales().GetServerDBFechaHora(),
            .NombrePC = My.Computer.Name,
            .Exitoso = fueExitoso,
            .Observacion = comentario
         }
      With oUsuarioAcceso
         Try
            .UsuarioWindows = Environment.UserName.Truncar(100)
         Catch ex As Exception
            .UsuarioWindows = "(error obteniendo usuario windows)"
         End Try
      End With

      Dim rUsuariosAccesos = New Reglas.UsuariosAccesos()
      rUsuariosAccesos.Insertar(oUsuarioAcceso)
   End Sub

#End Region

End Class