<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ImpresionMasivaDeCuotas
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
      Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ImpresionMasivaDeCuotas))
      Dim Appearance1 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridBand1 As Infragistics.Win.UltraWinGrid.UltraGridBand = New Infragistics.Win.UltraWinGrid.UltraGridBand("Band 0", -1)
      Dim UltraGridColumn1 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Ver")
      Dim Appearance2 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn2 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdSucursal")
      Dim UltraGridColumn3 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Fecha")
      Dim Appearance3 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn4 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Hora")
      Dim Appearance4 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn5 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdCliente")
      Dim UltraGridColumn6 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("CodigoCliente")
      Dim Appearance5 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn7 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreCliente")
      Dim UltraGridColumn8 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreCaja")
      Dim UltraGridColumn9 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdTipoComprobante")
      Dim UltraGridColumn10 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Letra")
      Dim Appearance6 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn11 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("CentroEmisor")
      Dim Appearance7 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn12 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NumeroComprobante")
      Dim Appearance8 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn13 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("ImportePesos")
      Dim Appearance9 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn14 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("ImporteTickets")
      Dim Appearance10 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn15 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("ImporteCheques")
      Dim Appearance11 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn16 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("ImporteTarjetas")
      Dim Appearance12 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn17 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("ImporteTransfBancaria")
      Dim Appearance13 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn18 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreCuentaBancaria")
      Dim UltraGridColumn19 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("ImporteRetenciones")
      Dim Appearance14 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn20 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("ImporteTotal")
      Dim Appearance15 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn21 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdEstadoComprobante")
      Dim UltraGridColumn22 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdUsuario")
      Dim UltraGridColumn23 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Observacion")
      Dim UltraGridColumn24 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("FechaActualizacion")
      Dim Appearance16 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn25 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Imprime", 0)
      Dim Appearance17 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
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
      Dim Appearance29 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Me.tstBarra = New System.Windows.Forms.ToolStrip()
      Me.tsbRefrescar = New System.Windows.Forms.ToolStripButton()
      Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
      Me.tsbImprimir = New System.Windows.Forms.ToolStripButton()
      Me.ToolStripSeparator5 = New System.Windows.Forms.ToolStripSeparator()
      Me.tsbExportar = New System.Windows.Forms.ToolStripButton()
      Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
      Me.tsddExportar = New System.Windows.Forms.ToolStripDropDownButton()
      Me.tsmiAExcel = New System.Windows.Forms.ToolStripMenuItem()
      Me.tsmiAPDF = New System.Windows.Forms.ToolStripMenuItem()
      Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
      Me.tsbPreferencias = New System.Windows.Forms.ToolStripButton()
      Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator()
      Me.tsbSalir = New System.Windows.Forms.ToolStripButton()
      Me.grbFiltros = New System.Windows.Forms.GroupBox()
      Me.cmbAfectaCaja = New Eniac.Controles.ComboBox()
      Me.lblAfectaCaja = New Eniac.Controles.Label()
      Me.cmbGrabanLibro = New Eniac.Controles.ComboBox()
      Me.lblGrabanLibro = New Eniac.Controles.Label()
      Me.lblExportado = New Eniac.Controles.Label()
      Me.cmbExportado = New Eniac.Controles.ComboBox()
      Me.chbOrdenInverso = New Eniac.Controles.CheckBox()
      Me.chbUsuario = New Eniac.Controles.CheckBox()
      Me.cmbUsuario = New Eniac.Controles.ComboBox()
      Me.chbFormaPago = New Eniac.Controles.CheckBox()
      Me.cmbFormaPago = New Eniac.Controles.ComboBox()
      Me.cmbEstadoComprobante = New Eniac.Controles.ComboBox()
      Me.chbEstadoComprobante = New Eniac.Controles.CheckBox()
      Me.bscCodigoCliente = New Eniac.Controles.Buscador2()
      Me.lblCodigoCliente = New Eniac.Controles.Label()
      Me.bscCliente = New Eniac.Controles.Buscador2()
      Me.lblNombre = New Eniac.Controles.Label()
      Me.chbCliente = New Eniac.Controles.CheckBox()
      Me.chbLetra = New Eniac.Controles.CheckBox()
      Me.chkMesCompleto = New Eniac.Controles.CheckBox()
      Me.dtpHasta = New Eniac.Controles.DateTimePicker()
      Me.lblHasta = New Eniac.Controles.Label()
      Me.dtpDesde = New Eniac.Controles.DateTimePicker()
      Me.lblDesde = New Eniac.Controles.Label()
      Me.txtEmisor = New Eniac.Controles.TextBox()
      Me.lblEmisor = New Eniac.Controles.Label()
      Me.cmbLetras = New Eniac.Controles.ComboBox()
      Me.txtNroHasta = New Eniac.Controles.TextBox()
      Me.lblNroHasta = New Eniac.Controles.Label()
      Me.txtNroDesde = New Eniac.Controles.TextBox()
      Me.lblNroDesde = New Eniac.Controles.Label()
      Me.cmbTiposComprobantes = New Eniac.Controles.ComboBox()
      Me.btnConsultar = New Eniac.Controles.Button()
      Me.chbTipoComprobante = New Eniac.Controles.CheckBox()
      Me.chbTodos = New Eniac.Controles.CheckBox()
      Me.ugDetalle = New Infragistics.Win.UltraWinGrid.UltraGrid()
      Me.stsStado = New System.Windows.Forms.StatusStrip()
      Me.tssInfo = New System.Windows.Forms.ToolStripStatusLabel()
      Me.tspBarra = New System.Windows.Forms.ToolStripProgressBar()
      Me.tssRegistros = New System.Windows.Forms.ToolStripStatusLabel()
      Me.FolderBrowserDialog1 = New System.Windows.Forms.FolderBrowserDialog()
      Me.UltraGridDocumentExporter1 = New Infragistics.Win.UltraWinGrid.DocumentExport.UltraGridDocumentExporter(Me.components)
      Me.UltraGridExcelExporter1 = New Infragistics.Win.UltraWinGrid.ExcelExport.UltraGridExcelExporter(Me.components)
      Me.UltraGridPrintDocument1 = New Infragistics.Win.UltraWinGrid.UltraGridPrintDocument(Me.components)
      Me.UltraPrintPreviewDialog1 = New Infragistics.Win.Printing.UltraPrintPreviewDialog(Me.components)
      Me.sfdExportar = New System.Windows.Forms.SaveFileDialog()
        Me.tstBarra.SuspendLayout()
        Me.grbFiltros.SuspendLayout()
        CType(Me.ugDetalle, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.stsStado.SuspendLayout()
        Me.SuspendLayout()
        '
        'tstBarra
        '
        Me.tstBarra.AllowItemReorder = True
        Me.tstBarra.ImageScalingSize = New System.Drawing.Size(22, 22)
        Me.tstBarra.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsbRefrescar, Me.ToolStripSeparator1, Me.tsbImprimir, Me.ToolStripSeparator5, Me.tsbExportar, Me.ToolStripSeparator3, Me.tsddExportar, Me.ToolStripSeparator2, Me.tsbPreferencias, Me.ToolStripSeparator4, Me.tsbSalir})
        Me.tstBarra.Location = New System.Drawing.Point(0, 0)
        Me.tstBarra.Name = "tstBarra"
        Me.tstBarra.Size = New System.Drawing.Size(984, 29)
        Me.tstBarra.TabIndex = 5
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
        'tsbImprimir
        '
        Me.tsbImprimir.Image = Global.Eniac.Win.My.Resources.Resources.printer_32
        Me.tsbImprimir.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbImprimir.Name = "tsbImprimir"
        Me.tsbImprimir.Size = New System.Drawing.Size(79, 26)
        Me.tsbImprimir.Text = "&Imprimir"
        Me.tsbImprimir.ToolTipText = "Imprimir"
        '
        'ToolStripSeparator5
        '
        Me.ToolStripSeparator5.Name = "ToolStripSeparator5"
        Me.ToolStripSeparator5.Size = New System.Drawing.Size(6, 29)
        '
        'tsbExportar
        '
        Me.tsbExportar.Image = Global.Eniac.Win.My.Resources.Resources.folder_32
        Me.tsbExportar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbExportar.Name = "tsbExportar"
        Me.tsbExportar.Size = New System.Drawing.Size(117, 26)
        Me.tsbExportar.Text = "&Grabar Archivos"
        Me.tsbExportar.ToolTipText = "Imprimir"
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
        Me.tsddExportar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsddExportar.Name = "tsddExportar"
        Me.tsddExportar.Size = New System.Drawing.Size(64, 26)
        Me.tsddExportar.Text = "Exportar"
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
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 29)
        '
        'tsbPreferencias
        '
        Me.tsbPreferencias.Image = CType(resources.GetObject("tsbPreferencias.Image"), System.Drawing.Image)
        Me.tsbPreferencias.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbPreferencias.Name = "tsbPreferencias"
        Me.tsbPreferencias.Size = New System.Drawing.Size(97, 26)
        Me.tsbPreferencias.Text = "&Preferencias"
        Me.tsbPreferencias.ToolTipText = "Selector de Columnas"
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
        'grbFiltros
        '
        Me.grbFiltros.Controls.Add(Me.cmbAfectaCaja)
        Me.grbFiltros.Controls.Add(Me.lblAfectaCaja)
        Me.grbFiltros.Controls.Add(Me.cmbGrabanLibro)
        Me.grbFiltros.Controls.Add(Me.lblGrabanLibro)
        Me.grbFiltros.Controls.Add(Me.lblExportado)
        Me.grbFiltros.Controls.Add(Me.cmbExportado)
        Me.grbFiltros.Controls.Add(Me.chbOrdenInverso)
        Me.grbFiltros.Controls.Add(Me.chbUsuario)
        Me.grbFiltros.Controls.Add(Me.cmbUsuario)
        Me.grbFiltros.Controls.Add(Me.chbFormaPago)
        Me.grbFiltros.Controls.Add(Me.cmbFormaPago)
        Me.grbFiltros.Controls.Add(Me.cmbEstadoComprobante)
        Me.grbFiltros.Controls.Add(Me.chbEstadoComprobante)
        Me.grbFiltros.Controls.Add(Me.bscCodigoCliente)
        Me.grbFiltros.Controls.Add(Me.bscCliente)
        Me.grbFiltros.Controls.Add(Me.lblCodigoCliente)
        Me.grbFiltros.Controls.Add(Me.lblNombre)
        Me.grbFiltros.Controls.Add(Me.chbCliente)
        Me.grbFiltros.Controls.Add(Me.chbLetra)
        Me.grbFiltros.Controls.Add(Me.chkMesCompleto)
        Me.grbFiltros.Controls.Add(Me.dtpHasta)
        Me.grbFiltros.Controls.Add(Me.dtpDesde)
        Me.grbFiltros.Controls.Add(Me.lblHasta)
        Me.grbFiltros.Controls.Add(Me.lblDesde)
        Me.grbFiltros.Controls.Add(Me.txtEmisor)
        Me.grbFiltros.Controls.Add(Me.lblEmisor)
        Me.grbFiltros.Controls.Add(Me.cmbLetras)
        Me.grbFiltros.Controls.Add(Me.txtNroHasta)
        Me.grbFiltros.Controls.Add(Me.lblNroHasta)
        Me.grbFiltros.Controls.Add(Me.txtNroDesde)
        Me.grbFiltros.Controls.Add(Me.lblNroDesde)
        Me.grbFiltros.Controls.Add(Me.cmbTiposComprobantes)
        Me.grbFiltros.Controls.Add(Me.btnConsultar)
        Me.grbFiltros.Controls.Add(Me.chbTipoComprobante)
        Me.grbFiltros.Location = New System.Drawing.Point(6, 32)
        Me.grbFiltros.Name = "grbFiltros"
        Me.grbFiltros.Size = New System.Drawing.Size(972, 146)
        Me.grbFiltros.TabIndex = 6
        Me.grbFiltros.TabStop = False
        Me.grbFiltros.Text = "Filtros"
        '
        'cmbAfectaCaja
        '
        Me.cmbAfectaCaja.BindearPropiedadControl = Nothing
        Me.cmbAfectaCaja.BindearPropiedadEntidad = Nothing
        Me.cmbAfectaCaja.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbAfectaCaja.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbAfectaCaja.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbAfectaCaja.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbAfectaCaja.FormattingEnabled = True
        Me.cmbAfectaCaja.IsPK = False
        Me.cmbAfectaCaja.IsRequired = False
        Me.cmbAfectaCaja.Key = Nothing
        Me.cmbAfectaCaja.LabelAsoc = Me.lblAfectaCaja
        Me.cmbAfectaCaja.Location = New System.Drawing.Point(731, 14)
        Me.cmbAfectaCaja.Name = "cmbAfectaCaja"
        Me.cmbAfectaCaja.Size = New System.Drawing.Size(83, 21)
        Me.cmbAfectaCaja.TabIndex = 8
        '
        'lblAfectaCaja
        '
        Me.lblAfectaCaja.AutoSize = True
        Me.lblAfectaCaja.LabelAsoc = Nothing
        Me.lblAfectaCaja.Location = New System.Drawing.Point(665, 18)
        Me.lblAfectaCaja.Name = "lblAfectaCaja"
        Me.lblAfectaCaja.Size = New System.Drawing.Size(62, 13)
        Me.lblAfectaCaja.TabIndex = 7
        Me.lblAfectaCaja.Text = "Afecta Caja"
        '
        'cmbGrabanLibro
        '
        Me.cmbGrabanLibro.BindearPropiedadControl = Nothing
        Me.cmbGrabanLibro.BindearPropiedadEntidad = Nothing
        Me.cmbGrabanLibro.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbGrabanLibro.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbGrabanLibro.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbGrabanLibro.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbGrabanLibro.FormattingEnabled = True
        Me.cmbGrabanLibro.IsPK = False
        Me.cmbGrabanLibro.IsRequired = False
        Me.cmbGrabanLibro.Key = Nothing
        Me.cmbGrabanLibro.LabelAsoc = Me.lblGrabanLibro
        Me.cmbGrabanLibro.Location = New System.Drawing.Point(561, 14)
        Me.cmbGrabanLibro.Name = "cmbGrabanLibro"
        Me.cmbGrabanLibro.Size = New System.Drawing.Size(83, 21)
        Me.cmbGrabanLibro.TabIndex = 6
        '
        'lblGrabanLibro
        '
        Me.lblGrabanLibro.AutoSize = True
        Me.lblGrabanLibro.LabelAsoc = Nothing
        Me.lblGrabanLibro.Location = New System.Drawing.Point(487, 18)
        Me.lblGrabanLibro.Name = "lblGrabanLibro"
        Me.lblGrabanLibro.Size = New System.Drawing.Size(68, 13)
        Me.lblGrabanLibro.TabIndex = 5
        Me.lblGrabanLibro.Text = "Graban Libro"
        '
        'lblExportado
        '
        Me.lblExportado.AutoSize = True
        Me.lblExportado.LabelAsoc = Nothing
        Me.lblExportado.Location = New System.Drawing.Point(650, 122)
        Me.lblExportado.Name = "lblExportado"
        Me.lblExportado.Size = New System.Drawing.Size(55, 13)
        Me.lblExportado.TabIndex = 31
        Me.lblExportado.Text = "Exportado"
        '
        'cmbExportado
        '
        Me.cmbExportado.BindearPropiedadControl = Nothing
        Me.cmbExportado.BindearPropiedadEntidad = Nothing
        Me.cmbExportado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbExportado.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbExportado.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbExportado.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbExportado.FormattingEnabled = True
        Me.cmbExportado.IsPK = False
        Me.cmbExportado.IsRequired = False
        Me.cmbExportado.Key = Nothing
        Me.cmbExportado.LabelAsoc = Nothing
        Me.cmbExportado.Location = New System.Drawing.Point(711, 116)
        Me.cmbExportado.Name = "cmbExportado"
        Me.cmbExportado.Size = New System.Drawing.Size(83, 21)
        Me.cmbExportado.TabIndex = 32
        '
        'chbOrdenInverso
        '
        Me.chbOrdenInverso.AutoSize = True
        Me.chbOrdenInverso.BindearPropiedadControl = Nothing
        Me.chbOrdenInverso.BindearPropiedadEntidad = Nothing
        Me.chbOrdenInverso.Checked = True
        Me.chbOrdenInverso.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chbOrdenInverso.ForeColorFocus = System.Drawing.Color.Red
        Me.chbOrdenInverso.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbOrdenInverso.IsPK = False
        Me.chbOrdenInverso.IsRequired = False
        Me.chbOrdenInverso.Key = Nothing
        Me.chbOrdenInverso.LabelAsoc = Nothing
        Me.chbOrdenInverso.Location = New System.Drawing.Point(544, 121)
        Me.chbOrdenInverso.Name = "chbOrdenInverso"
        Me.chbOrdenInverso.Size = New System.Drawing.Size(93, 17)
        Me.chbOrdenInverso.TabIndex = 30
        Me.chbOrdenInverso.Text = "Orden Inverso"
        Me.chbOrdenInverso.UseVisualStyleBackColor = True
        '
        'chbUsuario
        '
        Me.chbUsuario.AutoSize = True
        Me.chbUsuario.BindearPropiedadControl = Nothing
        Me.chbUsuario.BindearPropiedadEntidad = Nothing
        Me.chbUsuario.ForeColorFocus = System.Drawing.Color.Red
        Me.chbUsuario.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbUsuario.IsPK = False
        Me.chbUsuario.IsRequired = False
        Me.chbUsuario.Key = Nothing
        Me.chbUsuario.LabelAsoc = Nothing
        Me.chbUsuario.Location = New System.Drawing.Point(304, 121)
        Me.chbUsuario.Name = "chbUsuario"
        Me.chbUsuario.Size = New System.Drawing.Size(62, 17)
        Me.chbUsuario.TabIndex = 28
        Me.chbUsuario.Text = "Usuario"
        Me.chbUsuario.UseVisualStyleBackColor = True
        '
        'cmbUsuario
        '
        Me.cmbUsuario.BindearPropiedadControl = Nothing
        Me.cmbUsuario.BindearPropiedadEntidad = Nothing
        Me.cmbUsuario.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbUsuario.Enabled = False
        Me.cmbUsuario.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbUsuario.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbUsuario.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbUsuario.FormattingEnabled = True
        Me.cmbUsuario.IsPK = False
        Me.cmbUsuario.IsRequired = False
        Me.cmbUsuario.Key = Nothing
        Me.cmbUsuario.LabelAsoc = Nothing
        Me.cmbUsuario.Location = New System.Drawing.Point(377, 119)
        Me.cmbUsuario.Name = "cmbUsuario"
        Me.cmbUsuario.Size = New System.Drawing.Size(148, 21)
        Me.cmbUsuario.TabIndex = 29
        '
        'chbFormaPago
        '
        Me.chbFormaPago.AutoSize = True
        Me.chbFormaPago.BindearPropiedadControl = Nothing
        Me.chbFormaPago.BindearPropiedadEntidad = Nothing
        Me.chbFormaPago.ForeColorFocus = System.Drawing.Color.Red
        Me.chbFormaPago.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbFormaPago.IsPK = False
        Me.chbFormaPago.IsRequired = False
        Me.chbFormaPago.Key = Nothing
        Me.chbFormaPago.LabelAsoc = Nothing
        Me.chbFormaPago.Location = New System.Drawing.Point(18, 118)
        Me.chbFormaPago.Name = "chbFormaPago"
        Me.chbFormaPago.Size = New System.Drawing.Size(98, 17)
        Me.chbFormaPago.TabIndex = 26
        Me.chbFormaPago.Text = "Forma de Pago"
        Me.chbFormaPago.UseVisualStyleBackColor = True
        '
        'cmbFormaPago
        '
        Me.cmbFormaPago.BindearPropiedadControl = Nothing
        Me.cmbFormaPago.BindearPropiedadEntidad = Nothing
        Me.cmbFormaPago.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbFormaPago.Enabled = False
        Me.cmbFormaPago.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbFormaPago.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbFormaPago.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbFormaPago.FormattingEnabled = True
        Me.cmbFormaPago.IsPK = False
        Me.cmbFormaPago.IsRequired = False
        Me.cmbFormaPago.Key = Nothing
        Me.cmbFormaPago.LabelAsoc = Nothing
        Me.cmbFormaPago.Location = New System.Drawing.Point(133, 116)
        Me.cmbFormaPago.Name = "cmbFormaPago"
        Me.cmbFormaPago.Size = New System.Drawing.Size(151, 21)
        Me.cmbFormaPago.TabIndex = 27
        '
        'cmbEstadoComprobante
        '
        Me.cmbEstadoComprobante.BindearPropiedadControl = Nothing
        Me.cmbEstadoComprobante.BindearPropiedadEntidad = Nothing
        Me.cmbEstadoComprobante.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbEstadoComprobante.Enabled = False
        Me.cmbEstadoComprobante.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbEstadoComprobante.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbEstadoComprobante.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbEstadoComprobante.FormattingEnabled = True
        Me.cmbEstadoComprobante.IsPK = False
        Me.cmbEstadoComprobante.IsRequired = False
        Me.cmbEstadoComprobante.Key = Nothing
        Me.cmbEstadoComprobante.LabelAsoc = Nothing
        Me.cmbEstadoComprobante.Location = New System.Drawing.Point(574, 55)
        Me.cmbEstadoComprobante.Name = "cmbEstadoComprobante"
        Me.cmbEstadoComprobante.Size = New System.Drawing.Size(143, 21)
        Me.cmbEstadoComprobante.TabIndex = 15
        Me.cmbEstadoComprobante.TabStop = False
        '
        'chbEstadoComprobante
        '
        Me.chbEstadoComprobante.AutoSize = True
        Me.chbEstadoComprobante.BindearPropiedadControl = Nothing
        Me.chbEstadoComprobante.BindearPropiedadEntidad = Nothing
        Me.chbEstadoComprobante.ForeColorFocus = System.Drawing.Color.Red
        Me.chbEstadoComprobante.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbEstadoComprobante.IsPK = False
        Me.chbEstadoComprobante.IsRequired = False
        Me.chbEstadoComprobante.Key = Nothing
        Me.chbEstadoComprobante.LabelAsoc = Nothing
        Me.chbEstadoComprobante.Location = New System.Drawing.Point(509, 57)
        Me.chbEstadoComprobante.Name = "chbEstadoComprobante"
        Me.chbEstadoComprobante.Size = New System.Drawing.Size(59, 17)
        Me.chbEstadoComprobante.TabIndex = 14
        Me.chbEstadoComprobante.Text = "Estado"
        Me.chbEstadoComprobante.UseVisualStyleBackColor = True
      '
      'bscCodigoCliente
      '
      Me.bscCodigoCliente.BindearPropiedadControl = Nothing
      Me.bscCodigoCliente.BindearPropiedadEntidad = Nothing
      Me.bscCodigoCliente.Datos = Nothing
      Me.bscCodigoCliente.Enabled = False
        Me.bscCodigoCliente.FilaDevuelta = Nothing
        Me.bscCodigoCliente.ForeColorFocus = System.Drawing.Color.Red
        Me.bscCodigoCliente.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.bscCodigoCliente.IsDecimal = False
        Me.bscCodigoCliente.IsNumber = False
        Me.bscCodigoCliente.IsPK = False
        Me.bscCodigoCliente.IsRequired = False
        Me.bscCodigoCliente.Key = ""
        Me.bscCodigoCliente.LabelAsoc = Me.lblCodigoCliente
        Me.bscCodigoCliente.Location = New System.Drawing.Point(96, 57)
        Me.bscCodigoCliente.MaxLengh = "32767"
        Me.bscCodigoCliente.Name = "bscCodigoCliente"
        Me.bscCodigoCliente.Permitido = True
        Me.bscCodigoCliente.Selecciono = False
        Me.bscCodigoCliente.Size = New System.Drawing.Size(90, 23)
        Me.bscCodigoCliente.TabIndex = 11
      '
      'lblCodigoCliente
      '
      Me.lblCodigoCliente.AutoSize = True
        Me.lblCodigoCliente.LabelAsoc = Nothing
        Me.lblCodigoCliente.Location = New System.Drawing.Point(93, 41)
        Me.lblCodigoCliente.Name = "lblCodigoCliente"
        Me.lblCodigoCliente.Size = New System.Drawing.Size(40, 13)
        Me.lblCodigoCliente.TabIndex = 10
        Me.lblCodigoCliente.Text = "Código"
        '
        'bscCliente
        '
        Me.bscCliente.AutoSize = True
      Me.bscCliente.BindearPropiedadControl = Nothing
      Me.bscCliente.BindearPropiedadEntidad = Nothing
      Me.bscCliente.Datos = Nothing
      Me.bscCliente.Enabled = False
        Me.bscCliente.FilaDevuelta = Nothing
        Me.bscCliente.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bscCliente.ForeColorFocus = System.Drawing.Color.Red
        Me.bscCliente.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.bscCliente.IsDecimal = False
        Me.bscCliente.IsNumber = False
        Me.bscCliente.IsPK = False
        Me.bscCliente.IsRequired = False
        Me.bscCliente.Key = ""
        Me.bscCliente.LabelAsoc = Me.lblNombre
        Me.bscCliente.Location = New System.Drawing.Point(193, 57)
        Me.bscCliente.Margin = New System.Windows.Forms.Padding(4)
        Me.bscCliente.MaxLengh = "32767"
        Me.bscCliente.Name = "bscCliente"
        Me.bscCliente.Permitido = True
        Me.bscCliente.Selecciono = False
        Me.bscCliente.Size = New System.Drawing.Size(300, 23)
        Me.bscCliente.TabIndex = 13
      '
      'lblNombre
      '
      Me.lblNombre.AutoSize = True
        Me.lblNombre.LabelAsoc = Nothing
        Me.lblNombre.Location = New System.Drawing.Point(190, 41)
        Me.lblNombre.Name = "lblNombre"
        Me.lblNombre.Size = New System.Drawing.Size(44, 13)
        Me.lblNombre.TabIndex = 12
        Me.lblNombre.Text = "Nombre"
        '
        'chbCliente
        '
        Me.chbCliente.AutoSize = True
        Me.chbCliente.BindearPropiedadControl = Nothing
        Me.chbCliente.BindearPropiedadEntidad = Nothing
        Me.chbCliente.ForeColorFocus = System.Drawing.Color.Red
        Me.chbCliente.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbCliente.IsPK = False
        Me.chbCliente.IsRequired = False
        Me.chbCliente.Key = Nothing
        Me.chbCliente.LabelAsoc = Nothing
        Me.chbCliente.Location = New System.Drawing.Point(18, 57)
        Me.chbCliente.Name = "chbCliente"
        Me.chbCliente.Size = New System.Drawing.Size(58, 17)
        Me.chbCliente.TabIndex = 9
        Me.chbCliente.Text = "Cliente"
        Me.chbCliente.UseVisualStyleBackColor = True
        '
        'chbLetra
        '
        Me.chbLetra.AutoSize = True
        Me.chbLetra.BindearPropiedadControl = Nothing
        Me.chbLetra.BindearPropiedadEntidad = Nothing
        Me.chbLetra.ForeColorFocus = System.Drawing.Color.Red
        Me.chbLetra.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbLetra.IsPK = False
        Me.chbLetra.IsRequired = False
        Me.chbLetra.Key = Nothing
        Me.chbLetra.LabelAsoc = Nothing
        Me.chbLetra.Location = New System.Drawing.Point(305, 88)
        Me.chbLetra.Name = "chbLetra"
        Me.chbLetra.Size = New System.Drawing.Size(50, 17)
        Me.chbLetra.TabIndex = 18
        Me.chbLetra.Text = "Letra"
        Me.chbLetra.UseVisualStyleBackColor = True
        '
        'chkMesCompleto
        '
        Me.chkMesCompleto.AutoSize = True
        Me.chkMesCompleto.BindearPropiedadControl = Nothing
        Me.chkMesCompleto.BindearPropiedadEntidad = Nothing
        Me.chkMesCompleto.ForeColorFocus = System.Drawing.Color.Red
        Me.chkMesCompleto.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chkMesCompleto.IsPK = False
        Me.chkMesCompleto.IsRequired = False
        Me.chkMesCompleto.Key = Nothing
        Me.chkMesCompleto.LabelAsoc = Nothing
        Me.chkMesCompleto.Location = New System.Drawing.Point(18, 17)
        Me.chkMesCompleto.Name = "chkMesCompleto"
        Me.chkMesCompleto.Size = New System.Drawing.Size(93, 17)
        Me.chkMesCompleto.TabIndex = 0
        Me.chkMesCompleto.Text = "Mes Completo"
        Me.chkMesCompleto.UseVisualStyleBackColor = True
        '
        'dtpHasta
        '
        Me.dtpHasta.BindearPropiedadControl = Nothing
        Me.dtpHasta.BindearPropiedadEntidad = Nothing
        Me.dtpHasta.CustomFormat = "dd/MM/yyyy HH:mm"
        Me.dtpHasta.ForeColorFocus = System.Drawing.Color.Red
        Me.dtpHasta.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.dtpHasta.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpHasta.IsPK = False
        Me.dtpHasta.IsRequired = False
        Me.dtpHasta.Key = ""
        Me.dtpHasta.LabelAsoc = Me.lblHasta
        Me.dtpHasta.Location = New System.Drawing.Point(327, 15)
        Me.dtpHasta.Name = "dtpHasta"
        Me.dtpHasta.Size = New System.Drawing.Size(125, 20)
        Me.dtpHasta.TabIndex = 4
        '
        'lblHasta
        '
        Me.lblHasta.AutoSize = True
        Me.lblHasta.LabelAsoc = Nothing
        Me.lblHasta.Location = New System.Drawing.Point(290, 19)
        Me.lblHasta.Name = "lblHasta"
        Me.lblHasta.Size = New System.Drawing.Size(35, 13)
        Me.lblHasta.TabIndex = 3
        Me.lblHasta.Text = "Hasta"
        '
        'dtpDesde
        '
        Me.dtpDesde.BindearPropiedadControl = Nothing
        Me.dtpDesde.BindearPropiedadEntidad = Nothing
        Me.dtpDesde.CustomFormat = "dd/MM/yyyy HH:mm"
        Me.dtpDesde.ForeColorFocus = System.Drawing.Color.Red
        Me.dtpDesde.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.dtpDesde.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpDesde.IsPK = False
        Me.dtpDesde.IsRequired = False
        Me.dtpDesde.Key = ""
        Me.dtpDesde.LabelAsoc = Me.lblDesde
        Me.dtpDesde.Location = New System.Drawing.Point(159, 15)
        Me.dtpDesde.Name = "dtpDesde"
        Me.dtpDesde.Size = New System.Drawing.Size(125, 20)
        Me.dtpDesde.TabIndex = 2
        '
        'lblDesde
        '
        Me.lblDesde.AutoSize = True
        Me.lblDesde.LabelAsoc = Nothing
        Me.lblDesde.Location = New System.Drawing.Point(115, 19)
        Me.lblDesde.Name = "lblDesde"
        Me.lblDesde.Size = New System.Drawing.Size(38, 13)
        Me.lblDesde.TabIndex = 1
        Me.lblDesde.Text = "Desde"
        '
        'txtEmisor
        '
        Me.txtEmisor.BindearPropiedadControl = Nothing
        Me.txtEmisor.BindearPropiedadEntidad = Nothing
        Me.txtEmisor.ForeColorFocus = System.Drawing.Color.Red
        Me.txtEmisor.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtEmisor.Formato = ""
        Me.txtEmisor.IsDecimal = False
        Me.txtEmisor.IsNumber = True
        Me.txtEmisor.IsPK = False
        Me.txtEmisor.IsRequired = False
        Me.txtEmisor.Key = ""
        Me.txtEmisor.LabelAsoc = Me.lblEmisor
        Me.txtEmisor.Location = New System.Drawing.Point(462, 86)
        Me.txtEmisor.MaxLength = 12
        Me.txtEmisor.Name = "txtEmisor"
        Me.txtEmisor.Size = New System.Drawing.Size(35, 20)
        Me.txtEmisor.TabIndex = 21
        Me.txtEmisor.Text = "1"
        Me.txtEmisor.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblEmisor
        '
        Me.lblEmisor.AutoSize = True
        Me.lblEmisor.LabelAsoc = Nothing
        Me.lblEmisor.Location = New System.Drawing.Point(421, 90)
        Me.lblEmisor.Name = "lblEmisor"
        Me.lblEmisor.Size = New System.Drawing.Size(38, 13)
        Me.lblEmisor.TabIndex = 20
        Me.lblEmisor.Text = "Emisor"
        '
        'cmbLetras
        '
        Me.cmbLetras.BindearPropiedadControl = Nothing
        Me.cmbLetras.BindearPropiedadEntidad = Nothing
        Me.cmbLetras.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbLetras.Enabled = False
        Me.cmbLetras.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.cmbLetras.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbLetras.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbLetras.FormattingEnabled = True
        Me.cmbLetras.IsPK = False
        Me.cmbLetras.IsRequired = False
        Me.cmbLetras.ItemHeight = 13
        Me.cmbLetras.Items.AddRange(New Object() {"X", "A", "B", "C", "M"})
        Me.cmbLetras.Key = Nothing
        Me.cmbLetras.LabelAsoc = Nothing
        Me.cmbLetras.Location = New System.Drawing.Point(356, 86)
        Me.cmbLetras.Name = "cmbLetras"
        Me.cmbLetras.Size = New System.Drawing.Size(44, 21)
        Me.cmbLetras.TabIndex = 19
        '
        'txtNroHasta
        '
        Me.txtNroHasta.BindearPropiedadControl = Nothing
        Me.txtNroHasta.BindearPropiedadEntidad = Nothing
        Me.txtNroHasta.ForeColorFocus = System.Drawing.Color.Red
        Me.txtNroHasta.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtNroHasta.Formato = ""
        Me.txtNroHasta.IsDecimal = False
        Me.txtNroHasta.IsNumber = True
        Me.txtNroHasta.IsPK = False
        Me.txtNroHasta.IsRequired = False
        Me.txtNroHasta.Key = ""
        Me.txtNroHasta.LabelAsoc = Me.lblNroHasta
        Me.txtNroHasta.Location = New System.Drawing.Point(702, 86)
        Me.txtNroHasta.MaxLength = 12
        Me.txtNroHasta.Name = "txtNroHasta"
        Me.txtNroHasta.Size = New System.Drawing.Size(67, 20)
        Me.txtNroHasta.TabIndex = 25
        Me.txtNroHasta.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblNroHasta
        '
        Me.lblNroHasta.AutoSize = True
        Me.lblNroHasta.LabelAsoc = Nothing
        Me.lblNroHasta.Location = New System.Drawing.Point(666, 90)
        Me.lblNroHasta.Name = "lblNroHasta"
        Me.lblNroHasta.Size = New System.Drawing.Size(35, 13)
        Me.lblNroHasta.TabIndex = 24
        Me.lblNroHasta.Text = "Hasta"
        '
        'txtNroDesde
        '
        Me.txtNroDesde.BindearPropiedadControl = Nothing
        Me.txtNroDesde.BindearPropiedadEntidad = Nothing
        Me.txtNroDesde.ForeColorFocus = System.Drawing.Color.Red
        Me.txtNroDesde.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtNroDesde.Formato = ""
        Me.txtNroDesde.IsDecimal = False
        Me.txtNroDesde.IsNumber = True
        Me.txtNroDesde.IsPK = False
        Me.txtNroDesde.IsRequired = False
        Me.txtNroDesde.Key = ""
        Me.txtNroDesde.LabelAsoc = Me.lblNroDesde
        Me.txtNroDesde.Location = New System.Drawing.Point(591, 86)
        Me.txtNroDesde.MaxLength = 12
        Me.txtNroDesde.Name = "txtNroDesde"
        Me.txtNroDesde.Size = New System.Drawing.Size(67, 20)
        Me.txtNroDesde.TabIndex = 23
        Me.txtNroDesde.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblNroDesde
        '
        Me.lblNroDesde.AutoSize = True
        Me.lblNroDesde.LabelAsoc = Nothing
        Me.lblNroDesde.Location = New System.Drawing.Point(512, 90)
        Me.lblNroDesde.Name = "lblNroDesde"
        Me.lblNroDesde.Size = New System.Drawing.Size(78, 13)
        Me.lblNroDesde.TabIndex = 22
        Me.lblNroDesde.Text = "Numero Desde"
        '
        'cmbTiposComprobantes
        '
        Me.cmbTiposComprobantes.BindearPropiedadControl = Nothing
        Me.cmbTiposComprobantes.BindearPropiedadEntidad = Nothing
        Me.cmbTiposComprobantes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbTiposComprobantes.Enabled = False
        Me.cmbTiposComprobantes.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.cmbTiposComprobantes.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbTiposComprobantes.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbTiposComprobantes.FormattingEnabled = True
        Me.cmbTiposComprobantes.IsPK = False
        Me.cmbTiposComprobantes.IsRequired = False
        Me.cmbTiposComprobantes.ItemHeight = 13
        Me.cmbTiposComprobantes.Key = Nothing
        Me.cmbTiposComprobantes.LabelAsoc = Nothing
        Me.cmbTiposComprobantes.Location = New System.Drawing.Point(133, 86)
        Me.cmbTiposComprobantes.Name = "cmbTiposComprobantes"
        Me.cmbTiposComprobantes.Size = New System.Drawing.Size(151, 21)
        Me.cmbTiposComprobantes.TabIndex = 17
        '
        'btnConsultar
        '
        Me.btnConsultar.Image = Global.Eniac.Win.My.Resources.Resources.view
        Me.btnConsultar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnConsultar.Location = New System.Drawing.Point(841, 86)
        Me.btnConsultar.Name = "btnConsultar"
        Me.btnConsultar.Size = New System.Drawing.Size(98, 45)
        Me.btnConsultar.TabIndex = 33
        Me.btnConsultar.Text = "&Consultar"
        Me.btnConsultar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnConsultar.UseVisualStyleBackColor = True
        '
        'chbTipoComprobante
        '
        Me.chbTipoComprobante.AutoSize = True
        Me.chbTipoComprobante.BindearPropiedadControl = Nothing
        Me.chbTipoComprobante.BindearPropiedadEntidad = Nothing
        Me.chbTipoComprobante.ForeColorFocus = System.Drawing.Color.Red
        Me.chbTipoComprobante.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbTipoComprobante.IsPK = False
        Me.chbTipoComprobante.IsRequired = False
        Me.chbTipoComprobante.Key = Nothing
        Me.chbTipoComprobante.LabelAsoc = Nothing
        Me.chbTipoComprobante.Location = New System.Drawing.Point(18, 88)
        Me.chbTipoComprobante.Name = "chbTipoComprobante"
        Me.chbTipoComprobante.Size = New System.Drawing.Size(113, 17)
        Me.chbTipoComprobante.TabIndex = 16
        Me.chbTipoComprobante.Text = "Tipo Comprobante"
        Me.chbTipoComprobante.UseVisualStyleBackColor = True
        '
        'chbTodos
        '
        Me.chbTodos.BindearPropiedadControl = Nothing
        Me.chbTodos.BindearPropiedadEntidad = Nothing
        Me.chbTodos.ForeColorFocus = System.Drawing.Color.Red
        Me.chbTodos.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbTodos.Image = Global.Eniac.Win.My.Resources.Resources.ok_16
        Me.chbTodos.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.chbTodos.IsPK = False
        Me.chbTodos.IsRequired = False
        Me.chbTodos.Key = Nothing
        Me.chbTodos.LabelAsoc = Nothing
        Me.chbTodos.Location = New System.Drawing.Point(12, 184)
        Me.chbTodos.Name = "chbTodos"
        Me.chbTodos.Size = New System.Drawing.Size(124, 22)
        Me.chbTodos.TabIndex = 0
        Me.chbTodos.Text = "Chequear todos"
        Me.chbTodos.UseVisualStyleBackColor = True
        '
        'ugDetalle
        '
        Me.ugDetalle.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Appearance1.BackColor = System.Drawing.SystemColors.Window
        Appearance1.BorderColor = System.Drawing.SystemColors.InactiveCaption
        Me.ugDetalle.DisplayLayout.Appearance = Appearance1
        UltraGridColumn1.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        Appearance2.TextHAlignAsString = "Center"
        UltraGridColumn1.CellAppearance = Appearance2
        UltraGridColumn1.DefaultCellValue = "False"
        UltraGridColumn1.Header.VisiblePosition = 1
        UltraGridColumn1.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Button
        UltraGridColumn1.Width = 34
        UltraGridColumn2.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        UltraGridColumn2.Header.VisiblePosition = 2
        UltraGridColumn2.Hidden = True
        UltraGridColumn3.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        Appearance3.TextHAlignAsString = "Center"
        UltraGridColumn3.CellAppearance = Appearance3
        UltraGridColumn3.Format = "dd/MM/yyyy"
        UltraGridColumn3.Header.VisiblePosition = 10
        UltraGridColumn3.Width = 70
        Appearance4.TextHAlignAsString = "Center"
        UltraGridColumn4.CellAppearance = Appearance4
        UltraGridColumn4.Format = "HH:mm"
        UltraGridColumn4.Header.VisiblePosition = 11
        UltraGridColumn4.Width = 40
        UltraGridColumn5.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        UltraGridColumn5.Header.VisiblePosition = 23
        UltraGridColumn5.Hidden = True
        UltraGridColumn6.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        Appearance5.TextHAlignAsString = "Right"
        UltraGridColumn6.CellAppearance = Appearance5
        UltraGridColumn6.Header.Caption = "Código"
        UltraGridColumn6.Header.VisiblePosition = 3
        UltraGridColumn6.Hidden = True
        UltraGridColumn6.Width = 50
        UltraGridColumn7.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        UltraGridColumn7.Header.Caption = "Nombre Cliente"
        UltraGridColumn7.Header.VisiblePosition = 4
        UltraGridColumn7.Width = 170
        UltraGridColumn8.Header.Caption = "Caja"
        UltraGridColumn8.Header.VisiblePosition = 7
        UltraGridColumn8.Width = 100
        UltraGridColumn9.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        UltraGridColumn9.Header.Caption = "Comprobante"
        UltraGridColumn9.Header.VisiblePosition = 5
        UltraGridColumn9.Width = 90
        UltraGridColumn10.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        Appearance6.TextHAlignAsString = "Center"
        UltraGridColumn10.CellAppearance = Appearance6
        UltraGridColumn10.Header.Caption = "Let."
        UltraGridColumn10.Header.VisiblePosition = 6
        UltraGridColumn10.Width = 30
        UltraGridColumn11.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        Appearance7.TextHAlignAsString = "Right"
        UltraGridColumn11.CellAppearance = Appearance7
        UltraGridColumn11.Header.Caption = "Emisor"
        UltraGridColumn11.Header.VisiblePosition = 8
        UltraGridColumn11.Width = 48
        UltraGridColumn12.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        Appearance8.TextHAlignAsString = "Right"
        UltraGridColumn12.CellAppearance = Appearance8
        UltraGridColumn12.Header.Caption = "Número"
        UltraGridColumn12.Header.VisiblePosition = 9
        UltraGridColumn12.Width = 70
        UltraGridColumn13.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        Appearance9.TextHAlignAsString = "Right"
        UltraGridColumn13.CellAppearance = Appearance9
        UltraGridColumn13.Format = "N2"
        UltraGridColumn13.Header.Caption = "Pesos"
        UltraGridColumn13.Header.VisiblePosition = 13
        UltraGridColumn13.Width = 80
        UltraGridColumn14.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        Appearance10.TextHAlignAsString = "Right"
        UltraGridColumn14.CellAppearance = Appearance10
        UltraGridColumn14.Format = "N2"
        UltraGridColumn14.Header.Caption = "Tickets"
        UltraGridColumn14.Header.VisiblePosition = 18
        UltraGridColumn14.Width = 70
        UltraGridColumn15.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        Appearance11.TextHAlignAsString = "Right"
        UltraGridColumn15.CellAppearance = Appearance11
        UltraGridColumn15.Format = "N2"
        UltraGridColumn15.Header.Caption = "Cheques"
        UltraGridColumn15.Header.VisiblePosition = 14
        UltraGridColumn15.Width = 80
        UltraGridColumn16.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        Appearance12.TextHAlignAsString = "Right"
        UltraGridColumn16.CellAppearance = Appearance12
        UltraGridColumn16.Format = "N2"
        UltraGridColumn16.Header.Caption = "Tarjetas"
        UltraGridColumn16.Header.VisiblePosition = 16
        UltraGridColumn16.Width = 70
        UltraGridColumn17.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        Appearance13.TextHAlignAsString = "Right"
        UltraGridColumn17.CellAppearance = Appearance13
        UltraGridColumn17.Format = "N2"
        UltraGridColumn17.Header.Caption = "Transf. Bancaria"
        UltraGridColumn17.Header.VisiblePosition = 15
        UltraGridColumn17.Width = 70
        UltraGridColumn18.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        UltraGridColumn18.Header.Caption = "Cuenta Bancaria"
        UltraGridColumn18.Header.VisiblePosition = 19
        UltraGridColumn18.Width = 100
        UltraGridColumn19.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        Appearance14.TextHAlignAsString = "Right"
        UltraGridColumn19.CellAppearance = Appearance14
        UltraGridColumn19.Format = "N2"
        UltraGridColumn19.Header.Caption = "Retenciones"
        UltraGridColumn19.Header.VisiblePosition = 17
        UltraGridColumn19.Width = 70
        UltraGridColumn20.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        Appearance15.TextHAlignAsString = "Right"
        UltraGridColumn20.CellAppearance = Appearance15
        UltraGridColumn20.Format = "N2"
        UltraGridColumn20.Header.Caption = "Total"
        UltraGridColumn20.Header.VisiblePosition = 12
        UltraGridColumn20.Width = 80
        UltraGridColumn21.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        UltraGridColumn21.Header.Caption = "Estado"
        UltraGridColumn21.Header.VisiblePosition = 20
        UltraGridColumn21.Width = 80
        UltraGridColumn22.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        UltraGridColumn22.Header.Caption = "Usuario"
        UltraGridColumn22.Header.VisiblePosition = 21
        UltraGridColumn22.Width = 70
        UltraGridColumn23.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        UltraGridColumn23.Header.VisiblePosition = 22
        UltraGridColumn23.Width = 300
        Appearance16.TextHAlignAsString = "Center"
        UltraGridColumn24.CellAppearance = Appearance16
        UltraGridColumn24.Format = "dd/MM/yyyy HH:mm"
        UltraGridColumn24.Header.Caption = "Fecha Actualización"
        UltraGridColumn24.Header.VisiblePosition = 24
        UltraGridColumn25.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.Edit
        UltraGridColumn25.DataType = GetType(Boolean)
        Appearance17.TextHAlignAsString = "Center"
        UltraGridColumn25.Header.Appearance = Appearance17
        UltraGridColumn25.Header.Caption = "I"
        UltraGridColumn25.Header.VisiblePosition = 0
        UltraGridColumn25.Width = 23
        UltraGridBand1.Columns.AddRange(New Object() {UltraGridColumn1, UltraGridColumn2, UltraGridColumn3, UltraGridColumn4, UltraGridColumn5, UltraGridColumn6, UltraGridColumn7, UltraGridColumn8, UltraGridColumn9, UltraGridColumn10, UltraGridColumn11, UltraGridColumn12, UltraGridColumn13, UltraGridColumn14, UltraGridColumn15, UltraGridColumn16, UltraGridColumn17, UltraGridColumn18, UltraGridColumn19, UltraGridColumn20, UltraGridColumn21, UltraGridColumn22, UltraGridColumn23, UltraGridColumn24, UltraGridColumn25})
        Me.ugDetalle.DisplayLayout.BandsSerializer.Add(UltraGridBand1)
        Me.ugDetalle.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.ugDetalle.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.[False]
        Appearance18.BackColor = System.Drawing.SystemColors.ActiveBorder
        Appearance18.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance18.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Appearance18.BorderColor = System.Drawing.SystemColors.Window
        Me.ugDetalle.DisplayLayout.GroupByBox.Appearance = Appearance18
        Appearance19.ForeColor = System.Drawing.SystemColors.GrayText
        Me.ugDetalle.DisplayLayout.GroupByBox.BandLabelAppearance = Appearance19
        Me.ugDetalle.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.ugDetalle.DisplayLayout.GroupByBox.Prompt = "Arrastre las columnas aquí para agrupar."
        Appearance20.BackColor = System.Drawing.SystemColors.ControlLightLight
        Appearance20.BackColor2 = System.Drawing.SystemColors.Control
        Appearance20.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance20.ForeColor = System.Drawing.SystemColors.GrayText
        Me.ugDetalle.DisplayLayout.GroupByBox.PromptAppearance = Appearance20
        Me.ugDetalle.DisplayLayout.MaxColScrollRegions = 1
        Me.ugDetalle.DisplayLayout.MaxRowScrollRegions = 1
        Appearance21.BackColor = System.Drawing.SystemColors.Window
        Appearance21.ForeColor = System.Drawing.SystemColors.ControlText
        Me.ugDetalle.DisplayLayout.Override.ActiveCellAppearance = Appearance21
        Appearance22.BackColor = System.Drawing.SystemColors.Highlight
        Appearance22.ForeColor = System.Drawing.SystemColors.HighlightText
        Me.ugDetalle.DisplayLayout.Override.ActiveRowAppearance = Appearance22
        Me.ugDetalle.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted
        Me.ugDetalle.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted
        Appearance23.BackColor = System.Drawing.SystemColors.Window
        Me.ugDetalle.DisplayLayout.Override.CardAreaAppearance = Appearance23
        Appearance24.BorderColor = System.Drawing.Color.Silver
        Appearance24.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter
        Me.ugDetalle.DisplayLayout.Override.CellAppearance = Appearance24
        Me.ugDetalle.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText
        Me.ugDetalle.DisplayLayout.Override.CellPadding = 0
        Appearance25.BackColor = System.Drawing.SystemColors.Control
        Appearance25.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance25.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element
        Appearance25.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance25.BorderColor = System.Drawing.SystemColors.Window
        Me.ugDetalle.DisplayLayout.Override.GroupByRowAppearance = Appearance25
        Appearance26.TextHAlignAsString = "Left"
        Me.ugDetalle.DisplayLayout.Override.HeaderAppearance = Appearance26
        Me.ugDetalle.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
        Me.ugDetalle.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand
        Appearance27.BackColor = System.Drawing.SystemColors.Window
        Appearance27.BorderColor = System.Drawing.Color.Silver
        Me.ugDetalle.DisplayLayout.Override.RowAppearance = Appearance27
        Me.ugDetalle.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[False]
        Me.ugDetalle.DisplayLayout.Override.SummaryDisplayArea = Infragistics.Win.UltraWinGrid.SummaryDisplayAreas.BottomFixed
        Appearance28.BackColor = System.Drawing.SystemColors.ControlLight
        Me.ugDetalle.DisplayLayout.Override.TemplateAddRowAppearance = Appearance28
        Me.ugDetalle.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill
        Me.ugDetalle.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate
        Me.ugDetalle.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy
        Me.ugDetalle.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ugDetalle.Location = New System.Drawing.Point(12, 212)
        Me.ugDetalle.Name = "ugDetalle"
        Me.ugDetalle.Size = New System.Drawing.Size(966, 274)
        Me.ugDetalle.TabIndex = 8
        Me.ugDetalle.Text = "UltraGrid1"
        '
        'stsStado
        '
        Me.stsStado.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tssInfo, Me.tspBarra, Me.tssRegistros})
        Me.stsStado.Location = New System.Drawing.Point(0, 489)
        Me.stsStado.Name = "stsStado"
        Me.stsStado.Size = New System.Drawing.Size(984, 22)
        Me.stsStado.TabIndex = 9
        Me.stsStado.Text = "statusStrip1"
        '
        'tssInfo
        '
        Me.tssInfo.Name = "tssInfo"
        Me.tssInfo.Size = New System.Drawing.Size(905, 17)
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
        'FolderBrowserDialog1
        '
        Me.FolderBrowserDialog1.Description = "Seleccione la carpeta donde desea exportar los archivos"
        '
        'UltraGridPrintDocument1
        '
        Me.UltraGridPrintDocument1.DocumentName = "Informe"
        Me.UltraGridPrintDocument1.Footer.TextCenter = ""
        Me.UltraGridPrintDocument1.Grid = Me.ugDetalle
        Appearance29.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Appearance29.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element
        Appearance29.BackGradientStyle = Infragistics.Win.GradientStyle.VerticalBump
        Me.UltraGridPrintDocument1.Header.Appearance = Appearance29
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
        'UltraPrintPreviewDialog1
        '
        Me.UltraPrintPreviewDialog1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.UltraPrintPreviewDialog1.Name = "UltraPrintPreviewDialog1"
        '
        'ImpresionMasivaDeCuotas
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(984, 511)
        Me.Controls.Add(Me.stsStado)
        Me.Controls.Add(Me.ugDetalle)
        Me.Controls.Add(Me.chbTodos)
        Me.Controls.Add(Me.grbFiltros)
        Me.Controls.Add(Me.tstBarra)
        Me.KeyPreview = True
        Me.Name = "ImpresionMasivaDeCuotas"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Impresion Masiva de Cuotas"
        Me.tstBarra.ResumeLayout(False)
        Me.tstBarra.PerformLayout()
        Me.grbFiltros.ResumeLayout(False)
        Me.grbFiltros.PerformLayout()
        CType(Me.ugDetalle, System.ComponentModel.ISupportInitialize).EndInit()
        Me.stsStado.ResumeLayout(False)
        Me.stsStado.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Public WithEvents tstBarra As System.Windows.Forms.ToolStrip
   Public WithEvents tsbRefrescar As System.Windows.Forms.ToolStripButton
   Private WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
   Friend WithEvents tsbImprimir As System.Windows.Forms.ToolStripButton
   Private WithEvents ToolStripSeparator5 As System.Windows.Forms.ToolStripSeparator
   Friend WithEvents tsbExportar As System.Windows.Forms.ToolStripButton
   Private WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
   Friend WithEvents tsddExportar As System.Windows.Forms.ToolStripDropDownButton
   Friend WithEvents tsmiAExcel As System.Windows.Forms.ToolStripMenuItem
   Friend WithEvents tsmiAPDF As System.Windows.Forms.ToolStripMenuItem
   Private WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
   Public WithEvents tsbPreferencias As System.Windows.Forms.ToolStripButton
   Private WithEvents ToolStripSeparator4 As System.Windows.Forms.ToolStripSeparator
   Public WithEvents tsbSalir As System.Windows.Forms.ToolStripButton
   Friend WithEvents grbFiltros As System.Windows.Forms.GroupBox
   Friend WithEvents lblExportado As Eniac.Controles.Label
   Friend WithEvents cmbExportado As Eniac.Controles.ComboBox
   Friend WithEvents chbOrdenInverso As Eniac.Controles.CheckBox
   Friend WithEvents chbUsuario As Eniac.Controles.CheckBox
   Friend WithEvents cmbUsuario As Eniac.Controles.ComboBox
   Friend WithEvents chbFormaPago As Eniac.Controles.CheckBox
   Friend WithEvents cmbFormaPago As Eniac.Controles.ComboBox
   Friend WithEvents cmbEstadoComprobante As Eniac.Controles.ComboBox
   Friend WithEvents chbEstadoComprobante As Eniac.Controles.CheckBox
   Friend WithEvents bscCodigoCliente As Eniac.Controles.Buscador2
   Friend WithEvents lblCodigoCliente As Eniac.Controles.Label
   Friend WithEvents bscCliente As Eniac.Controles.Buscador2
   Friend WithEvents lblNombre As Eniac.Controles.Label
   Friend WithEvents chbCliente As Eniac.Controles.CheckBox
   Friend WithEvents chbLetra As Eniac.Controles.CheckBox
   Friend WithEvents chkMesCompleto As Eniac.Controles.CheckBox
   Friend WithEvents dtpHasta As Eniac.Controles.DateTimePicker
   Friend WithEvents lblHasta As Eniac.Controles.Label
   Friend WithEvents dtpDesde As Eniac.Controles.DateTimePicker
   Friend WithEvents lblDesde As Eniac.Controles.Label
   Friend WithEvents txtEmisor As Eniac.Controles.TextBox
   Friend WithEvents lblEmisor As Eniac.Controles.Label
   Friend WithEvents cmbLetras As Eniac.Controles.ComboBox
   Friend WithEvents txtNroHasta As Eniac.Controles.TextBox
   Friend WithEvents lblNroHasta As Eniac.Controles.Label
   Friend WithEvents txtNroDesde As Eniac.Controles.TextBox
   Friend WithEvents lblNroDesde As Eniac.Controles.Label
   Friend WithEvents cmbTiposComprobantes As Eniac.Controles.ComboBox
   Friend WithEvents btnConsultar As Eniac.Controles.Button
   Friend WithEvents chbTipoComprobante As Eniac.Controles.CheckBox
   Friend WithEvents chbTodos As Eniac.Controles.CheckBox
   Friend WithEvents ugDetalle As Infragistics.Win.UltraWinGrid.UltraGrid
   Protected Friend WithEvents stsStado As System.Windows.Forms.StatusStrip
   Protected Friend WithEvents tssInfo As System.Windows.Forms.ToolStripStatusLabel
   Protected Friend WithEvents tspBarra As System.Windows.Forms.ToolStripProgressBar
   Protected WithEvents tssRegistros As System.Windows.Forms.ToolStripStatusLabel
   Friend WithEvents cmbAfectaCaja As Eniac.Controles.ComboBox
   Friend WithEvents lblAfectaCaja As Eniac.Controles.Label
   Friend WithEvents cmbGrabanLibro As Eniac.Controles.ComboBox
   Friend WithEvents lblGrabanLibro As Eniac.Controles.Label
   Private WithEvents FolderBrowserDialog1 As System.Windows.Forms.FolderBrowserDialog
   Friend WithEvents UltraGridDocumentExporter1 As Infragistics.Win.UltraWinGrid.DocumentExport.UltraGridDocumentExporter
   Friend WithEvents UltraGridExcelExporter1 As Infragistics.Win.UltraWinGrid.ExcelExport.UltraGridExcelExporter
   Friend WithEvents UltraGridPrintDocument1 As Infragistics.Win.UltraWinGrid.UltraGridPrintDocument
   Friend WithEvents UltraPrintPreviewDialog1 As Infragistics.Win.Printing.UltraPrintPreviewDialog
   Friend WithEvents sfdExportar As System.Windows.Forms.SaveFileDialog
End Class
