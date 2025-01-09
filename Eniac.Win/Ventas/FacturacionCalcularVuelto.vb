Imports actual = Eniac.Entidades.Usuario.Actual

Public Class FacturacionCalcularVuelto

#Region "Campos"

   Private _publicos As Publicos

   Private _totalComprobante As Decimal

#End Region

#Region "Overrides"

   Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)
      MyBase.OnLoad(e)

      Try

         Me.Cursor = Cursors.WaitCursor

         Me.txtTotalComprobante.Text = Me._totalComprobante.ToString("##,##0.00")

         Me.Cursor = Cursors.Default

         'Me.txtPago.Text = "0.00"
         'Me.txtPago.SelectAll()
         'Me.txtPago.Focus()

      Catch ex As Exception

         Me.Cursor = Cursors.Default
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try

   End Sub

#End Region

#Region "Constructores"

   Public Sub New(ByVal totalComprobante As Decimal)

      Me.InitializeComponent()

      Me._totalComprobante = totalComprobante

   End Sub

#End Region

#Region "Eventos"

   Private Sub FacturacionCalcularVuelto_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyUp
      If e.KeyCode = Keys.Escape Then
         Me.Close()
      End If
   End Sub

   Private Sub tsbSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbSalir.Click
      Me.Close()
   End Sub

   Private Sub txtPago_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtPago.GotFocus
      Me.txtPago.SelectAll()
   End Sub

   Private Sub txtPago_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtPago.KeyUp
      Me.CalcularVuelto()
   End Sub

#End Region

#Region "Metodos"

   Private Sub CalcularVuelto()
      Dim Vuelto As Decimal
      Vuelto = Decimal.Parse("0" & Me.txtPago.Text.Replace("-", "")) - Me._totalComprobante
      Me.txtVuelto.Text = Vuelto.ToString("##,##0.00")
   End Sub

#End Region

End Class