Option Strict Off
Imports System.Security.Principal
Imports System.Xml
Imports System.Xml.Linq

Public Class ConfiguracionServiciosSSS

#Region "Campos"

   Private sss As ServiceProcess.ServiceController
   Private _reader As System.Xml.XmlTextReader
   Private _daa As OpenFileDialog
   Private _pathDestino As String = "c:\Eniac\SSSServicio\bin\"
   Private _nombreBD As String = "DBConfig.xml"
   Private _nombreProgramacion As String = "ScheduleConfig.xml"
   Private _nombreMail As String = "MailConfig.xml"
   Private _estaCargando As Boolean = True

#End Region

#Region "Constructores"

#End Region

#Region "Overrides"

   Protected Overrides Sub OnLoad(e As System.EventArgs)
      MyBase.OnLoad(e)

      sss = New ServiceProcess.ServiceController()
      sss.MachineName = My.Computer.Name
      sss.ServiceName = "ServicioSinergiaSoftware"

      Try
         Me.ActualizarServicio()

         If Not Me.IsRunningAsLocalAdmin() Then
            MessageBox.Show("Usted no tiene permisos para correr o parar el servicio. Debe ejecutarlo en modo Administrador.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.tsbCorrerServicio.Enabled = False
         End If

         Me.tsbObtenerBD.PerformClick()
         Me.tsbObtenerMail.PerformClick()
         Me.tsbObtenerProgramacion.PerformClick()

         Me._estaCargando = False
      Catch ex As Exception
         Me.tsbCorrerServicio.Enabled = False
         TabControl1.Enabled = False
         MessageBox.Show(ex.Message, Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try

   End Sub

#End Region

#Region "Eventos"

   Private Sub tsbCorrerServicio_Click(sender As System.Object, e As System.EventArgs) Handles tsbCorrerServicio.Click
      Try
         Me.Cursor = Cursors.WaitCursor
         sss.Refresh()

         If sss.Status = ServiceProcess.ServiceControllerStatus.Running Then
            sss.Stop()
            sss.WaitForStatus(ServiceProcess.ServiceControllerStatus.Stopped)
         Else
            sss.Start()
            sss.WaitForStatus(ServiceProcess.ServiceControllerStatus.Running)
         End If

         Me.ActualizarServicio()

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      Finally
         Me.Cursor = Cursors.Default

      End Try
   End Sub

   Private Sub tsbSalir_Click(sender As System.Object, e As System.EventArgs) Handles tsbSalir.Click
      Me.Close()
   End Sub

   Private Sub tsbObtenerBD_Click(sender As System.Object, e As System.EventArgs) Handles tsbObtenerBD.Click
      Try

         If Me._estaCargando And Not System.IO.File.Exists(Me._pathDestino & Me._nombreBD) Then
            Exit Sub
         End If

         _reader = Me.GetArchivo(Me._nombreBD)
         If _reader IsNot Nothing Then
            Me.Cursor = Cursors.WaitCursor
            Dim readElement As XElement = XElement.Load(_reader)
            Dim arc = From re As XElement In readElement.Elements() Select re

            For Each el As XElement In arc
               Select Case el.Name
                  Case "ConnectionString"
                     Dim caden As String
                     Dim cr As Eniac.Ayudantes.Criptografia = New Eniac.Ayudantes.Criptografia()
                     caden = cr.DecryptString128Bit(el.Value, "clave")
                     Dim val() As String = caden.Split(";")
                     Dim subi(1) As String
                     For Each va As String In val
                        subi = va.Split("=")
                        Select Case subi(0).Trim()
                           Case "Data Source"
                              Me.txtBDServidor.Text = subi(1)
                           Case "Initial Catalog"
                              Me.txtBDBaseDatos.Text = subi(1)
                           Case "User Id"
                              Me.txtBDUsuario.Text = subi(1)
                           Case "Password"
                              Me.txtBDContrasena.Text = subi(1)
                        End Select
                     Next
                  Case "Base"
                     Me.txtBDBaseDatos.Text = el.Value
                  Case "Path"
                     Me.txtBDDirectorioDestino.Text = el.Value
                  Case "PathCopia"
                     Me.txtCopiarEnDirectorio.Text = el.Value
               End Select
            Next
         End If
         Me.tsbGrabarBD.Enabled = True
         Me._reader.Close()

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      Finally
         Me.Cursor = Cursors.Default
      End Try
   End Sub

   Private Sub tsbGrabarBD_Click(sender As System.Object, e As System.EventArgs) Handles tsbGrabarBD.Click
      Try
         Me.Cursor = Cursors.WaitCursor

         Dim base As String = Me.txtBDBaseDatos.Text.Split(";")(0)

         Me._reader = New XmlTextReader(Me._pathDestino + Me._nombreBD)
         Dim readElement As XElement = XElement.Load(_reader)
         Dim arc = From re As XElement In readElement.Elements() Select re

         For Each el As XElement In arc
            Select Case el.Name
               Case "ConnectionString"
                  Dim caden As System.Text.StringBuilder = New System.Text.StringBuilder()
                  Dim cadenEncri As String
                  'armo la cadena con los valores actuales.
                  caden.AppendFormat("Data Source={0};", Me.txtBDServidor.Text)
                  caden.AppendFormat("Initial Catalog={0};", base)
                  caden.AppendFormat("Integrated Security=False;")
                  caden.AppendFormat("User Id={0};", Me.txtBDUsuario.Text)
                  caden.AppendFormat("Password={0};", Me.txtBDContrasena.Text)
                  caden.AppendFormat("Connect Timeout=120")
                  Dim cr As Eniac.Ayudantes.Criptografia = New Eniac.Ayudantes.Criptografia()
                  cadenEncri = cr.EncryptString128Bit(caden.ToString(), "clave")
                  el.SetValue(cadenEncri)
               Case "Base"
                  el.SetValue(Me.txtBDBaseDatos.Text)
               Case "Path"
                  el.SetValue(Me.txtBDDirectorioDestino.Text)
               Case "PathCopia"
                  el.SetValue(Me.txtCopiarEnDirectorio.Text)
            End Select
         Next

         Me._reader.Close()
         Me._reader = Nothing

         GC.Collect()
         GC.WaitForFullGCComplete()

         readElement.Save(Me._pathDestino + Me._nombreBD)

         Me.tsbGrabarBD.Enabled = False

         MessageBox.Show("El archivo se grabo exitosamente!", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      Finally
         Me.Cursor = Cursors.Default
      End Try
   End Sub

   Private Sub tsbObtenerProgramacion_Click(sender As System.Object, e As System.EventArgs) Handles tsbObtenerProgramacion.Click
      Try
         If Me._estaCargando And Not System.IO.File.Exists(Me._pathDestino & Me._nombreProgramacion) Then
            Exit Sub
         End If

         _reader = Me.GetArchivo(Me._nombreProgramacion)
         If _reader IsNot Nothing Then
            Me.Cursor = Cursors.WaitCursor
            Dim readElement As XElement = XElement.Load(_reader)
            Dim arc = From re As XElement In readElement.Elements() Select re

            For Each el As XElement In arc
               Select Case el.Name
                  Case "ThreadSleep"
                     Me.txtProTiempoEspera.Text = (Decimal.Parse(el.Value) / 1000).ToString()
                  Case "TimeFrom"
                     Me.mtbProHoraDesde.Text = (Decimal.Parse(el.Value) / 36).ToString()
                  Case "TimeTo"
                     Me.mtbProHoraHasta.Text = (Decimal.Parse(el.Value) / 36).ToString()
                  Case "Frequence"
                     Me.txtProFrecuencia.Text = el.Value
                  Case "Sunday"
                     Me.chbProDomingo.Checked = Boolean.Parse(el.Value)
                  Case "Monday"
                     Me.chbProLunes.Checked = Boolean.Parse(el.Value)
                  Case "Tuesday"
                     Me.chbProMartes.Checked = Boolean.Parse(el.Value)
                  Case "Wednesday"
                     Me.chbProMiercoles.Checked = Boolean.Parse(el.Value)
                  Case "Thursday"
                     Me.chbProJueves.Checked = Boolean.Parse(el.Value)
                  Case "Friday"
                     Me.chbProViernes.Checked = Boolean.Parse(el.Value)
                  Case "Saturday"
                     Me.chbProSabado.Checked = Boolean.Parse(el.Value)
               End Select
            Next
         End If
         Me.tsbGrabarProgramacion.Enabled = True
         Me._reader.Close()

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      Finally
         Me.Cursor = Cursors.Default
      End Try
   End Sub

   Private Sub tsbGrabarProgramacion_Click(sender As System.Object, e As System.EventArgs) Handles tsbGrabarProgramacion.Click
      Try
         Me.Cursor = Cursors.WaitCursor
         Me._reader = New XmlTextReader(Me._pathDestino + Me._nombreProgramacion)
         Dim readElement As XElement = XElement.Load(_reader)
         Dim arc = From re As XElement In readElement.Elements() Select re

         For Each el As XElement In arc
            Select Case el.Name
               Case "ThreadSleep"
                  el.SetValue((Decimal.Parse(Me.txtProTiempoEspera.Text) * 1000).ToString())
               Case "TimeFrom"
                  el.SetValue(Decimal.Parse(Me.mtbProHoraDesde.Text.Replace(":", "") * 36).ToString())
               Case "TimeTo"
                  el.SetValue(Decimal.Parse(Me.mtbProHoraHasta.Text.Replace(":", "") * 36).ToString())
               Case "Frequence"
                  el.SetValue(Me.txtProFrecuencia.Text)
               Case "Sunday"
                  el.SetValue(Me.chbProDomingo.Checked)
               Case "Monday"
                  el.SetValue(Me.chbProLunes.Checked)
               Case "Tuesday"
                  el.SetValue(Me.chbProMartes.Checked)
               Case "Wednesday"
                  el.SetValue(Me.chbProMiercoles.Checked)
               Case "Thursday"
                  el.SetValue(Me.chbProJueves.Checked)
               Case "Friday"
                  el.SetValue(Me.chbProViernes.Checked)
               Case "Saturday"
                  el.SetValue(Me.chbProSabado.Checked)
            End Select
         Next

         Me._reader.Close()
         Me._reader = Nothing

         GC.Collect()
         GC.WaitForFullGCComplete()

         readElement.Save(Me._pathDestino + Me._nombreProgramacion)

         Me.tsbGrabarProgramacion.Enabled = False

         MessageBox.Show("El archivo se grabo exitosamente!", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      Finally
         Me.Cursor = Cursors.Default
      End Try
   End Sub

   Private Sub tsbObtenerMail_Click(sender As System.Object, e As System.EventArgs) Handles tsbObtenerMail.Click
      Try
         If Me._estaCargando And Not System.IO.File.Exists(Me._pathDestino & Me._nombreMail) Then
            Exit Sub
         End If

         Me.txtDestinatarios.Text = String.Empty

         _reader = Me.GetArchivo(Me._nombreMail)
         If _reader IsNot Nothing Then
            Me.Cursor = Cursors.WaitCursor
            Dim readElement As XElement = XElement.Load(_reader)
            Dim arc = From re As XElement In readElement.Elements() Select re

            For Each el As XElement In arc
               Select Case el.Name
                  Case "SmtpAuthenticate"
                     Me.chbMailRequiereAutenticacion.Checked = el.Value
                  Case "SendUsing"
                     Me.chbMailRequiereSSL.Checked = el.Value
                  Case "SmtpServer"
                     Me.txtMailServidor.Text = el.Value
                  Case "SmtpServerPort"
                     Me.txtMailPuertoSalida.Text = Decimal.Parse(el.Value).ToString()
                  Case "From"
                     Me.txtMailDireccion.Text = el.Value
                  Case "User"
                     Me.txtMailUsuario.Text = el.Value
                  Case "Pwd"

                     Try
                        Dim caden As String
                        Dim cr As Eniac.Ayudantes.Criptografia = New Eniac.Ayudantes.Criptografia()
                        caden = cr.DecryptString128Bit(el.Value, "clave")
                        Me.txtMailPassword.Text = caden
                     Catch ex As Exception
                        'NO hago nada. En caso de existir puede estar NO encriptado.
                        Me.txtMailPassword.Text = ""

                     End Try

                     ' Me.txtMailPassword.Text = el.Value
                  Case "Tos"
                     Me.txtDestinatarios.Text += el.Value.Trim() + ";"
               End Select
            Next
         End If
         Me.tsbGrabarMail.Enabled = True

         Me._reader.Close()


      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      Finally
         Me.Cursor = Cursors.Default
      End Try
   End Sub

   Private Sub tsbGrabarMail_Click(sender As System.Object, e As System.EventArgs) Handles tsbGrabarMail.Click
      Try
         Me.Cursor = Cursors.WaitCursor
         Me._reader = New XmlTextReader(Me._pathDestino + Me._nombreMail)
         Dim readElement As XElement = XElement.Load(_reader)
         Dim arc = From re As XElement In readElement.Elements() Select re


         For Each el As XElement In arc
            Select Case el.Name
               Case "SmtpAuthenticate"
                  el.SetValue(Me.chbMailRequiereAutenticacion.Checked)
               Case "SendUsing"
                  el.SetValue(Me.chbMailRequiereSSL.Checked)
               Case "SmtpServer"
                  el.SetValue(Me.txtMailServidor.Text)
               Case "SmtpServerPort"
                  el.SetValue(Me.txtMailPuertoSalida.Text)
               Case "From"
                  el.SetValue(Me.txtMailDireccion.Text)
               Case "User"
                  el.SetValue(Me.txtMailUsuario.Text)
               Case "Pwd"
                  Dim cadenEncri As String
                  Dim cr As Eniac.Ayudantes.Criptografia = New Eniac.Ayudantes.Criptografia()
                  cadenEncri = cr.EncryptString128Bit(Me.txtMailPassword.Text.ToString(), "clave")
                  el.SetValue(cadenEncri)
                  'el.SetValue(Me.txtMailPassword.Text)
            End Select
         Next
         'elimino todos los destinatarios 
         readElement.Elements("Tos").Remove()

         Dim xl As XElement
         'cargo los nuevos destinatarios

         For Each tes As String In Me.txtDestinatarios.Text.Split(";")
            If Not String.IsNullOrEmpty(tes) Then
               xl = New XElement("Tos")
               xl.SetValue(tes)
               readElement.Add(xl)
            End If
         Next

         Me._reader.Close()
         Me._reader = Nothing

         GC.Collect()

         readElement.Save(Me._pathDestino + Me._nombreMail)

         Me.tsbGrabarMail.Enabled = False

         MessageBox.Show("El archivo se grabo exitosamente!", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)


      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      Finally
         Me.Cursor = Cursors.Default
      End Try
   End Sub

#End Region

#Region "Metodos"

   Private Sub ActualizarServicio()

      Me.tslEstadoServicio.Text = "El servicio esta " + sss.Status.ToString()

      If sss.Status = ServiceProcess.ServiceControllerStatus.Running Then
         Me.tsbCorrerServicio.Text = "Parar Servicio"
      Else
         Me.tsbCorrerServicio.Text = "Correr Servicio"
      End If

   End Sub

   Public Function IsRunningAsLocalAdmin() As Boolean
      Dim cur As WindowsIdentity = WindowsIdentity.GetCurrent()
      For Each role As IdentityReference In cur.Groups
         If role.IsValidTargetType(GetType(SecurityIdentifier)) Then
            Dim sid As SecurityIdentifier = _
                    TryCast(role.Translate(GetType(SecurityIdentifier)),  _
                                            SecurityIdentifier)
            If sid.IsWellKnown(WellKnownSidType.AccountAdministratorSid) _
            OrElse sid.IsWellKnown(WellKnownSidType.BuiltinAdministratorsSid) Then
               Return True
            End If
         End If
      Next

      Return False
   End Function

   Private Function GetArchivo(nombreArchivo As String) As System.Xml.XmlTextReader

      Dim arc As System.Xml.XmlTextReader = Nothing

      If Me._estaCargando Then
         arc = New XmlTextReader(Me._pathDestino + nombreArchivo)
      Else

         Me._daa = New OpenFileDialog()

         Me._daa.InitialDirectory = Me._pathDestino
         Me._daa.Filter = nombreArchivo + " (.xml)|" + nombreArchivo + "|Archivos XML (*.xml)|*.xml"
         Me._daa.FilterIndex = 1

         If Me._daa.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
            arc = New XmlTextReader(Me._daa.FileName)
         End If
      End If

      Return arc

   End Function

#End Region

End Class