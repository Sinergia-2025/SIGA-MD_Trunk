<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class IntercambioDeMovimientos
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
      Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(IntercambioDeMovimientos))
      Dim Appearance1 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridBand1 As Infragistics.Win.UltraWinGrid.UltraGridBand = New Infragistics.Win.UltraWinGrid.UltraGridBand("Band 0", -1)
      Dim UltraGridColumn1 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdSucursal")
      Dim UltraGridColumn2 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdCuentaBancaria")
      Dim UltraGridColumn3 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("DescCuentaBancaria")
      Dim UltraGridColumn4 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NumeroMovimiento")
      Dim Appearance2 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn5 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdCuentaBanco")
      Dim Appearance3 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn6 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreCuentaBanco")
      Dim UltraGridColumn7 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdTipoMovimiento")
      Dim Appearance4 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn8 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Importe")
      Dim Appearance5 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn9 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Saldo")
      Dim Appearance6 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn10 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("FechaMovimiento")
      Dim Appearance7 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn11 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("FechaAplicado")
      Dim Appearance8 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn12 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Conciliado")
      Dim Appearance9 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn13 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NumeroCheque")
      Dim UltraGridColumn14 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdBanco")
      Dim UltraGridColumn15 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("DescCheque")
      Dim UltraGridColumn23 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("FechaCobro")
      Dim Appearance10 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn16 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Observacion")
      Dim UltraGridColumn17 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("EsModificable")
      Dim UltraGridColumn22 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("GeneraContabilidad")
      Dim Appearance11 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn18 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdPlanCuenta")
      Dim Appearance12 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn19 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdAsiento")
      Dim Appearance13 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn20 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdCentroCosto")
      Dim Appearance14 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn21 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreCentroCosto")
      Dim UltraGridColumn24 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdTipoComprobante")
      Dim Appearance15 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim Appearance16 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn25 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NumeroDeposito")
      Dim Appearance17 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim Appearance18 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn26 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdEjercicio")
        Dim UltraGridColumn27 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdCheque")
        Dim Appearance19 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance20 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance21 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance22 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance23 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance24 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance25 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance26 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance27 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance28 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance29 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance30 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Me.imgIconos = New System.Windows.Forms.ImageList(Me.components)
        Me.ugDetalle = New Infragistics.Win.UltraWinGrid.UltraGrid()
        Me.grbFiltros = New System.Windows.Forms.GroupBox()
        Me.btnConsultar = New Eniac.Controles.Button()
        Me.dpFechaHasta = New Eniac.Controles.DateTimePicker()
        Me.lblY = New Eniac.Controles.Label()
        Me.dpFechaDesde = New Eniac.Controles.DateTimePicker()
        Me.lblEntre = New Eniac.Controles.Label()
        Me.lblCuentaOrigen = New Eniac.Controles.Label()
        Me.bscCuentaBancariaOrigen = New Eniac.Controles.Buscador()
        Me.tstBarra = New System.Windows.Forms.ToolStrip()
        Me.tsbRefrescar = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsbPreferencias = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsbSalir = New System.Windows.Forms.ToolStripButton()
        Me.lblCuentaDestino = New Eniac.Controles.Label()
        Me.bscCuentaBancariaDestino = New Eniac.Controles.Buscador()
        Me.btnProceder = New System.Windows.Forms.Button()
        CType(Me.ugDetalle, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grbFiltros.SuspendLayout()
        Me.tstBarra.SuspendLayout()
        Me.SuspendLayout()
        '
        'imgIconos
        '
        Me.imgIconos.ImageStream = CType(resources.GetObject("imgIconos.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.imgIconos.TransparentColor = System.Drawing.Color.Transparent
        Me.imgIconos.Images.SetKeyName(0, "find.ico")
        '
        'ugDetalle
        '
        Me.ugDetalle.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Appearance1.BackColor = System.Drawing.SystemColors.Window
        Appearance1.BorderColor = System.Drawing.SystemColors.InactiveCaption
        Me.ugDetalle.DisplayLayout.Appearance = Appearance1
        UltraGridColumn1.Header.Caption = "S."
        UltraGridColumn1.Header.VisiblePosition = 0
        UltraGridColumn1.Hidden = True
        UltraGridColumn1.Width = 22
        UltraGridColumn2.Header.VisiblePosition = 1
        UltraGridColumn2.Hidden = True
        UltraGridColumn3.Header.VisiblePosition = 2
        UltraGridColumn3.Hidden = True
        Appearance2.TextHAlignAsString = "Right"
        UltraGridColumn4.CellAppearance = Appearance2
        UltraGridColumn4.Header.Caption = "Mov."
        UltraGridColumn4.Header.VisiblePosition = 3
        UltraGridColumn4.Width = 46
        Appearance3.TextHAlignAsString = "Right"
        UltraGridColumn5.CellAppearance = Appearance3
        UltraGridColumn5.Header.Caption = "Cuenta"
        UltraGridColumn5.Header.VisiblePosition = 4
        UltraGridColumn5.Width = 55
        UltraGridColumn6.Header.Caption = "Descripcion"
        UltraGridColumn6.Header.VisiblePosition = 5
        UltraGridColumn6.Width = 207
        Appearance4.TextHAlignAsString = "Center"
        UltraGridColumn7.CellAppearance = Appearance4
        UltraGridColumn7.Header.Caption = "T."
        UltraGridColumn7.Header.VisiblePosition = 6
        UltraGridColumn7.Width = 28
        Appearance5.TextHAlignAsString = "Right"
        UltraGridColumn8.CellAppearance = Appearance5
        UltraGridColumn8.Format = "N2"
        UltraGridColumn8.Header.VisiblePosition = 7
        UltraGridColumn8.Width = 75
        Appearance6.TextHAlignAsString = "Right"
        UltraGridColumn9.CellAppearance = Appearance6
        UltraGridColumn9.Format = "N2"
        UltraGridColumn9.Header.VisiblePosition = 8
        UltraGridColumn9.Width = 81
        Appearance7.TextHAlignAsString = "Center"
        UltraGridColumn10.CellAppearance = Appearance7
        UltraGridColumn10.Format = "dd/MM/yyyy"
        UltraGridColumn10.Header.Caption = "Movimiento"
        UltraGridColumn10.Header.VisiblePosition = 9
        UltraGridColumn10.MaskInput = "{LOC}dd/mm/yyyy"
        UltraGridColumn10.Width = 76
        Appearance8.TextHAlignAsString = "Center"
        UltraGridColumn11.CellAppearance = Appearance8
        UltraGridColumn11.Format = "dd/MM/yyyy"
        UltraGridColumn11.Header.Caption = "Aplicado"
        UltraGridColumn11.Header.VisiblePosition = 10
        UltraGridColumn11.MaskInput = "{LOC}dd/mm/yyyy"
        UltraGridColumn11.Width = 67
        Appearance9.TextHAlignAsString = "Center"
        UltraGridColumn12.CellAppearance = Appearance9
        UltraGridColumn12.Header.Caption = "Conc."
        UltraGridColumn12.Header.VisiblePosition = 11
        UltraGridColumn12.Width = 40
        UltraGridColumn13.Header.VisiblePosition = 12
        UltraGridColumn13.Hidden = True
        UltraGridColumn14.Header.VisiblePosition = 13
        UltraGridColumn14.Hidden = True
        UltraGridColumn15.Header.Caption = "Cheque"
        UltraGridColumn15.Header.VisiblePosition = 14
        UltraGridColumn15.Width = 230
        Appearance10.TextHAlignAsString = "Center"
        UltraGridColumn23.CellAppearance = Appearance10
        UltraGridColumn23.Format = "dd/MM/yyyy"
        UltraGridColumn23.Header.Caption = "Fecha Cobro"
        UltraGridColumn23.Header.VisiblePosition = 15
        UltraGridColumn23.Width = 80
        UltraGridColumn16.Header.Caption = "Observación"
        UltraGridColumn16.Header.VisiblePosition = 18
        UltraGridColumn16.Width = 348
        UltraGridColumn17.Header.Caption = "Mod."
        UltraGridColumn17.Header.VisiblePosition = 16
        UltraGridColumn17.Hidden = True
        UltraGridColumn17.Width = 40
        Appearance11.TextHAlignAsString = "Center"
        UltraGridColumn22.CellAppearance = Appearance11
        UltraGridColumn22.Header.Caption = "Cntb"
        UltraGridColumn22.Header.VisiblePosition = 17
        UltraGridColumn22.Hidden = True
        UltraGridColumn22.Width = 40
        Appearance12.TextHAlignAsString = "Right"
        UltraGridColumn18.CellAppearance = Appearance12
        UltraGridColumn18.Header.Caption = "P."
        UltraGridColumn18.Header.VisiblePosition = 19
        UltraGridColumn18.Width = 25
        Appearance13.TextHAlignAsString = "Right"
        UltraGridColumn19.CellAppearance = Appearance13
        UltraGridColumn19.Header.Caption = "Asiento"
        UltraGridColumn19.Header.VisiblePosition = 20
        UltraGridColumn19.Width = 54
        Appearance14.TextHAlignAsString = "Right"
        UltraGridColumn20.CellAppearance = Appearance14
        UltraGridColumn20.Header.Caption = "C.C."
        UltraGridColumn20.Header.VisiblePosition = 21
        UltraGridColumn20.Width = 47
        UltraGridColumn21.Header.Caption = "Centro de Costos"
        UltraGridColumn21.Header.VisiblePosition = 22
        UltraGridColumn21.Width = 331
        Appearance15.TextHAlignAsString = "Left"
        UltraGridColumn24.CellAppearance = Appearance15
        Appearance16.TextHAlignAsString = "Left"
        UltraGridColumn24.FilterCellAppearance = Appearance16
        UltraGridColumn24.Header.Caption = "Comprobante"
        UltraGridColumn24.Header.VisiblePosition = 23
        Appearance17.TextHAlignAsString = "Right"
        UltraGridColumn25.CellAppearance = Appearance17
        Appearance18.TextHAlignAsString = "Right"
        UltraGridColumn25.FilterCellAppearance = Appearance18
        UltraGridColumn25.Header.Caption = "Deposito"
        UltraGridColumn25.Header.VisiblePosition = 24
        UltraGridColumn25.Width = 64
        UltraGridColumn26.Header.VisiblePosition = 25
        UltraGridColumn26.Hidden = True
        UltraGridColumn27.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        Appearance19.TextHAlignAsString = "Right"
        UltraGridColumn27.CellAppearance = Appearance19
        UltraGridColumn27.Header.VisiblePosition = 26
        UltraGridColumn27.Hidden = True
        UltraGridBand1.Columns.AddRange(New Object() {UltraGridColumn1, UltraGridColumn2, UltraGridColumn3, UltraGridColumn4, UltraGridColumn5, UltraGridColumn6, UltraGridColumn7, UltraGridColumn8, UltraGridColumn9, UltraGridColumn10, UltraGridColumn11, UltraGridColumn12, UltraGridColumn13, UltraGridColumn14, UltraGridColumn15, UltraGridColumn23, UltraGridColumn16, UltraGridColumn17, UltraGridColumn22, UltraGridColumn18, UltraGridColumn19, UltraGridColumn20, UltraGridColumn21, UltraGridColumn24, UltraGridColumn25, UltraGridColumn26, UltraGridColumn27})
        Me.ugDetalle.DisplayLayout.BandsSerializer.Add(UltraGridBand1)
        Me.ugDetalle.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.ugDetalle.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.[False]
        Appearance20.BackColor = System.Drawing.SystemColors.ActiveBorder
        Appearance20.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance20.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Appearance20.BorderColor = System.Drawing.SystemColors.Window
        Me.ugDetalle.DisplayLayout.GroupByBox.Appearance = Appearance20
        Appearance21.ForeColor = System.Drawing.SystemColors.GrayText
        Me.ugDetalle.DisplayLayout.GroupByBox.BandLabelAppearance = Appearance21
        Me.ugDetalle.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.ugDetalle.DisplayLayout.GroupByBox.Prompt = "Arrastre un título de columna aquí para agrupar."
        Appearance22.BackColor = System.Drawing.SystemColors.ControlLightLight
        Appearance22.BackColor2 = System.Drawing.SystemColors.Control
        Appearance22.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance22.ForeColor = System.Drawing.SystemColors.GrayText
        Me.ugDetalle.DisplayLayout.GroupByBox.PromptAppearance = Appearance22
        Me.ugDetalle.DisplayLayout.MaxColScrollRegions = 1
        Me.ugDetalle.DisplayLayout.MaxRowScrollRegions = 1
        Appearance23.BackColor = System.Drawing.SystemColors.Window
        Appearance23.ForeColor = System.Drawing.SystemColors.ControlText
        Me.ugDetalle.DisplayLayout.Override.ActiveCellAppearance = Appearance23
        Appearance24.BackColor = System.Drawing.SystemColors.Highlight
        Appearance24.ForeColor = System.Drawing.SystemColors.HighlightText
        Me.ugDetalle.DisplayLayout.Override.ActiveRowAppearance = Appearance24
        Me.ugDetalle.DisplayLayout.Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.No
        Me.ugDetalle.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.[False]
        Me.ugDetalle.DisplayLayout.Override.AllowUpdate = Infragistics.Win.DefaultableBoolean.[False]
        Me.ugDetalle.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted
        Me.ugDetalle.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted
        Appearance25.BackColor = System.Drawing.SystemColors.Window
        Me.ugDetalle.DisplayLayout.Override.CardAreaAppearance = Appearance25
        Appearance26.BorderColor = System.Drawing.Color.Silver
        Appearance26.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter
        Me.ugDetalle.DisplayLayout.Override.CellAppearance = Appearance26
        Me.ugDetalle.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText
        Me.ugDetalle.DisplayLayout.Override.CellPadding = 0
        Appearance27.BackColor = System.Drawing.SystemColors.Control
        Appearance27.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance27.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element
        Appearance27.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance27.BorderColor = System.Drawing.SystemColors.Window
        Me.ugDetalle.DisplayLayout.Override.GroupByRowAppearance = Appearance27
        Appearance28.TextHAlignAsString = "Left"
        Me.ugDetalle.DisplayLayout.Override.HeaderAppearance = Appearance28
        Me.ugDetalle.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
        Me.ugDetalle.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand
        Appearance29.BackColor = System.Drawing.SystemColors.Window
        Appearance29.BorderColor = System.Drawing.Color.Silver
        Me.ugDetalle.DisplayLayout.Override.RowAppearance = Appearance29
        Me.ugDetalle.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[False]
        Me.ugDetalle.DisplayLayout.Override.SelectTypeRow = Infragistics.Win.UltraWinGrid.SelectType.[Single]
        Appearance30.BackColor = System.Drawing.SystemColors.ControlLight
        Me.ugDetalle.DisplayLayout.Override.TemplateAddRowAppearance = Appearance30
        Me.ugDetalle.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill
        Me.ugDetalle.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate
        Me.ugDetalle.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy
        Me.ugDetalle.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ugDetalle.Location = New System.Drawing.Point(15, 114)
        Me.ugDetalle.Name = "ugDetalle"
        Me.ugDetalle.Size = New System.Drawing.Size(954, 364)
        Me.ugDetalle.TabIndex = 94
        '
        'grbFiltros
        '
        Me.grbFiltros.Controls.Add(Me.btnConsultar)
        Me.grbFiltros.Controls.Add(Me.dpFechaHasta)
        Me.grbFiltros.Controls.Add(Me.lblY)
        Me.grbFiltros.Controls.Add(Me.dpFechaDesde)
        Me.grbFiltros.Controls.Add(Me.lblEntre)
        Me.grbFiltros.Controls.Add(Me.lblCuentaOrigen)
        Me.grbFiltros.Controls.Add(Me.bscCuentaBancariaOrigen)
        Me.grbFiltros.Location = New System.Drawing.Point(15, 43)
        Me.grbFiltros.Name = "grbFiltros"
        Me.grbFiltros.Size = New System.Drawing.Size(954, 65)
        Me.grbFiltros.TabIndex = 93
        Me.grbFiltros.TabStop = False
        Me.grbFiltros.Text = "Filtros"
        '
        'btnConsultar
        '
        Me.btnConsultar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnConsultar.Image = Global.Eniac.Win.My.Resources.Resources.view
        Me.btnConsultar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnConsultar.Location = New System.Drawing.Point(844, 15)
        Me.btnConsultar.Name = "btnConsultar"
        Me.btnConsultar.Size = New System.Drawing.Size(93, 40)
        Me.btnConsultar.TabIndex = 99
        Me.btnConsultar.Text = "Consultar"
        Me.btnConsultar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnConsultar.UseVisualStyleBackColor = True
        '
        'dpFechaHasta
        '
        Me.dpFechaHasta.BindearPropiedadControl = Nothing
        Me.dpFechaHasta.BindearPropiedadEntidad = Nothing
        Me.dpFechaHasta.ForeColorFocus = System.Drawing.Color.Red
        Me.dpFechaHasta.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.dpFechaHasta.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dpFechaHasta.IsPK = False
        Me.dpFechaHasta.IsRequired = False
        Me.dpFechaHasta.Key = ""
        Me.dpFechaHasta.LabelAsoc = Nothing
        Me.dpFechaHasta.Location = New System.Drawing.Point(673, 25)
        Me.dpFechaHasta.Name = "dpFechaHasta"
        Me.dpFechaHasta.Size = New System.Drawing.Size(95, 20)
        Me.dpFechaHasta.TabIndex = 98
        Me.dpFechaHasta.Value = New Date(2008, 12, 30, 0, 0, 0, 0)
        '
        'lblY
        '
        Me.lblY.AutoSize = True
        Me.lblY.LabelAsoc = Nothing
        Me.lblY.Location = New System.Drawing.Point(643, 29)
        Me.lblY.Name = "lblY"
        Me.lblY.Size = New System.Drawing.Size(23, 13)
        Me.lblY.TabIndex = 97
        Me.lblY.Text = "y el"
        '
        'dpFechaDesde
        '
        Me.dpFechaDesde.BindearPropiedadControl = Nothing
        Me.dpFechaDesde.BindearPropiedadEntidad = Nothing
        Me.dpFechaDesde.ForeColorFocus = System.Drawing.Color.Red
        Me.dpFechaDesde.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.dpFechaDesde.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dpFechaDesde.IsPK = False
        Me.dpFechaDesde.IsRequired = False
        Me.dpFechaDesde.Key = ""
        Me.dpFechaDesde.LabelAsoc = Nothing
        Me.dpFechaDesde.Location = New System.Drawing.Point(538, 25)
        Me.dpFechaDesde.Name = "dpFechaDesde"
        Me.dpFechaDesde.Size = New System.Drawing.Size(95, 20)
        Me.dpFechaDesde.TabIndex = 96
        '
        'lblEntre
        '
        Me.lblEntre.AutoSize = True
        Me.lblEntre.LabelAsoc = Nothing
        Me.lblEntre.Location = New System.Drawing.Point(391, 29)
        Me.lblEntre.Name = "lblEntre"
        Me.lblEntre.Size = New System.Drawing.Size(141, 13)
        Me.lblEntre.TabIndex = 95
        Me.lblEntre.Text = "Mostrar movimientos entre el"
        '
        'lblCuentaOrigen
        '
        Me.lblCuentaOrigen.AutoSize = True
        Me.lblCuentaOrigen.LabelAsoc = Nothing
        Me.lblCuentaOrigen.Location = New System.Drawing.Point(14, 29)
        Me.lblCuentaOrigen.Name = "lblCuentaOrigen"
        Me.lblCuentaOrigen.Size = New System.Drawing.Size(75, 13)
        Me.lblCuentaOrigen.TabIndex = 94
        Me.lblCuentaOrigen.Text = "Cuenta Origen"
        '
        'bscCuentaBancariaOrigen
        '
        Me.bscCuentaBancariaOrigen.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.bscCuentaBancariaOrigen.AyudaAncho = 608
        Me.bscCuentaBancariaOrigen.BindearPropiedadControl = Nothing
        Me.bscCuentaBancariaOrigen.BindearPropiedadEntidad = Nothing
        Me.bscCuentaBancariaOrigen.ColumnasAlineacion = Nothing
        Me.bscCuentaBancariaOrigen.ColumnasAncho = Nothing
        Me.bscCuentaBancariaOrigen.ColumnasFormato = Nothing
        Me.bscCuentaBancariaOrigen.ColumnasOcultas = New String() {"IdLocalidad", "FechaNacimiento", "NroOperacion", "CorreoElectronico", "Celular", "NombreTrabajo", "DireccionTrabajo", "IdLocalidadTrabajo", "TelefonoTrabajo", "CorreoTrabajo", "FechaIngresoTrabajo", "FechaAlta", "SaldoPendiente", "TipoDocumentoGarante", "NroDocumentoGarante", "IdCategoria", "IdCategoriaFiscal", "NombreCategoriaFiscal", "LetraFiscal"}
        Me.bscCuentaBancariaOrigen.ColumnasTitulos = New String() {"Tipo de Doc", "Documento", "Nombre", "Direccion", "IdLocalidad", "Localidad", "Teléfono", "Categoria Fiscal", "Letra Fiscal"}
        Me.bscCuentaBancariaOrigen.Datos = Nothing
        Me.bscCuentaBancariaOrigen.FilaDevuelta = Nothing
        Me.bscCuentaBancariaOrigen.ForeColorFocus = System.Drawing.Color.Red
        Me.bscCuentaBancariaOrigen.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.bscCuentaBancariaOrigen.IsDecimal = False
        Me.bscCuentaBancariaOrigen.IsNumber = False
        Me.bscCuentaBancariaOrigen.IsPK = False
        Me.bscCuentaBancariaOrigen.IsRequired = False
        Me.bscCuentaBancariaOrigen.Key = ""
        Me.bscCuentaBancariaOrigen.LabelAsoc = Me.lblCuentaOrigen
        Me.bscCuentaBancariaOrigen.Location = New System.Drawing.Point(99, 25)
        Me.bscCuentaBancariaOrigen.MaxLengh = "32767"
        Me.bscCuentaBancariaOrigen.Name = "bscCuentaBancariaOrigen"
        Me.bscCuentaBancariaOrigen.Permitido = True
        Me.bscCuentaBancariaOrigen.Selecciono = False
        Me.bscCuentaBancariaOrigen.Size = New System.Drawing.Size(271, 20)
        Me.bscCuentaBancariaOrigen.TabIndex = 93
        Me.bscCuentaBancariaOrigen.Titulo = "Clientes"
        '
        'tstBarra
        '
        Me.tstBarra.AllowItemReorder = True
        Me.tstBarra.ImageScalingSize = New System.Drawing.Size(22, 22)
        Me.tstBarra.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsbRefrescar, Me.ToolStripSeparator4, Me.tsbPreferencias, Me.ToolStripSeparator1, Me.tsbSalir})
        Me.tstBarra.Location = New System.Drawing.Point(0, 0)
        Me.tstBarra.Name = "tstBarra"
        Me.tstBarra.Size = New System.Drawing.Size(981, 29)
        Me.tstBarra.TabIndex = 91
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
        'lblCuentaDestino
        '
        Me.lblCuentaDestino.AutoSize = True
        Me.lblCuentaDestino.LabelAsoc = Nothing
        Me.lblCuentaDestino.Location = New System.Drawing.Point(12, 496)
        Me.lblCuentaDestino.Name = "lblCuentaDestino"
        Me.lblCuentaDestino.Size = New System.Drawing.Size(80, 13)
        Me.lblCuentaDestino.TabIndex = 73
        Me.lblCuentaDestino.Text = "Cuenta Destino"
        '
        'bscCuentaBancariaDestino
        '
        Me.bscCuentaBancariaDestino.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.bscCuentaBancariaDestino.AyudaAncho = 608
        Me.bscCuentaBancariaDestino.BindearPropiedadControl = Nothing
        Me.bscCuentaBancariaDestino.BindearPropiedadEntidad = Nothing
        Me.bscCuentaBancariaDestino.ColumnasAlineacion = Nothing
        Me.bscCuentaBancariaDestino.ColumnasAncho = Nothing
        Me.bscCuentaBancariaDestino.ColumnasFormato = Nothing
        Me.bscCuentaBancariaDestino.ColumnasOcultas = New String() {"IdLocalidad", "FechaNacimiento", "NroOperacion", "CorreoElectronico", "Celular", "NombreTrabajo", "DireccionTrabajo", "IdLocalidadTrabajo", "TelefonoTrabajo", "CorreoTrabajo", "FechaIngresoTrabajo", "FechaAlta", "SaldoPendiente", "TipoDocumentoGarante", "NroDocumentoGarante", "IdCategoria", "IdCategoriaFiscal", "NombreCategoriaFiscal", "LetraFiscal"}
        Me.bscCuentaBancariaDestino.ColumnasTitulos = New String() {"Tipo de Doc", "Documento", "Nombre", "Direccion", "IdLocalidad", "Localidad", "Teléfono", "Categoria Fiscal", "Letra Fiscal"}
        Me.bscCuentaBancariaDestino.Datos = Nothing
        Me.bscCuentaBancariaDestino.FilaDevuelta = Nothing
        Me.bscCuentaBancariaDestino.ForeColorFocus = System.Drawing.Color.Red
        Me.bscCuentaBancariaDestino.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.bscCuentaBancariaDestino.IsDecimal = False
        Me.bscCuentaBancariaDestino.IsNumber = False
        Me.bscCuentaBancariaDestino.IsPK = False
        Me.bscCuentaBancariaDestino.IsRequired = False
        Me.bscCuentaBancariaDestino.Key = ""
        Me.bscCuentaBancariaDestino.LabelAsoc = Me.lblCuentaDestino
        Me.bscCuentaBancariaDestino.Location = New System.Drawing.Point(98, 495)
        Me.bscCuentaBancariaDestino.MaxLengh = "32767"
        Me.bscCuentaBancariaDestino.Name = "bscCuentaBancariaDestino"
        Me.bscCuentaBancariaDestino.Permitido = True
        Me.bscCuentaBancariaDestino.Selecciono = False
        Me.bscCuentaBancariaDestino.Size = New System.Drawing.Size(271, 20)
        Me.bscCuentaBancariaDestino.TabIndex = 70
        Me.bscCuentaBancariaDestino.Titulo = "Clientes"
        '
        'btnProceder
        '
        Me.btnProceder.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnProceder.Image = Global.Eniac.Win.My.Resources.Resources.ok_32
        Me.btnProceder.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnProceder.Location = New System.Drawing.Point(445, 484)
        Me.btnProceder.Name = "btnProceder"
        Me.btnProceder.Size = New System.Drawing.Size(102, 41)
        Me.btnProceder.TabIndex = 57
        Me.btnProceder.Text = "&Proceder"
        Me.btnProceder.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnProceder.UseVisualStyleBackColor = True
        '
        'IntercambioDeMovimientos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(981, 537)
        Me.Controls.Add(Me.ugDetalle)
        Me.Controls.Add(Me.grbFiltros)
        Me.Controls.Add(Me.tstBarra)
        Me.Controls.Add(Me.lblCuentaDestino)
        Me.Controls.Add(Me.bscCuentaBancariaDestino)
        Me.Controls.Add(Me.btnProceder)
        Me.KeyPreview = True
        Me.Name = "IntercambioDeMovimientos"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Intercambio De Movimientos"
        CType(Me.ugDetalle, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grbFiltros.ResumeLayout(False)
        Me.grbFiltros.PerformLayout()
        Me.tstBarra.ResumeLayout(False)
        Me.tstBarra.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnProceder As System.Windows.Forms.Button
   Friend WithEvents lblCuentaDestino As Eniac.Controles.Label
    Friend WithEvents bscCuentaBancariaDestino As Eniac.Controles.Buscador
   Public WithEvents tstBarra As System.Windows.Forms.ToolStrip
   Public WithEvents tsbRefrescar As System.Windows.Forms.ToolStripButton
   Public WithEvents tsbSalir As System.Windows.Forms.ToolStripButton
   Friend WithEvents imgIconos As System.Windows.Forms.ImageList
   Friend WithEvents grbFiltros As System.Windows.Forms.GroupBox
   Friend WithEvents btnConsultar As Eniac.Controles.Button
   Friend WithEvents dpFechaHasta As Eniac.Controles.DateTimePicker
   Friend WithEvents lblY As Eniac.Controles.Label
   Friend WithEvents dpFechaDesde As Eniac.Controles.DateTimePicker
   Friend WithEvents lblEntre As Eniac.Controles.Label
   Friend WithEvents lblCuentaOrigen As Eniac.Controles.Label
   Friend WithEvents bscCuentaBancariaOrigen As Eniac.Controles.Buscador
   Friend WithEvents ugDetalle As Infragistics.Win.UltraWinGrid.UltraGrid
   Public WithEvents tsbPreferencias As System.Windows.Forms.ToolStripButton
   Private WithEvents ToolStripSeparator4 As System.Windows.Forms.ToolStripSeparator
   Private WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
End Class
