<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MRPAsignacionActividades
   Inherits Eniac.Win.BaseForm

   'Form reemplaza a Dispose para limpiar la lista de componentes.
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

   'Requerido por el Diseñador de Windows Forms
   Private components As System.ComponentModel.IContainer

   'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
   'Se puede modificar usando el Diseñador de Windows Forms.  
   'No lo modifique con el editor de código.
   <System.Diagnostics.DebuggerStepThrough()> _
   Private Sub InitializeComponent()
      Me.components = New System.ComponentModel.Container()
      Dim Appearance1 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridBand1 As Infragistics.Win.UltraWinGrid.UltraGridBand = New Infragistics.Win.UltraWinGrid.UltraGridBand("Band 0", -1)
        Dim UltraGridColumn18 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdTipoComprobante")
        Dim UltraGridColumn19 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NumeroOrdenProduccion")
        Dim UltraGridColumn20 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("FechaOrdenProduccion")
        Dim UltraGridColumn21 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreCliente")
        Dim UltraGridColumn22 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdProducto")
        Dim UltraGridColumn23 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreProducto")
        Dim UltraGridColumn24 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("FechaEntrega")
        Dim UltraGridColumn25 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NumeroPedido")
        Dim UltraGridColumn26 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("OrdenPedido")
        Dim UltraGridColumn27 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("CodigoProcProdOperacion")
        Dim UltraGridColumn28 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("DescripcionOperacion")
        Dim UltraGridColumn29 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdEstadoTarea")
        Dim UltraGridColumn30 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("FechaComienzo")
        Dim UltraGridColumn31 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("DescripcionCP")
        Dim UltraGridColumn32 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("ClaseCentroProductor")
        Dim UltraGridColumn33 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreProveedor")
        Dim UltraGridColumn34 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("DescripcionSeccion")
        Dim UltraGridColumn35 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreEmpleado", 0)
        Dim UltraGridColumn38 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Observacion", 1)
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
        Dim UltraDataColumn18 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("IdTipoComprobante")
        Dim UltraDataColumn19 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("NumeroOrdenProduccion")
        Dim UltraDataColumn20 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("FechaOrdenProduccion")
        Dim UltraDataColumn21 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("NombreCliente")
        Dim UltraDataColumn22 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("IdProducto")
        Dim UltraDataColumn23 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("NombreProducto")
        Dim UltraDataColumn24 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("FechaEntrega")
        Dim UltraDataColumn25 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("NumeroPedido")
        Dim UltraDataColumn26 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("OrdenPedido")
        Dim UltraDataColumn27 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("CodigoProcProdOperacion")
        Dim UltraDataColumn28 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("DescripcionOperacion")
        Dim UltraDataColumn29 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("IdEstadoTarea")
        Dim UltraDataColumn30 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("FechaComienzo")
        Dim UltraDataColumn31 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("DescripcionCP")
        Dim UltraDataColumn32 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("ClaseCentroProductor")
        Dim UltraDataColumn33 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("NombreProveedor")
        Dim UltraDataColumn34 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("DescripcionSeccion")
        Dim Appearance14 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Me.tstBarra = New System.Windows.Forms.ToolStrip()
        Me.tsbRefrescar = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsbImprimir = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsddExportar = New System.Windows.Forms.ToolStripDropDownButton()
        Me.tsmiAExcel = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsmiAPDF = New System.Windows.Forms.ToolStripMenuItem()
        Me.toolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsbSalir = New System.Windows.Forms.ToolStripButton()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.bscNombreTareas = New Eniac.Controles.Buscador2()
        Me.txtLineaPedido = New Eniac.Controles.TextBox()
        Me.lblLineaVta = New Eniac.Controles.Label()
        Me.Label4 = New Eniac.Controles.Label()
        Me.Label3 = New Eniac.Controles.Label()
        Me.cmbTipoComprobanteOP = New Eniac.Controles.ComboBox()
        Me.cmbTipoComprobantePedido = New Eniac.Controles.ComboBox()
        Me.chbPedidoVta = New Eniac.Controles.CheckBox()
        Me.txtNroPedido = New Eniac.Controles.TextBox()
        Me.chbSeccion = New Eniac.Controles.CheckBox()
        Me.cmbSecciones = New Eniac.Controles.ComboBox()
        Me.chbTarea = New Eniac.Controles.CheckBox()
        Me.cmbResponsable = New Eniac.Controles.ComboBox()
        Me.chbOrdenCompra = New Eniac.Controles.CheckBox()
        Me.txtOrdenCompra = New Eniac.Controles.TextBox()
        Me.bscProducto2 = New Eniac.Controles.Buscador2()
        Me.bscCodigoProducto2 = New Eniac.Controles.Buscador2()
        Me.chbMarca = New Eniac.Controles.CheckBox()
        Me.cmbMarca = New Eniac.Controles.ComboBox()
        Me.chbRubro = New Eniac.Controles.CheckBox()
        Me.cmbRubro = New Eniac.Controles.ComboBox()
        Me.chbFecha = New Eniac.Controles.CheckBox()
        Me.Label1 = New Eniac.Controles.Label()
        Me.cmbEstados = New Eniac.Controles.ComboBox()
        Me.chkMesCompleto = New Eniac.Controles.CheckBox()
        Me.dtpHasta = New Eniac.Controles.DateTimePicker()
        Me.lblHasta = New Eniac.Controles.Label()
        Me.dtpDesde = New Eniac.Controles.DateTimePicker()
        Me.lblDesde = New Eniac.Controles.Label()
        Me.chbTamanio = New Eniac.Controles.CheckBox()
        Me.txtTamanio = New Eniac.Controles.TextBox()
        Me.chbOrdenProduccion = New Eniac.Controles.CheckBox()
        Me.txtIdOrdenProduccion = New Eniac.Controles.TextBox()
        Me.chbCliente = New Eniac.Controles.CheckBox()
        Me.bscCodigoCliente = New Eniac.Controles.Buscador()
        Me.lblCodigoCliente = New Eniac.Controles.Label()
        Me.bscCliente = New Eniac.Controles.Buscador()
        Me.lblNombre = New Eniac.Controles.Label()
        Me.chbProducto = New Eniac.Controles.CheckBox()
        Me.btnConsultar = New Eniac.Controles.Button()
        Me.chbOperario = New Eniac.Controles.CheckBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.gprCentroProductor = New System.Windows.Forms.GroupBox()
        Me.bscCodigoProveedor = New Eniac.Controles.Buscador2()
        Me.bscNombreProveedor = New Eniac.Controles.Buscador2()
        Me.lblCentrosProductores = New Eniac.Controles.Label()
        Me.bscCodigoCentroProductor = New Eniac.Controles.Buscador2()
        Me.bscNombreCentrosProductores = New Eniac.Controles.Buscador2()
        Me.lblCantidadRemota = New Eniac.Controles.Label()
        Me.chbEmpleado = New Eniac.Controles.CheckBox()
        Me.cmbEmpleado = New Eniac.Controles.ComboBox()
        Me.chbFechaComienzo = New Eniac.Controles.CheckBox()
        Me.dtpFechaComienzo = New Eniac.Controles.DateTimePicker()
        Me.cmdMasivo = New System.Windows.Forms.Button()
        Me.cmbEstadoCambiar = New Eniac.Controles.ComboBox()
        Me.lblEstado = New Eniac.Controles.Label()
        Me.cmdCancel = New System.Windows.Forms.Button()
        Me.ugDetalle = New Infragistics.Win.UltraWinGrid.UltraGrid()
        Me.UltraDataSource2 = New Infragistics.Win.UltraWinDataSource.UltraDataSource(Me.components)
        Me.UltraDataSource1 = New Infragistics.Win.UltraWinDataSource.UltraDataSource(Me.components)
        Me.stsStado = New System.Windows.Forms.StatusStrip()
        Me.tssInfo = New System.Windows.Forms.ToolStripStatusLabel()
        Me.tspBarra = New System.Windows.Forms.ToolStripProgressBar()
        Me.tssRegistros = New System.Windows.Forms.ToolStripStatusLabel()
        Me.UltraGridDocumentExporter1 = New Infragistics.Win.UltraWinGrid.DocumentExport.UltraGridDocumentExporter(Me.components)
        Me.UltraGridExcelExporter1 = New Infragistics.Win.UltraWinGrid.ExcelExport.UltraGridExcelExporter(Me.components)
        Me.UltraGridPrintDocument1 = New Infragistics.Win.UltraWinGrid.UltraGridPrintDocument(Me.components)
        Me.UltraPrintPreviewDialog1 = New Infragistics.Win.Printing.UltraPrintPreviewDialog(Me.components)
        Me.tstBarra.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.gprCentroProductor.SuspendLayout()
        CType(Me.ugDetalle, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UltraDataSource2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UltraDataSource1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.stsStado.SuspendLayout()
        Me.SuspendLayout()
        '
        'tstBarra
        '
        Me.tstBarra.AllowItemReorder = True
        Me.tstBarra.ImageScalingSize = New System.Drawing.Size(22, 22)
        Me.tstBarra.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsbRefrescar, Me.ToolStripSeparator4, Me.tsbImprimir, Me.ToolStripSeparator2, Me.tsddExportar, Me.toolStripSeparator3, Me.tsbSalir})
        Me.tstBarra.Location = New System.Drawing.Point(0, 0)
        Me.tstBarra.Name = "tstBarra"
        Me.tstBarra.Size = New System.Drawing.Size(1130, 29)
        Me.tstBarra.TabIndex = 5
        '
        'tsbRefrescar
        '
        Me.tsbRefrescar.Image = Global.Eniac.Win.My.Resources.Resources.refresh_32
        Me.tsbRefrescar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbRefrescar.Name = "tsbRefrescar"
        Me.tsbRefrescar.Size = New System.Drawing.Size(104, 26)
        Me.tsbRefrescar.Text = "&Refrescar (F5)"
        '
        'ToolStripSeparator4
        '
        Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
        Me.ToolStripSeparator4.Size = New System.Drawing.Size(6, 29)
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
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 29)
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
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.bscNombreTareas)
        Me.GroupBox1.Controls.Add(Me.txtLineaPedido)
        Me.GroupBox1.Controls.Add(Me.lblLineaVta)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.cmbTipoComprobanteOP)
        Me.GroupBox1.Controls.Add(Me.cmbTipoComprobantePedido)
        Me.GroupBox1.Controls.Add(Me.chbPedidoVta)
        Me.GroupBox1.Controls.Add(Me.txtNroPedido)
        Me.GroupBox1.Controls.Add(Me.chbSeccion)
        Me.GroupBox1.Controls.Add(Me.cmbSecciones)
        Me.GroupBox1.Controls.Add(Me.chbTarea)
        Me.GroupBox1.Controls.Add(Me.cmbResponsable)
        Me.GroupBox1.Controls.Add(Me.chbOrdenCompra)
        Me.GroupBox1.Controls.Add(Me.txtOrdenCompra)
        Me.GroupBox1.Controls.Add(Me.bscProducto2)
        Me.GroupBox1.Controls.Add(Me.bscCodigoProducto2)
        Me.GroupBox1.Controls.Add(Me.chbMarca)
        Me.GroupBox1.Controls.Add(Me.cmbMarca)
        Me.GroupBox1.Controls.Add(Me.chbRubro)
        Me.GroupBox1.Controls.Add(Me.cmbRubro)
        Me.GroupBox1.Controls.Add(Me.chbFecha)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.cmbEstados)
        Me.GroupBox1.Controls.Add(Me.chkMesCompleto)
        Me.GroupBox1.Controls.Add(Me.dtpHasta)
        Me.GroupBox1.Controls.Add(Me.dtpDesde)
        Me.GroupBox1.Controls.Add(Me.lblHasta)
        Me.GroupBox1.Controls.Add(Me.lblDesde)
        Me.GroupBox1.Controls.Add(Me.chbTamanio)
        Me.GroupBox1.Controls.Add(Me.txtTamanio)
        Me.GroupBox1.Controls.Add(Me.chbOrdenProduccion)
        Me.GroupBox1.Controls.Add(Me.txtIdOrdenProduccion)
        Me.GroupBox1.Controls.Add(Me.chbCliente)
        Me.GroupBox1.Controls.Add(Me.bscCodigoCliente)
        Me.GroupBox1.Controls.Add(Me.bscCliente)
        Me.GroupBox1.Controls.Add(Me.lblCodigoCliente)
        Me.GroupBox1.Controls.Add(Me.lblNombre)
        Me.GroupBox1.Controls.Add(Me.chbProducto)
        Me.GroupBox1.Controls.Add(Me.btnConsultar)
        Me.GroupBox1.Controls.Add(Me.chbOperario)
        Me.GroupBox1.Location = New System.Drawing.Point(6, 32)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(1115, 148)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Filtros"
        '
        'bscNombreTareas
        '
        Me.bscNombreTareas.ActivarFiltroEnGrilla = True
        Me.bscNombreTareas.BindearPropiedadControl = Nothing
        Me.bscNombreTareas.BindearPropiedadEntidad = Nothing
        Me.bscNombreTareas.ConfigBuscador = Nothing
        Me.bscNombreTareas.Datos = Nothing
        Me.bscNombreTareas.Enabled = False
        Me.bscNombreTareas.FilaDevuelta = Nothing
        Me.bscNombreTareas.ForeColorFocus = System.Drawing.Color.Red
        Me.bscNombreTareas.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.bscNombreTareas.IsDecimal = False
        Me.bscNombreTareas.IsNumber = False
        Me.bscNombreTareas.IsPK = False
        Me.bscNombreTareas.IsRequired = False
        Me.bscNombreTareas.Key = ""
        Me.bscNombreTareas.LabelAsoc = Nothing
        Me.bscNombreTareas.Location = New System.Drawing.Point(295, 114)
        Me.bscNombreTareas.Margin = New System.Windows.Forms.Padding(4)
        Me.bscNombreTareas.MaxLengh = "32767"
        Me.bscNombreTareas.Name = "bscNombreTareas"
        Me.bscNombreTareas.Permitido = True
        Me.bscNombreTareas.PermitidoNoBackColor = System.Drawing.Color.FromArgb(CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer))
        Me.bscNombreTareas.PermitidoNoForeColor = System.Drawing.Color.Black
        Me.bscNombreTareas.PermitidoSiBackColor = System.Drawing.Color.White
        Me.bscNombreTareas.PermitidoSiForeColor = System.Drawing.Color.Black
        Me.bscNombreTareas.Selecciono = False
        Me.bscNombreTareas.Size = New System.Drawing.Size(177, 20)
        Me.bscNombreTareas.TabIndex = 33
        '
        'txtLineaPedido
        '
        Me.txtLineaPedido.BackColor = System.Drawing.SystemColors.Window
        Me.txtLineaPedido.BindearPropiedadControl = Nothing
        Me.txtLineaPedido.BindearPropiedadEntidad = Nothing
        Me.txtLineaPedido.Enabled = False
        Me.txtLineaPedido.ForeColorFocus = System.Drawing.Color.Red
        Me.txtLineaPedido.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtLineaPedido.Formato = ""
        Me.txtLineaPedido.IsDecimal = False
        Me.txtLineaPedido.IsNumber = True
        Me.txtLineaPedido.IsPK = False
        Me.txtLineaPedido.IsRequired = False
        Me.txtLineaPedido.Key = ""
        Me.txtLineaPedido.LabelAsoc = Nothing
        Me.txtLineaPedido.Location = New System.Drawing.Point(692, 113)
        Me.txtLineaPedido.MaxLength = 8
        Me.txtLineaPedido.Name = "txtLineaPedido"
        Me.txtLineaPedido.Size = New System.Drawing.Size(54, 20)
        Me.txtLineaPedido.TabIndex = 37
        Me.txtLineaPedido.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblLineaVta
        '
        Me.lblLineaVta.AutoSize = True
        Me.lblLineaVta.LabelAsoc = Nothing
        Me.lblLineaVta.Location = New System.Drawing.Point(653, 117)
        Me.lblLineaVta.Name = "lblLineaVta"
        Me.lblLineaVta.Size = New System.Drawing.Size(33, 13)
        Me.lblLineaVta.TabIndex = 36
        Me.lblLineaVta.Text = "Linea"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.LabelAsoc = Nothing
        Me.Label4.Location = New System.Drawing.Point(752, 116)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(70, 13)
        Me.Label4.TabIndex = 38
        Me.Label4.Text = "Comprobante"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.LabelAsoc = Nothing
        Me.Label3.Location = New System.Drawing.Point(891, 41)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(94, 13)
        Me.Label3.TabIndex = 21
        Me.Label3.Text = "Tipo Comprobante"
        '
        'cmbTipoComprobanteOP
        '
        Me.cmbTipoComprobanteOP.BindearPropiedadControl = ""
        Me.cmbTipoComprobanteOP.BindearPropiedadEntidad = ""
        Me.cmbTipoComprobanteOP.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbTipoComprobanteOP.Enabled = False
        Me.cmbTipoComprobanteOP.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbTipoComprobanteOP.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbTipoComprobanteOP.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbTipoComprobanteOP.FormattingEnabled = True
        Me.cmbTipoComprobanteOP.IsPK = False
        Me.cmbTipoComprobanteOP.IsRequired = False
        Me.cmbTipoComprobanteOP.Key = Nothing
        Me.cmbTipoComprobanteOP.LabelAsoc = Me.Label3
        Me.cmbTipoComprobanteOP.Location = New System.Drawing.Point(894, 56)
        Me.cmbTipoComprobanteOP.Name = "cmbTipoComprobanteOP"
        Me.cmbTipoComprobanteOP.Size = New System.Drawing.Size(199, 21)
        Me.cmbTipoComprobanteOP.TabIndex = 22
        '
        'cmbTipoComprobantePedido
        '
        Me.cmbTipoComprobantePedido.BindearPropiedadControl = ""
        Me.cmbTipoComprobantePedido.BindearPropiedadEntidad = ""
        Me.cmbTipoComprobantePedido.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbTipoComprobantePedido.Enabled = False
        Me.cmbTipoComprobantePedido.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbTipoComprobantePedido.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbTipoComprobantePedido.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbTipoComprobantePedido.FormattingEnabled = True
        Me.cmbTipoComprobantePedido.IsPK = False
        Me.cmbTipoComprobantePedido.IsRequired = False
        Me.cmbTipoComprobantePedido.Key = Nothing
        Me.cmbTipoComprobantePedido.LabelAsoc = Nothing
        Me.cmbTipoComprobantePedido.Location = New System.Drawing.Point(828, 112)
        Me.cmbTipoComprobantePedido.Name = "cmbTipoComprobantePedido"
        Me.cmbTipoComprobantePedido.Size = New System.Drawing.Size(161, 21)
        Me.cmbTipoComprobantePedido.TabIndex = 39
        '
        'chbPedidoVta
        '
        Me.chbPedidoVta.AutoSize = True
        Me.chbPedidoVta.BindearPropiedadControl = Nothing
        Me.chbPedidoVta.BindearPropiedadEntidad = Nothing
        Me.chbPedidoVta.ForeColorFocus = System.Drawing.Color.Red
        Me.chbPedidoVta.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbPedidoVta.IsPK = False
        Me.chbPedidoVta.IsRequired = False
        Me.chbPedidoVta.Key = Nothing
        Me.chbPedidoVta.LabelAsoc = Nothing
        Me.chbPedidoVta.Location = New System.Drawing.Point(486, 117)
        Me.chbPedidoVta.Name = "chbPedidoVta"
        Me.chbPedidoVta.Size = New System.Drawing.Size(81, 17)
        Me.chbPedidoVta.TabIndex = 34
        Me.chbPedidoVta.Text = "Pedido Vta."
        Me.chbPedidoVta.UseVisualStyleBackColor = True
        '
        'txtNroPedido
        '
        Me.txtNroPedido.BackColor = System.Drawing.SystemColors.Window
        Me.txtNroPedido.BindearPropiedadControl = Nothing
        Me.txtNroPedido.BindearPropiedadEntidad = Nothing
        Me.txtNroPedido.Enabled = False
        Me.txtNroPedido.ForeColorFocus = System.Drawing.Color.Red
        Me.txtNroPedido.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtNroPedido.Formato = ""
        Me.txtNroPedido.IsDecimal = False
        Me.txtNroPedido.IsNumber = True
        Me.txtNroPedido.IsPK = False
        Me.txtNroPedido.IsRequired = False
        Me.txtNroPedido.Key = ""
        Me.txtNroPedido.LabelAsoc = Nothing
        Me.txtNroPedido.Location = New System.Drawing.Point(567, 114)
        Me.txtNroPedido.MaxLength = 8
        Me.txtNroPedido.Name = "txtNroPedido"
        Me.txtNroPedido.Size = New System.Drawing.Size(80, 20)
        Me.txtNroPedido.TabIndex = 35
        Me.txtNroPedido.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'chbSeccion
        '
        Me.chbSeccion.AutoSize = True
        Me.chbSeccion.BindearPropiedadControl = Nothing
        Me.chbSeccion.BindearPropiedadEntidad = Nothing
        Me.chbSeccion.ForeColorFocus = System.Drawing.Color.Red
        Me.chbSeccion.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbSeccion.IsPK = False
        Me.chbSeccion.IsRequired = False
        Me.chbSeccion.Key = Nothing
        Me.chbSeccion.LabelAsoc = Nothing
        Me.chbSeccion.Location = New System.Drawing.Point(11, 116)
        Me.chbSeccion.Name = "chbSeccion"
        Me.chbSeccion.Size = New System.Drawing.Size(65, 17)
        Me.chbSeccion.TabIndex = 30
        Me.chbSeccion.Text = "Seccion"
        Me.chbSeccion.UseVisualStyleBackColor = True
        '
        'cmbSecciones
        '
        Me.cmbSecciones.BindearPropiedadControl = Nothing
        Me.cmbSecciones.BindearPropiedadEntidad = Nothing
        Me.cmbSecciones.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbSecciones.Enabled = False
        Me.cmbSecciones.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbSecciones.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbSecciones.FormattingEnabled = True
        Me.cmbSecciones.IsPK = False
        Me.cmbSecciones.IsRequired = False
        Me.cmbSecciones.Key = Nothing
        Me.cmbSecciones.LabelAsoc = Nothing
        Me.cmbSecciones.Location = New System.Drawing.Point(80, 114)
        Me.cmbSecciones.Name = "cmbSecciones"
        Me.cmbSecciones.Size = New System.Drawing.Size(154, 21)
        Me.cmbSecciones.TabIndex = 31
        '
        'chbTarea
        '
        Me.chbTarea.AutoSize = True
        Me.chbTarea.BindearPropiedadControl = Nothing
        Me.chbTarea.BindearPropiedadEntidad = Nothing
        Me.chbTarea.ForeColorFocus = System.Drawing.Color.Red
        Me.chbTarea.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbTarea.IsPK = False
        Me.chbTarea.IsRequired = False
        Me.chbTarea.Key = Nothing
        Me.chbTarea.LabelAsoc = Nothing
        Me.chbTarea.Location = New System.Drawing.Point(239, 116)
        Me.chbTarea.Name = "chbTarea"
        Me.chbTarea.Size = New System.Drawing.Size(54, 17)
        Me.chbTarea.TabIndex = 32
        Me.chbTarea.Text = "Tarea"
        Me.chbTarea.UseVisualStyleBackColor = True
        '
        'cmbResponsable
        '
        Me.cmbResponsable.BindearPropiedadControl = Nothing
        Me.cmbResponsable.BindearPropiedadEntidad = Nothing
        Me.cmbResponsable.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbResponsable.Enabled = False
        Me.cmbResponsable.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbResponsable.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbResponsable.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbResponsable.FormattingEnabled = True
        Me.cmbResponsable.IsPK = False
        Me.cmbResponsable.IsRequired = False
        Me.cmbResponsable.Key = Nothing
        Me.cmbResponsable.LabelAsoc = Nothing
        Me.cmbResponsable.Location = New System.Drawing.Point(272, 16)
        Me.cmbResponsable.Name = "cmbResponsable"
        Me.cmbResponsable.Size = New System.Drawing.Size(140, 21)
        Me.cmbResponsable.TabIndex = 3
        '
        'chbOrdenCompra
        '
        Me.chbOrdenCompra.AutoSize = True
        Me.chbOrdenCompra.BindearPropiedadControl = Nothing
        Me.chbOrdenCompra.BindearPropiedadEntidad = Nothing
        Me.chbOrdenCompra.ForeColorFocus = System.Drawing.Color.Red
        Me.chbOrdenCompra.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbOrdenCompra.IsPK = False
        Me.chbOrdenCompra.IsRequired = False
        Me.chbOrdenCompra.Key = Nothing
        Me.chbOrdenCompra.LabelAsoc = Nothing
        Me.chbOrdenCompra.Location = New System.Drawing.Point(486, 59)
        Me.chbOrdenCompra.Name = "chbOrdenCompra"
        Me.chbOrdenCompra.Size = New System.Drawing.Size(109, 17)
        Me.chbOrdenCompra.TabIndex = 17
        Me.chbOrdenCompra.Text = "Orden de Compra"
        Me.chbOrdenCompra.UseVisualStyleBackColor = True
        '
        'txtOrdenCompra
        '
        Me.txtOrdenCompra.BackColor = System.Drawing.SystemColors.Window
        Me.txtOrdenCompra.BindearPropiedadControl = Nothing
        Me.txtOrdenCompra.BindearPropiedadEntidad = Nothing
        Me.txtOrdenCompra.Enabled = False
        Me.txtOrdenCompra.ForeColorFocus = System.Drawing.Color.Red
        Me.txtOrdenCompra.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtOrdenCompra.Formato = ""
        Me.txtOrdenCompra.IsDecimal = False
        Me.txtOrdenCompra.IsNumber = True
        Me.txtOrdenCompra.IsPK = False
        Me.txtOrdenCompra.IsRequired = False
        Me.txtOrdenCompra.Key = ""
        Me.txtOrdenCompra.LabelAsoc = Nothing
        Me.txtOrdenCompra.Location = New System.Drawing.Point(608, 56)
        Me.txtOrdenCompra.MaxLength = 8
        Me.txtOrdenCompra.Name = "txtOrdenCompra"
        Me.txtOrdenCompra.Size = New System.Drawing.Size(80, 20)
        Me.txtOrdenCompra.TabIndex = 18
        Me.txtOrdenCompra.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'bscProducto2
        '
        Me.bscProducto2.ActivarFiltroEnGrilla = True
        Me.bscProducto2.BindearPropiedadControl = Nothing
        Me.bscProducto2.BindearPropiedadEntidad = Nothing
        Me.bscProducto2.ConfigBuscador = Nothing
        Me.bscProducto2.Datos = Nothing
        Me.bscProducto2.Enabled = False
        Me.bscProducto2.FilaDevuelta = Nothing
        Me.bscProducto2.ForeColorFocus = System.Drawing.Color.Red
        Me.bscProducto2.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.bscProducto2.IsDecimal = False
        Me.bscProducto2.IsNumber = False
        Me.bscProducto2.IsPK = False
        Me.bscProducto2.IsRequired = False
        Me.bscProducto2.Key = ""
        Me.bscProducto2.LabelAsoc = Nothing
        Me.bscProducto2.Location = New System.Drawing.Point(172, 85)
        Me.bscProducto2.MaxLengh = "32767"
        Me.bscProducto2.Name = "bscProducto2"
        Me.bscProducto2.Permitido = True
        Me.bscProducto2.PermitidoNoBackColor = System.Drawing.Color.FromArgb(CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer))
        Me.bscProducto2.PermitidoNoForeColor = System.Drawing.Color.Black
        Me.bscProducto2.PermitidoSiBackColor = System.Drawing.Color.White
        Me.bscProducto2.PermitidoSiForeColor = System.Drawing.Color.Black
        Me.bscProducto2.Selecciono = False
        Me.bscProducto2.Size = New System.Drawing.Size(300, 20)
        Me.bscProducto2.TabIndex = 25
        '
        'bscCodigoProducto2
        '
        Me.bscCodigoProducto2.ActivarFiltroEnGrilla = True
        Me.bscCodigoProducto2.BindearPropiedadControl = Nothing
        Me.bscCodigoProducto2.BindearPropiedadEntidad = Nothing
        Me.bscCodigoProducto2.ConfigBuscador = Nothing
        Me.bscCodigoProducto2.Datos = Nothing
        Me.bscCodigoProducto2.Enabled = False
        Me.bscCodigoProducto2.FilaDevuelta = Nothing
        Me.bscCodigoProducto2.ForeColorFocus = System.Drawing.Color.Red
        Me.bscCodigoProducto2.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.bscCodigoProducto2.IsDecimal = False
        Me.bscCodigoProducto2.IsNumber = False
        Me.bscCodigoProducto2.IsPK = False
        Me.bscCodigoProducto2.IsRequired = False
        Me.bscCodigoProducto2.Key = ""
        Me.bscCodigoProducto2.LabelAsoc = Nothing
        Me.bscCodigoProducto2.Location = New System.Drawing.Point(80, 84)
        Me.bscCodigoProducto2.MaxLengh = "32767"
        Me.bscCodigoProducto2.Name = "bscCodigoProducto2"
        Me.bscCodigoProducto2.Permitido = True
        Me.bscCodigoProducto2.PermitidoNoBackColor = System.Drawing.Color.FromArgb(CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer))
        Me.bscCodigoProducto2.PermitidoNoForeColor = System.Drawing.Color.Black
        Me.bscCodigoProducto2.PermitidoSiBackColor = System.Drawing.Color.White
        Me.bscCodigoProducto2.PermitidoSiForeColor = System.Drawing.Color.Black
        Me.bscCodigoProducto2.Selecciono = False
        Me.bscCodigoProducto2.Size = New System.Drawing.Size(85, 20)
        Me.bscCodigoProducto2.TabIndex = 24
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
        Me.chbMarca.Location = New System.Drawing.Point(486, 87)
        Me.chbMarca.Name = "chbMarca"
        Me.chbMarca.Size = New System.Drawing.Size(56, 17)
        Me.chbMarca.TabIndex = 26
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
        Me.cmbMarca.Location = New System.Drawing.Point(538, 83)
        Me.cmbMarca.Name = "cmbMarca"
        Me.cmbMarca.Size = New System.Drawing.Size(190, 21)
        Me.cmbMarca.TabIndex = 27
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
        Me.chbRubro.Location = New System.Drawing.Point(734, 85)
        Me.chbRubro.Name = "chbRubro"
        Me.chbRubro.Size = New System.Drawing.Size(55, 17)
        Me.chbRubro.TabIndex = 28
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
        Me.cmbRubro.Location = New System.Drawing.Point(795, 83)
        Me.cmbRubro.Name = "cmbRubro"
        Me.cmbRubro.Size = New System.Drawing.Size(194, 21)
        Me.cmbRubro.TabIndex = 29
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
        Me.chbFecha.Location = New System.Drawing.Point(427, 19)
        Me.chbFecha.Name = "chbFecha"
        Me.chbFecha.Size = New System.Drawing.Size(56, 17)
        Me.chbFecha.TabIndex = 4
        Me.chbFecha.Text = "Fecha"
        Me.chbFecha.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.LabelAsoc = Nothing
        Me.Label1.Location = New System.Drawing.Point(11, 19)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(40, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Estado"
        '
        'cmbEstados
        '
        Me.cmbEstados.BindearPropiedadControl = ""
        Me.cmbEstados.BindearPropiedadEntidad = ""
        Me.cmbEstados.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbEstados.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbEstados.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbEstados.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbEstados.FormattingEnabled = True
        Me.cmbEstados.IsPK = False
        Me.cmbEstados.IsRequired = False
        Me.cmbEstados.Key = Nothing
        Me.cmbEstados.LabelAsoc = Me.Label1
        Me.cmbEstados.Location = New System.Drawing.Point(56, 15)
        Me.cmbEstados.Name = "cmbEstados"
        Me.cmbEstados.Size = New System.Drawing.Size(140, 21)
        Me.cmbEstados.TabIndex = 1
        '
        'chkMesCompleto
        '
        Me.chkMesCompleto.AutoSize = True
        Me.chkMesCompleto.BindearPropiedadControl = Nothing
        Me.chkMesCompleto.BindearPropiedadEntidad = Nothing
        Me.chkMesCompleto.Enabled = False
        Me.chkMesCompleto.ForeColorFocus = System.Drawing.Color.Red
        Me.chkMesCompleto.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chkMesCompleto.IsPK = False
        Me.chkMesCompleto.IsRequired = False
        Me.chkMesCompleto.Key = Nothing
        Me.chkMesCompleto.LabelAsoc = Nothing
        Me.chkMesCompleto.Location = New System.Drawing.Point(486, 19)
        Me.chkMesCompleto.Name = "chkMesCompleto"
        Me.chkMesCompleto.Size = New System.Drawing.Size(59, 17)
        Me.chkMesCompleto.TabIndex = 5
        Me.chkMesCompleto.Text = "Mes C."
        Me.chkMesCompleto.UseVisualStyleBackColor = True
        '
        'dtpHasta
        '
        Me.dtpHasta.BindearPropiedadControl = Nothing
        Me.dtpHasta.BindearPropiedadEntidad = Nothing
        Me.dtpHasta.CustomFormat = "dd/MM/yyyy HH:mm"
        Me.dtpHasta.Enabled = False
        Me.dtpHasta.ForeColorFocus = System.Drawing.Color.Red
        Me.dtpHasta.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.dtpHasta.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpHasta.IsPK = False
        Me.dtpHasta.IsRequired = False
        Me.dtpHasta.Key = ""
        Me.dtpHasta.LabelAsoc = Me.lblHasta
        Me.dtpHasta.Location = New System.Drawing.Point(757, 17)
        Me.dtpHasta.Name = "dtpHasta"
        Me.dtpHasta.Size = New System.Drawing.Size(128, 20)
        Me.dtpHasta.TabIndex = 9
        '
        'lblHasta
        '
        Me.lblHasta.AutoSize = True
        Me.lblHasta.LabelAsoc = Nothing
        Me.lblHasta.Location = New System.Drawing.Point(719, 21)
        Me.lblHasta.Name = "lblHasta"
        Me.lblHasta.Size = New System.Drawing.Size(35, 13)
        Me.lblHasta.TabIndex = 8
        Me.lblHasta.Text = "Hasta"
        '
        'dtpDesde
        '
        Me.dtpDesde.BindearPropiedadControl = Nothing
        Me.dtpDesde.BindearPropiedadEntidad = Nothing
        Me.dtpDesde.CustomFormat = "dd/MM/yyyy HH:mm"
        Me.dtpDesde.Enabled = False
        Me.dtpDesde.ForeColorFocus = System.Drawing.Color.Red
        Me.dtpDesde.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.dtpDesde.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpDesde.IsPK = False
        Me.dtpDesde.IsRequired = False
        Me.dtpDesde.Key = ""
        Me.dtpDesde.LabelAsoc = Me.lblDesde
        Me.dtpDesde.Location = New System.Drawing.Point(585, 17)
        Me.dtpDesde.Name = "dtpDesde"
        Me.dtpDesde.Size = New System.Drawing.Size(129, 20)
        Me.dtpDesde.TabIndex = 7
        '
        'lblDesde
        '
        Me.lblDesde.AutoSize = True
        Me.lblDesde.LabelAsoc = Nothing
        Me.lblDesde.Location = New System.Drawing.Point(544, 21)
        Me.lblDesde.Name = "lblDesde"
        Me.lblDesde.Size = New System.Drawing.Size(38, 13)
        Me.lblDesde.TabIndex = 6
        Me.lblDesde.Text = "Desde"
        '
        'chbTamanio
        '
        Me.chbTamanio.AutoSize = True
        Me.chbTamanio.BindearPropiedadControl = Nothing
        Me.chbTamanio.BindearPropiedadEntidad = Nothing
        Me.chbTamanio.ForeColorFocus = System.Drawing.Color.Red
        Me.chbTamanio.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbTamanio.IsPK = False
        Me.chbTamanio.IsRequired = False
        Me.chbTamanio.Key = Nothing
        Me.chbTamanio.LabelAsoc = Nothing
        Me.chbTamanio.Location = New System.Drawing.Point(704, 58)
        Me.chbTamanio.Name = "chbTamanio"
        Me.chbTamanio.Size = New System.Drawing.Size(65, 17)
        Me.chbTamanio.TabIndex = 19
        Me.chbTamanio.Text = "Tamaño"
        Me.chbTamanio.UseVisualStyleBackColor = True
        '
        'txtTamanio
        '
        Me.txtTamanio.BindearPropiedadControl = "Text"
        Me.txtTamanio.BindearPropiedadEntidad = "Tamano"
        Me.txtTamanio.Enabled = False
        Me.txtTamanio.ForeColorFocus = System.Drawing.Color.Red
        Me.txtTamanio.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtTamanio.Formato = "#0.000"
        Me.txtTamanio.IsDecimal = True
        Me.txtTamanio.IsNumber = True
        Me.txtTamanio.IsPK = False
        Me.txtTamanio.IsRequired = False
        Me.txtTamanio.Key = ""
        Me.txtTamanio.LabelAsoc = Nothing
        Me.txtTamanio.Location = New System.Drawing.Point(775, 56)
        Me.txtTamanio.MaxLength = 7
        Me.txtTamanio.Name = "txtTamanio"
        Me.txtTamanio.Size = New System.Drawing.Size(65, 20)
        Me.txtTamanio.TabIndex = 20
        Me.txtTamanio.Text = "0.000"
        Me.txtTamanio.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'chbOrdenProduccion
        '
        Me.chbOrdenProduccion.AutoSize = True
        Me.chbOrdenProduccion.BindearPropiedadControl = Nothing
        Me.chbOrdenProduccion.BindearPropiedadEntidad = Nothing
        Me.chbOrdenProduccion.ForeColorFocus = System.Drawing.Color.Red
        Me.chbOrdenProduccion.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbOrdenProduccion.IsPK = False
        Me.chbOrdenProduccion.IsRequired = False
        Me.chbOrdenProduccion.Key = Nothing
        Me.chbOrdenProduccion.LabelAsoc = Nothing
        Me.chbOrdenProduccion.Location = New System.Drawing.Point(894, 19)
        Me.chbOrdenProduccion.Name = "chbOrdenProduccion"
        Me.chbOrdenProduccion.Size = New System.Drawing.Size(127, 17)
        Me.chbOrdenProduccion.TabIndex = 10
        Me.chbOrdenProduccion.Text = "Orden de Producción"
        Me.chbOrdenProduccion.UseVisualStyleBackColor = True
        '
        'txtIdOrdenProduccion
        '
        Me.txtIdOrdenProduccion.BackColor = System.Drawing.SystemColors.Window
        Me.txtIdOrdenProduccion.BindearPropiedadControl = Nothing
        Me.txtIdOrdenProduccion.BindearPropiedadEntidad = Nothing
        Me.txtIdOrdenProduccion.Enabled = False
        Me.txtIdOrdenProduccion.ForeColorFocus = System.Drawing.Color.Red
        Me.txtIdOrdenProduccion.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtIdOrdenProduccion.Formato = ""
        Me.txtIdOrdenProduccion.IsDecimal = False
        Me.txtIdOrdenProduccion.IsNumber = True
        Me.txtIdOrdenProduccion.IsPK = False
        Me.txtIdOrdenProduccion.IsRequired = False
        Me.txtIdOrdenProduccion.Key = ""
        Me.txtIdOrdenProduccion.LabelAsoc = Nothing
        Me.txtIdOrdenProduccion.Location = New System.Drawing.Point(1024, 17)
        Me.txtIdOrdenProduccion.MaxLength = 6
        Me.txtIdOrdenProduccion.Name = "txtIdOrdenProduccion"
        Me.txtIdOrdenProduccion.Size = New System.Drawing.Size(69, 20)
        Me.txtIdOrdenProduccion.TabIndex = 11
        Me.txtIdOrdenProduccion.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
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
        Me.chbCliente.Location = New System.Drawing.Point(11, 57)
        Me.chbCliente.Name = "chbCliente"
        Me.chbCliente.Size = New System.Drawing.Size(58, 17)
        Me.chbCliente.TabIndex = 12
        Me.chbCliente.Text = "Cliente"
        Me.chbCliente.UseVisualStyleBackColor = True
        '
        'bscCodigoCliente
        '
        Me.bscCodigoCliente.AyudaAncho = 140
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
        Me.bscCodigoCliente.Location = New System.Drawing.Point(75, 56)
        Me.bscCodigoCliente.MaxLengh = "32767"
        Me.bscCodigoCliente.Name = "bscCodigoCliente"
        Me.bscCodigoCliente.Permitido = True
        Me.bscCodigoCliente.Selecciono = False
        Me.bscCodigoCliente.Size = New System.Drawing.Size(90, 20)
        Me.bscCodigoCliente.TabIndex = 14
        Me.bscCodigoCliente.Titulo = Nothing
        '
        'lblCodigoCliente
        '
        Me.lblCodigoCliente.AutoSize = True
        Me.lblCodigoCliente.LabelAsoc = Nothing
        Me.lblCodigoCliente.Location = New System.Drawing.Point(74, 41)
        Me.lblCodigoCliente.Name = "lblCodigoCliente"
        Me.lblCodigoCliente.Size = New System.Drawing.Size(40, 13)
        Me.lblCodigoCliente.TabIndex = 13
        Me.lblCodigoCliente.Text = "Código"
        '
        'bscCliente
        '
        Me.bscCliente.AutoSize = True
        Me.bscCliente.AyudaAncho = 140
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
        Me.bscCliente.Location = New System.Drawing.Point(172, 57)
        Me.bscCliente.Margin = New System.Windows.Forms.Padding(4)
        Me.bscCliente.MaxLengh = "32767"
        Me.bscCliente.Name = "bscCliente"
        Me.bscCliente.Permitido = True
        Me.bscCliente.Selecciono = False
        Me.bscCliente.Size = New System.Drawing.Size(300, 23)
        Me.bscCliente.TabIndex = 16
        Me.bscCliente.Titulo = Nothing
        '
        'lblNombre
        '
        Me.lblNombre.AutoSize = True
        Me.lblNombre.LabelAsoc = Nothing
        Me.lblNombre.Location = New System.Drawing.Point(169, 43)
        Me.lblNombre.Name = "lblNombre"
        Me.lblNombre.Size = New System.Drawing.Size(44, 13)
        Me.lblNombre.TabIndex = 15
        Me.lblNombre.Text = "&Nombre"
        '
        'chbProducto
        '
        Me.chbProducto.AutoSize = True
        Me.chbProducto.BindearPropiedadControl = Nothing
        Me.chbProducto.BindearPropiedadEntidad = Nothing
        Me.chbProducto.ForeColorFocus = System.Drawing.Color.Red
        Me.chbProducto.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbProducto.IsPK = False
        Me.chbProducto.IsRequired = False
        Me.chbProducto.Key = Nothing
        Me.chbProducto.LabelAsoc = Nothing
        Me.chbProducto.Location = New System.Drawing.Point(11, 87)
        Me.chbProducto.Name = "chbProducto"
        Me.chbProducto.Size = New System.Drawing.Size(69, 17)
        Me.chbProducto.TabIndex = 23
        Me.chbProducto.Text = "Producto"
        Me.chbProducto.UseVisualStyleBackColor = True
        '
        'btnConsultar
        '
        Me.btnConsultar.Image = Global.Eniac.Win.My.Resources.Resources.view
        Me.btnConsultar.ImageAlign = System.Drawing.ContentAlignment.BottomLeft
        Me.btnConsultar.Location = New System.Drawing.Point(1000, 85)
        Me.btnConsultar.Name = "btnConsultar"
        Me.btnConsultar.Size = New System.Drawing.Size(93, 45)
        Me.btnConsultar.TabIndex = 40
        Me.btnConsultar.Text = "&Consultar"
        Me.btnConsultar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnConsultar.UseVisualStyleBackColor = True
        '
        'chbOperario
        '
        Me.chbOperario.AutoSize = True
        Me.chbOperario.BindearPropiedadControl = Nothing
        Me.chbOperario.BindearPropiedadEntidad = Nothing
        Me.chbOperario.ForeColorFocus = System.Drawing.Color.Red
        Me.chbOperario.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbOperario.IsPK = False
        Me.chbOperario.IsRequired = False
        Me.chbOperario.Key = Nothing
        Me.chbOperario.LabelAsoc = Nothing
        Me.chbOperario.Location = New System.Drawing.Point(209, 18)
        Me.chbOperario.Name = "chbOperario"
        Me.chbOperario.Size = New System.Drawing.Size(66, 17)
        Me.chbOperario.TabIndex = 2
        Me.chbOperario.Text = "Operario"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.gprCentroProductor)
        Me.GroupBox2.Controls.Add(Me.chbEmpleado)
        Me.GroupBox2.Controls.Add(Me.cmbEmpleado)
        Me.GroupBox2.Controls.Add(Me.chbFechaComienzo)
        Me.GroupBox2.Controls.Add(Me.dtpFechaComienzo)
        Me.GroupBox2.Controls.Add(Me.cmdMasivo)
        Me.GroupBox2.Controls.Add(Me.cmbEstadoCambiar)
        Me.GroupBox2.Controls.Add(Me.lblEstado)
        Me.GroupBox2.Controls.Add(Me.cmdCancel)
        Me.GroupBox2.Location = New System.Drawing.Point(6, 186)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(1106, 92)
        Me.GroupBox2.TabIndex = 7
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Operaciones"
        '
        'gprCentroProductor
        '
        Me.gprCentroProductor.Controls.Add(Me.bscCodigoProveedor)
        Me.gprCentroProductor.Controls.Add(Me.bscNombreProveedor)
        Me.gprCentroProductor.Controls.Add(Me.bscCodigoCentroProductor)
        Me.gprCentroProductor.Controls.Add(Me.bscNombreCentrosProductores)
        Me.gprCentroProductor.Controls.Add(Me.lblCentrosProductores)
        Me.gprCentroProductor.Controls.Add(Me.lblCantidadRemota)
        Me.gprCentroProductor.Location = New System.Drawing.Point(416, 9)
        Me.gprCentroProductor.Name = "gprCentroProductor"
        Me.gprCentroProductor.Size = New System.Drawing.Size(471, 73)
        Me.gprCentroProductor.TabIndex = 8
        Me.gprCentroProductor.TabStop = False
        Me.gprCentroProductor.Text = "Centro Productor"
        '
        'bscCodigoProveedor
        '
        Me.bscCodigoProveedor.ActivarFiltroEnGrilla = True
        Me.bscCodigoProveedor.BindearPropiedadControl = Nothing
        Me.bscCodigoProveedor.BindearPropiedadEntidad = Nothing
        Me.bscCodigoProveedor.ConfigBuscador = Nothing
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
        Me.bscCodigoProveedor.Location = New System.Drawing.Point(81, 43)
        Me.bscCodigoProveedor.Margin = New System.Windows.Forms.Padding(4)
        Me.bscCodigoProveedor.MaxLengh = "32767"
        Me.bscCodigoProveedor.Name = "bscCodigoProveedor"
        Me.bscCodigoProveedor.Permitido = True
        Me.bscCodigoProveedor.PermitidoNoBackColor = System.Drawing.Color.FromArgb(CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer))
        Me.bscCodigoProveedor.PermitidoNoForeColor = System.Drawing.Color.Black
        Me.bscCodigoProveedor.PermitidoSiBackColor = System.Drawing.Color.White
        Me.bscCodigoProveedor.PermitidoSiForeColor = System.Drawing.Color.Black
        Me.bscCodigoProveedor.Selecciono = False
        Me.bscCodigoProveedor.Size = New System.Drawing.Size(110, 20)
        Me.bscCodigoProveedor.TabIndex = 6
        '
        'bscNombreProveedor
        '
        Me.bscNombreProveedor.ActivarFiltroEnGrilla = True
        Me.bscNombreProveedor.BindearPropiedadControl = Nothing
        Me.bscNombreProveedor.BindearPropiedadEntidad = Nothing
        Me.bscNombreProveedor.ConfigBuscador = Nothing
        Me.bscNombreProveedor.Datos = Nothing
        Me.bscNombreProveedor.Enabled = False
        Me.bscNombreProveedor.FilaDevuelta = Nothing
        Me.bscNombreProveedor.ForeColorFocus = System.Drawing.Color.Red
        Me.bscNombreProveedor.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.bscNombreProveedor.IsDecimal = False
        Me.bscNombreProveedor.IsNumber = False
        Me.bscNombreProveedor.IsPK = False
        Me.bscNombreProveedor.IsRequired = False
        Me.bscNombreProveedor.Key = ""
        Me.bscNombreProveedor.LabelAsoc = Me.lblCentrosProductores
        Me.bscNombreProveedor.Location = New System.Drawing.Point(198, 43)
        Me.bscNombreProveedor.Margin = New System.Windows.Forms.Padding(4)
        Me.bscNombreProveedor.MaxLengh = "32767"
        Me.bscNombreProveedor.Name = "bscNombreProveedor"
        Me.bscNombreProveedor.Permitido = True
        Me.bscNombreProveedor.PermitidoNoBackColor = System.Drawing.Color.FromArgb(CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer))
        Me.bscNombreProveedor.PermitidoNoForeColor = System.Drawing.Color.Black
        Me.bscNombreProveedor.PermitidoSiBackColor = System.Drawing.Color.White
        Me.bscNombreProveedor.PermitidoSiForeColor = System.Drawing.Color.Black
        Me.bscNombreProveedor.Selecciono = False
        Me.bscNombreProveedor.Size = New System.Drawing.Size(259, 20)
        Me.bscNombreProveedor.TabIndex = 7
        '
        'lblCentrosProductores
        '
        Me.lblCentrosProductores.AutoSize = True
        Me.lblCentrosProductores.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblCentrosProductores.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblCentrosProductores.LabelAsoc = Nothing
        Me.lblCentrosProductores.Location = New System.Drawing.Point(12, 22)
        Me.lblCentrosProductores.Name = "lblCentrosProductores"
        Me.lblCentrosProductores.Size = New System.Drawing.Size(38, 13)
        Me.lblCentrosProductores.TabIndex = 4
        Me.lblCentrosProductores.Text = "Centro"
        '
        'bscCodigoCentroProductor
        '
        Me.bscCodigoCentroProductor.ActivarFiltroEnGrilla = True
        Me.bscCodigoCentroProductor.BindearPropiedadControl = Nothing
        Me.bscCodigoCentroProductor.BindearPropiedadEntidad = Nothing
        Me.bscCodigoCentroProductor.ConfigBuscador = Nothing
        Me.bscCodigoCentroProductor.Datos = Nothing
        Me.bscCodigoCentroProductor.FilaDevuelta = Nothing
        Me.bscCodigoCentroProductor.ForeColorFocus = System.Drawing.Color.Red
        Me.bscCodigoCentroProductor.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.bscCodigoCentroProductor.IsDecimal = False
        Me.bscCodigoCentroProductor.IsNumber = False
        Me.bscCodigoCentroProductor.IsPK = False
        Me.bscCodigoCentroProductor.IsRequired = False
        Me.bscCodigoCentroProductor.Key = ""
        Me.bscCodigoCentroProductor.LabelAsoc = Nothing
        Me.bscCodigoCentroProductor.Location = New System.Drawing.Point(81, 19)
        Me.bscCodigoCentroProductor.Margin = New System.Windows.Forms.Padding(4)
        Me.bscCodigoCentroProductor.MaxLengh = "32767"
        Me.bscCodigoCentroProductor.Name = "bscCodigoCentroProductor"
        Me.bscCodigoCentroProductor.Permitido = True
        Me.bscCodigoCentroProductor.PermitidoNoBackColor = System.Drawing.Color.FromArgb(CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer))
        Me.bscCodigoCentroProductor.PermitidoNoForeColor = System.Drawing.Color.Black
        Me.bscCodigoCentroProductor.PermitidoSiBackColor = System.Drawing.Color.White
        Me.bscCodigoCentroProductor.PermitidoSiForeColor = System.Drawing.Color.Black
        Me.bscCodigoCentroProductor.Selecciono = False
        Me.bscCodigoCentroProductor.Size = New System.Drawing.Size(110, 20)
        Me.bscCodigoCentroProductor.TabIndex = 3
        '
        'bscNombreCentrosProductores
        '
        Me.bscNombreCentrosProductores.ActivarFiltroEnGrilla = True
        Me.bscNombreCentrosProductores.BindearPropiedadControl = Nothing
        Me.bscNombreCentrosProductores.BindearPropiedadEntidad = Nothing
        Me.bscNombreCentrosProductores.ConfigBuscador = Nothing
        Me.bscNombreCentrosProductores.Datos = Nothing
        Me.bscNombreCentrosProductores.FilaDevuelta = Nothing
        Me.bscNombreCentrosProductores.ForeColorFocus = System.Drawing.Color.Red
        Me.bscNombreCentrosProductores.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.bscNombreCentrosProductores.IsDecimal = False
        Me.bscNombreCentrosProductores.IsNumber = False
        Me.bscNombreCentrosProductores.IsPK = False
        Me.bscNombreCentrosProductores.IsRequired = False
        Me.bscNombreCentrosProductores.Key = ""
        Me.bscNombreCentrosProductores.LabelAsoc = Me.lblCentrosProductores
        Me.bscNombreCentrosProductores.Location = New System.Drawing.Point(198, 19)
        Me.bscNombreCentrosProductores.Margin = New System.Windows.Forms.Padding(4)
        Me.bscNombreCentrosProductores.MaxLengh = "32767"
        Me.bscNombreCentrosProductores.Name = "bscNombreCentrosProductores"
        Me.bscNombreCentrosProductores.Permitido = True
        Me.bscNombreCentrosProductores.PermitidoNoBackColor = System.Drawing.Color.FromArgb(CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer))
        Me.bscNombreCentrosProductores.PermitidoNoForeColor = System.Drawing.Color.Black
        Me.bscNombreCentrosProductores.PermitidoSiBackColor = System.Drawing.Color.White
        Me.bscNombreCentrosProductores.PermitidoSiForeColor = System.Drawing.Color.Black
        Me.bscNombreCentrosProductores.Selecciono = False
        Me.bscNombreCentrosProductores.Size = New System.Drawing.Size(259, 20)
        Me.bscNombreCentrosProductores.TabIndex = 5
        '
        'lblCantidadRemota
        '
        Me.lblCantidadRemota.AutoSize = True
        Me.lblCantidadRemota.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblCantidadRemota.LabelAsoc = Nothing
        Me.lblCantidadRemota.Location = New System.Drawing.Point(12, 46)
        Me.lblCantidadRemota.Name = "lblCantidadRemota"
        Me.lblCantidadRemota.Size = New System.Drawing.Size(56, 13)
        Me.lblCantidadRemota.TabIndex = 2
        Me.lblCantidadRemota.Text = "Proveedor"
        '
        'chbEmpleado
        '
        Me.chbEmpleado.AutoSize = True
        Me.chbEmpleado.BindearPropiedadControl = Nothing
        Me.chbEmpleado.BindearPropiedadEntidad = Nothing
        Me.chbEmpleado.ForeColorFocus = System.Drawing.Color.Red
        Me.chbEmpleado.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbEmpleado.IsPK = False
        Me.chbEmpleado.IsRequired = False
        Me.chbEmpleado.Key = Nothing
        Me.chbEmpleado.LabelAsoc = Nothing
        Me.chbEmpleado.Location = New System.Drawing.Point(14, 26)
        Me.chbEmpleado.Name = "chbEmpleado"
        Me.chbEmpleado.Size = New System.Drawing.Size(73, 17)
        Me.chbEmpleado.TabIndex = 38
        Me.chbEmpleado.Text = "Empleado"
        Me.chbEmpleado.UseVisualStyleBackColor = True
        '
        'cmbEmpleado
        '
        Me.cmbEmpleado.BindearPropiedadControl = ""
        Me.cmbEmpleado.BindearPropiedadEntidad = ""
        Me.cmbEmpleado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbEmpleado.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbEmpleado.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbEmpleado.FormattingEnabled = True
        Me.cmbEmpleado.IsPK = False
        Me.cmbEmpleado.IsRequired = True
        Me.cmbEmpleado.Key = Nothing
        Me.cmbEmpleado.LabelAsoc = Nothing
        Me.cmbEmpleado.Location = New System.Drawing.Point(125, 24)
        Me.cmbEmpleado.Name = "cmbEmpleado"
        Me.cmbEmpleado.Size = New System.Drawing.Size(278, 21)
        Me.cmbEmpleado.TabIndex = 37
        '
        'chbFechaComienzo
        '
        Me.chbFechaComienzo.AutoSize = True
        Me.chbFechaComienzo.BindearPropiedadControl = Nothing
        Me.chbFechaComienzo.BindearPropiedadEntidad = Nothing
        Me.chbFechaComienzo.ForeColorFocus = System.Drawing.Color.Red
        Me.chbFechaComienzo.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbFechaComienzo.IsPK = False
        Me.chbFechaComienzo.IsRequired = False
        Me.chbFechaComienzo.Key = Nothing
        Me.chbFechaComienzo.LabelAsoc = Nothing
        Me.chbFechaComienzo.Location = New System.Drawing.Point(14, 54)
        Me.chbFechaComienzo.Name = "chbFechaComienzo"
        Me.chbFechaComienzo.Size = New System.Drawing.Size(105, 17)
        Me.chbFechaComienzo.TabIndex = 35
        Me.chbFechaComienzo.Text = "Fecha Comienzo"
        Me.chbFechaComienzo.UseVisualStyleBackColor = True
        '
        'dtpFechaComienzo
        '
        Me.dtpFechaComienzo.BindearPropiedadControl = Nothing
        Me.dtpFechaComienzo.BindearPropiedadEntidad = Nothing
        Me.dtpFechaComienzo.CustomFormat = "dd/MM/yyyy"
        Me.dtpFechaComienzo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpFechaComienzo.ForeColorFocus = System.Drawing.Color.Red
        Me.dtpFechaComienzo.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.dtpFechaComienzo.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpFechaComienzo.IsPK = False
        Me.dtpFechaComienzo.IsRequired = False
        Me.dtpFechaComienzo.Key = ""
        Me.dtpFechaComienzo.LabelAsoc = Nothing
        Me.dtpFechaComienzo.Location = New System.Drawing.Point(125, 52)
        Me.dtpFechaComienzo.Name = "dtpFechaComienzo"
        Me.dtpFechaComienzo.Size = New System.Drawing.Size(95, 20)
        Me.dtpFechaComienzo.TabIndex = 4
        '
        'cmdMasivo
        '
        Me.cmdMasivo.Image = Global.Eniac.Win.My.Resources.Resources.play_32
        Me.cmdMasivo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdMasivo.Location = New System.Drawing.Point(900, 23)
        Me.cmdMasivo.Name = "cmdMasivo"
        Me.cmdMasivo.Size = New System.Drawing.Size(93, 48)
        Me.cmdMasivo.TabIndex = 6
        Me.cmdMasivo.Text = "Cambiar"
        Me.cmdMasivo.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cmdMasivo.UseVisualStyleBackColor = True
        '
        'cmbEstadoCambiar
        '
        Me.cmbEstadoCambiar.BindearPropiedadControl = "SelectedValue"
        Me.cmbEstadoCambiar.BindearPropiedadEntidad = "estadoCambiar"
        Me.cmbEstadoCambiar.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbEstadoCambiar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbEstadoCambiar.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbEstadoCambiar.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbEstadoCambiar.FormattingEnabled = True
        Me.cmbEstadoCambiar.IsPK = False
        Me.cmbEstadoCambiar.IsRequired = True
        Me.cmbEstadoCambiar.Key = Nothing
        Me.cmbEstadoCambiar.LabelAsoc = Nothing
        Me.cmbEstadoCambiar.Location = New System.Drawing.Point(295, 51)
        Me.cmbEstadoCambiar.Name = "cmbEstadoCambiar"
        Me.cmbEstadoCambiar.Size = New System.Drawing.Size(108, 21)
        Me.cmbEstadoCambiar.TabIndex = 1
        '
        'lblEstado
        '
        Me.lblEstado.AutoSize = True
        Me.lblEstado.LabelAsoc = Nothing
        Me.lblEstado.Location = New System.Drawing.Point(249, 55)
        Me.lblEstado.Name = "lblEstado"
        Me.lblEstado.Size = New System.Drawing.Size(40, 13)
        Me.lblEstado.TabIndex = 3
        Me.lblEstado.Text = "Estado"
        '
        'cmdCancel
        '
        Me.cmdCancel.Image = Global.Eniac.Win.My.Resources.Resources.delete2
        Me.cmdCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdCancel.Location = New System.Drawing.Point(1000, 23)
        Me.cmdCancel.Name = "cmdCancel"
        Me.cmdCancel.Size = New System.Drawing.Size(93, 48)
        Me.cmdCancel.TabIndex = 7
        Me.cmdCancel.Text = "Cancelar"
        Me.cmdCancel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cmdCancel.UseVisualStyleBackColor = True
        '
        'ugDetalle
        '
        Me.ugDetalle.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Appearance1.BackColor = System.Drawing.SystemColors.Window
        Appearance1.BorderColor = System.Drawing.SystemColors.InactiveCaption
        Me.ugDetalle.DisplayLayout.Appearance = Appearance1
        UltraGridColumn18.Header.Caption = "Comprobante"
        UltraGridColumn18.Header.VisiblePosition = 0
        UltraGridColumn19.Header.Caption = "Numero"
        UltraGridColumn19.Header.VisiblePosition = 1
        UltraGridColumn20.Header.Caption = "Fecha"
        UltraGridColumn20.Header.VisiblePosition = 2
        UltraGridColumn21.Header.Caption = "Cliente"
        UltraGridColumn21.Header.VisiblePosition = 3
        UltraGridColumn22.Header.Caption = "Codigo Producto"
        UltraGridColumn22.Header.VisiblePosition = 4
        UltraGridColumn23.Header.Caption = "Producto"
        UltraGridColumn23.Header.VisiblePosition = 5
        UltraGridColumn24.Header.Caption = "Fecha Entrega"
        UltraGridColumn24.Header.VisiblePosition = 6
        UltraGridColumn25.Header.Caption = "Pedido Vta"
        UltraGridColumn25.Header.VisiblePosition = 7
        UltraGridColumn26.Header.Caption = "Linea Vta"
        UltraGridColumn26.Header.VisiblePosition = 8
        UltraGridColumn27.Header.Caption = "Codigo Operación"
        UltraGridColumn27.Header.VisiblePosition = 9
        UltraGridColumn28.Header.Caption = "Descripcion Operación"
        UltraGridColumn28.Header.VisiblePosition = 10
        UltraGridColumn29.Header.Caption = "Estado Operacion"
        UltraGridColumn29.Header.VisiblePosition = 11
        UltraGridColumn30.Header.Caption = "Fecha Comienzo"
        UltraGridColumn30.Header.VisiblePosition = 12
        UltraGridColumn31.Header.Caption = "Centro Productor"
        UltraGridColumn31.Header.VisiblePosition = 13
        UltraGridColumn32.Header.Caption = "Clase"
        UltraGridColumn32.Header.VisiblePosition = 14
        UltraGridColumn33.Header.Caption = "Proveedor"
        UltraGridColumn33.Header.VisiblePosition = 15
        UltraGridColumn34.Header.Caption = "Seccion"
        UltraGridColumn34.Header.VisiblePosition = 16
        UltraGridColumn35.Header.Caption = "Nombre Empleado"
        UltraGridColumn35.Header.VisiblePosition = 17
        UltraGridColumn38.Header.VisiblePosition = 18
        UltraGridBand1.Columns.AddRange(New Object() {UltraGridColumn18, UltraGridColumn19, UltraGridColumn20, UltraGridColumn21, UltraGridColumn22, UltraGridColumn23, UltraGridColumn24, UltraGridColumn25, UltraGridColumn26, UltraGridColumn27, UltraGridColumn28, UltraGridColumn29, UltraGridColumn30, UltraGridColumn31, UltraGridColumn32, UltraGridColumn33, UltraGridColumn34, UltraGridColumn35, UltraGridColumn38})
        Me.ugDetalle.DisplayLayout.BandsSerializer.Add(UltraGridBand1)
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
        Me.ugDetalle.DisplayLayout.Override.ActiveAppearancesEnabled = Infragistics.Win.DefaultableBoolean.[True]
        Appearance5.BackColor = System.Drawing.SystemColors.Window
        Appearance5.ForeColor = System.Drawing.SystemColors.ControlText
        Me.ugDetalle.DisplayLayout.Override.ActiveCellAppearance = Appearance5
        Appearance6.BackColor = System.Drawing.SystemColors.Highlight
        Appearance6.ForeColor = System.Drawing.SystemColors.HighlightText
        Me.ugDetalle.DisplayLayout.Override.ActiveRowAppearance = Appearance6
        Me.ugDetalle.DisplayLayout.Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.No
        Me.ugDetalle.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.[False]
        Me.ugDetalle.DisplayLayout.Override.AllowUpdate = Infragistics.Win.DefaultableBoolean.[True]
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
        Appearance12.BackColor = System.Drawing.SystemColors.ControlLight
        Me.ugDetalle.DisplayLayout.Override.TemplateAddRowAppearance = Appearance12
        Me.ugDetalle.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill
        Me.ugDetalle.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate
        Me.ugDetalle.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy
        Me.ugDetalle.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ugDetalle.Location = New System.Drawing.Point(8, 284)
        Me.ugDetalle.Name = "ugDetalle"
        Me.ugDetalle.Size = New System.Drawing.Size(1106, 238)
        Me.ugDetalle.TabIndex = 15
        '
        'UltraDataSource2
        '
        Me.UltraDataSource2.Band.Columns.AddRange(New Object() {UltraDataColumn18, UltraDataColumn19, UltraDataColumn20, UltraDataColumn21, UltraDataColumn22, UltraDataColumn23, UltraDataColumn24, UltraDataColumn25, UltraDataColumn26, UltraDataColumn27, UltraDataColumn28, UltraDataColumn29, UltraDataColumn30, UltraDataColumn31, UltraDataColumn32, UltraDataColumn33, UltraDataColumn34})
        '
        'stsStado
        '
        Me.stsStado.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tssInfo, Me.tspBarra, Me.tssRegistros})
        Me.stsStado.Location = New System.Drawing.Point(0, 531)
        Me.stsStado.Name = "stsStado"
        Me.stsStado.Size = New System.Drawing.Size(1130, 22)
        Me.stsStado.TabIndex = 18
        Me.stsStado.Text = "statusStrip1"
        '
        'tssInfo
        '
        Me.tssInfo.Name = "tssInfo"
        Me.tssInfo.Size = New System.Drawing.Size(1051, 17)
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
        'UltraGridPrintDocument1
        '
        Me.UltraGridPrintDocument1.DocumentName = "Informe"
        Me.UltraGridPrintDocument1.Footer.TextCenter = ""
        Me.UltraGridPrintDocument1.Grid = Me.ugDetalle
        Appearance14.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Appearance14.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element
        Appearance14.BackGradientStyle = Infragistics.Win.GradientStyle.VerticalBump
        Me.UltraGridPrintDocument1.Header.Appearance = Appearance14
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
        Me.UltraPrintPreviewDialog1.Document = Me.UltraGridPrintDocument1
        Me.UltraPrintPreviewDialog1.Name = "UltraPrintPreviewDialog1"
        '
        'MRPAsignacionActividades
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1130, 553)
        Me.Controls.Add(Me.stsStado)
        Me.Controls.Add(Me.ugDetalle)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.tstBarra)
        Me.Name = "MRPAsignacionActividades"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "MRP Asignacion de Actividades"
        Me.tstBarra.ResumeLayout(False)
        Me.tstBarra.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.gprCentroProductor.ResumeLayout(False)
        Me.gprCentroProductor.PerformLayout()
        CType(Me.ugDetalle, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UltraDataSource2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UltraDataSource1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.stsStado.ResumeLayout(False)
        Me.stsStado.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Public WithEvents tstBarra As ToolStrip
   Public WithEvents tsbRefrescar As ToolStripButton
   Friend WithEvents ToolStripSeparator4 As ToolStripSeparator
    Friend WithEvents tsbImprimir As ToolStripButton
    Friend WithEvents ToolStripSeparator2 As ToolStripSeparator
    Friend WithEvents tsddExportar As ToolStripDropDownButton
    Friend WithEvents tsmiAExcel As ToolStripMenuItem
    Friend WithEvents tsmiAPDF As ToolStripMenuItem
    Private WithEvents toolStripSeparator3 As ToolStripSeparator
    Public WithEvents tsbSalir As ToolStripButton
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents cmbResponsable As Controles.ComboBox
    Friend WithEvents chbOrdenCompra As Controles.CheckBox
    Friend WithEvents txtOrdenCompra As Controles.TextBox
    Friend WithEvents bscProducto2 As Controles.Buscador2
    Friend WithEvents bscCodigoProducto2 As Controles.Buscador2
    Friend WithEvents chbMarca As Controles.CheckBox
    Friend WithEvents cmbMarca As Controles.ComboBox
    Friend WithEvents chbRubro As Controles.CheckBox
    Friend WithEvents cmbRubro As Controles.ComboBox
    Friend WithEvents chbFecha As Controles.CheckBox
    Friend WithEvents Label1 As Controles.Label
    Friend WithEvents cmbEstados As Controles.ComboBox
    Friend WithEvents chkMesCompleto As Controles.CheckBox
    Friend WithEvents dtpHasta As Controles.DateTimePicker
    Friend WithEvents lblHasta As Controles.Label
    Friend WithEvents dtpDesde As Controles.DateTimePicker
    Friend WithEvents lblDesde As Controles.Label
    Friend WithEvents chbTamanio As Controles.CheckBox
    Friend WithEvents txtTamanio As Controles.TextBox
    Friend WithEvents chbOrdenProduccion As Controles.CheckBox
    Friend WithEvents txtIdOrdenProduccion As Controles.TextBox
    Friend WithEvents chbCliente As Controles.CheckBox
    Friend WithEvents bscCodigoCliente As Controles.Buscador
    Friend WithEvents lblCodigoCliente As Controles.Label
    Friend WithEvents bscCliente As Controles.Buscador
    Friend WithEvents lblNombre As Controles.Label
    Friend WithEvents chbProducto As Controles.CheckBox
    Friend WithEvents btnConsultar As Controles.Button
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents dtpFechaComienzo As Controles.DateTimePicker
    Friend WithEvents cmdMasivo As Button
    Friend WithEvents cmbEstadoCambiar As Controles.ComboBox
    Friend WithEvents lblEstado As Controles.Label
    Friend WithEvents cmdCancel As Button
    Friend WithEvents chbSeccion As Controles.CheckBox
    Friend WithEvents cmbSecciones As Controles.ComboBox
    Friend WithEvents chbTarea As Controles.CheckBox
    Friend WithEvents cmbTipoComprobantePedido As Controles.ComboBox
    Friend WithEvents chbPedidoVta As Controles.CheckBox
    Friend WithEvents txtNroPedido As Controles.TextBox
    Friend WithEvents lblLineaVta As Controles.Label
    Friend WithEvents Label4 As Controles.Label
    Friend WithEvents Label3 As Controles.Label
    Friend WithEvents cmbTipoComprobanteOP As Controles.ComboBox
    Friend WithEvents txtLineaPedido As Controles.TextBox
    Friend WithEvents chbFechaComienzo As Controles.CheckBox
    Friend WithEvents chbEmpleado As Controles.CheckBox
    Friend WithEvents cmbEmpleado As Controles.ComboBox
    Friend WithEvents gprCentroProductor As GroupBox
    Friend WithEvents lblCantidadRemota As Controles.Label
    Friend WithEvents bscCodigoCentroProductor As Controles.Buscador2
    Friend WithEvents bscNombreCentrosProductores As Controles.Buscador2
    Friend WithEvents lblCentrosProductores As Controles.Label
    Friend WithEvents bscCodigoProveedor As Controles.Buscador2
    Friend WithEvents bscNombreProveedor As Controles.Buscador2
    Friend WithEvents ugDetalle As UltraGrid
    Protected Friend WithEvents stsStado As StatusStrip
    Protected Friend WithEvents tssInfo As ToolStripStatusLabel
    Protected Friend WithEvents tspBarra As ToolStripProgressBar
    Protected WithEvents tssRegistros As ToolStripStatusLabel
    Friend WithEvents UltraGridDocumentExporter1 As DocumentExport.UltraGridDocumentExporter
    Friend WithEvents UltraGridExcelExporter1 As ExcelExport.UltraGridExcelExporter
    Friend WithEvents UltraGridPrintDocument1 As UltraGridPrintDocument
    Friend WithEvents UltraPrintPreviewDialog1 As Infragistics.Win.Printing.UltraPrintPreviewDialog
    Friend WithEvents bscNombreTareas As Controles.Buscador2
    Friend WithEvents UltraDataSource1 As UltraWinDataSource.UltraDataSource
    Friend WithEvents UltraDataSource2 As UltraWinDataSource.UltraDataSource
    Friend WithEvents chbOperario As Controles.CheckBox
End Class
