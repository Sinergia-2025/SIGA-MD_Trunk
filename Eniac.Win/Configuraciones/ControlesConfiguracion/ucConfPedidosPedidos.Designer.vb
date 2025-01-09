<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ucConfPedidosPedidos
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
      Me.chbPedidosConservaOrdenProductos = New Eniac.Controles.CheckBox()
      Me.chbPermiteModificarDescRecPedidos = New Eniac.Controles.CheckBox()
      Me.txtDiasEntregaImportacion = New Eniac.Controles.TextBox()
      Me.lblDiasEntregaImportacion = New Eniac.Controles.Label()
      Me.chbImportarPedidosAltaProd = New Eniac.Controles.CheckBox()
      Me.chbPedidosOcultarRentabilidad = New Eniac.Controles.CheckBox()
      Me.chbPedidosModificaPrecioProducto = New Eniac.Controles.CheckBox()
      Me.chbPedidosModificaDescripSolicitaKilos = New Eniac.Controles.CheckBox()
      Me.chbPedidosPendientesFacturarAutomatico = New Eniac.Controles.CheckBox()
      Me.chbPedidosVisualizaAntesImprimir = New Eniac.Controles.CheckBox()
      Me.chbPedidosSolicitaTransportista = New Eniac.Controles.CheckBox()
      Me.chbPedidosSolicitaComprobanteGenerar = New Eniac.Controles.CheckBox()
      Me.cmbEstadosPedidos = New Eniac.Controles.ComboBox()
      Me.lblEstadoPedidoPendiente = New Eniac.Controles.Label()
      Me.chbPedidosPermiteModificarCambio = New Eniac.Controles.CheckBox()
      Me.cmbImportarPedidosTipoComprobante = New Eniac.Controles.ComboBox()
      Me.lblImportarPedidosTipoComprobante = New Eniac.Controles.Label()
      Me.cmbImportarPedidosFormatoArchivo = New Eniac.Controles.ComboBox()
      Me.lblImportarPedidosFormatoArchivo = New Eniac.Controles.Label()
      Me.cmbEstadoPresupuestoAlAnularPedido = New Eniac.Controles.ComboBox()
      Me.Label8 = New Eniac.Controles.Label()
      Me.cmbEstadosPedidosFacturado = New Eniac.Controles.ComboBox()
      Me.lblEstadoPedidoFacturado = New Eniac.Controles.Label()
      Me.chbUtilizaOrdenCompraPedidos = New Eniac.Controles.CheckBox()
      Me.chbPedidosPermiteFechaEntregaDistintas = New Eniac.Controles.CheckBox()
      Me.chbPermiteModificarClientePedido = New Eniac.Controles.CheckBox()
      Me.chbPrefacturaConsumePedido = New Eniac.Controles.CheckBox()
      Me.chbFacturarPedidoSeleccionado = New Eniac.Controles.CheckBox()
      Me.chbConvertirPedidoEnFacturaConservaPreciosPedido = New Eniac.Controles.CheckBox()
      Me.chbPedidoGenPedProvOCObligatoria = New Eniac.Controles.CheckBox()
      Me.chbPedidosValidaFacturaRemitoProveedor = New Eniac.Controles.CheckBox()
      Me.chbPedidosPresupuestosAgrupaProductos = New Eniac.Controles.CheckBox()
      Me.lblActualizaPrecioCopia = New Eniac.Controles.Label()
      Me.cmbCopiaPresupuestoActualizaPrecio = New Eniac.Controles.ComboBox()
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
      Me.chbPedidosGeneraOrdenProduccionPorProducto = New Eniac.Controles.CheckBox()
      Me.lblMonedaPorDefecto = New Eniac.Controles.Label()
      Me.cmbMonedaPorDefecto = New Eniac.Controles.ComboBox()
      Me.grbPermitirControlarLimiteCredito.SuspendLayout()
      Me.pnlPermitirControlarLimiteCredito_LimiteCredito.SuspendLayout()
      Me.pnlPermitirControlarLimiteCredito_LimiteDiasVencimiento.SuspendLayout()
      Me.SuspendLayout()
      '
      'chbPedidosConservaOrdenProductos
      '
      Me.chbPedidosConservaOrdenProductos.AutoSize = True
      Me.chbPedidosConservaOrdenProductos.BindearPropiedadControl = Nothing
      Me.chbPedidosConservaOrdenProductos.BindearPropiedadEntidad = Nothing
      Me.chbPedidosConservaOrdenProductos.ForeColorFocus = System.Drawing.Color.Red
      Me.chbPedidosConservaOrdenProductos.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
      Me.chbPedidosConservaOrdenProductos.IsPK = False
      Me.chbPedidosConservaOrdenProductos.IsRequired = False
      Me.chbPedidosConservaOrdenProductos.Key = Nothing
      Me.chbPedidosConservaOrdenProductos.LabelAsoc = Nothing
      Me.chbPedidosConservaOrdenProductos.Location = New System.Drawing.Point(409, 328)
      Me.chbPedidosConservaOrdenProductos.Name = "chbPedidosConservaOrdenProductos"
      Me.chbPedidosConservaOrdenProductos.Size = New System.Drawing.Size(237, 17)
      Me.chbPedidosConservaOrdenProductos.TabIndex = 29
      Me.chbPedidosConservaOrdenProductos.Text = "Conserva Orden de los Productos en la Grilla"
      Me.chbPedidosConservaOrdenProductos.UseVisualStyleBackColor = True
      '
      'chbPermiteModificarDescRecPedidos
      '
      Me.chbPermiteModificarDescRecPedidos.AutoSize = True
      Me.chbPermiteModificarDescRecPedidos.BindearPropiedadControl = Nothing
      Me.chbPermiteModificarDescRecPedidos.BindearPropiedadEntidad = Nothing
      Me.chbPermiteModificarDescRecPedidos.ForeColorFocus = System.Drawing.Color.Red
      Me.chbPermiteModificarDescRecPedidos.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
      Me.chbPermiteModificarDescRecPedidos.IsPK = False
      Me.chbPermiteModificarDescRecPedidos.IsRequired = False
      Me.chbPermiteModificarDescRecPedidos.Key = Nothing
      Me.chbPermiteModificarDescRecPedidos.LabelAsoc = Nothing
      Me.chbPermiteModificarDescRecPedidos.Location = New System.Drawing.Point(409, 213)
      Me.chbPermiteModificarDescRecPedidos.Name = "chbPermiteModificarDescRecPedidos"
      Me.chbPermiteModificarDescRecPedidos.Size = New System.Drawing.Size(210, 17)
      Me.chbPermiteModificarDescRecPedidos.TabIndex = 24
      Me.chbPermiteModificarDescRecPedidos.Tag = ""
      Me.chbPermiteModificarDescRecPedidos.Text = "Permite modificar el Desc/Rec General"
      Me.chbPermiteModificarDescRecPedidos.UseVisualStyleBackColor = True
      '
      'txtDiasEntregaImportacion
      '
      Me.txtDiasEntregaImportacion.BindearPropiedadControl = Nothing
      Me.txtDiasEntregaImportacion.BindearPropiedadEntidad = Nothing
      Me.txtDiasEntregaImportacion.ForeColorFocus = System.Drawing.Color.Red
      Me.txtDiasEntregaImportacion.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtDiasEntregaImportacion.Formato = ""
      Me.txtDiasEntregaImportacion.IsDecimal = False
      Me.txtDiasEntregaImportacion.IsNumber = True
      Me.txtDiasEntregaImportacion.IsPK = False
      Me.txtDiasEntregaImportacion.IsRequired = False
      Me.txtDiasEntregaImportacion.Key = ""
      Me.txtDiasEntregaImportacion.LabelAsoc = Me.lblDiasEntregaImportacion
      Me.txtDiasEntregaImportacion.Location = New System.Drawing.Point(211, 379)
      Me.txtDiasEntregaImportacion.MaxLength = 3
      Me.txtDiasEntregaImportacion.Name = "txtDiasEntregaImportacion"
      Me.txtDiasEntregaImportacion.Size = New System.Drawing.Size(21, 20)
      Me.txtDiasEntregaImportacion.TabIndex = 20
      Me.txtDiasEntregaImportacion.Tag = ""
      Me.txtDiasEntregaImportacion.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'lblDiasEntregaImportacion
      '
      Me.lblDiasEntregaImportacion.AutoSize = True
      Me.lblDiasEntregaImportacion.LabelAsoc = Nothing
      Me.lblDiasEntregaImportacion.Location = New System.Drawing.Point(53, 383)
      Me.lblDiasEntregaImportacion.Name = "lblDiasEntregaImportacion"
      Me.lblDiasEntregaImportacion.Size = New System.Drawing.Size(156, 13)
      Me.lblDiasEntregaImportacion.TabIndex = 21
      Me.lblDiasEntregaImportacion.Text = "Dias de Entrega en Importación"
      '
      'chbImportarPedidosAltaProd
      '
      Me.chbImportarPedidosAltaProd.AutoSize = True
      Me.chbImportarPedidosAltaProd.BindearPropiedadControl = Nothing
      Me.chbImportarPedidosAltaProd.BindearPropiedadEntidad = Nothing
      Me.chbImportarPedidosAltaProd.ForeColorFocus = System.Drawing.Color.Red
      Me.chbImportarPedidosAltaProd.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
      Me.chbImportarPedidosAltaProd.IsPK = False
      Me.chbImportarPedidosAltaProd.IsRequired = False
      Me.chbImportarPedidosAltaProd.Key = Nothing
      Me.chbImportarPedidosAltaProd.LabelAsoc = Nothing
      Me.chbImportarPedidosAltaProd.Location = New System.Drawing.Point(409, 305)
      Me.chbImportarPedidosAltaProd.Name = "chbImportarPedidosAltaProd"
      Me.chbImportarPedidosAltaProd.Size = New System.Drawing.Size(274, 17)
      Me.chbImportarPedidosAltaProd.TabIndex = 28
      Me.chbImportarPedidosAltaProd.Tag = ""
      Me.chbImportarPedidosAltaProd.Text = "Importar Pedidos: Dar de Alta Productos Inexistentes"
      Me.chbImportarPedidosAltaProd.UseVisualStyleBackColor = True
      '
      'chbPedidosOcultarRentabilidad
      '
      Me.chbPedidosOcultarRentabilidad.AutoSize = True
      Me.chbPedidosOcultarRentabilidad.BindearPropiedadControl = Nothing
      Me.chbPedidosOcultarRentabilidad.BindearPropiedadEntidad = Nothing
      Me.chbPedidosOcultarRentabilidad.ForeColorFocus = System.Drawing.Color.Red
      Me.chbPedidosOcultarRentabilidad.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
      Me.chbPedidosOcultarRentabilidad.IsPK = False
      Me.chbPedidosOcultarRentabilidad.IsRequired = False
      Me.chbPedidosOcultarRentabilidad.Key = Nothing
      Me.chbPedidosOcultarRentabilidad.LabelAsoc = Nothing
      Me.chbPedidosOcultarRentabilidad.Location = New System.Drawing.Point(409, 236)
      Me.chbPedidosOcultarRentabilidad.Name = "chbPedidosOcultarRentabilidad"
      Me.chbPedidosOcultarRentabilidad.Size = New System.Drawing.Size(160, 17)
      Me.chbPedidosOcultarRentabilidad.TabIndex = 25
      Me.chbPedidosOcultarRentabilidad.Tag = ""
      Me.chbPedidosOcultarRentabilidad.Text = "Permite Ocultar Rentabilidad"
      Me.chbPedidosOcultarRentabilidad.UseVisualStyleBackColor = True
      '
      'chbPedidosModificaPrecioProducto
      '
      Me.chbPedidosModificaPrecioProducto.AutoSize = True
      Me.chbPedidosModificaPrecioProducto.BindearPropiedadControl = Nothing
      Me.chbPedidosModificaPrecioProducto.BindearPropiedadEntidad = Nothing
      Me.chbPedidosModificaPrecioProducto.ForeColorFocus = System.Drawing.Color.Red
      Me.chbPedidosModificaPrecioProducto.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
      Me.chbPedidosModificaPrecioProducto.IsPK = False
      Me.chbPedidosModificaPrecioProducto.IsRequired = False
      Me.chbPedidosModificaPrecioProducto.Key = Nothing
      Me.chbPedidosModificaPrecioProducto.LabelAsoc = Nothing
      Me.chbPedidosModificaPrecioProducto.Location = New System.Drawing.Point(409, 190)
      Me.chbPedidosModificaPrecioProducto.Name = "chbPedidosModificaPrecioProducto"
      Me.chbPedidosModificaPrecioProducto.Size = New System.Drawing.Size(216, 17)
      Me.chbPedidosModificaPrecioProducto.TabIndex = 23
      Me.chbPedidosModificaPrecioProducto.Tag = ""
      Me.chbPedidosModificaPrecioProducto.Text = "Permite modificar el Precio del Producto."
      Me.chbPedidosModificaPrecioProducto.UseVisualStyleBackColor = True
      '
      'chbPedidosModificaDescripSolicitaKilos
      '
      Me.chbPedidosModificaDescripSolicitaKilos.AutoSize = True
      Me.chbPedidosModificaDescripSolicitaKilos.BindearPropiedadControl = Nothing
      Me.chbPedidosModificaDescripSolicitaKilos.BindearPropiedadEntidad = Nothing
      Me.chbPedidosModificaDescripSolicitaKilos.ForeColorFocus = System.Drawing.Color.Red
      Me.chbPedidosModificaDescripSolicitaKilos.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
      Me.chbPedidosModificaDescripSolicitaKilos.IsPK = False
      Me.chbPedidosModificaDescripSolicitaKilos.IsRequired = False
      Me.chbPedidosModificaDescripSolicitaKilos.Key = Nothing
      Me.chbPedidosModificaDescripSolicitaKilos.LabelAsoc = Nothing
      Me.chbPedidosModificaDescripSolicitaKilos.Location = New System.Drawing.Point(409, 167)
      Me.chbPedidosModificaDescripSolicitaKilos.Name = "chbPedidosModificaDescripSolicitaKilos"
      Me.chbPedidosModificaDescripSolicitaKilos.Size = New System.Drawing.Size(188, 17)
      Me.chbPedidosModificaDescripSolicitaKilos.TabIndex = 22
      Me.chbPedidosModificaDescripSolicitaKilos.Text = "Modifica Descripcion, solicita Kilos"
      Me.chbPedidosModificaDescripSolicitaKilos.UseVisualStyleBackColor = True
      '
      'chbPedidosPendientesFacturarAutomatico
      '
      Me.chbPedidosPendientesFacturarAutomatico.AutoSize = True
      Me.chbPedidosPendientesFacturarAutomatico.BindearPropiedadControl = Nothing
      Me.chbPedidosPendientesFacturarAutomatico.BindearPropiedadEntidad = Nothing
      Me.chbPedidosPendientesFacturarAutomatico.ForeColorFocus = System.Drawing.Color.Red
      Me.chbPedidosPendientesFacturarAutomatico.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
      Me.chbPedidosPendientesFacturarAutomatico.IsPK = False
      Me.chbPedidosPendientesFacturarAutomatico.IsRequired = False
      Me.chbPedidosPendientesFacturarAutomatico.Key = Nothing
      Me.chbPedidosPendientesFacturarAutomatico.LabelAsoc = Nothing
      Me.chbPedidosPendientesFacturarAutomatico.Location = New System.Drawing.Point(54, 14)
      Me.chbPedidosPendientesFacturarAutomatico.Name = "chbPedidosPendientesFacturarAutomatico"
      Me.chbPedidosPendientesFacturarAutomatico.Size = New System.Drawing.Size(264, 17)
      Me.chbPedidosPendientesFacturarAutomatico.TabIndex = 0
      Me.chbPedidosPendientesFacturarAutomatico.Tag = "PEDIDOSFACTURARAUTOMATICO"
      Me.chbPedidosPendientesFacturarAutomatico.Text = "Pedidos Pendientes: Facturados Autómaticamente"
      Me.chbPedidosPendientesFacturarAutomatico.UseVisualStyleBackColor = True
      '
      'chbPedidosVisualizaAntesImprimir
      '
      Me.chbPedidosVisualizaAntesImprimir.AutoSize = True
      Me.chbPedidosVisualizaAntesImprimir.BindearPropiedadControl = Nothing
      Me.chbPedidosVisualizaAntesImprimir.BindearPropiedadEntidad = Nothing
      Me.chbPedidosVisualizaAntesImprimir.ForeColorFocus = System.Drawing.Color.Red
      Me.chbPedidosVisualizaAntesImprimir.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
      Me.chbPedidosVisualizaAntesImprimir.IsPK = False
      Me.chbPedidosVisualizaAntesImprimir.IsRequired = False
      Me.chbPedidosVisualizaAntesImprimir.Key = Nothing
      Me.chbPedidosVisualizaAntesImprimir.LabelAsoc = Nothing
      Me.chbPedidosVisualizaAntesImprimir.Location = New System.Drawing.Point(54, 37)
      Me.chbPedidosVisualizaAntesImprimir.Name = "chbPedidosVisualizaAntesImprimir"
      Me.chbPedidosVisualizaAntesImprimir.Size = New System.Drawing.Size(206, 17)
      Me.chbPedidosVisualizaAntesImprimir.TabIndex = 1
      Me.chbPedidosVisualizaAntesImprimir.Tag = "PEDIDOSVISUALIZA"
      Me.chbPedidosVisualizaAntesImprimir.Text = "Visualiza los Pedidos antes de Imprimir"
      Me.chbPedidosVisualizaAntesImprimir.UseVisualStyleBackColor = True
      '
      'chbPedidosSolicitaTransportista
      '
      Me.chbPedidosSolicitaTransportista.AutoSize = True
      Me.chbPedidosSolicitaTransportista.BindearPropiedadControl = Nothing
      Me.chbPedidosSolicitaTransportista.BindearPropiedadEntidad = Nothing
      Me.chbPedidosSolicitaTransportista.ForeColorFocus = System.Drawing.Color.Red
      Me.chbPedidosSolicitaTransportista.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
      Me.chbPedidosSolicitaTransportista.IsPK = False
      Me.chbPedidosSolicitaTransportista.IsRequired = False
      Me.chbPedidosSolicitaTransportista.Key = Nothing
      Me.chbPedidosSolicitaTransportista.LabelAsoc = Nothing
      Me.chbPedidosSolicitaTransportista.Location = New System.Drawing.Point(54, 141)
      Me.chbPedidosSolicitaTransportista.Name = "chbPedidosSolicitaTransportista"
      Me.chbPedidosSolicitaTransportista.Size = New System.Drawing.Size(226, 17)
      Me.chbPedidosSolicitaTransportista.TabIndex = 8
      Me.chbPedidosSolicitaTransportista.Text = "Solicita Transportista en Carga de Pedidos"
      Me.chbPedidosSolicitaTransportista.UseVisualStyleBackColor = True
      '
      'chbPedidosSolicitaComprobanteGenerar
      '
      Me.chbPedidosSolicitaComprobanteGenerar.AutoSize = True
      Me.chbPedidosSolicitaComprobanteGenerar.BindearPropiedadControl = Nothing
      Me.chbPedidosSolicitaComprobanteGenerar.BindearPropiedadEntidad = Nothing
      Me.chbPedidosSolicitaComprobanteGenerar.ForeColorFocus = System.Drawing.Color.Red
      Me.chbPedidosSolicitaComprobanteGenerar.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
      Me.chbPedidosSolicitaComprobanteGenerar.IsPK = False
      Me.chbPedidosSolicitaComprobanteGenerar.IsRequired = False
      Me.chbPedidosSolicitaComprobanteGenerar.Key = Nothing
      Me.chbPedidosSolicitaComprobanteGenerar.LabelAsoc = Nothing
      Me.chbPedidosSolicitaComprobanteGenerar.Location = New System.Drawing.Point(54, 164)
      Me.chbPedidosSolicitaComprobanteGenerar.Name = "chbPedidosSolicitaComprobanteGenerar"
      Me.chbPedidosSolicitaComprobanteGenerar.Size = New System.Drawing.Size(278, 17)
      Me.chbPedidosSolicitaComprobanteGenerar.TabIndex = 9
      Me.chbPedidosSolicitaComprobanteGenerar.Text = "Solicita Comprobante a Generar en Carga de Pedidos"
      Me.chbPedidosSolicitaComprobanteGenerar.UseVisualStyleBackColor = True
      '
      'cmbEstadosPedidos
      '
      Me.cmbEstadosPedidos.BindearPropiedadControl = Nothing
      Me.cmbEstadosPedidos.BindearPropiedadEntidad = Nothing
      Me.cmbEstadosPedidos.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cmbEstadosPedidos.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.cmbEstadosPedidos.ForeColorFocus = System.Drawing.Color.Red
      Me.cmbEstadosPedidos.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.cmbEstadosPedidos.FormattingEnabled = True
      Me.cmbEstadosPedidos.IsPK = False
      Me.cmbEstadosPedidos.IsRequired = False
      Me.cmbEstadosPedidos.Key = Nothing
      Me.cmbEstadosPedidos.LabelAsoc = Me.lblEstadoPedidoPendiente
      Me.cmbEstadosPedidos.Location = New System.Drawing.Point(255, 60)
      Me.cmbEstadosPedidos.Name = "cmbEstadosPedidos"
      Me.cmbEstadosPedidos.Size = New System.Drawing.Size(122, 21)
      Me.cmbEstadosPedidos.TabIndex = 3
      Me.cmbEstadosPedidos.Tag = "PEDIDOSESTADOAREMITIR"
      '
      'lblEstadoPedidoPendiente
      '
      Me.lblEstadoPedidoPendiente.AutoSize = True
      Me.lblEstadoPedidoPendiente.ForeColor = System.Drawing.SystemColors.WindowText
      Me.lblEstadoPedidoPendiente.LabelAsoc = Nothing
      Me.lblEstadoPedidoPendiente.Location = New System.Drawing.Point(53, 63)
      Me.lblEstadoPedidoPendiente.Name = "lblEstadoPedidoPendiente"
      Me.lblEstadoPedidoPendiente.Size = New System.Drawing.Size(168, 13)
      Me.lblEstadoPedidoPendiente.TabIndex = 2
      Me.lblEstadoPedidoPendiente.Text = "Estado de Pedido que se Factura:"
      '
      'chbPedidosPermiteModificarCambio
      '
      Me.chbPedidosPermiteModificarCambio.AutoSize = True
      Me.chbPedidosPermiteModificarCambio.BindearPropiedadControl = Nothing
      Me.chbPedidosPermiteModificarCambio.BindearPropiedadEntidad = Nothing
      Me.chbPedidosPermiteModificarCambio.ForeColorFocus = System.Drawing.Color.Red
      Me.chbPedidosPermiteModificarCambio.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
      Me.chbPedidosPermiteModificarCambio.IsPK = False
      Me.chbPedidosPermiteModificarCambio.IsRequired = False
      Me.chbPedidosPermiteModificarCambio.Key = Nothing
      Me.chbPedidosPermiteModificarCambio.LabelAsoc = Nothing
      Me.chbPedidosPermiteModificarCambio.Location = New System.Drawing.Point(409, 259)
      Me.chbPedidosPermiteModificarCambio.Name = "chbPedidosPermiteModificarCambio"
      Me.chbPedidosPermiteModificarCambio.Size = New System.Drawing.Size(179, 17)
      Me.chbPedidosPermiteModificarCambio.TabIndex = 26
      Me.chbPedidosPermiteModificarCambio.Text = "Permite Modificar tipo de cambio"
      Me.chbPedidosPermiteModificarCambio.UseVisualStyleBackColor = True
      '
      'cmbImportarPedidosTipoComprobante
      '
      Me.cmbImportarPedidosTipoComprobante.BindearPropiedadControl = Nothing
      Me.cmbImportarPedidosTipoComprobante.BindearPropiedadEntidad = Nothing
      Me.cmbImportarPedidosTipoComprobante.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cmbImportarPedidosTipoComprobante.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.cmbImportarPedidosTipoComprobante.ForeColorFocus = System.Drawing.Color.Red
      Me.cmbImportarPedidosTipoComprobante.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.cmbImportarPedidosTipoComprobante.FormattingEnabled = True
      Me.cmbImportarPedidosTipoComprobante.IsPK = False
      Me.cmbImportarPedidosTipoComprobante.IsRequired = False
      Me.cmbImportarPedidosTipoComprobante.Key = Nothing
      Me.cmbImportarPedidosTipoComprobante.LabelAsoc = Me.lblImportarPedidosTipoComprobante
      Me.cmbImportarPedidosTipoComprobante.Location = New System.Drawing.Point(211, 352)
      Me.cmbImportarPedidosTipoComprobante.Name = "cmbImportarPedidosTipoComprobante"
      Me.cmbImportarPedidosTipoComprobante.Size = New System.Drawing.Size(166, 21)
      Me.cmbImportarPedidosTipoComprobante.TabIndex = 19
      Me.cmbImportarPedidosTipoComprobante.Tag = ""
      '
      'lblImportarPedidosTipoComprobante
      '
      Me.lblImportarPedidosTipoComprobante.AutoSize = True
      Me.lblImportarPedidosTipoComprobante.ForeColor = System.Drawing.SystemColors.WindowText
      Me.lblImportarPedidosTipoComprobante.LabelAsoc = Nothing
      Me.lblImportarPedidosTipoComprobante.Location = New System.Drawing.Point(53, 355)
      Me.lblImportarPedidosTipoComprobante.Name = "lblImportarPedidosTipoComprobante"
      Me.lblImportarPedidosTipoComprobante.Size = New System.Drawing.Size(152, 13)
      Me.lblImportarPedidosTipoComprobante.TabIndex = 18
      Me.lblImportarPedidosTipoComprobante.Text = "Tipo Comprobante Importación"
      '
      'cmbImportarPedidosFormatoArchivo
      '
      Me.cmbImportarPedidosFormatoArchivo.BindearPropiedadControl = Nothing
      Me.cmbImportarPedidosFormatoArchivo.BindearPropiedadEntidad = Nothing
      Me.cmbImportarPedidosFormatoArchivo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cmbImportarPedidosFormatoArchivo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.cmbImportarPedidosFormatoArchivo.ForeColorFocus = System.Drawing.Color.Red
      Me.cmbImportarPedidosFormatoArchivo.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.cmbImportarPedidosFormatoArchivo.FormattingEnabled = True
      Me.cmbImportarPedidosFormatoArchivo.IsPK = False
      Me.cmbImportarPedidosFormatoArchivo.IsRequired = False
      Me.cmbImportarPedidosFormatoArchivo.Key = Nothing
      Me.cmbImportarPedidosFormatoArchivo.LabelAsoc = Me.lblImportarPedidosFormatoArchivo
      Me.cmbImportarPedidosFormatoArchivo.Location = New System.Drawing.Point(211, 325)
      Me.cmbImportarPedidosFormatoArchivo.Name = "cmbImportarPedidosFormatoArchivo"
      Me.cmbImportarPedidosFormatoArchivo.Size = New System.Drawing.Size(166, 21)
      Me.cmbImportarPedidosFormatoArchivo.TabIndex = 17
      Me.cmbImportarPedidosFormatoArchivo.Tag = ""
      '
      'lblImportarPedidosFormatoArchivo
      '
      Me.lblImportarPedidosFormatoArchivo.AutoSize = True
      Me.lblImportarPedidosFormatoArchivo.ForeColor = System.Drawing.SystemColors.WindowText
      Me.lblImportarPedidosFormatoArchivo.LabelAsoc = Nothing
      Me.lblImportarPedidosFormatoArchivo.Location = New System.Drawing.Point(53, 328)
      Me.lblImportarPedidosFormatoArchivo.Name = "lblImportarPedidosFormatoArchivo"
      Me.lblImportarPedidosFormatoArchivo.Size = New System.Drawing.Size(142, 13)
      Me.lblImportarPedidosFormatoArchivo.TabIndex = 16
      Me.lblImportarPedidosFormatoArchivo.Text = "Formato Archivo Importación"
      '
      'cmbEstadoPresupuestoAlAnularPedido
      '
      Me.cmbEstadoPresupuestoAlAnularPedido.BindearPropiedadControl = Nothing
      Me.cmbEstadoPresupuestoAlAnularPedido.BindearPropiedadEntidad = Nothing
      Me.cmbEstadoPresupuestoAlAnularPedido.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cmbEstadoPresupuestoAlAnularPedido.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.cmbEstadoPresupuestoAlAnularPedido.ForeColorFocus = System.Drawing.Color.Red
      Me.cmbEstadoPresupuestoAlAnularPedido.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.cmbEstadoPresupuestoAlAnularPedido.FormattingEnabled = True
      Me.cmbEstadoPresupuestoAlAnularPedido.IsPK = False
      Me.cmbEstadoPresupuestoAlAnularPedido.IsRequired = False
      Me.cmbEstadoPresupuestoAlAnularPedido.Key = Nothing
      Me.cmbEstadoPresupuestoAlAnularPedido.LabelAsoc = Me.Label8
      Me.cmbEstadoPresupuestoAlAnularPedido.Location = New System.Drawing.Point(255, 114)
      Me.cmbEstadoPresupuestoAlAnularPedido.Name = "cmbEstadoPresupuestoAlAnularPedido"
      Me.cmbEstadoPresupuestoAlAnularPedido.Size = New System.Drawing.Size(122, 21)
      Me.cmbEstadoPresupuestoAlAnularPedido.TabIndex = 7
      Me.cmbEstadoPresupuestoAlAnularPedido.Tag = ""
      '
      'Label8
      '
      Me.Label8.AutoSize = True
      Me.Label8.ForeColor = System.Drawing.SystemColors.WindowText
      Me.Label8.LabelAsoc = Nothing
      Me.Label8.Location = New System.Drawing.Point(53, 117)
      Me.Label8.Name = "Label8"
      Me.Label8.Size = New System.Drawing.Size(196, 13)
      Me.Label8.TabIndex = 6
      Me.Label8.Text = "Estado de Presupuesto al anular Pedido"
      '
      'cmbEstadosPedidosFacturado
      '
      Me.cmbEstadosPedidosFacturado.BindearPropiedadControl = Nothing
      Me.cmbEstadosPedidosFacturado.BindearPropiedadEntidad = Nothing
      Me.cmbEstadosPedidosFacturado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cmbEstadosPedidosFacturado.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.cmbEstadosPedidosFacturado.ForeColorFocus = System.Drawing.Color.Red
      Me.cmbEstadosPedidosFacturado.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.cmbEstadosPedidosFacturado.FormattingEnabled = True
      Me.cmbEstadosPedidosFacturado.IsPK = False
      Me.cmbEstadosPedidosFacturado.IsRequired = False
      Me.cmbEstadosPedidosFacturado.Key = Nothing
      Me.cmbEstadosPedidosFacturado.LabelAsoc = Me.lblEstadoPedidoFacturado
      Me.cmbEstadosPedidosFacturado.Location = New System.Drawing.Point(255, 87)
      Me.cmbEstadosPedidosFacturado.Name = "cmbEstadosPedidosFacturado"
      Me.cmbEstadosPedidosFacturado.Size = New System.Drawing.Size(122, 21)
      Me.cmbEstadosPedidosFacturado.TabIndex = 5
      Me.cmbEstadosPedidosFacturado.Tag = "PEDIDOSESTADOAREMITIR"
      '
      'lblEstadoPedidoFacturado
      '
      Me.lblEstadoPedidoFacturado.AutoSize = True
      Me.lblEstadoPedidoFacturado.ForeColor = System.Drawing.SystemColors.WindowText
      Me.lblEstadoPedidoFacturado.LabelAsoc = Nothing
      Me.lblEstadoPedidoFacturado.Location = New System.Drawing.Point(53, 90)
      Me.lblEstadoPedidoFacturado.Name = "lblEstadoPedidoFacturado"
      Me.lblEstadoPedidoFacturado.Size = New System.Drawing.Size(177, 13)
      Me.lblEstadoPedidoFacturado.TabIndex = 4
      Me.lblEstadoPedidoFacturado.Text = "Estado de Pedido luego de Factura:"
      '
      'chbUtilizaOrdenCompraPedidos
      '
      Me.chbUtilizaOrdenCompraPedidos.AutoSize = True
      Me.chbUtilizaOrdenCompraPedidos.BindearPropiedadControl = Nothing
      Me.chbUtilizaOrdenCompraPedidos.BindearPropiedadEntidad = Nothing
      Me.chbUtilizaOrdenCompraPedidos.ForeColorFocus = System.Drawing.Color.Red
      Me.chbUtilizaOrdenCompraPedidos.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
      Me.chbUtilizaOrdenCompraPedidos.IsPK = False
      Me.chbUtilizaOrdenCompraPedidos.IsRequired = False
      Me.chbUtilizaOrdenCompraPedidos.Key = Nothing
      Me.chbUtilizaOrdenCompraPedidos.LabelAsoc = Nothing
      Me.chbUtilizaOrdenCompraPedidos.Location = New System.Drawing.Point(54, 279)
      Me.chbUtilizaOrdenCompraPedidos.Name = "chbUtilizaOrdenCompraPedidos"
      Me.chbUtilizaOrdenCompraPedidos.Size = New System.Drawing.Size(196, 17)
      Me.chbUtilizaOrdenCompraPedidos.TabIndex = 14
      Me.chbUtilizaOrdenCompraPedidos.Text = "Utiliza Orden de Compra en Pedidos"
      Me.chbUtilizaOrdenCompraPedidos.UseVisualStyleBackColor = True
      '
      'chbPedidosPermiteFechaEntregaDistintas
      '
      Me.chbPedidosPermiteFechaEntregaDistintas.AutoSize = True
      Me.chbPedidosPermiteFechaEntregaDistintas.BindearPropiedadControl = Nothing
      Me.chbPedidosPermiteFechaEntregaDistintas.BindearPropiedadEntidad = Nothing
      Me.chbPedidosPermiteFechaEntregaDistintas.ForeColorFocus = System.Drawing.Color.Red
      Me.chbPedidosPermiteFechaEntregaDistintas.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
      Me.chbPedidosPermiteFechaEntregaDistintas.IsPK = False
      Me.chbPedidosPermiteFechaEntregaDistintas.IsRequired = False
      Me.chbPedidosPermiteFechaEntregaDistintas.Key = Nothing
      Me.chbPedidosPermiteFechaEntregaDistintas.LabelAsoc = Nothing
      Me.chbPedidosPermiteFechaEntregaDistintas.Location = New System.Drawing.Point(54, 256)
      Me.chbPedidosPermiteFechaEntregaDistintas.Name = "chbPedidosPermiteFechaEntregaDistintas"
      Me.chbPedidosPermiteFechaEntregaDistintas.Size = New System.Drawing.Size(258, 17)
      Me.chbPedidosPermiteFechaEntregaDistintas.TabIndex = 13
      Me.chbPedidosPermiteFechaEntregaDistintas.Text = "Permite Fecha de Entrega Distintas en Productos"
      Me.chbPedidosPermiteFechaEntregaDistintas.UseVisualStyleBackColor = True
      '
      'chbPermiteModificarClientePedido
      '
      Me.chbPermiteModificarClientePedido.AutoSize = True
      Me.chbPermiteModificarClientePedido.BindearPropiedadControl = Nothing
      Me.chbPermiteModificarClientePedido.BindearPropiedadEntidad = Nothing
      Me.chbPermiteModificarClientePedido.ForeColorFocus = System.Drawing.Color.Red
      Me.chbPermiteModificarClientePedido.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
      Me.chbPermiteModificarClientePedido.IsPK = False
      Me.chbPermiteModificarClientePedido.IsRequired = False
      Me.chbPermiteModificarClientePedido.Key = Nothing
      Me.chbPermiteModificarClientePedido.LabelAsoc = Nothing
      Me.chbPermiteModificarClientePedido.Location = New System.Drawing.Point(54, 187)
      Me.chbPermiteModificarClientePedido.Name = "chbPermiteModificarClientePedido"
      Me.chbPermiteModificarClientePedido.Size = New System.Drawing.Size(198, 17)
      Me.chbPermiteModificarClientePedido.TabIndex = 10
      Me.chbPermiteModificarClientePedido.Text = "Permite Modificar Cliente en Pedidos"
      Me.chbPermiteModificarClientePedido.UseVisualStyleBackColor = True
      '
      'chbPrefacturaConsumePedido
      '
      Me.chbPrefacturaConsumePedido.AutoSize = True
      Me.chbPrefacturaConsumePedido.BindearPropiedadControl = Nothing
      Me.chbPrefacturaConsumePedido.BindearPropiedadEntidad = Nothing
      Me.chbPrefacturaConsumePedido.ForeColorFocus = System.Drawing.Color.Red
      Me.chbPrefacturaConsumePedido.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
      Me.chbPrefacturaConsumePedido.IsPK = False
      Me.chbPrefacturaConsumePedido.IsRequired = False
      Me.chbPrefacturaConsumePedido.Key = Nothing
      Me.chbPrefacturaConsumePedido.LabelAsoc = Nothing
      Me.chbPrefacturaConsumePedido.Location = New System.Drawing.Point(54, 233)
      Me.chbPrefacturaConsumePedido.Name = "chbPrefacturaConsumePedido"
      Me.chbPrefacturaConsumePedido.Size = New System.Drawing.Size(157, 17)
      Me.chbPrefacturaConsumePedido.TabIndex = 12
      Me.chbPrefacturaConsumePedido.Text = "Prefactura consume Pedido"
      Me.chbPrefacturaConsumePedido.UseVisualStyleBackColor = True
      '
      'chbFacturarPedidoSeleccionado
      '
      Me.chbFacturarPedidoSeleccionado.AutoSize = True
      Me.chbFacturarPedidoSeleccionado.BindearPropiedadControl = Nothing
      Me.chbFacturarPedidoSeleccionado.BindearPropiedadEntidad = Nothing
      Me.chbFacturarPedidoSeleccionado.ForeColorFocus = System.Drawing.Color.Red
      Me.chbFacturarPedidoSeleccionado.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
      Me.chbFacturarPedidoSeleccionado.IsPK = False
      Me.chbFacturarPedidoSeleccionado.IsRequired = False
      Me.chbFacturarPedidoSeleccionado.Key = Nothing
      Me.chbFacturarPedidoSeleccionado.LabelAsoc = Nothing
      Me.chbFacturarPedidoSeleccionado.Location = New System.Drawing.Point(54, 210)
      Me.chbFacturarPedidoSeleccionado.Name = "chbFacturarPedidoSeleccionado"
      Me.chbFacturarPedidoSeleccionado.Size = New System.Drawing.Size(277, 17)
      Me.chbFacturarPedidoSeleccionado.TabIndex = 11
      Me.chbFacturarPedidoSeleccionado.Text = "Al facturar un pedido respetar el pedido seleccionado"
      Me.chbFacturarPedidoSeleccionado.UseVisualStyleBackColor = True
      '
      'chbConvertirPedidoEnFacturaConservaPreciosPedido
      '
      Me.chbConvertirPedidoEnFacturaConservaPreciosPedido.AutoSize = True
      Me.chbConvertirPedidoEnFacturaConservaPreciosPedido.BindearPropiedadControl = Nothing
      Me.chbConvertirPedidoEnFacturaConservaPreciosPedido.BindearPropiedadEntidad = Nothing
      Me.chbConvertirPedidoEnFacturaConservaPreciosPedido.ForeColorFocus = System.Drawing.Color.Red
      Me.chbConvertirPedidoEnFacturaConservaPreciosPedido.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
      Me.chbConvertirPedidoEnFacturaConservaPreciosPedido.IsPK = False
      Me.chbConvertirPedidoEnFacturaConservaPreciosPedido.IsRequired = False
      Me.chbConvertirPedidoEnFacturaConservaPreciosPedido.Key = Nothing
      Me.chbConvertirPedidoEnFacturaConservaPreciosPedido.LabelAsoc = Nothing
      Me.chbConvertirPedidoEnFacturaConservaPreciosPedido.Location = New System.Drawing.Point(54, 302)
      Me.chbConvertirPedidoEnFacturaConservaPreciosPedido.Name = "chbConvertirPedidoEnFacturaConservaPreciosPedido"
      Me.chbConvertirPedidoEnFacturaConservaPreciosPedido.Size = New System.Drawing.Size(325, 17)
      Me.chbConvertirPedidoEnFacturaConservaPreciosPedido.TabIndex = 15
      Me.chbConvertirPedidoEnFacturaConservaPreciosPedido.Text = "Al convertir Pedido en Factura conservar los precios del Pedido"
      Me.chbConvertirPedidoEnFacturaConservaPreciosPedido.UseVisualStyleBackColor = True
      '
      'chbPedidoGenPedProvOCObligatoria
      '
      Me.chbPedidoGenPedProvOCObligatoria.AutoSize = True
      Me.chbPedidoGenPedProvOCObligatoria.BindearPropiedadControl = Nothing
      Me.chbPedidoGenPedProvOCObligatoria.BindearPropiedadEntidad = Nothing
      Me.chbPedidoGenPedProvOCObligatoria.ForeColorFocus = System.Drawing.Color.Red
      Me.chbPedidoGenPedProvOCObligatoria.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
      Me.chbPedidoGenPedProvOCObligatoria.IsPK = False
      Me.chbPedidoGenPedProvOCObligatoria.IsRequired = False
      Me.chbPedidoGenPedProvOCObligatoria.Key = Nothing
      Me.chbPedidoGenPedProvOCObligatoria.LabelAsoc = Nothing
      Me.chbPedidoGenPedProvOCObligatoria.Location = New System.Drawing.Point(409, 282)
      Me.chbPedidoGenPedProvOCObligatoria.Name = "chbPedidoGenPedProvOCObligatoria"
      Me.chbPedidoGenPedProvOCObligatoria.Size = New System.Drawing.Size(433, 17)
      Me.chbPedidoGenPedProvOCObligatoria.TabIndex = 27
      Me.chbPedidoGenPedProvOCObligatoria.Text = "Generación de Pedidos Proveedores desde Pedidos de Clientes: Utiliza OC Obligator" &
    "ia"
      Me.chbPedidoGenPedProvOCObligatoria.UseVisualStyleBackColor = True
      '
      'chbPedidosValidaFacturaRemitoProveedor
      '
      Me.chbPedidosValidaFacturaRemitoProveedor.AutoSize = True
      Me.chbPedidosValidaFacturaRemitoProveedor.BindearPropiedadControl = Nothing
      Me.chbPedidosValidaFacturaRemitoProveedor.BindearPropiedadEntidad = Nothing
      Me.chbPedidosValidaFacturaRemitoProveedor.ForeColorFocus = System.Drawing.Color.Red
      Me.chbPedidosValidaFacturaRemitoProveedor.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
      Me.chbPedidosValidaFacturaRemitoProveedor.IsPK = False
      Me.chbPedidosValidaFacturaRemitoProveedor.IsRequired = False
      Me.chbPedidosValidaFacturaRemitoProveedor.Key = Nothing
      Me.chbPedidosValidaFacturaRemitoProveedor.LabelAsoc = Nothing
      Me.chbPedidosValidaFacturaRemitoProveedor.Location = New System.Drawing.Point(409, 353)
      Me.chbPedidosValidaFacturaRemitoProveedor.Name = "chbPedidosValidaFacturaRemitoProveedor"
      Me.chbPedidosValidaFacturaRemitoProveedor.Size = New System.Drawing.Size(367, 17)
      Me.chbPedidosValidaFacturaRemitoProveedor.TabIndex = 59
      Me.chbPedidosValidaFacturaRemitoProveedor.Text = "Valida ingreso de Factura y Remito del Proveedor en Invocacion Masiva"
      Me.chbPedidosValidaFacturaRemitoProveedor.UseVisualStyleBackColor = True
      '
      'chbPedidosPresupuestosAgrupaProductos
      '
      Me.chbPedidosPresupuestosAgrupaProductos.AutoSize = True
      Me.chbPedidosPresupuestosAgrupaProductos.BindearPropiedadControl = Nothing
      Me.chbPedidosPresupuestosAgrupaProductos.BindearPropiedadEntidad = Nothing
      Me.chbPedidosPresupuestosAgrupaProductos.ForeColorFocus = System.Drawing.Color.Red
      Me.chbPedidosPresupuestosAgrupaProductos.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
      Me.chbPedidosPresupuestosAgrupaProductos.IsPK = False
      Me.chbPedidosPresupuestosAgrupaProductos.IsRequired = False
      Me.chbPedidosPresupuestosAgrupaProductos.Key = Nothing
      Me.chbPedidosPresupuestosAgrupaProductos.LabelAsoc = Nothing
      Me.chbPedidosPresupuestosAgrupaProductos.Location = New System.Drawing.Point(409, 142)
      Me.chbPedidosPresupuestosAgrupaProductos.Name = "chbPedidosPresupuestosAgrupaProductos"
      Me.chbPedidosPresupuestosAgrupaProductos.Size = New System.Drawing.Size(379, 17)
      Me.chbPedidosPresupuestosAgrupaProductos.TabIndex = 60
      Me.chbPedidosPresupuestosAgrupaProductos.Text = "Pedidos y Presupuestos de Clientes agrupa productos con el mismo código"
      Me.chbPedidosPresupuestosAgrupaProductos.UseVisualStyleBackColor = True
      '
      'lblActualizaPrecioCopia
      '
      Me.lblActualizaPrecioCopia.AutoSize = True
      Me.lblActualizaPrecioCopia.ForeColor = System.Drawing.SystemColors.WindowText
      Me.lblActualizaPrecioCopia.LabelAsoc = Nothing
      Me.lblActualizaPrecioCopia.Location = New System.Drawing.Point(436, 116)
      Me.lblActualizaPrecioCopia.Name = "lblActualizaPrecioCopia"
      Me.lblActualizaPrecioCopia.Size = New System.Drawing.Size(351, 13)
      Me.lblActualizaPrecioCopia.TabIndex = 61
      Me.lblActualizaPrecioCopia.Text = "Adm. Presupuestos: Al Copiar un presupuesto Actualizar a precio Vigente"
      '
      'cmbCopiaPresupuestoActualizaPrecio
      '
      Me.cmbCopiaPresupuestoActualizaPrecio.BindearPropiedadControl = Nothing
      Me.cmbCopiaPresupuestoActualizaPrecio.BindearPropiedadEntidad = Nothing
      Me.cmbCopiaPresupuestoActualizaPrecio.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cmbCopiaPresupuestoActualizaPrecio.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.cmbCopiaPresupuestoActualizaPrecio.ForeColorFocus = System.Drawing.Color.Red
      Me.cmbCopiaPresupuestoActualizaPrecio.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.cmbCopiaPresupuestoActualizaPrecio.FormattingEnabled = True
      Me.cmbCopiaPresupuestoActualizaPrecio.IsPK = False
      Me.cmbCopiaPresupuestoActualizaPrecio.IsRequired = False
      Me.cmbCopiaPresupuestoActualizaPrecio.Key = Nothing
      Me.cmbCopiaPresupuestoActualizaPrecio.LabelAsoc = Me.Label8
      Me.cmbCopiaPresupuestoActualizaPrecio.Location = New System.Drawing.Point(787, 112)
      Me.cmbCopiaPresupuestoActualizaPrecio.Name = "cmbCopiaPresupuestoActualizaPrecio"
      Me.cmbCopiaPresupuestoActualizaPrecio.Size = New System.Drawing.Size(90, 21)
      Me.cmbCopiaPresupuestoActualizaPrecio.TabIndex = 62
      Me.cmbCopiaPresupuestoActualizaPrecio.Tag = ""
      '
      'grbPermitirControlarLimiteCredito
      '
      Me.grbPermitirControlarLimiteCredito.Controls.Add(Me.pnlPermitirControlarLimiteCredito_LimiteCredito)
      Me.grbPermitirControlarLimiteCredito.Controls.Add(Me.pnlPermitirControlarLimiteCredito_LimiteDiasVencimiento)
      Me.grbPermitirControlarLimiteCredito.Location = New System.Drawing.Point(409, 10)
      Me.grbPermitirControlarLimiteCredito.Name = "grbPermitirControlarLimiteCredito"
      Me.grbPermitirControlarLimiteCredito.Size = New System.Drawing.Size(468, 71)
      Me.grbPermitirControlarLimiteCredito.TabIndex = 86
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
      Me.pnlPermitirControlarLimiteCredito_LimiteCredito.Size = New System.Drawing.Size(456, 24)
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
      Me.pnlPermitirControlarLimiteCredito_LimiteDiasVencimiento.Size = New System.Drawing.Size(456, 24)
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
      'chbPedidosGeneraOrdenProduccionPorProducto
      '
      Me.chbPedidosGeneraOrdenProduccionPorProducto.AutoSize = True
      Me.chbPedidosGeneraOrdenProduccionPorProducto.BindearPropiedadControl = Nothing
      Me.chbPedidosGeneraOrdenProduccionPorProducto.BindearPropiedadEntidad = Nothing
      Me.chbPedidosGeneraOrdenProduccionPorProducto.ForeColorFocus = System.Drawing.Color.Red
      Me.chbPedidosGeneraOrdenProduccionPorProducto.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
      Me.chbPedidosGeneraOrdenProduccionPorProducto.IsPK = False
      Me.chbPedidosGeneraOrdenProduccionPorProducto.IsRequired = False
      Me.chbPedidosGeneraOrdenProduccionPorProducto.Key = Nothing
      Me.chbPedidosGeneraOrdenProduccionPorProducto.LabelAsoc = Nothing
      Me.chbPedidosGeneraOrdenProduccionPorProducto.Location = New System.Drawing.Point(409, 89)
      Me.chbPedidosGeneraOrdenProduccionPorProducto.Name = "chbPedidosGeneraOrdenProduccionPorProducto"
      Me.chbPedidosGeneraOrdenProduccionPorProducto.Size = New System.Drawing.Size(467, 17)
      Me.chbPedidosGeneraOrdenProduccionPorProducto.TabIndex = 60
      Me.chbPedidosGeneraOrdenProduccionPorProducto.Text = "Al convertir Pedido en Orden de Producción, Genera una Orden de Produccion por Pr" &
    "oducto."
      Me.chbPedidosGeneraOrdenProduccionPorProducto.UseVisualStyleBackColor = True
      '
      'lblMonedaPorDefecto
      '
      Me.lblMonedaPorDefecto.AutoSize = True
      Me.lblMonedaPorDefecto.LabelAsoc = Nothing
      Me.lblMonedaPorDefecto.Location = New System.Drawing.Point(424, 379)
      Me.lblMonedaPorDefecto.Name = "lblMonedaPorDefecto"
      Me.lblMonedaPorDefecto.Size = New System.Drawing.Size(215, 13)
      Me.lblMonedaPorDefecto.TabIndex = 87
      Me.lblMonedaPorDefecto.Text = "Moneda por Defecto Pedidos/Presupuestos"
      '
      'cmbMonedaPorDefecto
      '
      Me.cmbMonedaPorDefecto.BindearPropiedadControl = Nothing
      Me.cmbMonedaPorDefecto.BindearPropiedadEntidad = Nothing
      Me.cmbMonedaPorDefecto.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cmbMonedaPorDefecto.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.cmbMonedaPorDefecto.ForeColorFocus = System.Drawing.Color.Red
      Me.cmbMonedaPorDefecto.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.cmbMonedaPorDefecto.FormattingEnabled = True
      Me.cmbMonedaPorDefecto.IsPK = False
      Me.cmbMonedaPorDefecto.IsRequired = False
      Me.cmbMonedaPorDefecto.Items.AddRange(New Object() {"del producto"})
      Me.cmbMonedaPorDefecto.Key = Nothing
      Me.cmbMonedaPorDefecto.LabelAsoc = Me.lblMonedaPorDefecto
      Me.cmbMonedaPorDefecto.Location = New System.Drawing.Point(642, 374)
      Me.cmbMonedaPorDefecto.Name = "cmbMonedaPorDefecto"
      Me.cmbMonedaPorDefecto.Size = New System.Drawing.Size(97, 21)
      Me.cmbMonedaPorDefecto.TabIndex = 88
      '
      'ucConfPedidosPedidos
      '
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.Controls.Add(Me.lblMonedaPorDefecto)
      Me.Controls.Add(Me.cmbMonedaPorDefecto)
      Me.Controls.Add(Me.chbPedidosGeneraOrdenProduccionPorProducto)
      Me.Controls.Add(Me.grbPermitirControlarLimiteCredito)
      Me.Controls.Add(Me.cmbCopiaPresupuestoActualizaPrecio)
      Me.Controls.Add(Me.lblActualizaPrecioCopia)
      Me.Controls.Add(Me.chbPedidosPresupuestosAgrupaProductos)
      Me.Controls.Add(Me.chbPedidosValidaFacturaRemitoProveedor)
      Me.Controls.Add(Me.chbPedidosConservaOrdenProductos)
      Me.Controls.Add(Me.chbPermiteModificarDescRecPedidos)
      Me.Controls.Add(Me.txtDiasEntregaImportacion)
      Me.Controls.Add(Me.lblDiasEntregaImportacion)
      Me.Controls.Add(Me.chbImportarPedidosAltaProd)
      Me.Controls.Add(Me.chbPedidosOcultarRentabilidad)
      Me.Controls.Add(Me.chbPedidosModificaPrecioProducto)
      Me.Controls.Add(Me.chbPedidosModificaDescripSolicitaKilos)
      Me.Controls.Add(Me.chbPedidosPendientesFacturarAutomatico)
      Me.Controls.Add(Me.chbPedidosVisualizaAntesImprimir)
      Me.Controls.Add(Me.chbPedidosSolicitaTransportista)
      Me.Controls.Add(Me.chbPedidosSolicitaComprobanteGenerar)
      Me.Controls.Add(Me.cmbEstadosPedidos)
      Me.Controls.Add(Me.chbPedidosPermiteModificarCambio)
      Me.Controls.Add(Me.cmbImportarPedidosTipoComprobante)
      Me.Controls.Add(Me.cmbImportarPedidosFormatoArchivo)
      Me.Controls.Add(Me.cmbEstadoPresupuestoAlAnularPedido)
      Me.Controls.Add(Me.cmbEstadosPedidosFacturado)
      Me.Controls.Add(Me.lblImportarPedidosTipoComprobante)
      Me.Controls.Add(Me.lblImportarPedidosFormatoArchivo)
      Me.Controls.Add(Me.lblEstadoPedidoPendiente)
      Me.Controls.Add(Me.Label8)
      Me.Controls.Add(Me.chbUtilizaOrdenCompraPedidos)
      Me.Controls.Add(Me.lblEstadoPedidoFacturado)
      Me.Controls.Add(Me.chbPedidosPermiteFechaEntregaDistintas)
      Me.Controls.Add(Me.chbPermiteModificarClientePedido)
      Me.Controls.Add(Me.chbPrefacturaConsumePedido)
      Me.Controls.Add(Me.chbFacturarPedidoSeleccionado)
      Me.Controls.Add(Me.chbConvertirPedidoEnFacturaConservaPreciosPedido)
      Me.Controls.Add(Me.chbPedidoGenPedProvOCObligatoria)
      Me.Name = "ucConfPedidosPedidos"
      Me.Size = New System.Drawing.Size(900, 430)
      Me.Controls.SetChildIndex(Me.chbPedidoGenPedProvOCObligatoria, 0)
      Me.Controls.SetChildIndex(Me.chbConvertirPedidoEnFacturaConservaPreciosPedido, 0)
      Me.Controls.SetChildIndex(Me.chbFacturarPedidoSeleccionado, 0)
      Me.Controls.SetChildIndex(Me.chbPrefacturaConsumePedido, 0)
      Me.Controls.SetChildIndex(Me.chbPermiteModificarClientePedido, 0)
      Me.Controls.SetChildIndex(Me.chbPedidosPermiteFechaEntregaDistintas, 0)
      Me.Controls.SetChildIndex(Me.lblEstadoPedidoFacturado, 0)
      Me.Controls.SetChildIndex(Me.chbUtilizaOrdenCompraPedidos, 0)
      Me.Controls.SetChildIndex(Me.Label8, 0)
      Me.Controls.SetChildIndex(Me.lblEstadoPedidoPendiente, 0)
      Me.Controls.SetChildIndex(Me.lblImportarPedidosFormatoArchivo, 0)
      Me.Controls.SetChildIndex(Me.lblImportarPedidosTipoComprobante, 0)
      Me.Controls.SetChildIndex(Me.cmbEstadosPedidosFacturado, 0)
      Me.Controls.SetChildIndex(Me.cmbEstadoPresupuestoAlAnularPedido, 0)
      Me.Controls.SetChildIndex(Me.cmbImportarPedidosFormatoArchivo, 0)
      Me.Controls.SetChildIndex(Me.cmbImportarPedidosTipoComprobante, 0)
      Me.Controls.SetChildIndex(Me.chbPedidosPermiteModificarCambio, 0)
      Me.Controls.SetChildIndex(Me.cmbEstadosPedidos, 0)
      Me.Controls.SetChildIndex(Me.chbPedidosSolicitaComprobanteGenerar, 0)
      Me.Controls.SetChildIndex(Me.chbPedidosSolicitaTransportista, 0)
      Me.Controls.SetChildIndex(Me.chbPedidosVisualizaAntesImprimir, 0)
      Me.Controls.SetChildIndex(Me.chbPedidosPendientesFacturarAutomatico, 0)
      Me.Controls.SetChildIndex(Me.chbPedidosModificaDescripSolicitaKilos, 0)
      Me.Controls.SetChildIndex(Me.chbPedidosModificaPrecioProducto, 0)
      Me.Controls.SetChildIndex(Me.chbPedidosOcultarRentabilidad, 0)
      Me.Controls.SetChildIndex(Me.chbImportarPedidosAltaProd, 0)
      Me.Controls.SetChildIndex(Me.lblDiasEntregaImportacion, 0)
      Me.Controls.SetChildIndex(Me.txtDiasEntregaImportacion, 0)
      Me.Controls.SetChildIndex(Me.chbPermiteModificarDescRecPedidos, 0)
      Me.Controls.SetChildIndex(Me.chbPedidosConservaOrdenProductos, 0)
      Me.Controls.SetChildIndex(Me.chbPedidosValidaFacturaRemitoProveedor, 0)
      Me.Controls.SetChildIndex(Me.chbPedidosPresupuestosAgrupaProductos, 0)
      Me.Controls.SetChildIndex(Me.lblActualizaPrecioCopia, 0)
      Me.Controls.SetChildIndex(Me.cmbCopiaPresupuestoActualizaPrecio, 0)
      Me.Controls.SetChildIndex(Me.grbPermitirControlarLimiteCredito, 0)
      Me.Controls.SetChildIndex(Me.chbPedidosGeneraOrdenProduccionPorProducto, 0)
      Me.Controls.SetChildIndex(Me.cmbMonedaPorDefecto, 0)
      Me.Controls.SetChildIndex(Me.lblMonedaPorDefecto, 0)
      Me.grbPermitirControlarLimiteCredito.ResumeLayout(False)
      Me.pnlPermitirControlarLimiteCredito_LimiteCredito.ResumeLayout(False)
      Me.pnlPermitirControlarLimiteCredito_LimiteCredito.PerformLayout()
      Me.pnlPermitirControlarLimiteCredito_LimiteDiasVencimiento.ResumeLayout(False)
      Me.pnlPermitirControlarLimiteCredito_LimiteDiasVencimiento.PerformLayout()
      Me.ResumeLayout(False)
      Me.PerformLayout()

   End Sub

   Friend WithEvents chbPedidosConservaOrdenProductos As Controles.CheckBox
   Friend WithEvents chbPermiteModificarDescRecPedidos As Controles.CheckBox
   Friend WithEvents txtDiasEntregaImportacion As Controles.TextBox
   Friend WithEvents lblDiasEntregaImportacion As Controles.Label
   Friend WithEvents chbImportarPedidosAltaProd As Controles.CheckBox
   Friend WithEvents chbPedidosOcultarRentabilidad As Controles.CheckBox
   Friend WithEvents chbPedidosModificaPrecioProducto As Controles.CheckBox
   Friend WithEvents chbPedidosModificaDescripSolicitaKilos As Controles.CheckBox
   Friend WithEvents chbPedidosPendientesFacturarAutomatico As Controles.CheckBox
   Friend WithEvents chbPedidosVisualizaAntesImprimir As Controles.CheckBox
   Friend WithEvents chbPedidosSolicitaTransportista As Controles.CheckBox
   Friend WithEvents chbPedidosSolicitaComprobanteGenerar As Controles.CheckBox
   Friend WithEvents cmbEstadosPedidos As Controles.ComboBox
   Friend WithEvents lblEstadoPedidoPendiente As Controles.Label
   Friend WithEvents chbPedidosPermiteModificarCambio As Controles.CheckBox
   Friend WithEvents cmbImportarPedidosTipoComprobante As Controles.ComboBox
   Friend WithEvents lblImportarPedidosTipoComprobante As Controles.Label
   Friend WithEvents cmbImportarPedidosFormatoArchivo As Controles.ComboBox
   Friend WithEvents lblImportarPedidosFormatoArchivo As Controles.Label
   Friend WithEvents cmbEstadoPresupuestoAlAnularPedido As Controles.ComboBox
   Friend WithEvents Label8 As Controles.Label
   Friend WithEvents cmbEstadosPedidosFacturado As Controles.ComboBox
   Friend WithEvents lblEstadoPedidoFacturado As Controles.Label
   Friend WithEvents chbUtilizaOrdenCompraPedidos As Controles.CheckBox
   Friend WithEvents chbPedidosPermiteFechaEntregaDistintas As Controles.CheckBox
   Friend WithEvents chbPermiteModificarClientePedido As Controles.CheckBox
   Friend WithEvents chbPrefacturaConsumePedido As Controles.CheckBox
   Friend WithEvents chbFacturarPedidoSeleccionado As Controles.CheckBox
   Friend WithEvents chbConvertirPedidoEnFacturaConservaPreciosPedido As Controles.CheckBox
   Friend WithEvents chbPedidoGenPedProvOCObligatoria As Controles.CheckBox
    Friend WithEvents chbPedidosValidaFacturaRemitoProveedor As Controles.CheckBox
	Friend WithEvents chbPedidosPresupuestosAgrupaProductos As Controles.CheckBox
    Friend WithEvents lblActualizaPrecioCopia As Controles.Label
    Friend WithEvents cmbCopiaPresupuestoActualizaPrecio As Controles.ComboBox
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
	Friend WithEvents chbPedidosGeneraOrdenProduccionPorProducto As Controles.CheckBox
    Friend WithEvents lblMonedaPorDefecto As Controles.Label
    Friend WithEvents cmbMonedaPorDefecto As Controles.ComboBox
End Class
