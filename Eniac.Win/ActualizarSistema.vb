Option Strict On
Option Explicit On
Imports actual = Eniac.Entidades.Usuario.Actual
Public Class ActualizarSistema

   Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)
      MyBase.OnLoad(e)
   End Sub

   Private Sub btnActualizarClave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnActualizarClave.Click
      Try
         Dim parametro As String = New Ayudantes.Criptografia().DecryptString128Bit(Me.txtClave.Text, "clave")
         Dim valores() As String = parametro.Split(";"c)
         Dim sistema As Entidades.Sistema = New Entidades.Sistema()
         sistema.FechaVencimiento = DateTime.Parse(valores(0))
         sistema.NombreEmpresa = valores(1)
         sistema.Habilitado = True

         Dim para As Reglas.Parametros = New Reglas.Parametros()
         para.SetValor(actual.Sucursal.IdEmpresa, "VENCIMIENTOSISTEMA", Me.txtClave.Text)
         MessageBox.Show("Su clave ha sido actualizada exitosamente, la nueva fecha de vencimiento es " + sistema.FechaVencimiento.ToString("dd/MM/yyyy") + ".", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
         para.Borrar(New Entidades.Parametro() With {.IdEmpresa = actual.Sucursal.IdEmpresa, .IdParametro = Entidades.Parametro.Parametros.FACTURACIONUTILIZAMONEDADOLAR.ToString()})
         Me.DialogResult = Windows.Forms.DialogResult.OK
      Catch ex As Exception
         MessageBox.Show("La clave ingresa es incorrecto, cambiela y vuelva a probar.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
         Me.DialogResult = Windows.Forms.DialogResult.Cancel
      End Try

   End Sub

   Private Sub btnCopiarAlPortapapeles_Click(sender As Object, e As EventArgs) Handles btnCopiarAlPortapapeles.Click
      Try
         My.Computer.Clipboard.SetText(Me.txtClaveActual.Text)
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Public Sub SetClaveActual(claveActual As String)
      Me.txtClaveActual.Text = claveActual
   End Sub

End Class