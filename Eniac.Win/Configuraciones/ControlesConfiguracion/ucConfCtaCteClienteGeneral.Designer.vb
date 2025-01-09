<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ucConfCtaCteClienteGeneral
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
		Me.txtCantidadDiasDHRecibos = New Eniac.Controles.TextBox()
		Me.lblCantidadDiasDHRecibos = New Eniac.Controles.Label()
		Me.chbEnviaMailRecibo = New Eniac.Controles.CheckBox()
		Me.txtCantidadDiasVencimiento = New Eniac.Controles.TextBox()
		Me.lblCantidadDiasvto = New Eniac.Controles.Label()
		Me.txtFacturacionAsuntoEnvioMasivoEmailCtaCte = New Eniac.Controles.TextBox()
		Me.lblFacturacionAsuntoEnvioMasivoEmailCtaCte = New Eniac.Controles.Label()
		Me.Label16 = New Eniac.Controles.Label()
		Me.chbPintaCuotaCtaCteClientes = New Eniac.Controles.CheckBox()
		Me.chbVisualizaReciboAntesImprimir = New Eniac.Controles.CheckBox()
		Me.chbValidaEmisorElectronicoRecibos = New Eniac.Controles.CheckBox()
		Me.chbUtilizaCuotasVencCCClientes = New Eniac.Controles.CheckBox()
		Me.chbPermiteReciboSinAplicarComprobantes = New Eniac.Controles.CheckBox()
		Me.lblIdProductoDescuentoRecargo = New Eniac.Controles.Label()
		Me.txtIdProductoDescuentoRecargo = New Eniac.Controles.TextBox()
		Me.chbReciboSolicitaFecha = New Eniac.Controles.CheckBox()
		Me.chbReciboUtilizaDescuentoRecargo = New Eniac.Controles.CheckBox()
		Me.chkInteresesCalculoCompletoPrimerPago = New Eniac.Controles.CheckBox()
		Me.chbReciboIgnorarPCdeCaja = New Eniac.Controles.CheckBox()
		Me.txtMontoMinimoInteres = New Eniac.Controles.TextBox()
		Me.lblMontoMinimoInteres = New Eniac.Controles.Label()
		Me.chbReciboAplicaSaldoEnPesos = New Eniac.Controles.CheckBox()
		Me.chbCtaCteClientesSeparar = New Eniac.Controles.CheckBox()
		Me.chbPermiteModificarImporteInteresesRecibo = New Eniac.Controles.CheckBox()
		Me.chbCtaCteClientesPriorizarNCyANT = New Eniac.Controles.CheckBox()
		Me.chbReciboConciliaAutomaticamenteTransferencias = New Eniac.Controles.CheckBox()
		Me.chbCtaCteClientesPermiteComprobantesEmisionPosterior = New Eniac.Controles.CheckBox()
		Me.chbReciboComparteNumeracionEntreSucursales = New Eniac.Controles.CheckBox()
		Me.chbCtaCteClientesCalcularPromedios = New Eniac.Controles.CheckBox()
		Me.chbReciboMantieneNumModificada = New Eniac.Controles.CheckBox()
		Me.txtCategoriaCliente = New Eniac.Controles.TextBox()
		Me.lblCategoriaCliente = New Eniac.Controles.Label()
		Me.chkMontoAplicadoIncluyeIntereses = New Eniac.Controles.CheckBox()
		Me.txtInteresesAdicionalProporcionalDiario = New Eniac.Controles.TextBox()
		Me.lblInteresesAdicionalProporcionalDiario = New Eniac.Controles.Label()
		Me.chbCategoriaClienteRecibos = New Eniac.Controles.CheckBox()
		Me.chbCtaCteClientesReciboMuestraSaldosEnImpresion = New Eniac.Controles.CheckBox()
		Me.chbCalculoInteresFuturo = New Eniac.Controles.CheckBox()
		Me.SuspendLayout()
		'
		'txtCantidadDiasDHRecibos
		'
		Me.txtCantidadDiasDHRecibos.BindearPropiedadControl = Nothing
		Me.txtCantidadDiasDHRecibos.BindearPropiedadEntidad = Nothing
		Me.txtCantidadDiasDHRecibos.ForeColorFocus = System.Drawing.Color.Red
		Me.txtCantidadDiasDHRecibos.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
		Me.txtCantidadDiasDHRecibos.Formato = ""
		Me.txtCantidadDiasDHRecibos.IsDecimal = True
		Me.txtCantidadDiasDHRecibos.IsNumber = True
		Me.txtCantidadDiasDHRecibos.IsPK = False
		Me.txtCantidadDiasDHRecibos.IsRequired = False
		Me.txtCantidadDiasDHRecibos.Key = ""
		Me.txtCantidadDiasDHRecibos.LabelAsoc = Me.lblCantidadDiasDHRecibos
		Me.txtCantidadDiasDHRecibos.Location = New System.Drawing.Point(792, 392)
		Me.txtCantidadDiasDHRecibos.MaxLength = 3
		Me.txtCantidadDiasDHRecibos.Name = "txtCantidadDiasDHRecibos"
		Me.txtCantidadDiasDHRecibos.Size = New System.Drawing.Size(46, 20)
		Me.txtCantidadDiasDHRecibos.TabIndex = 36
		Me.txtCantidadDiasDHRecibos.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
		'
		'lblCantidadDiasDHRecibos
		'
		Me.lblCantidadDiasDHRecibos.AutoSize = True
		Me.lblCantidadDiasDHRecibos.ForeColor = System.Drawing.SystemColors.WindowText
		Me.lblCantidadDiasDHRecibos.LabelAsoc = Nothing
		Me.lblCantidadDiasDHRecibos.Location = New System.Drawing.Point(483, 395)
		Me.lblCantidadDiasDHRecibos.Name = "lblCantidadDiasDHRecibos"
		Me.lblCantidadDiasDHRecibos.Size = New System.Drawing.Size(303, 13)
		Me.lblCantidadDiasDHRecibos.TabIndex = 35
		Me.lblCantidadDiasDHRecibos.Text = "Cantidad de dias para la consultad Debe-Haber desde recibos."
		'
		'chbEnviaMailRecibo
		'
		Me.chbEnviaMailRecibo.AutoSize = True
		Me.chbEnviaMailRecibo.BindearPropiedadControl = Nothing
		Me.chbEnviaMailRecibo.BindearPropiedadEntidad = Nothing
		Me.chbEnviaMailRecibo.ForeColorFocus = System.Drawing.Color.Red
		Me.chbEnviaMailRecibo.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
		Me.chbEnviaMailRecibo.IsPK = False
		Me.chbEnviaMailRecibo.IsRequired = False
		Me.chbEnviaMailRecibo.Key = Nothing
		Me.chbEnviaMailRecibo.LabelAsoc = Nothing
		Me.chbEnviaMailRecibo.Location = New System.Drawing.Point(42, 372)
		Me.chbEnviaMailRecibo.Name = "chbEnviaMailRecibo"
		Me.chbEnviaMailRecibo.Size = New System.Drawing.Size(191, 17)
		Me.chbEnviaMailRecibo.TabIndex = 18
		Me.chbEnviaMailRecibo.Tag = "ENVIAMAILCLIENTERECIBO"
		Me.chbEnviaMailRecibo.Text = "Envia Correo al Cliente con Recibo"
		Me.chbEnviaMailRecibo.UseVisualStyleBackColor = True
		'
		'txtCantidadDiasVencimiento
		'
		Me.txtCantidadDiasVencimiento.BindearPropiedadControl = Nothing
		Me.txtCantidadDiasVencimiento.BindearPropiedadEntidad = Nothing
		Me.txtCantidadDiasVencimiento.ForeColorFocus = System.Drawing.Color.Red
		Me.txtCantidadDiasVencimiento.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
		Me.txtCantidadDiasVencimiento.Formato = ""
		Me.txtCantidadDiasVencimiento.IsDecimal = True
		Me.txtCantidadDiasVencimiento.IsNumber = True
		Me.txtCantidadDiasVencimiento.IsPK = False
		Me.txtCantidadDiasVencimiento.IsRequired = False
		Me.txtCantidadDiasVencimiento.Key = ""
		Me.txtCantidadDiasVencimiento.LabelAsoc = Me.lblCantidadDiasvto
		Me.txtCantidadDiasVencimiento.Location = New System.Drawing.Point(673, 369)
		Me.txtCantidadDiasVencimiento.MaxLength = 3
		Me.txtCantidadDiasVencimiento.Name = "txtCantidadDiasVencimiento"
		Me.txtCantidadDiasVencimiento.Size = New System.Drawing.Size(46, 20)
		Me.txtCantidadDiasVencimiento.TabIndex = 34
		Me.txtCantidadDiasVencimiento.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
		'
		'lblCantidadDiasvto
		'
		Me.lblCantidadDiasvto.AutoSize = True
		Me.lblCantidadDiasvto.ForeColor = System.Drawing.SystemColors.WindowText
		Me.lblCantidadDiasvto.LabelAsoc = Nothing
		Me.lblCantidadDiasvto.Location = New System.Drawing.Point(483, 372)
		Me.lblCantidadDiasvto.Name = "lblCantidadDiasvto"
		Me.lblCantidadDiasvto.Size = New System.Drawing.Size(187, 13)
		Me.lblCantidadDiasvto.TabIndex = 33
		Me.lblCantidadDiasvto.Text = "Cantidad dias comprobantes vencidos"
		'
		'txtFacturacionAsuntoEnvioMasivoEmailCtaCte
		'
		Me.txtFacturacionAsuntoEnvioMasivoEmailCtaCte.BindearPropiedadControl = Nothing
		Me.txtFacturacionAsuntoEnvioMasivoEmailCtaCte.BindearPropiedadEntidad = Nothing
		Me.txtFacturacionAsuntoEnvioMasivoEmailCtaCte.ForeColorFocus = System.Drawing.Color.Red
		Me.txtFacturacionAsuntoEnvioMasivoEmailCtaCte.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
		Me.txtFacturacionAsuntoEnvioMasivoEmailCtaCte.Formato = ""
		Me.txtFacturacionAsuntoEnvioMasivoEmailCtaCte.IsDecimal = False
		Me.txtFacturacionAsuntoEnvioMasivoEmailCtaCte.IsNumber = False
		Me.txtFacturacionAsuntoEnvioMasivoEmailCtaCte.IsPK = False
		Me.txtFacturacionAsuntoEnvioMasivoEmailCtaCte.IsRequired = False
		Me.txtFacturacionAsuntoEnvioMasivoEmailCtaCte.Key = ""
		Me.txtFacturacionAsuntoEnvioMasivoEmailCtaCte.LabelAsoc = Me.lblFacturacionAsuntoEnvioMasivoEmailCtaCte
		Me.txtFacturacionAsuntoEnvioMasivoEmailCtaCte.Location = New System.Drawing.Point(486, 319)
		Me.txtFacturacionAsuntoEnvioMasivoEmailCtaCte.Name = "txtFacturacionAsuntoEnvioMasivoEmailCtaCte"
		Me.txtFacturacionAsuntoEnvioMasivoEmailCtaCte.Size = New System.Drawing.Size(373, 20)
		Me.txtFacturacionAsuntoEnvioMasivoEmailCtaCte.TabIndex = 31
		'
		'lblFacturacionAsuntoEnvioMasivoEmailCtaCte
		'
		Me.lblFacturacionAsuntoEnvioMasivoEmailCtaCte.AutoSize = True
		Me.lblFacturacionAsuntoEnvioMasivoEmailCtaCte.ForeColor = System.Drawing.SystemColors.WindowText
		Me.lblFacturacionAsuntoEnvioMasivoEmailCtaCte.LabelAsoc = Nothing
		Me.lblFacturacionAsuntoEnvioMasivoEmailCtaCte.Location = New System.Drawing.Point(483, 303)
		Me.lblFacturacionAsuntoEnvioMasivoEmailCtaCte.Name = "lblFacturacionAsuntoEnvioMasivoEmailCtaCte"
		Me.lblFacturacionAsuntoEnvioMasivoEmailCtaCte.Size = New System.Drawing.Size(132, 13)
		Me.lblFacturacionAsuntoEnvioMasivoEmailCtaCte.TabIndex = 30
		Me.lblFacturacionAsuntoEnvioMasivoEmailCtaCte.Text = "Asunto envio masivo email"
		'
		'Label16
		'
		Me.Label16.AutoSize = True
		Me.Label16.ForeColor = System.Drawing.SystemColors.WindowText
		Me.Label16.LabelAsoc = Nothing
		Me.Label16.Location = New System.Drawing.Point(484, 349)
		Me.Label16.Name = "Label16"
		Me.Label16.Size = New System.Drawing.Size(193, 13)
		Me.Label16.TabIndex = 32
		Me.Label16.Text = "{0} = Empresa / {1} = Nombre Fantasía"
		'
		'chbPintaCuotaCtaCteClientes
		'
		Me.chbPintaCuotaCtaCteClientes.AutoSize = True
		Me.chbPintaCuotaCtaCteClientes.BindearPropiedadControl = Nothing
		Me.chbPintaCuotaCtaCteClientes.BindearPropiedadEntidad = Nothing
		Me.chbPintaCuotaCtaCteClientes.ForeColorFocus = System.Drawing.Color.Red
		Me.chbPintaCuotaCtaCteClientes.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
		Me.chbPintaCuotaCtaCteClientes.IsPK = False
		Me.chbPintaCuotaCtaCteClientes.IsRequired = False
		Me.chbPintaCuotaCtaCteClientes.Key = Nothing
		Me.chbPintaCuotaCtaCteClientes.LabelAsoc = Nothing
		Me.chbPintaCuotaCtaCteClientes.Location = New System.Drawing.Point(486, 233)
		Me.chbPintaCuotaCtaCteClientes.Name = "chbPintaCuotaCtaCteClientes"
		Me.chbPintaCuotaCtaCteClientes.Size = New System.Drawing.Size(198, 17)
		Me.chbPintaCuotaCtaCteClientes.TabIndex = 29
		Me.chbPintaCuotaCtaCteClientes.Text = "Pinta Columna Cuota Cta Cte Cliente"
		Me.chbPintaCuotaCtaCteClientes.UseVisualStyleBackColor = True
		'
		'chbVisualizaReciboAntesImprimir
		'
		Me.chbVisualizaReciboAntesImprimir.AutoSize = True
		Me.chbVisualizaReciboAntesImprimir.BindearPropiedadControl = Nothing
		Me.chbVisualizaReciboAntesImprimir.BindearPropiedadEntidad = Nothing
		Me.chbVisualizaReciboAntesImprimir.ForeColorFocus = System.Drawing.Color.Red
		Me.chbVisualizaReciboAntesImprimir.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
		Me.chbVisualizaReciboAntesImprimir.IsPK = False
		Me.chbVisualizaReciboAntesImprimir.IsRequired = False
		Me.chbVisualizaReciboAntesImprimir.Key = Nothing
		Me.chbVisualizaReciboAntesImprimir.LabelAsoc = Nothing
		Me.chbVisualizaReciboAntesImprimir.Location = New System.Drawing.Point(42, 11)
		Me.chbVisualizaReciboAntesImprimir.Name = "chbVisualizaReciboAntesImprimir"
		Me.chbVisualizaReciboAntesImprimir.Size = New System.Drawing.Size(198, 17)
		Me.chbVisualizaReciboAntesImprimir.TabIndex = 0
		Me.chbVisualizaReciboAntesImprimir.Tag = "VISUALIZARECIBO"
		Me.chbVisualizaReciboAntesImprimir.Text = "Visualiza el Recibo Antes de Imprimir"
		Me.chbVisualizaReciboAntesImprimir.UseVisualStyleBackColor = True
		'
		'chbValidaEmisorElectronicoRecibos
		'
		Me.chbValidaEmisorElectronicoRecibos.AutoSize = True
		Me.chbValidaEmisorElectronicoRecibos.BindearPropiedadControl = Nothing
		Me.chbValidaEmisorElectronicoRecibos.BindearPropiedadEntidad = Nothing
		Me.chbValidaEmisorElectronicoRecibos.ForeColorFocus = System.Drawing.Color.Red
		Me.chbValidaEmisorElectronicoRecibos.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
		Me.chbValidaEmisorElectronicoRecibos.IsPK = False
		Me.chbValidaEmisorElectronicoRecibos.IsRequired = False
		Me.chbValidaEmisorElectronicoRecibos.Key = Nothing
		Me.chbValidaEmisorElectronicoRecibos.LabelAsoc = Nothing
		Me.chbValidaEmisorElectronicoRecibos.Location = New System.Drawing.Point(42, 326)
		Me.chbValidaEmisorElectronicoRecibos.Name = "chbValidaEmisorElectronicoRecibos"
		Me.chbValidaEmisorElectronicoRecibos.Size = New System.Drawing.Size(200, 17)
		Me.chbValidaEmisorElectronicoRecibos.TabIndex = 16
		Me.chbValidaEmisorElectronicoRecibos.Tag = "VALIDAEMISORELECTRONICOENRECIBOS"
		Me.chbValidaEmisorElectronicoRecibos.Text = "Valida emisor electronico en Recibos"
		Me.chbValidaEmisorElectronicoRecibos.UseVisualStyleBackColor = True
		'
		'chbUtilizaCuotasVencCCClientes
		'
		Me.chbUtilizaCuotasVencCCClientes.AutoSize = True
		Me.chbUtilizaCuotasVencCCClientes.BindearPropiedadControl = Nothing
		Me.chbUtilizaCuotasVencCCClientes.BindearPropiedadEntidad = Nothing
		Me.chbUtilizaCuotasVencCCClientes.ForeColorFocus = System.Drawing.Color.Red
		Me.chbUtilizaCuotasVencCCClientes.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
		Me.chbUtilizaCuotasVencCCClientes.IsPK = False
		Me.chbUtilizaCuotasVencCCClientes.IsRequired = False
		Me.chbUtilizaCuotasVencCCClientes.Key = Nothing
		Me.chbUtilizaCuotasVencCCClientes.LabelAsoc = Nothing
		Me.chbUtilizaCuotasVencCCClientes.Location = New System.Drawing.Point(42, 280)
		Me.chbUtilizaCuotasVencCCClientes.Name = "chbUtilizaCuotasVencCCClientes"
		Me.chbUtilizaCuotasVencCCClientes.Size = New System.Drawing.Size(170, 17)
		Me.chbUtilizaCuotasVencCCClientes.TabIndex = 14
		Me.chbUtilizaCuotasVencCCClientes.Tag = "UTILIZACUOTASOVENCIMIENTOCCCLIENTES"
		Me.chbUtilizaCuotasVencCCClientes.Text = "Utiliza Cuotas y/o Vencimiento"
		Me.chbUtilizaCuotasVencCCClientes.UseVisualStyleBackColor = True
		'
		'chbPermiteReciboSinAplicarComprobantes
		'
		Me.chbPermiteReciboSinAplicarComprobantes.AutoSize = True
		Me.chbPermiteReciboSinAplicarComprobantes.BindearPropiedadControl = Nothing
		Me.chbPermiteReciboSinAplicarComprobantes.BindearPropiedadEntidad = Nothing
		Me.chbPermiteReciboSinAplicarComprobantes.ForeColorFocus = System.Drawing.Color.Red
		Me.chbPermiteReciboSinAplicarComprobantes.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
		Me.chbPermiteReciboSinAplicarComprobantes.IsPK = False
		Me.chbPermiteReciboSinAplicarComprobantes.IsRequired = False
		Me.chbPermiteReciboSinAplicarComprobantes.Key = Nothing
		Me.chbPermiteReciboSinAplicarComprobantes.LabelAsoc = Nothing
		Me.chbPermiteReciboSinAplicarComprobantes.Location = New System.Drawing.Point(42, 34)
		Me.chbPermiteReciboSinAplicarComprobantes.Name = "chbPermiteReciboSinAplicarComprobantes"
		Me.chbPermiteReciboSinAplicarComprobantes.Size = New System.Drawing.Size(220, 17)
		Me.chbPermiteReciboSinAplicarComprobantes.TabIndex = 1
		Me.chbPermiteReciboSinAplicarComprobantes.Tag = "PERMITERECIBOSINAPLICARCOMPROBANTES"
		Me.chbPermiteReciboSinAplicarComprobantes.Text = "Permite Recibo sin Aplicar Comprobantes"
		Me.chbPermiteReciboSinAplicarComprobantes.UseVisualStyleBackColor = True
		'
		'lblIdProductoDescuentoRecargo
		'
		Me.lblIdProductoDescuentoRecargo.AutoSize = True
		Me.lblIdProductoDescuentoRecargo.LabelAsoc = Nothing
		Me.lblIdProductoDescuentoRecargo.Location = New System.Drawing.Point(42, 104)
		Me.lblIdProductoDescuentoRecargo.Name = "lblIdProductoDescuentoRecargo"
		Me.lblIdProductoDescuentoRecargo.Size = New System.Drawing.Size(294, 13)
		Me.lblIdProductoDescuentoRecargo.TabIndex = 4
		Me.lblIdProductoDescuentoRecargo.Text = "Codigo de Producto Administrativo para Descuento/Recargo"
		'
		'txtIdProductoDescuentoRecargo
		'
		Me.txtIdProductoDescuentoRecargo.BindearPropiedadControl = Nothing
		Me.txtIdProductoDescuentoRecargo.BindearPropiedadEntidad = Nothing
		Me.txtIdProductoDescuentoRecargo.ForeColorFocus = System.Drawing.Color.Red
		Me.txtIdProductoDescuentoRecargo.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
		Me.txtIdProductoDescuentoRecargo.Formato = ""
		Me.txtIdProductoDescuentoRecargo.IsDecimal = False
		Me.txtIdProductoDescuentoRecargo.IsNumber = False
		Me.txtIdProductoDescuentoRecargo.IsPK = False
		Me.txtIdProductoDescuentoRecargo.IsRequired = False
		Me.txtIdProductoDescuentoRecargo.Key = ""
		Me.txtIdProductoDescuentoRecargo.LabelAsoc = Me.lblIdProductoDescuentoRecargo
		Me.txtIdProductoDescuentoRecargo.Location = New System.Drawing.Point(342, 100)
		Me.txtIdProductoDescuentoRecargo.MaxLength = 15
		Me.txtIdProductoDescuentoRecargo.Name = "txtIdProductoDescuentoRecargo"
		Me.txtIdProductoDescuentoRecargo.Size = New System.Drawing.Size(120, 20)
		Me.txtIdProductoDescuentoRecargo.TabIndex = 5
		Me.txtIdProductoDescuentoRecargo.Tag = "IDPRODUCTODESCUENTORECARGO"
		Me.txtIdProductoDescuentoRecargo.Text = "0"
		Me.txtIdProductoDescuentoRecargo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
		'
		'chbReciboSolicitaFecha
		'
		Me.chbReciboSolicitaFecha.AutoSize = True
		Me.chbReciboSolicitaFecha.BindearPropiedadControl = Nothing
		Me.chbReciboSolicitaFecha.BindearPropiedadEntidad = Nothing
		Me.chbReciboSolicitaFecha.ForeColorFocus = System.Drawing.Color.Red
		Me.chbReciboSolicitaFecha.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
		Me.chbReciboSolicitaFecha.IsPK = False
		Me.chbReciboSolicitaFecha.IsRequired = False
		Me.chbReciboSolicitaFecha.Key = Nothing
		Me.chbReciboSolicitaFecha.LabelAsoc = Nothing
		Me.chbReciboSolicitaFecha.Location = New System.Drawing.Point(42, 56)
		Me.chbReciboSolicitaFecha.Name = "chbReciboSolicitaFecha"
		Me.chbReciboSolicitaFecha.Size = New System.Drawing.Size(268, 17)
		Me.chbReciboSolicitaFecha.TabIndex = 2
		Me.chbReciboSolicitaFecha.Tag = "RECIBOSOLICITAFECHA"
		Me.chbReciboSolicitaFecha.Text = "Recibo Solicita la Fecha luego de Cargar el Cliente."
		Me.chbReciboSolicitaFecha.UseVisualStyleBackColor = True
		'
		'chbReciboUtilizaDescuentoRecargo
		'
		Me.chbReciboUtilizaDescuentoRecargo.AutoSize = True
		Me.chbReciboUtilizaDescuentoRecargo.BindearPropiedadControl = Nothing
		Me.chbReciboUtilizaDescuentoRecargo.BindearPropiedadEntidad = Nothing
		Me.chbReciboUtilizaDescuentoRecargo.ForeColorFocus = System.Drawing.Color.Red
		Me.chbReciboUtilizaDescuentoRecargo.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
		Me.chbReciboUtilizaDescuentoRecargo.IsPK = False
		Me.chbReciboUtilizaDescuentoRecargo.IsRequired = False
		Me.chbReciboUtilizaDescuentoRecargo.Key = Nothing
		Me.chbReciboUtilizaDescuentoRecargo.LabelAsoc = Nothing
		Me.chbReciboUtilizaDescuentoRecargo.Location = New System.Drawing.Point(42, 79)
		Me.chbReciboUtilizaDescuentoRecargo.Name = "chbReciboUtilizaDescuentoRecargo"
		Me.chbReciboUtilizaDescuentoRecargo.Size = New System.Drawing.Size(192, 17)
		Me.chbReciboUtilizaDescuentoRecargo.TabIndex = 3
		Me.chbReciboUtilizaDescuentoRecargo.Tag = "RECIBOUTILIZADESCUENTORECARGO"
		Me.chbReciboUtilizaDescuentoRecargo.Text = "Recibo Utiliza Descuento/Recargo"
		Me.chbReciboUtilizaDescuentoRecargo.UseVisualStyleBackColor = True
		'
		'chkInteresesCalculoCompletoPrimerPago
		'
		Me.chkInteresesCalculoCompletoPrimerPago.AutoSize = True
		Me.chkInteresesCalculoCompletoPrimerPago.BindearPropiedadControl = Nothing
		Me.chkInteresesCalculoCompletoPrimerPago.BindearPropiedadEntidad = Nothing
		Me.chkInteresesCalculoCompletoPrimerPago.ForeColorFocus = System.Drawing.Color.Red
		Me.chkInteresesCalculoCompletoPrimerPago.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
		Me.chkInteresesCalculoCompletoPrimerPago.IsPK = False
		Me.chkInteresesCalculoCompletoPrimerPago.IsRequired = False
		Me.chkInteresesCalculoCompletoPrimerPago.Key = Nothing
		Me.chkInteresesCalculoCompletoPrimerPago.LabelAsoc = Nothing
		Me.chkInteresesCalculoCompletoPrimerPago.Location = New System.Drawing.Point(42, 211)
		Me.chkInteresesCalculoCompletoPrimerPago.Name = "chkInteresesCalculoCompletoPrimerPago"
		Me.chkInteresesCalculoCompletoPrimerPago.Size = New System.Drawing.Size(309, 17)
		Me.chkInteresesCalculoCompletoPrimerPago.TabIndex = 11
		Me.chkInteresesCalculoCompletoPrimerPago.Text = "Los Intereses se Calculan Completamente en el Primer Pago"
		Me.chkInteresesCalculoCompletoPrimerPago.UseVisualStyleBackColor = True
		'
		'chbReciboIgnorarPCdeCaja
		'
		Me.chbReciboIgnorarPCdeCaja.AutoSize = True
		Me.chbReciboIgnorarPCdeCaja.BindearPropiedadControl = Nothing
		Me.chbReciboIgnorarPCdeCaja.BindearPropiedadEntidad = Nothing
		Me.chbReciboIgnorarPCdeCaja.ForeColorFocus = System.Drawing.Color.Red
		Me.chbReciboIgnorarPCdeCaja.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
		Me.chbReciboIgnorarPCdeCaja.IsPK = False
		Me.chbReciboIgnorarPCdeCaja.IsRequired = False
		Me.chbReciboIgnorarPCdeCaja.Key = Nothing
		Me.chbReciboIgnorarPCdeCaja.LabelAsoc = Nothing
		Me.chbReciboIgnorarPCdeCaja.Location = New System.Drawing.Point(42, 127)
		Me.chbReciboIgnorarPCdeCaja.Name = "chbReciboIgnorarPCdeCaja"
		Me.chbReciboIgnorarPCdeCaja.Size = New System.Drawing.Size(115, 17)
		Me.chbReciboIgnorarPCdeCaja.TabIndex = 6
		Me.chbReciboIgnorarPCdeCaja.Tag = "RECIBOIGNORARPCDECAJA"
		Me.chbReciboIgnorarPCdeCaja.Text = "Ignorar PC de Caja"
		Me.chbReciboIgnorarPCdeCaja.UseVisualStyleBackColor = True
		'
		'txtMontoMinimoInteres
		'
		Me.txtMontoMinimoInteres.BindearPropiedadControl = Nothing
		Me.txtMontoMinimoInteres.BindearPropiedadEntidad = Nothing
		Me.txtMontoMinimoInteres.ForeColorFocus = System.Drawing.Color.Red
		Me.txtMontoMinimoInteres.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
		Me.txtMontoMinimoInteres.Formato = ""
		Me.txtMontoMinimoInteres.IsDecimal = True
		Me.txtMontoMinimoInteres.IsNumber = True
		Me.txtMontoMinimoInteres.IsPK = False
		Me.txtMontoMinimoInteres.IsRequired = False
		Me.txtMontoMinimoInteres.Key = ""
		Me.txtMontoMinimoInteres.LabelAsoc = Me.lblMontoMinimoInteres
		Me.txtMontoMinimoInteres.Location = New System.Drawing.Point(486, 206)
		Me.txtMontoMinimoInteres.MaxLength = 3
		Me.txtMontoMinimoInteres.Name = "txtMontoMinimoInteres"
		Me.txtMontoMinimoInteres.Size = New System.Drawing.Size(46, 20)
		Me.txtMontoMinimoInteres.TabIndex = 27
		Me.txtMontoMinimoInteres.Text = "0.00"
		Me.txtMontoMinimoInteres.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
		'
		'lblMontoMinimoInteres
		'
		Me.lblMontoMinimoInteres.AutoSize = True
		Me.lblMontoMinimoInteres.ForeColor = System.Drawing.SystemColors.WindowText
		Me.lblMontoMinimoInteres.LabelAsoc = Nothing
		Me.lblMontoMinimoInteres.Location = New System.Drawing.Point(538, 209)
		Me.lblMontoMinimoInteres.Name = "lblMontoMinimoInteres"
		Me.lblMontoMinimoInteres.Size = New System.Drawing.Size(251, 13)
		Me.lblMontoMinimoInteres.TabIndex = 28
		Me.lblMontoMinimoInteres.Text = "Monto mínimo de interés permitido por comprobante"
		'
		'chbReciboAplicaSaldoEnPesos
		'
		Me.chbReciboAplicaSaldoEnPesos.AutoSize = True
		Me.chbReciboAplicaSaldoEnPesos.BindearPropiedadControl = Nothing
		Me.chbReciboAplicaSaldoEnPesos.BindearPropiedadEntidad = Nothing
		Me.chbReciboAplicaSaldoEnPesos.ForeColorFocus = System.Drawing.Color.Red
		Me.chbReciboAplicaSaldoEnPesos.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
		Me.chbReciboAplicaSaldoEnPesos.IsPK = False
		Me.chbReciboAplicaSaldoEnPesos.IsRequired = False
		Me.chbReciboAplicaSaldoEnPesos.Key = Nothing
		Me.chbReciboAplicaSaldoEnPesos.LabelAsoc = Nothing
		Me.chbReciboAplicaSaldoEnPesos.Location = New System.Drawing.Point(42, 303)
		Me.chbReciboAplicaSaldoEnPesos.Name = "chbReciboAplicaSaldoEnPesos"
		Me.chbReciboAplicaSaldoEnPesos.Size = New System.Drawing.Size(180, 17)
		Me.chbReciboAplicaSaldoEnPesos.TabIndex = 15
		Me.chbReciboAplicaSaldoEnPesos.Tag = "RECIBOAPLICASALDOENPESOS"
		Me.chbReciboAplicaSaldoEnPesos.Text = "Recibo Aplica el Saldo en Pesos"
		Me.chbReciboAplicaSaldoEnPesos.UseVisualStyleBackColor = True
		'
		'chbCtaCteClientesSeparar
		'
		Me.chbCtaCteClientesSeparar.AutoSize = True
		Me.chbCtaCteClientesSeparar.BindearPropiedadControl = Nothing
		Me.chbCtaCteClientesSeparar.BindearPropiedadEntidad = Nothing
		Me.chbCtaCteClientesSeparar.ForeColorFocus = System.Drawing.Color.Red
		Me.chbCtaCteClientesSeparar.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
		Me.chbCtaCteClientesSeparar.IsPK = False
		Me.chbCtaCteClientesSeparar.IsRequired = False
		Me.chbCtaCteClientesSeparar.Key = Nothing
		Me.chbCtaCteClientesSeparar.LabelAsoc = Nothing
		Me.chbCtaCteClientesSeparar.Location = New System.Drawing.Point(486, 14)
		Me.chbCtaCteClientesSeparar.Name = "chbCtaCteClientesSeparar"
		Me.chbCtaCteClientesSeparar.Size = New System.Drawing.Size(134, 17)
		Me.chbCtaCteClientesSeparar.TabIndex = 19
		Me.chbCtaCteClientesSeparar.Tag = "CTACTECLIENTESSEPARAR"
		Me.chbCtaCteClientesSeparar.Text = "Separar Comprobantes"
		Me.chbCtaCteClientesSeparar.UseVisualStyleBackColor = True
		'
		'chbPermiteModificarImporteInteresesRecibo
		'
		Me.chbPermiteModificarImporteInteresesRecibo.AutoSize = True
		Me.chbPermiteModificarImporteInteresesRecibo.BindearPropiedadControl = Nothing
		Me.chbPermiteModificarImporteInteresesRecibo.BindearPropiedadEntidad = Nothing
		Me.chbPermiteModificarImporteInteresesRecibo.ForeColorFocus = System.Drawing.Color.Red
		Me.chbPermiteModificarImporteInteresesRecibo.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
		Me.chbPermiteModificarImporteInteresesRecibo.IsPK = False
		Me.chbPermiteModificarImporteInteresesRecibo.IsRequired = False
		Me.chbPermiteModificarImporteInteresesRecibo.Key = Nothing
		Me.chbPermiteModificarImporteInteresesRecibo.LabelAsoc = Nothing
		Me.chbPermiteModificarImporteInteresesRecibo.Location = New System.Drawing.Point(42, 257)
		Me.chbPermiteModificarImporteInteresesRecibo.Name = "chbPermiteModificarImporteInteresesRecibo"
		Me.chbPermiteModificarImporteInteresesRecibo.Size = New System.Drawing.Size(244, 17)
		Me.chbPermiteModificarImporteInteresesRecibo.TabIndex = 13
		Me.chbPermiteModificarImporteInteresesRecibo.Text = "Recibos permite modificar importe de intereses"
		Me.chbPermiteModificarImporteInteresesRecibo.UseVisualStyleBackColor = True
		'
		'chbCtaCteClientesPriorizarNCyANT
		'
		Me.chbCtaCteClientesPriorizarNCyANT.AutoSize = True
		Me.chbCtaCteClientesPriorizarNCyANT.BindearPropiedadControl = Nothing
		Me.chbCtaCteClientesPriorizarNCyANT.BindearPropiedadEntidad = Nothing
		Me.chbCtaCteClientesPriorizarNCyANT.ForeColorFocus = System.Drawing.Color.Red
		Me.chbCtaCteClientesPriorizarNCyANT.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
		Me.chbCtaCteClientesPriorizarNCyANT.IsPK = False
		Me.chbCtaCteClientesPriorizarNCyANT.IsRequired = False
		Me.chbCtaCteClientesPriorizarNCyANT.Key = Nothing
		Me.chbCtaCteClientesPriorizarNCyANT.LabelAsoc = Nothing
		Me.chbCtaCteClientesPriorizarNCyANT.Location = New System.Drawing.Point(486, 34)
		Me.chbCtaCteClientesPriorizarNCyANT.Name = "chbCtaCteClientesPriorizarNCyANT"
		Me.chbCtaCteClientesPriorizarNCyANT.Size = New System.Drawing.Size(140, 17)
		Me.chbCtaCteClientesPriorizarNCyANT.TabIndex = 20
		Me.chbCtaCteClientesPriorizarNCyANT.Tag = "CTACTECLIENTESPRIORIZARNCSYANTICIPOS"
		Me.chbCtaCteClientesPriorizarNCyANT.Text = "Priorizar NCs y Anticipos"
		Me.chbCtaCteClientesPriorizarNCyANT.UseVisualStyleBackColor = True
		'
		'chbReciboConciliaAutomaticamenteTransferencias
		'
		Me.chbReciboConciliaAutomaticamenteTransferencias.AutoSize = True
		Me.chbReciboConciliaAutomaticamenteTransferencias.BindearPropiedadControl = Nothing
		Me.chbReciboConciliaAutomaticamenteTransferencias.BindearPropiedadEntidad = Nothing
		Me.chbReciboConciliaAutomaticamenteTransferencias.ForeColorFocus = System.Drawing.Color.Red
		Me.chbReciboConciliaAutomaticamenteTransferencias.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
		Me.chbReciboConciliaAutomaticamenteTransferencias.IsPK = False
		Me.chbReciboConciliaAutomaticamenteTransferencias.IsRequired = False
		Me.chbReciboConciliaAutomaticamenteTransferencias.Key = Nothing
		Me.chbReciboConciliaAutomaticamenteTransferencias.LabelAsoc = Nothing
		Me.chbReciboConciliaAutomaticamenteTransferencias.Location = New System.Drawing.Point(42, 349)
		Me.chbReciboConciliaAutomaticamenteTransferencias.Name = "chbReciboConciliaAutomaticamenteTransferencias"
		Me.chbReciboConciliaAutomaticamenteTransferencias.Size = New System.Drawing.Size(400, 17)
		Me.chbReciboConciliaAutomaticamenteTransferencias.TabIndex = 17
		Me.chbReciboConciliaAutomaticamenteTransferencias.Text = "Recibos concilia transferencias bancarias automáticamente si se tiene permisos"
		Me.chbReciboConciliaAutomaticamenteTransferencias.UseVisualStyleBackColor = True
		'
		'chbCtaCteClientesPermiteComprobantesEmisionPosterior
		'
		Me.chbCtaCteClientesPermiteComprobantesEmisionPosterior.AutoSize = True
		Me.chbCtaCteClientesPermiteComprobantesEmisionPosterior.BindearPropiedadControl = Nothing
		Me.chbCtaCteClientesPermiteComprobantesEmisionPosterior.BindearPropiedadEntidad = Nothing
		Me.chbCtaCteClientesPermiteComprobantesEmisionPosterior.ForeColorFocus = System.Drawing.Color.Red
		Me.chbCtaCteClientesPermiteComprobantesEmisionPosterior.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
		Me.chbCtaCteClientesPermiteComprobantesEmisionPosterior.IsPK = False
		Me.chbCtaCteClientesPermiteComprobantesEmisionPosterior.IsRequired = False
		Me.chbCtaCteClientesPermiteComprobantesEmisionPosterior.Key = Nothing
		Me.chbCtaCteClientesPermiteComprobantesEmisionPosterior.LabelAsoc = Nothing
		Me.chbCtaCteClientesPermiteComprobantesEmisionPosterior.Location = New System.Drawing.Point(486, 57)
		Me.chbCtaCteClientesPermiteComprobantesEmisionPosterior.Name = "chbCtaCteClientesPermiteComprobantesEmisionPosterior"
		Me.chbCtaCteClientesPermiteComprobantesEmisionPosterior.Size = New System.Drawing.Size(265, 17)
		Me.chbCtaCteClientesPermiteComprobantesEmisionPosterior.TabIndex = 21
		Me.chbCtaCteClientesPermiteComprobantesEmisionPosterior.Tag = "CTACTECLIENTESEMISIONPOSTERIOR"
		Me.chbCtaCteClientesPermiteComprobantesEmisionPosterior.Text = "Permite Aplicar Comprobantes de Emision Posterior"
		Me.chbCtaCteClientesPermiteComprobantesEmisionPosterior.UseVisualStyleBackColor = True
		'
		'chbReciboComparteNumeracionEntreSucursales
		'
		Me.chbReciboComparteNumeracionEntreSucursales.AutoSize = True
		Me.chbReciboComparteNumeracionEntreSucursales.BindearPropiedadControl = Nothing
		Me.chbReciboComparteNumeracionEntreSucursales.BindearPropiedadEntidad = Nothing
		Me.chbReciboComparteNumeracionEntreSucursales.ForeColorFocus = System.Drawing.Color.Red
		Me.chbReciboComparteNumeracionEntreSucursales.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
		Me.chbReciboComparteNumeracionEntreSucursales.IsPK = False
		Me.chbReciboComparteNumeracionEntreSucursales.IsRequired = False
		Me.chbReciboComparteNumeracionEntreSucursales.Key = Nothing
		Me.chbReciboComparteNumeracionEntreSucursales.LabelAsoc = Nothing
		Me.chbReciboComparteNumeracionEntreSucursales.Location = New System.Drawing.Point(486, 183)
		Me.chbReciboComparteNumeracionEntreSucursales.Name = "chbReciboComparteNumeracionEntreSucursales"
		Me.chbReciboComparteNumeracionEntreSucursales.Size = New System.Drawing.Size(250, 17)
		Me.chbReciboComparteNumeracionEntreSucursales.TabIndex = 26
		Me.chbReciboComparteNumeracionEntreSucursales.Text = "Recibos comparte numeración entre sucursales"
		Me.chbReciboComparteNumeracionEntreSucursales.UseVisualStyleBackColor = True
		'
		'chbCtaCteClientesCalcularPromedios
		'
		Me.chbCtaCteClientesCalcularPromedios.AutoSize = True
		Me.chbCtaCteClientesCalcularPromedios.BindearPropiedadControl = Nothing
		Me.chbCtaCteClientesCalcularPromedios.BindearPropiedadEntidad = Nothing
		Me.chbCtaCteClientesCalcularPromedios.ForeColorFocus = System.Drawing.Color.Red
		Me.chbCtaCteClientesCalcularPromedios.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
		Me.chbCtaCteClientesCalcularPromedios.IsPK = False
		Me.chbCtaCteClientesCalcularPromedios.IsRequired = False
		Me.chbCtaCteClientesCalcularPromedios.Key = Nothing
		Me.chbCtaCteClientesCalcularPromedios.LabelAsoc = Nothing
		Me.chbCtaCteClientesCalcularPromedios.Location = New System.Drawing.Point(486, 80)
		Me.chbCtaCteClientesCalcularPromedios.Name = "chbCtaCteClientesCalcularPromedios"
		Me.chbCtaCteClientesCalcularPromedios.Size = New System.Drawing.Size(116, 17)
		Me.chbCtaCteClientesCalcularPromedios.TabIndex = 22
		Me.chbCtaCteClientesCalcularPromedios.Tag = "CTACTECLIENTESCALCULARPROMEDIOS"
		Me.chbCtaCteClientesCalcularPromedios.Text = "Calcular Promedios"
		Me.chbCtaCteClientesCalcularPromedios.UseVisualStyleBackColor = True
		'
		'chbReciboMantieneNumModificada
		'
		Me.chbReciboMantieneNumModificada.AutoSize = True
		Me.chbReciboMantieneNumModificada.BindearPropiedadControl = Nothing
		Me.chbReciboMantieneNumModificada.BindearPropiedadEntidad = Nothing
		Me.chbReciboMantieneNumModificada.ForeColorFocus = System.Drawing.Color.Red
		Me.chbReciboMantieneNumModificada.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
		Me.chbReciboMantieneNumModificada.IsPK = False
		Me.chbReciboMantieneNumModificada.IsRequired = False
		Me.chbReciboMantieneNumModificada.Key = Nothing
		Me.chbReciboMantieneNumModificada.LabelAsoc = Nothing
		Me.chbReciboMantieneNumModificada.Location = New System.Drawing.Point(486, 156)
		Me.chbReciboMantieneNumModificada.Name = "chbReciboMantieneNumModificada"
		Me.chbReciboMantieneNumModificada.Size = New System.Drawing.Size(223, 17)
		Me.chbReciboMantieneNumModificada.TabIndex = 25
		Me.chbReciboMantieneNumModificada.Tag = "RECIBOMANTIENENUMMODIFICADA"
		Me.chbReciboMantieneNumModificada.Text = "Recibos mantiene numeración modificada"
		Me.chbReciboMantieneNumModificada.UseVisualStyleBackColor = True
		'
		'txtCategoriaCliente
		'
		Me.txtCategoriaCliente.BindearPropiedadControl = Nothing
		Me.txtCategoriaCliente.BindearPropiedadEntidad = Nothing
		Me.txtCategoriaCliente.ForeColorFocus = System.Drawing.Color.Red
		Me.txtCategoriaCliente.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
		Me.txtCategoriaCliente.Formato = ""
		Me.txtCategoriaCliente.IsDecimal = False
		Me.txtCategoriaCliente.IsNumber = False
		Me.txtCategoriaCliente.IsPK = False
		Me.txtCategoriaCliente.IsRequired = False
		Me.txtCategoriaCliente.Key = ""
		Me.txtCategoriaCliente.LabelAsoc = Me.lblCategoriaCliente
		Me.txtCategoriaCliente.Location = New System.Drawing.Point(42, 154)
		Me.txtCategoriaCliente.MaxLength = 20
		Me.txtCategoriaCliente.Name = "txtCategoriaCliente"
		Me.txtCategoriaCliente.Size = New System.Drawing.Size(81, 20)
		Me.txtCategoriaCliente.TabIndex = 7
		Me.txtCategoriaCliente.Tag = "CTACTECATEGORIACLIENTE"
		Me.txtCategoriaCliente.Text = "ACTUAL"
		'
		'lblCategoriaCliente
		'
		Me.lblCategoriaCliente.AutoSize = True
		Me.lblCategoriaCliente.ForeColor = System.Drawing.SystemColors.WindowText
		Me.lblCategoriaCliente.LabelAsoc = Nothing
		Me.lblCategoriaCliente.Location = New System.Drawing.Point(129, 158)
		Me.lblCategoriaCliente.Name = "lblCategoriaCliente"
		Me.lblCategoriaCliente.Size = New System.Drawing.Size(307, 13)
		Me.lblCategoriaCliente.TabIndex = 8
		Me.lblCategoriaCliente.Text = "Categoria predeterminada de Cliente (ACTUAL ; MOVIMIENTO)"
		'
		'chkMontoAplicadoIncluyeIntereses
		'
		Me.chkMontoAplicadoIncluyeIntereses.AutoSize = True
		Me.chkMontoAplicadoIncluyeIntereses.BindearPropiedadControl = Nothing
		Me.chkMontoAplicadoIncluyeIntereses.BindearPropiedadEntidad = Nothing
		Me.chkMontoAplicadoIncluyeIntereses.ForeColorFocus = System.Drawing.Color.Red
		Me.chkMontoAplicadoIncluyeIntereses.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
		Me.chkMontoAplicadoIncluyeIntereses.IsPK = False
		Me.chkMontoAplicadoIncluyeIntereses.IsRequired = False
		Me.chkMontoAplicadoIncluyeIntereses.Key = Nothing
		Me.chkMontoAplicadoIncluyeIntereses.LabelAsoc = Nothing
		Me.chkMontoAplicadoIncluyeIntereses.Location = New System.Drawing.Point(42, 234)
		Me.chkMontoAplicadoIncluyeIntereses.Name = "chkMontoAplicadoIncluyeIntereses"
		Me.chkMontoAplicadoIncluyeIntereses.Size = New System.Drawing.Size(199, 17)
		Me.chkMontoAplicadoIncluyeIntereses.TabIndex = 12
		Me.chkMontoAplicadoIncluyeIntereses.TabStop = False
		Me.chkMontoAplicadoIncluyeIntereses.Text = "Monto Aplicado Incluye los Intereses"
		Me.chkMontoAplicadoIncluyeIntereses.UseVisualStyleBackColor = True
		'
		'txtInteresesAdicionalProporcionalDiario
		'
		Me.txtInteresesAdicionalProporcionalDiario.BindearPropiedadControl = Nothing
		Me.txtInteresesAdicionalProporcionalDiario.BindearPropiedadEntidad = Nothing
		Me.txtInteresesAdicionalProporcionalDiario.ForeColorFocus = System.Drawing.Color.Red
		Me.txtInteresesAdicionalProporcionalDiario.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
		Me.txtInteresesAdicionalProporcionalDiario.Formato = ""
		Me.txtInteresesAdicionalProporcionalDiario.IsDecimal = True
		Me.txtInteresesAdicionalProporcionalDiario.IsNumber = True
		Me.txtInteresesAdicionalProporcionalDiario.IsPK = False
		Me.txtInteresesAdicionalProporcionalDiario.IsRequired = False
		Me.txtInteresesAdicionalProporcionalDiario.Key = ""
		Me.txtInteresesAdicionalProporcionalDiario.LabelAsoc = Me.lblInteresesAdicionalProporcionalDiario
		Me.txtInteresesAdicionalProporcionalDiario.Location = New System.Drawing.Point(42, 184)
		Me.txtInteresesAdicionalProporcionalDiario.MaxLength = 3
		Me.txtInteresesAdicionalProporcionalDiario.Name = "txtInteresesAdicionalProporcionalDiario"
		Me.txtInteresesAdicionalProporcionalDiario.Size = New System.Drawing.Size(35, 20)
		Me.txtInteresesAdicionalProporcionalDiario.TabIndex = 9
		Me.txtInteresesAdicionalProporcionalDiario.Text = "0.00"
		Me.txtInteresesAdicionalProporcionalDiario.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
		'
		'lblInteresesAdicionalProporcionalDiario
		'
		Me.lblInteresesAdicionalProporcionalDiario.AutoSize = True
		Me.lblInteresesAdicionalProporcionalDiario.ForeColor = System.Drawing.SystemColors.WindowText
		Me.lblInteresesAdicionalProporcionalDiario.LabelAsoc = Nothing
		Me.lblInteresesAdicionalProporcionalDiario.Location = New System.Drawing.Point(83, 189)
		Me.lblInteresesAdicionalProporcionalDiario.Name = "lblInteresesAdicionalProporcionalDiario"
		Me.lblInteresesAdicionalProporcionalDiario.Size = New System.Drawing.Size(301, 13)
		Me.lblInteresesAdicionalProporcionalDiario.TabIndex = 10
		Me.lblInteresesAdicionalProporcionalDiario.Text = "Interés adicional proporcional diario acumulado a último interés"
		'
		'chbCategoriaClienteRecibos
		'
		Me.chbCategoriaClienteRecibos.AutoSize = True
		Me.chbCategoriaClienteRecibos.BindearPropiedadControl = Nothing
		Me.chbCategoriaClienteRecibos.BindearPropiedadEntidad = Nothing
		Me.chbCategoriaClienteRecibos.ForeColorFocus = System.Drawing.Color.Red
		Me.chbCategoriaClienteRecibos.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
		Me.chbCategoriaClienteRecibos.IsPK = False
		Me.chbCategoriaClienteRecibos.IsRequired = False
		Me.chbCategoriaClienteRecibos.Key = Nothing
		Me.chbCategoriaClienteRecibos.LabelAsoc = Nothing
		Me.chbCategoriaClienteRecibos.Location = New System.Drawing.Point(486, 104)
		Me.chbCategoriaClienteRecibos.Name = "chbCategoriaClienteRecibos"
		Me.chbCategoriaClienteRecibos.Size = New System.Drawing.Size(233, 17)
		Me.chbCategoriaClienteRecibos.TabIndex = 23
		Me.chbCategoriaClienteRecibos.Tag = "CTACTECATEGORIACLIENTESRECIBO"
		Me.chbCategoriaClienteRecibos.Text = "Contempla Categoría de Cliente en Recibos"
		Me.chbCategoriaClienteRecibos.UseVisualStyleBackColor = True
		'
		'chbCtaCteClientesReciboMuestraSaldosEnImpresion
		'
		Me.chbCtaCteClientesReciboMuestraSaldosEnImpresion.AutoSize = True
		Me.chbCtaCteClientesReciboMuestraSaldosEnImpresion.BindearPropiedadControl = Nothing
		Me.chbCtaCteClientesReciboMuestraSaldosEnImpresion.BindearPropiedadEntidad = Nothing
		Me.chbCtaCteClientesReciboMuestraSaldosEnImpresion.ForeColorFocus = System.Drawing.Color.Red
		Me.chbCtaCteClientesReciboMuestraSaldosEnImpresion.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
		Me.chbCtaCteClientesReciboMuestraSaldosEnImpresion.IsPK = False
		Me.chbCtaCteClientesReciboMuestraSaldosEnImpresion.IsRequired = False
		Me.chbCtaCteClientesReciboMuestraSaldosEnImpresion.Key = Nothing
		Me.chbCtaCteClientesReciboMuestraSaldosEnImpresion.LabelAsoc = Nothing
		Me.chbCtaCteClientesReciboMuestraSaldosEnImpresion.Location = New System.Drawing.Point(486, 131)
		Me.chbCtaCteClientesReciboMuestraSaldosEnImpresion.Name = "chbCtaCteClientesReciboMuestraSaldosEnImpresion"
		Me.chbCtaCteClientesReciboMuestraSaldosEnImpresion.Size = New System.Drawing.Size(199, 17)
		Me.chbCtaCteClientesReciboMuestraSaldosEnImpresion.TabIndex = 24
		Me.chbCtaCteClientesReciboMuestraSaldosEnImpresion.Tag = "RECIBOMUESTRASALDOCTACTEIMPRESION"
		Me.chbCtaCteClientesReciboMuestraSaldosEnImpresion.Text = "Recibos Muestra Saldo en Impresión"
		Me.chbCtaCteClientesReciboMuestraSaldosEnImpresion.UseVisualStyleBackColor = True
		'
		'chbCalculoInteresFuturo
		'
		Me.chbCalculoInteresFuturo.BindearPropiedadControl = Nothing
		Me.chbCalculoInteresFuturo.BindearPropiedadEntidad = Nothing
		Me.chbCalculoInteresFuturo.ForeColorFocus = System.Drawing.Color.Red
		Me.chbCalculoInteresFuturo.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
		Me.chbCalculoInteresFuturo.IsPK = False
		Me.chbCalculoInteresFuturo.IsRequired = False
		Me.chbCalculoInteresFuturo.Key = Nothing
		Me.chbCalculoInteresFuturo.LabelAsoc = Nothing
		Me.chbCalculoInteresFuturo.Location = New System.Drawing.Point(485, 258)
		Me.chbCalculoInteresFuturo.Name = "chbCalculoInteresFuturo"
		Me.chbCalculoInteresFuturo.Size = New System.Drawing.Size(398, 39)
		Me.chbCalculoInteresFuturo.TabIndex = 59
		Me.chbCalculoInteresFuturo.TabStop = False
		Me.chbCalculoInteresFuturo.Text = "De Existir, Los Intereses se Calculan Tomando como fecha efectiva del Pago la Fec" &
	"ha de Cobro del Cheque Más Largo"
		Me.chbCalculoInteresFuturo.UseVisualStyleBackColor = True
		'
		'ucConfCtaCteClienteGeneral
		'
		Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.Controls.Add(Me.chbCalculoInteresFuturo)
		Me.Controls.Add(Me.txtCantidadDiasDHRecibos)
		Me.Controls.Add(Me.lblCantidadDiasDHRecibos)
		Me.Controls.Add(Me.chbEnviaMailRecibo)
		Me.Controls.Add(Me.txtCantidadDiasVencimiento)
		Me.Controls.Add(Me.lblCantidadDiasvto)
		Me.Controls.Add(Me.txtFacturacionAsuntoEnvioMasivoEmailCtaCte)
		Me.Controls.Add(Me.Label16)
		Me.Controls.Add(Me.lblFacturacionAsuntoEnvioMasivoEmailCtaCte)
		Me.Controls.Add(Me.chbPintaCuotaCtaCteClientes)
		Me.Controls.Add(Me.chbVisualizaReciboAntesImprimir)
		Me.Controls.Add(Me.chbValidaEmisorElectronicoRecibos)
		Me.Controls.Add(Me.chbUtilizaCuotasVencCCClientes)
		Me.Controls.Add(Me.chbPermiteReciboSinAplicarComprobantes)
		Me.Controls.Add(Me.lblIdProductoDescuentoRecargo)
		Me.Controls.Add(Me.txtIdProductoDescuentoRecargo)
		Me.Controls.Add(Me.chbReciboSolicitaFecha)
		Me.Controls.Add(Me.chbReciboUtilizaDescuentoRecargo)
		Me.Controls.Add(Me.chkInteresesCalculoCompletoPrimerPago)
		Me.Controls.Add(Me.chbReciboIgnorarPCdeCaja)
		Me.Controls.Add(Me.txtMontoMinimoInteres)
		Me.Controls.Add(Me.chbReciboAplicaSaldoEnPesos)
		Me.Controls.Add(Me.lblMontoMinimoInteres)
		Me.Controls.Add(Me.chbCtaCteClientesSeparar)
		Me.Controls.Add(Me.chbPermiteModificarImporteInteresesRecibo)
		Me.Controls.Add(Me.chbCtaCteClientesPriorizarNCyANT)
		Me.Controls.Add(Me.chbReciboConciliaAutomaticamenteTransferencias)
		Me.Controls.Add(Me.chbCtaCteClientesPermiteComprobantesEmisionPosterior)
		Me.Controls.Add(Me.chbReciboComparteNumeracionEntreSucursales)
		Me.Controls.Add(Me.chbCtaCteClientesCalcularPromedios)
		Me.Controls.Add(Me.chbReciboMantieneNumModificada)
		Me.Controls.Add(Me.txtCategoriaCliente)
		Me.Controls.Add(Me.chkMontoAplicadoIncluyeIntereses)
		Me.Controls.Add(Me.lblCategoriaCliente)
		Me.Controls.Add(Me.txtInteresesAdicionalProporcionalDiario)
		Me.Controls.Add(Me.chbCategoriaClienteRecibos)
		Me.Controls.Add(Me.lblInteresesAdicionalProporcionalDiario)
		Me.Controls.Add(Me.chbCtaCteClientesReciboMuestraSaldosEnImpresion)
		Me.Name = "ucConfCtaCteClienteGeneral"
		Me.Size = New System.Drawing.Size(900, 428)
		Me.Controls.SetChildIndex(Me.chbCtaCteClientesReciboMuestraSaldosEnImpresion, 0)
		Me.Controls.SetChildIndex(Me.lblInteresesAdicionalProporcionalDiario, 0)
		Me.Controls.SetChildIndex(Me.chbCategoriaClienteRecibos, 0)
		Me.Controls.SetChildIndex(Me.txtInteresesAdicionalProporcionalDiario, 0)
		Me.Controls.SetChildIndex(Me.lblCategoriaCliente, 0)
		Me.Controls.SetChildIndex(Me.chkMontoAplicadoIncluyeIntereses, 0)
		Me.Controls.SetChildIndex(Me.txtCategoriaCliente, 0)
		Me.Controls.SetChildIndex(Me.chbReciboMantieneNumModificada, 0)
		Me.Controls.SetChildIndex(Me.chbCtaCteClientesCalcularPromedios, 0)
		Me.Controls.SetChildIndex(Me.chbReciboComparteNumeracionEntreSucursales, 0)
		Me.Controls.SetChildIndex(Me.chbCtaCteClientesPermiteComprobantesEmisionPosterior, 0)
		Me.Controls.SetChildIndex(Me.chbReciboConciliaAutomaticamenteTransferencias, 0)
		Me.Controls.SetChildIndex(Me.chbCtaCteClientesPriorizarNCyANT, 0)
		Me.Controls.SetChildIndex(Me.chbPermiteModificarImporteInteresesRecibo, 0)
		Me.Controls.SetChildIndex(Me.chbCtaCteClientesSeparar, 0)
		Me.Controls.SetChildIndex(Me.lblMontoMinimoInteres, 0)
		Me.Controls.SetChildIndex(Me.chbReciboAplicaSaldoEnPesos, 0)
		Me.Controls.SetChildIndex(Me.txtMontoMinimoInteres, 0)
		Me.Controls.SetChildIndex(Me.chbReciboIgnorarPCdeCaja, 0)
		Me.Controls.SetChildIndex(Me.chkInteresesCalculoCompletoPrimerPago, 0)
		Me.Controls.SetChildIndex(Me.chbReciboUtilizaDescuentoRecargo, 0)
		Me.Controls.SetChildIndex(Me.chbReciboSolicitaFecha, 0)
		Me.Controls.SetChildIndex(Me.txtIdProductoDescuentoRecargo, 0)
		Me.Controls.SetChildIndex(Me.lblIdProductoDescuentoRecargo, 0)
		Me.Controls.SetChildIndex(Me.chbPermiteReciboSinAplicarComprobantes, 0)
		Me.Controls.SetChildIndex(Me.chbUtilizaCuotasVencCCClientes, 0)
		Me.Controls.SetChildIndex(Me.chbValidaEmisorElectronicoRecibos, 0)
		Me.Controls.SetChildIndex(Me.chbVisualizaReciboAntesImprimir, 0)
		Me.Controls.SetChildIndex(Me.chbPintaCuotaCtaCteClientes, 0)
		Me.Controls.SetChildIndex(Me.lblFacturacionAsuntoEnvioMasivoEmailCtaCte, 0)
		Me.Controls.SetChildIndex(Me.Label16, 0)
		Me.Controls.SetChildIndex(Me.txtFacturacionAsuntoEnvioMasivoEmailCtaCte, 0)
		Me.Controls.SetChildIndex(Me.lblCantidadDiasvto, 0)
		Me.Controls.SetChildIndex(Me.txtCantidadDiasVencimiento, 0)
		Me.Controls.SetChildIndex(Me.chbEnviaMailRecibo, 0)
		Me.Controls.SetChildIndex(Me.lblCantidadDiasDHRecibos, 0)
		Me.Controls.SetChildIndex(Me.txtCantidadDiasDHRecibos, 0)
		Me.Controls.SetChildIndex(Me.chbCalculoInteresFuturo, 0)
		Me.ResumeLayout(False)
		Me.PerformLayout()

	End Sub

	Friend WithEvents txtCantidadDiasDHRecibos As Controles.TextBox
   Friend WithEvents lblCantidadDiasDHRecibos As Controles.Label
   Friend WithEvents chbEnviaMailRecibo As Controles.CheckBox
   Friend WithEvents txtCantidadDiasVencimiento As Controles.TextBox
   Friend WithEvents lblCantidadDiasvto As Controles.Label
   Friend WithEvents txtFacturacionAsuntoEnvioMasivoEmailCtaCte As Controles.TextBox
   Friend WithEvents lblFacturacionAsuntoEnvioMasivoEmailCtaCte As Controles.Label
   Friend WithEvents Label16 As Controles.Label
   Friend WithEvents chbPintaCuotaCtaCteClientes As Controles.CheckBox
   Friend WithEvents chbVisualizaReciboAntesImprimir As Controles.CheckBox
   Friend WithEvents chbValidaEmisorElectronicoRecibos As Controles.CheckBox
   Friend WithEvents chbUtilizaCuotasVencCCClientes As Controles.CheckBox
   Friend WithEvents chbPermiteReciboSinAplicarComprobantes As Controles.CheckBox
   Friend WithEvents lblIdProductoDescuentoRecargo As Controles.Label
   Friend WithEvents txtIdProductoDescuentoRecargo As Controles.TextBox
   Friend WithEvents chbReciboSolicitaFecha As Controles.CheckBox
   Friend WithEvents chbReciboUtilizaDescuentoRecargo As Controles.CheckBox
   Friend WithEvents chkInteresesCalculoCompletoPrimerPago As Controles.CheckBox
   Friend WithEvents chbReciboIgnorarPCdeCaja As Controles.CheckBox
   Friend WithEvents txtMontoMinimoInteres As Controles.TextBox
   Friend WithEvents lblMontoMinimoInteres As Controles.Label
   Friend WithEvents chbReciboAplicaSaldoEnPesos As Controles.CheckBox
   Friend WithEvents chbCtaCteClientesSeparar As Controles.CheckBox
   Friend WithEvents chbPermiteModificarImporteInteresesRecibo As Controles.CheckBox
   Friend WithEvents chbCtaCteClientesPriorizarNCyANT As Controles.CheckBox
   Friend WithEvents chbReciboConciliaAutomaticamenteTransferencias As Controles.CheckBox
   Friend WithEvents chbCtaCteClientesPermiteComprobantesEmisionPosterior As Controles.CheckBox
   Friend WithEvents chbReciboComparteNumeracionEntreSucursales As Controles.CheckBox
   Friend WithEvents chbCtaCteClientesCalcularPromedios As Controles.CheckBox
   Friend WithEvents chbReciboMantieneNumModificada As Controles.CheckBox
   Friend WithEvents txtCategoriaCliente As Controles.TextBox
   Friend WithEvents lblCategoriaCliente As Controles.Label
   Friend WithEvents chkMontoAplicadoIncluyeIntereses As Controles.CheckBox
   Friend WithEvents txtInteresesAdicionalProporcionalDiario As Controles.TextBox
   Friend WithEvents lblInteresesAdicionalProporcionalDiario As Controles.Label
   Friend WithEvents chbCategoriaClienteRecibos As Controles.CheckBox
   Friend WithEvents chbCtaCteClientesReciboMuestraSaldosEnImpresion As Controles.CheckBox
    Friend WithEvents chbCalculoInteresFuturo As Controles.CheckBox
End Class
