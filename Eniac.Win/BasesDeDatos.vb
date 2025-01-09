Public Class BasesDeDatos

   Public Sub New()
      InitializeComponent()
   End Sub

   Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)
      MyBase.OnLoad(e)
      Try
         Dim reg As Reglas.Generales = New Reglas.Generales()

         Me.cmbDataBase.DataSource = reg.GetTotasLasDBs(System.Configuration.ConfigurationManager.AppSettings("BaseBackup").ToString())
         Me.cmbDataBase.DisplayMember = "name"
         Me.cmbDataBase.ValueMember = "name"

         cmbDataBase.Focus()

         cmbDataBase.SelectedValue = Ayudantes.Conexiones.Base
         If cmbDataBase.SelectedIndex = -1 Then
            cmbDataBase.SelectedIndex = 0
         End If

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Protected Overrides Function ProcessCmdKey(ByRef msg As Message, keyData As Keys) As Boolean
      If keyData = (Keys.Control Or Keys.B) Or keyData = (Keys.Alt Or Keys.B) Then
         cmbDataBase.DropDownStyle = ComboBoxStyle.DropDown
         cmbDataBase.AutoCompleteMode = Windows.Forms.AutoCompleteMode.SuggestAppend
         cmbDataBase.AutoCompleteSource = AutoCompleteSource.ListItems
         cmbDataBase.Focus()
         Return True
      End If
      Return MyBase.ProcessCmdKey(msg, keyData)
   End Function

   Private Sub btnCambiar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCambiar.Click
      Try
         Ayudantes.Conexiones.Base = Me.cmbDataBase.SelectedValue.ToString()
         My.Computer.FileSystem.WriteAllText("BaseDefecto.txt", Ayudantes.Conexiones.Base, False)
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub
End Class