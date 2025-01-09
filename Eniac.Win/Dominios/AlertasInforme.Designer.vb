<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class AlertasInforme
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
      Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(AlertasInforme))
      Me.grbPendientes = New System.Windows.Forms.GroupBox()
      Me.btnBuscar2 = New Eniac.Controles.Button()
      Me.lblPrioridad = New Eniac.Controles.Label()
      Me.cboPrioridad = New Eniac.Controles.ComboBox()
      Me.cmbTipoDeNotificacion = New Eniac.Controles.ComboBox()
      Me.chbTipoDeNotificacion = New Eniac.Controles.CheckBox()
      Me.dtpHasta = New Eniac.Controles.DateTimePicker()
      Me.lblHasta = New Eniac.Controles.Label()
      Me.dtpDesde = New Eniac.Controles.DateTimePicker()
      Me.lblDesde = New Eniac.Controles.Label()
      Me.stsPie = New System.Windows.Forms.StatusStrip()
      Me.tssPie = New System.Windows.Forms.ToolStripStatusLabel()
      Me.tstBarra = New System.Windows.Forms.ToolStrip()
      Me.tsbRefrescar = New System.Windows.Forms.ToolStripButton()
      Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
      Me.tsbSalir = New System.Windows.Forms.ToolStripButton()
      Me.ugDetalle = New Infragistics.Win.UltraWinGrid.UltraGrid()
      Me.tssRegistros = New System.Windows.Forms.ToolStripStatusLabel()
      Me.grbPendientes.SuspendLayout()
      Me.stsPie.SuspendLayout()
      Me.tstBarra.SuspendLayout()
      CType(Me.ugDetalle, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.SuspendLayout()
      '
      'grbPendientes
      '
      Me.grbPendientes.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.grbPendientes.Controls.Add(Me.btnBuscar2)
      Me.grbPendientes.Controls.Add(Me.lblPrioridad)
      Me.grbPendientes.Controls.Add(Me.cboPrioridad)
      Me.grbPendientes.Controls.Add(Me.cmbTipoDeNotificacion)
      Me.grbPendientes.Controls.Add(Me.chbTipoDeNotificacion)
      Me.grbPendientes.Controls.Add(Me.dtpHasta)
      Me.grbPendientes.Controls.Add(Me.dtpDesde)
      Me.grbPendientes.Controls.Add(Me.lblHasta)
      Me.grbPendientes.Controls.Add(Me.lblDesde)
      Me.grbPendientes.Location = New System.Drawing.Point(12, 32)
      Me.grbPendientes.Name = "grbPendientes"
      Me.grbPendientes.Size = New System.Drawing.Size(1109, 66)
      Me.grbPendientes.TabIndex = 0
      Me.grbPendientes.TabStop = False
      '
      'btnBuscar2
      '
      Me.btnBuscar2.Image = Global.Eniac.Win.My.Resources.Resources.view
      Me.btnBuscar2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
      Me.btnBuscar2.Location = New System.Drawing.Point(870, 15)
      Me.btnBuscar2.Name = "btnBuscar2"
      Me.btnBuscar2.Size = New System.Drawing.Size(100, 45)
      Me.btnBuscar2.TabIndex = 33
      Me.btnBuscar2.Text = "&Buscar"
      Me.btnBuscar2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      Me.btnBuscar2.UseVisualStyleBackColor = True
      '
      'lblPrioridad
      '
      Me.lblPrioridad.AutoSize = True
      Me.lblPrioridad.LabelAsoc = Nothing
      Me.lblPrioridad.Location = New System.Drawing.Point(347, 31)
      Me.lblPrioridad.Name = "lblPrioridad"
      Me.lblPrioridad.Size = New System.Drawing.Size(48, 13)
      Me.lblPrioridad.TabIndex = 8
      Me.lblPrioridad.Text = "Prioridad"
      '
      'cboPrioridad
      '
      Me.cboPrioridad.BindearPropiedadControl = Nothing
      Me.cboPrioridad.BindearPropiedadEntidad = Nothing
      Me.cboPrioridad.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cboPrioridad.ForeColorFocus = System.Drawing.Color.Red
      Me.cboPrioridad.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.cboPrioridad.FormattingEnabled = True
      Me.cboPrioridad.IsPK = False
      Me.cboPrioridad.IsRequired = False
      Me.cboPrioridad.Key = Nothing
      Me.cboPrioridad.LabelAsoc = Me.lblPrioridad
      Me.cboPrioridad.Location = New System.Drawing.Point(401, 28)
      Me.cboPrioridad.Name = "cboPrioridad"
      Me.cboPrioridad.Size = New System.Drawing.Size(89, 21)
      Me.cboPrioridad.TabIndex = 9
      '
      'cmbTipoDeNotificacion
      '
      Me.cmbTipoDeNotificacion.BindearPropiedadControl = Nothing
      Me.cmbTipoDeNotificacion.BindearPropiedadEntidad = Nothing
      Me.cmbTipoDeNotificacion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cmbTipoDeNotificacion.Enabled = False
      Me.cmbTipoDeNotificacion.ForeColorFocus = System.Drawing.Color.Red
      Me.cmbTipoDeNotificacion.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.cmbTipoDeNotificacion.FormattingEnabled = True
      Me.cmbTipoDeNotificacion.IsPK = False
      Me.cmbTipoDeNotificacion.IsRequired = False
      Me.cmbTipoDeNotificacion.Key = Nothing
      Me.cmbTipoDeNotificacion.LabelAsoc = Nothing
      Me.cmbTipoDeNotificacion.Location = New System.Drawing.Point(149, 28)
      Me.cmbTipoDeNotificacion.Name = "cmbTipoDeNotificacion"
      Me.cmbTipoDeNotificacion.Size = New System.Drawing.Size(174, 21)
      Me.cmbTipoDeNotificacion.TabIndex = 5
      '
      'chbTipoDeNotificacion
      '
      Me.chbTipoDeNotificacion.AutoSize = True
      Me.chbTipoDeNotificacion.BindearPropiedadControl = Nothing
      Me.chbTipoDeNotificacion.BindearPropiedadEntidad = Nothing
      Me.chbTipoDeNotificacion.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.chbTipoDeNotificacion.ForeColorFocus = System.Drawing.Color.Red
      Me.chbTipoDeNotificacion.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
      Me.chbTipoDeNotificacion.IsPK = False
      Me.chbTipoDeNotificacion.IsRequired = False
      Me.chbTipoDeNotificacion.Key = Nothing
      Me.chbTipoDeNotificacion.LabelAsoc = Nothing
      Me.chbTipoDeNotificacion.Location = New System.Drawing.Point(6, 31)
      Me.chbTipoDeNotificacion.Name = "chbTipoDeNotificacion"
      Me.chbTipoDeNotificacion.Size = New System.Drawing.Size(137, 17)
      Me.chbTipoDeNotificacion.TabIndex = 4
      Me.chbTipoDeNotificacion.Text = "Por Tipo De Notificacion"
      Me.chbTipoDeNotificacion.UseVisualStyleBackColor = True
      '
      'dtpHasta
      '
      Me.dtpHasta.BindearPropiedadControl = Nothing
      Me.dtpHasta.BindearPropiedadEntidad = Nothing
      Me.dtpHasta.Checked = False
      Me.dtpHasta.CustomFormat = "dd/MM/yyyy"
      Me.dtpHasta.ForeColorFocus = System.Drawing.Color.Red
      Me.dtpHasta.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.dtpHasta.Format = System.Windows.Forms.DateTimePickerFormat.Custom
      Me.dtpHasta.IsPK = False
      Me.dtpHasta.IsRequired = False
      Me.dtpHasta.Key = ""
      Me.dtpHasta.LabelAsoc = Me.lblHasta
      Me.dtpHasta.Location = New System.Drawing.Point(713, 31)
      Me.dtpHasta.Name = "dtpHasta"
      Me.dtpHasta.ShowCheckBox = True
      Me.dtpHasta.Size = New System.Drawing.Size(115, 20)
      Me.dtpHasta.TabIndex = 13
      '
      'lblHasta
      '
      Me.lblHasta.AutoSize = True
      Me.lblHasta.LabelAsoc = Nothing
      Me.lblHasta.Location = New System.Drawing.Point(672, 35)
      Me.lblHasta.Name = "lblHasta"
      Me.lblHasta.Size = New System.Drawing.Size(35, 13)
      Me.lblHasta.TabIndex = 12
      Me.lblHasta.Text = "Hasta"
      '
      'dtpDesde
      '
      Me.dtpDesde.BindearPropiedadControl = Nothing
      Me.dtpDesde.BindearPropiedadEntidad = Nothing
      Me.dtpDesde.Checked = False
      Me.dtpDesde.CustomFormat = "dd/MM/yyyy"
      Me.dtpDesde.ForeColorFocus = System.Drawing.Color.Red
      Me.dtpDesde.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.dtpDesde.Format = System.Windows.Forms.DateTimePickerFormat.Custom
      Me.dtpDesde.IsPK = False
      Me.dtpDesde.IsRequired = False
      Me.dtpDesde.Key = ""
      Me.dtpDesde.LabelAsoc = Me.lblDesde
      Me.dtpDesde.Location = New System.Drawing.Point(545, 31)
      Me.dtpDesde.Name = "dtpDesde"
      Me.dtpDesde.ShowCheckBox = True
      Me.dtpDesde.Size = New System.Drawing.Size(115, 20)
      Me.dtpDesde.TabIndex = 11
      '
      'lblDesde
      '
      Me.lblDesde.AutoSize = True
      Me.lblDesde.LabelAsoc = Nothing
      Me.lblDesde.Location = New System.Drawing.Point(504, 35)
      Me.lblDesde.Name = "lblDesde"
      Me.lblDesde.Size = New System.Drawing.Size(38, 13)
      Me.lblDesde.TabIndex = 10
      Me.lblDesde.Text = "Desde"
      '
      'stsPie
      '
      Me.stsPie.ImageScalingSize = New System.Drawing.Size(20, 20)
      Me.stsPie.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tssPie, Me.tssRegistros})
      Me.stsPie.Location = New System.Drawing.Point(0, 464)
      Me.stsPie.Name = "stsPie"
      Me.stsPie.Size = New System.Drawing.Size(1131, 22)
      Me.stsPie.TabIndex = 2
      Me.stsPie.Text = "StatusStrip1"
      '
      'tssPie
      '
      Me.tssPie.Name = "tssPie"
      Me.tssPie.Size = New System.Drawing.Size(1021, 17)
      Me.tssPie.Spring = True
      Me.tssPie.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'tstBarra
      '
      Me.tstBarra.AllowItemReorder = True
      Me.tstBarra.ImageScalingSize = New System.Drawing.Size(22, 22)
      Me.tstBarra.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsbRefrescar, Me.ToolStripSeparator1, Me.tsbSalir})
      Me.tstBarra.Location = New System.Drawing.Point(0, 0)
      Me.tstBarra.Name = "tstBarra"
      Me.tstBarra.Size = New System.Drawing.Size(1131, 29)
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
      'tsbSalir
      '
      Me.tsbSalir.Image = Global.Eniac.Win.My.Resources.Resources.close_b_32
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
      Me.ugDetalle.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
      Me.ugDetalle.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.[False]
      Appearance2.BackColor = System.Drawing.SystemColors.ActiveBorder
      Appearance2.BackColor2 = System.Drawing.SystemColors.ControlDark
      Appearance2.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
      Appearance2.BorderColor = System.Drawing.SystemColors.Window
      Me.ugDetalle.DisplayLayout.GroupByBox.Appearance = Appearance2
      Appearance3.ForeColor = System.Drawing.SystemColors.GrayText
      Me.ugDetalle.DisplayLayout.GroupByBox.BandLabelAppearance = Appearance3
      Me.ugDetalle.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
      Me.ugDetalle.DisplayLayout.GroupByBox.Prompt = "Arrastre un título de columna aquí para agrupar."
      Appearance4.BackColor = System.Drawing.SystemColors.ControlLightLight
      Appearance4.BackColor2 = System.Drawing.SystemColors.Control
      Appearance4.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
      Appearance4.ForeColor = System.Drawing.SystemColors.GrayText
      Me.ugDetalle.DisplayLayout.GroupByBox.PromptAppearance = Appearance4
      Me.ugDetalle.DisplayLayout.MaxColScrollRegions = 1
      Me.ugDetalle.DisplayLayout.MaxRowScrollRegions = 1
      Appearance5.BackColor = System.Drawing.SystemColors.Window
      Appearance5.ForeColor = System.Drawing.SystemColors.ControlText
      Me.ugDetalle.DisplayLayout.Override.ActiveCellAppearance = Appearance5
      Appearance6.BackColor = System.Drawing.SystemColors.Highlight
      Appearance6.ForeColor = System.Drawing.SystemColors.HighlightText
      Me.ugDetalle.DisplayLayout.Override.ActiveRowAppearance = Appearance6
      Me.ugDetalle.DisplayLayout.Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.No
      Me.ugDetalle.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.[False]
      Me.ugDetalle.DisplayLayout.Override.AllowUpdate = Infragistics.Win.DefaultableBoolean.[False]
      Me.ugDetalle.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted
      Me.ugDetalle.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted
      Appearance7.BackColor = System.Drawing.SystemColors.Window
      Me.ugDetalle.DisplayLayout.Override.CardAreaAppearance = Appearance7
      Appearance8.BorderColor = System.Drawing.Color.Silver
      Appearance8.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter
      Me.ugDetalle.DisplayLayout.Override.CellAppearance = Appearance8
      Me.ugDetalle.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText
      Me.ugDetalle.DisplayLayout.Override.CellPadding = 0
      Appearance9.BackColor = System.Drawing.SystemColors.Control
      Appearance9.BackColor2 = System.Drawing.SystemColors.ControlDark
      Appearance9.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element
      Appearance9.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
      Appearance9.BorderColor = System.Drawing.SystemColors.Window
      Me.ugDetalle.DisplayLayout.Override.GroupByRowAppearance = Appearance9
      Appearance10.TextHAlignAsString = "Left"
      Me.ugDetalle.DisplayLayout.Override.HeaderAppearance = Appearance10
      Me.ugDetalle.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
      Me.ugDetalle.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand
      Appearance11.BackColor = System.Drawing.SystemColors.Window
      Appearance11.BorderColor = System.Drawing.Color.Silver
      Me.ugDetalle.DisplayLayout.Override.RowAppearance = Appearance11
      Me.ugDetalle.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[False]
      Me.ugDetalle.DisplayLayout.Override.SummaryDisplayArea = Infragistics.Win.UltraWinGrid.SummaryDisplayAreas.BottomFixed
      Appearance12.BackColor = System.Drawing.SystemColors.ControlLight
      Me.ugDetalle.DisplayLayout.Override.TemplateAddRowAppearance = Appearance12
      Me.ugDetalle.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill
      Me.ugDetalle.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate
      Me.ugDetalle.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy
      Me.ugDetalle.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.ugDetalle.Location = New System.Drawing.Point(12, 104)
      Me.ugDetalle.Name = "ugDetalle"
      Me.ugDetalle.Size = New System.Drawing.Size(1109, 357)
      Me.ugDetalle.TabIndex = 4
      '
      'tssRegistros
      '
      Me.tssRegistros.Name = "tssRegistros"
      Me.tssRegistros.Size = New System.Drawing.Size(64, 17)
      Me.tssRegistros.Text = "0 Registros"
      '
      'AlertasInforme
      '
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.ClientSize = New System.Drawing.Size(1131, 486)
      Me.Controls.Add(Me.ugDetalle)
      Me.Controls.Add(Me.grbPendientes)
      Me.Controls.Add(Me.stsPie)
      Me.Controls.Add(Me.tstBarra)
      Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
      Me.KeyPreview = True
      Me.Name = "AlertasInforme"
      Me.ShowInTaskbar = False
      Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
      Me.Text = "Informe de Alertas"
      Me.grbPendientes.ResumeLayout(False)
      Me.grbPendientes.PerformLayout()
      Me.stsPie.ResumeLayout(False)
      Me.stsPie.PerformLayout()
      Me.tstBarra.ResumeLayout(False)
      Me.tstBarra.PerformLayout()
      CType(Me.ugDetalle, System.ComponentModel.ISupportInitialize).EndInit()
      Me.ResumeLayout(False)
      Me.PerformLayout()

   End Sub
   Public WithEvents tstBarra As System.Windows.Forms.ToolStrip
   Public WithEvents tsbRefrescar As System.Windows.Forms.ToolStripButton
   Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
   Public WithEvents tsbSalir As System.Windows.Forms.ToolStripButton
   Friend WithEvents stsPie As System.Windows.Forms.StatusStrip
   Friend WithEvents tssPie As System.Windows.Forms.ToolStripStatusLabel
   Friend WithEvents grbPendientes As System.Windows.Forms.GroupBox
   Friend WithEvents dtpHasta As Eniac.Controles.DateTimePicker
   Friend WithEvents lblHasta As Eniac.Controles.Label
   Friend WithEvents dtpDesde As Eniac.Controles.DateTimePicker
   Friend WithEvents lblDesde As Eniac.Controles.Label
   Friend WithEvents cmbTipoDeNotificacion As Eniac.Controles.ComboBox
   Friend WithEvents chbTipoDeNotificacion As Eniac.Controles.CheckBox
   Friend WithEvents lblPrioridad As Eniac.Controles.Label
   Friend WithEvents cboPrioridad As Eniac.Controles.ComboBox
   Friend WithEvents btnBuscar2 As Eniac.Controles.Button
   Friend WithEvents ugDetalle As Infragistics.Win.UltraWinGrid.UltraGrid
   Protected WithEvents tssRegistros As System.Windows.Forms.ToolStripStatusLabel
End Class
