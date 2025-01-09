Public Class HistorialItem

   Private _Cliente As Entidades.Cliente

   Public Sub New(ByVal CLiente As Entidades.Cliente)
      MyBase.New()
      Me.InitializeComponent()

      Me._Cliente = CLiente
   End Sub

   Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
      Me.DialogResult = Windows.Forms.DialogResult.Cancel
      Me.Close()
   End Sub


   Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
      Try
         Me.GrabarItem()

         Me.DialogResult = Windows.Forms.DialogResult.OK

         Me.Close()
      Catch ex As Exception
         Me.DialogResult = Windows.Forms.DialogResult.Cancel
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub GrabarItem()
      Dim reg As Reglas.ClientesHistorias = New Reglas.ClientesHistorias()
      Dim en As Entidades.ClienteHistoria = New Entidades.ClienteHistoria()
      en.Cliente = Me._Cliente
      en.Usuario = Eniac.Entidades.Usuario.Actual.Nombre
      en.Item = Me.rtbItem.Text
      en.FechaHoraItem = DateTime.Now
      reg.Insertar(en)
   End Sub

End Class