﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ConsultarCtaCteProveedoresDH
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
      Me.components = New System.ComponentModel.Container()
      Dim Appearance1 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridBand1 As Infragistics.Win.UltraWinGrid.UltraGridBand = New Infragistics.Win.UltraWinGrid.UltraGridBand("Band 0", -1)
      Dim UltraGridColumn1 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Ver")
      Dim UltraGridColumn2 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdSucursal")
      Dim Appearance2 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn3 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdTipoComprobante")
      Dim UltraGridColumn4 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Letra")
      Dim Appearance3 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim Appearance4 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn5 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("CentroEmisor")
      Dim Appearance5 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn6 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NumeroComprobante")
      Dim Appearance6 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn7 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Fecha")
      Dim Appearance7 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim Appearance8 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn8 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("FechaVencimiento")
      Dim Appearance9 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim Appearance10 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn9 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Debe")
      Dim Appearance11 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn10 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Haber")
      Dim Appearance12 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn11 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Saldo")
      Dim Appearance13 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn12 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Observacion")
        Dim UltraGridColumn14 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("PeriodoFiscal", 0)
        Dim Appearance14 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance15 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance16 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance17 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance18 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance19 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance20 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance21 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance22 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance23 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance24 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance25 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ConsultarCtaCteProveedoresDH))
        Me.UltraGridExcelExporter1 = New Infragistics.Win.UltraWinGrid.ExcelExport.UltraGridExcelExporter(Me.components)
        Me.UltraGridDocumentExporter1 = New Infragistics.Win.UltraWinGrid.DocumentExport.UltraGridDocumentExporter(Me.components)
        Me.dgvDetalle = New Infragistics.Win.UltraWinGrid.UltraGrid()
        Me.txtSaldoFin = New Eniac.Controles.TextBox()
        Me.Label1 = New Eniac.Controles.Label()
        Me.stsStado = New System.Windows.Forms.StatusStrip()
        Me.tssInfo = New System.Windows.Forms.ToolStripStatusLabel()
        Me.tspBarra = New System.Windows.Forms.ToolStripProgressBar()
        Me.tssRegistros = New System.Windows.Forms.ToolStripStatusLabel()
        Me.txtSaldoFinal = New Eniac.Controles.TextBox()
        Me.lblSaldoFinal = New Eniac.Controles.Label()
        Me.txtSaldoActual = New Eniac.Controles.TextBox()
        Me.lblSaldoActual = New Eniac.Controles.Label()
        Me.txtSaldoInicial = New Eniac.Controles.TextBox()
        Me.lblSaldoInicial = New Eniac.Controles.Label()
        Me.grbFiltros = New System.Windows.Forms.GroupBox()
        Me.bscCodigoProveedor = New Eniac.Controles.Buscador2()
        Me.lblCodigoProveedor = New Eniac.Controles.Label()
        Me.cmbSucursal = New Eniac.Win.ComboBoxSucursales()
        Me.lblSucursal = New Eniac.Controles.Label()
        Me.cmbGrabanLibro = New Eniac.Controles.ComboBox()
        Me.lblGrabanLibro = New Eniac.Controles.Label()
        Me.Label2 = New Eniac.Controles.Label()
        Me.bscProveedor = New Eniac.Controles.Buscador2()
        Me.lblNombre = New Eniac.Controles.Label()
        Me.chbVistaContable = New Eniac.Controles.CheckBox()
        Me.chbFechas = New Eniac.Controles.CheckBox()
        Me.dtpHasta = New Eniac.Controles.DateTimePicker()
        Me.lblHasta = New Eniac.Controles.Label()
        Me.dtpDesde = New Eniac.Controles.DateTimePicker()
        Me.lblDesde = New Eniac.Controles.Label()
        Me.btnConsultar = New Eniac.Controles.Button()
        Me.tstBarra = New System.Windows.Forms.ToolStrip()
        Me.tsbRefrescar = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsbImprimir = New System.Windows.Forms.ToolStripButton()
        Me.toolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsddExportar = New System.Windows.Forms.ToolStripDropDownButton()
        Me.tsmiAExcel = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsmiAPDF = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsbPreferencias = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsbSalir = New System.Windows.Forms.ToolStripButton()
        CType(Me.dgvDetalle, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.stsStado.SuspendLayout()
        Me.grbFiltros.SuspendLayout()
        Me.tstBarra.SuspendLayout()
        Me.SuspendLayout()
        '
        'dgvDetalle
        '
        Me.dgvDetalle.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Appearance1.BackColor = System.Drawing.SystemColors.Window
        Appearance1.BorderColor = System.Drawing.SystemColors.InactiveCaption
        Me.dgvDetalle.DisplayLayout.Appearance = Appearance1
        UltraGridColumn1.Header.VisiblePosition = 0
        UltraGridColumn1.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Button
        UltraGridColumn1.Width = 30
        Appearance2.TextHAlignAsString = "Center"
        UltraGridColumn2.FilterCellAppearance = Appearance2
        UltraGridColumn2.Header.Caption = "S"
        UltraGridColumn2.Header.VisiblePosition = 1
        UltraGridColumn2.Width = 20
        UltraGridColumn3.Header.Caption = "Comprobante"
        UltraGridColumn3.Header.VisiblePosition = 2
        UltraGridColumn3.Width = 130
        Appearance3.TextHAlignAsString = "Center"
        UltraGridColumn4.CellAppearance = Appearance3
        Appearance4.TextHAlignAsString = "Center"
        UltraGridColumn4.FilterCellAppearance = Appearance4
        UltraGridColumn4.Header.VisiblePosition = 3
        UltraGridColumn4.Width = 40
        Appearance5.TextHAlignAsString = "Right"
        UltraGridColumn5.CellAppearance = Appearance5
        UltraGridColumn5.Header.Caption = "Emisor"
        UltraGridColumn5.Header.VisiblePosition = 4
        UltraGridColumn5.Width = 60
        Appearance6.TextHAlignAsString = "Right"
        UltraGridColumn6.CellAppearance = Appearance6
        UltraGridColumn6.Header.Caption = "Numero"
        UltraGridColumn6.Header.VisiblePosition = 5
        UltraGridColumn6.Width = 65
        Appearance7.TextHAlignAsString = "Center"
        UltraGridColumn7.CellAppearance = Appearance7
        Appearance8.TextHAlignAsString = "Center"
        UltraGridColumn7.FilterCellAppearance = Appearance8
        UltraGridColumn7.Format = "dd/MM/yyyy"
        UltraGridColumn7.Header.Caption = "Emisión"
        UltraGridColumn7.Header.VisiblePosition = 6
        UltraGridColumn7.Width = 65
        Appearance9.TextHAlignAsString = "Center"
        UltraGridColumn8.CellAppearance = Appearance9
        Appearance10.TextHAlignAsString = "Center"
        UltraGridColumn8.FilterCellAppearance = Appearance10
        UltraGridColumn8.Format = "dd/MM/yyyy"
        UltraGridColumn8.Header.Caption = "Vencimiento"
        UltraGridColumn8.Header.VisiblePosition = 8
        UltraGridColumn8.Hidden = True
        Appearance11.TextHAlignAsString = "Right"
        UltraGridColumn9.CellAppearance = Appearance11
        UltraGridColumn9.Format = "N2"
        UltraGridColumn9.Header.VisiblePosition = 9
        UltraGridColumn9.Width = 75
        Appearance12.TextHAlignAsString = "Right"
        UltraGridColumn10.CellAppearance = Appearance12
        UltraGridColumn10.Format = "N2"
        UltraGridColumn10.Header.VisiblePosition = 10
        UltraGridColumn10.Width = 75
        Appearance13.TextHAlignAsString = "Right"
        UltraGridColumn11.CellAppearance = Appearance13
        UltraGridColumn11.Format = "N2"
        UltraGridColumn11.Header.VisiblePosition = 11
        UltraGridColumn11.Width = 75
        UltraGridColumn12.Header.VisiblePosition = 12
        UltraGridColumn12.Width = 230
        Appearance14.TextHAlignAsString = "Center"
        Appearance14.TextVAlignAsString = "Middle"
        UltraGridColumn14.CellAppearance = Appearance14
        UltraGridColumn14.Header.Caption = "Periodo Fiscal"
        UltraGridColumn14.Header.TextOrientation = New Infragistics.Win.TextOrientationInfo(0, Infragistics.Win.TextFlowDirection.Horizontal)
        UltraGridColumn14.Header.VisiblePosition = 7
        UltraGridBand1.Columns.AddRange(New Object() {UltraGridColumn1, UltraGridColumn2, UltraGridColumn3, UltraGridColumn4, UltraGridColumn5, UltraGridColumn6, UltraGridColumn7, UltraGridColumn8, UltraGridColumn9, UltraGridColumn10, UltraGridColumn11, UltraGridColumn12, UltraGridColumn14})
        Me.dgvDetalle.DisplayLayout.BandsSerializer.Add(UltraGridBand1)
        Me.dgvDetalle.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.dgvDetalle.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.[False]
        Appearance15.BackColor = System.Drawing.SystemColors.ActiveBorder
        Appearance15.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance15.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Appearance15.BorderColor = System.Drawing.SystemColors.Window
        Me.dgvDetalle.DisplayLayout.GroupByBox.Appearance = Appearance15
        Appearance16.ForeColor = System.Drawing.SystemColors.GrayText
        Me.dgvDetalle.DisplayLayout.GroupByBox.BandLabelAppearance = Appearance16
        Me.dgvDetalle.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.dgvDetalle.DisplayLayout.GroupByBox.Prompt = "Arrastre un título de columna aquí para agrupar."
        Appearance17.BackColor = System.Drawing.SystemColors.ControlLightLight
        Appearance17.BackColor2 = System.Drawing.SystemColors.Control
        Appearance17.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance17.ForeColor = System.Drawing.SystemColors.GrayText
        Me.dgvDetalle.DisplayLayout.GroupByBox.PromptAppearance = Appearance17
        Me.dgvDetalle.DisplayLayout.MaxColScrollRegions = 1
        Me.dgvDetalle.DisplayLayout.MaxRowScrollRegions = 1
        Appearance18.BackColor = System.Drawing.SystemColors.Window
        Appearance18.ForeColor = System.Drawing.SystemColors.ControlText
        Me.dgvDetalle.DisplayLayout.Override.ActiveCellAppearance = Appearance18
        Appearance19.BackColor = System.Drawing.SystemColors.Highlight
        Appearance19.ForeColor = System.Drawing.SystemColors.HighlightText
        Me.dgvDetalle.DisplayLayout.Override.ActiveRowAppearance = Appearance19
        Me.dgvDetalle.DisplayLayout.Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.No
        Me.dgvDetalle.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.[False]
        Me.dgvDetalle.DisplayLayout.Override.AllowUpdate = Infragistics.Win.DefaultableBoolean.[False]
        Me.dgvDetalle.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted
        Me.dgvDetalle.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted
        Appearance20.BackColor = System.Drawing.SystemColors.Window
        Me.dgvDetalle.DisplayLayout.Override.CardAreaAppearance = Appearance20
        Appearance21.BorderColor = System.Drawing.Color.Silver
        Appearance21.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter
        Me.dgvDetalle.DisplayLayout.Override.CellAppearance = Appearance21
        Me.dgvDetalle.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText
        Me.dgvDetalle.DisplayLayout.Override.CellPadding = 0
        Appearance22.BackColor = System.Drawing.SystemColors.Control
        Appearance22.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance22.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element
        Appearance22.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance22.BorderColor = System.Drawing.SystemColors.Window
        Me.dgvDetalle.DisplayLayout.Override.GroupByRowAppearance = Appearance22
        Appearance23.TextHAlignAsString = "Left"
        Me.dgvDetalle.DisplayLayout.Override.HeaderAppearance = Appearance23
        Me.dgvDetalle.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
        Me.dgvDetalle.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand
        Appearance24.BackColor = System.Drawing.SystemColors.Window
        Appearance24.BorderColor = System.Drawing.Color.Silver
        Me.dgvDetalle.DisplayLayout.Override.RowAppearance = Appearance24
        Me.dgvDetalle.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[False]
        Appearance25.BackColor = System.Drawing.SystemColors.ControlLight
        Me.dgvDetalle.DisplayLayout.Override.TemplateAddRowAppearance = Appearance25
        Me.dgvDetalle.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill
        Me.dgvDetalle.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate
        Me.dgvDetalle.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy
        Me.dgvDetalle.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dgvDetalle.Location = New System.Drawing.Point(9, 178)
        Me.dgvDetalle.Name = "dgvDetalle"
        Me.dgvDetalle.Size = New System.Drawing.Size(888, 322)
        Me.dgvDetalle.TabIndex = 43
        '
        'txtSaldoFin
        '
        Me.txtSaldoFin.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtSaldoFin.BindearPropiedadControl = Nothing
        Me.txtSaldoFin.BindearPropiedadEntidad = Nothing
        Me.txtSaldoFin.ForeColorFocus = System.Drawing.Color.Red
        Me.txtSaldoFin.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtSaldoFin.Formato = ""
        Me.txtSaldoFin.IsDecimal = True
        Me.txtSaldoFin.IsNumber = True
        Me.txtSaldoFin.IsPK = False
        Me.txtSaldoFin.IsRequired = False
        Me.txtSaldoFin.Key = ""
        Me.txtSaldoFin.LabelAsoc = Nothing
        Me.txtSaldoFin.Location = New System.Drawing.Point(817, 506)
        Me.txtSaldoFin.Name = "txtSaldoFin"
        Me.txtSaldoFin.ReadOnly = True
        Me.txtSaldoFin.Size = New System.Drawing.Size(80, 20)
        Me.txtSaldoFin.TabIndex = 7
        Me.txtSaldoFin.Text = "0.00"
        Me.txtSaldoFin.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label1
        '
        Me.Label1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label1.AutoSize = True
        Me.Label1.LabelAsoc = Nothing
        Me.Label1.Location = New System.Drawing.Point(751, 509)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(62, 13)
        Me.Label1.TabIndex = 6
        Me.Label1.Text = "Saldo Final:"
        '
        'stsStado
        '
        Me.stsStado.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tssInfo, Me.tspBarra, Me.tssRegistros})
        Me.stsStado.Location = New System.Drawing.Point(0, 531)
        Me.stsStado.Name = "stsStado"
        Me.stsStado.Size = New System.Drawing.Size(911, 22)
        Me.stsStado.TabIndex = 8
        Me.stsStado.Text = "statusStrip1"
        '
        'tssInfo
        '
        Me.tssInfo.Name = "tssInfo"
        Me.tssInfo.Size = New System.Drawing.Size(832, 17)
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
        'txtSaldoFinal
        '
        Me.txtSaldoFinal.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtSaldoFinal.BindearPropiedadControl = Nothing
        Me.txtSaldoFinal.BindearPropiedadEntidad = Nothing
        Me.txtSaldoFinal.ForeColorFocus = System.Drawing.Color.Red
        Me.txtSaldoFinal.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtSaldoFinal.Formato = ""
        Me.txtSaldoFinal.IsDecimal = True
        Me.txtSaldoFinal.IsNumber = True
        Me.txtSaldoFinal.IsPK = False
        Me.txtSaldoFinal.IsRequired = False
        Me.txtSaldoFinal.Key = ""
        Me.txtSaldoFinal.LabelAsoc = Nothing
        Me.txtSaldoFinal.Location = New System.Drawing.Point(809, 597)
        Me.txtSaldoFinal.Name = "txtSaldoFinal"
        Me.txtSaldoFinal.ReadOnly = True
        Me.txtSaldoFinal.Size = New System.Drawing.Size(80, 20)
        Me.txtSaldoFinal.TabIndex = 42
        Me.txtSaldoFinal.Text = "0.00"
        Me.txtSaldoFinal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblSaldoFinal
        '
        Me.lblSaldoFinal.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblSaldoFinal.AutoSize = True
        Me.lblSaldoFinal.LabelAsoc = Nothing
        Me.lblSaldoFinal.Location = New System.Drawing.Point(743, 600)
        Me.lblSaldoFinal.Name = "lblSaldoFinal"
        Me.lblSaldoFinal.Size = New System.Drawing.Size(62, 13)
        Me.lblSaldoFinal.TabIndex = 41
        Me.lblSaldoFinal.Text = "Saldo Final:"
        '
        'txtSaldoActual
        '
        Me.txtSaldoActual.BindearPropiedadControl = Nothing
        Me.txtSaldoActual.BindearPropiedadEntidad = Nothing
        Me.txtSaldoActual.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSaldoActual.ForeColor = System.Drawing.Color.Red
        Me.txtSaldoActual.ForeColorFocus = System.Drawing.Color.Red
        Me.txtSaldoActual.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtSaldoActual.Formato = ""
        Me.txtSaldoActual.IsDecimal = False
        Me.txtSaldoActual.IsNumber = False
        Me.txtSaldoActual.IsPK = False
        Me.txtSaldoActual.IsRequired = False
        Me.txtSaldoActual.Key = ""
        Me.txtSaldoActual.LabelAsoc = Nothing
        Me.txtSaldoActual.Location = New System.Drawing.Point(82, 152)
        Me.txtSaldoActual.Name = "txtSaldoActual"
        Me.txtSaldoActual.ReadOnly = True
        Me.txtSaldoActual.Size = New System.Drawing.Size(80, 20)
        Me.txtSaldoActual.TabIndex = 3
        Me.txtSaldoActual.Text = "0.00"
        Me.txtSaldoActual.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblSaldoActual
        '
        Me.lblSaldoActual.AutoSize = True
        Me.lblSaldoActual.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSaldoActual.ForeColor = System.Drawing.Color.Red
        Me.lblSaldoActual.LabelAsoc = Nothing
        Me.lblSaldoActual.Location = New System.Drawing.Point(7, 155)
        Me.lblSaldoActual.Name = "lblSaldoActual"
        Me.lblSaldoActual.Size = New System.Drawing.Size(70, 13)
        Me.lblSaldoActual.TabIndex = 1
        Me.lblSaldoActual.Text = "Saldo Actual:"
        '
        'txtSaldoInicial
        '
        Me.txtSaldoInicial.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtSaldoInicial.BindearPropiedadControl = Nothing
        Me.txtSaldoInicial.BindearPropiedadEntidad = Nothing
        Me.txtSaldoInicial.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSaldoInicial.ForeColorFocus = System.Drawing.Color.Red
        Me.txtSaldoInicial.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtSaldoInicial.Formato = ""
        Me.txtSaldoInicial.IsDecimal = True
        Me.txtSaldoInicial.IsNumber = True
        Me.txtSaldoInicial.IsPK = False
        Me.txtSaldoInicial.IsRequired = False
        Me.txtSaldoInicial.Key = ""
        Me.txtSaldoInicial.LabelAsoc = Nothing
        Me.txtSaldoInicial.Location = New System.Drawing.Point(817, 152)
        Me.txtSaldoInicial.Name = "txtSaldoInicial"
        Me.txtSaldoInicial.ReadOnly = True
        Me.txtSaldoInicial.Size = New System.Drawing.Size(80, 20)
        Me.txtSaldoInicial.TabIndex = 5
        Me.txtSaldoInicial.Text = "0.00"
        Me.txtSaldoInicial.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblSaldoInicial
        '
        Me.lblSaldoInicial.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblSaldoInicial.AutoSize = True
        Me.lblSaldoInicial.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSaldoInicial.LabelAsoc = Nothing
        Me.lblSaldoInicial.Location = New System.Drawing.Point(746, 155)
        Me.lblSaldoInicial.Name = "lblSaldoInicial"
        Me.lblSaldoInicial.Size = New System.Drawing.Size(67, 13)
        Me.lblSaldoInicial.TabIndex = 4
        Me.lblSaldoInicial.Text = "Saldo Inicial:"
        '
        'grbFiltros
        '
        Me.grbFiltros.Controls.Add(Me.bscCodigoProveedor)
        Me.grbFiltros.Controls.Add(Me.cmbSucursal)
        Me.grbFiltros.Controls.Add(Me.lblSucursal)
        Me.grbFiltros.Controls.Add(Me.cmbGrabanLibro)
        Me.grbFiltros.Controls.Add(Me.lblGrabanLibro)
        Me.grbFiltros.Controls.Add(Me.Label2)
        Me.grbFiltros.Controls.Add(Me.bscProveedor)
        Me.grbFiltros.Controls.Add(Me.chbVistaContable)
        Me.grbFiltros.Controls.Add(Me.chbFechas)
        Me.grbFiltros.Controls.Add(Me.dtpHasta)
        Me.grbFiltros.Controls.Add(Me.dtpDesde)
        Me.grbFiltros.Controls.Add(Me.lblHasta)
        Me.grbFiltros.Controls.Add(Me.lblDesde)
        Me.grbFiltros.Controls.Add(Me.lblCodigoProveedor)
        Me.grbFiltros.Controls.Add(Me.lblNombre)
        Me.grbFiltros.Controls.Add(Me.btnConsultar)
        Me.grbFiltros.Location = New System.Drawing.Point(12, 32)
        Me.grbFiltros.Name = "grbFiltros"
        Me.grbFiltros.Size = New System.Drawing.Size(885, 114)
        Me.grbFiltros.TabIndex = 0
        Me.grbFiltros.TabStop = False
        Me.grbFiltros.Text = "Filtros"
        '
        'bscCodigoProveedor
        '
        Me.bscCodigoProveedor.ActivarFiltroEnGrilla = True
        Me.bscCodigoProveedor.BindearPropiedadControl = Nothing
        Me.bscCodigoProveedor.BindearPropiedadEntidad = Nothing
        Me.bscCodigoProveedor.ConfigBuscador = Nothing
        Me.bscCodigoProveedor.Datos = Nothing
        Me.bscCodigoProveedor.FilaDevuelta = Nothing
        Me.bscCodigoProveedor.ForeColorFocus = System.Drawing.Color.Red
        Me.bscCodigoProveedor.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.bscCodigoProveedor.IsDecimal = False
        Me.bscCodigoProveedor.IsNumber = True
        Me.bscCodigoProveedor.IsPK = False
        Me.bscCodigoProveedor.IsRequired = False
        Me.bscCodigoProveedor.Key = ""
        Me.bscCodigoProveedor.LabelAsoc = Me.lblCodigoProveedor
        Me.bscCodigoProveedor.Location = New System.Drawing.Point(251, 30)
        Me.bscCodigoProveedor.MaxLengh = "32767"
        Me.bscCodigoProveedor.Name = "bscCodigoProveedor"
        Me.bscCodigoProveedor.Permitido = True
        Me.bscCodigoProveedor.PermitidoNoBackColor = System.Drawing.Color.FromArgb(CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer))
        Me.bscCodigoProveedor.PermitidoNoForeColor = System.Drawing.Color.Black
        Me.bscCodigoProveedor.PermitidoSiBackColor = System.Drawing.Color.White
        Me.bscCodigoProveedor.PermitidoSiForeColor = System.Drawing.Color.Black
        Me.bscCodigoProveedor.Selecciono = False
        Me.bscCodigoProveedor.Size = New System.Drawing.Size(90, 23)
        Me.bscCodigoProveedor.TabIndex = 4
        '
        'lblCodigoProveedor
        '
        Me.lblCodigoProveedor.AutoSize = True
        Me.lblCodigoProveedor.LabelAsoc = Nothing
        Me.lblCodigoProveedor.Location = New System.Drawing.Point(248, 13)
        Me.lblCodigoProveedor.Name = "lblCodigoProveedor"
        Me.lblCodigoProveedor.Size = New System.Drawing.Size(40, 13)
        Me.lblCodigoProveedor.TabIndex = 3
        Me.lblCodigoProveedor.Text = "Código"
        '
        'cmbSucursal
        '
        Me.cmbSucursal.BindearPropiedadControl = Nothing
        Me.cmbSucursal.BindearPropiedadEntidad = Nothing
        Me.cmbSucursal.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbSucursal.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.cmbSucursal.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbSucursal.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbSucursal.FormattingEnabled = True
        Me.cmbSucursal.IsPK = False
        Me.cmbSucursal.IsRequired = False
        Me.cmbSucursal.ItemHeight = 13
        Me.cmbSucursal.Key = Nothing
        Me.cmbSucursal.LabelAsoc = Me.lblSucursal
        Me.cmbSucursal.Location = New System.Drawing.Point(63, 29)
        Me.cmbSucursal.Name = "cmbSucursal"
        Me.cmbSucursal.Size = New System.Drawing.Size(130, 21)
        Me.cmbSucursal.TabIndex = 1
        '
        'lblSucursal
        '
        Me.lblSucursal.AutoSize = True
        Me.lblSucursal.LabelAsoc = Nothing
        Me.lblSucursal.Location = New System.Drawing.Point(6, 32)
        Me.lblSucursal.Name = "lblSucursal"
        Me.lblSucursal.Size = New System.Drawing.Size(48, 13)
        Me.lblSucursal.TabIndex = 0
        Me.lblSucursal.Text = "Sucursal"
        '
        'cmbGrabanLibro
        '
        Me.cmbGrabanLibro.BindearPropiedadControl = Nothing
        Me.cmbGrabanLibro.BindearPropiedadEntidad = Nothing
        Me.cmbGrabanLibro.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbGrabanLibro.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbGrabanLibro.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbGrabanLibro.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbGrabanLibro.FormattingEnabled = True
        Me.cmbGrabanLibro.IsPK = False
        Me.cmbGrabanLibro.IsRequired = False
        Me.cmbGrabanLibro.Key = Nothing
        Me.cmbGrabanLibro.LabelAsoc = Me.lblGrabanLibro
        Me.cmbGrabanLibro.Location = New System.Drawing.Point(402, 62)
        Me.cmbGrabanLibro.Name = "cmbGrabanLibro"
        Me.cmbGrabanLibro.Size = New System.Drawing.Size(83, 21)
        Me.cmbGrabanLibro.TabIndex = 13
        '
        'lblGrabanLibro
        '
        Me.lblGrabanLibro.AutoSize = True
        Me.lblGrabanLibro.LabelAsoc = Nothing
        Me.lblGrabanLibro.Location = New System.Drawing.Point(330, 66)
        Me.lblGrabanLibro.Name = "lblGrabanLibro"
        Me.lblGrabanLibro.Size = New System.Drawing.Size(68, 13)
        Me.lblGrabanLibro.TabIndex = 12
        Me.lblGrabanLibro.Text = "Graban Libro"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.LabelAsoc = Nothing
        Me.Label2.Location = New System.Drawing.Point(195, 32)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(56, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Proveedor"
        '
        'bscProveedor
        '
        Me.bscProveedor.ActivarFiltroEnGrilla = True
        Me.bscProveedor.AutoSize = True
        Me.bscProveedor.BindearPropiedadControl = Nothing
        Me.bscProveedor.BindearPropiedadEntidad = Nothing
        Me.bscProveedor.ConfigBuscador = Nothing
        Me.bscProveedor.Datos = Nothing
        Me.bscProveedor.FilaDevuelta = Nothing
        Me.bscProveedor.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bscProveedor.ForeColorFocus = System.Drawing.Color.Red
        Me.bscProveedor.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.bscProveedor.IsDecimal = False
        Me.bscProveedor.IsNumber = False
        Me.bscProveedor.IsPK = False
        Me.bscProveedor.IsRequired = False
        Me.bscProveedor.Key = ""
        Me.bscProveedor.LabelAsoc = Me.lblNombre
        Me.bscProveedor.Location = New System.Drawing.Point(346, 30)
        Me.bscProveedor.Margin = New System.Windows.Forms.Padding(4)
        Me.bscProveedor.MaxLengh = "32767"
        Me.bscProveedor.Name = "bscProveedor"
        Me.bscProveedor.Permitido = True
        Me.bscProveedor.PermitidoNoBackColor = System.Drawing.Color.FromArgb(CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer))
        Me.bscProveedor.PermitidoNoForeColor = System.Drawing.Color.Black
        Me.bscProveedor.PermitidoSiBackColor = System.Drawing.Color.White
        Me.bscProveedor.PermitidoSiForeColor = System.Drawing.Color.Black
        Me.bscProveedor.Selecciono = False
        Me.bscProveedor.Size = New System.Drawing.Size(266, 23)
        Me.bscProveedor.TabIndex = 6
        '
        'lblNombre
        '
        Me.lblNombre.AutoSize = True
        Me.lblNombre.LabelAsoc = Nothing
        Me.lblNombre.Location = New System.Drawing.Point(345, 13)
        Me.lblNombre.Name = "lblNombre"
        Me.lblNombre.Size = New System.Drawing.Size(44, 13)
        Me.lblNombre.TabIndex = 5
        Me.lblNombre.Text = "Nombre"
        '
        'chbVistaContable
        '
        Me.chbVistaContable.AutoSize = True
        Me.chbVistaContable.BindearPropiedadControl = Nothing
        Me.chbVistaContable.BindearPropiedadEntidad = Nothing
        Me.chbVistaContable.ForeColorFocus = System.Drawing.Color.Red
        Me.chbVistaContable.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbVistaContable.IsPK = False
        Me.chbVistaContable.IsRequired = False
        Me.chbVistaContable.Key = Nothing
        Me.chbVistaContable.LabelAsoc = Nothing
        Me.chbVistaContable.Location = New System.Drawing.Point(9, 90)
        Me.chbVistaContable.Name = "chbVistaContable"
        Me.chbVistaContable.Size = New System.Drawing.Size(94, 17)
        Me.chbVistaContable.TabIndex = 14
        Me.chbVistaContable.Text = "Vista Contable"
        Me.chbVistaContable.UseVisualStyleBackColor = True
        '
        'chbFechas
        '
        Me.chbFechas.AutoSize = True
        Me.chbFechas.BindearPropiedadControl = Nothing
        Me.chbFechas.BindearPropiedadEntidad = Nothing
        Me.chbFechas.ForeColorFocus = System.Drawing.Color.Red
        Me.chbFechas.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbFechas.IsPK = False
        Me.chbFechas.IsRequired = False
        Me.chbFechas.Key = Nothing
        Me.chbFechas.LabelAsoc = Nothing
        Me.chbFechas.Location = New System.Drawing.Point(9, 64)
        Me.chbFechas.Name = "chbFechas"
        Me.chbFechas.Size = New System.Drawing.Size(56, 17)
        Me.chbFechas.TabIndex = 7
        Me.chbFechas.Text = "Fecha"
        Me.chbFechas.UseVisualStyleBackColor = True
        '
        'dtpHasta
        '
        Me.dtpHasta.BindearPropiedadControl = Nothing
        Me.dtpHasta.BindearPropiedadEntidad = Nothing
        Me.dtpHasta.CustomFormat = "dd/MM/yyyy"
        Me.dtpHasta.Enabled = False
        Me.dtpHasta.ForeColorFocus = System.Drawing.Color.Red
        Me.dtpHasta.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.dtpHasta.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpHasta.IsPK = False
        Me.dtpHasta.IsRequired = False
        Me.dtpHasta.Key = ""
        Me.dtpHasta.LabelAsoc = Me.lblHasta
        Me.dtpHasta.Location = New System.Drawing.Point(241, 62)
        Me.dtpHasta.Name = "dtpHasta"
        Me.dtpHasta.Size = New System.Drawing.Size(84, 20)
        Me.dtpHasta.TabIndex = 11
        '
        'lblHasta
        '
        Me.lblHasta.AutoSize = True
        Me.lblHasta.LabelAsoc = Nothing
        Me.lblHasta.Location = New System.Drawing.Point(202, 65)
        Me.lblHasta.Name = "lblHasta"
        Me.lblHasta.Size = New System.Drawing.Size(35, 13)
        Me.lblHasta.TabIndex = 10
        Me.lblHasta.Text = "Hasta"
        '
        'dtpDesde
        '
        Me.dtpDesde.BindearPropiedadControl = Nothing
        Me.dtpDesde.BindearPropiedadEntidad = Nothing
        Me.dtpDesde.CustomFormat = "dd/MM/yyyy"
        Me.dtpDesde.Enabled = False
        Me.dtpDesde.ForeColorFocus = System.Drawing.Color.Red
        Me.dtpDesde.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.dtpDesde.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpDesde.IsPK = False
        Me.dtpDesde.IsRequired = False
        Me.dtpDesde.Key = ""
        Me.dtpDesde.LabelAsoc = Me.lblDesde
        Me.dtpDesde.Location = New System.Drawing.Point(109, 62)
        Me.dtpDesde.Name = "dtpDesde"
        Me.dtpDesde.Size = New System.Drawing.Size(84, 20)
        Me.dtpDesde.TabIndex = 9
        '
        'lblDesde
        '
        Me.lblDesde.AutoSize = True
        Me.lblDesde.LabelAsoc = Nothing
        Me.lblDesde.Location = New System.Drawing.Point(67, 65)
        Me.lblDesde.Name = "lblDesde"
        Me.lblDesde.Size = New System.Drawing.Size(38, 13)
        Me.lblDesde.TabIndex = 8
        Me.lblDesde.Text = "Desde"
        '
        'btnConsultar
        '
        Me.btnConsultar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnConsultar.Image = Global.Eniac.Win.My.Resources.Resources.view
        Me.btnConsultar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnConsultar.Location = New System.Drawing.Point(779, 38)
        Me.btnConsultar.Name = "btnConsultar"
        Me.btnConsultar.Size = New System.Drawing.Size(100, 45)
        Me.btnConsultar.TabIndex = 15
        Me.btnConsultar.Text = "&Consultar"
        Me.btnConsultar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnConsultar.UseVisualStyleBackColor = True
        '
        'tstBarra
        '
        Me.tstBarra.AllowItemReorder = True
        Me.tstBarra.ImageScalingSize = New System.Drawing.Size(22, 22)
        Me.tstBarra.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsbRefrescar, Me.ToolStripSeparator2, Me.tsbImprimir, Me.toolStripSeparator3, Me.tsddExportar, Me.ToolStripSeparator4, Me.tsbPreferencias, Me.ToolStripSeparator1, Me.tsbSalir})
        Me.tstBarra.Location = New System.Drawing.Point(0, 0)
        Me.tstBarra.Name = "tstBarra"
        Me.tstBarra.Size = New System.Drawing.Size(911, 29)
        Me.tstBarra.TabIndex = 9
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
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 29)
        '
        'tsbImprimir
        '
        Me.tsbImprimir.Image = Global.Eniac.Win.My.Resources.Resources.printer_32
        Me.tsbImprimir.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbImprimir.Name = "tsbImprimir"
        Me.tsbImprimir.Size = New System.Drawing.Size(79, 26)
        Me.tsbImprimir.Text = "&Imprimir"
        Me.tsbImprimir.ToolTipText = "Imprimir y Grabar (F4)"
        '
        'toolStripSeparator3
        '
        Me.toolStripSeparator3.Name = "toolStripSeparator3"
        Me.toolStripSeparator3.Size = New System.Drawing.Size(6, 29)
        '
        'tsddExportar
        '
        Me.tsddExportar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.tsddExportar.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsmiAExcel, Me.tsmiAPDF})
        Me.tsddExportar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsddExportar.Name = "tsddExportar"
        Me.tsddExportar.Size = New System.Drawing.Size(64, 26)
        Me.tsddExportar.Text = "Exportar"
        '
        'tsmiAExcel
        '
        Me.tsmiAExcel.Image = Global.Eniac.Win.My.Resources.Resources.excel
        Me.tsmiAExcel.Name = "tsmiAExcel"
        Me.tsmiAExcel.Size = New System.Drawing.Size(110, 22)
        Me.tsmiAExcel.Text = "a Excel"
        '
        'tsmiAPDF
        '
        Me.tsmiAPDF.Image = Global.Eniac.Win.My.Resources.Resources.Adobe_PDF_256
        Me.tsmiAPDF.Name = "tsmiAPDF"
        Me.tsmiAPDF.Size = New System.Drawing.Size(110, 22)
        Me.tsmiAPDF.Text = "a PDF"
        '
        'ToolStripSeparator4
        '
        Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
        Me.ToolStripSeparator4.Size = New System.Drawing.Size(6, 29)
        '
        'tsbPreferencias
        '
        Me.tsbPreferencias.Image = CType(resources.GetObject("tsbPreferencias.Image"), System.Drawing.Image)
        Me.tsbPreferencias.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbPreferencias.Name = "tsbPreferencias"
        Me.tsbPreferencias.Size = New System.Drawing.Size(97, 26)
        Me.tsbPreferencias.Text = "&Preferencias"
        Me.tsbPreferencias.ToolTipText = "Selector de Columnas"
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
        Me.tsbSalir.ToolTipText = "Cerrar el formulario"
        '
        'ConsultarCtaCteProveedoresDH
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(911, 553)
        Me.Controls.Add(Me.dgvDetalle)
        Me.Controls.Add(Me.txtSaldoFin)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.stsStado)
        Me.Controls.Add(Me.txtSaldoFinal)
        Me.Controls.Add(Me.lblSaldoFinal)
        Me.Controls.Add(Me.txtSaldoActual)
        Me.Controls.Add(Me.lblSaldoActual)
        Me.Controls.Add(Me.txtSaldoInicial)
        Me.Controls.Add(Me.lblSaldoInicial)
        Me.Controls.Add(Me.grbFiltros)
        Me.Controls.Add(Me.tstBarra)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "ConsultarCtaCteProveedoresDH"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Consultar Cta. Cte. de Proveedor - Debe y Haber"
        CType(Me.dgvDetalle, System.ComponentModel.ISupportInitialize).EndInit()
        Me.stsStado.ResumeLayout(False)
        Me.stsStado.PerformLayout()
        Me.grbFiltros.ResumeLayout(False)
        Me.grbFiltros.PerformLayout()
        Me.tstBarra.ResumeLayout(False)
        Me.tstBarra.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Public WithEvents tstBarra As System.Windows.Forms.ToolStrip
   Public WithEvents tsbRefrescar As System.Windows.Forms.ToolStripButton
   Friend WithEvents tsbImprimir As System.Windows.Forms.ToolStripButton
   Private WithEvents toolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
   Public WithEvents tsbSalir As System.Windows.Forms.ToolStripButton
   Friend WithEvents grbFiltros As System.Windows.Forms.GroupBox
   Friend WithEvents chbFechas As Eniac.Controles.CheckBox
   Friend WithEvents dtpHasta As Eniac.Controles.DateTimePicker
   Friend WithEvents lblHasta As Eniac.Controles.Label
   Friend WithEvents dtpDesde As Eniac.Controles.DateTimePicker
   Friend WithEvents lblDesde As Eniac.Controles.Label
   Friend WithEvents lblCodigoProveedor As Eniac.Controles.Label
   Friend WithEvents lblNombre As Eniac.Controles.Label
   Friend WithEvents btnConsultar As Eniac.Controles.Button
   Friend WithEvents txtSaldoActual As Eniac.Controles.TextBox
   Friend WithEvents lblSaldoActual As Eniac.Controles.Label
   Friend WithEvents txtSaldoInicial As Eniac.Controles.TextBox
   Friend WithEvents lblSaldoInicial As Eniac.Controles.Label
   Friend WithEvents txtSaldoFinal As Eniac.Controles.TextBox
   Friend WithEvents lblSaldoFinal As Eniac.Controles.Label
   Protected Friend WithEvents stsStado As System.Windows.Forms.StatusStrip
   Protected Friend WithEvents tssInfo As System.Windows.Forms.ToolStripStatusLabel
   Protected Friend WithEvents tspBarra As System.Windows.Forms.ToolStripProgressBar
   Protected WithEvents tssRegistros As System.Windows.Forms.ToolStripStatusLabel
   Friend WithEvents bscCodigoProveedor As Eniac.Controles.Buscador2
   Friend WithEvents bscProveedor As Eniac.Controles.Buscador2
   Friend WithEvents txtSaldoFin As Eniac.Controles.TextBox
   Friend WithEvents Label1 As Eniac.Controles.Label
   Friend WithEvents Label2 As Eniac.Controles.Label
   Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
   Friend WithEvents cmbGrabanLibro As Eniac.Controles.ComboBox
   Friend WithEvents lblGrabanLibro As Eniac.Controles.Label
   Friend WithEvents chbVistaContable As Eniac.Controles.CheckBox
   Friend WithEvents cmbSucursal As Eniac.Win.ComboBoxSucursales
   Friend WithEvents lblSucursal As Eniac.Controles.Label
   Friend WithEvents dgvDetalle As Infragistics.Win.UltraWinGrid.UltraGrid
   Public WithEvents tsbPreferencias As System.Windows.Forms.ToolStripButton
   Private WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
   Friend WithEvents tsddExportar As System.Windows.Forms.ToolStripDropDownButton
   Friend WithEvents tsmiAExcel As System.Windows.Forms.ToolStripMenuItem
   Friend WithEvents tsmiAPDF As System.Windows.Forms.ToolStripMenuItem
   Private WithEvents ToolStripSeparator4 As System.Windows.Forms.ToolStripSeparator
   Friend WithEvents UltraGridExcelExporter1 As Infragistics.Win.UltraWinGrid.ExcelExport.UltraGridExcelExporter
   Friend WithEvents UltraGridDocumentExporter1 As Infragistics.Win.UltraWinGrid.DocumentExport.UltraGridDocumentExporter
End Class