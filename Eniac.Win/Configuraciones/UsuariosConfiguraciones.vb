Imports actual = Eniac.Entidades.Usuario.Actual
Imports System.Text

Public Class UsuariosConfiguraciones

   Protected Overrides Sub OnLoad(e As EventArgs)
      MyBase.OnLoad(e)
      Try
         'Esta pantalla trae solo los datos del usuario que esta logueado
         Me.lblUsuario.Text = actual.Nombre

         Me.CargoInfo()
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub CargoInfo()
      Dim reg As Reglas.Usuarios = New Reglas.Usuarios()
      Dim us As Entidades.Usuario

      us = reg.GetUnoConMail(actual.Nombre)

      With us.MailConfig
         Me.txtMailDireccion.Text = .Direccion
         Me.txtMailUsuario.Text = .UsuarioMail
         Me.txtMailPassword.Text = .Clave
         Me.txtCantidadMailsPorHora.Text = .CantidadXHora.ToString()
         Me.txtCantidadMailsPorMinuto.Text = .CantidadXMinuto.ToString()
         Me.txtMailServidor.Text = .ServidorSMTP
         Me.txtMailPuertoSalida.Text = .PuertoSalida.ToString()
         Me.chbMailRequiereSSL.Checked = .RequiereSSL
         Me.chbMailRequiereAutenticacion.Checked = .RequiereAutenticacion
         Me.chbUtilizaComoPredeterminado.Checked = .UtilizaComoPredeterminado
      End With

      Me.tsbProbar.Enabled = Me.chbUtilizaComoPredeterminado.Checked
   End Sub

   Private Sub tsbSalir_Click(sender As Object, e As EventArgs) Handles tsbCerrar.Click
      Me.Close()
   End Sub

   Private Sub Grabar()
      Dim reg As Reglas.Usuarios = New Reglas.Usuarios()
      Dim us As Entidades.Usuario

      us = New Entidades.Usuario()

      With us.MailConfig
         us.Id = actual.Nombre
         .Direccion = Me.txtMailDireccion.Text
         .UsuarioMail = Me.txtMailUsuario.Text
         .Clave = Me.txtMailPassword.Text
         Int32.TryParse(Me.txtCantidadMailsPorHora.Text, .CantidadXHora)
         Int32.TryParse(Me.txtCantidadMailsPorMinuto.Text, .CantidadXMinuto)
         .ServidorSMTP = Me.txtMailServidor.Text
         Int32.TryParse(Me.txtMailPuertoSalida.Text, .PuertoSalida)
         .RequiereSSL = Me.chbMailRequiereSSL.Checked
         .RequiereAutenticacion = Me.chbMailRequiereAutenticacion.Checked
         .UtilizaComoPredeterminado = Me.chbUtilizaComoPredeterminado.Checked
      End With

      reg.ActualizarMail(us)

      'luego de grabar atualizo el Actual para que lo tomen el resto de las pantallas, incluido el boton Probar
      Eniac.Entidades.Usuario.Actual.MailConfig = us.MailConfig

   End Sub

   Private Sub tsbProbar_Click(sender As Object, e As EventArgs) Handles tsbProbar.Click
      Try
         Dim ms As Eniac.Win.MailSSS = New Eniac.Win.MailSSS()
         ms.CrearMail("TO", {Me.txtMailDireccion.Text}, "Prueba de envio de mail", "Prueba de envio de mail", Nothing, Nothing)
         ms.EnviarMail()
         MessageBox.Show("Prueba enviada exitosamente.", Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      Catch ex As Exception
         MessageBox.Show(ex.Message, Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Function ValidaCorreo() As Boolean
      'Dim mps As Integer
      'Int32.TryParse(Me.txtMailPuertoSalida.Text, mps)

      'If String.IsNullOrEmpty(Me.txtMailServidor.Text) Or
      '    String.IsNullOrEmpty(Me.txtMailDireccion.Text) Or
      '    String.IsNullOrEmpty(Me.txtMailUsuario.Text) Or
      '    String.IsNullOrEmpty(Me.txtMailPassword.Text) Or
      '    mps = 0 Then
      '   Return False
      'End If

      Return True

   End Function

   Private Sub chbUtilizaComoPredeterminado_CheckedChanged(sender As Object, e As EventArgs) Handles chbUtilizaComoPredeterminado.CheckedChanged
      Try
         Me.tsbProbar.Enabled = Me.chbUtilizaComoPredeterminado.Checked
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub tsbGuardar_Click(sender As Object, e As EventArgs) Handles tsbGuardar.Click
      Try
         If Me.ValidaCorreo() Then
            Me.Cursor = Cursors.WaitCursor
            Me.Grabar()
            Me.Cursor = Cursors.Default
            MessageBox.Show("Se guardo la configuración.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
         End If

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      Finally
         Me.Cursor = Cursors.Default
      End Try
   End Sub

End Class