Imports Infragistics.Win.Misc
Public Class Alertas

   Private Property OpenWithDobleClick() As Boolean = False

   Private Shared Property TienePermisosDeDolar As Boolean

   Public Sub New()
      InitializeComponent()
      Mostrar = True
   End Sub

   Protected Overrides Sub OnLoad(e As EventArgs)
      MyBase.OnLoad(e)

      Try
         ugAlertas.DataSource = New List(Of Entidades.Alerta)()
         ugAlertas.DisplayLayout.Bands(0).ColHeadersVisible = False
         TienePermisosDeDolar = New Reglas.Usuarios().TienePermisos(actual.Nombre, actual.Sucursal.Id, "ActualizaValorDolar")
         lblAAplicar.Visible = TienePermisosDeDolar
         txtDolarAAplicar.Visible = TienePermisosDeDolar
         btnAplicar.Visible = TienePermisosDeDolar
         Recargar()
      Catch ex As Exception
      End Try
   End Sub

   Public Property Mostrar() As Boolean

   Public Overridable Sub Recargar()
      'limpia los items de los grupos
      'controla las alertas del sistema
      Dim config As Entidades.ConfiguracionesAplicacion = New Reglas.ConfiguracionesAplicacion().LeerArchivo()
      Try
         btnRefrescar.Visible = False

         _timer.Stop()

         Dim win8version As Version = New Version(6, 2, 9200, 0)

         If config.EjecutaAlerta Then
            If config.EjecutaAsync Then

               Dim task As Threading.Tasks.Task = New Threading.Tasks.Task(AddressOf RecargarAsync)
               ' Start and wait for task to end.
               task.Start()

            Else

               Dim alertas As List(Of Entidades.Alerta) = New List(Of Entidades.Alerta)()
               Dim alerta As Entidades.Alerta = New Entidades.Alerta()
               alerta.Key = Entidades.Alerta.Tipos.NoDefinido
               alerta.MensajeDeAlerta = "      Cargando..."
               alertas.Add(alerta)
               ParalelMethod(alertas)

               alertas = GetAlertasDeReglas()

               ParalelMethod(alertas)


            End If
         Else

         End If

      Catch ex As Exception

      Finally
         If config.EjecutaAsync Then
            _timer.Interval = config.MinutosEjecucionAlertas * 60000 'por defecto esta en 60 minutos
         Else
            _timer.Interval = config.MinutosEjecucionAlertas * 60000 'por defecto esta en 60 minutos
         End If
         _timer.Start()
      End Try
   End Sub

   Async Sub RecargarAsync()
      Dim alertas As List(Of Entidades.Alerta) = New List(Of Entidades.Alerta)()
      Dim alertaCargando As Entidades.Alerta = New Entidades.Alerta()
      alertaCargando.Key = Entidades.Alerta.Tipos.NoDefinido
      alertaCargando.MensajeDeAlerta = "      Cargando..."

      Try
         FindForm().Invoke(Sub() btnRefrescar.Visible = False)

         alertas.Add(alertaCargando)
         ParalelMethod(alertas)

         Dim task As Threading.Tasks.Task(Of List(Of Entidades.Alerta)) = GetAlertasDeReglasAsync()
         alertas = Await task

         ParalelMethod(alertas)

      Catch ex As Exception
         Try
            My.Application.Log.WriteEntry(String.Format("ERROR CARGANDO ALERTAS{0}{0}Error: {1}{0}Stack Trace: {2}",
                                                        Environment.NewLine,
                                                        ex.Message,
                                                        ex.StackTrace), TraceEventType.Error)
         Catch ex1 As Exception
         End Try
         alertaCargando.MensajeDeAlerta = "   ERROR Cargando Alertas..."
         alertaCargando.Tag = ex
         ParalelMethod(alertas)
      Finally
         FindForm().Invoke(Sub() btnRefrescar.Visible = True)
      End Try
   End Sub

   Private Sub ParalelMethod(arg As List(Of Entidades.Alerta))
      If InvokeRequired Then
         Dim dlg As Action(Of List(Of Entidades.Alerta)) = New Action(Of List(Of Entidades.Alerta))(AddressOf ParalelMethod)
         Invoke(dlg, arg)
      Else
         ugAlertas.DataSource = arg
         If ugAlertas.DisplayLayout.Bands(0).Columns.Exists("MostrarEnLista") Then
            ugAlertas.DisplayLayout.Bands(0).ColumnFilters("MostrarEnLista").FilterConditions.Add(FilterComparisionOperator.Equals, True)
         End If
         If ugAlertas.DisplayLayout.Bands(0).Columns.Exists("OrdenPrioridad") Then
            ugAlertas.DisplayLayout.Bands(0).SortedColumns.Add("OrdenPrioridad", False)
         End If

         ugAlertas.Rows.Refresh(RefreshRow.ReloadData)

         Me.txtDolarSistema.Text = New Reglas.Monedas().GetUna(2).FactorConversion.ToString("N2")
         Dim cotizacionPromedio As Decimal
         Try
            cotizacionPromedio = New Reglas.ServiciosRest.CotizacionMonedas.CotizacionMonedas().ObtenerCotizacionValor()
         Catch ex As Exception
            'si da error que no haga nada
            cotizacionPromedio = 0
         End Try
         Me.txtDolarAAplicar.Text = cotizacionPromedio.ToString("N2")

         pnlConfiguracionBackup.Visible = False
         Dim tienePermisosVerBackup As Boolean = True 'New Reglas.Usuarios().TienePermisos(actual.Nombre, actual.Sucursal.Id, "ActualizaValorDolar")
         If tienePermisosVerBackup Then
            Dim fiArchivoConfig As IO.FileInfo = New IO.FileInfo("c:\Eniac\SSSServicio\bin\ServiceConfig.xml")
            If fiArchivoConfig.Exists Then
               Try
                  Dim cfgBck As SSSServicioHelper.Configuration.ServiceConfig = New SSSServicioHelper.Configuration.ConfigProvider(fiArchivoConfig.FullName).LoadConfiguration()
                  chbLunes.Checked = cfgBck.Schedule.EjecutaLunes
                  chbMartes.Checked = cfgBck.Schedule.EjecutaMartes
                  chbMiercoles.Checked = cfgBck.Schedule.EjecutaMiercoles
                  chbJueves.Checked = cfgBck.Schedule.EjecutaJueves
                  chbViernes.Checked = cfgBck.Schedule.EjecutaViernes
                  chbSabado.Checked = cfgBck.Schedule.EjecutaSabado
                  chbDomingo.Checked = cfgBck.Schedule.EjecutaDomingo

                  mtbProHoraDesde.Text = cfgBck.Schedule.HoraDesde.Replace(":", "")
                  mtbProHoraHasta.Text = cfgBck.Schedule.HoraHasta.Replace(":", "")
                  txtProFrecuencia.Text = cfgBck.Schedule.Frecuencia.ToString()

                  Dim correos As StringBuilder = New StringBuilder()
                  For Each dest As String In cfgBck.Mail.To
                     If Not String.IsNullOrWhiteSpace(dest) Then
                        correos.AppendFormat("{0};", dest.Trim())
                     End If
                  Next
                  txtDestinatarios.Text = correos.ToString().Replace(Environment.NewLine, ";").Trim(";"c)

                  If String.IsNullOrWhiteSpace(Me.txtDestinatarios.Text) Then
                     txtDestinatarios.Text = "ATENCION"
                     txtDestinatarios.BackColor = Color.Red
                     txtDestinatarios.ForeColor = Color.White
                     txtDestinatarios.TextAlign = HorizontalAlignment.Center
                  End If

                  pnlConfiguracionBackup.Visible = True
               Catch ex As Exception
               End Try
            End If
         End If

         MostrarPopUp(arg)

         'cuento los items para ver si muestro o no las alertas
         If arg.Count = 0 Then
            Mostrar = False
         Else
            Mostrar = True
         End If
      End If
   End Sub

