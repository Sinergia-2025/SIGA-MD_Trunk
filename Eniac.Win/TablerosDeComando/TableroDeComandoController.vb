Imports Eniac.Reglas.ServiciosRest.SSSServicioWeb
Public Class TableroDeComandoController

   'Public Enum VerNombreCliente
   '   <Description("Nombre de Cliente")> NombreCliente
   '   <Description("Nombre de Fantasia")> NombreDeFantasia
   'End Enum

   Private Property Grillas As List(Of GrillaController)

   Public WithEvents tssInfo As System.Windows.Forms.ToolStripStatusLabel
   Public WithEvents Timer1 As System.Windows.Forms.Timer
   Public WithEvents bwkBajarDatosBackup As System.ComponentModel.BackgroundWorker

   'Public Property NombreCliente As VerNombreCliente
   Public Property Intervalo As Integer
      Get
         If Timer1 IsNot Nothing Then Return Convert.ToInt32(Timer1.Interval / 60 / 1000)
         Return 0
      End Get
      Set(value As Integer)
         If Timer1 IsNot Nothing Then
            Dim temp As Boolean = ActualizacionAutomatica
            ActualizacionAutomatica = False
            Timer1.Interval = value * 60 * 1000
            ActualizacionAutomatica = temp
         End If
      End Set
   End Property
   Public Property ActualizacionAutomatica As Boolean
      Get
         Return If(Timer1 IsNot Nothing, Timer1.Enabled, False)
      End Get
      Set(value As Boolean)
         If Timer1 IsNot Nothing Then
            Timer1.Enabled = value
         End If
      End Set
   End Property


   Private _contexto As BaseForm
   Private _controlesDesactivar As Object()
   Private _filtroUserControl As IFiltroTableros

   Private rTablero As Reglas.TableroDeComando

   Public Sub New(contexto As BaseForm, controlesDesactivar As Object())
      _contexto = contexto
      _controlesDesactivar = controlesDesactivar
      Grillas = New List(Of GrillaController)()

      rTablero = New Reglas.TableroDeComando()
   End Sub

   Public Function Inicializar(parametro As String, grillas As UltraGrid(), panelFiltros As Panel, location As Point) As Entidades.TableroControl
      Dim tablero = AgregarGrillas(parametro, grillas)
      _filtroUserControl = FiltroTablerosFactory.Crear(tablero)
      If _filtroUserControl IsNot Nothing Then
         Dim uc = DirectCast(_filtroUserControl, UserControl)
         uc.Location = location
         panelFiltros.Controls.Add(uc)
      End If
      Return tablero
   End Function

   Private Function AgregarGrillas(parametro As String, grillas As UltraGrid()) As Entidades.TableroControl
      Dim idTableroControl As Integer = 0
      If Not String.IsNullOrWhiteSpace(parametro) Then
         If IsNumeric(parametro) Then
            idTableroControl = Integer.Parse(parametro)
         Else
            Dim paramArr = parametro.Split(";"c)
            For Each par In paramArr
               Dim kv = par.Split("="c)
               If kv(0) = "Tablero" AndAlso IsNumeric(kv(1)) Then
                  idTableroControl = Integer.Parse(kv(1))
               End If
            Next
         End If
      End If
      Return AgregarGrillas(idTableroControl, grillas)
   End Function

   Public Function AgregarGrillas(idTableroControl As Integer, grillas As UltraGrid()) As Entidades.TableroControl
      Dim tablero As Entidades.TableroControl = Nothing
      If idTableroControl > 0 Then
         tablero = New Reglas.TablerosControl().GetUno(idTableroControl, Reglas.Base.AccionesSiNoExisteRegistro.Vacio)

         AgregarGrilla(tablero.TableroControlPanel1, grillas, 0)
         AgregarGrilla(tablero.TableroControlPanel2, grillas, 1)
         AgregarGrilla(tablero.TableroControlPanel3, grillas, 2)
         AgregarGrilla(tablero.TableroControlPanel4, grillas, 3)
         AgregarGrilla(tablero.TableroControlPanel5, grillas, 4)
         AgregarGrilla(tablero.TableroControlPanel6, grillas, 5)

         'If grillas.Length <= 1 AndAlso Not String.IsNullOrWhiteSpace(tablero.TableroControlPanel1.IdController) Then
         '   Crear(tablero.TableroControlPanel1.IdController, grillas(0))
         'End If

      End If
      Return tablero
   End Function

   Private Function AgregarGrilla(panel As Entidades.TableroControlPanel, grillas As UltraGrid(), posicion As Integer) As TableroDeComandoController
      If grillas.Length > posicion Then
         Return AgregarGrilla(panel, grillas(posicion))
      End If
      Return Me
   End Function
   Private Function AgregarGrilla(panel As Entidades.TableroControlPanel, grilla As UltraGrid) As TableroDeComandoController
      Return AgregarGrilla(Crear(panel, grilla))
   End Function

   Public Function AgregarGrilla(grilla As GrillaController) As TableroDeComandoController
      Grillas.Add(grilla.SetReglaTablero(rTablero))
      AddHandler grilla.SolicitaRefrescarGrilla, Sub(sender As Object, e As EventArgs)
                                                    CargarGrillaDetalle()
                                                 End Sub
      Return Me
   End Function
   Public Function ClearGrillas() As TableroDeComandoController
      For Each gr As GrillaController In Grillas
         gr.Dispose()
      Next
      Grillas.Clear()
      Return Me
   End Function

   Public Sub RefrescarGrillas()
      If _filtroUserControl IsNot Nothing Then
         _filtroUserControl.RefrescarGrilla()
      End If
      CargarGrillaDetalle()
   End Sub

   Public Sub CargarGrillaDetalle()
      Try
         _contexto.Cursor = Cursors.WaitCursor
         For Each grilla As GrillaController In Grillas
            RefrescarGrilla(grilla)
         Next
      Finally
         _contexto.Cursor = Cursors.Default
      End Try
   End Sub

   Private Sub RefrescarGrilla(grilla As GrillaController)
      Dim filtros = If(_filtroUserControl Is Nothing, New Entidades.TablerosDeComando.FiltroTableros(), _filtroUserControl.GetFiltros())
      grilla.Filtros = filtros
      grilla.SetDataSource(grilla.GetDatos(filtros))
   End Sub

   Public Shared Function ParseaTableros(tableros As String, tablerosDefaultSplit As String()) As List(Of String)
      Dim result = tablerosDefaultSplit.ToList()

      For i = 1 To If(tableros Is Nothing, String.Empty, tableros).Length - 1
         result(i) = tableros(i)
      Next

      'Dim result As List(Of String) = If(String.IsNullOrWhiteSpace(tableros), tablerosDefaultSplit.ToList(), tableros.Split(";"c).ToList())

      'For i As Integer = 1 To tablerosDefaultSplit.Count - 1
      '   If result.Count = i Then
      '      result.Add(tablerosDefaultSplit(i))
      '   End If
      'Next

      Return result
   End Function


