#Region "Option/Imports"
'Option Strict On
Option Explicit On
Imports Infragistics.Win.UltraWinDataSource
Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win
Imports actual = Eniac.Entidades.Usuario.Actual
#End Region
Public Class CertificadoEntregaObservacion

#Region "Campos"
   Private _Observacion As String
   Private _NroRemito As Long

#End Region

#Region "Propiedades"
   Public ReadOnly Property Observacion() As String
      Get
         Return Me._Observacion

      End Get
   End Property
   Public ReadOnly Property NroRemito() As Long
      Get
         Return Me._NroRemito

      End Get
   End Property
#End Region

#Region "Overrides"

   Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)

      MyBase.OnLoad(e)

      Try


      Catch ex As Exception
         ShowError(ex)
      End Try

   End Sub

   Protected Overrides Function ProcessCmdKey(ByRef msg As Message, keyData As Keys) As Boolean
      If keyData = Keys.F5 Then
         tsbRefrescar.PerformClick()
         Return True
      End If
      Return MyBase.ProcessCmdKey(msg, keyData)
   End Function


#End Region

#Region "Eventos"


#Region "Eventos Toolbar"
   Private Sub tsbRefrescar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbRefrescar.Click
        Try
            RefrescarGrilla()
        Catch ex As Exception
            ShowError(ex)
        End Try
    End Sub


   Private Sub tsbSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbSalir.Click
        Me.Close()
    End Sub
#End Region


#End Region

#Region "Metodos"

   Private Sub RefrescarGrilla()
      Me.txtObservacionCertificado.Text = String.Empty
      Me.txtNroRemito.Text = "0"
   End Sub

   Private Sub tsbGrabar_Click(sender As Object, e As EventArgs) Handles tsbGrabar.Click
      Try
         If Me.txtNroRemito.Text = "0" Or String.IsNullOrEmpty(Me.txtNroRemito.Text.ToString()) Then
            MessageBox.Show("Debe ingresar Nro de Remito del Certificado!!", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)

         Else

            _Observacion = Me.txtObservacionCertificado.Text
            _NroRemito = Long.Parse(Me.txtNroRemito.Text.ToString())

            Me.DialogResult = Windows.Forms.DialogResult.OK
         End If

      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

#End Region

End Class