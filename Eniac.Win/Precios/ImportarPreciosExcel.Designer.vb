<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class ImportarPreciosExcel
   'Inherits BaseForm
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
      Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ImportarPreciosExcel))
      Dim Appearance1 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridBand1 As Infragistics.Win.UltraWinGrid.UltraGridBand = New Infragistics.Win.UltraWinGrid.UltraGridBand("Band 0", -1)
      Dim UltraGridColumn7 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdProducto")
      Dim UltraGridColumn8 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreProducto")
      Dim UltraGridColumn9 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("PrecioCosto")
      Dim Appearance2 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn10 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("PrecioCostoCalculado")
      Dim Appearance3 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn11 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("PrecioVenta")
      Dim Appearance4 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn12 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("PrecioVentaCalculado")
      Dim Appearance5 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
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
      Me.btnLeerExel = New Eniac.Controles.Button()
      Me.lblIncrementoCosto = New Eniac.Controles.Label()
      Me.txtIncrementoCosto = New Eniac.Controles.TextBox()
      Me.txtArchivoOrigen = New Eniac.Controles.TextBox()
      Me.lblArchivo = New Eniac.Controles.Label()
      Me.btnExaminar = New Eniac.Controles.Button()
      Me.tstBarra = New System.Windows.Forms.ToolStrip()
      Me.tsbRefrescar = New System.Windows.Forms.ToolStripButton()
      Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
      Me.tsbImportar = New System.Windows.Forms.ToolStripButton()
      Me.toolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
      Me.tsbSalir = New System.Windows.Forms.ToolStripButton()
      Me.lblIncrementoVenta = New Eniac.Controles.Label()
      Me.txtIncrementoVenta = New Eniac.Controles.TextBox()
      Me.chbLeeCosto = New System.Windows.Forms.CheckBox()
      Me.chbLeeVenta = New System.Windows.Forms.CheckBox()
      Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
      Me.tssRegistros = New System.Windows.Forms.ToolStripStatusLabel()
      Me.Label3 = New Eniac.Controles.Label()
      Me.txtPrefijo = New Eniac.Controles.TextBox()
      Me.cmbListaDePrecios = New Eniac.Controles.ComboBox()
      Me.lblListaPrecios = New Eniac.Controles.Label()
      Me.ugPrecios = New Infragistics.Win.UltraWinGrid.UltraGrid()
      Me.grpImportar = New System.Windows.Forms.GroupBox()
      Me.txtRangoCeldasColumnaHasta = New Eniac.Controles.TextBox()
      Me.lblRangoCeldas = New Eniac.Controles.Label()
      Me.txtRangoCeldasFilaDesde = New Eniac.Controles.TextBox()
      Me.txtRangoCeldasFilaHasta = New Eniac.Controles.TextBox()
      Me.txtRangoCeldasColumnaDesde = New Eniac.Controles.TextBox()
      Me.lblSeparadosCeldas = New Eniac.Controles.Label()
      Me.frmOpenFile = New System.Windows.Forms.OpenFileDialog()
        Me.tstBarra.SuspendLayout()
        Me.StatusStrip1.SuspendLayout()
        CType(Me.ugPrecios, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpImportar.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnLeerExel
        '
        Me.btnLeerExel.Image = Global.Eniac.Win.My.Resources.Resources.Excel32
        Me.btnLeerExel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnLeerExel.Location = New System.Drawing.Point(741, 13)
        Me.btnLeerExel.Name = "btnLeerExel"
        Me.btnLeerExel.Size = New System.Drawing.Size(102, 47)
        Me.btnLeerExel.TabIndex = 9
        Me.btnLeerExel.Text = "Leer Excel"
        Me.btnLeerExel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnLeerExel.UseVisualStyleBackColor = True
        '
        'lblIncrementoCosto
        '
        Me.lblIncrementoCosto.AutoSize = True
        Me.lblIncrementoCosto.LabelAsoc = Nothing
        Me.lblIncrementoCosto.Location = New System.Drawing.Point(542, 68)
        Me.lblIncrementoCosto.Name = "lblIncrementoCosto"
        Me.lblIncrementoCosto.Size = New System.Drawing.Size(15, 13)
        Me.lblIncrementoCosto.TabIndex = 16
        Me.lblIncrementoCosto.Text = "%"
        '
        'txtIncrementoCosto
        '
        Me.txtIncrementoCosto.BindearPropiedadControl = Nothing
        Me.txtIncrementoCosto.BindearPropiedadEntidad = Nothing
        Me.txtIncrementoCosto.ForeColorFocus = System.Drawing.Color.Red
        Me.txtIncrementoCosto.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtIncrementoCosto.Formato = "N2"
        Me.txtIncrementoCosto.IsDecimal = True
        Me.txtIncrementoCosto.IsNumber = True
        Me.txtIncrementoCosto.IsPK = False
        Me.txtIncrementoCosto.IsRequired = False
        Me.txtIncrementoCosto.Key = ""
        Me.txtIncrementoCosto.LabelAsoc = Me.lblIncrementoCosto
        Me.txtIncrementoCosto.Location = New System.Drawing.Point(494, 64)
        Me.txtIncrementoCosto.MaxLength = 5
        Me.txtIncrementoCosto.Name = "txtIncrementoCosto"
        Me.txtIncrementoCosto.Size = New System.Drawing.Size(47, 20)
        Me.txtIncrementoCosto.TabIndex = 15
        Me.txtIncrementoCosto.Text = "0.00"
        Me.txtIncrementoCosto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtArchivoOrigen
        '
        Me.txtArchivoOrigen.BindearPropiedadControl = "Text"
        Me.txtArchivoOrigen.BindearPropiedadEntidad = "CantidadProductos"
        Me.txtArchivoOrigen.ForeColorFocus = System.Drawing.Color.Red
        Me.txtArchivoOrigen.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtArchivoOrigen.Formato = ""
        Me.txtArchivoOrigen.IsDecimal = False
        Me.txtArchivoOrigen.IsNumber = False
        Me.txtArchivoOrigen.IsPK = False
        Me.txtArchivoOrigen.IsRequired = False
        Me.txtArchivoOrigen.Key = ""
        Me.txtArchivoOrigen.LabelAsoc = Nothing
        Me.txtArchivoOrigen.Location = New System.Drawing.Point(6, 32)
        Me.txtArchivoOrigen.Name = "txtArchivoOrigen"
        Me.txtArchivoOrigen.Size = New System.Drawing.Size(437, 20)
        Me.txtArchivoOrigen.TabIndex = 1
        '
        'lblArchivo
        '
        Me.lblArchivo.AutoSize = True
        Me.lblArchivo.LabelAsoc = Nothing
        Me.lblArchivo.Location = New System.Drawing.Point(6, 16)
        Me.lblArchivo.Name = "lblArchivo"
        Me.lblArchivo.Size = New System.Drawing.Size(46, 13)
        Me.lblArchivo.TabIndex = 0
        Me.lblArchivo.Text = "Archivo:"
        '
        'btnExaminar
        '
        Me.btnExaminar.Image = Global.Eniac.Win.My.Resources.Resources.folder_32
        Me.btnExaminar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnExaminar.ImageKey = "folder.ico"
        Me.btnExaminar.Location = New System.Drawing.Point(448, 13)
        Me.btnExaminar.Name = "btnExaminar"
        Me.btnExaminar.Size = New System.Drawing.Size(100, 40)
        Me.btnExaminar.TabIndex = 2
        Me.btnExaminar.Text = "&Examinar..."
        Me.btnExaminar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnExaminar.UseVisualStyleBackColor = True
        '
        'tstBarra
        '
        Me.tstBarra.AllowItemReorder = True
        Me.tstBarra.ImageScalingSize = New System.Drawing.Size(22, 22)
        Me.tstBarra.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsbRefrescar, Me.ToolStripSeparator1, Me.tsbImportar, Me.toolStripSeparator3, Me.tsbSalir})
        Me.tstBarra.Location = New System.Drawing.Point(0, 0)
        Me.tstBarra.Name = "tstBarra"
        Me.tstBarra.Size = New System.Drawing.Size(974, 29)
        Me.tstBarra.TabIndex = 3
        Me.tstBarra.Text = "toolStrip1"
        '
        'tsbRefrescar
        '
        Me.tsbRefrescar.Image = Global.Eniac.Win.My.Resources.Resources.refresh_32
        Me.tsbRefrescar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbRefrescar.Name = "tsbRefrescar"
        Me.tsbRefrescar.Size = New System.Drawing.Size(104, 26)
        Me.tsbRefrescar.Text = "&Refrescar (F5)"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 29)
        '
        'tsbImportar
        '
        Me.tsbImportar.Image = CType(resources.GetObject("tsbImportar.Image"), System.Drawing.Image)
        Me.tsbImportar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbImportar.Name = "tsbImportar"
        Me.tsbImportar.Size = New System.Drawing.Size(79, 26)
        Me.tsbImportar.Text = "&Importar"
        '
        'toolStripSeparator3
        '
        Me.toolStripSeparator3.Name = "toolStripSeparator3"
        Me.toolStripSeparator3.Size = New System.Drawing.Size(6, 29)
        '
        'tsbSalir
        '
        Me.tsbSalir.Image = Global.Eniac.Win.My.Resources.Resources.close_b_32
        Me.tsbSalir.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbSalir.Name = "tsbSalir"
        Me.tsbSalir.Size = New System.Drawing.Size(65, 26)
        Me.tsbSalir.Text = "&Cerrar"
        Me.tsbSalir.ToolTipText = "Cerrar el formulario"
        '
        'lblIncrementoVenta
        '
        Me.lblIncrementoVenta.AutoSize = True
        Me.lblIncrementoVenta.LabelAsoc = Nothing
        Me.lblIncrementoVenta.Location = New System.Drawing.Point(702, 68)
        Me.lblIncrementoVenta.Name = "lblIncrementoVenta"
        Me.lblIncrementoVenta.Size = New System.Drawing.Size(15, 13)
        Me.lblIncrementoVenta.TabIndex = 19
        Me.lblIncrementoVenta.Text = "%"
        '
        'txtIncrementoVenta
        '
        Me.txtIncrementoVenta.BindearPropiedadControl = Nothing
        Me.txtIncrementoVenta.BindearPropiedadEntidad = Nothing
        Me.txtIncrementoVenta.ForeColorFocus = System.Drawing.Color.Red
        Me.txtIncrementoVenta.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtIncrementoVenta.Formato = "N2"
        Me.txtIncrementoVenta.IsDecimal = True
        Me.txtIncrementoVenta.IsNumber = True
        Me.txtIncrementoVenta.IsPK = False
        Me.txtIncrementoVenta.IsRequired = False
        Me.txtIncrementoVenta.Key = ""
        Me.txtIncrementoVenta.LabelAsoc = Me.lblIncrementoVenta
        Me.txtIncrementoVenta.Location = New System.Drawing.Point(651, 64)
        Me.txtIncrementoVenta.MaxLength = 5
        Me.txtIncrementoVenta.Name = "txtIncrementoVenta"
        Me.txtIncrementoVenta.Size = New System.Drawing.Size(48, 20)
        Me.txtIncrementoVenta.TabIndex = 18
        Me.txtIncrementoVenta.Text = "0.00"
        Me.txtIncrementoVenta.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'chbLeeCosto
        '
        Me.chbLeeCosto.AutoSize = True
        Me.chbLeeCosto.Checked = True
        Me.chbLeeCosto.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chbLeeCosto.Location = New System.Drawing.Point(419, 66)
        Me.chbLeeCosto.Name = "chbLeeCosto"
        Me.chbLeeCosto.Size = New System.Drawing.Size(74, 17)
        Me.chbLeeCosto.TabIndex = 14
        Me.chbLeeCosto.Text = "Lee Costo"
        Me.chbLeeCosto.UseVisualStyleBackColor = True
        '
        'chbLeeVenta
        '
        Me.chbLeeVenta.AutoSize = True
        Me.chbLeeVenta.Checked = True
        Me.chbLeeVenta.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chbLeeVenta.Location = New System.Drawing.Point(575, 66)
        Me.chbLeeVenta.Name = "chbLeeVenta"
        Me.chbLeeVenta.Size = New System.Drawing.Size(75, 17)
        Me.chbLeeVenta.TabIndex = 17
        Me.chbLeeVenta.Text = "Lee Venta"
        Me.chbLeeVenta.UseVisualStyleBackColor = True
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tssRegistros})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 529)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(974, 22)
        Me.StatusStrip1.TabIndex = 2
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'tssRegistros
        '
        Me.tssRegistros.Name = "tssRegistros"
        Me.tssRegistros.Size = New System.Drawing.Size(959, 17)
        Me.tssRegistros.Spring = True
        Me.tssRegistros.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.LabelAsoc = Nothing
        Me.Label3.Location = New System.Drawing.Point(4, 68)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(39, 13)
        Me.Label3.TabIndex = 10
        Me.Label3.Text = "Prefijo:"
        '
        'txtPrefijo
        '
        Me.txtPrefijo.BindearPropiedadControl = Nothing
        Me.txtPrefijo.BindearPropiedadEntidad = Nothing
        Me.txtPrefijo.ForeColorFocus = System.Drawing.Color.Red
        Me.txtPrefijo.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtPrefijo.Formato = ""
        Me.txtPrefijo.IsDecimal = False
        Me.txtPrefijo.IsNumber = False
        Me.txtPrefijo.IsPK = False
        Me.txtPrefijo.IsRequired = False
        Me.txtPrefijo.Key = ""
        Me.txtPrefijo.LabelAsoc = Nothing
        Me.txtPrefijo.Location = New System.Drawing.Point(44, 64)
        Me.txtPrefijo.MaxLength = 5
        Me.txtPrefijo.Name = "txtPrefijo"
        Me.txtPrefijo.Size = New System.Drawing.Size(52, 20)
        Me.txtPrefijo.TabIndex = 11
        '
        'cmbListaDePrecios
        '
        Me.cmbListaDePrecios.BindearPropiedadControl = Nothing
        Me.cmbListaDePrecios.BindearPropiedadEntidad = Nothing
        Me.cmbListaDePrecios.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbListaDePrecios.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbListaDePrecios.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbListaDePrecios.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbListaDePrecios.FormattingEnabled = True
        Me.cmbListaDePrecios.IsPK = False
        Me.cmbListaDePrecios.IsRequired = False
        Me.cmbListaDePrecios.Key = Nothing
        Me.cmbListaDePrecios.LabelAsoc = Me.lblListaPrecios
        Me.cmbListaDePrecios.Location = New System.Drawing.Point(184, 64)
        Me.cmbListaDePrecios.Name = "cmbListaDePrecios"
        Me.cmbListaDePrecios.Size = New System.Drawing.Size(215, 21)
        Me.cmbListaDePrecios.TabIndex = 13
        '
        'lblListaPrecios
        '
        Me.lblListaPrecios.AutoSize = True
        Me.lblListaPrecios.LabelAsoc = Nothing
        Me.lblListaPrecios.Location = New System.Drawing.Point(102, 68)
        Me.lblListaPrecios.Name = "lblListaPrecios"
        Me.lblListaPrecios.Size = New System.Drawing.Size(82, 13)
        Me.lblListaPrecios.TabIndex = 12
        Me.lblListaPrecios.Text = "Lista de Precios"
        '
        'ugPrecios
        '
        Appearance1.BackColor = System.Drawing.SystemColors.Window
        Appearance1.BorderColor = System.Drawing.SystemColors.InactiveCaption
        Me.ugPrecios.DisplayLayout.Appearance = Appearance1
        UltraGridColumn7.Header.Caption = "Código"
        UltraGridColumn7.Header.VisiblePosition = 0
        UltraGridColumn7.NullText = "--"
        UltraGridColumn7.Width = 120
        UltraGridColumn8.Header.Caption = "Descripción"
        UltraGridColumn8.Header.VisiblePosition = 1
        UltraGridColumn8.NullText = "--"
        UltraGridColumn8.Width = 400
        Appearance2.TextHAlignAsString = "Right"
        UltraGridColumn9.CellAppearance = Appearance2
        UltraGridColumn9.Format = "N2"
        UltraGridColumn9.Header.Caption = "Costo"
        UltraGridColumn9.Header.VisiblePosition = 2
        UltraGridColumn9.NullText = "--"
        UltraGridColumn9.Width = 80
        Appearance3.TextHAlignAsString = "Right"
        UltraGridColumn10.CellAppearance = Appearance3
        UltraGridColumn10.Format = "N2"
        UltraGridColumn10.Header.Caption = "Costo Calc."
        UltraGridColumn10.Header.VisiblePosition = 3
        UltraGridColumn10.NullText = "--"
        UltraGridColumn10.Width = 80
        Appearance4.TextHAlignAsString = "Right"
        UltraGridColumn11.CellAppearance = Appearance4
        UltraGridColumn11.Format = "N2"
        UltraGridColumn11.Header.Caption = "Venta"
        UltraGridColumn11.Header.VisiblePosition = 4
        UltraGridColumn11.NullText = "--"
        UltraGridColumn11.Width = 80
        Appearance5.TextHAlignAsString = "Right"
        UltraGridColumn12.CellAppearance = Appearance5
        UltraGridColumn12.Format = "N2"
        UltraGridColumn12.Header.Caption = "Venta Calc."
        UltraGridColumn12.Header.VisiblePosition = 5
        UltraGridColumn12.NullText = "--"
        UltraGridColumn12.Width = 80
        UltraGridBand1.Columns.AddRange(New Object() {UltraGridColumn7, UltraGridColumn8, UltraGridColumn9, UltraGridColumn10, UltraGridColumn11, UltraGridColumn12})
        Me.ugPrecios.DisplayLayout.BandsSerializer.Add(UltraGridBand1)
        Me.ugPrecios.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.ugPrecios.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.[False]
        Appearance6.BackColor = System.Drawing.SystemColors.ActiveBorder
        Appearance6.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance6.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Appearance6.BorderColor = System.Drawing.SystemColors.Window
        Me.ugPrecios.DisplayLayout.GroupByBox.Appearance = Appearance6
        Appearance7.ForeColor = System.Drawing.SystemColors.GrayText
        Me.ugPrecios.DisplayLayout.GroupByBox.BandLabelAppearance = Appearance7
        Me.ugPrecios.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Appearance8.BackColor = System.Drawing.SystemColors.ControlLightLight
        Appearance8.BackColor2 = System.Drawing.SystemColors.Control
        Appearance8.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance8.ForeColor = System.Drawing.SystemColors.GrayText
        Me.ugPrecios.DisplayLayout.GroupByBox.PromptAppearance = Appearance8
        Me.ugPrecios.DisplayLayout.MaxColScrollRegions = 1
        Me.ugPrecios.DisplayLayout.MaxRowScrollRegions = 1
        Appearance9.BackColor = System.Drawing.SystemColors.Window
        Appearance9.ForeColor = System.Drawing.SystemColors.ControlText
        Me.ugPrecios.DisplayLayout.Override.ActiveCellAppearance = Appearance9
        Appearance10.BackColor = System.Drawing.SystemColors.Highlight
        Appearance10.ForeColor = System.Drawing.SystemColors.HighlightText
        Me.ugPrecios.DisplayLayout.Override.ActiveRowAppearance = Appearance10
        Me.ugPrecios.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted
        Me.ugPrecios.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted
        Appearance11.BackColor = System.Drawing.SystemColors.Window
        Me.ugPrecios.DisplayLayout.Override.CardAreaAppearance = Appearance11
        Appearance12.BorderColor = System.Drawing.Color.Silver
        Appearance12.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter
        Me.ugPrecios.DisplayLayout.Override.CellAppearance = Appearance12
        Me.ugPrecios.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText
        Me.ugPrecios.DisplayLayout.Override.CellPadding = 0
        Appearance13.BackColor = System.Drawing.SystemColors.Control
        Appearance13.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance13.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element
        Appearance13.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance13.BorderColor = System.Drawing.SystemColors.Window
        Me.ugPrecios.DisplayLayout.Override.GroupByRowAppearance = Appearance13
        Appearance14.TextHAlignAsString = "Left"
        Me.ugPrecios.DisplayLayout.Override.HeaderAppearance = Appearance14
        Me.ugPrecios.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
        Me.ugPrecios.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand
        Appearance15.BackColor = System.Drawing.SystemColors.Window
        Appearance15.BorderColor = System.Drawing.Color.Silver
        Me.ugPrecios.DisplayLayout.Override.RowAppearance = Appearance15
        Me.ugPrecios.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[False]
        Appearance16.BackColor = System.Drawing.SystemColors.ControlLight
        Me.ugPrecios.DisplayLayout.Override.TemplateAddRowAppearance = Appearance16
        Me.ugPrecios.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill
        Me.ugPrecios.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate
        Me.ugPrecios.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy
        Me.ugPrecios.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ugPrecios.Location = New System.Drawing.Point(0, 125)
        Me.ugPrecios.Name = "ugPrecios"
        Me.ugPrecios.Size = New System.Drawing.Size(974, 404)
        Me.ugPrecios.TabIndex = 1
        Me.ugPrecios.Text = "UltraGrid1"
        '
        'grpImportar
        '
        Me.grpImportar.Controls.Add(Me.txtRangoCeldasColumnaHasta)
        Me.grpImportar.Controls.Add(Me.txtRangoCeldasFilaDesde)
        Me.grpImportar.Controls.Add(Me.txtRangoCeldasFilaHasta)
        Me.grpImportar.Controls.Add(Me.txtRangoCeldasColumnaDesde)
        Me.grpImportar.Controls.Add(Me.lblRangoCeldas)
        Me.grpImportar.Controls.Add(Me.lblSeparadosCeldas)
        Me.grpImportar.Controls.Add(Me.lblArchivo)
        Me.grpImportar.Controls.Add(Me.btnLeerExel)
        Me.grpImportar.Controls.Add(Me.cmbListaDePrecios)
        Me.grpImportar.Controls.Add(Me.txtIncrementoCosto)
        Me.grpImportar.Controls.Add(Me.lblListaPrecios)
        Me.grpImportar.Controls.Add(Me.lblIncrementoCosto)
        Me.grpImportar.Controls.Add(Me.Label3)
        Me.grpImportar.Controls.Add(Me.txtArchivoOrigen)
        Me.grpImportar.Controls.Add(Me.txtPrefijo)
        Me.grpImportar.Controls.Add(Me.chbLeeVenta)
        Me.grpImportar.Controls.Add(Me.chbLeeCosto)
        Me.grpImportar.Controls.Add(Me.btnExaminar)
        Me.grpImportar.Controls.Add(Me.lblIncrementoVenta)
        Me.grpImportar.Controls.Add(Me.txtIncrementoVenta)
        Me.grpImportar.Dock = System.Windows.Forms.DockStyle.Top
        Me.grpImportar.Location = New System.Drawing.Point(0, 29)
        Me.grpImportar.Name = "grpImportar"
        Me.grpImportar.Size = New System.Drawing.Size(974, 96)
        Me.grpImportar.TabIndex = 0
        Me.grpImportar.TabStop = False
        '
        'txtRangoCeldasColumnaHasta
        '
        Me.txtRangoCeldasColumnaHasta.BindearPropiedadControl = Nothing
        Me.txtRangoCeldasColumnaHasta.BindearPropiedadEntidad = Nothing
        Me.txtRangoCeldasColumnaHasta.ForeColorFocus = System.Drawing.Color.Red
        Me.txtRangoCeldasColumnaHasta.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtRangoCeldasColumnaHasta.Formato = ""
        Me.txtRangoCeldasColumnaHasta.IsDecimal = False
        Me.txtRangoCeldasColumnaHasta.IsNumber = False
        Me.txtRangoCeldasColumnaHasta.IsPK = False
        Me.txtRangoCeldasColumnaHasta.IsRequired = False
        Me.txtRangoCeldasColumnaHasta.Key = ""
        Me.txtRangoCeldasColumnaHasta.LabelAsoc = Me.lblRangoCeldas
        Me.txtRangoCeldasColumnaHasta.Location = New System.Drawing.Point(630, 32)
        Me.txtRangoCeldasColumnaHasta.Name = "txtRangoCeldasColumnaHasta"
        Me.txtRangoCeldasColumnaHasta.Size = New System.Drawing.Size(20, 20)
        Me.txtRangoCeldasColumnaHasta.TabIndex = 7
        Me.txtRangoCeldasColumnaHasta.TabStop = False
        Me.txtRangoCeldasColumnaHasta.Tag = "D"
        Me.txtRangoCeldasColumnaHasta.Text = "D"
        Me.txtRangoCeldasColumnaHasta.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'lblRangoCeldas
        '
        Me.lblRangoCeldas.AutoSize = True
        Me.lblRangoCeldas.LabelAsoc = Nothing
        Me.lblRangoCeldas.Location = New System.Drawing.Point(576, 17)
        Me.lblRangoCeldas.Name = "lblRangoCeldas"
        Me.lblRangoCeldas.Size = New System.Drawing.Size(88, 13)
        Me.lblRangoCeldas.TabIndex = 3
        Me.lblRangoCeldas.Text = "Rango de celdas"
        '
        'txtRangoCeldasFilaDesde
        '
        Me.txtRangoCeldasFilaDesde.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.txtRangoCeldasFilaDesde.BindearPropiedadControl = Nothing
        Me.txtRangoCeldasFilaDesde.BindearPropiedadEntidad = Nothing
        Me.txtRangoCeldasFilaDesde.ForeColorFocus = System.Drawing.Color.Red
        Me.txtRangoCeldasFilaDesde.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtRangoCeldasFilaDesde.Formato = ""
        Me.txtRangoCeldasFilaDesde.IsDecimal = False
        Me.txtRangoCeldasFilaDesde.IsNumber = False
        Me.txtRangoCeldasFilaDesde.IsPK = False
        Me.txtRangoCeldasFilaDesde.IsRequired = False
        Me.txtRangoCeldasFilaDesde.Key = ""
        Me.txtRangoCeldasFilaDesde.LabelAsoc = Me.lblRangoCeldas
        Me.txtRangoCeldasFilaDesde.Location = New System.Drawing.Point(592, 32)
        Me.txtRangoCeldasFilaDesde.Name = "txtRangoCeldasFilaDesde"
        Me.txtRangoCeldasFilaDesde.Size = New System.Drawing.Size(30, 20)
        Me.txtRangoCeldasFilaDesde.TabIndex = 5
        Me.txtRangoCeldasFilaDesde.Text = "4"
        Me.txtRangoCeldasFilaDesde.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtRangoCeldasFilaHasta
        '
        Me.txtRangoCeldasFilaHasta.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.txtRangoCeldasFilaHasta.BindearPropiedadControl = Nothing
        Me.txtRangoCeldasFilaHasta.BindearPropiedadEntidad = Nothing
        Me.txtRangoCeldasFilaHasta.ForeColorFocus = System.Drawing.Color.Red
        Me.txtRangoCeldasFilaHasta.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtRangoCeldasFilaHasta.Formato = ""
        Me.txtRangoCeldasFilaHasta.IsDecimal = False
        Me.txtRangoCeldasFilaHasta.IsNumber = False
        Me.txtRangoCeldasFilaHasta.IsPK = False
        Me.txtRangoCeldasFilaHasta.IsRequired = False
        Me.txtRangoCeldasFilaHasta.Key = ""
        Me.txtRangoCeldasFilaHasta.LabelAsoc = Me.lblRangoCeldas
        Me.txtRangoCeldasFilaHasta.Location = New System.Drawing.Point(649, 32)
        Me.txtRangoCeldasFilaHasta.Name = "txtRangoCeldasFilaHasta"
        Me.txtRangoCeldasFilaHasta.Size = New System.Drawing.Size(46, 20)
        Me.txtRangoCeldasFilaHasta.TabIndex = 8
        Me.txtRangoCeldasFilaHasta.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtRangoCeldasColumnaDesde
        '
        Me.txtRangoCeldasColumnaDesde.BindearPropiedadControl = Nothing
        Me.txtRangoCeldasColumnaDesde.BindearPropiedadEntidad = Nothing
        Me.txtRangoCeldasColumnaDesde.ForeColorFocus = System.Drawing.Color.Red
        Me.txtRangoCeldasColumnaDesde.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtRangoCeldasColumnaDesde.Formato = ""
        Me.txtRangoCeldasColumnaDesde.IsDecimal = False
        Me.txtRangoCeldasColumnaDesde.IsNumber = False
        Me.txtRangoCeldasColumnaDesde.IsPK = False
        Me.txtRangoCeldasColumnaDesde.IsRequired = False
        Me.txtRangoCeldasColumnaDesde.Key = ""
        Me.txtRangoCeldasColumnaDesde.LabelAsoc = Me.lblRangoCeldas
        Me.txtRangoCeldasColumnaDesde.Location = New System.Drawing.Point(573, 32)
        Me.txtRangoCeldasColumnaDesde.Name = "txtRangoCeldasColumnaDesde"
        Me.txtRangoCeldasColumnaDesde.Size = New System.Drawing.Size(20, 20)
        Me.txtRangoCeldasColumnaDesde.TabIndex = 4
        Me.txtRangoCeldasColumnaDesde.TabStop = False
        Me.txtRangoCeldasColumnaDesde.Text = "A"
        Me.txtRangoCeldasColumnaDesde.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'lblSeparadosCeldas
        '
        Me.lblSeparadosCeldas.AutoSize = True
        Me.lblSeparadosCeldas.LabelAsoc = Nothing
        Me.lblSeparadosCeldas.Location = New System.Drawing.Point(621, 36)
        Me.lblSeparadosCeldas.Name = "lblSeparadosCeldas"
        Me.lblSeparadosCeldas.Size = New System.Drawing.Size(10, 13)
        Me.lblSeparadosCeldas.TabIndex = 6
        Me.lblSeparadosCeldas.Text = ":"
        Me.lblSeparadosCeldas.Visible = False
        '
        'frmOpenFile
        '
        Me.frmOpenFile.Filter = """Libro de Excel 97-2003 (*.xls)|*.xls|Libro de Excel 2007-2010 (*.xlsx)|*.xlsx|To" &
    "dos los Archivos (*.*)|*.*"""
        Me.frmOpenFile.RestoreDirectory = True
        '
        'ImportarPreciosExcel
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(974, 551)
        Me.Controls.Add(Me.ugPrecios)
        Me.Controls.Add(Me.grpImportar)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.tstBarra)
        Me.KeyPreview = True
        Me.Name = "ImportarPreciosExcel"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Importación de Precios desde Excel"
        Me.tstBarra.ResumeLayout(False)
        Me.tstBarra.PerformLayout()
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        CType(Me.ugPrecios, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpImportar.ResumeLayout(False)
        Me.grpImportar.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnLeerExel As Eniac.Controles.Button
   Friend WithEvents lblIncrementoCosto As Eniac.Controles.Label
   Friend WithEvents txtIncrementoCosto As Eniac.Controles.TextBox
   Friend WithEvents txtArchivoOrigen As Eniac.Controles.TextBox
   Friend WithEvents lblArchivo As Eniac.Controles.Label
   Friend WithEvents btnExaminar As Eniac.Controles.Button
   Public WithEvents tstBarra As System.Windows.Forms.ToolStrip
   Public WithEvents tsbRefrescar As System.Windows.Forms.ToolStripButton
   Private WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
   Friend WithEvents tsbImportar As System.Windows.Forms.ToolStripButton
   Private WithEvents toolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
   Public WithEvents tsbSalir As System.Windows.Forms.ToolStripButton
   Friend WithEvents lblIncrementoVenta As Eniac.Controles.Label
   Friend WithEvents txtIncrementoVenta As Eniac.Controles.TextBox
   Friend WithEvents chbLeeCosto As System.Windows.Forms.CheckBox
   Friend WithEvents chbLeeVenta As System.Windows.Forms.CheckBox
   Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
   Friend WithEvents tssRegistros As System.Windows.Forms.ToolStripStatusLabel
   Friend WithEvents Label3 As Eniac.Controles.Label
   Friend WithEvents txtPrefijo As Eniac.Controles.TextBox
   Friend WithEvents cmbListaDePrecios As Eniac.Controles.ComboBox
   Friend WithEvents lblListaPrecios As Eniac.Controles.Label
   Friend WithEvents ugPrecios As UltraGrid
   Friend WithEvents grpImportar As GroupBox
   Friend WithEvents txtRangoCeldasColumnaHasta As Controles.TextBox
   Friend WithEvents lblRangoCeldas As Controles.Label
   Friend WithEvents txtRangoCeldasFilaDesde As Controles.TextBox
   Friend WithEvents txtRangoCeldasFilaHasta As Controles.TextBox
   Friend WithEvents txtRangoCeldasColumnaDesde As Controles.TextBox
   Friend WithEvents lblSeparadosCeldas As Controles.Label
   Friend WithEvents frmOpenFile As OpenFileDialog
End Class
