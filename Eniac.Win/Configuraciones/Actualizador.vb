Imports System.Text
Imports System.IO
Imports System.Net
Imports System.Collections.Generic

Public Class Actualizador

#Region "Campos"

   Private _httpWebReq As HttpWebRequest
   Private _httpWebResp As HttpWebResponse
   Private _fileStr As FileStream

   Private _dataBuffer() As Byte
   Private Const _dataBlockSize As Integer = 65536

   Private _valorBarraProgreso As Integer
   Private _maximoBarraProgreso As Integer
   Private _versionNueva As System.Version

   Private _fileName As String

   Private _resp As WSActualiza.Version

   Public Shared pathSetup As String

   Private WithEvents _tiempo As Timer
   Private _conta As Integer

   Private _url As String = "http://168.197.49.100/WSActualizador/WSActualizador.svc"

#End Region

#Region "Overrides"

   Protected Overrides Sub OnLoad(e As EventArgs)
      MyBase.OnLoad(e)
      Try
         'Me.InicializaSistema()
         Me.CargarInfoAtual()

         CheckForIllegalCrossThreadCalls = False

         'seteo los timers
         Me._tiempo = New Timer()
         Me._tiempo.Interval = 1000

         'seteo los valores de visualización
         Me.tspProgresito.Minimum = 0
         Me.tspProgresito.Maximum = 100

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Protected Overrides Sub OnClosing(e As System.ComponentModel.CancelEventArgs)
      MyBase.OnClosing(e)
      Me._tiempo.Stop()
      Me._tiempo.Dispose()
   End Sub

#End Region

