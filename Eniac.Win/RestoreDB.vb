Imports System.Threading

Public Class RestoreDB

   Private path As String = ""
   Private base As String = ""

#Region "Constructores"

   Public Sub New()

      ' This call is required by the Windows Form Designer.
      InitializeComponent()

   End Sub

#End Region

#Region "Overrides"

   Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)
      MyBase.OnLoad(e)

      Try
         Dim reg As Reglas.Generales = New Reglas.Generales()

         Dim dt As DataTable = reg.GetDBs()

         For Each dr As DataRow In dt.Rows
            Me.tscBase.Items.Add(dr("Name").ToString())
         Next

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

#End Region

#Region "Eventos"

   Private Sub btnBuscarDestino_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscarDestino.Click
      Try
         If Me.ofdBase.ShowDialog() = Windows.Forms.DialogResult.OK Then
            Me.txtBaseOrigen.Text = Me.ofdBase.FileName
            path = Me.txtBaseOrigen.Text
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub



#End Region

#Region "Metodos"

   Private Sub Restaurando()
      Dim val As Integer = 0

      Try
         Dim tr As Thread = New Thread(AddressOf Restaurar)
         tr.Start()

         Me.prbCopiando.Minimum = 0
         Me.prbCopiando.Maximum = 120
         Me.prbCopiando.Value = val

         Me.prbCopiando.Visible = True
         Me.lblCopiando.Visible = True
         Me.Refresh()

         While tr.IsAlive
            If Me.prbCopiando.Maximum = val Then
               val = 0
            End If
            val += 1
            Me.prbCopiando.Value = val
            Thread.Sleep(1000)
            Me.Refresh()
         End While

         Me.prbCopiando.Value = Me.prbCopiando.Maximum

         MessageBox.Show("Restauracion realizada con éxito!!", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      Catch ex As Exception
         Throw ex
      Finally
         Me.prbCopiando.Visible = False
         Me.lblCopiando.Visible = False
         Me.Refresh()
      End Try
   End Sub

   Private Sub Restaurar()
      Dim cl As Reglas.Generales = New Reglas.Generales()
      Dim oGen As Entidades.General = New Entidades.General()

      'realizo restauracion de la base principal
      oGen.Path = path
      oGen.Base = base
      cl.RestoreEn(oGen)

   End Sub

#End Region

   Private Sub tsbCerrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbCerrar.Click
      Me.Close()
   End Sub

   Private Sub tsbRestore_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbRestore.Click
      Try
         Me.tsbRestore.Enabled = False
         If String.IsNullOrEmpty(Me.tscBase.Text) Then
            MessageBox.Show("Debe seleccionar una Base de datos.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
         End If

         If String.IsNullOrEmpty(Me.txtBaseOrigen.Text) Then
            MessageBox.Show("Debe seleccionar un archivo a Restaurar.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
         End If

         If MessageBox.Show("Esta seguro de Restaurar la base " + Me.tscBase.Text + " con el backup " + Me.txtBaseOrigen.Text + "?", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.No Then
            Exit Sub
         End If

         Me.Restaurando()
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      Finally
         Me.tsbRestore.Enabled = True
      End Try
   End Sub

   Private Sub tscBase_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tscBase.SelectedIndexChanged
      Try
         base = Me.tscBase.Text
         Me.Text = "Restaurando " + base
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

End Class