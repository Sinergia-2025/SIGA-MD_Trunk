Public Class FacturacionRapida
   Implements IFacturacion

#Region "Constantes"

   Private Const funcionActual As String = "FacturacionRapidaSuper"
   '-- REQ-41770.- ---------------------------------------------------
   Private Const funcionFacSupri As String = "FacturacionRapidaSupri"
   '-- REQ-41772.- ---------------------------------------------------
   Private Const funcionFacNuevoSalida As String = "FacturacionRapidaNuevoSalida"
   '------------------------------------------------------------------

   Private Const funcionSupervisor As String = "FacturacionRapida"

   Private Const funcionActualLimiteCredito As String = "FactRapLimiteCreditoPermitido"
   Private Const funcionActualLimiteDiasVto As String = "FactRapLimiteDiasVtoPermitido"

#End Region

   Private Function LimiteCreditoPermitido() As Boolean
      Return BaseSeguridad.ControloPermisos(funcionActualLimiteCredito)
   End Function
   Private Function LimiteDiasVtoPermitido() As Boolean
      Return BaseSeguridad.ControloPermisos(funcionActualLimiteDiasVto)
   End Function

#Region "Campos"
   Private _tit As Dictionary(Of String, String) = New Dictionary(Of String, String)()
   Private _titCheques As Dictionary(Of String, String)
   Private _titPercepcionesIVA As Dictionary(Of String, String)
   Private _tituloOriginal As String

   Private _modificoPrecioManualmente As Boolean = False
   Private _modificoPrecioCodigoBarra As Boolean = False

   Private _txtPrecioEnter As Decimal

   Private _facturacionRapidaSolicitaCantidad As Boolean
   Private _facturacionRapidaAgrupaCantidad As Boolean
   Private _puedeEditarDolar As Boolean

   Private _ordenProducto As Integer

   '-- REQ-41750.- -------------------------------------------------------
   Private _cambioListaPrecio As Integer? = Nothing
   '----------------------------------------------------------------------

   Private _muestraTipoComprobante As Boolean
   Private _muestraLetraComprobante As Boolean
   Private _muestraNumeroComprobante As Boolean
   Private _solicitaVendedorPorDefecto As Boolean
   Private _solicitaTipoComprobantePorDefecto As Boolean
   Private _vendedorPorDefecto As Entidades.Empleado
   Private _idTipoComprobantePorDefecto As String

   Private _editarProductoDesdeGrilla As Boolean

   Private _ventasProductos As List(Of Entidades.VentaProducto)
   Private _subTotales As List(Of Entidades.VentaImpuesto)
   Private _estado As Estados
   Private _publicos As Publicos
   Private _numeroComprobante As Integer
   Private _clienteE As Entidades.Cliente
   Private _ModificaDetalle As String
   Private _cheques As List(Of Entidades.Cheque)
   Private _tarjetas As List(Of Entidades.VentaTarjeta)
   Private _transferencias As List(Of Entidades.VentaTransferencia)
   Private _ventasObservaciones As List(Of Entidades.VentaObservacion)
   Private _transportistaA As Entidades.Transportista
   Private _chequesRechazados As List(Of Entidades.Cheque)
   Private _estaCargando As Boolean = True
   Private _cantMaxItems As Integer
   Private _cantMaxItemsObserv As Integer
   Private _imprime As Boolean
   Private _tipoImpuestoIVA As Entidades.TipoImpuesto.Tipos = Entidades.TipoImpuesto.Tipos.IVA
   Private _categoriaFiscalEmpresa As Entidades.CategoriaFiscal
   Private _productoLoteTemporal As Entidades.VentaProductoLote
   Private _productosLotes As List(Of Entidades.VentaProductoLote)
   Private _productosNrosSeries As List(Of Entidades.ProductoNroSerie)
   Private _numeroOrden As Integer
   Private _modalidad As Eniac.Entidades.Producto.Modalidades
   Private _codigoBarrasCompleto As String
   Private _valorRedondeo As Integer = 2     '4 Se ajusto hasta que grabemos directamente los campos con IVA
   Private _decimalesAMostrar As Integer
   Private _formatoDecimalesAMostrar As String
   Private _ceroDecimalesAMostrar As String
   Private _decimalesEnDescRec As Integer
   Private _formatoDecimalesEnDescRec As String
   Private _ceroDecimalesEnDescRec As String
   Private _idCajaPorDefecto As Integer
   Private _fc As FacturacionComunes
   Private _comprobantesSeleccionados As List(Of Entidades.Venta)
   'Private _controladorFiscal As LibreriaFiscal.ControladorFiscal
   Private _blnMiraUsuario As Boolean = True
   Private _blnMiraPC As Boolean = Not Publicos.FacturacionIgnorarPCdeCaja
   Private _ConfiguracionImpresoras As Boolean
   Private _blnCajasModificables As Boolean = True
   'Private _cfiscal As ImpresionFiscal
   Private _IdCategoriaFiscalOriginal As Short = 0
   Private _DescRecGralPorc As Decimal = 0
   Private _DescuentosRecargosProd As Eniac.Reglas.DescuentoRecargoProducto
   Private _cantLineas As Integer = 0

   Private txtImpuestoInterno As TextBox = New TextBox()
   Private txtPorcImpuestoInterno As TextBox = New TextBox()

   Private _recalcularEfectivoAlCargarTarjeta As Boolean

   Private _cargoBienLaPantalla As Boolean
   Private _mensajeDeErrorEnCarga As String = ""

   Private _facturacionMantieneElClienteDefault As Long
   Private _nroOferta As Integer

   Private _decimalesEnCantidad As Integer
   Private _decimalesMostrarEnCantidad As Integer
   Private _formatoEnCantidad As String
   Private _decimalesRedondeoEnPrecio As Integer

   '# Lotes Seleccionados
   Private _lotesSeleccionados As DataTable

   '-- REQ-32953.- --------------------------------------------------------------------------
   Private _ValidacionCorrecta As Boolean = False
   Private _oMensaje As String = ""
   Private ActualizaPrecios As Boolean = Reglas.Publicos.ActualizaPreciosDeVenta()
   '----------------------------------------------------------------------------------------

   '-.PE-32996.-
   Private _idUsuario As String = actual.Nombre
   Private _idListaAux As Integer = -1
   Protected Property ModoClienteProspecto As Entidades.Cliente.ModoClienteProspecto

   '-- REQ-34669.- --------------------------------------------------------------------
   Public Property MovAtributo01 As Entidades.AtributoProducto
   Public Property MovAtributo02 As Entidades.AtributoProducto
   Public Property MovAtributo03 As Entidades.AtributoProducto
   Public Property MovAtributo04 As Entidades.AtributoProducto

   '-- REQ-35489.- --------------------------------------------------------------------------------------------------
   Private ReadOnly TipoAtributo01 As Short = Reglas.Publicos.AtributosProductos.TipoAtributo.TipoAtributoProducto01
   Private ReadOnly TipoAtributo02 As Short = Reglas.Publicos.AtributosProductos.TipoAtributo.TipoAtributoProducto02
   Private ReadOnly TipoAtributo03 As Short = Reglas.Publicos.AtributosProductos.TipoAtributo.TipoAtributoProducto03
   Private ReadOnly TipoAtributo04 As Short = Reglas.Publicos.AtributosProductos.TipoAtributo.TipoAtributoProducto04
   '-----------------------------------------------------------------------------------------------------------------

   Private flackCargaProductos As Boolean = True
   '-----------------------------------------------------------------------------------
   Private _FormaDePago As Entidades.VentaFormaPago
#End Region

#Region "Enumeraciones"

   Private Enum Estados
      Insercion
      Modificacion
   End Enum

   'Public Enum Modalidades
   '   NORMAL
   '   PESO
   'End Enum

#End Region

#Region "Overrides"

   Protected Overrides Sub OnLoad(e As System.EventArgs)

      MyBase.OnLoad(e)

      Try
         '-- REQ-32953.- --------------------------------------------------------------------------
         Dim oProductos = New Reglas.Productos().GetTipoBonificacion()
         If ActualizaPrecios And oProductos.Count > 0 Then
            _oMensaje = String.Format("{1}{0}{2}{0}{3}",
                                               Environment.NewLine,
                                               "Existen productos configurados con Tipo de Bonificacion = Lista de Precios",
                                               "Y está activo el parámetro Actualiza los precios de Venta si cambia la Lista de Precios.",
                                               "Ambos seteos no son compatibles. Por favor verifique la configuración")
            _ValidacionCorrecta = True
            Exit Sub
         End If
         '----------------------------------------------------------------------------------------

         pcbFoto.Visible = Reglas.Publicos.Facturacion.Rapida.FacturacionRapidaMuestraFotoProducto

         Me._cargoBienLaPantalla = False

         _tit = GetColumnasVisiblesGrilla(dgvProductos)
         tbcDetalle.SelectedTab = tbpTotales
         _titPercepcionesIVA = GetColumnasVisiblesGrilla(ugPercepcionIVA)
         tbcDetalle.SelectedTab = tbpProductos

         '-- REQ-34986.- --------------------------------------------------------------------------------------------------------------------------------
         With dgvProductos.Columns("DescripcionAtributo01")
            .HeaderText = New Reglas.TiposAtributosProductos().GetUno(TipoAtributo01).Descripcion
            If TipoAtributo01 > 0 Then
               lblAtributo01.Text = .HeaderText
               pnlAtributosProductos01.Visible = True
            End If
         End With
         With dgvProductos.Columns("DescripcionAtributo02")
            .HeaderText = New Reglas.TiposAtributosProductos().GetUno(TipoAtributo02).Descripcion
            If TipoAtributo02 > 0 Then
               lblAtributo02.Text = .HeaderText
               pnlAtributosProductos02.Visible = True
            End If
         End With
         With dgvProductos.Columns("DescripcionAtributo03")
            .HeaderText = New Reglas.TiposAtributosProductos().GetUno(TipoAtributo03).Descripcion
         End With
         With dgvProductos.Columns("DescripcionAtributo04")
            .HeaderText = New Reglas.TiposAtributosProductos().GetUno(TipoAtributo04).Descripcion
         End With
         '-----------------------------------------------------------------------------------------------------------------------------------------------

         _titCheques = GetColumnasVisiblesGrilla(dgvCheques)

         _solicitaVendedorPorDefecto = Reglas.Publicos.Facturacion.Rapida.FacturacionRapidaSolicitaVendedorPorDefecto
         _solicitaTipoComprobantePorDefecto = Reglas.Publicos.Facturacion.Rapida.FacturacionRapidaSolicitaTipoComprobantePorDefecto
         _muestraTipoComprobante = Reglas.Publicos.Facturacion.Rapida.FacturacionRapidaMuestraComprobante
         _muestraLetraComprobante = _muestraTipoComprobante
         _muestraNumeroComprobante = _muestraTipoComprobante

         _tituloOriginal = Text

         _valorRedondeo = Reglas.Publicos.Facturacion.Redondeo.FacturacionDecimalesRedondeoEnPrecio
         _decimalesEnDescRec = Reglas.Publicos.Facturacion.Redondeo.FacturacionDecimalesEnDescRec
         _decimalesAMostrar = Reglas.Publicos.Facturacion.Redondeo.FacturacionDecimalesEnPrecio
         _decimalesRedondeoEnPrecio = Reglas.Publicos.Facturacion.Redondeo.FacturacionDecimalesRedondeoEnPrecio

         _formatoDecimalesAMostrar = String.Format("N{0}", _decimalesAMostrar)
         _ceroDecimalesAMostrar = 0.ToString(_formatoDecimalesAMostrar)

         _formatoDecimalesEnDescRec = String.Format("N{0}", _decimalesEnDescRec)
         _ceroDecimalesEnDescRec = 0.ToString(_formatoDecimalesEnDescRec)


         _recalcularEfectivoAlCargarTarjeta = Reglas.Publicos.Facturacion.Rapida.FacturacionRapidaRecalcularEfectivoAlCargarTarjeta

         _facturacionRapidaSolicitaCantidad = Reglas.Publicos.Facturacion.Rapida.FacturacionRapidaSolicitaCantidad

         '-- REQ-33202.- -------------------------------------------------------
         _facturacionRapidaAgrupaCantidad = Reglas.Publicos.Facturacion.Rapida.FacturacionRapidaAgrupaProductos
         '----------------------------------------------------------------------

         'Seguridad de la Lista de Precios
         Dim oUsuario = New Eniac.Reglas.Usuarios()
         cmbListaDePrecios.Enabled = oUsuario.TienePermisos("Facturacion-ListaDePrecios")

         _puedeEditarDolar = oUsuario.TienePermisos("Fact-Rapid-ModCotizacionDolar")
         txtCotizacionDolar.Enabled = _puedeEditarDolar

         'Seguridad del Descuento/Recargo General
         'Me.txtDescRecGralPorc2.ReadOnly = Not oUsuario.TienePermisos( "Clientes-DescRecGeneralPorc")
         'Me.txtDescRecGralPorc2.ReadOnly = Not oUsuario.TienePermisos( "Clientes-DescRecGeneralPorc")


         txtDescRecGralPorc2.Visible = Not oUsuario.TienePermisos("Fact-RapidOcultaDescRecGral")
         lblDescRecGralPorcentaje.Visible = Not oUsuario.TienePermisos("Fact-RapidOcultaDescRecGral")

         '# La unica forma de que el tilde para modificar el Desc/Rec esté inhabilitado es que no tenga permisos ni tenga el parámetro activado
         If Not oUsuario.TienePermisos("Fact-RapidOcultaDescRecGral") AndAlso
            Not Reglas.Publicos.Facturacion.Rapida.FacturacionRapidaModificaDescRecGralPorc Then
            Me.chbModificaDescRecGralPorc.Enabled = False
         Else
            Me.chbModificaDescRecGralPorc.Enabled = True
         End If

         Me.lblDescRecGralPorc.Visible = Not oUsuario.TienePermisos("Fact-RapidOcultaDescRecGral")

         If Me.txtDescRecGralPorc2.Visible Then
            Me.chbModificaDescRecGralPorc.Visible = oUsuario.TienePermisos("Fact-RapidModifDescRecGral")
         End If

         Me.txtDescRecGralPorc2.Formato = "N" + _decimalesEnDescRec.ToString()
         Me.txtDescRecGralPorc2.Formato = "N" + _decimalesEnDescRec.ToString()
         Me.txtDescRecPorc1.Formato = "N" + _decimalesEnDescRec.ToString()
         Me.txtDescRecPorc2.Formato = "N" + _decimalesEnDescRec.ToString()
         Me.dgvProductos.Columns("DescuentoRecargoPorc1").DefaultCellStyle.Format = "N" + Me._decimalesEnDescRec.ToString()
         Me.dgvProductos.Columns("DescuentoRecargoPorc2").DefaultCellStyle.Format = "N" + Me._decimalesEnDescRec.ToString()

         '-- REG-32366.- --------------------------------------------------------------------------
         txtTransferenciaBancaria.Text = 0D.ToString("N" + _decimalesRedondeoEnPrecio.ToString())
         '-----------------------------------------------------------------------------------------

         'Seguridad de la Edición de Clientes (enlace a través de la etiqueta "Más info...")
         Me.llbCliente.Visible = oUsuario.TienePermisos("Clientes-PuedeUsarMasInfo")
         '---------------------------------------

         lnkProducto.Visible = oUsuario.TienePermisos("Productos")

         Me._publicos = New Publicos()
         Me._fc = New FacturacionComunes()

         Me._publicos.CargaComboTiposComprobantes(Me.cmbTiposComprobantes, True, "VENTAS", , , "SI", True)

         If Me.cmbTiposComprobantes.Items.Count = 0 Then
            Me._ConfiguracionImpresoras = True
         End If

         Me._publicos.CargaComboTipoDocumento(Me.cmbTipoDoc)

         Me._publicos.CargaComboCategoriasFiscales(Me.cmbCategoriaFiscal)

         '-.PE-32996.-
         Dim rEmpleados = New Reglas.Empleados
         If rEmpleados.GetPorTipo(Entidades.Publicos.TiposEmpleados.VENDEDOR, _idUsuario, False).Count = 0 Then
            'El usuario no es vendedor
            _publicos.CargaComboEmpleados(cmbVendedor, Entidades.Publicos.TiposEmpleados.VENDEDOR)
         Else
            'El usuario es vendedor
            _publicos.CargaComboEmpleados(cmbVendedor, Entidades.Publicos.TiposEmpleados.VENDEDOR, _idUsuario)
         End If
         '-----------

         _publicos.CargaComboFormasDePago(Me.cmbFormaPago, "VENTAS")
         _publicos.CargaComboListaDePrecios(Me.cmbListaDePrecios, activa:=True, insertarEnPosicionCero:=Nothing)
         '-- Guarda Valor Actual.- -------------------------------
         '--REQ-33274.- 
         cmbListaDePrecios.Tag = cmbListaDePrecios.SelectedValue
         '--------------------------------------------------------
         _publicos.CargaComboImpuestos(Me.cmbPorcentajeIva)

         _publicos.CargaComboCajas(Me.cmbCajas, Entidades.Usuario.Actual.Sucursal.Id, _blnMiraUsuario, _blnMiraPC, _blnCajasModificables)
         _publicos.CargaComboTarjetas(Me.cmbTarTarjeta, True)

         '# Tipos de Cheque
         Me._publicos.CargaComboTiposCheques(Me.cmbTipoCheque)

         'si tiene mas de 1 caja asignada tiene que seleccionar cual es la por defecto
         If Me.cmbTiposComprobantes.Items.Count > 0 Or _solicitaTipoComprobantePorDefecto Or _solicitaVendedorPorDefecto Then
            If Me.cmbCajas.Items.Count > 1 Or _solicitaTipoComprobantePorDefecto Or _solicitaVendedorPorDefecto Then
               SolicitaValoresPorDefecto()
            Else
               'si solo tiene una caja se la seteo
               Me._idCajaPorDefecto = Int32.Parse(Me.cmbCajas.SelectedValue.ToString())
            End If
         End If

         _facturacionMantieneElClienteDefault = Publicos.FacturacionMantieneElClienteDefault

         Me.SeteaDetalles()

         Me._estaCargando = False

         Me._categoriaFiscalEmpresa = New Reglas.CategoriasFiscales().GetUno(Reglas.Publicos.CategoriaFiscalEmpresa)

         'If Publicos.ProductoUtilizaCantidadesEnteras Then
         '   Me.txtCantidad.Formato = "##,##0"
         '   'Me.txtCantidad.IsDecimal = False   'No permite ingresar el signo de negativo
         'End If

         If Reglas.Publicos.ProductoUtilizaCantidadesEnteras Then
            _decimalesEnCantidad = 0
            _decimalesMostrarEnCantidad = 0
         Else
            _decimalesEnCantidad = Reglas.Publicos.Facturacion.Redondeo.FacturacionDecimalesRedondeoEnCantidad
            _decimalesMostrarEnCantidad = Reglas.Publicos.Facturacion.Redondeo.FacturacionDecimalesMostrarEnCantidad
         End If
         _formatoEnCantidad = String.Format("N{0}", _decimalesMostrarEnCantidad)
         Me.txtCantidad.Formato = _formatoEnCantidad
         Me.dgvProductos.Columns("Cantidad").DefaultCellStyle.Format = _formatoEnCantidad

         '# Botón para visualizar Lotes
         Me.dgvProductos.Columns("NrosLotes").Visible = Reglas.Publicos.VisualizaLote

         Me.tsbReemplazarComprobantes.Visible = Reglas.Publicos.Facturacion.Rapida.FacturacionRapidaReemplazarComprobantes
         Me.tsbImprimirPreTicket.Visible = oUsuario.TienePermisos("ImpresionTicketFiscal")

         Me._modalidad = Eniac.Entidades.Producto.Modalidades.NORMAL
         Me.PreparaFormatosControles()


         Me.Nuevo(Publicos.FacturacionMantieneElCliente AndAlso _facturacionMantieneElClienteDefault > 0, False)

         If Reglas.Publicos.RetieneIIBB Then
            MessageBox.Show("ATENCION: Esta Pantalla no se puede utilizar al ser Agente de Retencion de IIBB !!", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Me.tsbNuevo.Visible = False
            Me.tsbNuevo.Enabled = False
            Me.tsbGrabar.Visible = False
            Me.tsbGrabar.Enabled = False
         End If

         cmbTiposComprobantes.Visible = _muestraTipoComprobante
         txtLetra.Visible = _muestraLetraComprobante
         chbNumeroAutomatico.Visible = _muestraNumeroComprobante
         txtNumeroPosible.Visible = _muestraNumeroComprobante

         lblTipoComprobante.Visible = cmbTiposComprobantes.Visible
         lblLetra.Visible = txtLetra.Visible
         lblNumeroAutomatico.Visible = chbNumeroAutomatico.Visible
         lblNumeroPosible.Visible = txtNumeroPosible.Visible

         tsbCajaRegistradora.Visible = Not Environment.Is64BitOperatingSystem

         If tsbCajaRegistradora.Visible Then
            tsbCajaRegistradora.Visible = oUsuario.TienePermisos(actual.Nombre, actual.Sucursal.Id, "FacturacionRapida-AbrirCaja")
         End If

         tsbCanje.Visible = Reglas.Publicos.Facturacion.FacturacionUtilizaCanje

         SeteaColorGroupboxCliente()

         Me._cargoBienLaPantalla = True

         Me.ChequeaCajas()

         CargaTipoComprobanteProducto()

         '-- REQ-33325.- -----------------------------------------------------------------------------------------------------
         SeteaComprobanteSegunFormaDePago()
         '--------------------------------------------------------------------------------------------------------------------

         btnPlanesTarjetas.Visible = Reglas.Publicos.UtilizaInteresesTarjetas

      Catch ex As Exception
         Me.tsbNuevo.Visible = False
         Me.tsbGrabar.Visible = False
         Me.tsbCajaRegistradora.Visible = False
         Me.tsbReemplazarComprobantes.Visible = False
         Me.grbCliente.Enabled = False
         Me.tbcDetalle.Enabled = False
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
         Me._cargoBienLaPantalla = False
      End Try
   End Sub

   Private Sub SolicitaValoresPorDefecto()
      Using cd As SeleccionCajaDefecto = New SeleccionCajaDefecto(_solicitaVendedorPorDefecto, _solicitaTipoComprobantePorDefecto,
                                                                  _idCajaPorDefecto, _vendedorPorDefecto, _idTipoComprobantePorDefecto)
         cd.ShowDialog()
         Me._idCajaPorDefecto = cd.IdCaja

         If _solicitaVendedorPorDefecto Then
            _vendedorPorDefecto = cd.Vendedor
         End If
         If _solicitaTipoComprobantePorDefecto Then
            _idTipoComprobantePorDefecto = cd.IdTipoComprobante
         End If
      End Using
   End Sub

   Private Sub CambiarValoresPorDefecto()
      SolicitaValoresPorDefecto()

      Me.cmbCajas.SelectedValue = Me._idCajaPorDefecto

      If _solicitaVendedorPorDefecto AndAlso _vendedorPorDefecto IsNot Nothing Then
         cmbVendedor.SelectedItem = GetVendedorCombo(_vendedorPorDefecto.IdEmpleado)
      End If

      If _solicitaTipoComprobantePorDefecto AndAlso Not String.IsNullOrWhiteSpace(_idTipoComprobantePorDefecto) Then
         cmbTiposComprobantes.SelectedValue = _idTipoComprobantePorDefecto
      End If
   End Sub

   Protected Overrides Sub OnClosing(e As System.ComponentModel.CancelEventArgs)
      MyBase.OnClosing(e)

      'Pido la clave de autorizacion si tiene productos.
      If Me.dgvProductos.RowCount > 0 Then
         If Not Me.PuedoCancelarVenta(funcionActual, funcionFacNuevoSalida) Then
            e.Cancel = True
         End If
      End If
   End Sub
   Private Sub FacturacionRapida_VisibleChanged(sender As Object, e As EventArgs) Handles MyBase.VisibleChanged
      If Visible Then
         If Publicos.FacturacionMantieneElCliente AndAlso _facturacionMantieneElClienteDefault > 0 Then
            NavegacionDesdeClienteSegunParametros()
         End If
      End If
   End Sub

   Private Sub FacturacionRapida_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
      Try
         If _ConfiguracionImpresoras Then
            ShowMessage("No Existe la PC en Configuraciones/Impresoras")
            FormEnabled(False, {grbCliente, tbcDetalle}, tspFacturacion, {tsbSalir})
            'Me.Close()
         End If
         '-- REQ-32953.- --------------------------
         If _ValidacionCorrecta Then
            ShowMessage(_oMensaje)
            Me.Close()
         End If
         '-----------------------------------------
         Try
            Me.Enabled = False
            CalculosDescuentosRecargos1.Inicializar()
         Finally
            lblEstado.Text = String.Empty
            Me.Enabled = True
         End Try

         Me.Focus()

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
      End Try
   End Sub

   'No funciona
   'Protected Overrides Sub OnShown(e As System.EventArgs)

   '   MyBase.OnShown(e)

   '   If Publicos.RetieneIIBB Then

   '      'MessageBox.Show("ATENCION: Esta Pantalla no se puede utilizar al ser Agente de Retencion de IIBB !!", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
   '      'Me.Close()

   '      Throw New Exception("ATENCION: Esta Pantalla no se puede utilizar al ser Agente de Retencion de IIBB !!")

   '   End If

   'End Sub

#End Region

#Region "Eventos"

   Private _presionoElShift As Boolean = False

   Private Sub Grabar(tecla As Keys)
      If cmbCajas.SelectedIndex < 0 Then
         Exit Sub
      End If
      Dim caja As Entidades.CajaNombre = New Reglas.CajasNombres().GetUna(actual.Sucursal.IdSucursal, Integer.Parse(cmbCajas.SelectedValue.ToString()))
      Dim idTipoComprobanteNuevo As String = String.Empty

      If tecla.Equals(Keys.F3) Then
         If String.IsNullOrWhiteSpace(caja.IdTipoComprobanteF3) Then
            If Reglas.Publicos.Facturacion.FacturacionPermiteCobroTarjetaAutomatico Then
               If Not InsertarTarjetaTeclaRapidaF3() Then
                  Exit Sub
               End If
            Else
               Exit Sub
            End If
         Else
            idTipoComprobanteNuevo = caja.IdTipoComprobanteF3
         End If

      ElseIf tecla.Equals(Keys.F4) Then
         If Not String.IsNullOrWhiteSpace(caja.IdTipoComprobanteF4) Then
            idTipoComprobanteNuevo = caja.IdTipoComprobanteF4
         End If
      End If

      If Not String.IsNullOrWhiteSpace(idTipoComprobanteNuevo) Then
         Dim existe As Boolean = False
         For Each tpCom As Entidades.TipoComprobante In DirectCast(cmbTiposComprobantes.DataSource, List(Of Entidades.TipoComprobante))
            If tpCom.IdTipoComprobante = idTipoComprobanteNuevo Then
               cmbTiposComprobantes.SelectedValue = idTipoComprobanteNuevo
               existe = True
            End If
         Next
         If Not existe Then
            ShowMessage(String.Format("El tipo de comprobante {0} configurado en la Caja {1} como Comprobante de {2} no está habilitado. Por favor verifique y reintente.",
                                      idTipoComprobanteNuevo, cmbCajas.Text, tecla.ToString()))
            Exit Sub
         End If
      End If

      Me.tsbGrabar.PerformClick()
   End Sub

   Private Sub AbreAccionesAdicionales()
      Using frm As New FacturacionAccionesAdicionales()
         frm.ShowInTaskbar = False
         frm.StartPosition = FormStartPosition.CenterScreen
         If frm.ShowDialog(Me, {New FacturacionAccionesAdicionales.Accion(Keys.F5, "Cambiar valores por defecto", String.Empty),
                                New FacturacionAccionesAdicionales.Accion(Keys.F6, "Abrir Caja Registradora", "") With {.Visible = Not Environment.Is64BitOperatingSystem, .Imagen = tsbCajaRegistradora.Image},
                                New FacturacionAccionesAdicionales.Accion(Keys.F7, "Reemplazar Comprobantes", "CopiarComprobantes") With {.Visible = Reglas.Publicos.Facturacion.Rapida.FacturacionRapidaReemplazarComprobantes},
                                New FacturacionAccionesAdicionales.Accion(Keys.F8, "Imprimir Pre-Ticket", "ImpresionTicketFiscal")}) = Windows.Forms.DialogResult.OK Then
            Select Case frm.TeclaPresionada
               Case Keys.F5
                  CambiarValoresPorDefecto()
               Case Keys.F6
                  tsbCajaRegistradora.PerformClick()
               Case Keys.F7
                  tsbReemplazarComprobantes.PerformClick()
               Case Keys.F8
                  tsbImprimirPreTicket.PerformClick()
               Case Else

            End Select
         End If
      End Using
   End Sub

   Protected Overrides Function ProcessCmdKey(ByRef msg As Message, keyData As Keys) As Boolean
      If keyData = Keys.F2 Then
         tsbAccionesAdicionales.PerformClick()
      ElseIf keyData = Keys.F5 Then
         tsbNuevo.PerformClick()
      ElseIf keyData = Keys.F6 Then
         tsbCajaRegistradora.PerformClick()
      ElseIf keyData = Keys.F7 Then
         btnBuscarProducto.PerformClick()
      ElseIf keyData = Keys.F8 Then
         tbcDetalle.SelectedTab = tbpProductos
         If txtCantidad.Focused Then
            bscCodigoProducto2.Focus()
         Else
            txtCantidad.Focus()
         End If
      ElseIf keyData = Keys.F9 Then
         tbcDetalle.SelectedTab = tbpProductos
         bscCodigoProducto2.Focus()
      ElseIf keyData = Keys.F10 Then
         ReemplazarUltimoComprobante()
      ElseIf keyData = Keys.F11 Then
         If Not tbcDetalle.SelectedTab.Equals(tbpPagos) Then
            tbcDetalle.SelectedTab = tbpPagos
         Else
            If btnPlanesTarjetas.Visible Then
               btnPlanesTarjetas.PerformClick()
            End If
         End If
      ElseIf keyData = Keys.F12 Then
         tbcDetalle.SelectedTab = tbpTotales
         txtDescRecGralPorc2.Focus()
      ElseIf keyData = Keys.Escape Then
         btnLimpiarProducto.PerformClick()
      ElseIf keyData = (Keys.Add Or Keys.Control) Then
         btnInsertar.PerformClick()
      ElseIf keyData = (Keys.Subtract Or Keys.Control) Or keyData = (Keys.OemMinus Or Keys.Control) Then
         If dgvProductos.SelectedRows.Count > 0 Then
            btnEliminar.PerformClick()
            If dgvProductos.Rows.Count > 0 Then
               dgvProductos.Focus()
            Else
               bscCodigoProducto2.Focus()
            End If
         End If
      ElseIf keyData = (Keys.F4 Or Keys.Shift) Or keyData = (Keys.F3 Or Keys.Shift) Then
         _presionoElShift = True
         If tsbGrabar.Visible And tsbGrabar.Enabled Then
            Grabar(keyData)
         End If
      ElseIf keyData = Keys.F4 Or keyData = Keys.F3 Then
         _presionoElShift = False
         If tsbGrabar.Visible And tsbGrabar.Enabled Then
            Grabar(keyData)
         End If
      ElseIf keyData = (Keys.G Or Keys.Control) Then
         'Voy a la ultima posicion, al tomar el foco suele posicionarse primero y engaña la vision.
         If dgvProductos.RowCount > 0 Then
            dgvProductos.FirstDisplayedScrollingRowIndex = dgvProductos.Rows.Count - 1
            dgvProductos.Rows(dgvProductos.Rows.Count - 1).Selected = True
            dgvProductos.SelectedRows(0).Cells("IdProducto").Selected = True
         End If
         dgvProductos.Focus()
      ElseIf keyData = (Keys.I Or Keys.Control) Then
         pcbFoto.Visible = Not pcbFoto.Visible
      ElseIf keyData = (Keys.T Or Keys.Control) Then
         tbcDetalle.SelectedTab = tbpPagos
         tbcPagosTarChe.SelectedTab = tbpPagosTarjetas
      ElseIf keyData = (Keys.H Or Keys.Control) Then
         tbcDetalle.SelectedTab = tbpPagos
         tbcPagosTarChe.SelectedTab = tbpPagosCheques
      ElseIf keyData = (Keys.F Or Keys.Control) Then
         tbcDetalle.SelectedTab = tbpPagos
         tbcPagosTarChe.SelectedTab = tbpPagosTransferencias
      Else
         Return MyBase.ProcessCmdKey(msg, keyData)
      End If
      Return True
   End Function

   ''''Private Sub Facturacion_KeyUp(sender As Object, e As KeyEventArgs) Handles MyBase.KeyUp
   ''''   Try
   ''''      Select Case e.KeyCode
   ''''         'Case Keys.I
   ''''         '   If e.Control Then
   ''''         '      pcbFoto.Visible = Not pcbFoto.Visible
   ''''         '   End If
   ''''         'Case Keys.F2
   ''''         '   AbreAccionesAdicionales()
   ''''         'Case Keys.F5
   ''''         '   Me.tsbNuevo.PerformClick()
   ''''         Case Keys.F4, Keys.F3
   ''''            If e.Shift Then
   ''''               Me._presionoElShift = True
   ''''            End If
   ''''            If Me.tsbGrabar.Visible And Me.tsbGrabar.Enabled Then
   ''''               Grabar(e.KeyCode)
   ''''            End If
   ''''            'Case Keys.F6
   ''''            '   Me.tsbCajaRegistradora.PerformClick()
   ''''            'Case Keys.F8
   ''''            '   Me.tbcDetalle.SelectedTab = Me.tbpProductos
   ''''            '   If txtCantidad.Focused Then
   ''''            '      bscCodigoProducto2.Focus()
   ''''            '   Else
   ''''            '      Me.txtCantidad.Focus()
   ''''            '   End If
   ''''            'Case Keys.F9
   ''''            '   Me.tbcDetalle.SelectedTab = Me.tbpProductos
   ''''            '   Me.bscCodigoProducto2.Focus()
   ''''            'Case Keys.F10
   ''''            '   ReemplazarUltimoComprobante()
   ''''            'Case Keys.F11
   ''''            '   If Not tbcDetalle.SelectedTab.Equals(Me.tbpPagos) Then
   ''''            '      Me.tbcDetalle.SelectedTab = Me.tbpPagos
   ''''            '   Else
   ''''            '      If btnPlanesTarjetas.Visible Then
   ''''            '         btnPlanesTarjetas.PerformClick()
   ''''            '      End If
   ''''            '   End If
   ''''            'Case Keys.F12
   ''''            '   Me.tbcDetalle.SelectedTab = Me.tbpTotales
   ''''            '   Me.txtDescRecGralPorc2.Focus()
   ''''            'Case Keys.Add
   ''''            '   If e.Control Then
   ''''            '      Me.btnInsertar.PerformClick()
   ''''            '   End If
   ''''            'Case Keys.Subtract, Keys.OemMinus
   ''''            '   If e.Control Then
   ''''            '      If Me.dgvProductos.SelectedRows.Count > 0 Then
   ''''            '         Me.btnEliminar.PerformClick()
   ''''            '         If Me.dgvProductos.Rows.Count > 0 Then
   ''''            '            Me.dgvProductos.Focus()
   ''''            '         Else
   ''''            '            Me.bscCodigoProducto2.Focus()
   ''''            '         End If
   ''''            '      End If
   ''''            '   End If
   ''''            'Case Keys.Escape
   ''''            '   Me.btnLimpiarProducto.PerformClick()
   ''''            'Case Keys.D
   ''''            '   If e.Control Then
   ''''            '      Me.cmbVendedor.Focus()
   ''''            '   End If
   ''''            'Case Keys.F
   ''''            '   If e.Control Then
   ''''            '      Me.dtpFecha.Focus()
   ''''            '   End If
   ''''            'Case Keys.G
   ''''            '   If e.Control Then
   ''''            '      'Voy a la ultima posicion, al tomar el foco suele posicionarse primero y engaña la vision.
   ''''            '      If Me.dgvProductos.RowCount > 0 Then
   ''''            '         Me.dgvProductos.FirstDisplayedScrollingRowIndex = Me.dgvProductos.Rows.Count - 1
   ''''            '         Me.dgvProductos.Rows(Me.dgvProductos.Rows.Count - 1).Selected = True
   ''''            '         Me.dgvProductos.SelectedRows(0).Cells("IdProducto").Selected = True
   ''''            '      End If
   ''''            '      Me.dgvProductos.Focus()
   ''''            '   End If
   ''''            'Case Keys.J
   ''''            '   If e.Control Then
   ''''            '      Me.tbcDetalle.SelectedTab = Me.tbpPagos
   ''''            '      Me.cmbCajas.Focus()
   ''''            '   End If
   ''''            'Case Keys.L
   ''''            '   If e.Control Then
   ''''            '      Me.cmbListaDePrecios.Focus()
   ''''            '   End If
   ''''            'Case Keys.N
   ''''            '   If e.Control Then
   ''''            '      Me.bscCliente.Focus()
   ''''            '   End If
   ''''            'Case Keys.P
   ''''            '   If e.Control Then
   ''''            '      Me.cmbFormaPago.Focus()
   ''''            '   End If
   ''''            'Case Keys.T
   ''''            '   If e.Control Then
   ''''            '      Me.cmbTiposComprobantes.Focus()
   ''''            '   End If
   ''''         Case Else
   ''''      End Select
   ''''   Catch ex As Exception
   ''''      ShowError(ex)
   ''''   End Try
   ''''End Sub

   Private Sub ReemplazarUltimoComprobante()
      If IsNumeric(cmbCajas.SelectedValue) Then
         Dim idCaja As Integer = Integer.Parse(cmbCajas.SelectedValue.ToString())

         Dim caja As Entidades.CajaNombre = New Reglas.CajasNombres().GetUna(actual.Sucursal.Id, idCaja)
         If Not String.IsNullOrWhiteSpace(caja.IdTipoComprobanteF10Origen) Then
            Using frm As CopiarComprobantes = New CopiarComprobantes(New CopiarComprobantes.ConfiguracionAutomatica() _
                                                                           With {.Usuario = actual.Nombre,
                                                                                 .IdCaja = caja.IdCaja,
                                                                                 .IdTipoComprobanteOrigen = caja.IdTipoComprobanteF10Origen,
                                                                                 .IdTipoComprobanteDestino = caja.IdTipoComprobanteF10Destino})
               frm.IdFuncion = IdFuncion
               frm.ShowDialog()
            End Using
         End If
      End If
   End Sub

   Private Sub txtImporteCheque_KeyDown(sender As Object, e As KeyEventArgs) Handles txtImporteCheque.KeyDown
      Me.PresionarTab(e)
   End Sub

   Private Sub txtTitularCheque_KeyDown(sender As Object, e As KeyEventArgs) Handles txtTitularCheque.KeyDown
      Me.PresionarTab(e)
   End Sub

   Private Sub dtpFechaCobro_KeyDown(sender As Object, e As KeyEventArgs) Handles dtpFechaCobro.KeyDown
      Me.PresionarTab(e)
   End Sub

   Private Sub dtpFechaEmision_KeyDown(sender As Object, e As KeyEventArgs) Handles dtpFechaEmision.KeyDown
      Me.PresionarTab(e)
   End Sub

   Private Sub txtCodPostalCheque_KeyDown(sender As Object, e As KeyEventArgs) Handles txtCodPostalCheque.KeyDown
      Me.PresionarTab(e)
   End Sub

   Private Sub txtSucursalBanco_KeyDown(sender As Object, e As KeyEventArgs) Handles txtSucursalBanco.KeyDown
      Me.PresionarTab(e)
   End Sub

   Private Sub txtNroCheque_KeyDown(sender As Object, e As KeyEventArgs) Handles txtNroCheque.KeyDown
      Me.PresionarTab(e)
   End Sub

   Private Sub bscBancos_BuscadorClick() Handles bscBancos.BuscadorClick
      Try
         Me._publicos.PreparaGrillaBancos(Me.bscBancos)
         Dim oBanco As Eniac.Reglas.Bancos = New Eniac.Reglas.Bancos()
         Me.bscBancos.Datos = oBanco.GetFiltradoPorNombre(Me.bscBancos.Text.Trim())
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
      End Try
   End Sub

   Private Sub bscBancos_BuscadorSeleccion(sender As Object, e As Eniac.Controles.BuscadorEventArgs) Handles bscBancos.BuscadorSeleccion
      Try
         If Not e.FilaDevuelta Is Nothing Then
            Me.CargarDatosBancos(e.FilaDevuelta)
            Me.txtNroCheque.Focus()
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
         'Me.Nuevo()
      End Try
   End Sub

   Private Sub txtTarjetas_KeyUp(sender As Object, e As KeyEventArgs) Handles txtTarjetas.KeyUp
      Me.PresionarTab(e)
   End Sub

   Private Sub txtCheques_KeyUp(sender As Object, e As KeyEventArgs) Handles txtCheques.KeyUp
      Me.PresionarTab(e)
   End Sub

   Private Sub txtTickes_Leave(sender As Object, e As EventArgs)
      Try
         Me.CalcularPagos(False)
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
      End Try
   End Sub

   Private Sub txtTickets_KeyUp(sender As Object, e As KeyEventArgs)
      Me.PresionarTab(e)
   End Sub

   Private Sub txtEfectivo_Leave(sender As Object, e As EventArgs) Handles txtEfectivo.Leave
      TryCatched(Sub() CalcularPagos(False))
   End Sub
   Private Sub txtImporteDolares_Leave(sender As Object, e As EventArgs) Handles txtImporteDolares.Leave
      TryCatched(Sub() CalcularPagos(False))
   End Sub

   Private Sub txtEfectivo_KeyUp(sender As Object, e As KeyEventArgs) Handles txtEfectivo.KeyUp, txtImporteDolares.KeyUp
      PresionarTab(e)
   End Sub

   Private Sub tsbNuevo_Click(sender As Object, e As EventArgs) Handles tsbNuevo.Click
      Try
         If PuedoCancelarVenta(funcionActual, funcionFacNuevoSalida) Then
            If _ventasProductos.Count = 0 OrElse ShowPregunta("ATENCION: ¿Desea Realizar un Comprobante Nuevo?", MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.Yes Then
               Me.Nuevo(False, False)
            End If
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
      End Try
   End Sub

   Private Sub tsbSalir_Click(sender As Object, e As EventArgs) Handles tsbSalir.Click
      Me.Close()
   End Sub
   Private Sub FacturacionRapida_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing

      Dim intRegistros As Integer = Me.dgvProductos.RowCount

      If intRegistros <> 0 Then
         If MessageBox.Show("Quedan Productos pendientes de Grabar, desea salir de todas formas?", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) <> Windows.Forms.DialogResult.Yes Then
            e.Cancel = True
            Return
         End If
      End If
   End Sub
   Private Sub bscCodigoProducto2_BuscadorClick() Handles bscCodigoProducto2.BuscadorClick
      Try
         Dim oProductos As Reglas.Productos = New Reglas.Productos()
         Me._publicos.PreparaGrillaProductos2(Me.bscCodigoProducto2)
         Dim codProd As String = String.Empty
         Me._codigoBarrasCompleto = Me.bscCodigoProducto2.Text.Trim()

         codProd = Me.bscCodigoProducto2.Text.Trim()


         Dim dt As DataTable

         Dim idCliente As Long = 0
         idCliente = Long.Parse(Me.bscCodigoCliente.Tag.ToString())

         dt = oProductos.GetPorCodigo(codProd, actual.Sucursal.Id, DirectCast(Me.cmbListaDePrecios.SelectedItem, Entidades.ListaDePrecios).IdListaPrecios, "VENTAS", , , , , , , , , idCliente, soloBuscaPorIdProducto:=_editarProductoDesdeGrilla)

         If dt.Rows.Count > 0 Then
            Me._modalidad = Eniac.Entidades.Producto.Modalidades.NORMAL
         Else
            _modificoPrecioCodigoBarra = True

            codProd = Me.GetCodigoModalidadPeso()
            dt = oProductos.GetPorCodigo(codProd, actual.Sucursal.Id, DirectCast(Me.cmbListaDePrecios.SelectedItem, Entidades.ListaDePrecios).IdListaPrecios, "VENTAS", , Eniac.Entidades.Producto.Modalidades.PESO.ToString(), , , , , , , idCliente, soloBuscaPorIdProducto:=_editarProductoDesdeGrilla)
            If dt.Rows.Count > 0 Then
               Me._modalidad = DirectCast([Enum].Parse(GetType(Eniac.Entidades.Producto.Modalidades), dt.Rows(0)(Entidades.Producto.Columnas.ModalidadCodigoDeBarras.ToString()).ToString()), Eniac.Entidades.Producto.Modalidades)  ''   Modalidades.PESO
            Else
               'aca va la pantalla
               Dim frm As New AvisoProductoInexistente()
               frm.ShowDialog()
            End If
         End If
         Me.bscCodigoProducto2.Datos = dt
      Catch ex As Exception
         ShowError(ex)
      Finally
         '# Reseteo la propiedad de vuelta a False
         _editarProductoDesdeGrilla = False
      End Try
   End Sub

   Private Sub bscCodigoProducto2_BuscadorSeleccion(sender As Object, e As Controles.BuscadorEventArgs) Handles bscCodigoProducto2.BuscadorSeleccion
      Try
         If Not e.FilaDevuelta Is Nothing Then
            Me.CargarProducto(e.FilaDevuelta)
            If _facturacionRapidaSolicitaCantidad Then
               txtCantidad.Focus()
            Else
               If ProductModif = False Then
                  btnInsertar.Focus()
                  btnInsertar.PerformClick()
               End If
            End If

            Me.bscProducto2.FilaDevuelta = Me.bscCodigoProducto2.FilaDevuelta
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
      End Try
   End Sub

   Private Sub bscProducto2_BuscadorClick() Handles bscProducto2.BuscadorClick
      Try
         Dim oProductos As Reglas.Productos = New Reglas.Productos
         Me._publicos.PreparaGrillaProductos2(Me.bscProducto2)
         Dim idCliente As Long = 0
         idCliente = Long.Parse(Me.bscCodigoCliente.Tag.ToString())
         Me.bscProducto2.Datos = oProductos.GetPorNombre(Me.bscProducto2.Text.Trim(), actual.Sucursal.Id, DirectCast(Me.cmbListaDePrecios.SelectedItem, Entidades.ListaDePrecios).IdListaPrecios, "VENTAS", , , , , , , , idCliente)
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
      End Try
   End Sub

   Private Sub bscProducto2_BuscadorSeleccion(sender As Object, e As Controles.BuscadorEventArgs) Handles bscProducto2.BuscadorSeleccion
      Try
         If Not e.FilaDevuelta Is Nothing Then
            Me.CargarProducto(e.FilaDevuelta)
            If _facturacionRapidaSolicitaCantidad Then
               txtCantidad.Focus()
            Else
               If ProductModif = False Then
                  Me.btnInsertar.PerformClick()
               End If
            End If

            Me.bscCodigoProducto2.FilaDevuelta = Me.bscProducto2.FilaDevuelta
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
      End Try
   End Sub

   Private Sub lnkProducto_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lnkProducto.LinkClicked
      TryCatched(
         Sub()
            Dim prod = New Entidades.Producto()
            If Not String.IsNullOrWhiteSpace(bscCodigoProducto2.Text) Then
               prod = New Reglas.Productos().GetUno(bscCodigoProducto2.Text, True, True, accion:=Reglas.Base.AccionesSiNoExisteRegistro.Vacio)
            End If
            Using pr = New ProductosDetalle(prod)
               pr.StateForm = If(String.IsNullOrWhiteSpace(prod.IdProducto), StateForm.Insertar, StateForm.Actualizar)
               pr.CierraAutomaticamente = True
               If pr.ShowDialog() = Windows.Forms.DialogResult.OK Then
                  bscCodigoProducto2.Text = pr.IdProducto
                  bscCodigoProducto2.PresionarBoton()
               End If
            End Using
         End Sub)
   End Sub

   Private Sub txtDescRecGralPorc2_GotFocus(sender As Object, e As EventArgs) Handles txtDescRecGralPorc2.GotFocus
      Me.txtDescRecGralPorc2.SelectAll()
   End Sub

   Private Sub txtDescRecGralPorc2_KeyDown(sender As Object, e As KeyEventArgs) Handles txtDescRecGralPorc2.KeyDown
      If e.KeyCode = Keys.Enter Then
         If Me.cmbCategoriaFiscal.Enabled Then
            Me.cmbCategoriaFiscal.Focus()
         Else
            Me.cmbVendedor.Focus()
         End If
      End If
   End Sub

   Private Sub txtDescRecGralPorc2_Leave(sender As Object, e As EventArgs) Handles txtDescRecGralPorc2.Leave
      Try
         Me.CalcularDatosDetalle()
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
      End Try
   End Sub

   Private Sub tsbGrabar_Click(sender As Object, e As EventArgs) Handles tsbGrabar.Click
      Try
         Me.Cursor = Cursors.WaitCursor
         Me.GrabarComprobante()
      Catch ex As Exception
         Dim ex1 As Entidades.EniacException = New Entidades.EniacException(ex.Message)
         ShowError(ex, True)
      Finally
         Me._presionoElShift = False
         Me.Cursor = Cursors.Default
         Me.tsbGrabar.Enabled = True
      End Try
   End Sub

   Private Sub tsbCanje_Click(sender As Object, e As EventArgs) Handles tsbCanje.Click

      '-- Valido que haya ingresado el cliente. Recien ahi llamo al procedimiento para ahorrar tiempo.
      If Not Me.bscCodigoCliente.Selecciono And Not Me.bscCliente.Selecciono Then
         Exit Sub
      End If

      Try
         Me.Cursor = Cursors.WaitCursor
         '-- Invoco al procedimiento de Canje.- --
         ProcedimientoDeCanje()
      Catch ex As Exception
         Dim ex1 As Entidades.EniacException = New Entidades.EniacException(ex.Message)
         ShowError(ex, True)
      Finally
         Me.Cursor = Cursors.Default
      End Try

   End Sub

   Private Sub btnBuscarProducto_Click(sender As Object, e As EventArgs) Handles btnBuscarProducto.Click
      TryCatched(Sub() BuscarProductoConConsultaPrecios())
   End Sub
   Private Sub BuscarProductoConConsultaPrecios()
      If bscProducto2.Enabled Then
         Using frm = New ConsultarPrecios(esdeVentas:="SI", esDeCompras:="TODOS")
            frm.ConsultarAutomaticamente = True
            If frm.ShowDialogParaBusqueda(bscCodigoProducto2.Text, bscProducto2.Text, cmbListaDePrecios.ValorSeleccionado(Reglas.Publicos.ListaPreciosPredeterminada)) = Windows.Forms.DialogResult.OK Then
               If Not String.IsNullOrWhiteSpace(frm.IdProductoDevuelta) Then
                  bscCodigoProducto2.Text = frm.IdProductoDevuelta
                  bscCodigoProducto2.PresionarBoton()
               End If
            End If
         End Using
      End If
   End Sub


   Private Sub ProcedimientoDeCanje()
      Using frm As New FacturacionUtilizaCanje()
         '-- Pasa Parametros.- ----------------------------------------
         frm.idCliente = Long.Parse(Me.bscCodigoCliente.Tag.ToString())
         frm.idListaPrecios = DirectCast(Me.cmbListaDePrecios.SelectedItem, Entidades.ListaDePrecios).IdListaPrecios
         frm._clienteE = _clienteE
         frm.fechaCompro = dtpFecha.Value
         frm._categoriaFiscalEmpresa = _categoriaFiscalEmpresa
         frm._cotizacionDolar = txtCotizacionDolar.ValorNumericoPorDefecto(0D)
         frm._valorRedondeo = _valorRedondeo
         '-------------------------------------------------------------
         frm.ShowInTaskbar = False
         frm.StartPosition = FormStartPosition.CenterScreen


         If frm.ShowDialog() = Windows.Forms.DialogResult.OK Then
            '-- REQ-34986.- ----------------------------------------
            _ventasProductos.Clear()
            SetProductosDataSource()
            CalcularDatosDetalle()
            '-- Setea Tipo de Comprobante.- ------------------------
            cmbTiposComprobantes.SelectedValue = frm.cmbTipoComprobante.SelectedValue

            For Each dr As DataGridViewRow In frm.dgvDetalle.Rows
               '-- Carga la Cantidad.- -------------
               txtCantidad.Text = (Decimal.Parse(dr.Cells(10).Value.ToString()) * DirectCast(cmbTiposComprobantes.SelectedItem, Entidades.TipoComprobante).CoeficienteValores).ToString()
               txtCantidad.Focus()
               '-- Carga Producto.- ----------------
               bscCodigoProducto2.Text = dr.Cells(0).Value.ToString()
               flackCargaProductos = False
               bscCodigoProducto2.PresionarBoton()
               '-- Aloja los datos recuperados.- --
               With MovAtributo01
                  .IdaAtributoProducto = Integer.Parse(dr.Cells("IdaAtributoProducto01").Value.ToString())
                  .Descripcion = dr.Cells("DescripcionAtributo01").Value.ToString()
               End With
               With MovAtributo02
                  .IdaAtributoProducto = Integer.Parse(dr.Cells("IdaAtributoProducto02").Value.ToString())
                  .Descripcion = dr.Cells("DescripcionAtributo02").Value.ToString()
               End With
               With MovAtributo03
                  .IdaAtributoProducto = Integer.Parse(dr.Cells("IdaAtributoProducto03").Value.ToString())
                  .Descripcion = dr.Cells("DescripcionAtributo03").Value.ToString()
               End With
               With MovAtributo04
                  .IdaAtributoProducto = Integer.Parse(dr.Cells("IdaAtributoProducto04").Value.ToString())
                  .Descripcion = dr.Cells("DescripcionAtributo04").Value.ToString()
               End With
               '-------------------------------------------------------
               flackCargaProductos = True
               txtPrecio.Focus()
               btnInsertar.Focus()
               btnInsertar.PerformClick()
            Next
         End If
      End Using
   End Sub
   Private Sub bscCodigoCliente_BuscadorClick() Handles bscCodigoCliente.BuscadorClick
      Dim codigoCliente As Long = -1
      Try
         Me._publicos.PreparaGrillaClientes2(Me.bscCodigoCliente)
         Dim oClientes As Reglas.Clientes = New Reglas.Clientes
         If Me.bscCodigoCliente.Text.Trim.Length > 0 Then
            Dim val As Integer
            If Not Integer.TryParse(bscCodigoCliente.Text, val) Then
               If Reglas.Publicos.ClienteMuestraCodigoClienteLetras Then
                  Me.bscCodigoCliente.Datos = oClientes.GetFiltradoPorCodigoClienteLetras(Me.bscCodigoCliente.Text.Trim())
               Else
                  MessageBox.Show("El Código de Cliente debe ser numérico.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
               End If
            Else
               Me.bscCodigoCliente.Datos = oClientes.GetFiltradoPorCodigo(Long.Parse(Me.bscCodigoCliente.Text.Trim()), True, True)
            End If
         Else
            Me.bscCodigoCliente.Datos = oClientes.GetFiltradoPorCodigo(codigoCliente, True, True)
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try

   End Sub

   Private Sub bscCodigoCliente_BuscadorSeleccion(sender As Object, e As Controles.BuscadorEventArgs) Handles bscCodigoCliente.BuscadorSeleccion
      Try
         If Not e.FilaDevuelta Is Nothing Then
            Me.CargarDatosCliente(e.FilaDevuelta)
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
         Try
            Me.Nuevo(False, False)
         Catch ex1 As Exception
            MessageBox.Show(ex1.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
         End Try
      Finally
         Me.Cursor = Cursors.Default
      End Try
   End Sub

   Private Sub bscCliente_BuscadorClick() Handles bscCliente.BuscadorClick
      Try
         Me._publicos.PreparaGrillaClientes2(Me.bscCliente)
         Dim oClientes As Reglas.Clientes = New Reglas.Clientes
         Me.bscCliente.Datos = oClientes.GetFiltradoPorNombre(Me.bscCliente.Text.Trim(), True)
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
      End Try
   End Sub

   Private Sub bscCliente_BuscadorSeleccion(sender As Object, e As Controles.BuscadorEventArgs) Handles bscCliente.BuscadorSeleccion
      Try
         If Not e.FilaDevuelta Is Nothing Then
            Me.CargarDatosCliente(e.FilaDevuelta)
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
         Try
            Me.Nuevo(False, False)
         Catch ex1 As Exception
            MessageBox.Show(ex1.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
         End Try
      Finally
         Me.Cursor = Cursors.Default
      End Try
   End Sub

   Private Sub llbCliente_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles llbCliente.LinkClicked
      Try
         MostrarMasInfo()
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

   Private Function MostrarMasInfo() As DialogResult

      Dim clie As Entidades.Cliente = Nothing
      If Me.bscCodigoCliente.Selecciono Or Me.bscCliente.Selecciono Then
         clie = New Eniac.Reglas.Clientes().GetUno(Long.Parse(Me.bscCodigoCliente.Tag.ToString()), incluirFoto:=True)
      End If
      Dim result As DialogResult = Ayudante.MasInfoCliente.MostrarMasInfo.Mostrar(clie)
      If result = Windows.Forms.DialogResult.OK Then
         Me.bscCodigoCliente.Text = clie.CodigoCliente.ToString()
         Dim prevPermitido As Boolean = bscCodigoCliente.Permitido
         Me.bscCodigoCliente.Enabled = True
         Me.bscCodigoCliente.PresionarBoton()
         bscCodigoCliente.Permitido = prevPermitido
         If clie.NroDocCliente = 0 Then
            result = DialogResult.Cancel
         End If
      End If
      Return result

   End Function

   Private Sub txtPrecio_KeyDown(sender As Object, e As KeyEventArgs) Handles txtPrecio.KeyDown
      If e.KeyCode = Keys.Enter Then
         Me.btnInsertar.Focus()
         Me.btnInsertar.PerformClick()
      End If
   End Sub

   Private Sub btnInsertar_Click(sender As Object, e As EventArgs) Handles btnInsertar.Click
      Try
         If Me.ValidarInsertaProducto() Then
            Me.InsertarProducto()
            ProductModif = False
            Me.bscCodigoProducto2.Focus()
            If Me._ModificaDetalle <> "TODO" Then
               Me.CambiarEstadoControlesDetalle(False)
            End If
            'Me.CargarCantidadItems()
            '-- REQ-41750.- ------------------------------------------------------------------
            If _cambioListaPrecio.HasValue Then
               cmbListaDePrecios.SelectedValue = _cambioListaPrecio
               _cambioListaPrecio = Nothing
            End If
            '---------------------------------------------------------------------------------
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
      End Try
   End Sub

   Private Sub btnEliminar_Click(sender As Object, e As EventArgs) Handles btnEliminar.Click
      Try
         If Me.PuedoCancelarVenta(funcionFacSupri, funcionActual) Then
            If Me.dgvProductos.SelectedRows.Count > 0 Then
               If MessageBox.Show("Esta seguro de eliminar el producto seleccionado?", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                  Me.EliminarLineaProducto()
               End If
               'Me.CargarCantidadItems()
            End If
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
      End Try
   End Sub

   Private Sub txtPrecio_Leave(sender As Object, e As EventArgs) Handles txtPrecio.Leave
      Try
         If Me.txtPrecio.Text.Trim().Length = 0 Then
            Me.txtPrecio.Text = _ceroDecimalesAMostrar
         End If
         'dp - Lo comento para hasta que Bazar Celta defina como lo quiere.
         'If Decimal.Parse(Me.txtPrecio.Text) <= 0 And Not Me._ventasConProductosEnCero Then
         '   Dim oProd As Reglas.Productos = New Reglas.Productos()
         '   Dim prod As Entidades.Producto = New Entidades.Producto()
         '   prod = oProd.GetUno(Me.bscCodigoProducto2.Text)
         '   If Not prod.EsObservacion Then
         '      MessageBox.Show("No puede ingresar un producto con precio cero.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
         '      FocusPrecio()
         '      Exit Sub
         '   End If
         'End If
         If Not _modificoPrecioManualmente Then
            _modificoPrecioManualmente = _txtPrecioEnter <> txtPrecio.ValorNumericoPorDefecto(0D)
         End If

         Me.CalcularDescuentosProductos()
         Me.CalcularTotalProducto()
         Me.CalcularImpuestoInterno()
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

   Private Sub txtPrecio_LostFocus(sender As Object, e As EventArgs) Handles txtPrecio.LostFocus
      Try
         If Me.txtPrecio.Text.Trim().Length = 0 Then
            Me.txtPrecio.Text = _ceroDecimalesAMostrar
         End If
         Me.CalcularTotalProducto()
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
      End Try
   End Sub

   Private Sub txtCantidad_LostFocus(sender As Object, e As EventArgs) Handles txtCantidad.LostFocus
      Try
         Dim calculaDescuentoRecargo2 As Boolean = Not Reglas.Publicos.Facturacion.FacturacionDescuentoRecargo2CargaManual
         If Not IsNumeric(Me.txtCantidad.Text) Then
            Me.txtCantidad.Text = (1).ToString(_formatoEnCantidad)
         Else
            If Me.txtPrecio.Text = "-" Then
               Me.txtPrecio.Text = _ceroDecimalesAMostrar
            End If
         End If

         If Me.bscCodigoProducto2.Text <> "" Then
            'Se calculan los decuentos por Cantidad/Rubro
            Dim Producto As Entidades.Producto = New Reglas.Productos().GetUno(Me.bscCodigoProducto2.Text.ToString())


            If Reglas.Publicos.Facturacion.FacturacionDescuentosAgrupaCantidadesPorRubro Then
               Dim cantidad As Decimal = Decimal.Parse(Me.txtCantidad.Text.ToString())

               For Each vp As Entidades.VentaProducto In Me._ventasProductos
                  If vp.Producto.IdRubro = Producto.IdRubro Then
                     cantidad += vp.Cantidad
                  End If
               Next

               Me._DescuentosRecargosProd = New Reglas.Ventas().DescuentoRecargoSoloCantidadAgrupadaRubro(_clienteE, Producto, cantidad, Me._decimalesAMostrar)

               For Each vp As Entidades.VentaProducto In Me._ventasProductos
                  If vp.Producto.IdRubro = Producto.IdRubro Then
                     vp.DescuentoRecargoPorc1 = _DescuentosRecargosProd.DescuentoRecargo1
                     If calculaDescuentoRecargo2 Then
                        vp.DescuentoRecargoPorc2 = _DescuentosRecargosProd.DescuentoRecargo2
                     End If
                  End If
                  vp.DescuentoRecargo = CalculaDescuentosProductos(vp.Precio, vp.ImporteImpuestoInterno / vp.Cantidad,
                                                                   vp.DescuentoRecargoPorc1, vp.DescuentoRecargoPorc2, vp.Cantidad)
               Next

               'RecalcularTodo()

            Else
               Me._DescuentosRecargosProd = CalculosDescuentosRecargos1.DescuentoRecargo(_clienteE, Producto, Decimal.Parse(Me.txtCantidad.Text.ToString()), Me._decimalesAMostrar)
            End If

            Me.txtDescRecPorc1.Text = Me._DescuentosRecargosProd.DescuentoRecargo1.ToString("N" + _decimalesEnDescRec.ToString())
            If calculaDescuentoRecargo2 Then
               Me.txtDescRecPorc2.Text = Me._DescuentosRecargosProd.DescuentoRecargo2.ToString("N" + _decimalesEnDescRec.ToString())
            End If

            '# Si el producto tiene una bonificación x Lista de Precios x cantidad, se cambia la lista de precios y se modifica el precio
            If Producto.TipoBonificacion = Entidades.Producto.TiposBonificacionesProductos.LISTAPRECIO AndAlso
               Not Reglas.Publicos.Facturacion.FacturacionDescuentosAgrupaCantidadesPorRubro Then
               BonificacionListaDePrecioXCantidad(Producto, txtCantidad.ValorNumericoPorDefecto(0D))
            End If
         End If

         Me.CalcularTotalProducto()
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
      End Try
   End Sub

   Private Function ValidaCantidadDigitosCantidad() As Boolean
      Dim cantidadEntera = Convert.ToInt32(Math.Truncate(txtCantidad.ValorNumericoPorDefecto(0D)))
      If cantidadEntera >= 10 ^ Reglas.Publicos.Facturacion.FacturacionCantidadEnterosEnCantidad Then
         ShowMessage(String.Format("La cantidad NO puede tener mas de {0} digitos enteros.", Reglas.Publicos.Facturacion.FacturacionCantidadEnterosEnCantidad))
         txtCantidad.Focus()
         Return False
      End If
      Return True
   End Function

   Private Sub txtCantidad_KeyDown(sender As Object, e As KeyEventArgs) Handles txtCantidad.KeyDown
      If e.KeyCode = Keys.Enter Then
         If Not ValidaCantidadDigitosCantidad() Then
            Exit Sub
         End If

         If String.IsNullOrWhiteSpace(bscCodigoProducto2.Text) Then
            bscCodigoProducto2.Focus()
         Else

            If txtPrecio.ReadOnly Then
               btnInsertar.Focus()
               'txtCantidad_LostFocus(sender, Nothing)

               btnInsertar.PerformClick()
            Else
               txtPrecio.Focus()
            End If
         End If
      End If
   End Sub

   Private Sub cmbPorcentajeIva_KeyDown(sender As Object, e As KeyEventArgs) Handles cmbPorcentajeIva.KeyDown
      If e.KeyCode = Keys.Enter Then
         Me.PresionarTab(e)
      End If
   End Sub

   Private Sub cmbPorcentajeIva_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbPorcentajeIva.SelectedIndexChanged
      Try
         If Me.cmbCategoriaFiscal.SelectedItem IsNot Nothing And Me.cmbPorcentajeIva.Tag IsNot Nothing Then
            If (Not Me._clienteE.CategoriaFiscal.IvaDiscriminado Or Not Me._categoriaFiscalEmpresa.IvaDiscriminado) And
               Me._clienteE.CategoriaFiscal.UtilizaImpuestos And Me._categoriaFiscalEmpresa.UtilizaImpuestos Then
               Dim actualPrecio As Decimal = Decimal.Parse(Me.txtPrecio.Tag.ToString())
               'Dim impuestoInterno As Decimal = Decimal.Parse(Me.txtImpuestosInternos.Text)
               'actualPrecio = Decimal.Round((actualPrecio - impuestoInterno) / (1 + (Decimal.Parse(Me.cmbPorcentajeIva.Tag.ToString()) / 100)), Me._valorRedondeo)
               'actualPrecio = Decimal.Round((actualPrecio * (1 + (Decimal.Parse(Me.cmbPorcentajeIva.Text) / 100))) + impuestoInterno, Me._valorRedondeo)

               Dim iidb As FacturacionV2.ImpIntDesdeBusquedas = FacturacionV2.GetImpIntDesdeBusquedas(bscCodigoProducto2, bscProducto2)

               actualPrecio = Reglas.CalculosImpositivos.ObtenerPrecioSinImpuestos(actualPrecio, Decimal.Parse(Me.cmbPorcentajeIva.Tag.ToString()),
                                                                                   iidb.PorcImpuestoInterno, iidb.ImporteImpuestoInterno, iidb.OrigenPorcImpInt)
               actualPrecio = Reglas.CalculosImpositivos.ObtenerPrecioConImpuestos(actualPrecio, Decimal.Parse(Me.cmbPorcentajeIva.Text.ToString()),
                                                                                   iidb.PorcImpuestoInterno, iidb.ImporteImpuestoInterno, iidb.OrigenPorcImpInt)

               Me.txtPrecio.Text = actualPrecio.ToString(_ceroDecimalesAMostrar)
               Me.txtPrecio.Tag = actualPrecio.ToString(_ceroDecimalesAMostrar)
               Me.cmbPorcentajeIva.Tag = Me.cmbPorcentajeIva.Text
            End If
         End If

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
      End Try
   End Sub

   Private Sub cmbTiposComprobantes_KeyDown(sender As Object, e As KeyEventArgs) Handles cmbTiposComprobantes.KeyDown
      If e.KeyCode = Keys.Enter And Reglas.Publicos.Facturacion.FacturacionSolicitaComprobante Then
         Me.bscCodigoProducto2.Focus()
      Else
         Me.PresionarTab(e)
      End If
   End Sub

   Private Sub cmbTiposComprobantes_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbTiposComprobantes.SelectedIndexChanged

      If Me._estaCargando Then Exit Sub

      Try

         'cada vez que selecciono un comprobante, pongo la fecha de hoy en el comprobante y si es fiscal no lo permito modificar
         If Me.cmbTiposComprobantes.SelectedIndex = -1 Then
            Exit Sub
         End If

         '# Valido si el cliente no posee comprobantes vencidos por la cantidad de días permitidos 
         'Me.ValidarDiasDeVencimiento()

         lblTipoComprobanteAbreviadoOculto.Visible = Not _muestraTipoComprobante
         If lblTipoComprobanteAbreviadoOculto.Visible Then
            lblTipoComprobanteAbreviadoOculto.Text = DirectCast(Me.cmbTiposComprobantes.SelectedItem, Entidades.TipoComprobante).DescripcionAbrev
         End If

         If Me.cmbTiposComprobantes.Items.Count > 0 And Me.cmbTiposComprobantes.SelectedItem IsNot Nothing Then

            If Publicos.IdNotaDebitoChequeRechazado(DirectCast(Me.cmbTiposComprobantes.SelectedItem, Entidades.TipoComprobante).IdTipoComprobante) Or
               DirectCast(Me.cmbTiposComprobantes.SelectedItem, Entidades.TipoComprobante).EsRemitoTransportista Then
               MessageBox.Show("ATENCION: este comprobante no es posible emitirlo con la Pantalla Rapida", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
               Me.cmbTiposComprobantes.SelectedIndex = 0 'Esperemos el primero justo no sea un invalido, con -1 da error
               Exit Sub
            End If

            ''Por ahora no puede cambiar la fecha
            'Me.dtpFecha.Enabled = Not DirectCast(Me.cmbTiposComprobantes.SelectedItem, Entidades.TipoComprobante).EsFiscal
            'If Not Me.dtpFecha.Enabled Then
            Me.dtpFecha.Value = New Reglas.Generales().GetServerDBFechaHora   ' Date.Now
            'End If
            ''-----------------------------------

            '# Solo si el tilde de modificar manualmente el Desc/Rec no está tildado
            If Me.bscCodigoCliente.Selecciono Or Me.bscCliente.Selecciono Then
               If Not Me.chbModificaDescRecGralPorc.Checked Then
                  _cantLineas = _ventasProductos.Count
                  Me._DescRecGralPorc = CalculosDescuentosRecargos1.DescuentoRecargo(_clienteE,
                                                                             cmbTiposComprobantes.ItemSeleccionado(Of Entidades.TipoComprobante),
                                                                             cmbFormaPago.ItemSeleccionado(Of Entidades.VentaFormaPago),
                                                                             _cantLineas)
                  Me.txtDescRecGralPorc2.Text = _DescRecGralPorc.ToString("N" + _decimalesEnDescRec.ToString())
                  Me.txtDescRecGralPorc2.Text = _DescRecGralPorc.ToString("N" + _decimalesEnDescRec.ToString())
               End If
            End If


            ''Si es Ticket Factura Valido que tenga el CUIT para que no reviente despues.
            ''Habria que hacerlo mas general!
            'If DirectCast(Me.cmbTiposComprobantes.SelectedItem, Entidades.TipoComprobante).IdTipoComprobante = Publicos.IdTicketFacturaFiscal AndAlso Me._clienteE IsNot Nothing AndAlso String.IsNullOrEmpty(Me._clienteE.Cuit) Then
            '   MessageBox.Show("El Comprobante requiere obligatorio el CUIT pero el Cliente NO lo tiene.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
            '   'Me.Nuevo()
            '   'Exit Sub
            'End If

            'NO permito cambiar la Categoria Fiscal si es en Blanco. @@@@
            Me.cmbCategoriaFiscal.Enabled = True
            If Me._clienteE IsNot Nothing Then
               If DirectCast(Me.cmbTiposComprobantes.SelectedItem, Entidades.TipoComprobante).GrabaLibro Then

                  'Vuelvo a asignarlo para saber si lo cambio.
                  Me._clienteE = New Reglas.Clientes().GetUno(Long.Parse(Me.bscCodigoCliente.Tag.ToString()))

                  If Not Me._clienteE.EsClienteGenerico Then
                     Me.cmbCategoriaFiscal.Enabled = False
                     'Si cambio la categoria... le vuelvo la original
                     If DirectCast(Me.cmbCategoriaFiscal.SelectedItem, Entidades.CategoriaFiscal).IdCategoriaFiscal <> Me._IdCategoriaFiscalOriginal Then
                        Me.cmbCategoriaFiscal.SelectedValue = Me._IdCategoriaFiscalOriginal
                        'Exit Sub
                     End If
                  End If

               Else

                  'Solo para los comprobantes en negro (los Pre-Eelctronicos son en blanco)
                  If Publicos.FacturacionGrabaLibroNoFuerzaConsFinal And Not DirectCast(Me.cmbTiposComprobantes.SelectedItem, Entidades.TipoComprobante).EsPreElectronico Then
                     Me.cmbCategoriaFiscal.SelectedValue = Short.Parse("1")      'No deberia ser Fijo 1.
                  Else
                     'Pudo cambiarla.
                     Me.cmbCategoriaFiscal.SelectedValue = Me._IdCategoriaFiscalOriginal
                  End If

               End If
            End If
            '-----------------------------------------------------------

            FacturacionAyudantes.SetLetraParaComprobante(txtLetra, cmbTiposComprobantes, cmbCategoriaFiscal)
            ''Si es X es remito, siempre debe tener esa letra, sino dejo la que esta.
            'If DirectCast(Me.cmbTiposComprobantes.SelectedItem, Entidades.TipoComprobante).LetrasHabilitadas.Length = 1 Then
            '   Me.txtLetra.Text = DirectCast(Me.cmbTiposComprobantes.SelectedItem, Entidades.TipoComprobante).LetrasHabilitadas
            'Else
            '   If Me.cmbCategoriaFiscal.SelectedIndex >= 0 Then
            '      Me.txtLetra.Text = DirectCast(Me.cmbCategoriaFiscal.SelectedItem, Entidades.CategoriaFiscal).LetraFiscal
            '   Else
            '      Me.txtLetra.Text = ""
            '   End If
            'End If

            If Me.cmbFormaPago.SelectedIndex >= 0 Then
               If DirectCast(Me.cmbTiposComprobantes.SelectedItem, Entidades.TipoComprobante).AfectaCaja And DirectCast(Me.cmbFormaPago.SelectedItem, Entidades.VentaFormaPago).Dias = 0 Then
                  If Not Me.tbcDetalle.TabPages.Contains(Me.tbpPagos) Then
                     Me.tbcDetalle.TabPages.Add(Me.tbpPagos)
                  End If
               Else
                  'DP: Permitir CtaCte
                  'If Me.tbcDetalle.TabPages.Contains(Me.tbpPagos) Then
                  '   Me._cheques.Clear()
                  '   Me.dgvCheques.DataSource = Me._cheques
                  '   Me.tbcDetalle.TabPages.Remove(Me.tbpPagos)
                  'End If
               End If
            End If

            Me.chbNumeroAutomatico.Checked = True
            Me.chbNumeroAutomatico.Enabled = Reglas.Publicos.Facturacion.FacturacionModificaNumeroComprobante And Not DirectCast(Me.cmbTiposComprobantes.SelectedItem, Entidades.TipoComprobante).EsFiscal

            ''NO permito cambiar la Categoria Fiscal si es en Blanco. @@@@
            'Me.cmbCategoriaFiscal.Enabled = True
            'If Me._clienteE IsNot Nothing Then
            '   If DirectCast(Me.cmbTiposComprobantes.SelectedItem, Entidades.TipoComprobante).GrabaLibro Then

            '      'Vuelvo a asignarlo para saber si lo cambio.
            '      Me._clienteE = New Reglas.Clientes().GetUno(Me.cmbTipoDoc.Text, Me.bscCodigoCliente.Text)

            '      Me.cmbCategoriaFiscal.Enabled = False
            '      'Si cambio la categoria... le vuelvo la original
            '      If DirectCast(Me.cmbCategoriaFiscal.SelectedItem, Entidades.CategoriaFiscal).IdCategoriaFiscal <> Me._clienteE.CategoriaFiscal.IdCategoriaFiscal Then
            '         Me.cmbCategoriaFiscal.SelectedValue = Me._clienteE.CategoriaFiscal.IdCategoriaFiscal
            '         Exit Sub
            '      End If

            '   Else

            '      If Publicos.FacturacionGrabaLibroNoFuerzaConsFinal Then
            '         Me.cmbCategoriaFiscal.SelectedValue = Short.Parse("1")      'No deberia ser Fijo 1.
            '      End If

            '   End If
            'End If
            ''-----------------------------------------------------------

         End If

         Me.tbcDetalle.SelectedTab = Me.tbpProductos

         Me.CambiarEstadoControlesDetalle(Me._clienteE IsNot Nothing)

         'Si algun producto es con Lote tengo que limpiar el detalle, porque pudo cambiar de Factura a NCRED o viseversa, y lleva controles
         ' o que afecta stock si a no.
         If Me.ProductosConLote() > 0 Then
            Me.LimpiarDetalle()
         End If

         Me.CargarProximoNumero()

         If Me.cmbTiposComprobantes.SelectedValue IsNot Nothing Then

            ''Si es Ticket Factura Valido que tenga el CUIT para que no reviente despues.
            ''Habria que hacerlo mas general!
            'If (Me.txtLetra.Text = "A" Or Me.txtLetra.Text = "C") AndAlso Me.txtNumeroPosible.Tag.ToString() = "HASAR" AndAlso DirectCast(Me.cmbTiposComprobantes.SelectedItem, Entidades.TipoComprobante).IdTipoComprobante = Publicos.IdTicketFacturaFiscal AndAlso Me._clienteE IsNot Nothing AndAlso String.IsNullOrEmpty(Me._clienteE.Cuit) Then
            '   MessageBox.Show("El Comprobante requiere obligatorio el CUIT pero el Cliente NO lo tiene.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
            '   'Me.Nuevo()
            '   'Exit Sub
            'End If

            Dim tpComp As Entidades.TipoComprobante = DirectCast(cmbTiposComprobantes.SelectedItem, Entidades.TipoComprobante)
            'If _tipoComprobanteActual IsNot Nothing AndAlso
            '   ((_tipoComprobanteActual.GrabaLibro Or _tipoComprobanteActual.EsPreElectronico) <> (tpComp.GrabaLibro Or tpComp.EsPreElectronico) Or
            '    _tipoComprobanteActual.UtilizaImpuestos <> tpComp.UtilizaImpuestos) Then
            For Each vp As Entidades.VentaProducto In _ventasProductos

               Me.SeteaIVASegunComprobante(vp, tpComp, setearPrecio:=False)

            Next
            Me.RecalcularTodo(FacturacionV2.MetodoLlamador.CambioTipoDeComprobante, False)

         End If
         Me.ChequeaCajas()

         CargaTipoComprobanteProducto()

         Me.CalcularDatosDetalle()
      Catch ex As Exception
         ShowError(ex)
         Try
            Nuevo(False, False)
         Catch ex1 As Exception
            ShowError(ex1)
         End Try
      End Try
   End Sub
   Private _cargandoProductosAutomaticamente As Boolean = False
   Private Sub CargaTipoComprobanteProducto()
      If validaCliente() Then
         For Each rwVentaProduct As Entidades.VentaProducto In _ventasProductos.Where(Function(x) x.Automatico).ToArray()
            EliminarLineaProducto(rwVentaProduct)
         Next

         Dim _tiposComprobantes As List(Of Entidades.TipoComprobanteProducto)
         _tiposComprobantes = New Reglas.TiposComprobantesProductos().GetTodos(Me.cmbTiposComprobantes.SelectedValue.ToString())

         For Each Row As Entidades.TipoComprobanteProducto In _tiposComprobantes
            _cargandoProductosAutomaticamente = True
            bscCodigoProducto2.Text = Row.IdProducto
            bscCodigoProducto2.PresionarBoton()
            If _facturacionRapidaSolicitaCantidad Then
               txtCantidad.Text = Row.Cantidad.ToString(_formatoEnCantidad)
               txtPrecio.Focus()
               btnInsertar.PerformClick()
            End If
         Next
         _cargandoProductosAutomaticamente = False

      End If
   End Sub
   Private Function validaCliente() As Boolean
      If Not Me.bscCodigoCliente.Selecciono And Not Me.bscCliente.Selecciono And (Me.bscCodigoCliente.Text.Trim.Length = 0 Or Me.bscCliente.Text.Trim.Length = 0) Then
         Return False
      End If

      If bscCodigoCliente.FilaDevuelta Is Nothing And bscCliente.FilaDevuelta Is Nothing Then
         Return False
      End If
      Return True
   End Function
   Private Sub btnLimpiarProducto_Click(sender As Object, e As EventArgs) Handles btnLimpiarProducto.Click
      Me.LimpiarCamposProductos()
      Me.bscCodigoProducto2.Focus()
   End Sub

   'Si tiene Precio entra en un bucle y se termina duplicando el producto.
   'Private Sub dgvProductos_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvProductos.CellDoubleClick
   '   Try
   '      'limpia los textbox, y demas controles
   '      Me.LimpiarCamposProductos()
   '      'carga el producto seleccionado de la grilla en los textbox 
   '      Me.CargarProductoCompleto(Me.dgvProductos.Rows(e.RowIndex))
   '      'elimina el producto de la grilla
   '      Me.EliminarLineaProducto()

   '      If Me._ModificaDetalle = "SOLOPRECIOS" Then
   '         Me.txtPrecio.Enabled = True

   '         Me.tsbGrabar.Enabled = False    'Deshabilito hasta que confirme la grabacion
   '         Me.btnInsertar.Enabled = True
   '         Me.txtPrecio.Focus()
   '      Else
   '         Me.txtCantidad.Focus()
   '         Me.txtCantidad.SelectAll()
   '      End If

   '   Catch ex As Exception
   '      MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
   '   End Try
   'End Sub

   Private Sub dgvObservaciones_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvObservaciones.CellDoubleClick

      Try

         'limpia los textbox, y demas controles
         Me.LimpiarCamposObservDetalles()

         'carga la observacion seleccionada de la grilla en los textbox 
         Me.CargarObservDetalleCompleto(Me.dgvObservaciones.Rows(e.RowIndex))

         'elimina el producto de la grilla
         Me.EliminarLineaObservacion()

         'Tengo que renumerar por la forma que asigno el numero de linea.
         Me.RenumerarObservacionesDetalle()

         Me.txtObservacionDetalle.Focus()
         Me.txtObservacionDetalle.SelectAll()

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
      End Try

   End Sub

   Private Sub btnInsertarCheque_Click(sender As Object, e As EventArgs) Handles btnInsertarCheque.Click
      Try
         If Me.ValidarInsertarCheques() Then
            Me.InsertarChequesGrilla()
            Me.bscBancos.Focus()
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
      End Try
   End Sub

   Private Sub btnEliminarCheque_Click(sender As Object, e As EventArgs) Handles btnEliminarCheque.Click
      Try
         If Me.dgvCheques.SelectedRows.Count > 0 Then
            If MessageBox.Show("Esta seguro de eliminar el cheque seleccionado?", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
               Me.EliminarLineaCheques()
            End If
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
      End Try
   End Sub
   Private Sub dgvCheques_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvCheques.CellDoubleClick
      Try
         Me.LimpiarCamposCheques()
         'carga el producto seleccionado de la grilla en los textbox 
         Me.CargarChequeCompleto(Me.dgvCheques.Rows(e.RowIndex))
         'elimina el producto de la grilla
         Me.EliminarLineaCheques()
      Catch ex As Exception
         MessageBox.Show(ex.Message, Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub
   Private Sub CargarChequeCompleto(dr As DataGridViewRow)

      If dr IsNot Nothing AndAlso
         dr.DataBoundItem IsNot Nothing AndAlso
         TypeOf (dr.DataBoundItem) Is Entidades.Cheque Then

         Dim oCheque As Entidades.Cheque = DirectCast(dr.DataBoundItem, Entidades.Cheque)

         With oCheque
            If .Banco IsNot Nothing AndAlso .Banco.IdBanco > 0 Then
               bscBancos.Text = .Banco.NombreBanco
               bscBancos.PresionarBoton()
            End If
            Me.txtCuitChequeTercero.Text = .Cuit
            Me.txtSucursalBanco.Text = .IdBancoSucursal.ToString()
            Me.txtCodPostalCheque.Text = .Localidad.IdLocalidad.ToString()
            Me.dtpFechaEmision.Value = .FechaEmision
            Me.dtpFechaCobro.Value = .FechaCobro
            Me.txtTitularCheque.Text = .Titular
            Me.txtNroCheque.Text = .NumeroCheque.ToString()
            Me.txtImporteCheque.Text = .Importe.ToString("N2")
            Me.cmbTipoCheque.SelectedValue = .IdTipoCheque.ToString()
            Me.txtNroOperacion.Text = .NroOperacion.ToString()
         End With

      End If

   End Sub
   Private Sub cmbFormaPago_KeyDown(sender As Object, e As KeyEventArgs) Handles cmbFormaPago.KeyDown
      Me.PresionarTab(e)
   End Sub

   Private _formaPagoAnterio As Entidades.VentaFormaPago
   Private Sub cmbFormaPago_Enter(sender As Object, e As EventArgs) Handles cmbFormaPago.Enter
      TryCatched(Sub() _formaPagoAnterio = cmbFormaPago.ItemSeleccionado(Of Entidades.VentaFormaPago))
   End Sub

   Private Sub SeteaComprobanteSegunFormaDePago()
      '-- REQ-33325.- -----------------------------------------------------------------------------------------------------
      If DirectCast(cmbFormaPago.SelectedItem, Entidades.VentaFormaPago).IdTipoComprobantesFR IsNot Nothing Then
         '-- REG-33409 - Busca el Tipo de Comprobante dentro del Combo.- --
         For Each cTipoCompr In DirectCast(cmbTiposComprobantes.DataSource, List(Of Entidades.TipoComprobante))
            If cTipoCompr.IdTipoComprobante = DirectCast(cmbFormaPago.SelectedItem, Entidades.VentaFormaPago).IdTipoComprobantesFR Then
               cmbTiposComprobantes.SelectedValue = DirectCast(cmbFormaPago.SelectedItem, Entidades.VentaFormaPago).IdTipoComprobantesFR
            End If
         Next
      End If
      '--------------------------------------------------------------------------------------------------------------------
   End Sub

   Private Sub cmbFormaPago_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbFormaPago.SelectedIndexChanged

      If Me._estaCargando Then Exit Sub

      Try
         If Me.cmbTiposComprobantes.SelectedItem Is Nothing Then
            MessageBox.Show("Falta asignar el tipo de comprobante para una PC en impresoras.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
         End If

         If Me.cmbFormaPago.SelectedIndex <> -1 Then
            '-- REQ-33325.- -----------------------------------------------------------------------------------------------------
            SeteaComprobanteSegunFormaDePago()
            '--------------------------------------------------------------------------------------------------------------------
            If DirectCast(Me.cmbFormaPago.SelectedItem, Eniac.Entidades.VentaFormaPago).Dias = 0 And
               DirectCast(Me.cmbTiposComprobantes.SelectedItem, Entidades.TipoComprobante).AfectaCaja Then
               If Not Me.tbcDetalle.TabPages.Contains(Me.tbpPagos) Then
                  Me.tbcDetalle.TabPages.Add(Me.tbpPagos)
               End If
            Else
               'DP: Permitir CtaCte
               'If Me.tbcDetalle.TabPages.Contains(Me.tbpPagos) Then
               '   Me._cheques.Clear()
               '   Me.dgvCheques.DataSource = Me._cheques
               '   Me.tbcDetalle.TabPages.Remove(Me.tbpPagos)
               'End If
            End If

            Me.ChequeaCajas()

            '# Solo si el tilde de modificar manualmente el Desc/Rec no está tildado
            If Not Me.chbModificaDescRecGralPorc.Checked Then
               _cantLineas = _ventasProductos.Count
               txtDescRecGralPorc2.Text = CalculosDescuentosRecargos1.DescuentoRecargo(_clienteE,
                                                                               cmbTiposComprobantes.ItemSeleccionado(Of Entidades.TipoComprobante),
                                                                               cmbFormaPago.ItemSeleccionado(Of Entidades.VentaFormaPago),
                                                                               _cantLineas).ToString("N" + _decimalesAMostrar.ToString())
            End If
            Me.CalcularDatosDetalle()
            '-- REQ-33090.- ---------------------------------------------------------------------------------------
            If DirectCast(Me.cmbFormaPago.SelectedItem, Entidades.VentaFormaPago).IdListaPrecios IsNot Nothing Then
               '-- Guarda Lista de Precios Anterior.- --
               '--REQ-33274.- 
               cmbListaDePrecios.Tag = cmbListaDePrecios.SelectedValue
               If _formaPagoAnterio IsNot Nothing AndAlso _formaPagoAnterio.IdListaPrecios.IfNull(-1) <> cmbFormaPago.ItemSeleccionado(Of Entidades.VentaFormaPago).IdListaPrecios.IfNull(-1) Then
                  '-- Carga Nueva Lista de Precios.- ------
                  cmbListaDePrecios.SelectedValue = DirectCast(Me.cmbFormaPago.SelectedItem, Entidades.VentaFormaPago).IdListaPrecios
                  '-- Desactiva Combo de lista de Precios.- 
                  cmbListaDePrecios.Enabled = False
                  '-- Recalcula valores anterirores.- --
                  Me.RecalcularTodo(FacturacionV2.MetodoLlamador.CambioListaDePrecibos, False)
               End If
            Else
               If _formaPagoAnterio IsNot Nothing AndAlso _formaPagoAnterio.IdListaPrecios.IfNull(-1) <> cmbFormaPago.ItemSeleccionado(Of Entidades.VentaFormaPago).IdListaPrecios.IfNull(-1) Then
                  '-- Guarda Lista de Precios Anterior.- --
                  '--REQ-33274.- 
                  cmbListaDePrecios.SelectedValue = CInt(cmbListaDePrecios.Tag)
                  '-- Desactiva Combo de lista de Precios.- 
                  cmbListaDePrecios.Enabled = True
                  '-- Recalcula valores anterirores.- --
                  Me.RecalcularTodo(FacturacionV2.MetodoLlamador.CambioListaDePrecibos, True)
               End If
            End If
            '------------------------------------------------------------------------------------------------------
            RecalcularTodo(FacturacionV2.MetodoLlamador.CambioFormaDePago, True)

         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
      End Try

   End Sub

   Private Sub tbcDetalle_SelectedIndexChanged(sender As Object, e As EventArgs) Handles tbcDetalle.SelectedIndexChanged
      Try
         If Me.tbcDetalle.Contains(Me.tbpProductos) Then
            If Me.tbcDetalle.SelectedTab Is Me.tbpProductos Then
               Me.bscCodigoProducto2.Focus()
            End If
         End If

         If Me.tbcDetalle.Contains(Me.tbpPagos) Then
            If Me.tbcDetalle.SelectedTab Is Me.tbpPagos Then
               SetPagosSegunFormaPago()
               'txtEfectivo.Focus()
            End If
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
      End Try
   End Sub

   Private Sub cmbListaDePrecios_KeyDown(sender As Object, e As KeyEventArgs) Handles cmbListaDePrecios.KeyDown
      Me.PresionarTab(e)
   End Sub

   Private Sub cmbListaDePrecios_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbListaDePrecios.SelectedIndexChanged

      If Me._estaCargando Then Exit Sub

      Try
         '# Solo si el tilde de modificar manualmente el Desc/Rec no está tildado
         If Not Me.chbModificaDescRecGralPorc.Checked Then
            _cantLineas = _ventasProductos.Count
            txtDescRecGralPorc2.Text = CalculosDescuentosRecargos1.DescuentoRecargo(_clienteE,
                                                                            cmbTiposComprobantes.ItemSeleccionado(Of Entidades.TipoComprobante),
                                                                            cmbFormaPago.ItemSeleccionado(Of Entidades.VentaFormaPago),
                                                                            _cantLineas).ToString("N" + _decimalesAMostrar.ToString())
         End If
         '-- REQ-33090.- Verifico si cambio Variable.- --
         ActualizaPrecios = If(DirectCast(Me.cmbFormaPago.SelectedItem, Entidades.VentaFormaPago).IdListaPrecios IsNot Nothing, True, Reglas.Publicos.ActualizaPreciosDeVenta())
         '------------------------------------
         If ActualizaPrecios Then
            Me.RecalcularTodo(FacturacionV2.MetodoLlamador.CambioListaDePrecibos, False)
         Else
            SetearPrecio()
         End If
         '-- REQ-33090.- Restablezco cambio Variable.- --
         ActualizaPrecios = Reglas.Publicos.ActualizaPreciosDeVenta()
         '------------------------------------
      Catch ex As Exception
         ShowError(ex)
      End Try

   End Sub

   Private Sub SetearPrecio()
      If _clienteE Is Nothing Then Return
      If cmbListaDePrecios.ItemSeleccionado(Of Entidades.ListaDePrecios) Is Nothing Then Return
      'Dim dr = bscCodigoProducto2.FilaDevuelta
      Dim idProducto = bscCodigoProducto2.Text.Trim()
      Dim oProductos = New Reglas.Productos()
      Dim dt = oProductos.GetPorCodigo(idProducto, actual.Sucursal.Id,
                                       cmbListaDePrecios.ItemSeleccionado(Of Entidades.ListaDePrecios).IdListaPrecios,
                                       "VENTAS", , , , , , , , , _clienteE.IdCliente, soloBuscaPorIdProducto:=_editarProductoDesdeGrilla)
      If dt.Count > 0 Then
         Dim dr = dt(0)

         Dim producto = New Reglas.Productos().GetUno(idProducto, accion:=Reglas.Base.AccionesSiNoExisteRegistro.Nulo)
         If producto IsNot Nothing Then
            Dim p = FacturacionAyudantes.GetPrecio(dr.Field(Of Decimal)("PrecioVentaSinIVA"), dr.Field(Of Decimal)("PrecioVentaConIVA"),
                                                   producto, _clienteE, dtpFecha.Value, _nroOferta, _categoriaFiscalEmpresa, _codigoBarrasCompleto,
                                                   txtCotizacionDolar.ValorNumericoPorDefecto(0D), _modalidad, _valorRedondeo, _FormaDePago)

            txtPrecio.Text = p.ToString(_formatoDecimalesAMostrar)
            txtPrecio.Tag = txtPrecio.Text
         End If
      End If

   End Sub

   Private Sub cmbCategoriaFiscal_KeyDown(sender As Object, e As KeyEventArgs) Handles cmbCategoriaFiscal.KeyDown
      PresionarTab(e)
   End Sub

   Private _ultimaCategoriaFiscalSeleccionada As Entidades.CategoriaFiscal

   Private Sub cmbCategoriaFiscal_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbCategoriaFiscal.SelectedIndexChanged

      If Me._estaCargando Then Exit Sub

      Try
         FacturacionAyudantes.SetLetraParaComprobante(txtLetra, cmbTiposComprobantes, cmbCategoriaFiscal)
         ''Si es X es remito y siempre debe tener esa letra
         'If (Me.txtLetra.Text = "A" Or Me.txtLetra.Text = "B" Or Me.txtLetra.Text = "C" Or Me.txtLetra.Text = "E") And Me.cmbCategoriaFiscal.SelectedIndex >= 0 Then
         '   Me.txtLetra.Text = DirectCast(Me.cmbCategoriaFiscal.SelectedItem, Entidades.CategoriaFiscal).LetraFiscal
         'End If

         If Me._clienteE IsNot Nothing And Me.cmbCategoriaFiscal.SelectedItem IsNot Nothing Then

            Me._clienteE.CategoriaFiscal = New Reglas.CategoriasFiscales().GetUno(Short.Parse(Me.cmbCategoriaFiscal.SelectedValue.ToString()))

            'Exento sin IVA. 
            If Not Me._clienteE.CategoriaFiscal.UtilizaImpuestos Or Not Me._categoriaFiscalEmpresa.UtilizaImpuestos Then
               Me.cmbPorcentajeIva.Text = _ceroDecimalesAMostrar
               Me.cmbPorcentajeIva.Tag = Me.cmbPorcentajeIva.Text
               Me.cmbPorcentajeIva.Enabled = False
            Else
               Me.cmbPorcentajeIva.Enabled = True
            End If

            'Si es un comprobante en blanco no deberia cambiar el IVA del producto
            If DirectCast(Me.cmbTiposComprobantes.SelectedItem, Entidades.TipoComprobante).GrabaLibro Or
               DirectCast(Me.cmbTiposComprobantes.SelectedItem, Entidades.TipoComprobante).EsPreElectronico Then
               Me.cmbPorcentajeIva.Enabled = False
            End If

            Me.RecalcularTodo(FacturacionV2.MetodoLlamador.CambioCategoriaFiscal, False)
            Me.LimpiarCamposProductos()

            If _clienteE.EsClienteGenerico Then
               If Me._clienteE.CategoriaFiscal.SolicitaCUIT Then
                  Me.lblCUIT.Text = My.Resources.RTextos.Cuit
                  Me.cmbTipoDoc.Visible = False
                  Me.txtNroDocCliente.Visible = False
                  Me.lblTipoDocumento.Visible = False
                  Me.txtCUIT.Visible = True
                  Me.txtCUIT.ReadOnly = False
               Else
                  Me.cmbTipoDoc.Visible = True
                  Me.txtNroDocCliente.Visible = True
                  Me.cmbTipoDoc.Enabled = True
                  Me.txtNroDocCliente.ReadOnly = False
                  Me.lblTipoDocumento.Visible = True
                  Me.txtCUIT.Visible = False
                  Me.lblCUIT.Text = "Nro Documento"
               End If

            Else
               If Me._clienteE.CategoriaFiscal.SolicitaCUIT Then
                  Me.lblCUIT.Text = My.Resources.RTextos.Cuit
                  Me.cmbTipoDoc.Visible = False
                  Me.txtNroDocCliente.Visible = False
                  Me.lblTipoDocumento.Visible = False
                  Me.txtCUIT.Visible = True
                  Me.txtCUIT.ReadOnly = True
               Else
                  Me.cmbTipoDoc.Visible = True
                  Me.txtNroDocCliente.Visible = True
                  Me.cmbTipoDoc.Enabled = False
                  Me.txtNroDocCliente.ReadOnly = True
                  Me.lblTipoDocumento.Visible = True
                  Me.txtCUIT.Visible = False
                  Me.lblCUIT.Text = "Nro Documento"
               End If
            End If
            _ultimaCategoriaFiscalSeleccionada = _clienteE.CategoriaFiscal
         Else
            _ultimaCategoriaFiscalSeleccionada = Nothing
         End If
      Catch ex As Exception
         ShowError(ex)
      End Try

   End Sub

   Private Sub cmbVendedor_KeyDown(sender As Object, e As KeyEventArgs) Handles cmbVendedor.KeyDown

      If e.KeyCode = Keys.Enter And Reglas.Publicos.Facturacion.FacturacionSolicitaVendedor Then
         If Reglas.Publicos.Facturacion.FacturacionSolicitaComprobante Then
            Me.cmbTiposComprobantes.Focus()
         Else
            Me.bscCodigoProducto2.Focus()
         End If
      Else
         Me.PresionarTab(e)
      End If

   End Sub

   Private Sub chbNumeroAutomatico_CheckedChanged(sender As Object, e As EventArgs) Handles chbNumeroAutomatico.CheckedChanged
      Me.txtNumeroPosible.ReadOnly = chbNumeroAutomatico.Checked
   End Sub

   Private Sub btnInsertarObservacion_Click(sender As Object, e As EventArgs) Handles btnInsertarObservacion.Click
      Try
         If Me.txtObservacionDetalle.Text <> "" Then
            If Me.ValidarInsertaObservacion() Then
               Me.InsertarObservacion()
               Me.txtObservacionDetalle.Focus()
            End If
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
      End Try

   End Sub

   Private Sub btnEliminarObservacion_Click(sender As Object, e As EventArgs) Handles btnEliminarObservacion.Click
      Try
         If Me.dgvObservaciones.SelectedRows.Count > 0 Then
            If MessageBox.Show("Esta seguro de eliminar la Observación?", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
               Me.EliminarLineaObservacion()
            End If
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
      End Try
   End Sub

   Private Sub txtPercepcionIVA_Leave(sender As Object, e As EventArgs) Handles txtPercepcionIVA.Leave
      Try
         Me.CalcularTotales()
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
      End Try
   End Sub

   Private Sub txtPercepcionIVA_KeyDown(sender As Object, e As KeyEventArgs) Handles txtPercepcionIVA.KeyDown
      If e.KeyCode = Keys.Enter Then
         Me.txtPercepcionIIBB.Focus()
      End If
   End Sub

   Private Sub txtPercepcionIIBB_KeyDown(sender As Object, e As KeyEventArgs) Handles txtPercepcionIIBB.KeyDown
      If e.KeyCode = Keys.Enter Then
         Me.txtPercepcionGanancias.Focus()
      End If
   End Sub

   Private Sub txtPercepcionIIBB_Leave(sender As Object, e As EventArgs) Handles txtPercepcionIIBB.Leave
      Try
         Me.CalcularTotales()
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
      End Try
   End Sub

   Private Sub txtPercepcionGanancias_Leave(sender As Object, e As EventArgs) Handles txtPercepcionGanancias.Leave
      Try
         Me.CalcularTotales()
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
      End Try
   End Sub

   Private Sub txtPercepcionGanancias_KeyDown(sender As Object, e As KeyEventArgs) Handles txtPercepcionGanancias.KeyDown
      If e.KeyCode = Keys.Enter Then
         Me.txtPercepcionVarias.Focus()
      End If
   End Sub

   Private Sub txtPercepcionVarias_Leave(sender As Object, e As EventArgs) Handles txtPercepcionVarias.Leave
      Try
         Me.CalcularTotales()
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
      End Try
   End Sub

   Private Sub txtPercepcionVarias_KeyDown(sender As Object, e As KeyEventArgs) Handles txtPercepcionVarias.KeyDown
      If e.KeyCode = Keys.Enter Then
         Me.txtTotalPercepcion.Focus()
      End If
   End Sub

   Private Sub dgvProductos_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvProductos.CellClick
      Try
         If Me.dgvProductos.Rows.Count = 0 Then Exit Sub

         If Me.dgvProductos.SelectedRows.Count = 0 Then Exit Sub

         '# Visualizar Nros. Serie
         Me.MostrarNumerosSerieDesdeGrilla(Me.dgvProductos, e)

         '# Visualizar Lotes
         Me.MostrarNumerosLotesDesdeGrilla(Me.dgvProductos, e)

      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

   'Private Sub dgvProductos_KeyUp(sender As Object, e As KeyEventArgs) Handles dgvProductos.KeyUp
   '   If Me.dgvProductos.SelectedRows.Count > 0 Then
   '      'Control y la tecla "-" de un teclado o nobebook.
   '      If e.Control And (e.KeyCode = Keys.Subtract Or e.KeyCode = Keys.OemMinus) Then
   '         Me.btnEliminar.PerformClick()
   '         Me.dgvProductos.Focus()
   '      End If
   '   End If
   'End Sub

   Private Sub dgvProductos_SelectionChanged(sender As Object, e As EventArgs) Handles dgvProductos.SelectionChanged
      Try
         If Me.dgvProductos.SelectedRows.Count > 0 And Me.dgvProductos.Focused Then
            Me.CargarFoto(Me.dgvProductos.SelectedRows(0).Cells("IdProducto").Value.ToString.Trim(), Decimal.Parse(Me.dgvProductos.SelectedRows(0).Cells("Importe").Value.ToString()))
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
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

   Private Sub cmbTipoCheque_KeyDown(sender As Object, e As KeyEventArgs) Handles cmbTipoCheque.KeyDown
      Me.PresionarTab(e)
   End Sub

   Private Sub txtNroOperacion_KeyDown(sender As Object, e As KeyEventArgs) Handles txtNroOperacion.KeyDown
      Me.PresionarTab(e)
   End Sub

   Private Sub btnInsertarTarjeta_Click(sender As Object, e As EventArgs) Handles btnInsertarTarjeta.Click
      Try
         If Me.ValidarInsertarTarjeta() Then
            Me.InsertarTarjetaGrilla()
            Me.cmbTarTarjeta.Focus()
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
      End Try
   End Sub

   Private Sub btnEliminarTarjeta_Click(sender As Object, e As EventArgs) Handles btnEliminarTarjeta.Click
      Try
         If Me.dgvTarjetas.SelectedRows.Count > 0 Then
            If MessageBox.Show("Esta seguro de eliminar la tarjeta seleccionada?", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
               Me.EliminarLineaTarjetas()
            End If
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
      End Try
   End Sub
   Private Sub dgvTarjetas_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvTarjetas.CellDoubleClick
      Try
         Me.LimpiarCamposTarjetas()
         'carga el producto seleccionado de la grilla en los textbox 
         Me.CargarTarjetaCompleto(Me.dgvTarjetas.Rows(e.RowIndex))
         'elimina el producto de la grilla
         Me.EliminarLineaTarjetas()
      Catch ex As Exception
         MessageBox.Show(ex.Message, Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub
   Private Sub CargarTarjetaCompleto(dr As DataGridViewRow)

      If dr IsNot Nothing AndAlso
         dr.DataBoundItem IsNot Nothing AndAlso
         TypeOf (dr.DataBoundItem) Is Entidades.VentaTarjeta Then
         Dim vt As Entidades.VentaTarjeta = DirectCast(dr.DataBoundItem, Eniac.Entidades.VentaTarjeta)
         cmbTarTarjeta.SelectedValue = vt.Tarjeta.IdTarjeta
         If vt.Banco IsNot Nothing AndAlso vt.Banco.IdBanco > 0 Then
            bscTarBanco.Text = vt.Banco.NombreBanco
            bscTarBanco.PresionarBoton()
         End If

         txtTarMonto.Text = vt.Monto.ToString("N2")
         txtTarCuotas.Text = vt.Cuotas.ToString()
         txtTarNumeroCupon.Text = vt.NumeroCupon.ToString()

      End If

   End Sub
   Private Sub tsbReemplazarComprobantes_Click(sender As Object, e As EventArgs) Handles tsbReemplazarComprobantes.Click
      Try
         'Valido que haya ingresado el cliente. Recien ahi llamo a la ayuda para ahorrar tiempo.
         If Not Me.bscCodigoCliente.Selecciono And Not Me.bscCliente.Selecciono Then
            Exit Sub
         End If

         Dim IdTipoComprobante As String = String.Empty

         Dim oFactAyuda As FacturablesPendientesAyuda

         If Me.dgvFacturables.RowCount > 0 Then
            If Me._comprobantesSeleccionados IsNot Nothing Then
               If Me._comprobantesSeleccionados.Count > 0 Then
                  IdTipoComprobante = Me._comprobantesSeleccionados(0).TipoComprobante.IdTipoComprobante
               End If
            End If
         Else
            IdTipoComprobante = ""
         End If

         If dgvFacturables.Rows.Count = 0 Then
            oFactAyuda = New FacturablesPendientesAyuda(cmbTiposComprobantes.SelectedValue.ToString(), DirectCast(cmbListaDePrecios.SelectedItem, Entidades.ListaDePrecios).IdListaPrecios, IdTipoComprobante, Long.Parse(Me.bscCodigoCliente.Tag.ToString()), comprobantesSeleccionados:=Nothing)
         Else
            oFactAyuda = New FacturablesPendientesAyuda(cmbTiposComprobantes.SelectedValue.ToString(), DirectCast(cmbListaDePrecios.SelectedItem, Entidades.ListaDePrecios).IdListaPrecios, IdTipoComprobante, Long.Parse(Me.bscCodigoCliente.Tag.ToString()), DirectCast(Me.dgvFacturables.DataSource, List(Of Entidades.Venta)))
         End If

         oFactAyuda.Owner = Me

         oFactAyuda.ShowDialog()

         Me.CargarComprobantesFacturables(oFactAyuda.ComprobantesSeleccionados)
         Me.CargarProductosFacturables(oFactAyuda.ComprobantesSeleccionados)

         If DirectCast(Me.cmbTiposComprobantes.SelectedItem, Entidades.TipoComprobante).ImportaObservDeInvocados Then
            Me.CargarObservacionesFacturables(oFactAyuda.ComprobantesSeleccionados)
         End If

         Me.LimpiarCamposProductos()
         Me.CalcularTotales()
         Me.CalcularDatosDetalle()
         'Me.CalcularTotales()

         If Me._comprobantesSeleccionados.Count > 0 Then
            If Not Me.tbcDetalle.Contains(Me.tbpFacturables) Then
               Me.tbcDetalle.TabPages.Add(Me.tbpFacturables)
            End If
            If Me._comprobantesSeleccionados(0).TipoComprobante.ModificaAlFacturar = "SOLOPRECIOS" Then
               Me.CambiarEstadoControlesDetalle(False)
               Me._ModificaDetalle = "SOLOPRECIOS"
            End If
         Else
            If Me.tbcDetalle.Contains(Me.tbpFacturables) Then
               Me.tbcDetalle.TabPages.Remove(Me.tbpFacturables)
            End If
         End If

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
      End Try
   End Sub

   Private Sub tsbCajaRegistradora_Click(sender As Object, e As EventArgs) Handles tsbCajaRegistradora.Click
      Try
         Dim ImpFiscal As Entidades.Impresora = New Entidades.Impresora()

         ImpFiscal = New Reglas.Impresoras().GetPorSucursalPC(actual.Sucursal.Id, My.Computer.Name, True)

         If ImpFiscal.Marca = "HASAR" Then
            Dim objHasar As New FiscalHASAR(ImpFiscal.Puerto.Replace("COM", ""), ImpFiscal.Velocidad, Entidades.Publicos.CarpetaEniac)
            objHasar.AbrirCajon()
         ElseIf ImpFiscal.Marca = "EPSON" Then
            Dim _ArchivoEntrada As String = Entidades.Publicos.CarpetaEniac + "Envio.txt"
            Dim _ArchivoSalida As String = Entidades.Publicos.CarpetaEniac + "Salida.txt"
            Dim objEpson As New FiscalEPSON(_ArchivoEntrada, _ArchivoSalida, Nothing)
            objEpson.AbrirCajon(ImpFiscal.Puerto)
         End If

         '' ''Dim ModeloFiscal As LibreriaFiscal.ControladorFiscal.ModelosFiscales
         '' ''Select Case True
         '' ''   Case ImpFiscal.Modelo = "SMH/P-330F"
         '' ''      ModeloFiscal = LibreriaFiscal.ControladorFiscal.ModelosFiscales.HASAR_330

         '' ''   Case ImpFiscal.Modelo = "SMH/P-441F"
         '' ''      ModeloFiscal = LibreriaFiscal.ControladorFiscal.ModelosFiscales.HASAR_441

         '' ''   Case ImpFiscal.Modelo = "SMH/P-715F"
         '' ''      ModeloFiscal = LibreriaFiscal.ControladorFiscal.ModelosFiscales.HASAR_715

         '' ''   Case ImpFiscal.Modelo = "SMH/P-715Fv1"
         '' ''      ModeloFiscal = LibreriaFiscal.ControladorFiscal.ModelosFiscales.HASAR_715_VER1

         '' ''   Case (ImpFiscal.Modelo = "TM-U220AF" Or ImpFiscal.Modelo = "TM-U220AFII")
         '' ''      ModeloFiscal = LibreriaFiscal.ControladorFiscal.ModelosFiscales.EPSON_220

         '' ''   Case (ImpFiscal.Modelo = "TM-U2000AF" Or ImpFiscal.Modelo = "TM-U2000AF+" Or ImpFiscal.Modelo = "TM-U2002AF+")
         '' ''      ModeloFiscal = LibreriaFiscal.ControladorFiscal.ModelosFiscales.EPSON_2002

         '' ''   Case ImpFiscal.Modelo = "TM-U950F"
         '' ''      ModeloFiscal = LibreriaFiscal.ControladorFiscal.ModelosFiscales.EPSON_950

         '' ''   Case ImpFiscal.Modelo = "LX-300F+"
         '' ''      ModeloFiscal = LibreriaFiscal.ControladorFiscal.ModelosFiscales.EPSON_LX300

         '' ''   Case Else
         '' ''      Throw New Exception("ATENCION: El modelo " & ImpFiscal.Modelo & " NO se encuentra Habilitado , " & Chr(13) & Chr(13) & "NO podrá Continuar, por favor comuniquese con SISTEMAS.")
         '' ''      Exit Sub
         '' ''End Select

         ' '' ''GAR: 11/05/2016 - Quedaba el vinculo a la fiscal abriendo la caja solo una vez.
         ' '' ''Me._controladorFiscal = LibreriaFiscal.ControladorFiscal.CrearInstancia(ModeloFiscal)
         ' '' ''Me._controladorFiscal.Comenzar(ImpFiscal.Puerto, LibreriaFiscal.ControladorFiscal.ModosTrabajoLibreria.SINCRONO)
         ' '' ''Me._controladorFiscal.AbrirGaveta()
         ' '' ''Me._controladorFiscal.Finalizar()

         '' ''With LibreriaFiscal.ControladorFiscal.CrearInstancia(ModeloFiscal)
         '' ''   .Comenzar(ImpFiscal.Puerto, LibreriaFiscal.ControladorFiscal.ModosTrabajoLibreria.SINCRONO)
         '' ''   .AbrirGaveta()
         '' ''   .Finalizar()
         '' ''End With


      Catch ex As Exception
         MessageBox.Show("Hubo problemas al abrir la caja registradora" + ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
      End Try
   End Sub

   Private Sub txtDescRecPorc1_Leave(sender As Object, e As EventArgs) Handles txtDescRecPorc1.Leave
      Try
         If Me.txtDescRecPorc1.Text = "" Or Me.txtDescRecPorc1.Text = "-" Then
            Me.txtDescRecPorc1.Text = _ceroDecimalesEnDescRec
         End If
         Me.CalcularDescuentosProductos()
         Me.CalcularTotalProducto()
         Me.CalcularImpuestoInterno()
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

   Private Sub txtDescRecPorc2_Leave(sender As Object, e As EventArgs) Handles txtDescRecPorc2.Leave
      Try
         If Me.txtDescRecPorc2.Text = "" Or Me.txtDescRecPorc2.Text = "-" Then
            Me.txtDescRecPorc2.Text = _ceroDecimalesEnDescRec
         End If
         Me.CalcularDescuentosProductos()
         Me.CalcularTotalProducto()
         Me.CalcularImpuestoInterno()
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

   Private Sub txtDescRecPorc1_LostFocus(sender As Object, e As EventArgs) Handles txtDescRecPorc1.LostFocus
      Try
         If Me.txtDescRecPorc1.Text = "" Or Me.txtDescRecPorc1.Text = "-" Then
            Me.txtDescRecPorc1.Text = _ceroDecimalesEnDescRec
         End If
         Me.CalcularDescuentosProductos()
         Me.CalcularTotalProducto()
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
      End Try
   End Sub

   Private Sub txtDescRecPorc2_LostFocus(sender As Object, e As EventArgs) Handles txtDescRecPorc2.LostFocus
      Try
         If Me.txtDescRecPorc2.Text = "" Or Me.txtDescRecPorc2.Text = "-" Then
            Me.txtDescRecPorc2.Text = _ceroDecimalesAMostrar
         End If
         Me.CalcularDescuentosProductos()
         Me.CalcularTotalProducto()
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
      End Try
   End Sub

   Private Sub cmbCajas_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbCajas.SelectedIndexChanged
      Try
         Me.ChequeaCajas()
      Catch ex As Exception
         MessageBox.Show(ex.Message, Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub chbModificaDescRecGralPorc_CheckedChanged(sender As Object, e As EventArgs) Handles chbModificaDescRecGralPorc.CheckedChanged

      '# Disparo el cálculo del D/R
      Dim nuevoDescRecGralPorc As Decimal = CalculosDescuentosRecargos1.DescuentoRecargo(_clienteE,
                                                                                         cmbTiposComprobantes.ItemSeleccionado(Of Entidades.TipoComprobante),
                                                                                         cmbFormaPago.ItemSeleccionado(Of Entidades.VentaFormaPago),
                                                                                         _cantLineas)
      Me._DescRecGralPorc = nuevoDescRecGralPorc
      Me.txtDescRecGralPorc2.Text = _DescRecGralPorc.ToString("N" + _decimalesEnDescRec.ToString())

      If Me.chbModificaDescRecGralPorc.Checked Then
         Me.txtDescRecGralPorc2.ReadOnly = False
         Me.txtDescRecGralPorc2.Focus()
         Me.txtDescRecGralPorc2.SelectAll()
      Else
         Me.txtDescRecGralPorc2.ReadOnly = True
      End If

      Me.CalcularDatosDetalle()
   End Sub

#End Region

#Region "Metodos"
   ''' <summary>
   ''' Guardo la lista de Precios anterior para el caso de cmabio por bonificacion.
   ''' y solo la primera vez.
   ''' </summary>
   Private Sub GuardoListaPreciosPrevia()
      '-- REQ-41750.- -------------------------------------------------------
      If Not _cambioListaPrecio.HasValue Then
         _cambioListaPrecio = Integer.Parse(cmbListaDePrecios.SelectedValue.ToString())
         '----------------------------------------------------------------------
      End If
   End Sub

   Private Sub BonificacionListaDePrecioXCantidad(prod As Entidades.Producto, cantidad As Decimal)
      _idListaAux = -1
      '-- REQ-33090.- ---------------------------------------------------------------------------------------
      If cantidad >= prod.UnidHasta5 AndAlso prod.UHListaPrecios5 IsNot Nothing Then
         If DirectCast(Me.cmbFormaPago.SelectedItem, Entidades.VentaFormaPago).IdListaPrecios Is Nothing Then
            GuardoListaPreciosPrevia()
            cmbListaDePrecios.SelectedValue = prod.UHListaPrecios5
         End If
         _idListaAux = CInt(prod.UHListaPrecios5)
      ElseIf cantidad >= prod.UnidHasta4 AndAlso prod.UHListaPrecios4 IsNot Nothing Then
         If DirectCast(Me.cmbFormaPago.SelectedItem, Entidades.VentaFormaPago).IdListaPrecios Is Nothing Then
            GuardoListaPreciosPrevia()
            cmbListaDePrecios.SelectedValue = prod.UHListaPrecios4
         End If
         _idListaAux = CInt(prod.UHListaPrecios4)
      ElseIf cantidad >= prod.UnidHasta3 AndAlso prod.UHListaPrecios3 IsNot Nothing Then
         If DirectCast(Me.cmbFormaPago.SelectedItem, Entidades.VentaFormaPago).IdListaPrecios Is Nothing Then
            GuardoListaPreciosPrevia()
            cmbListaDePrecios.SelectedValue = prod.UHListaPrecios3
         End If
         _idListaAux = CInt(prod.UHListaPrecios3)
      ElseIf cantidad >= prod.UnidHasta2 AndAlso prod.UHListaPrecios2 IsNot Nothing Then
         If DirectCast(Me.cmbFormaPago.SelectedItem, Entidades.VentaFormaPago).IdListaPrecios Is Nothing Then
            GuardoListaPreciosPrevia()
            cmbListaDePrecios.SelectedValue = prod.UHListaPrecios2
         End If
         _idListaAux = CInt(prod.UHListaPrecios2)

      ElseIf cantidad >= prod.UnidHasta1 AndAlso prod.UHListaPrecios1 IsNot Nothing Then
         If DirectCast(Me.cmbFormaPago.SelectedItem, Entidades.VentaFormaPago).IdListaPrecios Is Nothing Then
            GuardoListaPreciosPrevia()
            cmbListaDePrecios.SelectedValue = prod.UHListaPrecios1
         End If
         _idListaAux = CInt(prod.UHListaPrecios1)
      Else
         If DirectCast(Me.cmbFormaPago.SelectedItem, Entidades.VentaFormaPago).IdListaPrecios Is Nothing Then
            GuardoListaPreciosPrevia()
            cmbListaDePrecios.SelectedValue = _clienteE.IdListaPrecios
         End If
         _idListaAux = _clienteE.IdListaPrecios
      End If
      '-------------------------------------------------------------------------------------------------------
   End Sub

   Private Sub SeteaIVASegunComprobante(vp As Entidades.VentaProducto, tpComp As Entidades.TipoComprobante, setearPrecio As Boolean)

      If tpComp.GrabaLibro Or tpComp.EsPreElectronico Or tpComp.UtilizaImpuestos Then

         '# Si la alicuota del VP es 0%, quiere decir que el IVA NO fue modificado manualmente ya que vengo de un comprobante que NO UTILIZA imp.
         '# En ese caso, se debe colocar el IVA del ABM Producto. Si es <> 0%, NO lo modifico ya que fué modificado anteriormente.
         If vp.AlicuotaImpuesto = 0 Then
            vp.AlicuotaImpuesto = vp.Producto.Alicuota
         End If

         '# Si el comprobante además de utilizar impuestos, GRABA LIBRO, SI O SI debe ir el IVA del Prodducto ABM.
         If tpComp.GrabaLibro Or tpComp.EsPreElectronico Then
            vp.AlicuotaImpuesto = vp.Producto.Alicuota
         End If

         '# Alicuota 2
         If Reglas.Publicos.ProductoUtilizaAlicuota2 AndAlso cmbCategoriaFiscal.ItemSeleccionado(Of Entidades.CategoriaFiscal)().ResuelveUtilizaAlicuota2Producto(_clienteE) AndAlso vp.Producto.Alicuota2.HasValue Then
            vp.AlicuotaImpuesto = vp.Producto.Alicuota2.Value
         End If

         If setearPrecio Then
            If Not Me._clienteE.CategoriaFiscal.IvaDiscriminado Or Not Me._categoriaFiscalEmpresa.IvaDiscriminado Then
               vp.Precio = Decimal.Round(Reglas.CalculosImpositivos.ObtenerPrecioConImpuestos(vp.Precio, vp.AlicuotaImpuesto, vp.PorcImpuestoInterno, vp.Producto.ImporteImpuestoInterno, vp.OrigenPorcImpInt), _decimalesRedondeoEnPrecio)
            End If
         End If

      Else

         '# Si la alicuota del VP <> alicuota ProductoABM, quiere decir que se fue modificado manualmente ya que vengo de un comprobante que UTILIZA IMP. En ese caso, NO lo modifico.
         '# Caso contrario, llevo la alicuota VP a 0%.
         If vp.AlicuotaImpuesto = vp.Producto.Alicuota Then
            vp.AlicuotaImpuesto = 0
         End If
         If setearPrecio Then
            vp.Precio = Decimal.Round(Reglas.CalculosImpositivos.ObtenerPrecioConImpuestos(vp.Precio, vp.AlicuotaImpuesto, vp.PorcImpuestoInterno, vp.Producto.ImporteImpuestoInterno, vp.OrigenPorcImpInt), _decimalesRedondeoEnPrecio)
         End If

      End If

   End Sub

   Private Sub CargarLotesPreviamenteSeleccionados(vp As Entidades.VentaProducto)

      If _lotesSeleccionados Is Nothing Then
         _lotesSeleccionados = New DataTable
         _lotesSeleccionados.Columns.Add("IdSucursal", GetType(Integer))
         _lotesSeleccionados.Columns.Add("IdProducto", GetType(String))
         _lotesSeleccionados.Columns.Add("IdLote", GetType(String))
         _lotesSeleccionados.Columns.Add("FechaVencimiento", GetType(Date))
         _lotesSeleccionados.Columns.Add("CantidadSeleccionada", GetType(Decimal))
      End If

      For Each vpl As Entidades.VentaProductoLote In vp.VentasProductosLotes
         Dim row As DataRow = _lotesSeleccionados.NewRow
         row("IdSucursal") = vpl.IdSucursal
         row("IdProducto") = vpl.IdProducto
         row("IdLote") = vpl.IdLote
         If vpl.FechaVencimiento IsNot Nothing Then
            row("FechaVencimiento") = vpl.FechaVencimiento
         End If
         row("CantidadSeleccionada") = vpl.Cantidad
         _lotesSeleccionados.Rows.Add(row)
      Next

   End Sub

   Private Sub MostrarNumerosLotesDesdeGrilla(grilla As DataGridView, e As DataGridViewCellEventArgs)
      If grilla.Columns(e.ColumnIndex).Name = "NrosLotes" Or grilla.Columns(e.ColumnIndex).Name = "NrosLotesRT" Then
         Dim eVentaProducto As Entidades.VentaProducto = DirectCast(DirectCast(grilla.SelectedRows(0), DataGridViewRow).DataBoundItem, Eniac.Entidades.VentaProducto)

         If Not eVentaProducto.Producto.Lote Then
            ShowMessage("Este producto no utiliza Lote.")
            Exit Sub
         End If

         '# Reconstruyo los lotes seleccionados
         If eVentaProducto.VentasProductosLotes.Count <> 0 Then
            Me.CargarLotesPreviamenteSeleccionados(eVentaProducto)
         End If

         Dim coeficienteStock As Integer = DirectCast(Me.cmbTiposComprobantes.SelectedItem, Entidades.TipoComprobante).CoeficienteStock
         If coeficienteStock = 0 And
            Not String.IsNullOrWhiteSpace(DirectCast(Me.cmbTiposComprobantes.SelectedItem, Entidades.TipoComprobante).IdTipoComprobanteSecundario) Then
            Dim tipoSecundario As Entidades.TipoComprobante
            tipoSecundario = New Reglas.TiposComprobantes().GetUno(DirectCast(Me.cmbTiposComprobantes.SelectedItem, Entidades.TipoComprobante).IdTipoComprobanteSecundario)
            coeficienteStock = tipoSecundario.CoeficienteStock
         End If

         If (eVentaProducto.Producto.IdSucursal = 0) Then eVentaProducto.Producto.IdSucursal = actual.Sucursal.Id
         Using frm As SeleccionNrosLotes = New SeleccionNrosLotes(eVentaProducto.Producto, eVentaProducto.Producto.IdDeposito, eVentaProducto.Producto.IdUbicacion, eVentaProducto.Cantidad, coeficienteStock, _lotesSeleccionados)
            If frm.ShowDialog() = Windows.Forms.DialogResult.Yes Then
               '# Me guardo los lotes seleccionados
               _lotesSeleccionados = frm._lotesSeleccionados
               Me.CargarLotesSeleccionados(_lotesSeleccionados, eVentaProducto, eVentaProducto.Producto)
            End If
         End Using
      End If
   End Sub

   Private Sub CargarLotesSeleccionados(lotesSeleccionados As DataTable,
                                        lineaDetalle As Entidades.VentaProducto,
                                        _productoTemporal As Entidades.Producto)
      Me.CargarLotesSeleccionados(lotesSeleccionados,
                                  lineaDetalle,
                                  _productoTemporal,
                                  precioCosto:=0,
                                  idMoneda:=0)
   End Sub

   Private Sub CargarLotesSeleccionados(lotesSeleccionados As DataTable,
                                        lineaDetalle As Entidades.VentaProducto,
                                        _productoTemporal As Entidades.Producto,
                                        precioCosto As Decimal,
                                        idMoneda As Integer)



      For Each row As DataRow In lotesSeleccionados.Rows

         '# Validar que no se haya sobrepasado el stock del lote con los productos ya agregados anteriormente
         Dim cantidadTotal As Decimal = 0
         For Each vp As Entidades.VentaProducto In _ventasProductos
            cantidadTotal += vp.VentasProductosLotes.Where(Function(vpl) vpl.IdLote = row("IdLote").ToString()).Sum(Function(x) x.Cantidad)
            cantidadTotal += CDec(row("CantidadSeleccionada"))
            If cantidadTotal > CDec(row("CantidadActual")) Then
               Throw New Exception(String.Format("ATENCIÓN: La cantidad ingresada del lote {0} del producto {1} superaría la cantidad en stock.", row("IdLote"), row("NombreProducto")))
            End If
         Next

         _productoLoteTemporal = New Entidades.VentaProductoLote

         '# Validar Fecha de Vencimiento
         If Reglas.Publicos.LoteSolicitaFechaVencimiento Then
            If DirectCast(Me.cmbTiposComprobantes.SelectedItem, Entidades.TipoComprobante).CoeficienteStock > 0 Then
               If row.Field(Of Date?)(Entidades.ProductoLote.Columnas.FechaVencimiento.ToString()) = Me.dtpFecha.Value.Date Then
                  If ShowPregunta("La fecha del lote es igual a la fecha del comprobante. Desea continuar?") <> Windows.Forms.DialogResult.Yes Then
                     Exit Sub
                  End If
               ElseIf row.Field(Of Date?)(Entidades.ProductoLote.Columnas.FechaVencimiento.ToString()) < Me.dtpFecha.Value.Date Then
                  If ShowPregunta("La fecha del lote es menor que la fecha del comprobante. Desea continuar?") <> Windows.Forms.DialogResult.Yes Then
                     Exit Sub
                  End If
               End If
               _productoLoteTemporal.FechaVencimiento = row.Field(Of Date?)(Entidades.ProductoLote.Columnas.FechaVencimiento.ToString())
            Else
               _productoLoteTemporal.FechaVencimiento = row.Field(Of Date?)(Entidades.ProductoLote.Columnas.FechaVencimiento.ToString())
            End If
         Else
            _productoLoteTemporal.FechaVencimiento = Nothing
         End If

         _productoLoteTemporal.IdSucursal = row.Field(Of Integer)(Entidades.ProductoLote.Columnas.IdSucursal.ToString())
         _productoLoteTemporal.Producto = _productoTemporal
         _productoLoteTemporal.IdLote = row.Field(Of String)(Entidades.ProductoLote.Columnas.IdLote.ToString())
         _productoLoteTemporal.Cantidad = row.Field(Of Decimal)("CantidadSeleccionada")
         _productoLoteTemporal.Orden = _numeroOrden

         lineaDetalle.VentasProductosLotes.Add(_productoLoteTemporal)

         '# Si se manejan Precio Costo
         If precioCosto <> 0 Then
            If Reglas.Publicos.UtilizaPrecioCostoPorLote Then
               precioCosto = _productoLoteTemporal.Producto.PrecioCosto
               If Reglas.Publicos.PreciosConIVA Then
                  precioCosto = Decimal.Round(precioCosto / (1 + lineaDetalle.AlicuotaImpuesto / 100), Me._decimalesRedondeoEnPrecio)
               End If
               If idMoneda = 2 Then
                  precioCosto = Decimal.Round(precioCosto * Decimal.Parse(Me.txtCotizacionDolar.Text), Me._decimalesRedondeoEnPrecio)
               End If
            End If
         End If
      Next

      '# Luego de cargar los lotes que se seleccionaron en la entidad, mantengo la estructura pero limpio el datatable
      If _lotesSeleccionados IsNot Nothing Then
         _lotesSeleccionados.Clear()
      End If

   End Sub

   Private Sub SetearColorSemaforos(textBox As Eniac.Controles.TextBox, IdTipoSemaforo As Entidades.SemaforoVentaUtilidad.TiposSemaforos)

      '# valor va a tomar el decimal que se encuentre en la caja de texto recibida por parámetro
      '# La misma que va a ser utilizada para pintar el color del semáforo
      '# RENTABILIDAD / SALDOS
      If Not String.IsNullOrEmpty(textBox.Text) Then
         Dim valor As Decimal = CDec(textBox.Text)
         Dim eSemaforoVentaUtilidad As Entidades.SemaforoVentaUtilidad

         eSemaforoVentaUtilidad = New Reglas.SemaforoVentasUtilidades().ColorSemaforo(valor, IdTipoSemaforo)
         If eSemaforoVentaUtilidad IsNot Nothing Then
            With eSemaforoVentaUtilidad
               textBox.BackColor = System.Drawing.Color.FromArgb(.ColorSemaforo)
               textBox.ForeColor = System.Drawing.Color.FromArgb(.ColorLetra)
               If .Negrita Then
                  textBox.Font = New Font(textBox.Font, FontStyle.Bold)
               Else
                  textBox.Font = New Font(textBox.Font, FontStyle.Regular)
               End If
            End With
         End If
      End If
   End Sub

   Private Sub ValidarDiasDeVencimiento()

      '# Controlo Limite Dias Vto Factura 
      If Me._clienteE Is Nothing OrElse
         Me.cmbTiposComprobantes.SelectedIndex = -1 Then Exit Sub

      If Me._clienteE.LimiteDiasVtoFactura > 0 AndAlso DirectCast(Me.cmbTiposComprobantes.SelectedItem, Entidades.TipoComprobante).CoeficienteValores = 1 Then
         Dim oCtaCteDet As Reglas.CuentasCorrientes = New Reglas.CuentasCorrientes
         Dim FechaLimite As Date = Date.Today().AddDays(-Me._clienteE.LimiteDiasVtoFactura)
         Dim dt As DataTable

         dt = oCtaCteDet.GetCtaCte(actual.Sucursal.IdSucursal, Nothing, Nothing, 0, Me._clienteE.IdCliente, Nothing, "CON SALDO", "", 0, "TODOS", Nothing, "SI", "SI", "SI", "", "ACTUAL", "ACTUAL", "NO", Nothing, agruparIdClienteCtaCte:=False, ruta:=0, dia:=Nothing, 0)

         If dt.Rows.Count <> 0 Then
            Dim fechaDeVencimiento As Date = dt.Rows(0).Field(Of Date)("FechaVencimiento")
            If fechaDeVencimiento <= FechaLimite Then
               Dim fechaFact As Date = fechaDeVencimiento
               Dim Dias As Long = DateDiff(DateInterval.Day, fechaFact, FechaLimite)

               Select Case Publicos.ControlaDiasVtoDeCreditoDeClientes
                  Case "No Permitir"
                     Throw New Exception("ATENCION: El Cliente Superó la cantidad de dias de límite de Crédito. El Comprobante fué Cancelado por Falta de Crédito.")
                  Case "Avisar y Permitir"
                     If Not LimiteDiasVtoPermitido() Then
                        Throw New Exception("El Comprobante fué Cancelado por Falta de Crédito.")
                     End If
                     If ShowPregunta("ATENCION: El Cliente Superó la cantidad de dias de límite de Crédito, ¿ Continúa ?", MessageBoxDefaultButton.Button2) <> Windows.Forms.DialogResult.Yes Then
                        Throw New Exception("El Comprobante fué Cancelado por Falta de Crédito.")
                     End If
                  Case Else
                     If Not LimiteDiasVtoPermitido() Then
                        Throw New Exception("El Comprobante fué Cancelado por Falta de Crédito.")
                     End If
               End Select
            End If
         End If
      End If

   End Sub

   Private Function ValidarLimiteCredito(arrojarException As Boolean) As Boolean?
      If Decimal.Parse(Me.txtSaldoCtaCte.Text) + Decimal.Parse(Me.txtTotalGeneral.Text) > Decimal.Parse(Me.txtLimiteDeCredito.Text) Then
         Select Case Publicos.ControlaEventosdeLimiteDeCreditoDeClientes
            Case "No Permitir"
               If Not arrojarException Then
                  ShowMessage("ATENCION: El Cliente Superó el Límite de Crédito")
                  Return False
               Else
                  Throw New Exception("ATENCION: El Cliente Superó la cantidad de dias de límite de Crédito. El Comprobante fué Cancelado por Falta de Crédito.")
               End If
            Case "Avisar y Permitir"
               If Not LimiteCreditoPermitido() Then
                  ShowMessage("ATENCION: El Cliente Superó el Límite de Crédito")
                  Return False
               End If
               If ShowPregunta("ATENCION: El Cliente Superó el Límite de Crédito, ¿ Continúa ?") <> Windows.Forms.DialogResult.Yes Then
                  If Not arrojarException Then
                     ShowMessage("ATENCION: El Cliente Superó el Límite de Crédito")
                     Return False
                  Else
                     Throw New Exception("El Comprobante fué Cancelado por Falta de Crédito.")
                  End If
               End If
            Case Else
               If Not LimiteCreditoPermitido() Then
                  ShowMessage("ATENCION: El Cliente Superó el Límite de Crédito")
                  Return False
               End If
         End Select
      End If
   End Function

   Private Function PuedoCancelarVenta(functEvaluar As String, functEvaluar2 As String) As Boolean


      Return BaseSeguridad.ControloPermisos(Eniac.Entidades.Usuario.Actual.Sucursal.Id,
                                            Eniac.Ayudantes.Common.usuario,
                                            functEvaluar,
                                            functEvaluar2,
                                            funcionSupervisor)
   End Function

   Private Sub PreparaFormatosControles()
      Me.txtCantidad.Formato = _formatoEnCantidad
      Me.txtPrecio.Formato = "##0." + New String("0"c, Me._decimalesAMostrar)
      Me.txtTotalProducto.Formato = "##0." + New String("0"c, Me._decimalesAMostrar)
      Me.txtKilos.Formato = "##0.000"
      Me.txtTotalBruto.Formato = "##,##0." + New String("0"c, Me._decimalesAMostrar)
      Me.txtDescRecGral.Formato = "##,##0." + New String("0"c, Me._decimalesAMostrar)
      Me.txtTotalNeto.Formato = "##,##0." + New String("0"c, Me._decimalesAMostrar)
      Me.txtTotalImpuestos.Formato = "##,##0." + New String("0"c, Me._decimalesAMostrar)
      Me.txtTotalPercepcion.Formato = "##,##0." + New String("0"c, Me._decimalesAMostrar)
      Me.txtTotalSubtotales.Formato = "##,##0." + New String("0"c, Me._decimalesAMostrar)
      'columnas grillas
      Me.Precio.DefaultCellStyle.Format = "N" + Me._decimalesAMostrar.ToString()
      Me.Importe.DefaultCellStyle.Format = "N" + Me._decimalesAMostrar.ToString()
   End Sub

   Private Function GetCodigoModalidadPeso() As String
      If _codigoBarrasCompleto.Length = 13 Then
         Dim num As Integer = 0
         Integer.TryParse(_codigoBarrasCompleto.Substring(0, Reglas.Publicos.CaracteresProductoCBPesoCantidad), num)
         Return num.ToString()
      Else
         Return Me._codigoBarrasCompleto
      End If
   End Function

   ''''Private Function GetPrecioModalidadPrecio() As Decimal
   ''''   If Me._codigoBarrasCompleto.Length = 13 Then
   ''''      Return Decimal.Parse(Me._codigoBarrasCompleto.Substring(7, 5).Insert(3, "."))
   ''''   Else
   ''''      Return 0
   ''''   End If
   ''''End Function

   Private Function GetPrecioModalidadPeso() As Decimal
      If _codigoBarrasCompleto.Length = 13 Then
         Return Decimal.Parse(_codigoBarrasCompleto.Substring(Reglas.Publicos.CaracteresProductoCBPesoCantidad,
                                                              12 - Reglas.Publicos.CaracteresProductoCBPesoCantidad).
                                                    Insert(12 - Reglas.Publicos.CaracteresProductoCBPesoCantidad - 3, "."))
      Else
         Return 0
      End If
   End Function

   Private Sub CargarDatosBancos(dr As DataGridViewRow)
      Me.bscBancos.Text = dr.Cells("NombreBanco").Value.ToString()
   End Sub

   Private Sub CargarDatosTarjetasBancos(dr As DataGridViewRow)
      Me.bscTarBanco.Text = dr.Cells("NombreBanco").Value.ToString()
      Me.txtTarMonto.Text = Me.txtDiferencia.Text
   End Sub

   Private Sub EliminarLineaCheques()
      Me._cheques.RemoveAt(Me.dgvCheques.SelectedRows(0).Index)

      Me.dgvCheques.DataSource = Me._cheques.ToArray()

      Me.CalcularPagos(False)
   End Sub

   Private Sub EliminarLineaTarjetas()
      Me._tarjetas.RemoveAt(Me.dgvTarjetas.SelectedRows(0).Index)

      Me.dgvTarjetas.DataSource = Me._tarjetas.ToArray()

      Me.CalcularPagos(_recalcularEfectivoAlCargarTarjeta)
   End Sub

   Private Sub CalcularPagos(recalcularEfectivoSegunDiferencia As Boolean)

      Dim tarMon As Decimal = 0
      Dim pago As Decimal = 0
      Dim fPago As Entidades.VentaFormaPago = cmbFormaPago.ItemSeleccionado(Of Entidades.VentaFormaPago)()

      For Each ch As Entidades.Cheque In Me._cheques
         pago += ch.Importe
      Next

      Me.txtCheques.Text = pago.ToString("#,##0." + New String("0"c, Me._decimalesAMostrar))

      For Each tar As Entidades.VentaTarjeta In Me._tarjetas
         tarMon += tar.Monto
      Next

      Me.txtTarjetas.Text = tarMon.ToString("#,##0." + New String("0"c, Me._decimalesAMostrar))

      If Me.txtTickets.Text.Length = 0 Then
         Me.txtTickets.Text = _ceroDecimalesAMostrar
      End If

      If Me.txtEfectivo.Text.Length = 0 Then
         Me.txtEfectivo.Text = _ceroDecimalesAMostrar
      End If
      If txtImporteDolares.Text.Length = 0 Then
         txtImporteDolares.SetValor(0D)
      End If

      '-- REQ-32366.- -----------------------------------------------------------------
      If Me.txtTransferenciaBancaria.Text.Length = 0 Then
         Me.txtTransferenciaBancaria.Text = "0." + New String("0"c, _decimalesAMostrar)
      End If
      '--------------------------------------------------------------------------------

      pago = Math.Round(pago, Me._valorRedondeo) + Decimal.Parse(Me.txtEfectivo.Text) +
                              Decimal.Parse(Me.txtTickets.Text) + Decimal.Parse(Me.txtTarjetas.Text) + Decimal.Parse(Me.txtTransferenciaBancaria.Text) +
                              (txtImporteDolares.ValorNumericoPorDefecto(0D) * txtCotizacionDolar.ValorNumericoPorDefecto(0D))

      Me.txtTotalPago.Text = pago.ToString("#,##0." + New String("0"c, Me._decimalesAMostrar))
      Me.txtDiferencia.Text = (Decimal.Parse(Me.txtTotalGeneral.Text) - Decimal.Parse(Me.txtTotalPago.Text)).ToString("#,##0." + New String("0"c, Me._decimalesAMostrar))

      If fPago IsNot Nothing AndAlso fPago.Dias = 0 AndAlso recalcularEfectivoSegunDiferencia AndAlso Decimal.Parse(txtDiferencia.Text) <> 0 Then
         txtEfectivo.Text = Math.Max(0, (Decimal.Parse(txtEfectivo.Text) + Decimal.Parse(txtDiferencia.Text))).ToString("N" + _decimalesAMostrar.ToString())

         CalcularPagos(False)
         'pago = Math.Round(pago, Me._valorRedondeo) + Decimal.Parse(Me.txtEfectivo.Text) + _
         '                        Decimal.Parse(Me.txtTickets.Text) + Decimal.Parse(Me.txtTarjetas.Text)

         'Me.txtTotalPago.Text = pago.ToString("#,##0." + New String("0"c, Me._decimalesAMostrar))
         'Me.txtDiferencia.Text = (Decimal.Parse(Me.txtTotalGeneral.Text) - Decimal.Parse(Me.txtTotalPago.Text)).ToString("#,##0." + New String("0"c, Me._decimalesAMostrar))
      End If

   End Sub

   Private Sub LimpiarCamposCheques()
      Me.bscBancos.Text = ""
      Me.bscBancos.FilaDevuelta = Nothing
      Me.dtpFechaCobro.Value = Date.Now
      Me.dtpFechaEmision.Value = Date.Now
      Me.txtImporteCheque.Text = _ceroDecimalesAMostrar
      Me.txtNroCheque.Text = "0"
      Me.txtCodPostalCheque.Text = "0"
      Me.txtSucursalBanco.Text = "0"
      Me.txtTitularCheque.Text = ""
      Me.cmbTipoCheque.SelectedValue = "F"
      Me.txtCuitChequeTercero.Clear()
      Me.txtNroOperacion.Clear()
   End Sub

   Private Sub LimpiarCamposTarjetas()
      Me.cmbTarTarjeta.SelectedIndex = -1
      Me.bscTarBanco.Text = ""
      Me.bscTarBanco.FilaDevuelta = Nothing
      Me.txtTarCuotas.Text = "1"
      Me.txtTarMonto.Text = _ceroDecimalesAMostrar
      Me.txtTarNumeroCupon.Text = "0"
      Me.txtTarNumeroLote.Text = "0"
   End Sub

   Private Function ValidarComprobante() As Boolean

      My.Application.Log.WriteEntry("FacturacionRapida.ValidarComprobante INICIA " + Now.ToString("dd/MM/yyyy HH:mm:ss.fff"), TraceEventType.Verbose)

      Dim sistema As Entidades.Sistema = Publicos.GetSistema()

      If DateDiff(DateInterval.Day, Me.dtpFecha.Value, sistema.FechaVencimiento) < 0 Then
         MessageBox.Show("La fecha es mayor a la validez del sistema, el " & sistema.FechaVencimiento.ToString("dd/MM/yyyy") & ".", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
         Me.dtpFecha.Focus()
         Return False
      End If
      If UCase(txtLetra.Text) = "E" Then
         ShowMessage("Formulario no habilitado para Comprobantes de Exportacion!!!.")
         Return False
      End If

      If DirectCast(Me.cmbTiposComprobantes.SelectedItem, Entidades.TipoComprobante).GrabaLibro Then
         Dim oPF As Reglas.PeriodosFiscales = New Reglas.PeriodosFiscales()
         Dim dt As DataTable = oPF.Get1(actual.Sucursal.IdEmpresa, Integer.Parse(Me.dtpFecha.Value.ToString("yyyyMM")))
         If dt.Rows.Count = 0 Then
            MessageBox.Show("La Fecha del Comprobante pertenece a un Periodo Fiscal que aún NO esta habilitado.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Me.dtpFecha.Focus()
            Return False
         ElseIf Not String.IsNullOrEmpty(dt.Rows(0)("FechaCierre").ToString()) Then
            MessageBox.Show("La Fecha del Comprobante pertenece a un Periodo Fiscal Cerrado.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Me.dtpFecha.Focus()
            Return False
         ElseIf Not Boolean.Parse(dt.Rows(0)("VentasHabilitadas").ToString()) Then
            ShowMessage(String.Format("El Período Fiscal '{0}' no está habilitado para emitir Comprobantes de Venta.", dtpFecha.Value.ToString("yyyy/MM")))
            Me.dtpFecha.Focus()
            Return False
         End If
      End If

      If Me.bscCodigoCliente.Text.Trim().Length = 0 Then
         MessageBox.Show("Falta cargar el Código del cliente.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
         Me.bscCodigoCliente.Focus()
         Return False
      End If

      If Me.bscCliente.Text.Trim().Length = 0 Then
         MessageBox.Show("Falta cargar el Nombre del cliente.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
         Me.bscCliente.Focus()
         Return False
      End If

      If Me._clienteE.EsClienteGenerico Then
         If Me.txtNombreClienteGenerico.Text = "" Then
            MessageBox.Show("Debe cargar Nombre de Cliente Eventual.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.txtNombreClienteGenerico.Focus()
            Return False
         End If
      End If

      If Me._clienteE Is Nothing Then
         MessageBox.Show("Falta cargar el Código del cliente.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
         Me.bscCodigoCliente.Focus()
         Return False
      Else
         If String.IsNullOrWhiteSpace(Me._clienteE.Direccion) Then
            MessageBox.Show("El cliente no tiene cargada dirección. Por favor modifique el cliente y vuelva a intentar.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Me.bscCodigoCliente.Focus()
            Return False
         End If
         If Me._clienteE.IdLocalidad <= 0 Then
            MessageBox.Show("El cliente no tiene cargada localidad. Por favor modifique el cliente y vuelva a intentar.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Me.bscCodigoCliente.Focus()
            Return False
         End If
      End If

      If Me._ventasProductos.Count = 0 Then
         MessageBox.Show("No se cargo ningún producto", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
         Me.tbcDetalle.SelectedTab = Me.tbpProductos
         Me.bscCodigoProducto2.Focus()
         Return False
      End If

      If Not Reglas.Publicos.VentasConProductosEnCero Then
         'verifico que ningun producto tenga precio cero
         For Each pro As Entidades.VentaProducto In Me._ventasProductos
            If pro.ImporteTotal = 0 Then
               MessageBox.Show("No puede haber Productos con Precio Cero.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
               Me.tbcDetalle.SelectedTab = Me.tbpProductos
               Me.bscCodigoProducto2.Focus()
               Return False
            End If
         Next
      End If

      '-- REG-32366.- -------------------------------------------------------------------------------------------------------------------------------------------
      If Not _transferencias.Any() AndAlso Decimal.Parse(Me.txtTransferenciaBancaria.Text) > 0 And Not Me.bscCuentaBancariaTransfBanc.Selecciono Then
         MessageBox.Show("Cargo Importe de Transferencia Bancaria pero no eligio la Cuenta de origen", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
         Return False
      End If

      If Decimal.Parse(Me.txtTransferenciaBancaria.Text) < 0 Then
         MessageBox.Show("El importe de Transferencia Bancaria no puede ser Negativo.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
         Return False
      End If
      '----------------------------------------------------------------------------------------------------------------------------------------------------------

      'Validacion de Stock segun Parametro
      Dim rStock As Reglas.Stock = New Reglas.Stock()
      Dim prodSinStock As Entidades.ProductosSinStock()
      prodSinStock = rStock.ControlarStockVenta(actual.Sucursal.Id, cmbTiposComprobantes.ItemSeleccionado(Of Entidades.TipoComprobante), _ventasProductos, _comprobantesSeleccionados)

      If prodSinStock.Count > 0 Then
         Dim stbMensaje As StringBuilder = New StringBuilder()
         If Reglas.Publicos.Facturacion.FacturarSinStock = "NOPERMITIR" Then
            stbMensaje.AppendLine("No es posible facturar los siguientes productos porque no hay stock suficiente.")
         ElseIf Reglas.Publicos.Facturacion.FacturarSinStock = "AVISARYPERMITIR" Then
            stbMensaje.AppendLine("Va a facturar los siguientes productos aunque no tenga stock suficiente.")
         End If
         stbMensaje.AppendLine()

         For Each prodSS As Entidades.ProductosSinStock In prodSinStock
            stbMensaje.AppendFormatLine("    - {0} {1} - Cantidad: {2} - Stock: {3}", prodSS.Producto.IdProducto, prodSS.Producto.NombreProducto, prodSS.Cantidad, prodSS.Stock)
         Next

         ShowMessage(stbMensaje.ToString())

         If Reglas.Publicos.Facturacion.FacturarSinStock = "NOPERMITIR" Then
            Return False
         End If

      End If

#Region "Codigo Comentado"

      'Dim blnControlarStock As Boolean = (DirectCast(Me.cmbTiposComprobantes.SelectedItem, Entidades.TipoComprobante).CoeficienteStock < 0)

      'If blnControlarStock AndAlso Reglas.Publicos.Facturacion.FacturarSinStock <> "PERMITIR" Then
      '   Dim cantidadTotal As Decimal = 0
      '   Dim ProductosCadena As String = ""
      '   Dim producto As String
      '   Dim ProdRepetido As DataTable = New DataTable()
      '   ProdRepetido.Columns.Add("ProdRepetido", System.Type.GetType("System.String"))
      '   ProdRepetido.Columns.Add("NombreProducto", System.Type.GetType("System.String"))
      '   Dim dr2 As DataRow
      '   Dim entro As Boolean = False
      '   Dim ocomponentes1 As Reglas.ProductosComponentes
      '   Dim ocomponentes2 As Reglas.ProductosComponentes
      '   Dim _componentes As DataTable
      '   Dim oProductos1 As Reglas.Productos
      '   Dim Producto1 As Entidades.Producto
      '   Dim entro2 As Boolean = False

      '   My.Application.Log.WriteEntry("FacturacionRapida.ValidarComprobante 1 " + Now.ToString("dd/MM/yyyy HH:mm:ss.fff"), TraceEventType.Verbose)

      '   For Each pro As Entidades.VentaProducto In Me._ventasProductos

      '      If entro2 Then
      '         Exit For
      '      End If

      '      producto = pro.IdProducto

      '      oProductos1 = New Reglas.Productos()
      '      Producto1 = New Entidades.Producto()

      '      'Busco el producto Nuevamente aunque este en la Coleccion porque pudo ajustar alguna caracterisca luego de algun hipotetico mensaje anterior.
      '      Producto1 = oProductos1.GetUno(pro.IdProducto, False)

      '      If Producto1.EsCompuesto Then

      '         If Producto1.DescontarStockComponentes Then
      '            ocomponentes2 = New Reglas.ProductosComponentes()
      '            _componentes = ocomponentes2.GetComponentes(actual.Sucursal.IdSucursal, Producto1.IdProducto, Producto1.IdFormula, 0)

      '            For Each dr1 As DataRow In _componentes.Rows

      '               If entro2 Then
      '                  Exit For
      '               End If

      '               cantidadTotal = Decimal.Parse(dr1("Cantidad").ToString()) * pro.Cantidad

      '               Dim prodSuc As Entidades.ProductoSucursal = New Reglas.ProductosSucursales().GetUno(actual.Sucursal.IdSucursal, dr1("IdProductoComponente").ToString())

      '               'Sumo cantidades en productos repetidos para controlar stock
      '               For Each pro1 As Entidades.VentaProducto In Me._ventasProductos

      '                  'If pro1.IdProducto = producto Then
      '                  '   cantidadTotal = cantidadTotal + pro1.Cantidad
      '                  'End If
      '                  Dim produ3 As Entidades.Producto = New Reglas.Productos().GetUno(pro1.IdProducto, False)

      '                  If produ3.EsCompuesto Then
      '                     If produ3.DescontarStockComponentes Then
      '                        ocomponentes1 = New Reglas.ProductosComponentes()
      '                        Dim _componentes2 As DataTable
      '                        _componentes2 = ocomponentes1.GetComponentes(actual.Sucursal.IdSucursal, produ3.IdProducto, produ3.IdFormula, 0)
      '                        For Each dr4 As DataRow In _componentes2.Rows
      '                           If producto = dr4("IdProductoComponente").ToString() Then
      '                              cantidadTotal = cantidadTotal + Decimal.Parse(dr4("Cantidad").ToString()) * pro1.Cantidad
      '                           End If
      '                        Next
      '                     End If

      '                  Else
      '                     producto = pro1.IdProducto
      '                     'Sumo cantidades en productos repetidos para controlar stock
      '                     For Each pro2 As Entidades.VentaProducto In Me._ventasProductos
      '                        If pro2.IdProducto = producto Then
      '                           cantidadTotal = cantidadTotal + pro2.Cantidad
      '                        End If
      '                     Next
      '                  End If
      '               Next

      '               'Controlo la cantidad total con el stock del producto
      '               If cantidadTotal > prodSuc.Stock And blnControlarStock Then
      '                  'chequeo que ya no se haya controlado
      '                  For Each rep As DataRow In ProdRepetido.Rows
      '                     If pro.IdProducto = rep("ProdRepetido").ToString() Then
      '                        entro = True
      '                     End If
      '                  Next
      '                  If entro = True Then
      '                  Else
      '                     dr2 = ProdRepetido.NewRow()
      '                     dr2("ProdRepetido") = prodSuc.Producto.IdProducto
      '                     dr2("NombreProducto") = prodSuc.Producto.NombreProducto
      '                     ProdRepetido.Rows.Add(dr2)
      '                  End If

      '               End If
      '               entro = False
      '               cantidadTotal = 0

      '               For Each dr As DataRow In ProdRepetido.Rows
      '                  ProductosCadena = ProductosCadena + " - " + dr("NombreProducto").ToString()
      '                  entro2 = True
      '               Next

      '            Next
      '         End If



      '      Else

      '         'Sumo cantidades en productos repetidos para controlar stock
      '         For Each pro1 As Entidades.VentaProducto In Me._ventasProductos

      '            'If pro1.IdProducto = producto Then
      '            '   cantidadTotal = cantidadTotal + pro1.Cantidad
      '            'End If
      '            Dim produ3 As Entidades.Producto = New Reglas.Productos().GetUno(pro1.IdProducto, False)

      '            If produ3.EsCompuesto Then
      '               If produ3.DescontarStockComponentes Then
      '                  ocomponentes1 = New Reglas.ProductosComponentes()
      '                  Dim _componentes2 As DataTable
      '                  _componentes2 = ocomponentes1.GetComponentes(actual.Sucursal.IdSucursal, produ3.IdProducto, produ3.IdFormula, 0)
      '                  For Each dr4 As DataRow In _componentes2.Rows
      '                     If producto = dr4("IdProductoComponente").ToString() Then
      '                        cantidadTotal = cantidadTotal + Decimal.Parse(dr4("Cantidad").ToString()) * pro1.Cantidad
      '                     End If
      '                  Next
      '               End If
      '            Else
      '               producto = pro1.IdProducto
      '               'Sumo cantidades en productos repetidos para controlar stock
      '               'For Each pro2 As Entidades.VentaProducto In Me._ventasProductos
      '               If pro.IdProducto = producto Then
      '                  cantidadTotal = cantidadTotal + pro1.Cantidad
      '               End If
      '               'Next
      '            End If
      '         Next

      '         'Controlo la cantidad total con el stock del producto
      '         If cantidadTotal > pro.Stock And blnControlarStock Then
      '            'chequeo que ya no se haya controlado
      '            For Each rep As DataRow In ProdRepetido.Rows
      '               If pro.IdProducto = rep("ProdRepetido").ToString() Then
      '                  entro = True
      '               End If
      '            Next
      '            If entro = True Then
      '            Else
      '               dr2 = ProdRepetido.NewRow()
      '               dr2("ProdRepetido") = pro.IdProducto
      '               dr2("NombreProducto") = pro.NombreProducto
      '               ProdRepetido.Rows.Add(dr2)
      '            End If

      '         End If
      '         entro = False
      '         cantidadTotal = 0

      '         For Each dr As DataRow In ProdRepetido.Rows
      '            ProductosCadena = ProductosCadena + " - " + dr("NombreProducto").ToString()
      '            entro2 = True
      '         Next

      '      End If

      '   Next

      '   My.Application.Log.WriteEntry("FacturacionRapida.ValidarComprobante 2 " + Now.ToString("dd/MM/yyyy HH:mm:ss.fff"), TraceEventType.Verbose)

      '   If Reglas.Publicos.Facturacion.FacturarSinStock = "NOPERMITIR" And ProductosCadena <> "" Then
      '      MessageBox.Show("No se puede Facturar el Producto. No tiene suficiente Stock. " + ProductosCadena, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
      '      Return False

      '   ElseIf Reglas.Publicos.Facturacion.FacturarSinStock = "AVISARYPERMITIR" And ProductosCadena <> "" Then

      '      MessageBox.Show("Va a Facturar el Producto " + ProductosCadena + " aunque no tenga suficiente Stock.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)

      '   End If
      'End If

      '--------------------------------------------------------------------------------------------------------------
#End Region

      '-- REQ-35950.- ---------------------------------------------------------------------------------------------------------
      'If Decimal.Parse(Me.txtTotalGeneral.Text) = 0 Then
      '   MessageBox.Show("No se calcularon los totales de la operación.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
      '   Me.tbcDetalle.SelectedTab = Me.tbpProductos
      '   Me.bscCodigoProducto2.Focus()
      '   Return False
      'End If
      '------------------------------------------------------------------------------------------------------------------------
      If Me.cmbTiposComprobantes.SelectedIndex = -1 Then
         MessageBox.Show("Falta cargar el tipo de comprobante.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
         Me.cmbTiposComprobantes.Focus()
         Return False
      End If

      If Me.cmbVendedor.SelectedIndex = -1 Then
         MessageBox.Show("Falta cargar el vendedor.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
         Me.cmbVendedor.Focus()
         Return False
      End If

      If Me.cmbFormaPago.SelectedIndex = -1 Then
         MessageBox.Show("Falta cargar la forma de pago.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
         Me.cmbFormaPago.Focus()
         Return False
      End If

      My.Application.Log.WriteEntry("FacturacionRapida.ValidarComprobante 3 " + Now.ToString("dd/MM/yyyy HH:mm:ss.fff"), TraceEventType.Verbose)

      Dim rVentas As Reglas.Ventas = New Reglas.Ventas()
      rVentas.ValidaMediosPagoSegunFormaPago(cmbTiposComprobantes.ItemSeleccionado(Of Entidades.TipoComprobante),
                                             cmbFormaPago.ItemSeleccionado(Of Entidades.VentaFormaPago),
                                             txtEfectivo.Text.ValorNumericoPorDefecto(0D),
                                             txtImporteDolares.Text.ValorNumericoPorDefecto(0D),
                                             txtTickets.Text.ValorNumericoPorDefecto(0D),
                                             txtTransferenciaBancaria.Text.ValorNumericoPorDefecto(0D),
                                             _cheques,
                                             _tarjetas)

      'Si es Nota Credito o Dev. Proforma no puede aceptar cheques. Que lo arregle desde caja.
      If DirectCast(Me.cmbTiposComprobantes.SelectedItem, Entidades.TipoComprobante).CoeficienteValores <= 0 And Me.dgvCheques.RowCount > 0 Then
         MessageBox.Show("Este comprobante no esta habilitado para ingresar cheque(s).", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
         Me.cmbTiposComprobantes.Focus()
         Return False
      End If

      If DirectCast(Me.cmbTiposComprobantes.SelectedItem, Entidades.TipoComprobante).LetrasHabilitadas.Length > 1 Then
         'Valida si el comprobante esta permitido para la letra fiscal
         Dim tip As Reglas.TiposComprobantes = New Reglas.TiposComprobantes()
         If Not tip.LetraHabilitada(Me.cmbTiposComprobantes.SelectedValue.ToString(), Me.txtLetra.Text) Then
            MessageBox.Show("Este comprobante no esta habilitado para esta Letra Fiscal.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Me.cmbTiposComprobantes.Focus()
            Return False
         End If
      End If

      If Not Me.chbNumeroAutomatico.Checked And Long.Parse(Me.txtNumeroPosible.Text) <= 0 Then
         MessageBox.Show("El Numero de Comprobante digatado es Inválido.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
         Me.txtNumeroPosible.Focus()
         Return False
      End If


      'Validacion por si invoco comprobantes -------------------------------

      If Me.dgvObservaciones.RowCount > Me._cantMaxItemsObserv Then
         MessageBox.Show("No puede ingresar mas de " & Me._cantMaxItemsObserv.ToString() & " lineas de Observaciones para este tipo de comprobante.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
         Me.btnInsertarObservacion.Focus()
         Return False
      End If

      'Sumo Lineas del Comprobante + Lineas de Observaciones.

      Dim LineasDetalle As Integer = Integer.Parse(Me.dgvProductos.RowCount.ToString())

      If LineasDetalle + Me.dgvObservaciones.RowCount > Me._cantMaxItems Then
         MessageBox.Show("No puede ingresar mas de " & Me._cantMaxItems.ToString() & " lineas (Productos y Observaciones) para este tipo de comprobante." + Environment.NewLine +
                         "Cantidad de líneas del comprobante " & (LineasDetalle + Me.dgvObservaciones.RowCount).ToString(), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
         Me.btnEliminar.Focus()
         Return False
      End If

      '-------------------------------------------------------------------

      'If Publicos.ControlaLimiteDeCreditoDeClientes And Decimal.Parse(Me.txtLimiteDeCredito.Text) > 0 Then
      '   If DirectCast(Me.cmbFormaPago.SelectedItem, Entidades.VentaFormaPago).Dias > 0 Then
      '      If Decimal.Parse(Me.txtSaldoCtaCte.Text) + Decimal.Parse(Me.txtTotalGeneral.Text) > Decimal.Parse(Me.txtLimiteDeCredito.Text) Then
      '         If MessageBox.Show("ATENCION: El Cliente Superó el Límite de Crédito, ¿ Continúa ?", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) <> Windows.Forms.DialogResult.Yes Then
      '            Return False
      '         End If
      '      End If
      '   End If
      'End If

      My.Application.Log.WriteEntry("FacturacionRapida.ValidarComprobante 4 " + Now.ToString("dd/MM/yyyy HH:mm:ss.fff"), TraceEventType.Verbose)

      If Decimal.Parse(Me.txtLimiteDeCredito.Text) > 0 And
         DirectCast(Me.cmbFormaPago.SelectedItem, Entidades.VentaFormaPago).Dias > 0 AndAlso
         DirectCast(Me.cmbTiposComprobantes.SelectedItem, Entidades.TipoComprobante).ActualizaCtaCte Then

         Dim valido As Boolean? = Me.ValidarLimiteCredito(arrojarException:=False)

         If valido.HasValue Then Return valido.Value

      End If


      Dim ImporteTope As Decimal = DirectCast(Me.cmbTiposComprobantes.SelectedItem, Entidades.TipoComprobante).ImporteTope
      '-- REQ-35950.- ' If ImporteTope > 0 And Decimal.Parse(Me.txtTotalGeneral.Text) > ImporteTope Then
      If txtTotalGeneral.ValorNumericoPorDefecto(0D) > ImporteTope Then
         MessageBox.Show("El Comprobante Superó el Límite Permitido de $ " & ImporteTope.ToString("##,##0." + New String("0"c, Me._decimalesAMostrar)), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
         Me.txtTotalGeneral.Focus()
         Return False
      End If

      Dim ImporteMinimo As Decimal = DirectCast(Me.cmbTiposComprobantes.SelectedItem, Entidades.TipoComprobante).ImporteMinimo
      '-- REQ-35950.- ' If ImporteMinimo > 0 And Decimal.Parse(Me.txtTotalGeneral.Text) < ImporteMinimo Then
      If txtTotalGeneral.ValorNumericoPorDefecto(0D) < ImporteMinimo Then
         MessageBox.Show("El Comprobante No Alcanzó el Mínimo Requerido de $ " & ImporteMinimo.ToString("##,##0." + New String("0"c, Me._decimalesAMostrar)), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
         Me.txtTotalGeneral.Focus()
         Return False
      End If

      'A Raymundo cada tanto le pasa que no genera el descuento, no dan enter!
      If Decimal.Parse(Me.txtDescRecGralPorc2.Text) <> 0 And Decimal.Parse(Me.txtDescRecGral.Text) = 0 Then
         MessageBox.Show("No se calculó el Descuento/Recargo General, por favor de enter para confirmarlo.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
         Me.txtDescRecGralPorc2.Focus()
         Return False
      End If

      ''Si es Ticket Factura Valido que tenga el CUIT para que no reviente despues.
      ''Habria que hacerlo mas general!
      'If (Me.txtLetra.Text = "A" Or Me.txtLetra.Text = "C") AndAlso Me.txtNumeroPosible.Tag.ToString() = "HASAR" AndAlso DirectCast(Me.cmbTiposComprobantes.SelectedItem, Entidades.TipoComprobante).IdTipoComprobante = Publicos.IdTicketFacturaFiscal And String.IsNullOrEmpty(Me._clienteE.Cuit) Then
      '   MessageBox.Show("El Cliente NO tiene CUIT y es obligatorio para este comprobante.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
      '   Me.cmbTiposComprobantes.Focus()
      '   Return False
      'End If

      Dim CategoriaFiscalCliente As Entidades.CategoriaFiscal = New Entidades.CategoriaFiscal()
      Dim CUIT As String = String.Empty

      If Me._clienteE.EsClienteGenerico Then
         CategoriaFiscalCliente = DirectCast(Me.cmbCategoriaFiscal.SelectedItem, Entidades.CategoriaFiscal)

         Dim result As Reglas.Validaciones.ValidacionResult
         result = Reglas.Validaciones.Impositivo.ValidarIdFiscal.Instancia.Validar(New Reglas.Validaciones.Impositivo.DatosValidacionFiscal() _
                                                                                   With {.IdFiscal = txtCUIT.Text,
                                                                                         .SolicitaCUIT = CategoriaFiscalCliente.SolicitaCUIT And
                                                                                                          Me.ModoClienteProspecto = Entidades.Cliente.ModoClienteProspecto.Cliente})
         If result.Error Then
            txtCUIT.Focus()
            MessageBox.Show(result.MensajeError.ToString(), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
         Else
            CUIT = txtCUIT.Text.ToString()
         End If
      Else
         CategoriaFiscalCliente = Me._clienteE.CategoriaFiscal
         CUIT = Me._clienteE.Cuit
      End If

      If CategoriaFiscalCliente.SolicitaCUIT And String.IsNullOrEmpty(CUIT.ToString()) And
                     (DirectCast(Me.cmbTiposComprobantes.SelectedItem, Entidades.TipoComprobante).GrabaLibro Or
                     DirectCast(Me.cmbTiposComprobantes.SelectedItem, Entidades.TipoComprobante).EsPreElectronico) Then

         MessageBox.Show("ATENCION: El Cliente NO tiene CUIT y es obligatorio.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
         If Not Me._clienteE.EsClienteGenerico Then
            If MostrarMasInfo() = Windows.Forms.DialogResult.Cancel Then
               Return False
            End If
         Else
            Me.txtCUIT.Focus()
            Return False
         End If

      End If

      My.Application.Log.WriteEntry("FacturacionRapida.ValidarComprobante 5 " + Now.ToString("dd/MM/yyyy HH:mm:ss.fff"), TraceEventType.Verbose)

      'Si es Consumidor Final, vendio a partir de $1000 y no tiene DNI
      If Not CategoriaFiscalCliente.IvaDiscriminado And Not CategoriaFiscalCliente.SolicitaCUIT And CategoriaFiscalCliente.LetraFiscal <> "E" And
        Decimal.Parse(Me.txtTotalGeneral.Text.ToString()) >= Reglas.Publicos.Facturacion.FacturacionControlaTopeCF And Me._clienteE.NroDocCliente = 0 And
         DirectCast(Me.cmbTiposComprobantes.SelectedItem, Entidades.TipoComprobante).ControlaTopeConsumidorFinal Then

         'Si tiene el parametro Activo de DNI controla a Todos (Blanco, Negro, Remito, Presupuestos, etc, sino, solo lo Blanco/Electronico.
         If Reglas.Publicos.Facturacion.FacturacionControlaDNIClienteConsumidorFinal Or
            (Not Reglas.Publicos.Facturacion.FacturacionControlaDNIClienteConsumidorFinal And
            (DirectCast(Me.cmbTiposComprobantes.SelectedItem, Entidades.TipoComprobante).GrabaLibro Or
                           DirectCast(Me.cmbTiposComprobantes.SelectedItem, Entidades.TipoComprobante).EsPreElectronico)) Then

            '-- REQ-38090.- --------------------------------------------
            If CUIT <> "" Then
               'Tiene CUIT
               If ShowPregunta(String.Format("ATENCION: El Cliente es Consumidor Final y el Total de Comprobante es $ {0} o mas. El DNI es obligatorio, pero tiene CUIT desea utilizarlo?", Reglas.Publicos.Facturacion.FacturacionControlaTopeCF)) = Windows.Forms.DialogResult.Yes Then
                  Me.txtCUIT.Text = CUIT
                  Me.lblCUIT.Text = My.Resources.RTextos.Cuit
               Else

                  If Not Me._clienteE.EsClienteGenerico Then
                     If MostrarMasInfo() = Windows.Forms.DialogResult.Cancel Then
                        Return False
                     End If
                     Me.lblCUIT.Text = "Nro.Documento"

                  Else
                     Return False
                     Me.txtNroDocCliente.Focus()
                  End If
               End If
            Else
               If Not Me._clienteE.EsClienteGenerico Then
                  ShowMessage(String.Format("ATENCION: El Cliente es Consumidor Final y el Total de Comprobante es $ {0} o mas. El DNI es obligatorio.", Reglas.Publicos.Facturacion.FacturacionControlaTopeCF))
                  If MostrarMasInfo() = Windows.Forms.DialogResult.Cancel Then
                     Return False
                  End If
               Else
                  If txtNroDocCliente.ValorNumericoPorDefecto(0L) = 0 Then
                     ShowMessage(String.Format("ATENCION: El Cliente es Consumidor Final y el Total de Comprobante es $ {0} o mas. El DNI es obligatorio.", Reglas.Publicos.Facturacion.FacturacionControlaTopeCF))
                     Me.txtNroDocCliente.Focus()
                     Return False
                  End If
               End If
            End If
            '-----------------------------------------------------------
            'ShowMessage(String.Format("ATENCION: El Cliente es Consumidor Final y el Total de Comprobante es $ {0} o mas. El DNI es obligatorio.", Reglas.Publicos.Facturacion.FacturacionControlaTopeCF))
            'If MostrarMasInfo() = Windows.Forms.DialogResult.Cancel Then
            '   Return False
            'End If
            '-----------------------------------------------------------
         End If
      End If

      My.Application.Log.WriteEntry("FacturacionRapida.ValidarComprobante 6 " + Now.ToString("dd/MM/yyyy HH:mm:ss.fff"), TraceEventType.Verbose)

      '------- Permitir comprobante con fecha y numeración anterior ---------
      Dim oVN As Reglas.VentasNumeros = New Reglas.VentasNumeros()
      Dim oImpresora As Entidades.Impresora
      Dim CentroEmisor As Short

      oImpresora = New Reglas.Impresoras().GetPorSucursalPCTipoComprobante(actual.Sucursal.Id, My.Computer.Name, Me.cmbTiposComprobantes.SelectedValue.ToString())

      CentroEmisor = oImpresora.CentroEmisor

      Dim FechaComp As Date
      FechaComp = oVN.GetUltimaFecha(actual.Sucursal, Me.cmbTiposComprobantes.SelectedValue.ToString(), Me.txtLetra.Text, CentroEmisor)

      If Not Reglas.Publicos.Facturacion.PermitirComprobFechaNumAnterior And Me.dtpFecha.Value < FechaComp Then
         MessageBox.Show("No puede Grabar el Comprobante con una Fecha menor a " & FechaComp.ToString("dd/MM/yyyy"), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
         Return False
      End If

      If Decimal.Parse(Me.txtDiferencia.Text) < 0 Then
         MessageBox.Show("No puede asignar mas Pagos que el Total del Comprobante.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
         Me.tbcDetalle.SelectedTab = Me.tbpPagos
         Me.txtEfectivo.Focus()
         Return False
      End If

      If DirectCast(Me.cmbTiposComprobantes.SelectedItem, Entidades.TipoComprobante).EsFiscal Then
         'Verifico que ningun producto tenga Cantidad Negativa (Hay que hacer un control segun la Fiscal !!).
         For Each pro As Entidades.VentaProducto In Me._ventasProductos
            If pro.Cantidad < 0 Then
               MessageBox.Show("Un Comprobante FISCAL No puede tener Productos con Cantidad en Negativo.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
               Me.tbcDetalle.SelectedTab = Me.tbpProductos
               Me.bscCodigoProducto2.Focus()
               Return False
            End If
         Next
      End If

      'Verifico Descuento Máximo solo de los productos que NO permiten modificar descripcion
      'En teoria no hace falta controlar producto por producto, pero, igual lo miro por posible ajustes futuros que los precios tomen descuentos.
      Dim PorcDescTotal As Decimal = 0
      Dim PrecioLista As Decimal = 0

      My.Application.Log.WriteEntry("FacturacionRapida.ValidarComprobante 7 " + Now.ToString("dd/MM/yyyy HH:mm:ss.fff"), TraceEventType.Verbose)

      For Each pro As Entidades.VentaProducto In Me._ventasProductos

         'GAR: 27/02/2018. Agrego este control porque hubo casos en cero (hasta encontrar el origen).

         If (pro.Producto.ImporteImpuestoInterno > 0 Or pro.Producto.PorcImpuestoInterno > 0) And pro.ImporteImpuestoInterno = 0 Then
            MessageBox.Show("El Producto " & pro.NombreProducto & " se cargo con Impuesto Interno en cero pero NO es correcto. Por favor quitelo y vuelva a cargarlo.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
         End If

         '----------------------------

         If Not pro.Producto.PermiteModificarDescripcion Then

            'Si la Empresa o el Cliente es MO/CF el precio tiene IVA, pero el Precio de IVA esta sin IVA, se lo tengo que poner!
            If Not Me._clienteE.CategoriaFiscal.IvaDiscriminado Or Not Me._categoriaFiscalEmpresa.IvaDiscriminado Then
               'PrecioLista = Decimal.Round((pro.PrecioLista * (1 + (pro.AlicuotaImpuesto / 100))) + pro.ImporteImpuestoInterno, 2)
               PrecioLista = Decimal.Round(Reglas.CalculosImpositivos.ObtenerPrecioConImpuestos(pro.PrecioLista, pro.AlicuotaImpuesto,
                                                                                                pro.PorcImpuestoInterno, pro.ImporteImpuestoInterno, pro.OrigenPorcImpInt), 2)
            Else
               PrecioLista = pro.PrecioLista
            End If

            'Calculo el precio Neto contra el de Lista porque ademas pudo cambiar el precio (para arriba o abajo).
            If PrecioLista > 0 Then
               PorcDescTotal = Decimal.Round((pro.PrecioNeto / PrecioLista - 1) * 100, 2)
            Else
               PorcDescTotal = 0
            End If

            'Rechazo Si tiene configurado el precio neto, y realizo descuento (en el global) y el descuento es mayor al maximo...
            If Reglas.Publicos.Facturacion.DescuentoMaximo > 0 And PorcDescTotal < 0 And Math.Abs(PorcDescTotal) > Reglas.Publicos.Facturacion.DescuentoMaximo Then
               MessageBox.Show("ATENCION: Asignó un Descuento de " & Math.Abs(PorcDescTotal).ToString("##0.00") & "% y el Máximo es : " & Reglas.Publicos.Facturacion.DescuentoMaximo.ToString("##0.00") + " %", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
               Return False
            End If

         End If

      Next
      '-----------------------------------------------------------------------------------------------

      My.Application.Log.WriteEntry("FacturacionRapida.ValidarComprobante 8 " + Now.ToString("dd/MM/yyyy HH:mm:ss.fff"), TraceEventType.Verbose)

      'Validación IVA de Productos
      Dim prod As Entidades.Producto
      If DirectCast(Me.cmbTiposComprobantes.SelectedItem, Entidades.TipoComprobante).GrabaLibro Then
         For Each pro As Entidades.VentaProducto In Me._ventasProductos
            'prod = New Entidades.Producto()
            prod = New Reglas.Productos().GetUno(pro.IdProducto)
            If pro.AlicuotaImpuesto <> prod.Alicuota AndAlso prod.Alicuota2.HasValue AndAlso pro.AlicuotaImpuesto <> prod.Alicuota2.Value Then
               If prod.Alicuota2.HasValue AndAlso prod.Alicuota2.Value <> 0 Then
                  MessageBox.Show("ATENCION: El IVA del Producto '" & pro.Producto.IdProducto & " - " & pro.Producto.NombreProducto & "', NO Corresponde: Debe Ser " & prod.Alicuota.ToString() + " % ó " + prod.Alicuota2.Value.ToString() + " %", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
               Else
                  MessageBox.Show("ATENCION: El IVA del Producto '" & pro.Producto.IdProducto & " - " & pro.Producto.NombreProducto & "', NO Corresponde: Debe Ser " & prod.Alicuota.ToString() + " %", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
               End If
               Return False
            End If
         Next
      End If
      '-------------------------------
      My.Application.Log.WriteEntry("FacturacionRapida.ValidarComprobante 9 " + Now.ToString("dd/MM/yyyy HH:mm:ss.fff"), TraceEventType.Verbose)

      ' ''Controlo los componentes de aquellos productos que descuentan stock al facturar.
      ''If blnControlarStock Then
      ''   Dim oComponentes As Reglas.ProductosComponentes = New Reglas.ProductosComponentes()
      ''   Dim oProductos As Reglas.Productos
      ''   Dim oProducto As Entidades.Producto
      ''   Dim idListaDePrecios As Integer = 0
      ''   Dim dtComponentes As DataTable

      ''   For Each pro As Entidades.VentaProducto In Me._ventasProductos
      ''      oProductos = New Reglas.Productos()
      ''      oProducto = New Entidades.Producto()

      ''      'Busco el producto Nuevamente aunque este en la Coleccion porque pudo ajustar alguna caracterisca luego de algun hipotetico mensaje anterior.
      ''      oProducto = oProductos.GetUno(pro.IdProducto)

      ''      If oProducto.EsCompuesto And oProducto.DescontarStockComponentes Then
      ''         dtComponentes = oComponentes.GetComponentes(actual.Sucursal.IdSucursal, oProducto.IdProducto, oProducto.IdFormula, idListaDePrecios)
      ''         If dtComponentes.Rows.Count = 0 Then
      ''            MessageBox.Show("ATENCION: El Producto '" & pro.IdProducto & " - " & pro.NombreProducto & "', tiene Predeterminada una Fórmula sin Componentes. NO puede Grabar.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
      ''            Return False
      ''         End If
      ''      End If
      ''   Next
      ''End If

      If Me.bscTarBanco.Text <> "" Then
         MessageBox.Show("ATENCION: Debe insertar el pago con Tarjeta", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning)
         Me.tbcDetalle.SelectedTab = Me.tbpPagos
         Me.btnInsertarTarjeta.Focus()
         Return False
      End If

      'Acumulo la cantidad de Envases que corresponde recibir y pregunto si fueron recibidos
      Dim oProductoEnv As Entidades.Producto
      Dim oProductosEnv As Reglas.Productos
      Dim iCantidadEnvases As Integer = 0

      My.Application.Log.WriteEntry("FacturacionRapida.ValidarComprobante 10 " + Now.ToString("dd/MM/yyyy HH:mm:ss.fff"), TraceEventType.Verbose)

      For Each pro As Entidades.VentaProducto In Me._ventasProductos
         oProductosEnv = New Reglas.Productos()
         oProductoEnv = New Entidades.Producto()

         'Busco el producto Nuevamente aunque este en la Coleccion porque pudo ajustar alguna caracterisca luego de algun hipotetico mensaje anterior.
         oProductoEnv = oProductosEnv.GetUno(pro.IdProducto)
         If oProductoEnv.SolicitaEnvase Then
            iCantidadEnvases = iCantidadEnvases + CInt(pro.Cantidad)
         End If
      Next
      If iCantidadEnvases > 0 Then
         If MessageBox.Show("ATENCION: Ha Recibido " & iCantidadEnvases.ToString & " envases?", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) <> Windows.Forms.DialogResult.Yes Then
            Return False
         End If
      End If

      If Not DirectCast(Me.cmbTiposComprobantes.SelectedItem, Entidades.TipoComprobante).GrabaLibro AndAlso _tarjetas.Count > 0 Then
         If MessageBox.Show("ATENCION: Esta seguro de asignar Tarjetas como forma de pago a: " & Me.cmbTiposComprobantes.Text.ToString(), Me.Text, MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation) = Windows.Forms.DialogResult.Cancel Then
            Return False
         End If
      End If

      My.Application.Log.WriteEntry("FacturacionRapida.ValidarComprobante FINALIZA " + Now.ToString("dd/MM/yyyy HH:mm:ss.fff"), TraceEventType.Verbose)
      Return True
   End Function

   Private Function EsComprobanteFiscal() As Boolean
      Return DirectCast(Me.cmbTiposComprobantes.SelectedItem, Entidades.TipoComprobante).EsFiscal
   End Function

   Private Sub GrabarComprobante()

      My.Application.Log.WriteEntry("FacturacionRapida.GrabarComprobante INICIA " + Now.ToString("dd/MM/yyyy HH:mm:ss.fff"), TraceEventType.Verbose)

      'Le quito el Foco al campo que lo tenga, porque podria ser uno de valor (pesos, transferencia) y que no haya dado enter.
      Me.bscCodigoProducto2.Focus()

      Me.CalcularPagos(False)

      My.Application.Log.WriteEntry("FacturacionRapida.GrabarComprobante - Antes de ValidarComprobante " + Now.ToString("dd/MM/yyyy HH:mm:ss.fff"), TraceEventType.Verbose)
      If Me.ValidarComprobante() Then

         Me.tsbGrabar.Enabled = False

         If Me.tbcDetalle.Contains(Me.tbpPagos) Then
            Me.tbcDetalle.SelectedTab = Me.tbpPagos
         End If

         Dim oFacturacion As Reglas.Ventas = New Reglas.Ventas()
         Dim oVentas As New Entidades.Venta

         My.Application.Log.WriteEntry("FacturacionRapida.GrabarComprobante - Inicia preparación de Venta " + Now.ToString("dd/MM/yyyy HH:mm:ss.fff"), TraceEventType.Verbose)

         With oVentas
            'cargo el comprobante
            .TipoComprobante = DirectCast(Me.cmbTiposComprobantes.SelectedItem, Entidades.TipoComprobante)

            'cargo el cliente ----------
            .Cliente = Me._clienteE

            If Not Me._clienteE.EsClienteGenerico Then
               .NombreCliente = Me.bscCliente.Text
            Else
               .NombreCliente = Me.txtNombreClienteGenerico.Text
            End If

            'cargo la direccion elegida (ACA NO Esta hecho el Multiple Direcciones)
            'If Integer.Parse(Me.cmbDirecciones.SelectedValue.ToString()) = 0 Then
            .Direccion = .Cliente.Direccion
            .IdLocalidad = .Cliente.IdLocalidad
            'Else
            '   Dim Direcciones As DataTable = New Reglas.ClientesDirecciones().GetDireccionCliente(.Cliente.IdCliente, Integer.Parse(cmbDirecciones.SelectedValue.ToString()))
            '   .Direccion = Direcciones.Rows(0).Item("Direccion").ToString()
            '   .IdLocalidad = Integer.Parse(Direcciones.Rows(0).Item("IdLocalidad").ToString())
            'End If

            'cargo la Categoria Fiscal (porque puede necesitar cambiarse para una operatoria puntual.
            .CategoriaFiscal = DirectCast(Me.cmbCategoriaFiscal.SelectedItem, Entidades.CategoriaFiscal)

            .LetraComprobante = Me.txtLetra.Text

            If Not Me.chbNumeroAutomatico.Checked Or (.TipoComprobante.EsFiscal And Not .TipoComprobante.GrabaLibro) Then
               .NumeroComprobante = Long.Parse(Me.txtNumeroPosible.Text)
            End If

            'cargo datos generales del comprobante
            .IdSucursal = actual.Sucursal.Id
            .Usuario = actual.Nombre

            'Pudo levantar la pantalla y grabar despues. Vuelvo a asignarlo para que tome la hora.
            If Me.dtpFecha.Value.Date = New Reglas.Generales().GetServerDBFechaHora.Date Then
               Me.dtpFecha.Value = New Reglas.Generales().GetServerDBFechaHora
            End If
            .Fecha = Me.dtpFecha.Value

            If Me.cmbVendedor.SelectedIndex <> -1 Then
               .Vendedor = DirectCast(Me.cmbVendedor.SelectedItem, Entidades.Empleado)
            End If

            If Me.cmbFormaPago.SelectedIndex <> -1 Then
               .FormaPago = DirectCast(Me.cmbFormaPago.SelectedItem, Entidades.VentaFormaPago)
            End If

            .Observacion = String.Empty

            .VentasImpuestos = Me._subTotales
            .ImpuestosVarios = Me._fc.ImpuestosVarios

            'cargo valores del comprobante
            .ImporteBruto = Decimal.Parse(Me.txtTotalBruto.Text)
            .DescuentoRecargo = Decimal.Parse(Me.txtDescRecGral.Text)
            .DescuentoRecargoPorc = Decimal.Parse(Me.txtDescRecGralPorc2.Text)
            .DescuentoRecargoPorcManual = Me.chbModificaDescRecGralPorc.Checked '# Registro si el descuento fué aplicado de forma automática o no.
            .Subtotal = Decimal.Parse(Me.txtTotalNeto.Text)
            .TotalImpuestos = Decimal.Parse(Me.txtTotalImpuestos.Text) + Decimal.Parse(Me.txtTotalPercepcion.Text)
            .ImporteTotal = Decimal.Parse(Me.txtTotalGeneral.Text)

            .Kilos = Decimal.Parse(Me.txtKilos.Text)

            'cargo la impresora
            '.Impresora = New Reglas.Impresoras().GetPorSucursalPC(actual.Sucursal.Id, My.Computer.Name, Me.EsComprobanteFiscal())
            .Impresora = New Reglas.Impresoras().GetPorSucursalPCTipoComprobante(actual.Sucursal.Id, My.Computer.Name, .TipoComprobante.IdTipoComprobante)

            'cargo los productos
            .VentasProductos = Me._ventasProductos

            'Cargo los Comprobantes Facturados (tal vez ninguno)
            .Invocados.Add(Me._comprobantesSeleccionados)
            '.Facturables = Me._comprobantesSeleccionados

            .IdEstadoComprobante = ""
            '.CantidadInvocados = 0

            'cargo el Remito Transportista
            .Bultos = 0
            .ValorDeclarado = 0
            .Transportista = Me._transportistaA
            .NumeroLote = 0

            'cargo las Observaciones
            .VentasObservaciones = Me._ventasObservaciones

            If oVentas.TipoComprobante.AfectaCaja Or oVentas.TipoComprobante.EsPreElectronico Then
               'controlo el pago que se realiza si no va a la cuenta corriente
               If oVentas.FormaPago.Dias = 0 Then
                  If Decimal.Parse(Me.txtTotalPago.Text) = 0 Then
                     If Decimal.Parse(Me.txtDiferencia.Text) <> 0 Then
                        If Reglas.Publicos.Facturacion.FacturacionContadoEsEnPesos Then
                           Dim fPago = cmbFormaPago.ItemSeleccionado(Of Entidades.VentaFormaPago)
                           Dim medio = "pesos"
                           Dim ctaBancaria = New Reglas.CuentasBancarias().GetUna(fPago.IdCuentaBancariaEfectivo.IfNull(-1), Reglas.Base.AccionesSiNoExisteRegistro.Nulo)
                           If fPago.IdCuentaBancariaEfectivo.HasValue Then
                              medio = String.Format("transferencia a la cuenta {0}", ctaBancaria.NombreCuenta)
                           End If
                           If ShowPregunta(String.Format("¿El pago se realizara totalmente como {0}?", medio)) = Windows.Forms.DialogResult.No Then
                              tbcDetalle.SelectedTab = tbpPagos
                              txtEfectivo.Select()
                              Exit Sub
                           Else
                              If fPago.IdCuentaBancariaEfectivo.HasValue Then
                                 txtTransferenciaBancaria.Text = txtTotalGeneral.Text
                                 bscCodigoCuentaBancariaTransfBanc.Text = fPago.IdCuentaBancariaEfectivo.Value.ToString()
                                 bscCodigoCuentaBancariaTransfBanc.Visible = True
                                 bscCodigoCuentaBancariaTransfBanc.PresionarBoton()
                                 bscCodigoCuentaBancariaTransfBanc.Visible = False
                              Else
                                 txtEfectivo.Text = txtTotalGeneral.Text
                              End If
                           End If
                        Else
                           tbcDetalle.SelectedTab = tbpPagos
                           txtEfectivo.Select()
                           Exit Sub
                        End If
                        '   If Not Reglas.Publicos.Facturacion.FacturacionContadoEsEnPesos AndAlso MessageBox.Show("El pago se realizara totalmente en pesos?", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.No Then
                        '      Me.tbpPagos.Focus()
                        '      Me.txtEfectivo.Focus()
                        '      Exit Sub
                        '   Else
                        '      Me.txtEfectivo.Text = Me.txtTotalGeneral.Text
                        '   End If
                     End If
                  Else
                     'si puso algo en pagos, se debe controlar que la diferencia este en cero
                     If Decimal.Parse(Me.txtDiferencia.Text) <> 0 Then
                        Me.tbpPagos.Focus()
                        Me.txtEfectivo.Focus()
                        Throw New Exception("El pago debe ser igual al total del comprobante.")
                     End If
                  End If
               End If
            Else

               'Asigno la diferencia porque puedo poner cheques o tarjetas.
               'las PRE-Facturas NO afectan Caja pero cargar los pagos cuando es Contado.

               'si puso algo en pagos, se debe controlar que la diferencia este en cero
               If Decimal.Parse(Me.txtDiferencia.Text) <> Decimal.Parse(Me.txtTotalGeneral.Text) And Decimal.Parse(Me.txtDiferencia.Text) <> 0 Then
                  Me.tbpPagos.Focus()
                  Me.txtEfectivo.Focus()
                  Throw New Exception("El pago debe ser igual al total del comprobante.")
               End If

               If oVentas.FormaPago.Dias = 0 Then
                  If Decimal.Parse(Me.txtEfectivo.Text) > 0 And Decimal.Parse(Me.txtDiferencia.Text) <> 0 Then
                     '   Me.txtEfectivo.Text = Me.txtEfectivo.Text
                     'Else
                     Me.txtEfectivo.Text = Me.txtTotalGeneral.Text
                  End If
               End If

            End If

            'carga los importes de pagos y cheques
            .Cheques = Me._cheques
            .Tarjetas = Me._tarjetas
            .ImportePesos = Decimal.Parse(Me.txtEfectivo.Text)
            .ImporteDolares = txtImporteDolares.ValorNumericoPorDefecto(0D)
            '.ImporteTarjetas = Decimal.Parse(Me.txtTarjetas.Text)
            .ImporteTickets = Decimal.Parse(Me.txtTickets.Text)

            If txtTransferenciaBancaria.ValorNumericoPorDefecto(0D) > 0 And bscCuentaBancariaTransfBanc.Selecciono Then
               .ImporteTransfBancaria = txtTransferenciaBancaria.ValorNumericoPorDefecto(0D)
               .CuentaBancariaTransfBanc = New Reglas.CuentasBancarias().GetUna(Integer.Parse(bscCuentaBancariaTransfBanc.Tag.ToString())) ''._filaDevuelta.Cells("IdCuentaBancaria").Value.ToString()))
               .FechaTransferencia = Me.dtpFechaTransferencia.Value
            End If
            If _transferencias.AnySecure() Then
               .FechaTransferencia = dtpFechaTransferencia.Value
            End If

            .Transferencias = _transferencias

            'carga los cheques rechazados
            .ChequesRechazados = Me._chequesRechazados

            'Informe los Productos que tuvieron Lotes.
            .CantidadLotes = 0   'Me.ProductosConLote()    ---- Luego le cargo el correcto segun la seleccion de lotes.

            'cargo los Lotes
            .VentasProductosLotes = Me._productosLotes

            'Cargo la utilidad
            .Utilidad = Decimal.Parse(Me.txtSemaforoRentabilidad.Key)

            .CotizacionDolar = Decimal.Parse(Me.txtCotizacionDolar.Text)

            .ComisionVendedor = 0  'Se calcula despues

            'grabo la caja
            .IdCaja = Integer.Parse(Me.cmbCajas.SelectedValue.ToString())

            .IdCategoria = .Cliente.IdCategoria

            '-- REQ-31371.- ------------------------------------------------------
            .Cuit = txtCUIT.Text
            .TipoDocCliente = cmbTipoDoc.Text
            If String.IsNullOrEmpty(txtNroDocCliente.Text.ToString()) Then
               .NroDocCliente = 0
            Else
               .NroDocCliente = Long.Parse(txtNroDocCliente.Text.ToString())
            End If
            '---------------------------------------------------------------------

            If .TipoComprobante.AfectaCaja And .FormaPago.Dias = 0 Then
               Dim oCaja As Reglas.CajasNombres = New Reglas.CajasNombres()
               Dim caja As Entidades.CajaNombre = New Entidades.CajaNombre()
               Dim oCajas As Reglas.Cajas = New Reglas.Cajas()
               Dim saldoCaja As Decimal

               Dim oPlanilla As Entidades.Caja = oCajas.GetPlanillaActual(.IdSucursal, .IdCaja)
               saldoCaja = oCajas.GetSaldoPesosFinal(.IdSucursal, .IdCaja, oPlanilla.NumeroPlanilla) + oCajas.GetSaldoChequesFinal(.IdSucursal, .IdCaja, oPlanilla.NumeroPlanilla)
               Dim totalCaja As Decimal = saldoCaja + Decimal.Parse(txtEfectivo.Text) + Decimal.Parse(txtCheques.Text) +
                                          (txtImporteDolares.ValorNumericoPorDefecto(0D) * txtCotizacionDolar.ValorNumericoPorDefecto(0D))
               caja = oCaja.GetUna(.IdSucursal, .IdCaja)

               If caja.TopeAviso > 0 And totalCaja >= caja.TopeAviso And totalCaja < caja.TopeBloqueo Then
                  MessageBox.Show("Superó el Limite Recomendado de " & caja.TopeAviso.ToString("##,##0.00") & ", y está por llegar al Límite Permitido en Caja de " & caja.TopeBloqueo.ToString("##,##0.00"), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
               ElseIf caja.TopeBloqueo > 0 And totalCaja >= caja.TopeBloqueo Then
                  ShowMessage("Llegó al Límite Permitido en Caja de " & caja.TopeBloqueo.ToString("N2") & ". No podrá registrar el próximo comprobante.")
               End If
            End If

         End With

         'Si el tipo de pago es cuenta corriente tengo que levantar la pantalla de Cuenta Corriente
         If oVentas.TipoComprobante.ActualizaCtaCte Then
            If oVentas.FormaPago.Dias > 0 Then
               'si el cliente compro el modulo de cuenta corriente
               If Reglas.Publicos.TieneModuloCuentaCorrienteClientes Then
                  If Not Reglas.Publicos.CtaCte.UtilizaCuotasVencimientoCtaCteClientes Then

                     If MessageBox.Show("Confirma enviar el Comprobante a Cuenta Corriente?", Me.Text, MessageBoxButtons.YesNo) <> Windows.Forms.DialogResult.Yes Then
                        'Me.tsbGrabar.Enabled = True
                        Exit Sub
                     End If

                     Dim oCCP As Entidades.CuentaCorrientePago
                     oCCP = New Entidades.CuentaCorrientePago()
                     oCCP.ImporteCuota = oVentas.ImporteTotal
                     oCCP.SaldoCuota = oCCP.ImporteCuota
                     oCCP.FechaVencimiento = Me.dtpFecha.Value.AddDays(oVentas.FormaPago.Dias)
                     oVentas.CuentaCorriente.Pagos.Add(oCCP)

                  Else

                     Dim cc As CuentaCorriente = New CuentaCorriente(Me.dtpFecha.Value, oVentas.ImporteTotal, oVentas.FormaPago.IdFormasPago)
                     If cc.ShowDialog() = Windows.Forms.DialogResult.OK Then
                        'recuperar los datos para armar la cuenta corriente
                        Dim oCCP As Entidades.CuentaCorrientePago
                        For Each dr As DataRow In cc.Pagos.Rows
                           oCCP = New Entidades.CuentaCorrientePago()
                           oCCP.ImporteCuota = Decimal.Parse(dr("MontoAPagar").ToString())
                           oCCP.SaldoCuota = oCCP.ImporteCuota
                           oCCP.FechaVencimiento = Date.Parse(dr("FechaAPagar").ToString())
                           oVentas.CuentaCorriente.Pagos.Add(oCCP)
                        Next
                     Else
                        'Me.tsbGrabar.Enabled = True
                        Throw New Exception("Debe ingresar la forma de pago para poder grabar e imprimir.")
                     End If

                  End If

               End If
            End If
         End If

         Dim TextoGrabacion As String = "impreso y grabado."

         'si voy a imprimir en una impresora fiscal, primero imprimo y despues obtengo el nro. de comprobante
         'en otro caso, grabo y despues imprimo

         'Para borrar el Invocado solo si viene de Facturacion Rapida, se borra dentro de la transaccion Insertar
         If oVentas.Invocados.Count > 0 Then
            oVentas.ReemplazaComprobante = True
         End If

         'Solo Fiscales LEGALES envio antes de grabar, los demas grabo primero.
         If Me.EsComprobanteFiscal() And oVentas.TipoComprobante.GrabaLibro Then
            If Me._fc.ImprimirComprobante(oVentas, Me.EsComprobanteFiscal()) Then
               Try
                  oFacturacion.Insertar(oVentas, Eniac.Entidades.Entidad.MetodoGrabacion.Manual, Me.IdFuncion)
               Catch ex As Reglas.Ventas.ActualizaCAEException
                  Dim stbMensaje = New StringBuilder(ex.Message)
                  stbMensaje.AppendLine().AppendLine().AppendFormat("¿Desea reintentar el envio del comprobante {0}?", oVentas.PkToString)
                  If ShowPregunta(stbMensaje.ToString(), MessageBoxDefaultButton.Button1) = DialogResult.Yes Then
                     Try
                        Dim rVentas = New Reglas.Ventas()
                        rVentas.ActualizarCAE(oVentas, Entidades.AFIPCAE.Secuencia.SegundaVez, Entidades.Entidad.MetodoGrabacion.Manual, IdFuncion)
                     Catch ex1 As Reglas.Ventas.ActualizaCAEException
                        ShowError(ex1)
                     End Try
                  Else
                     ShowMessage("No se realizó el reenvio del comprobante. Verifique en Solicitar CAE.")
                  End If
               Catch
                  Throw
               End Try
            Else
               Throw New Exception("Error en la impresión Fiscal")
            End If

         Else

            My.Application.Log.WriteEntry("FacturacionRapida.GrabarComprobante - Grabo Comprobante en BD " + Now.ToString("dd/MM/yyyy HH:mm:ss.fff"), TraceEventType.Verbose)

            Try
               oFacturacion.Insertar(oVentas, Eniac.Entidades.Entidad.MetodoGrabacion.Manual, Me.IdFuncion)
            Catch ex As Reglas.Ventas.ActualizaCAEException
               Dim stbMensaje = New StringBuilder(ex.Message)
               stbMensaje.AppendLine().AppendLine().AppendFormat("¿Desea reintentar el envio del comprobante {0}?", oVentas.PkToString)
               If ShowPregunta(stbMensaje.ToString(), MessageBoxDefaultButton.Button1) = DialogResult.Yes Then
                  Try
                     Dim rVentas = New Reglas.Ventas()
                     rVentas.ActualizarCAE(oVentas, Entidades.AFIPCAE.Secuencia.SegundaVez, Entidades.Entidad.MetodoGrabacion.Manual, IdFuncion)
                  Catch ex1 As Reglas.Ventas.ActualizaCAEException
                     ShowError(ex1)
                  End Try
               Else
                  ShowMessage("No se realizó el reenvio del comprobante. Verifique en Solicitar CAE.")
               End If
            Catch
               Throw
            End Try
            'Solo Fiscales LEGALES envio antes de grabar, los demas grabo primero.
            If Me.EsComprobanteFiscal() And oVentas.TipoComprobante.EsPreElectronico Then

               If Reglas.Publicos.Facturacion.Impresion.FacturacionImpresionFiscalSincronica Then

                  My.Application.Log.WriteEntry("FacturacionRapida.GrabarComprobante - Convierto Pre-Ticket en Ticket " + Now.ToString("dd/MM/yyyy HH:mm:ss.fff"), TraceEventType.Verbose)
                  '''''Armo la entidad TICKET FISCAL
                  Dim ComprobanteFiscal As Entidades.Venta = oFacturacion.ArmarComprobanteFiscal(oVentas)
                  '''''Conservo pre TICKET

                  Try
                     My.Application.Log.WriteEntry("FacturacionRapida.GrabarComprobante - Comienzo Imprimir Ticket " + Now.ToString("dd/MM/yyyy HH:mm:ss.fff"), TraceEventType.Verbose)
                     If Me._fc.ImprimirComprobante(ComprobanteFiscal, Me.EsComprobanteFiscal()) Then
                        Try
                           'Guardo numero de comprobante por si falla la grabacion del TICKET
                           oFacturacion.ActualizaNumeroComprobanteFiscal(oVentas.IdSucursal, oVentas.TipoComprobante.IdTipoComprobante,
                                                               oVentas.LetraComprobante, oVentas.Impresora.CentroEmisor,
                                                               oVentas.NumeroComprobante, ComprobanteFiscal.NumeroComprobante)

                           My.Application.Log.WriteEntry("FacturacionRapida.GrabarComprobante - Grabo Nuevo Ticket " + Now.ToString("dd/MM/yyyy HH:mm:ss.fff"), TraceEventType.Verbose)
                           '''''Si la impresion fue ok grabo el TICKET FISCAL
                           oFacturacion.GrabarComprobanteFiscal(oVentas, ComprobanteFiscal, Entidades.Entidad.MetodoGrabacion.Manual, Me.IdFuncion)

                        Catch ex As Reglas.Ventas.ActualizaCAEException
                           MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        Catch
                           MessageBox.Show("Error en la grabación del comprobante, por favor ir a pantalla Impresion Tickets Fiscales.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        End Try
                     End If
                     My.Application.Log.WriteEntry("FacturacionRapida.GrabarComprobante - Finalizo Imprimir Ticket " + Now.ToString("dd/MM/yyyy HH:mm:ss.fff"), TraceEventType.Verbose)
                  Catch ex As Exception
                     Dim stb As StringBuilder = New StringBuilder()
                     stb.AppendLine("Error en la impresión Fiscal.")
                     ArmaErrorRecursivo(ex, stb)

                     ShowMessage(stb.ToString())

                     'stb.AppendLine().Append("¿Desea reintentar?")
                     'If ShowPregunta(stb.ToString()) = Windows.Forms.DialogResult.Yes Then

                     '   Using IFR As ImpresionFiscalReintentar = New ImpresionFiscalReintentar(oVentas, ComprobanteFiscal, Me.EsComprobanteFiscal())
                     '      IFR.IdFuncion = IdFuncion
                     '      IFR.ShowDialog()
                     '   End Using

                     'Else
                     '   MessageBox.Show("Error en la impresión Fiscal, imprimir comprobante desde la Pantalla Impresión Ticket Fiscal.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning)
                     'End If
                  End Try
               Else
                  ' MessageBox.Show("Imprimir comprobante de la Pantalla Impresion Tickets Fiscales.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning)
               End If
            Else

               ''Elimino el comprobante invocado-----------------
               'If Me._comprobantesSeleccionados IsNot Nothing Then
               '    For Each ent As Entidades.Venta In Me._comprobantesSeleccionados
               '        ent.IdCaja = Integer.Parse(Me.cmbCajas.SelectedValue.ToString())
               '        ent.Usuario = actual.Nombre
               '        oFacturacion.AnularComprobante(ent)
               '    Next
               'End If

               Dim msg As System.Text.StringBuilder = New System.Text.StringBuilder()
               msg.AppendFormat("{0} Nro. {1}", oVentas.TipoComprobante.Descripcion, oVentas.NumeroComprobante.ToString()).AppendLine()
               msg.AppendFormat("de {0}", Me.bscCliente.Text).AppendLine()

               If oVentas.TipoComprobante.EsElectronico Then
                  If Not String.IsNullOrEmpty(oVentas.AFIPCAE.CAE) Then
                     msg.AppendFormat("CAE {0} con vencimiento {1} ", oVentas.AFIPCAE.CAE, oVentas.AFIPCAE.CAEVencimiento.ToString("dd/MM/yyyy")).AppendLine()
                  End If
               End If


               'Abrir la gaveta de la caja con comprobante no fiscal
               If Reglas.Publicos.Facturacion.Rapida.FacturacionRapidaAbrirCajaComprobanteNoFiscal AndAlso Not Environment.Is64BitOperatingSystem Then
                  Try
                     Dim ImpFiscal As Entidades.Impresora = New Entidades.Impresora()

                     ImpFiscal = New Reglas.Impresoras().GetPorSucursalPC(actual.Sucursal.Id, My.Computer.Name, True)

                     If ImpFiscal.Marca = "HASAR" Then
                        Dim objHasar As New FiscalHASAR(ImpFiscal.Puerto.Replace("COM", ""), ImpFiscal.Velocidad, Entidades.Publicos.CarpetaEniac)
                        objHasar.AbrirCajon()
                     ElseIf ImpFiscal.Marca = "EPSON" Then
                        Dim _ArchivoEntrada As String = Entidades.Publicos.CarpetaEniac + "Envio.txt"
                        Dim _ArchivoSalida As String = Entidades.Publicos.CarpetaEniac + "Salida.txt"
                        Dim objEpson As New FiscalEPSON(_ArchivoEntrada, _ArchivoSalida, Nothing)
                        objEpson.AbrirCajon(ImpFiscal.Puerto)
                     End If

                     '' ''Dim ModeloFiscal As LibreriaFiscal.ControladorFiscal.ModelosFiscales
                     '' ''Select Case True
                     '' ''   Case ImpFiscal.Modelo = "SMH/P-330F"
                     '' ''      ModeloFiscal = LibreriaFiscal.ControladorFiscal.ModelosFiscales.HASAR_330

                     '' ''   Case ImpFiscal.Modelo = "SMH/P-441F"
                     '' ''      ModeloFiscal = LibreriaFiscal.ControladorFiscal.ModelosFiscales.HASAR_441

                     '' ''   Case ImpFiscal.Modelo = "SMH/P-715F"
                     '' ''      ModeloFiscal = LibreriaFiscal.ControladorFiscal.ModelosFiscales.HASAR_715

                     '' ''   Case ImpFiscal.Modelo = "SMH/P-715Fv1"
                     '' ''      ModeloFiscal = LibreriaFiscal.ControladorFiscal.ModelosFiscales.HASAR_715_VER1

                     '' ''   Case (ImpFiscal.Modelo = "TM-U220AF" Or ImpFiscal.Modelo = "TM-U220AFII")
                     '' ''      ModeloFiscal = LibreriaFiscal.ControladorFiscal.ModelosFiscales.EPSON_220

                     '' ''   Case (ImpFiscal.Modelo = "TM-U2000AF" Or ImpFiscal.Modelo = "TM-U2000AF+" Or ImpFiscal.Modelo = "TM-U2002AF+")
                     '' ''      ModeloFiscal = LibreriaFiscal.ControladorFiscal.ModelosFiscales.EPSON_2002

                     '' ''   Case ImpFiscal.Modelo = "TM-U950F"
                     '' ''      ModeloFiscal = LibreriaFiscal.ControladorFiscal.ModelosFiscales.EPSON_950

                     '' ''   Case ImpFiscal.Modelo = "LX-300F+"
                     '' ''      ModeloFiscal = LibreriaFiscal.ControladorFiscal.ModelosFiscales.EPSON_LX300

                     '' ''   Case Else
                     '' ''      Throw New Exception("ATENCION: El modelo " & ImpFiscal.Modelo & " NO se encuentra Habilitado , " & Chr(13) & Chr(13) & "NO podrá Continuar, por favor comuniquese con SISTEMAS.")
                     '' ''      Exit Sub
                     '' ''End Select

                     ' '' ''GAR: 11/05/2016 - Quedaba el vinculo a la fiscal abriendo la caja solo una vez.
                     ' '' ''Me._controladorFiscal = LibreriaFiscal.ControladorFiscal.CrearInstancia(ModeloFiscal)
                     ' '' ''Me._controladorFiscal.Comenzar(ImpFiscal.Puerto, LibreriaFiscal.ControladorFiscal.ModosTrabajoLibreria.SINCRONO)
                     ' '' ''Me._controladorFiscal.AbrirGaveta()
                     ' '' ''Me._controladorFiscal.Finalizar()

                     '' ''With LibreriaFiscal.ControladorFiscal.CrearInstancia(ModeloFiscal)
                     '' ''   .Comenzar(ImpFiscal.Puerto, LibreriaFiscal.ControladorFiscal.ModosTrabajoLibreria.SINCRONO)
                     '' ''   .AbrirGaveta()
                     '' ''   .Finalizar()
                     '' ''End With

                  Catch ex As Exception
                     MessageBox.Show("Hubo problemas al abrir la caja registradora" + ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                  End Try
               End If


               Try
                  'verifica si el tipo de comprobante se puede imprimir, sino no hace nada
                  If Me.ImprimeComprobante() Then
                     Me._fc.ImprimirComprobante(oVentas, Me.EsComprobanteFiscal())
                  Else
                     TextoGrabacion = "grabado."
                  End If
               Catch ex As Exception
                  MessageBox.Show("Hubo problemas al imprimir. - " + ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
               End Try

               Try
                  Dim facturacionimprimeReciboVentasCtaCte = Reglas.Publicos.Facturacion.Impresion.FacturacionimprimeReciboVentasCtaCte
                  If facturacionimprimeReciboVentasCtaCte Then
                     Dim recibo = New Reglas.CuentasCorrientes().GetRecibosDelComprobante(oVentas).FirstOrDefault()
                     If recibo IsNot Nothing AndAlso recibo.TipoComprobante.Imprime Then
                        Dim recImp = New RecibosImprimir()
                        recImp.ImprimirRecibo(recibo, Reglas.Publicos.CtaCte.VisualizaReciboDeCliente)
                     End If
                  End If
               Catch ex As Exception
                  'si da error en la impresión solo muestra el mensaje y sigue para borrar la pantalla.
                  'sino no borraba la pantalla y era como que no se grababa la factura, mientras que si se graba
                  ShowError(ex)
               End Try

            End If
         End If

         If oVentas.TipoComprobante.AfectaCaja And oVentas.FormaPago.Dias = 0 Then

            Dim OfreceCalcularVuelto As String = Reglas.Publicos.Facturacion.FacturacionOfreceCalcularVuelto

            Dim NombreCliente As String = String.Empty
            If _clienteE.EsClienteGenerico Then
               NombreCliente = txtNombreClienteGenerico.Text
            Else
               NombreCliente = bscCliente.Text
            End If

            If OfreceCalcularVuelto <> "NOOFRECER" Then

               If OfreceCalcularVuelto = "OFRECER" Then

                  If MessageBox.Show(oVentas.TipoComprobante.Descripcion & " Numero " & oVentas.NumeroComprobante.ToString() & " del Cliente '" & NombreCliente & "' fue " & TextoGrabacion & Convert.ToChar(Keys.Enter) & Convert.ToChar(Keys.Enter) & "¿ Desea Calcular el Vuelto ?", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.Yes Then
                     Dim oFactCalcularVuelto As FacturacionCalcularVuelto
                     oFactCalcularVuelto = New FacturacionCalcularVuelto(oVentas.ImportePesos)
                     oFactCalcularVuelto.ShowDialog()
                  End If

               Else

                  Dim oFactCalcularVuelto As FacturacionCalcularVuelto
                  oFactCalcularVuelto = New FacturacionCalcularVuelto(oVentas.ImportePesos)
                  oFactCalcularVuelto.ShowDialog()

               End If

            Else

               MessageBox.Show(oVentas.TipoComprobante.Descripcion & " Nro. " & oVentas.NumeroComprobante.ToString() & Convert.ToChar(Keys.Enter) & " de " & NombreCliente & Convert.ToChar(Keys.Enter) & " fue " & TextoGrabacion, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)

            End If

         End If

         Me.Nuevo(Publicos.FacturacionMantieneElCliente, Publicos.FacturacionMantieneElComprobante)

      End If

      My.Application.Log.WriteEntry("FacturacionRapida.GrabarComprobante FINALIZA " + Now.ToString("dd/MM/yyyy HH:mm:ss.fff"), TraceEventType.Verbose)

   End Sub

   Private Function ImprimeComprobante() As Boolean
      If Me._presionoElShift Then
         Return False
      End If
      'Return DirectCast(Me.cmbTiposComprobantes.SelectedItem, Entidades.TipoComprobante).Imprime
      Return Me._imprime
   End Function

   Private Sub SeteaDetalles()
      Me._ventasProductos = New System.Collections.Generic.List(Of Entidades.VentaProducto)()
      Me._subTotales = New System.Collections.Generic.List(Of Entidades.VentaImpuesto)()
      Me._ventasObservaciones = New List(Of Entidades.VentaObservacion)()
      Me._cheques = New List(Of Entidades.Cheque)()
      Me._tarjetas = New List(Of Entidades.VentaTarjeta)()
      Me._chequesRechazados = New List(Of Entidades.Cheque)()
      Me._productosLotes = New List(Of Entidades.VentaProductoLote)()
      Me._productosNrosSeries = New List(Of Entidades.ProductoNroSerie)()
   End Sub

   Private Sub CalcularTotalProducto()
      If Not IsNumeric(Me.txtCantidad.Text) Then
         Me.txtCantidad.Text = (1).ToString(_formatoEnCantidad)
      End If
      Me.txtTotalProducto.Text = (((Decimal.Parse(Me.txtPrecio.Text) * Decimal.Parse(Me.txtCantidad.Text))) + Decimal.Parse(Me.txtDescRec.Text)).ToString("##,##0." + New String("0"c, Me._decimalesAMostrar))
   End Sub

   Private Sub LimpiarCamposProductos()
      _ordenProducto = 0

      Me._nroOferta = Nothing
      Me.bscCodigoProducto2.Enabled = True
      Me.bscCodigoProducto2.Text = ""
      Me.bscCodigoProducto2.FilaDevuelta = Nothing
      Me.bscProducto2.Enabled = True
      Me.bscProducto2.Text = ""
      Me.bscProducto2.FilaDevuelta = Nothing
      Me.txtPrecio.Text = _ceroDecimalesAMostrar
      Me.txtStock.Text = "0"
      Me.txtStock.Tag = False
      Me.txtCantidad.Text = (1).ToString(_formatoEnCantidad)
      Me.txtTotalProducto.Text = _ceroDecimalesAMostrar
      Me.txtTamanio.Text = _ceroDecimalesAMostrar
      Me.txtUM.Text = ""
      Me.txtDescRecPorc1.Text = _ceroDecimalesEnDescRec
      Me.txtDescRecPorc2.Text = _ceroDecimalesEnDescRec
      Me.txtPrecioMostrar.Text = _ceroDecimalesEnDescRec

      MuestraImpuestosInternos(0, 0)

      '--REQ-35489.- -------------------------
      txtAtributo01.Text = String.Empty
      txtAtributo02.Text = String.Empty
      '---------------------------------------

      If Reglas.Publicos.Facturacion.FacturacionDescuentosAgrupaCantidadesPorRubro Then
         Dim calculaDescuentoRecargo2 As Boolean = Not Reglas.Publicos.Facturacion.FacturacionDescuentoRecargo2CargaManual
         For Each vpo As Entidades.VentaProducto In _ventasProductos
            '_txtCantidad_prev = Nothing
            Dim cantidad As Decimal = Decimal.Parse(Me.txtCantidad.Text.ToString())

            For Each vp As Entidades.VentaProducto In _ventasProductos
               If vp.Producto.IdRubro = vpo.Producto.IdRubro Then
                  cantidad += vp.Cantidad
               End If
            Next

            Me._DescuentosRecargosProd = New Reglas.Ventas().DescuentoRecargoSoloCantidadAgrupadaRubro(_clienteE, vpo.Producto, cantidad, Me._decimalesAMostrar)

            For Each vp As Entidades.VentaProducto In _ventasProductos
               If vp.Producto.IdRubro = vpo.Producto.IdRubro Then
                  vp.DescuentoRecargoPorc1 = _DescuentosRecargosProd.DescuentoRecargo1
                  If calculaDescuentoRecargo2 Then
                     vp.DescuentoRecargoPorc2 = _DescuentosRecargosProd.DescuentoRecargo2
                  End If
               End If
               vp.DescuentoRecargo = CalculaDescuentosProductos(vp.Precio, vp.ImporteImpuestoInterno / vp.Cantidad,
                                                                vp.DescuentoRecargoPorc1, vp.DescuentoRecargoPorc2, vp.Cantidad)
            Next
         Next
         'RecalcularTodo()
      End If

      pnlEsOferta.Visible = False

      SetearDescuentosPorCantidad(Nothing)
   End Sub

   Private Sub LimpiarCamposObservDetalles()
      Me.txtObservacionDetalle.Text = ""
   End Sub

   Private Sub CalcularTotales()

      Dim bruto As Decimal = 0
      Dim descuento As Decimal = 0
      Dim subTotal As Decimal = 0
      Dim iva As Decimal = 0
      Dim impInt As Decimal = 0
      Dim total As Decimal = 0
      Dim totalGeneral As Decimal = 0
      Dim Kilos As Decimal = 0
      Dim percepcionIVA As Decimal = 0
      Dim percepcionIB As Decimal = 0
      Dim percepcionGanancias As Decimal = 0
      Dim percepcionVarias As Decimal = 0
      Dim percepcionTotal As Decimal = 0
      Dim CantItems As Integer = 0

      'If Me.dgvProductos.Rows.Count > 0 Then

      Dim tipoComp = cmbTiposComprobantes.ItemSeleccionado(Of Entidades.TipoComprobante)
      If tipoComp Is Nothing Then Exit Sub

      Dim totalKilosItems As Reglas.Ventas.TotalKilosItems = New Reglas.Ventas().CalculaTotalKilosItems(_ventasProductos)
      Kilos = totalKilosItems.TotalKilos
      CantItems = totalKilosItems.TotalProductos

      'For Each vp As Entidades.VentaProducto In Me._ventasProductos

      '   Kilos += vp.Kilos

      '   'Si NO tiene decimales lo sumo, sino solo sumo 1, pensando en productos con kilos (carnes, fiambres, clavos, etc).
      '   If Decimal.ToInt32(vp.Cantidad) = vp.Cantidad Then
      '      CantItems += Decimal.ToInt32(vp.Cantidad)
      '   Else
      '      CantItems += 1
      '   End If

      'Next

      For Each vi As Entidades.VentaImpuesto In Me._subTotales
         bruto += vi.Bruto
         subTotal += vi.Neto
         If vi.TipoImpuesto.IdTipoImpuesto = Entidades.TipoImpuesto.Tipos.IMINT Then
            impInt += vi.Importe
         Else
            iva += vi.Importe
         End If
         total += vi.Total
      Next

      Dim entPercIVA = _fc.CalculaPercepcionesIVA(_clienteE, tipoComp, _categoriaFiscalEmpresa, _ventasProductos, _comprobantesSeleccionados)
      txtPercepcionIVA.SetValor(entPercIVA.Sum(Function(x) x.Monto))
      ugPercepcionIVA.DataSource = entPercIVA
      AjustarColumnasGrilla(ugPercepcionIVA, _titPercepcionesIVA)

      percepcionIVA = Decimal.Parse(Me.txtPercepcionIVA.Text)
      percepcionIB = Decimal.Parse(Me.txtPercepcionIIBB.Text)
      percepcionGanancias = Decimal.Parse(Me.txtPercepcionGanancias.Text)
      percepcionVarias = Decimal.Parse(Me.txtPercepcionVarias.Text)

      percepcionTotal = percepcionIVA + percepcionIB + percepcionGanancias + percepcionVarias

      totalGeneral = total + percepcionTotal

      'End If

      txtTotalPercepcion.Text = percepcionTotal.ToString("#,##0." + New String("0"c, Me._decimalesAMostrar))
      txtTotalBruto.Text = bruto.ToString("#,##0." + New String("0"c, Me._decimalesAMostrar))
      txtDescRecGral.Text = (subTotal - bruto).ToString("#,##0." + New String("0"c, Me._decimalesAMostrar))
      txtTotalNeto.Text = subTotal.ToString("#,##0." + New String("0"c, Me._decimalesAMostrar))
      txtTotalSubtotales.Text = totalGeneral.ToString("#,##0." + New String("0"c, Me._decimalesAMostrar))
      txtTotalImpuestos.Text = iva.ToString("#,##0." + New String("0"c, Me._decimalesAMostrar))
      txtTotalImpuestosInternos.Text = impInt.ToString("##,##0." + New String("0"c, Me._decimalesAMostrar))
      txtTotalGeneral.Text = totalGeneral.ToString("#,##0." + New String("0"c, Me._decimalesAMostrar))

      CalcularDiferenciaDePago()

      txtKilos.Text = Kilos.ToString("#,##0.000")

      'TODO: 5329/2023
      _fc.CargarRetenciones(entPercIVA,
                            {New Entidades.PercepcionVentaCalculo()}.ToList(),
                            txtPercepcionGanancias.ValorNumericoPorDefecto(0D),
                            txtPercepcionVarias.ValorNumericoPorDefecto(0D))

      txtCantidadProductos.Text = "Cant. Productos: " + CantItems.ToString()
      txtCantidadItems.Text = "Items: " + Me._ventasProductos.Count.ToString()

      If Me.dgvProductos.Rows.Count > 0 Then
         Me.cmbCategoriaFiscal.Enabled = False
      ElseIf Me.cmbTiposComprobantes.SelectedItem IsNot Nothing And Me.cmbCategoriaFiscal.SelectedItem IsNot Nothing Then
         'NO permito cambiar la Categoria Fiscal si es en Blanco. @@@@
         If _clienteE IsNot Nothing Then
            If Not Me._clienteE.EsClienteGenerico Then
               Me.cmbCategoriaFiscal.Enabled = Not tipoComp.GrabaLibro
            End If
         End If
      End If

   End Sub

   Private Sub CargarDatosCliente(dr As DataGridViewRow)

      bscCliente.Text = dr.Cells("NombreCliente").Value.ToString()
      txtNombreClienteGenerico.Text = bscCliente.Text
      bscCodigoCliente.Text = dr.Cells("CodigoCliente").Value.ToString().Trim()
      bscCodigoCliente.Tag = dr.Cells("IdCliente").Value.ToString()
      'Me.txtDireccion.Text = dr.Cells("Direccion").Value.ToString()
      'Me.txtLocalidad.Text = dr.Cells("NombreLocalidad").Value.ToString()

      Dim rCliente As Reglas.Clientes = New Reglas.Clientes()
      Me._clienteE = rCliente.GetUno(Long.Parse(Me.bscCodigoCliente.Tag.ToString()))

      If IsNumeric(dr.Cells("ColorEstadoCliente").Value) Then
         Dim colorEstado As Color = Color.FromArgb(Integer.Parse(dr.Cells("ColorEstadoCliente").Value.ToString()))
         bscCliente.PermitidoNoBackColor = colorEstado
         bscCodigoCliente.PermitidoNoBackColor = colorEstado

         bscCliente.PermitidoSiBackColor = colorEstado
         bscCodigoCliente.PermitidoSiBackColor = colorEstado
      Else
         bscCliente.ReseteaPermitidoNoBackColor()
         bscCodigoCliente.ReseteaPermitidoNoBackColor()
         bscCliente.ReseteaPermitidoSiBackColor()
         bscCodigoCliente.ReseteaPermitidoSiBackColor()
      End If

      If Reglas.Publicos.Facturacion.Rapida.PermiteModificarClienteFacturacionRapida Then
         bscCliente.Permitido = True
         bscCodigoCliente.Permitido = True
      Else
         bscCliente.Permitido = False
         bscCodigoCliente.Permitido = False
      End If

      Me.txtLimiteDeCredito.Text = dr.Cells("LimiteDeCredito").Value.ToString()

      Me._IdCategoriaFiscalOriginal = Short.Parse(dr.Cells("IdCategoriaFiscal").Value.ToString())

      Me.cmbCategoriaFiscal.SelectedValue = dr.Cells("IdCategoriaFiscal").Value

      FacturacionAyudantes.SetLetraParaComprobante(txtLetra, cmbTiposComprobantes, cmbCategoriaFiscal)
      ''Si es X es remito y siempre debe tener esa letra
      'If Me.txtLetra.Text = "" Or Me.txtLetra.Text = "A" Or Me.txtLetra.Text = "B" Or Me.txtLetra.Text = "C" Or Me.txtLetra.Text = "E" Then
      '   Me.txtLetra.Text = dr.Cells("LetraFiscal").Value.ToString()
      'Else
      '   'despues de limpiar los campos reviso si el comprobante tiene letra X para setearlo como tal
      '   If DirectCast(Me.cmbTiposComprobantes.SelectedItem, Entidades.TipoComprobante).LetrasHabilitadas = "X" Then
      '      Me.txtLetra.Text = "X"
      '   End If
      'End If

      Me.tbcDetalle.Enabled = True
      Dim Vend As Reglas.Empleados = New Reglas.Empleados()
      If _solicitaVendedorPorDefecto AndAlso _vendedorPorDefecto IsNot Nothing Then
         Me.cmbVendedor.SelectedItem = Me.GetVendedorCombo(_vendedorPorDefecto.IdEmpleado)
      Else
         Me.cmbVendedor.SelectedItem = Me.GetVendedorCombo(Integer.Parse(dr.Cells("IdVendedor").Value.ToString()))
      End If

      'Asigno al SelectedValue porque la numeracion de las listas, no necesamiente es correlativa y da error.
      cmbListaDePrecios.SelectedValue = Integer.Parse(dr.Cells("IdListaPrecios").Value.ToString())
      '-- Guarda Valor en el Tag.---
      cmbListaDePrecios.Tag = Integer.Parse(dr.Cells("IdListaPrecios").Value.ToString())


      'If Me._clienteE.CategoriaFiscal.SolicitaCUIT Then
      '   Me.txtCUIT.Text = dr.Cells("CUIT").Value.ToString()
      '   Me.lblCUIT.Text = My.Resources.RTextos.Cuit
      'Else
      '   Me.cmbTipoDoc.Text = dr.Cells("TipoDocCliente").Value.ToString()
      '   Me.txtCUIT.Text = dr.Cells("NroDocCliente").Value.ToString()
      '   Me.lblCUIT.Text = "Nro Documento"
      'End If

      If _clienteE.CategoriaFiscal.SolicitaCUIT Then
         lblCUIT.Text = My.Resources.RTextos.Cuit
         cmbTipoDoc.Visible = False
         txtNroDocCliente.Visible = False
         lblTipoDocumento.Visible = False
         txtCUIT.Visible = True
         txtCUIT.ReadOnly = True
         lblCUIT.Text = My.Resources.RTextos.Cuit
         txtNroDocCliente.Text = String.Empty
      Else
         cmbTipoDoc.Visible = True
         cmbTipoDoc.Enabled = False
         txtNroDocCliente.Visible = True
         txtNroDocCliente.ReadOnly = True
         lblTipoDocumento.Visible = True
         txtCUIT.Text = String.Empty
         txtCUIT.Visible = False
         lblCUIT.Text = "Nro Documento"
      End If
      '-- REQ-31371.- ------------------------------------------------------
      txtCUIT.Text = dr.Cells("CUIT").Value.ToString()
      If String.IsNullOrEmpty(dr.Cells("NroDocCliente").Value.ToString()) Then
         cmbTipoDoc.Text = Reglas.Publicos.TipoDocumentoCliente()
         txtNroDocCliente.Text = "0"
      Else
         cmbTipoDoc.Text = dr.Cells("TipoDocCliente").Value.ToString()
         txtNroDocCliente.Text = dr.Cells("NroDocCliente").Value.ToString()
      End If
      '---------------------------------------------------------------------


      If Me._clienteE.IdTipoComprobante <> "" Then
         Me.cmbTiposComprobantes.SelectedIndex = -1 ' # Fuerzo la entrada al evento
         Me.cmbTiposComprobantes.SelectedValue = Me._clienteE.IdTipoComprobante
         If Me.cmbTiposComprobantes.SelectedIndex = -1 And Me.cmbTiposComprobantes.Items.Count > 0 Then
            Me.cmbTiposComprobantes.SelectedIndex = 0
         End If
      End If

      '# Vuelvo a validar la entidad del cliente por si no se permitió seguir por Falta de Crédito(evento de cambio de comprobante)
      If _clienteE Is Nothing Then Exit Sub

      If Me._clienteE.IdFormasPago > 0 Then
         Me.cmbFormaPago.SelectedValue = Me._clienteE.IdFormasPago
         If Me.cmbFormaPago.SelectedIndex = -1 And Me.cmbFormaPago.Items.Count > 0 Then
            Me.cmbFormaPago.SelectedIndex = 0
         End If
      End If

      If Me.cmbTiposComprobantes.Items.Count > 0 AndAlso Not DirectCast(Me.cmbTiposComprobantes.SelectedItem, Entidades.TipoComprobante).GrabaLibro Then
         If Publicos.FacturacionGrabaLibroNoFuerzaConsFinal And Not DirectCast(Me.cmbTiposComprobantes.SelectedItem, Entidades.TipoComprobante).EsPreElectronico Then
            Me.cmbCategoriaFiscal.SelectedValue = Short.Parse("1")      'No deberia ser Fijo 1.
         End If
      End If

      'NO corresponde. Elije la caja al ingresar y debe mantenerla.
      'If Me._clienteE.IdCaja > 0 Then
      '   Me.cmbCajas.SelectedValue = Me._clienteE.IdCaja
      '   If Me.cmbCajas.SelectedIndex = -1 And Me.cmbCajas.Items.Count > 0 Then
      '      Me.cmbCajas.SelectedIndex = 0
      '   End If
      'End If

      Me.CambiarEstadoControlesDetalle(True)

      'Se calcula el descuento/recargo gral del Cliente
      '# Solo si el tilde de modificar manualmente el Desc/Rec no está tildado
      If Not Me.chbModificaDescRecGralPorc.Checked Then
         _cantLineas = _ventasProductos.Count
         Me._DescRecGralPorc = CalculosDescuentosRecargos1.DescuentoRecargo(_clienteE,
                                                                    cmbTiposComprobantes.ItemSeleccionado(Of Entidades.TipoComprobante),
                                                                    cmbFormaPago.ItemSeleccionado(Of Entidades.VentaFormaPago),
                                                                    _cantLineas)
         Me.txtDescRecGralPorc2.Text = _DescRecGralPorc.ToString("N" + _decimalesEnDescRec.ToString())
      End If

      'Me.cmbCategoriaFiscal.Enabled = False
      Me.CargarProximoNumero()

      Me.CargarSaldosCtaCte()
      Me.ValidarDiasDeVencimiento()

      'NO permito cambiar la Categoria Fiscal si es en Blanco. @@@@
      Me.cmbCategoriaFiscal.Enabled = Not DirectCast(Me.cmbTiposComprobantes.SelectedItem, Entidades.TipoComprobante).GrabaLibro

      'controlo los focos y si tengo que solicitar el vendedor y el tipo de comprobante
      NavegacionDesdeClienteSegunParametros()

      ''Si es Ticket Factura Valido que tenga el CUIT para que no reviente despues.
      ''Habria que hacerlo mas general!
      'If (Me.txtLetra.Text = "A" Or Me.txtLetra.Text = "C") AndAlso Me.txtNumeroPosible.Tag.ToString() = "HASAR" AndAlso DirectCast(Me.cmbTiposComprobantes.SelectedItem, Entidades.TipoComprobante).IdTipoComprobante = Publicos.IdTicketFacturaFiscal And String.IsNullOrEmpty(Me._clienteE.Cuit) Then
      '   MessageBox.Show("El Cliente NO tiene CUIT y es obligatorio para este comprobante.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
      '   'Me.cmbTiposComprobantes.SelectedIndex = -1
      '   'Me.cmbTiposComprobantes.Focus()
      '   Me.Nuevo(False, False)
      '   Exit Sub
      'End If

      'controlo CUIT segun categoria fiscal 
      If Me.cmbTiposComprobantes.SelectedIndex >= 0 AndAlso Me._clienteE.CategoriaFiscal.SolicitaCUIT AndAlso String.IsNullOrEmpty(Me._clienteE.Cuit.ToString()) AndAlso
                                 (DirectCast(Me.cmbTiposComprobantes.SelectedItem, Entidades.TipoComprobante).GrabaLibro Or
                                 DirectCast(Me.cmbTiposComprobantes.SelectedItem, Entidades.TipoComprobante).EsPreElectronico) Then

         MessageBox.Show("ATENCION: El Cliente NO tiene CUIT y es obligatorio.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
         If MostrarMasInfo() = Windows.Forms.DialogResult.Cancel Then
            Me.Nuevo(False, False)
         End If

      End If
      CargaTipoComprobanteProducto()

      If Me._clienteE.EsClienteGenerico Then
         Me.bscCliente.Visible = False
         Me.txtNombreClienteGenerico.Visible = True
         If Me._clienteE.CategoriaFiscal.SolicitaCUIT Then
            Me.txtCUIT.ReadOnly = False
         Else
            Me.txtCUIT.Visible = False
            Me.txtNroDocCliente.Visible = True
            Me.cmbTipoDoc.Enabled = True
            Me.txtNroDocCliente.ReadOnly = False
            Me.cmbTipoDoc.Visible = True
            Me.cmbTipoDoc.Text = Reglas.Publicos.TipoDocumentoCliente
            Me.lblTipoDocumento.Visible = True
         End If
         Me.txtCUIT.ReadOnly = False
         Me.txtNombreClienteGenerico.Focus()
         '  Me.cmbCategoriaFiscal.Visible = True
         '  Me.cmbCategoriaFiscal.SelectedValue = Me._Proveedor.CategoriaFiscal.IdCategoriaFiscal
         '  Me.txtCategoriaFiscal.Visible = False
      Else
         Me.txtNombreClienteGenerico.Visible = False
         Me.bscCliente.Visible = True
         Me.txtCUIT.ReadOnly = True
         Me.txtNroDocCliente.ReadOnly = True
         Me.cmbTipoDoc.Enabled = False
      End If

      _ultimaCategoriaFiscalSeleccionada = _clienteE.CategoriaFiscal

      Me.txtCotizacionDolar.Text = New Reglas.Monedas().GetUna(2).FactorConversion.ToString("N2")

      If _clienteE IsNot Nothing AndAlso _clienteE.VarPesosCotizDolar <> 0 Then
         Me.txtCotizacionDolar.Text = (Decimal.Parse(Me.txtCotizacionDolar.Text()) + Decimal.Parse(_clienteE.VarPesosCotizDolar.ToString())).ToString("N2")
      End If

   End Sub

   Private Sub CargarSaldosCtaCte()

      Dim oCtaCteDet As Reglas.CuentasCorrientesPagos = New Reglas.CuentasCorrientesPagos

      Dim dt As DataTable

      dt = oCtaCteDet.GetSaldosCtaCte(Nothing, Long.Parse(Me.bscCodigoCliente.Tag.ToString()), Nothing, 0)

      Me.txtSaldoCtaCte.Text = _ceroDecimalesAMostrar
      'Me.txtSaldoCtaCteVencido.Text = "0.00"

      If dt.Rows.Count = 1 Then
         If Reglas.Publicos.Facturacion.FacturacionSaldoCtaCteIncluyeCh3ros Then
            Me.txtSaldoCtaCte.Text = (Decimal.Parse(dt.Rows(0)("Saldo").ToString()) + Decimal.Parse("0" & dt.Rows(0)("IMPORTE2").ToString())).ToString("N2")
         Else
            Me.txtSaldoCtaCte.Text = Decimal.Parse(dt.Rows(0)("Saldo").ToString()).ToString("N2")
         End If

         'If Not String.IsNullOrEmpty(dt.Rows(0)("SaldoVencido").ToString()) Then
         '   Me.txtSaldoCtaCteVencido.Text = Decimal.Parse(dt.Rows(0)("SaldoVencido").ToString()).ToString("##,##0.00")
         'End If
      End If

      'If Publicos.ControlaLimiteDeCreditoDeClientes And Decimal.Parse(Me.txtLimiteDeCredito.Text) > 0 Then
      '   If Decimal.Parse(Me.txtSaldoCtaCte.Text) > Decimal.Parse(Me.txtLimiteDeCredito.Text) Then
      '      If MessageBox.Show("ATENCION: El Cliente Superó el Límite de Crédito, ¿ Continúa ?", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) <> Windows.Forms.DialogResult.Yes Then
      '         Throw New Exception("El Comprobante fué Cancelado por Falta de Crédito.")
      '      End If
      '   End If
      'End If

      If Decimal.Parse(Me.txtLimiteDeCredito.Text) > 0 And
         DirectCast(Me.cmbFormaPago.SelectedItem, Entidades.VentaFormaPago).Dias > 0 AndAlso
         DirectCast(Me.cmbTiposComprobantes.SelectedItem, Entidades.TipoComprobante).ActualizaCtaCte Then

         Me.ValidarLimiteCredito(arrojarException:=True)

      End If

      '# Color de semáforo SALDOS
      Me.SetearColorSemaforos(txtSaldoCtaCte, Entidades.SemaforoVentaUtilidad.TiposSemaforos.SALDOS)

   End Sub

   Private _enNuevo As Boolean
   Private Sub Nuevo(mantieneElCliente As Boolean, mantieneElComprobante As Boolean)
      _enNuevo = True
      Try
         tsbGrabar.Enabled = False
         _estado = Estados.Insercion
         'Me.Text = "Facturación"
         cmbTiposComprobantes.Enabled = True
         cmbVendedor.Enabled = True
         cmbFormaPago.Enabled = True
         txtTotalGeneral.Enabled = True
         txtDescRecGral.Enabled = True
         tbcDetalle.SelectedTab = tbpProductos
         tbcDetalle.Enabled = True
         If Not mantieneElCliente Then
            bscCodigoCliente.Text = String.Empty
            bscCodigoCliente.Selecciono = False
            bscCliente.Text = String.Empty
            bscCliente.Selecciono = False
            bscCodigoCliente.Tag = Nothing
            bscCliente.Permitido = True
            bscCodigoCliente.Permitido = True
            _clienteE = Nothing


            bscCliente.ReseteaPermitidoNoBackColor()
            bscCodigoCliente.ReseteaPermitidoNoBackColor()
            bscCliente.ReseteaPermitidoSiBackColor()
            bscCodigoCliente.ReseteaPermitidoSiBackColor()

            bscCliente.Visible = True
            txtNombreClienteGenerico.Visible = False
            txtNombreClienteGenerico.Text = String.Empty
            txtNroDocCliente.Text = String.Empty
            txtCUIT.ReadOnly = True
            txtCUIT.Visible = True
            cmbTipoDoc.Visible = False
            txtNroDocCliente.Visible = False
            lblTipoDocumento.Visible = False

         ElseIf _facturacionMantieneElClienteDefault > 0 Then
            bscCodigoCliente.Text = _facturacionMantieneElClienteDefault.ToString()
         End If

         'txtBruto.Enabled = True
         'dtpFecha.Enabled = True
         'txtObservacion.Text = String.Empty
         _ventasProductos.Clear()
         '-- REQ-34986.- ----------------------------------------
         _tit.Remove("DescripcionAtributo01")
         _tit.Remove("DescripcionAtributo02")
         _tit.Remove("DescripcionAtributo03")
         _tit.Remove("DescripcionAtributo04")
         '-------------------------------------------------------
         '-- REQ-32596.- -------------------------------------------------------------------------------
         SetProductosDataSource()
         'Me.dgvProductos.DataSource = Me._ventasProductos.ToArray()
         '----------------------------------------------------------------------------------------------

         _transferencias = New List(Of Entidades.VentaTransferencia)()
         ugTransferenciasMultiples.DataSource = _transferencias

         OrdenarGrillaProductos()
         _subTotales.Clear()
         dgvIvas.DataSource = _subTotales.ToArray()
         'Me.txtDireccion.Text = String.Empty
         'Me.txtLocalidad.Text = String.Empty
         txtLimiteDeCredito.Text = _ceroDecimalesAMostrar
         txtSaldoCtaCte.Text = _ceroDecimalesAMostrar
         'Me.txtSaldoCtaCteVencido.Text = "0.00"
         'Me.txtBruto.Text = "0.00"
         txtDescRecGralPorc2.Text = _ceroDecimalesEnDescRec
         txtDescRecGral.Text = _ceroDecimalesAMostrar
         dtpFecha.Value = New Reglas.Generales().GetServerDBFechaHora   ' Date.Now
         txtTotalGeneral.Text = _ceroDecimalesAMostrar
         txtTotalPago.Text = _ceroDecimalesAMostrar
         txtKilos.Text = "0.000"
         bscCodigoProducto2.Text = String.Empty
         bscProducto2.Text = String.Empty
         txtStock.Text = String.Empty
         txtStock.Tag = False
         txtCantidad.Text = 1.ToString(_formatoEnCantidad)
         txtPrecio.Text = _ceroDecimalesAMostrar
         txtTotalProducto.Text = _ceroDecimalesAMostrar
         txtTamanio.Text = _ceroDecimalesAMostrar
         txtUM.Text = ""
         btnInsertar.Enabled = True
         btnEliminar.Enabled = True
         txtTickets.Text = _ceroDecimalesAMostrar
         txtEfectivo.Text = _ceroDecimalesAMostrar
         txtImporteDolares.SetValor(0D)
         txtTarjetas.Text = _ceroDecimalesAMostrar
         txtCheques.Text = _ceroDecimalesAMostrar
         '-- REQ-32366.- ---------------------------------------------------------------
         txtTransferenciaBancaria.Text = _ceroDecimalesAMostrar
         bscCuentaBancariaTransfBanc.Text = String.Empty
         '------------------------------------------------------------------------------
         txtTotalBruto.Text = _ceroDecimalesAMostrar
         txtTotalNeto.Text = _ceroDecimalesAMostrar
         txtTotalSubtotales.Text = _ceroDecimalesAMostrar
         txtTotalImpuestos.Text = _ceroDecimalesAMostrar
         txtPercepcionIVA.Text = _ceroDecimalesAMostrar
         txtPercepcionIIBB.Text = _ceroDecimalesAMostrar
         txtPercepcionGanancias.Text = _ceroDecimalesAMostrar
         txtPercepcionVarias.Text = _ceroDecimalesAMostrar
         txtTotalPercepcion.Text = _ceroDecimalesAMostrar
         txtDescRecPorc1.Text = _ceroDecimalesEnDescRec
         txtDescRecPorc2.Text = _ceroDecimalesEnDescRec

         FacturacionAyudantes.SetLetraParaComprobante(txtLetra, cmbTiposComprobantes, cmbCategoriaFiscal)
         'If Me.cmbTiposComprobantes.SelectedItem IsNot Nothing AndAlso DirectCast(Me.cmbTiposComprobantes.SelectedItem, Entidades.TipoComprobante).LetrasHabilitadas = "X" Then
         '   'si la letra es X se la seteo directamente
         '   Me.txtLetra.Text = "X"
         'Else
         '   Me.txtLetra.Text = String.Empty
         'End If

         txtCUIT.Text = String.Empty
         lblCUIT.Text = My.Resources.RTextos.Cuit
         txtCUIT.Visible = True

         If _solicitaTipoComprobantePorDefecto AndAlso Not String.IsNullOrWhiteSpace(_idTipoComprobantePorDefecto) Then
            cmbTiposComprobantes.SelectedValue = _idTipoComprobantePorDefecto
         Else
            If Not mantieneElComprobante Then
               If cmbTiposComprobantes.Items.Count > 0 Then
                  cmbTiposComprobantes.SelectedIndex = -1   'Fuerzo el evento de Changed
                  cmbTiposComprobantes.SelectedIndex = 0
               Else
                  cmbTiposComprobantes.SelectedIndex = -1
               End If
            End If
         End If            'If Not String.IsNullOrWhiteSpace(_idTipoComprobantePorDefecto) Then

         If _solicitaVendedorPorDefecto AndAlso _vendedorPorDefecto IsNot Nothing Then
            cmbVendedor.SelectedItem = GetVendedorCombo(_vendedorPorDefecto.IdEmpleado)
         Else
            If Me.cmbVendedor.Items.Count > 0 Then
               Me.cmbVendedor.SelectedIndex = 0
            Else
               Me.cmbVendedor.SelectedIndex = -1
            End If
         End If            'If _solicitaVendedorPorDefecto AndAlso _vendedorPorDefecto IsNot Nothing Then

         If Me.cmbFormaPago.Items.Count > 0 Then
            Me.cmbFormaPago.SelectedIndex = 0
         Else
            Me.cmbFormaPago.SelectedIndex = -1
         End If

         cmbListaDePrecios.SelectedIndex = 0
         '-- Guarda Valor en el Tag.---
         cmbListaDePrecios.Tag = 0


         Me.txtDescRecGralPorc2.Text = _ceroDecimalesEnDescRec

         Me.txtDescRecGral.Text = _ceroDecimalesAMostrar

         'Me.txtCategoriaFiscal.Text = String.Empty
         'Me.txtCategoria.Text = String.Empty

         Me.cmbCategoriaFiscal.Enabled = True
         Me.cmbCategoriaFiscal.SelectedIndex = -1

         Me.chbNumeroAutomatico.Checked = True
         Me.chbNumeroAutomatico.Enabled = Reglas.Publicos.Facturacion.FacturacionModificaNumeroComprobante

         Me.CambiarEstadoControlesDetalle(False)

         Me._ModificaDetalle = "TODO"

         Me.txtTotalPago.Text = _ceroDecimalesAMostrar
         Me.txtDiferencia.Text = _ceroDecimalesAMostrar

         Me._cheques.Clear()
         Me.dgvCheques.DataSource = Me._cheques
         AjustarColumnasGrilla(dgvCheques, _titCheques)

         If Me.tbcDetalle.TabPages.Contains(Me.tbpFacturables) Then
            Me.tbcDetalle.TabPages.Remove(Me.tbpFacturables)
         End If

         If Me._comprobantesSeleccionados IsNot Nothing Then
            Me._comprobantesSeleccionados.Clear()
         End If

         Me.dgvFacturables.DataSource = Me._comprobantesSeleccionados


         _tarjetas.Clear()
         dgvTarjetas.DataSource = Me._tarjetas
         LimpiarCamposCheques()

         _transportistaA = Nothing

         _ventasObservaciones.Clear()
         dgvObservaciones.DataSource = _ventasObservaciones.ToArray()

         txtCantidadProductos.Text = "Cant. Productos: "
         txtCantidadItems.Text = "Items: "
         txtPrecioMostrar.Text = Me.txtTotalProducto.Text
         pcbFoto.Image = Nothing

         _numeroOrden = 0

         CargarProximoNumero()

         txtSemaforoRentabilidad.BackColor = txtLetra.BackColor
         txtSemaforoRentabilidad.ForeColor = txtLetra.ForeColor
         txtSemaforoRentabilidad.Text = ""
         txtSemaforoRentabilidad.Key = "0"

         txtSaldoCtaCte.Text = _ceroDecimalesAMostrar
         txtSaldoCtaCte.BackColor = txtLetra.BackColor
         txtSaldoCtaCte.ForeColor = txtLetra.ForeColor
         txtSaldoCtaCte.Font = New Font(Me.txtSaldoCtaCte.Font, FontStyle.Regular)

         ' If _clienteE IsNot Nothing AndAlso _clienteE.VarPesosCotizDolar <> 0 Then
         txtCotizacionDolar.Text = New Reglas.Monedas().GetUna(2).FactorConversion.ToString(_formatoDecimalesAMostrar)
         ' End If


         cmbCajas.SelectedValue = Me._idCajaPorDefecto

         If Not mantieneElCliente Then
            Me.bscCodigoCliente.Focus()
         Else
            Me.bscCodigoCliente.PresionarBoton()
         End If

         '# El Desc/Rec siempre va a venir en FALSE ya que cuando esté tildado quiere decir que el usuario aplicó un Desc/Rec Manualmente
         Me.chbModificaDescRecGralPorc.Checked = False

         _transferencias.Clear()
         ugTransferenciasMultiples.Rows.Refresh(RefreshRow.ReloadData)
         txtTransferenciaBancaria.ReadOnly = _transferencias.AnySecure()
         bscCuentaBancariaTransfBanc.Permitido = Not _transferencias.AnySecure()

      Finally
         _enNuevo = False
      End Try
   End Sub

   Private Function ValidarInsertaProducto() As Boolean

      If Me.cmbTiposComprobantes.SelectedIndex = -1 Then
         MessageBox.Show("Debe seleccionar un tipo de comprobante", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
         Me.cmbTiposComprobantes.Focus()
         Return False
      End If

      If Not ValidaCantidadDigitosCantidad() Then
         Return False
      End If

      If DirectCast(Me.cmbTiposComprobantes.SelectedItem, Entidades.TipoComprobante).GrabaLibro Then
         Dim oPF As Reglas.PeriodosFiscales = New Reglas.PeriodosFiscales()
         Dim dt As DataTable = oPF.Get1(actual.Sucursal.IdEmpresa, Integer.Parse(Me.dtpFecha.Value.ToString("yyyyMM")))
         If dt.Rows.Count = 0 Then
            MessageBox.Show("La Fecha del Comprobante pertenece a un Periodo Fiscal que aún NO esta habilitado.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Me.dtpFecha.Focus()
            Return False
         ElseIf Not String.IsNullOrEmpty(dt.Rows(0)("FechaCierre").ToString()) Then
            MessageBox.Show("La Fecha del Comprobante pertenece a un Periodo Fiscal Cerrado.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Me.dtpFecha.Focus()
            Return False
         ElseIf Not Boolean.Parse(dt.Rows(0)("VentasHabilitadas").ToString()) Then
            ShowMessage(String.Format("El Período Fiscal '{0}' no está habilitado para emitir Comprobantes de Venta.", dtpFecha.Value.ToString("yyyy/MM")))
            Me.dtpFecha.Focus()
            Return False
         End If
      End If

      Dim CategoriaFiscalCliente As Entidades.CategoriaFiscal = New Entidades.CategoriaFiscal()
      Dim CUIT As String = String.Empty

      If Me._clienteE.EsClienteGenerico Then
         CategoriaFiscalCliente = DirectCast(Me.cmbCategoriaFiscal.SelectedItem, Entidades.CategoriaFiscal)
         Dim result As Reglas.Validaciones.ValidacionResult
         result = Reglas.Validaciones.Impositivo.ValidarIdFiscal.Instancia.Validar(New Reglas.Validaciones.Impositivo.DatosValidacionFiscal() _
                                                                                   With {.IdFiscal = txtCUIT.Text,
                                                                                         .SolicitaCUIT = CategoriaFiscalCliente.SolicitaCUIT And
                                                                                                          Me.ModoClienteProspecto = Entidades.Cliente.ModoClienteProspecto.Cliente})
         If result.Error Then
            txtCUIT.Focus()
            MessageBox.Show(result.MensajeError.ToString(), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
         Else
            CUIT = txtCUIT.Text.ToString()
         End If
      Else
         CategoriaFiscalCliente = Me._clienteE.CategoriaFiscal
         CUIT = Me._clienteE.Cuit
      End If


      If CategoriaFiscalCliente.SolicitaCUIT And String.IsNullOrEmpty(CUIT.ToString()) And
                           (DirectCast(Me.cmbTiposComprobantes.SelectedItem, Entidades.TipoComprobante).GrabaLibro Or
                           DirectCast(Me.cmbTiposComprobantes.SelectedItem, Entidades.TipoComprobante).EsPreElectronico) Then

         MessageBox.Show("ATENCION: El Cliente NO tiene CUIT y es obligatorio.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
         If Not Me._clienteE.EsClienteGenerico Then
            If MostrarMasInfo() = Windows.Forms.DialogResult.Cancel Then
               Return False
            End If
         Else
            Me.txtCUIT.Focus()
            Return False
         End If
      End If


      If _ventasProductos.Count = 0 Then
         If DirectCast(Me.cmbTiposComprobantes.SelectedItem, Entidades.TipoComprobante) IsNot Nothing Then
            If DirectCast(Me.cmbTiposComprobantes.SelectedItem, Entidades.TipoComprobante).AfectaCaja And DirectCast(Me.cmbFormaPago.SelectedItem, Entidades.VentaFormaPago).Dias = 0 Then
               Dim oCaja As Reglas.CajasNombres = New Reglas.CajasNombres()
               Dim caja As Entidades.CajaNombre = New Entidades.CajaNombre()
               Dim oCajas As Reglas.Cajas = New Reglas.Cajas()
               Dim saldoCaja As Decimal

               Dim oPlanilla As Entidades.Caja = oCajas.GetPlanillaActual(actual.Sucursal.IdSucursal, Integer.Parse(Me.cmbCajas.SelectedValue.ToString()))
               saldoCaja = oCajas.GetSaldoPesosFinal(actual.Sucursal.IdSucursal, Integer.Parse(Me.cmbCajas.SelectedValue.ToString()), oPlanilla.NumeroPlanilla) + oCajas.GetSaldoChequesFinal(actual.Sucursal.IdSucursal, Integer.Parse(Me.cmbCajas.SelectedValue.ToString()), oPlanilla.NumeroPlanilla)
               Dim totalCaja As Decimal = saldoCaja + Decimal.Parse(txtEfectivo.Text) + Decimal.Parse(txtCheques.Text) +
                                          (txtImporteDolares.ValorNumericoPorDefecto(0D) * txtCotizacionDolar.ValorNumericoPorDefecto(0D))
               caja = oCaja.GetUna(actual.Sucursal.IdSucursal, Integer.Parse(Me.cmbCajas.SelectedValue.ToString()))

               If caja.TopeAviso > 0 And totalCaja >= caja.TopeAviso And totalCaja < caja.TopeBloqueo Then
                  MessageBox.Show("Superó el Limite Recomendado de " & caja.TopeAviso.ToString("N2") & ", y está por llegar al Límite Permitido en Caja de " & caja.TopeBloqueo.ToString("N2"), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
               ElseIf caja.TopeBloqueo > 0 And totalCaja >= caja.TopeBloqueo Then
                  MessageBox.Show("Llegó al Límite Permitido en Caja de " & caja.TopeBloqueo.ToString("N2"), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
                  Return False
               End If
            End If
         End If
      End If


      'Esta Habilitado si permite Modificar la Descripcion.
      If Me.bscProducto2.Enabled Then

         If Me.bscCodigoProducto2.Text.Trim.Length = 0 Then
            MessageBox.Show("No puede ingresar sin Codigo de Producto.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Me.bscCodigoProducto2.Focus()
            Return False
         End If
         If Me.bscProducto2.Text.Trim.Length = 0 Then
            MessageBox.Show("No puede ingresar sin Producto.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Me.bscProducto2.Focus()
            Return False
         End If

         If Not Me.bscCodigoProducto2.Selecciono And Not Me.bscProducto2.Selecciono And (Me.bscCodigoProducto2.Text.Trim.Length = 0 Or Me.bscProducto2.Text.Trim.Length = 0) Then
            MessageBox.Show("No eligió un Producto ó falto pulsar ENTER.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Me.bscCodigoProducto2.Focus()
            Return False
         End If

         'Significa que escribo en ambos casos y no dio enter, tiene que al menos buscar.
         If bscCodigoProducto2.FilaDevuelta Is Nothing And bscProducto2.FilaDevuelta Is Nothing Then
            MessageBox.Show("No eligió un Producto, solo los digito, falto pulsar ENTER.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Me.bscCodigoProducto2.Focus()
            Return False
         End If

      Else
         If Not Me.bscCodigoProducto2.Selecciono And Not Me.bscProducto2.Selecciono Then
            MessageBox.Show("No eligió un Producto ó falto pulsar ENTER.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Me.bscCodigoProducto2.Focus()
            Return False
         End If

         Dim PrecioNeto As Decimal = 0
         Dim descRec As Decimal = Decimal.Round((Decimal.Parse(Me.txtPrecio.Text.ToString())) * Decimal.Parse(Me.txtDescRecGralPorc2.Text.ToString()) / 100, Me._valorRedondeo)

         PrecioNeto = Decimal.Parse(Me.txtPrecio.Text.ToString()) + descRec

         Dim PorcDescTotal As Decimal = 0

         'Calculo el precio Neto contra el de Lista porque ademas pudo cambiar el precio (para arriba o abajo).
         If Decimal.Parse(Me.txtPrecio.Tag.ToString()) > 0 Then
            PorcDescTotal = Decimal.Round((PrecioNeto / Decimal.Parse(Me.txtPrecio.Tag.ToString()) - 1) * 100, 2)
         End If

         'Rechazo Si tiene configurado el precio neto, y realizo descuento (en el global) y el descuento es mayor al maximo...
         If Reglas.Publicos.Facturacion.DescuentoMaximo > 0 And PorcDescTotal < 0 And Math.Abs(PorcDescTotal) > Reglas.Publicos.Facturacion.DescuentoMaximo Then
            MessageBox.Show("ATENCION: Asignó un Descuento de " & Math.Abs(PorcDescTotal).ToString("##0.00") & "% y el Máximo es : " & Reglas.Publicos.Facturacion.DescuentoMaximo.ToString("##0.00") + " %", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Me.txtPrecio.Focus()
            Return False
         End If

      End If

      If Me.txtCantidad.Text = "" Then
         'Beep()
         MessageBox.Show("No puede ingresar sin cantidad.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
         Me.txtCantidad.Focus()
         Return False
      End If

      If Decimal.Parse(Me.txtCantidad.Text) = 0 Then
         'Beep()
         MessageBox.Show("La cantidad debe ser distinta de cero.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
         Me.txtCantidad.Focus()
         Return False
      End If

      'En txtStock.Tag guardo propiedad "AfectaStock"
      If Decimal.Parse(Me.txtCantidad.Text) <= 0 And Boolean.Parse(Me.txtStock.Tag.ToString()) And Not Reglas.Publicos.Facturacion.FacturacionPermiteCantidadNegativa Then
         MessageBox.Show("La cantidad debe ser mayor a cero.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
         Me.txtCantidad.Focus()
         Return False
      End If

      'El Nuevo control de Cantidad negativa es que no aplique mas mercaderia de la que habia cargado (incorpora Devoluciones).
      If Decimal.Parse(Me.txtCantidad.Text) < 0 And Boolean.Parse(Me.txtStock.Tag.ToString()) And Not Reglas.Publicos.Facturacion.FacturacionPermiteCantidadNegativaAcumulada Then
         Dim ent As Entidades.VentaProducto
         Dim CantResultante As Decimal = Decimal.Parse(Me.txtCantidad.Text)
         For i As Integer = 0 To Me._ventasProductos.Count - 1
            ent = Me._ventasProductos(i)
            If ent.Producto.IdProducto = Me.bscCodigoProducto2.Text Then
               CantResultante += ent.Cantidad
            End If
         Next
         '-- REQ-36082.- -----------------------------------------------------------------------------------
         'If CantResultante < 0 Then
         '   MessageBox.Show("La Cantidad Resultante (incluyendo devoluciones) NO puede ser Negativa, da " & CantResultante.ToString(), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
         '   Return False
         'End If
         '--------------------------------------------------------------------------------------------------
      End If

      If Decimal.Parse(Me.txtPrecio.Text) <= 0 And Not Reglas.Publicos.VentasConProductosEnCero Then
         If Publicos.FacturacionAvisaProductosEnCero Then
            MessageBox.Show("No puede ingresar un producto con precio cero.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
         End If
         Me.txtPrecio.Focus()
         Return False
      End If

      If Me.dgvProductos.RowCount >= Me._cantMaxItems Then
         MessageBox.Show("No puede ingresar mas de " & Me._cantMaxItems.ToString() & " lineas de Productos para este tipo de comprobante." + Environment.NewLine +
                      "Cantidad de líneas del comprobante " & dgvProductos.RowCount.ToString(), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
         Me.btnInsertar.Focus()
         Return False
      End If

      'Sumo Lineas del Comprobante + Lineas de Observaciones.
      If Me.dgvProductos.RowCount + Me.dgvObservaciones.RowCount >= Me._cantMaxItems Then
         MessageBox.Show("No puede ingresar mas de " & Me._cantMaxItems.ToString() & " lineas (Productos y Observaciones) para este tipo de comprobante." + Environment.NewLine +
                      "Cantidad de líneas del comprobante " & (dgvProductos.RowCount + dgvObservaciones.RowCount).ToString(), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
         Me.btnInsertar.Focus()
         Return False
      End If

      '*** Controlo la Facturacion Sin Stock ***

      Dim rStock As Reglas.Stock = New Reglas.Stock()
      Dim prodSinStock As Entidades.ProductosSinStock()
      prodSinStock = rStock.ControlarStockVenta(actual.Sucursal.Id, cmbTiposComprobantes.ItemSeleccionado(Of Entidades.TipoComprobante), _ventasProductos, _comprobantesSeleccionados,
                                                idProductoInsertar:=bscCodigoProducto2.Text, cantidadInsertar:=If(IsNumeric(txtCantidad.Text), Decimal.Parse(txtCantidad.Text), 0))

      If prodSinStock.Count > 0 Then
         Dim stbMensaje As StringBuilder = New StringBuilder()
         If Reglas.Publicos.Facturacion.FacturarSinStock = "NOPERMITIR" Then
            stbMensaje.AppendLine("No es posible facturar el producto porque no hay stock suficiente.")
         ElseIf Reglas.Publicos.Facturacion.FacturarSinStock = "AVISARYPERMITIR" Then
            stbMensaje.AppendLine("Va a facturar el producto aunque no tenga stock suficiente.")
         End If
         stbMensaje.AppendLine()

         For Each prodSS As Entidades.ProductosSinStock In prodSinStock
            stbMensaje.AppendFormatLine("    - {0} {1} - Cantidad: {2} - Stock: {3}", prodSS.Producto.IdProducto, prodSS.Producto.NombreProducto, prodSS.Cantidad, prodSS.Stock)
         Next

         ShowMessage(stbMensaje.ToString())

         If Reglas.Publicos.Facturacion.FacturarSinStock = "NOPERMITIR" Then
            Return False
         End If

      End If




      ' '' ''PRIMERO: Cheque si el comprobante afecta stock negativo (solo si descuenta), ó invoco (no corresponde)
      ' '' ''los valores posibles para el coeficientestock son 0, 1 y -1

      '' ''Dim blnControlarStock As Boolean = DirectCast(Me.cmbTiposComprobantes.SelectedItem, Entidades.TipoComprobante).CoeficienteStock < 0


      '' ''If blnControlarStock Then

      '' ''   Dim oProd As Reglas.Productos = New Reglas.Productos()
      '' ''   Dim prod As Entidades.Producto = New Entidades.Producto()
      '' ''   prod = oProd.GetUno(Me.bscCodigoProducto2.Text)


      '' ''   'GAR: 27/02/2018. Agrego este control porque hubo casos en cero (hasta encontrar el origen).
      '' ''   If (prod.ImporteImpuestoInterno > 0 Or prod.PorcImpuestoInterno > 0) And Decimal.Parse(Me.txtImpuestoInterno.Text) = 0 Then
      '' ''      MessageBox.Show("El Producto se cargo con Impuesto Interno en cero pero no es correcto. Por favor vuelva a seleccionarlo.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
      '' ''      Me.txtImpuestoInterno.Focus()
      '' ''      Return False
      '' ''   End If
      '' ''   '----------------------------

      '' ''   'Validacion de Stock segun Parametro
      '' ''   Dim cantidadTotal As Decimal = 0
      '' ''   Dim ProductosCadena As String = ""
      '' ''   Dim producto As String
      '' ''   Dim ProdRepetido As DataTable = New DataTable()
      '' ''   ProdRepetido.Columns.Add("ProdRepetido", System.Type.GetType("System.String"))
      '' ''   ProdRepetido.Columns.Add("NombreProducto", System.Type.GetType("System.String"))
      '' ''   Dim dr2 As DataRow
      '' ''   Dim entro As Boolean = False
      '' ''   Dim entro2 As Boolean = False

      '' ''   'busco el compuesto y comparo todo los componentes con los que estan en VentasProductos
      '' ''   Dim _Componentes As DataTable
      '' ''   Dim oProductos As Reglas.Productos
      '' ''   Dim oProducto As Entidades.Producto
      '' ''   Dim ocomponentes As Reglas.ProductosComponentes = New Reglas.ProductosComponentes()
      '' ''   Dim prodprodcomp As Entidades.ProduccionProductoComp

      '' ''   If Not prod.EsCompuesto Then


      '' ''      '1 Parte. Del Producto ingresado
      '' ''      If Decimal.Parse(Me.txtCantidad.Text) > Decimal.Parse(Me.txtStock.Text) And Boolean.Parse(Me.txtStock.Tag.ToString()) Then

      '' ''         If Reglas.Publicos.Facturacion.FacturarSinStock = "NOPERMITIR" Then
      '' ''            MessageBox.Show("No se puede Facturar el Producto. No tiene suficiente Stock.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
      '' ''            Me.txtCantidad.Focus()
      '' ''            Return False

      '' ''         ElseIf Reglas.Publicos.Facturacion.FacturarSinStock = "AVISARYPERMITIR" Then
      '' ''            MessageBox.Show("Va a Facturar el Producto aunque no tenga suficiente Stock.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
      '' ''         End If

      '' ''      End If

      '' ''      '2 Parte. Del Producto ingreso mas lo que esta en la grilla.

      '' ''      If Boolean.Parse(Me.txtStock.Tag.ToString()) And Me.dgvProductos.RowCount <> 0 Then

      '' ''         Dim cantidadTotal1 As Decimal = Decimal.Parse(Me.txtCantidad.Text)
      '' ''         producto = prod.IdProducto

      '' ''         For Each pro1 As Entidades.VentaProducto In Me._ventasProductos

      '' ''            If entro2 Then
      '' ''               Exit For
      '' ''            End If

      '' ''            Dim produ3 As Entidades.Producto = New Reglas.Productos().GetUno(pro1.IdProducto, False)

      '' ''            If produ3.EsCompuesto Then
      '' ''               If produ3.DescontarStockComponentes Then
      '' ''                  Dim _componentes2 As DataTable
      '' ''                  _componentes2 = ocomponentes.GetComponentes(actual.Sucursal.IdSucursal, produ3.IdProducto, produ3.IdFormula, 0)
      '' ''                  For Each dr4 As DataRow In _componentes2.Rows
      '' ''                     If prod.IdProducto = dr4("IdProductoComponente").ToString() Then
      '' ''                        cantidadTotal1 = cantidadTotal1 + Decimal.Parse(dr4("Cantidad").ToString()) * pro1.Cantidad
      '' ''                     End If
      '' ''                  Next

      '' ''               End If
      '' ''            Else

      '' ''               'Sumo cantidades en productos repetidos para controlar stock
      '' ''               'For Each pro2 As Entidades.VentaProducto In Me._ventasProductos
      '' ''               If pro1.IdProducto = producto Then
      '' ''                  cantidadTotal1 = cantidadTotal1 + pro1.Cantidad
      '' ''               End If
      '' ''               'Next
      '' ''            End If
      '' ''         Next

      '' ''         'Controlo la cantidad total con el stock del producto
      '' ''         If cantidadTotal1 > Decimal.Parse(Me.txtStock.Text) And blnControlarStock Then
      '' ''            'chequeo que ya no se haya controlado
      '' ''            For Each rep As DataRow In ProdRepetido.Rows
      '' ''               If prod.IdProducto = rep("ProdRepetido").ToString() Then
      '' ''                  entro = True
      '' ''               End If
      '' ''            Next
      '' ''            If entro = True Then
      '' ''            Else
      '' ''               dr2 = ProdRepetido.NewRow()
      '' ''               dr2("ProdRepetido") = prod.IdProducto
      '' ''               dr2("NombreProducto") = prod.NombreProducto
      '' ''               ProdRepetido.Rows.Add(dr2)
      '' ''            End If

      '' ''         End If
      '' ''         entro = False
      '' ''         cantidadTotal = 0

      '' ''         For Each dr As DataRow In ProdRepetido.Rows
      '' ''            ProductosCadena = ProductosCadena + " - " + dr("NombreProducto").ToString()
      '' ''            entro2 = True
      '' ''         Next

      '' ''      End If

      '' ''   Else

      '' ''      oProductos = New Reglas.Productos()
      '' ''      oProducto = New Entidades.Producto()


      '' ''      'Busco el producto Nuevamente aunque este en la Coleccion porque pudo ajustar alguna caracterisca luego de algun hipotetico mensaje anterior.
      '' ''      oProducto = oProductos.GetUno(prod.IdProducto)

      '' ''      prodprodcomp = New Entidades.ProduccionProductoComp()

      '' ''      If prod.DescontarStockComponentes Then

      '' ''         _Componentes = ocomponentes.GetComponentes(actual.Sucursal.IdSucursal, oProducto.IdProducto, oProducto.IdFormula, 0)


      '' ''         For Each dr1 As DataRow In _Componentes.Rows

      '' ''            If entro2 Then
      '' ''               Exit For
      '' ''            End If

      '' ''            cantidadTotal = Decimal.Parse(dr1("Cantidad").ToString()) * Decimal.Parse(Me.txtCantidad.Text.ToString())

      '' ''            Dim prodSuc As Entidades.ProductoSucursal = New Reglas.ProductosSucursales().GetUno(actual.Sucursal.IdSucursal, dr1("IdProductoComponente").ToString())

      '' ''            'If Me._ventasProductos.Count = 0 Then
      '' ''            '   If cantidadTotal > prodSuc.Stock Then
      '' ''            '      ProductosCadena = ProductosCadena + " - " + dr1("NombreProducto").ToString()
      '' ''            '   End If
      '' ''            'End If

      '' ''            For Each pro As Entidades.VentaProducto In Me._ventasProductos


      '' ''               Dim produ3 As Entidades.Producto = New Reglas.Productos().GetUno(pro.IdProducto, False)

      '' ''               If produ3.EsCompuesto Then
      '' ''                  If produ3.DescontarStockComponentes Then
      '' ''                     Dim _componentes2 As DataTable
      '' ''                     _componentes2 = ocomponentes.GetComponentes(actual.Sucursal.IdSucursal, produ3.IdProducto, produ3.IdFormula, 0)
      '' ''                     For Each dr4 As DataRow In _componentes2.Rows
      '' ''                        If dr1("IdProducto").ToString() = dr4("IdProducto").ToString() Then
      '' ''                           cantidadTotal = cantidadTotal + Decimal.Parse(dr4("Cantidad").ToString()) * pro.Cantidad
      '' ''                        End If
      '' ''                     Next
      '' ''                  End If


      '' ''               Else
      '' ''                  producto = pro.IdProducto
      '' ''                  'Sumo cantidades en productos repetidos para controlar stock
      '' ''                  For Each pro1 As Entidades.VentaProducto In Me._ventasProductos
      '' ''                     If pro1.IdProducto = producto Then
      '' ''                        cantidadTotal = cantidadTotal + pro1.Cantidad
      '' ''                     End If
      '' ''                  Next

      '' ''               End If
      '' ''            Next


      '' ''            'Controlo la cantidad total con el stock del producto
      '' ''            If cantidadTotal > prodSuc.Stock And blnControlarStock Then
      '' ''               'chequeo que ya no se haya controlado
      '' ''               For Each rep As DataRow In ProdRepetido.Rows
      '' ''                  If dr1("IdProductoComponente").ToString() = rep("ProdRepetido").ToString() Then
      '' ''                     entro = True
      '' ''                  End If
      '' ''               Next
      '' ''               If entro = True Then
      '' ''               Else
      '' ''                  dr2 = ProdRepetido.NewRow()
      '' ''                  dr2("ProdRepetido") = dr1("IdProductoComponente").ToString()
      '' ''                  dr2("NombreProducto") = dr1("NombreProducto").ToString()
      '' ''                  ProdRepetido.Rows.Add(dr2)
      '' ''               End If

      '' ''            End If
      '' ''            entro = False
      '' ''            cantidadTotal = 0

      '' ''            For Each dr As DataRow In ProdRepetido.Rows
      '' ''               ProductosCadena = ProductosCadena + " - " + dr("NombreProducto").ToString()
      '' ''               entro2 = True
      '' ''            Next

      '' ''            'If Reglas.Publicos.Facturacion.FacturarSinStock = "NOPERMITIR" And ProductosCadena <> "" Then
      '' ''            '   MessageBox.Show("No se puede Facturar el Producto. No tiene suficiente Stock. " + ProductosCadena, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
      '' ''            '   Return False

      '' ''            'ElseIf Reglas.Publicos.Facturacion.FacturarSinStock = "AVISARYPERMITIR" And ProductosCadena <> "" Then

      '' ''            '   MessageBox.Show("Va a Facturar el Producto " + ProductosCadena + " aunque no tenga suficiente Stock.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)

      '' ''            'End If

      '' ''         Next



      '' ''      End If



      '' ''   End If

      '' ''   If Reglas.Publicos.Facturacion.FacturarSinStock = "NOPERMITIR" And ProductosCadena <> "" Then
      '' ''      MessageBox.Show("No se puede Facturar el Producto. No tiene suficiente Stock. " + ProductosCadena, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
      '' ''      Return False

      '' ''   ElseIf Reglas.Publicos.Facturacion.FacturarSinStock = "AVISARYPERMITIR" And ProductosCadena <> "" Then

      '' ''      MessageBox.Show("Va a Facturar el Producto " + ProductosCadena + " aunque no tenga suficiente Stock.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
      '' ''   End If

      '' ''End If

      '-----------------------------------------


      ''controlo que no se repita el producto ingresado
      'Dim ent As Entidades.VentaProducto
      'For i As Integer = 0 To Me._ventasProductos.Count - 1
      '   ent = Me._ventasProductos(i)
      '   If ent.Producto = Me.bscCodigoProducto2.Text Then
      '      If MessageBox.Show("El producto ya esta ingresado en este comprobante. ¿Desea agregar la cantidad al mismo?", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Error) = Windows.Forms.DialogResult.Yes Then
      '         Me.txtCantidad.Text = (Decimal.Parse(Me.txtCantidad.Text) + ent.Cantidad).ToString("##0.00")
      '         Me.CalcularTotalProducto()
      '         Me._ventasProductos.RemoveAt(i)
      '         Return True
      '      Else
      '         Return False
      '      End If
      '   End If
      'Next

      'Si esta habilitado aunque grabe Libro de Iva significa que tiene Multiples IVAs, chequeo que sea uno de los dos.
      If Me.cmbPorcentajeIva.Enabled And (DirectCast(Me.cmbTiposComprobantes.SelectedItem, Entidades.TipoComprobante).GrabaLibro Or
                                          DirectCast(Me.cmbTiposComprobantes.SelectedItem, Entidades.TipoComprobante).GrabaLibro) Then
         Dim oProducto As Entidades.Producto = New Reglas.Productos().GetUno(Me.bscCodigoProducto2.Text.Trim())
         If Decimal.Parse(Me.cmbPorcentajeIva.Text) <> oProducto.Alicuota AndAlso oProducto.Alicuota2.HasValue AndAlso Decimal.Parse(Me.cmbPorcentajeIva.Text) <> oProducto.Alicuota2.Value Then
            MessageBox.Show("Alicuota NO habilitada para este Productos, estas son: " & oProducto.Alicuota.ToString() & " y " & oProducto.Alicuota2.Value.ToString() & ".", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Me.cmbPorcentajeIva.Focus()
            Return False
         End If
      End If


      Dim NroDocCliente As Long = 0

      If Me._clienteE.EsClienteGenerico Then
         'NroDocCliente = Long.Parse(Me.txtNroDocCliente.ToString())
         NroDocCliente = If(IsNumeric(txtNroDocCliente.Text), Long.Parse(Me.txtNroDocCliente.Text), 0)
      Else
         NroDocCliente = Me._clienteE.NroDocCliente
      End If

      If Not CategoriaFiscalCliente.IvaDiscriminado And Not CategoriaFiscalCliente.SolicitaCUIT And CategoriaFiscalCliente.LetraFiscal <> "E" _
            And (Decimal.Parse(Me.txtTotalGeneral.Text.ToString()) + (Decimal.Parse(Me.txtCantidad.Text.ToString()) * Decimal.Parse(Me.txtPrecio.Text.ToString()))) >= Reglas.Publicos.Facturacion.FacturacionControlaTopeCF And NroDocCliente = 0 Then

         If Reglas.Publicos.Facturacion.FacturacionControlaDNIClienteConsumidorFinal Or (Not Reglas.Publicos.Facturacion.FacturacionControlaDNIClienteConsumidorFinal And (DirectCast(Me.cmbTiposComprobantes.SelectedItem, Entidades.TipoComprobante).GrabaLibro Or
            DirectCast(Me.cmbTiposComprobantes.SelectedItem, Entidades.TipoComprobante).EsPreElectronico)) Then

            ShowMessage(String.Format("ATENCION: El Cliente es Consumidor Final y el Total de Comprobante es $ {0} o mas. El DNI es obligatorio.", Reglas.Publicos.Facturacion.FacturacionControlaTopeCF))
            Me.txtNroDocCliente.Focus()
            Return False
         End If

      End If

      Return True

   End Function

   Private Function ValidarInsertaObservacion() As Boolean

      If Me.dgvObservaciones.RowCount = Me._cantMaxItemsObserv Then
         MessageBox.Show("No puede ingresar mas de " & Me._cantMaxItemsObserv.ToString() & " lineas de Observaciones para este tipo de comprobante.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
         Me.btnInsertarObservacion.Focus()
         Return False
      End If

      'Sumo Lineas del Comprobante + Lineas de Observaciones.

      Dim LineasDetalle As Integer = Integer.Parse(Me.dgvProductos.RowCount.ToString())

      If LineasDetalle + Me.dgvObservaciones.RowCount >= Me._cantMaxItems Then
         MessageBox.Show("No puede ingresar mas de " & Me._cantMaxItems.ToString() & " lineas (Productos y Observaciones) para este tipo de comprobante." + Environment.NewLine +
                         "Cantidad de líneas del comprobante " & (LineasDetalle + Me.dgvObservaciones.RowCount).ToString(), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
         Me.btnInsertarObservacion.Focus()
         Return False
      End If

      Return True

   End Function

   Private Sub CargarProducto(dr As DataGridViewRow)

      Me.bscCodigoProducto2.Text = dr.Cells("IdProducto").Value.ToString.Trim()
      Me.bscCodigoProducto2.Enabled = False

      Me.bscProducto2.Text = dr.Cells("NombreProducto").Value.ToString()

      Dim valor As String = Boolean.Parse(dr.Cells("PermiteModificarDescripcion").Value.ToString()).ToString()

      Me.bscProducto2.Enabled = Reglas.Publicos.Facturacion.FacturacionModificaDescripcionProducto And Boolean.Parse(dr.Cells("PermiteModificarDescripcion").Value.ToString())

      'Dim impuestoInterno As Decimal = MuestraImpuestosInternos(Decimal.Parse(dr.Cells("ImporteImpuestoInterno").Value.ToString()))

      Me.cmbPorcentajeIva.Text = dr.Cells("Alicuota").Value.ToString()
      Me.cmbPorcentajeIva.Tag = Me.cmbPorcentajeIva.Text

      Dim Producto As Entidades.Producto = New Reglas.Productos().GetUno(dr.Cells("IdProducto").Value.ToString.Trim())

      If Producto.ImporteImpuestoInterno <> 0 Then
         ShowMessage(String.Format("El producto seleccionado {0} - {1} tiene configurado Impuesto Interno Fijo. No se podrá agregar el producto al Comprobante.", Producto.IdProducto, Producto.NombreProducto))
      End If

      '----------------------------------------------------------------------------------------------------------------------------------

      Dim PrecioPorEmbalaje As Boolean = Boolean.Parse(dr.Cells("PrecioPorEmbalaje").Value.ToString())
#Region "Comentado"
      ''''Dim PrecioVentaSinIVA As Decimal = 0
      ''''Dim PrecioVentaConIVA As Decimal = 0

      ''''PrecioVentaSinIVA = Decimal.Parse(dr.Cells("PrecioVentaSinIVA").Value.ToString())
      ''''PrecioVentaConIVA = Decimal.Parse(dr.Cells("PrecioVentaConIVA").Value.ToString())

      '''''----------------------------------------------------------------------------------------------------------------------------------

      ''''Dim oferta As Entidades.ProductoOferta = New Reglas.ProductosOfertas().GetOfertaVigente(dtpFecha.Value.Date, dr.Cells("IdProducto").Value.ToString.Trim(),
      ''''                                                                                 Reglas.Base.AccionesSiNoExisteRegistro.Nulo)

      ''''If oferta IsNot Nothing Then
      ''''   _nroOferta = oferta.IdOferta
      ''''   If Publicos.PreciosConIVA Then
      ''''      PrecioVentaConIVA = oferta.PrecioOferta
      ''''      PrecioVentaSinIVA = Reglas.CalculosImpositivos.ObtenerPrecioSinImpuestos(oferta.PrecioOferta, Producto.Alicuota,
      ''''                                                                               Producto.PorcImpuestoInterno, Producto.ImporteImpuestoInterno, Producto.OrigenPorcImpInt)
      ''''   Else
      ''''      PrecioVentaSinIVA = oferta.PrecioOferta
      ''''      PrecioVentaConIVA = Reglas.CalculosImpositivos.ObtenerPrecioConImpuestos(oferta.PrecioOferta, Producto.Alicuota,
      ''''                                                                   Producto.PorcImpuestoInterno, Producto.ImporteImpuestoInterno, Producto.OrigenPorcImpInt)
      ''''   End If
      ''''End If

      '''''----------------------------------------------------------------------------------------------------------------------------------


      ''''If PrecioPorEmbalaje Then
      ''''   PrecioVentaSinIVA = PrecioVentaSinIVA / Integer.Parse(dr.Cells("Embalaje").Value.ToString())
      ''''   PrecioVentaConIVA = PrecioVentaConIVA / Integer.Parse(dr.Cells("Embalaje").Value.ToString())
      ''''End If

      '''''Si el producto pertenece a una Marca que tiene lista de Precios especifica.. vuelvo a tomar los precios.

      ''''Dim dt As DataTable
      ''''dt = New Reglas.ClientesMarcasListasDePrecios().GetUno(Long.Parse(Me.bscCodigoCliente.Tag.ToString()), Integer.Parse(dr.Cells("IdMarca").Value.ToString()))

      ''''If dt.Rows.Count = 1 Then

      ''''   Dim IdListaDePrecio As Integer
      ''''   IdListaDePrecio = Integer.Parse(dt.Rows(0)("IdListaPrecios").ToString())

      ''''   dt = Nothing
      ''''   dt = New Reglas.Productos().GetPorCodigo(Me.bscCodigoProducto2.Text, actual.Sucursal.Id, IdListaDePrecio, "VENTAS")

      ''''   PrecioVentaSinIVA = Decimal.Parse(dt.Rows(0)("PrecioVentaSinIVA").ToString())
      ''''   PrecioVentaConIVA = Decimal.Parse(dt.Rows(0)("PrecioVentaConIVA").ToString())

      ''''End If
      '''''----------------------------------------------------------------------------------------------------------------------------------

      ''''If Integer.Parse(dr.Cells("IdMoneda").Value.ToString()) = 2 Then
      ''''   PrecioVentaSinIVA = Decimal.Round(PrecioVentaSinIVA * Decimal.Parse(Me.txtCotizacionDolar.Text), Me._valorRedondeo)
      ''''   PrecioVentaConIVA = Decimal.Round(PrecioVentaConIVA * Decimal.Parse(Me.txtCotizacionDolar.Text), Me._valorRedondeo)
      ''''End If

      '''''Si leyo el Precio de la Etiqueta lo asigno.
      ''''If Me._modalidad = Eniac.Entidades.Producto.Modalidades.PRECIO And (PrecioVentaConIVA = 0 Or Publicos.ProductoCodigoBarraPrecioRespetaEtiqueta) Then
      ''''   PrecioVentaConIVA = Me.GetPrecioModalidadPrecio()
      ''''   PrecioVentaSinIVA = Decimal.Round(PrecioVentaConIVA / (1 + Decimal.Parse(Me.cmbPorcentajeIva.Text) / 100), Me._valorRedondeo)
      ''''End If

      ''''If (Me._clienteE.CategoriaFiscal.IvaDiscriminado And Me._categoriaFiscalEmpresa.IvaDiscriminado) Or
      ''''Not Me._clienteE.CategoriaFiscal.UtilizaImpuestos Or Not Me._categoriaFiscalEmpresa.UtilizaImpuestos Then
      ''''   Me.txtPrecio.Text = PrecioVentaSinIVA.ToString("#,##0." + New String("0"c, Me._decimalesAMostrar))
      ''''   Me.txtPrecio.Tag = Me.txtPrecio.Text
      ''''Else
      ''''   'comprobante sin discrimir y precio con IVA o comprobante discriminado con precio sin IVA
      ''''   Me.txtPrecio.Text = PrecioVentaConIVA.ToString("#,##0." + New String("0"c, Me._decimalesAMostrar))
      ''''   Me.txtPrecio.Tag = Me.txtPrecio.Text
      ''''End If
#End Region

      _FormaDePago = DirectCast(Me.cmbFormaPago.SelectedItem, Eniac.Entidades.VentaFormaPago)

      Dim p = FacturacionAyudantes.GetPrecio(Decimal.Parse(dr.Cells("PrecioVentaSinIVA").Value.ToString()), Decimal.Parse(dr.Cells("PrecioVentaConIVA").Value.ToString()),
                                             Producto, _clienteE, dtpFecha.Value, _nroOferta, _categoriaFiscalEmpresa, _codigoBarrasCompleto,
                                             txtCotizacionDolar.ValorNumericoPorDefecto(0D), _modalidad, _valorRedondeo, _FormaDePago)

      txtPrecio.Text = p.ToString(_formatoDecimalesAMostrar)
      txtPrecio.Tag = txtPrecio.Text


      txtPrecio.ReadOnly = Decimal.Parse(txtPrecio.Text) <> 0
      If _modificoPrecioCodigoBarra Then
         _modificoPrecioManualmente = _modificoPrecioCodigoBarra
      Else
         _modificoPrecioManualmente = False
      End If
      _modificoPrecioCodigoBarra = False

      CalcularImpuestoInterno()


      Me.txtTamanio.Text = dr.Cells("Tamano").Value.ToString()
      Me.txtUM.Text = dr.Cells("IdUnidadDeMedida").Value.ToString()
      'Me.txtCantidad.Text = "1.00"

      '---------------------------------------------------------------------------

      'Exento sin IVA. 
      If Me.cmbTiposComprobantes.SelectedIndex <> -1 Then
         If Not Me._clienteE.CategoriaFiscal.UtilizaImpuestos Or
               Not Me._categoriaFiscalEmpresa.UtilizaImpuestos Or
               Not DirectCast(Me.cmbTiposComprobantes.SelectedItem, Entidades.TipoComprobante).UtilizaImpuestos Then
            Me.cmbPorcentajeIva.Text = _ceroDecimalesAMostrar
            Me.cmbPorcentajeIva.Tag = Me.cmbPorcentajeIva.Text
         End If
      End If

      Me._productoLoteTemporal = New Entidades.VentaProductoLote()
      Me._productoLoteTemporal.Producto = Producto 'New Reglas.Productos().GetUno(dr.Cells("IdProducto").Value.ToString().Trim())

      'Se calculan los descuentos correspondientes al Cliente/Producto/Cantidad
      '-------------------------------------------------------------------------
      Dim calculaDescuentoRecargo2 As Boolean = Not Reglas.Publicos.Facturacion.FacturacionDescuentoRecargo2CargaManual


      If Reglas.Publicos.Facturacion.FacturacionDescuentosAgrupaCantidadesPorRubro Then
         Dim cantidad As Decimal = Decimal.Parse(Me.txtCantidad.Text.ToString())

         For Each vp As Entidades.VentaProducto In Me._ventasProductos
            If vp.Producto.IdRubro = Producto.IdRubro Then
               cantidad += vp.Cantidad
            End If
         Next

         Me._DescuentosRecargosProd = New Reglas.Ventas().DescuentoRecargoSoloCantidadAgrupadaRubro(_clienteE, Producto, cantidad, Me._decimalesAMostrar)

         For Each vp As Entidades.VentaProducto In Me._ventasProductos
            If vp.Producto.IdRubro = Producto.IdRubro Then
               vp.DescuentoRecargoPorc1 = _DescuentosRecargosProd.DescuentoRecargo1
               If calculaDescuentoRecargo2 Then
                  vp.DescuentoRecargoPorc2 = _DescuentosRecargosProd.DescuentoRecargo2
               End If
            End If
            vp.DescuentoRecargo = CalculaDescuentosProductos(vp.Precio, vp.ImporteImpuestoInterno / vp.Cantidad,
                                                             vp.DescuentoRecargoPorc1, vp.DescuentoRecargoPorc2, vp.Cantidad)
         Next

         'RecalcularTodo()

      Else
         Me._DescuentosRecargosProd = CalculosDescuentosRecargos1.DescuentoRecargo(_clienteE, Producto, Decimal.Parse(Me.txtCantidad.Text.ToString()), Me._decimalesAMostrar)
      End If


      Me.txtDescRecPorc1.Text = Me._DescuentosRecargosProd.DescuentoRecargo1.ToString("N" + _decimalesEnDescRec.ToString())
      If calculaDescuentoRecargo2 Then
         Me.txtDescRecPorc2.Text = Me._DescuentosRecargosProd.DescuentoRecargo2.ToString("N" + _decimalesEnDescRec.ToString())
      End If

      '# Si el producto tiene una bonificación x Lista de Precios x cantidad, se cambia la lista de precios y se modifica el precio
      If Producto.TipoBonificacion = Entidades.Producto.TiposBonificacionesProductos.LISTAPRECIO AndAlso
               Not Reglas.Publicos.Facturacion.FacturacionDescuentosAgrupaCantidadesPorRubro Then
         BonificacionListaDePrecioXCantidad(Producto, txtCantidad.ValorNumericoPorDefecto(0D))
      End If

      If Me._DescuentosRecargosProd.Mensaje <> "" Then
         MessageBox.Show(Me._DescuentosRecargosProd.Mensaje.ToString(), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
      End If
      '-- REQ-34669.- -------------------------------------------------------------------------------
      MovAtributo01 = New Entidades.AtributoProducto
      MovAtributo02 = New Entidades.AtributoProducto
      MovAtributo03 = New Entidades.AtributoProducto
      MovAtributo04 = New Entidades.AtributoProducto
      If Integer.Parse(dr.Cells("Atributos").Value.ToString()) > 0 Then
         If flackCargaProductos Then
            '-- Carga los Valores de Atributo.- --
            With MovAtributo01
               .IdTipoAtributoProducto = Short.Parse(dr.Cells("TipoAtributo01").Value.ToString())
               .IdGrupoTipoAtributoProducto = Integer.Parse(dr.Cells("GrupoAtributo01").Value.ToString())
            End With
            With MovAtributo02
               .IdTipoAtributoProducto = Short.Parse(dr.Cells("TipoAtributo02").Value.ToString())
               .IdGrupoTipoAtributoProducto = Integer.Parse(dr.Cells("GrupoAtributo02").Value.ToString())
            End With
            With MovAtributo03
               .IdTipoAtributoProducto = Short.Parse(dr.Cells("TipoAtributo03").Value.ToString())
               .IdGrupoTipoAtributoProducto = Integer.Parse(dr.Cells("GrupoAtributo03").Value.ToString())
            End With
            With MovAtributo04
               .IdTipoAtributoProducto = Short.Parse(dr.Cells("TipoAtributo04").Value.ToString())
               .IdGrupoTipoAtributoProducto = Integer.Parse(dr.Cells("GrupoAtributo04").Value.ToString())
            End With

            '-- Convoca Formulario de Carga de Atributos.-
            Using sap = SeleccionaAtributosProductosFactory.Create(DirectCast(cmbTiposComprobantes.SelectedItem, Entidades.TipoComprobante))
               With sap
                  .Atributo01 = MovAtributo01
                  .Atributo02 = MovAtributo02
                  .Atributo03 = MovAtributo03
                  .Atributo04 = MovAtributo04
                  '-- Adiciona Producto y Sucursal.- ---------------
                  .idSucursal = actual.Sucursal.IdSucursal
                  .idProducto = dr.Cells("IdProducto").Value.ToString.Trim()
               End With
               '-- Invoca Formulario.- -----------------------------
               If sap.ShowDialog(Me) = DialogResult.Cancel Then
                  btnLimpiarProducto.PerformClick()
                  bscCodigoProducto2.Focus()
                  Exit Sub
               End If
               '-- Aloja los datos recuperados.- --
               With sap
                  MovAtributo01 = .Atributo01
                  MovAtributo02 = .Atributo02
                  MovAtributo03 = .Atributo03
                  MovAtributo04 = .Atributo04
               End With
            End Using
         End If
         '----------------------------------------------
         txtAtributo01.Text = MovAtributo01.Descripcion
         txtAtributo02.Text = MovAtributo02.Descripcion
         '----------------------------------------------
         Me.txtStock.Text = New Reglas.ProductosSucursalesAtributos().GetStockProductoAtributo(dr.Cells("IdProducto").Value.ToString.Trim(),
                                                                                               actual.Sucursal.IdSucursal,
                                                                                               MovAtributo01.IdaAtributoProducto,
                                                                                               MovAtributo02.IdaAtributoProducto,
                                                                                               MovAtributo03.IdaAtributoProducto,
                                                                                               MovAtributo04.IdaAtributoProducto).ToString()
      Else
         txtStock.Text = dr.Cells("Stock").Value.ToString()
         Using dt = New Reglas.ProductosUbicaciones().GetSucursalDepositoProducto(actual.Sucursal.Id, Producto.IdDeposito, Producto.IdUbicacion, bscCodigoProducto2.Text())
            If dt.Any() Then
               txtStock.SetValor(dt.First().Field(Of Decimal)("Stock"))
               '.ToString(String.Format("N{0}", Reglas.Publicos.Compras.Redondeo.ComprasDecimalesRedondeoEnCantidad))
            End If
         End Using
      End If
      Me.txtStock.Tag = Boolean.Parse(dr.Cells("AfectaStock").Value.ToString())
      '----------------------------------------------------------------------------------------------

      If Me._modalidad = Eniac.Entidades.Producto.Modalidades.PESO Then
         Me.txtCantidad.Text = Decimal.Round(Me.GetPrecioModalidadPeso(), _decimalesEnCantidad).ToString(_formatoEnCantidad)
      End If

      Me._modalidad = Eniac.Entidades.Producto.Modalidades.NORMAL

      SetearDescuentosPorCantidad(Producto)

      If Boolean.Parse(dr.Cells("FacturacionCantidadNegativa").Value.ToString()) Then
         Me.txtCantidad.Text = (-1).ToString(_formatoEnCantidad)
         Me.txtStock.Tag = False
      End If

      Me.txtCantidad.Focus()
      Me.txtCantidad.SelectAll()

      pnlEsOferta.Visible = Reglas.Publicos.FacturacionResaltaProductosEnOferta And Producto.EsOferta = "SI"

      'Controla multiples Ivas en producto
      If Reglas.Publicos.ProductoUtilizaAlicuota2 AndAlso cmbCategoriaFiscal.ItemSeleccionado(Of Entidades.CategoriaFiscal)().ResuelveUtilizaAlicuota2Producto(_clienteE) AndAlso dr.Cells("Alicuota2").Value.ToString() <> Nothing Then
         'If dr.Cells("Alicuota2").Value.ToString() <> Nothing Then
         Me.cmbPorcentajeIva.Enabled = True
         'Me.cmbPorcentajeIva.Tag = dr.Cells("Alicuota2").Value.ToString()
         cmbPorcentajeIva.SelectedValue = dr.Cells("Alicuota2").Value
         Me.cmbPorcentajeIva.Enabled = False
      End If

      Me.CargarFoto(dr.Cells("IdProducto").Value.ToString.Trim(), Decimal.Parse(Me.txtTotalProducto.Text))

   End Sub

   Private Sub CargarFoto(idProducto As String, precio As Decimal)
      If pcbFoto.Visible Then
         Dim producto As Entidades.Producto = New Reglas.Productos().GetUno(idProducto, incluirFoto:=True)
         Me.pcbFoto.Image = producto.Foto
      Else
         Me.pcbFoto.Image = Nothing
      End If
      Me.txtPrecioMostrar.Text = precio.ToString("N" + Me._decimalesAMostrar.ToString())
   End Sub

   Private Sub CargarProductoCompleto(dr As DataGridViewRow,
                                      editarProductoDesdeGrilla As Boolean)

      Dim oProductos As Reglas.Productos = New Reglas.Productos
      Dim Prod As Entidades.Producto

      Prod = oProductos.GetUno(dr.Cells("IdProducto").Value.ToString.Trim())

      Me.bscCodigoProducto2.Text = dr.Cells("IdProducto").Value.ToString.Trim()

      Dim ventaProducto As Entidades.VentaProducto = DirectCast(dr.DataBoundItem, Entidades.VentaProducto)

      _cargandoProductosAutomaticamente = ventaProducto.Automatico

      'Llamo al evento para cargar el objeto "FilaDevuelta" validado luego al insertar el producto.
      Me.bscCodigoProducto2.Datos = oProductos.GetPorCodigo(Me.bscCodigoProducto2.Text.Trim(), actual.Sucursal.Id, DirectCast(Me.cmbListaDePrecios.SelectedItem, Entidades.ListaDePrecios).IdListaPrecios, "VENTAS", soloBuscaPorIdProducto:=editarProductoDesdeGrilla)
      Me.bscCodigoProducto2.PresionarBoton()

      'Dim valor As String = Boolean.Parse(dr.Cells("PermiteModificarDescripcion").Value.ToString()).ToString()

      ' Verificar si la fila devuelta está vacia.
      ' # Se adopta por ahora una solución parcial que es no permitirle al usuario editar el producto que está en la grilla si no lo selecciono.
      If Me.bscCodigoProducto2.FilaDevuelta Is Nothing Then
         Throw New Exception("No se seleccionó un producto para editar.")
      End If

      '------------------------------------------------------
      If Reglas.Publicos.Facturacion.FacturacionRapidaConservaOrdenProductos Then
         _ordenProducto = ventaProducto.Orden   ' Integer.Parse(dr.Cells("Orden").Value.ToString())
      End If
      '------------------------------------------------------

      If Reglas.Publicos.Facturacion.FacturacionModificaDescripcionProducto And Boolean.Parse(Me.bscCodigoProducto2.FilaDevuelta.Cells("PermiteModificarDescripcion").Value.ToString()) Then
         'Pongo la descripcion que estaba, porque pudo escribirla, sino dejo que la lea de la base (pudo cambiar).
         Me.bscProducto2.Text = dr.Cells("ProductoDesc").Value.ToString()
      End If

      'NO hace falta, el "PresionarBoton" llama a "CargarProducto" y lo asigna.
      ''Lo cargo por si dejo la pantalla levantada y cambio en el transcurso del tiempo que paso.
      'Me.txtStock.Text = Me.bscCodigoProducto2.FilaDevuelta.Cells("Stock").Value.ToString()
      'Me.txtStock.Tag = Boolean.Parse(Me.bscCodigoProducto2.FilaDevuelta.Cells("AfectaStock").Value.ToString())

      If DirectCast(Me.cmbFormaPago.SelectedItem, Eniac.Entidades.VentaFormaPago).AplicanOfertas Then
         Me._nroOferta = Integer.Parse(dr.Cells("IdOferta").Value.ToString())
      Else
         Me._nroOferta = Nothing
      End If

      Me.txtPrecio.Text = Decimal.Round(Decimal.Parse(dr.Cells("Precio").Value.ToString()), Me._valorRedondeo).ToString("#,##0." + New String("0"c, Me._decimalesAMostrar))
      Me.txtCantidad.Text = Decimal.Parse(dr.Cells("Cantidad").Value.ToString()).ToString(_formatoEnCantidad)
      Me.cmbPorcentajeIva.Text = dr.Cells("AlicuotaImpuesto").Value.ToString()
      Me.cmbPorcentajeIva.Tag = Me.cmbPorcentajeIva.Text
      Me.txtTotalProducto.Text = Decimal.Parse(dr.Cells("Importe").Value.ToString()).ToString("#0." + New String("0"c, Me._decimalesAMostrar))

      _modificoPrecioManualmente = ventaProducto.ModificoPrecioManualmente

      CalcularImpuestoInterno()

      Me.txtTamanio.Text = Me.bscCodigoProducto2.FilaDevuelta.Cells("Tamano").Value.ToString()
      Me.txtUM.Text = Me.bscCodigoProducto2.FilaDevuelta.Cells("IdUnidadDeMedida").Value.ToString()

      '-- REQ-34669.- -- Aloja los datos recuperados.- --
      With MovAtributo01
         .IdaAtributoProducto = Integer.Parse(dr.Cells("idaAtributoProducto01").Value.ToString())
         If dr.Cells("DescripcionAtributo01").Value IsNot Nothing Then
            .Descripcion = dr.Cells("DescripcionAtributo01").Value.ToString()
         End If
      End With
      With MovAtributo02
         .IdaAtributoProducto = Integer.Parse(dr.Cells("idaAtributoProducto02").Value.ToString())
         If dr.Cells("DescripcionAtributo02").Value IsNot Nothing Then
            .Descripcion = dr.Cells("DescripcionAtributo02").Value.ToString()
         End If
      End With
      With MovAtributo03
         .IdaAtributoProducto = Integer.Parse(dr.Cells("idaAtributoProducto03").Value.ToString())
         If dr.Cells("DescripcionAtributo03").Value IsNot Nothing Then
            .Descripcion = dr.Cells("DescripcionAtributo03").Value.ToString()
         End If
      End With
      With MovAtributo04
         .IdaAtributoProducto = Integer.Parse(dr.Cells("idaAtributoProducto04").Value.ToString())
         If dr.Cells("DescripcionAtributo04").Value IsNot Nothing Then
            .Descripcion = dr.Cells("DescripcionAtributo04").Value.ToString()
         End If
      End With
      '-- REQ-35489.- -------------------------------
      txtAtributo01.Text = MovAtributo01.Descripcion
      txtAtributo02.Text = MovAtributo02.Descripcion
      '----------------------------------------------
   End Sub

   Private Sub CargarObservDetalleCompleto(dr As DataGridViewRow)

      Me.txtObservacionDetalle.Text = dr.Cells("gobsObservacion").Value.ToString()

   End Sub

   Private Sub CalcularDatosDetalle()

      If Me.cmbCategoriaFiscal.SelectedItem Is Nothing Then Exit Sub

      'If Publicos.DescuentoMaximo > 0 And Decimal.Parse(Me.txtDescRecGralPorc.Text.ToString()) < 0 And Math.Abs(Decimal.Parse(Me.txtDescRecGralPorc.Text.ToString())) > Publicos.DescuentoMaximo Then
      '   MessageBox.Show("ATENCION: no puede asignar un Descuento mayor al: " & Publicos.DescuentoMaximo.ToString("##0.00") + " %", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
      '   Me.txtDescRecGralPorc.Focus()
      '   Exit Sub
      'End If

      For Each vPro As Entidades.VentaProducto In Me._ventasProductos

         vPro.DescRecGeneral = Decimal.Round((vPro.ImporteTotal * Decimal.Parse(Me.txtDescRecGralPorc2.Text) / 100), Me._valorRedondeo)

         Me.CalculaValores(vPro.Cantidad, vPro.AlicuotaImpuesto, vPro.ImporteImpuestoInterno, vPro.Precio,
               vPro.DescuentoRecargoPorc1, vPro.DescuentoRecargoPorc2, Decimal.Parse(Me.txtDescRecGralPorc2.Text),
               vPro.PrecioNeto, 0, vPro.ImporteImpuesto, vPro.ImporteTotal, vPro.Producto)

         'vPro.DescuentoRecargo = (vPro.PrecioNeto - vPro.Precio) * vPro.Cantidad

      Next

      Me.dgvProductos.Refresh()
      Me.RecalcularSubtotales()
      Me.CalcularTotales()

   End Sub

   Private Sub RenumerarObservacionesDetalle()

      Dim Linea As Integer = 0

      For Each vObs As Entidades.VentaObservacion In Me._ventasObservaciones
         Linea += 1
         vObs.Linea = Linea
      Next

      Me.dgvObservaciones.DataSource = Me._ventasObservaciones.ToArray()
      Me.dgvObservaciones.FirstDisplayedScrollingRowIndex = Me.dgvObservaciones.Rows.Count - 1
      Me.dgvObservaciones.Refresh()

   End Sub

   Private Sub CargarUnArticulo(linea As Entidades.VentaProducto,
                                 producto As Entidades.Producto,
                                 productoDescripcion As String,
                                 descuentoRecargoPorc1 As Decimal,
                                 descuentoRecargoPorc2 As Decimal,
                                 descuentoRecargo As Decimal,
                                 precio As Decimal,
                                 cantidad As Decimal,
                                 importeTotal As Decimal,
                                 stock As Decimal,
                                 costo As Decimal,
                                 precioLista As Decimal,
                                 kilos As Decimal,
                                 idTipoImpuesto As Entidades.TipoImpuesto.Tipos,
                                 porcentajeIva As Decimal,
                                 importeIva As Decimal,
                                 precioNeto As Decimal,
                                 ImpuestoInterno As Decimal,
                                 porcImpuestoInterno As Decimal,
                                 origenPorcImpInt As Entidades.OrigenesPorcImpInt,
                                 idOferta As Integer, moneda As Entidades.Moneda)

      Dim blnIncluirFoto As Boolean = True

      With linea
         .IdSucursal = actual.Sucursal.Id
         .Usuario = actual.Nombre
         '.Producto.IdProducto = idProducto
         .Producto = producto ' New Reglas.Productos().GetUno(idProducto, blnIncluirFoto)  'Luego uso ciertas caracteristicas (ej: LOTE).
         .Producto.NombreProducto = productoDescripcion   'Piso la descripcion por si tiene habilitado la posibilidad de cambiarlas.
         .DescuentoRecargoPorc1 = descuentoRecargoPorc1
         .DescuentoRecargoPorc2 = descuentoRecargoPorc2
         .DescuentoRecargo = descuentoRecargo
         .Precio = precio
         .Cantidad = cantidad
         .ImporteTotal = importeTotal
         .Stock = stock
         .Costo = costo
         .PrecioLista = precioLista
         .Kilos = kilos
         .PrecioNeto = precioNeto
         .AlicuotaImpuesto = porcentajeIva
         .ImporteImpuesto = importeIva
         .TipoImpuesto = New Reglas.TiposImpuestos().GetUno(idTipoImpuesto)
         .ComisionVendedorPorc = 0
         .ComisionVendedor = 0
         .IdListaPrecios = Integer.Parse(Me.cmbListaDePrecios.SelectedValue.ToString())
         .NombreListaPrecios = Me.cmbListaDePrecios.Text
         .ImporteImpuestoInterno = ImpuestoInterno
         .PorcImpuestoInterno = porcImpuestoInterno
         .OrigenPorcImpInt = origenPorcImpInt
         .Automatico = _cargandoProductosAutomaticamente
         .IdOferta = idOferta
         '-- REQ-42781.- ------------------------------------------------------------------
         .Moneda = moneda
         '-- REQ-33090.- ------------------------------------------------------------------
         .PrecioAux = precio
         .IdListaPreciosAux = _idListaAux
         '---------------------------------------------------------------------------------
         .ModificoPrecioManualmente = _modificoPrecioManualmente
         If _ordenProducto > 0 Then
            .Orden = _ordenProducto
         ElseIf _ordenProducto = 0 Then
            .Orden = _ventasProductos.MaxSecure(Function(x) x.Orden).IfNull() + 1
         End If
      End With

   End Sub

   Private Sub CargarTotales(impuesto As Entidades.VentaImpuesto,
                           idTipoImpuesto As Entidades.TipoImpuesto.Tipos,
                           alicuota As Decimal,
                           bruto As Decimal,
                           neto As Decimal,
                           importeIva As Decimal,
                           total As Decimal)

      With impuesto
         .TipoImpuesto = New Reglas.TiposImpuestos().GetUno(idTipoImpuesto)
         .Alicuota = alicuota
         .Bruto = bruto
         .Neto = neto
         .Importe = importeIva
         .Total = total
      End With

   End Sub

   Private Sub InsertarProducto()

      Dim producto = New Reglas.Productos().GetUno(Me.bscCodigoProducto2.Text)
      If producto.ImporteImpuestoInterno <> 0 Then
         Throw New Exception(String.Format("El producto seleccionado {0} - {1} tiene configurado Impuesto Interno Fijo. No se puede agregar el producto al Comprobane.", producto.IdProducto, producto.NombreProducto))
      End If

      If Not producto.CodigoDeBarrasConPrecio AndAlso _facturacionRapidaAgrupaCantidad Then
         Dim drExistente = _ventasProductos.FirstOrDefault(Function(vp) vp.IdProducto.Trim() = bscCodigoProducto2.Text.Trim())
         If drExistente IsNot Nothing Then
            Dim cantidadActual = txtCantidad.ValorNumericoPorDefecto(0D)
            txtCantidad.Text = (cantidadActual + drExistente.Cantidad).ToString("N2")
            _ordenProducto = drExistente.Orden
            txtCantidad.Focus()
            btnInsertar.Focus()
            _ventasProductos.Remove(drExistente)
            btnInsertar.PerformClick()
            Exit Sub
         End If
      End If

      'Fuerzo los calculos porque pudo no pasar Insertar sin los tab en los campos de descuento.
      'Me.CalcularDescuentosProductos()
      Me.CalcularTotalProducto()
      '------------------------------------------------------------------------------------------

      'cargo los valores de los controles a variables locales---------------------
      Dim oLineaDetalle As Entidades.VentaProducto = New Entidades.VentaProducto()
      Dim oLineaImpuestos As Entidades.VentaImpuesto = New Entidades.VentaImpuesto()

      Dim stock As Decimal = 0
      Dim precioCosto As Decimal = 0
      Dim precioLista As Decimal = 0
      Dim Kilos As Decimal = 0

      Dim importeBruto As Decimal = 0
      Dim importeNeto As Decimal = 0
      Dim importeIva As Decimal = 0
      Dim importeTotal As Decimal = 0

      Dim descRecPorc1 As Decimal = Decimal.Parse(Me.txtDescRecPorc1.Text)
      Dim descRecPorc2 As Decimal = Decimal.Parse(Me.txtDescRecPorc2.Text)
      Dim descRecargo As Decimal = 0

      If Me.txtStock.Text.Length <> 0 Then
         stock = Decimal.Parse(Me.txtStock.Text)
      End If

      Dim alicuotaIVA As Decimal
      Dim IdMoneda As Integer

      '-- REQ-42781.- -------------------------------------------------------------------------
      Dim filaDevuelta As DataGridViewRow
      If bscCodigoProducto2.FilaDevuelta Is Nothing Then
         filaDevuelta = bscProducto2.FilaDevuelta
      Else
         filaDevuelta = bscCodigoProducto2.FilaDevuelta
      End If

      precioCosto = Decimal.Parse(filaDevuelta.Cells("PrecioCosto").Value.ToString())
      precioLista = Decimal.Parse(filaDevuelta.Cells("PrecioVenta").Value.ToString())
      alicuotaIVA = Decimal.Parse(filaDevuelta.Cells("Alicuota").Value.ToString())
      IdMoneda = Integer.Parse(filaDevuelta.Cells("IdMoneda").Value.ToString())

      Dim eMoneda As Entidades.Moneda = New Reglas.Monedas().GetUna(IdMoneda)
      '----------------------------------------------------------------------------------------

      'Precio de Costo, Opciones: ACTUAL o PROMPOND;<meses>
      If Publicos.VentasPrecioCosto <> "ACTUAL" Then

         Dim CalculoCosto() As String = Publicos.VentasPrecioCosto.Split(";"c)

         Dim oCP As Reglas.ComprasProductos = New Reglas.ComprasProductos()

         Dim OtroPrecioCosto As Decimal = 0

         'Dejo preparado para distintas formas.
         If CalculoCosto(0) = "PROMPOND" Then
            OtroPrecioCosto = oCP.GetCostoPromedioPonderado(actual.Sucursal.Id, bscCodigoProducto2.Text,
                                                            Date.Today.AddMonths(Integer.Parse(CalculoCosto(1).ToString()) * (-1)),
                                                            Date.Today, _decimalesRedondeoEnPrecio)

            If OtroPrecioCosto <> 0 Then
               precioCosto = OtroPrecioCosto
            End If
         End If

      End If

      If Reglas.Publicos.PreciosConIVA Then
         'Le quito el IVA que el producto tiene en forma predeterminada.
         precioCosto = Decimal.Round(precioCosto / (1 + alicuotaIVA / 100), Me._valorRedondeo)
         precioLista = Decimal.Round(precioLista / (1 + alicuotaIVA / 100), Me._valorRedondeo)
      End If

      If IdMoneda = 2 Then
         precioCosto = Decimal.Round(precioCosto * Decimal.Parse(Me.txtCotizacionDolar.Text), Me._valorRedondeo)
         precioLista = Decimal.Round(precioLista * Decimal.Parse(Me.txtCotizacionDolar.Text), Me._valorRedondeo)
      End If

      'Asigno el nuevo iva (puedo cambiar o no)
      alicuotaIVA = Decimal.Parse(Me.cmbPorcentajeIva.Text)

      'If Me.txtUM.Text <> "" Then
      '   Dim Conversion As Decimal
      '   Dim oUM As Reglas.UnidadesDeMedidas = New Reglas.UnidadesDeMedidas
      '   Conversion = oUM.GetUno(Me.txtUM.Text).ConversionAKilos
      '   Kilos = Decimal.Round(Decimal.Parse(Me.txtCantidad.Text) * Decimal.Parse(Me.txtTamanio.Text) * Conversion, Me._valorRedondeo)
      'End If

      Dim kilosProducto As Decimal = 0
      If bscCodigoProducto2.FilaDevuelta Is Nothing Then
         kilosProducto = Decimal.Parse(bscProducto2.FilaDevuelta.Cells("Kilos").Value.ToString())
      Else
         kilosProducto = Decimal.Parse(bscCodigoProducto2.FilaDevuelta.Cells("Kilos").Value.ToString())
      End If
      Kilos = Decimal.Round(Decimal.Parse(Me.txtCantidad.Text) * kilosProducto, 3)


      Dim precioProducto As Decimal = Decimal.Parse(Me.txtPrecio.Text.Trim())

      Dim cantidad As Decimal = Decimal.Parse(Me.txtCantidad.Text)

      Dim descRecPorGeneral As Decimal = Decimal.Parse(Me.txtDescRecGralPorc2.Text)

      Dim precioNeto As Decimal = 0

      Me._numeroOrden += 1

      '--------------------------------------------------------------------------------
      '###############################
      '#          Lotes              #
      '###############################
      Dim coeficienteStockParaLote As Integer = DirectCast(Me.cmbTiposComprobantes.SelectedItem, Entidades.TipoComprobante).CoeficienteStock
      If coeficienteStockParaLote = 0 And
         Not String.IsNullOrWhiteSpace(DirectCast(Me.cmbTiposComprobantes.SelectedItem, Entidades.TipoComprobante).IdTipoComprobanteSecundario) Then
         Dim tipoSecundario As Entidades.TipoComprobante
         tipoSecundario = New Reglas.TiposComprobantes().GetUno(DirectCast(Me.cmbTiposComprobantes.SelectedItem, Entidades.TipoComprobante).IdTipoComprobanteSecundario)
         coeficienteStockParaLote = tipoSecundario.CoeficienteStock
      End If

      'Dim _productoTemporal As Entidades.Producto = producto
      If producto.Lote And coeficienteStockParaLote <> 0 Then

         'Si es NCRE , valido fechas.. sino.. que exista
         If coeficienteStockParaLote > 0 Then
            '_productoLoteTemporal.Producto.IdSucursal = actual.Sucursal.Id
            producto.IdSucursal = actual.Sucursal.Id
            Using frm As New SeleccionNrosLotes(producto, producto.IdDeposito, producto.IdUbicacion, CDec(Me.txtCantidad.Text), coeficienteStockParaLote, _numeroOrden)
               If frm.ShowDialog() = Windows.Forms.DialogResult.Cancel Then
                  Throw New Exception("Si el producto esta marcado que utiliza Lote tiene que ingresar uno en la Venta.")
               Else
                  '# Me guardo los lotes seleccionados
                  _lotesSeleccionados = frm._lotesSeleccionados
                  Me.CargarLotesSeleccionados(_lotesSeleccionados, oLineaDetalle, producto)
               End If
            End Using
         Else

            '# Si el comprobante facturable no afecta stock, los nros de lotes no fueron solicitados, por lo que se le solicitan al usuario.
            '# Selección Automática
            Dim DispProdLotes As Decimal = New Reglas.ProductosLotes().GetDisponiblePorProducto(actual.Sucursal.Id, Me.bscCodigoProducto2.Text)
            If DispProdLotes = 0 Then
               Throw New Exception("No existen Lotes para el Producto seleccionado.")
            End If
            If DispProdLotes < CDec(Me.txtCantidad.Text) Then
               Throw New Exception("El Producto tiene en Stock " & DispProdLotes.ToString() & " quedaría en Cantidad Negativa, No es posible con Lotes.")
            End If

            '# Selección Manual
            If Reglas.Publicos.Facturacion.FacturacionSeleccionManualLoteProducto Then
               producto.IdSucursal = actual.Sucursal.Id
               Using frm As New SeleccionNrosLotes(producto, producto.IdDeposito, producto.IdUbicacion, CDec(Me.txtCantidad.Text), coeficienteStockParaLote, _lotesSeleccionados)
                  If frm.ShowDialog() = Windows.Forms.DialogResult.Cancel Then
                     Throw New Exception("Si el producto esta marcado que utiliza Lote tiene que ingresar uno en la Venta.")
                  Else
                     _lotesSeleccionados = frm._lotesSeleccionados
                     Me.CargarLotesSeleccionados(_lotesSeleccionados, oLineaDetalle, producto, precioCosto, IdMoneda)
                  End If
               End Using
            End If
         End If

      Else
         If producto.Lote AndAlso
            coeficienteStockParaLote = 0 AndAlso
            DirectCast(Me.cmbTiposComprobantes.SelectedItem, Entidades.TipoComprobante).EsPreElectronico AndAlso
            Reglas.Publicos.Facturacion.FacturacionSeleccionManualLoteProducto Then
            MessageBox.Show("El comprobante " & DirectCast(Me.cmbTiposComprobantes.SelectedItem, Entidades.TipoComprobante).DescripcionAbrev.ToString() & " No permite productos con Lotes.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
         End If
      End If
#Region "Codigo Comentado"
      'Dim coeficienteStockParaLote As Integer = DirectCast(Me.cmbTiposComprobantes.SelectedItem, Entidades.TipoComprobante).CoeficienteStock
      'If coeficienteStockParaLote = 0 And
      '   Not String.IsNullOrWhiteSpace(DirectCast(Me.cmbTiposComprobantes.SelectedItem, Entidades.TipoComprobante).IdTipoComprobanteSecundario) Then
      '   Dim tipoSecundario As Entidades.TipoComprobante
      '   tipoSecundario = New Reglas.TiposComprobantes().GetUno(DirectCast(Me.cmbTiposComprobantes.SelectedItem, Entidades.TipoComprobante).IdTipoComprobanteSecundario)
      '   coeficienteStockParaLote = tipoSecundario.CoeficienteStock
      'End If

      ''ingreso los valores del Lote '.... por ahora solo de hace Nota de Credito
      'If Me._productoLoteTemporal.Producto.Lote And coeficienteStockParaLote <> 0 Then


      '   'Si es NCRE , valido fechas.. sino.. que exista
      '   If coeficienteStockParaLote > 0 Then

      '      'En caso de NCRED no debe seleccionarlo... debe crearlo.
      '      'Dim idL1 As SeleccionDeLote = New SeleccionDeLote(Me.bscCodigoProducto2.Text, Decimal.Parse(Me.txtCantidad.Text))

      '      Dim idL As SeleccionDeLote = New SeleccionDeLote(Me.bscCodigoProducto2.Text, Decimal.Parse(Me.txtCantidad.Text), coeficienteStockParaLote, False)

      '      If idL.ShowDialog() = Windows.Forms.DialogResult.Cancel Then
      '         MessageBox.Show("Si el producto esta marcado que utiliza Lote tiene que ingresar uno en la Compra.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
      '         Me.btnInsertar.Focus()
      '         Exit Sub
      '      End If

      '      If Publicos.LoteSolicitaFechaVencimiento Then
      '         'Controlar la fecha de la factura con la fecha de vencimiento del lote
      '         If idL.dtpFechaVencimiento.Value.Date = Me.dtpFecha.Value.Date Then
      '            If MessageBox.Show("La fecha del lote es igual a la fecha del comprobante. Desea continuar?", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) <> Windows.Forms.DialogResult.Yes Then
      '               Exit Sub
      '            End If
      '         ElseIf idL.dtpFechaVencimiento.Value.Date < Me.dtpFecha.Value.Date Then
      '            If MessageBox.Show("La fecha del lote es menor que la fecha del comprobante. Desea continuar?", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) <> Windows.Forms.DialogResult.Yes Then
      '               Exit Sub
      '            End If
      '         End If

      '         Me._productoLoteTemporal.FechaVencimiento = idL.dtpFechaVencimiento.Value
      '      Else
      '         Me._productoLoteTemporal.FechaVencimiento = Nothing
      '      End If

      '      Me._productoLoteTemporal.IdSucursal = actual.Sucursal.Id
      '      Me._productoLoteTemporal.IdLote = idL.bscLote.Text.ToUpper()
      '      Me._productoLoteTemporal.Cantidad = Decimal.Parse(Me.txtCantidad.Text)
      '      Me._productoLoteTemporal.Orden = Me._numeroOrden
      '      Me._productosLotes.Add(Me._productoLoteTemporal)

      '      'Valido que Exista
      '   Else

      '      'Dim oProductoLote As Entidades.ProductoLote
      '      'oProductoLote = New Reglas.ProductosLotes().GetUno(idL.txtIdLote.Text.ToUpper(), actual.Sucursal.Id, Me.bscCodigoProducto2.Text)


      '      'Automatico
      '      Dim DispProdLotes As Decimal

      '      DispProdLotes = New Reglas.ProductosLotes().GetDisponiblePorProducto(actual.Sucursal.Id, Me.bscCodigoProducto2.Text)
      '      If DispProdLotes = 0 Then
      '         MessageBox.Show("No existen Lotes para el Producto seleccionado.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
      '         Exit Sub
      '      End If

      '      If DispProdLotes < Decimal.Parse(Me.txtCantidad.Text) Then
      '         MessageBox.Show("El Producto tiene en Stock " & DispProdLotes.ToString() & " quedaría en Cantidad Negativa, No es posible con Lotes.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
      '         Exit Sub
      '      End If

      '      If Publicos.FacturacionSeleccionManualLoteProducto Then


      '         'Selecciono Lote 
      '         Dim idL As SeleccionDeLote = New SeleccionDeLote(Me.bscCodigoProducto2.Text, Decimal.Parse(Me.txtCantidad.Text), coeficienteStockParaLote, False)

      '         If idL.ShowDialog() = Windows.Forms.DialogResult.Cancel Then
      '            MessageBox.Show("Si el producto esta marcado que utiliza Lote tiene que ingresar uno en la Compra.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      '            Me.btnInsertar.Focus()
      '            Exit Sub
      '         Else

      '            If Publicos.LoteSolicitaFechaVencimiento Then
      '               Me._productoLoteTemporal.FechaVencimiento = idL.dtpFechaVencimiento.Value
      '            Else
      '               Me._productoLoteTemporal.FechaVencimiento = Nothing
      '            End If

      '            Me._productoLoteTemporal.IdSucursal = actual.Sucursal.Id
      '            Me._productoLoteTemporal.IdLote = idL.bscLote.Text.ToUpper()
      '            Me._productoLoteTemporal.Cantidad = Decimal.Parse(Me.txtCantidad.Text)
      '            Me._productoLoteTemporal.Orden = Me._numeroOrden

      '            Me._productosLotes.Add(Me._productoLoteTemporal)

      '            If Reglas.Publicos.UtilizaPrecioCostoPorLote Then
      '               Dim oProductoLote As Entidades.ProductoLote
      '               oProductoLote = New Reglas.ProductosLotes().GetUno(idL.bscLote.Text.ToUpper(), actual.Sucursal.Id, Me.bscCodigoProducto2.Text)
      '               precioCosto = oProductoLote.PrecioCosto
      '               If Publicos.PreciosConIVA Then
      '                  precioCosto = Decimal.Round(precioCosto / (1 + alicuotaIVA / 100), Me._decimalesRedondeoEnPrecio)
      '               End If
      '               If IdMoneda = 2 Then
      '                  precioCosto = Decimal.Round(precioCosto * Decimal.Parse(Me.txtCotizacionDolar.Text), Me._decimalesRedondeoEnPrecio)
      '               End If

      '            End If

      '         End If
      '      Else

      '         ' ##############

      '      End If

      '      ''Le pongo la fecha del Lote original
      '      'Me._productoLoteTemporal.FechaVencimiento = oProductoLote.FechaVencimiento.Date

      '   End If

      'Else
      '   If Me._productoLoteTemporal.Producto.Lote AndAlso
      '      coeficienteStockParaLote = 0 AndAlso
      '      DirectCast(Me.cmbTiposComprobantes.SelectedItem, Entidades.TipoComprobante).EsPreElectronico AndAlso
      '      Publicos.FacturacionSeleccionManualLoteProducto Then
      '      MessageBox.Show("El comprobante " & DirectCast(Me.cmbTiposComprobantes.SelectedItem, Entidades.TipoComprobante).DescripcionAbrev.ToString() & " No permite productos con Lotes.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
      '      Exit Sub
      '   End If
      'End If

      ''ingreso los valores del Lote '.... por ahora solo de hace Nota de Credito
      'If Me._productoLoteTemporal.Producto.Lote And DirectCast(Me.cmbTiposComprobantes.SelectedItem, Entidades.TipoComprobante).CoeficienteStock <> 0 Then

      '   'Si es NCRE , valido fechas.. sino.. que exista
      '   If DirectCast(Me.cmbTiposComprobantes.SelectedItem, Entidades.TipoComprobante).CoeficienteStock > 0 Then

      '      'En caso de NCRED no debe seleccionarlo... debe crearlo.
      '      'Dim idL As SeleccionDeLote = New SeleccionDeLote(Me.bscCodigoProducto2.Text, Decimal.Parse(Me.txtCantidad.Text))
      '      Dim idL As IngresoDeLote = New IngresoDeLote()

      '      If idL.ShowDialog() = Windows.Forms.DialogResult.Cancel Then
      '         MessageBox.Show("Si el producto esta marcado que utiliza Lote tiene que ingresar uno en la Compra.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
      '         Me.btnInsertar.Focus()
      '         Exit Sub
      '      End If

      '      If Publicos.LoteSolicitaFechaVencimiento Then
      '         'Controlar la fecha de la factura con la fecha de vencimiento del lote
      '         If idL.dtpFechaVencimiento.Value.Date = Me.dtpFecha.Value.Date Then
      '            If MessageBox.Show("La fecha del lote es igual a la fecha del comprobante. Desea continuar?", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) <> Windows.Forms.DialogResult.Yes Then
      '               Exit Sub
      '            End If
      '         ElseIf idL.dtpFechaVencimiento.Value.Date < Me.dtpFecha.Value.Date Then
      '            If MessageBox.Show("La fecha del lote es menor que la fecha del comprobante. Desea continuar?", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) <> Windows.Forms.DialogResult.Yes Then
      '               Exit Sub
      '            End If
      '         End If

      '         Me._productoLoteTemporal.FechaVencimiento = idL.dtpFechaVencimiento.Value
      '      Else
      '         Me._productoLoteTemporal.FechaVencimiento = Nothing
      '      End If

      '      Me._productoLoteTemporal.IdSucursal = actual.Sucursal.Id
      '      Me._productoLoteTemporal.IdLote = idL.txtIdLote.Text.ToUpper()
      '      Me._productoLoteTemporal.Cantidad = Decimal.Parse(Me.txtCantidad.Text)
      '      Me._productoLoteTemporal.Orden = Me._numeroOrden
      '      Me._productosLotes.Add(Me._productoLoteTemporal)

      '      'Valido que Exista
      '   Else

      '      'Dim oProductoLote As Entidades.ProductoLote
      '      'oProductoLote = New Reglas.ProductosLotes().GetUno(idL.txtIdLote.Text.ToUpper(), actual.Sucursal.Id, Me.bscCodigoProducto2.Text)

      '      Dim DispProdLotes As Decimal

      '      DispProdLotes = New Reglas.ProductosLotes().GetDisponiblePorProducto(actual.Sucursal.Id, Me.bscCodigoProducto2.Text)

      '      If DispProdLotes = 0 Then
      '         MessageBox.Show("No existen Lotes para el Producto seleccionado.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
      '         Exit Sub
      '      End If


      '      If DispProdLotes < Decimal.Parse(Me.txtCantidad.Text) Then
      '         MessageBox.Show("El Producto tiene en Stock " & DispProdLotes.ToString() & " quedaría en Cantidad Negativa, No es posible con Lotes.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
      '         Exit Sub
      '      End If

      '      ''Le pongo la fecha del Lote original
      '      'Me._productoLoteTemporal.FechaVencimiento = oProductoLote.FechaVencimiento.Date

      '   End If
      'Else
      '   If Me._productoLoteTemporal.Producto.Lote AndAlso
      '      DirectCast(Me.cmbTiposComprobantes.SelectedItem, Entidades.TipoComprobante).CoeficienteStock = 0 AndAlso
      '      DirectCast(Me.cmbTiposComprobantes.SelectedItem, Entidades.TipoComprobante).EsPreElectronico AndAlso
      '      Publicos.FacturacionSeleccionManualLoteProducto Then
      '      MessageBox.Show("El comprobante " & DirectCast(Me.cmbTiposComprobantes.SelectedItem, Entidades.TipoComprobante).DescripcionAbrev.ToString() & " No permite productos con Lotes.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
      '      Exit Sub
      '   End If
      'End If


      ''ingreso los nros. de serie
      'If Me._productoLoteTemporal.ProductoSucursal.Producto.NroSerie Then
      '   Dim cantidadDeProductos As Integer = Int32.Parse(Math.Round(Decimal.Parse(Me.txtCantidad.Text), 0).ToString())
      '   Dim ins As IngresoNumerosSerie = New IngresoNumerosSerie(cantidadDeProductos, Me._productoLoteTemporal.ProductoSucursal.Producto)
      '   If ins.ShowDialog() = Windows.Forms.DialogResult.Cancel Then
      '      MessageBox.Show("Si el producto esta marcado que utiliza Nro. de Serie los tiene que ingresar en la compra.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
      '      Me.btnInsertar.Focus()
      '      Exit Sub
      '   Else
      '      For Each ns As Entidades.ProductoNroSerie In ins.ProductosNrosSerie
      '         Me._productosNrosSeries.Add(ns)
      '      Next
      '   End If
      'End If
#End Region
      '--------------------------------------------------------------------------------
      Me._numeroOrden += 1

      Dim impuestoInterno As Decimal = Decimal.Round(Decimal.Parse(Me.txtImpuestoInterno.Text) * cantidad, _valorRedondeo)
      Me.CalculaValores(cantidad, alicuotaIVA, impuestoInterno, precioProducto, descRecPorc1, descRecPorc2, descRecPorGeneral,
                        precioNeto, importeBruto, importeIva, importeTotal, producto)

      Dim iidb As FacturacionV2.ImpIntDesdeBusquedas = FacturacionV2.GetImpIntDesdeBusquedas(bscCodigoProducto2, bscProducto2)
      Me.CalcularDescuentosProductos()
      descRecargo = Decimal.Parse(txtDescRec.Text)

      Me.CargarUnArticulo(oLineaDetalle,
                        producto,
                        Me.bscProducto2.Text,
                        descRecPorc1,
                        descRecPorc2,
                        descRecargo,
                        precioProducto,
                        cantidad,
                        importeTotal,
                        stock,
                        precioCosto,
                        precioLista,
                        Kilos,
                        Me._tipoImpuestoIVA,
                        alicuotaIVA,
                        importeIva,
                        precioNeto,
                        impuestoInterno,
                        Decimal.Parse(txtPorcImpuestoInterno.Text),
                        iidb.OrigenPorcImpInt,
                        _nroOferta, eMoneda)

      oLineaDetalle.ModificoPrecioManualmente = _modificoPrecioManualmente

      'Selecciono los nros. de serie SOLO si el producto permite
      If coeficienteStockParaLote <> 0 Then
         If oLineaDetalle.Producto.NroSerie Then
            Dim nrosSerie As DataTable
            Dim onrosSerie As Reglas.ProductosNrosSerie = New Reglas.ProductosNrosSerie()

            If DirectCast(Me.cmbTiposComprobantes.SelectedItem, Entidades.TipoComprobante).CoeficienteValores = -1 Then
               nrosSerie = New Reglas.ProductosNrosSerie().GetNrosSerieProductoCLienteVendido(actual.Sucursal.Id, Me.bscCodigoProducto2.Text, _clienteE.IdCliente)

            Else
               '-- REQ-32489.- -------------------------------------------------------------------------
               nrosSerie = onrosSerie.GetNrosSerieProducto(actual.Sucursal, producto.IdDeposito, producto.IdUbicacion, bscCodigoProducto2.Text)
            End If

            Dim cantidadDeProductos As Integer = Int32.Parse(Math.Round(Decimal.Parse(Me.txtCantidad.Text), 0).ToString())
            Dim sel As SeleccionoNrosSerie = New SeleccionoNrosSerie(cantidadDeProductos, oLineaDetalle.Producto, nrosSerie)
            If sel.ShowDialog() = Windows.Forms.DialogResult.Cancel Then
               MessageBox.Show("Si el producto esta marcado que utiliza Nro. de Serie debe seleccionar los numeros", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
               Me.btnInsertar.Focus()
               Exit Sub
            Else
               For Each ns As Entidades.ProductoNroSerie In sel.ProductosNrosSerie
                  Dim noFueAgregado As Boolean
                  noFueAgregado = _ventasProductos.All(Function(vp)
                                                          If vp.Producto.IdProducto = ns.Producto.IdProducto Then
                                                             Return Not vp.Producto.NrosSeries.Any(Function(x) x.NroSerie = ns.NroSerie)
                                                          End If
                                                          Return True
                                                       End Function)

                  '# Si el producto ya fue agregado a la grilla, no dejo agregarlo nuevamente
                  If Not noFueAgregado Then
                     ShowMessage(String.Format("ATENCIÓN: El Producto: {0} Nro. Serie: {1} ya fue agregado.", ns.Producto.IdProducto, ns.NroSerie))
                     Exit Sub
                  End If

                  oLineaDetalle.Producto.NrosSeries.Add(ns)
               Next
            End If
         End If
      End If

      '# Si el producto Es Compuesto y NO tiene Fórmula predeterminada, el sistema no debe permitir ingresarlo.
      If oLineaDetalle.Producto.EsCompuesto AndAlso
         Not oLineaDetalle.Producto.IdFormula > 0 Then
         ShowMessage(String.Format("ATENCIÓN: El Producto: {0} {1} es Compuesto y no tiene fórmula predeterminada. Debe configurarla primero para poder ingresarlo.",
                                   oLineaDetalle.Producto.IdProducto,
                                   oLineaDetalle.Producto.NombreProducto))
         Exit Sub
      End If


      With oLineaDetalle
         '--REQ-34986.- ---------------------------------------------
         .IdaAtributoProducto01 = MovAtributo01.IdaAtributoProducto
         .DescripcionAtributo01 = MovAtributo01.Descripcion
         .IdaAtributoProducto02 = MovAtributo02.IdaAtributoProducto
         .DescripcionAtributo02 = MovAtributo02.Descripcion
         .IdaAtributoProducto03 = MovAtributo03.IdaAtributoProducto
         .DescripcionAtributo03 = MovAtributo03.Descripcion
         .IdaAtributoProducto04 = MovAtributo04.IdaAtributoProducto
         .DescripcionAtributo04 = MovAtributo04.Descripcion
         '---------------------------------------------------------
      End With

      If oLineaDetalle.Orden = 0 Then
         oLineaDetalle.Orden = Me._numeroOrden
      End If

      Me._ventasProductos.Add(oLineaDetalle)

      '-- REQ-34986.- ------------------------------------------------------
      If _ventasProductos.MaxSecure(Function(p) p.IdaAtributoProducto01).IfNull() > 0 Then
         If Not _tit.ContainsKey("DescripcionAtributo01") Then _tit.Add("DescripcionAtributo01", "")
      End If
      If _ventasProductos.MaxSecure(Function(p) p.IdaAtributoProducto02).IfNull() > 0 Then
         If Not _tit.ContainsKey("DescripcionAtributo02") Then _tit.Add("DescripcionAtributo02", "")
      End If
      If _ventasProductos.MaxSecure(Function(p) p.IdaAtributoProducto03).IfNull() > 0 Then
         If Not _tit.ContainsKey("DescripcionAtributo03") Then _tit.Add("DescripcionAtributo03", "")
      End If
      If _ventasProductos.MaxSecure(Function(p) p.IdaAtributoProducto03).IfNull() > 0 Then
         If Not _tit.ContainsKey("DescripcionAtributo04") Then _tit.Add("DescripcionAtributo04", "")
      End If
      '---------------------------------------------------------------------
      '-- REQ-32596.- -------------------------------------------------------------------------------
      SetProductosDataSource()
      'Me.dgvProductos.DataSource = Me._ventasProductos.ToArray()
      '----------------------------------------------------------------------------------------------

      'Me.OrdenarGrillaProductos()
      Me.dgvProductos.Rows(Me.dgvProductos.Rows.Count - 1).Selected = True
      Me.dgvProductos.FirstDisplayedScrollingRowIndex = Me.dgvProductos.Rows.Count - 1
      'Me.dgvProductos.Refresh()

      'importeBruto = precioProducto * cantidad
      importeNeto = precioNeto * cantidad

      'SI el CLIENTE es CF/MO o el Emisor; el monto llega CON IVA, hay que sacarselo.
      If (Not Me._clienteE.CategoriaFiscal.IvaDiscriminado Or Not Me._categoriaFiscalEmpresa.IvaDiscriminado) Then
         importeBruto = Decimal.Round(importeBruto / (1 + alicuotaIVA / 100), Me._valorRedondeo)
         importeNeto = Decimal.Round(importeNeto / (1 + alicuotaIVA / 100), Me._valorRedondeo)
      End If

      Me.CargarTotales(oLineaImpuestos,
                     Me._tipoImpuestoIVA,
                     alicuotaIVA,
                     importeBruto,
                        importeNeto,
                     importeIva,
                        importeNeto + importeIva)

      Dim entro As Boolean = False
      For Each vi As Entidades.VentaImpuesto In Me._subTotales
         If vi.Alicuota = alicuotaIVA Then
            vi.TipoImpuesto.IdTipoImpuesto = Me._tipoImpuestoIVA
            vi.Bruto += importeBruto      'precioProducto * cantidad
            vi.Neto += importeNeto   'importeTotal
            vi.Importe += importeIva
            vi.Total += (importeNeto + importeIva)
            entro = True
         End If
      Next

      If Not entro Then
         Me._subTotales.Add(oLineaImpuestos)
      End If


      If impuestoInterno <> 0 Then
         oLineaImpuestos = New Entidades.VentaImpuesto()
         Me.CargarTotales(oLineaImpuestos,
                          Entidades.TipoImpuesto.Tipos.IMINT,
                          0,
                          0,
                          0,
                          impuestoInterno,
                          impuestoInterno)

         entro = False
         For Each vi As Entidades.VentaImpuesto In Me._subTotales
            If vi.Alicuota = 0 And vi.TipoImpuesto.IdTipoImpuesto = Entidades.TipoImpuesto.Tipos.IMINT Then
               vi.TipoImpuesto.IdTipoImpuesto = Entidades.TipoImpuesto.Tipos.IMINT
               vi.Bruto += 0
               vi.Neto += 0
               vi.Importe += impuestoInterno
               vi.Total += impuestoInterno
               entro = True
            End If
         Next

         If Not entro Then
            Me._subTotales.Add(oLineaImpuestos)
         End If
      End If

      Me.dgvIvas.DataSource = Me._subTotales.ToArray()


      ' Aplico la lógica de Descuentos
      '# Solo si el tilde de modificar manualmente el Desc/Rec no está tildado
      If Me.bscCodigoCliente.Selecciono Or Me.bscCliente.Selecciono Then
         If Not Me.chbModificaDescRecGralPorc.Checked Then
            _cantLineas = _ventasProductos.Count
            Me._DescRecGralPorc = CalculosDescuentosRecargos1.DescuentoRecargo(_clienteE,
                                                                       cmbTiposComprobantes.ItemSeleccionado(Of Entidades.TipoComprobante),
                                                                       cmbFormaPago.ItemSeleccionado(Of Entidades.VentaFormaPago),
                                                                       _cantLineas)
            Me.txtDescRecGralPorc2.Text = _DescRecGralPorc.ToString("N" + _decimalesEnDescRec.ToString())
            Me.txtDescRecGralPorc2.Text = _DescRecGralPorc.ToString("N" + _decimalesEnDescRec.ToString())
         End If
      End If
      '
      ' ###########################################

      Me.CalcularDescuentosProductos()
      Me.CalcularTotalProducto()

      Me.txtPrecioMostrar.Text = Me.txtTotalProducto.Text

      Me.CargarFoto(Me.bscCodigoProducto2.Text, Decimal.Parse(Me.txtTotalProducto.Text))

      Me.LimpiarCamposProductos()
      Me.CalcularTotales()
      Me.CalcularDatosDetalle()
      Me.OrdenarGrillaProductos()

      'Me.CalcularTotales()

      'Me.dgvProductos.Rows(Me.dgvProductos.Rows.Count - 1).Selected = True
      'Me.dgvProductos.FirstDisplayedScrollingRowIndex = Me.dgvProductos.Rows.Count - 1

      Me.tsbGrabar.Enabled = True
      Me.bscCodigoProducto2.Focus()


      'If Me.EsComprobanteFiscal() And DirectCast(Me.cmbTiposComprobantes.SelectedItem, Entidades.TipoComprobante).GrabaLibro Then


      '   'oImpresora = New Reglas.Impresoras().GetPorSucursalPCTipoComprobante(actual.Sucursal.Id, My.Computer.Name, Me.cmbTiposComprobantes.SelectedValue.ToString())

      '   _cfiscal = New ImpresionFiscal()

      '   If Me._ventasProductos.Count = 1 Then
      '      'Apertura del comprobante

      '   End If

      '   'Impresion del item

      'End If

      ' Me.CargarFoto(dr.Cells("IdProducto").Value.ToString.Trim(), Decimal.Parse(Me.txtTotalProducto.Text))

      _cargandoProductosAutomaticamente = False
   End Sub

   Private Sub CalculaValores(cantidad As Decimal,
                              alicuotaIVA As Decimal,
                              ByRef impuestoInterno As Decimal,
                              ByRef precioProducto As Decimal,
                              descRecPorc1 As Decimal,
                              descRecPorc2 As Decimal,
                              descRecPorGeneral As Decimal,
                              ByRef precioNeto As Decimal,
                              ByRef importeBruto As Decimal,
                              ByRef importeIVA As Decimal,
                              ByRef importeTotalProducto As Decimal,
                              prod As Entidades.Producto)

      Dim alicuotaIVASobre100 As Decimal = (alicuotaIVA / 100)

      Dim precioParaDescuento As Decimal = precioProducto
      'Se anula esta lógica porque no se permite más facturación con ImpInt fijos.
      'If Not Me._clienteE.CategoriaFiscal.IvaDiscriminado Or Not Me._categoriaFiscalEmpresa.IvaDiscriminado Then
      '   If DirectCast(Me.cmbTiposComprobantes.SelectedItem, Entidades.TipoComprobante).GrabaLibro Or
      '      DirectCast(Me.cmbTiposComprobantes.SelectedItem, Entidades.TipoComprobante).EsPreElectronico Or
      '      Reglas.Publicos.Facturacion.FacturacionDescuentoImpIntIgualado Then
      '      precioParaDescuento = precioProducto - (impuestoInterno / cantidad)
      '   Else
      '      precioParaDescuento = precioProducto
      '   End If
      '   ''precioParaDescuento = precioProducto - (impuestoInterno / cantidad)
      'Else
      '   precioParaDescuento = precioProducto
      'End If

      Dim descRec1 As Decimal = Decimal.Round(precioParaDescuento * descRecPorc1 / 100, Me._valorRedondeo)
      Dim descRec2 As Decimal = Decimal.Round((precioParaDescuento + descRec1) * descRecPorc2 / 100, Me._valorRedondeo)
      Dim descRec As Decimal = Decimal.Round((precioParaDescuento + descRec1 + descRec2) * descRecPorGeneral / 100, Me._valorRedondeo)

      precioNeto = precioProducto + descRec1 + descRec2 + descRec

      importeBruto = (precioProducto + descRec1 + descRec2) * cantidad

      'Lo calcula despues
      'importeTotalProducto = precioNeto * cantidad
      '------------------------------------
      'En Pantalla debe mostrar el total bruto (sin aplicar el descuento General)
      importeTotalProducto = importeBruto

      If Not Me._clienteE.CategoriaFiscal.IvaDiscriminado Or Not Me._categoriaFiscalEmpresa.IvaDiscriminado Then
         impuestoInterno = Reglas.CalculosImpositivos.CalcularImpuestoInternoDesdeNetoConIVA(precioNeto, alicuotaIVA, prod.PorcImpuestoInterno, prod.ImporteImpuestoInterno, prod.OrigenPorcImpInt) * cantidad
         Dim tmpImpInt = impuestoInterno  '((impuestoInterno - (prod.ImporteImpuestoInterno * cantidad)) * (1 + (descRecPorGeneral / 100))) + prod.ImporteImpuestoInterno * cantidad
         importeIVA = Decimal.Round(((precioNeto * cantidad) - tmpImpInt) - ((precioNeto * cantidad) - tmpImpInt) / (1 + alicuotaIVASobre100), Me._valorRedondeo)
      Else
         impuestoInterno = Reglas.CalculosImpositivos.CalcularImpuestoInternoDesdeNetoSinIVA(precioNeto, alicuotaIVA, prod.PorcImpuestoInterno, prod.ImporteImpuestoInterno, prod.OrigenPorcImpInt) * cantidad
         importeIVA = Decimal.Round((precioNeto * cantidad) * alicuotaIVASobre100, Me._valorRedondeo)
      End If

   End Sub

   Private Sub InsertarObservacion()

      Dim oLineaDetalle As Entidades.VentaObservacion = New Entidades.VentaObservacion()

      With oLineaDetalle
         .IdSucursal = actual.Sucursal.Id
         .Usuario = actual.Nombre
         .Linea = Me.dgvObservaciones.RowCount + 1
         .Observacion = Me.txtObservacionDetalle.Text
      End With

      Me._ventasObservaciones.Add(oLineaDetalle)

      Me.dgvObservaciones.DataSource = Me._ventasObservaciones.ToArray()
      Me.dgvObservaciones.FirstDisplayedScrollingRowIndex = Me.dgvObservaciones.Rows.Count - 1
      Me.dgvObservaciones.Refresh()

      Me.LimpiarCamposObservDetalles()

      'Me.tsbGrabar.Enabled = True
      Me.txtObservacionDetalle.Focus()

   End Sub
   Private Sub EliminarLineaProducto()
      EliminarLineaProducto(dgvProductos.FilaSeleccionada(Of Entidades.VentaProducto)())
   End Sub
   Private Sub EliminarLineaProducto(vpro As Entidades.VentaProducto)

      Dim producto As Entidades.Producto = vpro.Producto

      Me._ventasProductos.Remove(vpro)

      '-- REQ-34986.- -------------------------------------------------------------------------------
      If _ventasProductos.MaxSecure(Function(p) p.IdaAtributoProducto01).IfNull() = 0 Then
         If _tit.ContainsKey("DescripcionAtributo01") Then _tit.Remove("DescripcionAtributo01")
      End If
      If _ventasProductos.MaxSecure(Function(p) p.IdaAtributoProducto02).IfNull() = 0 Then
         If _tit.ContainsKey("DescripcionAtributo02") Then _tit.Remove("DescripcionAtributo02")
      End If
      If _ventasProductos.MaxSecure(Function(p) p.IdaAtributoProducto03).IfNull() = 0 Then
         If _tit.ContainsKey("DescripcionAtributo03") Then _tit.Remove("DescripcionAtributo03")
      End If
      If _ventasProductos.MaxSecure(Function(p) p.IdaAtributoProducto03).IfNull() = 0 Then
         If _tit.ContainsKey("DescripcionAtributo04") Then _tit.Remove("DescripcionAtributo04")
      End If
      '----------------------------------------------------------------------------------------------

      '-- REQ-32596.- -------------------------------------------------------------------------------
      SetProductosDataSource()
      'Me.dgvProductos.DataSource = Me._ventasProductos.ToArray()
      '----------------------------------------------------------------------------------------------
      'Me.OrdenarGrillaProductos()

      Dim calculaDescuentoRecargo2 As Boolean = Not Reglas.Publicos.Facturacion.FacturacionDescuentoRecargo2CargaManual
      If Reglas.Publicos.Facturacion.FacturacionDescuentosAgrupaCantidadesPorRubro Then
         Dim cantidad As Decimal = Decimal.Parse(Me.txtCantidad.Text.ToString())

         For Each vp As Entidades.VentaProducto In Me._ventasProductos
            If vp.Producto.IdRubro = producto.IdRubro Then
               cantidad = vp.Cantidad
            End If
         Next
         Me._DescuentosRecargosProd = New Reglas.Ventas().DescuentoRecargoSoloCantidadAgrupadaRubro(_clienteE, producto, cantidad, Me._decimalesAMostrar)
         For Each vp As Entidades.VentaProducto In Me._ventasProductos
            If vp.Producto.IdRubro = producto.IdRubro Then
               vp.DescuentoRecargoPorc1 = _DescuentosRecargosProd.DescuentoRecargo1
               If calculaDescuentoRecargo2 Then
                  vp.DescuentoRecargoPorc2 = _DescuentosRecargosProd.DescuentoRecargo2
               End If
            End If
            vp.DescuentoRecargo = CalculaDescuentosProductos(vp.Precio, vp.ImporteImpuestoInterno / vp.Cantidad,
                                                             vp.DescuentoRecargoPorc1, vp.DescuentoRecargoPorc2, vp.Cantidad)
         Next
      End If

      'Se calcula el descuento/recargo gral del Cliente
      _cantLineas = _ventasProductos.Count
      Me._DescRecGralPorc = CalculosDescuentosRecargos1.DescuentoRecargo(_clienteE,
                                                                       cmbTiposComprobantes.ItemSeleccionado(Of Entidades.TipoComprobante),
                                                                       cmbFormaPago.ItemSeleccionado(Of Entidades.VentaFormaPago),
                                                                       _cantLineas)
      Me.txtDescRecGralPorc2.Text = _DescRecGralPorc.ToString("N" + _decimalesEnDescRec.ToString())

      If Me.dgvProductos.SelectedRows.Count > 0 Or Me.dgvProductos.Focused Then
         Me.CargarFoto(Me.dgvProductos.SelectedRows(0).Cells("IdProducto").Value.ToString.Trim(), Decimal.Parse(Me.dgvProductos.SelectedRows(0).Cells("Importe").Value.ToString()))
      Else

         If Me.dgvProductos.Rows.Count > 0 Then
            Me.dgvProductos.FirstDisplayedScrollingRowIndex = Me.dgvProductos.Rows.Count - 1
            Me.dgvProductos.Rows(Me.dgvProductos.Rows.Count - 1).Selected = True
         End If

         Me.dgvProductos.Focus()

         Me.txtPrecioMostrar.Text = _ceroDecimalesAMostrar
         Me.pcbFoto.Image = Nothing
      End If

      Me.bscCodigoProducto2.Focus()
      Me.CalcularDatosDetalle()
      Me.RecalcularSubtotales()
      Me.CalcularTotales()
   End Sub

   Private Sub EliminarLineaObservacion()

      Me._ventasObservaciones.RemoveAt(Me.dgvObservaciones.SelectedRows(0).Index)
      Me.dgvObservaciones.DataSource = Me._ventasObservaciones.ToArray()

   End Sub

   Private Sub OrdenarGrillaProductos()
      With Me.dgvProductos
         If .Columns("NrosLotes").Visible Then
            .Columns("NrosLotes").DisplayIndex = 0
         End If
         .Columns("IdProducto").DisplayIndex = 1
         .Columns("ProductoDesc").DisplayIndex = 2
         .Columns("Cantidad").DisplayIndex = 3
         .Columns("Stock").DisplayIndex = 4
         .Columns("Precio").DisplayIndex = 5
         .Columns("DescuentoRecargoPorc1").DisplayIndex = 6
         .Columns("DescuentoRecargoPorc2").DisplayIndex = 7
         .Columns("PrecioNeto").DisplayIndex = 8
         .Columns("IdTipoImpuesto").DisplayIndex = 9
         .Columns("AlicuotaImpuesto").DisplayIndex = 10
         .Columns("ImporteImpuesto").DisplayIndex = 11
         .Columns("Importe").DisplayIndex = 12

         .Columns("DescuentoRecargoPorc1").Visible = Reglas.Publicos.Facturacion.Rapida.FacturacionRapidaMostrarDesc1
         .Columns("DescuentoRecargoPorc2").Visible = Reglas.Publicos.Facturacion.Rapida.FacturacionRapidaMostrarDesc2
         .Columns("PrecioNeto").Visible = Reglas.Publicos.Facturacion.Rapida.FacturacionRapidaMuestraPrUnitario
         .Columns("NombreListaPrecios").Visible = Reglas.Publicos.Facturacion.Rapida.FacturacionRapidaMuestraListaPrecio
      End With
   End Sub

   Private Sub CambiarEstadoControlesDetalle(Habilitado As Boolean)

      Me.btnLimpiarProducto.Enabled = Habilitado

      Me.bscCodigoProducto2.Enabled = Habilitado
      Me.bscProducto2.Enabled = Habilitado
      Me.txtCantidad.Enabled = Habilitado
      Me.txtPrecio.Enabled = Habilitado

      Me.btnInsertar.Enabled = Habilitado
      Me.btnEliminar.Enabled = Habilitado

      'Por las que le toque habilitar, es factible que no corresponda
      If Habilitado Then
         Me.cmbPorcentajeIva.Enabled = Me._clienteE.CategoriaFiscal.UtilizaImpuestos And Me._categoriaFiscalEmpresa.UtilizaImpuestos
      End If

      If Me.cmbTiposComprobantes.SelectedItem IsNot Nothing Then
         If DirectCast(Me.cmbTiposComprobantes.SelectedItem, Entidades.TipoComprobante).GrabaLibro Or
            DirectCast(Me.cmbTiposComprobantes.SelectedItem, Entidades.TipoComprobante).EsPreElectronico Then
            Me.cmbPorcentajeIva.Enabled = False
         End If
      End If

   End Sub

   Private Sub InsertarChequesGrilla()

      Dim oLineaDetalle As Entidades.Cheque = New Entidades.Cheque()

      With oLineaDetalle
         .IdSucursal = actual.Sucursal.Id
         .NumeroCheque = Integer.Parse(Me.txtNroCheque.Text)
         .Banco = New Reglas.Bancos().GetUno(Integer.Parse(Me.bscBancos._filaDevuelta.Cells("idBanco").Value.ToString()))
         .IdBancoSucursal = Integer.Parse(Me.txtSucursalBanco.Text)
         .Localidad.IdLocalidad = Integer.Parse(Me.txtCodPostalCheque.Text)
         .FechaEmision = Me.dtpFechaEmision.Value
         .FechaCobro = Me.dtpFechaCobro.Value
         .Titular = Me.txtTitularCheque.Text
         .Importe = Decimal.Parse(Me.txtImporteCheque.Text)
         .Cliente.IdCliente = _clienteE.IdCliente
         .Cliente.CodigoCliente = _clienteE.CodigoCliente
         .Cuit = Me.txtCuitChequeTercero.Text

         .Usuario = actual.Nombre
         .IdEstadoCheque = Entidades.Cheque.Estados.ENCARTERA

         .IdTipoCheque = Me.cmbTipoCheque.SelectedValue.ToString()
         .NombreTipoCheque = Me.cmbTipoCheque.Text
         .NroOperacion = Me.txtNroOperacion.Text
      End With

      Me._cheques.Add(oLineaDetalle)

      Me.dgvCheques.DataSource = Me._cheques.ToArray()
      Me.dgvCheques.FirstDisplayedScrollingRowIndex = Me.dgvCheques.Rows.Count - 1

      Me.dgvCheques.Refresh()
      Me.LimpiarCamposCheques()
      Me.CalcularPagos(False)

   End Sub

   Private Sub InsertarTarjetaGrilla()
      InsertarTarjetaGrilla(New Reglas.Tarjetas().GetUno(Integer.Parse(Me.cmbTarTarjeta.SelectedValue.ToString())),
                            New Reglas.Bancos().GetUno(Integer.Parse(Me.bscTarBanco._filaDevuelta.Cells("IdBanco").Value.ToString())),
                            Decimal.Parse(Me.txtTarMonto.Text),
                            Integer.Parse(Me.txtTarCuotas.Text),
                            Integer.Parse(Me.txtTarNumeroLote.Text),
                            Integer.Parse(Me.txtTarNumeroCupon.Text))
   End Sub
   Private Sub InsertarTarjetaGrilla(tarjeta As Entidades.Tarjeta, banco As Entidades.Banco, monto As Decimal, cuotas As Integer, lote As Integer, numeroCupon As Integer)

      Dim oLineaDetalle As Entidades.VentaTarjeta = New Entidades.VentaTarjeta()

      With oLineaDetalle
         .IdSucursal = actual.Sucursal.Id
         .Tarjeta = tarjeta
         .Banco = banco
         .Monto = monto
         .Cuotas = cuotas
         .NumeroLote = lote
         .NumeroCupon = numeroCupon
         .Usuario = actual.Nombre
      End With

      Me._tarjetas.Add(oLineaDetalle)

      Me.dgvTarjetas.DataSource = Me._tarjetas.ToArray()
      Me.dgvTarjetas.FirstDisplayedScrollingRowIndex = Me.dgvTarjetas.Rows.Count - 1

      Me.dgvTarjetas.Refresh()
      Me.LimpiarCamposTarjetas()
      Me.CalcularPagos(_recalcularEfectivoAlCargarTarjeta)

   End Sub
   Private Function InsertarTarjetaTeclaRapidaF3() As Boolean
      Me._tarjetas.Clear()
      Dim tarjeta As Entidades.Tarjeta
      Dim banco As Entidades.Banco
      Dim cuotas As Integer
      Try
         tarjeta = New Reglas.Tarjetas().GetUno(Reglas.Publicos.Facturacion.FacturacionTarjetaAutomatico)
         banco = New Reglas.Bancos().GetUno(Reglas.Publicos.Facturacion.FacturacionBancoTarjetaAutomatico)

         cuotas = Math.Max(cmbFormaPago.ItemSeleccionado(Of Entidades.VentaFormaPago).CantidadCuotas, 1)
      Catch ex As Exception
         Throw New Exception(String.Format("Error guardando automáticamente con TARJETA (F3):", ex.Message), ex)
      End Try

      If ShowPregunta(String.Format("El pago se realizara totalmente en con TARJETA{0}{0}Tarjeta: {2}{0}Banco: {1}{0}Cuotas:{3}{0}{0}¿Desea continuar?",
                                    Environment.NewLine, banco.NombreBanco, tarjeta.NombreTarjeta, cuotas)) = Windows.Forms.DialogResult.Yes Then
         InsertarTarjetaGrilla(tarjeta, banco, Decimal.Parse(txtTotalGeneral.Text), cuotas, 0, 0)
         Return True
      Else
         Return False
      End If

   End Function
   'Private Function InsertarTarjetaTeclaRapidaF3() As Boolean
   '   Try
   '      Dim oLineaDetalle As Entidades.VentaTarjeta = New Entidades.VentaTarjeta()
   '      Dim valida As Boolean = False
   '      With oLineaDetalle
   '         .IdSucursal = actual.Sucursal.Id
   '         .Tarjeta = New Reglas.Tarjetas().GetUno(Publicos.FacturacionTarjetaAutomatico)
   '         .Banco = New Reglas.Bancos().GetUno(Publicos.FacturacionBancoTarjetaAutomatico)
   '         .Monto = Decimal.Parse(txtTotalGeneral.Text)
   '         .Cuotas = 1
   '         .NumeroCupon = 0
   '         .Usuario = actual.Nombre
   '      End With

   '      Me._tarjetas.Add(oLineaDetalle)

   '      Me.dgvTarjetas.DataSource = Me._tarjetas.ToArray()
   '      Me.dgvTarjetas.FirstDisplayedScrollingRowIndex = Me.dgvTarjetas.Rows.Count - 1

   '      Me.dgvTarjetas.Refresh()

   '      Me.CalcularPagos(_recalcularEfectivoAlCargarTarjeta)

   '      Return True

   '   Catch ex As Exception
   '      MessageBox.Show(ex.Message + " " + ", En Tecla Rapida F3", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
   '      Return False
   '   End Try

   'End Function

   Private Sub CalcularDiferenciaDePago()
      Me.txtDiferencia.Text = (Decimal.Parse(Me.txtTotalGeneral.Text) - Decimal.Parse(Me.txtTotalPago.Text)).ToString("#,##0." + New String("0"c, Me._decimalesAMostrar))
   End Sub

   Private Function ValidarInsertarCheques() As Boolean

      '# Valido que se haya seleccionado un cliente
      If Not Me.bscCodigoCliente.Selecciono And Not Me.bscCliente.Selecciono Then
         ShowMessage("Debe seleccionar un Cliente.")
         Me.bscCodigoCliente.Focus()
         Return False
      End If

      If Decimal.Parse(Me.txtImporteCheque.Text) <= 0 Then
         MessageBox.Show("No puede ingresar un cheque con importe cero.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
         Me.txtImporteCheque.Focus()
         Return False
      End If

      If Decimal.Parse(Me.txtNroCheque.Text) = 0 Then
         MessageBox.Show("El número de cheque no puede ser cero.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
         Me.txtNroCheque.Focus()
         Return False
      End If

      If Not Me.bscBancos.Selecciono Then
         MessageBox.Show("Debe seleccionar un Banco.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
         Me.bscBancos.Focus()
         Return False
      End If

      If Decimal.Parse(Me.txtSucursalBanco.Text) < 0 Then
         MessageBox.Show("La Sucursal del Banco es inválida.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
         Me.txtSucursalBanco.Focus()
         Return False
      End If

      If Integer.Parse(Me.txtCodPostalCheque.Text) = 0 Then
         MessageBox.Show("Debe ingresar un C.P. para el cheque.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
         Me.txtCodPostalCheque.Focus()
         Return False
      Else
         If Not New Reglas.Localidades().Existe(Integer.Parse(Me.txtCodPostalCheque.Text)) Then
            MessageBox.Show("No existe la localidad del Cheque.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Me.txtCodPostalCheque.Focus()
            Return False
         End If
      End If


      '# Valido que se haya seleccionado un cliente
      If Not Me.bscCodigoCliente.Selecciono And Not Me.bscCliente.Selecciono Then
         MessageBox.Show("Debe seleccionar un Cliente.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
         Me.bscCodigoCliente.Focus()
         Return False
      End If

      '# Validación del CUIT
      If String.IsNullOrEmpty(Me.txtCuitChequeTercero.Text) Then
         ShowMessage("Debe ingresar un Nro. CUIT para el Cheque.")
         Return False
      Else

         Dim result As Reglas.Validaciones.ValidacionResult
         result = Reglas.Validaciones.Impositivo.ValidarIdFiscal.Instancia.Validar(New Reglas.Validaciones.Impositivo.DatosValidacionFiscal() _
                                                                                     With {.IdFiscal = txtCuitChequeTercero.Text,
                                                                                           .SolicitaCUIT = True}) '# Siempre solicitamos el CUIT al insertar el cheque por la nueva Alternative Key en BD
         If result.Error Then
            txtCuitChequeTercero.Focus()
            ShowMessage(result.MensajeError)
            Return False
         End If

      End If

      'controlo que no se repita el cheque ingresado
      Dim ent As Entidades.Cheque
      For i As Integer = 0 To Me._cheques.Count - 1
         ent = Me._cheques(i)
         If ent.NumeroCheque = Integer.Parse(Me.txtNroCheque.Text) And
                  ent.Banco.IdBanco = Integer.Parse(Me.bscBancos._filaDevuelta.Cells("idBanco").Value.ToString()) And
                  ent.IdBancoSucursal = Integer.Parse(Me.txtSucursalBanco.Text) And
                  ent.Localidad.IdLocalidad = Integer.Parse(Me.txtCodPostalCheque.Text) Then
            MessageBox.Show("El cheque ya esta ingresado.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
         End If
      Next

      '# Tipo de Cheque
      If Me.cmbTipoCheque.SelectedIndex = -1 Then
         Me.cmbTipoCheque.Focus()
         ShowMessage("ATENCIÓN: No seleccionó un Tipo de Cheque.")
         Return False
      End If

      If Me.cmbTipoCheque.SelectedIndex <> -1 Then
         If DirectCast(Me.cmbTipoCheque.SelectedItem, Entidades.TiposCheques).SolicitaNroOperacion AndAlso
            String.IsNullOrEmpty(Me.txtNroOperacion.Text) Then
            Me.txtNroOperacion.Focus()
            ShowMessage("ATENCIÓN: Debe ingresar un Número de Operación para el Tipo de Cheque seleccionado.")
            Return False
         End If
      End If

      Return True

   End Function

   Private Function ValidarInsertarTarjeta() As Boolean

      If Me.cmbTarTarjeta.SelectedIndex = -1 Then
         MessageBox.Show("Debe seleccionar una Tarjeta.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
         Me.cmbTarTarjeta.Focus()
         Return False
      End If

      If Not Me.bscTarBanco.Selecciono Then
         MessageBox.Show("Debe seleccionar un Banco.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
         Me.bscTarBanco.Focus()
         Return False
      End If

      If Decimal.Parse(Me.txtTarMonto.Text) <= 0 Then
         MessageBox.Show("No puede ingresar el importe menor a cero.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
         Me.txtTarMonto.Focus()
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

      'controlo que no se repita la tarjeta ingresada
      For Each ent As Entidades.VentaTarjeta In Me._tarjetas
         If ent.Tarjeta.IdTarjeta = Integer.Parse(Me.cmbTarTarjeta.SelectedValue.ToString()) And
                  ent.Banco.IdBanco = Integer.Parse(Me.bscTarBanco._filaDevuelta.Cells("IdBanco").Value.ToString()) Then
            MessageBox.Show("La tarjeta ya fue ingresada.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
         End If
      Next

      Return True
   End Function

   'Private Sub PresionarTab(e As System.Windows.Forms.KeyEventArgs)
   '   If e.KeyCode = Keys.Enter Then
   '      Me.ProcessTabKey(True)
   '   End If
   'End Sub

   Private Function GetVendedorCombo(id As Integer) As Object
      Dim empleados As List(Of Entidades.Empleado) = DirectCast(Me.cmbVendedor.DataSource, List(Of Entidades.Empleado))
      For Each emp As Entidades.Empleado In empleados
         If id = emp.IdEmpleado Then
            Return emp
         End If
      Next
      Return Nothing
   End Function

   Private Sub RecalcularTodo(metodoLlamador As FacturacionV2.MetodoLlamador, oLista As Boolean)

      Try

         If Me._ventasProductos IsNot Nothing Then

            'Dim oProductos As Reglas.ProductosSucursales = New Reglas.ProductosSucursales()
            'Dim pro1 As Entidades.ProductoSucursal

            Dim oProductos As Reglas.Productos = New Reglas.Productos()
            Dim ProdDT As DataTable


            Dim DescRec1 As Decimal
            Dim DescRec2 As Decimal
            Dim PrecioNeto As Decimal
            Dim PrecioPorEmbalaje As Boolean
            Dim precioParaDescuento As Decimal
            Dim precioAnterior As Decimal
            Dim seModificoElPrecioManualmente As Boolean
            Dim cargoPrecioDesdeLaBase As Boolean
            Dim precioMonedaLocalConIVA As Decimal
            Dim precioMonedaLocalConSinIVA As Decimal

            For Each pro As Entidades.VentaProducto In Me._ventasProductos
               'voy a controlar si se modifico el precio del producto manualmente
               seModificoElPrecioManualmente = pro.ModificoPrecioManualmente
               'redondeo el valor a 2 para despues compararlo ya que pueden haber diferencia de centavos luego.
               precioAnterior = Decimal.Round(pro.Precio, 2)

               cargoPrecioDesdeLaBase = False
               '-- REQ-33090.- ---------------------------------------------------------------------------------------
               Dim cListaPrecio As New Integer
               If oLista AndAlso pro.IdListaPreciosAux > -1 Then
                  '-- 
                  pro.IdListaPrecios = pro.IdListaPreciosAux
                  pro.Precio = pro.PrecioAux
                  cListaPrecio = pro.IdListaPreciosAux
               Else
                  cListaPrecio = DirectCast(Me.cmbListaDePrecios.SelectedItem, Entidades.ListaDePrecios).IdListaPrecios
               End If
               'obtengo el producto de la base de datos, incluyendo el precio de la lista que se selecciono
               ProdDT = oProductos.GetPorCodigo(pro.Producto.IdProducto, actual.Sucursal.Id, cListaPrecio, "VENTAS",,,,,,,,,,, True)
               '------------------------------------------------------------------------------------------------------

               If pro.TipoOperacion <> Entidades.Producto.TiposOperaciones.NORMAL Then
                  ProdDT.Rows(0)("PrecioVentaConIVA") = 0
                  ProdDT.Rows(0)("PrecioVentaSinIVA") = 0
               End If

               If Integer.Parse(ProdDT.Rows(0)("IdMoneda").ToString()) = 2 Then
                  precioMonedaLocalConIVA = Decimal.Round(Decimal.Parse(ProdDT.Rows(0)("PrecioVentaConIVA").ToString()) * Decimal.Parse(Me.txtCotizacionDolar.Text), 2)
                  precioMonedaLocalConSinIVA = Decimal.Round(Decimal.Parse(ProdDT.Rows(0)("PrecioVentaSinIVA").ToString()) * Decimal.Parse(Me.txtCotizacionDolar.Text), 2)
               Else
                  precioMonedaLocalConIVA = Decimal.Round(Decimal.Parse(ProdDT.Rows(0)("PrecioVentaConIVA").ToString()), 2)
                  precioMonedaLocalConSinIVA = Decimal.Round(Decimal.Parse(ProdDT.Rows(0)("PrecioVentaSinIVA").ToString()), 2)
               End If

               PrecioPorEmbalaje = Boolean.Parse(ProdDT.Rows(0)("PrecioPorEmbalaje").ToString())

               If PrecioPorEmbalaje Then
                  precioMonedaLocalConIVA = Decimal.Round(precioMonedaLocalConIVA / Integer.Parse(ProdDT.Rows(0)("Embalaje").ToString()), 2)
                  precioMonedaLocalConSinIVA = Decimal.Round(precioMonedaLocalConSinIVA / Integer.Parse(ProdDT.Rows(0)("Embalaje").ToString()), 2)
               End If

               'controlo si el precio anterior es igual a alguno de los precios con o sin IVA, el redondeo es a 2 por una cuestion de comparacion
               If metodoLlamador <> FacturacionV2.MetodoLlamador.CambioListaDePrecibos And metodoLlamador <> FacturacionV2.MetodoLlamador.CambioFormaDePago Then
                  If Not (precioAnterior = precioMonedaLocalConIVA Or precioAnterior = precioMonedaLocalConSinIVA) Then
                     seModificoElPrecioManualmente = True
                  End If
               End If

               'si no se modifico el precio manualmente lo cambio
               If Not seModificoElPrecioManualmente And (metodoLlamador = FacturacionV2.MetodoLlamador.CambioListaDePrecibos Or
                                                         metodoLlamador = FacturacionV2.MetodoLlamador.CambioCategoriaFiscal Or
                                                         metodoLlamador = FacturacionV2.MetodoLlamador.CambioFormaDePago
                                                         ) Then
                  If (Not Me._clienteE.CategoriaFiscal.IvaDiscriminado Or Not Me._categoriaFiscalEmpresa.IvaDiscriminado) And
                     Me._clienteE.CategoriaFiscal.UtilizaImpuestos And Me._categoriaFiscalEmpresa.UtilizaImpuestos And
                     DirectCast(Me.cmbTiposComprobantes.SelectedItem, Entidades.TipoComprobante).UtilizaImpuestos Then
                     pro.Precio = Decimal.Parse(ProdDT.Rows(0)("PrecioVentaConIVA").ToString())
                     cargoPrecioDesdeLaBase = True
                  Else
                     pro.Precio = Decimal.Parse(ProdDT.Rows(0)("PrecioVentaSinIVA").ToString())
                     cargoPrecioDesdeLaBase = True
                  End If

                  If DirectCast(Me.cmbFormaPago.SelectedItem, Eniac.Entidades.VentaFormaPago).AplicanOfertas Then


                     Dim oferta As Entidades.ProductoOferta = New Reglas.ProductosOfertas().GetOfertaVigente(dtpFecha.Value.Date, pro.Producto.IdProducto,
                                                                                       Reglas.Base.AccionesSiNoExisteRegistro.Nulo)

                     If oferta IsNot Nothing Then
                        _nroOferta = oferta.IdOferta

                        If (Not Me._clienteE.CategoriaFiscal.IvaDiscriminado Or Not Me._categoriaFiscalEmpresa.IvaDiscriminado) And
                     Me._clienteE.CategoriaFiscal.UtilizaImpuestos And Me._categoriaFiscalEmpresa.UtilizaImpuestos And
                     DirectCast(Me.cmbTiposComprobantes.SelectedItem, Entidades.TipoComprobante).UtilizaImpuestos Then
                           pro.Precio = oferta.PrecioOferta
                        Else
                           pro.Precio = Reglas.CalculosImpositivos.ObtenerPrecioSinImpuestos(oferta.PrecioOferta, pro.Producto.Alicuota,
                                                                         pro.PorcImpuestoInterno, pro.ImporteImpuestoInterno, pro.OrigenPorcImpInt)
                        End If
                     End If
                  End If
               Else
                  If metodoLlamador = FacturacionV2.MetodoLlamador.CambioCategoriaFiscal Then
                     If _ultimaCategoriaFiscalSeleccionada.IvaDiscriminado <> _clienteE.CategoriaFiscal.IvaDiscriminado Then
                        If (Not Me._clienteE.CategoriaFiscal.IvaDiscriminado Or Not Me._categoriaFiscalEmpresa.IvaDiscriminado) And
                           Me._clienteE.CategoriaFiscal.UtilizaImpuestos And Me._categoriaFiscalEmpresa.UtilizaImpuestos And
                           DirectCast(Me.cmbTiposComprobantes.SelectedItem, Entidades.TipoComprobante).UtilizaImpuestos Then
                           pro.Precio = Reglas.CalculosImpositivos.ObtenerPrecioConImpuestos(pro.Precio, pro.Producto)
                        Else
                           pro.Precio = Reglas.CalculosImpositivos.ObtenerPrecioSinImpuestos(pro.Precio, pro.Producto)
                        End If
                     End If
                  End If
               End If

               If Integer.Parse(ProdDT.Rows(0)("IdMoneda").ToString()) = 2 And cargoPrecioDesdeLaBase Then
                  pro.Precio = Decimal.Round(pro.Precio * Decimal.Parse(Me.txtCotizacionDolar.Text), Me._valorRedondeo)
               End If

               If PrecioPorEmbalaje And cargoPrecioDesdeLaBase Then
                  pro.Precio = pro.Precio / Integer.Parse(ProdDT.Rows(0)("Embalaje").ToString())
               End If

               If Not Me._clienteE.CategoriaFiscal.IvaDiscriminado Or Not Me._categoriaFiscalEmpresa.IvaDiscriminado Then
                  If DirectCast(Me.cmbTiposComprobantes.SelectedItem, Entidades.TipoComprobante).GrabaLibro Or
                     DirectCast(Me.cmbTiposComprobantes.SelectedItem, Entidades.TipoComprobante).EsPreElectronico Or
                     Reglas.Publicos.Facturacion.FacturacionDescuentoImpIntIgualado Then
                     precioParaDescuento = pro.Precio - (pro.ImporteImpuestoInterno / pro.Cantidad)
                  Else
                     precioParaDescuento = pro.Precio
                  End If
                  ''precioParaDescuento = precioProducto - (impuestoInterno / cantidad)
               Else
                  precioParaDescuento = pro.Precio
               End If

               'Calculo el Nuevo Descuento/Recargo
               DescRec1 = Decimal.Round((precioParaDescuento * pro.DescuentoRecargoPorc1 / 100), Me._valorRedondeo)
               DescRec2 = Decimal.Round(((precioParaDescuento + DescRec1) * pro.DescuentoRecargoPorc2 / 100), Me._valorRedondeo)

               pro.DescuentoRecargo = (DescRec1 + DescRec2) * pro.Cantidad

               'Calculo el Nuevo Precio Neto
               PrecioNeto = pro.Precio + DescRec1 + DescRec2
               PrecioNeto = Decimal.Round(PrecioNeto * (1 + (Decimal.Parse(Me.txtDescRecGralPorc2.Text) / 100)), Me._valorRedondeo)

               pro.PrecioNeto = PrecioNeto

               pro.ImporteTotal = (pro.Precio * pro.Cantidad) + pro.DescuentoRecargo

               If metodoLlamador = FacturacionV2.MetodoLlamador.CambioListaDePrecibos Then
                  Dim lp = cmbListaDePrecios.ItemSeleccionado(Of Entidades.ListaDePrecios)()
                  pro.IdListaPrecios = lp.IdListaPrecios
                  pro.NombreListaPrecios = lp.NombreListaPrecios
               End If

            Next

            '-- REQ-32596.- -------------------------------------------------------------------------------
            SetProductosDataSource()
            'Me.dgvProductos.DataSource = Me._ventasProductos.ToArray()
            '----------------------------------------------------------------------------------------------
            If Me.dgvProductos.Rows.Count > 0 Then
               Me.dgvProductos.FirstDisplayedScrollingRowIndex = Me.dgvProductos.Rows.Count - 1
            End If

            Me.dgvProductos.Refresh()


            _cantLineas = _ventasProductos.Count
            If Publicos.ClienteDRporGrabaLibro AndAlso (Me.bscCodigoCliente.Selecciono Or Me.bscCliente.Selecciono) Then
               Me._DescRecGralPorc = CalculosDescuentosRecargos1.DescuentoRecargo(_clienteE,
                                                                                  cmbTiposComprobantes.ItemSeleccionado(Of Entidades.TipoComprobante),
                                                                                  cmbFormaPago.ItemSeleccionado(Of Entidades.VentaFormaPago),
                                                                                  _cantLineas)

               Me.txtDescRecGralPorc2.Text = _DescRecGralPorc.ToString("N" + _decimalesEnDescRec.ToString())
            End If

            Me.CalcularTotalProducto()

            Me.LimpiarCamposProductos()

            Me.CalcularTotales()
            Me.CalcularDatosDetalle()
            ' Me.CalcularTotales()

            Me.tsbGrabar.Enabled = True
            If Reglas.Publicos.Facturacion.FacturacionPermitePosicionarNombreProducto Then
               Me.bscProducto2.Focus()
            Else
               Me.bscCodigoProducto2.Focus()
            End If
         End If

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
      End Try

   End Sub

   'Private Sub RecalcularTodo(metodoLlamador As FacturacionV2.MetodoLlamador)

   '   Try

   '      If Me._ventasProductos IsNot Nothing Then

   '         Dim oProductos As Reglas.Productos = New Reglas.Productos()
   '         Dim ProdDT As DataTable

   '         Dim DescRec1 As Decimal, DescRec2 As Decimal
   '         Dim PrecioNeto As Decimal
   '         Dim precioAnterior As Decimal
   '         Dim seModificoElPrecioManualmente As Boolean

   '         For Each pro As Entidades.VentaProducto In Me._ventasProductos

   '            'voy a controlar si se modifico el precio del producto manualmente
   '            seModificoElPrecioManualmente = False
   '            precioAnterior = pro.Precio

   '            'obtengo el producto de la base de datos, incluyendo el precio de la lista que se selecciono
   '            ProdDT = oProductos.GetPorCodigo(pro.Producto.IdProducto, actual.Sucursal.Id, DirectCast(Me.cmbListaDePrecios.SelectedItem, Entidades.ListaDePrecios).IdListaPrecios, "VENTAS")

   '            'controlo si el precio anterior es igual a alguno de los precios con o sin IVA
   '            If Not (precioAnterior = Decimal.Parse(ProdDT.Rows(0)("PrecioVentaConIVA").ToString()) Or precioAnterior = Decimal.Parse(ProdDT.Rows(0)("PrecioVentaSinIVA").ToString())) Then
   '               seModificoElPrecioManualmente = True
   '            End If

   '            If (Not Me._clienteE.CategoriaFiscal.IvaDiscriminado Or Not Me._categoriaFiscalEmpresa.IvaDiscriminado) And _
   '               Me._clienteE.CategoriaFiscal.UtilizaImpuestos And Me._categoriaFiscalEmpresa.UtilizaImpuestos And
   '               DirectCast(Me.cmbTiposComprobantes.SelectedItem, Entidades.TipoComprobante).UtilizaImpuestos Then
   '               'si no se modifico el precio manualmente lo cambio
   '               If Not seModificoElPrecioManualmente And metodoLlamador = FacturacionV2.MetodoLlamador.CambioTipoDeComprobante Then
   '                  pro.Precio = Decimal.Parse(ProdDT.Rows(0)("PrecioVentaConIVA").ToString())
   '                  If pro.AlicuotaImpuesto <> pro.Producto.Alicuota Then
   '                     pro.Precio = Reglas.CalculosImpositivos.ObtenerPrecioSinImpuestos(pro.Precio, pro.Producto.Alicuota,
   '                                                                                       pro.PorcImpuestoInterno, pro.Producto.ImporteImpuestoInterno, pro.OrigenPorcImpInt)
   '                     pro.Precio = Reglas.CalculosImpositivos.ObtenerPrecioConImpuestos(pro.Precio, pro.AlicuotaImpuesto,
   '                                                                                       pro.PorcImpuestoInterno, pro.Producto.ImporteImpuestoInterno, pro.OrigenPorcImpInt)
   '                  End If
   '               End If
   '            Else
   '               'si no se modifico el precio manualmente lo cambio
   '               If Not seModificoElPrecioManualmente And metodoLlamador = FacturacionV2.MetodoLlamador.CambioTipoDeComprobante Then
   '                  pro.Precio = Decimal.Parse(ProdDT.Rows(0)("PrecioVentaSinIVA").ToString())
   '               End If
   '            End If

   '            'Calculo el Nuevo Descuento/Recargo
   '            DescRec1 = Decimal.Round((pro.Precio * pro.DescuentoRecargoPorc1 / 100), Me._valorRedondeo)
   '            DescRec2 = Decimal.Round(((pro.Precio + DescRec1) * pro.DescuentoRecargoPorc2 / 100), Me._valorRedondeo)

   '            pro.DescuentoRecargo = (DescRec1 + DescRec2) * pro.Cantidad

   '            'Calculo el Nuevo Precio Neto
   '            PrecioNeto = pro.Precio + DescRec1 + DescRec2
   '            PrecioNeto = Decimal.Round(PrecioNeto * (1 + (Decimal.Parse(Me.txtDescRecGralPorc2.Text) / 100)), Me._valorRedondeo)

   '            pro.PrecioNeto = PrecioNeto

   '            pro.ImporteTotal = (pro.Precio * pro.Cantidad) + pro.DescuentoRecargo

   '         Next

   '         Me.dgvProductos.DataSource = _ventasProductos.ToArray()
   '         If Me.dgvProductos.Rows.Count > 0 Then
   '            Me.dgvProductos.FirstDisplayedScrollingRowIndex = Me.dgvProductos.Rows.Count - 1
   '         End If

   '         Me.dgvProductos.Refresh()
   '         Me.CalcularTotalProducto()
   '         Me.LimpiarCamposProductos()
   '         Me.CalcularTotales()
   '         Me.CalcularDatosDetalle()
   '         ' Me.CalcularTotales()

   '         Me.tsbGrabar.Enabled = True
   '         Me.bscCodigoProducto2.Focus()
   '      End If

   '   Catch ex As Exception
   '      MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
   '   End Try

   'End Sub

   Private Sub CargarProximoNumero()

      If Me.txtLetra.Text <> "" Then

         Dim oImpresora As Entidades.Impresora
         Dim oVentasNumeros As New Reglas.VentasNumeros
         Dim CentroEmisor As Short

         'CentroEmisor = oImpresoras.GetPorSucursalPC(actual.Sucursal.Id, My.Computer.Name, Me.EsComprobanteFiscal()).CentroEmisor

         oImpresora = New Reglas.Impresoras().GetPorSucursalPCTipoComprobante(actual.Sucursal.Id, My.Computer.Name, Me.cmbTiposComprobantes.SelectedValue.ToString())

         CentroEmisor = oImpresora.CentroEmisor

         Me.txtNumeroPosible.Text = oVentasNumeros.GetProximoNumero(actual.Sucursal,
                                                               DirectCast(Me.cmbTiposComprobantes.SelectedItem, Entidades.TipoComprobante).IdTipoComprobante,
                                                               Me.txtLetra.Text,
                                                               CentroEmisor).ToString()
         Me.txtNumeroPosible.Tag = oImpresora.Marca

      Else

         Me.txtNumeroPosible.Text = ""
         Me.txtNumeroPosible.Tag = ""

      End If

      Me.CargarLineasPermitidas()

      Me.OrdenarGrillaProductos()

   End Sub

   Private Sub CargarLineasPermitidas()

      If Me.cmbTiposComprobantes.SelectedValue IsNot Nothing Then

         Dim oComprobanteLetra As Entidades.TipoComprobanteLetra
         oComprobanteLetra = New Reglas.TiposComprobantesLetras().GetUno(Me.cmbTiposComprobantes.SelectedValue.ToString(), Me.txtLetra.Text)

         'Toma las Lineas del reporte especifico.
         If oComprobanteLetra.TipoComprobante.IdTipoComprobante <> "" Then

            Me._cantMaxItems = oComprobanteLetra.CantidadItemsProductos
            Me._cantMaxItemsObserv = oComprobanteLetra.CantidadItemsObservaciones
            Me._imprime = oComprobanteLetra.Imprime

            'Toma las Lineas del Comprobante.
         Else

            Me._cantMaxItems = DirectCast(Me.cmbTiposComprobantes.SelectedItem, Entidades.TipoComprobante).CantidadMaximaItems
            Me._cantMaxItemsObserv = DirectCast(Me.cmbTiposComprobantes.SelectedItem, Entidades.TipoComprobante).CantidadMaximaItemsObserv
            Me._imprime = DirectCast(Me.cmbTiposComprobantes.SelectedItem, Entidades.TipoComprobante).Imprime

         End If

      Else

         Me._cantMaxItems = 0
         Me._cantMaxItemsObserv = 0
         Me._imprime = False

      End If

      If Me._cantMaxItemsObserv > 0 Then
         If Not Me.tbcDetalle.TabPages.Contains(Me.tbpObservaciones) Then
            Me.tbcDetalle.TabPages.Add(Me.tbpObservaciones)
         End If
      Else
         If Me.tbcDetalle.TabPages.Contains(Me.tbpObservaciones) Then
            Me._ventasObservaciones.Clear()
            Me.dgvObservaciones.DataSource = Me._ventasObservaciones.ToArray()
            Me.tbcDetalle.TabPages.Remove(Me.tbpObservaciones)
         End If
      End If

   End Sub

   Private Sub RecalcularSubtotales()

      Me._subTotales.Clear()
      Dim olineaTotales As Entidades.VentaImpuesto
      Dim entro As Boolean = False

      Dim descRec1 As Decimal = 0
      Dim descRec2 As Decimal = 0
      Dim importeCosto As Decimal = 0
      Dim importeBruto As Decimal = 0
      Dim importeNeto As Decimal = 0
      Dim importeNetoTotal As Decimal = 0
      Dim Utilidad As Decimal = 0
      Dim impuestoInterno As Decimal = 0

      For Each dr As Entidades.VentaProducto In Me._ventasProductos

         impuestoInterno = dr.ImporteImpuestoInterno

         Dim precioParaDescuento As Decimal = dr.Precio
         'Se anula esta lógica porque no se permite más facturación con ImpInt fijos.
         'If Not Me._clienteE.CategoriaFiscal.IvaDiscriminado Or Not Me._categoriaFiscalEmpresa.IvaDiscriminado Then
         '   If DirectCast(Me.cmbTiposComprobantes.SelectedItem, Entidades.TipoComprobante).GrabaLibro Or
         '      DirectCast(Me.cmbTiposComprobantes.SelectedItem, Entidades.TipoComprobante).EsPreElectronico Then
         '      precioParaDescuento = dr.Precio - (impuestoInterno / dr.Cantidad)
         '   Else
         '      precioParaDescuento = dr.Precio
         '   End If
         'Else
         '   precioParaDescuento = dr.Precio
         'End If

         descRec1 = Decimal.Round(precioParaDescuento * dr.DescuentoRecargoPorc1 / 100, Me._valorRedondeo)
         descRec2 = Decimal.Round((precioParaDescuento + descRec1) * dr.DescuentoRecargoPorc2 / 100, Me._valorRedondeo)

         'descRec1 = Decimal.Round(dr.Precio * dr.DescuentoRecargoPorc1 / 100, Me._valorRedondeo)
         'descRec2 = Decimal.Round((dr.Precio + descRec1) * dr.DescuentoRecargoPorc2 / 100, Me._valorRedondeo)


         Dim costo As Decimal = 0
         costo = dr.Costo

         'Dim costo As Decimal = New Reglas.ProductosSucursales().GetUno(dr.IdSucursal, dr.IdProducto).PrecioCosto

         'If Publicos.PreciosConIVA Then
         '   'Le quito el IVA que el producto tiene en forma predeterminada.
         '   costo = Decimal.Round(costo / (1 + dr.AlicuotaImpuesto / 100), Me._valorRedondeo)
         'End If

         'If dr.Producto.Moneda.IdMoneda = 2 Then
         '   costo = costo * Decimal.Parse(Me.txtCotizacionDolar.Text.ToString())
         'End If

         'If dr.Producto.PrecioPorEmbalaje Then
         '   dr.Costo = costo / dr.Producto.Embalaje
         'Else
         '   dr.Costo = costo
         'End If

         importeCosto = dr.Costo * dr.Cantidad
         importeBruto = (dr.Precio + descRec1 + descRec2) * dr.Cantidad
         importeNeto = dr.PrecioNeto * dr.Cantidad

         If Not Me._clienteE.CategoriaFiscal.IvaDiscriminado Or Not Me._categoriaFiscalEmpresa.IvaDiscriminado Then
            'importeBruto = Decimal.Round((importeBruto - impuestoInterno) / (1 + dr.AlicuotaImpuesto / 100), Me._valorRedondeo)
            importeBruto = Decimal.Round(Reglas.CalculosImpositivos.ObtenerPrecioSinImpuestos(importeBruto, dr.AlicuotaImpuesto, dr.PorcImpuestoInterno, dr.Producto.ImporteImpuestoInterno, dr.OrigenPorcImpInt),
                                         Me._valorRedondeo)
            importeNeto = Decimal.Round((importeNeto - impuestoInterno) / (1 + dr.AlicuotaImpuesto / 100), Me._valorRedondeo)
            'importeBruto = Decimal.Round(importeBruto / (1 + dr.AlicuotaImpuesto / 100), Me._valorRedondeo)
            'importeNeto = Decimal.Round(importeNeto / (1 + dr.AlicuotaImpuesto / 100), Me._valorRedondeo)
         End If

         Utilidad += (importeNeto - importeCosto)
         importeNetoTotal += importeNeto

         entro = False

         For Each vi As Entidades.VentaImpuesto In Me._subTotales
            If vi.Alicuota = dr.AlicuotaImpuesto Then
               vi.TipoImpuesto.IdTipoImpuesto = Me._tipoImpuestoIVA

               vi.Bruto += importeBruto
               vi.Neto += importeNeto

               vi.Importe += dr.ImporteImpuesto
               vi.Total += (importeNeto + dr.ImporteImpuesto)
               entro = True
            End If
         Next
         If Not entro Then

            olineaTotales = New Entidades.VentaImpuesto()

            Me.CargarTotales(olineaTotales,
                  Me._tipoImpuestoIVA,
               dr.AlicuotaImpuesto,
               importeBruto,
               importeNeto,
               dr.ImporteImpuesto,
               importeNeto + dr.ImporteImpuesto)

            Me._subTotales.Add(olineaTotales)
         End If

         If impuestoInterno <> 0 Then
            entro = False
            For Each vi As Entidades.VentaImpuesto In Me._subTotales
               If vi.Alicuota = 0 And vi.TipoImpuesto.IdTipoImpuesto = Entidades.TipoImpuesto.Tipos.IMINT Then
                  vi.TipoImpuesto.IdTipoImpuesto = Entidades.TipoImpuesto.Tipos.IMINT

                  vi.Bruto += 0
                  vi.Neto += 0

                  vi.Importe += impuestoInterno
                  vi.Total += impuestoInterno
                  entro = True
               End If
            Next
            If Not entro Then

               olineaTotales = New Entidades.VentaImpuesto()

               Me.CargarTotales(olineaTotales,
                     Entidades.TipoImpuesto.Tipos.IMINT,
                     0,
                     0,
                     0,
                     impuestoInterno,
                     impuestoInterno)

               Me._subTotales.Add(olineaTotales)
            End If
         End If


      Next

      Me.dgvIvas.DataSource = Me._subTotales.ToArray()

      If importeNetoTotal <> 0 Then

         Dim PorcentajeUtilidad As Decimal = Decimal.Round(Utilidad / importeNetoTotal * 100, Me._valorRedondeo)

         '# Semaforo para RENTABILIDAD
         txtSemaforoRentabilidad.Text = PorcentajeUtilidad.ToString("##,##0." + New String("0"c, Me._decimalesAMostrar))

         Me.SetearColorSemaforos(txtSemaforoRentabilidad, Entidades.SemaforoVentaUtilidad.TiposSemaforos.RENTABILIDAD)
         Me.txtSemaforoRentabilidad.Key = Utilidad.ToString()

      Else

         Me.txtSemaforoRentabilidad.Text = ""
         Me.txtSemaforoRentabilidad.BackColor = Me.txtLetra.BackColor
         Me.txtSemaforoRentabilidad.ForeColor = Me.txtLetra.ForeColor
         Me.txtSemaforoRentabilidad.Key = "0"

      End If

   End Sub

   Private Function ProductosConLote() As Integer
      Dim Cantidad As Integer = 0
      For Each vp As Entidades.VentaProducto In Me._ventasProductos
         If vp.Producto.Lote Then
            Cantidad += 1
         End If
      Next
      Return Cantidad
   End Function

   Private Sub SetProductosDataSource()
      dgvProductos.DataSource = _ventasProductos.ToArray().OrderBy(Function(x) x.Orden).ToArray()
      AjustarColumnasGrillaProductos()
      ColorearCeldasGrillaProductos()
   End Sub
   Private Sub ColorearCeldasGrillaProductos()
      'Cuando eventualmente se migre DataGridView a Infragistics reemplazar este método por el evento de InitializeRow de IG.

      'Por el momento solo recorro las filas si está habilitado este parametro, ya que solo coloreo cuando es Oferta y así evito ingresar innecesariamente.
      If Reglas.Publicos.FacturacionResaltaProductosEnOferta Then
         For Each dgr In dgvProductos.Rows.OfType(Of DataGridViewRow)
            Dim dr = dgvProductos.FilaSeleccionada(Of Entidades.VentaProducto)(dgr)
            If dr.Producto.EsOferta = "SI" Then
               dgr.Cells(IdProducto.Name).Style.BackColor = Color.Yellow
               dgr.Cells(IdProducto.Name).Style.SelectionBackColor = Color.YellowGreen
               dgr.Cells(IdProducto.Name).Style.SelectionForeColor = Color.Black
               dgr.Cells(ProductoDesc.Name).Style.BackColor = Color.Yellow
               dgr.Cells(ProductoDesc.Name).Style.SelectionBackColor = Color.YellowGreen
               dgr.Cells(ProductoDesc.Name).Style.SelectionForeColor = Color.Black
            End If
         Next
      End If
   End Sub
   Private Sub LimpiarDetalle()

      Me._ventasProductos = Nothing
      Me._ventasProductos = New List(Of Entidades.VentaProducto)
      Me._productosLotes = New List(Of Entidades.VentaProductoLote)

      '-- REQ-32596.- -------------------------------------------------------------------------------
      SetProductosDataSource()
      'Me.dgvProductos.DataSource = Me._ventasProductos.ToArray()
      '----------------------------------------------------------------------------------------------

      'Me.OrdenarGrillaProductos()

      Me._subTotales = Nothing
      Me._subTotales = New List(Of Entidades.VentaImpuesto)
      Me.dgvIvas.DataSource = Me._subTotales.ToArray()

      'Pone todo en cero.
      Me.CalcularTotales()

   End Sub

   'Private Sub AcomodaNumeroOrden()
   '   For Each vp As Entidades.VentaProducto In Me._ventasProductos
   '   Next
   '   For Each vp As Entidades.VentaProductoLote In Me._productosLotes
   '   Next
   'End Sub

   Private Sub CargarComprobantesFacturables(selec As List(Of Entidades.Venta))

      Me._comprobantesSeleccionados = New List(Of Entidades.Venta)

      For Each v As Entidades.Venta In selec
         Me._comprobantesSeleccionados.Add(v)

      Next

      Me.dgvFacturables.DataSource = Me._comprobantesSeleccionados

   End Sub

   Private Sub CargarProductosFacturables(selec As List(Of Entidades.Venta))

      'limpio todos los productos de la grilla
      Me._ventasProductos = Nothing
      Me._ventasProductos = New List(Of Entidades.VentaProducto)

      Dim DescRec1 As Decimal, DescRec2 As Decimal
      Dim PrecioNeto As Decimal

      'creo una coleccion para probar si existe codigos repetidos
      Dim codigos As List(Of String) = New List(Of String)

      Dim Producto As Entidades.Producto

      Dim oSR As Reglas.SubRubros = New Reglas.SubRubros()
      Dim SubR As Entidades.SubRubro

      Dim oCSR As Reglas.ClientesDescuentosSubRubros = New Reglas.ClientesDescuentosSubRubros()
      Dim SubR2 As Entidades.SubRubro

      Dim blnEntrar As Boolean
      Dim blnIncluirFoto As Boolean = True

      Dim CoefVal As Integer = DirectCast(Me.cmbTiposComprobantes.SelectedItem, Entidades.TipoComprobante).CoeficienteValores

      'Si el invocador es una NCRED y A su vez Invoca Un comprobante Positivo debe multiplicar por 1 en lugar de -1.
      'Si es Factura es 1 asi que queda como invoca.
      If CoefVal = -1 And selec.Count > 0 Then
         If selec(0).TipoComprobante.CoeficienteValores = 1 Then
            CoefVal = 1
         End If
      End If

      For Each v As Entidades.Venta In selec

         'En REMITO no tendria sentido que haya carga el descuento.
         'Poner el recargo general solo si cargo uno, si pone mas, se pierde.
         '# Solo si el tilde de modificar manualmente el Desc/Rec no está tildado
         If Not Me.chbModificaDescRecGralPorc.Checked Then
            If selec.Count = 1 And Not v.TipoComprobante.CargaPrecioActual Then
               Me.txtDescRecGralPorc2.Text = v.DescuentoRecargoPorc.ToString("N" + _decimalesEnDescRec.ToString())
            End If
         End If

         For Each vp As Entidades.VentaProducto In v.VentasProductos

            blnEntrar = True

            Producto = New Reglas.Productos().GetUno(vp.Producto.IdProducto, blnIncluirFoto)

            vp.Cantidad = vp.Cantidad * CoefVal

            If vp.Producto.Moneda.IdMoneda = 2 Then
               vp.Costo = Decimal.Round(vp.Costo * Decimal.Parse(Me.txtCotizacionDolar.Text.ToString()), 2)
            End If

            'Los precios en la BASE siempre se guardan SIN IVA

            'Le agrego el IVA porque al momento de la grabacion se lo saca si cumple con esto. Se devuelve SIN IVA
            '1.
            'If Publicos.PreciosConIVA Then
            '   vp.PrecioLista = Decimal.Round((vp.PrecioLista * (1 + vp.AlicuotaImpuesto / 100)), Me._valorRedondeo)
            '   vp.Costo = Decimal.Round((vp.Costo * (1 + vp.AlicuotaImpuesto / 100)), Me._valorRedondeo)
            'End If

            'Indica si el comprobante elegido mantene el precio (PRESUPUESTO) o hay que cargar el actual (REMITO).
            If v.TipoComprobante.CargaPrecioActual Then

               'Si carga el precio actual y el mismo tiene valor. En los productos varios se deja en 0 (cero) para vender aquellos que no se detallan.
               If vp.PrecioLista <> 0 Then
                  'AHORA CAMBIA LA FORMA porque comente "1."
                  If Not Me._clienteE.CategoriaFiscal.IvaDiscriminado Or Not Me._categoriaFiscalEmpresa.IvaDiscriminado Then
                     vp.Precio = Decimal.Round((vp.PrecioLista * (1 + vp.AlicuotaImpuesto / 100)), Me._valorRedondeo)
                  Else
                     vp.Precio = vp.PrecioLista
                  End If

                  Dim PrecioPorEmbalaje As Boolean = vp.Producto.PrecioPorEmbalaje

                  If PrecioPorEmbalaje Then
                     vp.Precio = vp.Precio / vp.Producto.Embalaje
                  End If

               Else
                  blnEntrar = False
                  If Not Me._clienteE.CategoriaFiscal.IvaDiscriminado Or Not Me._categoriaFiscalEmpresa.IvaDiscriminado Then
                     vp.Precio = Decimal.Round((vp.Precio * (1 + vp.AlicuotaImpuesto / 100)), Me._valorRedondeo)
                  End If
               End If

               'En REMITO no tendria sentido que haya carga el descuento.
               'vp.DescuentoRecargo = Decimal.Round((vp.Precio * vp.Cantidad * vp.DescuentoRecargoPorc / 100), Me._valorRedondeo)

               Producto = vp.Producto

               'Cargo el Descuento/Recargo cargado en el subrubro

               If Producto.IdSubRubro > 0 Then
                  SubR = oSR.GetUno(Producto.IdSubRubro)
                  vp.DescuentoRecargoPorc1 = SubR.DescuentoRecargoPorc1

                  'Cargo el Descuento/Recargo cargado en el subrubro especifico para el Cliente
                  SubR2 = oCSR.GetUno(Long.Parse(Me.bscCodigoCliente.Tag.ToString()), Producto.IdSubRubro)
                  vp.DescuentoRecargoPorc2 = SubR2.DescuentoRecargoPorc1
               End If
               '---------------------------------------------------------------------------

            Else

               If Not Me._clienteE.CategoriaFiscal.IvaDiscriminado Or Not Me._categoriaFiscalEmpresa.IvaDiscriminado Then
                  vp.Precio = Decimal.Round((vp.Precio * (1 + vp.AlicuotaImpuesto / 100)), Me._valorRedondeo)
               End If

            End If

            'Calculo el descuento Recargo CON/SIN IVA.
            DescRec1 = Decimal.Round((vp.Precio * vp.DescuentoRecargoPorc1 / 100), Me._valorRedondeo)
            DescRec2 = Decimal.Round(((vp.Precio + DescRec1) * vp.DescuentoRecargoPorc2 / 100), Me._valorRedondeo)

            vp.DescuentoRecargo = (DescRec1 + DescRec2) * vp.Cantidad

            'Calculo el Precio Neto CON/SIN IVA.
            PrecioNeto = vp.Precio + DescRec1 + DescRec2
            PrecioNeto = Decimal.Round(PrecioNeto * (1 + (v.DescuentoRecargoPorc / 100)), Me._valorRedondeo)
            PrecioNeto = Decimal.Round(PrecioNeto * (1 + (Decimal.Parse(Me.txtDescRecGralPorc2.Text) / 100)), Me._valorRedondeo)

            vp.PrecioNeto = PrecioNeto

            vp.ImporteTotal = (vp.Precio * vp.Cantidad) + vp.DescuentoRecargo

            'Solo se unifica en caso de facturar REMITOS, para presupuesto lo dejo separado porque ahora se puede digita separado.
            'Y en caso de NO poder modificar la descripcion del producto

            'If codigos.Contains(vp.Producto.IdProducto) And v.TipoComprobante.CargaPrecioActual And Not Publicos.FacturacionModificaDescripcionProducto And blnEntrar Then

            If codigos.Contains(vp.Producto.IdProducto) And v.TipoComprobante.CargaPrecioActual And Not vp.Producto.PermiteModificarDescripcion And blnEntrar Then
               Me._ventasProductos(codigos.IndexOf(vp.Producto.IdProducto)).Cantidad += vp.Cantidad
               Me._ventasProductos(codigos.IndexOf(vp.Producto.IdProducto)).ImporteTotal = Me._ventasProductos(codigos.IndexOf(vp.Producto.IdProducto)).Cantidad * Me._ventasProductos(codigos.IndexOf(vp.Producto.IdProducto)).Precio
            Else
               Me._numeroOrden += 1
               vp.Orden = Me._numeroOrden
               codigos.Add(vp.Producto.IdProducto)
               Me._ventasProductos.Add(vp)
            End If

         Next

      Next

      'Elimino los de Cantidades en Cero (Puede suceder por una devolucion).
      Dim blnLlegoAlFin As Boolean = False
      Dim Cont As Integer
      Do While Not blnLlegoAlFin And Me._ventasProductos.Count > 0
         Cont = 0
         For Each pro As Entidades.VentaProducto In Me._ventasProductos
            If pro.Cantidad = 0 Then
               'Cada Vez que borro debo volver a Empezar porque se renumeran los indices y si continuo da error
               Me._ventasProductos.RemoveAt(Cont)
               Exit For
            End If
            Cont += 1
         Next
         If Cont = Me._ventasProductos.Count Then
            blnLlegoAlFin = True
         End If
      Loop
      '-- REQ-34669.- ---------------------------------------------------------
      If _ventasProductos.MaxSecure(Function(p) p.IdaAtributoProducto01).IfNull() > 0 Then
         If Not _tit.ContainsKey("DescripcionAtributo01") Then _tit.Add("DescripcionAtributo01", "")
      End If
      If _ventasProductos.MaxSecure(Function(p) p.IdaAtributoProducto02).IfNull() > 0 Then
         If Not _tit.ContainsKey("DescripcionAtributo02") Then _tit.Add("DescripcionAtributo02", "")
      End If
      If _ventasProductos.MaxSecure(Function(p) p.IdaAtributoProducto03).IfNull() > 0 Then
         If Not _tit.ContainsKey("DescripcionAtributo03") Then _tit.Add("DescripcionAtributo03", "")
      End If
      If _ventasProductos.MaxSecure(Function(p) p.IdaAtributoProducto03).IfNull() > 0 Then
         If Not _tit.ContainsKey("DescripcionAtributo04") Then _tit.Add("DescripcionAtributo04", "")
      End If
      '-- REQ-32596.- -------------------------------------------------------------------------------
      SetProductosDataSource()
      'Me.dgvProductos.DataSource = Me._ventasProductos.ToArray()
      '----------------------------------------------------------------------------------------------

      Me.tsbGrabar.Enabled = True

   End Sub

   Private Sub CargarObservacionesFacturables(selec As List(Of Entidades.Venta))

      'No Limpio las Observaciones para que quede el INVOCO.
      'Me._ventasObservaciones = Nothing
      'Me._ventasObservaciones = New List(Of Entidades.VentaObservacion)

      For Each v As Entidades.Venta In selec

         For Each vp As Entidades.VentaObservacion In v.VentasObservaciones
            vp.Linea = Me._ventasObservaciones.Count + 1
            Me._ventasObservaciones.Add(vp)
         Next

      Next

      '# Observaciones generales
      '# Si los Comp. invocados = 1 y tiene OBS General, pisa la OBS General del comprobante origen.
      Dim obsGral As String() = selec.Where(Function(x) Not String.IsNullOrWhiteSpace(x.Observacion)).ToList().ConvertAll(Function(x) x.Observacion).ToArray()

      If DirectCast(Me.cmbTiposComprobantes.SelectedItem, Entidades.TipoComprobante).ImportaObservGrales Then
         For Each obs As String In obsGral
            Dim ventaObs As Entidades.VentaObservacion = New Entidades.VentaObservacion
            ventaObs.Observacion = obs
            ventaObs.Linea = Me._ventasObservaciones.Count + 1

            Me._ventasObservaciones.Add(ventaObs)
         Next
      End If

      Me.dgvObservaciones.DataSource = Me._ventasObservaciones

   End Sub

   Private Sub CalcularDescuentosProductos()

      'Dim DescRec1 As Decimal
      'Dim DescRec2 As Decimal
      'Dim DescRecT As Decimal

      'DescRec1 = Decimal.Parse(Me.txtPrecio.Text) * Decimal.Parse(Me.txtDescRecPorc1.Text) / 100

      'DescRec2 = (Decimal.Parse(Me.txtPrecio.Text) + DescRec1) * Decimal.Parse(Me.txtDescRecPorc2.Text) / 100

      'DescRecT = Decimal.Round((DescRec1 + DescRec2) * Decimal.Parse(Me.txtCantidad.Text), Me._decimalesAMostrar)

      Me.txtDescRec.Text = CalculaDescuentosProductos(Decimal.Parse(Me.txtPrecio.Text),
                                                      Decimal.Parse(txtImpuestoInterno.Text),
                                                      Decimal.Parse(Me.txtDescRecPorc1.Text),
                                                      Decimal.Parse(Me.txtDescRecPorc2.Text),
                                                      Decimal.Parse(Me.txtCantidad.Text)).ToString("##,##0." + New String("0"c, Me._decimalesAMostrar))

      'Me.txtDescRec.Text = DescRecT.ToString("##,##0." + New String("0"c, Me._decimalesAMostrar))

   End Sub

   Private Function CalculaDescuentosProductos(precioProducto As Decimal, impInt As Decimal, descRecPorc1 As Decimal, descRecPorc2 As Decimal, cantidad As Decimal) As Decimal
      Dim DescRec1 As Decimal
      Dim DescRec2 As Decimal
      Dim DescRecT As Decimal

      DescRec1 = Decimal.Parse(Me.txtPrecio.Text) * Decimal.Parse(Me.txtDescRecPorc1.Text) / 100

      DescRec2 = (Decimal.Parse(Me.txtPrecio.Text) + DescRec1) * Decimal.Parse(Me.txtDescRecPorc2.Text) / 100

      DescRecT = Decimal.Round((DescRec1 + DescRec2) * Decimal.Parse(Me.txtCantidad.Text), Me._decimalesAMostrar)

      Return DescRecT
   End Function

   Private Overloads Sub AjustarColumnasGrillaProductos()
      'SI SE DESEA CAMBIAR EL TITULO DE ALGUNA COLUMNA EN PARTICULAR
      'tit("NOMBRECOLUMNA") = "NUEVO HEADER"
      AjustarColumnasGrilla(dgvProductos, _tit)
      DisplayIndexProducto()
   End Sub

   Private Sub DisplayIndexProducto()
      DisplayIndex({NrosLotes, NrosSerie, IdProducto, ProductoDesc, DescripcionAtributo01, DescripcionAtributo02,
                    DescripcionAtributo03, DescripcionAtributo04, Cantidad, Precio,
                    DescuentoRecargo, DescRecGeneral, Stock, Importe, PorcentajeIVA,
                    PrecioLista, Utilidad, Password, CentroEmisor, Costo, Usuario, NroComprobante,
                    TipoDocumento, NroDocumento, IdSucursal, TipoComprobante, letra, Iva})
   End Sub
   Private Sub DisplayIndex(columnas As IEnumerable(Of DataGridViewColumn))
      Dim pos = 0
      columnas.ToList().ForEach(Sub(c)
                                   DisplayIndex(c, pos)
                                End Sub)
   End Sub
   Private Sub DisplayIndex(column As DataGridViewColumn, ByRef pos As Integer)
      dgvProductos.Columns(column.Name).DisplayIndex = pos
      pos += 1
      Console.WriteLine(String.Format("{1} : {0}", column.Name, pos))
   End Sub
   Private Sub ChequeaCajas()
      If _enNuevo Then Return
      SeteaTituloVentana()
      SeteaColorGroupboxCliente()
      If DirectCast(Me.cmbTiposComprobantes.SelectedItem, Entidades.TipoComprobante) IsNot Nothing Then
         If DirectCast(Me.cmbTiposComprobantes.SelectedItem, Entidades.TipoComprobante).AfectaCaja And DirectCast(Me.cmbFormaPago.SelectedItem, Entidades.VentaFormaPago).Dias = 0 Then
            Dim oCaja As Reglas.CajasNombres = New Reglas.CajasNombres()
            Dim caja As Entidades.CajaNombre = New Entidades.CajaNombre()
            Dim oCajas As Reglas.Cajas = New Reglas.Cajas()
            Dim saldoCaja As Decimal

            Dim oPlanilla As Entidades.Caja = oCajas.GetPlanillaActual(actual.Sucursal.IdSucursal, Integer.Parse(Me.cmbCajas.SelectedValue.ToString()))

            '# Se agrega validación por si la sucursal no posee una Planilla creada
            If oPlanilla Is Nothing Then Throw New Exception("Esta sucursal no tiene planilla de caja creada para la forma de pago seleccionada.")

            saldoCaja = oCajas.GetSaldoPesosFinal(actual.Sucursal.IdSucursal, Integer.Parse(Me.cmbCajas.SelectedValue.ToString()), oPlanilla.NumeroPlanilla) + oCajas.GetSaldoChequesFinal(actual.Sucursal.IdSucursal, Integer.Parse(Me.cmbCajas.SelectedValue.ToString()), oPlanilla.NumeroPlanilla)
            Dim totalCaja As Decimal = saldoCaja + Decimal.Parse(txtEfectivo.Text) + Decimal.Parse(txtCheques.Text) +
                                       (txtImporteDolares.ValorNumericoPorDefecto(0D) * txtCotizacionDolar.ValorNumericoPorDefecto(0D))
            caja = oCaja.GetUna(actual.Sucursal.IdSucursal, Integer.Parse(Me.cmbCajas.SelectedValue.ToString()))

            If caja.TopeAviso > 0 And totalCaja >= caja.TopeAviso And totalCaja < caja.TopeBloqueo Then
               MessageBox.Show("Superó el Limite Recomendado de " & caja.TopeAviso.ToString("N2") & ", y está por llegar al Límite Permitido en Caja de " & caja.TopeBloqueo.ToString("N2"), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            ElseIf caja.TopeBloqueo > 0 And totalCaja >= caja.TopeBloqueo Then
               MessageBox.Show("Llegó al Límite Permitido en Caja de " & caja.TopeBloqueo.ToString("N2"), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
         End If
      End If
   End Sub

   Private Function MuestraImpuestosInternos(importe As Decimal, porcentaje As Decimal) As Decimal
      txtImpuestoInterno.Text = importe.ToString("N2")
      txtImpuestoInterno.Visible = importe <> 0
      'txtImpuestosInternos.LabelAsoc.Visible = txtImpuestosInternos.Visible

      txtPorcImpuestoInterno.Text = porcentaje.ToString("N2")
      txtPorcImpuestoInterno.Visible = porcentaje <> 0
      'txtPorcImpuestoInterno.LabelAsoc.Visible = txtPorcImpuestoInterno.Visible

      Return importe
   End Function

   Private Sub MostrarNumerosSerieDesdeGrilla(grilla As DataGridView, e As System.Windows.Forms.DataGridViewCellEventArgs)

      If grilla.Columns(e.ColumnIndex).Name = "NrosSerie" Or grilla.Columns(e.ColumnIndex).Name = "NrosSerieRT" Then
         If e.RowIndex <> -1 Then

            Dim nrosSerie As DataTable
            Dim onrosSerie As Reglas.ProductosNrosSerie = New Reglas.ProductosNrosSerie()
            Dim cantidadDeProductos As Integer = 0

            Dim producto = DirectCast(grilla.SelectedRows(0).DataBoundItem, Entidades.VentaProducto).Producto
            If producto.NrosSeries.Count > 0 Then

               cantidadDeProductos = producto.NrosSeries.Count

               If DirectCast(Me.cmbTiposComprobantes.SelectedItem, Entidades.TipoComprobante).CoeficienteValores = -1 Then
                  nrosSerie = New Reglas.ProductosNrosSerie().GetNrosSerieProductoClienteVendido(actual.Sucursal.Id, producto.IdProducto, _clienteE.IdCliente)
               Else
                  '-- REQ-32489.- -----------------------------------------------------------------------------------------------------------
                  nrosSerie = onrosSerie.GetNrosSerieProducto(actual.Sucursal, producto.IdDeposito, producto.IdUbicacion, producto.IdProducto)
               End If

               Dim sel As SeleccionoNrosSerie = New SeleccionoNrosSerie(cantidadDeProductos, producto, nrosSerie)
               If sel.ShowDialog() = Windows.Forms.DialogResult.OK Then
                  producto.NrosSeries.Clear()
                  producto.NrosSeries = sel.ProductosNrosSerie
               End If
            Else
               If producto.NroSerie Then

                  cantidadDeProductos = Integer.Parse(Math.Round(DirectCast(DirectCast(grilla.SelectedRows(0), DataGridViewRow).DataBoundItem, Eniac.Entidades.VentaProducto).Cantidad, 0).ToString())
                  '-- REQ-32489.- -----------------------------------------------------------------------------------------------------------
                  nrosSerie = onrosSerie.GetNrosSerieProducto(actual.Sucursal, producto.IdDeposito, producto.IdUbicacion, producto.IdProducto)

                  Dim sel As SeleccionoNrosSerie = New SeleccionoNrosSerie(cantidadDeProductos, producto, nrosSerie)
                  If sel.ShowDialog() = Windows.Forms.DialogResult.OK Then
                     producto.NrosSeries.Clear()
                     producto.NrosSeries = sel.ProductosNrosSerie
                  End If

               Else
                  ShowMessage("El producto no tiene definido numero de serie")
               End If

            End If
         End If
      End If
   End Sub

   Public Sub SetPagosSegunFormaPago()
      Dim formaPago = cmbFormaPago.ItemSeleccionado(Of Entidades.VentaFormaPago)
      If formaPago IsNot Nothing Then
         Dim diferentia = txtDiferencia.ValorNumericoPorDefecto(0D)
         If diferentia <> 0 AndAlso formaPago.CountRequiere = 1 Then
            If formaPago.RequierePesos Then
               txtEfectivo.SetValor(txtEfectivo.ValorNumericoPorDefecto(0D) + diferentia)
               txtEfectivo.Focus()

            ElseIf formaPago.RequiereDolares Then

            ElseIf formaPago.RequiereTransferencia Then
               txtTransferenciaBancaria.SetValor(txtTransferenciaBancaria.ValorNumericoPorDefecto(0D) + diferentia)
               If formaPago.IdCuentaBancariaEfectivo.HasValue Then
                  bscCodigoCuentaBancariaTransfBanc.Text = formaPago.IdCuentaBancariaEfectivo.Value.ToString()
                  bscCodigoCuentaBancariaTransfBanc.PresionarBoton()
               End If
               txtTransferenciaBancaria.Focus()

            ElseIf formaPago.RequiereTickets Then
               txtTickets.SetValor(txtEfectivo.ValorNumericoPorDefecto(0D) + diferentia)
               txtTickets.Focus()

            ElseIf formaPago.RequiereTarjetaCredito Or formaPago.RequiereTarjetaCredito1Pago Or formaPago.RequiereTarjetaDebito Then
               tbcPagosTarChe.SelectedTab = tbpPagosTarjetas
               cmbTarTarjeta.Focus()

            ElseIf formaPago.RequiereCheques Then
               tbcPagosTarChe.SelectedTab = tbpPagosCheques
               bscBancos.Focus()

            Else
               txtEfectivo.Focus()
            End If
         Else
            txtEfectivo.Focus()
         End If
      Else
         txtEfectivo.Focus()
      End If
   End Sub

#End Region

   Private Sub SeteaTituloVentana()
      Dim prefijo As String = ""
      Dim orden As String = Reglas.Publicos.Facturacion.FacturacionOrdenDeTitulo
      Dim formato As String = ""
      Dim facturacionCajaEnTitulo As Boolean = Reglas.Publicos.Facturacion.FacturacionCajaEnTitulo
      Dim facturacionVendedorEnTitulo As Boolean = Reglas.Publicos.Facturacion.FacturacionVendedorEnTitulo

      If facturacionVendedorEnTitulo And facturacionCajaEnTitulo Then
         If orden = Entidades.Publicos.FacturacionOrdenesDeTitulo.VENDEDORCAJA.ToString() Then
            formato = "{0} - {1} - "
         Else
            formato = "{1} - {0} - "
         End If
      ElseIf facturacionVendedorEnTitulo Then
         formato = "{0} - "
      ElseIf facturacionCajaEnTitulo Then
         formato = "{1} - "
      End If

      prefijo = String.Format(formato, cmbVendedor.Text, cmbCajas.Text)

      Me.Text = prefijo + _tituloOriginal
   End Sub

   Private Sub SeteaColorGroupboxCliente()
      SeteaColorGroupboxCliente(cmbCajas, cmbVendedor, cmbTiposComprobantes, grbCliente)
   End Sub

   Private Sub cmbVendedor_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbVendedor.SelectedIndexChanged
      Try
         SeteaTituloVentana()
         SeteaColorGroupboxCliente()
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

   Private Sub CalcularImpuestoInterno()
      Dim iidb As FacturacionV2.ImpIntDesdeBusquedas = FacturacionV2.GetImpIntDesdeBusquedas(bscCodigoProducto2, bscProducto2)

      If iidb.PorcImpuestoInterno = 0 Then
         MuestraImpuestosInternos(iidb.ImporteImpuestoInterno, iidb.PorcImpuestoInterno)
      Else
         If Not IsNumeric(txtPrecio.Text) Then txtPrecio.Text = (0).ToString("N" + _decimalesAMostrar.ToString())
         Dim precioNeto As Decimal
         Dim descRecPorc1 As Decimal = Decimal.Parse(txtDescRecPorc1.Text)
         Dim descRecPorc2 As Decimal = Decimal.Parse(txtDescRecPorc2.Text)
         Dim descRecGralPorc As Decimal = Decimal.Parse(txtDescRecGralPorc2.Text)

         Dim alicuotaIVA As Decimal = Decimal.Parse(cmbPorcentajeIva.Text)

         If (DirectCast(cmbCategoriaFiscal.SelectedItem, Entidades.CategoriaFiscal).IvaDiscriminado And Me._categoriaFiscalEmpresa.IvaDiscriminado) Or
            Not DirectCast(cmbCategoriaFiscal.SelectedItem, Entidades.CategoriaFiscal).UtilizaImpuestos Or Not Me._categoriaFiscalEmpresa.UtilizaImpuestos Then
            precioNeto = Decimal.Parse(txtPrecio.Text)
         Else
            precioNeto = Reglas.CalculosImpositivos.ObtenerPrecioSinImpuestos(Decimal.Parse(txtPrecio.Text), alicuotaIVA,
                                                                              iidb.PorcImpuestoInterno, iidb.ImporteImpuestoInterno, iidb.OrigenPorcImpInt)
         End If

         precioNeto = precioNeto * (1 + (descRecPorc1 / 100))
         precioNeto = precioNeto * (1 + (descRecPorc2 / 100))
         precioNeto = precioNeto * (1 + (descRecGralPorc / 100))

         Dim impuestoInterno As Decimal

         'If DirectCast(cmbCategoriaFiscal.SelectedItem, Entidades.CategoriaFiscal).IvaDiscriminado Then
         If (DirectCast(cmbCategoriaFiscal.SelectedItem, Entidades.CategoriaFiscal).IvaDiscriminado And Me._categoriaFiscalEmpresa.IvaDiscriminado) Or
             Not DirectCast(cmbCategoriaFiscal.SelectedItem, Entidades.CategoriaFiscal).UtilizaImpuestos Or Not Me._categoriaFiscalEmpresa.UtilizaImpuestos Then
            'El precio en pantalla está sin IVA
            impuestoInterno = Reglas.CalculosImpositivos.CalcularImpuestoInternoDesdeNetoSinIVA(precioNeto, alicuotaIVA, iidb.PorcImpuestoInterno, iidb.ImporteImpuestoInterno, iidb.OrigenPorcImpInt)
            'impuestoInterno = importeImpuestoInternoProducto + (precioNeto * porcImpuestoInterno / 100)
         Else
            'El precio en pantalla está con IVA
            impuestoInterno = Reglas.CalculosImpositivos.CalcularImpuestoInternoDesdeNetoSinIVA(precioNeto, alicuotaIVA, iidb.PorcImpuestoInterno, iidb.ImporteImpuestoInterno, iidb.OrigenPorcImpInt)
            'impuestoInterno = importeImpuestoInternoProducto + (precioNeto * porcImpuestoInterno / 100)
         End If

         MuestraImpuestosInternos(impuestoInterno, iidb.PorcImpuestoInterno)
      End If
   End Sub
   Private Sub SetearDescuentosPorCantidad(producto As Entidades.Producto)
      txtCantidad.Tag = Nothing
      ToolTip1.SetToolTip(txtCantidad, String.Empty)
      If producto IsNot Nothing Then
         Dim descRecCantidad As Reglas.Ventas.DescuentoRecargoPorCantidad = New Reglas.Ventas().GetDescuentoCantidad(producto)
         If descRecCantidad IsNot Nothing Then
            Dim stb As StringBuilder = New StringBuilder()
            If descRecCantidad.UnidHasta1 <> 0 Then
               stb.AppendFormat("Desde {0:N2} unidades ==> {1} %", descRecCantidad.UnidHasta1, descRecCantidad.UHPorc1.ToString("N" + _decimalesEnDescRec.ToString()))
            End If
            If descRecCantidad.UnidHasta2 <> 0 Then
               stb.AppendLine().AppendFormat("Desde {0:N2} unidades ==> {1} %", descRecCantidad.UnidHasta2, descRecCantidad.UHPorc2.ToString("N" + _decimalesEnDescRec.ToString()))
            End If
            If descRecCantidad.UnidHasta3 <> 0 Then
               stb.AppendLine().AppendFormat("Desde {0:N2} unidades ==> {1} %", descRecCantidad.UnidHasta3, descRecCantidad.UHPorc3.ToString("N" + _decimalesEnDescRec.ToString()))
            End If
            If descRecCantidad.UnidHasta4 <> 0 Then
               stb.AppendLine().AppendFormat("Desde {0:N2} unidades ==> {1} %", descRecCantidad.UnidHasta4, descRecCantidad.UHPorc4.ToString("N" + _decimalesEnDescRec.ToString()))
            End If
            If descRecCantidad.UnidHasta5 <> 0 Then
               stb.AppendLine().AppendFormat("Desde {0:N2} unidades ==> {1} %", descRecCantidad.UnidHasta5, descRecCantidad.UHPorc5.ToString("N" + _decimalesEnDescRec.ToString()))
            End If
            ToolTip1.Show(stb.ToString(), txtCantidad, New Point(0, 17))
            txtCantidad.Tag = stb.ToString()
         End If
      End If
   End Sub

   Private Sub txtCantidad_Enter(sender As Object, e As EventArgs) Handles txtCantidad.Enter
      Try
         If txtCantidad.Tag IsNot Nothing AndAlso Not String.IsNullOrWhiteSpace(txtCantidad.Tag.ToString()) Then
            ToolTip1.Show(txtCantidad.Tag.ToString(), txtCantidad, New Point(0, 17))
         End If
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub
   Private Sub txtCantidad_Leave(sender As Object, e As EventArgs) Handles txtCantidad.Leave
      Try
         ToolTip1.Hide(txtCantidad)
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub
   Private ProductModif As Boolean = False
   Private Sub dgvProductos_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvProductos.CellDoubleClick
      Try
         If New Reglas.Usuarios().TienePermisos(actual.Nombre, actual.Sucursal.Id, "FacturacionRapida-EditarItem") Then
            If _ModificaDetalle <> "NO" Then
               ProductModif = True
               Me.LimpiarCamposProductos()

               '# Seteo la propiedad en True para indicar que voy a editar un producto que se encuentra en la grilla y debe buscar por Código Exacto.
               _editarProductoDesdeGrilla = True
               flackCargaProductos = False
               Me.CargarProductoCompleto(Me.dgvProductos.Rows(e.RowIndex), editarProductoDesdeGrilla:=_editarProductoDesdeGrilla)
               flackCargaProductos = True
               'elimina el producto de la grilla
               Me.EliminarLineaProducto()
               If Me._ModificaDetalle = "SOLOPRECIOS" Then
                  Me.txtPrecio.Enabled = True
                  Me.txtDescRecPorc1.Enabled = True
                  Me.txtDescRecPorc2.Enabled = True
                  Me.cmbPorcentajeIva.Enabled = True
                  Me.tsbGrabar.Enabled = False
                  Me.btnInsertar.Enabled = True
               Else
                  Me.txtCantidad.Focus()
                  Me.txtCantidad.SelectAll()
               End If
            End If
         End If

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
      End Try
   End Sub
   Private Sub LlSaldoCtaCte_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LlSaldoCtaCte.LinkClicked
      Try
         Me.Cursor = Cursors.WaitCursor
         If New Reglas.Usuarios().TienePermisos(actual.Nombre, actual.Sucursal.Id, "RecibosNuevos") Then
            If Me.bscCodigoCliente.Selecciono Or Me.bscCliente.Selecciono Then
               Using Recibos As Recibos = New Recibos(Long.Parse(bscCodigoCliente.Text), 0, cerraLuegoDeGrabar:=False)
                  Recibos.IdFuncion = "RecibosNuevos"
                  Recibos.ShowDialog(Me)
               End Using

            End If
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
      Finally
         Me.Cursor = Cursors.Default
      End Try
   End Sub

   Private Sub btnPlanesTarjetas_Click(sender As Object, e As EventArgs) Handles btnPlanesTarjetas.Click
      Try

         If Me._tarjetas.Count > 0 Then
            If ShowPregunta("Al cambiar los planes de las tarjetas se perderán los registros de tarjeta ya ingresado. ¿Desea continuar?") = Windows.Forms.DialogResult.No Then
               Exit Sub
            End If
         End If

         Dim prevDescRecGralPorc As Decimal = Decimal.Parse(txtDescRecGralPorc2.Text)

         Me.txtDescRecGralPorc2.Text = (0).ToString("N" + _decimalesEnDescRec.ToString())

         Try
            Me.CalcularDatosDetalle()
         Catch ex As Exception
            MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
         End Try

         Dim totalGeneral As Decimal = Decimal.Parse(txtTotalGeneral.Text)

         Using frm As New SeleccionPlanesTarjetas(totalGeneral,
                                                  txtEfectivo.ValorNumericoPorDefecto(0D),
                                                  txtTransferenciaBancaria.ValorNumericoPorDefecto(0D),
                                                  txtTickets.ValorNumericoPorDefecto(0D),
                                                  txtCheques.ValorNumericoPorDefecto(0D),
                                                  txtImporteDolares.ValorNumericoPorDefecto(0D),
                                                  _tarjetas, False,
                                                  0)
            '-- REQ-34675.- -----------------------
            frm._fechaComprobante = dtpFecha.Value
            '--------------------------------------
            If frm.ShowDialog() = Windows.Forms.DialogResult.OK Then

               '# En caso de que la modificación del D/R Gral esté activado
               '# Se debe avisar al usuario que se va a sobreescribir dicho d/r con los d/r asociados a las tarjetas.
               If Me.chbModificaDescRecGralPorc.Checked Then
                  ShowMessage("ATENCIÓN: Se van a sobreescribir los D/R Gral ingresados manualmente por los D/R asociados a los Planes de Tarjetas.")
                  Me.chbModificaDescRecGralPorc.Checked = False
               End If

               dgvTarjetas.DataSource = Me._tarjetas.ToArray()

               txtEfectivo.Text = frm.Efectivo.ToString(txtEfectivo.Formato)
               txtImporteDolares.SetValor(frm.Dolares)

               '-- REQ- 34513.- -----------------------------------------------------------------------------
               txtTransferenciaBancaria.Text = frm.Transferencia.ToString(txtTransferenciaBancaria.Formato)
               txtTickets.Text = frm.Tickets.ToString(txtTickets.Formato)
               txtCheques.Text = frm.Cheques.ToString(txtCheques.Formato)
               '---------------------------------------------------------------------------------------------


               If totalGeneral <> frm.ImporteTotalConInterses Then
                  'Si eligio mas de una, tengo que redondear el coeficiente por mas que luego tenga que ajustar algo.
                  '-- REQ- 34513.- -----------------------------------------------------------------------------
                  If Me.dgvTarjetas.RowCount > 1 Or frm.Efectivo <> 0 Or frm.Transferencia <> 0 Or frm.Tickets <> 0 Or frm.Cheques <> 0 Then
                     txtDescRecGralPorc2.Text = Decimal.Round((frm.ImporteTotalConInterses / totalGeneral * 100) - 100, _decimalesEnDescRec).ToString("N" + _decimalesEnDescRec.ToString())
                  Else
                     'Si eligio sola una, tomo ese % porque un 12% puede mostrar 11.99.

                     Me.txtDescRecGralPorc2.Text = Me._tarjetas(0).Tarjeta.PorcIntereses.ToString("N" + _decimalesEnDescRec.ToString())

                  End If
               Else
                  Me.txtDescRecGralPorc2.Text = (0).ToString("N" + _decimalesEnDescRec.ToString())
               End If
               _DescRecGralPorc = Decimal.Parse(txtDescRecGralPorc2.Text)

               '               CalcularPagos(_recalcularEfectivoAlCargarTarjeta)
            Else
               Me.txtDescRecGralPorc2.Text = prevDescRecGralPorc.ToString("N" + _decimalesEnDescRec.ToString())
            End If

            Try
               Me.CalcularDatosDetalle()
               If Math.Abs(Decimal.Parse(txtDiferencia.Text)) < 1 AndAlso _tarjetas.Count > 0 Then
                  _tarjetas(_tarjetas.Count - 1).Monto = _tarjetas(_tarjetas.Count - 1).Monto + Decimal.Parse(txtDiferencia.Text)
                  Me.dgvTarjetas.DataSource = Me._tarjetas.ToArray()
               End If
               Me.CalcularPagos(_recalcularEfectivoAlCargarTarjeta)
            Catch ex As Exception
               MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try

         End Using

      Catch ex As Exception
         MessageBox.Show(ex.Message, Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub tsbImprimirPreTicket_Click(sender As Object, e As EventArgs) Handles tsbImprimirPreTicket.Click
      Try
         Using frm As New ImpresionTicketFiscal()
            frm.ConsultarAutomaticamente = True
            frm.IdFuncion = IdFuncion
            frm.ShowDialog()
         End Using

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
      End Try

   End Sub

   Private Sub tsbAccionesAdicionales_Click(sender As Object, e As EventArgs) Handles tsbAccionesAdicionales.Click
      TryCatched(Sub() AbreAccionesAdicionales())
   End Sub

   Private Sub CalculosDescuentosRecargos1_ReporteEstado(sender As Object, e As CalculosDescuentosRecargosReporteEstadoEventArgs) Handles CalculosDescuentosRecargos1.ReporteEstado
      Try
         lblEstado.Text = e.Estado
         Application.DoEvents()
      Catch ex As Exception
      End Try
   End Sub

   Private Sub NavegacionDesdeClienteSegunParametros()
      'controlo los focos y si tengo que solicitar el vendedor y el tipo de comprobante
      If Reglas.Publicos.Facturacion.FacturacionSolicitaComprobante Then
         Me.cmbTiposComprobantes.SelectedIndex = -1
         Me.cmbTiposComprobantes.Focus()
      End If
      If Reglas.Publicos.Facturacion.FacturacionSolicitaVendedor Then
         Me.cmbVendedor.SelectedIndex = -1
         Me.cmbVendedor.Focus()
      End If
      If Not Reglas.Publicos.Facturacion.FacturacionSolicitaComprobante And Not Reglas.Publicos.Facturacion.FacturacionSolicitaVendedor Then
         Me.bscCodigoProducto2.Focus()
      End If
   End Sub

   Private Sub txtNombreClienteGenerico_KeyDown(sender As Object, e As KeyEventArgs) Handles txtNombreClienteGenerico.KeyDown
      If e.KeyCode = Keys.Enter Then
         'controlo los focos y si tengo que solicitar el vendedor y el tipo de comprobante
         NavegacionDesdeClienteSegunParametros()
      End If
   End Sub

   Private Sub cmbTipoCheque_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbTipoCheque.SelectedIndexChanged
      If Me.cmbTipoCheque.SelectedIndex <> -1 Then
         If Not DirectCast(Me.cmbTipoCheque.SelectedItem, Entidades.TiposCheques).SolicitaNroOperacion Then
            Me.txtNroOperacion.Clear()
            Me.txtNroOperacion.Enabled = False
         Else
            Me.txtNroOperacion.Enabled = True
         End If
      End If
   End Sub
   '-- REQ-31198.- -Factura de Exportacion.- --
   Private Sub txtLetra_TextChanged(sender As Object, e As EventArgs) Handles txtLetra.TextChanged
      If UCase(txtLetra.Text) = "E" Then
         ShowMessage("Formulario no habilitado para Comprobantes de Exportacion!!!.")
      End If
   End Sub

   Private Sub txtTransferenciaBancaria_KeyUp(sender As Object, e As KeyEventArgs) Handles txtTransferenciaBancaria.KeyUp
      If e.KeyCode = Keys.Enter Then
         If Not String.IsNullOrEmpty(Me.txtTransferenciaBancaria.Text) AndAlso Decimal.Parse(Me.txtTransferenciaBancaria.Text) <> 0 Then
            Me.PresionarTab(e)
         Else
            Me.cmbTarTarjeta.Focus()
         End If
      End If
   End Sub

   Private Sub txtTransferenciaBancaria_Leave(sender As Object, e As EventArgs) Handles txtTransferenciaBancaria.Leave
      TryCatched(Sub() CalcularPagos(False))
   End Sub

   Private Sub bscCuentaBancariaTransfBanc_BuscadorClick() Handles bscCuentaBancariaTransfBanc.BuscadorClick
      TryCatched(
         Sub()
            _publicos.PreparaGrillaCuentasBancarias2(bscCuentaBancariaTransfBanc)
            bscCuentaBancariaTransfBanc.Datos = New Reglas.CuentasBancarias().GetFiltradoPorNombre(bscCuentaBancariaTransfBanc.Text.Trim(), Entidades.Moneda.Peso)
         End Sub)
   End Sub
   Private Sub bscCodigoCuentaBancariaTransfBanc_BuscadorClick() Handles bscCodigoCuentaBancariaTransfBanc.BuscadorClick
      TryCatched(
         Sub()
            _publicos.PreparaGrillaCuentasBancarias2(bscCodigoCuentaBancariaTransfBanc)
            bscCodigoCuentaBancariaTransfBanc.Datos = New Reglas.CuentasBancarias().GetFiltradoPorCodigo(bscCodigoCuentaBancariaTransfBanc.Text.ValorNumericoPorDefecto(0I))
         End Sub)
   End Sub
   Private Sub bscCuentaBancariaTransfBanc_BuscadorSeleccion(sender As Object, e As Controles.BuscadorEventArgs) Handles bscCuentaBancariaTransfBanc.BuscadorSeleccion, bscCodigoCuentaBancariaTransfBanc.BuscadorSeleccion
      TryCatched(
         Sub()
            If Not e.FilaDevuelta Is Nothing Then
               bscCodigoCuentaBancariaTransfBanc.Text = e.FilaDevuelta.Cells("IdCuentaBancaria").Value.ToString()
               bscCuentaBancariaTransfBanc.Text = e.FilaDevuelta.Cells("NombreCuenta").Value.ToString()
               bscCuentaBancariaTransfBanc.Tag = e.FilaDevuelta.Cells("IdCuentaBancaria").Value.ToString()
               bscCodigoCuentaBancariaTransfBanc.Selecciono = True
               bscCuentaBancariaTransfBanc.Selecciono = True
               dtpFechaTransferencia.Select()
            End If
         End Sub)
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
   Private Sub txtImporteTransferenciaMultiple_KeyDown(sender As Object, e As KeyEventArgs) Handles txtImporteTransferenciaMultiple.KeyDown
      PresionarTab(e)
   End Sub

   Private Sub btnAgregarImporteTransfMultiple_Click(sender As Object, e As EventArgs) Handles btnAgregarImporteTransfMultiple.Click
      TryCatched(
      Sub()
         If ValidarInsertarTransfMultiple() Then
            InsertarTransferenciaMultiple()
            CalcularPagos(False)
         End If
      End Sub)
   End Sub
   Private Sub btnQuitarImporteTransfMultiple_Click(sender As Object, e As EventArgs) Handles btnQuitarImporteTransfMultiple.Click
      TryCatched(
      Sub()
         If ugTransferenciasMultiples.ActiveRow IsNot Nothing Then
            QuitarTransferenciaMultiple()
            CalcularPagos(False)
         End If
      End Sub)
   End Sub

   Private Sub InsertarTransferenciaMultiple()
      If _transferencias Is Nothing Then _transferencias = New List(Of Entidades.VentaTransferencia)
      _transferencias.Add(New Entidades.VentaTransferencia With
                          {
                              .IdCuentaBancaria = bscCodigoCuentaBancariaTransfBancMultiples.Text.ValorNumericoPorDefecto(0I),
                              .Orden = _transferencias.Count + 1,
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
      Dim dr = ugTransferenciasMultiples.FilaSeleccionada(Of Entidades.VentaTransferencia)
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


   Private Sub txtPrecio_Enter(sender As Object, e As EventArgs) Handles txtPrecio.Enter
      TryCatched(Sub() _txtPrecioEnter = txtPrecio.ValorNumericoPorDefecto(0D))
   End Sub

   Private Sub txtCotizacionDolar_TextChanged(sender As Object, e As EventArgs) Handles txtCotizacionDolar.TextChanged
      If Me._estaCargando Then Exit Sub

      Try

         ActualizaPrecios = If(cmbFormaPago.ItemSeleccionado(Of Entidades.VentaFormaPago).IdListaPrecios.HasValue, True, Reglas.Publicos.ActualizaPreciosDeVenta())

         If ActualizaPrecios Then
            RecalcularTodo(FacturacionV2.MetodoLlamador.CambioListaDePrecibos, False)
         Else
            SetearPrecio()
         End If

         ActualizaPrecios = Reglas.Publicos.ActualizaPreciosDeVenta()
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub
End Class