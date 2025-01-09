<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class KardexComprobCtaCteClientes
   Inherits Eniac.Win.BaseForm

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
      Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(KardexComprobCtaCteClientes))
      Dim Appearance1 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Me.grbFiltros = New System.Windows.Forms.GroupBox()
      Me.txtNumero = New Eniac.Controles.TextBox()
      Me.lblNumeroFactura = New Eniac.Controles.Label()
      Me.txtEmisor = New Eniac.Controles.TextBox()
      Me.lblEmisorFactura = New Eniac.Controles.Label()
      Me.lblTipoFactura = New Eniac.Controles.Label()
      Me.cboLetra = New Eniac.Controles.ComboBox()
      Me.lblComprobante = New Eniac.Controles.Label()
      Me.lblTipoComprobante = New Eniac.Controles.Label()
      Me.cmbTiposComprobantes = New Eniac.Controles.ComboBox()
      Me.btnConsultar = New Eniac.Controles.Button()
      Me.imgIconos = New System.Windows.Forms.ImageList(Me.components)
      Me.tstBarra = New System.Windows.Forms.ToolStrip()
      Me.tsbRefrescar = New System.Windows.Forms.ToolStripButton()
      Me.toolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
      Me.tsbImprimir = New System.Windows.Forms.ToolStripButton()
      Me.tss3 = New System.Windows.Forms.ToolStripSeparator()
      Me.tsddExportar = New System.Windows.Forms.ToolStripDropDownButton()
      Me.tsmiAExcel = New System.Windows.Forms.ToolStripMenuItem()
      Me.tsmiAPDF = New System.Windows.Forms.ToolStripMenuItem()
      Me.tss2 = New System.Windows.Forms.ToolStripSeparator()
      Me.tsbImprimir2 = New System.Windows.Forms.ToolStripButton()
      Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
      Me.tsbSalir = New System.Windows.Forms.ToolStripButton()
      Me.tss5 = New System.Windows.Forms.ToolStripSeparator()
      Me.stsStado = New System.Windows.Forms.StatusStrip()
      Me.tssInfo = New System.Windows.Forms.ToolStripStatusLabel()
      Me.tspBarra = New System.Windows.Forms.ToolStripProgressBar()
      Me.tssRegistros = New System.Windows.Forms.ToolStripStatusLabel()
      Me.KardexComprobCtaCteClientesUC1 = New Eniac.Win.KardexComprobCtaCteClientesUC()
      Me.UltraPrintPreviewDialog1 = New Infragistics.Win.Printing.UltraPrintPreviewDialog(Me.components)
      Me.UltraGridPrintDocument1 = New Infragistics.Win.UltraWinGrid.UltraGridPrintDocument(Me.components)
      Me.UltraGridExcelExporter1 = New Infragistics.Win.UltraWinGrid.ExcelExport.UltraGridExcelExporter(Me.components)
      Me.UltraGridDocumentExporter1 = New Infragistics.Win.UltraWinGrid.DocumentExport.UltraGridDocumentExporter(Me.components)
      Me.grbFiltros.SuspendLayout()
      Me.tstBarra.SuspendLayout()
      Me.stsStado.SuspendLayout()
      Me.SuspendLayout()
      '
      'grbFiltros
      '
      Me.grbFiltros.Controls.Add(Me.txtNumero)
      Me.grbFiltros.Controls.Add(Me.txtEmisor)
      Me.grbFiltros.Controls.Add(Me.lblNumeroFactura)
      Me.grbFiltros.Controls.Add(Me.lblEmisorFactura)
      Me.grbFiltros.Controls.Add(Me.lblTipoFactura)
      Me.grbFiltros.Controls.Add(Me.cboLetra)
      Me.grbFiltros.Controls.Add(Me.lblComprobante)
      Me.grbFiltros.Controls.Add(Me.lblTipoComprobante)
      Me.grbFiltros.Controls.Add(Me.cmbTiposComprobantes)
      Me.grbFiltros.Controls.Add(Me.btnConsultar)
      Me.grbFiltros.Location = New System.Drawing.Point(12, 38)
      Me.grbFiltros.Name = "grbFiltros"
      Me.grbFiltros.Size = New System.Drawing.Size(662, 68)
      Me.grbFiltros.TabIndex = 0
      Me.grbFiltros.TabStop = False
      Me.grbFiltros.Text = "Filtros"
      '
      'txtNumero
      '
      Me.txtNumero.BackColor = System.Drawing.Color.White
      Me.txtNumero.BindearPropiedadControl = Nothing
      Me.txtNumero.BindearPropiedadEntidad = Nothing
      Me.txtNumero.ForeColorFocus = System.Drawing.Color.Red
      Me.txtNumero.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtNumero.Formato = ""
      Me.txtNumero.IsDecimal = False
      Me.txtNumero.IsNumber = True
      Me.txtNumero.IsPK = False
      Me.txtNumero.IsRequired = True
      Me.txtNumero.Key = ""
      Me.txtNumero.LabelAsoc = Me.lblNumeroFactura
      Me.txtNumero.Location = New System.Drawing.Point(393, 32)
      Me.txtNumero.MaxLength = 8
      Me.txtNumero.Name = "txtNumero"
      Me.txtNumero.Size = New System.Drawing.Size(81, 20)
      Me.txtNumero.TabIndex = 3
      Me.txtNumero.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'lblNumeroFactura
      '
      Me.lblNumeroFactura.AutoSize = True
      Me.lblNumeroFactura.LabelAsoc = Nothing
      Me.lblNumeroFactura.Location = New System.Drawing.Point(390, 16)
      Me.lblNumeroFactura.Name = "lblNumeroFactura"
      Me.lblNumeroFactura.Size = New System.Drawing.Size(44, 13)
      Me.lblNumeroFactura.TabIndex = 9
      Me.lblNumeroFactura.Text = "Numero"
      '
      'txtEmisor
      '
      Me.txtEmisor.BackColor = System.Drawing.Color.White
      Me.txtEmisor.BindearPropiedadControl = Nothing
      Me.txtEmisor.BindearPropiedadEntidad = Nothing
      Me.txtEmisor.ForeColorFocus = System.Drawing.Color.Red
      Me.txtEmisor.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtEmisor.Formato = ""
      Me.txtEmisor.IsDecimal = False
      Me.txtEmisor.IsNumber = True
      Me.txtEmisor.IsPK = False
      Me.txtEmisor.IsRequired = True
      Me.txtEmisor.Key = ""
      Me.txtEmisor.LabelAsoc = Me.lblEmisorFactura
      Me.txtEmisor.Location = New System.Drawing.Point(346, 32)
      Me.txtEmisor.MaxLength = 4
      Me.txtEmisor.Name = "txtEmisor"
      Me.txtEmisor.Size = New System.Drawing.Size(41, 20)
      Me.txtEmisor.TabIndex = 2
      Me.txtEmisor.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'lblEmisorFactura
      '
      Me.lblEmisorFactura.AutoSize = True
      Me.lblEmisorFactura.LabelAsoc = Nothing
      Me.lblEmisorFactura.Location = New System.Drawing.Point(343, 16)
      Me.lblEmisorFactura.Name = "lblEmisorFactura"
      Me.lblEmisorFactura.Size = New System.Drawing.Size(38, 13)
      Me.lblEmisorFactura.TabIndex = 8
      Me.lblEmisorFactura.Text = "Emisor"
      '
      'lblTipoFactura
      '
      Me.lblTipoFactura.AutoSize = True
      Me.lblTipoFactura.LabelAsoc = Nothing
      Me.lblTipoFactura.Location = New System.Drawing.Point(286, 16)
      Me.lblTipoFactura.Name = "lblTipoFactura"
      Me.lblTipoFactura.Size = New System.Drawing.Size(31, 13)
      Me.lblTipoFactura.TabIndex = 7
      Me.lblTipoFactura.Text = "Letra"
      '
      'cboLetra
      '
      Me.cboLetra.BindearPropiedadControl = Nothing
      Me.cboLetra.BindearPropiedadEntidad = Nothing
      Me.cboLetra.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cboLetra.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.cboLetra.ForeColorFocus = System.Drawing.Color.Red
      Me.cboLetra.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.cboLetra.FormattingEnabled = True
      Me.cboLetra.IsPK = False
      Me.cboLetra.IsRequired = False
      Me.cboLetra.Key = Nothing
      Me.cboLetra.LabelAsoc = Me.lblTipoFactura
      Me.cboLetra.Location = New System.Drawing.Point(289, 32)
      Me.cboLetra.Name = "cboLetra"
      Me.cboLetra.Size = New System.Drawing.Size(48, 21)
      Me.cboLetra.TabIndex = 1
      '
      'lblComprobante
      '
      Me.lblComprobante.AutoSize = True
      Me.lblComprobante.LabelAsoc = Nothing
      Me.lblComprobante.Location = New System.Drawing.Point(11, 36)
      Me.lblComprobante.Name = "lblComprobante"
      Me.lblComprobante.Size = New System.Drawing.Size(70, 13)
      Me.lblComprobante.TabIndex = 6
      Me.lblComprobante.Text = "Comprobante"
      '
      'lblTipoComprobante
      '
      Me.lblTipoComprobante.AutoSize = True
      Me.lblTipoComprobante.LabelAsoc = Nothing
      Me.lblTipoComprobante.Location = New System.Drawing.Point(84, 16)
      Me.lblTipoComprobante.Name = "lblTipoComprobante"
      Me.lblTipoComprobante.Size = New System.Drawing.Size(94, 13)
      Me.lblTipoComprobante.TabIndex = 5
      Me.lblTipoComprobante.Text = "Tipo Comprobante"
      '
      'cmbTiposComprobantes
      '
      Me.cmbTiposComprobantes.BindearPropiedadControl = Nothing
      Me.cmbTiposComprobantes.BindearPropiedadEntidad = Nothing
      Me.cmbTiposComprobantes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cmbTiposComprobantes.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
      Me.cmbTiposComprobantes.ForeColorFocus = System.Drawing.Color.Red
      Me.cmbTiposComprobantes.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.cmbTiposComprobantes.FormattingEnabled = True
      Me.cmbTiposComprobantes.IsPK = False
      Me.cmbTiposComprobantes.IsRequired = False
      Me.cmbTiposComprobantes.ItemHeight = 13
      Me.cmbTiposComprobantes.Key = Nothing
      Me.cmbTiposComprobantes.LabelAsoc = Nothing
      Me.cmbTiposComprobantes.Location = New System.Drawing.Point(87, 32)
      Me.cmbTiposComprobantes.Name = "cmbTiposComprobantes"
      Me.cmbTiposComprobantes.Size = New System.Drawing.Size(196, 21)
      Me.cmbTiposComprobantes.TabIndex = 0
      '
      'btnConsultar
      '
      Me.btnConsultar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.btnConsultar.Image = Global.Eniac.Win.My.Resources.Resources.view
      Me.btnConsultar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
      Me.btnConsultar.Location = New System.Drawing.Point(556, 17)
      Me.btnConsultar.Name = "btnConsultar"
      Me.btnConsultar.Size = New System.Drawing.Size(100, 45)
      Me.btnConsultar.TabIndex = 4
      Me.btnConsultar.Text = "&Consultar"
      Me.btnConsultar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      Me.btnConsultar.UseVisualStyleBackColor = True
      '
      'imgIconos
      '
      Me.imgIconos.ImageStream = CType(resources.GetObject("imgIconos.ImageStream"), System.Windows.Forms.ImageListStreamer)
      Me.imgIconos.TransparentColor = System.Drawing.Color.Transparent
      Me.imgIconos.Images.SetKeyName(0, "find.ico")
      '
      'tstBarra
      '
      Me.tstBarra.AllowItemReorder = True
      Me.tstBarra.ImageScalingSize = New System.Drawing.Size(22, 22)
      Me.tstBarra.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsbRefrescar, Me.toolStripSeparator3, Me.tsbImprimir, Me.tss3, Me.tsddExportar, Me.tss2, Me.tsbImprimir2, Me.ToolStripSeparator2, Me.tsbSalir, Me.tss5})
      Me.tstBarra.Location = New System.Drawing.Point(0, 0)
      Me.tstBarra.Name = "tstBarra"
      Me.tstBarra.Size = New System.Drawing.Size(686, 29)
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
      'tsbImprimir
      '
      Me.tsbImprimir.Image = Global.Eniac.Win.My.Resources.Resources.printer_32
      Me.tsbImprimir.ImageTransparentColor = System.Drawing.Color.Magenta
      Me.tsbImprimir.Name = "tsbImprimir"
      Me.tsbImprimir.Size = New System.Drawing.Size(79, 26)
      Me.tsbImprimir.Text = "&Imprimir"
      Me.tsbImprimir.ToolTipText = "Imprimir y Grabar (F4)"
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
      Me.tsddExportar.ImageTransparentColor = System.Drawing.Color.Magenta
      Me.tsddExportar.Name = "tsddExportar"
      Me.tsddExportar.Size = New System.Drawing.Size(64, 26)
      Me.tsddExportar.Text = "Exportar"
      '
      'tsmiAExcel
      '
      Me.tsmiAExcel.Image = CType(resources.GetObject("tsmiAExcel.Image"), System.Drawing.Image)
      Me.tsmiAExcel.Name = "tsmiAExcel"
      Me.tsmiAExcel.Size = New System.Drawing.Size(110, 22)
      Me.tsmiAExcel.Text = "a Excel"
      '
      'tsmiAPDF
      '
      Me.tsmiAPDF.Image = CType(resources.GetObject("tsmiAPDF.Image"), System.Drawing.Image)
      Me.tsmiAPDF.Name = "tsmiAPDF"
      Me.tsmiAPDF.Size = New System.Drawing.Size(110, 22)
      Me.tsmiAPDF.Text = "a PDF"
      '
      'tss2
      '
      Me.tss2.Name = "tss2"
      Me.tss2.Size = New System.Drawing.Size(6, 29)
      '
      'tsbImprimir2
      '
      Me.tsbImprimir2.Image = Global.Eniac.Win.My.Resources.Resources.printer
      Me.tsbImprimir2.ImageTransparentColor = System.Drawing.Color.Magenta
      Me.tsbImprimir2.Name = "tsbImprimir2"
      Me.tsbImprimir2.Size = New System.Drawing.Size(147, 26)
      Me.tsbImprimir2.Text = "&Imprimir Prediseñado"
      Me.tsbImprimir2.ToolTipText = "Imprimir y Grabar (F4)"
      '
      'ToolStripSeparator2
      '
      Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
      Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 29)
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
      'tss5
      '
      Me.tss5.Name = "tss5"
      Me.tss5.Size = New System.Drawing.Size(6, 29)
      '
      'stsStado
      '
      Me.stsStado.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tssInfo, Me.tspBarra, Me.tssRegistros})
      Me.stsStado.Location = New System.Drawing.Point(0, 461)
      Me.stsStado.Name = "stsStado"
      Me.stsStado.Size = New System.Drawing.Size(686, 22)
      Me.stsStado.TabIndex = 4
      Me.stsStado.Text = "statusStrip1"
      '
      'tssInfo
      '
      Me.tssInfo.Name = "tssInfo"
      Me.tssInfo.Size = New System.Drawing.Size(607, 17)
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
      'KardexComprobCtaCteClientesUC1
      '
      Me.KardexComprobCtaCteClientesUC1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.KardexComprobCtaCteClientesUC1.Location = New System.Drawing.Point(12, 112)
      Me.KardexComprobCtaCteClientesUC1.Name = "KardexComprobCtaCteClientesUC1"
      Me.KardexComprobCtaCteClientesUC1.Size = New System.Drawing.Size(662, 346)
      Me.KardexComprobCtaCteClientesUC1.TabIndex = 6
      '
      'UltraPrintPreviewDialog1
      '
      Me.UltraPrintPreviewDialog1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
      Me.UltraPrintPreviewDialog1.Name = "UltraPrintPreviewDialog1"
      '
      'UltraGridPrintDocument1
      '
      Me.UltraGridPrintDocument1.DocumentName = "Informe"
      Me.UltraGridPrintDocument1.FitWidthToPages = 1
      Me.UltraGridPrintDocument1.Footer.TextCenter = ""
      Appearance1.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
      Appearance1.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element
      Appearance1.BackGradientStyle = Infragistics.Win.GradientStyle.VerticalBump
      Me.UltraGridPrintDocument1.Header.Appearance = Appearance1
      Me.UltraGridPrintDocument1.Header.BorderSides = System.Windows.Forms.Border3DSide.Bottom
      Me.UltraGridPrintDocument1.Header.BorderStyle = Infragistics.Win.UIElementBorderStyle.None
      Me.UltraGridPrintDocument1.Header.TextCenter = ""
      Me.UltraGridPrintDocument1.Page.BorderStyle = Infragistics.Win.UIElementBorderStyle.None
      Me.UltraGridPrintDocument1.Page.Margins.Bottom = 2
      Me.UltraGridPrintDocument1.Page.Margins.Left = 2
      Me.UltraGridPrintDocument1.Page.Margins.Right = 2
      Me.UltraGridPrintDocument1.Page.Margins.Top = 2
      Me.UltraGridPrintDocument1.PageBody.BorderStyle = Infragistics.Win.UIElementBorderStyle.None
      Me.UltraGridPrintDocument1.PageBody.Margins.Bottom = 2
      Me.UltraGridPrintDocument1.PageBody.Margins.Left = 2
      Me.UltraGridPrintDocument1.PageBody.Margins.Right = 2
      Me.UltraGridPrintDocument1.PageBody.Margins.Top = 2
      '
      'KardexComprobCtaCteClientes
      '
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.ClientSize = New System.Drawing.Size(686, 483)
      Me.Controls.Add(Me.KardexComprobCtaCteClientesUC1)
      Me.Controls.Add(Me.stsStado)
      Me.Controls.Add(Me.tstBarra)
      Me.Controls.Add(Me.grbFiltros)
      Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
      Me.KeyPreview = True
      Me.Name = "KardexComprobCtaCteClientes"
      Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
      Me.Text = "Kardex de Comprobante de Cta. Cte. de Clientes"
      Me.grbFiltros.ResumeLayout(False)
      Me.grbFiltros.PerformLayout()
      Me.tstBarra.ResumeLayout(False)
      Me.tstBarra.PerformLayout()
      Me.stsStado.ResumeLayout(False)
      Me.stsStado.PerformLayout()
      Me.ResumeLayout(False)
      Me.PerformLayout()

   End Sub
   Friend WithEvents grbFiltros As System.Windows.Forms.GroupBox
   Public WithEvents tstBarra As System.Windows.Forms.ToolStrip
   Private WithEvents toolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
   Public WithEvents tsbSalir As System.Windows.Forms.ToolStripButton
   Friend WithEvents imgIconos As System.Windows.Forms.ImageList
   Friend WithEvents btnConsultar As Eniac.Controles.Button
   Friend WithEvents cmbTiposComprobantes As Eniac.Controles.ComboBox
   Public WithEvents tsbRefrescar As System.Windows.Forms.ToolStripButton
   Protected Friend WithEvents stsStado As System.Windows.Forms.StatusStrip
   Protected Friend WithEvents tssInfo As System.Windows.Forms.ToolStripStatusLabel
   Protected Friend WithEvents tspBarra As System.Windows.Forms.ToolStripProgressBar
   Protected WithEvents tssRegistros As System.Windows.Forms.ToolStripStatusLabel
   Friend WithEvents tsbImprimir2 As System.Windows.Forms.ToolStripButton
   Friend WithEvents lblTipoComprobante As Eniac.Controles.Label
   Friend WithEvents lblComprobante As Eniac.Controles.Label
   Friend WithEvents txtNumero As Eniac.Controles.TextBox
   Friend WithEvents lblNumeroFactura As Eniac.Controles.Label
   Friend WithEvents txtEmisor As Eniac.Controles.TextBox
   Friend WithEvents lblEmisorFactura As Eniac.Controles.Label
   Friend WithEvents lblTipoFactura As Eniac.Controles.Label
   Friend WithEvents cboLetra As Eniac.Controles.ComboBox
   Friend WithEvents KardexComprobCtaCteClientesUC1 As Eniac.Win.KardexComprobCtaCteClientesUC
   Friend WithEvents tsbImprimir As System.Windows.Forms.ToolStripButton
   Friend WithEvents tsddExportar As System.Windows.Forms.ToolStripDropDownButton
   Friend WithEvents tsmiAExcel As System.Windows.Forms.ToolStripMenuItem
   Friend WithEvents tsmiAPDF As System.Windows.Forms.ToolStripMenuItem
   Private WithEvents tss2 As System.Windows.Forms.ToolStripSeparator
   Private WithEvents tss3 As System.Windows.Forms.ToolStripSeparator
   Private WithEvents tss5 As System.Windows.Forms.ToolStripSeparator
   Private WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
   Friend WithEvents UltraPrintPreviewDialog1 As Infragistics.Win.Printing.UltraPrintPreviewDialog
   Friend WithEvents UltraGridPrintDocument1 As Infragistics.Win.UltraWinGrid.UltraGridPrintDocument
   Friend WithEvents UltraGridExcelExporter1 As Infragistics.Win.UltraWinGrid.ExcelExport.UltraGridExcelExporter
   Friend WithEvents UltraGridDocumentExporter1 As Infragistics.Win.UltraWinGrid.DocumentExport.UltraGridDocumentExporter
End Class
