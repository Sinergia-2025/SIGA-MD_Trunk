<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class InfStockValorizado
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
      Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(InfStockValorizado))
      Dim Appearance1 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridBand1 As Infragistics.Win.UltraWinGrid.UltraGridBand = New Infragistics.Win.UltraWinGrid.UltraGridBand("Band 0", -1)
      Dim UltraGridColumn22 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdSucursal")
      Dim Appearance2 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn23 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreSucursal")
      Dim UltraGridColumn24 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdProducto")
      Dim Appearance3 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn25 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreProducto")
      Dim UltraGridColumn26 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdUnidadDeMedida")
      Dim Appearance4 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn27 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Tamano")
      Dim UltraGridColumn28 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdMarca")
      Dim Appearance5 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn29 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreMarca")
      Dim UltraGridColumn30 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdRubro")
      Dim Appearance6 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn31 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreRubro")
      Dim UltraGridColumn32 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("StockInicial")
      Dim Appearance7 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn33 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Kilos")
      Dim Appearance8 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn1 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("PrecioCostoConImpuestos")
      Dim Appearance9 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn2 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("PrecioVentaConImpuestos")
      Dim Appearance10 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn3 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("PrecioCostoSinImpuestos")
      Dim Appearance11 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn4 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("PrecioVentaSinImpuestos")
      Dim Appearance12 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn36 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Stock")
      Dim Appearance13 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn5 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("ValorizadoFabricaConImpuestos")
      Dim Appearance14 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn6 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("ValorizadoCostoConImpuestos")
      Dim Appearance15 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn7 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("ValorizadoVentaConImpuestos")
      Dim Appearance16 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn8 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("ValorizadoFabricaSinImpuestos")
      Dim Appearance17 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn9 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("ValorizadoCostoSinImpuestos")
      Dim Appearance18 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn10 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("ValorizadoVentaSinImpuestos")
      Dim Appearance19 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn11 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreDeposito", 0)
      Dim UltraGridColumn12 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("StockDeposito", 1)
      Dim Appearance20 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn13 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreUbicacion", 2)
      Dim UltraGridColumn14 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("StockUbicacion", 3)
      Dim Appearance21 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn15 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("KilosProducto", 4)
        Dim Appearance22 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn16 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("KilosDeposito", 5)
        Dim Appearance23 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn17 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("KilosUbicacion", 6)
        Dim Appearance24 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
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
        Me.grbFiltros = New System.Windows.Forms.GroupBox()
        Me.cmbUbicacion = New Eniac.Controles.ComboBox()
        Me.chbUbicacion = New Eniac.Controles.CheckBox()
        Me.cmbDepositos = New Eniac.Win.ComboBoxDepositos()
        Me.lblDeposito = New Eniac.Controles.Label()
        Me.cmbSucursal = New Eniac.Win.ComboBoxSucursales()
        Me.lblActivos = New Eniac.Controles.Label()
        Me.cmbActivos = New Eniac.Controles.ComboBox()
        Me.chbProveedorHabitual = New Eniac.Controles.CheckBox()
        Me.cmbListaDePrecios = New Eniac.Controles.ComboBox()
        Me.lblListaPrecios = New Eniac.Controles.Label()
        Me.bscCodigoProveedor = New Eniac.Controles.Buscador2()
        Me.Label1 = New Eniac.Controles.Label()
        Me.chbProveedor = New Eniac.Controles.CheckBox()
        Me.bscNombreProveedor = New Eniac.Controles.Buscador2()
        Me.Label2 = New Eniac.Controles.Label()
        Me.dtpFecha = New Eniac.Controles.DateTimePicker()
        Me.chbHastaFecha = New Eniac.Controles.CheckBox()
        Me.bscProducto2 = New Eniac.Controles.Buscador2()
        Me.bscCodigoProducto2 = New Eniac.Controles.Buscador2()
        Me.chbSubRubro = New Eniac.Controles.CheckBox()
        Me.cmbSubRubro = New Eniac.Controles.ComboBox()
        Me.btnCalcular = New Eniac.Controles.Button()
        Me.chbRubro = New Eniac.Controles.CheckBox()
        Me.cmbRubro = New Eniac.Controles.ComboBox()
        Me.chbMarca = New Eniac.Controles.CheckBox()
        Me.lblSucursales = New Eniac.Controles.Label()
        Me.chbProducto = New Eniac.Controles.CheckBox()
        Me.cmbMarca = New Eniac.Controles.ComboBox()
        Me.chbConIVA = New Eniac.Controles.CheckBox()
        Me.tstBarra = New System.Windows.Forms.ToolStrip()
        Me.tsbRefrescar = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsbImprimir = New System.Windows.Forms.ToolStripButton()
        Me.toolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsddExportar = New System.Windows.Forms.ToolStripDropDownButton()
        Me.tsmiAExcel = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsmiAPDF = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsbPreferencias = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsbSalir = New System.Windows.Forms.ToolStripButton()
        Me.stsStado = New System.Windows.Forms.StatusStrip()
        Me.tssInfo = New System.Windows.Forms.ToolStripStatusLabel()
        Me.tspBarra = New System.Windows.Forms.ToolStripProgressBar()
        Me.tssRegistros = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ugdDetalle = New Eniac.Win.UltraGridSiga()
        Me.sfdExportar = New System.Windows.Forms.SaveFileDialog()
        Me.UltraPrintPreviewDialog1 = New Infragistics.Win.Printing.UltraPrintPreviewDialog(Me.components)
        Me.UltraGridPrintDocument1 = New Infragistics.Win.UltraWinGrid.UltraGridPrintDocument(Me.components)
        Me.UltraGridExcelExporter1 = New Infragistics.Win.UltraWinGrid.ExcelExport.UltraGridExcelExporter(Me.components)
        Me.UltraGridDocumentExporter1 = New Infragistics.Win.UltraWinGrid.DocumentExport.UltraGridDocumentExporter(Me.components)
        Me.txtCotizacionDolar = New Eniac.Controles.TextBox()
        Me.lblCotizacionDolar = New Eniac.Controles.Label()
        Me.grbFiltros.SuspendLayout()
        Me.tstBarra.SuspendLayout()
        Me.stsStado.SuspendLayout()
        CType(Me.ugdDetalle, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'grbFiltros
        '
        Me.grbFiltros.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grbFiltros.Controls.Add(Me.cmbUbicacion)
        Me.grbFiltros.Controls.Add(Me.chbUbicacion)
        Me.grbFiltros.Controls.Add(Me.cmbDepositos)
        Me.grbFiltros.Controls.Add(Me.lblDeposito)
        Me.grbFiltros.Controls.Add(Me.cmbSucursal)
        Me.grbFiltros.Controls.Add(Me.lblActivos)
        Me.grbFiltros.Controls.Add(Me.cmbActivos)
        Me.grbFiltros.Controls.Add(Me.chbProveedorHabitual)
        Me.grbFiltros.Controls.Add(Me.cmbListaDePrecios)
        Me.grbFiltros.Controls.Add(Me.lblListaPrecios)
        Me.grbFiltros.Controls.Add(Me.bscCodigoProveedor)
        Me.grbFiltros.Controls.Add(Me.chbProveedor)
        Me.grbFiltros.Controls.Add(Me.bscNombreProveedor)
        Me.grbFiltros.Controls.Add(Me.dtpFecha)
        Me.grbFiltros.Controls.Add(Me.chbHastaFecha)
        Me.grbFiltros.Controls.Add(Me.Label1)
        Me.grbFiltros.Controls.Add(Me.Label2)
        Me.grbFiltros.Controls.Add(Me.bscProducto2)
        Me.grbFiltros.Controls.Add(Me.bscCodigoProducto2)
        Me.grbFiltros.Controls.Add(Me.chbSubRubro)
        Me.grbFiltros.Controls.Add(Me.cmbSubRubro)
        Me.grbFiltros.Controls.Add(Me.btnCalcular)
        Me.grbFiltros.Controls.Add(Me.chbRubro)
        Me.grbFiltros.Controls.Add(Me.cmbRubro)
        Me.grbFiltros.Controls.Add(Me.chbMarca)
        Me.grbFiltros.Controls.Add(Me.lblSucursales)
        Me.grbFiltros.Controls.Add(Me.chbProducto)
        Me.grbFiltros.Controls.Add(Me.cmbMarca)
        Me.grbFiltros.Location = New System.Drawing.Point(11, 31)
        Me.grbFiltros.Name = "grbFiltros"
        Me.grbFiltros.Size = New System.Drawing.Size(961, 135)
        Me.grbFiltros.TabIndex = 0
        Me.grbFiltros.TabStop = False
        '
        'cmbUbicacion
        '
        Me.cmbUbicacion.BindearPropiedadControl = Nothing
        Me.cmbUbicacion.BindearPropiedadEntidad = Nothing
        Me.cmbUbicacion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbUbicacion.Enabled = False
        Me.cmbUbicacion.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbUbicacion.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbUbicacion.FormattingEnabled = True
        Me.cmbUbicacion.IsPK = False
        Me.cmbUbicacion.IsRequired = False
        Me.cmbUbicacion.Key = Nothing
        Me.cmbUbicacion.LabelAsoc = Nothing
        Me.cmbUbicacion.Location = New System.Drawing.Point(308, 50)
        Me.cmbUbicacion.Name = "cmbUbicacion"
        Me.cmbUbicacion.Size = New System.Drawing.Size(122, 21)
        Me.cmbUbicacion.TabIndex = 27
        '
        'chbUbicacion
        '
        Me.chbUbicacion.AutoSize = True
        Me.chbUbicacion.BindearPropiedadControl = Nothing
        Me.chbUbicacion.BindearPropiedadEntidad = Nothing
        Me.chbUbicacion.ForeColorFocus = System.Drawing.Color.Red
        Me.chbUbicacion.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbUbicacion.IsPK = False
        Me.chbUbicacion.IsRequired = False
        Me.chbUbicacion.Key = Nothing
        Me.chbUbicacion.LabelAsoc = Nothing
        Me.chbUbicacion.Location = New System.Drawing.Point(228, 53)
        Me.chbUbicacion.Name = "chbUbicacion"
        Me.chbUbicacion.Size = New System.Drawing.Size(74, 17)
        Me.chbUbicacion.TabIndex = 26
        Me.chbUbicacion.Text = "Ubicacion"
        Me.chbUbicacion.UseVisualStyleBackColor = True
        '
        'cmbDepositos
        '
        Me.cmbDepositos.BindearPropiedadControl = Nothing
        Me.cmbDepositos.BindearPropiedadEntidad = Nothing
        Me.cmbDepositos.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbDepositos.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbDepositos.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbDepositos.FormattingEnabled = True
        Me.cmbDepositos.IsPK = False
        Me.cmbDepositos.IsRequired = False
        Me.cmbDepositos.Key = Nothing
        Me.cmbDepositos.LabelAsoc = Nothing
        Me.cmbDepositos.Location = New System.Drawing.Point(82, 51)
        Me.cmbDepositos.Name = "cmbDepositos"
        Me.cmbDepositos.Size = New System.Drawing.Size(140, 21)
        Me.cmbDepositos.TabIndex = 3
        '
        'lblDeposito
        '
        Me.lblDeposito.AutoSize = True
        Me.lblDeposito.LabelAsoc = Nothing
        Me.lblDeposito.Location = New System.Drawing.Point(8, 54)
        Me.lblDeposito.Name = "lblDeposito"
        Me.lblDeposito.Size = New System.Drawing.Size(49, 13)
        Me.lblDeposito.TabIndex = 2
        Me.lblDeposito.Text = "Depósito"
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
        Me.cmbSucursal.LabelAsoc = Nothing
        Me.cmbSucursal.Location = New System.Drawing.Point(82, 25)
        Me.cmbSucursal.Name = "cmbSucursal"
        Me.cmbSucursal.Size = New System.Drawing.Size(140, 21)
        Me.cmbSucursal.TabIndex = 1
        '
        'lblActivos
        '
        Me.lblActivos.AutoSize = True
        Me.lblActivos.LabelAsoc = Nothing
        Me.lblActivos.Location = New System.Drawing.Point(808, 31)
        Me.lblActivos.Name = "lblActivos"
        Me.lblActivos.Size = New System.Drawing.Size(42, 13)
        Me.lblActivos.TabIndex = 11
        Me.lblActivos.Text = "Activos"
        '
        'cmbActivos
        '
        Me.cmbActivos.BindearPropiedadControl = Nothing
        Me.cmbActivos.BindearPropiedadEntidad = Nothing
        Me.cmbActivos.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbActivos.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbActivos.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbActivos.FormattingEnabled = True
        Me.cmbActivos.IsPK = False
        Me.cmbActivos.IsRequired = False
        Me.cmbActivos.Key = Nothing
        Me.cmbActivos.LabelAsoc = Me.lblActivos
        Me.cmbActivos.Location = New System.Drawing.Point(856, 28)
        Me.cmbActivos.Name = "cmbActivos"
        Me.cmbActivos.Size = New System.Drawing.Size(86, 21)
        Me.cmbActivos.TabIndex = 12
        '
        'chbProveedorHabitual
        '
        Me.chbProveedorHabitual.AutoSize = True
        Me.chbProveedorHabitual.BindearPropiedadControl = Nothing
        Me.chbProveedorHabitual.BindearPropiedadEntidad = Nothing
        Me.chbProveedorHabitual.Enabled = False
        Me.chbProveedorHabitual.ForeColorFocus = System.Drawing.Color.Red
        Me.chbProveedorHabitual.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbProveedorHabitual.IsPK = False
        Me.chbProveedorHabitual.IsRequired = False
        Me.chbProveedorHabitual.Key = Nothing
        Me.chbProveedorHabitual.LabelAsoc = Nothing
        Me.chbProveedorHabitual.Location = New System.Drawing.Point(447, 54)
        Me.chbProveedorHabitual.Name = "chbProveedorHabitual"
        Me.chbProveedorHabitual.Size = New System.Drawing.Size(65, 17)
        Me.chbProveedorHabitual.TabIndex = 15
        Me.chbProveedorHabitual.Text = "Habitual"
        Me.chbProveedorHabitual.UseVisualStyleBackColor = True
        '
        'cmbListaDePrecios
        '
        Me.cmbListaDePrecios.BindearPropiedadControl = Nothing
        Me.cmbListaDePrecios.BindearPropiedadEntidad = Nothing
        Me.cmbListaDePrecios.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbListaDePrecios.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbListaDePrecios.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbListaDePrecios.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbListaDePrecios.FormattingEnabled = True
        Me.cmbListaDePrecios.IsPK = False
        Me.cmbListaDePrecios.IsRequired = False
        Me.cmbListaDePrecios.Key = Nothing
        Me.cmbListaDePrecios.LabelAsoc = Me.lblListaPrecios
        Me.cmbListaDePrecios.Location = New System.Drawing.Point(540, 106)
        Me.cmbListaDePrecios.Name = "cmbListaDePrecios"
        Me.cmbListaDePrecios.Size = New System.Drawing.Size(212, 21)
        Me.cmbListaDePrecios.TabIndex = 0
        '
        'lblListaPrecios
        '
        Me.lblListaPrecios.AutoSize = True
        Me.lblListaPrecios.LabelAsoc = Nothing
        Me.lblListaPrecios.Location = New System.Drawing.Point(444, 110)
        Me.lblListaPrecios.Name = "lblListaPrecios"
        Me.lblListaPrecios.Size = New System.Drawing.Size(82, 13)
        Me.lblListaPrecios.TabIndex = 25
        Me.lblListaPrecios.Text = "Lista de Precios"
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
        Me.bscCodigoProveedor.LabelAsoc = Me.Label1
        Me.bscCodigoProveedor.Location = New System.Drawing.Point(522, 26)
        Me.bscCodigoProveedor.MaxLengh = "32767"
        Me.bscCodigoProveedor.Name = "bscCodigoProveedor"
        Me.bscCodigoProveedor.Permitido = True
        Me.bscCodigoProveedor.PermitidoNoBackColor = System.Drawing.Color.FromArgb(CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer))
        Me.bscCodigoProveedor.PermitidoNoForeColor = System.Drawing.Color.Black
        Me.bscCodigoProveedor.PermitidoSiBackColor = System.Drawing.Color.White
        Me.bscCodigoProveedor.PermitidoSiForeColor = System.Drawing.Color.Black
        Me.bscCodigoProveedor.Selecciono = False
        Me.bscCodigoProveedor.Size = New System.Drawing.Size(90, 23)
        Me.bscCodigoProveedor.TabIndex = 8
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.LabelAsoc = Nothing
        Me.Label1.Location = New System.Drawing.Point(519, 12)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(40, 13)
        Me.Label1.TabIndex = 7
        Me.Label1.Text = "Código"
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
        Me.chbProveedor.Location = New System.Drawing.Point(447, 27)
        Me.chbProveedor.Name = "chbProveedor"
        Me.chbProveedor.Size = New System.Drawing.Size(75, 17)
        Me.chbProveedor.TabIndex = 4
        Me.chbProveedor.Text = "Proveedor"
        Me.chbProveedor.UseVisualStyleBackColor = True
        '
        'bscNombreProveedor
        '
        Me.bscNombreProveedor.ActivarFiltroEnGrilla = True
        Me.bscNombreProveedor.AutoSize = True
        Me.bscNombreProveedor.BindearPropiedadControl = Nothing
        Me.bscNombreProveedor.BindearPropiedadEntidad = Nothing
        Me.bscNombreProveedor.ConfigBuscador = Nothing
        Me.bscNombreProveedor.Datos = Nothing
        Me.bscNombreProveedor.Enabled = False
        Me.bscNombreProveedor.FilaDevuelta = Nothing
        Me.bscNombreProveedor.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bscNombreProveedor.ForeColorFocus = System.Drawing.Color.Red
        Me.bscNombreProveedor.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.bscNombreProveedor.IsDecimal = False
        Me.bscNombreProveedor.IsNumber = False
        Me.bscNombreProveedor.IsPK = False
        Me.bscNombreProveedor.IsRequired = False
        Me.bscNombreProveedor.Key = ""
        Me.bscNombreProveedor.LabelAsoc = Me.Label2
        Me.bscNombreProveedor.Location = New System.Drawing.Point(619, 26)
        Me.bscNombreProveedor.Margin = New System.Windows.Forms.Padding(4)
        Me.bscNombreProveedor.MaxLengh = "32767"
        Me.bscNombreProveedor.Name = "bscNombreProveedor"
        Me.bscNombreProveedor.Permitido = True
        Me.bscNombreProveedor.PermitidoNoBackColor = System.Drawing.Color.FromArgb(CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer))
        Me.bscNombreProveedor.PermitidoNoForeColor = System.Drawing.Color.Black
        Me.bscNombreProveedor.PermitidoSiBackColor = System.Drawing.Color.White
        Me.bscNombreProveedor.PermitidoSiForeColor = System.Drawing.Color.Black
        Me.bscNombreProveedor.Selecciono = False
        Me.bscNombreProveedor.Size = New System.Drawing.Size(187, 23)
        Me.bscNombreProveedor.TabIndex = 10
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.LabelAsoc = Nothing
        Me.Label2.Location = New System.Drawing.Point(616, 12)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(44, 13)
        Me.Label2.TabIndex = 9
        Me.Label2.Text = "Nombre"
        '
        'dtpFecha
        '
        Me.dtpFecha.BindearPropiedadControl = Nothing
        Me.dtpFecha.BindearPropiedadEntidad = Nothing
        Me.dtpFecha.CustomFormat = "dd/MM/yyyy"
        Me.dtpFecha.Enabled = False
        Me.dtpFecha.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpFecha.ForeColorFocus = System.Drawing.Color.Red
        Me.dtpFecha.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.dtpFecha.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpFecha.IsPK = False
        Me.dtpFecha.IsRequired = False
        Me.dtpFecha.Key = ""
        Me.dtpFecha.LabelAsoc = Nothing
        Me.dtpFecha.Location = New System.Drawing.Point(540, 78)
        Me.dtpFecha.Name = "dtpFecha"
        Me.dtpFecha.Size = New System.Drawing.Size(95, 20)
        Me.dtpFecha.TabIndex = 22
        '
        'chbHastaFecha
        '
        Me.chbHastaFecha.AutoSize = True
        Me.chbHastaFecha.BindearPropiedadControl = Nothing
        Me.chbHastaFecha.BindearPropiedadEntidad = Nothing
        Me.chbHastaFecha.ForeColorFocus = System.Drawing.Color.Red
        Me.chbHastaFecha.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbHastaFecha.IsPK = False
        Me.chbHastaFecha.IsRequired = False
        Me.chbHastaFecha.Key = Nothing
        Me.chbHastaFecha.LabelAsoc = Nothing
        Me.chbHastaFecha.Location = New System.Drawing.Point(447, 81)
        Me.chbHastaFecha.Name = "chbHastaFecha"
        Me.chbHastaFecha.Size = New System.Drawing.Size(87, 17)
        Me.chbHastaFecha.TabIndex = 21
        Me.chbHastaFecha.Text = "Hasta Fecha"
        Me.chbHastaFecha.UseVisualStyleBackColor = True
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
        Me.bscProducto2.Location = New System.Drawing.Point(710, 54)
        Me.bscProducto2.MaxLengh = "32767"
        Me.bscProducto2.Name = "bscProducto2"
        Me.bscProducto2.Permitido = True
        Me.bscProducto2.PermitidoNoBackColor = System.Drawing.Color.FromArgb(CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer))
        Me.bscProducto2.PermitidoNoForeColor = System.Drawing.Color.Black
        Me.bscProducto2.PermitidoSiBackColor = System.Drawing.Color.White
        Me.bscProducto2.PermitidoSiForeColor = System.Drawing.Color.Black
        Me.bscProducto2.Selecciono = False
        Me.bscProducto2.Size = New System.Drawing.Size(232, 20)
        Me.bscProducto2.TabIndex = 18
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
        Me.bscCodigoProducto2.Location = New System.Drawing.Point(592, 53)
        Me.bscCodigoProducto2.MaxLengh = "32767"
        Me.bscCodigoProducto2.Name = "bscCodigoProducto2"
        Me.bscCodigoProducto2.Permitido = True
        Me.bscCodigoProducto2.PermitidoNoBackColor = System.Drawing.Color.FromArgb(CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer))
        Me.bscCodigoProducto2.PermitidoNoForeColor = System.Drawing.Color.Black
        Me.bscCodigoProducto2.PermitidoSiBackColor = System.Drawing.Color.White
        Me.bscCodigoProducto2.PermitidoSiForeColor = System.Drawing.Color.Black
        Me.bscCodigoProducto2.Selecciono = False
        Me.bscCodigoProducto2.Size = New System.Drawing.Size(111, 20)
        Me.bscCodigoProducto2.TabIndex = 17
        '
        'chbSubRubro
        '
        Me.chbSubRubro.AutoSize = True
        Me.chbSubRubro.BindearPropiedadControl = Nothing
        Me.chbSubRubro.BindearPropiedadEntidad = Nothing
        Me.chbSubRubro.ForeColorFocus = System.Drawing.Color.Red
        Me.chbSubRubro.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbSubRubro.IsPK = False
        Me.chbSubRubro.IsRequired = False
        Me.chbSubRubro.Key = Nothing
        Me.chbSubRubro.LabelAsoc = Nothing
        Me.chbSubRubro.Location = New System.Drawing.Point(8, 108)
        Me.chbSubRubro.Name = "chbSubRubro"
        Me.chbSubRubro.Size = New System.Drawing.Size(74, 17)
        Me.chbSubRubro.TabIndex = 23
        Me.chbSubRubro.Text = "SubRubro"
        Me.chbSubRubro.UseVisualStyleBackColor = True
        '
        'cmbSubRubro
        '
        Me.cmbSubRubro.BindearPropiedadControl = Nothing
        Me.cmbSubRubro.BindearPropiedadEntidad = Nothing
        Me.cmbSubRubro.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbSubRubro.Enabled = False
        Me.cmbSubRubro.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbSubRubro.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbSubRubro.FormattingEnabled = True
        Me.cmbSubRubro.IsPK = False
        Me.cmbSubRubro.IsRequired = False
        Me.cmbSubRubro.Key = Nothing
        Me.cmbSubRubro.LabelAsoc = Nothing
        Me.cmbSubRubro.Location = New System.Drawing.Point(82, 106)
        Me.cmbSubRubro.Name = "cmbSubRubro"
        Me.cmbSubRubro.Size = New System.Drawing.Size(348, 21)
        Me.cmbSubRubro.TabIndex = 24
        '
        'btnCalcular
        '
        Me.btnCalcular.Image = Global.Eniac.Win.My.Resources.Resources.database_zoom_24
        Me.btnCalcular.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCalcular.Location = New System.Drawing.Point(852, 82)
        Me.btnCalcular.Name = "btnCalcular"
        Me.btnCalcular.Size = New System.Drawing.Size(89, 45)
        Me.btnCalcular.TabIndex = 1
        Me.btnCalcular.Text = "&Calcular"
        Me.btnCalcular.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnCalcular.UseVisualStyleBackColor = True
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
        Me.chbRubro.Location = New System.Drawing.Point(228, 81)
        Me.chbRubro.Name = "chbRubro"
        Me.chbRubro.Size = New System.Drawing.Size(55, 17)
        Me.chbRubro.TabIndex = 19
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
        Me.cmbRubro.Location = New System.Drawing.Point(289, 79)
        Me.cmbRubro.Name = "cmbRubro"
        Me.cmbRubro.Size = New System.Drawing.Size(141, 21)
        Me.cmbRubro.TabIndex = 20
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
        Me.chbMarca.Location = New System.Drawing.Point(8, 81)
        Me.chbMarca.Name = "chbMarca"
        Me.chbMarca.Size = New System.Drawing.Size(56, 17)
        Me.chbMarca.TabIndex = 13
        Me.chbMarca.Text = "Marca"
        Me.chbMarca.UseVisualStyleBackColor = True
        '
        'lblSucursales
        '
        Me.lblSucursales.AutoSize = True
        Me.lblSucursales.LabelAsoc = Nothing
        Me.lblSucursales.Location = New System.Drawing.Point(5, 28)
        Me.lblSucursales.Name = "lblSucursales"
        Me.lblSucursales.Size = New System.Drawing.Size(59, 13)
        Me.lblSucursales.TabIndex = 0
        Me.lblSucursales.Text = "Sucursales"
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
        Me.chbProducto.Location = New System.Drawing.Point(522, 55)
        Me.chbProducto.Name = "chbProducto"
        Me.chbProducto.Size = New System.Drawing.Size(69, 17)
        Me.chbProducto.TabIndex = 16
        Me.chbProducto.Text = "Producto"
        Me.chbProducto.UseVisualStyleBackColor = True
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
        Me.cmbMarca.Location = New System.Drawing.Point(82, 79)
        Me.cmbMarca.Name = "cmbMarca"
        Me.cmbMarca.Size = New System.Drawing.Size(140, 21)
        Me.cmbMarca.TabIndex = 14
        '
        'chbConIVA
        '
        Me.chbConIVA.AutoSize = True
        Me.chbConIVA.BackColor = System.Drawing.SystemColors.AppWorkspace
        Me.chbConIVA.BindearPropiedadControl = Nothing
        Me.chbConIVA.BindearPropiedadEntidad = Nothing
        Me.chbConIVA.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.chbConIVA.ForeColorFocus = System.Drawing.Color.Red
        Me.chbConIVA.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbConIVA.IsPK = False
        Me.chbConIVA.IsRequired = False
        Me.chbConIVA.Key = Nothing
        Me.chbConIVA.LabelAsoc = Nothing
        Me.chbConIVA.Location = New System.Drawing.Point(888, 181)
        Me.chbConIVA.Name = "chbConIVA"
        Me.chbConIVA.Size = New System.Drawing.Size(65, 17)
        Me.chbConIVA.TabIndex = 3
        Me.chbConIVA.Text = "Con IVA"
        Me.chbConIVA.UseVisualStyleBackColor = False
        '
        'tstBarra
        '
        Me.tstBarra.AllowItemReorder = True
        Me.tstBarra.ImageScalingSize = New System.Drawing.Size(22, 22)
        Me.tstBarra.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsbRefrescar, Me.ToolStripSeparator1, Me.tsbImprimir, Me.toolStripSeparator3, Me.tsddExportar, Me.ToolStripSeparator2, Me.tsbPreferencias, Me.ToolStripSeparator4, Me.tsbSalir})
        Me.tstBarra.Location = New System.Drawing.Point(0, 0)
        Me.tstBarra.Name = "tstBarra"
        Me.tstBarra.Size = New System.Drawing.Size(984, 29)
        Me.tstBarra.TabIndex = 6
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
        'stsStado
        '
        Me.stsStado.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tssInfo, Me.tspBarra, Me.tssRegistros})
        Me.stsStado.Location = New System.Drawing.Point(0, 529)
        Me.stsStado.Name = "stsStado"
        Me.stsStado.Size = New System.Drawing.Size(984, 22)
        Me.stsStado.TabIndex = 5
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
        Me.tssRegistros.Text = "2 Registros"
        '
        'ugdDetalle
        '
        Me.ugdDetalle.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Appearance1.BackColor = System.Drawing.SystemColors.Window
        Appearance1.BorderColor = System.Drawing.SystemColors.InactiveCaption
        Me.ugdDetalle.DisplayLayout.Appearance = Appearance1
        Appearance2.TextHAlignAsString = "Right"
        UltraGridColumn22.CellAppearance = Appearance2
        UltraGridColumn22.Header.VisiblePosition = 0
        UltraGridColumn22.Hidden = True
        UltraGridColumn23.Header.VisiblePosition = 1
        UltraGridColumn23.Hidden = True
        Appearance3.TextHAlignAsString = "Right"
        UltraGridColumn24.CellAppearance = Appearance3
        UltraGridColumn24.Header.Caption = "Código"
        UltraGridColumn24.Header.VisiblePosition = 2
        UltraGridColumn24.Width = 97
        UltraGridColumn25.Header.Caption = "Producto"
        UltraGridColumn25.Header.VisiblePosition = 3
        UltraGridColumn25.Width = 220
        Appearance4.TextHAlignAsString = "Right"
        UltraGridColumn26.CellAppearance = Appearance4
        UltraGridColumn26.Header.VisiblePosition = 4
        UltraGridColumn26.Hidden = True
        UltraGridColumn27.Header.VisiblePosition = 5
        UltraGridColumn27.Hidden = True
        Appearance5.TextHAlignAsString = "Right"
        UltraGridColumn28.CellAppearance = Appearance5
        UltraGridColumn28.Header.VisiblePosition = 6
        UltraGridColumn28.Hidden = True
        UltraGridColumn29.Header.Caption = "Marca"
        UltraGridColumn29.Header.VisiblePosition = 7
        UltraGridColumn29.Width = 100
        Appearance6.TextHAlignAsString = "Right"
        UltraGridColumn30.CellAppearance = Appearance6
        UltraGridColumn30.Header.VisiblePosition = 8
        UltraGridColumn30.Hidden = True
        UltraGridColumn31.Header.Caption = "Rubro"
        UltraGridColumn31.Header.VisiblePosition = 9
        UltraGridColumn31.Width = 100
        Appearance7.TextHAlignAsString = "Right"
        UltraGridColumn32.CellAppearance = Appearance7
        UltraGridColumn32.Format = "N2"
        UltraGridColumn32.Header.VisiblePosition = 10
        UltraGridColumn32.Hidden = True
        UltraGridColumn32.Width = 90
        Appearance8.TextHAlignAsString = "Right"
        UltraGridColumn33.CellAppearance = Appearance8
        UltraGridColumn33.Format = "N2"
        UltraGridColumn33.Header.VisiblePosition = 11
        UltraGridColumn33.Hidden = True
        UltraGridColumn33.Width = 80
        Appearance9.TextHAlignAsString = "Right"
        UltraGridColumn1.CellAppearance = Appearance9
        UltraGridColumn1.Format = "N2"
        UltraGridColumn1.Header.Caption = "Precio Costo"
        UltraGridColumn1.Header.VisiblePosition = 12
        UltraGridColumn1.Width = 65
        Appearance10.TextHAlignAsString = "Right"
        UltraGridColumn2.CellAppearance = Appearance10
        UltraGridColumn2.Format = "N2"
        UltraGridColumn2.Header.Caption = "Precio Venta"
        UltraGridColumn2.Header.VisiblePosition = 13
        UltraGridColumn2.Width = 65
        Appearance11.TextHAlignAsString = "Right"
        UltraGridColumn3.CellAppearance = Appearance11
        UltraGridColumn3.Format = "N2"
        UltraGridColumn3.Header.Caption = "Precio Costo"
        UltraGridColumn3.Header.VisiblePosition = 14
        UltraGridColumn3.Hidden = True
        UltraGridColumn3.Width = 65
        Appearance12.TextHAlignAsString = "Right"
        UltraGridColumn4.CellAppearance = Appearance12
        UltraGridColumn4.Format = "N2"
        UltraGridColumn4.Header.Caption = "Precio Venta"
        UltraGridColumn4.Header.VisiblePosition = 15
        UltraGridColumn4.Hidden = True
        UltraGridColumn4.Width = 65
        Appearance13.TextHAlignAsString = "Right"
        UltraGridColumn36.CellAppearance = Appearance13
        UltraGridColumn36.Format = "N2"
        UltraGridColumn36.Header.VisiblePosition = 16
        UltraGridColumn36.Width = 80
        Appearance14.TextHAlignAsString = "Right"
        UltraGridColumn5.CellAppearance = Appearance14
        UltraGridColumn5.Format = "N2"
        UltraGridColumn5.Header.Caption = "Valor Fábrica"
        UltraGridColumn5.Header.VisiblePosition = 24
        UltraGridColumn5.Hidden = True
        UltraGridColumn5.Width = 100
        Appearance15.TextHAlignAsString = "Right"
        UltraGridColumn6.CellAppearance = Appearance15
        UltraGridColumn6.Format = "N2"
        UltraGridColumn6.Header.Caption = "Valor Costo"
        UltraGridColumn6.Header.VisiblePosition = 25
        UltraGridColumn6.Width = 100
        Appearance16.TextHAlignAsString = "Right"
        UltraGridColumn7.CellAppearance = Appearance16
        UltraGridColumn7.Format = "N2"
        UltraGridColumn7.Header.Caption = "Valor Venta"
        UltraGridColumn7.Header.VisiblePosition = 26
        UltraGridColumn7.Width = 100
        Appearance17.TextHAlignAsString = "Right"
        UltraGridColumn8.CellAppearance = Appearance17
        UltraGridColumn8.Format = "N2"
        UltraGridColumn8.Header.Caption = "Valor Fabrica"
        UltraGridColumn8.Header.VisiblePosition = 27
        UltraGridColumn8.Hidden = True
        UltraGridColumn8.Width = 100
        Appearance18.TextHAlignAsString = "Right"
        UltraGridColumn9.CellAppearance = Appearance18
        UltraGridColumn9.Format = "N2"
        UltraGridColumn9.Header.Caption = "Valor Costo"
        UltraGridColumn9.Header.VisiblePosition = 28
        UltraGridColumn9.Hidden = True
        UltraGridColumn9.Width = 100
        Appearance19.TextHAlignAsString = "Right"
        UltraGridColumn10.CellAppearance = Appearance19
        UltraGridColumn10.Format = "N2"
        UltraGridColumn10.Header.Caption = "Valor Venta"
        UltraGridColumn10.Header.VisiblePosition = 29
        UltraGridColumn10.Hidden = True
        UltraGridColumn10.Width = 100
        UltraGridColumn11.Header.Caption = "Depósito"
        UltraGridColumn11.Header.VisiblePosition = 18
        Appearance20.TextHAlignAsString = "Right"
        Appearance20.TextVAlignAsString = "Middle"
        UltraGridColumn12.CellAppearance = Appearance20
        UltraGridColumn12.Header.Caption = "Stock Depósito"
        UltraGridColumn12.Header.VisiblePosition = 19
        UltraGridColumn13.Header.Caption = "Ubicación"
        UltraGridColumn13.Header.VisiblePosition = 21
        Appearance21.TextHAlignAsString = "Right"
        Appearance21.TextVAlignAsString = "Middle"
        UltraGridColumn14.CellAppearance = Appearance21
        UltraGridColumn14.Header.Caption = "Stock Ubicación"
        UltraGridColumn14.Header.VisiblePosition = 22
        Appearance22.TextHAlignAsString = "Right"
        Appearance22.TextVAlignAsString = "Middle"
        UltraGridColumn15.CellAppearance = Appearance22
        UltraGridColumn15.Header.Caption = "Kilos"
        UltraGridColumn15.Header.VisiblePosition = 17
        Appearance23.TextHAlignAsString = "Right"
        Appearance23.TextVAlignAsString = "Middle"
        UltraGridColumn16.CellAppearance = Appearance23
        UltraGridColumn16.Header.Caption = "Kilos Deposito"
        UltraGridColumn16.Header.VisiblePosition = 20
        Appearance24.TextHAlignAsString = "Right"
        Appearance24.TextVAlignAsString = "Middle"
        UltraGridColumn17.CellAppearance = Appearance24
        UltraGridColumn17.Header.Caption = "Kilos Ubicacion"
        UltraGridColumn17.Header.VisiblePosition = 23
        UltraGridBand1.Columns.AddRange(New Object() {UltraGridColumn22, UltraGridColumn23, UltraGridColumn24, UltraGridColumn25, UltraGridColumn26, UltraGridColumn27, UltraGridColumn28, UltraGridColumn29, UltraGridColumn30, UltraGridColumn31, UltraGridColumn32, UltraGridColumn33, UltraGridColumn1, UltraGridColumn2, UltraGridColumn3, UltraGridColumn4, UltraGridColumn36, UltraGridColumn5, UltraGridColumn6, UltraGridColumn7, UltraGridColumn8, UltraGridColumn9, UltraGridColumn10, UltraGridColumn11, UltraGridColumn12, UltraGridColumn13, UltraGridColumn14, UltraGridColumn15, UltraGridColumn16, UltraGridColumn17})
        Me.ugdDetalle.DisplayLayout.BandsSerializer.Add(UltraGridBand1)
        Me.ugdDetalle.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.ugdDetalle.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.[False]
        Appearance25.BackColor = System.Drawing.SystemColors.ActiveBorder
        Appearance25.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance25.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Appearance25.BorderColor = System.Drawing.SystemColors.Window
        Me.ugdDetalle.DisplayLayout.GroupByBox.Appearance = Appearance25
        Appearance26.ForeColor = System.Drawing.SystemColors.GrayText
        Me.ugdDetalle.DisplayLayout.GroupByBox.BandLabelAppearance = Appearance26
        Me.ugdDetalle.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.ugdDetalle.DisplayLayout.GroupByBox.Prompt = " Arrastrar la Columna que desea agrupar"
        Appearance27.BackColor = System.Drawing.SystemColors.ControlLightLight
        Appearance27.BackColor2 = System.Drawing.SystemColors.Control
        Appearance27.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance27.ForeColor = System.Drawing.SystemColors.GrayText
        Me.ugdDetalle.DisplayLayout.GroupByBox.PromptAppearance = Appearance27
        Me.ugdDetalle.DisplayLayout.MaxColScrollRegions = 1
        Me.ugdDetalle.DisplayLayout.MaxRowScrollRegions = 1
        Appearance28.BackColor = System.Drawing.SystemColors.Window
        Appearance28.ForeColor = System.Drawing.SystemColors.ControlText
        Me.ugdDetalle.DisplayLayout.Override.ActiveCellAppearance = Appearance28
        Appearance29.BackColor = System.Drawing.SystemColors.Highlight
        Appearance29.ForeColor = System.Drawing.SystemColors.HighlightText
        Me.ugdDetalle.DisplayLayout.Override.ActiveRowAppearance = Appearance29
        Me.ugdDetalle.DisplayLayout.Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.No
        Me.ugdDetalle.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.[False]
        Me.ugdDetalle.DisplayLayout.Override.AllowUpdate = Infragistics.Win.DefaultableBoolean.[False]
        Me.ugdDetalle.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted
        Me.ugdDetalle.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted
        Appearance30.BackColor = System.Drawing.SystemColors.Window
        Me.ugdDetalle.DisplayLayout.Override.CardAreaAppearance = Appearance30
        Appearance31.BorderColor = System.Drawing.Color.Silver
        Appearance31.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter
        Me.ugdDetalle.DisplayLayout.Override.CellAppearance = Appearance31
        Me.ugdDetalle.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText
        Me.ugdDetalle.DisplayLayout.Override.CellPadding = 0
        Appearance32.BackColor = System.Drawing.SystemColors.Control
        Appearance32.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance32.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element
        Appearance32.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance32.BorderColor = System.Drawing.SystemColors.Window
        Me.ugdDetalle.DisplayLayout.Override.GroupByRowAppearance = Appearance32
        Appearance33.TextHAlignAsString = "Left"
        Me.ugdDetalle.DisplayLayout.Override.HeaderAppearance = Appearance33
        Me.ugdDetalle.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
        Me.ugdDetalle.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand
        Appearance34.BackColor = System.Drawing.SystemColors.Window
        Appearance34.BorderColor = System.Drawing.Color.Silver
        Me.ugdDetalle.DisplayLayout.Override.RowAppearance = Appearance34
        Me.ugdDetalle.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[True]
        Me.ugdDetalle.DisplayLayout.Override.SummaryDisplayArea = Infragistics.Win.UltraWinGrid.SummaryDisplayAreas.BottomFixed
        Appearance35.BackColor = System.Drawing.Color.SkyBlue
        Me.ugdDetalle.DisplayLayout.Override.SummaryValueAppearance = Appearance35
        Appearance36.BackColor = System.Drawing.SystemColors.ControlLight
        Me.ugdDetalle.DisplayLayout.Override.TemplateAddRowAppearance = Appearance36
        Me.ugdDetalle.DisplayLayout.Override.WrapHeaderText = Infragistics.Win.DefaultableBoolean.[True]
        Me.ugdDetalle.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill
        Me.ugdDetalle.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate
        Me.ugdDetalle.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy
        Me.ugdDetalle.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ugdDetalle.Location = New System.Drawing.Point(11, 172)
        Me.ugdDetalle.Name = "ugdDetalle"
        Me.ugdDetalle.Size = New System.Drawing.Size(961, 354)
        Me.ugdDetalle.TabIndex = 2
        Me.ugdDetalle.Text = "UltraGrid1"
        Me.ugdDetalle.ToolStripLabelRegistros = Me.tssRegistros
        Me.ugdDetalle.ToolStripMenuExpandir = Nothing
        '
        'UltraPrintPreviewDialog1
        '
        Me.UltraPrintPreviewDialog1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.UltraPrintPreviewDialog1.Document = Me.UltraGridPrintDocument1
        Me.UltraPrintPreviewDialog1.Name = "UltraPrintPreviewDialog1"
        '
        'UltraGridPrintDocument1
        '
        Me.UltraGridPrintDocument1.DocumentName = "Informe"
        Me.UltraGridPrintDocument1.Footer.TextCenter = ""
        Me.UltraGridPrintDocument1.Grid = Me.ugdDetalle
        Appearance37.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Appearance37.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element
        Appearance37.BackGradientStyle = Infragistics.Win.GradientStyle.VerticalBump
        Me.UltraGridPrintDocument1.Header.Appearance = Appearance37
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
        'txtCotizacionDolar
        '
        Me.txtCotizacionDolar.BackColor = System.Drawing.SystemColors.Window
        Me.txtCotizacionDolar.BindearPropiedadControl = Nothing
        Me.txtCotizacionDolar.BindearPropiedadEntidad = Nothing
        Me.txtCotizacionDolar.ForeColorFocus = System.Drawing.Color.Red
        Me.txtCotizacionDolar.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtCotizacionDolar.Formato = "N2"
        Me.txtCotizacionDolar.IsDecimal = True
        Me.txtCotizacionDolar.IsNumber = True
        Me.txtCotizacionDolar.IsPK = False
        Me.txtCotizacionDolar.IsRequired = False
        Me.txtCotizacionDolar.Key = ""
        Me.txtCotizacionDolar.LabelAsoc = Me.lblCotizacionDolar
        Me.txtCotizacionDolar.Location = New System.Drawing.Point(823, 179)
        Me.txtCotizacionDolar.MaxLength = 7
        Me.txtCotizacionDolar.Name = "txtCotizacionDolar"
        Me.txtCotizacionDolar.Size = New System.Drawing.Size(48, 20)
        Me.txtCotizacionDolar.TabIndex = 2
        Me.txtCotizacionDolar.Text = "0.00"
        Me.txtCotizacionDolar.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblCotizacionDolar
        '
        Me.lblCotizacionDolar.BackColor = System.Drawing.Color.DarkGray
        Me.lblCotizacionDolar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCotizacionDolar.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.lblCotizacionDolar.LabelAsoc = Nothing
        Me.lblCotizacionDolar.Location = New System.Drawing.Point(789, 180)
        Me.lblCotizacionDolar.Name = "lblCotizacionDolar"
        Me.lblCotizacionDolar.Size = New System.Drawing.Size(33, 18)
        Me.lblCotizacionDolar.TabIndex = 1
        Me.lblCotizacionDolar.Text = "Dolar"
        Me.lblCotizacionDolar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'InfStockValorizado
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(984, 551)
        Me.Controls.Add(Me.txtCotizacionDolar)
        Me.Controls.Add(Me.lblCotizacionDolar)
        Me.Controls.Add(Me.stsStado)
        Me.Controls.Add(Me.grbFiltros)
        Me.Controls.Add(Me.tstBarra)
        Me.Controls.Add(Me.chbConIVA)
        Me.Controls.Add(Me.ugdDetalle)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.Name = "InfStockValorizado"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Informe de Stock Valorizado"
        Me.grbFiltros.ResumeLayout(False)
        Me.grbFiltros.PerformLayout()
        Me.tstBarra.ResumeLayout(False)
        Me.tstBarra.PerformLayout()
        Me.stsStado.ResumeLayout(False)
        Me.stsStado.PerformLayout()
        CType(Me.ugdDetalle, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents grbFiltros As System.Windows.Forms.GroupBox
   Friend WithEvents cmbMarca As Eniac.Controles.ComboBox
   Friend WithEvents chbProducto As Eniac.Controles.CheckBox
   Public WithEvents tstBarra As System.Windows.Forms.ToolStrip
   Public WithEvents tsbRefrescar As System.Windows.Forms.ToolStripButton
   Private WithEvents toolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
   Public WithEvents tsbSalir As System.Windows.Forms.ToolStripButton
   Friend WithEvents lblSucursales As Eniac.Controles.Label
   Friend WithEvents chbMarca As Eniac.Controles.CheckBox
   Friend WithEvents chbRubro As Eniac.Controles.CheckBox
   Friend WithEvents cmbRubro As Eniac.Controles.ComboBox
   Protected Friend WithEvents stsStado As System.Windows.Forms.StatusStrip
   Protected Friend WithEvents tssInfo As System.Windows.Forms.ToolStripStatusLabel
   Protected Friend WithEvents tspBarra As System.Windows.Forms.ToolStripProgressBar
   Protected WithEvents tssRegistros As System.Windows.Forms.ToolStripStatusLabel
   Friend WithEvents btnCalcular As Eniac.Controles.Button
   Friend WithEvents chbSubRubro As Eniac.Controles.CheckBox
   Friend WithEvents cmbSubRubro As Eniac.Controles.ComboBox
   Private WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
   Friend WithEvents tsbImprimir As System.Windows.Forms.ToolStripButton
   Friend WithEvents dtpFecha As Eniac.Controles.DateTimePicker
   Friend WithEvents chbHastaFecha As Eniac.Controles.CheckBox
   Friend WithEvents ugdDetalle As UltraGridSiga
   Friend WithEvents chbConIVA As Eniac.Controles.CheckBox
   Friend WithEvents sfdExportar As System.Windows.Forms.SaveFileDialog
   Friend WithEvents UltraPrintPreviewDialog1 As Infragistics.Win.Printing.UltraPrintPreviewDialog
   Friend WithEvents UltraGridPrintDocument1 As Infragistics.Win.UltraWinGrid.UltraGridPrintDocument
   Friend WithEvents UltraGridExcelExporter1 As Infragistics.Win.UltraWinGrid.ExcelExport.UltraGridExcelExporter
   Friend WithEvents UltraGridDocumentExporter1 As Infragistics.Win.UltraWinGrid.DocumentExport.UltraGridDocumentExporter
   Friend WithEvents tsddExportar As System.Windows.Forms.ToolStripDropDownButton
   Friend WithEvents tsmiAExcel As System.Windows.Forms.ToolStripMenuItem
   Friend WithEvents tsmiAPDF As System.Windows.Forms.ToolStripMenuItem
   Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
   Friend WithEvents txtCotizacionDolar As Eniac.Controles.TextBox
   Friend WithEvents lblCotizacionDolar As Eniac.Controles.Label
   Friend WithEvents bscProducto2 As Eniac.Controles.Buscador2
   Friend WithEvents bscCodigoProducto2 As Eniac.Controles.Buscador2
   Friend WithEvents bscCodigoProveedor As Eniac.Controles.Buscador2
   Friend WithEvents Label1 As Eniac.Controles.Label
   Friend WithEvents chbProveedor As Eniac.Controles.CheckBox
   Friend WithEvents bscNombreProveedor As Eniac.Controles.Buscador2
   Friend WithEvents Label2 As Eniac.Controles.Label
   Public WithEvents tsbPreferencias As System.Windows.Forms.ToolStripButton
   Friend WithEvents cmbListaDePrecios As Eniac.Controles.ComboBox
   Friend WithEvents lblListaPrecios As Eniac.Controles.Label
   Friend WithEvents ToolStripSeparator4 As System.Windows.Forms.ToolStripSeparator
   Friend WithEvents chbProveedorHabitual As Eniac.Controles.CheckBox
   Friend WithEvents lblActivos As Eniac.Controles.Label
   Friend WithEvents cmbActivos As Eniac.Controles.ComboBox
   Friend WithEvents cmbSucursal As ComboBoxSucursales
   Friend WithEvents cmbDepositos As ComboBoxDepositos
   Friend WithEvents lblDeposito As Controles.Label
   Friend WithEvents cmbUbicacion As Eniac.Controles.ComboBox
   Friend WithEvents chbUbicacion As Controles.CheckBox
End Class
