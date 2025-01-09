<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ImportarPedidosExcel
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
      Dim UltraGridBand1 As Infragistics.Win.UltraWinGrid.UltraGridBand = New Infragistics.Win.UltraWinGrid.UltraGridBand("Band 0", -1)
      Dim UltraGridColumn4 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Importa")
      Dim UltraGridColumn3 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Accion")
      Dim UltraGridColumn23 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdTipoComprobante")
      Dim UltraGridColumn24 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NumeroPedido")
      Dim Appearance2 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn25 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Entidades_TipoComprobante")
      Dim UltraGridColumn9 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("FechaPedido")
      Dim Appearance3 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn26 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NumeroOrdenCompra")
      Dim Appearance4 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn6 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdCliente")
      Dim UltraGridColumn10 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("CodigoCliente")
      Dim Appearance5 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn1 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreFantasia")
      Dim UltraGridColumn12 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("TipoDocVendedor")
        Dim UltraGridColumn13 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NroDocVendedor", -1, Nothing, 0, Infragistics.Win.UltraWinGrid.SortIndicator.Ascending, False)
        Dim UltraGridColumn14 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreVendedor")
        Dim UltraGridColumn17 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Entidades_Vendedor")
        Dim UltraGridColumn15 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdFormasPago")
        Dim Appearance6 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn16 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("DescripcionFormasPago")
        Dim UltraGridColumn18 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Entidades_FormasPago")
        Dim UltraGridColumn7 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdProducto")
        Dim UltraGridColumn32 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("CodigoProveedor")
        Dim UltraGridColumn8 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreProducto")
        Dim UltraGridColumn11 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Cantidad")
        Dim Appearance7 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn27 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("PrecioCosto")
        Dim Appearance8 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn2 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("PrecioVenta")
        Dim Appearance9 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn5 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("TotalProducto")
        Dim Appearance10 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn19 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreListaPrecios")
        Dim UltraGridColumn20 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Entidades_ListaDePrecios")
        Dim UltraGridColumn21 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Observaciones")
        Dim UltraGridColumn22 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Mensaje")
        Dim UltraGridColumn29 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("ImportaProducto")
        Dim UltraGridColumn28 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreMarca")
        Dim UltraGridColumn30 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreRubro")
        Dim UltraGridColumn31 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IVA")
        Dim UltraGridColumn33 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Moneda")
        Dim UltraGridColumn35 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("DescuentoRecargoPorc")
        Dim Appearance11 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn36 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("DescuentoRecargoPorc2")
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
        Dim Appearance22 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance23 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ImportarPedidosExcel))
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.chbRespetaPrecios = New System.Windows.Forms.CheckBox()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.tbpFiltros = New System.Windows.Forms.TabPage()
        Me.grbPendientes = New System.Windows.Forms.GroupBox()
        Me.chbAnticipado = New Eniac.Controles.CheckBox()
        Me.chbDescuentoRecargo = New Eniac.Controles.CheckBox()
        Me.chbAltaProductos = New System.Windows.Forms.CheckBox()
        Me.txtRangoCeldasColumnaDesde = New Eniac.Controles.TextBox()
        Me.lblRangoCeldas = New Eniac.Controles.Label()
        Me.txtRangoCeldasColumnaHasta = New Eniac.Controles.TextBox()
        Me.txtRangoCeldasFilaDesde = New Eniac.Controles.TextBox()
        Me.txtRangoCeldasFilaHasta = New Eniac.Controles.TextBox()
        Me.lblSeparadosCeldas = New Eniac.Controles.Label()
        Me.lblEjemplos = New Eniac.Controles.Label()
        Me.dtpFechaEntrega = New Eniac.Controles.DateTimePicker()
        Me.chbFechaEntrega = New Eniac.Controles.CheckBox()
        Me.cmbFormaPago = New Eniac.Controles.ComboBox()
        Me.lblFormaPago = New Eniac.Controles.Label()
        Me.lblOrdenCompra = New Eniac.Controles.Label()
        Me.txtOrdenCompra = New Eniac.Controles.TextBox()
        Me.bscCodigoProveedor = New Eniac.Controles.Buscador()
        Me.bscProveedor = New Eniac.Controles.Buscador()
        Me.lblCodigoProveedor = New Eniac.Controles.Label()
        Me.lblNombre = New Eniac.Controles.Label()
        Me.cboAccion = New Eniac.Controles.ComboBox()
        Me.lblAccion = New Eniac.Controles.Label()
        Me.cmbFormatoArchivo = New Eniac.Controles.ComboBox()
        Me.lblFormatoArchivo = New Eniac.Controles.Label()
        Me.cboEstado = New Eniac.Controles.ComboBox()
        Me.lblEstado = New Eniac.Controles.Label()
        Me.txtArchivoOrigen = New Eniac.Controles.TextBox()
        Me.lblArchivo = New Eniac.Controles.Label()
        Me.btnExaminar = New Eniac.Controles.Button()
        Me.btnMostrar = New Eniac.Controles.Button()
        Me.lblProveedor = New Eniac.Controles.Label()
        Me.grpAltaProductos = New System.Windows.Forms.GroupBox()
        Me.Label4 = New Eniac.Controles.Label()
        Me.Label3 = New Eniac.Controles.Label()
        Me.Label2 = New Eniac.Controles.Label()
        Me.Label1 = New Eniac.Controles.Label()
        Me.bscCodigoRubro = New Eniac.Controles.Buscador()
        Me.bscRubro = New Eniac.Controles.Buscador()
        Me.bscCodigoMarca = New Eniac.Controles.Buscador()
        Me.bscMarca = New Eniac.Controles.Buscador()
        Me.cmbTipoImpuesto = New Eniac.Controles.ComboBox()
        Me.cmbMoneda = New Eniac.Controles.ComboBox()
        Me.ugDetalle = New Infragistics.Win.UltraWinGrid.UltraGrid()
        Me.prbImportando = New System.Windows.Forms.ProgressBar()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.tssInfo = New System.Windows.Forms.ToolStripStatusLabel()
        Me.tsbFormatoExcel = New System.Windows.Forms.ToolStripStatusLabel()
        Me.tslTiempoActual = New System.Windows.Forms.ToolStripStatusLabel()
        Me.tslRegistroActual = New System.Windows.Forms.ToolStripStatusLabel()
        Me.tssRegistros = New System.Windows.Forms.ToolStripStatusLabel()
        Me.tstBarra = New System.Windows.Forms.ToolStrip()
        Me.tsbRefrescar = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsbImportar = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsbSalir = New System.Windows.Forms.ToolStripButton()
        Me.TabControl1.SuspendLayout()
        Me.tbpFiltros.SuspendLayout()
        Me.grbPendientes.SuspendLayout()
        Me.grpAltaProductos.SuspendLayout()
        CType(Me.ugDetalle, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.StatusStrip1.SuspendLayout()
        Me.tstBarra.SuspendLayout()
        Me.SuspendLayout()
        '
        'chbRespetaPrecios
        '
        Me.chbRespetaPrecios.AutoSize = True
        Me.chbRespetaPrecios.Checked = True
        Me.chbRespetaPrecios.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chbRespetaPrecios.Location = New System.Drawing.Point(836, 30)
        Me.chbRespetaPrecios.Name = "chbRespetaPrecios"
        Me.chbRespetaPrecios.Size = New System.Drawing.Size(103, 17)
        Me.chbRespetaPrecios.TabIndex = 29
        Me.chbRespetaPrecios.Text = "Respeta precios"
        Me.ToolTip1.SetToolTip(Me.chbRespetaPrecios, "Respeta los precios de la Orden de Compra cuando se genera el pedido")
        Me.chbRespetaPrecios.UseVisualStyleBackColor = True
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.tbpFiltros)
        Me.TabControl1.Location = New System.Drawing.Point(7, 32)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(977, 176)
        Me.TabControl1.TabIndex = 0
        '
        'tbpFiltros
        '
        Me.tbpFiltros.Controls.Add(Me.grbPendientes)
        Me.tbpFiltros.Location = New System.Drawing.Point(4, 22)
        Me.tbpFiltros.Name = "tbpFiltros"
        Me.tbpFiltros.Padding = New System.Windows.Forms.Padding(3)
        Me.tbpFiltros.Size = New System.Drawing.Size(969, 150)
        Me.tbpFiltros.TabIndex = 0
        Me.tbpFiltros.Text = "Filtros"
        Me.tbpFiltros.UseVisualStyleBackColor = True
        '
        'grbPendientes
        '
        Me.grbPendientes.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grbPendientes.Controls.Add(Me.chbAnticipado)
        Me.grbPendientes.Controls.Add(Me.chbDescuentoRecargo)
        Me.grbPendientes.Controls.Add(Me.chbAltaProductos)
        Me.grbPendientes.Controls.Add(Me.txtRangoCeldasColumnaDesde)
        Me.grbPendientes.Controls.Add(Me.txtRangoCeldasColumnaHasta)
        Me.grbPendientes.Controls.Add(Me.txtRangoCeldasFilaDesde)
        Me.grbPendientes.Controls.Add(Me.txtRangoCeldasFilaHasta)
        Me.grbPendientes.Controls.Add(Me.lblRangoCeldas)
        Me.grbPendientes.Controls.Add(Me.lblSeparadosCeldas)
        Me.grbPendientes.Controls.Add(Me.lblEjemplos)
        Me.grbPendientes.Controls.Add(Me.dtpFechaEntrega)
        Me.grbPendientes.Controls.Add(Me.chbFechaEntrega)
        Me.grbPendientes.Controls.Add(Me.chbRespetaPrecios)
        Me.grbPendientes.Controls.Add(Me.cmbFormaPago)
        Me.grbPendientes.Controls.Add(Me.lblFormaPago)
        Me.grbPendientes.Controls.Add(Me.lblOrdenCompra)
        Me.grbPendientes.Controls.Add(Me.txtOrdenCompra)
        Me.grbPendientes.Controls.Add(Me.bscCodigoProveedor)
        Me.grbPendientes.Controls.Add(Me.bscProveedor)
        Me.grbPendientes.Controls.Add(Me.lblCodigoProveedor)
        Me.grbPendientes.Controls.Add(Me.lblNombre)
        Me.grbPendientes.Controls.Add(Me.cboAccion)
        Me.grbPendientes.Controls.Add(Me.cmbFormatoArchivo)
        Me.grbPendientes.Controls.Add(Me.lblFormatoArchivo)
        Me.grbPendientes.Controls.Add(Me.cboEstado)
        Me.grbPendientes.Controls.Add(Me.lblEstado)
        Me.grbPendientes.Controls.Add(Me.txtArchivoOrigen)
        Me.grbPendientes.Controls.Add(Me.lblArchivo)
        Me.grbPendientes.Controls.Add(Me.btnExaminar)
        Me.grbPendientes.Controls.Add(Me.btnMostrar)
        Me.grbPendientes.Controls.Add(Me.lblProveedor)
        Me.grbPendientes.Controls.Add(Me.grpAltaProductos)
        Me.grbPendientes.Controls.Add(Me.lblAccion)
        Me.grbPendientes.Location = New System.Drawing.Point(3, -1)
        Me.grbPendientes.Name = "grbPendientes"
        Me.grbPendientes.Size = New System.Drawing.Size(963, 151)
        Me.grbPendientes.TabIndex = 0
        Me.grbPendientes.TabStop = False
        '
        'chbAnticipado
        '
        Me.chbAnticipado.AutoSize = True
        Me.chbAnticipado.BindearPropiedadControl = "Checked"
        Me.chbAnticipado.BindearPropiedadEntidad = "AplicaDescuentoRecargo"
        Me.chbAnticipado.ForeColorFocus = System.Drawing.Color.Red
        Me.chbAnticipado.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbAnticipado.IsPK = False
        Me.chbAnticipado.IsRequired = False
        Me.chbAnticipado.Key = Nothing
        Me.chbAnticipado.LabelAsoc = Nothing
        Me.chbAnticipado.Location = New System.Drawing.Point(836, 74)
        Me.chbAnticipado.Name = "chbAnticipado"
        Me.chbAnticipado.Size = New System.Drawing.Size(76, 17)
        Me.chbAnticipado.TabIndex = 40
        Me.chbAnticipado.Text = "Anticipado"
        Me.chbAnticipado.UseVisualStyleBackColor = True
        '
        'chbDescuentoRecargo
        '
        Me.chbDescuentoRecargo.AutoSize = True
        Me.chbDescuentoRecargo.BindearPropiedadControl = "Checked"
        Me.chbDescuentoRecargo.BindearPropiedadEntidad = "AplicaDescuentoRecargo"
        Me.chbDescuentoRecargo.ForeColorFocus = System.Drawing.Color.Red
        Me.chbDescuentoRecargo.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbDescuentoRecargo.IsPK = False
        Me.chbDescuentoRecargo.IsRequired = False
        Me.chbDescuentoRecargo.Key = Nothing
        Me.chbDescuentoRecargo.LabelAsoc = Nothing
        Me.chbDescuentoRecargo.Location = New System.Drawing.Point(836, 51)
        Me.chbDescuentoRecargo.Name = "chbDescuentoRecargo"
        Me.chbDescuentoRecargo.Size = New System.Drawing.Size(122, 17)
        Me.chbDescuentoRecargo.TabIndex = 39
        Me.chbDescuentoRecargo.Text = "Impuesto Ley 25413"
        Me.chbDescuentoRecargo.UseVisualStyleBackColor = True
        '
        'chbAltaProductos
        '
        Me.chbAltaProductos.AutoSize = True
        Me.chbAltaProductos.Location = New System.Drawing.Point(567, 11)
        Me.chbAltaProductos.Name = "chbAltaProductos"
        Me.chbAltaProductos.Size = New System.Drawing.Size(168, 17)
        Me.chbAltaProductos.TabIndex = 4
        Me.chbAltaProductos.Text = "Alta de Productos inexistentes"
        Me.chbAltaProductos.UseVisualStyleBackColor = True
        '
        'txtRangoCeldasColumnaDesde
        '
        Me.txtRangoCeldasColumnaDesde.BindearPropiedadControl = Nothing
        Me.txtRangoCeldasColumnaDesde.BindearPropiedadEntidad = Nothing
        Me.txtRangoCeldasColumnaDesde.ForeColorFocus = System.Drawing.Color.Red
        Me.txtRangoCeldasColumnaDesde.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtRangoCeldasColumnaDesde.Formato = ""
        Me.txtRangoCeldasColumnaDesde.IsDecimal = False
        Me.txtRangoCeldasColumnaDesde.IsNumber = False
        Me.txtRangoCeldasColumnaDesde.IsPK = False
        Me.txtRangoCeldasColumnaDesde.IsRequired = False
        Me.txtRangoCeldasColumnaDesde.Key = ""
        Me.txtRangoCeldasColumnaDesde.LabelAsoc = Me.lblRangoCeldas
        Me.txtRangoCeldasColumnaDesde.Location = New System.Drawing.Point(442, 74)
        Me.txtRangoCeldasColumnaDesde.Name = "txtRangoCeldasColumnaDesde"
        Me.txtRangoCeldasColumnaDesde.Size = New System.Drawing.Size(20, 20)
        Me.txtRangoCeldasColumnaDesde.TabIndex = 11
        Me.txtRangoCeldasColumnaDesde.Text = "A"
        Me.txtRangoCeldasColumnaDesde.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'lblRangoCeldas
        '
        Me.lblRangoCeldas.AutoSize = True
        Me.lblRangoCeldas.LabelAsoc = Nothing
        Me.lblRangoCeldas.Location = New System.Drawing.Point(445, 59)
        Me.lblRangoCeldas.Name = "lblRangoCeldas"
        Me.lblRangoCeldas.Size = New System.Drawing.Size(88, 13)
        Me.lblRangoCeldas.TabIndex = 10
        Me.lblRangoCeldas.Text = "Rango de celdas"
        '
        'txtRangoCeldasColumnaHasta
        '
        Me.txtRangoCeldasColumnaHasta.BindearPropiedadControl = Nothing
        Me.txtRangoCeldasColumnaHasta.BindearPropiedadEntidad = Nothing
        Me.txtRangoCeldasColumnaHasta.ForeColorFocus = System.Drawing.Color.Red
        Me.txtRangoCeldasColumnaHasta.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtRangoCeldasColumnaHasta.Formato = ""
        Me.txtRangoCeldasColumnaHasta.IsDecimal = False
        Me.txtRangoCeldasColumnaHasta.IsNumber = False
        Me.txtRangoCeldasColumnaHasta.IsPK = False
        Me.txtRangoCeldasColumnaHasta.IsRequired = False
        Me.txtRangoCeldasColumnaHasta.Key = ""
        Me.txtRangoCeldasColumnaHasta.LabelAsoc = Me.lblRangoCeldas
        Me.txtRangoCeldasColumnaHasta.Location = New System.Drawing.Point(499, 74)
        Me.txtRangoCeldasColumnaHasta.Name = "txtRangoCeldasColumnaHasta"
        Me.txtRangoCeldasColumnaHasta.Size = New System.Drawing.Size(20, 20)
        Me.txtRangoCeldasColumnaHasta.TabIndex = 13
        Me.txtRangoCeldasColumnaHasta.Text = "T"
        Me.txtRangoCeldasColumnaHasta.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtRangoCeldasFilaDesde
        '
        Me.txtRangoCeldasFilaDesde.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.txtRangoCeldasFilaDesde.BindearPropiedadControl = Nothing
        Me.txtRangoCeldasFilaDesde.BindearPropiedadEntidad = Nothing
        Me.txtRangoCeldasFilaDesde.ForeColorFocus = System.Drawing.Color.Red
        Me.txtRangoCeldasFilaDesde.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtRangoCeldasFilaDesde.Formato = ""
        Me.txtRangoCeldasFilaDesde.IsDecimal = False
        Me.txtRangoCeldasFilaDesde.IsNumber = False
        Me.txtRangoCeldasFilaDesde.IsPK = False
        Me.txtRangoCeldasFilaDesde.IsRequired = False
        Me.txtRangoCeldasFilaDesde.Key = ""
        Me.txtRangoCeldasFilaDesde.LabelAsoc = Me.lblRangoCeldas
        Me.txtRangoCeldasFilaDesde.Location = New System.Drawing.Point(461, 74)
        Me.txtRangoCeldasFilaDesde.Name = "txtRangoCeldasFilaDesde"
        Me.txtRangoCeldasFilaDesde.Size = New System.Drawing.Size(30, 20)
        Me.txtRangoCeldasFilaDesde.TabIndex = 12
        Me.txtRangoCeldasFilaDesde.Text = "4"
        Me.txtRangoCeldasFilaDesde.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtRangoCeldasFilaHasta
        '
        Me.txtRangoCeldasFilaHasta.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.txtRangoCeldasFilaHasta.BindearPropiedadControl = Nothing
        Me.txtRangoCeldasFilaHasta.BindearPropiedadEntidad = Nothing
        Me.txtRangoCeldasFilaHasta.ForeColorFocus = System.Drawing.Color.Red
        Me.txtRangoCeldasFilaHasta.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtRangoCeldasFilaHasta.Formato = ""
        Me.txtRangoCeldasFilaHasta.IsDecimal = False
        Me.txtRangoCeldasFilaHasta.IsNumber = False
        Me.txtRangoCeldasFilaHasta.IsPK = False
        Me.txtRangoCeldasFilaHasta.IsRequired = False
        Me.txtRangoCeldasFilaHasta.Key = ""
        Me.txtRangoCeldasFilaHasta.LabelAsoc = Me.lblRangoCeldas
        Me.txtRangoCeldasFilaHasta.Location = New System.Drawing.Point(518, 74)
        Me.txtRangoCeldasFilaHasta.Name = "txtRangoCeldasFilaHasta"
        Me.txtRangoCeldasFilaHasta.Size = New System.Drawing.Size(46, 20)
        Me.txtRangoCeldasFilaHasta.TabIndex = 14
        Me.txtRangoCeldasFilaHasta.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblSeparadosCeldas
        '
        Me.lblSeparadosCeldas.AutoSize = True
        Me.lblSeparadosCeldas.LabelAsoc = Nothing
        Me.lblSeparadosCeldas.Location = New System.Drawing.Point(490, 78)
        Me.lblSeparadosCeldas.Name = "lblSeparadosCeldas"
        Me.lblSeparadosCeldas.Size = New System.Drawing.Size(10, 13)
        Me.lblSeparadosCeldas.TabIndex = 14
        Me.lblSeparadosCeldas.Text = ":"
        Me.lblSeparadosCeldas.Visible = False
        '
        'lblEjemplos
        '
        Me.lblEjemplos.AutoSize = True
        Me.lblEjemplos.LabelAsoc = Nothing
        Me.lblEjemplos.Location = New System.Drawing.Point(439, 97)
        Me.lblEjemplos.Name = "lblEjemplos"
        Me.lblEjemplos.Size = New System.Drawing.Size(101, 13)
        Me.lblEjemplos.TabIndex = 24
        Me.lblEjemplos.Text = "Ejemplo:  A4 : Q200"
        Me.lblEjemplos.Visible = False
        '
        'dtpFechaEntrega
        '
        Me.dtpFechaEntrega.BindearPropiedadControl = Nothing
        Me.dtpFechaEntrega.BindearPropiedadEntidad = Nothing
        Me.dtpFechaEntrega.CustomFormat = "dd/MM/yyyy"
        Me.dtpFechaEntrega.Enabled = False
        Me.dtpFechaEntrega.ForeColorFocus = System.Drawing.Color.Red
        Me.dtpFechaEntrega.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.dtpFechaEntrega.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpFechaEntrega.IsPK = False
        Me.dtpFechaEntrega.IsRequired = False
        Me.dtpFechaEntrega.Key = ""
        Me.dtpFechaEntrega.LabelAsoc = Nothing
        Me.dtpFechaEntrega.Location = New System.Drawing.Point(671, 122)
        Me.dtpFechaEntrega.Name = "dtpFechaEntrega"
        Me.dtpFechaEntrega.Size = New System.Drawing.Size(95, 20)
        Me.dtpFechaEntrega.TabIndex = 28
        Me.dtpFechaEntrega.Visible = False
        '
        'chbFechaEntrega
        '
        Me.chbFechaEntrega.AutoSize = True
        Me.chbFechaEntrega.BindearPropiedadControl = Nothing
        Me.chbFechaEntrega.BindearPropiedadEntidad = Nothing
        Me.chbFechaEntrega.ForeColorFocus = System.Drawing.Color.Red
        Me.chbFechaEntrega.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbFechaEntrega.IsPK = False
        Me.chbFechaEntrega.IsRequired = False
        Me.chbFechaEntrega.Key = Nothing
        Me.chbFechaEntrega.LabelAsoc = Nothing
        Me.chbFechaEntrega.Location = New System.Drawing.Point(569, 124)
        Me.chbFechaEntrega.Name = "chbFechaEntrega"
        Me.chbFechaEntrega.Size = New System.Drawing.Size(96, 17)
        Me.chbFechaEntrega.TabIndex = 27
        Me.chbFechaEntrega.Text = "Fecha Entrega"
        Me.chbFechaEntrega.UseVisualStyleBackColor = True
        Me.chbFechaEntrega.Visible = False
        '
        'cmbFormaPago
        '
        Me.cmbFormaPago.BindearPropiedadControl = Nothing
        Me.cmbFormaPago.BindearPropiedadEntidad = Nothing
        Me.cmbFormaPago.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbFormaPago.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbFormaPago.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbFormaPago.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbFormaPago.FormattingEnabled = True
        Me.cmbFormaPago.IsPK = False
        Me.cmbFormaPago.IsRequired = False
        Me.cmbFormaPago.Key = Nothing
        Me.cmbFormaPago.LabelAsoc = Me.lblFormaPago
        Me.cmbFormaPago.Location = New System.Drawing.Point(5, 74)
        Me.cmbFormaPago.Name = "cmbFormaPago"
        Me.cmbFormaPago.Size = New System.Drawing.Size(194, 21)
        Me.cmbFormaPago.TabIndex = 18
        '
        'lblFormaPago
        '
        Me.lblFormaPago.AutoSize = True
        Me.lblFormaPago.LabelAsoc = Nothing
        Me.lblFormaPago.Location = New System.Drawing.Point(2, 60)
        Me.lblFormaPago.Name = "lblFormaPago"
        Me.lblFormaPago.Size = New System.Drawing.Size(79, 13)
        Me.lblFormaPago.TabIndex = 17
        Me.lblFormaPago.Text = "Forma de &Pago"
        '
        'lblOrdenCompra
        '
        Me.lblOrdenCompra.AutoSize = True
        Me.lblOrdenCompra.LabelAsoc = Nothing
        Me.lblOrdenCompra.Location = New System.Drawing.Point(3, 105)
        Me.lblOrdenCompra.Name = "lblOrdenCompra"
        Me.lblOrdenCompra.Size = New System.Drawing.Size(90, 13)
        Me.lblOrdenCompra.TabIndex = 25
        Me.lblOrdenCompra.Text = "Orden de Compra"
        '
        'txtOrdenCompra
        '
        Me.txtOrdenCompra.BindearPropiedadControl = "Text"
        Me.txtOrdenCompra.BindearPropiedadEntidad = "CantidadProductos"
        Me.txtOrdenCompra.ForeColorFocus = System.Drawing.Color.Red
        Me.txtOrdenCompra.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtOrdenCompra.Formato = ""
        Me.txtOrdenCompra.IsDecimal = False
        Me.txtOrdenCompra.IsNumber = False
        Me.txtOrdenCompra.IsPK = False
        Me.txtOrdenCompra.IsRequired = False
        Me.txtOrdenCompra.Key = ""
        Me.txtOrdenCompra.LabelAsoc = Me.lblOrdenCompra
        Me.txtOrdenCompra.Location = New System.Drawing.Point(5, 121)
        Me.txtOrdenCompra.Name = "txtOrdenCompra"
        Me.txtOrdenCompra.Size = New System.Drawing.Size(111, 20)
        Me.txtOrdenCompra.TabIndex = 26
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
        Me.bscCodigoProveedor.FilaDevuelta = Nothing
        Me.bscCodigoProveedor.ForeColorFocus = System.Drawing.Color.Red
        Me.bscCodigoProveedor.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.bscCodigoProveedor.IsDecimal = False
        Me.bscCodigoProveedor.IsNumber = True
        Me.bscCodigoProveedor.IsPK = False
        Me.bscCodigoProveedor.IsRequired = False
        Me.bscCodigoProveedor.Key = ""
        Me.bscCodigoProveedor.LabelAsoc = Nothing
        Me.bscCodigoProveedor.Location = New System.Drawing.Point(201, 119)
        Me.bscCodigoProveedor.MaxLengh = "32767"
        Me.bscCodigoProveedor.Name = "bscCodigoProveedor"
        Me.bscCodigoProveedor.Permitido = True
        Me.bscCodigoProveedor.Selecciono = False
        Me.bscCodigoProveedor.Size = New System.Drawing.Size(90, 20)
        Me.bscCodigoProveedor.TabIndex = 21
        Me.bscCodigoProveedor.Tag = "IdProveedor"
        Me.bscCodigoProveedor.Titulo = Nothing
        '
        'bscProveedor
        '
        Me.bscProveedor.AyudaAncho = 608
        Me.bscProveedor.BindearPropiedadControl = Nothing
        Me.bscProveedor.BindearPropiedadEntidad = Nothing
        Me.bscProveedor.ColumnasAlineacion = Nothing
        Me.bscProveedor.ColumnasAncho = Nothing
        Me.bscProveedor.ColumnasFormato = Nothing
        Me.bscProveedor.ColumnasOcultas = Nothing
        Me.bscProveedor.ColumnasTitulos = Nothing
        Me.bscProveedor.Datos = Nothing
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
        Me.bscProveedor.Location = New System.Drawing.Point(298, 119)
        Me.bscProveedor.Margin = New System.Windows.Forms.Padding(4)
        Me.bscProveedor.MaxLengh = "32767"
        Me.bscProveedor.Name = "bscProveedor"
        Me.bscProveedor.Permitido = True
        Me.bscProveedor.Selecciono = False
        Me.bscProveedor.Size = New System.Drawing.Size(236, 20)
        Me.bscProveedor.TabIndex = 23
        Me.bscProveedor.Titulo = Nothing
        '
        'lblCodigoProveedor
        '
        Me.lblCodigoProveedor.AutoSize = True
        Me.lblCodigoProveedor.LabelAsoc = Nothing
        Me.lblCodigoProveedor.Location = New System.Drawing.Point(198, 103)
        Me.lblCodigoProveedor.Name = "lblCodigoProveedor"
        Me.lblCodigoProveedor.Size = New System.Drawing.Size(40, 13)
        Me.lblCodigoProveedor.TabIndex = 20
        Me.lblCodigoProveedor.Text = "Código"
        '
        'lblNombre
        '
        Me.lblNombre.AutoSize = True
        Me.lblNombre.LabelAsoc = Nothing
        Me.lblNombre.Location = New System.Drawing.Point(295, 103)
        Me.lblNombre.Name = "lblNombre"
        Me.lblNombre.Size = New System.Drawing.Size(44, 13)
        Me.lblNombre.TabIndex = 22
        Me.lblNombre.Text = "Nombre"
        '
        'cboAccion
        '
        Me.cboAccion.BindearPropiedadControl = Nothing
        Me.cboAccion.BindearPropiedadEntidad = Nothing
        Me.cboAccion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboAccion.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboAccion.ForeColorFocus = System.Drawing.Color.Red
        Me.cboAccion.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cboAccion.FormattingEnabled = True
        Me.cboAccion.IsPK = False
        Me.cboAccion.IsRequired = False
        Me.cboAccion.Key = Nothing
        Me.cboAccion.LabelAsoc = Me.lblAccion
        Me.cboAccion.Location = New System.Drawing.Point(387, 74)
        Me.cboAccion.Name = "cboAccion"
        Me.cboAccion.Size = New System.Drawing.Size(51, 21)
        Me.cboAccion.TabIndex = 9
        Me.cboAccion.Visible = False
        '
        'lblAccion
        '
        Me.lblAccion.AutoSize = True
        Me.lblAccion.LabelAsoc = Nothing
        Me.lblAccion.Location = New System.Drawing.Point(343, 78)
        Me.lblAccion.Name = "lblAccion"
        Me.lblAccion.Size = New System.Drawing.Size(40, 13)
        Me.lblAccion.TabIndex = 8
        Me.lblAccion.Text = "Accion"
        Me.lblAccion.Visible = False
        '
        'cmbFormatoArchivo
        '
        Me.cmbFormatoArchivo.BindearPropiedadControl = Nothing
        Me.cmbFormatoArchivo.BindearPropiedadEntidad = Nothing
        Me.cmbFormatoArchivo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbFormatoArchivo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbFormatoArchivo.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbFormatoArchivo.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbFormatoArchivo.FormattingEnabled = True
        Me.cmbFormatoArchivo.IsPK = False
        Me.cmbFormatoArchivo.IsRequired = False
        Me.cmbFormatoArchivo.Key = Nothing
        Me.cmbFormatoArchivo.LabelAsoc = Me.lblFormatoArchivo
        Me.cmbFormatoArchivo.Location = New System.Drawing.Point(5, 28)
        Me.cmbFormatoArchivo.Name = "cmbFormatoArchivo"
        Me.cmbFormatoArchivo.Size = New System.Drawing.Size(111, 21)
        Me.cmbFormatoArchivo.TabIndex = 3
        '
        'lblFormatoArchivo
        '
        Me.lblFormatoArchivo.AutoSize = True
        Me.lblFormatoArchivo.LabelAsoc = Nothing
        Me.lblFormatoArchivo.Location = New System.Drawing.Point(2, 13)
        Me.lblFormatoArchivo.Name = "lblFormatoArchivo"
        Me.lblFormatoArchivo.Size = New System.Drawing.Size(99, 13)
        Me.lblFormatoArchivo.TabIndex = 1
        Me.lblFormatoArchivo.Text = "Formato de Archivo"
        '
        'cboEstado
        '
        Me.cboEstado.BindearPropiedadControl = Nothing
        Me.cboEstado.BindearPropiedadEntidad = Nothing
        Me.cboEstado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboEstado.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboEstado.ForeColorFocus = System.Drawing.Color.Red
        Me.cboEstado.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cboEstado.FormattingEnabled = True
        Me.cboEstado.IsPK = False
        Me.cboEstado.IsRequired = False
        Me.cboEstado.Key = Nothing
        Me.cboEstado.LabelAsoc = Me.lblEstado
        Me.cboEstado.Location = New System.Drawing.Point(243, 74)
        Me.cboEstado.Name = "cboEstado"
        Me.cboEstado.Size = New System.Drawing.Size(96, 21)
        Me.cboEstado.TabIndex = 7
        '
        'lblEstado
        '
        Me.lblEstado.AutoSize = True
        Me.lblEstado.LabelAsoc = Nothing
        Me.lblEstado.Location = New System.Drawing.Point(205, 78)
        Me.lblEstado.Name = "lblEstado"
        Me.lblEstado.Size = New System.Drawing.Size(40, 13)
        Me.lblEstado.TabIndex = 6
        Me.lblEstado.Text = "Estado"
        '
        'txtArchivoOrigen
        '
        Me.txtArchivoOrigen.BindearPropiedadControl = "Text"
        Me.txtArchivoOrigen.BindearPropiedadEntidad = "CantidadProductos"
        Me.txtArchivoOrigen.ForeColorFocus = System.Drawing.Color.Red
        Me.txtArchivoOrigen.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtArchivoOrigen.Formato = ""
        Me.txtArchivoOrigen.IsDecimal = False
        Me.txtArchivoOrigen.IsNumber = False
        Me.txtArchivoOrigen.IsPK = False
        Me.txtArchivoOrigen.IsRequired = False
        Me.txtArchivoOrigen.Key = ""
        Me.txtArchivoOrigen.LabelAsoc = Nothing
        Me.txtArchivoOrigen.Location = New System.Drawing.Point(165, 26)
        Me.txtArchivoOrigen.Name = "txtArchivoOrigen"
        Me.txtArchivoOrigen.Size = New System.Drawing.Size(280, 20)
        Me.txtArchivoOrigen.TabIndex = 1
        '
        'lblArchivo
        '
        Me.lblArchivo.AutoSize = True
        Me.lblArchivo.LabelAsoc = Nothing
        Me.lblArchivo.Location = New System.Drawing.Point(124, 30)
        Me.lblArchivo.Name = "lblArchivo"
        Me.lblArchivo.Size = New System.Drawing.Size(43, 13)
        Me.lblArchivo.TabIndex = 0
        Me.lblArchivo.Text = "Archivo"
        '
        'btnExaminar
        '
        Me.btnExaminar.Image = Global.Eniac.Win.My.Resources.Resources.folder_32
        Me.btnExaminar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnExaminar.Location = New System.Drawing.Point(451, 11)
        Me.btnExaminar.Name = "btnExaminar"
        Me.btnExaminar.Size = New System.Drawing.Size(104, 40)
        Me.btnExaminar.TabIndex = 2
        Me.btnExaminar.Text = "&Examinar..."
        Me.btnExaminar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnExaminar.UseVisualStyleBackColor = True
        '
        'btnMostrar
        '
        Me.btnMostrar.Image = Global.Eniac.Win.My.Resources.Resources.view
        Me.btnMostrar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnMostrar.Location = New System.Drawing.Point(843, 99)
        Me.btnMostrar.Name = "btnMostrar"
        Me.btnMostrar.Size = New System.Drawing.Size(100, 45)
        Me.btnMostrar.TabIndex = 30
        Me.btnMostrar.Text = "&Mostrar"
        Me.btnMostrar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnMostrar.UseVisualStyleBackColor = False
        '
        'lblProveedor
        '
        Me.lblProveedor.AutoSize = True
        Me.lblProveedor.LabelAsoc = Nothing
        Me.lblProveedor.Location = New System.Drawing.Point(143, 123)
        Me.lblProveedor.Name = "lblProveedor"
        Me.lblProveedor.Size = New System.Drawing.Size(56, 13)
        Me.lblProveedor.TabIndex = 19
        Me.lblProveedor.Text = "Proveedor"
        '
        'grpAltaProductos
        '
        Me.grpAltaProductos.Controls.Add(Me.Label4)
        Me.grpAltaProductos.Controls.Add(Me.Label3)
        Me.grpAltaProductos.Controls.Add(Me.Label2)
        Me.grpAltaProductos.Controls.Add(Me.Label1)
        Me.grpAltaProductos.Controls.Add(Me.bscCodigoRubro)
        Me.grpAltaProductos.Controls.Add(Me.bscRubro)
        Me.grpAltaProductos.Controls.Add(Me.bscCodigoMarca)
        Me.grpAltaProductos.Controls.Add(Me.bscMarca)
        Me.grpAltaProductos.Controls.Add(Me.cmbTipoImpuesto)
        Me.grpAltaProductos.Controls.Add(Me.cmbMoneda)
        Me.grpAltaProductos.Enabled = False
        Me.grpAltaProductos.Location = New System.Drawing.Point(565, 22)
        Me.grpAltaProductos.Name = "grpAltaProductos"
        Me.grpAltaProductos.Size = New System.Drawing.Size(263, 96)
        Me.grpAltaProductos.TabIndex = 5
        Me.grpAltaProductos.TabStop = False
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.LabelAsoc = Nothing
        Me.Label4.Location = New System.Drawing.Point(8, 73)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(36, 13)
        Me.Label4.TabIndex = 7
        Me.Label4.Text = "Rubro"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.LabelAsoc = Nothing
        Me.Label3.Location = New System.Drawing.Point(7, 47)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(37, 13)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "Marca"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.LabelAsoc = Nothing
        Me.Label2.Location = New System.Drawing.Point(136, 15)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(65, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Alicuota IVA"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.LabelAsoc = Nothing
        Me.Label1.Location = New System.Drawing.Point(1, 15)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(46, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Moneda"
        '
        'bscCodigoRubro
        '
        Me.bscCodigoRubro.AyudaAncho = 608
        Me.bscCodigoRubro.BindearPropiedadControl = "Text"
        Me.bscCodigoRubro.BindearPropiedadEntidad = "IdRubro"
        Me.bscCodigoRubro.ColumnasAlineacion = Nothing
        Me.bscCodigoRubro.ColumnasAncho = Nothing
        Me.bscCodigoRubro.ColumnasFormato = Nothing
        Me.bscCodigoRubro.ColumnasOcultas = Nothing
        Me.bscCodigoRubro.ColumnasTitulos = Nothing
        Me.bscCodigoRubro.Datos = Nothing
        Me.bscCodigoRubro.FilaDevuelta = Nothing
        Me.bscCodigoRubro.ForeColorFocus = System.Drawing.Color.Red
        Me.bscCodigoRubro.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.bscCodigoRubro.IsDecimal = False
        Me.bscCodigoRubro.IsNumber = False
        Me.bscCodigoRubro.IsPK = False
        Me.bscCodigoRubro.IsRequired = False
        Me.bscCodigoRubro.Key = ""
        Me.bscCodigoRubro.LabelAsoc = Nothing
        Me.bscCodigoRubro.Location = New System.Drawing.Point(50, 68)
        Me.bscCodigoRubro.MaxLengh = "32767"
        Me.bscCodigoRubro.Name = "bscCodigoRubro"
        Me.bscCodigoRubro.Permitido = True
        Me.bscCodigoRubro.Selecciono = False
        Me.bscCodigoRubro.Size = New System.Drawing.Size(80, 20)
        Me.bscCodigoRubro.TabIndex = 8
        Me.bscCodigoRubro.Titulo = Nothing
        '
        'bscRubro
        '
        Me.bscRubro.AyudaAncho = 608
        Me.bscRubro.BindearPropiedadControl = Nothing
        Me.bscRubro.BindearPropiedadEntidad = Nothing
        Me.bscRubro.ColumnasAlineacion = Nothing
        Me.bscRubro.ColumnasAncho = Nothing
        Me.bscRubro.ColumnasFormato = Nothing
        Me.bscRubro.ColumnasOcultas = Nothing
        Me.bscRubro.ColumnasTitulos = Nothing
        Me.bscRubro.Datos = Nothing
        Me.bscRubro.FilaDevuelta = Nothing
        Me.bscRubro.ForeColorFocus = System.Drawing.Color.Red
        Me.bscRubro.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.bscRubro.IsDecimal = False
        Me.bscRubro.IsNumber = False
        Me.bscRubro.IsPK = False
        Me.bscRubro.IsRequired = False
        Me.bscRubro.Key = ""
        Me.bscRubro.LabelAsoc = Nothing
        Me.bscRubro.Location = New System.Drawing.Point(134, 68)
        Me.bscRubro.MaxLengh = "32767"
        Me.bscRubro.Name = "bscRubro"
        Me.bscRubro.Permitido = True
        Me.bscRubro.Selecciono = False
        Me.bscRubro.Size = New System.Drawing.Size(123, 20)
        Me.bscRubro.TabIndex = 9
        Me.bscRubro.Titulo = Nothing
        '
        'bscCodigoMarca
        '
        Me.bscCodigoMarca.AyudaAncho = 608
        Me.bscCodigoMarca.BindearPropiedadControl = "Text"
        Me.bscCodigoMarca.BindearPropiedadEntidad = "IdMarca"
        Me.bscCodigoMarca.ColumnasAlineacion = Nothing
        Me.bscCodigoMarca.ColumnasAncho = Nothing
        Me.bscCodigoMarca.ColumnasFormato = Nothing
        Me.bscCodigoMarca.ColumnasOcultas = Nothing
        Me.bscCodigoMarca.ColumnasTitulos = Nothing
        Me.bscCodigoMarca.Datos = Nothing
        Me.bscCodigoMarca.FilaDevuelta = Nothing
        Me.bscCodigoMarca.ForeColorFocus = System.Drawing.Color.Red
        Me.bscCodigoMarca.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.bscCodigoMarca.IsDecimal = False
        Me.bscCodigoMarca.IsNumber = False
        Me.bscCodigoMarca.IsPK = False
        Me.bscCodigoMarca.IsRequired = False
        Me.bscCodigoMarca.Key = ""
        Me.bscCodigoMarca.LabelAsoc = Nothing
        Me.bscCodigoMarca.Location = New System.Drawing.Point(50, 40)
        Me.bscCodigoMarca.MaxLengh = "32767"
        Me.bscCodigoMarca.Name = "bscCodigoMarca"
        Me.bscCodigoMarca.Permitido = True
        Me.bscCodigoMarca.Selecciono = False
        Me.bscCodigoMarca.Size = New System.Drawing.Size(80, 20)
        Me.bscCodigoMarca.TabIndex = 5
        Me.bscCodigoMarca.Titulo = Nothing
        '
        'bscMarca
        '
        Me.bscMarca.AyudaAncho = 608
        Me.bscMarca.BindearPropiedadControl = Nothing
        Me.bscMarca.BindearPropiedadEntidad = Nothing
        Me.bscMarca.ColumnasAlineacion = Nothing
        Me.bscMarca.ColumnasAncho = Nothing
        Me.bscMarca.ColumnasFormato = Nothing
        Me.bscMarca.ColumnasOcultas = Nothing
        Me.bscMarca.ColumnasTitulos = Nothing
        Me.bscMarca.Datos = Nothing
        Me.bscMarca.FilaDevuelta = Nothing
        Me.bscMarca.ForeColorFocus = System.Drawing.Color.Red
        Me.bscMarca.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.bscMarca.IsDecimal = False
        Me.bscMarca.IsNumber = False
        Me.bscMarca.IsPK = False
        Me.bscMarca.IsRequired = False
        Me.bscMarca.Key = ""
        Me.bscMarca.LabelAsoc = Nothing
        Me.bscMarca.Location = New System.Drawing.Point(135, 40)
        Me.bscMarca.MaxLengh = "32767"
        Me.bscMarca.Name = "bscMarca"
        Me.bscMarca.Permitido = True
        Me.bscMarca.Selecciono = False
        Me.bscMarca.Size = New System.Drawing.Size(125, 20)
        Me.bscMarca.TabIndex = 6
        Me.bscMarca.Titulo = Nothing
        '
        'cmbTipoImpuesto
        '
        Me.cmbTipoImpuesto.BindearPropiedadControl = "Text"
        Me.cmbTipoImpuesto.BindearPropiedadEntidad = "Alicuota"
        Me.cmbTipoImpuesto.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbTipoImpuesto.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbTipoImpuesto.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbTipoImpuesto.FormattingEnabled = True
        Me.cmbTipoImpuesto.IsPK = False
        Me.cmbTipoImpuesto.IsRequired = False
        Me.cmbTipoImpuesto.Key = Nothing
        Me.cmbTipoImpuesto.LabelAsoc = Nothing
        Me.cmbTipoImpuesto.Location = New System.Drawing.Point(201, 11)
        Me.cmbTipoImpuesto.Name = "cmbTipoImpuesto"
        Me.cmbTipoImpuesto.Size = New System.Drawing.Size(56, 21)
        Me.cmbTipoImpuesto.TabIndex = 3
        '
        'cmbMoneda
        '
        Me.cmbMoneda.BindearPropiedadControl = "SelectedValue"
        Me.cmbMoneda.BindearPropiedadEntidad = "Moneda.IdMoneda"
        Me.cmbMoneda.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbMoneda.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbMoneda.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbMoneda.FormattingEnabled = True
        Me.cmbMoneda.IsPK = False
        Me.cmbMoneda.IsRequired = False
        Me.cmbMoneda.Key = Nothing
        Me.cmbMoneda.LabelAsoc = Nothing
        Me.cmbMoneda.Location = New System.Drawing.Point(49, 12)
        Me.cmbMoneda.Name = "cmbMoneda"
        Me.cmbMoneda.Size = New System.Drawing.Size(81, 21)
        Me.cmbMoneda.TabIndex = 1
        '
        'ugDetalle
        '
        Me.ugDetalle.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Appearance1.BackColor = System.Drawing.SystemColors.Window
        Appearance1.BorderColor = System.Drawing.SystemColors.InactiveCaption
        Me.ugDetalle.DisplayLayout.Appearance = Appearance1
        UltraGridColumn4.Header.VisiblePosition = 0
        UltraGridColumn4.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.CheckBox
        UltraGridColumn4.Width = 57
        UltraGridColumn3.Header.VisiblePosition = 2
        UltraGridColumn3.Width = 51
        UltraGridColumn23.Header.Caption = "Tipo"
        UltraGridColumn23.Header.VisiblePosition = 4
        UltraGridColumn23.Width = 84
        Appearance2.TextHAlignAsString = "Right"
        UltraGridColumn24.CellAppearance = Appearance2
        UltraGridColumn24.Header.Caption = "Número"
        UltraGridColumn24.Header.VisiblePosition = 5
        UltraGridColumn24.Width = 56
        UltraGridColumn25.Header.VisiblePosition = 9
        UltraGridColumn25.Hidden = True
        Appearance3.TextHAlignAsString = "Center"
        UltraGridColumn9.CellAppearance = Appearance3
        UltraGridColumn9.Format = "dd/MM/yyyy"
        UltraGridColumn9.Header.Caption = "Fecha"
        UltraGridColumn9.Header.VisiblePosition = 6
        UltraGridColumn9.Width = 80
        Appearance4.TextHAlignAsString = "Right"
        UltraGridColumn26.CellAppearance = Appearance4
        UltraGridColumn26.Header.Caption = "Orden Compra"
        UltraGridColumn26.Header.VisiblePosition = 7
        UltraGridColumn26.Width = 66
        UltraGridColumn6.Header.VisiblePosition = 26
        UltraGridColumn6.Hidden = True
        Appearance5.TextHAlignAsString = "Right"
        UltraGridColumn10.CellAppearance = Appearance5
        UltraGridColumn10.Header.Caption = "Código Cliente"
        UltraGridColumn10.Header.VisiblePosition = 8
        UltraGridColumn10.Width = 62
        UltraGridColumn1.Header.Caption = "Cliente"
        UltraGridColumn1.Header.VisiblePosition = 10
        UltraGridColumn1.Width = 213
        UltraGridColumn12.Header.Caption = "Tp. Doc. Vendedor"
        UltraGridColumn12.Header.VisiblePosition = 11
        UltraGridColumn12.Width = 68
        UltraGridColumn13.Header.Caption = "Nro. Doc. Vendedor"
        UltraGridColumn13.Header.VisiblePosition = 12
        UltraGridColumn13.Width = 69
        UltraGridColumn14.Header.Caption = "Vendedor"
        UltraGridColumn14.Header.VisiblePosition = 13
        UltraGridColumn17.Header.VisiblePosition = 15
        UltraGridColumn17.Hidden = True
        Appearance6.TextHAlignAsString = "Right"
        UltraGridColumn15.CellAppearance = Appearance6
        UltraGridColumn15.Header.Caption = "Código F. Pago"
        UltraGridColumn15.Header.VisiblePosition = 14
        UltraGridColumn15.Width = 54
        UltraGridColumn16.Header.Caption = "Forma de Pago"
        UltraGridColumn16.Header.VisiblePosition = 16
        UltraGridColumn18.Header.VisiblePosition = 19
        UltraGridColumn18.Hidden = True
        UltraGridColumn7.Header.Caption = "Código Producto"
        UltraGridColumn7.Header.VisiblePosition = 17
        UltraGridColumn32.Header.Caption = "Codigo Producto"
        UltraGridColumn32.Header.VisiblePosition = 18
        UltraGridColumn32.Width = 101
        UltraGridColumn8.Header.Caption = "Producto"
        UltraGridColumn8.Header.VisiblePosition = 20
        UltraGridColumn8.Width = 239
        Appearance7.TextHAlignAsString = "Right"
        UltraGridColumn11.CellAppearance = Appearance7
        UltraGridColumn11.Format = "N2"
        UltraGridColumn11.Header.Caption = "Cant.Pedida"
        UltraGridColumn11.Header.VisiblePosition = 21
        UltraGridColumn11.Width = 87
        Appearance8.TextHAlignAsString = "Right"
        UltraGridColumn27.CellAppearance = Appearance8
        UltraGridColumn27.Format = "N2"
        UltraGridColumn27.Header.Caption = "Precio Costo"
        UltraGridColumn27.Header.VisiblePosition = 22
        Appearance9.TextHAlignAsString = "Right"
        UltraGridColumn2.CellAppearance = Appearance9
        UltraGridColumn2.Format = "N2"
        UltraGridColumn2.Header.Caption = "Precio Venta"
        UltraGridColumn2.Header.VisiblePosition = 23
        Appearance10.TextHAlignAsString = "Right"
        UltraGridColumn5.CellAppearance = Appearance10
        UltraGridColumn5.Format = "N2"
        UltraGridColumn5.Header.Caption = "Total Producto"
        UltraGridColumn5.Header.VisiblePosition = 27
        UltraGridColumn19.Header.Caption = "Lista de Precios"
        UltraGridColumn19.Header.VisiblePosition = 28
        UltraGridColumn19.Width = 121
        UltraGridColumn20.Header.VisiblePosition = 29
        UltraGridColumn20.Hidden = True
        UltraGridColumn21.Header.VisiblePosition = 34
        UltraGridColumn21.Width = 312
        UltraGridColumn22.Header.VisiblePosition = 3
        UltraGridColumn22.Width = 100
        UltraGridColumn29.Header.Caption = "Importa Producto"
        UltraGridColumn29.Header.VisiblePosition = 1
        UltraGridColumn29.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.CheckBox
        UltraGridColumn29.Width = 57
        UltraGridColumn28.Header.Caption = "Marca"
        UltraGridColumn28.Header.VisiblePosition = 30
        UltraGridColumn30.Header.Caption = "Rubro"
        UltraGridColumn30.Header.VisiblePosition = 31
        UltraGridColumn31.Header.VisiblePosition = 32
        UltraGridColumn33.Header.VisiblePosition = 33
        Appearance11.TextHAlignAsString = "Right"
        UltraGridColumn35.CellAppearance = Appearance11
        UltraGridColumn35.Header.Caption = "% D/R"
        UltraGridColumn35.Header.VisiblePosition = 24
        Appearance12.TextHAlignAsString = "Right"
        UltraGridColumn36.CellAppearance = Appearance12
        UltraGridColumn36.Header.Caption = "% D/R2"
        UltraGridColumn36.Header.VisiblePosition = 25
        UltraGridBand1.Columns.AddRange(New Object() {UltraGridColumn4, UltraGridColumn3, UltraGridColumn23, UltraGridColumn24, UltraGridColumn25, UltraGridColumn9, UltraGridColumn26, UltraGridColumn6, UltraGridColumn10, UltraGridColumn1, UltraGridColumn12, UltraGridColumn13, UltraGridColumn14, UltraGridColumn17, UltraGridColumn15, UltraGridColumn16, UltraGridColumn18, UltraGridColumn7, UltraGridColumn32, UltraGridColumn8, UltraGridColumn11, UltraGridColumn27, UltraGridColumn2, UltraGridColumn5, UltraGridColumn19, UltraGridColumn20, UltraGridColumn21, UltraGridColumn22, UltraGridColumn29, UltraGridColumn28, UltraGridColumn30, UltraGridColumn31, UltraGridColumn33, UltraGridColumn35, UltraGridColumn36})
        Me.ugDetalle.DisplayLayout.BandsSerializer.Add(UltraGridBand1)
        Me.ugDetalle.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.ugDetalle.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.[False]
        Appearance13.BackColor = System.Drawing.SystemColors.ActiveBorder
        Appearance13.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance13.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Appearance13.BorderColor = System.Drawing.SystemColors.Window
        Me.ugDetalle.DisplayLayout.GroupByBox.Appearance = Appearance13
        Appearance14.ForeColor = System.Drawing.SystemColors.GrayText
        Me.ugDetalle.DisplayLayout.GroupByBox.BandLabelAppearance = Appearance14
        Me.ugDetalle.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.ugDetalle.DisplayLayout.GroupByBox.Prompt = "Arrastre un título de columna aquí para agrupar."
        Appearance15.BackColor = System.Drawing.SystemColors.ControlLightLight
        Appearance15.BackColor2 = System.Drawing.SystemColors.Control
        Appearance15.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance15.ForeColor = System.Drawing.SystemColors.GrayText
        Me.ugDetalle.DisplayLayout.GroupByBox.PromptAppearance = Appearance15
        Me.ugDetalle.DisplayLayout.MaxColScrollRegions = 1
        Me.ugDetalle.DisplayLayout.MaxRowScrollRegions = 1
        Appearance16.BackColor = System.Drawing.SystemColors.Window
        Appearance16.ForeColor = System.Drawing.SystemColors.ControlText
        Me.ugDetalle.DisplayLayout.Override.ActiveCellAppearance = Appearance16
        Appearance17.BackColor = System.Drawing.SystemColors.Highlight
        Appearance17.ForeColor = System.Drawing.SystemColors.HighlightText
        Me.ugDetalle.DisplayLayout.Override.ActiveRowAppearance = Appearance17
        Me.ugDetalle.DisplayLayout.Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.No
        Me.ugDetalle.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.[False]
        Me.ugDetalle.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.[False]
        Me.ugDetalle.DisplayLayout.Override.AllowUpdate = Infragistics.Win.DefaultableBoolean.[False]
        Me.ugDetalle.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted
        Me.ugDetalle.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted
        Appearance18.BackColor = System.Drawing.SystemColors.Window
        Me.ugDetalle.DisplayLayout.Override.CardAreaAppearance = Appearance18
        Appearance19.BorderColor = System.Drawing.Color.Silver
        Appearance19.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter
        Me.ugDetalle.DisplayLayout.Override.CellAppearance = Appearance19
        Me.ugDetalle.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText
        Me.ugDetalle.DisplayLayout.Override.CellPadding = 0
        Appearance20.BackColor = System.Drawing.SystemColors.Control
        Appearance20.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance20.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element
        Appearance20.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance20.BorderColor = System.Drawing.SystemColors.Window
        Me.ugDetalle.DisplayLayout.Override.GroupByRowAppearance = Appearance20
        Appearance21.TextHAlignAsString = "Left"
        Me.ugDetalle.DisplayLayout.Override.HeaderAppearance = Appearance21
        Me.ugDetalle.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
        Me.ugDetalle.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand
        Appearance22.BackColor = System.Drawing.SystemColors.Window
        Appearance22.BorderColor = System.Drawing.Color.Silver
        Me.ugDetalle.DisplayLayout.Override.RowAppearance = Appearance22
        Me.ugDetalle.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[False]
        Me.ugDetalle.DisplayLayout.Override.SummaryDisplayArea = CType((Infragistics.Win.UltraWinGrid.SummaryDisplayAreas.BottomFixed Or Infragistics.Win.UltraWinGrid.SummaryDisplayAreas.InGroupByRows), Infragistics.Win.UltraWinGrid.SummaryDisplayAreas)
        Appearance23.BackColor = System.Drawing.SystemColors.ControlLight
        Me.ugDetalle.DisplayLayout.Override.TemplateAddRowAppearance = Appearance23
        Me.ugDetalle.DisplayLayout.Override.WrapHeaderText = Infragistics.Win.DefaultableBoolean.[True]
        Me.ugDetalle.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill
        Me.ugDetalle.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate
        Me.ugDetalle.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy
        Me.ugDetalle.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ugDetalle.Location = New System.Drawing.Point(6, 214)
        Me.ugDetalle.Name = "ugDetalle"
        Me.ugDetalle.Size = New System.Drawing.Size(974, 293)
        Me.ugDetalle.TabIndex = 1
        '
        'prbImportando
        '
        Me.prbImportando.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.prbImportando.Location = New System.Drawing.Point(12, 513)
        Me.prbImportando.Name = "prbImportando"
        Me.prbImportando.Size = New System.Drawing.Size(960, 23)
        Me.prbImportando.Style = System.Windows.Forms.ProgressBarStyle.Continuous
        Me.prbImportando.TabIndex = 2
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tssInfo, Me.tsbFormatoExcel, Me.tslTiempoActual, Me.tslRegistroActual, Me.tssRegistros})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 539)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(984, 22)
        Me.StatusStrip1.TabIndex = 3
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'tssInfo
        '
        Me.tssInfo.Name = "tssInfo"
        Me.tssInfo.Size = New System.Drawing.Size(721, 17)
        Me.tssInfo.Spring = True
        Me.tssInfo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'tsbFormatoExcel
        '
        Me.tsbFormatoExcel.BackColor = System.Drawing.Color.Gray
        Me.tsbFormatoExcel.ForeColor = System.Drawing.Color.Black
        Me.tsbFormatoExcel.LinkColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.tsbFormatoExcel.Name = "tsbFormatoExcel"
        Me.tsbFormatoExcel.Size = New System.Drawing.Size(100, 17)
        Me.tsbFormatoExcel.Text = "Formato Estandar"
        Me.tsbFormatoExcel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'tslTiempoActual
        '
        Me.tslTiempoActual.Name = "tslTiempoActual"
        Me.tslTiempoActual.Size = New System.Drawing.Size(45, 17)
        Me.tslTiempoActual.Text = "tiempo"
        '
        'tslRegistroActual
        '
        Me.tslRegistroActual.Name = "tslRegistroActual"
        Me.tslRegistroActual.Size = New System.Drawing.Size(39, 17)
        Me.tslRegistroActual.Text = "actual"
        '
        'tssRegistros
        '
        Me.tssRegistros.Name = "tssRegistros"
        Me.tssRegistros.Size = New System.Drawing.Size(64, 17)
        Me.tssRegistros.Text = "0 Registros"
        Me.tssRegistros.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'tstBarra
        '
        Me.tstBarra.AllowItemReorder = True
        Me.tstBarra.ImageScalingSize = New System.Drawing.Size(22, 22)
        Me.tstBarra.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsbRefrescar, Me.ToolStripSeparator1, Me.tsbImportar, Me.ToolStripSeparator2, Me.tsbSalir})
        Me.tstBarra.Location = New System.Drawing.Point(0, 0)
        Me.tstBarra.Name = "tstBarra"
        Me.tstBarra.Size = New System.Drawing.Size(984, 29)
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
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 29)
        '
        'tsbImportar
        '
        Me.tsbImportar.Enabled = False
        Me.tsbImportar.Image = CType(resources.GetObject("tsbImportar.Image"), System.Drawing.Image)
        Me.tsbImportar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbImportar.Name = "tsbImportar"
        Me.tsbImportar.Size = New System.Drawing.Size(79, 26)
        Me.tsbImportar.Text = "&Importar"
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
        'ImportarPedidosExcel
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(984, 561)
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.ugDetalle)
        Me.Controls.Add(Me.prbImportando)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.tstBarra)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.Name = "ImportarPedidosExcel"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Importar Pedidos desde Excel"
        Me.TabControl1.ResumeLayout(False)
        Me.tbpFiltros.ResumeLayout(False)
        Me.grbPendientes.ResumeLayout(False)
        Me.grbPendientes.PerformLayout()
        Me.grpAltaProductos.ResumeLayout(False)
        Me.grpAltaProductos.PerformLayout()
        CType(Me.ugDetalle, System.ComponentModel.ISupportInitialize).EndInit()
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.tstBarra.ResumeLayout(False)
        Me.tstBarra.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents grbPendientes As System.Windows.Forms.GroupBox
   Friend WithEvents btnMostrar As Eniac.Controles.Button
   Public WithEvents tstBarra As System.Windows.Forms.ToolStrip
    Public WithEvents tsbSalir As System.Windows.Forms.ToolStripButton
    Public WithEvents tsbRefrescar As System.Windows.Forms.ToolStripButton
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents btnExaminar As Eniac.Controles.Button
    Friend WithEvents lblArchivo As Eniac.Controles.Label
   Friend WithEvents txtArchivoOrigen As Eniac.Controles.TextBox
   Private WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
   Friend WithEvents prbImportando As System.Windows.Forms.ProgressBar
   Friend WithEvents cboEstado As Eniac.Controles.ComboBox
   Friend WithEvents lblEstado As Eniac.Controles.Label
   Friend WithEvents cboAccion As Eniac.Controles.ComboBox
   Friend WithEvents lblAccion As Eniac.Controles.Label
   Friend WithEvents lblOrdenCompra As Eniac.Controles.Label
   Friend WithEvents txtOrdenCompra As Eniac.Controles.TextBox
   Friend WithEvents bscCodigoProveedor As Eniac.Controles.Buscador
   Friend WithEvents bscProveedor As Eniac.Controles.Buscador
   Friend WithEvents lblCodigoProveedor As Eniac.Controles.Label
   Friend WithEvents lblNombre As Eniac.Controles.Label
   Friend WithEvents lblProveedor As Eniac.Controles.Label
   Friend WithEvents cmbFormaPago As Eniac.Controles.ComboBox
   Friend WithEvents lblFormaPago As Eniac.Controles.Label
   Friend WithEvents ugDetalle As Infragistics.Win.UltraWinGrid.UltraGrid
   Friend WithEvents tssRegistros As System.Windows.Forms.ToolStripStatusLabel
   Friend WithEvents tslTiempoActual As System.Windows.Forms.ToolStripStatusLabel
   Friend WithEvents tslRegistroActual As System.Windows.Forms.ToolStripStatusLabel
   Friend WithEvents chbRespetaPrecios As System.Windows.Forms.CheckBox
   Friend WithEvents tsbFormatoExcel As System.Windows.Forms.ToolStripStatusLabel
   Friend WithEvents dtpFechaEntrega As Eniac.Controles.DateTimePicker
   Friend WithEvents chbFechaEntrega As Eniac.Controles.CheckBox
   Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
   Friend WithEvents cmbFormatoArchivo As Eniac.Controles.ComboBox
   Friend WithEvents lblFormatoArchivo As Eniac.Controles.Label
   Friend WithEvents txtRangoCeldasColumnaHasta As Eniac.Controles.TextBox
   Friend WithEvents lblRangoCeldas As Eniac.Controles.Label
   Friend WithEvents txtRangoCeldasFilaDesde As Eniac.Controles.TextBox
   Friend WithEvents txtRangoCeldasFilaHasta As Eniac.Controles.TextBox
   Friend WithEvents lblSeparadosCeldas As Eniac.Controles.Label
   Friend WithEvents lblEjemplos As Eniac.Controles.Label
   Friend WithEvents txtRangoCeldasColumnaDesde As Eniac.Controles.TextBox
   Friend WithEvents tssInfo As System.Windows.Forms.ToolStripStatusLabel
   Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
   Friend WithEvents tbpFiltros As System.Windows.Forms.TabPage
   Friend WithEvents chbAltaProductos As System.Windows.Forms.CheckBox
   Friend WithEvents grpAltaProductos As System.Windows.Forms.GroupBox
   Friend WithEvents Label4 As Eniac.Controles.Label
   Friend WithEvents Label3 As Eniac.Controles.Label
   Friend WithEvents Label2 As Eniac.Controles.Label
   Friend WithEvents Label1 As Eniac.Controles.Label
   Friend WithEvents bscCodigoRubro As Eniac.Controles.Buscador
   Friend WithEvents bscRubro As Eniac.Controles.Buscador
   Friend WithEvents bscCodigoMarca As Eniac.Controles.Buscador
   Friend WithEvents bscMarca As Eniac.Controles.Buscador
   Friend WithEvents cmbTipoImpuesto As Eniac.Controles.ComboBox
   Friend WithEvents cmbMoneda As Eniac.Controles.ComboBox
    Friend WithEvents tsbImportar As ToolStripButton
    Friend WithEvents ToolStripSeparator2 As ToolStripSeparator
    Friend WithEvents chbAnticipado As Controles.CheckBox
    Friend WithEvents chbDescuentoRecargo As Controles.CheckBox
End Class
