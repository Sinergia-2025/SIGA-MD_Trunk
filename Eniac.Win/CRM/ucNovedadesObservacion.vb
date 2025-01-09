Option Strict Off
Public Class ucNovedadesObservacion

   Public Property IdCliente As Long?

   Protected Overrides Sub OnLoad(e As EventArgs)
      MyBase.OnLoad(e)
      Try
         Me._publicos = New Publicos()
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
      End Try
   End Sub


   Public Property Observacion() As String
      Get
         Return Me.txtObservacion.Text.Trim()
      End Get
      Set(ByVal value As String)
         Try
            If value <> String.Empty Then
               Me.txtObservacion.Text = value
            Else
               Me.txtObservacion.Text = String.Empty
            End If
            OnSelectedChanged(Nothing)
         Catch ex As Exception
            Me.txtObservacion.Text = String.Empty
            OnSelectedChanged(Nothing)
            MessageBox.Show(String.Format("No se pudo recuperar la observacion: {0}", ex.Message), FindForm().Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
         End Try
      End Set
   End Property


End Class
