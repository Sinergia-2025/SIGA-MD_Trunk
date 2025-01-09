<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PedidosPendientesAyuda
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
   '<System.Diagnostics.DebuggerStepThrough()> _
   Private Sub InitializeComponent()
      Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
      Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
      Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
      Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
      Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
      Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
      Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
      Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
      Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle10 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.grbPendientes = New System.Windows.Forms.GroupBox()
        Me.chbOrdenCompra = New Eniac.Controles.CheckBox()
        Me.txtOrdenCompra = New Eniac.Controles.TextBox()
        Me.clbTiposComprobantes = New Eniac.Controles.CheckedListBox()
        Me.bscCodigoCliente = New Eniac.Controles.Buscador()
        Me.lblCodigoCliente = New Eniac.Controles.Label()
        Me.bscCliente = New Eniac.Controles.Buscador()
        Me.lblNombre = New Eniac.Controles.Label()
        Me.chbCliente = New Eniac.Controles.CheckBox()
        Me.chkMesCompleto = New Eniac.Controles.CheckBox()
        Me.btnBuscar = New Eniac.Controles.Button()
        Me.Label2 = New Eniac.Controles.Label()
        Me.Label1 = New Eniac.Controles.Label()
        Me.dtpHasta = New Eniac.Controles.DateTimePicker()
        Me.lblHasta = New Eniac.Controles.Label()
        Me.dtpDesde = New Eniac.Controles.DateTimePicker()
        Me.lblDesde = New Eniac.Controles.Label()
        Me.dgvDetalle = New Eniac.Controles.DataGridView()
        Me.btnCancelar = New Eniac.Controles.Button()
        Me.btnAceptar = New Eniac.Controles.Button()
        Me.stsStado = New System.Windows.Forms.StatusStrip()
        Me.tssInfo = New System.Windows.Forms.ToolStripStatusLabel()
        Me.tspBarra = New System.Windows.Forms.ToolStripProgressBar()
        Me.tssRegistros = New System.Windows.Forms.ToolStripStatusLabel()
        Me.txtTotal = New Eniac.Controles.TextBox()
        Me.lblTotal = New Eniac.Controles.Label()
        Me.chbTodos = New Eniac.Controles.CheckBox()
        Me.Check = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.Fecha = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.IdTipoComprobante = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.facIdSucursal = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TipoComprobanteDescripcion = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.LetraComprobante = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CentroEmisor = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.NumeroComprobante = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Kilos = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Total = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Usuario = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.facObservacion = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.LetraCliente = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.facPassword = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.facTipoComprobante = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.facImpresora = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.facTotalImpuestos = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.facCliente = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.facPorcentajeIva = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.facVendedor = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.facFormaPago = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.facSubTotal = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.facDescuentoRecargo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.facDescuentoRecargoPorc = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ImporteBruto = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CuentaCorriente = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.IdEstadoComprobante = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ImporteNoGravado = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ImportePesos = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ImporteTickets = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ImporteTarjetas = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ImporteCheques = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.NumeroPlanilla = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.NumeroMovimiento = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TipoComprobanteFact = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.LetraFact = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CentroEmisorFact = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.NumeroComprobanteFact = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CategoriaFiscal = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Bultos = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ValorDeclarado = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Transportista = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.NumeroLote = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TotalIVA = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CantidadInvocados = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CantidadLotes = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.AFIPCAE = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TotalImporteExento = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TotalTributos = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ConceptoDelComprobante = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.AFIPIdTipoComprobante = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Utilidad = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.FechaTransmisionAFIP = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CotizacionDolar = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ComisionVendedor = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.IdCaja = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Periodo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.GrabaAutomatico = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.EsMultipleRubro = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TablaContabilidad = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ImporteACtaCte = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ImporteTransfBancaria = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CuentaBancariaTransfBanc = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.IdProvincia = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.IdActividad = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Percepciones = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.MercDespachada = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PantallaOrigen = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ReemplazaComprobante = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SaldoActualCtaCte = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.FechaEnvio = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.NumeroReparto = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.FechaRendicion = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.FechaActualizacion = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Direccion = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.IdLocalidad = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DescripcionFormaPago = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.IdProveedor = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Proveedor = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Localidad = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.IdCategoria = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.IdPlanCuenta = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.IdAsiento = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CodigoErrorAfip = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CantidadProductos = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TotalImpuestoInterno = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.NumeroOrdenCompra = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CodigoClienteVinculado = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.NombreClienteVinculado = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.grbPendientes.SuspendLayout()
        CType(Me.dgvDetalle, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.stsStado.SuspendLayout()
        Me.SuspendLayout()
        '
        'grbPendientes
        '
        Me.grbPendientes.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grbPendientes.Controls.Add(Me.chbOrdenCompra)
        Me.grbPendientes.Controls.Add(Me.txtOrdenCompra)
        Me.grbPendientes.Controls.Add(Me.clbTiposComprobantes)
        Me.grbPendientes.Controls.Add(Me.bscCodigoCliente)
        Me.grbPendientes.Controls.Add(Me.bscCliente)
        Me.grbPendientes.Controls.Add(Me.lblCodigoCliente)
        Me.grbPendientes.Controls.Add(Me.lblNombre)
        Me.grbPendientes.Controls.Add(Me.chbCliente)
        Me.grbPendientes.Controls.Add(Me.chkMesCompleto)
        Me.grbPendientes.Controls.Add(Me.btnBuscar)
        Me.grbPendientes.Controls.Add(Me.Label2)
        Me.grbPendientes.Controls.Add(Me.Label1)
        Me.grbPendientes.Controls.Add(Me.dtpHasta)
        Me.grbPendientes.Controls.Add(Me.dtpDesde)
        Me.grbPendientes.Controls.Add(Me.lblHasta)
        Me.grbPendientes.Controls.Add(Me.lblDesde)
        Me.grbPendientes.Location = New System.Drawing.Point(12, 5)
        Me.grbPendientes.Name = "grbPendientes"
        Me.grbPendientes.Size = New System.Drawing.Size(956, 119)
        Me.grbPendientes.TabIndex = 0
        Me.grbPendientes.TabStop = False
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
        Me.chbOrdenCompra.Location = New System.Drawing.Point(549, 97)
        Me.chbOrdenCompra.Name = "chbOrdenCompra"
        Me.chbOrdenCompra.Size = New System.Drawing.Size(109, 17)
        Me.chbOrdenCompra.TabIndex = 53
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
        Me.txtOrdenCompra.Location = New System.Drawing.Point(662, 94)
        Me.txtOrdenCompra.MaxLength = 6
        Me.txtOrdenCompra.Name = "txtOrdenCompra"
        Me.txtOrdenCompra.Size = New System.Drawing.Size(90, 20)
        Me.txtOrdenCompra.TabIndex = 52
        Me.txtOrdenCompra.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'clbTiposComprobantes
        '
        Me.clbTiposComprobantes.CheckOnClick = True
        Me.clbTiposComprobantes.ForeColorFocus = System.Drawing.Color.Red
        Me.clbTiposComprobantes.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.clbTiposComprobantes.FormattingEnabled = True
        Me.clbTiposComprobantes.IsPK = False
        Me.clbTiposComprobantes.IsRequired = False
        Me.clbTiposComprobantes.Key = Nothing
        Me.clbTiposComprobantes.LabelAsoc = Nothing
        Me.clbTiposComprobantes.Location = New System.Drawing.Point(411, 23)
        Me.clbTiposComprobantes.MultiColumn = True
        Me.clbTiposComprobantes.Name = "clbTiposComprobantes"
        Me.clbTiposComprobantes.Size = New System.Drawing.Size(341, 64)
        Me.clbTiposComprobantes.TabIndex = 7
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
        Me.bscCodigoCliente.FilaDevuelta = Nothing
        Me.bscCodigoCliente.ForeColorFocus = System.Drawing.Color.Red
        Me.bscCodigoCliente.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.bscCodigoCliente.IsDecimal = False
        Me.bscCodigoCliente.IsNumber = False
        Me.bscCodigoCliente.IsPK = False
        Me.bscCodigoCliente.IsRequired = False
        Me.bscCodigoCliente.Key = ""
        Me.bscCodigoCliente.LabelAsoc = Me.lblCodigoCliente
        Me.bscCodigoCliente.Location = New System.Drawing.Point(74, 91)
        Me.bscCodigoCliente.MaxLengh = "32767"
        Me.bscCodigoCliente.Name = "bscCodigoCliente"
        Me.bscCodigoCliente.Permitido = False
        Me.bscCodigoCliente.Selecciono = False
        Me.bscCodigoCliente.Size = New System.Drawing.Size(90, 23)
        Me.bscCodigoCliente.TabIndex = 12
        Me.bscCodigoCliente.Titulo = Nothing
        '
        'lblCodigoCliente
        '
        Me.lblCodigoCliente.AutoSize = True
        Me.lblCodigoCliente.LabelAsoc = Nothing
        Me.lblCodigoCliente.Location = New System.Drawing.Point(71, 75)
        Me.lblCodigoCliente.Name = "lblCodigoCliente"
        Me.lblCodigoCliente.Size = New System.Drawing.Size(40, 13)
        Me.lblCodigoCliente.TabIndex = 11
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
        Me.bscCliente.Location = New System.Drawing.Point(171, 91)
        Me.bscCliente.Margin = New System.Windows.Forms.Padding(4)
        Me.bscCliente.MaxLengh = "32767"
        Me.bscCliente.Name = "bscCliente"
        Me.bscCliente.Permitido = False
        Me.bscCliente.Selecciono = False
        Me.bscCliente.Size = New System.Drawing.Size(300, 23)
        Me.bscCliente.TabIndex = 14
        Me.bscCliente.Titulo = Nothing
        '
        'lblNombre
        '
        Me.lblNombre.AutoSize = True
        Me.lblNombre.LabelAsoc = Nothing
        Me.lblNombre.Location = New System.Drawing.Point(168, 75)
        Me.lblNombre.Name = "lblNombre"
        Me.lblNombre.Size = New System.Drawing.Size(44, 13)
        Me.lblNombre.TabIndex = 13
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
        Me.chbCliente.Location = New System.Drawing.Point(10, 91)
        Me.chbCliente.Name = "chbCliente"
        Me.chbCliente.Size = New System.Drawing.Size(58, 17)
        Me.chbCliente.TabIndex = 8
        Me.chbCliente.Text = "Cliente"
        Me.chbCliente.UseVisualStyleBackColor = True
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
        Me.chkMesCompleto.Location = New System.Drawing.Point(10, 36)
        Me.chkMesCompleto.Name = "chkMesCompleto"
        Me.chkMesCompleto.Size = New System.Drawing.Size(93, 17)
        Me.chkMesCompleto.TabIndex = 0
        Me.chkMesCompleto.Text = "Mes Completo"
        Me.chkMesCompleto.UseVisualStyleBackColor = True
        '
        'btnBuscar
        '
        Me.btnBuscar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnBuscar.Image = Global.Eniac.Win.My.Resources.Resources.view
        Me.btnBuscar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnBuscar.Location = New System.Drawing.Point(846, 50)
        Me.btnBuscar.Name = "btnBuscar"
        Me.btnBuscar.Size = New System.Drawing.Size(82, 43)
        Me.btnBuscar.TabIndex = 15
        Me.btnBuscar.Text = "&Buscar"
        Me.btnBuscar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnBuscar.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.LabelAsoc = Nothing
        Me.Label2.Location = New System.Drawing.Point(209, 17)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(91, 13)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Fecha de Emisión"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.LabelAsoc = Nothing
        Me.Label1.Location = New System.Drawing.Point(407, 10)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(109, 13)
        Me.Label1.TabIndex = 6
        Me.Label1.Text = "Tipo de Comprobante"
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
        Me.dtpHasta.Location = New System.Drawing.Point(296, 34)
        Me.dtpHasta.Name = "dtpHasta"
        Me.dtpHasta.Size = New System.Drawing.Size(95, 20)
        Me.dtpHasta.TabIndex = 5
        '
        'lblHasta
        '
        Me.lblHasta.AutoSize = True
        Me.lblHasta.LabelAsoc = Nothing
        Me.lblHasta.Location = New System.Drawing.Point(258, 38)
        Me.lblHasta.Name = "lblHasta"
        Me.lblHasta.Size = New System.Drawing.Size(35, 13)
        Me.lblHasta.TabIndex = 4
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
        Me.dtpDesde.Location = New System.Drawing.Point(153, 34)
        Me.dtpDesde.Name = "dtpDesde"
        Me.dtpDesde.Size = New System.Drawing.Size(95, 20)
        Me.dtpDesde.TabIndex = 2
        '
        'lblDesde
        '
        Me.lblDesde.AutoSize = True
        Me.lblDesde.LabelAsoc = Nothing
        Me.lblDesde.Location = New System.Drawing.Point(112, 38)
        Me.lblDesde.Name = "lblDesde"
        Me.lblDesde.Size = New System.Drawing.Size(38, 13)
        Me.lblDesde.TabIndex = 1
        Me.lblDesde.Text = "Desde"
        '
        'dgvDetalle
        '
        Me.dgvDetalle.AllowUserToAddRows = False
        Me.dgvDetalle.AllowUserToDeleteRows = False
        Me.dgvDetalle.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvDetalle.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvDetalle.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Check, Me.Fecha, Me.IdTipoComprobante, Me.facIdSucursal, Me.TipoComprobanteDescripcion, Me.LetraComprobante, Me.CentroEmisor, Me.NumeroComprobante, Me.Kilos, Me.Total, Me.Usuario, Me.facObservacion, Me.LetraCliente, Me.facPassword, Me.facTipoComprobante, Me.facImpresora, Me.facTotalImpuestos, Me.facCliente, Me.facPorcentajeIva, Me.facVendedor, Me.facFormaPago, Me.facSubTotal, Me.facDescuentoRecargo, Me.facDescuentoRecargoPorc, Me.ImporteBruto, Me.CuentaCorriente, Me.IdEstadoComprobante, Me.ImporteNoGravado, Me.ImportePesos, Me.ImporteTickets, Me.ImporteTarjetas, Me.ImporteCheques, Me.NumeroPlanilla, Me.NumeroMovimiento, Me.TipoComprobanteFact, Me.LetraFact, Me.CentroEmisorFact, Me.NumeroComprobanteFact, Me.CategoriaFiscal, Me.Bultos, Me.ValorDeclarado, Me.Transportista, Me.NumeroLote, Me.TotalIVA, Me.CantidadInvocados, Me.CantidadLotes, Me.AFIPCAE, Me.TotalImporteExento, Me.TotalTributos, Me.ConceptoDelComprobante, Me.AFIPIdTipoComprobante, Me.Utilidad, Me.FechaTransmisionAFIP, Me.CotizacionDolar, Me.ComisionVendedor, Me.IdCaja, Me.Periodo, Me.GrabaAutomatico, Me.EsMultipleRubro, Me.TablaContabilidad, Me.ImporteACtaCte, Me.ImporteTransfBancaria, Me.CuentaBancariaTransfBanc, Me.IdProvincia, Me.IdActividad, Me.Percepciones, Me.MercDespachada, Me.PantallaOrigen, Me.ReemplazaComprobante, Me.SaldoActualCtaCte, Me.FechaEnvio, Me.NumeroReparto, Me.FechaRendicion, Me.FechaActualizacion, Me.Direccion, Me.IdLocalidad, Me.DescripcionFormaPago, Me.IdProveedor, Me.Proveedor, Me.Localidad, Me.IdCategoria, Me.IdPlanCuenta, Me.IdAsiento, Me.CodigoErrorAfip, Me.CantidadProductos, Me.TotalImpuestoInterno, Me.NumeroOrdenCompra, Me.CodigoClienteVinculado, Me.NombreClienteVinculado})
        Me.dgvDetalle.Location = New System.Drawing.Point(12, 134)
        Me.dgvDetalle.Name = "dgvDetalle"
        Me.dgvDetalle.RowHeadersVisible = False
        Me.dgvDetalle.RowHeadersWidth = 20
        Me.dgvDetalle.Size = New System.Drawing.Size(956, 305)
        Me.dgvDetalle.TabIndex = 1
        '
        'btnCancelar
        '
        Me.btnCancelar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancelar.Image = Global.Eniac.Win.My.Resources.Resources.delete_24
        Me.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCancelar.Location = New System.Drawing.Point(884, 448)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(85, 30)
        Me.btnCancelar.TabIndex = 6
        Me.btnCancelar.Text = "&Cancelar"
        Me.btnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnCancelar.UseVisualStyleBackColor = True
        '
        'btnAceptar
        '
        Me.btnAceptar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnAceptar.Image = Global.Eniac.Win.My.Resources.Resources.ok_24
        Me.btnAceptar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnAceptar.Location = New System.Drawing.Point(793, 448)
        Me.btnAceptar.Name = "btnAceptar"
        Me.btnAceptar.Size = New System.Drawing.Size(85, 30)
        Me.btnAceptar.TabIndex = 5
        Me.btnAceptar.Text = "&Aceptar"
        Me.btnAceptar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnAceptar.UseVisualStyleBackColor = True
        '
        'stsStado
        '
        Me.stsStado.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tssInfo, Me.tspBarra, Me.tssRegistros})
        Me.stsStado.Location = New System.Drawing.Point(0, 491)
        Me.stsStado.Name = "stsStado"
        Me.stsStado.Size = New System.Drawing.Size(980, 22)
        Me.stsStado.TabIndex = 7
        Me.stsStado.Text = "statusStrip1"
        '
        'tssInfo
        '
        Me.tssInfo.Name = "tssInfo"
        Me.tssInfo.Size = New System.Drawing.Size(901, 17)
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
        'txtTotal
        '
        Me.txtTotal.BindearPropiedadControl = Nothing
        Me.txtTotal.BindearPropiedadEntidad = Nothing
        Me.txtTotal.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotal.ForeColorFocus = System.Drawing.Color.Red
        Me.txtTotal.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtTotal.Formato = ""
        Me.txtTotal.IsDecimal = False
        Me.txtTotal.IsNumber = False
        Me.txtTotal.IsPK = False
        Me.txtTotal.IsRequired = False
        Me.txtTotal.Key = ""
        Me.txtTotal.LabelAsoc = Nothing
        Me.txtTotal.Location = New System.Drawing.Point(584, 444)
        Me.txtTotal.Name = "txtTotal"
        Me.txtTotal.ReadOnly = True
        Me.txtTotal.Size = New System.Drawing.Size(90, 20)
        Me.txtTotal.TabIndex = 4
        Me.txtTotal.Text = "0.00"
        Me.txtTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblTotal
        '
        Me.lblTotal.AutoSize = True
        Me.lblTotal.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotal.LabelAsoc = Nothing
        Me.lblTotal.Location = New System.Drawing.Point(536, 447)
        Me.lblTotal.Name = "lblTotal"
        Me.lblTotal.Size = New System.Drawing.Size(44, 13)
        Me.lblTotal.TabIndex = 3
        Me.lblTotal.Text = "Total :"
        '
        'chbTodos
        '
        Me.chbTodos.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.chbTodos.BindearPropiedadControl = Nothing
        Me.chbTodos.BindearPropiedadEntidad = Nothing
        Me.chbTodos.ForeColorFocus = System.Drawing.Color.Red
        Me.chbTodos.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbTodos.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.chbTodos.ImageIndex = 1
        Me.chbTodos.IsPK = False
        Me.chbTodos.IsRequired = False
        Me.chbTodos.Key = Nothing
        Me.chbTodos.LabelAsoc = Nothing
        Me.chbTodos.Location = New System.Drawing.Point(12, 445)
        Me.chbTodos.Name = "chbTodos"
        Me.chbTodos.Size = New System.Drawing.Size(126, 24)
        Me.chbTodos.TabIndex = 2
        Me.chbTodos.Text = "Chequear Todos"
        Me.chbTodos.UseVisualStyleBackColor = True
        '
        'Check
        '
        Me.Check.FillWeight = 50.0!
        Me.Check.HeaderText = ""
        Me.Check.Name = "Check"
        Me.Check.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.Check.Width = 30
        '
        'Fecha
        '
        Me.Fecha.DataPropertyName = "Fecha"
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.Format = "dd/MM/yyyy HH:mm"
        DataGridViewCellStyle1.NullValue = Nothing
        Me.Fecha.DefaultCellStyle = DataGridViewCellStyle1
        Me.Fecha.HeaderText = "Emision"
        Me.Fecha.Name = "Fecha"
        Me.Fecha.ReadOnly = True
        '
        'IdTipoComprobante
        '
        Me.IdTipoComprobante.DataPropertyName = "IdTipoComprobante"
        Me.IdTipoComprobante.HeaderText = "IdTipoComprobante"
        Me.IdTipoComprobante.Name = "IdTipoComprobante"
        Me.IdTipoComprobante.Visible = False
        '
        'facIdSucursal
        '
        Me.facIdSucursal.DataPropertyName = "IdSucursal"
        Me.facIdSucursal.HeaderText = "Suc."
        Me.facIdSucursal.Name = "facIdSucursal"
        Me.facIdSucursal.Width = 40
        '
        'TipoComprobanteDescripcion
        '
        Me.TipoComprobanteDescripcion.DataPropertyName = "TipoComprobanteDescripcion"
        Me.TipoComprobanteDescripcion.HeaderText = "Tipo Comprobante"
        Me.TipoComprobanteDescripcion.Name = "TipoComprobanteDescripcion"
        Me.TipoComprobanteDescripcion.ReadOnly = True
        Me.TipoComprobanteDescripcion.Width = 120
        '
        'LetraComprobante
        '
        Me.LetraComprobante.DataPropertyName = "LetraComprobante"
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.LetraComprobante.DefaultCellStyle = DataGridViewCellStyle2
        Me.LetraComprobante.HeaderText = "L"
        Me.LetraComprobante.Name = "LetraComprobante"
        Me.LetraComprobante.Width = 30
        '
        'CentroEmisor
        '
        Me.CentroEmisor.DataPropertyName = "CentroEmisor"
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.CentroEmisor.DefaultCellStyle = DataGridViewCellStyle3
        Me.CentroEmisor.HeaderText = "Emisor"
        Me.CentroEmisor.Name = "CentroEmisor"
        Me.CentroEmisor.Width = 50
        '
        'NumeroComprobante
        '
        Me.NumeroComprobante.DataPropertyName = "NumeroComprobante"
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.NumeroComprobante.DefaultCellStyle = DataGridViewCellStyle4
        Me.NumeroComprobante.HeaderText = "Numero"
        Me.NumeroComprobante.Name = "NumeroComprobante"
        Me.NumeroComprobante.ReadOnly = True
        Me.NumeroComprobante.Width = 80
        '
        'Kilos
        '
        Me.Kilos.DataPropertyName = "Kilos"
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle5.Format = "N2"
        Me.Kilos.DefaultCellStyle = DataGridViewCellStyle5
        Me.Kilos.HeaderText = "Kilos"
        Me.Kilos.Name = "Kilos"
        Me.Kilos.Width = 75
        '
        'Total
        '
        Me.Total.DataPropertyName = "ImporteTotal"
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle6.Format = "N2"
        DataGridViewCellStyle6.NullValue = Nothing
        Me.Total.DefaultCellStyle = DataGridViewCellStyle6
        Me.Total.HeaderText = "Total"
        Me.Total.Name = "Total"
        Me.Total.ReadOnly = True
        Me.Total.Width = 75
        '
        'Usuario
        '
        Me.Usuario.DataPropertyName = "Usuario"
        Me.Usuario.HeaderText = "Usuario"
        Me.Usuario.Name = "Usuario"
        Me.Usuario.Visible = False
        '
        'facObservacion
        '
        Me.facObservacion.DataPropertyName = "Observacion"
        Me.facObservacion.HeaderText = "Observacion"
        Me.facObservacion.Name = "facObservacion"
        Me.facObservacion.Width = 270
        '
        'LetraCliente
        '
        Me.LetraCliente.DataPropertyName = "Letra"
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.LetraCliente.DefaultCellStyle = DataGridViewCellStyle7
        Me.LetraCliente.HeaderText = "LetraCliente"
        Me.LetraCliente.Name = "LetraCliente"
        Me.LetraCliente.Visible = False
        Me.LetraCliente.Width = 50
        '
        'facPassword
        '
        Me.facPassword.DataPropertyName = "Password"
        Me.facPassword.HeaderText = "Password"
        Me.facPassword.Name = "facPassword"
        Me.facPassword.Visible = False
        '
        'facTipoComprobante
        '
        Me.facTipoComprobante.DataPropertyName = "TipoComprobante"
        Me.facTipoComprobante.HeaderText = "TipoComprobante"
        Me.facTipoComprobante.Name = "facTipoComprobante"
        Me.facTipoComprobante.Visible = False
        '
        'facImpresora
        '
        Me.facImpresora.DataPropertyName = "Impresora"
        Me.facImpresora.HeaderText = "Impresora"
        Me.facImpresora.Name = "facImpresora"
        Me.facImpresora.Visible = False
        '
        'facTotalImpuestos
        '
        Me.facTotalImpuestos.DataPropertyName = "TotalImpuestos"
        Me.facTotalImpuestos.HeaderText = "TotalImpuestos"
        Me.facTotalImpuestos.Name = "facTotalImpuestos"
        Me.facTotalImpuestos.Visible = False
        '
        'facCliente
        '
        Me.facCliente.DataPropertyName = "Cliente"
        Me.facCliente.HeaderText = "Cliente"
        Me.facCliente.Name = "facCliente"
        Me.facCliente.Visible = False
        '
        'facPorcentajeIva
        '
        Me.facPorcentajeIva.DataPropertyName = "PorcentajeIva"
        Me.facPorcentajeIva.HeaderText = "PorcentajeIva"
        Me.facPorcentajeIva.Name = "facPorcentajeIva"
        Me.facPorcentajeIva.Visible = False
        '
        'facVendedor
        '
        Me.facVendedor.DataPropertyName = "Vendedor"
        Me.facVendedor.HeaderText = "Vendedor"
        Me.facVendedor.Name = "facVendedor"
        Me.facVendedor.Visible = False
        '
        'facFormaPago
        '
        Me.facFormaPago.DataPropertyName = "FormaPago"
        Me.facFormaPago.HeaderText = "FormaPago"
        Me.facFormaPago.Name = "facFormaPago"
        Me.facFormaPago.Visible = False
        '
        'facSubTotal
        '
        Me.facSubTotal.DataPropertyName = "SubTotal"
        Me.facSubTotal.HeaderText = "SubTotal"
        Me.facSubTotal.Name = "facSubTotal"
        Me.facSubTotal.Visible = False
        '
        'facDescuentoRecargo
        '
        Me.facDescuentoRecargo.DataPropertyName = "DescuentoRecargo"
        Me.facDescuentoRecargo.HeaderText = "DescuentoRecargo"
        Me.facDescuentoRecargo.Name = "facDescuentoRecargo"
        Me.facDescuentoRecargo.Visible = False
        '
        'facDescuentoRecargoPorc
        '
        Me.facDescuentoRecargoPorc.DataPropertyName = "DescuentoRecargoPorc"
        Me.facDescuentoRecargoPorc.HeaderText = "DescuentoRecargoPorc"
        Me.facDescuentoRecargoPorc.Name = "facDescuentoRecargoPorc"
        Me.facDescuentoRecargoPorc.Visible = False
        '
        'ImporteBruto
        '
        Me.ImporteBruto.DataPropertyName = "ImporteBruto"
        Me.ImporteBruto.HeaderText = "ImporteBruto"
        Me.ImporteBruto.Name = "ImporteBruto"
        Me.ImporteBruto.Visible = False
        '
        'CuentaCorriente
        '
        Me.CuentaCorriente.DataPropertyName = "CuentaCorriente"
        Me.CuentaCorriente.HeaderText = "CuentaCorriente"
        Me.CuentaCorriente.Name = "CuentaCorriente"
        Me.CuentaCorriente.Visible = False
        '
        'IdEstadoComprobante
        '
        Me.IdEstadoComprobante.DataPropertyName = "IdEstadoComprobante"
        Me.IdEstadoComprobante.HeaderText = "IdEstadoComprobante"
        Me.IdEstadoComprobante.Name = "IdEstadoComprobante"
        Me.IdEstadoComprobante.Visible = False
        '
        'ImporteNoGravado
        '
        Me.ImporteNoGravado.DataPropertyName = "ImporteNoGravado"
        Me.ImporteNoGravado.HeaderText = "ImporteNoGravado"
        Me.ImporteNoGravado.Name = "ImporteNoGravado"
        Me.ImporteNoGravado.Visible = False
        '
        'ImportePesos
        '
        Me.ImportePesos.DataPropertyName = "ImportePesos"
        Me.ImportePesos.HeaderText = "ImportePesos"
        Me.ImportePesos.Name = "ImportePesos"
        Me.ImportePesos.Visible = False
        '
        'ImporteTickets
        '
        Me.ImporteTickets.DataPropertyName = "ImporteTickets"
        Me.ImporteTickets.HeaderText = "ImporteTickets"
        Me.ImporteTickets.Name = "ImporteTickets"
        Me.ImporteTickets.Visible = False
        '
        'ImporteTarjetas
        '
        Me.ImporteTarjetas.DataPropertyName = "ImporteTarjetas"
        Me.ImporteTarjetas.HeaderText = "ImporteTarjetas"
        Me.ImporteTarjetas.Name = "ImporteTarjetas"
        Me.ImporteTarjetas.Visible = False
        '
        'ImporteCheques
        '
        Me.ImporteCheques.DataPropertyName = "ImporteCheques"
        Me.ImporteCheques.HeaderText = "ImporteCheques"
        Me.ImporteCheques.Name = "ImporteCheques"
        Me.ImporteCheques.Visible = False
        '
        'NumeroPlanilla
        '
        Me.NumeroPlanilla.DataPropertyName = "NumeroPlanilla"
        Me.NumeroPlanilla.HeaderText = "NumeroPlanilla"
        Me.NumeroPlanilla.Name = "NumeroPlanilla"
        Me.NumeroPlanilla.Visible = False
        '
        'NumeroMovimiento
        '
        Me.NumeroMovimiento.DataPropertyName = "NumeroMovimiento"
        Me.NumeroMovimiento.HeaderText = "NumeroMovimiento"
        Me.NumeroMovimiento.Name = "NumeroMovimiento"
        Me.NumeroMovimiento.Visible = False
        '
        'TipoComprobanteFact
        '
        Me.TipoComprobanteFact.DataPropertyName = "TipoComprobanteFact"
        Me.TipoComprobanteFact.HeaderText = "TipoComprobanteFact"
        Me.TipoComprobanteFact.Name = "TipoComprobanteFact"
        Me.TipoComprobanteFact.Visible = False
        '
        'LetraFact
        '
        Me.LetraFact.DataPropertyName = "LetraFact"
        Me.LetraFact.HeaderText = "LetraFact"
        Me.LetraFact.Name = "LetraFact"
        Me.LetraFact.Visible = False
        '
        'CentroEmisorFact
        '
        Me.CentroEmisorFact.DataPropertyName = "CentroEmisorFact"
        Me.CentroEmisorFact.HeaderText = "CentroEmisorFact"
        Me.CentroEmisorFact.Name = "CentroEmisorFact"
        Me.CentroEmisorFact.Visible = False
        '
        'NumeroComprobanteFact
        '
        Me.NumeroComprobanteFact.DataPropertyName = "NumeroComprobanteFact"
        Me.NumeroComprobanteFact.HeaderText = "NumeroComprobanteFact"
        Me.NumeroComprobanteFact.Name = "NumeroComprobanteFact"
        Me.NumeroComprobanteFact.Visible = False
        '
        'CategoriaFiscal
        '
        Me.CategoriaFiscal.DataPropertyName = "CategoriaFiscal"
        Me.CategoriaFiscal.HeaderText = "CategoriaFiscal"
        Me.CategoriaFiscal.Name = "CategoriaFiscal"
        Me.CategoriaFiscal.Visible = False
        '
        'Bultos
        '
        Me.Bultos.DataPropertyName = "Bultos"
        Me.Bultos.HeaderText = "Bultos"
        Me.Bultos.Name = "Bultos"
        Me.Bultos.Visible = False
        '
        'ValorDeclarado
        '
        Me.ValorDeclarado.DataPropertyName = "ValorDeclarado"
        Me.ValorDeclarado.HeaderText = "ValorDeclarado"
        Me.ValorDeclarado.Name = "ValorDeclarado"
        Me.ValorDeclarado.Visible = False
        '
        'Transportista
        '
        Me.Transportista.DataPropertyName = "Transportista"
        Me.Transportista.HeaderText = "Transportista"
        Me.Transportista.Name = "Transportista"
        Me.Transportista.Visible = False
        '
        'NumeroLote
        '
        Me.NumeroLote.DataPropertyName = "NumeroLote"
        Me.NumeroLote.HeaderText = "NumeroLote"
        Me.NumeroLote.Name = "NumeroLote"
        Me.NumeroLote.Visible = False
        '
        'TotalIVA
        '
        Me.TotalIVA.DataPropertyName = "TotalIVA"
        Me.TotalIVA.HeaderText = "TotalIVA"
        Me.TotalIVA.Name = "TotalIVA"
        Me.TotalIVA.Visible = False
        '
        'CantidadInvocados
        '
        Me.CantidadInvocados.DataPropertyName = "CantidadInvocados"
        Me.CantidadInvocados.HeaderText = "CantidadInvocados"
        Me.CantidadInvocados.Name = "CantidadInvocados"
        Me.CantidadInvocados.Visible = False
        '
        'CantidadLotes
        '
        Me.CantidadLotes.DataPropertyName = "CantidadLotes"
        Me.CantidadLotes.HeaderText = "CantidadLotes"
        Me.CantidadLotes.Name = "CantidadLotes"
        Me.CantidadLotes.Visible = False
        '
        'AFIPCAE
        '
        Me.AFIPCAE.DataPropertyName = "AFIPCAE"
        Me.AFIPCAE.HeaderText = "AFIPCAE"
        Me.AFIPCAE.Name = "AFIPCAE"
        Me.AFIPCAE.Visible = False
        '
        'TotalImporteExento
        '
        Me.TotalImporteExento.DataPropertyName = "TotalImporteExento"
        Me.TotalImporteExento.HeaderText = "TotalImporteExento"
        Me.TotalImporteExento.Name = "TotalImporteExento"
        Me.TotalImporteExento.Visible = False
        '
        'TotalTributos
        '
        Me.TotalTributos.DataPropertyName = "TotalTributos"
        Me.TotalTributos.HeaderText = "TotalTributos"
        Me.TotalTributos.Name = "TotalTributos"
        Me.TotalTributos.Visible = False
        '
        'ConceptoDelComprobante
        '
        Me.ConceptoDelComprobante.DataPropertyName = "ConceptoDelComprobante"
        Me.ConceptoDelComprobante.HeaderText = "ConceptoDelComprobante"
        Me.ConceptoDelComprobante.Name = "ConceptoDelComprobante"
        Me.ConceptoDelComprobante.Visible = False
        '
        'AFIPIdTipoComprobante
        '
        Me.AFIPIdTipoComprobante.DataPropertyName = "AFIPIdTipoComprobante"
        Me.AFIPIdTipoComprobante.HeaderText = "AFIPIdTipoComprobante"
        Me.AFIPIdTipoComprobante.Name = "AFIPIdTipoComprobante"
        Me.AFIPIdTipoComprobante.Visible = False
        '
        'Utilidad
        '
        Me.Utilidad.DataPropertyName = "Utilidad"
        Me.Utilidad.HeaderText = "Utilidad"
        Me.Utilidad.Name = "Utilidad"
        Me.Utilidad.Visible = False
        '
        'FechaTransmisionAFIP
        '
        Me.FechaTransmisionAFIP.DataPropertyName = "FechaTransmisionAFIP"
        Me.FechaTransmisionAFIP.HeaderText = "FechaTransmisionAFIP"
        Me.FechaTransmisionAFIP.Name = "FechaTransmisionAFIP"
        Me.FechaTransmisionAFIP.Visible = False
        '
        'CotizacionDolar
        '
        Me.CotizacionDolar.DataPropertyName = "CotizacionDolar"
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle8.Format = "N2"
        Me.CotizacionDolar.DefaultCellStyle = DataGridViewCellStyle8
        Me.CotizacionDolar.HeaderText = "Cotización Dólar"
        Me.CotizacionDolar.Name = "CotizacionDolar"
        '
        'ComisionVendedor
        '
        Me.ComisionVendedor.DataPropertyName = "ComisionVendedor"
        Me.ComisionVendedor.HeaderText = "ComisionVendedor"
        Me.ComisionVendedor.Name = "ComisionVendedor"
        Me.ComisionVendedor.Visible = False
        '
        'IdCaja
        '
        Me.IdCaja.DataPropertyName = "IdCaja"
        Me.IdCaja.HeaderText = "IdCaja"
        Me.IdCaja.Name = "IdCaja"
        Me.IdCaja.Visible = False
        '
        'Periodo
        '
        Me.Periodo.DataPropertyName = "Periodo"
        Me.Periodo.HeaderText = "Periodo"
        Me.Periodo.Name = "Periodo"
        Me.Periodo.Visible = False
        '
        'GrabaAutomatico
        '
        Me.GrabaAutomatico.DataPropertyName = "GrabaAutomatico"
        Me.GrabaAutomatico.HeaderText = "GrabaAutomatico"
        Me.GrabaAutomatico.Name = "GrabaAutomatico"
        Me.GrabaAutomatico.Visible = False
        '
        'EsMultipleRubro
        '
        Me.EsMultipleRubro.DataPropertyName = "EsMultipleRubro"
        Me.EsMultipleRubro.HeaderText = "EsMultipleRubro"
        Me.EsMultipleRubro.Name = "EsMultipleRubro"
        Me.EsMultipleRubro.Visible = False
        '
        'TablaContabilidad
        '
        Me.TablaContabilidad.DataPropertyName = "TablaContabilidad"
        Me.TablaContabilidad.HeaderText = "TablaContabilidad"
        Me.TablaContabilidad.Name = "TablaContabilidad"
        Me.TablaContabilidad.Visible = False
        '
        'ImporteACtaCte
        '
        Me.ImporteACtaCte.DataPropertyName = "ImporteACtaCte"
        Me.ImporteACtaCte.HeaderText = "ImporteACtaCte"
        Me.ImporteACtaCte.Name = "ImporteACtaCte"
        Me.ImporteACtaCte.Visible = False
        '
        'ImporteTransfBancaria
        '
        Me.ImporteTransfBancaria.DataPropertyName = "ImporteTransfBancaria"
        Me.ImporteTransfBancaria.HeaderText = "ImporteTransfBancaria"
        Me.ImporteTransfBancaria.Name = "ImporteTransfBancaria"
        Me.ImporteTransfBancaria.Visible = False
        '
        'CuentaBancariaTransfBanc
        '
        Me.CuentaBancariaTransfBanc.DataPropertyName = "CuentaBancariaTransfBanc"
        Me.CuentaBancariaTransfBanc.HeaderText = "CuentaBancariaTransfBanc"
        Me.CuentaBancariaTransfBanc.Name = "CuentaBancariaTransfBanc"
        Me.CuentaBancariaTransfBanc.Visible = False
        '
        'IdProvincia
        '
        Me.IdProvincia.DataPropertyName = "IdProvincia"
        Me.IdProvincia.HeaderText = "IdProvincia"
        Me.IdProvincia.Name = "IdProvincia"
        Me.IdProvincia.Visible = False
        '
        'IdActividad
        '
        Me.IdActividad.DataPropertyName = "IdActividad"
        Me.IdActividad.HeaderText = "IdActividad"
        Me.IdActividad.Name = "IdActividad"
        Me.IdActividad.Visible = False
        '
        'Percepciones
        '
        Me.Percepciones.DataPropertyName = "Percepciones"
        Me.Percepciones.HeaderText = "Percepciones"
        Me.Percepciones.Name = "Percepciones"
        Me.Percepciones.Visible = False
        '
        'MercDespachada
        '
        Me.MercDespachada.DataPropertyName = "MercDespachada"
        Me.MercDespachada.HeaderText = "MercDespachada"
        Me.MercDespachada.Name = "MercDespachada"
        Me.MercDespachada.Visible = False
        '
        'PantallaOrigen
        '
        Me.PantallaOrigen.DataPropertyName = "PantallaOrigen"
        Me.PantallaOrigen.HeaderText = "PantallaOrigen"
        Me.PantallaOrigen.Name = "PantallaOrigen"
        Me.PantallaOrigen.Visible = False
        '
        'ReemplazaComprobante
        '
        Me.ReemplazaComprobante.DataPropertyName = "ReemplazaComprobante"
        Me.ReemplazaComprobante.HeaderText = "ReemplazaComprobante"
        Me.ReemplazaComprobante.Name = "ReemplazaComprobante"
        Me.ReemplazaComprobante.Visible = False
        '
        'SaldoActualCtaCte
        '
        Me.SaldoActualCtaCte.DataPropertyName = "SaldoActualCtaCte"
        Me.SaldoActualCtaCte.HeaderText = "SaldoActualCtaCte"
        Me.SaldoActualCtaCte.Name = "SaldoActualCtaCte"
        Me.SaldoActualCtaCte.Visible = False
        '
        'FechaEnvio
        '
        Me.FechaEnvio.DataPropertyName = "FechaEnvio"
        Me.FechaEnvio.HeaderText = "FechaEnvio"
        Me.FechaEnvio.Name = "FechaEnvio"
        Me.FechaEnvio.Visible = False
        '
        'NumeroReparto
        '
        Me.NumeroReparto.DataPropertyName = "NumeroReparto"
        Me.NumeroReparto.HeaderText = "NumeroReparto"
        Me.NumeroReparto.Name = "NumeroReparto"
        Me.NumeroReparto.Visible = False
        '
        'FechaRendicion
        '
        Me.FechaRendicion.DataPropertyName = "FechaRendicion"
        Me.FechaRendicion.HeaderText = "FechaRendicion"
        Me.FechaRendicion.Name = "FechaRendicion"
        Me.FechaRendicion.Visible = False
        '
        'FechaActualizacion
        '
        Me.FechaActualizacion.DataPropertyName = "FechaActualizacion"
        Me.FechaActualizacion.HeaderText = "FechaActualizacion"
        Me.FechaActualizacion.Name = "FechaActualizacion"
        Me.FechaActualizacion.Visible = False
        '
        'Direccion
        '
        Me.Direccion.DataPropertyName = "Direccion"
        Me.Direccion.HeaderText = "Direccion"
        Me.Direccion.Name = "Direccion"
        Me.Direccion.Visible = False
        '
        'IdLocalidad
        '
        Me.IdLocalidad.DataPropertyName = "IdLocalidad"
        Me.IdLocalidad.HeaderText = "IdLocalidad"
        Me.IdLocalidad.Name = "IdLocalidad"
        Me.IdLocalidad.Visible = False
        '
        'DescripcionFormaPago
        '
        Me.DescripcionFormaPago.DataPropertyName = "DescripcionFormaPago"
        Me.DescripcionFormaPago.HeaderText = "Forma de Pago"
        Me.DescripcionFormaPago.Name = "DescripcionFormaPago"
        Me.DescripcionFormaPago.Width = 95
        '
        'IdProveedor
        '
        Me.IdProveedor.DataPropertyName = "IdProveedor"
        Me.IdProveedor.HeaderText = "IdProveedor"
        Me.IdProveedor.Name = "IdProveedor"
        Me.IdProveedor.Visible = False
        '
        'Proveedor
        '
        Me.Proveedor.DataPropertyName = "Proveedor"
        Me.Proveedor.HeaderText = "Proveedor"
        Me.Proveedor.Name = "Proveedor"
        '
        'Localidad
        '
        Me.Localidad.DataPropertyName = "Localidad"
        Me.Localidad.HeaderText = "Localidad"
        Me.Localidad.Name = "Localidad"
        Me.Localidad.Visible = False
        '
        'IdCategoria
        '
        Me.IdCategoria.DataPropertyName = "IdCategoria"
        Me.IdCategoria.HeaderText = "IdCategoria"
        Me.IdCategoria.Name = "IdCategoria"
        Me.IdCategoria.Visible = False
        '
        'IdPlanCuenta
        '
        Me.IdPlanCuenta.DataPropertyName = "IdPlanCuenta"
        Me.IdPlanCuenta.HeaderText = "IdPlanCuenta"
        Me.IdPlanCuenta.Name = "IdPlanCuenta"
        Me.IdPlanCuenta.Visible = False
        '
        'IdAsiento
        '
        Me.IdAsiento.DataPropertyName = "IdAsiento"
        Me.IdAsiento.HeaderText = "IdAsiento"
        Me.IdAsiento.Name = "IdAsiento"
        Me.IdAsiento.Visible = False
        '
        'CodigoErrorAfip
        '
        Me.CodigoErrorAfip.DataPropertyName = "CodigoErrorAfip"
        Me.CodigoErrorAfip.HeaderText = "CodigoErrorAfip"
        Me.CodigoErrorAfip.Name = "CodigoErrorAfip"
        Me.CodigoErrorAfip.Visible = False
        '
        'CantidadProductos
        '
        Me.CantidadProductos.DataPropertyName = "CantidadProductos"
        Me.CantidadProductos.HeaderText = "CantidadProductos"
        Me.CantidadProductos.Name = "CantidadProductos"
        Me.CantidadProductos.Visible = False
        '
        'TotalImpuestoInterno
        '
        Me.TotalImpuestoInterno.DataPropertyName = "TotalImpuestoInterno"
        Me.TotalImpuestoInterno.HeaderText = "TotalImpuestoInterno"
        Me.TotalImpuestoInterno.Name = "TotalImpuestoInterno"
        Me.TotalImpuestoInterno.Visible = False
        '
        'NumeroOrdenCompra
        '
        Me.NumeroOrdenCompra.DataPropertyName = "NumeroOrdenCompra"
        DataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.NumeroOrdenCompra.DefaultCellStyle = DataGridViewCellStyle9
        Me.NumeroOrdenCompra.HeaderText = "Orden Compra"
        Me.NumeroOrdenCompra.Name = "NumeroOrdenCompra"
        Me.NumeroOrdenCompra.Width = 68
        '
        'CodigoClienteVinculado
        '
        Me.CodigoClienteVinculado.DataPropertyName = "CodigoClienteVinculado"
        DataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.CodigoClienteVinculado.DefaultCellStyle = DataGridViewCellStyle10
        Me.CodigoClienteVinculado.HeaderText = "Código Vinculado"
        Me.CodigoClienteVinculado.Name = "CodigoClienteVinculado"
        '
        'NombreClienteVinculado
        '
        Me.NombreClienteVinculado.DataPropertyName = "NombreClienteVinculado"
        Me.NombreClienteVinculado.HeaderText = "Cliente Vinculado"
        Me.NombreClienteVinculado.Name = "NombreClienteVinculado"
        Me.NombreClienteVinculado.Width = 200
        '
        'PedidosPendientesAyuda
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(980, 513)
        Me.Controls.Add(Me.chbTodos)
        Me.Controls.Add(Me.txtTotal)
        Me.Controls.Add(Me.lblTotal)
        Me.Controls.Add(Me.stsStado)
        Me.Controls.Add(Me.btnCancelar)
        Me.Controls.Add(Me.btnAceptar)
        Me.Controls.Add(Me.dgvDetalle)
        Me.Controls.Add(Me.grbPendientes)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "PedidosPendientesAyuda"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Ayuda de Pedidos a Invocar"
        Me.grbPendientes.ResumeLayout(False)
        Me.grbPendientes.PerformLayout()
        CType(Me.dgvDetalle, System.ComponentModel.ISupportInitialize).EndInit()
        Me.stsStado.ResumeLayout(False)
        Me.stsStado.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents grbPendientes As System.Windows.Forms.GroupBox
   Friend WithEvents dtpHasta As Eniac.Controles.DateTimePicker
   Friend WithEvents lblHasta As Eniac.Controles.Label
   Friend WithEvents dtpDesde As Eniac.Controles.DateTimePicker
   Friend WithEvents lblDesde As Eniac.Controles.Label
   Friend WithEvents dgvDetalle As Eniac.Controles.DataGridView
   Friend WithEvents Label1 As Eniac.Controles.Label
   Friend WithEvents Label2 As Eniac.Controles.Label
   Friend WithEvents btnCancelar As Eniac.Controles.Button
   Friend WithEvents btnAceptar As Eniac.Controles.Button
   Protected Friend WithEvents stsStado As System.Windows.Forms.StatusStrip
   Protected Friend WithEvents tssInfo As System.Windows.Forms.ToolStripStatusLabel
   Protected Friend WithEvents tspBarra As System.Windows.Forms.ToolStripProgressBar
   Protected WithEvents tssRegistros As System.Windows.Forms.ToolStripStatusLabel
   Friend WithEvents txtTotal As Eniac.Controles.TextBox
   Friend WithEvents lblTotal As Eniac.Controles.Label
   Friend WithEvents btnBuscar As Eniac.Controles.Button
   Friend WithEvents chkMesCompleto As Eniac.Controles.CheckBox
   Friend WithEvents chbTodos As Eniac.Controles.CheckBox
   Friend WithEvents bscCodigoCliente As Eniac.Controles.Buscador
   Friend WithEvents lblCodigoCliente As Eniac.Controles.Label
   Friend WithEvents bscCliente As Eniac.Controles.Buscador
   Friend WithEvents lblNombre As Eniac.Controles.Label
   Friend WithEvents chbCliente As Eniac.Controles.CheckBox
   Friend WithEvents clbTiposComprobantes As Eniac.Controles.CheckedListBox
   Friend WithEvents chbOrdenCompra As Eniac.Controles.CheckBox
   Friend WithEvents txtOrdenCompra As Eniac.Controles.TextBox
    Friend WithEvents Check As DataGridViewCheckBoxColumn
    Friend WithEvents Fecha As DataGridViewTextBoxColumn
    Friend WithEvents IdTipoComprobante As DataGridViewTextBoxColumn
    Friend WithEvents facIdSucursal As DataGridViewTextBoxColumn
    Friend WithEvents TipoComprobanteDescripcion As DataGridViewTextBoxColumn
    Friend WithEvents LetraComprobante As DataGridViewTextBoxColumn
    Friend WithEvents CentroEmisor As DataGridViewTextBoxColumn
    Friend WithEvents NumeroComprobante As DataGridViewTextBoxColumn
    Friend WithEvents Kilos As DataGridViewTextBoxColumn
    Friend WithEvents Total As DataGridViewTextBoxColumn
    Friend WithEvents Usuario As DataGridViewTextBoxColumn
    Friend WithEvents facObservacion As DataGridViewTextBoxColumn
    Friend WithEvents LetraCliente As DataGridViewTextBoxColumn
    Friend WithEvents facPassword As DataGridViewTextBoxColumn
    Friend WithEvents facTipoComprobante As DataGridViewTextBoxColumn
    Friend WithEvents facImpresora As DataGridViewTextBoxColumn
    Friend WithEvents facTotalImpuestos As DataGridViewTextBoxColumn
    Friend WithEvents facCliente As DataGridViewTextBoxColumn
    Friend WithEvents facPorcentajeIva As DataGridViewTextBoxColumn
    Friend WithEvents facVendedor As DataGridViewTextBoxColumn
    Friend WithEvents facFormaPago As DataGridViewTextBoxColumn
    Friend WithEvents facSubTotal As DataGridViewTextBoxColumn
    Friend WithEvents facDescuentoRecargo As DataGridViewTextBoxColumn
    Friend WithEvents facDescuentoRecargoPorc As DataGridViewTextBoxColumn
    Friend WithEvents ImporteBruto As DataGridViewTextBoxColumn
    Friend WithEvents CuentaCorriente As DataGridViewTextBoxColumn
    Friend WithEvents IdEstadoComprobante As DataGridViewTextBoxColumn
    Friend WithEvents ImporteNoGravado As DataGridViewTextBoxColumn
    Friend WithEvents ImportePesos As DataGridViewTextBoxColumn
    Friend WithEvents ImporteTickets As DataGridViewTextBoxColumn
    Friend WithEvents ImporteTarjetas As DataGridViewTextBoxColumn
    Friend WithEvents ImporteCheques As DataGridViewTextBoxColumn
    Friend WithEvents NumeroPlanilla As DataGridViewTextBoxColumn
    Friend WithEvents NumeroMovimiento As DataGridViewTextBoxColumn
    Friend WithEvents TipoComprobanteFact As DataGridViewTextBoxColumn
    Friend WithEvents LetraFact As DataGridViewTextBoxColumn
    Friend WithEvents CentroEmisorFact As DataGridViewTextBoxColumn
    Friend WithEvents NumeroComprobanteFact As DataGridViewTextBoxColumn
    Friend WithEvents CategoriaFiscal As DataGridViewTextBoxColumn
    Friend WithEvents Bultos As DataGridViewTextBoxColumn
    Friend WithEvents ValorDeclarado As DataGridViewTextBoxColumn
    Friend WithEvents Transportista As DataGridViewTextBoxColumn
    Friend WithEvents NumeroLote As DataGridViewTextBoxColumn
    Friend WithEvents TotalIVA As DataGridViewTextBoxColumn
    Friend WithEvents CantidadInvocados As DataGridViewTextBoxColumn
    Friend WithEvents CantidadLotes As DataGridViewTextBoxColumn
    Friend WithEvents AFIPCAE As DataGridViewTextBoxColumn
    Friend WithEvents TotalImporteExento As DataGridViewTextBoxColumn
    Friend WithEvents TotalTributos As DataGridViewTextBoxColumn
    Friend WithEvents ConceptoDelComprobante As DataGridViewTextBoxColumn
    Friend WithEvents AFIPIdTipoComprobante As DataGridViewTextBoxColumn
    Friend WithEvents Utilidad As DataGridViewTextBoxColumn
    Friend WithEvents FechaTransmisionAFIP As DataGridViewTextBoxColumn
    Friend WithEvents CotizacionDolar As DataGridViewTextBoxColumn
    Friend WithEvents ComisionVendedor As DataGridViewTextBoxColumn
    Friend WithEvents IdCaja As DataGridViewTextBoxColumn
    Friend WithEvents Periodo As DataGridViewTextBoxColumn
    Friend WithEvents GrabaAutomatico As DataGridViewTextBoxColumn
    Friend WithEvents EsMultipleRubro As DataGridViewTextBoxColumn
    Friend WithEvents TablaContabilidad As DataGridViewTextBoxColumn
    Friend WithEvents ImporteACtaCte As DataGridViewTextBoxColumn
    Friend WithEvents ImporteTransfBancaria As DataGridViewTextBoxColumn
    Friend WithEvents CuentaBancariaTransfBanc As DataGridViewTextBoxColumn
    Friend WithEvents IdProvincia As DataGridViewTextBoxColumn
    Friend WithEvents IdActividad As DataGridViewTextBoxColumn
    Friend WithEvents Percepciones As DataGridViewTextBoxColumn
    Friend WithEvents MercDespachada As DataGridViewTextBoxColumn
    Friend WithEvents PantallaOrigen As DataGridViewTextBoxColumn
    Friend WithEvents ReemplazaComprobante As DataGridViewTextBoxColumn
    Friend WithEvents SaldoActualCtaCte As DataGridViewTextBoxColumn
    Friend WithEvents FechaEnvio As DataGridViewTextBoxColumn
    Friend WithEvents NumeroReparto As DataGridViewTextBoxColumn
    Friend WithEvents FechaRendicion As DataGridViewTextBoxColumn
    Friend WithEvents FechaActualizacion As DataGridViewTextBoxColumn
    Friend WithEvents Direccion As DataGridViewTextBoxColumn
    Friend WithEvents IdLocalidad As DataGridViewTextBoxColumn
    Friend WithEvents DescripcionFormaPago As DataGridViewTextBoxColumn
    Friend WithEvents IdProveedor As DataGridViewTextBoxColumn
    Friend WithEvents Proveedor As DataGridViewTextBoxColumn
    Friend WithEvents Localidad As DataGridViewTextBoxColumn
    Friend WithEvents IdCategoria As DataGridViewTextBoxColumn
    Friend WithEvents IdPlanCuenta As DataGridViewTextBoxColumn
    Friend WithEvents IdAsiento As DataGridViewTextBoxColumn
    Friend WithEvents CodigoErrorAfip As DataGridViewTextBoxColumn
    Friend WithEvents CantidadProductos As DataGridViewTextBoxColumn
    Friend WithEvents TotalImpuestoInterno As DataGridViewTextBoxColumn
    Friend WithEvents NumeroOrdenCompra As DataGridViewTextBoxColumn
    Friend WithEvents CodigoClienteVinculado As DataGridViewTextBoxColumn
    Friend WithEvents NombreClienteVinculado As DataGridViewTextBoxColumn
End Class
