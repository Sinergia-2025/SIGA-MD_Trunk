Public Class Recibos
   Implements IConParametros

#Region "Campos"

   Private _ComprobantesGrilla As New List(Of Entidades.CuentaCorrientePago)
   '-- Pagos Promedios.- ---------------------------------------------------
   Private _retenciones As List(Of Entidades.Retencion)
   '------------------------------------------------------------------------
   Private _cheques As List(Of Entidades.Cheque)
   Protected _publicos As Publicos
   Private _clienteGrilla As Entidades.Cliente
   Private _tarjetas As List(Of Entidades.VentaTarjeta)
   Private _idFormaDePagoContado As Integer
   Private _idFormaDePagoCtaCte As Integer
   Private _blnMiraUsuario As Boolean = True
   Private _blnMiraPC As Boolean = Not Reglas.Publicos.CtaCte.ReciboIgnorarPCdeCaja
   Private _blnCajasModificables As Boolean = True
   Private _ConfiguracionImpresoras As Boolean
   Private _permiteModificarImporteIntereses As Boolean
   Public ConsultarAutomaticamente As Boolean = False
   Private _CodigoCliente As Long
   Private _importe As Decimal
   Private _cerraLuegoDeGrabar As Boolean
   '-- REQ-42455.- ----------------------------------------------------------------
   Private _ComprobantesPP As DataTable
   Private _PagosPromedioP As DataTable
   '-------------------------------------------------------------------------------
   Private _NumeroComprobante As Long = 0
   Private _IdTipoComprobante As String = ""
   Private _Letra As String = ""
   Private _Emisor As Short = 0

   Private _tit As Dictionary(Of String, String)
   Private _cargoBienLaPantalla As Boolean
   Private _mensajeDeErrorEnCarga As String = ""
   Private MontoDiferenciaPorPlanesTarjeta As Decimal = 0
   Private _esReciboClienteVinculado As Boolean = False
   Public _ImporteAnticipoSinInteres As Decimal = 0
   Private _asunto As String = ""
   Private _cuerpo As String = ""

   Private _cobroNovedad As Entidades.CRMNovedad

   Private _transferencias As List(Of Entidades.CuentaCorrienteTransferencia)


   Private _idEmbarcacion As Long = 0
   Private _idCama As Long = 0

#Region "Campos Busqueda Cliente Secundaria"
   Private Const BusquedaClienteSecundaria_CUIT As String = "CUIT"
   Private Const BusquedaClienteSecundaria_EMBARCACION As String = "EMBARCACION"
   Private Const BusquedaClienteSecundaria_CAMA As String = "CAMA"
#End Region
#End Region

#Region "Constructores"

   Public Sub New()
      InitializeComponent()
      _cerraLuegoDeGrabar = False
   End Sub

   Public Sub New(Novedad As Entidades.CRMNovedad)

      Me.New()
      '-- Descarga Novedades.- --
      _cobroNovedad = Novedad
      _CodigoCliente = New Reglas.Clientes().GetUnoLiviando(Novedad.IdCliente).CodigoCliente
      _cerraLuegoDeGrabar = True
   End Sub

   Public Sub New(Comprobante As Entidades.Venta)

      Me.New()
      _CodigoCliente = Comprobante.Cliente.CodigoCliente
      _IdTipoComprobante = Comprobante.TipoComprobante.IdTipoComprobante
      _Letra = Comprobante.LetraComprobante
      _Emisor = Comprobante.CentroEmisor
      _NumeroComprobante = Comprobante.NumeroComprobante

   End Sub

   Public Sub New(codigoCliente As Long, importe As Decimal, cerraLuegoDeGrabar As Boolean)
      Me.New()
      _CodigoCliente = codigoCliente
      _importe = importe
      _cerraLuegoDeGrabar = cerraLuegoDeGrabar
   End Sub


#End Region

#Region "Overrides"

   Protected Overrides Sub OnLoad(e As EventArgs)

      If _esReciboClienteVinculado Then
         Text = Text.Replace("Recibos", "Recibos Vinculados")
      End If

      MyBase.OnLoad(e)

      Try
         _cargoBienLaPantalla = False

         _publicos = New Publicos()

         _tit = GetColumnasVisiblesGrilla(dgvComprobantes)

         _transferencias = New List(Of Entidades.CuentaCorrienteTransferencia)
         _cheques = New List(Of Entidades.Cheque)
         _retenciones = New List(Of Entidades.Retencion)
         _tarjetas = New List(Of Entidades.VentaTarjeta)()

         _publicos.CargaComboTiposComprobantes(Me.cmbTiposComprobantes, False, "VENTAS", "CTACTE")
         _publicos.CargaComboEmpleados(Me.cmbVendedor, Entidades.Publicos.TiposEmpleados.VENDEDOR)
         _publicos.CargaComboTiposImpuestos(Me.cmbTipoImpuesto, "RETENCION")
         _publicos.CargaComboCajas(Me.cmbCajas, actual.Sucursal.IdSucursal, _blnMiraUsuario, _blnMiraPC, _blnCajasModificables)
         _publicos.CargaComboTarjetas(Me.cmbTarTarjeta, True)
         '_publicos.CargaComboTiposComprobantesCtaCteClientesRec(Me.cmbTiposComprobantesRec)
         _publicos.CargaComboProvincias(cmbProvinciaRetencion)
         _publicos.CargaComboTiposComprobantesRecibo(Me.cmbTiposComprobantesRec, True, "CTACTECLIE", _esReciboClienteVinculado)

         '# Tipos de Cheque
         Me._publicos.CargaComboTiposCheques(Me.cmbTipoCheque)

         Me._publicos.CargaComboEmpleados(Me.cmbCobrador, Entidades.Publicos.TiposEmpleados.COBRADOR)
         'seteo el primero del combo para que no molesto el campo nuevo
         If Me.cmbCobrador.Items.Count > 0 Then
            Me.cmbCobrador.SelectedIndex = 0
         End If

         CargaComboBusquedaClienteSecundaria(cmbBusquedaClienteSecundaria)
         PosicionaSeleccionCombo()
         cmbBusquedaClienteSecundaria.Enabled = cmbBusquedaClienteSecundaria.Items.Count > 1

         Dim oUsuario As Eniac.Reglas.Usuarios = New Eniac.Reglas.Usuarios()
         'Seguridad de la Edición de Clientes (enlace a través de la etiqueta "Más info...")
         Me.llbCliente.Visible = oUsuario.TienePermisos(Eniac.Ayudantes.Common.usuario, Eniac.Entidades.Usuario.Actual.Sucursal.Id, "Clientes-PuedeUsarMasInfo")

         If Me.cmbTiposComprobantesRec.Items.Count = 0 Then
            Me._ConfiguracionImpresoras = True
         End If

         Me._publicos.CargaComboCategorias(Me.cmbCategoria)
         _permiteModificarImporteIntereses = Reglas.Publicos.CtaCte.PermiteModificarImporteInteresesRecibo

         '-- REQ-33040.- -------------
         tsbDebeHaber.Visible = oUsuario.TienePermisos(Eniac.Ayudantes.Common.usuario, Eniac.Entidades.Usuario.Actual.Sucursal.Id, "InfCtaCteClientesDebeHaber")
         tsbDebeHaber.Enabled = False

         Me.LimpiarCamposComprobante()

         Me._idFormaDePagoContado = New Reglas.VentasFormasPago().GetUna("VENTAS", True).IdFormasPago
         Me._idFormaDePagoCtaCte = New Reglas.VentasFormasPago().GetUna("VENTAS", False).IdFormasPago

         If Not Reglas.Publicos.CtaCte.CtaCteClientesSeparar Then
            Me.lblSaldoGeneral.Visible = False
            Me.txtSaldoGeneral.Visible = False
         End If

         'Dim strEtiquetaCuota As String = New Reglas.Traducciones().GetUno(Entidades.Traduccion.Idiomas.es_AR.ToString(), "Recibo", "CuotaNumero").Texto
         'Me.dgvComprobantes.Columns("gcoCuota").HeaderText = strEtiquetaCuota

         If _ConfiguracionImpresoras Then
            Throw New Exception("No Existe la PC en Configuraciones/Impresoras")
         End If
         If Reglas.Publicos.CtaCajaVentas.ToString() = Reglas.Publicos.CtaCajaRecibos.ToString() Then
            Throw New Exception("La cuenta de Caja para Ventas es igual a la Cuenta de Caja para Recibos")
         End If

         Nuevo()

         'Si viene de Facturacion V2 y es Nota de Credito
         If ConsultarAutomaticamente Then

            bscCodigoCliente.Text = Me._CodigoCliente.ToString()
            bscCodigoCliente.PresionarBoton()

            _publicos.CargaComboTiposComprobantesMinutas(Me.cmbTiposComprobantesRec, "VENTAS", "CTACTECLIE", Me._IdTipoComprobante)
            cmbTiposComprobantesRec.SelectedIndex = 0
            cmbTiposComprobantesRec.Enabled = True

            tbcDetalle.SelectedTab = Me.tbpComprobantes
            bscComprobante.Text = Me._NumeroComprobante.ToString()
            bscComprobante.PresionarBoton()

            btnInsertar.PerformClick()

            cmbTiposComprobantesRec.Enabled = True

            _NumeroComprobante = 0
            _IdTipoComprobante = ""
            _Letra = ""
            _Emisor = 0
         Else
            If _CodigoCliente > 0 Then
               Me.bscCodigoCliente.Text = _CodigoCliente.ToString()
               Me.bscCodigoCliente.PresionarBoton()
            End If
            If _importe <> 0 Then
               txtEfectivo.Text = _importe.ToString(txtEfectivo.Formato)
            End If
         End If

         Me._cargoBienLaPantalla = True

         Try
            If _invocadosCajero IsNot Nothing AndAlso _invocadosCajero.Count > 0 Then
               Me.bscCodigoCliente.Text = _invocadosCajero(0).Cliente.CodigoCliente.ToString()
               Me.bscCodigoCliente.PresionarBoton()

               tbcDetalle.SelectedTab = tbpComprobantes
               CargaComprobanteDesdeCajero()
               If _tiposRecibosParaInvocados IsNot Nothing AndAlso _tiposRecibosParaInvocados.Count > 0 Then
                  cmbTiposComprobantes.SelectedValue = _tiposRecibosParaInvocados(0).IdTipoComprobante
               End If
               tbcDetalle.SelectedTab = tbpPagos

               txtEfectivo.Text = txtTotalComprobantes.Text
               txtEfectivo_Leave(txtEfectivo, Nothing)
            End If
         Catch ex As Exception
            ShowError(ex)
         End Try

         bscCodigoCliente.Focus()

      Catch ex As Exception
         ShowError(ex)
         FormEnabled(False)
      End Try

   End Sub

   Private Sub PosicionaSeleccionCombo()
      cmbBusquedaClienteSecundaria.SelectedItem = BusquedaClienteSecundaria_CUIT

      If Reglas.Publicos.CtaCteEmbarcacion Then
         cmbBusquedaClienteSecundaria.SelectedItem = BusquedaClienteSecundaria_EMBARCACION
      End If
      If Reglas.Publicos.CtaCteCama Then
         cmbBusquedaClienteSecundaria.SelectedItem = BusquedaClienteSecundaria_CAMA
      End If

   End Sub
   Private Sub FormEnabled(value As Boolean)
      grbCliente.Enabled = value
      tbcDetalle.Enabled = value
      tspFacturacion.Items.OfType(Of ToolStripButton).ToList().ForEach(
         Sub(tsb)
            If Not tsb.Equals(tsbSalir) Then
               If value Then
                  tsb.Enabled = tsb.TagAs(Of Boolean)()
                  tsb.Tag = Nothing
               Else
                  tsb.Tag = tsb.Enabled
                  tsb.Enabled = value
               End If
            End If
         End Sub)
   End Sub

#End Region

#Region "Eventos"
   '-- REQ-33040.- ------------------------------------------------
   Private Sub AbrirDebeHaberCliente()
      Using frm = New ConsultarCtaCteDetClientesDH
         '---------------------------------------------------------
         frm.InicializarPublicos()
         frm.bscCodigoCliente.Text = bscCodigoCliente.Text
         '---------------------------------------------------------
         frm.chbFechas.Checked = True
         Dim FechaDesdeNew = frm.dtpDesde.Value.Date.AddDays(Reglas.Publicos.CtaCte.CantidadDiasDHRecibos * -1)
         frm.dtpDesde.Value = FechaDesdeNew
         '---------------------------------------------------------
         frm.ConsultarAutomaticamenteDesdeRecibos = True
         frm.ShowDialog()
      End Using
   End Sub
   Private Sub AbrirHistoricoCheques()
      If Me._clienteGrilla Is Nothing Then
         ShowMessage("ATENCIÓN: Debe seleccionar un cliente para poder ver su historial de Cheques.")
         Exit Sub
      End If

      '# Abro el historial de cheques
      Using frm As InformeChequesDeTerceros = New InformeChequesDeTerceros
         frm.InicializarPublicos()
         frm.chbCliente.Checked = True
         frm.bscCodigoCliente.Text = _clienteGrilla.CodigoCliente.ToString()
         frm.bscCodigoCliente.PresionarBoton()
         frm.ConsultarAutomaticamenteDesdeRecibos = True
         frm.ShowDialog()
      End Using
   End Sub

   Private Sub Recibos_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
      Select Case e.KeyCode
         Case Keys.F4
            If tsbGrabar.Enabled And tsbGrabar.Visible Then
               tsbGrabar.PerformClick()
            ElseIf tsbGenerarNCND.Enabled And tsbGenerarNCND.Visible Then
               tsbGenerarNCND.PerformClick()
            End If
         Case Keys.F6
            AbrirHistoricoCheques()
         Case Keys.F7
            '-- REQ-33040.- ----------
            tsbDebeHaber.PerformClick()
            '-------------------------
         Case Keys.F9
            tbcDetalle.SelectedTab = tbpComprobantes
         Case Keys.F11
            If Not tbcDetalle.SelectedTab.Equals(tbpPagos) Then
               tbcDetalle.SelectedTab = tbpPagos
            Else
               btnPlanesTarjetas.PerformClick()
            End If
         Case Keys.H
            If e.Control Then
               tbcDetalle.SelectedTab = tbpPagos
               tbcDetalle2.SelectedTab = tbpCheques
               bscCodBancos.Focus()
            End If
         Case Keys.F
            If e.Control Then
               tbcDetalle.SelectedTab = tbpPagos
               tbcDetalle2.SelectedTab = tpTransferencias
               bscCuentaBancariaTransfBancMultiple.Focus()
            End If
         Case Keys.T
            If e.Control Then
               tbcDetalle.SelectedTab = tbpPagos
               tbcDetalle2.SelectedTab = tbpTarjetas
               cmbTarTarjeta.Focus()
            End If
         Case Keys.R
            If e.Control Then
               tbcDetalle.SelectedTab = tbpPagos
               tbcDetalle2.SelectedTab = tbpRetenciones
               cmbTipoImpuesto.Focus()
            End If

         Case Else
      End Select
   End Sub

   Private Sub tsbNuevo_Click(sender As Object, e As EventArgs) Handles tsbNuevo.Click
      TryCatched(Sub() Nuevo())
   End Sub

   Private Sub tsbGenerarNCND_Click(sender As Object, e As EventArgs) Handles tsbGenerarNCND.Click
      TryCatched(
      Sub()
         GenerarCreditosDebitos()
         tsbGrabar.PerformClick()
      End Sub)
   End Sub

   Private Sub tsbGrabar_Click(sender As Object, e As EventArgs) Handles tsbGrabar.Click
      TryCatched(
      Sub()
         GrabarRecibo()
         If _invocadosCajero IsNot Nothing AndAlso _invocadosCajero.Count > 0 Then
            DialogResult = Windows.Forms.DialogResult.OK
            Close()
         End If
      End Sub)
   End Sub

   Private Sub tsbSalir_Click(sender As Object, e As EventArgs) Handles tsbSalir.Click
      TryCatched(Sub() Close())
   End Sub

