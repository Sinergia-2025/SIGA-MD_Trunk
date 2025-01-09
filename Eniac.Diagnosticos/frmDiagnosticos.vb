Option Strict On
Option Explicit On
Imports System.IO
Imports System.Configuration
Imports System.Reflection
Imports System.Net
Imports System.Text

Public Class frmVerificarRed

   Private _lblPingAFIPWSAAText As String
   Private _lblPingAFIPWSFEText As String

   Public Sub New()
      ' This call is required by the designer.
      InitializeComponent()
      ' Add any initialization after the InitializeComponent() call.
      Icon = Drawing.Icon.ExtractAssociatedIcon(Reflection.Assembly.GetExecutingAssembly().Location)
      _lblPingAFIPWSAAText = lblPingAFIPWSAA.Text
      _lblPingAFIPWSFEText = lblPingAFIPWSFE.Text
      Text = Text + " - " + Assembly.GetExecutingAssembly().GetName().Version.ToString()
   End Sub
   Protected Overrides Sub OnLoad(e As EventArgs)
      InicializaSistema()
      MyBase.OnLoad(e)
      CargaPantalla()
   End Sub

   Private Sub InicializaSistema()
      If System.IO.File.Exists("BaseDefecto.txt") Then
         Dim base As String = System.IO.File.ReadAllText("BaseDefecto.txt")
         If base.Trim.Length <> 0 Then
            Ayudantes.Conexiones.Base = base
            Ayudantes.Conexiones.BaseSegura = base
         End If
      End If

      If System.IO.File.Exists("Servidor.txt") Then
         Dim fileContents As String = My.Computer.FileSystem.ReadAllText("Servidor.txt")
         Ayudantes.Conexiones.Servidor = fileContents
         Ayudantes.Conexiones.ServidorWS = fileContents.Substring(0, fileContents.IndexOf("\"c))
      End If

      'setea el driver por defecto del sistema
      'Entidades.Publicos.DriverBase = New Reglas.Parametros().GetValorPD("DRIVERBASE", "C:\")

      'busco el disco donde esta instalado y lo seteo como DriverBase
      For Each di As System.IO.DriveInfo In My.Computer.FileSystem.Drives
         If di.DriveType = IO.DriveType.Fixed Then
            Entidades.Publicos.DriverBase = di.Name
            Exit For
         End If
      Next
   End Sub

   Private Sub CargaPantalla()
      Try
         Dim myConnectionSettings As ConnectionStringSettings = ConfigurationManager.ConnectionStrings(Eniac.Datos.DataAccess.Cadenas.CadenaConexion.ToString())
         If myConnectionSettings Is Nothing Then
            Dim fiSIGA As FileInfo
            fiSIGA = New FileInfo("Eniac.SiGA.Win.exe.config")
            If Not fiSIGA.Exists Then
               fiSIGA = New FileInfo("Eniac.SiLIVE.WinExe.exe.config")
               If Not fiSIGA.Exists Then
                  fiSIGA = New FileInfo("Eniac.SiSeN.WinExe.exe.config")
                  If Not fiSIGA.Exists Then
                     fiSIGA = New FileInfo("Eniac.SiCAP.WinExe.exe.config")
                  End If
               End If
            End If
            If Not fiSIGA.Exists() Then
               Throw New Exception("No se puede localizar archivo '.config'.")
            End If
            Dim fiDiag As FileInfo = New FileInfo("Eniac.Diagnosticos.exe")
            File.Copy(fiSIGA.FullName, fiDiag.FullName + ".config", True)
            Application.Restart()
         End If

         lblPingServidor.Text = String.Empty
         lblPingSQLServer.Text = String.Empty
         Dim archivo As FileInfo = New FileInfo("Servidor.txt")
         If archivo.Exists Then
            lblPingSQLServer.Text = IO.File.ReadAllLines(archivo.FullName)(0)
            lblPingServidor.Text = lblPingSQLServer.Text.Split("\"c)(0)
            If lblPingServidor.Text.ToLower().Equals("(local)") Then
               lblPingServidor.Text = "localhost"
            End If
         End If
         lblSharedFolders.Text = lblPingServidor.Text

         lblProblema1.Visible = False
         lblProblema2.Visible = False
         lblProblema3.Visible = False
         lblProblema4.Visible = False
         lblProblema5.Visible = False
         lblProblema6.Visible = False
         lblProblema7.Visible = False
         lblProblema8.Visible = False

         lblAccion1.Visible = False
         lblAccion2.Visible = False
         lblAccion3.Visible = False
         lblAccion4.Visible = False
         lblAccion5.Visible = False
         lblAccion6.Visible = False
         lblAccion7.Visible = False
         lblAccion8.Visible = False

      Catch ex As Exception
         MessageBox.Show(ex.Message, Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub btnVerificar_Click(sender As Object, e As EventArgs) Handles btnVerificar.Click
      Try
         btnVerificar.Enabled = False

         lblPingAFIPWSAA.Text = _lblPingAFIPWSAAText
         lblPingAFIPWSFE.Text = _lblPingAFIPWSFEText

         picPingServidor.Image = Nothing
         picPingGoogle.Image = Nothing
         picPingAFIPWSAA.Image = Nothing
         picPingSQLServer.Image = Nothing
         picSharedFolders.Image = Nothing
         picPingAFIPWSFE_1.Image = Nothing
         picPingAFIPWSFE_2.Image = Nothing
         picPingAFIPWSFE_3.Image = Nothing
         Application.DoEvents()

         If Not String.IsNullOrWhiteSpace(lblPingServidor.Text) Then
            PoneTilde(picPingServidor, My.Resources.refresh, False)
            Application.DoEvents()
            Ping(lblPingServidor.Text, picPingServidor)
            Application.DoEvents()
         End If

         PoneTilde(picPingGoogle, My.Resources.refresh, False)
         Application.DoEvents()
         Ping(lblPingGoogle.Text, picPingGoogle)
         Application.DoEvents()

         PoneTilde(picPingAFIPWSAA, My.Resources.refresh, False)
         Application.DoEvents()
         Ping(lblPingAFIPWSAA.Text, picPingAFIPWSAA)
         Application.DoEvents()

         Try
            PoneTilde(picSharedFolders, My.Resources.refresh, False)
            Application.DoEvents()
            If IsFileShareServerOnline(lblSharedFolders.Text, 2) Then
               PoneTilde(picSharedFolders, My.Resources.check2, False)
            Else
               If IsFileShareServerOnline(lblSharedFolders.Text, 2) Then
                  PoneTilde(picSharedFolders, My.Resources.check2, False)
               Else
                  PoneTilde(picSharedFolders, My.Resources.delete2, True)
               End If
            End If
         Catch ex As Exception
            PoneTilde(picSharedFolders, My.Resources.delete2, True)
         Finally
            Application.DoEvents()
         End Try

         Try
            PoneTilde(picPingSQLServer, My.Resources.refresh, False)
            Application.DoEvents()
            Dim rSucursales As Reglas.Sucursales = New Reglas.Sucursales()
            Dim sucursal As Entidades.Sucursal = rSucursales.EstoyEn(False)
            PoneTilde(picPingSQLServer, My.Resources.check2, False)
         Catch ex As Exception
            PoneTilde(picPingSQLServer, My.Resources.delete2, True)
         Finally
            Application.DoEvents()
         End Try

         PoneTilde(picPingAFIPWSFE_1, My.Resources.refresh, False)
         Application.DoEvents()
         Ping(lblPingAFIPWSFE.Text, picPingAFIPWSFE_1)
         Application.DoEvents()

         Try
            lblPingAFIPWSAA.Text = String.Format("{0} ({1})", _lblPingAFIPWSAAText, GetIps(_lblPingAFIPWSAAText))
         Catch ex As Exception
            lblPingAFIPWSAA.Text = _lblPingAFIPWSAAText
         Finally
            Application.DoEvents()
         End Try
         Try
            lblPingAFIPWSFE.Text = String.Format("{0} ({1})", _lblPingAFIPWSFEText, GetIps(_lblPingAFIPWSFEText))
         Catch ex As Exception
            lblPingAFIPWSFE.Text = _lblPingAFIPWSFEText
         Finally
            Application.DoEvents()
         End Try

         Try
            Dim reg As Reglas.AFIPFE = New Reglas.AFIPFE()
            Dim estados() As String = reg.TestearServidoresV1().Split("/"c)

            Ping(lblPingAFIPWSFE.Text, picPingAFIPWSFE_1)
            Application.DoEvents()
            If estados(0) = "OK" Then
               PoneTilde(picPingAFIPWSFE_1, My.Resources.check2, False)
            Else
               PoneTilde(picPingAFIPWSFE_1, My.Resources.delete2, True)
            End If

            Ping(lblPingAFIPWSFE.Text, picPingAFIPWSFE_2)
            Application.DoEvents()
            'Servidor Aplicación
            If estados(1) = "OK" Then
               PoneTilde(picPingAFIPWSFE_2, My.Resources.check2, False)
            Else
               PoneTilde(picPingAFIPWSFE_2, My.Resources.delete2, True)
            End If

            Ping(lblPingAFIPWSFE.Text, picPingAFIPWSFE_3)
            Application.DoEvents()
            'Servidor Base de Datos
            If estados(2) = "OK" Then
               PoneTilde(picPingAFIPWSFE_3, My.Resources.check2, False)
            Else
               PoneTilde(picPingAFIPWSFE_3, My.Resources.delete2, True)
            End If
         Catch ex As Exception
            PoneTilde(picPingAFIPWSFE_1, My.Resources.delete2, True)
            PoneTilde(picPingAFIPWSFE_2, My.Resources.delete2, True)
            PoneTilde(picPingAFIPWSFE_3, My.Resources.delete2, True)
         Finally
            Application.DoEvents()
         End Try

      Catch ex As Exception
         MessageBox.Show(ex.Message, Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      Finally
         btnVerificar.Enabled = True
      End Try
   End Sub

   Public Shared Function IsFileShareServerOnline(PCName As String,
                                                  Timeout As Integer) As Boolean
      If Not IsFileShareServerOnline(PCName, Timeout, 135) Then
         If Not IsFileShareServerOnline(PCName, Timeout, 139) Then
            Return IsFileShareServerOnline(PCName, Timeout, 445)
         End If
      End If
      Return True
   End Function
   Public Shared Function IsFileShareServerOnline(PCName As String,
                                                  Timeout As Integer,
                                                  Port As Integer) As Boolean

      'Const Port As Integer = 139 'port for file sharing service

      Dim IsOnline As Boolean = False
      Dim IP As Net.IPAddress = Net.Dns.GetHostAddresses(PCName)(0)
      Dim Address As Net.IPAddress = Net.IPAddress.Parse(IP.ToString())
      Dim Socket As Net.Sockets.TcpClient = New Net.Sockets.TcpClient(Address.AddressFamily)
      Dim Connect = Socket.BeginConnect(Address, Port, Nothing, Nothing)
      Dim WaitingResult = Connect.AsyncWaitHandle.WaitOne(Timeout, False)

      If (Connect.IsCompleted) Then
         If WaitingResult Then
            Socket.EndConnect(Connect)
            IsOnline = True
         End If
      End If
      Socket.Close()
      Return IsOnline

   End Function

   Private Sub Ping(servidor As String, pic As PictureBox)
      Try
         If My.Computer.Network.Ping(servidor) Then
            PoneTilde(pic, My.Resources.check2, False)
         Else
            PoneTilde(pic, My.Resources.delete2, True)
         End If
      Catch ex As Exception
         PoneTilde(pic, My.Resources.delete2, True)
      End Try
   End Sub

   Private Sub PoneTilde(pic As PictureBox, icono As Icon, [error] As Boolean)
      pic.Image = Bitmap.FromHicon(icono.Handle)

      Dim fila As Integer = TableLayoutPanel1.GetRow(pic)
      Dim columna As Integer = TableLayoutPanel1.GetColumn(lblProblema1)
      Dim columna2 As Integer = TableLayoutPanel1.GetColumn(lblAccion1)

      Dim label1 As Control = TableLayoutPanel1.GetControlFromPosition(columna, fila)
      Dim label2 As Control = TableLayoutPanel1.GetControlFromPosition(columna2, fila)

      label1.Visible = [error]
      label2.Visible = [error]

   End Sub

   Private Function GetIps(hostName As String) As String
      Dim ips As IPAddress() = Dns.GetHostAddresses(hostName)
      Dim stb As StringBuilder = New StringBuilder()
      For Each ip As IPAddress In ips
         stb.AppendFormat("{0},", ip.ToString())
      Next
      Return stb.ToString().Trim(","c)
   End Function

End Class