#Region "BackgroundWorker"
   Public Sub InicializaBackgroundWorker()
      HabilitarControlers(False)
      If Timer1 IsNot Nothing Then
         Timer1.Stop()
      End If
      If bwkBajarDatosBackup IsNot Nothing Then
         bwkBajarDatosBackup.RunWorkerAsync()
      Else
         bwkBajarDatosBackup_RunWorkerCompleted(Nothing, Nothing)
      End If
   End Sub

   Private Sub bwkBajarDatosBackup_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles bwkBajarDatosBackup.DoWork
      Try
         ''TODO: una vez que no haya más registros en http://wi531792.ferozo.com/SSSServicioWeb/api/, quitar la importación de dicha URL
         'Dim rEjecucionBackupLegacy As New Reglas.ServiciosRest.SSSServicioWeb.EjecucionBase(EjecucionBackup.BaseUriLegacy)
         'AddHandler rEjecucionBackupLegacy.AvanceImportarAutomaticamente, Sub(sender1 As Object, e1 As EjecucionBase.AvanceImportarAutomaticamenteEventArgs)
         '                                                                    bwkBajarDatosBackup.ReportProgress(0, e1.Etapa)
         '                                                                 End Sub
         'rEjecucionBackupLegacy.ImportarAutomaticamente()
         ''FIN http://wi531792.ferozo.com/SSSServicioWeb/api/

         Dim rEjecucionBackup = New Reglas.ServiciosRest.SSSServicioWeb.EjecucionBackup(EjecucionBase.BaseUriActual)
         AddHandler rEjecucionBackup.AvanceImportarAutomaticamente, Sub(sender1 As Object, e1 As EjecucionBase.AvanceImportarAutomaticamenteEventArgs)
                                                                       bwkBajarDatosBackup.ReportProgress(0, e1.Etapa)
                                                                    End Sub
         rEjecucionBackup.ImportarAutomaticamente()
      Catch ex As Exception
         bwkBajarDatosBackup.ReportProgress(0, ex)
      End Try

      Try
         Dim rEjecucionActualizador = New Reglas.ServiciosRest.SSSServicioWeb.EjecucionActualizador(EjecucionBase.BaseUriActual)
         AddHandler rEjecucionActualizador.AvanceImportarAutomaticamente, Sub(sender1 As Object, e1 As EjecucionBase.AvanceImportarAutomaticamenteEventArgs)
                                                                             bwkBajarDatosBackup.ReportProgress(0, e1.Etapa)
                                                                          End Sub
         rEjecucionActualizador.ImportarAutomaticamente()
      Catch ex As Exception
         bwkBajarDatosBackup.ReportProgress(0, ex)
      End Try

      Try
         Dim rVersionesServiciosRest = New VersionesServiciosRest()
         AddHandler rVersionesServiciosRest.AvanceImportarAutomaticamente, Sub(sender1 As Object, e1 As VersionesServiciosRest.AvanceImportarAutomaticamenteEventArgs)
                                                                              bwkBajarDatosBackup.ReportProgress(0, e1.Etapa)
                                                                           End Sub
         rVersionesServiciosRest.ImportarAutomaticamente()
      Catch ex As Exception
         bwkBajarDatosBackup.ReportProgress(0, ex)
      End Try

      Try
         Dim rSincronizarTickets = New Reglas.ServiciosRest.Soporte.SincronizarTickets()
         AddHandler rSincronizarTickets.Avance, Sub(sender1 As Object, e1 As Reglas.ServiciosRest.SincronizacionEventArgs)
                                                   bwkBajarDatosBackup.ReportProgress(0, e1.Mensaje)
                                                End Sub
         rSincronizarTickets.ImportarAutomaticamente()

      Catch ex As Exception
         bwkBajarDatosBackup.ReportProgress(0, ex)
      End Try
   End Sub

   Private Sub bwkBajarDatosBackup_ProgressChanged(sender As Object, e As System.ComponentModel.ProgressChangedEventArgs) Handles bwkBajarDatosBackup.ProgressChanged
      If TypeOf (e.UserState) Is Exception Then
         _contexto.ShowError(DirectCast(e.UserState, Exception))
      ElseIf TypeOf (e.UserState) Is String Then
         tssInfo.Text = e.UserState.ToString()
      End If
   End Sub

   Private Sub bwkBajarDatosBackup_RunWorkerCompleted(sender As Object, e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles bwkBajarDatosBackup.RunWorkerCompleted
      tssInfo.Text = "Actualizando grillas"
      CargarGrillaDetalle()

      HabilitarControlers(True)
      tssInfo.Text = String.Empty

      If Timer1 IsNot Nothing Then
         Timer1.Start()
      End If
   End Sub
#End Region

   Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
      Try
         InicializaBackgroundWorker()
      Catch ex As Exception
         _contexto.ShowError(ex)
      End Try
   End Sub

   Private Sub HabilitarControlers(habilitar As Boolean)
      For Each ctrl As Object In _controlesDesactivar
         If TypeOf (ctrl) Is Control Then
            DirectCast(ctrl, Control).Enabled = habilitar
         ElseIf TypeOf (ctrl) Is ToolStripItem Then
            DirectCast(ctrl, ToolStripItem).Enabled = habilitar
         End If
      Next
   End Sub

#Region "Factory Grilla Controller"
   'Public Enum Controllers
   '   <Description("Backups")> GrillaBackup
   '   <Description("Vencimiento de Licencias")> GrillaVencimientoLicencias
   '   <Description("Dispositivos Clientes")> GrillaPcs
   '   <Description("Clientes por Largar")> GrillaLargada
   '   <Description("Versión Aplicación")> GrillaVersionAplicacion
   '   <Description("Versión Api")> GrillaVersionApi
   '   <Description("Tickets")> GrillaTickets
   '   <Description("Pendientes")> GrillaPendientes
   '   <Description("Actualizador Automático")> ActualizadorAutomatico
   '   <Description("Actualizador Automático (Alerta)")> ActualizadorAutomaticoAlerta
   'End Enum

   Public Function Crear(panel As Entidades.TableroControlPanel, grilla As UltraGrid) As GrillaController
      Try
         If Not String.IsNullOrWhiteSpace(panel.IdController) Then
            Dim assemblyName As String = String.Empty
            Dim className As String
            Dim splitController = panel.IdController.Split(":"c)
            If splitController.Length > 1 Then
               assemblyName = splitController(0)
               className = splitController(1)
            Else
               If splitController(0).Contains(".") Then
                  Dim posicionUltimoPunto = splitController(0).LastIndexOf("."c)
                  assemblyName = splitController(0).Substring(0, posicionUltimoPunto)
               End If
               className = splitController(0)
            End If

            Dim assembly As System.Reflection.Assembly = Nothing
            If Not String.IsNullOrWhiteSpace(assemblyName) Then
               Try
                  assembly = AppDomain.CurrentDomain.GetAssemblies().SingleOrDefault(Function(a) a.GetName().Name = assemblyName)
               Catch ex As Exception
                  assembly = Nothing
               End Try
            End If
            If assembly Is Nothing Then
               assembly = System.Reflection.Assembly.GetExecutingAssembly()
            End If

            If Not className.Contains(".") Then
               className = String.Concat(assembly.GetName().Name, ".", className)
            End If

            Dim type = assembly.GetType(className)

            Dim obj = System.Activator.CreateInstance(type, grilla, panel)

            If TypeOf (obj) Is GrillaController Then
               Return DirectCast(obj, GrillaController)
            End If

         End If
      Catch ex As Exception

      End Try
      Return New GrillaDummy(grilla, panel)
   End Function

   'Public Function Crear(controller As String, grilla As UltraGrid) As GrillaController
   '   Dim ctrl As Controllers
   '   Try
   '      ctrl = DirectCast([Enum].Parse(GetType(Controllers), controller), Controllers)
   '   Catch ex As Exception
   '      Throw New NotImplementedException(String.Format("El controlador de grilla {0} no existe.", controller), ex)
   '   End Try
   '   Return Crear(ctrl, grilla)
   'End Function
   'Public Function Crear(controller As Controllers, grilla As UltraGrid) As GrillaController
   '   Select Case controller
   '      Case Controllers.GrillaBackup
   '         Return New GrillaBackup(grilla, controller)
   '      Case Controllers.GrillaLargada
   '         Return New GrillaLargada(grilla, controller)
   '      Case Controllers.GrillaPcs
   '         Return New GrillaPcs(grilla, controller)
   '      Case Controllers.GrillaTickets
   '         Return New GrillaTickets(grilla, controller)
   '      Case Controllers.GrillaVencimientoLicencias
   '         Return New GrillaVencimientoLicencias(grilla, controller)
   '      Case Controllers.GrillaVersionAplicacion
   '         Return New GrillaVersionAplicacion(grilla, controller)
   '      Case Controllers.GrillaVersionApi
   '         Return New GrillaVersionApi(grilla, controller)
   '      Case Controllers.GrillaPendientes
   '         Return New GrillaPendientes(grilla, controller)
   '      Case Controllers.ActualizadorAutomatico
   '         Return New GrillaActualizador(grilla, controller)
   '      Case Controllers.ActualizadorAutomaticoAlerta
   '         Return New GrillaActualizadorAlerta(grilla, controller)
   '      Case Else
   '         Throw New NotImplementedException(String.Format("El controlador de grilla {0} no existe.", controller.ToString()))
   '   End Select
   'End Function
#End Region

End Class