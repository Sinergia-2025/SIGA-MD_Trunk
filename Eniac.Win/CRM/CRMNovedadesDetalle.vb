Imports Eniac.Win.SincronizacionSubidaV2

Public Class CRMNovedadesDetalle

#Region "Campos"

   Private _publicos As Publicos
   Private _tit As Dictionary(Of String, String) = New Dictionary(Of String, String)()
   Private Property TipoNovedad As Entidades.CRMTipoNovedad
   Private Property _cuentaCaracteres As String
   Private _OnLoad As Boolean = False
   Private _modificaDescrip As Boolean
   Private _panelesActivos As List(Of String)
   Private _novedadCopia As Entidades.CRMNovedad
   Private _copiarComentarios As Boolean
   Private _comprobante As Entidades.Venta
   Private _EstadoOriginal As Integer
   Private _cargandoVersiones As Boolean = False

   Private _IdProductoService As String = ""
   Public Property _sucStock As Integer
   Public Property _depStock As Integer
   Public Property _ubiStock As Integer
   Private _cargaComboDestino As Boolean = False

   Private _OrdenProductoService As Integer = 0
   Private _RegProductos As Entidades.CRMNovedadProducto

   Private _decimalesMostrarPrecios As Integer = Reglas.Publicos.Facturacion.Redondeo.FacturacionDecimalesEnPrecio
   Private _decimalesMostrarCantidad As Integer = Reglas.Publicos.Facturacion.Redondeo.FacturacionDecimalesMostrarEnCantidad
   Private _productoLoteTemporal As Entidades.CRMNovedadProductoLote
   Private _productoserieTemporal As Entidades.CRMNovedadProductoNrosSerie
   Private _productosLotes As List(Of Entidades.CRMNovedadProductoLote)

   '# Lotes Seleccionados
   Private _lotesSeleccionados As DataTable
   Private _nrosSerieSeleccionados As List(Of Entidades.ProductoNroSerie)
   Public Property depOrigen As Integer
   Public Property ubiOrigen As Integer
#End Region

#Region "Constructores"

   Public Sub New()
      ' This call is required by the designer.
      InitializeComponent()
      ' Add any initialization after the InitializeComponent() call.
      _cuentaCaracteres = lblCuentaCaracteres.Text
   End Sub
   Public Sub New(novedad As Entidades.CRMNovedad, TipoNovedad As Entidades.CRMTipoNovedad)
      Me.New()
      _entidad = novedad
      Me.TipoNovedad = TipoNovedad
   End Sub

   Public Sub New(novedad As Entidades.CRMNovedad, TipoNovedad As Entidades.CRMTipoNovedad, novedadCopia As Entidades.CRMNovedad, copiarComentarios As Boolean)
      Me.New(novedad, TipoNovedad)
      _novedadCopia = novedadCopia
      _copiarComentarios = copiarComentarios
   End Sub

#End Region

