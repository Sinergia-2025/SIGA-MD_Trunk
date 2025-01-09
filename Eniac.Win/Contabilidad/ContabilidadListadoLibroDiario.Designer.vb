<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ContabilidadListadoLibroDiario
   Inherits Eniac.Win.BaseForm

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
      Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ContabilidadListadoLibroDiario))
      Dim Appearance1 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridBand1 As Infragistics.Win.UltraWinGrid.UltraGridBand = New Infragistics.Win.UltraWinGrid.UltraGridBand("Band 0", -1)
      Dim UltraGridColumn1 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdPlanCuenta")
      Dim Appearance2 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn2 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdAsiento")
      Dim Appearance3 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn3 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreAsiento", -1, Nothing, 1, Infragistics.Win.UltraWinGrid.SortIndicator.Ascending, True)
      Dim UltraGridColumn4 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("FechaAsiento", -1, Nothing, 0, Infragistics.Win.UltraWinGrid.SortIndicator.Ascending, True)
      Dim Appearance4 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn5 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdCuenta")
      Dim Appearance5 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn6 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreCuenta")
      Dim UltraGridColumn7 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Debe")
      Dim Appearance6 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn8 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Haber")
      Dim Appearance7 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim SummarySettings1 As Infragistics.Win.UltraWinGrid.SummarySettings = New Infragistics.Win.UltraWinGrid.SummarySettings("", Infragistics.Win.UltraWinGrid.SummaryType.Sum, Nothing, "Debe", 6, True, "Band 0", 0, Infragistics.Win.UltraWinGrid.SummaryPosition.UseSummaryPositionColumn, Nothing, -1, False)
      Dim Appearance8 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim Appearance9 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim SummarySettings2 As Infragistics.Win.UltraWinGrid.SummarySettings = New Infragistics.Win.UltraWinGrid.SummarySettings("", Infragistics.Win.UltraWinGrid.SummaryType.Sum, Nothing, "Haber", 7, True, "Band 0", 0, Infragistics.Win.UltraWinGrid.SummaryPosition.UseSummaryPositionColumn, Nothing, -1, False)
      Dim Appearance10 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim Appearance11 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim Appearance12 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim Appearance13 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim Appearance14 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim Appearance15 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim Appearance16 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim Appearance17 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim Appearance18 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim Appearance19 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim Appearance20 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim Appearance21 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim Appearance22 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Me.fraFiltros = New System.Windows.Forms.GroupBox()
      Me.dtpDesde = New Eniac.Controles.DateTimePicker()
      Me.lbldesde = New Eniac.Controles.Label()
      Me.dtpHasta = New Eniac.Controles.DateTimePicker()
      Me.lblHasta = New Eniac.Controles.Label()
      Me.cmbPlan = New Eniac.Controles.ComboBox()
      Me.lblPlan = New Eniac.Controles.Label()
      Me.btnConsultar = New Eniac.Controles.Button()
      Me.Label3 = New Eniac.Controles.Label()
      Me.clbSucursales = New Eniac.Controles.CheckedListBox()
      Me.stsStado = New System.Windows.Forms.StatusStrip()
      Me.tssInfo = New System.Windows.Forms.ToolStripStatusLabel()
      Me.tspBarra = New System.Windows.Forms.ToolStripProgressBar()
      Me.tssRegistros = New System.Windows.Forms.ToolStripStatusLabel()
      Me.tstBarra = New System.Windows.Forms.ToolStrip()
      Me.toolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
      Me.tsbRefrescar = New System.Windows.Forms.ToolStripButton()
      Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
      Me.tsbImprimir = New System.Windows.Forms.ToolStripButton()
      Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
      Me.tsbSalir = New System.Windows.Forms.ToolStripButton()
      Me.ugDetalle = New Infragistics.Win.UltraWinGrid.UltraGrid()
      Me.fraFiltros.SuspendLayout()
      Me.stsStado.SuspendLayout()
      Me.tstBarra.SuspendLayout()
      CType(Me.ugDetalle, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.SuspendLayout()
      '
      'fraFiltros
      '
      Me.fraFiltros.Controls.Add(Me.dtpDesde)
      Me.fraFiltros.Controls.Add(Me.lbldesde)
      Me.fraFiltros.Controls.Add(Me.dtpHasta)
      Me.fraFiltros.Controls.Add(Me.lblHasta)
      Me.fraFiltros.Controls.Add(Me.cmbPlan)
      Me.fraFiltros.Controls.Add(Me.btnConsultar)
      Me.fraFiltros.Controls.Add(Me.lblPlan)
      Me.fraFiltros.Controls.Add(Me.Label3)
      Me.fraFiltros.Controls.Add(Me.clbSucursales)
      Me.fraFiltros.Location = New System.Drawing.Point(12, 32)
      Me.fraFiltros.Name = "fraFiltros"
      Me.fraFiltros.Size = New System.Drawing.Size(702, 102)
      Me.fraFiltros.TabIndex = 0
      Me.fraFiltros.TabStop = False
      Me.fraFiltros.Text = "Filtros"
      '
      'dtpDesde
      '
      Me.dtpDesde.BindearPropiedadControl = ""
      Me.dtpDesde.BindearPropiedadEntidad = ""
      Me.dtpDesde.Checked = False
      Me.dtpDesde.CustomFormat = "dd/MM/yyyy"
      Me.dtpDesde.ForeColorFocus = System.Drawing.Color.Red
      Me.dtpDesde.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.dtpDesde.Format = System.Windows.Forms.DateTimePickerFormat.Custom
      Me.dtpDesde.IsPK = False
      Me.dtpDesde.IsRequired = False
      Me.dtpDesde.Key = ""
      Me.dtpDesde.LabelAsoc = Me.lbldesde
      Me.dtpDesde.Location = New System.Drawing.Point(386, 19)
      Me.dtpDesde.Name = "dtpDesde"
      Me.dtpDesde.ShowCheckBox = True
      Me.dtpDesde.Size = New System.Drawing.Size(97, 20)
      Me.dtpDesde.TabIndex = 5
      Me.dtpDesde.Value = New Date(2011, 10, 6, 0, 0, 0, 0)
      '
      'lbldesde
      '
      Me.lbldesde.AutoSize = True
      Me.lbldesde.ForeColor = System.Drawing.SystemColors.WindowText
      Me.lbldesde.Location = New System.Drawing.Point(309, 23)
      Me.lbldesde.Name = "lbldesde"
      Me.lbldesde.Size = New System.Drawing.Size(71, 13)
      Me.lbldesde.TabIndex = 4
      Me.lbldesde.Text = "Fecha Desde"
      '
      'dtpHasta
      '
      Me.dtpHasta.BindearPropiedadControl = ""
      Me.dtpHasta.BindearPropiedadEntidad = ""
      Me.dtpHasta.CustomFormat = "dd/MM/yyyy"
      Me.dtpHasta.ForeColorFocus = System.Drawing.Color.Red
      Me.dtpHasta.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.dtpHasta.Format = System.Windows.Forms.DateTimePickerFormat.Custom
      Me.dtpHasta.IsPK = False
      Me.dtpHasta.IsRequired = False
      Me.dtpHasta.Key = ""
      Me.dtpHasta.LabelAsoc = Me.lblHasta
      Me.dtpHasta.Location = New System.Drawing.Point(545, 19)
      Me.dtpHasta.Name = "dtpHasta"
      Me.dtpHasta.ShowCheckBox = True
      Me.dtpHasta.Size = New System.Drawing.Size(97, 20)
      Me.dtpHasta.TabIndex = 7
      Me.dtpHasta.Value = New Date(2012, 7, 2, 23, 27, 0, 0)
      '
      'lblHasta
      '
      Me.lblHasta.AutoSize = True
      Me.lblHasta.Location = New System.Drawing.Point(502, 23)
      Me.lblHasta.Name = "lblHasta"
      Me.lblHasta.Size = New System.Drawing.Size(35, 13)
      Me.lblHasta.TabIndex = 6
      Me.lblHasta.Text = "Hasta"
      '
      'cmbPlan
      '
      Me.cmbPlan.BindearPropiedadControl = "SelectedValue"
      Me.cmbPlan.BindearPropiedadEntidad = "IdPlanCuenta"
      Me.cmbPlan.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cmbPlan.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.cmbPlan.ForeColorFocus = System.Drawing.Color.Red
      Me.cmbPlan.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.cmbPlan.FormattingEnabled = True
      Me.cmbPlan.IsPK = False
      Me.cmbPlan.IsRequired = True
      Me.cmbPlan.Key = Nothing
      Me.cmbPlan.LabelAsoc = Me.lblPlan
      Me.cmbPlan.Location = New System.Drawing.Point(97, 75)
      Me.cmbPlan.Name = "cmbPlan"
      Me.cmbPlan.Size = New System.Drawing.Size(196, 21)
      Me.cmbPlan.TabIndex = 3
      '
      'lblPlan
      '
      Me.lblPlan.AutoSize = True
      Me.lblPlan.Location = New System.Drawing.Point(11, 79)
      Me.lblPlan.Name = "lblPlan"
      Me.lblPlan.Size = New System.Drawing.Size(80, 13)
      Me.lblPlan.TabIndex = 2
      Me.lblPlan.Text = "Plan de Cuenta"
      '
      'btnConsultar
      '
      Me.btnConsultar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.btnConsultar.Image = CType(resources.GetObject("btnConsultar.Image"), System.Drawing.Image)
      Me.btnConsultar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
      Me.btnConsultar.Location = New System.Drawing.Point(596, 51)
      Me.btnConsultar.Name = "btnConsultar"
      Me.btnConsultar.Size = New System.Drawing.Size(100, 45)
      Me.btnConsultar.TabIndex = 8
      Me.btnConsultar.Text = "&Consultar"
      Me.btnConsultar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      Me.btnConsultar.UseVisualStyleBackColor = True
      '
      'Label3
      '
      Me.Label3.AutoSize = True
      Me.Label3.Location = New System.Drawing.Point(11, 19)
      Me.Label3.Name = "Label3"
      Me.Label3.Size = New System.Drawing.Size(59, 13)
      Me.Label3.TabIndex = 0
      Me.Label3.Text = "Sucursales"
      '
      'clbSucursales
      '
      Me.clbSucursales.CheckOnClick = True
      Me.clbSucursales.FormattingEnabled = True
      Me.clbSucursales.Location = New System.Drawing.Point(97, 19)
      Me.clbSucursales.Name = "clbSucursales"
      Me.clbSucursales.Size = New System.Drawing.Size(196, 49)
      Me.clbSucursales.TabIndex = 1
      '
      'stsStado
      '
      Me.stsStado.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tssInfo, Me.tspBarra, Me.tssRegistros})
      Me.stsStado.Location = New System.Drawing.Point(0, 478)
      Me.stsStado.Name = "stsStado"
      Me.stsStado.Size = New System.Drawing.Size(726, 22)
      Me.stsStado.TabIndex = 2
      Me.stsStado.Text = "statusStrip1"
      '
      'tssInfo
      '
      Me.tssInfo.Name = "tssInfo"
      Me.tssInfo.Size = New System.Drawing.Size(647, 17)
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
      'tstBarra
      '
      Me.tstBarra.AllowItemReorder = True
      Me.tstBarra.ImageScalingSize = New System.Drawing.Size(22, 22)
      Me.tstBarra.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.toolStripSeparator3, Me.tsbRefrescar, Me.ToolStripSeparator1, Me.tsbImprimir, Me.ToolStripSeparator2, Me.tsbSalir})
      Me.tstBarra.Location = New System.Drawing.Point(0, 0)
      Me.tstBarra.Name = "tstBarra"
      Me.tstBarra.Size = New System.Drawing.Size(726, 29)
      Me.tstBarra.TabIndex = 3
      Me.tstBarra.Text = "toolStrip1"
      '
      'toolStripSeparator3
      '
      Me.toolStripSeparator3.Name = "toolStripSeparator3"
      Me.toolStripSeparator3.Size = New System.Drawing.Size(6, 29)
      '
      'tsbRefrescar
      '
      Me.tsbRefrescar.Image = CType(resources.GetObject("tsbRefrescar.Image"), System.Drawing.Image)
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
      'tsbImprimir
      '
      Me.tsbImprimir.Image = CType(resources.GetObject("tsbImprimir.Image"), System.Drawing.Image)
      Me.tsbImprimir.ImageTransparentColor = System.Drawing.Color.Magenta
      Me.tsbImprimir.Name = "tsbImprimir"
      Me.tsbImprimir.Size = New System.Drawing.Size(79, 26)
      Me.tsbImprimir.Text = "&Imprimir"
      Me.tsbImprimir.ToolTipText = "Imprimir y Grabar (F4)"
      '
      'ToolStripSeparator2
      '
      Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
      Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 29)
      '
      'tsbSalir
      '
      Me.tsbSalir.Image = CType(resources.GetObject("tsbSalir.Image"), System.Drawing.Image)
      Me.tsbSalir.ImageTransparentColor = System.Drawing.Color.Magenta
      Me.tsbSalir.Name = "tsbSalir"
      Me.tsbSalir.Size = New System.Drawing.Size(65, 26)
      Me.tsbSalir.Text = "&Cerrar"
      Me.tsbSalir.ToolTipText = "Cerrar el formulario"
      '
      'ugDetalle
      '
      Me.ugDetalle.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Appearance1.BackColor = System.Drawing.SystemColors.Window
      Appearance1.BorderColor = System.Drawing.SystemColors.InactiveCaption
      Me.ugDetalle.DisplayLayout.Appearance = Appearance1
      Me.ugDetalle.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ResizeAllColumns
      Appearance2.TextHAlignAsString = "Right"
      UltraGridColumn1.CellAppearance = Appearance2
      UltraGridColumn1.Header.Caption = "P."
      UltraGridColumn1.Header.VisiblePosition = 0
      UltraGridColumn1.Hidden = True
      UltraGridColumn1.Width = 25
      Appearance3.TextHAlignAsString = "Right"
      UltraGridColumn2.CellAppearance = Appearance3
      UltraGridColumn2.Header.Caption = "Nro. Asiento"
      UltraGridColumn2.Header.VisiblePosition = 1
      UltraGridColumn2.Width = 80
      UltraGridColumn3.Header.Caption = "Asiento"
      UltraGridColumn3.Header.VisiblePosition = 2
      UltraGridColumn3.Width = 250
      Appearance4.TextHAlignAsString = "Center"
      UltraGridColumn4.CellAppearance = Appearance4
      UltraGridColumn4.Format = "dd/MM/yyyy"
      UltraGridColumn4.Header.Caption = "Fecha"
      UltraGridColumn4.Header.VisiblePosition = 3
      UltraGridColumn4.HiddenWhenGroupBy = Infragistics.Win.DefaultableBoolean.[False]
      UltraGridColumn4.MaskInput = "{LOC}dd/mm/yyyy"
      UltraGridColumn4.Width = 80
      Appearance5.TextHAlignAsString = "Right"
      UltraGridColumn5.CellAppearance = Appearance5
      UltraGridColumn5.Header.Caption = "Nro. Cuenta"
      UltraGridColumn5.Header.VisiblePosition = 4
      UltraGridColumn5.Width = 80
      UltraGridColumn6.Header.Caption = "Cuenta"
      UltraGridColumn6.Header.VisiblePosition = 5
      UltraGridColumn6.Width = 250
      Appearance6.TextHAlignAsString = "Right"
      UltraGridColumn7.CellAppearance = Appearance6
      UltraGridColumn7.Header.VisiblePosition = 6
      UltraGridColumn7.Width = 90
      Appearance7.TextHAlignAsString = "Right"
      UltraGridColumn8.CellAppearance = Appearance7
      UltraGridColumn8.Header.VisiblePosition = 7
      UltraGridColumn8.Width = 90
      UltraGridBand1.Columns.AddRange(New Object() {UltraGridColumn1, UltraGridColumn2, UltraGridColumn3, UltraGridColumn4, UltraGridColumn5, UltraGridColumn6, UltraGridColumn7, UltraGridColumn8})
      Appearance8.TextHAlignAsString = "Right"
      SummarySettings1.Appearance = Appearance8
      SummarySettings1.DisplayFormat = "{0:N2}"
      SummarySettings1.GroupBySummaryValueAppearance = Appearance9
      SummarySettings1.SummaryDisplayArea = CType((Infragistics.Win.UltraWinGrid.SummaryDisplayAreas.BottomFixed Or Infragistics.Win.UltraWinGrid.SummaryDisplayAreas.GroupByRowsFooter), Infragistics.Win.UltraWinGrid.SummaryDisplayAreas)
      Appearance10.TextHAlignAsString = "Right"
      SummarySettings2.Appearance = Appearance10
      SummarySettings2.DisplayFormat = "{0:N2}"
      SummarySettings2.GroupBySummaryValueAppearance = Appearance11
      SummarySettings2.SummaryDisplayArea = CType((Infragistics.Win.UltraWinGrid.SummaryDisplayAreas.BottomFixed Or Infragistics.Win.UltraWinGrid.SummaryDisplayAreas.GroupByRowsFooter), Infragistics.Win.UltraWinGrid.SummaryDisplayAreas)
      UltraGridBand1.Summaries.AddRange(New Infragistics.Win.UltraWinGrid.SummarySettings() {SummarySettings1, SummarySettings2})
      UltraGridBand1.SummaryFooterCaption = "Total"
      Me.ugDetalle.DisplayLayout.BandsSerializer.Add(UltraGridBand1)
      Me.ugDetalle.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
      Me.ugDetalle.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.[False]
      Appearance12.BackColor = System.Drawing.SystemColors.ActiveBorder
      Appearance12.BackColor2 = System.Drawing.SystemColors.ControlDark
      Appearance12.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
      Appearance12.BorderColor = System.Drawing.SystemColors.Window
      Me.ugDetalle.DisplayLayout.GroupByBox.Appearance = Appearance12
      Appearance13.ForeColor = System.Drawing.SystemColors.GrayText
      Me.ugDetalle.DisplayLayout.GroupByBox.BandLabelAppearance = Appearance13
      Me.ugDetalle.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
      Appearance14.BackColor = System.Drawing.SystemColors.ControlLightLight
      Appearance14.BackColor2 = System.Drawing.SystemColors.Control
      Appearance14.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
      Appearance14.ForeColor = System.Drawing.SystemColors.GrayText
      Me.ugDetalle.DisplayLayout.GroupByBox.PromptAppearance = Appearance14
      Me.ugDetalle.DisplayLayout.MaxColScrollRegions = 1
      Me.ugDetalle.DisplayLayout.MaxRowScrollRegions = 1
      Appearance15.BackColor = System.Drawing.SystemColors.Window
      Appearance15.ForeColor = System.Drawing.SystemColors.ControlText
      Me.ugDetalle.DisplayLayout.Override.ActiveCellAppearance = Appearance15
      Appearance16.BackColor = System.Drawing.SystemColors.Highlight
      Appearance16.ForeColor = System.Drawing.SystemColors.HighlightText
      Me.ugDetalle.DisplayLayout.Override.ActiveRowAppearance = Appearance16
      Me.ugDetalle.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted
      Me.ugDetalle.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted
      Appearance17.BackColor = System.Drawing.SystemColors.Window
      Me.ugDetalle.DisplayLayout.Override.CardAreaAppearance = Appearance17
      Appearance18.BorderColor = System.Drawing.Color.Silver
      Appearance18.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter
      Me.ugDetalle.DisplayLayout.Override.CellAppearance = Appearance18
      Me.ugDetalle.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText
      Me.ugDetalle.DisplayLayout.Override.CellPadding = 0
      Appearance19.BackColor = System.Drawing.SystemColors.Control
      Appearance19.BackColor2 = System.Drawing.SystemColors.ControlDark
      Appearance19.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element
      Appearance19.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
      Appearance19.BorderColor = System.Drawing.SystemColors.Window
      Me.ugDetalle.DisplayLayout.Override.GroupByRowAppearance = Appearance19
      Appearance20.TextHAlignAsString = "Left"
      Me.ugDetalle.DisplayLayout.Override.HeaderAppearance = Appearance20
      Me.ugDetalle.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
      Me.ugDetalle.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand
      Appearance21.BackColor = System.Drawing.SystemColors.Window
      Appearance21.BorderColor = System.Drawing.Color.Silver
      Me.ugDetalle.DisplayLayout.Override.RowAppearance = Appearance21
      Me.ugDetalle.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[False]
      Appearance22.BackColor = System.Drawing.SystemColors.ControlLight
      Me.ugDetalle.DisplayLayout.Override.TemplateAddRowAppearance = Appearance22
      Me.ugDetalle.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill
      Me.ugDetalle.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate
      Me.ugDetalle.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy
      Me.ugDetalle.Location = New System.Drawing.Point(12, 140)
      Me.ugDetalle.Name = "ugDetalle"
      Me.ugDetalle.Size = New System.Drawing.Size(702, 335)
      Me.ugDetalle.TabIndex = 1
      Me.ugDetalle.Text = "UltraGrid1"
      '
      'ContabilidadListadoLibroDiario
      '
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.ClientSize = New System.Drawing.Size(726, 500)
      Me.Controls.Add(Me.ugDetalle)
      Me.Controls.Add(Me.stsStado)
      Me.Controls.Add(Me.tstBarra)
      Me.Controls.Add(Me.fraFiltros)
      Me.KeyPreview = True
      Me.Name = "ContabilidadListadoLibroDiario"
      Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
      Me.Text = "Libro Diario"
      Me.fraFiltros.ResumeLayout(False)
      Me.fraFiltros.PerformLayout()
      Me.stsStado.ResumeLayout(False)
      Me.stsStado.PerformLayout()
      Me.tstBarra.ResumeLayout(False)
      Me.tstBarra.PerformLayout()
      CType(Me.ugDetalle, System.ComponentModel.ISupportInitialize).EndInit()
      Me.ResumeLayout(False)
      Me.PerformLayout()

   End Sub
   Friend WithEvents fraFiltros As System.Windows.Forms.GroupBox
   Friend WithEvents dtpHasta As Eniac.Controles.DateTimePicker
   Friend WithEvents lblHasta As Eniac.Controles.Label
   Friend WithEvents cmbPlan As Eniac.Controles.ComboBox
   Friend WithEvents lblPlan As Eniac.Controles.Label
   Friend WithEvents btnConsultar As Eniac.Controles.Button
   Friend WithEvents Label3 As Eniac.Controles.Label
   Friend WithEvents clbSucursales As Eniac.Controles.CheckedListBox
   Protected Friend WithEvents stsStado As System.Windows.Forms.StatusStrip
   Protected Friend WithEvents tssInfo As System.Windows.Forms.ToolStripStatusLabel
   Protected Friend WithEvents tspBarra As System.Windows.Forms.ToolStripProgressBar
   Protected WithEvents tssRegistros As System.Windows.Forms.ToolStripStatusLabel
   Public WithEvents tstBarra As System.Windows.Forms.ToolStrip
   Private WithEvents toolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
   Public WithEvents tsbRefrescar As System.Windows.Forms.ToolStripButton
   Private WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
   Friend WithEvents tsbImprimir As System.Windows.Forms.ToolStripButton
   Private WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
   Public WithEvents tsbSalir As System.Windows.Forms.ToolStripButton
   Friend WithEvents ugDetalle As Infragistics.Win.UltraWinGrid.UltraGrid
   Friend WithEvents dtpDesde As Eniac.Controles.DateTimePicker
   Friend WithEvents lbldesde As Eniac.Controles.Label
End Class
