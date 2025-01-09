Public Class BasePrincipal

#Region "Constructores"

   Public Sub New()
      ' This call is required by the Windows Form Designer.
      InitializeComponent()

      My.Application.Log.WriteEntry("BasePrincipal - Comienzo a configurar la configuración regional.", TraceEventType.Verbose)

      Reglas.Publicos.VerificaConfiguracionRegional()
      System.Threading.Thread.CurrentThread.CurrentUICulture = New Globalization.CultureInfo("es-AR")

      My.Application.Log.WriteEntry("BasePrincipal - Termino de configurar la configuración regional.", TraceEventType.Verbose)

      If Me.GetService(GetType(System.ComponentModel.Design.IDesignerHost)) Is Nothing Then

      End If

   End Sub

   Public Function Actualiza() As Boolean
      Try
         Dim actualizaVersion As Boolean = False

         If Not My.Computer.Network.IsAvailable Then
            Return True
         End If

         Dim actuaVer As String = Application.StartupPath + "\ActualizaVersion.sin"
         If System.IO.File.Exists(actuaVer) Then
            actualizaVersion = Boolean.Parse(My.Computer.FileSystem.ReadAllText(actuaVer))
         Else
            '-- REQ-32686.- --
            My.Computer.FileSystem.WriteAllText(actuaVer, "False", False)
            actualizaVersion = False
         End If

         If Not actualizaVersion Then
            Return True
         End If

         If Not System.IO.File.Exists(Application.StartupPath & "\Actualizador.exe") Then
            Throw New Exception("Falta el archivo Actualizador.exe, contactese con sistemas.")
         End If
         If Not System.IO.File.Exists(Application.StartupPath & "\Actualizador.exe.config") Then
            Throw New Exception("Falta el archivo Actualizador.exe.config, contactese con sistemas.")
         End If
         'chequea la version del modulo actual 
         'si esta configurado en el app.config que salga para actualizar, la aplic se cierra 
         Dim appName As String = My.Application.Info.CompanyName ' CType(GetCustomAttribute(GetCallingAssembly(), GetType(AssemblyAppNameAttribute)), AssemblyAppNameAttribute).AppName
         Dim moduleName As String = My.Application.Info.ProductName ' CType(GetCustomAttribute(GetCallingAssembly(), GetType(AssemblyModuleNameAttribute)), AssemblyModuleNameAttribute).ModuleName
         Dim starupPath As String = Application.StartupPath
         Dim modulePath As String = Application.ExecutablePath

         Dim log As String = "appName= " + appName + " - moduleName = " + moduleName + " - starupPath = " + starupPath + " - modulePath = " + modulePath

         My.Application.Log.WriteEntry(log, TraceEventType.Information, 23)

         Dim url As String = "http://" + Ayudantes.Conexiones.ServidorWS + "/Sinergia/WSActualizador.asmx"

         My.Application.Log.WriteEntry(url, TraceEventType.Information, 24)

         If Eniac.Ayudantes.Actualizador.Common.CheckVersion(appName, moduleName, starupPath, modulePath, url) Then
            Return False
         Else
            Return True
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, " E R R O R ", MessageBoxButtons.OK, MessageBoxIcon.Information)
         MessageBox.Show("Tiene que reiniciar la aplicación", "A V I S O", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
         Return False
      End Try
   End Function


#End Region

#Region "Constantes"

   Private Const usrId As String = "Id"
   Private Const usrNombre As String = "Nombre"
   Private Const usrEsMenu As String = "EsMenu"
   Private Const usrDescripcion As String = "Descripcion"
   Private Const usrEnabled As String = "Enabled"
   Private Const usrVisible As String = "Visible"
   Private Const usrEsBoton As String = "EsBoton"
   Private Const usrArchivo As String = "Archivo"
   Private Const usrPantalla As String = "Pantalla"

#End Region

#Region "Campos"

   Protected _ok As Boolean = True
   Public Shared enti As Eniac.Entidades.Entidad
   Protected _ale As Alertas
   Private _log As BaseLogin

#End Region

#Region "Overridables"

   Public Overridable Function GetLogin() As BaseLogin
      Return New BaseLogin()
   End Function

   Protected Overridable Sub ControlesVariosPrincipal()
      Dim rObjetivos = New Reglas.CRMTiposNovedadesObjetivos()
      rObjetivos.CopiarObjetivosParaPeriodo()
      Dim rParams = New Reglas.Parametros()
      rParams.ConvertirParametros()
   End Sub

#End Region

#Region "Overrides"

   Private WithEvents _frmMonitor As MonitorParametros

   ''' <summary>
   ''' Proceso de Versionado de Actualizador.- 
   ''' </summary>
   ''' <param name="archivoOrigen">Archivo de Origen</param>
   ''' <param name="archivoDestino">Archivo de Destino</param>
   Public Sub Proceso_Actualizador(archivoOrigen As String, archivoDestino As String)
      '-- Archivo Exe.- --
      If System.IO.File.Exists(archivoOrigen) Then
         Try
            If System.IO.File.Exists(archivoDestino) Then
               IO.File.Delete(archivoDestino)
            End If
            IO.File.Move(archivoOrigen, archivoDestino)
         Catch ex As Exception
            Throw New Exception(String.Format("Error al respaldar el actualizador: {0}", ex.Message), ex)
         End Try
         IO.File.Delete(archivoOrigen)
      End If
   End Sub

   Private Sub AbrirMonitorParametros(sender As Object, e As EventArgs)
      If _frmMonitor Is Nothing Then
         _frmMonitor = New MonitorParametros()
         components.Add(_frmMonitor)
         _frmMonitor.Show(Me)
      Else
         If _frmMonitor.IsDisposed Then
            CloseMonitorParametros()
            AbrirMonitorParametros(sender, e)
         Else
            _frmMonitor.BringToFront()
         End If
      End If
   End Sub

   Private Sub _frmMonitor_FormClosed(sender As Object, e As FormClosedEventArgs) Handles _frmMonitor.FormClosed
      TryCatched(Sub() CloseMonitorParametros())
   End Sub
   Private Sub CloseMonitorParametros()
      If _frmMonitor IsNot Nothing Then
         _frmMonitor.Dispose()
         Try
            components.Remove(_frmMonitor)
         Catch ex As Exception
         End Try
         _frmMonitor = Nothing
      End If
   End Sub

   Protected Overrides Sub OnLoad(e As EventArgs)
      Me.Hide()

      'controlo que si envian parametros en el exe ejecute un metodo previo
      If Environment.GetCommandLineArgs.Length > 1 Then
         Dim reg As Reglas.Desatendidos = New Reglas.Desatendidos()
         reg.CuandoInicioElExe(Sub(f) LevantaPantalla(GetNombreAssembly(f.Archivo), String.Format("{0}.{1}", f.Archivo, f.Pantalla), f.Parametros, f.Id, f.PermiteMultiplesInstancias, mostrarMensajeError:=False, EsMDIChild:=True))
         Me._ok = False
         Application.Exit()
         Exit Sub
      End If

      MyBase.OnLoad(e)
      Try
         'Entidades.Publicos.DriverBase = New Reglas.Parametros().GetValorPD("DRIVERBASE", "C:\")
         'reviso los servidores de SQL Server
         My.Application.Log.WriteEntry("BasePrincipal - Reviso los servidores de SQL Server.", TraceEventType.Verbose)
         Dim ser As Servidores = New Servidores()
         If ser.ShowDialog() <> Windows.Forms.DialogResult.OK Then
            MessageBox.Show("No existen servidores para conectarse.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Me._ok = False
            Exit Sub
         End If
         'realizo las actualizaciones de versiones
         My.Application.Log.WriteEntry("BasePrincipal - Realizo las actualizaciones de versiones.", TraceEventType.Verbose)
         If Me.Actualiza() Then
            'pido el logueo
            Me._log = Me.GetLogin()
            If Me._log.ShowDialog() = Windows.Forms.DialogResult.OK Then
               actual.CurrentUICulture = Reglas.Publicos.EmpresaCurrentUICulture
               System.Threading.Thread.CurrentThread.CurrentUICulture = New Globalization.CultureInfo(actual.CurrentUICulture)
               'tssCurrentUICulture.Text = System.Threading.Thread.CurrentThread.CurrentUICulture.DisplayName
               tssCurrentUICulture.Text = New Globalization.RegionInfo(System.Threading.Thread.CurrentThread.CurrentUICulture.Name).DisplayName
               Me.Show()
               Me._ok = True
               Eniac.Ayudantes.Common.usuario = Me._log.txtUsuario.Text
               Eniac.Ayudantes.Common.pwd = Me._log.txtPwd.Text

               Dim currentSecurityProtocol As Net.SecurityProtocolType = System.Net.ServicePointManager.SecurityProtocol

               '-------------------------------------------------------------------
               '-- REQ-25724.- --
               '-- Proceso Archivo EXE.- --
               Proceso_Actualizador("Actualizador.exe.data", "Actualizador.exe")
               '-- Proceso Archivo Config.- --
               Proceso_Actualizador("Actualizador.exe.config.data", "Actualizador.exe.config")
               '------------------------------------------------------------------------------------------

               Try
                  Try
                     If Reglas.Publicos.WebArchivos.HabilitarTLS1_1 Then
                        currentSecurityProtocol = currentSecurityProtocol Or DirectCast(768, Net.SecurityProtocolType)
                        System.Net.ServicePointManager.SecurityProtocol = currentSecurityProtocol
                     End If
                  Catch ex As Exception
                     Throw New Exception("Error habilitando TLS 1.1", ex)
                  End Try

                  Try
                     If Reglas.Publicos.WebArchivos.HabilitarTLS1_2 Then
                        currentSecurityProtocol = currentSecurityProtocol Or DirectCast(3072, Net.SecurityProtocolType)
                        System.Net.ServicePointManager.SecurityProtocol = currentSecurityProtocol
                     End If
                  Catch ex As Exception
                     Throw New Exception("Error habilitando TLS 1.2", ex)
                  End Try
               Catch ex As Exception
                  ShowError(ex, recursivo:=True)
               End Try

               'System.Net.ServicePointManager.SecurityProtocol = Net.SecurityProtocolType.Ssl3 Or Net.SecurityProtocolType.Tls Or
               '                                                  DirectCast(768, Net.SecurityProtocolType) Or DirectCast(3072, Net.SecurityProtocolType)
               'System.Net.ServicePointManager.ServerCertificateValidationCallback = Function(sender As Object,
               '                                                                              certification As System.Security.Cryptography.X509Certificates.X509Certificate,
               '                                                                              chain As System.Security.Cryptography.X509Certificates.X509Chain,
               '                                                                              sslPolicyErrors As System.Net.Security.SslPolicyErrors)
               '                                                                        Return True
               '                                                                     End Function

            Else
               Me._ok = False
            End If
         Else
            Me._ok = False
         End If

         If Me.GetService(GetType(System.ComponentModel.Design.IDesignerHost)) Is Nothing Then
            If Me._ok Then
               Me.Cursor = Cursors.WaitCursor

               'Cargar distintos datos en la barra del MDI
               My.Application.Log.WriteEntry("BasePrincipal - Cargar distintos datos en la barra del MDI.", TraceEventType.Verbose)
               Me.tssVencimiento.Text = Publicos.GetSistema().FechaVencimiento.ToString("dd/MM/yyyy")
               Me.tssVencimiento.Visible = (New Reglas.UsuariosRoles().GetRolesdeUsuarios(actual.Nombre, "Adm").Rows.Count > 0)

               Me.tssUsuario.Text = actual.Nombre.ToUpper()
               Me.tssEmpresa.Text = String.Format("{0} ({1})", Reglas.Publicos.NombreEmpresaImpresion.ToUpper(), Publicos.CodigoClienteSinergia.ToUpper())
               If Not IsNumeric(Publicos.CodigoClienteSinergia) OrElse Long.Parse(Publicos.CodigoClienteSinergia) = 0 Then
                  tssError.Text = String.Format("ADVERTENCIA: No se ha configurado el código de empresa")
               End If
               Me.tssSucursal.Text = actual.Sucursal.Nombre.ToUpper()
               Me.tssVersion.Text = My.Application.Info.Version.ToString()
               Text = String.Format("{0} ({1})", Text, My.Application.Info.Version)
               My.Application.Log.WriteEntry("BasePrincipal - EjecutarQuerys.", TraceEventType.Verbose)
               Me.EjecutarQuerys()
               My.Application.Log.WriteEntry("BasePrincipal - CrearMenuToolbar.", TraceEventType.Verbose)

               Dim menu As CreaMenuToolbar = New CreaMenuToolbar()
               menu.Crear(Me, mnsPrincipal, tlsPrincipal, AddressOf CargaPantallas, AddressOf CargaPantallasBoton, AddressOf AbrirMonitorParametros)

               My.Application.Log.WriteEntry("BasePrincipal - SeteaLenguajeControlesInfragistics.", TraceEventType.Verbose)
               Me.SeteaLenguajeControlesInfragistics()
               Me._ale = New Alertas()
               My.Application.Log.WriteEntry("BasePrincipal - CargaAlertas.", TraceEventType.Verbose)
               Me.CargaAlertas()

               My.Application.Log.WriteEntry("BasePrincipal - FIN CargaAlertas.", TraceEventType.Verbose)

               If actual.Sucursal IsNot Nothing Then
                  If actual.Sucursal.ColorSucursal <> 0 And actual.Sucursal.ColorSucursal <> -1 Then
                     BackColor = Color.FromArgb(actual.Sucursal.ColorSucursal)
                  End If
               End If

            End If
         End If

         Me.CargarTareas()

         Traducciones.Cargar()

         'AbrirMonitorParametros()

         TryCatched(Sub()
                       If _ok Then
                          ControlesVariosPrincipal()
                       End If
                    End Sub)

         Dim netVersion = Reglas.CheckNetFrameworkInstalled()

         If netVersion < Reglas.NetFramworkVersion.Net4_8 Then
            Using frm = New CheckNetFrameworkVersion()
               frm.ShowDialog()
            End Using
         End If

      Catch ex As Exception
         Me.Cursor = Cursors.Default
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      Finally
         Me.Cursor = Cursors.Default
      End Try
   End Sub

   Protected Overrides Sub OnShown(e As EventArgs)
      MyBase.OnShown(e)
   End Sub

   Protected Overrides Sub OnClosing(e As System.ComponentModel.CancelEventArgs)
      MyBase.OnClosing(e)
      Try
         If MessageBox.Show("Desea cerrar la aplicacion?", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.Yes Then
            If Me.MdiChildren.Length > 1 Then
               If MessageBox.Show("Hay " + (Me.MdiChildren.Length - 1).ToString() + " pantallas abiertas en la aplicación, desea cerrarlas?", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Information) = Windows.Forms.DialogResult.Yes Then
                  For Each pan As Form In Me.MdiChildren
                     If pan.Name <> "Alertas" Then
                        pan.Close()
                     End If
                  Next
               End If
            End If
            If Me.MdiChildren.Length > 1 Then
               MessageBox.Show("Hay pantallas que no se pueden cerrar.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning)
               e.Cancel = True
            Else
               e.Cancel = False
            End If
         Else
            e.Cancel = True
         End If
      Catch ex As Exception
         'si da error aca no hace nada, para que no le muestre ningun mensaje raro al usuario
      End Try
   End Sub

#End Region

#Region "Eventos"

   Private Sub BasePrincipal_Resize(sender As Object, e As EventArgs) Handles Me.Resize
      Me.AcomodarAlertas()
   End Sub

   Private Sub About(sender As Object, e As EventArgs)
      Dim fr As Eniac.Win.BaseAbout = New Eniac.Win.BaseAbout()
      fr.MdiParent = Me
      fr.Show()
   End Sub

   Private Sub Salir(sender As Object, e As EventArgs)
      Me.Close()
   End Sub

   Public Sub CargaPantallas(sender As Object, e As EventArgs)
      Dim item = DirectCast(sender, ToolStripMenuItem)
      Me.CargaAssembly(DirectCast(item.Tag, DataRow))
   End Sub

   Public Sub CargaPantallasBoton(sender As Object, e As EventArgs)
      Dim item = DirectCast(sender, ToolStripButton)
      Me.CargaAssembly(DirectCast(item.Tag, DataRow))
   End Sub

   Public Sub CargaPantalla(idFuncion As String, parametros As String)
      If Not String.IsNullOrWhiteSpace(idFuncion) Then
         Using dt = New Reglas.Funciones().Get1(idFuncion)
            If dt.Any() Then
               Dim dr = dt.First()
               dr("Parametros") = String.Join(";", {dr.Field(Of String)("Parametros"), parametros}.Where(Function(s) Not String.IsNullOrWhiteSpace(s)))
               CargaAssembly(dr)
            Else
               Throw New Exception(String.Format("No se encuentra la función: {0}", idFuncion))
            End If
         End Using
      End If
   End Sub

   Private _usuarioTienePermisosPermiteMultiplesInstancias As Boolean?
   Private Sub CargaAssembly(dr As DataRow)
      If String.IsNullOrWhiteSpace(dr(usrPantalla).ToString()) Then Return
      Dim nombreClase As String = dr(usrArchivo).ToString() + "." + dr(usrPantalla).ToString()
      Dim nombreAssembly As String = Me.GetNombreAssembly(dr(usrArchivo).ToString())
      Dim parametros As String = dr("Parametros").ToString()
      Dim idFuncion As String = dr("Id").ToString()
      Dim permiteMultiplesInstancias As Boolean = Boolean.Parse(dr(Entidades.Funcion.Columnas.PermiteMultiplesInstancias.ToString()).ToString())
      Dim EsMDIChild As Boolean = Boolean.Parse(dr(Entidades.Funcion.Columnas.EsMDIChild.ToString()).ToString())
      If Not permiteMultiplesInstancias Then
         If Not _usuarioTienePermisosPermiteMultiplesInstancias.HasValue Then
            _usuarioTienePermisosPermiteMultiplesInstancias = New Reglas.Usuarios().TienePermisos("PermiteMultiplesInstancias")
         End If
         permiteMultiplesInstancias = _usuarioTienePermisosPermiteMultiplesInstancias.Value
      End If
      Bitacora(idFuncion)
      LevantaPantalla(nombreAssembly, nombreClase, parametros, idFuncion,
                      permiteMultiplesInstancias, mostrarMensajeError:=True,
                      EsMDIChild)

   End Sub

   Private Function BuscaFormAbierto(idFuncion As String) As Form
      Return DirectCast(Application.OpenForms.OfType(Of IConIdFuncion).FirstOrDefault(Function(f) f.IdFuncion = idFuncion), Form)
      'For Each f As Form In Application.OpenForms
      '   If TypeOf (f) Is IConIdFuncion Then
      '      If DirectCast(f, IConIdFuncion).IdFuncion = idFuncion Then
      '         Return f
      '      End If
      '   End If
      'Next
      'Return Nothing
   End Function

   Private Sub LevantaPantalla(assemblyFile As String, typeName As String,
                               parametros As String, idFuncion As String,
                               permiteMultiplesInstancias As Boolean,
                               mostrarMensajeError As Boolean,
                               EsMDIChild As Boolean)

      My.Application.Log.WriteEntry(String.Format("BasePrincipal - LevantaPantalla({0}, {1}, {2}, {3}, {4}, {5})", assemblyFile, typeName, parametros, idFuncion, permiteMultiplesInstancias, mostrarMensajeError), TraceEventType.Verbose)

      Try
         Reglas.Publicos.VerificaConfiguracionRegional()
      Catch ex As Exception
         'En caso de que de una excepción (algo raro ya que no debería
         'de ninguna manera), continúo con la ejecución de la aplicación.
      End Try

      Try
         Publicos.GetSistema().ControlaValidezDeFecha(Today)
      Catch ex As Exception
         ShowError(ex)
         Exit Sub
      End Try
      Reglas.Publicos.VerificaFechaUltimoLogin()

      Dim abrirNuevaPantalla As Boolean = True

      If Not permiteMultiplesInstancias Then
         Dim frm As Form = BuscaFormAbierto(idFuncion)
         If frm IsNot Nothing Then
            abrirNuevaPantalla = False
            If frm.WindowState = FormWindowState.Minimized Then
               frm.WindowState = FormWindowState.Normal
            End If
            frm.BringToFront()
         End If
      End If            ' ELSE - If permiteMultiplesInstancias Then
      If abrirNuevaPantalla Then
         Dim frm As Form = Nothing
         Dim obj As System.Runtime.Remoting.ObjectHandle
         Try
            System.Windows.Forms.Cursor.Current = Cursors.WaitCursor

            obj = System.Activator.CreateInstanceFrom(assemblyFile, typeName)

            If TypeOf (obj.Unwrap()) Is IComandoMenu Then
               If Not String.IsNullOrWhiteSpace(parametros) AndAlso TypeOf (obj.Unwrap()) Is IConParametros Then
                  DirectCast(obj.Unwrap(), IConParametros).SetParametros(parametros)
               End If

               DirectCast(obj.Unwrap(), IComandoMenu).Ejecutar(Me, idFuncion)
            Else
               frm = DirectCast(obj.Unwrap(), Form)

               If Not String.IsNullOrWhiteSpace(parametros) AndAlso TypeOf (frm) Is IConParametros Then
                  DirectCast(frm, IConParametros).SetParametros(parametros)
               End If

               If TypeOf (frm) Is IConIdFuncion Then
                  DirectCast(frm, IConIdFuncion).IdFuncion = idFuncion
               End If

               If EsMDIChild Then
                  frm.MdiParent = Me
               End If

               frm.Show()
            End If

         Catch ex As Exception
            My.Application.Log.WriteEntry(String.Format("BasePrincipal - LevantaPantalla: {0}", ex.ToString()), TraceEventType.Warning)
            If mostrarMensajeError Then ShowError(ex) ' MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            If frm IsNot Nothing Then
               frm.Close()
            End If
         Finally
            System.Windows.Forms.Cursor.Current = Cursors.Default
         End Try
      End If         ' If abrirNuevaPantalla Then
   End Sub
   Private Sub Bitacora(IdFuncion As String)
      Try
         Dim oBitacora As Reglas.Bitacora = New Reglas.Bitacora()
         Dim Bitacora As Entidades.Bitacora = New Entidades.Bitacora()
         With Bitacora
            .IdSucursal = Eniac.Entidades.Usuario.Actual.Sucursal.IdSucursal
            .FechaBitacora = Date.Now()
            .IdFuncion = IdFuncion
            .IdUsuario = Eniac.Entidades.Usuario.Actual.Nombre
            .NombrePC = My.Computer.Name
            .Tipo = Entidades.Bitacora.TipoBitacora.IniciarPantalla.ToString()
            .Descripcion = ""
         End With
         oBitacora.Insertar(Bitacora)
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub
   Private Sub tsmAlertas_Click(sender As System.Object, e As EventArgs) Handles tsmAlertas.Click
      Try
         If Me.tsmAlertas.Checked Then
            Me._ale.Show()
         Else
            Me._ale.Hide()
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub tsmRecargarAlertas_Click(sender As System.Object, e As EventArgs) Handles tsmRecargarAlertas.Click
      Try
         Me.CargaAlertas()
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

#End Region

#Region "Metodos"

   Protected Sub SeteaLenguajeControlesInfragistics()
      TraductorInfragistics.TraducirShared()
   End Sub

   Protected Sub CargaAlertas()
      Me._ale.MdiParent = Me
      Me.AcomodarAlertas()

      Me.tsmAlertas.Checked = True
      Me._ale.Show()
   End Sub

   Protected Sub CargarTareas()
      Dim otareas As Reglas.Tareas = New Reglas.Tareas()
      Dim tareas As DataSet = New DataSet()
      tareas = otareas.GetxFecha(Date.Today())

      If tareas.Tables.Item("Table").Rows.Count <> 0 Then
         Dim tarea As Tareas = New Tareas()
         tarea.ShowDialog()
      End If
   End Sub

   Private Sub EjecutarQuerys()
      Dim oGene As Reglas.Generales = New Reglas.Generales()
      Try
         'leo el archivo xml
         If Not IO.File.Exists(System.Environment.CurrentDirectory & "\dsQuery.esq") Then
            Exit Sub
         End If
         If Not IO.File.Exists(System.Environment.CurrentDirectory & "\dsQuery.dat") Then
            Exit Sub
         End If
         Dim ds As DataSet = New DataSet()
         ds.ReadXmlSchema(System.Environment.CurrentDirectory & "\dsQuery.esq")
         ds.ReadXml(System.Environment.CurrentDirectory & "\dsQuery.dat")
         If ds.Tables.Count > 0 Then
            For Each dr As DataRow In ds.Tables(0).Rows
               Try
                  oGene.EjecutarQuery(dr("Query").ToString())
               Catch ex As Exception
                  'no hago nada si falla, ya que ejecuto los querys de a uno.
               End Try
            Next
         End If
         IO.File.Delete(System.Environment.CurrentDirectory & "\dsQuery.esq")
         IO.File.Delete(System.Environment.CurrentDirectory & "\dsQuery.dat")
      Catch ex As Exception
         'no hago nada, ya que si da error en cualquier cosa no lo tiene que ver el usuario
      End Try
   End Sub

   'Private Sub CrearMenuToolbar()
   '   Dim oUsuarios As Eniac.Reglas.Usuarios = New Eniac.Reglas.Usuarios()

   '   'Buscar todas las funciones que van en el menu superior del usuario actual 
   '   Dim dtPadres As DataTable = oUsuarios.ObtenerFunciones(Eniac.Entidades.Usuario.Actual.Nombre, Eniac.Entidades.Usuario.Actual.Sucursal.Id, Nothing)
   '   'Recorre todos las funciones obtenidas y crea los menus y la toolbar
   '   For Each dr As DataRow In dtPadres.Rows
   '      If Boolean.Parse(dr(usrEsMenu).ToString()) Then
   '         Me.CrearHijosMenu(Me.CrearItemMenu(dr))
   '      End If
   '      If Boolean.Parse(dr(usrEsBoton).ToString()) Then
   '         Me.CrearBoton(dr)
   '      End If
   '   Next

   '   Dim ixMenuAyuda As Integer = mnsPrincipal.Items.IndexOfKey("tsm_Ayuda")

   '   'Crea el itemMenu Ventanas de la aplicación
   '   Dim mnuVentanas As System.Windows.Forms.ToolStripMenuItem = _
   '   New System.Windows.Forms.ToolStripMenuItem("Ventanas")
   '   mnuVentanas.Name = "tsm_Ventanas"
   '   mnuVentanas.Size = New System.Drawing.Size(161, 22)
   '   If ixMenuAyuda > -1 Then
   '      Me.mnsPrincipal.Items.Insert(ixMenuAyuda, mnuVentanas)
   '   Else
   '      Me.mnsPrincipal.Items.Add(mnuVentanas)
   '   End If
   '   Me.mnsPrincipal.MdiWindowListItem = mnuVentanas

   '   mnuVentanas.DropDownItems.Add("&Cascada", Nothing, AddressOf Cascade)
   '   mnuVentanas.DropDownItems.Add("&Vertical", Nothing, AddressOf TileVertical)
   '   mnuVentanas.DropDownItems.Add("&Horizontal", Nothing, AddressOf TileHorizontal)
   '   mnuVentanas.DropDownItems.Add("Cerrar &Todas", Nothing, AddressOf CloseAll)

   '   'Crea el itemMenu About de la aplicación
   '   If ixMenuAyuda = -1 Then
   '      Dim mnuAyuda As ToolStripMenuItem = New ToolStripMenuItem("Ayuda")
   '      mnuAyuda.Name = "tsm_Ayuda"
   '      mnuAyuda.Size = New System.Drawing.Size(161, 22)
   '      mnuAyuda.DropDownItems.Add("Acerca de Sinergia...", Nothing, AddressOf About)
   '      Me.mnsPrincipal.Items.Add(mnuAyuda)

   '   End If

   '   ixMenuAyuda = mnsPrincipal.Items.IndexOfKey("tsm_Ayuda")

   '   Dim itemMenuAyuda As ToolStripMenuItem = mnsPrincipal.Items(ixMenuAyuda)
   '   itemMenuAyuda.DropDownItems.Add("Vincular Dispositivo", Nothing,
   '                                   Sub(sender As Object, e As EventArgs)
   '                                      Dim fr As Eniac.Win.VincularDispositivos = New Eniac.Win.VincularDispositivos()
   '                                      fr.MdiParent = Me
   '                                      fr.Show()
   '                                   End Sub)

   '   'Crea el itemMenu Salir de la aplicación
   '   Me.mnsPrincipal.Items.Add("-")
   '   Me.mnsPrincipal.Items.Add("&Salir", My.Resources._stop, AddressOf Salir)
   '   'Crea el boton salida de la aplicación
   '   'Me.tlsPrincipal.Items.Add("-")
   '   'Me.tlsPrincipal.Items.Add("Salir", My.Resources._stop, AddressOf Salir)
   'End Sub

   Private Sub Cascade(sender As Object, e As EventArgs)
      Me.LayoutMdi(MdiLayout.Cascade)
   End Sub

   Private Sub TileVertical(sender As Object, e As EventArgs)
      Me.LayoutMdi(MdiLayout.TileVertical)
   End Sub

   Private Sub TileHorizontal(sender As Object, e As EventArgs)
      Me.LayoutMdi(MdiLayout.TileHorizontal)
   End Sub

   Private Sub CloseAll(sender As Object, e As EventArgs)
      For Each ChildForm As Form In Me.MdiChildren
         ChildForm.Close()
      Next
   End Sub

   Private Sub CrearHijosMenu(padre As System.Windows.Forms.ToolStripMenuItem)
      Dim oUsuarios As Eniac.Reglas.Usuarios = New Eniac.Reglas.Usuarios()
      Dim dtHijos As DataTable = oUsuarios.ObtenerFunciones(Eniac.Entidades.Usuario.Actual.Nombre, Eniac.Entidades.Usuario.Actual.Sucursal.Id, padre.Name.Replace("tsm_", ""))
      For Each dr As DataRow In dtHijos.Rows
         If Boolean.Parse(dr(usrEsMenu).ToString()) Then
            Me.CrearHijosMenu(Me.CrearItemMenuHijo(padre, dr))
         End If
         If Boolean.Parse(dr(usrEsBoton).ToString()) Then
            Me.CrearBoton(dr)
         End If
      Next
   End Sub

   Private Function CrearBoton(dr As DataRow) As System.Windows.Forms.ToolStripButton
      Dim tsbBoton As System.Windows.Forms.ToolStripButton =
              New System.Windows.Forms.ToolStripButton(dr(usrId).ToString(), Nothing, AddressOf CargaPantallasBoton)
      tsbBoton.ImageTransparentColor = System.Drawing.Color.Magenta
      tsbBoton.ToolTipText = dr(usrDescripcion).ToString()
      tsbBoton.Name = "tsb" + dr(usrId).ToString()
      tsbBoton.Text = dr(usrNombre).ToString()
      tsbBoton.Enabled = Boolean.Parse(dr(usrEnabled).ToString())
      tsbBoton.Visible = Boolean.Parse(dr(usrVisible).ToString())
      tsbBoton.Tag = dr
      tsbBoton.Image = Me.GetImagen(dr)
      tsbBoton.Size = New System.Drawing.Size(65, 22)
      Me.tlsPrincipal.Items.Add(tsbBoton)
      Return tsbBoton
   End Function

   Private Function CrearItemMenuHijo(padre As System.Windows.Forms.ToolStripMenuItem, dr As DataRow) As System.Windows.Forms.ToolStripMenuItem
      Dim mnuMenu As System.Windows.Forms.ToolStripMenuItem =
         New System.Windows.Forms.ToolStripMenuItem(dr(usrId).ToString(), Nothing, AddressOf CargaPantallas)
      mnuMenu.Name = "tsm_" + dr(usrId).ToString()
      mnuMenu.Text = dr(usrNombre).ToString()
      mnuMenu.Enabled = Boolean.Parse(dr(usrEnabled).ToString())
      mnuMenu.Visible = Boolean.Parse(dr(usrVisible).ToString())
      mnuMenu.ToolTipText = dr(usrDescripcion).ToString()
      mnuMenu.Tag = dr
      mnuMenu.Image = Me.GetImagen(dr)
      mnuMenu.Size = New System.Drawing.Size(161, 22)
      padre.DropDownItems.Add(mnuMenu)
      Return mnuMenu
   End Function

   Private Function CrearItemMenu(dr As DataRow) As System.Windows.Forms.ToolStripMenuItem
      Dim mnuMenu As System.Windows.Forms.ToolStripMenuItem =
              New System.Windows.Forms.ToolStripMenuItem()
      mnuMenu.Name = "tsm_" + dr(usrId).ToString()
      mnuMenu.Text = dr(usrNombre).ToString()
      mnuMenu.Enabled = Boolean.Parse(dr(usrEnabled).ToString())
      mnuMenu.Visible = Boolean.Parse(dr(usrVisible).ToString())
      mnuMenu.Size = New System.Drawing.Size(161, 22)
      mnuMenu.Text = dr(usrNombre).ToString()
      Me.mnsPrincipal.Items.Add(mnuMenu)
      Return mnuMenu
   End Function

   Private Function GetImagen(dr As DataRow) As Bitmap
      Try
         If Not dr.IsNull("Icono") Then
            Dim content() As Byte = CType(dr("Icono"), Byte())
            Dim stream As System.IO.MemoryStream = New System.IO.MemoryStream(content)
            Return New Bitmap(stream)
         End If
      Catch
      End Try
      Return Nothing
   End Function

   Public Sub BarraProgresoSetearValor(valor As Integer)
      Me.tspProgreso.Value = valor
   End Sub

   Public Sub BarraProgresoTerminar()
      Me.tspProgreso.Value = Me.tspProgreso.Maximum
      Me.tspProgreso.Visible = False
   End Sub

   Public Sub BarraProgresoComenzar(minimo As Integer, maximo As Integer)
      Me.tspProgreso.Visible = True
      Me.tspProgreso.Minimum = minimo
      Me.tspProgreso.Maximum = maximo
   End Sub

   Private Function GetNombreAssembly(clase As String) As String
      Dim nom As String = Application.StartupPath + "\" + clase
      If System.IO.File.Exists(nom + ".exe") Then
         Return nom + ".exe"
      Else
         Return nom + ".dll"
      End If
      Return ""
      'Environment.CurrentDirectory 
   End Function

   Private Sub AcomodarAlertas()
      If Me._ale IsNot Nothing Then
         _ale.Dock = DockStyle.Right
      End If
   End Sub


#End Region

End Class