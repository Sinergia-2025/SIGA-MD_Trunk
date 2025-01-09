<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FichasABM
   Inherits Eniac.Win.BaseForm

   'Form overrides dispose to clean up the component list.
   <System.Diagnostics.DebuggerNonUserCode()> _
   Protected Overrides Sub Dispose(ByVal disposing As Boolean)
      If disposing AndAlso components IsNot Nothing Then
         components.Dispose()
      End If
      MyBase.Dispose(disposing)
   End Sub

   'Required by the Windows Form Designer
   Private components As System.ComponentModel.IContainer

   'NOTE: The following procedure is required by the Windows Form Designer
   'It can be modified using the Windows Form Designer.  
   'Do not modify it using the code editor.
   <System.Diagnostics.DebuggerStepThrough()> _
   Private Sub InitializeComponent()
      Me.components = New System.ComponentModel.Container()
      Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FichasABM))
      Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
      Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
      Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
      Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
      Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
      Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
      Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
      Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
      Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
      Dim DataGridViewCellStyle15 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
      Dim DataGridViewCellStyle16 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
      Dim DataGridViewCellStyle17 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
      Dim DataGridViewCellStyle21 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
      Dim DataGridViewCellStyle22 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
      Dim DataGridViewCellStyle18 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
      Dim DataGridViewCellStyle19 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
      Dim DataGridViewCellStyle20 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
      Dim DataGridViewCellStyle23 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
      Dim DataGridViewCellStyle10 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
      Dim DataGridViewCellStyle11 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
      Dim DataGridViewCellStyle12 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
      Dim DataGridViewCellStyle13 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
      Dim DataGridViewCellStyle14 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
      Me.imgIconos = New System.Windows.Forms.ImageList(Me.components)
      Me.tlpMensaje = New System.Windows.Forms.ToolTip(Me.components)
      Me.txtPrecio = New Eniac.Controles.TextBox()
      Me.lblPrecio = New Eniac.Controles.Label()
      Me.tspFichas = New System.Windows.Forms.ToolStrip()
      Me.tsbNuevo = New System.Windows.Forms.ToolStripButton()
      Me.tsbPago = New System.Windows.Forms.ToolStripButton()
      Me.tsbImprimirFicha = New System.Windows.Forms.ToolStripButton()
      Me.tsbImpFichaCliente = New System.Windows.Forms.ToolStripButton()
      Me.tsbAnular = New System.Windows.Forms.ToolStripButton()
      Me.tsbDevolverPago = New System.Windows.Forms.ToolStripButton()
      Me.tsbRevisado = New System.Windows.Forms.ToolStripButton()
      Me.tsbSalir = New System.Windows.Forms.ToolStripButton()
      Me.tbcFichas = New System.Windows.Forms.TabControl()
      Me.tbpProductos = New System.Windows.Forms.TabPage()
      Me.lblProveedor = New Eniac.Controles.Label()
      Me.bscProveedor = New Eniac.Controles.Buscador()
      Me.txtGarantia = New Eniac.Controles.TextBox()
      Me.lblGarantia = New Eniac.Controles.Label()
      Me.dtpEntrego = New Eniac.Controles.DateTimePicker()
      Me.lblFechaEntrega = New Eniac.Controles.Label()
      Me.txtStock = New Eniac.Controles.TextBox()
      Me.llbTotalProducto = New Eniac.Controles.Label()
      Me.lblStock = New Eniac.Controles.Label()
      Me.bscProducto = New Eniac.Controles.Buscador2()
      Me.lblProducto = New Eniac.Controles.Label()
      Me.btnEliminar = New Eniac.Controles.Button()
      Me.btnInsertar = New Eniac.Controles.Button()
      Me.txtTotalProducto = New Eniac.Controles.TextBox()
      Me.txtCantidad = New Eniac.Controles.TextBox()
      Me.lblCantidad = New Eniac.Controles.Label()
      Me.dtgProductos = New Eniac.Controles.DataGridView()
      Me.IdProducto = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.IdCliente = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.NombreCliente = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.ProductoDesc = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.Cantidad = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.Precio = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.Importe = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.FechaEntrega = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.Garantia = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.NroOperacion = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.Usuario = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.Password = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.IdSucursal = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.tbpPagos = New System.Windows.Forms.TabPage()
      Me.txtSaldo = New Eniac.Controles.TextBox()
      Me.lblSaldo = New Eniac.Controles.Label()
      Me.dgvPagos = New Eniac.Controles.DataGridView()
      Me.dgvCuotas = New Eniac.Controles.DataGridView()
      Me.NroCuota = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.IdCliente1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.FechaVencimiento = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.Saldo = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.UsuarioPagos = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.PasswordPagos = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.NroOperacionPago = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.NroDocumentoPago = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.TipoDocumentoPago = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.ImportePago = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.IdSucursalCuotas = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.grbTotales = New System.Windows.Forms.GroupBox()
      Me.btnGrabar = New Eniac.Controles.Button()
      Me.grbDetallePago = New System.Windows.Forms.GroupBox()
      Me.txtCuotas = New Eniac.Controles.TextBox()
      Me.lblCuotas = New Eniac.Controles.Label()
      Me.txtTotalCuotas = New Eniac.Controles.TextBox()
      Me.lblTotalCuotas = New Eniac.Controles.Label()
      Me.cmbFormaPago = New Eniac.Controles.ComboBox()
      Me.lblFormaPago = New Eniac.Controles.Label()
      Me.txtImpCuota = New Eniac.Controles.TextBox()
      Me.lblImpCuota = New Eniac.Controles.Label()
      Me.txtIntereses = New Eniac.Controles.TextBox()
      Me.lblIntereses = New Eniac.Controles.Label()
      Me.txtTotal = New Eniac.Controles.TextBox()
      Me.lblTotal = New Eniac.Controles.Label()
      Me.txtSubTotal = New Eniac.Controles.TextBox()
      Me.lblSubTotal = New Eniac.Controles.Label()
      Me.txtAnticipo = New Eniac.Controles.TextBox()
      Me.lblAnticipo = New Eniac.Controles.Label()
      Me.txtBruto = New Eniac.Controles.TextBox()
      Me.lblBruto = New Eniac.Controles.Label()
      Me.tbpCartasEmitidas = New System.Windows.Forms.TabPage()
      Me.dgvCartasEmitidas = New Eniac.Controles.DataGridView()
      Me.TipoCarta = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.FechaEnvio = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.TipoDocumentoGarante = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.NroDocumentoGarante = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.NombreGarante = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.UsuarioCartas = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.stsPie = New System.Windows.Forms.StatusStrip()
      Me.grbCliente = New System.Windows.Forms.GroupBox()
      Me.cmbCajas = New Eniac.Controles.ComboBox()
      Me.lblCaja = New Eniac.Controles.Label()
      Me.llbCliente = New Eniac.Controles.LinkLabel()
      Me.bscDireccion = New Eniac.Controles.Buscador()
      Me.lblDireccion = New Eniac.Controles.Label()
      Me.cmbVendedor = New Eniac.Controles.ComboBox()
      Me.lblVendedor = New Eniac.Controles.Label()
      Me.cmbCobrador = New Eniac.Controles.ComboBox()
      Me.lblCobrador = New Eniac.Controles.Label()
      Me.llbOperacion = New Eniac.Controles.LinkLabel()
      Me.txtComentario = New Eniac.Controles.TextBox()
      Me.lblComentario = New Eniac.Controles.Label()
      Me.bscCodigoCliente = New Eniac.Controles.Buscador2()
      Me.lblCodigoCliente = New Eniac.Controles.Label()
      Me.dtpFecha = New Eniac.Controles.DateTimePicker()
      Me.lblFecha = New Eniac.Controles.Label()
      Me.bscCliente = New Eniac.Controles.Buscador2()
      Me.lblNombre = New Eniac.Controles.Label()
      Me.txtTelefono = New Eniac.Controles.TextBox()
      Me.lblTelefono = New Eniac.Controles.Label()
      Me.txtCP = New Eniac.Controles.TextBox()
      Me.lblCodPostal = New Eniac.Controles.Label()
      Me.txtLocalidad = New Eniac.Controles.TextBox()
      Me.lblLocalidad = New Eniac.Controles.Label()
      Me.txtNroOperacion = New Eniac.Controles.TextBox()
      Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.DataGridViewTextBoxColumn9 = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.DataGridViewTextBoxColumn4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.DataGridViewTextBoxColumn5 = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.DataGridViewTextBoxColumn6 = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.DataGridViewTextBoxColumn7 = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.DataGridViewTextBoxColumn8 = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.IdCliente2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.NombreCobradorPago = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.IdCobrador = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.IdSucursalPago = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.FichaPagoAjuste = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.IdCaja = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.NumeroPlanilla = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.NumeroMovimiento = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.tspFichas.SuspendLayout()
      Me.tbcFichas.SuspendLayout()
      Me.tbpProductos.SuspendLayout()
      CType(Me.dtgProductos, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.tbpPagos.SuspendLayout()
      CType(Me.dgvPagos, System.ComponentModel.ISupportInitialize).BeginInit()
      CType(Me.dgvCuotas, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.grbTotales.SuspendLayout()
      Me.grbDetallePago.SuspendLayout()
      Me.tbpCartasEmitidas.SuspendLayout()
      CType(Me.dgvCartasEmitidas, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.grbCliente.SuspendLayout()
      Me.SuspendLayout()
      '
      'imgIconos
      '
      Me.imgIconos.ImageStream = CType(resources.GetObject("imgIconos.ImageStream"), System.Windows.Forms.ImageListStreamer)
      Me.imgIconos.TransparentColor = System.Drawing.Color.Transparent
      Me.imgIconos.Images.SetKeyName(0, "row_add.ico")
      Me.imgIconos.Images.SetKeyName(1, "row_delete.ico")
      Me.imgIconos.Images.SetKeyName(2, "disk_blue.ico")
      '
      'tlpMensaje
      '
      Me.tlpMensaje.IsBalloon = True
      Me.tlpMensaje.ShowAlways = True
      '
      'txtPrecio
      '
      Me.txtPrecio.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.txtPrecio.BindearPropiedadControl = Nothing
      Me.txtPrecio.BindearPropiedadEntidad = Nothing
      Me.txtPrecio.ForeColorFocus = System.Drawing.Color.Red
      Me.txtPrecio.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtPrecio.Formato = "##0.00"
      Me.txtPrecio.IsDecimal = True
      Me.txtPrecio.IsNumber = True
      Me.txtPrecio.IsPK = False
      Me.txtPrecio.IsRequired = False
      Me.txtPrecio.Key = ""
      Me.txtPrecio.LabelAsoc = Me.lblPrecio
      Me.txtPrecio.Location = New System.Drawing.Point(300, 22)
      Me.txtPrecio.Name = "txtPrecio"
      Me.txtPrecio.Size = New System.Drawing.Size(55, 20)
      Me.txtPrecio.TabIndex = 3
      Me.txtPrecio.Text = "0.00"
      Me.txtPrecio.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      Me.tlpMensaje.SetToolTip(Me.txtPrecio, "Cargar el precio de producto")
      '
      'lblPrecio
      '
      Me.lblPrecio.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.lblPrecio.AutoSize = True
      Me.lblPrecio.LabelAsoc = Nothing
      Me.lblPrecio.Location = New System.Drawing.Point(302, 6)
      Me.lblPrecio.Name = "lblPrecio"
      Me.lblPrecio.Size = New System.Drawing.Size(37, 13)
      Me.lblPrecio.TabIndex = 5
      Me.lblPrecio.Text = "Precio"
      '
      'tspFichas
      '
      Me.tspFichas.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsbNuevo, Me.tsbPago, Me.tsbImprimirFicha, Me.tsbImpFichaCliente, Me.tsbAnular, Me.tsbDevolverPago, Me.tsbRevisado, Me.tsbSalir})
      Me.tspFichas.Location = New System.Drawing.Point(0, 0)
      Me.tspFichas.Name = "tspFichas"
      Me.tspFichas.Size = New System.Drawing.Size(881, 25)
      Me.tspFichas.TabIndex = 2
      Me.tspFichas.Text = "ToolStrip1"
      '
      'tsbNuevo
      '
      Me.tsbNuevo.Image = Global.Eniac.Win.My.Resources.Resources.id_card_add
      Me.tsbNuevo.ImageTransparentColor = System.Drawing.Color.Magenta
      Me.tsbNuevo.Name = "tsbNuevo"
      Me.tsbNuevo.Size = New System.Drawing.Size(85, 22)
      Me.tsbNuevo.Text = "&Nuevo (F5)"
      '
      'tsbPago
      '
      Me.tsbPago.Enabled = False
      Me.tsbPago.Image = Global.Eniac.Win.My.Resources.Resources.money2
      Me.tsbPago.ImageTransparentColor = System.Drawing.Color.Magenta
      Me.tsbPago.Name = "tsbPago"
      Me.tsbPago.Size = New System.Drawing.Size(54, 22)
      Me.tsbPago.Text = "&Pago"
      '
      'tsbImprimirFicha
      '
      Me.tsbImprimirFicha.Enabled = False
      Me.tsbImprimirFicha.Image = Global.Eniac.Win.My.Resources.Resources.printer
      Me.tsbImprimirFicha.ImageTransparentColor = System.Drawing.Color.Magenta
      Me.tsbImprimirFicha.Name = "tsbImprimirFicha"
      Me.tsbImprimirFicha.Size = New System.Drawing.Size(104, 22)
      Me.tsbImprimirFicha.Text = "&Imprimir Ficha"
      '
      'tsbImpFichaCliente
      '
      Me.tsbImpFichaCliente.Enabled = False
      Me.tsbImpFichaCliente.Image = Global.Eniac.Win.My.Resources.Resources.printer
      Me.tsbImpFichaCliente.ImageTransparentColor = System.Drawing.Color.Magenta
      Me.tsbImpFichaCliente.Name = "tsbImpFichaCliente"
      Me.tsbImpFichaCliente.Size = New System.Drawing.Size(144, 22)
      Me.tsbImpFichaCliente.Text = "Imprimir Fic&ha Cliente"
      '
      'tsbAnular
      '
      Me.tsbAnular.Enabled = False
      Me.tsbAnular.Image = Global.Eniac.Win.My.Resources.Resources.id_card_delete
      Me.tsbAnular.ImageTransparentColor = System.Drawing.Color.Magenta
      Me.tsbAnular.Name = "tsbAnular"
      Me.tsbAnular.Size = New System.Drawing.Size(62, 22)
      Me.tsbAnular.Text = "&Anular"
      '
      'tsbDevolverPago
      '
      Me.tsbDevolverPago.Enabled = False
      Me.tsbDevolverPago.Image = Global.Eniac.Win.My.Resources.Resources.money_envelope
      Me.tsbDevolverPago.ImageTransparentColor = System.Drawing.Color.Magenta
      Me.tsbDevolverPago.Name = "tsbDevolverPago"
      Me.tsbDevolverPago.Size = New System.Drawing.Size(103, 22)
      Me.tsbDevolverPago.Text = "De&volver Pago"
      '
      'tsbRevisado
      '
      Me.tsbRevisado.Image = Global.Eniac.Win.My.Resources.Resources.document_check
      Me.tsbRevisado.ImageTransparentColor = System.Drawing.Color.Magenta
      Me.tsbRevisado.Name = "tsbRevisado"
      Me.tsbRevisado.Size = New System.Drawing.Size(74, 22)
      Me.tsbRevisado.Text = "&Revisado"
      Me.tsbRevisado.Visible = False
      '
      'tsbSalir
      '
      Me.tsbSalir.Image = Global.Eniac.Win.My.Resources.Resources.redo
      Me.tsbSalir.ImageTransparentColor = System.Drawing.Color.Magenta
      Me.tsbSalir.Name = "tsbSalir"
      Me.tsbSalir.Size = New System.Drawing.Size(59, 22)
      Me.tsbSalir.Text = "&Cerrar"
      '
      'tbcFichas
      '
      Me.tbcFichas.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.tbcFichas.Controls.Add(Me.tbpProductos)
      Me.tbcFichas.Controls.Add(Me.tbpPagos)
      Me.tbcFichas.Controls.Add(Me.tbpCartasEmitidas)
      Me.tbcFichas.Location = New System.Drawing.Point(12, 173)
      Me.tbcFichas.Name = "tbcFichas"
      Me.tbcFichas.SelectedIndex = 0
      Me.tbcFichas.Size = New System.Drawing.Size(857, 310)
      Me.tbcFichas.TabIndex = 1
      Me.tbcFichas.TabStop = False
      '
      'tbpProductos
      '
      Me.tbpProductos.Controls.Add(Me.lblProveedor)
      Me.tbpProductos.Controls.Add(Me.bscProveedor)
      Me.tbpProductos.Controls.Add(Me.txtGarantia)
      Me.tbpProductos.Controls.Add(Me.lblGarantia)
      Me.tbpProductos.Controls.Add(Me.dtpEntrego)
      Me.tbpProductos.Controls.Add(Me.lblFechaEntrega)
      Me.tbpProductos.Controls.Add(Me.txtStock)
      Me.tbpProductos.Controls.Add(Me.lblStock)
      Me.tbpProductos.Controls.Add(Me.bscProducto)
      Me.tbpProductos.Controls.Add(Me.btnEliminar)
      Me.tbpProductos.Controls.Add(Me.btnInsertar)
      Me.tbpProductos.Controls.Add(Me.txtTotalProducto)
      Me.tbpProductos.Controls.Add(Me.llbTotalProducto)
      Me.tbpProductos.Controls.Add(Me.txtPrecio)
      Me.tbpProductos.Controls.Add(Me.lblPrecio)
      Me.tbpProductos.Controls.Add(Me.txtCantidad)
      Me.tbpProductos.Controls.Add(Me.lblCantidad)
      Me.tbpProductos.Controls.Add(Me.lblProducto)
      Me.tbpProductos.Controls.Add(Me.dtgProductos)
      Me.tbpProductos.Location = New System.Drawing.Point(4, 22)
      Me.tbpProductos.Name = "tbpProductos"
      Me.tbpProductos.Padding = New System.Windows.Forms.Padding(3)
      Me.tbpProductos.Size = New System.Drawing.Size(849, 284)
      Me.tbpProductos.TabIndex = 0
      Me.tbpProductos.Text = "Productos"
      Me.tbpProductos.UseVisualStyleBackColor = True
      '
      'lblProveedor
      '
      Me.lblProveedor.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.lblProveedor.AutoSize = True
      Me.lblProveedor.LabelAsoc = Nothing
      Me.lblProveedor.Location = New System.Drawing.Point(583, 6)
      Me.lblProveedor.Name = "lblProveedor"
      Me.lblProveedor.Size = New System.Drawing.Size(56, 13)
      Me.lblProveedor.TabIndex = 13
      Me.lblProveedor.Text = "Proveedor"
      '
      'bscProveedor
      '
      Me.bscProveedor.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.bscProveedor.AyudaAncho = 608
      Me.bscProveedor.BindearPropiedadControl = Nothing
      Me.bscProveedor.BindearPropiedadEntidad = Nothing
      Me.bscProveedor.ColumnasAlineacion = Nothing
      Me.bscProveedor.ColumnasAncho = Nothing
      Me.bscProveedor.ColumnasFormato = Nothing
      Me.bscProveedor.ColumnasOcultas = Nothing
      Me.bscProveedor.ColumnasTitulos = Nothing
      Me.bscProveedor.Datos = Nothing
      Me.bscProveedor.FilaDevuelta = Nothing
      Me.bscProveedor.ForeColorFocus = System.Drawing.Color.Red
      Me.bscProveedor.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
      Me.bscProveedor.IsDecimal = False
      Me.bscProveedor.IsNumber = False
      Me.bscProveedor.IsPK = False
      Me.bscProveedor.IsRequired = False
      Me.bscProveedor.Key = ""
      Me.bscProveedor.LabelAsoc = Me.lblProveedor
      Me.bscProveedor.Location = New System.Drawing.Point(547, 22)
      Me.bscProveedor.MaxLengh = "32767"
      Me.bscProveedor.Name = "bscProveedor"
      Me.bscProveedor.Permitido = True
      Me.bscProveedor.Selecciono = False
      Me.bscProveedor.Size = New System.Drawing.Size(155, 20)
      Me.bscProveedor.TabIndex = 7
      Me.bscProveedor.Titulo = Nothing
      '
      'txtGarantia
      '
      Me.txtGarantia.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.txtGarantia.BindearPropiedadControl = Nothing
      Me.txtGarantia.BindearPropiedadEntidad = Nothing
      Me.txtGarantia.ForeColorFocus = System.Drawing.Color.Red
      Me.txtGarantia.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtGarantia.Formato = ""
      Me.txtGarantia.IsDecimal = False
      Me.txtGarantia.IsNumber = True
      Me.txtGarantia.IsPK = False
      Me.txtGarantia.IsRequired = False
      Me.txtGarantia.Key = ""
      Me.txtGarantia.LabelAsoc = Me.lblGarantia
      Me.txtGarantia.Location = New System.Drawing.Point(515, 22)
      Me.txtGarantia.Name = "txtGarantia"
      Me.txtGarantia.Size = New System.Drawing.Size(28, 20)
      Me.txtGarantia.TabIndex = 6
      Me.txtGarantia.Text = "0"
      Me.txtGarantia.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'lblGarantia
      '
      Me.lblGarantia.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.lblGarantia.AutoSize = True
      Me.lblGarantia.LabelAsoc = Nothing
      Me.lblGarantia.Location = New System.Drawing.Point(507, 6)
      Me.lblGarantia.Name = "lblGarantia"
      Me.lblGarantia.Size = New System.Drawing.Size(47, 13)
      Me.lblGarantia.TabIndex = 11
      Me.lblGarantia.Text = "Garantia"
      '
      'dtpEntrego
      '
      Me.dtpEntrego.BindearPropiedadControl = Nothing
      Me.dtpEntrego.BindearPropiedadEntidad = Nothing
      Me.dtpEntrego.CustomFormat = "dd/MM/yyyy"
      Me.dtpEntrego.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.dtpEntrego.ForeColorFocus = System.Drawing.Color.Red
      Me.dtpEntrego.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.dtpEntrego.Format = System.Windows.Forms.DateTimePickerFormat.Custom
      Me.dtpEntrego.IsPK = False
      Me.dtpEntrego.IsRequired = False
      Me.dtpEntrego.Key = ""
      Me.dtpEntrego.LabelAsoc = Me.lblFechaEntrega
      Me.dtpEntrego.Location = New System.Drawing.Point(417, 22)
      Me.dtpEntrego.Name = "dtpEntrego"
      Me.dtpEntrego.ShowCheckBox = True
      Me.dtpEntrego.Size = New System.Drawing.Size(95, 20)
      Me.dtpEntrego.TabIndex = 5
      '
      'lblFechaEntrega
      '
      Me.lblFechaEntrega.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.lblFechaEntrega.AutoSize = True
      Me.lblFechaEntrega.LabelAsoc = Nothing
      Me.lblFechaEntrega.Location = New System.Drawing.Point(418, 6)
      Me.lblFechaEntrega.Name = "lblFechaEntrega"
      Me.lblFechaEntrega.Size = New System.Drawing.Size(77, 13)
      Me.lblFechaEntrega.TabIndex = 9
      Me.lblFechaEntrega.Text = "Fecha Entrega"
      '
      'txtStock
      '
      Me.txtStock.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.txtStock.BindearPropiedadControl = Nothing
      Me.txtStock.BindearPropiedadEntidad = Nothing
      Me.txtStock.Enabled = False
      Me.txtStock.ForeColorFocus = System.Drawing.Color.Red
      Me.txtStock.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtStock.Formato = ""
      Me.txtStock.IsDecimal = False
      Me.txtStock.IsNumber = True
      Me.txtStock.IsPK = False
      Me.txtStock.IsRequired = False
      Me.txtStock.Key = ""
      Me.txtStock.LabelAsoc = Me.llbTotalProducto
      Me.txtStock.Location = New System.Drawing.Point(222, 1)
      Me.txtStock.Name = "txtStock"
      Me.txtStock.Size = New System.Drawing.Size(32, 20)
      Me.txtStock.TabIndex = 1
      Me.txtStock.TabStop = False
      Me.txtStock.Text = "0"
      Me.txtStock.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'llbTotalProducto
      '
      Me.llbTotalProducto.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.llbTotalProducto.AutoSize = True
      Me.llbTotalProducto.LabelAsoc = Nothing
      Me.llbTotalProducto.Location = New System.Drawing.Point(361, 6)
      Me.llbTotalProducto.Name = "llbTotalProducto"
      Me.llbTotalProducto.Size = New System.Drawing.Size(42, 13)
      Me.llbTotalProducto.TabIndex = 7
      Me.llbTotalProducto.Text = "Importe"
      '
      'lblStock
      '
      Me.lblStock.AutoSize = True
      Me.lblStock.ForeColor = System.Drawing.SystemColors.ControlText
      Me.lblStock.LabelAsoc = Nothing
      Me.lblStock.Location = New System.Drawing.Point(181, 6)
      Me.lblStock.Name = "lblStock"
      Me.lblStock.Size = New System.Drawing.Size(35, 13)
      Me.lblStock.TabIndex = 8
      Me.lblStock.Text = "Stock"
      '
      'bscProducto
      '
      Me.bscProducto.ActivarFiltroEnGrilla = True
      Me.bscProducto.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.bscProducto.BindearPropiedadControl = Nothing
      Me.bscProducto.BindearPropiedadEntidad = Nothing
      Me.bscProducto.ConfigBuscador = Nothing
      Me.bscProducto.Datos = Nothing
      Me.bscProducto.FilaDevuelta = Nothing
      Me.bscProducto.ForeColorFocus = System.Drawing.Color.Red
      Me.bscProducto.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
      Me.bscProducto.IsDecimal = False
      Me.bscProducto.IsNumber = False
      Me.bscProducto.IsPK = False
      Me.bscProducto.IsRequired = False
      Me.bscProducto.Key = ""
      Me.bscProducto.LabelAsoc = Me.lblProducto
      Me.bscProducto.Location = New System.Drawing.Point(3, 22)
      Me.bscProducto.MaxLengh = "32767"
      Me.bscProducto.Name = "bscProducto"
      Me.bscProducto.Permitido = True
      Me.bscProducto.PermitidoNoBackColor = System.Drawing.Color.FromArgb(CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer))
      Me.bscProducto.PermitidoNoForeColor = System.Drawing.Color.Black
      Me.bscProducto.PermitidoSiBackColor = System.Drawing.Color.White
      Me.bscProducto.PermitidoSiForeColor = System.Drawing.Color.Black
      Me.bscProducto.Selecciono = False
      Me.bscProducto.Size = New System.Drawing.Size(251, 20)
      Me.bscProducto.TabIndex = 0
      '
      'lblProducto
      '
      Me.lblProducto.AutoSize = True
      Me.lblProducto.ForeColor = System.Drawing.SystemColors.ControlText
      Me.lblProducto.LabelAsoc = Nothing
      Me.lblProducto.Location = New System.Drawing.Point(3, 6)
      Me.lblProducto.Name = "lblProducto"
      Me.lblProducto.Size = New System.Drawing.Size(50, 13)
      Me.lblProducto.TabIndex = 2
      Me.lblProducto.Text = "Producto"
      '
      'btnEliminar
      '
      Me.btnEliminar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.btnEliminar.ImageIndex = 1
      Me.btnEliminar.ImageList = Me.imgIconos
      Me.btnEliminar.Location = New System.Drawing.Point(774, 6)
      Me.btnEliminar.Name = "btnEliminar"
      Me.btnEliminar.Size = New System.Drawing.Size(72, 37)
      Me.btnEliminar.TabIndex = 9
      Me.btnEliminar.Text = "&Eliminar"
      Me.btnEliminar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
      Me.btnEliminar.UseVisualStyleBackColor = True
      '
      'btnInsertar
      '
      Me.btnInsertar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.btnInsertar.ImageIndex = 0
      Me.btnInsertar.ImageList = Me.imgIconos
      Me.btnInsertar.Location = New System.Drawing.Point(702, 6)
      Me.btnInsertar.Name = "btnInsertar"
      Me.btnInsertar.Size = New System.Drawing.Size(72, 36)
      Me.btnInsertar.TabIndex = 8
      Me.btnInsertar.Text = "&Insertar"
      Me.btnInsertar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
      Me.btnInsertar.UseVisualStyleBackColor = True
      '
      'txtTotalProducto
      '
      Me.txtTotalProducto.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.txtTotalProducto.BindearPropiedadControl = Nothing
      Me.txtTotalProducto.BindearPropiedadEntidad = Nothing
      Me.txtTotalProducto.Enabled = False
      Me.txtTotalProducto.ForeColorFocus = System.Drawing.Color.Red
      Me.txtTotalProducto.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtTotalProducto.Formato = "##0.00"
      Me.txtTotalProducto.IsDecimal = False
      Me.txtTotalProducto.IsNumber = True
      Me.txtTotalProducto.IsPK = False
      Me.txtTotalProducto.IsRequired = False
      Me.txtTotalProducto.Key = ""
      Me.txtTotalProducto.LabelAsoc = Me.llbTotalProducto
      Me.txtTotalProducto.Location = New System.Drawing.Point(359, 22)
      Me.txtTotalProducto.Name = "txtTotalProducto"
      Me.txtTotalProducto.Size = New System.Drawing.Size(55, 20)
      Me.txtTotalProducto.TabIndex = 4
      Me.txtTotalProducto.Text = "0.00"
      Me.txtTotalProducto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'txtCantidad
      '
      Me.txtCantidad.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.txtCantidad.BindearPropiedadControl = Nothing
      Me.txtCantidad.BindearPropiedadEntidad = Nothing
      Me.txtCantidad.ForeColorFocus = System.Drawing.Color.Red
      Me.txtCantidad.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtCantidad.Formato = ""
      Me.txtCantidad.IsDecimal = False
      Me.txtCantidad.IsNumber = True
      Me.txtCantidad.IsPK = False
      Me.txtCantidad.IsRequired = False
      Me.txtCantidad.Key = ""
      Me.txtCantidad.LabelAsoc = Me.lblCantidad
      Me.txtCantidad.Location = New System.Drawing.Point(260, 22)
      Me.txtCantidad.Name = "txtCantidad"
      Me.txtCantidad.Size = New System.Drawing.Size(33, 20)
      Me.txtCantidad.TabIndex = 2
      Me.txtCantidad.Text = "0"
      Me.txtCantidad.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'lblCantidad
      '
      Me.lblCantidad.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.lblCantidad.AutoSize = True
      Me.lblCantidad.LabelAsoc = Nothing
      Me.lblCantidad.Location = New System.Drawing.Point(257, 6)
      Me.lblCantidad.Name = "lblCantidad"
      Me.lblCantidad.Size = New System.Drawing.Size(49, 13)
      Me.lblCantidad.TabIndex = 3
      Me.lblCantidad.Text = "Cantidad"
      '
      'dtgProductos
      '
      Me.dtgProductos.AllowUserToAddRows = False
      Me.dtgProductos.AllowUserToDeleteRows = False
      Me.dtgProductos.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
      DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
      DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
      DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
      DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
      DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
      Me.dtgProductos.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
      Me.dtgProductos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
      Me.dtgProductos.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.IdProducto, Me.IdCliente, Me.NombreCliente, Me.ProductoDesc, Me.Cantidad, Me.Precio, Me.Importe, Me.FechaEntrega, Me.Garantia, Me.NroOperacion, Me.Usuario, Me.Password, Me.IdSucursal})
      DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
      DataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Window
      DataGridViewCellStyle7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      DataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.ControlText
      DataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight
      DataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText
      DataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
      Me.dtgProductos.DefaultCellStyle = DataGridViewCellStyle7
      Me.dtgProductos.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
      Me.dtgProductos.Location = New System.Drawing.Point(3, 48)
      Me.dtgProductos.MultiSelect = False
      Me.dtgProductos.Name = "dtgProductos"
      Me.dtgProductos.ReadOnly = True
      DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
      DataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Control
      DataGridViewCellStyle8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      DataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.WindowText
      DataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight
      DataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText
      DataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
      Me.dtgProductos.RowHeadersDefaultCellStyle = DataGridViewCellStyle8
      Me.dtgProductos.RowHeadersWidth = 20
      Me.dtgProductos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
      Me.dtgProductos.Size = New System.Drawing.Size(843, 233)
      Me.dtgProductos.TabIndex = 10
      '
      'IdProducto
      '
      Me.IdProducto.DataPropertyName = "IdProducto"
      Me.IdProducto.HeaderText = "Código"
      Me.IdProducto.Name = "IdProducto"
      Me.IdProducto.ReadOnly = True
      Me.IdProducto.ToolTipText = "Código del producto"
      Me.IdProducto.Width = 90
      '
      'IdCliente
      '
      Me.IdCliente.DataPropertyName = "IdCliente"
      Me.IdCliente.HeaderText = "IdCliente"
      Me.IdCliente.Name = "IdCliente"
      Me.IdCliente.ReadOnly = True
      Me.IdCliente.Visible = False
      '
      'NombreCliente
      '
      Me.NombreCliente.DataPropertyName = "NombreCliente"
      Me.NombreCliente.HeaderText = "NombreCliente"
      Me.NombreCliente.Name = "NombreCliente"
      Me.NombreCliente.ReadOnly = True
      Me.NombreCliente.Visible = False
      '
      'ProductoDesc
      '
      Me.ProductoDesc.DataPropertyName = "ProductoDesc"
      Me.ProductoDesc.HeaderText = "Descripción"
      Me.ProductoDesc.Name = "ProductoDesc"
      Me.ProductoDesc.ReadOnly = True
      Me.ProductoDesc.Width = 215
      '
      'Cantidad
      '
      Me.Cantidad.DataPropertyName = "Cantidad"
      DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
      Me.Cantidad.DefaultCellStyle = DataGridViewCellStyle2
      Me.Cantidad.HeaderText = "Cantidad"
      Me.Cantidad.Name = "Cantidad"
      Me.Cantidad.ReadOnly = True
      Me.Cantidad.Width = 75
      '
      'Precio
      '
      Me.Precio.DataPropertyName = "Precio"
      DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
      Me.Precio.DefaultCellStyle = DataGridViewCellStyle3
      Me.Precio.HeaderText = "Precio"
      Me.Precio.Name = "Precio"
      Me.Precio.ReadOnly = True
      Me.Precio.Width = 90
      '
      'Importe
      '
      Me.Importe.DataPropertyName = "Importe"
      DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
      Me.Importe.DefaultCellStyle = DataGridViewCellStyle4
      Me.Importe.HeaderText = "Importe"
      Me.Importe.Name = "Importe"
      Me.Importe.ReadOnly = True
      Me.Importe.Width = 90
      '
      'FechaEntrega
      '
      Me.FechaEntrega.DataPropertyName = "FechaEntrega"
      DataGridViewCellStyle5.Format = "d"
      Me.FechaEntrega.DefaultCellStyle = DataGridViewCellStyle5
      Me.FechaEntrega.HeaderText = "Entregado"
      Me.FechaEntrega.Name = "FechaEntrega"
      Me.FechaEntrega.ReadOnly = True
      Me.FechaEntrega.Width = 75
      '
      'Garantia
      '
      Me.Garantia.DataPropertyName = "Garantia"
      DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
      Me.Garantia.DefaultCellStyle = DataGridViewCellStyle6
      Me.Garantia.HeaderText = "Garantia"
      Me.Garantia.Name = "Garantia"
      Me.Garantia.ReadOnly = True
      Me.Garantia.Width = 50
      '
      'NroOperacion
      '
      Me.NroOperacion.DataPropertyName = "NroOperacion"
      Me.NroOperacion.HeaderText = "NroOperacion"
      Me.NroOperacion.Name = "NroOperacion"
      Me.NroOperacion.ReadOnly = True
      Me.NroOperacion.Visible = False
      '
      'Usuario
      '
      Me.Usuario.DataPropertyName = "Usuario"
      Me.Usuario.HeaderText = "Usuario"
      Me.Usuario.Name = "Usuario"
      Me.Usuario.ReadOnly = True
      Me.Usuario.Visible = False
      '
      'Password
      '
      Me.Password.DataPropertyName = "Password"
      Me.Password.HeaderText = "Password"
      Me.Password.Name = "Password"
      Me.Password.ReadOnly = True
      Me.Password.Visible = False
      '
      'IdSucursal
      '
      Me.IdSucursal.DataPropertyName = "IdSucursal"
      Me.IdSucursal.HeaderText = "IdSucursal"
      Me.IdSucursal.Name = "IdSucursal"
      Me.IdSucursal.ReadOnly = True
      Me.IdSucursal.Visible = False
      '
      'tbpPagos
      '
      Me.tbpPagos.Controls.Add(Me.txtSaldo)
      Me.tbpPagos.Controls.Add(Me.lblSaldo)
      Me.tbpPagos.Controls.Add(Me.dgvPagos)
      Me.tbpPagos.Controls.Add(Me.dgvCuotas)
      Me.tbpPagos.Controls.Add(Me.grbTotales)
      Me.tbpPagos.Location = New System.Drawing.Point(4, 22)
      Me.tbpPagos.Name = "tbpPagos"
      Me.tbpPagos.Padding = New System.Windows.Forms.Padding(3)
      Me.tbpPagos.Size = New System.Drawing.Size(849, 284)
      Me.tbpPagos.TabIndex = 1
      Me.tbpPagos.Text = "Pagos"
      Me.tbpPagos.UseVisualStyleBackColor = True
      '
      'txtSaldo
      '
      Me.txtSaldo.BindearPropiedadControl = Nothing
      Me.txtSaldo.BindearPropiedadEntidad = Nothing
      Me.txtSaldo.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.txtSaldo.ForeColor = System.Drawing.Color.Red
      Me.txtSaldo.ForeColorFocus = System.Drawing.Color.Red
      Me.txtSaldo.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtSaldo.Formato = "##,##0.00"
      Me.txtSaldo.IsDecimal = True
      Me.txtSaldo.IsNumber = True
      Me.txtSaldo.IsPK = False
      Me.txtSaldo.IsRequired = False
      Me.txtSaldo.Key = ""
      Me.txtSaldo.LabelAsoc = Me.lblSaldo
      Me.txtSaldo.Location = New System.Drawing.Point(367, 3)
      Me.txtSaldo.Name = "txtSaldo"
      Me.txtSaldo.ReadOnly = True
      Me.txtSaldo.Size = New System.Drawing.Size(141, 26)
      Me.txtSaldo.TabIndex = 22
      Me.txtSaldo.Text = "0.00"
      Me.txtSaldo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'lblSaldo
      '
      Me.lblSaldo.AutoSize = True
      Me.lblSaldo.LabelAsoc = Nothing
      Me.lblSaldo.Location = New System.Drawing.Point(327, 14)
      Me.lblSaldo.Name = "lblSaldo"
      Me.lblSaldo.Size = New System.Drawing.Size(34, 13)
      Me.lblSaldo.TabIndex = 23
      Me.lblSaldo.Text = "Saldo"
      '
      'dgvPagos
      '
      Me.dgvPagos.AllowUserToAddRows = False
      Me.dgvPagos.AllowUserToDeleteRows = False
      Me.dgvPagos.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      DataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
      DataGridViewCellStyle9.BackColor = System.Drawing.SystemColors.Control
      DataGridViewCellStyle9.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      DataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.WindowText
      DataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.Highlight
      DataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.HighlightText
      DataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
      Me.dgvPagos.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle9
      Me.dgvPagos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
      Me.dgvPagos.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewTextBoxColumn1, Me.DataGridViewTextBoxColumn2, Me.DataGridViewTextBoxColumn9, Me.DataGridViewTextBoxColumn4, Me.DataGridViewTextBoxColumn5, Me.DataGridViewTextBoxColumn6, Me.DataGridViewTextBoxColumn7, Me.DataGridViewTextBoxColumn8, Me.IdCliente2, Me.NombreCobradorPago, Me.IdCobrador, Me.IdSucursalPago, Me.FichaPagoAjuste, Me.IdCaja, Me.NumeroPlanilla, Me.NumeroMovimiento})
      DataGridViewCellStyle15.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
      DataGridViewCellStyle15.BackColor = System.Drawing.SystemColors.Window
      DataGridViewCellStyle15.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      DataGridViewCellStyle15.ForeColor = System.Drawing.SystemColors.ControlText
      DataGridViewCellStyle15.SelectionBackColor = System.Drawing.SystemColors.Highlight
      DataGridViewCellStyle15.SelectionForeColor = System.Drawing.SystemColors.HighlightText
      DataGridViewCellStyle15.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
      Me.dgvPagos.DefaultCellStyle = DataGridViewCellStyle15
      Me.dgvPagos.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
      Me.dgvPagos.Location = New System.Drawing.Point(534, 31)
      Me.dgvPagos.Name = "dgvPagos"
      DataGridViewCellStyle16.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
      DataGridViewCellStyle16.BackColor = System.Drawing.SystemColors.Control
      DataGridViewCellStyle16.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      DataGridViewCellStyle16.ForeColor = System.Drawing.SystemColors.WindowText
      DataGridViewCellStyle16.SelectionBackColor = System.Drawing.SystemColors.Highlight
      DataGridViewCellStyle16.SelectionForeColor = System.Drawing.SystemColors.HighlightText
      DataGridViewCellStyle16.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
      Me.dgvPagos.RowHeadersDefaultCellStyle = DataGridViewCellStyle16
      Me.dgvPagos.RowHeadersWidth = 10
      Me.dgvPagos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
      Me.dgvPagos.Size = New System.Drawing.Size(313, 250)
      Me.dgvPagos.TabIndex = 6
      Me.dgvPagos.Visible = False
      '
      'dgvCuotas
      '
      Me.dgvCuotas.AllowUserToAddRows = False
      Me.dgvCuotas.AllowUserToDeleteRows = False
      Me.dgvCuotas.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
      DataGridViewCellStyle17.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
      DataGridViewCellStyle17.BackColor = System.Drawing.SystemColors.Control
      DataGridViewCellStyle17.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      DataGridViewCellStyle17.ForeColor = System.Drawing.SystemColors.WindowText
      DataGridViewCellStyle17.SelectionBackColor = System.Drawing.SystemColors.Highlight
      DataGridViewCellStyle17.SelectionForeColor = System.Drawing.SystemColors.HighlightText
      DataGridViewCellStyle17.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
      Me.dgvCuotas.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle17
      Me.dgvCuotas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
      Me.dgvCuotas.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.NroCuota, Me.IdCliente1, Me.FechaVencimiento, Me.Saldo, Me.UsuarioPagos, Me.PasswordPagos, Me.NroOperacionPago, Me.NroDocumentoPago, Me.TipoDocumentoPago, Me.ImportePago, Me.IdSucursalCuotas})
      DataGridViewCellStyle21.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
      DataGridViewCellStyle21.BackColor = System.Drawing.SystemColors.Window
      DataGridViewCellStyle21.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      DataGridViewCellStyle21.ForeColor = System.Drawing.SystemColors.ControlText
      DataGridViewCellStyle21.SelectionBackColor = System.Drawing.SystemColors.Highlight
      DataGridViewCellStyle21.SelectionForeColor = System.Drawing.SystemColors.HighlightText
      DataGridViewCellStyle21.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
      Me.dgvCuotas.DefaultCellStyle = DataGridViewCellStyle21
      Me.dgvCuotas.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
      Me.dgvCuotas.Location = New System.Drawing.Point(326, 31)
      Me.dgvCuotas.Name = "dgvCuotas"
      DataGridViewCellStyle22.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
      DataGridViewCellStyle22.BackColor = System.Drawing.SystemColors.Control
      DataGridViewCellStyle22.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      DataGridViewCellStyle22.ForeColor = System.Drawing.SystemColors.WindowText
      DataGridViewCellStyle22.SelectionBackColor = System.Drawing.SystemColors.Highlight
      DataGridViewCellStyle22.SelectionForeColor = System.Drawing.SystemColors.HighlightText
      DataGridViewCellStyle22.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
      Me.dgvCuotas.RowHeadersDefaultCellStyle = DataGridViewCellStyle22
      Me.dgvCuotas.RowHeadersWidth = 10
      Me.dgvCuotas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
      Me.dgvCuotas.Size = New System.Drawing.Size(207, 250)
      Me.dgvCuotas.TabIndex = 5
      '
      'NroCuota
      '
      Me.NroCuota.DataPropertyName = "NroCuota"
      Me.NroCuota.HeaderText = "Nro."
      Me.NroCuota.Name = "NroCuota"
      Me.NroCuota.Width = 30
      '
      'IdCliente1
      '
      Me.IdCliente1.DataPropertyName = "IdCliente"
      Me.IdCliente1.HeaderText = "IdCiente"
      Me.IdCliente1.Name = "IdCliente1"
      Me.IdCliente1.Visible = False
      '
      'FechaVencimiento
      '
      Me.FechaVencimiento.DataPropertyName = "FechaVencimiento"
      DataGridViewCellStyle18.Format = "dd/MM/yyyy"
      DataGridViewCellStyle18.NullValue = "dd/MM/yyyy"
      Me.FechaVencimiento.DefaultCellStyle = DataGridViewCellStyle18
      Me.FechaVencimiento.HeaderText = "Vencimiento"
      Me.FechaVencimiento.Name = "FechaVencimiento"
      Me.FechaVencimiento.Width = 70
      '
      'Saldo
      '
      Me.Saldo.DataPropertyName = "Saldo"
      DataGridViewCellStyle19.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
      DataGridViewCellStyle19.Format = "N2"
      DataGridViewCellStyle19.NullValue = Nothing
      Me.Saldo.DefaultCellStyle = DataGridViewCellStyle19
      Me.Saldo.HeaderText = "Saldo"
      Me.Saldo.Name = "Saldo"
      Me.Saldo.Width = 70
      '
      'UsuarioPagos
      '
      Me.UsuarioPagos.DataPropertyName = "Usuario"
      Me.UsuarioPagos.HeaderText = "Usuario"
      Me.UsuarioPagos.Name = "UsuarioPagos"
      Me.UsuarioPagos.Visible = False
      '
      'PasswordPagos
      '
      Me.PasswordPagos.DataPropertyName = "Password"
      Me.PasswordPagos.HeaderText = "Password"
      Me.PasswordPagos.Name = "PasswordPagos"
      Me.PasswordPagos.Visible = False
      '
      'NroOperacionPago
      '
      Me.NroOperacionPago.DataPropertyName = "NroOperacion"
      Me.NroOperacionPago.HeaderText = "NroOperacionPago"
      Me.NroOperacionPago.Name = "NroOperacionPago"
      Me.NroOperacionPago.Visible = False
      '
      'NroDocumentoPago
      '
      Me.NroDocumentoPago.DataPropertyName = "NroDocumento"
      Me.NroDocumentoPago.HeaderText = "NroDocumentoPago"
      Me.NroDocumentoPago.Name = "NroDocumentoPago"
      Me.NroDocumentoPago.Visible = False
      '
      'TipoDocumentoPago
      '
      Me.TipoDocumentoPago.DataPropertyName = "TipoDocumento"
      Me.TipoDocumentoPago.HeaderText = "TipoDocumentoPago"
      Me.TipoDocumentoPago.Name = "TipoDocumentoPago"
      Me.TipoDocumentoPago.Visible = False
      '
      'ImportePago
      '
      Me.ImportePago.DataPropertyName = "Importe"
      DataGridViewCellStyle20.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
      DataGridViewCellStyle20.Format = "C2"
      DataGridViewCellStyle20.NullValue = Nothing
      Me.ImportePago.DefaultCellStyle = DataGridViewCellStyle20
      Me.ImportePago.HeaderText = "Importe"
      Me.ImportePago.Name = "ImportePago"
      Me.ImportePago.Visible = False
      Me.ImportePago.Width = 70
      '
      'IdSucursalCuotas
      '
      Me.IdSucursalCuotas.DataPropertyName = "IdSucursal"
      Me.IdSucursalCuotas.HeaderText = "IdSucursalCuotas"
      Me.IdSucursalCuotas.Name = "IdSucursalCuotas"
      Me.IdSucursalCuotas.Visible = False
      '
      'grbTotales
      '
      Me.grbTotales.Controls.Add(Me.btnGrabar)
      Me.grbTotales.Controls.Add(Me.grbDetallePago)
      Me.grbTotales.Controls.Add(Me.txtTotal)
      Me.grbTotales.Controls.Add(Me.lblTotal)
      Me.grbTotales.Controls.Add(Me.txtSubTotal)
      Me.grbTotales.Controls.Add(Me.lblSubTotal)
      Me.grbTotales.Controls.Add(Me.txtAnticipo)
      Me.grbTotales.Controls.Add(Me.lblAnticipo)
      Me.grbTotales.Controls.Add(Me.txtBruto)
      Me.grbTotales.Controls.Add(Me.lblBruto)
      Me.grbTotales.Location = New System.Drawing.Point(15, 6)
      Me.grbTotales.Name = "grbTotales"
      Me.grbTotales.Size = New System.Drawing.Size(304, 272)
      Me.grbTotales.TabIndex = 0
      Me.grbTotales.TabStop = False
      Me.grbTotales.Text = "Totales"
      '
      'btnGrabar
      '
      Me.btnGrabar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
      Me.btnGrabar.ImageIndex = 2
      Me.btnGrabar.ImageList = Me.imgIconos
      Me.btnGrabar.Location = New System.Drawing.Point(200, 231)
      Me.btnGrabar.Name = "btnGrabar"
      Me.btnGrabar.Size = New System.Drawing.Size(93, 37)
      Me.btnGrabar.TabIndex = 5
      Me.btnGrabar.Text = "&Grabar"
      Me.btnGrabar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      Me.btnGrabar.UseVisualStyleBackColor = True
      '
      'grbDetallePago
      '
      Me.grbDetallePago.Controls.Add(Me.txtCuotas)
      Me.grbDetallePago.Controls.Add(Me.txtTotalCuotas)
      Me.grbDetallePago.Controls.Add(Me.lblTotalCuotas)
      Me.grbDetallePago.Controls.Add(Me.cmbFormaPago)
      Me.grbDetallePago.Controls.Add(Me.txtImpCuota)
      Me.grbDetallePago.Controls.Add(Me.lblImpCuota)
      Me.grbDetallePago.Controls.Add(Me.txtIntereses)
      Me.grbDetallePago.Controls.Add(Me.lblIntereses)
      Me.grbDetallePago.Controls.Add(Me.lblCuotas)
      Me.grbDetallePago.Controls.Add(Me.lblFormaPago)
      Me.grbDetallePago.Location = New System.Drawing.Point(5, 93)
      Me.grbDetallePago.Name = "grbDetallePago"
      Me.grbDetallePago.Size = New System.Drawing.Size(293, 100)
      Me.grbDetallePago.TabIndex = 3
      Me.grbDetallePago.TabStop = False
      '
      'txtCuotas
      '
      Me.txtCuotas.BindearPropiedadControl = Nothing
      Me.txtCuotas.BindearPropiedadEntidad = Nothing
      Me.txtCuotas.ForeColorFocus = System.Drawing.Color.Red
      Me.txtCuotas.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtCuotas.Formato = ""
      Me.txtCuotas.IsDecimal = False
      Me.txtCuotas.IsNumber = True
      Me.txtCuotas.IsPK = False
      Me.txtCuotas.IsRequired = False
      Me.txtCuotas.Key = ""
      Me.txtCuotas.LabelAsoc = Me.lblCuotas
      Me.txtCuotas.Location = New System.Drawing.Point(238, 20)
      Me.txtCuotas.MaxLength = 4
      Me.txtCuotas.Name = "txtCuotas"
      Me.txtCuotas.Size = New System.Drawing.Size(46, 20)
      Me.txtCuotas.TabIndex = 4
      Me.txtCuotas.Text = "1"
      Me.txtCuotas.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'lblCuotas
      '
      Me.lblCuotas.AutoSize = True
      Me.lblCuotas.LabelAsoc = Nothing
      Me.lblCuotas.Location = New System.Drawing.Point(192, 24)
      Me.lblCuotas.Name = "lblCuotas"
      Me.lblCuotas.Size = New System.Drawing.Size(40, 13)
      Me.lblCuotas.TabIndex = 31
      Me.lblCuotas.Text = "Cuotas"
      '
      'txtTotalCuotas
      '
      Me.txtTotalCuotas.BindearPropiedadControl = Nothing
      Me.txtTotalCuotas.BindearPropiedadEntidad = Nothing
      Me.txtTotalCuotas.ForeColorFocus = System.Drawing.Color.Red
      Me.txtTotalCuotas.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtTotalCuotas.Formato = "##,##0.00"
      Me.txtTotalCuotas.IsDecimal = True
      Me.txtTotalCuotas.IsNumber = True
      Me.txtTotalCuotas.IsPK = False
      Me.txtTotalCuotas.IsRequired = False
      Me.txtTotalCuotas.Key = ""
      Me.txtTotalCuotas.LabelAsoc = Me.lblTotalCuotas
      Me.txtTotalCuotas.Location = New System.Drawing.Point(214, 72)
      Me.txtTotalCuotas.Name = "txtTotalCuotas"
      Me.txtTotalCuotas.ReadOnly = True
      Me.txtTotalCuotas.Size = New System.Drawing.Size(73, 20)
      Me.txtTotalCuotas.TabIndex = 7
      Me.txtTotalCuotas.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'lblTotalCuotas
      '
      Me.lblTotalCuotas.AutoSize = True
      Me.lblTotalCuotas.LabelAsoc = Nothing
      Me.lblTotalCuotas.Location = New System.Drawing.Point(149, 76)
      Me.lblTotalCuotas.Name = "lblTotalCuotas"
      Me.lblTotalCuotas.Size = New System.Drawing.Size(66, 13)
      Me.lblTotalCuotas.TabIndex = 33
      Me.lblTotalCuotas.Text = "Total cuotas"
      '
      'cmbFormaPago
      '
      Me.cmbFormaPago.BindearPropiedadControl = Nothing
      Me.cmbFormaPago.BindearPropiedadEntidad = Nothing
      Me.cmbFormaPago.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cmbFormaPago.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.cmbFormaPago.ForeColorFocus = System.Drawing.Color.Red
      Me.cmbFormaPago.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.cmbFormaPago.FormattingEnabled = True
      Me.cmbFormaPago.IsPK = False
      Me.cmbFormaPago.IsRequired = False
      Me.cmbFormaPago.Key = Nothing
      Me.cmbFormaPago.LabelAsoc = Me.lblFormaPago
      Me.cmbFormaPago.Location = New System.Drawing.Point(70, 20)
      Me.cmbFormaPago.Name = "cmbFormaPago"
      Me.cmbFormaPago.Size = New System.Drawing.Size(116, 21)
      Me.cmbFormaPago.TabIndex = 3
      '
      'lblFormaPago
      '
      Me.lblFormaPago.AutoSize = True
      Me.lblFormaPago.LabelAsoc = Nothing
      Me.lblFormaPago.Location = New System.Drawing.Point(5, 24)
      Me.lblFormaPago.Name = "lblFormaPago"
      Me.lblFormaPago.Size = New System.Drawing.Size(64, 13)
      Me.lblFormaPago.TabIndex = 6
      Me.lblFormaPago.Text = "Forma Pago"
      '
      'txtImpCuota
      '
      Me.txtImpCuota.BindearPropiedadControl = Nothing
      Me.txtImpCuota.BindearPropiedadEntidad = Nothing
      Me.txtImpCuota.ForeColorFocus = System.Drawing.Color.Red
      Me.txtImpCuota.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtImpCuota.Formato = "##,##0.00"
      Me.txtImpCuota.IsDecimal = True
      Me.txtImpCuota.IsNumber = True
      Me.txtImpCuota.IsPK = False
      Me.txtImpCuota.IsRequired = False
      Me.txtImpCuota.Key = ""
      Me.txtImpCuota.LabelAsoc = Me.lblImpCuota
      Me.txtImpCuota.Location = New System.Drawing.Point(70, 72)
      Me.txtImpCuota.Name = "txtImpCuota"
      Me.txtImpCuota.ReadOnly = True
      Me.txtImpCuota.Size = New System.Drawing.Size(73, 20)
      Me.txtImpCuota.TabIndex = 6
      Me.txtImpCuota.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'lblImpCuota
      '
      Me.lblImpCuota.AutoSize = True
      Me.lblImpCuota.LabelAsoc = Nothing
      Me.lblImpCuota.Location = New System.Drawing.Point(5, 76)
      Me.lblImpCuota.Name = "lblImpCuota"
      Me.lblImpCuota.Size = New System.Drawing.Size(57, 13)
      Me.lblImpCuota.TabIndex = 24
      Me.lblImpCuota.Text = "Imp. cuota"
      '
      'txtIntereses
      '
      Me.txtIntereses.BindearPropiedadControl = Nothing
      Me.txtIntereses.BindearPropiedadEntidad = Nothing
      Me.txtIntereses.ForeColorFocus = System.Drawing.Color.Red
      Me.txtIntereses.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtIntereses.Formato = "##,##0.00"
      Me.txtIntereses.IsDecimal = True
      Me.txtIntereses.IsNumber = True
      Me.txtIntereses.IsPK = False
      Me.txtIntereses.IsRequired = False
      Me.txtIntereses.Key = ""
      Me.txtIntereses.LabelAsoc = Me.lblIntereses
      Me.txtIntereses.Location = New System.Drawing.Point(70, 46)
      Me.txtIntereses.Name = "txtIntereses"
      Me.txtIntereses.Size = New System.Drawing.Size(73, 20)
      Me.txtIntereses.TabIndex = 5
      Me.txtIntereses.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'lblIntereses
      '
      Me.lblIntereses.AutoSize = True
      Me.lblIntereses.LabelAsoc = Nothing
      Me.lblIntereses.Location = New System.Drawing.Point(5, 50)
      Me.lblIntereses.Name = "lblIntereses"
      Me.lblIntereses.Size = New System.Drawing.Size(50, 13)
      Me.lblIntereses.TabIndex = 28
      Me.lblIntereses.Text = "Intereses"
      '
      'txtTotal
      '
      Me.txtTotal.BindearPropiedadControl = Nothing
      Me.txtTotal.BindearPropiedadEntidad = Nothing
      Me.txtTotal.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.txtTotal.ForeColorFocus = System.Drawing.Color.Red
      Me.txtTotal.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtTotal.Formato = "##,##0.00"
      Me.txtTotal.IsDecimal = True
      Me.txtTotal.IsNumber = True
      Me.txtTotal.IsPK = False
      Me.txtTotal.IsRequired = False
      Me.txtTotal.Key = ""
      Me.txtTotal.LabelAsoc = Me.lblTotal
      Me.txtTotal.Location = New System.Drawing.Point(75, 199)
      Me.txtTotal.Name = "txtTotal"
      Me.txtTotal.ReadOnly = True
      Me.txtTotal.Size = New System.Drawing.Size(141, 26)
      Me.txtTotal.TabIndex = 4
      Me.txtTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'lblTotal
      '
      Me.lblTotal.AutoSize = True
      Me.lblTotal.LabelAsoc = Nothing
      Me.lblTotal.Location = New System.Drawing.Point(10, 206)
      Me.lblTotal.Name = "lblTotal"
      Me.lblTotal.Size = New System.Drawing.Size(42, 13)
      Me.lblTotal.TabIndex = 21
      Me.lblTotal.Text = "TOTAL"
      '
      'txtSubTotal
      '
      Me.txtSubTotal.BindearPropiedadControl = Nothing
      Me.txtSubTotal.BindearPropiedadEntidad = Nothing
      Me.txtSubTotal.ForeColorFocus = System.Drawing.Color.Red
      Me.txtSubTotal.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtSubTotal.Formato = "##,##0.00"
      Me.txtSubTotal.IsDecimal = True
      Me.txtSubTotal.IsNumber = True
      Me.txtSubTotal.IsPK = False
      Me.txtSubTotal.IsRequired = False
      Me.txtSubTotal.Key = ""
      Me.txtSubTotal.LabelAsoc = Me.lblSubTotal
      Me.txtSubTotal.Location = New System.Drawing.Point(75, 70)
      Me.txtSubTotal.Name = "txtSubTotal"
      Me.txtSubTotal.ReadOnly = True
      Me.txtSubTotal.Size = New System.Drawing.Size(99, 20)
      Me.txtSubTotal.TabIndex = 2
      Me.txtSubTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'lblSubTotal
      '
      Me.lblSubTotal.AutoSize = True
      Me.lblSubTotal.LabelAsoc = Nothing
      Me.lblSubTotal.Location = New System.Drawing.Point(10, 74)
      Me.lblSubTotal.Name = "lblSubTotal"
      Me.lblSubTotal.Size = New System.Drawing.Size(50, 13)
      Me.lblSubTotal.TabIndex = 4
      Me.lblSubTotal.Text = "SubTotal"
      '
      'txtAnticipo
      '
      Me.txtAnticipo.BindearPropiedadControl = Nothing
      Me.txtAnticipo.BindearPropiedadEntidad = Nothing
      Me.txtAnticipo.ForeColorFocus = System.Drawing.Color.Red
      Me.txtAnticipo.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtAnticipo.Formato = "##0.00"
      Me.txtAnticipo.IsDecimal = True
      Me.txtAnticipo.IsNumber = True
      Me.txtAnticipo.IsPK = False
      Me.txtAnticipo.IsRequired = False
      Me.txtAnticipo.Key = ""
      Me.txtAnticipo.LabelAsoc = Me.lblAnticipo
      Me.txtAnticipo.Location = New System.Drawing.Point(75, 44)
      Me.txtAnticipo.Name = "txtAnticipo"
      Me.txtAnticipo.Size = New System.Drawing.Size(99, 20)
      Me.txtAnticipo.TabIndex = 1
      Me.txtAnticipo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'lblAnticipo
      '
      Me.lblAnticipo.AutoSize = True
      Me.lblAnticipo.LabelAsoc = Nothing
      Me.lblAnticipo.Location = New System.Drawing.Point(10, 48)
      Me.lblAnticipo.Name = "lblAnticipo"
      Me.lblAnticipo.Size = New System.Drawing.Size(45, 13)
      Me.lblAnticipo.TabIndex = 2
      Me.lblAnticipo.Text = "Anticipo"
      '
      'txtBruto
      '
      Me.txtBruto.BindearPropiedadControl = Nothing
      Me.txtBruto.BindearPropiedadEntidad = Nothing
      Me.txtBruto.ForeColorFocus = System.Drawing.Color.Red
      Me.txtBruto.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtBruto.Formato = "##,##0.00"
      Me.txtBruto.IsDecimal = True
      Me.txtBruto.IsNumber = True
      Me.txtBruto.IsPK = False
      Me.txtBruto.IsRequired = False
      Me.txtBruto.Key = ""
      Me.txtBruto.LabelAsoc = Me.lblBruto
      Me.txtBruto.Location = New System.Drawing.Point(75, 18)
      Me.txtBruto.Name = "txtBruto"
      Me.txtBruto.ReadOnly = True
      Me.txtBruto.Size = New System.Drawing.Size(99, 20)
      Me.txtBruto.TabIndex = 0
      Me.txtBruto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'lblBruto
      '
      Me.lblBruto.AutoSize = True
      Me.lblBruto.LabelAsoc = Nothing
      Me.lblBruto.Location = New System.Drawing.Point(10, 22)
      Me.lblBruto.Name = "lblBruto"
      Me.lblBruto.Size = New System.Drawing.Size(32, 13)
      Me.lblBruto.TabIndex = 0
      Me.lblBruto.Text = "Bruto"
      '
      'tbpCartasEmitidas
      '
      Me.tbpCartasEmitidas.Controls.Add(Me.dgvCartasEmitidas)
      Me.tbpCartasEmitidas.Location = New System.Drawing.Point(4, 22)
      Me.tbpCartasEmitidas.Name = "tbpCartasEmitidas"
      Me.tbpCartasEmitidas.Padding = New System.Windows.Forms.Padding(3)
      Me.tbpCartasEmitidas.Size = New System.Drawing.Size(849, 284)
      Me.tbpCartasEmitidas.TabIndex = 2
      Me.tbpCartasEmitidas.Text = "Cartas Emitidas"
      Me.tbpCartasEmitidas.UseVisualStyleBackColor = True
      '
      'dgvCartasEmitidas
      '
      Me.dgvCartasEmitidas.AllowUserToAddRows = False
      Me.dgvCartasEmitidas.AllowUserToDeleteRows = False
      Me.dgvCartasEmitidas.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.dgvCartasEmitidas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
      Me.dgvCartasEmitidas.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.TipoCarta, Me.FechaEnvio, Me.TipoDocumentoGarante, Me.NroDocumentoGarante, Me.NombreGarante, Me.UsuarioCartas})
      Me.dgvCartasEmitidas.Location = New System.Drawing.Point(15, 6)
      Me.dgvCartasEmitidas.Name = "dgvCartasEmitidas"
      Me.dgvCartasEmitidas.Size = New System.Drawing.Size(816, 272)
      Me.dgvCartasEmitidas.TabIndex = 0
      '
      'TipoCarta
      '
      Me.TipoCarta.DataPropertyName = "TipoCarta"
      Me.TipoCarta.HeaderText = "Tipo de Carta"
      Me.TipoCarta.Name = "TipoCarta"
      Me.TipoCarta.ReadOnly = True
      '
      'FechaEnvio
      '
      Me.FechaEnvio.DataPropertyName = "FechaEnvio"
      DataGridViewCellStyle23.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
      DataGridViewCellStyle23.Format = "G"
      DataGridViewCellStyle23.NullValue = Nothing
      Me.FechaEnvio.DefaultCellStyle = DataGridViewCellStyle23
      Me.FechaEnvio.HeaderText = "Fecha de Envio"
      Me.FechaEnvio.Name = "FechaEnvio"
      Me.FechaEnvio.ReadOnly = True
      Me.FechaEnvio.Width = 120
      '
      'TipoDocumentoGarante
      '
      Me.TipoDocumentoGarante.DataPropertyName = "TipoDocumentoGarante"
      Me.TipoDocumentoGarante.HeaderText = "Tipo Doc. Garante"
      Me.TipoDocumentoGarante.Name = "TipoDocumentoGarante"
      Me.TipoDocumentoGarante.ReadOnly = True
      Me.TipoDocumentoGarante.Width = 80
      '
      'NroDocumentoGarante
      '
      Me.NroDocumentoGarante.DataPropertyName = "NroDocumentoGarante"
      Me.NroDocumentoGarante.HeaderText = "Nro. Doc. Garante"
      Me.NroDocumentoGarante.Name = "NroDocumentoGarante"
      Me.NroDocumentoGarante.ReadOnly = True
      Me.NroDocumentoGarante.Width = 90
      '
      'NombreGarante
      '
      Me.NombreGarante.DataPropertyName = "NombreGarante"
      Me.NombreGarante.HeaderText = "Nombre Garante"
      Me.NombreGarante.Name = "NombreGarante"
      Me.NombreGarante.ReadOnly = True
      Me.NombreGarante.Width = 250
      '
      'UsuarioCartas
      '
      Me.UsuarioCartas.DataPropertyName = "Usuario"
      Me.UsuarioCartas.HeaderText = "Usuario"
      Me.UsuarioCartas.Name = "UsuarioCartas"
      '
      'stsPie
      '
      Me.stsPie.Location = New System.Drawing.Point(0, 486)
      Me.stsPie.Name = "stsPie"
      Me.stsPie.Size = New System.Drawing.Size(881, 22)
      Me.stsPie.TabIndex = 3
      Me.stsPie.Text = "StatusStrip1"
      '
      'grbCliente
      '
      Me.grbCliente.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.grbCliente.Controls.Add(Me.cmbCajas)
      Me.grbCliente.Controls.Add(Me.lblCaja)
      Me.grbCliente.Controls.Add(Me.llbCliente)
      Me.grbCliente.Controls.Add(Me.bscDireccion)
      Me.grbCliente.Controls.Add(Me.cmbVendedor)
      Me.grbCliente.Controls.Add(Me.lblVendedor)
      Me.grbCliente.Controls.Add(Me.cmbCobrador)
      Me.grbCliente.Controls.Add(Me.lblCobrador)
      Me.grbCliente.Controls.Add(Me.llbOperacion)
      Me.grbCliente.Controls.Add(Me.txtComentario)
      Me.grbCliente.Controls.Add(Me.bscCodigoCliente)
      Me.grbCliente.Controls.Add(Me.lblComentario)
      Me.grbCliente.Controls.Add(Me.dtpFecha)
      Me.grbCliente.Controls.Add(Me.bscCliente)
      Me.grbCliente.Controls.Add(Me.txtTelefono)
      Me.grbCliente.Controls.Add(Me.lblTelefono)
      Me.grbCliente.Controls.Add(Me.txtCP)
      Me.grbCliente.Controls.Add(Me.lblCodPostal)
      Me.grbCliente.Controls.Add(Me.txtLocalidad)
      Me.grbCliente.Controls.Add(Me.lblLocalidad)
      Me.grbCliente.Controls.Add(Me.lblDireccion)
      Me.grbCliente.Controls.Add(Me.txtNroOperacion)
      Me.grbCliente.Controls.Add(Me.lblFecha)
      Me.grbCliente.Controls.Add(Me.lblCodigoCliente)
      Me.grbCliente.Controls.Add(Me.lblNombre)
      Me.grbCliente.Location = New System.Drawing.Point(12, 36)
      Me.grbCliente.Name = "grbCliente"
      Me.grbCliente.Size = New System.Drawing.Size(857, 131)
      Me.grbCliente.TabIndex = 0
      Me.grbCliente.TabStop = False
      Me.grbCliente.Text = "Cliente"
      '
      'cmbCajas
      '
      Me.cmbCajas.BindearPropiedadControl = ""
      Me.cmbCajas.BindearPropiedadEntidad = ""
      Me.cmbCajas.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cmbCajas.ForeColorFocus = System.Drawing.Color.Red
      Me.cmbCajas.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.cmbCajas.FormattingEnabled = True
      Me.cmbCajas.IsPK = False
      Me.cmbCajas.IsRequired = False
      Me.cmbCajas.Key = Nothing
      Me.cmbCajas.LabelAsoc = Me.lblCaja
      Me.cmbCajas.Location = New System.Drawing.Point(740, 105)
      Me.cmbCajas.Name = "cmbCajas"
      Me.cmbCajas.Size = New System.Drawing.Size(106, 21)
      Me.cmbCajas.TabIndex = 27
      '
      'lblCaja
      '
      Me.lblCaja.AutoSize = True
      Me.lblCaja.LabelAsoc = Nothing
      Me.lblCaja.Location = New System.Drawing.Point(737, 92)
      Me.lblCaja.Name = "lblCaja"
      Me.lblCaja.Size = New System.Drawing.Size(28, 13)
      Me.lblCaja.TabIndex = 26
      Me.lblCaja.Text = "Caja"
      '
      'llbCliente
      '
      Me.llbCliente.AutoSize = True
      Me.llbCliente.Location = New System.Drawing.Point(176, 16)
      Me.llbCliente.Name = "llbCliente"
      Me.llbCliente.Size = New System.Drawing.Size(55, 13)
      Me.llbCliente.TabIndex = 25
      Me.llbCliente.TabStop = True
      Me.llbCliente.Text = "más info..."
      '
      'bscDireccion
      '
      Me.bscDireccion.AutoSize = True
      Me.bscDireccion.AyudaAncho = 608
      Me.bscDireccion.BindearPropiedadControl = Nothing
      Me.bscDireccion.BindearPropiedadEntidad = Nothing
      Me.bscDireccion.ColumnasAlineacion = Nothing
      Me.bscDireccion.ColumnasAncho = Nothing
      Me.bscDireccion.ColumnasFormato = Nothing
      Me.bscDireccion.ColumnasOcultas = Nothing
      Me.bscDireccion.ColumnasTitulos = Nothing
      Me.bscDireccion.Datos = Nothing
      Me.bscDireccion.FilaDevuelta = Nothing
      Me.bscDireccion.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.bscDireccion.ForeColorFocus = System.Drawing.Color.Red
      Me.bscDireccion.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
      Me.bscDireccion.IsDecimal = False
      Me.bscDireccion.IsNumber = False
      Me.bscDireccion.IsPK = False
      Me.bscDireccion.IsRequired = False
      Me.bscDireccion.Key = ""
      Me.bscDireccion.LabelAsoc = Me.lblDireccion
      Me.bscDireccion.Location = New System.Drawing.Point(7, 71)
      Me.bscDireccion.Margin = New System.Windows.Forms.Padding(4)
      Me.bscDireccion.MaxLengh = "32767"
      Me.bscDireccion.Name = "bscDireccion"
      Me.bscDireccion.Permitido = True
      Me.bscDireccion.Selecciono = False
      Me.bscDireccion.Size = New System.Drawing.Size(315, 23)
      Me.bscDireccion.TabIndex = 4
      Me.bscDireccion.Titulo = Nothing
      '
      'lblDireccion
      '
      Me.lblDireccion.AutoSize = True
      Me.lblDireccion.LabelAsoc = Nothing
      Me.lblDireccion.Location = New System.Drawing.Point(4, 56)
      Me.lblDireccion.Name = "lblDireccion"
      Me.lblDireccion.Size = New System.Drawing.Size(95, 13)
      Me.lblDireccion.TabIndex = 17
      Me.lblDireccion.Text = "Dirección (ALT+D)"
      '
      'cmbVendedor
      '
      Me.cmbVendedor.BindearPropiedadControl = Nothing
      Me.cmbVendedor.BindearPropiedadEntidad = Nothing
      Me.cmbVendedor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cmbVendedor.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.cmbVendedor.ForeColorFocus = System.Drawing.Color.Red
      Me.cmbVendedor.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.cmbVendedor.FormattingEnabled = True
      Me.cmbVendedor.IsPK = False
      Me.cmbVendedor.IsRequired = False
      Me.cmbVendedor.Key = Nothing
      Me.cmbVendedor.LabelAsoc = Me.lblVendedor
      Me.cmbVendedor.Location = New System.Drawing.Point(410, 105)
      Me.cmbVendedor.Name = "cmbVendedor"
      Me.cmbVendedor.Size = New System.Drawing.Size(165, 21)
      Me.cmbVendedor.TabIndex = 10
      '
      'lblVendedor
      '
      Me.lblVendedor.AutoSize = True
      Me.lblVendedor.LabelAsoc = Nothing
      Me.lblVendedor.Location = New System.Drawing.Point(411, 92)
      Me.lblVendedor.Name = "lblVendedor"
      Me.lblVendedor.Size = New System.Drawing.Size(53, 13)
      Me.lblVendedor.TabIndex = 23
      Me.lblVendedor.Text = "Vendedor"
      '
      'cmbCobrador
      '
      Me.cmbCobrador.BindearPropiedadControl = Nothing
      Me.cmbCobrador.BindearPropiedadEntidad = Nothing
      Me.cmbCobrador.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cmbCobrador.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.cmbCobrador.ForeColorFocus = System.Drawing.Color.Red
      Me.cmbCobrador.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.cmbCobrador.FormattingEnabled = True
      Me.cmbCobrador.IsPK = False
      Me.cmbCobrador.IsRequired = False
      Me.cmbCobrador.Key = Nothing
      Me.cmbCobrador.LabelAsoc = Me.lblCobrador
      Me.cmbCobrador.Location = New System.Drawing.Point(581, 105)
      Me.cmbCobrador.Name = "cmbCobrador"
      Me.cmbCobrador.Size = New System.Drawing.Size(156, 21)
      Me.cmbCobrador.TabIndex = 11
      '
      'lblCobrador
      '
      Me.lblCobrador.AutoSize = True
      Me.lblCobrador.LabelAsoc = Nothing
      Me.lblCobrador.Location = New System.Drawing.Point(578, 92)
      Me.lblCobrador.Name = "lblCobrador"
      Me.lblCobrador.Size = New System.Drawing.Size(50, 13)
      Me.lblCobrador.TabIndex = 24
      Me.lblCobrador.Text = "Cobrador"
      '
      'llbOperacion
      '
      Me.llbOperacion.AutoSize = True
      Me.llbOperacion.Location = New System.Drawing.Point(572, 15)
      Me.llbOperacion.Name = "llbOperacion"
      Me.llbOperacion.Size = New System.Drawing.Size(79, 13)
      Me.llbOperacion.TabIndex = 15
      Me.llbOperacion.TabStop = True
      Me.llbOperacion.Text = "Nro. Operación"
      '
      'txtComentario
      '
      Me.txtComentario.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.txtComentario.BindearPropiedadControl = Nothing
      Me.txtComentario.BindearPropiedadEntidad = Nothing
      Me.txtComentario.ForeColorFocus = System.Drawing.Color.Red
      Me.txtComentario.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtComentario.Formato = ""
      Me.txtComentario.IsDecimal = False
      Me.txtComentario.IsNumber = False
      Me.txtComentario.IsPK = False
      Me.txtComentario.IsRequired = False
      Me.txtComentario.Key = ""
      Me.txtComentario.LabelAsoc = Me.lblComentario
      Me.txtComentario.Location = New System.Drawing.Point(7, 106)
      Me.txtComentario.MaxLength = 200
      Me.txtComentario.Name = "txtComentario"
      Me.txtComentario.Size = New System.Drawing.Size(400, 20)
      Me.txtComentario.TabIndex = 9
      '
      'lblComentario
      '
      Me.lblComentario.AutoSize = True
      Me.lblComentario.LabelAsoc = Nothing
      Me.lblComentario.Location = New System.Drawing.Point(4, 93)
      Me.lblComentario.Name = "lblComentario"
      Me.lblComentario.Size = New System.Drawing.Size(60, 13)
      Me.lblComentario.TabIndex = 21
      Me.lblComentario.Text = "Comentario"
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
      Me.bscCodigoCliente.Location = New System.Drawing.Point(10, 30)
      Me.bscCodigoCliente.MaxLengh = "32767"
      Me.bscCodigoCliente.Name = "bscCodigoCliente"
      Me.bscCodigoCliente.Permitido = True
      Me.bscCodigoCliente.PermitidoNoBackColor = System.Drawing.Color.FromArgb(CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer))
      Me.bscCodigoCliente.PermitidoNoForeColor = System.Drawing.Color.Black
      Me.bscCodigoCliente.PermitidoSiBackColor = System.Drawing.Color.White
      Me.bscCodigoCliente.PermitidoSiForeColor = System.Drawing.Color.Black
      Me.bscCodigoCliente.Selecciono = False
      Me.bscCodigoCliente.Size = New System.Drawing.Size(116, 20)
      Me.bscCodigoCliente.TabIndex = 0
      '
      'lblCodigoCliente
      '
      Me.lblCodigoCliente.AutoSize = True
      Me.lblCodigoCliente.LabelAsoc = Nothing
      Me.lblCodigoCliente.Location = New System.Drawing.Point(10, 15)
      Me.lblCodigoCliente.Name = "lblCodigoCliente"
      Me.lblCodigoCliente.Size = New System.Drawing.Size(40, 13)
      Me.lblCodigoCliente.TabIndex = 13
      Me.lblCodigoCliente.Text = "Codigo"
      '
      'dtpFecha
      '
      Me.dtpFecha.BindearPropiedadControl = Nothing
      Me.dtpFecha.BindearPropiedadEntidad = Nothing
      Me.dtpFecha.CustomFormat = "dd/MM/yyyy"
      Me.dtpFecha.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.dtpFecha.ForeColorFocus = System.Drawing.Color.Red
      Me.dtpFecha.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.dtpFecha.Format = System.Windows.Forms.DateTimePickerFormat.Custom
      Me.dtpFecha.IsPK = False
      Me.dtpFecha.IsRequired = False
      Me.dtpFecha.Key = ""
      Me.dtpFecha.LabelAsoc = Me.lblFecha
      Me.dtpFecha.Location = New System.Drawing.Point(748, 31)
      Me.dtpFecha.Name = "dtpFecha"
      Me.dtpFecha.Size = New System.Drawing.Size(98, 20)
      Me.dtpFecha.TabIndex = 3
      '
      'lblFecha
      '
      Me.lblFecha.AutoSize = True
      Me.lblFecha.LabelAsoc = Nothing
      Me.lblFecha.Location = New System.Drawing.Point(746, 16)
      Me.lblFecha.Name = "lblFecha"
      Me.lblFecha.Size = New System.Drawing.Size(37, 13)
      Me.lblFecha.TabIndex = 16
      Me.lblFecha.Text = "Fecha"
      '
      'bscCliente
      '
      Me.bscCliente.ActivarFiltroEnGrilla = True
      Me.bscCliente.AutoSize = True
      Me.bscCliente.BindearPropiedadControl = Nothing
      Me.bscCliente.BindearPropiedadEntidad = Nothing
      Me.bscCliente.ConfigBuscador = Nothing
      Me.bscCliente.Datos = Nothing
      Me.bscCliente.FilaDevuelta = Nothing
      Me.bscCliente.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.bscCliente.ForeColorFocus = System.Drawing.Color.Red
      Me.bscCliente.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
      Me.bscCliente.IsDecimal = False
      Me.bscCliente.IsNumber = False
      Me.bscCliente.IsPK = False
      Me.bscCliente.IsRequired = False
      Me.bscCliente.Key = ""
      Me.bscCliente.LabelAsoc = Me.lblNombre
      Me.bscCliente.Location = New System.Drawing.Point(130, 30)
      Me.bscCliente.Margin = New System.Windows.Forms.Padding(4)
      Me.bscCliente.MaxLengh = "32767"
      Me.bscCliente.Name = "bscCliente"
      Me.bscCliente.Permitido = True
      Me.bscCliente.PermitidoNoBackColor = System.Drawing.Color.FromArgb(CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer))
      Me.bscCliente.PermitidoNoForeColor = System.Drawing.Color.Black
      Me.bscCliente.PermitidoSiBackColor = System.Drawing.Color.White
      Me.bscCliente.PermitidoSiForeColor = System.Drawing.Color.Black
      Me.bscCliente.Selecciono = False
      Me.bscCliente.Size = New System.Drawing.Size(435, 23)
      Me.bscCliente.TabIndex = 1
      '
      'lblNombre
      '
      Me.lblNombre.AutoSize = True
      Me.lblNombre.LabelAsoc = Nothing
      Me.lblNombre.Location = New System.Drawing.Point(127, 16)
      Me.lblNombre.Name = "lblNombre"
      Me.lblNombre.Size = New System.Drawing.Size(44, 13)
      Me.lblNombre.TabIndex = 14
      Me.lblNombre.Text = "Nombre"
      '
      'txtTelefono
      '
      Me.txtTelefono.BindearPropiedadControl = Nothing
      Me.txtTelefono.BindearPropiedadEntidad = Nothing
      Me.txtTelefono.ForeColorFocus = System.Drawing.Color.Red
      Me.txtTelefono.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtTelefono.Formato = ""
      Me.txtTelefono.IsDecimal = False
      Me.txtTelefono.IsNumber = False
      Me.txtTelefono.IsPK = False
      Me.txtTelefono.IsRequired = False
      Me.txtTelefono.Key = ""
      Me.txtTelefono.LabelAsoc = Me.lblTelefono
      Me.txtTelefono.Location = New System.Drawing.Point(591, 72)
      Me.txtTelefono.Name = "txtTelefono"
      Me.txtTelefono.ReadOnly = True
      Me.txtTelefono.Size = New System.Drawing.Size(255, 20)
      Me.txtTelefono.TabIndex = 8
      Me.txtTelefono.TabStop = False
      '
      'lblTelefono
      '
      Me.lblTelefono.AutoSize = True
      Me.lblTelefono.LabelAsoc = Nothing
      Me.lblTelefono.Location = New System.Drawing.Point(588, 56)
      Me.lblTelefono.Name = "lblTelefono"
      Me.lblTelefono.Size = New System.Drawing.Size(92, 13)
      Me.lblTelefono.TabIndex = 21
      Me.lblTelefono.Text = "Telefono / Celular"
      '
      'txtCP
      '
      Me.txtCP.BindearPropiedadControl = Nothing
      Me.txtCP.BindearPropiedadEntidad = Nothing
      Me.txtCP.ForeColorFocus = System.Drawing.Color.Red
      Me.txtCP.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtCP.Formato = ""
      Me.txtCP.IsDecimal = False
      Me.txtCP.IsNumber = False
      Me.txtCP.IsPK = False
      Me.txtCP.IsRequired = False
      Me.txtCP.Key = ""
      Me.txtCP.LabelAsoc = Me.lblCodPostal
      Me.txtCP.Location = New System.Drawing.Point(329, 72)
      Me.txtCP.Name = "txtCP"
      Me.txtCP.ReadOnly = True
      Me.txtCP.Size = New System.Drawing.Size(52, 20)
      Me.txtCP.TabIndex = 5
      Me.txtCP.TabStop = False
      Me.txtCP.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'lblCodPostal
      '
      Me.lblCodPostal.AutoSize = True
      Me.lblCodPostal.LabelAsoc = Nothing
      Me.lblCodPostal.Location = New System.Drawing.Point(326, 56)
      Me.lblCodPostal.Name = "lblCodPostal"
      Me.lblCodPostal.Size = New System.Drawing.Size(61, 13)
      Me.lblCodPostal.TabIndex = 18
      Me.lblCodPostal.Text = "Cód. Postal"
      '
      'txtLocalidad
      '
      Me.txtLocalidad.BindearPropiedadControl = Nothing
      Me.txtLocalidad.BindearPropiedadEntidad = Nothing
      Me.txtLocalidad.ForeColorFocus = System.Drawing.Color.Red
      Me.txtLocalidad.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtLocalidad.Formato = ""
      Me.txtLocalidad.IsDecimal = False
      Me.txtLocalidad.IsNumber = False
      Me.txtLocalidad.IsPK = False
      Me.txtLocalidad.IsRequired = False
      Me.txtLocalidad.Key = ""
      Me.txtLocalidad.LabelAsoc = Me.lblLocalidad
      Me.txtLocalidad.Location = New System.Drawing.Point(387, 72)
      Me.txtLocalidad.Name = "txtLocalidad"
      Me.txtLocalidad.ReadOnly = True
      Me.txtLocalidad.Size = New System.Drawing.Size(197, 20)
      Me.txtLocalidad.TabIndex = 6
      Me.txtLocalidad.TabStop = False
      '
      'lblLocalidad
      '
      Me.lblLocalidad.AutoSize = True
      Me.lblLocalidad.LabelAsoc = Nothing
      Me.lblLocalidad.Location = New System.Drawing.Point(386, 56)
      Me.lblLocalidad.Name = "lblLocalidad"
      Me.lblLocalidad.Size = New System.Drawing.Size(53, 13)
      Me.lblLocalidad.TabIndex = 19
      Me.lblLocalidad.Text = "Localidad"
      '
      'txtNroOperacion
      '
      Me.txtNroOperacion.BindearPropiedadControl = Nothing
      Me.txtNroOperacion.BindearPropiedadEntidad = Nothing
      Me.txtNroOperacion.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.txtNroOperacion.ForeColorFocus = System.Drawing.Color.Red
      Me.txtNroOperacion.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtNroOperacion.Formato = ""
      Me.txtNroOperacion.IsDecimal = False
      Me.txtNroOperacion.IsNumber = True
      Me.txtNroOperacion.IsPK = False
      Me.txtNroOperacion.IsRequired = False
      Me.txtNroOperacion.Key = ""
      Me.txtNroOperacion.LabelAsoc = Nothing
      Me.txtNroOperacion.Location = New System.Drawing.Point(575, 30)
      Me.txtNroOperacion.Name = "txtNroOperacion"
      Me.txtNroOperacion.ReadOnly = True
      Me.txtNroOperacion.Size = New System.Drawing.Size(82, 20)
      Me.txtNroOperacion.TabIndex = 2
      Me.txtNroOperacion.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'DataGridViewTextBoxColumn1
      '
      Me.DataGridViewTextBoxColumn1.DataPropertyName = "NroCuota"
      Me.DataGridViewTextBoxColumn1.HeaderText = "Nro."
      Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
      Me.DataGridViewTextBoxColumn1.Width = 40
      '
      'DataGridViewTextBoxColumn2
      '
      Me.DataGridViewTextBoxColumn2.DataPropertyName = "FechaPago"
      DataGridViewCellStyle10.Format = "dd/MM/yyyy"
      DataGridViewCellStyle10.NullValue = "dd/MM/yyyy"
      Me.DataGridViewTextBoxColumn2.DefaultCellStyle = DataGridViewCellStyle10
      Me.DataGridViewTextBoxColumn2.HeaderText = "Pago"
      Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
      Me.DataGridViewTextBoxColumn2.Width = 80
      '
      'DataGridViewTextBoxColumn9
      '
      Me.DataGridViewTextBoxColumn9.DataPropertyName = "Importe"
      DataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
      DataGridViewCellStyle11.Format = "N2"
      DataGridViewCellStyle11.NullValue = Nothing
      Me.DataGridViewTextBoxColumn9.DefaultCellStyle = DataGridViewCellStyle11
      Me.DataGridViewTextBoxColumn9.HeaderText = "Importe"
      Me.DataGridViewTextBoxColumn9.Name = "DataGridViewTextBoxColumn9"
      Me.DataGridViewTextBoxColumn9.Width = 70
      '
      'DataGridViewTextBoxColumn4
      '
      Me.DataGridViewTextBoxColumn4.DataPropertyName = "Usuario"
      Me.DataGridViewTextBoxColumn4.HeaderText = "Usuario"
      Me.DataGridViewTextBoxColumn4.Name = "DataGridViewTextBoxColumn4"
      Me.DataGridViewTextBoxColumn4.Visible = False
      '
      'DataGridViewTextBoxColumn5
      '
      Me.DataGridViewTextBoxColumn5.DataPropertyName = "Password"
      Me.DataGridViewTextBoxColumn5.HeaderText = "Password"
      Me.DataGridViewTextBoxColumn5.Name = "DataGridViewTextBoxColumn5"
      Me.DataGridViewTextBoxColumn5.Visible = False
      '
      'DataGridViewTextBoxColumn6
      '
      Me.DataGridViewTextBoxColumn6.DataPropertyName = "NroOperacion"
      Me.DataGridViewTextBoxColumn6.HeaderText = "NroOperacionPago"
      Me.DataGridViewTextBoxColumn6.Name = "DataGridViewTextBoxColumn6"
      Me.DataGridViewTextBoxColumn6.Visible = False
      '
      'DataGridViewTextBoxColumn7
      '
      Me.DataGridViewTextBoxColumn7.DataPropertyName = "NroDocumento"
      Me.DataGridViewTextBoxColumn7.HeaderText = "NroDocumentoPago"
      Me.DataGridViewTextBoxColumn7.Name = "DataGridViewTextBoxColumn7"
      Me.DataGridViewTextBoxColumn7.Visible = False
      '
      'DataGridViewTextBoxColumn8
      '
      Me.DataGridViewTextBoxColumn8.DataPropertyName = "TipoDocumento"
      Me.DataGridViewTextBoxColumn8.HeaderText = "TipoDocumentoPago"
      Me.DataGridViewTextBoxColumn8.Name = "DataGridViewTextBoxColumn8"
      Me.DataGridViewTextBoxColumn8.Visible = False
      '
      'IdCliente2
      '
      Me.IdCliente2.DataPropertyName = "IdCliente"
      Me.IdCliente2.HeaderText = "IdCliente"
      Me.IdCliente2.Name = "IdCliente2"
      Me.IdCliente2.Visible = False
      Me.IdCliente2.Width = 80
      '
      'NombreCobradorPago
      '
      Me.NombreCobradorPago.DataPropertyName = "NombreCobrador"
      Me.NombreCobradorPago.HeaderText = "Cobrador"
      Me.NombreCobradorPago.Name = "NombreCobradorPago"
      '
      'IdCobrador
      '
      Me.IdCobrador.DataPropertyName = "IdCobrador"
      Me.IdCobrador.HeaderText = "IdCobrador"
      Me.IdCobrador.Name = "IdCobrador"
      Me.IdCobrador.Visible = False
      '
      'IdSucursalPago
      '
      Me.IdSucursalPago.DataPropertyName = "IdSucursal"
      Me.IdSucursalPago.HeaderText = "IdSucursalPago"
      Me.IdSucursalPago.Name = "IdSucursalPago"
      Me.IdSucursalPago.Visible = False
      '
      'FichaPagoAjuste
      '
      Me.FichaPagoAjuste.DataPropertyName = "FichaPagoAjuste"
      Me.FichaPagoAjuste.HeaderText = "PagosFichasEmitidas"
      Me.FichaPagoAjuste.Name = "FichaPagoAjuste"
      Me.FichaPagoAjuste.Visible = False
      '
      'IdCaja
      '
      Me.IdCaja.DataPropertyName = "IdCaja"
      DataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
      Me.IdCaja.DefaultCellStyle = DataGridViewCellStyle12
      Me.IdCaja.HeaderText = "Caja"
      Me.IdCaja.Name = "IdCaja"
      Me.IdCaja.Width = 40
      '
      'NumeroPlanilla
      '
      Me.NumeroPlanilla.DataPropertyName = "NumeroPlanilla"
      DataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
      Me.NumeroPlanilla.DefaultCellStyle = DataGridViewCellStyle13
      Me.NumeroPlanilla.HeaderText = "Plan."
      Me.NumeroPlanilla.Name = "NumeroPlanilla"
      Me.NumeroPlanilla.Width = 40
      '
      'NumeroMovimiento
      '
      Me.NumeroMovimiento.DataPropertyName = "NumeroMovimiento"
      DataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
      Me.NumeroMovimiento.DefaultCellStyle = DataGridViewCellStyle14
      Me.NumeroMovimiento.HeaderText = "Mov."
      Me.NumeroMovimiento.Name = "NumeroMovimiento"
      Me.NumeroMovimiento.Width = 50
      '
      'FichasABM
      '
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.ClientSize = New System.Drawing.Size(881, 508)
      Me.Controls.Add(Me.tspFichas)
      Me.Controls.Add(Me.tbcFichas)
      Me.Controls.Add(Me.stsPie)
      Me.Controls.Add(Me.grbCliente)
      Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
      Me.KeyPreview = True
      Me.Name = "FichasABM"
      Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
      Me.Text = "Fichas"
      Me.tspFichas.ResumeLayout(False)
      Me.tspFichas.PerformLayout()
      Me.tbcFichas.ResumeLayout(False)
      Me.tbpProductos.ResumeLayout(False)
      Me.tbpProductos.PerformLayout()
      CType(Me.dtgProductos, System.ComponentModel.ISupportInitialize).EndInit()
      Me.tbpPagos.ResumeLayout(False)
      Me.tbpPagos.PerformLayout()
      CType(Me.dgvPagos, System.ComponentModel.ISupportInitialize).EndInit()
      CType(Me.dgvCuotas, System.ComponentModel.ISupportInitialize).EndInit()
      Me.grbTotales.ResumeLayout(False)
      Me.grbTotales.PerformLayout()
      Me.grbDetallePago.ResumeLayout(False)
      Me.grbDetallePago.PerformLayout()
      Me.tbpCartasEmitidas.ResumeLayout(False)
      CType(Me.dgvCartasEmitidas, System.ComponentModel.ISupportInitialize).EndInit()
      Me.grbCliente.ResumeLayout(False)
      Me.grbCliente.PerformLayout()
      Me.ResumeLayout(False)
      Me.PerformLayout()

   End Sub
   Friend WithEvents grbCliente As System.Windows.Forms.GroupBox
   Friend WithEvents stsPie As System.Windows.Forms.StatusStrip
   Friend WithEvents lblNombre As Eniac.Controles.Label
   Friend WithEvents tbcFichas As System.Windows.Forms.TabControl
   Friend WithEvents tbpProductos As System.Windows.Forms.TabPage
   Friend WithEvents tbpPagos As System.Windows.Forms.TabPage
   Friend WithEvents lblCodigoCliente As Eniac.Controles.Label
   Friend WithEvents dtpFecha As Eniac.Controles.DateTimePicker
   Friend WithEvents lblFecha As Eniac.Controles.Label
   Friend WithEvents txtNroOperacion As Eniac.Controles.TextBox
   Friend WithEvents lblDireccion As Eniac.Controles.Label
   Friend WithEvents dtgProductos As Eniac.Controles.DataGridView
   Friend WithEvents grbTotales As System.Windows.Forms.GroupBox
   Friend WithEvents dgvCuotas As Eniac.Controles.DataGridView
   Friend WithEvents txtCP As Eniac.Controles.TextBox
   Friend WithEvents lblCodPostal As Eniac.Controles.Label
   Friend WithEvents txtLocalidad As Eniac.Controles.TextBox
   Friend WithEvents lblLocalidad As Eniac.Controles.Label
   Friend WithEvents lblBruto As Eniac.Controles.Label
   Friend WithEvents txtAnticipo As Eniac.Controles.TextBox
   Friend WithEvents lblAnticipo As Eniac.Controles.Label
   Friend WithEvents txtBruto As Eniac.Controles.TextBox
   Friend WithEvents txtSubTotal As Eniac.Controles.TextBox
   Friend WithEvents lblSubTotal As Eniac.Controles.Label
   Friend WithEvents txtTelefono As Eniac.Controles.TextBox
   Friend WithEvents lblTelefono As Eniac.Controles.Label
   Friend WithEvents lblTotal As Eniac.Controles.Label
   Friend WithEvents txtImpCuota As Eniac.Controles.TextBox
   Friend WithEvents lblImpCuota As Eniac.Controles.Label
   Friend WithEvents txtTotal As Eniac.Controles.TextBox
   Friend WithEvents lblFormaPago As Eniac.Controles.Label
   Friend WithEvents imgIconos As System.Windows.Forms.ImageList
   Friend WithEvents bscCliente As Eniac.Controles.Buscador2
   Friend WithEvents lblProducto As Eniac.Controles.Label
   Friend WithEvents bscProducto As Eniac.Controles.Buscador2
   Friend WithEvents txtCantidad As Eniac.Controles.TextBox
   Friend WithEvents lblCantidad As Eniac.Controles.Label
   Friend WithEvents txtPrecio As Eniac.Controles.TextBox
   Friend WithEvents lblPrecio As Eniac.Controles.Label
   Friend WithEvents btnInsertar As Eniac.Controles.Button
   Friend WithEvents txtTotalProducto As Eniac.Controles.TextBox
   Friend WithEvents llbTotalProducto As Eniac.Controles.Label
   Friend WithEvents btnEliminar As Eniac.Controles.Button
   Friend WithEvents lblIntereses As Eniac.Controles.Label
   Friend WithEvents txtIntereses As Eniac.Controles.TextBox
   Friend WithEvents lblComentario As Eniac.Controles.Label
   Friend WithEvents tlpMensaje As System.Windows.Forms.ToolTip
   Friend WithEvents tspFichas As System.Windows.Forms.ToolStrip
   Friend WithEvents tsbPago As System.Windows.Forms.ToolStripButton
   Friend WithEvents tsbImprimirFicha As System.Windows.Forms.ToolStripButton
   Friend WithEvents tsbSalir As System.Windows.Forms.ToolStripButton
   Friend WithEvents bscCodigoCliente As Eniac.Controles.Buscador2
   Friend WithEvents txtStock As Eniac.Controles.TextBox
   Friend WithEvents lblStock As Eniac.Controles.Label
   Friend WithEvents tsbImpFichaCliente As System.Windows.Forms.ToolStripButton
   Friend WithEvents cmbFormaPago As Eniac.Controles.ComboBox
   Friend WithEvents lblCuotas As Eniac.Controles.Label
   Friend WithEvents grbDetallePago As System.Windows.Forms.GroupBox
   Friend WithEvents txtComentario As Eniac.Controles.TextBox
   Friend WithEvents llbOperacion As Eniac.Controles.LinkLabel
   Friend WithEvents tsbNuevo As System.Windows.Forms.ToolStripButton
   Friend WithEvents btnGrabar As Eniac.Controles.Button
   Friend WithEvents txtTotalCuotas As Eniac.Controles.TextBox
   Friend WithEvents lblTotalCuotas As Eniac.Controles.Label
   Friend WithEvents lblCobrador As Eniac.Controles.Label
   Friend WithEvents dtpEntrego As Eniac.Controles.DateTimePicker
   Friend WithEvents lblFechaEntrega As Eniac.Controles.Label
   Friend WithEvents txtGarantia As Eniac.Controles.TextBox
   Friend WithEvents lblGarantia As Eniac.Controles.Label
   Friend WithEvents dgvPagos As Eniac.Controles.DataGridView
   Friend WithEvents txtCuotas As Eniac.Controles.TextBox
   Friend WithEvents cmbCobrador As Eniac.Controles.ComboBox
   Friend WithEvents txtSaldo As Eniac.Controles.TextBox
   Friend WithEvents lblSaldo As Eniac.Controles.Label
   Friend WithEvents cmbVendedor As Eniac.Controles.ComboBox
   Friend WithEvents lblVendedor As Eniac.Controles.Label
   Friend WithEvents tsbAnular As System.Windows.Forms.ToolStripButton
   Friend WithEvents bscProveedor As Eniac.Controles.Buscador
   Friend WithEvents lblProveedor As Eniac.Controles.Label
   Friend WithEvents tsbDevolverPago As System.Windows.Forms.ToolStripButton
   Friend WithEvents tsbRevisado As System.Windows.Forms.ToolStripButton
    Friend WithEvents tbpCartasEmitidas As System.Windows.Forms.TabPage
   Friend WithEvents dgvCartasEmitidas As Eniac.Controles.DataGridView
   Friend WithEvents TipoCarta As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents FechaEnvio As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents TipoDocumentoGarante As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents NroDocumentoGarante As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents NombreGarante As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents UsuarioCartas As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents bscDireccion As Eniac.Controles.Buscador
   Friend WithEvents llbCliente As Eniac.Controles.LinkLabel
   Friend WithEvents cmbCajas As Eniac.Controles.ComboBox
   Friend WithEvents lblCaja As Eniac.Controles.Label
    Friend WithEvents IdProducto As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents IdCliente As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents NombreCliente As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ProductoDesc As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Cantidad As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Precio As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Importe As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents FechaEntrega As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Garantia As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents NroOperacion As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Usuario As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Password As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents IdSucursal As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents NroCuota As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents IdCliente1 As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents FechaVencimiento As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents Saldo As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents UsuarioPagos As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents PasswordPagos As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents NroOperacionPago As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents NroDocumentoPago As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents TipoDocumentoPago As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents ImportePago As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents IdSucursalCuotas As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents DataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents DataGridViewTextBoxColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents DataGridViewTextBoxColumn9 As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents DataGridViewTextBoxColumn4 As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents DataGridViewTextBoxColumn5 As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents DataGridViewTextBoxColumn6 As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents DataGridViewTextBoxColumn7 As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents DataGridViewTextBoxColumn8 As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents IdCliente2 As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents NombreCobradorPago As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents IdCobrador As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents IdSucursalPago As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents FichaPagoAjuste As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents IdCaja As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents NumeroPlanilla As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents NumeroMovimiento As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
