<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ExportarSaldosCtaCteClientesWeb
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
        Dim UltraDataColumn1 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("Fecha")
        Dim UltraDataColumn2 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("IdTipoComprobante")
        Dim UltraDataColumn3 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("TipoComprobante")
        Dim UltraDataColumn4 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("Letra")
        Dim UltraDataColumn5 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("CentroEmisor")
        Dim UltraDataColumn6 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("NumeroComprobante")
        Dim UltraDataColumn7 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("TipoDocCliente")
        Dim UltraDataColumn8 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("NroDocCliente")
        Dim UltraDataColumn9 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("NombreCliente")
        Dim UltraDataColumn10 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("NombreCategoriaFiscal")
        Dim UltraDataColumn11 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("FormaDePago")
        Dim UltraDataColumn12 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("IdProducto")
        Dim UltraDataColumn13 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("NombreProducto")
        Dim UltraDataColumn14 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("NombreMarca")
        Dim UltraDataColumn15 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("NombreRubro")
        Dim UltraDataColumn16 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("NombreSubRubro")
        Dim UltraDataColumn17 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("Cantidad")
        Dim UltraDataColumn18 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("PrecioLista")
        Dim UltraDataColumn19 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("Precio")
        Dim UltraDataColumn20 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("DescuentoRecargoPorc")
        Dim UltraDataColumn21 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("DescuentoRecargoPorc2")
        Dim UltraDataColumn22 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("DescuentoRecargoPorcGral")
        Dim UltraDataColumn23 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("PrecioNeto")
        Dim UltraDataColumn24 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("AlicuotaImpuesto")
        Dim UltraDataColumn25 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("ImporteImpuesto")
        Dim UltraDataColumn26 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("ImporteTotalNeto")
        Dim UltraDataColumn27 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("Usuario")
        Dim Appearance1 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance2 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridBand1 As Infragistics.Win.UltraWinGrid.UltraGridBand = New Infragistics.Win.UltraWinGrid.UltraGridBand("Band 0", -1)
        Dim UltraGridColumn22 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreVendedor")
        Dim UltraGridColumn23 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdCliente")
        Dim UltraGridColumn24 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("CodigoCliente")
        Dim Appearance3 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn25 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreCliente")
        Dim UltraGridColumn26 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreCategoria")
        Dim UltraGridColumn27 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdCobrador")
        Dim UltraGridColumn28 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdEmpleado")
        Dim UltraGridColumn29 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreCobrador")
        Dim UltraGridColumn30 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreEstadoCliente")
        Dim UltraGridColumn31 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Cuit")
        Dim UltraGridColumn32 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreZonaGeografica")
        Dim UltraGridColumn33 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Telefonos")
        Dim UltraGridColumn34 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Total")
        Dim Appearance4 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn35 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Saldo")
        Dim Appearance5 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn36 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("CantDiasPromedio")
        Dim Appearance6 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn37 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("SaldoVencido")
        Dim Appearance7 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn38 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("CantDiasPromedioVencido")
        Dim Appearance8 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn39 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IMPORTE2")
        Dim Appearance9 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn40 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreLocalidad")
        Dim UltraGridColumn43 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdSucursal")
        Dim UltraGridColumn44 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreDeFantasia")
        Dim UltraGridColumn45 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdVendedor")
        Dim UltraGridColumn46 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("FechaInicioSaldo")
        Dim Appearance10 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn1 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Direccion")
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
        Me.grbFiltros = New System.Windows.Forms.GroupBox()
        Me.chbProvincia = New Eniac.Controles.CheckBox()
        Me.cmbProvincia = New Eniac.Controles.ComboBox()
        Me.chbExcluirPreComprobantes = New Eniac.Controles.CheckBox()
        Me.chbExcluirAnticipos = New Eniac.Controles.CheckBox()
        Me.cmbGrupos = New Eniac.Controles.ComboBox()
        Me.chbGrupo = New Eniac.Controles.CheckBox()
        Me.chkExpandAll = New System.Windows.Forms.CheckBox()
        Me.cmbGrabanLibro = New Eniac.Controles.ComboBox()
        Me.lblGrabanLibro = New Eniac.Controles.Label()
        Me.chbCategoria = New Eniac.Controles.CheckBox()
        Me.cmbCategoria = New Eniac.Controles.ComboBox()
        Me.chbExcluirSaldosNegativos = New Eniac.Controles.CheckBox()
        Me.chbZonaGeografica = New Eniac.Controles.CheckBox()
        Me.cmbZonaGeografica = New Eniac.Controles.ComboBox()
        Me.chbVendedor = New Eniac.Controles.CheckBox()
        Me.cmbVendedor = New Eniac.Controles.ComboBox()
        Me.chbCliente = New Eniac.Controles.CheckBox()
        Me.bscCodigoCliente = New Eniac.Controles.Buscador2()
        Me.lblCodigoCliente = New Eniac.Controles.Label()
        Me.bscCliente = New Eniac.Controles.Buscador2()
        Me.lblNombre = New Eniac.Controles.Label()
        Me.btnConsultar = New Eniac.Controles.Button()
        Me.chbFecha = New Eniac.Controles.CheckBox()
        Me.dtpHasta = New Eniac.Controles.DateTimePicker()
        Me.tstBarra = New System.Windows.Forms.ToolStrip()
        Me.tsbRefrescar = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsbImprimir = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsddExportar = New System.Windows.Forms.ToolStripDropDownButton()
        Me.tsmiAExcel = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsmiAPDF = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsbExportar = New System.Windows.Forms.ToolStripButton()
        Me.toolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsbSalir = New System.Windows.Forms.ToolStripButton()
        Me.stsStado = New System.Windows.Forms.StatusStrip()
        Me.tssInfo = New System.Windows.Forms.ToolStripStatusLabel()
        Me.tspBarra = New System.Windows.Forms.ToolStripProgressBar()
        Me.tssRegistros = New System.Windows.Forms.ToolStripStatusLabel()
        Me.UltraDataSource1 = New Infragistics.Win.UltraWinDataSource.UltraDataSource(Me.components)
        Me.UltraPrintPreviewDialog1 = New Infragistics.Win.Printing.UltraPrintPreviewDialog(Me.components)
        Me.UltraGridPrintDocument1 = New Infragistics.Win.UltraWinGrid.UltraGridPrintDocument(Me.components)
        Me.UltraGridExcelExporter1 = New Infragistics.Win.UltraWinGrid.ExcelExport.UltraGridExcelExporter(Me.components)
        Me.UltraGridDocumentExporter1 = New Infragistics.Win.UltraWinGrid.DocumentExport.UltraGridDocumentExporter(Me.components)
        Me.sfdExportar = New System.Windows.Forms.SaveFileDialog()
        Me.btnExaminar = New Eniac.Controles.Button()
        Me.txtArchivoDestino = New Eniac.Controles.TextBox()
        Me.lblArchivoDestino = New Eniac.Controles.Label()
        Me.chbTodos = New Eniac.Controles.CheckBox()
        Me.ugDetalle = New Infragistics.Win.UltraWinGrid.UltraGrid()
        Me.grbFiltros.SuspendLayout()
        Me.tstBarra.SuspendLayout()
        Me.stsStado.SuspendLayout()
        CType(Me.UltraDataSource1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ugDetalle, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'grbFiltros
        '
        Me.grbFiltros.Controls.Add(Me.chbProvincia)
        Me.grbFiltros.Controls.Add(Me.cmbProvincia)
        Me.grbFiltros.Controls.Add(Me.chbExcluirPreComprobantes)
        Me.grbFiltros.Controls.Add(Me.chbExcluirAnticipos)
        Me.grbFiltros.Controls.Add(Me.cmbGrupos)
        Me.grbFiltros.Controls.Add(Me.chbGrupo)
        Me.grbFiltros.Controls.Add(Me.chkExpandAll)
        Me.grbFiltros.Controls.Add(Me.cmbGrabanLibro)
        Me.grbFiltros.Controls.Add(Me.lblGrabanLibro)
        Me.grbFiltros.Controls.Add(Me.chbCategoria)
        Me.grbFiltros.Controls.Add(Me.cmbCategoria)
        Me.grbFiltros.Controls.Add(Me.chbExcluirSaldosNegativos)
        Me.grbFiltros.Controls.Add(Me.chbZonaGeografica)
        Me.grbFiltros.Controls.Add(Me.cmbZonaGeografica)
        Me.grbFiltros.Controls.Add(Me.chbVendedor)
        Me.grbFiltros.Controls.Add(Me.cmbVendedor)
        Me.grbFiltros.Controls.Add(Me.chbCliente)
        Me.grbFiltros.Controls.Add(Me.bscCodigoCliente)
        Me.grbFiltros.Controls.Add(Me.bscCliente)
        Me.grbFiltros.Controls.Add(Me.lblCodigoCliente)
        Me.grbFiltros.Controls.Add(Me.lblNombre)
        Me.grbFiltros.Controls.Add(Me.btnConsultar)
        Me.grbFiltros.Controls.Add(Me.chbFecha)
        Me.grbFiltros.Controls.Add(Me.dtpHasta)
        Me.grbFiltros.Location = New System.Drawing.Point(7, 38)
        Me.grbFiltros.Name = "grbFiltros"
        Me.grbFiltros.Size = New System.Drawing.Size(868, 135)
        Me.grbFiltros.TabIndex = 0
        Me.grbFiltros.TabStop = False
        Me.grbFiltros.Text = "Filtros"
        '
        'chbProvincia
        '
        Me.chbProvincia.AutoSize = True
        Me.chbProvincia.BindearPropiedadControl = Nothing
        Me.chbProvincia.BindearPropiedadEntidad = Nothing
        Me.chbProvincia.ForeColorFocus = System.Drawing.Color.Red
        Me.chbProvincia.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbProvincia.IsPK = False
        Me.chbProvincia.IsRequired = False
        Me.chbProvincia.Key = Nothing
        Me.chbProvincia.LabelAsoc = Nothing
        Me.chbProvincia.Location = New System.Drawing.Point(670, 60)
        Me.chbProvincia.Name = "chbProvincia"
        Me.chbProvincia.Size = New System.Drawing.Size(70, 17)
        Me.chbProvincia.TabIndex = 6
        Me.chbProvincia.Text = "Provincia"
        Me.chbProvincia.UseVisualStyleBackColor = True
        '
        'cmbProvincia
        '
        Me.cmbProvincia.BindearPropiedadControl = "SelectedValue"
        Me.cmbProvincia.BindearPropiedadEntidad = "IdProvincia"
        Me.cmbProvincia.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbProvincia.Enabled = False
        Me.cmbProvincia.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbProvincia.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbProvincia.FormattingEnabled = True
        Me.cmbProvincia.IsPK = False
        Me.cmbProvincia.IsRequired = True
        Me.cmbProvincia.Key = Nothing
        Me.cmbProvincia.LabelAsoc = Nothing
        Me.cmbProvincia.Location = New System.Drawing.Point(744, 58)
        Me.cmbProvincia.Name = "cmbProvincia"
        Me.cmbProvincia.Size = New System.Drawing.Size(118, 21)
        Me.cmbProvincia.TabIndex = 21
        '
        'chbExcluirPreComprobantes
        '
        Me.chbExcluirPreComprobantes.AutoSize = True
        Me.chbExcluirPreComprobantes.BindearPropiedadControl = Nothing
        Me.chbExcluirPreComprobantes.BindearPropiedadEntidad = Nothing
        Me.chbExcluirPreComprobantes.ForeColorFocus = System.Drawing.Color.Red
        Me.chbExcluirPreComprobantes.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbExcluirPreComprobantes.IsPK = False
        Me.chbExcluirPreComprobantes.IsRequired = False
        Me.chbExcluirPreComprobantes.Key = Nothing
        Me.chbExcluirPreComprobantes.LabelAsoc = Nothing
        Me.chbExcluirPreComprobantes.Location = New System.Drawing.Point(465, 114)
        Me.chbExcluirPreComprobantes.Name = "chbExcluirPreComprobantes"
        Me.chbExcluirPreComprobantes.Size = New System.Drawing.Size(147, 17)
        Me.chbExcluirPreComprobantes.TabIndex = 10
        Me.chbExcluirPreComprobantes.Text = "Excluir Pre-Comprobantes"
        Me.chbExcluirPreComprobantes.UseVisualStyleBackColor = True
        '
        'chbExcluirAnticipos
        '
        Me.chbExcluirAnticipos.AutoSize = True
        Me.chbExcluirAnticipos.BindearPropiedadControl = Nothing
        Me.chbExcluirAnticipos.BindearPropiedadEntidad = Nothing
        Me.chbExcluirAnticipos.ForeColorFocus = System.Drawing.Color.Red
        Me.chbExcluirAnticipos.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbExcluirAnticipos.IsPK = False
        Me.chbExcluirAnticipos.IsRequired = False
        Me.chbExcluirAnticipos.Key = Nothing
        Me.chbExcluirAnticipos.LabelAsoc = Nothing
        Me.chbExcluirAnticipos.Location = New System.Drawing.Point(465, 60)
        Me.chbExcluirAnticipos.Name = "chbExcluirAnticipos"
        Me.chbExcluirAnticipos.Size = New System.Drawing.Size(103, 17)
        Me.chbExcluirAnticipos.TabIndex = 5
        Me.chbExcluirAnticipos.Text = "Excluir Anticipos"
        Me.chbExcluirAnticipos.UseVisualStyleBackColor = True
        '
        'cmbGrupos
        '
        Me.cmbGrupos.BindearPropiedadControl = Nothing
        Me.cmbGrupos.BindearPropiedadEntidad = Nothing
        Me.cmbGrupos.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbGrupos.Enabled = False
        Me.cmbGrupos.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.cmbGrupos.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbGrupos.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbGrupos.FormattingEnabled = True
        Me.cmbGrupos.IsPK = False
        Me.cmbGrupos.IsRequired = False
        Me.cmbGrupos.ItemHeight = 13
        Me.cmbGrupos.Key = Nothing
        Me.cmbGrupos.LabelAsoc = Nothing
        Me.cmbGrupos.Location = New System.Drawing.Point(340, 65)
        Me.cmbGrupos.Name = "cmbGrupos"
        Me.cmbGrupos.Size = New System.Drawing.Size(107, 21)
        Me.cmbGrupos.TabIndex = 20
        '
        'chbGrupo
        '
        Me.chbGrupo.AutoSize = True
        Me.chbGrupo.BindearPropiedadControl = Nothing
        Me.chbGrupo.BindearPropiedadEntidad = Nothing
        Me.chbGrupo.ForeColorFocus = System.Drawing.Color.Red
        Me.chbGrupo.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbGrupo.IsPK = False
        Me.chbGrupo.IsRequired = False
        Me.chbGrupo.Key = Nothing
        Me.chbGrupo.LabelAsoc = Nothing
        Me.chbGrupo.Location = New System.Drawing.Point(269, 67)
        Me.chbGrupo.Name = "chbGrupo"
        Me.chbGrupo.Size = New System.Drawing.Size(55, 17)
        Me.chbGrupo.TabIndex = 4
        Me.chbGrupo.Text = "Grupo"
        Me.chbGrupo.UseVisualStyleBackColor = True
        '
        'chkExpandAll
        '
        Me.chkExpandAll.Enabled = False
        Me.chkExpandAll.Location = New System.Drawing.Point(636, 108)
        Me.chkExpandAll.Name = "chkExpandAll"
        Me.chkExpandAll.Size = New System.Drawing.Size(104, 15)
        Me.chkExpandAll.TabIndex = 11
        Me.chkExpandAll.Text = "Expandir Grupos"
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
        Me.cmbGrabanLibro.Location = New System.Drawing.Point(340, 102)
        Me.cmbGrabanLibro.Name = "cmbGrabanLibro"
        Me.cmbGrabanLibro.Size = New System.Drawing.Size(107, 21)
        Me.cmbGrabanLibro.TabIndex = 8
        '
        'lblGrabanLibro
        '
        Me.lblGrabanLibro.AutoSize = True
        Me.lblGrabanLibro.LabelAsoc = Nothing
        Me.lblGrabanLibro.Location = New System.Drawing.Point(263, 106)
        Me.lblGrabanLibro.Name = "lblGrabanLibro"
        Me.lblGrabanLibro.Size = New System.Drawing.Size(68, 13)
        Me.lblGrabanLibro.TabIndex = 23
        Me.lblGrabanLibro.Text = "Graban Libro"
        '
        'chbCategoria
        '
        Me.chbCategoria.AutoSize = True
        Me.chbCategoria.BindearPropiedadControl = Nothing
        Me.chbCategoria.BindearPropiedadEntidad = Nothing
        Me.chbCategoria.ForeColorFocus = System.Drawing.Color.Red
        Me.chbCategoria.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbCategoria.IsPK = False
        Me.chbCategoria.IsRequired = False
        Me.chbCategoria.Key = Nothing
        Me.chbCategoria.LabelAsoc = Nothing
        Me.chbCategoria.Location = New System.Drawing.Point(670, 31)
        Me.chbCategoria.Name = "chbCategoria"
        Me.chbCategoria.Size = New System.Drawing.Size(71, 17)
        Me.chbCategoria.TabIndex = 2
        Me.chbCategoria.Text = "Categoria"
        Me.chbCategoria.UseVisualStyleBackColor = True
        '
        'cmbCategoria
        '
        Me.cmbCategoria.BindearPropiedadControl = "SelectedValue"
        Me.cmbCategoria.BindearPropiedadEntidad = "Categoria.IdCategoria"
        Me.cmbCategoria.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbCategoria.Enabled = False
        Me.cmbCategoria.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbCategoria.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbCategoria.FormattingEnabled = True
        Me.cmbCategoria.IsPK = False
        Me.cmbCategoria.IsRequired = True
        Me.cmbCategoria.Key = Nothing
        Me.cmbCategoria.LabelAsoc = Nothing
        Me.cmbCategoria.Location = New System.Drawing.Point(744, 29)
        Me.cmbCategoria.Name = "cmbCategoria"
        Me.cmbCategoria.Size = New System.Drawing.Size(118, 21)
        Me.cmbCategoria.TabIndex = 18
        '
        'chbExcluirSaldosNegativos
        '
        Me.chbExcluirSaldosNegativos.AutoSize = True
        Me.chbExcluirSaldosNegativos.BindearPropiedadControl = Nothing
        Me.chbExcluirSaldosNegativos.BindearPropiedadEntidad = Nothing
        Me.chbExcluirSaldosNegativos.ForeColorFocus = System.Drawing.Color.Red
        Me.chbExcluirSaldosNegativos.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbExcluirSaldosNegativos.IsPK = False
        Me.chbExcluirSaldosNegativos.IsRequired = False
        Me.chbExcluirSaldosNegativos.Key = Nothing
        Me.chbExcluirSaldosNegativos.LabelAsoc = Nothing
        Me.chbExcluirSaldosNegativos.Location = New System.Drawing.Point(465, 88)
        Me.chbExcluirSaldosNegativos.Name = "chbExcluirSaldosNegativos"
        Me.chbExcluirSaldosNegativos.Size = New System.Drawing.Size(143, 17)
        Me.chbExcluirSaldosNegativos.TabIndex = 9
        Me.chbExcluirSaldosNegativos.Text = "Excluir Saldos Negativos"
        Me.chbExcluirSaldosNegativos.UseVisualStyleBackColor = True
        '
        'chbZonaGeografica
        '
        Me.chbZonaGeografica.AutoSize = True
        Me.chbZonaGeografica.BindearPropiedadControl = Nothing
        Me.chbZonaGeografica.BindearPropiedadEntidad = Nothing
        Me.chbZonaGeografica.ForeColorFocus = System.Drawing.Color.Red
        Me.chbZonaGeografica.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbZonaGeografica.IsPK = False
        Me.chbZonaGeografica.IsRequired = False
        Me.chbZonaGeografica.Key = Nothing
        Me.chbZonaGeografica.LabelAsoc = Nothing
        Me.chbZonaGeografica.Location = New System.Drawing.Point(16, 67)
        Me.chbZonaGeografica.Name = "chbZonaGeografica"
        Me.chbZonaGeografica.Size = New System.Drawing.Size(106, 17)
        Me.chbZonaGeografica.TabIndex = 3
        Me.chbZonaGeografica.Text = "Zona Geográfica"
        Me.chbZonaGeografica.UseVisualStyleBackColor = True
        '
        'cmbZonaGeografica
        '
        Me.cmbZonaGeografica.BindearPropiedadControl = Nothing
        Me.cmbZonaGeografica.BindearPropiedadEntidad = Nothing
        Me.cmbZonaGeografica.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbZonaGeografica.Enabled = False
        Me.cmbZonaGeografica.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbZonaGeografica.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbZonaGeografica.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbZonaGeografica.FormattingEnabled = True
        Me.cmbZonaGeografica.IsPK = False
        Me.cmbZonaGeografica.IsRequired = False
        Me.cmbZonaGeografica.Key = Nothing
        Me.cmbZonaGeografica.LabelAsoc = Nothing
        Me.cmbZonaGeografica.Location = New System.Drawing.Point(126, 63)
        Me.cmbZonaGeografica.Name = "cmbZonaGeografica"
        Me.cmbZonaGeografica.Size = New System.Drawing.Size(119, 21)
        Me.cmbZonaGeografica.TabIndex = 19
        '
        'chbVendedor
        '
        Me.chbVendedor.AutoSize = True
        Me.chbVendedor.BindearPropiedadControl = Nothing
        Me.chbVendedor.BindearPropiedadEntidad = Nothing
        Me.chbVendedor.ForeColorFocus = System.Drawing.Color.Red
        Me.chbVendedor.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbVendedor.IsPK = False
        Me.chbVendedor.IsRequired = False
        Me.chbVendedor.Key = Nothing
        Me.chbVendedor.LabelAsoc = Nothing
        Me.chbVendedor.Location = New System.Drawing.Point(16, 106)
        Me.chbVendedor.Name = "chbVendedor"
        Me.chbVendedor.Size = New System.Drawing.Size(72, 17)
        Me.chbVendedor.TabIndex = 7
        Me.chbVendedor.Text = "Vendedor"
        Me.chbVendedor.UseVisualStyleBackColor = True
        '
        'cmbVendedor
        '
        Me.cmbVendedor.BindearPropiedadControl = Nothing
        Me.cmbVendedor.BindearPropiedadEntidad = Nothing
        Me.cmbVendedor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbVendedor.Enabled = False
        Me.cmbVendedor.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbVendedor.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbVendedor.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbVendedor.FormattingEnabled = True
        Me.cmbVendedor.IsPK = False
        Me.cmbVendedor.IsRequired = False
        Me.cmbVendedor.Key = Nothing
        Me.cmbVendedor.LabelAsoc = Nothing
        Me.cmbVendedor.Location = New System.Drawing.Point(126, 102)
        Me.cmbVendedor.Name = "cmbVendedor"
        Me.cmbVendedor.Size = New System.Drawing.Size(119, 21)
        Me.cmbVendedor.TabIndex = 22
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
        Me.chbCliente.Location = New System.Drawing.Point(224, 28)
        Me.chbCliente.Name = "chbCliente"
        Me.chbCliente.Size = New System.Drawing.Size(58, 17)
        Me.chbCliente.TabIndex = 1
        Me.chbCliente.Text = "Cliente"
        Me.chbCliente.UseVisualStyleBackColor = True
        '
        'bscCodigoCliente
        '
        Me.bscCodigoCliente.ActivarFiltroEnGrilla = True
        Me.bscCodigoCliente.BindearPropiedadControl = Nothing
        Me.bscCodigoCliente.BindearPropiedadEntidad = Nothing
        Me.bscCodigoCliente.ConfigBuscador = Nothing
        Me.bscCodigoCliente.Datos = Nothing
        Me.bscCodigoCliente.Enabled = False
        Me.bscCodigoCliente.FilaDevuelta = Nothing
        Me.bscCodigoCliente.ForeColorFocus = System.Drawing.Color.Red
        Me.bscCodigoCliente.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.bscCodigoCliente.IsDecimal = False
        Me.bscCodigoCliente.IsNumber = True
        Me.bscCodigoCliente.IsPK = False
        Me.bscCodigoCliente.IsRequired = False
        Me.bscCodigoCliente.Key = ""
        Me.bscCodigoCliente.LabelAsoc = Me.lblCodigoCliente
        Me.bscCodigoCliente.Location = New System.Drawing.Point(285, 28)
        Me.bscCodigoCliente.MaxLengh = "32767"
        Me.bscCodigoCliente.Name = "bscCodigoCliente"
        Me.bscCodigoCliente.Permitido = True
        Me.bscCodigoCliente.PermitidoNoBackColor = System.Drawing.Color.FromArgb(CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer))
        Me.bscCodigoCliente.PermitidoNoForeColor = System.Drawing.Color.Black
        Me.bscCodigoCliente.PermitidoSiBackColor = System.Drawing.Color.White
        Me.bscCodigoCliente.PermitidoSiForeColor = System.Drawing.Color.Black
        Me.bscCodigoCliente.Selecciono = False
        Me.bscCodigoCliente.Size = New System.Drawing.Size(90, 23)
        Me.bscCodigoCliente.TabIndex = 15
        '
        'lblCodigoCliente
        '
        Me.lblCodigoCliente.AutoSize = True
        Me.lblCodigoCliente.LabelAsoc = Nothing
        Me.lblCodigoCliente.Location = New System.Drawing.Point(282, 12)
        Me.lblCodigoCliente.Name = "lblCodigoCliente"
        Me.lblCodigoCliente.Size = New System.Drawing.Size(40, 13)
        Me.lblCodigoCliente.TabIndex = 14
        Me.lblCodigoCliente.Text = "Código"
        '
        'bscCliente
        '
        Me.bscCliente.ActivarFiltroEnGrilla = True
        Me.bscCliente.AutoSize = True
        Me.bscCliente.BindearPropiedadControl = Nothing
        Me.bscCliente.BindearPropiedadEntidad = Nothing
        Me.bscCliente.ConfigBuscador = Nothing
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
        Me.bscCliente.Location = New System.Drawing.Point(377, 28)
        Me.bscCliente.Margin = New System.Windows.Forms.Padding(4)
        Me.bscCliente.MaxLengh = "32767"
        Me.bscCliente.Name = "bscCliente"
        Me.bscCliente.Permitido = True
        Me.bscCliente.PermitidoNoBackColor = System.Drawing.Color.FromArgb(CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer))
        Me.bscCliente.PermitidoNoForeColor = System.Drawing.Color.Black
        Me.bscCliente.PermitidoSiBackColor = System.Drawing.Color.White
        Me.bscCliente.PermitidoSiForeColor = System.Drawing.Color.Black
        Me.bscCliente.Selecciono = False
        Me.bscCliente.Size = New System.Drawing.Size(275, 23)
        Me.bscCliente.TabIndex = 17
        '
        'lblNombre
        '
        Me.lblNombre.AutoSize = True
        Me.lblNombre.LabelAsoc = Nothing
        Me.lblNombre.Location = New System.Drawing.Point(379, 12)
        Me.lblNombre.Name = "lblNombre"
        Me.lblNombre.Size = New System.Drawing.Size(44, 13)
        Me.lblNombre.TabIndex = 16
        Me.lblNombre.Text = "Nombre"
        '
        'btnConsultar
        '
        Me.btnConsultar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnConsultar.Image = Global.Eniac.Win.My.Resources.Resources.view
        Me.btnConsultar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnConsultar.Location = New System.Drawing.Point(762, 85)
        Me.btnConsultar.Name = "btnConsultar"
        Me.btnConsultar.Size = New System.Drawing.Size(100, 45)
        Me.btnConsultar.TabIndex = 12
        Me.btnConsultar.Text = "&Consultar"
        Me.btnConsultar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnConsultar.UseVisualStyleBackColor = True
        '
        'chbFecha
        '
        Me.chbFecha.AutoSize = True
        Me.chbFecha.BindearPropiedadControl = Nothing
        Me.chbFecha.BindearPropiedadEntidad = Nothing
        Me.chbFecha.ForeColorFocus = System.Drawing.Color.Red
        Me.chbFecha.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbFecha.IsPK = False
        Me.chbFecha.IsRequired = False
        Me.chbFecha.Key = Nothing
        Me.chbFecha.LabelAsoc = Nothing
        Me.chbFecha.Location = New System.Drawing.Point(16, 28)
        Me.chbFecha.Name = "chbFecha"
        Me.chbFecha.Size = New System.Drawing.Size(87, 17)
        Me.chbFecha.TabIndex = 0
        Me.chbFecha.Text = "Fecha Hasta"
        Me.chbFecha.UseVisualStyleBackColor = True
        '
        'dtpHasta
        '
        Me.dtpHasta.BindearPropiedadControl = Nothing
        Me.dtpHasta.BindearPropiedadEntidad = Nothing
        Me.dtpHasta.CustomFormat = "dd/MM/yyyy"
        Me.dtpHasta.Enabled = False
        Me.dtpHasta.ForeColorFocus = System.Drawing.Color.Red
        Me.dtpHasta.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.dtpHasta.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpHasta.IsPK = False
        Me.dtpHasta.IsRequired = False
        Me.dtpHasta.Key = ""
        Me.dtpHasta.LabelAsoc = Nothing
        Me.dtpHasta.Location = New System.Drawing.Point(109, 26)
        Me.dtpHasta.Name = "dtpHasta"
        Me.dtpHasta.Size = New System.Drawing.Size(95, 20)
        Me.dtpHasta.TabIndex = 13
        '
        'tstBarra
        '
        Me.tstBarra.AllowItemReorder = True
        Me.tstBarra.ImageScalingSize = New System.Drawing.Size(22, 22)
        Me.tstBarra.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsbRefrescar, Me.ToolStripSeparator2, Me.tsbImprimir, Me.ToolStripSeparator1, Me.tsddExportar, Me.ToolStripSeparator4, Me.tsbExportar, Me.toolStripSeparator3, Me.tsbSalir})
        Me.tstBarra.Location = New System.Drawing.Point(0, 0)
        Me.tstBarra.Name = "tstBarra"
        Me.tstBarra.Size = New System.Drawing.Size(884, 29)
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
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 29)
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
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 29)
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
        'ToolStripSeparator4
        '
        Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
        Me.ToolStripSeparator4.Size = New System.Drawing.Size(6, 29)
        '
        'tsbExportar
        '
        Me.tsbExportar.Enabled = False
        Me.tsbExportar.Image = Global.Eniac.Win.My.Resources.Resources.export_database_save_32
        Me.tsbExportar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbExportar.Name = "tsbExportar"
        Me.tsbExportar.Size = New System.Drawing.Size(118, 26)
        Me.tsbExportar.Text = "&Generar Archivo"
        Me.tsbExportar.ToolTipText = "Imprimir"
        '
        'toolStripSeparator3
        '
        Me.toolStripSeparator3.Name = "toolStripSeparator3"
        Me.toolStripSeparator3.Size = New System.Drawing.Size(6, 29)
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
        'stsStado
        '
        Me.stsStado.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tssInfo, Me.tspBarra, Me.tssRegistros})
        Me.stsStado.Location = New System.Drawing.Point(0, 544)
        Me.stsStado.Name = "stsStado"
        Me.stsStado.Size = New System.Drawing.Size(884, 22)
        Me.stsStado.TabIndex = 2
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
        'UltraDataSource1
        '
        Me.UltraDataSource1.Band.Columns.AddRange(New Object() {UltraDataColumn1, UltraDataColumn2, UltraDataColumn3, UltraDataColumn4, UltraDataColumn5, UltraDataColumn6, UltraDataColumn7, UltraDataColumn8, UltraDataColumn9, UltraDataColumn10, UltraDataColumn11, UltraDataColumn12, UltraDataColumn13, UltraDataColumn14, UltraDataColumn15, UltraDataColumn16, UltraDataColumn17, UltraDataColumn18, UltraDataColumn19, UltraDataColumn20, UltraDataColumn21, UltraDataColumn22, UltraDataColumn23, UltraDataColumn24, UltraDataColumn25, UltraDataColumn26, UltraDataColumn27})
        '
        'UltraPrintPreviewDialog1
        '
        Me.UltraPrintPreviewDialog1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.UltraPrintPreviewDialog1.Name = "UltraPrintPreviewDialog1"
        '
        'UltraGridPrintDocument1
        '
        Me.UltraGridPrintDocument1.DocumentName = "Informe"
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
        'btnExaminar
        '
        Me.btnExaminar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnExaminar.Image = Global.Eniac.Win.My.Resources.Resources.folder_32
        Me.btnExaminar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnExaminar.Location = New System.Drawing.Point(581, 497)
        Me.btnExaminar.Name = "btnExaminar"
        Me.btnExaminar.Size = New System.Drawing.Size(98, 40)
        Me.btnExaminar.TabIndex = 29
        Me.btnExaminar.Text = "&Examinar..."
        Me.btnExaminar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnExaminar.UseVisualStyleBackColor = True
        '
        'txtArchivoDestino
        '
        Me.txtArchivoDestino.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.txtArchivoDestino.BindearPropiedadControl = ""
        Me.txtArchivoDestino.BindearPropiedadEntidad = ""
        Me.txtArchivoDestino.ForeColorFocus = System.Drawing.Color.Red
        Me.txtArchivoDestino.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtArchivoDestino.Formato = ""
        Me.txtArchivoDestino.IsDecimal = False
        Me.txtArchivoDestino.IsNumber = False
        Me.txtArchivoDestino.IsPK = False
        Me.txtArchivoDestino.IsRequired = False
        Me.txtArchivoDestino.Key = ""
        Me.txtArchivoDestino.LabelAsoc = Me.lblArchivoDestino
        Me.txtArchivoDestino.Location = New System.Drawing.Point(101, 509)
        Me.txtArchivoDestino.Name = "txtArchivoDestino"
        Me.txtArchivoDestino.Size = New System.Drawing.Size(463, 20)
        Me.txtArchivoDestino.TabIndex = 28
        '
        'lblArchivoDestino
        '
        Me.lblArchivoDestino.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblArchivoDestino.AutoSize = True
        Me.lblArchivoDestino.LabelAsoc = Nothing
        Me.lblArchivoDestino.Location = New System.Drawing.Point(10, 512)
        Me.lblArchivoDestino.Name = "lblArchivoDestino"
        Me.lblArchivoDestino.Size = New System.Drawing.Size(85, 13)
        Me.lblArchivoDestino.TabIndex = 27
        Me.lblArchivoDestino.Text = "Archivo Destino:"
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
        Me.chbTodos.Location = New System.Drawing.Point(7, 179)
        Me.chbTodos.Name = "chbTodos"
        Me.chbTodos.Size = New System.Drawing.Size(122, 24)
        Me.chbTodos.TabIndex = 30
        Me.chbTodos.Text = "Chequear todos"
        Me.chbTodos.UseVisualStyleBackColor = True
        '
        'ugDetalle
        '
        Me.ugDetalle.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Appearance2.BackColor = System.Drawing.SystemColors.Window
        Appearance2.BorderColor = System.Drawing.SystemColors.InactiveCaption
        Me.ugDetalle.DisplayLayout.Appearance = Appearance2
        UltraGridColumn22.Header.Caption = "Vendedor"
        UltraGridColumn22.Header.VisiblePosition = 1
        UltraGridColumn22.Width = 117
        UltraGridColumn23.Header.VisiblePosition = 18
        UltraGridColumn23.Hidden = True
        Appearance3.TextHAlignAsString = "Right"
        UltraGridColumn24.CellAppearance = Appearance3
        UltraGridColumn24.Header.Caption = "Codigo"
        UltraGridColumn24.Header.VisiblePosition = 2
        UltraGridColumn24.Width = 65
        UltraGridColumn25.Header.Caption = "Cliente"
        UltraGridColumn25.Header.VisiblePosition = 3
        UltraGridColumn25.Width = 138
        UltraGridColumn26.Header.Caption = "Categoria"
        UltraGridColumn26.Header.VisiblePosition = 8
        UltraGridColumn26.Width = 86
        UltraGridColumn27.Header.VisiblePosition = 5
        UltraGridColumn27.Hidden = True
        UltraGridColumn28.Header.VisiblePosition = 6
        UltraGridColumn28.Hidden = True
        UltraGridColumn29.Header.Caption = "Cobrador"
        UltraGridColumn29.Header.VisiblePosition = 23
        UltraGridColumn30.Header.Caption = "Estado"
        UltraGridColumn30.Header.VisiblePosition = 9
        UltraGridColumn30.Hidden = True
        UltraGridColumn30.Width = 101
        UltraGridColumn31.Header.VisiblePosition = 7
        UltraGridColumn31.Width = 84
        UltraGridColumn32.Header.Caption = "Zona Geograf."
        UltraGridColumn32.Header.VisiblePosition = 11
        UltraGridColumn32.Hidden = True
        UltraGridColumn32.Width = 83
        UltraGridColumn33.Header.Caption = "Telefono(s)"
        UltraGridColumn33.Header.VisiblePosition = 12
        UltraGridColumn33.Width = 122
        Appearance4.TextHAlignAsString = "Right"
        UltraGridColumn34.CellAppearance = Appearance4
        UltraGridColumn34.Format = "N2"
        UltraGridColumn34.Header.VisiblePosition = 16
        UltraGridColumn34.Hidden = True
        UltraGridColumn34.Width = 90
        Appearance5.TextHAlignAsString = "Right"
        UltraGridColumn35.CellAppearance = Appearance5
        UltraGridColumn35.Format = "N2"
        UltraGridColumn35.Header.VisiblePosition = 14
        UltraGridColumn35.MinWidth = 90
        UltraGridColumn35.Width = 102
        Appearance6.TextHAlignAsString = "Right"
        UltraGridColumn36.CellAppearance = Appearance6
        UltraGridColumn36.Format = "N0"
        UltraGridColumn36.Header.Caption = "D.Pr."
        UltraGridColumn36.Header.VisiblePosition = 17
        UltraGridColumn36.Width = 31
        Appearance7.TextHAlignAsString = "Right"
        UltraGridColumn37.CellAppearance = Appearance7
        UltraGridColumn37.Format = "N2"
        UltraGridColumn37.Header.Caption = "Vencido"
        UltraGridColumn37.Header.VisiblePosition = 15
        UltraGridColumn37.MinWidth = 90
        UltraGridColumn37.Width = 102
        Appearance8.TextHAlignAsString = "Right"
        UltraGridColumn38.CellAppearance = Appearance8
        UltraGridColumn38.Format = "N0"
        UltraGridColumn38.Header.Caption = "D.P.V."
        UltraGridColumn38.Header.VisiblePosition = 20
        UltraGridColumn38.Width = 32
        Appearance9.TextHAlignAsString = "Right"
        UltraGridColumn39.CellAppearance = Appearance9
        UltraGridColumn39.Format = "N2"
        UltraGridColumn39.Header.Caption = "Cheques"
        UltraGridColumn39.Header.VisiblePosition = 13
        UltraGridColumn39.MinWidth = 90
        UltraGridColumn39.Width = 102
        UltraGridColumn40.Header.Caption = "Localidad"
        UltraGridColumn40.Header.VisiblePosition = 10
        UltraGridColumn40.Hidden = True
        UltraGridColumn40.Width = 101
        UltraGridColumn43.Header.Caption = "S."
        UltraGridColumn43.Header.VisiblePosition = 0
        UltraGridColumn43.Hidden = True
        UltraGridColumn43.MinWidth = 25
        UltraGridColumn43.Width = 25
        UltraGridColumn44.Header.Caption = "Cliente (N. de Fantasía)"
        UltraGridColumn44.Header.VisiblePosition = 4
        UltraGridColumn44.Hidden = True
        UltraGridColumn45.Header.VisiblePosition = 19
        UltraGridColumn45.Hidden = True
        UltraGridColumn46.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        Appearance10.TextHAlignAsString = "Center"
        UltraGridColumn46.CellAppearance = Appearance10
        UltraGridColumn46.Format = "dd/MM/yyyy"
        UltraGridColumn46.Header.Caption = "F. Inicio Saldo"
        UltraGridColumn46.Header.VisiblePosition = 21
        UltraGridColumn46.Width = 85
        UltraGridColumn1.Header.Caption = "Dirección"
        UltraGridColumn1.Header.VisiblePosition = 22
        UltraGridBand1.Columns.AddRange(New Object() {UltraGridColumn22, UltraGridColumn23, UltraGridColumn24, UltraGridColumn25, UltraGridColumn26, UltraGridColumn27, UltraGridColumn28, UltraGridColumn29, UltraGridColumn30, UltraGridColumn31, UltraGridColumn32, UltraGridColumn33, UltraGridColumn34, UltraGridColumn35, UltraGridColumn36, UltraGridColumn37, UltraGridColumn38, UltraGridColumn39, UltraGridColumn40, UltraGridColumn43, UltraGridColumn44, UltraGridColumn45, UltraGridColumn46, UltraGridColumn1})
        Me.ugDetalle.DisplayLayout.BandsSerializer.Add(UltraGridBand1)
        Me.ugDetalle.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.ugDetalle.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.[False]
        Appearance11.BackColor = System.Drawing.SystemColors.ActiveBorder
        Appearance11.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance11.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Appearance11.BorderColor = System.Drawing.SystemColors.Window
        Me.ugDetalle.DisplayLayout.GroupByBox.Appearance = Appearance11
        Appearance12.ForeColor = System.Drawing.SystemColors.GrayText
        Me.ugDetalle.DisplayLayout.GroupByBox.BandLabelAppearance = Appearance12
        Me.ugDetalle.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.ugDetalle.DisplayLayout.GroupByBox.Prompt = "Arrastre un título de columna aquí para agrupar."
        Appearance13.BackColor = System.Drawing.SystemColors.ControlLightLight
        Appearance13.BackColor2 = System.Drawing.SystemColors.Control
        Appearance13.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance13.ForeColor = System.Drawing.SystemColors.GrayText
        Me.ugDetalle.DisplayLayout.GroupByBox.PromptAppearance = Appearance13
        Me.ugDetalle.DisplayLayout.MaxColScrollRegions = 1
        Me.ugDetalle.DisplayLayout.MaxRowScrollRegions = 1
        Appearance14.BackColor = System.Drawing.SystemColors.Window
        Appearance14.ForeColor = System.Drawing.SystemColors.ControlText
        Me.ugDetalle.DisplayLayout.Override.ActiveCellAppearance = Appearance14
        Appearance15.BackColor = System.Drawing.SystemColors.Highlight
        Appearance15.ForeColor = System.Drawing.SystemColors.HighlightText
        Me.ugDetalle.DisplayLayout.Override.ActiveRowAppearance = Appearance15
        Me.ugDetalle.DisplayLayout.Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.No
        Me.ugDetalle.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.[False]
        Me.ugDetalle.DisplayLayout.Override.AllowUpdate = Infragistics.Win.DefaultableBoolean.[False]
        Me.ugDetalle.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted
        Me.ugDetalle.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted
        Appearance16.BackColor = System.Drawing.SystemColors.Window
        Me.ugDetalle.DisplayLayout.Override.CardAreaAppearance = Appearance16
        Appearance17.BorderColor = System.Drawing.Color.Silver
        Appearance17.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter
        Me.ugDetalle.DisplayLayout.Override.CellAppearance = Appearance17
        Me.ugDetalle.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText
        Me.ugDetalle.DisplayLayout.Override.CellPadding = 0
        Appearance18.BackColor = System.Drawing.SystemColors.Control
        Appearance18.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance18.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element
        Appearance18.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance18.BorderColor = System.Drawing.SystemColors.Window
        Me.ugDetalle.DisplayLayout.Override.GroupByRowAppearance = Appearance18
        Appearance19.TextHAlignAsString = "Left"
        Me.ugDetalle.DisplayLayout.Override.HeaderAppearance = Appearance19
        Me.ugDetalle.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand
        Appearance20.BackColor = System.Drawing.SystemColors.Window
        Appearance20.BorderColor = System.Drawing.Color.Silver
        Me.ugDetalle.DisplayLayout.Override.RowAppearance = Appearance20
        Me.ugDetalle.DisplayLayout.Override.RowSelectorHeaderStyle = Infragistics.Win.UltraWinGrid.RowSelectorHeaderStyle.None
        Me.ugDetalle.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[False]
        Appearance21.BackColor = System.Drawing.SystemColors.ControlLight
        Me.ugDetalle.DisplayLayout.Override.TemplateAddRowAppearance = Appearance21
        Me.ugDetalle.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill
        Me.ugDetalle.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate
        Me.ugDetalle.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy
        Me.ugDetalle.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ugDetalle.Location = New System.Drawing.Point(7, 209)
        Me.ugDetalle.Name = "ugDetalle"
        Me.ugDetalle.Size = New System.Drawing.Size(868, 287)
        Me.ugDetalle.TabIndex = 31
        '
        'ExportarSaldosCtaCteClientesWeb
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(884, 566)
        Me.Controls.Add(Me.ugDetalle)
        Me.Controls.Add(Me.chbTodos)
        Me.Controls.Add(Me.btnExaminar)
        Me.Controls.Add(Me.txtArchivoDestino)
        Me.Controls.Add(Me.lblArchivoDestino)
        Me.Controls.Add(Me.stsStado)
        Me.Controls.Add(Me.tstBarra)
        Me.Controls.Add(Me.grbFiltros)
        Me.KeyPreview = True
        Me.Name = "ExportarSaldosCtaCteClientesWeb"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Exportar Saldos de Cta. Cte. de Clientes a Web"
        Me.grbFiltros.ResumeLayout(False)
        Me.grbFiltros.PerformLayout()
        Me.tstBarra.ResumeLayout(False)
        Me.tstBarra.PerformLayout()
        Me.stsStado.ResumeLayout(False)
        Me.stsStado.PerformLayout()
        CType(Me.UltraDataSource1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ugDetalle, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents grbFiltros As System.Windows.Forms.GroupBox
   Public WithEvents tstBarra As System.Windows.Forms.ToolStrip
   Public WithEvents tsbSalir As System.Windows.Forms.ToolStripButton
   Friend WithEvents chbFecha As Eniac.Controles.CheckBox
   Friend WithEvents dtpHasta As Eniac.Controles.DateTimePicker
   Friend WithEvents btnConsultar As Eniac.Controles.Button
   Friend WithEvents bscCodigoCliente As Eniac.Controles.Buscador2
   Friend WithEvents lblCodigoCliente As Eniac.Controles.Label
   Friend WithEvents bscCliente As Eniac.Controles.Buscador2
   Friend WithEvents lblNombre As Eniac.Controles.Label
   Public WithEvents tsbRefrescar As System.Windows.Forms.ToolStripButton
   Protected Friend WithEvents stsStado As System.Windows.Forms.StatusStrip
   Protected Friend WithEvents tssInfo As System.Windows.Forms.ToolStripStatusLabel
   Protected Friend WithEvents tspBarra As System.Windows.Forms.ToolStripProgressBar
   Protected WithEvents tssRegistros As System.Windows.Forms.ToolStripStatusLabel
   Friend WithEvents chbCliente As Eniac.Controles.CheckBox
   Friend WithEvents chbVendedor As Eniac.Controles.CheckBox
   Friend WithEvents cmbVendedor As Eniac.Controles.ComboBox
   Friend WithEvents chbZonaGeografica As Eniac.Controles.CheckBox
   Friend WithEvents cmbZonaGeografica As Eniac.Controles.ComboBox
   Friend WithEvents chbExcluirSaldosNegativos As Eniac.Controles.CheckBox
   Friend WithEvents chbCategoria As Eniac.Controles.CheckBox
   Friend WithEvents cmbCategoria As Eniac.Controles.ComboBox
   Friend WithEvents cmbGrabanLibro As Eniac.Controles.ComboBox
   Friend WithEvents lblGrabanLibro As Eniac.Controles.Label
    Friend WithEvents UltraDataSource1 As Infragistics.Win.UltraWinDataSource.UltraDataSource
    Friend WithEvents UltraPrintPreviewDialog1 As Infragistics.Win.Printing.UltraPrintPreviewDialog
    Friend WithEvents UltraGridPrintDocument1 As Infragistics.Win.UltraWinGrid.UltraGridPrintDocument
    Friend WithEvents UltraGridExcelExporter1 As Infragistics.Win.UltraWinGrid.ExcelExport.UltraGridExcelExporter
    Friend WithEvents UltraGridDocumentExporter1 As Infragistics.Win.UltraWinGrid.DocumentExport.UltraGridDocumentExporter
    Friend WithEvents sfdExportar As System.Windows.Forms.SaveFileDialog
    Friend WithEvents chkExpandAll As System.Windows.Forms.CheckBox
    Private WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents tsbImprimir As System.Windows.Forms.ToolStripButton
    Private WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents tsddExportar As System.Windows.Forms.ToolStripDropDownButton
    Friend WithEvents tsmiAExcel As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsmiAPDF As System.Windows.Forms.ToolStripMenuItem
    Private WithEvents ToolStripSeparator4 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents cmbGrupos As Eniac.Controles.ComboBox
    Friend WithEvents chbGrupo As Eniac.Controles.CheckBox
    Friend WithEvents chbExcluirAnticipos As Eniac.Controles.CheckBox
    Friend WithEvents chbExcluirPreComprobantes As Eniac.Controles.CheckBox
    Friend WithEvents chbProvincia As Eniac.Controles.CheckBox
    Public WithEvents cmbProvincia As Eniac.Controles.ComboBox
    Friend WithEvents tsbExportar As System.Windows.Forms.ToolStripButton
    Private WithEvents toolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents btnExaminar As Eniac.Controles.Button
    Friend WithEvents txtArchivoDestino As Eniac.Controles.TextBox
    Friend WithEvents lblArchivoDestino As Eniac.Controles.Label
    Friend WithEvents chbTodos As Eniac.Controles.CheckBox
    Friend WithEvents ugDetalle As UltraGrid
End Class
