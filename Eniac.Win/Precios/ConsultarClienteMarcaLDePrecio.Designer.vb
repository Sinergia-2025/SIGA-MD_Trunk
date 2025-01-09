<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ConsultarClienteMarcaLDePrecio
   Inherits BaseForm

   'Form reemplaza a Dispose para limpiar la lista de componentes.
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

   'Requerido por el Diseñador de Windows Forms
   Private components As System.ComponentModel.IContainer

   'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
   'Se puede modificar usando el Diseñador de Windows Forms.  
   'No lo modifique con el editor de código.
   <System.Diagnostics.DebuggerStepThrough()> _
   Private Sub InitializeComponent()
      Me.components = New System.ComponentModel.Container()
      Dim Appearance1 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridBand1 As Infragistics.Win.UltraWinGrid.UltraGridBand = New Infragistics.Win.UltraWinGrid.UltraGridBand("Band 0", -1)
      Dim UltraGridColumn1 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("TipoDocumento")
      Dim UltraGridColumn2 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NroDocumento")
      Dim UltraGridColumn3 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreCliente")
      Dim UltraGridColumn4 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdMarca")
      Dim UltraGridColumn5 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreMarca")
      Dim UltraGridColumn6 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdListaPrecios")
      Dim UltraGridColumn7 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreListaPrecios")
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
      Dim Appearance13 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Me.bscMarca = New Eniac.Controles.Buscador()
      Me.grbCliente = New System.Windows.Forms.GroupBox()
      Me.cmbListasDePrecios = New Eniac.Controles.ComboBox()
      Me.chbCliente = New System.Windows.Forms.CheckBox()
      Me.lblNombre = New Eniac.Controles.Label()
      Me.lblCodigoCliente = New Eniac.Controles.Label()
      Me.bscCliente = New Eniac.Controles.Buscador()
      Me.bscCodigoCliente = New Eniac.Controles.Buscador()
      Me.btnConsultar = New Eniac.Controles.Button()
      Me.ckbMarca = New System.Windows.Forms.CheckBox()
      Me.ckbListaPrecios = New System.Windows.Forms.CheckBox()
      Me.tspFacturacion = New System.Windows.Forms.ToolStrip()
      Me.tsbRefrescar = New System.Windows.Forms.ToolStripButton()
      Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator()
      Me.tsbImprimir = New System.Windows.Forms.ToolStripButton()
      Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
      Me.tsbSalir = New System.Windows.Forms.ToolStripButton()
      Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
      Me.dgvDetalle = New Infragistics.Win.UltraWinGrid.UltraGrid()
      Me.chkExpandAll = New System.Windows.Forms.CheckBox()
      Me.UltraGridPrintDocument1 = New Infragistics.Win.UltraWinGrid.UltraGridPrintDocument(Me.components)
      Me.UltraPrintPreviewDialog1 = New Infragistics.Win.Printing.UltraPrintPreviewDialog(Me.components)
      Me.grbCliente.SuspendLayout()
      Me.tspFacturacion.SuspendLayout()
      CType(Me.dgvDetalle, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.SuspendLayout()
      '
      'bscMarca
      '
      Me.bscMarca.AyudaAncho = 608
      Me.bscMarca.BindearPropiedadControl = Nothing
      Me.bscMarca.BindearPropiedadEntidad = Nothing
      Me.bscMarca.ColumnasAlineacion = Nothing
      Me.bscMarca.ColumnasAncho = Nothing
      Me.bscMarca.ColumnasFormato = Nothing
      Me.bscMarca.ColumnasOcultas = Nothing
      Me.bscMarca.ColumnasTitulos = Nothing
      Me.bscMarca.Datos = Nothing
      Me.bscMarca.Enabled = False
      Me.bscMarca.FilaDevuelta = Nothing
      Me.bscMarca.ForeColorFocus = System.Drawing.Color.Red
      Me.bscMarca.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
      Me.bscMarca.IsDecimal = False
      Me.bscMarca.IsNumber = False
      Me.bscMarca.IsPK = False
      Me.bscMarca.IsRequired = False
      Me.bscMarca.Key = ""
      Me.bscMarca.LabelAsoc = Nothing
      Me.bscMarca.Location = New System.Drawing.Point(77, 105)
      Me.bscMarca.MaxLengh = "32767"
      Me.bscMarca.Name = "bscMarca"
      Me.bscMarca.Permitido = True
      Me.bscMarca.Selecciono = False
      Me.bscMarca.Size = New System.Drawing.Size(201, 20)
      Me.bscMarca.TabIndex = 11
      Me.bscMarca.Titulo = Nothing
      '
      'grbCliente
      '
      Me.grbCliente.Controls.Add(Me.cmbListasDePrecios)
      Me.grbCliente.Controls.Add(Me.chbCliente)
      Me.grbCliente.Controls.Add(Me.lblNombre)
      Me.grbCliente.Controls.Add(Me.lblCodigoCliente)
      Me.grbCliente.Controls.Add(Me.bscCliente)
      Me.grbCliente.Controls.Add(Me.bscCodigoCliente)
      Me.grbCliente.Location = New System.Drawing.Point(10, 38)
      Me.grbCliente.Name = "grbCliente"
      Me.grbCliente.Size = New System.Drawing.Size(603, 102)
      Me.grbCliente.TabIndex = 10
      Me.grbCliente.TabStop = False
      Me.grbCliente.Text = "Filtros"
      '
      'cmbListasDePrecios
      '
      Me.cmbListasDePrecios.BindearPropiedadControl = "SelectedValue"
      Me.cmbListasDePrecios.BindearPropiedadEntidad = "IdListaPrecios"
      Me.cmbListasDePrecios.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cmbListasDePrecios.Enabled = False
      Me.cmbListasDePrecios.ForeColorFocus = System.Drawing.Color.Red
      Me.cmbListasDePrecios.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.cmbListasDePrecios.FormattingEnabled = True
      Me.cmbListasDePrecios.IsPK = False
      Me.cmbListasDePrecios.IsRequired = True
      Me.cmbListasDePrecios.Key = Nothing
      Me.cmbListasDePrecios.LabelAsoc = Nothing
      Me.cmbListasDePrecios.Location = New System.Drawing.Point(395, 66)
      Me.cmbListasDePrecios.Name = "cmbListasDePrecios"
      Me.cmbListasDePrecios.Size = New System.Drawing.Size(204, 21)
      Me.cmbListasDePrecios.TabIndex = 18
      '
      'chbCliente
      '
      Me.chbCliente.AutoSize = True
      Me.chbCliente.Location = New System.Drawing.Point(6, 33)
      Me.chbCliente.Name = "chbCliente"
      Me.chbCliente.Size = New System.Drawing.Size(58, 17)
      Me.chbCliente.TabIndex = 17
      Me.chbCliente.Text = "Cliente"
      Me.chbCliente.UseVisualStyleBackColor = True
      '
      'lblNombre
      '
      Me.lblNombre.AutoSize = True
      Me.lblNombre.Location = New System.Drawing.Point(197, 11)
      Me.lblNombre.Name = "lblNombre"
      Me.lblNombre.Size = New System.Drawing.Size(44, 13)
      Me.lblNombre.TabIndex = 4
      Me.lblNombre.Text = "Nombre"
      '
      'lblCodigoCliente
      '
      Me.lblCodigoCliente.AutoSize = True
      Me.lblCodigoCliente.Location = New System.Drawing.Point(64, 11)
      Me.lblCodigoCliente.Name = "lblCodigoCliente"
      Me.lblCodigoCliente.Size = New System.Drawing.Size(40, 13)
      Me.lblCodigoCliente.TabIndex = 5
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
      Me.bscCliente.Location = New System.Drawing.Point(195, 27)
      Me.bscCliente.Margin = New System.Windows.Forms.Padding(4)
      Me.bscCliente.MaxLengh = "32767"
      Me.bscCliente.Name = "bscCliente"
      Me.bscCliente.Permitido = True
      Me.bscCliente.Selecciono = False
      Me.bscCliente.Size = New System.Drawing.Size(300, 23)
      Me.bscCliente.TabIndex = 2
      Me.bscCliente.Titulo = Nothing
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
      Me.bscCodigoCliente.IsNumber = True
      Me.bscCodigoCliente.IsPK = False
      Me.bscCodigoCliente.IsRequired = False
      Me.bscCodigoCliente.Key = ""
      Me.bscCodigoCliente.LabelAsoc = Me.lblCodigoCliente
      Me.bscCodigoCliente.Location = New System.Drawing.Point(67, 27)
      Me.bscCodigoCliente.MaxLengh = "32767"
      Me.bscCodigoCliente.Name = "bscCodigoCliente"
      Me.bscCodigoCliente.Permitido = True
      Me.bscCodigoCliente.Selecciono = False
      Me.bscCodigoCliente.Size = New System.Drawing.Size(90, 23)
      Me.bscCodigoCliente.TabIndex = 1
      Me.bscCodigoCliente.Titulo = Nothing
      '
      'btnConsultar
      '
      Me.btnConsultar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.btnConsultar.Image = Global.Eniac.Win.My.Resources.Resources.view
      Me.btnConsultar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
      Me.btnConsultar.Location = New System.Drawing.Point(506, 145)
      Me.btnConsultar.Name = "btnConsultar"
      Me.btnConsultar.Size = New System.Drawing.Size(100, 45)
      Me.btnConsultar.TabIndex = 3
      Me.btnConsultar.Text = "&Consultar"
      Me.btnConsultar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      Me.btnConsultar.UseVisualStyleBackColor = True
      '
      'ckbMarca
      '
      Me.ckbMarca.AutoSize = True
      Me.ckbMarca.Location = New System.Drawing.Point(16, 108)
      Me.ckbMarca.Name = "ckbMarca"
      Me.ckbMarca.Size = New System.Drawing.Size(56, 17)
      Me.ckbMarca.TabIndex = 15
      Me.ckbMarca.Text = "Marca"
      Me.ckbMarca.UseVisualStyleBackColor = True
      '
      'ckbListaPrecios
      '
      Me.ckbListaPrecios.AutoSize = True
      Me.ckbListaPrecios.Location = New System.Drawing.Point(301, 108)
      Me.ckbListaPrecios.Name = "ckbListaPrecios"
      Me.ckbListaPrecios.Size = New System.Drawing.Size(101, 17)
      Me.ckbListaPrecios.TabIndex = 16
      Me.ckbListaPrecios.Text = "Lista de Precios"
      Me.ckbListaPrecios.UseVisualStyleBackColor = True
      '
      'tspFacturacion
      '
      Me.tspFacturacion.ImageScalingSize = New System.Drawing.Size(22, 22)
      Me.tspFacturacion.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsbRefrescar, Me.ToolStripSeparator4, Me.tsbImprimir, Me.ToolStripSeparator1, Me.tsbSalir, Me.ToolStripSeparator3})
      Me.tspFacturacion.Location = New System.Drawing.Point(0, 0)
      Me.tspFacturacion.Name = "tspFacturacion"
      Me.tspFacturacion.Size = New System.Drawing.Size(625, 29)
      Me.tspFacturacion.TabIndex = 17
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
      'tsbImprimir
      '
      Me.tsbImprimir.Enabled = False
      Me.tsbImprimir.Image = Global.Eniac.Win.My.Resources.Resources.printer_32
      Me.tsbImprimir.ImageTransparentColor = System.Drawing.Color.Magenta
      Me.tsbImprimir.Name = "tsbImprimir"
      Me.tsbImprimir.Size = New System.Drawing.Size(79, 26)
      Me.tsbImprimir.Text = "Imprimir"
      Me.tsbImprimir.ToolTipText = "Imprimir"
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
      'dgvDetalle
      '
      Appearance1.BackColor = System.Drawing.SystemColors.Window
      Appearance1.BorderColor = System.Drawing.SystemColors.InactiveCaption
      Me.dgvDetalle.DisplayLayout.Appearance = Appearance1
      UltraGridColumn1.Header.VisiblePosition = 0
      UltraGridColumn1.Hidden = True
      UltraGridColumn2.Header.VisiblePosition = 1
      UltraGridColumn2.Hidden = True
      UltraGridColumn3.Header.Caption = "Cliente"
      UltraGridColumn3.Header.VisiblePosition = 2
      UltraGridColumn3.Width = 265
      UltraGridColumn4.Header.VisiblePosition = 3
      UltraGridColumn4.Hidden = True
      UltraGridColumn5.Header.Caption = "Marca"
      UltraGridColumn5.Header.VisiblePosition = 4
      UltraGridColumn5.Width = 152
      UltraGridColumn6.Header.VisiblePosition = 5
      UltraGridColumn6.Hidden = True
      UltraGridColumn7.Header.Caption = "Lista Precios"
      UltraGridColumn7.Header.VisiblePosition = 6
      UltraGridColumn7.Width = 169
      UltraGridBand1.Columns.AddRange(New Object() {UltraGridColumn1, UltraGridColumn2, UltraGridColumn3, UltraGridColumn4, UltraGridColumn5, UltraGridColumn6, UltraGridColumn7})
      Appearance2.FontData.BoldAsString = "True"
      Appearance2.FontData.SizeInPoints = 6.0!
      UltraGridBand1.Header.Appearance = Appearance2
      Me.dgvDetalle.DisplayLayout.BandsSerializer.Add(UltraGridBand1)
      Me.dgvDetalle.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.None
      Me.dgvDetalle.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.[False]
      Appearance3.BackColor = System.Drawing.SystemColors.ActiveBorder
      Appearance3.BackColor2 = System.Drawing.SystemColors.ControlDark
      Appearance3.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
      Appearance3.BorderColor = System.Drawing.SystemColors.Window
      Me.dgvDetalle.DisplayLayout.GroupByBox.Appearance = Appearance3
      Appearance4.ForeColor = System.Drawing.SystemColors.GrayText
      Me.dgvDetalle.DisplayLayout.GroupByBox.BandLabelAppearance = Appearance4
      Me.dgvDetalle.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
      Me.dgvDetalle.DisplayLayout.GroupByBox.Prompt = "Arrastrar la columna que desea agrupar"
      Appearance5.BackColor = System.Drawing.SystemColors.ControlLightLight
      Appearance5.BackColor2 = System.Drawing.SystemColors.Control
      Appearance5.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
      Appearance5.ForeColor = System.Drawing.SystemColors.GrayText
      Me.dgvDetalle.DisplayLayout.GroupByBox.PromptAppearance = Appearance5
      Me.dgvDetalle.DisplayLayout.MaxColScrollRegions = 1
      Me.dgvDetalle.DisplayLayout.MaxRowScrollRegions = 1
      Appearance6.BackColor = System.Drawing.SystemColors.Window
      Appearance6.ForeColor = System.Drawing.SystemColors.ControlText
      Me.dgvDetalle.DisplayLayout.Override.ActiveCellAppearance = Appearance6
      Appearance7.BackColor = System.Drawing.SystemColors.Highlight
      Appearance7.ForeColor = System.Drawing.SystemColors.HighlightText
      Me.dgvDetalle.DisplayLayout.Override.ActiveRowAppearance = Appearance7
      Me.dgvDetalle.DisplayLayout.Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.No
      Me.dgvDetalle.DisplayLayout.Override.AllowColMoving = Infragistics.Win.UltraWinGrid.AllowColMoving.NotAllowed
      Me.dgvDetalle.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.[False]
      Me.dgvDetalle.DisplayLayout.Override.AllowUpdate = Infragistics.Win.DefaultableBoolean.[False]
      Me.dgvDetalle.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted
      Me.dgvDetalle.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted
      Appearance8.BackColor = System.Drawing.SystemColors.Window
      Me.dgvDetalle.DisplayLayout.Override.CardAreaAppearance = Appearance8
      Appearance9.BorderColor = System.Drawing.Color.Silver
      Appearance9.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter
      Me.dgvDetalle.DisplayLayout.Override.CellAppearance = Appearance9
      Me.dgvDetalle.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText
      Me.dgvDetalle.DisplayLayout.Override.CellPadding = 0
      Appearance10.BackColor = System.Drawing.Color.Transparent
      Appearance10.BackColor2 = System.Drawing.Color.Transparent
      Appearance10.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element
      Appearance10.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
      Appearance10.BorderColor = System.Drawing.SystemColors.Window
      Appearance10.FontData.BoldAsString = "True"
      Appearance10.FontData.SizeInPoints = 9.0!
      Me.dgvDetalle.DisplayLayout.Override.GroupByRowAppearance = Appearance10
      Appearance11.TextHAlignAsString = "Left"
      Me.dgvDetalle.DisplayLayout.Override.HeaderAppearance = Appearance11
      Me.dgvDetalle.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
      Me.dgvDetalle.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand
      Appearance12.BackColor = System.Drawing.SystemColors.Window
      Appearance12.BorderColor = System.Drawing.Color.Silver
      Me.dgvDetalle.DisplayLayout.Override.RowAppearance = Appearance12
      Me.dgvDetalle.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[False]
      Appearance13.BackColor = System.Drawing.SystemColors.ControlLight
      Me.dgvDetalle.DisplayLayout.Override.TemplateAddRowAppearance = Appearance13
      Me.dgvDetalle.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill
      Me.dgvDetalle.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate
      Me.dgvDetalle.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy
      Me.dgvDetalle.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.dgvDetalle.Location = New System.Drawing.Point(10, 196)
      Me.dgvDetalle.Name = "dgvDetalle"
      Me.dgvDetalle.Size = New System.Drawing.Size(603, 305)
      Me.dgvDetalle.TabIndex = 18
      Me.dgvDetalle.Text = "UltraGrid1"
      '
      'chkExpandAll
      '
      Me.chkExpandAll.Enabled = False
      Me.chkExpandAll.Location = New System.Drawing.Point(15, 160)
      Me.chkExpandAll.Name = "chkExpandAll"
      Me.chkExpandAll.Size = New System.Drawing.Size(122, 16)
      Me.chkExpandAll.TabIndex = 54
      Me.chkExpandAll.Text = "Expandir Filas"
      '
      'UltraGridPrintDocument1
      '
      Me.UltraGridPrintDocument1.Grid = Me.dgvDetalle
      Me.UltraGridPrintDocument1.Page.Margins.Bottom = 2
      Me.UltraGridPrintDocument1.Page.Margins.Left = 2
      Me.UltraGridPrintDocument1.Page.Margins.Right = 2
      Me.UltraGridPrintDocument1.Page.Margins.Top = 2
      Me.UltraGridPrintDocument1.PageBody.Margins.Bottom = 2
      Me.UltraGridPrintDocument1.PageBody.Margins.Left = 2
      Me.UltraGridPrintDocument1.PageBody.Margins.Right = 2
      Me.UltraGridPrintDocument1.PageBody.Margins.Top = 2
      '
      'UltraPrintPreviewDialog1
      '
      Me.UltraPrintPreviewDialog1.Document = Me.UltraGridPrintDocument1
      Me.UltraPrintPreviewDialog1.Name = "UltraPrintPreviewDialog1"
      '
      'ConsultarClienteMarcaLDePrecio
      '
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.ClientSize = New System.Drawing.Size(625, 513)
      Me.Controls.Add(Me.chkExpandAll)
      Me.Controls.Add(Me.dgvDetalle)
      Me.Controls.Add(Me.tspFacturacion)
      Me.Controls.Add(Me.ckbListaPrecios)
      Me.Controls.Add(Me.ckbMarca)
      Me.Controls.Add(Me.btnConsultar)
      Me.Controls.Add(Me.bscMarca)
      Me.Controls.Add(Me.grbCliente)
      Me.KeyPreview = True
      Me.Name = "ConsultarClienteMarcaLDePrecio"
      Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
      Me.Text = "Consultar Listas de Precios/Marca a Clientes"
      Me.grbCliente.ResumeLayout(False)
      Me.grbCliente.PerformLayout()
      Me.tspFacturacion.ResumeLayout(False)
      Me.tspFacturacion.PerformLayout()
      CType(Me.dgvDetalle, System.ComponentModel.ISupportInitialize).EndInit()
      Me.ResumeLayout(False)
      Me.PerformLayout()

   End Sub
   Friend WithEvents bscMarca As Eniac.Controles.Buscador
   Friend WithEvents grbCliente As System.Windows.Forms.GroupBox
   Friend WithEvents lblNombre As Eniac.Controles.Label
   Friend WithEvents lblCodigoCliente As Eniac.Controles.Label
   Friend WithEvents bscCliente As Eniac.Controles.Buscador
   Friend WithEvents bscCodigoCliente As Eniac.Controles.Buscador
   Friend WithEvents btnConsultar As Eniac.Controles.Button
   Friend WithEvents ckbMarca As System.Windows.Forms.CheckBox
   Friend WithEvents ckbListaPrecios As System.Windows.Forms.CheckBox
   Friend WithEvents chbCliente As System.Windows.Forms.CheckBox
   Friend WithEvents tspFacturacion As System.Windows.Forms.ToolStrip
   Public WithEvents tsbRefrescar As System.Windows.Forms.ToolStripButton
   Friend WithEvents ToolStripSeparator4 As System.Windows.Forms.ToolStripSeparator
   Friend WithEvents tsbImprimir As System.Windows.Forms.ToolStripButton
   Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
   Friend WithEvents tsbSalir As System.Windows.Forms.ToolStripButton
   Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
   Friend WithEvents dgvDetalle As Infragistics.Win.UltraWinGrid.UltraGrid
   Friend WithEvents chkExpandAll As System.Windows.Forms.CheckBox
   Friend WithEvents UltraGridPrintDocument1 As Infragistics.Win.UltraWinGrid.UltraGridPrintDocument
   Friend WithEvents UltraPrintPreviewDialog1 As Infragistics.Win.Printing.UltraPrintPreviewDialog
   Friend WithEvents cmbListasDePrecios As Eniac.Controles.ComboBox
End Class
