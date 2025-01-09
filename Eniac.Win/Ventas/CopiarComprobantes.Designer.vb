<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CopiarComprobantes
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
      Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(CopiarComprobantes))
      Dim Appearance1 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim Appearance2 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim Appearance3 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim Appearance4 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim Appearance5 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim Appearance6 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim Appearance7 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim Appearance8 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim Appearance9 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim Appearance10 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim Appearance11 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim Appearance12 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Me.tstBarra = New System.Windows.Forms.ToolStrip()
      Me.tsbRefrescar = New System.Windows.Forms.ToolStripButton()
      Me.tsbCerrar = New System.Windows.Forms.ToolStripButton()
      Me.stsStado = New System.Windows.Forms.StatusStrip()
      Me.tssInfo = New System.Windows.Forms.ToolStripStatusLabel()
      Me.tspBarra = New System.Windows.Forms.ToolStripProgressBar()
      Me.tssRegistros = New System.Windows.Forms.ToolStripStatusLabel()
      Me.grbDetalle = New System.Windows.Forms.GroupBox()
      Me.cmbCajasOrigen = New Eniac.Controles.ComboBox()
      Me.Label1 = New Eniac.Controles.Label()
      Me.lblTipoComprobanteOrigen = New Eniac.Controles.Label()
      Me.txtUsuario = New Eniac.Controles.TextBox()
      Me.chbUsuario = New Eniac.Controles.CheckBox()
      Me.txtNroReparto = New Eniac.Controles.TextBox()
      Me.chbNumeroReparto = New Eniac.Controles.CheckBox()
      Me.bscCodigoCliente = New Eniac.Controles.Buscador()
      Me.lblCodigoCliente = New Eniac.Controles.Label()
      Me.bscCliente = New Eniac.Controles.Buscador()
      Me.lblNombre = New Eniac.Controles.Label()
      Me.chbCliente = New Eniac.Controles.CheckBox()
      Me.chbLetra = New Eniac.Controles.CheckBox()
      Me.chbEmisor = New Eniac.Controles.CheckBox()
      Me.cmbEmisor = New Eniac.Controles.ComboBox()
      Me.cboLetra = New Eniac.Controles.ComboBox()
      Me.txtNumero = New Eniac.Controles.TextBox()
      Me.cmbTiposComprobantesOrigen = New Eniac.Controles.ComboBox()
      Me.chbNumero = New Eniac.Controles.CheckBox()
      Me.chkMesCompleto = New Eniac.Controles.CheckBox()
      Me.btnBuscar = New Eniac.Controles.Button()
      Me.dtpHasta = New Eniac.Controles.DateTimePicker()
      Me.lblHasta = New Eniac.Controles.Label()
      Me.dtpDesde = New Eniac.Controles.DateTimePicker()
      Me.lblDesde = New Eniac.Controles.Label()
      Me.chbTodos = New Eniac.Controles.CheckBox()
      Me.ugvComprobantes = New Infragistics.Win.UltraWinGrid.UltraGrid()
      Me.grbDatosNuevos = New System.Windows.Forms.GroupBox()
      Me.lblSucursal = New Eniac.Controles.Label()
      Me.cmbSucursalNueva = New Eniac.Controles.ComboBox()
      Me.txtNumeroDestino = New Eniac.Controles.TextBox()
      Me.chbNumeroDestino = New Eniac.Controles.CheckBox()
      Me.dtpNuevaFecha = New Eniac.Controles.DateTimePicker()
      Me.chbUtilizaFechaCompAnterior = New System.Windows.Forms.CheckBox()
      Me.cmbCajas = New Eniac.Controles.ComboBox()
      Me.lblCaja = New Eniac.Controles.Label()
      Me.btnCopiar = New Eniac.Controles.Button()
      Me.lblTipoComprobanteDestino = New Eniac.Controles.Label()
      Me.cmbTiposComprobantesDestino = New Eniac.Controles.ComboBox()
      Me.chbEliminarOrigen = New System.Windows.Forms.CheckBox()
        Me.tstBarra.SuspendLayout()
        Me.stsStado.SuspendLayout()
        Me.grbDetalle.SuspendLayout()
        CType(Me.ugvComprobantes, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grbDatosNuevos.SuspendLayout()
        Me.SuspendLayout()
        '
        'tstBarra
        '
        Me.tstBarra.ImageScalingSize = New System.Drawing.Size(24, 24)
        Me.tstBarra.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsbRefrescar, Me.tsbCerrar})
        Me.tstBarra.Location = New System.Drawing.Point(0, 0)
        Me.tstBarra.Name = "tstBarra"
        Me.tstBarra.Size = New System.Drawing.Size(984, 31)
        Me.tstBarra.TabIndex = 4
        '
        'tsbRefrescar
        '
        Me.tsbRefrescar.Image = CType(resources.GetObject("tsbRefrescar.Image"), System.Drawing.Image)
        Me.tsbRefrescar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbRefrescar.Name = "tsbRefrescar"
        Me.tsbRefrescar.Size = New System.Drawing.Size(106, 28)
        Me.tsbRefrescar.Text = "&Refrescar (F5)"
        '
        'tsbCerrar
        '
        Me.tsbCerrar.Image = CType(resources.GetObject("tsbCerrar.Image"), System.Drawing.Image)
        Me.tsbCerrar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbCerrar.Name = "tsbCerrar"
        Me.tsbCerrar.Size = New System.Drawing.Size(67, 28)
        Me.tsbCerrar.Text = "&Cerrar"
        '
        'stsStado
        '
        Me.stsStado.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tssInfo, Me.tspBarra, Me.tssRegistros})
        Me.stsStado.Location = New System.Drawing.Point(0, 489)
        Me.stsStado.Name = "stsStado"
        Me.stsStado.Size = New System.Drawing.Size(984, 22)
        Me.stsStado.TabIndex = 3
        Me.stsStado.Text = "statusStrip1"
        '
        'tssInfo
        '
        Me.tssInfo.Name = "tssInfo"
        Me.tssInfo.Size = New System.Drawing.Size(905, 17)
        Me.tssInfo.Spring = True
        Me.tssInfo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
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
        'grbDetalle
        '
        Me.grbDetalle.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grbDetalle.Controls.Add(Me.cmbCajasOrigen)
        Me.grbDetalle.Controls.Add(Me.Label1)
        Me.grbDetalle.Controls.Add(Me.lblTipoComprobanteOrigen)
        Me.grbDetalle.Controls.Add(Me.txtUsuario)
        Me.grbDetalle.Controls.Add(Me.chbUsuario)
        Me.grbDetalle.Controls.Add(Me.txtNroReparto)
        Me.grbDetalle.Controls.Add(Me.chbNumeroReparto)
        Me.grbDetalle.Controls.Add(Me.bscCodigoCliente)
        Me.grbDetalle.Controls.Add(Me.bscCliente)
        Me.grbDetalle.Controls.Add(Me.lblCodigoCliente)
        Me.grbDetalle.Controls.Add(Me.lblNombre)
        Me.grbDetalle.Controls.Add(Me.chbCliente)
        Me.grbDetalle.Controls.Add(Me.chbLetra)
        Me.grbDetalle.Controls.Add(Me.chbEmisor)
        Me.grbDetalle.Controls.Add(Me.cmbEmisor)
        Me.grbDetalle.Controls.Add(Me.cboLetra)
        Me.grbDetalle.Controls.Add(Me.txtNumero)
        Me.grbDetalle.Controls.Add(Me.cmbTiposComprobantesOrigen)
        Me.grbDetalle.Controls.Add(Me.chbNumero)
        Me.grbDetalle.Controls.Add(Me.chkMesCompleto)
        Me.grbDetalle.Controls.Add(Me.btnBuscar)
        Me.grbDetalle.Controls.Add(Me.dtpHasta)
        Me.grbDetalle.Controls.Add(Me.dtpDesde)
        Me.grbDetalle.Controls.Add(Me.lblHasta)
        Me.grbDetalle.Controls.Add(Me.lblDesde)
        Me.grbDetalle.Location = New System.Drawing.Point(12, 34)
        Me.grbDetalle.Name = "grbDetalle"
        Me.grbDetalle.Size = New System.Drawing.Size(960, 112)
        Me.grbDetalle.TabIndex = 0
        Me.grbDetalle.TabStop = False
        Me.grbDetalle.Text = "Detalle"
        '
        'cmbCajasOrigen
        '
        Me.cmbCajasOrigen.BindearPropiedadControl = ""
        Me.cmbCajasOrigen.BindearPropiedadEntidad = ""
        Me.cmbCajasOrigen.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbCajasOrigen.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbCajasOrigen.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbCajasOrigen.FormattingEnabled = True
        Me.cmbCajasOrigen.IsPK = False
        Me.cmbCajasOrigen.IsRequired = False
        Me.cmbCajasOrigen.Key = Nothing
        Me.cmbCajasOrigen.LabelAsoc = Me.Label1
        Me.cmbCajasOrigen.Location = New System.Drawing.Point(115, 83)
        Me.cmbCajasOrigen.Name = "cmbCajasOrigen"
        Me.cmbCajasOrigen.Size = New System.Drawing.Size(125, 21)
        Me.cmbCajasOrigen.TabIndex = 4
        Me.cmbCajasOrigen.TabStop = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Label1.LabelAsoc = Nothing
        Me.Label1.Location = New System.Drawing.Point(17, 86)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(28, 13)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "Caja"
        '
        'lblTipoComprobanteOrigen
        '
        Me.lblTipoComprobanteOrigen.AutoSize = True
        Me.lblTipoComprobanteOrigen.LabelAsoc = Nothing
        Me.lblTipoComprobanteOrigen.Location = New System.Drawing.Point(17, 60)
        Me.lblTipoComprobanteOrigen.Name = "lblTipoComprobanteOrigen"
        Me.lblTipoComprobanteOrigen.Size = New System.Drawing.Size(94, 13)
        Me.lblTipoComprobanteOrigen.TabIndex = 6
        Me.lblTipoComprobanteOrigen.Text = "Tipo Comprobante"
        '
        'txtUsuario
        '
        Me.txtUsuario.BindearPropiedadControl = Nothing
        Me.txtUsuario.BindearPropiedadEntidad = Nothing
        Me.txtUsuario.Enabled = False
        Me.txtUsuario.ForeColorFocus = System.Drawing.Color.Red
        Me.txtUsuario.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtUsuario.Formato = "##0"
        Me.txtUsuario.IsDecimal = False
        Me.txtUsuario.IsNumber = False
        Me.txtUsuario.IsPK = False
        Me.txtUsuario.IsRequired = False
        Me.txtUsuario.Key = ""
        Me.txtUsuario.LabelAsoc = Nothing
        Me.txtUsuario.Location = New System.Drawing.Point(332, 84)
        Me.txtUsuario.MaxLength = 8
        Me.txtUsuario.Name = "txtUsuario"
        Me.txtUsuario.Size = New System.Drawing.Size(112, 20)
        Me.txtUsuario.TabIndex = 27
        '
        'chbUsuario
        '
        Me.chbUsuario.AutoSize = True
        Me.chbUsuario.BindearPropiedadControl = Nothing
        Me.chbUsuario.BindearPropiedadEntidad = Nothing
        Me.chbUsuario.ForeColorFocus = System.Drawing.Color.Red
        Me.chbUsuario.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbUsuario.IsPK = False
        Me.chbUsuario.IsRequired = False
        Me.chbUsuario.Key = Nothing
        Me.chbUsuario.LabelAsoc = Nothing
        Me.chbUsuario.Location = New System.Drawing.Point(274, 86)
        Me.chbUsuario.Name = "chbUsuario"
        Me.chbUsuario.Size = New System.Drawing.Size(62, 17)
        Me.chbUsuario.TabIndex = 26
        Me.chbUsuario.Text = "Usuario"
        Me.chbUsuario.UseVisualStyleBackColor = True
        '
        'txtNroReparto
        '
        Me.txtNroReparto.BindearPropiedadControl = Nothing
        Me.txtNroReparto.BindearPropiedadEntidad = Nothing
        Me.txtNroReparto.Enabled = False
        Me.txtNroReparto.ForeColorFocus = System.Drawing.Color.Red
        Me.txtNroReparto.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtNroReparto.Formato = "##0"
        Me.txtNroReparto.IsDecimal = False
        Me.txtNroReparto.IsNumber = True
        Me.txtNroReparto.IsPK = False
        Me.txtNroReparto.IsRequired = False
        Me.txtNroReparto.Key = ""
        Me.txtNroReparto.LabelAsoc = Nothing
        Me.txtNroReparto.Location = New System.Drawing.Point(718, 56)
        Me.txtNroReparto.MaxLength = 8
        Me.txtNroReparto.Name = "txtNroReparto"
        Me.txtNroReparto.Size = New System.Drawing.Size(56, 20)
        Me.txtNroReparto.TabIndex = 27
        Me.txtNroReparto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'chbNumeroReparto
        '
        Me.chbNumeroReparto.AutoSize = True
        Me.chbNumeroReparto.BindearPropiedadControl = Nothing
        Me.chbNumeroReparto.BindearPropiedadEntidad = Nothing
        Me.chbNumeroReparto.ForeColorFocus = System.Drawing.Color.Red
        Me.chbNumeroReparto.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbNumeroReparto.IsPK = False
        Me.chbNumeroReparto.IsRequired = False
        Me.chbNumeroReparto.Key = Nothing
        Me.chbNumeroReparto.LabelAsoc = Nothing
        Me.chbNumeroReparto.Location = New System.Drawing.Point(618, 58)
        Me.chbNumeroReparto.Name = "chbNumeroReparto"
        Me.chbNumeroReparto.Size = New System.Drawing.Size(104, 17)
        Me.chbNumeroReparto.TabIndex = 26
        Me.chbNumeroReparto.Text = "Numero Reparto"
        Me.chbNumeroReparto.UseVisualStyleBackColor = True
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
        Me.bscCodigoCliente.Enabled = False
        Me.bscCodigoCliente.FilaDevuelta = Nothing
        Me.bscCodigoCliente.ForeColorFocus = System.Drawing.Color.Red
        Me.bscCodigoCliente.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.bscCodigoCliente.IsDecimal = False
        Me.bscCodigoCliente.IsNumber = False
        Me.bscCodigoCliente.IsPK = False
        Me.bscCodigoCliente.IsRequired = False
        Me.bscCodigoCliente.Key = ""
        Me.bscCodigoCliente.LabelAsoc = Me.lblCodigoCliente
        Me.bscCodigoCliente.Location = New System.Drawing.Point(551, 27)
        Me.bscCodigoCliente.MaxLengh = "32767"
        Me.bscCodigoCliente.Name = "bscCodigoCliente"
        Me.bscCodigoCliente.Permitido = True
        Me.bscCodigoCliente.Selecciono = False
        Me.bscCodigoCliente.Size = New System.Drawing.Size(90, 23)
        Me.bscCodigoCliente.TabIndex = 22
        Me.bscCodigoCliente.Titulo = Nothing
        '
        'lblCodigoCliente
        '
        Me.lblCodigoCliente.AutoSize = True
        Me.lblCodigoCliente.LabelAsoc = Nothing
        Me.lblCodigoCliente.Location = New System.Drawing.Point(548, 11)
        Me.lblCodigoCliente.Name = "lblCodigoCliente"
        Me.lblCodigoCliente.Size = New System.Drawing.Size(40, 13)
        Me.lblCodigoCliente.TabIndex = 23
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
        Me.bscCliente.Enabled = False
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
        Me.bscCliente.Location = New System.Drawing.Point(645, 27)
        Me.bscCliente.Margin = New System.Windows.Forms.Padding(4)
        Me.bscCliente.MaxLengh = "32767"
        Me.bscCliente.Name = "bscCliente"
        Me.bscCliente.Permitido = True
        Me.bscCliente.Selecciono = False
        Me.bscCliente.Size = New System.Drawing.Size(254, 23)
        Me.bscCliente.TabIndex = 24
        Me.bscCliente.Titulo = Nothing
        '
        'lblNombre
        '
        Me.lblNombre.AutoSize = True
        Me.lblNombre.LabelAsoc = Nothing
        Me.lblNombre.Location = New System.Drawing.Point(645, 11)
        Me.lblNombre.Name = "lblNombre"
        Me.lblNombre.Size = New System.Drawing.Size(44, 13)
        Me.lblNombre.TabIndex = 25
        Me.lblNombre.Text = "Nombre"
        '
        'chbCliente
        '
        Me.chbCliente.AutoSize = True
        Me.chbCliente.BindearPropiedadControl = Nothing
        Me.chbCliente.BindearPropiedadEntidad = Nothing
        Me.chbCliente.ForeColorFocus = System.Drawing.Color.Red
        Me.chbCliente.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbCliente.IsPK = False
        Me.chbCliente.IsRequired = False
        Me.chbCliente.Key = Nothing
        Me.chbCliente.LabelAsoc = Nothing
        Me.chbCliente.Location = New System.Drawing.Point(485, 29)
        Me.chbCliente.Name = "chbCliente"
        Me.chbCliente.Size = New System.Drawing.Size(58, 17)
        Me.chbCliente.TabIndex = 21
        Me.chbCliente.Text = "Cliente"
        Me.chbCliente.UseVisualStyleBackColor = True
        '
        'chbLetra
        '
        Me.chbLetra.AutoSize = True
        Me.chbLetra.BindearPropiedadControl = Nothing
        Me.chbLetra.BindearPropiedadEntidad = Nothing
        Me.chbLetra.ForeColorFocus = System.Drawing.Color.Red
        Me.chbLetra.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbLetra.IsPK = False
        Me.chbLetra.IsRequired = False
        Me.chbLetra.Key = Nothing
        Me.chbLetra.LabelAsoc = Nothing
        Me.chbLetra.Location = New System.Drawing.Point(274, 58)
        Me.chbLetra.Name = "chbLetra"
        Me.chbLetra.Size = New System.Drawing.Size(50, 17)
        Me.chbLetra.TabIndex = 14
        Me.chbLetra.Text = "Letra"
        Me.chbLetra.UseVisualStyleBackColor = True
        '
        'chbEmisor
        '
        Me.chbEmisor.AutoSize = True
        Me.chbEmisor.BindearPropiedadControl = Nothing
        Me.chbEmisor.BindearPropiedadEntidad = Nothing
        Me.chbEmisor.ForeColorFocus = System.Drawing.Color.Red
        Me.chbEmisor.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbEmisor.IsPK = False
        Me.chbEmisor.IsRequired = False
        Me.chbEmisor.Key = Nothing
        Me.chbEmisor.LabelAsoc = Nothing
        Me.chbEmisor.Location = New System.Drawing.Point(379, 58)
        Me.chbEmisor.Name = "chbEmisor"
        Me.chbEmisor.Size = New System.Drawing.Size(57, 17)
        Me.chbEmisor.TabIndex = 16
        Me.chbEmisor.Text = "Emisor"
        Me.chbEmisor.UseVisualStyleBackColor = True
        '
        'cmbEmisor
        '
        Me.cmbEmisor.BindearPropiedadControl = Nothing
        Me.cmbEmisor.BindearPropiedadEntidad = Nothing
        Me.cmbEmisor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbEmisor.Enabled = False
        Me.cmbEmisor.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbEmisor.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbEmisor.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbEmisor.FormattingEnabled = True
        Me.cmbEmisor.IsPK = False
        Me.cmbEmisor.IsRequired = False
        Me.cmbEmisor.Key = Nothing
        Me.cmbEmisor.LabelAsoc = Nothing
        Me.cmbEmisor.Location = New System.Drawing.Point(437, 56)
        Me.cmbEmisor.Name = "cmbEmisor"
        Me.cmbEmisor.Size = New System.Drawing.Size(40, 21)
        Me.cmbEmisor.TabIndex = 17
        '
        'cboLetra
        '
        Me.cboLetra.BindearPropiedadControl = Nothing
        Me.cboLetra.BindearPropiedadEntidad = Nothing
        Me.cboLetra.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboLetra.Enabled = False
        Me.cboLetra.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboLetra.ForeColorFocus = System.Drawing.Color.Red
        Me.cboLetra.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cboLetra.FormattingEnabled = True
        Me.cboLetra.IsPK = False
        Me.cboLetra.IsRequired = False
        Me.cboLetra.Key = Nothing
        Me.cboLetra.LabelAsoc = Nothing
        Me.cboLetra.Location = New System.Drawing.Point(332, 56)
        Me.cboLetra.Name = "cboLetra"
        Me.cboLetra.Size = New System.Drawing.Size(38, 21)
        Me.cboLetra.TabIndex = 15
        '
        'txtNumero
        '
        Me.txtNumero.BindearPropiedadControl = Nothing
        Me.txtNumero.BindearPropiedadEntidad = Nothing
        Me.txtNumero.Enabled = False
        Me.txtNumero.ForeColorFocus = System.Drawing.Color.Red
        Me.txtNumero.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtNumero.Formato = "##0"
        Me.txtNumero.IsDecimal = False
        Me.txtNumero.IsNumber = True
        Me.txtNumero.IsPK = False
        Me.txtNumero.IsRequired = False
        Me.txtNumero.Key = ""
        Me.txtNumero.LabelAsoc = Nothing
        Me.txtNumero.Location = New System.Drawing.Point(551, 56)
        Me.txtNumero.MaxLength = 8
        Me.txtNumero.Name = "txtNumero"
        Me.txtNumero.Size = New System.Drawing.Size(56, 20)
        Me.txtNumero.TabIndex = 19
        Me.txtNumero.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'cmbTiposComprobantesOrigen
        '
        Me.cmbTiposComprobantesOrigen.BindearPropiedadControl = Nothing
        Me.cmbTiposComprobantesOrigen.BindearPropiedadEntidad = Nothing
        Me.cmbTiposComprobantesOrigen.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbTiposComprobantesOrigen.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.cmbTiposComprobantesOrigen.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbTiposComprobantesOrigen.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbTiposComprobantesOrigen.FormattingEnabled = True
        Me.cmbTiposComprobantesOrigen.IsPK = False
        Me.cmbTiposComprobantesOrigen.IsRequired = False
        Me.cmbTiposComprobantesOrigen.ItemHeight = 13
        Me.cmbTiposComprobantesOrigen.Key = Nothing
        Me.cmbTiposComprobantesOrigen.LabelAsoc = Me.lblTipoComprobanteOrigen
        Me.cmbTiposComprobantesOrigen.Location = New System.Drawing.Point(115, 56)
        Me.cmbTiposComprobantesOrigen.Name = "cmbTiposComprobantesOrigen"
        Me.cmbTiposComprobantesOrigen.Size = New System.Drawing.Size(150, 21)
        Me.cmbTiposComprobantesOrigen.TabIndex = 13
        '
        'chbNumero
        '
        Me.chbNumero.AutoSize = True
        Me.chbNumero.BindearPropiedadControl = Nothing
        Me.chbNumero.BindearPropiedadEntidad = Nothing
        Me.chbNumero.ForeColorFocus = System.Drawing.Color.Red
        Me.chbNumero.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbNumero.IsPK = False
        Me.chbNumero.IsRequired = False
        Me.chbNumero.Key = Nothing
        Me.chbNumero.LabelAsoc = Nothing
        Me.chbNumero.Location = New System.Drawing.Point(485, 58)
        Me.chbNumero.Name = "chbNumero"
        Me.chbNumero.Size = New System.Drawing.Size(63, 17)
        Me.chbNumero.TabIndex = 18
        Me.chbNumero.Text = "Número"
        Me.chbNumero.UseVisualStyleBackColor = True
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
        Me.chkMesCompleto.Location = New System.Drawing.Point(17, 27)
        Me.chkMesCompleto.Name = "chkMesCompleto"
        Me.chkMesCompleto.Size = New System.Drawing.Size(93, 17)
        Me.chkMesCompleto.TabIndex = 0
        Me.chkMesCompleto.Text = "Mes Completo"
        Me.chkMesCompleto.UseVisualStyleBackColor = True
        '
        'btnBuscar
        '
        Me.btnBuscar.Image = CType(resources.GetObject("btnBuscar.Image"), System.Drawing.Image)
        Me.btnBuscar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnBuscar.Location = New System.Drawing.Point(864, 58)
        Me.btnBuscar.Name = "btnBuscar"
        Me.btnBuscar.Size = New System.Drawing.Size(90, 45)
        Me.btnBuscar.TabIndex = 5
        Me.btnBuscar.Text = "&Buscar"
        Me.btnBuscar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnBuscar.UseVisualStyleBackColor = True
        '
        'dtpHasta
        '
        Me.dtpHasta.BindearPropiedadControl = Nothing
        Me.dtpHasta.BindearPropiedadEntidad = Nothing
        Me.dtpHasta.CustomFormat = "dd/MM/yyyy HH:mm"
        Me.dtpHasta.ForeColorFocus = System.Drawing.Color.Red
        Me.dtpHasta.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.dtpHasta.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpHasta.IsPK = False
        Me.dtpHasta.IsRequired = False
        Me.dtpHasta.Key = ""
        Me.dtpHasta.LabelAsoc = Me.lblHasta
        Me.dtpHasta.Location = New System.Drawing.Point(332, 25)
        Me.dtpHasta.Name = "dtpHasta"
        Me.dtpHasta.Size = New System.Drawing.Size(125, 20)
        Me.dtpHasta.TabIndex = 4
        '
        'lblHasta
        '
        Me.lblHasta.AutoSize = True
        Me.lblHasta.LabelAsoc = Nothing
        Me.lblHasta.Location = New System.Drawing.Point(291, 29)
        Me.lblHasta.Name = "lblHasta"
        Me.lblHasta.Size = New System.Drawing.Size(35, 13)
        Me.lblHasta.TabIndex = 3
        Me.lblHasta.Text = "Hasta"
        '
        'dtpDesde
        '
        Me.dtpDesde.BindearPropiedadControl = Nothing
        Me.dtpDesde.BindearPropiedadEntidad = Nothing
        Me.dtpDesde.CustomFormat = "dd/MM/yyyy HH:mm"
        Me.dtpDesde.ForeColorFocus = System.Drawing.Color.Red
        Me.dtpDesde.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.dtpDesde.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpDesde.IsPK = False
        Me.dtpDesde.IsRequired = False
        Me.dtpDesde.Key = ""
        Me.dtpDesde.LabelAsoc = Me.lblDesde
        Me.dtpDesde.Location = New System.Drawing.Point(156, 25)
        Me.dtpDesde.Name = "dtpDesde"
        Me.dtpDesde.Size = New System.Drawing.Size(125, 20)
        Me.dtpDesde.TabIndex = 2
        '
        'lblDesde
        '
        Me.lblDesde.AutoSize = True
        Me.lblDesde.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblDesde.LabelAsoc = Nothing
        Me.lblDesde.Location = New System.Drawing.Point(112, 29)
        Me.lblDesde.Name = "lblDesde"
        Me.lblDesde.Size = New System.Drawing.Size(38, 13)
        Me.lblDesde.TabIndex = 1
        Me.lblDesde.Text = "Desde"
        '
        'chbTodos
        '
        Me.chbTodos.BindearPropiedadControl = Nothing
        Me.chbTodos.BindearPropiedadEntidad = Nothing
        Me.chbTodos.ForeColorFocus = System.Drawing.Color.Red
        Me.chbTodos.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbTodos.Image = CType(resources.GetObject("chbTodos.Image"), System.Drawing.Image)
        Me.chbTodos.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.chbTodos.IsPK = False
        Me.chbTodos.IsRequired = False
        Me.chbTodos.Key = Nothing
        Me.chbTodos.LabelAsoc = Nothing
        Me.chbTodos.Location = New System.Drawing.Point(12, 152)
        Me.chbTodos.Name = "chbTodos"
        Me.chbTodos.Size = New System.Drawing.Size(121, 18)
        Me.chbTodos.TabIndex = 6
        Me.chbTodos.Text = "Chequear todos"
        Me.chbTodos.UseVisualStyleBackColor = True
        '
        'ugvComprobantes
        '
        Me.ugvComprobantes.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Appearance1.BackColor = System.Drawing.SystemColors.Window
        Appearance1.BorderColor = System.Drawing.SystemColors.InactiveCaption
        Me.ugvComprobantes.DisplayLayout.Appearance = Appearance1
        Me.ugvComprobantes.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.ugvComprobantes.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.[False]
        Appearance2.BackColor = System.Drawing.SystemColors.ActiveBorder
        Appearance2.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance2.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Appearance2.BorderColor = System.Drawing.SystemColors.Window
        Me.ugvComprobantes.DisplayLayout.GroupByBox.Appearance = Appearance2
        Appearance3.ForeColor = System.Drawing.SystemColors.GrayText
        Me.ugvComprobantes.DisplayLayout.GroupByBox.BandLabelAppearance = Appearance3
        Me.ugvComprobantes.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Appearance4.BackColor = System.Drawing.SystemColors.ControlLightLight
        Appearance4.BackColor2 = System.Drawing.SystemColors.Control
        Appearance4.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance4.ForeColor = System.Drawing.SystemColors.GrayText
        Me.ugvComprobantes.DisplayLayout.GroupByBox.PromptAppearance = Appearance4
        Me.ugvComprobantes.DisplayLayout.MaxColScrollRegions = 1
        Me.ugvComprobantes.DisplayLayout.MaxRowScrollRegions = 1
        Appearance5.BackColor = System.Drawing.SystemColors.Window
        Appearance5.ForeColor = System.Drawing.SystemColors.ControlText
        Me.ugvComprobantes.DisplayLayout.Override.ActiveCellAppearance = Appearance5
        Appearance6.BackColor = System.Drawing.SystemColors.Highlight
        Appearance6.ForeColor = System.Drawing.SystemColors.HighlightText
        Me.ugvComprobantes.DisplayLayout.Override.ActiveRowAppearance = Appearance6
        Me.ugvComprobantes.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted
        Me.ugvComprobantes.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted
        Appearance7.BackColor = System.Drawing.SystemColors.Window
        Me.ugvComprobantes.DisplayLayout.Override.CardAreaAppearance = Appearance7
        Appearance8.BorderColor = System.Drawing.Color.Silver
        Appearance8.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter
        Me.ugvComprobantes.DisplayLayout.Override.CellAppearance = Appearance8
        Me.ugvComprobantes.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText
        Me.ugvComprobantes.DisplayLayout.Override.CellPadding = 0
        Appearance9.BackColor = System.Drawing.SystemColors.Control
        Appearance9.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance9.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element
        Appearance9.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance9.BorderColor = System.Drawing.SystemColors.Window
        Me.ugvComprobantes.DisplayLayout.Override.GroupByRowAppearance = Appearance9
        Appearance10.TextHAlignAsString = "Left"
        Me.ugvComprobantes.DisplayLayout.Override.HeaderAppearance = Appearance10
        Me.ugvComprobantes.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
        Me.ugvComprobantes.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand
        Appearance11.BackColor = System.Drawing.SystemColors.Window
        Appearance11.BorderColor = System.Drawing.Color.Silver
        Me.ugvComprobantes.DisplayLayout.Override.RowAppearance = Appearance11
        Me.ugvComprobantes.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[False]
        Me.ugvComprobantes.DisplayLayout.Override.SelectTypeRow = Infragistics.Win.UltraWinGrid.SelectType.Extended
        Appearance12.BackColor = System.Drawing.SystemColors.ControlLight
        Me.ugvComprobantes.DisplayLayout.Override.TemplateAddRowAppearance = Appearance12
        Me.ugvComprobantes.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill
        Me.ugvComprobantes.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate
        Me.ugvComprobantes.Location = New System.Drawing.Point(12, 176)
        Me.ugvComprobantes.Name = "ugvComprobantes"
        Me.ugvComprobantes.Size = New System.Drawing.Size(759, 310)
        Me.ugvComprobantes.TabIndex = 1
        '
        'grbDatosNuevos
        '
        Me.grbDatosNuevos.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grbDatosNuevos.Controls.Add(Me.lblSucursal)
        Me.grbDatosNuevos.Controls.Add(Me.cmbSucursalNueva)
        Me.grbDatosNuevos.Controls.Add(Me.txtNumeroDestino)
        Me.grbDatosNuevos.Controls.Add(Me.chbNumeroDestino)
        Me.grbDatosNuevos.Controls.Add(Me.dtpNuevaFecha)
        Me.grbDatosNuevos.Controls.Add(Me.chbUtilizaFechaCompAnterior)
        Me.grbDatosNuevos.Controls.Add(Me.cmbCajas)
        Me.grbDatosNuevos.Controls.Add(Me.lblCaja)
        Me.grbDatosNuevos.Controls.Add(Me.btnCopiar)
        Me.grbDatosNuevos.Controls.Add(Me.lblTipoComprobanteDestino)
        Me.grbDatosNuevos.Controls.Add(Me.cmbTiposComprobantesDestino)
        Me.grbDatosNuevos.Controls.Add(Me.chbEliminarOrigen)
        Me.grbDatosNuevos.Location = New System.Drawing.Point(777, 152)
        Me.grbDatosNuevos.Name = "grbDatosNuevos"
        Me.grbDatosNuevos.Size = New System.Drawing.Size(195, 334)
        Me.grbDatosNuevos.TabIndex = 2
        Me.grbDatosNuevos.TabStop = False
        Me.grbDatosNuevos.Text = "Datos Nuevo Comprobante"
        '
        'lblSucursal
        '
        Me.lblSucursal.AutoSize = True
        Me.lblSucursal.LabelAsoc = Nothing
        Me.lblSucursal.Location = New System.Drawing.Point(6, 24)
        Me.lblSucursal.Name = "lblSucursal"
        Me.lblSucursal.Size = New System.Drawing.Size(83, 13)
        Me.lblSucursal.TabIndex = 0
        Me.lblSucursal.Text = "Sucursal Nueva"
        '
        'cmbSucursalNueva
        '
        Me.cmbSucursalNueva.BindearPropiedadControl = Nothing
        Me.cmbSucursalNueva.BindearPropiedadEntidad = Nothing
        Me.cmbSucursalNueva.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbSucursalNueva.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.cmbSucursalNueva.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbSucursalNueva.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbSucursalNueva.FormattingEnabled = True
        Me.cmbSucursalNueva.IsPK = False
        Me.cmbSucursalNueva.IsRequired = False
        Me.cmbSucursalNueva.ItemHeight = 13
        Me.cmbSucursalNueva.Key = Nothing
        Me.cmbSucursalNueva.LabelAsoc = Me.lblSucursal
        Me.cmbSucursalNueva.Location = New System.Drawing.Point(6, 40)
        Me.cmbSucursalNueva.Name = "cmbSucursalNueva"
        Me.cmbSucursalNueva.Size = New System.Drawing.Size(158, 21)
        Me.cmbSucursalNueva.TabIndex = 1
        '
        'txtNumeroDestino
        '
        Me.txtNumeroDestino.BindearPropiedadControl = Nothing
        Me.txtNumeroDestino.BindearPropiedadEntidad = Nothing
        Me.txtNumeroDestino.Enabled = False
        Me.txtNumeroDestino.ForeColorFocus = System.Drawing.Color.Red
        Me.txtNumeroDestino.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtNumeroDestino.Formato = "##0"
        Me.txtNumeroDestino.IsDecimal = False
        Me.txtNumeroDestino.IsNumber = True
        Me.txtNumeroDestino.IsPK = False
        Me.txtNumeroDestino.IsRequired = False
        Me.txtNumeroDestino.Key = ""
        Me.txtNumeroDestino.LabelAsoc = Nothing
        Me.txtNumeroDestino.Location = New System.Drawing.Point(108, 107)
        Me.txtNumeroDestino.MaxLength = 8
        Me.txtNumeroDestino.Name = "txtNumeroDestino"
        Me.txtNumeroDestino.Size = New System.Drawing.Size(56, 20)
        Me.txtNumeroDestino.TabIndex = 5
        Me.txtNumeroDestino.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'chbNumeroDestino
        '
        Me.chbNumeroDestino.AutoSize = True
        Me.chbNumeroDestino.BindearPropiedadControl = Nothing
        Me.chbNumeroDestino.BindearPropiedadEntidad = Nothing
        Me.chbNumeroDestino.ForeColorFocus = System.Drawing.Color.Red
        Me.chbNumeroDestino.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbNumeroDestino.IsPK = False
        Me.chbNumeroDestino.IsRequired = False
        Me.chbNumeroDestino.Key = Nothing
        Me.chbNumeroDestino.LabelAsoc = Nothing
        Me.chbNumeroDestino.Location = New System.Drawing.Point(6, 109)
        Me.chbNumeroDestino.Name = "chbNumeroDestino"
        Me.chbNumeroDestino.Size = New System.Drawing.Size(98, 17)
        Me.chbNumeroDestino.TabIndex = 4
        Me.chbNumeroDestino.Text = "Número Nuevo"
        Me.chbNumeroDestino.UseVisualStyleBackColor = True
        '
        'dtpNuevaFecha
        '
        Me.dtpNuevaFecha.BindearPropiedadControl = Nothing
        Me.dtpNuevaFecha.BindearPropiedadEntidad = Nothing
        Me.dtpNuevaFecha.CustomFormat = "dd/MM/yyyy HH:mm"
        Me.dtpNuevaFecha.Enabled = False
        Me.dtpNuevaFecha.ForeColorFocus = System.Drawing.Color.Red
        Me.dtpNuevaFecha.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.dtpNuevaFecha.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpNuevaFecha.IsPK = False
        Me.dtpNuevaFecha.IsRequired = False
        Me.dtpNuevaFecha.Key = ""
        Me.dtpNuevaFecha.LabelAsoc = Nothing
        Me.dtpNuevaFecha.Location = New System.Drawing.Point(24, 284)
        Me.dtpNuevaFecha.Name = "dtpNuevaFecha"
        Me.dtpNuevaFecha.Size = New System.Drawing.Size(125, 20)
        Me.dtpNuevaFecha.TabIndex = 11
        '
        'chbUtilizaFechaCompAnterior
        '
        Me.chbUtilizaFechaCompAnterior.AutoSize = True
        Me.chbUtilizaFechaCompAnterior.Checked = True
        Me.chbUtilizaFechaCompAnterior.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chbUtilizaFechaCompAnterior.Location = New System.Drawing.Point(6, 261)
        Me.chbUtilizaFechaCompAnterior.Name = "chbUtilizaFechaCompAnterior"
        Me.chbUtilizaFechaCompAnterior.Size = New System.Drawing.Size(192, 17)
        Me.chbUtilizaFechaCompAnterior.TabIndex = 10
        Me.chbUtilizaFechaCompAnterior.Text = "Utiliza Fecha Comprobante Anterior"
        Me.chbUtilizaFechaCompAnterior.UseVisualStyleBackColor = True
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
        Me.cmbCajas.Location = New System.Drawing.Point(6, 150)
        Me.cmbCajas.Name = "cmbCajas"
        Me.cmbCajas.Size = New System.Drawing.Size(158, 21)
        Me.cmbCajas.TabIndex = 7
        Me.cmbCajas.TabStop = False
        '
        'lblCaja
        '
        Me.lblCaja.AutoSize = True
        Me.lblCaja.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblCaja.LabelAsoc = Nothing
        Me.lblCaja.Location = New System.Drawing.Point(6, 134)
        Me.lblCaja.Name = "lblCaja"
        Me.lblCaja.Size = New System.Drawing.Size(28, 13)
        Me.lblCaja.TabIndex = 6
        Me.lblCaja.Text = "Caja"
        '
        'btnCopiar
        '
        Me.btnCopiar.Image = CType(resources.GetObject("btnCopiar.Image"), System.Drawing.Image)
        Me.btnCopiar.Location = New System.Drawing.Point(6, 182)
        Me.btnCopiar.Name = "btnCopiar"
        Me.btnCopiar.Size = New System.Drawing.Size(168, 37)
        Me.btnCopiar.TabIndex = 8
        Me.btnCopiar.Text = "&Copiar Comprobante (F4)"
        Me.btnCopiar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnCopiar.UseVisualStyleBackColor = True
        '
        'lblTipoComprobanteDestino
        '
        Me.lblTipoComprobanteDestino.AutoSize = True
        Me.lblTipoComprobanteDestino.LabelAsoc = Nothing
        Me.lblTipoComprobanteDestino.Location = New System.Drawing.Point(6, 64)
        Me.lblTipoComprobanteDestino.Name = "lblTipoComprobanteDestino"
        Me.lblTipoComprobanteDestino.Size = New System.Drawing.Size(129, 13)
        Me.lblTipoComprobanteDestino.TabIndex = 2
        Me.lblTipoComprobanteDestino.Text = "Tipo Comprobante Nuevo"
        '
        'cmbTiposComprobantesDestino
        '
        Me.cmbTiposComprobantesDestino.BindearPropiedadControl = Nothing
        Me.cmbTiposComprobantesDestino.BindearPropiedadEntidad = Nothing
        Me.cmbTiposComprobantesDestino.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbTiposComprobantesDestino.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.cmbTiposComprobantesDestino.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbTiposComprobantesDestino.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbTiposComprobantesDestino.FormattingEnabled = True
        Me.cmbTiposComprobantesDestino.IsPK = False
        Me.cmbTiposComprobantesDestino.IsRequired = False
        Me.cmbTiposComprobantesDestino.ItemHeight = 13
        Me.cmbTiposComprobantesDestino.Key = Nothing
        Me.cmbTiposComprobantesDestino.LabelAsoc = Me.lblTipoComprobanteDestino
        Me.cmbTiposComprobantesDestino.Location = New System.Drawing.Point(6, 80)
        Me.cmbTiposComprobantesDestino.Name = "cmbTiposComprobantesDestino"
        Me.cmbTiposComprobantesDestino.Size = New System.Drawing.Size(158, 21)
        Me.cmbTiposComprobantesDestino.TabIndex = 3
        '
        'chbEliminarOrigen
        '
        Me.chbEliminarOrigen.AutoSize = True
        Me.chbEliminarOrigen.Checked = True
        Me.chbEliminarOrigen.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chbEliminarOrigen.Location = New System.Drawing.Point(6, 238)
        Me.chbEliminarOrigen.Name = "chbEliminarOrigen"
        Me.chbEliminarOrigen.Size = New System.Drawing.Size(167, 17)
        Me.chbEliminarOrigen.TabIndex = 9
        Me.chbEliminarOrigen.Text = "Eliminar Comprobante Anterior"
        Me.chbEliminarOrigen.UseVisualStyleBackColor = True
        '
        'CopiarComprobantes
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(984, 511)
        Me.Controls.Add(Me.chbTodos)
        Me.Controls.Add(Me.grbDatosNuevos)
        Me.Controls.Add(Me.ugvComprobantes)
        Me.Controls.Add(Me.grbDetalle)
        Me.Controls.Add(Me.stsStado)
        Me.Controls.Add(Me.tstBarra)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "CopiarComprobantes"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Reemplazar / Copiar Comprobantes"
        Me.tstBarra.ResumeLayout(False)
        Me.tstBarra.PerformLayout()
        Me.stsStado.ResumeLayout(False)
        Me.stsStado.PerformLayout()
        Me.grbDetalle.ResumeLayout(False)
        Me.grbDetalle.PerformLayout()
        CType(Me.ugvComprobantes, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grbDatosNuevos.ResumeLayout(False)
        Me.grbDatosNuevos.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents tstBarra As System.Windows.Forms.ToolStrip
   Public WithEvents tsbRefrescar As System.Windows.Forms.ToolStripButton
   Friend WithEvents tsbCerrar As System.Windows.Forms.ToolStripButton
   Protected Friend WithEvents stsStado As System.Windows.Forms.StatusStrip
   Protected Friend WithEvents tssInfo As System.Windows.Forms.ToolStripStatusLabel
   Protected Friend WithEvents tspBarra As System.Windows.Forms.ToolStripProgressBar
   Protected WithEvents tssRegistros As System.Windows.Forms.ToolStripStatusLabel
   Friend WithEvents grbDetalle As System.Windows.Forms.GroupBox
   Friend WithEvents chkMesCompleto As Eniac.Controles.CheckBox
   Friend WithEvents btnBuscar As Eniac.Controles.Button
   Friend WithEvents dtpHasta As Eniac.Controles.DateTimePicker
   Friend WithEvents lblHasta As Eniac.Controles.Label
   Friend WithEvents dtpDesde As Eniac.Controles.DateTimePicker
   Friend WithEvents lblDesde As Eniac.Controles.Label
   Friend WithEvents ugvComprobantes As Infragistics.Win.UltraWinGrid.UltraGrid
   Friend WithEvents grbDatosNuevos As System.Windows.Forms.GroupBox
   Friend WithEvents chbEliminarOrigen As System.Windows.Forms.CheckBox
   Friend WithEvents lblTipoComprobanteDestino As Eniac.Controles.Label
   Friend WithEvents cmbTiposComprobantesDestino As Eniac.Controles.ComboBox
   Friend WithEvents btnCopiar As Eniac.Controles.Button
   Friend WithEvents cmbCajas As Eniac.Controles.ComboBox
   Friend WithEvents lblCaja As Eniac.Controles.Label
   Friend WithEvents chbTodos As Eniac.Controles.CheckBox
   Friend WithEvents chbLetra As Eniac.Controles.CheckBox
   Friend WithEvents chbEmisor As Eniac.Controles.CheckBox
   Friend WithEvents cmbEmisor As Eniac.Controles.ComboBox
   Friend WithEvents cboLetra As Eniac.Controles.ComboBox
   Friend WithEvents txtNumero As Eniac.Controles.TextBox
   Friend WithEvents cmbTiposComprobantesOrigen As Eniac.Controles.ComboBox
   Friend WithEvents chbNumero As Eniac.Controles.CheckBox
   Friend WithEvents bscCodigoCliente As Eniac.Controles.Buscador
   Friend WithEvents lblCodigoCliente As Eniac.Controles.Label
   Friend WithEvents bscCliente As Eniac.Controles.Buscador
   Friend WithEvents lblNombre As Eniac.Controles.Label
   Friend WithEvents chbCliente As Eniac.Controles.CheckBox
   Friend WithEvents txtNroReparto As Eniac.Controles.TextBox
   Friend WithEvents chbNumeroReparto As Eniac.Controles.CheckBox
   Friend WithEvents lblTipoComprobanteOrigen As Eniac.Controles.Label
   Friend WithEvents cmbCajasOrigen As Eniac.Controles.ComboBox
   Friend WithEvents Label1 As Eniac.Controles.Label
   Friend WithEvents chbUtilizaFechaCompAnterior As System.Windows.Forms.CheckBox
   Friend WithEvents dtpNuevaFecha As Eniac.Controles.DateTimePicker
   Friend WithEvents txtUsuario As Eniac.Controles.TextBox
   Friend WithEvents chbUsuario As Eniac.Controles.CheckBox
   Friend WithEvents txtNumeroDestino As Eniac.Controles.TextBox
   Friend WithEvents chbNumeroDestino As Eniac.Controles.CheckBox
   Friend WithEvents lblSucursal As Eniac.Controles.Label
   Friend WithEvents cmbSucursalNueva As Eniac.Controles.ComboBox
End Class
