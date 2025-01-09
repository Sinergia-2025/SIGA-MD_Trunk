<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class DividirPedidoV2
   Inherits Eniac.Win.BaseForm

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
      Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(DividirPedidoV2))
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
      Me.tsbGrabar = New System.Windows.Forms.ToolStripButton()
      Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
      Me.tsbCerrar = New System.Windows.Forms.ToolStripButton()
      Me.txtCentroEmisor = New Eniac.Controles.TextBox()
      Me.txtNumeroComprobante = New Eniac.Controles.TextBox()
      Me.txtIdTipoComprobante = New Eniac.Controles.TextBox()
      Me.Label2 = New System.Windows.Forms.Label()
      Me.txtIdSucursal = New Eniac.Controles.TextBox()
      Me.txtNombreSucursal = New Eniac.Controles.TextBox()
      Me.cmbTipoComprNuevo = New Eniac.Controles.ComboBox()
      Me.Label3 = New System.Windows.Forms.Label()
      Me.Label4 = New System.Windows.Forms.Label()
      Me.cmbSucursalNueva = New Eniac.Controles.ComboBox()
      Me.ugDetalle = New Infragistics.Win.UltraWinGrid.UltraGrid()
      Me.Label5 = New System.Windows.Forms.Label()
      Me.txtDecimales = New Eniac.Controles.TextBox()
      Me.GroupBox1 = New System.Windows.Forms.GroupBox()
      Me.btnDividir = New System.Windows.Forms.Button()
      Me.txtPorcDestino = New Eniac.Controles.TextBox()
      Me.Label7 = New System.Windows.Forms.Label()
      Me.txtPorcOrigen = New Eniac.Controles.TextBox()
      Me.Label6 = New System.Windows.Forms.Label()
      Me.Label8 = New System.Windows.Forms.Label()
      Me.txtcompActual = New Eniac.Controles.TextBox()
      Me.txtLetra = New Eniac.Controles.TextBox()
      Me.tstBarra.SuspendLayout()
      CType(Me.ugDetalle, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.GroupBox1.SuspendLayout()
      Me.SuspendLayout()
      '
      'tstBarra
      '
      Me.tstBarra.AllowItemReorder = True
      Me.tstBarra.ImageScalingSize = New System.Drawing.Size(22, 22)
      Me.tstBarra.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsbGrabar, Me.ToolStripSeparator2, Me.tsbCerrar})
      Me.tstBarra.Location = New System.Drawing.Point(0, 0)
      Me.tstBarra.Name = "tstBarra"
      Me.tstBarra.Size = New System.Drawing.Size(884, 29)
      Me.tstBarra.TabIndex = 76
      Me.tstBarra.Text = "toolStrip1"
      '
      'tsbGrabar
      '
      Me.tsbGrabar.Image = Global.Eniac.Win.My.Resources.Resources.diskette_32
      Me.tsbGrabar.ImageTransparentColor = System.Drawing.Color.Magenta
      Me.tsbGrabar.Name = "tsbGrabar"
      Me.tsbGrabar.Size = New System.Drawing.Size(68, 26)
      Me.tsbGrabar.Text = "&Grabar"
      Me.tsbGrabar.ToolTipText = "Cerrar el formulario"
      '
      'ToolStripSeparator2
      '
      Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
      Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 29)
      '
      'tsbCerrar
      '
      Me.tsbCerrar.Image = CType(resources.GetObject("tsbCerrar.Image"), System.Drawing.Image)
      Me.tsbCerrar.ImageTransparentColor = System.Drawing.Color.Magenta
      Me.tsbCerrar.Name = "tsbCerrar"
      Me.tsbCerrar.Size = New System.Drawing.Size(65, 26)
      Me.tsbCerrar.Text = "&Cerrar"
      Me.tsbCerrar.ToolTipText = "Cerrar el formulario"
      '
      'txtCentroEmisor
      '
      Me.txtCentroEmisor.BindearPropiedadControl = Nothing
      Me.txtCentroEmisor.BindearPropiedadEntidad = Nothing
      Me.txtCentroEmisor.Enabled = False
      Me.txtCentroEmisor.ForeColorFocus = System.Drawing.Color.Red
      Me.txtCentroEmisor.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtCentroEmisor.Formato = ""
      Me.txtCentroEmisor.IsDecimal = False
      Me.txtCentroEmisor.IsNumber = False
      Me.txtCentroEmisor.IsPK = False
      Me.txtCentroEmisor.IsRequired = False
      Me.txtCentroEmisor.Key = ""
      Me.txtCentroEmisor.LabelAsoc = Nothing
      Me.txtCentroEmisor.Location = New System.Drawing.Point(306, 42)
      Me.txtCentroEmisor.Name = "txtCentroEmisor"
      Me.txtCentroEmisor.Size = New System.Drawing.Size(44, 20)
      Me.txtCentroEmisor.TabIndex = 80
      Me.txtCentroEmisor.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
      '
      'txtNumeroComprobante
      '
      Me.txtNumeroComprobante.BindearPropiedadControl = Nothing
      Me.txtNumeroComprobante.BindearPropiedadEntidad = Nothing
      Me.txtNumeroComprobante.Enabled = False
      Me.txtNumeroComprobante.ForeColorFocus = System.Drawing.Color.Red
      Me.txtNumeroComprobante.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtNumeroComprobante.Formato = ""
      Me.txtNumeroComprobante.IsDecimal = False
      Me.txtNumeroComprobante.IsNumber = False
      Me.txtNumeroComprobante.IsPK = False
      Me.txtNumeroComprobante.IsRequired = False
      Me.txtNumeroComprobante.Key = ""
      Me.txtNumeroComprobante.LabelAsoc = Nothing
      Me.txtNumeroComprobante.Location = New System.Drawing.Point(356, 42)
      Me.txtNumeroComprobante.Name = "txtNumeroComprobante"
      Me.txtNumeroComprobante.Size = New System.Drawing.Size(87, 20)
      Me.txtNumeroComprobante.TabIndex = 79
      Me.txtNumeroComprobante.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'txtIdTipoComprobante
      '
      Me.txtIdTipoComprobante.BindearPropiedadControl = Nothing
      Me.txtIdTipoComprobante.BindearPropiedadEntidad = Nothing
      Me.txtIdTipoComprobante.Enabled = False
      Me.txtIdTipoComprobante.ForeColorFocus = System.Drawing.Color.Red
      Me.txtIdTipoComprobante.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtIdTipoComprobante.Formato = ""
      Me.txtIdTipoComprobante.IsDecimal = False
      Me.txtIdTipoComprobante.IsNumber = False
      Me.txtIdTipoComprobante.IsPK = False
      Me.txtIdTipoComprobante.IsRequired = False
      Me.txtIdTipoComprobante.Key = ""
      Me.txtIdTipoComprobante.LabelAsoc = Nothing
      Me.txtIdTipoComprobante.Location = New System.Drawing.Point(155, 42)
      Me.txtIdTipoComprobante.Name = "txtIdTipoComprobante"
      Me.txtIdTipoComprobante.Size = New System.Drawing.Size(125, 20)
      Me.txtIdTipoComprobante.TabIndex = 78
      '
      'Label2
      '
      Me.Label2.AutoSize = True
      Me.Label2.Location = New System.Drawing.Point(68, 97)
      Me.Label2.Name = "Label2"
      Me.Label2.Size = New System.Drawing.Size(81, 13)
      Me.Label2.TabIndex = 77
      Me.Label2.Text = "Sucursal Actual"
      '
      'txtIdSucursal
      '
      Me.txtIdSucursal.BindearPropiedadControl = Nothing
      Me.txtIdSucursal.BindearPropiedadEntidad = Nothing
      Me.txtIdSucursal.Enabled = False
      Me.txtIdSucursal.ForeColorFocus = System.Drawing.Color.Red
      Me.txtIdSucursal.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtIdSucursal.Formato = ""
      Me.txtIdSucursal.IsDecimal = False
      Me.txtIdSucursal.IsNumber = False
      Me.txtIdSucursal.IsPK = False
      Me.txtIdSucursal.IsRequired = False
      Me.txtIdSucursal.Key = ""
      Me.txtIdSucursal.LabelAsoc = Nothing
      Me.txtIdSucursal.Location = New System.Drawing.Point(155, 94)
      Me.txtIdSucursal.Name = "txtIdSucursal"
      Me.txtIdSucursal.Size = New System.Drawing.Size(37, 20)
      Me.txtIdSucursal.TabIndex = 78
      '
      'txtNombreSucursal
      '
      Me.txtNombreSucursal.BindearPropiedadControl = Nothing
      Me.txtNombreSucursal.BindearPropiedadEntidad = Nothing
      Me.txtNombreSucursal.Enabled = False
      Me.txtNombreSucursal.ForeColorFocus = System.Drawing.Color.Red
      Me.txtNombreSucursal.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtNombreSucursal.Formato = ""
      Me.txtNombreSucursal.IsDecimal = False
      Me.txtNombreSucursal.IsNumber = False
      Me.txtNombreSucursal.IsPK = False
      Me.txtNombreSucursal.IsRequired = False
      Me.txtNombreSucursal.Key = ""
      Me.txtNombreSucursal.LabelAsoc = Nothing
      Me.txtNombreSucursal.Location = New System.Drawing.Point(198, 94)
      Me.txtNombreSucursal.Name = "txtNombreSucursal"
      Me.txtNombreSucursal.Size = New System.Drawing.Size(245, 20)
      Me.txtNombreSucursal.TabIndex = 78
      '
      'cmbTipoComprNuevo
      '
      Me.cmbTipoComprNuevo.BindearPropiedadControl = "SelectedValue"
      Me.cmbTipoComprNuevo.BindearPropiedadEntidad = "ventas.idformaspago"
      Me.cmbTipoComprNuevo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cmbTipoComprNuevo.ForeColorFocus = System.Drawing.Color.Red
      Me.cmbTipoComprNuevo.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.cmbTipoComprNuevo.FormattingEnabled = True
      Me.cmbTipoComprNuevo.IsPK = False
      Me.cmbTipoComprNuevo.IsRequired = True
      Me.cmbTipoComprNuevo.Key = Nothing
      Me.cmbTipoComprNuevo.LabelAsoc = Nothing
      Me.cmbTipoComprNuevo.Location = New System.Drawing.Point(641, 68)
      Me.cmbTipoComprNuevo.Name = "cmbTipoComprNuevo"
      Me.cmbTipoComprNuevo.Size = New System.Drawing.Size(181, 21)
      Me.cmbTipoComprNuevo.TabIndex = 82
      '
      'Label3
      '
      Me.Label3.AutoSize = True
      Me.Label3.Location = New System.Drawing.Point(506, 71)
      Me.Label3.Name = "Label3"
      Me.Label3.Size = New System.Drawing.Size(129, 13)
      Me.Label3.TabIndex = 81
      Me.Label3.Text = "Tipo Comprobante Nuevo"
      '
      'Label4
      '
      Me.Label4.AutoSize = True
      Me.Label4.Location = New System.Drawing.Point(552, 97)
      Me.Label4.Name = "Label4"
      Me.Label4.Size = New System.Drawing.Size(83, 13)
      Me.Label4.TabIndex = 81
      Me.Label4.Text = "Sucursal Nueva"
      '
      'cmbSucursalNueva
      '
      Me.cmbSucursalNueva.BindearPropiedadControl = "SelectedValue"
      Me.cmbSucursalNueva.BindearPropiedadEntidad = "ventas.idformaspago"
      Me.cmbSucursalNueva.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cmbSucursalNueva.ForeColorFocus = System.Drawing.Color.Red
      Me.cmbSucursalNueva.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.cmbSucursalNueva.FormattingEnabled = True
      Me.cmbSucursalNueva.IsPK = False
      Me.cmbSucursalNueva.IsRequired = True
      Me.cmbSucursalNueva.Key = Nothing
      Me.cmbSucursalNueva.LabelAsoc = Nothing
      Me.cmbSucursalNueva.Location = New System.Drawing.Point(641, 94)
      Me.cmbSucursalNueva.Name = "cmbSucursalNueva"
      Me.cmbSucursalNueva.Size = New System.Drawing.Size(181, 21)
      Me.cmbSucursalNueva.TabIndex = 82
      '
      'ugDetalle
      '
      Appearance1.BackColor = System.Drawing.SystemColors.Window
      Appearance1.BorderColor = System.Drawing.SystemColors.InactiveCaption
      Me.ugDetalle.DisplayLayout.Appearance = Appearance1
      Me.ugDetalle.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
      Me.ugDetalle.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.[False]
      Appearance2.BackColor = System.Drawing.SystemColors.ActiveBorder
      Appearance2.BackColor2 = System.Drawing.SystemColors.ControlDark
      Appearance2.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
      Appearance2.BorderColor = System.Drawing.SystemColors.Window
      Me.ugDetalle.DisplayLayout.GroupByBox.Appearance = Appearance2
      Appearance3.ForeColor = System.Drawing.SystemColors.GrayText
      Me.ugDetalle.DisplayLayout.GroupByBox.BandLabelAppearance = Appearance3
      Me.ugDetalle.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
      Me.ugDetalle.DisplayLayout.GroupByBox.Hidden = True
      Appearance4.BackColor = System.Drawing.SystemColors.ControlLightLight
      Appearance4.BackColor2 = System.Drawing.SystemColors.Control
      Appearance4.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
      Appearance4.ForeColor = System.Drawing.SystemColors.GrayText
      Me.ugDetalle.DisplayLayout.GroupByBox.PromptAppearance = Appearance4
      Me.ugDetalle.DisplayLayout.MaxColScrollRegions = 1
      Me.ugDetalle.DisplayLayout.MaxRowScrollRegions = 1
      Appearance5.BackColor = System.Drawing.SystemColors.Window
      Appearance5.ForeColor = System.Drawing.SystemColors.ControlText
      Me.ugDetalle.DisplayLayout.Override.ActiveCellAppearance = Appearance5
      Appearance6.BackColor = System.Drawing.SystemColors.Highlight
      Appearance6.ForeColor = System.Drawing.SystemColors.HighlightText
      Me.ugDetalle.DisplayLayout.Override.ActiveRowAppearance = Appearance6
      Me.ugDetalle.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted
      Me.ugDetalle.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted
      Appearance7.BackColor = System.Drawing.SystemColors.Window
      Me.ugDetalle.DisplayLayout.Override.CardAreaAppearance = Appearance7
      Appearance8.BorderColor = System.Drawing.Color.Silver
      Appearance8.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter
      Me.ugDetalle.DisplayLayout.Override.CellAppearance = Appearance8
      Me.ugDetalle.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText
      Me.ugDetalle.DisplayLayout.Override.CellPadding = 0
      Appearance9.BackColor = System.Drawing.SystemColors.Control
      Appearance9.BackColor2 = System.Drawing.SystemColors.ControlDark
      Appearance9.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element
      Appearance9.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
      Appearance9.BorderColor = System.Drawing.SystemColors.Window
      Me.ugDetalle.DisplayLayout.Override.GroupByRowAppearance = Appearance9
      Appearance10.TextHAlignAsString = "Left"
      Me.ugDetalle.DisplayLayout.Override.HeaderAppearance = Appearance10
      Me.ugDetalle.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
      Me.ugDetalle.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand
      Appearance11.BackColor = System.Drawing.SystemColors.Window
      Appearance11.BorderColor = System.Drawing.Color.Silver
      Me.ugDetalle.DisplayLayout.Override.RowAppearance = Appearance11
      Me.ugDetalle.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[False]
      Appearance12.BackColor = System.Drawing.SystemColors.ControlLight
      Me.ugDetalle.DisplayLayout.Override.TemplateAddRowAppearance = Appearance12
      Me.ugDetalle.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill
      Me.ugDetalle.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate
      Me.ugDetalle.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy
      Me.ugDetalle.Location = New System.Drawing.Point(12, 196)
      Me.ugDetalle.Name = "ugDetalle"
      Me.ugDetalle.Size = New System.Drawing.Size(860, 344)
      Me.ugDetalle.TabIndex = 83
      Me.ugDetalle.Text = "UltraGrid1"
      '
      'Label5
      '
      Me.Label5.AutoSize = True
      Me.Label5.Location = New System.Drawing.Point(349, 163)
      Me.Label5.Name = "Label5"
      Me.Label5.Size = New System.Drawing.Size(99, 13)
      Me.Label5.TabIndex = 77
      Me.Label5.Text = "Cantidad decimales"
      '
      'txtDecimales
      '
      Me.txtDecimales.BindearPropiedadControl = Nothing
      Me.txtDecimales.BindearPropiedadEntidad = Nothing
      Me.txtDecimales.ForeColorFocus = System.Drawing.Color.Red
      Me.txtDecimales.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtDecimales.Formato = ""
      Me.txtDecimales.IsDecimal = False
      Me.txtDecimales.IsNumber = True
      Me.txtDecimales.IsPK = False
      Me.txtDecimales.IsRequired = False
      Me.txtDecimales.Key = ""
      Me.txtDecimales.LabelAsoc = Nothing
      Me.txtDecimales.Location = New System.Drawing.Point(454, 160)
      Me.txtDecimales.Name = "txtDecimales"
      Me.txtDecimales.Size = New System.Drawing.Size(37, 20)
      Me.txtDecimales.TabIndex = 78
      Me.txtDecimales.Text = "0"
      '
      'GroupBox1
      '
      Me.GroupBox1.Controls.Add(Me.btnDividir)
      Me.GroupBox1.Controls.Add(Me.txtPorcDestino)
      Me.GroupBox1.Controls.Add(Me.Label7)
      Me.GroupBox1.Controls.Add(Me.txtPorcOrigen)
      Me.GroupBox1.Controls.Add(Me.Label6)
      Me.GroupBox1.Location = New System.Drawing.Point(529, 142)
      Me.GroupBox1.Name = "GroupBox1"
      Me.GroupBox1.Size = New System.Drawing.Size(343, 48)
      Me.GroupBox1.TabIndex = 84
      Me.GroupBox1.TabStop = False
      Me.GroupBox1.Text = "División automática"
      '
      'btnDividir
      '
      Me.btnDividir.Location = New System.Drawing.Point(257, 16)
      Me.btnDividir.Name = "btnDividir"
      Me.btnDividir.Size = New System.Drawing.Size(75, 23)
      Me.btnDividir.TabIndex = 79
      Me.btnDividir.Text = "Dividir"
      Me.btnDividir.UseVisualStyleBackColor = True
      '
      'txtPorcDestino
      '
      Me.txtPorcDestino.BindearPropiedadControl = Nothing
      Me.txtPorcDestino.BindearPropiedadEntidad = Nothing
      Me.txtPorcDestino.ForeColorFocus = System.Drawing.Color.Red
      Me.txtPorcDestino.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtPorcDestino.Formato = ""
      Me.txtPorcDestino.IsDecimal = True
      Me.txtPorcDestino.IsNumber = True
      Me.txtPorcDestino.IsPK = False
      Me.txtPorcDestino.IsRequired = False
      Me.txtPorcDestino.Key = ""
      Me.txtPorcDestino.LabelAsoc = Nothing
      Me.txtPorcDestino.Location = New System.Drawing.Point(174, 19)
      Me.txtPorcDestino.Name = "txtPorcDestino"
      Me.txtPorcDestino.Size = New System.Drawing.Size(37, 20)
      Me.txtPorcDestino.TabIndex = 78
      Me.txtPorcDestino.Text = "50"
      '
      'Label7
      '
      Me.Label7.AutoSize = True
      Me.Label7.Location = New System.Drawing.Point(129, 21)
      Me.Label7.Name = "Label7"
      Me.Label7.Size = New System.Drawing.Size(39, 13)
      Me.Label7.TabIndex = 77
      Me.Label7.Text = "Nuevo"
      '
      'txtPorcOrigen
      '
      Me.txtPorcOrigen.BindearPropiedadControl = Nothing
      Me.txtPorcOrigen.BindearPropiedadEntidad = Nothing
      Me.txtPorcOrigen.ForeColorFocus = System.Drawing.Color.Red
      Me.txtPorcOrigen.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtPorcOrigen.Formato = ""
      Me.txtPorcOrigen.IsDecimal = True
      Me.txtPorcOrigen.IsNumber = True
      Me.txtPorcOrigen.IsPK = False
      Me.txtPorcOrigen.IsRequired = False
      Me.txtPorcOrigen.Key = ""
      Me.txtPorcOrigen.LabelAsoc = Nothing
      Me.txtPorcOrigen.Location = New System.Drawing.Point(58, 18)
      Me.txtPorcOrigen.Name = "txtPorcOrigen"
      Me.txtPorcOrigen.Size = New System.Drawing.Size(37, 20)
      Me.txtPorcOrigen.TabIndex = 78
      Me.txtPorcOrigen.Text = "50"
      '
      'Label6
      '
      Me.Label6.AutoSize = True
      Me.Label6.Location = New System.Drawing.Point(6, 21)
      Me.Label6.Name = "Label6"
      Me.Label6.Size = New System.Drawing.Size(42, 13)
      Me.Label6.TabIndex = 77
      Me.Label6.Text = "Original"
      '
      'Label8
      '
      Me.Label8.AutoSize = True
      Me.Label8.Location = New System.Drawing.Point(22, 70)
      Me.Label8.Name = "Label8"
      Me.Label8.Size = New System.Drawing.Size(127, 13)
      Me.Label8.TabIndex = 85
      Me.Label8.Text = "Tipo Comprobante Actual"
      '
      'txtcompActual
      '
      Me.txtcompActual.BindearPropiedadControl = Nothing
      Me.txtcompActual.BindearPropiedadEntidad = Nothing
      Me.txtcompActual.Enabled = False
      Me.txtcompActual.ForeColorFocus = System.Drawing.Color.Red
      Me.txtcompActual.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtcompActual.Formato = ""
      Me.txtcompActual.IsDecimal = False
      Me.txtcompActual.IsNumber = False
      Me.txtcompActual.IsPK = False
      Me.txtcompActual.IsRequired = False
      Me.txtcompActual.Key = ""
      Me.txtcompActual.LabelAsoc = Nothing
      Me.txtcompActual.Location = New System.Drawing.Point(155, 68)
      Me.txtcompActual.Name = "txtcompActual"
      Me.txtcompActual.Size = New System.Drawing.Size(288, 20)
      Me.txtcompActual.TabIndex = 78
      '
      'txtLetra
      '
      Me.txtLetra.BindearPropiedadControl = Nothing
      Me.txtLetra.BindearPropiedadEntidad = Nothing
      Me.txtLetra.Enabled = False
      Me.txtLetra.ForeColorFocus = System.Drawing.Color.Red
      Me.txtLetra.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtLetra.Formato = ""
      Me.txtLetra.IsDecimal = False
      Me.txtLetra.IsNumber = False
      Me.txtLetra.IsPK = False
      Me.txtLetra.IsRequired = False
      Me.txtLetra.Key = ""
      Me.txtLetra.LabelAsoc = Nothing
      Me.txtLetra.Location = New System.Drawing.Point(286, 42)
      Me.txtLetra.Name = "txtLetra"
      Me.txtLetra.Size = New System.Drawing.Size(14, 20)
      Me.txtLetra.TabIndex = 80
      Me.txtLetra.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
      '
      'DividirPedidoV2
      '
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.ClientSize = New System.Drawing.Size(884, 561)
      Me.Controls.Add(Me.Label8)
      Me.Controls.Add(Me.GroupBox1)
      Me.Controls.Add(Me.ugDetalle)
      Me.Controls.Add(Me.cmbSucursalNueva)
      Me.Controls.Add(Me.Label4)
      Me.Controls.Add(Me.cmbTipoComprNuevo)
      Me.Controls.Add(Me.Label3)
      Me.Controls.Add(Me.txtLetra)
      Me.Controls.Add(Me.txtCentroEmisor)
      Me.Controls.Add(Me.txtNumeroComprobante)
      Me.Controls.Add(Me.txtNombreSucursal)
      Me.Controls.Add(Me.txtDecimales)
      Me.Controls.Add(Me.Label5)
      Me.Controls.Add(Me.txtIdSucursal)
      Me.Controls.Add(Me.Label2)
      Me.Controls.Add(Me.txtcompActual)
      Me.Controls.Add(Me.txtIdTipoComprobante)
      Me.Controls.Add(Me.tstBarra)
      Me.MaximizeBox = False
      Me.MinimizeBox = False
      Me.Name = "DividirPedidoV2"
      Me.ShowInTaskbar = False
      Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
      Me.Text = "Dividir Pedido"
      Me.tstBarra.ResumeLayout(False)
      Me.tstBarra.PerformLayout()
      CType(Me.ugDetalle, System.ComponentModel.ISupportInitialize).EndInit()
      Me.GroupBox1.ResumeLayout(False)
      Me.GroupBox1.PerformLayout()
      Me.ResumeLayout(False)
      Me.PerformLayout()

   End Sub
   Public WithEvents tstBarra As System.Windows.Forms.ToolStrip
   Public WithEvents tsbGrabar As System.Windows.Forms.ToolStripButton
   Private WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
   Public WithEvents tsbCerrar As System.Windows.Forms.ToolStripButton
   Friend WithEvents txtCentroEmisor As Eniac.Controles.TextBox
   Friend WithEvents txtNumeroComprobante As Eniac.Controles.TextBox
   Friend WithEvents txtIdTipoComprobante As Eniac.Controles.TextBox
   Friend WithEvents Label2 As System.Windows.Forms.Label
   Friend WithEvents txtIdSucursal As Eniac.Controles.TextBox
   Friend WithEvents txtNombreSucursal As Eniac.Controles.TextBox
   Friend WithEvents cmbTipoComprNuevo As Eniac.Controles.ComboBox
   Friend WithEvents Label3 As System.Windows.Forms.Label
   Friend WithEvents Label4 As System.Windows.Forms.Label
   Friend WithEvents cmbSucursalNueva As Eniac.Controles.ComboBox
   Friend WithEvents ugDetalle As Infragistics.Win.UltraWinGrid.UltraGrid
   Friend WithEvents Label5 As System.Windows.Forms.Label
   Friend WithEvents txtDecimales As Eniac.Controles.TextBox
   Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
   Friend WithEvents btnDividir As System.Windows.Forms.Button
   Friend WithEvents txtPorcDestino As Eniac.Controles.TextBox
   Friend WithEvents Label7 As System.Windows.Forms.Label
   Friend WithEvents txtPorcOrigen As Eniac.Controles.TextBox
   Friend WithEvents Label6 As System.Windows.Forms.Label
   Friend WithEvents Label8 As System.Windows.Forms.Label
   Friend WithEvents txtcompActual As Eniac.Controles.TextBox
   Friend WithEvents txtLetra As Eniac.Controles.TextBox
End Class
