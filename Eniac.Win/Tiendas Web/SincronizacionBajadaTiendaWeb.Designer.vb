<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SincronizacionBajadaTiendaWeb
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
      Dim Appearance1 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridBand1 As Infragistics.Win.UltraWinGrid.UltraGridBand = New Infragistics.Win.UltraWinGrid.UltraGridBand("Band 0", -1)
      Dim UltraGridColumn1 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Estado")
      Dim UltraGridColumn2 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Metodo")
      Dim UltraGridColumn3 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Nombre")
      Dim UltraGridColumn4 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NroRegistro")
      Dim Appearance2 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn5 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("TotalRegistros")
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
      Dim Appearance14 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Me.stsStado = New System.Windows.Forms.StatusStrip()
      Me.tssInfo = New System.Windows.Forms.ToolStripStatusLabel()
      Me.tssVersionAPI = New System.Windows.Forms.ToolStripStatusLabel()
      Me.tbcLog = New System.Windows.Forms.TabControl()
      Me.tbpResumen = New System.Windows.Forms.TabPage()
      Me.ugResumen = New Infragistics.Win.UltraWinGrid.UltraGrid()
      Me.lblInformacion = New Eniac.Controles.Label()
      Me.btnSincronizar = New System.Windows.Forms.Button()
      Me.bwSincronizacion = New System.ComponentModel.BackgroundWorker()
      Me.chbBajarTodos = New System.Windows.Forms.CheckBox()
      Me.tstBarra = New System.Windows.Forms.ToolStrip()
      Me.tsbRefrescar = New System.Windows.Forms.ToolStripButton()
      Me.toolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
      Me.tsbSalir = New System.Windows.Forms.ToolStripButton()
        Me.pnlTiendas = New System.Windows.Forms.FlowLayoutPanel()
        Me.chbSincronizaTiendaNube = New System.Windows.Forms.CheckBox()
        Me.chbSincronizaMercadoLibre = New System.Windows.Forms.CheckBox()
        Me.chbSincronizaArborea = New System.Windows.Forms.CheckBox()
        Me.stsStado.SuspendLayout()
        Me.tbcLog.SuspendLayout()
        Me.tbpResumen.SuspendLayout()
        CType(Me.ugResumen, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tstBarra.SuspendLayout()
        Me.pnlTiendas.SuspendLayout()
        Me.SuspendLayout()
        '
        'stsStado
        '
        Me.stsStado.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tssInfo, Me.tssVersionAPI})
        Me.stsStado.Location = New System.Drawing.Point(0, 233)
        Me.stsStado.Name = "stsStado"
        Me.stsStado.Size = New System.Drawing.Size(724, 22)
        Me.stsStado.TabIndex = 6
        Me.stsStado.Text = "statusStrip1"
        '
        'tssInfo
        '
        Me.tssInfo.Name = "tssInfo"
        Me.tssInfo.Size = New System.Drawing.Size(709, 17)
        Me.tssInfo.Spring = True
        Me.tssInfo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'tssVersionAPI
        '
        Me.tssVersionAPI.Name = "tssVersionAPI"
        Me.tssVersionAPI.Size = New System.Drawing.Size(0, 17)
        '
        'tbcLog
        '
        Me.tbcLog.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tbcLog.Controls.Add(Me.tbpResumen)
        Me.tbcLog.Location = New System.Drawing.Point(313, 45)
        Me.tbcLog.Name = "tbcLog"
        Me.tbcLog.SelectedIndex = 0
        Me.tbcLog.Size = New System.Drawing.Size(399, 185)
        Me.tbcLog.TabIndex = 3
        '
        'tbpResumen
        '
        Me.tbpResumen.Controls.Add(Me.ugResumen)
        Me.tbpResumen.Location = New System.Drawing.Point(4, 22)
        Me.tbpResumen.Name = "tbpResumen"
        Me.tbpResumen.Size = New System.Drawing.Size(391, 159)
        Me.tbpResumen.TabIndex = 2
        Me.tbpResumen.Text = "Resumen"
        Me.tbpResumen.UseVisualStyleBackColor = True
        '
        'ugResumen
        '
        Appearance1.BackColor = System.Drawing.SystemColors.Window
        Appearance1.BorderColor = System.Drawing.SystemColors.InactiveCaption
        Me.ugResumen.DisplayLayout.Appearance = Appearance1
        UltraGridColumn1.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        UltraGridColumn1.Header.VisiblePosition = 0
        UltraGridColumn1.Width = 83
        UltraGridColumn2.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        UltraGridColumn2.Header.VisiblePosition = 1
        UltraGridColumn2.Hidden = True
        UltraGridColumn3.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        UltraGridColumn3.Header.VisiblePosition = 2
        UltraGridColumn3.Width = 112
        UltraGridColumn4.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        Appearance2.TextHAlignAsString = "Right"
        UltraGridColumn4.CellAppearance = Appearance2
        UltraGridColumn4.Header.Caption = "#"
        UltraGridColumn4.Header.VisiblePosition = 3
        UltraGridColumn4.Width = 28
        UltraGridColumn5.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        Appearance3.TextHAlignAsString = "Right"
        UltraGridColumn5.CellAppearance = Appearance3
        UltraGridColumn5.Header.Caption = "Total"
        UltraGridColumn5.Header.VisiblePosition = 4
        UltraGridBand1.Columns.AddRange(New Object() {UltraGridColumn1, UltraGridColumn2, UltraGridColumn3, UltraGridColumn4, UltraGridColumn5})
        Me.ugResumen.DisplayLayout.BandsSerializer.Add(UltraGridBand1)
        Me.ugResumen.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.ugResumen.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.[False]
        Appearance4.BackColor = System.Drawing.SystemColors.ActiveBorder
        Appearance4.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance4.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Appearance4.BorderColor = System.Drawing.SystemColors.Window
        Me.ugResumen.DisplayLayout.GroupByBox.Appearance = Appearance4
        Appearance5.ForeColor = System.Drawing.SystemColors.GrayText
        Me.ugResumen.DisplayLayout.GroupByBox.BandLabelAppearance = Appearance5
        Me.ugResumen.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.ugResumen.DisplayLayout.GroupByBox.Hidden = True
        Appearance6.BackColor = System.Drawing.SystemColors.ControlLightLight
        Appearance6.BackColor2 = System.Drawing.SystemColors.Control
        Appearance6.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance6.ForeColor = System.Drawing.SystemColors.GrayText
        Me.ugResumen.DisplayLayout.GroupByBox.PromptAppearance = Appearance6
        Me.ugResumen.DisplayLayout.MaxColScrollRegions = 1
        Me.ugResumen.DisplayLayout.MaxRowScrollRegions = 1
        Appearance7.BackColor = System.Drawing.SystemColors.Window
        Appearance7.ForeColor = System.Drawing.SystemColors.ControlText
        Me.ugResumen.DisplayLayout.Override.ActiveCellAppearance = Appearance7
        Appearance8.BackColor = System.Drawing.SystemColors.Highlight
        Appearance8.ForeColor = System.Drawing.SystemColors.HighlightText
        Me.ugResumen.DisplayLayout.Override.ActiveRowAppearance = Appearance8
        Me.ugResumen.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted
        Me.ugResumen.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted
        Appearance9.BackColor = System.Drawing.SystemColors.Window
        Me.ugResumen.DisplayLayout.Override.CardAreaAppearance = Appearance9
        Appearance10.BorderColor = System.Drawing.Color.Silver
        Appearance10.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter
        Me.ugResumen.DisplayLayout.Override.CellAppearance = Appearance10
        Me.ugResumen.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText
        Me.ugResumen.DisplayLayout.Override.CellPadding = 0
        Appearance11.BackColor = System.Drawing.SystemColors.Control
        Appearance11.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance11.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element
        Appearance11.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance11.BorderColor = System.Drawing.SystemColors.Window
        Me.ugResumen.DisplayLayout.Override.GroupByRowAppearance = Appearance11
        Appearance12.TextHAlignAsString = "Left"
        Me.ugResumen.DisplayLayout.Override.HeaderAppearance = Appearance12
        Me.ugResumen.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
        Me.ugResumen.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand
        Appearance13.BackColor = System.Drawing.SystemColors.Window
        Appearance13.BorderColor = System.Drawing.Color.Silver
        Me.ugResumen.DisplayLayout.Override.RowAppearance = Appearance13
        Me.ugResumen.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[False]
        Appearance14.BackColor = System.Drawing.SystemColors.ControlLight
        Me.ugResumen.DisplayLayout.Override.TemplateAddRowAppearance = Appearance14
        Me.ugResumen.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill
        Me.ugResumen.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate
        Me.ugResumen.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy
        Me.ugResumen.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ugResumen.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ugResumen.Location = New System.Drawing.Point(0, 0)
        Me.ugResumen.Name = "ugResumen"
        Me.ugResumen.Size = New System.Drawing.Size(391, 159)
        Me.ugResumen.TabIndex = 0
        Me.ugResumen.Text = "UltraGrid1"
        '
        'lblInformacion
        '
        Me.lblInformacion.AutoSize = True
        Me.lblInformacion.LabelAsoc = Nothing
        Me.lblInformacion.Location = New System.Drawing.Point(314, 29)
        Me.lblInformacion.Name = "lblInformacion"
        Me.lblInformacion.Size = New System.Drawing.Size(0, 13)
        Me.lblInformacion.TabIndex = 4
        '
        'btnSincronizar
        '
        Me.btnSincronizar.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSincronizar.Image = Global.Eniac.Win.My.Resources.Resources.exchange
        Me.btnSincronizar.Location = New System.Drawing.Point(42, 73)
        Me.btnSincronizar.Name = "btnSincronizar"
        Me.btnSincronizar.Size = New System.Drawing.Size(230, 99)
        Me.btnSincronizar.TabIndex = 1
        Me.btnSincronizar.Text = "Sincronizar"
        Me.btnSincronizar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnSincronizar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnSincronizar.UseVisualStyleBackColor = True
        '
        'bwSincronizacion
        '
        Me.bwSincronizacion.WorkerReportsProgress = True
        Me.bwSincronizacion.WorkerSupportsCancellation = True
        '
        'chbBajarTodos
        '
        Me.chbBajarTodos.AutoSize = True
        Me.chbBajarTodos.Location = New System.Drawing.Point(113, 50)
        Me.chbBajarTodos.Name = "chbBajarTodos"
        Me.chbBajarTodos.Size = New System.Drawing.Size(83, 17)
        Me.chbBajarTodos.TabIndex = 0
        Me.chbBajarTodos.Text = "Bajar Todos"
        Me.chbBajarTodos.UseVisualStyleBackColor = True
        '
        'tstBarra
        '
        Me.tstBarra.AllowItemReorder = True
        Me.tstBarra.ImageScalingSize = New System.Drawing.Size(22, 22)
        Me.tstBarra.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsbRefrescar, Me.toolStripSeparator3, Me.tsbSalir})
        Me.tstBarra.Location = New System.Drawing.Point(0, 0)
        Me.tstBarra.Name = "tstBarra"
        Me.tstBarra.Size = New System.Drawing.Size(724, 29)
        Me.tstBarra.TabIndex = 5
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
        'pnlTiendas
        '
        Me.pnlTiendas.AutoSize = True
        Me.pnlTiendas.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.pnlTiendas.Controls.Add(Me.chbSincronizaTiendaNube)
        Me.pnlTiendas.Controls.Add(Me.chbSincronizaMercadoLibre)
        Me.pnlTiendas.Controls.Add(Me.chbSincronizaArborea)
        Me.pnlTiendas.Location = New System.Drawing.Point(28, 178)
        Me.pnlTiendas.Name = "pnlTiendas"
        Me.pnlTiendas.Size = New System.Drawing.Size(263, 23)
        Me.pnlTiendas.TabIndex = 2
        '
        'chbSincronizaTiendaNube
        '
        Me.chbSincronizaTiendaNube.AutoSize = True
        Me.chbSincronizaTiendaNube.Checked = True
        Me.chbSincronizaTiendaNube.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chbSincronizaTiendaNube.Location = New System.Drawing.Point(3, 3)
        Me.chbSincronizaTiendaNube.Name = "chbSincronizaTiendaNube"
        Me.chbSincronizaTiendaNube.Size = New System.Drawing.Size(88, 17)
        Me.chbSincronizaTiendaNube.TabIndex = 0
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
        Me.chbSincronizaMercadoLibre.TabIndex = 1
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
        Me.chbSincronizaArborea.TabIndex = 2
        Me.chbSincronizaArborea.Text = "Arborea"
        Me.chbSincronizaArborea.UseVisualStyleBackColor = True
        '
        'SincronizacionBajadaTiendaWeb
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(724, 255)
        Me.Controls.Add(Me.pnlTiendas)
        Me.Controls.Add(Me.tstBarra)
        Me.Controls.Add(Me.stsStado)
        Me.Controls.Add(Me.tbcLog)
        Me.Controls.Add(Me.lblInformacion)
        Me.Controls.Add(Me.btnSincronizar)
        Me.Controls.Add(Me.chbBajarTodos)
        Me.Name = "SincronizacionBajadaTiendaWeb"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Sincronización Bajada - Tienda Web"
        Me.stsStado.ResumeLayout(False)
        Me.stsStado.PerformLayout()
        Me.tbcLog.ResumeLayout(False)
        Me.tbpResumen.ResumeLayout(False)
        CType(Me.ugResumen, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tstBarra.ResumeLayout(False)
        Me.tstBarra.PerformLayout()
        Me.pnlTiendas.ResumeLayout(False)
        Me.pnlTiendas.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Protected Friend WithEvents stsStado As System.Windows.Forms.StatusStrip
   Protected Friend WithEvents tssInfo As System.Windows.Forms.ToolStripStatusLabel
   Protected WithEvents tssVersionAPI As System.Windows.Forms.ToolStripStatusLabel
   Friend WithEvents tbcLog As System.Windows.Forms.TabControl
   Friend WithEvents tbpResumen As System.Windows.Forms.TabPage
   Friend WithEvents ugResumen As Infragistics.Win.UltraWinGrid.UltraGrid
   Friend WithEvents lblInformacion As Eniac.Controles.Label
   Friend WithEvents btnSincronizar As System.Windows.Forms.Button
   Friend WithEvents bwSincronizacion As System.ComponentModel.BackgroundWorker
   Friend WithEvents chbBajarTodos As System.Windows.Forms.CheckBox
   Public WithEvents tstBarra As System.Windows.Forms.ToolStrip
   Public WithEvents tsbRefrescar As System.Windows.Forms.ToolStripButton
   Private WithEvents toolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
   Public WithEvents tsbSalir As System.Windows.Forms.ToolStripButton
    Friend WithEvents pnlTiendas As FlowLayoutPanel
    Friend WithEvents chbSincronizaTiendaNube As CheckBox
    Friend WithEvents chbSincronizaMercadoLibre As CheckBox
    Friend WithEvents chbSincronizaArborea As CheckBox
End Class
