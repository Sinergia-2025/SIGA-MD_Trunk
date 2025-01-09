<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ModificarComprobantes
   Inherits Eniac.Win.BaseForm

   'Form reemplaza a Dispose para limpiar la lista de componentes.
   <System.Diagnostics.DebuggerNonUserCode()> _
   Protected Overrides Sub Dispose(ByVal disposing As Boolean)
      If disposing AndAlso components IsNot Nothing Then
         components.Dispose()
      End If
      MyBase.Dispose(disposing)
   End Sub

   'Requerido por el Diseñador de Windows Forms
   Private components As System.ComponentModel.IContainer

   'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
   'Se puede modificar usando el Diseñador de Windows Forms.  
   'No lo modifique con el editor de código.
   <System.Diagnostics.DebuggerStepThrough()> _
   Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ModificarComprobantes))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle13 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle14 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle10 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle11 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle12 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle15 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle26 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle27 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle16 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle17 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle18 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle19 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle20 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle21 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle22 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle23 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle24 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle25 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.tspFacturacion = New System.Windows.Forms.ToolStrip()
        Me.tsbRefrescar = New System.Windows.Forms.ToolStripButton()
        Me.tsbSalir = New System.Windows.Forms.ToolStripButton()
        Me.imgIconos = New System.Windows.Forms.ImageList(Me.components)
        Me.grbDetalle = New System.Windows.Forms.GroupBox()
        Me.chkMesCompleto = New Eniac.Controles.CheckBox()
        Me.lblCliente = New Eniac.Controles.Label()
        Me.bscCodigoCliente = New Eniac.Controles.Buscador()
        Me.lblCodigoCliente = New Eniac.Controles.Label()
        Me.bscCliente = New Eniac.Controles.Buscador()
        Me.lblNombre = New Eniac.Controles.Label()
        Me.lblTipoComprobante = New Eniac.Controles.Label()
        Me.cmbTiposComprobantes = New Eniac.Controles.ComboBox()
        Me.btnBuscar = New Eniac.Controles.Button()
        Me.dtpHasta = New Eniac.Controles.DateTimePicker()
        Me.lblHasta = New Eniac.Controles.Label()
        Me.dtpDesde = New Eniac.Controles.DateTimePicker()
        Me.lblDesde = New Eniac.Controles.Label()
        Me.stsStado = New System.Windows.Forms.StatusStrip()
        Me.tssInfo = New System.Windows.Forms.ToolStripStatusLabel()
        Me.tspBarra = New System.Windows.Forms.ToolStripProgressBar()
        Me.tssRegistros = New System.Windows.Forms.ToolStripStatusLabel()
        Me.btnGrabar = New Eniac.Controles.Button()
        Me.btnEditar = New Eniac.Controles.Button()
        Me.dgvProductos = New Eniac.Controles.DataGridView()
        Me.pIdProducto = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.pProductoDesc = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.pCantidad = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.pPrecio = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.pDescuentoRecargoPorc1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.pDescuentoRecargoPorc2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.pDescuentoRecargo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.pPrecioNeto = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.pAlicuotaImpuesto = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.pImporteTotal = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.pCantidadNueva = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.pKilos = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.pPrecioLista = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.pUtilidad = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.pPassword = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.pCentroEmisor = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.pCosto = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.pUsuario = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.pNumeroComprobante = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.pTipoDocumento = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.pNroDocumento = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.pIdSucursal = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.pTipoComprobante = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.pLetra = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.pIva = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.pDescRecGeneral = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.pDescuentoRecargoProducto = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.pDescRecGeneralProducto = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.pImporteTotalNeto = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.pEsNoGravado = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.pStock = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.pOrden = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Producto = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.pTipoImpuesto = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.pImporteImpuesto = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgvFacturables = New Eniac.Controles.DataGridView()
        Me.Fecha = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.IdTipoComprobante = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Letra = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CentroEmisor = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.NroComprobante = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.IdEstadoComprobante = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ImporteBruto = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DescuentoRecargoPorc = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DescuentoRecargo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SubTotal = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TotalImpuestos = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ImporteTotal = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Kilos = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.txtSubtotal = New Eniac.Controles.TextBox()
        Me.txtTotal = New Eniac.Controles.TextBox()
        Me.lblNuevosTotales = New Eniac.Controles.Label()
        Me.txtTotalImpuestos = New Eniac.Controles.TextBox()
        Me.txtDescRecGralPorc = New Eniac.Controles.TextBox()
        Me.txtDescRecGral = New Eniac.Controles.TextBox()
        Me.txtBruto = New Eniac.Controles.TextBox()
        Me.txtKilos = New Eniac.Controles.TextBox()
        Me.txtNoGravado = New Eniac.Controles.TextBox()
        Me.tspFacturacion.SuspendLayout()
        Me.grbDetalle.SuspendLayout()
        Me.stsStado.SuspendLayout()
        CType(Me.dgvProductos, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvFacturables, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'tspFacturacion
        '
        Me.tspFacturacion.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsbRefrescar, Me.tsbSalir})
        Me.tspFacturacion.Location = New System.Drawing.Point(0, 0)
        Me.tspFacturacion.Name = "tspFacturacion"
        Me.tspFacturacion.Size = New System.Drawing.Size(923, 25)
        Me.tspFacturacion.TabIndex = 15
        Me.tspFacturacion.Text = "ToolStrip1"
        '
        'tsbRefrescar
        '
        Me.tsbRefrescar.Image = Global.Eniac.Win.My.Resources.Resources.refresh
        Me.tsbRefrescar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbRefrescar.Name = "tsbRefrescar"
        Me.tsbRefrescar.Size = New System.Drawing.Size(98, 22)
        Me.tsbRefrescar.Text = "&Refrescar (F5)"
        '
        'tsbSalir
        '
        Me.tsbSalir.Image = Global.Eniac.Win.My.Resources.Resources.redo
        Me.tsbSalir.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbSalir.Name = "tsbSalir"
        Me.tsbSalir.Size = New System.Drawing.Size(59, 22)
        Me.tsbSalir.Text = "&Cerrar"
        '
        'imgIconos
        '
        Me.imgIconos.ImageStream = CType(resources.GetObject("imgIconos.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.imgIconos.TransparentColor = System.Drawing.Color.Transparent
        Me.imgIconos.Images.SetKeyName(0, "row_add.ico")
        Me.imgIconos.Images.SetKeyName(1, "row_delete.ico")
        Me.imgIconos.Images.SetKeyName(2, "disk_blue.ico")
        Me.imgIconos.Images.SetKeyName(3, "document_find.ico")
        Me.imgIconos.Images.SetKeyName(4, "refresh.ico")
        '
        'grbDetalle
        '
        Me.grbDetalle.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
              Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grbDetalle.Controls.Add(Me.chkMesCompleto)
        Me.grbDetalle.Controls.Add(Me.lblCliente)
        Me.grbDetalle.Controls.Add(Me.bscCodigoCliente)
        Me.grbDetalle.Controls.Add(Me.bscCliente)
        Me.grbDetalle.Controls.Add(Me.lblCodigoCliente)
        Me.grbDetalle.Controls.Add(Me.lblNombre)
        Me.grbDetalle.Controls.Add(Me.lblTipoComprobante)
        Me.grbDetalle.Controls.Add(Me.cmbTiposComprobantes)
        Me.grbDetalle.Controls.Add(Me.btnBuscar)
        Me.grbDetalle.Controls.Add(Me.dtpHasta)
        Me.grbDetalle.Controls.Add(Me.dtpDesde)
        Me.grbDetalle.Controls.Add(Me.lblHasta)
        Me.grbDetalle.Controls.Add(Me.lblDesde)
        Me.grbDetalle.Location = New System.Drawing.Point(3, 28)
        Me.grbDetalle.Name = "grbDetalle"
        Me.grbDetalle.Size = New System.Drawing.Size(911, 85)
        Me.grbDetalle.TabIndex = 0
        Me.grbDetalle.TabStop = False
        Me.grbDetalle.Text = "Detalle"
        '
        'chkMesCompleto
        '
        Me.chkMesCompleto.AutoSize = True
        Me.chkMesCompleto.BindearPropiedadControl = Nothing
        Me.chkMesCompleto.BindearPropiedadEntidad = Nothing
        Me.chkMesCompleto.ForeColorFocus = System.Drawing.Color.Red
        Me.chkMesCompleto.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chkMesCompleto.IsPK = False
        Me.chkMesCompleto.IsRequired = False
        Me.chkMesCompleto.Key = Nothing
        Me.chkMesCompleto.LabelAsoc = Nothing
        Me.chkMesCompleto.Location = New System.Drawing.Point(17, 19)
        Me.chkMesCompleto.Name = "chkMesCompleto"
        Me.chkMesCompleto.Size = New System.Drawing.Size(93, 17)
        Me.chkMesCompleto.TabIndex = 0
        Me.chkMesCompleto.Text = "Mes Completo"
        Me.chkMesCompleto.UseVisualStyleBackColor = True
        '
        'lblCliente
        '
        Me.lblCliente.AutoSize = True
        Me.lblCliente.LabelAsoc = Nothing
        Me.lblCliente.Location = New System.Drawing.Point(14, 61)
        Me.lblCliente.Name = "lblCliente"
        Me.lblCliente.Size = New System.Drawing.Size(39, 13)
        Me.lblCliente.TabIndex = 7
        Me.lblCliente.Text = "Cliente"
        '
        'bscCodigoCliente
        '
        Me.bscCodigoCliente.AyudaAncho = 608
        Me.bscCodigoCliente.BindearPropiedadControl = Nothing
        Me.bscCodigoCliente.BindearPropiedadEntidad = Nothing
        Me.bscCodigoCliente.ColumnasAlineacion = Nothing
        Me.bscCodigoCliente.ColumnasAncho = Nothing
        Me.bscCodigoCliente.ColumnasFormato = Nothing
        Me.bscCodigoCliente.ColumnasOcultas = Nothing
        Me.bscCodigoCliente.ColumnasTitulos = Nothing
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
        Me.bscCodigoCliente.Location = New System.Drawing.Point(59, 56)
        Me.bscCodigoCliente.MaxLengh = "32767"
        Me.bscCodigoCliente.Name = "bscCodigoCliente"
        Me.bscCodigoCliente.Permitido = True
        Me.bscCodigoCliente.Selecciono = False
        Me.bscCodigoCliente.Size = New System.Drawing.Size(90, 23)
        Me.bscCodigoCliente.TabIndex = 11
        Me.bscCodigoCliente.Titulo = Nothing
        '
        'lblCodigoCliente
        '
        Me.lblCodigoCliente.AutoSize = True
        Me.lblCodigoCliente.LabelAsoc = Nothing
        Me.lblCodigoCliente.Location = New System.Drawing.Point(59, 44)
        Me.lblCodigoCliente.Name = "lblCodigoCliente"
        Me.lblCodigoCliente.Size = New System.Drawing.Size(40, 13)
        Me.lblCodigoCliente.TabIndex = 10
        Me.lblCodigoCliente.Text = "Código"
        '
        'bscCliente
        '
        Me.bscCliente.AutoSize = True
        Me.bscCliente.AyudaAncho = 608
        Me.bscCliente.BindearPropiedadControl = Nothing
        Me.bscCliente.BindearPropiedadEntidad = Nothing
        Me.bscCliente.ColumnasAlineacion = Nothing
        Me.bscCliente.ColumnasAncho = Nothing
        Me.bscCliente.ColumnasFormato = Nothing
        Me.bscCliente.ColumnasOcultas = Nothing
        Me.bscCliente.ColumnasTitulos = Nothing
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
        Me.bscCliente.Location = New System.Drawing.Point(156, 56)
        Me.bscCliente.Margin = New System.Windows.Forms.Padding(4)
        Me.bscCliente.MaxLengh = "32767"
        Me.bscCliente.Name = "bscCliente"
        Me.bscCliente.Permitido = True
        Me.bscCliente.Selecciono = False
        Me.bscCliente.Size = New System.Drawing.Size(300, 23)
        Me.bscCliente.TabIndex = 13
        Me.bscCliente.Titulo = Nothing
        '
        'lblNombre
        '
        Me.lblNombre.AutoSize = True
        Me.lblNombre.LabelAsoc = Nothing
        Me.lblNombre.Location = New System.Drawing.Point(153, 44)
        Me.lblNombre.Name = "lblNombre"
        Me.lblNombre.Size = New System.Drawing.Size(44, 13)
        Me.lblNombre.TabIndex = 12
        Me.lblNombre.Text = "Nombre"
        '
        'lblTipoComprobante
        '
        Me.lblTipoComprobante.AutoSize = True
        Me.lblTipoComprobante.LabelAsoc = Nothing
        Me.lblTipoComprobante.Location = New System.Drawing.Point(410, 20)
        Me.lblTipoComprobante.Name = "lblTipoComprobante"
        Me.lblTipoComprobante.Size = New System.Drawing.Size(94, 13)
        Me.lblTipoComprobante.TabIndex = 5
        Me.lblTipoComprobante.Text = "Tipo Comprobante"
        '
        'cmbTiposComprobantes
        '
        Me.cmbTiposComprobantes.BindearPropiedadControl = Nothing
        Me.cmbTiposComprobantes.BindearPropiedadEntidad = Nothing
        Me.cmbTiposComprobantes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbTiposComprobantes.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.cmbTiposComprobantes.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbTiposComprobantes.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbTiposComprobantes.FormattingEnabled = True
        Me.cmbTiposComprobantes.IsPK = False
        Me.cmbTiposComprobantes.IsRequired = False
        Me.cmbTiposComprobantes.ItemHeight = 13
        Me.cmbTiposComprobantes.Key = Nothing
        Me.cmbTiposComprobantes.LabelAsoc = Nothing
        Me.cmbTiposComprobantes.Location = New System.Drawing.Point(507, 17)
        Me.cmbTiposComprobantes.Name = "cmbTiposComprobantes"
        Me.cmbTiposComprobantes.Size = New System.Drawing.Size(184, 21)
        Me.cmbTiposComprobantes.TabIndex = 6
        '
        'btnBuscar
        '
        Me.btnBuscar.Image = Global.Eniac.Win.My.Resources.Resources.view
        Me.btnBuscar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnBuscar.Location = New System.Drawing.Point(773, 31)
        Me.btnBuscar.Name = "btnBuscar"
        Me.btnBuscar.Size = New System.Drawing.Size(100, 45)
        Me.btnBuscar.TabIndex = 14
        Me.btnBuscar.Text = "&Buscar"
        Me.btnBuscar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnBuscar.UseVisualStyleBackColor = True
        '
        'dtpHasta
        '
        Me.dtpHasta.BindearPropiedadControl = Nothing
        Me.dtpHasta.BindearPropiedadEntidad = Nothing
        Me.dtpHasta.CustomFormat = "dd/MM/yyyy"
        Me.dtpHasta.ForeColorFocus = System.Drawing.Color.Red
        Me.dtpHasta.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.dtpHasta.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpHasta.IsPK = False
        Me.dtpHasta.IsRequired = False
        Me.dtpHasta.Key = ""
        Me.dtpHasta.LabelAsoc = Me.lblHasta
        Me.dtpHasta.Location = New System.Drawing.Point(287, 17)
        Me.dtpHasta.Name = "dtpHasta"
        Me.dtpHasta.Size = New System.Drawing.Size(86, 20)
        Me.dtpHasta.TabIndex = 4
        '
        'lblHasta
        '
        Me.lblHasta.AutoSize = True
        Me.lblHasta.LabelAsoc = Nothing
        Me.lblHasta.Location = New System.Drawing.Point(249, 21)
        Me.lblHasta.Name = "lblHasta"
        Me.lblHasta.Size = New System.Drawing.Size(35, 13)
        Me.lblHasta.TabIndex = 3
        Me.lblHasta.Text = "Hasta"
        '
        'dtpDesde
        '
        Me.dtpDesde.BindearPropiedadControl = Nothing
        Me.dtpDesde.BindearPropiedadEntidad = Nothing
        Me.dtpDesde.CustomFormat = "dd/MM/yyyy"
        Me.dtpDesde.ForeColorFocus = System.Drawing.Color.Red
        Me.dtpDesde.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.dtpDesde.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpDesde.IsPK = False
        Me.dtpDesde.IsRequired = False
        Me.dtpDesde.Key = ""
        Me.dtpDesde.LabelAsoc = Me.lblDesde
        Me.dtpDesde.Location = New System.Drawing.Point(153, 17)
        Me.dtpDesde.Name = "dtpDesde"
        Me.dtpDesde.Size = New System.Drawing.Size(86, 20)
        Me.dtpDesde.TabIndex = 2
        '
        'lblDesde
        '
        Me.lblDesde.AutoSize = True
        Me.lblDesde.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblDesde.LabelAsoc = Nothing
        Me.lblDesde.Location = New System.Drawing.Point(112, 21)
        Me.lblDesde.Name = "lblDesde"
        Me.lblDesde.Size = New System.Drawing.Size(38, 13)
        Me.lblDesde.TabIndex = 1
        Me.lblDesde.Text = "Desde"
        '
        'stsStado
        '
        Me.stsStado.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tssInfo, Me.tspBarra, Me.tssRegistros})
        Me.stsStado.Location = New System.Drawing.Point(0, 571)
        Me.stsStado.Name = "stsStado"
        Me.stsStado.Size = New System.Drawing.Size(923, 22)
        Me.stsStado.TabIndex = 14
        Me.stsStado.Text = "statusStrip1"
        '
        'tssInfo
        '
        Me.tssInfo.Name = "tssInfo"
        Me.tssInfo.Size = New System.Drawing.Size(844, 17)
        Me.tssInfo.Spring = True
        '
        'tspBarra
        '
        Me.tspBarra.Name = "tspBarra"
        Me.tspBarra.Size = New System.Drawing.Size(100, 16)
        Me.tspBarra.Style = System.Windows.Forms.ProgressBarStyle.Continuous
        Me.tspBarra.Visible = False
        '
        'tssRegistros
        '
        Me.tssRegistros.Name = "tssRegistros"
        Me.tssRegistros.Size = New System.Drawing.Size(64, 17)
        Me.tssRegistros.Text = "0 Registros"
        '
        'btnGrabar
        '
        Me.btnGrabar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnGrabar.Image = Global.Eniac.Win.My.Resources.Resources.disk_blue
        Me.btnGrabar.Location = New System.Drawing.Point(86, 333)
        Me.btnGrabar.Name = "btnGrabar"
        Me.btnGrabar.Size = New System.Drawing.Size(80, 37)
        Me.btnGrabar.TabIndex = 3
        Me.btnGrabar.Text = "&Grabar"
        Me.btnGrabar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnGrabar.UseVisualStyleBackColor = True
        '
        'btnEditar
        '
        Me.btnEditar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnEditar.ImageIndex = 0
        Me.btnEditar.ImageList = Me.imgIconos
        Me.btnEditar.Location = New System.Drawing.Point(5, 333)
        Me.btnEditar.Name = "btnEditar"
        Me.btnEditar.Size = New System.Drawing.Size(72, 36)
        Me.btnEditar.TabIndex = 2
        Me.btnEditar.Text = "&Editar"
        Me.btnEditar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnEditar.UseVisualStyleBackColor = True
        '
        'dgvProductos
        '
        Me.dgvProductos.AllowUserToAddRows = False
        Me.dgvProductos.AllowUserToDeleteRows = False
        Me.dgvProductos.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
              Or System.Windows.Forms.AnchorStyles.Left) _
              Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvProductos.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvProductos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvProductos.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.pIdProducto, Me.pProductoDesc, Me.pCantidad, Me.pPrecio, Me.pDescuentoRecargoPorc1, Me.pDescuentoRecargoPorc2, Me.pDescuentoRecargo, Me.pPrecioNeto, Me.pAlicuotaImpuesto, Me.pImporteTotal, Me.pCantidadNueva, Me.pKilos, Me.pPrecioLista, Me.pUtilidad, Me.pPassword, Me.pCentroEmisor, Me.pCosto, Me.pUsuario, Me.pNumeroComprobante, Me.pTipoDocumento, Me.pNroDocumento, Me.pIdSucursal, Me.pTipoComprobante, Me.pLetra, Me.pIva, Me.pDescRecGeneral, Me.pDescuentoRecargoProducto, Me.pDescRecGeneralProducto, Me.pImporteTotalNeto, Me.pEsNoGravado, Me.pStock, Me.pOrden, Me.Producto, Me.pTipoImpuesto, Me.pImporteImpuesto})
        DataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle13.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle13.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle13.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle13.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle13.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle13.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvProductos.DefaultCellStyle = DataGridViewCellStyle13
        Me.dgvProductos.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnKeystroke
        Me.dgvProductos.Location = New System.Drawing.Point(5, 375)
        Me.dgvProductos.MultiSelect = False
        Me.dgvProductos.Name = "dgvProductos"
        DataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle14.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle14.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle14.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle14.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle14.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle14.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvProductos.RowHeadersDefaultCellStyle = DataGridViewCellStyle14
        Me.dgvProductos.RowHeadersWidth = 10
        Me.dgvProductos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.dgvProductos.Size = New System.Drawing.Size(909, 191)
        Me.dgvProductos.TabIndex = 13
        '
        'pIdProducto
        '
        Me.pIdProducto.DataPropertyName = "IdProducto"
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.pIdProducto.DefaultCellStyle = DataGridViewCellStyle2
        Me.pIdProducto.HeaderText = "Código"
        Me.pIdProducto.Name = "pIdProducto"
        Me.pIdProducto.ReadOnly = True
        Me.pIdProducto.ToolTipText = "Código del producto"
        '
        'pProductoDesc
        '
        Me.pProductoDesc.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.pProductoDesc.DataPropertyName = "NombreProducto"
        Me.pProductoDesc.HeaderText = "Descripción"
        Me.pProductoDesc.Name = "pProductoDesc"
        Me.pProductoDesc.ReadOnly = True
        '
        'pCantidad
        '
        Me.pCantidad.DataPropertyName = "Cantidad"
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle3.NullValue = Nothing
        Me.pCantidad.DefaultCellStyle = DataGridViewCellStyle3
        Me.pCantidad.HeaderText = "Cantidad"
        Me.pCantidad.Name = "pCantidad"
        Me.pCantidad.ReadOnly = True
        Me.pCantidad.Width = 65
        '
        'pPrecio
        '
        Me.pPrecio.DataPropertyName = "Precio"
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle4.Format = "N2"
        DataGridViewCellStyle4.NullValue = Nothing
        Me.pPrecio.DefaultCellStyle = DataGridViewCellStyle4
        Me.pPrecio.HeaderText = "Precio"
        Me.pPrecio.Name = "pPrecio"
        Me.pPrecio.ReadOnly = True
        Me.pPrecio.Width = 70
        '
        'pDescuentoRecargoPorc1
        '
        Me.pDescuentoRecargoPorc1.DataPropertyName = "DescuentoRecargoPorc1"
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle5.Format = "N2"
        Me.pDescuentoRecargoPorc1.DefaultCellStyle = DataGridViewCellStyle5
        Me.pDescuentoRecargoPorc1.HeaderText = "D/R % 1"
        Me.pDescuentoRecargoPorc1.Name = "pDescuentoRecargoPorc1"
        Me.pDescuentoRecargoPorc1.Width = 40
        '
        'pDescuentoRecargoPorc2
        '
        Me.pDescuentoRecargoPorc2.DataPropertyName = "DescuentoRecargoPorc2"
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle6.Format = "N2"
        Me.pDescuentoRecargoPorc2.DefaultCellStyle = DataGridViewCellStyle6
        Me.pDescuentoRecargoPorc2.HeaderText = "D/R % 2"
        Me.pDescuentoRecargoPorc2.Name = "pDescuentoRecargoPorc2"
        Me.pDescuentoRecargoPorc2.Width = 40
        '
        'pDescuentoRecargo
        '
        Me.pDescuentoRecargo.DataPropertyName = "DescuentoRecargo"
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle7.Format = "N2"
        DataGridViewCellStyle7.NullValue = Nothing
        Me.pDescuentoRecargo.DefaultCellStyle = DataGridViewCellStyle7
        Me.pDescuentoRecargo.HeaderText = "Desc./Rec."
        Me.pDescuentoRecargo.Name = "pDescuentoRecargo"
        Me.pDescuentoRecargo.ReadOnly = True
        Me.pDescuentoRecargo.Visible = False
        Me.pDescuentoRecargo.Width = 70
        '
        'pPrecioNeto
        '
        Me.pPrecioNeto.DataPropertyName = "PrecioNeto"
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle8.Format = "N2"
        Me.pPrecioNeto.DefaultCellStyle = DataGridViewCellStyle8
        Me.pPrecioNeto.HeaderText = "Precio Unit."
        Me.pPrecioNeto.Name = "pPrecioNeto"
        Me.pPrecioNeto.Width = 70
        '
        'pAlicuotaImpuesto
        '
        Me.pAlicuotaImpuesto.DataPropertyName = "AlicuotaImpuesto"
        DataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle9.Format = "N2"
        Me.pAlicuotaImpuesto.DefaultCellStyle = DataGridViewCellStyle9
        Me.pAlicuotaImpuesto.HeaderText = "IVA"
        Me.pAlicuotaImpuesto.Name = "pAlicuotaImpuesto"
        Me.pAlicuotaImpuesto.Width = 40
        '
        'pImporteTotal
        '
        Me.pImporteTotal.DataPropertyName = "ImporteTotal"
        DataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle10.Format = "N2"
        DataGridViewCellStyle10.NullValue = Nothing
        Me.pImporteTotal.DefaultCellStyle = DataGridViewCellStyle10
        Me.pImporteTotal.HeaderText = "Importe"
        Me.pImporteTotal.Name = "pImporteTotal"
        Me.pImporteTotal.ReadOnly = True
        Me.pImporteTotal.Width = 70
        '
        'pCantidadNueva
        '
        Me.pCantidadNueva.DataPropertyName = "CantidadNueva"
        DataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle11.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        DataGridViewCellStyle11.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        DataGridViewCellStyle11.Format = "N2"
        DataGridViewCellStyle11.NullValue = Nothing
        Me.pCantidadNueva.DefaultCellStyle = DataGridViewCellStyle11
        Me.pCantidadNueva.HeaderText = "Cantidad Nueva"
        Me.pCantidadNueva.Name = "pCantidadNueva"
        Me.pCantidadNueva.ReadOnly = True
        Me.pCantidadNueva.Width = 65
        '
        'pKilos
        '
        Me.pKilos.DataPropertyName = "Kilos"
        DataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle12.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        DataGridViewCellStyle12.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        DataGridViewCellStyle12.Format = "N2"
        Me.pKilos.DefaultCellStyle = DataGridViewCellStyle12
        Me.pKilos.HeaderText = "Kilos Nuevo"
        Me.pKilos.Name = "pKilos"
        Me.pKilos.Width = 65
        '
        'pPrecioLista
        '
        Me.pPrecioLista.DataPropertyName = "PrecioLista"
        Me.pPrecioLista.HeaderText = "PrecioLista"
        Me.pPrecioLista.Name = "pPrecioLista"
        Me.pPrecioLista.Visible = False
        '
        'pUtilidad
        '
        Me.pUtilidad.DataPropertyName = "Utilidad"
        Me.pUtilidad.HeaderText = "Utilidad"
        Me.pUtilidad.Name = "pUtilidad"
        Me.pUtilidad.Visible = False
        '
        'pPassword
        '
        Me.pPassword.DataPropertyName = "Password"
        Me.pPassword.HeaderText = "Password"
        Me.pPassword.Name = "pPassword"
        Me.pPassword.Visible = False
        '
        'pCentroEmisor
        '
        Me.pCentroEmisor.DataPropertyName = "CentroEmisor"
        Me.pCentroEmisor.HeaderText = "CentroEmisor"
        Me.pCentroEmisor.Name = "pCentroEmisor"
        Me.pCentroEmisor.Visible = False
        '
        'pCosto
        '
        Me.pCosto.DataPropertyName = "Costo"
        Me.pCosto.HeaderText = "Costo"
        Me.pCosto.Name = "pCosto"
        Me.pCosto.Visible = False
        '
        'pUsuario
        '
        Me.pUsuario.DataPropertyName = "Usuario"
        Me.pUsuario.HeaderText = "Usuario"
        Me.pUsuario.Name = "pUsuario"
        Me.pUsuario.Visible = False
        '
        'pNumeroComprobante
        '
        Me.pNumeroComprobante.DataPropertyName = "NumeroComprobante"
        Me.pNumeroComprobante.HeaderText = "NroComprobante"
        Me.pNumeroComprobante.Name = "pNumeroComprobante"
        Me.pNumeroComprobante.Visible = False
        '
        'pTipoDocumento
        '
        Me.pTipoDocumento.DataPropertyName = "TipoDocumento"
        Me.pTipoDocumento.HeaderText = "TipoDocumento"
        Me.pTipoDocumento.Name = "pTipoDocumento"
        Me.pTipoDocumento.Visible = False
        '
        'pNroDocumento
        '
        Me.pNroDocumento.DataPropertyName = "NroDocumento"
        Me.pNroDocumento.HeaderText = "NroDocumento"
        Me.pNroDocumento.Name = "pNroDocumento"
        Me.pNroDocumento.Visible = False
        '
        'pIdSucursal
        '
        Me.pIdSucursal.DataPropertyName = "IdSucursal"
        Me.pIdSucursal.HeaderText = "IdSucursal"
        Me.pIdSucursal.Name = "pIdSucursal"
        Me.pIdSucursal.Visible = False
        '
        'pTipoComprobante
        '
        Me.pTipoComprobante.DataPropertyName = "TipoComprobante"
        Me.pTipoComprobante.HeaderText = "TipoComprobante"
        Me.pTipoComprobante.Name = "pTipoComprobante"
        Me.pTipoComprobante.Visible = False
        '
        'pLetra
        '
        Me.pLetra.DataPropertyName = "Letra"
        Me.pLetra.HeaderText = "letra"
        Me.pLetra.Name = "pLetra"
        Me.pLetra.Visible = False
        '
        'pIva
        '
        Me.pIva.DataPropertyName = "Iva"
        Me.pIva.HeaderText = "Iva"
        Me.pIva.Name = "pIva"
        Me.pIva.Visible = False
        '
        'pDescRecGeneral
        '
        Me.pDescRecGeneral.DataPropertyName = "DescRecGeneral"
        Me.pDescRecGeneral.HeaderText = "DescRecGeneral"
        Me.pDescRecGeneral.Name = "pDescRecGeneral"
        Me.pDescRecGeneral.Visible = False
        '
        'pDescuentoRecargoProducto
        '
        Me.pDescuentoRecargoProducto.DataPropertyName = "DescuentoRecargoProducto"
        Me.pDescuentoRecargoProducto.HeaderText = "DescuentoRecargoProducto"
        Me.pDescuentoRecargoProducto.Name = "pDescuentoRecargoProducto"
        Me.pDescuentoRecargoProducto.Visible = False
        '
        'pDescRecGeneralProducto
        '
        Me.pDescRecGeneralProducto.DataPropertyName = "DescRecGeneralProducto"
        Me.pDescRecGeneralProducto.HeaderText = "DescRecGeneralProducto"
        Me.pDescRecGeneralProducto.Name = "pDescRecGeneralProducto"
        Me.pDescRecGeneralProducto.Visible = False
        '
        'pImporteTotalNeto
        '
        Me.pImporteTotalNeto.DataPropertyName = "ImporteTotalNeto"
        Me.pImporteTotalNeto.HeaderText = "ImporteTotalNeto"
        Me.pImporteTotalNeto.Name = "pImporteTotalNeto"
        Me.pImporteTotalNeto.Visible = False
        '
        'pEsNoGravado
        '
        Me.pEsNoGravado.DataPropertyName = "EsNoGravado"
        Me.pEsNoGravado.HeaderText = "EsNoGravado"
        Me.pEsNoGravado.Name = "pEsNoGravado"
        Me.pEsNoGravado.Visible = False
        '
        'pStock
        '
        Me.pStock.DataPropertyName = "Stock"
        Me.pStock.HeaderText = "Stock"
        Me.pStock.Name = "pStock"
        Me.pStock.Visible = False
        '
        'pOrden
        '
        Me.pOrden.DataPropertyName = "Orden"
        Me.pOrden.HeaderText = "Orden"
        Me.pOrden.Name = "pOrden"
        Me.pOrden.Visible = False
        '
        'Producto
        '
        Me.Producto.DataPropertyName = "Producto"
        Me.Producto.HeaderText = "Producto"
        Me.Producto.Name = "Producto"
        Me.Producto.Visible = False
        '
        'pTipoImpuesto
        '
        Me.pTipoImpuesto.DataPropertyName = "TipoImpuesto"
        Me.pTipoImpuesto.HeaderText = "TipoImpuesto"
        Me.pTipoImpuesto.Name = "pTipoImpuesto"
        Me.pTipoImpuesto.Visible = False
        '
        'pImporteImpuesto
        '
        Me.pImporteImpuesto.DataPropertyName = "ImporteImpuesto"
        Me.pImporteImpuesto.HeaderText = "ImporteImpuesto"
        Me.pImporteImpuesto.Name = "pImporteImpuesto"
        Me.pImporteImpuesto.Visible = False
        '
        'dgvFacturables
        '
        Me.dgvFacturables.AllowUserToAddRows = False
        Me.dgvFacturables.AllowUserToDeleteRows = False
        Me.dgvFacturables.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
              Or System.Windows.Forms.AnchorStyles.Left) _
              Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        DataGridViewCellStyle15.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle15.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle15.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle15.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle15.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle15.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle15.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvFacturables.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle15
        Me.dgvFacturables.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvFacturables.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Fecha, Me.IdTipoComprobante, Me.Letra, Me.CentroEmisor, Me.NroComprobante, Me.IdEstadoComprobante, Me.ImporteBruto, Me.DescuentoRecargoPorc, Me.DescuentoRecargo, Me.SubTotal, Me.TotalImpuestos, Me.ImporteTotal, Me.Kilos})
        DataGridViewCellStyle26.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle26.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle26.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle26.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle26.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle26.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle26.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvFacturables.DefaultCellStyle = DataGridViewCellStyle26
        Me.dgvFacturables.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.dgvFacturables.Location = New System.Drawing.Point(5, 119)
        Me.dgvFacturables.MultiSelect = False
        Me.dgvFacturables.Name = "dgvFacturables"
        Me.dgvFacturables.ReadOnly = True
        DataGridViewCellStyle27.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle27.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle27.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle27.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle27.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle27.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle27.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvFacturables.RowHeadersDefaultCellStyle = DataGridViewCellStyle27
        Me.dgvFacturables.RowHeadersWidth = 10
        Me.dgvFacturables.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvFacturables.Size = New System.Drawing.Size(909, 212)
        Me.dgvFacturables.TabIndex = 1
        '
        'Fecha
        '
        Me.Fecha.DataPropertyName = "Fecha"
        DataGridViewCellStyle16.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle16.Format = "dd/MM/yyyy HH:mm"
        DataGridViewCellStyle16.NullValue = Nothing
        Me.Fecha.DefaultCellStyle = DataGridViewCellStyle16
        Me.Fecha.HeaderText = "Fecha"
        Me.Fecha.Name = "Fecha"
        Me.Fecha.ReadOnly = True
        '
        'IdTipoComprobante
        '
        Me.IdTipoComprobante.DataPropertyName = "IdTipoComprobante"
        Me.IdTipoComprobante.HeaderText = "Comprobante"
        Me.IdTipoComprobante.Name = "IdTipoComprobante"
        Me.IdTipoComprobante.ReadOnly = True
        Me.IdTipoComprobante.Visible = False
        Me.IdTipoComprobante.Width = 84
        '
        'Letra
        '
        Me.Letra.DataPropertyName = "Letra"
        DataGridViewCellStyle17.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.Letra.DefaultCellStyle = DataGridViewCellStyle17
        Me.Letra.HeaderText = "L."
        Me.Letra.Name = "Letra"
        Me.Letra.ReadOnly = True
        Me.Letra.Width = 30
        '
        'CentroEmisor
        '
        Me.CentroEmisor.DataPropertyName = "CentroEmisor"
        DataGridViewCellStyle18.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.CentroEmisor.DefaultCellStyle = DataGridViewCellStyle18
        Me.CentroEmisor.HeaderText = "Emisor"
        Me.CentroEmisor.Name = "CentroEmisor"
        Me.CentroEmisor.ReadOnly = True
        Me.CentroEmisor.Width = 50
        '
        'NroComprobante
        '
        Me.NroComprobante.DataPropertyName = "NumeroComprobante"
        DataGridViewCellStyle19.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.NroComprobante.DefaultCellStyle = DataGridViewCellStyle19
        Me.NroComprobante.HeaderText = "Numero"
        Me.NroComprobante.Name = "NroComprobante"
        Me.NroComprobante.ReadOnly = True
        Me.NroComprobante.Width = 70
        '
        'IdEstadoComprobante
        '
        Me.IdEstadoComprobante.DataPropertyName = "IdEstadoComprobante"
        Me.IdEstadoComprobante.HeaderText = "Estado"
        Me.IdEstadoComprobante.Name = "IdEstadoComprobante"
        Me.IdEstadoComprobante.ReadOnly = True
        Me.IdEstadoComprobante.Visible = False
        Me.IdEstadoComprobante.Width = 90
        '
        'ImporteBruto
        '
        Me.ImporteBruto.DataPropertyName = "ImporteBruto"
        DataGridViewCellStyle20.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle20.Format = "N2"
        Me.ImporteBruto.DefaultCellStyle = DataGridViewCellStyle20
        Me.ImporteBruto.HeaderText = "Bruto"
        Me.ImporteBruto.Name = "ImporteBruto"
        Me.ImporteBruto.ReadOnly = True
        Me.ImporteBruto.Width = 70
        '
        'DescuentoRecargoPorc
        '
        Me.DescuentoRecargoPorc.DataPropertyName = "DescuentoRecargoPorc"
        DataGridViewCellStyle21.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle21.Format = "N2"
        Me.DescuentoRecargoPorc.DefaultCellStyle = DataGridViewCellStyle21
        Me.DescuentoRecargoPorc.HeaderText = "D/R Porc."
        Me.DescuentoRecargoPorc.Name = "DescuentoRecargoPorc"
        Me.DescuentoRecargoPorc.ReadOnly = True
        Me.DescuentoRecargoPorc.Width = 50
        '
        'DescuentoRecargo
        '
        Me.DescuentoRecargo.DataPropertyName = "DescuentoRecargo"
        DataGridViewCellStyle22.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle22.Format = "N2"
        Me.DescuentoRecargo.DefaultCellStyle = DataGridViewCellStyle22
        Me.DescuentoRecargo.HeaderText = "Desc. / Rec."
        Me.DescuentoRecargo.Name = "DescuentoRecargo"
        Me.DescuentoRecargo.ReadOnly = True
        Me.DescuentoRecargo.Width = 70
        '
        'SubTotal
        '
        Me.SubTotal.DataPropertyName = "SubTotal"
        DataGridViewCellStyle23.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle23.Format = "N2"
        DataGridViewCellStyle23.NullValue = Nothing
        Me.SubTotal.DefaultCellStyle = DataGridViewCellStyle23
        Me.SubTotal.HeaderText = "Neto"
        Me.SubTotal.Name = "SubTotal"
        Me.SubTotal.ReadOnly = True
        Me.SubTotal.Width = 70
        '
        'TotalImpuestos
        '
        Me.TotalImpuestos.DataPropertyName = "TotalImpuestos"
        Me.TotalImpuestos.HeaderText = "Impuestos"
        Me.TotalImpuestos.Name = "TotalImpuestos"
        Me.TotalImpuestos.ReadOnly = True
        Me.TotalImpuestos.Width = 70
        '
        'ImporteTotal
        '
        Me.ImporteTotal.DataPropertyName = "ImporteTotal"
        DataGridViewCellStyle24.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle24.Format = "N2"
        Me.ImporteTotal.DefaultCellStyle = DataGridViewCellStyle24
        Me.ImporteTotal.HeaderText = "Total"
        Me.ImporteTotal.Name = "ImporteTotal"
        Me.ImporteTotal.ReadOnly = True
        Me.ImporteTotal.Width = 80
        '
        'Kilos
        '
        Me.Kilos.DataPropertyName = "Kilos"
        DataGridViewCellStyle25.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle25.Format = "N2"
        Me.Kilos.DefaultCellStyle = DataGridViewCellStyle25
        Me.Kilos.HeaderText = "Kilos"
        Me.Kilos.Name = "Kilos"
        Me.Kilos.ReadOnly = True
        Me.Kilos.Width = 80
        '
        'txtSubtotal
        '
        Me.txtSubtotal.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtSubtotal.BindearPropiedadControl = Nothing
        Me.txtSubtotal.BindearPropiedadEntidad = Nothing
        Me.txtSubtotal.ForeColorFocus = System.Drawing.Color.Red
        Me.txtSubtotal.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtSubtotal.Formato = "##0.00"
        Me.txtSubtotal.IsDecimal = True
        Me.txtSubtotal.IsNumber = True
        Me.txtSubtotal.IsPK = False
        Me.txtSubtotal.IsRequired = False
        Me.txtSubtotal.Key = ""
        Me.txtSubtotal.LabelAsoc = Nothing
        Me.txtSubtotal.Location = New System.Drawing.Point(556, 341)
        Me.txtSubtotal.Name = "txtSubtotal"
        Me.txtSubtotal.ReadOnly = True
        Me.txtSubtotal.Size = New System.Drawing.Size(70, 20)
        Me.txtSubtotal.TabIndex = 9
        Me.txtSubtotal.Text = "0.00"
        Me.txtSubtotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtTotal
        '
        Me.txtTotal.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtTotal.BindearPropiedadControl = Nothing
        Me.txtTotal.BindearPropiedadEntidad = Nothing
        Me.txtTotal.ForeColorFocus = System.Drawing.Color.Red
        Me.txtTotal.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtTotal.Formato = ""
        Me.txtTotal.IsDecimal = False
        Me.txtTotal.IsNumber = False
        Me.txtTotal.IsPK = False
        Me.txtTotal.IsRequired = False
        Me.txtTotal.Key = ""
        Me.txtTotal.LabelAsoc = Nothing
        Me.txtTotal.Location = New System.Drawing.Point(696, 341)
        Me.txtTotal.Name = "txtTotal"
        Me.txtTotal.ReadOnly = True
        Me.txtTotal.Size = New System.Drawing.Size(80, 20)
        Me.txtTotal.TabIndex = 11
        Me.txtTotal.Text = "0.00"
        Me.txtTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblNuevosTotales
        '
        Me.lblNuevosTotales.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblNuevosTotales.AutoSize = True
        Me.lblNuevosTotales.LabelAsoc = Nothing
        Me.lblNuevosTotales.Location = New System.Drawing.Point(273, 345)
        Me.lblNuevosTotales.Name = "lblNuevosTotales"
        Me.lblNuevosTotales.Size = New System.Drawing.Size(85, 13)
        Me.lblNuevosTotales.TabIndex = 5
        Me.lblNuevosTotales.Text = "Nuevos Totales:"
        '
        'txtTotalImpuestos
        '
        Me.txtTotalImpuestos.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtTotalImpuestos.BindearPropiedadControl = Nothing
        Me.txtTotalImpuestos.BindearPropiedadEntidad = Nothing
        Me.txtTotalImpuestos.ForeColorFocus = System.Drawing.Color.Red
        Me.txtTotalImpuestos.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtTotalImpuestos.Formato = "##0.00"
        Me.txtTotalImpuestos.IsDecimal = True
        Me.txtTotalImpuestos.IsNumber = True
        Me.txtTotalImpuestos.IsPK = False
        Me.txtTotalImpuestos.IsRequired = False
        Me.txtTotalImpuestos.Key = ""
        Me.txtTotalImpuestos.LabelAsoc = Nothing
        Me.txtTotalImpuestos.Location = New System.Drawing.Point(626, 341)
        Me.txtTotalImpuestos.Name = "txtTotalImpuestos"
        Me.txtTotalImpuestos.ReadOnly = True
        Me.txtTotalImpuestos.Size = New System.Drawing.Size(70, 20)
        Me.txtTotalImpuestos.TabIndex = 10
        Me.txtTotalImpuestos.Text = "0.00"
        Me.txtTotalImpuestos.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtDescRecGralPorc
        '
        Me.txtDescRecGralPorc.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtDescRecGralPorc.BindearPropiedadControl = Nothing
        Me.txtDescRecGralPorc.BindearPropiedadEntidad = Nothing
        Me.txtDescRecGralPorc.ForeColorFocus = System.Drawing.Color.Red
        Me.txtDescRecGralPorc.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtDescRecGralPorc.Formato = "##0.00"
        Me.txtDescRecGralPorc.IsDecimal = True
        Me.txtDescRecGralPorc.IsNumber = True
        Me.txtDescRecGralPorc.IsPK = False
        Me.txtDescRecGralPorc.IsRequired = False
        Me.txtDescRecGralPorc.Key = ""
        Me.txtDescRecGralPorc.LabelAsoc = Nothing
        Me.txtDescRecGralPorc.Location = New System.Drawing.Point(436, 341)
        Me.txtDescRecGralPorc.Name = "txtDescRecGralPorc"
        Me.txtDescRecGralPorc.ReadOnly = True
        Me.txtDescRecGralPorc.Size = New System.Drawing.Size(50, 20)
        Me.txtDescRecGralPorc.TabIndex = 7
        Me.txtDescRecGralPorc.Text = "0.00"
        Me.txtDescRecGralPorc.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtDescRecGral
        '
        Me.txtDescRecGral.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtDescRecGral.BindearPropiedadControl = Nothing
        Me.txtDescRecGral.BindearPropiedadEntidad = Nothing
        Me.txtDescRecGral.ForeColorFocus = System.Drawing.Color.Red
        Me.txtDescRecGral.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtDescRecGral.Formato = "##0.00"
        Me.txtDescRecGral.IsDecimal = True
        Me.txtDescRecGral.IsNumber = True
        Me.txtDescRecGral.IsPK = False
        Me.txtDescRecGral.IsRequired = False
        Me.txtDescRecGral.Key = ""
        Me.txtDescRecGral.LabelAsoc = Nothing
        Me.txtDescRecGral.Location = New System.Drawing.Point(486, 341)
        Me.txtDescRecGral.Name = "txtDescRecGral"
        Me.txtDescRecGral.ReadOnly = True
        Me.txtDescRecGral.Size = New System.Drawing.Size(70, 20)
        Me.txtDescRecGral.TabIndex = 8
        Me.txtDescRecGral.Text = "0.00"
        Me.txtDescRecGral.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtBruto
        '
        Me.txtBruto.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtBruto.BindearPropiedadControl = Nothing
        Me.txtBruto.BindearPropiedadEntidad = Nothing
        Me.txtBruto.ForeColorFocus = System.Drawing.Color.Red
        Me.txtBruto.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtBruto.Formato = "##0.00"
        Me.txtBruto.IsDecimal = True
        Me.txtBruto.IsNumber = True
        Me.txtBruto.IsPK = False
        Me.txtBruto.IsRequired = False
        Me.txtBruto.Key = ""
        Me.txtBruto.LabelAsoc = Nothing
        Me.txtBruto.Location = New System.Drawing.Point(366, 341)
        Me.txtBruto.Name = "txtBruto"
        Me.txtBruto.ReadOnly = True
        Me.txtBruto.Size = New System.Drawing.Size(70, 20)
        Me.txtBruto.TabIndex = 6
        Me.txtBruto.Text = "0.00"
        Me.txtBruto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtKilos
        '
        Me.txtKilos.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtKilos.BindearPropiedadControl = Nothing
        Me.txtKilos.BindearPropiedadEntidad = Nothing
        Me.txtKilos.ForeColorFocus = System.Drawing.Color.Red
        Me.txtKilos.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtKilos.Formato = ""
        Me.txtKilos.IsDecimal = False
        Me.txtKilos.IsNumber = False
        Me.txtKilos.IsPK = False
        Me.txtKilos.IsRequired = False
        Me.txtKilos.Key = ""
        Me.txtKilos.LabelAsoc = Nothing
        Me.txtKilos.Location = New System.Drawing.Point(776, 341)
        Me.txtKilos.Name = "txtKilos"
        Me.txtKilos.ReadOnly = True
        Me.txtKilos.Size = New System.Drawing.Size(80, 20)
        Me.txtKilos.TabIndex = 12
        Me.txtKilos.Text = "0.00"
        Me.txtKilos.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtNoGravado
        '
        Me.txtNoGravado.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtNoGravado.BindearPropiedadControl = Nothing
        Me.txtNoGravado.BindearPropiedadEntidad = Nothing
        Me.txtNoGravado.ForeColorFocus = System.Drawing.Color.Red
        Me.txtNoGravado.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtNoGravado.Formato = "##0.00"
        Me.txtNoGravado.IsDecimal = True
        Me.txtNoGravado.IsNumber = True
        Me.txtNoGravado.IsPK = False
        Me.txtNoGravado.IsRequired = False
        Me.txtNoGravado.Key = ""
        Me.txtNoGravado.LabelAsoc = Nothing
        Me.txtNoGravado.Location = New System.Drawing.Point(173, 341)
        Me.txtNoGravado.Name = "txtNoGravado"
        Me.txtNoGravado.ReadOnly = True
        Me.txtNoGravado.Size = New System.Drawing.Size(70, 20)
        Me.txtNoGravado.TabIndex = 4
        Me.txtNoGravado.Text = "0.00"
        Me.txtNoGravado.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtNoGravado.Visible = False
        '
        'ModificarComprobantes
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.ClientSize = New System.Drawing.Size(923, 593)
        Me.Controls.Add(Me.txtNoGravado)
        Me.Controls.Add(Me.txtKilos)
        Me.Controls.Add(Me.txtBruto)
        Me.Controls.Add(Me.txtDescRecGral)
        Me.Controls.Add(Me.txtDescRecGralPorc)
        Me.Controls.Add(Me.txtSubtotal)
        Me.Controls.Add(Me.txtTotal)
        Me.Controls.Add(Me.lblNuevosTotales)
        Me.Controls.Add(Me.txtTotalImpuestos)
        Me.Controls.Add(Me.btnGrabar)
        Me.Controls.Add(Me.btnEditar)
        Me.Controls.Add(Me.dgvProductos)
        Me.Controls.Add(Me.dgvFacturables)
        Me.Controls.Add(Me.stsStado)
        Me.Controls.Add(Me.grbDetalle)
        Me.Controls.Add(Me.tspFacturacion)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.Name = "ModificarComprobantes"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Modificar Comprobantes"
        Me.tspFacturacion.ResumeLayout(False)
        Me.tspFacturacion.PerformLayout()
        Me.grbDetalle.ResumeLayout(False)
        Me.grbDetalle.PerformLayout()
        Me.stsStado.ResumeLayout(False)
        Me.stsStado.PerformLayout()
        CType(Me.dgvProductos, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvFacturables, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
   Friend WithEvents tspFacturacion As System.Windows.Forms.ToolStrip
   Friend WithEvents tsbSalir As System.Windows.Forms.ToolStripButton
   Friend WithEvents imgIconos As System.Windows.Forms.ImageList
   Friend WithEvents grbDetalle As System.Windows.Forms.GroupBox
   Friend WithEvents btnBuscar As Eniac.Controles.Button
   Friend WithEvents dtpHasta As Eniac.Controles.DateTimePicker
   Friend WithEvents lblHasta As Eniac.Controles.Label
   Friend WithEvents dtpDesde As Eniac.Controles.DateTimePicker
   Friend WithEvents lblDesde As Eniac.Controles.Label
   Friend WithEvents lblTipoComprobante As Eniac.Controles.Label
   Friend WithEvents cmbTiposComprobantes As Eniac.Controles.ComboBox
   Public WithEvents tsbRefrescar As System.Windows.Forms.ToolStripButton
   Protected Friend WithEvents stsStado As System.Windows.Forms.StatusStrip
   Protected Friend WithEvents tssInfo As System.Windows.Forms.ToolStripStatusLabel
   Protected Friend WithEvents tspBarra As System.Windows.Forms.ToolStripProgressBar
   Protected WithEvents tssRegistros As System.Windows.Forms.ToolStripStatusLabel
   Friend WithEvents bscCodigoCliente As Eniac.Controles.Buscador
   Friend WithEvents bscCliente As Eniac.Controles.Buscador
   Friend WithEvents lblNombre As Eniac.Controles.Label
   Friend WithEvents lblCliente As Eniac.Controles.Label
   Friend WithEvents btnGrabar As Eniac.Controles.Button
   Friend WithEvents btnEditar As Eniac.Controles.Button
   Friend WithEvents dgvProductos As Eniac.Controles.DataGridView
   Friend WithEvents dgvFacturables As Eniac.Controles.DataGridView
   Friend WithEvents lblCodigoCliente As Eniac.Controles.Label
   Friend WithEvents txtSubtotal As Eniac.Controles.TextBox
   Friend WithEvents txtTotal As Eniac.Controles.TextBox
   Friend WithEvents lblNuevosTotales As Eniac.Controles.Label
   Friend WithEvents txtTotalImpuestos As Eniac.Controles.TextBox
   Friend WithEvents txtDescRecGralPorc As Eniac.Controles.TextBox
   Friend WithEvents txtDescRecGral As Eniac.Controles.TextBox
   Friend WithEvents txtBruto As Eniac.Controles.TextBox
   Friend WithEvents txtKilos As Eniac.Controles.TextBox
   Friend WithEvents txtNoGravado As Eniac.Controles.TextBox
   Friend WithEvents Fecha As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents IdTipoComprobante As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents Letra As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents CentroEmisor As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents NroComprobante As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents IdEstadoComprobante As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents ImporteBruto As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents DescuentoRecargoPorc As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents DescuentoRecargo As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents SubTotal As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents TotalImpuestos As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents ImporteTotal As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents Kilos As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents chkMesCompleto As Eniac.Controles.CheckBox
   Friend WithEvents pIdProducto As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents pProductoDesc As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents pCantidad As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents pPrecio As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents pDescuentoRecargoPorc1 As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents pDescuentoRecargoPorc2 As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents pDescuentoRecargo As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents pPrecioNeto As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents pAlicuotaImpuesto As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents pImporteTotal As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents pCantidadNueva As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents pKilos As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents pPrecioLista As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents pUtilidad As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents pPassword As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents pCentroEmisor As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents pCosto As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents pUsuario As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents pNumeroComprobante As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents pTipoDocumento As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents pNroDocumento As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents pIdSucursal As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents pTipoComprobante As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents pLetra As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents pIva As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents pDescRecGeneral As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents pDescuentoRecargoProducto As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents pDescRecGeneralProducto As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents pImporteTotalNeto As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents pEsNoGravado As System.Windows.Forms.DataGridViewCheckBoxColumn
   Friend WithEvents pStock As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents pOrden As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents Producto As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents pTipoImpuesto As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents pImporteImpuesto As System.Windows.Forms.DataGridViewTextBoxColumn

End Class
