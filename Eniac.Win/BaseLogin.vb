Public Class BaseLogin

   Private _claveActual As String
   Private mensajeActualizacion As String = "´ACTUALIZAR SIGA´"

   Public Sub New()
      ' This call is required by the designer.
      InitializeComponent()
   End Sub

   Public Sub New(mensajeActualizacion As String)
      Me.New()
      Me.mensajeActualizacion = mensajeActualizacion
   End Sub

#Region "Overrides"

   Protected Overrides Sub OnLoad(e As EventArgs)
      MyBase.OnLoad(e)

      Try
         lblVersion.Text = String.Format("v {0}", Application.ProductVersion)

         My.Application.Log.WriteEntry("BaseLogin - Carga Sucursales.", TraceEventType.Verbose)
         CargarSucursales()
         My.Application.Log.WriteEntry("BaseLogin - Termino de cargar Sucursales.", TraceEventType.Verbose)

         If Configuration.ConfigurationManager.AppSettings("CambiarBase") IsNot Nothing Then
            If Not String.IsNullOrEmpty(Configuration.ConfigurationManager.AppSettings("CambiarBase").ToString()) Then
               lnkCambiarBase.Visible = Boolean.Parse(Configuration.ConfigurationManager.AppSettings("CambiarBase").ToString())
            Else
               lnkCambiarBase.Visible = False
            End If
         End If

         Try
            CheckNetFrameworkInstalled()
         Catch ex As Exception
         End Try

      Catch ex As Exception
         Dim msg = String.Empty
         msg += ex.Message
         If ex.InnerException IsNot Nothing Then
            msg += Convert.ToChar(Keys.Enter)
            msg += ex.InnerException.Message
         End If
         MessageBox.Show("Error cargando las sucursales. - " + msg, Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
         Application.Exit()
      End Try
   End Sub

   Protected Overrides Function ProcessCmdKey(ByRef msg As Message, keyData As Keys) As Boolean
      Try
         If keyData = (Keys.Control Or Keys.B) Or keyData = (Keys.Alt Or Keys.B) Then
            lnkCambiarBase_LinkClicked(lnkCambiarBase, Nothing)
            Return True
         End If
      Catch ex As Exception
         ShowError(ex)
      End Try
      Return MyBase.ProcessCmdKey(msg, keyData)
   End Function

   Private Sub VerificarSistema()
      If cmbSucursales.SelectedIndex > -1 Then

         Dim sucursal = DirectCast(cmbSucursales.SelectedItem, Entidades.Sucursal)

         actual.Sucursal = sucursal

         My.Application.Log.WriteEntry("BaseLogin - Obtengo información del sistema.", TraceEventType.Verbose)
         'bloqueo de seguridad
         Dim sistema = Publicos.GetSistema(sucursal.IdEmpresa)

         _claveActual = sistema.ClaveActual

         If Not sistema.Habilitado Then
            lblCaducidad.Text = "Su sistema ha caducado."
            lblCaducidad.Font = New Font(lblCaducidad.Font, FontStyle.Bold)
            tambienCadicidad = True
            lnkActualizaSistema.Visible = True
            Timer1.Start()
            btnLogin.Enabled = False
         Else
            If sistema.AvisarAlCliente Then
               lblCaducidad.Text = "Su sistema caducará en " + sistema.FechaVencimiento.Subtract(Date.Now).Days.ToString() + " días."
               lnkActualizaSistema.Visible = True
               Timer1.Start()
               btnLogin.Enabled = True
            Else
               SetTextoPantalla("Login")
               lblCaducidad.Text = ""
               lnkActualizaSistema.Visible = False
               btnLogin.Enabled = True
            End If
         End If

         If Not lnkActualizaSistema.Visible Then
            Dim rSistema = New Reglas.ControlSistema()
            Dim errorBld = rSistema.ControlaCantidadDeposito(sistema, sucursal.IdSucursal, New Entidades.ErrorBuilder())
            If errorBld.AnyError() Then
               lblCaducidad.Text = "Inconsistencia de Cantidad de Depositos"
               lnkActualizaSistema.Visible = True
               Timer1.Start()
               btnLogin.Enabled = True
            End If
         End If

         'bloqueo de PC
         'Dim regPCs As Reglas.PCs = New Reglas.PCs()
         'Dim pcs As List(Of Entidades.PC) = regPCs.GetPCsHabilitadas()
         'Dim habilitada As Boolean = False
         'For Each pc As Entidades.PC In pcs
         '   If Publicos.GetMACPCLocal() = pc.Mac Then
         '      habilitada = True
         '      Exit For
         '   End If
         'Next
         'If Not habilitada Then
         '   Me.Text = "PC NO HABILITADA !!!!"
         '   Me.lnkActualizaSistema.Visible = False
         '   Me.lnkCambiarContra.Visible = False
         '   Me.btnLogin.Enabled = False
         'End If


         My.Application.Log.WriteEntry("BaseLogin - Controla la fecha/hora del servidor.", TraceEventType.Verbose)

         'Control de Fecha/Hora
         Dim FechaHoraServ As Date = New Reglas.Generales().GetServerDBFechaHora()

         'Si la fecha de la maquina tiene una diferencia mayor a 10 minutos, no lo dejo entrar.
         If Date.Now < FechaHoraServ.AddMinutes(-2) Or Date.Now > FechaHoraServ.AddMinutes(2) Then
            Text = "Ingreso Bloqueado por Fecha Invalida."
            btnLogin.Enabled = False
            MessageBox.Show("ATENCION: para ingresar debe ajustar la Fecha/Hora a la del Servidor (" & FechaHoraServ.ToString("dd/MM/yyyy HH:mm") & ").", Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
         End If

         '--------------------------------
      End If


   End Sub

   Protected Overrides Sub OnClosing(e As System.ComponentModel.CancelEventArgs)
      MyBase.OnClosing(e)
      If DialogResult = DialogResult.OK Or DialogResult = DialogResult.Cancel Then
         e.Cancel = False
      Else
         e.Cancel = True
      End If
   End Sub

#End Region

#Region "Eventos"

   Private Sub txtPwd_GotFocus(sender As Object, e As EventArgs) Handles txtPwd.GotFocus
      txtPwd.SelectAll()
   End Sub

   Private Sub txtUsuario_GotFocus(sender As Object, e As EventArgs) Handles txtUsuario.GotFocus
      txtUsuario.SelectAll()
   End Sub

   Private Sub btnLogin_Click(sender As Object, e As EventArgs) Handles btnLogin.Click

      Try

         DialogResult = DialogResult.Retry

         If txtUsuario.Text.Trim() = "" Then
            MessageBox.Show("Debe ingresar un Usuario para loguearse", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            txtUsuario.Focus()
            Exit Sub
         End If

         If txtPwd.Text.Trim() = "" Then
            MessageBox.Show("Debe ingresar una contraseña para loguearse", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            txtPwd.Focus()
            Exit Sub
         End If

         If Not ValidarUsuario() Then
            MessageBox.Show("Usuario Inexistente", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            txtUsuario.Focus()
            Exit Sub
         End If

         If Not ValidarClave() Then
            RegistrarAcceso(False, "Clave Incorrecta")
            MessageBox.Show("Clave Incorrecta", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            txtPwd.Focus()
            Exit Sub
         End If

         If Not ValidarUsuarioActivo() Then
            MessageBox.Show("Usuario No Activo", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            txtUsuario.Focus()
            Exit Sub
         End If

         Dim VersionDB = Publicos.VersionDB.ToString().Split("."c)

         'Dim decVersionDB As Decimal, decVersionExe As Decimal

         Dim decVersionDB As Decimal = VersionDB(0).ToDecimal().IfNull() + (VersionDB(1).ToDecimal().IfNull() / 100) + (VersionDB(2).ToDecimal().IfNull() / 10000) + (VersionDB(3).ToDecimal().IfNull() / 1000000)
         Dim decVersionExe As Decimal = (My.Application.Info.Version.Major + (My.Application.Info.Version.Minor / 100) + (My.Application.Info.Version.Build / 10000) + (My.Application.Info.Version.Revision / 1000000)).ToDecimal()

         If decVersionExe > decVersionDB Then

            If New Reglas.Usuarios().TienePermisos(txtUsuario.Text, actual.Sucursal.Id, "Login_ProhibicionDeActualizar") Then
               ShowMessage("El usuario no tiene permisos para actualizar el sistema a la nueva versión.")
               Exit Sub
            End If

            Dim prevVersion = Publicos.VersionDB
            Dim nuevaVersion = My.Application.Info.Version.ToString()

            Dim es = New Reglas.Empresas().GetTodos()
            es.ForEach(Sub(em)
                          Dim pars = New Reglas.Parametros()
                          pars.SetValor(em.IdEmpresa, Entidades.Parametro.Parametros.VERSIONDB.ToString(), My.Application.Info.Version.ToString())
                          pars.SetValor(em.IdEmpresa, "FECHAVERSIONDB", Now.ToString("yyyy-MM-dd HH:mm:ss"))
                          pars.SetValor(em.IdEmpresa, "VERSIONDB_RESPONSABLE", String.Format("{0} actualizó de {1} a {2}", txtUsuario.Text.Trim.ToLower(), prevVersion.ToString(), nuevaVersion.ToString()))
                       End Sub)

         ElseIf decVersionExe < decVersionDB Then

            RegistrarAcceso(False, "La Version Actual es antigüa ( " _
                            & My.Application.Info.Version.ToString() _
                            & " ), debe actualizarla a " _
                            & Publicos.VersionDB)

            MessageBox.Show("La Version Actual es antigüa ( " _
                            & My.Application.Info.Version.ToString() _
                            & " ), debe actualizarla a " _
                            & Publicos.VersionDB & vbCrLf & vbCrLf _
                            & "Por Favor ejecute el acceso directo " & mensajeActualizacion & " o Contáctese con Sistemas.", Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
         End If

         Dim oSuc = New Reglas.Sucursales()
         Dim oSucu = oSuc.GetUna(Integer.Parse(cmbSucursales.SelectedValue.ToString()), True)

         If oSucu Is Nothing Then
            Throw New Exception("No hay ninguna sucursal seteada en la base de datos")
         End If
         actual.Sistema = Configuration.ConfigurationManager.AppSettings("BaseBackup").ToString()
         actual.Nombre = txtUsuario.Text.Trim.ToLower()
         actual.Pwd = txtPwd.Text.Trim()
         actual.Sucursal = oSucu
         actual.Empresa = Reglas.Publicos.NombreEmpresa

         Dim usu = New Reglas.Usuarios()
         Dim usuar = usu.GetUnoConMail(actual.Nombre)
         actual.MailConfig = usuar.MailConfig

         actual.NivelAutorizacion = usuar.NivelAutorizacion

         If Publicos.PoliticasSeguridadClaves Then
            If VerificarModificacionContraseña(usuar) Then
               MessageBox.Show("Contraseña vencida. Debe cambiarla.", Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
               txtPwd.Focus()
               Exit Sub
            End If
            'si no esta vencida pero le falta menos de 10 días le aviso al usuario
            Dim dias = (usuar.FechaUltimaModContraseña.AddDays(90) - Date.Now.AddDays(-10)).Days
            If dias <= 10 Then
               MessageBox.Show(String.Format("Por favor, cambie su contraseña, faltan {0} días para que venza.", dias), Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
         End If


         Dim pub = New Publicos()
         pub.ValidaCarpetaEniac()

         'Datos de logo
         actual.NombreLogo = Publicos.NombreLogo
         actual.Logo = Publicos.Logo(oSucu)

         DialogResult = DialogResult.OK

         RegistrarAcceso(True, String.Empty)

         RegistrarDispositivo()

         LimpiaErroresAntiguosEnBitacora()

         Close()

      Catch ex As Exception
         ShowError(ex)
      End Try

   End Sub

   Private Function ValidarUsuario() As Boolean
      Dim oUsuarios = New Reglas.Usuarios()
      Return Not IsNothing(oUsuarios.GetUno(txtUsuario.Text))
   End Function

   Private Function ValidarClave() As Boolean
      Dim oUsuarios = New Reglas.Usuarios()
      Return oUsuarios.EsValido(txtUsuario.Text, txtPwd.Text)
   End Function

   Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
      DialogResult = DialogResult.Cancel
   End Sub

   Private Sub lnkCambiarContra_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lnkCambiarContra.LinkClicked
      TryCatched(
         Sub()
            Using frmCam = New BaseCambioContrasena()
               frmCam.ShowDialog(Me)
            End Using
         End Sub)
   End Sub

   Private Sub lnkCambiarBase_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lnkCambiarBase.LinkClicked
      TryCatched(
         Sub()
            Using frmCam = New BasesDeDatos()
               frmCam.ShowDialog(Me)
               CargarSucursales()
            End Using
         End Sub)
   End Sub

   Private Sub lnkActualizaSistema_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lnkActualizaSistema.LinkClicked
      Try
         Using aSis = New ActualizarSistema()
            aSis.SetClaveActual(_claveActual)
            If aSis.ShowDialog() = DialogResult.OK Then
               VerificarSistema()
            End If
         End Using
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

   Private Sub btnConfig_Click(sender As Object, e As EventArgs) Handles btnConfig.Click
      Try
         Using frm = New BaseConfig()
            If frm.ShowDialog() = DialogResult.OK Then
               CargarSucursales()
            End If
         End Using
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

#End Region

#Region "Metodos"

   Private Sub CargarSucursales()
      Try
         Reglas.ParametrosCache.Instancia.LimpiarCache()
         cmbSucursales.Enabled = True
         btnLogin.Enabled = True

         Cursor = Cursors.WaitCursor

         If IO.File.Exists("BaseDefecto.txt") Then
            Dim base As String = System.IO.File.ReadAllText("BaseDefecto.txt")
            If base.Trim.Length <> 0 Then
               Ayudantes.Conexiones.Base = base
               Ayudantes.Conexiones.BaseSegura = base
            End If
         End If

         Dim oSucursal = New Reglas.Sucursales()

         'setea el driver por defecto del sistema
         'Entidades.Publicos.DriverBase = New Reglas.Parametros().GetValorPD("DRIVERBASE", "C:\")

         'busco el disco donde esta instalado y lo seteo como DriverBase
         For Each di In My.Computer.FileSystem.Drives
            If di.DriveType = IO.DriveType.Fixed Then
               Entidades.Publicos.DriverBase = di.Name
               Exit For
            End If
         Next

         My.Application.Log.WriteEntry("BaseLogin - Formatear combo Sucursales.", TraceEventType.Verbose)

         FormatearComboSucursales()
         With cmbSucursales
            My.Application.Log.WriteEntry("BaseLogin - Obtengo todas las sucursales de la base.", TraceEventType.Verbose)
            .DataSource = oSucursal.GetTodas(False)
            If .Items.Count > 0 Then
               For Each en As Entidades.Sucursal In DirectCast(.DataSource, List(Of Entidades.Sucursal))
                  If en.EstoyAca Then
                     .SelectedValue = en.Id
                     Exit For
                  End If
               Next
               '.SelectedValue = oSucursal.EstoyEn().Id
            End If
         End With

         'Tiene que asignar true o false porque la base SIGA puede tener o no sucursales.
         If cmbSucursales.Items.Count > 1 Then
            cmbSucursales.Visible = True
            lblSucursal.Visible = True
            'Me.Height = 221
         Else
            cmbSucursales.Visible = False
            lblSucursal.Visible = False
            'Me.Height = 189
         End If

         My.Application.Log.WriteEntry("BaseLogin - Comienza verificación del sistema.", TraceEventType.Verbose)
         VerificarSistema()
         My.Application.Log.WriteEntry("BaseLogin - Finaliza verificación del sistema.", TraceEventType.Verbose)

         lblVersionBD.Text = Publicos.VersionDB

         Dim VersionDB = lblVersionBD.Text.ToString().Split("."c)

         Dim decVersionDB As Decimal = VersionDB(0).ToDecimal().IfNull() + (VersionDB(1).ToDecimal().IfNull() / 100) + (VersionDB(2).ToDecimal().IfNull() / 10000) + (VersionDB(3).ToDecimal().IfNull() / 1000000)
         Dim decVersionExe As Decimal = (My.Application.Info.Version.Major + (My.Application.Info.Version.Minor / 100) + (My.Application.Info.Version.Build / 10000) + My.Application.Info.Version.Revision / 1000000).ToDecimal()

         lblVersionBD.Visible = False
         'lblVersionBD.ForeColor = Color.Blue
         lblVersionBD.BackColor = Nothing
         lblVersionBD.ForeColor = Nothing
         If decVersionExe <> decVersionDB Then
            lblVersionBD.Visible = True
            If decVersionExe > decVersionDB Then
               lblVersionBD.BackColor = Color.DarkGreen
               lblVersionBD.ForeColor = Color.White
            ElseIf decVersionExe < decVersionDB Then
               lblVersionBD.BackColor = Color.Red
               lblVersionBD.ForeColor = Color.White
            End If
         End If

         lblVersionBD.Text = "v " + lblVersionBD.Text

         SetTextoPantalla("Login " + Ayudantes.Conexiones.Base)
      Catch ex As Exception
         ShowError(ex)
         cmbSucursales.Enabled = False
         btnLogin.Enabled = False
      Finally
         Cursor = Cursors.Default
      End Try
   End Sub

   Private Sub FormatearComboSucursales()
      With cmbSucursales
         .DisplayMember = "Nombre"
         .ValueMember = "Id"
      End With
   End Sub

   Private Sub RegistrarAcceso(fueExitoso As Boolean, comentario As String)

      Dim oUsuarioAcceso = New Entidades.UsuarioAcceso

      With oUsuarioAcceso
         .IdSucursal = Integer.Parse(Me.cmbSucursales.SelectedValue.ToString())
         .Usuario = Me.txtUsuario.Text
         .FechaAcceso = New Reglas.Generales().GetServerDBFechaHora()
         .NombrePC = My.Computer.Name
         .Exitoso = fueExitoso
         .Observacion = comentario
         Try
            .UsuarioWindows = Environment.UserName.Truncar(100)
         Catch ex As Exception
            .UsuarioWindows = "(error obteniendo usuario windows)"
         End Try
      End With

      Dim regUA = New Reglas.UsuariosAccesos()

      regUA.Insertar(oUsuarioAcceso)

   End Sub

   Private Sub LimpiaErroresAntiguosEnBitacora()
      Dim regla = New Reglas.Bitacora()
      regla.BorraErroresAntiguos()
   End Sub

   Private Sub RegistrarDispositivo()

      Dim dispositivo = New Entidades.Dispositivo()

      With dispositivo
         .NombreDispositivo = My.Computer.Name
         .FechaUltimoLogin = Nothing ' Si es NOTHING, el sql toma GetDate() del servidor New Reglas.Generales().GetServerDBFechaHora()
         .UsuarioUltimoLogin = txtUsuario.Text
         .IdTipoDispositivo = "PC"
         .SistemaOperativo = Publicos.InformacionPC.GetSistemaOperativo().Truncar(100)
         .ArquitecturaSO = Publicos.InformacionPC.GetArquitecturaSistemaOperativo()
         .NumeroSerieDiscoRigido = Publicos.InformacionPC.GetSerialNumberDiscos().Truncar(100)
         .DireccionMAC = Publicos.InformacionPC.GetMACPCLocal().Truncar(100)

         .NumeroSerieMotherboard = Publicos.InformacionPC.GetSerialMotherboard().Truncar(20)
         .NumeroSerieDiscoPrimario = Publicos.InformacionPC.GetSerialNumberDiscosPrimario().Truncar(20)
         .ResolucionPantalla = Publicos.InformacionPC.GetResolucionPantalla().Truncar(20)
         .VersionFramework = Publicos.InformacionPC.GetVersionFramework().Truncar(10)

         'GAR: 31/12/2022. Con el Pendiente 38106 se cambia la PK y se agregan funciones para control de Licencias.
         .IdDispositivo = My.Computer.Name   '.NumeroSerieDiscoRigido

      End With

      Dim odisp = New Reglas.Dispositivos()

      odisp.Merge(dispositivo)

   End Sub

   Private Function ValidarUsuarioActivo() As Boolean
      Dim oUsuarios = New Reglas.Usuarios()
      Return oUsuarios.EsUsuarioActivo(txtUsuario.Text)

   End Function

   Private Function VerificarModificacionContraseña(usuario As Entidades.Usuario) As Boolean

      'al usuario Admin le permito cualquier fecha ya que tiene que administrar el resto.
      If usuario.Usuario = "Admin" Then
         Return False
      End If

      If usuario.FechaUltimaModContraseña.AddDays(90) < DateTime.Now Then
         Return True
      Else
         Return False
      End If

   End Function

   Protected Overridable Sub SetTextoPantalla(texto As String)
      Text = texto
   End Sub
#End Region

   Private Sub txtPaginaWeb_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles txtPaginaWeb.LinkClicked
      Try
         Process.Start(txtPaginaWeb.Text)
      Catch ex As Exception

      End Try
   End Sub

   Private Sub txtCorreoElectronico_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles txtCorreoElectronico.LinkClicked
      Try
         Process.Start(String.Format("mailto:{0}&subject={1}", txtCorreoElectronico.Text, Text))
      Catch ex As Exception

      End Try
   End Sub

   Dim rojo As Boolean = True
   Dim tambienCadicidad As Boolean = False
   Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
      If rojo Then
         lnkActualizaSistema.LinkColor = Nothing
         lblTelefonosFijos.ForeColor = Nothing
         lblTelefonosCelulares.ForeColor = Nothing
         If tambienCadicidad Then lblCaducidad.ForeColor = Nothing
         rojo = False
      Else
         lnkActualizaSistema.LinkColor = Color.Red
         lblTelefonosFijos.ForeColor = Color.Red
         lblTelefonosCelulares.ForeColor = Color.Red
         If tambienCadicidad Then lblCaducidad.ForeColor = Color.Red
         rojo = True
      End If
   End Sub

   Private Sub pnlSinergiaGestion_Click(sender As Object, e As EventArgs) Handles pnlSinergiaGestion.Click
      AbrirUrl("https://www.sinergiasoftware.com.ar/simovil-aplicacion-movil-de-gestion/")
   End Sub
   Private Sub pnlSinergiaPedidos_Click(sender As Object, e As EventArgs) Handles pnlSinergiaPedidos.Click
      AbrirUrl("https://www.sinergiasoftware.com.ar/simovil-aplicacion-movil-de-pedidos/")
   End Sub
   Private Sub pnlSinergiaCobranza_Click(sender As Object, e As EventArgs) Handles pnlSinergiaCobranza.Click
      AbrirUrl("https://www.sinergiasoftware.com.ar/simovil-aplicacion-movil-para-cobranzas/")
   End Sub
   Private Sub pnlSinergiaSoporte_Click(sender As Object, e As EventArgs) Handles pnlSinergiaSoporte.Click
      AbrirUrl("https://www.sinergiasoftware.com.ar/simovil-aplicaciones-moviles/")
   End Sub
   Private Sub pnlSinergiaSoftware_Click(sender As Object, e As EventArgs) Handles pnlSinergiaSoftware.Click
      AbrirUrl("https://www.sinergiasoftware.com.ar/")
   End Sub
   Private Sub pnlGooglePlayStore_Click(sender As Object, e As EventArgs) Handles pnlGooglePlayStore.Click
      AbrirUrl("https://play.google.com/store/apps/developer?id=Sinergia+Software")
   End Sub
   Private Sub pnlAppleAppStore_Click(sender As Object, e As EventArgs) Handles pnlAppleAppStore.Click
      AbrirUrl("https://apps.apple.com/ar/developer/gerardo-augusto-rolla/id1478959587")
   End Sub

   Private Sub AbrirUrl(url As String)
      Try
         Process.Start(url)
      Catch ex As Exception
      End Try
   End Sub

   Private Sub cmbSucursales_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbSucursales.SelectedIndexChanged
      Reglas.ParametrosCache.Instancia.LimpiarCache()
   End Sub

   Private Sub pnlSinergiaGestion_MouseEnter(sender As Object, e As EventArgs) Handles pnlSinergiaGestion.MouseEnter, pnlSinergiaPedidos.MouseEnter, pnlSinergiaCobranza.MouseEnter, pnlSinergiaSoporte.MouseEnter, pnlSinergiaSoftware.MouseEnter
      Try
         DirectCast(sender, Control).BackColor = Color.FromArgb(80, 128, 128, 128)
      Catch ex As Exception
      End Try
   End Sub

   Private Sub pnlSinergiaGestion_MouseLeave(sender As Object, e As EventArgs) Handles pnlSinergiaGestion.MouseLeave, pnlSinergiaPedidos.MouseLeave, pnlSinergiaCobranza.MouseLeave, pnlSinergiaSoporte.MouseLeave, pnlSinergiaSoftware.MouseLeave
      Try
         DirectCast(sender, Control).BackColor = Color.Transparent
      Catch ex As Exception
      End Try
   End Sub


#Region "Control de version de Framework"
   Public Sub CheckNetFrameworkInstalled()
      Dim netVersion = Reglas.CheckNetFrameworkInstalled()
      ToolTip1.SetToolTip(picVersion, String.Format(".NET Framework Versión: {0}", Publicos.GetEnumString(netVersion)))

      If netVersion < Reglas.NetFramworkVersion.Net4_8 Then
         picVersion.Visible = True
      End If
   End Sub

   Private Sub picVersion_Click(sender As Object, e As EventArgs) Handles picVersion.Click
      TryCatched(Sub()
                    Using frm = New CheckNetFrameworkVersion()
                       frm.ShowDialog()
                    End Using
                 End Sub)
   End Sub


   Private _clickCount As Integer
   Private Sub lblVersion_Click(sender As Object, e As EventArgs) Handles lblVersion.Click
      TryCatched(
         Sub()
            _clickCount += 1
            TimerMultiClick.ReStart()
            If _clickCount >= 5 Then
               ShowMessage(Reglas.Publicos.VersionDBResponsable)
            End If
         End Sub)
   End Sub

   Private Sub TimerMultiClick_Tick(sender As Object, e As EventArgs) Handles TimerMultiClick.Tick
      _clickCount = 0
      TimerMultiClick.Stop()
   End Sub
#End Region

End Class