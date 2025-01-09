<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class BaseABM2
   Inherits BaseForm

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
      Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(BaseABM2))
      Dim UltraGridBand1 As Infragistics.Win.UltraWinGrid.UltraGridBand = New Infragistics.Win.UltraWinGrid.UltraGridBand("", -1)
      Dim Appearance1 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim Appearance2 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim Appearance3 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim Appearance4 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim Appearance5 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim Appearance6 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Me.stsStado = New System.Windows.Forms.StatusStrip()
      Me.tssInfo = New System.Windows.Forms.ToolStripStatusLabel()
      Me.toolStripProgressBar1 = New System.Windows.Forms.ToolStripProgressBar()
      Me.tssRegistros = New System.Windows.Forms.ToolStripStatusLabel()
      Me.tstBarra = New System.Windows.Forms.ToolStrip()
      Me.tsbRefrescar = New System.Windows.Forms.ToolStripButton()
      Me.toolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
      Me.tsbNuevo = New System.Windows.Forms.ToolStripButton()
      Me.tsbEditar = New System.Windows.Forms.ToolStripButton()
      Me.tsbCopiar = New System.Windows.Forms.ToolStripButton()
      Me.tsbBorrar = New System.Windows.Forms.ToolStripButton()
      Me.toolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
      Me.tstColumnas = New System.Windows.Forms.ToolStripComboBox()
      Me.tstBuscar = New System.Windows.Forms.ToolStripTextBox()
      Me.tsbFiltrar = New System.Windows.Forms.ToolStripButton()
      Me.ToolStripSeparator5 = New System.Windows.Forms.ToolStripSeparator()
      Me.tsddExportar = New System.Windows.Forms.ToolStripDropDownButton()
      Me.tsmiAExcel = New System.Windows.Forms.ToolStripMenuItem()
      Me.tsmiAPDF = New System.Windows.Forms.ToolStripMenuItem()
      Me.tsbImprimirDirecto = New System.Windows.Forms.ToolStripButton()
      Me.tsbImprimir = New System.Windows.Forms.ToolStripButton()
      Me.tsbPrePrint = New System.Windows.Forms.ToolStripButton()
      Me.toolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
      Me.tsbVistaEspecial = New System.Windows.Forms.ToolStripButton()
      Me.tsbPreferencias = New System.Windows.Forms.ToolStripButton()
      Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator()
      Me.tsbSalir = New System.Windows.Forms.ToolStripButton()
      Me.dgvDatos = New Infragistics.Win.UltraWinGrid.UltraGrid()
      Me.sfdExportar = New System.Windows.Forms.SaveFileDialog()
      Me.UltraGridExcelExporter1 = New Infragistics.Win.UltraWinGrid.ExcelExport.UltraGridExcelExporter(Me.components)
      Me.UltraGridDocumentExporter1 = New Infragistics.Win.UltraWinGrid.DocumentExport.UltraGridDocumentExporter(Me.components)
      Me.uppPrint = New Infragistics.Win.Printing.UltraPrintPreviewDialog(Me.components)
      Me.ugpDocumento = New Infragistics.Win.UltraWinGrid.UltraGridPrintDocument(Me.components)
        Me.stsStado.SuspendLayout()
        Me.tstBarra.SuspendLayout()
        CType(Me.dgvDatos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'stsStado
        '
        Me.stsStado.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tssInfo, Me.toolStripProgressBar1, Me.tssRegistros})
        Me.stsStado.Location = New System.Drawing.Point(0, 376)
        Me.stsStado.Name = "stsStado"
        Me.stsStado.Size = New System.Drawing.Size(954, 22)
        Me.stsStado.TabIndex = 4
        Me.stsStado.Text = "statusStrip1"
        '
        'tssInfo
        '
        Me.tssInfo.Name = "tssInfo"
        Me.tssInfo.Size = New System.Drawing.Size(875, 17)
        Me.tssInfo.Spring = True
        '
        'toolStripProgressBar1
        '
        Me.toolStripProgressBar1.Name = "toolStripProgressBar1"
        Me.toolStripProgressBar1.Size = New System.Drawing.Size(100, 16)
        Me.toolStripProgressBar1.Visible = False
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
        Me.tstBarra.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsbRefrescar, Me.toolStripSeparator3, Me.tsbNuevo, Me.tsbEditar, Me.tsbCopiar, Me.tsbBorrar, Me.toolStripSeparator2, Me.tstColumnas, Me.tstBuscar, Me.tsbFiltrar, Me.ToolStripSeparator5, Me.tsddExportar, Me.tsbImprimirDirecto, Me.tsbImprimir, Me.tsbPrePrint, Me.toolStripSeparator1, Me.tsbVistaEspecial, Me.tsbPreferencias, Me.ToolStripSeparator4, Me.tsbSalir})
        Me.tstBarra.Location = New System.Drawing.Point(0, 0)
        Me.tstBarra.Name = "tstBarra"
        Me.tstBarra.Size = New System.Drawing.Size(954, 29)
        Me.tstBarra.TabIndex = 3
        '
        'tsbRefrescar
        '
        Me.tsbRefrescar.Image = Global.Eniac.Win.My.Resources.Resources.refresh_32
        Me.tsbRefrescar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbRefrescar.Name = "tsbRefrescar"
        Me.tsbRefrescar.Size = New System.Drawing.Size(81, 26)
        Me.tsbRefrescar.Text = "&Refrescar"
        '
        'toolStripSeparator3
        '
        Me.toolStripSeparator3.Name = "toolStripSeparator3"
        Me.toolStripSeparator3.Size = New System.Drawing.Size(6, 29)
        '
        'tsbNuevo
        '
        Me.tsbNuevo.Image = Global.Eniac.Win.My.Resources.Resources.document_add
        Me.tsbNuevo.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbNuevo.Name = "tsbNuevo"
        Me.tsbNuevo.Size = New System.Drawing.Size(68, 26)
        Me.tsbNuevo.Text = "&Nuevo"
        '
        'tsbEditar
        '
        Me.tsbEditar.Image = Global.Eniac.Win.My.Resources.Resources.document_edit
        Me.tsbEditar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbEditar.Name = "tsbEditar"
        Me.tsbEditar.Size = New System.Drawing.Size(63, 26)
        Me.tsbEditar.Text = "&Editar"
        '
        'tsbCopiar
        '
        Me.tsbCopiar.Image = Global.Eniac.Win.My.Resources.Resources.documents
        Me.tsbCopiar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbCopiar.Name = "tsbCopiar"
        Me.tsbCopiar.Size = New System.Drawing.Size(68, 26)
        Me.tsbCopiar.Text = "Co&piar"
        Me.tsbCopiar.Visible = False
        '
        'tsbBorrar
        '
        Me.tsbBorrar.Image = Global.Eniac.Win.My.Resources.Resources.document_delete
        Me.tsbBorrar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbBorrar.Name = "tsbBorrar"
        Me.tsbBorrar.Size = New System.Drawing.Size(76, 26)
        Me.tsbBorrar.Text = "E&liminar"
        '
        'toolStripSeparator2
        '
        Me.toolStripSeparator2.Name = "toolStripSeparator2"
        Me.toolStripSeparator2.Size = New System.Drawing.Size(6, 29)
        '
        'tstColumnas
        '
        Me.tstColumnas.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.tstColumnas.Name = "tstColumnas"
        Me.tstColumnas.Size = New System.Drawing.Size(120, 29)
        '
        'tstBuscar
        '
        Me.tstBuscar.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.tstBuscar.Name = "tstBuscar"
        Me.tstBuscar.Size = New System.Drawing.Size(100, 29)
        '
        'tsbFiltrar
        '
        Me.tsbFiltrar.Image = Global.Eniac.Win.My.Resources.Resources.filter_data_24
        Me.tsbFiltrar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbFiltrar.Name = "tsbFiltrar"
        Me.tsbFiltrar.Size = New System.Drawing.Size(63, 26)
        Me.tsbFiltrar.Text = "&Filtrar"
        '
        'ToolStripSeparator5
        '
        Me.ToolStripSeparator5.Name = "ToolStripSeparator5"
        Me.ToolStripSeparator5.Size = New System.Drawing.Size(6, 29)
        '
        'tsddExportar
        '
        Me.tsddExportar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.tsddExportar.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsmiAExcel, Me.tsmiAPDF})
        Me.tsddExportar.Image = CType(resources.GetObject("tsddExportar.Image"), System.Drawing.Image)
        Me.tsddExportar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsddExportar.Name = "tsddExportar"
        Me.tsddExportar.Size = New System.Drawing.Size(64, 26)
        Me.tsddExportar.Text = "E&xportar"
        '
        'tsmiAExcel
        '
        Me.tsmiAExcel.Image = Global.Eniac.Win.My.Resources.Resources.excel
        Me.tsmiAExcel.Name = "tsmiAExcel"
        Me.tsmiAExcel.Size = New System.Drawing.Size(110, 22)
        Me.tsmiAExcel.Text = "a Excel"
        '
        'tsmiAPDF
        '
        Me.tsmiAPDF.Image = Global.Eniac.Win.My.Resources.Resources.Adobe_PDF_256
        Me.tsmiAPDF.Name = "tsmiAPDF"
        Me.tsmiAPDF.Size = New System.Drawing.Size(110, 22)
        Me.tsmiAPDF.Text = "a PDF"
        '
        'tsbImprimirDirecto
        '
        Me.tsbImprimirDirecto.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tsbImprimirDirecto.Image = Global.Eniac.Win.My.Resources.Resources.printer_2
        Me.tsbImprimirDirecto.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbImprimirDirecto.Name = "tsbImprimirDirecto"
        Me.tsbImprimirDirecto.Size = New System.Drawing.Size(26, 26)
        Me.tsbImprimirDirecto.Text = "Imprimir grilla"
        '
        'tsbImprimir
        '
        Me.tsbImprimir.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tsbImprimir.Image = Global.Eniac.Win.My.Resources.Resources.printer
        Me.tsbImprimir.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbImprimir.Name = "tsbImprimir"
        Me.tsbImprimir.Size = New System.Drawing.Size(26, 26)
        Me.tsbImprimir.Text = "Imprimir"
        '
        'tsbPrePrint
        '
        Me.tsbPrePrint.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tsbPrePrint.Image = Global.Eniac.Win.My.Resources.Resources.printer_32
        Me.tsbPrePrint.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbPrePrint.Name = "tsbPrePrint"
        Me.tsbPrePrint.Size = New System.Drawing.Size(26, 26)
        Me.tsbPrePrint.Text = "Imprimir Grilla personalizada"
        '
        'toolStripSeparator1
        '
        Me.toolStripSeparator1.Name = "toolStripSeparator1"
        Me.toolStripSeparator1.Size = New System.Drawing.Size(6, 29)
        '
        'tsbVistaEspecial
        '
        Me.tsbVistaEspecial.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tsbVistaEspecial.Image = Global.Eniac.Win.My.Resources.Resources.view
        Me.tsbVistaEspecial.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbVistaEspecial.Name = "tsbVistaEspecial"
        Me.tsbVistaEspecial.Size = New System.Drawing.Size(26, 26)
        Me.tsbVistaEspecial.Text = "Vista especial"
        '
        'tsbPreferencias
        '
        Me.tsbPreferencias.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tsbPreferencias.Image = Global.Eniac.Win.My.Resources.Resources.window_ok_24
        Me.tsbPreferencias.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbPreferencias.Name = "tsbPreferencias"
        Me.tsbPreferencias.Size = New System.Drawing.Size(26, 26)
        Me.tsbPreferencias.Text = "Preferencias"
        '
        'ToolStripSeparator4
        '
        Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
        Me.ToolStripSeparator4.Size = New System.Drawing.Size(6, 29)
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
        'dgvDatos
        '
        UltraGridBand1.Header.FixOnRight = Infragistics.Win.DefaultableBoolean.[True]
        UltraGridBand1.Override.AllowUpdate = Infragistics.Win.DefaultableBoolean.[False]
        Me.dgvDatos.DisplayLayout.BandsSerializer.Add(UltraGridBand1)
        Me.dgvDatos.DisplayLayout.GroupByBox.Prompt = "Arrastre un titulo de columna aquí para agrupar."
        Me.dgvDatos.DisplayLayout.MaxColScrollRegions = 1
        Me.dgvDatos.DisplayLayout.MaxRowScrollRegions = 1
        Me.dgvDatos.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.[True]
        Me.dgvDatos.DisplayLayout.Override.AllowRowSummaries = Infragistics.Win.UltraWinGrid.AllowRowSummaries.[False]
        Appearance1.BorderColor = System.Drawing.Color.Silver
        Me.dgvDatos.DisplayLayout.Override.CellAppearance = Appearance1
        Me.dgvDatos.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText
        Appearance2.ForeColor = System.Drawing.Color.Gray
        Me.dgvDatos.DisplayLayout.Override.FixedHeaderAppearance = Appearance2
        Appearance3.ForeColor = System.Drawing.Color.ForestGreen
        Me.dgvDatos.DisplayLayout.Override.HeaderAppearance = Appearance3
        Me.dgvDatos.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
        Appearance4.ForeColor = System.Drawing.Color.Gray
        Me.dgvDatos.DisplayLayout.Override.HotTrackHeaderAppearance = Appearance4
        Appearance5.BorderColor = System.Drawing.Color.Silver
        Me.dgvDatos.DisplayLayout.Override.RowAppearance = Appearance5
        Appearance6.ForeColor = System.Drawing.Color.Gray
        Me.dgvDatos.DisplayLayout.Override.RowSelectorHeaderAppearance = Appearance6
        Me.dgvDatos.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[True]
        Me.dgvDatos.DisplayLayout.Override.SelectTypeRow = Infragistics.Win.UltraWinGrid.SelectType.None
        Me.dgvDatos.DisplayLayout.RowConnectorStyle = Infragistics.Win.UltraWinGrid.RowConnectorStyle.Dotted
        Me.dgvDatos.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill
        Me.dgvDatos.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate
        Me.dgvDatos.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy
        Me.dgvDatos.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvDatos.Location = New System.Drawing.Point(0, 29)
        Me.dgvDatos.Name = "dgvDatos"
        Me.dgvDatos.Size = New System.Drawing.Size(954, 347)
        Me.dgvDatos.TabIndex = 6
        Me.dgvDatos.UpdateMode = Infragistics.Win.UltraWinGrid.UpdateMode.OnCellChange
        '
        'uppPrint
        '
        Me.uppPrint.Name = "uppPrint"
        '
        'ugpDocumento
        '
        Me.ugpDocumento.Grid = Me.dgvDatos
        '
        'BaseABM2
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(954, 398)
        Me.Controls.Add(Me.dgvDatos)
        Me.Controls.Add(Me.stsStado)
        Me.Controls.Add(Me.tstBarra)
        Me.KeyPreview = True
        Me.Name = "BaseABM2"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.stsStado.ResumeLayout(False)
        Me.stsStado.PerformLayout()
        Me.tstBarra.ResumeLayout(False)
        Me.tstBarra.PerformLayout()
        CType(Me.dgvDatos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Protected Friend WithEvents stsStado As System.Windows.Forms.StatusStrip
   Private WithEvents toolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
   Private WithEvents toolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
   Protected Friend WithEvents tssInfo As System.Windows.Forms.ToolStripStatusLabel
   Protected Friend WithEvents toolStripProgressBar1 As System.Windows.Forms.ToolStripProgressBar
   Protected WithEvents tssRegistros As System.Windows.Forms.ToolStripStatusLabel
   Friend WithEvents ToolStripSeparator4 As System.Windows.Forms.ToolStripSeparator
   Public WithEvents tstBarra As System.Windows.Forms.ToolStrip
   Public WithEvents tsbNuevo As System.Windows.Forms.ToolStripButton
   Public WithEvents tsbEditar As System.Windows.Forms.ToolStripButton
   Public WithEvents tsbBorrar As System.Windows.Forms.ToolStripButton
   Public WithEvents tsbImprimir As System.Windows.Forms.ToolStripButton
   Public WithEvents tsbRefrescar As System.Windows.Forms.ToolStripButton
   Public WithEvents tsbSalir As System.Windows.Forms.ToolStripButton
   Friend WithEvents tsbVistaEspecial As System.Windows.Forms.ToolStripButton
   Friend WithEvents tsbPreferencias As System.Windows.Forms.ToolStripButton
   Friend WithEvents tsbPrePrint As System.Windows.Forms.ToolStripButton
   Friend WithEvents tstColumnas As System.Windows.Forms.ToolStripComboBox
   Friend WithEvents tstBuscar As System.Windows.Forms.ToolStripTextBox
   Friend WithEvents tsbFiltrar As System.Windows.Forms.ToolStripButton
   Friend WithEvents ToolStripSeparator5 As System.Windows.Forms.ToolStripSeparator
   Friend WithEvents tsddExportar As System.Windows.Forms.ToolStripDropDownButton
   Friend WithEvents tsmiAExcel As System.Windows.Forms.ToolStripMenuItem
   Friend WithEvents tsmiAPDF As System.Windows.Forms.ToolStripMenuItem
   Friend WithEvents sfdExportar As System.Windows.Forms.SaveFileDialog
   Friend WithEvents UltraGridExcelExporter1 As Infragistics.Win.UltraWinGrid.ExcelExport.UltraGridExcelExporter
   Friend WithEvents UltraGridDocumentExporter1 As Infragistics.Win.UltraWinGrid.DocumentExport.UltraGridDocumentExporter
   Public WithEvents dgvDatos As Infragistics.Win.UltraWinGrid.UltraGrid
   Friend WithEvents uppPrint As Infragistics.Win.Printing.UltraPrintPreviewDialog
   Friend WithEvents ugpDocumento As Infragistics.Win.UltraWinGrid.UltraGridPrintDocument
   Friend WithEvents tsbImprimirDirecto As System.Windows.Forms.ToolStripButton
   Public WithEvents toolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
   Friend WithEvents tsbCopiar As System.Windows.Forms.ToolStripButton
End Class
