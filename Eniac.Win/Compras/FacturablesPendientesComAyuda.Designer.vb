<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FacturablesPendientesComAyuda
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
      Me.grbPendientes = New System.Windows.Forms.GroupBox()
      Me.cmbInvocados = New Eniac.Controles.ComboBox()
      Me.lblInvocados = New Eniac.Controles.Label()
        Me.cmbCentroCosto = New Eniac.Controles.ComboBox()
        Me.bscCodigoProveedor = New Eniac.Controles.Buscador()
        Me.lblCodigoProveedor = New Eniac.Controles.Label()
        Me.bscProveedor = New Eniac.Controles.Buscador()
        Me.lblNombreProveedor = New Eniac.Controles.Label()
        Me.clbTiposComprobantes = New Eniac.Controles.CheckedListBox()
        Me.chbProveedor = New Eniac.Controles.CheckBox()
        Me.chkMesCompleto = New Eniac.Controles.CheckBox()
        Me.btnBuscar = New Eniac.Controles.Button()
        Me.Label2 = New Eniac.Controles.Label()
        Me.Label1 = New Eniac.Controles.Label()
        Me.dtpHasta = New Eniac.Controles.DateTimePicker()
        Me.lblHasta = New Eniac.Controles.Label()
        Me.dtpDesde = New Eniac.Controles.DateTimePicker()
        Me.lblDesde = New Eniac.Controles.Label()
        Me.chbCentroCosto = New Eniac.Controles.CheckBox()
        Me.dgvDetalle = New Eniac.Controles.DataGridView()
        Me.Check = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.Fecha = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.NombreProveedor = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.IdTipoComprobante = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TipoComprobanteDescripcion = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Letra = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CentroEmisor = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.NumeroComprobante = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Total = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.facObservacion = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.facIdSucursal = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.LetraCliente = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.facUsuario = New System.Windows.Forms.DataGridViewTextBoxColumn()
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
        Me.CuentaCorrienteProv = New System.Windows.Forms.DataGridViewTextBoxColumn()
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
        Me.TotalIVA = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CantidadInvocados = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.IdCaja = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Periodo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ImporteACtaCte = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ImporteTransfBancaria = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CuentaBancariaTransfBanc = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Neto210 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Neto105 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Neto270 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.NetoNoGravado = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.IVA210 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.IVA105 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.IVA270 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Bruto210 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Bruto105 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Bruto270 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.BrutoNoGravado = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PercepcionIVA = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PercepcionIB = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PercepcionGanancias = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PercepcionVarias = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Comprador = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Rubro = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.btnCancelar = New Eniac.Controles.Button()
        Me.btnAceptar = New Eniac.Controles.Button()
        Me.stsStado = New System.Windows.Forms.StatusStrip()
        Me.tssInfo = New System.Windows.Forms.ToolStripStatusLabel()
        Me.tspBarra = New System.Windows.Forms.ToolStripProgressBar()
        Me.tssRegistros = New System.Windows.Forms.ToolStripStatusLabel()
        Me.txtTotal = New Eniac.Controles.TextBox()
        Me.lblTotal = New Eniac.Controles.Label()
        Me.chbTodos = New Eniac.Controles.CheckBox()
        Me.chbSoloCopiar = New System.Windows.Forms.CheckBox()
        Me.grbPendientes.SuspendLayout()
        CType(Me.dgvDetalle, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.stsStado.SuspendLayout()
        Me.SuspendLayout()
        '
        'grbPendientes
        '
        Me.grbPendientes.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grbPendientes.Controls.Add(Me.cmbInvocados)
        Me.grbPendientes.Controls.Add(Me.lblInvocados)
        Me.grbPendientes.Controls.Add(Me.cmbCentroCosto)
        Me.grbPendientes.Controls.Add(Me.bscCodigoProveedor)
        Me.grbPendientes.Controls.Add(Me.bscProveedor)
        Me.grbPendientes.Controls.Add(Me.lblCodigoProveedor)
        Me.grbPendientes.Controls.Add(Me.lblNombreProveedor)
        Me.grbPendientes.Controls.Add(Me.clbTiposComprobantes)
        Me.grbPendientes.Controls.Add(Me.chbProveedor)
        Me.grbPendientes.Controls.Add(Me.chkMesCompleto)
        Me.grbPendientes.Controls.Add(Me.btnBuscar)
        Me.grbPendientes.Controls.Add(Me.Label2)
        Me.grbPendientes.Controls.Add(Me.Label1)
        Me.grbPendientes.Controls.Add(Me.dtpHasta)
        Me.grbPendientes.Controls.Add(Me.dtpDesde)
        Me.grbPendientes.Controls.Add(Me.lblHasta)
        Me.grbPendientes.Controls.Add(Me.lblDesde)
        Me.grbPendientes.Controls.Add(Me.chbCentroCosto)
        Me.grbPendientes.Location = New System.Drawing.Point(12, 5)
        Me.grbPendientes.Name = "grbPendientes"
        Me.grbPendientes.Size = New System.Drawing.Size(903, 119)
        Me.grbPendientes.TabIndex = 0
        Me.grbPendientes.TabStop = False
        '
        'cmbInvocados
        '
        Me.cmbInvocados.BindearPropiedadControl = "SelectedValue"
        Me.cmbInvocados.BindearPropiedadEntidad = "MedioComunicacionNovedad.IdMedioComunicacionNovedad"
        Me.cmbInvocados.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbInvocados.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbInvocados.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbInvocados.FormattingEnabled = True
        Me.cmbInvocados.IsPK = False
        Me.cmbInvocados.IsRequired = False
        Me.cmbInvocados.Key = Nothing
        Me.cmbInvocados.LabelAsoc = Nothing
        Me.cmbInvocados.Location = New System.Drawing.Point(84, 53)
        Me.cmbInvocados.Name = "cmbInvocados"
        Me.cmbInvocados.Size = New System.Drawing.Size(89, 21)
        Me.cmbInvocados.TabIndex = 25
        '
        'lblInvocados
        '
        Me.lblInvocados.AutoSize = True
        Me.lblInvocados.LabelAsoc = Nothing
        Me.lblInvocados.Location = New System.Drawing.Point(10, 57)
        Me.lblInvocados.Name = "lblInvocados"
        Me.lblInvocados.Size = New System.Drawing.Size(57, 13)
        Me.lblInvocados.TabIndex = 24
        Me.lblInvocados.Text = "Invocados"
        '
        'cmbCentroCosto
        '
        Me.cmbCentroCosto.BindearPropiedadControl = "SelectedValue"
        Me.cmbCentroCosto.BindearPropiedadEntidad = "IdPlanCuenta"
        Me.cmbCentroCosto.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbCentroCosto.Enabled = False
        Me.cmbCentroCosto.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbCentroCosto.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbCentroCosto.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbCentroCosto.FormattingEnabled = True
        Me.cmbCentroCosto.IsPK = False
        Me.cmbCentroCosto.IsRequired = True
        Me.cmbCentroCosto.Key = Nothing
        Me.cmbCentroCosto.LabelAsoc = Nothing
        Me.cmbCentroCosto.Location = New System.Drawing.Point(288, 53)
        Me.cmbCentroCosto.Name = "cmbCentroCosto"
        Me.cmbCentroCosto.Size = New System.Drawing.Size(172, 21)
        Me.cmbCentroCosto.TabIndex = 23
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
        Me.bscCodigoProveedor.LabelAsoc = Me.lblCodigoProveedor
        Me.bscCodigoProveedor.Location = New System.Drawing.Point(85, 91)
        Me.bscCodigoProveedor.MaxLengh = "32767"
        Me.bscCodigoProveedor.Name = "bscCodigoProveedor"
        Me.bscCodigoProveedor.Permitido = True
        Me.bscCodigoProveedor.Selecciono = False
        Me.bscCodigoProveedor.Size = New System.Drawing.Size(90, 20)
        Me.bscCodigoProveedor.TabIndex = 17
        Me.bscCodigoProveedor.Titulo = Nothing
        Me.bscCodigoProveedor.Visible = False
        '
        'lblCodigoProveedor
        '
        Me.lblCodigoProveedor.AutoSize = True
        Me.lblCodigoProveedor.LabelAsoc = Nothing
        Me.lblCodigoProveedor.Location = New System.Drawing.Point(85, 78)
        Me.lblCodigoProveedor.Name = "lblCodigoProveedor"
        Me.lblCodigoProveedor.Size = New System.Drawing.Size(40, 13)
        Me.lblCodigoProveedor.TabIndex = 20
        Me.lblCodigoProveedor.Text = "Código"
        Me.lblCodigoProveedor.Visible = False
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
        Me.bscProveedor.LabelAsoc = Me.lblNombreProveedor
        Me.bscProveedor.Location = New System.Drawing.Point(178, 91)
        Me.bscProveedor.Margin = New System.Windows.Forms.Padding(4)
        Me.bscProveedor.MaxLengh = "32767"
        Me.bscProveedor.Name = "bscProveedor"
        Me.bscProveedor.Permitido = True
        Me.bscProveedor.Selecciono = False
        Me.bscProveedor.Size = New System.Drawing.Size(282, 20)
        Me.bscProveedor.TabIndex = 19
        Me.bscProveedor.Titulo = Nothing
        Me.bscProveedor.Visible = False
        '
        'lblNombreProveedor
        '
        Me.lblNombreProveedor.AutoSize = True
        Me.lblNombreProveedor.LabelAsoc = Nothing
        Me.lblNombreProveedor.Location = New System.Drawing.Point(175, 78)
        Me.lblNombreProveedor.Name = "lblNombreProveedor"
        Me.lblNombreProveedor.Size = New System.Drawing.Size(44, 13)
        Me.lblNombreProveedor.TabIndex = 21
        Me.lblNombreProveedor.Text = "Nombre"
        Me.lblNombreProveedor.Visible = False
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
        Me.clbTiposComprobantes.Location = New System.Drawing.Point(472, 40)
        Me.clbTiposComprobantes.MultiColumn = True
        Me.clbTiposComprobantes.Name = "clbTiposComprobantes"
        Me.clbTiposComprobantes.Size = New System.Drawing.Size(341, 64)
        Me.clbTiposComprobantes.TabIndex = 7
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
        Me.chbProveedor.Location = New System.Drawing.Point(13, 92)
        Me.chbProveedor.Name = "chbProveedor"
        Me.chbProveedor.Size = New System.Drawing.Size(75, 17)
        Me.chbProveedor.TabIndex = 8
        Me.chbProveedor.Text = "Proveedor"
        Me.chbProveedor.UseVisualStyleBackColor = True
        Me.chbProveedor.Visible = False
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
        Me.chkMesCompleto.Location = New System.Drawing.Point(12, 24)
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
        Me.btnBuscar.Location = New System.Drawing.Point(816, 50)
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
        Me.Label2.Location = New System.Drawing.Point(233, 7)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(91, 13)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Fecha de Emisión"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.LabelAsoc = Nothing
        Me.Label1.Location = New System.Drawing.Point(468, 24)
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
        Me.dtpHasta.Location = New System.Drawing.Point(306, 22)
        Me.dtpHasta.Name = "dtpHasta"
        Me.dtpHasta.Size = New System.Drawing.Size(95, 20)
        Me.dtpHasta.TabIndex = 5
        '
        'lblHasta
        '
        Me.lblHasta.AutoSize = True
        Me.lblHasta.LabelAsoc = Nothing
        Me.lblHasta.Location = New System.Drawing.Point(261, 26)
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
        Me.dtpDesde.Location = New System.Drawing.Point(156, 22)
        Me.dtpDesde.Name = "dtpDesde"
        Me.dtpDesde.Size = New System.Drawing.Size(95, 20)
        Me.dtpDesde.TabIndex = 2
        '
        'lblDesde
        '
        Me.lblDesde.AutoSize = True
        Me.lblDesde.LabelAsoc = Nothing
        Me.lblDesde.Location = New System.Drawing.Point(115, 26)
        Me.lblDesde.Name = "lblDesde"
        Me.lblDesde.Size = New System.Drawing.Size(38, 13)
        Me.lblDesde.TabIndex = 1
        Me.lblDesde.Text = "Desde"
        '
        'chbCentroCosto
        '
        Me.chbCentroCosto.AutoSize = True
        Me.chbCentroCosto.BindearPropiedadControl = Nothing
        Me.chbCentroCosto.BindearPropiedadEntidad = Nothing
        Me.chbCentroCosto.ForeColorFocus = System.Drawing.Color.Red
        Me.chbCentroCosto.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbCentroCosto.IsPK = False
        Me.chbCentroCosto.IsRequired = False
        Me.chbCentroCosto.Key = Nothing
        Me.chbCentroCosto.LabelAsoc = Nothing
        Me.chbCentroCosto.Location = New System.Drawing.Point(181, 55)
        Me.chbCentroCosto.Name = "chbCentroCosto"
        Me.chbCentroCosto.Size = New System.Drawing.Size(107, 17)
        Me.chbCentroCosto.TabIndex = 22
        Me.chbCentroCosto.Text = "Centro de Costos"
        Me.chbCentroCosto.UseVisualStyleBackColor = True
        '
        'dgvDetalle
        '
        Me.dgvDetalle.AllowUserToAddRows = False
        Me.dgvDetalle.AllowUserToDeleteRows = False
        Me.dgvDetalle.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvDetalle.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvDetalle.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Check, Me.Fecha, Me.NombreProveedor, Me.IdTipoComprobante, Me.TipoComprobanteDescripcion, Me.Letra, Me.CentroEmisor, Me.NumeroComprobante, Me.Total, Me.facObservacion, Me.facIdSucursal, Me.LetraCliente, Me.facUsuario, Me.facPassword, Me.facTipoComprobante, Me.facImpresora, Me.facTotalImpuestos, Me.facCliente, Me.facPorcentajeIva, Me.facVendedor, Me.facFormaPago, Me.facSubTotal, Me.facDescuentoRecargo, Me.facDescuentoRecargoPorc, Me.ImporteBruto, Me.CuentaCorrienteProv, Me.IdEstadoComprobante, Me.ImporteNoGravado, Me.ImportePesos, Me.ImporteTickets, Me.ImporteTarjetas, Me.ImporteCheques, Me.NumeroPlanilla, Me.NumeroMovimiento, Me.TipoComprobanteFact, Me.LetraFact, Me.CentroEmisorFact, Me.NumeroComprobanteFact, Me.CategoriaFiscal, Me.TotalIVA, Me.CantidadInvocados, Me.IdCaja, Me.Periodo, Me.ImporteACtaCte, Me.ImporteTransfBancaria, Me.CuentaBancariaTransfBanc, Me.Neto210, Me.Neto105, Me.Neto270, Me.NetoNoGravado, Me.IVA210, Me.IVA105, Me.IVA270, Me.Bruto210, Me.Bruto105, Me.Bruto270, Me.BrutoNoGravado, Me.PercepcionIVA, Me.PercepcionIB, Me.PercepcionGanancias, Me.PercepcionVarias, Me.Comprador, Me.Rubro})
        Me.dgvDetalle.Location = New System.Drawing.Point(12, 134)
        Me.dgvDetalle.Name = "dgvDetalle"
        Me.dgvDetalle.RowHeadersVisible = False
        Me.dgvDetalle.RowHeadersWidth = 20
        Me.dgvDetalle.Size = New System.Drawing.Size(903, 305)
        Me.dgvDetalle.TabIndex = 1
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
        'NombreProveedor
        '
        Me.NombreProveedor.DataPropertyName = "NombreProveedor"
        Me.NombreProveedor.HeaderText = "Proveedor"
        Me.NombreProveedor.Name = "NombreProveedor"
        Me.NombreProveedor.Visible = False
        Me.NombreProveedor.Width = 180
        '
        'IdTipoComprobante
        '
        Me.IdTipoComprobante.DataPropertyName = "IdTipoComprobante"
        Me.IdTipoComprobante.HeaderText = "IdTipoComprobante"
        Me.IdTipoComprobante.Name = "IdTipoComprobante"
        Me.IdTipoComprobante.Visible = False
        '
        'TipoComprobanteDescripcion
        '
        Me.TipoComprobanteDescripcion.DataPropertyName = "TipoComprobanteDescripcion"
        Me.TipoComprobanteDescripcion.HeaderText = "Tipo Comprobante"
        Me.TipoComprobanteDescripcion.Name = "TipoComprobanteDescripcion"
        Me.TipoComprobanteDescripcion.ReadOnly = True
        Me.TipoComprobanteDescripcion.Width = 135
        '
        'Letra
        '
        Me.Letra.DataPropertyName = "Letra"
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.Letra.DefaultCellStyle = DataGridViewCellStyle2
        Me.Letra.HeaderText = "Letra"
        Me.Letra.Name = "Letra"
        Me.Letra.Width = 50
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
        'Total
        '
        Me.Total.DataPropertyName = "ImporteTotal"
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle5.Format = "N2"
        DataGridViewCellStyle5.NullValue = Nothing
        Me.Total.DefaultCellStyle = DataGridViewCellStyle5
        Me.Total.HeaderText = "Total"
        Me.Total.Name = "Total"
        Me.Total.ReadOnly = True
        Me.Total.Width = 75
        '
        'facObservacion
        '
        Me.facObservacion.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.facObservacion.DataPropertyName = "Observacion"
        Me.facObservacion.HeaderText = "Observacion"
        Me.facObservacion.Name = "facObservacion"
        '
        'facIdSucursal
        '
        Me.facIdSucursal.DataPropertyName = "IdSucursal"
        Me.facIdSucursal.HeaderText = "IdSucursal"
        Me.facIdSucursal.Name = "facIdSucursal"
        Me.facIdSucursal.Visible = False
        '
        'LetraCliente
        '
        Me.LetraCliente.DataPropertyName = "Letra"
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.LetraCliente.DefaultCellStyle = DataGridViewCellStyle6
        Me.LetraCliente.HeaderText = "LetraCliente"
        Me.LetraCliente.Name = "LetraCliente"
        Me.LetraCliente.Visible = False
        Me.LetraCliente.Width = 50
        '
        'facUsuario
        '
        Me.facUsuario.DataPropertyName = "Usuario"
        Me.facUsuario.HeaderText = "Usuario"
        Me.facUsuario.Name = "facUsuario"
        Me.facUsuario.Visible = False
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
        Me.facCliente.DataPropertyName = "Proveedor"
        Me.facCliente.HeaderText = "Proveedor"
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
        Me.facVendedor.DataPropertyName = "Comprador"
        Me.facVendedor.HeaderText = "Comprador"
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
        'CuentaCorrienteProv
        '
        Me.CuentaCorrienteProv.DataPropertyName = "CuentaCorrienteProv"
        Me.CuentaCorrienteProv.HeaderText = "CuentaCorrienteProv"
        Me.CuentaCorrienteProv.Name = "CuentaCorrienteProv"
        Me.CuentaCorrienteProv.Visible = False
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
        'IdCaja
        '
        Me.IdCaja.DataPropertyName = "IdCaja"
        Me.IdCaja.HeaderText = "IdCaja"
        Me.IdCaja.Name = "IdCaja"
        Me.IdCaja.Visible = False
        '
        'Periodo
        '
        Me.Periodo.DataPropertyName = "PeriodoFiscal"
        Me.Periodo.HeaderText = "PeriodoFiscal"
        Me.Periodo.Name = "Periodo"
        Me.Periodo.Visible = False
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
        'Neto210
        '
        Me.Neto210.DataPropertyName = "Neto210"
        Me.Neto210.HeaderText = "Neto210"
        Me.Neto210.Name = "Neto210"
        Me.Neto210.Visible = False
        '
        'Neto105
        '
        Me.Neto105.DataPropertyName = "Neto105"
        Me.Neto105.HeaderText = "Neto105"
        Me.Neto105.Name = "Neto105"
        Me.Neto105.Visible = False
        '
        'Neto270
        '
        Me.Neto270.DataPropertyName = "Neto270"
        Me.Neto270.HeaderText = "Neto270"
        Me.Neto270.Name = "Neto270"
        Me.Neto270.Visible = False
        '
        'NetoNoGravado
        '
        Me.NetoNoGravado.DataPropertyName = "NetoNoGravado"
        Me.NetoNoGravado.HeaderText = "NetoNoGravado"
        Me.NetoNoGravado.Name = "NetoNoGravado"
        Me.NetoNoGravado.Visible = False
        '
        'IVA210
        '
        Me.IVA210.DataPropertyName = "IVA210"
        Me.IVA210.HeaderText = "IVA210"
        Me.IVA210.Name = "IVA210"
        Me.IVA210.Visible = False
        '
        'IVA105
        '
        Me.IVA105.DataPropertyName = "IVA105"
        Me.IVA105.HeaderText = "IVA105"
        Me.IVA105.Name = "IVA105"
        Me.IVA105.Visible = False
        '
        'IVA270
        '
        Me.IVA270.DataPropertyName = "IVA270"
        Me.IVA270.HeaderText = "IVA270"
        Me.IVA270.Name = "IVA270"
        Me.IVA270.Visible = False
        '
        'Bruto210
        '
        Me.Bruto210.DataPropertyName = "Bruto210"
        Me.Bruto210.HeaderText = "Bruto210"
        Me.Bruto210.Name = "Bruto210"
        Me.Bruto210.Visible = False
        '
        'Bruto105
        '
        Me.Bruto105.DataPropertyName = "Bruto105"
        Me.Bruto105.HeaderText = "Bruto105"
        Me.Bruto105.Name = "Bruto105"
        Me.Bruto105.Visible = False
        '
        'Bruto270
        '
        Me.Bruto270.DataPropertyName = "Bruto270"
        Me.Bruto270.HeaderText = "Bruto270"
        Me.Bruto270.Name = "Bruto270"
        Me.Bruto270.Visible = False
        '
        'BrutoNoGravado
        '
        Me.BrutoNoGravado.DataPropertyName = "BrutoNoGravado"
        Me.BrutoNoGravado.HeaderText = "BrutoNoGravado"
        Me.BrutoNoGravado.Name = "BrutoNoGravado"
        Me.BrutoNoGravado.Visible = False
        '
        'PercepcionIVA
        '
        Me.PercepcionIVA.DataPropertyName = "PercepcionIVA"
        Me.PercepcionIVA.HeaderText = "PercepcionIVA"
        Me.PercepcionIVA.Name = "PercepcionIVA"
        Me.PercepcionIVA.Visible = False
        '
        'PercepcionIB
        '
        Me.PercepcionIB.DataPropertyName = "PercepcionIB"
        Me.PercepcionIB.HeaderText = "PercepcionIB"
        Me.PercepcionIB.Name = "PercepcionIB"
        Me.PercepcionIB.Visible = False
        '
        'PercepcionGanancias
        '
        Me.PercepcionGanancias.DataPropertyName = "PercepcionGanancias"
        Me.PercepcionGanancias.HeaderText = "PercepcionGanancias"
        Me.PercepcionGanancias.Name = "PercepcionGanancias"
        Me.PercepcionGanancias.Visible = False
        '
        'PercepcionVarias
        '
        Me.PercepcionVarias.DataPropertyName = "PercepcionVarias"
        Me.PercepcionVarias.HeaderText = "PercepcionVarias"
        Me.PercepcionVarias.Name = "PercepcionVarias"
        Me.PercepcionVarias.Visible = False
        '
        'Comprador
        '
        Me.Comprador.DataPropertyName = "Comprador"
        Me.Comprador.HeaderText = "Comprador"
        Me.Comprador.Name = "Comprador"
        Me.Comprador.Visible = False
        '
        'Rubro
        '
        Me.Rubro.DataPropertyName = "Rubro"
        Me.Rubro.HeaderText = "Rubro"
        Me.Rubro.Name = "Rubro"
        Me.Rubro.Visible = False
        '
        'btnCancelar
        '
        Me.btnCancelar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancelar.Image = Global.Eniac.Win.My.Resources.Resources.delete_24
        Me.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCancelar.Location = New System.Drawing.Point(831, 444)
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
        Me.btnAceptar.Location = New System.Drawing.Point(740, 444)
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
        Me.stsStado.Size = New System.Drawing.Size(927, 22)
        Me.stsStado.TabIndex = 7
        Me.stsStado.Text = "statusStrip1"
        '
        'tssInfo
        '
        Me.tssInfo.Name = "tssInfo"
        Me.tssInfo.Size = New System.Drawing.Size(848, 17)
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
        Me.txtTotal.Location = New System.Drawing.Point(527, 449)
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
        Me.lblTotal.Location = New System.Drawing.Point(479, 453)
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
        'chbSoloCopiar
        '
        Me.chbSoloCopiar.AutoSize = True
        Me.chbSoloCopiar.Location = New System.Drawing.Point(646, 451)
        Me.chbSoloCopiar.Name = "chbSoloCopiar"
        Me.chbSoloCopiar.Size = New System.Drawing.Size(80, 17)
        Me.chbSoloCopiar.TabIndex = 17
        Me.chbSoloCopiar.Text = "Solo Copiar"
        Me.chbSoloCopiar.UseVisualStyleBackColor = True
        '
        'FacturablesPendientesComAyuda
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(927, 513)
        Me.Controls.Add(Me.chbSoloCopiar)
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
        Me.Name = "FacturablesPendientesComAyuda"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Ayuda de Comprobantes a Invocar"
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
   Friend WithEvents chbProveedor As Eniac.Controles.CheckBox
   Friend WithEvents clbTiposComprobantes As Eniac.Controles.CheckedListBox
   Friend WithEvents bscCodigoProveedor As Eniac.Controles.Buscador
   Friend WithEvents lblCodigoProveedor As Eniac.Controles.Label
   Friend WithEvents bscProveedor As Eniac.Controles.Buscador
   Friend WithEvents lblNombreProveedor As Eniac.Controles.Label
   Friend WithEvents Check As System.Windows.Forms.DataGridViewCheckBoxColumn
   Friend WithEvents Fecha As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents NombreProveedor As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents IdTipoComprobante As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents TipoComprobanteDescripcion As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents Letra As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents CentroEmisor As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents NumeroComprobante As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents Total As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents facObservacion As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents facIdSucursal As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents LetraCliente As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents facUsuario As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents facPassword As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents facTipoComprobante As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents facImpresora As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents facTotalImpuestos As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents facCliente As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents facPorcentajeIva As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents facVendedor As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents facFormaPago As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents facSubTotal As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents facDescuentoRecargo As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents facDescuentoRecargoPorc As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents ImporteBruto As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents CuentaCorrienteProv As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents IdEstadoComprobante As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents ImporteNoGravado As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents ImportePesos As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents ImporteTickets As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents ImporteTarjetas As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents ImporteCheques As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents NumeroPlanilla As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents NumeroMovimiento As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents TipoComprobanteFact As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents LetraFact As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents CentroEmisorFact As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents NumeroComprobanteFact As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents CategoriaFiscal As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents TotalIVA As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents CantidadInvocados As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents IdCaja As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents Periodo As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents ImporteACtaCte As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents ImporteTransfBancaria As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents CuentaBancariaTransfBanc As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents Neto210 As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents Neto105 As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents Neto270 As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents NetoNoGravado As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents IVA210 As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents IVA105 As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents IVA270 As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents Bruto210 As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents Bruto105 As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents Bruto270 As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents BrutoNoGravado As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents PercepcionIVA As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents PercepcionIB As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents PercepcionGanancias As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents PercepcionVarias As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents Comprador As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents Rubro As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents chbSoloCopiar As System.Windows.Forms.CheckBox
   Friend WithEvents chbCentroCosto As Eniac.Controles.CheckBox
   Friend WithEvents cmbCentroCosto As Eniac.Controles.ComboBox
   Friend WithEvents cmbInvocados As Controles.ComboBox
   Friend WithEvents lblInvocados As Controles.Label
End Class
