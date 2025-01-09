<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class GestionesInforme
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
      Me.components = New System.ComponentModel.Container()
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
      Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(GestionesInforme))
      Me.sfdExportar = New System.Windows.Forms.SaveFileDialog()
      Me.UltraGridExcelExporter1 = New Infragistics.Win.UltraWinGrid.ExcelExport.UltraGridExcelExporter(Me.components)
      Me.UltraGridDocumentExporter1 = New Infragistics.Win.UltraWinGrid.DocumentExport.UltraGridDocumentExporter(Me.components)
      Me.btnBuscar = New Eniac.Controles.Button()
      Me.ugDatos = New Infragistics.Win.UltraWinGrid.UltraGrid()
      Me.grbPendientes = New System.Windows.Forms.GroupBox()
      Me.dtpFechaHasta = New Eniac.Controles.DateTimePicker()
      Me.lblGestion = New System.Windows.Forms.Label()
      Me.lblHasta = New System.Windows.Forms.Label()
      Me.dtpFechaDesde = New Eniac.Controles.DateTimePicker()
      Me.lblDesde = New System.Windows.Forms.Label()
      Me.chbUsuarios = New System.Windows.Forms.CheckBox()
      Me.chbTipoDeNotificacion = New System.Windows.Forms.CheckBox()
      Me.cmbTipoDeNotificacion = New Eniac.Controles.ComboBox()
      Me.cmbUsuarios = New Eniac.Controles.ComboBox()
      Me.stsPie = New System.Windows.Forms.StatusStrip()
      Me.tssPie = New System.Windows.Forms.ToolStripStatusLabel()
      Me.tssTotal = New System.Windows.Forms.ToolStripStatusLabel()
      Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel()
      Me.tssRegistros = New System.Windows.Forms.ToolStripStatusLabel()
      Me.tstBarra = New System.Windows.Forms.ToolStrip()
      Me.tsbRefrescar = New System.Windows.Forms.ToolStripButton()
      Me.tss1 = New System.Windows.Forms.ToolStripSeparator()
      Me.tsbImprimir = New System.Windows.Forms.ToolStripButton()
      Me.tss3 = New System.Windows.Forms.ToolStripSeparator()
      Me.tsddExportar = New System.Windows.Forms.ToolStripDropDownButton()
      Me.tsmiAExcel = New System.Windows.Forms.ToolStripMenuItem()
      Me.tsmiAPDF = New System.Windows.Forms.ToolStripMenuItem()
      Me.tss4 = New System.Windows.Forms.ToolStripSeparator()
      Me.tsbPreferencias = New System.Windows.Forms.ToolStripButton()
      Me.tss5 = New System.Windows.Forms.ToolStripSeparator()
      Me.tsbSalir = New System.Windows.Forms.ToolStripButton()
      CType(Me.ugDatos, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.grbPendientes.SuspendLayout()
      Me.stsPie.SuspendLayout()
      Me.tstBarra.SuspendLayout()
      Me.SuspendLayout()
      '
      'btnBuscar
      '
      Me.btnBuscar.Image = Global.Eniac.Win.My.Resources.Resources.view
      Me.btnBuscar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
      Me.btnBuscar.Location = New System.Drawing.Point(751, 23)
      Me.btnBuscar.Name = "btnBuscar"
      Me.btnBuscar.Size = New System.Drawing.Size(100, 45)
      Me.btnBuscar.TabIndex = 13
      Me.btnBuscar.Text = "&Consultar"
      Me.btnBuscar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      Me.btnBuscar.UseVisualStyleBackColor = True
      '
      'ugDatos
      '
      Me.ugDatos.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.ugDatos.DataMember = Nothing
      Appearance1.BackColor = System.Drawing.SystemColors.Window
      Appearance1.BorderColor = System.Drawing.SystemColors.InactiveCaption
      Me.ugDatos.DisplayLayout.Appearance = Appearance1
      Me.ugDatos.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ExtendLastColumn
      Me.ugDatos.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
      Me.ugDatos.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.[False]
      Appearance2.BackColor = System.Drawing.SystemColors.ActiveBorder
      Appearance2.BackColor2 = System.Drawing.SystemColors.ControlDark
      Appearance2.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
      Appearance2.BorderColor = System.Drawing.SystemColors.Window
      Me.ugDatos.DisplayLayout.GroupByBox.Appearance = Appearance2
      Appearance3.ForeColor = System.Drawing.SystemColors.GrayText
      Me.ugDatos.DisplayLayout.GroupByBox.BandLabelAppearance = Appearance3
      Me.ugDatos.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
      Me.ugDatos.DisplayLayout.GroupByBox.Prompt = "Arrastre un título de columna para agrupar"
      Appearance4.BackColor = System.Drawing.SystemColors.ControlLightLight
      Appearance4.BackColor2 = System.Drawing.SystemColors.Control
      Appearance4.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
      Appearance4.ForeColor = System.Drawing.SystemColors.GrayText
      Me.ugDatos.DisplayLayout.GroupByBox.PromptAppearance = Appearance4
      Me.ugDatos.DisplayLayout.MaxColScrollRegions = 1
      Me.ugDatos.DisplayLayout.MaxRowScrollRegions = 1
      Appearance5.BackColor = System.Drawing.SystemColors.Window
      Appearance5.ForeColor = System.Drawing.SystemColors.ControlText
      Me.ugDatos.DisplayLayout.Override.ActiveCellAppearance = Appearance5
      Appearance6.BackColor = System.Drawing.SystemColors.Highlight
      Appearance6.ForeColor = System.Drawing.SystemColors.HighlightText
      Me.ugDatos.DisplayLayout.Override.ActiveRowAppearance = Appearance6
      Me.ugDatos.DisplayLayout.Override.AllowUpdate = Infragistics.Win.DefaultableBoolean.[False]
      Me.ugDatos.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted
      Me.ugDatos.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted
      Appearance7.BackColor = System.Drawing.SystemColors.Window
      Me.ugDatos.DisplayLayout.Override.CardAreaAppearance = Appearance7
      Appearance8.BorderColor = System.Drawing.Color.Silver
      Appearance8.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter
      Me.ugDatos.DisplayLayout.Override.CellAppearance = Appearance8
      Me.ugDatos.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.RowSelect
      Me.ugDatos.DisplayLayout.Override.CellPadding = 0
      Appearance9.BackColor = System.Drawing.SystemColors.Control
      Appearance9.BackColor2 = System.Drawing.SystemColors.ControlDark
      Appearance9.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element
      Appearance9.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
      Appearance9.BorderColor = System.Drawing.SystemColors.Window
      Me.ugDatos.DisplayLayout.Override.GroupByRowAppearance = Appearance9
      Appearance10.TextHAlignAsString = "Left"
      Me.ugDatos.DisplayLayout.Override.HeaderAppearance = Appearance10
      Me.ugDatos.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
      Me.ugDatos.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand
      Appearance11.BackColor = System.Drawing.SystemColors.Window
      Appearance11.BorderColor = System.Drawing.Color.Silver
      Me.ugDatos.DisplayLayout.Override.RowAppearance = Appearance11
      Me.ugDatos.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[False]
      Me.ugDatos.DisplayLayout.Override.SelectTypeCell = Infragistics.Win.UltraWinGrid.SelectType.None
      Me.ugDatos.DisplayLayout.Override.SelectTypeRow = Infragistics.Win.UltraWinGrid.SelectType.[Single]
      Appearance12.BackColor = System.Drawing.SystemColors.ControlLight
      Me.ugDatos.DisplayLayout.Override.TemplateAddRowAppearance = Appearance12
      Me.ugDatos.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill
      Me.ugDatos.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate
      Me.ugDatos.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy
      Me.ugDatos.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.ugDatos.Location = New System.Drawing.Point(0, 122)
      Me.ugDatos.Name = "ugDatos"
      Me.ugDatos.Size = New System.Drawing.Size(1131, 377)
      Me.ugDatos.TabIndex = 1
      Me.ugDatos.Text = "UltraGrid1"
      '
      'grbPendientes
      '
      Me.grbPendientes.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.grbPendientes.Controls.Add(Me.dtpFechaHasta)
      Me.grbPendientes.Controls.Add(Me.lblGestion)
      Me.grbPendientes.Controls.Add(Me.lblHasta)
      Me.grbPendientes.Controls.Add(Me.dtpFechaDesde)
      Me.grbPendientes.Controls.Add(Me.lblDesde)
      Me.grbPendientes.Controls.Add(Me.chbUsuarios)
      Me.grbPendientes.Controls.Add(Me.chbTipoDeNotificacion)
      Me.grbPendientes.Controls.Add(Me.cmbTipoDeNotificacion)
      Me.grbPendientes.Controls.Add(Me.cmbUsuarios)
      Me.grbPendientes.Controls.Add(Me.btnBuscar)
      Me.grbPendientes.Location = New System.Drawing.Point(4, 33)
      Me.grbPendientes.Name = "grbPendientes"
      Me.grbPendientes.Size = New System.Drawing.Size(1119, 83)
      Me.grbPendientes.TabIndex = 0
      Me.grbPendientes.TabStop = False
      '
      'dtpFechaHasta
      '
      Me.dtpFechaHasta.BindearPropiedadControl = "Value"
      Me.dtpFechaHasta.BindearPropiedadEntidad = "FechaRealizado"
      Me.dtpFechaHasta.CustomFormat = "dd/MM/yyyy"
      Me.dtpFechaHasta.ForeColorFocus = System.Drawing.Color.Red
      Me.dtpFechaHasta.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.dtpFechaHasta.Format = System.Windows.Forms.DateTimePickerFormat.Custom
      Me.dtpFechaHasta.IsPK = True
      Me.dtpFechaHasta.IsRequired = False
      Me.dtpFechaHasta.Key = ""
      Me.dtpFechaHasta.LabelAsoc = Nothing
      Me.dtpFechaHasta.Location = New System.Drawing.Point(254, 19)
      Me.dtpFechaHasta.Name = "dtpFechaHasta"
      Me.dtpFechaHasta.Size = New System.Drawing.Size(95, 20)
      Me.dtpFechaHasta.TabIndex = 6
      '
      'lblGestion
      '
      Me.lblGestion.AutoSize = True
      Me.lblGestion.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.lblGestion.Location = New System.Drawing.Point(14, 23)
      Me.lblGestion.Name = "lblGestion"
      Me.lblGestion.Size = New System.Drawing.Size(43, 13)
      Me.lblGestion.TabIndex = 2
      Me.lblGestion.Text = "Gestion"
      '
      'lblHasta
      '
      Me.lblHasta.AutoSize = True
      Me.lblHasta.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.lblHasta.Location = New System.Drawing.Point(216, 23)
      Me.lblHasta.Name = "lblHasta"
      Me.lblHasta.Size = New System.Drawing.Size(35, 13)
      Me.lblHasta.TabIndex = 5
      Me.lblHasta.Text = "Hasta"
      '
      'dtpFechaDesde
      '
      Me.dtpFechaDesde.BindearPropiedadControl = "Value"
      Me.dtpFechaDesde.BindearPropiedadEntidad = "FechaRealizado"
      Me.dtpFechaDesde.CustomFormat = "dd/MM/yyyy"
      Me.dtpFechaDesde.ForeColorFocus = System.Drawing.Color.Red
      Me.dtpFechaDesde.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.dtpFechaDesde.Format = System.Windows.Forms.DateTimePickerFormat.Custom
      Me.dtpFechaDesde.IsPK = True
      Me.dtpFechaDesde.IsRequired = False
      Me.dtpFechaDesde.Key = ""
      Me.dtpFechaDesde.LabelAsoc = Nothing
      Me.dtpFechaDesde.Location = New System.Drawing.Point(106, 19)
      Me.dtpFechaDesde.Name = "dtpFechaDesde"
      Me.dtpFechaDesde.Size = New System.Drawing.Size(95, 20)
      Me.dtpFechaDesde.TabIndex = 4
      '
      'lblDesde
      '
      Me.lblDesde.AutoSize = True
      Me.lblDesde.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.lblDesde.Location = New System.Drawing.Point(64, 23)
      Me.lblDesde.Name = "lblDesde"
      Me.lblDesde.Size = New System.Drawing.Size(38, 13)
      Me.lblDesde.TabIndex = 3
      Me.lblDesde.Text = "Desde"
      '
      'chbUsuarios
      '
      Me.chbUsuarios.AutoSize = True
      Me.chbUsuarios.Location = New System.Drawing.Point(379, 53)
      Me.chbUsuarios.Name = "chbUsuarios"
      Me.chbUsuarios.Size = New System.Drawing.Size(62, 17)
      Me.chbUsuarios.TabIndex = 11
      Me.chbUsuarios.Text = "Usuario"
      Me.chbUsuarios.UseVisualStyleBackColor = True
      '
      'chbTipoDeNotificacion
      '
      Me.chbTipoDeNotificacion.AutoSize = True
      Me.chbTipoDeNotificacion.Location = New System.Drawing.Point(14, 53)
      Me.chbTipoDeNotificacion.Name = "chbTipoDeNotificacion"
      Me.chbTipoDeNotificacion.Size = New System.Drawing.Size(103, 17)
      Me.chbTipoDeNotificacion.TabIndex = 9
      Me.chbTipoDeNotificacion.Text = "Tipo De Gestion"
      Me.chbTipoDeNotificacion.UseVisualStyleBackColor = True
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
      Me.cmbTipoDeNotificacion.Location = New System.Drawing.Point(123, 51)
      Me.cmbTipoDeNotificacion.Name = "cmbTipoDeNotificacion"
      Me.cmbTipoDeNotificacion.Size = New System.Drawing.Size(177, 21)
      Me.cmbTipoDeNotificacion.TabIndex = 10
      '
      'cmbUsuarios
      '
      Me.cmbUsuarios.BindearPropiedadControl = Nothing
      Me.cmbUsuarios.BindearPropiedadEntidad = Nothing
      Me.cmbUsuarios.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cmbUsuarios.Enabled = False
      Me.cmbUsuarios.ForeColorFocus = System.Drawing.Color.Red
      Me.cmbUsuarios.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.cmbUsuarios.FormattingEnabled = True
      Me.cmbUsuarios.IsPK = False
      Me.cmbUsuarios.IsRequired = False
      Me.cmbUsuarios.Key = Nothing
      Me.cmbUsuarios.LabelAsoc = Nothing
      Me.cmbUsuarios.Location = New System.Drawing.Point(447, 51)
      Me.cmbUsuarios.Name = "cmbUsuarios"
      Me.cmbUsuarios.Size = New System.Drawing.Size(106, 21)
      Me.cmbUsuarios.TabIndex = 12
      '
      'stsPie
      '
      Me.stsPie.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tssPie, Me.tssTotal, Me.ToolStripStatusLabel1, Me.tssRegistros})
      Me.stsPie.Location = New System.Drawing.Point(0, 502)
      Me.stsPie.Name = "stsPie"
      Me.stsPie.Size = New System.Drawing.Size(1131, 22)
      Me.stsPie.TabIndex = 2
      Me.stsPie.Text = "StatusStrip1"
      '
      'tssPie
      '
      Me.tssPie.Name = "tssPie"
      Me.tssPie.Size = New System.Drawing.Size(0, 17)
      Me.tssPie.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
      '
      'tssTotal
      '
      Me.tssTotal.Name = "tssTotal"
      Me.tssTotal.Size = New System.Drawing.Size(0, 17)
      Me.tssTotal.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'ToolStripStatusLabel1
      '
      Me.ToolStripStatusLabel1.Name = "ToolStripStatusLabel1"
      Me.ToolStripStatusLabel1.Size = New System.Drawing.Size(1052, 17)
      Me.ToolStripStatusLabel1.Spring = True
      Me.ToolStripStatusLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
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
      Me.tstBarra.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsbRefrescar, Me.tss1, Me.tsbImprimir, Me.tss3, Me.tsddExportar, Me.tss4, Me.tsbPreferencias, Me.tss5, Me.tsbSalir})
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
      'tss1
      '
      Me.tss1.Name = "tss1"
      Me.tss1.Size = New System.Drawing.Size(6, 29)
      '
      'tsbImprimir
      '
      Me.tsbImprimir.Image = CType(resources.GetObject("tsbImprimir.Image"), System.Drawing.Image)
      Me.tsbImprimir.ImageTransparentColor = System.Drawing.Color.Magenta
      Me.tsbImprimir.Name = "tsbImprimir"
      Me.tsbImprimir.Size = New System.Drawing.Size(79, 26)
      Me.tsbImprimir.Text = "&Imprimir"
      '
      'tss3
      '
      Me.tss3.Name = "tss3"
      Me.tss3.Size = New System.Drawing.Size(6, 29)
      '
      'tsddExportar
      '
      Me.tsddExportar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
      Me.tsddExportar.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsmiAExcel, Me.tsmiAPDF})
      Me.tsddExportar.Image = CType(resources.GetObject("tsddExportar.Image"), System.Drawing.Image)
      Me.tsddExportar.ImageTransparentColor = System.Drawing.Color.Magenta
      Me.tsddExportar.Name = "tsddExportar"
      Me.tsddExportar.Size = New System.Drawing.Size(63, 26)
      Me.tsddExportar.Text = "E&xportar"
      '
      'tsmiAExcel
      '
      Me.tsmiAExcel.Image = CType(resources.GetObject("tsmiAExcel.Image"), System.Drawing.Image)
      Me.tsmiAExcel.Name = "tsmiAExcel"
      Me.tsmiAExcel.Size = New System.Drawing.Size(109, 22)
      Me.tsmiAExcel.Text = "a Excel"
      '
      'tsmiAPDF
      '
      Me.tsmiAPDF.Image = CType(resources.GetObject("tsmiAPDF.Image"), System.Drawing.Image)
      Me.tsmiAPDF.Name = "tsmiAPDF"
      Me.tsmiAPDF.Size = New System.Drawing.Size(109, 22)
      Me.tsmiAPDF.Text = "a PDF"
      '
      'tss4
      '
      Me.tss4.Name = "tss4"
      Me.tss4.Size = New System.Drawing.Size(6, 29)
      '
      'tsbPreferencias
      '
      Me.tsbPreferencias.Image = CType(resources.GetObject("tsbPreferencias.Image"), System.Drawing.Image)
      Me.tsbPreferencias.ImageTransparentColor = System.Drawing.Color.Magenta
      Me.tsbPreferencias.Name = "tsbPreferencias"
      Me.tsbPreferencias.Size = New System.Drawing.Size(97, 26)
      Me.tsbPreferencias.Text = "&Preferencias"
      '
      'tss5
      '
      Me.tss5.Name = "tss5"
      Me.tss5.Size = New System.Drawing.Size(6, 29)
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
      'GestionesInforme
      '
      Me.AcceptButton = Me.btnBuscar
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.ClientSize = New System.Drawing.Size(1131, 524)
      Me.Controls.Add(Me.ugDatos)
      Me.Controls.Add(Me.grbPendientes)
      Me.Controls.Add(Me.stsPie)
      Me.Controls.Add(Me.tstBarra)
      Me.KeyPreview = True
      Me.Name = "GestionesInforme"
      Me.ShowInTaskbar = False
      Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
      Me.Text = "Informe de Gestiones de Cuentas"
      CType(Me.ugDatos, System.ComponentModel.ISupportInitialize).EndInit()
      Me.grbPendientes.ResumeLayout(False)
      Me.grbPendientes.PerformLayout()
      Me.stsPie.ResumeLayout(False)
      Me.stsPie.PerformLayout()
      Me.tstBarra.ResumeLayout(False)
      Me.tstBarra.PerformLayout()
      Me.ResumeLayout(False)
      Me.PerformLayout()

   End Sub
   Public WithEvents tstBarra As System.Windows.Forms.ToolStrip
   Public WithEvents tsbRefrescar As System.Windows.Forms.ToolStripButton
   Friend WithEvents tss1 As System.Windows.Forms.ToolStripSeparator
   Public WithEvents tsbSalir As System.Windows.Forms.ToolStripButton
   Friend WithEvents stsPie As System.Windows.Forms.StatusStrip
   Friend WithEvents tssPie As System.Windows.Forms.ToolStripStatusLabel
   Friend WithEvents grbPendientes As System.Windows.Forms.GroupBox
   Friend WithEvents cmbUsuarios As Eniac.Controles.ComboBox
   Friend WithEvents btnBuscar As Eniac.Controles.Button
   Friend WithEvents lblDesde As System.Windows.Forms.Label
   Friend WithEvents tssTotal As System.Windows.Forms.ToolStripStatusLabel
   Friend WithEvents dtpFechaDesde As Eniac.Controles.DateTimePicker
   Friend WithEvents chbTipoDeNotificacion As System.Windows.Forms.CheckBox
   Friend WithEvents cmbTipoDeNotificacion As Eniac.Controles.ComboBox
   Friend WithEvents chbUsuarios As System.Windows.Forms.CheckBox
   Friend WithEvents ugDatos As Infragistics.Win.UltraWinGrid.UltraGrid
   Friend WithEvents tsddExportar As System.Windows.Forms.ToolStripDropDownButton
   Friend WithEvents tsmiAExcel As System.Windows.Forms.ToolStripMenuItem
   Friend WithEvents tsmiAPDF As System.Windows.Forms.ToolStripMenuItem
   Friend WithEvents tss4 As System.Windows.Forms.ToolStripSeparator
   Friend WithEvents tsbPreferencias As System.Windows.Forms.ToolStripButton
   Private WithEvents tss5 As System.Windows.Forms.ToolStripSeparator
   Friend WithEvents tsbImprimir As System.Windows.Forms.ToolStripButton
   Friend WithEvents sfdExportar As System.Windows.Forms.SaveFileDialog
   Friend WithEvents UltraGridExcelExporter1 As Infragistics.Win.UltraWinGrid.ExcelExport.UltraGridExcelExporter
   Friend WithEvents UltraGridDocumentExporter1 As Infragistics.Win.UltraWinGrid.DocumentExport.UltraGridDocumentExporter
   Friend WithEvents dtpFechaHasta As Eniac.Controles.DateTimePicker
   Friend WithEvents lblHasta As System.Windows.Forms.Label
   Friend WithEvents lblGestion As System.Windows.Forms.Label
   Friend WithEvents tss3 As System.Windows.Forms.ToolStripSeparator
   Protected WithEvents tssRegistros As System.Windows.Forms.ToolStripStatusLabel
   Friend WithEvents ToolStripStatusLabel1 As System.Windows.Forms.ToolStripStatusLabel
End Class
