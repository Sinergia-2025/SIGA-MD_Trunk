Public Class ProductosDetalle

#Region "Campos"

   Private dtListaPrecios As DataTable
   Private _publicos As Publicos
   Private _productosComp As DataTable
   Private _NombreProductoOriginal As String
   Private _estaCargando As Boolean
   Private _conceptos As List(Of Entidades.ProductoConcepto)
   Private _EmbalajeNormal As Boolean
   Private _MostrarPrecios As Boolean
   Private _observacionesCompras As Boolean

   Private _SubRubroAtributo As Boolean = False

   Private _calidadProductos As List(Of Entidades.CalidadListaControlProducto)

   Private _titPrecios As Dictionary(Of String, String)
   Private _titProductoProveedor As Dictionary(Of String, String)
   Private _titIdentificaciones As Dictionary(Of String, String)
   Private _titAdjuntos As Dictionary(Of String, String)

   Private _titCalidad As Dictionary(Of String, String)
   Private _titCalidadProducto As Dictionary(Of String, String)


   Private _reglasProductos As Reglas.Productos
   Private _productoUtilizaAlicuota2 As Boolean
   Private _tieneModuloContabilidad As Boolean
   Private _productoUtilizaCodigoLargo As Boolean
   Private _utilizaPrecioDeCompra As Boolean

   '-- REQ-32570.- ---------------------------------------------------------
   Private _decimalesEnPrecio As Integer
   Private _formatoEnPrecio As String
   Private _ceroFormatoEnPrecio As String
   '------------------------------------------------------------------------

   Private _lblSolicitaPrecioVentaPorTamanoDefault As String
   Private _productosOfertas As List(Of Entidades.ProductoOferta)

   Private _unidadDeMedidaInicial As Entidades.UnidadDeMedida
   Private _monedaInicial As Entidades.Moneda
   Private _alicuotaInicial As Entidades.Impuesto

   Private idCategoriaML As String

   Private subRubroActual As Integer

#End Region

#Region "Propiedades"

   Private __idProducto As String
   Public Property IdProducto() As String
      Get
         Return __idProducto
      End Get
      Set(value As String)
         __idProducto = value
      End Set
   End Property

   Private ReadOnly Property ProductoE As Entidades.Producto
      Get
         Return DirectCast(_entidad, Entidades.Producto)
      End Get
   End Property

#End Region

#Region "Constructores"

   Public Sub New()
      ' This call is required by the Windows Form Designer.
      InitializeComponent()
      _decimalesEnPrecio = Reglas.Publicos.PreciosDecimalesEnVenta
      _formatoEnPrecio = "N" + _decimalesEnPrecio.ToString()
      _ceroFormatoEnPrecio = 0.ToString(_formatoEnPrecio)

   End Sub

   Public Sub New(entidad As Entidades.Producto)
      Me.New()
      _entidad = entidad
   End Sub

#End Region

