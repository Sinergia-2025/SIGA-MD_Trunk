Option Strict Off
Imports System.Threading
Imports System.Security.Principal
Imports System.IO

Public Class Backups

   Private Shared nombreArchivo As String = ""
   Private Shared pathDestino As String = ""
   Private Shared iden As WindowsIdentity
   Private _tamanoDB As Long = 0

   Public Shared ReadOnly Property PathCompleto As String
      Get
         Return Backups.pathDestino & Backups.nombreArchivo
      End Get
   End Property


#Region "Constructores"

   Public Sub New()

      ' This call is required by the Windows Form Designer.
      InitializeComponent()

   End Sub

   Public Sub New(ByVal base As String, ByVal baseSegu As String, ByVal nombreArchivo As String, ByVal nombreArchivoSegu As String, ByVal pathDestino As String, ByVal pathDestinoSegu As String)
      Me.New()
      Backups.nombreArchivo = nombreArchivo
      Backups.pathDestino = pathDestino
      If Not System.IO.Directory.Exists(pathDestino) Then
         System.IO.Directory.CreateDirectory(pathDestino)
      End If
   End Sub

#End Region

#Region "Overrides"

   Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)
      MyBase.OnLoad(e)
      Me.ConfiguraDatos()
      Me.InicializaDatos()
   End Sub

#End Region

#Region "Eventos"

   Private Sub btnBuscarDestino_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscarDestino.Click
      Try
         If Not String.IsNullOrEmpty(Me.txtBaseDestino.Text) Then
            Me.fbdBase.SelectedPath = Me.txtBaseDestino.Text
         End If

         If Me.fbdBase.ShowDialog() = Windows.Forms.DialogResult.OK Then
            If Strings.Right(Me.fbdBase.SelectedPath, 1) = "\" Then
               Backups.pathDestino = Me.fbdBase.SelectedPath
            Else
               Backups.pathDestino = Me.fbdBase.SelectedPath & "\"
            End If

            Me.txtBaseDestino.Text = Backups.PathCompleto

            Me.SetearEspacioDisco()
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub SetearEspacioDisco()

      Dim cl As Reglas.Generales = New Reglas.Generales()

      Me._tamanoDB = cl.GetTamanoDB() / 1000

      Dim pt As String = ""

      If Not String.IsNullOrEmpty(Me.txtBaseDestino.Text) Then
         pt = System.IO.Path.GetPathRoot(Me.txtBaseDestino.Text)
         Me.lblEspacio.Text = (My.Computer.FileSystem.GetDriveInfo(pt).TotalFreeSpace / 1000000).ToString("#,###,###")
      End If

   End Sub

   Private Sub btnCopiar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCopiar.Click
      Try
         Dim tamano As Long = Long.Parse(Me.lblEspacio.Text.Replace(",", "")) - Me._tamanoDB
         If tamano < 0 Then
            MessageBox.Show("Tiene poco espacio para realizar el backup. Esta faltando " + tamano.ToString("#,##0") + " MBytes.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
         End If
         If Not String.IsNullOrWhiteSpace(Backups.pathCompleto) Then
            If My.Computer.FileSystem.FileExists(Backups.pathCompleto) Then
               If MessageBox.Show("El Archivo de Backup ya Existe ¿Está Seguro de Pisarlo?", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.No Then
                  Exit Sub
               End If
            End If
         End If
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

#End Region

#Region "Metodos"

   Private Sub InicializaDatos()

      Me.txtBaseDestino.Text = Backups.PathCompleto
      'Me.Size = New System.Drawing.Size(592, 187)
      'Me.Height = 231
      'Me.Width = 602
      Me.grbBase.Text += " - " + Ayudantes.Conexiones.Base

      Me.SetearEspacioDisco()
   End Sub

   Private Sub ConfiguraDatos()
      Dim gen As Reglas.Generales
      gen = New Reglas.Generales()
      Me.lblMotorNombre.Text = gen.GetMotorDB()
      Dim version As String = gen.GetMotorVersion()
      Backups.nombreArchivo = Backups.nombreArchivo.Substring(0, Backups.nombreArchivo.Length - 4) + "_MSQL_" + version + ".bak"
   End Sub

   Private Sub Backupeando()
      Dim val As Integer = 0

      Try
         'Me.Backup()
         iden = WindowsIdentity.GetCurrent()
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

         Me.InicializaDatos()

      Catch ex As Exception
         Throw ex
      Finally
         Me.prbCopiando.Visible = False
         Me.lblCopiando.Visible = False
         Me.Refresh()
      End Try
   End Sub

   Private Sub Backup()

      Dim iC As WindowsImpersonationContext = Nothing
      Try

         iC = iden.Impersonate()

         Dim cl As Reglas.Generales = New Reglas.Generales()
         Dim oGen As Entidades.General = New Entidades.General()

         'realizo backup de la base principal
         oGen.Path = pathCompleto
         oGen.Base = Ayudantes.Conexiones.Base
         cl.BackupEn(oGen)
      Catch ex As Exception
         Dim msg As String = String.Empty
         msg += ex.Message
         If ex.InnerException IsNot Nothing Then
            msg += Convert.ToChar(Keys.Enter)
            msg += ex.InnerException.Message
         End If
         MessageBox.Show(msg, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      Finally
         If iC IsNot Nothing Then
            iC.Undo()
         End If
      End Try
   End Sub

#End Region

End Class