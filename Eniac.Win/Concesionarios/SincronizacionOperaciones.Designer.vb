<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class SincronizacionOperaciones
    Inherits System.Windows.Forms.Form

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
        Me.tstBarra = New System.Windows.Forms.ToolStrip()
        Me.tsbRefrescar = New System.Windows.Forms.ToolStripButton()
        Me.toolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsbSalir = New System.Windows.Forms.ToolStripButton()
        Me.tbcLog = New System.Windows.Forms.TabControl()
        Me.tbpResumen = New System.Windows.Forms.TabPage()
        Me.ugResumen = New Infragistics.Win.UltraWinGrid.UltraGrid()
        Me.tbpErrores = New System.Windows.Forms.TabPage()
        Me.ugDetallesError = New Infragistics.Win.UltraWinGrid.UltraGrid()
        Me.btnSincronizar = New System.Windows.Forms.Button()
        Me.tssInfo = New System.Windows.Forms.ToolStripStatusLabel()
        Me.stsStado = New System.Windows.Forms.StatusStrip()
        Me.tssVersionAPI = New System.Windows.Forms.ToolStripStatusLabel()
        Me.bwSincronizacion = New System.ComponentModel.BackgroundWorker()
        Me.tstBarra.SuspendLayout()
        Me.tbcLog.SuspendLayout()
        Me.tbpResumen.SuspendLayout()
        CType(Me.ugResumen, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tbpErrores.SuspendLayout()
        CType(Me.ugDetallesError, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.stsStado.SuspendLayout()
        Me.SuspendLayout()
        '
        'tstBarra
        '
        Me.tstBarra.AllowItemReorder = True
        Me.tstBarra.ImageScalingSize = New System.Drawing.Size(22, 22)
        Me.tstBarra.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsbRefrescar, Me.toolStripSeparator3, Me.tsbSalir})
        Me.tstBarra.Location = New System.Drawing.Point(0, 0)
        Me.tstBarra.Name = "tstBarra"
        Me.tstBarra.Size = New System.Drawing.Size(904, 29)
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
        Me.tbcLog.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tbcLog.Controls.Add(Me.tbpResumen)
        Me.tbcLog.Controls.Add(Me.tbpErrores)
        Me.tbcLog.Location = New System.Drawing.Point(244, 34)
        Me.tbcLog.Name = "tbcLog"
        Me.tbcLog.SelectedIndex = 0
        Me.tbcLog.Size = New System.Drawing.Size(660, 402)
        Me.tbcLog.TabIndex = 34
        '
        'tbpResumen
        '
        Me.tbpResumen.Controls.Add(Me.ugResumen)
        Me.tbpResumen.Location = New System.Drawing.Point(4, 22)
        Me.tbpResumen.Name = "tbpResumen"
        Me.tbpResumen.Size = New System.Drawing.Size(652, 376)
        Me.tbpResumen.TabIndex = 2
        Me.tbpResumen.Text = "Resumen"
        Me.tbpResumen.UseVisualStyleBackColor = True
        '
        'ugResumen
        '
        Appearance1.BackColor = System.Drawing.SystemColors.Window
        Appearance1.BorderColor = System.Drawing.SystemColors.InactiveCaption
        Me.ugResumen.DisplayLayout.Appearance = Appearance1
        Me.ugResumen.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.ugResumen.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.[False]
        Appearance2.BackColor = System.Drawing.SystemColors.ActiveBorder
        Appearance2.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance2.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Appearance2.BorderColor = System.Drawing.SystemColors.Window
        Me.ugResumen.DisplayLayout.GroupByBox.Appearance = Appearance2
        Appearance3.ForeColor = System.Drawing.SystemColors.GrayText
        Me.ugResumen.DisplayLayout.GroupByBox.BandLabelAppearance = Appearance3
        Me.ugResumen.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.ugResumen.DisplayLayout.GroupByBox.Hidden = True
        Appearance4.BackColor = System.Drawing.SystemColors.ControlLightLight
        Appearance4.BackColor2 = System.Drawing.SystemColors.Control
        Appearance4.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance4.ForeColor = System.Drawing.SystemColors.GrayText
        Me.ugResumen.DisplayLayout.GroupByBox.PromptAppearance = Appearance4
        Me.ugResumen.DisplayLayout.MaxColScrollRegions = 1
        Me.ugResumen.DisplayLayout.MaxRowScrollRegions = 1
        Appearance5.BackColor = System.Drawing.SystemColors.Window
        Appearance5.ForeColor = System.Drawing.SystemColors.ControlText
        Me.ugResumen.DisplayLayout.Override.ActiveCellAppearance = Appearance5
        Appearance6.BackColor = System.Drawing.SystemColors.Highlight
        Appearance6.ForeColor = System.Drawing.SystemColors.HighlightText
        Me.ugResumen.DisplayLayout.Override.ActiveRowAppearance = Appearance6
        Me.ugResumen.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted
        Me.ugResumen.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted
        Appearance7.BackColor = System.Drawing.SystemColors.Window
        Me.ugResumen.DisplayLayout.Override.CardAreaAppearance = Appearance7
        Appearance8.BorderColor = System.Drawing.Color.Silver
        Appearance8.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter
        Me.ugResumen.DisplayLayout.Override.CellAppearance = Appearance8
        Me.ugResumen.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText
        Me.ugResumen.DisplayLayout.Override.CellPadding = 0
        Appearance9.BackColor = System.Drawing.SystemColors.Control
        Appearance9.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance9.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element
        Appearance9.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance9.BorderColor = System.Drawing.SystemColors.Window
        Me.ugResumen.DisplayLayout.Override.GroupByRowAppearance = Appearance9
        Appearance10.TextHAlignAsString = "Left"
        Me.ugResumen.DisplayLayout.Override.HeaderAppearance = Appearance10
        Me.ugResumen.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
        Me.ugResumen.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand
        Appearance11.BackColor = System.Drawing.SystemColors.Window
        Appearance11.BorderColor = System.Drawing.Color.Silver
        Me.ugResumen.DisplayLayout.Override.RowAppearance = Appearance11
        Me.ugResumen.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[False]
        Appearance12.BackColor = System.Drawing.SystemColors.ControlLight
        Me.ugResumen.DisplayLayout.Override.TemplateAddRowAppearance = Appearance12
        Me.ugResumen.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill
        Me.ugResumen.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate
        Me.ugResumen.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy
        Me.ugResumen.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ugResumen.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ugResumen.Location = New System.Drawing.Point(0, 0)
        Me.ugResumen.Name = "ugResumen"
        Me.ugResumen.Size = New System.Drawing.Size(652, 376)
        Me.ugResumen.TabIndex = 0
        Me.ugResumen.Text = "UltraGrid1"
        '
        'tbpErrores
        '
        Me.tbpErrores.BackColor = System.Drawing.SystemColors.Control
        Me.tbpErrores.Controls.Add(Me.ugDetallesError)
        Me.tbpErrores.Location = New System.Drawing.Point(4, 22)
        Me.tbpErrores.Name = "tbpErrores"
        Me.tbpErrores.Size = New System.Drawing.Size(652, 376)
        Me.tbpErrores.TabIndex = 3
        Me.tbpErrores.Text = "Errores"
        '
        'ugDetallesError
        '
        Appearance13.BackColor = System.Drawing.SystemColors.Window
        Appearance13.BorderColor = System.Drawing.SystemColors.InactiveCaption
        Me.ugDetallesError.DisplayLayout.Appearance = Appearance13
        Me.ugDetallesError.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.ugDetallesError.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.[False]
        Appearance14.BackColor = System.Drawing.SystemColors.ActiveBorder
        Appearance14.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance14.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Appearance14.BorderColor = System.Drawing.SystemColors.Window
        Me.ugDetallesError.DisplayLayout.GroupByBox.Appearance = Appearance14
        Appearance15.ForeColor = System.Drawing.SystemColors.GrayText
        Me.ugDetallesError.DisplayLayout.GroupByBox.BandLabelAppearance = Appearance15
        Me.ugDetallesError.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Appearance16.BackColor = System.Drawing.SystemColors.ControlLightLight
        Appearance16.BackColor2 = System.Drawing.SystemColors.Control
        Appearance16.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance16.ForeColor = System.Drawing.SystemColors.GrayText
        Me.ugDetallesError.DisplayLayout.GroupByBox.PromptAppearance = Appearance16
        Me.ugDetallesError.DisplayLayout.MaxColScrollRegions = 1
        Me.ugDetallesError.DisplayLayout.MaxRowScrollRegions = 1
        Appearance17.BackColor = System.Drawing.SystemColors.Window
        Appearance17.ForeColor = System.Drawing.SystemColors.ControlText
        Me.ugDetallesError.DisplayLayout.Override.ActiveCellAppearance = Appearance17
        Appearance18.BackColor = System.Drawing.SystemColors.Highlight
        Appearance18.ForeColor = System.Drawing.SystemColors.HighlightText
        Me.ugDetallesError.DisplayLayout.Override.ActiveRowAppearance = Appearance18
        Me.ugDetallesError.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted
        Me.ugDetallesError.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted
        Appearance19.BackColor = System.Drawing.SystemColors.Window
        Me.ugDetallesError.DisplayLayout.Override.CardAreaAppearance = Appearance19
        Appearance20.BorderColor = System.Drawing.Color.Silver
        Appearance20.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter
        Me.ugDetallesError.DisplayLayout.Override.CellAppearance = Appearance20
        Me.ugDetallesError.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText
        Me.ugDetallesError.DisplayLayout.Override.CellPadding = 0
        Appearance21.BackColor = System.Drawing.SystemColors.Control
        Appearance21.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance21.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element
        Appearance21.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance21.BorderColor = System.Drawing.SystemColors.Window
        Me.ugDetallesError.DisplayLayout.Override.GroupByRowAppearance = Appearance21
        Appearance22.TextHAlignAsString = "Left"
        Me.ugDetallesError.DisplayLayout.Override.HeaderAppearance = Appearance22
        Me.ugDetallesError.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
        Me.ugDetallesError.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand
        Appearance23.BackColor = System.Drawing.SystemColors.Window
        Appearance23.BorderColor = System.Drawing.Color.Silver
        Me.ugDetallesError.DisplayLayout.Override.RowAppearance = Appearance23
        Me.ugDetallesError.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[False]
        Appearance24.BackColor = System.Drawing.SystemColors.ControlLight
        Me.ugDetallesError.DisplayLayout.Override.TemplateAddRowAppearance = Appearance24
        Me.ugDetallesError.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill
        Me.ugDetallesError.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate
        Me.ugDetallesError.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy
        Me.ugDetallesError.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ugDetallesError.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ugDetallesError.Location = New System.Drawing.Point(0, 0)
        Me.ugDetallesError.Name = "ugDetallesError"
        Me.ugDetallesError.Size = New System.Drawing.Size(652, 376)
        Me.ugDetallesError.TabIndex = 0
        Me.ugDetallesError.Text = "UltraGrid1"
        '
        'btnSincronizar
        '
        Me.btnSincronizar.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSincronizar.Image = Global.Eniac.Win.My.Resources.Resources.exchange
        Me.btnSincronizar.Location = New System.Drawing.Point(8, 34)
        Me.btnSincronizar.Name = "btnSincronizar"
        Me.btnSincronizar.Size = New System.Drawing.Size(230, 76)
        Me.btnSincronizar.TabIndex = 33
        Me.btnSincronizar.Text = "Sincronizar"
        Me.btnSincronizar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnSincronizar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnSincronizar.UseVisualStyleBackColor = True
        '
        'tssInfo
        '
        Me.tssInfo.Name = "tssInfo"
        Me.tssInfo.Size = New System.Drawing.Size(889, 17)
        Me.tssInfo.Spring = True
        Me.tssInfo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'stsStado
        '
        Me.stsStado.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tssInfo, Me.tssVersionAPI})
        Me.stsStado.Location = New System.Drawing.Point(0, 439)
        Me.stsStado.Name = "stsStado"
        Me.stsStado.Size = New System.Drawing.Size(904, 22)
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
        'SincronizacionOperaciones
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(904, 461)
        Me.Controls.Add(Me.tbcLog)
        Me.Controls.Add(Me.btnSincronizar)
        Me.Controls.Add(Me.stsStado)
        Me.Controls.Add(Me.tstBarra)
        Me.Name = "SincronizacionOperaciones"
        Me.Text = "Sincronizacion Movil"
        Me.tstBarra.ResumeLayout(False)
        Me.tstBarra.PerformLayout()
        Me.tbcLog.ResumeLayout(False)
        Me.tbpResumen.ResumeLayout(False)
        CType(Me.ugResumen, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tbpErrores.ResumeLayout(False)
        CType(Me.ugDetallesError, System.ComponentModel.ISupportInitialize).EndInit()
        Me.stsStado.ResumeLayout(False)
        Me.stsStado.PerformLayout()
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
    Friend WithEvents btnSincronizar As Button
    Protected Friend WithEvents tssInfo As ToolStripStatusLabel
    Protected Friend WithEvents stsStado As StatusStrip
    Protected WithEvents tssVersionAPI As ToolStripStatusLabel
    Friend WithEvents bwSincronizacion As System.ComponentModel.BackgroundWorker
End Class