#Region "Eventos Busqueda Foranea Cliente"
   Private Sub bscCodigoCliente_BuscadorClick() Handles bscCodigoCliente.BuscadorClick
      Dim codigoCliente As Long = -1
      Try
         Me._publicos.PreparaGrillaClientes2(Me.bscCodigoCliente)
         Dim oClientes As Reglas.Clientes = New Reglas.Clientes
         If Me.bscCodigoCliente.Text.Trim.Length > 0 Then
            codigoCliente = Long.Parse(Me.bscCodigoCliente.Text.Trim())
         End If
         Me.bscCodigoCliente.Datos = oClientes.GetFiltradoPorCodigo(codigoCliente, True, True)

         tsbDebeHaber.Enabled = tsbDebeHaber.Visible
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try

   End Sub
   Private Sub bscCliente_BuscadorClick() Handles bscCliente.BuscadorClick
      Try
         Me._publicos.PreparaGrillaClientes2(Me.bscCliente)
         Dim oClientes As Eniac.Reglas.Clientes = New Eniac.Reglas.Clientes
         Me.bscCliente.Datos = oClientes.GetFiltradoPorNombre(Me.bscCliente.Text.Trim(), True)
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub bscCodigoCliente_BuscadorSeleccion(sender As Object, e As Controles.BuscadorEventArgs) Handles bscCodigoCliente.BuscadorSeleccion, bscCliente.BuscadorSeleccion
      TryCatched(
         Sub() If e.FilaDevuelta IsNot Nothing Then CargarDatosCliente(e.FilaDevuelta),
         onErrorAction:=
         Sub(owner, ex)
            ShowError(ex)
            Nuevo()
         End Sub)
   End Sub

   Private Sub llbCliente_LinkClicked(sender As Object, e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles llbCliente.LinkClicked

      Try
         If Me.bscCodigoCliente.Selecciono Or Me.bscCliente.Selecciono Or Me.bscBusquedaClienteSecundaria.Selecciono Then

            Dim clie As Eniac.Entidades.Cliente
            Dim blnIncluirFoto As Boolean = True

            clie = New Eniac.Reglas.Clientes().GetUnoPorCodigo(Long.Parse(Me.bscCodigoCliente.Text), blnIncluirFoto)
            clie.Usuario = actual.Nombre

            Using PantCliente As ClientesDetalle = New ClientesDetalle(clie)
               PantCliente.StateForm = Eniac.Win.StateForm.Actualizar
               PantCliente.CierraAutomaticamente = True
               PantCliente.ShowDialog()
            End Using
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try

   End Sub
#End Region

#Region "Eventos Busqueda Foranea Cliente Comprobante"
   Private Sub bscCodigoClienteComprobante_BuscadorClick() Handles bscCodigoClienteComprobante.BuscadorClick
      Dim codigoCliente As Long = -1
      Try
         Me._publicos.PreparaGrillaClientes2(Me.bscCodigoClienteComprobante)
         Dim oClientes As Reglas.Clientes = New Reglas.Clientes
         If Me.bscCodigoClienteComprobante.Text.Trim.Length > 0 Then
            codigoCliente = Long.Parse(Me.bscCodigoClienteComprobante.Text.Trim())
         End If
         Me.bscCodigoClienteComprobante.Datos = oClientes.GetFiltradoPorCodigo(codigoCliente, True, True)
      Catch ex As Exception
         ShowError(ex)
      End Try

   End Sub

   Private Sub bscCodigoClienteComprobante_BuscadorSeleccion(sender As Object, e As Controles.BuscadorEventArgs) Handles bscCodigoClienteComprobante.BuscadorSeleccion
      Try
         If Not e.FilaDevuelta Is Nothing Then
            Me.CargarDatosClienteComprobante(e.FilaDevuelta)
         End If
      Catch ex As Exception
         ShowError(ex)
         Me.Nuevo()
      End Try
   End Sub
#End Region


#Region "Propiedades Busqueda Cliente Secudaria"
   Private Sub bscBusquedaClienteSecundaria_BuscadorClick() Handles bscBusquedaClienteSecundaria.BuscadorClick
      Try
         Me.Cursor = Cursors.WaitCursor

         Me.bscBusquedaClienteSecundaria.Datos = EjecutaBusquedaClienteSecundaria(cmbBusquedaClienteSecundaria.SelectedItem.ToString())

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
      Finally
         Me.Cursor = Cursors.Default
      End Try
   End Sub

   Private Sub BusquedaClienteSecundaria_BuscadorSeleccion(sender As Object, e As Controles.BuscadorEventArgs) Handles bscBusquedaClienteSecundaria.BuscadorSeleccion
      Try
         Me.Cursor = Cursors.WaitCursor
         If Not e.FilaDevuelta Is Nothing Then
            Me.CargarDatosCliente(e.FilaDevuelta)
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
      Finally
         Me.Cursor = Cursors.Default
      End Try
   End Sub
#End Region

   Private Sub chbNumeroAutomatico_CheckedChanged(sender As Object, e As EventArgs) Handles chbNumeroAutomatico.CheckedChanged
      TryCatched(Sub()
                    Me.txtNumeroPosible.ReadOnly = chbNumeroAutomatico.Checked
                    CargarProximoNumero(cmbTiposComprobantesRec.SelectedValue.ToString())
                 End Sub)
   End Sub

   Private Sub txtNumeroPosible_KeyDown(sender As Object, e As KeyEventArgs) Handles txtNumeroPosible.KeyDown
      Me.PresionarTab(e)
   End Sub

   Private Sub dtpFecha_KeyDown(sender As Object, e As KeyEventArgs) Handles dtpFecha.KeyDown

      If e.KeyCode = Keys.Enter And Reglas.Publicos.CtaCte.ReciboSolicitaFecha Then
         'Asigno aca porque por algun motivo maravilloso se mueve 1 lugar, y termina en efectivo (donde corresponde)
         'Me.txtObservacion.Focus()

         'GAR: 19/07/2019. Se reasigna porque hay un textbox nuevo.
         'El salgo es porque dicho objeto tiene el evento keyup con enter y aparentemente comparte el evento con el objeto previo.
         Me.txtCotizacionDolar.Focus()
      Else
         Me.PresionarTab(e)
      End If

   End Sub

   Private Sub txtComprobantes_LostFocus(sender As Object, e As EventArgs) Handles txtTotalComprobantes.LostFocus
      If Me.txtTotalComprobantes.Text.Trim().Length = 0 Then
         Me.txtTotalComprobantes.Text = "0"
      End If
   End Sub

   Private Sub txtObservacion_KeyDown(sender As Object, e As KeyEventArgs) Handles txtObservacion.KeyDown
      Me.PresionarTab(e)
   End Sub

   Private Sub txtImporteTransferenciaMultiple_KeyDown(sender As Object, e As KeyEventArgs) Handles txtImporteTransferenciaMultiple.KeyDown
      If e.KeyCode = Keys.Enter AndAlso Not String.IsNullOrEmpty(Me.txtImporteTransferenciaMultiple.Text) Then
         Me.btnAgregarImporteTransfMultiple.PerformClick()
      End If
   End Sub

   Private Sub txtCotizacionDolar_KeyDown(sender As Object, e As KeyEventArgs) Handles txtCotizacionDolar.KeyDown
      Me.PresionarTab(e)

      'Me.cmbDirecciones.Focus()

   End Sub
   Private Sub cmbTipoCheque_KeyDown(sender As Object, e As KeyEventArgs) Handles cmbTipoCheque.KeyDown
      Me.PresionarTab(e)
   End Sub

   Private Sub txtNroOperacion_KeyDown(sender As Object, e As KeyEventArgs) Handles txtNroOperacion.KeyDown
      Me.PresionarTab(e)
   End Sub

   Private Sub tbcDetalle_SelectedIndexChanged(sender As Object, e As EventArgs) Handles tbcDetalle.SelectedIndexChanged
      Try
         Select Case Me.tbcDetalle.SelectedTab.Name
            Case "tbpComprobantes"
               Me.bscComprobante.Focus()
            Case "tbpPagos"
               Me.txtEfectivo.Focus()
         End Select
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub txtEfectivo_KeyDown(sender As Object, e As KeyEventArgs) Handles txtEfectivo.KeyDown
      Me.PresionarTab(e)
   End Sub

   Private Sub txtEfectivo_Leave(sender As Object, e As EventArgs) Handles txtEfectivo.Leave
      Try
         Me.CalcularPagos()
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub txtImporteDolares_KeyDown(sender As Object, e As KeyEventArgs) Handles txtImporteDolares.KeyDown
      Me.PresionarTab(e)
   End Sub

   Private Sub txtImporteDolares_Leave(sender As Object, e As EventArgs) Handles txtImporteDolares.Leave
      Try
         Me.CalcularPagos()
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub txtTarjetas_Leave(sender As Object, e As EventArgs) Handles txtTarjetas.Leave
      Try
         Me.CalcularPagos()
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub txtTarjetas_KeyDown(sender As Object, e As KeyEventArgs) Handles txtTarjetas.KeyDown
      Me.PresionarTab(e)
   End Sub

   Private Sub txtTransferenciaBancaria_KeyDown(sender As Object, e As KeyEventArgs) Handles txtTransferenciaBancaria.KeyDown
      If e.KeyCode = Keys.Enter Then
         If Not String.IsNullOrEmpty(Me.txtTransferenciaBancaria.Text) AndAlso Decimal.Parse(Me.txtTransferenciaBancaria.Text) <> 0 Then
            Me.PresionarTab(e)
         Else
            Me.bscCodBancos.Focus()
         End If
      End If
   End Sub

   Private Sub txtTransferenciaBancaria_Leave(sender As Object, e As EventArgs) Handles txtTransferenciaBancaria.Leave
      TryCatched(Sub() CalcularPagos())
   End Sub

   Private Sub bscCuentaBancariaTransfBanc_BuscadorClick() Handles bscCuentaBancariaTransfBanc.BuscadorClick
      TryCatched(
         Sub()
            _publicos.PreparaGrillaCuentasBancarias2(bscCuentaBancariaTransfBanc)
            Dim oCBancarias = New Reglas.CuentasBancarias()
            bscCuentaBancariaTransfBanc.Datos = oCBancarias.GetFiltradoPorNombre(bscCuentaBancariaTransfBanc.Text.Trim())
         End Sub)
   End Sub

   Private Sub bscCuentaBancariaTransfBanc_BuscadorSeleccion(sender As Object, e As Controles.BuscadorEventArgs) Handles bscCuentaBancariaTransfBanc.BuscadorSeleccion
      TryCatched(
         Sub()
            If Not e.FilaDevuelta Is Nothing Then
               'Me.CargarDatosCuentasBancarias(e.FilaDevuelta)
               bscCuentaBancariaTransfBanc.Text = e.FilaDevuelta.Cells("NombreCuenta").Value.ToString()
               bscCuentaBancariaTransfBanc.Tag = New Reglas.CuentasBancarias().GetUna(Integer.Parse(e.FilaDevuelta.Cells("IdCuentaBancaria").Value.ToString()))
               CalcularPagos()
               dtpFechaTransferencia.Focus()
            End If
         End Sub)
   End Sub

   Private Sub txtCheques_KeyDown(sender As Object, e As KeyEventArgs) Handles txtCheques.KeyDown
      Me.PresionarTab(e)
   End Sub

   Private Sub txtRetenciones_KeyDown(sender As Object, e As KeyEventArgs) Handles txtRetenciones.KeyDown
      Me.PresionarTab(e)
   End Sub

   Private Sub bscBancos_BuscadorClick() Handles bscBancos.BuscadorClick
      Try
         Me._publicos.PreparaGrillaBancos(Me.bscBancos)
         Dim oBanco As Eniac.Reglas.Bancos = New Eniac.Reglas.Bancos()
         Me.bscBancos.Datos = oBanco.GetFiltradoPorNombre(Me.bscBancos.Text.Trim())
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub bscBancos_BuscadorSeleccion(sender As Object, e As Eniac.Controles.BuscadorEventArgs) Handles bscBancos.BuscadorSeleccion
      Try
         If Not e.FilaDevuelta Is Nothing Then
            Me.CargarDatosBancos(e.FilaDevuelta)
            Me.txtSucursalBanco.Focus()
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
         Me.Nuevo()
      End Try
   End Sub

   Private Sub bscCodBancos_BuscadorClick() Handles bscCodBancos.BuscadorClick

      Try
         Me.Cursor = Cursors.WaitCursor
         Me._publicos.PreparaGrillaBancos(Me.bscCodBancos)
         Dim oBanco As Eniac.Reglas.Bancos = New Eniac.Reglas.Bancos()

         Me.bscCodBancos.Datos = oBanco.GetFiltradoPorCodigo(Me.bscCodBancos.Text.Trim())
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try

      Me.Cursor = Cursors.Default
   End Sub

   Private Sub bscCodBancos_BuscadorSeleccion(sender As Object, e As Eniac.Controles.BuscadorEventArgs) Handles bscCodBancos.BuscadorSeleccion
      Try
         If Not e.FilaDevuelta Is Nothing Then
            Me.CargarDatosBancos(e.FilaDevuelta)
            Me.txtSucursalBanco.Focus()
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
         Me.Nuevo()
      End Try
   End Sub

   Private Sub txtSucursalBanco_KeyDown(sender As Object, e As KeyEventArgs) Handles txtSucursalBanco.KeyDown
      Me.PresionarTab(e)
   End Sub

   Private Sub bscCodigoLocalidad_BuscadorClick() Handles bscCodigoLocalidad.BuscadorClick
      Try
         Dim oLocalidades As Reglas.Localidades = New Reglas.Localidades
         Me._publicos.PreparaGrillaLocalidades(Me.bscCodigoLocalidad)
         Me.bscCodigoLocalidad.Datos = oLocalidades.GetPorCodigo(Integer.Parse("0" & Me.bscCodigoLocalidad.Text))
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub bscCodigoLocalidad_BuscadorSeleccion(sender As Object, e As Controles.BuscadorEventArgs) Handles bscCodigoLocalidad.BuscadorSeleccion
      Try
         If Not e.FilaDevuelta Is Nothing Then
            Me.CargarLocalidad(e.FilaDevuelta)
         End If
         Me.txtNroCheque.Focus()
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub txtNroCheque_KeyDown(sender As Object, e As KeyEventArgs) Handles txtNroCheque.KeyDown
      Me.PresionarTab(e)
   End Sub

   'Private Sub txtCodPostalCheque_KeyDown(sender As Object, e As KeyEventArgs)
   '   Me.PresionarTab(e)
   'End Sub

   Private Sub dtpFechaEmision_KeyDown(sender As Object, e As KeyEventArgs) Handles dtpChequeFechaEmision.KeyDown
      Me.PresionarTab(e)
   End Sub

   Private Sub dtpFechaCobro_KeyDown(sender As Object, e As KeyEventArgs) Handles dtpChequeFechaCobro.KeyDown
      Me.PresionarTab(e)
   End Sub

   Private Sub txtTitularCheque_KeyDown(sender As Object, e As KeyEventArgs) Handles txtTitularCheque.KeyDown
      Me.PresionarTab(e)
   End Sub

   Private Sub txtTitularCheque_LostFocus(sender As Object, e As EventArgs) Handles txtTitularCheque.LostFocus
      If Me.txtTitularCheque.Text.Trim.Length > 0 Then
         Dim oCheques As Reglas.Cheques = New Reglas.Cheques()
         Dim dtCheques As DataTable
         Dim Orden = Entidades.Cheque.Ordenamiento.FECHACOBRO

         dtCheques = oCheques.GetInforme({actual.Sucursal},
                                         cajas:={},
                                         estados:=Nothing,
                                         fechaCobroDesde:=Nothing, fechaCobroHasta:=Nothing,
                                         fechaEnCarteraAl:=Nothing,
                                         numero:=0,
                                         idBanco:=0,
                                         idLocalidad:=0,
                                         esPropio:=False,
                                         idCliente:=0,
                                         idProveedor:=0,
                                         titular:=Me.txtTitularCheque.Text,
                                         fechaIngresoDesde:=Nothing, fechaIngresoHasta:=Nothing,
                                         idCuentaBancaria:=0,
                                         orden:=Orden,
                                         tipoCheque:="", conciliado:=Nothing,
                                         observacion:=String.Empty)
         If dtCheques.Rows.Count > 0 Then
            Me.txtCUITCheque.Text = dtCheques(0)("CUIT").ToString()
         Else
            Me.txtCUITCheque.Text = String.Empty
         End If
      End If
   End Sub

   Private Sub txtCUITCheque_KeyDown(sender As Object, e As KeyEventArgs) Handles txtCUITCheque.KeyDown
      Me.PresionarTab(e)
   End Sub

   Private Sub txtImporteCheque_KeyDown(sender As Object, e As KeyEventArgs) Handles txtImporteCheque.KeyDown
      Me.PresionarTab(e)
   End Sub

   Private Sub chbProveedor_KeyDown(sender As Object, e As KeyEventArgs) Handles chbProveedor.KeyDown
      PresionarTab(e)
   End Sub

   Private Sub btnInsertarCheque_Click(sender As Object, e As EventArgs) Handles btnInsertarCheque.Click
      Try
         If Me.ValidarInsertarCheques() Then
            Me.InsertarChequeGrilla()
            Me.bscCodBancos.Focus()
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try

   End Sub

   Private Sub btnEliminarCheque_Click(sender As Object, e As EventArgs) Handles btnEliminarCheque.Click
      Try
         If Me.dgvCheques.SelectedRows.Count > 0 Then
            If MessageBox.Show("Esta seguro de eliminar el cheque seleccionado?", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
               Me.EliminarLineaCheque()
            End If
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub dgvCheques_CellDoubleClick(sender As Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvCheques.CellDoubleClick

      Try

         'Limpia los textbox, y demas controles
         Me.LimpiarCamposCheque()

         If Me.dgvCheques.Rows(e.RowIndex).Cells("gchIdEstadoCheque").Value.ToString() = "ALTA" Then
            MessageBox.Show("El Cheque seleccionado fue invocado como Cheque en ALta", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
         End If

         'Carga el Comprobante seleccionado de la grilla en los textbox 
         Me.CargarChequeCompleto(Me.dgvCheques.Rows(e.RowIndex))

         'Elimina el comprobantede la grilla
         Me.EliminarLineaCheque()

         Me.bscCodBancos.Focus()

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try

   End Sub

   '-------------------------------------------
   Private Sub cmbProvinciaRetencion_KeyDown(sender As Object, e As KeyEventArgs) Handles cmbProvinciaRetencion.KeyDown
      Me.PresionarTab(e)
   End Sub

   Private Sub cmbTipoImpuesto_KeyDown(sender As Object, e As KeyEventArgs) Handles cmbTipoImpuesto.KeyDown
      Me.PresionarTab(e)
   End Sub

   Private Sub txtRetencionEmisor_KeyDown(sender As Object, e As KeyEventArgs) Handles txtRetencionEmisor.KeyDown
      Me.PresionarTab(e)
   End Sub

   Private Sub txtRetencionNumero_KeyDown(sender As Object, e As KeyEventArgs) Handles txtRetencionNumero.KeyDown
      Me.PresionarTab(e)
   End Sub

   Private Sub dtpRetencionFechaEmision_KeyDown(sender As Object, e As KeyEventArgs) Handles dtpRetencionFechaEmision.KeyDown
      Me.PresionarTab(e)
   End Sub

   Private Sub txtRetencionBaseImponible_KeyDown(sender As Object, e As KeyEventArgs) Handles txtRetencionBaseImponible.KeyDown
      Me.PresionarTab(e)
   End Sub

   Private Sub txtRetencionBaseImponible_Leave(sender As Object, e As EventArgs) Handles txtRetencionBaseImponible.Leave

      Dim BaseImponible As Decimal = 0
      If IsNumeric(Me.txtRetencionBaseImponible.Text.Trim()) Then
         BaseImponible = Decimal.Parse(Me.txtRetencionBaseImponible.Text)
      End If

      Dim Alicuota As Decimal = 0
      If IsNumeric(Me.txtRetencionAlicuota.Text.Trim()) Then
         Alicuota = Decimal.Parse(Me.txtRetencionAlicuota.Text)
      End If

      Me.txtRetencionImporteTotal.Text = Decimal.Round(BaseImponible * (Alicuota / 100), 2).ToString("#,##0.00")

   End Sub

   Private Sub txtRetencionAlicuota_KeyDown(sender As Object, e As KeyEventArgs) Handles txtRetencionAlicuota.KeyDown
      Me.PresionarTab(e)
   End Sub

   Private Sub txtRetencionAlicuota_Leave(sender As Object, e As EventArgs) Handles txtRetencionAlicuota.Leave

      Dim BaseImponible As Decimal = 0
      If IsNumeric(Me.txtRetencionBaseImponible.Text.Trim()) Then
         BaseImponible = Decimal.Parse(Me.txtRetencionBaseImponible.Text)
      End If

      Dim Alicuota As Decimal = 0
      If IsNumeric(Me.txtRetencionAlicuota.Text.Trim()) Then
         Alicuota = Decimal.Parse(Me.txtRetencionAlicuota.Text)
      End If

      Me.txtRetencionImporteTotal.Text = Decimal.Round(BaseImponible * (Alicuota / 100), 2).ToString("#,##0.00")

   End Sub

   Private Sub txtRetencionImporteTotal_KeyDown(sender As Object, e As KeyEventArgs) Handles txtRetencionImporteTotal.KeyDown
      Me.PresionarTab(e)
   End Sub

   Private Sub btnRetencionInsertar_Click(sender As Object, e As EventArgs) Handles btnRetencionInsertar.Click
      Try

         ''--PE-31252 --
         Dim oRetenciones As Reglas.Retenciones = New Reglas.Retenciones()
         Dim oValidaDetalle As Entidades.Retencion = New Entidades.Retencion()

         With oValidaDetalle
            .IdSucursal = actual.Sucursal.IdSucursal
            .TipoImpuesto = New Reglas.TiposImpuestos().GetUno(DirectCast([Enum].Parse(GetType(Eniac.Entidades.TipoImpuesto.Tipos), Me.cmbTipoImpuesto.SelectedValue.ToString()), Entidades.TipoImpuesto.Tipos))
            .EmisorRetencion = Integer.Parse(Me.txtRetencionEmisor.Text)
            .NumeroRetencion = Long.Parse(Me.txtRetencionNumero.Text)
            .Cliente.IdCliente = Me._clienteGrilla.IdCliente
         End With


         If Not oRetenciones.ExisteRetencion(oValidaDetalle) Then
            If ValidarInsertarRetenciones() Then
               InsertarRetencionGrilla()
               cmbTipoImpuesto.Focus()
            End If
         Else
            MessageBox.Show(String.Format("Ya existe una retención del cliente con el Emisor {0} y Número {1}",
                                           oValidaDetalle.EmisorRetencion, oValidaDetalle.NumeroRetencion), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.txtRetencionNumero.Focus()
         End If

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub btnRetencionEliminar_Click(sender As Object, e As EventArgs) Handles btnRetencionEliminar.Click
      Try
         If Me.dgvRetenciones.SelectedRows.Count > 0 Then
            If MessageBox.Show("Esta seguro de eliminar la Retención seleccionada?", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
               Me.EliminarLineaRetencion()
            End If
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub dgvRetenciones_CellDoubleClick(sender As Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvRetenciones.CellDoubleClick

      Try
         'Limpia los textbox, y demas controles
         Me.LimpiarCamposRetencion()

         'Carga el Comprobante seleccionado de la grilla en los textbox 
         Me.CargarRetencionCompleto(Me.dgvRetenciones.Rows(e.RowIndex))

         'Elimina el comprobantede la grilla
         Me.EliminarLineaRetencion()

         Me.cmbTipoImpuesto.Focus()

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try

   End Sub

   '--------------------------------------

   Private Sub btnLimpiarComprobante_Click(sender As Object, e As EventArgs) Handles btnLimpiarComprobante.Click

      Me.LimpiarCamposComprobante()
      Me.bscComprobante.Focus()

   End Sub

   Private Sub bscComprobante_BuscadorClick() Handles bscComprobante.BuscadorClick
      Try
         Dim oComprobantes As Reglas.CuentasCorrientes = New Reglas.CuentasCorrientes

         Dim numero As Long = 0

         Long.TryParse(Me.bscComprobante.Text, numero)

         _publicos.PreparaGrillaComprobantesVentaPendientes(bscComprobante)
         'Me.PreparaGrillaComprobantes(Me.bscComprobante)
         'Dim grabaLibro As Boolean = New Reglas.TiposComprobantes().GetUno(Me.cmbTiposComprobantesRec.SelectedValue.ToString()).GrabaLibro
         Dim strComprobantesAsociados As String = New Reglas.TiposComprobantes().GetUno(Me.cmbTiposComprobantesRec.SelectedValue.ToString()).ComprobantesAsociados

         bscComprobante.Datos = oComprobantes.BuscarPendientes(actual.Sucursal.Id,
                                                               _clienteGrilla.IdCliente, GetIdCategoriaClienteSegunParametro(),
                                                               GetTipoReciboSeleccionado().EsReciboClienteVinculado, strComprobantesAsociados,
                                                               _IdTipoComprobante, _Letra, _Emisor, numero, String.Empty,
                                                               idTipoLiquidacion:=Nothing, incluirPreElectronicos:=False,
                                                               idEmbarcacion:=_idEmbarcacion, idCama:=_idCama, crmNovedad:=Nothing,
                                                               seleccionMultiple:=False)

      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

   Private Sub bscComprobante_BuscadorSeleccion(sender As Object, e As Controles.BuscadorEventArgs) Handles bscComprobante.BuscadorSeleccion
      Try
         If Not e.FilaDevuelta Is Nothing Then
            Me.CargarComprobante(e.FilaDevuelta)
            ''If Me.chbDescuentoRecargoPorc.Checked Then
            ''   Me.txtDescuentoRecargoPorc.Focus()
            ''Else
            Me.txtPaga.Focus()
            ''End If
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub txtImporte_LostFocus(sender As Object, e As EventArgs) Handles txtImporte.LostFocus
      Try
         If Me.txtImporte.Text.Trim().Length = 0 Then
            Me.txtImporte.Text = "0.00"
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub txtCuota_LostFocus(sender As Object, e As EventArgs) Handles txtCuota.LostFocus
      Try
         If Me.txtCuota.Text.Trim().Length = 0 Then

         Else
            If Me.txtImporte.Text = "-" Then
               Me.txtImporte.Text = "0.00"
            End If
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub txtCuota_KeyDown(sender As Object, e As KeyEventArgs) Handles txtCuota.KeyDown
      If e.KeyCode = Keys.Enter Then
         Me.txtImporte.Focus()
      End If
   End Sub

   Private Sub txtDescuentoRecargoPorcImporte_KeyDown(sender As Object, e As KeyEventArgs) Handles txtDescuentoRecargoPorc.KeyDown, txtDescuentoRecargoImporte.KeyDown
      Me.PresionarTab(e)
   End Sub

   Private _txtDescuentoRecargoPorcTmp As Decimal
   Private Sub txtDescuentoRecargoPorc_Enter(sender As Object, e As EventArgs) Handles txtDescuentoRecargoPorc.Enter
      _txtDescuentoRecargoPorcTmp = Decimal.Parse(txtDescuentoRecargoPorc.Text)
   End Sub

   Private Sub txtDescuentoRecargoPorc_Leave(sender As Object, e As EventArgs) Handles txtDescuentoRecargoPorc.Leave
      Try
         If Me.txtDescuentoRecargoPorc.Text = "" Or Me.txtDescuentoRecargoPorc.Text = "-" Then
            Me.txtDescuentoRecargoPorc.Text = "0.00"
         End If
         If _txtDescuentoRecargoPorcTmp = Decimal.Parse(txtDescuentoRecargoPorc.Text) Then Return
         Me.CalcularTotalAPagarComprobantePorPorc()
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private _txtDescuentoRecargoImporteTmp As Decimal
   Private Sub txtDescuentoRecargoImporte_Enter(sender As Object, e As EventArgs) Handles txtDescuentoRecargoImporte.Enter
      _txtDescuentoRecargoImporteTmp = Decimal.Parse(txtDescuentoRecargoImporte.Text)
   End Sub

   Private Sub txtDescuentoRecargoImporte_Leave(sender As Object, e As EventArgs) Handles txtDescuentoRecargoImporte.Leave
      Try
         If Me.txtDescuentoRecargoImporte.Text = "" Or Me.txtDescuentoRecargoImporte.Text = "-" Then
            Me.txtDescuentoRecargoImporte.Text = "0.00"
         End If
         If _txtDescuentoRecargoImporteTmp = Decimal.Parse(txtDescuentoRecargoImporte.Text) Then Return
         Me.CalcularTotalAPagarComprobantePorImporte()
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub txtPaga_KeyDown(sender As Object, e As KeyEventArgs) Handles txtPaga.KeyDown
      Me.PresionarTab(e)
   End Sub

   Private Sub btnInsertar_Click(sender As Object, e As EventArgs) Handles btnInsertar.Click
      Try
         If Me.ValidarInsertarComprobante() Then
            Me.InsertarComprobanteGrilla()
            Me.bscComprobante.Focus()
            CalculoPromedioPagoPonderados()
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub btnEliminar_Click(sender As Object, e As EventArgs) Handles btnEliminar.Click
      Try
         If Me.dgvComprobantes.SelectedRows.Count > 0 Then
            If MessageBox.Show("Esta seguro de eliminar el pago seleccionado?", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
               Me.EliminarLineaComprobante()
               '-- REQ-31947.- ----------------------------------
               ProcesoCalculoInteresCheques()
               '-------------------------------------------------
            End If
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub dgvComprobantes_CellClick(sender As Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvComprobantes.CellClick
      Try
         If e.RowIndex <> -1 And Me.dgvComprobantes.Columns(e.ColumnIndex).HeaderText = "Ver" Then
            Try
               Me.Cursor = Cursors.WaitCursor

               Dim regTipoComp As Reglas.TiposComprobantes = New Reglas.TiposComprobantes()
               Dim oTipoComprobante As Entidades.TipoComprobante = regTipoComp.GetUno(Me.dgvComprobantes.Rows(e.RowIndex).Cells("gcoIdTipoComprobante").Value.ToString())

               If oTipoComprobante.EsAnticipo Then
                  'imprime los recibos
                  Dim reg As Reglas.CuentasCorrientes = New Reglas.CuentasCorrientes()
                  Dim ctacte As Entidades.CuentaCorriente = reg.GetUna(actual.Sucursal.Id,
                                 oTipoComprobante.IdTipoComprobanteSecundario,
                                 Me.dgvComprobantes.Rows(e.RowIndex).Cells("gcoLetra").Value.ToString(),
                                 Int32.Parse(Me.dgvComprobantes.Rows(e.RowIndex).Cells("gcoCentroEmisor").Value.ToString()),
                                 Long.Parse(Me.dgvComprobantes.Rows(e.RowIndex).Cells("gcoNumeroComprobante").Value.ToString()))
                  Dim imp As RecibosImprimir = New RecibosImprimir()
                  imp.ImprimirRecibo(ctacte, True)
               Else
                  'imprime los comprobantes que no son recibos
                  Dim oVentas As Reglas.Ventas = New Reglas.Ventas()
                  Dim venta As Entidades.Venta = oVentas.GetUna(actual.Sucursal.Id,
                              Me.dgvComprobantes.Rows(e.RowIndex).Cells("gcoIdTipoComprobante").Value.ToString(),
                              Me.dgvComprobantes.Rows(e.RowIndex).Cells("gcoLetra").Value.ToString(),
                              Short.Parse(Me.dgvComprobantes.Rows(e.RowIndex).Cells("gcoCentroEmisor").Value.ToString()),
                              Long.Parse(Me.dgvComprobantes.Rows(e.RowIndex).Cells("gcoNumeroComprobante").Value.ToString()))

                  Dim oImpr As Impresion = New Impresion(venta)

                  If Not oTipoComprobante.EsFiscal Then
                     oImpr.ImprimirComprobanteNoFiscal(True)
                  Else
                     oImpr.ReImprimirComprobanteFiscal()
                  End If
               End If

            Catch ex As Exception
               MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Finally
               Me.Cursor = Cursors.Default
            End Try

         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub dgvComprobantes_CellDoubleClick(sender As Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvComprobantes.CellDoubleClick

      Try
         'Limpia los textbox, y demas controles
         Me.LimpiarCamposComprobante()

         'Carga el Comprobante seleccionado de la grilla en los textbox 
         Me.CargarComprobanteCompleto(Me.dgvComprobantes.Rows(e.RowIndex))

         'Elimina el comprobantede la grilla
         Me.EliminarLineaComprobante()

         If Me.chbDescuentoRecargoPorc.Checked Or Decimal.Parse(Me.txtDescuentoRecargoPorc.Text) <> 0 Then
            Me.txtDescuentoRecargoPorc.Focus()
         Else
            Me.txtPaga.Focus()
         End If

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try

   End Sub

   Private Sub btnImputAutomat_Click(sender As Object, e As EventArgs) Handles btnImputAutomat.Click
      Try

         If Decimal.Parse(Me.txtTotalPagos.Text.ToString()) <> 0 Then
            Me._ComprobantesGrilla.Clear()
            Dim oComprobantes As Reglas.CuentasCorrientes = New Reglas.CuentasCorrientes
            Dim dt As DataTable
            'Dim grabaLibro As Boolean = New Reglas.TiposComprobantes().GetUno(Me.cmbTiposComprobantesRec.SelectedValue.ToString()).GrabaLibro
            Dim strComprobantesAsociados As String = New Reglas.TiposComprobantes().GetUno(Me.cmbTiposComprobantesRec.SelectedValue.ToString()).ComprobantesAsociados
            dt = oComprobantes.BuscarPendientes(actual.Sucursal.Id, Me._clienteGrilla.IdCliente, GetIdCategoriaClienteSegunParametro(),
               GetTipoReciboSeleccionado().EsReciboClienteVinculado, strComprobantesAsociados, "", "", 0, 0, String.Empty, Nothing,
               incluirPreElectronicos:=False, idEmbarcacion:=_idEmbarcacion, idCama:=0, crmNovedad:=Nothing, seleccionMultiple:=False)
            Dim Paga As Double
            Paga = Decimal.Parse(Me.txtTotalPagos.Text.ToString())
            Dim dt1 As DataTable = dt.Clone()
            dt1.Columns.Add("Paga", System.Type.GetType("System.Decimal"))
            dt1.Columns.Add("DescRecPorc", System.Type.GetType("System.Decimal")).DefaultValue = 0
            dt1.Columns.Add("DescRec", System.Type.GetType("System.Decimal")).DefaultValue = 0
            Dim dr2 As DataRow
            '-- REQ-31947.- --------------------------------
            ProcesoCalculoInteresCheques()
            '-----------------------------------------------
            For Each dr As DataRow In dt.Rows
               If Not Paga = 0 Then

                  Dim saldo As Decimal = Decimal.Parse(dr("Saldo").ToString())
                  Dim descRecPorc As Decimal
                  Dim descRec As Decimal = 0
                  descRecPorc = ReciboPorcentajeDescuentoRecargo(DirectCast(cmbTiposComprobantesRec.SelectedItem, Entidades.TipoComprobante),
                                                                 Integer.Parse(dr("IdCategoria").ToString()),
                                                                 Date.Parse(dr("Fecha").ToString()),
                                                                 Date.Parse(dr("FechaVencimiento").ToString()),
                                                                 dtpFechaCalculoInteres.Value,
                                                                 Decimal.Parse(dr("Importe").ToString()),
                                                                 Decimal.Parse(dr("Saldo").ToString()))
                  descRecPorc = Decimal.Round(descRecPorc, 2)
                  If descRecPorc <> 0 Then
                     descRec = Decimal.Round(saldo * descRecPorc / 100, 2)
                     If Reglas.Publicos.CtaCte.MontoMinimoInteresPermitido > descRec Then
                        descRec = 0
                     End If
                     saldo = saldo + descRec
                  End If

                  If saldo <= Paga Then
                     dr2 = dt1.NewRow()
                     dr2.ItemArray = dr.ItemArray
                     dr2("Paga") = saldo - descRec ''Double.Parse(dr("Saldo").ToString())
                     dr2("DescRecPorc") = descRecPorc
                     dr2("DescRec") = descRec
                     dt1.Rows.Add(dr2)
                     dt1.AcceptChanges()
                     Paga = Paga - saldo ''Double.Parse(dr("Saldo").ToString())
                  Else
                     If descRecPorc <> 0 Then
                        Dim importeParaCalculo As Decimal = 0
                        If Reglas.Publicos.CtaCte.InteresesCalculoCompletoPrimerPago Then
                           If IsNumeric(dr("Saldo").ToString()) Then
                              importeParaCalculo = Decimal.Parse(dr("Saldo").ToString())
                           End If
                        Else
                           importeParaCalculo = Convert.ToDecimal(Paga)
                        End If

                        'If chkMontoAplicadoIncluyeIntereses.Checked And Not Reglas.Publicos.CtaCte.InteresesCalculoCompletoPrimerPago Then
                        '   descRec = importeParaCalculo  - Math.Round(importeParaCalculo / (100 + descRecPorc * 100), 2)
                        'Else
                        '   descRec = importeParaCalculo * descRecPorc / 100
                        'End If
                        descRec = importeParaCalculo - Math.Round(importeParaCalculo / (100 + descRecPorc) * 100, 2)

                        If Reglas.Publicos.CtaCte.MontoMinimoInteresPermitido > descRec Then
                           descRec = 0
                        End If

                     End If
                     dr2 = dt1.NewRow()
                     dr2.ItemArray = dr.ItemArray
                     ''dr2("Paga") = Paga

                     dr2("Paga") = Paga - descRec ''Double.Parse(dr("Saldo").ToString())
                     'If chkMontoAplicadoIncluyeIntereses.Checked Then
                     '   dr2("Paga") = Paga - descRec ''Double.Parse(dr("Saldo").ToString())
                     'Else
                     '   dr2("Paga") = Paga ''Double.Parse(dr("Saldo").ToString())
                     'End If
                     dr2("DescRecPorc") = descRecPorc
                     dr2("DescRec") = descRec

                     If CDec(dr2("Paga")) > 0 Then
                        dt1.Rows.Add(dr2)
                     Else
                        MessageBox.Show("El remanente a pagar es menor a los intereses calculados por el siguiente comprobante." + Environment.NewLine +
                                        "Por favor finalice la carga del comprobante de manera manual.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
                     End If
                     dt1.AcceptChanges()
                     Paga = 0
                  End If

               End If

            Next

            For Each dr1 As DataRow In dt1.Rows
               Dim oLineaDetalle As Entidades.CuentaCorrientePago = New Entidades.CuentaCorrientePago()
               With oLineaDetalle
                  Dim otipocomp As Reglas.TiposComprobantes = New Reglas.TiposComprobantes()
                  .TipoComprobante = otipocomp.GetUno(dr1("IdTipoComprobante").ToString())
                  .Letra = dr1("Letra").ToString()
                  .CentroEmisor = Integer.Parse(dr1("Emisor").ToString())
                  .NumeroComprobante = Integer.Parse(dr1("Numero").ToString())
                  .Cuota = Integer.Parse(dr1("Cuota").ToString())
                  .FechaEmision = Date.Parse(dr1("Fecha").ToString())
                  .FechaVencimiento = Date.Parse(dr1("FechaVencimiento").ToString())
                  .ImporteCuota = Decimal.Parse(dr1("Importe").ToString())
                  .NombreMoneda = dr1("NombreMoneda").ToString()
                  .SaldoCuota = Decimal.Parse(dr1("Saldo").ToString())
                  .Paga = Decimal.Parse(dr1("Paga").ToString())
                  .FormaPago = New Reglas.VentasFormasPago().GetUna(Integer.Parse(dr1("IdFormasPago").ToString()))
                  .DescuentoRecargoPorc = Decimal.Parse(dr1("DescRecPorc").ToString()) ''ReciboPorcentajeDescuentoRecargo(.FechaEmision, .FechaVencimiento, dtpFecha.Value, .ImporteCuota, .SaldoCuota)
                  .DescuentoRecargo = Decimal.Parse(dr1("DescRec").ToString()) ''.Paga * .DescuentoRecargoPorc / 100
                  .MontoAplicadoIncluyeIntereses = False
                  .IdSucursal = Integer.Parse(dr1("Sucursal").ToString())
                  .Usuario = actual.Nombre
                  .CuentaCorriente.Cliente = New Entidades.Cliente() With {.IdCliente = Long.Parse(dr1("IdCliente").ToString()),
                                                                           .CodigoCliente = Long.Parse(dr1("CodigoCliente").ToString()),
                                                                           .NombreCliente = dr1("NombreCliente").ToString()}
               End With
               Me._ComprobantesGrilla.Add(oLineaDetalle)
            Next

            Me.dgvComprobantes.DataSource = _ComprobantesGrilla.ToArray()
            Me.AjustarColumnasGrilla(Me.dgvComprobantes, Me._tit)

            If Me.dgvComprobantes.Rows.Count > 0 Then
               Me.dgvComprobantes.FirstDisplayedScrollingRowIndex = Me.dgvComprobantes.Rows.Count - 1
            End If

            Me.dgvComprobantes.Refresh()

            Me.CalcularTotales()
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub cmbTarTarjeta_KeyDown(sender As Object, e As KeyEventArgs) Handles cmbTarTarjeta.KeyDown
      Me.PresionarTab(e)
   End Sub

   Private Sub bscTarBanco_BuscadorClick() Handles bscTarBanco.BuscadorClick
      Try
         Me._publicos.PreparaGrillaBancos(Me.bscTarBanco)
         Dim oBanco As Eniac.Reglas.Bancos = New Eniac.Reglas.Bancos()
         Me.bscTarBanco.Datos = oBanco.GetFiltradoPorNombre(Me.bscTarBanco.Text.Trim())
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
      End Try
   End Sub

   Private Sub bscTarBanco_BuscadorSeleccion(sender As Object, e As Eniac.Controles.BuscadorEventArgs) Handles bscTarBanco.BuscadorSeleccion
      Try
         If Not e.FilaDevuelta Is Nothing Then
            Me.CargarDatosTarjetasBancos(e.FilaDevuelta)
            Me.txtTarMonto.Focus()
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
      End Try
   End Sub

   Private Sub txtTarMonto_KeyDown(sender As Object, e As KeyEventArgs) Handles txtTarMonto.KeyDown
      Me.PresionarTab(e)
   End Sub

   Private Sub txtTarCuotas_KeyDown(sender As Object, e As KeyEventArgs) Handles txtTarCuotas.KeyDown
      Me.PresionarTab(e)
   End Sub

   Private Sub txtTarNumeroCupon_KeyDown(sender As Object, e As KeyEventArgs) Handles txtTarNumeroCupon.KeyDown
      Me.PresionarTab(e)
   End Sub
   Private Sub txtTarNumeroLote_KeyDown(sender As Object, e As KeyEventArgs) Handles txtTarNumeroLote.KeyDown
      Me.PresionarTab(e)
   End Sub

   Private Sub btnInsertarTarjeta_Click(sender As Object, e As EventArgs) Handles btnInsertarTarjeta.Click
      TryCatched(
      Sub()
         If ValidarInsertarTarjeta() Then
            InsertarTarjetaGrilla()
            cmbTarTarjeta.Focus()
         End If
      End Sub)
   End Sub

   Private Sub btnEliminarTarjeta_Click(sender As Object, e As EventArgs) Handles btnEliminarTarjeta.Click
      TryCatched(
      Sub()
         If dgvTarjetas.SelectedRows.Count > 0 Then
            If ShowPregunta("¿Esta seguro de eliminar la tarjeta seleccionada?") = Windows.Forms.DialogResult.Yes Then
               EliminarLineaTarjetas()
            End If
         End If
      End Sub)
   End Sub

   Private Sub cmbTiposComprobantesRec_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbTiposComprobantesRec.SelectedIndexChanged
      Try
         If Me.cmbTiposComprobantesRec.SelectedValue IsNot Nothing Then

            'Si es X/R siempre debe tener esa letra, sino dejo la del Cliente
            If DirectCast(Me.cmbTiposComprobantesRec.SelectedItem, Entidades.TipoComprobante).LetrasHabilitadas = "X" Or
               DirectCast(Me.cmbTiposComprobantesRec.SelectedItem, Entidades.TipoComprobante).LetrasHabilitadas = "R" Then
               Me.txtLetraRecibo.Text = DirectCast(Me.cmbTiposComprobantesRec.SelectedItem, Entidades.TipoComprobante).LetrasHabilitadas
            Else
               If Me._clienteGrilla IsNot Nothing Then
                  Me.txtLetraRecibo.Text = Me._clienteGrilla.CategoriaFiscal.LetraFiscal
               Else
                  Me.txtLetraRecibo.Text = ""
               End If
            End If

            If Reglas.Publicos.CtaCte.CtaCteClientesSeparar Then
               Me._ComprobantesGrilla.Clear()
               Me.dgvComprobantes.DataSource = Me._ComprobantesGrilla.ToArray()
               If Me._tit IsNot Nothing Then
                  Me.AjustarColumnasGrilla(Me.dgvComprobantes, Me._tit)
               End If
               Me.CalcularTotales()
            End If

            Me.CargarProximoNumero(Me.cmbTiposComprobantesRec.SelectedValue.ToString())

            chbNumeroAutomatico.Checked = cmbTiposComprobantesRec.ItemSeleccionado(Of Entidades.TipoComprobante).NumeracionAutomatica

            If DirectCast(Me.cmbTiposComprobantesRec.SelectedItem, Entidades.TipoComprobante).ImporteTope < 0 Then
               Me.tbcDetalle2.Enabled = False
               Me._cheques.Clear()
               Me.dgvCheques.DataSource = Me._cheques.ToArray()
               Me.LimpiarCamposCheque()
               Me.txtCheques.Text = "0.00"

               Me._tarjetas.Clear()
               Me.dgvTarjetas.DataSource = Me._tarjetas
               Me.LimpiarCamposTarjetas()

               Me._retenciones.Clear()
               Me.dgvRetenciones.DataSource = Me._retenciones.ToArray()
               Me.LimpiarCamposRetencion()
               Me.txtRetenciones.Text = "0.00"
               Me.CalcularPagos()
            Else
               Me.tbcDetalle2.Enabled = True
            End If

            tbcDetalle.SelectedTab = tbpComprobantes
            bscCodigoClienteComprobante.Visible = DirectCast(Me.cmbTiposComprobantesRec.SelectedItem, Entidades.TipoComprobante).EsReciboClienteVinculado
            bscClienteComprobante.Visible = bscCodigoClienteComprobante.Visible
            lblCodigoClienteComprobante.Visible = bscCodigoClienteComprobante.Visible
            tbcDetalle.SelectedTab = tbpPagos

         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub cmbTiposComprobantesRec_KeyDown(sender As Object, e As KeyEventArgs) Handles cmbTiposComprobantesRec.KeyDown
      Me.PresionarTab(e)
   End Sub

   Private Sub btnSeleccionMultiple_Click(sender As Object, e As EventArgs) Handles btnSeleccionMultiple.Click
      Try
         'Valido que haya ingresado el cliente. Recien ahi llamo a la ayuda para ahorrar tiempo.
         If Not Me.bscCodigoCliente.Selecciono And Not Me.bscCliente.Selecciono And Not Me.bscBusquedaClienteSecundaria.Selecciono Then
            Exit Sub
         End If

         '-- REQ-31947.- --------------------------------
         ProcesoCalculoInteresCheques()
         '-----------------------------------------------
         Dim IdTipoComprobante As String = String.Empty
         If Me.dgvComprobantes.RowCount > 0 And Me._ComprobantesGrilla IsNot Nothing AndAlso Me._ComprobantesGrilla.Count > 0 Then
            IdTipoComprobante = Me._ComprobantesGrilla(0).TipoComprobante.IdTipoComprobante
         End If
         Dim oCtaCte = New Entidades.CuentaCorriente()
         '-- REG-33207.- ----------------------------------------------------------------
         AntesInsertarRecibo(oCtaCte)
         '-------------------------------------------------------------------------------
         Using oFactAyuda As ComprobantesPendientesAyuda = New ComprobantesPendientesAyuda(GetTipoReciboSeleccionado(),
                                                                                           IdTipoComprobante,
            Long.Parse(Me.bscCodigoCliente.Tag.ToString()),
                                                                                           Me._ComprobantesGrilla,
            GetIdCategoriaClienteSegunParametro(),
            oCtaCte.IdEmbarcacion, oCtaCte.IdCama)
            oFactAyuda.ShowDialog()
            Me.CargarComprobantesSeleccionados(oFactAyuda.ComprobantesSeleccionados)
         End Using
         Me.CalcularTotales()

      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

   Private Sub txtPaga_TextChanged(sender As Object, e As EventArgs) Handles txtPaga.TextChanged
      Try
         CalcularTotalAPagarComprobantePorPorc()
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub chkMontoAplicadoIncluyeIntereses_CheckedChanged(sender As Object, e As EventArgs) Handles chkMontoAplicadoIncluyeIntereses.CheckedChanged
      Try
         CalcularTotalAPagarComprobantePorPorc()
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub chbNroOrdenDeCompra_CheckedChanged(sender As Object, e As EventArgs) Handles chbNroOrdenDeCompra.CheckedChanged
      TryCatched(Sub() chbNroOrdenDeCompra.FiltroCheckedChanged(usaPermitido:=True, bscNroOrdenDeCompra))
   End Sub

   Private Sub bscNroOrdenDeCompra_BuscadorClick() Handles bscNroOrdenDeCompra.BuscadorClick
      TryCatched(
         Sub()
            _publicos.PreparaGrillaOrdenDeCompra(bscNroOrdenDeCompra)
            Dim nroOrdenDeCompra = bscNroOrdenDeCompra.Text.ValorNumericoPorDefecto(0L)
            bscNroOrdenDeCompra.Datos = New Reglas.OrdenesCompra().GetPorCodigo(actual.Sucursal.Id, nroOrdenDeCompra)
         End Sub)
   End Sub

   Private Sub bscNroOrdenDeCompra_BuscadorSeleccion(sender As Object, e As Controles.BuscadorEventArgs) Handles bscNroOrdenDeCompra.BuscadorSeleccion
      TryCatched(
         Sub()
            If e.FilaDevuelta IsNot Nothing Then
               bscNroOrdenDeCompra.Text = e.FilaDevuelta.Cells("NumeroOrdenCompra").Value.ToString()
               bscNroOrdenDeCompra.Permitido = False
            End If
         End Sub)
   End Sub


#End Region

#Region "Metodos"

   Private Sub Nuevo()
      txtTotalPagos.Enabled = True
      bscCodigoCliente.Text = String.Empty
      bscCliente.Text = String.Empty
      'Me.bscCUIT.Text = String.Empty
      MuestraBusquedaClienteSecudaria(Nothing, cmbBusquedaClienteSecundaria.SelectedItem.ToString())
      txtTotalComprobantes.Enabled = True
      bscCodigoCliente.Permitido = True

      bscCliente.Permitido = True
      bscBusquedaClienteSecundaria.Permitido = True
      cmbBusquedaClienteSecundaria.Enabled = True
      txtObservacion.Text = String.Empty
      txtObservacionCliente.Text = String.Empty
      cmbVendedor.SelectedIndex = -1
      cmbCategoria.SelectedIndex = -1
      cmbCategoria.Enabled = False

      chbNroOrdenDeCompra.Checked = False

      txtTotalComprobantes.Text = "0.00"
      cmbDirecciones.Enabled = False
      cmbDirecciones.SelectedIndex = -1
      dtpFechaTransferencia.Value = Date.Now

      '-- REQ-30852 - -
      dtpFecha.Enabled = True
      dtpFecha.Value = Date.Now

      PosicionaSeleccionCombo()

      dtpFechaCalculoInteres.Enabled = True
      dtpFechaCalculoInteres.Checked = False

      txtNumeroPosible.Text = String.Empty
      txtTotalPagos.Text = "0.00"
      txtTotalNCND.Text = "0.00"
      MontoDiferenciaPorPlanesTarjeta = 0
      txtSaldo.Text = String.Empty
      txtLetra.Text = ""
      txtEmisor.Text = ""
      bscComprobante.Text = String.Empty
      txtCuota.Text = ""
      txtImporte.Text = "0.00"
      chbDescuentoRecargoPorc.Checked = Reglas.Publicos.CtaCte.ReciboUtilizaDescuentoRecargo
      txtDescuentoRecargoPorc.Text = "0.00"
      txtPaga.Text = "0.00"
      txtMontoInteresTarjeta.Text = "0.00"
      txtFormaDePago.Tag = ""
      txtFormaDePago.Text = ""
      btnInsertar.Enabled = True
      btnEliminar.Enabled = True
      txtCategoriaFiscal.Text = String.Empty
      tsbGenerarNCND.Visible = True
      tsbGenerarNCND.Enabled = False
      tsbGrabar.Visible = True
      tsbGrabar.Enabled = False
      txtEfectivo.Text = "0.00"
      txtImporteDolares.Text = "0.00"
      txtCheques.Text = "0.00"
      txtTarjetas.Text = "0.00"
      txtSaldoGeneral.Text = "0.00"
      txtSaldoActual.Text = "0.00"
      txtDiferencia.Text = "0.00"
      txtTransferenciaBancaria.Text = "0.00"
      _ImporteAnticipoSinInteres = 0
      bscCuentaBancariaTransfBanc.Text = String.Empty
      bscCuentaBancariaTransfBanc.Tag = Nothing

      _ComprobantesGrilla.Clear()
      dgvComprobantes.DataSource = Me._ComprobantesGrilla.ToArray()
      If Me._tit IsNot Nothing Then
         Me.AjustarColumnasGrilla(Me.dgvComprobantes, Me._tit)
      End If

      _transferencias.Clear()
      ugTransferenciasMultiples.ClearFilas()
      txtImporteTransferenciaMultiple.Text = "0.00"
      'txtTransferenciaBancaria.ReadOnly = False
      txtTransferenciaBancaria.ReadOnly = _transferencias.AnySecure()
      bscCuentaBancariaTransfBanc.Permitido = Not _transferencias.AnySecure()

      'Me.dgvCheques.DataSource = Nothing

      _cheques.Clear()
      dgvCheques.DataSource = Me._cheques.ToArray()
      LimpiarCamposCheque()
      txtCheques.Text = "0.00"

      _tarjetas.Clear()
      dgvTarjetas.DataSource = Me._tarjetas
      LimpiarCamposTarjetas()

      _retenciones.Clear()
      dgvRetenciones.DataSource = Me._retenciones.ToArray()


      tbcDetalle.SelectedTab = Me.tbpPagos
      tbcDetalle.Enabled = True

      _clienteGrilla = Nothing

      LimpiarCamposRetencion()
      txtRetenciones.Text = "0.00"

      '-- REQ-33040.- -------------
      tsbDebeHaber.Enabled = False
      '----------------------------

      If cmbTiposComprobantesRec.Items.Count > 0 Then
         cmbTiposComprobantesRec.SelectedIndex = -1   'Fuerzo el evento de Changed
         cmbTiposComprobantesRec.SelectedIndex = 0
         'Else
         '   Me.cmbTiposComprobantesRec.SelectedIndex = -1
      End If


      CambiarEstadoControlesDetalle(False)

      chbNumeroAutomatico.Checked = True
      chbNumeroAutomatico.Checked = If(cmbTiposComprobantesRec.SelectedIndex = -1, True, cmbTiposComprobantesRec.ItemSeleccionado(Of Entidades.TipoComprobante).NumeracionAutomatica)

      If cmbTiposComprobantesRec.Items.Count > 0 Then
         CargarProximoNumero(Me.cmbTiposComprobantesRec.SelectedValue.ToString())
      End If


      'Me.cmbCajas.SelectedIndex = 0
      cmbCajas.Enabled = True
      _publicos.CargaComboCajas(cmbCajas, actual.Sucursal.IdSucursal, _blnMiraUsuario, _blnMiraPC, _blnCajasModificables)

      cmbTiposComprobantesRec.Enabled = True

      tbcDetalle.SelectedTab = tbpComprobantes
      bscCodigoClienteComprobante.Visible = DirectCast(Me.cmbTiposComprobantesRec.SelectedItem, Entidades.TipoComprobante).EsReciboClienteVinculado
      bscClienteComprobante.Visible = bscCodigoClienteComprobante.Visible
      lblCodigoClienteComprobante.Visible = bscCodigoClienteComprobante.Visible
      tbcDetalle.SelectedTab = tbpPagos

      bscCodigoCliente.Focus()

      chkMontoAplicadoIncluyeIntereses.Checked = Reglas.Publicos.CtaCte.InteresesMontoAplicadoIncluyeIntereses

      txtCotizacionDolar.Text = New Reglas.Monedas().GetUna(Entidades.Moneda.Dolar).FactorConversion.ToString("N2")

      '-- REQ-42455.- ----------------------------------
      txtEmisionPromedioPago.Text = String.Empty
      txtFechaPromedioPago.Text = String.Empty
      txtDiasPromedioPago.Text = "0"
      txtDiasDirectos.Text = "0"
      '-- Comprobantes.- -------------------------------------------------------------- 
      ugDetalle.ClearFilas()
      '-- Pagos.- ---------------------------------------------------------------------
      ugComprobantesMediosPagos.ClearFilas()
      '-------------------------------------------------

   End Sub

   Private Sub CargarProximoNumero(TipoRecibo As String)

      If Me.txtLetraRecibo.Text <> "" Then

         If chbNumeroAutomatico.Checked Then

            Dim oImpresoras As New Reglas.Impresoras
            Dim oVentas As New Reglas.Ventas
            Dim oVentasNumeros As New Reglas.VentasNumeros
            Dim CentroEmisor As Short
            Dim ProximoNumero As Long

            'CentroEmisor = oImpresoras.GetPorSucursalPC(actual.Sucursal.Id, My.Computer.Name, False).CentroEmisor
            CentroEmisor = oImpresoras.GetPorSucursalPCTipoComprobante(actual.Sucursal.Id, My.Computer.Name, Me.cmbTiposComprobantesRec.SelectedValue.ToString()).CentroEmisor

            ProximoNumero = oVentasNumeros.GetProximoNumero(actual.Sucursal, TipoRecibo, Me.txtLetraRecibo.Text, CentroEmisor, Reglas.Publicos.CtaCte.ReciboComparteNumeracionEntreSucursales)

            Do While True
               'Por las dudas que haya digitado mal y al ofrecer el proximo, coincida, luego no lo controla.
               If Not oVentas.Existe(actual.Sucursal.Id, TipoRecibo, Me.txtLetraRecibo.Text, CentroEmisor, ProximoNumero) Then
                  Exit Do
               End If
               ProximoNumero += 1
            Loop

            Me.txtNumeroPosible.Text = ProximoNumero.ToString()

            If Reglas.Publicos.CtaCte.CtaCteClientesSeparar And Me._clienteGrilla IsNot Nothing Then
               'carga el saldo del cliente de la cuenta corriente (Blanco o Negro)
               Dim oCtaCte As Eniac.Reglas.CuentasCorrientes = New Eniac.Reglas.CuentasCorrientes()
               'Dim grabaLibro As String = IIf(New Reglas.TiposComprobantes().GetUno(Me.cmbTiposComprobantesRec.SelectedValue.ToString()).GrabaLibro, "SI", "NO").ToString()
               Dim strComprobantesAsociados As String = New Reglas.TiposComprobantes().GetUno(Me.cmbTiposComprobantesRec.SelectedValue.ToString()).ComprobantesAsociados
               Me.txtSaldoActual.Text = oCtaCte.GetSaldoCliente({actual.Sucursal}, Me._clienteGrilla.IdCliente,
                                                                fechaSaldo:=Nothing,
                                                                contemplaHora:=False,
                                                                comprobantesAsociados:=strComprobantesAsociados,
                                                                grabaLibro:=Nothing,
                                                                comprobantesExcluidos:=Nothing,
                                                                numeroComprobanteFinalizaCon:=String.Empty,
                                                                excluirPreComprobantes:=False,
                                                                IdCama:=_idCama,
                                                                IdEmbarcacion:=_idEmbarcacion).ToString("N2")
            End If

         Else
            txtNumeroPosible.Text = "0"

         End If

      Else

         Me.txtNumeroPosible.Text = ""

         If Reglas.Publicos.CtaCte.CtaCteClientesSeparar Then
            Me.txtSaldoActual.Text = "0.00"
         End If

      End If

   End Sub

   Private Sub CargarDatosCliente(dr As DataGridViewRow)


      'Busco nuevamente los datos del cliente porque podría venir de cualquier otro query que no contenga 
      'los datos necesarios (como por ejemplo al buscar por Embarcación en SiSeN), de esta manera me
      'aseguro que siempre tengo todos los datos.
      Dim idcliente As Long = If(IsNumeric(dr.Cells("IdCliente").Value.ToString()), Long.Parse(dr.Cells("IdCliente").Value.ToString()), 0)
      If idcliente = 0 Then
         Select Case cmbBusquedaClienteSecundaria.SelectedItem.ToString()
            Case BusquedaClienteSecundaria_EMBARCACION
               bscBusquedaClienteSecundaria.Text = dr.Cells("NombreEmbarcacion").Value.ToString()
               _idEmbarcacion = Long.Parse(dr.Cells("idEmbarcacion").Value.ToString())
            Case BusquedaClienteSecundaria_CAMA
               bscBusquedaClienteSecundaria.Text = dr.Cells("CodigoCama").Value.ToString()
               _idCama = Long.Parse(dr.Cells("idCama").Value.ToString())
         End Select

         MessageBox.Show(String.Format("La {0} no posee Cliente Responsable de Cargo Asignado!!!", cmbBusquedaClienteSecundaria.SelectedItem.ToString()), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)

         Exit Sub
      End If

      Dim dtCliente As DataTable = New Reglas.Clientes(Entidades.Cliente.ModoClienteProspecto.Cliente).Get1(idcliente, incluirFoto:=False, puedeVerDetalleValoracionEstrellas:=False)
      Dim drCliente As DataRow = dtCliente.Rows(0)

      Me.bscCliente.Text = drCliente("NombreCliente").ToString()
      Me.bscCodigoCliente.Text = drCliente("CodigoCliente").ToString()
      Me.bscCodigoCliente.Tag = drCliente("IdCliente").ToString()
      'Me.bscCUIT.Text = drCliente("CUIT").ToString()
      MuestraBusquedaClienteSecudaria(dr, cmbBusquedaClienteSecundaria.SelectedItem.ToString())

      With cmbDirecciones
         .DisplayMember = "DireccionAMostrar"
         .ValueMember = "IdDireccion"
         .DataSource = New Reglas.ClientesDirecciones().GetDirecciones(Long.Parse(dr.Cells("IdCliente").Value.ToString()))
         .SelectedIndex = 0
      End With

      Me.cmbDirecciones.Enabled = True

      Me.txtCategoriaFiscal.Text = drCliente("NombreCategoriaFiscal").ToString()
      Me.txtCategoriaFiscal.Tag = drCliente("IdCategoriaFiscal")

      Me.txtEstadoCliente.Text = drCliente("NombreEstadoCliente").ToString()
      Me.txtEstadoCliente.Tag = drCliente("IdEstado").ToString()

      Me.cmbCobrador.SelectedValue = drCliente("IdCobrador")

      Me.txtObservacionCliente.Text = dr.Cells("Observacion").Value.ToString()

      'Si el recibo emite numeracion X siempre debe salir asi, sino, debe tomar la letra del Cliente.
      If Me.txtLetraRecibo.Text <> "X" And Me.txtLetraRecibo.Text <> "R" Then
         Me.txtLetraRecibo.Text = drCliente("LetraFiscal").ToString()
      End If

      Me.tbcDetalle.Enabled = True
      Me.bscCodigoCliente.Permitido = False
      Me.bscCliente.Permitido = False
      Me.bscBusquedaClienteSecundaria.Permitido = False
      cmbBusquedaClienteSecundaria.Enabled = False
      Me.btnImputAutomat.Enabled = True
      Me.btnSeleccionMultiple.Enabled = True

      Me.CambiarEstadoControlesDetalle(True)

      Dim oCliente As Eniac.Reglas.Clientes = New Eniac.Reglas.Clientes()
      Me._clienteGrilla = oCliente.GetUno(Long.Parse(Me.bscCodigoCliente.Tag.ToString()))

      Dim Vend As Reglas.Empleados = New Reglas.Empleados()
      Me.cmbVendedor.SelectedItem = Me.GetVendedorCombo(Integer.Parse(drCliente("IdVendedor").ToString()))

      'carga el saldo del cliente de la cuenta corriente
      Dim oCtaCte As Eniac.Reglas.CuentasCorrientes = New Eniac.Reglas.CuentasCorrientes()
      Me.txtSaldoGeneral.Text = oCtaCte.GetSaldoCliente({actual.Sucursal}, Me._clienteGrilla.IdCliente,
                                                        fechaSaldo:=Nothing,
                                                        contemplaHora:=False,
                                                        comprobantesAsociados:="TODOS",
                                                        grabaLibro:=Nothing,
                                                        comprobantesExcluidos:=Nothing,
                                                        numeroComprobanteFinalizaCon:=String.Empty,
                                                        excluirPreComprobantes:=False,
                                                        IdCama:=_idCama,
                                                        IdEmbarcacion:=_idEmbarcacion).ToString("N2")

      If Reglas.Publicos.CtaCte.CtaCteClientesSeparar Then
         'carga el saldo del cliente de la cuenta corriente (Blanco o Negro)
         'Dim grabaLibro As String = IIf(New Reglas.TiposComprobantes().GetUno(Me.cmbTiposComprobantesRec.SelectedValue.ToString()).GrabaLibro, "SI", "NO").ToString()
         Dim strComprobantesAsociados As String = New Reglas.TiposComprobantes().GetUno(Me.cmbTiposComprobantesRec.SelectedValue.ToString()).ComprobantesAsociados
         Me.txtSaldoActual.Text = oCtaCte.GetSaldoCliente({actual.Sucursal}, Me._clienteGrilla.IdCliente,
                                                          fechaSaldo:=Nothing,
                                                          contemplaHora:=False,
                                                          comprobantesAsociados:=strComprobantesAsociados,
                                                          grabaLibro:=Nothing,
                                                          comprobantesExcluidos:=Nothing,
                                                          numeroComprobanteFinalizaCon:=String.Empty,
                                                          excluirPreComprobantes:=False,
                                                          IdCama:=_idCama,
                                                          IdEmbarcacion:=_idEmbarcacion).ToString("N2")
      Else
         Me.txtSaldoActual.Text = Me.txtSaldoGeneral.Text
      End If

      'GAR: 03/05/2018 - La variable ConsultarAutomaticamente se carga desde facturacion cuando quiere que se aplique una NC mediante una minuta
      'Esto fue pensado para pasar varios los recibos luego de la vuelta de un reparto.
      If Reglas.Publicos.CtaCte.ReciboAplicaSaldoEnPesos And Not ConsultarAutomaticamente Then
         Me.txtEfectivo.Text = Me.txtSaldoActual.Text
      End If

      'Cargo la Caja opcional de la Categoria.

      Dim oCategorias As Reglas.Categorias = New Reglas.Categorias()
      Dim oCateg As Entidades.Categoria
      oCateg = oCategorias.GetUno(Integer.Parse(drCliente("IdCategoria").ToString()))

      Me.cmbCategoria.SelectedValue = oCateg.IdCategoria

      If Reglas.Publicos.CtaCte.ContemplaCategoriaClienteRecibo Then
         Me.cmbCategoria.Enabled = True
      End If

      If oCateg.IdCaja > 0 Then
         Me.cmbCajas.SelectedValue = oCateg.IdCaja
         If Me.cmbCajas.SelectedIndex >= 0 Then
            Me.cmbCajas.Enabled = False
         Else
            Me.cmbCajas.SelectedIndex = 0
         End If
      End If
      If Not String.IsNullOrEmpty(oCateg.IdTipoComprobante) Then
         Me.cmbTiposComprobantesRec.SelectedValue = oCateg.IdTipoComprobante
         If Me.cmbTiposComprobantesRec.SelectedIndex >= 0 Then
            'No lo bloqueo porque se permite hacer minutas
            'Me.cmbTiposComprobantesRec.Enabled = False  
         Else
            Me.cmbTiposComprobantesRec.SelectedIndex = 0
         End If
      End If

      bscCodigoLocalidadRetenciones.Text = _clienteGrilla.Localidad.IdLocalidad.ToString()
      bscCodigoLocalidadRetenciones.PresionarBoton()

      Me.CargarProximoNumero(Me.cmbTiposComprobantesRec.SelectedValue.ToString())

      'controlo los focos y si tengo que solicitar la fecha
      If Reglas.Publicos.CtaCte.ReciboSolicitaFecha Then
         Me.dtpFecha.Focus()
      Else
         Me.txtEfectivo.Focus()
      End If

   End Sub

   Private Sub CargarDatosClienteComprobante(dr As DataGridViewRow)

      Me.bscClienteComprobante.Text = dr.Cells("NombreCliente").Value.ToString()
      Me.bscCodigoClienteComprobante.Text = dr.Cells("CodigoCliente").Value.ToString()
      Me.bscCodigoClienteComprobante.Tag = dr.Cells("IdCliente").Value.ToString()

   End Sub

   Private Sub CambiarEstadoControlesDetalle(Habilitado As Boolean)
      Me.btnLimpiarComprobante.Enabled = Habilitado
      Me.bscComprobante.Enabled = Habilitado
      Me.txtImporte.Enabled = Habilitado
      Me.btnInsertar.Enabled = Habilitado
      Me.btnEliminar.Enabled = Habilitado
   End Sub

   Private Function GetVendedorCombo(id As Integer) As Object
      Dim empleados As List(Of Entidades.Empleado) = DirectCast(Me.cmbVendedor.DataSource, List(Of Entidades.Empleado))
      For Each emp As Entidades.Empleado In empleados
         If id = emp.IdEmpleado Then
            Return emp
         End If
      Next
      Return Nothing
   End Function

   Private Sub CargarDatosBancos(dr As DataGridViewRow)
      If _clienteGrilla Is Nothing Then
         bscCodigoCliente.Focus()
         Throw New Exception("Debe seleccionar primero un cliente")
      End If
      Me.bscBancos.Text = dr.Cells("NombreBanco").Value.ToString()
      Me.bscCodBancos.Text = dr.Cells("IdBanco").Value.ToString()
      If Me._clienteGrilla.Cuit.Length > 0 Then
         Me.txtCUITCheque.Text = Me._clienteGrilla.Cuit
      End If
   End Sub

   Private Sub CargarLocalidad(dr As DataGridViewRow)
      Me.bscCodigoLocalidad.Text = dr.Cells("IdLocalidad").Value.ToString()
   End Sub

   Private Function ValidarInsertarCheques() As Boolean

      If Not Me.bscBancos.Selecciono And Not Me.bscCodBancos.Selecciono Then
         MessageBox.Show("Debe seleccionar un Banco.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
         Me.bscCodBancos.Focus()
         Return False
      End If

      If Integer.Parse(Me.txtSucursalBanco.Text) < 0 Then
         MessageBox.Show("La Sucursal del Banco es inválida.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
         Me.txtSucursalBanco.Focus()
         Return False
      End If

      If Not Me.bscCodigoLocalidad.Selecciono Then
         MessageBox.Show("Debe ingresar y confirmar un C.P. para el cheque.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
         Me.bscCodigoLocalidad.Focus()
         Return False
      Else
         'If Not New Reglas.Localidades().Existe(Integer.Parse(Me.txtCodPostalCheque.Text)) Then
         '   MessageBox.Show("No existe la localidad del Cheque.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
         '   Me.txtCodPostalCheque.Focus()
         '   Return False
         'End If
      End If

      If Long.Parse(Me.txtNroCheque.Text) = 0 Then
         MessageBox.Show("El número de cheque no puede ser cero.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
         Me.txtNroCheque.Focus()
         Return False
      End If

      If Decimal.Parse(Me.txtImporteCheque.Text) <= 0 Then
         MessageBox.Show("No puede ingresar un cheque con importe cero o negativo.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
         Me.txtImporteCheque.Focus()
         Return False
      End If
      If Me.chbProveedor.Checked And Not Me.bscCodigoProveedor.Selecciono And Not Me.bscProveedor.Selecciono Then
         MessageBox.Show("ATENCION: NO seleccionó un Proveedor", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
         Me.bscCodigoProveedor.Focus()
         Return False
      End If

      'Valida fecha cobro sea mayor a fecha emision
      If Me.dtpChequeFechaCobro.Value.Date < Me.dtpChequeFechaEmision.Value.Date Then
         Me.dtpChequeFechaCobro.Focus()
         MessageBox.Show("La Fecha de Cobro NO puede ser menor a la Fecha de Emisión", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
         Return False
      End If


      'controlo que no se repita el cheque ingresado
      Dim ent As Entidades.Cheque
      For i As Integer = 0 To Me._cheques.Count - 1
         ent = Me._cheques(i)
         If ent.NumeroCheque = Integer.Parse(Me.txtNroCheque.Text) And
                  ent.Banco.IdBanco = Integer.Parse(Me.bscCodBancos.Text) And
                  ent.IdBancoSucursal = Integer.Parse(Me.txtSucursalBanco.Text) And
                  ent.Localidad.IdLocalidad = Integer.Parse(Me.bscCodigoLocalidad.Text) Then
            MessageBox.Show("El cheque ya esta ingresado.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return False
         End If
      Next

      If New Reglas.Cheques().Existe(actual.Sucursal.IdSucursal,
                                       Integer.Parse(Me.txtNroCheque.Text),
                                       Integer.Parse(Me.bscCodBancos.Text),
                                       Integer.Parse(Me.txtSucursalBanco.Text),
                                       Integer.Parse(Me.bscCodigoLocalidad.Text),
                                       Me.txtCUITCheque.Text) Then
         MessageBox.Show("El Cheque fué Ingresado con Anterioridad.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
         Me.txtNroCheque.Focus()
         Return False
      End If

      '# Validación del CUIT
      If String.IsNullOrEmpty(Me.txtCUITCheque.Text) Then
         ShowMessage("Debe ingresar un Nro. CUIT para el Cheque.")
         Return False
      Else
         Dim result As Reglas.Validaciones.ValidacionResult
         result = Reglas.Validaciones.Impositivo.ValidarIdFiscal.Instancia.Validar(New Reglas.Validaciones.Impositivo.DatosValidacionFiscal() _
                                                                                     With {.IdFiscal = txtCUITCheque.Text,
                                                                                           .SolicitaCUIT = True}) '# Siempre solicitamos el CUIT al insertar el cheque por la nueva Alternative Key en BD
         If result.Error Then
            txtCUITCheque.Focus()
            ShowMessage(result.MensajeError)
            Return False
         End If
      End If
      '# Tipo de Cheque
      If Me.cmbTipoCheque.SelectedIndex = -1 Then
         Me.cmbTipoCheque.Focus()
         ShowMessage("ATENCIÓN: No seleccionó un Tipo de Cheque")
         Return False
      End If
      If DirectCast(Me.cmbTipoCheque.SelectedItem, Entidades.TiposCheques).SolicitaNroOperacion AndAlso
         String.IsNullOrEmpty(Me.txtNroOperacion.Text) Then
         Me.txtNroOperacion.Focus()
         ShowMessage("ATENCIÓN: Debe ingresar un Número de Operación para el Tipo de Cheque seleccionado.")
         Return False
      End If
      Return True

   End Function
   ''' <summary>
   ''' Proceso para el calculo de Interes Futuro.-
   ''' Recibe fecha y verifica si es mayor a la cargada para el calculo.-
   ''' </summary>
   Private Sub ProcesoCalculoInteresCheques()
      '-- Verifico si debo realizar el procedimiento.- --
      Dim fechaCheque As Date = Nothing
      If Reglas.Publicos.CtaCte.ReciboCalculoInteresFuturos Then
         fechaCheque = If(_cheques.Count > 0, _cheques.Max(Function(x) x.FechaCobro), Nothing)
      End If
      If dtpFechaCalculoInteres.Enabled AndAlso Not dtpFechaCalculoInteres.Checked Then
         CargaFechaCalculoInteres(If((fechaCheque > dtpFecha.Value), fechaCheque, dtpFecha.Value))
      End If
   End Sub

   Private Sub InsertarChequeGrilla()

      Dim oLineaDetalle As Entidades.Cheque = New Entidades.Cheque()

      With oLineaDetalle
         .NombreTipoCheque = Me.cmbTipoCheque.Text
         .Banco = New Reglas.Bancos().GetUno(Integer.Parse(Me.bscCodBancos.Text))
         .IdBancoSucursal = Integer.Parse(Me.txtSucursalBanco.Text)
         .Localidad.IdLocalidad = Integer.Parse(Me.bscCodigoLocalidad.Text)
         .NumeroCheque = Integer.Parse(Me.txtNroCheque.Text)
         .NroOperacion = Me.txtNroOperacion.Text
         .FechaEmision = Me.dtpChequeFechaEmision.Value
         .FechaCobro = Me.dtpChequeFechaCobro.Value
         .Titular = Me.txtTitularCheque.Text
         .Importe = Decimal.Parse(Me.txtImporteCheque.Text)
         .Cliente.IdCliente = Me._clienteGrilla.IdCliente
         .Usuario = actual.Nombre
         .IdEstadoCheque = Entidades.Cheque.Estados.ENCARTERA
         .Cuit = Me.txtCUITCheque.Text
         If Not String.IsNullOrWhiteSpace(Me.bscCodigoProveedor.Text) Then
            .IdProveedorPreasignado = Long.Parse(Me.bscCodigoProveedor.Tag.ToString())
            .CodigoProveedorPreasignado = Long.Parse(Me.bscCodigoProveedor.Text.ToString())
            .ProveedorPreasignado = Me.bscProveedor.Text
         End If
         .IdTipoCheque = Me.cmbTipoCheque.SelectedValue.ToString()
      End With

      Me._cheques.Add(oLineaDetalle)
      '-- REQ-31947.- --------------------------------
      ProcesoCalculoInteresCheques()
      '-----------------------------------------------
      dgvCheques.DataSource = Me._cheques.ToArray()
      dgvCheques.FirstDisplayedScrollingRowIndex = Me.dgvCheques.Rows.Count - 1

      dgvCheques.Refresh()
      LimpiarCamposCheque()
      CalcularPagos()

   End Sub

   Private Sub EliminarLineaCheque()
      _cheques.RemoveAt(Me.dgvCheques.SelectedRows(0).Index)
      dgvCheques.DataSource = Me._cheques.ToArray()
      '-- REQ-31947.- --------------------------------
      ProcesoCalculoInteresCheques()
      '-----------------------------------------------
      CalcularPagos()
   End Sub

   Private Sub LimpiarCamposCheque()
      bscBancos.Text = ""
      bscCodBancos.Text = ""
      bscBancos.FilaDevuelta = Nothing
      bscCodBancos.FilaDevuelta = Nothing
      dtpChequeFechaCobro.Value = Date.Now
      dtpChequeFechaEmision.Value = Date.Now
      txtImporteCheque.Text = "0.00"
      txtNroCheque.Text = "0"
      bscCodigoLocalidad.Text = "0"
      txtSucursalBanco.Text = "0"
      txtTitularCheque.Text = ""
      txtCUITCheque.Text = ""
      txtNroOperacion.Clear()
      cmbTipoCheque.SelectedValue = "F"
      chbProveedor.Checked = False
   End Sub

   Private Sub CargarChequeCompleto(dr As DataGridViewRow)

      bscBancos.Text = dr.Cells("gchNombreBanco").Value.ToString()
      bscBancos.PresionarBoton()

      txtSucursalBanco.Text = dr.Cells("gchIdBancoSucursal").Value.ToString()

      bscCodigoLocalidad.Text = dr.Cells("gchCP").Value.ToString()
      bscCodigoLocalidad.PresionarBoton()
      txtNroCheque.Text = dr.Cells("gchNumeroCheque").Value.ToString()
      dtpChequeFechaEmision.Value = Date.Parse(dr.Cells("gchFechaEmision").Value.ToString())
      dtpChequeFechaCobro.Value = Date.Parse(dr.Cells("gchFechaCobro").Value.ToString())
      txtTitularCheque.Text = dr.Cells("gchTitular").Value.ToString()
      txtImporteCheque.Text = Decimal.Parse(dr.Cells("gchImporte").Value.ToString()).ToString("#,##0.00")
      txtCUITCheque.Text = dr.Cells("Cuit").Value.ToString()

      If IsNumeric(dr.Cells(IdProveedorPreasignado.Name).Value) AndAlso Long.Parse(dr.Cells(IdProveedorPreasignado.Name).Value.ToString()) > 0 Then
         chbProveedor.Checked = True
         bscCodigoProveedor.Text = dr.Cells(CodigoProveedorPreasignado.Name).Value.ToString()
         bscCodigoProveedor.PresionarBoton()
      End If

      cmbTipoCheque.SelectedValue = dr.Cells("IdTipoCheque").Value.ToString()
      txtNroOperacion.Text = dr.Cells("NroOperacion").Value.ToString()

   End Sub

   Private Sub dtpFecha_ValueChanged(sender As Object, e As EventArgs) Handles dtpFecha.ValueChanged
      '-- REQ-31947.- ----------------------------------
      ProcesoCalculoInteresCheques()
      '-- REQ-42455.- ----------------------------------
      If _cargoBienLaPantalla Then
         CalculoPromedioPagoPonderados()
      End If
      '-------------------------------------------------
   End Sub

   Private Sub CargaFechaCalculoInteres(fechaInteres As Date)
      dtpFechaCalculoInteres.Tag = dtpFechaCalculoInteres.Checked
      dtpFechaCalculoInteres.Value = fechaInteres
      dtpFechaCalculoInteres.Checked = CBool(dtpFechaCalculoInteres.Tag)
   End Sub

   Private Function ValidarInsertarRetenciones() As Boolean

      If _clienteGrilla Is Nothing Then
         MessageBox.Show("Debe seleccionar un Cliente.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
         Me.bscCodigoCliente.Focus()
         Return False
      End If

      If Me.cmbTipoImpuesto.SelectedIndex = -1 Then
         MessageBox.Show("Debe seleccionar un Tipo de Impuesto.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
         Me.cmbTipoImpuesto.Focus()
         Return False
      End If

      If cmbProvinciaRetencion.Visible And cmbProvinciaRetencion.SelectedIndex = -1 Then
         ShowMessage("Debe seleccionar una Provincia.")
         Me.cmbProvinciaRetencion.Focus()
         Return False
      End If

      If Integer.Parse(Me.txtRetencionEmisor.Text) = 0 Then
         MessageBox.Show("El Emisor de Retencion no puede ser cero.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
         Me.txtRetencionEmisor.Focus()
         Return False
      End If

      If Long.Parse(Me.txtRetencionNumero.Text) = 0 Then
         MessageBox.Show("El Número de Retencion no puede ser cero.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
         Me.txtRetencionNumero.Focus()
         Return False
      End If

      'Solo Valido la base imposible si no digito el total, sino, toma solo eso.
      If Decimal.Parse(Me.txtRetencionImporteTotal.Text) = 0 Then
         If Decimal.Parse(Me.txtRetencionBaseImponible.Text) <= 0 Then
            MessageBox.Show("No puede ingresar una Base Imponible cero o negativa.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.txtRetencionBaseImponible.Focus()
            Return False
         End If

         If Decimal.Parse(Me.txtRetencionAlicuota.Text) <= 0 Then
            MessageBox.Show("No puede ingresar una Alicuota cero o negativa.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.txtRetencionAlicuota.Focus()
            Return False
         End If
      End If


      If Decimal.Parse(Me.txtRetencionImporteTotal.Text) <= 0 Then
         MessageBox.Show("No puede ingresar un Retencion con importe cero o negativo.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
         Me.txtRetencionImporteTotal.Focus()
         Return False
      End If

      If Me.cmbTipoImpuesto.SelectedValue.ToString() = "RIVA" Then
         Dim oPF As Reglas.PeriodosFiscales = New Reglas.PeriodosFiscales()
         Dim dt As DataTable = oPF.Get1(actual.Sucursal.IdEmpresa, Integer.Parse(Me.dtpRetencionFechaEmision.Value.ToString("yyyyMM")))
         If dt.Rows.Count = 0 Then
            MessageBox.Show("La Fecha del Comprobante pertenece a un Periodo Fiscal que aún NO esta habilitado.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.dtpRetencionFechaEmision.Focus()
            Return False
         ElseIf Not String.IsNullOrEmpty(dt.Rows(0)("FechaCierre").ToString()) Then
            MessageBox.Show("La Fecha del Comprobante pertenece a un Periodo Fiscal Cerrado.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.dtpRetencionFechaEmision.Focus()
            Return False
         End If
      End If

      If Me.cmbTipoImpuesto.SelectedValue.ToString() = Entidades.TipoImpuesto.Tipos.RDREI.ToString() Then
         If Not bscCodigoLocalidadRetenciones.Selecciono And Not bscNombreLocalidadRetenciones.Selecciono Then
            ShowMessage("Debe seleccionar una localidad.")
            Me.bscCodigoLocalidadRetenciones.Focus()
            Return False
         End If
      End If

      'controlo que no se repita el Retencion ingresado
      Dim ent As Entidades.Retencion
      For i As Integer = 0 To Me._retenciones.Count - 1
         ent = Me._retenciones(i)
         If ent.IdSucursal = actual.Sucursal.IdSucursal And
                  ent.TipoImpuesto.IdTipoImpuesto = DirectCast([Enum].Parse(GetType(Entidades.TipoImpuesto.Tipos), Me.cmbTipoImpuesto.SelectedValue.ToString()), Entidades.TipoImpuesto.Tipos) And
                  ent.EmisorRetencion = Integer.Parse(Me.txtRetencionEmisor.Text) And
                  ent.NumeroRetencion = Long.Parse(Me.txtRetencionNumero.Text) Then
            MessageBox.Show("El Retencion ya esta ingresado.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return False
         End If
      Next

      Return True

   End Function

   Private Sub InsertarRetencionGrilla()

      Dim oLineaDetalle As Entidades.Retencion = New Entidades.Retencion()

      With oLineaDetalle
         .IdSucursal = actual.Sucursal.IdSucursal
         .TipoImpuesto = New Reglas.TiposImpuestos().GetUno(DirectCast([Enum].Parse(GetType(Eniac.Entidades.TipoImpuesto.Tipos), Me.cmbTipoImpuesto.SelectedValue.ToString()), Entidades.TipoImpuesto.Tipos))
         .EmisorRetencion = Integer.Parse(Me.txtRetencionEmisor.Text)
         .NumeroRetencion = Long.Parse(Me.txtRetencionNumero.Text)
         .FechaEmision = Me.dtpRetencionFechaEmision.Value
         .BaseImponible = Decimal.Parse(Me.txtRetencionBaseImponible.Text)
         .Alicuota = Decimal.Parse(Me.txtRetencionAlicuota.Text)
         .ImporteTotal = Decimal.Parse(Me.txtRetencionImporteTotal.Text)
         .Cliente.IdCliente = Me._clienteGrilla.IdCliente
         .Usuario = actual.Nombre
         .IdEstado = Entidades.Retencion.Estados.APLICADO
         If .TipoImpuesto.IdTipoImpuesto = Entidades.TipoImpuesto.Tipos.RDREI Then
            .Localidad = New Reglas.Localidades().GetUna(If(IsNumeric(bscCodigoLocalidadRetenciones.Text), Integer.Parse(bscCodigoLocalidadRetenciones.Text), 0))
         Else
            If cmbProvinciaRetencion.SelectedIndex > -1 Then
               .Provincia = New Reglas.Provincias().GetUno(cmbProvinciaRetencion.SelectedValue.ToString())
            End If
         End If
      End With

      Me._retenciones.Add(oLineaDetalle)

      Me.dgvRetenciones.DataSource = Me._retenciones.ToArray()
      Me.dgvRetenciones.FirstDisplayedScrollingRowIndex = Me.dgvRetenciones.Rows.Count - 1

      Me.dgvRetenciones.Refresh()
      Me.LimpiarCamposRetencion()
      Me.CalcularPagos()

   End Sub

   Private Sub EliminarLineaRetencion()
      Me._retenciones.RemoveAt(Me.dgvRetenciones.SelectedRows(0).Index)
      Me.dgvRetenciones.DataSource = Me._retenciones.ToArray()
      Me.CalcularPagos()
   End Sub

   Private Sub LimpiarCamposRetencion()
      Me.cmbTipoImpuesto.SelectedIndex = -1
      If _clienteGrilla Is Nothing Then
         Me.cmbProvinciaRetencion.SelectedIndex = -1
         bscCodigoLocalidadRetenciones.Text = "0"
         bscNombreLocalidadRetenciones.Text = ""
      Else
         Me.cmbProvinciaRetencion.SelectedValue = _clienteGrilla.Localidad.IdProvincia
         bscCodigoLocalidadRetenciones.Text = _clienteGrilla.Localidad.IdLocalidad.ToString()
         bscCodigoLocalidadRetenciones.PresionarBoton()
      End If

      Me.txtRetencionEmisor.Text = "0"
      Me.txtRetencionNumero.Text = "0"
      Me.dtpRetencionFechaEmision.Value = Date.Now
      Me.txtRetencionBaseImponible.Text = "0.00"
      Me.txtRetencionAlicuota.Text = "0.00"
      Me.txtRetencionImporteTotal.Text = "0.00"
   End Sub

   Private Sub CargarRetencionCompleto(dr As DataGridViewRow)
      Me.cmbTipoImpuesto.SelectedValue = dr.Cells("gretIdTipoImpuesto").Value.ToString()
      If dr.Cells("gretIdProvincia").Value IsNot Nothing Then
         cmbProvinciaRetencion.SelectedValue = dr.Cells("gretIdProvincia").Value.ToString()
      Else
         cmbProvinciaRetencion.SelectedIndex = -1
      End If

      If dr.Cells("gretIdTipoImpuesto").Value.ToString() = Entidades.TipoImpuesto.Tipos.RDREI.ToString() Then
         bscCodigoLocalidadRetenciones.Text = dr.Cells("gretIdLocalidad").Value.ToString()
         bscCodigoLocalidadRetenciones.PresionarBoton()
      End If

      Me.txtRetencionEmisor.Text = dr.Cells("gretEmisorRetencion").Value.ToString()
      Me.txtRetencionNumero.Text = dr.Cells("gretNumeroRetencion").Value.ToString()
      Me.dtpRetencionFechaEmision.Value = Date.Parse(dr.Cells("gretFechaEmision").Value.ToString())
      Me.txtRetencionBaseImponible.Text = dr.Cells("gretBaseImponible").Value.ToString()
      Me.txtRetencionAlicuota.Text = dr.Cells("gretAlicuota").Value.ToString()
      Me.txtRetencionImporteTotal.Text = dr.Cells("gretImporteTotal").Value.ToString()
   End Sub

   Private Function ValidarInsertarComprobante() As Boolean

      If Not Me.bscComprobante.Selecciono Then
         MessageBox.Show("Debe Seleccionar el Comprobante", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
         Me.bscComprobante.Focus()
         Return False
      End If

      If DirectCast(Me.cmbTiposComprobantes.SelectedItem, Entidades.TipoComprobante).EsAnticipo And Decimal.Parse(Me.txtDescuentoRecargoPorc.Text) <> 0 Then
         MessageBox.Show("El Tipo de Comprobante 'ANTICIPO' NO permite asignarle un Descuento/Recargo.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
         Me.txtDescuentoRecargoPorc.Focus()
         Return False
      End If

      Dim DescuentoRecargo As Decimal
      DescuentoRecargo = Decimal.Parse(Me.txtPaga.Text) - Decimal.Round(Decimal.Parse(Me.txtPaga.Text) / (1 + Decimal.Parse(Me.txtDescuentoRecargoPorc.Text) / 100), 2)

      'Positivos: Facturas, Notas de Debito, otros.
      If Decimal.Parse(Me.txtImporte.Text) > 0 Then

         If Decimal.Parse(Me.txtPaga.Text) <= 0 Then
            MessageBox.Show("El importe a cancelar NO puede ser menor o igual a cero.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.txtPaga.Focus()
            Return False
         End If

         If chkMontoAplicadoIncluyeIntereses.Checked Then
            If Decimal.Parse(Me.txtPaga.Text) - Decimal.Parse(Me.txtDescuentoRecargoImporte.Text) > Decimal.Parse(Me.txtSaldo.Text) Then
               MessageBox.Show("No puede pagar mas de lo que tiene como saldo.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
               Me.txtPaga.Focus()
               Return False
            End If
         Else
            If Decimal.Parse(Me.txtPaga.Text) > Decimal.Parse(Me.txtSaldo.Text) Then
               MessageBox.Show("No puede pagar mas de lo que tiene como saldo.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
               Me.txtPaga.Focus()
               Return False
            End If
         End If

         'If Decimal.Parse(Me.txtPaga.Text) + DescuentoRecargo * (-1) > Decimal.Parse(Me.txtSaldo.Text) Then
         '   MessageBox.Show("No puede Pagar mas de lo que tiene como Saldo (Incluyendo el Descuento/Recargo).", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
         '   Me.txtPaga.Focus()
         '   Return False
         'End If


         'Nota de Credito
      Else

         If Decimal.Parse(Me.txtPaga.Text) >= 0 Then
            MessageBox.Show("El importe a cancelar NO puede ser mayor o igual a cero.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.txtPaga.Focus()
            Return False
         End If

         If Decimal.Parse(Me.txtPaga.Text) < Decimal.Parse(Me.txtSaldo.Text) Then
            MessageBox.Show("No puede pagar mas de lo que tiene como saldo.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.txtPaga.Focus()
            Return False
         End If

         'If Decimal.Parse(Me.txtPaga.Text) + DescuentoRecargo * (-1) < Decimal.Parse(Me.txtSaldo.Text) Then
         '   MessageBox.Show("No puede Pagar mas de lo que tiene como Saldo (Incluyendo el Descuento/Recargo).", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
         '   Me.txtPaga.Focus()
         '   Return False
         'End If

      End If

      'If Me._ComprobantesGrilla.Count = cant Then
      '   MessageBox.Show("No puede ingresar mas de " & cant.ToString() & " productos para este tipo de comprobante.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      '   Me.btnInsertar.Focus()
      '   Return False
      'End If

      'controlo que no se repita el producto ingresado
      Dim ent As Entidades.CuentaCorrientePago
      For i As Integer = 0 To Me._ComprobantesGrilla.Count - 1
         ent = Me._ComprobantesGrilla(i)
         If ent.IdTipoComprobante = Me.cmbTiposComprobantes.SelectedValue.ToString() And
                  ent.Letra = Me.txtLetra.Text And
                  ent.CentroEmisor = Integer.Parse(Me.txtEmisor.Text) And
                  ent.NumeroComprobante = Long.Parse(Me.bscComprobante.Text) And
                  ent.Cuota = Integer.Parse(Me.txtCuota.Text) Then
            MessageBox.Show("La cuota de este comprobante ya esta ingresado.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return False
         End If
      Next

      Return True

   End Function

   Private Sub CalcularTotalAPagarComprobantePorImporte()
      Dim DescRec1 As Decimal

      Dim importeParaCalculo As Decimal = 0
      If Reglas.Publicos.CtaCte.InteresesCalculoCompletoPrimerPago Then
         If IsNumeric(Me.txtSaldo.Text) Then
            importeParaCalculo = Decimal.Parse(Me.txtSaldo.Text)
         End If
      Else
         If IsNumeric(Me.txtPaga.Text) Then
            importeParaCalculo = Decimal.Parse(Me.txtPaga.Text)
         End If
      End If

      DescRec1 = Decimal.Parse(txtDescuentoRecargoImporte.Text)

      If chkMontoAplicadoIncluyeIntereses.Checked And Not Reglas.Publicos.CtaCte.InteresesCalculoCompletoPrimerPago Then
         Me.txtDescuentoRecargoPorc.Text = ((importeParaCalculo / ((importeParaCalculo - DescRec1) / 100)) - 100).ToString("N2")

         'Me.txtDescuentoRecargoPorc.Text = ((DescRec1 / importeParaCalculo) * 100).ToString("N2")
      Else
         Me.txtDescuentoRecargoPorc.Text = ((DescRec1 / importeParaCalculo) * 100).ToString("N2")
      End If

      'txtDescuentoRecargoImporte.Text = DescRec1.ToString("N2")
   End Sub

   Private Sub CalcularTotalAPagarComprobantePorPorc()
      Dim DescRec1 As Decimal

      If IsNumeric(txtDescuentoRecargoPorc.Text) AndAlso Decimal.Parse(Me.txtDescuentoRecargoPorc.Text) < 0 Then
         chkMontoAplicadoIncluyeIntereses.Checked = False
      End If

      Dim importeParaCalculo As Decimal = 0
      If Reglas.Publicos.CtaCte.InteresesCalculoCompletoPrimerPago Then
         If IsNumeric(Me.txtSaldo.Text) Then
            importeParaCalculo = Decimal.Parse(Me.txtSaldo.Text)
         End If
      Else
         If IsNumeric(Me.txtPaga.Text) Then
            importeParaCalculo = Decimal.Parse(Me.txtPaga.Text)
         End If
      End If

      If chkMontoAplicadoIncluyeIntereses.Checked And Not Reglas.Publicos.CtaCte.InteresesCalculoCompletoPrimerPago Then
         DescRec1 = importeParaCalculo - Math.Round(importeParaCalculo / (100 + Decimal.Parse(Me.txtDescuentoRecargoPorc.Text)) * 100, 2)
      Else
         DescRec1 = importeParaCalculo * Decimal.Parse(Me.txtDescuentoRecargoPorc.Text) / 100
      End If

      If DescRec1 > 0 And Reglas.Publicos.CtaCte.MontoMinimoInteresPermitido > DescRec1 Then
         txtDescuentoRecargoImporte.Text = "0.00"
      Else
         txtDescuentoRecargoImporte.Text = DescRec1.ToString("N2")
      End If

   End Sub

   Private Sub InsertarComprobanteGrilla()

      Dim oLineaDetalle As Entidades.CuentaCorrientePago = New Entidades.CuentaCorrientePago()

      With oLineaDetalle
         .IdSucursal = actual.Sucursal.IdSucursal
         .TipoComprobante = DirectCast(Me.cmbTiposComprobantes.SelectedItem, Entidades.TipoComprobante)
         .Letra = Me.txtLetra.Text
         .CentroEmisor = Integer.Parse(Me.txtEmisor.Text)
         .NumeroComprobante = Long.Parse(Me.bscComprobante.Text)
         .Cuota = Integer.Parse(Me.txtCuota.Text)
         .FechaEmision = Me.dtpComprobanteFechaEmision.Value
         .FechaVencimiento = Me.dtpComprobanteFechaVencimiento.Value
         .FormaPago.DescripcionFormasPago = Me.txtFormaDePago.Text
         .ImporteCuota = Decimal.Parse(Me.txtImporte.Text)
         .NombreMoneda = Me.txtNombreMoneda.Text
         .SaldoCuota = Decimal.Parse(Me.txtSaldo.Text)
         .DescuentoRecargoPorc = Decimal.Parse(Me.txtDescuentoRecargoPorc.Text)
         .DescuentoRecargo = Decimal.Parse(Me.txtDescuentoRecargoImporte.Text)  ''.Paga - Decimal.Round(.Paga / (1 + .DescuentoRecargoPorc / 100), 2)
         If chkMontoAplicadoIncluyeIntereses.Checked Then
            .Paga = Decimal.Parse(Me.txtPaga.Text) - .DescuentoRecargo
         Else
            .Paga = Decimal.Parse(Me.txtPaga.Text)
         End If
         .MontoAplicadoIncluyeIntereses = chkMontoAplicadoIncluyeIntereses.Checked

         .CuentaCorriente.Cliente = New Entidades.Cliente()
         .CuentaCorriente.Cliente.IdCliente = Long.Parse(bscCodigoClienteComprobante.Tag.ToString())
         .CuentaCorriente.Cliente.CodigoCliente = Long.Parse(bscCodigoClienteComprobante.Text.ToString())
         .CuentaCorriente.Cliente.NombreCliente = bscCliente.Text.ToString()

         'If .DescuentoRecargoPorc <> 0 Then
         '   .Paga = Decimal.Parse(Me.txtPaga.Text) ''+ .DescuentoRecargo * (-1)
         'End If

         '.FormaPago = New Reglas.VentasFormasPago().GetUna(Integer.Parse(Me.txtFormaDePago.Tag.ToString()))

         .Usuario = actual.Nombre
      End With

      Me._ComprobantesGrilla.Add(oLineaDetalle)

      Me.dgvComprobantes.DataSource = Me._ComprobantesGrilla.ToArray()
      Me.AjustarColumnasGrilla(Me.dgvComprobantes, Me._tit)
      Me.dgvComprobantes.FirstDisplayedScrollingRowIndex = Me.dgvComprobantes.Rows.Count - 1

      Me.dgvComprobantes.Refresh()
      Me.LimpiarCamposComprobante()
      Me.CalcularTotales()

   End Sub

   Private Sub EliminarLineaComprobante()
      Me._ComprobantesGrilla.RemoveAt(Me.dgvComprobantes.SelectedRows(0).Index)
      Me.dgvComprobantes.DataSource = Me._ComprobantesGrilla.ToArray()
      Me.AjustarColumnasGrilla(Me.dgvComprobantes, Me._tit)

      Me.CalcularTotales()
   End Sub

   Private Sub LimpiarCamposComprobante()
      If Me.cmbTiposComprobantes.Items.Count > 0 Then
         Me.cmbTiposComprobantes.SelectedIndex = -1
      End If
      Me.txtLetra.Text = ""
      Me.txtEmisor.Text = ""
      Me.bscComprobante.Text = ""
      Me.bscComprobante.FilaDevuelta = Nothing
      Me.txtCuota.Text = ""
      Me.dtpComprobanteFechaEmision.Value = Date.Now
      Me.dtpComprobanteFechaVencimiento.Value = Date.Now
      Me.txtImporte.Text = "0.00"
      Me.txtSaldo.Text = "0.00"
      Me.txtDescuentoRecargoPorc.Text = "0.00"
      Me.txtDescuentoRecargoImporte.Text = "0.00"
      Me.txtPaga.Text = "0.00"
      Me.txtFormaDePago.Tag = ""
      Me.txtFormaDePago.Text = ""
      Me.txtNombreMoneda.Clear()

      txtDescuentoRecargoImporte.ReadOnly = Not _permiteModificarImporteIntereses
      txtDescuentoRecargoImporte.TabStop = _permiteModificarImporteIntereses

      bscClienteComprobante.Text = String.Empty
      bscCodigoClienteComprobante.Text = String.Empty
      bscCodigoClienteComprobante.Tag = Nothing

   End Sub

   Private Sub InsertarComprobanteAutomatico(Comprobante As Entidades.Venta)

      Dim oLineaDetalle As Entidades.CuentaCorrientePago = New Entidades.CuentaCorrientePago()

      With oLineaDetalle
         .TipoComprobante = Comprobante.TipoComprobante
         .Letra = Comprobante.LetraComprobante
         .CentroEmisor = Comprobante.CentroEmisor
         .NumeroComprobante = Comprobante.NumeroComprobante
         .Cuota = 1
         .FechaEmision = Comprobante.Fecha
         .FechaVencimiento = Comprobante.Fecha.AddDays(Me._idFormaDePagoCtaCte)
         .ImporteCuota = Comprobante.ImporteTotal
         .SaldoCuota = Comprobante.ImporteTotal
         .Paga = Comprobante.ImporteTotal
         .DescuentoRecargoPorc = 0
         .DescuentoRecargo = 0
         .IdSucursal = actual.Sucursal.IdSucursal
         .Usuario = actual.Nombre
      End With

      Me._ComprobantesGrilla.Add(oLineaDetalle)

      Me.dgvComprobantes.DataSource = Me._ComprobantesGrilla.ToArray()
      Me.AjustarColumnasGrilla(Me.dgvComprobantes, Me._tit)
      Me.dgvComprobantes.FirstDisplayedScrollingRowIndex = Me.dgvComprobantes.Rows.Count - 1

      Me.dgvComprobantes.Refresh()
      'Me.LimpiarCamposComprobante()
      Me.CalcularTotales()

   End Sub

   Private Sub CalcularTotales()

      Dim TotalComprobantes As Decimal = 0
      Dim TotalNCND As Decimal = 0

      For i As Integer = 0 To Me._ComprobantesGrilla.Count - 1

         TotalComprobantes += Me._ComprobantesGrilla(i).Paga

         TotalNCND += Me._ComprobantesGrilla(i).DescuentoRecargo

      Next
      If MontoDiferenciaPorPlanesTarjeta > 0 Then
         TotalNCND = TotalNCND + MontoDiferenciaPorPlanesTarjeta
      End If
      'Si el boton es visible es porque todavia no lo genero, entonces lo sumo para facili
      If Me.tsbGenerarNCND.Visible Then
         TotalComprobantes += TotalNCND
      End If

      Me.txtTotalComprobantes.Text = TotalComprobantes.ToString("#,##0.00")

      Me.txtDiferencia.Text = (Decimal.Parse(Me.txtTotalComprobantes.Text) - Decimal.Parse(Me.txtTotalPagos.Text)).ToString("#,##0.00")

      Me.txtTotalNCND.Text = TotalNCND.ToString("#,##0.00")

      Me.VerificarBotonesDeBarra()
      Me.EvaluaHabilitarFecha()
   End Sub

   Private Sub CargarComprobante(dr As DataGridViewRow)
      Me.cmbTiposComprobantesRec.Enabled = False
      Me.cmbTiposComprobantes.SelectedValue = dr.Cells("IdTipoComprobante").Value.ToString()
      Me.txtLetra.Text = dr.Cells("Letra").Value.ToString()
      Me.txtEmisor.Text = dr.Cells("Emisor").Value.ToString()
      Me.bscComprobante.Text = dr.Cells("Numero").Value.ToString()
      Me.txtCuota.Text = dr.Cells("Cuota").Value.ToString()
      Me.dtpComprobanteFechaEmision.Value = Date.Parse(dr.Cells("Fecha").Value.ToString())
      Me.dtpComprobanteFechaVencimiento.Value = Date.Parse(dr.Cells("FechaVencimiento").Value.ToString())
      Me.txtImporte.Text = Decimal.Parse(dr.Cells("Importe").Value.ToString()).ToString("#,##0.00")
      Me.txtNombreMoneda.Text = dr.Cells("NombreMoneda").Value.ToString()
      Me.txtSaldo.Text = Decimal.Parse(dr.Cells("Saldo").Value.ToString()).ToString("#,##0.00")
      Me.txtDescuentoRecargoPorc.Text = "0.00"
      Me.txtPaga.Text = Me.txtSaldo.Text
      Me.txtFormaDePago.Tag = dr.Cells("IdFormasPago").Value.ToString()
      Me.txtFormaDePago.Text = New Reglas.VentasFormasPago().GetUna(Integer.Parse(Me.txtFormaDePago.Tag.ToString())).DescripcionFormasPago


      Me.txtDescuentoRecargoPorc.Text = ReciboPorcentajeDescuentoRecargo(DirectCast(cmbTiposComprobantesRec.SelectedItem, Entidades.TipoComprobante),
                                                                         Integer.Parse(dr.Cells("IdCategoria").Value.ToString()),
                                                                         Date.Parse(dr.Cells("Fecha").Value.ToString()),
                                                                         Date.Parse(dr.Cells("FechaVencimiento").Value.ToString()), dtpFechaCalculoInteres.Value,
                                                                         Decimal.Parse(dr.Cells("Importe").Value.ToString()),
                                                                         Decimal.Parse(dr.Cells("Saldo").Value.ToString())).ToString("N2")

      bscCodigoClienteComprobante.Visible = True
      bscCodigoClienteComprobante.Permitido = True

      bscCodigoClienteComprobante.Text = dr.Cells("CodigoCliente").Value.ToString()
      bscCodigoClienteComprobante.PresionarBoton()

      bscCodigoClienteComprobante.Visible = lblCodigoClienteComprobante.Visible
      bscCodigoClienteComprobante.Permitido = False

      CalcularTotalAPagarComprobantePorPorc()

   End Sub

   Function ReciboPorcentajeDescuentoRecargo(tipoRecibo As Entidades.TipoComprobante, idCategoria As Integer, fechaComprobante As DateTime, fechaVencimiento As DateTime, fechaRecibo As DateTime, importeTotal As Decimal, saldo As Decimal) As Decimal
      Dim result As Decimal = 0

      result = New Reglas.Ventas().ReciboPorcentajeDescuentoRecargo(tipoRecibo, idCategoria, fechaComprobante, fechaVencimiento, fechaRecibo, importeTotal, saldo)

      Return result
   End Function

   Private Sub CargarComprobanteCompleto(dr As DataGridViewRow)

      Me.cmbTiposComprobantes.SelectedValue = dr.Cells("gcoIdTipoComprobante").Value.ToString()
      Me.txtLetra.Text = dr.Cells("gcoLetra").Value.ToString()
      Me.txtEmisor.Text = dr.Cells("gcoCentroEmisor").Value.ToString()
      Me.bscComprobante.Text = dr.Cells("gcoNumeroComprobante").Value.ToString()
      Me.bscComprobante.Selecciono = True
      Me.txtCuota.Text = dr.Cells("gcoCuota").Value.ToString()
      Me.dtpComprobanteFechaEmision.Value = Date.Parse(dr.Cells("gcoFechaEmision").Value.ToString())
      Me.dtpComprobanteFechaVencimiento.Value = Date.Parse(dr.Cells("gcoFechaVencimiento").Value.ToString())
      Me.txtImporte.Text = Decimal.Parse(dr.Cells("gcoImporteCuota").Value.ToString()).ToString("#,##0.00")
      Me.txtSaldo.Text = Decimal.Parse(dr.Cells("gcoSaldoCuota").Value.ToString()).ToString("#,##0.00")
      Me.txtNombreMoneda.Text = dr.Cells("NombreMoneda").Value.ToString()

      txtFormaDePago.Text = dr.Cells("FomaPagoDesc").Value.ToString()

      chkMontoAplicadoIncluyeIntereses.Checked = Boolean.Parse(dr.Cells("MontoAplicadoIncluyeIntereses").Value.ToString())

      Dim Paga As Decimal
      Paga = Decimal.Parse(dr.Cells("gcoPaga").Value.ToString()) ''+ Decimal.Parse(dr.Cells("gcoDescuentoRecargo").Value.ToString())
      If chkMontoAplicadoIncluyeIntereses.Checked Then
         Paga = Paga + Decimal.Parse(dr.Cells("gcoDescuentoRecargo").Value.ToString())
      End If

      Me.txtPaga.Text = Paga.ToString("N2")
      Me.txtDescuentoRecargoPorc.Text = Decimal.Parse(dr.Cells("gcoDescuentoRecargoPorc").Value.ToString()).ToString("N2")
      Me.txtDescuentoRecargoImporte.Text = Decimal.Parse(dr.Cells("gcoDescuentoRecargo").Value.ToString()).ToString("N2")

      bscCodigoClienteComprobante.Visible = True
      bscCodigoClienteComprobante.Permitido = True

      bscCodigoClienteComprobante.Text = dr.Cells("CodigoCliente").Value.ToString()
      bscCodigoClienteComprobante.PresionarBoton()

      bscCodigoClienteComprobante.Visible = lblCodigoClienteComprobante.Visible
      bscCodigoClienteComprobante.Permitido = False


   End Sub

   Private Sub CalcularPagos()

      Dim totalComprobantes = txtTotalComprobantes.ValorNumericoPorDefecto(0D)

      Dim pesos = txtEfectivo.ValorNumericoPorDefecto(0D)
      Dim dolaresConvertidos = txtImporteDolares.ValorNumericoPorDefecto(0D) * txtCotizacionDolar.ValorNumericoPorDefecto(0D)
      Dim transferencia = txtTransferenciaBancaria.ValorNumericoPorDefecto(0D)

      If bscCuentaBancariaTransfBanc.Tag IsNot Nothing AndAlso DirectCast(bscCuentaBancariaTransfBanc.Tag, Entidades.CuentaBancaria).Moneda.IdMoneda = Entidades.Moneda.Dolar Then
         transferencia *= txtCotizacionDolar.ValorNumericoPorDefecto(0D)
      End If

      Dim totalCheques = _cheques.Sum(Function(x) x.Importe)
      Dim totalRetenciones = _retenciones.Sum(Function(x) x.ImporteTotal)
      Dim totalTarjetas = _tarjetas.Sum(Function(x) x.Monto)

      Dim totalPagos = pesos + dolaresConvertidos + totalTarjetas + transferencia + totalCheques + totalRetenciones

      txtCheques.Text = totalCheques.ToString("N2")
      txtRetenciones.Text = totalRetenciones.ToString("N2")
      txtTarjetas.Text = totalTarjetas.ToString("N2")
      txtTotalPagos.Text = totalPagos.ToString("N2")
      txtDiferencia.Text = (totalComprobantes - totalPagos).ToString("N2")

      '-- Promedio de Pagos.- ---------------------------------------------
      CalculoPromedioPagoPonderados()
      '--------------------------------------------------------------------

      VerificarBotonesDeBarra()

   End Sub

   Private Sub VerificarBotonesDeBarra()

      'Pudo generar un comprobante luego de levantar la pantalla

      'carga el saldo del cliente de la cuenta corriente
      Dim oCtaCte As Eniac.Reglas.CuentasCorrientes = New Eniac.Reglas.CuentasCorrientes()
      If Me._clienteGrilla IsNot Nothing Then
         Me.txtSaldoGeneral.Text = oCtaCte.GetSaldoCliente({actual.Sucursal}, Me._clienteGrilla.IdCliente,
                                                           fechaSaldo:=Nothing,
                                                           contemplaHora:=False,
                                                           comprobantesAsociados:="TODOS",
                                                           grabaLibro:=Nothing,
                                                           comprobantesExcluidos:=Nothing,
                                                           numeroComprobanteFinalizaCon:=String.Empty,
                                                           excluirPreComprobantes:=False,
                                                           IdCama:=_idCama,
                                                           IdEmbarcacion:=_idEmbarcacion).ToString("N2")
      End If

      If Reglas.Publicos.CtaCte.CtaCteClientesSeparar Then
         'carga el saldo del cliente de la cuenta corriente (Blanco o Negro)
         'Dim grabaLibro As String = IIf(New Reglas.TiposComprobantes().GetUno(Me.cmbTiposComprobantesRec.SelectedValue.ToString()).GrabaLibro, "SI", "NO").ToString()
         Dim strComprobantesAsociados As String = New Reglas.TiposComprobantes().GetUno(Me.cmbTiposComprobantesRec.SelectedValue.ToString()).ComprobantesAsociados
         If Me._clienteGrilla IsNot Nothing Then
            Me.txtSaldoActual.Text = oCtaCte.GetSaldoCliente({actual.Sucursal}, Me._clienteGrilla.IdCliente,
                                                             fechaSaldo:=Nothing,
                                                             contemplaHora:=False,
                                                             comprobantesAsociados:=strComprobantesAsociados,
                                                             grabaLibro:=Nothing,
                                                             comprobantesExcluidos:=Nothing,
                                                             numeroComprobanteFinalizaCon:=String.Empty,
                                                             excluirPreComprobantes:=False,
                                                             IdCama:=_idCama,
                                                             IdEmbarcacion:=_idEmbarcacion).ToString("N2")
         End If
      Else
         Me.txtSaldoActual.Text = Me.txtSaldoGeneral.Text
      End If


      'Si imputo comprobantes y la diferencia es cero, significa que aplico todo.
      If Me.dgvComprobantes.RowCount > 0 And Decimal.Parse(Me.txtDiferencia.Text) = 0 Then
         Me.tsbGrabar.Enabled = True
         'Si aplico mas pagos que comprobantes y NO tiene saldo 
      ElseIf Decimal.Parse(Me.txtDiferencia.Text) < 0 And Decimal.Parse(Me.txtSaldoActual.Text) <= 0 Then
         Me.tsbGrabar.Enabled = True

         'Si hago recibo negativo y no tiene saldo.
      ElseIf Decimal.Parse(Me.txtDiferencia.Text) > 0 And Decimal.Parse(Me.txtSaldoActual.Text) <= 0 Then
         Me.tsbGrabar.Enabled = True
         'Consultar con Augusto antes de rehabilitar esta condición
         ''Si aplico mas pagos que comprobantes y Aplico todos los comprobantes pendientes
         'ElseIf Decimal.Parse(Me.txtDiferencia.Text) < 0 And (Decimal.Parse(Me.txtTotalComprobantes.Text) + Decimal.Parse(Me.txtTotalNCND.Text)) = (Decimal.Parse(Me.txtSaldoActual.Text) + Decimal.Parse(Me.txtTotalNCND.Text)) Then
         '   Me.tsbGrabar.Enabled = True
      ElseIf Decimal.Parse(Me.txtDiferencia.Text) < 0 And Decimal.Parse(Me.txtTotalComprobantes.Text) = (Decimal.Parse(Me.txtSaldoActual.Text) + Decimal.Parse(Me.txtTotalNCND.Text)) Then
         Me.tsbGrabar.Enabled = True
         'Si aplico Pagos y tiene habilitado la posibilidad de Ancitipos aun con Comprobantes Pendientes
      ElseIf Decimal.Parse(Me.txtDiferencia.Text) <= 0 And Decimal.Parse(Me.txtTotalPagos.Text) > 0 And Reglas.Publicos.CtaCte.PermiteReciboSinAplicarComprobantes Then
         Me.tsbGrabar.Enabled = True
      Else
         Me.tsbGrabar.Enabled = False
      End If

      ''Los Recibos En Negativo (Ej: DIVIDENDOS - Pagos a Inversionistas) por el momendo deben ser exactos.
      'If Decimal.Parse(Me.txtTotalComprobantes.Text) < 0 And Decimal.Parse(Me.txtDiferencia.Text) <> 0 Then
      '   Me.tsbGrabar.Enabled = False
      'End If

      If cmbTiposComprobantesRec.SelectedItem IsNot Nothing AndAlso
         DirectCast(cmbTiposComprobantesRec.SelectedItem, Entidades.TipoComprobante).ImporteTope > 0 AndAlso
         Decimal.Parse(txtTotalPagos.Text) < 0 And Decimal.Parse(txtTotalComprobantes.Text) = 0 Then
         tsbGrabar.Enabled = True
      End If

      Me.tsbGenerarNCND.Enabled = (Decimal.Parse(Me.txtTotalNCND.Text) <> 0) And Me.tsbGrabar.Enabled = True

      Me.tsbGrabar.Visible = Not Me.tsbGenerarNCND.Enabled Or Not Me.tsbGenerarNCND.Visible

   End Sub

   Private Function ValidarRecibo() As Boolean

      'Dim sistema As Entidades.Sistema = Publicos.GetSistema()

      'If sistema.FechaVencimiento.Subtract(Me.dtpFecha.Value).Days < 0 Then
      '   MessageBox.Show("La fecha es mayor a la validez del sistema, el " & sistema.FechaVencimiento.ToString("dd/MM/yyyy") & ".", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      '   Me.dtpFecha.Focus()
      '   Return False
      'End If


      If Me.bscCodigoCliente.Text.Trim().Length = 0 Then
         MessageBox.Show("Falta cargar el Código del Cliente", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
         Me.bscCodigoCliente.Focus()
         Return False
      End If


      If Me.bscCliente.Text.Trim().Length = 0 Then
         MessageBox.Show("Falta cargar el Nombre del Cliente", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
         Me.bscCliente.Focus()
         Return False
      End If

      'ahora no validad si tiene o no comprobantes
      'If Me._ComprobantesGrilla.Count = 0 Then
      '   MessageBox.Show("No se cargo ningún Comprobante", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      '   Return False
      'End If
      If Not _transferencias.Any() AndAlso Decimal.Parse(Me.txtTransferenciaBancaria.Text) <> 0 And Not Me.bscCuentaBancariaTransfBanc.Selecciono Then
         MessageBox.Show("Cargo Importe de Transferencia Bancaria pero no eligio la Cuenta de origen", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
         Return False
      End If

      If chbNroOrdenDeCompra.Checked And Not bscNroOrdenDeCompra.Selecciono Then
         bscNroOrdenDeCompra.Select()
         ShowMessage("Falta cargar el Nro. de Orden de Compra")
         Return False
      End If

      ''# Valido que la cuenta bancaria se encuentre seleccionada en caso de que haya cargado multiples transferencias
      'If (_transferencias.Count > 0 OrElse Decimal.Parse(Me.txtTransferenciaBancaria.Text) <> 0) AndAlso Not Me.bscCuentaBancariaTransfBanc.Selecciono Then
      '   ShowMessage("ATENCIÓN: Cargó importes de Transferencia Bancaria pero no eligió la Cuenta de Origen.")
      '   Return False
      'End If

      'Para pago de DIVIDENDOS.
      'If Decimal.Parse(Me.txtTransferenciaBancaria.Text) < 0 Then
      '   MessageBox.Show("El importe de Transferencia Bancaria no puede ser Negativo.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      '   Return False
      'End If

      If Me.dtpFecha.Value.Date > Date.Now.Date Then
         MessageBox.Show("La Fecha del Recibo NO puede ser Mayor al dia de Hoy", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
         Return False
      End If

      If Not Me.chbNumeroAutomatico.Checked And Long.Parse(Me.txtNumeroPosible.Text) <= 0 Then
         MessageBox.Show("El Numero de Comprobante digitado es Inválido.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
         Me.txtNumeroPosible.Focus()
         Return False
      End If

      If Not Me.chbNumeroAutomatico.Checked AndAlso Me.txtNumeroPosible.Text.Length > 0 Then
         Dim oCtaCte As New Reglas.CuentasCorrientes
         Dim idSucursal As Integer = actual.Sucursal.Id
         If Reglas.Publicos.CtaCte.ReciboComparteNumeracionEntreSucursales Then
            idSucursal = 0
         End If
         If oCtaCte.Existe(idSucursal, Me.cmbTiposComprobantesRec.SelectedValue.ToString(), Me.txtLetraRecibo.Text, New Reglas.Impresoras().GetPorSucursalPCTipoComprobante(actual.Sucursal.Id, My.Computer.Name, Me.cmbTiposComprobantesRec.SelectedValue.ToString()).CentroEmisor, Long.Parse(Me.txtNumeroPosible.Text)) Then
            MessageBox.Show("El Numero de Recibo YA Existe", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return False
         End If
      End If

      'If Decimal.Parse(Me.txtEfectivo.Text) < 0 Then
      '   MessageBox.Show("El importe de Efectivo no puede ser Negativo.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      '   Return False
      'End If

      If Decimal.Parse(Me.txtTarjetas.Text) < 0 Then
         MessageBox.Show("El importe de Tarjetas no puede ser Negativo.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
         Return False
      End If

      'Dejo que sea en cero, porque si aplica una NC y FACT puede quedar en cero.
      'If Decimal.Parse(Me.txtTotalPago.Text) = 0 Then
      '   MessageBox.Show("No se calcularon los montos de la operación", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      '   Return False
      'End If

      'valida que ningun comprobante tenga fecha de emisión posterior a la fecha de emisión del recibo
      If Not Reglas.Publicos.CtaCte.CtaCteClientesPermitirComprobantesEmisionPosterior Then
         Dim FechaHoraAControlar As Date
         If Me.dtpFecha.Value.Date = Date.Now.Date Then
            FechaHoraAControlar = DateTime.Now.AddMinutes(1) 'Para que no queden silimar (en segundos) a comprobantes automaticos
         Else
            'Toma la fecha y le coloco la hora/min/seg actual porque pudo generar comprobantes automaticos y quedan igual o bien generarlos desde facturacion.
            FechaHoraAControlar = Me.dtpFecha.Value.Date.AddHours(DateTime.Now.Hour).AddMinutes(DateTime.Now.Minute).AddSeconds(DateTime.Now.Second)
         End If

         Dim ent As Entidades.CuentaCorrientePago
         For i As Integer = 0 To Me._ComprobantesGrilla.Count - 1
            ent = Me._ComprobantesGrilla(i)
            If ent.FechaEmision > FechaHoraAControlar Then
               MessageBox.Show("El Comprobante " & ent.TipoComprobante.IdTipoComprobante & " '" & ent.Letra & "' " & ent.CentroEmisor.ToString() & "-" & ent.NumeroComprobante.ToString() & ", fué Emitido el " & ent.FechaEmision.ToString("dd/MM/yyyy HH:mm:ss") & ", posterior a la Emisión del Pago.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
               Return False
            End If
         Next
      End If

      'valida si se el importe que paga es mayor al importe de los comprobantes.
      If Decimal.Parse(Me.txtDiferencia.Text) < 0 Then
         If MessageBox.Show("¿Esta seguro de asignar la diferencia A FAVOR del Cliente?", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.No Then
            Return False
         End If
      End If

      If cmbVendedor.SelectedIndex < 0 Then
         ShowMessage("Debe seleccionar un Vendedor.")
         Return False
      End If

      If cmbCobrador.SelectedIndex < 0 Then
         ShowMessage("Debe seleccionar un Cobrador.")
         Return False
      End If

      Dim TipoComprobante As Entidades.TipoComprobante = New Entidades.TipoComprobante()
      TipoComprobante = New Reglas.TiposComprobantes().GetUno(Me.cmbTiposComprobantesRec.SelectedValue.ToString())
      Dim ImporteMinimo As Decimal = TipoComprobante.ImporteMinimo
      Dim ImporteTope As Decimal = TipoComprobante.ImporteTope

      Select Case True
         Case ImporteTope = 0 And Decimal.Parse(Me.txtTotalPagos.Text.ToString()) <> 0
            MessageBox.Show("El Tipo de Recibo Solo Permite Total en Cero (Aplicar Comprobantes entre SI).", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return False
         Case ImporteMinimo > 0 And Decimal.Parse(Me.txtTotalPagos.Text.ToString()) = 0
            MessageBox.Show("El Tipo de Recibo NO Permite Total en Cero (Debe Aplicar Comprobantes).", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return False
         Case ImporteTope < 0 And Decimal.Parse(Me.txtTotalPagos.Text.ToString()) > 0
            MessageBox.Show("El Tipo de Recibo Solo Permite Total en Negativo.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return False
         Case Decimal.Parse(Me.txtTotalPagos.Text.ToString()) < ImporteMinimo
            MessageBox.Show("El Importe Total es Menor al Importe Minimo Permitido.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return False
         Case Decimal.Parse(Me.txtTotalPagos.Text.ToString()) > ImporteTope
            MessageBox.Show("El Importe Total es Mayor al Importe Maximo Permitido.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return False
         Case Else
      End Select

      If Decimal.Parse(txtTotalComprobantes.Text) <> 0 AndAlso Decimal.Parse(txtTotalPagos.Text) <> 0 Then
         If (Decimal.Parse(txtTotalComprobantes.Text) < 0 AndAlso Decimal.Parse(txtTotalPagos.Text) > 0) Or
            (Decimal.Parse(txtTotalComprobantes.Text) > 0 AndAlso Decimal.Parse(txtTotalPagos.Text) < 0) Then
            ShowMessage("El importe total a pagar es de diferente signo al importe total de comprobantes. Por favor verifique.")
            Return False
         End If
      End If

      Dim ultimoEmisorElectronica As Integer = 0
      For Each compro As Entidades.CuentaCorrientePago In _ComprobantesGrilla
         If compro.TipoComprobante.EsPreElectronico Then
            MessageBox.Show(String.Format("El comprobante '{0} {1} {2:0000}-{3:00000000}' es un comprobante pre-electrónico." + Environment.NewLine + "No es posible emitir un recibo con este tipo de comprobantes." + Environment.NewLine + "Por favor verifique.",
                                          compro.IdTipoComprobante, compro.Letra, compro.CentroEmisor, compro.NumeroComprobante), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return False
         End If

         If Reglas.Publicos.CtaCte.ValidaEmisorElectronicoEnRecibos Then
            If compro.TipoComprobante.EsElectronico Then
               If ultimoEmisorElectronica = 0 Then ultimoEmisorElectronica = compro.CentroEmisor
               If ultimoEmisorElectronica <> compro.CentroEmisor Then
                  ShowMessage("No es posible aplicar comprobantes electrónicos con diferentes Emisores.")
                  Return False
               End If
            End If
         End If

      Next

      If cmbTiposComprobantesRec.SelectedItem IsNot Nothing AndAlso
         DirectCast(cmbTiposComprobantesRec.SelectedItem, Entidades.TipoComprobante).ImporteTope > 0 AndAlso
         Decimal.Parse(txtTotalPagos.Text) < 0 And Decimal.Parse(txtTotalComprobantes.Text) = 0 Then
         If MessageBox.Show(String.Format("¿Está seguro que desea generar un {0} con importe negativo sin aplicar comprobantes?",
                                          DirectCast(cmbTiposComprobantesRec.SelectedItem, Entidades.TipoComprobante).IdTipoComprobante),
                            Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.No Then
            Return False
         End If
      End If

      Return True

   End Function

   Private Sub GenerarCreditosDebitos()
      If ValidarRecibo() Then
         Dim totalBlanco As Decimal = 0
         Dim colObservacionesBlanco = New List(Of Entidades.VentaObservacion)()

         Dim totalNegro As Decimal = 0
         Dim colObservacionesNegro = New List(Of Entidades.VentaObservacion)()

         Dim oLineaObservacion = New Entidades.VentaObservacion()

         For i = 0 To _ComprobantesGrilla.Count - 1

            If _ComprobantesGrilla(i).DescuentoRecargoPorc <> 0 Then

               oLineaObservacion = New Entidades.VentaObservacion()

               If _ComprobantesGrilla(i).TipoComprobante.GrabaLibro Then

                  'TotalBlanco += Decimal.Round(Me._ComprobantesGrilla(i).Paga * Me._ComprobantesGrilla(i).DescuentoRecargoPorc / 100, 2)
                  totalBlanco += Me._ComprobantesGrilla(i).DescuentoRecargo

                  With oLineaObservacion
                     .IdSucursal = actual.Sucursal.Id
                     .Usuario = actual.Nombre
                     .Linea = colObservacionesBlanco.Count + 1
                     .Observacion = Strings.Left("Aplico: " & Me._ComprobantesGrilla(i).TipoComprobante.Descripcion & " ´" & Me._ComprobantesGrilla(i).Letra & "´ " & Me._ComprobantesGrilla(i).CentroEmisor.ToString("0000") & "-" & Me._ComprobantesGrilla(i).NumeroComprobante.ToString("00000000") & ". Emision: " & Me._ComprobantesGrilla(i).FechaEmision.ToString("dd/MM/yyyy") & ". Pago: " & Me._ComprobantesGrilla(i).Paga.ToString("##,##0.00") & ". Porc: " & Me._ComprobantesGrilla(i).DescuentoRecargoPorc.ToString("##0.00") & ". Monto: " & Me._ComprobantesGrilla(i).DescuentoRecargo.ToString("#,##0.00") & ".", 100)

                     'Luego de la grabacion del recibo, deberia agregar el recibo.
                     '.Observacion = Strings.Left(oVentas.TipoComprobante.DescripcionAbrev & " " & oVentas.LetraComprobante & " " & oVentas.Impresora.CentroEmisor.ToString() & "-" & oVentas.NumeroComprobante.ToString("00000000") & IIf(oVentas.Cheques.Count > 0, " - Cantidad Cheq. Tercero: " + oVentas.Cheques.Count.ToString(), "").ToString() & ". " & oVentas.Cliente.NombreCliente, 100)
                  End With

                  colObservacionesBlanco.Add(oLineaObservacion)

               Else

                  'TotalNegro += Decimal.Round(Me._ComprobantesGrilla(i).Paga * Me._ComprobantesGrilla(i).DescuentoRecargoPorc / 100, 2)
                  totalNegro += Me._ComprobantesGrilla(i).DescuentoRecargo

                  With oLineaObservacion
                     .IdSucursal = actual.Sucursal.Id
                     .Usuario = actual.Nombre
                     .Linea = colObservacionesNegro.Count + 1
                     .Observacion = Strings.Left("Aplico: " & Me._ComprobantesGrilla(i).TipoComprobante.Descripcion & " ´" & Me._ComprobantesGrilla(i).Letra & "´ " & Me._ComprobantesGrilla(i).CentroEmisor.ToString("0000") & "-" & Me._ComprobantesGrilla(i).NumeroComprobante.ToString("00000000") & ". Emision: " & Me._ComprobantesGrilla(i).FechaEmision.ToString("dd/MM/yyyy") & ". Pago: " & Me._ComprobantesGrilla(i).Paga.ToString("##,##0.00") & ". Porc: " & Me._ComprobantesGrilla(i).DescuentoRecargoPorc.ToString("##0.00") & ". Monto: " & Me._ComprobantesGrilla(i).DescuentoRecargo.ToString("#,##0.00") & ".", 100)

                     'Luego de la grabacion del recibo, deberia agregar el recibo.
                     '.Observacion = Strings.Left(oVentas.TipoComprobante.DescripcionAbrev & " " & oVentas.LetraComprobante & " " & oVentas.Impresora.CentroEmisor.ToString() & "-" & oVentas.NumeroComprobante.ToString("00000000") & IIf(oVentas.Cheques.Count > 0, " - Cantidad Cheq. Tercero: " + oVentas.Cheques.Count.ToString(), "").ToString() & ". " & oVentas.Cliente.NombreCliente, 100)

                  End With

                  colObservacionesNegro.Add(oLineaObservacion)

               End If

            End If

         Next

         If MontoDiferenciaPorPlanesTarjeta <> 0 Then
            Dim importeTotalBlanco As Decimal = _ComprobantesGrilla.Where(Function(x) x.TipoComprobante.GrabaLibro).Sum(Function(x) x.ImporteCuota)
            Dim importeTotalNegro As Decimal = _ComprobantesGrilla.Where(Function(x) Not x.TipoComprobante.GrabaLibro).Sum(Function(x) x.ImporteCuota)

            Dim coeficienteBlanco As Decimal = 0
            Dim coeficienteNegro As Decimal = 0

            If importeTotalBlanco + importeTotalNegro <> 0 Then
               coeficienteBlanco = importeTotalBlanco / (importeTotalBlanco + importeTotalNegro)
               coeficienteNegro = importeTotalNegro / (importeTotalBlanco + importeTotalNegro)
            Else
               'Si la suma de ambos importe totales da 0 es que se cancelan entre ellos
               'entonces aplico el 100% de los intereses al importe positivo
               If importeTotalBlanco > 0 Then
                  coeficienteBlanco = 1
               Else
                  coeficienteNegro = 1
               End If
            End If

            totalBlanco += Math.Round(MontoDiferenciaPorPlanesTarjeta * coeficienteBlanco, 2)
            totalNegro += Math.Round(MontoDiferenciaPorPlanesTarjeta * coeficienteNegro, 2)
         End If

         Dim comprobante As Entidades.Venta = Nothing
         Dim idTipoComprobante As String
         Dim idCliente As Long = _clienteGrilla.IdCliente
         Dim fecha As Date = dtpFecha.Value
         Dim vend = cmbVendedor.ItemSeleccionado(Of Entidades.Empleado)

         Dim idProducto = Reglas.Publicos.CtaCte.IDProductoDescuentoRecargo


         If totalBlanco <> 0 Then

            idTipoComprobante = IIf(totalBlanco > 0, Publicos.IdNotaDebitoGrabaLibro, Publicos.IdNotaCreditoGrabaLibro).ToString()

            If totalBlanco > 0 Then
               If Not String.IsNullOrWhiteSpace(DirectCast(cmbTiposComprobantesRec.SelectedItem, Entidades.TipoComprobante).IdTipoComprobanteNDeb) Then
                  idTipoComprobante = DirectCast(cmbTiposComprobantesRec.SelectedItem, Entidades.TipoComprobante).IdTipoComprobanteNDeb
               End If
               If Not String.IsNullOrWhiteSpace(DirectCast(cmbTiposComprobantesRec.SelectedItem, Entidades.TipoComprobante).IdProductoNDeb) Then
                  idProducto = DirectCast(cmbTiposComprobantesRec.SelectedItem, Entidades.TipoComprobante).IdProductoNDeb
               End If
            ElseIf totalBlanco < 0 Then
               If Not String.IsNullOrWhiteSpace(DirectCast(cmbTiposComprobantesRec.SelectedItem, Entidades.TipoComprobante).IdTipoComprobanteNCred) Then
                  idTipoComprobante = DirectCast(cmbTiposComprobantesRec.SelectedItem, Entidades.TipoComprobante).IdTipoComprobanteNCred
               End If
               If Not String.IsNullOrWhiteSpace(DirectCast(cmbTiposComprobantesRec.SelectedItem, Entidades.TipoComprobante).IdProductoNCred) Then
                  idProducto = DirectCast(cmbTiposComprobantesRec.SelectedItem, Entidades.TipoComprobante).IdProductoNCred
               End If
            End If

            totalBlanco = Math.Abs(totalBlanco)

            ''Para evitar que de error la impresion en aquellos que no detallan Observaciones.
            'If Not (New Reglas.TiposComprobantes().GetUno(IdTipoComprobante).GeneraObservConInvocados) Then
            '   colObservacionesBlanco = Nothing
            'End If

            Dim rReglaVentas1 = New Reglas.Ventas()

            Try
               Dim intentarTransmitir As Boolean = False
               Dim rVentas As Reglas.Ventas = New Reglas.Ventas()
               Dim tipoComprobante As Entidades.TipoComprobante = New Reglas.TiposComprobantes().GetUno(idTipoComprobante)
               If tipoComprobante.EsPreElectronico Then
                  'SI EL COMPROBANTE A GENERAR EN PRE-ELECTRONICO, BUSCO SI NO TENGO UNO GENERADO PARA EL MISMO CLIENTE/FECHA/IMPORTE
                  'SI LO ENCUENTRO, ASUMO QUE EL COMPROBANTE NO SE PUDO TRANSMITIR, EN CONSEQUENCIA INTENTO VOLVER A TRANSMITIR EL MISMO
                  comprobante = rVentas.GetUna(actual.Sucursal.IdSucursal, idTipoComprobante, idCliente, fecha, totalBlanco)
                  If comprobante IsNot Nothing Then
                     'INDICO QUE ES UNA RE-TRANSMISION Y QUE NO DEBO GENERAR UN NUEVO COMPROBANTE
                     intentarTransmitir = True
                  End If
               End If

               If Not intentarTransmitir Then

                  Dim _ComprobantesInvocados As New List(Of Entidades.CuentaCorrientePago)
                  Dim Pago As Entidades.CuentaCorrientePago = _ComprobantesGrilla.Item(0)
                  _ComprobantesInvocados.Add(Pago)

                  If _ComprobantesGrilla IsNot Nothing Then
                     For Each com As Entidades.CuentaCorrientePago In _ComprobantesGrilla
                        If Not (Pago.IdTipoComprobante = com.IdTipoComprobante And Pago.Letra = com.Letra And Pago.CentroEmisor = com.CentroEmisor And Pago.NumeroComprobante = com.NumeroComprobante) Then
                           _ComprobantesInvocados.Add(com)
                           Pago = com
                        End If
                     Next
                  End If


                  Dim asoc As Entidades.Venta() = {}
                  If tipoComprobante.AFIPWSRequiereComprobanteAsociado Then
                     asoc = _ComprobantesInvocados.
                                 Where(Function(x) x.TipoComprobante.GrabaLibro And
                                                   x.TipoComprobante.Tipo = Entidades.TipoComprobante.Tipos.VENTAS.ToString() And
                                                   x.DescuentoRecargo <> 0).
                     ToList().ConvertAll(Function(x) New Entidades.Venta() With
                                                            {.IdSucursal = x.IdSucursal,
                                                             .TipoComprobante = x.TipoComprobante,
                                                             .LetraComprobante = x.Letra,
                                                             .CentroEmisor = x.CentroEmisor.ToShort(),
                                                             .NumeroComprobante = x.NumeroComprobante,
                                                             .Fecha = x.FechaEmision}).ToArray()
                  End If

                  'SI NO ES RETRANSMISION GRABO EL NUEVO COMPROBANTE Y LO INSERTO EN EL RECIBO PARA LUEGO GRABAR EL RECIBO
                  comprobante = rReglaVentas1.GrabarComprobante(actual.Sucursal.Id,
                                                                idTipoComprobante,
                                                                idCliente,
                                                                cmbCajas.ValorSeleccionado(Of Integer),
                                                                fecha,
                                                                vend,
                                                                _idFormaDePagoCtaCte,
                                                                "Generado Automatico.",
                                                                totalBlanco,
                                                                idProducto,
                                                                cantProducto:=1,
                                                                observacionDetalladas:=colObservacionesBlanco,
                                                                solicitaCAE:=True,
                                                                contactos:=Nothing,
                                                                nombreProducto:=String.Empty,
                                                                cobrador:=Nothing,
                                                                comprobantesAsociados:=asoc,
                                                                idEmbarcacion:=_idEmbarcacion,
                                                                metodoGrabacion:=Entidades.Entidad.MetodoGrabacion.Automatico,
                                                                idFuncion:=IdFuncion)
                  InsertarComprobanteAutomatico(comprobante)
               Else
                  'SI ES UNA RETRANSMISION
                  Dim ComprobanteAnt = New Entidades.Venta()
                  'GUARDO EN ComprobanteAnt LA CLAVE PRIMARIA DEL COMPROBANTE
                  'PORQUE AL TRANSMITIR ME CAMBIA LA MISMA POR LA NUEVA Y VOY A NECESITAR LUEGO EL VALOR ORIGINAL
                  With ComprobanteAnt
                     .IdSucursal = comprobante.IdSucursal
                     .TipoComprobante = comprobante.TipoComprobante
                     .LetraComprobante = comprobante.LetraComprobante
                     .CentroEmisor = comprobante.CentroEmisor
                     .NumeroComprobante = comprobante.NumeroComprobante

                     'DATOS NO RECUPERADOS QUE SE DEBEN REGISTRAR CON LOS VALORES ACUTALES SIEMPRE
                     comprobante.Usuario = actual.Nombre
                     comprobante.IdCaja = cmbCajas.ValorSeleccionado(Of Integer)
                  End With
                  Try
                     'actualizo el nro. de CAE
                     'EN UNA RETRANSMISION LO PRIMERO QUE HAGO ES VERIFICAR SI PUEDO EJECUTAR EL 'CONTROLAR INFO' (Secuencia.SegundaVez)
                     rVentas.ActualizarCAE(comprobante, Entidades.AFIPCAE.Secuencia.SegundaVez, Entidades.Entidad.MetodoGrabacion.Automatico, IdFuncion)

                     'SI FUE EXITOSO, INSERTO EL COMPROBANTE EN EL RECIBO PARA SU GRABACIÓN
                     Me.InsertarComprobanteAutomatico(comprobante)
                  Catch ex1 As Exception
                     'SI SALTO UNA EXCEPCION ES PORQUE NO SE PUDO CONTROLAR LA INFO SEGURAMENTE PORQUE NO ENTRÓ EN AFIP
                     'DEBO ENTONCES INTENTAR TRANSMITIR NUEVAMENTE ESTE COMPROBANTE
                     'PARA PODER TRANSMITIR DEBO TOMAR LA IDENTIFICACION DEL MISMO DE ComprobanteAnt YA QUE AL CONTROLAR INFO SE CAMBIO
                     If ComprobanteAnt IsNot Nothing Then
                        With ComprobanteAnt
                           comprobante.IdSucursal = ComprobanteAnt.IdSucursal
                           comprobante.TipoComprobante = ComprobanteAnt.TipoComprobante
                           comprobante.LetraComprobante = ComprobanteAnt.LetraComprobante
                           comprobante.CentroEmisor = ComprobanteAnt.CentroEmisor
                           comprobante.NumeroComprobante = ComprobanteAnt.NumeroComprobante
                        End With
                     End If
                     Try
                        'INTENTO 'SOLICITAR CAE' DEL COMPROBANTE (Secuencia.PrimeraVez)
                        rVentas.ActualizarCAE(comprobante, Entidades.AFIPCAE.Secuencia.PrimeraVez, Entidades.Entidad.MetodoGrabacion.Automatico, IdFuncion)

                        'SI FUE EXITOSO, INSERTO EL COMPROBANTE EN EL RECIBO PARA SU GRABACIÓN
                        Me.InsertarComprobanteAutomatico(comprobante)
                     Catch ex2 As Exception
                        'SI SALTO UNA EXCEPCION ES PORQUE NO SE PUDO SOLICITAR CAE
                        'VUELVO A TOMAR LA IDENTIFICACION DEL MISMO DE ComprobanteAnt YA QUE AL CONTROLAR INFO SE CAMBIO
                        'DISPARO LA EXCEPCION DE ESTA ÚLTIMA TRANSMISION PARA MOSTRAR EL ERROR Y CORTAR LA EJECUCION
                        If ComprobanteAnt IsNot Nothing Then
                           With ComprobanteAnt
                              comprobante.IdSucursal = ComprobanteAnt.IdSucursal
                              comprobante.TipoComprobante = ComprobanteAnt.TipoComprobante
                              comprobante.LetraComprobante = ComprobanteAnt.LetraComprobante
                              comprobante.CentroEmisor = ComprobanteAnt.CentroEmisor
                              comprobante.NumeroComprobante = ComprobanteAnt.NumeroComprobante
                           End With
                        End If
                        'NUEVA EXCEPCIÓN PARA QUE NO LA TOME EL CATCH DE UNAS LINEAS MAS ABAJO Y EL CATCH DEL EVENTO
                        Throw New Exception(ex2.Message, ex2)
                     End Try
                  End Try
               End If

            Catch ex As Reglas.Ventas.ActualizaCAEException
               'ESTA EXCEPCION SE CATCHEA CUANDO DA ERROR LA TRANSMISION AL GrabarComprobante
               Dim mensaje = ex.Message
               Dim comprobanteAnt = New Entidades.Venta()
               'GUARDO EN ComprobanteAnt LA CLAVE PRIMARIA DEL COMPROBANTE
               'PORQUE AL TRANSMITIR ME CAMBIA LA MISMA POR LA NUEVA Y VOY A NECESITAR LUEGO EL VALOR ORIGINAL
               With comprobanteAnt
                  .IdSucursal = ex.Comprobante.IdSucursal
                  .TipoComprobante = ex.Comprobante.TipoComprobante
                  .LetraComprobante = ex.Comprobante.LetraComprobante
                  .CentroEmisor = ex.Comprobante.CentroEmisor
                  .NumeroComprobante = ex.Comprobante.NumeroComprobante
               End With
               While True
                  'SI AL GRABAR EL NUEVO COMPROBANTE DA ERROR AL QUERER TRANSMITIR EL MISMO A AFIP
                  'LE INFORMO AL USUARIO DE ESTA SITUACION Y LE PREGUNTO SI DESEA REINTENTAR LA TRANSMISION
                  If ShowPregunta(String.Format("Se produjo un error solicitando el CAE del comprobante: {0}{1}{1}¿Desea reintentar?",
                                                mensaje, Environment.NewLine)) = Windows.Forms.DialogResult.Yes Then

                     Dim rVentas = New Reglas.Ventas()

                     'Actualizo la Fecha de Transmision fuera del proceso normal para que no lo tome la transaccion
                     'Si tiene la Fecha.. no podra anularlo.
                     rVentas.ActualizarFechaTransmisionAFIP(ex.Comprobante.IdSucursal,
                                                            ex.Comprobante.TipoComprobante.IdTipoComprobante,
                                                            ex.Comprobante.LetraComprobante,
                                                            ex.Comprobante.CentroEmisor,
                                                            ex.Comprobante.NumeroComprobante,
                                                            Date.Now)
                     Try
                        'actualizo el nro. de CAE
                        'EN UNA RETRANSMISION LO PRIMERO QUE HAGO ES VERIFICAR SI PUEDO EJECUTAR EL 'CONTROLAR INFO' (Secuencia.SegundaVez)
                        rVentas.ActualizarCAE(ex.Comprobante, Entidades.AFIPCAE.Secuencia.SegundaVez, Entidades.Entidad.MetodoGrabacion.Automatico, IdFuncion)

                        'SI FUE EXITOSO, INSERTO EL COMPROBANTE EN EL RECIBO PARA SU GRABACIÓN
                        Me.InsertarComprobanteAutomatico(ex.Comprobante)
                        Exit While
                     Catch ex1 As Exception
                        'SI SALTO UNA EXCEPCION ES PORQUE NO SE PUDO CONTROLAR LA INFO SEGURAMENTE PORQUE NO ENTRÓ EN AFIP
                        'DEBO ENTONCES INTENTAR TRANSMITIR NUEVAMENTE ESTE COMPROBANTE
                        'PARA PODER TRANSMITIR DEBO TOMAR LA IDENTIFICACION DEL MISMO DE ComprobanteAnt YA QUE AL CONTROLAR INFO SE CAMBIO
                        If comprobanteAnt IsNot Nothing Then
                           With comprobanteAnt
                              ex.Comprobante.IdSucursal = comprobanteAnt.IdSucursal
                              ex.Comprobante.TipoComprobante = comprobanteAnt.TipoComprobante
                              ex.Comprobante.LetraComprobante = comprobanteAnt.LetraComprobante
                              ex.Comprobante.CentroEmisor = comprobanteAnt.CentroEmisor
                              ex.Comprobante.NumeroComprobante = comprobanteAnt.NumeroComprobante
                           End With
                        End If
                        Try
                           'INTENTO 'SOLICITAR CAE' DEL COMPROBANTE (Secuencia.PrimeraVez)
                           rVentas.ActualizarCAE(ex.Comprobante, Entidades.AFIPCAE.Secuencia.PrimeraVez, Entidades.Entidad.MetodoGrabacion.Automatico, IdFuncion)

                           'SI FUE EXITOSO, INSERTO EL COMPROBANTE EN EL RECIBO PARA SU GRABACIÓN
                           Me.InsertarComprobanteAutomatico(ex.Comprobante)
                        Catch ex2 As Exception
                           'SI SALTO UNA EXCEPCION ES PORQUE NO SE PUDO SOLICITAR CAE
                           'VUELVO A TOMAR LA IDENTIFICACION DEL MISMO DE ComprobanteAnt YA QUE AL CONTROLAR INFO SE CAMBIO
                           If comprobanteAnt IsNot Nothing Then
                              With comprobanteAnt
                                 ex.Comprobante.IdSucursal = comprobanteAnt.IdSucursal
                                 ex.Comprobante.TipoComprobante = comprobanteAnt.TipoComprobante
                                 ex.Comprobante.LetraComprobante = comprobanteAnt.LetraComprobante
                                 ex.Comprobante.CentroEmisor = comprobanteAnt.CentroEmisor
                                 ex.Comprobante.NumeroComprobante = comprobanteAnt.NumeroComprobante
                              End With
                           End If
                           'GUARDO EL MENSAJE DE LA EXCEPCION PARA MOSTRARSELO AL USUARIO Y VUELVO A 
                           'CONSULTARLO RESPECTO A SI DESEA VOLVER A INTENTAR O NO EN EL LOOP DEL WHILE
                           mensaje = ex2.Message
                        End Try
                     End Try
                  Else
                     'SI NO QUIERE REINTENTAR LA TRANSMISION, DISPARO LA PRIMER EXCEPCION PARA MOSTRAR EL ERROR (NUEVAMENTE) Y CORTAR LA EJECUCION 
                     Throw ex
                  End If
               End While
               'oReglaVentas1.AnularComprobante(ex.Comprobante)
               'oReglaVentas1.EliminarComprobantes(New List(Of Entidades.Venta)({ex.Comprobante}))
            End Try
         End If

         If totalNegro <> 0 Then

            idTipoComprobante = IIf(totalNegro > 0, Publicos.IdNotaDebitoNoGrabaLibro, Publicos.IdNotaCreditoNoGrabaLibro).ToString()

            If totalNegro > 0 Then
               If Not String.IsNullOrWhiteSpace(DirectCast(cmbTiposComprobantesRec.SelectedItem, Entidades.TipoComprobante).IdTipoComprobanteNDeb) Then
                  idTipoComprobante = DirectCast(cmbTiposComprobantesRec.SelectedItem, Entidades.TipoComprobante).IdTipoComprobanteNDeb
               End If
               If Not String.IsNullOrWhiteSpace(DirectCast(cmbTiposComprobantesRec.SelectedItem, Entidades.TipoComprobante).IdProductoNDeb) Then
                  idProducto = DirectCast(cmbTiposComprobantesRec.SelectedItem, Entidades.TipoComprobante).IdProductoNDeb
               End If
            ElseIf totalNegro < 0 Then
               If Not String.IsNullOrWhiteSpace(DirectCast(cmbTiposComprobantesRec.SelectedItem, Entidades.TipoComprobante).IdTipoComprobanteNCred) Then
                  idTipoComprobante = DirectCast(cmbTiposComprobantesRec.SelectedItem, Entidades.TipoComprobante).IdTipoComprobanteNCred
               End If
               If Not String.IsNullOrWhiteSpace(DirectCast(cmbTiposComprobantesRec.SelectedItem, Entidades.TipoComprobante).IdProductoNCred) Then
                  idProducto = DirectCast(cmbTiposComprobantesRec.SelectedItem, Entidades.TipoComprobante).IdProductoNCred
               End If
            End If

            totalNegro = Math.Abs(totalNegro)

            ''Para evitar que de error la impresion en aquellos que no detallan Observaciones.
            'If Not (New Reglas.TiposComprobantes().GetUno(IdTipoComprobante).GeneraObservConInvocados) Then
            '   colObservacionesNegro = Nothing
            'End If

            Dim rReglaVentas2 = New Reglas.Ventas()

            Dim tipoComprobante As Entidades.TipoComprobante = New Reglas.TiposComprobantes().GetUno(idTipoComprobante)

            Dim asoc As Entidades.Venta() = {}
            If tipoComprobante.AFIPWSRequiereComprobanteAsociado Then
               asoc = _ComprobantesGrilla.
                                 Where(Function(x) Not x.TipoComprobante.GrabaLibro And
                                                   x.TipoComprobante.Tipo = Entidades.TipoComprobante.Tipos.VENTAS.ToString() And
                                                   x.DescuentoRecargo <> 0).
                                 ToList().ConvertAll(Function(x) New Entidades.Venta() With
                                                            {.IdSucursal = x.IdSucursal,
                                                             .TipoComprobante = x.TipoComprobante,
                                                             .LetraComprobante = x.Letra,
                                                             .CentroEmisor = Convert.ToInt16(x.CentroEmisor),
                                                             .NumeroComprobante = x.NumeroComprobante,
                                                             .Fecha = x.FechaEmision}).ToArray()
            End If

            comprobante = rReglaVentas2.GrabarComprobante(actual.Sucursal.Id,
                                                         idTipoComprobante,
                                                         idCliente,
                                                         Integer.Parse(Me.cmbCajas.SelectedValue.ToString()),
                                                         fecha,
                                                         vend,
                                                         _idFormaDePagoCtaCte,
                                                         "Generado Automatico.",
                                                         totalNegro,
                                                         idProducto,
                                                         1,
                                                         colObservacionesNegro,
                                                         True,
                                                         contactos:=Nothing,
                                                         nombreProducto:=String.Empty,
                                                         cobrador:=Nothing,
                                                         comprobantesAsociados:=asoc,
                                                         idEmbarcacion:=_idEmbarcacion,
                                                         metodoGrabacion:=Entidades.Entidad.MetodoGrabacion.Automatico,
                                                         idFuncion:=Me.IdFuncion)

            Me.InsertarComprobanteAutomatico(comprobante)

         End If

         Me.tsbGenerarNCND.Visible = False   'Por ahora. Para que solo pueda entrar 1 vez.

         Me.CalcularTotales()

         Me.tsbGrabar.Enabled = True
         Me.tsbGrabar.Visible = True
      End If      'If ValidarRecibo() Then
   End Sub

   Private Sub GrabarRecibo()

      'Le quito el Foco al campo que lo tenga, porque podria ser uno de valor (pesos, transferencia) y que no haya dado enter.
      txtObservacion.Focus()
      CalcularPagos()
      If Not tsbGrabar.Enabled And Not tsbGenerarNCND.Enabled Then Return

      Dim conciliado As Boolean = False
      'Si tiene importe de transferencia, tiene acceso a la opción de menú de Libro de Bancos, pregunta si se desea conciliar la transferencia (si está habilitado el parámetro)
      '# Si se realizaron multiples transferencias, en el campo TransferenciaBancaria se va a visualizar el importe total de las mismas
      If IsNumeric(txtTransferenciaBancaria.Text) AndAlso Decimal.Parse(txtTransferenciaBancaria.Text) <> 0 AndAlso
         New Reglas.Usuarios().TienePermisos(actual.Nombre, actual.Sucursal.Id, "LibroBancos") AndAlso
         Reglas.Publicos.CtaCte.ReciboConciliaAutomaticamenteTransferencias Then
         Dim result As DialogResult = MessageBox.Show("¿Desea conciliar automáticamente la transferencia ingresada?", Text, MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
         If result = Windows.Forms.DialogResult.Cancel Then
            Return
         ElseIf result = Windows.Forms.DialogResult.Yes Then
            conciliado = True
         End If
      End If

      If Me.ValidarRecibo() Then

         Me.tsbGrabar.Enabled = False

         Dim oCtaCte = New Entidades.CuentaCorriente()

         With oCtaCte

            .TipoComprobante = New Reglas.TiposComprobantes().GetUno(Me.cmbTiposComprobantesRec.SelectedValue.ToString())

            .Letra = Me.txtLetraRecibo.Text

            '-- REQ-31710.- ----------------------------------
            If _cobroNovedad IsNot Nothing Then
               .IdTipoNovedad = _cobroNovedad.IdTipoNovedad
               .LetraNovedad = _cobroNovedad.Letra
               .CentroEmisorNovedad = _cobroNovedad.CentroEmisor
               .NumeroNovedad = _cobroNovedad.IdNovedad
            End If
            '-- REQ-31710.- ----------------------------------
            .FechaCalculoInteres = dtpFechaCalculoInteres.Value
            .FechaCalculoInteresModif = dtpFechaCalculoInteres.Checked
            '-------------------------------------------------

            '.CentroEmisor = New Reglas.Impresoras().GetPorSucursalPC(actual.Sucursal.Id, My.Computer.Name, False).CentroEmisor
            .CentroEmisor = New Reglas.Impresoras().GetPorSucursalPCTipoComprobante(actual.Sucursal.Id, My.Computer.Name, Me.cmbTiposComprobantesRec.SelectedValue.ToString()).CentroEmisor

            If Not Me.chbNumeroAutomatico.Checked Then
               .NumeroComprobante = Long.Parse(Me.txtNumeroPosible.Text)
            End If

            'Actualiza la fecha de hoy, si se dejo la pantalla abierta mucho tiempo
            If Me.dtpFecha.Value.Date = Date.Now.Date Then
               .Fecha = Date.Now.AddMinutes(1) 'Para que no queden silimar (en segundos) a comprobantes automaticos
            Else
               'Toma la fecha y le coloco la hora/min/seg actual porque pudo generar comprobantes automaticos y quedan igual o bien generarlos desde facturacion.
               .Fecha = Me.dtpFecha.Value.Date.AddHours(Date.Now.Hour).AddMinutes(Date.Now.Minute).AddSeconds(Date.Now.Second)
            End If

            .FechaVencimiento = .Fecha

            .FormaPago = New Reglas.VentasFormasPago().GetUna(Me._idFormaDePagoContado)

            'cargo el cliente ----------
            .Cliente = Me._clienteGrilla

            .Vendedor = DirectCast(Me.cmbVendedor.SelectedItem, Entidades.Empleado)

            .Observacion = txtObservacion.Text

            .NumeroOrdenCompra = bscNroOrdenDeCompra.Text.ValorNumericoPorDefecto(0L)

            'cargo valores del comprobante
            .ImporteTotal = Decimal.Parse(Me.txtTotalPagos.Text)

            'cargo los comprobantes
            .Pagos = Me._ComprobantesGrilla

            'cargo el efectivo para tenerlo discriminado
            .ImportePesos = Decimal.Parse(Me.txtEfectivo.Text)
            .ImporteDolares = If(IsNumeric(txtImporteDolares.Text), Decimal.Parse(txtImporteDolares.Text), 0)
            .ImporteTickets = 0
            .ImporteTarjetas = Decimal.Parse(Me.txtTarjetas.Text)
            'cargo los cheques
            .Cheques = Me._cheques
            .ImporteCheques = Decimal.Parse(Me.txtCheques.Text)
            .Tarjetas = Me._tarjetas

            If Decimal.Parse(Me.txtTransferenciaBancaria.Text) <> 0 And Me.bscCuentaBancariaTransfBanc.Selecciono Then
               .ImporteTransfBancaria = Decimal.Parse(Me.txtTransferenciaBancaria.Text)
               .CuentaBancariaTransfBanc = DirectCast(bscCuentaBancariaTransfBanc.Tag, Entidades.CuentaBancaria) '  New Reglas.CuentasBancarias().GetUna(Integer.Parse(Me.bscCuentaBancariaTransfBanc._filaDevuelta.Cells("IdCuentaBancaria").Value.ToString()))
               .FechaTransferencia = Me.dtpFechaTransferencia.Value.Date
               .Conciliado = conciliado
            End If

            '# Si ingresó una única transferencia (sin ingresar datos en la solapa de Transferencias, sino que ingreso el importe directamente en el campo Textbox),
            '# Se crea un único registro en la colección con esa información para unificar el comportamiento
            If Not _transferencias.AnySecure() AndAlso .ImporteTransfBancaria <> 0 Then
               If _transferencias Is Nothing Then _transferencias = New List(Of Entidades.CuentaCorrienteTransferencia)
               _transferencias.Add(New Entidades.CuentaCorrienteTransferencia With
                                   {
                                       .IdCuentaBancaria = DirectCast(bscCuentaBancariaTransfBanc.Tag, Entidades.CuentaBancaria).IdCuentaBancaria,
                                       .Orden = _transferencias.MaxSecure(Function(t) t.Orden).IfNull() + 1,
                                       .Importe = oCtaCte.ImporteTransfBancaria
                                   })
            End If
            .CCTransferencias = _transferencias

            'cargo las Retenciones
            .Retenciones = Me._retenciones
            .ImporteRetenciones = Decimal.Parse(Me.txtRetenciones.Text)

            'cargo la caja
            .CajaDetalle.IdCaja = Integer.Parse(Me.cmbCajas.SelectedValue.ToString())

            .Cobrador = DirectCast(Me.cmbCobrador.SelectedItem, Entidades.Empleado)

            .EstadoCliente.IdEstadoCliente = Int32.Parse(Me.txtEstadoCliente.Tag.ToString())

            'cargo datos generales del comprobante
            .IdSucursal = actual.Sucursal.Id
            .Usuario = actual.Nombre
            .IdEstado = "NORMAL"

            If .Cliente.IdClienteCtaCte <> 0 Then
               .IdClienteCtaCte = .Cliente.IdClienteCtaCte
            Else
               .IdClienteCtaCte = .Cliente.IdCliente
            End If

            .IdCategoria = .Cliente.IdCategoria

            .SaldoCtaCte = Decimal.Parse(Me.txtSaldoActual.Text.ToString()) - Decimal.Parse(Me.txtTotalPagos.Text.ToString())

            .CotizacionDolar = Decimal.Parse(Me.txtCotizacionDolar.Text.ToString())

            '-- 42455.- ---------------------------------------------------------------------------------------------------------------
            If Not String.IsNullOrEmpty(txtFechaPromedioPago.Text) Then
               .FechaPromedioCobro = DateTime.Parse(txtFechaPromedioPago.Text)
               .PromedioDiasCobro = Decimal.Parse(txtDiasPromedioPago.Text.ToString())
            End If
            .CantidadDiasCobro = Decimal.Parse(txtDiasDirectos.Text.ToString())
            '--------------------------------------------------------------------------------------------------------------------------
            'cargo la direccion elegida
            If Integer.Parse(Me.cmbDirecciones.SelectedValue.ToString()) = 0 Then
               .Direccion = .Cliente.Direccion
               .IdLocalidad = .Cliente.IdLocalidad
            Else
               Dim Direcciones As DataTable = New Reglas.ClientesDirecciones().GetDireccionCliente(.Cliente.IdCliente, Integer.Parse(cmbDirecciones.SelectedValue.ToString()))
               .Direccion = Direcciones.Rows(0).Item("Direccion").ToString()
               .IdLocalidad = Integer.Parse(Direcciones.Rows(0).Item("IdLocalidad").ToString())
            End If

         End With

         My.Application.Log.WriteEntry("Recibos-Inserta registro.", TraceEventType.Verbose)

         Try
            '-- REG-33207.- ----------------------------------------------------------------
            AntesInsertarRecibo(oCtaCte)
            '-------------------------------------------------------------------------------
            Dim oReglasCuentaCorriente = New Reglas.CuentasCorrientes()
            oReglasCuentaCorriente.Insertar(oCtaCte, Entidades.Entidad.MetodoGrabacion.Manual, IdFuncion)
         Catch
            VerificarBotonesDeBarra()
            Throw
         End Try

         My.Application.Log.WriteEntry("Recibos-Termino de Insertar registro.", TraceEventType.Verbose)

         ShowMessage("Se ingreso el Recibo número " & oCtaCte.NumeroComprobante)

         'Se envia por mail si corresponde
         If Reglas.Publicos.CtaCte.RecibosEnviaMailCliente Then

            Dim dt As DataTable

            dt = New Reglas.Textos().GetTextos(Me.IdFuncion, "")

            For Each dr As DataRow In dt.Rows
               Me._asunto = dr("Asunto").ToString()

               'Trabajo el cuerpo para que respete el formato
               Dim stbCuerpo As System.Text.StringBuilder = New System.Text.StringBuilder()

               Dim parts As String() = dr("Cuerpo").ToString.Split(ControlChars.CrLf.ToCharArray)

               stbCuerpo.Append("<!DOCTYPE HTML>")
               stbCuerpo.Append("<html>")
               stbCuerpo.Append("<head>")
               stbCuerpo.Append("</head>")
               stbCuerpo.Append("<body>")

               For Each st As String In parts
                  stbCuerpo.Append("<br>")
                  stbCuerpo.Append(st)
               Next
               stbCuerpo.Append("</body>")
               stbCuerpo.Append("</html>")

               _cuerpo = stbCuerpo.ToString()

            Next
            ExportarPDF.ArmarRecibo(oCtaCte, _asunto, _cuerpo)
         End If


         Dim ir As RecibosImprimir = New RecibosImprimir()

         'Por ahora pregunto aca, aunque podria ser en la funcion abajo.
         If oCtaCte.TipoComprobante.Imprime Or Reglas.Publicos.CtaCte.VisualizaReciboDeCliente Then

            'Declaro una nueva regla porque la otra cierra la conexion.
            'Vuelvo a leer los datos por la fecha de vencimiento 
            Dim reg = New Reglas.CuentasCorrientes()
            oCtaCte = reg.GetUna(oCtaCte.IdSucursal, oCtaCte.TipoComprobante.IdTipoComprobante, oCtaCte.Letra, oCtaCte.CentroEmisor, oCtaCte.NumeroComprobante)

            ir.ImprimirRecibo(oCtaCte, Reglas.Publicos.CtaCte.VisualizaReciboDeCliente)
         End If

         Nuevo()

         If _cerraLuegoDeGrabar Then
            DialogResult = Windows.Forms.DialogResult.OK
            Close()
         End If
      End If
   End Sub


   Private Function ValidarInsertarTarjeta() As Boolean
      If cmbTarTarjeta.SelectedIndex = -1 Then
         ShowMessage("Debe seleccionar una Tarjeta.")
         cmbTarTarjeta.Focus()
         Return False
      End If
      If Not bscTarBanco.Selecciono Then
         ShowMessage("Debe seleccionar un Banco.")
         bscTarBanco.Focus()
         Return False
      End If
      If txtTarMonto.ValorNumericoPorDefecto(0D) <= 0 Then
         ShowMessage("No puede ingresar el importe menor a cero.")
         txtTarMonto.Focus()
         Return False
      End If

      If Decimal.Parse(Me.txtTarNumeroLote.Text) <= 0 Then
         MessageBox.Show("No puede ingresar un Nro de lote menor a cero.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
         Me.txtTarNumeroLote.Focus()
         Return False
      End If
      If Decimal.Parse(Me.txtTarNumeroCupon.Text) <= 0 Then
         MessageBox.Show("No puede ingresar un Nro de cupon menor a cero.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
         Me.txtTarNumeroCupon.Focus()
         Return False
      End If

      ''controlo que no se repita la tarjeta ingresada
      'For Each ent As Entidades.VentaTarjeta In Me._tarjetas
      '   If ent.Tarjeta.IdTarjeta = Integer.Parse(Me.cmbTarTarjeta.SelectedValue.ToString()) And
      '            ent.Banco.IdBanco = Integer.Parse(Me.bscTarBanco._filaDevuelta.Cells("IdBanco").Value.ToString()) Then
      '      MessageBox.Show("La tarjeta ya fue ingresada.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
      '      Return False
      '   End If
      'Next

      Return True
   End Function

   Private Sub InsertarTarjetaGrilla()

      Dim oLineaDetalle As Entidades.VentaTarjeta = New Entidades.VentaTarjeta()

      With oLineaDetalle
         .IdSucursal = actual.Sucursal.Id
         .Tarjeta = New Reglas.Tarjetas().GetUno(cmbTarTarjeta.ValorSeleccionado(0I))
         .Banco = New Reglas.Bancos().GetUno(Integer.Parse(bscTarBanco._filaDevuelta.Cells("IdBanco").Value.ToString()))
         .Orden = 0     ' Lo dejo en cero para que lo asigne la regla. La regla, si es cero (0) busca el último y se lo pone.
         .Monto = txtTarMonto.ValorNumericoPorDefecto(0D)
         .Cuotas = txtTarCuotas.ValorNumericoPorDefecto(0I)
         .NumeroLote = txtTarNumeroLote.ValorNumericoPorDefecto(0I)
         .NumeroCupon = txtTarNumeroCupon.ValorNumericoPorDefecto(0I)
         .Usuario = actual.Nombre
      End With

      _tarjetas.Add(oLineaDetalle)

      dgvTarjetas.DataSource = _tarjetas.ToArray()
      dgvTarjetas.FirstDisplayedScrollingRowIndex = dgvTarjetas.Rows.Count - 1

      dgvTarjetas.Refresh()
      LimpiarCamposTarjetas()
      CalculaMontoInteresTarjeta()
      CalcularTotales()
      CalcularPagos()
   End Sub

   Private Sub EliminarLineaTarjetas()
      _tarjetas.RemoveAt(dgvTarjetas.SelectedRows(0).Index)

      dgvTarjetas.DataSource = _tarjetas.ToArray()
      CalculaMontoInteresTarjeta()
      CalcularTotales()
      CalcularPagos()
   End Sub

   Private Sub CargarDatosTarjetasBancos(dr As DataGridViewRow)
      Me.bscTarBanco.Text = dr.Cells("NombreBanco").Value.ToString()
   End Sub

   Private Sub LimpiarCamposTarjetas()
      Me.cmbTarTarjeta.SelectedIndex = -1
      Me.bscTarBanco.Text = ""
      Me.bscTarBanco.FilaDevuelta = Nothing
      Me.txtTarCuotas.Text = "1"
      Me.txtTarMonto.Text = "0"
      Me.txtTarNumeroCupon.Text = "0"
      Me.txtTarNumeroLote.Text = "0"
   End Sub

   Private Sub CargarComprobantesSeleccionados(selec As List(Of Entidades.CuentaCorrientePago))

      Me._ComprobantesGrilla = New List(Of Entidades.CuentaCorrientePago)

      '-- Obtiene la sumatoria de Importes para calculo de Promedios Pagos.- -
      Dim sumatoria = selec.Sum(Function(x) x.ImporteCuota)
      '-----------------------------------------------------------------------

      For Each v As Entidades.CuentaCorrientePago In selec

         '-- REQ-34643.- ------------------------------------
         v.DescuentoRecargoPorc = ReciboPorcentajeDescuentoRecargo(DirectCast(cmbTiposComprobantesRec.SelectedItem, Entidades.TipoComprobante),
                                                                   DirectCast(cmbCategoria.SelectedValue, Integer),
                                                                   v.FechaEmision, v.FechaVencimiento, dtpFechaCalculoInteres.Value, v.ImporteCuota, v.SaldoCuota)

         'v.DescuentoRecargoPorc = ReciboPorcentajeDescuentoRecargo(DirectCast(cmbTiposComprobantesRec.SelectedItem, Entidades.TipoComprobante),
         '                                                          DirectCast(cmbCategoria.SelectedValue, Integer),
         '                                                          v.FechaEmision, v.FechaVencimiento, dtpFecha.Value, v.ImporteCuota, v.SaldoCuota)

         v.DescuentoRecargoPorc = Decimal.Round(v.DescuentoRecargoPorc, 2)
         v.DescuentoRecargo = Math.Round(v.Paga * v.DescuentoRecargoPorc / 100, 2)

         If Reglas.Publicos.CtaCte.MontoMinimoInteresPermitido > v.DescuentoRecargo Then
            v.DescuentoRecargo = 0
         End If

         v.MontoAplicadoIncluyeIntereses = False



         Me._ComprobantesGrilla.Add(v)

      Next
      '-- Carga Comprobantes para Calculo de Promedios Pagos.- ------------------------------------

      Me.dgvComprobantes.DataSource = Me._ComprobantesGrilla
      Me.AjustarColumnasGrilla(Me.dgvComprobantes, Me._tit)

      CalculoPromedioPagoPonderados()

      Me.dgvComprobantes.Refresh()

   End Sub

   Private Sub OrdenarGrillaComprobantes()
      With Me.dgvComprobantes
         .Columns("gfacFecha").DisplayIndex = 0
         .Columns("gfacTipoComprobanteDescripcion").DisplayIndex = 1
         .Columns("gfacLetraComprobante").DisplayIndex = 2
         .Columns("gfacCentroEmisor").DisplayIndex = 3
         .Columns("gfacNumeroComprobante").DisplayIndex = 4
         .Columns("gfacSubtotal").DisplayIndex = 5
         .Columns("gfacTotalImpuestos").DisplayIndex = 6
         .Columns("gfacImporteTotal").DisplayIndex = 7
         .Columns("gfacKilos").DisplayIndex = 8
         .Columns("gfacObservacion").DisplayIndex = 9
      End With
   End Sub

   Private Sub EvaluaHabilitarFecha()
      If dgvComprobantes.RowCount = 0 Then
         dtpFecha.Enabled = True
      Else
         'TODO: Ver si esto hay que cambiarlo (el parametro no se usaria mas en principio)
         dtpFecha.Enabled = Reglas.Publicos.CtaCte.InteresesAdicionalProporcionalDiario = 0 AndAlso
                            New Reglas.InteresesDias().GetAll().Rows.Count = 0
      End If
      '-- REQ-31947.- ----------------------------------
      dtpFechaCalculoInteres.Enabled = dtpFecha.Enabled
      ProcesoCalculoInteresCheques()
      '-------------------------------------------------
   End Sub

   Private _invocadosCajero As List(Of Entidades.Venta)
   Private _tiposRecibosParaInvocados As List(Of Entidades.TipoComprobante)
   Public Sub InvocarDesdeCajero(invocados As List(Of Entidades.Venta))
      _invocadosCajero = invocados ' New List(Of Entidades.Venta)({invocado})

      Dim tiposComprobantes As List(Of String) = New List(Of String)()
      Dim idClienteTemp As Long = 0
      Dim idCaja As Integer = 0
      For Each Venta As Entidades.Venta In invocados
         If Not tiposComprobantes.Contains(Venta.IdTipoComprobante) Then
            tiposComprobantes.Add(Venta.IdTipoComprobante)
         End If
         If idClienteTemp = 0 Then idClienteTemp = Venta.Cliente.IdCliente
         If idClienteTemp <> Venta.Cliente.IdCliente Then
            Throw New Exception("Debe seleccionar comprobantes de un mismo cliente.")
         End If
         If idCaja = 0 Then idCaja = Venta.IdCaja
         If idCaja <> Venta.IdCaja Then
            Throw New Exception("Debe seleccionar comprobantes de una misma caja.")
         End If
      Next

      _tiposRecibosParaInvocados = New Reglas.TiposComprobantes().GetMinutas(actual.Sucursal.Id,
                                                                             "VENTAS",
                                                                             "CTACTECLIE",
                                                                             tiposComprobantes.ToArray(),
                                                                             Nothing)

      If _tiposRecibosParaInvocados.Count = 0 Then
         Throw New Exception("No se encontró un Tipo de Recibo común para los comprobantes seleccionados. Es posible que haya seleccionado comprobantes de diferente tipo.")
      End If

   End Sub

   Public Sub CargaComprobanteDesdeCajero()

      '-- REQ-31947.- --------------------------------
      ProcesoCalculoInteresCheques()
      '-----------------------------------------------

      For Each venta As Entidades.Venta In _invocadosCajero
         Dim fechaVencimiento As DateTime = venta.Fecha  'TODO: Cambiar para que recupere la CtaCte y así poner la fecha de vencimiento.  venta.FechaVencimiento 
         Dim saldo As Decimal = venta.ImporteTotal       'TODO: Cambiar para que recupere la CtaCte y así poner el saldo.    venta.Saldo

         Me.cmbTiposComprobantesRec.Enabled = False
         Me.cmbTiposComprobantes.SelectedValue = venta.IdTipoComprobante
         Me.txtLetra.Text = venta.LetraComprobante
         Me.txtEmisor.Text = venta.CentroEmisor.ToString()
         Me.bscComprobante.Text = venta.NumeroComprobante.ToString()
         bscCodigoClienteComprobante.Tag = venta.IdCliente
         bscCodigoClienteComprobante.Text = venta.CodigoCliente.ToString()
         bscCliente.Text = venta.NombreCliente


         Me.txtCuota.Text = "1" 'TODO: Cambiar Cajero para que recupere la CtaCte y así obtener la cuota. venta.Cuota.ToString()
         Me.dtpComprobanteFechaEmision.Value = venta.Fecha
         Me.dtpComprobanteFechaVencimiento.Value = fechaVencimiento
         Me.txtImporte.Text = venta.ImporteTotal.ToString("N2")
         Me.txtSaldo.Text = saldo.ToString("N2")
         Me.txtDescuentoRecargoPorc.Text = "0.00"
         Me.txtPaga.Text = Me.txtSaldo.Text
         Me.txtFormaDePago.Tag = venta.FormaPago.IdFormasPago
         Me.txtFormaDePago.Text = venta.FormaPago.DescripcionFormasPago

         Me.txtDescuentoRecargoPorc.Text = ReciboPorcentajeDescuentoRecargo(DirectCast(cmbTiposComprobantesRec.SelectedItem, Entidades.TipoComprobante),
                                                                            venta.IdCategoria,
                                                                            venta.Fecha,
                                                                            fechaVencimiento, dtpFechaCalculoInteres.Value,
                                                                            venta.ImporteTotal,
                                                                            saldo).ToString("N2")

         bscComprobante.Selecciono = True

         CalcularTotalAPagarComprobantePorPorc()
         btnInsertar.PerformClick()
      Next
   End Sub

#Region "Metodos Busqueda Cliente Secundaria"
   Protected Overridable Sub CargaComboBusquedaClienteSecundaria(combo As Eniac.Controles.ComboBox)
      combo.Items.Add(BusquedaClienteSecundaria_CUIT)
      If New Reglas.Generales().ExisteTabla("Embarcaciones") Then
         combo.Items.Add(BusquedaClienteSecundaria_EMBARCACION)
      End If
      '-- REQ-36328.- --------------------------------------------
      If New Reglas.Generales().ExisteTabla("Camas") Then
         combo.Items.Add(BusquedaClienteSecundaria_CAMA)
      End If
      '-----------------------------------------------------------
   End Sub

   Protected Overridable Function EjecutaBusquedaClienteSecundaria(modo As String) As DataTable
      _idEmbarcacion = 0
      _idCama = 0
      If modo = BusquedaClienteSecundaria_CUIT Then
         _publicos.PreparaGrillaClientes2(bscBusquedaClienteSecundaria)
         Dim oClientes = New Reglas.Clientes()
         Return oClientes.GetFiltradoPorCUIT(bscBusquedaClienteSecundaria.Text.Trim())
      ElseIf modo = BusquedaClienteSecundaria_EMBARCACION Then
         _publicos.PreparaGrillaEmbarcaciones(bscBusquedaClienteSecundaria)
         Dim oClientes = New Reglas.Embarcaciones()
         Return oClientes.GetFiltradoPorNombre(bscBusquedaClienteSecundaria.Text.Trim())
      ElseIf modo = BusquedaClienteSecundaria_CAMA Then
         _publicos.PreparaGrillaCamas(bscBusquedaClienteSecundaria)
         Dim oCamas As Reglas.Camas = New Reglas.Camas
         Return oCamas.GetCamaPorCodigo(bscBusquedaClienteSecundaria.Text.Trim())
      End If

      Return New DataTable()
   End Function

   Protected Overridable Sub MuestraBusquedaClienteSecudaria(dgvr As DataGridViewRow, modo As String)
      _idEmbarcacion = 0
      _idCama = 0
      If dgvr Is Nothing Then
         bscBusquedaClienteSecundaria.Text = String.Empty
      Else
         If modo = BusquedaClienteSecundaria_CUIT Then
            bscBusquedaClienteSecundaria.Text = dgvr.Cells(BusquedaClienteSecundaria_CUIT).Value.ToString()
         ElseIf modo = BusquedaClienteSecundaria_EMBARCACION Then
            bscBusquedaClienteSecundaria.Text = dgvr.Cells("NombreEmbarcacion").Value.ToString()
            _idEmbarcacion = Long.Parse(dgvr.Cells("idEmbarcacion").Value.ToString())
         ElseIf modo = BusquedaClienteSecundaria_CAMA Then
            bscBusquedaClienteSecundaria.Text = dgvr.Cells("CodigoCama").Value.ToString()
            _idCama = Long.Parse(dgvr.Cells("idCama").Value.ToString())
         End If
      End If
   End Sub
   '-- REQ-33207.- --------------------------
   Protected Overridable Sub AntesInsertarRecibo(entd As Entidades.CuentaCorriente)
      entd.IdEmbarcacion = 0
      '-- Asigna Id de Embarcacion.- --
      If Reglas.Publicos.CtaCteEmbarcacion Then
         entd.IdEmbarcacion = _idEmbarcacion
         entd.NombreEmbarcacion = bscBusquedaClienteSecundaria.Text
      End If
      '-- REQ-36328.- ------------------------------------------------
      entd.IdCama = 0
      If Reglas.Publicos.CtaCteCama Then
         entd.IdCama = _idCama
      End If
      '-- Procedimiento para permitir la carga de información adicional antes de
      '   grabar.-
   End Sub
   '-----------------------------------------
   Protected Overridable Sub AntesBuscarComprobante(Embarcacion As Long)
      '-- Procedimiento para permitir la carga de información adicional antes de
      '   grabar.-
   End Sub

#End Region

   Private Function GetTipoReciboSeleccionado() As Entidades.TipoComprobante
      If cmbTiposComprobantesRec.SelectedIndex > -1 AndAlso
         TypeOf (cmbTiposComprobantesRec.SelectedItem) Is Entidades.TipoComprobante Then
         Return DirectCast(cmbTiposComprobantesRec.SelectedItem, Entidades.TipoComprobante)
      End If
      Return Nothing
   End Function

   Private Function GetIdCategoriaClienteSegunParametro() As Integer
      Return If(Reglas.Publicos.CtaCte.ContemplaCategoriaClienteRecibo, Integer.Parse(Me.cmbCategoria.SelectedValue.ToString()), 0)
   End Function

#End Region

   Private Sub cmbTipoImpuesto_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbTipoImpuesto.SelectedIndexChanged
      Try
         If cmbTipoImpuesto.SelectedIndex > -1 Then
            If _clienteGrilla Is Nothing Then
               Me.cmbProvinciaRetencion.SelectedIndex = -1
            Else
               Me.cmbProvinciaRetencion.SelectedValue = _clienteGrilla.Localidad.IdProvincia
            End If

            cmbProvinciaRetencion.Visible = cmbTipoImpuesto.SelectedValue.ToString() = Entidades.TipoImpuesto.Tipos.RIIBB.ToString()
            lblProvinciaRetencion.Visible = cmbProvinciaRetencion.Visible

            bscCodigoLocalidadRetenciones.Visible = cmbTipoImpuesto.SelectedValue.ToString() = Entidades.TipoImpuesto.Tipos.RDREI.ToString()
            bscNombreLocalidadRetenciones.Visible = cmbTipoImpuesto.SelectedValue.ToString() = Entidades.TipoImpuesto.Tipos.RDREI.ToString()
            lblCodigoLocalidadRetenciones.Visible = bscCodigoLocalidadRetenciones.Visible
         End If
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

   Public Sub SetParametros(parametros As String) Implements IConParametros.SetParametros
      If parametros = "RECIBOVINCULADO" Then
         _esReciboClienteVinculado = True
      End If
   End Sub
   Public Function GetParametrosDisponibles() As String Implements IConParametros.GetParametrosDisponibles
      Return "Pendiente documentar"
   End Function

   Private Sub chbProveedor_CheckedChanged(sender As Object, e As EventArgs) Handles chbProveedor.CheckedChanged

      Me.bscCodigoProveedor.Enabled = Me.chbProveedor.Checked
      Me.bscProveedor.Enabled = Me.chbProveedor.Checked

      Me.bscCodigoProveedor.Text = String.Empty
      Me.bscCodigoProveedor.Tag = Nothing
      Me.bscProveedor.Text = String.Empty

      Me.bscCodigoProveedor.Focus()

   End Sub
   Private Sub bscCodigoProveedor_BuscadorClick() Handles bscCodigoProveedor.BuscadorClick
      Dim codigoProveedor As Long = -1
      Try
         Me._publicos.PreparaGrillaProveedores2(Me.bscCodigoProveedor)
         Dim oProveedores As Reglas.Proveedores = New Reglas.Proveedores
         If Me.bscCodigoProveedor.Text.Trim.Length > 0 Then
            codigoProveedor = Long.Parse(Me.bscCodigoProveedor.Text.Trim())
         End If
         Me.bscCodigoProveedor.Datos = oProveedores.GetFiltradoPorCodigo(codigoProveedor)
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub bscCodigoProveedor_BuscadorSeleccion(sender As Object, e As Controles.BuscadorEventArgs) Handles bscCodigoProveedor.BuscadorSeleccion
      Try
         If Not e.FilaDevuelta Is Nothing Then
            Me.CargarDatosProveedor(e.FilaDevuelta)
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub bscProveedorProv_BuscadorClick() Handles bscProveedor.BuscadorClick
      Try
         Me._publicos.PreparaGrillaProveedores2(Me.bscProveedor)
         Dim oProveedores As Reglas.Proveedores = New Reglas.Proveedores
         Me.bscProveedor.Datos = oProveedores.GetFiltradoPorNombre(Me.bscProveedor.Text.Trim())
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub bscProveedorProv_BuscadorSeleccion(sender As Object, e As Controles.BuscadorEventArgs) Handles bscProveedor.BuscadorSeleccion
      Try
         If Not e.FilaDevuelta Is Nothing Then
            Me.CargarDatosProveedor(e.FilaDevuelta)
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub
   Private Sub CargarDatosProveedor(dr As DataGridViewRow)

      Me.bscProveedor.Text = dr.Cells("NombreProveedor").Value.ToString()
      Me.bscCodigoProveedor.Text = dr.Cells("CodigoProveedor").Value.ToString()
      Me.bscCodigoProveedor.Tag = dr.Cells("IdProveedor").Value.ToString()
      Me.bscProveedor.Enabled = False
      Me.bscCodigoProveedor.Enabled = False

   End Sub


   Private Sub btnObservacionCliente_Click(sender As Object, e As EventArgs) Handles btnObservacionCliente.Click
      Try
         If MessageBox.Show("¿Desea ingresar nuevas observaciones ?", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.Yes Then

            Dim ocli As Reglas.Clientes = New Reglas.Clientes()
            _clienteGrilla.Observacion = Me.txtObservacionCliente.Text
            _clienteGrilla.Usuario = actual.Nombre

            ocli.Actualizar(_clienteGrilla)

            MessageBox.Show("La observación fue registrada", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)

         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub btnInvocarChequesAlta_Click(sender As Object, e As EventArgs) Handles btnInvocarChequesAlta.Click

      Try
         If Me.bscCodigoCliente.Text.Trim().Length = 0 Then
            MessageBox.Show("Falta cargar el Código del Cliente", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.bscCodigoCliente.Focus()
            Exit Sub

         End If


         If Me.bscCliente.Text.Trim().Length = 0 Then
            MessageBox.Show("Falta cargar el Nombre del Cliente", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.bscCliente.Focus()
            Exit Sub
         End If

         Dim frmChequesDetalleAyuda As Eniac.Win.ChequesDetalleAyuda
         frmChequesDetalleAyuda = New Eniac.Win.ChequesDetalleAyuda(Integer.Parse(Me.cmbCajas.SelectedValue.ToString()), 0)



         frmChequesDetalleAyuda.TipoDeMovimiento = "I"
         frmChequesDetalleAyuda.ShowDialog()

         If frmChequesDetalleAyuda.blSeleccionados Then
            Me.AgregarChequesEnALta(frmChequesDetalleAyuda.dtSelectedCheques)
         End If

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub
   Private Sub AgregarChequesEnALta(dtCheques As DataTable)


      For Each cRow As DataRow In dtCheques.Rows
         Dim ExisteChq As Boolean = False
         For Each chq As Entidades.Cheque In Me._cheques.ToArray()
            If chq.NumeroCheque = Integer.Parse(cRow("NumeroCheque").ToString()) _
               And chq.IdSucursal = actual.Sucursal.IdSucursal _
               And chq.IdBanco = Integer.Parse(cRow("IdBanco").ToString()) _
               And chq.IdBancoSucursal = Integer.Parse(cRow("IdBancoSucursal").ToString()) _
               And chq.Localidad.IdLocalidad = Integer.Parse(cRow("IdLocalidad").ToString()) Then
               ExisteChq = True
            End If
         Next
         If Not ExisteChq Then
            Dim oLineaDetalle As Entidades.Cheque = New Entidades.Cheque()
            With oLineaDetalle
               .IdCheque = Long.Parse(cRow("IdCheque").ToString())
               .Banco = New Reglas.Bancos().GetUno(Integer.Parse(cRow("IdBanco").ToString()))
               .IdBancoSucursal = Integer.Parse(cRow("IdBancoSucursal").ToString())
               .Localidad.IdLocalidad = Integer.Parse(cRow("IdLocalidad").ToString())
               .NumeroCheque = Integer.Parse(cRow("NumeroCheque").ToString())
               .FechaEmision = Date.Parse(cRow("FechaEmision").ToString())
               .FechaCobro = Date.Parse(cRow("FechaCobro").ToString())
               .Titular = cRow("Titular").ToString()
               .Importe = Decimal.Parse(cRow("Importe").ToString())
               .IdTipoCheque = cRow("IdTipoCheque").ToString()
               .NombreTipoCheque = cRow("NombreTipoCheque").ToString()
               .NroOperacion = cRow("NroOperacion").ToString()
               .Cliente.IdCliente = Me._clienteGrilla.IdCliente
               .Usuario = actual.Nombre
               .IdEstadoCheque = Entidades.Cheque.Estados.ALTA
               .Cuit = cRow("Cuit").ToString()
               .IdSucursal = actual.Sucursal.IdSucursal
               If Not String.IsNullOrWhiteSpace(Me.bscCodigoProveedor.Text) Then
                  .IdProveedorPreasignado = Long.Parse(Me.bscCodigoProveedor.Tag.ToString())
                  .CodigoProveedorPreasignado = Long.Parse(Me.bscCodigoProveedor.Text.ToString())
                  .ProveedorPreasignado = Me.bscProveedor.Text
               End If
            End With
            Me._cheques.Add(oLineaDetalle)
         End If

      Next

      Me.dgvCheques.DataSource = Me._cheques.ToArray()
      Me.dgvCheques.FirstDisplayedScrollingRowIndex = Me.dgvCheques.Rows.Count - 1
      Me.dgvCheques.Refresh()
      Me.LimpiarCamposCheque()
      Me.CalcularPagos()
   End Sub

   Private Sub dtpFechaTransferencia_KeyDown(sender As Object, e As KeyEventArgs) Handles dtpFechaTransferencia.KeyDown
      If e.KeyCode = Keys.Enter Then
         Me.bscCodBancos.Focus()
      End If
   End Sub

   Private Sub bscCodigoLocalidadRetenciones_BuscadorClick() Handles bscCodigoLocalidadRetenciones.BuscadorClick
      Try
         Dim oLocalidades As Reglas.Localidades = New Reglas.Localidades()
         Me._publicos.PreparaGrillaLocalidades(Me.bscCodigoLocalidadRetenciones)
         Me.bscCodigoLocalidadRetenciones.Datos = oLocalidades.GetPorCodigo(If(IsNumeric(bscCodigoLocalidadRetenciones.Text), Integer.Parse(bscCodigoLocalidadRetenciones.Text), 0))
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub bscCodigoLocalidadRetenciones_BuscadorSeleccion(sender As Object, e As Controles.BuscadorEventArgs) Handles bscCodigoLocalidadRetenciones.BuscadorSeleccion
      Try
         If Not e.FilaDevuelta Is Nothing Then
            Me.CargarDatosLocalidadRetenciones(e.FilaDevuelta)
         End If
         Me.ProcessTabKey(True)
         'Me.txtNroCheque.Focus()
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub


   Private Sub Recibos_FormClosed(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing

      Dim valida As Boolean = False
      Dim stbMensaje As StringBuilder = New StringBuilder()

      stbMensaje.AppendFormatLine("¿ Desea Salir del Formulario ?").AppendLine()
      stbMensaje.AppendFormatLine("       Verifique:").AppendLine()

      If dgvCheques.RowCount > 0 Then
         valida = True
         stbMensaje.AppendFormatLine("Tiene Cheques Cargados.").AppendLine()
      End If
      If dgvTarjetas.RowCount > 0 Then
         valida = True
         stbMensaje.AppendFormatLine("Tiene Tarjetas Cargadas.").AppendLine()
      End If
      If dgvRetenciones.RowCount > 0 Then
         valida = True
         stbMensaje.AppendFormatLine("Tiene Retenciones Cargadas.").AppendLine()
      End If
      If dgvRetenciones.RowCount > 0 Then
         valida = True
         stbMensaje.AppendFormatLine("Tiene Retenciones Cargadas.").AppendLine()
      End If
      If Decimal.Parse(Me.txtTotalPagos.Text.ToString()) <> 0 Then
         valida = True
         stbMensaje.AppendFormatLine("Total Pagos es Diferente de cero.").AppendLine()
      End If
      If valida Then
         If MessageBox.Show(stbMensaje.ToString(), Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Information) = Windows.Forms.DialogResult.No Then
            e.Cancel = True
         End If
      End If

   End Sub

   Private Sub bscNombreLocalidadRetenciones_BuscadorClick() Handles bscNombreLocalidadRetenciones.BuscadorClick
      Try
         Dim oLocalidades As Reglas.Localidades = New Reglas.Localidades()
         Me._publicos.PreparaGrillaLocalidades(Me.bscNombreLocalidadRetenciones)
         Me.bscNombreLocalidadRetenciones.Datos = oLocalidades.GetPorNombre(bscNombreLocalidadRetenciones.Text)
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub bscNombreLocalidadRetenciones_BuscadorSeleccion(sender As Object, e As Controles.BuscadorEventArgs) Handles bscNombreLocalidadRetenciones.BuscadorSeleccion
      Try
         If Not e.FilaDevuelta Is Nothing Then
            Me.CargarDatosLocalidadRetenciones(e.FilaDevuelta)
         End If
         Me.ProcessTabKey(True)
         'Me.txtNroCheque.Focus()
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub
   Private Sub CargarDatosLocalidadRetenciones(dr As DataGridViewRow)
      Me.bscCodigoLocalidadRetenciones.Text = dr.Cells("IdLocalidad").Value.ToString()
      Me.bscNombreLocalidadRetenciones.Text = dr.Cells("NombreLocalidad").Value.ToString()
   End Sub

   Private Sub btnPlanesTarjetas_Click(sender As Object, e As EventArgs) Handles btnPlanesTarjetas.Click
      Try

         If Me._tarjetas.Count > 0 Then
            If ShowPregunta("Al cambiar los planes de las tarjetas se perderán los registros de tarjeta ya ingresado. ¿Desea continuar?") = Windows.Forms.DialogResult.No Then
               Exit Sub
            End If
         End If


         Dim totalGeneral As Decimal = _ComprobantesGrilla.Sum(Function(x) x.Paga + x.DescuentoRecargo)     ' Decimal.Parse(txtTotalComprobantes.Text)

         Using frm As New SeleccionPlanesTarjetas(totalGeneral, Decimal.Parse(txtEfectivo.Text), Decimal.Parse(txtTransferenciaBancaria.Text), ntickets:=0, Decimal.Parse(txtCheques.Text), Decimal.Parse(txtImporteDolares.Text), Me._tarjetas, True, _ImporteAnticipoSinInteres)
            If frm.ShowDialog() = Windows.Forms.DialogResult.OK Then
               'If Not String.IsNullOrWhiteSpace(frm.txtImporteAnticipoSinInteres.Formato) Then
               Me._ImporteAnticipoSinInteres = frm.ImporteAnticipoSinInteres
               'End If

               Me.dgvTarjetas.DataSource = Me._tarjetas.ToArray()
               Me.txtEfectivo.Text = frm.Efectivo.ToString(txtEfectivo.Formato)
               '-- REQ- 34513.- -----------------------------------------------------------------------------
               txtTransferenciaBancaria.Text = frm.Transferencia.ToString(txtTransferenciaBancaria.Formato)
               txtImporteDolares.Text = frm.Dolares.ToString(txtImporteDolares.Formato)
               txtCheques.Text = frm.Cheques.ToString(txtCheques.Formato)
               '---------------------------------------------------------------------------------------------
               CalculaMontoInteresTarjeta()
               CalcularTotales()
               CalcularPagos()
               tbcDetalle2.SelectedTab = Me.tbpTarjetas
            End If

            Try
               If Math.Abs(Decimal.Parse(txtDiferencia.Text)) < 1 AndAlso _tarjetas.Count > 0 Then
                  _tarjetas(_tarjetas.Count - 1).Monto = _tarjetas(_tarjetas.Count - 1).Monto + Decimal.Parse(txtDiferencia.Text)
                  dgvTarjetas.DataSource = Me._tarjetas.ToArray()
                  CalcularPagos()
               End If
            Catch ex As Exception
               MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
         End Using

      Catch ex As Exception
         MessageBox.Show(ex.Message, Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub CalculaMontoInteresTarjeta()

      MontoDiferenciaPorPlanesTarjeta = _tarjetas.Sum(Function(x) x.MontoDelInteres)
      txtMontoInteresTarjeta.Text = MontoDiferenciaPorPlanesTarjeta.ToString()

   End Sub

   Private Sub dtpFechaTransferencia_Leave(sender As Object, e As EventArgs) Handles dtpFechaTransferencia.Leave
      Try
         If IsNumeric(txtTransferenciaBancaria.Text) AndAlso Decimal.Parse(txtTransferenciaBancaria.Text) <> 0 Then
            If dtpFechaTransferencia.Value.Date <> dtpFecha.Value.Date Then
               If ShowPregunta("La fecha de transferencia es diferente a la fecha del recibo, ¿desea ajustar la fecha del recibo a la fecha de transferencia?") = Windows.Forms.DialogResult.Yes Then
                  dtpFecha.Value = dtpFechaTransferencia.Value.Date
               End If
            End If
         End If
         CalculoPromedioPagoPonderados()
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

   Private Sub dtpFecha_Leave(sender As Object, e As EventArgs) Handles dtpFecha.Leave
      Try
         If IsNumeric(txtTransferenciaBancaria.Text) AndAlso Decimal.Parse(txtTransferenciaBancaria.Text) <> 0 Then
            If dtpFechaTransferencia.Value.Date <> dtpFecha.Value.Date Then
               If ShowPregunta("La fecha de transferencia es diferente a la fecha del recibo, ¿desea ajustar la fecha de transferencia a la fecha del recibo?") = Windows.Forms.DialogResult.Yes Then
                  dtpFechaTransferencia.Value = dtpFecha.Value.Date
               End If
            End If
         Else
            dtpFechaTransferencia.Value = dtpFecha.Value.Date
         End If
         CalculoPromedioPagoPonderados()
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

   Private Sub cmbTipoCheque_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbTipoCheque.SelectedIndexChanged
      If Me.cmbTipoCheque.SelectedIndex <> -1 Then
         If Not DirectCast(Me.cmbTipoCheque.SelectedItem, Entidades.TiposCheques).SolicitaNroOperacion Then
            Me.txtNroOperacion.Clear()
            Me.txtNroOperacion.Enabled = False
         Else
            Me.txtNroOperacion.Enabled = True
         End If
      Else
         Me.txtNroOperacion.Clear()
         Me.txtNroOperacion.Enabled = False
      End If
   End Sub

   Private Sub tsbConfigurarMail_Click(sender As Object, e As EventArgs) Handles tsbConfigurarMail.Click
      Try

         Dim txt As Textos = New Textos(Me.IdFuncion, "")
         txt.ShowDialog()

         Me._asunto = txt.asunto

         'Trabajo el cuerpo para que respete el formato
         Dim stbCuerpo As System.Text.StringBuilder = New System.Text.StringBuilder()

         Dim parts As String() = txt.cuerpo.Split(ControlChars.CrLf.ToCharArray)

         stbCuerpo.Append("<!DOCTYPE HTML>")
         stbCuerpo.Append("<html>")
         stbCuerpo.Append("<head>")
         stbCuerpo.Append("</head>")
         stbCuerpo.Append("<body>")

         For Each st As String In parts
            stbCuerpo.Append("<br>")
            stbCuerpo.Append(st)
         Next
         stbCuerpo.Append("</body>")
         stbCuerpo.Append("</html>")

         Me._cuerpo = stbCuerpo.ToString()

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

#Region "Transferencias Multiples"
   Private Sub bscCuentaBancariaTransfBancMultiple_BuscadorClick() Handles bscCuentaBancariaTransfBancMultiple.BuscadorClick
      TryCatched(
      Sub()
         _publicos.PreparaGrillaCuentasBancarias2(bscCuentaBancariaTransfBancMultiple)
         bscCuentaBancariaTransfBancMultiple.Datos = New Reglas.CuentasBancarias().GetFiltradoPorNombre(bscCuentaBancariaTransfBancMultiple.Text.Trim(), Entidades.Moneda.Peso)
      End Sub)
   End Sub
   Private Sub bscCodigoCuentaBancariaTransfBancMultiples_BuscadorClick() Handles bscCodigoCuentaBancariaTransfBancMultiples.BuscadorClick
      TryCatched(
      Sub()
         _publicos.PreparaGrillaCuentasBancarias2(bscCodigoCuentaBancariaTransfBancMultiples)
         bscCodigoCuentaBancariaTransfBancMultiples.Datos = New Reglas.CuentasBancarias().GetFiltradoPorCodigo(bscCodigoCuentaBancariaTransfBancMultiples.Text.ValorNumericoPorDefecto(0I))
      End Sub)
   End Sub
   Private Sub bscCuentaBancariaTransfBancMultiple_BuscadorSeleccion(sender As Object, e As Controles.BuscadorEventArgs) Handles bscCuentaBancariaTransfBancMultiple.BuscadorSeleccion, bscCodigoCuentaBancariaTransfBancMultiples.BuscadorSeleccion
      TryCatched(
      Sub()
         If Not e.FilaDevuelta Is Nothing Then
            bscCodigoCuentaBancariaTransfBancMultiples.Text = e.FilaDevuelta.Cells("IdCuentaBancaria").Value.ToString()
            bscCuentaBancariaTransfBancMultiple.Text = e.FilaDevuelta.Cells("NombreCuenta").Value.ToString()
            bscCodigoCuentaBancariaTransfBancMultiples.Selecciono = True
            bscCuentaBancariaTransfBancMultiple.Selecciono = True
            txtImporteTransferenciaMultiple.Focus()
         End If
      End Sub)
   End Sub
   Private Sub btnAgregarImporteTransfMultiple_Click(sender As Object, e As EventArgs) Handles btnAgregarImporteTransfMultiple.Click
      TryCatched(
      Sub()
         If ValidarInsertarTransfMultiple() Then
            InsertarTransferenciaMultiple()
            CalcularPagos()
         End If
      End Sub)
   End Sub
   Private Sub btnQuitarImporteTransfMultiple_Click(sender As Object, e As EventArgs) Handles btnQuitarImporteTransfMultiple.Click
      TryCatched(
      Sub()
         If ugTransferenciasMultiples.ActiveRow IsNot Nothing Then
            QuitarTransferenciaMultiple()
            CalcularPagos()
         End If
      End Sub)
   End Sub

   Private Sub InsertarTransferenciaMultiple()
      If _transferencias Is Nothing Then _transferencias = New List(Of Entidades.CuentaCorrienteTransferencia)
      _transferencias.Add(New Entidades.CuentaCorrienteTransferencia With
                          {
                              .IdCuentaBancaria = bscCodigoCuentaBancariaTransfBancMultiples.Text.ValorNumericoPorDefecto(0I),
                              .Orden = _transferencias.MaxSecure(Function(t) t.Orden).IfNull() + 1,
                              .Importe = txtImporteTransferenciaMultiple.ValorNumericoPorDefecto(0D),
                              .NombreCuenta = bscCuentaBancariaTransfBancMultiple.Text
                          })

      If ugTransferenciasMultiples.DataSource Is Nothing Then ugTransferenciasMultiples.DataSource = _transferencias
      txtImporteTransferenciaMultiple.SetValor(0D)
      bscCuentaBancariaTransfBancMultiple.Text = String.Empty
      bscCodigoCuentaBancariaTransfBancMultiples.Text = String.Empty
      ugTransferenciasMultiples.Rows.Refresh(RefreshRow.ReloadData)

      txtImporteTransferenciaMultiple.SelectAll()

      '# Si se cargan multiples transferencias, se debe bloquear el campo individual de importe de transferencia
      txtTransferenciaBancaria.ReadOnly = _transferencias.AnySecure()
      bscCuentaBancariaTransfBanc.Permitido = Not _transferencias.AnySecure()

      '# El importe visualizado en el Textbox de transferencias va a ser el total de las multiples realizadas
      txtTransferenciaBancaria.SetValor(_transferencias.Sum(Function(x) x.Importe))

      bscCuentaBancariaTransfBancMultiple.Focus()
   End Sub

   Private Sub QuitarTransferenciaMultiple()
      Dim dr = ugTransferenciasMultiples.FilaSeleccionada(Of Entidades.CuentaCorrienteTransferencia)
      If dr IsNot Nothing Then
         _transferencias.Remove(dr)
         ugTransferenciasMultiples.Rows.Refresh(RefreshRow.ReloadData)
      End If

      '# Si se cargan multiples transferencias, se debe bloquear el campo individual de importe de transferencia
      txtTransferenciaBancaria.ReadOnly = _transferencias.AnySecure()
      bscCuentaBancariaTransfBanc.Permitido = Not _transferencias.AnySecure()

      '# El importe visualizado en el Textbox de transferencias va a ser el total de las multiples realizadas
      txtTransferenciaBancaria.SetValor(_transferencias.Sum(Function(x) x.Importe))
   End Sub

   Private Function ValidarInsertarTransfMultiple() As Boolean
      If Not bscCodigoCuentaBancariaTransfBancMultiples.Selecciono Then
         ShowMessage("ATENCIÓN: Debe seleccionar una cuenta bancaria.")
         bscCodigoCuentaBancariaTransfBancMultiples.Focus()
         Return False
      End If
      If txtImporteTransferenciaMultiple.ValorNumericoPorDefecto(0D) = 0 Then
         ShowMessage("ATENCIÓN: El importe de la transferencia no puede ser 0.")
         txtImporteTransferenciaMultiple.Focus()
         Return False
      End If

      Return True
   End Function

#End Region

   Private Sub btnHistoricoVentas_Click(sender As Object, e As EventArgs) Handles btnHistoricoVentas.Click
      TryCatched(Sub() AbrirHistoricoCheques())
   End Sub

   '-- REQ-33040.- --
   Private Sub tsbDebeHaber_Click(sender As Object, e As EventArgs) Handles tsbDebeHaber.Click
      TryCatched(Sub() AbrirDebeHaberCliente())
   End Sub

   Private Sub chbDescuentoRecargoPorc_CheckedChanged(sender As Object, e As EventArgs) Handles chbDescuentoRecargoPorc.CheckedChanged
      TryCatched(
         Sub()
            txtDescuentoRecargoPorc.Enabled = chbDescuentoRecargoPorc.Checked
            txtDescuentoRecargoImporte.Enabled = chbDescuentoRecargoPorc.Checked
         End Sub)
   End Sub

   '-- Promedio Pagos Clientes.- ------------------------------------------------------------------------------------------------------
   Private Sub CalculoPromedioPagoPonderados()
      '-- Limpia Campos de Resumen.- --------------------------------------------------------------------------------------------------
      txtEmisionPromedioPago.Text = String.Empty
      txtFechaPromedioPago.Text = String.Empty
      txtDiasPromedioPago.Text = "0"
      txtDiasDirectos.Text = "0"
      '--------------------------------------------------------------------------------------------------------------------------------
      Dim calculo = Reglas.CuentasCorrientesPagos.CalcularPromedioPagoPonderados(dtpFecha.Value, _ComprobantesGrilla,
                                                                                 txtEfectivo.ValorNumericoPorDefecto(0D),
                                                                                 txtImporteDolares.ValorNumericoPorDefecto(0D),
                                                                                 txtTarjetas.ValorNumericoPorDefecto(0D),
                                                                                 txtTransferenciaBancaria.ValorNumericoPorDefecto(0D),
                                                                                 dtpFechaTransferencia.Value, _cheques, _retenciones,
                                                                                 New Reglas.TiposComprobantes().GetUno(Me.cmbTiposComprobantesRec.SelectedValue.ToString()))
      If calculo.Comprobantes IsNot Nothing And calculo.Pagos IsNot Nothing Then
         txtEmisionPromedioPago.Text = calculo.EmisionPromedioPagos.ToString("dd/MM/yyyy")
         txtFechaPromedioPago.Text = calculo.FechaPromedioPagos.ToString("dd/MM/yyyy")
         txtDiasPromedioPago.Text = calculo.DiasPromedioPago.ToString()
         txtDiasDirectos.Text = calculo.DiasDirectos.ToString()
         '-- Comprobantes.- -------------------------------------------------------------- 
         ugDetalle.DataSource = calculo.Comprobantes
         '-- Pagos.- ---------------------------------------------------------------------
         ugComprobantesMediosPagos.DataSource = calculo.Pagos '.Where(Function(x) (x.PorcentajeAfecta = 0 And x.Procesado = False) Or (x.PorcentajeAfecta > 0 And x.Procesado = True)).ToList()
      Else
         txtDiasDirectos.Text = calculo.DiasDirectos.ToString()
         '-- Comprobantes.- -------------------------------------------------------------- 
         ugDetalle.ClearFilas()
         '-- Pagos.- ---------------------------------------------------------------------
         ugComprobantesMediosPagos.ClearFilas()
      End If
      Me.dgvComprobantes.Refresh()
   End Sub

   Private Sub dtpFechaTransferencia_ValueChanged(sender As Object, e As EventArgs) Handles dtpFechaTransferencia.ValueChanged
      If _cargoBienLaPantalla Then
         '-- REQ-42455.- ----------------------------------
         CalculoPromedioPagoPonderados()
      End If
   End Sub

   Private Sub cmbDirecciones_KeyDown(sender As Object, e As KeyEventArgs) Handles cmbDirecciones.KeyDown
      Me.txtEfectivo.Focus()
   End Sub
End Class