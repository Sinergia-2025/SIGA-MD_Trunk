<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class InfVentasSumaPorRubros
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
      Dim UltraGridBand1 As Infragistics.Win.UltraWinGrid.UltraGridBand = New Infragistics.Win.UltraWinGrid.UltraGridBand("Band 0", -1)
      Dim UltraGridColumn2 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreRubro")
      Dim UltraGridColumn16 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreListaPrecios")
      Dim UltraGridColumn17 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("DescripcionFormasPago")
      Dim UltraGridColumn6 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("ImporteTotalNeto")
      Dim Appearance2 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn7 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("ImporteTotal")
      Dim Appearance3 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn8 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Kilos")
      Dim Appearance4 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn9 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Cantidad")
      Dim Appearance5 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn10 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Stock")
      Dim Appearance6 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn15 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdSucursal")
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
      Dim UltraGridBand2 As Infragistics.Win.UltraWinGrid.UltraGridBand = New Infragistics.Win.UltraWinGrid.UltraGridBand("Band 0", -1)
      Dim UltraGridColumn1 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdSucursal")
      Dim Appearance20 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn3 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreRubro")
      Dim UltraGridColumn4 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Stock")
      Dim Appearance21 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn5 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Cantidad")
      Dim Appearance22 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn14 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("ImporteTotalNeto")
      Dim Appearance23 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn18 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("ImporteTotal")
      Dim Appearance24 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn13 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Kilos")
      Dim Appearance25 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim Appearance26 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim Appearance27 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim Appearance28 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim Appearance29 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim Appearance30 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim Appearance31 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim Appearance32 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim Appearance33 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim Appearance34 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim Appearance35 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim Appearance36 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim Appearance37 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridBand3 As Infragistics.Win.UltraWinGrid.UltraGridBand = New Infragistics.Win.UltraWinGrid.UltraGridBand("Band 0", -1)
      Dim UltraGridColumn11 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdSucursal")
      Dim Appearance38 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn12 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreRubro")
      Dim UltraGridColumn19 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdZonaGeografica")
      Dim UltraGridColumn20 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("ImporteTotalNeto")
      Dim Appearance39 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn21 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("ImporteTotal")
      Dim Appearance40 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn22 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Kilos")
      Dim Appearance41 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn23 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Cantidad")
      Dim Appearance42 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn24 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Stock")
      Dim Appearance43 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim Appearance44 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim Appearance45 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim Appearance46 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim Appearance47 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim Appearance48 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim Appearance49 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim Appearance50 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim Appearance51 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim Appearance52 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim Appearance53 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim Appearance54 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Me.grbConsultar = New System.Windows.Forms.GroupBox()
      Me.chbUnificar = New Eniac.Controles.CheckBox()
      Me.chbConIVA = New Eniac.Controles.CheckBox()
      Me.lblSucursal = New Eniac.Controles.Label()
      Me.cmbSucursal = New Eniac.Win.ComboBoxSucursales()
      Me.chbListaDePrecios = New Eniac.Controles.CheckBox()
      Me.chbCategoria = New Eniac.Controles.CheckBox()
      Me.cmbListaDePrecios = New Eniac.Controles.ComboBox()
      Me.cmbCategoria = New Eniac.Controles.ComboBox()
      Me.bscProveedor = New Eniac.Controles.Buscador()
      Me.chbAlertaDeCaja = New Eniac.Controles.CheckBox()
      Me.bscCodigoProveedor = New Eniac.Controles.Buscador()
      Me.chbProveedor = New Eniac.Controles.CheckBox()
      Me.chkExpandAll = New System.Windows.Forms.CheckBox()
      Me.lblPromediar = New Eniac.Controles.Label()
      Me.chbPromediar = New Eniac.Controles.CheckBox()
      Me.btnConsultar = New Eniac.Controles.Button()
      Me.chbCaja = New Eniac.Controles.CheckBox()
      Me.chbVendedor = New Eniac.Controles.CheckBox()
      Me.cmbCajas = New Eniac.Controles.ComboBox()
      Me.cmbVendedor = New Eniac.Controles.ComboBox()
      Me.bscCodigoCliente = New Eniac.Controles.Buscador()
      Me.lblCodigoCliente = New Eniac.Controles.Label()
      Me.bscCliente = New Eniac.Controles.Buscador()
      Me.lblNombre = New Eniac.Controles.Label()
      Me.chbCliente = New Eniac.Controles.CheckBox()
      Me.chbRubro = New Eniac.Controles.CheckBox()
      Me.cmbRubro = New Eniac.Controles.ComboBox()
      Me.chbMarca = New Eniac.Controles.CheckBox()
      Me.cmbMarca = New Eniac.Controles.ComboBox()
      Me.chbMesCompleto = New Eniac.Controles.CheckBox()
      Me.dtpHasta = New Eniac.Controles.DateTimePicker()
      Me.lblHasta = New Eniac.Controles.Label()
      Me.dtpDesde = New Eniac.Controles.DateTimePicker()
      Me.lblDesde = New Eniac.Controles.Label()
      Me.tstBarra = New System.Windows.Forms.ToolStrip()
      Me.tsbRefrescar = New System.Windows.Forms.ToolStripButton()
      Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
      Me.tsbImprimir = New System.Windows.Forms.ToolStripButton()
      Me.toolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
      Me.tsddExportar = New System.Windows.Forms.ToolStripDropDownButton()
      Me.tsmiAExcel = New System.Windows.Forms.ToolStripMenuItem()
      Me.tsmiAPDF = New System.Windows.Forms.ToolStripMenuItem()
      Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
      Me.tsbPreferencias = New System.Windows.Forms.ToolStripButton()
      Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator()
      Me.tsbSalir = New System.Windows.Forms.ToolStripButton()
      Me.UltraDataSource1 = New Infragistics.Win.UltraWinDataSource.UltraDataSource(Me.components)
      Me.UltraGridDocumentExporter1 = New Infragistics.Win.UltraWinGrid.DocumentExport.UltraGridDocumentExporter(Me.components)
      Me.UltraGridExcelExporter1 = New Infragistics.Win.UltraWinGrid.ExcelExport.UltraGridExcelExporter(Me.components)
      Me.sfdExportar = New System.Windows.Forms.SaveFileDialog()
      Me.ugDetalle = New Infragistics.Win.UltraWinGrid.UltraGrid()
      Me.UltraGridPrintDocument1 = New Infragistics.Win.UltraWinGrid.UltraGridPrintDocument(Me.components)
      Me.UltraPrintPreviewDialog1 = New Infragistics.Win.Printing.UltraPrintPreviewDialog(Me.components)
      Me.stsStado = New System.Windows.Forms.StatusStrip()
      Me.tssInfo = New System.Windows.Forms.ToolStripStatusLabel()
      Me.tspBarra = New System.Windows.Forms.ToolStripStatusLabel()
      Me.tssRegistros = New System.Windows.Forms.ToolStripStatusLabel()
      Me.tbcAgrupados = New System.Windows.Forms.TabControl()
      Me.tbpXRubros = New System.Windows.Forms.TabPage()
      Me.ugDetalleXRubro = New Infragistics.Win.UltraWinGrid.UltraGrid()
      Me.tbpXListaPrecios = New System.Windows.Forms.TabPage()
      Me.tbpXZonaGeografica = New System.Windows.Forms.TabPage()
      Me.ugvXZona = New Infragistics.Win.UltraWinGrid.UltraGrid()
      Me.UltraDataSource2 = New Infragistics.Win.UltraWinDataSource.UltraDataSource(Me.components)
      Me.grbConsultar.SuspendLayout()
      Me.tstBarra.SuspendLayout()
      CType(Me.UltraDataSource1, System.ComponentModel.ISupportInitialize).BeginInit()
      CType(Me.ugDetalle, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.stsStado.SuspendLayout()
      Me.tbcAgrupados.SuspendLayout()
      Me.tbpXRubros.SuspendLayout()
      CType(Me.ugDetalleXRubro, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.tbpXListaPrecios.SuspendLayout()
      Me.tbpXZonaGeografica.SuspendLayout()
      CType(Me.ugvXZona, System.ComponentModel.ISupportInitialize).BeginInit()
      CType(Me.UltraDataSource2, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.SuspendLayout()
      '
      'grbConsultar
      '
      Me.grbConsultar.Controls.Add(Me.chbUnificar)
      Me.grbConsultar.Controls.Add(Me.chbConIVA)
      Me.grbConsultar.Controls.Add(Me.lblSucursal)
      Me.grbConsultar.Controls.Add(Me.cmbSucursal)
      Me.grbConsultar.Controls.Add(Me.chbListaDePrecios)
      Me.grbConsultar.Controls.Add(Me.chbCategoria)
      Me.grbConsultar.Controls.Add(Me.cmbListaDePrecios)
      Me.grbConsultar.Controls.Add(Me.cmbCategoria)
      Me.grbConsultar.Controls.Add(Me.bscProveedor)
      Me.grbConsultar.Controls.Add(Me.chbAlertaDeCaja)
      Me.grbConsultar.Controls.Add(Me.bscCodigoProveedor)
      Me.grbConsultar.Controls.Add(Me.chbProveedor)
      Me.grbConsultar.Controls.Add(Me.chkExpandAll)
      Me.grbConsultar.Controls.Add(Me.lblPromediar)
      Me.grbConsultar.Controls.Add(Me.chbPromediar)
      Me.grbConsultar.Controls.Add(Me.btnConsultar)
      Me.grbConsultar.Controls.Add(Me.chbCaja)
      Me.grbConsultar.Controls.Add(Me.chbVendedor)
      Me.grbConsultar.Controls.Add(Me.cmbCajas)
      Me.grbConsultar.Controls.Add(Me.cmbVendedor)
      Me.grbConsultar.Controls.Add(Me.bscCodigoCliente)
      Me.grbConsultar.Controls.Add(Me.bscCliente)
      Me.grbConsultar.Controls.Add(Me.lblCodigoCliente)
      Me.grbConsultar.Controls.Add(Me.lblNombre)
      Me.grbConsultar.Controls.Add(Me.chbCliente)
      Me.grbConsultar.Controls.Add(Me.chbRubro)
      Me.grbConsultar.Controls.Add(Me.cmbRubro)
      Me.grbConsultar.Controls.Add(Me.chbMarca)
      Me.grbConsultar.Controls.Add(Me.cmbMarca)
      Me.grbConsultar.Controls.Add(Me.chbMesCompleto)
      Me.grbConsultar.Controls.Add(Me.dtpHasta)
      Me.grbConsultar.Controls.Add(Me.dtpDesde)
      Me.grbConsultar.Controls.Add(Me.lblHasta)
      Me.grbConsultar.Controls.Add(Me.lblDesde)
      Me.grbConsultar.Location = New System.Drawing.Point(9, 32)
      Me.grbConsultar.Name = "grbConsultar"
      Me.grbConsultar.Size = New System.Drawing.Size(865, 165)
      Me.grbConsultar.TabIndex = 0
      Me.grbConsultar.TabStop = False
      Me.grbConsultar.Text = "Filtros"
      '
      'chbUnificar
      '
      Me.chbUnificar.AutoSize = True
      Me.chbUnificar.BindearPropiedadControl = Nothing
      Me.chbUnificar.BindearPropiedadEntidad = Nothing
      Me.chbUnificar.Checked = True
      Me.chbUnificar.CheckState = System.Windows.Forms.CheckState.Checked
      Me.chbUnificar.ForeColorFocus = System.Drawing.Color.Red
      Me.chbUnificar.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
      Me.chbUnificar.IsPK = False
      Me.chbUnificar.IsRequired = False
      Me.chbUnificar.Key = Nothing
      Me.chbUnificar.LabelAsoc = Nothing
      Me.chbUnificar.Location = New System.Drawing.Point(235, 15)
      Me.chbUnificar.Name = "chbUnificar"
      Me.chbUnificar.Size = New System.Drawing.Size(62, 17)
      Me.chbUnificar.TabIndex = 2
      Me.chbUnificar.Text = "Unificar"
      Me.chbUnificar.UseVisualStyleBackColor = True
      '
      'chbConIVA
      '
      Me.chbConIVA.AutoSize = True
      Me.chbConIVA.BindearPropiedadControl = Nothing
      Me.chbConIVA.BindearPropiedadEntidad = Nothing
      Me.chbConIVA.ForeColorFocus = System.Drawing.Color.Red
      Me.chbConIVA.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
      Me.chbConIVA.IsPK = False
      Me.chbConIVA.IsRequired = False
      Me.chbConIVA.Key = Nothing
      Me.chbConIVA.LabelAsoc = Nothing
      Me.chbConIVA.Location = New System.Drawing.Point(605, 137)
      Me.chbConIVA.Name = "chbConIVA"
      Me.chbConIVA.Size = New System.Drawing.Size(65, 17)
      Me.chbConIVA.TabIndex = 31
      Me.chbConIVA.Text = "Con IVA"
      Me.chbConIVA.UseVisualStyleBackColor = True
      '
      'lblSucursal
      '
      Me.lblSucursal.AutoSize = True
      Me.lblSucursal.ForeColor = System.Drawing.SystemColors.WindowText
      Me.lblSucursal.LabelAsoc = Nothing
      Me.lblSucursal.Location = New System.Drawing.Point(29, 16)
      Me.lblSucursal.Name = "lblSucursal"
      Me.lblSucursal.Size = New System.Drawing.Size(48, 13)
      Me.lblSucursal.TabIndex = 0
      Me.lblSucursal.Text = "Sucursal"
      '
      'cmbSucursal
      '
      Me.cmbSucursal.BindearPropiedadControl = Nothing
      Me.cmbSucursal.BindearPropiedadEntidad = Nothing
      Me.cmbSucursal.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cmbSucursal.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
      Me.cmbSucursal.ForeColorFocus = System.Drawing.Color.Red
      Me.cmbSucursal.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.cmbSucursal.FormattingEnabled = True
      Me.cmbSucursal.IsPK = False
      Me.cmbSucursal.IsRequired = False
      Me.cmbSucursal.ItemHeight = 13
      Me.cmbSucursal.Key = Nothing
      Me.cmbSucursal.LabelAsoc = Me.lblSucursal
      Me.cmbSucursal.Location = New System.Drawing.Point(83, 12)
      Me.cmbSucursal.Name = "cmbSucursal"
      Me.cmbSucursal.Size = New System.Drawing.Size(130, 21)
      Me.cmbSucursal.TabIndex = 1
      '
      'chbListaDePrecios
      '
      Me.chbListaDePrecios.AutoSize = True
      Me.chbListaDePrecios.BindearPropiedadControl = Nothing
      Me.chbListaDePrecios.BindearPropiedadEntidad = Nothing
      Me.chbListaDePrecios.ForeColorFocus = System.Drawing.Color.Red
      Me.chbListaDePrecios.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
      Me.chbListaDePrecios.IsPK = False
      Me.chbListaDePrecios.IsRequired = False
      Me.chbListaDePrecios.Key = Nothing
      Me.chbListaDePrecios.LabelAsoc = Nothing
      Me.chbListaDePrecios.Location = New System.Drawing.Point(569, 13)
      Me.chbListaDePrecios.Name = "chbListaDePrecios"
      Me.chbListaDePrecios.Size = New System.Drawing.Size(101, 17)
      Me.chbListaDePrecios.TabIndex = 5
      Me.chbListaDePrecios.Text = "Lista de Precios"
      Me.chbListaDePrecios.UseVisualStyleBackColor = True
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
      Me.chbCategoria.Location = New System.Drawing.Point(498, 76)
      Me.chbCategoria.Name = "chbCategoria"
      Me.chbCategoria.Size = New System.Drawing.Size(71, 17)
      Me.chbCategoria.TabIndex = 19
      Me.chbCategoria.Text = "Categoria"
      Me.chbCategoria.UseVisualStyleBackColor = True
      '
      'cmbListaDePrecios
      '
      Me.cmbListaDePrecios.BindearPropiedadControl = "SelectedValue"
      Me.cmbListaDePrecios.BindearPropiedadEntidad = "Categoria.IdCategoria"
      Me.cmbListaDePrecios.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cmbListaDePrecios.Enabled = False
      Me.cmbListaDePrecios.ForeColorFocus = System.Drawing.Color.Red
      Me.cmbListaDePrecios.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.cmbListaDePrecios.FormattingEnabled = True
      Me.cmbListaDePrecios.IsPK = False
      Me.cmbListaDePrecios.IsRequired = True
      Me.cmbListaDePrecios.Key = Nothing
      Me.cmbListaDePrecios.LabelAsoc = Nothing
      Me.cmbListaDePrecios.Location = New System.Drawing.Point(676, 11)
      Me.cmbListaDePrecios.Name = "cmbListaDePrecios"
      Me.cmbListaDePrecios.Size = New System.Drawing.Size(144, 21)
      Me.cmbListaDePrecios.TabIndex = 6
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
      Me.cmbCategoria.Location = New System.Drawing.Point(569, 74)
      Me.cmbCategoria.Name = "cmbCategoria"
      Me.cmbCategoria.Size = New System.Drawing.Size(144, 21)
      Me.cmbCategoria.TabIndex = 20
      '
      'bscProveedor
      '
      Me.bscProveedor.AutoSize = True
      Me.bscProveedor.AyudaAncho = 608
      Me.bscProveedor.BindearPropiedadControl = Nothing
      Me.bscProveedor.BindearPropiedadEntidad = Nothing
      Me.bscProveedor.ColumnasAlineacion = Nothing
      Me.bscProveedor.ColumnasAncho = Nothing
      Me.bscProveedor.ColumnasFormato = Nothing
      Me.bscProveedor.ColumnasOcultas = Nothing
      Me.bscProveedor.ColumnasTitulos = Nothing
      Me.bscProveedor.Datos = Nothing
      Me.bscProveedor.Enabled = False
      Me.bscProveedor.FilaDevuelta = Nothing
      Me.bscProveedor.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.bscProveedor.ForeColorFocus = System.Drawing.Color.Red
      Me.bscProveedor.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
      Me.bscProveedor.IsDecimal = False
      Me.bscProveedor.IsNumber = False
      Me.bscProveedor.IsPK = False
      Me.bscProveedor.IsRequired = False
      Me.bscProveedor.Key = ""
      Me.bscProveedor.LabelAsoc = Nothing
      Me.bscProveedor.Location = New System.Drawing.Point(186, 134)
      Me.bscProveedor.Margin = New System.Windows.Forms.Padding(4)
      Me.bscProveedor.MaxLengh = "32767"
      Me.bscProveedor.Name = "bscProveedor"
      Me.bscProveedor.Permitido = True
      Me.bscProveedor.Selecciono = False
      Me.bscProveedor.Size = New System.Drawing.Size(300, 23)
      Me.bscProveedor.TabIndex = 29
      Me.bscProveedor.Titulo = Nothing
      '
      'chbAlertaDeCaja
      '
      Me.chbAlertaDeCaja.AutoSize = True
      Me.chbAlertaDeCaja.BindearPropiedadControl = Nothing
      Me.chbAlertaDeCaja.BindearPropiedadEntidad = Nothing
      Me.chbAlertaDeCaja.ForeColorFocus = System.Drawing.Color.Red
      Me.chbAlertaDeCaja.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
      Me.chbAlertaDeCaja.IsPK = False
      Me.chbAlertaDeCaja.IsRequired = False
      Me.chbAlertaDeCaja.Key = Nothing
      Me.chbAlertaDeCaja.LabelAsoc = Nothing
      Me.chbAlertaDeCaja.Location = New System.Drawing.Point(498, 137)
      Me.chbAlertaDeCaja.Name = "chbAlertaDeCaja"
      Me.chbAlertaDeCaja.Size = New System.Drawing.Size(92, 17)
      Me.chbAlertaDeCaja.TabIndex = 30
      Me.chbAlertaDeCaja.Text = "Alerta de Caja"
      Me.chbAlertaDeCaja.UseVisualStyleBackColor = True
      '
      'bscCodigoProveedor
      '
      Me.bscCodigoProveedor.AyudaAncho = 608
      Me.bscCodigoProveedor.BindearPropiedadControl = Nothing
      Me.bscCodigoProveedor.BindearPropiedadEntidad = Nothing
      Me.bscCodigoProveedor.ColumnasAlineacion = Nothing
      Me.bscCodigoProveedor.ColumnasAncho = Nothing
      Me.bscCodigoProveedor.ColumnasFormato = Nothing
      Me.bscCodigoProveedor.ColumnasOcultas = Nothing
      Me.bscCodigoProveedor.ColumnasTitulos = Nothing
      Me.bscCodigoProveedor.Datos = Nothing
      Me.bscCodigoProveedor.Enabled = False
      Me.bscCodigoProveedor.FilaDevuelta = Nothing
      Me.bscCodigoProveedor.ForeColorFocus = System.Drawing.Color.Red
      Me.bscCodigoProveedor.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
      Me.bscCodigoProveedor.IsDecimal = False
      Me.bscCodigoProveedor.IsNumber = False
      Me.bscCodigoProveedor.IsPK = False
      Me.bscCodigoProveedor.IsRequired = False
      Me.bscCodigoProveedor.Key = ""
      Me.bscCodigoProveedor.LabelAsoc = Nothing
      Me.bscCodigoProveedor.Location = New System.Drawing.Point(89, 134)
      Me.bscCodigoProveedor.MaxLengh = "32767"
      Me.bscCodigoProveedor.Name = "bscCodigoProveedor"
      Me.bscCodigoProveedor.Permitido = True
      Me.bscCodigoProveedor.Selecciono = False
      Me.bscCodigoProveedor.Size = New System.Drawing.Size(90, 23)
      Me.bscCodigoProveedor.TabIndex = 28
      Me.bscCodigoProveedor.Titulo = Nothing
      '
      'chbProveedor
      '
      Me.chbProveedor.AutoSize = True
      Me.chbProveedor.BindearPropiedadControl = Nothing
      Me.chbProveedor.BindearPropiedadEntidad = Nothing
      Me.chbProveedor.ForeColorFocus = System.Drawing.Color.Red
      Me.chbProveedor.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
      Me.chbProveedor.IsPK = False
      Me.chbProveedor.IsRequired = False
      Me.chbProveedor.Key = Nothing
      Me.chbProveedor.LabelAsoc = Nothing
      Me.chbProveedor.Location = New System.Drawing.Point(13, 137)
      Me.chbProveedor.Name = "chbProveedor"
      Me.chbProveedor.Size = New System.Drawing.Size(75, 17)
      Me.chbProveedor.TabIndex = 27
      Me.chbProveedor.Text = "Pro&veedor"
      Me.chbProveedor.UseVisualStyleBackColor = True
      '
      'chkExpandAll
      '
      Me.chkExpandAll.AutoSize = True
      Me.chkExpandAll.Enabled = False
      Me.chkExpandAll.Location = New System.Drawing.Point(759, 125)
      Me.chkExpandAll.Name = "chkExpandAll"
      Me.chkExpandAll.Size = New System.Drawing.Size(104, 17)
      Me.chkExpandAll.TabIndex = 33
      Me.chkExpandAll.Text = "Expandir Grupos"
      '
      'lblPromediar
      '
      Me.lblPromediar.AutoSize = True
      Me.lblPromediar.LabelAsoc = Nothing
      Me.lblPromediar.Location = New System.Drawing.Point(729, 106)
      Me.lblPromediar.Name = "lblPromediar"
      Me.lblPromediar.Size = New System.Drawing.Size(13, 13)
      Me.lblPromediar.TabIndex = 26
      Me.lblPromediar.Text = "1"
      Me.lblPromediar.Visible = False
      '
      'chbPromediar
      '
      Me.chbPromediar.AutoSize = True
      Me.chbPromediar.BindearPropiedadControl = Nothing
      Me.chbPromediar.BindearPropiedadEntidad = Nothing
      Me.chbPromediar.ForeColorFocus = System.Drawing.Color.Red
      Me.chbPromediar.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
      Me.chbPromediar.IsPK = False
      Me.chbPromediar.IsRequired = False
      Me.chbPromediar.Key = Nothing
      Me.chbPromediar.LabelAsoc = Nothing
      Me.chbPromediar.Location = New System.Drawing.Point(569, 104)
      Me.chbPromediar.Name = "chbPromediar"
      Me.chbPromediar.Size = New System.Drawing.Size(153, 17)
      Me.chbPromediar.TabIndex = 25
      Me.chbPromediar.Text = "Promediar por Dias Habiles"
      Me.chbPromediar.UseVisualStyleBackColor = True
      '
      'btnConsultar
      '
      Me.btnConsultar.Image = Global.Eniac.Win.My.Resources.Resources.view
      Me.btnConsultar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
      Me.btnConsultar.Location = New System.Drawing.Point(759, 74)
      Me.btnConsultar.Name = "btnConsultar"
      Me.btnConsultar.Size = New System.Drawing.Size(100, 45)
      Me.btnConsultar.TabIndex = 32
      Me.btnConsultar.Text = "&Consultar"
      Me.btnConsultar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      Me.btnConsultar.UseVisualStyleBackColor = True
      '
      'chbCaja
      '
      Me.chbCaja.AutoSize = True
      Me.chbCaja.BindearPropiedadControl = Nothing
      Me.chbCaja.BindearPropiedadEntidad = Nothing
      Me.chbCaja.ForeColorFocus = System.Drawing.Color.Red
      Me.chbCaja.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
      Me.chbCaja.IsPK = False
      Me.chbCaja.IsRequired = False
      Me.chbCaja.Key = Nothing
      Me.chbCaja.LabelAsoc = Nothing
      Me.chbCaja.Location = New System.Drawing.Point(340, 13)
      Me.chbCaja.Name = "chbCaja"
      Me.chbCaja.Size = New System.Drawing.Size(47, 17)
      Me.chbCaja.TabIndex = 3
      Me.chbCaja.Text = "Caja"
      Me.chbCaja.UseVisualStyleBackColor = True
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
      Me.chbVendedor.Location = New System.Drawing.Point(497, 41)
      Me.chbVendedor.Name = "chbVendedor"
      Me.chbVendedor.Size = New System.Drawing.Size(72, 17)
      Me.chbVendedor.TabIndex = 12
      Me.chbVendedor.Text = "Vendedor"
      Me.chbVendedor.UseVisualStyleBackColor = True
      '
      'cmbCajas
      '
      Me.cmbCajas.BindearPropiedadControl = Nothing
      Me.cmbCajas.BindearPropiedadEntidad = Nothing
      Me.cmbCajas.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cmbCajas.Enabled = False
      Me.cmbCajas.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.cmbCajas.ForeColorFocus = System.Drawing.Color.Red
      Me.cmbCajas.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.cmbCajas.FormattingEnabled = True
      Me.cmbCajas.IsPK = False
      Me.cmbCajas.IsRequired = False
      Me.cmbCajas.Key = Nothing
      Me.cmbCajas.LabelAsoc = Nothing
      Me.cmbCajas.Location = New System.Drawing.Point(402, 11)
      Me.cmbCajas.Name = "cmbCajas"
      Me.cmbCajas.Size = New System.Drawing.Size(144, 21)
      Me.cmbCajas.TabIndex = 4
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
      Me.cmbVendedor.Location = New System.Drawing.Point(569, 39)
      Me.cmbVendedor.Name = "cmbVendedor"
      Me.cmbVendedor.Size = New System.Drawing.Size(144, 21)
      Me.cmbVendedor.TabIndex = 13
      '
      'bscCodigoCliente
      '
      Me.bscCodigoCliente.AyudaAncho = 608
      Me.bscCodigoCliente.BindearPropiedadControl = Nothing
      Me.bscCodigoCliente.BindearPropiedadEntidad = Nothing
      Me.bscCodigoCliente.ColumnasAlineacion = Nothing
      Me.bscCodigoCliente.ColumnasAncho = Nothing
      Me.bscCodigoCliente.ColumnasFormato = Nothing
      Me.bscCodigoCliente.ColumnasOcultas = Nothing
      Me.bscCodigoCliente.ColumnasTitulos = Nothing
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
      Me.bscCodigoCliente.Location = New System.Drawing.Point(89, 74)
      Me.bscCodigoCliente.MaxLengh = "32767"
      Me.bscCodigoCliente.Name = "bscCodigoCliente"
      Me.bscCodigoCliente.Permitido = True
      Me.bscCodigoCliente.Selecciono = False
      Me.bscCodigoCliente.Size = New System.Drawing.Size(90, 23)
      Me.bscCodigoCliente.TabIndex = 15
      Me.bscCodigoCliente.Titulo = Nothing
      '
      'lblCodigoCliente
      '
      Me.lblCodigoCliente.AutoSize = True
      Me.lblCodigoCliente.LabelAsoc = Nothing
      Me.lblCodigoCliente.Location = New System.Drawing.Point(90, 61)
      Me.lblCodigoCliente.Name = "lblCodigoCliente"
      Me.lblCodigoCliente.Size = New System.Drawing.Size(40, 13)
      Me.lblCodigoCliente.TabIndex = 16
      Me.lblCodigoCliente.Text = "Código"
      '
      'bscCliente
      '
      Me.bscCliente.AutoSize = True
      Me.bscCliente.AyudaAncho = 608
      Me.bscCliente.BindearPropiedadControl = Nothing
      Me.bscCliente.BindearPropiedadEntidad = Nothing
      Me.bscCliente.ColumnasAlineacion = Nothing
      Me.bscCliente.ColumnasAncho = Nothing
      Me.bscCliente.ColumnasFormato = Nothing
      Me.bscCliente.ColumnasOcultas = Nothing
      Me.bscCliente.ColumnasTitulos = Nothing
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
      Me.bscCliente.Location = New System.Drawing.Point(186, 74)
      Me.bscCliente.Margin = New System.Windows.Forms.Padding(4)
      Me.bscCliente.MaxLengh = "32767"
      Me.bscCliente.Name = "bscCliente"
      Me.bscCliente.Permitido = True
      Me.bscCliente.Selecciono = False
      Me.bscCliente.Size = New System.Drawing.Size(300, 23)
      Me.bscCliente.TabIndex = 17
      Me.bscCliente.Titulo = Nothing
      '
      'lblNombre
      '
      Me.lblNombre.AutoSize = True
      Me.lblNombre.LabelAsoc = Nothing
      Me.lblNombre.Location = New System.Drawing.Point(187, 61)
      Me.lblNombre.Name = "lblNombre"
      Me.lblNombre.Size = New System.Drawing.Size(44, 13)
      Me.lblNombre.TabIndex = 18
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
      Me.chbCliente.Location = New System.Drawing.Point(13, 77)
      Me.chbCliente.Name = "chbCliente"
      Me.chbCliente.Size = New System.Drawing.Size(58, 17)
      Me.chbCliente.TabIndex = 14
      Me.chbCliente.Text = "Cliente"
      Me.chbCliente.UseVisualStyleBackColor = True
      '
      'chbRubro
      '
      Me.chbRubro.AutoSize = True
      Me.chbRubro.BindearPropiedadControl = Nothing
      Me.chbRubro.BindearPropiedadEntidad = Nothing
      Me.chbRubro.ForeColorFocus = System.Drawing.Color.Red
      Me.chbRubro.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
      Me.chbRubro.IsPK = False
      Me.chbRubro.IsRequired = False
      Me.chbRubro.Key = Nothing
      Me.chbRubro.LabelAsoc = Nothing
      Me.chbRubro.Location = New System.Drawing.Point(301, 102)
      Me.chbRubro.Name = "chbRubro"
      Me.chbRubro.Size = New System.Drawing.Size(55, 17)
      Me.chbRubro.TabIndex = 23
      Me.chbRubro.Text = "Rubro"
      Me.chbRubro.UseVisualStyleBackColor = True
      '
      'cmbRubro
      '
      Me.cmbRubro.BindearPropiedadControl = Nothing
      Me.cmbRubro.BindearPropiedadEntidad = Nothing
      Me.cmbRubro.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cmbRubro.Enabled = False
      Me.cmbRubro.ForeColorFocus = System.Drawing.Color.Red
      Me.cmbRubro.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.cmbRubro.FormattingEnabled = True
      Me.cmbRubro.IsPK = False
      Me.cmbRubro.IsRequired = False
      Me.cmbRubro.Key = Nothing
      Me.cmbRubro.LabelAsoc = Nothing
      Me.cmbRubro.Location = New System.Drawing.Point(359, 100)
      Me.cmbRubro.Name = "cmbRubro"
      Me.cmbRubro.Size = New System.Drawing.Size(200, 21)
      Me.cmbRubro.TabIndex = 24
      '
      'chbMarca
      '
      Me.chbMarca.AutoSize = True
      Me.chbMarca.BindearPropiedadControl = Nothing
      Me.chbMarca.BindearPropiedadEntidad = Nothing
      Me.chbMarca.ForeColorFocus = System.Drawing.Color.Red
      Me.chbMarca.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
      Me.chbMarca.IsPK = False
      Me.chbMarca.IsRequired = False
      Me.chbMarca.Key = Nothing
      Me.chbMarca.LabelAsoc = Nothing
      Me.chbMarca.Location = New System.Drawing.Point(13, 102)
      Me.chbMarca.Name = "chbMarca"
      Me.chbMarca.Size = New System.Drawing.Size(56, 17)
      Me.chbMarca.TabIndex = 21
      Me.chbMarca.Text = "Marca"
      Me.chbMarca.UseVisualStyleBackColor = True
      '
      'cmbMarca
      '
      Me.cmbMarca.BindearPropiedadControl = Nothing
      Me.cmbMarca.BindearPropiedadEntidad = Nothing
      Me.cmbMarca.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cmbMarca.Enabled = False
      Me.cmbMarca.ForeColorFocus = System.Drawing.Color.Red
      Me.cmbMarca.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.cmbMarca.FormattingEnabled = True
      Me.cmbMarca.IsPK = False
      Me.cmbMarca.IsRequired = False
      Me.cmbMarca.Key = Nothing
      Me.cmbMarca.LabelAsoc = Nothing
      Me.cmbMarca.Location = New System.Drawing.Point(89, 100)
      Me.cmbMarca.Name = "cmbMarca"
      Me.cmbMarca.Size = New System.Drawing.Size(200, 21)
      Me.cmbMarca.TabIndex = 22
      '
      'chbMesCompleto
      '
      Me.chbMesCompleto.AutoSize = True
      Me.chbMesCompleto.BindearPropiedadControl = Nothing
      Me.chbMesCompleto.BindearPropiedadEntidad = Nothing
      Me.chbMesCompleto.ForeColorFocus = System.Drawing.Color.Red
      Me.chbMesCompleto.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
      Me.chbMesCompleto.IsPK = False
      Me.chbMesCompleto.IsRequired = False
      Me.chbMesCompleto.Key = Nothing
      Me.chbMesCompleto.LabelAsoc = Nothing
      Me.chbMesCompleto.Location = New System.Drawing.Point(13, 41)
      Me.chbMesCompleto.Name = "chbMesCompleto"
      Me.chbMesCompleto.Size = New System.Drawing.Size(93, 17)
      Me.chbMesCompleto.TabIndex = 7
      Me.chbMesCompleto.Text = "Mes Completo"
      Me.chbMesCompleto.UseVisualStyleBackColor = True
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
      Me.dtpHasta.Location = New System.Drawing.Point(336, 39)
      Me.dtpHasta.Name = "dtpHasta"
      Me.dtpHasta.Size = New System.Drawing.Size(125, 20)
      Me.dtpHasta.TabIndex = 11
      '
      'lblHasta
      '
      Me.lblHasta.AutoSize = True
      Me.lblHasta.LabelAsoc = Nothing
      Me.lblHasta.Location = New System.Drawing.Point(297, 43)
      Me.lblHasta.Name = "lblHasta"
      Me.lblHasta.Size = New System.Drawing.Size(35, 13)
      Me.lblHasta.TabIndex = 10
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
      Me.dtpDesde.Location = New System.Drawing.Point(160, 39)
      Me.dtpDesde.Name = "dtpDesde"
      Me.dtpDesde.Size = New System.Drawing.Size(125, 20)
      Me.dtpDesde.TabIndex = 9
      '
      'lblDesde
      '
      Me.lblDesde.AutoSize = True
      Me.lblDesde.LabelAsoc = Nothing
      Me.lblDesde.Location = New System.Drawing.Point(118, 43)
      Me.lblDesde.Name = "lblDesde"
      Me.lblDesde.Size = New System.Drawing.Size(38, 13)
      Me.lblDesde.TabIndex = 8
      Me.lblDesde.Text = "Desde"
      '
      'tstBarra
      '
      Me.tstBarra.AllowItemReorder = True
      Me.tstBarra.ImageScalingSize = New System.Drawing.Size(22, 22)
      Me.tstBarra.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsbRefrescar, Me.ToolStripSeparator2, Me.tsbImprimir, Me.toolStripSeparator3, Me.tsddExportar, Me.ToolStripSeparator1, Me.tsbPreferencias, Me.ToolStripSeparator4, Me.tsbSalir})
      Me.tstBarra.Location = New System.Drawing.Point(0, 0)
      Me.tstBarra.Name = "tstBarra"
      Me.tstBarra.Size = New System.Drawing.Size(892, 29)
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
      'toolStripSeparator3
      '
      Me.toolStripSeparator3.Name = "toolStripSeparator3"
      Me.toolStripSeparator3.Size = New System.Drawing.Size(6, 29)
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
      'ToolStripSeparator1
      '
      Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
      Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 29)
      '
      'tsbPreferencias
      '
      Me.tsbPreferencias.Image = Global.Eniac.Win.My.Resources.Resources.window_ok_24
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
      'UltraDataSource1
      '
      Me.UltraDataSource1.Band.Columns.AddRange(New Object() {UltraDataColumn1, UltraDataColumn2, UltraDataColumn3, UltraDataColumn4, UltraDataColumn5, UltraDataColumn6, UltraDataColumn7, UltraDataColumn8, UltraDataColumn9, UltraDataColumn10, UltraDataColumn11, UltraDataColumn12, UltraDataColumn13, UltraDataColumn14, UltraDataColumn15, UltraDataColumn16, UltraDataColumn17, UltraDataColumn18, UltraDataColumn19, UltraDataColumn20, UltraDataColumn21, UltraDataColumn22, UltraDataColumn23, UltraDataColumn24, UltraDataColumn25, UltraDataColumn26, UltraDataColumn27})
      '
      'ugDetalle
      '
      Appearance1.BackColor = System.Drawing.SystemColors.Window
      Appearance1.BorderColor = System.Drawing.SystemColors.InactiveCaption
      Me.ugDetalle.DisplayLayout.Appearance = Appearance1
      UltraGridColumn2.Header.Caption = "Rubro"
      UltraGridColumn2.Header.VisiblePosition = 1
      UltraGridColumn2.Width = 210
      UltraGridColumn16.Header.Caption = "Lista de Precios"
      UltraGridColumn16.Header.VisiblePosition = 2
      UltraGridColumn16.Width = 130
      UltraGridColumn17.Header.Caption = "Forma de Pago"
      UltraGridColumn17.Header.VisiblePosition = 3
      UltraGridColumn17.Width = 130
      Appearance2.TextHAlignAsString = "Right"
      UltraGridColumn6.CellAppearance = Appearance2
      UltraGridColumn6.Format = "##,##0.00"
      UltraGridColumn6.Header.Caption = "Neto"
      UltraGridColumn6.Header.VisiblePosition = 5
      UltraGridColumn6.Width = 80
      Appearance3.TextHAlignAsString = "Right"
      UltraGridColumn7.CellAppearance = Appearance3
      UltraGridColumn7.Format = "##,##0.00"
      UltraGridColumn7.Header.Caption = "Total"
      UltraGridColumn7.Header.VisiblePosition = 6
      UltraGridColumn7.Hidden = True
      UltraGridColumn7.Width = 80
      Appearance4.TextHAlignAsString = "Right"
      UltraGridColumn8.CellAppearance = Appearance4
      UltraGridColumn8.Format = "##,##0.00"
      UltraGridColumn8.Header.VisiblePosition = 7
      UltraGridColumn8.Width = 80
      Appearance5.TextHAlignAsString = "Right"
      UltraGridColumn9.CellAppearance = Appearance5
      UltraGridColumn9.Format = "##,##0.00"
      UltraGridColumn9.Header.VisiblePosition = 4
      UltraGridColumn9.Width = 80
      Appearance6.TextHAlignAsString = "Right"
      UltraGridColumn10.CellAppearance = Appearance6
      UltraGridColumn10.Format = "##,##0.00"
      UltraGridColumn10.Header.VisiblePosition = 8
      UltraGridColumn10.Width = 70
      UltraGridColumn15.Header.Caption = "S."
      UltraGridColumn15.Header.VisiblePosition = 0
      UltraGridColumn15.Width = 25
      UltraGridBand1.Columns.AddRange(New Object() {UltraGridColumn2, UltraGridColumn16, UltraGridColumn17, UltraGridColumn6, UltraGridColumn7, UltraGridColumn8, UltraGridColumn9, UltraGridColumn10, UltraGridColumn15})
      Me.ugDetalle.DisplayLayout.BandsSerializer.Add(UltraGridBand1)
      Me.ugDetalle.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
      Me.ugDetalle.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.[False]
      Appearance7.BackColor = System.Drawing.SystemColors.ActiveBorder
      Appearance7.BackColor2 = System.Drawing.SystemColors.ControlDark
      Appearance7.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
      Appearance7.BorderColor = System.Drawing.SystemColors.Window
      Me.ugDetalle.DisplayLayout.GroupByBox.Appearance = Appearance7
      Appearance8.ForeColor = System.Drawing.SystemColors.GrayText
      Me.ugDetalle.DisplayLayout.GroupByBox.BandLabelAppearance = Appearance8
      Me.ugDetalle.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
      Me.ugDetalle.DisplayLayout.GroupByBox.Prompt = "Arrastre un título de columna aquí para agrupar."
      Appearance9.BackColor = System.Drawing.SystemColors.ControlLightLight
      Appearance9.BackColor2 = System.Drawing.SystemColors.Control
      Appearance9.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
      Appearance9.ForeColor = System.Drawing.SystemColors.GrayText
      Me.ugDetalle.DisplayLayout.GroupByBox.PromptAppearance = Appearance9
      Me.ugDetalle.DisplayLayout.MaxColScrollRegions = 1
      Me.ugDetalle.DisplayLayout.MaxRowScrollRegions = 1
      Appearance10.BackColor = System.Drawing.SystemColors.Window
      Appearance10.ForeColor = System.Drawing.SystemColors.ControlText
      Me.ugDetalle.DisplayLayout.Override.ActiveCellAppearance = Appearance10
      Appearance11.BackColor = System.Drawing.SystemColors.Highlight
      Appearance11.ForeColor = System.Drawing.SystemColors.HighlightText
      Me.ugDetalle.DisplayLayout.Override.ActiveRowAppearance = Appearance11
      Me.ugDetalle.DisplayLayout.Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.No
      Me.ugDetalle.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.[False]
      Me.ugDetalle.DisplayLayout.Override.AllowUpdate = Infragistics.Win.DefaultableBoolean.[False]
      Me.ugDetalle.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted
      Me.ugDetalle.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted
      Appearance12.BackColor = System.Drawing.SystemColors.Window
      Me.ugDetalle.DisplayLayout.Override.CardAreaAppearance = Appearance12
      Appearance13.BorderColor = System.Drawing.Color.Silver
      Appearance13.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter
      Me.ugDetalle.DisplayLayout.Override.CellAppearance = Appearance13
      Me.ugDetalle.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText
      Me.ugDetalle.DisplayLayout.Override.CellPadding = 0
      Appearance14.BackColor = System.Drawing.SystemColors.Control
      Appearance14.BackColor2 = System.Drawing.SystemColors.ControlDark
      Appearance14.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element
      Appearance14.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
      Appearance14.BorderColor = System.Drawing.SystemColors.Window
      Me.ugDetalle.DisplayLayout.Override.GroupByRowAppearance = Appearance14
      Appearance15.TextHAlignAsString = "Left"
      Me.ugDetalle.DisplayLayout.Override.HeaderAppearance = Appearance15
      Me.ugDetalle.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
      Me.ugDetalle.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand
      Appearance16.BackColor = System.Drawing.SystemColors.Window
      Appearance16.BorderColor = System.Drawing.Color.Silver
      Me.ugDetalle.DisplayLayout.Override.RowAppearance = Appearance16
      Me.ugDetalle.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[False]
      Appearance17.BackColor = System.Drawing.SystemColors.ControlLight
      Me.ugDetalle.DisplayLayout.Override.TemplateAddRowAppearance = Appearance17
      Me.ugDetalle.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill
      Me.ugDetalle.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate
      Me.ugDetalle.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy
      Me.ugDetalle.Dock = System.Windows.Forms.DockStyle.Fill
      Me.ugDetalle.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.ugDetalle.Location = New System.Drawing.Point(3, 3)
      Me.ugDetalle.Name = "ugDetalle"
      Me.ugDetalle.Size = New System.Drawing.Size(859, 286)
      Me.ugDetalle.TabIndex = 1
      '
      'UltraGridPrintDocument1
      '
      Me.UltraGridPrintDocument1.DocumentName = "Informe"
      Me.UltraGridPrintDocument1.Footer.TextCenter = ""
      Me.UltraGridPrintDocument1.Grid = Me.ugDetalle
      Appearance18.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
      Appearance18.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element
      Appearance18.BackGradientStyle = Infragistics.Win.GradientStyle.VerticalBump
      Me.UltraGridPrintDocument1.Header.Appearance = Appearance18
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
      Me.UltraPrintPreviewDialog1.AutoValidate = System.Windows.Forms.AutoValidate.EnablePreventFocusChange
      Me.UltraPrintPreviewDialog1.Name = "UltraPrintPreviewDialog1"
      '
      'stsStado
      '
      Me.stsStado.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tssInfo, Me.tspBarra, Me.tssRegistros})
      Me.stsStado.Location = New System.Drawing.Point(0, 531)
      Me.stsStado.Name = "stsStado"
      Me.stsStado.Size = New System.Drawing.Size(892, 22)
      Me.stsStado.TabIndex = 2
      Me.stsStado.Text = "statusStrip1"
      '
      'tssInfo
      '
      Me.tssInfo.Name = "tssInfo"
      Me.tssInfo.Size = New System.Drawing.Size(813, 17)
      Me.tssInfo.Spring = True
      '
      'tspBarra
      '
      Me.tspBarra.Name = "tspBarra"
      Me.tspBarra.Size = New System.Drawing.Size(0, 17)
      Me.tspBarra.Visible = False
      '
      'tssRegistros
      '
      Me.tssRegistros.Name = "tssRegistros"
      Me.tssRegistros.Size = New System.Drawing.Size(64, 17)
      Me.tssRegistros.Text = "0 Registros"
      '
      'tbcAgrupados
      '
      Me.tbcAgrupados.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.tbcAgrupados.Controls.Add(Me.tbpXRubros)
      Me.tbcAgrupados.Controls.Add(Me.tbpXListaPrecios)
      Me.tbcAgrupados.Controls.Add(Me.tbpXZonaGeografica)
      Me.tbcAgrupados.Location = New System.Drawing.Point(9, 203)
      Me.tbcAgrupados.Name = "tbcAgrupados"
      Me.tbcAgrupados.SelectedIndex = 0
      Me.tbcAgrupados.Size = New System.Drawing.Size(873, 318)
      Me.tbcAgrupados.TabIndex = 4
      '
      'tbpXRubros
      '
      Me.tbpXRubros.Controls.Add(Me.ugDetalleXRubro)
      Me.tbpXRubros.Location = New System.Drawing.Point(4, 22)
      Me.tbpXRubros.Name = "tbpXRubros"
      Me.tbpXRubros.Size = New System.Drawing.Size(865, 292)
      Me.tbpXRubros.TabIndex = 2
      Me.tbpXRubros.Text = "x Rubro"
      Me.tbpXRubros.UseVisualStyleBackColor = True
      '
      'ugDetalleXRubro
      '
      Appearance19.BackColor = System.Drawing.SystemColors.Window
      Appearance19.BorderColor = System.Drawing.SystemColors.InactiveCaption
      Me.ugDetalleXRubro.DisplayLayout.Appearance = Appearance19
      Appearance20.TextHAlignAsString = "Right"
      UltraGridColumn1.CellAppearance = Appearance20
      UltraGridColumn1.Header.Caption = "S."
      UltraGridColumn1.Header.VisiblePosition = 0
      UltraGridColumn1.Hidden = True
      UltraGridColumn3.Header.Caption = "Rubro"
      UltraGridColumn3.Header.VisiblePosition = 1
      UltraGridColumn3.Width = 186
      Appearance21.TextHAlignAsString = "Right"
      UltraGridColumn4.CellAppearance = Appearance21
      UltraGridColumn4.Format = "N2"
      UltraGridColumn4.Header.VisiblePosition = 6
      UltraGridColumn4.Width = 82
      Appearance22.TextHAlignAsString = "Right"
      UltraGridColumn5.CellAppearance = Appearance22
      UltraGridColumn5.Format = "N2"
      UltraGridColumn5.Header.VisiblePosition = 2
      UltraGridColumn5.Width = 73
      Appearance23.TextHAlignAsString = "Right"
      UltraGridColumn14.CellAppearance = Appearance23
      UltraGridColumn14.Format = "N2"
      UltraGridColumn14.Header.Caption = "Neto"
      UltraGridColumn14.Header.VisiblePosition = 3
      UltraGridColumn14.Width = 96
      Appearance24.TextHAlignAsString = "Right"
      UltraGridColumn18.CellAppearance = Appearance24
      UltraGridColumn18.Format = "N2"
      UltraGridColumn18.Header.Caption = "Total"
      UltraGridColumn18.Header.VisiblePosition = 4
      Appearance25.TextHAlignAsString = "Right"
      UltraGridColumn13.CellAppearance = Appearance25
      UltraGridColumn13.Format = "N2"
      UltraGridColumn13.Header.VisiblePosition = 5
      UltraGridColumn13.Width = 79
      UltraGridBand2.Columns.AddRange(New Object() {UltraGridColumn1, UltraGridColumn3, UltraGridColumn4, UltraGridColumn5, UltraGridColumn14, UltraGridColumn18, UltraGridColumn13})
      Me.ugDetalleXRubro.DisplayLayout.BandsSerializer.Add(UltraGridBand2)
      Me.ugDetalleXRubro.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
      Me.ugDetalleXRubro.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.[False]
      Appearance26.BackColor = System.Drawing.SystemColors.ActiveBorder
      Appearance26.BackColor2 = System.Drawing.SystemColors.ControlDark
      Appearance26.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
      Appearance26.BorderColor = System.Drawing.SystemColors.Window
      Me.ugDetalleXRubro.DisplayLayout.GroupByBox.Appearance = Appearance26
      Appearance27.ForeColor = System.Drawing.SystemColors.GrayText
      Me.ugDetalleXRubro.DisplayLayout.GroupByBox.BandLabelAppearance = Appearance27
      Me.ugDetalleXRubro.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
      Me.ugDetalleXRubro.DisplayLayout.GroupByBox.Prompt = "Arrastre un título de columna aquí para agrupar."
      Appearance28.BackColor = System.Drawing.SystemColors.ControlLightLight
      Appearance28.BackColor2 = System.Drawing.SystemColors.Control
      Appearance28.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
      Appearance28.ForeColor = System.Drawing.SystemColors.GrayText
      Me.ugDetalleXRubro.DisplayLayout.GroupByBox.PromptAppearance = Appearance28
      Me.ugDetalleXRubro.DisplayLayout.MaxColScrollRegions = 1
      Me.ugDetalleXRubro.DisplayLayout.MaxRowScrollRegions = 1
      Appearance29.BackColor = System.Drawing.SystemColors.Window
      Appearance29.ForeColor = System.Drawing.SystemColors.ControlText
      Me.ugDetalleXRubro.DisplayLayout.Override.ActiveCellAppearance = Appearance29
      Appearance30.BackColor = System.Drawing.SystemColors.Highlight
      Appearance30.ForeColor = System.Drawing.SystemColors.HighlightText
      Me.ugDetalleXRubro.DisplayLayout.Override.ActiveRowAppearance = Appearance30
      Me.ugDetalleXRubro.DisplayLayout.Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.No
      Me.ugDetalleXRubro.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.[False]
      Me.ugDetalleXRubro.DisplayLayout.Override.AllowUpdate = Infragistics.Win.DefaultableBoolean.[False]
      Me.ugDetalleXRubro.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted
      Me.ugDetalleXRubro.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted
      Appearance31.BackColor = System.Drawing.SystemColors.Window
      Me.ugDetalleXRubro.DisplayLayout.Override.CardAreaAppearance = Appearance31
      Appearance32.BorderColor = System.Drawing.Color.Silver
      Appearance32.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter
      Me.ugDetalleXRubro.DisplayLayout.Override.CellAppearance = Appearance32
      Me.ugDetalleXRubro.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText
      Me.ugDetalleXRubro.DisplayLayout.Override.CellPadding = 0
      Appearance33.BackColor = System.Drawing.SystemColors.Control
      Appearance33.BackColor2 = System.Drawing.SystemColors.ControlDark
      Appearance33.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element
      Appearance33.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
      Appearance33.BorderColor = System.Drawing.SystemColors.Window
      Me.ugDetalleXRubro.DisplayLayout.Override.GroupByRowAppearance = Appearance33
      Appearance34.TextHAlignAsString = "Left"
      Me.ugDetalleXRubro.DisplayLayout.Override.HeaderAppearance = Appearance34
      Me.ugDetalleXRubro.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
      Me.ugDetalleXRubro.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand
      Appearance35.BackColor = System.Drawing.SystemColors.Window
      Appearance35.BorderColor = System.Drawing.Color.Silver
      Me.ugDetalleXRubro.DisplayLayout.Override.RowAppearance = Appearance35
      Me.ugDetalleXRubro.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[False]
      Appearance36.BackColor = System.Drawing.SystemColors.ControlLight
      Me.ugDetalleXRubro.DisplayLayout.Override.TemplateAddRowAppearance = Appearance36
      Me.ugDetalleXRubro.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill
      Me.ugDetalleXRubro.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate
      Me.ugDetalleXRubro.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy
      Me.ugDetalleXRubro.Dock = System.Windows.Forms.DockStyle.Fill
      Me.ugDetalleXRubro.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.ugDetalleXRubro.Location = New System.Drawing.Point(0, 0)
      Me.ugDetalleXRubro.Name = "ugDetalleXRubro"
      Me.ugDetalleXRubro.Size = New System.Drawing.Size(865, 292)
      Me.ugDetalleXRubro.TabIndex = 4
      '
      'tbpXListaPrecios
      '
      Me.tbpXListaPrecios.Controls.Add(Me.ugDetalle)
      Me.tbpXListaPrecios.Location = New System.Drawing.Point(4, 22)
      Me.tbpXListaPrecios.Name = "tbpXListaPrecios"
      Me.tbpXListaPrecios.Padding = New System.Windows.Forms.Padding(3)
      Me.tbpXListaPrecios.Size = New System.Drawing.Size(865, 292)
      Me.tbpXListaPrecios.TabIndex = 0
      Me.tbpXListaPrecios.Text = "x Lista"
      Me.tbpXListaPrecios.UseVisualStyleBackColor = True
      '
      'tbpXZonaGeografica
      '
      Me.tbpXZonaGeografica.Controls.Add(Me.ugvXZona)
      Me.tbpXZonaGeografica.Location = New System.Drawing.Point(4, 22)
      Me.tbpXZonaGeografica.Name = "tbpXZonaGeografica"
      Me.tbpXZonaGeografica.Padding = New System.Windows.Forms.Padding(3)
      Me.tbpXZonaGeografica.Size = New System.Drawing.Size(865, 292)
      Me.tbpXZonaGeografica.TabIndex = 1
      Me.tbpXZonaGeografica.Text = "x Zona"
      Me.tbpXZonaGeografica.UseVisualStyleBackColor = True
      '
      'ugvXZona
      '
      Appearance37.BackColor = System.Drawing.SystemColors.Window
      Appearance37.BorderColor = System.Drawing.SystemColors.InactiveCaption
      Me.ugvXZona.DisplayLayout.Appearance = Appearance37
      Appearance38.TextHAlignAsString = "Right"
      UltraGridColumn11.CellAppearance = Appearance38
      UltraGridColumn11.Format = "N2"
      UltraGridColumn11.Header.Caption = "S."
      UltraGridColumn11.Header.VisiblePosition = 0
      UltraGridColumn11.Hidden = True
      UltraGridColumn12.Header.Caption = "Rubro"
      UltraGridColumn12.Header.VisiblePosition = 1
      UltraGridColumn12.Width = 199
      UltraGridColumn19.Format = ""
      UltraGridColumn19.Header.Caption = "Zona"
      UltraGridColumn19.Header.VisiblePosition = 2
      UltraGridColumn19.Width = 130
      Appearance39.TextHAlignAsString = "Right"
      UltraGridColumn20.CellAppearance = Appearance39
      UltraGridColumn20.Format = "N2"
      UltraGridColumn20.Header.Caption = "Neto"
      UltraGridColumn20.Header.VisiblePosition = 4
      UltraGridColumn20.Width = 95
      Appearance40.TextHAlignAsString = "Right"
      UltraGridColumn21.CellAppearance = Appearance40
      UltraGridColumn21.Format = "N2"
      UltraGridColumn21.Header.Caption = "Total"
      UltraGridColumn21.Header.VisiblePosition = 5
      UltraGridColumn21.Width = 90
      Appearance41.TextHAlignAsString = "Right"
      UltraGridColumn22.CellAppearance = Appearance41
      UltraGridColumn22.Format = "N2"
      UltraGridColumn22.Header.VisiblePosition = 6
      Appearance42.TextHAlignAsString = "Right"
      UltraGridColumn23.CellAppearance = Appearance42
      UltraGridColumn23.Format = "N2"
      UltraGridColumn23.Header.VisiblePosition = 3
      UltraGridColumn23.Width = 88
      Appearance43.TextHAlignAsString = "Right"
      UltraGridColumn24.CellAppearance = Appearance43
      UltraGridColumn24.Format = "N2"
      UltraGridColumn24.Header.VisiblePosition = 7
      UltraGridColumn24.Width = 81
      UltraGridBand3.Columns.AddRange(New Object() {UltraGridColumn11, UltraGridColumn12, UltraGridColumn19, UltraGridColumn20, UltraGridColumn21, UltraGridColumn22, UltraGridColumn23, UltraGridColumn24})
      Me.ugvXZona.DisplayLayout.BandsSerializer.Add(UltraGridBand3)
      Me.ugvXZona.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
      Me.ugvXZona.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.[False]
      Appearance44.BackColor = System.Drawing.SystemColors.ActiveBorder
      Appearance44.BackColor2 = System.Drawing.SystemColors.ControlDark
      Appearance44.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
      Appearance44.BorderColor = System.Drawing.SystemColors.Window
      Me.ugvXZona.DisplayLayout.GroupByBox.Appearance = Appearance44
      Appearance45.ForeColor = System.Drawing.SystemColors.GrayText
      Me.ugvXZona.DisplayLayout.GroupByBox.BandLabelAppearance = Appearance45
      Me.ugvXZona.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
      Me.ugvXZona.DisplayLayout.GroupByBox.Prompt = "Arrastre un título de columna aquí para agrupar."
      Appearance46.BackColor = System.Drawing.SystemColors.ControlLightLight
      Appearance46.BackColor2 = System.Drawing.SystemColors.Control
      Appearance46.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
      Appearance46.ForeColor = System.Drawing.SystemColors.GrayText
      Me.ugvXZona.DisplayLayout.GroupByBox.PromptAppearance = Appearance46
      Me.ugvXZona.DisplayLayout.MaxColScrollRegions = 1
      Me.ugvXZona.DisplayLayout.MaxRowScrollRegions = 1
      Appearance47.BackColor = System.Drawing.SystemColors.Window
      Appearance47.ForeColor = System.Drawing.SystemColors.ControlText
      Me.ugvXZona.DisplayLayout.Override.ActiveCellAppearance = Appearance47
      Appearance48.BackColor = System.Drawing.SystemColors.Highlight
      Appearance48.ForeColor = System.Drawing.SystemColors.HighlightText
      Me.ugvXZona.DisplayLayout.Override.ActiveRowAppearance = Appearance48
      Me.ugvXZona.DisplayLayout.Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.No
      Me.ugvXZona.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.[False]
      Me.ugvXZona.DisplayLayout.Override.AllowUpdate = Infragistics.Win.DefaultableBoolean.[False]
      Me.ugvXZona.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted
      Me.ugvXZona.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted
      Appearance49.BackColor = System.Drawing.SystemColors.Window
      Me.ugvXZona.DisplayLayout.Override.CardAreaAppearance = Appearance49
      Appearance50.BorderColor = System.Drawing.Color.Silver
      Appearance50.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter
      Me.ugvXZona.DisplayLayout.Override.CellAppearance = Appearance50
      Me.ugvXZona.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText
      Me.ugvXZona.DisplayLayout.Override.CellPadding = 0
      Appearance51.BackColor = System.Drawing.SystemColors.Control
      Appearance51.BackColor2 = System.Drawing.SystemColors.ControlDark
      Appearance51.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element
      Appearance51.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
      Appearance51.BorderColor = System.Drawing.SystemColors.Window
      Me.ugvXZona.DisplayLayout.Override.GroupByRowAppearance = Appearance51
      Appearance52.TextHAlignAsString = "Left"
      Me.ugvXZona.DisplayLayout.Override.HeaderAppearance = Appearance52
      Me.ugvXZona.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
      Me.ugvXZona.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand
      Appearance53.BackColor = System.Drawing.SystemColors.Window
      Appearance53.BorderColor = System.Drawing.Color.Silver
      Me.ugvXZona.DisplayLayout.Override.RowAppearance = Appearance53
      Me.ugvXZona.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[False]
      Appearance54.BackColor = System.Drawing.SystemColors.ControlLight
      Me.ugvXZona.DisplayLayout.Override.TemplateAddRowAppearance = Appearance54
      Me.ugvXZona.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill
      Me.ugvXZona.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate
      Me.ugvXZona.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy
      Me.ugvXZona.Dock = System.Windows.Forms.DockStyle.Fill
      Me.ugvXZona.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.ugvXZona.Location = New System.Drawing.Point(3, 3)
      Me.ugvXZona.Name = "ugvXZona"
      Me.ugvXZona.Size = New System.Drawing.Size(859, 286)
      Me.ugvXZona.TabIndex = 3
      '
      'InfVentasSumaPorRubros
      '
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.ClientSize = New System.Drawing.Size(892, 553)
      Me.Controls.Add(Me.tbcAgrupados)
      Me.Controls.Add(Me.stsStado)
      Me.Controls.Add(Me.tstBarra)
      Me.Controls.Add(Me.grbConsultar)
      Me.KeyPreview = True
      Me.Name = "InfVentasSumaPorRubros"
      Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
      Me.Text = "Informe de Venta Suma por Rubros"
      Me.grbConsultar.ResumeLayout(False)
      Me.grbConsultar.PerformLayout()
      Me.tstBarra.ResumeLayout(False)
      Me.tstBarra.PerformLayout()
      CType(Me.UltraDataSource1, System.ComponentModel.ISupportInitialize).EndInit()
      CType(Me.ugDetalle, System.ComponentModel.ISupportInitialize).EndInit()
      Me.stsStado.ResumeLayout(False)
      Me.stsStado.PerformLayout()
      Me.tbcAgrupados.ResumeLayout(False)
      Me.tbpXRubros.ResumeLayout(False)
      CType(Me.ugDetalleXRubro, System.ComponentModel.ISupportInitialize).EndInit()
      Me.tbpXListaPrecios.ResumeLayout(False)
      Me.tbpXZonaGeografica.ResumeLayout(False)
      CType(Me.ugvXZona, System.ComponentModel.ISupportInitialize).EndInit()
      CType(Me.UltraDataSource2, System.ComponentModel.ISupportInitialize).EndInit()
      Me.ResumeLayout(False)
      Me.PerformLayout()

   End Sub
   Friend WithEvents grbConsultar As System.Windows.Forms.GroupBox
   Public WithEvents tstBarra As System.Windows.Forms.ToolStrip
   Public WithEvents tsbSalir As System.Windows.Forms.ToolStripButton
   Friend WithEvents dtpHasta As Eniac.Controles.DateTimePicker
   Friend WithEvents lblHasta As Eniac.Controles.Label
   Friend WithEvents dtpDesde As Eniac.Controles.DateTimePicker
   Friend WithEvents lblDesde As Eniac.Controles.Label
   Friend WithEvents chbMesCompleto As Eniac.Controles.CheckBox
   Public WithEvents tsbRefrescar As System.Windows.Forms.ToolStripButton
   Friend WithEvents chbRubro As Eniac.Controles.CheckBox
   Friend WithEvents cmbRubro As Eniac.Controles.ComboBox
   Friend WithEvents chbMarca As Eniac.Controles.CheckBox
   Friend WithEvents cmbMarca As Eniac.Controles.ComboBox
   Friend WithEvents bscCodigoCliente As Eniac.Controles.Buscador
   Friend WithEvents lblCodigoCliente As Eniac.Controles.Label
   Friend WithEvents bscCliente As Eniac.Controles.Buscador
   Friend WithEvents lblNombre As Eniac.Controles.Label
   Friend WithEvents chbCliente As Eniac.Controles.CheckBox
   Private WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
   Friend WithEvents chbVendedor As Eniac.Controles.CheckBox
   Friend WithEvents cmbVendedor As Eniac.Controles.ComboBox
   Friend WithEvents btnConsultar As Eniac.Controles.Button
   Friend WithEvents chbPromediar As Eniac.Controles.CheckBox
   Friend WithEvents lblPromediar As Eniac.Controles.Label
   Friend WithEvents UltraDataSource1 As Infragistics.Win.UltraWinDataSource.UltraDataSource
   Friend WithEvents UltraGridDocumentExporter1 As Infragistics.Win.UltraWinGrid.DocumentExport.UltraGridDocumentExporter
   Friend WithEvents UltraGridExcelExporter1 As Infragistics.Win.UltraWinGrid.ExcelExport.UltraGridExcelExporter
   Friend WithEvents sfdExportar As System.Windows.Forms.SaveFileDialog
   Friend WithEvents ugDetalle As Infragistics.Win.UltraWinGrid.UltraGrid
   Friend WithEvents UltraGridPrintDocument1 As Infragistics.Win.UltraWinGrid.UltraGridPrintDocument
   Friend WithEvents UltraPrintPreviewDialog1 As Infragistics.Win.Printing.UltraPrintPreviewDialog
   Private WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
   Friend WithEvents tsbImprimir As System.Windows.Forms.ToolStripButton
   Private WithEvents toolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
   Friend WithEvents tsddExportar As System.Windows.Forms.ToolStripDropDownButton
   Friend WithEvents tsmiAExcel As System.Windows.Forms.ToolStripMenuItem
   Friend WithEvents tsmiAPDF As System.Windows.Forms.ToolStripMenuItem
   Friend WithEvents chkExpandAll As System.Windows.Forms.CheckBox
   Friend WithEvents chbConIVA As Eniac.Controles.CheckBox
   Protected Friend WithEvents stsStado As System.Windows.Forms.StatusStrip
   Protected Friend WithEvents tssInfo As System.Windows.Forms.ToolStripStatusLabel
   Protected WithEvents tssRegistros As System.Windows.Forms.ToolStripStatusLabel
   Public WithEvents tsbPreferencias As System.Windows.Forms.ToolStripButton
   Friend WithEvents ToolStripSeparator4 As System.Windows.Forms.ToolStripSeparator
   Friend WithEvents bscProveedor As Eniac.Controles.Buscador
   Friend WithEvents bscCodigoProveedor As Eniac.Controles.Buscador
   Friend WithEvents chbProveedor As Eniac.Controles.CheckBox
   Friend WithEvents chbAlertaDeCaja As Eniac.Controles.CheckBox
   Friend WithEvents chbCategoria As Eniac.Controles.CheckBox
   Friend WithEvents cmbCategoria As Eniac.Controles.ComboBox
   Friend WithEvents lblSucursal As Eniac.Controles.Label
   Friend WithEvents cmbSucursal As Eniac.Win.ComboBoxSucursales
   Friend WithEvents chbUnificar As Eniac.Controles.CheckBox
   Friend WithEvents chbListaDePrecios As Eniac.Controles.CheckBox
   Friend WithEvents cmbListaDePrecios As Eniac.Controles.ComboBox
   Friend WithEvents chbCaja As Eniac.Controles.CheckBox
   Friend WithEvents cmbCajas As Eniac.Controles.ComboBox
   Friend WithEvents tbcAgrupados As System.Windows.Forms.TabControl
   Friend WithEvents tbpXListaPrecios As System.Windows.Forms.TabPage
   Friend WithEvents tbpXZonaGeografica As System.Windows.Forms.TabPage
   Friend WithEvents ugvXZona As Infragistics.Win.UltraWinGrid.UltraGrid
   Friend WithEvents UltraDataSource2 As Infragistics.Win.UltraWinDataSource.UltraDataSource
   Protected Friend WithEvents tspBarra As System.Windows.Forms.ToolStripStatusLabel
   Friend WithEvents tbpXRubros As System.Windows.Forms.TabPage
   Friend WithEvents ugDetalleXRubro As Infragistics.Win.UltraWinGrid.UltraGrid
End Class
