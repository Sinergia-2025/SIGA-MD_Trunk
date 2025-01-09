<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class AcuerdosDePagosDetalle
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
      Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
      Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
      Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
      Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
      Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(AcuerdosDePagosDetalle))
      Dim Appearance1 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridBand1 As Infragistics.Win.UltraWinGrid.UltraGridBand = New Infragistics.Win.UltraWinGrid.UltraGridBand("Band 0", -1)
      Dim UltraGridColumn38 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdCliente")
      Dim UltraGridColumn39 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("CodigoCliente")
      Dim Appearance2 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn40 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("nro_prestamo")
      Dim Appearance3 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn41 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("fecha_corte")
      Dim UltraGridColumn42 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("tipo_cobro")
      Dim UltraGridColumn43 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("convenio")
      Dim UltraGridColumn45 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("linea")
      Dim UltraGridColumn46 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("fecha_emision")
      Dim UltraGridColumn47 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("cantidad_cuotas")
      Dim UltraGridColumn59 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("cuotas_pagas")
      Dim UltraGridColumn49 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("cuotas_adeudadas")
      Dim UltraGridColumn51 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("capital_total")
      Dim Appearance4 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn52 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("deuda_exigible")
      Dim Appearance5 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn53 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("fecha_ult_cobranza")
      Dim UltraGridColumn54 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("dias_mora")
      Dim Appearance6 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn55 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("deuda_exigible_con_quita", -1, Nothing, 0, Infragistics.Win.UltraWinGrid.SortIndicator.Ascending, False)
      Dim Appearance7 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn56 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("empresa")
      Dim UltraGridColumn44 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Cliente")
      Dim UltraGridColumn50 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Usuario")
      Dim UltraGridColumn57 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Password")
      Dim UltraGridColumn58 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdSucursal")
      Dim UltraGridColumn8 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("ImporteAcordado")
      Dim Appearance8 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn10 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreCliente")
      Dim UltraGridColumn11 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Cuit")
      Dim UltraGridColumn12 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Direccion")
      Dim UltraGridColumn13 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdLocalidad")
      Dim UltraGridColumn14 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreLocalidad")
      Dim UltraGridColumn15 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreProvincia")
      Dim UltraGridColumn16 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("CorreoElectronico")
      Dim UltraGridColumn1 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("monto_cuota")
      Dim Appearance9 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn9 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("CheckBox", 0)
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
      Dim Appearance20 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
      Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
      Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
      Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
      Me.tspMenu = New System.Windows.Forms.ToolStrip()
      Me.tsbGrabar = New System.Windows.Forms.ToolStripButton()
      Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
      Me.tbsSalir = New System.Windows.Forms.ToolStripButton()
      Me.dgvCuotas = New Eniac.Controles.DataGridView()
      Me.MontoAPagar = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.Cuota = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.Dias = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.FechaAPagar = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.grbVariasCuotas = New System.Windows.Forms.GroupBox()
      Me.txtPrimeraCuota = New Eniac.Controles.TextBox()
      Me.lblCuotas = New Eniac.Controles.Label()
      Me.chbPrimerCuota = New System.Windows.Forms.CheckBox()
      Me.chbDiaFijo = New System.Windows.Forms.CheckBox()
      Me.txtCuotas = New Eniac.Controles.TextBox()
      Me.cmbFormaPago = New Eniac.Controles.ComboBox()
      Me.lblFormaPago = New Eniac.Controles.Label()
      Me.btnEliminarVC = New Eniac.Controles.Button()
      Me.btnInsertarVC = New Eniac.Controles.Button()
      Me.dtpPrimerVencimiento = New Eniac.Controles.DateTimePicker()
      Me.lblPrimerVencimiento = New Eniac.Controles.Label()
      Me.btnLimpiarProducto = New Eniac.Controles.Button()
      Me.lblRestan = New Eniac.Controles.Label()
      Me.txtRestan = New Eniac.Controles.TextBox()
      Me.lblSaldo = New Eniac.Controles.Label()
      Me.txtSaldo = New Eniac.Controles.TextBox()
      Me.lblCantPeriodos = New System.Windows.Forms.Label()
      Me.txtCantPeriodos = New System.Windows.Forms.TextBox()
      Me.grbTenedorVehiculo = New System.Windows.Forms.GroupBox()
      Me.cmbLocalidad2 = New Eniac.Controles.ComboBox()
      Me.lblLocalidad2 = New Eniac.Controles.Label()
      Me.txtDomicilio2 = New Eniac.Controles.TextBox()
      Me.lblDomicilio2 = New Eniac.Controles.Label()
      Me.txtTelefono2 = New Eniac.Controles.TextBox()
      Me.lblTelefono2 = New Eniac.Controles.Label()
      Me.txtNombre = New Eniac.Controles.TextBox()
      Me.lblNombre = New Eniac.Controles.Label()
      Me.grbPlanDePago = New System.Windows.Forms.GroupBox()
      Me.ugDetalle = New Infragistics.Win.UltraWinGrid.UltraGrid()
      Me.lblRegistrosSeleccionados = New System.Windows.Forms.Label()
      Me.txtRegistrosSeleccionados = New System.Windows.Forms.TextBox()
      Me.Label5 = New System.Windows.Forms.Label()
      Me.Label4 = New System.Windows.Forms.Label()
      Me.Label3 = New System.Windows.Forms.Label()
      Me.txtPromedio = New System.Windows.Forms.TextBox()
      Me.txtSeleccionado = New System.Windows.Forms.TextBox()
      Me.txtPendiente = New System.Windows.Forms.TextBox()
      Me.chbTodos = New Eniac.Controles.CheckBox()
      Me.dgvPeriodosAdeudados = New Eniac.Controles.DataGridView()
      Me.ppPeriodo = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.ppImporteAproximado = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.ppFechaPago = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.ppFechaCarta1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.ppFechaCarta2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.ppFechaCarta3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.ppFechaUltimaModificacion = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.ppFechaLiquidacion = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.ppFechaActualizadoAl = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.ppFechaCobro = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.ppImporteCobrado = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.ppDarDeBaja = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.ppIdPago = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.ppDato = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.ppLocalidad = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.ppLocalidad2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.ppUsuario = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.ppIdSucursal = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.ppPassword = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.ppDocumento = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.ppFechaVencimiento = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.txtObservacion = New Eniac.Controles.TextBox()
      Me.Label1 = New Eniac.Controles.Label()
      Me.txtReferencia = New Eniac.Controles.TextBox()
      Me.Label2 = New Eniac.Controles.Label()
      Me.tspMenu.SuspendLayout()
      CType(Me.dgvCuotas, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.grbVariasCuotas.SuspendLayout()
      Me.grbTenedorVehiculo.SuspendLayout()
      Me.grbPlanDePago.SuspendLayout()
      CType(Me.ugDetalle, System.ComponentModel.ISupportInitialize).BeginInit()
      CType(Me.dgvPeriodosAdeudados, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.SuspendLayout()
      '
      'tspMenu
      '
      Me.tspMenu.ImageScalingSize = New System.Drawing.Size(24, 24)
      Me.tspMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsbGrabar, Me.ToolStripSeparator2, Me.tbsSalir})
      Me.tspMenu.Location = New System.Drawing.Point(0, 0)
      Me.tspMenu.Name = "tspMenu"
      Me.tspMenu.Size = New System.Drawing.Size(771, 31)
      Me.tspMenu.TabIndex = 40
      Me.tspMenu.Text = "ToolStrip1"
      '
      'tsbGrabar
      '
      Me.tsbGrabar.Enabled = False
      Me.tsbGrabar.Image = Global.Eniac.Win.My.Resources.Resources.diskette_32
      Me.tsbGrabar.ImageTransparentColor = System.Drawing.Color.Magenta
      Me.tsbGrabar.Name = "tsbGrabar"
      Me.tsbGrabar.Size = New System.Drawing.Size(73, 28)
      Me.tsbGrabar.Text = "Grabar "
      '
      'ToolStripSeparator2
      '
      Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
      Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 31)
      '
      'tbsSalir
      '
      Me.tbsSalir.Image = Global.Eniac.Win.My.Resources.Resources.close_b_24
      Me.tbsSalir.ImageTransparentColor = System.Drawing.Color.Magenta
      Me.tbsSalir.Name = "tbsSalir"
      Me.tbsSalir.Size = New System.Drawing.Size(67, 28)
      Me.tbsSalir.Text = "Cerrar"
      '
      'dgvCuotas
      '
      Me.dgvCuotas.AllowUserToAddRows = False
      Me.dgvCuotas.AllowUserToDeleteRows = False
      Me.dgvCuotas.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.dgvCuotas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
      Me.dgvCuotas.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.MontoAPagar, Me.Cuota, Me.Dias, Me.FechaAPagar})
      Me.dgvCuotas.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
      Me.dgvCuotas.Location = New System.Drawing.Point(416, 332)
      Me.dgvCuotas.Name = "dgvCuotas"
      Me.dgvCuotas.RowHeadersVisible = False
      Me.dgvCuotas.RowHeadersWidth = 20
      Me.dgvCuotas.Size = New System.Drawing.Size(347, 165)
      Me.dgvCuotas.TabIndex = 38
      '
      'MontoAPagar
      '
      Me.MontoAPagar.DataPropertyName = "MontoAPagar"
      DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
      DataGridViewCellStyle1.Format = "N2"
      DataGridViewCellStyle1.NullValue = Nothing
      Me.MontoAPagar.DefaultCellStyle = DataGridViewCellStyle1
      Me.MontoAPagar.HeaderText = "Monto"
      Me.MontoAPagar.Name = "MontoAPagar"
      Me.MontoAPagar.Width = 90
      '
      'Cuota
      '
      Me.Cuota.DataPropertyName = "Cuota"
      DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
      Me.Cuota.DefaultCellStyle = DataGridViewCellStyle2
      Me.Cuota.HeaderText = "Cuota"
      Me.Cuota.Name = "Cuota"
      Me.Cuota.Width = 50
      '
      'Dias
      '
      Me.Dias.DataPropertyName = "Dias"
      DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
      Me.Dias.DefaultCellStyle = DataGridViewCellStyle3
      Me.Dias.HeaderText = "Días"
      Me.Dias.Name = "Dias"
      Me.Dias.Width = 50
      '
      'FechaAPagar
      '
      Me.FechaAPagar.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
      Me.FechaAPagar.DataPropertyName = "FechaAPagar"
      DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
      DataGridViewCellStyle4.Format = "dd/MM/yyyy"
      DataGridViewCellStyle4.NullValue = Nothing
      Me.FechaAPagar.DefaultCellStyle = DataGridViewCellStyle4
      Me.FechaAPagar.HeaderText = "Vencimiento"
      Me.FechaAPagar.Name = "FechaAPagar"
      '
      'grbVariasCuotas
      '
      Me.grbVariasCuotas.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.grbVariasCuotas.Controls.Add(Me.txtPrimeraCuota)
      Me.grbVariasCuotas.Controls.Add(Me.chbPrimerCuota)
      Me.grbVariasCuotas.Controls.Add(Me.chbDiaFijo)
      Me.grbVariasCuotas.Controls.Add(Me.txtCuotas)
      Me.grbVariasCuotas.Controls.Add(Me.lblCuotas)
      Me.grbVariasCuotas.Controls.Add(Me.cmbFormaPago)
      Me.grbVariasCuotas.Controls.Add(Me.lblFormaPago)
      Me.grbVariasCuotas.Controls.Add(Me.btnEliminarVC)
      Me.grbVariasCuotas.Controls.Add(Me.btnInsertarVC)
      Me.grbVariasCuotas.Controls.Add(Me.dtpPrimerVencimiento)
      Me.grbVariasCuotas.Controls.Add(Me.lblPrimerVencimiento)
      Me.grbVariasCuotas.Location = New System.Drawing.Point(5, 363)
      Me.grbVariasCuotas.Name = "grbVariasCuotas"
      Me.grbVariasCuotas.Size = New System.Drawing.Size(445, 99)
      Me.grbVariasCuotas.TabIndex = 37
      Me.grbVariasCuotas.TabStop = False
      Me.grbVariasCuotas.Text = "Forma de Pago"
      '
      'txtPrimeraCuota
      '
      Me.txtPrimeraCuota.BindearPropiedadControl = Nothing
      Me.txtPrimeraCuota.BindearPropiedadEntidad = Nothing
      Me.txtPrimeraCuota.Enabled = False
      Me.txtPrimeraCuota.ForeColorFocus = System.Drawing.Color.Red
      Me.txtPrimeraCuota.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtPrimeraCuota.Formato = ""
      Me.txtPrimeraCuota.IsDecimal = True
      Me.txtPrimeraCuota.IsNumber = True
      Me.txtPrimeraCuota.IsPK = False
      Me.txtPrimeraCuota.IsRequired = False
      Me.txtPrimeraCuota.Key = ""
      Me.txtPrimeraCuota.LabelAsoc = Me.lblCuotas
      Me.txtPrimeraCuota.Location = New System.Drawing.Point(306, 65)
      Me.txtPrimeraCuota.MaxLength = 15
      Me.txtPrimeraCuota.Name = "txtPrimeraCuota"
      Me.txtPrimeraCuota.Size = New System.Drawing.Size(78, 20)
      Me.txtPrimeraCuota.TabIndex = 11
      Me.txtPrimeraCuota.Text = "0.00"
      Me.txtPrimeraCuota.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'lblCuotas
      '
      Me.lblCuotas.AutoSize = True
      Me.lblCuotas.LabelAsoc = Nothing
      Me.lblCuotas.Location = New System.Drawing.Point(256, 20)
      Me.lblCuotas.Name = "lblCuotas"
      Me.lblCuotas.Size = New System.Drawing.Size(40, 13)
      Me.lblCuotas.TabIndex = 5
      Me.lblCuotas.Text = "Cuotas"
      '
      'chbPrimerCuota
      '
      Me.chbPrimerCuota.AutoSize = True
      Me.chbPrimerCuota.Location = New System.Drawing.Point(228, 67)
      Me.chbPrimerCuota.Name = "chbPrimerCuota"
      Me.chbPrimerCuota.Size = New System.Drawing.Size(75, 17)
      Me.chbPrimerCuota.TabIndex = 10
      Me.chbPrimerCuota.Text = "1er. Cuota"
      Me.chbPrimerCuota.UseVisualStyleBackColor = True
      '
      'chbDiaFijo
      '
      Me.chbDiaFijo.AutoSize = True
      Me.chbDiaFijo.Location = New System.Drawing.Point(150, 67)
      Me.chbDiaFijo.Name = "chbDiaFijo"
      Me.chbDiaFijo.Size = New System.Drawing.Size(63, 17)
      Me.chbDiaFijo.TabIndex = 8
      Me.chbDiaFijo.Text = "Día Fijo"
      Me.chbDiaFijo.UseVisualStyleBackColor = True
      '
      'txtCuotas
      '
      Me.txtCuotas.BindearPropiedadControl = Nothing
      Me.txtCuotas.BindearPropiedadEntidad = Nothing
      Me.txtCuotas.ForeColorFocus = System.Drawing.Color.Red
      Me.txtCuotas.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtCuotas.Formato = ""
      Me.txtCuotas.IsDecimal = False
      Me.txtCuotas.IsNumber = True
      Me.txtCuotas.IsPK = False
      Me.txtCuotas.IsRequired = False
      Me.txtCuotas.Key = ""
      Me.txtCuotas.LabelAsoc = Me.lblCuotas
      Me.txtCuotas.Location = New System.Drawing.Point(254, 36)
      Me.txtCuotas.MaxLength = 4
      Me.txtCuotas.Name = "txtCuotas"
      Me.txtCuotas.Size = New System.Drawing.Size(46, 20)
      Me.txtCuotas.TabIndex = 4
      Me.txtCuotas.Text = "1"
      Me.txtCuotas.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
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
      Me.cmbFormaPago.Location = New System.Drawing.Point(12, 36)
      Me.cmbFormaPago.Name = "cmbFormaPago"
      Me.cmbFormaPago.Size = New System.Drawing.Size(130, 21)
      Me.cmbFormaPago.TabIndex = 0
      '
      'lblFormaPago
      '
      Me.lblFormaPago.AutoSize = True
      Me.lblFormaPago.LabelAsoc = Nothing
      Me.lblFormaPago.Location = New System.Drawing.Point(9, 22)
      Me.lblFormaPago.Name = "lblFormaPago"
      Me.lblFormaPago.Size = New System.Drawing.Size(79, 13)
      Me.lblFormaPago.TabIndex = 1
      Me.lblFormaPago.Text = "Forma de &Pago"
      '
      'btnEliminarVC
      '
      Me.btnEliminarVC.Image = CType(resources.GetObject("btnEliminarVC.Image"), System.Drawing.Image)
      Me.btnEliminarVC.Location = New System.Drawing.Point(353, 22)
      Me.btnEliminarVC.Name = "btnEliminarVC"
      Me.btnEliminarVC.Size = New System.Drawing.Size(37, 37)
      Me.btnEliminarVC.TabIndex = 7
      Me.btnEliminarVC.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
      Me.btnEliminarVC.UseVisualStyleBackColor = True
      '
      'btnInsertarVC
      '
      Me.btnInsertarVC.Image = CType(resources.GetObject("btnInsertarVC.Image"), System.Drawing.Image)
      Me.btnInsertarVC.Location = New System.Drawing.Point(310, 22)
      Me.btnInsertarVC.Name = "btnInsertarVC"
      Me.btnInsertarVC.Size = New System.Drawing.Size(37, 37)
      Me.btnInsertarVC.TabIndex = 6
      Me.btnInsertarVC.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
      Me.btnInsertarVC.UseVisualStyleBackColor = True
      '
      'dtpPrimerVencimiento
      '
      Me.dtpPrimerVencimiento.BindearPropiedadControl = Nothing
      Me.dtpPrimerVencimiento.BindearPropiedadEntidad = Nothing
      Me.dtpPrimerVencimiento.CustomFormat = "dd/MM/yyyy"
      Me.dtpPrimerVencimiento.ForeColorFocus = System.Drawing.Color.Red
      Me.dtpPrimerVencimiento.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.dtpPrimerVencimiento.Format = System.Windows.Forms.DateTimePickerFormat.Custom
      Me.dtpPrimerVencimiento.IsPK = False
      Me.dtpPrimerVencimiento.IsRequired = False
      Me.dtpPrimerVencimiento.Key = ""
      Me.dtpPrimerVencimiento.LabelAsoc = Me.lblPrimerVencimiento
      Me.dtpPrimerVencimiento.Location = New System.Drawing.Point(150, 37)
      Me.dtpPrimerVencimiento.Name = "dtpPrimerVencimiento"
      Me.dtpPrimerVencimiento.Size = New System.Drawing.Size(96, 20)
      Me.dtpPrimerVencimiento.TabIndex = 2
      '
      'lblPrimerVencimiento
      '
      Me.lblPrimerVencimiento.AutoSize = True
      Me.lblPrimerVencimiento.LabelAsoc = Nothing
      Me.lblPrimerVencimiento.Location = New System.Drawing.Point(147, 22)
      Me.lblPrimerVencimiento.Name = "lblPrimerVencimiento"
      Me.lblPrimerVencimiento.Size = New System.Drawing.Size(97, 13)
      Me.lblPrimerVencimiento.TabIndex = 3
      Me.lblPrimerVencimiento.Text = "Primer Vencimiento"
      '
      'btnLimpiarProducto
      '
      Me.btnLimpiarProducto.Image = Global.Eniac.Win.My.Resources.Resources.refresh_32
      Me.btnLimpiarProducto.Location = New System.Drawing.Point(374, 332)
      Me.btnLimpiarProducto.Name = "btnLimpiarProducto"
      Me.btnLimpiarProducto.Size = New System.Drawing.Size(37, 37)
      Me.btnLimpiarProducto.TabIndex = 39
      Me.btnLimpiarProducto.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
      Me.btnLimpiarProducto.UseVisualStyleBackColor = True
      '
      'lblRestan
      '
      Me.lblRestan.AutoSize = True
      Me.lblRestan.LabelAsoc = Nothing
      Me.lblRestan.Location = New System.Drawing.Point(184, 335)
      Me.lblRestan.Name = "lblRestan"
      Me.lblRestan.Size = New System.Drawing.Size(41, 13)
      Me.lblRestan.TabIndex = 35
      Me.lblRestan.Text = "Restan"
      '
      'txtRestan
      '
      Me.txtRestan.BindearPropiedadControl = Nothing
      Me.txtRestan.BindearPropiedadEntidad = Nothing
      Me.txtRestan.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.txtRestan.ForeColorFocus = System.Drawing.Color.Red
      Me.txtRestan.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtRestan.Formato = ""
      Me.txtRestan.IsDecimal = True
      Me.txtRestan.IsNumber = True
      Me.txtRestan.IsPK = False
      Me.txtRestan.IsRequired = False
      Me.txtRestan.Key = ""
      Me.txtRestan.LabelAsoc = Me.lblRestan
      Me.txtRestan.Location = New System.Drawing.Point(231, 331)
      Me.txtRestan.Name = "txtRestan"
      Me.txtRestan.ReadOnly = True
      Me.txtRestan.Size = New System.Drawing.Size(100, 23)
      Me.txtRestan.TabIndex = 36
      Me.txtRestan.TabStop = False
      Me.txtRestan.Text = "0.00"
      Me.txtRestan.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'lblSaldo
      '
      Me.lblSaldo.AutoSize = True
      Me.lblSaldo.LabelAsoc = Nothing
      Me.lblSaldo.Location = New System.Drawing.Point(13, 335)
      Me.lblSaldo.Name = "lblSaldo"
      Me.lblSaldo.Size = New System.Drawing.Size(53, 13)
      Me.lblSaldo.TabIndex = 33
      Me.lblSaldo.Text = "Acordado"
      '
      'txtSaldo
      '
      Me.txtSaldo.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
      Me.txtSaldo.BindearPropiedadControl = Nothing
      Me.txtSaldo.BindearPropiedadEntidad = Nothing
      Me.txtSaldo.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.txtSaldo.ForeColorFocus = System.Drawing.Color.Red
      Me.txtSaldo.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtSaldo.Formato = ""
      Me.txtSaldo.IsDecimal = True
      Me.txtSaldo.IsNumber = True
      Me.txtSaldo.IsPK = False
      Me.txtSaldo.IsRequired = False
      Me.txtSaldo.Key = ""
      Me.txtSaldo.LabelAsoc = Me.lblSaldo
      Me.txtSaldo.Location = New System.Drawing.Point(68, 331)
      Me.txtSaldo.Name = "txtSaldo"
      Me.txtSaldo.ReadOnly = True
      Me.txtSaldo.Size = New System.Drawing.Size(100, 23)
      Me.txtSaldo.TabIndex = 34
      Me.txtSaldo.TabStop = False
      Me.txtSaldo.Text = "0.00"
      Me.txtSaldo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'lblCantPeriodos
      '
      Me.lblCantPeriodos.AutoSize = True
      Me.lblCantPeriodos.Location = New System.Drawing.Point(20, 563)
      Me.lblCantPeriodos.Name = "lblCantPeriodos"
      Me.lblCantPeriodos.Size = New System.Drawing.Size(48, 13)
      Me.lblCantPeriodos.TabIndex = 32
      Me.lblCantPeriodos.Text = "Periodos"
      Me.lblCantPeriodos.Visible = False
      '
      'txtCantPeriodos
      '
      Me.txtCantPeriodos.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
      Me.txtCantPeriodos.Location = New System.Drawing.Point(76, 560)
      Me.txtCantPeriodos.Name = "txtCantPeriodos"
      Me.txtCantPeriodos.ReadOnly = True
      Me.txtCantPeriodos.Size = New System.Drawing.Size(40, 20)
      Me.txtCantPeriodos.TabIndex = 31
      Me.txtCantPeriodos.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
      Me.txtCantPeriodos.Visible = False
      '
      'grbTenedorVehiculo
      '
      Me.grbTenedorVehiculo.Controls.Add(Me.cmbLocalidad2)
      Me.grbTenedorVehiculo.Controls.Add(Me.lblLocalidad2)
      Me.grbTenedorVehiculo.Controls.Add(Me.txtDomicilio2)
      Me.grbTenedorVehiculo.Controls.Add(Me.lblDomicilio2)
      Me.grbTenedorVehiculo.Controls.Add(Me.txtTelefono2)
      Me.grbTenedorVehiculo.Controls.Add(Me.lblTelefono2)
      Me.grbTenedorVehiculo.Controls.Add(Me.txtNombre)
      Me.grbTenedorVehiculo.Controls.Add(Me.lblNombre)
      Me.grbTenedorVehiculo.Enabled = False
      Me.grbTenedorVehiculo.Location = New System.Drawing.Point(5, 36)
      Me.grbTenedorVehiculo.Name = "grbTenedorVehiculo"
      Me.grbTenedorVehiculo.Size = New System.Drawing.Size(758, 66)
      Me.grbTenedorVehiculo.TabIndex = 20
      Me.grbTenedorVehiculo.TabStop = False
      Me.grbTenedorVehiculo.Text = "Cliente"
      '
      'cmbLocalidad2
      '
      Me.cmbLocalidad2.BindearPropiedadControl = "SelectedValue"
      Me.cmbLocalidad2.BindearPropiedadEntidad = "Localidad2.IdLocalidad"
      Me.cmbLocalidad2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cmbLocalidad2.ForeColorFocus = System.Drawing.Color.Red
      Me.cmbLocalidad2.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.cmbLocalidad2.FormattingEnabled = True
      Me.cmbLocalidad2.IsPK = False
      Me.cmbLocalidad2.IsRequired = True
      Me.cmbLocalidad2.Key = Nothing
      Me.cmbLocalidad2.LabelAsoc = Me.lblLocalidad2
      Me.cmbLocalidad2.Location = New System.Drawing.Point(453, 39)
      Me.cmbLocalidad2.Name = "cmbLocalidad2"
      Me.cmbLocalidad2.Size = New System.Drawing.Size(142, 21)
      Me.cmbLocalidad2.TabIndex = 3
      '
      'lblLocalidad2
      '
      Me.lblLocalidad2.AutoSize = True
      Me.lblLocalidad2.LabelAsoc = Nothing
      Me.lblLocalidad2.Location = New System.Drawing.Point(389, 42)
      Me.lblLocalidad2.Name = "lblLocalidad2"
      Me.lblLocalidad2.Size = New System.Drawing.Size(53, 13)
      Me.lblLocalidad2.TabIndex = 7
      Me.lblLocalidad2.Text = "Localidad"
      '
      'txtDomicilio2
      '
      Me.txtDomicilio2.BindearPropiedadControl = "Text"
      Me.txtDomicilio2.BindearPropiedadEntidad = "Domicilio2"
      Me.txtDomicilio2.ForeColorFocus = System.Drawing.Color.Red
      Me.txtDomicilio2.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtDomicilio2.Formato = ""
      Me.txtDomicilio2.IsDecimal = False
      Me.txtDomicilio2.IsNumber = False
      Me.txtDomicilio2.IsPK = False
      Me.txtDomicilio2.IsRequired = False
      Me.txtDomicilio2.Key = ""
      Me.txtDomicilio2.LabelAsoc = Me.lblDomicilio2
      Me.txtDomicilio2.Location = New System.Drawing.Point(57, 41)
      Me.txtDomicilio2.MaxLength = 50
      Me.txtDomicilio2.Name = "txtDomicilio2"
      Me.txtDomicilio2.Size = New System.Drawing.Size(320, 20)
      Me.txtDomicilio2.TabIndex = 2
      '
      'lblDomicilio2
      '
      Me.lblDomicilio2.AutoSize = True
      Me.lblDomicilio2.LabelAsoc = Nothing
      Me.lblDomicilio2.Location = New System.Drawing.Point(6, 45)
      Me.lblDomicilio2.Name = "lblDomicilio2"
      Me.lblDomicilio2.Size = New System.Drawing.Size(49, 13)
      Me.lblDomicilio2.TabIndex = 4
      Me.lblDomicilio2.Text = "Domicilio"
      '
      'txtTelefono2
      '
      Me.txtTelefono2.BindearPropiedadControl = "Text"
      Me.txtTelefono2.BindearPropiedadEntidad = "Telefono2"
      Me.txtTelefono2.ForeColorFocus = System.Drawing.Color.Red
      Me.txtTelefono2.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtTelefono2.Formato = ""
      Me.txtTelefono2.IsDecimal = False
      Me.txtTelefono2.IsNumber = False
      Me.txtTelefono2.IsPK = False
      Me.txtTelefono2.IsRequired = False
      Me.txtTelefono2.Key = ""
      Me.txtTelefono2.LabelAsoc = Me.lblTelefono2
      Me.txtTelefono2.Location = New System.Drawing.Point(453, 17)
      Me.txtTelefono2.MaxLength = 30
      Me.txtTelefono2.Name = "txtTelefono2"
      Me.txtTelefono2.Size = New System.Drawing.Size(141, 20)
      Me.txtTelefono2.TabIndex = 1
      '
      'lblTelefono2
      '
      Me.lblTelefono2.AutoSize = True
      Me.lblTelefono2.LabelAsoc = Nothing
      Me.lblTelefono2.Location = New System.Drawing.Point(390, 21)
      Me.lblTelefono2.Name = "lblTelefono2"
      Me.lblTelefono2.Size = New System.Drawing.Size(49, 13)
      Me.lblTelefono2.TabIndex = 2
      Me.lblTelefono2.Text = "Telefono"
      '
      'txtNombre
      '
      Me.txtNombre.BindearPropiedadControl = "Text"
      Me.txtNombre.BindearPropiedadEntidad = "Titular2"
      Me.txtNombre.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.txtNombre.ForeColorFocus = System.Drawing.Color.Red
      Me.txtNombre.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtNombre.Formato = ""
      Me.txtNombre.IsDecimal = False
      Me.txtNombre.IsNumber = False
      Me.txtNombre.IsPK = False
      Me.txtNombre.IsRequired = False
      Me.txtNombre.Key = ""
      Me.txtNombre.LabelAsoc = Me.lblNombre
      Me.txtNombre.Location = New System.Drawing.Point(57, 20)
      Me.txtNombre.MaxLength = 50
      Me.txtNombre.Name = "txtNombre"
      Me.txtNombre.Size = New System.Drawing.Size(320, 20)
      Me.txtNombre.TabIndex = 0
      '
      'lblNombre
      '
      Me.lblNombre.AutoSize = True
      Me.lblNombre.ForeColor = System.Drawing.SystemColors.WindowText
      Me.lblNombre.LabelAsoc = Nothing
      Me.lblNombre.Location = New System.Drawing.Point(6, 24)
      Me.lblNombre.Name = "lblNombre"
      Me.lblNombre.Size = New System.Drawing.Size(44, 13)
      Me.lblNombre.TabIndex = 0
      Me.lblNombre.Text = "Nombre"
      '
      'grbPlanDePago
      '
      Me.grbPlanDePago.Controls.Add(Me.ugDetalle)
      Me.grbPlanDePago.Controls.Add(Me.lblRegistrosSeleccionados)
      Me.grbPlanDePago.Controls.Add(Me.txtRegistrosSeleccionados)
      Me.grbPlanDePago.Controls.Add(Me.Label5)
      Me.grbPlanDePago.Controls.Add(Me.Label4)
      Me.grbPlanDePago.Controls.Add(Me.Label3)
      Me.grbPlanDePago.Controls.Add(Me.txtPromedio)
      Me.grbPlanDePago.Controls.Add(Me.txtSeleccionado)
      Me.grbPlanDePago.Controls.Add(Me.txtPendiente)
      Me.grbPlanDePago.Controls.Add(Me.chbTodos)
      Me.grbPlanDePago.Controls.Add(Me.dgvPeriodosAdeudados)
      Me.grbPlanDePago.Location = New System.Drawing.Point(5, 109)
      Me.grbPlanDePago.Name = "grbPlanDePago"
      Me.grbPlanDePago.Size = New System.Drawing.Size(758, 216)
      Me.grbPlanDePago.TabIndex = 22
      Me.grbPlanDePago.TabStop = False
      Me.grbPlanDePago.Text = "Plan de Pago"
      '
      'ugDetalle
      '
      Me.ugDetalle.DataMember = Nothing
      Appearance1.BackColor = System.Drawing.SystemColors.Window
      Appearance1.BorderColor = System.Drawing.SystemColors.InactiveCaption
      Me.ugDetalle.DisplayLayout.Appearance = Appearance1
      UltraGridColumn38.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
      UltraGridColumn38.Header.VisiblePosition = 2
      UltraGridColumn38.Hidden = True
      UltraGridColumn39.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
      Appearance2.TextHAlignAsString = "Right"
      UltraGridColumn39.CellAppearance = Appearance2
      UltraGridColumn39.Format = ""
      UltraGridColumn39.Header.Caption = "Código"
      UltraGridColumn39.Header.VisiblePosition = 3
      UltraGridColumn39.Hidden = True
      UltraGridColumn39.Width = 78
      UltraGridColumn40.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
      Appearance3.TextHAlignAsString = "Right"
      UltraGridColumn40.CellAppearance = Appearance3
      UltraGridColumn40.Header.Caption = "Nro. Préstamo"
      UltraGridColumn40.Header.VisiblePosition = 5
      UltraGridColumn40.Width = 75
      UltraGridColumn41.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
      UltraGridColumn41.Header.VisiblePosition = 16
      UltraGridColumn41.Hidden = True
      UltraGridColumn42.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
      UltraGridColumn42.Header.Caption = "Tipo Cobro"
      UltraGridColumn42.Header.VisiblePosition = 19
      UltraGridColumn42.Width = 92
      UltraGridColumn43.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
      UltraGridColumn43.Header.Caption = "Mutual"
      UltraGridColumn43.Header.VisiblePosition = 4
      UltraGridColumn43.Width = 88
      UltraGridColumn45.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
      UltraGridColumn45.Header.Caption = "Tipo Préstamo"
      UltraGridColumn45.Header.VisiblePosition = 18
      UltraGridColumn46.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
      UltraGridColumn46.Header.Caption = "Fecha emisión"
      UltraGridColumn46.Header.VisiblePosition = 11
      UltraGridColumn46.Width = 68
      UltraGridColumn47.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
      UltraGridColumn47.Header.Caption = "Cantidad Cuotas"
      UltraGridColumn47.Header.VisiblePosition = 12
      UltraGridColumn47.Width = 58
      UltraGridColumn59.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
      UltraGridColumn59.Header.Caption = "Cuotas Pagas"
      UltraGridColumn59.Header.VisiblePosition = 13
      UltraGridColumn59.Width = 51
      UltraGridColumn49.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
      UltraGridColumn49.Header.Caption = "Cuotas Adeudadas"
      UltraGridColumn49.Header.VisiblePosition = 14
      UltraGridColumn49.Width = 68
      UltraGridColumn51.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
      Appearance4.TextHAlignAsString = "Right"
      UltraGridColumn51.CellAppearance = Appearance4
      UltraGridColumn51.Format = "N2"
      UltraGridColumn51.Header.Caption = "Capital"
      UltraGridColumn51.Header.VisiblePosition = 6
      UltraGridColumn51.Width = 83
      UltraGridColumn52.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
      Appearance5.TextHAlignAsString = "Right"
      UltraGridColumn52.CellAppearance = Appearance5
      UltraGridColumn52.Format = "N2"
      UltraGridColumn52.Header.Caption = "Monto Máximo Exigible"
      UltraGridColumn52.Header.VisiblePosition = 9
      UltraGridColumn52.Width = 87
      UltraGridColumn53.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
      UltraGridColumn53.Header.Caption = "Ultima Fecha Pago"
      UltraGridColumn53.Header.VisiblePosition = 17
      UltraGridColumn53.Width = 79
      UltraGridColumn54.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
      Appearance6.TextHAlignAsString = "Right"
      UltraGridColumn54.CellAppearance = Appearance6
      UltraGridColumn54.Header.Caption = "Días Mora"
      UltraGridColumn54.Header.VisiblePosition = 15
      UltraGridColumn54.Width = 62
      UltraGridColumn55.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
      Appearance7.TextHAlignAsString = "Right"
      UltraGridColumn55.CellAppearance = Appearance7
      UltraGridColumn55.Format = "N2"
      UltraGridColumn55.Header.Caption = "Monto Mínimo Exigible"
      UltraGridColumn55.Header.VisiblePosition = 8
      UltraGridColumn55.Width = 82
      UltraGridColumn56.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
      UltraGridColumn56.Header.Caption = "Empresa"
      UltraGridColumn56.Header.VisiblePosition = 1
      UltraGridColumn56.Width = 73
      UltraGridColumn44.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
      UltraGridColumn44.Header.VisiblePosition = 20
      UltraGridColumn44.Hidden = True
      UltraGridColumn50.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
      UltraGridColumn50.Header.VisiblePosition = 21
      UltraGridColumn50.Hidden = True
      UltraGridColumn57.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
      UltraGridColumn57.Header.VisiblePosition = 22
      UltraGridColumn57.Hidden = True
      UltraGridColumn58.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
      UltraGridColumn58.Header.VisiblePosition = 23
      UltraGridColumn58.Hidden = True
      Appearance8.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
      Appearance8.TextHAlignAsString = "Right"
      UltraGridColumn8.CellAppearance = Appearance8
      UltraGridColumn8.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.Edit
      UltraGridColumn8.Header.Caption = "Importe Acordado"
      UltraGridColumn8.Header.VisiblePosition = 10
      UltraGridColumn8.Width = 87
      UltraGridColumn10.Header.VisiblePosition = 24
      UltraGridColumn10.Hidden = True
      UltraGridColumn11.Header.VisiblePosition = 25
      UltraGridColumn11.Hidden = True
      UltraGridColumn12.Header.VisiblePosition = 26
      UltraGridColumn12.Hidden = True
      UltraGridColumn13.Header.VisiblePosition = 27
      UltraGridColumn13.Hidden = True
      UltraGridColumn14.Header.VisiblePosition = 28
      UltraGridColumn14.Hidden = True
      UltraGridColumn15.Header.VisiblePosition = 29
      UltraGridColumn15.Hidden = True
      UltraGridColumn16.Header.VisiblePosition = 30
      UltraGridColumn16.Hidden = True
      Appearance9.TextHAlignAsString = "Right"
      UltraGridColumn1.CellAppearance = Appearance9
      UltraGridColumn1.Format = "N2"
      UltraGridColumn1.Header.Caption = "Monto cuota"
      UltraGridColumn1.Header.VisiblePosition = 7
      UltraGridColumn1.Width = 83
      UltraGridColumn9.DataType = GetType(Boolean)
      UltraGridColumn9.DefaultCellValue = False
      UltraGridColumn9.Header.Caption = ""
      UltraGridColumn9.Header.VisiblePosition = 0
      UltraGridColumn9.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.CheckBox
      UltraGridColumn9.Width = 46
      UltraGridBand1.Columns.AddRange(New Object() {UltraGridColumn38, UltraGridColumn39, UltraGridColumn40, UltraGridColumn41, UltraGridColumn42, UltraGridColumn43, UltraGridColumn45, UltraGridColumn46, UltraGridColumn47, UltraGridColumn59, UltraGridColumn49, UltraGridColumn51, UltraGridColumn52, UltraGridColumn53, UltraGridColumn54, UltraGridColumn55, UltraGridColumn56, UltraGridColumn44, UltraGridColumn50, UltraGridColumn57, UltraGridColumn58, UltraGridColumn8, UltraGridColumn10, UltraGridColumn11, UltraGridColumn12, UltraGridColumn13, UltraGridColumn14, UltraGridColumn15, UltraGridColumn16, UltraGridColumn1, UltraGridColumn9})
      Me.ugDetalle.DisplayLayout.BandsSerializer.Add(UltraGridBand1)
      Me.ugDetalle.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
      Me.ugDetalle.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.[False]
      Appearance10.BackColor = System.Drawing.SystemColors.ActiveBorder
      Appearance10.BackColor2 = System.Drawing.SystemColors.ControlDark
      Appearance10.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
      Appearance10.BorderColor = System.Drawing.SystemColors.Window
      Me.ugDetalle.DisplayLayout.GroupByBox.Appearance = Appearance10
      Appearance11.ForeColor = System.Drawing.SystemColors.GrayText
      Me.ugDetalle.DisplayLayout.GroupByBox.BandLabelAppearance = Appearance11
      Me.ugDetalle.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
      Me.ugDetalle.DisplayLayout.GroupByBox.Hidden = True
      Me.ugDetalle.DisplayLayout.GroupByBox.Prompt = "Arrastre un título de columna aquí para agrupar."
      Appearance12.BackColor = System.Drawing.SystemColors.ControlLightLight
      Appearance12.BackColor2 = System.Drawing.SystemColors.Control
      Appearance12.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
      Appearance12.ForeColor = System.Drawing.SystemColors.GrayText
      Me.ugDetalle.DisplayLayout.GroupByBox.PromptAppearance = Appearance12
      Me.ugDetalle.DisplayLayout.MaxColScrollRegions = 1
      Me.ugDetalle.DisplayLayout.MaxRowScrollRegions = 1
      Appearance13.BackColor = System.Drawing.SystemColors.Window
      Appearance13.ForeColor = System.Drawing.SystemColors.ControlText
      Me.ugDetalle.DisplayLayout.Override.ActiveCellAppearance = Appearance13
      Appearance14.BackColor = System.Drawing.SystemColors.Highlight
      Appearance14.ForeColor = System.Drawing.SystemColors.HighlightText
      Me.ugDetalle.DisplayLayout.Override.ActiveRowAppearance = Appearance14
      Me.ugDetalle.DisplayLayout.Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.No
      Me.ugDetalle.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.[False]
      Me.ugDetalle.DisplayLayout.Override.AllowUpdate = Infragistics.Win.DefaultableBoolean.[True]
      Me.ugDetalle.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted
      Me.ugDetalle.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted
      Appearance15.BackColor = System.Drawing.SystemColors.Window
      Me.ugDetalle.DisplayLayout.Override.CardAreaAppearance = Appearance15
      Appearance16.BorderColor = System.Drawing.Color.Silver
      Appearance16.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter
      Me.ugDetalle.DisplayLayout.Override.CellAppearance = Appearance16
      Me.ugDetalle.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText
      Me.ugDetalle.DisplayLayout.Override.CellPadding = 0
      Appearance17.BackColor = System.Drawing.SystemColors.Control
      Appearance17.BackColor2 = System.Drawing.SystemColors.ControlDark
      Appearance17.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element
      Appearance17.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
      Appearance17.BorderColor = System.Drawing.SystemColors.Window
      Me.ugDetalle.DisplayLayout.Override.GroupByRowAppearance = Appearance17
      Appearance18.TextHAlignAsString = "Left"
      Me.ugDetalle.DisplayLayout.Override.HeaderAppearance = Appearance18
      Me.ugDetalle.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
      Me.ugDetalle.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand
      Appearance19.BackColor = System.Drawing.SystemColors.Window
      Appearance19.BorderColor = System.Drawing.Color.Silver
      Me.ugDetalle.DisplayLayout.Override.RowAppearance = Appearance19
      Me.ugDetalle.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[False]
      Me.ugDetalle.DisplayLayout.Override.SummaryDisplayArea = Infragistics.Win.UltraWinGrid.SummaryDisplayAreas.BottomFixed
      Appearance20.BackColor = System.Drawing.SystemColors.ControlLight
      Me.ugDetalle.DisplayLayout.Override.TemplateAddRowAppearance = Appearance20
      Me.ugDetalle.DisplayLayout.Override.WrapHeaderText = Infragistics.Win.DefaultableBoolean.[True]
      Me.ugDetalle.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill
      Me.ugDetalle.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate
      Me.ugDetalle.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy
      Me.ugDetalle.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.ugDetalle.Location = New System.Drawing.Point(9, 41)
      Me.ugDetalle.Name = "ugDetalle"
      Me.ugDetalle.Size = New System.Drawing.Size(743, 169)
      Me.ugDetalle.TabIndex = 11
      '
      'lblRegistrosSeleccionados
      '
      Me.lblRegistrosSeleccionados.AutoSize = True
      Me.lblRegistrosSeleccionados.Location = New System.Drawing.Point(299, 19)
      Me.lblRegistrosSeleccionados.Name = "lblRegistrosSeleccionados"
      Me.lblRegistrosSeleccionados.Size = New System.Drawing.Size(12, 13)
      Me.lblRegistrosSeleccionados.TabIndex = 10
      Me.lblRegistrosSeleccionados.Text = "/"
      Me.lblRegistrosSeleccionados.Visible = False
      '
      'txtRegistrosSeleccionados
      '
      Me.txtRegistrosSeleccionados.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer))
      Me.txtRegistrosSeleccionados.Location = New System.Drawing.Point(309, 15)
      Me.txtRegistrosSeleccionados.Name = "txtRegistrosSeleccionados"
      Me.txtRegistrosSeleccionados.ReadOnly = True
      Me.txtRegistrosSeleccionados.Size = New System.Drawing.Size(19, 20)
      Me.txtRegistrosSeleccionados.TabIndex = 9
      Me.txtRegistrosSeleccionados.Text = "0"
      Me.txtRegistrosSeleccionados.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
      Me.txtRegistrosSeleccionados.Visible = False
      '
      'Label5
      '
      Me.Label5.AutoSize = True
      Me.Label5.Location = New System.Drawing.Point(452, 18)
      Me.Label5.Name = "Label5"
      Me.Label5.Size = New System.Drawing.Size(53, 13)
      Me.Label5.TabIndex = 8
      Me.Label5.Text = "Acordado"
      Me.Label5.Visible = False
      '
      'Label4
      '
      Me.Label4.AutoSize = True
      Me.Label4.Location = New System.Drawing.Point(336, 18)
      Me.Label4.Name = "Label4"
      Me.Label4.Size = New System.Drawing.Size(34, 13)
      Me.Label4.TabIndex = 7
      Me.Label4.Text = "Prom."
      Me.Label4.Visible = False
      '
      'Label3
      '
      Me.Label3.AutoSize = True
      Me.Label3.Location = New System.Drawing.Point(171, 18)
      Me.Label3.Name = "Label3"
      Me.Label3.Size = New System.Drawing.Size(54, 13)
      Me.Label3.TabIndex = 6
      Me.Label3.Text = "Seleccion"
      Me.Label3.Visible = False
      '
      'txtPromedio
      '
      Me.txtPromedio.Location = New System.Drawing.Point(373, 15)
      Me.txtPromedio.Name = "txtPromedio"
      Me.txtPromedio.ReadOnly = True
      Me.txtPromedio.Size = New System.Drawing.Size(73, 20)
      Me.txtPromedio.TabIndex = 5
      Me.txtPromedio.Text = "0.00"
      Me.txtPromedio.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      Me.txtPromedio.Visible = False
      '
      'txtSeleccionado
      '
      Me.txtSeleccionado.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer))
      Me.txtSeleccionado.Location = New System.Drawing.Point(226, 15)
      Me.txtSeleccionado.Name = "txtSeleccionado"
      Me.txtSeleccionado.ReadOnly = True
      Me.txtSeleccionado.Size = New System.Drawing.Size(73, 20)
      Me.txtSeleccionado.TabIndex = 4
      Me.txtSeleccionado.Text = "0.00"
      Me.txtSeleccionado.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      Me.txtSeleccionado.Visible = False
      '
      'txtPendiente
      '
      Me.txtPendiente.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
      Me.txtPendiente.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
      Me.txtPendiente.Location = New System.Drawing.Point(508, 15)
      Me.txtPendiente.Name = "txtPendiente"
      Me.txtPendiente.ReadOnly = True
      Me.txtPendiente.Size = New System.Drawing.Size(87, 20)
      Me.txtPendiente.TabIndex = 3
      Me.txtPendiente.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      Me.txtPendiente.Visible = False
      '
      'chbTodos
      '
      Me.chbTodos.BindearPropiedadControl = Nothing
      Me.chbTodos.BindearPropiedadEntidad = Nothing
      Me.chbTodos.ForeColorFocus = System.Drawing.Color.Red
      Me.chbTodos.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
      Me.chbTodos.Image = CType(resources.GetObject("chbTodos.Image"), System.Drawing.Image)
      Me.chbTodos.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
      Me.chbTodos.IsPK = False
      Me.chbTodos.IsRequired = False
      Me.chbTodos.Key = Nothing
      Me.chbTodos.LabelAsoc = Nothing
      Me.chbTodos.Location = New System.Drawing.Point(26, 14)
      Me.chbTodos.Name = "chbTodos"
      Me.chbTodos.Size = New System.Drawing.Size(122, 24)
      Me.chbTodos.TabIndex = 2
      Me.chbTodos.Text = "Chequear Todos"
      Me.chbTodos.UseVisualStyleBackColor = True
      '
      'dgvPeriodosAdeudados
      '
      Me.dgvPeriodosAdeudados.AllowUserToAddRows = False
      Me.dgvPeriodosAdeudados.AllowUserToDeleteRows = False
      Me.dgvPeriodosAdeudados.AllowUserToResizeRows = False
      Me.dgvPeriodosAdeudados.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
      Me.dgvPeriodosAdeudados.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.ppPeriodo, Me.ppImporteAproximado, Me.ppFechaPago, Me.ppFechaCarta1, Me.ppFechaCarta2, Me.ppFechaCarta3, Me.ppFechaUltimaModificacion, Me.ppFechaLiquidacion, Me.ppFechaActualizadoAl, Me.ppFechaCobro, Me.ppImporteCobrado, Me.ppDarDeBaja, Me.ppIdPago, Me.ppDato, Me.ppLocalidad, Me.ppLocalidad2, Me.ppUsuario, Me.ppIdSucursal, Me.ppPassword, Me.ppDocumento, Me.ppFechaVencimiento})
      Me.dgvPeriodosAdeudados.Location = New System.Drawing.Point(9, 41)
      Me.dgvPeriodosAdeudados.Name = "dgvPeriodosAdeudados"
      Me.dgvPeriodosAdeudados.RowHeadersVisible = False
      Me.dgvPeriodosAdeudados.RowHeadersWidth = 10
      DataGridViewCellStyle8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.dgvPeriodosAdeudados.RowsDefaultCellStyle = DataGridViewCellStyle8
      Me.dgvPeriodosAdeudados.RowTemplate.Height = 19
      Me.dgvPeriodosAdeudados.Size = New System.Drawing.Size(592, 89)
      Me.dgvPeriodosAdeudados.TabIndex = 0
      '
      'ppPeriodo
      '
      Me.ppPeriodo.DataPropertyName = "Periodo"
      DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
      Me.ppPeriodo.DefaultCellStyle = DataGridViewCellStyle5
      Me.ppPeriodo.HeaderText = "Periodo"
      Me.ppPeriodo.Name = "ppPeriodo"
      Me.ppPeriodo.ReadOnly = True
      Me.ppPeriodo.Width = 70
      '
      'ppImporteAproximado
      '
      Me.ppImporteAproximado.DataPropertyName = "ImporteAproximado"
      DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
      DataGridViewCellStyle6.Format = "N2"
      DataGridViewCellStyle6.NullValue = Nothing
      Me.ppImporteAproximado.DefaultCellStyle = DataGridViewCellStyle6
      Me.ppImporteAproximado.HeaderText = "Importe Aprox."
      Me.ppImporteAproximado.Name = "ppImporteAproximado"
      Me.ppImporteAproximado.ReadOnly = True
      '
      'ppFechaPago
      '
      Me.ppFechaPago.DataPropertyName = "FechaPago"
      Me.ppFechaPago.HeaderText = "Fecha Pago"
      Me.ppFechaPago.Name = "ppFechaPago"
      Me.ppFechaPago.Visible = False
      Me.ppFechaPago.Width = 95
      '
      'ppFechaCarta1
      '
      Me.ppFechaCarta1.DataPropertyName = "FechaCarta1"
      Me.ppFechaCarta1.HeaderText = "Carta 1"
      Me.ppFechaCarta1.Name = "ppFechaCarta1"
      Me.ppFechaCarta1.ReadOnly = True
      Me.ppFechaCarta1.Width = 115
      '
      'ppFechaCarta2
      '
      Me.ppFechaCarta2.DataPropertyName = "FechaCarta2"
      Me.ppFechaCarta2.HeaderText = "Carta 2"
      Me.ppFechaCarta2.Name = "ppFechaCarta2"
      Me.ppFechaCarta2.ReadOnly = True
      Me.ppFechaCarta2.Width = 115
      '
      'ppFechaCarta3
      '
      Me.ppFechaCarta3.DataPropertyName = "FechaCarta3"
      Me.ppFechaCarta3.HeaderText = "Carta 3"
      Me.ppFechaCarta3.Name = "ppFechaCarta3"
      Me.ppFechaCarta3.ReadOnly = True
      Me.ppFechaCarta3.Width = 115
      '
      'ppFechaUltimaModificacion
      '
      Me.ppFechaUltimaModificacion.DataPropertyName = "FechaUltimaModificacion"
      Me.ppFechaUltimaModificacion.HeaderText = "Ultima Modif."
      Me.ppFechaUltimaModificacion.Name = "ppFechaUltimaModificacion"
      Me.ppFechaUltimaModificacion.ReadOnly = True
      Me.ppFechaUltimaModificacion.Width = 115
      '
      'ppFechaLiquidacion
      '
      Me.ppFechaLiquidacion.DataPropertyName = "FechaLiquidacion"
      Me.ppFechaLiquidacion.HeaderText = "Fecha Liq."
      Me.ppFechaLiquidacion.Name = "ppFechaLiquidacion"
      Me.ppFechaLiquidacion.Width = 115
      '
      'ppFechaActualizadoAl
      '
      Me.ppFechaActualizadoAl.DataPropertyName = "FechaActualizadoAl"
      Me.ppFechaActualizadoAl.HeaderText = "Actualizado al"
      Me.ppFechaActualizadoAl.Name = "ppFechaActualizadoAl"
      Me.ppFechaActualizadoAl.ReadOnly = True
      Me.ppFechaActualizadoAl.Width = 115
      '
      'ppFechaCobro
      '
      Me.ppFechaCobro.DataPropertyName = "FechaCobro"
      Me.ppFechaCobro.HeaderText = "Fecha Cobro"
      Me.ppFechaCobro.Name = "ppFechaCobro"
      Me.ppFechaCobro.Visible = False
      '
      'ppImporteCobrado
      '
      Me.ppImporteCobrado.DataPropertyName = "ImporteCobrado"
      DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
      DataGridViewCellStyle7.Format = "N2"
      DataGridViewCellStyle7.NullValue = Nothing
      Me.ppImporteCobrado.DefaultCellStyle = DataGridViewCellStyle7
      Me.ppImporteCobrado.HeaderText = "Imp. Cobrado"
      Me.ppImporteCobrado.Name = "ppImporteCobrado"
      Me.ppImporteCobrado.Visible = False
      Me.ppImporteCobrado.Width = 95
      '
      'ppDarDeBaja
      '
      Me.ppDarDeBaja.DataPropertyName = "DarDeBaja"
      Me.ppDarDeBaja.HeaderText = "ppDarDeBaja"
      Me.ppDarDeBaja.Name = "ppDarDeBaja"
      Me.ppDarDeBaja.Visible = False
      '
      'ppIdPago
      '
      Me.ppIdPago.DataPropertyName = "IdPago"
      Me.ppIdPago.HeaderText = "ppIdPago"
      Me.ppIdPago.Name = "ppIdPago"
      Me.ppIdPago.Visible = False
      '
      'ppDato
      '
      Me.ppDato.DataPropertyName = "Dato"
      Me.ppDato.HeaderText = "ppDato"
      Me.ppDato.Name = "ppDato"
      Me.ppDato.Visible = False
      '
      'ppLocalidad
      '
      Me.ppLocalidad.DataPropertyName = "Localidad"
      Me.ppLocalidad.HeaderText = "ppLocalidad"
      Me.ppLocalidad.Name = "ppLocalidad"
      Me.ppLocalidad.Visible = False
      '
      'ppLocalidad2
      '
      Me.ppLocalidad2.DataPropertyName = "Localidad2"
      Me.ppLocalidad2.HeaderText = "ppLocalidad2"
      Me.ppLocalidad2.Name = "ppLocalidad2"
      Me.ppLocalidad2.Visible = False
      '
      'ppUsuario
      '
      Me.ppUsuario.DataPropertyName = "Usuario"
      Me.ppUsuario.HeaderText = "ppUsuario"
      Me.ppUsuario.Name = "ppUsuario"
      Me.ppUsuario.Visible = False
      '
      'ppIdSucursal
      '
      Me.ppIdSucursal.DataPropertyName = "IdSucursal"
      Me.ppIdSucursal.HeaderText = "ppIdSucursal"
      Me.ppIdSucursal.Name = "ppIdSucursal"
      Me.ppIdSucursal.Visible = False
      '
      'ppPassword
      '
      Me.ppPassword.DataPropertyName = "Password"
      Me.ppPassword.HeaderText = "ppPassword"
      Me.ppPassword.Name = "ppPassword"
      Me.ppPassword.Visible = False
      '
      'ppDocumento
      '
      Me.ppDocumento.DataPropertyName = "Documento"
      Me.ppDocumento.HeaderText = "ppDocumento"
      Me.ppDocumento.Name = "ppDocumento"
      Me.ppDocumento.Visible = False
      '
      'ppFechaVencimiento
      '
      Me.ppFechaVencimiento.DataPropertyName = "FechaVencimiento"
      Me.ppFechaVencimiento.HeaderText = "ppFechaVencimiento"
      Me.ppFechaVencimiento.Name = "ppFechaVencimiento"
      Me.ppFechaVencimiento.Visible = False
      '
      'txtObservacion
      '
      Me.txtObservacion.BindearPropiedadControl = "Text"
      Me.txtObservacion.BindearPropiedadEntidad = "Domicilio2"
      Me.txtObservacion.ForeColorFocus = System.Drawing.Color.Red
      Me.txtObservacion.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtObservacion.Formato = ""
      Me.txtObservacion.IsDecimal = False
      Me.txtObservacion.IsNumber = False
      Me.txtObservacion.IsPK = False
      Me.txtObservacion.IsRequired = False
      Me.txtObservacion.Key = ""
      Me.txtObservacion.LabelAsoc = Me.Label1
      Me.txtObservacion.Location = New System.Drawing.Point(48, 474)
      Me.txtObservacion.MaxLength = 50
      Me.txtObservacion.Name = "txtObservacion"
      Me.txtObservacion.Size = New System.Drawing.Size(144, 20)
      Me.txtObservacion.TabIndex = 8
      '
      'Label1
      '
      Me.Label1.AutoSize = True
      Me.Label1.LabelAsoc = Nothing
      Me.Label1.Location = New System.Drawing.Point(5, 477)
      Me.Label1.Name = "Label1"
      Me.Label1.Size = New System.Drawing.Size(44, 13)
      Me.Label1.TabIndex = 9
      Me.Label1.Text = "Observ."
      '
      'txtReferencia
      '
      Me.txtReferencia.BindearPropiedadControl = "Text"
      Me.txtReferencia.BindearPropiedadEntidad = "Domicilio2"
      Me.txtReferencia.ForeColorFocus = System.Drawing.Color.Red
      Me.txtReferencia.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtReferencia.Formato = ""
      Me.txtReferencia.IsDecimal = False
      Me.txtReferencia.IsNumber = False
      Me.txtReferencia.IsPK = False
      Me.txtReferencia.IsRequired = False
      Me.txtReferencia.Key = ""
      Me.txtReferencia.LabelAsoc = Me.Label2
      Me.txtReferencia.Location = New System.Drawing.Point(254, 474)
      Me.txtReferencia.MaxLength = 50
      Me.txtReferencia.Name = "txtReferencia"
      Me.txtReferencia.Size = New System.Drawing.Size(157, 20)
      Me.txtReferencia.TabIndex = 41
      '
      'Label2
      '
      Me.Label2.AutoSize = True
      Me.Label2.LabelAsoc = Nothing
      Me.Label2.Location = New System.Drawing.Point(198, 477)
      Me.Label2.Name = "Label2"
      Me.Label2.Size = New System.Drawing.Size(59, 13)
      Me.Label2.TabIndex = 42
      Me.Label2.Text = "Referencia"
      '
      'AcuerdosDePagosDetalle
      '
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.ClientSize = New System.Drawing.Size(771, 505)
      Me.Controls.Add(Me.txtReferencia)
      Me.Controls.Add(Me.Label2)
      Me.Controls.Add(Me.btnLimpiarProducto)
      Me.Controls.Add(Me.txtObservacion)
      Me.Controls.Add(Me.Label1)
      Me.Controls.Add(Me.tspMenu)
      Me.Controls.Add(Me.dgvCuotas)
      Me.Controls.Add(Me.grbVariasCuotas)
      Me.Controls.Add(Me.lblRestan)
      Me.Controls.Add(Me.txtRestan)
      Me.Controls.Add(Me.lblSaldo)
      Me.Controls.Add(Me.txtSaldo)
      Me.Controls.Add(Me.lblCantPeriodos)
      Me.Controls.Add(Me.txtCantPeriodos)
      Me.Controls.Add(Me.grbTenedorVehiculo)
      Me.Controls.Add(Me.grbPlanDePago)
      Me.Name = "AcuerdosDePagosDetalle"
      Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
      Me.Text = "Acuerdo de Pago"
      Me.tspMenu.ResumeLayout(False)
      Me.tspMenu.PerformLayout()
      CType(Me.dgvCuotas, System.ComponentModel.ISupportInitialize).EndInit()
      Me.grbVariasCuotas.ResumeLayout(False)
      Me.grbVariasCuotas.PerformLayout()
      Me.grbTenedorVehiculo.ResumeLayout(False)
      Me.grbTenedorVehiculo.PerformLayout()
      Me.grbPlanDePago.ResumeLayout(False)
      Me.grbPlanDePago.PerformLayout()
      CType(Me.ugDetalle, System.ComponentModel.ISupportInitialize).EndInit()
      CType(Me.dgvPeriodosAdeudados, System.ComponentModel.ISupportInitialize).EndInit()
      Me.ResumeLayout(False)
      Me.PerformLayout()

   End Sub
   Friend WithEvents grbTenedorVehiculo As System.Windows.Forms.GroupBox
   Friend WithEvents cmbLocalidad2 As Eniac.Controles.ComboBox
   Friend WithEvents lblLocalidad2 As Eniac.Controles.Label
   Friend WithEvents txtDomicilio2 As Eniac.Controles.TextBox
   Friend WithEvents lblDomicilio2 As Eniac.Controles.Label
   Friend WithEvents txtTelefono2 As Eniac.Controles.TextBox
   Friend WithEvents lblTelefono2 As Eniac.Controles.Label
   Friend WithEvents txtNombre As Eniac.Controles.TextBox
   Friend WithEvents lblNombre As Eniac.Controles.Label
   Friend WithEvents grbPlanDePago As System.Windows.Forms.GroupBox
   Friend WithEvents dgvPeriodosAdeudados As Eniac.Controles.DataGridView
   Friend WithEvents chbTodos As Eniac.Controles.CheckBox
   Friend WithEvents Label5 As System.Windows.Forms.Label
   Friend WithEvents Label4 As System.Windows.Forms.Label
   Friend WithEvents Label3 As System.Windows.Forms.Label
   Friend WithEvents txtPromedio As System.Windows.Forms.TextBox
   Friend WithEvents txtSeleccionado As System.Windows.Forms.TextBox
   Friend WithEvents txtPendiente As System.Windows.Forms.TextBox
   Friend WithEvents ppPeriodo As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents ppImporteAproximado As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents ppFechaPago As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents ppFechaCarta1 As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents ppFechaCarta2 As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents ppFechaCarta3 As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents ppFechaUltimaModificacion As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents ppFechaLiquidacion As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents ppFechaActualizadoAl As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents ppFechaCobro As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents ppImporteCobrado As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents ppDarDeBaja As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents ppIdPago As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents ppDato As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents ppLocalidad As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents ppLocalidad2 As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents ppUsuario As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents ppIdSucursal As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents ppPassword As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents ppDocumento As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents ppFechaVencimiento As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents lblCantPeriodos As System.Windows.Forms.Label
   Friend WithEvents txtCantPeriodos As System.Windows.Forms.TextBox
   Friend WithEvents lblRegistrosSeleccionados As System.Windows.Forms.Label
   Friend WithEvents txtRegistrosSeleccionados As System.Windows.Forms.TextBox
   Friend WithEvents ugDetalle As Infragistics.Win.UltraWinGrid.UltraGrid
   Friend WithEvents btnLimpiarProducto As Eniac.Controles.Button
   Friend WithEvents grbVariasCuotas As System.Windows.Forms.GroupBox
   Friend WithEvents txtPrimeraCuota As Eniac.Controles.TextBox
   Friend WithEvents lblCuotas As Eniac.Controles.Label
   Friend WithEvents chbPrimerCuota As System.Windows.Forms.CheckBox
   Friend WithEvents chbDiaFijo As System.Windows.Forms.CheckBox
   Friend WithEvents txtCuotas As Eniac.Controles.TextBox
   Friend WithEvents cmbFormaPago As Eniac.Controles.ComboBox
   Friend WithEvents lblFormaPago As Eniac.Controles.Label
   Friend WithEvents btnEliminarVC As Eniac.Controles.Button
   Friend WithEvents btnInsertarVC As Eniac.Controles.Button
   Friend WithEvents dtpPrimerVencimiento As Eniac.Controles.DateTimePicker
   Friend WithEvents lblPrimerVencimiento As Eniac.Controles.Label
   Friend WithEvents dgvCuotas As Eniac.Controles.DataGridView
   Friend WithEvents MontoAPagar As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents Cuota As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents Dias As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents FechaAPagar As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents lblSaldo As Eniac.Controles.Label
   Friend WithEvents txtSaldo As Eniac.Controles.TextBox
   Friend WithEvents txtRestan As Eniac.Controles.TextBox
   Friend WithEvents lblRestan As Eniac.Controles.Label
   Friend WithEvents tspMenu As System.Windows.Forms.ToolStrip
   Friend WithEvents tsbGrabar As System.Windows.Forms.ToolStripButton
   Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
   Friend WithEvents tbsSalir As System.Windows.Forms.ToolStripButton
   Friend WithEvents txtObservacion As Eniac.Controles.TextBox
   Friend WithEvents Label1 As Eniac.Controles.Label
   Friend WithEvents txtReferencia As Eniac.Controles.TextBox
   Friend WithEvents Label2 As Eniac.Controles.Label
End Class
