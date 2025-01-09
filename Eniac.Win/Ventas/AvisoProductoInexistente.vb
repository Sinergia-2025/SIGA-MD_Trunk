Public Class AvisoProductoInexistente
   Private c As Integer = 0
   Private Sub AvisoProductoInexistente_Load(sender As Object, e As EventArgs) Handles MyBase.Load
      Try
         Timer2.Interval = 1000 '1000 por segundo aprox.
         Timer2.Enabled = True
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
      End Try
   End Sub

   Private Sub Timer2_Tick(sender As Object, e As EventArgs) Handles Timer2.Tick
      Try
         c += 1
         My.Computer.Audio.PlaySystemSound(Media.SystemSounds.Exclamation)
         If c = 2 Then  '2 Segundos
            Timer2.Enabled = False
            Me.Close()
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
      End Try

   End Sub

End Class