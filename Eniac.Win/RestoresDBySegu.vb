Imports System.Threading

Public Class RestoresDBySegu

   Private Shared path As String = ""
   Private Shared base As String = System.Configuration.ConfigurationManager.AppSettings("BaseBackup").ToString()

   Private Shared nombreArchivoSegu As String = ""
   Private Shared pathSegu As String = ""
   Private Shared baseSegu As String = System.Configuration.ConfigurationManager.AppSettings("BaseBackupSegu").ToString()

#Region "Constructores"

   Public Sub New()

      ' This call is required by the Windows Form Designer.
      InitializeComponent()

   End Sub

#End Region

#Region "Overrides"

   Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)
      MyBase.OnLoad(e)
      Me.txtBaseOrigen.Text = path
      Me.txtBaseOrigenSegu.Text = pathSegu
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

   Private Sub btnBuscarDestinoSegu_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscarDestinoSegu.Click
      Try
         If Me.ofdBase.ShowDialog() = Windows.Forms.DialogResult.OK Then
            Me.txtBaseOrigenSegu.Text = Me.ofdBase.FileName
            pathSegu = Me.txtBaseOrigenSegu.Text
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub btnCopiar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCopiar.Click
      Try
         Me.btnCopiar.Enabled = False
         Me.btnCancelar.Enabled = False
         Me.Restaurando()
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      Finally
         Me.btnCopiar.Enabled = True
         Me.btnCancelar.Enabled = True
      End Try
   End Sub

   Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
      Me.Close()
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
      Dim oGenSeg As Entidades.General = New Entidades.General()

      'realizo restauracion de la base principal
      oGen.Path = path
      oGen.Base = base
      cl.RestoreEn(oGen)

      'realizo restauracion de la base de seguridad solo si esta activo el grupo de la base
      If Me.grbBaseSegu.Enabled Then
         oGenSeg.Path = pathSegu
         oGenSeg.Base = baseSegu
         cl.RestoreEnSegu(oGenSeg)
      End If

   End Sub

#End Region


   Private Sub chbBaseSeguridad_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chbBaseSeguridad.CheckedChanged
      Me.grbBaseSegu.Enabled = Me.chbBaseSeguridad.Checked
   End Sub

End Class