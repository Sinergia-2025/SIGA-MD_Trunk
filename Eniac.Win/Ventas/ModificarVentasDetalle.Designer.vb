<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ModificarVentasDetalle
   Inherits BaseForm

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
      Me.tspFichas = New System.Windows.Forms.ToolStrip()
      Me.tsbGrabar = New System.Windows.Forms.ToolStripButton()
      Me.tsbSalir = New System.Windows.Forms.ToolStripButton()
      Me.grpCliente = New System.Windows.Forms.GroupBox()
      Me.txtIdTipoComprobante = New Eniac.Controles.TextBox()
      Me.txtLetra = New Eniac.Controles.TextBox()
      Me.lblComprobante = New Eniac.Controles.Label()
      Me.txtNumeroFactura = New Eniac.Controles.TextBox()
      Me.lblTipoComprobante = New Eniac.Controles.Label()
      Me.txtEmisorFactura = New Eniac.Controles.TextBox()
      Me.lblNumeroFactura = New Eniac.Controles.Label()
      Me.lblEmisorFactura = New Eniac.Controles.Label()
      Me.lblTipoFactura = New Eniac.Controles.Label()
      Me.txtCategoriaFiscal = New Eniac.Controles.TextBox()
      Me.lblCategoriaFiscal = New System.Windows.Forms.Label()
      Me.bscCliente = New Eniac.Controles.Buscador2()
      Me.lblNombreProv = New Eniac.Controles.Label()
      Me.lblCodigoProveedor = New Eniac.Controles.Label()
      Me.bscCodigoCliente = New Eniac.Controles.Buscador2()
      Me.lblCliente = New Eniac.Controles.Label()
      Me.tbcDatos = New System.Windows.Forms.TabControl()
      Me.tbpDatos = New System.Windows.Forms.TabPage()
      Me.cmbTipoDoc = New Eniac.Controles.ComboBox()
      Me.chbTipoDocumento = New Eniac.Controles.CheckBox()
      Me.txtNroDoc = New Eniac.Controles.TextBox()
      Me.txtCUIT = New Eniac.Controles.TextBox()
      Me.chbCUIT = New Eniac.Controles.CheckBox()
      Me.btnQuitarClienteVinculado = New Eniac.Controles.Button()
      Me.dtpFecha = New System.Windows.Forms.DateTimePicker()
      Me.chbFecha = New Eniac.Controles.CheckBox()
      Me.chbObservacion = New Eniac.Controles.CheckBox()
      Me.chbReferenciaCuentaCorriente = New Eniac.Controles.CheckBox()
      Me.chbComisionVendedor = New Eniac.Controles.CheckBox()
      Me.txtReferenciaCtaCte = New Eniac.Controles.TextBox()
      Me.chbCobrador = New Eniac.Controles.CheckBox()
      Me.chbVendedor = New Eniac.Controles.CheckBox()
      Me.txtComisiones = New Eniac.Controles.TextBox()
      Me.chbClienteCtaCte = New Eniac.Controles.CheckBox()
      Me.bscCodigoClienteCtaCte = New Eniac.Controles.Buscador2()
      Me.lblCodigoClienteCtaCte = New Eniac.Controles.Label()
      Me.cmbCategoria = New Eniac.Controles.ComboBox()
      Me.chbCategoria = New Eniac.Controles.CheckBox()
      Me.lblNombreCtaCte = New Eniac.Controles.Label()
      Me.bscClienteCtaCte = New Eniac.Controles.Buscador2()
      Me.chbFormaDePago = New Eniac.Controles.CheckBox()
      Me.cboFormaPago = New Eniac.Controles.ComboBox()
      Me.txtObservacion = New Eniac.Controles.TextBox()
      Me.cmbVendedor = New Eniac.Controles.ComboBox()
      Me.cmbCobrador = New Eniac.Controles.ComboBox()
      Me.tbpHistoriaClinica = New System.Windows.Forms.TabPage()
      Me.btnQuitarDoctor = New Eniac.Controles.Button()
      Me.btnQuitarPaciente = New Eniac.Controles.Button()
      Me.chbDoctor = New Eniac.Controles.CheckBox()
      Me.chbPaciente = New Eniac.Controles.CheckBox()
      Me.chbFechaCirugia = New Eniac.Controles.CheckBox()
      Me.bscCodigoDoctor = New Eniac.Controles.Buscador2()
      Me.bscCodigoPaciente = New Eniac.Controles.Buscador2()
      Me.dtpFechaCirugia = New Eniac.Controles.DateTimePicker()
      Me.bscPaciente = New Eniac.Controles.Buscador2()
      Me.Label4 = New Eniac.Controles.Label()
      Me.bscDoctor = New Eniac.Controles.Buscador2()
      Me.Label5 = New Eniac.Controles.Label()
      Me.Label3 = New Eniac.Controles.Label()
      Me.Label2 = New Eniac.Controles.Label()
      Me.DsInfPedidosFacturados1 = New Eniac.Entidades.DsInfPedidosFacturados()
      Me.tspFichas.SuspendLayout()
      Me.grpCliente.SuspendLayout()
      Me.tbcDatos.SuspendLayout()
      Me.tbpDatos.SuspendLayout()
      Me.tbpHistoriaClinica.SuspendLayout()
      CType(Me.DsInfPedidosFacturados1, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.SuspendLayout()
      '
      'tspFichas
      '
      Me.tspFichas.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsbGrabar, Me.tsbSalir})
      Me.tspFichas.Location = New System.Drawing.Point(0, 0)
      Me.tspFichas.Name = "tspFichas"
      Me.tspFichas.Size = New System.Drawing.Size(738, 25)
      Me.tspFichas.TabIndex = 4
      Me.tspFichas.Text = "ToolStrip1"
      '
      'tsbGrabar
      '
      Me.tsbGrabar.Image = Global.Eniac.Win.My.Resources.Resources.diskette_32
      Me.tsbGrabar.ImageTransparentColor = System.Drawing.Color.Magenta
      Me.tsbGrabar.Name = "tsbGrabar"
      Me.tsbGrabar.Size = New System.Drawing.Size(85, 22)
      Me.tsbGrabar.Text = "&Grabar (F4)"
      '
      'tsbSalir
      '
      Me.tsbSalir.Image = Global.Eniac.Win.My.Resources.Resources.close_b_24
      Me.tsbSalir.ImageTransparentColor = System.Drawing.Color.Magenta
      Me.tsbSalir.Name = "tsbSalir"
      Me.tsbSalir.Size = New System.Drawing.Size(73, 22)
      Me.tsbSalir.Text = "&Cancelar"
      '
      'grpCliente
      '
      Me.grpCliente.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.grpCliente.Controls.Add(Me.txtIdTipoComprobante)
      Me.grpCliente.Controls.Add(Me.txtLetra)
      Me.grpCliente.Controls.Add(Me.lblComprobante)
      Me.grpCliente.Controls.Add(Me.txtNumeroFactura)
      Me.grpCliente.Controls.Add(Me.lblTipoComprobante)
      Me.grpCliente.Controls.Add(Me.txtEmisorFactura)
      Me.grpCliente.Controls.Add(Me.lblNumeroFactura)
      Me.grpCliente.Controls.Add(Me.lblEmisorFactura)
      Me.grpCliente.Controls.Add(Me.lblTipoFactura)
      Me.grpCliente.Controls.Add(Me.txtCategoriaFiscal)
      Me.grpCliente.Controls.Add(Me.lblCategoriaFiscal)
      Me.grpCliente.Controls.Add(Me.bscCliente)
      Me.grpCliente.Controls.Add(Me.lblNombreProv)
      Me.grpCliente.Controls.Add(Me.lblCodigoProveedor)
      Me.grpCliente.Controls.Add(Me.bscCodigoCliente)
      Me.grpCliente.Controls.Add(Me.lblCliente)
      Me.grpCliente.Location = New System.Drawing.Point(12, 28)
      Me.grpCliente.Name = "grpCliente"
      Me.grpCliente.Size = New System.Drawing.Size(709, 110)
      Me.grpCliente.TabIndex = 1
      Me.grpCliente.TabStop = False
      '
      'txtIdTipoComprobante
      '
      Me.txtIdTipoComprobante.BindearPropiedadControl = Nothing
      Me.txtIdTipoComprobante.BindearPropiedadEntidad = Nothing
      Me.txtIdTipoComprobante.ForeColorFocus = System.Drawing.Color.Red
      Me.txtIdTipoComprobante.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtIdTipoComprobante.Formato = ""
      Me.txtIdTipoComprobante.IsDecimal = False
      Me.txtIdTipoComprobante.IsNumber = True
      Me.txtIdTipoComprobante.IsPK = False
      Me.txtIdTipoComprobante.IsRequired = True
      Me.txtIdTipoComprobante.Key = ""
      Me.txtIdTipoComprobante.LabelAsoc = Nothing
      Me.txtIdTipoComprobante.Location = New System.Drawing.Point(82, 73)
      Me.txtIdTipoComprobante.MaxLength = 8
      Me.txtIdTipoComprobante.Name = "txtIdTipoComprobante"
      Me.txtIdTipoComprobante.ReadOnly = True
      Me.txtIdTipoComprobante.Size = New System.Drawing.Size(131, 20)
      Me.txtIdTipoComprobante.TabIndex = 9
      '
      'txtLetra
      '
      Me.txtLetra.BindearPropiedadControl = Nothing
      Me.txtLetra.BindearPropiedadEntidad = Nothing
      Me.txtLetra.ForeColorFocus = System.Drawing.Color.Red
      Me.txtLetra.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtLetra.Formato = ""
      Me.txtLetra.IsDecimal = False
      Me.txtLetra.IsNumber = True
      Me.txtLetra.IsPK = False
      Me.txtLetra.IsRequired = True
      Me.txtLetra.Key = ""
      Me.txtLetra.LabelAsoc = Nothing
      Me.txtLetra.Location = New System.Drawing.Point(220, 73)
      Me.txtLetra.MaxLength = 4
      Me.txtLetra.Name = "txtLetra"
      Me.txtLetra.ReadOnly = True
      Me.txtLetra.Size = New System.Drawing.Size(28, 20)
      Me.txtLetra.TabIndex = 11
      Me.txtLetra.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
      '
      'lblComprobante
      '
      Me.lblComprobante.AutoSize = True
      Me.lblComprobante.LabelAsoc = Nothing
      Me.lblComprobante.Location = New System.Drawing.Point(6, 77)
      Me.lblComprobante.Name = "lblComprobante"
      Me.lblComprobante.Size = New System.Drawing.Size(70, 13)
      Me.lblComprobante.TabIndex = 7
      Me.lblComprobante.Text = "Comprobante"
      '
      'txtNumeroFactura
      '
      Me.txtNumeroFactura.BindearPropiedadControl = Nothing
      Me.txtNumeroFactura.BindearPropiedadEntidad = Nothing
      Me.txtNumeroFactura.ForeColorFocus = System.Drawing.Color.Red
      Me.txtNumeroFactura.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtNumeroFactura.Formato = ""
      Me.txtNumeroFactura.IsDecimal = False
      Me.txtNumeroFactura.IsNumber = True
      Me.txtNumeroFactura.IsPK = False
      Me.txtNumeroFactura.IsRequired = True
      Me.txtNumeroFactura.Key = ""
      Me.txtNumeroFactura.LabelAsoc = Nothing
      Me.txtNumeroFactura.Location = New System.Drawing.Point(301, 73)
      Me.txtNumeroFactura.MaxLength = 8
      Me.txtNumeroFactura.Name = "txtNumeroFactura"
      Me.txtNumeroFactura.ReadOnly = True
      Me.txtNumeroFactura.Size = New System.Drawing.Size(92, 20)
      Me.txtNumeroFactura.TabIndex = 15
      Me.txtNumeroFactura.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'lblTipoComprobante
      '
      Me.lblTipoComprobante.AutoSize = True
      Me.lblTipoComprobante.LabelAsoc = Nothing
      Me.lblTipoComprobante.Location = New System.Drawing.Point(80, 58)
      Me.lblTipoComprobante.Name = "lblTipoComprobante"
      Me.lblTipoComprobante.Size = New System.Drawing.Size(28, 13)
      Me.lblTipoComprobante.TabIndex = 8
      Me.lblTipoComprobante.Text = "Tipo"
      '
      'txtEmisorFactura
      '
      Me.txtEmisorFactura.BindearPropiedadControl = Nothing
      Me.txtEmisorFactura.BindearPropiedadEntidad = Nothing
      Me.txtEmisorFactura.ForeColorFocus = System.Drawing.Color.Red
      Me.txtEmisorFactura.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtEmisorFactura.Formato = ""
      Me.txtEmisorFactura.IsDecimal = False
      Me.txtEmisorFactura.IsNumber = True
      Me.txtEmisorFactura.IsPK = False
      Me.txtEmisorFactura.IsRequired = True
      Me.txtEmisorFactura.Key = ""
      Me.txtEmisorFactura.LabelAsoc = Nothing
      Me.txtEmisorFactura.Location = New System.Drawing.Point(254, 73)
      Me.txtEmisorFactura.MaxLength = 4
      Me.txtEmisorFactura.Name = "txtEmisorFactura"
      Me.txtEmisorFactura.ReadOnly = True
      Me.txtEmisorFactura.Size = New System.Drawing.Size(41, 20)
      Me.txtEmisorFactura.TabIndex = 13
      Me.txtEmisorFactura.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'lblNumeroFactura
      '
      Me.lblNumeroFactura.AutoSize = True
      Me.lblNumeroFactura.ForeColor = System.Drawing.Color.Black
      Me.lblNumeroFactura.LabelAsoc = Nothing
      Me.lblNumeroFactura.Location = New System.Drawing.Point(298, 58)
      Me.lblNumeroFactura.Name = "lblNumeroFactura"
      Me.lblNumeroFactura.Size = New System.Drawing.Size(44, 13)
      Me.lblNumeroFactura.TabIndex = 14
      Me.lblNumeroFactura.Text = "Numero"
      '
      'lblEmisorFactura
      '
      Me.lblEmisorFactura.AutoSize = True
      Me.lblEmisorFactura.ForeColor = System.Drawing.Color.Black
      Me.lblEmisorFactura.LabelAsoc = Nothing
      Me.lblEmisorFactura.Location = New System.Drawing.Point(251, 58)
      Me.lblEmisorFactura.Name = "lblEmisorFactura"
      Me.lblEmisorFactura.Size = New System.Drawing.Size(38, 13)
      Me.lblEmisorFactura.TabIndex = 12
      Me.lblEmisorFactura.Text = "Emisor"
      '
      'lblTipoFactura
      '
      Me.lblTipoFactura.AutoSize = True
      Me.lblTipoFactura.LabelAsoc = Nothing
      Me.lblTipoFactura.Location = New System.Drawing.Point(217, 58)
      Me.lblTipoFactura.Name = "lblTipoFactura"
      Me.lblTipoFactura.Size = New System.Drawing.Size(31, 13)
      Me.lblTipoFactura.TabIndex = 10
      Me.lblTipoFactura.Text = "Letra"
      '
      'txtCategoriaFiscal
      '
      Me.txtCategoriaFiscal.BindearPropiedadControl = Nothing
      Me.txtCategoriaFiscal.BindearPropiedadEntidad = Nothing
      Me.txtCategoriaFiscal.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.txtCategoriaFiscal.ForeColorFocus = System.Drawing.Color.Red
      Me.txtCategoriaFiscal.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtCategoriaFiscal.Formato = ""
      Me.txtCategoriaFiscal.IsDecimal = False
      Me.txtCategoriaFiscal.IsNumber = False
      Me.txtCategoriaFiscal.IsPK = False
      Me.txtCategoriaFiscal.IsRequired = False
      Me.txtCategoriaFiscal.Key = ""
      Me.txtCategoriaFiscal.LabelAsoc = Nothing
      Me.txtCategoriaFiscal.Location = New System.Drawing.Point(484, 34)
      Me.txtCategoriaFiscal.Name = "txtCategoriaFiscal"
      Me.txtCategoriaFiscal.ReadOnly = True
      Me.txtCategoriaFiscal.Size = New System.Drawing.Size(164, 20)
      Me.txtCategoriaFiscal.TabIndex = 6
      Me.txtCategoriaFiscal.TabStop = False
      '
      'lblCategoriaFiscal
      '
      Me.lblCategoriaFiscal.AutoSize = True
      Me.lblCategoriaFiscal.Location = New System.Drawing.Point(481, 17)
      Me.lblCategoriaFiscal.Name = "lblCategoriaFiscal"
      Me.lblCategoriaFiscal.Size = New System.Drawing.Size(82, 13)
      Me.lblCategoriaFiscal.TabIndex = 5
      Me.lblCategoriaFiscal.Text = "Categoria Fiscal"
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
      Me.bscCliente.LabelAsoc = Me.lblNombreProv
      Me.bscCliente.Location = New System.Drawing.Point(177, 32)
      Me.bscCliente.Margin = New System.Windows.Forms.Padding(4)
      Me.bscCliente.MaxLengh = "32767"
      Me.bscCliente.Name = "bscCliente"
      Me.bscCliente.Permitido = True
      Me.bscCliente.PermitidoNoBackColor = System.Drawing.Color.FromArgb(CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer))
      Me.bscCliente.PermitidoNoForeColor = System.Drawing.Color.Black
      Me.bscCliente.PermitidoSiBackColor = System.Drawing.Color.White
      Me.bscCliente.PermitidoSiForeColor = System.Drawing.Color.Black
      Me.bscCliente.Selecciono = False
      Me.bscCliente.Size = New System.Drawing.Size(300, 23)
      Me.bscCliente.TabIndex = 4
      '
      'lblNombreProv
      '
      Me.lblNombreProv.AutoSize = True
      Me.lblNombreProv.LabelAsoc = Nothing
      Me.lblNombreProv.Location = New System.Drawing.Point(174, 15)
      Me.lblNombreProv.Name = "lblNombreProv"
      Me.lblNombreProv.Size = New System.Drawing.Size(44, 13)
      Me.lblNombreProv.TabIndex = 3
      Me.lblNombreProv.Text = "Nombre"
      '
      'lblCodigoProveedor
      '
      Me.lblCodigoProveedor.AutoSize = True
      Me.lblCodigoProveedor.LabelAsoc = Nothing
      Me.lblCodigoProveedor.Location = New System.Drawing.Point(79, 15)
      Me.lblCodigoProveedor.Name = "lblCodigoProveedor"
      Me.lblCodigoProveedor.Size = New System.Drawing.Size(40, 13)
      Me.lblCodigoProveedor.TabIndex = 1
      Me.lblCodigoProveedor.Text = "Código"
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
      Me.bscCodigoCliente.LabelAsoc = Me.lblCodigoProveedor
      Me.bscCodigoCliente.Location = New System.Drawing.Point(82, 32)
      Me.bscCodigoCliente.MaxLengh = "32767"
      Me.bscCodigoCliente.Name = "bscCodigoCliente"
      Me.bscCodigoCliente.Permitido = True
      Me.bscCodigoCliente.PermitidoNoBackColor = System.Drawing.Color.FromArgb(CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer))
      Me.bscCodigoCliente.PermitidoNoForeColor = System.Drawing.Color.Black
      Me.bscCodigoCliente.PermitidoSiBackColor = System.Drawing.Color.White
      Me.bscCodigoCliente.PermitidoSiForeColor = System.Drawing.Color.Black
      Me.bscCodigoCliente.Selecciono = False
      Me.bscCodigoCliente.Size = New System.Drawing.Size(90, 23)
      Me.bscCodigoCliente.TabIndex = 2
      '
      'lblCliente
      '
      Me.lblCliente.AutoSize = True
      Me.lblCliente.LabelAsoc = Nothing
      Me.lblCliente.Location = New System.Drawing.Point(6, 37)
      Me.lblCliente.Name = "lblCliente"
      Me.lblCliente.Size = New System.Drawing.Size(39, 13)
      Me.lblCliente.TabIndex = 0
      Me.lblCliente.Text = "Cliente"
      '
      'tbcDatos
      '
      Me.tbcDatos.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.tbcDatos.Controls.Add(Me.tbpDatos)
      Me.tbcDatos.Controls.Add(Me.tbpHistoriaClinica)
      Me.tbcDatos.Location = New System.Drawing.Point(12, 144)
      Me.tbcDatos.Name = "tbcDatos"
      Me.tbcDatos.SelectedIndex = 0
      Me.tbcDatos.Size = New System.Drawing.Size(718, 264)
      Me.tbcDatos.TabIndex = 5
      '
      'tbpDatos
      '
      Me.tbpDatos.BackColor = System.Drawing.SystemColors.Control
      Me.tbpDatos.Controls.Add(Me.cmbTipoDoc)
      Me.tbpDatos.Controls.Add(Me.txtNroDoc)
      Me.tbpDatos.Controls.Add(Me.chbTipoDocumento)
      Me.tbpDatos.Controls.Add(Me.txtCUIT)
      Me.tbpDatos.Controls.Add(Me.chbCUIT)
      Me.tbpDatos.Controls.Add(Me.btnQuitarClienteVinculado)
      Me.tbpDatos.Controls.Add(Me.dtpFecha)
      Me.tbpDatos.Controls.Add(Me.chbFecha)
      Me.tbpDatos.Controls.Add(Me.chbObservacion)
      Me.tbpDatos.Controls.Add(Me.chbReferenciaCuentaCorriente)
      Me.tbpDatos.Controls.Add(Me.chbComisionVendedor)
      Me.tbpDatos.Controls.Add(Me.txtReferenciaCtaCte)
      Me.tbpDatos.Controls.Add(Me.chbCobrador)
      Me.tbpDatos.Controls.Add(Me.chbVendedor)
      Me.tbpDatos.Controls.Add(Me.txtComisiones)
      Me.tbpDatos.Controls.Add(Me.chbClienteCtaCte)
      Me.tbpDatos.Controls.Add(Me.bscCodigoClienteCtaCte)
      Me.tbpDatos.Controls.Add(Me.cmbCategoria)
      Me.tbpDatos.Controls.Add(Me.chbCategoria)
      Me.tbpDatos.Controls.Add(Me.lblNombreCtaCte)
      Me.tbpDatos.Controls.Add(Me.bscClienteCtaCte)
      Me.tbpDatos.Controls.Add(Me.lblCodigoClienteCtaCte)
      Me.tbpDatos.Controls.Add(Me.chbFormaDePago)
      Me.tbpDatos.Controls.Add(Me.cboFormaPago)
      Me.tbpDatos.Controls.Add(Me.txtObservacion)
      Me.tbpDatos.Controls.Add(Me.cmbVendedor)
      Me.tbpDatos.Controls.Add(Me.cmbCobrador)
      Me.tbpDatos.Location = New System.Drawing.Point(4, 22)
      Me.tbpDatos.Name = "tbpDatos"
      Me.tbpDatos.Padding = New System.Windows.Forms.Padding(3)
      Me.tbpDatos.Size = New System.Drawing.Size(710, 238)
      Me.tbpDatos.TabIndex = 0
      Me.tbpDatos.Text = "Datos"
      '
      'cmbTipoDoc
      '
      Me.cmbTipoDoc.BindearPropiedadControl = "SelectedValue"
      Me.cmbTipoDoc.BindearPropiedadEntidad = "TipoDocCliente"
      Me.cmbTipoDoc.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cmbTipoDoc.Enabled = False
      Me.cmbTipoDoc.ForeColorFocus = System.Drawing.Color.Red
      Me.cmbTipoDoc.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.cmbTipoDoc.FormattingEnabled = True
      Me.cmbTipoDoc.IsPK = False
      Me.cmbTipoDoc.IsRequired = False
      Me.cmbTipoDoc.Key = Nothing
      Me.cmbTipoDoc.LabelAsoc = Me.chbTipoDocumento
      Me.cmbTipoDoc.Location = New System.Drawing.Point(435, 33)
      Me.cmbTipoDoc.Name = "cmbTipoDoc"
      Me.cmbTipoDoc.Size = New System.Drawing.Size(59, 21)
      Me.cmbTipoDoc.TabIndex = 56
      '
      'chbTipoDocumento
      '
      Me.chbTipoDocumento.AutoSize = True
      Me.chbTipoDocumento.BindearPropiedadControl = Nothing
      Me.chbTipoDocumento.BindearPropiedadEntidad = Nothing
      Me.chbTipoDocumento.ForeColor = System.Drawing.Color.Red
      Me.chbTipoDocumento.ForeColorFocus = System.Drawing.Color.Red
      Me.chbTipoDocumento.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
      Me.chbTipoDocumento.ImeMode = System.Windows.Forms.ImeMode.NoControl
      Me.chbTipoDocumento.IsPK = False
      Me.chbTipoDocumento.IsRequired = False
      Me.chbTipoDocumento.Key = Nothing
      Me.chbTipoDocumento.LabelAsoc = Nothing
      Me.chbTipoDocumento.Location = New System.Drawing.Point(312, 35)
      Me.chbTipoDocumento.Name = "chbTipoDocumento"
      Me.chbTipoDocumento.Size = New System.Drawing.Size(104, 17)
      Me.chbTipoDocumento.TabIndex = 55
      Me.chbTipoDocumento.Text = "Tipo y Nro. Doc."
      '
      'txtNroDoc
      '
      Me.txtNroDoc.BindearPropiedadControl = "Text"
      Me.txtNroDoc.BindearPropiedadEntidad = "NroDocCliente"
      Me.txtNroDoc.Enabled = False
      Me.txtNroDoc.ForeColorFocus = System.Drawing.Color.Red
      Me.txtNroDoc.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtNroDoc.Formato = ""
      Me.txtNroDoc.IsDecimal = False
      Me.txtNroDoc.IsNumber = True
      Me.txtNroDoc.IsPK = False
      Me.txtNroDoc.IsRequired = False
      Me.txtNroDoc.Key = ""
      Me.txtNroDoc.LabelAsoc = Me.chbTipoDocumento
      Me.txtNroDoc.Location = New System.Drawing.Point(496, 33)
      Me.txtNroDoc.MaxLength = 12
      Me.txtNroDoc.Name = "txtNroDoc"
      Me.txtNroDoc.Size = New System.Drawing.Size(95, 20)
      Me.txtNroDoc.TabIndex = 57
      Me.txtNroDoc.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'txtCUIT
      '
      Me.txtCUIT.BindearPropiedadControl = "Text"
      Me.txtCUIT.BindearPropiedadEntidad = "Cuit"
      Me.txtCUIT.Enabled = False
      Me.txtCUIT.ForeColorFocus = System.Drawing.Color.Red
      Me.txtCUIT.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtCUIT.Formato = ""
      Me.txtCUIT.IsDecimal = False
      Me.txtCUIT.IsNumber = False
      Me.txtCUIT.IsPK = False
      Me.txtCUIT.IsRequired = False
      Me.txtCUIT.Key = ""
      Me.txtCUIT.LabelAsoc = Me.chbCUIT
      Me.txtCUIT.Location = New System.Drawing.Point(435, 7)
      Me.txtCUIT.MaxLength = 11
      Me.txtCUIT.Name = "txtCUIT"
      Me.txtCUIT.Size = New System.Drawing.Size(95, 20)
      Me.txtCUIT.TabIndex = 54
      '
      'chbCUIT
      '
      Me.chbCUIT.AutoSize = True
      Me.chbCUIT.BindearPropiedadControl = Nothing
      Me.chbCUIT.BindearPropiedadEntidad = Nothing
      Me.chbCUIT.ForeColor = System.Drawing.Color.Red
      Me.chbCUIT.ForeColorFocus = System.Drawing.Color.Red
      Me.chbCUIT.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
      Me.chbCUIT.ImeMode = System.Windows.Forms.ImeMode.NoControl
      Me.chbCUIT.IsPK = False
      Me.chbCUIT.IsRequired = False
      Me.chbCUIT.Key = Nothing
      Me.chbCUIT.LabelAsoc = Nothing
      Me.chbCUIT.Location = New System.Drawing.Point(312, 9)
      Me.chbCUIT.Name = "chbCUIT"
      Me.chbCUIT.Size = New System.Drawing.Size(51, 17)
      Me.chbCUIT.TabIndex = 53
      Me.chbCUIT.Text = "CUIT"
      '
      'btnQuitarClienteVinculado
      '
      Me.btnQuitarClienteVinculado.Image = Global.Eniac.Win.My.Resources.Resources.refresh_24
      Me.btnQuitarClienteVinculado.ImeMode = System.Windows.Forms.ImeMode.NoControl
      Me.btnQuitarClienteVinculado.Location = New System.Drawing.Point(123, 175)
      Me.btnQuitarClienteVinculado.Name = "btnQuitarClienteVinculado"
      Me.btnQuitarClienteVinculado.Size = New System.Drawing.Size(29, 28)
      Me.btnQuitarClienteVinculado.TabIndex = 19
      Me.btnQuitarClienteVinculado.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
      Me.btnQuitarClienteVinculado.UseVisualStyleBackColor = True
      '
      'dtpFecha
      '
      Me.dtpFecha.Enabled = False
      Me.dtpFecha.Format = System.Windows.Forms.DateTimePickerFormat.Custom
      Me.dtpFecha.Location = New System.Drawing.Point(123, 7)
      Me.dtpFecha.Name = "dtpFecha"
      Me.dtpFecha.Size = New System.Drawing.Size(100, 20)
      Me.dtpFecha.TabIndex = 1
      '
      'chbFecha
      '
      Me.chbFecha.AutoSize = True
      Me.chbFecha.BindearPropiedadControl = Nothing
      Me.chbFecha.BindearPropiedadEntidad = Nothing
      Me.chbFecha.ForeColor = System.Drawing.Color.Red
      Me.chbFecha.ForeColorFocus = System.Drawing.Color.Red
      Me.chbFecha.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
      Me.chbFecha.IsPK = False
      Me.chbFecha.IsRequired = False
      Me.chbFecha.Key = Nothing
      Me.chbFecha.LabelAsoc = Nothing
      Me.chbFecha.Location = New System.Drawing.Point(6, 9)
      Me.chbFecha.Name = "chbFecha"
      Me.chbFecha.Size = New System.Drawing.Size(56, 17)
      Me.chbFecha.TabIndex = 0
      Me.chbFecha.Text = "Fecha"
      Me.chbFecha.UseVisualStyleBackColor = True
      '
      'chbObservacion
      '
      Me.chbObservacion.AutoSize = True
      Me.chbObservacion.BindearPropiedadControl = Nothing
      Me.chbObservacion.BindearPropiedadEntidad = Nothing
      Me.chbObservacion.ForeColor = System.Drawing.Color.Red
      Me.chbObservacion.ForeColorFocus = System.Drawing.Color.Red
      Me.chbObservacion.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
      Me.chbObservacion.IsPK = False
      Me.chbObservacion.IsRequired = False
      Me.chbObservacion.Key = Nothing
      Me.chbObservacion.LabelAsoc = Nothing
      Me.chbObservacion.Location = New System.Drawing.Point(6, 211)
      Me.chbObservacion.Name = "chbObservacion"
      Me.chbObservacion.Size = New System.Drawing.Size(86, 17)
      Me.chbObservacion.TabIndex = 20
      Me.chbObservacion.Text = "Observación"
      Me.chbObservacion.UseVisualStyleBackColor = True
      '
      'chbReferenciaCuentaCorriente
      '
      Me.chbReferenciaCuentaCorriente.AutoSize = True
      Me.chbReferenciaCuentaCorriente.BindearPropiedadControl = Nothing
      Me.chbReferenciaCuentaCorriente.BindearPropiedadEntidad = Nothing
      Me.chbReferenciaCuentaCorriente.ForeColor = System.Drawing.Color.Red
      Me.chbReferenciaCuentaCorriente.ForeColorFocus = System.Drawing.Color.Red
      Me.chbReferenciaCuentaCorriente.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
      Me.chbReferenciaCuentaCorriente.IsPK = False
      Me.chbReferenciaCuentaCorriente.IsRequired = False
      Me.chbReferenciaCuentaCorriente.Key = Nothing
      Me.chbReferenciaCuentaCorriente.LabelAsoc = Nothing
      Me.chbReferenciaCuentaCorriente.Location = New System.Drawing.Point(6, 143)
      Me.chbReferenciaCuentaCorriente.Name = "chbReferenciaCuentaCorriente"
      Me.chbReferenciaCuentaCorriente.Size = New System.Drawing.Size(175, 17)
      Me.chbReferenciaCuentaCorriente.TabIndex = 12
      Me.chbReferenciaCuentaCorriente.Text = "Referencia de Cuenta Corriente"
      Me.chbReferenciaCuentaCorriente.UseVisualStyleBackColor = True
      '
      'chbComisionVendedor
      '
      Me.chbComisionVendedor.AutoSize = True
      Me.chbComisionVendedor.BindearPropiedadControl = Nothing
      Me.chbComisionVendedor.BindearPropiedadEntidad = Nothing
      Me.chbComisionVendedor.ForeColor = System.Drawing.Color.Red
      Me.chbComisionVendedor.ForeColorFocus = System.Drawing.Color.Red
      Me.chbComisionVendedor.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
      Me.chbComisionVendedor.IsPK = False
      Me.chbComisionVendedor.IsRequired = False
      Me.chbComisionVendedor.Key = Nothing
      Me.chbComisionVendedor.LabelAsoc = Nothing
      Me.chbComisionVendedor.Location = New System.Drawing.Point(312, 89)
      Me.chbComisionVendedor.Name = "chbComisionVendedor"
      Me.chbComisionVendedor.Size = New System.Drawing.Size(117, 17)
      Me.chbComisionVendedor.TabIndex = 8
      Me.chbComisionVendedor.Text = "Comisión Vendedor"
      Me.chbComisionVendedor.UseVisualStyleBackColor = True
      '
      'txtReferenciaCtaCte
      '
      Me.txtReferenciaCtaCte.BindearPropiedadControl = Nothing
      Me.txtReferenciaCtaCte.BindearPropiedadEntidad = Nothing
      Me.txtReferenciaCtaCte.Enabled = False
      Me.txtReferenciaCtaCte.ForeColorFocus = System.Drawing.Color.Red
      Me.txtReferenciaCtaCte.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtReferenciaCtaCte.Formato = ""
      Me.txtReferenciaCtaCte.IsDecimal = False
      Me.txtReferenciaCtaCte.IsNumber = False
      Me.txtReferenciaCtaCte.IsPK = False
      Me.txtReferenciaCtaCte.IsRequired = False
      Me.txtReferenciaCtaCte.Key = ""
      Me.txtReferenciaCtaCte.LabelAsoc = Nothing
      Me.txtReferenciaCtaCte.Location = New System.Drawing.Point(187, 141)
      Me.txtReferenciaCtaCte.MaxLength = 15
      Me.txtReferenciaCtaCte.Name = "txtReferenciaCtaCte"
      Me.txtReferenciaCtaCte.Size = New System.Drawing.Size(135, 20)
      Me.txtReferenciaCtaCte.TabIndex = 13
      '
      'chbCobrador
      '
      Me.chbCobrador.AutoSize = True
      Me.chbCobrador.BindearPropiedadControl = Nothing
      Me.chbCobrador.BindearPropiedadEntidad = Nothing
      Me.chbCobrador.ForeColor = System.Drawing.Color.Red
      Me.chbCobrador.ForeColorFocus = System.Drawing.Color.Red
      Me.chbCobrador.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
      Me.chbCobrador.IsPK = False
      Me.chbCobrador.IsRequired = False
      Me.chbCobrador.Key = Nothing
      Me.chbCobrador.LabelAsoc = Nothing
      Me.chbCobrador.Location = New System.Drawing.Point(6, 116)
      Me.chbCobrador.Name = "chbCobrador"
      Me.chbCobrador.Size = New System.Drawing.Size(69, 17)
      Me.chbCobrador.TabIndex = 10
      Me.chbCobrador.Text = "Cobrador"
      Me.chbCobrador.UseVisualStyleBackColor = True
      '
      'chbVendedor
      '
      Me.chbVendedor.AutoSize = True
      Me.chbVendedor.BindearPropiedadControl = Nothing
      Me.chbVendedor.BindearPropiedadEntidad = Nothing
      Me.chbVendedor.ForeColor = System.Drawing.Color.Red
      Me.chbVendedor.ForeColorFocus = System.Drawing.Color.Red
      Me.chbVendedor.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
      Me.chbVendedor.IsPK = False
      Me.chbVendedor.IsRequired = False
      Me.chbVendedor.Key = Nothing
      Me.chbVendedor.LabelAsoc = Nothing
      Me.chbVendedor.Location = New System.Drawing.Point(6, 89)
      Me.chbVendedor.Name = "chbVendedor"
      Me.chbVendedor.Size = New System.Drawing.Size(72, 17)
      Me.chbVendedor.TabIndex = 6
      Me.chbVendedor.Text = "Vendedor"
      Me.chbVendedor.UseVisualStyleBackColor = True
      '
      'txtComisiones
      '
      Me.txtComisiones.BindearPropiedadControl = Nothing
      Me.txtComisiones.BindearPropiedadEntidad = Nothing
      Me.txtComisiones.Enabled = False
      Me.txtComisiones.ForeColorFocus = System.Drawing.Color.Red
      Me.txtComisiones.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtComisiones.Formato = "##0.00"
      Me.txtComisiones.IsDecimal = True
      Me.txtComisiones.IsNumber = True
      Me.txtComisiones.IsPK = False
      Me.txtComisiones.IsRequired = False
      Me.txtComisiones.Key = ""
      Me.txtComisiones.LabelAsoc = Nothing
      Me.txtComisiones.Location = New System.Drawing.Point(435, 87)
      Me.txtComisiones.Name = "txtComisiones"
      Me.txtComisiones.Size = New System.Drawing.Size(70, 20)
      Me.txtComisiones.TabIndex = 9
      Me.txtComisiones.Text = "0.00"
      Me.txtComisiones.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'chbClienteCtaCte
      '
      Me.chbClienteCtaCte.AutoSize = True
      Me.chbClienteCtaCte.BindearPropiedadControl = Nothing
      Me.chbClienteCtaCte.BindearPropiedadEntidad = Nothing
      Me.chbClienteCtaCte.ForeColor = System.Drawing.Color.Red
      Me.chbClienteCtaCte.ForeColorFocus = System.Drawing.Color.Red
      Me.chbClienteCtaCte.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
      Me.chbClienteCtaCte.IsPK = False
      Me.chbClienteCtaCte.IsRequired = False
      Me.chbClienteCtaCte.Key = Nothing
      Me.chbClienteCtaCte.LabelAsoc = Nothing
      Me.chbClienteCtaCte.Location = New System.Drawing.Point(6, 181)
      Me.chbClienteCtaCte.Name = "chbClienteCtaCte"
      Me.chbClienteCtaCte.Size = New System.Drawing.Size(111, 17)
      Me.chbClienteCtaCte.TabIndex = 14
      Me.chbClienteCtaCte.Text = "Cliente Vinculado."
      Me.chbClienteCtaCte.UseVisualStyleBackColor = True
      '
      'bscCodigoClienteCtaCte
      '
      Me.bscCodigoClienteCtaCte.ActivarFiltroEnGrilla = True
      Me.bscCodigoClienteCtaCte.BindearPropiedadControl = Nothing
      Me.bscCodigoClienteCtaCte.BindearPropiedadEntidad = Nothing
      Me.bscCodigoClienteCtaCte.ConfigBuscador = Nothing
      Me.bscCodigoClienteCtaCte.Datos = Nothing
      Me.bscCodigoClienteCtaCte.FilaDevuelta = Nothing
      Me.bscCodigoClienteCtaCte.ForeColorFocus = System.Drawing.Color.Red
      Me.bscCodigoClienteCtaCte.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
      Me.bscCodigoClienteCtaCte.IsDecimal = False
      Me.bscCodigoClienteCtaCte.IsNumber = False
      Me.bscCodigoClienteCtaCte.IsPK = False
      Me.bscCodigoClienteCtaCte.IsRequired = False
      Me.bscCodigoClienteCtaCte.Key = ""
      Me.bscCodigoClienteCtaCte.LabelAsoc = Me.lblCodigoClienteCtaCte
      Me.bscCodigoClienteCtaCte.Location = New System.Drawing.Point(158, 178)
      Me.bscCodigoClienteCtaCte.MaxLengh = "32767"
      Me.bscCodigoClienteCtaCte.Name = "bscCodigoClienteCtaCte"
      Me.bscCodigoClienteCtaCte.Permitido = True
      Me.bscCodigoClienteCtaCte.PermitidoNoBackColor = System.Drawing.Color.FromArgb(CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer))
      Me.bscCodigoClienteCtaCte.PermitidoNoForeColor = System.Drawing.Color.Black
      Me.bscCodigoClienteCtaCte.PermitidoSiBackColor = System.Drawing.Color.White
      Me.bscCodigoClienteCtaCte.PermitidoSiForeColor = System.Drawing.Color.Black
      Me.bscCodigoClienteCtaCte.Selecciono = False
      Me.bscCodigoClienteCtaCte.Size = New System.Drawing.Size(90, 23)
      Me.bscCodigoClienteCtaCte.TabIndex = 16
      '
      'lblCodigoClienteCtaCte
      '
      Me.lblCodigoClienteCtaCte.AutoSize = True
      Me.lblCodigoClienteCtaCte.ForeColor = System.Drawing.Color.Black
      Me.lblCodigoClienteCtaCte.LabelAsoc = Nothing
      Me.lblCodigoClienteCtaCte.Location = New System.Drawing.Point(155, 162)
      Me.lblCodigoClienteCtaCte.Name = "lblCodigoClienteCtaCte"
      Me.lblCodigoClienteCtaCte.Size = New System.Drawing.Size(40, 13)
      Me.lblCodigoClienteCtaCte.TabIndex = 15
      Me.lblCodigoClienteCtaCte.Text = "Código"
      '
      'cmbCategoria
      '
      Me.cmbCategoria.BindearPropiedadControl = Nothing
      Me.cmbCategoria.BindearPropiedadEntidad = Nothing
      Me.cmbCategoria.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cmbCategoria.Enabled = False
      Me.cmbCategoria.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.cmbCategoria.ForeColorFocus = System.Drawing.Color.Red
      Me.cmbCategoria.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.cmbCategoria.FormattingEnabled = True
      Me.cmbCategoria.IsPK = False
      Me.cmbCategoria.IsRequired = False
      Me.cmbCategoria.Key = Nothing
      Me.cmbCategoria.LabelAsoc = Nothing
      Me.cmbCategoria.Location = New System.Drawing.Point(123, 60)
      Me.cmbCategoria.Name = "cmbCategoria"
      Me.cmbCategoria.Size = New System.Drawing.Size(150, 21)
      Me.cmbCategoria.TabIndex = 5
      '
      'chbCategoria
      '
      Me.chbCategoria.AutoSize = True
      Me.chbCategoria.BindearPropiedadControl = Nothing
      Me.chbCategoria.BindearPropiedadEntidad = Nothing
      Me.chbCategoria.ForeColor = System.Drawing.Color.Red
      Me.chbCategoria.ForeColorFocus = System.Drawing.Color.Red
      Me.chbCategoria.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
      Me.chbCategoria.IsPK = False
      Me.chbCategoria.IsRequired = False
      Me.chbCategoria.Key = Nothing
      Me.chbCategoria.LabelAsoc = Nothing
      Me.chbCategoria.Location = New System.Drawing.Point(6, 62)
      Me.chbCategoria.Name = "chbCategoria"
      Me.chbCategoria.Size = New System.Drawing.Size(73, 17)
      Me.chbCategoria.TabIndex = 4
      Me.chbCategoria.Text = "Categoría"
      Me.chbCategoria.UseVisualStyleBackColor = True
      '
      'lblNombreCtaCte
      '
      Me.lblNombreCtaCte.AutoSize = True
      Me.lblNombreCtaCte.ForeColor = System.Drawing.Color.Black
      Me.lblNombreCtaCte.LabelAsoc = Nothing
      Me.lblNombreCtaCte.Location = New System.Drawing.Point(252, 162)
      Me.lblNombreCtaCte.Name = "lblNombreCtaCte"
      Me.lblNombreCtaCte.Size = New System.Drawing.Size(44, 13)
      Me.lblNombreCtaCte.TabIndex = 17
      Me.lblNombreCtaCte.Text = "Nombre"
      '
      'bscClienteCtaCte
      '
      Me.bscClienteCtaCte.ActivarFiltroEnGrilla = True
      Me.bscClienteCtaCte.AutoSize = True
      Me.bscClienteCtaCte.BindearPropiedadControl = Nothing
      Me.bscClienteCtaCte.BindearPropiedadEntidad = Nothing
      Me.bscClienteCtaCte.ConfigBuscador = Nothing
      Me.bscClienteCtaCte.Datos = Nothing
      Me.bscClienteCtaCte.FilaDevuelta = Nothing
      Me.bscClienteCtaCte.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.bscClienteCtaCte.ForeColorFocus = System.Drawing.Color.Red
      Me.bscClienteCtaCte.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
      Me.bscClienteCtaCte.IsDecimal = False
      Me.bscClienteCtaCte.IsNumber = False
      Me.bscClienteCtaCte.IsPK = False
      Me.bscClienteCtaCte.IsRequired = False
      Me.bscClienteCtaCte.Key = ""
      Me.bscClienteCtaCte.LabelAsoc = Me.lblNombreCtaCte
      Me.bscClienteCtaCte.Location = New System.Drawing.Point(255, 177)
      Me.bscClienteCtaCte.Margin = New System.Windows.Forms.Padding(4)
      Me.bscClienteCtaCte.MaxLengh = "32767"
      Me.bscClienteCtaCte.Name = "bscClienteCtaCte"
      Me.bscClienteCtaCte.Permitido = True
      Me.bscClienteCtaCte.PermitidoNoBackColor = System.Drawing.Color.FromArgb(CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer))
      Me.bscClienteCtaCte.PermitidoNoForeColor = System.Drawing.Color.Black
      Me.bscClienteCtaCte.PermitidoSiBackColor = System.Drawing.Color.White
      Me.bscClienteCtaCte.PermitidoSiForeColor = System.Drawing.Color.Black
      Me.bscClienteCtaCte.Selecciono = False
      Me.bscClienteCtaCte.Size = New System.Drawing.Size(183, 25)
      Me.bscClienteCtaCte.TabIndex = 18
      '
      'chbFormaDePago
      '
      Me.chbFormaDePago.AutoSize = True
      Me.chbFormaDePago.BindearPropiedadControl = Nothing
      Me.chbFormaDePago.BindearPropiedadEntidad = Nothing
      Me.chbFormaDePago.ForeColor = System.Drawing.Color.Red
      Me.chbFormaDePago.ForeColorFocus = System.Drawing.Color.Red
      Me.chbFormaDePago.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
      Me.chbFormaDePago.IsPK = False
      Me.chbFormaDePago.IsRequired = False
      Me.chbFormaDePago.Key = Nothing
      Me.chbFormaDePago.LabelAsoc = Nothing
      Me.chbFormaDePago.Location = New System.Drawing.Point(6, 35)
      Me.chbFormaDePago.Name = "chbFormaDePago"
      Me.chbFormaDePago.Size = New System.Drawing.Size(98, 17)
      Me.chbFormaDePago.TabIndex = 2
      Me.chbFormaDePago.Text = "Forma de Pago"
      Me.chbFormaDePago.UseVisualStyleBackColor = True
      '
      'cboFormaPago
      '
      Me.cboFormaPago.BindearPropiedadControl = Nothing
      Me.cboFormaPago.BindearPropiedadEntidad = Nothing
      Me.cboFormaPago.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cboFormaPago.Enabled = False
      Me.cboFormaPago.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.cboFormaPago.ForeColorFocus = System.Drawing.Color.Red
      Me.cboFormaPago.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.cboFormaPago.FormattingEnabled = True
      Me.cboFormaPago.IsPK = False
      Me.cboFormaPago.IsRequired = False
      Me.cboFormaPago.Key = Nothing
      Me.cboFormaPago.LabelAsoc = Nothing
      Me.cboFormaPago.Location = New System.Drawing.Point(123, 33)
      Me.cboFormaPago.Name = "cboFormaPago"
      Me.cboFormaPago.Size = New System.Drawing.Size(125, 21)
      Me.cboFormaPago.TabIndex = 3
      '
      'txtObservacion
      '
      Me.txtObservacion.BackColor = System.Drawing.Color.White
      Me.txtObservacion.BindearPropiedadControl = Nothing
      Me.txtObservacion.BindearPropiedadEntidad = Nothing
      Me.txtObservacion.Enabled = False
      Me.txtObservacion.ForeColorFocus = System.Drawing.Color.Red
      Me.txtObservacion.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtObservacion.Formato = ""
      Me.txtObservacion.IsDecimal = False
      Me.txtObservacion.IsNumber = False
      Me.txtObservacion.IsPK = False
      Me.txtObservacion.IsRequired = False
      Me.txtObservacion.Key = ""
      Me.txtObservacion.LabelAsoc = Nothing
      Me.txtObservacion.Location = New System.Drawing.Point(123, 209)
      Me.txtObservacion.MaxLength = 100
      Me.txtObservacion.Name = "txtObservacion"
      Me.txtObservacion.Size = New System.Drawing.Size(556, 20)
      Me.txtObservacion.TabIndex = 21
      '
      'cmbVendedor
      '
      Me.cmbVendedor.BindearPropiedadControl = Nothing
      Me.cmbVendedor.BindearPropiedadEntidad = Nothing
      Me.cmbVendedor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cmbVendedor.Enabled = False
      Me.cmbVendedor.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.cmbVendedor.ForeColorFocus = System.Drawing.Color.Red
      Me.cmbVendedor.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.cmbVendedor.FormattingEnabled = True
      Me.cmbVendedor.IsPK = False
      Me.cmbVendedor.IsRequired = False
      Me.cmbVendedor.Key = Nothing
      Me.cmbVendedor.LabelAsoc = Nothing
      Me.cmbVendedor.Location = New System.Drawing.Point(123, 87)
      Me.cmbVendedor.Name = "cmbVendedor"
      Me.cmbVendedor.Size = New System.Drawing.Size(171, 21)
      Me.cmbVendedor.TabIndex = 7
      '
      'cmbCobrador
      '
      Me.cmbCobrador.BindearPropiedadControl = Nothing
      Me.cmbCobrador.BindearPropiedadEntidad = Nothing
      Me.cmbCobrador.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cmbCobrador.Enabled = False
      Me.cmbCobrador.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.cmbCobrador.ForeColorFocus = System.Drawing.Color.Red
      Me.cmbCobrador.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.cmbCobrador.FormattingEnabled = True
      Me.cmbCobrador.IsPK = False
      Me.cmbCobrador.IsRequired = False
      Me.cmbCobrador.Key = Nothing
      Me.cmbCobrador.LabelAsoc = Nothing
      Me.cmbCobrador.Location = New System.Drawing.Point(123, 114)
      Me.cmbCobrador.Name = "cmbCobrador"
      Me.cmbCobrador.Size = New System.Drawing.Size(130, 21)
      Me.cmbCobrador.TabIndex = 11
      '
      'tbpHistoriaClinica
      '
      Me.tbpHistoriaClinica.BackColor = System.Drawing.SystemColors.Control
      Me.tbpHistoriaClinica.Controls.Add(Me.btnQuitarDoctor)
      Me.tbpHistoriaClinica.Controls.Add(Me.btnQuitarPaciente)
      Me.tbpHistoriaClinica.Controls.Add(Me.chbDoctor)
      Me.tbpHistoriaClinica.Controls.Add(Me.chbPaciente)
      Me.tbpHistoriaClinica.Controls.Add(Me.chbFechaCirugia)
      Me.tbpHistoriaClinica.Controls.Add(Me.bscCodigoDoctor)
      Me.tbpHistoriaClinica.Controls.Add(Me.bscCodigoPaciente)
      Me.tbpHistoriaClinica.Controls.Add(Me.dtpFechaCirugia)
      Me.tbpHistoriaClinica.Controls.Add(Me.bscPaciente)
      Me.tbpHistoriaClinica.Controls.Add(Me.Label4)
      Me.tbpHistoriaClinica.Controls.Add(Me.bscDoctor)
      Me.tbpHistoriaClinica.Controls.Add(Me.Label5)
      Me.tbpHistoriaClinica.Controls.Add(Me.Label3)
      Me.tbpHistoriaClinica.Controls.Add(Me.Label2)
      Me.tbpHistoriaClinica.Location = New System.Drawing.Point(4, 22)
      Me.tbpHistoriaClinica.Name = "tbpHistoriaClinica"
      Me.tbpHistoriaClinica.Padding = New System.Windows.Forms.Padding(3)
      Me.tbpHistoriaClinica.Size = New System.Drawing.Size(710, 238)
      Me.tbpHistoriaClinica.TabIndex = 1
      Me.tbpHistoriaClinica.Text = "Historia Clínica"
      '
      'btnQuitarDoctor
      '
      Me.btnQuitarDoctor.Image = Global.Eniac.Win.My.Resources.Resources.refresh_24
      Me.btnQuitarDoctor.ImeMode = System.Windows.Forms.ImeMode.NoControl
      Me.btnQuitarDoctor.Location = New System.Drawing.Point(75, 51)
      Me.btnQuitarDoctor.Name = "btnQuitarDoctor"
      Me.btnQuitarDoctor.Size = New System.Drawing.Size(29, 28)
      Me.btnQuitarDoctor.TabIndex = 14
      Me.btnQuitarDoctor.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
      Me.btnQuitarDoctor.UseVisualStyleBackColor = True
      '
      'btnQuitarPaciente
      '
      Me.btnQuitarPaciente.Image = Global.Eniac.Win.My.Resources.Resources.refresh_24
      Me.btnQuitarPaciente.ImeMode = System.Windows.Forms.ImeMode.NoControl
      Me.btnQuitarPaciente.Location = New System.Drawing.Point(75, 12)
      Me.btnQuitarPaciente.Name = "btnQuitarPaciente"
      Me.btnQuitarPaciente.Size = New System.Drawing.Size(29, 28)
      Me.btnQuitarPaciente.TabIndex = 13
      Me.btnQuitarPaciente.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
      Me.btnQuitarPaciente.UseVisualStyleBackColor = True
      '
      'chbDoctor
      '
      Me.chbDoctor.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.chbDoctor.AutoSize = True
      Me.chbDoctor.BindearPropiedadControl = Nothing
      Me.chbDoctor.BindearPropiedadEntidad = Nothing
      Me.chbDoctor.ForeColorFocus = System.Drawing.Color.Red
      Me.chbDoctor.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
      Me.chbDoctor.ImeMode = System.Windows.Forms.ImeMode.NoControl
      Me.chbDoctor.IsPK = False
      Me.chbDoctor.IsRequired = False
      Me.chbDoctor.Key = Nothing
      Me.chbDoctor.LabelAsoc = Nothing
      Me.chbDoctor.Location = New System.Drawing.Point(6, 58)
      Me.chbDoctor.Name = "chbDoctor"
      Me.chbDoctor.Size = New System.Drawing.Size(58, 17)
      Me.chbDoctor.TabIndex = 5
      Me.chbDoctor.Text = "Doctor"
      Me.chbDoctor.UseVisualStyleBackColor = True
      '
      'chbPaciente
      '
      Me.chbPaciente.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.chbPaciente.AutoSize = True
      Me.chbPaciente.BindearPropiedadControl = Nothing
      Me.chbPaciente.BindearPropiedadEntidad = Nothing
      Me.chbPaciente.ForeColorFocus = System.Drawing.Color.Red
      Me.chbPaciente.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
      Me.chbPaciente.ImeMode = System.Windows.Forms.ImeMode.NoControl
      Me.chbPaciente.IsPK = False
      Me.chbPaciente.IsRequired = False
      Me.chbPaciente.Key = Nothing
      Me.chbPaciente.LabelAsoc = Nothing
      Me.chbPaciente.Location = New System.Drawing.Point(6, 19)
      Me.chbPaciente.Name = "chbPaciente"
      Me.chbPaciente.Size = New System.Drawing.Size(68, 17)
      Me.chbPaciente.TabIndex = 0
      Me.chbPaciente.Text = "Paciente"
      Me.chbPaciente.UseVisualStyleBackColor = True
      '
      'chbFechaCirugia
      '
      Me.chbFechaCirugia.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.chbFechaCirugia.AutoSize = True
      Me.chbFechaCirugia.BindearPropiedadControl = Nothing
      Me.chbFechaCirugia.BindearPropiedadEntidad = Nothing
      Me.chbFechaCirugia.ForeColorFocus = System.Drawing.Color.Red
      Me.chbFechaCirugia.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
      Me.chbFechaCirugia.ImeMode = System.Windows.Forms.ImeMode.NoControl
      Me.chbFechaCirugia.IsPK = False
      Me.chbFechaCirugia.IsRequired = False
      Me.chbFechaCirugia.Key = Nothing
      Me.chbFechaCirugia.LabelAsoc = Nothing
      Me.chbFechaCirugia.Location = New System.Drawing.Point(6, 88)
      Me.chbFechaCirugia.Name = "chbFechaCirugia"
      Me.chbFechaCirugia.Size = New System.Drawing.Size(108, 17)
      Me.chbFechaCirugia.TabIndex = 10
      Me.chbFechaCirugia.Text = "Fecha de Cirugía"
      Me.chbFechaCirugia.UseVisualStyleBackColor = True
      '
      'bscCodigoDoctor
      '
      Me.bscCodigoDoctor.ActivarFiltroEnGrilla = True
      Me.bscCodigoDoctor.BindearPropiedadControl = Nothing
      Me.bscCodigoDoctor.BindearPropiedadEntidad = Nothing
      Me.bscCodigoDoctor.ConfigBuscador = Nothing
      Me.bscCodigoDoctor.Datos = Nothing
      Me.bscCodigoDoctor.FilaDevuelta = Nothing
      Me.bscCodigoDoctor.ForeColorFocus = System.Drawing.Color.Red
      Me.bscCodigoDoctor.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
      Me.bscCodigoDoctor.IsDecimal = False
      Me.bscCodigoDoctor.IsNumber = False
      Me.bscCodigoDoctor.IsPK = False
      Me.bscCodigoDoctor.IsRequired = False
      Me.bscCodigoDoctor.Key = ""
      Me.bscCodigoDoctor.LabelAsoc = Nothing
      Me.bscCodigoDoctor.Location = New System.Drawing.Point(110, 58)
      Me.bscCodigoDoctor.MaxLengh = "32767"
      Me.bscCodigoDoctor.Name = "bscCodigoDoctor"
      Me.bscCodigoDoctor.Permitido = True
      Me.bscCodigoDoctor.PermitidoNoBackColor = System.Drawing.Color.FromArgb(CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer))
      Me.bscCodigoDoctor.PermitidoNoForeColor = System.Drawing.Color.Black
      Me.bscCodigoDoctor.PermitidoSiBackColor = System.Drawing.Color.White
      Me.bscCodigoDoctor.PermitidoSiForeColor = System.Drawing.Color.Black
      Me.bscCodigoDoctor.Selecciono = False
      Me.bscCodigoDoctor.Size = New System.Drawing.Size(129, 20)
      Me.bscCodigoDoctor.TabIndex = 7
      '
      'bscCodigoPaciente
      '
      Me.bscCodigoPaciente.ActivarFiltroEnGrilla = True
      Me.bscCodigoPaciente.BindearPropiedadControl = Nothing
      Me.bscCodigoPaciente.BindearPropiedadEntidad = Nothing
      Me.bscCodigoPaciente.ConfigBuscador = Nothing
      Me.bscCodigoPaciente.Datos = Nothing
      Me.bscCodigoPaciente.FilaDevuelta = Nothing
      Me.bscCodigoPaciente.ForeColorFocus = System.Drawing.Color.Red
      Me.bscCodigoPaciente.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
      Me.bscCodigoPaciente.IsDecimal = False
      Me.bscCodigoPaciente.IsNumber = False
      Me.bscCodigoPaciente.IsPK = False
      Me.bscCodigoPaciente.IsRequired = False
      Me.bscCodigoPaciente.Key = ""
      Me.bscCodigoPaciente.LabelAsoc = Nothing
      Me.bscCodigoPaciente.Location = New System.Drawing.Point(110, 19)
      Me.bscCodigoPaciente.MaxLengh = "32767"
      Me.bscCodigoPaciente.Name = "bscCodigoPaciente"
      Me.bscCodigoPaciente.Permitido = True
      Me.bscCodigoPaciente.PermitidoNoBackColor = System.Drawing.Color.FromArgb(CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer))
      Me.bscCodigoPaciente.PermitidoNoForeColor = System.Drawing.Color.Black
      Me.bscCodigoPaciente.PermitidoSiBackColor = System.Drawing.Color.White
      Me.bscCodigoPaciente.PermitidoSiForeColor = System.Drawing.Color.Black
      Me.bscCodigoPaciente.Selecciono = False
      Me.bscCodigoPaciente.Size = New System.Drawing.Size(129, 20)
      Me.bscCodigoPaciente.TabIndex = 2
      '
      'dtpFechaCirugia
      '
      Me.dtpFechaCirugia.BindearPropiedadControl = Nothing
      Me.dtpFechaCirugia.BindearPropiedadEntidad = Nothing
      Me.dtpFechaCirugia.CustomFormat = "dd/MM/yyyy HH:mm"
      Me.dtpFechaCirugia.Enabled = False
      Me.dtpFechaCirugia.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
      Me.dtpFechaCirugia.ForeColorFocus = System.Drawing.Color.Red
      Me.dtpFechaCirugia.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.dtpFechaCirugia.Format = System.Windows.Forms.DateTimePickerFormat.Custom
      Me.dtpFechaCirugia.IsPK = False
      Me.dtpFechaCirugia.IsRequired = False
      Me.dtpFechaCirugia.Key = ""
      Me.dtpFechaCirugia.LabelAsoc = Nothing
      Me.dtpFechaCirugia.Location = New System.Drawing.Point(120, 87)
      Me.dtpFechaCirugia.Name = "dtpFechaCirugia"
      Me.dtpFechaCirugia.ShowCheckBox = True
      Me.dtpFechaCirugia.Size = New System.Drawing.Size(142, 20)
      Me.dtpFechaCirugia.TabIndex = 12
      '
      'bscPaciente
      '
      Me.bscPaciente.ActivarFiltroEnGrilla = True
      Me.bscPaciente.BindearPropiedadControl = Nothing
      Me.bscPaciente.BindearPropiedadEntidad = Nothing
      Me.bscPaciente.ConfigBuscador = Nothing
      Me.bscPaciente.Datos = Nothing
      Me.bscPaciente.FilaDevuelta = Nothing
      Me.bscPaciente.ForeColorFocus = System.Drawing.Color.Red
      Me.bscPaciente.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
      Me.bscPaciente.IsDecimal = False
      Me.bscPaciente.IsNumber = False
      Me.bscPaciente.IsPK = False
      Me.bscPaciente.IsRequired = False
      Me.bscPaciente.Key = ""
      Me.bscPaciente.LabelAsoc = Nothing
      Me.bscPaciente.Location = New System.Drawing.Point(250, 19)
      Me.bscPaciente.MaxLengh = "32767"
      Me.bscPaciente.Name = "bscPaciente"
      Me.bscPaciente.Permitido = True
      Me.bscPaciente.PermitidoNoBackColor = System.Drawing.Color.FromArgb(CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer))
      Me.bscPaciente.PermitidoNoForeColor = System.Drawing.Color.Black
      Me.bscPaciente.PermitidoSiBackColor = System.Drawing.Color.White
      Me.bscPaciente.PermitidoSiForeColor = System.Drawing.Color.Black
      Me.bscPaciente.Selecciono = False
      Me.bscPaciente.Size = New System.Drawing.Size(225, 20)
      Me.bscPaciente.TabIndex = 4
      '
      'Label4
      '
      Me.Label4.AutoSize = True
      Me.Label4.ImeMode = System.Windows.Forms.ImeMode.NoControl
      Me.Label4.LabelAsoc = Nothing
      Me.Label4.Location = New System.Drawing.Point(247, 42)
      Me.Label4.Name = "Label4"
      Me.Label4.Size = New System.Drawing.Size(44, 13)
      Me.Label4.TabIndex = 8
      Me.Label4.Text = "Nombre"
      '
      'bscDoctor
      '
      Me.bscDoctor.ActivarFiltroEnGrilla = True
      Me.bscDoctor.BindearPropiedadControl = Nothing
      Me.bscDoctor.BindearPropiedadEntidad = Nothing
      Me.bscDoctor.ConfigBuscador = Nothing
      Me.bscDoctor.Datos = Nothing
      Me.bscDoctor.FilaDevuelta = Nothing
      Me.bscDoctor.ForeColorFocus = System.Drawing.Color.Red
      Me.bscDoctor.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
      Me.bscDoctor.IsDecimal = False
      Me.bscDoctor.IsNumber = False
      Me.bscDoctor.IsPK = False
      Me.bscDoctor.IsRequired = False
      Me.bscDoctor.Key = ""
      Me.bscDoctor.LabelAsoc = Nothing
      Me.bscDoctor.Location = New System.Drawing.Point(250, 58)
      Me.bscDoctor.MaxLengh = "32767"
      Me.bscDoctor.Name = "bscDoctor"
      Me.bscDoctor.Permitido = True
      Me.bscDoctor.PermitidoNoBackColor = System.Drawing.Color.FromArgb(CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer))
      Me.bscDoctor.PermitidoNoForeColor = System.Drawing.Color.Black
      Me.bscDoctor.PermitidoSiBackColor = System.Drawing.Color.White
      Me.bscDoctor.PermitidoSiForeColor = System.Drawing.Color.Black
      Me.bscDoctor.Selecciono = False
      Me.bscDoctor.Size = New System.Drawing.Size(225, 20)
      Me.bscDoctor.TabIndex = 9
      '
      'Label5
      '
      Me.Label5.AutoSize = True
      Me.Label5.ImeMode = System.Windows.Forms.ImeMode.NoControl
      Me.Label5.LabelAsoc = Nothing
      Me.Label5.Location = New System.Drawing.Point(109, 42)
      Me.Label5.Name = "Label5"
      Me.Label5.Size = New System.Drawing.Size(40, 13)
      Me.Label5.TabIndex = 6
      Me.Label5.Text = "Código"
      '
      'Label3
      '
      Me.Label3.AutoSize = True
      Me.Label3.ImeMode = System.Windows.Forms.ImeMode.NoControl
      Me.Label3.LabelAsoc = Nothing
      Me.Label3.Location = New System.Drawing.Point(247, 3)
      Me.Label3.Name = "Label3"
      Me.Label3.Size = New System.Drawing.Size(44, 13)
      Me.Label3.TabIndex = 3
      Me.Label3.Text = "Nombre"
      '
      'Label2
      '
      Me.Label2.AutoSize = True
      Me.Label2.ImeMode = System.Windows.Forms.ImeMode.NoControl
      Me.Label2.LabelAsoc = Nothing
      Me.Label2.Location = New System.Drawing.Point(109, 3)
      Me.Label2.Name = "Label2"
      Me.Label2.Size = New System.Drawing.Size(40, 13)
      Me.Label2.TabIndex = 1
      Me.Label2.Text = "Código"
      '
      'DsInfPedidosFacturados1
      '
      Me.DsInfPedidosFacturados1.DataSetName = "DsInfPedidosFacturados"
      Me.DsInfPedidosFacturados1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
      '
      'ModificarVentasDetalle
      '
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.ClientSize = New System.Drawing.Size(738, 412)
      Me.Controls.Add(Me.tbcDatos)
      Me.Controls.Add(Me.grpCliente)
      Me.Controls.Add(Me.tspFichas)
      Me.KeyPreview = True
      Me.Name = "ModificarVentasDetalle"
      Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
      Me.Text = "Modificar Ventas "
      Me.tspFichas.ResumeLayout(False)
      Me.tspFichas.PerformLayout()
      Me.grpCliente.ResumeLayout(False)
      Me.grpCliente.PerformLayout()
      Me.tbcDatos.ResumeLayout(False)
      Me.tbpDatos.ResumeLayout(False)
      Me.tbpDatos.PerformLayout()
      Me.tbpHistoriaClinica.ResumeLayout(False)
      Me.tbpHistoriaClinica.PerformLayout()
      CType(Me.DsInfPedidosFacturados1, System.ComponentModel.ISupportInitialize).EndInit()
      Me.ResumeLayout(False)
      Me.PerformLayout()

   End Sub
   Friend WithEvents tspFichas As System.Windows.Forms.ToolStrip
   Friend WithEvents tsbGrabar As System.Windows.Forms.ToolStripButton
   Friend WithEvents tsbSalir As System.Windows.Forms.ToolStripButton
   Friend WithEvents grpCliente As System.Windows.Forms.GroupBox
   Friend WithEvents txtCategoriaFiscal As Eniac.Controles.TextBox
   Friend WithEvents lblCategoriaFiscal As System.Windows.Forms.Label
   Friend WithEvents bscProveedor As Eniac.Controles.Buscador2
   Friend WithEvents lblNombreProv As Eniac.Controles.Label
   Friend WithEvents lblCodigoProveedor As Eniac.Controles.Label
   Friend WithEvents bscCodigoCliente As Eniac.Controles.Buscador2
   Friend WithEvents lblCliente As Eniac.Controles.Label
   Friend WithEvents txtIdTipoComprobante As Eniac.Controles.TextBox
   Friend WithEvents txtLetra As Eniac.Controles.TextBox
   Friend WithEvents lblComprobante As Eniac.Controles.Label
   Friend WithEvents txtNumeroFactura As Eniac.Controles.TextBox
   Friend WithEvents txtEmisorFactura As Eniac.Controles.TextBox
   Friend WithEvents lblNumeroFactura As Eniac.Controles.Label
   Friend WithEvents lblEmisorFactura As Eniac.Controles.Label
   Friend WithEvents lblTipoFactura As Eniac.Controles.Label
   Friend WithEvents lblTipoComprobante As Eniac.Controles.Label
   Friend WithEvents bscCliente As Eniac.Controles.Buscador2
   Friend WithEvents tbcDatos As System.Windows.Forms.TabControl
   Friend WithEvents tbpDatos As System.Windows.Forms.TabPage
   Friend WithEvents tbpHistoriaClinica As System.Windows.Forms.TabPage
   Friend WithEvents chbFechaCirugia As Eniac.Controles.CheckBox
   Friend WithEvents bscCodigoDoctor As Eniac.Controles.Buscador2
   Friend WithEvents bscCodigoPaciente As Eniac.Controles.Buscador2
   Friend WithEvents dtpFechaCirugia As Eniac.Controles.DateTimePicker
   Friend WithEvents bscPaciente As Eniac.Controles.Buscador2
   Friend WithEvents Label4 As Eniac.Controles.Label
   Friend WithEvents bscDoctor As Eniac.Controles.Buscador2
   Friend WithEvents Label5 As Eniac.Controles.Label
   Friend WithEvents Label3 As Eniac.Controles.Label
   Friend WithEvents Label2 As Eniac.Controles.Label
   Friend WithEvents chbDoctor As Eniac.Controles.CheckBox
   Friend WithEvents chbPaciente As Eniac.Controles.CheckBox
   Friend WithEvents chbObservacion As Eniac.Controles.CheckBox
   Friend WithEvents chbReferenciaCuentaCorriente As Eniac.Controles.CheckBox
   Friend WithEvents chbComisionVendedor As Eniac.Controles.CheckBox
   Friend WithEvents txtReferenciaCtaCte As Eniac.Controles.TextBox
   Friend WithEvents chbCobrador As Eniac.Controles.CheckBox
   Friend WithEvents chbVendedor As Eniac.Controles.CheckBox
   Friend WithEvents txtComisiones As Eniac.Controles.TextBox
   Friend WithEvents chbClienteCtaCte As Eniac.Controles.CheckBox
   Friend WithEvents bscCodigoClienteCtaCte As Eniac.Controles.Buscador2
   Friend WithEvents lblCodigoClienteCtaCte As Eniac.Controles.Label
   Friend WithEvents cmbCategoria As Eniac.Controles.ComboBox
   Friend WithEvents chbCategoria As Eniac.Controles.CheckBox
   Friend WithEvents lblNombreCtaCte As Eniac.Controles.Label
   Friend WithEvents bscClienteCtaCte As Eniac.Controles.Buscador2
   Friend WithEvents chbFormaDePago As Eniac.Controles.CheckBox
   Friend WithEvents cboFormaPago As Eniac.Controles.ComboBox
   Friend WithEvents txtObservacion As Eniac.Controles.TextBox
   Friend WithEvents cmbVendedor As Eniac.Controles.ComboBox
   Friend WithEvents cmbCobrador As Eniac.Controles.ComboBox
   Friend WithEvents dtpFecha As System.Windows.Forms.DateTimePicker
   Friend WithEvents chbFecha As Eniac.Controles.CheckBox
   Friend WithEvents DsInfPedidosFacturados1 As Eniac.Entidades.DsInfPedidosFacturados
   Friend WithEvents btnQuitarDoctor As Eniac.Controles.Button
   Friend WithEvents btnQuitarPaciente As Eniac.Controles.Button
   Friend WithEvents btnQuitarClienteVinculado As Eniac.Controles.Button
   Friend WithEvents cmbTipoDoc As Controles.ComboBox
   Friend WithEvents chbTipoDocumento As Controles.CheckBox
   Friend WithEvents txtNroDoc As Controles.TextBox
   Friend WithEvents txtCUIT As Controles.TextBox
   Friend WithEvents chbCUIT As Controles.CheckBox
End Class
