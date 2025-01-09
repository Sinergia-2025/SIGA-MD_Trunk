<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ucConfVentas2
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
      Me.grbPermitirControlarLimiteCredito = New System.Windows.Forms.GroupBox()
      Me.pnlPermitirControlarLimiteCredito_LimiteCredito = New System.Windows.Forms.FlowLayoutPanel()
      Me.lblCreditoLimite = New Eniac.Controles.Label()
      Me.rbtPermitirFacturarCreditoLimite = New System.Windows.Forms.RadioButton()
      Me.rbtNoPermitirFacturarCreditoLimite = New System.Windows.Forms.RadioButton()
      Me.rbtAvisarPermitirFacturarCreditoLimite = New System.Windows.Forms.RadioButton()
      Me.pnlPermitirControlarLimiteCredito_LimiteDiasVencimiento = New System.Windows.Forms.FlowLayoutPanel()
      Me.lblLimiteDiasVto = New Eniac.Controles.Label()
      Me.rbtPermitirFacturarLimiteDiasVto = New System.Windows.Forms.RadioButton()
      Me.rbtNoPermitirFacturarLimiteDiasVto = New System.Windows.Forms.RadioButton()
      Me.rbtAvisarPermitirFacturarLimiteDiasVto = New System.Windows.Forms.RadioButton()
      Me.txtDiasInvocacionComprobantes = New Eniac.Controles.TextBox()
      Me.lblDiasInvocacionComprobantes = New Eniac.Controles.Label()
      Me.lblTopeCF = New Eniac.Controles.Label()
      Me.txtControlTopeCF = New Eniac.Controles.TextBox()
      Me.chbPermiteModificarCliente = New Eniac.Controles.CheckBox()
      Me.grbFacturacionRapidaOfreceCalcularVuelto = New System.Windows.Forms.GroupBox()
      Me.rbtFacturacionRapidaVueltoDirecto = New System.Windows.Forms.RadioButton()
      Me.rbtFacturacionRapidaVueltoNoOfrecer = New System.Windows.Forms.RadioButton()
      Me.rbtFacturacionRapidaVueltoOfrecer = New System.Windows.Forms.RadioButton()
      Me.chbFacturacionControlaDNIConsumidorFinal = New Eniac.Controles.CheckBox()
      Me.chbFacturacionRemitoTranspCalculaBultos = New Eniac.Controles.CheckBox()
      Me.chbFacturacionRemitoTranspUtilizaLote = New Eniac.Controles.CheckBox()
      Me.chbFacturacionIgnorarPCdeCaja = New Eniac.Controles.CheckBox()
      Me.chbPorCtaOrden = New Eniac.Controles.CheckBox()
      Me.chbFacturacionPermiteCantidadNegativaAcumulada = New Eniac.Controles.CheckBox()
      Me.grpComisionVendedor = New System.Windows.Forms.GroupBox()
      Me.rbtComisionVendedorMarcaRubro = New System.Windows.Forms.RadioButton()
      Me.rbtComisionVendedorRubroMarca = New System.Windows.Forms.RadioButton()
      Me.chbFacturacionComprobanteGrabaLibroNoFuerzaConsFinal = New Eniac.Controles.CheckBox()
      Me.chbFacturacionModificaDescripSolicitaPrecio = New Eniac.Controles.CheckBox()
      Me.chbFacturacionModificaDescripSolicKilos = New Eniac.Controles.CheckBox()
      Me.chbFacturacionModificaDescriProdCantidad = New Eniac.Controles.CheckBox()
      Me.lblDescuentoMaximo = New Eniac.Controles.Label()
      Me.chbFacturacionPermiteCantidadNegativa = New Eniac.Controles.CheckBox()
      Me.chbSaldoTomaActual = New Eniac.Controles.CheckBox()
      Me.chbSaldoContemplaHora = New Eniac.Controles.CheckBox()
      Me.txtDescuentoMaximo = New Eniac.Controles.TextBox()
      Me.chbFacturacionAvisaProductosEnCero = New Eniac.Controles.CheckBox()
      Me.lblCalculoComisionVendedor = New Eniac.Controles.Label()
      Me.chbFacturacionIgnorarUltimoDigitoCB = New Eniac.Controles.CheckBox()
      Me.cmbCalculoComisionVendedor = New Eniac.Controles.ComboBox()
        Me.lblBusquedaClienteDefault = New Eniac.Controles.Label()
        Me.cmbBusquedaClienteDefault = New Eniac.Controles.ComboBox()
        Me.chbSimulaPercepcionNGLibro = New Eniac.Controles.CheckBox()
        Me.grbPermitirControlarLimiteCredito.SuspendLayout()
        Me.pnlPermitirControlarLimiteCredito_LimiteCredito.SuspendLayout()
        Me.pnlPermitirControlarLimiteCredito_LimiteDiasVencimiento.SuspendLayout()
        Me.grbFacturacionRapidaOfreceCalcularVuelto.SuspendLayout()
        Me.grpComisionVendedor.SuspendLayout()
        Me.SuspendLayout()
        '
        'grbPermitirControlarLimiteCredito
        '
        Me.grbPermitirControlarLimiteCredito.Controls.Add(Me.pnlPermitirControlarLimiteCredito_LimiteCredito)
        Me.grbPermitirControlarLimiteCredito.Controls.Add(Me.pnlPermitirControlarLimiteCredito_LimiteDiasVencimiento)
        Me.grbPermitirControlarLimiteCredito.Location = New System.Drawing.Point(30, 160)
        Me.grbPermitirControlarLimiteCredito.Name = "grbPermitirControlarLimiteCredito"
        Me.grbPermitirControlarLimiteCredito.Size = New System.Drawing.Size(438, 71)
        Me.grbPermitirControlarLimiteCredito.TabIndex = 85
        Me.grbPermitirControlarLimiteCredito.TabStop = False
        Me.grbPermitirControlarLimiteCredito.Tag = ""
        Me.grbPermitirControlarLimiteCredito.Text = "Control Limite de Credito y Limite de Vencimiento de Clientes"
        '
        'pnlPermitirControlarLimiteCredito_LimiteCredito
        '
        Me.pnlPermitirControlarLimiteCredito_LimiteCredito.Controls.Add(Me.lblCreditoLimite)
        Me.pnlPermitirControlarLimiteCredito_LimiteCredito.Controls.Add(Me.rbtPermitirFacturarCreditoLimite)
        Me.pnlPermitirControlarLimiteCredito_LimiteCredito.Controls.Add(Me.rbtNoPermitirFacturarCreditoLimite)
        Me.pnlPermitirControlarLimiteCredito_LimiteCredito.Controls.Add(Me.rbtAvisarPermitirFacturarCreditoLimite)
        Me.pnlPermitirControlarLimiteCredito_LimiteCredito.Location = New System.Drawing.Point(6, 19)
        Me.pnlPermitirControlarLimiteCredito_LimiteCredito.Name = "pnlPermitirControlarLimiteCredito_LimiteCredito"
        Me.pnlPermitirControlarLimiteCredito_LimiteCredito.Size = New System.Drawing.Size(411, 24)
        Me.pnlPermitirControlarLimiteCredito_LimiteCredito.TabIndex = 0
        '
        'lblCreditoLimite
        '
        Me.lblCreditoLimite.AutoSize = True
        Me.lblCreditoLimite.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblCreditoLimite.LabelAsoc = Nothing
        Me.lblCreditoLimite.Location = New System.Drawing.Point(3, 3)
        Me.lblCreditoLimite.Margin = New System.Windows.Forms.Padding(3)
        Me.lblCreditoLimite.MinimumSize = New System.Drawing.Size(130, 17)
        Me.lblCreditoLimite.Name = "lblCreditoLimite"
        Me.lblCreditoLimite.Size = New System.Drawing.Size(130, 17)
        Me.lblCreditoLimite.TabIndex = 0
        Me.lblCreditoLimite.Text = "Límite de Crédito:"
        '
        'rbtPermitirFacturarCreditoLimite
        '
        Me.rbtPermitirFacturarCreditoLimite.AutoSize = True
        Me.rbtPermitirFacturarCreditoLimite.Checked = True
        Me.rbtPermitirFacturarCreditoLimite.Location = New System.Drawing.Point(139, 3)
        Me.rbtPermitirFacturarCreditoLimite.Name = "rbtPermitirFacturarCreditoLimite"
        Me.rbtPermitirFacturarCreditoLimite.Size = New System.Drawing.Size(59, 17)
        Me.rbtPermitirFacturarCreditoLimite.TabIndex = 1
        Me.rbtPermitirFacturarCreditoLimite.TabStop = True
        Me.rbtPermitirFacturarCreditoLimite.Tag = ""
        Me.rbtPermitirFacturarCreditoLimite.Text = "Permitir"
        Me.rbtPermitirFacturarCreditoLimite.UseVisualStyleBackColor = True
        '
        'rbtNoPermitirFacturarCreditoLimite
        '
        Me.rbtNoPermitirFacturarCreditoLimite.AutoSize = True
        Me.rbtNoPermitirFacturarCreditoLimite.Location = New System.Drawing.Point(204, 3)
        Me.rbtNoPermitirFacturarCreditoLimite.Name = "rbtNoPermitirFacturarCreditoLimite"
        Me.rbtNoPermitirFacturarCreditoLimite.Size = New System.Drawing.Size(76, 17)
        Me.rbtNoPermitirFacturarCreditoLimite.TabIndex = 2
        Me.rbtNoPermitirFacturarCreditoLimite.Tag = ""
        Me.rbtNoPermitirFacturarCreditoLimite.Text = "No Permitir"
        Me.rbtNoPermitirFacturarCreditoLimite.UseVisualStyleBackColor = True
        '
        'rbtAvisarPermitirFacturarCreditoLimite
        '
        Me.rbtAvisarPermitirFacturarCreditoLimite.AutoSize = True
        Me.rbtAvisarPermitirFacturarCreditoLimite.Location = New System.Drawing.Point(286, 3)
        Me.rbtAvisarPermitirFacturarCreditoLimite.Name = "rbtAvisarPermitirFacturarCreditoLimite"
        Me.rbtAvisarPermitirFacturarCreditoLimite.Size = New System.Drawing.Size(99, 17)
        Me.rbtAvisarPermitirFacturarCreditoLimite.TabIndex = 3
        Me.rbtAvisarPermitirFacturarCreditoLimite.Tag = ""
        Me.rbtAvisarPermitirFacturarCreditoLimite.Text = "Avisar y Permitir"
        Me.rbtAvisarPermitirFacturarCreditoLimite.UseVisualStyleBackColor = True
        '
        'pnlPermitirControlarLimiteCredito_LimiteDiasVencimiento
        '
        Me.pnlPermitirControlarLimiteCredito_LimiteDiasVencimiento.Controls.Add(Me.lblLimiteDiasVto)
        Me.pnlPermitirControlarLimiteCredito_LimiteDiasVencimiento.Controls.Add(Me.rbtPermitirFacturarLimiteDiasVto)
        Me.pnlPermitirControlarLimiteCredito_LimiteDiasVencimiento.Controls.Add(Me.rbtNoPermitirFacturarLimiteDiasVto)
        Me.pnlPermitirControlarLimiteCredito_LimiteDiasVencimiento.Controls.Add(Me.rbtAvisarPermitirFacturarLimiteDiasVto)
        Me.pnlPermitirControlarLimiteCredito_LimiteDiasVencimiento.Location = New System.Drawing.Point(6, 45)
        Me.pnlPermitirControlarLimiteCredito_LimiteDiasVencimiento.Name = "pnlPermitirControlarLimiteCredito_LimiteDiasVencimiento"
        Me.pnlPermitirControlarLimiteCredito_LimiteDiasVencimiento.Size = New System.Drawing.Size(411, 24)
        Me.pnlPermitirControlarLimiteCredito_LimiteDiasVencimiento.TabIndex = 1
        '
        'lblLimiteDiasVto
        '
        Me.lblLimiteDiasVto.AutoSize = True
        Me.lblLimiteDiasVto.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblLimiteDiasVto.LabelAsoc = Nothing
        Me.lblLimiteDiasVto.Location = New System.Drawing.Point(3, 3)
        Me.lblLimiteDiasVto.Margin = New System.Windows.Forms.Padding(3)
        Me.lblLimiteDiasVto.MinimumSize = New System.Drawing.Size(130, 17)
        Me.lblLimiteDiasVto.Name = "lblLimiteDiasVto"
        Me.lblLimiteDiasVto.Size = New System.Drawing.Size(130, 17)
        Me.lblLimiteDiasVto.TabIndex = 0
        Me.lblLimiteDiasVto.Text = "Límite Días Vto Factura:"
        '
        'rbtPermitirFacturarLimiteDiasVto
        '
        Me.rbtPermitirFacturarLimiteDiasVto.AutoSize = True
        Me.rbtPermitirFacturarLimiteDiasVto.Checked = True
        Me.rbtPermitirFacturarLimiteDiasVto.Location = New System.Drawing.Point(139, 3)
        Me.rbtPermitirFacturarLimiteDiasVto.Name = "rbtPermitirFacturarLimiteDiasVto"
        Me.rbtPermitirFacturarLimiteDiasVto.Size = New System.Drawing.Size(59, 17)
        Me.rbtPermitirFacturarLimiteDiasVto.TabIndex = 1
        Me.rbtPermitirFacturarLimiteDiasVto.TabStop = True
        Me.rbtPermitirFacturarLimiteDiasVto.Tag = ""
        Me.rbtPermitirFacturarLimiteDiasVto.Text = "Permitir"
        Me.rbtPermitirFacturarLimiteDiasVto.UseVisualStyleBackColor = True
        '
        'rbtNoPermitirFacturarLimiteDiasVto
        '
        Me.rbtNoPermitirFacturarLimiteDiasVto.AutoSize = True
        Me.rbtNoPermitirFacturarLimiteDiasVto.Location = New System.Drawing.Point(204, 3)
        Me.rbtNoPermitirFacturarLimiteDiasVto.Name = "rbtNoPermitirFacturarLimiteDiasVto"
        Me.rbtNoPermitirFacturarLimiteDiasVto.Size = New System.Drawing.Size(76, 17)
        Me.rbtNoPermitirFacturarLimiteDiasVto.TabIndex = 2
        Me.rbtNoPermitirFacturarLimiteDiasVto.Tag = ""
        Me.rbtNoPermitirFacturarLimiteDiasVto.Text = "No Permitir"
        Me.rbtNoPermitirFacturarLimiteDiasVto.UseVisualStyleBackColor = True
        '
        'rbtAvisarPermitirFacturarLimiteDiasVto
        '
        Me.rbtAvisarPermitirFacturarLimiteDiasVto.AutoSize = True
        Me.rbtAvisarPermitirFacturarLimiteDiasVto.Location = New System.Drawing.Point(286, 3)
        Me.rbtAvisarPermitirFacturarLimiteDiasVto.Name = "rbtAvisarPermitirFacturarLimiteDiasVto"
        Me.rbtAvisarPermitirFacturarLimiteDiasVto.Size = New System.Drawing.Size(99, 17)
        Me.rbtAvisarPermitirFacturarLimiteDiasVto.TabIndex = 3
        Me.rbtAvisarPermitirFacturarLimiteDiasVto.Tag = ""
        Me.rbtAvisarPermitirFacturarLimiteDiasVto.Text = "Avisar y Permitir"
        Me.rbtAvisarPermitirFacturarLimiteDiasVto.UseVisualStyleBackColor = True
        '
        'txtDiasInvocacionComprobantes
        '
        Me.txtDiasInvocacionComprobantes.BindearPropiedadControl = Nothing
        Me.txtDiasInvocacionComprobantes.BindearPropiedadEntidad = Nothing
        Me.txtDiasInvocacionComprobantes.ForeColorFocus = System.Drawing.Color.Red
        Me.txtDiasInvocacionComprobantes.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtDiasInvocacionComprobantes.Formato = ""
        Me.txtDiasInvocacionComprobantes.IsDecimal = False
        Me.txtDiasInvocacionComprobantes.IsNumber = True
        Me.txtDiasInvocacionComprobantes.IsPK = False
        Me.txtDiasInvocacionComprobantes.IsRequired = False
        Me.txtDiasInvocacionComprobantes.Key = ""
        Me.txtDiasInvocacionComprobantes.LabelAsoc = Me.lblDiasInvocacionComprobantes
        Me.txtDiasInvocacionComprobantes.Location = New System.Drawing.Point(536, 64)
        Me.txtDiasInvocacionComprobantes.MaxLength = 3
        Me.txtDiasInvocacionComprobantes.Name = "txtDiasInvocacionComprobantes"
        Me.txtDiasInvocacionComprobantes.Size = New System.Drawing.Size(35, 20)
        Me.txtDiasInvocacionComprobantes.TabIndex = 71
        Me.txtDiasInvocacionComprobantes.Tag = "FACTURACIONDIASINVOCACIONCOMPROBANTES"
        Me.txtDiasInvocacionComprobantes.Text = "7"
        Me.txtDiasInvocacionComprobantes.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'lblDiasInvocacionComprobantes
        '
        Me.lblDiasInvocacionComprobantes.AutoSize = True
        Me.lblDiasInvocacionComprobantes.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblDiasInvocacionComprobantes.LabelAsoc = Nothing
        Me.lblDiasInvocacionComprobantes.Location = New System.Drawing.Point(577, 69)
        Me.lblDiasInvocacionComprobantes.Name = "lblDiasInvocacionComprobantes"
        Me.lblDiasInvocacionComprobantes.Size = New System.Drawing.Size(184, 13)
        Me.lblDiasInvocacionComprobantes.TabIndex = 72
        Me.lblDiasInvocacionComprobantes.Text = "Dias de Invocación de comprobantes"
        '
        'lblTopeCF
        '
        Me.lblTopeCF.AutoSize = True
        Me.lblTopeCF.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblTopeCF.LabelAsoc = Nothing
        Me.lblTopeCF.Location = New System.Drawing.Point(531, 350)
        Me.lblTopeCF.Name = "lblTopeCF"
        Me.lblTopeCF.Size = New System.Drawing.Size(115, 13)
        Me.lblTopeCF.TabIndex = 82
        Me.lblTopeCF.Text = "Tope Consumidor Final"
        '
        'txtControlTopeCF
        '
        Me.txtControlTopeCF.BindearPropiedadControl = Nothing
        Me.txtControlTopeCF.BindearPropiedadEntidad = Nothing
        Me.txtControlTopeCF.ForeColorFocus = System.Drawing.Color.Red
        Me.txtControlTopeCF.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtControlTopeCF.Formato = "N0"
        Me.txtControlTopeCF.IsDecimal = False
        Me.txtControlTopeCF.IsNumber = True
        Me.txtControlTopeCF.IsPK = False
        Me.txtControlTopeCF.IsRequired = False
        Me.txtControlTopeCF.Key = ""
        Me.txtControlTopeCF.LabelAsoc = Nothing
        Me.txtControlTopeCF.Location = New System.Drawing.Point(649, 347)
        Me.txtControlTopeCF.MaxLength = 8
        Me.txtControlTopeCF.Name = "txtControlTopeCF"
        Me.txtControlTopeCF.Size = New System.Drawing.Size(133, 20)
        Me.txtControlTopeCF.TabIndex = 83
        Me.txtControlTopeCF.Tag = "FACTURACIONCONTROLATOPECF"
        Me.txtControlTopeCF.Text = "0"
        Me.txtControlTopeCF.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'chbPermiteModificarCliente
        '
        Me.chbPermiteModificarCliente.BindearPropiedadControl = Nothing
        Me.chbPermiteModificarCliente.BindearPropiedadEntidad = Nothing
        Me.chbPermiteModificarCliente.ForeColorFocus = System.Drawing.Color.Red
        Me.chbPermiteModificarCliente.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbPermiteModificarCliente.IsPK = False
        Me.chbPermiteModificarCliente.IsRequired = False
        Me.chbPermiteModificarCliente.Key = Nothing
        Me.chbPermiteModificarCliente.LabelAsoc = Nothing
        Me.chbPermiteModificarCliente.Location = New System.Drawing.Point(536, 37)
        Me.chbPermiteModificarCliente.Name = "chbPermiteModificarCliente"
        Me.chbPermiteModificarCliente.Size = New System.Drawing.Size(335, 25)
        Me.chbPermiteModificarCliente.TabIndex = 70
        Me.chbPermiteModificarCliente.Tag = "FACTURACIONPERMITEMODIFICARCLIENTE"
        Me.chbPermiteModificarCliente.Text = "Permite Modificar Cliente en Facturación"
        Me.chbPermiteModificarCliente.UseVisualStyleBackColor = True
        '
        'grbFacturacionRapidaOfreceCalcularVuelto
        '
        Me.grbFacturacionRapidaOfreceCalcularVuelto.Controls.Add(Me.rbtFacturacionRapidaVueltoDirecto)
        Me.grbFacturacionRapidaOfreceCalcularVuelto.Controls.Add(Me.rbtFacturacionRapidaVueltoNoOfrecer)
        Me.grbFacturacionRapidaOfreceCalcularVuelto.Controls.Add(Me.rbtFacturacionRapidaVueltoOfrecer)
        Me.grbFacturacionRapidaOfreceCalcularVuelto.Location = New System.Drawing.Point(30, 14)
        Me.grbFacturacionRapidaOfreceCalcularVuelto.Name = "grbFacturacionRapidaOfreceCalcularVuelto"
        Me.grbFacturacionRapidaOfreceCalcularVuelto.Size = New System.Drawing.Size(246, 42)
        Me.grbFacturacionRapidaOfreceCalcularVuelto.TabIndex = 59
        Me.grbFacturacionRapidaOfreceCalcularVuelto.TabStop = False
        Me.grbFacturacionRapidaOfreceCalcularVuelto.Tag = "FACTURACIONOFRECECALCULARVUELTO"
        Me.grbFacturacionRapidaOfreceCalcularVuelto.Text = "Facturación Ofrece Calcular el Vuelto"
        '
        'rbtFacturacionRapidaVueltoDirecto
        '
        Me.rbtFacturacionRapidaVueltoDirecto.AutoSize = True
        Me.rbtFacturacionRapidaVueltoDirecto.Location = New System.Drawing.Point(170, 18)
        Me.rbtFacturacionRapidaVueltoDirecto.Name = "rbtFacturacionRapidaVueltoDirecto"
        Me.rbtFacturacionRapidaVueltoDirecto.Size = New System.Drawing.Size(59, 17)
        Me.rbtFacturacionRapidaVueltoDirecto.TabIndex = 2
        Me.rbtFacturacionRapidaVueltoDirecto.Tag = "DIRECTO"
        Me.rbtFacturacionRapidaVueltoDirecto.Text = "Directo"
        Me.rbtFacturacionRapidaVueltoDirecto.UseVisualStyleBackColor = True
        '
        'rbtFacturacionRapidaVueltoNoOfrecer
        '
        Me.rbtFacturacionRapidaVueltoNoOfrecer.AutoSize = True
        Me.rbtFacturacionRapidaVueltoNoOfrecer.Location = New System.Drawing.Point(86, 18)
        Me.rbtFacturacionRapidaVueltoNoOfrecer.Name = "rbtFacturacionRapidaVueltoNoOfrecer"
        Me.rbtFacturacionRapidaVueltoNoOfrecer.Size = New System.Drawing.Size(77, 17)
        Me.rbtFacturacionRapidaVueltoNoOfrecer.TabIndex = 1
        Me.rbtFacturacionRapidaVueltoNoOfrecer.Tag = "NOOFRECER"
        Me.rbtFacturacionRapidaVueltoNoOfrecer.Text = "No Ofrecer"
        Me.rbtFacturacionRapidaVueltoNoOfrecer.UseVisualStyleBackColor = True
        '
        'rbtFacturacionRapidaVueltoOfrecer
        '
        Me.rbtFacturacionRapidaVueltoOfrecer.AutoSize = True
        Me.rbtFacturacionRapidaVueltoOfrecer.Checked = True
        Me.rbtFacturacionRapidaVueltoOfrecer.Location = New System.Drawing.Point(21, 18)
        Me.rbtFacturacionRapidaVueltoOfrecer.Name = "rbtFacturacionRapidaVueltoOfrecer"
        Me.rbtFacturacionRapidaVueltoOfrecer.Size = New System.Drawing.Size(60, 17)
        Me.rbtFacturacionRapidaVueltoOfrecer.TabIndex = 0
        Me.rbtFacturacionRapidaVueltoOfrecer.TabStop = True
        Me.rbtFacturacionRapidaVueltoOfrecer.Tag = "OFRECER"
        Me.rbtFacturacionRapidaVueltoOfrecer.Text = "Ofrecer"
        Me.rbtFacturacionRapidaVueltoOfrecer.UseVisualStyleBackColor = True
        '
        'chbFacturacionControlaDNIConsumidorFinal
        '
        Me.chbFacturacionControlaDNIConsumidorFinal.AutoSize = True
        Me.chbFacturacionControlaDNIConsumidorFinal.BindearPropiedadControl = Nothing
        Me.chbFacturacionControlaDNIConsumidorFinal.BindearPropiedadEntidad = Nothing
        Me.chbFacturacionControlaDNIConsumidorFinal.ForeColorFocus = System.Drawing.Color.Red
        Me.chbFacturacionControlaDNIConsumidorFinal.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbFacturacionControlaDNIConsumidorFinal.IsPK = False
        Me.chbFacturacionControlaDNIConsumidorFinal.IsRequired = False
        Me.chbFacturacionControlaDNIConsumidorFinal.Key = Nothing
        Me.chbFacturacionControlaDNIConsumidorFinal.LabelAsoc = Nothing
        Me.chbFacturacionControlaDNIConsumidorFinal.Location = New System.Drawing.Point(536, 373)
        Me.chbFacturacionControlaDNIConsumidorFinal.Name = "chbFacturacionControlaDNIConsumidorFinal"
        Me.chbFacturacionControlaDNIConsumidorFinal.Size = New System.Drawing.Size(285, 17)
        Me.chbFacturacionControlaDNIConsumidorFinal.TabIndex = 84
        Me.chbFacturacionControlaDNIConsumidorFinal.Tag = "FACTURACIONCLIENTECONTROLADNICF"
        Me.chbFacturacionControlaDNIConsumidorFinal.Text = "Graba Libro NO: Controla DNI Cliente Consumidor Final"
        Me.chbFacturacionControlaDNIConsumidorFinal.UseVisualStyleBackColor = True
        '
        'chbFacturacionRemitoTranspCalculaBultos
        '
        Me.chbFacturacionRemitoTranspCalculaBultos.BindearPropiedadControl = Nothing
        Me.chbFacturacionRemitoTranspCalculaBultos.BindearPropiedadEntidad = Nothing
        Me.chbFacturacionRemitoTranspCalculaBultos.ForeColorFocus = System.Drawing.Color.Red
        Me.chbFacturacionRemitoTranspCalculaBultos.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbFacturacionRemitoTranspCalculaBultos.IsPK = False
        Me.chbFacturacionRemitoTranspCalculaBultos.IsRequired = False
        Me.chbFacturacionRemitoTranspCalculaBultos.Key = Nothing
        Me.chbFacturacionRemitoTranspCalculaBultos.LabelAsoc = Nothing
        Me.chbFacturacionRemitoTranspCalculaBultos.Location = New System.Drawing.Point(30, 130)
        Me.chbFacturacionRemitoTranspCalculaBultos.Name = "chbFacturacionRemitoTranspCalculaBultos"
        Me.chbFacturacionRemitoTranspCalculaBultos.Size = New System.Drawing.Size(194, 24)
        Me.chbFacturacionRemitoTranspCalculaBultos.TabIndex = 62
        Me.chbFacturacionRemitoTranspCalculaBultos.Tag = "FACTURACIONREMITOTRANSPCALCULABULTOS"
        Me.chbFacturacionRemitoTranspCalculaBultos.Text = "Remito Transportista Calcula Bultos"
        Me.chbFacturacionRemitoTranspCalculaBultos.UseVisualStyleBackColor = True
        '
        'chbFacturacionRemitoTranspUtilizaLote
        '
        Me.chbFacturacionRemitoTranspUtilizaLote.BindearPropiedadControl = Nothing
        Me.chbFacturacionRemitoTranspUtilizaLote.BindearPropiedadEntidad = Nothing
        Me.chbFacturacionRemitoTranspUtilizaLote.ForeColorFocus = System.Drawing.Color.Red
        Me.chbFacturacionRemitoTranspUtilizaLote.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbFacturacionRemitoTranspUtilizaLote.IsPK = False
        Me.chbFacturacionRemitoTranspUtilizaLote.IsRequired = False
        Me.chbFacturacionRemitoTranspUtilizaLote.Key = Nothing
        Me.chbFacturacionRemitoTranspUtilizaLote.LabelAsoc = Nothing
        Me.chbFacturacionRemitoTranspUtilizaLote.Location = New System.Drawing.Point(30, 100)
        Me.chbFacturacionRemitoTranspUtilizaLote.Name = "chbFacturacionRemitoTranspUtilizaLote"
        Me.chbFacturacionRemitoTranspUtilizaLote.Size = New System.Drawing.Size(194, 24)
        Me.chbFacturacionRemitoTranspUtilizaLote.TabIndex = 61
        Me.chbFacturacionRemitoTranspUtilizaLote.Tag = "FACTURACIONREMITOTRANSPUTILIZALOTE"
        Me.chbFacturacionRemitoTranspUtilizaLote.Text = "Remito Transportista Utiliza Lote"
        Me.chbFacturacionRemitoTranspUtilizaLote.UseVisualStyleBackColor = True
        '
        'chbFacturacionIgnorarPCdeCaja
        '
        Me.chbFacturacionIgnorarPCdeCaja.AutoSize = True
        Me.chbFacturacionIgnorarPCdeCaja.BindearPropiedadControl = Nothing
        Me.chbFacturacionIgnorarPCdeCaja.BindearPropiedadEntidad = Nothing
        Me.chbFacturacionIgnorarPCdeCaja.ForeColorFocus = System.Drawing.Color.Red
        Me.chbFacturacionIgnorarPCdeCaja.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbFacturacionIgnorarPCdeCaja.IsPK = False
        Me.chbFacturacionIgnorarPCdeCaja.IsRequired = False
        Me.chbFacturacionIgnorarPCdeCaja.Key = Nothing
        Me.chbFacturacionIgnorarPCdeCaja.LabelAsoc = Nothing
        Me.chbFacturacionIgnorarPCdeCaja.Location = New System.Drawing.Point(30, 71)
        Me.chbFacturacionIgnorarPCdeCaja.Name = "chbFacturacionIgnorarPCdeCaja"
        Me.chbFacturacionIgnorarPCdeCaja.Size = New System.Drawing.Size(115, 17)
        Me.chbFacturacionIgnorarPCdeCaja.TabIndex = 60
        Me.chbFacturacionIgnorarPCdeCaja.Tag = "FACTURACIONIGNORARPCDECAJA"
        Me.chbFacturacionIgnorarPCdeCaja.Text = "Ignorar PC de Caja"
        Me.chbFacturacionIgnorarPCdeCaja.UseVisualStyleBackColor = True
        '
        'chbPorCtaOrden
        '
        Me.chbPorCtaOrden.BindearPropiedadControl = Nothing
        Me.chbPorCtaOrden.BindearPropiedadEntidad = Nothing
        Me.chbPorCtaOrden.ForeColorFocus = System.Drawing.Color.Red
        Me.chbPorCtaOrden.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbPorCtaOrden.IsPK = False
        Me.chbPorCtaOrden.IsRequired = False
        Me.chbPorCtaOrden.Key = Nothing
        Me.chbPorCtaOrden.LabelAsoc = Nothing
        Me.chbPorCtaOrden.Location = New System.Drawing.Point(30, 292)
        Me.chbPorCtaOrden.Name = "chbPorCtaOrden"
        Me.chbPorCtaOrden.Size = New System.Drawing.Size(246, 21)
        Me.chbPorCtaOrden.TabIndex = 65
        Me.chbPorCtaOrden.Tag = "FACTURACIONPORCUENTAYORDEN"
        Me.chbPorCtaOrden.Text = "Permite Facturar por Cuenta y Orden"
        Me.chbPorCtaOrden.UseVisualStyleBackColor = True
        '
        'chbFacturacionPermiteCantidadNegativaAcumulada
        '
        Me.chbFacturacionPermiteCantidadNegativaAcumulada.BindearPropiedadControl = Nothing
        Me.chbFacturacionPermiteCantidadNegativaAcumulada.BindearPropiedadEntidad = Nothing
        Me.chbFacturacionPermiteCantidadNegativaAcumulada.ForeColorFocus = System.Drawing.Color.Red
        Me.chbFacturacionPermiteCantidadNegativaAcumulada.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbFacturacionPermiteCantidadNegativaAcumulada.IsPK = False
        Me.chbFacturacionPermiteCantidadNegativaAcumulada.IsRequired = False
        Me.chbFacturacionPermiteCantidadNegativaAcumulada.Key = Nothing
        Me.chbFacturacionPermiteCantidadNegativaAcumulada.LabelAsoc = Nothing
        Me.chbFacturacionPermiteCantidadNegativaAcumulada.Location = New System.Drawing.Point(536, 223)
        Me.chbFacturacionPermiteCantidadNegativaAcumulada.Name = "chbFacturacionPermiteCantidadNegativaAcumulada"
        Me.chbFacturacionPermiteCantidadNegativaAcumulada.Size = New System.Drawing.Size(228, 25)
        Me.chbFacturacionPermiteCantidadNegativaAcumulada.TabIndex = 78
        Me.chbFacturacionPermiteCantidadNegativaAcumulada.Tag = "FACTURACIONPERMITECANTIDADNEGATIVAACUMULADA"
        Me.chbFacturacionPermiteCantidadNegativaAcumulada.Text = "Permite Cantidad en Negativo Acumulada"
        Me.chbFacturacionPermiteCantidadNegativaAcumulada.UseVisualStyleBackColor = True
        '
        'grpComisionVendedor
        '
        Me.grpComisionVendedor.Controls.Add(Me.rbtComisionVendedorMarcaRubro)
        Me.grpComisionVendedor.Controls.Add(Me.rbtComisionVendedorRubroMarca)
        Me.grpComisionVendedor.Location = New System.Drawing.Point(714, 93)
        Me.grpComisionVendedor.Name = "grpComisionVendedor"
        Me.grpComisionVendedor.Size = New System.Drawing.Size(150, 61)
        Me.grpComisionVendedor.TabIndex = 75
        Me.grpComisionVendedor.TabStop = False
        Me.grpComisionVendedor.Tag = "COMISIONVENDEDOR"
        Me.grpComisionVendedor.Text = "Comisión Vendedor"
        '
        'rbtComisionVendedorMarcaRubro
        '
        Me.rbtComisionVendedorMarcaRubro.AutoSize = True
        Me.rbtComisionVendedorMarcaRubro.Location = New System.Drawing.Point(6, 39)
        Me.rbtComisionVendedorMarcaRubro.Name = "rbtComisionVendedorMarcaRubro"
        Me.rbtComisionVendedorMarcaRubro.Size = New System.Drawing.Size(136, 17)
        Me.rbtComisionVendedorMarcaRubro.TabIndex = 1
        Me.rbtComisionVendedorMarcaRubro.Tag = "VENDEDORMARCARUBRO"
        Me.rbtComisionVendedorMarcaRubro.Text = "Vendedor-Marca-Rubro"
        Me.rbtComisionVendedorMarcaRubro.UseVisualStyleBackColor = True
        '
        'rbtComisionVendedorRubroMarca
        '
        Me.rbtComisionVendedorRubroMarca.AutoSize = True
        Me.rbtComisionVendedorRubroMarca.Checked = True
        Me.rbtComisionVendedorRubroMarca.Location = New System.Drawing.Point(6, 16)
        Me.rbtComisionVendedorRubroMarca.Name = "rbtComisionVendedorRubroMarca"
        Me.rbtComisionVendedorRubroMarca.Size = New System.Drawing.Size(136, 17)
        Me.rbtComisionVendedorRubroMarca.TabIndex = 0
        Me.rbtComisionVendedorRubroMarca.TabStop = True
        Me.rbtComisionVendedorRubroMarca.Tag = "VENDEDORRUBROMARCA"
        Me.rbtComisionVendedorRubroMarca.Text = "Vendedor-Rubro-Marca"
        Me.rbtComisionVendedorRubroMarca.UseVisualStyleBackColor = True
        '
        'chbFacturacionComprobanteGrabaLibroNoFuerzaConsFinal
        '
        Me.chbFacturacionComprobanteGrabaLibroNoFuerzaConsFinal.BindearPropiedadControl = Nothing
        Me.chbFacturacionComprobanteGrabaLibroNoFuerzaConsFinal.BindearPropiedadEntidad = Nothing
        Me.chbFacturacionComprobanteGrabaLibroNoFuerzaConsFinal.ForeColorFocus = System.Drawing.Color.Red
        Me.chbFacturacionComprobanteGrabaLibroNoFuerzaConsFinal.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbFacturacionComprobanteGrabaLibroNoFuerzaConsFinal.IsPK = False
        Me.chbFacturacionComprobanteGrabaLibroNoFuerzaConsFinal.IsRequired = False
        Me.chbFacturacionComprobanteGrabaLibroNoFuerzaConsFinal.Key = Nothing
        Me.chbFacturacionComprobanteGrabaLibroNoFuerzaConsFinal.LabelAsoc = Nothing
        Me.chbFacturacionComprobanteGrabaLibroNoFuerzaConsFinal.Location = New System.Drawing.Point(536, 161)
        Me.chbFacturacionComprobanteGrabaLibroNoFuerzaConsFinal.Name = "chbFacturacionComprobanteGrabaLibroNoFuerzaConsFinal"
        Me.chbFacturacionComprobanteGrabaLibroNoFuerzaConsFinal.Size = New System.Drawing.Size(243, 25)
        Me.chbFacturacionComprobanteGrabaLibroNoFuerzaConsFinal.TabIndex = 76
        Me.chbFacturacionComprobanteGrabaLibroNoFuerzaConsFinal.Tag = "FACTURACIONGRABALIBRONOFUERZACONSFINAL"
        Me.chbFacturacionComprobanteGrabaLibroNoFuerzaConsFinal.Text = "Comprobante Graba Libro NO: Fuerza C.Final"
        Me.chbFacturacionComprobanteGrabaLibroNoFuerzaConsFinal.UseVisualStyleBackColor = True
        '
        'chbFacturacionModificaDescripSolicitaPrecio
        '
        Me.chbFacturacionModificaDescripSolicitaPrecio.BindearPropiedadControl = Nothing
        Me.chbFacturacionModificaDescripSolicitaPrecio.BindearPropiedadEntidad = Nothing
        Me.chbFacturacionModificaDescripSolicitaPrecio.ForeColorFocus = System.Drawing.Color.Red
        Me.chbFacturacionModificaDescripSolicitaPrecio.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbFacturacionModificaDescripSolicitaPrecio.IsPK = False
        Me.chbFacturacionModificaDescripSolicitaPrecio.IsRequired = False
        Me.chbFacturacionModificaDescripSolicitaPrecio.Key = Nothing
        Me.chbFacturacionModificaDescripSolicitaPrecio.LabelAsoc = Nothing
        Me.chbFacturacionModificaDescripSolicitaPrecio.Location = New System.Drawing.Point(536, 312)
        Me.chbFacturacionModificaDescripSolicitaPrecio.Name = "chbFacturacionModificaDescripSolicitaPrecio"
        Me.chbFacturacionModificaDescripSolicitaPrecio.Size = New System.Drawing.Size(246, 25)
        Me.chbFacturacionModificaDescripSolicitaPrecio.TabIndex = 81
        Me.chbFacturacionModificaDescripSolicitaPrecio.Text = "Modifica Descripcion, solicita Precio"
        Me.chbFacturacionModificaDescripSolicitaPrecio.UseVisualStyleBackColor = True
        '
        'chbFacturacionModificaDescripSolicKilos
        '
        Me.chbFacturacionModificaDescripSolicKilos.BindearPropiedadControl = Nothing
        Me.chbFacturacionModificaDescripSolicKilos.BindearPropiedadEntidad = Nothing
        Me.chbFacturacionModificaDescripSolicKilos.ForeColorFocus = System.Drawing.Color.Red
        Me.chbFacturacionModificaDescripSolicKilos.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbFacturacionModificaDescripSolicKilos.IsPK = False
        Me.chbFacturacionModificaDescripSolicKilos.IsRequired = False
        Me.chbFacturacionModificaDescripSolicKilos.Key = Nothing
        Me.chbFacturacionModificaDescripSolicKilos.LabelAsoc = Nothing
        Me.chbFacturacionModificaDescripSolicKilos.Location = New System.Drawing.Point(536, 285)
        Me.chbFacturacionModificaDescripSolicKilos.Name = "chbFacturacionModificaDescripSolicKilos"
        Me.chbFacturacionModificaDescripSolicKilos.Size = New System.Drawing.Size(246, 25)
        Me.chbFacturacionModificaDescripSolicKilos.TabIndex = 80
        Me.chbFacturacionModificaDescripSolicKilos.Tag = "FACTURACIONMODIFICADESCRIPSOLICITAKILOS"
        Me.chbFacturacionModificaDescripSolicKilos.Text = "Modifica Descripcion, solicita Kilos"
        Me.chbFacturacionModificaDescripSolicKilos.UseVisualStyleBackColor = True
        '
        'chbFacturacionModificaDescriProdCantidad
        '
        Me.chbFacturacionModificaDescriProdCantidad.BindearPropiedadControl = Nothing
        Me.chbFacturacionModificaDescriProdCantidad.BindearPropiedadEntidad = Nothing
        Me.chbFacturacionModificaDescriProdCantidad.ForeColorFocus = System.Drawing.Color.Red
        Me.chbFacturacionModificaDescriProdCantidad.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbFacturacionModificaDescriProdCantidad.IsPK = False
        Me.chbFacturacionModificaDescriProdCantidad.IsRequired = False
        Me.chbFacturacionModificaDescriProdCantidad.Key = Nothing
        Me.chbFacturacionModificaDescriProdCantidad.LabelAsoc = Nothing
        Me.chbFacturacionModificaDescriProdCantidad.Location = New System.Drawing.Point(536, 256)
        Me.chbFacturacionModificaDescriProdCantidad.Name = "chbFacturacionModificaDescriProdCantidad"
        Me.chbFacturacionModificaDescriProdCantidad.Size = New System.Drawing.Size(246, 25)
        Me.chbFacturacionModificaDescriProdCantidad.TabIndex = 79
        Me.chbFacturacionModificaDescriProdCantidad.Tag = "FACTURACIONMODIFICADESCRIPRODCANTIDAD"
        Me.chbFacturacionModificaDescriProdCantidad.Text = "Modifica Descripcion, se para en Cantidad"
        Me.chbFacturacionModificaDescriProdCantidad.UseVisualStyleBackColor = True
        '
        'lblDescuentoMaximo
        '
        Me.lblDescuentoMaximo.AutoSize = True
        Me.lblDescuentoMaximo.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblDescuentoMaximo.LabelAsoc = Nothing
        Me.lblDescuentoMaximo.Location = New System.Drawing.Point(574, 18)
        Me.lblDescuentoMaximo.Name = "lblDescuentoMaximo"
        Me.lblDescuentoMaximo.Size = New System.Drawing.Size(109, 13)
        Me.lblDescuentoMaximo.TabIndex = 69
        Me.lblDescuentoMaximo.Text = "% Descuento Máximo"
        '
        'chbFacturacionPermiteCantidadNegativa
        '
        Me.chbFacturacionPermiteCantidadNegativa.BindearPropiedadControl = Nothing
        Me.chbFacturacionPermiteCantidadNegativa.BindearPropiedadEntidad = Nothing
        Me.chbFacturacionPermiteCantidadNegativa.ForeColorFocus = System.Drawing.Color.Red
        Me.chbFacturacionPermiteCantidadNegativa.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbFacturacionPermiteCantidadNegativa.IsPK = False
        Me.chbFacturacionPermiteCantidadNegativa.IsRequired = False
        Me.chbFacturacionPermiteCantidadNegativa.Key = Nothing
        Me.chbFacturacionPermiteCantidadNegativa.LabelAsoc = Nothing
        Me.chbFacturacionPermiteCantidadNegativa.Location = New System.Drawing.Point(536, 192)
        Me.chbFacturacionPermiteCantidadNegativa.Name = "chbFacturacionPermiteCantidadNegativa"
        Me.chbFacturacionPermiteCantidadNegativa.Size = New System.Drawing.Size(205, 25)
        Me.chbFacturacionPermiteCantidadNegativa.TabIndex = 77
        Me.chbFacturacionPermiteCantidadNegativa.Tag = "FACTURACIONPERMITECANTIDADNEGATIVA"
        Me.chbFacturacionPermiteCantidadNegativa.Text = "Permite Cantidad en Negativo"
        Me.chbFacturacionPermiteCantidadNegativa.UseVisualStyleBackColor = True
        '
        'chbSaldoTomaActual
        '
        Me.chbSaldoTomaActual.BindearPropiedadControl = Nothing
        Me.chbSaldoTomaActual.BindearPropiedadEntidad = Nothing
        Me.chbSaldoTomaActual.ForeColorFocus = System.Drawing.Color.Red
        Me.chbSaldoTomaActual.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbSaldoTomaActual.IsPK = False
        Me.chbSaldoTomaActual.IsRequired = False
        Me.chbSaldoTomaActual.Key = Nothing
        Me.chbSaldoTomaActual.LabelAsoc = Nothing
        Me.chbSaldoTomaActual.Location = New System.Drawing.Point(170, 320)
        Me.chbSaldoTomaActual.Name = "chbSaldoTomaActual"
        Me.chbSaldoTomaActual.Size = New System.Drawing.Size(196, 21)
        Me.chbSaldoTomaActual.TabIndex = 67
        Me.chbSaldoTomaActual.Text = "Utiliza Saldo Actual (sino Historico)"
        Me.chbSaldoTomaActual.UseVisualStyleBackColor = True
        '
        'chbSaldoContemplaHora
        '
        Me.chbSaldoContemplaHora.BindearPropiedadControl = Nothing
        Me.chbSaldoContemplaHora.BindearPropiedadEntidad = Nothing
        Me.chbSaldoContemplaHora.ForeColorFocus = System.Drawing.Color.Red
        Me.chbSaldoContemplaHora.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbSaldoContemplaHora.IsPK = False
        Me.chbSaldoContemplaHora.IsRequired = False
        Me.chbSaldoContemplaHora.Key = Nothing
        Me.chbSaldoContemplaHora.LabelAsoc = Nothing
        Me.chbSaldoContemplaHora.Location = New System.Drawing.Point(30, 318)
        Me.chbSaldoContemplaHora.Name = "chbSaldoContemplaHora"
        Me.chbSaldoContemplaHora.Size = New System.Drawing.Size(134, 21)
        Me.chbSaldoContemplaHora.TabIndex = 66
        Me.chbSaldoContemplaHora.Tag = "FACTURACIONSALDOCONTEMPLAHORA"
        Me.chbSaldoContemplaHora.Text = "Saldo Contempla Hora"
        Me.chbSaldoContemplaHora.UseVisualStyleBackColor = True
        '
        'txtDescuentoMaximo
        '
        Me.txtDescuentoMaximo.BindearPropiedadControl = Nothing
        Me.txtDescuentoMaximo.BindearPropiedadEntidad = Nothing
        Me.txtDescuentoMaximo.ForeColorFocus = System.Drawing.Color.Red
        Me.txtDescuentoMaximo.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtDescuentoMaximo.Formato = "#0.00"
        Me.txtDescuentoMaximo.IsDecimal = True
        Me.txtDescuentoMaximo.IsNumber = True
        Me.txtDescuentoMaximo.IsPK = False
        Me.txtDescuentoMaximo.IsRequired = False
        Me.txtDescuentoMaximo.Key = ""
        Me.txtDescuentoMaximo.LabelAsoc = Nothing
        Me.txtDescuentoMaximo.Location = New System.Drawing.Point(536, 11)
        Me.txtDescuentoMaximo.MaxLength = 6
        Me.txtDescuentoMaximo.Name = "txtDescuentoMaximo"
        Me.txtDescuentoMaximo.Size = New System.Drawing.Size(35, 20)
        Me.txtDescuentoMaximo.TabIndex = 68
        Me.txtDescuentoMaximo.Tag = "DESCUENTOMAXIMO"
        Me.txtDescuentoMaximo.Text = "0"
        Me.txtDescuentoMaximo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'chbFacturacionAvisaProductosEnCero
        '
        Me.chbFacturacionAvisaProductosEnCero.BindearPropiedadControl = Nothing
        Me.chbFacturacionAvisaProductosEnCero.BindearPropiedadEntidad = Nothing
        Me.chbFacturacionAvisaProductosEnCero.ForeColorFocus = System.Drawing.Color.Red
        Me.chbFacturacionAvisaProductosEnCero.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbFacturacionAvisaProductosEnCero.IsPK = False
        Me.chbFacturacionAvisaProductosEnCero.IsRequired = False
        Me.chbFacturacionAvisaProductosEnCero.Key = Nothing
        Me.chbFacturacionAvisaProductosEnCero.LabelAsoc = Nothing
        Me.chbFacturacionAvisaProductosEnCero.Location = New System.Drawing.Point(30, 264)
        Me.chbFacturacionAvisaProductosEnCero.Name = "chbFacturacionAvisaProductosEnCero"
        Me.chbFacturacionAvisaProductosEnCero.Size = New System.Drawing.Size(246, 21)
        Me.chbFacturacionAvisaProductosEnCero.TabIndex = 64
        Me.chbFacturacionAvisaProductosEnCero.Tag = "FACTURACIONAVISAPRODUCTOSENCERO"
        Me.chbFacturacionAvisaProductosEnCero.Text = "Avisa si el Producto tiene Precio Cero"
        Me.chbFacturacionAvisaProductosEnCero.UseVisualStyleBackColor = True
        '
        'lblCalculoComisionVendedor
        '
        Me.lblCalculoComisionVendedor.AutoSize = True
        Me.lblCalculoComisionVendedor.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblCalculoComisionVendedor.LabelAsoc = Nothing
        Me.lblCalculoComisionVendedor.Location = New System.Drawing.Point(537, 102)
        Me.lblCalculoComisionVendedor.Name = "lblCalculoComisionVendedor"
        Me.lblCalculoComisionVendedor.Size = New System.Drawing.Size(171, 13)
        Me.lblCalculoComisionVendedor.TabIndex = 73
        Me.lblCalculoComisionVendedor.Text = "Calculo de Comision del Vendedor."
        '
        'chbFacturacionIgnorarUltimoDigitoCB
        '
        Me.chbFacturacionIgnorarUltimoDigitoCB.BindearPropiedadControl = Nothing
        Me.chbFacturacionIgnorarUltimoDigitoCB.BindearPropiedadEntidad = Nothing
        Me.chbFacturacionIgnorarUltimoDigitoCB.ForeColorFocus = System.Drawing.Color.Red
        Me.chbFacturacionIgnorarUltimoDigitoCB.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbFacturacionIgnorarUltimoDigitoCB.IsPK = False
        Me.chbFacturacionIgnorarUltimoDigitoCB.IsRequired = False
        Me.chbFacturacionIgnorarUltimoDigitoCB.Key = Nothing
        Me.chbFacturacionIgnorarUltimoDigitoCB.LabelAsoc = Nothing
        Me.chbFacturacionIgnorarUltimoDigitoCB.Location = New System.Drawing.Point(30, 237)
        Me.chbFacturacionIgnorarUltimoDigitoCB.Name = "chbFacturacionIgnorarUltimoDigitoCB"
        Me.chbFacturacionIgnorarUltimoDigitoCB.Size = New System.Drawing.Size(246, 21)
        Me.chbFacturacionIgnorarUltimoDigitoCB.TabIndex = 63
        Me.chbFacturacionIgnorarUltimoDigitoCB.Tag = "FACTURACIONIGNORARULTIMODIGITOCB"
        Me.chbFacturacionIgnorarUltimoDigitoCB.Text = "Ignorar el Ultimo Digito del Codigo de Barras"
        Me.chbFacturacionIgnorarUltimoDigitoCB.UseVisualStyleBackColor = True
        '
        'cmbCalculoComisionVendedor
        '
        Me.cmbCalculoComisionVendedor.BindearPropiedadControl = Nothing
        Me.cmbCalculoComisionVendedor.BindearPropiedadEntidad = Nothing
        Me.cmbCalculoComisionVendedor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbCalculoComisionVendedor.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbCalculoComisionVendedor.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbCalculoComisionVendedor.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbCalculoComisionVendedor.FormattingEnabled = True
        Me.cmbCalculoComisionVendedor.IsPK = False
        Me.cmbCalculoComisionVendedor.IsRequired = False
        Me.cmbCalculoComisionVendedor.Items.AddRange(New Object() {"FACTURACION", "LISTADO"})
        Me.cmbCalculoComisionVendedor.Key = Nothing
        Me.cmbCalculoComisionVendedor.LabelAsoc = Nothing
        Me.cmbCalculoComisionVendedor.Location = New System.Drawing.Point(537, 121)
        Me.cmbCalculoComisionVendedor.Name = "cmbCalculoComisionVendedor"
        Me.cmbCalculoComisionVendedor.Size = New System.Drawing.Size(104, 21)
        Me.cmbCalculoComisionVendedor.TabIndex = 74
        Me.cmbCalculoComisionVendedor.Tag = "CALCULOCOMISIONVENDEDOR"
        '
        'lblBusquedaClienteDefault
        '
        Me.lblBusquedaClienteDefault.AutoSize = True
        Me.lblBusquedaClienteDefault.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblBusquedaClienteDefault.LabelAsoc = Nothing
        Me.lblBusquedaClienteDefault.Location = New System.Drawing.Point(28, 347)
        Me.lblBusquedaClienteDefault.Name = "lblBusquedaClienteDefault"
        Me.lblBusquedaClienteDefault.Size = New System.Drawing.Size(220, 13)
        Me.lblBusquedaClienteDefault.TabIndex = 86
        Me.lblBusquedaClienteDefault.Text = "Facturacion Realiza Busqueda de Cliente por"
        '
        'cmbBusquedaClienteDefault
        '
        Me.cmbBusquedaClienteDefault.BindearPropiedadControl = Nothing
        Me.cmbBusquedaClienteDefault.BindearPropiedadEntidad = Nothing
        Me.cmbBusquedaClienteDefault.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbBusquedaClienteDefault.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbBusquedaClienteDefault.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbBusquedaClienteDefault.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbBusquedaClienteDefault.FormattingEnabled = True
        Me.cmbBusquedaClienteDefault.IsPK = False
        Me.cmbBusquedaClienteDefault.IsRequired = False
        Me.cmbBusquedaClienteDefault.Key = Nothing
        Me.cmbBusquedaClienteDefault.LabelAsoc = Me.lblBusquedaClienteDefault
        Me.cmbBusquedaClienteDefault.Location = New System.Drawing.Point(254, 344)
        Me.cmbBusquedaClienteDefault.Name = "cmbBusquedaClienteDefault"
        Me.cmbBusquedaClienteDefault.Size = New System.Drawing.Size(168, 21)
        Me.cmbBusquedaClienteDefault.TabIndex = 87
        Me.cmbBusquedaClienteDefault.Tag = "CALCULOCOMISIONVENDEDOR"
        '
        'chbSimulaPercepcionNGLibro
        '
        Me.chbSimulaPercepcionNGLibro.AutoSize = True
        Me.chbSimulaPercepcionNGLibro.BindearPropiedadControl = Nothing
        Me.chbSimulaPercepcionNGLibro.BindearPropiedadEntidad = Nothing
        Me.chbSimulaPercepcionNGLibro.ForeColorFocus = System.Drawing.Color.Red
        Me.chbSimulaPercepcionNGLibro.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbSimulaPercepcionNGLibro.IsPK = False
        Me.chbSimulaPercepcionNGLibro.IsRequired = False
        Me.chbSimulaPercepcionNGLibro.Key = Nothing
        Me.chbSimulaPercepcionNGLibro.LabelAsoc = Nothing
        Me.chbSimulaPercepcionNGLibro.Location = New System.Drawing.Point(31, 371)
        Me.chbSimulaPercepcionNGLibro.Name = "chbSimulaPercepcionNGLibro"
        Me.chbSimulaPercepcionNGLibro.Size = New System.Drawing.Size(292, 17)
        Me.chbSimulaPercepcionNGLibro.TabIndex = 90
        Me.chbSimulaPercepcionNGLibro.Text = "Simula Percepciones si el comprobante NO GRABA libro"
        Me.chbSimulaPercepcionNGLibro.UseVisualStyleBackColor = True
        '
        'ucConfVentas2
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.chbSimulaPercepcionNGLibro)
        Me.Controls.Add(Me.cmbBusquedaClienteDefault)
        Me.Controls.Add(Me.lblBusquedaClienteDefault)
        Me.Controls.Add(Me.grbPermitirControlarLimiteCredito)
        Me.Controls.Add(Me.txtDiasInvocacionComprobantes)
        Me.Controls.Add(Me.lblTopeCF)
        Me.Controls.Add(Me.txtControlTopeCF)
        Me.Controls.Add(Me.lblDiasInvocacionComprobantes)
        Me.Controls.Add(Me.chbPermiteModificarCliente)
        Me.Controls.Add(Me.grbFacturacionRapidaOfreceCalcularVuelto)
        Me.Controls.Add(Me.chbFacturacionControlaDNIConsumidorFinal)
        Me.Controls.Add(Me.chbFacturacionRemitoTranspCalculaBultos)
        Me.Controls.Add(Me.chbFacturacionRemitoTranspUtilizaLote)
        Me.Controls.Add(Me.chbFacturacionIgnorarPCdeCaja)
        Me.Controls.Add(Me.chbPorCtaOrden)
        Me.Controls.Add(Me.chbFacturacionPermiteCantidadNegativaAcumulada)
        Me.Controls.Add(Me.grpComisionVendedor)
        Me.Controls.Add(Me.chbFacturacionComprobanteGrabaLibroNoFuerzaConsFinal)
        Me.Controls.Add(Me.chbFacturacionModificaDescripSolicitaPrecio)
        Me.Controls.Add(Me.chbFacturacionModificaDescripSolicKilos)
        Me.Controls.Add(Me.chbFacturacionModificaDescriProdCantidad)
        Me.Controls.Add(Me.lblDescuentoMaximo)
        Me.Controls.Add(Me.chbFacturacionPermiteCantidadNegativa)
        Me.Controls.Add(Me.chbSaldoTomaActual)
        Me.Controls.Add(Me.chbSaldoContemplaHora)
        Me.Controls.Add(Me.txtDescuentoMaximo)
        Me.Controls.Add(Me.chbFacturacionAvisaProductosEnCero)
        Me.Controls.Add(Me.lblCalculoComisionVendedor)
        Me.Controls.Add(Me.chbFacturacionIgnorarUltimoDigitoCB)
        Me.Controls.Add(Me.cmbCalculoComisionVendedor)
        Me.Name = "ucConfVentas2"
        Me.Size = New System.Drawing.Size(900, 425)
        Me.Controls.SetChildIndex(Me.cmbCalculoComisionVendedor, 0)
        Me.Controls.SetChildIndex(Me.chbFacturacionIgnorarUltimoDigitoCB, 0)
        Me.Controls.SetChildIndex(Me.lblCalculoComisionVendedor, 0)
        Me.Controls.SetChildIndex(Me.chbFacturacionAvisaProductosEnCero, 0)
        Me.Controls.SetChildIndex(Me.txtDescuentoMaximo, 0)
        Me.Controls.SetChildIndex(Me.chbSaldoContemplaHora, 0)
        Me.Controls.SetChildIndex(Me.chbSaldoTomaActual, 0)
        Me.Controls.SetChildIndex(Me.chbFacturacionPermiteCantidadNegativa, 0)
        Me.Controls.SetChildIndex(Me.lblDescuentoMaximo, 0)
        Me.Controls.SetChildIndex(Me.chbFacturacionModificaDescriProdCantidad, 0)
        Me.Controls.SetChildIndex(Me.chbFacturacionModificaDescripSolicKilos, 0)
        Me.Controls.SetChildIndex(Me.chbFacturacionModificaDescripSolicitaPrecio, 0)
        Me.Controls.SetChildIndex(Me.chbFacturacionComprobanteGrabaLibroNoFuerzaConsFinal, 0)
        Me.Controls.SetChildIndex(Me.grpComisionVendedor, 0)
        Me.Controls.SetChildIndex(Me.chbFacturacionPermiteCantidadNegativaAcumulada, 0)
        Me.Controls.SetChildIndex(Me.chbPorCtaOrden, 0)
        Me.Controls.SetChildIndex(Me.chbFacturacionIgnorarPCdeCaja, 0)
        Me.Controls.SetChildIndex(Me.chbFacturacionRemitoTranspUtilizaLote, 0)
        Me.Controls.SetChildIndex(Me.chbFacturacionRemitoTranspCalculaBultos, 0)
        Me.Controls.SetChildIndex(Me.chbFacturacionControlaDNIConsumidorFinal, 0)
        Me.Controls.SetChildIndex(Me.grbFacturacionRapidaOfreceCalcularVuelto, 0)
        Me.Controls.SetChildIndex(Me.chbPermiteModificarCliente, 0)
        Me.Controls.SetChildIndex(Me.lblDiasInvocacionComprobantes, 0)
        Me.Controls.SetChildIndex(Me.txtControlTopeCF, 0)
        Me.Controls.SetChildIndex(Me.lblTopeCF, 0)
        Me.Controls.SetChildIndex(Me.txtDiasInvocacionComprobantes, 0)
        Me.Controls.SetChildIndex(Me.grbPermitirControlarLimiteCredito, 0)
        Me.Controls.SetChildIndex(Me.lblBusquedaClienteDefault, 0)
        Me.Controls.SetChildIndex(Me.cmbBusquedaClienteDefault, 0)
        Me.Controls.SetChildIndex(Me.chbSimulaPercepcionNGLibro, 0)
        Me.grbPermitirControlarLimiteCredito.ResumeLayout(False)
        Me.pnlPermitirControlarLimiteCredito_LimiteCredito.ResumeLayout(False)
        Me.pnlPermitirControlarLimiteCredito_LimiteCredito.PerformLayout()
        Me.pnlPermitirControlarLimiteCredito_LimiteDiasVencimiento.ResumeLayout(False)
        Me.pnlPermitirControlarLimiteCredito_LimiteDiasVencimiento.PerformLayout()
        Me.grbFacturacionRapidaOfreceCalcularVuelto.ResumeLayout(False)
        Me.grbFacturacionRapidaOfreceCalcularVuelto.PerformLayout()
        Me.grpComisionVendedor.ResumeLayout(False)
        Me.grpComisionVendedor.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents grbPermitirControlarLimiteCredito As GroupBox
   Friend WithEvents pnlPermitirControlarLimiteCredito_LimiteCredito As FlowLayoutPanel
   Friend WithEvents lblCreditoLimite As Controles.Label
   Friend WithEvents rbtPermitirFacturarCreditoLimite As RadioButton
   Friend WithEvents rbtNoPermitirFacturarCreditoLimite As RadioButton
   Friend WithEvents rbtAvisarPermitirFacturarCreditoLimite As RadioButton
   Friend WithEvents pnlPermitirControlarLimiteCredito_LimiteDiasVencimiento As FlowLayoutPanel
   Friend WithEvents lblLimiteDiasVto As Controles.Label
   Friend WithEvents rbtPermitirFacturarLimiteDiasVto As RadioButton
   Friend WithEvents rbtNoPermitirFacturarLimiteDiasVto As RadioButton
   Friend WithEvents rbtAvisarPermitirFacturarLimiteDiasVto As RadioButton
   Friend WithEvents txtDiasInvocacionComprobantes As Controles.TextBox
   Friend WithEvents lblDiasInvocacionComprobantes As Controles.Label
   Friend WithEvents lblTopeCF As Controles.Label
   Friend WithEvents txtControlTopeCF As Controles.TextBox
   Friend WithEvents chbPermiteModificarCliente As Controles.CheckBox
   Friend WithEvents grbFacturacionRapidaOfreceCalcularVuelto As GroupBox
   Friend WithEvents rbtFacturacionRapidaVueltoDirecto As RadioButton
   Friend WithEvents rbtFacturacionRapidaVueltoNoOfrecer As RadioButton
   Friend WithEvents rbtFacturacionRapidaVueltoOfrecer As RadioButton
   Friend WithEvents chbFacturacionControlaDNIConsumidorFinal As Controles.CheckBox
   Friend WithEvents chbFacturacionRemitoTranspCalculaBultos As Controles.CheckBox
   Friend WithEvents chbFacturacionRemitoTranspUtilizaLote As Controles.CheckBox
   Friend WithEvents chbFacturacionIgnorarPCdeCaja As Controles.CheckBox
   Friend WithEvents chbPorCtaOrden As Controles.CheckBox
   Friend WithEvents chbFacturacionPermiteCantidadNegativaAcumulada As Controles.CheckBox
   Friend WithEvents grpComisionVendedor As GroupBox
   Friend WithEvents rbtComisionVendedorMarcaRubro As RadioButton
   Friend WithEvents rbtComisionVendedorRubroMarca As RadioButton
   Friend WithEvents chbFacturacionComprobanteGrabaLibroNoFuerzaConsFinal As Controles.CheckBox
   Friend WithEvents chbFacturacionModificaDescripSolicitaPrecio As Controles.CheckBox
   Friend WithEvents chbFacturacionModificaDescripSolicKilos As Controles.CheckBox
   Friend WithEvents chbFacturacionModificaDescriProdCantidad As Controles.CheckBox
   Friend WithEvents lblDescuentoMaximo As Controles.Label
   Friend WithEvents chbFacturacionPermiteCantidadNegativa As Controles.CheckBox
   Friend WithEvents chbSaldoTomaActual As Controles.CheckBox
   Friend WithEvents chbSaldoContemplaHora As Controles.CheckBox
   Friend WithEvents txtDescuentoMaximo As Controles.TextBox
   Friend WithEvents chbFacturacionAvisaProductosEnCero As Controles.CheckBox
   Friend WithEvents lblCalculoComisionVendedor As Controles.Label
   Friend WithEvents chbFacturacionIgnorarUltimoDigitoCB As Controles.CheckBox
   Friend WithEvents cmbCalculoComisionVendedor As Controles.ComboBox
    Friend WithEvents lblBusquedaClienteDefault As Controles.Label
    Friend WithEvents cmbBusquedaClienteDefault As Controles.ComboBox
    Friend WithEvents chbSimulaPercepcionNGLibro As Controles.CheckBox
End Class
