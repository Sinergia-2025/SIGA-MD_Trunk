<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class InfCajonesHectolitros
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
      Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(InfCajonesHectolitros))
      Dim Appearance1 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridBand1 As Infragistics.Win.UltraWinGrid.UltraGridBand = New Infragistics.Win.UltraWinGrid.UltraGridBand("Band 0", -1)
      Dim UltraGridColumn1 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Tipo", -1, Nothing, 0, Infragistics.Win.UltraWinGrid.SortIndicator.Ascending, True)
      Dim UltraGridColumn2 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("idproducto")
      Dim UltraGridColumn3 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("nombreproducto")
      Dim UltraGridColumn4 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("tamano")
      Dim UltraGridColumn5 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("presentacion")
      Dim UltraGridColumn6 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("nombreMarca")
      Dim UltraGridColumn7 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Total")
      Dim Appearance2 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn8 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Promedio")
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
      Dim Appearance15 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Me.tstBarra = New System.Windows.Forms.ToolStrip()
      Me.tsbRefrescar = New System.Windows.Forms.ToolStripButton()
      Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
      Me.tsbImprimir = New System.Windows.Forms.ToolStripButton()
      Me.toolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
      Me.tsddExportar = New System.Windows.Forms.ToolStripDropDownButton()
      Me.tsmiAExcel = New System.Windows.Forms.ToolStripMenuItem()
      Me.tsmiAPDF = New System.Windows.Forms.ToolStripMenuItem()
      Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
      Me.tsbSalir = New System.Windows.Forms.ToolStripButton()
      Me.grbConsultar = New System.Windows.Forms.GroupBox()
      Me.chbMuestraImportes = New Eniac.Controles.CheckBox()
      Me.btnConsultar = New Eniac.Controles.Button()
      Me.lnkFiltroTiposComprobantes = New System.Windows.Forms.LinkLabel()
      Me.lnkFiltroZonas = New System.Windows.Forms.LinkLabel()
      Me.cmbTiposClientes = New Eniac.Controles.ComboBox()
      Me.chbTipoCliente = New Eniac.Controles.CheckBox()
      Me.lnkFiltroPorProductos = New System.Windows.Forms.LinkLabel()
      Me.cmbTransportistas = New Eniac.Controles.ComboBox()
      Me.chbTransportista = New Eniac.Controles.CheckBox()
      Me.cmbVendedor = New Eniac.Controles.ComboBox()
      Me.chbVendedor = New Eniac.Controles.CheckBox()
      Me.txtDias = New System.Windows.Forms.TextBox()
      Me.lnkFiltroLocalidades = New System.Windows.Forms.LinkLabel()
      Me.lblDias = New System.Windows.Forms.Label()
      Me.chkMesCompleto = New Eniac.Controles.CheckBox()
      Me.dtpHasta = New Eniac.Controles.DateTimePicker()
      Me.lblHasta = New Eniac.Controles.Label()
      Me.dtpDesde = New Eniac.Controles.DateTimePicker()
      Me.lblDesde = New Eniac.Controles.Label()
      Me.dgvDetalle = New Infragistics.Win.UltraWinGrid.UltraGrid()
      Me.UltraGridDocumentExporter1 = New Infragistics.Win.UltraWinGrid.DocumentExport.UltraGridDocumentExporter(Me.components)
      Me.UltraDataSource1 = New Infragistics.Win.UltraWinDataSource.UltraDataSource(Me.components)
      Me.sfdExportar = New System.Windows.Forms.SaveFileDialog()
      Me.UltraPrintPreviewDialog1 = New Infragistics.Win.Printing.UltraPrintPreviewDialog(Me.components)
      Me.UltraGridPrintDocument1 = New Infragistics.Win.UltraWinGrid.UltraGridPrintDocument(Me.components)
      Me.UltraGridExcelExporter1 = New Infragistics.Win.UltraWinGrid.ExcelExport.UltraGridExcelExporter(Me.components)
      Me.tstBarra.SuspendLayout()
      Me.grbConsultar.SuspendLayout()
      CType(Me.dgvDetalle, System.ComponentModel.ISupportInitialize).BeginInit()
      CType(Me.UltraDataSource1, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.SuspendLayout()
      '
      'tstBarra
      '
      Me.tstBarra.AllowItemReorder = True
      Me.tstBarra.ImageScalingSize = New System.Drawing.Size(22, 22)
      Me.tstBarra.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsbRefrescar, Me.ToolStripSeparator1, Me.tsbImprimir, Me.toolStripSeparator3, Me.tsddExportar, Me.ToolStripSeparator2, Me.tsbSalir})
      Me.tstBarra.Location = New System.Drawing.Point(0, 0)
      Me.tstBarra.Name = "tstBarra"
      Me.tstBarra.Size = New System.Drawing.Size(794, 29)
      Me.tstBarra.TabIndex = 9
      Me.tstBarra.Text = "toolStrip1"
      '
      'tsbRefrescar
      '
      Me.tsbRefrescar.Image = CType(resources.GetObject("tsbRefrescar.Image"), System.Drawing.Image)
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
      Me.tsbImprimir.Image = CType(resources.GetObject("tsbImprimir.Image"), System.Drawing.Image)
      Me.tsbImprimir.ImageTransparentColor = System.Drawing.Color.Magenta
      Me.tsbImprimir.Name = "tsbImprimir"
      Me.tsbImprimir.Size = New System.Drawing.Size(79, 26)
      Me.tsbImprimir.Text = "&Imprimir"
      Me.tsbImprimir.ToolTipText = "Imprimir"
      '
      'toolStripSeparator3
      '
      Me.toolStripSeparator3.Name = "toolStripSeparator3"
      Me.toolStripSeparator3.Size = New System.Drawing.Size(6, 29)
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
      'ToolStripSeparator2
      '
      Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
      Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 29)
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
      'grbConsultar
      '
      Me.grbConsultar.Controls.Add(Me.chbMuestraImportes)
      Me.grbConsultar.Controls.Add(Me.btnConsultar)
      Me.grbConsultar.Controls.Add(Me.lnkFiltroTiposComprobantes)
      Me.grbConsultar.Controls.Add(Me.lnkFiltroZonas)
      Me.grbConsultar.Controls.Add(Me.cmbTiposClientes)
      Me.grbConsultar.Controls.Add(Me.chbTipoCliente)
      Me.grbConsultar.Controls.Add(Me.lnkFiltroPorProductos)
      Me.grbConsultar.Controls.Add(Me.cmbTransportistas)
      Me.grbConsultar.Controls.Add(Me.chbTransportista)
      Me.grbConsultar.Controls.Add(Me.cmbVendedor)
      Me.grbConsultar.Controls.Add(Me.chbVendedor)
      Me.grbConsultar.Controls.Add(Me.txtDias)
      Me.grbConsultar.Controls.Add(Me.lnkFiltroLocalidades)
      Me.grbConsultar.Controls.Add(Me.lblDias)
      Me.grbConsultar.Controls.Add(Me.chkMesCompleto)
      Me.grbConsultar.Controls.Add(Me.dtpHasta)
      Me.grbConsultar.Controls.Add(Me.dtpDesde)
      Me.grbConsultar.Controls.Add(Me.lblHasta)
      Me.grbConsultar.Controls.Add(Me.lblDesde)
      Me.grbConsultar.Location = New System.Drawing.Point(12, 32)
      Me.grbConsultar.Name = "grbConsultar"
      Me.grbConsultar.Size = New System.Drawing.Size(774, 96)
      Me.grbConsultar.TabIndex = 10
      Me.grbConsultar.TabStop = False
      Me.grbConsultar.Text = "Consultar"
      '
      'chbMuestraImportes
      '
      Me.chbMuestraImportes.AutoSize = True
      Me.chbMuestraImportes.BindearPropiedadControl = Nothing
      Me.chbMuestraImportes.BindearPropiedadEntidad = Nothing
      Me.chbMuestraImportes.ForeColorFocus = System.Drawing.Color.Red
      Me.chbMuestraImportes.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
      Me.chbMuestraImportes.IsPK = False
      Me.chbMuestraImportes.IsRequired = False
      Me.chbMuestraImportes.Key = Nothing
      Me.chbMuestraImportes.LabelAsoc = Nothing
      Me.chbMuestraImportes.Location = New System.Drawing.Point(660, 18)
      Me.chbMuestraImportes.Name = "chbMuestraImportes"
      Me.chbMuestraImportes.Size = New System.Drawing.Size(106, 17)
      Me.chbMuestraImportes.TabIndex = 66
      Me.chbMuestraImportes.Text = "Muestra importes"
      Me.chbMuestraImportes.UseVisualStyleBackColor = True
      '
      'btnConsultar
      '
      Me.btnConsultar.Image = CType(resources.GetObject("btnConsultar.Image"), System.Drawing.Image)
      Me.btnConsultar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
      Me.btnConsultar.Location = New System.Drawing.Point(657, 39)
      Me.btnConsultar.Name = "btnConsultar"
      Me.btnConsultar.Size = New System.Drawing.Size(111, 48)
      Me.btnConsultar.TabIndex = 27
      Me.btnConsultar.Text = "&Consultar"
      Me.btnConsultar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      Me.btnConsultar.UseVisualStyleBackColor = True
      '
      'lnkFiltroTiposComprobantes
      '
      Me.lnkFiltroTiposComprobantes.AutoSize = True
      Me.lnkFiltroTiposComprobantes.Location = New System.Drawing.Point(407, 68)
      Me.lnkFiltroTiposComprobantes.Name = "lnkFiltroTiposComprobantes"
      Me.lnkFiltroTiposComprobantes.Size = New System.Drawing.Size(123, 13)
      Me.lnkFiltroTiposComprobantes.TabIndex = 65
      Me.lnkFiltroTiposComprobantes.TabStop = True
      Me.lnkFiltroTiposComprobantes.Text = "Todos los comprobantes"
      '
      'lnkFiltroZonas
      '
      Me.lnkFiltroZonas.AutoSize = True
      Me.lnkFiltroZonas.Location = New System.Drawing.Point(407, 43)
      Me.lnkFiltroZonas.Name = "lnkFiltroZonas"
      Me.lnkFiltroZonas.Size = New System.Drawing.Size(142, 13)
      Me.lnkFiltroZonas.TabIndex = 64
      Me.lnkFiltroZonas.TabStop = True
      Me.lnkFiltroZonas.Text = "Todas las zonas geográficas"
      '
      'cmbTiposClientes
      '
      Me.cmbTiposClientes.BindearPropiedadControl = Nothing
      Me.cmbTiposClientes.BindearPropiedadEntidad = Nothing
      Me.cmbTiposClientes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cmbTiposClientes.Enabled = False
      Me.cmbTiposClientes.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.cmbTiposClientes.ForeColorFocus = System.Drawing.Color.Red
      Me.cmbTiposClientes.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.cmbTiposClientes.FormattingEnabled = True
      Me.cmbTiposClientes.IsPK = False
      Me.cmbTiposClientes.IsRequired = False
      Me.cmbTiposClientes.Key = Nothing
      Me.cmbTiposClientes.LabelAsoc = Nothing
      Me.cmbTiposClientes.Location = New System.Drawing.Point(502, 12)
      Me.cmbTiposClientes.Name = "cmbTiposClientes"
      Me.cmbTiposClientes.Size = New System.Drawing.Size(144, 21)
      Me.cmbTiposClientes.TabIndex = 62
      '
      'chbTipoCliente
      '
      Me.chbTipoCliente.AutoSize = True
      Me.chbTipoCliente.BindearPropiedadControl = Nothing
      Me.chbTipoCliente.BindearPropiedadEntidad = Nothing
      Me.chbTipoCliente.ForeColorFocus = System.Drawing.Color.Red
      Me.chbTipoCliente.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
      Me.chbTipoCliente.IsPK = False
      Me.chbTipoCliente.IsRequired = False
      Me.chbTipoCliente.Key = Nothing
      Me.chbTipoCliente.LabelAsoc = Nothing
      Me.chbTipoCliente.Location = New System.Drawing.Point(394, 16)
      Me.chbTipoCliente.Name = "chbTipoCliente"
      Me.chbTipoCliente.Size = New System.Drawing.Size(97, 17)
      Me.chbTipoCliente.TabIndex = 63
      Me.chbTipoCliente.Text = "Tipo de Cliente"
      Me.chbTipoCliente.UseVisualStyleBackColor = True
      '
      'lnkFiltroPorProductos
      '
      Me.lnkFiltroPorProductos.AutoSize = True
      Me.lnkFiltroPorProductos.Location = New System.Drawing.Point(152, 20)
      Me.lnkFiltroPorProductos.Name = "lnkFiltroPorProductos"
      Me.lnkFiltroPorProductos.Size = New System.Drawing.Size(103, 13)
      Me.lnkFiltroPorProductos.TabIndex = 28
      Me.lnkFiltroPorProductos.TabStop = True
      Me.lnkFiltroPorProductos.Text = "Todos los productos"
      '
      'cmbTransportistas
      '
      Me.cmbTransportistas.BindearPropiedadControl = Nothing
      Me.cmbTransportistas.BindearPropiedadEntidad = Nothing
      Me.cmbTransportistas.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cmbTransportistas.Enabled = False
      Me.cmbTransportistas.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.cmbTransportistas.ForeColorFocus = System.Drawing.Color.Red
      Me.cmbTransportistas.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.cmbTransportistas.FormattingEnabled = True
      Me.cmbTransportistas.IsPK = False
      Me.cmbTransportistas.IsRequired = False
      Me.cmbTransportistas.Key = Nothing
      Me.cmbTransportistas.LabelAsoc = Nothing
      Me.cmbTransportistas.Location = New System.Drawing.Point(238, 63)
      Me.cmbTransportistas.Name = "cmbTransportistas"
      Me.cmbTransportistas.Size = New System.Drawing.Size(162, 21)
      Me.cmbTransportistas.TabIndex = 59
      '
      'chbTransportista
      '
      Me.chbTransportista.AutoSize = True
      Me.chbTransportista.BindearPropiedadControl = Nothing
      Me.chbTransportista.BindearPropiedadEntidad = Nothing
      Me.chbTransportista.ForeColorFocus = System.Drawing.Color.Red
      Me.chbTransportista.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
      Me.chbTransportista.IsPK = False
      Me.chbTransportista.IsRequired = False
      Me.chbTransportista.Key = Nothing
      Me.chbTransportista.LabelAsoc = Nothing
      Me.chbTransportista.Location = New System.Drawing.Point(155, 67)
      Me.chbTransportista.Name = "chbTransportista"
      Me.chbTransportista.Size = New System.Drawing.Size(87, 17)
      Me.chbTransportista.TabIndex = 60
      Me.chbTransportista.Text = "Transportista"
      Me.chbTransportista.UseVisualStyleBackColor = True
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
      Me.cmbVendedor.Location = New System.Drawing.Point(238, 37)
      Me.cmbVendedor.Name = "cmbVendedor"
      Me.cmbVendedor.Size = New System.Drawing.Size(162, 21)
      Me.cmbVendedor.TabIndex = 57
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
      Me.chbVendedor.Location = New System.Drawing.Point(155, 42)
      Me.chbVendedor.Name = "chbVendedor"
      Me.chbVendedor.Size = New System.Drawing.Size(72, 17)
      Me.chbVendedor.TabIndex = 58
      Me.chbVendedor.Text = "Vendedor"
      Me.chbVendedor.UseVisualStyleBackColor = True
      '
      'txtDias
      '
      Me.txtDias.Location = New System.Drawing.Point(578, 64)
      Me.txtDias.Name = "txtDias"
      Me.txtDias.ReadOnly = True
      Me.txtDias.Size = New System.Drawing.Size(44, 20)
      Me.txtDias.TabIndex = 1
      Me.txtDias.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'lnkFiltroLocalidades
      '
      Me.lnkFiltroLocalidades.AutoSize = True
      Me.lnkFiltroLocalidades.Location = New System.Drawing.Point(275, 20)
      Me.lnkFiltroLocalidades.Name = "lnkFiltroLocalidades"
      Me.lnkFiltroLocalidades.Size = New System.Drawing.Size(109, 13)
      Me.lnkFiltroLocalidades.TabIndex = 61
      Me.lnkFiltroLocalidades.TabStop = True
      Me.lnkFiltroLocalidades.Text = "Todas las localidades"
      '
      'lblDias
      '
      Me.lblDias.AutoSize = True
      Me.lblDias.Location = New System.Drawing.Point(549, 49)
      Me.lblDias.Name = "lblDias"
      Me.lblDias.Size = New System.Drawing.Size(80, 13)
      Me.lblDias.TabIndex = 0
      Me.lblDias.Text = "Días de ventas"
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
      Me.chkMesCompleto.Location = New System.Drawing.Point(9, 19)
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
      Me.dtpHasta.CustomFormat = "dd/MM/yyyy"
      Me.dtpHasta.ForeColorFocus = System.Drawing.Color.Red
      Me.dtpHasta.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.dtpHasta.Format = System.Windows.Forms.DateTimePickerFormat.Custom
      Me.dtpHasta.IsPK = False
      Me.dtpHasta.IsRequired = False
      Me.dtpHasta.Key = ""
      Me.dtpHasta.LabelAsoc = Me.lblHasta
      Me.dtpHasta.Location = New System.Drawing.Point(50, 65)
      Me.dtpHasta.Name = "dtpHasta"
      Me.dtpHasta.Size = New System.Drawing.Size(99, 20)
      Me.dtpHasta.TabIndex = 4
      '
      'lblHasta
      '
      Me.lblHasta.AutoSize = True
      Me.lblHasta.Location = New System.Drawing.Point(6, 71)
      Me.lblHasta.Name = "lblHasta"
      Me.lblHasta.Size = New System.Drawing.Size(35, 13)
      Me.lblHasta.TabIndex = 3
      Me.lblHasta.Text = "Hasta"
      '
      'dtpDesde
      '
      Me.dtpDesde.BindearPropiedadControl = Nothing
      Me.dtpDesde.BindearPropiedadEntidad = Nothing
      Me.dtpDesde.CustomFormat = "dd/MM/yyyy"
      Me.dtpDesde.ForeColorFocus = System.Drawing.Color.Red
      Me.dtpDesde.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.dtpDesde.Format = System.Windows.Forms.DateTimePickerFormat.Custom
      Me.dtpDesde.IsPK = False
      Me.dtpDesde.IsRequired = False
      Me.dtpDesde.Key = ""
      Me.dtpDesde.LabelAsoc = Me.lblDesde
      Me.dtpDesde.Location = New System.Drawing.Point(50, 39)
      Me.dtpDesde.Name = "dtpDesde"
      Me.dtpDesde.Size = New System.Drawing.Size(99, 20)
      Me.dtpDesde.TabIndex = 2
      '
      'lblDesde
      '
      Me.lblDesde.AutoSize = True
      Me.lblDesde.Location = New System.Drawing.Point(6, 45)
      Me.lblDesde.Name = "lblDesde"
      Me.lblDesde.Size = New System.Drawing.Size(38, 13)
      Me.lblDesde.TabIndex = 1
      Me.lblDesde.Text = "Desde"
      '
      'dgvDetalle
      '
      Me.dgvDetalle.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Appearance1.BackColor = System.Drawing.SystemColors.Window
      Appearance1.BorderColor = System.Drawing.SystemColors.InactiveCaption
      Me.dgvDetalle.DisplayLayout.Appearance = Appearance1
      UltraGridColumn1.Header.VisiblePosition = 0
      UltraGridColumn2.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
      UltraGridColumn2.Header.Caption = "Cod. Prod."
      UltraGridColumn2.Header.VisiblePosition = 1
      UltraGridColumn2.Width = 110
      UltraGridColumn3.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
      UltraGridColumn3.Header.Caption = "Producto"
      UltraGridColumn3.Header.VisiblePosition = 2
      UltraGridColumn3.Width = 239
      UltraGridColumn4.Header.VisiblePosition = 5
      UltraGridColumn4.Hidden = True
      UltraGridColumn5.Header.VisiblePosition = 6
      UltraGridColumn5.Hidden = True
      UltraGridColumn6.Header.Caption = "Marca"
      UltraGridColumn6.Header.VisiblePosition = 7
      UltraGridColumn6.Hidden = True
      Appearance2.TextHAlignAsString = "Right"
      UltraGridColumn7.CellAppearance = Appearance2
      UltraGridColumn7.Format = "#,##0.00"
      UltraGridColumn7.Header.VisiblePosition = 3
      Appearance3.TextHAlignAsString = "Right"
      UltraGridColumn8.CellAppearance = Appearance3
      UltraGridColumn8.Header.VisiblePosition = 4
      UltraGridBand1.Columns.AddRange(New Object() {UltraGridColumn1, UltraGridColumn2, UltraGridColumn3, UltraGridColumn4, UltraGridColumn5, UltraGridColumn6, UltraGridColumn7, UltraGridColumn8})
      Me.dgvDetalle.DisplayLayout.BandsSerializer.Add(UltraGridBand1)
      Me.dgvDetalle.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
      Me.dgvDetalle.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.[False]
      Appearance4.BackColor = System.Drawing.SystemColors.ActiveBorder
      Appearance4.BackColor2 = System.Drawing.SystemColors.ControlDark
      Appearance4.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
      Appearance4.BorderColor = System.Drawing.SystemColors.Window
      Me.dgvDetalle.DisplayLayout.GroupByBox.Appearance = Appearance4
      Appearance5.ForeColor = System.Drawing.SystemColors.GrayText
      Me.dgvDetalle.DisplayLayout.GroupByBox.BandLabelAppearance = Appearance5
      Me.dgvDetalle.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
      Me.dgvDetalle.DisplayLayout.GroupByBox.Hidden = True
      Me.dgvDetalle.DisplayLayout.GroupByBox.Prompt = "Arrastre un título de columna aquí para agrupar."
      Appearance6.BackColor = System.Drawing.SystemColors.ControlLightLight
      Appearance6.BackColor2 = System.Drawing.SystemColors.Control
      Appearance6.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
      Appearance6.ForeColor = System.Drawing.SystemColors.GrayText
      Me.dgvDetalle.DisplayLayout.GroupByBox.PromptAppearance = Appearance6
      Me.dgvDetalle.DisplayLayout.MaxColScrollRegions = 1
      Me.dgvDetalle.DisplayLayout.MaxRowScrollRegions = 1
      Appearance7.BackColor = System.Drawing.SystemColors.Window
      Appearance7.ForeColor = System.Drawing.SystemColors.ControlText
      Me.dgvDetalle.DisplayLayout.Override.ActiveCellAppearance = Appearance7
      Appearance8.BackColor = System.Drawing.SystemColors.Highlight
      Appearance8.ForeColor = System.Drawing.SystemColors.HighlightText
      Me.dgvDetalle.DisplayLayout.Override.ActiveRowAppearance = Appearance8
      Me.dgvDetalle.DisplayLayout.Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.No
      Me.dgvDetalle.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.[False]
      Me.dgvDetalle.DisplayLayout.Override.AllowUpdate = Infragistics.Win.DefaultableBoolean.[False]
      Me.dgvDetalle.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted
      Me.dgvDetalle.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted
      Appearance9.BackColor = System.Drawing.SystemColors.Window
      Me.dgvDetalle.DisplayLayout.Override.CardAreaAppearance = Appearance9
      Appearance10.BorderColor = System.Drawing.Color.Silver
      Appearance10.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter
      Me.dgvDetalle.DisplayLayout.Override.CellAppearance = Appearance10
      Me.dgvDetalle.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText
      Me.dgvDetalle.DisplayLayout.Override.CellPadding = 0
      Appearance11.BackColor = System.Drawing.SystemColors.Control
      Appearance11.BackColor2 = System.Drawing.SystemColors.ControlDark
      Appearance11.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element
      Appearance11.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
      Appearance11.BorderColor = System.Drawing.SystemColors.Window
      Me.dgvDetalle.DisplayLayout.Override.GroupByRowAppearance = Appearance11
      Appearance12.TextHAlignAsString = "Left"
      Me.dgvDetalle.DisplayLayout.Override.HeaderAppearance = Appearance12
      Me.dgvDetalle.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
      Me.dgvDetalle.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand
      Appearance13.BackColor = System.Drawing.SystemColors.Window
      Appearance13.BorderColor = System.Drawing.Color.Silver
      Me.dgvDetalle.DisplayLayout.Override.RowAppearance = Appearance13
      Me.dgvDetalle.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[False]
      Me.dgvDetalle.DisplayLayout.Override.SummaryDisplayArea = Infragistics.Win.UltraWinGrid.SummaryDisplayAreas.TopFixed
      Appearance14.BackColor = System.Drawing.SystemColors.ControlLight
      Me.dgvDetalle.DisplayLayout.Override.TemplateAddRowAppearance = Appearance14
      Me.dgvDetalle.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill
      Me.dgvDetalle.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate
      Me.dgvDetalle.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy
      Me.dgvDetalle.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.dgvDetalle.Location = New System.Drawing.Point(12, 134)
      Me.dgvDetalle.Name = "dgvDetalle"
      Me.dgvDetalle.Size = New System.Drawing.Size(774, 315)
      Me.dgvDetalle.TabIndex = 11
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
      Me.UltraGridPrintDocument1.DocumentName = "Lista de Precios Múltiples"
      Me.UltraGridPrintDocument1.Footer.TextCenter = ""
      Me.UltraGridPrintDocument1.Grid = Me.dgvDetalle
      Appearance15.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
      Appearance15.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element
      Appearance15.BackGradientStyle = Infragistics.Win.GradientStyle.VerticalBump
      Me.UltraGridPrintDocument1.Header.Appearance = Appearance15
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
      'InfCajonesHectolitros
      '
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.ClientSize = New System.Drawing.Size(794, 452)
      Me.Controls.Add(Me.dgvDetalle)
      Me.Controls.Add(Me.grbConsultar)
      Me.Controls.Add(Me.tstBarra)
      Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
      Me.Name = "InfCajonesHectolitros"
      Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
      Me.Text = "Informe de Cajones y Hectolitros"
      Me.tstBarra.ResumeLayout(False)
      Me.tstBarra.PerformLayout()
      Me.grbConsultar.ResumeLayout(False)
      Me.grbConsultar.PerformLayout()
      CType(Me.dgvDetalle, System.ComponentModel.ISupportInitialize).EndInit()
      CType(Me.UltraDataSource1, System.ComponentModel.ISupportInitialize).EndInit()
      Me.ResumeLayout(False)
      Me.PerformLayout()

   End Sub
   Public WithEvents tstBarra As System.Windows.Forms.ToolStrip
   Public WithEvents tsbRefrescar As System.Windows.Forms.ToolStripButton
   Private WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
   Friend WithEvents tsbImprimir As System.Windows.Forms.ToolStripButton
   Private WithEvents toolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
   Friend WithEvents tsddExportar As System.Windows.Forms.ToolStripDropDownButton
   Friend WithEvents tsmiAExcel As System.Windows.Forms.ToolStripMenuItem
   Friend WithEvents tsmiAPDF As System.Windows.Forms.ToolStripMenuItem
   Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
   Public WithEvents tsbSalir As System.Windows.Forms.ToolStripButton
   Friend WithEvents grbConsultar As System.Windows.Forms.GroupBox
   Friend WithEvents btnConsultar As Eniac.Controles.Button
   Friend WithEvents chkMesCompleto As Eniac.Controles.CheckBox
   Friend WithEvents dtpHasta As Eniac.Controles.DateTimePicker
   Friend WithEvents lblHasta As Eniac.Controles.Label
   Friend WithEvents dtpDesde As Eniac.Controles.DateTimePicker
   Friend WithEvents lblDesde As Eniac.Controles.Label
   Friend WithEvents dgvDetalle As Infragistics.Win.UltraWinGrid.UltraGrid
   Friend WithEvents UltraGridDocumentExporter1 As Infragistics.Win.UltraWinGrid.DocumentExport.UltraGridDocumentExporter
   Friend WithEvents UltraDataSource1 As Infragistics.Win.UltraWinDataSource.UltraDataSource
   Friend WithEvents sfdExportar As System.Windows.Forms.SaveFileDialog
   Friend WithEvents UltraPrintPreviewDialog1 As Infragistics.Win.Printing.UltraPrintPreviewDialog
   Friend WithEvents UltraGridPrintDocument1 As Infragistics.Win.UltraWinGrid.UltraGridPrintDocument
   Friend WithEvents UltraGridExcelExporter1 As Infragistics.Win.UltraWinGrid.ExcelExport.UltraGridExcelExporter
   Friend WithEvents txtDias As System.Windows.Forms.TextBox
   Friend WithEvents lblDias As System.Windows.Forms.Label
   Friend WithEvents lnkFiltroLocalidades As System.Windows.Forms.LinkLabel
   Friend WithEvents cmbVendedor As Eniac.Controles.ComboBox
   Friend WithEvents chbVendedor As Eniac.Controles.CheckBox
   Friend WithEvents cmbTransportistas As Eniac.Controles.ComboBox
   Friend WithEvents chbTransportista As Eniac.Controles.CheckBox
   Friend WithEvents lnkFiltroPorProductos As System.Windows.Forms.LinkLabel
   Friend WithEvents cmbTiposClientes As Eniac.Controles.ComboBox
   Friend WithEvents chbTipoCliente As Eniac.Controles.CheckBox
   Friend WithEvents lnkFiltroZonas As System.Windows.Forms.LinkLabel
   Friend WithEvents lnkFiltroTiposComprobantes As System.Windows.Forms.LinkLabel
   Friend WithEvents chbMuestraImportes As Eniac.Controles.CheckBox
End Class
