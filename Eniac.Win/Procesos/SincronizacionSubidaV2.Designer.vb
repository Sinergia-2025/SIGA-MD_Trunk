<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SincronizacionSubidaV2
    Inherits System.Windows.Forms.Form

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
      Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(SincronizacionSubidaV2))
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
      Me.tstBarra = New System.Windows.Forms.ToolStrip()
      Me.tsbSalir = New System.Windows.Forms.ToolStripButton()
      Me.stsStado = New System.Windows.Forms.StatusStrip()
      Me.tssInfo = New System.Windows.Forms.ToolStripStatusLabel()
      Me.tspBarra = New System.Windows.Forms.ToolStripProgressBar()
      Me.tssRegistros = New System.Windows.Forms.ToolStripStatusLabel()
      Me.btnSincronizar = New System.Windows.Forms.Button()
      Me.bkgSincronizar = New System.ComponentModel.BackgroundWorker()
      Me.lblURLServicio = New Eniac.Controles.Label()
      Me.txtURLServicio = New Eniac.Controles.TextBox()
      Me.chbReenviarTodos = New Eniac.Controles.CheckBox()
      Me.txtLogInformation = New System.Windows.Forms.TextBox()
      Me.tbcLog = New System.Windows.Forms.TabControl()
      Me.tbpResumen = New System.Windows.Forms.TabPage()
      Me.ugResumen = New Infragistics.Win.UltraWinGrid.UltraGrid()
      Me.tbpLogInformation = New System.Windows.Forms.TabPage()
      Me.tbpLogVerbose = New System.Windows.Forms.TabPage()
      Me.txtLogVerbose = New System.Windows.Forms.TextBox()
      Me.chbRecibirTodo = New Eniac.Controles.CheckBox()
        Me.tstBarra.SuspendLayout()
        Me.stsStado.SuspendLayout()
        Me.tbcLog.SuspendLayout()
        Me.tbpResumen.SuspendLayout()
        CType(Me.ugResumen, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tbpLogInformation.SuspendLayout()
        Me.tbpLogVerbose.SuspendLayout()
        Me.SuspendLayout()
        '
        'tstBarra
        '
        Me.tstBarra.AllowItemReorder = True
        Me.tstBarra.ImageScalingSize = New System.Drawing.Size(22, 22)
        Me.tstBarra.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsbSalir})
        Me.tstBarra.Location = New System.Drawing.Point(0, 0)
        Me.tstBarra.Name = "tstBarra"
        Me.tstBarra.Size = New System.Drawing.Size(784, 29)
        Me.tstBarra.TabIndex = 9
        Me.tstBarra.Text = "toolStrip1"
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
        'stsStado
        '
        Me.stsStado.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tssInfo, Me.tspBarra, Me.tssRegistros})
        Me.stsStado.Location = New System.Drawing.Point(0, 339)
        Me.stsStado.Name = "stsStado"
        Me.stsStado.Size = New System.Drawing.Size(784, 22)
        Me.stsStado.TabIndex = 8
        Me.stsStado.Text = "statusStrip1"
        '
        'tssInfo
        '
        Me.tssInfo.Name = "tssInfo"
        Me.tssInfo.Size = New System.Drawing.Size(705, 17)
        Me.tssInfo.Spring = True
        Me.tssInfo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
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
        'btnSincronizar
        '
        Me.btnSincronizar.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSincronizar.Image = Global.Eniac.Win.My.Resources.Resources.exchange
        Me.btnSincronizar.Location = New System.Drawing.Point(12, 71)
        Me.btnSincronizar.Name = "btnSincronizar"
        Me.btnSincronizar.Size = New System.Drawing.Size(230, 99)
        Me.btnSincronizar.TabIndex = 5
        Me.btnSincronizar.Text = "Sincronizar"
        Me.btnSincronizar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnSincronizar.UseVisualStyleBackColor = True
        '
        'bkgSincronizar
        '
        Me.bkgSincronizar.WorkerReportsProgress = True
        Me.bkgSincronizar.WorkerSupportsCancellation = True
        '
        'lblURLServicio
        '
        Me.lblURLServicio.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblURLServicio.AutoSize = True
        Me.lblURLServicio.LabelAsoc = Nothing
        Me.lblURLServicio.Location = New System.Drawing.Point(6, 319)
        Me.lblURLServicio.Name = "lblURLServicio"
        Me.lblURLServicio.Size = New System.Drawing.Size(114, 13)
        Me.lblURLServicio.TabIndex = 6
        Me.lblURLServicio.Text = "URL de sincronización"
        '
        'txtURLServicio
        '
        Me.txtURLServicio.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtURLServicio.BindearPropiedadControl = Nothing
        Me.txtURLServicio.BindearPropiedadEntidad = Nothing
        Me.txtURLServicio.ForeColorFocus = System.Drawing.Color.Red
        Me.txtURLServicio.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtURLServicio.Formato = ""
        Me.txtURLServicio.IsDecimal = False
        Me.txtURLServicio.IsNumber = False
        Me.txtURLServicio.IsPK = False
        Me.txtURLServicio.IsRequired = False
        Me.txtURLServicio.Key = ""
        Me.txtURLServicio.LabelAsoc = Me.lblURLServicio
        Me.txtURLServicio.Location = New System.Drawing.Point(126, 316)
        Me.txtURLServicio.Name = "txtURLServicio"
        Me.txtURLServicio.ReadOnly = True
        Me.txtURLServicio.Size = New System.Drawing.Size(646, 20)
        Me.txtURLServicio.TabIndex = 7
        '
        'chbReenviarTodos
        '
        Me.chbReenviarTodos.AutoSize = True
        Me.chbReenviarTodos.BindearPropiedadControl = Nothing
        Me.chbReenviarTodos.BindearPropiedadEntidad = Nothing
        Me.chbReenviarTodos.ForeColorFocus = System.Drawing.Color.Red
        Me.chbReenviarTodos.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbReenviarTodos.IsPK = False
        Me.chbReenviarTodos.IsRequired = False
        Me.chbReenviarTodos.Key = Nothing
        Me.chbReenviarTodos.LabelAsoc = Nothing
        Me.chbReenviarTodos.Location = New System.Drawing.Point(79, 48)
        Me.chbReenviarTodos.Name = "chbReenviarTodos"
        Me.chbReenviarTodos.Size = New System.Drawing.Size(98, 17)
        Me.chbReenviarTodos.TabIndex = 18
        Me.chbReenviarTodos.Text = "Reenviar todos"
        Me.chbReenviarTodos.UseVisualStyleBackColor = True
        '
        'txtLogInformation
        '
        Me.txtLogInformation.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtLogInformation.Location = New System.Drawing.Point(3, 3)
        Me.txtLogInformation.Multiline = True
        Me.txtLogInformation.Name = "txtLogInformation"
        Me.txtLogInformation.ReadOnly = True
        Me.txtLogInformation.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.txtLogInformation.Size = New System.Drawing.Size(510, 266)
        Me.txtLogInformation.TabIndex = 19
        Me.txtLogInformation.WordWrap = False
        '
        'tbcLog
        '
        Me.tbcLog.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tbcLog.Controls.Add(Me.tbpResumen)
        Me.tbcLog.Controls.Add(Me.tbpLogInformation)
        Me.tbcLog.Controls.Add(Me.tbpLogVerbose)
        Me.tbcLog.Location = New System.Drawing.Point(248, 12)
        Me.tbcLog.Name = "tbcLog"
        Me.tbcLog.SelectedIndex = 0
        Me.tbcLog.Size = New System.Drawing.Size(524, 298)
        Me.tbcLog.TabIndex = 20
        '
        'tbpResumen
        '
        Me.tbpResumen.Controls.Add(Me.ugResumen)
        Me.tbpResumen.Location = New System.Drawing.Point(4, 22)
        Me.tbpResumen.Name = "tbpResumen"
        Me.tbpResumen.Size = New System.Drawing.Size(516, 272)
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
        Me.ugResumen.Location = New System.Drawing.Point(0, 0)
        Me.ugResumen.Name = "ugResumen"
        Me.ugResumen.Size = New System.Drawing.Size(516, 272)
        Me.ugResumen.TabIndex = 0
        Me.ugResumen.Text = "UltraGrid1"
        '
        'tbpLogInformation
        '
        Me.tbpLogInformation.Controls.Add(Me.txtLogInformation)
        Me.tbpLogInformation.Location = New System.Drawing.Point(4, 22)
        Me.tbpLogInformation.Name = "tbpLogInformation"
        Me.tbpLogInformation.Padding = New System.Windows.Forms.Padding(3)
        Me.tbpLogInformation.Size = New System.Drawing.Size(516, 272)
        Me.tbpLogInformation.TabIndex = 0
        Me.tbpLogInformation.Text = "Information"
        Me.tbpLogInformation.UseVisualStyleBackColor = True
        '
        'tbpLogVerbose
        '
        Me.tbpLogVerbose.Controls.Add(Me.txtLogVerbose)
        Me.tbpLogVerbose.Location = New System.Drawing.Point(4, 22)
        Me.tbpLogVerbose.Name = "tbpLogVerbose"
        Me.tbpLogVerbose.Padding = New System.Windows.Forms.Padding(3)
        Me.tbpLogVerbose.Size = New System.Drawing.Size(516, 272)
        Me.tbpLogVerbose.TabIndex = 1
        Me.tbpLogVerbose.Text = "Verbose"
        Me.tbpLogVerbose.UseVisualStyleBackColor = True
        '
        'txtLogVerbose
        '
        Me.txtLogVerbose.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtLogVerbose.Location = New System.Drawing.Point(3, 3)
        Me.txtLogVerbose.Multiline = True
        Me.txtLogVerbose.Name = "txtLogVerbose"
        Me.txtLogVerbose.ReadOnly = True
        Me.txtLogVerbose.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.txtLogVerbose.Size = New System.Drawing.Size(510, 266)
        Me.txtLogVerbose.TabIndex = 20
        Me.txtLogVerbose.WordWrap = False
        '
        'chbRecibirTodo
        '
        Me.chbRecibirTodo.AutoSize = True
        Me.chbRecibirTodo.BindearPropiedadControl = Nothing
        Me.chbRecibirTodo.BindearPropiedadEntidad = Nothing
        Me.chbRecibirTodo.ForeColorFocus = System.Drawing.Color.Red
        Me.chbRecibirTodo.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbRecibirTodo.IsPK = False
        Me.chbRecibirTodo.IsRequired = False
        Me.chbRecibirTodo.Key = Nothing
        Me.chbRecibirTodo.LabelAsoc = Nothing
        Me.chbRecibirTodo.Location = New System.Drawing.Point(79, 176)
        Me.chbRecibirTodo.Name = "chbRecibirTodo"
        Me.chbRecibirTodo.Size = New System.Drawing.Size(83, 17)
        Me.chbRecibirTodo.TabIndex = 18
        Me.chbRecibirTodo.Text = "Recibir todo"
        Me.chbRecibirTodo.UseVisualStyleBackColor = True
        '
        'SincronizacionSubidaV2
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(784, 361)
        Me.Controls.Add(Me.tbcLog)
        Me.Controls.Add(Me.chbRecibirTodo)
        Me.Controls.Add(Me.chbReenviarTodos)
        Me.Controls.Add(Me.tstBarra)
        Me.Controls.Add(Me.stsStado)
        Me.Controls.Add(Me.btnSincronizar)
        Me.Controls.Add(Me.lblURLServicio)
        Me.Controls.Add(Me.txtURLServicio)
        Me.Name = "SincronizacionSubidaV2"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "SincronizacionSubidaV2"
        Me.tstBarra.ResumeLayout(False)
        Me.tstBarra.PerformLayout()
        Me.stsStado.ResumeLayout(False)
        Me.stsStado.PerformLayout()
        Me.tbcLog.ResumeLayout(False)
        Me.tbpResumen.ResumeLayout(False)
        CType(Me.ugResumen, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tbpLogInformation.ResumeLayout(False)
        Me.tbpLogInformation.PerformLayout()
        Me.tbpLogVerbose.ResumeLayout(False)
        Me.tbpLogVerbose.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Public WithEvents tstBarra As System.Windows.Forms.ToolStrip
   Public WithEvents tsbSalir As System.Windows.Forms.ToolStripButton
   Protected Friend WithEvents stsStado As System.Windows.Forms.StatusStrip
   Protected Friend WithEvents tssInfo As System.Windows.Forms.ToolStripStatusLabel
   Protected Friend WithEvents tspBarra As System.Windows.Forms.ToolStripProgressBar
   Protected WithEvents tssRegistros As System.Windows.Forms.ToolStripStatusLabel
   Friend WithEvents btnSincronizar As System.Windows.Forms.Button
   Friend WithEvents bkgSincronizar As System.ComponentModel.BackgroundWorker
   Friend WithEvents lblURLServicio As Eniac.Controles.Label
   Friend WithEvents txtURLServicio As Eniac.Controles.TextBox
   Friend WithEvents chbReenviarTodos As Eniac.Controles.CheckBox
   Friend WithEvents txtLogInformation As System.Windows.Forms.TextBox
   Friend WithEvents tbcLog As System.Windows.Forms.TabControl
   Friend WithEvents tbpLogInformation As System.Windows.Forms.TabPage
   Friend WithEvents tbpLogVerbose As System.Windows.Forms.TabPage
   Friend WithEvents txtLogVerbose As System.Windows.Forms.TextBox
   Friend WithEvents tbpResumen As System.Windows.Forms.TabPage
   Friend WithEvents ugResumen As Infragistics.Win.UltraWinGrid.UltraGrid
   Friend WithEvents chbRecibirTodo As Eniac.Controles.CheckBox
End Class
