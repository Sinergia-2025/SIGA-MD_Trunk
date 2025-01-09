<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class EstadoSituacionCrediticiaCalculoMasivo
   Inherits BaseForm

   'Form reemplaza a Dispose para limpiar la lista de componentes.
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

   'Requerido por el Diseñador de Windows Forms
   Private components As System.ComponentModel.IContainer

   'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
   'Se puede modificar usando el Diseñador de Windows Forms.  
   'No lo modifique con el editor de código.
   <System.Diagnostics.DebuggerStepThrough()>
   Private Sub InitializeComponent()
      Dim Appearance1 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridBand1 As Infragistics.Win.UltraWinGrid.UltraGridBand = New Infragistics.Win.UltraWinGrid.UltraGridBand("Band 0", -1)
      Dim UltraGridColumn1 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("CodigoCliente")
      Dim Appearance2 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn2 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreCliente")
      Dim UltraGridColumn3 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("SaldoLimiteCredigoNuevo")
      Dim Appearance3 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn4 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("EtapaResult")
      Dim UltraGridColumn9 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("TiempoResult")
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
      Dim Appearance14 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim Appearance15 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim Appearance16 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridBand2 As Infragistics.Win.UltraWinGrid.UltraGridBand = New Infragistics.Win.UltraWinGrid.UltraGridBand("Band 0", -1)
      Dim UltraGridColumn5 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("CodigoCliente")
      Dim Appearance17 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn6 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreCliente")
      Dim UltraGridColumn7 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("EtapaResult")
      Dim UltraGridColumn8 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Mensaje")
      Dim UltraGridColumn10 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("TiempoResult")
      Dim Appearance18 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
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
      Me.tstBarra = New System.Windows.Forms.ToolStrip()
      Me.tsbRefrescar = New System.Windows.Forms.ToolStripButton()
      Me.toolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
      Me.tsbSalir = New System.Windows.Forms.ToolStripButton()
      Me.tbcLog = New System.Windows.Forms.TabControl()
      Me.tbpResumen = New System.Windows.Forms.TabPage()
      Me.ugResumen = New Infragistics.Win.UltraWinGrid.UltraGrid()
      Me.tbpErrores = New System.Windows.Forms.TabPage()
      Me.ugDetallesError = New Infragistics.Win.UltraWinGrid.UltraGrid()
      Me.btnCalcular = New System.Windows.Forms.Button()
      Me.tssInfo = New System.Windows.Forms.ToolStripStatusLabel()
      Me.stsStado = New System.Windows.Forms.StatusStrip()
      Me.tssVersionAPI = New System.Windows.Forms.ToolStripStatusLabel()
      Me.bwSincronizacion = New System.ComponentModel.BackgroundWorker()
      Me.pnlParametros = New System.Windows.Forms.Panel()
      Me.chbSaldoLimiteCreditoContemplaPedidos = New Eniac.Controles.CheckBox()
      Me.chbSaldoLimiteCreditoContemplaAnticipos = New Eniac.Controles.CheckBox()
      Me.pnlAcciones = New System.Windows.Forms.Panel()
        Me.tstBarra.SuspendLayout()
        Me.tbcLog.SuspendLayout()
        Me.tbpResumen.SuspendLayout()
        CType(Me.ugResumen, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tbpErrores.SuspendLayout()
        CType(Me.ugDetallesError, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.stsStado.SuspendLayout()
        Me.pnlParametros.SuspendLayout()
        Me.pnlAcciones.SuspendLayout()
        Me.SuspendLayout()
        '
        'tstBarra
        '
        Me.tstBarra.AllowItemReorder = True
        Me.tstBarra.ImageScalingSize = New System.Drawing.Size(22, 22)
        Me.tstBarra.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsbRefrescar, Me.toolStripSeparator3, Me.tsbSalir})
        Me.tstBarra.Location = New System.Drawing.Point(0, 0)
        Me.tstBarra.Name = "tstBarra"
        Me.tstBarra.Size = New System.Drawing.Size(984, 29)
        Me.tstBarra.TabIndex = 31
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
        'tbcLog
        '
        Me.tbcLog.Controls.Add(Me.tbpResumen)
        Me.tbcLog.Controls.Add(Me.tbpErrores)
        Me.tbcLog.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tbcLog.Location = New System.Drawing.Point(246, 29)
        Me.tbcLog.Name = "tbcLog"
        Me.tbcLog.SelectedIndex = 0
        Me.tbcLog.Size = New System.Drawing.Size(738, 410)
        Me.tbcLog.TabIndex = 34
        '
        'tbpResumen
        '
        Me.tbpResumen.Controls.Add(Me.ugResumen)
        Me.tbpResumen.Location = New System.Drawing.Point(4, 22)
        Me.tbpResumen.Name = "tbpResumen"
        Me.tbpResumen.Size = New System.Drawing.Size(730, 384)
        Me.tbpResumen.TabIndex = 2
        Me.tbpResumen.Text = "Resumen"
        Me.tbpResumen.UseVisualStyleBackColor = True
        '
        'ugResumen
        '
        Appearance1.BackColor = System.Drawing.SystemColors.Window
        Appearance1.BorderColor = System.Drawing.SystemColors.InactiveCaption
        Me.ugResumen.DisplayLayout.Appearance = Appearance1
        Appearance2.TextHAlignAsString = "Right"
        UltraGridColumn1.CellAppearance = Appearance2
        UltraGridColumn1.Header.Caption = "Código"
        UltraGridColumn1.Header.VisiblePosition = 0
        UltraGridColumn1.Width = 100
        UltraGridColumn2.Header.Caption = "Cliente"
        UltraGridColumn2.Header.VisiblePosition = 1
        UltraGridColumn2.Width = 200
        Appearance3.TextHAlignAsString = "Right"
        UltraGridColumn3.CellAppearance = Appearance3
        UltraGridColumn3.Format = "N2"
        UltraGridColumn3.Header.Caption = "Nuevo Saldo"
        UltraGridColumn3.Header.VisiblePosition = 4
        UltraGridColumn3.Width = 120
        UltraGridColumn4.Header.Caption = ""
        UltraGridColumn4.Header.VisiblePosition = 2
        UltraGridColumn4.Width = 140
        Appearance4.TextHAlignAsString = "Right"
        UltraGridColumn9.CellAppearance = Appearance4
        UltraGridColumn9.Header.Caption = "Tiempo (seg)"
        UltraGridColumn9.Header.VisiblePosition = 3
        UltraGridColumn9.Width = 100
        UltraGridBand1.Columns.AddRange(New Object() {UltraGridColumn1, UltraGridColumn2, UltraGridColumn3, UltraGridColumn4, UltraGridColumn9})
        Me.ugResumen.DisplayLayout.BandsSerializer.Add(UltraGridBand1)
        Me.ugResumen.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.ugResumen.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.[False]
        Appearance5.BackColor = System.Drawing.SystemColors.ActiveBorder
        Appearance5.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance5.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Appearance5.BorderColor = System.Drawing.SystemColors.Window
        Me.ugResumen.DisplayLayout.GroupByBox.Appearance = Appearance5
        Appearance6.ForeColor = System.Drawing.SystemColors.GrayText
        Me.ugResumen.DisplayLayout.GroupByBox.BandLabelAppearance = Appearance6
        Me.ugResumen.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.ugResumen.DisplayLayout.GroupByBox.Hidden = True
        Appearance7.BackColor = System.Drawing.SystemColors.ControlLightLight
        Appearance7.BackColor2 = System.Drawing.SystemColors.Control
        Appearance7.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance7.ForeColor = System.Drawing.SystemColors.GrayText
        Me.ugResumen.DisplayLayout.GroupByBox.PromptAppearance = Appearance7
        Me.ugResumen.DisplayLayout.MaxColScrollRegions = 1
        Me.ugResumen.DisplayLayout.MaxRowScrollRegions = 1
        Appearance8.BackColor = System.Drawing.SystemColors.Window
        Appearance8.ForeColor = System.Drawing.SystemColors.ControlText
        Me.ugResumen.DisplayLayout.Override.ActiveCellAppearance = Appearance8
        Appearance9.BackColor = System.Drawing.SystemColors.Highlight
        Appearance9.ForeColor = System.Drawing.SystemColors.HighlightText
        Me.ugResumen.DisplayLayout.Override.ActiveRowAppearance = Appearance9
        Me.ugResumen.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted
        Me.ugResumen.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted
        Appearance10.BackColor = System.Drawing.SystemColors.Window
        Me.ugResumen.DisplayLayout.Override.CardAreaAppearance = Appearance10
        Appearance11.BorderColor = System.Drawing.Color.Silver
        Appearance11.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter
        Me.ugResumen.DisplayLayout.Override.CellAppearance = Appearance11
        Me.ugResumen.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText
        Me.ugResumen.DisplayLayout.Override.CellPadding = 0
        Appearance12.BackColor = System.Drawing.SystemColors.Control
        Appearance12.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance12.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element
        Appearance12.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance12.BorderColor = System.Drawing.SystemColors.Window
        Me.ugResumen.DisplayLayout.Override.GroupByRowAppearance = Appearance12
        Appearance13.TextHAlignAsString = "Left"
        Me.ugResumen.DisplayLayout.Override.HeaderAppearance = Appearance13
        Me.ugResumen.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
        Me.ugResumen.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand
        Appearance14.BackColor = System.Drawing.SystemColors.Window
        Appearance14.BorderColor = System.Drawing.Color.Silver
        Me.ugResumen.DisplayLayout.Override.RowAppearance = Appearance14
        Me.ugResumen.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[False]
        Appearance15.BackColor = System.Drawing.SystemColors.ControlLight
        Me.ugResumen.DisplayLayout.Override.TemplateAddRowAppearance = Appearance15
        Me.ugResumen.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill
        Me.ugResumen.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate
        Me.ugResumen.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy
        Me.ugResumen.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ugResumen.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ugResumen.Location = New System.Drawing.Point(0, 0)
        Me.ugResumen.Name = "ugResumen"
        Me.ugResumen.Size = New System.Drawing.Size(730, 384)
        Me.ugResumen.TabIndex = 0
        Me.ugResumen.Text = "UltraGrid1"
        '
        'tbpErrores
        '
        Me.tbpErrores.BackColor = System.Drawing.SystemColors.Control
        Me.tbpErrores.Controls.Add(Me.ugDetallesError)
        Me.tbpErrores.Location = New System.Drawing.Point(4, 22)
        Me.tbpErrores.Name = "tbpErrores"
        Me.tbpErrores.Size = New System.Drawing.Size(730, 384)
        Me.tbpErrores.TabIndex = 3
        Me.tbpErrores.Text = "Errores"
        '
        'ugDetallesError
        '
        Appearance16.BackColor = System.Drawing.SystemColors.Window
        Appearance16.BorderColor = System.Drawing.SystemColors.InactiveCaption
        Me.ugDetallesError.DisplayLayout.Appearance = Appearance16
        Appearance17.TextHAlignAsString = "Right"
        UltraGridColumn5.CellAppearance = Appearance17
        UltraGridColumn5.Header.Caption = "Código"
        UltraGridColumn5.Header.VisiblePosition = 0
        UltraGridColumn5.Width = 100
        UltraGridColumn6.Header.Caption = "Cliente"
        UltraGridColumn6.Header.VisiblePosition = 1
        UltraGridColumn6.Width = 200
        UltraGridColumn7.Header.Caption = ""
        UltraGridColumn7.Header.VisiblePosition = 2
        UltraGridColumn7.Width = 140
        UltraGridColumn8.Header.VisiblePosition = 3
        UltraGridColumn8.Width = 1000
        UltraGridColumn10.Header.Caption = "Tiempo"
        UltraGridColumn10.Header.VisiblePosition = 4
        UltraGridColumn10.Width = 100
        UltraGridBand2.Columns.AddRange(New Object() {UltraGridColumn5, UltraGridColumn6, UltraGridColumn7, UltraGridColumn8, UltraGridColumn10})
        Me.ugDetallesError.DisplayLayout.BandsSerializer.Add(UltraGridBand2)
        Me.ugDetallesError.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.ugDetallesError.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.[False]
        Appearance18.BackColor = System.Drawing.SystemColors.ActiveBorder
        Appearance18.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance18.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Appearance18.BorderColor = System.Drawing.SystemColors.Window
        Me.ugDetallesError.DisplayLayout.GroupByBox.Appearance = Appearance18
        Appearance19.ForeColor = System.Drawing.SystemColors.GrayText
        Me.ugDetallesError.DisplayLayout.GroupByBox.BandLabelAppearance = Appearance19
        Me.ugDetallesError.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.ugDetallesError.DisplayLayout.GroupByBox.Hidden = True
        Appearance20.BackColor = System.Drawing.SystemColors.ControlLightLight
        Appearance20.BackColor2 = System.Drawing.SystemColors.Control
        Appearance20.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance20.ForeColor = System.Drawing.SystemColors.GrayText
        Me.ugDetallesError.DisplayLayout.GroupByBox.PromptAppearance = Appearance20
        Me.ugDetallesError.DisplayLayout.MaxColScrollRegions = 1
        Me.ugDetallesError.DisplayLayout.MaxRowScrollRegions = 1
        Appearance21.BackColor = System.Drawing.SystemColors.Window
        Appearance21.ForeColor = System.Drawing.SystemColors.ControlText
        Me.ugDetallesError.DisplayLayout.Override.ActiveCellAppearance = Appearance21
        Appearance22.BackColor = System.Drawing.SystemColors.Highlight
        Appearance22.ForeColor = System.Drawing.SystemColors.HighlightText
        Me.ugDetallesError.DisplayLayout.Override.ActiveRowAppearance = Appearance22
        Me.ugDetallesError.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted
        Me.ugDetallesError.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted
        Appearance23.BackColor = System.Drawing.SystemColors.Window
        Me.ugDetallesError.DisplayLayout.Override.CardAreaAppearance = Appearance23
        Appearance24.BorderColor = System.Drawing.Color.Silver
        Appearance24.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter
        Me.ugDetallesError.DisplayLayout.Override.CellAppearance = Appearance24
        Me.ugDetallesError.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText
        Me.ugDetallesError.DisplayLayout.Override.CellPadding = 0
        Appearance25.BackColor = System.Drawing.SystemColors.Control
        Appearance25.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance25.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element
        Appearance25.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance25.BorderColor = System.Drawing.SystemColors.Window
        Me.ugDetallesError.DisplayLayout.Override.GroupByRowAppearance = Appearance25
        Appearance26.TextHAlignAsString = "Left"
        Me.ugDetallesError.DisplayLayout.Override.HeaderAppearance = Appearance26
        Me.ugDetallesError.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
        Me.ugDetallesError.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand
        Appearance27.BackColor = System.Drawing.SystemColors.Window
        Appearance27.BorderColor = System.Drawing.Color.Silver
        Me.ugDetallesError.DisplayLayout.Override.RowAppearance = Appearance27
        Me.ugDetallesError.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[False]
        Appearance28.BackColor = System.Drawing.SystemColors.ControlLight
        Me.ugDetallesError.DisplayLayout.Override.TemplateAddRowAppearance = Appearance28
        Me.ugDetallesError.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill
        Me.ugDetallesError.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate
        Me.ugDetallesError.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy
        Me.ugDetallesError.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ugDetallesError.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ugDetallesError.Location = New System.Drawing.Point(0, 0)
        Me.ugDetallesError.Name = "ugDetallesError"
        Me.ugDetallesError.Size = New System.Drawing.Size(730, 384)
        Me.ugDetallesError.TabIndex = 0
        Me.ugDetallesError.Text = "UltraGrid1"
        '
        'btnCalcular
        '
        Me.btnCalcular.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCalcular.Image = Global.Eniac.Win.My.Resources.Resources.exchange
        Me.btnCalcular.Location = New System.Drawing.Point(8, 12)
        Me.btnCalcular.Name = "btnCalcular"
        Me.btnCalcular.Size = New System.Drawing.Size(230, 76)
        Me.btnCalcular.TabIndex = 33
        Me.btnCalcular.Text = "Calcular (F4)"
        Me.btnCalcular.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnCalcular.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnCalcular.UseVisualStyleBackColor = True
        '
        'tssInfo
        '
        Me.tssInfo.Name = "tssInfo"
        Me.tssInfo.Size = New System.Drawing.Size(969, 17)
        Me.tssInfo.Spring = True
        Me.tssInfo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'stsStado
        '
        Me.stsStado.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tssInfo, Me.tssVersionAPI})
        Me.stsStado.Location = New System.Drawing.Point(0, 439)
        Me.stsStado.Name = "stsStado"
        Me.stsStado.Size = New System.Drawing.Size(984, 22)
        Me.stsStado.TabIndex = 32
        Me.stsStado.Text = "statusStrip1"
        '
        'tssVersionAPI
        '
        Me.tssVersionAPI.Name = "tssVersionAPI"
        Me.tssVersionAPI.Size = New System.Drawing.Size(0, 17)
        '
        'bwSincronizacion
        '
        Me.bwSincronizacion.WorkerReportsProgress = True
        Me.bwSincronizacion.WorkerSupportsCancellation = True
        '
        'pnlParametros
        '
        Me.pnlParametros.AutoSize = True
        Me.pnlParametros.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.pnlParametros.Controls.Add(Me.chbSaldoLimiteCreditoContemplaPedidos)
        Me.pnlParametros.Controls.Add(Me.chbSaldoLimiteCreditoContemplaAnticipos)
        Me.pnlParametros.Enabled = False
        Me.pnlParametros.Location = New System.Drawing.Point(3, 95)
        Me.pnlParametros.Name = "pnlParametros"
        Me.pnlParametros.Size = New System.Drawing.Size(240, 46)
        Me.pnlParametros.TabIndex = 35
        '
        'chbSaldoLimiteCreditoContemplaPedidos
        '
        Me.chbSaldoLimiteCreditoContemplaPedidos.AutoSize = True
        Me.chbSaldoLimiteCreditoContemplaPedidos.BindearPropiedadControl = Nothing
        Me.chbSaldoLimiteCreditoContemplaPedidos.BindearPropiedadEntidad = Nothing
        Me.chbSaldoLimiteCreditoContemplaPedidos.Checked = True
        Me.chbSaldoLimiteCreditoContemplaPedidos.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chbSaldoLimiteCreditoContemplaPedidos.ForeColorFocus = System.Drawing.Color.Red
        Me.chbSaldoLimiteCreditoContemplaPedidos.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbSaldoLimiteCreditoContemplaPedidos.IsPK = False
        Me.chbSaldoLimiteCreditoContemplaPedidos.IsRequired = False
        Me.chbSaldoLimiteCreditoContemplaPedidos.Key = Nothing
        Me.chbSaldoLimiteCreditoContemplaPedidos.LabelAsoc = Nothing
        Me.chbSaldoLimiteCreditoContemplaPedidos.Location = New System.Drawing.Point(3, 3)
        Me.chbSaldoLimiteCreditoContemplaPedidos.Name = "chbSaldoLimiteCreditoContemplaPedidos"
        Me.chbSaldoLimiteCreditoContemplaPedidos.Size = New System.Drawing.Size(229, 17)
        Me.chbSaldoLimiteCreditoContemplaPedidos.TabIndex = 0
        Me.chbSaldoLimiteCreditoContemplaPedidos.Text = "Saldo Límite de Crédito contempla Pedidos"
        Me.chbSaldoLimiteCreditoContemplaPedidos.UseVisualStyleBackColor = True
        '
        'chbSaldoLimiteCreditoContemplaAnticipos
        '
        Me.chbSaldoLimiteCreditoContemplaAnticipos.AutoSize = True
        Me.chbSaldoLimiteCreditoContemplaAnticipos.BindearPropiedadControl = Nothing
        Me.chbSaldoLimiteCreditoContemplaAnticipos.BindearPropiedadEntidad = Nothing
        Me.chbSaldoLimiteCreditoContemplaAnticipos.Checked = True
        Me.chbSaldoLimiteCreditoContemplaAnticipos.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chbSaldoLimiteCreditoContemplaAnticipos.ForeColorFocus = System.Drawing.Color.Red
        Me.chbSaldoLimiteCreditoContemplaAnticipos.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbSaldoLimiteCreditoContemplaAnticipos.IsPK = False
        Me.chbSaldoLimiteCreditoContemplaAnticipos.IsRequired = False
        Me.chbSaldoLimiteCreditoContemplaAnticipos.Key = Nothing
        Me.chbSaldoLimiteCreditoContemplaAnticipos.LabelAsoc = Nothing
        Me.chbSaldoLimiteCreditoContemplaAnticipos.Location = New System.Drawing.Point(3, 26)
        Me.chbSaldoLimiteCreditoContemplaAnticipos.Name = "chbSaldoLimiteCreditoContemplaAnticipos"
        Me.chbSaldoLimiteCreditoContemplaAnticipos.Size = New System.Drawing.Size(234, 17)
        Me.chbSaldoLimiteCreditoContemplaAnticipos.TabIndex = 1
        Me.chbSaldoLimiteCreditoContemplaAnticipos.Text = "Saldo Límite de Crédito contempla Anticipos"
        Me.chbSaldoLimiteCreditoContemplaAnticipos.UseVisualStyleBackColor = True
        '
        'pnlAcciones
        '
        Me.pnlAcciones.AutoSize = True
        Me.pnlAcciones.Controls.Add(Me.pnlParametros)
        Me.pnlAcciones.Controls.Add(Me.btnCalcular)
        Me.pnlAcciones.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlAcciones.Location = New System.Drawing.Point(0, 29)
        Me.pnlAcciones.Name = "pnlAcciones"
        Me.pnlAcciones.Size = New System.Drawing.Size(246, 410)
        Me.pnlAcciones.TabIndex = 36
        '
        'EstadoSituacionCrediticiaCalculoMasivo
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(984, 461)
        Me.Controls.Add(Me.tbcLog)
        Me.Controls.Add(Me.pnlAcciones)
        Me.Controls.Add(Me.stsStado)
        Me.Controls.Add(Me.tstBarra)
        Me.Name = "EstadoSituacionCrediticiaCalculoMasivo"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Cálculo Masivo de Saldo de Límite de Crédito"
        Me.tstBarra.ResumeLayout(False)
        Me.tstBarra.PerformLayout()
        Me.tbcLog.ResumeLayout(False)
        Me.tbpResumen.ResumeLayout(False)
        CType(Me.ugResumen, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tbpErrores.ResumeLayout(False)
        CType(Me.ugDetallesError, System.ComponentModel.ISupportInitialize).EndInit()
        Me.stsStado.ResumeLayout(False)
        Me.stsStado.PerformLayout()
        Me.pnlParametros.ResumeLayout(False)
        Me.pnlParametros.PerformLayout()
        Me.pnlAcciones.ResumeLayout(False)
        Me.pnlAcciones.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Public WithEvents tstBarra As ToolStrip
   Public WithEvents tsbRefrescar As ToolStripButton
   Private WithEvents toolStripSeparator3 As ToolStripSeparator
   Public WithEvents tsbSalir As ToolStripButton
   Friend WithEvents tbcLog As TabControl
   Friend WithEvents tbpResumen As TabPage
   Friend WithEvents ugResumen As UltraGrid
   Friend WithEvents tbpErrores As TabPage
   Friend WithEvents ugDetallesError As UltraGrid
   Friend WithEvents btnCalcular As Button
   Protected Friend WithEvents tssInfo As ToolStripStatusLabel
   Protected Friend WithEvents stsStado As StatusStrip
   Protected WithEvents tssVersionAPI As ToolStripStatusLabel
   Friend WithEvents bwSincronizacion As System.ComponentModel.BackgroundWorker
    Friend WithEvents pnlParametros As Panel
    Friend WithEvents chbSaldoLimiteCreditoContemplaPedidos As Controles.CheckBox
    Friend WithEvents chbSaldoLimiteCreditoContemplaAnticipos As Controles.CheckBox
    Friend WithEvents pnlAcciones As Panel
End Class