#Region "Metodos Privados"

   Private Sub CargarInfoAtual()
      Me.txtAplicacion.Text = New Eniac.Reglas.Parametros().GetValorPD("APLICACION", "SIGA")
      Me.txtVersionActual.Text = New Eniac.Reglas.Parametros().GetValorPD("VersionDB", "1.0.0")
      Me.txtCodigo.Text = New Eniac.Reglas.Parametros().GetValorPD("CODIGOCLIENTESINERGIA", "1")
      Me.txtClave.Text = New Eniac.Reglas.Parametros().GetValorPD("CLAVECLIENTESINERGIA", "ClaveCliente")
      Me.txtBase.Text = Ayudantes.Conexiones.Base
      Me.txtPathDownload.Text = New Eniac.Reglas.Parametros().GetValorPD("UBICACIONMSI", My.Application.Info.DirectoryPath)
      Me._url = New Eniac.Reglas.Parametros().GetValorPD("URLACTUALIZADOR", "http://168.197.49.100/WSActualizador/WSActualizador.svc")

      Me.prbBarraDeProgreso.Value = 0

   End Sub

   Private Sub EjecutarProgresito()
      Try

         If Me._conta = 99 Then
            Me._conta = 0
         End If

         Me._conta += 1

         Me.tspProgresito.Value = Me._conta


      Catch ex As Exception
      Finally
      End Try
   End Sub

   'Rutina asincronica
   Private Sub ResponseReceived(ByVal res As IAsyncResult)
      Try
         _httpWebResp = CType(_httpWebReq.EndGetResponse(res), HttpWebResponse)
      Catch ThisExcept As WebException
         Return
      End Try
      _dataBuffer = New Byte(_dataBlockSize) {}
      ' prepara la barra de progreso
      _maximoBarraProgreso = Fix(_httpWebResp.ContentLength)
      Me.prbBarraDeProgreso.Invoke(New EventHandler(AddressOf SeteaMaximoEnBarraDeProgreso))

      If File.Exists(Me.txtPathDownload.Text + "\" + _fileName) Then
         File.Delete(Me.txtPathDownload.Text + "\" + _fileName)
      End If

      _fileStr = New FileStream(Me.txtPathDownload.Text + "\" + _fileName, FileMode.Create)

      ' comienza a leer desde la red asincronicamente
      _httpWebResp.GetResponseStream().BeginRead(_dataBuffer, 0, _dataBlockSize, New AsyncCallback(AddressOf OnDataRead), Me)


   End Sub

   ' Lectura asincronica de red
   Private Sub OnDataRead(ByVal res As IAsyncResult)
      ' Get bytecount of the received chunk
      Dim nBytes As Integer = _httpWebResp.GetResponseStream().EndRead(res)
      ' Dump it to the output stream
      _fileStr.Write(_dataBuffer, 0, nBytes)
      ' Update prgress bar
      _valorBarraProgreso += nBytes
      Me.prbBarraDeProgreso.Invoke(New EventHandler(AddressOf ActualizaBarraDeProgreso))
      If nBytes > 0 Then
         ' If read was successful, continue reading asynchronously as there is more data
         _httpWebResp.GetResponseStream().BeginRead(_dataBuffer, 0, _dataBlockSize, New AsyncCallback(AddressOf OnDataRead), Me)
      Else
         Try
            ' Otherwise close the stream and proceed with installation
            _fileStr.Close()
            _fileStr = Nothing

            MessageBox.Show("Archivo descargado. Presione Comenzar Instalación para continuar.", "Actualizador.", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            Me.lblTextoBarraDownload.Text = ""
            Me.prbBarraDeProgreso.Value = 0

            Me.btnInstalar.Enabled = True
            Me.btnBuscarActualizaciones.Enabled = True
            Me.btnBajarActualizacion.Enabled = False

         Catch ex As Exception
            MessageBox.Show(ex.StackTrace, ex.Message)
         End Try
      End If


   End Sub 'OnDataRead

   ' Delegate for updating the file download progress
   Private Sub ActualizaBarraDeProgreso(ByVal sender As Object, ByVal e As EventArgs)
      Me.prbBarraDeProgreso.Value = _valorBarraProgreso
      Me.lblTextoBarraDownload.Text = String.Format("{0}% - " + Me._resp.URLMSI, ((_valorBarraProgreso / _maximoBarraProgreso) * 100).ToString("0"))
      Application.DoEvents()
   End Sub 'UpdateProgressValue

   ' Delegate for setting the progress bar size
   Private Sub SeteaMaximoEnBarraDeProgreso(ByVal sender As Object, ByVal e As EventArgs)
      Me.prbBarraDeProgreso.Maximum = _maximoBarraProgreso
      Application.DoEvents()
   End Sub 'SetProgressMax

#End Region

#Region "Eventos"

   Private Sub btnConsultarVersiones_Click(sender As Object, e As EventArgs) Handles btnBuscarActualizaciones.Click
      Try
         Me.Cursor = Cursors.WaitCursor

         Me.tslPie.Text = "Comenzado proceso de consulta"
         Dim ws As WSActualiza.WSActualizador = New WSActualiza.WSActualizador()
         ws.Url = Me._url
         Me.tslPie.Text = "Consultando sitio " + Me._url
         Me._conta = 0
         Me.lblMensajeActualizacion.Text = String.Empty
         Me.lblMensajeActualizacion.ForeColor = System.Windows.Forms.Control.DefaultForeColor
         Me.tspProgresito.Visible = True

         Me._tiempo.Start()

         Dim ver As String = ws.GetUltimaVersion(Me.txtAplicacion.Text, Long.Parse(Me.txtCodigo.Text), True, Me.txtClave.Text, Me.txtBase.Text)

         Dim versionActual As System.Version = New System.Version(Me.txtVersionActual.Text)

         If String.IsNullOrEmpty(ver) Then
            Me._versionNueva = versionActual
         Else
            Me._versionNueva = New System.Version(ver)
         End If

         If Me._versionNueva > versionActual Then
            Me.lblMensajeActualizacion.Text = String.Format("Esta disponible la versión {0} para actualizar la aplicación.", Me._versionNueva.ToString())
            Me.lblMensajeActualizacion.ForeColor = Color.Green
            Me.btnBajarActualizacion.Enabled = True
         Else
            Me.lblMensajeActualizacion.Text = String.Format("No se encontro ninguna versión a actualizar.")
            Me.lblMensajeActualizacion.ForeColor = Color.OrangeRed
            Me.btnBajarActualizacion.Enabled = False
         End If

      Catch ex As Exception
         Me.lblMensajeActualizacion.Text = String.Format("Sucedio un inconveniente, contacte a sistemas. {0} {1}", vbNewLine, ex.Message)
      Finally
         Me.tslPie.Text = String.Empty
         Me.tspProgresito.Visible = False
         Me.Cursor = Cursors.Default
         Me._tiempo.Stop()
      End Try
   End Sub

   Private Sub btnBajarActualizacion_Click(sender As Object, e As EventArgs) Handles btnBajarActualizacion.Click
      Try
         Me.Cursor = Cursors.WaitCursor

         'consulto si esta seguro de actualizar ahora
         If MessageBox.Show("¿Esta seguro de bajar la actualización en este momento?", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.No Then
            Exit Sub
         End If

         Dim ws As WSActualiza.WSActualizador = New WSActualiza.WSActualizador()
         ws.Url = Me._url

         Dim sVer As String = Me.txtVersionActual.Text

         Me.tslPie.Text = "Buscando información en servidor..."
         Application.DoEvents()

         Me._resp = ws.GetVersionCompleta(Me.txtAplicacion.Text,
                                          sVer,
                                          Me._versionNueva.ToString(),
                                          Long.Parse(Me.txtCodigo.Text),
                                          True,
                                          Me.txtClave.Text,
                                          Me.txtBase.Text)

         Me.tslPie.Text = "Información obtenida."
         Application.DoEvents()

         If Me._resp Is Nothing Then
            MessageBox.Show("No existe ninguna actualización dipsonible!!!!.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
         End If

         '-------------------------------------------
         Me.tslPie.Text = "Bajando MSI."
         Application.DoEvents()

         Me.btnBajarActualizacion.Enabled = False
         Me.btnBuscarActualizaciones.Enabled = False

         _fileName = System.IO.Path.GetFileName(Me._resp.URLMSI)
         Dim nomSinExt As String = System.IO.Path.GetFileNameWithoutExtension(Me._resp.URLMSI)
         Dim exten As String = System.IO.Path.GetExtension(Me._resp.URLMSI)

         'haciendo backup del MSI Actual y de la base de datos.-----------------------------------
         Me.tslPie.Text = "Haciendo backup del MSI."
         Application.DoEvents()

         If System.IO.File.Exists(Me.txtPathDownload.Text + "\" + _fileName) Then
            System.IO.File.Copy(Me.txtPathDownload.Text + "\" + _fileName, Me.txtPathDownload.Text + "\" + nomSinExt + DateTime.Now.ToString("_yyyyMMddHHmmss") + exten)
            System.IO.File.Delete(Me.txtPathDownload.Text + "\" + _fileName)
         End If
         '--------------------------------------------------------------

         Me.tslPie.Text = "Bajando archivo."
         Application.DoEvents()

         _httpWebReq = CType(HttpWebRequest.Create(Me._resp.URLMSI), HttpWebRequest)
         _httpWebReq.BeginGetResponse(New AsyncCallback(AddressOf ResponseReceived), Nothing)
         'fin de bajada de MSI -------------------------------------------


      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      Finally
         Me.Cursor = Cursors.Default
         Me._tiempo.Stop()
         Me.tslPie.Text = String.Empty
      End Try

   End Sub

   Private Sub _tiempo_Tick(sender As Object, e As EventArgs) Handles _tiempo.Tick
      Me.EjecutarProgresito()
   End Sub

   Private Sub btnInstalar_Click(sender As Object, e As EventArgs) Handles btnInstalar.Click
      Try
         Me.btnBajarActualizacion.Enabled = False

         Dim scriptsOk As Boolean = True

         Try
            'ejecutar los scripts
            Dim oGene As Reglas.Generales = New Reglas.Generales()
            Dim scri As String = String.Empty
            Dim coleScri As SortedList(Of Integer, String) = New SortedList(Of Integer, String)()

            '--------------
            Me.tslPie.Text = "Haciendo backup de la base de datos."
            Application.DoEvents()
            Dim en As Eniac.Entidades.General = New Eniac.Entidades.General()
            en.Base = Me.txtBase.Text
            en.Path = Me.txtPathDownload.Text + "\" + en.Base + DateTime.Now.ToString("yyyyMMddHHmmss") + ".bak"
            oGene.BackupEn(en)
            Me._tiempo.Start()
            '--------------

            Me.tslPie.Text = "Cargando los scripts..."
            Application.DoEvents()
            Me.tspProgresito.Visible = True
            Me._tiempo.Start()

            'llamar a un metodo para que comience la transacción
            'For Each sc As WSActualiza.Script In Me._resp.Scripts.Items
            '   coleScri.Add(sc.Orden, sc.Texto)
            'Next

            'Me.tslPie.Text = "Ejecutando los scripts..."
            'Application.DoEvents()

            'oGene.EjecutarQuerys(coleScri)

            Me._tiempo.Stop()
            Me.tspProgresito.Visible = False
         Catch ex As Exception
            scriptsOk = False
            MessageBox.Show("Sucedio un error en la ejecución de Scripts, contacte a Sistemas.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
         End Try

         If Not scriptsOk Then
            If MessageBox.Show("Debido al error ocurrido en los scripts, ¿Desea instalar el MSI de todas maneras?", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.No Then
               'salgo sin ejecutar el MSI
               Exit Sub
            End If
         End If

         Me.tslPie.Text = "Se ejecutaron todos los scripts correctamente."
         Application.DoEvents()

         'comenzar a instalar el MSI.
         pathSetup = Me.txtPathDownload.Text + "\" + _fileName
         Dim pr As Process = New Process
         Dim strtInfo As ProcessStartInfo = New ProcessStartInfo(pathSetup)
         strtInfo.WindowStyle = ProcessWindowStyle.Normal
         pr.StartInfo = strtInfo
         pr.Start()
         pr.Close()
         'cierro la aplicación
         Application.Exit()

         Me.lblMensajeActualizacion.Text = "Su sistema se actualizo correctamente."
         Application.DoEvents()

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      Finally
         Me.Cursor = Cursors.Default
         Me.tspProgresito.Visible = False
         Me.btnInstalar.Enabled = True
         Me.btnBajarActualizacion.Enabled = False
      End Try
   End Sub


#End Region

End Class