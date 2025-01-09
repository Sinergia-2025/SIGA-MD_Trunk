#Region "Option/Imports"
Option Strict On
Option Explicit On
#End Region
Public Class ExportarProductosWebInformacionProgresoSubida
   Private Property args As BackgroundWorkerArguments

   Private sw As Stopwatch
   Private tamanioSubido As Long
   Private tamanioTotal As Long
   Private cantidadArchivos As Long
   Private cantidadSubido As Long

#Region "Overrodes/Overloads"

   Protected Overrides Sub OnShown(e As EventArgs)
      MyBase.OnShown(e)
      If String.IsNullOrWhiteSpace(args.ServidorFTP) Or String.IsNullOrWhiteSpace(args.UsuarioFTP) Or
         String.IsNullOrWhiteSpace(args.ClaveFTP) Or String.IsNullOrWhiteSpace(args.NuevoArchivo) Then
         MessageBox.Show("ATENCION: Faltan configurar Parametros de Subida del Archivo FTP (Solapa Precios)", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
         Close()
      Else
         sw = New Stopwatch()
         sw.Start()
         Timer1.Start()

         InicializaBackgroundWorker()
      End If
   End Sub

   Public Overloads Function ShowDialog(form As IWin32Window, dtArchivos As DataTable, carpetaImagenes As String, archivoDestino As String) As DialogResult
      args = New BackgroundWorkerArguments()

      args.ServidorFTP = Reglas.Publicos.FTPServidor
      args.UsuarioFTP = Reglas.Publicos.FTPUsuario
      args.ClaveFTP = Reglas.Publicos.FTPPassword
      args.NuevoArchivo = Reglas.Publicos.FTPNombreArchivo
      args.BlnConexionPassivaFTP = Reglas.Publicos.FTPConexionPasiva
      args.CarpetaRemotaFTP = Reglas.Publicos.FTPCarpetaRemota

      args.DtArchivos = dtArchivos
      args.CarpetaImagenes = carpetaImagenes
      args.ArchivoDestino = archivoDestino
      Return ShowDialog(form)
   End Function

#End Region

#Region "Eventos"
   Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
      Try
         Dim tiempoTranscurrido As TimeSpan = sw.Elapsed
         txtTiempoTranscurrido.Text = String.Format("{0:00}:{1:00}:{2:00}", tiempoTranscurrido.Hours, tiempoTranscurrido.Minutes, tiempoTranscurrido.Seconds)

         Dim tiempoTotal As TimeSpan = New TimeSpan(Convert.ToInt64(Math.Truncate((tiempoTranscurrido.Ticks / tamanioSubido * tamanioTotal))))
         txtTiempoEstimado.Text = String.Format("{0:00}:{1:00}:{2:00}", tiempoTotal.Hours, tiempoTotal.Minutes, tiempoTotal.Seconds)

         Dim tiempoFinalizcion As TimeSpan = tiempoTotal.Subtract(tiempoTranscurrido)
         txtTiempoFinalizacion.Text = String.Format("{0:00}:{1:00}:{2:00}", tiempoFinalizcion.Hours, tiempoFinalizcion.Minutes, tiempoFinalizcion.Seconds)
      Catch ex As Exception
         'Si da un error no hago nada
      End Try
   End Sub

   Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
      Me.Close()
   End Sub

   Private Sub ExportarProductosWebInformacionProgresoSubida_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
      sw.Stop()
   End Sub
#End Region

#Region "BackgroundWorker"
   Private Sub InicializaBackgroundWorker()
      args.rProWeb = New Reglas.ProductosWeb()
      AddHandler args.rProWeb.BeforeUploadBegins, Sub(sender1 As Object, e1 As Reglas.BeginUploadEventArgs)
                                                     BackgroundWorker1.ReportProgress(0, e1)
                                                  End Sub

      AddHandler args.rProWeb.FileUploadBeginning, Sub(sender1 As Object, e1 As Reglas.FileUploadEventArgs)
                                                      BackgroundWorker1.ReportProgress(0, e1)
                                                   End Sub
      AddHandler args.rProWeb.FileUploadFinished, Sub(sender1 As Object, e1 As Reglas.FileUploadEventArgs)
                                                     BackgroundWorker1.ReportProgress(0, e1)
                                                  End Sub

      BackgroundWorker1.RunWorkerAsync(args)
   End Sub

   Private Sub BackgroundWorker1_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker1.DoWork
      Dim args As BackgroundWorkerArguments = DirectCast(e.Argument, BackgroundWorkerArguments)

      Try
         Dim cantidadDeRegistrosSubidos As Integer = 0
         cantidadDeRegistrosSubidos = args.rProWeb.SubirArchivosALaWeb(args.ServidorFTP, args.UsuarioFTP, args.ClaveFTP, args.NuevoArchivo, args.BlnConexionPassivaFTP,
                                                                       args.CarpetaRemotaFTP, args.ArchivoDestino, args.CarpetaImagenes)
         BackgroundWorker1.ReportProgress(0, "Marcando productos como enviados")
         args.rProWeb.MarcarProductosSubidos(args.DtArchivos.Select("Check"))
      Catch ex As Exception
         BackgroundWorker1.ReportProgress(0, ex)
         BackgroundWorker1.CancelAsync()
      End Try

   End Sub

   Private Sub BackgroundWorker1_ProgressChanged(sender As Object, e As System.ComponentModel.ProgressChangedEventArgs) Handles BackgroundWorker1.ProgressChanged
      If TypeOf (e.UserState) Is Reglas.BeginUploadEventArgs Then
         cantidadArchivos = DirectCast(e.UserState, Reglas.BeginUploadEventArgs).CantidadArchivos
         tamanioTotal = DirectCast(e.UserState, Reglas.BeginUploadEventArgs).TamanioTotal

      ElseIf TypeOf (e.UserState) Is Reglas.FileUploadEventArgs Then
         Dim e1 As Reglas.FileUploadEventArgs = DirectCast(e.UserState, Reglas.FileUploadEventArgs)

         txtNombreArchivo.Text = e1.FileName
         txtTamanio.Text = String.Format("{0:N0}", e1.Tamanio)

         If e1.SubidoExitosamente Then
            tamanioSubido += e1.Tamanio
            cantidadSubido += 1
         End If

         txtSubiendoCantidadArchivos.Text = String.Format("{0:N0} / {1:N0}", cantidadSubido, cantidadArchivos)
         txtSubiendoTamanioArchivos.Text = String.Format("{0:N0} / {1:N0}", tamanioSubido, tamanioTotal)

      ElseIf TypeOf (e.UserState) Is Exception Then
         ShowError(DirectCast(e.UserState, Exception))

      ElseIf TypeOf (e.UserState) Is String Then
         txtNombreArchivo.Text = e.UserState.ToString()
         txtTamanio.Text = String.Empty
      End If

   End Sub

   Private Sub BackgroundWorker1_RunWorkerCompleted(sender As Object, e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles BackgroundWorker1.RunWorkerCompleted
      sw.Stop()
      Timer1.Stop()
      btnCerrar.Visible = True
   End Sub

   Private Class BackgroundWorkerArguments
      Public Property rProWeb As Reglas.ProductosWeb

      Public Property ServidorFTP As String
      Public Property UsuarioFTP As String
      Public Property ClaveFTP As String
      Public Property NuevoArchivo As String
      Public Property BlnConexionPassivaFTP As Boolean
      Public Property CarpetaRemotaFTP As String

      Public Property DtArchivos As DataTable
      Public Property CarpetaImagenes As String
      Public Property ArchivoDestino As String

   End Class
#End Region

End Class