<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class ComisionesProductoVendedorLista
   Inherits BaseForm

   'Form overrides dispose to clean up the component list.
   <System.Diagnostics.DebuggerNonUserCode()>
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
   <System.Diagnostics.DebuggerStepThrough()>
   Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim Appearance1 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridBand1 As Infragistics.Win.UltraWinGrid.UltraGridBand = New Infragistics.Win.UltraWinGrid.UltraGridBand("Band 0", -1)
        Dim UltraGridColumn12 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdProducto")
        Dim UltraGridColumn13 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreProducto")
        Dim UltraGridColumn14 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Comision")
        Dim Appearance2 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn18 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdEmpleado")
        Dim UltraGridColumn16 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdListaPrecios")
        Dim UltraGridColumn17 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreListaPrecios")
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
        Dim Appearance13 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraDataColumn1 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("IdProducto")
        Dim UltraDataColumn2 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("NombreProducto")
        Dim UltraDataColumn3 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("Comision")
        Dim UltraDataColumn4 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("IdVendedor")
        Dim UltraDataColumn5 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("IdListaPrecios")
        Dim UltraDataColumn6 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("NombreListaPrecios")
        Me.tspFacturacion = New System.Windows.Forms.ToolStrip()
        Me.tsbRefrescar = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsbGrabar = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsbSalir = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.grbCliente = New System.Windows.Forms.GroupBox()
        Me.btnBuscar = New Eniac.Controles.Button()
        Me.lblVendedor = New Eniac.Controles.Label()
        Me.cmbVendedor = New Eniac.Controles.ComboBox()
        Me.lblListasDePrecios = New Eniac.Controles.Label()
        Me.txtPorcentaje = New Eniac.Controles.TextBox()
        Me.lblPorcentaje = New Eniac.Controles.Label()
        Me.ugdProductos = New Infragistics.Win.UltraWinGrid.UltraGrid()
        Me.pnlComision = New System.Windows.Forms.Panel()
        Me.bscProducto = New Eniac.Controles.Buscador2()
        Me.cmbListasDePrecios = New Eniac.Controles.ComboBox()
        Me.Label1 = New Eniac.Controles.Label()
        Me.bscCodigoProducto = New Eniac.Controles.Buscador2()
        Me.btnEliminarProductos = New Eniac.Controles.Button()
        Me.btnInsertarProductos = New Eniac.Controles.Button()
        Me.UltraDataSource1 = New Infragistics.Win.UltraWinDataSource.UltraDataSource(Me.components)
        Me.tspFacturacion.SuspendLayout()
        Me.grbCliente.SuspendLayout()
        CType(Me.ugdProductos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlComision.SuspendLayout()
        CType(Me.UltraDataSource1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'tspFacturacion
        '
        Me.tspFacturacion.ImageScalingSize = New System.Drawing.Size(22, 22)
        Me.tspFacturacion.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsbRefrescar, Me.ToolStripSeparator4, Me.tsbGrabar, Me.ToolStripSeparator1, Me.tsbSalir, Me.ToolStripSeparator3})
        Me.tspFacturacion.Location = New System.Drawing.Point(0, 0)
        Me.tspFacturacion.Name = "tspFacturacion"
        Me.tspFacturacion.Size = New System.Drawing.Size(884, 29)
        Me.tspFacturacion.TabIndex = 2
        Me.tspFacturacion.Text = "ToolStrip1"
        '
        'tsbRefrescar
        '
        Me.tsbRefrescar.Image = Global.Eniac.Win.My.Resources.Resources.refresh_32
        Me.tsbRefrescar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbRefrescar.Name = "tsbRefrescar"
        Me.tsbRefrescar.Size = New System.Drawing.Size(104, 26)
        Me.tsbRefrescar.Text = "&Refrescar (F5)"
        '
        'ToolStripSeparator4
        '
        Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
        Me.ToolStripSeparator4.Size = New System.Drawing.Size(6, 29)
        '
        'tsbGrabar
        '
        Me.tsbGrabar.Enabled = False
        Me.tsbGrabar.Image = Global.Eniac.Win.My.Resources.Resources.disk_blue
        Me.tsbGrabar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbGrabar.Name = "tsbGrabar"
        Me.tsbGrabar.Size = New System.Drawing.Size(91, 26)
        Me.tsbGrabar.Text = "&Grabar (F4)"
        Me.tsbGrabar.ToolTipText = "Imprimir y Grabar (F4)"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 29)
        '
        'tsbSalir
        '
        Me.tsbSalir.Image = Global.Eniac.Win.My.Resources.Resources.close_b_32
        Me.tsbSalir.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbSalir.Name = "tsbSalir"
        Me.tsbSalir.Size = New System.Drawing.Size(65, 26)
        Me.tsbSalir.Text = "&Cerrar"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(6, 29)
        '
        'grbCliente
        '
        Me.grbCliente.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grbCliente.Controls.Add(Me.btnBuscar)
        Me.grbCliente.Controls.Add(Me.lblVendedor)
        Me.grbCliente.Controls.Add(Me.cmbVendedor)
        Me.grbCliente.Location = New System.Drawing.Point(12, 32)
        Me.grbCliente.Name = "grbCliente"
        Me.grbCliente.Size = New System.Drawing.Size(860, 55)
        Me.grbCliente.TabIndex = 0
        Me.grbCliente.TabStop = False
        '
        'btnBuscar
        '
        Me.btnBuscar.Image = Global.Eniac.Win.My.Resources.Resources.view
        Me.btnBuscar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnBuscar.Location = New System.Drawing.Point(362, 10)
        Me.btnBuscar.Name = "btnBuscar"
        Me.btnBuscar.Size = New System.Drawing.Size(89, 40)
        Me.btnBuscar.TabIndex = 2
        Me.btnBuscar.Text = "&Buscar"
        Me.btnBuscar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnBuscar.UseVisualStyleBackColor = True
        '
        'lblVendedor
        '
        Me.lblVendedor.AutoSize = True
        Me.lblVendedor.LabelAsoc = Nothing
        Me.lblVendedor.Location = New System.Drawing.Point(10, 22)
        Me.lblVendedor.Name = "lblVendedor"
        Me.lblVendedor.Size = New System.Drawing.Size(53, 13)
        Me.lblVendedor.TabIndex = 0
        Me.lblVendedor.Text = "Vendedor"
        '
        'cmbVendedor
        '
        Me.cmbVendedor.BindearPropiedadControl = Nothing
        Me.cmbVendedor.BindearPropiedadEntidad = Nothing
        Me.cmbVendedor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbVendedor.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbVendedor.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbVendedor.FormattingEnabled = True
        Me.cmbVendedor.IsPK = False
        Me.cmbVendedor.IsRequired = False
        Me.cmbVendedor.Key = Nothing
        Me.cmbVendedor.LabelAsoc = Me.lblVendedor
        Me.cmbVendedor.Location = New System.Drawing.Point(72, 19)
        Me.cmbVendedor.Name = "cmbVendedor"
        Me.cmbVendedor.Size = New System.Drawing.Size(249, 21)
        Me.cmbVendedor.TabIndex = 1
        '
        'lblListasDePrecios
        '
        Me.lblListasDePrecios.AutoSize = True
        Me.lblListasDePrecios.LabelAsoc = Nothing
        Me.lblListasDePrecios.Location = New System.Drawing.Point(398, 15)
        Me.lblListasDePrecios.Name = "lblListasDePrecios"
        Me.lblListasDePrecios.Size = New System.Drawing.Size(81, 13)
        Me.lblListasDePrecios.TabIndex = 3
        Me.lblListasDePrecios.Text = "Lista de precios"
        '
        'txtPorcentaje
        '
        Me.txtPorcentaje.BindearPropiedadControl = Nothing
        Me.txtPorcentaje.BindearPropiedadEntidad = Nothing
        Me.txtPorcentaje.ForeColorFocus = System.Drawing.Color.Red
        Me.txtPorcentaje.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtPorcentaje.Formato = "N2"
        Me.txtPorcentaje.IsDecimal = True
        Me.txtPorcentaje.IsNumber = True
        Me.txtPorcentaje.IsPK = False
        Me.txtPorcentaje.IsRequired = False
        Me.txtPorcentaje.Key = ""
        Me.txtPorcentaje.LabelAsoc = Me.lblPorcentaje
        Me.txtPorcentaje.Location = New System.Drawing.Point(657, 12)
        Me.txtPorcentaje.Name = "txtPorcentaje"
        Me.txtPorcentaje.Size = New System.Drawing.Size(69, 20)
        Me.txtPorcentaje.TabIndex = 6
        Me.txtPorcentaje.Text = "0,00"
        Me.txtPorcentaje.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblPorcentaje
        '
        Me.lblPorcentaje.AutoSize = True
        Me.lblPorcentaje.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblPorcentaje.LabelAsoc = Nothing
        Me.lblPorcentaje.Location = New System.Drawing.Point(634, 15)
        Me.lblPorcentaje.Name = "lblPorcentaje"
        Me.lblPorcentaje.Size = New System.Drawing.Size(15, 13)
        Me.lblPorcentaje.TabIndex = 5
        Me.lblPorcentaje.Text = "%"
        '
        'ugdProductos
        '
        Appearance1.BackColor = System.Drawing.SystemColors.Window
        Appearance1.BorderColor = System.Drawing.SystemColors.InactiveCaption
        Me.ugdProductos.DisplayLayout.Appearance = Appearance1
        UltraGridColumn12.Header.Caption = "Código"
        UltraGridColumn12.Header.VisiblePosition = 0
        UltraGridColumn12.Width = 129
        UltraGridColumn13.Header.Caption = "Producto"
        UltraGridColumn13.Header.VisiblePosition = 1
        UltraGridColumn13.Width = 353
        Appearance2.TextHAlignAsString = "Right"
        UltraGridColumn14.CellAppearance = Appearance2
        UltraGridColumn14.Format = "N2"
        UltraGridColumn14.Header.VisiblePosition = 3
        UltraGridColumn18.Header.VisiblePosition = 4
        UltraGridColumn18.Hidden = True
        UltraGridColumn16.Header.VisiblePosition = 5
        UltraGridColumn16.Hidden = True
        UltraGridColumn17.Header.Caption = "Lista de Precios"
        UltraGridColumn17.Header.VisiblePosition = 2
        UltraGridColumn17.Width = 166
        UltraGridBand1.Columns.AddRange(New Object() {UltraGridColumn12, UltraGridColumn13, UltraGridColumn14, UltraGridColumn18, UltraGridColumn16, UltraGridColumn17})
        Me.ugdProductos.DisplayLayout.BandsSerializer.Add(UltraGridBand1)
        Me.ugdProductos.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.ugdProductos.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.[False]
        Appearance3.BackColor = System.Drawing.SystemColors.ActiveBorder
        Appearance3.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance3.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Appearance3.BorderColor = System.Drawing.SystemColors.Window
        Me.ugdProductos.DisplayLayout.GroupByBox.Appearance = Appearance3
        Appearance4.ForeColor = System.Drawing.SystemColors.GrayText
        Me.ugdProductos.DisplayLayout.GroupByBox.BandLabelAppearance = Appearance4
        Me.ugdProductos.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.ugdProductos.DisplayLayout.GroupByBox.Hidden = True
        Appearance5.BackColor = System.Drawing.SystemColors.ControlLightLight
        Appearance5.BackColor2 = System.Drawing.SystemColors.Control
        Appearance5.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance5.ForeColor = System.Drawing.SystemColors.GrayText
        Me.ugdProductos.DisplayLayout.GroupByBox.PromptAppearance = Appearance5
        Me.ugdProductos.DisplayLayout.MaxColScrollRegions = 1
        Me.ugdProductos.DisplayLayout.MaxRowScrollRegions = 1
        Appearance6.BackColor = System.Drawing.SystemColors.Window
        Appearance6.ForeColor = System.Drawing.SystemColors.ControlText
        Me.ugdProductos.DisplayLayout.Override.ActiveCellAppearance = Appearance6
        Appearance7.BackColor = System.Drawing.SystemColors.Highlight
        Appearance7.ForeColor = System.Drawing.SystemColors.HighlightText
        Me.ugdProductos.DisplayLayout.Override.ActiveRowAppearance = Appearance7
        Me.ugdProductos.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.[True]
        Me.ugdProductos.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted
        Me.ugdProductos.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted
        Appearance8.BackColor = System.Drawing.SystemColors.Window
        Me.ugdProductos.DisplayLayout.Override.CardAreaAppearance = Appearance8
        Appearance9.BorderColor = System.Drawing.Color.Silver
        Appearance9.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter
        Me.ugdProductos.DisplayLayout.Override.CellAppearance = Appearance9
        Me.ugdProductos.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText
        Me.ugdProductos.DisplayLayout.Override.CellPadding = 0
        Appearance10.BackColor = System.Drawing.SystemColors.Control
        Appearance10.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance10.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element
        Appearance10.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance10.BorderColor = System.Drawing.SystemColors.Window
        Me.ugdProductos.DisplayLayout.Override.GroupByRowAppearance = Appearance10
        Appearance11.TextHAlignAsString = "Left"
        Me.ugdProductos.DisplayLayout.Override.HeaderAppearance = Appearance11
        Me.ugdProductos.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
        Me.ugdProductos.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand
        Appearance12.BackColor = System.Drawing.SystemColors.Window
        Appearance12.BorderColor = System.Drawing.Color.Silver
        Me.ugdProductos.DisplayLayout.Override.RowAppearance = Appearance12
        Me.ugdProductos.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[False]
        Appearance13.BackColor = System.Drawing.SystemColors.ControlLight
        Me.ugdProductos.DisplayLayout.Override.TemplateAddRowAppearance = Appearance13
        Me.ugdProductos.DisplayLayout.Override.WrapHeaderText = Infragistics.Win.DefaultableBoolean.[True]
        Me.ugdProductos.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill
        Me.ugdProductos.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate
        Me.ugdProductos.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy
        Me.ugdProductos.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ugdProductos.Location = New System.Drawing.Point(13, 140)
        Me.ugdProductos.Name = "ugdProductos"
        Me.ugdProductos.Size = New System.Drawing.Size(855, 389)
        Me.ugdProductos.TabIndex = 2
        Me.ugdProductos.Text = "UltraGrid1"
        '
        'pnlComision
        '
        Me.pnlComision.Controls.Add(Me.bscProducto)
        Me.pnlComision.Controls.Add(Me.txtPorcentaje)
        Me.pnlComision.Controls.Add(Me.cmbListasDePrecios)
        Me.pnlComision.Controls.Add(Me.lblPorcentaje)
        Me.pnlComision.Controls.Add(Me.lblListasDePrecios)
        Me.pnlComision.Controls.Add(Me.Label1)
        Me.pnlComision.Controls.Add(Me.bscCodigoProducto)
        Me.pnlComision.Controls.Add(Me.btnEliminarProductos)
        Me.pnlComision.Controls.Add(Me.btnInsertarProductos)
        Me.pnlComision.Enabled = False
        Me.pnlComision.Location = New System.Drawing.Point(12, 93)
        Me.pnlComision.Name = "pnlComision"
        Me.pnlComision.Size = New System.Drawing.Size(860, 44)
        Me.pnlComision.TabIndex = 1
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
        Me.bscProducto.LabelAsoc = Nothing
        Me.bscProducto.Location = New System.Drawing.Point(164, 12)
        Me.bscProducto.MaxLengh = "60"
        Me.bscProducto.Name = "bscProducto"
        Me.bscProducto.Permitido = True
        Me.bscProducto.PermitidoNoBackColor = System.Drawing.Color.FromArgb(CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer))
        Me.bscProducto.PermitidoNoForeColor = System.Drawing.Color.Black
        Me.bscProducto.PermitidoSiBackColor = System.Drawing.Color.White
        Me.bscProducto.PermitidoSiForeColor = System.Drawing.Color.Black
        Me.bscProducto.Selecciono = False
        Me.bscProducto.Size = New System.Drawing.Size(227, 20)
        Me.bscProducto.TabIndex = 2
        '
        'cmbListasDePrecios
        '
        Me.cmbListasDePrecios.BindearPropiedadControl = Nothing
        Me.cmbListasDePrecios.BindearPropiedadEntidad = Nothing
        Me.cmbListasDePrecios.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbListasDePrecios.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbListasDePrecios.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbListasDePrecios.FormattingEnabled = True
        Me.cmbListasDePrecios.IsPK = False
        Me.cmbListasDePrecios.IsRequired = False
        Me.cmbListasDePrecios.Key = Nothing
        Me.cmbListasDePrecios.LabelAsoc = Me.lblListasDePrecios
        Me.cmbListasDePrecios.Location = New System.Drawing.Point(478, 11)
        Me.cmbListasDePrecios.Name = "cmbListasDePrecios"
        Me.cmbListasDePrecios.Size = New System.Drawing.Size(154, 21)
        Me.cmbListasDePrecios.TabIndex = 4
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.LabelAsoc = Nothing
        Me.Label1.Location = New System.Drawing.Point(6, 16)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(50, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Producto"
        '
        'bscCodigoProducto
        '
        Me.bscCodigoProducto.ActivarFiltroEnGrilla = True
        Me.bscCodigoProducto.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.bscCodigoProducto.BindearPropiedadControl = Nothing
        Me.bscCodigoProducto.BindearPropiedadEntidad = Nothing
        Me.bscCodigoProducto.ConfigBuscador = Nothing
        Me.bscCodigoProducto.Datos = Nothing
        Me.bscCodigoProducto.FilaDevuelta = Nothing
        Me.bscCodigoProducto.ForeColorFocus = System.Drawing.Color.Red
        Me.bscCodigoProducto.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.bscCodigoProducto.IsDecimal = False
        Me.bscCodigoProducto.IsNumber = False
        Me.bscCodigoProducto.IsPK = False
        Me.bscCodigoProducto.IsRequired = False
        Me.bscCodigoProducto.Key = ""
        Me.bscCodigoProducto.LabelAsoc = Nothing
        Me.bscCodigoProducto.Location = New System.Drawing.Point(62, 12)
        Me.bscCodigoProducto.MaxLengh = "32767"
        Me.bscCodigoProducto.Name = "bscCodigoProducto"
        Me.bscCodigoProducto.Permitido = True
        Me.bscCodigoProducto.PermitidoNoBackColor = System.Drawing.Color.FromArgb(CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer))
        Me.bscCodigoProducto.PermitidoNoForeColor = System.Drawing.Color.Black
        Me.bscCodigoProducto.PermitidoSiBackColor = System.Drawing.Color.White
        Me.bscCodigoProducto.PermitidoSiForeColor = System.Drawing.Color.Black
        Me.bscCodigoProducto.Selecciono = False
        Me.bscCodigoProducto.Size = New System.Drawing.Size(104, 20)
        Me.bscCodigoProducto.TabIndex = 1
        '
        'btnEliminarProductos
        '
        Me.btnEliminarProductos.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnEliminarProductos.Image = Global.Eniac.Win.My.Resources.Resources.delete_32
        Me.btnEliminarProductos.Location = New System.Drawing.Point(796, 3)
        Me.btnEliminarProductos.Name = "btnEliminarProductos"
        Me.btnEliminarProductos.Size = New System.Drawing.Size(38, 38)
        Me.btnEliminarProductos.TabIndex = 8
        Me.btnEliminarProductos.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnEliminarProductos.UseVisualStyleBackColor = True
        '
        'btnInsertarProductos
        '
        Me.btnInsertarProductos.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnInsertarProductos.Image = Global.Eniac.Win.My.Resources.Resources.add_32
        Me.btnInsertarProductos.Location = New System.Drawing.Point(752, 3)
        Me.btnInsertarProductos.Name = "btnInsertarProductos"
        Me.btnInsertarProductos.Size = New System.Drawing.Size(38, 38)
        Me.btnInsertarProductos.TabIndex = 7
        Me.btnInsertarProductos.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnInsertarProductos.UseVisualStyleBackColor = True
        '
        'UltraDataSource1
        '
        Me.UltraDataSource1.Band.Columns.AddRange(New Object() {UltraDataColumn1, UltraDataColumn2, UltraDataColumn3, UltraDataColumn4, UltraDataColumn5, UltraDataColumn6})
        '
        'ComisionesProductoVendedorLista
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(884, 541)
        Me.Controls.Add(Me.ugdProductos)
        Me.Controls.Add(Me.pnlComision)
        Me.Controls.Add(Me.grbCliente)
        Me.Controls.Add(Me.tspFacturacion)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.KeyPreview = True
        Me.Name = "ComisionesProductoVendedorLista"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Comisiones Productos de Vendedores por Lista"
        Me.tspFacturacion.ResumeLayout(False)
        Me.tspFacturacion.PerformLayout()
        Me.grbCliente.ResumeLayout(False)
        Me.grbCliente.PerformLayout()
        CType(Me.ugdProductos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlComision.ResumeLayout(False)
        Me.pnlComision.PerformLayout()
        CType(Me.UltraDataSource1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents tspFacturacion As System.Windows.Forms.ToolStrip
   Public WithEvents tsbRefrescar As System.Windows.Forms.ToolStripButton
   Friend WithEvents ToolStripSeparator4 As System.Windows.Forms.ToolStripSeparator
   Friend WithEvents tsbGrabar As System.Windows.Forms.ToolStripButton
   Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
   Friend WithEvents tsbSalir As System.Windows.Forms.ToolStripButton
   Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
   Friend WithEvents grbCliente As System.Windows.Forms.GroupBox
   Friend WithEvents lblVendedor As Eniac.Controles.Label
   Friend WithEvents cmbVendedor As Eniac.Controles.ComboBox
   Friend WithEvents btnBuscar As Eniac.Controles.Button
    Friend WithEvents cmbListasDePrecios As Eniac.Controles.ComboBox
    Friend WithEvents lblListasDePrecios As Eniac.Controles.Label
   Friend WithEvents txtPorcentaje As Eniac.Controles.TextBox
   Friend WithEvents lblPorcentaje As Eniac.Controles.Label
    Friend WithEvents ugdProductos As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents pnlComision As System.Windows.Forms.Panel
   Friend WithEvents bscProducto As Eniac.Controles.Buscador2
   Friend WithEvents bscCodigoProducto As Eniac.Controles.Buscador2
   Friend WithEvents btnEliminarProductos As Eniac.Controles.Button
   Friend WithEvents btnInsertarProductos As Eniac.Controles.Button
   Friend WithEvents Label1 As Eniac.Controles.Label
    Friend WithEvents UltraDataSource1 As UltraWinDataSource.UltraDataSource
End Class
