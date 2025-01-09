Public Class CartasFechas

   Private _numeroCarta As Integer
   Private _proximaCarta As Integer
   Private _diasAlerta As Integer

   Private _signo As Integer

   Public Sub New(ByVal numeroCarta As Integer, ByVal diasAlerta As Integer, ByVal proximaCarta As Integer)

      InitializeComponent()

      Me._numeroCarta = numeroCarta
      Me._diasAlerta = diasAlerta
      Me._proximaCarta = proximaCarta

   End Sub

   Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)
      MyBase.OnLoad(e)

      If Me._numeroCarta = 5 Or Me._numeroCarta = 52 Then
         Me._signo = 1
      Else
         Me._signo = -1
      End If

      Me.dtpFechaLiquidacion.Value = DateTime.Now

      '  Me.txtDiasAvisoPrevio.Text = Publicos.DiasAvisoProximaCarta.ToString()

      Me.dtpFechaAlertaLlamado.Value = Me.dtpFechaLiquidacion.Value.AddDays(Me._signo * Int32.Parse(Me.txtDiasAvisoPrevio.Text))

      If Me._proximaCarta > 0 Then
         Me.txtDiasAlertaProxCarta.Text = Me._diasAlerta.ToString()
         'Me.dtpFechaAlertaProxCarta.Value = Me.dtpFechaLiquidacion.Value.AddDays(Me._diasAlerta)
         Me.dtpFechaAlertaProxCarta.Value = Date.Now.AddDays(Me._diasAlerta)
      Else
         Me.chbEnlazaProxCarta.Checked = False
         Me.chbEnlazaProxCarta.Enabled = False
      End If

   End Sub

   Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
      Me.DialogResult = Windows.Forms.DialogResult.Yes
      Me.Close()
   End Sub

   Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
      Me.DialogResult = Windows.Forms.DialogResult.Cancel
      Me.Close()
   End Sub

   Private Sub dtpFechaLiquidacion_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpFechaLiquidacion.ValueChanged
      Try
         If String.IsNullOrEmpty(Me.txtDiasAvisoPrevio.Text) Then
            Me.txtDiasAvisoPrevio.Text = "0"
         End If
         Me.dtpFechaAlertaLlamado.Value = Me.dtpFechaLiquidacion.Value.AddDays(Me._signo * Int32.Parse(Me.txtDiasAvisoPrevio.Text))
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub dtpFechaAlertaLlamado_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpFechaAlertaLlamado.ValueChanged
      Try
         If Me._signo = 1 Then
            Me.txtDiasAvisoPrevio.Text = Me.dtpFechaAlertaLlamado.Value.Subtract(Me.dtpFechaLiquidacion.Value).Days.ToString()
         Else
            Me.txtDiasAvisoPrevio.Text = Me.dtpFechaLiquidacion.Value.Subtract(Me.dtpFechaAlertaLlamado.Value).Days.ToString()
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub txtDiasAvisoPrevio_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtDiasAvisoPrevio.Leave
      Try
         If String.IsNullOrEmpty(Me.txtDiasAvisoPrevio.Text) Then
            Me.txtDiasAvisoPrevio.Text = "0"
         End If
         Me.dtpFechaAlertaLlamado.Value = Me.dtpFechaLiquidacion.Value.AddDays(Me._signo * Int32.Parse(Me.txtDiasAvisoPrevio.Text))
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub chbEnlazaProxCarta_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chbEnlazaProxCarta.CheckedChanged
      Me.txtDiasAlertaProxCarta.Enabled = Me.chbEnlazaProxCarta.Checked
      Me.dtpFechaAlertaProxCarta.Enabled = Me.chbEnlazaProxCarta.Checked
   End Sub

   Private Sub dtpFechaAlertaProxCarta_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpFechaAlertaProxCarta.ValueChanged
      Try
         'Me.txtDiasAlertaProxCarta.Text = Me.dtpFechaAlertaProxCarta.Value.Subtract(Me.dtpFechaLiquidacion.Value).Days.ToString()
         Me.txtDiasAlertaProxCarta.Text = Me.dtpFechaAlertaProxCarta.Value.Subtract(Date.Now).Days.ToString()
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub txtDiasAlertaProxCarta_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtDiasAlertaProxCarta.Leave
      Try
         If String.IsNullOrEmpty(Me.txtDiasAlertaProxCarta.Text) Then
            Me.txtDiasAlertaProxCarta.Text = "0"
         End If
         'Me.dtpFechaAlertaProxCarta.Value = Me.dtpFechaLiquidacion.Value.AddDays(Int32.Parse(Me.txtDiasAlertaProxCarta.Text))
         Me.dtpFechaAlertaProxCarta.Value = Date.Now.AddDays(Int32.Parse(Me.txtDiasAlertaProxCarta.Text))
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try

   End Sub

End Class