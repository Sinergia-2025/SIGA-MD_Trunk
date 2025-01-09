Imports System.Threading

Public Class BackupsDBySegu

   Private Shared nombreArchivo As String = ""
   Private Shared path As String = ""
   Private Shared base As String = ""

   Private Shared nombreArchivoSegu As String = ""
   Private Shared pathSegu As String = ""
   Private Shared baseSegu As String = ""

#Region "Constructores"

   Public Sub New()

      ' This call is required by the Windows Form Designer.
      InitializeComponent()

   End Sub

   Public Sub New(ByVal base As String, ByVal baseSegu As String, ByVal nombreArchivo As String, ByVal nombreArchivoSegu As String, ByVal pathDestino As String, ByVal pathDestinoSegu As String)
      Me.New()
      BackupsDBySegu.nombreArchivo = nombreArchivo
      BackupsDBySegu.path = pathDestino & nombreArchivo
      BackupsDBySegu.base = base
      If Not System.IO.Directory.Exists(pathDestino) Then
         System.IO.Directory.CreateDirectory(pathDestino)
      End If

      BackupsDBySegu.nombreArchivoSegu = nombreArchivoSegu
      BackupsDBySegu.pathSegu = pathDestinoSegu & nombreArchivoSegu
      BackupsDBySegu.baseSegu = baseSegu
      If Not System.IO.Directory.Exists(pathDestinoSegu) Then
         System.IO.Directory.CreateDirectory(pathDestinoSegu)
      End If
   End Sub

#End Region

#Region "Overrides"

   Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)
      MyBase.OnLoad(e)
      Me.txtBaseDestino.Text = path
      Me.txtBaseDestinoSegu.Text = pathSegu
   End Sub

#End Region

#Region "Eventos"

   Private Sub btnBuscarDestino_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscarDestino.Click
      Try
         If Me.fbdBase.ShowDialog() = Windows.Forms.DialogResult.OK Then
            'Me.txtBaseDestino.Text = Me.fbdBase.SelectedPath & "\" & nombreArchivo
            Me.txtBaseDestino.Text = Me.fbdBase.SelectedPath & nombreArchivo

            path = Me.txtBaseDestino.Text
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub btnBuscarDestinoSegu_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscarDestinoSegu.Click
      Try
         If Me.fbdBase.ShowDialog() = Windows.Forms.DialogResult.OK Then
            'Me.txtBaseDestinoSegu.Text = Me.fbdBase.SelectedPath & "\" & nombreArchivoSegu
            Me.txtBaseDestinoSegu.Text = Me.fbdBase.SelectedPath & nombreArchivoSegu
            pathSegu = Me.txtBaseDestinoSegu.Text
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub btnCopiar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCopiar.Click
      Try
         Me.btnCopiar.Enabled = False
         Me.btnCancelar.Enabled = False
         Me.Backupeando()
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

   Private Sub chbBaseSeguridad_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chbBaseSeguridad.CheckedChanged
      Me.grbBaseSegu.Enabled = Me.chbBaseSeguridad.Checked
   End Sub

#End Region

#Region "Metodos"

   Private Sub Backupeando()
      Dim val As Integer = 0

      Try
         Dim tr As Thread = New Thread(AddressOf Backup)
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
         End While

         Me.prbCopiando.Value = Me.prbCopiando.Maximum

         MessageBox.Show("Backup realizado con éxito!!", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      Catch ex As Exception
         Throw ex
      Finally
         Me.prbCopiando.Visible = False
         Me.lblCopiando.Visible = False
         Me.Refresh()
      End Try
   End Sub

   Private Sub Backup()
      Dim cl As Reglas.Generales = New Reglas.Generales()
      Dim oGen As Entidades.General = New Entidades.General()
      Dim oGenSeg As Entidades.General = New Entidades.General()

      'realizo backup de la base principal
      oGen.Path = path
      oGen.Base = base
      cl.BackupEn(oGen)

      'realizo backup de la base de seguridad solo si esta activo el grupo de la base
      If Me.grbBaseSegu.Enabled Then
         oGenSeg.Path = pathSegu
         oGenSeg.Base = baseSegu
         cl.BackupEnSegu(oGenSeg)
      End If

   End Sub

#End Region

End Class