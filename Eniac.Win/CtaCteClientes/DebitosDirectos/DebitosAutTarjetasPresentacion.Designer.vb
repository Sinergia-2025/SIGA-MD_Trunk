﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class DebitosAutTarjetasPresentacion
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
      Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(DebitosAutTarjetasPresentacion))
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
      Me.tsbRefrescar = New System.Windows.Forms.ToolStripButton()
      Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
      Me.tsddExportar = New System.Windows.Forms.ToolStripDropDownButton()
      Me.tsmiAExcel = New System.Windows.Forms.ToolStripMenuItem()
      Me.tsmiAPDF = New System.Windows.Forms.ToolStripMenuItem()
      Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
      Me.tsbGenerar = New System.Windows.Forms.ToolStripButton()
      Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
      Me.tsbSalir = New System.Windows.Forms.ToolStripButton()
      Me.grbFiltros = New System.Windows.Forms.GroupBox()
      Me.chbTomaFoto = New Eniac.Controles.CheckBox()
      Me.cmbTarTarjeta = New Eniac.Controles.ComboBox()
      Me.lblTarjeta = New Eniac.Controles.Label()
      Me.btnConsultar = New Eniac.Controles.Button()
      Me.stsStado = New System.Windows.Forms.StatusStrip()
      Me.tssInfo = New System.Windows.Forms.ToolStripStatusLabel()
      Me.tspBarra = New System.Windows.Forms.ToolStripProgressBar()
      Me.tssRegistros = New System.Windows.Forms.ToolStripStatusLabel()
      Me.ugDetalle = New Eniac.Win.UltraGridEditable()
      Me.UltraDataSource5 = New Infragistics.Win.UltraWinDataSource.UltraDataSource(Me.components)
      Me.sfdExportar = New System.Windows.Forms.SaveFileDialog()
      Me.UltraGridExcelExporter1 = New Infragistics.Win.UltraWinGrid.ExcelExport.UltraGridExcelExporter(Me.components)
      Me.UltraGridDocumentExporter1 = New Infragistics.Win.UltraWinGrid.DocumentExport.UltraGridDocumentExporter(Me.components)
      Me.grbDatosModificables = New System.Windows.Forms.GroupBox()
      Me.lblFechaAcreditacionDiasMacro = New Eniac.Controles.Label()
      Me.dtpFechaVencimiento = New Eniac.Controles.DateTimePicker()
      Me.lblFechaVencimiento = New Eniac.Controles.Label()
      Me.chbTodos = New Eniac.Controles.CheckBox()
      Me.tstBarra.SuspendLayout()
      Me.grbFiltros.SuspendLayout()
      Me.stsStado.SuspendLayout()
      CType(Me.ugDetalle, System.ComponentModel.ISupportInitialize).BeginInit()
      CType(Me.UltraDataSource5, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.grbDatosModificables.SuspendLayout()
      Me.SuspendLayout()
      '
      'tstBarra
      '
      Me.tstBarra.AllowItemReorder = True
      Me.tstBarra.ImageScalingSize = New System.Drawing.Size(22, 22)
      Me.tstBarra.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsbRefrescar, Me.ToolStripSeparator3, Me.tsddExportar, Me.ToolStripSeparator1, Me.tsbGenerar, Me.ToolStripSeparator2, Me.tsbSalir})
      Me.tstBarra.Location = New System.Drawing.Point(0, 0)
      Me.tstBarra.Name = "tstBarra"
      Me.tstBarra.Size = New System.Drawing.Size(884, 29)
      Me.tstBarra.TabIndex = 4
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
      'ToolStripSeparator3
      '
      Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
      Me.ToolStripSeparator3.Size = New System.Drawing.Size(6, 29)
      '
      'tsddExportar
      '
      Me.tsddExportar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
      Me.tsddExportar.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsmiAExcel, Me.tsmiAPDF})
      Me.tsddExportar.Image = CType(resources.GetObject("tsddExportar.Image"), System.Drawing.Image)
      Me.tsddExportar.ImageTransparentColor = System.Drawing.Color.Magenta
      Me.tsddExportar.Name = "tsddExportar"
      Me.tsddExportar.Size = New System.Drawing.Size(63, 26)
      Me.tsddExportar.Text = "Exportar"
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
      'ToolStripSeparator1
      '
      Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
      Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 29)
      '
      'tsbGenerar
      '
      Me.tsbGenerar.Image = Global.Eniac.Win.My.Resources.Resources.folder_32
      Me.tsbGenerar.ImageTransparentColor = System.Drawing.Color.Magenta
      Me.tsbGenerar.Name = "tsbGenerar"
      Me.tsbGenerar.Size = New System.Drawing.Size(74, 26)
      Me.tsbGenerar.Text = "&Generar"
      Me.tsbGenerar.ToolTipText = "Imprimir y Grabar (F4)"
      '
      'ToolStripSeparator2
      '
      Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
      Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 29)
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
      'grbFiltros
      '
      Me.grbFiltros.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.grbFiltros.Controls.Add(Me.chbTomaFoto)
      Me.grbFiltros.Controls.Add(Me.cmbTarTarjeta)
      Me.grbFiltros.Controls.Add(Me.btnConsultar)
      Me.grbFiltros.Controls.Add(Me.lblTarjeta)
      Me.grbFiltros.Location = New System.Drawing.Point(12, 38)
      Me.grbFiltros.Name = "grbFiltros"
      Me.grbFiltros.Size = New System.Drawing.Size(483, 72)
      Me.grbFiltros.TabIndex = 0
      Me.grbFiltros.TabStop = False
      Me.grbFiltros.Text = "Filtros"
      '
      'chbTomaFoto
      '
      Me.chbTomaFoto.AutoSize = True
      Me.chbTomaFoto.BindearPropiedadControl = Nothing
      Me.chbTomaFoto.BindearPropiedadEntidad = Nothing
      Me.chbTomaFoto.ForeColorFocus = System.Drawing.Color.Red
      Me.chbTomaFoto.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
      Me.chbTomaFoto.IsPK = False
      Me.chbTomaFoto.IsRequired = False
      Me.chbTomaFoto.Key = Nothing
      Me.chbTomaFoto.LabelAsoc = Nothing
      Me.chbTomaFoto.Location = New System.Drawing.Point(34, 53)
      Me.chbTomaFoto.Name = "chbTomaFoto"
      Me.chbTomaFoto.Size = New System.Drawing.Size(121, 17)
      Me.chbTomaFoto.TabIndex = 2
      Me.chbTomaFoto.Text = "Tomar datos de foto"
      Me.chbTomaFoto.UseVisualStyleBackColor = True
      '
      'cmbTarTarjeta
      '
      Me.cmbTarTarjeta.BindearPropiedadControl = "SelectedValue"
      Me.cmbTarTarjeta.BindearPropiedadEntidad = "IdTarjeta"
      Me.cmbTarTarjeta.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cmbTarTarjeta.ForeColorFocus = System.Drawing.Color.Red
      Me.cmbTarTarjeta.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.cmbTarTarjeta.FormattingEnabled = True
      Me.cmbTarTarjeta.IsPK = False
      Me.cmbTarTarjeta.IsRequired = False
      Me.cmbTarTarjeta.Key = Nothing
      Me.cmbTarTarjeta.LabelAsoc = Me.lblTarjeta
      Me.cmbTarTarjeta.Location = New System.Drawing.Point(34, 27)
      Me.cmbTarTarjeta.Name = "cmbTarTarjeta"
      Me.cmbTarTarjeta.Size = New System.Drawing.Size(149, 21)
      Me.cmbTarTarjeta.TabIndex = 1
      '
      'lblTarjeta
      '
      Me.lblTarjeta.AutoSize = True
      Me.lblTarjeta.Location = New System.Drawing.Point(31, 13)
      Me.lblTarjeta.Name = "lblTarjeta"
      Me.lblTarjeta.Size = New System.Drawing.Size(40, 13)
      Me.lblTarjeta.TabIndex = 0
      Me.lblTarjeta.Text = "Tarjeta"
      '
      'btnConsultar
      '
      Me.btnConsultar.Image = Global.Eniac.Win.My.Resources.Resources.view
      Me.btnConsultar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
      Me.btnConsultar.Location = New System.Drawing.Point(368, 17)
      Me.btnConsultar.Name = "btnConsultar"
      Me.btnConsultar.Size = New System.Drawing.Size(100, 45)
      Me.btnConsultar.TabIndex = 3
      Me.btnConsultar.Text = "&Consultar"
      Me.btnConsultar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      Me.btnConsultar.UseVisualStyleBackColor = True
      '
      'stsStado
      '
      Me.stsStado.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tssInfo, Me.tspBarra, Me.tssRegistros})
      Me.stsStado.Location = New System.Drawing.Point(0, 540)
      Me.stsStado.Name = "stsStado"
      Me.stsStado.Size = New System.Drawing.Size(884, 22)
      Me.stsStado.TabIndex = 3
      Me.stsStado.Text = "statusStrip1"
      '
      'tssInfo
      '
      Me.tssInfo.Name = "tssInfo"
      Me.tssInfo.Size = New System.Drawing.Size(805, 17)
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
      'ugDetalle
      '
      Me.ugDetalle.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.ugDetalle.DataSource = Me.UltraDataSource5
      Appearance1.BackColor = System.Drawing.SystemColors.Window
      Appearance1.BorderColor = System.Drawing.SystemColors.InactiveCaption
      Me.ugDetalle.DisplayLayout.Appearance = Appearance1
      Me.ugDetalle.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ResizeAllColumns
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
      Me.ugDetalle.DisplayLayout.GroupByBox.Prompt = "Arrastre una columna aquí para agrupar"
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
      Me.ugDetalle.EnterMueveACeldaDeAbajo = False
      Me.ugDetalle.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.ugDetalle.Location = New System.Drawing.Point(12, 139)
      Me.ugDetalle.Name = "ugDetalle"
      Me.ugDetalle.Size = New System.Drawing.Size(863, 398)
      Me.ugDetalle.TabIndex = 2
      Me.ugDetalle.Text = "UltraGrid1"
      '
      'grbDatosModificables
      '
      Me.grbDatosModificables.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.grbDatosModificables.Controls.Add(Me.lblFechaAcreditacionDiasMacro)
      Me.grbDatosModificables.Controls.Add(Me.dtpFechaVencimiento)
      Me.grbDatosModificables.Controls.Add(Me.lblFechaVencimiento)
      Me.grbDatosModificables.Location = New System.Drawing.Point(501, 38)
      Me.grbDatosModificables.Name = "grbDatosModificables"
      Me.grbDatosModificables.Size = New System.Drawing.Size(374, 72)
      Me.grbDatosModificables.TabIndex = 1
      Me.grbDatosModificables.TabStop = False
      Me.grbDatosModificables.Text = "Datos Modificables"
      '
      'lblFechaAcreditacionDiasMacro
      '
      Me.lblFechaAcreditacionDiasMacro.AutoSize = True
      Me.lblFechaAcreditacionDiasMacro.Location = New System.Drawing.Point(103, 17)
      Me.lblFechaAcreditacionDiasMacro.Name = "lblFechaAcreditacionDiasMacro"
      Me.lblFechaAcreditacionDiasMacro.Size = New System.Drawing.Size(77, 13)
      Me.lblFechaAcreditacionDiasMacro.TabIndex = 4
      Me.lblFechaAcreditacionDiasMacro.Text = "(2 dias habiles)"
      '
      'dtpFechaVencimiento
      '
      Me.dtpFechaVencimiento.BindearPropiedadControl = Nothing
      Me.dtpFechaVencimiento.BindearPropiedadEntidad = Nothing
      Me.dtpFechaVencimiento.CustomFormat = "dd/MM/yyyy"
      Me.dtpFechaVencimiento.ForeColorFocus = System.Drawing.Color.Red
      Me.dtpFechaVencimiento.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.dtpFechaVencimiento.Format = System.Windows.Forms.DateTimePickerFormat.Custom
      Me.dtpFechaVencimiento.IsPK = False
      Me.dtpFechaVencimiento.IsRequired = False
      Me.dtpFechaVencimiento.Key = ""
      Me.dtpFechaVencimiento.LabelAsoc = Me.lblFechaVencimiento
      Me.dtpFechaVencimiento.Location = New System.Drawing.Point(103, 32)
      Me.dtpFechaVencimiento.Name = "dtpFechaVencimiento"
      Me.dtpFechaVencimiento.Size = New System.Drawing.Size(95, 20)
      Me.dtpFechaVencimiento.TabIndex = 3
      '
      'lblFechaVencimiento
      '
      Me.lblFechaVencimiento.AutoSize = True
      Me.lblFechaVencimiento.Location = New System.Drawing.Point(32, 36)
      Me.lblFechaVencimiento.Name = "lblFechaVencimiento"
      Me.lblFechaVencimiento.Size = New System.Drawing.Size(65, 13)
      Me.lblFechaVencimiento.TabIndex = 2
      Me.lblFechaVencimiento.Text = "Vencimiento"
      '
      'chbTodos
      '
      Me.chbTodos.BindearPropiedadControl = Nothing
      Me.chbTodos.BindearPropiedadEntidad = Nothing
      Me.chbTodos.ForeColorFocus = System.Drawing.Color.Red
      Me.chbTodos.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
      Me.chbTodos.Image = Global.Eniac.Win.My.Resources.Resources.ok_24
      Me.chbTodos.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
      Me.chbTodos.IsPK = False
      Me.chbTodos.IsRequired = False
      Me.chbTodos.Key = Nothing
      Me.chbTodos.LabelAsoc = Nothing
      Me.chbTodos.Location = New System.Drawing.Point(12, 109)
      Me.chbTodos.Name = "chbTodos"
      Me.chbTodos.Size = New System.Drawing.Size(130, 28)
      Me.chbTodos.TabIndex = 5
      Me.chbTodos.Text = "Chequear Todos"
      Me.chbTodos.UseVisualStyleBackColor = True
      '
      'DebitosAutTarjetasPresentacion
      '
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.ClientSize = New System.Drawing.Size(884, 562)
      Me.Controls.Add(Me.chbTodos)
      Me.Controls.Add(Me.grbDatosModificables)
      Me.Controls.Add(Me.ugDetalle)
      Me.Controls.Add(Me.stsStado)
      Me.Controls.Add(Me.grbFiltros)
      Me.Controls.Add(Me.tstBarra)
      Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
      Me.Name = "DebitosAutTarjetasPresentacion"
      Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
      Me.Text = "Generar Archivo para Tarjetas de Credito"
      Me.tstBarra.ResumeLayout(False)
      Me.tstBarra.PerformLayout()
      Me.grbFiltros.ResumeLayout(False)
      Me.grbFiltros.PerformLayout()
      Me.stsStado.ResumeLayout(False)
      Me.stsStado.PerformLayout()
      CType(Me.ugDetalle, System.ComponentModel.ISupportInitialize).EndInit()
      CType(Me.UltraDataSource5, System.ComponentModel.ISupportInitialize).EndInit()
      Me.grbDatosModificables.ResumeLayout(False)
      Me.grbDatosModificables.PerformLayout()
      Me.ResumeLayout(False)
      Me.PerformLayout()

   End Sub
   Public WithEvents tstBarra As System.Windows.Forms.ToolStrip
   Public WithEvents tsbRefrescar As System.Windows.Forms.ToolStripButton
   Private WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
   Friend WithEvents tsbGenerar As System.Windows.Forms.ToolStripButton
   Private WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
   Public WithEvents tsbSalir As System.Windows.Forms.ToolStripButton
   Friend WithEvents grbFiltros As System.Windows.Forms.GroupBox
   Friend WithEvents btnConsultar As Eniac.Controles.Button
   Protected Friend WithEvents stsStado As System.Windows.Forms.StatusStrip
   Protected Friend WithEvents tssInfo As System.Windows.Forms.ToolStripStatusLabel
   Protected Friend WithEvents tspBarra As System.Windows.Forms.ToolStripProgressBar
   Protected WithEvents tssRegistros As System.Windows.Forms.ToolStripStatusLabel
   Friend WithEvents ugDetalle As Eniac.Win.UltraGridEditable
   Friend WithEvents UltraDataSource5 As Infragistics.Win.UltraWinDataSource.UltraDataSource
   Friend WithEvents tsddExportar As System.Windows.Forms.ToolStripDropDownButton
   Friend WithEvents tsmiAExcel As System.Windows.Forms.ToolStripMenuItem
   Friend WithEvents tsmiAPDF As System.Windows.Forms.ToolStripMenuItem
   Friend WithEvents sfdExportar As System.Windows.Forms.SaveFileDialog
   Friend WithEvents UltraGridExcelExporter1 As Infragistics.Win.UltraWinGrid.ExcelExport.UltraGridExcelExporter
   Friend WithEvents UltraGridDocumentExporter1 As Infragistics.Win.UltraWinGrid.DocumentExport.UltraGridDocumentExporter
   Private WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
   Friend WithEvents grbDatosModificables As System.Windows.Forms.GroupBox
   Friend WithEvents lblTarjeta As Eniac.Controles.Label
    Friend WithEvents chbTodos As Eniac.Controles.CheckBox
    Friend WithEvents dtpFechaVencimiento As Eniac.Controles.DateTimePicker
    Friend WithEvents lblFechaVencimiento As Eniac.Controles.Label
    Friend WithEvents lblFechaAcreditacionDiasMacro As Eniac.Controles.Label
   Friend WithEvents cmbTarTarjeta As Eniac.Controles.ComboBox
   Friend WithEvents chbTomaFoto As Eniac.Controles.CheckBox
End Class