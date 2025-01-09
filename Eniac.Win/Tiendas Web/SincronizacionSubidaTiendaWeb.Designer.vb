<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class SincronizacionSubidaTiendaWeb
    Inherits System.Windows.Forms.Form

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
        Dim Appearance1 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridBand1 As Infragistics.Win.UltraWinGrid.UltraGridBand = New Infragistics.Win.UltraWinGrid.UltraGridBand("Band 0", -1)
        Dim UltraGridColumn6 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Tienda")
        Dim UltraGridColumn1 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Estado")
        Dim Appearance2 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn2 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Nombre")
        Dim Appearance3 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn3 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Metodo")
        Dim Appearance4 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn4 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NroRegistro")
        Dim Appearance5 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn5 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("TotalRegistros")
        Dim Appearance6 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn7 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("TotalRegistrosExitosos")
        Dim Appearance7 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn8 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("TotalRegistrosError")
        Dim Appearance8 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance9 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
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
        Dim UltraGridBand2 As Infragistics.Win.UltraWinGrid.UltraGridBand = New Infragistics.Win.UltraWinGrid.UltraGridBand("Band 0", -1)
        Dim UltraGridColumn9 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Tienda")
        Dim UltraGridColumn10 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Mensaje")
        Dim UltraGridColumn11 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("ElementoTransmitido")
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
        Dim Appearance31 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Me.stsStado = New System.Windows.Forms.StatusStrip()
        Me.tssInfo = New System.Windows.Forms.ToolStripStatusLabel()
        Me.tssVersionAPI = New System.Windows.Forms.ToolStripStatusLabel()
        Me.btnSincronizar = New System.Windows.Forms.Button()
        Me.tbcLog = New System.Windows.Forms.TabControl()
        Me.tbpResumen = New System.Windows.Forms.TabPage()
        Me.ugResumen = New Infragistics.Win.UltraWinGrid.UltraGrid()
        Me.tbpErrores = New System.Windows.Forms.TabPage()
        Me.ugDetallesError = New Infragistics.Win.UltraWinGrid.UltraGrid()
        Me.bwSincronizacion = New System.ComponentModel.BackgroundWorker()
        Me.chbReenviarTodos = New System.Windows.Forms.CheckBox()
        Me.tstBarra = New System.Windows.Forms.ToolStrip()
        Me.tsbRefrescar = New System.Windows.Forms.ToolStripButton()
        Me.toolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsbSalir = New System.Windows.Forms.ToolStripButton()
        Me.chbClientes = New System.Windows.Forms.CheckBox()
        Me.chbCategorias = New System.Windows.Forms.CheckBox()
        Me.chbProductos = New System.Windows.Forms.CheckBox()
        Me.chbPrecios = New System.Windows.Forms.CheckBox()
        Me.pnlModulos = New System.Windows.Forms.FlowLayoutPanel()
        Me.pnlTiendas = New System.Windows.Forms.FlowLayoutPanel()
        Me.chbSincronizaTiendaNube = New System.Windows.Forms.CheckBox()
        Me.chbSincronizaMercadoLibre = New System.Windows.Forms.CheckBox()
        Me.chbSincronizaArborea = New System.Windows.Forms.CheckBox()
        Me.stsStado.SuspendLayout()
        Me.tbcLog.SuspendLayout()
        Me.tbpResumen.SuspendLayout()
        CType(Me.ugResumen, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tbpErrores.SuspendLayout()
        CType(Me.ugDetallesError, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tstBarra.SuspendLayout()
        Me.pnlModulos.SuspendLayout()
        Me.pnlTiendas.SuspendLayout()
        Me.SuspendLayout()
        '
        'stsStado
        '
        Me.stsStado.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tssInfo, Me.tssVersionAPI})
        Me.stsStado.Location = New System.Drawing.Point(0, 439)
        Me.stsStado.Name = "stsStado"
        Me.stsStado.Size = New System.Drawing.Size(904, 22)
        Me.stsStado.TabIndex = 5
        Me.stsStado.Text = "statusStrip1"
        '
        'tssInfo
        '
        Me.tssInfo.Name = "tssInfo"
        Me.tssInfo.Size = New System.Drawing.Size(889, 17)
        Me.tssInfo.Spring = True
        Me.tssInfo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'tssVersionAPI
        '
        Me.tssVersionAPI.Name = "tssVersionAPI"
        Me.tssVersionAPI.Size = New System.Drawing.Size(0, 17)
        '
        'btnSincronizar
        '
        Me.btnSincronizar.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSincronizar.Image = Global.Eniac.Win.My.Resources.Resources.exchange
        Me.btnSincronizar.Location = New System.Drawing.Point(42, 73)
        Me.btnSincronizar.Name = "btnSincronizar"
        Me.btnSincronizar.Size = New System.Drawing.Size(230, 99)
        Me.btnSincronizar.TabIndex = 19
        Me.btnSincronizar.Text = "Sincronizar"
        Me.btnSincronizar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnSincronizar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnSincronizar.UseVisualStyleBackColor = True
        '
        'tbcLog
        '
        Me.tbcLog.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tbcLog.Controls.Add(Me.tbpResumen)
        Me.tbcLog.Controls.Add(Me.tbpErrores)
        Me.tbcLog.Location = New System.Drawing.Point(313, 45)
        Me.tbcLog.Name = "tbcLog"
        Me.tbcLog.SelectedIndex = 0
        Me.tbcLog.Size = New System.Drawing.Size(579, 391)
        Me.tbcLog.TabIndex = 22
        '
        'tbpResumen
        '
        Me.tbpResumen.Controls.Add(Me.ugResumen)
        Me.tbpResumen.Location = New System.Drawing.Point(4, 22)
        Me.tbpResumen.Name = "tbpResumen"
        Me.tbpResumen.Size = New System.Drawing.Size(571, 365)
        Me.tbpResumen.TabIndex = 2
        Me.tbpResumen.Text = "Resumen"
        Me.tbpResumen.UseVisualStyleBackColor = True
        '
        'ugResumen
        '
        Appearance1.BackColor = System.Drawing.SystemColors.Window
        Appearance1.BorderColor = System.Drawing.SystemColors.InactiveCaption
        Me.ugResumen.DisplayLayout.Appearance = Appearance1
        UltraGridColumn6.Header.VisiblePosition = 0
        UltraGridColumn6.Width = 100
        UltraGridColumn1.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        Appearance2.TextHAlignAsString = "Left"
        UltraGridColumn1.CellAppearance = Appearance2
        UltraGridColumn1.Header.VisiblePosition = 1
        UltraGridColumn1.Width = 81
        UltraGridColumn2.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        Appearance3.TextHAlignAsString = "Left"
        UltraGridColumn2.CellAppearance = Appearance3
        UltraGridColumn2.Header.VisiblePosition = 2
        UltraGridColumn2.Width = 98
        UltraGridColumn3.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        Appearance4.TextHAlignAsString = "Left"
        UltraGridColumn3.CellAppearance = Appearance4
        UltraGridColumn3.Header.VisiblePosition = 3
        UltraGridColumn3.Hidden = True
        UltraGridColumn4.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        Appearance5.TextHAlignAsString = "Right"
        UltraGridColumn4.CellAppearance = Appearance5
        UltraGridColumn4.Header.Caption = "#"
        UltraGridColumn4.Header.VisiblePosition = 4
        UltraGridColumn4.Width = 30
        UltraGridColumn5.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        Appearance6.TextHAlignAsString = "Right"
        UltraGridColumn5.CellAppearance = Appearance6
        UltraGridColumn5.Header.Caption = "Total"
        UltraGridColumn5.Header.VisiblePosition = 5
        UltraGridColumn5.Width = 77
        Appearance7.TextHAlignAsString = "Right"
        UltraGridColumn7.CellAppearance = Appearance7
        UltraGridColumn7.Header.Caption = "Exitosos"
        UltraGridColumn7.Header.VisiblePosition = 6
        UltraGridColumn7.Width = 77
        Appearance8.TextHAlignAsString = "Right"
        UltraGridColumn8.CellAppearance = Appearance8
        UltraGridColumn8.Header.Caption = "Errores"
        UltraGridColumn8.Header.VisiblePosition = 7
        UltraGridColumn8.Width = 77
        UltraGridBand1.Columns.AddRange(New Object() {UltraGridColumn6, UltraGridColumn1, UltraGridColumn2, UltraGridColumn3, UltraGridColumn4, UltraGridColumn5, UltraGridColumn7, UltraGridColumn8})
        Me.ugResumen.DisplayLayout.BandsSerializer.Add(UltraGridBand1)
        Me.ugResumen.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.ugResumen.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.[False]
        Appearance9.BackColor = System.Drawing.SystemColors.ActiveBorder
        Appearance9.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance9.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Appearance9.BorderColor = System.Drawing.SystemColors.Window
        Me.ugResumen.DisplayLayout.GroupByBox.Appearance = Appearance9
        Appearance10.ForeColor = System.Drawing.SystemColors.GrayText
        Me.ugResumen.DisplayLayout.GroupByBox.BandLabelAppearance = Appearance10
        Me.ugResumen.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.ugResumen.DisplayLayout.GroupByBox.Hidden = True
        Appearance11.BackColor = System.Drawing.SystemColors.ControlLightLight
        Appearance11.BackColor2 = System.Drawing.SystemColors.Control
        Appearance11.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance11.ForeColor = System.Drawing.SystemColors.GrayText
        Me.ugResumen.DisplayLayout.GroupByBox.PromptAppearance = Appearance11
        Me.ugResumen.DisplayLayout.MaxColScrollRegions = 1
        Me.ugResumen.DisplayLayout.MaxRowScrollRegions = 1
        Appearance12.BackColor = System.Drawing.SystemColors.Window
        Appearance12.ForeColor = System.Drawing.SystemColors.ControlText
        Me.ugResumen.DisplayLayout.Override.ActiveCellAppearance = Appearance12
        Appearance13.BackColor = System.Drawing.SystemColors.Highlight
        Appearance13.ForeColor = System.Drawing.SystemColors.HighlightText
        Me.ugResumen.DisplayLayout.Override.ActiveRowAppearance = Appearance13
        Me.ugResumen.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted
        Me.ugResumen.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted
        Appearance14.BackColor = System.Drawing.SystemColors.Window
        Me.ugResumen.DisplayLayout.Override.CardAreaAppearance = Appearance14
        Appearance15.BorderColor = System.Drawing.Color.Silver
        Appearance15.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter
        Me.ugResumen.DisplayLayout.Override.CellAppearance = Appearance15
        Me.ugResumen.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText
        Me.ugResumen.DisplayLayout.Override.CellPadding = 0
        Appearance16.BackColor = System.Drawing.SystemColors.Control
        Appearance16.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance16.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element
        Appearance16.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance16.BorderColor = System.Drawing.SystemColors.Window
        Me.ugResumen.DisplayLayout.Override.GroupByRowAppearance = Appearance16
        Appearance17.TextHAlignAsString = "Left"
        Me.ugResumen.DisplayLayout.Override.HeaderAppearance = Appearance17
        Me.ugResumen.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
        Me.ugResumen.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand
        Appearance18.BackColor = System.Drawing.SystemColors.Window
        Appearance18.BorderColor = System.Drawing.Color.Silver
        Me.ugResumen.DisplayLayout.Override.RowAppearance = Appearance18
        Me.ugResumen.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[False]
        Appearance19.BackColor = System.Drawing.SystemColors.ControlLight
        Me.ugResumen.DisplayLayout.Override.TemplateAddRowAppearance = Appearance19
        Me.ugResumen.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill
        Me.ugResumen.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate
        Me.ugResumen.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy
        Me.ugResumen.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ugResumen.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ugResumen.Location = New System.Drawing.Point(0, 0)
        Me.ugResumen.Name = "ugResumen"
        Me.ugResumen.Size = New System.Drawing.Size(571, 365)
        Me.ugResumen.TabIndex = 0
        Me.ugResumen.Text = "UltraGrid1"
        '
        'tbpErrores
        '
        Me.tbpErrores.BackColor = System.Drawing.SystemColors.Control
        Me.tbpErrores.Controls.Add(Me.ugDetallesError)
        Me.tbpErrores.Location = New System.Drawing.Point(4, 22)
        Me.tbpErrores.Name = "tbpErrores"
        Me.tbpErrores.Size = New System.Drawing.Size(571, 365)
        Me.tbpErrores.TabIndex = 3
        Me.tbpErrores.Text = "Errores"
        '
        'ugDetallesError
        '
        Appearance20.BackColor = System.Drawing.SystemColors.Window
        Appearance20.BorderColor = System.Drawing.SystemColors.InactiveCaption
        Me.ugDetallesError.DisplayLayout.Appearance = Appearance20
        UltraGridColumn9.Header.VisiblePosition = 0
        UltraGridColumn9.Width = 100
        UltraGridColumn10.Header.VisiblePosition = 2
        UltraGridColumn10.Width = 500
        UltraGridColumn11.Header.Caption = "Enviando..."
        UltraGridColumn11.Header.VisiblePosition = 1
        UltraGridColumn11.Width = 118
        UltraGridBand2.Columns.AddRange(New Object() {UltraGridColumn9, UltraGridColumn10, UltraGridColumn11})
        Me.ugDetallesError.DisplayLayout.BandsSerializer.Add(UltraGridBand2)
        Me.ugDetallesError.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.ugDetallesError.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.[False]
        Appearance21.BackColor = System.Drawing.SystemColors.ActiveBorder
        Appearance21.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance21.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Appearance21.BorderColor = System.Drawing.SystemColors.Window
        Me.ugDetallesError.DisplayLayout.GroupByBox.Appearance = Appearance21
        Appearance22.ForeColor = System.Drawing.SystemColors.GrayText
        Me.ugDetallesError.DisplayLayout.GroupByBox.BandLabelAppearance = Appearance22
        Me.ugDetallesError.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Appearance23.BackColor = System.Drawing.SystemColors.ControlLightLight
        Appearance23.BackColor2 = System.Drawing.SystemColors.Control
        Appearance23.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance23.ForeColor = System.Drawing.SystemColors.GrayText
        Me.ugDetallesError.DisplayLayout.GroupByBox.PromptAppearance = Appearance23
        Me.ugDetallesError.DisplayLayout.MaxColScrollRegions = 1
        Me.ugDetallesError.DisplayLayout.MaxRowScrollRegions = 1
        Appearance24.BackColor = System.Drawing.SystemColors.Window
        Appearance24.ForeColor = System.Drawing.SystemColors.ControlText
        Me.ugDetallesError.DisplayLayout.Override.ActiveCellAppearance = Appearance24
        Appearance25.BackColor = System.Drawing.SystemColors.Highlight
        Appearance25.ForeColor = System.Drawing.SystemColors.HighlightText
        Me.ugDetallesError.DisplayLayout.Override.ActiveRowAppearance = Appearance25
        Me.ugDetallesError.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted
        Me.ugDetallesError.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted
        Appearance26.BackColor = System.Drawing.SystemColors.Window
        Me.ugDetallesError.DisplayLayout.Override.CardAreaAppearance = Appearance26
        Appearance27.BorderColor = System.Drawing.Color.Silver
        Appearance27.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter
        Me.ugDetallesError.DisplayLayout.Override.CellAppearance = Appearance27
        Me.ugDetallesError.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText
        Me.ugDetallesError.DisplayLayout.Override.CellPadding = 0
        Appearance28.BackColor = System.Drawing.SystemColors.Control
        Appearance28.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance28.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element
        Appearance28.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance28.BorderColor = System.Drawing.SystemColors.Window
        Me.ugDetallesError.DisplayLayout.Override.GroupByRowAppearance = Appearance28
        Appearance29.TextHAlignAsString = "Left"
        Me.ugDetallesError.DisplayLayout.Override.HeaderAppearance = Appearance29
        Me.ugDetallesError.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
        Me.ugDetallesError.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand
        Appearance30.BackColor = System.Drawing.SystemColors.Window
        Appearance30.BorderColor = System.Drawing.Color.Silver
        Me.ugDetallesError.DisplayLayout.Override.RowAppearance = Appearance30
        Me.ugDetallesError.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[False]
        Appearance31.BackColor = System.Drawing.SystemColors.ControlLight
        Me.ugDetallesError.DisplayLayout.Override.TemplateAddRowAppearance = Appearance31
        Me.ugDetallesError.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill
        Me.ugDetallesError.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate
        Me.ugDetallesError.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy
        Me.ugDetallesError.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ugDetallesError.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ugDetallesError.Location = New System.Drawing.Point(0, 0)
        Me.ugDetallesError.Name = "ugDetallesError"
        Me.ugDetallesError.Size = New System.Drawing.Size(571, 365)
        Me.ugDetallesError.TabIndex = 0
        Me.ugDetallesError.Text = "UltraGrid1"
        '
        'bwSincronizacion
        '
        Me.bwSincronizacion.WorkerReportsProgress = True
        Me.bwSincronizacion.WorkerSupportsCancellation = True
        '
        'chbReenviarTodos
        '
        Me.chbReenviarTodos.AutoSize = True
        Me.chbReenviarTodos.Location = New System.Drawing.Point(110, 50)
        Me.chbReenviarTodos.Name = "chbReenviarTodos"
        Me.chbReenviarTodos.Size = New System.Drawing.Size(102, 17)
        Me.chbReenviarTodos.TabIndex = 23
        Me.chbReenviarTodos.Text = "Reenviar Todos"
        Me.chbReenviarTodos.UseVisualStyleBackColor = True
        '
        'tstBarra
        '
        Me.tstBarra.AllowItemReorder = True
        Me.tstBarra.ImageScalingSize = New System.Drawing.Size(22, 22)
        Me.tstBarra.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsbRefrescar, Me.toolStripSeparator3, Me.tsbSalir})
        Me.tstBarra.Location = New System.Drawing.Point(0, 0)
        Me.tstBarra.Name = "tstBarra"
        Me.tstBarra.Size = New System.Drawing.Size(904, 29)
        Me.tstBarra.TabIndex = 26
        Me.tstBarra.Text = "toolStrip1"
        '
        'tsbRefrescar
        '
        Me.tsbRefrescar.Image = Global.Eniac.Win.My.Resources.Resources.refresh_24
        Me.tsbRefrescar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbRefrescar.Name = "tsbRefrescar"
        Me.tsbRefrescar.Size = New System.Drawing.Size(104, 26)
        Me.tsbRefrescar.Text = "&Refrescar (F5)"
        '
        'toolStripSeparator3
        '
        Me.toolStripSeparator3.Name = "toolStripSeparator3"
        Me.toolStripSeparator3.Size = New System.Drawing.Size(6, 29)
        '
        'tsbSalir
        '
        Me.tsbSalir.Image = Global.Eniac.Win.My.Resources.Resources.close_b_24
        Me.tsbSalir.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbSalir.Name = "tsbSalir"
        Me.tsbSalir.Size = New System.Drawing.Size(65, 26)
        Me.tsbSalir.Text = "&Cerrar"
        Me.tsbSalir.ToolTipText = "Cerrar el formulario"
        '
        'chbClientes
        '
        Me.chbClientes.AutoSize = True
        Me.chbClientes.Checked = True
        Me.chbClientes.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chbClientes.Location = New System.Drawing.Point(3, 3)
        Me.chbClientes.Name = "chbClientes"
        Me.chbClientes.Size = New System.Drawing.Size(63, 17)
        Me.chbClientes.TabIndex = 27
        Me.chbClientes.Text = "Clientes"
        Me.chbClientes.UseVisualStyleBackColor = True
        '
        'chbCategorias
        '
        Me.chbCategorias.AutoSize = True
        Me.chbCategorias.Checked = True
        Me.chbCategorias.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chbCategorias.Location = New System.Drawing.Point(72, 3)
        Me.chbCategorias.Name = "chbCategorias"
        Me.chbCategorias.Size = New System.Drawing.Size(78, 17)
        Me.chbCategorias.TabIndex = 28
        Me.chbCategorias.Text = "Categorías"
        Me.chbCategorias.UseVisualStyleBackColor = True
        '
        'chbProductos
        '
        Me.chbProductos.AutoSize = True
        Me.chbProductos.Checked = True
        Me.chbProductos.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chbProductos.Location = New System.Drawing.Point(156, 3)
        Me.chbProductos.Name = "chbProductos"
        Me.chbProductos.Size = New System.Drawing.Size(74, 17)
        Me.chbProductos.TabIndex = 29
        Me.chbProductos.Text = "Productos"
        Me.chbProductos.UseVisualStyleBackColor = True
        '
        'chbPrecios
        '
        Me.chbPrecios.AutoSize = True
        Me.chbPrecios.Checked = True
        Me.chbPrecios.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chbPrecios.Location = New System.Drawing.Point(236, 3)
        Me.chbPrecios.Name = "chbPrecios"
        Me.chbPrecios.Size = New System.Drawing.Size(61, 17)
        Me.chbPrecios.TabIndex = 30
        Me.chbPrecios.Text = "Precios"
        Me.chbPrecios.UseVisualStyleBackColor = True
        '
        'pnlModulos
        '
        Me.pnlModulos.AutoSize = True
        Me.pnlModulos.Controls.Add(Me.chbClientes)
        Me.pnlModulos.Controls.Add(Me.chbCategorias)
        Me.pnlModulos.Controls.Add(Me.chbProductos)
        Me.pnlModulos.Controls.Add(Me.chbPrecios)
        Me.pnlModulos.Location = New System.Drawing.Point(7, 203)
        Me.pnlModulos.MaximumSize = New System.Drawing.Size(300, 5000)
        Me.pnlModulos.Name = "pnlModulos"
        Me.pnlModulos.Size = New System.Drawing.Size(300, 23)
        Me.pnlModulos.TabIndex = 31
        '
        'pnlTiendas
        '
        Me.pnlTiendas.AutoSize = True
        Me.pnlTiendas.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.pnlTiendas.Controls.Add(Me.chbSincronizaTiendaNube)
        Me.pnlTiendas.Controls.Add(Me.chbSincronizaMercadoLibre)
        Me.pnlTiendas.Controls.Add(Me.chbSincronizaArborea)
        Me.pnlTiendas.Location = New System.Drawing.Point(26, 176)
        Me.pnlTiendas.Name = "pnlTiendas"
        Me.pnlTiendas.Size = New System.Drawing.Size(263, 23)
        Me.pnlTiendas.TabIndex = 32
        '
        'chbSincronizaTiendaNube
        '
        Me.chbSincronizaTiendaNube.AutoSize = True
        Me.chbSincronizaTiendaNube.Checked = True
        Me.chbSincronizaTiendaNube.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chbSincronizaTiendaNube.Location = New System.Drawing.Point(3, 3)
        Me.chbSincronizaTiendaNube.Name = "chbSincronizaTiendaNube"
        Me.chbSincronizaTiendaNube.Size = New System.Drawing.Size(88, 17)
        Me.chbSincronizaTiendaNube.TabIndex = 28
        Me.chbSincronizaTiendaNube.Text = "Tienda Nube"
        Me.chbSincronizaTiendaNube.UseVisualStyleBackColor = True
        '
        'chbSincronizaMercadoLibre
        '
        Me.chbSincronizaMercadoLibre.AutoSize = True
        Me.chbSincronizaMercadoLibre.Checked = True
        Me.chbSincronizaMercadoLibre.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chbSincronizaMercadoLibre.Location = New System.Drawing.Point(97, 3)
        Me.chbSincronizaMercadoLibre.Name = "chbSincronizaMercadoLibre"
        Me.chbSincronizaMercadoLibre.Size = New System.Drawing.Size(94, 17)
        Me.chbSincronizaMercadoLibre.TabIndex = 29
        Me.chbSincronizaMercadoLibre.Text = "Mercado Libre"
        Me.chbSincronizaMercadoLibre.UseVisualStyleBackColor = True
        '
        'chbSincronizaArborea
        '
        Me.chbSincronizaArborea.AutoSize = True
        Me.chbSincronizaArborea.Checked = True
        Me.chbSincronizaArborea.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chbSincronizaArborea.Location = New System.Drawing.Point(197, 3)
        Me.chbSincronizaArborea.Name = "chbSincronizaArborea"
        Me.chbSincronizaArborea.Size = New System.Drawing.Size(63, 17)
        Me.chbSincronizaArborea.TabIndex = 30
        Me.chbSincronizaArborea.Text = "Arborea"
        Me.chbSincronizaArborea.UseVisualStyleBackColor = True
        '
        'SincronizacionSubidaTiendaWeb
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(904, 461)
        Me.Controls.Add(Me.pnlTiendas)
        Me.Controls.Add(Me.pnlModulos)
        Me.Controls.Add(Me.tstBarra)
        Me.Controls.Add(Me.chbReenviarTodos)
        Me.Controls.Add(Me.tbcLog)
        Me.Controls.Add(Me.btnSincronizar)
        Me.Controls.Add(Me.stsStado)
        Me.Name = "SincronizacionSubidaTiendaWeb"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Sincronización Subida - Tienda Web"
        Me.stsStado.ResumeLayout(False)
        Me.stsStado.PerformLayout()
        Me.tbcLog.ResumeLayout(False)
        Me.tbpResumen.ResumeLayout(False)
        CType(Me.ugResumen, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tbpErrores.ResumeLayout(False)
        CType(Me.ugDetallesError, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tstBarra.ResumeLayout(False)
        Me.tstBarra.PerformLayout()
        Me.pnlModulos.ResumeLayout(False)
        Me.pnlModulos.PerformLayout()
        Me.pnlTiendas.ResumeLayout(False)
        Me.pnlTiendas.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Protected Friend WithEvents stsStado As System.Windows.Forms.StatusStrip
    Protected Friend WithEvents tssInfo As System.Windows.Forms.ToolStripStatusLabel
    Protected WithEvents tssVersionAPI As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents btnSincronizar As System.Windows.Forms.Button
    Friend WithEvents tbcLog As System.Windows.Forms.TabControl
    Friend WithEvents tbpResumen As System.Windows.Forms.TabPage
    Friend WithEvents ugResumen As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents bwSincronizacion As System.ComponentModel.BackgroundWorker
    Friend WithEvents chbReenviarTodos As System.Windows.Forms.CheckBox
    Public WithEvents tstBarra As System.Windows.Forms.ToolStrip
    Public WithEvents tsbRefrescar As System.Windows.Forms.ToolStripButton
    Private WithEvents toolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Public WithEvents tsbSalir As System.Windows.Forms.ToolStripButton
    Friend WithEvents chbClientes As CheckBox
    Friend WithEvents chbCategorias As CheckBox
    Friend WithEvents chbProductos As CheckBox
    Friend WithEvents chbPrecios As CheckBox
    Friend WithEvents pnlModulos As FlowLayoutPanel
    Friend WithEvents pnlTiendas As FlowLayoutPanel
    Friend WithEvents chbSincronizaTiendaNube As CheckBox
    Friend WithEvents chbSincronizaMercadoLibre As CheckBox
    Friend WithEvents chbSincronizaArborea As CheckBox
    Friend WithEvents tbpErrores As TabPage
    Friend WithEvents ugDetallesError As UltraGrid
End Class
