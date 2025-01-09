<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ConcesionarioOperacionesDetalle
   Inherits BaseDetalle

   'Form overrides dispose to clean up the component list.
   <System.Diagnostics.DebuggerNonUserCode()> _
   Protected Overrides Sub Dispose(ByVal disposing As Boolean)
      Try
         If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
         End If
      Finally
         MyBase.Dispose(disposing)
      End Try
   End Sub

   'Required by the Windows Form Designer
   Private components As System.ComponentModel.IContainer

   'NOTE: The following procedure is required by the Windows Form Designer
   'It can be modified using the Windows Form Designer.  
   'Do not modify it using the code editor.
   <System.Diagnostics.DebuggerStepThrough()> _
   Private Sub InitializeComponent()
      Dim Appearance1 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridBand1 As Infragistics.Win.UltraWinGrid.UltraGridBand = New Infragistics.Win.UltraWinGrid.UltraGridBand("Band 0", -1)
        Dim UltraGridColumn1 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("PatenteVehiculo")
        Dim UltraGridColumn2 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdMarcaVehiculo")
        Dim UltraGridColumn3 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("DescripMarcaVehiculo")
        Dim UltraGridColumn4 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdModeloVehiculo")
        Dim UltraGridColumn5 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("DescripModeloVehiculo")
        Dim UltraGridColumn6 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Color")
        Dim UltraGridColumn7 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("VencimientoSeguro")
        Dim UltraGridColumn8 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Ruta")
        Dim UltraGridColumn9 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Vtv")
        Dim UltraGridColumn10 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Activo")
        Dim UltraGridColumn11 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("EstaAdentro")
        Dim UltraGridColumn23 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("TipoUnidad")
        Dim UltraGridColumn13 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("SubTipoUnidad")
        Dim UltraGridColumn14 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("AnioPatentamiento")
        Dim Appearance2 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn15 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("MedidasVehiculo")
        Dim UltraGridColumn16 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("LlantasVehiculo")
        Dim UltraGridColumn17 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("AuxilioVehiculo")
        Dim UltraGridColumn18 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NeumaticosVehiculo")
        Dim UltraGridColumn19 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("OtrosVehiculo")
        Dim UltraGridColumn20 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdentificacionVehiculo")
        Dim UltraGridColumn21 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("ObservacionesVehiculo")
        Dim UltraGridColumn22 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("EstadoVehiculo")
        Dim UltraGridColumn12 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreTipoUnidad")
        Dim UltraGridColumn25 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreEstadoVehiculo")
        Dim UltraGridColumn24 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("PrecioCompra")
        Dim Appearance3 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn26 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdProductoReferencia")
        Dim UltraGridColumn27 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreProductoReferencia")
        Dim UltraGridColumn28 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("PrecioReferencia")
        Dim UltraGridColumn29 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("PrecioVenta")
        Dim Appearance4 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn30 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("PrecioLista")
        Dim Appearance5 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn31 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("HasValue")
        Dim UltraGridColumn32 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Usuario")
        Dim UltraGridColumn33 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Password")
        Dim UltraGridColumn34 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdSucursal")
        Dim UltraGridColumn35 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdMarcaOperacionIngreso")
        Dim UltraGridColumn36 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("AnioOperacionIngreso")
        Dim UltraGridColumn37 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NumeroOperacionIngreso")
        Dim UltraGridColumn38 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("SecuenciaOperacionIngreso")
        Dim UltraGridColumn39 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("CodigoOperacionIngreso")
        Dim Appearance6 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance7 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance8 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance9 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance10 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance11 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance12 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance13 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance14 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance15 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance16 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Me.lblMarcaVehiculo = New Eniac.Controles.Label()
        Me.dtpFechaOperacion = New Eniac.Controles.DateTimePicker()
        Me.lblFecha = New Eniac.Controles.Label()
        Me.lblNumeroOperacion = New Eniac.Controles.Label()
        Me.txtNumeroOperacion = New Eniac.Controles.TextBox()
        Me.txtSecuenciaOperacion = New Eniac.Controles.TextBox()
        Me.bscCliente = New Eniac.Controles.Buscador2()
        Me.lblNombre = New Eniac.Controles.Label()
        Me.lblCliente = New Eniac.Controles.Label()
        Me.llbCliente = New Eniac.Controles.LinkLabel()
        Me.bscCodigoCliente = New Eniac.Controles.Buscador2()
        Me.lblCodigoCliente = New Eniac.Controles.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.btnFacturar = New System.Windows.Forms.Button()
        Me.btnGenerarRecibo = New System.Windows.Forms.Button()
        Me.lblAnioOperacion = New Eniac.Controles.Label()
        Me.pnlTipoOperacion = New System.Windows.Forms.FlowLayoutPanel()
        Me.radCeroKm = New System.Windows.Forms.RadioButton()
        Me.radUsado = New System.Windows.Forms.RadioButton()
        Me.txtAnioOperacion = New Eniac.Controles.TextBox()
        Me.txtCotizacionDolar = New Eniac.Controles.TextBox()
        Me.lblCotizacionDolar = New Eniac.Controles.Label()
        Me.txtTelefonos = New Eniac.Controles.TextBox()
        Me.lblTelefonos = New Eniac.Controles.Label()
        Me.lblCategoriaFiscal = New Eniac.Controles.Label()
        Me.lblCUIT = New Eniac.Controles.Label()
        Me.cmbCategoriaFiscal = New Eniac.Controles.ComboBox()
        Me.txtCUITCliente = New Eniac.Controles.TextBox()
        Me.cmbTipoDocCliente = New Eniac.Controles.ComboBox()
        Me.cmbMarca = New Eniac.Controles.ComboBox()
        Me.lblNroDocCliente = New Eniac.Controles.Label()
        Me.lblTipoDocCliente = New Eniac.Controles.Label()
        Me.txtNroDocCliente = New Eniac.Controles.TextBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.txtTotalGeneral = New Eniac.Controles.TextBox()
        Me.btnCaracteristicas = New System.Windows.Forms.Button()
        Me.txtImporteTotalCaracteristicas = New Eniac.Controles.TextBox()
        Me.lblPrecio = New Eniac.Controles.Label()
        Me.lblTotalGeneral = New Eniac.Controles.Label()
        Me.btnAdicionales = New System.Windows.Forms.Button()
        Me.txtImporteTotalAdicionales = New Eniac.Controles.TextBox()
        Me.tbcUnidadVendida = New System.Windows.Forms.TabControl()
        Me.tbp0Km = New System.Windows.Forms.TabPage()
        Me.llbTotalProducto = New Eniac.Controles.Label()
        Me.txtTotalProducto = New Eniac.Controles.TextBox()
        Me.txtPrecioProducto = New Eniac.Controles.TextBox()
        Me.lblCantidad = New Eniac.Controles.Label()
        Me.lblProducto = New Eniac.Controles.Label()
        Me.txtCantidadProducto = New Eniac.Controles.TextBox()
        Me.bscProducto2 = New Eniac.Controles.Buscador2()
        Me.bscCodigoProducto2 = New Eniac.Controles.Buscador2()
        Me.lblCodProducto = New Eniac.Controles.Label()
        Me.lnkProducto = New System.Windows.Forms.LinkLabel()
        Me.lblNombreProducto = New Eniac.Controles.Label()
        Me.tbpUsado = New System.Windows.Forms.TabPage()
        Me.txtMaximoActualizadoUsado = New Eniac.Controles.TextBox()
        Me.lblPrecioListaUsado = New Eniac.Controles.Label()
        Me.txtMinimoActualizadoUsado = New Eniac.Controles.TextBox()
        Me.pnlColorPrecioLista = New System.Windows.Forms.Panel()
        Me.lblModeloUsado = New Eniac.Controles.Label()
        Me.lblMarcaUsado = New Eniac.Controles.Label()
        Me.txtModeloUsado = New Eniac.Controles.TextBox()
        Me.txtMarcaUsado = New Eniac.Controles.TextBox()
        Me.txtPrecioListaUsado = New Eniac.Controles.TextBox()
        Me.txtPrecioVentaUsado = New Eniac.Controles.TextBox()
        Me.lblPrecioVentaUsado = New Eniac.Controles.Label()
        Me.Label1 = New Eniac.Controles.Label()
        Me.bscCodigoVehiculoUsado = New Eniac.Controles.Buscador2()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.lblUsados = New Eniac.Controles.Label()
        Me.txtUsados = New Eniac.Controles.TextBox()
        Me.bscCodigoCuentaBancariaTransfBanc = New Eniac.Controles.Buscador2()
        Me.lblCuentaBancaria = New Eniac.Controles.Label()
        Me.lblFechaTransferenciaBancaria = New Eniac.Controles.Label()
        Me.dtpFechaTransferencia = New Eniac.Controles.DateTimePicker()
        Me.txtEfectivo = New Eniac.Controles.TextBox()
        Me.lblEfectivo = New Eniac.Controles.Label()
        Me.tbcPagosTarChe = New System.Windows.Forms.TabControl()
        Me.tbpVehiculosUsados = New System.Windows.Forms.TabPage()
        Me.ugVehiculosUsados = New Infragistics.Win.UltraWinGrid.UltraGrid()
        Me.FlowLayoutPanel1 = New System.Windows.Forms.FlowLayoutPanel()
        Me.btnInsertarVehiculosUsados = New Eniac.Controles.Button()
        Me.btnEliminarVehiculosUsados = New Eniac.Controles.Button()
        Me.btnAgregarVehiculoUsado = New Eniac.Controles.Button()
        Me.bscCodigoVehiculo = New Eniac.Controles.Buscador2()
        Me.tbpPagosCheques = New System.Windows.Forms.TabPage()
        Me.UcMedioPagoChequesTerceros1 = New Eniac.Win.ucMedioPagoChequesTerceros()
        Me.tbpPagosTarjetas = New System.Windows.Forms.TabPage()
        Me.UcMedioPagoTarjeta1 = New Eniac.Win.ucMedioPagoTarjeta()
        Me.bscCuentaBancariaTransfBanc = New Eniac.Controles.Buscador2()
        Me.txtTarjetas = New Eniac.Controles.TextBox()
        Me.lblTarjetas = New Eniac.Controles.Label()
        Me.lblCheques = New Eniac.Controles.Label()
        Me.lblTransferenciaBancaria = New Eniac.Controles.Label()
        Me.txtCheques = New Eniac.Controles.TextBox()
        Me.txtDiferencia = New Eniac.Controles.TextBox()
        Me.lblDiferencia = New Eniac.Controles.Label()
        Me.txtTransferenciaBancaria = New Eniac.Controles.TextBox()
        Me.lblTotalPago = New Eniac.Controles.Label()
        Me.txtTotalPago = New Eniac.Controles.TextBox()
        Me.btnEditarVehiculosUsados = New Eniac.Controles.Button()
        Me.GroupBox1.SuspendLayout()
        Me.pnlTipoOperacion.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.tbcUnidadVendida.SuspendLayout()
        Me.tbp0Km.SuspendLayout()
        Me.tbpUsado.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.tbcPagosTarChe.SuspendLayout()
        Me.tbpVehiculosUsados.SuspendLayout()
        CType(Me.ugVehiculosUsados, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.FlowLayoutPanel1.SuspendLayout()
        Me.tbpPagosCheques.SuspendLayout()
        Me.tbpPagosTarjetas.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnAceptar
        '
        Me.btnAceptar.Location = New System.Drawing.Point(795, 521)
        Me.btnAceptar.Size = New System.Drawing.Size(96, 30)
        Me.btnAceptar.Text = "&Aceptar (F4)"
        '
        'btnCancelar
        '
        Me.btnCancelar.Location = New System.Drawing.Point(897, 521)
        Me.btnCancelar.TabIndex = 4
        '
        'btnCopiar
        '
        Me.btnCopiar.Location = New System.Drawing.Point(694, 521)
        Me.btnCopiar.TabIndex = 6
        '
        'btnAplicar
        '
        Me.btnAplicar.Location = New System.Drawing.Point(637, 521)
        Me.btnAplicar.TabIndex = 5
        '
        'lblMarcaVehiculo
        '
        Me.lblMarcaVehiculo.AutoSize = True
        Me.lblMarcaVehiculo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.lblMarcaVehiculo.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblMarcaVehiculo.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblMarcaVehiculo.LabelAsoc = Nothing
        Me.lblMarcaVehiculo.Location = New System.Drawing.Point(145, 14)
        Me.lblMarcaVehiculo.Name = "lblMarcaVehiculo"
        Me.lblMarcaVehiculo.Size = New System.Drawing.Size(37, 13)
        Me.lblMarcaVehiculo.TabIndex = 1
        Me.lblMarcaVehiculo.Text = "Marca"
        '
        'dtpFechaOperacion
        '
        Me.dtpFechaOperacion.BindearPropiedadControl = "Value"
        Me.dtpFechaOperacion.BindearPropiedadEntidad = "FechaOperacion"
        Me.dtpFechaOperacion.CustomFormat = "dd/MM/yyyy"
        Me.dtpFechaOperacion.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.dtpFechaOperacion.ForeColorFocus = System.Drawing.Color.Red
        Me.dtpFechaOperacion.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.dtpFechaOperacion.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpFechaOperacion.IsPK = False
        Me.dtpFechaOperacion.IsRequired = False
        Me.dtpFechaOperacion.Key = ""
        Me.dtpFechaOperacion.LabelAsoc = Me.lblFecha
        Me.dtpFechaOperacion.Location = New System.Drawing.Point(452, 30)
        Me.dtpFechaOperacion.Name = "dtpFechaOperacion"
        Me.dtpFechaOperacion.Size = New System.Drawing.Size(82, 20)
        Me.dtpFechaOperacion.TabIndex = 9
        '
        'lblFecha
        '
        Me.lblFecha.AutoSize = True
        Me.lblFecha.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblFecha.LabelAsoc = Nothing
        Me.lblFecha.Location = New System.Drawing.Point(448, 14)
        Me.lblFecha.Name = "lblFecha"
        Me.lblFecha.Size = New System.Drawing.Size(37, 13)
        Me.lblFecha.TabIndex = 8
        Me.lblFecha.Text = "&Fecha"
        '
        'lblNumeroOperacion
        '
        Me.lblNumeroOperacion.AutoSize = True
        Me.lblNumeroOperacion.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblNumeroOperacion.LabelAsoc = Nothing
        Me.lblNumeroOperacion.Location = New System.Drawing.Point(324, 14)
        Me.lblNumeroOperacion.Name = "lblNumeroOperacion"
        Me.lblNumeroOperacion.Size = New System.Drawing.Size(44, 13)
        Me.lblNumeroOperacion.TabIndex = 5
        Me.lblNumeroOperacion.Text = "Número"
        '
        'txtNumeroOperacion
        '
        Me.txtNumeroOperacion.BindearPropiedadControl = Nothing
        Me.txtNumeroOperacion.BindearPropiedadEntidad = Nothing
        Me.txtNumeroOperacion.ForeColorFocus = System.Drawing.Color.Red
        Me.txtNumeroOperacion.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtNumeroOperacion.Formato = ""
        Me.txtNumeroOperacion.IsDecimal = False
        Me.txtNumeroOperacion.IsNumber = True
        Me.txtNumeroOperacion.IsPK = False
        Me.txtNumeroOperacion.IsRequired = False
        Me.txtNumeroOperacion.Key = ""
        Me.txtNumeroOperacion.LabelAsoc = Me.lblNumeroOperacion
        Me.txtNumeroOperacion.Location = New System.Drawing.Point(327, 30)
        Me.txtNumeroOperacion.MaxLength = 8
        Me.txtNumeroOperacion.Name = "txtNumeroOperacion"
        Me.txtNumeroOperacion.ReadOnly = True
        Me.txtNumeroOperacion.Size = New System.Drawing.Size(81, 20)
        Me.txtNumeroOperacion.TabIndex = 6
        Me.txtNumeroOperacion.Text = "0"
        Me.txtNumeroOperacion.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtSecuenciaOperacion
        '
        Me.txtSecuenciaOperacion.BindearPropiedadControl = Nothing
        Me.txtSecuenciaOperacion.BindearPropiedadEntidad = Nothing
        Me.txtSecuenciaOperacion.ForeColorFocus = System.Drawing.Color.Red
        Me.txtSecuenciaOperacion.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtSecuenciaOperacion.Formato = ""
        Me.txtSecuenciaOperacion.IsDecimal = False
        Me.txtSecuenciaOperacion.IsNumber = True
        Me.txtSecuenciaOperacion.IsPK = False
        Me.txtSecuenciaOperacion.IsRequired = False
        Me.txtSecuenciaOperacion.Key = ""
        Me.txtSecuenciaOperacion.LabelAsoc = Nothing
        Me.txtSecuenciaOperacion.Location = New System.Drawing.Point(414, 30)
        Me.txtSecuenciaOperacion.MaxLength = 8
        Me.txtSecuenciaOperacion.Name = "txtSecuenciaOperacion"
        Me.txtSecuenciaOperacion.ReadOnly = True
        Me.txtSecuenciaOperacion.Size = New System.Drawing.Size(32, 20)
        Me.txtSecuenciaOperacion.TabIndex = 7
        Me.txtSecuenciaOperacion.Text = "0"
        Me.txtSecuenciaOperacion.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'bscCliente
        '
        Me.bscCliente.ActivarFiltroEnGrilla = True
        Me.bscCliente.BindearPropiedadControl = Nothing
        Me.bscCliente.BindearPropiedadEntidad = Nothing
        Me.bscCliente.ConfigBuscador = Nothing
        Me.bscCliente.Datos = Nothing
        Me.bscCliente.FilaDevuelta = Nothing
        Me.bscCliente.ForeColorFocus = System.Drawing.Color.Red
        Me.bscCliente.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.bscCliente.IsDecimal = False
        Me.bscCliente.IsNumber = False
        Me.bscCliente.IsPK = False
        Me.bscCliente.IsRequired = False
        Me.bscCliente.Key = ""
        Me.bscCliente.LabelAsoc = Me.lblNombre
        Me.bscCliente.Location = New System.Drawing.Point(148, 67)
        Me.bscCliente.MaxLengh = "32767"
        Me.bscCliente.Name = "bscCliente"
        Me.bscCliente.Permitido = True
        Me.bscCliente.PermitidoNoBackColor = System.Drawing.Color.FromArgb(CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer))
        Me.bscCliente.PermitidoNoForeColor = System.Drawing.Color.Black
        Me.bscCliente.PermitidoSiBackColor = System.Drawing.Color.White
        Me.bscCliente.PermitidoSiForeColor = System.Drawing.Color.Black
        Me.bscCliente.Selecciono = False
        Me.bscCliente.Size = New System.Drawing.Size(300, 20)
        Me.bscCliente.TabIndex = 16
        '
        'lblNombre
        '
        Me.lblNombre.AutoSize = True
        Me.lblNombre.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblNombre.LabelAsoc = Me.lblCliente
        Me.lblNombre.Location = New System.Drawing.Point(145, 53)
        Me.lblNombre.Name = "lblNombre"
        Me.lblNombre.Size = New System.Drawing.Size(44, 13)
        Me.lblNombre.TabIndex = 15
        Me.lblNombre.Text = "&Nombre"
        '
        'lblCliente
        '
        Me.lblCliente.AutoSize = True
        Me.lblCliente.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.lblCliente.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblCliente.LabelAsoc = Nothing
        Me.lblCliente.Location = New System.Drawing.Point(11, 71)
        Me.lblCliente.Name = "lblCliente"
        Me.lblCliente.Size = New System.Drawing.Size(39, 13)
        Me.lblCliente.TabIndex = 12
        Me.lblCliente.Text = "Cliente"
        '
        'llbCliente
        '
        Me.llbCliente.AutoSize = True
        Me.llbCliente.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.llbCliente.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline
        Me.llbCliente.Location = New System.Drawing.Point(195, 53)
        Me.llbCliente.Name = "llbCliente"
        Me.llbCliente.Size = New System.Drawing.Size(55, 13)
        Me.llbCliente.TabIndex = 17
        Me.llbCliente.TabStop = True
        Me.llbCliente.Text = "más info..."
        '
        'bscCodigoCliente
        '
        Me.bscCodigoCliente.ActivarFiltroEnGrilla = True
        Me.bscCodigoCliente.BindearPropiedadControl = Nothing
        Me.bscCodigoCliente.BindearPropiedadEntidad = Nothing
        Me.bscCodigoCliente.ConfigBuscador = Nothing
        Me.bscCodigoCliente.Datos = Nothing
        Me.bscCodigoCliente.FilaDevuelta = Nothing
        Me.bscCodigoCliente.ForeColorFocus = System.Drawing.Color.Red
        Me.bscCodigoCliente.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.bscCodigoCliente.IsDecimal = False
        Me.bscCodigoCliente.IsNumber = False
        Me.bscCodigoCliente.IsPK = False
        Me.bscCodigoCliente.IsRequired = False
        Me.bscCodigoCliente.Key = ""
        Me.bscCodigoCliente.LabelAsoc = Me.lblCodigoCliente
        Me.bscCodigoCliente.Location = New System.Drawing.Point(54, 67)
        Me.bscCodigoCliente.MaxLengh = "32767"
        Me.bscCodigoCliente.Name = "bscCodigoCliente"
        Me.bscCodigoCliente.Permitido = True
        Me.bscCodigoCliente.PermitidoNoBackColor = System.Drawing.Color.FromArgb(CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer))
        Me.bscCodigoCliente.PermitidoNoForeColor = System.Drawing.Color.Black
        Me.bscCodigoCliente.PermitidoSiBackColor = System.Drawing.Color.White
        Me.bscCodigoCliente.PermitidoSiForeColor = System.Drawing.Color.Black
        Me.bscCodigoCliente.Selecciono = False
        Me.bscCodigoCliente.Size = New System.Drawing.Size(87, 20)
        Me.bscCodigoCliente.TabIndex = 14
        '
        'lblCodigoCliente
        '
        Me.lblCodigoCliente.AutoSize = True
        Me.lblCodigoCliente.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblCodigoCliente.LabelAsoc = Me.lblCliente
        Me.lblCodigoCliente.Location = New System.Drawing.Point(54, 53)
        Me.lblCodigoCliente.Name = "lblCodigoCliente"
        Me.lblCodigoCliente.Size = New System.Drawing.Size(40, 13)
        Me.lblCodigoCliente.TabIndex = 13
        Me.lblCodigoCliente.Text = "Código"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.btnFacturar)
        Me.GroupBox1.Controls.Add(Me.btnGenerarRecibo)
        Me.GroupBox1.Controls.Add(Me.lblAnioOperacion)
        Me.GroupBox1.Controls.Add(Me.pnlTipoOperacion)
        Me.GroupBox1.Controls.Add(Me.txtAnioOperacion)
        Me.GroupBox1.Controls.Add(Me.txtCotizacionDolar)
        Me.GroupBox1.Controls.Add(Me.txtTelefonos)
        Me.GroupBox1.Controls.Add(Me.lblCotizacionDolar)
        Me.GroupBox1.Controls.Add(Me.lblTelefonos)
        Me.GroupBox1.Controls.Add(Me.lblCategoriaFiscal)
        Me.GroupBox1.Controls.Add(Me.lblCUIT)
        Me.GroupBox1.Controls.Add(Me.cmbCategoriaFiscal)
        Me.GroupBox1.Controls.Add(Me.txtCUITCliente)
        Me.GroupBox1.Controls.Add(Me.cmbTipoDocCliente)
        Me.GroupBox1.Controls.Add(Me.cmbMarca)
        Me.GroupBox1.Controls.Add(Me.lblCliente)
        Me.GroupBox1.Controls.Add(Me.lblNroDocCliente)
        Me.GroupBox1.Controls.Add(Me.lblMarcaVehiculo)
        Me.GroupBox1.Controls.Add(Me.bscCliente)
        Me.GroupBox1.Controls.Add(Me.lblFecha)
        Me.GroupBox1.Controls.Add(Me.llbCliente)
        Me.GroupBox1.Controls.Add(Me.lblTipoDocCliente)
        Me.GroupBox1.Controls.Add(Me.txtNroDocCliente)
        Me.GroupBox1.Controls.Add(Me.dtpFechaOperacion)
        Me.GroupBox1.Controls.Add(Me.bscCodigoCliente)
        Me.GroupBox1.Controls.Add(Me.txtNumeroOperacion)
        Me.GroupBox1.Controls.Add(Me.lblCodigoCliente)
        Me.GroupBox1.Controls.Add(Me.lblNumeroOperacion)
        Me.GroupBox1.Controls.Add(Me.lblNombre)
        Me.GroupBox1.Controls.Add(Me.txtSecuenciaOperacion)
        Me.GroupBox1.Dock = System.Windows.Forms.DockStyle.Top
        Me.GroupBox1.Location = New System.Drawing.Point(0, 0)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(980, 93)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Operación"
        '
        'btnFacturar
        '
        Me.btnFacturar.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnFacturar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnFacturar.Location = New System.Drawing.Point(815, 14)
        Me.btnFacturar.Name = "btnFacturar"
        Me.btnFacturar.Size = New System.Drawing.Size(131, 29)
        Me.btnFacturar.TabIndex = 29
        Me.btnFacturar.TabStop = False
        Me.btnFacturar.Text = "Facturar"
        Me.btnFacturar.UseVisualStyleBackColor = True
        '
        'btnGenerarRecibo
        '
        Me.btnGenerarRecibo.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnGenerarRecibo.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnGenerarRecibo.Location = New System.Drawing.Point(678, 14)
        Me.btnGenerarRecibo.Name = "btnGenerarRecibo"
        Me.btnGenerarRecibo.Size = New System.Drawing.Size(131, 29)
        Me.btnGenerarRecibo.TabIndex = 28
        Me.btnGenerarRecibo.TabStop = False
        Me.btnGenerarRecibo.Text = "Generar Recibo"
        Me.btnGenerarRecibo.UseVisualStyleBackColor = True
        '
        'lblAnioOperacion
        '
        Me.lblAnioOperacion.AutoSize = True
        Me.lblAnioOperacion.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.lblAnioOperacion.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblAnioOperacion.LabelAsoc = Nothing
        Me.lblAnioOperacion.Location = New System.Drawing.Point(282, 14)
        Me.lblAnioOperacion.Name = "lblAnioOperacion"
        Me.lblAnioOperacion.Size = New System.Drawing.Size(26, 13)
        Me.lblAnioOperacion.TabIndex = 3
        Me.lblAnioOperacion.Text = "Año"
        '
        'pnlTipoOperacion
        '
        Me.pnlTipoOperacion.AutoSize = True
        Me.pnlTipoOperacion.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.pnlTipoOperacion.Controls.Add(Me.radCeroKm)
        Me.pnlTipoOperacion.Controls.Add(Me.radUsado)
        Me.pnlTipoOperacion.Location = New System.Drawing.Point(24, 29)
        Me.pnlTipoOperacion.Name = "pnlTipoOperacion"
        Me.pnlTipoOperacion.Size = New System.Drawing.Size(117, 23)
        Me.pnlTipoOperacion.TabIndex = 0
        '
        'radCeroKm
        '
        Me.radCeroKm.AutoSize = True
        Me.radCeroKm.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.radCeroKm.Location = New System.Drawing.Point(3, 3)
        Me.radCeroKm.Name = "radCeroKm"
        Me.radCeroKm.Size = New System.Drawing.Size(49, 17)
        Me.radCeroKm.TabIndex = 0
        Me.radCeroKm.Text = "0 Km"
        Me.radCeroKm.UseVisualStyleBackColor = True
        '
        'radUsado
        '
        Me.radUsado.AutoSize = True
        Me.radUsado.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.radUsado.Location = New System.Drawing.Point(58, 3)
        Me.radUsado.Name = "radUsado"
        Me.radUsado.Size = New System.Drawing.Size(56, 17)
        Me.radUsado.TabIndex = 1
        Me.radUsado.Text = "Usado"
        Me.radUsado.UseVisualStyleBackColor = True
        '
        'txtAnioOperacion
        '
        Me.txtAnioOperacion.BindearPropiedadControl = Nothing
        Me.txtAnioOperacion.BindearPropiedadEntidad = Nothing
        Me.txtAnioOperacion.ForeColorFocus = System.Drawing.Color.Red
        Me.txtAnioOperacion.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtAnioOperacion.Formato = ""
        Me.txtAnioOperacion.IsDecimal = False
        Me.txtAnioOperacion.IsNumber = True
        Me.txtAnioOperacion.IsPK = False
        Me.txtAnioOperacion.IsRequired = False
        Me.txtAnioOperacion.Key = ""
        Me.txtAnioOperacion.LabelAsoc = Me.lblNumeroOperacion
        Me.txtAnioOperacion.Location = New System.Drawing.Point(285, 30)
        Me.txtAnioOperacion.MaxLength = 8
        Me.txtAnioOperacion.Name = "txtAnioOperacion"
        Me.txtAnioOperacion.ReadOnly = True
        Me.txtAnioOperacion.Size = New System.Drawing.Size(36, 20)
        Me.txtAnioOperacion.TabIndex = 4
        Me.txtAnioOperacion.Text = "0"
        Me.txtAnioOperacion.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtCotizacionDolar
        '
        Me.txtCotizacionDolar.BackColor = System.Drawing.SystemColors.Window
        Me.txtCotizacionDolar.BindearPropiedadControl = "Text"
        Me.txtCotizacionDolar.BindearPropiedadEntidad = "CotizacionDolar"
        Me.txtCotizacionDolar.ForeColorFocus = System.Drawing.Color.Red
        Me.txtCotizacionDolar.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtCotizacionDolar.Formato = "##0.00"
        Me.txtCotizacionDolar.IsDecimal = True
        Me.txtCotizacionDolar.IsNumber = True
        Me.txtCotizacionDolar.IsPK = False
        Me.txtCotizacionDolar.IsRequired = False
        Me.txtCotizacionDolar.Key = ""
        Me.txtCotizacionDolar.LabelAsoc = Me.lblCotizacionDolar
        Me.txtCotizacionDolar.Location = New System.Drawing.Point(540, 30)
        Me.txtCotizacionDolar.MaxLength = 7
        Me.txtCotizacionDolar.Name = "txtCotizacionDolar"
        Me.txtCotizacionDolar.Size = New System.Drawing.Size(67, 20)
        Me.txtCotizacionDolar.TabIndex = 11
        Me.txtCotizacionDolar.Text = "0.00"
        Me.txtCotizacionDolar.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblCotizacionDolar
        '
        Me.lblCotizacionDolar.AutoSize = True
        Me.lblCotizacionDolar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.lblCotizacionDolar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblCotizacionDolar.LabelAsoc = Nothing
        Me.lblCotizacionDolar.Location = New System.Drawing.Point(537, 14)
        Me.lblCotizacionDolar.Name = "lblCotizacionDolar"
        Me.lblCotizacionDolar.Size = New System.Drawing.Size(32, 13)
        Me.lblCotizacionDolar.TabIndex = 10
        Me.lblCotizacionDolar.Text = "Dolar"
        Me.lblCotizacionDolar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtTelefonos
        '
        Me.txtTelefonos.BindearPropiedadControl = ""
        Me.txtTelefonos.BindearPropiedadEntidad = ""
        Me.txtTelefonos.ForeColorFocus = System.Drawing.Color.Red
        Me.txtTelefonos.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtTelefonos.Formato = ""
        Me.txtTelefonos.IsDecimal = False
        Me.txtTelefonos.IsNumber = False
        Me.txtTelefonos.IsPK = False
        Me.txtTelefonos.IsRequired = False
        Me.txtTelefonos.Key = ""
        Me.txtTelefonos.LabelAsoc = Me.lblTelefonos
        Me.txtTelefonos.Location = New System.Drawing.Point(815, 67)
        Me.txtTelefonos.Name = "txtTelefonos"
        Me.txtTelefonos.ReadOnly = True
        Me.txtTelefonos.Size = New System.Drawing.Size(135, 20)
        Me.txtTelefonos.TabIndex = 27
        Me.txtTelefonos.TabStop = False
        '
        'lblTelefonos
        '
        Me.lblTelefonos.AutoSize = True
        Me.lblTelefonos.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblTelefonos.LabelAsoc = Nothing
        Me.lblTelefonos.Location = New System.Drawing.Point(815, 53)
        Me.lblTelefonos.Name = "lblTelefonos"
        Me.lblTelefonos.Size = New System.Drawing.Size(54, 13)
        Me.lblTelefonos.TabIndex = 26
        Me.lblTelefonos.Text = "Telefonos"
        '
        'lblCategoriaFiscal
        '
        Me.lblCategoriaFiscal.AutoSize = True
        Me.lblCategoriaFiscal.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.lblCategoriaFiscal.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblCategoriaFiscal.LabelAsoc = Nothing
        Me.lblCategoriaFiscal.Location = New System.Drawing.Point(680, 53)
        Me.lblCategoriaFiscal.Name = "lblCategoriaFiscal"
        Me.lblCategoriaFiscal.Size = New System.Drawing.Size(82, 13)
        Me.lblCategoriaFiscal.TabIndex = 24
        Me.lblCategoriaFiscal.Text = "Categoria Fiscal"
        '
        'lblCUIT
        '
        Me.lblCUIT.AutoSize = True
        Me.lblCUIT.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblCUIT.LabelAsoc = Nothing
        Me.lblCUIT.Location = New System.Drawing.Point(592, 53)
        Me.lblCUIT.Name = "lblCUIT"
        Me.lblCUIT.Size = New System.Drawing.Size(32, 13)
        Me.lblCUIT.TabIndex = 22
        Me.lblCUIT.Text = "CUIT"
        '
        'cmbCategoriaFiscal
        '
        Me.cmbCategoriaFiscal.BindearPropiedadControl = ""
        Me.cmbCategoriaFiscal.BindearPropiedadEntidad = ""
        Me.cmbCategoriaFiscal.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbCategoriaFiscal.Enabled = False
        Me.cmbCategoriaFiscal.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.cmbCategoriaFiscal.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbCategoriaFiscal.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbCategoriaFiscal.FormattingEnabled = True
        Me.cmbCategoriaFiscal.IsPK = False
        Me.cmbCategoriaFiscal.IsRequired = False
        Me.cmbCategoriaFiscal.Key = Nothing
        Me.cmbCategoriaFiscal.LabelAsoc = Me.lblCategoriaFiscal
        Me.cmbCategoriaFiscal.Location = New System.Drawing.Point(678, 67)
        Me.cmbCategoriaFiscal.Name = "cmbCategoriaFiscal"
        Me.cmbCategoriaFiscal.Size = New System.Drawing.Size(131, 21)
        Me.cmbCategoriaFiscal.TabIndex = 25
        '
        'txtCUITCliente
        '
        Me.txtCUITCliente.BindearPropiedadControl = ""
        Me.txtCUITCliente.BindearPropiedadEntidad = ""
        Me.txtCUITCliente.ForeColorFocus = System.Drawing.Color.Red
        Me.txtCUITCliente.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtCUITCliente.Formato = ""
        Me.txtCUITCliente.IsDecimal = False
        Me.txtCUITCliente.IsNumber = False
        Me.txtCUITCliente.IsPK = False
        Me.txtCUITCliente.IsRequired = False
        Me.txtCUITCliente.Key = ""
        Me.txtCUITCliente.LabelAsoc = Me.lblCUIT
        Me.txtCUITCliente.Location = New System.Drawing.Point(593, 67)
        Me.txtCUITCliente.MaxLength = 8
        Me.txtCUITCliente.Name = "txtCUITCliente"
        Me.txtCUITCliente.ReadOnly = True
        Me.txtCUITCliente.Size = New System.Drawing.Size(79, 20)
        Me.txtCUITCliente.TabIndex = 23
        Me.txtCUITCliente.TabStop = False
        Me.txtCUITCliente.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'cmbTipoDocCliente
        '
        Me.cmbTipoDocCliente.BindearPropiedadControl = ""
        Me.cmbTipoDocCliente.BindearPropiedadEntidad = ""
        Me.cmbTipoDocCliente.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbTipoDocCliente.Enabled = False
        Me.cmbTipoDocCliente.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbTipoDocCliente.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbTipoDocCliente.FormattingEnabled = True
        Me.cmbTipoDocCliente.IsPK = False
        Me.cmbTipoDocCliente.IsRequired = False
        Me.cmbTipoDocCliente.Key = Nothing
        Me.cmbTipoDocCliente.LabelAsoc = Nothing
        Me.cmbTipoDocCliente.Location = New System.Drawing.Point(454, 67)
        Me.cmbTipoDocCliente.Name = "cmbTipoDocCliente"
        Me.cmbTipoDocCliente.Size = New System.Drawing.Size(71, 21)
        Me.cmbTipoDocCliente.TabIndex = 19
        '
        'cmbMarca
        '
        Me.cmbMarca.BindearPropiedadControl = Nothing
        Me.cmbMarca.BindearPropiedadEntidad = Nothing
        Me.cmbMarca.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbMarca.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.cmbMarca.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbMarca.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbMarca.FormattingEnabled = True
        Me.cmbMarca.IsPK = True
        Me.cmbMarca.IsRequired = True
        Me.cmbMarca.Key = Nothing
        Me.cmbMarca.LabelAsoc = Me.lblMarcaVehiculo
        Me.cmbMarca.Location = New System.Drawing.Point(148, 30)
        Me.cmbMarca.Name = "cmbMarca"
        Me.cmbMarca.Size = New System.Drawing.Size(131, 21)
        Me.cmbMarca.TabIndex = 2
        '
        'lblNroDocCliente
        '
        Me.lblNroDocCliente.AutoSize = True
        Me.lblNroDocCliente.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblNroDocCliente.LabelAsoc = Nothing
        Me.lblNroDocCliente.Location = New System.Drawing.Point(525, 53)
        Me.lblNroDocCliente.Name = "lblNroDocCliente"
        Me.lblNroDocCliente.Size = New System.Drawing.Size(44, 13)
        Me.lblNroDocCliente.TabIndex = 20
        Me.lblNroDocCliente.Text = "Número"
        '
        'lblTipoDocCliente
        '
        Me.lblTipoDocCliente.AutoSize = True
        Me.lblTipoDocCliente.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblTipoDocCliente.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblTipoDocCliente.LabelAsoc = Nothing
        Me.lblTipoDocCliente.Location = New System.Drawing.Point(451, 53)
        Me.lblTipoDocCliente.Name = "lblTipoDocCliente"
        Me.lblTipoDocCliente.Size = New System.Drawing.Size(43, 13)
        Me.lblTipoDocCliente.TabIndex = 18
        Me.lblTipoDocCliente.Text = "T. Doc."
        Me.lblTipoDocCliente.Visible = False
        '
        'txtNroDocCliente
        '
        Me.txtNroDocCliente.BindearPropiedadControl = ""
        Me.txtNroDocCliente.BindearPropiedadEntidad = ""
        Me.txtNroDocCliente.ForeColorFocus = System.Drawing.Color.Red
        Me.txtNroDocCliente.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtNroDocCliente.Formato = ""
        Me.txtNroDocCliente.IsDecimal = False
        Me.txtNroDocCliente.IsNumber = False
        Me.txtNroDocCliente.IsPK = False
        Me.txtNroDocCliente.IsRequired = False
        Me.txtNroDocCliente.Key = ""
        Me.txtNroDocCliente.LabelAsoc = Me.lblNroDocCliente
        Me.txtNroDocCliente.Location = New System.Drawing.Point(526, 67)
        Me.txtNroDocCliente.MaxLength = 8
        Me.txtNroDocCliente.Name = "txtNroDocCliente"
        Me.txtNroDocCliente.ReadOnly = True
        Me.txtNroDocCliente.Size = New System.Drawing.Size(61, 20)
        Me.txtNroDocCliente.TabIndex = 21
        Me.txtNroDocCliente.TabStop = False
        Me.txtNroDocCliente.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.TableLayoutPanel1)
        Me.GroupBox2.Controls.Add(Me.tbcUnidadVendida)
        Me.GroupBox2.Dock = System.Windows.Forms.DockStyle.Top
        Me.GroupBox2.Location = New System.Drawing.Point(0, 93)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(980, 141)
        Me.GroupBox2.TabIndex = 1
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Unidad Vendida"
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 3
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel1.Controls.Add(Me.txtTotalGeneral, 1, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.btnCaracteristicas, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.txtImporteTotalCaracteristicas, 2, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.lblTotalGeneral, 0, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.btnAdicionales, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.txtImporteTotalAdicionales, 2, 0)
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(741, 10)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 3
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(233, 120)
        Me.TableLayoutPanel1.TabIndex = 1
        '
        'txtTotalGeneral
        '
        Me.txtTotalGeneral.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtTotalGeneral.BindearPropiedadControl = "Text"
        Me.txtTotalGeneral.BindearPropiedadEntidad = "ImporteTotal"
        Me.TableLayoutPanel1.SetColumnSpan(Me.txtTotalGeneral, 2)
        Me.txtTotalGeneral.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotalGeneral.ForeColorFocus = System.Drawing.Color.Red
        Me.txtTotalGeneral.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtTotalGeneral.Formato = "##,##0.00"
        Me.txtTotalGeneral.IsDecimal = True
        Me.txtTotalGeneral.IsNumber = True
        Me.txtTotalGeneral.IsPK = False
        Me.txtTotalGeneral.IsRequired = False
        Me.txtTotalGeneral.Key = ""
        Me.txtTotalGeneral.LabelAsoc = Nothing
        Me.txtTotalGeneral.Location = New System.Drawing.Point(75, 87)
        Me.txtTotalGeneral.Name = "txtTotalGeneral"
        Me.txtTotalGeneral.ReadOnly = True
        Me.txtTotalGeneral.Size = New System.Drawing.Size(155, 26)
        Me.txtTotalGeneral.TabIndex = 5
        Me.txtTotalGeneral.TabStop = False
        Me.txtTotalGeneral.Text = "0.00"
        Me.txtTotalGeneral.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'btnCaracteristicas
        '
        Me.btnCaracteristicas.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TableLayoutPanel1.SetColumnSpan(Me.btnCaracteristicas, 2)
        Me.btnCaracteristicas.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnCaracteristicas.Location = New System.Drawing.Point(3, 45)
        Me.btnCaracteristicas.Name = "btnCaracteristicas"
        Me.btnCaracteristicas.Size = New System.Drawing.Size(131, 36)
        Me.btnCaracteristicas.TabIndex = 2
        Me.btnCaracteristicas.Text = "Características (F8)"
        Me.btnCaracteristicas.UseVisualStyleBackColor = True
        '
        'txtImporteTotalCaracteristicas
        '
        Me.txtImporteTotalCaracteristicas.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.txtImporteTotalCaracteristicas.BindearPropiedadControl = "Text"
        Me.txtImporteTotalCaracteristicas.BindearPropiedadEntidad = "ImporteTotalCaracteristicas"
        Me.txtImporteTotalCaracteristicas.ForeColorFocus = System.Drawing.Color.Red
        Me.txtImporteTotalCaracteristicas.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtImporteTotalCaracteristicas.Formato = "N2"
        Me.txtImporteTotalCaracteristicas.IsDecimal = True
        Me.txtImporteTotalCaracteristicas.IsNumber = True
        Me.txtImporteTotalCaracteristicas.IsPK = False
        Me.txtImporteTotalCaracteristicas.IsRequired = False
        Me.txtImporteTotalCaracteristicas.Key = ""
        Me.txtImporteTotalCaracteristicas.LabelAsoc = Me.lblPrecio
        Me.txtImporteTotalCaracteristicas.Location = New System.Drawing.Point(140, 53)
        Me.txtImporteTotalCaracteristicas.MaxLength = 15
        Me.txtImporteTotalCaracteristicas.Name = "txtImporteTotalCaracteristicas"
        Me.txtImporteTotalCaracteristicas.ReadOnly = True
        Me.txtImporteTotalCaracteristicas.Size = New System.Drawing.Size(90, 20)
        Me.txtImporteTotalCaracteristicas.TabIndex = 3
        Me.txtImporteTotalCaracteristicas.Text = "0.00"
        Me.txtImporteTotalCaracteristicas.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtImporteTotalCaracteristicas.Visible = False
        '
        'lblPrecio
        '
        Me.lblPrecio.AutoSize = True
        Me.lblPrecio.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblPrecio.LabelAsoc = Nothing
        Me.lblPrecio.Location = New System.Drawing.Point(489, 3)
        Me.lblPrecio.Name = "lblPrecio"
        Me.lblPrecio.Size = New System.Drawing.Size(37, 13)
        Me.lblPrecio.TabIndex = 7
        Me.lblPrecio.Text = "Pre&cio"
        '
        'lblTotalGeneral
        '
        Me.lblTotalGeneral.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.lblTotalGeneral.AutoSize = True
        Me.lblTotalGeneral.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold)
        Me.lblTotalGeneral.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblTotalGeneral.LabelAsoc = Nothing
        Me.lblTotalGeneral.Location = New System.Drawing.Point(20, 92)
        Me.lblTotalGeneral.Name = "lblTotalGeneral"
        Me.lblTotalGeneral.Size = New System.Drawing.Size(49, 20)
        Me.lblTotalGeneral.TabIndex = 4
        Me.lblTotalGeneral.Text = "Total"
        '
        'btnAdicionales
        '
        Me.btnAdicionales.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TableLayoutPanel1.SetColumnSpan(Me.btnAdicionales, 2)
        Me.btnAdicionales.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnAdicionales.Location = New System.Drawing.Point(3, 3)
        Me.btnAdicionales.Name = "btnAdicionales"
        Me.btnAdicionales.Size = New System.Drawing.Size(131, 36)
        Me.btnAdicionales.TabIndex = 0
        Me.btnAdicionales.Text = "Adicionales (F7)"
        Me.btnAdicionales.UseVisualStyleBackColor = True
        '
        'txtImporteTotalAdicionales
        '
        Me.txtImporteTotalAdicionales.AccessibleDescription = ""
        Me.txtImporteTotalAdicionales.AccessibleName = ""
        Me.txtImporteTotalAdicionales.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.txtImporteTotalAdicionales.BindearPropiedadControl = "Text"
        Me.txtImporteTotalAdicionales.BindearPropiedadEntidad = "ImporteTotalAdicionales"
        Me.txtImporteTotalAdicionales.ForeColorFocus = System.Drawing.Color.Red
        Me.txtImporteTotalAdicionales.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtImporteTotalAdicionales.Formato = "N2"
        Me.txtImporteTotalAdicionales.IsDecimal = True
        Me.txtImporteTotalAdicionales.IsNumber = True
        Me.txtImporteTotalAdicionales.IsPK = False
        Me.txtImporteTotalAdicionales.IsRequired = False
        Me.txtImporteTotalAdicionales.Key = ""
        Me.txtImporteTotalAdicionales.LabelAsoc = Me.lblPrecio
        Me.txtImporteTotalAdicionales.Location = New System.Drawing.Point(140, 11)
        Me.txtImporteTotalAdicionales.MaxLength = 15
        Me.txtImporteTotalAdicionales.Name = "txtImporteTotalAdicionales"
        Me.txtImporteTotalAdicionales.ReadOnly = True
        Me.txtImporteTotalAdicionales.Size = New System.Drawing.Size(90, 20)
        Me.txtImporteTotalAdicionales.TabIndex = 1
        Me.txtImporteTotalAdicionales.Text = "0.00"
        Me.txtImporteTotalAdicionales.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'tbcUnidadVendida
        '
        Me.tbcUnidadVendida.Alignment = System.Windows.Forms.TabAlignment.Left
        Me.tbcUnidadVendida.Controls.Add(Me.tbp0Km)
        Me.tbcUnidadVendida.Controls.Add(Me.tbpUsado)
        Me.tbcUnidadVendida.Location = New System.Drawing.Point(6, 14)
        Me.tbcUnidadVendida.Multiline = True
        Me.tbcUnidadVendida.Name = "tbcUnidadVendida"
        Me.tbcUnidadVendida.SelectedIndex = 0
        Me.tbcUnidadVendida.Size = New System.Drawing.Size(730, 120)
        Me.tbcUnidadVendida.SizeMode = System.Windows.Forms.TabSizeMode.FillToRight
        Me.tbcUnidadVendida.TabIndex = 0
        '
        'tbp0Km
        '
        Me.tbp0Km.BackColor = System.Drawing.SystemColors.Control
        Me.tbp0Km.Controls.Add(Me.llbTotalProducto)
        Me.tbp0Km.Controls.Add(Me.txtTotalProducto)
        Me.tbp0Km.Controls.Add(Me.lblPrecio)
        Me.tbp0Km.Controls.Add(Me.txtPrecioProducto)
        Me.tbp0Km.Controls.Add(Me.lblCantidad)
        Me.tbp0Km.Controls.Add(Me.txtCantidadProducto)
        Me.tbp0Km.Controls.Add(Me.bscProducto2)
        Me.tbp0Km.Controls.Add(Me.lblProducto)
        Me.tbp0Km.Controls.Add(Me.bscCodigoProducto2)
        Me.tbp0Km.Controls.Add(Me.lnkProducto)
        Me.tbp0Km.Controls.Add(Me.lblCodProducto)
        Me.tbp0Km.Controls.Add(Me.lblNombreProducto)
        Me.tbp0Km.Location = New System.Drawing.Point(23, 4)
        Me.tbp0Km.Name = "tbp0Km"
        Me.tbp0Km.Padding = New System.Windows.Forms.Padding(3)
        Me.tbp0Km.Size = New System.Drawing.Size(703, 112)
        Me.tbp0Km.TabIndex = 0
        Me.tbp0Km.Text = "0 Km"
        '
        'llbTotalProducto
        '
        Me.llbTotalProducto.AutoSize = True
        Me.llbTotalProducto.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.llbTotalProducto.LabelAsoc = Nothing
        Me.llbTotalProducto.Location = New System.Drawing.Point(587, 4)
        Me.llbTotalProducto.Name = "llbTotalProducto"
        Me.llbTotalProducto.Size = New System.Drawing.Size(42, 13)
        Me.llbTotalProducto.TabIndex = 9
        Me.llbTotalProducto.Text = "Importe"
        '
        'txtTotalProducto
        '
        Me.txtTotalProducto.BindearPropiedadControl = "Text"
        Me.txtTotalProducto.BindearPropiedadEntidad = "ImporteCeroKilometro"
        Me.txtTotalProducto.ForeColorFocus = System.Drawing.Color.Red
        Me.txtTotalProducto.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtTotalProducto.Formato = "N2"
        Me.txtTotalProducto.IsDecimal = False
        Me.txtTotalProducto.IsNumber = True
        Me.txtTotalProducto.IsPK = False
        Me.txtTotalProducto.IsRequired = False
        Me.txtTotalProducto.Key = ""
        Me.txtTotalProducto.LabelAsoc = Me.llbTotalProducto
        Me.txtTotalProducto.Location = New System.Drawing.Point(588, 19)
        Me.txtTotalProducto.Name = "txtTotalProducto"
        Me.txtTotalProducto.ReadOnly = True
        Me.txtTotalProducto.Size = New System.Drawing.Size(90, 20)
        Me.txtTotalProducto.TabIndex = 10
        Me.txtTotalProducto.TabStop = False
        Me.txtTotalProducto.Text = "0.00"
        Me.txtTotalProducto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtPrecioProducto
        '
        Me.txtPrecioProducto.BindearPropiedadControl = "Text"
        Me.txtPrecioProducto.BindearPropiedadEntidad = "PrecioCeroKilometro"
        Me.txtPrecioProducto.ForeColorFocus = System.Drawing.Color.Red
        Me.txtPrecioProducto.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtPrecioProducto.Formato = "N2"
        Me.txtPrecioProducto.IsDecimal = True
        Me.txtPrecioProducto.IsNumber = True
        Me.txtPrecioProducto.IsPK = False
        Me.txtPrecioProducto.IsRequired = False
        Me.txtPrecioProducto.Key = ""
        Me.txtPrecioProducto.LabelAsoc = Me.lblPrecio
        Me.txtPrecioProducto.Location = New System.Drawing.Point(492, 18)
        Me.txtPrecioProducto.MaxLength = 15
        Me.txtPrecioProducto.Name = "txtPrecioProducto"
        Me.txtPrecioProducto.Size = New System.Drawing.Size(90, 20)
        Me.txtPrecioProducto.TabIndex = 8
        Me.txtPrecioProducto.Text = "0.00"
        Me.txtPrecioProducto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblCantidad
        '
        Me.lblCantidad.AutoSize = True
        Me.lblCantidad.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblCantidad.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblCantidad.LabelAsoc = Me.lblProducto
        Me.lblCantidad.Location = New System.Drawing.Point(434, 3)
        Me.lblCantidad.Name = "lblCantidad"
        Me.lblCantidad.Size = New System.Drawing.Size(49, 13)
        Me.lblCantidad.TabIndex = 5
        Me.lblCantidad.Text = "Cantidad"
        '
        'lblProducto
        '
        Me.lblProducto.AutoSize = True
        Me.lblProducto.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.lblProducto.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblProducto.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblProducto.LabelAsoc = Nothing
        Me.lblProducto.Location = New System.Drawing.Point(9, 22)
        Me.lblProducto.Name = "lblProducto"
        Me.lblProducto.Size = New System.Drawing.Size(50, 13)
        Me.lblProducto.TabIndex = 0
        Me.lblProducto.Text = "Producto"
        '
        'txtCantidadProducto
        '
        Me.txtCantidadProducto.BindearPropiedadControl = "Text"
        Me.txtCantidadProducto.BindearPropiedadEntidad = "CantidadCeroKilometro"
        Me.txtCantidadProducto.ForeColorFocus = System.Drawing.Color.Red
        Me.txtCantidadProducto.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtCantidadProducto.Formato = "N0"
        Me.txtCantidadProducto.IsDecimal = True
        Me.txtCantidadProducto.IsNumber = True
        Me.txtCantidadProducto.IsPK = False
        Me.txtCantidadProducto.IsRequired = False
        Me.txtCantidadProducto.Key = ""
        Me.txtCantidadProducto.LabelAsoc = Me.lblCantidad
        Me.txtCantidadProducto.Location = New System.Drawing.Point(437, 18)
        Me.txtCantidadProducto.MaxLength = 8
        Me.txtCantidadProducto.Name = "txtCantidadProducto"
        Me.txtCantidadProducto.Size = New System.Drawing.Size(49, 20)
        Me.txtCantidadProducto.TabIndex = 6
        Me.txtCantidadProducto.Text = "0"
        Me.txtCantidadProducto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'bscProducto2
        '
        Me.bscProducto2.ActivarFiltroEnGrilla = True
        Me.bscProducto2.BindearPropiedadControl = Nothing
        Me.bscProducto2.BindearPropiedadEntidad = Nothing
        Me.bscProducto2.ConfigBuscador = Nothing
        Me.bscProducto2.Datos = Nothing
        Me.bscProducto2.FilaDevuelta = Nothing
        Me.bscProducto2.ForeColorFocus = System.Drawing.Color.Red
        Me.bscProducto2.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.bscProducto2.IsDecimal = False
        Me.bscProducto2.IsNumber = False
        Me.bscProducto2.IsPK = False
        Me.bscProducto2.IsRequired = False
        Me.bscProducto2.Key = ""
        Me.bscProducto2.LabelAsoc = Me.lblProducto
        Me.bscProducto2.Location = New System.Drawing.Point(196, 18)
        Me.bscProducto2.MaxLengh = "60"
        Me.bscProducto2.Name = "bscProducto2"
        Me.bscProducto2.Permitido = True
        Me.bscProducto2.PermitidoNoBackColor = System.Drawing.Color.FromArgb(CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer))
        Me.bscProducto2.PermitidoNoForeColor = System.Drawing.Color.Black
        Me.bscProducto2.PermitidoSiBackColor = System.Drawing.Color.White
        Me.bscProducto2.PermitidoSiForeColor = System.Drawing.Color.Black
        Me.bscProducto2.Selecciono = False
        Me.bscProducto2.Size = New System.Drawing.Size(235, 20)
        Me.bscProducto2.TabIndex = 4
        '
        'bscCodigoProducto2
        '
        Me.bscCodigoProducto2.ActivarFiltroEnGrilla = True
        Me.bscCodigoProducto2.BindearPropiedadControl = Nothing
        Me.bscCodigoProducto2.BindearPropiedadEntidad = Nothing
        Me.bscCodigoProducto2.ConfigBuscador = Nothing
        Me.bscCodigoProducto2.Datos = Nothing
        Me.bscCodigoProducto2.FilaDevuelta = Nothing
        Me.bscCodigoProducto2.ForeColorFocus = System.Drawing.Color.Red
        Me.bscCodigoProducto2.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.bscCodigoProducto2.IsDecimal = False
        Me.bscCodigoProducto2.IsNumber = False
        Me.bscCodigoProducto2.IsPK = False
        Me.bscCodigoProducto2.IsRequired = False
        Me.bscCodigoProducto2.Key = ""
        Me.bscCodigoProducto2.LabelAsoc = Me.lblCodProducto
        Me.bscCodigoProducto2.Location = New System.Drawing.Point(65, 18)
        Me.bscCodigoProducto2.MaxLengh = "32767"
        Me.bscCodigoProducto2.Name = "bscCodigoProducto2"
        Me.bscCodigoProducto2.Permitido = True
        Me.bscCodigoProducto2.PermitidoNoBackColor = System.Drawing.Color.FromArgb(CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer))
        Me.bscCodigoProducto2.PermitidoNoForeColor = System.Drawing.Color.Black
        Me.bscCodigoProducto2.PermitidoSiBackColor = System.Drawing.Color.White
        Me.bscCodigoProducto2.PermitidoSiForeColor = System.Drawing.Color.Black
        Me.bscCodigoProducto2.Selecciono = False
        Me.bscCodigoProducto2.Size = New System.Drawing.Size(125, 20)
        Me.bscCodigoProducto2.TabIndex = 2
        '
        'lblCodProducto
        '
        Me.lblCodProducto.AutoSize = True
        Me.lblCodProducto.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblCodProducto.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblCodProducto.LabelAsoc = Me.lblProducto
        Me.lblCodProducto.Location = New System.Drawing.Point(62, 3)
        Me.lblCodProducto.Name = "lblCodProducto"
        Me.lblCodProducto.Size = New System.Drawing.Size(40, 13)
        Me.lblCodProducto.TabIndex = 1
        Me.lblCodProducto.Text = "Código"
        '
        'lnkProducto
        '
        Me.lnkProducto.AutoSize = True
        Me.lnkProducto.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lnkProducto.Location = New System.Drawing.Point(193, 2)
        Me.lnkProducto.Name = "lnkProducto"
        Me.lnkProducto.Size = New System.Drawing.Size(50, 13)
        Me.lnkProducto.TabIndex = 3
        Me.lnkProducto.TabStop = True
        Me.lnkProducto.Text = "Producto"
        '
        'lblNombreProducto
        '
        Me.lblNombreProducto.AutoSize = True
        Me.lblNombreProducto.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblNombreProducto.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblNombreProducto.LabelAsoc = Me.lblProducto
        Me.lblNombreProducto.Location = New System.Drawing.Point(193, 2)
        Me.lblNombreProducto.Name = "lblNombreProducto"
        Me.lblNombreProducto.Size = New System.Drawing.Size(50, 13)
        Me.lblNombreProducto.TabIndex = 11
        Me.lblNombreProducto.Text = "Producto"
        Me.lblNombreProducto.Visible = False
        '
        'tbpUsado
        '
        Me.tbpUsado.BackColor = System.Drawing.SystemColors.Control
        Me.tbpUsado.Controls.Add(Me.txtMaximoActualizadoUsado)
        Me.tbpUsado.Controls.Add(Me.txtMinimoActualizadoUsado)
        Me.tbpUsado.Controls.Add(Me.pnlColorPrecioLista)
        Me.tbpUsado.Controls.Add(Me.lblModeloUsado)
        Me.tbpUsado.Controls.Add(Me.lblMarcaUsado)
        Me.tbpUsado.Controls.Add(Me.txtModeloUsado)
        Me.tbpUsado.Controls.Add(Me.txtMarcaUsado)
        Me.tbpUsado.Controls.Add(Me.txtPrecioListaUsado)
        Me.tbpUsado.Controls.Add(Me.lblPrecioListaUsado)
        Me.tbpUsado.Controls.Add(Me.txtPrecioVentaUsado)
        Me.tbpUsado.Controls.Add(Me.lblPrecioVentaUsado)
        Me.tbpUsado.Controls.Add(Me.Label1)
        Me.tbpUsado.Controls.Add(Me.bscCodigoVehiculoUsado)
        Me.tbpUsado.Location = New System.Drawing.Point(23, 4)
        Me.tbpUsado.Name = "tbpUsado"
        Me.tbpUsado.Padding = New System.Windows.Forms.Padding(3)
        Me.tbpUsado.Size = New System.Drawing.Size(703, 112)
        Me.tbpUsado.TabIndex = 1
        Me.tbpUsado.Text = "Usado"
        '
        'txtMaximoActualizadoUsado
        '
        Me.txtMaximoActualizadoUsado.BindearPropiedadControl = ""
        Me.txtMaximoActualizadoUsado.BindearPropiedadEntidad = ""
        Me.txtMaximoActualizadoUsado.ForeColorFocus = System.Drawing.Color.Red
        Me.txtMaximoActualizadoUsado.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtMaximoActualizadoUsado.Formato = "N2"
        Me.txtMaximoActualizadoUsado.IsDecimal = True
        Me.txtMaximoActualizadoUsado.IsNumber = True
        Me.txtMaximoActualizadoUsado.IsPK = False
        Me.txtMaximoActualizadoUsado.IsRequired = False
        Me.txtMaximoActualizadoUsado.Key = ""
        Me.txtMaximoActualizadoUsado.LabelAsoc = Me.lblPrecioListaUsado
        Me.txtMaximoActualizadoUsado.Location = New System.Drawing.Point(492, 70)
        Me.txtMaximoActualizadoUsado.Name = "txtMaximoActualizadoUsado"
        Me.txtMaximoActualizadoUsado.ReadOnly = True
        Me.txtMaximoActualizadoUsado.Size = New System.Drawing.Size(90, 20)
        Me.txtMaximoActualizadoUsado.TabIndex = 30
        Me.txtMaximoActualizadoUsado.Text = "0,00"
        Me.txtMaximoActualizadoUsado.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtMaximoActualizadoUsado.Visible = False
        '
        'lblPrecioListaUsado
        '
        Me.lblPrecioListaUsado.AutoSize = True
        Me.lblPrecioListaUsado.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblPrecioListaUsado.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblPrecioListaUsado.LabelAsoc = Nothing
        Me.lblPrecioListaUsado.Location = New System.Drawing.Point(489, 4)
        Me.lblPrecioListaUsado.Name = "lblPrecioListaUsado"
        Me.lblPrecioListaUsado.Size = New System.Drawing.Size(62, 13)
        Me.lblPrecioListaUsado.TabIndex = 11
        Me.lblPrecioListaUsado.Text = "Precio Lista"
        '
        'txtMinimoActualizadoUsado
        '
        Me.txtMinimoActualizadoUsado.BindearPropiedadControl = ""
        Me.txtMinimoActualizadoUsado.BindearPropiedadEntidad = ""
        Me.txtMinimoActualizadoUsado.ForeColorFocus = System.Drawing.Color.Red
        Me.txtMinimoActualizadoUsado.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtMinimoActualizadoUsado.Formato = "N2"
        Me.txtMinimoActualizadoUsado.IsDecimal = True
        Me.txtMinimoActualizadoUsado.IsNumber = True
        Me.txtMinimoActualizadoUsado.IsPK = False
        Me.txtMinimoActualizadoUsado.IsRequired = False
        Me.txtMinimoActualizadoUsado.Key = ""
        Me.txtMinimoActualizadoUsado.LabelAsoc = Me.lblPrecioListaUsado
        Me.txtMinimoActualizadoUsado.Location = New System.Drawing.Point(492, 44)
        Me.txtMinimoActualizadoUsado.Name = "txtMinimoActualizadoUsado"
        Me.txtMinimoActualizadoUsado.ReadOnly = True
        Me.txtMinimoActualizadoUsado.Size = New System.Drawing.Size(90, 20)
        Me.txtMinimoActualizadoUsado.TabIndex = 29
        Me.txtMinimoActualizadoUsado.Text = "0,00"
        Me.txtMinimoActualizadoUsado.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtMinimoActualizadoUsado.Visible = False
        '
        'pnlColorPrecioLista
        '
        Me.pnlColorPrecioLista.Location = New System.Drawing.Point(680, 19)
        Me.pnlColorPrecioLista.Name = "pnlColorPrecioLista"
        Me.pnlColorPrecioLista.Size = New System.Drawing.Size(20, 20)
        Me.pnlColorPrecioLista.TabIndex = 28
        '
        'lblModeloUsado
        '
        Me.lblModeloUsado.AutoSize = True
        Me.lblModeloUsado.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblModeloUsado.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblModeloUsado.LabelAsoc = Nothing
        Me.lblModeloUsado.Location = New System.Drawing.Point(343, 4)
        Me.lblModeloUsado.Name = "lblModeloUsado"
        Me.lblModeloUsado.Size = New System.Drawing.Size(42, 13)
        Me.lblModeloUsado.TabIndex = 27
        Me.lblModeloUsado.Text = "Modelo"
        '
        'lblMarcaUsado
        '
        Me.lblMarcaUsado.AutoSize = True
        Me.lblMarcaUsado.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblMarcaUsado.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblMarcaUsado.LabelAsoc = Nothing
        Me.lblMarcaUsado.Location = New System.Drawing.Point(198, 4)
        Me.lblMarcaUsado.Name = "lblMarcaUsado"
        Me.lblMarcaUsado.Size = New System.Drawing.Size(37, 13)
        Me.lblMarcaUsado.TabIndex = 26
        Me.lblMarcaUsado.Text = "Marca"
        '
        'txtModeloUsado
        '
        Me.txtModeloUsado.BindearPropiedadControl = ""
        Me.txtModeloUsado.BindearPropiedadEntidad = ""
        Me.txtModeloUsado.ForeColorFocus = System.Drawing.Color.Red
        Me.txtModeloUsado.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtModeloUsado.Formato = ""
        Me.txtModeloUsado.IsDecimal = False
        Me.txtModeloUsado.IsNumber = False
        Me.txtModeloUsado.IsPK = False
        Me.txtModeloUsado.IsRequired = False
        Me.txtModeloUsado.Key = ""
        Me.txtModeloUsado.LabelAsoc = Me.lblModeloUsado
        Me.txtModeloUsado.Location = New System.Drawing.Point(346, 18)
        Me.txtModeloUsado.MaxLength = 8
        Me.txtModeloUsado.Name = "txtModeloUsado"
        Me.txtModeloUsado.ReadOnly = True
        Me.txtModeloUsado.Size = New System.Drawing.Size(140, 20)
        Me.txtModeloUsado.TabIndex = 25
        Me.txtModeloUsado.TabStop = False
        Me.txtModeloUsado.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtMarcaUsado
        '
        Me.txtMarcaUsado.BindearPropiedadControl = ""
        Me.txtMarcaUsado.BindearPropiedadEntidad = ""
        Me.txtMarcaUsado.ForeColorFocus = System.Drawing.Color.Red
        Me.txtMarcaUsado.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtMarcaUsado.Formato = ""
        Me.txtMarcaUsado.IsDecimal = False
        Me.txtMarcaUsado.IsNumber = False
        Me.txtMarcaUsado.IsPK = False
        Me.txtMarcaUsado.IsRequired = False
        Me.txtMarcaUsado.Key = ""
        Me.txtMarcaUsado.LabelAsoc = Me.lblMarcaUsado
        Me.txtMarcaUsado.Location = New System.Drawing.Point(201, 18)
        Me.txtMarcaUsado.MaxLength = 8
        Me.txtMarcaUsado.Name = "txtMarcaUsado"
        Me.txtMarcaUsado.ReadOnly = True
        Me.txtMarcaUsado.Size = New System.Drawing.Size(140, 20)
        Me.txtMarcaUsado.TabIndex = 24
        Me.txtMarcaUsado.TabStop = False
        Me.txtMarcaUsado.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtPrecioListaUsado
        '
        Me.txtPrecioListaUsado.BindearPropiedadControl = "Text"
        Me.txtPrecioListaUsado.BindearPropiedadEntidad = "PrecioListaUsado"
        Me.txtPrecioListaUsado.ForeColorFocus = System.Drawing.Color.Red
        Me.txtPrecioListaUsado.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtPrecioListaUsado.Formato = "N2"
        Me.txtPrecioListaUsado.IsDecimal = True
        Me.txtPrecioListaUsado.IsNumber = True
        Me.txtPrecioListaUsado.IsPK = False
        Me.txtPrecioListaUsado.IsRequired = False
        Me.txtPrecioListaUsado.Key = ""
        Me.txtPrecioListaUsado.LabelAsoc = Me.lblPrecioListaUsado
        Me.txtPrecioListaUsado.Location = New System.Drawing.Point(492, 18)
        Me.txtPrecioListaUsado.Name = "txtPrecioListaUsado"
        Me.txtPrecioListaUsado.ReadOnly = True
        Me.txtPrecioListaUsado.Size = New System.Drawing.Size(90, 20)
        Me.txtPrecioListaUsado.TabIndex = 12
        Me.txtPrecioListaUsado.Text = "0,00"
        Me.txtPrecioListaUsado.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtPrecioVentaUsado
        '
        Me.txtPrecioVentaUsado.BindearPropiedadControl = "Text"
        Me.txtPrecioVentaUsado.BindearPropiedadEntidad = "ImporteUsado"
        Me.txtPrecioVentaUsado.ForeColorFocus = System.Drawing.Color.Red
        Me.txtPrecioVentaUsado.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtPrecioVentaUsado.Formato = "N2"
        Me.txtPrecioVentaUsado.IsDecimal = True
        Me.txtPrecioVentaUsado.IsNumber = True
        Me.txtPrecioVentaUsado.IsPK = False
        Me.txtPrecioVentaUsado.IsRequired = False
        Me.txtPrecioVentaUsado.Key = ""
        Me.txtPrecioVentaUsado.LabelAsoc = Me.lblPrecioVentaUsado
        Me.txtPrecioVentaUsado.Location = New System.Drawing.Point(588, 19)
        Me.txtPrecioVentaUsado.Name = "txtPrecioVentaUsado"
        Me.txtPrecioVentaUsado.Size = New System.Drawing.Size(90, 20)
        Me.txtPrecioVentaUsado.TabIndex = 10
        Me.txtPrecioVentaUsado.Text = "0,00"
        Me.txtPrecioVentaUsado.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblPrecioVentaUsado
        '
        Me.lblPrecioVentaUsado.AutoSize = True
        Me.lblPrecioVentaUsado.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblPrecioVentaUsado.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblPrecioVentaUsado.LabelAsoc = Nothing
        Me.lblPrecioVentaUsado.Location = New System.Drawing.Point(587, 4)
        Me.lblPrecioVentaUsado.Name = "lblPrecioVentaUsado"
        Me.lblPrecioVentaUsado.Size = New System.Drawing.Size(42, 13)
        Me.lblPrecioVentaUsado.TabIndex = 9
        Me.lblPrecioVentaUsado.Text = "Importe"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Label1.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label1.LabelAsoc = Nothing
        Me.Label1.Location = New System.Drawing.Point(15, 22)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(44, 13)
        Me.Label1.TabIndex = 6
        Me.Label1.Text = "Patente"
        '
        'bscCodigoVehiculoUsado
        '
        Me.bscCodigoVehiculoUsado.ActivarFiltroEnGrilla = True
        Me.bscCodigoVehiculoUsado.BindearPropiedadControl = Nothing
        Me.bscCodigoVehiculoUsado.BindearPropiedadEntidad = Nothing
        Me.bscCodigoVehiculoUsado.ConfigBuscador = Nothing
        Me.bscCodigoVehiculoUsado.Datos = Nothing
        Me.bscCodigoVehiculoUsado.FilaDevuelta = Nothing
        Me.bscCodigoVehiculoUsado.ForeColorFocus = System.Drawing.Color.Red
        Me.bscCodigoVehiculoUsado.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.bscCodigoVehiculoUsado.IsDecimal = False
        Me.bscCodigoVehiculoUsado.IsNumber = False
        Me.bscCodigoVehiculoUsado.IsPK = False
        Me.bscCodigoVehiculoUsado.IsRequired = False
        Me.bscCodigoVehiculoUsado.Key = ""
        Me.bscCodigoVehiculoUsado.LabelAsoc = Me.lblCodProducto
        Me.bscCodigoVehiculoUsado.Location = New System.Drawing.Point(65, 18)
        Me.bscCodigoVehiculoUsado.MaxLengh = "32767"
        Me.bscCodigoVehiculoUsado.Name = "bscCodigoVehiculoUsado"
        Me.bscCodigoVehiculoUsado.Permitido = True
        Me.bscCodigoVehiculoUsado.PermitidoNoBackColor = System.Drawing.Color.FromArgb(CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer))
        Me.bscCodigoVehiculoUsado.PermitidoNoForeColor = System.Drawing.Color.Black
        Me.bscCodigoVehiculoUsado.PermitidoSiBackColor = System.Drawing.Color.White
        Me.bscCodigoVehiculoUsado.PermitidoSiForeColor = System.Drawing.Color.Black
        Me.bscCodigoVehiculoUsado.Selecciono = False
        Me.bscCodigoVehiculoUsado.Size = New System.Drawing.Size(130, 20)
        Me.bscCodigoVehiculoUsado.TabIndex = 5
        '
        'GroupBox3
        '
        Me.GroupBox3.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox3.Controls.Add(Me.lblUsados)
        Me.GroupBox3.Controls.Add(Me.txtUsados)
        Me.GroupBox3.Controls.Add(Me.bscCodigoCuentaBancariaTransfBanc)
        Me.GroupBox3.Controls.Add(Me.lblFechaTransferenciaBancaria)
        Me.GroupBox3.Controls.Add(Me.dtpFechaTransferencia)
        Me.GroupBox3.Controls.Add(Me.txtEfectivo)
        Me.GroupBox3.Controls.Add(Me.tbcPagosTarChe)
        Me.GroupBox3.Controls.Add(Me.lblEfectivo)
        Me.GroupBox3.Controls.Add(Me.bscCuentaBancariaTransfBanc)
        Me.GroupBox3.Controls.Add(Me.txtTarjetas)
        Me.GroupBox3.Controls.Add(Me.lblCheques)
        Me.GroupBox3.Controls.Add(Me.lblTarjetas)
        Me.GroupBox3.Controls.Add(Me.lblCuentaBancaria)
        Me.GroupBox3.Controls.Add(Me.lblTransferenciaBancaria)
        Me.GroupBox3.Controls.Add(Me.txtCheques)
        Me.GroupBox3.Controls.Add(Me.txtDiferencia)
        Me.GroupBox3.Controls.Add(Me.txtTransferenciaBancaria)
        Me.GroupBox3.Controls.Add(Me.lblDiferencia)
        Me.GroupBox3.Controls.Add(Me.lblTotalPago)
        Me.GroupBox3.Controls.Add(Me.txtTotalPago)
        Me.GroupBox3.Location = New System.Drawing.Point(0, 234)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(980, 287)
        Me.GroupBox3.TabIndex = 2
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Pagos"
        '
        'lblUsados
        '
        Me.lblUsados.AutoSize = True
        Me.lblUsados.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblUsados.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblUsados.LabelAsoc = Nothing
        Me.lblUsados.Location = New System.Drawing.Point(700, 7)
        Me.lblUsados.Name = "lblUsados"
        Me.lblUsados.Size = New System.Drawing.Size(43, 13)
        Me.lblUsados.TabIndex = 22
        Me.lblUsados.Text = "Usados"
        '
        'txtUsados
        '
        Me.txtUsados.BindearPropiedadControl = Nothing
        Me.txtUsados.BindearPropiedadEntidad = Nothing
        Me.txtUsados.ForeColorFocus = System.Drawing.Color.Red
        Me.txtUsados.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtUsados.Formato = "N2"
        Me.txtUsados.IsDecimal = True
        Me.txtUsados.IsNumber = True
        Me.txtUsados.IsPK = False
        Me.txtUsados.IsRequired = False
        Me.txtUsados.Key = ""
        Me.txtUsados.LabelAsoc = Me.lblUsados
        Me.txtUsados.Location = New System.Drawing.Point(703, 23)
        Me.txtUsados.Name = "txtUsados"
        Me.txtUsados.ReadOnly = True
        Me.txtUsados.Size = New System.Drawing.Size(69, 20)
        Me.txtUsados.TabIndex = 23
        Me.txtUsados.TabStop = False
        Me.txtUsados.Text = "0.00"
        Me.txtUsados.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'bscCodigoCuentaBancariaTransfBanc
        '
        Me.bscCodigoCuentaBancariaTransfBanc.ActivarFiltroEnGrilla = True
        Me.bscCodigoCuentaBancariaTransfBanc.BindearPropiedadControl = Nothing
        Me.bscCodigoCuentaBancariaTransfBanc.BindearPropiedadEntidad = Nothing
        Me.bscCodigoCuentaBancariaTransfBanc.ConfigBuscador = Nothing
        Me.bscCodigoCuentaBancariaTransfBanc.Datos = Nothing
        Me.bscCodigoCuentaBancariaTransfBanc.FilaDevuelta = Nothing
        Me.bscCodigoCuentaBancariaTransfBanc.ForeColorFocus = System.Drawing.Color.Red
        Me.bscCodigoCuentaBancariaTransfBanc.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.bscCodigoCuentaBancariaTransfBanc.IsDecimal = False
        Me.bscCodigoCuentaBancariaTransfBanc.IsNumber = False
        Me.bscCodigoCuentaBancariaTransfBanc.IsPK = False
        Me.bscCodigoCuentaBancariaTransfBanc.IsRequired = False
        Me.bscCodigoCuentaBancariaTransfBanc.Key = ""
        Me.bscCodigoCuentaBancariaTransfBanc.LabelAsoc = Me.lblCuentaBancaria
        Me.bscCodigoCuentaBancariaTransfBanc.Location = New System.Drawing.Point(936, 23)
        Me.bscCodigoCuentaBancariaTransfBanc.MaxLengh = "32767"
        Me.bscCodigoCuentaBancariaTransfBanc.Name = "bscCodigoCuentaBancariaTransfBanc"
        Me.bscCodigoCuentaBancariaTransfBanc.Permitido = True
        Me.bscCodigoCuentaBancariaTransfBanc.PermitidoNoBackColor = System.Drawing.Color.FromArgb(CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer))
        Me.bscCodigoCuentaBancariaTransfBanc.PermitidoNoForeColor = System.Drawing.Color.Black
        Me.bscCodigoCuentaBancariaTransfBanc.PermitidoSiBackColor = System.Drawing.Color.White
        Me.bscCodigoCuentaBancariaTransfBanc.PermitidoSiForeColor = System.Drawing.Color.Black
        Me.bscCodigoCuentaBancariaTransfBanc.Selecciono = False
        Me.bscCodigoCuentaBancariaTransfBanc.Size = New System.Drawing.Size(31, 20)
        Me.bscCodigoCuentaBancariaTransfBanc.TabIndex = 6
        Me.bscCodigoCuentaBancariaTransfBanc.Visible = False
        '
        'lblCuentaBancaria
        '
        Me.lblCuentaBancaria.AutoSize = True
        Me.lblCuentaBancaria.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblCuentaBancaria.LabelAsoc = Nothing
        Me.lblCuentaBancaria.Location = New System.Drawing.Point(237, 10)
        Me.lblCuentaBancaria.Name = "lblCuentaBancaria"
        Me.lblCuentaBancaria.Size = New System.Drawing.Size(71, 13)
        Me.lblCuentaBancaria.TabIndex = 4
        Me.lblCuentaBancaria.Text = "Cta. Bancaria"
        '
        'lblFechaTransferenciaBancaria
        '
        Me.lblFechaTransferenciaBancaria.AutoSize = True
        Me.lblFechaTransferenciaBancaria.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblFechaTransferenciaBancaria.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblFechaTransferenciaBancaria.LabelAsoc = Nothing
        Me.lblFechaTransferenciaBancaria.Location = New System.Drawing.Point(447, 7)
        Me.lblFechaTransferenciaBancaria.Name = "lblFechaTransferenciaBancaria"
        Me.lblFechaTransferenciaBancaria.Size = New System.Drawing.Size(105, 13)
        Me.lblFechaTransferenciaBancaria.TabIndex = 7
        Me.lblFechaTransferenciaBancaria.Text = "Fecha Transferencia"
        '
        'dtpFechaTransferencia
        '
        Me.dtpFechaTransferencia.BindearPropiedadControl = Nothing
        Me.dtpFechaTransferencia.BindearPropiedadEntidad = Nothing
        Me.dtpFechaTransferencia.CustomFormat = "dd/MM/yyyy"
        Me.dtpFechaTransferencia.ForeColorFocus = System.Drawing.Color.Red
        Me.dtpFechaTransferencia.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.dtpFechaTransferencia.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpFechaTransferencia.IsPK = False
        Me.dtpFechaTransferencia.IsRequired = False
        Me.dtpFechaTransferencia.Key = ""
        Me.dtpFechaTransferencia.LabelAsoc = Me.lblFechaTransferenciaBancaria
        Me.dtpFechaTransferencia.Location = New System.Drawing.Point(450, 23)
        Me.dtpFechaTransferencia.Name = "dtpFechaTransferencia"
        Me.dtpFechaTransferencia.Size = New System.Drawing.Size(101, 20)
        Me.dtpFechaTransferencia.TabIndex = 8
        '
        'txtEfectivo
        '
        Me.txtEfectivo.BindearPropiedadControl = Nothing
        Me.txtEfectivo.BindearPropiedadEntidad = Nothing
        Me.txtEfectivo.ForeColorFocus = System.Drawing.Color.Red
        Me.txtEfectivo.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtEfectivo.Formato = "N2"
        Me.txtEfectivo.IsDecimal = True
        Me.txtEfectivo.IsNumber = True
        Me.txtEfectivo.IsPK = False
        Me.txtEfectivo.IsRequired = False
        Me.txtEfectivo.Key = ""
        Me.txtEfectivo.LabelAsoc = Me.lblEfectivo
        Me.txtEfectivo.Location = New System.Drawing.Point(94, 26)
        Me.txtEfectivo.Name = "txtEfectivo"
        Me.txtEfectivo.Size = New System.Drawing.Size(69, 20)
        Me.txtEfectivo.TabIndex = 1
        Me.txtEfectivo.Text = "0,00"
        Me.txtEfectivo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblEfectivo
        '
        Me.lblEfectivo.AutoSize = True
        Me.lblEfectivo.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblEfectivo.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblEfectivo.LabelAsoc = Nothing
        Me.lblEfectivo.Location = New System.Drawing.Point(91, 10)
        Me.lblEfectivo.Name = "lblEfectivo"
        Me.lblEfectivo.Size = New System.Drawing.Size(36, 13)
        Me.lblEfectivo.TabIndex = 0
        Me.lblEfectivo.Text = "Pesos"
        '
        'tbcPagosTarChe
        '
        Me.tbcPagosTarChe.Alignment = System.Windows.Forms.TabAlignment.Left
        Me.tbcPagosTarChe.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.tbcPagosTarChe.Controls.Add(Me.tbpVehiculosUsados)
        Me.tbcPagosTarChe.Controls.Add(Me.tbpPagosCheques)
        Me.tbcPagosTarChe.Controls.Add(Me.tbpPagosTarjetas)
        Me.tbcPagosTarChe.Location = New System.Drawing.Point(6, 52)
        Me.tbcPagosTarChe.Multiline = True
        Me.tbcPagosTarChe.Name = "tbcPagosTarChe"
        Me.tbcPagosTarChe.SelectedIndex = 0
        Me.tbcPagosTarChe.Size = New System.Drawing.Size(968, 229)
        Me.tbcPagosTarChe.TabIndex = 21
        '
        'tbpVehiculosUsados
        '
        Me.tbpVehiculosUsados.BackColor = System.Drawing.SystemColors.Control
        Me.tbpVehiculosUsados.Controls.Add(Me.ugVehiculosUsados)
        Me.tbpVehiculosUsados.Controls.Add(Me.FlowLayoutPanel1)
        Me.tbpVehiculosUsados.Location = New System.Drawing.Point(23, 4)
        Me.tbpVehiculosUsados.Name = "tbpVehiculosUsados"
        Me.tbpVehiculosUsados.Size = New System.Drawing.Size(941, 221)
        Me.tbpVehiculosUsados.TabIndex = 2
        Me.tbpVehiculosUsados.Text = "Vehículos usados"
        '
        'ugVehiculosUsados
        '
        Appearance1.BackColor = System.Drawing.SystemColors.Window
        Appearance1.BorderColor = System.Drawing.SystemColors.InactiveCaption
        Me.ugVehiculosUsados.DisplayLayout.Appearance = Appearance1
        UltraGridColumn1.Header.Caption = "Patente"
        UltraGridColumn1.Header.VisiblePosition = 0
        UltraGridColumn1.Width = 80
        UltraGridColumn2.Header.VisiblePosition = 1
        UltraGridColumn2.Hidden = True
        UltraGridColumn3.Header.Caption = "Marca"
        UltraGridColumn3.Header.VisiblePosition = 2
        UltraGridColumn3.Width = 100
        UltraGridColumn4.Header.VisiblePosition = 3
        UltraGridColumn4.Hidden = True
        UltraGridColumn5.Header.Caption = "Modelo"
        UltraGridColumn5.Header.VisiblePosition = 4
        UltraGridColumn5.Width = 100
        UltraGridColumn6.Header.VisiblePosition = 9
        UltraGridColumn6.Width = 100
        UltraGridColumn7.Format = "dd/MM/yyyy"
        UltraGridColumn7.Header.Caption = "Vto. Seguro"
        UltraGridColumn7.Header.VisiblePosition = 10
        UltraGridColumn7.Hidden = True
        UltraGridColumn8.Header.VisiblePosition = 11
        UltraGridColumn8.Hidden = True
        UltraGridColumn9.Header.VisiblePosition = 12
        UltraGridColumn9.Hidden = True
        UltraGridColumn10.Header.VisiblePosition = 13
        UltraGridColumn10.Hidden = True
        UltraGridColumn11.Header.VisiblePosition = 14
        UltraGridColumn11.Hidden = True
        UltraGridColumn23.Header.VisiblePosition = 15
        UltraGridColumn23.Hidden = True
        UltraGridColumn13.Header.Caption = "Unidad"
        UltraGridColumn13.Header.VisiblePosition = 17
        Appearance2.TextHAlignAsString = "Right"
        UltraGridColumn14.CellAppearance = Appearance2
        UltraGridColumn14.Header.Caption = "Año"
        UltraGridColumn14.Header.VisiblePosition = 18
        UltraGridColumn14.Width = 40
        UltraGridColumn15.Header.Caption = "Medidas"
        UltraGridColumn15.Header.VisiblePosition = 19
        UltraGridColumn16.Header.Caption = "Llantas"
        UltraGridColumn16.Header.VisiblePosition = 20
        UltraGridColumn17.Header.Caption = "Auxilio"
        UltraGridColumn17.Header.VisiblePosition = 21
        UltraGridColumn17.Width = 50
        UltraGridColumn18.Header.Caption = "Neumáticos"
        UltraGridColumn18.Header.VisiblePosition = 22
        UltraGridColumn19.Header.Caption = "Otros"
        UltraGridColumn19.Header.VisiblePosition = 23
        UltraGridColumn20.Header.Caption = "Identificación"
        UltraGridColumn20.Header.VisiblePosition = 24
        UltraGridColumn20.Width = 80
        UltraGridColumn21.Header.Caption = "Observaciones"
        UltraGridColumn21.Header.VisiblePosition = 25
        UltraGridColumn22.Header.VisiblePosition = 26
        UltraGridColumn22.Hidden = True
        UltraGridColumn12.Header.Caption = "Tipo"
        UltraGridColumn12.Header.VisiblePosition = 16
        UltraGridColumn25.Header.Caption = "Estado"
        UltraGridColumn25.Header.VisiblePosition = 5
        Appearance3.TextHAlignAsString = "Right"
        UltraGridColumn24.CellAppearance = Appearance3
        UltraGridColumn24.Format = "N2"
        UltraGridColumn24.Header.Caption = "Precio Compra"
        UltraGridColumn24.Header.VisiblePosition = 7
        UltraGridColumn24.Width = 100
        UltraGridColumn26.Header.VisiblePosition = 27
        UltraGridColumn26.Hidden = True
        UltraGridColumn27.Header.VisiblePosition = 28
        UltraGridColumn27.Hidden = True
        UltraGridColumn28.Header.VisiblePosition = 29
        UltraGridColumn28.Hidden = True
        Appearance4.TextHAlignAsString = "Right"
        UltraGridColumn29.CellAppearance = Appearance4
        UltraGridColumn29.Format = "N2"
        UltraGridColumn29.Header.VisiblePosition = 8
        UltraGridColumn29.Hidden = True
        UltraGridColumn29.Width = 100
        Appearance5.TextHAlignAsString = "Right"
        UltraGridColumn30.CellAppearance = Appearance5
        UltraGridColumn30.Format = "N2"
        UltraGridColumn30.Header.Caption = "Precio"
        UltraGridColumn30.Header.VisiblePosition = 6
        UltraGridColumn30.Hidden = True
        UltraGridColumn30.Width = 100
        UltraGridColumn31.Header.VisiblePosition = 30
        UltraGridColumn31.Hidden = True
        UltraGridColumn32.Header.VisiblePosition = 31
        UltraGridColumn32.Hidden = True
        UltraGridColumn33.Header.VisiblePosition = 32
        UltraGridColumn33.Hidden = True
        UltraGridColumn34.Header.VisiblePosition = 33
        UltraGridColumn34.Hidden = True
        UltraGridColumn35.Header.VisiblePosition = 34
        UltraGridColumn35.Hidden = True
        UltraGridColumn36.Header.VisiblePosition = 35
        UltraGridColumn36.Hidden = True
        UltraGridColumn37.Header.VisiblePosition = 36
        UltraGridColumn37.Hidden = True
        UltraGridColumn38.Header.VisiblePosition = 37
        UltraGridColumn38.Hidden = True
        UltraGridColumn39.Header.VisiblePosition = 38
        UltraGridColumn39.Hidden = True
        UltraGridBand1.Columns.AddRange(New Object() {UltraGridColumn1, UltraGridColumn2, UltraGridColumn3, UltraGridColumn4, UltraGridColumn5, UltraGridColumn6, UltraGridColumn7, UltraGridColumn8, UltraGridColumn9, UltraGridColumn10, UltraGridColumn11, UltraGridColumn23, UltraGridColumn13, UltraGridColumn14, UltraGridColumn15, UltraGridColumn16, UltraGridColumn17, UltraGridColumn18, UltraGridColumn19, UltraGridColumn20, UltraGridColumn21, UltraGridColumn22, UltraGridColumn12, UltraGridColumn25, UltraGridColumn24, UltraGridColumn26, UltraGridColumn27, UltraGridColumn28, UltraGridColumn29, UltraGridColumn30, UltraGridColumn31, UltraGridColumn32, UltraGridColumn33, UltraGridColumn34, UltraGridColumn35, UltraGridColumn36, UltraGridColumn37, UltraGridColumn38, UltraGridColumn39})
        Me.ugVehiculosUsados.DisplayLayout.BandsSerializer.Add(UltraGridBand1)
        Me.ugVehiculosUsados.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.ugVehiculosUsados.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.[False]
        Appearance6.BackColor = System.Drawing.SystemColors.ActiveBorder
        Appearance6.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance6.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Appearance6.BorderColor = System.Drawing.SystemColors.Window
        Me.ugVehiculosUsados.DisplayLayout.GroupByBox.Appearance = Appearance6
        Appearance7.ForeColor = System.Drawing.SystemColors.GrayText
        Me.ugVehiculosUsados.DisplayLayout.GroupByBox.BandLabelAppearance = Appearance7
        Me.ugVehiculosUsados.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Appearance8.BackColor = System.Drawing.SystemColors.ControlLightLight
        Appearance8.BackColor2 = System.Drawing.SystemColors.Control
        Appearance8.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance8.ForeColor = System.Drawing.SystemColors.GrayText
        Me.ugVehiculosUsados.DisplayLayout.GroupByBox.PromptAppearance = Appearance8
        Me.ugVehiculosUsados.DisplayLayout.MaxBandDepth = 1
        Me.ugVehiculosUsados.DisplayLayout.MaxColScrollRegions = 1
        Me.ugVehiculosUsados.DisplayLayout.MaxRowScrollRegions = 1
        Appearance9.BackColor = System.Drawing.SystemColors.Window
        Appearance9.ForeColor = System.Drawing.SystemColors.ControlText
        Me.ugVehiculosUsados.DisplayLayout.Override.ActiveCellAppearance = Appearance9
        Appearance10.BackColor = System.Drawing.SystemColors.Highlight
        Appearance10.ForeColor = System.Drawing.SystemColors.HighlightText
        Me.ugVehiculosUsados.DisplayLayout.Override.ActiveRowAppearance = Appearance10
        Me.ugVehiculosUsados.DisplayLayout.Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.No
        Me.ugVehiculosUsados.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.[False]
        Me.ugVehiculosUsados.DisplayLayout.Override.AllowUpdate = Infragistics.Win.DefaultableBoolean.[False]
        Me.ugVehiculosUsados.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted
        Me.ugVehiculosUsados.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted
        Appearance11.BackColor = System.Drawing.SystemColors.Window
        Me.ugVehiculosUsados.DisplayLayout.Override.CardAreaAppearance = Appearance11
        Appearance12.BorderColor = System.Drawing.Color.Silver
        Appearance12.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter
        Me.ugVehiculosUsados.DisplayLayout.Override.CellAppearance = Appearance12
        Me.ugVehiculosUsados.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText
        Me.ugVehiculosUsados.DisplayLayout.Override.CellPadding = 0
        Appearance13.BackColor = System.Drawing.SystemColors.Control
        Appearance13.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance13.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element
        Appearance13.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance13.BorderColor = System.Drawing.SystemColors.Window
        Me.ugVehiculosUsados.DisplayLayout.Override.GroupByRowAppearance = Appearance13
        Appearance14.TextHAlignAsString = "Left"
        Me.ugVehiculosUsados.DisplayLayout.Override.HeaderAppearance = Appearance14
        Me.ugVehiculosUsados.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
        Me.ugVehiculosUsados.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand
        Appearance15.BackColor = System.Drawing.SystemColors.Window
        Appearance15.BorderColor = System.Drawing.Color.Silver
        Me.ugVehiculosUsados.DisplayLayout.Override.RowAppearance = Appearance15
        Me.ugVehiculosUsados.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[False]
        Appearance16.BackColor = System.Drawing.SystemColors.ControlLight
        Me.ugVehiculosUsados.DisplayLayout.Override.TemplateAddRowAppearance = Appearance16
        Me.ugVehiculosUsados.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill
        Me.ugVehiculosUsados.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate
        Me.ugVehiculosUsados.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy
        Me.ugVehiculosUsados.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ugVehiculosUsados.Location = New System.Drawing.Point(0, 0)
        Me.ugVehiculosUsados.Name = "ugVehiculosUsados"
        Me.ugVehiculosUsados.Size = New System.Drawing.Size(898, 221)
        Me.ugVehiculosUsados.TabIndex = 0
        Me.ugVehiculosUsados.Text = "UltraGrid1"
        '
        'FlowLayoutPanel1
        '
        Me.FlowLayoutPanel1.AutoSize = True
        Me.FlowLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.FlowLayoutPanel1.Controls.Add(Me.btnInsertarVehiculosUsados)
        Me.FlowLayoutPanel1.Controls.Add(Me.btnEditarVehiculosUsados)
        Me.FlowLayoutPanel1.Controls.Add(Me.btnEliminarVehiculosUsados)
        Me.FlowLayoutPanel1.Controls.Add(Me.btnAgregarVehiculoUsado)
        Me.FlowLayoutPanel1.Controls.Add(Me.bscCodigoVehiculo)
        Me.FlowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Right
        Me.FlowLayoutPanel1.Location = New System.Drawing.Point(898, 0)
        Me.FlowLayoutPanel1.Name = "FlowLayoutPanel1"
        Me.FlowLayoutPanel1.Size = New System.Drawing.Size(43, 221)
        Me.FlowLayoutPanel1.TabIndex = 5
        '
        'btnInsertarVehiculosUsados
        '
        Me.btnInsertarVehiculosUsados.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnInsertarVehiculosUsados.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.0!)
        Me.btnInsertarVehiculosUsados.Image = Global.Eniac.Win.My.Resources.Resources.add_32
        Me.btnInsertarVehiculosUsados.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnInsertarVehiculosUsados.Location = New System.Drawing.Point(3, 3)
        Me.btnInsertarVehiculosUsados.Name = "btnInsertarVehiculosUsados"
        Me.btnInsertarVehiculosUsados.Size = New System.Drawing.Size(37, 37)
        Me.btnInsertarVehiculosUsados.TabIndex = 1
        Me.btnInsertarVehiculosUsados.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnInsertarVehiculosUsados.UseVisualStyleBackColor = True
        '
        'btnEliminarVehiculosUsados
        '
        Me.btnEliminarVehiculosUsados.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnEliminarVehiculosUsados.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.0!)
        Me.btnEliminarVehiculosUsados.Image = Global.Eniac.Win.My.Resources.Resources.delete_32
        Me.btnEliminarVehiculosUsados.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnEliminarVehiculosUsados.Location = New System.Drawing.Point(3, 89)
        Me.btnEliminarVehiculosUsados.Name = "btnEliminarVehiculosUsados"
        Me.btnEliminarVehiculosUsados.Size = New System.Drawing.Size(37, 37)
        Me.btnEliminarVehiculosUsados.TabIndex = 3
        Me.btnEliminarVehiculosUsados.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnEliminarVehiculosUsados.UseVisualStyleBackColor = True
        '
        'btnAgregarVehiculoUsado
        '
        Me.btnAgregarVehiculoUsado.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnAgregarVehiculoUsado.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.0!)
        Me.btnAgregarVehiculoUsado.Image = Global.Eniac.Win.My.Resources.Resources.harddisk_add
        Me.btnAgregarVehiculoUsado.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnAgregarVehiculoUsado.Location = New System.Drawing.Point(3, 132)
        Me.btnAgregarVehiculoUsado.Name = "btnAgregarVehiculoUsado"
        Me.btnAgregarVehiculoUsado.Size = New System.Drawing.Size(37, 37)
        Me.btnAgregarVehiculoUsado.TabIndex = 2
        Me.btnAgregarVehiculoUsado.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnAgregarVehiculoUsado.UseVisualStyleBackColor = True
        '
        'bscCodigoVehiculo
        '
        Me.bscCodigoVehiculo.ActivarFiltroEnGrilla = True
        Me.bscCodigoVehiculo.BindearPropiedadControl = Nothing
        Me.bscCodigoVehiculo.BindearPropiedadEntidad = Nothing
        Me.bscCodigoVehiculo.ConfigBuscador = Nothing
        Me.bscCodigoVehiculo.Datos = Nothing
        Me.bscCodigoVehiculo.FilaDevuelta = Nothing
        Me.bscCodigoVehiculo.ForeColorFocus = System.Drawing.Color.Red
        Me.bscCodigoVehiculo.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.bscCodigoVehiculo.IsDecimal = False
        Me.bscCodigoVehiculo.IsNumber = False
        Me.bscCodigoVehiculo.IsPK = False
        Me.bscCodigoVehiculo.IsRequired = False
        Me.bscCodigoVehiculo.Key = ""
        Me.bscCodigoVehiculo.LabelAsoc = Me.lblCodProducto
        Me.bscCodigoVehiculo.Location = New System.Drawing.Point(3, 175)
        Me.bscCodigoVehiculo.MaxLengh = "32767"
        Me.bscCodigoVehiculo.Name = "bscCodigoVehiculo"
        Me.bscCodigoVehiculo.Permitido = True
        Me.bscCodigoVehiculo.PermitidoNoBackColor = System.Drawing.Color.FromArgb(CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer))
        Me.bscCodigoVehiculo.PermitidoNoForeColor = System.Drawing.Color.Black
        Me.bscCodigoVehiculo.PermitidoSiBackColor = System.Drawing.Color.White
        Me.bscCodigoVehiculo.PermitidoSiForeColor = System.Drawing.Color.Black
        Me.bscCodigoVehiculo.Selecciono = False
        Me.bscCodigoVehiculo.Size = New System.Drawing.Size(37, 20)
        Me.bscCodigoVehiculo.TabIndex = 4
        Me.bscCodigoVehiculo.Visible = False
        '
        'tbpPagosCheques
        '
        Me.tbpPagosCheques.BackColor = System.Drawing.SystemColors.Control
        Me.tbpPagosCheques.Controls.Add(Me.UcMedioPagoChequesTerceros1)
        Me.tbpPagosCheques.Location = New System.Drawing.Point(23, 4)
        Me.tbpPagosCheques.Name = "tbpPagosCheques"
        Me.tbpPagosCheques.Padding = New System.Windows.Forms.Padding(3)
        Me.tbpPagosCheques.Size = New System.Drawing.Size(941, 221)
        Me.tbpPagosCheques.TabIndex = 1
        Me.tbpPagosCheques.Text = "Cheques"
        '
        'UcMedioPagoChequesTerceros1
        '
        Me.UcMedioPagoChequesTerceros1.Cheques = Nothing
        Me.UcMedioPagoChequesTerceros1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.UcMedioPagoChequesTerceros1.Location = New System.Drawing.Point(3, 3)
        Me.UcMedioPagoChequesTerceros1.Name = "UcMedioPagoChequesTerceros1"
        Me.UcMedioPagoChequesTerceros1.Size = New System.Drawing.Size(935, 215)
        Me.UcMedioPagoChequesTerceros1.TabIndex = 0
        '
        'tbpPagosTarjetas
        '
        Me.tbpPagosTarjetas.BackColor = System.Drawing.SystemColors.Control
        Me.tbpPagosTarjetas.Controls.Add(Me.UcMedioPagoTarjeta1)
        Me.tbpPagosTarjetas.Location = New System.Drawing.Point(23, 4)
        Me.tbpPagosTarjetas.Name = "tbpPagosTarjetas"
        Me.tbpPagosTarjetas.Padding = New System.Windows.Forms.Padding(3)
        Me.tbpPagosTarjetas.Size = New System.Drawing.Size(941, 221)
        Me.tbpPagosTarjetas.TabIndex = 0
        Me.tbpPagosTarjetas.Text = "Tarjetas"
        '
        'UcMedioPagoTarjeta1
        '
        Me.UcMedioPagoTarjeta1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.UcMedioPagoTarjeta1.Location = New System.Drawing.Point(3, 3)
        Me.UcMedioPagoTarjeta1.Name = "UcMedioPagoTarjeta1"
        Me.UcMedioPagoTarjeta1.Size = New System.Drawing.Size(935, 215)
        Me.UcMedioPagoTarjeta1.TabIndex = 0
        Me.UcMedioPagoTarjeta1.Tarjetas = Nothing
        '
        'bscCuentaBancariaTransfBanc
        '
        Me.bscCuentaBancariaTransfBanc.ActivarFiltroEnGrilla = True
        Me.bscCuentaBancariaTransfBanc.BindearPropiedadControl = Nothing
        Me.bscCuentaBancariaTransfBanc.BindearPropiedadEntidad = Nothing
        Me.bscCuentaBancariaTransfBanc.ConfigBuscador = Nothing
        Me.bscCuentaBancariaTransfBanc.Datos = Nothing
        Me.bscCuentaBancariaTransfBanc.FilaDevuelta = Nothing
        Me.bscCuentaBancariaTransfBanc.ForeColorFocus = System.Drawing.Color.Red
        Me.bscCuentaBancariaTransfBanc.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.bscCuentaBancariaTransfBanc.IsDecimal = False
        Me.bscCuentaBancariaTransfBanc.IsNumber = False
        Me.bscCuentaBancariaTransfBanc.IsPK = False
        Me.bscCuentaBancariaTransfBanc.IsRequired = False
        Me.bscCuentaBancariaTransfBanc.Key = ""
        Me.bscCuentaBancariaTransfBanc.LabelAsoc = Me.lblCuentaBancaria
        Me.bscCuentaBancariaTransfBanc.Location = New System.Drawing.Point(240, 26)
        Me.bscCuentaBancariaTransfBanc.MaxLengh = "32767"
        Me.bscCuentaBancariaTransfBanc.Name = "bscCuentaBancariaTransfBanc"
        Me.bscCuentaBancariaTransfBanc.Permitido = True
        Me.bscCuentaBancariaTransfBanc.PermitidoNoBackColor = System.Drawing.Color.FromArgb(CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer))
        Me.bscCuentaBancariaTransfBanc.PermitidoNoForeColor = System.Drawing.Color.Black
        Me.bscCuentaBancariaTransfBanc.PermitidoSiBackColor = System.Drawing.Color.White
        Me.bscCuentaBancariaTransfBanc.PermitidoSiForeColor = System.Drawing.Color.Black
        Me.bscCuentaBancariaTransfBanc.Selecciono = False
        Me.bscCuentaBancariaTransfBanc.Size = New System.Drawing.Size(204, 20)
        Me.bscCuentaBancariaTransfBanc.TabIndex = 5
        '
        'txtTarjetas
        '
        Me.txtTarjetas.BindearPropiedadControl = Nothing
        Me.txtTarjetas.BindearPropiedadEntidad = Nothing
        Me.txtTarjetas.ForeColorFocus = System.Drawing.Color.Red
        Me.txtTarjetas.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtTarjetas.Formato = "N2"
        Me.txtTarjetas.IsDecimal = True
        Me.txtTarjetas.IsNumber = True
        Me.txtTarjetas.IsPK = False
        Me.txtTarjetas.IsRequired = False
        Me.txtTarjetas.Key = ""
        Me.txtTarjetas.LabelAsoc = Me.lblTarjetas
        Me.txtTarjetas.Location = New System.Drawing.Point(557, 23)
        Me.txtTarjetas.Name = "txtTarjetas"
        Me.txtTarjetas.ReadOnly = True
        Me.txtTarjetas.Size = New System.Drawing.Size(65, 20)
        Me.txtTarjetas.TabIndex = 13
        Me.txtTarjetas.TabStop = False
        Me.txtTarjetas.Text = "0.00"
        Me.txtTarjetas.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblTarjetas
        '
        Me.lblTarjetas.AutoSize = True
        Me.lblTarjetas.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblTarjetas.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblTarjetas.LabelAsoc = Nothing
        Me.lblTarjetas.Location = New System.Drawing.Point(554, 7)
        Me.lblTarjetas.Name = "lblTarjetas"
        Me.lblTarjetas.Size = New System.Drawing.Size(45, 13)
        Me.lblTarjetas.TabIndex = 12
        Me.lblTarjetas.Text = "Tarjetas"
        '
        'lblCheques
        '
        Me.lblCheques.AutoSize = True
        Me.lblCheques.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblCheques.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblCheques.LabelAsoc = Nothing
        Me.lblCheques.Location = New System.Drawing.Point(625, 7)
        Me.lblCheques.Name = "lblCheques"
        Me.lblCheques.Size = New System.Drawing.Size(49, 13)
        Me.lblCheques.TabIndex = 14
        Me.lblCheques.Text = "Cheques"
        '
        'lblTransferenciaBancaria
        '
        Me.lblTransferenciaBancaria.AutoSize = True
        Me.lblTransferenciaBancaria.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblTransferenciaBancaria.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblTransferenciaBancaria.LabelAsoc = Nothing
        Me.lblTransferenciaBancaria.Location = New System.Drawing.Point(166, 10)
        Me.lblTransferenciaBancaria.Name = "lblTransferenciaBancaria"
        Me.lblTransferenciaBancaria.Size = New System.Drawing.Size(72, 13)
        Me.lblTransferenciaBancaria.TabIndex = 2
        Me.lblTransferenciaBancaria.Text = "Transferencia"
        '
        'txtCheques
        '
        Me.txtCheques.BindearPropiedadControl = Nothing
        Me.txtCheques.BindearPropiedadEntidad = Nothing
        Me.txtCheques.ForeColorFocus = System.Drawing.Color.Red
        Me.txtCheques.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtCheques.Formato = "N2"
        Me.txtCheques.IsDecimal = True
        Me.txtCheques.IsNumber = True
        Me.txtCheques.IsPK = False
        Me.txtCheques.IsRequired = False
        Me.txtCheques.Key = ""
        Me.txtCheques.LabelAsoc = Me.lblCheques
        Me.txtCheques.Location = New System.Drawing.Point(628, 23)
        Me.txtCheques.Name = "txtCheques"
        Me.txtCheques.ReadOnly = True
        Me.txtCheques.Size = New System.Drawing.Size(69, 20)
        Me.txtCheques.TabIndex = 15
        Me.txtCheques.TabStop = False
        Me.txtCheques.Text = "0.00"
        Me.txtCheques.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtDiferencia
        '
        Me.txtDiferencia.BindearPropiedadControl = Nothing
        Me.txtDiferencia.BindearPropiedadEntidad = Nothing
        Me.txtDiferencia.ForeColorFocus = System.Drawing.Color.Red
        Me.txtDiferencia.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtDiferencia.Formato = "N2"
        Me.txtDiferencia.IsDecimal = True
        Me.txtDiferencia.IsNumber = True
        Me.txtDiferencia.IsPK = False
        Me.txtDiferencia.IsRequired = False
        Me.txtDiferencia.Key = ""
        Me.txtDiferencia.LabelAsoc = Me.lblDiferencia
        Me.txtDiferencia.Location = New System.Drawing.Point(853, 23)
        Me.txtDiferencia.Name = "txtDiferencia"
        Me.txtDiferencia.ReadOnly = True
        Me.txtDiferencia.Size = New System.Drawing.Size(69, 20)
        Me.txtDiferencia.TabIndex = 20
        Me.txtDiferencia.TabStop = False
        Me.txtDiferencia.Text = "0.00"
        Me.txtDiferencia.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblDiferencia
        '
        Me.lblDiferencia.AutoSize = True
        Me.lblDiferencia.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblDiferencia.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblDiferencia.LabelAsoc = Nothing
        Me.lblDiferencia.Location = New System.Drawing.Point(853, 7)
        Me.lblDiferencia.Name = "lblDiferencia"
        Me.lblDiferencia.Size = New System.Drawing.Size(55, 13)
        Me.lblDiferencia.TabIndex = 19
        Me.lblDiferencia.Text = "Diferencia"
        '
        'txtTransferenciaBancaria
        '
        Me.txtTransferenciaBancaria.BindearPropiedadControl = Nothing
        Me.txtTransferenciaBancaria.BindearPropiedadEntidad = Nothing
        Me.txtTransferenciaBancaria.ForeColorFocus = System.Drawing.Color.Red
        Me.txtTransferenciaBancaria.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtTransferenciaBancaria.Formato = "N2"
        Me.txtTransferenciaBancaria.IsDecimal = True
        Me.txtTransferenciaBancaria.IsNumber = True
        Me.txtTransferenciaBancaria.IsPK = False
        Me.txtTransferenciaBancaria.IsRequired = False
        Me.txtTransferenciaBancaria.Key = ""
        Me.txtTransferenciaBancaria.LabelAsoc = Me.lblTransferenciaBancaria
        Me.txtTransferenciaBancaria.Location = New System.Drawing.Point(169, 26)
        Me.txtTransferenciaBancaria.Name = "txtTransferenciaBancaria"
        Me.txtTransferenciaBancaria.Size = New System.Drawing.Size(65, 20)
        Me.txtTransferenciaBancaria.TabIndex = 3
        Me.txtTransferenciaBancaria.Text = "0.00"
        Me.txtTransferenciaBancaria.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblTotalPago
        '
        Me.lblTotalPago.AutoSize = True
        Me.lblTotalPago.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblTotalPago.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblTotalPago.LabelAsoc = Nothing
        Me.lblTotalPago.Location = New System.Drawing.Point(775, 10)
        Me.lblTotalPago.Name = "lblTotalPago"
        Me.lblTotalPago.Size = New System.Drawing.Size(59, 13)
        Me.lblTotalPago.TabIndex = 17
        Me.lblTotalPago.Text = "Total Pago"
        '
        'txtTotalPago
        '
        Me.txtTotalPago.BindearPropiedadControl = Nothing
        Me.txtTotalPago.BindearPropiedadEntidad = Nothing
        Me.txtTotalPago.ForeColorFocus = System.Drawing.Color.Red
        Me.txtTotalPago.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtTotalPago.Formato = "N2"
        Me.txtTotalPago.IsDecimal = True
        Me.txtTotalPago.IsNumber = True
        Me.txtTotalPago.IsPK = False
        Me.txtTotalPago.IsRequired = False
        Me.txtTotalPago.Key = ""
        Me.txtTotalPago.LabelAsoc = Me.lblTotalPago
        Me.txtTotalPago.Location = New System.Drawing.Point(778, 23)
        Me.txtTotalPago.Name = "txtTotalPago"
        Me.txtTotalPago.ReadOnly = True
        Me.txtTotalPago.Size = New System.Drawing.Size(69, 20)
        Me.txtTotalPago.TabIndex = 18
        Me.txtTotalPago.TabStop = False
        Me.txtTotalPago.Text = "0.00"
        Me.txtTotalPago.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'btnEditarVehiculosUsados
        '
        Me.btnEditarVehiculosUsados.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnEditarVehiculosUsados.BackgroundImage = Global.Eniac.Win.My.Resources.Resources.document_edit
        Me.btnEditarVehiculosUsados.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.btnEditarVehiculosUsados.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.0!)
        Me.btnEditarVehiculosUsados.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnEditarVehiculosUsados.Location = New System.Drawing.Point(3, 46)
        Me.btnEditarVehiculosUsados.Name = "btnEditarVehiculosUsados"
        Me.btnEditarVehiculosUsados.Size = New System.Drawing.Size(37, 37)
        Me.btnEditarVehiculosUsados.TabIndex = 5
        Me.btnEditarVehiculosUsados.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnEditarVehiculosUsados.UseVisualStyleBackColor = True
        '
        'ConcesionarioOperacionesDetalle
        '
        Me.AcceptButton = Nothing
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(980, 557)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Cursor = System.Windows.Forms.Cursors.Default
        Me.KeyPreview = True
        Me.Name = "ConcesionarioOperacionesDetalle"
        Me.Text = "Operación"
        Me.Controls.SetChildIndex(Me.btnCancelar, 0)
        Me.Controls.SetChildIndex(Me.btnAceptar, 0)
        Me.Controls.SetChildIndex(Me.btnCopiar, 0)
        Me.Controls.SetChildIndex(Me.btnAplicar, 0)
        Me.Controls.SetChildIndex(Me.GroupBox1, 0)
        Me.Controls.SetChildIndex(Me.GroupBox2, 0)
        Me.Controls.SetChildIndex(Me.GroupBox3, 0)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.pnlTipoOperacion.ResumeLayout(False)
        Me.pnlTipoOperacion.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel1.PerformLayout()
        Me.tbcUnidadVendida.ResumeLayout(False)
        Me.tbp0Km.ResumeLayout(False)
        Me.tbp0Km.PerformLayout()
        Me.tbpUsado.ResumeLayout(False)
        Me.tbpUsado.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.tbcPagosTarChe.ResumeLayout(False)
        Me.tbpVehiculosUsados.ResumeLayout(False)
        Me.tbpVehiculosUsados.PerformLayout()
        CType(Me.ugVehiculosUsados, System.ComponentModel.ISupportInitialize).EndInit()
        Me.FlowLayoutPanel1.ResumeLayout(False)
        Me.tbpPagosCheques.ResumeLayout(False)
        Me.tbpPagosTarjetas.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents lblMarcaVehiculo As Controles.Label
   Friend WithEvents cmbMarca As Controles.ComboBox
   Friend WithEvents dtpFechaOperacion As Controles.DateTimePicker
   Friend WithEvents lblFecha As Controles.Label
   Friend WithEvents lblNumeroOperacion As Controles.Label
   Friend WithEvents txtNumeroOperacion As Controles.TextBox
   Friend WithEvents txtSecuenciaOperacion As Controles.TextBox
   Friend WithEvents bscCliente As Controles.Buscador2
   Friend WithEvents lblNombre As Controles.Label
   Friend WithEvents llbCliente As Controles.LinkLabel
   Friend WithEvents bscCodigoCliente As Controles.Buscador2
   Friend WithEvents lblCodigoCliente As Controles.Label
   Friend WithEvents lblCliente As Controles.Label
   Friend WithEvents GroupBox1 As GroupBox
   Friend WithEvents cmbTipoDocCliente As Controles.ComboBox
   Friend WithEvents lblNroDocCliente As Controles.Label
   Friend WithEvents lblTipoDocCliente As Controles.Label
   Friend WithEvents txtNroDocCliente As Controles.TextBox
   Friend WithEvents lblCategoriaFiscal As Controles.Label
   Friend WithEvents cmbCategoriaFiscal As Controles.ComboBox
   Friend WithEvents txtTelefonos As Controles.TextBox
   Friend WithEvents lblTelefonos As Controles.Label
   Friend WithEvents lblCUIT As Controles.Label
   Friend WithEvents txtCUITCliente As Controles.TextBox
   Friend WithEvents GroupBox2 As GroupBox
   Friend WithEvents btnAdicionales As Button
   Friend WithEvents btnCaracteristicas As Button
   Friend WithEvents tbcUnidadVendida As TabControl
   Friend WithEvents tbp0Km As TabPage
    Friend WithEvents tbpUsado As TabPage
    Friend WithEvents lnkProducto As LinkLabel
    Friend WithEvents bscCodigoProducto2 As Controles.Buscador2
    Friend WithEvents lblCodProducto As Controles.Label
   Friend WithEvents lblProducto As Controles.Label
   Friend WithEvents pnlTipoOperacion As FlowLayoutPanel
   Friend WithEvents radUsado As RadioButton
   Friend WithEvents radCeroKm As RadioButton
   Friend WithEvents bscProducto2 As Controles.Buscador2
   Friend WithEvents txtCantidadProducto As Controles.TextBox
    Friend WithEvents lblCantidad As Controles.Label
    Friend WithEvents lblPrecio As Controles.Label
    Friend WithEvents txtPrecioProducto As Controles.TextBox
    Friend WithEvents txtTotalGeneral As Controles.TextBox
    Friend WithEvents lblTotalGeneral As Controles.Label
    Friend WithEvents txtImporteTotalAdicionales As Controles.TextBox
    Friend WithEvents txtImporteTotalCaracteristicas As Controles.TextBox
    Friend WithEvents llbTotalProducto As Controles.Label
    Friend WithEvents txtTotalProducto As Controles.TextBox
    Friend WithEvents GroupBox3 As GroupBox
    Friend WithEvents bscCodigoCuentaBancariaTransfBanc As Controles.Buscador2
    Friend WithEvents lblCuentaBancaria As Controles.Label
    Friend WithEvents lblFechaTransferenciaBancaria As Controles.Label
    Friend WithEvents dtpFechaTransferencia As Controles.DateTimePicker
    Friend WithEvents txtEfectivo As Controles.TextBox
    Friend WithEvents lblEfectivo As Controles.Label
    Friend WithEvents tbcPagosTarChe As TabControl
    Friend WithEvents tbpPagosTarjetas As TabPage
    Friend WithEvents tbpPagosCheques As TabPage
    Friend WithEvents bscCuentaBancariaTransfBanc As Controles.Buscador2
    Friend WithEvents txtTarjetas As Controles.TextBox
    Friend WithEvents lblTarjetas As Controles.Label
    Friend WithEvents lblCheques As Controles.Label
    Friend WithEvents lblTransferenciaBancaria As Controles.Label
    Friend WithEvents txtCheques As Controles.TextBox
    Friend WithEvents txtDiferencia As Controles.TextBox
    Friend WithEvents lblDiferencia As Controles.Label
    Friend WithEvents txtTransferenciaBancaria As Controles.TextBox
    Friend WithEvents lblTotalPago As Controles.Label
    Friend WithEvents txtTotalPago As Controles.TextBox
    Friend WithEvents tbpVehiculosUsados As TabPage
    Friend WithEvents btnInsertarVehiculosUsados As Controles.Button
    Friend WithEvents btnEliminarVehiculosUsados As Controles.Button
    Friend WithEvents ugVehiculosUsados As UltraGrid
    Friend WithEvents txtCotizacionDolar As Controles.TextBox
    Friend WithEvents lblCotizacionDolar As Controles.Label
    Friend WithEvents lblAnioOperacion As Controles.Label
    Friend WithEvents txtAnioOperacion As Controles.TextBox
    Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
    Friend WithEvents UcMedioPagoTarjeta1 As ucMedioPagoTarjeta
    Friend WithEvents UcMedioPagoChequesTerceros1 As ucMedioPagoChequesTerceros
    Friend WithEvents lblUsados As Controles.Label
    Friend WithEvents txtUsados As Controles.TextBox
    Friend WithEvents btnAgregarVehiculoUsado As Controles.Button
    Friend WithEvents FlowLayoutPanel1 As FlowLayoutPanel
    Friend WithEvents bscCodigoVehiculo As Controles.Buscador2
    Friend WithEvents lblNombreProducto As Controles.Label
    Friend WithEvents btnFacturar As Button
    Friend WithEvents btnGenerarRecibo As Button
    Friend WithEvents Label1 As Controles.Label
    Friend WithEvents bscCodigoVehiculoUsado As Controles.Buscador2
    Friend WithEvents txtPrecioListaUsado As Controles.TextBox
    Friend WithEvents lblPrecioListaUsado As Controles.Label
    Friend WithEvents txtPrecioVentaUsado As Controles.TextBox
    Friend WithEvents lblPrecioVentaUsado As Controles.Label
    Friend WithEvents txtModeloUsado As Controles.TextBox
    Friend WithEvents txtMarcaUsado As Controles.TextBox
    Friend WithEvents lblModeloUsado As Controles.Label
    Friend WithEvents lblMarcaUsado As Controles.Label
    Friend WithEvents pnlColorPrecioLista As Panel
    Friend WithEvents txtMaximoActualizadoUsado As Controles.TextBox
    Friend WithEvents txtMinimoActualizadoUsado As Controles.TextBox
    Friend WithEvents btnEditarVehiculosUsados As Controles.Button
End Class