#Disable Warning BC42356 ' This async method lacks 'Await' operators and so will run synchronously
   Async Function GetAlertasDeReglasAsync() As Threading.Tasks.Task(Of List(Of Entidades.Alerta))
#Enable Warning BC42356 ' This async method lacks 'Await' operators and so will run synchronously
      Dim result As List(Of Entidades.Alerta) = GetAlertasDeReglas()
      Return result
   End Function

   Protected Overridable Function GetAlertasDeReglas() As List(Of Entidades.Alerta)
      Return GetRegla().GetPorSucursal(actual.Nombre, actual.Sucursal.IdSucursal)
   End Function

   Protected Overridable Function GetRegla() As Reglas.Alertas
      Return New Reglas.Alertas()
   End Function

   Private Sub MostrarPopUp(alertas As List(Of Entidades.Alerta))
      For Each alerta As Entidades.Alerta In alertas
         MostrarPopUp(alerta)
      Next
   End Sub
   Private Sub MostrarPopUp(alerta As Entidades.Alerta)
      If alerta.MostrarPopUp Then
         Try
            If UltraDesktopAlert1.GetWindowInfo(alerta.Key.ToString()) Is Nothing Then
               Dim winInfo As UltraDesktopAlertShowWindowInfo = New UltraDesktopAlertShowWindowInfo()
               winInfo.Caption = "Alerta"
               winInfo.Text = alerta.MensajeDeAlerta
               winInfo.Key = alerta.Key.ToString()
               winInfo.Data = alerta

               If alerta.Color.HasValue Then
                  UltraDesktopAlert1.Appearance.BackColor = alerta.Color.Value
                  UltraDesktopAlert1.Appearance.BackColor2 = alerta.Color.Value
                  UltraDesktopAlert1.GripAreaAppearance.BackColor = alerta.Color.Value
                  UltraDesktopAlert1.GripAreaAppearance.BackColor2 = alerta.Color.Value
                  UltraDesktopAlert1.Opacity = 1
               End If

               UltraDesktopAlert1.Show(winInfo)
            End If
         Catch ex As Exception
         End Try
      End If
   End Sub

   Public Overridable Sub CargarPantallas(ByVal key As Entidades.Alerta)
      MostrarPopUp(key)
      '-- 36589 - Las alertas que se muestran deben ser sólo las de la Sucursal de la misma Empresa (mismo Cuit) y de las sucursales vinculadas por más que tengan diferente CUIT
      Dim SucursalesAlerta As List(Of Entidades.Sucursal) = New Reglas.Sucursales().GetParaAlerta()

      Select Case key.Key
         Case Entidades.Alerta.Tipos.NoDefinido
            If TypeOf (key.Tag) Is Exception Then
               ShowError(DirectCast(key.Tag, Exception), recursivo:=True)
            End If
         Case Entidades.Alerta.Tipos.LicenciasVsDispositivos
            Dim fr As ConsultaGenerica = New ConsultaGenerica(New Reglas.Dispositivos().GetLicenciasVsDispositivos())
            fr.Width = 900
            fr.Text = key.TituloConsultaGenerica
            fr.MdiParent = Me.MdiParent
            fr.Show()

         Case Entidades.Alerta.Tipos.ProductosSinStock
            Dim fr As ConsultaGenerica = New ConsultaGenerica(New Reglas.ProductosSucursales().GetProductosSinStock(actual.Sucursal.IdSucursal))
            fr.Width = 950
            fr.Text = key.TituloConsultaGenerica
            fr.MdiParent = Me.MdiParent
            fr.Show()
         Case Entidades.Alerta.Tipos.ChequesADepositar
            'Dim fr As ConsultaGenerica = New ConsultaGenerica(New Reglas.Cheques().GetChequesADepositar(DateTime.Now))
            'fr.Text = key.Titulo
            Dim fr As InformeChequesDeTerceros = New InformeChequesDeTerceros()
            fr.ConsultarAutomaticamente = True
            fr.MdiParent = Me.MdiParent
            fr.Show()
         Case Entidades.Alerta.Tipos.RemitosSinFacturar
            Dim fr As ConsultaGenerica = New ConsultaGenerica(New Reglas.Ventas().GetRemitosSinFacturar(SucursalesAlerta))
            fr.Width = 950
            fr.Text = key.TituloConsultaGenerica
            fr.MdiParent = Me.MdiParent
            fr.Show()
         Case Entidades.Alerta.Tipos.PuntoDePedidosDeProductos
            Dim fr As InfPuntoDePedidoDeProductos = New InfPuntoDePedidoDeProductos()
            fr.ConsultarAutomaticamente = True
            fr.MdiParent = Me.MdiParent
            fr.Show()
         Case Entidades.Alerta.Tipos.StockMinimoDeProductos
            Dim fr As InfStockMinimoDeProductos = New InfStockMinimoDeProductos()
            fr.ConsultarAutomaticamente = True
            fr.MdiParent = Me.MdiParent
            fr.Show()
         Case Entidades.Alerta.Tipos.TopesCaja
            MessageBox.Show(key.MensajeDeAlerta, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)


            'ALERTAS DE CONSISTENCIA DE LA INFORMACION.
         Case Entidades.Alerta.Tipos.InconsistenciaStockVsStockLotes
            Dim fr As ConsultaGenerica = New ConsultaGenerica(New Reglas.ProductosSucursales().GetInconsistenciaStockVsStockLotes(actual.Sucursal.IdSucursal))
            fr.Width = 800
            fr.Text = key.TituloConsultaGenerica
            fr.MdiParent = Me.MdiParent
            fr.Show()
         Case Entidades.Alerta.Tipos.InconsistenciaStockVsMovimientosDeStock
            Dim fr = New ConsultaGenerica(New Reglas.ProductosSucursales().GetInconsistenciaStockVsMovimientosDeStock(actual.Sucursal.IdSucursal))
            fr.Width = 850
            fr.Text = key.TituloConsultaGenerica
            fr.MdiParent = MdiParent
            fr.Show()
            '------------------------------------------
         Case Entidades.Alerta.Tipos.InconsistenciaDepositosVsSucursales
            Dim fr = New ConsultaGenerica(New Reglas.ProductosDepositos().GetInconsistenciaDepositosVsSucursales(actual.Sucursal.IdSucursal))
            fr.Width = 850
            fr.Text = key.TituloConsultaGenerica
            fr.MdiParent = MdiParent
            fr.Show()
            '------------------------------------------
         Case Entidades.Alerta.Tipos.InconsistenciaDepositosVsUbicaciones
            Dim fr = New ConsultaGenerica(New Reglas.ProductosUbicaciones().GetInconsistenciaDepositosVsUbicaciones(actual.Sucursal.IdSucursal))
            fr.Width = 850
            fr.Text = key.TituloConsultaGenerica
            fr.MdiParent = MdiParent
            fr.Show()
            '------------------------------------------
         Case Entidades.Alerta.Tipos.InconsistenciaUbicacionesVsMovimientoDeStock
            Dim fr = New ConsultaGenerica(New Reglas.ProductosUbicaciones().GetInconsistenciaUbicacionesVsMovStock(actual.Sucursal.IdSucursal))
            fr.Width = 850
            fr.Text = key.TituloConsultaGenerica
            fr.MdiParent = MdiParent
            fr.Show()
            '------------------------------------------
         Case Entidades.Alerta.Tipos.InconsistenciaDepositosVsMovimientoDeStock
            Dim fr = New ConsultaGenerica(New Reglas.ProductosDepositos().GetInconsistenciaDepositosVsMovStock(actual.Sucursal.IdSucursal))
            fr.Width = 850
            fr.Text = key.TituloConsultaGenerica
            fr.MdiParent = MdiParent
            fr.Show()
            '------------------------------------------
         Case Entidades.Alerta.Tipos.ConfiguracionImpresoras
            Dim fr As ImpresorasABM = New ImpresorasABM()
            fr.ConsultarAutomaticamente = True
            fr.MdiParent = Me.MdiParent
            fr.Show()

         Case Entidades.Alerta.Tipos.ControlVersion
            MessageBox.Show("La Versión Actual es antigüa ( " _
                              & Publicos.VersionDB & " ), debe actualizarla a " _
                            & My.Application.Info.Version.ToString() _
                            & ". Por Favor cierre la aplicación y vuelva a entrar.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)

         Case Entidades.Alerta.Tipos.ControlSaltoNumeracion
            Dim fr As ConsultaGenerica = New ConsultaGenerica(key.Tag)
            fr.Width = 800
            fr.Text = key.TituloConsultaGenerica
            fr.MdiParent = Me.MdiParent
            fr.Show()

         Case Entidades.Alerta.Tipos.ControlNetFwk
            TryCatched(Sub()
                          Using frm = New CheckNetFrameworkVersion()
                             frm.ShowDialog(Me)
                          End Using
                       End Sub)

         Case Entidades.Alerta.Tipos.ControlInconsistenciasCtaCteClientesVsCtaCtePagos
            Dim fr As ConsultaGenerica = New ConsultaGenerica(New Reglas.CuentasCorrientesPagos().GetControlInconsistenciasCtaCteVsCtaCtePagos(actual.Sucursal.IdSucursal))
            fr.Width = 950
            If Not String.IsNullOrWhiteSpace(key.TituloConsultaGenerica) Then
               fr.Text = key.TituloConsultaGenerica
            Else
               fr.Text = key.MensajeDeAlerta
            End If
            fr.MdiParent = Me.MdiParent
            fr.Show()

         Case Entidades.Alerta.Tipos.ControlInconsistenciasCtaCteProveedoresVsCtaCtePagos
            Dim fr As ConsultaGenerica = New ConsultaGenerica(New Reglas.CuentasCorrientesProvPagos().GetControlInconsistenciasCtaCteVsCtaCtePagos(actual.Sucursal.IdSucursal))
            fr.Width = 950
            If Not String.IsNullOrWhiteSpace(key.TituloConsultaGenerica) Then
               fr.Text = key.TituloConsultaGenerica
            Else
               fr.Text = key.MensajeDeAlerta
            End If
            fr.MdiParent = Me.MdiParent
            fr.Show()

            'ALERTAS DE PEDIDOS
         Case Entidades.Alerta.Tipos.ParámetrosDePedidos
            Dim fr As ConsultaGenerica = New ConsultaGenerica(New Reglas.Parametros().GetParametrosDeOrganizarEntregasv2())
            fr.Width = 800
            If Not String.IsNullOrWhiteSpace(key.TituloConsultaGenerica) Then
               fr.Text = key.TituloConsultaGenerica
            Else
               fr.Text = key.MensajeDeAlerta
            End If
            fr.MdiParent = Me.MdiParent
            fr.Show()
         Case Entidades.Alerta.Tipos.PedidosSinFacturar
            Dim fr As ConsultaGenerica = New ConsultaGenerica(New Reglas.Pedidos().GetPedidosSinFacturar(SucursalesAlerta))
            fr.Width = 800
            If Not String.IsNullOrWhiteSpace(key.TituloConsultaGenerica) Then
               fr.Text = key.TituloConsultaGenerica
            Else
               fr.Text = key.MensajeDeAlerta
            End If
            fr.MdiParent = Me.MdiParent
            fr.Show()
         Case Entidades.Alerta.Tipos.VencimientoCertificadoDigital
            Dim fr As ParametrosDelUsuario = New ParametrosDelUsuario()
            fr.Show()
            fr.tbcParametros.SelectedTab = fr.tbpFactElectronica
            'ALERTA DE NOVEDADES VENCIDAS
         Case Entidades.Alerta.Tipos.NovedadesFechasVencidas
            Dim fr As InformeDeNovedades = New InformeDeNovedades()
            DirectCast(fr, IConParametros).SetParametros(key.Tag.ToString())
            fr.FechaDesde = Today.AddYears(-2)
            fr.FechaHasta = Today.AddSeconds(-1)
            fr.TipoFechaFiltro = Entidades.CRMNovedad.TipoFechaFiltro.FechaProximoContacto
            fr.MdiParent = Me.MdiParent
            fr.VieneDeAlerta = True
            fr.Show()

            'ALERTA DE NOVEDADES POR VENCER
         Case Entidades.Alerta.Tipos.NovedadesFechasPorVencer
            Dim fr As InformeDeNovedades = New InformeDeNovedades()
            DirectCast(fr, IConParametros).SetParametros(key.Tag.ToString())
            fr.FechaDesde = Today
            fr.FechaHasta = Today.AddDays(Reglas.Publicos.CRMNovedadesDiasAVencerAlarma).AddDays(1).AddSeconds(-1)
            fr.TipoFechaFiltro = Entidades.CRMNovedad.TipoFechaFiltro.FechaProximoContacto
            fr.VieneDeAlerta = True
            fr.MdiParent = Me.MdiParent
            fr.Show()

         Case Entidades.Alerta.Tipos.TurnosNoEfectivos
            Dim fr As InfTurnosCalendarios = NewInfTurnosCalendarios(idCalendario:=0, consultarAutomaticamente:=True)
            fr.MdiParent = Me.MdiParent
            fr.Show()
         Case Entidades.Alerta.Tipos.TurnosDelDia
            Dim fr As InfTurnosCalendarios = NewInfTurnosCalendarios(idCalendario:=Integer.Parse(key.Tag.ToString()), consultarAutomaticamente:=True)
            fr.MdiParent = Me.MdiParent
            fr.Show()

         Case Entidades.Alerta.Tipos.ProspectoSinCRM
            Dim fr As ConsultaGenerica = New ConsultaGenerica(New Reglas.Clientes().GetProspectoSinCRM())
            fr.Width = 950
            fr.Text = key.TituloConsultaGenerica
            fr.MdiParent = Me.MdiParent
            fr.Show()
         Case Entidades.Alerta.Tipos.ChequesPropiosADebitar
            Dim fr As InformeChequesPropios = New InformeChequesPropios()
            fr.ConsultarAutomaticamente = True
            fr.ConsultarAutomaticamente_Estado = Entidades.Cheque.Estados.PROVEEDOR.ToString()
            If TypeOf (key.Tag) Is IEnumerable(Of DateTime) Then
               Dim fechas As IEnumerable(Of DateTime) = DirectCast(key.Tag, IEnumerable(Of DateTime))
               If fechas.Count > 0 Then
                  fr.ConsultarAutomaticamente_FechaDesde = fechas(0)
               End If
               If fechas.Count > 1 Then
                  fr.ConsultarAutomaticamente_FechaHasta = fechas(1)
               End If
            End If
            fr.MdiParent = Me.MdiParent
            fr.Show()
            'PE-30972
         Case Entidades.Alerta.Tipos.AlertaClientesCategoriaModificarVencidas
            Dim fr As ConsultaGenerica = New ConsultaGenerica(New Reglas.Clientes().GetClientesCambioCategoriaVencidas)
            fr.Width = 650
            fr.Text = key.MensajeDeAlerta
            fr.MdiParent = Me.MdiParent
            fr.Show()
            '-.PE-32652.-

         Case Entidades.Alerta.Tipos.AlertaPedidosConCantidadItems
            Dim fr = New ConsultaGenerica(New Reglas.Pedidos().GetPedidosPendientesConCantItems("Pendiente", True, SucursalesAlerta))
            fr.Width = 1100
            fr.Text = key.MensajeDeAlerta
            fr.MdiParent = Me.MdiParent
            fr.Show()

         Case Entidades.Alerta.Tipos.AlertaPedidosSinCantidadItems
            Dim fr = New ConsultaGenerica(New Reglas.Pedidos().GetPedidosPendientesSinCantItems("Pendiente", False, SucursalesAlerta))
            fr.Width = 1100
            fr.Text = key.MensajeDeAlerta
            fr.MdiParent = Me.MdiParent
            fr.Show()

         Case Entidades.Alerta.Tipos.AlertaClientesConDeuda
            Dim fr = New ConsultaGenerica(DirectCast(key.Tag, DataTable), {"NombreCliente", "Telefono", "NombreEmbarcacion"}, {"Saldo"})
            fr.Width = 1000
            fr.Text = key.MensajeDeAlerta
            fr.MdiParent = MdiParent
            fr.Show()
         Case Entidades.Alerta.Tipos.UltimaFechaSincroOCBejerman

            Dim fechaSincOrdenCompra = Reglas.Publicos.BejermanMetalsur.FechaUltimaSincronizacionOrdenCompra
            key.MensajeDeAlerta = String.Format("Ultima sincronizacion de Ordenes de Compra: {0}", fechaSincOrdenCompra)
            If fechaSincOrdenCompra.Value.AddHours(1) < Date.Now Then
               key.Color = Drawing.Color.Red
            Else
               key.Color = Drawing.Color.Green
            End If

         Case Entidades.Alerta.Tipos.AlertaCustom
            Dim alerta = key.AlertaSistema

            If alerta.UtilizaConsultaGenerica Then
               Dim fr = New ConsultaGenerica(DirectCast(key.Tag, DataTable))
               fr.Width = 1000
               fr.Text = key.MensajeDeAlerta
               fr.MdiParent = MdiParent
               fr.Show()
            Else
               Dim mdiParent = DirectCast(Me.MdiParent, BasePrincipal)
               mdiParent.CargaPantalla(key.AlertaSistema.IdFuncionClick, String.Join(";", {key.AlertaSistema.ParametrosPantalla,
                                                                                        key.AlertaSistemaCondicion.ParametrosAdicionalesPantalla}.Where(Function(s) Not String.IsNullOrWhiteSpace(s))))
            End If

         Case Entidades.Alerta.Tipos.AlertaProvComprobantesVencidos
            Dim fr = New ConsultaGenerica(DirectCast(key.Tag, DataTable), {"NombreProveedor", "TelefonoProveedor"}, {"Saldo"})
            fr.Width = 1000
            fr.Text = key.MensajeDeAlerta
            fr.MdiParent = MdiParent
            fr.Show()
         Case Else
      End Select
   End Sub

   Protected Overridable Function NewInfTurnosCalendarios(idCalendario As Integer, consultarAutomaticamente As Boolean) As InfTurnosCalendarios
      Return New InfTurnosCalendarios(idCalendario, consultarAutomaticamente)
   End Function

   Protected Overrides Sub OnActivated(ByVal e As System.EventArgs)
      MyBase.OnActivated(e)
      Me.SendToBack()
   End Sub

   Private Sub UltraGrid1_InitializeRow(sender As Object, e As InitializeRowEventArgs) Handles ugAlertas.InitializeRow
      Try
         Dim alerta As Entidades.Alerta = GetAlerta(e.Row)
         If alerta IsNot Nothing Then

            If e.Row.Cells.Exists("Prioridad") Then
               If alerta.Color.HasValue Then
                  e.Row.Cells("Prioridad").Appearance.BackColor = alerta.Color.Value
                  e.Row.Cells("Prioridad").ActiveAppearance.BackColor = alerta.Color.Value
                  e.Row.Cells("Prioridad").ButtonAppearance.BackColor = alerta.Color.Value
               Else
                  e.Row.Cells("Prioridad").Appearance.BackColor = SystemColors.ControlDark
                  e.Row.Cells("Prioridad").ActiveAppearance.BackColor = SystemColors.ControlDark
                  e.Row.Cells("Prioridad").ButtonAppearance.BackColor = SystemColors.ControlDark
               End If
            End If
         End If
      Catch ex As Exception
      End Try
   End Sub

   Private Function GetAlerta() As Entidades.Alerta
      Return GetAlerta(ugAlertas.ActiveRow)
   End Function

   Private Function GetAlerta(uRow As UltraGridRow) As Entidades.Alerta
      If uRow IsNot Nothing AndAlso
         uRow.ListObject IsNot Nothing AndAlso
         TypeOf (uRow.ListObject) Is Entidades.Alerta Then
         Return DirectCast(uRow.ListObject, Entidades.Alerta)
      End If

      Return Nothing
   End Function

   Private Sub ugAlertas_DoubleClickRow(sender As Object, e As DoubleClickRowEventArgs) Handles ugAlertas.DoubleClickRow
      If OpenWithDobleClick Then
         Try
            Dim alerta As Entidades.Alerta = GetAlerta(e.Row)
            If alerta IsNot Nothing Then
               Me.CargarPantallas(alerta)
            End If
         Catch ex As Exception
            MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
         End Try
      End If
   End Sub

   Private Sub ugAlertas_ClickCell(sender As Object, e As ClickCellEventArgs) Handles ugAlertas.ClickCell
      If Not OpenWithDobleClick Then
         Try
            Dim alerta As Entidades.Alerta = GetAlerta(e.Cell.Row)
            If alerta IsNot Nothing Then
               Me.CargarPantallas(alerta)
            End If
         Catch ex As Exception
            MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
         End Try
      End If
   End Sub

   Private Sub ugAlertas_ClickCellButton(sender As Object, e As CellEventArgs) Handles ugAlertas.ClickCellButton
      Try
         Dim alerta As Entidades.Alerta = GetAlerta(e.Cell.Row)
         If alerta IsNot Nothing Then
            Me.CargarPantallas(alerta)
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub UltraDesktopAlert1_DesktopAlertLinkClicked(sender As Object, e As DesktopAlertLinkClickedEventArgs) Handles UltraDesktopAlert1.DesktopAlertLinkClicked
      Try
         Dim alerta As Entidades.Alerta = DirectCast(e.WindowInfo.Data, Entidades.Alerta)
         If alerta IsNot Nothing Then
            Me.CargarPantallas(alerta)
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub timer_Tick(sender As Object, e As EventArgs) Handles _timer.Tick
      Try
         Recargar()
      Catch ex As Exception
         'si da error aca no hace nada, para que no le muestre ningun mensaje raro al usuario
      End Try
   End Sub

   Private Sub ugAlertas_Click(sender As Object, e As EventArgs) Handles ugAlertas.Click
      BringToFront()
   End Sub

   Private Sub btnAplicar_Click(sender As Object, e As EventArgs) Handles btnAplicar.Click
      TryCatched(
         Sub()
            If txtDolarAAplicar.ValorNumericoPorDefecto(0D) < 1 Then
               Throw New Exception("La cotización del dolar no puede ser inferior a uno (1)")
            End If

            'previo a actualizar el precio del dolar del sistema controlo que vario el nuevo
            Dim precioViejo = txtDolarSistema.ValorNumericoPorDefecto(0D)

            'realizar el metodo de grabación del precio del dolar
            Dim oMonedas = New Reglas.Monedas()
            oMonedas.ActualizarCotizacion(Entidades.Moneda.Dolar, txtDolarAAplicar.ValorNumericoPorDefecto(0D))
            ShowMessage("¡El valor del dolar se actualizo correctamente!")
            txtDolarSistema.Text = txtDolarAAplicar.Text

            If Reglas.Publicos.ActualizaPrecioCostoPorTipoCambio Then
               If ShowPregunta("¿Desea actualizar el precio de costo de los productos con formula?") = Windows.Forms.DialogResult.Yes Then
                  Using prec = New ActualizarPreciosV2(ActualizarPreciosV2.Compuesto.SI, True)
                     prec.ShowDialog()
                  End Using
               End If
            End If
         End Sub)
   End Sub

   Private Sub btnRefrescar_Click(sender As Object, e As EventArgs) Handles btnRefrescar.Click
      Try
         Recargar()
      Catch ex As Exception
         'si da error aca no hace nada, para que no le muestre ningun mensaje raro al usuario
      End Try
   End Sub

   Private Sub ugAlertas_SizeChanged(sender As Object, e As EventArgs) Handles ugAlertas.SizeChanged
      TryCatched(Sub() btnRefrescar.Top = ugAlertas.Top + ugAlertas.Height - btnRefrescar.Height - 5)
   End Sub
End Class