#Region "Overrides"

   Protected Overrides Sub OnLoad(e As EventArgs)

      MyBase.OnLoad(e)

      Try
         Dim ts As TimeSpan = Date.Now.TimeOfDay

         _lblSolicitaPrecioVentaPorTamanoDefault = chbSolicitaPrecioVentaPorTamano.Text

         Me.tbcDetalle.SelectedTab = tbpPrecios

         Me.CargaValoresIniciales()

         Me.HabilitaCodigoNumerico()

         If Not Reglas.Publicos.TieneModuloProduccion Then
            dgvListasPrecios.DisplayLayout.Bands(0).Columns(ListaPreciosColumns.DesdeFormula.ToString()).Hidden = True
         End If
         _titPrecios = GetColumnasVisiblesGrilla(dgvListasPrecios)
         _titProductoProveedor = GetColumnasVisiblesGrilla(ugProductosProveedores)
         _titIdentificaciones = GetColumnasVisiblesGrilla(ugIdentificaciones)
         _titAdjuntos = GetColumnasVisiblesGrilla(ugAdjunto)

         _titCalidad = GetColumnasVisiblesGrilla(ugCalidad)
         _titCalidadProducto = GetColumnasVisiblesGrilla(ugCalidadProductos)

         tbcDetalle.SelectedTab = tbpDatos

         Dim rUsuario As Reglas.Usuarios = New Eniac.Reglas.Usuarios()
         _MostrarPrecios = rUsuario.TienePermisos("Productos-MostrarPrecios")
         _observacionesCompras = rUsuario.TienePermisos("MovimientosDeCompras")

         '-- REQ-35665.- ----------------------------------------------------------------------
         txtCodigoProductoMercadoLibre.ReadOnly = Not rUsuario.TienePermisos("SincronizacionSubidaTiendaWeb")
         '-- REQ-35926.- ----------------------------------------------------------------------
         txtCodigoProductoTiendaNube.ReadOnly = Not rUsuario.TienePermisos("SincronizacionSubidaTiendaWeb")
         '-- REQ-38250.- ----------------------------------------------------------------------
         txtCodigoArborea.ReadOnly = Not rUsuario.TienePermisos("SincronizacionSubidaTiendaWeb")
         '-- REQ-42330.- --------------------------------------------------------------
         If Not rUsuario.TienePermisos("CalidadListasControlABM") Then tbcDetalle.TabPages.Remove(tblCalidad)
         '-------------------------------------------------------------------------------------

         'El LimpiarControles (luego del aceptar) lo daba por error y no encontre porque. Se modifico base detalle para que tenga en cuenta esto.
         CierraAutomaticamente = True

         _publicos = New Publicos()

         _publicos.CargaComboUnidadesDeMedidas(cmbUnidadDeMedida)
         _publicos.CargaComboUnidadesDeMedidas(cmbUnidadDeMedidaCompra)
         _publicos.CargaComboUnidadesDeMedidas(cmbUnidadDeMedidaProduccion)
         '_publicos.CargaComboUnidadesDeMedidas(Me.cmbUnidadDeMedida2)
         _publicos.CargaComboMonedas(cmbMoneda)
         _publicos.CargaComboImpuestos(cmbTipoImpuesto)
         _publicos.CargaComboModalidadCodigoDeBarras(cmbModalidadCodigoDeBarras)

         _publicos.CargaComboDepositos(cmbDepositoOrigen, actual.Sucursal.IdSucursal, miraUsuario:=False, permiteEscritura:=False, Entidades.Publicos.SiNoTodos.SI)
         cmbDepositoOrigen.SelectedIndex = 0

         _publicos.CargaComboDepositos(cmbDepositoAjuste, actual.Sucursal.IdSucursal, miraUsuario:=False, permiteEscritura:=False, Entidades.Publicos.SiNoTodos.TODOS)
         cmbDepositoAjuste.SelectedIndex = 0
         '-- REQ-30521.- --------------------------------------------
         _publicos.CargaComboCategoriasMercadoLibre(Me.cmbCategoriasMercadoLibre)
         cmbCategoriasMercadoLibre.Enabled = False
         '-- MRP Carga los Tipos de Archivos Adjuntos.- -----------------
         _publicos.CargaComboTiposAdjuntos(cmbTipoAdjunto)
         If cmbTipoAdjunto.Items.Count > 0 Then
            cmbTipoAdjunto.SelectedIndex = 0
         End If
         '-----------------------------------------------------------
         _publicos.CargaComboProduccionFormas(cmbProduccionForma)
         _publicos.CargaComboProduccionProcesos(cmbProduccionProceso)
         _publicos.CargaComboDesdeEnum(cmbOrigenPorcImpInt, GetType(Entidades.OrigenesPorcImpInt))

         _publicos.CargaComboDesdeEnum(cmbNivelInspeccion, GetType(Entidades.NivelInspeccionMRP))

         '# Bonificación Lista de Precios
         _publicos.CargaComboListaDePrecios(cmbBonificacionListaDePrecios1, activa:=True, insertarEnPosicionCero:=Nothing)
         _publicos.CargaComboListaDePrecios(cmbBonificacionListaDePrecios2, activa:=True, insertarEnPosicionCero:=Nothing)
         _publicos.CargaComboListaDePrecios(cmbBonificacionListaDePrecios3, activa:=True, insertarEnPosicionCero:=Nothing)
         _publicos.CargaComboListaDePrecios(cmbBonificacionListaDePrecios4, activa:=True, insertarEnPosicionCero:=Nothing)
         _publicos.CargaComboListaDePrecios(cmbBonificacionListaDePrecios5, activa:=True, insertarEnPosicionCero:=Nothing)
         cmbBonificacionListaDePrecios1.SelectedIndex = -1
         cmbBonificacionListaDePrecios2.SelectedIndex = -1
         cmbBonificacionListaDePrecios3.SelectedIndex = -1
         cmbBonificacionListaDePrecios4.SelectedIndex = -1
         cmbBonificacionListaDePrecios5.SelectedIndex = -1

         _liSources.Add("UnidadDeMedida", DirectCast(Me._entidad, Entidades.Producto).UnidadDeMedida)
         _liSources.Add("UnidadDeMedidaCompra", DirectCast(Me._entidad, Entidades.Producto).UnidadDeMedidaCompra)
         _liSources.Add("UnidadDeMedidaProduccion", DirectCast(Me._entidad, Entidades.Producto).UnidadDeMedidaProduccion)
         _liSources.Add("Moneda", DirectCast(Me._entidad, Entidades.Producto).Moneda)
         'Me._liSources.Add("NrosSeries", DirectCast(Me._entidad, Entidades.Producto).ProductoNroSerie)

         BindearControles(Me._entidad, Me._liSources)

         txtNombreCorto.Enabled = Publicos.ProductoUtilizaNombreCorto
         txtNombreCorto.IsRequired = Me.txtNombreCorto.Enabled
         btnCopiarNombreProducto.Enabled = Publicos.ProductoUtilizaNombreCorto


         _publicos.CargaComboFormulasDeProductos(Me.cmbFormulas, Me.txtIdProducto.Text)

         If Not Reglas.Publicos.ProductoUtilizaProductoWeb Then
            Me.tbcDetalle.TabPages.Remove(Me.tbpWeb)
         End If
         '-- REQ-43595.- --------------------------------------------------------------
         chbEsDevolucion.Visible = Reglas.Publicos.ProductoPermiteEsDevolucion
         '-- REQ-41235.- --------------------------------------------------------------
         If Not Reglas.Publicos.TieneModuloMRP Then tbcDetalle.TabPages.Remove(tbpMRP)
         '-- REQ-31518.- --------------------------------------------------------------
         txtUltimoPrecioCompra.Formato = _formatoEnPrecio
         txtUltimoPrecioCompra.Text = _ceroFormatoEnPrecio
         txtPrecioLista.Formato = _formatoEnPrecio
         txtPrecioLista.Text = _ceroFormatoEnPrecio
         txtPrecioCosto.Formato = _formatoEnPrecio
         txtPrecioCosto.Text = _ceroFormatoEnPrecio

         txtRedondeoPrecioVenta.Text = _decimalesEnPrecio.ToString()
         '-----------------------------------------------------------------------------


         If Me.StateForm = Eniac.Win.StateForm.Insertar Then

            If Publicos.ProductoCodigoNumerico Then
               Me.txtIdProducto.IsNumber = True
               Me.txtIdProducto.IsDecimal = False
            End If

            Me.chbActivo.Checked = True
            Me.chbAfectaStock.Checked = True

            Me.CargarProximoNumero()
            DirectCast(Me._entidad, Entidades.Producto).Usuario = actual.Nombre

            DirectCast(Me._entidad, Entidades.Producto).IdTipoImpuesto = Entidades.TipoImpuesto.Tipos.IVA.ToString()

            Me.cmbTipoImpuesto.SelectedValue = New Reglas.Impuestos().GetUno(Entidades.TipoImpuesto.Tipos.IVA.ToString(), Publicos.ProductoIVA).Alicuota
            DirectCast(Me._entidad, Entidades.Producto).Alicuota = Decimal.Parse(Me.cmbTipoImpuesto.Text)

            ''GAR: 12/10/2017 - Ahora lo muestro igualmente a Numero de Serie. DEbe activar la funcionalidad para que lo tome en todas las pantallas.
            'If Publicos.VisualizaLote Then
            '   Me.chbLote.Visible = True
            'End If
            ''---------------

            'If Publicos.VisualizaNrosSerie Then
            '   Me.chbNroSerie.Visible = True
            'End If

            Me.tbcDetalle.SelectedTab = Me.tbpDatos
            Me.cmbMoneda.SelectedValue = 1  'Pesos
            DirectCast(Me._entidad, Entidades.Producto).Moneda = New Reglas.Monedas().GetUna(Entidades.Moneda.Peso)

            Me.chbEsDeVentas.Checked = True
            DirectCast(Me._entidad, Entidades.Producto).EsDeVentas = True

            Me.chbEsComercial.Checked = True
            DirectCast(Me._entidad, Entidades.Producto).EsComercial = True

            Me.chbEsDeCompras.Checked = True
            DirectCast(Me._entidad, Entidades.Producto).EsDeCompras = True

            Me.chbEsCompuesto.Checked = False
            DirectCast(Me._entidad, Entidades.Producto).EsCompuesto = False

            Me.chbEsAlquilable.Checked = False
            DirectCast(Me._entidad, Entidades.Producto).EsAlquilable = False


            tbcDetalle.SelectedTab = Me.tbpDatos
            chbPagaIngBrutos.Checked = True
            txtEmbalaje.Text = "1"
            txtKilos.Text = "0.00"
            txtAQL.Text = "0.00"

            'PE-31388 IGUALAR VALOR AL DE LOS PARAMETROS
            tbcDetalle.SelectedTab = tbpPublicarEn

            chbPublicarEnWeb.Checked = Reglas.Publicos.ProductoPublicarWebCarrito
            chbPublicarEnTiendaNube.Checked = Reglas.Publicos.ProductoPublicarTiendaNube
            chbPublicarEnMercadoLibre.Checked = Reglas.Publicos.ProductoPublicarMercadoLibre
            chbPublicarEnArborea.Checked = Reglas.Publicos.ProductoPublicarArborea
            chbPublicarEnBalanza.Checked = Reglas.Publicos.ProductoPublicarBalanza
            chbPublicarListaDePreciosClientes.Checked = Reglas.Publicos.ProductoPublicarListaPrecioClientes
            chbPublicarEnGestion.Checked = Reglas.Publicos.ProductoPublicarAppGestion
            chbPublicarEnSincronizacionSucursal.Checked = Reglas.Publicos.ProductoPublicarSincronizacionSucursal
            chbPublicarEnEmpresarial.Checked = Reglas.Publicos.ProductoPublicarAppEmpresarial

            chbFacturacionCantidadNegativa.Checked = False

            tbcDetalle.SelectedTab = tbpOtros
            txtOrden.Text = "1"
            txtTamanio.Text = "1"

            cmbEsOferta.SelectedIndex = 0   'NO

            txtIdProducto.Focus()

            If Me._tieneModuloContabilidad Then
               UcCuentasCompras.Cuenta = Nothing
               UcCuentasVentas.Cuenta = Nothing
               UcCuentasComprasSecundaria.Cuenta = Nothing
               If Reglas.ContabilidadPublicos.UtilizaCentroCostos Then
                  bscCodigoCentroCosto.Text = String.Empty
                  bscNombreCentroCosto.Text = String.Empty
               Else
                  bscCodigoCentroCosto.Visible = Reglas.ContabilidadPublicos.UtilizaCentroCostos
                  bscNombreCentroCosto.Visible = bscCodigoCentroCosto.Visible
                  lblCentroCostos.Visible = bscCodigoCentroCosto.Visible
               End If
            Else
               tbcDetalle.TabPages.Remove(tbpContabilidad)
            End If

            Me.txtFechaActualizacion.Text = ""  'Date.Now().ToString()

            'si estoy insertando un producto NO lo dejo ajustar el stock
            btnAjustarStock.Visible = False

            Me.cmbUnidadDeMedida.SelectedValue = New Reglas.UnidadesDeMedidas().GetUnidadDeMedidaPorDefecto()
            Me.cmbUnidadDeMedidaCompra.SelectedValue = New Reglas.UnidadesDeMedidas().GetUnidadDeMedidaPorDefecto()
            Me.cmbUnidadDeMedidaProduccion.SelectedValue = New Reglas.UnidadesDeMedidas().GetUnidadDeMedidaPorDefecto()


            If tbcDetalle.TabPages.Contains(tbpUltimasCompras) Then
               tbcDetalle.TabPages.Remove(tbpUltimasCompras)
            End If
            tbcDetalle.SelectedTab = tbpStock
            cmbDepositoOrigen.SelectedIndex = 0
            cmbDepositoAjuste.SelectedIndex = 0
         Else
            '-- 
            cmbDepositoOrigen.SelectedValue = DirectCast(Me._entidad, Entidades.Producto).IdDeposito
            cmbUbicacionOrigen.SelectedValue = DirectCast(Me._entidad, Entidades.Producto).IdUbicacion
            '# Unidad de Medida 2
            'If DirectCast(Me._entidad, Entidades.Producto).UnidadDeMedida2 IsNot Nothing Then Me.cmbUnidadDeMedida2.SelectedValue = DirectCast(Me._entidad, Entidades.Producto).UnidadDeMedida2.IdUnidadDeMedida

            Me.chbLote.Checked = DirectCast(Me._entidad, Entidades.Producto).Lote
            Me.chbNroSerie.Checked = DirectCast(Me._entidad, Entidades.Producto).NroSerie

            Me.ValidarLotesNroSerie()

            Me._conceptos = DirectCast(Me._entidad, Entidades.Producto).Conceptos

            Me.dgvDetalleConceptos.DataSource = Me._conceptos

            'Navego los tabs para activar los controles combobox y que luego se validen, sino, no sucede.
            tbcDetalle.SelectedTab = tbpContabilidad
            tbcDetalle.SelectedTab = tbpPublicarEn
            tbcDetalle.SelectedTab = tbpObservacion
            tbcDetalle.SelectedTab = tbpFoto
            tbcDetalle.SelectedTab = tbpAlquiler
            tbcDetalle.SelectedTab = tbpProduccion
            tbcDetalle.SelectedTab = tbpExpensas
            tbcDetalle.SelectedTab = tbpDatos
            tbcDetalle.SelectedTab = tbpOfertas

            Me.bscCodigoMarca.PresionarBoton()

            Me.tbcDetalle.SelectedTab = Me.tbpPrecios
            If DirectCast(Me._entidad, Entidades.Producto).Proveedor IsNot Nothing Then
               Me.bscCodigoProveedor.Text = DirectCast(Me._entidad, Entidades.Producto).Proveedor.CodigoProveedor.ToString()
               Me.bscCodigoProveedor.PresionarBoton()

            End If

            If DirectCast(Me._entidad, Entidades.Producto).ProductoProveedorHabitual IsNot Nothing Then
               txtCodigoProductoProveedor.Text = DirectCast(Me._entidad, Entidades.Producto).ProductoProveedorHabitual.CodigoProductoProveedor
               txtPrecioLista.Text = DirectCast(Me._entidad, Entidades.Producto).ProductoProveedorHabitual.UltimoPrecioFabrica.ToString(_formatoEnPrecio)
               txtUltimoPrecioCompra.Text = DirectCast(Me._entidad, Entidades.Producto).ProductoProveedorHabitual.UltimoPrecioCompra.ToString(_formatoEnPrecio)
               txtDescuento1.Text = DirectCast(Me._entidad, Entidades.Producto).ProductoProveedorHabitual.DescuentoRecargoPorc1.ToString(_formatoEnPrecio)
               txtDescuento2.Text = DirectCast(Me._entidad, Entidades.Producto).ProductoProveedorHabitual.DescuentoRecargoPorc2.ToString(_formatoEnPrecio)
               txtDescuento3.Text = DirectCast(Me._entidad, Entidades.Producto).ProductoProveedorHabitual.DescuentoRecargoPorc3.ToString(_formatoEnPrecio)
               txtDescuento4.Text = DirectCast(Me._entidad, Entidades.Producto).ProductoProveedorHabitual.DescuentoRecargoPorc4.ToString(_formatoEnPrecio)
               txtUltimaFechaCompra.Text = DirectCast(Me._entidad, Entidades.Producto).ProductoProveedorHabitual.UltimaFechaCompra.ToString("dd/MM/yyyy")
               txtUltimaHoraCompra.Text = DirectCast(Me._entidad, Entidades.Producto).ProductoProveedorHabitual.UltimaFechaCompra.ToString("hh:mm:ss")

               ''MuestraPrecioCosto()
            End If

            Me.txtPrecioCosto.Text = DirectCast(Me._entidad, Entidades.Producto).PrecioCosto.ToString(_formatoEnPrecio)

            Me.txtNombreWeb.Text = DirectCast(Me._entidad, Entidades.Producto).NombreProductoWeb.ToString()

            If DirectCast(Me._entidad, Entidades.Producto).IdModelo > 0 Then
               Me.bscCodigoModelo.Text = DirectCast(Me._entidad, Entidades.Producto).IdModelo.ToString()
               Me.bscCodigoModelo.PresionarBoton()
            End If

            Me.bscCodigoRubro.PresionarBoton()

            If Reglas.Publicos.ProductoTieneSubRubro Then
               If DirectCast(Me._entidad, Entidades.Producto).IdSubRubro > 0 Then
                  Me.bscCodigoSubRubro.PresionarBoton()
               Else
                  Me.bscCodigoSubRubro.Text = ""
               End If
            End If

            Me.tbcDetalle.Focus()
            Me.bscCodigoMarca.Focus()

            Me.pcbFoto.Image = DirectCast(Me._entidad, Entidades.Producto).Foto

            Dim PS As Entidades.ProductoSucursal = New Reglas.ProductosSucursales()._GetUno(actual.Sucursal.Id, DirectCast(Me._entidad, Entidades.Producto).IdProducto)
            '-- REQ-43847 ------------------------------------------------------------------------------
            txtUbicacion.Text = PS.Ubicacion
            '-------------------------------------------------------------------------------------------
            txtFechaActualizacion.Text = PS.FechaActualizacion.ToString("dd/MM/yyyy HH:mm")

            Me.btnGenerarCodigo.Visible = False

            If Me._tieneModuloContabilidad Then
               UcCuentasCompras.Cuenta = DirectCast(Me._entidad, Entidades.Producto).CuentaCompras
               UcCuentasVentas.Cuenta = DirectCast(Me._entidad, Entidades.Producto).CuentaVentas
               UcCuentasComprasSecundaria.Cuenta = DirectCast(Me._entidad, Entidades.Producto).CuentaComprasSecundaria
               If Reglas.ContabilidadPublicos.UtilizaCentroCostos Then
                  If DirectCast(Me._entidad, Entidades.Producto).IdCentroCosto.HasValue Then
                     bscCodigoCentroCosto.Text = DirectCast(Me._entidad, Entidades.Producto).IdCentroCosto.Value.ToString()
                     If DirectCast(Me._entidad, Entidades.Producto).IdCentroCosto.HasValue Then
                        Dim prev_tabpage As TabPage = tbcDetalle.SelectedTab
                        tbcDetalle.SelectedTab = tbpContabilidad
                        bscCodigoCentroCosto.PresionarBoton()
                        tbcDetalle.SelectedTab = prev_tabpage
                     End If
                  End If
               Else
                  bscCodigoCentroCosto.Visible = Reglas.ContabilidadPublicos.UtilizaCentroCostos
                  bscNombreCentroCosto.Visible = bscCodigoCentroCosto.Visible
                  lblCentroCostos.Visible = bscCodigoCentroCosto.Visible
               End If
            Else
               tbcDetalle.TabPages.Remove(tbpContabilidad)
            End If

            ugProductosProveedores.DataSource = New Reglas.ProductosProveedores().GetPorProductoYProveedor(Nothing, DirectCast(Me._entidad, Entidades.Producto).IdProducto, "UltimaFechaCompra", True)
            AjustarColumnasGrillaProductosProveedores()

            'P-1013: VialParking - se agrego arriba para visualizar los controles
            Me.txtTamaño2.Text = Me.txtTamanio.Text
            Me.txtUM2.Text = Me.cmbUnidadDeMedida.Text
            Me.chbSolicitaPrecioVentaPorTamano.Text = String.Format(_lblSolicitaPrecioVentaPorTamanoDefault, Me.txtUM2.Text)

            chbProduccionForma.Checked = DirectCast(Me._entidad, Entidades.Producto).IdProduccionForma <> 0
            chbProduccionProceso.Checked = DirectCast(Me._entidad, Entidades.Producto).IdProduccionProceso <> 0


            'SUBRUBRO POR PARAMETRO
            If DirectCast(Me._entidad, Entidades.Producto).IdSubSubRubro > 0 Then
               Me.bscCodigoSubSubRubro.PresionarBoton()
            Else
               Me.bscCodigoSubSubRubro.Text = ""
            End If


            'SOLAPA WEB POR PARAMETRO
            'Cargo Productos Web
            Dim ProductoWeb As DataTable = New Reglas.ProductosWeb().Get1(DirectCast(Me._entidad, Entidades.Producto).IdProducto, Reglas.Publicos.NombreBaseProductosWeb)
            If ProductoWeb.Rows.Count <> 0 Then
               Me.txtCaracteristica1.Text = ProductoWeb.Rows(0).Item("Caracteristica1").ToString()
               Me.txtValorCaracteristica1.Text = ProductoWeb.Rows(0).Item("ValorCaracteristica1").ToString()
               Me.txtCaracteristica2.Text = ProductoWeb.Rows(0).Item("Caracteristica2").ToString()
               Me.txtValorCaracteristica2.Text = ProductoWeb.Rows(0).Item("ValorCaracteristica2").ToString()
               Me.txtCaracteristica3.Text = ProductoWeb.Rows(0).Item("Caracteristica3").ToString()
               Me.txtValorCaracteristica3.Text = ProductoWeb.Rows(0).Item("ValorCaracteristica3").ToString()
               '-- REQ-30521.- --
               If DirectCast(_entidad, Entidades.Producto).idCategoriaMercadoLibre IsNot Nothing Then
                  Me.cmbCategoriasMercadoLibre.SelectedValue = DirectCast(_entidad, Entidades.Producto).idCategoriaMercadoLibre
                  Me.chbCategoriasMercadoLibre.Checked = True
               End If

               If Not String.IsNullOrEmpty(ProductoWeb.Rows(0).Item("Foto2").ToString()) Then
                  Dim content() As Byte = CType(ProductoWeb.Rows(0).Item("Foto2"), Byte())
                  Using stream As System.IO.MemoryStream = New System.IO.MemoryStream(content)
                     Me.pcbFoto2.Image = New System.Drawing.Bitmap(stream)
                  End Using
               End If

               If Not String.IsNullOrEmpty(ProductoWeb.Rows(0).Item("Foto3").ToString()) Then
                  Dim content() As Byte = CType(ProductoWeb.Rows(0).Item("Foto3"), Byte())
                  Using stream As System.IO.MemoryStream = New System.IO.MemoryStream(content)
                     Me.pcbFoto3.Image = New System.Drawing.Bitmap(stream)
                  End Using
               End If
               Me.chbEsParaConstructora.Checked = Boolean.Parse(ProductoWeb.Rows(0).Item(Eniac.Entidades.ProductoWeb.Columnas.EsParaConstructora.ToString()).ToString())
               Me.chbEsParaIndustria.Checked = Boolean.Parse(ProductoWeb.Rows(0).Item(Eniac.Entidades.ProductoWeb.Columnas.EsParaIndustria.ToString()).ToString())
               Me.chbEsParaCooperativa.Checked = Boolean.Parse(ProductoWeb.Rows(0).Item(Eniac.Entidades.ProductoWeb.Columnas.EsParaCooperativaElectrica.ToString()).ToString())
               Me.chbEsParaMayorista.Checked = Boolean.Parse(ProductoWeb.Rows(0).Item(Eniac.Entidades.ProductoWeb.Columnas.EsParaMayorista.ToString()).ToString())
               Me.chbEsParaMinorista.Checked = Boolean.Parse(ProductoWeb.Rows(0).Item(Eniac.Entidades.ProductoWeb.Columnas.EsParaMinorista.ToString()).ToString())
            End If

            'If DirectCast(_entidad, Entidades.Producto).UnidadDeMedida2 IsNot Nothing Then Me.cmbUnidadDeMedida2.SelectedValue = DirectCast(_entidad, Entidades.Producto).UnidadDeMedida2.IdUnidadDeMedida

            If DirectCast(_entidad, Entidades.Producto).TipoBonificacion = Entidades.Producto.TiposBonificacionesProductos.LISTAPRECIO Then Me.rbBonificacionListaPrecio.Checked = True

            Dim cantidadUltimasCompras = Reglas.Publicos.ProductosCantidadComprasSolapaCompras
            If cantidadUltimasCompras = 0 Then
               If tbcDetalle.TabPages.Contains(tbpUltimasCompras) Then
                  tbcDetalle.TabPages.Remove(tbpUltimasCompras)
               End If
            Else
               Dim prevPage = tbcDetalle.SelectedTab
               tbcDetalle.SelectedTab = tbpUltimasCompras
               Dim titUltimasCompras = GetColumnasVisiblesGrilla(ugUltimasCompras)
               tbcDetalle.SelectedTab = prevPage
               Dim rComprasProd = New Reglas.ComprasProductos()
               Dim dtDetalle = rComprasProd.GetDetallePorProductos(
                                             actual.Sucursal.Id, desde:=Nothing, hasta:=Nothing,
                                             DirectCast(_entidad, Entidades.Producto).IdProducto,
                                             idMarca:=0, rubros:={}, subrubros:={}, subsubrubros:={},
                                             idTipoComprobante:=String.Empty, idComprador:=0, idProveedor:=0,
                                             grabaLibro:="TODOS", afectaCaja:="TODOS", idFormaDePago:=0,
                                             cantidad:=String.Empty, periodoFiscalDesde:=0, periodoFiscalHasta:=0,
                                             cantidadUltimasCompras, Entidades.ComprasProductos_GetDetallePorProductos_OrderBy.FechaDescendente)

               ugUltimasCompras.DataSource = dtDetalle
               AjustarColumnasGrilla(ugUltimasCompras, titUltimasCompras)
               ugUltimasCompras.AgregarFiltroEnLinea({"NombreProveedor"})
               ugUltimasCompras.AgregarTotalesSuma({"Cantidad"})
            End If

            tbcDetalle.SelectedTab = tbpDatos

            Dim idMarca = ProductoE.IdMarca
            Dim idModelo = ProductoE.IdModelo
            Dim idRubro = ProductoE.IdRubro
            Dim idSubRubro = ProductoE.IdSubRubro
            Dim idSubSubRubro = ProductoE.IdSubSubRubro

            If idMarca <> 0 Then
               bscCodigoMarca.Text = idMarca.ToString()
               bscCodigoMarca.PresionarBoton()
            End If
            If idModelo <> 0 Then
               bscCodigoModelo.Text = idModelo.ToString()
               bscCodigoModelo.PresionarBoton()
            End If
            If idRubro <> 0 Then
               bscCodigoRubro.Text = idRubro.ToString()
               bscCodigoRubro.PresionarBoton()
            End If
            If idSubRubro <> 0 Then
               bscCodigoSubRubro.Text = idSubRubro.ToString()
               If Reglas.Publicos.ProductoTieneSubRubro Then
                  bscCodigoSubRubro.PresionarBoton()
               End If
            End If
            If idSubSubRubro <> 0 Then
               bscCodigoSubSubRubro.Text = idSubSubRubro.ToString()
               bscCodigoSubSubRubro.PresionarBoton()
            End If

            tbcDetalle.SelectedTab = tbpPrecios

         End If

         '-- REQ-38948.- --------------------------------------------
         _publicos.CargaComboProcesosProductivos(Me.cmbProcesoProductivoDefecto, Me.txtIdProducto.Text, Entidades.Publicos.SiNoTodos.SI)
         '-----------------------------------------------------------

         '-- REQ-42330.- ---------------------------------------------------------------------------------------------------------------
         '-- Carga Listas Controles Items.- -------------------------------------------------------------------------------------------- 
         Dim rCalidad = New Reglas.CalidadListasControl()
         With ugCalidad
            .DataSource = rCalidad.GetAll()
         End With
         AjustarColumnasGrilla(ugCalidad, _titCalidad)
         '-- Carga Listas Controles Items Productos.- ----------------------------------------------------------------------------------
         Dim rCalidadP = New Reglas.CalidadListasControlProductos()
         _calidadProductos = New List(Of Entidades.CalidadListaControlProducto)
         If ProductoE.CalidadListaProductos IsNot Nothing Then
            _calidadProductos = ProductoE.CalidadListaProductos
         End If
         With ugCalidadProductos
            .DataSource = _calidadProductos
         End With
         AjustarColumnasGrilla(ugCalidadProductos, _titCalidadProducto)
         '------------------------------------------------------------------------------------------------------------------------------

         ugIdentificaciones.DataSource = DirectCast(Me._entidad, Entidades.Producto).Identificaciones
         AjustarColumnasGrilla(ugIdentificaciones, _titIdentificaciones)
         ugIdentificaciones.AgregarFiltroEnLinea({Entidades.ProductoIdentificacion.Columnas.Identificacion.ToString()})


         MostrarUltimoPrecioCosto(DirectCast(Me._entidad, Entidades.Producto))

         Me.grbAjusteStock.Visible = New Reglas.Usuarios().TienePermisos(actual.Nombre, actual.Sucursal.Id, "MovimientosDeStock")

         Me.grpCuentaComprasSecundaria.Visible = Reglas.ContabilidadPublicos.ContabilidadCuentaSecundariaProducto

         Me.CreaDTPrecios()
         dgvListasPrecios.DataSource = dtListaPrecios

         Me.CargaDTPrecios()
         FormateaGrillaPrecios()

         If Not Publicos.ProductoTieneModelo Then
            lnkModelo.Enabled = False
            bscCodigoModelo.Enabled = False
            bscModelo.Enabled = False
         End If

         If Not Reglas.Publicos.ProductoTieneSubRubro Then
            lnkSubRubro.Enabled = False
            bscCodigoSubRubro.Enabled = False
            bscSubRubro.Enabled = False
         End If

         If Not Reglas.Publicos.ProductoTieneSubSubRubro Then
            lnkSubSubRubro.Enabled = False
            bscCodigoSubSubRubro.Enabled = False
            bscSubSubRubro.Enabled = False
         End If

         If Not Reglas.Publicos.TieneModuloProduccion Then
            tbcDetalle.TabPages.Remove(tbpProduccion)
         End If

         If Not Reglas.Publicos.TieneModuloAlquiler Then
            tbcDetalle.TabPages.Remove(Me.tbpAlquiler)
         End If

         'GAR: 12/10/2017 - Ahora lo muestro igualmente a Numero de Serie. DEbe activar la funcionalidad para que lo tome en todas las pantallas.
         chbLote.Enabled = Reglas.Publicos.VisualizaLote
         '---------------
         chbNroSerie.Enabled = Reglas.Publicos.VisualizaNrosSerie

         If Not Reglas.Publicos.TieneModuloExpensas Then
            tbcDetalle.TabPages.Remove(Me.tbpExpensas)
         End If

         If New Reglas.ProductosComponentes().GetPorProductoComponente(actual.Sucursal.Id, txtIdProducto.Text, Reglas.Publicos.ListaPreciosPredeterminada).Any() Then
            cmbUnidadDeMedida.Enabled = False
            cmbUnidadDeMedidaProduccion.Enabled = False
         ElseIf Not Reglas.Publicos.TieneModuloProduccion Then
            cmbUnidadDeMedidaProduccion.Enabled = False
         End If

         CambiaUnidadMedidaCompra()
         CambiaUnidadMedidaProduccion()

         _NombreProductoOriginal = Me.txtNombreProducto.Text

         _estaCargando = False

         txtCodigoLargoProducto.LabelAsoc.Enabled = Me._productoUtilizaCodigoLargo
         txtCodigoLargoProducto.Enabled = Me._productoUtilizaCodigoLargo

         txtPrecioLista.LabelAsoc.Visible = Me._utilizaPrecioDeCompra
         txtPrecioLista.Visible = Me._utilizaPrecioDeCompra
         txtDescuento1.LabelAsoc.Visible = Me._utilizaPrecioDeCompra
         txtDescuento1.Visible = Me._utilizaPrecioDeCompra
         txtDescuento2.LabelAsoc.Visible = Me._utilizaPrecioDeCompra
         txtDescuento2.Visible = Me._utilizaPrecioDeCompra
         txtDescuento3.LabelAsoc.Visible = Me._utilizaPrecioDeCompra
         txtDescuento3.Visible = Me._utilizaPrecioDeCompra
         txtDescuento4.LabelAsoc.Visible = Me._utilizaPrecioDeCompra
         txtDescuento4.Visible = Me._utilizaPrecioDeCompra

         btnCalcularCosto.Visible = Me._utilizaPrecioDeCompra


         If Not _MostrarPrecios Then
            tbcDetalle.TabPages.Remove(tbpPrecios)
         End If

         txtObservacionCompra.Visible = _observacionesCompras
         txtObservacionCompra.LabelAsoc.Visible = _observacionesCompras

         tbcDetalle.SelectedTab = tbpDescuentos
         chbEsCambiable.Visible = Reglas.Publicos.ProductoPermiteEsCambiable
         chbEsBonificable.Visible = Reglas.Publicos.ProductoPermiteEsBonificable
         grpCambiableBonificable.Visible = chbEsCambiable.Visible Or chbEsBonificable.Visible Or chbEsDevolucion.Visible

         '-- Carga Stock y Distribucion de Producto en Suc-Dep-Ubi.-
         CargaValoresInicialesStock()
         '----------------------------------------------------------

         tbcDetalle.SelectedTab = tbpDatos


         Me._productosOfertas = DirectCast(Me._entidad, Entidades.Producto).ProductosOfertas
         ugProductoOfertas.DataSource = Me._productosOfertas
         AjustarColumnasGrillaProductoOferta()
         RefrescarOfertas()


         ugAdjunto.DataSource = ProductoE.ArchivosAdjuntos
         AjustarColumnasGrilla(ugAdjunto, _titAdjuntos)
         ugAdjunto.AgregarFiltroEnLinea({Entidades.ProductoLinks.Columnas.Descripcion.ToString()})


         'Ayudante.Grilla.AgregarFiltroEnLinea(ugProductosProveedores, {Entidades.Proveedor.Columnas.NombreProveedor.ToString()})
         Me.lblTiempo.Text = DateTime.Now.TimeOfDay.Add(-ts).TotalSeconds.ToString()

         '# Guardo los valores iniciales de los siguientes campos
         _alicuotaInicial = DirectCast(Me.cmbTipoImpuesto.SelectedItem, Entidades.Impuesto)
         _monedaInicial = New Reglas.Monedas().GetUna(CInt(Me.cmbMoneda.SelectedValue))
         _unidadDeMedidaInicial = New Reglas.UnidadesDeMedidas().GetUno(Me.cmbUnidadDeMedida.SelectedValue.ToString())
         '-- REQ-35484.- ------------------------------------------------------------------
         subRubroActual = DirectCast(Me._entidad, Entidades.Producto).IdSubRubro
         Dim dtTieneAtributos = New Reglas.SubRubros().TieneAtributoSubRubro(DirectCast(Me._entidad, Entidades.Producto).IdSubRubro)
         If dtTieneAtributos IsNot Nothing AndAlso dtTieneAtributos.Rows.Count() > 0 AndAlso dtTieneAtributos.Rows(0).Field(Of Integer)("AtributoSubRubro") > 0 Then
            If Me.StateForm = Eniac.Win.StateForm.Actualizar And DirectCast(Me._entidad, Entidades.Producto).StockActual > 0 Then
               lnkSubRubro.Enabled = False
               bscCodigoSubRubro.Permitido = False
               bscSubRubro.Permitido = False
               '---------------------------------------------------------------------------------
               lnkRubro.Enabled = False
               bscCodigoRubro.Permitido = False
               bscRubro.Permitido = False
            End If
         End If
         '---------------------------------------------------------------------------------
         If DirectCast(Me._entidad, Entidades.Producto).RealizaControlCalidad Then
            cmbNivelInspeccion.Enabled = True
            If String.IsNullOrEmpty(DirectCast(Me._entidad, Entidades.Producto).NivelInspeccion) Then
               cmbNivelInspeccion.SelectedIndex = -1
            Else
               cmbNivelInspeccion.SelectedIndex = Integer.Parse(DirectCast(Me._entidad, Entidades.Producto).NivelInspeccion)
            End If
         End If
         '---------------------------------------------------------------------------------
         ActualizarLabelsPublicarEn()

         RecalculaStock()
         Me.tbcDetalle.SelectedTab = tbpDatos

      Catch ex As Exception
         Dim erro As String = ex.Message
         If ex.InnerException IsNot Nothing Then
            erro += " - " + ex.InnerException.Message
         End If

         MessageBox.Show(erro, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try

   End Sub

   Protected Overrides Function GetReglas() As Eniac.Reglas.Base
      Return New Reglas.Productos()
   End Function

   Protected Overrides Function ValidarDetalle() As String

      'Validaciones Exclusivas cuando es nuevo.
      If Me.StateForm = Eniac.Win.StateForm.Insertar Then
         'Para evitar el Trhow y el mensaje de error al correo de soporte.

         Dim ExisteProducto As Boolean
         'If Me._reglasProductos Is Nothing Then
         Me._reglasProductos = New Reglas.Productos()
         'End If

         ExisteProducto = Me._reglasProductos.Existe(Me.txtIdProducto.Text.Trim())

         If ExisteProducto Then
            Return "El Código de Producto Ya Existe."
         End If
      End If

      If Not Me.bscCodigoMarca.Selecciono And Not Me.bscMarca.Selecciono Then
         Me.tbcDetalle.SelectedTab = Me.tbpDatos
         Me.bscMarca.Focus()
         Return "No selecciono la Marca."
      End If

      If Me.bscCodigoModelo.Enabled And Not Me.bscCodigoModelo.Selecciono And Not Me.bscModelo.Selecciono Then
         Me.tbcDetalle.SelectedTab = Me.tbpDatos
         Me.bscModelo.Focus()
         Return "No selecciono el Modelo."
      End If

      If Not Me.bscCodigoRubro.Selecciono And Not Me.bscRubro.Selecciono Then
         Me.tbcDetalle.SelectedTab = Me.tbpDatos
         Me.bscRubro.Focus()
         Return "No selecciono el Rubro."
      End If

      If Decimal.Parse("0" & Me.txtTamanio.Text.Trim()) > 0 And Me.cmbUnidadDeMedida.SelectedIndex = -1 Then
         Me.tbcDetalle.SelectedTab = Me.tbpDatos
         Me.cmbUnidadDeMedida.Focus()
         Return "Debe elegir la Unidad de Medida si cargo el Tamaño."
      End If

      If Decimal.Parse("0" & Me.txtTamanio.Text.Trim()) = 0 And Me.cmbUnidadDeMedida.SelectedIndex >= 0 Then
         Me.tbcDetalle.SelectedTab = Me.tbpDatos
         Me.txtTamanio.Focus()
         Return "Debe ingresar el Tamaño si eligio la Unidad de Medida."
      End If

      If Decimal.Parse("0" & Me.txtFactorConversionCompra.Text.Trim()) = 0 And Me.cmbUnidadDeMedidaCompra.SelectedIndex >= 0 Then
         Me.tbcDetalle.SelectedTab = Me.tbpDatos
         Me.txtFactorConversionCompra.Focus()
         Return "Debe ingresar el factor de conversión de Compra, no puede ser 0."
      End If

      If Decimal.Parse("0" & Me.txtFactorConversionProduccion.Text.Trim()) = 0 And Me.cmbUnidadDeMedidaProduccion.SelectedIndex >= 0 Then
         Me.tbcDetalle.SelectedTab = Me.tbpDatos
         Me.txtFactorConversionProduccion.Focus()
         Return "Debe ingresar el factor de conversión de Producción, no puede ser 0."
      End If

      If Integer.Parse("0" & Me.txtOrden.Text.Trim()) = 0 Then
         Me.tbcDetalle.SelectedTab = Me.tbpDatos
         Me.txtOrden.Focus()
         Return "El Orden de impresión no puede ser 0."
      End If

      If Me.chbPrecioPorEmbalaje.Checked And Integer.Parse(Me.txtEmbalaje.Text.ToString()) = 0 Then
         Return "Precio por Embalaje está activo, es necesario ingresar un valor en el campo Embalaje"
      End If

      'If Me.chbAfectaStock.Checked And Integer.Parse(Me.txtEmbalaje.Text.ToString()) = 0 Then
      '   Return "Embalaje no puede ser 0"
      'End If
      '-------------- Validaciones de STOCK y LOTES/NROS SERIES --------------

      Dim oProdSuc As Reglas.ProductosSucursales = New Reglas.ProductosSucursales()
      Dim ProdSuc As Entidades.ProductoSucursal

      ProdSuc = oProdSuc.GetUno(actual.Sucursal.Id, Me.txtIdProducto.Text)

      'If oProdSuc.GetProductoTieneStock(Me.txtId.Text, 0) And Not Me.chbActivo.Checked And ProdSuc.Producto.Activo Then
      '   Return "NO Puede desactivar un Producto con Stock, primero debe llevarlo a Cero."
      'End If

      '###################################################################
      '#   Esta validación se paso al momento de cargar la pantalla      #
      '###################################################################

      ' '' '' ''Dim dtDetalle As DataTable = oProdSuc.GetProductoConStock(Me.txtIdProducto.Text, 0)

      ' '' '' ''For Each dr As DataRow In dtDetalle.Rows
      ' '' '' ''   'Si tiene Stock Negativo lo voy a bloquear al grabar.
      ' '' '' ''   If Decimal.Parse(dr("Stock").ToString()) < 0 And Me.chbLote.Checked And Not ProdSuc.Producto.Lote Then
      ' '' '' ''      Return "NO Puede Activar la Propiedad de Lotes a un Producto con Stock Negativo, primero debe llevarlo a Cero."
      ' '' '' ''   End If

      ' '' '' ''   If Decimal.Parse(dr("Stock").ToString()) < 0 And Me.chbNroSerie.Checked And Not ProdSuc.Producto.NroSerie Then
      ' '' '' ''      Return "NO Puede Activar la Propiedad de Nro. Serie a un Producto con Stock Negativo, primero debe llevarlo a Cero."
      ' '' '' ''   End If
      ' '' '' ''Next

      ' '' '' ''If dtDetalle.Rows.Count > 0 And Not Me.chbLote.Checked And ProdSuc.Producto.Lote Then
      ' '' '' ''   Return "NO Puede Sacar la Propiedad de Lotes a un Producto con Stock, primero debe llevarlo a Cero."
      ' '' '' ''End If
      ' '' '' ''If dtDetalle.Rows.Count > 0 And Not Me.chbNroSerie.Checked And ProdSuc.Producto.NroSerie Then
      ' '' '' ''   Return "NO Puede Sacar la Propiedad de Nro. Serie a un Producto con Stock, primero debe llevarlo a Cero."
      ' '' '' ''End If

      '# Valido que si el producto va a utilizar alguna de estas dos propiedades, afecte stock.
      If Me.chbLote.Checked OrElse Me.chbNroSerie.Checked Then
         If Not Me.chbAfectaStock.Checked Then Return String.Format("El producto debe afectar stock si utiliza {0}.", If(chbLote.Checked, "Lote", "Nro. Serie"))
      End If

      '-------------- Validaciones de PRODUCCION --------------

      'Que le asigne primero la formula y luego lo modifique.
      If Not Me.chbEsCompuesto.Checked And Me.chbDescontarStockComp.Checked Then
         Me.tbcDetalle.SelectedTab = Me.tbpProduccion
         Me.chbDescontarStockComp.Focus()
         Return "NO Puede Activar la Propiedad de Descontar Stock de Componentes a un producto que NO tiene Formula."
      End If

      '-------------- Validaciones de ALQUILER --------------

      If Me.chbEsAlquilable.Checked And Me.txtAnio.Text <> "" AndAlso Integer.Parse(Me.txtAnio.Text) < 1900 Then
         Me.tbcDetalle.SelectedTab = Me.tbpAlquiler
         Me.txtAnio.Focus()
         Return "Debe ingresar un Año válido."
      End If

      '------------------------------------------------------------

      If Me.tbcDetalle.Contains(Me.tbpExpensas) And Me.chbEsDeCompras.Checked And Me.dgvDetalleConceptos.RowCount = 0 And Not Reglas.Publicos.ExpensasPermitirCargarProductosSinConceptos Then
         Me.tbcDetalle.SelectedTab = Me.tbpExpensas
         Me.bscCodigoConcepto.Focus()
         Return "Indico que el Producto es de Compras pero NO cargo Conceptos, debe asignar al menos uno."
      End If

      'Controla que no exista el codigo de barra

      If Not String.IsNullOrEmpty(Me.txtCodigoDeBarras.Text.Trim()) Then
         If DirectCast(_entidad, Entidades.Producto).Identificaciones.Exists(Function(x) x.Identificacion = txtCodigoDeBarras.Text) Then
            Return "El Código de Barras se repite como Código Alternativo. Por favor revise y vuelva a intentar."
         End If

         If chbCodigoDeBarrasConPrecio.Checked AndAlso txtCodigoDeBarras.Text.Length <> Reglas.Publicos.CaracteresProductoCBPesoCantidad Then
            Return String.Format("El producto está configurado como Código de Barra con {0}. El Código de barra debe tener {1} caracteres.",
                                 cmbModalidadCodigoDeBarras.Text, Reglas.Publicos.CaracteresProductoCBPesoCantidad)
         End If

      End If

      If Not String.IsNullOrEmpty(Me.txtCodigoDeBarras.Text.Trim()) OrElse DirectCast(_entidad, Entidades.Producto).Identificaciones.Count > 0 Then

         Dim ExisteCodigoDeBarra As Reglas.Validaciones.ValidacionResult

         ExisteCodigoDeBarra = Me._reglasProductos.ExisteCodigoDeBarrasRepetido(Me.txtIdProducto.Text.Trim(), Me.txtCodigoDeBarras.Text.Trim(),
                                                                                DirectCast(_entidad, Entidades.Producto).Identificaciones)

         If ExisteCodigoDeBarra.Error Then
            'If MessageBox.Show("El Codigo de Barra ya Existe, Desea Continuar de todas formas?", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) <> Windows.Forms.DialogResult.Yes Then
            If ShowPregunta(String.Format("{0}{1}{1}¿Desea Continuar de todas formas?", ExisteCodigoDeBarra.MensajeError, Environment.NewLine)) = Windows.Forms.DialogResult.No Then
               Return "El Código de Barra Ya Existe."
            End If
         End If

      End If

      If chbEsObservacion.Checked Then
         If Not chbPermiteModificarDescripcion.Checked Then
            Return "Para productos que son Observaciones, deber indicar que se permite modificar la descripción."
         End If
         If chbAfectaStock.Checked Then
            Return "Para productos que son Observaciones, no debe afectar stock."
         End If
         If chbAlertaDeCaja.Checked Then
            Return "Para productos que son Observaciones, no debe tener marcado Alerta de Caja."
         End If
      End If
      If (Decimal.Parse(Me.txtUnidHasta1.Text) <> 0 And Decimal.Parse(Me.txtUHPorc1.Text) = 0 Or
         Decimal.Parse(Me.txtUnidHasta2.Text) <> 0 And Decimal.Parse(Me.txtUHPorc2.Text) = 0 Or
         Decimal.Parse(Me.txtUnidHasta3.Text) <> 0 And Decimal.Parse(Me.txtUHPorc3.Text) = 0 Or
         Decimal.Parse(Me.txtUnidHasta4.Text) <> 0 And Decimal.Parse(Me.txtUHPorc4.Text) = 0 Or
         Decimal.Parse(Me.txtUnidHasta5.Text) <> 0 And Decimal.Parse(Me.txtUHPorc5.Text) = 0) AndAlso Me.rbBonificacionDescuento.Checked Then
         Return "El porcentaje no puede ser 0 si ingreso la cantidad."
      ElseIf (Decimal.Parse(Me.txtUnidHasta1.Text) <> 0 AndAlso Me.cmbBonificacionListaDePrecios1.SelectedIndex = -1 Or
             Decimal.Parse(Me.txtUnidHasta2.Text) <> 0 AndAlso Me.cmbBonificacionListaDePrecios2.SelectedIndex = -1 Or
             Decimal.Parse(Me.txtUnidHasta3.Text) <> 0 AndAlso Me.cmbBonificacionListaDePrecios3.SelectedIndex = -1 Or
             Decimal.Parse(Me.txtUnidHasta4.Text) <> 0 AndAlso Me.cmbBonificacionListaDePrecios4.SelectedIndex = -1 Or
             Decimal.Parse(Me.txtUnidHasta5.Text) <> 0 AndAlso Me.cmbBonificacionListaDePrecios5.SelectedIndex = -1) AndAlso Me.rbBonificacionListaPrecio.Checked Then
         Return "Debe seleccionar una Lista de Precio si ingreso la cantidad."
      End If
      If (Decimal.Parse(Me.txtUHPorc1.Text) > 0 Or
         Decimal.Parse(Me.txtUHPorc2.Text) > 0 Or
         Decimal.Parse(Me.txtUHPorc3.Text) > 0 Or
         Decimal.Parse(Me.txtUHPorc4.Text) > 0 Or
         Decimal.Parse(Me.txtUHPorc5.Text) > 0) AndAlso Me.rbBonificacionDescuento.Checked Then
         If Decimal.Parse(Me.txtUHPorc5.Text) > 0 Then
            Me.txtUHPorc5.Focus()
         End If
         If Decimal.Parse(Me.txtUHPorc4.Text) > 0 Then
            Me.txtUHPorc4.Focus()
         End If
         If Decimal.Parse(Me.txtUHPorc3.Text) > 0 Then
            Me.txtUHPorc3.Focus()
         End If
         If Decimal.Parse(Me.txtUHPorc2.Text) > 0 Then
            Me.txtUHPorc2.Focus()
         End If
         If Decimal.Parse(Me.txtUHPorc1.Text) > 0 Then
            Me.txtUHPorc1.Focus()
         End If
         Return "El porcentaje debe ser negativo"
      End If
      If Decimal.Parse(Me.txtUnidHasta2.Text) <> 0 Then
         If Decimal.Parse(Me.txtUnidHasta2.Text) <= Decimal.Parse(Me.txtUnidHasta1.Text) Then
            Return "Las cantidades de bonificaciones por volumen deben ir en orden."
         End If
      End If
      If Decimal.Parse(Me.txtUnidHasta3.Text) <> 0 Then
         If Decimal.Parse(Me.txtUnidHasta3.Text) <= Decimal.Parse(Me.txtUnidHasta2.Text) Then
            Return "Las cantidades de bonificaciones por volumen deben ir en orden."
         End If
      End If
      If Decimal.Parse(Me.txtUnidHasta4.Text) <> 0 Then
         If Decimal.Parse(Me.txtUnidHasta4.Text) <= Decimal.Parse(Me.txtUnidHasta3.Text) Then
            Return "Las cantidades de bonificaciones por volumen deben ir en orden."
         End If
      End If
      If Decimal.Parse(Me.txtUnidHasta5.Text) <> 0 Then
         If Decimal.Parse(Me.txtUnidHasta5.Text) <= Decimal.Parse(Me.txtUnidHasta4.Text) Then
            Return "Las cantidades de bonificaciones por volumen deben ir en orden."
         End If
      End If

      If cmbEsOferta.SelectedIndex = -1 Then
         Return "No seleccionó si es Oferta."
      End If

      Dim iii As Decimal = 0
      Dim pii As Decimal = 0
      If IsNumeric(txtPorcImpuestoInterno.Text) Then
         pii = Decimal.Parse(txtPorcImpuestoInterno.Text)
      End If

      Return MyBase.ValidarDetalle()

   End Function

   Protected Overrides Sub Aceptar()

      '-- REQ-35484.- ------------------------------------------------------------------
      If subRubroActual <> DirectCast(Me._entidad, Entidades.Producto).IdSubRubro Then
         Dim stockActual As DataRow = New Reglas.Productos().GetStockPorProducto(txtIdProducto.Text).AsEnumerable().FirstOrDefault()
         Dim TieneAtributos As DataRow = New Reglas.SubRubros().TieneAtributoSubRubro(DirectCast(Me._entidad, Entidades.Producto).IdSubRubro).AsEnumerable().FirstOrDefault()

         If Me.StateForm = Eniac.Win.StateForm.Actualizar AndAlso
            TieneAtributos IsNot Nothing AndAlso TieneAtributos.Field(Of Integer)("AtributoSubRubro") > 0 AndAlso
            stockActual IsNot Nothing AndAlso Decimal.Parse(stockActual("Stock").ToString()) > 0 Then

            ShowMessage("ATENCIÓN: ¡No es posible modificar el SubRubro! El mismo contiene movimientos de Stock")
            Exit Sub
         End If
      End If
      '---------------------------------------------------------------------------------
      If DirectCast(Me._entidad, Entidades.Producto).IdSubRubro > 0 And _SubRubroAtributo And Not chbAfectaStock.Checked Then
         MessageBox.Show(String.Format("Producto que no afecta Stock No puede tener {0}SubRubro ({1}) con Atributos", Environment.NewLine, bscSubRubro.Text), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
         bscCodigoSubRubro.Focus()
         Exit Sub
      End If
      '# En caso que se haya modificado alguno de estos campos, debo pedir la confirmación del usuario para continuar
      '---------------------------------------------------------------------------------
      If cmbUnidadDeMedida.SelectedIndex = -1 Then
         tbcDetalle.SelectedTab = tbpDatos
         cmbUnidadDeMedida.Focus()
         ShowMessage("Debe elegir la Unidad de Medida")
         Exit Sub
      Else
         DirectCast(Me._entidad, Entidades.Producto).UnidadDeMedida.IdUnidadDeMedida = cmbUnidadDeMedida.ValorSeleccionado(String.Empty)
      End If


      If _unidadDeMedidaInicial.IdUnidadDeMedida <> New Reglas.UnidadesDeMedidas().GetUno(Me.cmbUnidadDeMedida.SelectedValue.ToString()).IdUnidadDeMedida Then
         If Not ShowPregunta(String.Format("Se cambió el valor de Unidad de Medida de {0} a {1} ¿Desea continuar?", _unidadDeMedidaInicial.NombreUnidadDeMedida, Me.cmbUnidadDeMedida.Text)) = DialogResult.Yes Then
            Exit Sub
         End If
      End If
      If _alicuotaInicial.Alicuota <> DirectCast(Me.cmbTipoImpuesto.SelectedItem, Entidades.Impuesto).Alicuota Then
         If Not ShowPregunta(String.Format("Se cambió el valor de Alícuota de {0} a {1} ¿Desea continuar?", _alicuotaInicial.Alicuota, DirectCast(Me.cmbTipoImpuesto.SelectedItem, Entidades.Impuesto).Alicuota)) = DialogResult.Yes Then
            Exit Sub
         End If
      End If
      If _monedaInicial.IdMoneda <> New Reglas.Monedas().GetUna(CInt(Me.cmbMoneda.SelectedValue)).IdMoneda Then
         If Not ShowPregunta(String.Format("Se cambió el valor de Moneda de {0} a {1} ¿Desea continuar?", _monedaInicial.NombreMoneda, Me.cmbMoneda.Text)) = DialogResult.Yes Then
            Exit Sub
         End If
      End If

      dgvListasPrecios.UpdateData()
      ugProductoOfertas.UpdateData()

      DirectCast(Me._entidad, Entidades.Producto).Alicuota2 = -1

      '-- REQ-43847 ------------------------------------------------------------------------------
      DirectCast(Me._entidad, Entidades.Producto).Ubicacion = Me.txtUbicacion.Text
      '-------------------------------------------------------------------------------------------

      If ugProductoOfertas.Rows.Count > 0 Then
         DirectCast(Me._entidad, Entidades.Producto).ProductosOfertas = _productosOfertas
      End If

      If ugAdjunto.Rows.Count > 0 Then
         DirectCast(Me._entidad, Entidades.Producto).ArchivosAdjuntos = ProductoE.ArchivosAdjuntos
      End If

      '-- REQ-39778 ------------------------------------------------------------------------------
      Dim _Ofertas = (From prodof In _productosOfertas
                      Where prodof.FechaHasta > Now.Date And prodof.Activa = True And prodof.LimiteStock <> prodof.CantidadConsumida
                      Select prodof.IdOferta).ToList()

      If _productosOfertas.Count > 0 Then
         cmbEsOferta.SelectedIndex = If(_Ofertas.Count > 0, 1, 0)
      End If
      '-------------------------------------------------------------------------------------------
      With DirectCast(Me._entidad, Entidades.Producto)
         If Me.bscCodigoProveedor.Selecciono AndAlso
            Me.bscCodigoProveedor.Tag IsNot Nothing AndAlso
            CLng(Me.bscCodigoProveedor.Tag.ToString()) > 0 Then
            If .Proveedor Is Nothing Then
               .Proveedor = New Entidades.Proveedor()
            End If
            .Proveedor.IdProveedor = CLng(Me.bscCodigoProveedor.Tag.ToString())
            If .ProductoProveedorHabitual Is Nothing Then
               .ProductoProveedorHabitual = New Entidades.ProductoProveedor()
               .ProductoProveedorHabitual.UltimaFechaCompra = Nothing
            End If
            .ProductoProveedorHabitual.IdProveedor = .Proveedor.IdProveedor
            .ProductoProveedorHabitual.IdProducto = Me.txtIdProducto.Text
            .ProductoProveedorHabitual.UltimoPrecioCompra = Decimal.Parse(txtUltimoPrecioCompra.Text)
            .ProductoProveedorHabitual.UltimoPrecioFabrica = Decimal.Parse(txtPrecioLista.Text)
            .ProductoProveedorHabitual.DescuentoRecargoPorc1 = Decimal.Parse(txtDescuento1.Text)
            .ProductoProveedorHabitual.DescuentoRecargoPorc2 = Decimal.Parse(txtDescuento2.Text)
            .ProductoProveedorHabitual.DescuentoRecargoPorc3 = Decimal.Parse(txtDescuento3.Text)
            .ProductoProveedorHabitual.DescuentoRecargoPorc4 = Decimal.Parse(txtDescuento4.Text)
            .ProductoProveedorHabitual.CodigoProductoProveedor = txtCodigoProductoProveedor.Text
         Else
            .Proveedor = Nothing
            .ProductoProveedorHabitual = Nothing
         End If

         If .Precios Is Nothing Then
            .Precios = New DataTable()
            .Precios.Columns.Add("IdProducto", GetType(String))
            .Precios.Columns.Add("IdListaPrecios", GetType(String))

            .Precios.Columns.Add("IdSucursal", GetType(Integer))
            .Precios.Columns.Add("PrecioVenta", GetType(Decimal))
            .Precios.Columns.Add("PrecioVentaBase", GetType(Decimal))
            .Precios.Columns.Add("PorcentajeBase", GetType(Decimal))
            .Precios.Columns.Add("PrecioCosto", GetType(Decimal))
            .Precios.Columns.Add("PorcentajeCosto", GetType(Decimal))
            .Precios.Columns.Add("NombreListaPrecios", GetType(String))
            .Precios.Columns.Add("NombreProducto", GetType(String))
         End If

         For Each drListaPrecios As DataRow In dtListaPrecios.Rows
            Dim drs() As DataRow = .Precios.Select(String.Format("{0} = {1}", ListaPreciosColumns.IdListaPrecios.ToString(), drListaPrecios(ListaPreciosColumns.IdListaPrecios.ToString())))
            If drs.Length = 0 Then
               Dim drPrecios As DataRow = .Precios.NewRow
               .Precios.Rows.Add(drPrecios)
               drPrecios("IdProducto") = .IdProducto
               drPrecios("IdListaPrecios") = drListaPrecios(ListaPreciosColumns.IdListaPrecios.ToString())
               drPrecios("IdProducto") = actual.Sucursal.Id
               drPrecios(ListaPreciosColumns.PrecioVenta.ToString()) = drListaPrecios(ListaPreciosColumns.PrecioVenta.ToString())
               drPrecios("NombreProducto") = .NombreProducto
               drPrecios("NombreListaPrecios") = drListaPrecios(ListaPreciosColumns.NombreListaPrecios.ToString())

               drPrecios("PrecioVentaBase") = drListaPrecios("PrecioVentaBase")
               drPrecios("PorcentajeBase") = drListaPrecios("PorcentajeBase")
               drPrecios("PrecioCosto") = drListaPrecios("PrecioCosto")
               drPrecios("PorcentajeCosto") = drListaPrecios("PorcentajeCosto")
            Else
               For Each drPrecios As DataRow In drs
                  drPrecios(ListaPreciosColumns.PrecioVenta.ToString()) = drListaPrecios(ListaPreciosColumns.PrecioVenta.ToString())
               Next
            End If
         Next
         .PrecioCosto = CDec(Me.txtPrecioCosto.Text)
         If cmbProcesoProductivoDefecto.SelectedIndex > -1 Then
            .IdProcesoProductivoDefecto = Integer.Parse(cmbProcesoProductivoDefecto.SelectedValue.ToString())
         End If

      End With

      Me.IdProducto = Me.txtIdProducto.Text

      If Me._tieneModuloContabilidad Then
         DirectCast(_entidad, Entidades.Producto).CuentaCompras = UcCuentasCompras.Cuenta
         DirectCast(_entidad, Entidades.Producto).CuentaVentas = UcCuentasVentas.Cuenta
         If Reglas.ContabilidadPublicos.ContabilidadCuentaSecundariaProducto Then
            DirectCast(_entidad, Entidades.Producto).CuentaComprasSecundaria = UcCuentasComprasSecundaria.Cuenta
         Else
            DirectCast(_entidad, Entidades.Producto).CuentaComprasSecundaria = Nothing
         End If
         If Reglas.ContabilidadPublicos.UtilizaCentroCostos AndAlso IsNumeric(bscCodigoCentroCosto.Text) Then
            DirectCast(_entidad, Entidades.Producto).CentroCosto = New Reglas.ContabilidadCentrosCostos().GetUna(Integer.Parse(bscCodigoCentroCosto.Text))
         Else
            DirectCast(_entidad, Entidades.Producto).CentroCosto = Nothing
         End If
      Else
         DirectCast(_entidad, Entidades.Producto).CuentaCompras = Nothing
         DirectCast(_entidad, Entidades.Producto).CuentaVentas = Nothing
         DirectCast(_entidad, Entidades.Producto).CuentaComprasSecundaria = Nothing
      End If

      If Not chbProduccionForma.Checked Then
         DirectCast(_entidad, Entidades.Producto).IdProduccionForma = 0
      End If
      If Not chbProduccionProceso.Checked Then
         DirectCast(_entidad, Entidades.Producto).IdProduccionProceso = 0
      End If

      'parametro Producto WEB
      With DirectCast(Me._entidad, Entidades.Producto)
         If .ProductosWeb Is Nothing Then
            .ProductosWeb = New Entidades.ProductoWeb()
         End If
         .ProductosWeb.Caracteristica1 = Me.txtCaracteristica1.Text
         .ProductosWeb.ValorCaracteristica1 = Me.txtValorCaracteristica1.Text
         .ProductosWeb.Caracteristica2 = Me.txtCaracteristica2.Text
         .ProductosWeb.ValorCaracteristica2 = Me.txtValorCaracteristica2.Text
         .ProductosWeb.Caracteristica3 = Me.txtCaracteristica3.Text
         .ProductosWeb.ValorCaracteristica3 = Me.txtValorCaracteristica3.Text
         .ProductosWeb.Foto2 = Me.pcbFoto2.Image
         .ProductosWeb.Foto3 = Me.pcbFoto3.Image
         .ProductosWeb.EsParaConstructora = Me.chbEsParaConstructora.Checked
         .ProductosWeb.EsParaIndustria = Me.chbEsParaIndustria.Checked
         .ProductosWeb.EsParaCooperativaElectrica = Me.chbEsParaCooperativa.Checked
         .ProductosWeb.EsParaMayorista = Me.chbEsParaMayorista.Checked
         .ProductosWeb.EsParaMinorista = Me.chbEsParaMinorista.Checked

      End With
      DirectCast(_entidad, Entidades.Producto).CalidadStatusEntregado = False
      DirectCast(_entidad, Entidades.Producto).CalidadStatusLiberado = False

      DirectCast(Me._entidad, Entidades.Producto).Lote = Me.chbLote.Checked
      DirectCast(Me._entidad, Entidades.Producto).NroSerie = Me.chbNroSerie.Checked

      '-- REQ-30521.- ---------------------------------------------------------------
      If cmbCategoriasMercadoLibre.SelectedIndex <> -1 Then
         DirectCast(Me._entidad, Entidades.Producto).idCategoriaMercadoLibre = cmbCategoriasMercadoLibre.SelectedValue.ToString()
         Me.chbCategoriasMercadoLibre.Checked = True
      Else
         DirectCast(Me._entidad, Entidades.Producto).idCategoriaMercadoLibre = Nothing
         Me.chbCategoriasMercadoLibre.Checked = False
      End If
      '------------------------------------------------------------------------------
      '-- REQ-31619.- ---------------------------------------------------------------
      If Len(Trim(txtNombreWeb.Text)) = 0 Then
         DirectCast(Me._entidad, Entidades.Producto).NombreProductoWeb = ""
      Else
         DirectCast(Me._entidad, Entidades.Producto).NombreProductoWeb = txtNombreWeb.Text
      End If
      '------------------------------------------------------------------------------

      '# Una vez seleccionado un tipo de bonificación, la otra se limpia.
      If Me.rbBonificacionDescuento.Checked Then
         DirectCast(Me._entidad, Entidades.Producto).TipoBonificacion = Entidades.Producto.TiposBonificacionesProductos.DESCUENTO

         Me.cmbBonificacionListaDePrecios1.SelectedIndex = -1
         Me.cmbBonificacionListaDePrecios2.SelectedIndex = -1
         Me.cmbBonificacionListaDePrecios3.SelectedIndex = -1
         Me.cmbBonificacionListaDePrecios4.SelectedIndex = -1
         Me.cmbBonificacionListaDePrecios5.SelectedIndex = -1
      Else
         DirectCast(Me._entidad, Entidades.Producto).TipoBonificacion = Entidades.Producto.TiposBonificacionesProductos.LISTAPRECIO

         txtUHPorc1.Text = "0.00"
         txtUHPorc2.Text = "0.00"
         txtUHPorc3.Text = "0.00"
         txtUHPorc4.Text = "0.00"
         txtUHPorc5.Text = "0.00"

         If txtUnidHasta1.ValorNumericoPorDefecto(0D) = 0 Then
            cmbBonificacionListaDePrecios1.SelectedIndex = -1
         End If
         If txtUnidHasta2.ValorNumericoPorDefecto(0D) = 0 Then
            cmbBonificacionListaDePrecios2.SelectedIndex = -1
         End If
         If txtUnidHasta3.ValorNumericoPorDefecto(0D) = 0 Then
            cmbBonificacionListaDePrecios3.SelectedIndex = -1
         End If
         If txtUnidHasta4.ValorNumericoPorDefecto(0D) = 0 Then
            cmbBonificacionListaDePrecios4.SelectedIndex = -1
         End If
         If txtUnidHasta5.ValorNumericoPorDefecto(0D) = 0 Then
            cmbBonificacionListaDePrecios5.SelectedIndex = -1
         End If

      End If

      MyBase.Aceptar()

      If Not HayError And Decimal.Parse(Me.txtAjusteStock.Text) <> 0 Then
         Me.CargarAjusteStock()
         Me.txtStockActual.Text = (Decimal.Parse(Me.txtStockActual.Text) + Decimal.Parse(Me.txtAjusteStock.Text)).ToString(_formatoEnPrecio)
         Me.txtAjusteStock.Text = "0.0000"
      End If

   End Sub

   Protected Overrides Function EjecutaInsertar(rg As Reglas.Base, en As Entidades.Entidad) As Entidades.Entidad
      'Return MyBase.EjecutaInsertar(rg, en)
      DirectCast(rg, Reglas.Productos).Insertar(en, IdFuncion)
      Return en
   End Function
   Protected Overrides Function EjecutaActualizar(rg As Reglas.Base, en As Entidades.Entidad) As Entidades.Entidad
      'Return MyBase.EjecutaActualizar(rg, en)
      DirectCast(rg, Reglas.Productos).Actualizar(en, IdFuncion)
      Return en
   End Function
#End Region

#Region "Eventos"

   Private Sub ProductosDetalle_Shown(sender As Object, e As EventArgs) Handles Me.Shown
      Try
         'If Me.StateForm = Win.StateForm.Actualizar Then
         Me.txtNombreProducto.Focus()
         'End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub ProductosDetalle_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
      Select Case e.KeyCode
         Case Keys.F4
            Me.btnAceptar.PerformClick()
         Case Keys.F6
            Me.lblTiempo.Visible = Not Me.lblTiempo.Visible
         Case Keys.F7
            Me.tbcDetalle.SelectedTab = Me.tbpDatos
            Me.bscMarca.Focus()
         Case Keys.F8
            Me.tbcDetalle.SelectedTab = Me.tbpFoto
            Me.btnBuscarImagen.Focus()
         Case Keys.F9
            Me.tbcDetalle.SelectedTab = Me.tbpObservacion
            Me.txtObservacion.Focus()
         Case Keys.F11
            If Reglas.Publicos.TieneModuloProduccion Then
               Me.tbcDetalle.SelectedTab = Me.tbpProduccion
            End If
         Case Keys.F12
            If Reglas.Publicos.TieneModuloExpensas Then
               Me.tbcDetalle.SelectedTab = Me.tbpExpensas
            ElseIf Reglas.Publicos.TieneModuloAlquiler Then
               Me.tbcDetalle.SelectedTab = Me.tbpAlquiler
            End If
         Case Else
      End Select
   End Sub

   Private Sub txtIdProducto_LostFocus(sender As Object, e As EventArgs) Handles txtIdProducto.LostFocus
      Me.txtIdProducto.Text = Me.txtIdProducto.Text.Trim().ToUpper()
      If IsNumeric(Me.txtIdProducto.Text) Then Me.txtCodigoNumerico.Text = Me.txtIdProducto.Text
   End Sub

   Private Sub lnkMarca_LinkClicked(sender As Object, e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles lnkMarca.LinkClicked
      Try
         Dim PantMarca As MarcasDetalle = New MarcasDetalle(New Entidades.Marca())
         PantMarca.StateForm = Win.StateForm.Insertar
         PantMarca.CierraAutomaticamente = True
         If PantMarca.ShowDialog() = Windows.Forms.DialogResult.OK Then
            Me.bscCodigoMarca.Text = PantMarca.IdMarca
            Me.bscCodigoMarca.PresionarBoton()
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub bscCodigoMarca_BuscadorClick() Handles bscCodigoMarca.BuscadorClick
      TryCatched(
         Sub()
            _publicos.PreparaGrillaMarcas2(bscCodigoMarca)
            bscCodigoMarca.Datos = New Reglas.Marcas().GetPorCodigo(bscCodigoMarca.Text.ValorNumericoPorDefecto(0I))
         End Sub)
   End Sub
   Private Sub bscMarca_BuscadorClick() Handles bscMarca.BuscadorClick
      TryCatched(
         Sub()
            _publicos.PreparaGrillaMarcas2(bscMarca)
            bscMarca.Datos = New Reglas.Marcas().GetPorNombre(bscMarca.Text)
         End Sub)
   End Sub
   Private Sub bscCodigoMarca_BuscadorSeleccion(sender As Object, e As Controles.BuscadorEventArgs) Handles bscCodigoMarca.BuscadorSeleccion, bscMarca.BuscadorSeleccion
      TryCatched(Sub() CargarMarca(e.FilaDevuelta))
   End Sub
   Private Sub lnkModelo_LinkClicked(sender As Object, e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles lnkModelo.LinkClicked
      Try
         Dim PantModelo As ModelosDetalle = New ModelosDetalle(New Entidades.Modelo())
         PantModelo.StateForm = Win.StateForm.Insertar
         PantModelo.CierraAutomaticamente = True
         If PantModelo.ShowDialog() = Windows.Forms.DialogResult.OK Then
            Me.bscCodigoMarca.Text = PantModelo.bscCodigoMarca.Text
            Me.bscCodigoMarca.PresionarBoton()
            Me.bscCodigoModelo.Text = PantModelo.txtIdModelo.Text
            Me.bscCodigoModelo.PresionarBoton()
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub bscCodigoModelo_BuscadorClick() Handles bscCodigoModelo.BuscadorClick
      TryCatched(
         Sub()
            _publicos.PreparaGrillaModelos(bscCodigoModelo)
            bscCodigoModelo.Datos = New Reglas.Modelos().GetPorCodigo(bscCodigoMarca.Text.ValorNumericoPorDefecto(0I), bscCodigoModelo.Text.ValorNumericoPorDefecto(0I))
         End Sub)
   End Sub
   Private Sub bscModelo_BuscadorClick() Handles bscModelo.BuscadorClick
      TryCatched(
         Sub()
            _publicos.PreparaGrillaModelos(bscModelo)
            bscModelo.Datos = New Reglas.Modelos().GetPorNombre(bscCodigoMarca.Text.ValorNumericoPorDefecto(0I), bscModelo.Text)
         End Sub)
   End Sub
   Private Sub bscCodigoModelo_BuscadorSeleccion(sender As Object, e As Controles.BuscadorEventArgs) Handles bscCodigoModelo.BuscadorSeleccion, bscModelo.BuscadorSeleccion
      TryCatched(Sub() CargarModelo(e.FilaDevuelta))
   End Sub
   Private Sub lnkRubro_LinkClicked(sender As Object, e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles lnkRubro.LinkClicked
      Try
         Dim PantRubro As RubrosDetalle = New RubrosDetalle(New Entidades.Rubro())
         PantRubro.StateForm = Win.StateForm.Insertar
         PantRubro.CierraAutomaticamente = True
         If PantRubro.ShowDialog() = Windows.Forms.DialogResult.OK Then
            Me.bscCodigoRubro.Text = PantRubro.IdRubro
            Me.bscCodigoRubro.PresionarBoton()
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub bscCodigoRubro_BuscadorClick() Handles bscCodigoRubro.BuscadorClick
      TryCatched(
         Sub()
            _publicos.PreparaGrillaRubros2(bscCodigoRubro)
            bscCodigoRubro.Datos = New Reglas.Rubros().GetPorCodigo(bscCodigoRubro.Text.ValorNumericoPorDefecto(0I))
         End Sub)
   End Sub
   Private Sub bscRubro_BuscadorClick() Handles bscRubro.BuscadorClick
      TryCatched(
         Sub()
            Me._publicos.PreparaGrillaRubros2(bscRubro)
            Me.bscRubro.Datos = New Reglas.Rubros().GetPorNombre(bscRubro.Text)
         End Sub)
   End Sub
   Private Sub bscCodigoRubro_BuscadorSeleccion(sender As Object, e As Controles.BuscadorEventArgs) Handles bscCodigoRubro.BuscadorSeleccion, bscRubro.BuscadorSeleccion
      TryCatched(Sub() CargarRubro(e.FilaDevuelta))
   End Sub
   Private Sub lnkSubRubro_LinkClicked(sender As Object, e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles lnkSubRubro.LinkClicked
      Try
         Dim idRubro As Integer = 0
         If IsNumeric(bscCodigoRubro.Text) Then idRubro = Integer.Parse(bscCodigoRubro.Text)
         Dim PantSubRubro As SubRubrosDetalle = New SubRubrosDetalle(idRubro, New Entidades.SubRubro())
         PantSubRubro.StateForm = Win.StateForm.Insertar
         PantSubRubro.CierraAutomaticamente = True
         If PantSubRubro.ShowDialog() = Windows.Forms.DialogResult.OK Then
            Me.bscCodigoSubRubro.Text = PantSubRubro.txtIdSubRubro.Text
            Me.bscCodigoSubRubro.PresionarBoton()
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub bscCodigoSubRubro_BuscadorClick() Handles bscCodigoSubRubro.BuscadorClick
      TryCatched(
         Sub()
            _publicos.PreparaGrillaSubRubros2(bscCodigoSubRubro)
            bscCodigoSubRubro.Datos = New Reglas.SubRubros().GetPorCodigo(bscCodigoRubro.Text.ValorNumericoPorDefecto(0I), bscCodigoSubRubro.Text.ValorNumericoPorDefecto(0I))
         End Sub)
   End Sub
   Private Sub bscSubRubro_BuscadorClick() Handles bscSubRubro.BuscadorClick
      TryCatched(
         Sub()
            _publicos.PreparaGrillaSubRubros2(bscSubRubro)
            bscSubRubro.Datos = New Reglas.SubRubros().GetPorNombre(bscCodigoRubro.Text.ValorNumericoPorDefecto(0I), bscSubRubro.Text)
         End Sub)
   End Sub
   Private Sub BuscadorSubRubro_BuscadorSeleccion(sender As Object, e As Controles.BuscadorEventArgs) Handles bscCodigoSubRubro.BuscadorSeleccion, bscSubRubro.BuscadorSeleccion
      TryCatched(Sub() CargarSubRubro(e.FilaDevuelta))
   End Sub

   Private Sub chbLote_CheckedChanged(sender As Object, e As EventArgs) Handles chbLote.CheckedChanged

      Dim oProdSuc As Reglas.ProductosSucursales = New Reglas.ProductosSucursales()
      Dim ProdSuc As Entidades.ProductoSucursal


      ProdSuc = oProdSuc.GetUno(actual.Sucursal.Id, Me.txtIdProducto.Text)

      Dim dtDetalle As DataTable = oProdSuc.GetProductoConStock(Me.txtIdProducto.Text, 0)

      For Each dr As DataRow In dtDetalle.Rows
         'Si tiene Stock Negativo lo voy a bloquear al grabar.
         If Decimal.Parse(dr("Stock").ToString()) > 0 And Me.chbLote.Checked And Not ProdSuc.Producto.Lote Then
            If MessageBox.Show("Al Activar la Propiedad de Lotes de un Producto con Stock se generaran Automaticamente., ¿ Acepta ?", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) <> Windows.Forms.DialogResult.Yes Then
               Me.chbLote.Checked = False
            End If
            Exit Sub
         End If
      Next

      btnAjustarStock.Enabled = False
      txtAjusteStock.Text = "0.000"
      txtAjusteStock.Enabled = False
   End Sub

   Private Sub btnLimpiarTamaño_Click(sender As Object, e As EventArgs) Handles btnLimpiarTamaño.Click
      'Limpia primeto el tamaño para que el calulo de kilos no de error.
      If cmbUnidadDeMedida.Enabled Then
         cmbUnidadDeMedida.SelectedIndex = -1
         DirectCast(_entidad, Entidades.Producto).UnidadDeMedida = Nothing
         txtUM2.Text = ""
         chbSolicitaPrecioVentaPorTamano.Text = String.Format(_lblSolicitaPrecioVentaPorTamanoDefault, txtUM2.Text)
         txtTamanio.Text = ""
         txtTamaño2.Text = ""
         DirectCast(_entidad, Entidades.Producto).Tamano = Nothing
         txtKilos.Text = "0.00"
      End If
   End Sub

   Private Sub txtTamanio_GotFocus(sender As Object, e As EventArgs) Handles txtTamanio.GotFocus
      Me.txtTamanio.SelectAll()
   End Sub

   Private Sub btnCopiarCodigoProducto_Click(sender As Object, e As EventArgs) Handles btnCopiarCodigoProducto.Click
      'If IsNumeric(Me.txtIdProducto.Text) Then
      '   Me.txtCodigoDeBarras.Text = Me.txtIdProducto.Text
      'End If
      If rbtEAN8.Checked Then
         Me.txtCodigoDeBarras.Text = Me.ConvertirEAN8(Me.txtCodigoBarrasAGenerar.Text)
      Else
         Me.txtCodigoDeBarras.Text = Me.ConvertirEAN13(Me.txtCodigoBarrasAGenerar.Text)
      End If

   End Sub

   Private Sub btnLimpiarImagen_Click(sender As Object, e As EventArgs) Handles btnLimpiarImagen.Click
      Try
         DirectCast(Me._entidad, Entidades.Producto).Foto = Nothing
         Me.pcbFoto.Image = Nothing
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub btnBuscarImagen_Click(sender As Object, e As EventArgs) Handles btnBuscarImagen.Click
      Try
         If Me.ofdArchivos.ShowDialog() = Windows.Forms.DialogResult.OK Then
            If Not String.IsNullOrEmpty(Me.ofdArchivos.FileName) Then
               If System.IO.File.ReadAllBytes(Me.ofdArchivos.FileName).Length > Reglas.Publicos.TamañoMaximoImagenes Then
                  MessageBox.Show("El tamaño de la imagen no puede ser mayor a " + (Reglas.Publicos.TamañoMaximoImagenes / 1000).ToString() + "KB", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
                  Exit Sub
               End If
               Me.pcbFoto.Image = New System.Drawing.Bitmap(Me.ofdArchivos.FileName)
               DirectCast(Me._entidad, Entidades.Producto).Foto = Me.pcbFoto.Image
            End If
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub chbActivo_CheckedChanged(sender As Object, e As EventArgs) Handles chbActivo.CheckedChanged, chbIncluirExpensas.CheckedChanged
      If chbActivo.Checked = False Then
         Dim oProdComp As Reglas.ProductosComponentes = New Reglas.ProductosComponentes()
         Dim idListaDePrecios As Integer = 0    'Lista Base
         Me._productosComp = oProdComp.GetPorProductoComponente(actual.Sucursal.IdSucursal, Me.txtIdProducto.Text, idListaDePrecios)
         If Me._productosComp.Rows.Count > 0 Then
            Dim DetalleProductos As String = "("
            For Each dr As DataRow In Me._productosComp.Rows
               DetalleProductos &= dr("IdProducto").ToString() & ", "
            Next
            DetalleProductos = DetalleProductos.Substring(0, DetalleProductos.Length - 2) & ")"
            Me.chbActivo.Checked = True
            MessageBox.Show("El Producto es Componente de " & DetalleProductos & ", NO es Posible Inactivarlo.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
         Else
            Exit Sub
         End If
      End If
   End Sub

   'Private Sub chbEsServicio_CheckedChanged(sender As Object, e As EventArgs) Handles chbEsServicio.CheckedChanged
   '   Dim producto As String
   '   producto = Me.txtIdProducto.Text
   '   Dim sucursal As Integer
   '   sucursal = actual.Sucursal.IdSucursal

   '   If chbEsServicio.Checked = True Then
   '      Dim oprodcomp As Reglas.ProductosComponentes = New Reglas.ProductosComponentes()
   '      Me._productosComp = oprodcomp.GetProdComponentes(sucursal, producto)
   '      If Me._productosComp.Rows.Count > 0 Then
   '         Me.chbEsServicio.Checked = False
   '         MessageBox.Show("El producto es componente de otro producto, no es posible definir como servicio", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
   '      Else
   '         Exit Sub
   '      End If
   '   End If
   'End Sub

   'Private Sub chbAfectaStock_CheckedChanged(sender As Object, e As EventArgs) Handles chbAfectaStock.CheckedChanged
   '   Dim producto As String
   '   producto = Me.txtIdProducto.Text
   '   Dim sucursal As Integer
   '   sucursal = actual.Sucursal.IdSucursal

   '   If chbAfectaStock.Checked = False Then
   '      Dim oprodcomp As Reglas.ProductosComponentes = New Reglas.ProductosComponentes()
   '      Me._productosComp = oprodcomp.GetProdComponentes(sucursal, producto)
   '      If Me._productosComp.Rows.Count > 0 Then
   '         Me.chbAfectaStock.Checked = True
   '         MessageBox.Show("El producto es componente de otro producto, debe afectar stock", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
   '      Else
   '         Exit Sub
   '      End If
   '   End If
   'End Sub

   Private Sub chbEsAlquilable_CheckedChanged(sender As Object, e As EventArgs) Handles chbEsAlquilable.CheckedChanged
      Me.txtEquipoModelo.IsRequired = Me.chbEsAlquilable.Checked
      Me.txtNumeroSerie.IsRequired = Me.chbEsAlquilable.Checked
      Me.txtEquipoMarca.IsRequired = Me.chbEsAlquilable.Checked
      Me.txtAnio.IsRequired = Me.chbEsAlquilable.Checked
   End Sub

   Private Sub btnAceptar_Click(sender As Object, e As EventArgs) Handles btnAceptar.Click

      'Pasa por aca si luego del aceptar

      If Me.StateForm = Eniac.Win.StateForm.Insertar And Not Me.HayError And Not Me.CierraAutomaticamente Then

         Me.cmbTipoImpuesto.SelectedValue = New Reglas.Impuestos().GetUno("IVA", Publicos.ProductoIVA).Alicuota
         DirectCast(Me._entidad, Entidades.Producto).Alicuota = Decimal.Parse(Me.cmbTipoImpuesto.Text)

         Me.bscCodigoMarca.Text = ""
         Me.bscMarca.Text = String.Empty

         Me.bscCodigoModelo.Text = ""
         Me.bscModelo.Text = String.Empty

         Me.bscCodigoRubro.Text = ""
         Me.bscRubro.Text = String.Empty

         Me.bscCodigoSubRubro.Text = ""
         Me.bscSubRubro.Text = String.Empty

         Me.txtTamanio.Text = ""
         Me.cmbUnidadDeMedida.SelectedIndex = -1

         Me.chbActivo.Checked = True
         Me.chbAfectaStock.Checked = True

         Me.CargarProximoNumero()

      End If

      Me.txtIdProducto.Focus()

   End Sub

   Private Sub cmbUnidadDeMedida_SelectedValueChanged(sender As Object, e As EventArgs) Handles cmbUnidadDeMedida.SelectedValueChanged, cmbOrigenPorcImpInt.SelectedValueChanged, cmbUnidadDeMedidaProduccion.SelectedValueChanged, cmbUnidadDeMedidaCompra.SelectedValueChanged
      TryCatched(
      Sub()
         txtUM2.Text = cmbUnidadDeMedida.Text
         chbSolicitaPrecioVentaPorTamano.Text = String.Format(_lblSolicitaPrecioVentaPorTamanoDefault, txtUM2.Text)
         CalcularKilos()
         CambiaUnidadMedidaCompra()
         CambiaUnidadMedidaProduccion()
      End Sub)
   End Sub
   Private Sub cmbUnidadDeMedidaCompra_SelectedValueChanged(sender As Object, e As EventArgs) Handles cmbUnidadDeMedidaCompra.SelectedValueChanged
      TryCatched(Sub() CambiaUnidadMedidaCompra())
   End Sub
   Private Sub cmbUnidadDeMedidaProduccion_SelectedValueChanged(sender As Object, e As EventArgs) Handles cmbUnidadDeMedidaProduccion.SelectedValueChanged
      TryCatched(Sub() CambiaUnidadMedidaProduccion())
   End Sub

   Private Sub CambiaUnidadMedidaCompra()
      Dim ums = cmbUnidadDeMedida.ValorSeleccionado(String.Empty)
      Dim umc = cmbUnidadDeMedidaCompra.ValorSeleccionado(String.Empty)
      CambiaUnidadMedida(ums, umc, txtFactorConversionCompra)
   End Sub
   Private Sub CambiaUnidadMedidaProduccion()
      Dim ums = cmbUnidadDeMedida.ValorSeleccionado(String.Empty)
      Dim ump = cmbUnidadDeMedidaProduccion.ValorSeleccionado(String.Empty)
      CambiaUnidadMedida(ums, ump, txtFactorConversionProduccion)
   End Sub
   Private Sub CambiaUnidadMedida(ums As String, ump As String, txtFactorConversion As Controles.TextBox)
      If ums IsNot Nothing AndAlso ump IsNot Nothing Then
         txtFactorConversion.ReadOnly = False
         If ump = ums Then
            txtFactorConversion.SetValor(1D)
            txtFactorConversion.ReadOnly = True
         Else
            Dim rUMConv = New Reglas.UnidadesDeMedidasConversiones()
            Dim umConv = rUMConv.GetFactorConversion(ums, ump)
            If umConv IsNot Nothing Then
               txtFactorConversion.ReadOnly = umConv.Fija
               If Not _estaCargando Then
                  txtFactorConversion.SetValor(umConv.FactorConversion)
               End If
            End If
         End If
      End If
   End Sub

   Private Sub txtEmbalaje_LostFocus(sender As Object, e As EventArgs) Handles txtEmbalaje.LostFocus
      Me.CalcularKilos()
   End Sub

   Private Sub chbEsCompuesto_CheckedChanged(sender As Object, e As EventArgs) Handles chbEsCompuesto.CheckedChanged
      Try
         If chbEsCompuesto.Checked Then
            Me.cmbFormulas.Enabled = True
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub chbAfectaStock_CheckedChanged(sender As Object, e As EventArgs) Handles chbAfectaStock.CheckedChanged
      If Not Me.chbAfectaStock.Checked Then
         Me.txtEmbalaje.Text = "0"
      End If
   End Sub

   Private Sub txtNombreProducto_LostFocus(sender As Object, e As EventArgs) Handles txtNombreProducto.LostFocus
      'Lo asigna solo si cambio
      If Publicos.ProductoUtilizaNombreCorto And (Me.txtNombreProducto.Text <> Me._NombreProductoOriginal Or String.IsNullOrEmpty(Me.txtNombreCorto.Text)) Then
         Me.txtNombreCorto.Text = Strings.Left(Me.txtNombreProducto.Text, 30)
      End If
   End Sub

   Private Sub btnCopiarNombreProducto_Click(sender As Object, e As EventArgs) Handles btnCopiarNombreProducto.Click
      If Not String.IsNullOrEmpty(Me.txtNombreProducto.Text) Then
         Me.txtNombreCorto.Text = Strings.Left(Me.txtNombreProducto.Text, 30)
      End If
   End Sub

   '-- REQ-31619.- --
   Private Sub btnCopiarNombreProductoWeb_Click(sender As Object, e As EventArgs) Handles btnCopiarNombreProductoWeb.Click
      If Not String.IsNullOrEmpty(Me.txtNombreProducto.Text) Then
         Me.txtNombreWeb.Text = Strings.Left(Me.txtNombreProducto.Text, 60)
      End If
   End Sub


   'De un momento a otro dejo de asignar el valor, ademas el LimpiarControles (luego del aceptar) lo daba por error cuando el selecindex era -1
   Private Sub cmbMoneda_SelectedValueChanged(sender As Object, e As EventArgs) Handles cmbMoneda.SelectedValueChanged
      If Me._estaCargando Then Exit Sub
      If Me.cmbMoneda.SelectedIndex >= 0 Then
         DirectCast(Me._entidad, Entidades.Producto).Moneda = New Reglas.Monedas().GetUna(Integer.Parse(Me.cmbMoneda.SelectedValue.ToString()))
      Else
         DirectCast(Me._entidad, Entidades.Producto).Moneda = Nothing
      End If
   End Sub

   Private Sub bscCodigoConcepto_BuscadorClick() Handles bscCodigoConcepto.BuscadorClick
      Try

         Dim concepto As Integer = -1

         Dim oConceptos As Reglas.Conceptos = New Reglas.Conceptos
         Me._publicos.PreparaGrillaConceptos(Me.bscCodigoConcepto)

         If Me.bscCodigoConcepto.Text.Trim.Length > 0 Then
            concepto = Integer.Parse(Me.bscCodigoConcepto.Text.ToString())
         End If

         Me.bscCodigoConcepto.Datos = oConceptos.GetPorCodigo(concepto)
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub bscCodigoConcepto_BuscadorSeleccion(sender As Object, e As Controles.BuscadorEventArgs) Handles bscCodigoConcepto.BuscadorSeleccion
      Try
         If Not e.FilaDevuelta Is Nothing Then
            Me.CargarConcepto(e.FilaDevuelta)
            Me.btnInsertarConcepto.Focus()
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub bscConcepto_BuscadorClick() Handles bscConcepto.BuscadorClick
      Try
         Dim oProductos As Reglas.Conceptos = New Reglas.Conceptos
         Me._publicos.PreparaGrillaConceptos(Me.bscConcepto)
         Me.bscConcepto.Datos = oProductos.GetPorNombre(Me.bscConcepto.Text.Trim())
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub bscConcepto_BuscadorSeleccion(sender As Object, e As Controles.BuscadorEventArgs) Handles bscConcepto.BuscadorSeleccion
      Try
         If Not e.FilaDevuelta Is Nothing Then
            Me.CargarConcepto(e.FilaDevuelta)
            Me.btnInsertarConcepto.Focus()
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub btnInsertar_Click(sender As Object, e As EventArgs) Handles btnInsertarConcepto.Click
      Try
         If (Not Me.bscCodigoConcepto.FilaDevuelta Is Nothing Or Not Me.bscConcepto.FilaDevuelta Is Nothing) Then
            If Me.ExisteConcepto(Integer.Parse(Me.bscCodigoConcepto.Text.ToString())) Then
               MessageBox.Show("Ya existe el Concepto.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
               Me.AgregarMarca()

            End If
            Me.bscCodigoConcepto.Text = ""
            Me.bscConcepto.Text = ""
            Me.bscCodigoConcepto.Enabled = True
            Me.bscConcepto.Enabled = True
            Me.bscCodigoConcepto.Focus()
         End If

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub btnEliminarConcepto_Click(sender As Object, e As EventArgs) Handles btnEliminarConcepto.Click
      Try
         If Me.dgvDetalleConceptos.SelectedRows.Count > 0 Then
            If MessageBox.Show("Esta Seguro de Eliminar el Concepto Seleccionado?", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
               Me.EliminarLineaDescuento()
            End If
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub rbtEAN8_CheckedChanged(sender As Object, e As EventArgs) Handles rbtEAN8.CheckedChanged
      Me.txtCodigoBarrasAGenerar.MaxLength = 7
   End Sub

   Private Sub rbtEAN13_CheckedChanged(sender As Object, e As EventArgs) Handles rbtEAN13.CheckedChanged
      Me.txtCodigoBarrasAGenerar.MaxLength = 12
   End Sub

   Private Sub btnGenerarCodigo_Click(sender As Object, e As EventArgs) Handles btnGenerarCodigo.Click
      Try
         Me.txtIdProducto.Text = Me._reglasProductos.GetProximoCodigo(Me.txtIdProducto.Text)
         If IsNumeric(Me.txtIdProducto.Text) Then Me.txtCodigoNumerico.Text = Me.txtIdProducto.Text
      Catch ex As Exception
         ShowError(ex)
      End Try
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

   Private Sub txtPrecioLista_Leave(sender As Object, e As EventArgs) Handles txtPrecioLista.Leave, txtDescuento4.Leave, txtDescuento3.Leave, txtDescuento2.Leave, txtDescuento1.Leave
      ''MuestraPrecioCosto()
   End Sub

   Private Sub dgvListasPrecios_CellChange(sender As Object, e As CellEventArgs) Handles dgvListasPrecios.CellChange
      If e.Cell.Column.DataType.Equals(GetType(Boolean)) AndAlso
         e.Cell.Row.ListObject IsNot Nothing AndAlso
         TypeOf (e.Cell.Row.ListObject) Is DataRowView AndAlso
         DirectCast(e.Cell.Row.ListObject, DataRowView).Row IsNot Nothing Then

         Dim dr As DataRow = DirectCast(e.Cell.Row.ListObject, DataRowView).Row

         If e.Cell.Column.Key <> ListaPreciosColumns.PorcActual.ToString() Then
            dr(ListaPreciosColumns.PorcActual.ToString()) = False
         End If

         If e.Cell.Column.Key <> ListaPreciosColumns.SobreVenta.ToString() Then
            dr(ListaPreciosColumns.SobreVenta.ToString()) = False
         End If

         If e.Cell.Column.Key <> ListaPreciosColumns.SobreCosto.ToString() Then
            dr(ListaPreciosColumns.SobreCosto.ToString()) = False
         End If

         If e.Cell.Column.Key <> ListaPreciosColumns.DesdeFormula.ToString() Then
            dr(ListaPreciosColumns.DesdeFormula.ToString()) = False
         End If

         If e.Cell.Column.Key = ListaPreciosColumns.PorcActual.ToString() Then
            dr(ListaPreciosColumns.PorcentajeCalculado.ToString()) = dr(ListaPreciosColumns.PorcentajeCosto.ToString())
         Else
            dr(ListaPreciosColumns.PorcentajeCalculado.ToString()) = dr(ListaPreciosColumns.PorcentajeBase.ToString())
         End If

         Dim lp As Entidades.ListaDePrecios = New Reglas.ListasDePrecios().GetUno(Integer.Parse(dr(ListaPreciosColumns.IdListaPrecios.ToString()).ToString()))

         If e.Cell.Column.Key = ListaPreciosColumns.SobreCosto.ToString() Then
            dr(ListaPreciosColumns.PorcentajeCalculado.ToString()) = lp.DescuentoRecargoPorc
         End If

         dgvListasPrecios.PerformAction(UltraGridAction.ExitEditMode)
         dgvListasPrecios.UpdateData()

      End If

   End Sub

   Private Sub dgvListasPrecios_InitializeRow(sender As Object, e As InitializeRowEventArgs) Handles dgvListasPrecios.InitializeRow
      If CBool(e.Row.Cells(ListaPreciosColumns.PorcActual.ToString()).Value) Then
         e.Row.Cells(ListaPreciosColumns.PorcActual.ToString()).Activation = Activation.NoEdit
         e.Row.Cells(ListaPreciosColumns.PorcentajeCalculado.ToString()).Activation = Activation.NoEdit
      Else
         e.Row.Cells(ListaPreciosColumns.PorcActual.ToString()).Activation = Activation.AllowEdit
         e.Row.Cells(ListaPreciosColumns.PorcentajeCalculado.ToString()).Activation = Activation.AllowEdit
      End If
      If CBool(e.Row.Cells(ListaPreciosColumns.SobreVenta.ToString()).Value) Then
         e.Row.Cells(ListaPreciosColumns.SobreVenta.ToString()).Activation = Activation.NoEdit
      Else
         e.Row.Cells(ListaPreciosColumns.SobreVenta.ToString()).Activation = Activation.AllowEdit
      End If
      If CBool(e.Row.Cells(ListaPreciosColumns.SobreCosto.ToString()).Value) Then
         e.Row.Cells(ListaPreciosColumns.SobreCosto.ToString()).Activation = Activation.NoEdit
      Else
         e.Row.Cells(ListaPreciosColumns.SobreCosto.ToString()).Activation = Activation.AllowEdit
      End If
      If CBool(e.Row.Cells(ListaPreciosColumns.DesdeFormula.ToString()).Value) Then
         e.Row.Cells(ListaPreciosColumns.DesdeFormula.ToString()).Activation = Activation.NoEdit
      Else
         e.Row.Cells(ListaPreciosColumns.DesdeFormula.ToString()).Activation = Activation.AllowEdit
      End If
   End Sub

   Private Sub btnCalcular_Click(sender As Object, e As EventArgs) Handles btnCalcular.Click
      Try
         If ValidarRecalculaPrecios() Then
            Me.RecalculaPrecios()
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
      End Try
   End Sub

   Private Sub chbCodigoDeBarrasConPrecio_CheckedChanged(sender As Object, e As EventArgs) Handles chbCodigoDeBarrasConPrecio.CheckedChanged
      cmbModalidadCodigoDeBarras.Enabled = chbCodigoDeBarrasConPrecio.Checked
   End Sub

   Private Sub btnCalcularCosto_Click(sender As Object, e As EventArgs) Handles btnCalcularCosto.Click
      Try
         MuestraPrecioCosto()
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub btnLimpiarConcepto_Click(sender As Object, e As EventArgs) Handles btnLimpiarConcepto.Click
      Me.bscCodigoConcepto.Enabled = True
      Me.bscConcepto.Enabled = True
      Me.bscCodigoConcepto.Text = ""
      Me.bscConcepto.Text = ""
      Me.bscCodigoConcepto.Focus()
   End Sub

   Private Sub txtTamanio_Leave(sender As Object, e As EventArgs) Handles txtTamanio.Leave
      Try
         Me.txtTamaño2.Text = Me.txtTamanio.Text
         Me.CalcularKilos()
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub chbProduccionProceso_CheckedChanged(sender As Object, e As EventArgs) Handles chbProduccionProceso.CheckedChanged
      Try
         If chbProduccionProceso.Checked Then
            cmbProduccionProceso.Enabled = True
            cmbProduccionProceso.Focus()
         Else
            cmbProduccionProceso.Enabled = False
            cmbProduccionProceso.SelectedIndex = -1
         End If
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

   Private Sub chbProduccionForma_CheckedChanged(sender As Object, e As EventArgs) Handles chbProduccionForma.CheckedChanged
      Try
         If chbProduccionForma.Checked Then
            cmbProduccionForma.Enabled = True
            cmbProduccionForma.Focus()
         Else
            cmbProduccionForma.Enabled = False
            cmbProduccionForma.SelectedIndex = -1
         End If
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

   Private Sub lblProduccionProceso_Click(sender As Object, e As EventArgs) Handles lblProduccionProceso.Click
      chbProduccionProceso.Checked = Not chbProduccionProceso.Checked
   End Sub

   Private Sub lblProduccionForma_Click(sender As Object, e As EventArgs) Handles lblProduccionForma.Click
      chbProduccionForma.Checked = Not chbProduccionForma.Checked
   End Sub

   Private Sub lnkSubSubRubro_LinkClicked(sender As Object, e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles lnkSubSubRubro.LinkClicked
      Try
         Dim idSubRubro As Integer = 0
         If IsNumeric(bscCodigoSubRubro.Text) Then idSubRubro = Integer.Parse(bscCodigoSubRubro.Text)
         Dim PantSubSubRubro As SubSubRubrosDetalle = New SubSubRubrosDetalle(idSubRubro, New Entidades.SubSubRubro())
         PantSubSubRubro.StateForm = Win.StateForm.Insertar
         PantSubSubRubro.CierraAutomaticamente = True
         If PantSubSubRubro.ShowDialog() = Windows.Forms.DialogResult.OK Then
            Me.bscCodigoSubSubRubro.Text = PantSubSubRubro.txtIdSubSubRubro.Text
            Me.bscCodigoSubSubRubro.PresionarBoton()
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub bscCodigoSubSubRubro_BuscadorClick() Handles bscCodigoSubSubRubro.BuscadorClick
      TryCatched(
         Sub()
            _publicos.PreparaGrillaSubSubRubros2(bscCodigoSubSubRubro)
            bscCodigoSubSubRubro.Datos = New Reglas.SubSubRubros().GetPorCodigo(bscCodigoRubro.Text.ValorNumericoPorDefecto(0I),
                                                                                bscCodigoSubRubro.Text.ValorNumericoPorDefecto(0I),
                                                                                bscCodigoSubSubRubro.Text.ValorNumericoPorDefecto(0I))
         End Sub)
   End Sub
   Private Sub bscSubSubRubro_BuscadorClick() Handles bscSubSubRubro.BuscadorClick
      TryCatched(
         Sub()
            _publicos.PreparaGrillaSubSubRubros2(bscSubSubRubro)
            bscSubSubRubro.Datos = New Reglas.SubSubRubros().GetPorNombre(bscCodigoRubro.Text.ValorNumericoPorDefecto(0I),
                                                                          bscCodigoSubRubro.Text.ValorNumericoPorDefecto(0I),
                                                                          bscSubSubRubro.Text.Trim())
         End Sub)
   End Sub
   Private Sub bscCodigoSubSubRubro_BuscadorSeleccion(sender As Object, e As Controles.BuscadorEventArgs) Handles bscCodigoSubSubRubro.BuscadorSeleccion, bscSubSubRubro.BuscadorSeleccion
      TryCatched(Sub() CargarSubSubRubro(e.FilaDevuelta))
   End Sub

#Region "Buscador Centro de Costos"
   Private Sub bscCodigoCentroCosto_BuscadorClick() Handles bscCodigoCentroCosto.BuscadorClick
      Try
         Me._publicos.PreparaGrillaCentroCosto(Me.bscCodigoCentroCosto)
         If Not IsNumeric(bscCodigoCentroCosto.Text) Then bscCodigoCentroCosto.Text = "0"
         Me.bscCodigoCentroCosto.Datos = New Reglas.ContabilidadCentrosCostos().GetPorCodigo(Integer.Parse(Me.bscCodigoCentroCosto.Text))
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

   Private Sub bscNombreCentroCosto_BuscadorClick() Handles bscNombreCentroCosto.BuscadorClick
      Try
         Me._publicos.PreparaGrillaCentroCosto(Me.bscNombreCentroCosto)
         Me.bscNombreCentroCosto.Datos = New Reglas.ContabilidadCentrosCostos().GetPorNombre(Me.bscNombreCentroCosto.Text)
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

   Private Sub bscCentroCosto_BuscadorSeleccion(sender As Object, e As Controles.BuscadorEventArgs) Handles bscCodigoCentroCosto.BuscadorSeleccion, bscNombreCentroCosto.BuscadorSeleccion
      Try
         If Not e.FilaDevuelta Is Nothing Then
            bscCodigoCentroCosto.Text = e.FilaDevuelta.Cells(Entidades.ContabilidadCentroCosto.Columnas.IdCentroCosto.ToString()).Value.ToString()
            bscNombreCentroCosto.Text = e.FilaDevuelta.Cells(Entidades.ContabilidadCentroCosto.Columnas.NombreCentroCosto.ToString()).Value.ToString()
         End If
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub
#End Region

#End Region

#Region "Metodos"

   Private Sub ActivarBonificaciones(esDescuento As Boolean)

      '# Descuento
      Me.txtUHPorc1.Enabled = esDescuento
      Me.txtUHPorc2.Enabled = esDescuento
      Me.txtUHPorc3.Enabled = esDescuento
      Me.txtUHPorc4.Enabled = esDescuento
      Me.txtUHPorc5.Enabled = esDescuento

      '# Lista de Precio
      Me.cmbBonificacionListaDePrecios1.Enabled = Not esDescuento
      Me.cmbBonificacionListaDePrecios2.Enabled = Not esDescuento
      Me.cmbBonificacionListaDePrecios3.Enabled = Not esDescuento
      Me.cmbBonificacionListaDePrecios4.Enabled = Not esDescuento
      Me.cmbBonificacionListaDePrecios5.Enabled = Not esDescuento

   End Sub

   Private Sub ValidarLotesNroSerie()

      Dim rPS As Reglas.ProductosSucursales = New Reglas.ProductosSucursales
      Dim dtDetalle As DataTable = rPS.GetProductoConStock(Me.txtIdProducto.Text, 0)
      Dim ProdSuc As Entidades.ProductoSucursal = rPS.GetUno(actual.Sucursal.Id, Me.txtIdProducto.Text)

      Dim algunStock As Boolean = False
      Dim stbMensajeStock = New StringBuilder("Existe stock en las siguientes sucursales.").AppendLine().AppendLine()

      Dim TieneAtributos As DataRow = Nothing
      Dim atrMensajeStock = New StringBuilder("¡No es posible modificar el SubRubro! El mismo contiene movimientos de Stock").AppendLine().AppendLine()
      atrMensajeStock.AppendLine("Existe stock en las siguientes sucursales.")

      For Each dr As DataRow In dtDetalle.Rows
         Dim idSucursal = dr.Field(Of Integer)("IdSucursal")
         Dim nombreSucursal = dr.Field(Of String)("NombreSucursal")
         Dim stock = dr.Field(Of Decimal)("Stock")

         If stock <> 0 Then
            stbMensajeStock.AppendFormatLine("  - {0}: {1:N2}", nombreSucursal, stock)
            Dim idSubRubro = dr.Field(Of Integer?)("IdSubRubro")
            If idSubRubro.HasValue Then
               '-- REQ-35484.- -------------------------------------------------------------
               Dim dtTieneAtributos = New Reglas.SubRubros().TieneAtributoSubRubro(idSubRubro.Value)
               If dtTieneAtributos.Count > 0 Then
                  TieneAtributos = dtTieneAtributos.Rows(0)
                  If TieneAtributos.Field(Of Integer)("AtributoSubRubro") > 0 Then
                     atrMensajeStock.AppendFormatLine("  - {0}: {1:N2}", nombreSucursal, stock)
                  End If
               End If
               '----------------------------------------------------------------------------
            End If
            algunStock = True
         End If
      Next

      If algunStock Then
         stbMensajeStock.AppendLine()
         atrMensajeStock.AppendLine()

         stbMensajeStock.AppendLine("NO Puede activar/desactivar la Propiedad de Lotes o Nro Serie a un Producto con Stock, primero debe llevarlo a Cero.")
         atrMensajeStock.AppendLine("NO Puede modificar la Propiedad de Rubro y SubRubro(con atributo) a un Producto con Stock, primero debe llevarlo a Cero.")

         chbLote.Enabled = False
         chbNroSerie.Enabled = False
         ErrorProvider1.SetError(chbLote, stbMensajeStock.ToString())
         ErrorProvider1.SetError(chbNroSerie, stbMensajeStock.ToString())

         '-- Etiqueta de Mensaje.- --------------------------------------------------------
         If TieneAtributos IsNot Nothing AndAlso TieneAtributos.Field(Of Integer)("AtributoSubRubro") > 0 Then
            ErrorProvider1.SetError(bscSubRubro, atrMensajeStock.ToString())
            ErrorProvider1.SetError(bscRubro, "¡No es posible modificar el Rubro! El SubRubro Asociado posee Atributos.")
         End If

      End If

   End Sub

   Private Sub HabilitaCodigoNumerico()
      txtCodigoNumerico.ReadOnly = Not Reglas.Publicos.HabilitaCodigoNumericoProducto
   End Sub

   Public Sub SetEntidad(enti As Entidades.Producto)
      _entidad = Nothing
      _entidad = enti
   End Sub

   Public Sub SetCreaEntidadNueva()
      _entidad = New Entidades.Producto()
   End Sub

   Private Sub CargaValoresIniciales()
      _reglasProductos = New Reglas.Productos()
      _productoUtilizaAlicuota2 = Reglas.Publicos.ProductoUtilizaAlicuota2    'TODO: ¿Quitarmos parametro?
      _tieneModuloContabilidad = Reglas.Publicos.TieneModuloContabilidad
      _titProductoProveedor = New Dictionary(Of String, String)()
      _EmbalajeNormal = Not Publicos.ProductoEmbalajeHaciaArriba
      _NombreProductoOriginal = String.Empty
      _estaCargando = True
      _conceptos = New List(Of Entidades.ProductoConcepto)()
      _productoUtilizaCodigoLargo = Reglas.Publicos.ProductoUtilizaCodigoLargo
      _utilizaPrecioDeCompra = Reglas.Publicos.UtilizaPrecioDeCompra
   End Sub

   Private Sub CargarProximoNumero()
      txtIdProducto.Text = (_reglasProductos.GetCodigoMaximo() + 1).ToString("####0")
      txtCodigoNumerico.Text = txtIdProducto.Text
   End Sub

   Private Sub CargarMarca(dr As DataGridViewRow)
      If dr IsNot Nothing Then
         DirectCast(_entidad, Entidades.Producto).IdMarca = Integer.Parse(dr.Cells("IdMarca").Value.ToString())
         bscCodigoMarca.Text = dr.Cells("IdMarca").Value.ToString()
         bscMarca.Text = dr.Cells("NombreMarca").Value.ToString()

         bscCodigoModelo.Text = String.Empty
         bscModelo.Text = String.Empty

         If bscCodigoModelo.Visible Then
            bscCodigoModelo.Focus()
         Else
            bscCodigoRubro.Focus()
         End If
      End If

   End Sub

   Private Sub CargarModelo(dr As DataGridViewRow)
      If dr IsNot Nothing Then
         DirectCast(_entidad, Entidades.Producto).IdModelo = Integer.Parse(dr.Cells("IdModelo").Value.ToString())
         bscCodigoModelo.Text = dr.Cells("IdModelo").Value.ToString()
         bscModelo.Text = dr.Cells("NombreModelo").Value.ToString()

         If bscCodigoMarca.Text.ValorNumericoPorDefecto(0I) = 0 Then
            DirectCast(_entidad, Entidades.Producto).IdMarca = Integer.Parse(dr.Cells("IdMarca").Value.ToString())
            bscCodigoMarca.Text = dr.Cells("IdMarca").Value.ToString()
            bscMarca.Text = dr.Cells("NombreMarca").Value.ToString()
            bscCodigoMarca.Selecciono = True
         End If
         bscCodigoRubro.Focus()
      End If
   End Sub

   Private Sub CargarRubro(dr As DataGridViewRow)
      If dr IsNot Nothing Then
         'tengo que limpiar el SubRubro si cargo un Rubro si no esta cargando la pantalla
         If Not _estaCargando And bscCodigoSubRubro.Visible Then
            bscCodigoSubRubro.Text = "0"
            bscSubRubro.Text = ""
         End If
         If Not _estaCargando And bscCodigoSubSubRubro.Visible Then
            bscCodigoSubSubRubro.Text = "0"
            bscSubSubRubro.Text = ""
         End If

         DirectCast(_entidad, Entidades.Producto).IdRubro = Integer.Parse(dr.Cells("IdRubro").Value.ToString())
         bscCodigoRubro.Text = dr.Cells("IdRubro").Value.ToString()
         bscRubro.Text = dr.Cells("NombreRubro").Value.ToString()

         If bscCodigoSubRubro.Visible Then
            bscCodigoSubRubro.Focus()
         End If
      End If
   End Sub

   Private Sub CargarSubRubro(dr As DataGridViewRow)
      If dr IsNot Nothing Then
         'tengo que limpiar el SubSubRubro si cargo un SubRubro si no esta cargando la pantalla
         If Not Me._estaCargando And Me.bscCodigoSubSubRubro.Visible Then
            Me.bscCodigoSubSubRubro.Text = "0"
            Me.bscSubSubRubro.Text = ""
         End If

         _SubRubroAtributo = If(Integer.Parse(dr.Cells("Atributos").Value.ToString()) > 0, True, False)

         '-- REQ-35659.- -----------------------------------------
         If _SubRubroAtributo Then
            VisualizaAjusteStock(False)
         End If
         '--------------------------------------------------------
         DirectCast(Me._entidad, Entidades.Producto).IdSubRubro = Int32.Parse(dr.Cells("IdSubRubro").Value.ToString())
         Me.bscCodigoSubRubro.Text = dr.Cells("IdSubRubro").Value.ToString()
         Me.bscSubRubro.Text = dr.Cells("NombreSubRubro").Value.ToString()

         If Integer.Parse("0" & Me.bscCodigoMarca.Text) = 0 Then
            DirectCast(Me._entidad, Entidades.Producto).IdRubro = Int32.Parse(dr.Cells("IdRubro").Value.ToString())
            Me.bscCodigoRubro.Text = dr.Cells("IdRubro").Value.ToString()
            Me.bscRubro.Text = dr.Cells("NombreRubro").Value.ToString()
            Me.bscCodigoRubro.Selecciono = True
         End If

         Dim idRubroPantalla As Integer = 0
         If IsNumeric(bscCodigoRubro.Text) Then idRubroPantalla = Integer.Parse(bscCodigoRubro.Text)
         If idRubroPantalla = 0 Then
            Dim tempEstaCargando As Boolean = _estaCargando
            _estaCargando = True
            bscCodigoRubro.Text = dr.Cells("IdRubro").Value.ToString()
            bscCodigoRubro.PresionarBoton()
            _estaCargando = tempEstaCargando
         End If
      End If

   End Sub

   Private Sub CargarSubSubRubro(dr As DataGridViewRow)
      If dr IsNot Nothing Then
         DirectCast(Me._entidad, Entidades.Producto).IdSubSubRubro = Int32.Parse(dr.Cells("IdSubSubRubro").Value.ToString())
         Me.bscCodigoSubSubRubro.Text = dr.Cells("IdSubSubRubro").Value.ToString()
         Me.bscSubSubRubro.Text = dr.Cells("NombreSubSubRubro").Value.ToString()

         Dim idSubRubroPantalla As Integer = 0
         If IsNumeric(bscCodigoSubRubro.Text) Then idSubRubroPantalla = Integer.Parse(bscCodigoSubRubro.Text)
         If idSubRubroPantalla = 0 Then
            Dim tempEstaCargando As Boolean = _estaCargando
            _estaCargando = True
            bscCodigoSubRubro.Text = dr.Cells("IdSubRubro").Value.ToString()
            bscCodigoSubRubro.PresionarBoton()
            _estaCargando = tempEstaCargando
         End If
         bscCodigoSubSubRubro.Focus()
      End If

   End Sub

   Private Sub CalcularKilos()

      If Me.cmbUnidadDeMedida.SelectedValue IsNot Nothing Then

         Dim unid As Entidades.UnidadDeMedida
         Dim ounid As Reglas.UnidadesDeMedidas = New Reglas.UnidadesDeMedidas
         unid = ounid.GetUno(Me.cmbUnidadDeMedida.SelectedValue.ToString())

         'Si esta en cero pudo digitarlo y se perderia
         If unid.ConversionAKilos > 0 Then
            If Me._EmbalajeNormal Then
               Me.txtKilos.Text = (Decimal.Parse(Me.txtTamanio.Text) * unid.ConversionAKilos * Integer.Parse("0" & Me.txtEmbalaje.Text)).ToString("#0.000")
            Else
               Me.txtKilos.Text = (Decimal.Parse(Me.txtTamanio.Text) * unid.ConversionAKilos).ToString("#0.000")
            End If
         End If

         'Solo habilito si digito "Unidad" que da cero, por ahi necesita cargarlo.
         Me.txtKilos.Enabled = (unid.ConversionAKilos = 0)

      Else
         Me.txtKilos.Enabled = True 'Que ponga lo que quiera!
      End If

   End Sub

   Private Sub CargarConcepto(dr As DataGridViewRow)

      Me.bscCodigoConcepto.Text = dr.Cells("IdConcepto").Value.ToString.Trim()
      Me.bscCodigoConcepto.Enabled = False
      Me.bscConcepto.Text = dr.Cells("NombreConcepto").Value.ToString()
      Me.bscConcepto.Enabled = False

   End Sub

   Private Sub AgregarMarca()
      Dim conc As Entidades.ProductoConcepto = New Entidades.ProductoConcepto()
      With conc
         .IdProducto = Me.txtIdProducto.Text
         .IdConcepto = Integer.Parse(Me.bscCodigoConcepto.Text.ToString())
         .NombreConcepto = Me.bscConcepto.Text.ToString()
      End With

      Me._conceptos.Add(conc)

      Me.dgvDetalleConceptos.DataSource = Me._conceptos.ToArray()

      DirectCast(Me._entidad, Entidades.Producto).Conceptos = Me._conceptos

   End Sub

   Private Sub EliminarLineaDescuento()

      Me._conceptos.RemoveAt(Me.dgvDetalleConceptos.SelectedRows(0).Index)

      Me.dgvDetalleConceptos.DataSource = Me._conceptos.ToArray()

      If Me.dgvDetalleConceptos.Rows.Count > 0 Then
         Me.dgvDetalleConceptos.FirstDisplayedScrollingRowIndex = Me.dgvDetalleConceptos.Rows.Count - 1
         Me.dgvDetalleConceptos.Rows(Me.dgvDetalleConceptos.Rows.Count - 1).Selected = True
      End If

      DirectCast(Me._entidad, Entidades.Producto).Conceptos = Me._conceptos

   End Sub

   Private Function ExisteConcepto(idConcepto As Integer) As Boolean

      For Each dr As DataGridViewRow In Me.dgvDetalleConceptos.Rows
         If Integer.Parse(dr.Cells("IdConcepto").Value.ToString()) = idConcepto Then
            Return True
         End If
      Next

      Return False

   End Function

   Private Function ConvertirEAN8(cadena As String) As String
      Me.txtCodigoDeBarras.Text = ""
      Dim EAN8 As String = ""
      Dim i%, checksum%
      If Len(cadena) = 7 Then

         For i% = 1 To 7
            If Asc(Mid$(cadena, i%, 1)) < 48 Or Asc(Mid$(cadena, i%, 1)) > 57 Then
               i% = 0
               Exit For
            End If
         Next
         If i% = 8 Then

            For i% = 7 To 1 Step -2
               checksum% += Integer.Parse(Val(Mid$(cadena, i%, 1)).ToString())
            Next
            checksum% = checksum% * 3
            For i% = 6 To 1 Step -2
               checksum% += Integer.Parse(Val(Mid$(cadena, i%, 1)).ToString())
            Next
            cadena = cadena & (10 - checksum% Mod 10) Mod 10
         End If
      Else
         MessageBox.Show("La cadena tiene " & Len(cadena) & " dígitos debe ser de 7 digitos", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
         Return ""
         Exit Function
      End If
      Return cadena
   End Function

   Private Function ConvertirEAN13(cadena As String) As String
      Me.txtCodigoDeBarras.Text = ""
      Dim EAN13 As String = ""
      Dim i%, checksum%

      If Len(cadena) = 12 Then

         For i% = 1 To 12
            If Asc(Mid$(cadena, i%, 1)) < 48 Or Asc(Mid$(cadena, i%, 1)) > 57 Then
               i% = 0
               Exit For
            End If
         Next
         If i% = 13 Then
            For i% = 12 To 1 Step -2
               checksum% += Integer.Parse(Val(Mid$(cadena, i%, 1)).ToString())
            Next
            checksum% = checksum% * 3
            For i% = 11 To 1 Step -2
               checksum% += Integer.Parse(Val(Mid$(cadena, i%, 1)).ToString())
            Next
            cadena = cadena & (10 - checksum% Mod 10) Mod 10
         End If
      Else
         MessageBox.Show("La cadena tiene " & Len(cadena) & " dígitos debe ser de 12 dígitos", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
         Return ""
         Exit Function
      End If
      Return cadena
   End Function

   Private Sub CargarDatosProveedor(dr As DataGridViewRow)

      Me.bscCodigoProveedor.Text = dr.Cells("CodigoProveedor").Value.ToString()
      Me.bscCodigoProveedor.Tag = dr.Cells("IdProveedor").Value.ToString()
      Me.bscProveedor.Text = dr.Cells("NombreProveedor").Value.ToString()
      Me.bscProveedor.Tag = dr.Cells("IdProveedor").Value.ToString()

      Me.bscCodigoProveedor.Selecciono = True
      Me.bscProveedor.Selecciono = True

      Dim dt As DataTable = New Reglas.ProductosProveedores().GetPorProductoYProveedor(CLng(dr.Cells("IdProveedor").Value), txtIdProducto.Text)
      If dt.Rows.Count > 0 Then
         txtCodigoProductoProveedor.Text = dt.Rows(0)(Entidades.ProductoProveedor.Columnas.CodigoProductoProveedor.ToString()).ToString()

         txtPrecioLista.Text = CDec(dt.Rows(0)(Entidades.ProductoProveedor.Columnas.UltimoPrecioFabrica.ToString())).ToString("N2")

         If Not IsDBNull(dt.Rows(0)(Entidades.ProductoProveedor.Columnas.UltimoPrecioCompra.ToString())) Then
            txtUltimoPrecioCompra.Text = CDec(dt.Rows(0)(Entidades.ProductoProveedor.Columnas.UltimoPrecioCompra.ToString())).ToString("N2")
         Else
            txtUltimoPrecioCompra.Text = _ceroFormatoEnPrecio
         End If

         txtDescuento1.Text = CDec(dt.Rows(0)(Entidades.ProductoProveedor.Columnas.DescuentoRecargoPorc1.ToString())).ToString("N2")
         txtDescuento2.Text = CDec(dt.Rows(0)(Entidades.ProductoProveedor.Columnas.DescuentoRecargoPorc2.ToString())).ToString("N2")
         txtDescuento3.Text = CDec(dt.Rows(0)(Entidades.ProductoProveedor.Columnas.DescuentoRecargoPorc3.ToString())).ToString("N2")
         txtDescuento4.Text = CDec(dt.Rows(0)(Entidades.ProductoProveedor.Columnas.DescuentoRecargoPorc4.ToString())).ToString("N2")

         If Not IsDBNull(dt.Rows(0)(Entidades.ProductoProveedor.Columnas.UltimaFechaCompra.ToString())) Then
            txtUltimaFechaCompra.Text = dt.Rows(0)(Entidades.ProductoProveedor.Columnas.UltimaFechaCompra.ToString()).ToString()
         End If
      Else
         txtCodigoProductoProveedor.Text = String.Empty

         txtPrecioLista.Text = _ceroFormatoEnPrecio
         txtUltimoPrecioCompra.Text = _ceroFormatoEnPrecio
         txtDescuento1.Text = "0.00"
         txtDescuento2.Text = "0.00"
         txtDescuento3.Text = "0.00"
         txtDescuento4.Text = "0.00"

         txtUltimaFechaCompra.Text = String.Empty
      End If

      ''MuestraPrecioCosto()

      Me.txtCodigoProductoProveedor.Focus()
   End Sub
   Private Function ValidarMuestraPrecioCosto() As Boolean
      If Reglas.Publicos.UtilizaPrecioDeCompra AndAlso Decimal.Parse(txtPrecioLista.Text) < 0 Then
         MessageBox.Show("Atención: El Precio de Compra es Negativo, NO puede continuar.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
         Return False
      End If
      If Decimal.Parse(txtPrecioCosto.Text) < 0 Then
         MessageBox.Show("Atención: El Precio de Costo es Negativo, NO puede continuar.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
         Return False
      End If
      Return True
   End Function
   Private Sub MuestraPrecioCosto()
      Try

         If ValidarMuestraPrecioCosto() Then
            Dim costoAnterior As String = txtPrecioCosto.Text
            Dim precioCostoAnterior As Decimal = If(IsNumeric(txtPrecioCostoAnterior.Text), Decimal.Parse(txtPrecioCostoAnterior.Text), 0)
            Dim precioLista As Decimal = If(IsNumeric(txtPrecioLista.Text), Decimal.Parse(txtPrecioLista.Text), 0)
            Dim precioCosto As Decimal = precioLista
            precioCosto = precioCosto + (precioCosto * If(IsNumeric(txtDescuento1.Text), Decimal.Parse(txtDescuento1.Text), 0) / 100)
            precioCosto = precioCosto + (precioCosto * If(IsNumeric(txtDescuento2.Text), Decimal.Parse(txtDescuento2.Text), 0) / 100)
            precioCosto = precioCosto + (precioCosto * If(IsNumeric(txtDescuento3.Text), Decimal.Parse(txtDescuento3.Text), 0) / 100)
            precioCosto = precioCosto + (precioCosto * If(IsNumeric(txtDescuento4.Text), Decimal.Parse(txtDescuento4.Text), 0) / 100)
            txtPrecioCosto.Text = Math.Round(precioCosto, _decimalesEnPrecio).ToString("N2")

            If precioCostoAnterior > 0 And precioCosto = 0 Then
               If MessageBox.Show("Atención: El precio de Costo Nuevo es 0 (cero) pero el Actual NO, ¿ Desea continuar ?",
                                  Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.No Then
                  txtPrecioCosto.Text = costoAnterior
                  Exit Sub
               End If
            End If
            If Reglas.Publicos.UtilizaPrecioDeCompra AndAlso precioCosto > precioLista Then
               If MessageBox.Show("El Precio de Costo es mayor al Precio de Compra, ¿ Desea Continuar ?",
                                  Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.No Then
                  txtPrecioCosto.Text = costoAnterior
                  Exit Sub
               End If
            End If
         End If

      Catch ex As Exception
         txtPrecioCosto.Text = _ceroFormatoEnPrecio
         ShowError(ex)
      End Try
   End Sub

   Private Sub CreaDTPrecios()
      dtListaPrecios = New DataTable()

      dtListaPrecios.Columns.Add(ListaPreciosColumns.IdListaPrecios.ToString(), GetType(Int32))
      dtListaPrecios.Columns.Add(ListaPreciosColumns.NombreListaPrecios.ToString(), GetType(String))
      dtListaPrecios.Columns.Add(ListaPreciosColumns.PrecioVenta.ToString(), GetType(Decimal))
      dtListaPrecios.Columns.Add(ListaPreciosColumns.PrecioVentaBase.ToString(), GetType(Decimal))
      dtListaPrecios.Columns.Add(ListaPreciosColumns.PorcentajeBase.ToString(), GetType(Decimal))
      dtListaPrecios.Columns.Add(ListaPreciosColumns.PrecioCosto.ToString(), GetType(Decimal))
      dtListaPrecios.Columns.Add(ListaPreciosColumns.PorcentajeCosto.ToString(), GetType(Decimal))
      dtListaPrecios.Columns.Add(ListaPreciosColumns.PorcentajeCalculado.ToString(), GetType(Decimal))
      dtListaPrecios.Columns.Add(ListaPreciosColumns.PorcActual.ToString(), GetType(Boolean))
      dtListaPrecios.Columns.Add(ListaPreciosColumns.SobreVenta.ToString(), GetType(Boolean))
      dtListaPrecios.Columns.Add(ListaPreciosColumns.SobreCosto.ToString(), GetType(Boolean))
      dtListaPrecios.Columns.Add(ListaPreciosColumns.DesdeFormula.ToString(), GetType(Boolean))
      dtListaPrecios.Columns.Add(ListaPreciosColumns.PermiteUtilidadEnCero.ToString(), GetType(Boolean))
   End Sub

   Private Sub CargaDTPrecios()

      If DirectCast(Me._entidad, Entidades.Producto).Precios IsNot Nothing Then
         For Each drPrecios As DataRow In DirectCast(Me._entidad, Entidades.Producto).Precios.Rows
            If CBool(drPrecios("Activa")) Then
               Dim dr As DataRow
               dr = dtListaPrecios.NewRow()
               dr(ListaPreciosColumns.IdListaPrecios.ToString()) = drPrecios("IdListaPrecios")
               dr(ListaPreciosColumns.NombreListaPrecios.ToString()) = drPrecios("NombreListaPrecios")
               dr(ListaPreciosColumns.PrecioVenta.ToString()) = drPrecios("PrecioVenta")
               dr(ListaPreciosColumns.PrecioVentaBase.ToString()) = drPrecios("PrecioVentaBase")
               dr(ListaPreciosColumns.PorcentajeBase.ToString()) = drPrecios("PorcentajeBase")
               dr(ListaPreciosColumns.PrecioCosto.ToString()) = drPrecios("PrecioCosto")
               dr(ListaPreciosColumns.PorcentajeCosto.ToString()) = drPrecios("PorcentajeCosto")

               'dr(ListaPreciosColumns.PorcentajeCalculado.ToString()) = IIf(Reglas.Publicos.ActualizaPreciosCalculo = TiposPreciosCalculo.ACTUAL.ToString(), drPrecios("PorcentajeCosto"), drPrecios("PorcentajeBase"))

               dr(ListaPreciosColumns.PorcentajeCalculado.ToString()) = drPrecios("PorcentajeBase")
               If Reglas.Publicos.ActualizaPreciosCalculo = TiposPreciosCalculo.ACTUAL.ToString() Then
                  dr(ListaPreciosColumns.PorcentajeCalculado.ToString()) = drPrecios("PorcentajeCosto")
               ElseIf Reglas.Publicos.ActualizaPreciosCalculo = TiposPreciosCalculo.COSTO.ToString() Then
                  dr(ListaPreciosColumns.PorcentajeCalculado.ToString()) = drPrecios("DescuentoRecargoPorc")
               End If


               dr(ListaPreciosColumns.PorcActual.ToString()) = Reglas.Publicos.ActualizaPreciosCalculo = TiposPreciosCalculo.ACTUAL.ToString()
               Me.dgvListasPrecios.UpdateData()
               dr(ListaPreciosColumns.SobreVenta.ToString()) = Reglas.Publicos.ActualizaPreciosCalculo = TiposPreciosCalculo.VENTA.ToString()
               Me.dgvListasPrecios.UpdateData()
               dr(ListaPreciosColumns.SobreCosto.ToString()) = Reglas.Publicos.ActualizaPreciosCalculo = TiposPreciosCalculo.COSTO.ToString()
               Me.dgvListasPrecios.UpdateData()
               dr(ListaPreciosColumns.DesdeFormula.ToString()) = Reglas.Publicos.ActualizaPreciosCalculo = TiposPreciosCalculo.FORMULA.ToString()
               Me.dgvListasPrecios.UpdateData()
               dr(ListaPreciosColumns.PermiteUtilidadEnCero.ToString()) = drPrecios("PermiteUtilidadEnCero")
               dtListaPrecios.Rows.Add(dr)
            End If
         Next
      End If

      For Each drPrecios As DataRow In New Reglas.ListasDePrecios().GetAll(True, Entidades.ListaDePrecios.Columnas.NombreListaPrecios).Rows
         If dtListaPrecios.Select(String.Format("{0} = {1}", ListaPreciosColumns.IdListaPrecios.ToString(), drPrecios("IdListaPrecios"))).Length = 0 Then
            Dim dr As DataRow
            dr = dtListaPrecios.NewRow()
            dr(ListaPreciosColumns.IdListaPrecios.ToString()) = drPrecios("IdListaPrecios")
            dr(ListaPreciosColumns.NombreListaPrecios.ToString()) = drPrecios("NombreListaPrecios")
            dr(ListaPreciosColumns.PrecioVenta.ToString()) = 0
            dr(ListaPreciosColumns.PrecioVentaBase.ToString()) = 0
            dr(ListaPreciosColumns.PorcentajeBase.ToString()) = 0
            dr(ListaPreciosColumns.PrecioCosto.ToString()) = 0
            dr(ListaPreciosColumns.PorcentajeCosto.ToString()) = 0
            dr(ListaPreciosColumns.PorcentajeCalculado.ToString()) = 0

            If Reglas.Publicos.ActualizaPreciosCalculo = TiposPreciosCalculo.COSTO.ToString() Then
               dr(ListaPreciosColumns.PorcentajeCalculado.ToString()) = drPrecios("DescuentoRecargoPorc")
            End If

            dr(ListaPreciosColumns.PorcActual.ToString()) = Reglas.Publicos.ActualizaPreciosCalculo = TiposPreciosCalculo.ACTUAL.ToString()
            Me.dgvListasPrecios.UpdateData()
            dr(ListaPreciosColumns.SobreVenta.ToString()) = Reglas.Publicos.ActualizaPreciosCalculo = TiposPreciosCalculo.VENTA.ToString()
            Me.dgvListasPrecios.UpdateData()
            dr(ListaPreciosColumns.SobreCosto.ToString()) = Reglas.Publicos.ActualizaPreciosCalculo = TiposPreciosCalculo.COSTO.ToString()
            Me.dgvListasPrecios.UpdateData()
            dr(ListaPreciosColumns.DesdeFormula.ToString()) = Reglas.Publicos.ActualizaPreciosCalculo = TiposPreciosCalculo.FORMULA.ToString()
            Me.dgvListasPrecios.UpdateData()
            dr(ListaPreciosColumns.PermiteUtilidadEnCero.ToString()) = drPrecios("PermiteUtilidadEnCero")
            dtListaPrecios.Rows.Add(dr)
         End If
      Next

   End Sub

   Private Enum TiposPreciosCalculo
      ACTUAL
      VENTA
      COSTO
      FORMULA
   End Enum

   Private Enum ListaPreciosColumns
      IdListaPrecios
      NombreListaPrecios
      PrecioVenta
      PrecioVentaBase
      PorcentajeBase
      PrecioCosto
      PorcentajeCosto
      PorcActual
      SobreVenta
      SobreCosto
      DesdeFormula
      PorcentajeCalculado
      PermiteUtilidadEnCero
   End Enum

   Private Sub FormateaGrillaPrecios()
      AjustarColumnasGrilla(dgvListasPrecios, _titPrecios)
      With dgvListasPrecios.DisplayLayout.Bands(0)
         '.Override.WrapHeaderText = DefaultableBoolean.True
         'For Each columna As UltraGridColumn In .Columns
         '      columna.Hidden = True
         '      columna.CellActivation = Activation.NoEdit
         'Next

         .Columns(ListaPreciosColumns.NombreListaPrecios.ToString()).Header.Caption = "Nombre"
         .Columns(ListaPreciosColumns.NombreListaPrecios.ToString()).Width = 160
         .Columns(ListaPreciosColumns.NombreListaPrecios.ToString()).Hidden = False

         .Columns(ListaPreciosColumns.PrecioVenta.ToString()).Header.Caption = "Precio Nuevo"
         .Columns(ListaPreciosColumns.PrecioVenta.ToString()).CellActivation = Activation.AllowEdit
         .Columns(ListaPreciosColumns.PrecioVenta.ToString()).Width = 60
         .Columns(ListaPreciosColumns.PrecioVenta.ToString()).Format = _formatoEnPrecio
         .Columns(ListaPreciosColumns.PrecioVenta.ToString()).MaskInput = "{double:-9." + _decimalesEnPrecio.ToString() + "}"
         .Columns(ListaPreciosColumns.PrecioVenta.ToString()).Hidden = False
         .Columns(ListaPreciosColumns.PrecioVenta.ToString()).CellAppearance.TextHAlign = HAlign.Right
         .Columns(ListaPreciosColumns.PrecioVenta.ToString()).CellAppearance.BackColor = System.Drawing.Color.FromArgb(224, 224, 224)


         .Columns(ListaPreciosColumns.PrecioVentaBase.ToString()).Header.Caption = "Precio"
         .Columns(ListaPreciosColumns.PrecioVentaBase.ToString()).CellActivation = Activation.AllowEdit
         .Columns(ListaPreciosColumns.PrecioVentaBase.ToString()).Width = 60
         .Columns(ListaPreciosColumns.PrecioVentaBase.ToString()).Format = _formatoEnPrecio
         .Columns(ListaPreciosColumns.PrecioVentaBase.ToString()).MaskInput = "{double:-9." + _decimalesEnPrecio.ToString() + "}"
         .Columns(ListaPreciosColumns.PrecioVentaBase.ToString()).Hidden = False
         .Columns(ListaPreciosColumns.PrecioVentaBase.ToString()).CellAppearance.TextHAlign = HAlign.Right

         .Columns(ListaPreciosColumns.PorcentajeCalculado.ToString()).Header.Caption = "%"
         .Columns(ListaPreciosColumns.PorcentajeCalculado.ToString()).CellActivation = Activation.AllowEdit
         .Columns(ListaPreciosColumns.PorcentajeCalculado.ToString()).Width = 50
         .Columns(ListaPreciosColumns.PorcentajeCalculado.ToString()).Format = "N2"
         .Columns(ListaPreciosColumns.PorcentajeCalculado.ToString()).MaskInput = "{double:-4.2}"
         .Columns(ListaPreciosColumns.PorcentajeCalculado.ToString()).Hidden = False
         .Columns(ListaPreciosColumns.PorcentajeCalculado.ToString()).CellAppearance.TextHAlign = HAlign.Right

         '.Columns(ListaPreciosColumns.PorcActual.ToString()).Header.Caption = "Porc. Actual"
         '.Columns(ListaPreciosColumns.PorcActual.ToString()).CellActivation = Activation.AllowEdit
         '.Columns(ListaPreciosColumns.PorcActual.ToString()).Width = 50
         '.Columns(ListaPreciosColumns.PorcActual.ToString()).Hidden = False

         '.Columns(ListaPreciosColumns.SobreVenta.ToString()).Header.Caption = "Sobre Venta"
         '.Columns(ListaPreciosColumns.SobreVenta.ToString()).CellActivation = Activation.AllowEdit
         '.Columns(ListaPreciosColumns.SobreVenta.ToString()).Width = 50
         '.Columns(ListaPreciosColumns.SobreVenta.ToString()).Hidden = False

         '.Columns(ListaPreciosColumns.SobreCosto.ToString()).Header.Caption = "Sobre Costo"
         '.Columns(ListaPreciosColumns.SobreCosto.ToString()).CellActivation = Activation.AllowEdit
         '.Columns(ListaPreciosColumns.SobreCosto.ToString()).Width = 50
         '.Columns(ListaPreciosColumns.SobreCosto.ToString()).Hidden = False

         'If Publicos.TieneModuloProduccion Then
         '      .Columns(ListaPreciosColumns.DesdeFormula.ToString()).Header.Caption = "Desde Form."
         '      .Columns(ListaPreciosColumns.DesdeFormula.ToString()).CellActivation = Activation.AllowEdit
         '      .Columns(ListaPreciosColumns.DesdeFormula.ToString()).Width = 50
         '      .Columns(ListaPreciosColumns.DesdeFormula.ToString()).Hidden = False
         'End If

         'dgvListasPrecios.DisplayLayout.Override.HeaderClickAction = HeaderClickAction.Select
         'dgvListasPrecios.DisplayLayout.GroupByBox.Hidden = True
         'dgvListasPrecios.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns
      End With
   End Sub
   Private Sub FormateaGrillaCalidad()
      Dim pos = 0I
      With ugCalidad.DisplayLayout.Bands(0)
         .OcultaTodasLasColumnas()
         .Columns("NombreListaControl").FormatearColumna("Lista Control", pos, 380, HAlign.Left)
      End With
   End Sub
   Private Sub FormateaGrillaCalidadProductos()
      Dim pos = 0I
      With ugCalidadProductos.DisplayLayout.Bands(0)
         .OcultaTodasLasColumnas()
         .Columns("NombreListaControl").FormatearColumna("Lista Control", pos, 380, HAlign.Left)
      End With
   End Sub
   Private Function ValidarRecalculaPrecios() As Boolean

      For Each drPrecios As DataRow In dtListaPrecios.Rows
         Dim porcRecargo As Decimal = If(IsNumeric(Decimal.Parse(drPrecios(ListaPreciosColumns.PorcentajeCalculado.ToString()).ToString())), Decimal.Parse(drPrecios(ListaPreciosColumns.PorcentajeCalculado.ToString()).ToString()), 0)
         If porcRecargo = 0 And Boolean.Parse(drPrecios(ListaPreciosColumns.SobreCosto.ToString()).ToString()) And Not Boolean.Parse(drPrecios(ListaPreciosColumns.PermiteUtilidadEnCero.ToString()).ToString()) Then
            MessageBox.Show(String.Format("Atención: En la lista {0}, no esta permitido utilidad en cero",
                                          drPrecios(ListaPreciosColumns.NombreListaPrecios.ToString())).ToString(),
                             Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
         End If
      Next
      Return True
   End Function
   Private Sub RecalculaPrecios()

      For Each drPrecios As DataRow In dtListaPrecios.Rows
         If CBool(drPrecios(ListaPreciosColumns.PorcActual.ToString())) Then
            Me.RecalculaPreciosPorcActual(drPrecios)
         ElseIf CBool(drPrecios(ListaPreciosColumns.SobreCosto.ToString())) Then
            Me.RecalculaPreciosSobreCosto(drPrecios)
         ElseIf CBool(drPrecios(ListaPreciosColumns.SobreVenta.ToString())) Then
            Me.RecalculaPreciosSobreVenta(drPrecios)
         ElseIf CBool(drPrecios(ListaPreciosColumns.DesdeFormula.ToString())) Then
            Me.RecalculaPreciosDesdeFormula(drPrecios)
         End If


         Dim precioVentaNuevo As Decimal = CDec(drPrecios(ListaPreciosColumns.PrecioVenta.ToString()))

         precioVentaNuevo = Math.Round(precioVentaNuevo, CInt(Me.txtRedondeoPrecioVenta.Text))

         If Me.chbAjusteA.Checked And precioVentaNuevo > 0 Then
            'Si ajustamos a 0
            If Me.chbAjusteA.Checked And Integer.Parse(txtAjusteA.Text) = 0 Then
               Dim PrecioTemporal As String = precioVentaNuevo.ToString("#,##0." + New String("0"c, CInt(txtRedondeoPrecioVenta.Text)))
               precioVentaNuevo = Decimal.Parse(Split(PrecioTemporal, ".")(0).Substring(0, Split(PrecioTemporal, ".")(0).Length() - 1) + txtAjusteA.Text)
            Else
               Dim PrecioTemporal As String = precioVentaNuevo.ToString("#,##0." + New String("0"c, CInt(txtRedondeoPrecioVenta.Text)))
               precioVentaNuevo = Decimal.Parse(Strings.Mid(PrecioTemporal, 1, PrecioTemporal.Length() - 1) + txtAjusteA.Text)
            End If
         End If

         drPrecios(ListaPreciosColumns.PrecioVenta.ToString()) = precioVentaNuevo

         If Decimal.Parse(txtPrecioCosto.Text) = precioVentaNuevo And Not Boolean.Parse(drPrecios(ListaPreciosColumns.PermiteUtilidadEnCero.ToString()).ToString()) Then
            MessageBox.Show(String.Format("Atención: En la lista {0}, no esta permitido utilidad en cero",
                                          drPrecios(ListaPreciosColumns.NombreListaPrecios.ToString())).ToString(),
                             Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
            drPrecios(ListaPreciosColumns.PrecioVenta.ToString()) = Decimal.Parse(drPrecios(ListaPreciosColumns.PrecioVentaBase.ToString()).ToString())
            Exit Sub
         End If

         If Decimal.Parse(drPrecios(ListaPreciosColumns.PrecioVentaBase.ToString()).ToString()) > 0 And precioVentaNuevo = 0 Then
            If MessageBox.Show(String.Format("Atención: En la lista {0}, El Nuevo Precio de Venta es 0 (cero) pero el Actual NO, ¿ Desea Continuar ?",
                                            drPrecios(ListaPreciosColumns.NombreListaPrecios.ToString())).ToString(),
                               Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.No Then

               drPrecios(ListaPreciosColumns.PrecioVenta.ToString()) = Decimal.Parse(drPrecios(ListaPreciosColumns.PrecioVentaBase.ToString()).ToString())
            End If
         End If
         If Decimal.Parse(txtPrecioCosto.Text) > precioVentaNuevo Then
            If MessageBox.Show(String.Format("Atención: En la lista {0}, El Precio de Costo es mayor al Precio de Venta, ¿ Desea Continuar ?",
                               drPrecios(ListaPreciosColumns.NombreListaPrecios.ToString())).ToString(),
                               Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.No Then

               drPrecios(ListaPreciosColumns.PrecioVenta.ToString()) = Decimal.Parse(drPrecios(ListaPreciosColumns.PrecioVentaBase.ToString()).ToString())
            End If
         End If
      Next
   End Sub

   Private Sub RecalculaPreciosPorcActual(drPrecios As DataRow)
      drPrecios(ListaPreciosColumns.PrecioVenta.ToString()) = Decimal.Parse(Me.txtPrecioCosto.Text) +
                                                              (Decimal.Parse(Me.txtPrecioCosto.Text) * Decimal.Parse(drPrecios(ListaPreciosColumns.PorcentajeCosto.ToString()).ToString()) / 100)
   End Sub

   Private Sub RecalculaPreciosSobreCosto(drPrecios As DataRow)
      drPrecios(ListaPreciosColumns.PrecioVenta.ToString()) = Decimal.Parse(Me.txtPrecioCosto.Text) +
                                                              (Decimal.Parse(Me.txtPrecioCosto.Text) * Decimal.Parse(drPrecios(ListaPreciosColumns.PorcentajeCalculado.ToString()).ToString()) / 100)
   End Sub

   Private Sub RecalculaPreciosSobreVenta(drPrecios As DataRow)
      drPrecios(ListaPreciosColumns.PrecioVenta.ToString()) = Decimal.Parse(drPrecios(ListaPreciosColumns.PrecioVentaBase.ToString()).ToString()) +
                                                              (Decimal.Parse(drPrecios(ListaPreciosColumns.PrecioVentaBase.ToString()).ToString()) * Decimal.Parse(drPrecios(ListaPreciosColumns.PorcentajeCalculado.ToString()).ToString()) / 100)
   End Sub

   Private Sub RecalculaPreciosDesdeFormula(drPrecios As DataRow)
      Dim oProdComp As Reglas.ProductosComponentes = New Reglas.ProductosComponentes()

      Dim formula As Integer
      formula = Me._reglasProductos.GetUno(IdProducto).IdFormula

      Dim precioVenta As Decimal = oProdComp.GetPrecioVenta(actual.Sucursal.IdSucursal, IdProducto, formula, CInt(drPrecios(ListaPreciosColumns.IdListaPrecios.ToString())))
      Dim porcRecargo As Decimal = CDec(drPrecios(ListaPreciosColumns.PorcentajeCalculado.ToString()))
      If porcRecargo <> 0 Then
         drPrecios(ListaPreciosColumns.PrecioVenta.ToString()) = precioVenta + Decimal.Round(precioVenta * porcRecargo, _decimalesEnPrecio)
      Else
         drPrecios(ListaPreciosColumns.PrecioVenta.ToString()) = precioVenta
      End If
   End Sub

   Private Sub AjustarColumnasGrillaProductosProveedores()
      'SI SE DESEA CAMBIAR EL TITULO DE ALGUNA COLUMNA EN PARTICULAR
      'tit("NOMBRECOLUMNA") = "NUEVO HEADER"

      For Each col As UltraGridColumn In ugProductosProveedores.DisplayLayout.Bands(0).Columns
         col.Hidden = Not _titProductoProveedor.ContainsKey(col.Key)
         If _titProductoProveedor.ContainsKey(col.Key) Then
            If Not String.IsNullOrWhiteSpace(_titProductoProveedor(col.Key)) Then
               col.Header.Caption = _titProductoProveedor(col.Key)
            End If
         End If
      Next
   End Sub
   Private Sub AjustarColumnasGrillaProductoOferta()
      ugProductoOfertas.DisplayLayout.UseFixedHeaders = True
      ugProductoOfertas.DisplayLayout.Override.FixedHeaderIndicator = FixedHeaderIndicator.None
      Dim pos As Integer = 0
      With Me.ugProductoOfertas.DisplayLayout.Bands(0)

         For Each columna As UltraGridColumn In .Columns
            columna.Hidden = True
            columna.CellActivation = Activation.NoEdit
         Next

         .Columns("FechaDesde").FormatearColumna("Fecha Desde", pos, 130, HAlign.Left, False, "dd/MM/yyyy")
         .Columns("FechaHasta").FormatearColumna("Fecha Hasta", pos, 130, HAlign.Left, False, "dd/MM/yyyy")
         .Columns("LimiteStock").FormatearColumna("Cantidad Asignada", pos, 90, HAlign.Right, False, "N2")
         .Columns("CantidadConsumida").FormatearColumna("Cantidad Comprometida", pos, 90, HAlign.Right, False, "N2")
         .Columns("PrecioOferta").FormatearColumna("Precio de Oferta", pos, 90, HAlign.Right, False, "N2")
         .Columns("Activa").FormatearColumna("Activa", pos, 50, HAlign.Center)
      End With
   End Sub

#End Region

   Private Sub MostrarUltimoPrecioCosto(producto As Entidades.Producto)
      If lblPrecioCostoAnterior IsNot Nothing Then
         lblPrecioCostoAnterior.Text = ""
         txtPrecioCostoAnterior.Text = ""
         If producto IsNot Nothing Then
            If producto.FechaUltimoCostoAnterior.HasValue Then
               lblPrecioCostoAnterior.Text = String.Format("{0:dd/MM/yyyy HH:mm}", producto.FechaUltimoCostoAnterior.Value)
            End If
            If producto.PrecioCostoAnterior.HasValue Then
               txtPrecioCostoAnterior.Text = producto.PrecioCostoAnterior.Value.ToString(_formatoEnPrecio)
            End If
         End If         'If producto IsNot Nothing Then
      End If            'If lbl IsNot Nothing Then
   End Sub

   Private Sub btnBuscarImagen2_Click(sender As Object, e As EventArgs) Handles btnBuscarImagen2.Click
      Try
         If Me.ofdArchivos.ShowDialog() = Windows.Forms.DialogResult.OK Then
            If Not String.IsNullOrEmpty(Me.ofdArchivos.FileName) Then
               If System.IO.File.ReadAllBytes(Me.ofdArchivos.FileName).Length > Reglas.Publicos.TamañoMaximoImagenes Then
                  MessageBox.Show("El tamaño de la imagen no puede ser mayor a " + (Reglas.Publicos.TamañoMaximoImagenes / 1000).ToString() + "KB", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
                  Exit Sub
               End If
               Me.pcbFoto2.Image = New System.Drawing.Bitmap(Me.ofdArchivos.FileName)
               ' DirectCast(Me._entidad, Entidades.Producto).ProductosWeb.Foto2 = Me.pcbFoto2.Image
            End If
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub btnLimpiarImagen2_Click(sender As Object, e As EventArgs) Handles btnLimpiarImagen2.Click
      Try
         DirectCast(Me._entidad, Entidades.Producto).ProductosWeb.Foto2 = Nothing
         Me.pcbFoto2.Image = Nothing
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub


   Private Sub btnBuscarImagen3_Click(sender As Object, e As EventArgs) Handles btnBuscarImagen3.Click
      Try
         If Me.ofdArchivos.ShowDialog() = Windows.Forms.DialogResult.OK Then
            If Not String.IsNullOrEmpty(Me.ofdArchivos.FileName) Then
               If System.IO.File.ReadAllBytes(Me.ofdArchivos.FileName).Length > Reglas.Publicos.TamañoMaximoImagenes Then
                  MessageBox.Show("El tamaño de la imagen no puede ser mayor a " + (Reglas.Publicos.TamañoMaximoImagenes / 1000).ToString() + "KB", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
                  Exit Sub
               End If
               Me.pcbFoto3.Image = New System.Drawing.Bitmap(Me.ofdArchivos.FileName)
               '  DirectCast(Me._entidad, Entidades.Producto).ProductosWeb.Foto3 = Me.pcbFoto3.Image
            End If
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub btnLimpiarImagen3_Click(sender As Object, e As EventArgs) Handles btnLimpiarImagen3.Click
      Try
         DirectCast(Me._entidad, Entidades.Producto).ProductosWeb.Foto3 = Nothing
         Me.pcbFoto3.Image = Nothing
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub bscCodigoSubRubro_Leave(sender As Object, e As EventArgs) Handles bscCodigoSubRubro.Leave
      Try
         If String.IsNullOrEmpty(Me.bscCodigoSubRubro.Text) Then
            Me.bscCodigoSubRubro.Text = "0"
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub
   Private Sub bscCodigoSubSubRubro_Leave(sender As Object, e As EventArgs) Handles bscCodigoSubSubRubro.Leave
      Try
         If String.IsNullOrEmpty(Me.bscCodigoSubSubRubro.Text) Then
            Me.bscCodigoSubSubRubro.Text = "0"
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub btnAjustarStock_Click(sender As Object, e As EventArgs) Handles btnAjustarStock.Click
      Try
         If Decimal.Parse(Me.txtAjusteStock.Text) = 0 Then Exit Sub

         If Me.chbLote.Checked Or Me.chbNroSerie.Checked Then
            Dim stb As StringBuilder = New StringBuilder("")

            With stb

               If Me.chbLote.Checked Then
                  .AppendFormatLine("").AppendLine()
                  .AppendFormatLine("    El Produto Utiliza Lote").AppendLine()
               End If
               If Me.chbNroSerie.Checked Then
                  .AppendFormatLine("").AppendLine()
                  .AppendFormatLine("    El Produto Utiliza Número de Serie").AppendLine()
               End If
            End With

            MessageBox.Show("No se permite ajustar producto con la siguiente condición: " & stb.ToString & "", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
         End If

         If MessageBox.Show("¿Desea generar un ajuste para el stock?", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.Yes Then
            Me.btnAjustarStock.Enabled = False
            Me.CargarAjusteStock()
            CargaValoresInicialesStock()
            MessageBox.Show("Se ajusto el stock.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.txtStockActual.Text = (Decimal.Parse(Me.txtStockActual.Text) + Decimal.Parse(Me.txtAjusteStock.Text)).ToString(_formatoEnPrecio)
            chbNroSerie.Enabled = False
            chbLote.Enabled = False
         End If

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      Finally
         Me.txtAjusteStock.Text = "0.000"
         Me.btnAjustarStock.Enabled = True
      End Try
   End Sub

   Private Sub VisualizaAjusteStock(visualiza As Boolean)
      btnAjustarStock.Enabled = visualiza
      lblMensajeAtributoProducto.Visible = Not visualiza
   End Sub
   Private Sub CargarAjusteStock()
      Dim oMovimientos = New Reglas.MovimientosStock()
      Dim oMov = New Entidades.MovimientoStock()
      Dim oCF As Entidades.CategoriaFiscal = Nothing

      With oMov
         .Sucursal = New Reglas.Sucursales().GetUna(actual.Sucursal.Id, False)

         .TipoMovimiento = New Reglas.TiposMovimientos().GetUno("AJUSTE")

         .FechaMovimiento = DateTime.Now

         .DescuentoRecargo = 0

         .Total = 0

         'If cmbEmpleado.SelectedIndex > -1 Then
         '   .Empleado = DirectCast(cmbEmpleado.SelectedItem, Entidades.Empleado)
         'End If

         .PercepcionIVA = 0
         .PercepcionIB = 0
         .PercepcionGanancias = 0
         .PercepcionVarias = 0

         .Comentarios = ""
         .Observacion = ""

         .Productos = Me.GetProductosStock()

         '.ProductosNrosSerie = Me._productosNrosSeries

         .Usuario = actual.Nombre

      End With

      oMovimientos.Insertar(oMov, dtExpensas:=Nothing, Entidades.Entidad.MetodoGrabacion.Manual, IdFuncion)
   End Sub

   Private Function GetProductosStock() As List(Of Entidades.MovimientoStockProducto)
      Dim oLineaDetalle = New Entidades.MovimientoStockProducto()
      With oLineaDetalle
         .IdProducto = Me.txtIdProducto.Text
         .NombreProducto = Me.txtNombreProducto.Text
         .DescuentoRecargo = 0
         .Precio = 0
         .Cantidad = Decimal.Parse(Me.txtAjusteStock.Text)
         .CantidadAfectada = Entidades.MovimientoStockProducto.Afecta.DISPONIBLE

         .ImporteTotal = 0
         .PorcentajeIVA = 0
         .IVA = 0
         .TotalProducto = .ImporteTotal
         If Me.txtStockActual.Text.Length <> 0 Then
            .Stock = Decimal.Parse(Me.txtStockActual.Text)
         Else
            .Stock = 0
         End If
         .IdSucursal = actual.Sucursal.Id
         .IdDeposito = Integer.Parse(cmbDepositoAjuste.SelectedValue.ToString())
         .IdUbicacion = Integer.Parse(cmbUbicacionAjuste.SelectedValue.ToString())
         .Usuario = actual.Nombre
         .IdLote = ""
         .VtoLote = Nothing

         .Orden = 1

      End With

      Dim mcp As List(Of Entidades.MovimientoStockProducto)
      mcp = New List(Of Entidades.MovimientoStockProducto)()

      mcp.Add(oLineaDetalle)

      Return mcp
   End Function


   Private Sub btnAgregarIdentificacion_Click(sender As Object, e As EventArgs) Handles btnAgregarIdentificacion.Click
      Try
         If Not String.IsNullOrWhiteSpace(txtIdentificacion.Text) Then
            If DirectCast(Me._entidad, Entidades.Producto).Identificaciones.Exists(Function(x) x.Identificacion = txtIdentificacion.Text) Then
               ShowMessage("La identificación ya fué agregada al producto")
               Exit Sub
            End If
            DirectCast(Me._entidad, Entidades.Producto).Identificaciones.Add(New Entidades.ProductoIdentificacion() _
                                                                             With {.Identificacion = txtIdentificacion.Text})
            ugIdentificaciones.Rows.Refresh(RefreshRow.ReloadData)
            txtIdentificacion.Text = String.Empty
         End If
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

   Private Sub btnEliminarIdentificacion_Click(sender As Object, e As EventArgs) Handles btnEliminarIdentificacion.Click
      Try
         Dim identif As Entidades.ProductoIdentificacion = GetIdentificacionSeleccionada()
         If identif IsNot Nothing Then
            If ShowPregunta(String.Format("¿Desea eliminar la identificación ´{0}´?", identif.Identificacion)) = Windows.Forms.DialogResult.Yes Then
               DirectCast(Me._entidad, Entidades.Producto).Identificaciones.Remove(identif)
               ugIdentificaciones.Rows.Refresh(RefreshRow.ReloadData)
            End If
         End If
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

   Private Sub ugIdentificaciones_DoubleClickRow(sender As Object, e As DoubleClickRowEventArgs) Handles ugIdentificaciones.DoubleClickRow
      Try
         Dim identif As Entidades.ProductoIdentificacion = GetIdentificacionSeleccionada()
         If identif IsNot Nothing Then
            txtIdentificacion.Text = identif.Identificacion
            DirectCast(Me._entidad, Entidades.Producto).Identificaciones.Remove(identif)
            ugIdentificaciones.Rows.Refresh(RefreshRow.ReloadData)
         End If
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

   Private Function GetIdentificacionSeleccionada() As Entidades.ProductoIdentificacion

      If ugIdentificaciones.ActiveRow IsNot Nothing AndAlso
         ugIdentificaciones.ActiveRow.ListObject IsNot Nothing AndAlso
         TypeOf (ugIdentificaciones.ActiveRow.ListObject) Is Entidades.ProductoIdentificacion Then
         Return DirectCast(ugIdentificaciones.ActiveRow.ListObject, Entidades.ProductoIdentificacion)
      End If

      Return Nothing
   End Function

   Private Sub btnInsertar_Click_1(sender As Object, e As EventArgs) Handles btnInsertar.Click
      Try
         If Me.ValidarInsertaOferta() Then
            Me.InsertarProductoOferta()
            RefrescarOfertas()
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub
   Private Sub InsertarProductoOferta()

      Dim entProductOferta As Entidades.ProductoOferta = New Entidades.ProductoOferta()
      With entProductOferta
         If btnRefrescarOfertas.Tag Is Nothing Then
            .IdOferta = If(DirectCast(Me._entidad, Entidades.Producto).ProductosOfertas.Count = 0, 0, DirectCast(Me._entidad, Entidades.Producto).ProductosOfertas.Max(Function(x) x.IdOferta)) + 1
         Else
            .IdOferta = DirectCast(btnRefrescarOfertas.Tag, Entidades.ProductoOferta).IdOferta
         End If
         .IdProducto = Me.txtIdProducto.Text
         If Decimal.Parse(Me.txtPrecioOferta.Text) > 0 Then
            .PrecioOferta = Decimal.Parse(Me.txtPrecioOferta.Text)
         End If
         If Decimal.Parse(Me.txtLimiteStock.Text) > 0 Then
            .LimiteStock = Decimal.Parse(Me.txtLimiteStock.Text)
         End If
         .CantidadConsumida = Decimal.Parse(Me.txtStockConsumido.Text)
         .FechaDesde = dtpFechaDesde.Value
         .FechaHasta = dtpFechaHasta.Value
         .Activa = Me.chbOfertaActiva.Checked
      End With
      Me._productosOfertas.Add(entProductOferta)
      Me.ugProductoOfertas.Rows.Refresh(RefreshRow.ReloadData)
      Me.dtpFechaDesde.Focus()
   End Sub

   Private Function GetProximoIdOferta() As Integer
      Dim producto As Entidades.Producto = DirectCast(Me._entidad, Entidades.Producto)
      If StateForm = Win.StateForm.Insertar Then
         Return If(producto.ProductosOfertas.Count = 0, 0, producto.ProductosOfertas.Max(Function(x) x.IdOferta)) + 1
      Else
         Return New Reglas.ProductosOfertas().GetCodigoMaximo(producto.IdProducto) + 1
      End If
   End Function

   Private Sub controlesOferta_KeyPress(sender As Object, e As KeyPressEventArgs) Handles btnInsertar.KeyPress, dtpFechaDesde.KeyPress, dtpFechaHasta.KeyPress, txtPrecioOferta.KeyPress, txtLimiteStock.KeyPress, chbOfertaActiva.KeyPress
      PresionarTab(e)
   End Sub
   Private Sub btnEliminar_Click(sender As Object, e As EventArgs) Handles btnEliminar.Click
      Try
         Dim entProductOferta As Entidades.ProductoOferta = GetProductoOferta()
         If entProductOferta IsNot Nothing Then
            If StateForm <> Win.StateForm.Insertar Then
               If New Reglas.ProductosOfertas().ExisteOfertaAplicada(entProductOferta.IdProducto, entProductOferta.IdOferta) Then
                  ShowMessage(String.Format("Ya se registró al menos una venta con la oferta del {0:dd/MM/yyyy} al {1:dd/MM/yyyy}. No es posible borrar la misma.", entProductOferta.FechaDesde, entProductOferta.FechaHasta))
                  Exit Sub
               End If
            End If

            If ShowPregunta(String.Format("¿Está seguro de borra la oferta del {0:dd/MM/yyyy} al {1:dd/MM/yyyy}?", entProductOferta.FechaDesde, entProductOferta.FechaHasta)) = Windows.Forms.DialogResult.Yes Then
               _productosOfertas.Remove(entProductOferta)
               Me.ugProductoOfertas.Rows.Refresh(UltraWinGrid.RefreshRow.ReloadData)
            End If
         Else
            ShowMessage("Debe seleccionar una oferta para poder borrar.")
         End If
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

   Private Function GetProductoOferta() As Entidades.ProductoOferta
      Return ugProductoOfertas.FilaSeleccionada(Of Entidades.ProductoOferta)()
   End Function
   Private Sub ugProductoOfertas_DoubleClickRow(sender As Object, e As DoubleClickRowEventArgs) Handles ugProductoOfertas.DoubleClickRow
      Try
         Dim row As Entidades.ProductoOferta = GetProductoOferta()
         If row IsNot Nothing Then
            If row.FechaHasta < Today.Date Then
               Throw New Exception("La Oferta que desea editar se encuentra vencida. No es posible editarla.")
            End If
            Me.dtpFechaDesde.Value = row.FechaDesde
            Me.dtpFechaHasta.Value = row.FechaHasta
            Me.txtPrecioOferta.Text = row.PrecioOferta.ToString()
            Me.txtLimiteStock.Text = row.LimiteStock.ToString()
            Me.txtStockConsumido.Text = row.CantidadConsumida.ToString()
            Me.chbOfertaActiva.Checked = row.Activa
            Me.btnRefrescarOfertas.Tag = row
            _productosOfertas.Remove(row)
            Me.ugProductoOfertas.Rows.Refresh(UltraWinGrid.RefreshRow.ReloadData)
            dtpFechaDesde.Focus()

            btnRefrescarOfertas.Enabled = False
            btnAceptar.Enabled = False

         End If
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub
   Private Function ValidarInsertaOferta() As Boolean
      If dtpFechaDesde.Value.Date > dtpFechaHasta.Value.Date Then
         MessageBox.Show("Rango de Fecha es invalido, la Fecha Desde es mayor a la Fecha Hasta", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
         Me.dtpFechaHasta.Focus()
         Return False
      End If
      If dtpFechaHasta.Value.Date < Today.Date Then
         MessageBox.Show("La Fecha Hasta debe ser mayor a hoy", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
         Me.dtpFechaHasta.Focus()
         Return False
      End If
      For Each oferta As Entidades.ProductoOferta In _productosOfertas
         If Entidades.Extensiones.DateTimeExtensions.CompraraRangoDeFechas(dtpFechaDesde.Value.Date, dtpFechaHasta.Value.Date, oferta.FechaDesde, oferta.FechaHasta) Then
            'If (oferta.FechaDesde >= dtpFechaDesde.Value.Date Or dtpFechaDesde.Value.Date <= oferta.FechaHasta) OrElse (oferta.FechaDesde >= dtpFechaHasta.Value.Date Or dtpFechaHasta.Value.Date <= oferta.FechaHasta) Then
            MessageBox.Show("Rango de Fecha esta comprometido con una oferta existente", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Me.dtpFechaHasta.Focus()
            Return False
         End If
      Next
      If Not IsNumeric(Me.txtLimiteStock.Text) Then txtLimiteStock.Text = "0"
      If Decimal.Parse(Me.txtLimiteStock.Text) <= 0 Then
         MessageBox.Show("El Limite de Stock debe ser mayor a cero.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
         Me.txtLimiteStock.Focus()
         Return False
      End If

      If Not IsNumeric(Me.txtPrecioOferta.Text) Then txtPrecioOferta.Text = "0"
      If Decimal.Parse(Me.txtPrecioOferta.Text) <= 0 Then
         MessageBox.Show("El Precio Oferta debe ser mayor a cero.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
         Me.txtPrecioOferta.Focus()
         Return False
      End If

      Return True
   End Function

   Private Sub btnRefrescarOfertas_Click(sender As Object, e As EventArgs) Handles btnRefrescarOfertas.Click
      Try
         RefrescarOfertas()
         dtpFechaDesde.Focus()
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub
   Private Sub RefrescarOfertas()
      Me.dtpFechaDesde.Value = Date.Today
      Me.dtpFechaHasta.Value = Date.Today

      Me.txtPrecioOferta.Text = _ceroFormatoEnPrecio
      Me.txtLimiteStock.Text = "0.00"
      Me.txtStockConsumido.Text = "0.00"

      Me.chbOfertaActiva.Checked = True
      Me.btnRefrescarOfertas.Tag = Nothing
      btnRefrescarOfertas.Enabled = True
      btnAceptar.Enabled = True
   End Sub

   Private Sub chbCategoriasMercadoLibre_CheckedChanged(sender As Object, e As EventArgs) Handles chbCategoriasMercadoLibre.CheckedChanged
      cmbCategoriasMercadoLibre.Enabled = chbCategoriasMercadoLibre.Checked
   End Sub

   Private Sub Bonificaciones_CheckedChanged(sender As Object, e As EventArgs) Handles rbBonificacionDescuento.CheckedChanged, rbBonificacionListaPrecio.CheckedChanged
      Try
         Me.ActivarBonificaciones(Me.rbBonificacionDescuento.Checked)
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

   Private Sub btnVerFormula_Click(sender As Object, e As EventArgs) Handles btnVerFormula.Click
      TryCatched(Sub() VerFormula())
   End Sub

   Private Sub VerFormula()
      Using frm = New FormulasABM()
         frm.MdiParent = MdiParent
         frm.IdFuncion = IdFuncion
         frm.bscCodigoProducto2.Text = txtIdProducto.Text
         frm.bscCodigoProducto2.PresionarBoton()
         frm.ShowDialog()
      End Using
   End Sub

   Private Sub lnkPublicarEn_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lnkPublicarEn.LinkClicked
      TryCatched(Sub() tbcDetalle.SelectedTab = tbpPublicarEn)
   End Sub

   Private Sub chbPublicarEn_CheckedChanged(sender As Object, e As EventArgs) Handles chbPublicarEnTiendaNube.CheckedChanged, chbPublicarEnMercadoLibre.CheckedChanged, chbPublicarEnArborea.CheckedChanged, chbPublicarListaDePreciosClientes.CheckedChanged, chbPublicarEnWeb.CheckedChanged, chbPublicarEnSincronizacionSucursal.CheckedChanged, chbPublicarEnGestion.CheckedChanged, chbPublicarEnEmpresarial.CheckedChanged, chbPublicarEnBalanza.CheckedChanged
      TryCatched(Sub() ActualizarLabelsPublicarEn())
   End Sub

   Private Sub ActualizarLabelsPublicarEn()
      Dim colorTrue = Color.LawnGreen
      Dim colorFalse = Color.Coral

      lblPublicarEnWeb.BackColor = If(chbPublicarEnWeb.Checked, colorTrue, colorFalse)
      lblPublicarEnTiendaNube.BackColor = If(chbPublicarEnTiendaNube.Checked, colorTrue, colorFalse)
      lblPublicarEnMercadoLibre.BackColor = If(chbPublicarEnMercadoLibre.Checked, colorTrue, colorFalse)
      lblPublicarEnArborea.BackColor = If(chbPublicarEnArborea.Checked, colorTrue, colorFalse)
      lblPublicarEnGestion.BackColor = If(chbPublicarEnGestion.Checked, colorTrue, colorFalse)
      lblPublicarEnEmpresarial.BackColor = If(chbPublicarEnEmpresarial.Checked, colorTrue, colorFalse)
      lblPublicarEnBalanza.BackColor = If(chbPublicarEnBalanza.Checked, colorTrue, colorFalse)
      lblPublicarEnSincronizacionSucursal.BackColor = If(chbPublicarEnSincronizacionSucursal.Checked, colorTrue, colorFalse)
      lblPublicarListaDePreciosClientes.BackColor = If(chbPublicarListaDePreciosClientes.Checked, colorTrue, colorFalse)

      'lblPublicarEnWeb.Visible = chbPublicarEnWeb.Checked

      'lblPublicarEnTiendaNube.Visible = chbPublicarEnTiendaNube.Checked
      'lblPublicarEnMercadoLibre.Visible = chbPublicarEnMercadoLibre.Checked
      'lblPublicarEnArborea.Visible = chbPublicarEnArborea.Checked

      'lblPublicarEnGestion.Visible = chbPublicarEnGestion.Checked
      'lblPublicarEnEmpresarial.Visible = chbPublicarEnEmpresarial.Checked

      'lblPublicarEnBalanza.Visible = chbPublicarEnBalanza.Checked
      'lblPublicarEnSincronizacionSucursal.Visible = chbPublicarEnSincronizacionSucursal.Checked
      'lblPublicarListaDePreciosClientes.Visible = chbPublicarListaDePreciosClientes.Checked
   End Sub

   Private Sub cmbDepositoOrigen_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbDepositoOrigen.SelectedIndexChanged
      Dim vDepo = If(cmbDepositoOrigen.SelectedValue Is Nothing, 1, Integer.Parse(cmbDepositoOrigen.SelectedValue.ToString()))
      _publicos.CargaComboUbicaciones(cmbUbicacionOrigen, vDepo, actual.Sucursal.IdSucursal)
   End Sub
   Private Sub cmbDepositoAjuste_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbDepositoAjuste.SelectedIndexChanged
      Dim vDepo = If(cmbDepositoAjuste.SelectedValue Is Nothing, 1, Integer.Parse(cmbDepositoAjuste.SelectedValue.ToString()))
      _publicos.CargaComboUbicaciones(cmbUbicacionAjuste, vDepo, actual.Sucursal.IdSucursal)
   End Sub

   Private Sub cmbUbicacionAjuste_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbUbicacionAjuste.SelectedIndexChanged
      Me.tbcDetalle.SelectedTab = tbpStock
      RecalculaStock()
   End Sub

   Private Sub RecalculaStock()
      Dim dt = New Reglas.ProductosUbicaciones().GetSucursalDepositoProducto(actual.Sucursal.IdSucursal,
                                                                             Integer.Parse(cmbDepositoAjuste.SelectedValue.ToString()),
                                                                             Integer.Parse(cmbUbicacionAjuste.SelectedValue.ToString()),
                                                                             txtIdProducto.Text)
      If dt.Count > 0 Then
         DirectCast(Me._entidad, Entidades.Producto).StockActual = dt.Rows(0).Field(Of Decimal)("Stock")
         txtStockActual.Text = dt.Rows(0).Field(Of Decimal)("Stock").ToString("N4")
      Else
         txtStockActual.Text = "0.0000"
      End If
   End Sub

   Private Sub ugStockDepositos_ClickCell(sender As Object, e As ClickCellEventArgs) Handles ugStockDepositos.ClickCell
      Dim dt = ugStockDepositos.FilaSeleccionada(Of DataRow)(e.Cell.Row)
      cmbDepositoAjuste.SelectedValue = dt.Field(Of Integer)("IdDeposito")
      cmbUbicacionAjuste.SelectedValue = dt.Field(Of Integer)("IdUbicacion")
   End Sub
   Private Sub CargaValoresInicialesStock()
      ugStockDepositos.DataSource = New Reglas.Productos().GetProductosDepositos(DirectCast(Me._entidad, Entidades.Producto).IdProducto, 0)
      ugStockDepositos.AgregarTotalesSuma({"Stock"})
   End Sub

   Private Sub chbNroSerie_CheckedChanged(sender As Object, e As EventArgs) Handles chbNroSerie.CheckedChanged
      btnAjustarStock.Enabled = False
      txtAjusteStock.Text = "0.000"
      txtAjusteStock.Enabled = False
   End Sub

   Private Sub btnExaminar_Click(sender As Object, e As EventArgs) Handles btnExaminar.Click
      DialogoAbrirArchivo.InitialDirectory = My.Computer.FileSystem.SpecialDirectories.Desktop

      If DialogoAbrirArchivo.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
         Try
            Dim fileInfo = New IO.FileInfo(DialogoAbrirArchivo.FileName)
            If fileInfo.Exists Then
               txtLinkAdjunto.Text = DialogoAbrirArchivo.FileName
               txtLinkAdjunto.Focus()
            Else
               ShowMessage(String.Format("No se puede acceder al archivo '{0}'.", DialogoAbrirArchivo.FileName))
            End If
         Catch Ex As Exception
            ShowMessage(String.Format("ATENCION: No se puede leer el Archivo. Error: {0}", Ex.Message))
         End Try
      End If

   End Sub

   Private Sub btnInsertarAdjunto_Click(sender As Object, e As EventArgs) Handles btnInsertarAdjunto.Click
      Try
         If ValidarAdjuntos() Then
            InsertarAdjuntos()
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub btnBorrarAdjunto_Click(sender As Object, e As EventArgs) Handles btnBorrarAdjunto.Click
      Try
         Dim eProdLink = GetProductoLinks()
         If eProdLink IsNot Nothing Then
            If StateForm <> Win.StateForm.Insertar Then
               If New Reglas.MRPProcesosProductivos().ExisteAdjunto(eProdLink.IdProducto, eProdLink.ItemLink) Then
                  ShowMessage("Ya se registró al menos un Proceso Productivo con el Adjunto seleccionado. No es posible borrar el mismo.")
                  Exit Sub
               Else
                  Try
                     Dim adjunto = GetProductoLinks()
                     If adjunto IsNot Nothing Then
                        If ShowPregunta("¿Desea eliminar el adjunto seleccionado?") = Windows.Forms.DialogResult.Yes Then
                           ProductoE.ArchivosAdjuntos.Remove(adjunto)
                           ugAdjunto.Rows.Refresh(RefreshRow.ReloadData)
                        End If
                        btnLimpiarAdjuntos.PerformClick()
                     End If
                  Catch ex As Exception
                     ShowError(ex)
                  End Try
               End If
            End If
         Else
            ShowMessage("Debe seleccionar un Adjunto para poder borrar.")
         End If
      Catch ex As Exception
         ShowError(ex)
      End Try

   End Sub

   Private Function ValidarAdjuntos() As Boolean
      If String.IsNullOrEmpty(txtDescripcionAdjuntos.Text) Then
         MessageBox.Show("Debe ingresar una descripción", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
         Me.txtDescripcionAdjuntos.Focus()
         Return False
      End If
      If String.IsNullOrEmpty(txtLinkAdjunto.Text) Then
         MessageBox.Show("Debe ingresar una dirección de Archivo", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
         Me.txtLinkAdjunto.Focus()
         Return False
      End If

      Return True
   End Function

   Private Sub btnLimpiarAdjuntos_Click(sender As Object, e As EventArgs) Handles btnLimpiarAdjuntos.Click
      cmbTipoAdjunto.SelectedIndex = 0
      txtDescripcionAdjuntos.Text = String.Empty
      txtLinkAdjunto.Text = String.Empty
      txtDescripcionAdjuntos.Select()
   End Sub
   Private Sub InsertarAdjuntos()

      Dim eProdLink = New Entidades.ProductoLinks()
      With eProdLink
         .IdProducto = txtIdProducto.Text
         .Descripcion = txtDescripcionAdjuntos.Text
         .ItemLink = 0
         .Link = txtLinkAdjunto.Text
         .IdTipoAdjunto = Integer.Parse(cmbTipoAdjunto.SelectedValue.ToString())
         .NombreTipoAdjunto = cmbTipoAdjunto.Text
      End With
      ProductoE.ArchivosAdjuntos.Add(eProdLink)
      Me.ugAdjunto.Rows.Refresh(RefreshRow.ReloadData)
      btnLimpiarAdjuntos.PerformClick()
   End Sub

   Private Function GetProductoLinks() As Entidades.ProductoLinks
      Return ugAdjunto.FilaSeleccionada(Of Entidades.ProductoLinks)()
   End Function

   Private Sub chbRealizaCCCompras_CheckedChanged(sender As Object, e As EventArgs) Handles chbRealizaCCCompras.CheckedChanged
      cmbNivelInspeccion.Enabled = chbRealizaCCCompras.Checked
      If Not chbRealizaCCCompras.Checked Then
         cmbNivelInspeccion.SelectedIndex = -1
      End If
   End Sub

   Private Sub btnAgregarCalidadProductos_Click(sender As Object, e As EventArgs) Handles btnAgregarCalidadProductos.Click
      If ugCalidad.Selected.Rows.Count = 0 AndAlso ugCalidad.ActiveRow IsNot Nothing Then ugCalidad.ActiveRow.Selected = True
      For Each dg In ugCalidad.Selected.Rows.OfType(Of UltraGridRow)
         Dim dr = dg.FilaSeleccionada(Of DataRow)()
         If dr IsNot Nothing Then
            Dim idControl = dr.Field(Of Integer)("IdListaControl")
            Dim CalidadProducto = _calidadProductos.FirstOrDefault(Function(drU) drU.IdListaControl = idControl)
            If CalidadProducto Is Nothing Then
               CalidadProducto = New Entidades.CalidadListaControlProducto()
               With CalidadProducto
                  .IdListaControl = dr.Field(Of Integer)("IdListaControl")
                  .NombreListaControl = dr.Field(Of String)("NombreListaControl")
               End With
               _calidadProductos.Add(CalidadProducto)
            End If
         End If
      Next
      ugCalidadProductos.Rows.Refresh(RefreshRow.FireInitializeRow)
   End Sub

   Private Sub btnQuitarCalidadProductos_Click(sender As Object, e As EventArgs) Handles btnQuitarCalidadProductos.Click
      TryCatched(
      Sub()
         If ugCalidadProductos.Selected.Rows.Count = 0 AndAlso ugCalidadProductos.ActiveRow IsNot Nothing Then ugCalidadProductos.ActiveRow.Selected = True
         Dim eProdCalid = ugCalidadProductos.FilaSeleccionada(Of Entidades.CalidadListaControlProducto)()
         If eProdCalid IsNot Nothing Then
            ProductoE.CalidadListaProductos.Remove(eProdCalid)
         End If
         ugCalidadProductos.Rows.Refresh(RefreshRow.FireInitializeRow)
      End Sub)
   End Sub

   Private Sub txtComision_Leave(sender As Object, e As EventArgs) Handles txtComision.Leave
      If IsNumeric(txtComision.Text.ToString()) Then
         If Decimal.Parse(txtComision.Text.ToString()) < 0 Then
            MessageBox.Show("La comision debe ser mayor que 0.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Me.txtComision.Focus()
         End If

      End If
   End Sub

   Private Sub cmbUnidadDeMedida_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbUnidadDeMedida.SelectedIndexChanged
      Try

      Catch ex As Exception

      End Try
   End Sub


End Class