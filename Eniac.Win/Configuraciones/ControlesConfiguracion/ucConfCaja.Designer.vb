<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ucConfCaja
   Inherits ucConfBase

   'UserControl overrides dispose to clean up the component list.
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
      Me.gpbOrdenarCobranzaPor = New System.Windows.Forms.GroupBox()
      Me.rbtOrdenarCobranzaPorVendedor = New System.Windows.Forms.RadioButton()
      Me.rbtOrdenarCobranzaPorFecha = New System.Windows.Forms.RadioButton()
      Me.grbCuentasdeCaja = New System.Windows.Forms.GroupBox()
      Me.lblCuentaCajaLiquidacionesTarjetas = New Eniac.Controles.Label()
      Me.txtCuentaCajaLiquidacionesTarjetas = New Eniac.Controles.TextBox()
      Me.txtCuentaCajaVentas = New Eniac.Controles.TextBox()
      Me.lblCuentaCajaVentas = New Eniac.Controles.Label()
      Me.lblCuentaCajaExtraccionesBancarias = New Eniac.Controles.Label()
      Me.txtCuentaCajaExtraccionesBancarias = New Eniac.Controles.TextBox()
      Me.lblCuentaCajaDepositoTarjeta = New Eniac.Controles.Label()
      Me.txtCuentaCajaRecibos = New Eniac.Controles.TextBox()
      Me.lblCuentaCajaRecibos = New Eniac.Controles.Label()
      Me.lblCuentaCajaMovimientoChequesSucursales = New Eniac.Controles.Label()
      Me.lblCuentaCajaTransfBancaria = New Eniac.Controles.Label()
      Me.txtCuentaCajaCompras = New Eniac.Controles.TextBox()
      Me.lblCuentaCajaCompras = New Eniac.Controles.Label()
      Me.lblCuentaCajaDeposito = New Eniac.Controles.Label()
      Me.txtCuentaCajaDepositoTarjetas = New Eniac.Controles.TextBox()
      Me.lblCuentaCajaPagoProveedores = New Eniac.Controles.Label()
      Me.txtCuentaCajaPagoProveedores = New Eniac.Controles.TextBox()
      Me.txtCuentaCajaDeposito = New Eniac.Controles.TextBox()
      Me.txtCuentaCajaMovCheques = New Eniac.Controles.TextBox()
      Me.txtCuentaCajaTransfBancaria = New Eniac.Controles.TextBox()
      Me.chbFechaPlanillaDelDia = New Eniac.Controles.CheckBox()
      Me.chbPermiteMovimientoSinSaldo = New Eniac.Controles.CheckBox()
      Me.chbCajaPlanillaMuestraVentasEnCtaCte = New Eniac.Controles.CheckBox()
      Me.chbCajaPlanillaMuestraProductosConAlerta = New Eniac.Controles.CheckBox()
      Me.chbCajaUtilizaSaldosDigitados = New Eniac.Controles.CheckBox()
      Me.chbCajaMostrarNCIndividual = New Eniac.Controles.CheckBox()
      Me.chbCajaAcumulaVentas = New Eniac.Controles.CheckBox()
      Me.pnlCierreCaja = New System.Windows.Forms.GroupBox()
      Me.cmbSucursalDestino = New Eniac.Controles.ComboBox()
      Me.lblSucursalDestino = New Eniac.Controles.Label()
      Me.cmbCajasDestino = New Eniac.Controles.ComboBox()
      Me.lblCajaDestino = New Eniac.Controles.Label()
      Me.cmbModoCierrePlanillaCaja = New Eniac.Controles.ComboBox()
      Me.lblModoCierrePlanillaCaja = New Eniac.Controles.Label()
      Me.chbCajaPredPorPC = New Eniac.Controles.CheckBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.chbNegativoImporteTickets = New Eniac.Controles.CheckBox()
        Me.chbNegativoImporteBancos = New Eniac.Controles.CheckBox()
        Me.chbNegativoImportePesos = New Eniac.Controles.CheckBox()
        Me.chbNegativoImporteDolares = New Eniac.Controles.CheckBox()
        Me.chbNegativoImporteTotal = New Eniac.Controles.CheckBox()
        Me.gpbOrdenarCobranzaPor.SuspendLayout()
        Me.grbCuentasdeCaja.SuspendLayout()
        Me.pnlCierreCaja.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'gpbOrdenarCobranzaPor
        '
        Me.gpbOrdenarCobranzaPor.Controls.Add(Me.rbtOrdenarCobranzaPorVendedor)
        Me.gpbOrdenarCobranzaPor.Controls.Add(Me.rbtOrdenarCobranzaPorFecha)
        Me.gpbOrdenarCobranzaPor.Location = New System.Drawing.Point(53, 226)
        Me.gpbOrdenarCobranzaPor.Name = "gpbOrdenarCobranzaPor"
        Me.gpbOrdenarCobranzaPor.Size = New System.Drawing.Size(350, 46)
        Me.gpbOrdenarCobranzaPor.TabIndex = 74
        Me.gpbOrdenarCobranzaPor.TabStop = False
        Me.gpbOrdenarCobranzaPor.Tag = "ORDENARCOBRANZAPOR"
        Me.gpbOrdenarCobranzaPor.Text = "Cobranza realizada ordenar por :"
        '
        'rbtOrdenarCobranzaPorVendedor
        '
        Me.rbtOrdenarCobranzaPorVendedor.AutoSize = True
        Me.rbtOrdenarCobranzaPorVendedor.Location = New System.Drawing.Point(183, 19)
        Me.rbtOrdenarCobranzaPorVendedor.Name = "rbtOrdenarCobranzaPorVendedor"
        Me.rbtOrdenarCobranzaPorVendedor.Size = New System.Drawing.Size(145, 17)
        Me.rbtOrdenarCobranzaPorVendedor.TabIndex = 2
        Me.rbtOrdenarCobranzaPorVendedor.TabStop = True
        Me.rbtOrdenarCobranzaPorVendedor.Tag = "Vendedor"
        Me.rbtOrdenarCobranzaPorVendedor.Text = "Vendedor / Comprobante"
        Me.rbtOrdenarCobranzaPorVendedor.UseVisualStyleBackColor = True
        '
        'rbtOrdenarCobranzaPorFecha
        '
        Me.rbtOrdenarCobranzaPorFecha.AutoSize = True
        Me.rbtOrdenarCobranzaPorFecha.Checked = True
        Me.rbtOrdenarCobranzaPorFecha.Location = New System.Drawing.Point(32, 19)
        Me.rbtOrdenarCobranzaPorFecha.Name = "rbtOrdenarCobranzaPorFecha"
        Me.rbtOrdenarCobranzaPorFecha.Size = New System.Drawing.Size(129, 17)
        Me.rbtOrdenarCobranzaPorFecha.TabIndex = 1
        Me.rbtOrdenarCobranzaPorFecha.TabStop = True
        Me.rbtOrdenarCobranzaPorFecha.Tag = "Fecha"
        Me.rbtOrdenarCobranzaPorFecha.Text = "Fecha / Comprobante"
        Me.rbtOrdenarCobranzaPorFecha.UseVisualStyleBackColor = True
        '
        'grbCuentasdeCaja
        '
        Me.grbCuentasdeCaja.Controls.Add(Me.lblCuentaCajaLiquidacionesTarjetas)
        Me.grbCuentasdeCaja.Controls.Add(Me.txtCuentaCajaLiquidacionesTarjetas)
        Me.grbCuentasdeCaja.Controls.Add(Me.txtCuentaCajaVentas)
        Me.grbCuentasdeCaja.Controls.Add(Me.lblCuentaCajaExtraccionesBancarias)
        Me.grbCuentasdeCaja.Controls.Add(Me.txtCuentaCajaExtraccionesBancarias)
        Me.grbCuentasdeCaja.Controls.Add(Me.lblCuentaCajaDepositoTarjeta)
        Me.grbCuentasdeCaja.Controls.Add(Me.txtCuentaCajaRecibos)
        Me.grbCuentasdeCaja.Controls.Add(Me.lblCuentaCajaMovimientoChequesSucursales)
        Me.grbCuentasdeCaja.Controls.Add(Me.lblCuentaCajaTransfBancaria)
        Me.grbCuentasdeCaja.Controls.Add(Me.txtCuentaCajaCompras)
        Me.grbCuentasdeCaja.Controls.Add(Me.lblCuentaCajaDeposito)
        Me.grbCuentasdeCaja.Controls.Add(Me.txtCuentaCajaDepositoTarjetas)
        Me.grbCuentasdeCaja.Controls.Add(Me.lblCuentaCajaPagoProveedores)
        Me.grbCuentasdeCaja.Controls.Add(Me.txtCuentaCajaPagoProveedores)
        Me.grbCuentasdeCaja.Controls.Add(Me.lblCuentaCajaCompras)
        Me.grbCuentasdeCaja.Controls.Add(Me.txtCuentaCajaDeposito)
        Me.grbCuentasdeCaja.Controls.Add(Me.lblCuentaCajaRecibos)
        Me.grbCuentasdeCaja.Controls.Add(Me.txtCuentaCajaMovCheques)
        Me.grbCuentasdeCaja.Controls.Add(Me.lblCuentaCajaVentas)
        Me.grbCuentasdeCaja.Controls.Add(Me.txtCuentaCajaTransfBancaria)
        Me.grbCuentasdeCaja.Location = New System.Drawing.Point(446, 14)
        Me.grbCuentasdeCaja.Name = "grbCuentasdeCaja"
        Me.grbCuentasdeCaja.Size = New System.Drawing.Size(401, 292)
        Me.grbCuentasdeCaja.TabIndex = 73
        Me.grbCuentasdeCaja.TabStop = False
        Me.grbCuentasdeCaja.Text = "Configuración de Cuentas De Caja"
        '
        'lblCuentaCajaLiquidacionesTarjetas
        '
        Me.lblCuentaCajaLiquidacionesTarjetas.AutoSize = True
        Me.lblCuentaCajaLiquidacionesTarjetas.LabelAsoc = Nothing
        Me.lblCuentaCajaLiquidacionesTarjetas.Location = New System.Drawing.Point(71, 264)
        Me.lblCuentaCajaLiquidacionesTarjetas.Name = "lblCuentaCajaLiquidacionesTarjetas"
        Me.lblCuentaCajaLiquidacionesTarjetas.Size = New System.Drawing.Size(298, 13)
        Me.lblCuentaCajaLiquidacionesTarjetas.TabIndex = 64
        Me.lblCuentaCajaLiquidacionesTarjetas.Text = "Define la cuenta para movimientos de Liquidación de Tarjetas"
        '
        'txtCuentaCajaLiquidacionesTarjetas
        '
        Me.txtCuentaCajaLiquidacionesTarjetas.BindearPropiedadControl = Nothing
        Me.txtCuentaCajaLiquidacionesTarjetas.BindearPropiedadEntidad = Nothing
        Me.txtCuentaCajaLiquidacionesTarjetas.ForeColorFocus = System.Drawing.Color.Red
        Me.txtCuentaCajaLiquidacionesTarjetas.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtCuentaCajaLiquidacionesTarjetas.Formato = ""
        Me.txtCuentaCajaLiquidacionesTarjetas.IsDecimal = False
        Me.txtCuentaCajaLiquidacionesTarjetas.IsNumber = True
        Me.txtCuentaCajaLiquidacionesTarjetas.IsPK = False
        Me.txtCuentaCajaLiquidacionesTarjetas.IsRequired = False
        Me.txtCuentaCajaLiquidacionesTarjetas.Key = ""
        Me.txtCuentaCajaLiquidacionesTarjetas.LabelAsoc = Me.lblCuentaCajaLiquidacionesTarjetas
        Me.txtCuentaCajaLiquidacionesTarjetas.Location = New System.Drawing.Point(19, 261)
        Me.txtCuentaCajaLiquidacionesTarjetas.MaxLength = 7
        Me.txtCuentaCajaLiquidacionesTarjetas.Name = "txtCuentaCajaLiquidacionesTarjetas"
        Me.txtCuentaCajaLiquidacionesTarjetas.Size = New System.Drawing.Size(35, 20)
        Me.txtCuentaCajaLiquidacionesTarjetas.TabIndex = 63
        Me.txtCuentaCajaLiquidacionesTarjetas.Tag = "CTACAJALIQUIDACIONTARJETA"
        Me.txtCuentaCajaLiquidacionesTarjetas.Text = "26"
        Me.txtCuentaCajaLiquidacionesTarjetas.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtCuentaCajaVentas
        '
        Me.txtCuentaCajaVentas.BindearPropiedadControl = Nothing
        Me.txtCuentaCajaVentas.BindearPropiedadEntidad = Nothing
        Me.txtCuentaCajaVentas.ForeColorFocus = System.Drawing.Color.Red
        Me.txtCuentaCajaVentas.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtCuentaCajaVentas.Formato = ""
        Me.txtCuentaCajaVentas.IsDecimal = False
        Me.txtCuentaCajaVentas.IsNumber = True
        Me.txtCuentaCajaVentas.IsPK = False
        Me.txtCuentaCajaVentas.IsRequired = False
        Me.txtCuentaCajaVentas.Key = ""
        Me.txtCuentaCajaVentas.LabelAsoc = Me.lblCuentaCajaVentas
        Me.txtCuentaCajaVentas.Location = New System.Drawing.Point(19, 28)
        Me.txtCuentaCajaVentas.MaxLength = 7
        Me.txtCuentaCajaVentas.Name = "txtCuentaCajaVentas"
        Me.txtCuentaCajaVentas.Size = New System.Drawing.Size(35, 20)
        Me.txtCuentaCajaVentas.TabIndex = 45
        Me.txtCuentaCajaVentas.Tag = ""
        Me.txtCuentaCajaVentas.Text = "1"
        Me.txtCuentaCajaVentas.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblCuentaCajaVentas
        '
        Me.lblCuentaCajaVentas.AutoSize = True
        Me.lblCuentaCajaVentas.LabelAsoc = Nothing
        Me.lblCuentaCajaVentas.Location = New System.Drawing.Point(71, 31)
        Me.lblCuentaCajaVentas.Name = "lblCuentaCajaVentas"
        Me.lblCuentaCajaVentas.Size = New System.Drawing.Size(221, 13)
        Me.lblCuentaCajaVentas.TabIndex = 51
        Me.lblCuentaCajaVentas.Text = "Define la cuenta para movimientos de Ventas"
        '
        'lblCuentaCajaExtraccionesBancarias
        '
        Me.lblCuentaCajaExtraccionesBancarias.AutoSize = True
        Me.lblCuentaCajaExtraccionesBancarias.LabelAsoc = Nothing
        Me.lblCuentaCajaExtraccionesBancarias.Location = New System.Drawing.Point(71, 238)
        Me.lblCuentaCajaExtraccionesBancarias.Name = "lblCuentaCajaExtraccionesBancarias"
        Me.lblCuentaCajaExtraccionesBancarias.Size = New System.Drawing.Size(299, 13)
        Me.lblCuentaCajaExtraccionesBancarias.TabIndex = 61
        Me.lblCuentaCajaExtraccionesBancarias.Text = "Define la cuenta para movimientos de Extracciones Bancarias"
        '
        'txtCuentaCajaExtraccionesBancarias
        '
        Me.txtCuentaCajaExtraccionesBancarias.BindearPropiedadControl = Nothing
        Me.txtCuentaCajaExtraccionesBancarias.BindearPropiedadEntidad = Nothing
        Me.txtCuentaCajaExtraccionesBancarias.ForeColorFocus = System.Drawing.Color.Red
        Me.txtCuentaCajaExtraccionesBancarias.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtCuentaCajaExtraccionesBancarias.Formato = ""
        Me.txtCuentaCajaExtraccionesBancarias.IsDecimal = False
        Me.txtCuentaCajaExtraccionesBancarias.IsNumber = True
        Me.txtCuentaCajaExtraccionesBancarias.IsPK = False
        Me.txtCuentaCajaExtraccionesBancarias.IsRequired = False
        Me.txtCuentaCajaExtraccionesBancarias.Key = ""
        Me.txtCuentaCajaExtraccionesBancarias.LabelAsoc = Me.lblCuentaCajaExtraccionesBancarias
        Me.txtCuentaCajaExtraccionesBancarias.Location = New System.Drawing.Point(19, 235)
        Me.txtCuentaCajaExtraccionesBancarias.MaxLength = 7
        Me.txtCuentaCajaExtraccionesBancarias.Name = "txtCuentaCajaExtraccionesBancarias"
        Me.txtCuentaCajaExtraccionesBancarias.Size = New System.Drawing.Size(35, 20)
        Me.txtCuentaCajaExtraccionesBancarias.TabIndex = 62
        Me.txtCuentaCajaExtraccionesBancarias.Tag = ""
        Me.txtCuentaCajaExtraccionesBancarias.Text = "26"
        Me.txtCuentaCajaExtraccionesBancarias.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblCuentaCajaDepositoTarjeta
        '
        Me.lblCuentaCajaDepositoTarjeta.AutoSize = True
        Me.lblCuentaCajaDepositoTarjeta.LabelAsoc = Nothing
        Me.lblCuentaCajaDepositoTarjeta.Location = New System.Drawing.Point(71, 212)
        Me.lblCuentaCajaDepositoTarjeta.Name = "lblCuentaCajaDepositoTarjeta"
        Me.lblCuentaCajaDepositoTarjeta.Size = New System.Drawing.Size(282, 13)
        Me.lblCuentaCajaDepositoTarjeta.TabIndex = 59
        Me.lblCuentaCajaDepositoTarjeta.Text = "Define la cuenta para movimientos de Tarjetas de Créditos"
        '
        'txtCuentaCajaRecibos
        '
        Me.txtCuentaCajaRecibos.BindearPropiedadControl = Nothing
        Me.txtCuentaCajaRecibos.BindearPropiedadEntidad = Nothing
        Me.txtCuentaCajaRecibos.ForeColorFocus = System.Drawing.Color.Red
        Me.txtCuentaCajaRecibos.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtCuentaCajaRecibos.Formato = ""
        Me.txtCuentaCajaRecibos.IsDecimal = False
        Me.txtCuentaCajaRecibos.IsNumber = True
        Me.txtCuentaCajaRecibos.IsPK = False
        Me.txtCuentaCajaRecibos.IsRequired = False
        Me.txtCuentaCajaRecibos.Key = ""
        Me.txtCuentaCajaRecibos.LabelAsoc = Me.lblCuentaCajaRecibos
        Me.txtCuentaCajaRecibos.Location = New System.Drawing.Point(19, 54)
        Me.txtCuentaCajaRecibos.MaxLength = 7
        Me.txtCuentaCajaRecibos.Name = "txtCuentaCajaRecibos"
        Me.txtCuentaCajaRecibos.Size = New System.Drawing.Size(35, 20)
        Me.txtCuentaCajaRecibos.TabIndex = 46
        Me.txtCuentaCajaRecibos.Tag = ""
        Me.txtCuentaCajaRecibos.Text = "2"
        Me.txtCuentaCajaRecibos.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblCuentaCajaRecibos
        '
        Me.lblCuentaCajaRecibos.AutoSize = True
        Me.lblCuentaCajaRecibos.LabelAsoc = Nothing
        Me.lblCuentaCajaRecibos.Location = New System.Drawing.Point(71, 57)
        Me.lblCuentaCajaRecibos.Name = "lblCuentaCajaRecibos"
        Me.lblCuentaCajaRecibos.Size = New System.Drawing.Size(227, 13)
        Me.lblCuentaCajaRecibos.TabIndex = 52
        Me.lblCuentaCajaRecibos.Text = "Define la cuenta para movimientos de Recibos"
        '
        'lblCuentaCajaMovimientoChequesSucursales
        '
        Me.lblCuentaCajaMovimientoChequesSucursales.AutoSize = True
        Me.lblCuentaCajaMovimientoChequesSucursales.LabelAsoc = Nothing
        Me.lblCuentaCajaMovimientoChequesSucursales.Location = New System.Drawing.Point(71, 187)
        Me.lblCuentaCajaMovimientoChequesSucursales.Name = "lblCuentaCajaMovimientoChequesSucursales"
        Me.lblCuentaCajaMovimientoChequesSucursales.Size = New System.Drawing.Size(312, 13)
        Me.lblCuentaCajaMovimientoChequesSucursales.TabIndex = 57
        Me.lblCuentaCajaMovimientoChequesSucursales.Text = "Define la cuenta para movimientos de Cheques entre Sucursales"
        '
        'lblCuentaCajaTransfBancaria
        '
        Me.lblCuentaCajaTransfBancaria.AutoSize = True
        Me.lblCuentaCajaTransfBancaria.LabelAsoc = Nothing
        Me.lblCuentaCajaTransfBancaria.Location = New System.Drawing.Point(71, 135)
        Me.lblCuentaCajaTransfBancaria.Name = "lblCuentaCajaTransfBancaria"
        Me.lblCuentaCajaTransfBancaria.Size = New System.Drawing.Size(308, 13)
        Me.lblCuentaCajaTransfBancaria.TabIndex = 56
        Me.lblCuentaCajaTransfBancaria.Text = "Define la cuenta para movimientos de Transferencias Bancarias"
        '
        'txtCuentaCajaCompras
        '
        Me.txtCuentaCajaCompras.BindearPropiedadControl = Nothing
        Me.txtCuentaCajaCompras.BindearPropiedadEntidad = Nothing
        Me.txtCuentaCajaCompras.ForeColorFocus = System.Drawing.Color.Red
        Me.txtCuentaCajaCompras.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtCuentaCajaCompras.Formato = ""
        Me.txtCuentaCajaCompras.IsDecimal = False
        Me.txtCuentaCajaCompras.IsNumber = True
        Me.txtCuentaCajaCompras.IsPK = False
        Me.txtCuentaCajaCompras.IsRequired = False
        Me.txtCuentaCajaCompras.Key = ""
        Me.txtCuentaCajaCompras.LabelAsoc = Me.lblCuentaCajaCompras
        Me.txtCuentaCajaCompras.Location = New System.Drawing.Point(19, 80)
        Me.txtCuentaCajaCompras.MaxLength = 7
        Me.txtCuentaCajaCompras.Name = "txtCuentaCajaCompras"
        Me.txtCuentaCajaCompras.Size = New System.Drawing.Size(35, 20)
        Me.txtCuentaCajaCompras.TabIndex = 47
        Me.txtCuentaCajaCompras.Tag = ""
        Me.txtCuentaCajaCompras.Text = "3"
        Me.txtCuentaCajaCompras.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblCuentaCajaCompras
        '
        Me.lblCuentaCajaCompras.AutoSize = True
        Me.lblCuentaCajaCompras.LabelAsoc = Nothing
        Me.lblCuentaCajaCompras.Location = New System.Drawing.Point(71, 83)
        Me.lblCuentaCajaCompras.Name = "lblCuentaCajaCompras"
        Me.lblCuentaCajaCompras.Size = New System.Drawing.Size(229, 13)
        Me.lblCuentaCajaCompras.TabIndex = 54
        Me.lblCuentaCajaCompras.Text = "Define la cuenta para movimientos de Compras"
        '
        'lblCuentaCajaDeposito
        '
        Me.lblCuentaCajaDeposito.AutoSize = True
        Me.lblCuentaCajaDeposito.LabelAsoc = Nothing
        Me.lblCuentaCajaDeposito.Location = New System.Drawing.Point(71, 161)
        Me.lblCuentaCajaDeposito.Name = "lblCuentaCajaDeposito"
        Me.lblCuentaCajaDeposito.Size = New System.Drawing.Size(285, 13)
        Me.lblCuentaCajaDeposito.TabIndex = 55
        Me.lblCuentaCajaDeposito.Text = "Define la cuenta para movimientos de Depositos Bancarios"
        '
        'txtCuentaCajaDepositoTarjetas
        '
        Me.txtCuentaCajaDepositoTarjetas.BindearPropiedadControl = Nothing
        Me.txtCuentaCajaDepositoTarjetas.BindearPropiedadEntidad = Nothing
        Me.txtCuentaCajaDepositoTarjetas.ForeColorFocus = System.Drawing.Color.Red
        Me.txtCuentaCajaDepositoTarjetas.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtCuentaCajaDepositoTarjetas.Formato = ""
        Me.txtCuentaCajaDepositoTarjetas.IsDecimal = False
        Me.txtCuentaCajaDepositoTarjetas.IsNumber = True
        Me.txtCuentaCajaDepositoTarjetas.IsPK = False
        Me.txtCuentaCajaDepositoTarjetas.IsRequired = False
        Me.txtCuentaCajaDepositoTarjetas.Key = ""
        Me.txtCuentaCajaDepositoTarjetas.LabelAsoc = Me.lblCuentaCajaDepositoTarjeta
        Me.txtCuentaCajaDepositoTarjetas.Location = New System.Drawing.Point(19, 209)
        Me.txtCuentaCajaDepositoTarjetas.MaxLength = 7
        Me.txtCuentaCajaDepositoTarjetas.Name = "txtCuentaCajaDepositoTarjetas"
        Me.txtCuentaCajaDepositoTarjetas.Size = New System.Drawing.Size(35, 20)
        Me.txtCuentaCajaDepositoTarjetas.TabIndex = 60
        Me.txtCuentaCajaDepositoTarjetas.Tag = ""
        Me.txtCuentaCajaDepositoTarjetas.Text = "8"
        Me.txtCuentaCajaDepositoTarjetas.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblCuentaCajaPagoProveedores
        '
        Me.lblCuentaCajaPagoProveedores.AutoSize = True
        Me.lblCuentaCajaPagoProveedores.LabelAsoc = Nothing
        Me.lblCuentaCajaPagoProveedores.Location = New System.Drawing.Point(71, 109)
        Me.lblCuentaCajaPagoProveedores.Name = "lblCuentaCajaPagoProveedores"
        Me.lblCuentaCajaPagoProveedores.Size = New System.Drawing.Size(290, 13)
        Me.lblCuentaCajaPagoProveedores.TabIndex = 53
        Me.lblCuentaCajaPagoProveedores.Text = "Define la cuenta para movimientos de Pagos a Proveedores"
        '
        'txtCuentaCajaPagoProveedores
        '
        Me.txtCuentaCajaPagoProveedores.BindearPropiedadControl = Nothing
        Me.txtCuentaCajaPagoProveedores.BindearPropiedadEntidad = Nothing
        Me.txtCuentaCajaPagoProveedores.ForeColorFocus = System.Drawing.Color.Red
        Me.txtCuentaCajaPagoProveedores.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtCuentaCajaPagoProveedores.Formato = ""
        Me.txtCuentaCajaPagoProveedores.IsDecimal = False
        Me.txtCuentaCajaPagoProveedores.IsNumber = True
        Me.txtCuentaCajaPagoProveedores.IsPK = False
        Me.txtCuentaCajaPagoProveedores.IsRequired = False
        Me.txtCuentaCajaPagoProveedores.Key = ""
        Me.txtCuentaCajaPagoProveedores.LabelAsoc = Me.lblCuentaCajaPagoProveedores
        Me.txtCuentaCajaPagoProveedores.Location = New System.Drawing.Point(19, 106)
        Me.txtCuentaCajaPagoProveedores.MaxLength = 7
        Me.txtCuentaCajaPagoProveedores.Name = "txtCuentaCajaPagoProveedores"
        Me.txtCuentaCajaPagoProveedores.Size = New System.Drawing.Size(35, 20)
        Me.txtCuentaCajaPagoProveedores.TabIndex = 48
        Me.txtCuentaCajaPagoProveedores.Tag = ""
        Me.txtCuentaCajaPagoProveedores.Text = "4"
        Me.txtCuentaCajaPagoProveedores.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtCuentaCajaDeposito
        '
        Me.txtCuentaCajaDeposito.BindearPropiedadControl = Nothing
        Me.txtCuentaCajaDeposito.BindearPropiedadEntidad = Nothing
        Me.txtCuentaCajaDeposito.ForeColorFocus = System.Drawing.Color.Red
        Me.txtCuentaCajaDeposito.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtCuentaCajaDeposito.Formato = ""
        Me.txtCuentaCajaDeposito.IsDecimal = False
        Me.txtCuentaCajaDeposito.IsNumber = True
        Me.txtCuentaCajaDeposito.IsPK = False
        Me.txtCuentaCajaDeposito.IsRequired = False
        Me.txtCuentaCajaDeposito.Key = ""
        Me.txtCuentaCajaDeposito.LabelAsoc = Me.lblCuentaCajaDeposito
        Me.txtCuentaCajaDeposito.Location = New System.Drawing.Point(19, 158)
        Me.txtCuentaCajaDeposito.MaxLength = 7
        Me.txtCuentaCajaDeposito.Name = "txtCuentaCajaDeposito"
        Me.txtCuentaCajaDeposito.Size = New System.Drawing.Size(35, 20)
        Me.txtCuentaCajaDeposito.TabIndex = 50
        Me.txtCuentaCajaDeposito.Tag = ""
        Me.txtCuentaCajaDeposito.Text = "6"
        Me.txtCuentaCajaDeposito.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtCuentaCajaMovCheques
        '
        Me.txtCuentaCajaMovCheques.BindearPropiedadControl = Nothing
        Me.txtCuentaCajaMovCheques.BindearPropiedadEntidad = Nothing
        Me.txtCuentaCajaMovCheques.ForeColorFocus = System.Drawing.Color.Red
        Me.txtCuentaCajaMovCheques.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtCuentaCajaMovCheques.Formato = ""
        Me.txtCuentaCajaMovCheques.IsDecimal = False
        Me.txtCuentaCajaMovCheques.IsNumber = True
        Me.txtCuentaCajaMovCheques.IsPK = False
        Me.txtCuentaCajaMovCheques.IsRequired = False
        Me.txtCuentaCajaMovCheques.Key = ""
        Me.txtCuentaCajaMovCheques.LabelAsoc = Me.lblCuentaCajaMovimientoChequesSucursales
        Me.txtCuentaCajaMovCheques.Location = New System.Drawing.Point(19, 184)
        Me.txtCuentaCajaMovCheques.MaxLength = 7
        Me.txtCuentaCajaMovCheques.Name = "txtCuentaCajaMovCheques"
        Me.txtCuentaCajaMovCheques.Size = New System.Drawing.Size(35, 20)
        Me.txtCuentaCajaMovCheques.TabIndex = 58
        Me.txtCuentaCajaMovCheques.Tag = ""
        Me.txtCuentaCajaMovCheques.Text = "7"
        Me.txtCuentaCajaMovCheques.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtCuentaCajaTransfBancaria
        '
        Me.txtCuentaCajaTransfBancaria.BindearPropiedadControl = Nothing
        Me.txtCuentaCajaTransfBancaria.BindearPropiedadEntidad = Nothing
        Me.txtCuentaCajaTransfBancaria.ForeColorFocus = System.Drawing.Color.Red
        Me.txtCuentaCajaTransfBancaria.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtCuentaCajaTransfBancaria.Formato = ""
        Me.txtCuentaCajaTransfBancaria.IsDecimal = False
        Me.txtCuentaCajaTransfBancaria.IsNumber = True
        Me.txtCuentaCajaTransfBancaria.IsPK = False
        Me.txtCuentaCajaTransfBancaria.IsRequired = False
        Me.txtCuentaCajaTransfBancaria.Key = ""
        Me.txtCuentaCajaTransfBancaria.LabelAsoc = Me.lblCuentaCajaTransfBancaria
        Me.txtCuentaCajaTransfBancaria.Location = New System.Drawing.Point(19, 132)
        Me.txtCuentaCajaTransfBancaria.MaxLength = 7
        Me.txtCuentaCajaTransfBancaria.Name = "txtCuentaCajaTransfBancaria"
        Me.txtCuentaCajaTransfBancaria.Size = New System.Drawing.Size(35, 20)
        Me.txtCuentaCajaTransfBancaria.TabIndex = 49
        Me.txtCuentaCajaTransfBancaria.Tag = ""
        Me.txtCuentaCajaTransfBancaria.Text = "5"
        Me.txtCuentaCajaTransfBancaria.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'chbFechaPlanillaDelDia
        '
        Me.chbFechaPlanillaDelDia.AutoSize = True
        Me.chbFechaPlanillaDelDia.BindearPropiedadControl = Nothing
        Me.chbFechaPlanillaDelDia.BindearPropiedadEntidad = Nothing
        Me.chbFechaPlanillaDelDia.ForeColorFocus = System.Drawing.Color.Red
        Me.chbFechaPlanillaDelDia.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbFechaPlanillaDelDia.IsPK = False
        Me.chbFechaPlanillaDelDia.IsRequired = False
        Me.chbFechaPlanillaDelDia.Key = Nothing
        Me.chbFechaPlanillaDelDia.LabelAsoc = Nothing
        Me.chbFechaPlanillaDelDia.Location = New System.Drawing.Point(53, 180)
        Me.chbFechaPlanillaDelDia.Name = "chbFechaPlanillaDelDia"
        Me.chbFechaPlanillaDelDia.Size = New System.Drawing.Size(290, 17)
        Me.chbFechaPlanillaDelDia.TabIndex = 72
        Me.chbFechaPlanillaDelDia.Tag = "CAJAPLANILLAFECHADIA"
        Me.chbFechaPlanillaDelDia.Text = "Fecha Planilla Nueva:  es del Día (sino, del Movimiento)"
        Me.chbFechaPlanillaDelDia.UseVisualStyleBackColor = True
        '
        'chbPermiteMovimientoSinSaldo
        '
        Me.chbPermiteMovimientoSinSaldo.AutoSize = True
        Me.chbPermiteMovimientoSinSaldo.BindearPropiedadControl = Nothing
        Me.chbPermiteMovimientoSinSaldo.BindearPropiedadEntidad = Nothing
        Me.chbPermiteMovimientoSinSaldo.ForeColorFocus = System.Drawing.Color.Red
        Me.chbPermiteMovimientoSinSaldo.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbPermiteMovimientoSinSaldo.IsPK = False
        Me.chbPermiteMovimientoSinSaldo.IsRequired = False
        Me.chbPermiteMovimientoSinSaldo.Key = Nothing
        Me.chbPermiteMovimientoSinSaldo.LabelAsoc = Nothing
        Me.chbPermiteMovimientoSinSaldo.Location = New System.Drawing.Point(53, 155)
        Me.chbPermiteMovimientoSinSaldo.Name = "chbPermiteMovimientoSinSaldo"
        Me.chbPermiteMovimientoSinSaldo.Size = New System.Drawing.Size(221, 17)
        Me.chbPermiteMovimientoSinSaldo.TabIndex = 71
        Me.chbPermiteMovimientoSinSaldo.Tag = "CAJAPERMITIRMOVSINSALDO"
        Me.chbPermiteMovimientoSinSaldo.Text = "Permitir Movimiento entre Cajas Sin Saldo"
        Me.chbPermiteMovimientoSinSaldo.UseVisualStyleBackColor = True
        '
        'chbCajaPlanillaMuestraVentasEnCtaCte
        '
        Me.chbCajaPlanillaMuestraVentasEnCtaCte.AutoSize = True
        Me.chbCajaPlanillaMuestraVentasEnCtaCte.BindearPropiedadControl = Nothing
        Me.chbCajaPlanillaMuestraVentasEnCtaCte.BindearPropiedadEntidad = Nothing
        Me.chbCajaPlanillaMuestraVentasEnCtaCte.ForeColorFocus = System.Drawing.Color.Red
        Me.chbCajaPlanillaMuestraVentasEnCtaCte.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbCajaPlanillaMuestraVentasEnCtaCte.IsPK = False
        Me.chbCajaPlanillaMuestraVentasEnCtaCte.IsRequired = False
        Me.chbCajaPlanillaMuestraVentasEnCtaCte.Key = Nothing
        Me.chbCajaPlanillaMuestraVentasEnCtaCte.LabelAsoc = Nothing
        Me.chbCajaPlanillaMuestraVentasEnCtaCte.Location = New System.Drawing.Point(53, 132)
        Me.chbCajaPlanillaMuestraVentasEnCtaCte.Name = "chbCajaPlanillaMuestraVentasEnCtaCte"
        Me.chbCajaPlanillaMuestraVentasEnCtaCte.Size = New System.Drawing.Size(208, 17)
        Me.chbCajaPlanillaMuestraVentasEnCtaCte.TabIndex = 70
        Me.chbCajaPlanillaMuestraVentasEnCtaCte.Tag = "CAJAPLANILLAMUESTRAVENTASENCTACTE"
        Me.chbCajaPlanillaMuestraVentasEnCtaCte.Text = "Planilla Muestra las Ventas en Cta.Cte."
        Me.chbCajaPlanillaMuestraVentasEnCtaCte.UseVisualStyleBackColor = True
        '
        'chbCajaPlanillaMuestraProductosConAlerta
        '
        Me.chbCajaPlanillaMuestraProductosConAlerta.AutoSize = True
        Me.chbCajaPlanillaMuestraProductosConAlerta.BindearPropiedadControl = Nothing
        Me.chbCajaPlanillaMuestraProductosConAlerta.BindearPropiedadEntidad = Nothing
        Me.chbCajaPlanillaMuestraProductosConAlerta.ForeColorFocus = System.Drawing.Color.Red
        Me.chbCajaPlanillaMuestraProductosConAlerta.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbCajaPlanillaMuestraProductosConAlerta.IsPK = False
        Me.chbCajaPlanillaMuestraProductosConAlerta.IsRequired = False
        Me.chbCajaPlanillaMuestraProductosConAlerta.Key = Nothing
        Me.chbCajaPlanillaMuestraProductosConAlerta.LabelAsoc = Nothing
        Me.chbCajaPlanillaMuestraProductosConAlerta.Location = New System.Drawing.Point(53, 109)
        Me.chbCajaPlanillaMuestraProductosConAlerta.Name = "chbCajaPlanillaMuestraProductosConAlerta"
        Me.chbCajaPlanillaMuestraProductosConAlerta.Size = New System.Drawing.Size(218, 17)
        Me.chbCajaPlanillaMuestraProductosConAlerta.TabIndex = 69
        Me.chbCajaPlanillaMuestraProductosConAlerta.Tag = "CAJAPLANILLAMUESTRAPRODUCTOSCONALERTA"
        Me.chbCajaPlanillaMuestraProductosConAlerta.Text = "Planilla Muestra los Productos con Alerta"
        Me.chbCajaPlanillaMuestraProductosConAlerta.UseVisualStyleBackColor = True
        '
        'chbCajaUtilizaSaldosDigitados
        '
        Me.chbCajaUtilizaSaldosDigitados.AutoSize = True
        Me.chbCajaUtilizaSaldosDigitados.BindearPropiedadControl = Nothing
        Me.chbCajaUtilizaSaldosDigitados.BindearPropiedadEntidad = Nothing
        Me.chbCajaUtilizaSaldosDigitados.ForeColorFocus = System.Drawing.Color.Red
        Me.chbCajaUtilizaSaldosDigitados.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbCajaUtilizaSaldosDigitados.IsPK = False
        Me.chbCajaUtilizaSaldosDigitados.IsRequired = False
        Me.chbCajaUtilizaSaldosDigitados.Key = Nothing
        Me.chbCajaUtilizaSaldosDigitados.LabelAsoc = Nothing
        Me.chbCajaUtilizaSaldosDigitados.Location = New System.Drawing.Point(53, 86)
        Me.chbCajaUtilizaSaldosDigitados.Name = "chbCajaUtilizaSaldosDigitados"
        Me.chbCajaUtilizaSaldosDigitados.Size = New System.Drawing.Size(136, 17)
        Me.chbCajaUtilizaSaldosDigitados.TabIndex = 68
        Me.chbCajaUtilizaSaldosDigitados.Tag = "CAJAUTILIZASALDOSDIGITADOS"
        Me.chbCajaUtilizaSaldosDigitados.Text = "Utiliza Saldos Digitados"
        Me.chbCajaUtilizaSaldosDigitados.UseVisualStyleBackColor = True
        '
        'chbCajaMostrarNCIndividual
        '
        Me.chbCajaMostrarNCIndividual.AutoSize = True
        Me.chbCajaMostrarNCIndividual.BindearPropiedadControl = Nothing
        Me.chbCajaMostrarNCIndividual.BindearPropiedadEntidad = Nothing
        Me.chbCajaMostrarNCIndividual.ForeColorFocus = System.Drawing.Color.Red
        Me.chbCajaMostrarNCIndividual.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbCajaMostrarNCIndividual.IsPK = False
        Me.chbCajaMostrarNCIndividual.IsRequired = False
        Me.chbCajaMostrarNCIndividual.Key = Nothing
        Me.chbCajaMostrarNCIndividual.LabelAsoc = Nothing
        Me.chbCajaMostrarNCIndividual.Location = New System.Drawing.Point(53, 63)
        Me.chbCajaMostrarNCIndividual.Name = "chbCajaMostrarNCIndividual"
        Me.chbCajaMostrarNCIndividual.Size = New System.Drawing.Size(155, 17)
        Me.chbCajaMostrarNCIndividual.TabIndex = 67
        Me.chbCajaMostrarNCIndividual.Tag = "CAJAMOSTRARNCINDIVIDUAL"
        Me.chbCajaMostrarNCIndividual.Text = "Mostrar NC individualmente"
        Me.chbCajaMostrarNCIndividual.UseVisualStyleBackColor = True
        '
        'chbCajaAcumulaVentas
        '
        Me.chbCajaAcumulaVentas.AutoSize = True
        Me.chbCajaAcumulaVentas.BindearPropiedadControl = Nothing
        Me.chbCajaAcumulaVentas.BindearPropiedadEntidad = Nothing
        Me.chbCajaAcumulaVentas.ForeColorFocus = System.Drawing.Color.Red
        Me.chbCajaAcumulaVentas.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbCajaAcumulaVentas.IsPK = False
        Me.chbCajaAcumulaVentas.IsRequired = False
        Me.chbCajaAcumulaVentas.Key = Nothing
        Me.chbCajaAcumulaVentas.LabelAsoc = Nothing
        Me.chbCajaAcumulaVentas.Location = New System.Drawing.Point(53, 40)
        Me.chbCajaAcumulaVentas.Name = "chbCajaAcumulaVentas"
        Me.chbCajaAcumulaVentas.Size = New System.Drawing.Size(234, 17)
        Me.chbCajaAcumulaVentas.TabIndex = 66
        Me.chbCajaAcumulaVentas.Tag = "CTACAJAVENTASACUMULA"
        Me.chbCajaAcumulaVentas.Text = "Acumula los movimientos de Caja de Ventas"
        Me.chbCajaAcumulaVentas.UseVisualStyleBackColor = True
        '
        'pnlCierreCaja
        '
        Me.pnlCierreCaja.Controls.Add(Me.cmbSucursalDestino)
        Me.pnlCierreCaja.Controls.Add(Me.lblSucursalDestino)
        Me.pnlCierreCaja.Controls.Add(Me.cmbCajasDestino)
        Me.pnlCierreCaja.Controls.Add(Me.lblCajaDestino)
        Me.pnlCierreCaja.Controls.Add(Me.cmbModoCierrePlanillaCaja)
        Me.pnlCierreCaja.Controls.Add(Me.lblModoCierrePlanillaCaja)
        Me.pnlCierreCaja.Location = New System.Drawing.Point(53, 278)
        Me.pnlCierreCaja.Name = "pnlCierreCaja"
        Me.pnlCierreCaja.Size = New System.Drawing.Size(350, 102)
        Me.pnlCierreCaja.TabIndex = 75
        Me.pnlCierreCaja.TabStop = False
        Me.pnlCierreCaja.Text = "Cierre Planilla de Caja"
        '
        'cmbSucursalDestino
        '
        Me.cmbSucursalDestino.BindearPropiedadControl = Nothing
        Me.cmbSucursalDestino.BindearPropiedadEntidad = Nothing
        Me.cmbSucursalDestino.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbSucursalDestino.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbSucursalDestino.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbSucursalDestino.FormattingEnabled = True
        Me.cmbSucursalDestino.IsPK = False
        Me.cmbSucursalDestino.IsRequired = False
        Me.cmbSucursalDestino.Key = Nothing
        Me.cmbSucursalDestino.LabelAsoc = Me.lblSucursalDestino
        Me.cmbSucursalDestino.Location = New System.Drawing.Point(122, 46)
        Me.cmbSucursalDestino.Name = "cmbSucursalDestino"
        Me.cmbSucursalDestino.Size = New System.Drawing.Size(194, 21)
        Me.cmbSucursalDestino.TabIndex = 91
        '
        'lblSucursalDestino
        '
        Me.lblSucursalDestino.AutoSize = True
        Me.lblSucursalDestino.LabelAsoc = Nothing
        Me.lblSucursalDestino.Location = New System.Drawing.Point(29, 50)
        Me.lblSucursalDestino.Name = "lblSucursalDestino"
        Me.lblSucursalDestino.Size = New System.Drawing.Size(87, 13)
        Me.lblSucursalDestino.TabIndex = 90
        Me.lblSucursalDestino.Text = "Sucursal Destino"
        '
        'cmbCajasDestino
        '
        Me.cmbCajasDestino.BindearPropiedadControl = ""
        Me.cmbCajasDestino.BindearPropiedadEntidad = ""
        Me.cmbCajasDestino.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbCajasDestino.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbCajasDestino.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbCajasDestino.FormattingEnabled = True
        Me.cmbCajasDestino.IsPK = False
        Me.cmbCajasDestino.IsRequired = False
        Me.cmbCajasDestino.Key = Nothing
        Me.cmbCajasDestino.LabelAsoc = Me.lblCajaDestino
        Me.cmbCajasDestino.Location = New System.Drawing.Point(122, 73)
        Me.cmbCajasDestino.Name = "cmbCajasDestino"
        Me.cmbCajasDestino.Size = New System.Drawing.Size(194, 21)
        Me.cmbCajasDestino.TabIndex = 93
        '
        'lblCajaDestino
        '
        Me.lblCajaDestino.AutoSize = True
        Me.lblCajaDestino.LabelAsoc = Nothing
        Me.lblCajaDestino.Location = New System.Drawing.Point(29, 77)
        Me.lblCajaDestino.Name = "lblCajaDestino"
        Me.lblCajaDestino.Size = New System.Drawing.Size(67, 13)
        Me.lblCajaDestino.TabIndex = 92
        Me.lblCajaDestino.Text = "Caja Destino"
        '
        'cmbModoCierrePlanillaCaja
        '
        Me.cmbModoCierrePlanillaCaja.BindearPropiedadControl = Nothing
        Me.cmbModoCierrePlanillaCaja.BindearPropiedadEntidad = Nothing
        Me.cmbModoCierrePlanillaCaja.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbModoCierrePlanillaCaja.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbModoCierrePlanillaCaja.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbModoCierrePlanillaCaja.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbModoCierrePlanillaCaja.FormattingEnabled = True
        Me.cmbModoCierrePlanillaCaja.IsPK = False
        Me.cmbModoCierrePlanillaCaja.IsRequired = False
        Me.cmbModoCierrePlanillaCaja.Key = Nothing
        Me.cmbModoCierrePlanillaCaja.LabelAsoc = Me.lblModoCierrePlanillaCaja
        Me.cmbModoCierrePlanillaCaja.Location = New System.Drawing.Point(122, 19)
        Me.cmbModoCierrePlanillaCaja.Name = "cmbModoCierrePlanillaCaja"
        Me.cmbModoCierrePlanillaCaja.Size = New System.Drawing.Size(194, 21)
        Me.cmbModoCierrePlanillaCaja.TabIndex = 89
        Me.cmbModoCierrePlanillaCaja.Tag = "CALCULOCOMISIONVENDEDOR"
        '
        'lblModoCierrePlanillaCaja
        '
        Me.lblModoCierrePlanillaCaja.AutoSize = True
        Me.lblModoCierrePlanillaCaja.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblModoCierrePlanillaCaja.LabelAsoc = Nothing
        Me.lblModoCierrePlanillaCaja.Location = New System.Drawing.Point(29, 23)
        Me.lblModoCierrePlanillaCaja.Name = "lblModoCierrePlanillaCaja"
        Me.lblModoCierrePlanillaCaja.Size = New System.Drawing.Size(34, 13)
        Me.lblModoCierrePlanillaCaja.TabIndex = 88
        Me.lblModoCierrePlanillaCaja.Text = "Modo"
        '
        'chbCajaPredPorPC
        '
        Me.chbCajaPredPorPC.AutoSize = True
        Me.chbCajaPredPorPC.BindearPropiedadControl = Nothing
        Me.chbCajaPredPorPC.BindearPropiedadEntidad = Nothing
        Me.chbCajaPredPorPC.ForeColorFocus = System.Drawing.Color.Red
        Me.chbCajaPredPorPC.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbCajaPredPorPC.IsPK = False
        Me.chbCajaPredPorPC.IsRequired = False
        Me.chbCajaPredPorPC.Key = Nothing
        Me.chbCajaPredPorPC.LabelAsoc = Nothing
        Me.chbCajaPredPorPC.Location = New System.Drawing.Point(53, 204)
        Me.chbCajaPredPorPC.Name = "chbCajaPredPorPC"
        Me.chbCajaPredPorPC.Size = New System.Drawing.Size(258, 17)
        Me.chbCajaPredPorPC.TabIndex = 76
        Me.chbCajaPredPorPC.Tag = "CAJAPLANILLAFECHADIA"
        Me.chbCajaPredPorPC.Text = "Planilla toma caja predeterminada por nombre pc "
        Me.chbCajaPredPorPC.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.chbNegativoImporteTickets)
        Me.GroupBox1.Controls.Add(Me.chbNegativoImporteBancos)
        Me.GroupBox1.Controls.Add(Me.chbNegativoImportePesos)
        Me.GroupBox1.Controls.Add(Me.chbNegativoImporteDolares)
        Me.GroupBox1.Controls.Add(Me.chbNegativoImporteTotal)
        Me.GroupBox1.Location = New System.Drawing.Point(446, 313)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(200, 137)
        Me.GroupBox1.TabIndex = 78
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Permite importes negativos"
        '
        'chbNegativoImporteTickets
        '
        Me.chbNegativoImporteTickets.AutoSize = True
        Me.chbNegativoImporteTickets.BindearPropiedadControl = Nothing
        Me.chbNegativoImporteTickets.BindearPropiedadEntidad = Nothing
        Me.chbNegativoImporteTickets.ForeColorFocus = System.Drawing.Color.Red
        Me.chbNegativoImporteTickets.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbNegativoImporteTickets.IsPK = False
        Me.chbNegativoImporteTickets.IsRequired = False
        Me.chbNegativoImporteTickets.Key = Nothing
        Me.chbNegativoImporteTickets.LabelAsoc = Nothing
        Me.chbNegativoImporteTickets.Location = New System.Drawing.Point(19, 68)
        Me.chbNegativoImporteTickets.Name = "chbNegativoImporteTickets"
        Me.chbNegativoImporteTickets.Size = New System.Drawing.Size(99, 17)
        Me.chbNegativoImporteTickets.TabIndex = 72
        Me.chbNegativoImporteTickets.Tag = "CAJAIMPORTESNEGATIVOSTICKETS"
        Me.chbNegativoImporteTickets.Text = "Importe Tickets"
        Me.chbNegativoImporteTickets.UseVisualStyleBackColor = True
        '
        'chbNegativoImporteBancos
        '
        Me.chbNegativoImporteBancos.AutoSize = True
        Me.chbNegativoImporteBancos.BindearPropiedadControl = Nothing
        Me.chbNegativoImporteBancos.BindearPropiedadEntidad = Nothing
        Me.chbNegativoImporteBancos.ForeColorFocus = System.Drawing.Color.Red
        Me.chbNegativoImporteBancos.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbNegativoImporteBancos.IsPK = False
        Me.chbNegativoImporteBancos.IsRequired = False
        Me.chbNegativoImporteBancos.Key = Nothing
        Me.chbNegativoImporteBancos.LabelAsoc = Nothing
        Me.chbNegativoImporteBancos.Location = New System.Drawing.Point(19, 91)
        Me.chbNegativoImporteBancos.Name = "chbNegativoImporteBancos"
        Me.chbNegativoImporteBancos.Size = New System.Drawing.Size(100, 17)
        Me.chbNegativoImporteBancos.TabIndex = 71
        Me.chbNegativoImporteBancos.Tag = "CAJAIMPORTESNEGATIVOSBANCOS"
        Me.chbNegativoImporteBancos.Text = "Importe Bancos"
        Me.chbNegativoImporteBancos.UseVisualStyleBackColor = True
        '
        'chbNegativoImportePesos
        '
        Me.chbNegativoImportePesos.AutoSize = True
        Me.chbNegativoImportePesos.BindearPropiedadControl = Nothing
        Me.chbNegativoImportePesos.BindearPropiedadEntidad = Nothing
        Me.chbNegativoImportePesos.ForeColorFocus = System.Drawing.Color.Red
        Me.chbNegativoImportePesos.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbNegativoImportePesos.IsPK = False
        Me.chbNegativoImportePesos.IsRequired = False
        Me.chbNegativoImportePesos.Key = Nothing
        Me.chbNegativoImportePesos.LabelAsoc = Nothing
        Me.chbNegativoImportePesos.Location = New System.Drawing.Point(19, 45)
        Me.chbNegativoImportePesos.Name = "chbNegativoImportePesos"
        Me.chbNegativoImportePesos.Size = New System.Drawing.Size(93, 17)
        Me.chbNegativoImportePesos.TabIndex = 70
        Me.chbNegativoImportePesos.Tag = "CAJAIMPORTESNEGATIVOSPESOS"
        Me.chbNegativoImportePesos.Text = "Importe Pesos"
        Me.chbNegativoImportePesos.UseVisualStyleBackColor = True
        '
        'chbNegativoImporteDolares
        '
        Me.chbNegativoImporteDolares.AutoSize = True
        Me.chbNegativoImporteDolares.BindearPropiedadControl = Nothing
        Me.chbNegativoImporteDolares.BindearPropiedadEntidad = Nothing
        Me.chbNegativoImporteDolares.ForeColorFocus = System.Drawing.Color.Red
        Me.chbNegativoImporteDolares.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbNegativoImporteDolares.IsPK = False
        Me.chbNegativoImporteDolares.IsRequired = False
        Me.chbNegativoImporteDolares.Key = Nothing
        Me.chbNegativoImporteDolares.LabelAsoc = Nothing
        Me.chbNegativoImporteDolares.Location = New System.Drawing.Point(19, 112)
        Me.chbNegativoImporteDolares.Name = "chbNegativoImporteDolares"
        Me.chbNegativoImporteDolares.Size = New System.Drawing.Size(100, 17)
        Me.chbNegativoImporteDolares.TabIndex = 69
        Me.chbNegativoImporteDolares.Tag = "CAJAIMPORTESNEGATIVOSDOLARES"
        Me.chbNegativoImporteDolares.Text = "Importe Dólares"
        Me.chbNegativoImporteDolares.UseVisualStyleBackColor = True
        '
        'chbNegativoImporteTotal
        '
        Me.chbNegativoImporteTotal.AutoSize = True
        Me.chbNegativoImporteTotal.BindearPropiedadControl = Nothing
        Me.chbNegativoImporteTotal.BindearPropiedadEntidad = Nothing
        Me.chbNegativoImporteTotal.ForeColorFocus = System.Drawing.Color.Red
        Me.chbNegativoImporteTotal.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbNegativoImporteTotal.IsPK = False
        Me.chbNegativoImporteTotal.IsRequired = False
        Me.chbNegativoImporteTotal.Key = Nothing
        Me.chbNegativoImporteTotal.LabelAsoc = Nothing
        Me.chbNegativoImporteTotal.Location = New System.Drawing.Point(19, 22)
        Me.chbNegativoImporteTotal.Name = "chbNegativoImporteTotal"
        Me.chbNegativoImporteTotal.Size = New System.Drawing.Size(88, 17)
        Me.chbNegativoImporteTotal.TabIndex = 68
        Me.chbNegativoImporteTotal.Tag = "CAJAIMPORTESNEGATIVOSTOTAL"
        Me.chbNegativoImporteTotal.Text = "Importe Total"
        Me.chbNegativoImporteTotal.UseVisualStyleBackColor = True
        '
        'ucConfCaja
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.chbCajaPredPorPC)
        Me.Controls.Add(Me.pnlCierreCaja)
        Me.Controls.Add(Me.gpbOrdenarCobranzaPor)
        Me.Controls.Add(Me.grbCuentasdeCaja)
        Me.Controls.Add(Me.chbFechaPlanillaDelDia)
        Me.Controls.Add(Me.chbPermiteMovimientoSinSaldo)
        Me.Controls.Add(Me.chbCajaPlanillaMuestraVentasEnCtaCte)
        Me.Controls.Add(Me.chbCajaPlanillaMuestraProductosConAlerta)
        Me.Controls.Add(Me.chbCajaUtilizaSaldosDigitados)
        Me.Controls.Add(Me.chbCajaMostrarNCIndividual)
        Me.Controls.Add(Me.chbCajaAcumulaVentas)
        Me.Name = "ucConfCaja"
        Me.Size = New System.Drawing.Size(900, 453)
        Me.Controls.SetChildIndex(Me.chbCajaAcumulaVentas, 0)
        Me.Controls.SetChildIndex(Me.chbCajaMostrarNCIndividual, 0)
        Me.Controls.SetChildIndex(Me.chbCajaUtilizaSaldosDigitados, 0)
        Me.Controls.SetChildIndex(Me.chbCajaPlanillaMuestraProductosConAlerta, 0)
        Me.Controls.SetChildIndex(Me.chbCajaPlanillaMuestraVentasEnCtaCte, 0)
        Me.Controls.SetChildIndex(Me.chbPermiteMovimientoSinSaldo, 0)
        Me.Controls.SetChildIndex(Me.chbFechaPlanillaDelDia, 0)
        Me.Controls.SetChildIndex(Me.grbCuentasdeCaja, 0)
        Me.Controls.SetChildIndex(Me.gpbOrdenarCobranzaPor, 0)
        Me.Controls.SetChildIndex(Me.pnlCierreCaja, 0)
        Me.Controls.SetChildIndex(Me.chbCajaPredPorPC, 0)
        Me.Controls.SetChildIndex(Me.GroupBox1, 0)
        Me.gpbOrdenarCobranzaPor.ResumeLayout(False)
        Me.gpbOrdenarCobranzaPor.PerformLayout()
        Me.grbCuentasdeCaja.ResumeLayout(False)
        Me.grbCuentasdeCaja.PerformLayout()
        Me.pnlCierreCaja.ResumeLayout(False)
        Me.pnlCierreCaja.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents gpbOrdenarCobranzaPor As GroupBox
   Friend WithEvents rbtOrdenarCobranzaPorVendedor As RadioButton
   Friend WithEvents rbtOrdenarCobranzaPorFecha As RadioButton
   Friend WithEvents grbCuentasdeCaja As GroupBox
   Friend WithEvents lblCuentaCajaLiquidacionesTarjetas As Controles.Label
   Friend WithEvents txtCuentaCajaLiquidacionesTarjetas As Controles.TextBox
   Friend WithEvents txtCuentaCajaVentas As Controles.TextBox
   Friend WithEvents lblCuentaCajaVentas As Controles.Label
   Friend WithEvents lblCuentaCajaExtraccionesBancarias As Controles.Label
   Friend WithEvents txtCuentaCajaExtraccionesBancarias As Controles.TextBox
   Friend WithEvents lblCuentaCajaDepositoTarjeta As Controles.Label
   Friend WithEvents txtCuentaCajaRecibos As Controles.TextBox
   Friend WithEvents lblCuentaCajaRecibos As Controles.Label
   Friend WithEvents lblCuentaCajaMovimientoChequesSucursales As Controles.Label
   Friend WithEvents lblCuentaCajaTransfBancaria As Controles.Label
   Friend WithEvents txtCuentaCajaCompras As Controles.TextBox
   Friend WithEvents lblCuentaCajaCompras As Controles.Label
   Friend WithEvents lblCuentaCajaDeposito As Controles.Label
   Friend WithEvents txtCuentaCajaDepositoTarjetas As Controles.TextBox
   Friend WithEvents lblCuentaCajaPagoProveedores As Controles.Label
   Friend WithEvents txtCuentaCajaPagoProveedores As Controles.TextBox
   Friend WithEvents txtCuentaCajaDeposito As Controles.TextBox
   Friend WithEvents txtCuentaCajaMovCheques As Controles.TextBox
   Friend WithEvents txtCuentaCajaTransfBancaria As Controles.TextBox
   Friend WithEvents chbFechaPlanillaDelDia As Controles.CheckBox
   Friend WithEvents chbPermiteMovimientoSinSaldo As Controles.CheckBox
   Friend WithEvents chbCajaPlanillaMuestraVentasEnCtaCte As Controles.CheckBox
   Friend WithEvents chbCajaPlanillaMuestraProductosConAlerta As Controles.CheckBox
   Friend WithEvents chbCajaUtilizaSaldosDigitados As Controles.CheckBox
   Friend WithEvents chbCajaMostrarNCIndividual As Controles.CheckBox
   Friend WithEvents chbCajaAcumulaVentas As Controles.CheckBox
    Friend WithEvents pnlCierreCaja As GroupBox
    Friend WithEvents cmbModoCierrePlanillaCaja As Controles.ComboBox
    Friend WithEvents lblModoCierrePlanillaCaja As Controles.Label
    Friend WithEvents cmbSucursalDestino As Controles.ComboBox
    Friend WithEvents lblSucursalDestino As Controles.Label
    Friend WithEvents cmbCajasDestino As Controles.ComboBox
    Friend WithEvents lblCajaDestino As Controles.Label
   Friend WithEvents chbCajaPredPorPC As Controles.CheckBox
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents chbNegativoImporteTickets As Controles.CheckBox
    Friend WithEvents chbNegativoImporteBancos As Controles.CheckBox
    Friend WithEvents chbNegativoImportePesos As Controles.CheckBox
    Friend WithEvents chbNegativoImporteDolares As Controles.CheckBox
    Friend WithEvents chbNegativoImporteTotal As Controles.CheckBox
End Class