#Region "Propiedades"

   Public Property IdProducto() As String
      Get
         If Me.bscCodigoProductoServ.Selecciono Or Me.bscNombreProductoServ.Selecciono Then
            Return Me.bscCodigoProductoServ.Text.Trim()
         Else
            Return String.Empty
         End If
      End Get
      Set(value As String)
         Try
            If value <> String.Empty Then
               Me.bscCodigoProductoServ.Text = value
               Me.bscCodigoProductoServ.PresionarBoton()
            Else
               Me.bscCodigoProductoServ.Text = String.Empty
               Me.bscNombreProductoServ.Text = String.Empty
            End If
         Catch ex As Exception
            Me.bscCodigoProductoServ.Text = String.Empty
            Me.bscNombreProductoServ.Text = String.Empty
            MessageBox.Show(String.Format("No se pudo recuperar el Producto: {0}", ex.Message), FindForm().Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
         End Try
      End Set
   End Property

   Protected ReadOnly Property Novedad() As Entidades.CRMNovedad
      Get
         Return DirectCast(_entidad, Entidades.CRMNovedad)
      End Get
   End Property

#End Region

#Region "Overrides"

   Protected Overrides Sub OnShown(e As EventArgs)
      MyBase.OnShown(e)

      Try
         tbcMasInfo.SelectedTab = tbpExtrasSinergia
         tbcMasInfo.SelectedTab = tbpMasInfo
         If _novedadCopia IsNot Nothing Then
            cmbTiposNovedadesPadre.SelectedValue = _novedadCopia.IdTipoNovedad
            txtLetraPadre.Text = _novedadCopia.Letra
            txtCentroEmisorPadre.Text = _novedadCopia.CentroEmisor.ToString()
            bscNumeroPadre.Text = _novedadCopia.IdNovedad.ToString()
            bscNumeroPadre.Enabled = True
            bscNumeroPadre.PresionarBoton()

         End If
         tbcMasInfo.SelectedTab = tbpComentariosCarga

         'Solapa por Defecto
         'If CBool(GetTipoNovedad().SolapaPorDefecto) Then
         If GetTipoNovedad().SolapaPorDefecto = Entidades.CRMTipoNovedad.SolapaPorDef.Comentarios Then
            tbcMasInfo.SelectedTab = tbpComentariosCarga
         End If
         If GetTipoNovedad().SolapaPorDefecto = Entidades.CRMTipoNovedad.SolapaPorDef.MasInfo Then
            tbcMasInfo.SelectedTab = tbpMasInfo
         End If
         If GetTipoNovedad().SolapaPorDefecto = Entidades.CRMTipoNovedad.SolapaPorDef.Sinergia Then
            tbcMasInfo.SelectedTab = tbpExtrasSinergia
         End If
         'End If
         '-- REQ-35999.- ----------------------------------------------------------------------
         If TipoNovedad.IdTipoNovedad = "SERVICE" Or TipoNovedad.IdTipoNovedad = "VEHICULO" Then
            Me.tbcDetalle.SelectedTab = Me.tbpService

            If Not String.IsNullOrWhiteSpace(Novedad.FechaHoraEnvioGarantia.ToString()) Then
               dtpEnvioProveedor.Value = CDate(Novedad.FechaHoraEnvioGarantia)
               dtpEnvioProveedor.Checked = True
               dtpEnvioProveedor.Enabled = True
            End If
            If Not String.IsNullOrWhiteSpace(Novedad.FechaHoraRetiroGarantia.ToString()) Then
               dtpRetiroProveedor.Value = CDate(Novedad.FechaHoraRetiroGarantia)
               dtpRetiroProveedor.Checked = True
               dtpRetiroProveedor.Enabled = True
            End If

            ' tbcMasInfo.SelectedTab = tbpProductos
         End If
         '-------------------------------------------------------------------------------------
         If StateForm = Win.StateForm.Insertar Then
            txtDescripcion.Focus()
         End If
      Catch ex As Exception
         ShowError(ex)
      End Try

   End Sub

   Protected Overrides Sub OnLoad(e As EventArgs)
      Dim sw As New Stopwatch()
      sw.Start()


      If _entidad Is Nothing Then
         _entidad = New Eniac.Entidades.CRMNovedad()
      End If

      MyBase.OnLoad(e)


      Try
         _tit = GetColumnasVisiblesGrilla(ugSeguimiento)
         _OnLoad = True
         _publicos = New Publicos()

         Dim enabledActual As Boolean = Novedad.FechaProximoContacto.HasValue

         _panelesActivos = New List(Of String)()

         'remuevo el tab de Otras Novedades y luego según el tipo de novedad lo agrego o no
         tbcDetalle.TabPages.Remove(Me.tbpOtrasNovedades)

         'remuevo el tab de Mas Info si no tiene el seteo correcto
         If Not Reglas.Publicos.CRMMuestraSolapaMasInfo Then
            tbcMasInfo.TabPages.Remove(Me.tbpMasInfo)
         End If

         '# Visualización de la solapa "Sinergia"
         If Not Reglas.Publicos.ExtrasSinergia Then
            tbcMasInfo.TabPages.Remove(Me.tbpExtrasSinergia)
         End If

         'remuevo el tab de Service y luego según el tipo de novedad lo agrego o no
         tbcDetalle.TabPages.Remove(tbpService)
         tbcDetalle.TabPages.Remove(tbpRetiroEntrega)
         tbcDetalle.TabPages.Remove(tbpProductos)

         If Reglas.Publicos.CRMSoloMuestraUsuariosActivos Then
            _publicos.CargaComboUsuariosActivos(cmbIdUsuarioAsignado, Novedad.IdUsuarioAsignado)
         Else
            _publicos.CargaComboUsuarios(cmbIdUsuarioAsignado)
         End If

         _publicos.CargaComboCRMTiposNovedades(cmbTiposNovedadesPadre, "")
         Dim aplicaSeguridad As Boolean = True
         _publicos.CargaComboCRMTiposNovedades(cmbTipoNovedadCopiaTablero, aplicaSeguridad, "")
         cmbTipoNovedadCopiaTablero.SelectedIndex = 0

         _publicos.CargaComboDesdeEnum(cmbComentarioPrincipal, Entidades.CRMNovedad.ComentarioPrincipalOptiones.Ultimo)

         btnEnviarMail.Visible = Reglas.Publicos.CRMPermiteEnvioMailsDesdeNovedad


         _liSources.Add("TipoNovedad", Novedad.TipoNovedad)
         _liSources.Add("PrioridadNovedad", Novedad.PrioridadNovedad)
         _liSources.Add("CategoriaNovedad", Novedad.CategoriaNovedad)
         _liSources.Add("MedioComunicacionNovedad", Novedad.MedioComunicacionNovedad)
         _liSources.Add("EstadoNovedad", Novedad.EstadoNovedad)
         _liSources.Add("UsuarioAsignado", Novedad.UsuarioAsignado)

         If TipoNovedad Is Nothing Then
            _publicos.CargaComboCRMTiposNovedades(cmbTipoNovedad)
         Else
            _publicos.CargaComboCRMTiposNovedades(cmbTipoNovedad, TipoNovedad.IdTipoNovedad)
         End If

         chbNumeroAutomatico.Checked = True
         txtIdNovedad.ReadOnly = True
         If StateForm = Win.StateForm.Insertar Then
            cmbTipoNovedad.SelectedIndex = 0
            If GetTipoNovedad().PermiteIngresarNumero Then
               chbNumeroAutomatico.Visible = True
               lblNumeroAutomatico.Visible = True
            End If
            If GetTipoNovedad().ProximoContactoRequerido Then
               enabledActual = True
            End If

            dtpCantidad.Value = Today

            btnCopiaTablero.Enabled = False

            tstBarra.Enabled = False
            Novedad.RequiereTesteo = Reglas.Publicos.ExtrasSinergia

            If TipoNovedad IsNot Nothing AndAlso TipoNovedad.IdTipoNovedad = "TICKETS" Then
               Novedad.Descripcion = "."
               Novedad.IdFuncion = "SIGA"
            End If

            txtCantidadProducto.Text = 1.ToString(txtCantidadProducto.Formato)
            ' btnAplicar.Enabled = False
         Else

            _EstadoOriginal = Novedad.EstadoNovedad.IdEstadoNovedad

            chbVerCambios.Checked = Novedad.TipoNovedad.VerCambios

            dtpCantidad.Value = FromHoraDecimal(Novedad.Cantidad)

            cmbTipoNovedad.Enabled = False
            txtLetra.Text = Novedad.Letra
            txtCentroEmisor.Text = Novedad.CentroEmisor.ToString()
            txtIdNovedad.Text = Novedad.IdNovedad.ToString()
            cmbTipoNovedad.SelectedValue = Novedad.IdTipoNovedad
            cmbInterlocutor.SelectedItem = Novedad.Interlocutor
            If Novedad.BanderaColor.HasValue Then
               btnBanderaColor.BackColor = Novedad.BanderaColor.Value
            Else
               btnBanderaColor.BackColor = SystemColors.Control
            End If

            lblIdNovedad.Text = lblIdNovedad.Text.Replace("(posible)", "")

            'SERVICE
            If TipoNovedad.IdTipoNovedad = "SERVICE" Or TipoNovedad.IdTipoNovedad = "VEHICULO" Then
               Me.tbcDetalle.SelectedTab = Me.tbpService

               If Novedad.IdProductoPrestado IsNot Nothing Then
                  Me.bscCodigoProductoPrestado2.Text = Novedad.IdProductoPrestado
                  Me.bscCodigoProductoPrestado2.PresionarBoton()
               End If
               If Novedad.IdProveedorService <> 0 Then
                  Me.bscCodigoProveedor.Text = New Reglas.Proveedores()._GetUno(Novedad.IdProveedorService, False).CodigoProveedor.ToString()
                  Me.bscCodigoProveedor.PresionarBoton()
               End If

               txtCantidadProducto.Text = Novedad.CantidadProducto.ToString()
               txtCantidadProductoPrestado.Text = Novedad.CantidadProductoPrestado.ToString()
               txtNroSerieProductoPrestado.Text = Novedad.NroSerieProductoPrestado
               chbDevuelto.Checked = Novedad.ProductoPrestadoDevuelto
               txtCostoReparacion.Text = Novedad.CostoReparacion.ToString()

               If Novedad.TieneGarantiaService.HasValue Then
                  chbTieneGarantiaService.Checked = Novedad.TieneGarantiaService.Value
               End If
               txtUbicacionService.Text = Novedad.UbicacionService

               bscCodigoProductoServ.Text = _IdProductoService.ToString()
               bscCodigoProductoServ.PresionarBoton()

            End If

            CargaNovedadesRelacionadas()
         End If

         Me.BindearControles(Me._entidad, Me._liSources)

         CargaNuevoTipoComentarioDefault()

         Me.tbcMasInfo.SelectedTab = Me.tbpOtrasNovedades
         Me.tbcMasInfo.SelectedTab = Me.tbpComentariosCarga

         If StateForm = Win.StateForm.Insertar Then
            cmbTipoNovedad.SelectedIndex = 0
         End If

         dtpFechaEstadoNovedad.Checked = False

         'If Novedad.FechaProximoContacto.HasValue Then
         If enabledActual Then
            dtpFechaProximoContacto.Checked = True
         Else
            'dtpFechaProximoContacto.Value = Today.AddDays(1)
            dtpFechaProximoContacto.Checked = False
         End If

         dtpVersionFecha.Checked = Novedad.VersionFecha.HasValue
         dtpInicioPlan.Checked = Novedad.FechaInicioPlan.HasValue
         dtpFinPlan.Checked = Novedad.FechaFinPlan.HasValue
         tbcMasInfo.SelectedTab = tbpMasInfo
         Me.bscNumeroPadre.Text = DirectCast(Me._entidad, Entidades.CRMNovedad).IdNovedadPadre.ToString()
         Me.bscNumeroPadre.Enabled = Me.cmbTiposNovedadesPadre.SelectedIndex <> -1
         If DirectCast(Me._entidad, Entidades.CRMNovedad).IdNovedadPadre <> 0 Then
            Me.bscNumeroPadre.PresionarBoton()
         End If

         MostrarSeguimiento()
         MuestraControlesDinamicos()

         'SERVICE
         If TipoNovedad.IdTipoNovedad = "SERVICE" Or TipoNovedad.IdTipoNovedad = "VEHICULO" Then
            '-- REG-31656.- -------------------------------------------------------
            If TipoNovedad.VisualizaSucursal <> Entidades.CRMTipoNovedad.ColVisualizaSucursalNovedades.NoVisible.ToString() Then
               '-- Carga el combo de sucursales.- --
               _publicos.CargaComboSucursales(cmbSucursalesNovedad)
               If Novedad.IdSucursalNovedad Is Nothing Then
                  cmbSucursalesNovedad.SelectedValue = actual.Sucursal.IdSucursal
               Else
                  cmbSucursalesNovedad.SelectedValue = Novedad.IdSucursalNovedad
               End If
               '-- Muestra el Panel de Sucursales.- --
               pnlSucursalesNovedad.Visible = True
            End If
            ugCambiosEstado.DisplayLayout.Bands(0).Columns("NombreSucursalNovedad").Hidden = Not pnlSucursalesNovedad.Visible
            '----------------------------------------------------------------------
            txtProductoObservacion.Text = String.Empty
            txtProductoObservacion.Visible = False
            '------------------------------------------------------------------------------------------------------------------------------------------
            '-- REQ-31756/31871/31988 - Carga Domicilios de Entrega-Retiro - Proveedor Garantia.- --
            '-- Datos de Anticipos y Saldos.- --
            txtAnticioReparacion.Text = Novedad.AnticipoNovedad.ToString("N2")

            Dim oCtaCte As DataTable = New Reglas.CuentasCorrientes()._GetComprobantesDeNovedadTodos(DirectCast(Me._entidad, Entidades.CRMNovedad))
            For Each dr As DataRow In oCtaCte.Rows
               Dim Empresa As Integer = New Reglas.Sucursales().GetUna(Integer.Parse(dr("IdSucursal").ToString()), False).IdEmpresa
               If Empresa <> actual.Sucursal.IdEmpresa Then
                  tsbFacturar.Enabled = False
                  tsbCobrar.Enabled = False
                  MessageBox.Show("No es posible aplicar pagos o emitir facturas para dicho services, se deben emitir en la sucursal de origen.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning)
                  Exit For
               End If
            Next
            txtSaldoReparacion.Text = CalculaSaldo().ToString("N2")
            '-- Datos de Retiro.- --
            If Not String.IsNullOrWhiteSpace(Novedad.FechaHoraRetiro.ToString()) Then
               chbRetiros.Checked = True
               dtpFechaHoraRetiro.Value = Novedad.FechaHoraRetiro.IfNull()
               cmbDomicilioRetiro.SelectedValue = Novedad.IdDomicilioRetiro.IfNull()
            Else
               chbRetiros.Checked = False
               cmbDomicilioRetiro.SelectedValue = -1
            End If
            '-- Sincroniza Panel de Retiros.- --
            pnlRetiros.Enabled = chbRetiros.Checked
            '-- Datos de Entrega.- --
            If Not String.IsNullOrWhiteSpace(Novedad.FechaHoraEntrega.ToString()) Then
               chbEntregas.Checked = True
               dtpFechaHoraEntrega.Value = Novedad.FechaHoraEntrega.IfNull()
               cmbDomicilioEntrega.SelectedValue = Novedad.IdDomicilioEntrega.IfNull()
            Else
               chbEntregas.Checked = False
            End If
            '-- Sincroniza Panel de Entrega.- --
            pnlEntregas.Enabled = chbEntregas.Checked
            '-- Datos de Garantia.- --
            If Not String.IsNullOrWhiteSpace(Novedad.IdProveedorGarantia.ToString()) Then
               Me.bscCodigoProveedorGarantia.Text = New Reglas.Proveedores()._GetUno(CLng(Novedad.IdProveedorGarantia), False).CodigoProveedor.ToString()
               Me.bscCodigoProveedorGarantia.PresionarBoton()
            End If
            '------------------------------------------------------------------------------------------------------------------------------------------
            '-- Carga Datos de en la Grilla.- --
            Me.tbcMasInfo.SelectedTab = Me.tbpProductos
            ugProductos.DisplayLayout.Bands(0).Columns.Add("Lot")
            ugProductos.DisplayLayout.Bands(0).Columns.Add("NS")
            ugProductos.DisplayLayout.Bands(0).Columns("Lot").Style = UltraWinGrid.ColumnStyle.Button
            ugProductos.DisplayLayout.Bands(0).Columns("Lot").ButtonDisplayStyle = UltraWinGrid.ButtonDisplayStyle.Always
            ugProductos.DisplayLayout.Bands(0).Columns("NS").Style = UltraWinGrid.ColumnStyle.Button
            ugProductos.DisplayLayout.Bands(0).Columns("NS").ButtonDisplayStyle = UltraWinGrid.ButtonDisplayStyle.Always

            MostrarNovedadesProductos(cargando:=True)
            '-- Refresca Datos a Mostrar Grilla.- --
            ugProductos.Rows.Refresh(RefreshRow.ReloadData)

            _sucStock = actual.Sucursal.IdSucursal
            _publicos.CargaComboDepositos(cmbDepositoOrigen, _sucStock, miraUsuario:=True, permiteEscritura:=True, Entidades.Publicos.SiNoTodos.TODOS)

            _productosLotes = New List(Of Entidades.CRMNovedadProductoLote)()

         End If

         'EnableFechasEnvioRetiroProveedor()
         MostrarCambiosEstados()

         Dim tienePermisoParaUsarAdjuntos As Boolean = False
         If TipoNovedad IsNot Nothing Then
            tienePermisoParaUsarAdjuntos = New Eniac.Reglas.Usuarios().TienePermisos(actual.Nombre, actual.Sucursal.Id, TipoNovedad.IdTipoNovedad + "-PuedeAdjuntar")
         End If

         If Not tienePermisoParaUsarAdjuntos Then
            Me.btnExaminar.Enabled = False
            Me.lblNombreAdjunto.Enabled = False
            Me.txtNombreAdjunto.Enabled = False

            Me.btnExaminar.Visible = False
            Me.lblNombreAdjunto.Visible = False
            Me.txtNombreAdjunto.Visible = False
         End If

         Me.dtpFechaNovedad.Focus()

         tbcMasInfo.SelectedTab = tbpComentariosCarga

         '# Preferencais de las grillas
         Me.LeerPreferencias()
      Catch ex As Exception
         ShowError(ex)
      Finally
         lblCuentaCaracteres.Text = String.Format(_cuentaCaracteres, txtComentarios.Text.Length)
         _OnLoad = False
      End Try

      sw.Stop()
      'ShowMessage(String.Format("Tiempo de Carga Detalle: {0}", sw.Elapsed.ToString()))
   End Sub

   Private Sub CargaNovedadesRelacionadas()
      Dim regla As Reglas.CRMNovedades = New Reglas.CRMNovedades()
      Dim dt As DataTable = regla.GetNovedadesRelacionadas(Novedad)

      ugNovedadesRelacionadas.DataSource = dt
      FormatearGrillaRelacionadas()

   End Sub

   Protected Overrides Function ProcessCmdKey(ByRef msg As Message, keyData As Keys) As Boolean
      Try
         If keyData = Keys.F4 Then
            btnAceptar.PerformClick()
            Return True
         End If
         If keyData = Keys.F12 Then
            btnCopiar.PerformClick()
            Return True
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
      Return MyBase.ProcessCmdKey(msg, keyData)
   End Function

   Protected Overrides Function GetReglas() As Reglas.Base
      Return New Reglas.CRMNovedades()
   End Function

   Protected Overrides Sub LimpiaPantallaParaCopia(enActual As Entidades.Entidad)
      Dim novedadActual As Entidades.CRMNovedad = DirectCast(enActual, Entidades.CRMNovedad)
      StateForm = StateForm.Insertar
      novedadActual.IdNovedad = 0
      novedadActual.NuevoComentario = String.Empty
      novedadActual.IdFuncion = String.Empty
      novedadActual.IdSistema = String.Empty
      novedadActual.Descripcion = String.Empty
      novedadActual.BanderaColor = Nothing

      'txtIdNovedad.Text = novedadActual.IdNovedad.ToString()
      txtLetra.Text = TipoNovedad.LetrasHabilitadas
      txtCentroEmisor.Text = Novedad.CentroEmisor.ToString()
      Me.txtIdNovedad.Text = (DirectCast(GetReglas(), Reglas.CRMNovedades).GetCodigoMaximo(TipoNovedad.IdTipoNovedad, TipoNovedad.LetrasHabilitadas, Novedad.CentroEmisor) + 1).ToString()
      Me.txtComentarios.Text = novedadActual.NuevoComentario
      Me.txtDescripcion.Text = novedadActual.Descripcion
      Me.chbRequiereTesteo.Checked = novedadActual.RequiereTesteo
      Me.btnBanderaColor.BackColor = SystemColors.Control

      Me.btnBanderaColor.BackColor = Nothing

      MuestraControlesDinamicos()
      'For Each seg As Entidades.CRMNovedadSeguimiento In Novedad.Seguimientos.ToArray
      '   If Not seg.EsComentario Then
      '      Novedad.Seguimientos.Remove(seg)
      '   End If
      '   seg.IdNovedad = 0
      '   seg.IdSeguimiento = 0
      'Next
      Novedad.Seguimientos.Clear()
      '-- REQ-31804.- --
      If chbHistoriaCambioEstado.Checked Then
         Novedad.CambiosEstados.Clear()
      Else
         Novedad.CambiosEstadosAgrupado.Clear()
      End If

      MostrarSeguimiento()
      InicializaCombos()
      MostrarCambiosEstados()
   End Sub

   Protected Overrides Function ValidarDetalle() As String

      Dim avance = txtAvance.ValorNumericoPorDefecto(0D) ' If(IsNumeric(txtAvance.Text), Decimal.Parse(txtAvance.Text), 0)
      Dim cantidad = txtCantidad.ValorNumericoPorDefecto(0D) ' If(IsNumeric(txtCantidad.Text), Decimal.Parse(txtCantidad.Text), 0)

      Dim blnFinalizado = DirectCast(cmbEstadoNovedad.SelectedItem, Entidades.CRMEstadoNovedad).Finalizado

      If GetTipoNovedad().ReportaAvance Then

         If avance > 100 Then
            txtAvance.Focus()
            Return "El Avance No puede ser mayor a 100 %"
         ElseIf avance < 0 Then
            txtAvance.Focus()
            Return "El Avance No puede ser menor a 0 %"
         ElseIf avance <> 100 And blnFinalizado Then
            txtAvance.Focus()
            Return "Selecciono un Estado Finalizado, el Avance debe ser 100 %"
         ElseIf avance = 100 And Not blnFinalizado Then
            txtAvance.Focus()
            Return "Selecciono un Estado NO Finalizado, el Avance No debe ser 100 %"
         End If

      End If
      If GetTipoNovedad().ReportaCantidad Then

         If cantidad < 0 Then
            txtCantidad.Focus()
            Return String.Format("{0} No puede ser menor a 0", GetTipoNovedad().UnidadDeMedida)

         ElseIf cantidad = 0 And blnFinalizado Then
            txtCantidad.Focus()
            Return String.Format("Selecciono un Estado Finalizado, {0} debe ser Mayor a 0 ", GetTipoNovedad().UnidadDeMedida)
         End If

      End If

      If Not String.IsNullOrWhiteSpace(txtNombreAdjunto.Text) Then
         If Not IO.File.Exists(txtNombreAdjunto.Text) Then
            txtNombreAdjunto.Focus()
            Return String.Format("El archivo '{0}' no existe.", txtNombreAdjunto.Text)
         End If
         If String.IsNullOrWhiteSpace(txtComentarios.Text) Then
            txtComentarios.Focus()
            Return "Para adjuntar un archivo, debe ingresar al menos un comentario."
         End If
      End If

      If Me.TipoNovedad IsNot Nothing And TipoNovedad.UsuarioRequerido Then
         If cmbIdUsuarioAsignado.SelectedValue Is Nothing Then
            cmbIdUsuarioAsignado.Focus()
            Return "El Usuario Asignado es Requerido."
         End If
      End If

      'Solo si el estado es abierto.
      If Not blnFinalizado And Me.TipoNovedad IsNot Nothing And TipoNovedad.ProximoContactoRequerido Then
         If Not Me.dtpFechaProximoContacto.Checked Then
            Me.dtpFechaProximoContacto.Focus()
            Return "El Próximo Contacto es Requerido."
         End If
      End If

      If Me.bscNumeroPadre.Text <> "0" Then
         If Not Me.bscNumeroPadre.Selecciono Then
            Me.bscNumeroPadre.Focus()
            Return "No selecciono una Novedad."
         End If
      End If
      If TipoNovedad.IdTipoNovedad = "SERVICE" Then
         If String.IsNullOrWhiteSpace(Novedad.IdProducto) Then
            Return "El Producto es Requerido"
         End If
         If Decimal.Parse(Me.txtCantidadProducto.Text.ToString()) = 0 Then
            Me.txtCantidadProducto.Focus()
            Return "La cantidad es requerida"
         End If
      End If

      '# Validado SOLO en el Insertar por el momento
      If StateForm = Win.StateForm.Insertar Then
         If Novedad IsNot Nothing Then
            If TipoNovedad IsNot Nothing Then
               If Novedad.IdNovedadPadre = 0 AndAlso TipoNovedad.RequierePadre Then
                  Return "El tipo de novedad seleccionada requiere un Padre."
               End If
            End If
         End If
      End If

      If StateForm = Win.StateForm.Insertar And cmbEstadoNovedad.ItemSeleccionado(Of Entidades.CRMEstadoNovedad).RequiereComentarios Then
         If txtComentarios.Text.Length < 5 And Not Novedad.Seguimientos.Any(Function(s) s.IdSeguimiento = 0 And s.Comentario.Length > 5) Then
            Return String.Format("El estado {0} requiere que se cargue un comentario", cmbEstadoNovedad.Text)
         End If
      Else
         If Novedad.EstadoNovedad.IdEstadoNovedad <> _EstadoOriginal And
            cmbEstadoNovedad.ItemSeleccionado(Of Entidades.CRMEstadoNovedad).RequiereComentarios Then
            If txtComentarios.Text.Length < 5 And Not Novedad.Seguimientos.Any(Function(s) s.IdSeguimiento = 0 And s.Comentario.Length > 5) Then
               Return String.Format("El estado {0} requiere que se cargue un comentario", cmbEstadoNovedad.Text)
            End If
         End If
      End If


      Return MyBase.ValidarDetalle()

   End Function

#End Region

#Region "Metodos"

   Private Sub LeerPreferencias()

      Dim solapaSeleccionada As TabPage = tbcDetalle.SelectedTab
      If solapaSeleccionada Is tbpComentarios Then
         PreferenciasLeer(grid:=ugSeguimiento, sufijoXML:=ugSeguimiento.Name.ToString(), tsbPreferencias:=Nothing)
      ElseIf solapaSeleccionada Is tbpOtrasNovedades Then
         PreferenciasLeer(grid:=ugDetalle, sufijoXML:=ugDetalle.Name.ToString(), tsbPreferencias:=Nothing)
      Else
         PreferenciasLeer(grid:=ugNovedadesRelacionadas, sufijoXML:=ugNovedadesRelacionadas.Name.ToString(), tsbPreferencias:=Nothing)
      End If

   End Sub

   Protected Overrides Sub Aceptar()

      GuardaControlesDinamicos()

      If Me._panelesActivos.Contains("PROYECTOS") Then
         If Novedad.IdProyecto = 0 Then
            Throw New Exception("Debe seleccionar un proyecto")
         Else
            Dim dt As DataTable
            Dim op As Reglas.Proyectos = New Reglas.Proyectos()
            dt = op.GetFiltradoPorCodigo(Novedad.IdProyecto, Novedad.IdCliente)
            If dt.Rows.Count = 0 Then
               Throw New Exception("El proyecto no pertenece al cliente.")
            End If
         End If

         'If StateForm = Win.StateForm.Insertar Then
         '-- REG-30998 --
         Dim proy = New Reglas.Proyectos().GetUno(Novedad.IdProyecto)
         If proy.Finalizado Then
            If ShowPregunta("El proyecto seleccionado no puede estar finalizado. ¿Desea continuar?", MessageBoxDefaultButton.Button2) = DialogResult.No Then
               Exit Sub
            End If
         End If
         'End If

      End If

      If _panelesActivos.Contains(Entidades.CRMTipoNovedad.TipoDinamico.VEHICULO.ToString()) Then
         If String.IsNullOrWhiteSpace(Novedad.PatenteVehiculo) Then
            Throw New Exception("Debe seleccionar una Patente de Vehículo")
         Else
            Dim rVh = New Reglas.Vehiculos()
            Dim vh = rVh.GetUno(Novedad.PatenteVehiculo, Reglas.Base.AccionesSiNoExisteRegistro.Nulo)
            If vh Is Nothing Then
               Throw New Exception("El vehículo no existe")
            End If
            If Not vh.Clientes.AnySecure(Function(cvh) cvh.IdCliente = Novedad.IdCliente) Then
               Throw New Exception("El vehículo no pertenece al cliente.")
            End If
         End If
      End If

      If Novedad.TipoNovedad.IdTipoNovedad = "PENDIENTE" AndAlso Not String.IsNullOrWhiteSpace(Novedad.Version) AndAlso Novedad.EstadoNovedad.IdEstadoNovedad <> _EstadoOriginal Then
         Dim estadoAnterior = Reglas.Cache.CRMCacheHandler.Instancia.Estados.Buscar(_EstadoOriginal)
         If estadoAnterior IsNot Nothing Then
            If ShowPregunta(String.Format("¿Está seguro de querer cambiar el estado de {0} a {1}?",
                                          estadoAnterior.NombreEstadoNovedad, cmbEstadoNovedad.Text)) = DialogResult.Yes Then
               Dim rB = New Reglas.Bitacora()
               rB.InsertarError(IdFuncion, String.Format("Intento de cambiar el estado del {0} {1} {2:0000}-{3:00000000} de {4} a {5} pero el mismo ya fue publicado en la versión {6}",
                                                         Novedad.TipoNovedad.NombreTipoNovedad, Novedad.Letra, Novedad.CentroEmisor, Novedad.IdNovedad,
                                                         estadoAnterior.NombreEstadoNovedad, cmbEstadoNovedad.Text, Novedad.Version))
               ShowMessage(String.Format("El {1} ya fue publicado en la versión {2}. No es posible cambiarle el estado.{0}{0}¡¡REVISE EL PROCEDIMIENTO!!",
                                         Environment.NewLine, Novedad.TipoNovedad.NombreTipoNovedad, Novedad.Version))
            End If
            Exit Sub
         End If
      End If


      If Not String.IsNullOrEmpty(Novedad.IdProductoNovedad) Then
         Dim PC As Entidades.ProductosClientes = New Entidades.ProductosClientes
         Dim oPC As Reglas.ProductosClientes = New Reglas.ProductosClientes()
         PC = oPC.GetUno(Novedad.IdProductoNovedad, Novedad.IdCliente, Reglas.Base.AccionesSiNoExisteRegistro.Vacio)
         If PC Is Nothing Then
            Throw New Exception("El producto no pertenece al cliente.")
         End If
      End If

#Region "Codigo-Marcado"
      ''controlo que si el cliente que se cargo tiene un proyecto abierto, le advierta a la persona para ver como carga las horas
      'If Me._panelesActivos.Contains("PROYECTOS") Then
      '   If Novedad.IdProyecto = 0 Then
      '      Dim dt As DataTable
      '      If Novedad.IdCliente <> 0 Then
      '         Dim op As Reglas.Proyectos = New Reglas.Proyectos()
      '         dt = op.GetFiltradoPorCodigo(Nothing, Novedad.IdCliente)
      '         If dt.Rows.Count > 0 AndAlso Me.StateForm = Win.StateForm.Insertar Then
      '            If MessageBox.Show("El cliente seleccionado tiene proyectos en ejecución, ¿quiere seleccionar el proyecto antes de grabar?", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
      '               If dt.Rows.Count = 1 Then
      '                  Novedad.IdProyecto = Int32.Parse(dt.Rows(0)("IdProyecto").ToString())
      '                  Me.MuestraControlesDinamicos()
      '               End If
      '               Exit Sub
      '            End If
      '         End If
      '      End If
      '   End If
      'Else
#End Region

      If Novedad.TipoNovedad.IdTipoNovedad = "SERVICE" Or Novedad.TipoNovedad.IdTipoNovedad = "VEHICULO" Then

#Region "REQ-31710/31756/31871/31988 - Carga Domicilios de Entrega-Retiro - Proveedor Garantia.-"
         '-- REQ-31825.- --
         If _modificaDescrip Then
            If String.IsNullOrEmpty(Novedad.NombreMarcaProducto) Then
               Throw New Exception("Debe seleccionar una Marca")
            End If
            If String.IsNullOrEmpty(Novedad.NombreModeloProducto) And Publicos.ProductoTieneModelo Then
               Throw New Exception("Debe seleccionar un Modelo")
            End If
         End If
         '-- REQ-31710.- ---------
         If txtAnticioReparacion.Enabled Then
            Novedad.AnticipoNovedad = CInt(txtAnticioReparacion.Text)
         End If

         '-- REQ-31988.- --
         If chbTieneGarantiaService.Checked And String.IsNullOrEmpty(Me.bscCodigoProveedorGarantia.Text) Then
            Throw New Exception("Debe seleccionar un Proveedor de la Garantia")
         End If
         '-- REQ-31756.- --
         If chbRetiros.Checked And cmbDomicilioRetiro.SelectedIndex = -1 Then
            Throw New Exception("Debe seleccionar un Domicilio de Retiro")
         End If
         '-- REQ-31871.- --
         If chbEntregas.Checked And cmbDomicilioEntrega.SelectedIndex = -1 Then
            Throw New Exception("Debe seleccionar un Domicilio de Entrega")
         End If
         '-- REQ-32878.- --
         If chbEntregas.Checked And dtpFechaHoraEntrega.Value < dtpFechaHoraRetiro.Value Then
            Throw New Exception("Fecha de Entrega debe ser mayor a Fecha de Retiro")
         End If

         '-- Carga los todos los datos recolectados.- --
         '-- Tiene Garantia.- --
         If chbTieneGarantiaService.Checked Then
            Novedad.IdProveedorGarantia = CInt(bscCodigoProveedorGarantia.Tag)
         End If
         '-- Datos de retiro.- --
         If chbRetiros.Checked Then
            Novedad.FechaHoraRetiro = dtpFechaHoraRetiro.Value
            If cmbDomicilioRetiro.SelectedIndex > 0 Then
               Novedad.IdDomicilioRetiro = CInt(cmbDomicilioRetiro.SelectedValue.ToString())
            Else
               Novedad.IdDomicilioRetiro = Nothing
            End If
         Else
            Novedad.FechaHoraRetiro = Nothing
            Novedad.IdDomicilioRetiro = Nothing
         End If
         '-- Datos de entrega.- --
         If chbEntregas.Checked Then
            Novedad.FechaHoraEntrega = dtpFechaHoraEntrega.Value
            If cmbDomicilioEntrega.SelectedIndex > 0 Then
               Novedad.IdDomicilioEntrega = CInt(cmbDomicilioEntrega.SelectedValue.ToString())
            Else
               Novedad.IdDomicilioEntrega = Nothing
            End If
         Else
            Novedad.FechaHoraEntrega = Nothing
            Novedad.IdDomicilioEntrega = Nothing
         End If
         '-- Fecha-Hora Envio Proveedor.- --
         If dtpEnvioProveedor.Checked Then
            Novedad.FechaHoraEnvioGarantia = dtpEnvioProveedor.Value
         Else
            Novedad.FechaHoraEnvioGarantia = Nothing
         End If
         '-- Fecha-Hora Retiro Proveedor.- --
         If dtpRetiroProveedor.Checked Then
            Novedad.FechaHoraRetiroGarantia = dtpRetiroProveedor.Value
         Else
            Novedad.FechaHoraRetiroGarantia = Nothing
         End If

         '-- REQ-31656.- -Sucursal Novedad-
         If TipoNovedad.VisualizaSucursal <> Entidades.CRMTipoNovedad.ColVisualizaSucursalNovedades.NoVisible.ToString() Then
            If cmbSucursalesNovedad.SelectedIndex = -1 Then
               Throw New Exception("Debe seleccionar una Sucursal para la novedad")
            Else
               Novedad.IdSucursalNovedad = Integer.Parse(cmbSucursalesNovedad.SelectedValue.ToString())
            End If
         Else
            Novedad.IdSucursalNovedad = Nothing
         End If

#End Region

         Novedad.IdProductoPrestado = bscCodigoProductoPrestado2.Text
         Novedad.CantidadProducto = Decimal.Parse(txtCantidadProducto.Text.ToString())
         Novedad.CostoReparacion = Decimal.Parse(txtCostoReparacion.Text.ToString())
         Novedad.CantidadProductoPrestado = Decimal.Parse(txtCantidadProductoPrestado.Text.ToString())
         Novedad.NroSerieProductoPrestado = txtNroSerieProductoPrestado.Text
         Novedad.ProductoPrestadoDevuelto = chbDevuelto.Checked
         If Not String.IsNullOrEmpty(bscCodigoProveedor.Text) Then
            Novedad.IdProveedorService = Long.Parse(bscCodigoProveedor.Tag.ToString())
         Else
            Dim estadoCombo As Entidades.CRMEstadoNovedad = DirectCast(cmbEstadoNovedad.SelectedItem, Entidades.CRMEstadoNovedad)
            '-- REQ-31992.- --
            Novedad.IdProveedorService = 0
            If estadoCombo.SolicitaProveedorService Then
               Throw New Exception("Debe seleccionar un Proveedor de servicio. Es requerido!!!")
            End If
         End If

         Novedad.TieneGarantiaService = chbTieneGarantiaService.Checked
         Novedad.UbicacionService = txtUbicacionService.Text
      End If


      If btnBanderaColor.BackColor.Equals(SystemColors.Control) Then
         Novedad.BanderaColor = Nothing
      Else
         Novedad.BanderaColor = btnBanderaColor.BackColor
      End If

      If Not dtpFechaProximoContacto.Checked Then
         Novedad.FechaProximoContacto = Nothing
      End If

      Novedad.FechaEstadoNovedad = dtpFechaEstadoNovedad.Value

      If dtpFechaEstadoNovedad.Checked Then
         Novedad.FechaEstadoNovedad = dtpFechaEstadoNovedad.Value
      Else
         Novedad.FechaEstadoNovedad = Nothing
      End If

      If Me.dtpVersionFecha.Checked Then
         Novedad.VersionFecha = Me.dtpVersionFecha.Value
      Else
         Novedad.VersionFecha = Nothing
      End If

      If Me.dtpInicioPlan.Checked Then
         Novedad.FechaInicioPlan = Me.dtpInicioPlan.Value
      Else
         Novedad.FechaInicioPlan = Nothing
      End If

      If Me.dtpFinPlan.Checked Then
         Novedad.FechaFinPlan = Me.dtpFinPlan.Value
      Else
         Novedad.FechaFinPlan = Nothing
      End If

      Novedad.Cantidad = txtCantidad.ValorNumericoPorDefecto(0D)

      If StateForm = Win.StateForm.Insertar Then
         Novedad.Letra = txtLetra.Text
         If Not chbNumeroAutomatico.Checked And IsNumeric(txtIdNovedad.Text) Then
            Novedad.IdNovedad = Integer.Parse(txtIdNovedad.Text)
         Else
            Novedad.IdNovedad = 0
         End If
      End If

      Novedad.TipoNovedad.NombreTipoNovedad = cmbTipoNovedad.Text
      Novedad.EstadoNovedad = DirectCast(cmbEstadoNovedad.DataSource, List(Of Entidades.CRMEstadoNovedad)).FirstOrDefault(Function(x) x.IdEstadoNovedad = cmbEstadoNovedad.ValorSeleccionado(Of Integer)())
      '-- REQ-31800.- --
      If dtpFechaEstadoNovedad.Checked Then
         Novedad.FechaEstadoNovedad = dtpFechaEstadoNovedad.Value
      End If
      Novedad.MarcaCRMFecha = dtpFechaEstadoNovedad.Checked

      MyBase.Aceptar()

      If Not Me.HayError Then

         If StateForm = StateForm.Insertar Then
            StateForm = StateForm.Actualizar
         End If

         Dim oNovedadImprimir As Reglas.CRMNovedades = New Reglas.CRMNovedades()
         Dim novedadImprimir As Entidades.CRMNovedad = oNovedadImprimir.GetUno(Novedad.TipoNovedad.IdTipoNovedad, Novedad.Letra,
                                                                               Novedad.CentroEmisor, Novedad.IdNovedad)
         Dim oNovImp As CRMNovedadesImpresion = New CRMNovedadesImpresion(novedadImprimir)

         If StateForm = Win.StateForm.Insertar And novedadImprimir.EstadoNovedad.Imprime Then
            oNovImp.ImprimirNovedad()
         Else
            If Novedad.EstadoNovedad.IdEstadoNovedad <> Me._EstadoOriginal And novedadImprimir.EstadoNovedad.Imprime Then
               oNovImp.ImprimirNovedad()
            End If
         End If
      End If
      If Novedad.TipoNovedad.IdTipoNovedad = "SERVICE" Or Novedad.TipoNovedad.IdTipoNovedad = "VEHICULO" Then
         RefrescaAnticipo()
      End If

   End Sub

   Private Sub CambiaTipoNovedad()
      Dim tipoNovedad As Entidades.CRMTipoNovedad = GetTipoNovedad()

      While pnlReferencias.Controls.Count > 0
         Dim ctrl As Control = pnlReferencias.Controls(0)
         pnlReferencias.Controls.Remove(ctrl)
         ctrl.Dispose()
      End While

      If tipoNovedad IsNot Nothing Then

         Text = tipoNovedad.NombreTipoNovedad
         Me.lblCantidad.Text = tipoNovedad.UnidadDeMedida

         InicializaControlesDinamicos(tipoNovedad)

         Dim idTipoNovedad As String = tipoNovedad.IdTipoNovedad
         _publicos.CargaComboCRMPrioridadesNovedades(cmbPrioridadNovedad, idTipoNovedad)
         _publicos.CargaComboCRMEstadosNovedades(cmbEstadoNovedad, idTipoNovedad)
         _publicos.CargaComboCRMCategoriasNovedades(cmbCategoriaNovedad, idTipoNovedad)
         _publicos.CargaComboCRMMediosComunicacionesNovedades(cmbMedio, idTipoNovedad)
         _publicos.CargaComboCRMTiposComentariosNovedades(cmbNuevoIdTipoComentarioNovedad, idTipoNovedad)
         _publicos.CargaComboCRMTiposComentariosNovedades(cmbTipoComentarioNovedadEditor, idTipoNovedad)

         'cmbTipoComentarioNovedadEditor.ValueList.ItemHeight = cmbTipoComentarioNovedadEditor.Height * 2


         If Me.StateForm = Win.StateForm.Insertar Then

            InicializaCombos()

            If tipoNovedad IsNot Nothing AndAlso tipoNovedad.UsuarioPorDefecto = True Then
               Dim usr As String = New Reglas.Usuarios().GetUno(actual.Nombre).Id

               cmbIdUsuarioAsignado.SelectedValue = usr

               txtLetra.Text = tipoNovedad.LetrasHabilitadas
               txtCentroEmisor.Text = Novedad.CentroEmisor.ToString()
               txtIdNovedad.Text = (DirectCast(GetReglas(), Reglas.CRMNovedades).GetCodigoMaximo(tipoNovedad.IdTipoNovedad, tipoNovedad.LetrasHabilitadas, Novedad.CentroEmisor) + 1).ToString()
            End If

         Else
            CargaNuevoTipoComentarioDefault()

         End If

         btnEliminarComentario.Visible = tipoNovedad.PermiteBorrarComentarios

         txtAvance.Enabled = tipoNovedad.ReportaAvance
         txtCantidad.Enabled = tipoNovedad.ReportaCantidad
         dtpCantidad.Enabled = tipoNovedad.ReportaCantidad

      Else
         ClearCombo(cmbPrioridadNovedad)
         ClearCombo(cmbEstadoNovedad)
         ClearCombo(cmbCategoriaNovedad)
         ClearCombo(cmbMedio)
      End If

   End Sub

   Private Sub CargaNuevoTipoComentarioDefault()
      If cmbNuevoIdTipoComentarioNovedad.Items.Count = 1 Then
         cmbNuevoIdTipoComentarioNovedad.SelectedIndex = 0
      Else
         cmbNuevoIdTipoComentarioNovedad.SelectedIndex = -1
         Dim tipoDef As Entidades.CRMTipoComentarioNovedad = DirectCast(cmbNuevoIdTipoComentarioNovedad.DataSource, List(Of Entidades.CRMTipoComentarioNovedad)).FirstOrDefault(Function(x) x.PorDefecto)
         If tipoDef IsNot Nothing Then
            cmbNuevoIdTipoComentarioNovedad.SelectedValue = tipoDef.IdTipoComentarioNovedad
         End If
      End If
   End Sub

   Private Sub ClearCombo(cmb As ComboBox)
      If TypeOf (cmb.DataSource) Is IList Then DirectCast(cmb.DataSource, IList).Clear()
   End Sub

   Private Sub InicializaCombos()
      If cmbEstadoNovedad.Items.Count = 1 Then
         cmbEstadoNovedad.SelectedIndex = 0
      Else
         cmbEstadoNovedad.SelectedIndex = -1
         For Each estado As Entidades.CRMEstadoNovedad In DirectCast(cmbEstadoNovedad.DataSource, List(Of Entidades.CRMEstadoNovedad))
            If estado.PorDefecto Then
               cmbEstadoNovedad.SelectedValue = estado.IdEstadoNovedad
               Exit For
            End If
         Next
      End If
      If cmbPrioridadNovedad.Items.Count = 1 Then
         cmbPrioridadNovedad.SelectedIndex = 0
      Else
         cmbPrioridadNovedad.SelectedIndex = -1
         For Each prioridad As Entidades.CRMPrioridadNovedad In DirectCast(cmbPrioridadNovedad.DataSource, List(Of Entidades.CRMPrioridadNovedad))
            If prioridad.PorDefecto Then
               cmbPrioridadNovedad.SelectedValue = prioridad.IdPrioridadNovedad
               Exit For
            End If
         Next
      End If
      If cmbCategoriaNovedad.Items.Count = 1 Then
         cmbCategoriaNovedad.SelectedIndex = 0
      Else
         cmbCategoriaNovedad.SelectedIndex = -1
         For Each categoria As Entidades.CRMCategoriaNovedad In DirectCast(Me.cmbCategoriaNovedad.DataSource, List(Of Entidades.CRMCategoriaNovedad))
            If categoria.PorDefecto Then
               Me.cmbCategoriaNovedad.SelectedValue = categoria.IdCategoriaNovedad
               Exit For
            End If
         Next
      End If
      If cmbMedio.Items.Count = 1 Then
         cmbMedio.SelectedIndex = 0
      Else
         cmbMedio.SelectedIndex = -1
         For Each medio As Entidades.CRMMedioComunicacionNovedad In DirectCast(cmbMedio.DataSource, List(Of Entidades.CRMMedioComunicacionNovedad))
            If medio.PorDefecto Then
               cmbMedio.SelectedValue = medio.IdMedioComunicacionNovedad
               Exit For
            End If
         Next
      End If

      CargaNuevoTipoComentarioDefault()
   End Sub

   Private Function GetIdTipoNovedad() As String
      If GetTipoNovedad() Is Nothing Then
         Return String.Empty
      Else
         Return GetTipoNovedad().IdTipoNovedad
      End If
   End Function

   Private Function GetTipoNovedad() As Entidades.CRMTipoNovedad
      If cmbTipoNovedad.SelectedIndex >= 0 Then
         Return DirectCast(cmbTipoNovedad.SelectedItem, Entidades.CRMTipoNovedad)
      Else
         Return Nothing
      End If
   End Function

   Private Sub MostrarSeguimiento()
      If chbVerCambios.Checked Then
         ugSeguimiento.DataSource = Novedad.Seguimientos
      Else
         Dim list = New List(Of Entidades.CRMNovedadSeguimiento)()
         For Each seg As Entidades.CRMNovedadSeguimiento In Novedad.Seguimientos
            If seg.EsComentario Then
               list.Add(seg)
            End If
         Next
         ugSeguimiento.DataSource = list
      End If

      AjustarColumnasGrilla(ugSeguimiento, _tit)
      ugSeguimiento.AgregarFiltroEnLinea({Entidades.CRMNovedadSeguimiento.Columnas.Comentario.ToString()})
   End Sub

   Private Sub MostrarCambiosEstados()
      Dim tit = GetColumnasVisiblesGrilla(ugCambiosEstado)
      If chbHistoriaCambioEstado.Checked Then
         ugCambiosEstado.DataSource = Novedad.CambiosEstados
      Else
         ugCambiosEstado.DataSource = Novedad.CambiosEstadosAgrupado
      End If
      AjustarColumnasGrilla(ugCambiosEstado, tit)
   End Sub


#End Region

#Region "Eventos"

   Private Sub tbcDetalle_SelectedIndexChanged(sender As Object, e As EventArgs) Handles tbcDetalle.SelectedIndexChanged

      Try
         LeerPreferencias()
      Catch ex As Exception
         ShowError(ex)
      End Try

   End Sub

   Private Sub btnPreferencias_Click(sender As Object, e As EventArgs) Handles btnPreferencias.Click
      Try
         If Me.tbcDetalle.SelectedTab Is tbpComentarios Then
            Me.PreferenciasCargar(Me.ugSeguimiento, Me.ugSeguimiento.Name, Nothing)
         ElseIf Me.tbcDetalle.SelectedTab Is tbpOtrasNovedades Then
            Me.PreferenciasCargar(Me.ugDetalle, ugDetalle.Name, Nothing)
         Else
            Me.PreferenciasCargar(Me.ugNovedadesRelacionadas, ugNovedadesRelacionadas.Name, Nothing)
         End If

         Me.LeerPreferencias()
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

   Private Sub cmbTipoNovedad_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbTipoNovedad.SelectedIndexChanged
      Try
         Cursor = Cursors.WaitCursor
         Me.CambiaTipoNovedad()

         'si el tipo tiene el tilde de Visualizar agrego el taba
         If Me.cmbTipoNovedad.SelectedIndex > -1 Then
            TipoNovedad = New Reglas.CRMTiposNovedades().GetUno(Me.cmbTipoNovedad.SelectedValue.ToString())
         End If

         If TipoNovedad IsNot Nothing Then
            If TipoNovedad.VisualizaOtrasNovedades Then
               If Not Me.tbcDetalle.Contains(Me.tbpOtrasNovedades) Then
                  Me.tbcDetalle.TabPages.Add(Me.tbpOtrasNovedades)
               End If
            Else
               If Me.tbcDetalle.Contains(Me.tbpOtrasNovedades) Then
                  Me.tbcDetalle.TabPages.Remove(Me.tbpOtrasNovedades)
               End If
            End If
         Else
            'si el tipo es nothing veo que no existe sino lo remuevo
            If Me.tbcDetalle.Contains(Me.tbpOtrasNovedades) Then
               Me.tbcDetalle.TabPages.Remove(Me.tbpOtrasNovedades)
            End If
         End If

      Catch ex As Exception
         MessageBox.Show(ex.Message, Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      Finally
         Cursor = Cursors.Default
      End Try
   End Sub

   Private Sub ucNovedadesSistemas_SelectedChanged(sender As Object, e As EventArgs)
      Try
         _cargandoVersiones = True
         _publicos.CargaComboVersiones(cmbVersion, DirectCast(sender, ucNovedadesSistemas).IdSistema)
         Me.cmbVersion.SelectedIndex = -1
      Catch ex As Exception
         MessageBox.Show(ex.Message, Nothing, MessageBoxButtons.OK, MessageBoxIcon.Information)
      Finally
         _cargandoVersiones = False
      End Try
   End Sub
   Private Sub ucNovedadesProspectos_SelectedChanged(sender As Object, e As EventArgs)
      Try
         _publicos.CargaComboCRMProspectosInterlocutores(cmbInterlocutor, DirectCast(sender, ucNovedadesProspectos).IdProspectos)

         If Not _OnLoad Then
            For Each uc As Control In pnlReferencias.Controls
               If TypeOf (uc) Is ucNovedades AndAlso DirectCast(uc, ucNovedades).Dinamico.IdNombreDinamico = "SISTEMAS" Then
                  Dim clte As Entidades.Cliente = New Reglas.Clientes(Entidades.Cliente.ModoClienteProspecto.Prospecto).GetUno(DirectCast(sender, ucNovedadesProspectos).IdProspectos)
                  Novedad.IdSistema = clte.ZonaGeografica.IdZonaGeografica
                  MuestraControlesDinamicos(DirectCast(uc, ucNovedades), Novedad, copiando:=False)
               End If
            Next
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Nothing, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub


   Private Sub ucNovedadesCliente_SelectedChanged(sender As Object, e As EventArgs)
      Try
         _publicos.CargaComboCRMClientesInterlocutores(cmbInterlocutor, DirectCast(sender, ucNovedadesCliente).IdCliente)

         If Not _OnLoad Then
            For Each uc As Control In pnlReferencias.Controls
               If TypeOf (uc) Is ucNovedades AndAlso DirectCast(uc, ucNovedades).Dinamico.IdNombreDinamico = Entidades.CRMTipoNovedad.TipoDinamico.SISTEMAS.ToString() Then
                  Dim clte As Entidades.Cliente = New Reglas.Clientes().GetUno(DirectCast(sender, ucNovedadesCliente).IdCliente)
                  Novedad.IdSistema = clte.ZonaGeografica.IdZonaGeografica
                  MuestraControlesDinamicos(DirectCast(uc, ucNovedades), Novedad, copiando:=False)
               ElseIf TypeOf (uc) Is ucNovedades AndAlso DirectCast(uc, ucNovedades).Dinamico.IdNombreDinamico = Entidades.CRMTipoNovedad.TipoDinamico.PROYECTOS.ToString() Then
                  Dim ucProyecto As ucNovedadesProyectos = DirectCast(uc, ucNovedadesProyectos)
                  ucProyecto.bscCodigoProyecto.Text = String.Empty
                  ucProyecto.bscProyecto.Text = String.Empty
                  ucProyecto.txtEstado.Text = String.Empty
                  ucProyecto.txtPrioridad.Text = String.Empty
                  ucProyecto.txtClasificacion.Text = String.Empty
                  ucProyecto.IdCliente = DirectCast(sender, ucNovedadesCliente).IdCliente
               ElseIf TypeOf (uc) Is ucNovedades AndAlso DirectCast(uc, ucNovedades).Dinamico.IdNombreDinamico = Entidades.CRMTipoNovedad.TipoDinamico.VEHICULO.ToString() Then
                  Dim ucProyecto = DirectCast(uc, ucNovedadesVehiculos)
                  If ucProyecto.bscCodigoVehiculo.Text = String.Empty Then
                     ucProyecto.bscCodigoVehiculo.Text = String.Empty
                     ucProyecto.txtMarcaVehiculo.Clear()
                     ucProyecto.txtModeloVehiculo.Clear()
                     ucProyecto.txtAnioPatentamiento.Clear()
                     ucProyecto.txtColor.Clear()
                     ucProyecto.IdCliente = DirectCast(sender, ucNovedadesCliente).IdCliente
                  End If
               ElseIf TypeOf (uc) Is ucNovedades AndAlso DirectCast(uc, ucNovedades).Dinamico.IdNombreDinamico = Entidades.CRMTipoNovedad.TipoDinamico.CLIENTES.ToString() Then
                  Dim clte As Entidades.Cliente = New Reglas.Clientes().GetUno(DirectCast(sender, ucNovedadesCliente).IdCliente)
                  Novedad.IdCliente = clte.IdCliente
               ElseIf TypeOf (uc) Is ucNovedades AndAlso DirectCast(uc, ucNovedades).Dinamico.IdNombreDinamico = Entidades.CRMTipoNovedad.TipoDinamico.PRODUCTOS.ToString() Then
                  Dim ucProducto As ucNovedadesProductos = DirectCast(uc, ucNovedadesProductos)
                  ucProducto.bscCodigoProducto.Text = String.Empty
                  ucProducto.bscProducto.Text = String.Empty
                  ucProducto.IdCliente = DirectCast(sender, ucNovedadesCliente).IdCliente
               ElseIf TypeOf (uc) Is ucNovedades AndAlso DirectCast(uc, ucNovedades).Dinamico.IdNombreDinamico = Entidades.CRMTipoNovedad.TipoDinamico.OBSERVACION.ToString() Then
                  Dim ucObservacion As ucNovedadesObservacion = DirectCast(uc, ucNovedadesObservacion)
                  ucObservacion.txtObservacion.Text = String.Empty
                  ucObservacion.IdCliente = DirectCast(sender, ucNovedadesCliente).IdCliente
               ElseIf TypeOf (uc) Is ucNovedades AndAlso DirectCast(uc, ucNovedades).Dinamico.IdNombreDinamico = Entidades.CRMTipoNovedad.TipoDinamico.SERVICE.ToString() Then
                  Dim ucService As ucNovedadesService = DirectCast(uc, ucNovedadesService)
                  ucService.LimpiarComprobante()
                  ucService.IdCliente = DirectCast(sender, ucNovedadesCliente).IdCliente
               End If
            Next
            If Me.tbcDetalle.Contains(Me.tbpOtrasNovedades) Then
               Me.ugDetalle.DataSource = Nothing
               If DirectCast(sender, ucNovedadesCliente).IdCliente <> 0 Then
                  CargaOtrasNovedades(DirectCast(sender, ucNovedadesCliente).IdCliente)
               End If
            End If

            If Novedad.TipoNovedad.IdTipoNovedad = Entidades.CRMTipoNovedad.TipoDinamico.SERVICE.ToString() Then
               Me.tbcDetalle.SelectedTab = Me.tbpService
            End If
         End If
         '-- REQ-31756/31871 - Carga Domicilios de Entrega-Retiro.- --
         CargaDomiciliosRetiroEntrega()
      Catch ex As Exception
         MessageBox.Show(ex.Message, Nothing, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub chbMesCompletoOtrasNovedades_CheckedChanged(sender As Object, e As EventArgs) Handles chbMesCompletoOtrasNovedades.CheckedChanged
      Try
         chbMesCompletoOtrasNovedades.FiltroCheckedChangedMesCompleto(dtpFechaDesdeOtrasNovedades, dtpFechaHastaOtrasNovedades)
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

   Private Sub chbFechaOtrasNovedades_CheckedChanged(sender As Object, e As EventArgs) Handles chbFechaOtrasNovedades.CheckedChanged
      Try
         chbFechaOtrasNovedades.FiltroCheckedChanged(chbMesCompletoOtrasNovedades, dtpFechaDesdeOtrasNovedades, dtpFechaHastaOtrasNovedades)
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

   Private Sub btnConsultarOtrasNovedades_Click(sender As Object, e As EventArgs) Handles btnConsultarOtrasNovedades.Click
      Try
         Dim obj As Object = ObtenerValorControlesDinamicos(Entidades.CRMTipoNovedad.TipoDinamico.CLIENTES.ToString())
         If IsNumeric(obj) Then
            CargaOtrasNovedades(Long.Parse(obj.ToString()))
         End If
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

   '-- REQ-31756/31871 - Carga Domicilios de Entrega-Retiro.- --
   Private Sub CargaDomiciliosRetiroEntrega()
      If Novedad.IdCliente <> 0 Then
         '-- REQ-31756-RETIRO.- --
         With cmbDomicilioRetiro
            .DisplayMember = "DireccionAMostrar"
            .ValueMember = "IdDireccion"
            .DataSource = New Reglas.ClientesDirecciones().GetDirecciones(Novedad.IdCliente)
            .SelectedIndex = -1
         End With
         '-- REQ-31756-ENTREGA.- --
         With cmbDomicilioEntrega
            .DisplayMember = "DireccionAMostrar"
            .ValueMember = "IdDireccion"
            .DataSource = New Reglas.ClientesDirecciones().GetDirecciones(Novedad.IdCliente)
            .SelectedIndex = -1
         End With
      End If
   End Sub
   Private Sub CargaOtrasNovedades(idCliente As Long)
      Dim rCRM As Reglas.CRMNovedades = New Reglas.CRMNovedades()
      Dim fechaDesde As DateTime? = Nothing
      Dim fechaHasta As DateTime? = Nothing
      If chbFechaOtrasNovedades.Checked Then
         fechaDesde = dtpFechaDesdeOtrasNovedades.Value
         fechaHasta = dtpFechaHastaOtrasNovedades.Value
      End If
      Me.ugDetalle.DataSource = rCRM.GetNovedadesXCliente(Nothing, idCliente,
                                                          fechaDesde, fechaHasta,
                                                          If(IsNumeric(txtUltimosNRegistrosOtrasNovedades.Text), Integer.Parse(txtUltimosNRegistrosOtrasNovedades.Text), 0))
      Me.FormatearGrillaOtrasNovedades()
      If Me.ugDetalle.Rows.Count > 0 Then
         Me.tbcDetalle.SelectedTab = Me.tbpOtrasNovedades
      End If
   End Sub

   Private Sub ucNovedadesProyectos_SelectedChanged(sender As Object, e As EventArgs)
      Try
         '   _publicos.CargaComboCRMClientesInterlocutores(cmbInterlocutor, DirectCast(sender, ucNovedadesCliente).IdCliente)

         'If Not _OnLoad Then
         '   For Each uc As Control In pnlReferencias.Controls
         '      If TypeOf (uc) Is ucNovedades AndAlso DirectCast(uc, ucNovedades).Dinamico.IdNombreDinamico = "PROYECTOS" Then
         '         Dim ucProyecto As ucNovedadesProyectos = DirectCast(uc, ucNovedadesProyectos)
         '         ucProyecto.IdCliente = DirectCast(sender, ucNovedadesCliente).IdCliente
         '      End If
         '   Next
         'End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Nothing, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub
   Private Sub ucNovedadesVehiculos_SelectedChanged(sender As Object, e As EventArgs)
      TryCatched(
      Sub()
         If Not _OnLoad Then
            For Each uc As Control In pnlReferencias.Controls
               If TypeOf (uc) Is ucNovedades AndAlso DirectCast(uc, ucNovedades).Dinamico.IdNombreDinamico = Entidades.CRMTipoNovedad.TipoDinamico.CLIENTES.ToString() Then
                  Dim ucClientes = DirectCast(uc, ucNovedadesCliente)
                  If ucClientes.IdCliente = 0 Then
                     Dim ucVehiculo = DirectCast(sender, ucNovedadesVehiculos)
                     Dim vh = New Reglas.Vehiculos().GetUno(ucVehiculo.PatenteVehiculo)
                     If vh.Clientes.Count = 1 Then
                        ucClientes.IdCliente = vh.Clientes.First().IdCliente
                     End If
                  End If
               End If
            Next
         End If
      End Sub)
   End Sub

   Private Sub chbVerCambios_CheckedChanged(sender As Object, e As EventArgs) Handles chbVerCambios.CheckedChanged
      Try
         MostrarSeguimiento()
      Catch ex As Exception
         MessageBox.Show(ex.Message, Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub btnBanderaColor_Click(sender As Object, e As EventArgs) Handles btnBanderaColor.Click
      Try
         If btnBanderaColor.BackColor.ToArgb().Equals(SystemColors.Control.ToArgb()) Then
            btnBanderaColor.BackColor = Color.Green
         ElseIf btnBanderaColor.BackColor.ToArgb().Equals(Color.Green.ToArgb()) Then
            btnBanderaColor.BackColor = Color.Yellow
         ElseIf btnBanderaColor.BackColor.ToArgb().Equals(Color.Yellow.ToArgb()) Then
            btnBanderaColor.BackColor = Color.Red
         ElseIf btnBanderaColor.BackColor.ToArgb().Equals(Color.Red.ToArgb()) Then
            btnBanderaColor.BackColor = SystemColors.Control
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Nothing, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub txtComentarios_TextChanged(sender As Object, e As EventArgs) Handles txtComentarios.TextChanged
      Try
         lblCuentaCaracteres.Text = String.Format(_cuentaCaracteres, txtComentarios.Text.Length)
      Catch ex As Exception
         MessageBox.Show(ex.Message, Nothing, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub btnInsertarComentario_Click(sender As Object, e As EventArgs) Handles btnInsertarComentario.Click
      Try
         If Not String.IsNullOrWhiteSpace(Me.txtComentarios.Text) Then
            Dim fecha As DateTime = Now
            If dtpFechaEstadoNovedad.Checked Then
               fecha = dtpFechaEstadoNovedad.Value
            End If
            Dim _Seguimiento As Entidades.CRMNovedadSeguimiento = New Entidades.CRMNovedadSeguimiento(Nothing, fecha, txtComentarios.Text, cmbInterlocutor.Text, True,
                                                                                                      cmbNuevoIdTipoComentarioNovedad.ValorSeleccionado(Of Integer),
                                                                                                      cmbEstadoNovedad.ItemSeleccionado(Of Entidades.CRMEstadoNovedad),
                                                                                                      adjunto:=Nothing)
            'ver si hay algun archivo seleccionado
            If Not String.IsNullOrWhiteSpace(Me.txtNombreAdjunto.Text) Then
               'comprobar si existe el archivo
               Dim fileInfo = New IO.FileInfo(Me.txtNombreAdjunto.Text)
               If fileInfo.Exists Then
                  'agregar el adjunto al seguimiento
                  _Seguimiento.ArchivoAdjunto = New Entidades.CRMNovedadSeguimientoAdjunto(Nothing, Me.txtNombreAdjunto.Text.Trim())
               Else
                  ShowMessage(String.Format("No se puede acceder al archivo '{0}'.", fileInfo.FullName))
                  Exit Sub
               End If
            End If
            Me.Novedad.Seguimientos.Add(_Seguimiento)
            Me.MostrarSeguimiento()
            Me.txtComentarios.Text = ""
            Me.txtNombreAdjunto.Text = ""
            Me.txtComentarios.Focus()
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Nothing, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub btnEliminarComentario_Click(sender As Object, e As EventArgs) Handles btnEliminarComentario.Click

      Try
         'If Me.ugSeguimiento.ActiveCell Is Nothing Then
         '   If Me.ugSeguimiento.ActiveRow IsNot Nothing Then
         '      Me.ugSeguimiento.ActiveCell = Me.ugSeguimiento.ActiveRow.Cells(0)
         '   End If
         'End If
         If ugSeguimiento.ActiveRow IsNot Nothing AndAlso
            ugSeguimiento.ActiveRow.ListObject IsNot Nothing AndAlso
            TypeOf (ugSeguimiento.ActiveRow.ListObject) Is Entidades.CRMNovedadSeguimiento Then
            Dim seg As Entidades.CRMNovedadSeguimiento = DirectCast(ugSeguimiento.ActiveRow.ListObject, Entidades.CRMNovedadSeguimiento)
            If seg.EsComentario Then
               If MessageBox.Show("¿Está seguro de eliminar el registro seleccionado?", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                  Novedad.SeguimientosBorrados.Add(seg)
                  Novedad.Seguimientos.Remove(seg)
                  Me.MostrarSeguimiento()
               End If
            Else
               ShowMessage("No se puede eliminar el registro de cambios. Solo se pueden eliminar comentarios.")
            End If
         End If
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

   Private Sub btnExaminar_Click(sender As Object, e As EventArgs) Handles btnExaminar.Click
      DialogoAbrirArchivo.InitialDirectory = My.Computer.FileSystem.SpecialDirectories.Desktop

      If DialogoAbrirArchivo.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
         Try
            Dim fileInfo = New IO.FileInfo(DialogoAbrirArchivo.FileName)
            If fileInfo.Exists Then
               'Si bien aca lo pude abrir, solo es para obtener el path.
               txtNombreAdjunto.Text = DialogoAbrirArchivo.FileName
               txtNombreAdjunto.Focus()
            Else
               ShowMessage(String.Format("No se puede acceder al archivo '{0}'.", DialogoAbrirArchivo.FileName))
            End If
         Catch Ex As Exception
            ShowMessage(String.Format("ATENCION: No se puede leer el Archivo. Error: {0}", Ex.Message))
         End Try
      End If

   End Sub


   Private Sub ugCambiosEstado_InitializeRow(sender As Object, e As InitializeRowEventArgs) Handles ugCambiosEstado.InitializeRow
      TryCatched(Sub()
                    Dim row = ugSeguimiento.FilaSeleccionada(Of Entidades.CRMNovedadCambioEstado)(e.Row)
                    If row IsNot Nothing Then
                       If row.EstadoNovedad IsNot Nothing AndAlso row.EstadoNovedad.Color.HasValue Then
                          Dim color As Color = Drawing.Color.FromArgb(row.EstadoNovedad.Color.Value)
                          e.Row.Cells(Entidades.CRMEstadoNovedad.Columnas.NombreEstadoNovedad.ToString()).Color(Color.Black, color)
                       Else
                          e.Row.Cells(Entidades.CRMEstadoNovedad.Columnas.NombreEstadoNovedad.ToString()).Color(Nothing, Nothing)
                       End If
                    End If
                 End Sub)
   End Sub

   Private Sub ugSeguimiento_InitializeRow(sender As Object, e As InitializeRowEventArgs) Handles ugSeguimiento.InitializeRow
      Try
         Dim row As Entidades.CRMNovedadSeguimiento = ugSeguimiento.FilaSeleccionada(Of Entidades.CRMNovedadSeguimiento)(e.Row)
         If row IsNot Nothing Then
            If row.ArchivoAdjunto IsNot Nothing AndAlso Not String.IsNullOrWhiteSpace(row.ArchivoAdjunto.NombreAdjunto) Then
               e.Row.Cells("ClipArchivoAdjunto").Style = UltraWinGrid.ColumnStyle.EditButton
               e.Row.Cells("ClipArchivoAdjunto").ButtonAppearance.Image = My.Resources.paper_clip_64
            Else
               e.Row.Cells("ClipArchivoAdjunto").Activation = Activation.Disabled
            End If

            If row.EstadoNovedad IsNot Nothing AndAlso row.EstadoNovedad.Color.HasValue Then
               Dim Color As Color = Drawing.Color.FromArgb(row.EstadoNovedad.Color.Value)
               e.Row.Cells(Entidades.CRMEstadoNovedad.Columnas.NombreEstadoNovedad.ToString()).Appearance.BackColor = Color
               e.Row.Cells(Entidades.CRMEstadoNovedad.Columnas.NombreEstadoNovedad.ToString()).ActiveAppearance.BackColor = Color
               e.Row.Cells(Entidades.CRMEstadoNovedad.Columnas.NombreEstadoNovedad.ToString()).Appearance.ForeColor = Drawing.Color.Black
               e.Row.Cells(Entidades.CRMEstadoNovedad.Columnas.NombreEstadoNovedad.ToString()).ActiveAppearance.ForeColor = Drawing.Color.Black
            Else
               e.Row.Cells(Entidades.CRMEstadoNovedad.Columnas.NombreEstadoNovedad.ToString()).Appearance.BackColor = Nothing
               e.Row.Cells(Entidades.CRMEstadoNovedad.Columnas.NombreEstadoNovedad.ToString()).ActiveAppearance.BackColor = Nothing
               e.Row.Cells(Entidades.CRMEstadoNovedad.Columnas.NombreEstadoNovedad.ToString()).Appearance.ForeColor = Nothing
               e.Row.Cells(Entidades.CRMEstadoNovedad.Columnas.NombreEstadoNovedad.ToString()).ActiveAppearance.ForeColor = Nothing
            End If

            If e.Row.Cells("IdTipoComentarioNovedad").EditorComponentResolved IsNot Nothing Then
               Dim combo As Infragistics.Win.UltraWinEditors.UltraComboEditor = DirectCast(e.Row.Cells("IdTipoComentarioNovedad").EditorComponentResolved, Infragistics.Win.UltraWinEditors.UltraComboEditor)
               If TypeOf (combo.DataSource) Is List(Of Entidades.CRMTipoComentarioNovedad) Then
                  Dim lista As List(Of Entidades.CRMTipoComentarioNovedad) = DirectCast(combo.DataSource, List(Of Entidades.CRMTipoComentarioNovedad))
                  Dim sel As Entidades.CRMTipoComentarioNovedad = Nothing
                  If row.IdTipoComentarioNovedad.HasValue Then
                     sel = lista.FirstOrDefault(Function(x) x.IdTipoComentarioNovedad = row.IdTipoComentarioNovedad.Value)
                  End If

                  If sel IsNot Nothing AndAlso sel.Color.HasValue Then
                     e.Row.Cells("IdTipoComentarioNovedad").ActiveAppearance.BackColor = Color.FromArgb(sel.Color.Value)
                     e.Row.Cells("IdTipoComentarioNovedad").ActiveAppearance.ForeColor = Color.Black
                  Else
                     e.Row.Cells("IdTipoComentarioNovedad").ActiveAppearance.BackColor = Nothing
                     e.Row.Cells("IdTipoComentarioNovedad").ActiveAppearance.ForeColor = Nothing
                  End If
               End If
            End If

            If Not row.Activo Then
               e.Row.RowSelectorAppearance.ForeColor = Color.DarkGray
               e.Row.Appearance.ForeColor = Color.DarkGray
               e.Row.Appearance.FontData.Strikeout = DefaultableBoolean.True
            Else
               e.Row.RowSelectorAppearance.ForeColor = Nothing
               e.Row.Appearance.ForeColor = Nothing
               e.Row.Appearance.FontData.Strikeout = DefaultableBoolean.Default
            End If

         End If
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

   Private Sub ugSeguimiento_ClickCellButton(sender As Object, e As CellEventArgs) Handles ugSeguimiento.ClickCellButton
      Try
         Dim row As Entidades.CRMNovedadSeguimiento = ugSeguimiento.FilaSeleccionada(Of Entidades.CRMNovedadSeguimiento)(e.Cell.Row)
         If row IsNot Nothing Then
            Select Case e.Cell.Column.Key
               Case "ClipArchivoAdjunto"
                  If row.ArchivoAdjunto IsNot Nothing AndAlso Not String.IsNullOrWhiteSpace(row.ArchivoAdjunto.NombreAdjunto) Then
                     Using pantallaAdjunto As Eniac.Win.BaseDetalle = New CRMNovedadesSeguimientoAdjunto(row.ArchivoAdjunto)
                        pantallaAdjunto.MdiParent = MdiParent
                        pantallaAdjunto.ShowDialog()
                     End Using
                  End If
               Case "VerDescripcion"
                  If Not String.IsNullOrWhiteSpace(row.Comentario) Then
                     Using frm As VisorTexto = New VisorTexto()
                        frm.ShowDialog(Me, String.Format("Comentario {4} de {0} {1} {2:0000}-{3:00000000}",
                                                         If(row.TipoNovedad IsNot Nothing, row.TipoNovedad.NombreTipoNovedad, cmbTipoNovedad.Text),
                                                         row.Letra, row.CentroEmisor, row.IdNovedad, row.IdSeguimiento),
                                       row.Comentario)
                     End Using
                  End If
               Case "CopiarDescripcion"
                  If Not String.IsNullOrWhiteSpace(row.Comentario) Then
                     Clipboard.SetText(row.Comentario)
                  End If
               Case Else

            End Select
         End If
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

   Private Sub chbHistoriaCambioEstado_CheckedChanged(sender As Object, e As EventArgs) Handles chbHistoriaCambioEstado.CheckedChanged
      TryCatched(Sub() MostrarCambiosEstados())
   End Sub


#Region "Eventos Buscadores"


   Private Sub bscCodigoProductoPrestado2_BuscadorClick() Handles bscCodigoProductoPrestado2.BuscadorClick
      Try
         Dim oProductos As Eniac.Reglas.Productos = New Eniac.Reglas.Productos
         Me._publicos.PreparaGrillaProductos2(Me.bscCodigoProductoPrestado2)
         Me.bscCodigoProductoPrestado2.Datos = oProductos.GetPorCodigo(Me.bscCodigoProductoPrestado2.Text.Trim(), actual.Sucursal.Id, Publicos.ListaPreciosPredeterminada, "TODOS")
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub
   Private Sub bscCodigoProductoPrestado2_BuscadorSeleccion(sender As Object, e As Controles.BuscadorEventArgs) Handles bscCodigoProductoPrestado2.BuscadorSeleccion
      Try
         If Not e.FilaDevuelta Is Nothing Then
            Me.CargarProductoPrestado(e.FilaDevuelta)
         End If
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

   Private Sub bscProductoPrestado2_BuscadorClick() Handles bscProductoPrestado2.BuscadorClick
      Try
         Dim oProductos As Eniac.Reglas.Productos = New Eniac.Reglas.Productos
         Me._publicos.PreparaGrillaProductos2(Me.bscProductoPrestado2)
         Me.bscProductoPrestado2.Datos = oProductos.GetPorNombre(Me.bscProductoPrestado2.Text.Trim(), actual.Sucursal.Id, Publicos.ListaPreciosPredeterminada, "TODOS")
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub
   Private Sub bscProductoPrestado2_BuscadorSeleccion(sender As Object, e As Controles.BuscadorEventArgs) Handles bscProductoPrestado2.BuscadorSeleccion
      Try
         If Not e.FilaDevuelta Is Nothing Then
            Me.CargarProductoPrestado(e.FilaDevuelta)
         End If
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

   Private Sub bscCodigoProveedor_BuscadorClick() Handles bscCodigoProveedor.BuscadorClick
      Dim codigoProveedor As Long = -1
      Try
         Dim oProveedores As Reglas.Proveedores = New Reglas.Proveedores

         Me._publicos.PreparaGrillaProveedores2(Me.bscCodigoProveedor)
         If Me.bscCodigoProveedor.Text.Trim.Length > 0 Then
            codigoProveedor = Long.Parse(Me.bscCodigoProveedor.Text.Trim())
         End If
         Me.bscCodigoProveedor.Datos = oProveedores.GetFiltradoPorCodigo(codigoProveedor)
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub
   Private Sub bscCodigoProveedor_BuscadorSeleccion(sender As Object, e As Controles.BuscadorEventArgs) Handles bscCodigoProveedor.BuscadorSeleccion
      Try
         If e.FilaDevuelta IsNot Nothing Then
            Me.CargarDatosProveedor(e.FilaDevuelta)
         End If
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

   Private Sub bscProveedor_BuscadorClick() Handles bscProveedor.BuscadorClick
      Try
         Dim oProveedores As Reglas.Proveedores = New Reglas.Proveedores

         Me._publicos.PreparaGrillaProveedores2(Me.bscProveedor)
         Me.bscProveedor.Datos = oProveedores.GetFiltradoPorNombre(Me.bscProveedor.Text.Trim())
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

   Private Sub bscProveedor_BuscadorSeleccion(sender As Object, e As Controles.BuscadorEventArgs) Handles bscProveedor.BuscadorSeleccion
      Try
         If Not e.FilaDevuelta Is Nothing Then
            Me.CargarDatosProveedor(e.FilaDevuelta)
         End If
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

#End Region


#End Region

#Region "MostrarControlesDinamicos"
   Protected Overridable Sub MuestraControlesDinamicos()
      MuestraControlesDinamicos(Novedad, copiando:=False)
   End Sub
   Protected Overridable Sub MuestraControlesDinamicos(novedad As Entidades.CRMNovedad, copiando As Boolean)
      'limpio listado de paneles activos
      Me._panelesActivos.Clear()

      For Each uc As Control In pnlReferencias.Controls
         If TypeOf (uc) Is ucNovedades Then
            MuestraControlesDinamicos(DirectCast(uc, ucNovedades), novedad, copiando)
            'cargo el nombre del panel
            Me._panelesActivos.Add(DirectCast(uc, ucNovedades).Dinamico.IdNombreDinamico)
         End If
      Next
   End Sub
   Protected Overridable Sub MuestraControlesDinamicos(uc As ucNovedades, novedad As Entidades.CRMNovedad, copiando As Boolean)
      Select Case uc.Dinamico.IdNombreDinamico     '.StringToEnum(Entidades.CRMTipoNovedad.TipoDinamico.CLIENTES)
         Case Entidades.CRMTipoNovedad.TipoDinamico.CLIENTES.ToString()
            DirectCast(uc, ucNovedadesCliente).IdCliente = novedad.IdCliente
            If copiando Then
               DirectCast(uc, ucNovedadesCliente).RevisionAdministrativa = novedad.RevisionAdministrativa
            End If
         Case Entidades.CRMTipoNovedad.TipoDinamico.PROSPECTOS.ToString()
            DirectCast(uc, ucNovedadesProspectos).IdProspectos = novedad.IdProspecto
         Case Entidades.CRMTipoNovedad.TipoDinamico.PROVEEDORES.ToString()
            DirectCast(uc, ucNovedadesProveedores).IdProveedor = novedad.IdProveedor
         Case Entidades.CRMTipoNovedad.TipoDinamico.FUNCIONES.ToString()
            DirectCast(uc, ucNovedadesFuncionesAplicacion).IdFuncion = novedad.IdFuncion
         Case Entidades.CRMTipoNovedad.TipoDinamico.SISTEMAS.ToString()
            DirectCast(uc, ucNovedadesSistemas).IdSistema = novedad.IdSistema
         Case Entidades.CRMTipoNovedad.TipoDinamico.METODORESOLUCION.ToString()
            DirectCast(uc, ucNovedadesMedioResolucion).IdMetodoResolucionNovedad = novedad.IdMetodoResolucionNovedad
         Case Entidades.CRMTipoNovedad.TipoDinamico.MOTIVOS.ToString()
            DirectCast(uc, ucNovedadesMotivo).IdMotivoNovedad = novedad.IdMotivoNovedad
         Case Entidades.CRMTipoNovedad.TipoDinamico.APLICACIONTERCERO.ToString()
            DirectCast(uc, ucNovedadesAplicacionesTerceros).IdAplicacion = novedad.IdAplicacionTerceros
         Case Entidades.CRMTipoNovedad.TipoDinamico.PROYECTOS.ToString()
            DirectCast(uc, ucNovedadesProyectos).TipoNovedad = novedad.TipoNovedad
            DirectCast(uc, ucNovedadesProyectos).IdCliente = novedad.IdCliente
            DirectCast(uc, ucNovedadesProyectos).IdProyecto = novedad.IdProyecto
         Case Entidades.CRMTipoNovedad.TipoDinamico.VEHICULO.ToString()
            DirectCast(uc, ucNovedadesVehiculos).TipoNovedad = novedad.TipoNovedad
            DirectCast(uc, ucNovedadesVehiculos).IdCliente = novedad.IdCliente
            DirectCast(uc, ucNovedadesVehiculos).PatenteVehiculo = novedad.PatenteVehiculo
         Case Entidades.CRMTipoNovedad.TipoDinamico.SERVICE.ToString()
            With DirectCast(uc, ucNovedadesService)
               .IdCliente = novedad.IdCliente
               .SetComprobante(novedad.IdSucursalService, novedad.IdTipoComprobanteService, novedad.LetraService, novedad.CentroEmisorService, novedad.NumeroComprobanteService)
               .StateForm = Me.StateForm
               If _novedadCopia IsNot Nothing Then Exit Select '# Para que al copiar de entre comprobantes de service, deba volver a seleccionar el producto.
               '-- REQ-31710.- ------------------------------------------
               .idMarcaProducto = novedad.IdMarcaProducto
               .NombreMarcaProducto = novedad.NombreMarcaProducto
               .idModeloProducto = novedad.IdModeloProducto
               .NombreModeloProducto = novedad.NombreModeloProducto
               '---------------------------------------------------------
               .NombreProducto = novedad.NombreProducto
               .NroDeSerie = novedad.NroDeSerie
               .IdProducto = novedad.IdProducto

               .ServiceLugarCompra = novedad.ServiceLugarCompra
               .ServiceLugarCompraFecha = novedad.ServiceLugarCompraFecha
               .ServiceLugarCompraTipoComprobante = novedad.ServiceLugarCompraTipoComprobante
               .ServiceLugarCompraNumeroComprobante = novedad.ServiceLugarCompraNumeroComprobante
               .MostrarServiceLugarCompra = TipoNovedad.TieneDinamico(Entidades.CRMTipoNovedad.TipoDinamico.SERVICELUGARCOMPRA)

            End With
         Case Entidades.CRMTipoNovedad.TipoDinamico.PRODUCTOS.ToString()
            DirectCast(uc, ucNovedadesProductos).IdCliente = novedad.IdCliente
            DirectCast(uc, ucNovedadesProductos).IdProductoNovedad = novedad.IdProductoNovedad
         Case Entidades.CRMTipoNovedad.TipoDinamico.OBSERVACION.ToString()
            DirectCast(uc, ucNovedadesObservacion).IdCliente = novedad.IdCliente
            DirectCast(uc, ucNovedadesObservacion).Observacion = novedad.Observacion
         Case Else

      End Select

   End Sub
#End Region

#Region "GrabaControlesDinamicos"
   Protected Overridable Sub GuardaControlesDinamicos()
      For Each uc As Control In pnlReferencias.Controls
         If TypeOf (uc) Is ucNovedades Then
            GuardaControlesDinamicos(DirectCast(uc, ucNovedades))
         End If
      Next
   End Sub
   Protected Overridable Sub GuardaControlesDinamicos(uc As ucNovedades)
      Select Case uc.Dinamico.IdNombreDinamico     '.StringToEnum(Entidades.CRMTipoNovedad.TipoDinamico.CLIENTES)
         Case Entidades.CRMTipoNovedad.TipoDinamico.CLIENTES.ToString()
            Novedad.IdCliente = DirectCast(uc, ucNovedadesCliente).IdCliente
            Novedad.RevisionAdministrativa = DirectCast(uc, ucNovedadesCliente).RevisionAdministrativa
         Case Entidades.CRMTipoNovedad.TipoDinamico.PROSPECTOS.ToString()
            Novedad.IdProspecto = DirectCast(uc, ucNovedadesProspectos).IdProspectos
         Case Entidades.CRMTipoNovedad.TipoDinamico.PROVEEDORES.ToString()
            Novedad.IdProveedor = DirectCast(uc, ucNovedadesProveedores).IdProveedor
         Case Entidades.CRMTipoNovedad.TipoDinamico.FUNCIONES.ToString()
            Novedad.IdFuncion = DirectCast(uc, ucNovedadesFuncionesAplicacion).IdFuncion
         Case Entidades.CRMTipoNovedad.TipoDinamico.SISTEMAS.ToString()
            Novedad.IdSistema = DirectCast(uc, ucNovedadesSistemas).IdSistema
         Case Entidades.CRMTipoNovedad.TipoDinamico.METODORESOLUCION.ToString()
            Novedad.IdMetodoResolucionNovedad = DirectCast(uc, ucNovedadesMedioResolucion).IdMetodoResolucionNovedad
         Case Entidades.CRMTipoNovedad.TipoDinamico.MOTIVOS.ToString()
            Novedad.IdMotivoNovedad = DirectCast(uc, ucNovedadesMotivo).IdMotivoNovedad
         Case Entidades.CRMTipoNovedad.TipoDinamico.APLICACIONTERCERO.ToString()
            Novedad.IdAplicacionTerceros = DirectCast(uc, ucNovedadesAplicacionesTerceros).IdAplicacion
         Case Entidades.CRMTipoNovedad.TipoDinamico.PROYECTOS.ToString()
            Novedad.IdProyecto = DirectCast(uc, ucNovedadesProyectos).IdProyecto
         Case Entidades.CRMTipoNovedad.TipoDinamico.VEHICULO.ToString()
            Novedad.PatenteVehiculo = DirectCast(uc, ucNovedadesVehiculos).PatenteVehiculo
         Case Entidades.CRMTipoNovedad.TipoDinamico.PRODUCTOS.ToString()
            Novedad.IdProductoNovedad = DirectCast(uc, ucNovedadesProductos).IdProductoNovedad
         Case Entidades.CRMTipoNovedad.TipoDinamico.OBSERVACION.ToString()
            Novedad.Observacion = DirectCast(uc, ucNovedadesObservacion).Observacion
         Case Entidades.CRMTipoNovedad.TipoDinamico.SERVICE.ToString()
            With DirectCast(uc, ucNovedadesService)
               Novedad.IdProducto = .IdProducto
               Novedad.NombreProducto = .NombreProducto
               Novedad.IdSucursalService = .IdSucursal
               Novedad.IdTipoComprobanteService = .IdTipoComprobante
               Novedad.LetraService = .Letra
               Novedad.CentroEmisorService = .CentroEmisor
               Novedad.NumeroComprobanteService = .NumeroComprobante
               Novedad.NroDeSerie = .NroDeSerie
               Novedad.IdMarcaProducto = .idMarcaProducto
               Novedad.IdModeloProducto = .idModeloProducto
               .CargaMarcaModelo()
               Novedad.NombreMarcaProducto = .NombreMarcaProducto.ToUpper()
               Novedad.NombreModeloProducto = .NombreModeloProducto.ToUpper()
               Novedad.ServiceLugarCompra = .ServiceLugarCompra
               Novedad.ServiceLugarCompraFecha = .ServiceLugarCompraFecha
               Novedad.ServiceLugarCompraTipoComprobante = .ServiceLugarCompraTipoComprobante
               Novedad.ServiceLugarCompraNumeroComprobante = .ServiceLugarCompraNumeroComprobante
               '-- Recupera Caracteristica de Producto.- --
               _modificaDescrip = .ModificaDescrip
            End With
         Case Else

      End Select

   End Sub
#End Region

#Region "GrabaControlesDinamicos"
   Protected Overridable Function ObtenerValorControlesDinamicos(idNombreDinamico As String) As Object
      For Each ctrl As Control In pnlReferencias.Controls
         If TypeOf (ctrl) Is ucNovedades Then
            Dim uc As ucNovedades = DirectCast(ctrl, ucNovedades)
            If uc.Dinamico.IdNombreDinamico = idNombreDinamico Then
               Select Case uc.Dinamico.IdNombreDinamico     '.StringToEnum(Entidades.CRMTipoNovedad.TipoDinamico.CLIENTES)
                  Case Entidades.CRMTipoNovedad.TipoDinamico.CLIENTES.ToString()
                     Return DirectCast(uc, ucNovedadesCliente).IdCliente
                  Case Entidades.CRMTipoNovedad.TipoDinamico.PROSPECTOS.ToString()
                     Return DirectCast(uc, ucNovedadesProspectos).IdProspectos
                  Case Entidades.CRMTipoNovedad.TipoDinamico.PROVEEDORES.ToString()
                     Return DirectCast(uc, ucNovedadesProveedores).IdProveedor
                  Case Entidades.CRMTipoNovedad.TipoDinamico.FUNCIONES.ToString()
                     Return DirectCast(uc, ucNovedadesFuncionesAplicacion).IdFuncion
                  Case Entidades.CRMTipoNovedad.TipoDinamico.SISTEMAS.ToString()
                     Return DirectCast(uc, ucNovedadesSistemas).IdSistema
                  Case Entidades.CRMTipoNovedad.TipoDinamico.METODORESOLUCION.ToString()
                     Return DirectCast(uc, ucNovedadesMedioResolucion).IdMetodoResolucionNovedad
                  Case Entidades.CRMTipoNovedad.TipoDinamico.MOTIVOS.ToString()
                     Return DirectCast(uc, ucNovedadesMotivo).IdMotivoNovedad
                  Case Entidades.CRMTipoNovedad.TipoDinamico.APLICACIONTERCERO.ToString()
                     Return DirectCast(uc, ucNovedadesAplicacionesTerceros).IdAplicacion
                  Case Entidades.CRMTipoNovedad.TipoDinamico.PROYECTOS.ToString()
                     Return DirectCast(uc, ucNovedadesProyectos).IdProyecto
                  Case Entidades.CRMTipoNovedad.TipoDinamico.VEHICULO.ToString()
                     Return DirectCast(uc, ucNovedadesVehiculos).PatenteVehiculo
                  Case Entidades.CRMTipoNovedad.TipoDinamico.PRODUCTOS.ToString()
                     Return DirectCast(uc, ucNovedadesProductos).IdProductoNovedad
                  Case Entidades.CRMTipoNovedad.TipoDinamico.OBSERVACION.ToString()
                     Return DirectCast(uc, ucNovedadesObservacion).Observacion
                  Case Else

               End Select
            End If
         End If
      Next
      Return Nothing
   End Function
#End Region


#Region "InicializaControlesDinamicos"
   Protected Overridable Sub InicializaControlesDinamicos(tipoNovedad As Entidades.CRMTipoNovedad)
      For Each dinamico As Entidades.CRMTipoNovedadDinamico In tipoNovedad.Dinamicos
         InicializaControlesDinamicos(dinamico)
      Next
   End Sub
   Protected Overridable Sub InicializaControlesDinamicos(dinamico As Entidades.CRMTipoNovedadDinamico)
      Select Case dinamico.IdNombreDinamico  '.StringToEnum(Entidades.CRMTipoNovedad.TipoDinamico.CLIENTES)
         Case Entidades.CRMTipoNovedad.TipoDinamico.CLIENTES.ToString()
            Dim ucNovedadesCliente As New ucNovedadesCliente()
            If TipoNovedad IsNot Nothing Then
               ucNovedadesCliente.VisualizaRevisionAdministrativa = TipoNovedad.VisualizaRevisionAdministrativa
               ucNovedadesCliente.RevisionAdministrativa = Novedad.RevisionAdministrativa
               ucNovedadesCliente.StateForm = Me.StateForm
               ucNovedadesCliente.Novedad = Novedad
            End If
            InicializaControlesDinamicos(ucNovedadesCliente, dinamico)
            AddHandler ucNovedadesCliente.SelectedChanged, AddressOf ucNovedadesCliente_SelectedChanged
         Case Entidades.CRMTipoNovedad.TipoDinamico.PROSPECTOS.ToString()
            Dim ucNovedadesProspectos As New ucNovedadesProspectos()
            InicializaControlesDinamicos(ucNovedadesProspectos, dinamico)
            AddHandler ucNovedadesProspectos.SelectedChanged, AddressOf ucNovedadesProspectos_SelectedChanged
         Case Entidades.CRMTipoNovedad.TipoDinamico.PROVEEDORES.ToString()
            Dim ucNovedadesProveedores As New ucNovedadesProveedores()
            InicializaControlesDinamicos(ucNovedadesProveedores, dinamico)
            'AddHandler ucNovedadesProveedores.SelectedChanged, AddressOf ucNovedadesProveedores_SelectedChanged
         Case Entidades.CRMTipoNovedad.TipoDinamico.FUNCIONES.ToString()
            InicializaControlesDinamicos(New ucNovedadesFuncionesAplicacion(), dinamico)
         Case Entidades.CRMTipoNovedad.TipoDinamico.SISTEMAS.ToString()
            Dim ucNovedadesSistemas As New ucNovedadesSistemas()
            InicializaControlesDinamicos(ucNovedadesSistemas, dinamico)
            AddHandler ucNovedadesSistemas.SelectedChanged, AddressOf ucNovedadesSistemas_SelectedChanged

         Case Entidades.CRMTipoNovedad.TipoDinamico.METODORESOLUCION.ToString()
            Dim ucNovedadesMedioResolucion As New ucNovedadesMedioResolucion()
            InicializaControlesDinamicos(ucNovedadesMedioResolucion, dinamico)
            'Novedad.IdMetodoResolucionNovedad = 0
            Dim tipo As String = String.Empty
            If Novedad IsNot Nothing Then
               tipo = Novedad.IdTipoNovedad
               ucNovedadesMedioResolucion.IdTipoNovedad = tipo
            End If
            If StateForm = Win.StateForm.Insertar Then
               For Each estado As Entidades.CRMMetodoResolucionNovedad In New Reglas.CRMMetodosResolucionesNovedades().GetTodos(tipo)
                  If estado.PorDefecto Then
                     Novedad.IdMetodoResolucionNovedad = estado.IdMetodoResolucionNovedad
                     Exit For
                  End If
               Next
               'Else
               '   Novedad.IdMetodoResolucionNovedad = Novedad.IdMetodoResolucionNovedad
            End If

         Case Entidades.CRMTipoNovedad.TipoDinamico.MOTIVOS.ToString()
            Dim ucNovedadesMotivos = New ucNovedadesMotivo()
            InicializaControlesDinamicos(ucNovedadesMotivos, dinamico)
            Dim tipo As String = String.Empty
            If Novedad IsNot Nothing Then
               tipo = Novedad.IdTipoNovedad
               ucNovedadesMotivos.IdTipoNovedad = tipo
            End If
            If StateForm = Win.StateForm.Insertar Then
               Dim mot = New Reglas.CRMMotivosNovedades().GetTodos(tipo).FirstOrDefault()
               If mot IsNot Nothing Then
                  Novedad.MotivoNovedad = mot
               End If
            End If
            ''AddHandler ucNovedadesMotivos.SelectedChanged, AddressOf ucNovedadesProyectos_SelectedChanged

         Case Entidades.CRMTipoNovedad.TipoDinamico.APLICACIONTERCERO.ToString()
            Dim ucNovedadesAplicacionTerceros = New ucNovedadesAplicacionesTerceros()
            InicializaControlesDinamicos(ucNovedadesAplicacionTerceros, dinamico)
            ''AddHandler ucNovedadesAplicacionTerceros.SelectedChanged, AddressOf ucNovedadesSistemas_SelectedChanged

         Case Entidades.CRMTipoNovedad.TipoDinamico.PROYECTOS.ToString()
            Dim ucNovedadesProyectos As New ucNovedadesProyectos()
            InicializaControlesDinamicos(ucNovedadesProyectos, dinamico)
            AddHandler ucNovedadesProyectos.SelectedChanged, AddressOf ucNovedadesProyectos_SelectedChanged

         Case Entidades.CRMTipoNovedad.TipoDinamico.VEHICULO.ToString()
            Dim ucNovedadesVehiculos = New ucNovedadesVehiculos()
            InicializaControlesDinamicos(ucNovedadesVehiculos, dinamico)
            AddHandler ucNovedadesVehiculos.SelectedChanged, AddressOf ucNovedadesVehiculos_SelectedChanged
            If Not Me.tbcDetalle.Contains(Me.tbpService) Then
               tbcDetalle.TabPages.Insert(0, tbpService)
               tbcDetalle.TabPages.Insert(1, tbpRetiroEntrega)
               tbcDetalle.TabPages.Insert(2, tbpProductos)
               tbcDetalle.SelectedTab = tbpService
            End If
         Case Entidades.CRMTipoNovedad.TipoDinamico.SERVICE.ToString()
            Dim ucNovedadesService As New ucNovedadesService
            ucNovedadesService.StateForm = Me.StateForm
            InicializaControlesDinamicos(ucNovedadesService, dinamico)
            If Not Me.tbcDetalle.Contains(Me.tbpService) Then
               tbcDetalle.TabPages.Insert(0, tbpService)
               tbcDetalle.TabPages.Insert(1, tbpRetiroEntrega)
               tbcDetalle.TabPages.Insert(2, tbpProductos)
               tbcDetalle.SelectedTab = tbpService
            End If
         Case Entidades.CRMTipoNovedad.TipoDinamico.PRODUCTOS.ToString()
            InicializaControlesDinamicos(New ucNovedadesProductos(), dinamico)
         Case Entidades.CRMTipoNovedad.TipoDinamico.OBSERVACION.ToString()
            InicializaControlesDinamicos(New ucNovedadesObservacion(), dinamico)
         Case Else

      End Select
   End Sub
   Protected Overridable Sub InicializaControlesDinamicos(ucDinamico As ucNovedades, dinamico As Entidades.CRMTipoNovedadDinamico)
      ucDinamico.Dinamico = dinamico
      pnlReferencias.Controls.Add(ucDinamico)
   End Sub
#End Region

   Private Sub FormatearGrillaRelacionadas()

      'ugNovedadesRelacionadas.DisplayLayout.UseFixedHeaders = True
      'ugNovedadesRelacionadas.DisplayLayout.Override.FixedHeaderIndicator = FixedHeaderIndicator.None
      Dim pos As Integer = 0
      With ugNovedadesRelacionadas.DisplayLayout.Bands(0)

         For Each columna As UltraGridColumn In .Columns
            columna.Hidden = True
            columna.CellActivation = Activation.NoEdit
         Next

         .Columns("Parentesco").FormatearColumna("", pos, 50, HAlign.Center)

         .Columns(Entidades.CRMNovedad.Columnas.BanderaColor.ToString()).FormatearColumna("", 1000, 30, , True)

         .Columns(Entidades.CRMTipoNovedad.Columnas.NombreTipoNovedad.ToString()).FormatearColumna("Tipo", pos, 60)
         .Columns(Entidades.CRMNovedad.Columnas.Letra.ToString()).FormatearColumna("L.", pos, 25, HAlign.Center)
         .Columns(Entidades.CRMNovedad.Columnas.CentroEmisor.ToString()).FormatearColumna("Emisor", pos, 45, HAlign.Right, True)
         .Columns(Entidades.CRMNovedad.Columnas.IdNovedad.ToString()).FormatearColumna("Número", pos, 60, HAlign.Right)
         .Columns(Entidades.CRMNovedad.Columnas.FechaNovedad.ToString()).FormatearColumna("Fecha / Hora", pos, 120, HAlign.Center, True, "dd/MM/yyyy HH:mm:ss")
         .Columns(Entidades.CRMNovedad.Columnas.FechaNovedad.ToString() + "_Fecha").FormatearColumna("Fecha", pos, 80, HAlign.Center)
         .Columns(Entidades.CRMNovedad.Columnas.FechaNovedad.ToString() + "_Hora").FormatearColumna("Hora", pos, 40, HAlign.Center)
         .Columns(Entidades.CRMNovedad.Columnas.Descripcion.ToString()).FormatearColumna("Descripción", pos, 150)

         .Columns(Entidades.CRMNovedad.Columnas.IdUsuarioAsignado.ToString()).FormatearColumna("Usuario Asignado", pos, 100)
         .Columns(Entidades.CRMEstadoNovedad.Columnas.NombreEstadoNovedad.ToString()).FormatearColumna("Estado", pos, 120)
         .Columns(Entidades.CRMNovedad.Columnas.FechaEstadoNovedad.ToString()).FormatearColumna("Fecha/Hora Estado", pos, 80, HAlign.Center, hidden:=True)
         .Columns(Entidades.CRMNovedad.Columnas.FechaEstadoNovedad.ToString()).Format = "dd/MM/yyyy HH:mm:ss"
         .Columns(Entidades.CRMNovedad.Columnas.FechaEstadoNovedad.ToString() + "_Fecha").FormatearColumna("Fecha Estado", pos, 80, HAlign.Center)
         .Columns(Entidades.CRMNovedad.Columnas.FechaEstadoNovedad.ToString() + "_Hora").FormatearColumna("Hora Estado", pos, 40, HAlign.Center)

         .Columns(Entidades.CRMPrioridadNovedad.Columnas.NombrePrioridadNovedad.ToString()).FormatearColumna("Prioridad", pos, 70)
         .Columns(Entidades.CRMCategoriaNovedad.Columnas.NombreCategoriaNovedad.ToString()).FormatearColumna("Categoria", pos, 110)
         .Columns(Entidades.CRMMetodoResolucionNovedad.Columnas.NombreMetodoResolucionNovedad.ToString()).FormatearColumna("Método", pos, 110)

         .Columns(Entidades.CRMNovedad.Columnas.Avance.ToString()).FormatearColumna("% Av.", pos, 50, HAlign.Right)
         .Columns(Entidades.CRMNovedad.Columnas.Cantidad.ToString()).FormatearColumna(TipoNovedad.UnidadDeMedida, pos, 50, HAlign.Right)

      End With

      ugNovedadesRelacionadas.AgregarFiltroEnLinea({Entidades.Cliente.Columnas.NombreCliente.ToString(),
                                     Entidades.Cliente.Columnas.NombreDeFantasia.ToString(),
                                     "NombreProspecto",
                                     "NombreDeFantasiaProspecto",
                                     "NombreProveedor",
                                     Entidades.CRMNovedad.Columnas.Interlocutor.ToString(),
                                     Entidades.CRMNovedad.Columnas.Descripcion.ToString(),
                                     "NombreFuncion"})

   End Sub
   Private Sub ugNovedadesRelacionadas_InitializeRow(sender As Object, e As InitializeRowEventArgs) Handles ugNovedadesRelacionadas.InitializeRow
      Try
         Dim color As Color = SystemColors.Control
         If IsNumeric(e.Row.Cells("ColorEstado").Value) Then
            color = Drawing.Color.FromArgb(Integer.Parse(e.Row.Cells("ColorEstado").Value.ToString()))
            e.Row.Cells(Entidades.CRMEstadoNovedad.Columnas.NombreEstadoNovedad.ToString()).Appearance.BackColor = color
            e.Row.Cells(Entidades.CRMEstadoNovedad.Columnas.NombreEstadoNovedad.ToString()).ActiveAppearance.BackColor = color
         End If

         If IsNumeric(e.Row.Cells("ColorCategoria").Value) Then
            color = Drawing.Color.FromArgb(Integer.Parse(e.Row.Cells("ColorCategoria").Value.ToString()))
            e.Row.Cells(Entidades.CRMCategoriaNovedad.Columnas.NombreCategoriaNovedad.ToString()).Appearance.BackColor = color
            e.Row.Cells(Entidades.CRMCategoriaNovedad.Columnas.NombreCategoriaNovedad.ToString()).ActiveAppearance.BackColor = color
         End If

         Dim celParentesco = e.Row.Cells("Parentesco")
         Select Case celParentesco.ValorAs(Of String)()
            Case "Padre"
               celParentesco.Color(foreColor:=Drawing.Color.Black, backColor:=Drawing.Color.LightGreen)
            Case "Hijo"
               celParentesco.Color(foreColor:=Drawing.Color.Black, backColor:=Drawing.Color.Yellow)
            Case Else
               celParentesco.Color(foreColor:=Nothing, backColor:=Nothing)
         End Select


      Catch ex As Exception
         MessageBox.Show(ex.Message, Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub FormatearGrillaOtrasNovedades()

      If ugDetalle.DisplayLayout.Bands(0).Columns.Count = 0 Then
         Exit Sub
      End If

      Dim pos As Integer = 0
      With ugDetalle.DisplayLayout.Bands(0)
         .Columns("NombreCliente").OcultoPosicion(True, pos)

         .Columns("NombreTipoNovedad").FormatearColumna("Tipo", pos, 70)
         .Columns("IdNovedad").FormatearColumna("Novedad", pos, 60, HAlign.Right)
         .Columns("Usuario").FormatearColumna("Usuario", pos, 110)
         .Columns("FechaNovedad").FormatearColumna("Fecha Nov.", pos, 100, HAlign.Center, , "dd/MM/yyyy HH:mm")
         .Columns("UsuarioSeguimiento").FormatearColumna("Usuario Seg.", pos, 110).Header.ToolTipText = "Usuario Seguimiento"
         .Columns("FechaSeguimiento").FormatearColumna("Fecha Seg.", pos, 100, HAlign.Center, , "dd/MM/yyyy HH:mm").Header.ToolTipText = "Fecha Seguimiento"
         .Columns("Descripcion").FormatearColumna("Descripcion", pos, 180)
         .Columns("Comentario").FormatearColumna("Comentario", pos, 180)
         .Columns("Interlocutor").FormatearColumna("Interlocutor", pos, 70)
         .Columns("Cantidad").FormatearColumna("Horas", pos, 50, HAlign.Right)
      End With

      ugDetalle.AgregarFiltroEnLinea({"Descripcion", "Comentario"})

   End Sub

   Private Sub btnEnviarMail_Click(sender As Object, e As EventArgs) Handles btnEnviarMail.Click
      TryCatched(
      Sub()
         Dim imp = New CRMNovedadesImpresion(Novedad)
         Dim nombreArchivoExportado = imp.ExportarNovedad()
         Using ma = New MensajeMail()
            ma.ArchivoAAdjuntar = nombreArchivoExportado
            ma.txtDestinatarios.Text = DirectCast(cmbIdUsuarioAsignado.SelectedItem, Entidades.Usuario).CorreoElectronico
            ma.txtAsunto.Text = cmbTipoNovedad.Text + " - " + txtIdNovedad.Text + " - " + txtDescripcion.Text
            ma.chbCopiaASiMismo.Checked = False
            ma.ShowDialog(Me)
            ma.txtCuerpo.Focus()
         End Using
      End Sub)
   End Sub

   Private Sub bscNumeroPadre_BuscadorClick() Handles bscNumeroPadre.BuscadorClick
      Try
         Dim tipNov As String = Me.cmbTiposNovedadesPadre.SelectedValue.ToString()
         Dim oNovedad As Reglas.CRMNovedades = New Reglas.CRMNovedades()
         Me._publicos.PreparaGrillaCRMNovedades(Me.bscNumeroPadre, tipNov)

         Dim dt As DataTable

         dt = oNovedad.GetNovedadXTipo(Me.cmbTiposNovedadesPadre.SelectedValue.ToString(),
                                       Me.txtLetraPadre.Text,
                                       If(Not String.IsNullOrEmpty(Me.txtCentroEmisorPadre.Text), CShort(Me.txtCentroEmisorPadre.Text), 0S),
                                       If(Not String.IsNullOrEmpty(Me.bscNumeroPadre.Text), Convert.ToInt64(Me.bscNumeroPadre.Text), 0L))
         Me.bscNumeroPadre.Datos = dt
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

   Private Sub bscNumeroPadre_BuscadorSeleccion(sender As Object, e As Controles.BuscadorEventArgs) Handles bscNumeroPadre.BuscadorSeleccion
      Try
         If Not e.FilaDevuelta Is Nothing Then
            CargaDatosPadre(e.FilaDevuelta)
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
      End Try
   End Sub

   Private Sub CargaDatosPadre(dr As DataGridViewRow)
      Dim padre As Entidades.CRMNovedad = New Reglas.CRMNovedades().GetUno(dr.Cells("IdTipoNovedad").Value.ToString(),
                                                                           dr.Cells("Letra").Value.ToString(),
                                                                           Short.Parse(dr.Cells("CentroEmisor").Value.ToString()),
                                                                           Long.Parse(dr.Cells("IdNovedad").Value.ToString()),
                                                                           Reglas.Base.AccionesSiNoExisteRegistro.Excepcion)

      Me.bscNumeroPadre.Text = padre.IdNovedad.ToString()
      Me.txtLetraPadre.Text = padre.Letra
      Me.txtCentroEmisorPadre.Text = padre.CentroEmisor.ToString()
      Me.txtDescripcionPadre.Text = padre.Descripcion
      Novedad.IdTipoNovedadPadre = padre.IdTipoNovedad
      Novedad.LetraPadre = padre.Letra
      Novedad.CentroEmisorPadre = padre.CentroEmisor
      Novedad.IdNovedadPadre = padre.IdNovedad

      MuestraControlesDinamicos(padre, copiando:=True)
      If String.IsNullOrWhiteSpace(txtDescripcion.Text) Then
         txtDescripcion.Text = padre.Descripcion
      End If

      '# Seteo de Combos
      If String.IsNullOrWhiteSpace(cmbInterlocutor.Text) Then
         cmbInterlocutor.Text = padre.Interlocutor
      End If

      If String.IsNullOrWhiteSpace(txtEtiquetaNovedad.Text) Then
         txtEtiquetaNovedad.Text = padre.EtiquetaNovedad
         'Novedad.EtiquetaNovedad = padre.EtiquetaNovedad
      End If

      '################################################################################################################################
      '# Si existe un medio/prioridad/categoria/estado con el mismo nombre de mi medio/prioridad/categoria/estado anterior, lo seteo. #
      '################################################################################################################################

      If _novedadCopia IsNot Nothing Then
         '# Combo Medio
         Dim medio = DirectCast(cmbMedio.DataSource, List(Of Entidades.CRMMedioComunicacionNovedad)).FirstOrDefault(Function(x) x.NombreMedioComunicacionNovedad = padre.MedioComunicacionNovedad.NombreMedioComunicacionNovedad)
         If medio IsNot Nothing Then
            cmbMedio.SelectedValue = medio.IdMedioComunicacionNovedad
         End If

         '# Combo Prioridad
         Dim prioridad = DirectCast(cmbPrioridadNovedad.DataSource, List(Of Entidades.CRMPrioridadNovedad)).FirstOrDefault(Function(x) x.NombrePrioridadNovedad = padre.PrioridadNovedad.NombrePrioridadNovedad)
         If prioridad IsNot Nothing Then
            cmbPrioridadNovedad.SelectedValue = prioridad.IdPrioridadNovedad
         End If

         '# Combo Estado
         'Dim estado = DirectCast(cmbEstadoNovedad.DataSource, List(Of Entidades.CRMEstadoNovedad)).FirstOrDefault(Function(x) x.NombreEstadoNovedad = padre.EstadoNovedad.NombreEstadoNovedad)
         Dim estado = DirectCast(cmbEstadoNovedad.DataSource, List(Of Entidades.CRMEstadoNovedad)).FirstOrDefault(Function(x) x.IdEstadoNovedad = padre.EstadoNovedad.IdEstadoNovedad)
         If estado IsNot Nothing Then
            cmbEstadoNovedad.SelectedValue = estado.IdEstadoNovedad
         End If

         '# Combo Categoria
         Dim categoria = DirectCast(cmbCategoriaNovedad.DataSource, List(Of Entidades.CRMCategoriaNovedad)).FirstOrDefault(Function(x) x.NombreCategoriaNovedad = padre.CategoriaNovedad.NombreCategoriaNovedad)
         If categoria IsNot Nothing Then
            cmbCategoriaNovedad.SelectedValue = categoria.IdCategoriaNovedad
         End If

         Me.chbPriorizado.Checked = _novedadCopia.Priorizado
         Me.chbRequiereTesteo.Checked = _novedadCopia.RequiereTesteo
      End If

      CargaNovedadesRelacionadas()

      If _copiarComentarios Then
         Dim rSeguimiento = New Reglas.CRMNovedadesSeguimientoAdjuntos()
         For Each seg In _novedadCopia.Seguimientos.Where(Function(x) x.EsComentario And x.Activo).OrderBy(Function(x) x.IdSeguimiento).ToArray()
            Dim adjunto = rSeguimiento.GetUno(seg.IdTipoNovedad, seg.Letra, seg.CentroEmisor, seg.IdNovedad, seg.IdSeguimiento, seg.IdUnico, incluirFoto:=True)

            Dim idTipoComentario = 0I 'Entidades.CRMTipoComentarioNovedad
            Dim tipoComentario As Entidades.CRMTipoComentarioNovedad
            If TipoNovedad IsNot Nothing AndAlso padre.IdTipoNovedad = Novedad.IdTipoNovedad AndAlso seg.IdTipoComentarioNovedad.HasValue Then
               idTipoComentario = seg.IdTipoComentarioNovedad.Value
            End If
            If idTipoComentario = 0 Then
               'No tengo el nombre en el origen. Ver si lo ponemos para buscar por nombre si son diferente tableros pero tienen los mismos tipos
               'tipoComentario = DirectCast(cmbNuevoIdTipoComentarioNovedad.DataSource, List(Of Entidades.CRMTipoComentarioNovedad)).FirstOrDefault(Function(x) x.NombreTipoComentarioNovedad = seg.NombreTipoComentarioNovedad)
            End If
            If idTipoComentario = 0 Then
               tipoComentario = DirectCast(cmbNuevoIdTipoComentarioNovedad.DataSource, List(Of Entidades.CRMTipoComentarioNovedad)).FirstOrDefault(Function(x) x.PorDefecto)
               idTipoComentario = If(tipoComentario Is Nothing, 0, tipoComentario.IdTipoComentarioNovedad)
            End If
            If idTipoComentario = 0 Then
               Throw New Exception(String.Format("No se puede copiar comentarios porque el tipo de novedad destino ({0}) no tiene tipo de comentario Por Defecto", Novedad.TipoNovedad.NombreTipoNovedad))
            End If

            Novedad.Seguimientos.Add(New Entidades.CRMNovedadSeguimiento(Nothing, seg.FechaSeguimiento, seg.Comentario, seg.Interlocutor, seg.EsComentario, idTipoComentario,
                                                                         cmbEstadoNovedad.ItemSeleccionado(Of Entidades.CRMEstadoNovedad), adjunto))
         Next
         MostrarSeguimiento()
      End If

      If _novedadCopia IsNot Nothing AndAlso padre.IdTipoNovedad = TipoNovedad.IdTipoNovedad Then
         If String.IsNullOrWhiteSpace(padre.IdTipoNovedadPadre) Then
            '# Si no tiene datos del padre, pero _novedadCopia tiene datos (lo que quiere decir que proviene de una novedad la cual es "huérfana", los datos del padre pasan a ser los del hermano)
            cmbTiposNovedadesPadre.SelectedValue = _novedadCopia.IdTipoNovedad
            Me.txtLetraPadre.Text = _novedadCopia.Letra
            Novedad.CentroEmisorPadre = padre.CentroEmisor
            bscNumeroPadre.Text = _novedadCopia.IdNovedad.ToString()
            Novedad.IdNovedadPadre = _novedadCopia.IdNovedad
            bscNumeroPadre.Selecciono = True
         Else
            cmbTiposNovedadesPadre.SelectedValue = padre.IdTipoNovedadPadre
            Me.txtLetraPadre.Text = padre.LetraPadre
            bscNumeroPadre.Text = padre.IdNovedadPadre.ToString()
            Novedad.IdNovedadPadre = padre.IdNovedadPadre
            Novedad.CentroEmisorPadre = padre.CentroEmisorPadre
            Me.txtDescripcionPadre.Text = padre.DescripcionPadre
            bscNumeroPadre.Selecciono = True
         End If
      End If

   End Sub

   Private Sub cmbTiposNovedadesPadre_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbTiposNovedadesPadre.SelectedIndexChanged
      If Not _OnLoad Then
         If Me.cmbTiposNovedadesPadre.SelectedIndex <> -1 Then
            Me.bscNumeroPadre.Enabled = True
         Else
            Me.bscNumeroPadre.Enabled = False
         End If
         Me.bscNumeroPadre.Text = "0"
         Me.bscNumeroPadre.Selecciono = False
      End If
   End Sub

   Private Sub cmbEstadoNovedad_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbEstadoNovedad.SelectedIndexChanged
      Try
         If cmbEstadoNovedad.SelectedIndex > -1 Then
            Dim actualmenteChecked As Boolean = dtpFechaProximoContacto.Checked
            Dim estadoCombo As Entidades.CRMEstadoNovedad = DirectCast(cmbEstadoNovedad.SelectedItem, Entidades.CRMEstadoNovedad)
            Dim dias As Integer = TipoNovedad.DiasProximoContacto
            If estadoCombo.DiasProximoContacto.HasValue Then
               dias = estadoCombo.DiasProximoContacto.Value
            End If
            If dias > 0 Then
               If dtpFechaEstadoNovedad.Checked Then
                  dtpFechaProximoContacto.Value = dtpFechaEstadoNovedad.Value.AddDays(dias)
               Else
                  dtpFechaProximoContacto.Value = Now.AddDays(dias)
               End If
            End If
            If Not Me.bscCodigoProveedor.Enabled Then
               Me.bscCodigoProveedor.Text = ""
               Me.bscProveedor.Text = ""
            End If
            dtpFechaProximoContacto.Checked = actualmenteChecked
         End If
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

   Private Sub chbNumeroAutomatico_CheckedChanged(sender As Object, e As EventArgs) Handles chbNumeroAutomatico.CheckedChanged
      txtIdNovedad.ReadOnly = chbNumeroAutomatico.Checked
   End Sub

   Private Sub btnCopiaTablero_Click(sender As Object, e As EventArgs) Handles btnCopiaTablero.Click
      Try
         If cmbTipoNovedadCopiaTablero.SelectedIndex > -1 Then
            Dim tipoNovedadCopia As Entidades.CRMTipoNovedad = DirectCast(cmbTipoNovedadCopiaTablero.SelectedItem, Entidades.CRMTipoNovedad)
            Using frmCopia As New CRMNovedadesDetalle(New Entidades.CRMNovedad(), tipoNovedadCopia, Novedad, chbCopiarComentarios.Checked)
               frmCopia.ShowDialog()
               CargaNovedadesRelacionadas()
            End Using
         End If
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

   Protected Overrides Sub OnAfterAplicar()
      Novedad.FechaEstadoNovedad = Nothing
      _fechaEstadoAnterior = Nothing
      dtpFechaEstadoNovedad.Checked = False
      MostrarSeguimiento()
      MostrarCambiosEstados()
      txtComentarios.Text = Novedad.NuevoComentario
      txtNombreAdjunto.Text = Novedad.NuevoAdjunto
      txtIdNovedad.Text = Novedad.IdNovedad.ToString()
      MostrarNovedadesProductos(cargando:=False)
      btnCopiaTablero.Enabled = True
      tstBarra.Enabled = True
      lblIdNovedad.Text = lblIdNovedad.Text.Replace("(posible)", "")
      MyBase.OnAfterAplicar()
   End Sub

   Private Sub ugNovedadesRelacionadas_DoubleClickRow(sender As Object, e As DoubleClickRowEventArgs) Handles ugNovedadesRelacionadas.DoubleClickRow
      Try
         Dim dr = ugNovedadesRelacionadas.FilaSeleccionada(Of DataRow)()
         If dr IsNot Nothing Then
            Dim novedad As Entidades.CRMNovedad
            novedad = New Reglas.CRMNovedades().GetUno(dr(Entidades.CRMNovedad.Columnas.IdTipoNovedad.ToString()).ToString(),
                                                       dr(Entidades.CRMNovedad.Columnas.Letra.ToString()).ToString(),
                                                       Short.Parse(dr(Entidades.CRMNovedad.Columnas.CentroEmisor.ToString()).ToString()),
                                                       Long.Parse(dr(Entidades.CRMNovedad.Columnas.IdNovedad.ToString()).ToString()),
                                                       Reglas.Base.AccionesSiNoExisteRegistro.Excepcion)
            Using frm = New CRMNovedadesDetalle(novedad, novedad.TipoNovedad)
               frm.StateForm = StateForm.Actualizar
               frm.ShowDialog()
               CargaNovedadesRelacionadas()
            End Using
         End If
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub


   Private Sub CargarProductoPrestado(dr As DataGridViewRow)
      bscCodigoProductoPrestado2.Text = dr.Cells("IdProducto").Value.ToString.Trim()
      bscProductoPrestado2.Text = dr.Cells("NombreProducto").Value.ToString()
   End Sub

   Private Sub CargarDatosProveedor(dr As DataGridViewRow)

      bscProveedor.Text = dr.Cells("NombreProveedor").Value.ToString()
      bscCodigoProveedor.Text = dr.Cells("CodigoProveedor").Value.ToString()
      bscCodigoProveedor.Tag = dr.Cells("IdProveedor").Value.ToString

      bscProveedor.Selecciono = True

      EnableFechasEnvioRetiroProveedor()
   End Sub

   Private Sub CargarDatosProveedorGarantia(dr As DataGridViewRow)

      bscProveedorGarantia.Text = dr.Cells("NombreProveedor").Value.ToString()
      bscCodigoProveedorGarantia.Text = dr.Cells("CodigoProveedor").Value.ToString()
      bscCodigoProveedorGarantia.Tag = dr.Cells("IdProveedor").Value.ToString

   End Sub

   Private Sub tsbImprimirComprobante_Click(sender As Object, e As EventArgs) Handles tsbImprimirComprobante.Click
      Try
         Dim rNovedadImprimir As Reglas.CRMNovedades = New Reglas.CRMNovedades()
         Dim novedadImprimir As Entidades.CRMNovedad = rNovedadImprimir.GetUno(Novedad.TipoNovedad.IdTipoNovedad, Novedad.Letra,
                                                                  Novedad.CentroEmisor, Novedad.IdNovedad)

         Cursor = Cursors.WaitCursor
         Dim rNovedadesImpresion As CRMNovedadesImpresion = New CRMNovedadesImpresion(novedadImprimir)
         rNovedadesImpresion.ImprimirNovedad()

      Catch ex As Exception
         ShowError(ex)
      Finally
         Cursor = Cursors.Default
      End Try
   End Sub


   Private Sub chbVersion_CheckedChanged(sender As Object, e As EventArgs) Handles chbVersion.CheckedChanged
      Try
         Me.cmbVersion.Enabled = Me.chbVersion.Checked
         If Not Me.chbVersion.Checked Then
            Me.cmbVersion.SelectedIndex = -1
         Else
            If Me.cmbVersion.Items.Count > 0 Then
               Me.cmbVersion.SelectedIndex = -1
            End If
         End If
         Me.cmbVersion.Focus()
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

   Private Sub cmbVersion_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbVersion.SelectedIndexChanged
      If _cargandoVersiones Then Exit Sub
      If Me.chbVersion.Checked Then
         If cmbVersion.SelectedIndex > -1 Then
            txtVersion.Text = cmbVersion.SelectedValue.ToString()
            dtpVersionFecha.Checked = True
            Dim rVersion As Reglas.Versiones = New Reglas.Versiones()
            Dim obj As Object = ObtenerValorControlesDinamicos("SISTEMAS")
            Dim entidad As Entidades.Version = rVersion.GetUno(obj.ToString(), cmbVersion.SelectedValue.ToString(), Reglas.Base.AccionesSiNoExisteRegistro.Nulo)
            If entidad IsNot Nothing Then
               dtpVersionFecha.Value = entidad.VersionFecha
            End If

         End If
      End If
   End Sub

   Private Sub cmbTipoComentarioNovedadEditor_InitializeDataItem(sender As Object, e As InitializeDataItemEventArgs) Handles cmbTipoComentarioNovedadEditor.InitializeDataItem
      Try
         Dim tipo As Entidades.CRMTipoComentarioNovedad = DirectCast(e.ValueListItem.ListObject, Entidades.CRMTipoComentarioNovedad)
         If tipo.Color.HasValue Then
            e.ValueListItem.Appearance.BackColor = Color.FromArgb(tipo.Color.Value)
         Else
            e.ValueListItem.Appearance.BackColor = Nothing
         End If

      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

   Private Sub ugSeguimiento_CellChange(sender As Object, e As CellEventArgs) Handles ugSeguimiento.CellChange
      TryCatched(
      Sub()
         ugSeguimiento.UpdateData()
         Dim dr = e.Cell.Row.FilaSeleccionada(Of Entidades.CRMNovedadSeguimiento)
         Novedad.Seguimientos.Where(Function(s) Not s.Equals(dr)).ToList().ForEach(Sub(s) s.ComentarioPrincipal = False)
         ugSeguimiento.Rows.Refresh(RefreshRow.ReloadData)
      End Sub)
   End Sub

   Private Sub dtpCantidad_ValueChanged(sender As Object, e As EventArgs) Handles dtpCantidad.ValueChanged
      TryCatched(Sub() txtCantidad.Text = ToHoraDecimal(dtpCantidad).ToString("N2"))
   End Sub

   Private Sub lblCantidad_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lblCantidad.LinkClicked
      TryCatched(
         Sub()
            txtCantidad.Visible = Not txtCantidad.Visible
            dtpCantidad.Visible = Not dtpCantidad.Visible
            If dtpCantidad.Visible Then
               dtpCantidad.Value = FromHoraDecimal(txtCantidad) ' Today.AddHours(txtCantidad.ValorNumericoPorDefecto(0D))
            Else
               txtCantidad.Text = ToHoraDecimal(dtpCantidad).ToString("N2")
            End If
         End Sub)
   End Sub

   Private Function FromHoraDecimal(txt As TextBox) As DateTime
      Return FromHoraDecimal(txt.ValorNumericoPorDefecto(0D))
   End Function
   Private Function FromHoraDecimal(hora As Decimal) As DateTime
      Return DateTime.Today.AddHours(Math.Truncate(hora)).AddMinutes(Math.Truncate((hora - Math.Truncate(hora)) * 60))
   End Function

   Private Function ToHoraDecimal(dtp As DateTimePicker) As Decimal
      Return Convert.ToDecimal(dtp.Value.TimeOfDay.TotalHours)
   End Function
   Private Function ToHoraDecimal(fechaHora As DateTime) As Decimal
      Return Convert.ToDecimal(fechaHora.TimeOfDay.TotalHours)
   End Function
   Private Function ToHoraDecimal(hora As TimeSpan) As Decimal
      Return Convert.ToDecimal(hora.TotalHours)
   End Function


   Private Sub tsbImprimirComprobanteEnOtroEstado_Click(sender As Object, e As EventArgs) Handles tsbImprimirCRMEnOtroEstado.Click
      TryCatched(
         Sub()
            '# Abro la pantalla para que el usuario pueda seleccionar en qué estado quiere imprimir el reporte.
            Cursor = Cursors.WaitCursor
            Using frm = New ImprimirCRMEnOtroEstado(Novedad.TipoNovedad.IdTipoNovedad)

               '# Si el usuario seleccionó un nuevo estado, modifico el estado anterior de la Novedad por el nuevo. 
               If (frm.ShowDialog()) = Windows.Forms.DialogResult.OK Then
                  If frm.EstadoSeleccionado IsNot Nothing Then Novedad.EstadoNovedad = frm.EstadoSeleccionado

                  Dim rNovedadesImpresion As CRMNovedadesImpresion = New CRMNovedadesImpresion(Novedad)
                  rNovedadesImpresion.ImprimirNovedad()
               End If
            End Using
         End Sub)
   End Sub

   Private Sub tsbFacturar_Click(sender As Object, e As EventArgs) Handles tsbFacturar.Click
      TryCatched(
         Sub()
            '# Valido que el estado seleccionado sea facturable
            If cmbEstadoNovedad.ItemSeleccionado(Of Entidades.CRMEstadoNovedad).EsFacturable Then
               Dim rNovedadAnticipo As Reglas.CRMNovedades = New Reglas.CRMNovedades()
               Dim eNovedadAnticipo As Entidades.CRMNovedad = rNovedadAnticipo.GetUno(Novedad.TipoNovedad.IdTipoNovedad, Novedad.Letra,
                                                                             Novedad.CentroEmisor, Novedad.IdNovedad)
               If eNovedadAnticipo.IdSucursalFact.HasValue AndAlso eNovedadAnticipo.IdSucursalFact.Value > 0 Then '# Asumo que si tiene la sucursal, está facturado
                  Throw New Exception(String.Format("ATENCIÓN: Este servicio ya fué facturado con el comprobante {0} {1} {2:0000}-{3:00000000}",
                                                       eNovedadAnticipo.IdTipoComprobanteFact,
                                                       eNovedadAnticipo.LetraFact,
                                                       eNovedadAnticipo.CentroEmisorFact,
                                                       eNovedadAnticipo.NumeroComprobanteFact))
               End If


               If Not Novedad.ProductosNovedad.Any(Function(pn) Not pn.StockConsumidoProducto) Then
                  If Reglas.Publicos.CRMNovedadesFormaDePago < 1 Then
                     Throw New Exception("No se configuró la forma de pagos para facturar. Parametros de Sistemas -> RMA")
                  End If
                  Dim venta = New Reglas.CRMNovedades().ConvertirNovedadEnVenta(Novedad, New Reglas.BusquedasCacheadas())
                  If Reglas.Publicos.CRMNovedadesCopiarSaldoComoEfectivoAlFacturar Then
                     venta.ImportePesos = txtCostoReparacion.ValorNumericoPorDefecto(0D) - txtAnticioReparacion.ValorNumericoPorDefecto(0D)
                  End If
                  Using frm As New FacturacionV2()
                     frm.IdFuncion = IdFuncion
                     frm.InvocarDesdeCajero(venta, idTipoComprobanteGenerar:=String.Empty, soloCopia:=True)
                     frm.ShowInTaskbar = False
                     If frm.ShowDialog(Me) = Windows.Forms.DialogResult.OK Then

                     End If
                  End Using
               Else
                  Throw New Exception("ATENCIÓN: Existen productos que aún no se consumió el stock. Debe consumir el stock antes de facturar el Servicio.")
               End If
            Else
               Throw New Exception(String.Format("ATENCIÓN: El estado seleccionado ({0}) NO es facturable.", cmbEstadoNovedad.Text))
            End If
         End Sub)
   End Sub
   '------------------------------------------------------------------------------------------------------------------------------------------
   Private Sub bscCodigoProveedorGarantia_BuscadorClick() Handles bscCodigoProveedorGarantia.BuscadorClick
      TryCatched(
         Sub()
            Dim codigoProveedor = -1L
            _publicos.PreparaGrillaProveedores2(bscCodigoProveedorGarantia)
            Dim rProveedores = New Reglas.Proveedores()
            If bscCodigoProveedorGarantia.Text.Trim.Length > 0 Then
               codigoProveedor = Long.Parse(bscCodigoProveedorGarantia.Text.Trim())
            End If
            bscCodigoProveedorGarantia.Datos = rProveedores.GetFiltradoPorCodigo(codigoProveedor)
         End Sub)
   End Sub
   Private Sub bscCodigoProveedorGarantia_BuscadorSeleccion(sender As Object, e As Controles.BuscadorEventArgs) Handles bscCodigoProveedorGarantia.BuscadorSeleccion
      Try
         If Not e.FilaDevuelta Is Nothing Then
            CargarDatosProveedorGarantia(e.FilaDevuelta)
         End If
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

   Private Sub bscProveedorGarantia_BuscadorClick() Handles bscProveedorGarantia.BuscadorClick
      Try
         Me._publicos.PreparaGrillaProveedores2(bscProveedorGarantia)
         Dim oProveedores = New Reglas.Proveedores
         bscProveedorGarantia.Datos = oProveedores.GetFiltradoPorNombre(bscProveedorGarantia.Text.Trim())
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

   Private Sub bscProveedorGarantia_BuscadorSeleccion(sender As Object, e As Controles.BuscadorEventArgs) Handles bscProveedorGarantia.BuscadorSeleccion
      Try
         If Not e.FilaDevuelta Is Nothing Then
            CargarDatosProveedorGarantia(e.FilaDevuelta)
         End If
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

   '------------------------------------------------------------------------------------------------------------------------------------------
   '-- REQ-31756/31871/31988 - Carga Domicilios de Entrega-Retiro - Proveedor Garantia.- --
   '-- REQ-31988.- --
   Private Sub chbTieneGarantiaService_CheckedChanged(sender As Object, e As EventArgs) Handles chbTieneGarantiaService.CheckedChanged
      '-- Sincroniza Panel de En Garantia.- --
      pnlEnGarantia.Enabled = chbTieneGarantiaService.Checked
      '-- Inicilializa Combo de Domiclios Retiros.- --
      If Not chbTieneGarantiaService.Checked Then
         bscProveedorGarantia.Text = ""
         bscCodigoProveedorGarantia.Text = ""
         bscCodigoProveedorGarantia.Tag = ""
         '   '-- REQ-32981.- --------------------------------------------
         '   dtpEnvioProveedor.Enabled = False
         '   dtpEnvioProveedor.Checked = False
         '   dtpRetiroProveedor.Enabled = False
         '   dtpRetiroProveedor.Checked = False
         'Else
         '   dtpEnvioProveedor.Enabled = True
         '   dtpRetiroProveedor.Enabled = True
         '   '-----------------------------------------------------------
      End If
   End Sub
   '-- REQ-31756.- --
   Private Sub chbRetiros_CheckedChanged(sender As Object, e As EventArgs) Handles chbRetiros.CheckedChanged
      '-- Sincroniza Panel de Retiros.- --
      pnlRetiros.Enabled = chbRetiros.Checked
      '-- Inicilializa Combo de Domiclios Retiros.- --
      If Not chbRetiros.Checked Then
         cmbDomicilioRetiro.SelectedIndex = -1
      End If
   End Sub
   '-- REQ-31871.- --
   Private Sub chbEntregas_CheckedChanged(sender As Object, e As EventArgs) Handles chbEntregas.CheckedChanged
      '-- Sincroniza Panel de Entregas.- --
      pnlEntregas.Enabled = chbEntregas.Checked
      '-- Inicilializa Combo de Domiclios Retiros.- --
      If Not chbEntregas.Checked Then
         cmbDomicilioEntrega.SelectedIndex = -1
      End If
   End Sub
   '------------------------------------------------------------------------------------------------------------------------------------------
   '-- REG-31710.- --
   Private Function CalculaSaldo() As Decimal
      Return txtCostoReparacion.ValorNumericoPorDefecto(0D) - txtAnticioReparacion.ValorNumericoPorDefecto(0D)
   End Function

   Private Sub txtCostoReparacion_Leave(sender As Object, e As EventArgs) Handles txtCostoReparacion.Leave
      txtSaldoReparacion.Text = CalculaSaldo().ToString("N2")
   End Sub


   Private Sub bscProveedor_Leave(sender As Object, e As EventArgs) Handles bscProveedor.Leave, bscCodigoProveedor.Leave
      TryCatched(Sub() EnableFechasEnvioRetiroProveedor())
   End Sub


   Private Sub EnableFechasEnvioRetiroProveedor()
      '-- REQ-31990.- --------------------------------------------------
      dtpRetiroProveedor.Enabled = bscProveedor.Selecciono Or bscCodigoProveedor.Selecciono
      dtpRetiroProveedor.Checked = False
      dtpEnvioProveedor.Enabled = dtpRetiroProveedor.Enabled
      dtpEnvioProveedor.Checked = False
      '-----------------------------------------------------------------
   End Sub

   Private Sub tsbCobrar_Click(sender As Object, e As EventArgs) Handles tsbCobrar.Click
      Try
         '-- Define Variable de Novedad
         Using frm = New Recibos(Novedad)
            frm.IdFuncion = IdFuncion
            frm.ShowInTaskbar = False
            frm.ShowDialog()
         End Using
         '-- Refresca el Valor de anticipo.- --
         RefrescaAnticipo()
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

   Private Sub RefrescaAnticipo()
      Dim rNovedadAnticipo As Reglas.CRMNovedades = New Reglas.CRMNovedades()
      Dim eNovedadAnticipo As Entidades.CRMNovedad = rNovedadAnticipo.GetUno(Novedad.TipoNovedad.IdTipoNovedad, Novedad.Letra,
                                                                             Novedad.CentroEmisor, Novedad.IdNovedad)
      If eNovedadAnticipo IsNot Nothing Then
         txtAnticioReparacion.Text = eNovedadAnticipo.AnticipoNovedad.ToString("N2")
         txtSaldoReparacion.Text = CalculaSaldo().ToString("N2")
      End If
   End Sub

#Region "Requerimiento - 31709.- --"
   '-- REQ-31709.- ------------------------------------------------------------------------------------------------------
   Private Sub bscCodigoProductoServ_BuscadorSeleccion(sender As Object, e As Controles.BuscadorEventArgs) Handles bscCodigoProductoServ.BuscadorSeleccion
      Try
         If e.FilaDevuelta IsNot Nothing Then
            'If Boolean.Parse(e.FilaDevuelta.Cells("Lote").Value.ToString()) Then
            '   LimpiarCamposProductos()
            '   Throw New Exception(ResuelveMensaje("Lote", e))
            'End If

            'If Boolean.Parse(e.FilaDevuelta.Cells("NroSerie").Value.ToString()) Then
            '   LimpiarCamposProductos()
            '   Throw New Exception(ResuelveMensaje("Nro Serie", e))
            'End If

            '-- Producto Habilitado para Operar.- --
            CargarProducto(e.FilaDevuelta)
            '-- Calcula el precio.- --
            txtCantidadServiceProducto.Text = "1." + New String("0"c, _decimalesMostrarCantidad)
            txtCantidadServiceProducto.Focus()
            txtCantidadServiceProducto.SelectAll()
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub
   Private Sub bscCodigoProductoServ_BuscadorClick() Handles bscCodigoProductoServ.BuscadorClick
      Dim rProductos = New Eniac.Reglas.Productos
      Dim codProd As String = bscCodigoProductoServ.Text.Trim()
      Dim dt As DataTable

      Try
         _publicos.PreparaGrillaProductos2(Me.bscCodigoProductoServ)
         dt = rProductos.GetPorCodigo(codProd, actual.Sucursal.Id, Reglas.Publicos.CRMListaPrecioFacturar, "VENTAS", , , , Entidades.Producto.TiposOperaciones.NORMAL, , , , , Novedad.IdCliente, soloBuscaPorIdProducto:=True)
         '-- Carga Datos.- --
         bscCodigoProductoServ.Datos = dt
      Catch ex As Exception
         MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try

   End Sub
   '---------------------------------------------------------------------------------------------------------------------
   Private Sub bscNombreProductoServ_BuscadorSeleccion(sender As Object, e As Controles.BuscadorEventArgs) Handles bscNombreProductoServ.BuscadorSeleccion
      Try
         If e.FilaDevuelta IsNot Nothing Then
            'If Boolean.Parse(e.FilaDevuelta.Cells("Lote").Value.ToString()) Then
            '   LimpiarCamposProductos()
            '   Throw New Exception(ResuelveMensaje("Lote", e))
            'End If

            'If Boolean.Parse(e.FilaDevuelta.Cells("NroSerie").Value.ToString()) Then
            '   LimpiarCamposProductos()
            '   Throw New Exception(ResuelveMensaje("Nro Serie", e))
            'End If
            '-- Producto Habilitado para Operar.- --
            CargarProducto(e.FilaDevuelta)
            '-- Calcula el precio.- --
            txtCantidadServiceProducto.Text = "1." + New String("0"c, _decimalesMostrarCantidad)
            txtCantidadServiceProducto.Focus()
            txtCantidadServiceProducto.SelectAll()
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub
   Private Sub bscNombreProductoServ_BuscadorClick() Handles bscNombreProductoServ.BuscadorClick
      Try
         Dim oProductos As Reglas.Productos = New Reglas.Productos
         _publicos.PreparaGrillaProductos2(bscNombreProductoServ)
         bscNombreProductoServ.Datos = oProductos.GetPorNombre(bscNombreProductoServ.Text.Trim(), actual.Sucursal.Id, Reglas.Publicos.CRMListaPrecioFacturar, "VENTAS", , , Entidades.Producto.TiposOperaciones.NORMAL, , , , , Novedad.IdCliente)
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

   Private Function ResuelveMensaje(oTipo As String, e As Controles.BuscadorEventArgs) As String
      Return String.Format("Producto {0} - {1} utiliza {2} {3}No se puede utilizar en {4}",
                                                 e.FilaDevuelta.Cells("IdProducto").Value.ToString().Trim(),
                                                 e.FilaDevuelta.Cells("NombreProducto").Value.ToString().Trim(),
                                                 oTipo,
                                                 Environment.NewLine,
                                                 TipoNovedad.NombreTipoNovedad)
   End Function
   Private Sub CargarProducto(dr As DataGridViewRow)
      '-- Cargar los datos del Producto.- --
      bscCodigoProductoServ.Text = dr.Cells("IdProducto").Value.ToString.Trim()
      bscNombreProductoServ.Text = dr.Cells("NombreProducto").Value.ToString()
      '-- Carga el precio con IVA.- --
      txtPrecioServiceProducto.Text = Decimal.Parse(dr.Cells("PrecioVentaConIVA").Value.ToString()).ToString("N2")
      txtImporteServiceProducto.Text = Decimal.Parse(dr.Cells("PrecioVentaConIVA").Value.ToString()).ToString("N2")
      '-- Actualiza Observaciones Producto Modificable.- --
      With txtProductoObservacion
         .Text = bscNombreProductoServ.Text
         .MaxLength = Integer.Parse(bscNombreProductoServ.MaxLengh)
         .Visible = Reglas.Publicos.Facturacion.FacturacionModificaDescripcionProducto And Boolean.Parse(dr.Cells("PermiteModificarDescripcion").Value.ToString())
      End With

      cmbDepositoOrigen.Enabled = True
      cmbDepositoOrigen.SelectedValue = Integer.Parse(dr.Cells("IdDepositoDefecto").Value.ToString.Trim())
      If cmbDepositoOrigen.SelectedIndex <> -1 Then
         cmbUbicacionOrigen.Enabled = True
         cmbUbicacionOrigen.SelectedValue = Integer.Parse(dr.Cells("IdUbicacionDefecto").Value.ToString.Trim())
      Else
         'ShowMessage("El usuario carece de permisos para el Depósito por Defecto del Producto. Se asume proximo depósito autorizado.")
         cmbDepositoOrigen.SelectedIndex = 0
      End If

      ''***************LOTE 
      'Me._productoLoteTemporal = New Entidades.VentaProductoLote()
      'Me._productoLoteTemporal.Producto = New Reglas.Productos().GetUno(dr.Cells("IdProducto").Value.ToString().Trim())
      '_nrosSerieSeleccionados = ventaProducto.Producto.NrosSeries
      ''# Reconstruyo los lotes seleccionados dentro del producto que se está editando
      'Me.CargarLotesPreviamenteSeleccionados(ventaProducto)

   End Sub
   '---------------------------------------------------------------------------------------------------------------------
   Private Sub btnLimpiarProductos_Click(sender As Object, e As EventArgs) Handles btnLimpiarProductos.Click
      If bscCodigoProductoServ.Enabled Then
         LimpiarCamposProductos()
         If Reglas.Publicos.Facturacion.FacturacionPermitePosicionarNombreProducto Then
            bscNombreProductoServ.Focus()
         Else
            bscCodigoProductoServ.Focus()
         End If
      End If
   End Sub

   Private Sub txtServiceProducto_GotFocus(sender As Object, e As EventArgs) Handles txtPrecioServiceProducto.GotFocus, txtCantidadServiceProducto.GotFocus
      txtImporteServiceProducto.SelectAll()
      txtCantidadServiceProducto.SelectAll()
   End Sub
   Private Sub txtServiceProducto_KeyDown(sender As Object, e As KeyEventArgs) Handles txtPrecioServiceProducto.KeyDown, txtCantidadServiceProducto.KeyDown
      If e.KeyCode = Keys.Enter Then
         txtCantidadServiceProducto.ValorNumericoPorDefecto(2D)
         txtPrecioServiceProducto.ValorNumericoPorDefecto(2D)
         txtImporteServiceProducto.Text = CalculaImporteServicioProducto().ToString("N2")
         btnInsertarProducto.Focus()
      End If
   End Sub
   '-- Botones de Insercion-Eliminacion.- ------------------------------------------------------------------------------------------
   Private Sub btnInsertarProducto_Click(sender As Object, e As EventArgs) Handles btnInsertarProducto.Click
      Try
         Dim _ProductoNovedad = New Entidades.CRMNovedadProducto
         Novedad.AjustarStock = Entidades.Publicos.AjustaStock.RESERVAR

         If Not String.IsNullOrWhiteSpace(bscCodigoProductoServ.Text) Then
            '-- Agrega los datos del Producto.- --
            _ProductoNovedad.IdProducto = bscCodigoProductoServ.Text
            '-- Valida el nombre del producto.- --
            If txtProductoObservacion.Visible Then
               _ProductoNovedad.NombreProducto = txtProductoObservacion.Text
            Else
               _ProductoNovedad.NombreProducto = bscNombreProductoServ.Text
            End If
            '-- Valida la sucursal de la Novedad.- --
            _ProductoNovedad.IdSucursalNovedad = Novedad.IdSucursalNovedad
            If bscCodigoProductoServ.Tag Is Nothing Then
               If Novedad.ProductosNovedad.Count > 0 Then
                  _ProductoNovedad.OrdenProducto = Novedad.ProductosNovedad.Max(Function(x) x.OrdenProducto) + 1
               Else
                  _ProductoNovedad.OrdenProducto = 1
               End If
               '_OrdenProductoService += 1
               '_ProductoNovedad.OrdenProducto = _OrdenProductoService
            Else
               _ProductoNovedad.OrdenProducto = Integer.Parse(bscCodigoProductoServ.Tag.ToString())
               bscCodigoProductoServ.Tag = Nothing
            End If
            _ProductoNovedad.CantidadProducto = Decimal.Parse(txtCantidadServiceProducto.Text)
            _ProductoNovedad.PrecioProducto = Decimal.Parse(txtPrecioServiceProducto.Text)
            _ProductoNovedad.ImporteNovedad = (_ProductoNovedad.CantidadProducto * _ProductoNovedad.PrecioProducto)
            _ProductoNovedad.IdListaPrecios = Reglas.Publicos.CRMListaPrecioFacturar
            _ProductoNovedad.StockConsumidoProducto = False
            _ProductoNovedad.IdSucursalActual = actual.Sucursal.Id

            If Reglas.Publicos.CRMNovedadesDepositoReserva = 0 Then Throw New Exception("No está configurado el Depósito para Reserva. Parámetros del Sistema -> RMA -> Depósito de Reserva de Mercaderia")
            If Reglas.Publicos.CRMNovedadesUbicacionReserva = 0 Then Throw New Exception("No está configurado la Ubicación para Reserva. Parámetros del Sistema -> RMA -> Depósito de Reserva de Mercaderia")

            _ProductoNovedad.IdDepositoActual = Reglas.Publicos.CRMNovedadesDepositoReserva
            _ProductoNovedad.IdUbicacionActual = Reglas.Publicos.CRMNovedadesUbicacionReserva
            _ProductoNovedad.IdsucursalAnterior = actual.Sucursal.Id
            _ProductoNovedad.IdDepositoAnterior = Integer.Parse(cmbDepositoOrigen.SelectedValue.ToString())
            _ProductoNovedad.IdUbicacionAnterior = Integer.Parse(cmbUbicacionOrigen.SelectedValue.ToString())
            _ProductoNovedad.StockReservadoProducto = False

            '--------------------------------------------------------------------------------
            '###############################
            '#          Lotes              #
            '###############################

            'Dim coeficienteStockParaLote As Integer = DirectCast(Me.cmbTiposComprobantes.SelectedItem, Entidades.TipoComprobante).CoeficienteStock

            '   If coeficienteStockParaLote = 0 And
            'Not String.IsNullOrWhiteSpace(DirectCast(Me.cmbTiposComprobantes.SelectedItem, Entidades.TipoComprobante).IdTipoComprobanteSecundario) Then
            '      Dim tipoSecundario As Entidades.TipoComprobante
            '      tipoSecundario = New Reglas.TiposComprobantes().GetUno(DirectCast(Me.cmbTiposComprobantes.SelectedItem, Entidades.TipoComprobante).IdTipoComprobanteSecundario)
            '      coeficienteStockParaLote = tipoSecundario.CoeficienteStock
            '   End If

            Dim _productoTemporal As Entidades.Producto = New Reglas.Productos().GetUno(_ProductoNovedad.IdProducto)
            If _productoTemporal.Lote Then

               If Not Reglas.Publicos.Facturacion.FacturacionSeleccionManualLoteProducto Then
                  MessageBox.Show("Servicio Técnico no admite selección automática de Lote, Configure en Parametros del Sistema la Selección Manual.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                  Exit Sub
               End If

               'Si es NCRE , valido fechas.. sino.. que exista
               'If coeficienteStockParaLote > 0 Then
               '   '_productoLoteTemporal.Producto.IdSucursal = actual.Sucursal.Id
               '   producto.IdSucursal = actual.Sucursal.Id
               '   Using frm As New SeleccionNrosLotes(producto, cmbDepositoOrigen.ValorSeleccionado(Of Integer), cmbUbicacionOrigen.ValorSeleccionado(Of Integer), CDec(Me.txtCantidad.Text), coeficienteStockParaLote, _numeroOrden)
               '      If frm.ShowDialog() = Windows.Forms.DialogResult.Cancel Then
               '         Throw New Exception("Si el producto esta marcado que utiliza Lote tiene que ingresar uno en la Venta.")
               '      Else
               '         '# Me guardo los lotes seleccionados
               '         _lotesSeleccionados = frm._lotesSeleccionados
               '         Me.CargarLotesSeleccionados(_lotesSeleccionados, oLineaDetalle, producto)
               '      End If
               '   End Using
               '    Else

               '# Si el comprobante facturable no afecta stock, los nros de lotes no fueron solicitados, por lo que se le solicitan al usuario.
               '# Selección Automática
               Dim DispProdLotes As Decimal = New Reglas.ProductosLotes().GetDisponiblePorProducto(actual.Sucursal.Id, Me.bscCodigoProductoServ.Text)
               If DispProdLotes = 0 Then
                  Throw New Exception("No existen Lotes para el Producto seleccionado.")
               End If
               If DispProdLotes < CDec(Me.txtCantidadServiceProducto.Text) Then
                  Throw New Exception("El Producto tiene en Stock " & DispProdLotes.ToString() & " quedaría en Cantidad Negativa, No es posible con Lotes.")
               End If

               '# Selección Manual
               ' If Reglas.Publicos.Facturacion.FacturacionSeleccionManualLoteProducto Then
               _productoTemporal.IdSucursal = actual.Sucursal.Id
                  Using frm As New SeleccionNrosLotes(_productoTemporal, cmbDepositoOrigen.ValorSeleccionado(Of Integer), cmbUbicacionOrigen.ValorSeleccionado(Of Integer), CDec(Me.txtCantidadServiceProducto.Text), -1, _lotesSeleccionados)
                     If frm.ShowDialog() = Windows.Forms.DialogResult.Cancel Then
                        Throw New Exception("Si el producto esta marcado que utiliza Lote tiene que ingresar uno en la Venta.")
                     Else
                        _lotesSeleccionados = frm._lotesSeleccionados
                        Me.CargarLotesSeleccionados(_lotesSeleccionados, _ProductoNovedad, _productoTemporal, 0, 1)
                     End If
                  End Using
               '  End If
               ' End If

               'Else
               '   If producto.Lote AndAlso
               'coeficienteStockParaLote = 0 AndAlso
               'DirectCast(Me.cmbTiposComprobantes.SelectedItem, Entidades.TipoComprobante).EsPreElectronico AndAlso
               'Reglas.Publicos.Facturacion.FacturacionSeleccionManualLoteProducto Then
               '      MessageBox.Show("El comprobante " & DirectCast(Me.cmbTiposComprobantes.SelectedItem, Entidades.TipoComprobante).DescripcionAbrev.ToString() & " No permite productos con Lotes.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
               '      Exit Sub
               '   End If
            End If



            '************************
            '*     NROS SERIE       *
            '************************
            'Selecciono los nros. de serie SOLO si el producto permite
            If _productoTemporal.NroSerie Then
               Dim nrosSerie As DataTable
               Dim rNrosSerie As Reglas.ProductosNrosSerie = New Reglas.ProductosNrosSerie()

               If _nrosSerieSeleccionados IsNot Nothing Then
                  nrosSerie = rNrosSerie.GetNrosSerieProducto(actual.Sucursal, cmbDepositoOrigen.ValorSeleccionado(Of Integer), cmbUbicacionOrigen.ValorSeleccionado(Of Integer),
                                                           bscCodigoProductoServ.Text, _nrosSerieSeleccionados.ConvertAll(Function(ns) ns.NroSerie))
                  _productoTemporal.NrosSeries = _nrosSerieSeleccionados
               Else
                  'If DirectCast(Me.cmbTiposComprobantes.SelectedItem, Entidades.TipoComprobante).CoeficienteValores = -1 Then
                  '   nrosSerie = rNrosSerie.GetNrosSerieProductoClienteVendido(actual.Sucursal.Id, Me.bscCodigoProducto2.Text, _clienteE.IdCliente)

                  'Else
                  '-- REQ-32489.- -------------------------------------------------------------------------
                  nrosSerie = rNrosSerie.GetNrosSerieProducto(actual.Sucursal, cmbDepositoOrigen.ValorSeleccionado(Of Integer), cmbUbicacionOrigen.ValorSeleccionado(Of Integer), bscCodigoProductoServ.Text)
                  ' End If
               End If

               Dim cantidadDeProductos As Integer = Int32.Parse(Math.Round(Decimal.Parse(Me.txtCantidadServiceProducto.Text), 0).ToString())
               Dim sel As SeleccionoNrosSerie = New SeleccionoNrosSerie(cantidadDeProductos, _productoTemporal, nrosSerie)
               If sel.ShowDialog() = Windows.Forms.DialogResult.Cancel Then
                  MessageBox.Show("Si el producto esta marcado que utiliza Nro. de Serie debe seleccionar los numeros", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                  Me.btnInsertarProducto.Focus()
                  Exit Sub
               Else
                  For Each ns As Entidades.ProductoNroSerie In sel.ProductosNrosSerie
                     Dim noFueAgregado As Boolean
                     noFueAgregado = Novedad.ProductosNovedad.All(Function(vp)
                                                                     If vp.IdProducto = ns.Producto.IdProducto Then
                                                                        Return Not vp.ProductosNovedadNrosSerie.Any(Function(x) x.NroSerie = ns.NroSerie)
                                                                     End If
                                                                     Return True
                                                                  End Function)

                     '# Si el producto ya fue agregado a la grilla, no dejo agregarlo nuevamente
                     If Not noFueAgregado Then
                        ShowMessage(String.Format("ATENCIÓN: El Producto: {0} Nro. Serie: {1} ya fue agregado.", ns.Producto.IdProducto, ns.NroSerie))
                        Exit Sub
                     End If
                  Next
                  _productoTemporal.NrosSeries.Clear()

                  For Each ns As Entidades.ProductoNroSerie In sel.ProductosNrosSerie
                     _productoserieTemporal = New Entidades.CRMNovedadProductoNrosSerie

                     _productoserieTemporal.IdProducto = _productoTemporal.IdProducto
                     _productoserieTemporal.NroSerie = ns.NroSerie
                     _productoserieTemporal.OrdenProducto = _productoTemporal.Orden
                     _productoserieTemporal.IdSucursal = actual.Sucursal.Id
                     _productoserieTemporal.IdDeposito = Reglas.Publicos.CRMNovedadesDepositoReserva
                     _productoserieTemporal.IdUbicacion = Reglas.Publicos.CRMNovedadesUbicacionReserva

                     _ProductoNovedad.ProductosNovedadNrosSerie.Add(_productoserieTemporal)
                  Next
               End If
            End If

            '-- Carga la Novedad.- --
            Novedad.ProductosNovedad.Add(_ProductoNovedad)
         End If


         'ugProductos.Rows.Refresh(RefreshRow.ReloadData)

         '-- Mostrar Grilla.- --
         MostrarNovedadesProductos(cargando:=False)
         '-- Limpia Campos de Carga.- --
         LimpiarCamposProductos()
         '-- Posiciona el Cursor.- --
         If Reglas.Publicos.Facturacion.FacturacionPermitePosicionarNombreProducto Then
            bscNombreProductoServ.Focus()
         Else
            bscCodigoProductoServ.Focus()
         End If
         '-- Habilito Borrar.- --
         btnBorrarProducto.Enabled = True

         '-- Ajusta el Stock.- --
         Aplicar()
      Catch ex As Exception
         MessageBox.Show(ex.Message, Nothing, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub
   Private Sub btnBorrarProducto_Click(sender As Object, e As EventArgs) Handles btnBorrarProducto.Click
      Try
         If ugProductos.ActiveRow IsNot Nothing AndAlso
            ugProductos.ActiveRow.ListObject IsNot Nothing AndAlso
            TypeOf (ugProductos.ActiveRow.ListObject) Is Entidades.CRMNovedadProducto Then
            Dim NovProducto As Entidades.CRMNovedadProducto = DirectCast(ugProductos.ActiveRow.ListObject, Entidades.CRMNovedadProducto)
            If NovProducto.StockConsumidoProducto Then
               ShowMessage(String.Format("ATENCIÓN: El Producto: {0} ya fue consumido, debe revertir consumo para eliminar.", NovProducto.IdProducto))
               Exit Sub
            End If
            If MessageBox.Show("¿Está seguro de eliminar el registro seleccionado?", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
               Novedad.AjustarStock = Entidades.Publicos.AjustaStock.DEVRESERVAR
               Novedad.ProductosNovedad.Remove(NovProducto)
               ugProductos.Rows.Refresh(RefreshRow.ReloadData)
               '-- Mostrar Grilla.- --
               MostrarNovedadesProductos(cargando:=False)
            End If
         End If
         If ugProductos.Rows.Count = 0 Then
            _OrdenProductoService = ugProductos.Rows.Count
         End If
         '-- Ajusta el Stock.- --
         Aplicar()
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub
   '-- Configuracion de ugProductos.- ----------------------------------------------------------------------------------------------
   Private Sub ugProductos_ClickCell(sender As Object, e As ClickCellEventArgs) Handles ugProductos.ClickCell
      _RegProductos = ugProductos.FilaSeleccionada(Of Entidades.CRMNovedadProducto)(e.Cell.Row)
      '-- Inhabilita Productos con StockConsumidos.- --
      btnBorrarProducto.Enabled = Not (_RegProductos.StockConsumidoProducto)

   End Sub
   Private Sub ugProductos_DoubleClickCell(sender As Object, e As DoubleClickCellEventArgs) Handles ugProductos.DoubleClickCell
      _RegProductos = ugProductos.FilaSeleccionada(Of Entidades.CRMNovedadProducto)(e.Cell.Row)
      If _RegProductos IsNot Nothing AndAlso Not (_RegProductos.StockConsumidoProducto) Then
         txtCantidadServiceProducto.Text = _RegProductos.CantidadProducto.ToString("N2")
         txtPrecioServiceProducto.Text = _RegProductos.PrecioProducto.ToString("N2")
         txtImporteServiceProducto.Text = _RegProductos.ImporteNovedad.ToString("N2")
         bscCodigoProductoServ.Text = _RegProductos.IdProducto.ToString()
         bscCodigoProductoServ.Tag = _RegProductos.OrdenProducto.ToString()
         bscNombreProductoServ.Text = _RegProductos.NombreProducto.ToString()
         '-- Deshabilita el producto.- --
         bscCodigoProductoServ.Enabled = False
         bscNombreProductoServ.Enabled = False
         '-- Posiciona el cursor.- --
         txtCantidadServiceProducto.Focus()
         Novedad.ProductosNovedad.Remove(_RegProductos)
         ugProductos.Rows.Refresh(RefreshRow.ReloadData)
         '-- Deshabilito Borrar.- --
         btnBorrarProducto.Enabled = False
      End If
   End Sub
   '--------------------------------------------------------------------------------------------------------------------------------

   ''' <summary>
   ''' Limpia los Campos de Ingreso de Producto.- --
   ''' </summary>
   Public Sub LimpiarCamposProductos()
      '-- Limpia Buscadores.- --
      bscCodigoProductoServ.FilaDevuelta = Nothing
      bscCodigoProductoServ.Enabled = True
      bscCodigoProductoServ.Text = ""

      bscNombreProductoServ.FilaDevuelta = Nothing
      bscNombreProductoServ.Enabled = True
      bscNombreProductoServ.Text = ""

      txtProductoObservacion.Text = String.Empty
      txtProductoObservacion.Visible = False

      '-- Limpia los Text.- --
      txtCantidadServiceProducto.Text = "0." + New String("0"c, _decimalesMostrarCantidad)
      txtPrecioServiceProducto.Text = "0." + New String("0"c, _decimalesMostrarPrecios)
      txtImporteServiceProducto.Text = "0." + New String("0"c, _decimalesMostrarPrecios)
   End Sub
   ''' <summary>
   ''' Calcula el Importe de Servicios Productos.- --
   ''' </summary>
   ''' <returns></returns>
   Public Function CalculaImporteServicioProducto() As Decimal
      Return txtPrecioServiceProducto.ValorNumericoPorDefecto(2D) * txtCantidadServiceProducto.ValorNumericoPorDefecto(2D)
   End Function
   ''' <summary>
   ''' Configura la Grilla y Carga DataSource.-
   ''' </summary>admin
   Private Sub MostrarNovedadesProductos(cargando As Boolean)

      ugProductos.DataSource = Novedad.ProductosNovedad

      ugProductos.Rows.Refresh(RefreshRow.FireInitializeRow)
      FormatearGrillaNovedadesProductos()
      tsbConsumirStock.Enabled = Novedad.ProductosNovedad.Count > 0
      tsbRevertirStock.Enabled = Novedad.ProductosNovedad.Count > 0

      MostrarImporteTotal()

   End Sub
   ''' <summary>
   ''' Formate la Grilla.- 
   ''' </summary>
   Private Sub FormatearGrillaNovedadesProductos()
      If ugProductos.DisplayLayout.Bands(0).Columns.Count = 0 Then
         Exit Sub
      End If

      Dim pos = 0I


      With ugProductos.DisplayLayout.Bands(0)
         For Each col In .Columns
            col.Hidden = True
         Next
         '.Columns("Lot").Style = UltraWinGrid.ColumnStyle.Button
         '.Columns("Lot").ButtonDisplayStyle = UltraWinGrid.ButtonDisplayStyle.Always

         .Columns("Lot").FormatearColumna("LT", pos, 30)

         '.Columns("NS").Style = UltraWinGrid.ColumnStyle.Button
         '.Columns("NS").ButtonDisplayStyle = UltraWinGrid.ButtonDisplayStyle.Always

         .Columns("NS").FormatearColumna("NS", pos, 30)

         '-- Configura solo las visibles.- --
         .Columns("IdProducto").FormatearColumna("Codigo Producto", pos, 110, HAlign.Right)

         .Columns("NombreProducto").FormatearColumna("Nombre Producto", pos, 280)
         .Columns("CantidadProducto").FormatearColumna("Cantidad", pos, 110, HAlign.Right, , "N2")
         '-- Muestra las columnas si tiene permiso.- ----------------------------------------------------
         If New Reglas.Usuarios().TienePermisos(actual.Nombre, actual.Sucursal.Id, "Precios") Then
            .Columns("PrecioProducto").FormatearColumna("Precio", pos, 110, HAlign.Right, , "N2")
            .Columns("ImporteNovedad").FormatearColumna("Importe", pos, 110, HAlign.Right, , "N2")
         End If

         '-----------------------------------------------------------------------------------------------
         .Columns("StockReservadoProducto").FormatearColumna("Stock Reservado", pos, 110, HAlign.Center,,,, Activation.ActivateOnly)

         .Columns("StockConsumidoProducto").FormatearColumna("Stock Consumido", pos, 110, HAlign.Center,,,, Activation.ActivateOnly)

      End With
      ugProductos.AgregarTotalesSuma({"ImporteNovedad", "CantidadProducto"})
   End Sub

   Private Sub tsbConsumirStock_Click(sender As Object, e As EventArgs) Handles tsbConsumirStock.Click
      Try
         If StateForm <> StateForm.Insertar Then
            '-- Guarda la Novedad.- --
            Novedad.AjustarStock = Entidades.Publicos.AjustaStock.CONSUMIR
            '-- Ajusta el Stock.- --
            Aplicar()
         End If
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

   Private Sub tsbRevertirStock_Click(sender As Object, e As EventArgs) Handles tsbRevertirStock.Click
      Try
         If StateForm <> StateForm.Insertar Then
            '-- Guarda la Novedad.- --
            Novedad.AjustarStock = Entidades.Publicos.AjustaStock.REVERTIR
            '-- Ajusta el Stock.- --
            Aplicar()
         End If
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

   Private Sub MostrarImporteTotal()
      TryCatched(
         Sub()
            If Novedad.ProductosNovedad.Count > 0 Then
               txtCostoReparacion.Text = Novedad.ProductosNovedad.Sum(Function(p) p.ImporteNovedad).ToString(txtCostoReparacion.Formato)
            End If
            'txtCostoReparacion.Text = If(Novedad.ProductosNovedad.Count = 0, 0D,
            '                             Novedad.ProductosNovedad.Sum(Function(p) p.ImporteNovedad)).ToString(txtCostoReparacion.Formato)
            txtCostoReparacion.ReadOnly = Novedad.ProductosNovedad.Count <> 0
         End Sub)
   End Sub

   Private _fechaEstadoAnterior As Date?
   Private Sub dtpFechaEstadoNovedad_ValueChanged(sender As Object, e As EventArgs) Handles dtpFechaEstadoNovedad.ValueChanged
      TryCatched(
         Sub()
            If Not _fechaEstadoAnterior.HasValue And dtpFechaEstadoNovedad.Checked Then
               dtpFechaEstadoNovedad.Value = Date.Now
            End If
            _fechaEstadoAnterior = dtpFechaEstadoNovedad.Valor()
         End Sub)
   End Sub

   Private Sub cmbTipoComentarioNovedadEditor_ValueChanged(sender As Object, e As EventArgs) Handles cmbTipoComentarioNovedadEditor.ValueChanged

   End Sub

   Private Sub cmbComentarioPrincipal_SelectedValueChanged(sender As Object, e As EventArgs) Handles cmbComentarioPrincipal.SelectedValueChanged
      TryCatched(
      Sub()
         If cmbComentarioPrincipal.ValorSeleccionado(Of Entidades.CRMNovedad.ComentarioPrincipalOptiones) = Entidades.CRMNovedad.ComentarioPrincipalOptiones.Manual Then
            ugSeguimiento.DisplayLayout.Bands(0).Columns("ComentarioPrincipal").CellActivation = Activation.AllowEdit
         Else
            ugSeguimiento.DisplayLayout.Bands(0).Columns("ComentarioPrincipal").CellActivation = Activation.ActivateOnly
         End If
      End Sub)
   End Sub


   Private Sub MostrarNumerosLotesDesdeGrilla(grilla As UltraGrid, e As CellEventArgs)

      If grilla.DisplayLayout.Bands(0).Columns(e.Cell.Column.Index).Key = "Lot" Then

         Dim eNovedadProducto As Entidades.CRMNovedadProducto = DirectCast(grilla.ActiveRow.ListObject, Eniac.Entidades.CRMNovedadProducto)

         Dim producto As Entidades.Producto = New Reglas.Productos().GetUno(eNovedadProducto.IdProducto)
         If Not producto.Lote Then
            ShowMessage("Este producto no utiliza Lote.")
            Exit Sub
         End If

         '# Reconstruyo los lotes seleccionados - solo si hay seleccionados - 
         If eNovedadProducto.ProductosNovedadLote IsNot Nothing AndAlso eNovedadProducto.ProductosNovedadLote.Count <> 0 Then
            Me.CargarLotesPreviamenteSeleccionados(eNovedadProducto)
         End If

         'Dim coeficienteStock As Integer = DirectCast(cmbTiposComprobantes.SelectedItem, Entidades.TipoComprobante).CoeficienteStock
         'If coeficienteStock = 0 And
         '   Not String.IsNullOrWhiteSpace(DirectCast(cmbTiposComprobantes.SelectedItem, Entidades.TipoComprobante).IdTipoComprobanteSecundario) Then
         '   Dim tipoSecundario As Entidades.TipoComprobante
         '   tipoSecundario = New Reglas.TiposComprobantes().GetUno(DirectCast(Me.cmbTiposComprobantes.SelectedItem, Entidades.TipoComprobante).IdTipoComprobanteSecundario)
         '   coeficienteStock = tipoSecundario.CoeficienteStock
         'End If

         If (producto.IdSucursal = 0) Then producto.IdSucursal = actual.Sucursal.Id
            Using frm As SeleccionNrosLotes = New SeleccionNrosLotes(producto, eNovedadProducto.IdDepositoActual, eNovedadProducto.IdUbicacionActual, eNovedadProducto.CantidadProducto, -1, _lotesSeleccionados)
            'If eNovedadProducto.StockReservadoProducto Or eNovedadProducto.StockConsumidoProducto Then
            '   frm.Enabled = False
            'End If
            If frm.ShowDialog() = Windows.Forms.DialogResult.OK Then
               '# Me guardo los lotes seleccionados
               _lotesSeleccionados = frm._lotesSeleccionados
               Me.CargarLotesSeleccionados(_lotesSeleccionados, eNovedadProducto, producto)
            End If
         End Using
         End If


   End Sub

   Private Sub MostrarNumerosSerieDesdeGrilla(grilla As UltraGrid, e As CellEventArgs)

      If grilla.DisplayLayout.Bands(0).Columns(e.Cell.Column.Index).Key = "NS" Then

         ' If e.Row.Index <> -1 Then

         Dim nrosSerie As DataTable
         Dim rNrosSerie As Reglas.ProductosNrosSerie = New Reglas.ProductosNrosSerie()
         Dim cantidadDeProductos As Integer = 0

         Dim drVP = DirectCast(grilla.ActiveRow.ListObject, Eniac.Entidades.CRMNovedadProducto)
         Dim producto As Entidades.Producto = New Reglas.Productos().GetUno(drVP.IdProducto)
         If drVP.ProductosNovedadNrosSerie.Count > 0 Then

            cantidadDeProductos = drVP.ProductosNovedadNrosSerie.Count

            'If _comprobantesSeleccionados.Count > 0 AndAlso _comprobantesSeleccionados(0).TipoComprobante.CoeficienteStock = DirectCast(Me.cmbTiposComprobantes.SelectedItem, Entidades.TipoComprobante).CoeficienteStock Then
            nrosSerie = rNrosSerie.GetNrosSerieProducto(actual.Sucursal, drVP.IdDepositoActual, drVP.IdUbicacionActual, drVP.IdProducto, drVP.ProductosNovedadNrosSerie.ConvertAll(Function(ns) ns.NroSerie), Entidades.Publicos.SiNoTodos.SI)
            'Else
            '   If DirectCast(Me.cmbTiposComprobantes.SelectedItem, Entidades.TipoComprobante).CoeficienteValores = -1 Then
            '  nrosSerie = rNrosSerie.GetNrosSerieProductoClienteVendido(actual.Sucursal.Id, drVP.IdProducto, Novedad.IdCliente)
            '   Else
            '-- REQ-32489.- -----------------------------------------------------------------------------------------------------------

            'nrosSerie = rNrosSerie.GetNrosSerieProducto(actual.Sucursal, drVP.IdDepositoActual, drVP.IdUbicacionActual, drVP.IdProducto)
            '   End If
            'End If

            Dim sel As SeleccionoCRMNrosSerie = New SeleccionoCRMNrosSerie(cantidadDeProductos, drVP, nrosSerie)
            If sel.ShowDialog() = Windows.Forms.DialogResult.OK Then
               drVP.ProductosNovedadNrosSerie.Clear()
               drVP.ProductosNovedadNrosSerie = sel.ProductosNrosSerie
            End If
         Else
            If producto.NroSerie Then

               cantidadDeProductos = Integer.Parse(Math.Round(drVP.CantidadProducto, 0).ToString())
               '-- REQ-32489.- -----------------------------------------------------------------------------------------------------------
               nrosSerie = rNrosSerie.GetNrosSerieProducto(actual.Sucursal, producto.IdDeposito, producto.IdUbicacion, producto.IdProducto)

               Dim sel As SeleccionoCRMNrosSerie = New SeleccionoCRMNrosSerie(cantidadDeProductos, drVP, nrosSerie)
               If sel.ShowDialog() = Windows.Forms.DialogResult.OK Then
                  drVP.ProductosNovedadNrosSerie.Clear()
                  drVP.ProductosNovedadNrosSerie = sel.ProductosNrosSerie
               End If

            Else
               ShowMessage("El producto no tiene definido numero de serie")
            End If

            '   End If
         End If
      End If
   End Sub

   Private Sub CargarLotesPreviamenteSeleccionados(vp As Entidades.CRMNovedadProducto)

      If _lotesSeleccionados Is Nothing Then
         _lotesSeleccionados = New DataTable
         _lotesSeleccionados.Columns.Add("IdSucursal", GetType(Integer))
         _lotesSeleccionados.Columns.Add("IdProducto", GetType(String))
         _lotesSeleccionados.Columns.Add("IdLote", GetType(String))
         _lotesSeleccionados.Columns.Add("FechaVencimiento", GetType(Date))
         _lotesSeleccionados.Columns.Add("CantidadSeleccionada", GetType(Decimal))
         _lotesSeleccionados.Columns.Add("IdDeposito", GetType(Integer))
         _lotesSeleccionados.Columns.Add("IdUbicacion", GetType(Integer))
      End If

      For Each vpl As Entidades.CRMNovedadProductoLote In vp.ProductosNovedadLote
         Dim row As DataRow = _lotesSeleccionados.NewRow
         row("IdSucursal") = vpl.IdSucursal
         row("IdProducto") = vpl.IdProducto
         row("IdLote") = vpl.IdLote
         If vpl.FechaVencimiento <> Nothing Then
            row("FechaVencimiento") = vpl.FechaVencimiento
         End If
         row("CantidadSeleccionada") = vpl.CantidadActual
         row("IdDeposito") = vpl.IdDeposito
         row("IdUbicacion") = vpl.IdUbicacion

         _lotesSeleccionados.Rows.Add(row)
      Next

   End Sub

   Private Sub CargarLotesSeleccionados(lotesSeleccionados As DataTable,
                                        lineaDetalle As Entidades.CRMNovedadProducto,
                                        _productoTemporal As Entidades.Producto)
      Me.CargarLotesSeleccionados(lotesSeleccionados,
                                  lineaDetalle,
                                  _productoTemporal,
                                  precioCosto:=0,
                                  idMoneda:=0)
   End Sub

   Private Sub CargarLotesSeleccionados(lotesSeleccionados As DataTable,
                                        lineaDetalle As Entidades.CRMNovedadProducto,
                                        _productoTemporal As Entidades.Producto,
                                        precioCosto As Decimal,
                                        idMoneda As Integer)


      lineaDetalle.ProductosNovedadLote = New List(Of Entidades.CRMNovedadProductoLote)

      For Each row As DataRow In lotesSeleccionados.Rows

         '# Validar que no se haya sobrepasado el stock del lote con los productos ya agregados anteriormente
         Dim cantidadTotal As Decimal = 0
         For Each vp As Entidades.CRMNovedadProducto In Novedad.ProductosNovedad
            cantidadTotal = vp.ProductosNovedadLote.Where(Function(vpl) vpl.IdLote = row("IdLote").ToString() And vpl.IdProducto.Equals(row("IdProducto").ToString())).Sum(Function(x) x.CantidadActual)
            cantidadTotal += CDec(row("CantidadSeleccionada"))
            If cantidadTotal > CDec(row("CantidadActual")) Then
               Throw New Exception(String.Format("ATENCIÓN: La cantidad ingresada del lote {0} del producto {1} superaría la cantidad en stock.", row("IdLote"), row("NombreProducto")))
            End If
         Next

         _productoLoteTemporal = New Entidades.CRMNovedadProductoLote

         '# Validar Fecha de Vencimiento
         If Reglas.Publicos.LoteSolicitaFechaVencimiento Then
            _productoLoteTemporal.FechaIngreso = row.Field(Of Date)(Entidades.ProductoLote.Columnas.FechaIngreso.ToString())
            _productoLoteTemporal.FechaVencimiento = row.Field(Of Date)(Entidades.ProductoLote.Columnas.FechaVencimiento.ToString())
            '  End If
         Else
            _productoLoteTemporal.FechaVencimiento = Nothing
            _productoLoteTemporal.FechaIngreso = Nothing
         End If

         _productoLoteTemporal.IdSucursal = row.Field(Of Integer)(Entidades.ProductoLote.Columnas.IdSucursal.ToString())
         _productoLoteTemporal.IdProducto = _productoTemporal.IdProducto
         _productoLoteTemporal.IdLote = row.Field(Of String)(Entidades.ProductoLote.Columnas.IdLote.ToString())
         _productoLoteTemporal.CantidadActual = row.Field(Of Decimal)("CantidadSeleccionada")
         _productoLoteTemporal.OrdenProducto = _productoTemporal.Orden
         _productoLoteTemporal.IdSucursal = actual.Sucursal.Id
         _productoLoteTemporal.IdDeposito = Reglas.Publicos.CRMNovedadesDepositoReserva
         _productoLoteTemporal.IdUbicacion = Reglas.Publicos.CRMNovedadesUbicacionReserva

         ' _productoLoteTemporal.Orden = _numeroOrden

         lineaDetalle.ProductosNovedadLote.Add(_productoLoteTemporal)

      Next

      '# Luego de cargar los lotes que se seleccionaron en la entidad, mantengo la estructura pero limpio el datatable
      If _lotesSeleccionados IsNot Nothing Then
         _lotesSeleccionados.Clear()
      End If

   End Sub

   Private Sub ugProductos_ClickCellButton(sender As Object, e As CellEventArgs) Handles ugProductos.ClickCellButton


      '# Visualizar Nros. Serie
      Me.MostrarNumerosSerieDesdeGrilla(Me.ugProductos, e)

      '# Visualizar Lotes
      Me.MostrarNumerosLotesDesdeGrilla(Me.ugProductos, e)



   End Sub

   Private Sub cmbDepositoOrigen_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbDepositoOrigen.SelectedIndexChanged
      TryCatched(
        Sub()
           Dim dr = cmbDepositoOrigen.ItemSeleccionado(Of DataRow)()
           If dr IsNot Nothing Then
              depOrigen = dr.Field(Of Integer)("IdDeposito")
              _publicos.CargaComboUbicaciones(cmbUbicacionOrigen, depOrigen, actual.Sucursal.Id)
              cmbUbicacionOrigen.SelectedIndex = 0
              ubiOrigen = Integer.Parse(cmbUbicacionOrigen.SelectedValue.ToString())
           End If
        End Sub)
   End Sub


#End Region

End Class