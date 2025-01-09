<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ucConfCompras
   Inherits ucConfBase

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
        Me.chbComprasConservaOrdenProductos = New Eniac.Controles.CheckBox()
        Me.chbComprasSoloCargaProductosDelProveedor = New Eniac.Controles.CheckBox()
        Me.chbComprasSolicitaComprador = New Eniac.Controles.CheckBox()
        Me.chbExpensasPermitirCargarProductosSinConceptos = New Eniac.Controles.CheckBox()
        Me.chbActualizarPreciosDesdeComprasPriorizaIVAProducto = New Eniac.Controles.CheckBox()
        Me.chbExpensasPermiteConSinConcepto = New Eniac.Controles.CheckBox()
        Me.grpActualizarPreciosCalculoDesdeCompras = New System.Windows.Forms.GroupBox()
        Me.radActualizarPreciosCalculoDesdeCompras_SobreCosto = New System.Windows.Forms.RadioButton()
        Me.radActualizarPreciosCalculoDesdeCompras_SobreVenta = New System.Windows.Forms.RadioButton()
        Me.radActualizarPreciosCalculoDesdeCompras_PorcActual = New System.Windows.Forms.RadioButton()
        Me.chbComprasPosicionarNombreProducto = New Eniac.Controles.CheckBox()
        Me.txtComprasToleranciaIvaManual = New Eniac.Controles.TextBox()
        Me.lblComprasToleranciaIvaManual = New Eniac.Controles.Label()
        Me.chbActualizaPreciosUtilizaAjusteDecimales = New Eniac.Controles.CheckBox()
        Me.chbComprasPedidosInvocadosProvMantieneFormaPago = New Eniac.Controles.CheckBox()
        Me.chbComprasVisualizaPorcVarCosto = New Eniac.Controles.CheckBox()
        Me.chbComprasVisualizaCodigoProveedor = New Eniac.Controles.CheckBox()
        Me.chbComprasImpresionVisualizaNroSerie = New Eniac.Controles.CheckBox()
        Me.GroupBox5 = New System.Windows.Forms.GroupBox()
        Me.txtComprasDecimalesRedondeoEnCantidad = New Eniac.Controles.TextBox()
        Me.lblComprasDecimalesRedondeoEnCantidad = New Eniac.Controles.Label()
        Me.lblComprasDecimalesMostrarEnCantidad = New Eniac.Controles.Label()
        Me.txtComprasDecimalesRedondeoEnPrecio = New Eniac.Controles.TextBox()
        Me.lblComprasDecimalesRedondeoEnPrecio = New Eniac.Controles.Label()
        Me.lblComprasDecimalesMostrarEnItems = New Eniac.Controles.Label()
        Me.lblComprasDecimalesEnTotal = New Eniac.Controles.Label()
        Me.lblComprasDecimalesEnTotalXProducto = New Eniac.Controles.Label()
        Me.txtComprasDecimalesMostrarEnCantidad = New Eniac.Controles.TextBox()
        Me.txtComprasDecimalesEnTotal = New Eniac.Controles.TextBox()
        Me.txtComprasDecimalesEnTotalXProducto = New Eniac.Controles.TextBox()
        Me.txtComprasDecimalesMostrarEnItems = New Eniac.Controles.TextBox()
        Me.txtIdentifNDEBCheqRechCompra = New Eniac.Controles.TextBox()
        Me.lblIdentifNDebCheqCheqCompra = New Eniac.Controles.Label()
        Me.chbComprasContadoEsEnPesos = New Eniac.Controles.CheckBox()
        Me.chbPermiteModificarDescCompras = New Eniac.Controles.CheckBox()
        Me.txtUltimaHojaCompras = New Eniac.Controles.TextBox()
        Me.lblUltimaHojaCompras = New Eniac.Controles.Label()
        Me.chbComprasIgnorarPCdeCaja = New Eniac.Controles.CheckBox()
        Me.chbActualizaCostosPreciosVenta = New Eniac.Controles.CheckBox()
        Me.chbComprasSinProductos = New Eniac.Controles.CheckBox()
        Me.chbVisualizaComprasAntesImprimir = New Eniac.Controles.CheckBox()
        Me.chbComprasConProductosEnCero = New Eniac.Controles.CheckBox()
        Me.lblIdentifNDEBNoGL = New Eniac.Controles.Label()
        Me.txtIdentifNDEBNoGL = New Eniac.Controles.TextBox()
        Me.lblIdentifNCREDNoGL = New Eniac.Controles.Label()
        Me.txtIdentifNCREDNoGL = New Eniac.Controles.TextBox()
        Me.cmbCompraPrecioCosto = New Eniac.Controles.ComboBox()
        Me.txtComprasProductoLiquidacionTarjetas = New Eniac.Controles.TextBox()
        Me.lblComprasProductoLiquidacionTarjetas = New Eniac.Controles.Label()
        Me.grpActualizarPreciosCalculoDesdeCompras.SuspendLayout()
        Me.GroupBox5.SuspendLayout()
        Me.SuspendLayout()
        '
        'chbComprasConservaOrdenProductos
        '
        Me.chbComprasConservaOrdenProductos.AutoSize = True
        Me.chbComprasConservaOrdenProductos.BindearPropiedadControl = Nothing
        Me.chbComprasConservaOrdenProductos.BindearPropiedadEntidad = Nothing
        Me.chbComprasConservaOrdenProductos.ForeColorFocus = System.Drawing.Color.Red
        Me.chbComprasConservaOrdenProductos.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbComprasConservaOrdenProductos.IsPK = False
        Me.chbComprasConservaOrdenProductos.IsRequired = False
        Me.chbComprasConservaOrdenProductos.Key = Nothing
        Me.chbComprasConservaOrdenProductos.LabelAsoc = Nothing
        Me.chbComprasConservaOrdenProductos.Location = New System.Drawing.Point(9, 371)
        Me.chbComprasConservaOrdenProductos.Name = "chbComprasConservaOrdenProductos"
        Me.chbComprasConservaOrdenProductos.Size = New System.Drawing.Size(237, 17)
        Me.chbComprasConservaOrdenProductos.TabIndex = 15
        Me.chbComprasConservaOrdenProductos.Text = "Conserva Orden de los Productos en la Grilla"
        Me.chbComprasConservaOrdenProductos.UseVisualStyleBackColor = True
        '
        'chbComprasSoloCargaProductosDelProveedor
        '
        Me.chbComprasSoloCargaProductosDelProveedor.BindearPropiedadControl = Nothing
        Me.chbComprasSoloCargaProductosDelProveedor.BindearPropiedadEntidad = Nothing
        Me.chbComprasSoloCargaProductosDelProveedor.ForeColorFocus = System.Drawing.Color.Red
        Me.chbComprasSoloCargaProductosDelProveedor.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbComprasSoloCargaProductosDelProveedor.IsPK = False
        Me.chbComprasSoloCargaProductosDelProveedor.IsRequired = False
        Me.chbComprasSoloCargaProductosDelProveedor.Key = Nothing
        Me.chbComprasSoloCargaProductosDelProveedor.LabelAsoc = Nothing
        Me.chbComprasSoloCargaProductosDelProveedor.Location = New System.Drawing.Point(9, 211)
        Me.chbComprasSoloCargaProductosDelProveedor.Name = "chbComprasSoloCargaProductosDelProveedor"
        Me.chbComprasSoloCargaProductosDelProveedor.Size = New System.Drawing.Size(220, 21)
        Me.chbComprasSoloCargaProductosDelProveedor.TabIndex = 8
        Me.chbComprasSoloCargaProductosDelProveedor.Tag = ""
        Me.chbComprasSoloCargaProductosDelProveedor.Text = "Solo cargar Productos del Proveedor"
        Me.chbComprasSoloCargaProductosDelProveedor.UseVisualStyleBackColor = True
        '
        'chbComprasSolicitaComprador
        '
        Me.chbComprasSolicitaComprador.BindearPropiedadControl = Nothing
        Me.chbComprasSolicitaComprador.BindearPropiedadEntidad = Nothing
        Me.chbComprasSolicitaComprador.ForeColorFocus = System.Drawing.Color.Red
        Me.chbComprasSolicitaComprador.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbComprasSolicitaComprador.IsPK = False
        Me.chbComprasSolicitaComprador.IsRequired = False
        Me.chbComprasSolicitaComprador.Key = Nothing
        Me.chbComprasSolicitaComprador.LabelAsoc = Nothing
        Me.chbComprasSolicitaComprador.Location = New System.Drawing.Point(389, 343)
        Me.chbComprasSolicitaComprador.Name = "chbComprasSolicitaComprador"
        Me.chbComprasSolicitaComprador.Size = New System.Drawing.Size(316, 24)
        Me.chbComprasSolicitaComprador.TabIndex = 29
        Me.chbComprasSolicitaComprador.Text = "Solicita el Comprador luego de Cargar el Proveedor"
        Me.chbComprasSolicitaComprador.UseVisualStyleBackColor = True
        '
        'chbExpensasPermitirCargarProductosSinConceptos
        '
        Me.chbExpensasPermitirCargarProductosSinConceptos.BindearPropiedadControl = Nothing
        Me.chbExpensasPermitirCargarProductosSinConceptos.BindearPropiedadEntidad = Nothing
        Me.chbExpensasPermitirCargarProductosSinConceptos.ForeColorFocus = System.Drawing.Color.Red
        Me.chbExpensasPermitirCargarProductosSinConceptos.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbExpensasPermitirCargarProductosSinConceptos.IsPK = False
        Me.chbExpensasPermitirCargarProductosSinConceptos.IsRequired = False
        Me.chbExpensasPermitirCargarProductosSinConceptos.Key = Nothing
        Me.chbExpensasPermitirCargarProductosSinConceptos.LabelAsoc = Nothing
        Me.chbExpensasPermitirCargarProductosSinConceptos.Location = New System.Drawing.Point(389, 318)
        Me.chbExpensasPermitirCargarProductosSinConceptos.Name = "chbExpensasPermitirCargarProductosSinConceptos"
        Me.chbExpensasPermitirCargarProductosSinConceptos.Size = New System.Drawing.Size(374, 25)
        Me.chbExpensasPermitirCargarProductosSinConceptos.TabIndex = 28
        Me.chbExpensasPermitirCargarProductosSinConceptos.Text = "Expensas: Permitir cargar productos sin Conceptos"
        Me.chbExpensasPermitirCargarProductosSinConceptos.UseVisualStyleBackColor = True
        '
        'chbActualizarPreciosDesdeComprasPriorizaIVAProducto
        '
        Me.chbActualizarPreciosDesdeComprasPriorizaIVAProducto.BindearPropiedadControl = Nothing
        Me.chbActualizarPreciosDesdeComprasPriorizaIVAProducto.BindearPropiedadEntidad = Nothing
        Me.chbActualizarPreciosDesdeComprasPriorizaIVAProducto.ForeColorFocus = System.Drawing.Color.Red
        Me.chbActualizarPreciosDesdeComprasPriorizaIVAProducto.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbActualizarPreciosDesdeComprasPriorizaIVAProducto.IsPK = False
        Me.chbActualizarPreciosDesdeComprasPriorizaIVAProducto.IsRequired = False
        Me.chbActualizarPreciosDesdeComprasPriorizaIVAProducto.Key = Nothing
        Me.chbActualizarPreciosDesdeComprasPriorizaIVAProducto.LabelAsoc = Nothing
        Me.chbActualizarPreciosDesdeComprasPriorizaIVAProducto.Location = New System.Drawing.Point(9, 342)
        Me.chbActualizarPreciosDesdeComprasPriorizaIVAProducto.Name = "chbActualizarPreciosDesdeComprasPriorizaIVAProducto"
        Me.chbActualizarPreciosDesdeComprasPriorizaIVAProducto.Size = New System.Drawing.Size(369, 21)
        Me.chbActualizarPreciosDesdeComprasPriorizaIVAProducto.TabIndex = 14
        Me.chbActualizarPreciosDesdeComprasPriorizaIVAProducto.Tag = ""
        Me.chbActualizarPreciosDesdeComprasPriorizaIVAProducto.Text = "Actualiza Precios desde compras: Prioriza IVA del Producto"
        Me.chbActualizarPreciosDesdeComprasPriorizaIVAProducto.UseVisualStyleBackColor = True
        '
        'chbExpensasPermiteConSinConcepto
        '
        Me.chbExpensasPermiteConSinConcepto.BindearPropiedadControl = Nothing
        Me.chbExpensasPermiteConSinConcepto.BindearPropiedadEntidad = Nothing
        Me.chbExpensasPermiteConSinConcepto.ForeColorFocus = System.Drawing.Color.Red
        Me.chbExpensasPermiteConSinConcepto.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbExpensasPermiteConSinConcepto.IsPK = False
        Me.chbExpensasPermiteConSinConcepto.IsRequired = False
        Me.chbExpensasPermiteConSinConcepto.Key = Nothing
        Me.chbExpensasPermiteConSinConcepto.LabelAsoc = Nothing
        Me.chbExpensasPermiteConSinConcepto.Location = New System.Drawing.Point(389, 293)
        Me.chbExpensasPermiteConSinConcepto.Name = "chbExpensasPermiteConSinConcepto"
        Me.chbExpensasPermiteConSinConcepto.Size = New System.Drawing.Size(374, 25)
        Me.chbExpensasPermiteConSinConcepto.TabIndex = 27
        Me.chbExpensasPermiteConSinConcepto.Text = "Expensas: Compra permite productos con y sin concepto"
        Me.chbExpensasPermiteConSinConcepto.UseVisualStyleBackColor = True
        '
        'grpActualizarPreciosCalculoDesdeCompras
        '
        Me.grpActualizarPreciosCalculoDesdeCompras.Controls.Add(Me.radActualizarPreciosCalculoDesdeCompras_SobreCosto)
        Me.grpActualizarPreciosCalculoDesdeCompras.Controls.Add(Me.radActualizarPreciosCalculoDesdeCompras_SobreVenta)
        Me.grpActualizarPreciosCalculoDesdeCompras.Controls.Add(Me.radActualizarPreciosCalculoDesdeCompras_PorcActual)
        Me.grpActualizarPreciosCalculoDesdeCompras.Location = New System.Drawing.Point(9, 284)
        Me.grpActualizarPreciosCalculoDesdeCompras.Name = "grpActualizarPreciosCalculoDesdeCompras"
        Me.grpActualizarPreciosCalculoDesdeCompras.Size = New System.Drawing.Size(291, 50)
        Me.grpActualizarPreciosCalculoDesdeCompras.TabIndex = 13
        Me.grpActualizarPreciosCalculoDesdeCompras.TabStop = False
        Me.grpActualizarPreciosCalculoDesdeCompras.Tag = "ACTUALIZARPRECIOSCALCULO"
        Me.grpActualizarPreciosCalculoDesdeCompras.Text = "Actualizar Precios cálculo desde Compras"
        '
        'radActualizarPreciosCalculoDesdeCompras_SobreCosto
        '
        Me.radActualizarPreciosCalculoDesdeCompras_SobreCosto.AutoSize = True
        Me.radActualizarPreciosCalculoDesdeCompras_SobreCosto.Location = New System.Drawing.Point(198, 22)
        Me.radActualizarPreciosCalculoDesdeCompras_SobreCosto.Name = "radActualizarPreciosCalculoDesdeCompras_SobreCosto"
        Me.radActualizarPreciosCalculoDesdeCompras_SobreCosto.Size = New System.Drawing.Size(83, 17)
        Me.radActualizarPreciosCalculoDesdeCompras_SobreCosto.TabIndex = 2
        Me.radActualizarPreciosCalculoDesdeCompras_SobreCosto.Tag = "COSTO"
        Me.radActualizarPreciosCalculoDesdeCompras_SobreCosto.Text = "Sobre Costo"
        Me.radActualizarPreciosCalculoDesdeCompras_SobreCosto.UseVisualStyleBackColor = True
        '
        'radActualizarPreciosCalculoDesdeCompras_SobreVenta
        '
        Me.radActualizarPreciosCalculoDesdeCompras_SobreVenta.AutoSize = True
        Me.radActualizarPreciosCalculoDesdeCompras_SobreVenta.Location = New System.Drawing.Point(106, 22)
        Me.radActualizarPreciosCalculoDesdeCompras_SobreVenta.Name = "radActualizarPreciosCalculoDesdeCompras_SobreVenta"
        Me.radActualizarPreciosCalculoDesdeCompras_SobreVenta.Size = New System.Drawing.Size(84, 17)
        Me.radActualizarPreciosCalculoDesdeCompras_SobreVenta.TabIndex = 1
        Me.radActualizarPreciosCalculoDesdeCompras_SobreVenta.Tag = "VENTA"
        Me.radActualizarPreciosCalculoDesdeCompras_SobreVenta.Text = "Sobre Venta"
        Me.radActualizarPreciosCalculoDesdeCompras_SobreVenta.UseVisualStyleBackColor = True
        '
        'radActualizarPreciosCalculoDesdeCompras_PorcActual
        '
        Me.radActualizarPreciosCalculoDesdeCompras_PorcActual.AutoSize = True
        Me.radActualizarPreciosCalculoDesdeCompras_PorcActual.Checked = True
        Me.radActualizarPreciosCalculoDesdeCompras_PorcActual.Location = New System.Drawing.Point(16, 22)
        Me.radActualizarPreciosCalculoDesdeCompras_PorcActual.Name = "radActualizarPreciosCalculoDesdeCompras_PorcActual"
        Me.radActualizarPreciosCalculoDesdeCompras_PorcActual.Size = New System.Drawing.Size(83, 17)
        Me.radActualizarPreciosCalculoDesdeCompras_PorcActual.TabIndex = 0
        Me.radActualizarPreciosCalculoDesdeCompras_PorcActual.TabStop = True
        Me.radActualizarPreciosCalculoDesdeCompras_PorcActual.Tag = "ACTUAL"
        Me.radActualizarPreciosCalculoDesdeCompras_PorcActual.Text = "Porc. Actual"
        Me.radActualizarPreciosCalculoDesdeCompras_PorcActual.UseVisualStyleBackColor = True
        '
        'chbComprasPosicionarNombreProducto
        '
        Me.chbComprasPosicionarNombreProducto.BindearPropiedadControl = Nothing
        Me.chbComprasPosicionarNombreProducto.BindearPropiedadEntidad = Nothing
        Me.chbComprasPosicionarNombreProducto.ForeColorFocus = System.Drawing.Color.Red
        Me.chbComprasPosicionarNombreProducto.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbComprasPosicionarNombreProducto.IsPK = False
        Me.chbComprasPosicionarNombreProducto.IsRequired = False
        Me.chbComprasPosicionarNombreProducto.Key = Nothing
        Me.chbComprasPosicionarNombreProducto.LabelAsoc = Nothing
        Me.chbComprasPosicionarNombreProducto.Location = New System.Drawing.Point(389, 268)
        Me.chbComprasPosicionarNombreProducto.Name = "chbComprasPosicionarNombreProducto"
        Me.chbComprasPosicionarNombreProducto.Size = New System.Drawing.Size(374, 25)
        Me.chbComprasPosicionarNombreProducto.TabIndex = 26
        Me.chbComprasPosicionarNombreProducto.Text = "Posicionar en Nombre del Producto en Lugar del Codigo."
        Me.chbComprasPosicionarNombreProducto.UseVisualStyleBackColor = True
        '
        'txtComprasToleranciaIvaManual
        '
        Me.txtComprasToleranciaIvaManual.BindearPropiedadControl = Nothing
        Me.txtComprasToleranciaIvaManual.BindearPropiedadEntidad = Nothing
        Me.txtComprasToleranciaIvaManual.ForeColorFocus = System.Drawing.Color.Red
        Me.txtComprasToleranciaIvaManual.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtComprasToleranciaIvaManual.Formato = ""
        Me.txtComprasToleranciaIvaManual.IsDecimal = True
        Me.txtComprasToleranciaIvaManual.IsNumber = True
        Me.txtComprasToleranciaIvaManual.IsPK = False
        Me.txtComprasToleranciaIvaManual.IsRequired = False
        Me.txtComprasToleranciaIvaManual.Key = ""
        Me.txtComprasToleranciaIvaManual.LabelAsoc = Me.lblComprasToleranciaIvaManual
        Me.txtComprasToleranciaIvaManual.Location = New System.Drawing.Point(9, 260)
        Me.txtComprasToleranciaIvaManual.MaxLength = 4
        Me.txtComprasToleranciaIvaManual.Name = "txtComprasToleranciaIvaManual"
        Me.txtComprasToleranciaIvaManual.Size = New System.Drawing.Size(35, 20)
        Me.txtComprasToleranciaIvaManual.TabIndex = 11
        Me.txtComprasToleranciaIvaManual.Text = "0.00"
        Me.txtComprasToleranciaIvaManual.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblComprasToleranciaIvaManual
        '
        Me.lblComprasToleranciaIvaManual.AutoSize = True
        Me.lblComprasToleranciaIvaManual.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblComprasToleranciaIvaManual.LabelAsoc = Nothing
        Me.lblComprasToleranciaIvaManual.Location = New System.Drawing.Point(50, 263)
        Me.lblComprasToleranciaIvaManual.Name = "lblComprasToleranciaIvaManual"
        Me.lblComprasToleranciaIvaManual.Size = New System.Drawing.Size(113, 13)
        Me.lblComprasToleranciaIvaManual.TabIndex = 12
        Me.lblComprasToleranciaIvaManual.Text = "Tolerancia Iva Manual"
        '
        'chbActualizaPreciosUtilizaAjusteDecimales
        '
        Me.chbActualizaPreciosUtilizaAjusteDecimales.BindearPropiedadControl = Nothing
        Me.chbActualizaPreciosUtilizaAjusteDecimales.BindearPropiedadEntidad = Nothing
        Me.chbActualizaPreciosUtilizaAjusteDecimales.ForeColorFocus = System.Drawing.Color.Red
        Me.chbActualizaPreciosUtilizaAjusteDecimales.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbActualizaPreciosUtilizaAjusteDecimales.IsPK = False
        Me.chbActualizaPreciosUtilizaAjusteDecimales.IsRequired = False
        Me.chbActualizaPreciosUtilizaAjusteDecimales.Key = Nothing
        Me.chbActualizaPreciosUtilizaAjusteDecimales.LabelAsoc = Nothing
        Me.chbActualizaPreciosUtilizaAjusteDecimales.Location = New System.Drawing.Point(389, 245)
        Me.chbActualizaPreciosUtilizaAjusteDecimales.Name = "chbActualizaPreciosUtilizaAjusteDecimales"
        Me.chbActualizaPreciosUtilizaAjusteDecimales.Size = New System.Drawing.Size(400, 21)
        Me.chbActualizaPreciosUtilizaAjusteDecimales.TabIndex = 25
        Me.chbActualizaPreciosUtilizaAjusteDecimales.Tag = "ACTUALIZAPRECIOSUTILIZAAJUSTEA"
        Me.chbActualizaPreciosUtilizaAjusteDecimales.Text = "Actualiza Precios: Utiliza Ajuste a decimales "
        Me.chbActualizaPreciosUtilizaAjusteDecimales.UseVisualStyleBackColor = True
        '
        'chbComprasPedidosInvocadosProvMantieneFormaPago
        '
        Me.chbComprasPedidosInvocadosProvMantieneFormaPago.BindearPropiedadControl = Nothing
        Me.chbComprasPedidosInvocadosProvMantieneFormaPago.BindearPropiedadEntidad = Nothing
        Me.chbComprasPedidosInvocadosProvMantieneFormaPago.ForeColorFocus = System.Drawing.Color.Red
        Me.chbComprasPedidosInvocadosProvMantieneFormaPago.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbComprasPedidosInvocadosProvMantieneFormaPago.IsPK = False
        Me.chbComprasPedidosInvocadosProvMantieneFormaPago.IsRequired = False
        Me.chbComprasPedidosInvocadosProvMantieneFormaPago.Key = Nothing
        Me.chbComprasPedidosInvocadosProvMantieneFormaPago.LabelAsoc = Nothing
        Me.chbComprasPedidosInvocadosProvMantieneFormaPago.Location = New System.Drawing.Point(389, 222)
        Me.chbComprasPedidosInvocadosProvMantieneFormaPago.Name = "chbComprasPedidosInvocadosProvMantieneFormaPago"
        Me.chbComprasPedidosInvocadosProvMantieneFormaPago.Size = New System.Drawing.Size(400, 21)
        Me.chbComprasPedidosInvocadosProvMantieneFormaPago.TabIndex = 24
        Me.chbComprasPedidosInvocadosProvMantieneFormaPago.Tag = "COMPRASPEDIDOSPROVINVOCADOSMANTIENEFORMAPAGO"
        Me.chbComprasPedidosInvocadosProvMantieneFormaPago.Text = "Invocar Pedidos: Mantiene Forma de Pago del Pedido Proveedor invocado"
        Me.chbComprasPedidosInvocadosProvMantieneFormaPago.UseVisualStyleBackColor = True
        '
        'chbComprasVisualizaPorcVarCosto
        '
        Me.chbComprasVisualizaPorcVarCosto.BindearPropiedadControl = Nothing
        Me.chbComprasVisualizaPorcVarCosto.BindearPropiedadEntidad = Nothing
        Me.chbComprasVisualizaPorcVarCosto.ForeColorFocus = System.Drawing.Color.Red
        Me.chbComprasVisualizaPorcVarCosto.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbComprasVisualizaPorcVarCosto.IsPK = False
        Me.chbComprasVisualizaPorcVarCosto.IsRequired = False
        Me.chbComprasVisualizaPorcVarCosto.Key = Nothing
        Me.chbComprasVisualizaPorcVarCosto.LabelAsoc = Nothing
        Me.chbComprasVisualizaPorcVarCosto.Location = New System.Drawing.Point(389, 199)
        Me.chbComprasVisualizaPorcVarCosto.Name = "chbComprasVisualizaPorcVarCosto"
        Me.chbComprasVisualizaPorcVarCosto.Size = New System.Drawing.Size(400, 21)
        Me.chbComprasVisualizaPorcVarCosto.TabIndex = 23
        Me.chbComprasVisualizaPorcVarCosto.Tag = "VISUALIZAPORCVARCOSTO"
        Me.chbComprasVisualizaPorcVarCosto.Text = "Visualiza porcentaje de variación de costo"
        Me.chbComprasVisualizaPorcVarCosto.UseVisualStyleBackColor = True
        '
        'chbComprasVisualizaCodigoProveedor
        '
        Me.chbComprasVisualizaCodigoProveedor.BindearPropiedadControl = Nothing
        Me.chbComprasVisualizaCodigoProveedor.BindearPropiedadEntidad = Nothing
        Me.chbComprasVisualizaCodigoProveedor.ForeColorFocus = System.Drawing.Color.Red
        Me.chbComprasVisualizaCodigoProveedor.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbComprasVisualizaCodigoProveedor.IsPK = False
        Me.chbComprasVisualizaCodigoProveedor.IsRequired = False
        Me.chbComprasVisualizaCodigoProveedor.Key = Nothing
        Me.chbComprasVisualizaCodigoProveedor.LabelAsoc = Nothing
        Me.chbComprasVisualizaCodigoProveedor.Location = New System.Drawing.Point(389, 177)
        Me.chbComprasVisualizaCodigoProveedor.Name = "chbComprasVisualizaCodigoProveedor"
        Me.chbComprasVisualizaCodigoProveedor.Size = New System.Drawing.Size(400, 21)
        Me.chbComprasVisualizaCodigoProveedor.TabIndex = 22
        Me.chbComprasVisualizaCodigoProveedor.Tag = "VISUALIZACODIGOPROVEEDOR"
        Me.chbComprasVisualizaCodigoProveedor.Text = "Visualiza código del Proveedor"
        Me.chbComprasVisualizaCodigoProveedor.UseVisualStyleBackColor = True
        '
        'chbComprasImpresionVisualizaNroSerie
        '
        Me.chbComprasImpresionVisualizaNroSerie.BindearPropiedadControl = Nothing
        Me.chbComprasImpresionVisualizaNroSerie.BindearPropiedadEntidad = Nothing
        Me.chbComprasImpresionVisualizaNroSerie.ForeColorFocus = System.Drawing.Color.Red
        Me.chbComprasImpresionVisualizaNroSerie.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbComprasImpresionVisualizaNroSerie.IsPK = False
        Me.chbComprasImpresionVisualizaNroSerie.IsRequired = False
        Me.chbComprasImpresionVisualizaNroSerie.Key = Nothing
        Me.chbComprasImpresionVisualizaNroSerie.LabelAsoc = Nothing
        Me.chbComprasImpresionVisualizaNroSerie.Location = New System.Drawing.Point(389, 157)
        Me.chbComprasImpresionVisualizaNroSerie.Name = "chbComprasImpresionVisualizaNroSerie"
        Me.chbComprasImpresionVisualizaNroSerie.Size = New System.Drawing.Size(400, 21)
        Me.chbComprasImpresionVisualizaNroSerie.TabIndex = 21
        Me.chbComprasImpresionVisualizaNroSerie.Tag = "COMPRASIMPRESIONVISNROSERIE"
        Me.chbComprasImpresionVisualizaNroSerie.Text = "Impresión Comprobante muestra Nros Serie"
        Me.chbComprasImpresionVisualizaNroSerie.UseVisualStyleBackColor = True
        '
        'GroupBox5
        '
        Me.GroupBox5.Controls.Add(Me.txtComprasDecimalesRedondeoEnCantidad)
        Me.GroupBox5.Controls.Add(Me.lblComprasDecimalesMostrarEnCantidad)
        Me.GroupBox5.Controls.Add(Me.txtComprasDecimalesRedondeoEnPrecio)
        Me.GroupBox5.Controls.Add(Me.lblComprasDecimalesMostrarEnItems)
        Me.GroupBox5.Controls.Add(Me.lblComprasDecimalesRedondeoEnCantidad)
        Me.GroupBox5.Controls.Add(Me.lblComprasDecimalesEnTotal)
        Me.GroupBox5.Controls.Add(Me.lblComprasDecimalesEnTotalXProducto)
        Me.GroupBox5.Controls.Add(Me.lblComprasDecimalesRedondeoEnPrecio)
        Me.GroupBox5.Controls.Add(Me.txtComprasDecimalesMostrarEnCantidad)
        Me.GroupBox5.Controls.Add(Me.txtComprasDecimalesEnTotal)
        Me.GroupBox5.Controls.Add(Me.txtComprasDecimalesEnTotalXProducto)
        Me.GroupBox5.Controls.Add(Me.txtComprasDecimalesMostrarEnItems)
        Me.GroupBox5.Location = New System.Drawing.Point(389, 55)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(405, 98)
        Me.GroupBox5.TabIndex = 20
        Me.GroupBox5.TabStop = False
        Me.GroupBox5.Text = "Cantidad de decimales"
        '
        'txtComprasDecimalesRedondeoEnCantidad
        '
        Me.txtComprasDecimalesRedondeoEnCantidad.BindearPropiedadControl = Nothing
        Me.txtComprasDecimalesRedondeoEnCantidad.BindearPropiedadEntidad = Nothing
        Me.txtComprasDecimalesRedondeoEnCantidad.ForeColorFocus = System.Drawing.Color.Red
        Me.txtComprasDecimalesRedondeoEnCantidad.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtComprasDecimalesRedondeoEnCantidad.Formato = ""
        Me.txtComprasDecimalesRedondeoEnCantidad.IsDecimal = False
        Me.txtComprasDecimalesRedondeoEnCantidad.IsNumber = True
        Me.txtComprasDecimalesRedondeoEnCantidad.IsPK = False
        Me.txtComprasDecimalesRedondeoEnCantidad.IsRequired = False
        Me.txtComprasDecimalesRedondeoEnCantidad.Key = ""
        Me.txtComprasDecimalesRedondeoEnCantidad.LabelAsoc = Me.lblComprasDecimalesRedondeoEnCantidad
        Me.txtComprasDecimalesRedondeoEnCantidad.Location = New System.Drawing.Point(218, 19)
        Me.txtComprasDecimalesRedondeoEnCantidad.MaxLength = 3
        Me.txtComprasDecimalesRedondeoEnCantidad.Name = "txtComprasDecimalesRedondeoEnCantidad"
        Me.txtComprasDecimalesRedondeoEnCantidad.Size = New System.Drawing.Size(35, 20)
        Me.txtComprasDecimalesRedondeoEnCantidad.TabIndex = 6
        Me.txtComprasDecimalesRedondeoEnCantidad.Text = "2"
        Me.txtComprasDecimalesRedondeoEnCantidad.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'lblComprasDecimalesRedondeoEnCantidad
        '
        Me.lblComprasDecimalesRedondeoEnCantidad.AutoSize = True
        Me.lblComprasDecimalesRedondeoEnCantidad.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblComprasDecimalesRedondeoEnCantidad.LabelAsoc = Nothing
        Me.lblComprasDecimalesRedondeoEnCantidad.Location = New System.Drawing.Point(256, 23)
        Me.lblComprasDecimalesRedondeoEnCantidad.Name = "lblComprasDecimalesRedondeoEnCantidad"
        Me.lblComprasDecimalesRedondeoEnCantidad.Size = New System.Drawing.Size(117, 13)
        Me.lblComprasDecimalesRedondeoEnCantidad.TabIndex = 7
        Me.lblComprasDecimalesRedondeoEnCantidad.Text = "Redondeo en Cantidad"
        '
        'lblComprasDecimalesMostrarEnCantidad
        '
        Me.lblComprasDecimalesMostrarEnCantidad.AutoSize = True
        Me.lblComprasDecimalesMostrarEnCantidad.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblComprasDecimalesMostrarEnCantidad.LabelAsoc = Nothing
        Me.lblComprasDecimalesMostrarEnCantidad.Location = New System.Drawing.Point(256, 49)
        Me.lblComprasDecimalesMostrarEnCantidad.Name = "lblComprasDecimalesMostrarEnCantidad"
        Me.lblComprasDecimalesMostrarEnCantidad.Size = New System.Drawing.Size(102, 13)
        Me.lblComprasDecimalesMostrarEnCantidad.TabIndex = 9
        Me.lblComprasDecimalesMostrarEnCantidad.Text = "Mostrar en Cantidad"
        '
        'txtComprasDecimalesRedondeoEnPrecio
        '
        Me.txtComprasDecimalesRedondeoEnPrecio.BindearPropiedadControl = Nothing
        Me.txtComprasDecimalesRedondeoEnPrecio.BindearPropiedadEntidad = Nothing
        Me.txtComprasDecimalesRedondeoEnPrecio.ForeColorFocus = System.Drawing.Color.Red
        Me.txtComprasDecimalesRedondeoEnPrecio.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtComprasDecimalesRedondeoEnPrecio.Formato = ""
        Me.txtComprasDecimalesRedondeoEnPrecio.IsDecimal = False
        Me.txtComprasDecimalesRedondeoEnPrecio.IsNumber = True
        Me.txtComprasDecimalesRedondeoEnPrecio.IsPK = False
        Me.txtComprasDecimalesRedondeoEnPrecio.IsRequired = False
        Me.txtComprasDecimalesRedondeoEnPrecio.Key = ""
        Me.txtComprasDecimalesRedondeoEnPrecio.LabelAsoc = Me.lblComprasDecimalesRedondeoEnPrecio
        Me.txtComprasDecimalesRedondeoEnPrecio.Location = New System.Drawing.Point(6, 19)
        Me.txtComprasDecimalesRedondeoEnPrecio.MaxLength = 3
        Me.txtComprasDecimalesRedondeoEnPrecio.Name = "txtComprasDecimalesRedondeoEnPrecio"
        Me.txtComprasDecimalesRedondeoEnPrecio.Size = New System.Drawing.Size(35, 20)
        Me.txtComprasDecimalesRedondeoEnPrecio.TabIndex = 0
        Me.txtComprasDecimalesRedondeoEnPrecio.Text = "2"
        Me.txtComprasDecimalesRedondeoEnPrecio.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'lblComprasDecimalesRedondeoEnPrecio
        '
        Me.lblComprasDecimalesRedondeoEnPrecio.AutoSize = True
        Me.lblComprasDecimalesRedondeoEnPrecio.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblComprasDecimalesRedondeoEnPrecio.LabelAsoc = Nothing
        Me.lblComprasDecimalesRedondeoEnPrecio.Location = New System.Drawing.Point(44, 23)
        Me.lblComprasDecimalesRedondeoEnPrecio.Name = "lblComprasDecimalesRedondeoEnPrecio"
        Me.lblComprasDecimalesRedondeoEnPrecio.Size = New System.Drawing.Size(105, 13)
        Me.lblComprasDecimalesRedondeoEnPrecio.TabIndex = 1
        Me.lblComprasDecimalesRedondeoEnPrecio.Text = "Redondeo en Precio"
        '
        'lblComprasDecimalesMostrarEnItems
        '
        Me.lblComprasDecimalesMostrarEnItems.AutoSize = True
        Me.lblComprasDecimalesMostrarEnItems.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblComprasDecimalesMostrarEnItems.LabelAsoc = Nothing
        Me.lblComprasDecimalesMostrarEnItems.Location = New System.Drawing.Point(44, 49)
        Me.lblComprasDecimalesMostrarEnItems.Name = "lblComprasDecimalesMostrarEnItems"
        Me.lblComprasDecimalesMostrarEnItems.Size = New System.Drawing.Size(90, 13)
        Me.lblComprasDecimalesMostrarEnItems.TabIndex = 3
        Me.lblComprasDecimalesMostrarEnItems.Text = "Mostrar en Precio"
        '
        'lblComprasDecimalesEnTotal
        '
        Me.lblComprasDecimalesEnTotal.AutoSize = True
        Me.lblComprasDecimalesEnTotal.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblComprasDecimalesEnTotal.LabelAsoc = Nothing
        Me.lblComprasDecimalesEnTotal.Location = New System.Drawing.Point(256, 75)
        Me.lblComprasDecimalesEnTotal.Name = "lblComprasDecimalesEnTotal"
        Me.lblComprasDecimalesEnTotal.Size = New System.Drawing.Size(146, 13)
        Me.lblComprasDecimalesEnTotal.TabIndex = 11
        Me.lblComprasDecimalesEnTotal.Text = "Mostrar en Totales Generales"
        '
        'lblComprasDecimalesEnTotalXProducto
        '
        Me.lblComprasDecimalesEnTotalXProducto.AutoSize = True
        Me.lblComprasDecimalesEnTotalXProducto.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblComprasDecimalesEnTotalXProducto.LabelAsoc = Nothing
        Me.lblComprasDecimalesEnTotalXProducto.Location = New System.Drawing.Point(44, 75)
        Me.lblComprasDecimalesEnTotalXProducto.Name = "lblComprasDecimalesEnTotalXProducto"
        Me.lblComprasDecimalesEnTotalXProducto.Size = New System.Drawing.Size(138, 13)
        Me.lblComprasDecimalesEnTotalXProducto.TabIndex = 5
        Me.lblComprasDecimalesEnTotalXProducto.Text = "Mostrar en Total x Producto"
        '
        'txtComprasDecimalesMostrarEnCantidad
        '
        Me.txtComprasDecimalesMostrarEnCantidad.BindearPropiedadControl = Nothing
        Me.txtComprasDecimalesMostrarEnCantidad.BindearPropiedadEntidad = Nothing
        Me.txtComprasDecimalesMostrarEnCantidad.ForeColorFocus = System.Drawing.Color.Red
        Me.txtComprasDecimalesMostrarEnCantidad.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtComprasDecimalesMostrarEnCantidad.Formato = ""
        Me.txtComprasDecimalesMostrarEnCantidad.IsDecimal = False
        Me.txtComprasDecimalesMostrarEnCantidad.IsNumber = True
        Me.txtComprasDecimalesMostrarEnCantidad.IsPK = False
        Me.txtComprasDecimalesMostrarEnCantidad.IsRequired = False
        Me.txtComprasDecimalesMostrarEnCantidad.Key = ""
        Me.txtComprasDecimalesMostrarEnCantidad.LabelAsoc = Me.lblComprasDecimalesMostrarEnCantidad
        Me.txtComprasDecimalesMostrarEnCantidad.Location = New System.Drawing.Point(218, 45)
        Me.txtComprasDecimalesMostrarEnCantidad.MaxLength = 3
        Me.txtComprasDecimalesMostrarEnCantidad.Name = "txtComprasDecimalesMostrarEnCantidad"
        Me.txtComprasDecimalesMostrarEnCantidad.Size = New System.Drawing.Size(35, 20)
        Me.txtComprasDecimalesMostrarEnCantidad.TabIndex = 8
        Me.txtComprasDecimalesMostrarEnCantidad.Text = "2"
        Me.txtComprasDecimalesMostrarEnCantidad.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtComprasDecimalesEnTotal
        '
        Me.txtComprasDecimalesEnTotal.BindearPropiedadControl = Nothing
        Me.txtComprasDecimalesEnTotal.BindearPropiedadEntidad = Nothing
        Me.txtComprasDecimalesEnTotal.ForeColorFocus = System.Drawing.Color.Red
        Me.txtComprasDecimalesEnTotal.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtComprasDecimalesEnTotal.Formato = ""
        Me.txtComprasDecimalesEnTotal.IsDecimal = False
        Me.txtComprasDecimalesEnTotal.IsNumber = True
        Me.txtComprasDecimalesEnTotal.IsPK = False
        Me.txtComprasDecimalesEnTotal.IsRequired = False
        Me.txtComprasDecimalesEnTotal.Key = ""
        Me.txtComprasDecimalesEnTotal.LabelAsoc = Me.lblComprasDecimalesEnTotal
        Me.txtComprasDecimalesEnTotal.Location = New System.Drawing.Point(218, 71)
        Me.txtComprasDecimalesEnTotal.MaxLength = 3
        Me.txtComprasDecimalesEnTotal.Name = "txtComprasDecimalesEnTotal"
        Me.txtComprasDecimalesEnTotal.Size = New System.Drawing.Size(35, 20)
        Me.txtComprasDecimalesEnTotal.TabIndex = 10
        Me.txtComprasDecimalesEnTotal.Text = "2"
        Me.txtComprasDecimalesEnTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtComprasDecimalesEnTotalXProducto
        '
        Me.txtComprasDecimalesEnTotalXProducto.BindearPropiedadControl = Nothing
        Me.txtComprasDecimalesEnTotalXProducto.BindearPropiedadEntidad = Nothing
        Me.txtComprasDecimalesEnTotalXProducto.ForeColorFocus = System.Drawing.Color.Red
        Me.txtComprasDecimalesEnTotalXProducto.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtComprasDecimalesEnTotalXProducto.Formato = ""
        Me.txtComprasDecimalesEnTotalXProducto.IsDecimal = False
        Me.txtComprasDecimalesEnTotalXProducto.IsNumber = True
        Me.txtComprasDecimalesEnTotalXProducto.IsPK = False
        Me.txtComprasDecimalesEnTotalXProducto.IsRequired = False
        Me.txtComprasDecimalesEnTotalXProducto.Key = ""
        Me.txtComprasDecimalesEnTotalXProducto.LabelAsoc = Me.lblComprasDecimalesEnTotalXProducto
        Me.txtComprasDecimalesEnTotalXProducto.Location = New System.Drawing.Point(6, 71)
        Me.txtComprasDecimalesEnTotalXProducto.MaxLength = 3
        Me.txtComprasDecimalesEnTotalXProducto.Name = "txtComprasDecimalesEnTotalXProducto"
        Me.txtComprasDecimalesEnTotalXProducto.Size = New System.Drawing.Size(35, 20)
        Me.txtComprasDecimalesEnTotalXProducto.TabIndex = 4
        Me.txtComprasDecimalesEnTotalXProducto.Text = "2"
        Me.txtComprasDecimalesEnTotalXProducto.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtComprasDecimalesMostrarEnItems
        '
        Me.txtComprasDecimalesMostrarEnItems.BindearPropiedadControl = Nothing
        Me.txtComprasDecimalesMostrarEnItems.BindearPropiedadEntidad = Nothing
        Me.txtComprasDecimalesMostrarEnItems.ForeColorFocus = System.Drawing.Color.Red
        Me.txtComprasDecimalesMostrarEnItems.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtComprasDecimalesMostrarEnItems.Formato = ""
        Me.txtComprasDecimalesMostrarEnItems.IsDecimal = False
        Me.txtComprasDecimalesMostrarEnItems.IsNumber = True
        Me.txtComprasDecimalesMostrarEnItems.IsPK = False
        Me.txtComprasDecimalesMostrarEnItems.IsRequired = False
        Me.txtComprasDecimalesMostrarEnItems.Key = ""
        Me.txtComprasDecimalesMostrarEnItems.LabelAsoc = Me.lblComprasDecimalesMostrarEnItems
        Me.txtComprasDecimalesMostrarEnItems.Location = New System.Drawing.Point(6, 45)
        Me.txtComprasDecimalesMostrarEnItems.MaxLength = 3
        Me.txtComprasDecimalesMostrarEnItems.Name = "txtComprasDecimalesMostrarEnItems"
        Me.txtComprasDecimalesMostrarEnItems.Size = New System.Drawing.Size(35, 20)
        Me.txtComprasDecimalesMostrarEnItems.TabIndex = 2
        Me.txtComprasDecimalesMostrarEnItems.Text = "2"
        Me.txtComprasDecimalesMostrarEnItems.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtIdentifNDEBCheqRechCompra
        '
        Me.txtIdentifNDEBCheqRechCompra.BindearPropiedadControl = Nothing
        Me.txtIdentifNDEBCheqRechCompra.BindearPropiedadEntidad = Nothing
        Me.txtIdentifNDEBCheqRechCompra.ForeColorFocus = System.Drawing.Color.Red
        Me.txtIdentifNDEBCheqRechCompra.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtIdentifNDEBCheqRechCompra.Formato = ""
        Me.txtIdentifNDEBCheqRechCompra.IsDecimal = False
        Me.txtIdentifNDEBCheqRechCompra.IsNumber = False
        Me.txtIdentifNDEBCheqRechCompra.IsPK = False
        Me.txtIdentifNDEBCheqRechCompra.IsRequired = False
        Me.txtIdentifNDEBCheqRechCompra.Key = ""
        Me.txtIdentifNDEBCheqRechCompra.LabelAsoc = Me.lblIdentifNDebCheqCheqCompra
        Me.txtIdentifNDEBCheqRechCompra.Location = New System.Drawing.Point(207, 233)
        Me.txtIdentifNDEBCheqRechCompra.MaxLength = 20
        Me.txtIdentifNDEBCheqRechCompra.Name = "txtIdentifNDEBCheqRechCompra"
        Me.txtIdentifNDEBCheqRechCompra.Size = New System.Drawing.Size(171, 20)
        Me.txtIdentifNDEBCheqRechCompra.TabIndex = 10
        Me.txtIdentifNDEBCheqRechCompra.Text = "NDEBCHEQRECH"
        '
        'lblIdentifNDebCheqCheqCompra
        '
        Me.lblIdentifNDebCheqCheqCompra.AutoSize = True
        Me.lblIdentifNDebCheqCheqCompra.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblIdentifNDebCheqCheqCompra.LabelAsoc = Nothing
        Me.lblIdentifNDebCheqCheqCompra.Location = New System.Drawing.Point(6, 237)
        Me.lblIdentifNDebCheqCheqCompra.Name = "lblIdentifNDebCheqCheqCompra"
        Me.lblIdentifNDebCheqCheqCompra.Size = New System.Drawing.Size(200, 13)
        Me.lblIdentifNDebCheqCheqCompra.TabIndex = 9
        Me.lblIdentifNDebCheqCheqCompra.Text = "Identif. de N.Debito Cheque  Rechazado"
        '
        'chbComprasContadoEsEnPesos
        '
        Me.chbComprasContadoEsEnPesos.BindearPropiedadControl = Nothing
        Me.chbComprasContadoEsEnPesos.BindearPropiedadEntidad = Nothing
        Me.chbComprasContadoEsEnPesos.ForeColorFocus = System.Drawing.Color.Red
        Me.chbComprasContadoEsEnPesos.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbComprasContadoEsEnPesos.IsPK = False
        Me.chbComprasContadoEsEnPesos.IsRequired = False
        Me.chbComprasContadoEsEnPesos.Key = Nothing
        Me.chbComprasContadoEsEnPesos.LabelAsoc = Nothing
        Me.chbComprasContadoEsEnPesos.Location = New System.Drawing.Point(9, 184)
        Me.chbComprasContadoEsEnPesos.Name = "chbComprasContadoEsEnPesos"
        Me.chbComprasContadoEsEnPesos.Size = New System.Drawing.Size(369, 21)
        Me.chbComprasContadoEsEnPesos.TabIndex = 7
        Me.chbComprasContadoEsEnPesos.Tag = "COMPRASCONTADOESENPESOS"
        Me.chbComprasContadoEsEnPesos.Text = "Comprobante en Contado es en Pesos"
        Me.chbComprasContadoEsEnPesos.UseVisualStyleBackColor = True
        '
        'chbPermiteModificarDescCompras
        '
        Me.chbPermiteModificarDescCompras.BindearPropiedadControl = Nothing
        Me.chbPermiteModificarDescCompras.BindearPropiedadEntidad = Nothing
        Me.chbPermiteModificarDescCompras.ForeColorFocus = System.Drawing.Color.Red
        Me.chbPermiteModificarDescCompras.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbPermiteModificarDescCompras.IsPK = False
        Me.chbPermiteModificarDescCompras.IsRequired = False
        Me.chbPermiteModificarDescCompras.Key = Nothing
        Me.chbPermiteModificarDescCompras.LabelAsoc = Nothing
        Me.chbPermiteModificarDescCompras.Location = New System.Drawing.Point(9, 157)
        Me.chbPermiteModificarDescCompras.Name = "chbPermiteModificarDescCompras"
        Me.chbPermiteModificarDescCompras.Size = New System.Drawing.Size(369, 21)
        Me.chbPermiteModificarDescCompras.TabIndex = 6
        Me.chbPermiteModificarDescCompras.Tag = "COMPRASMODIFICADESCRIPCIONPRODUCTO"
        Me.chbPermiteModificarDescCompras.Text = "Permite modificar la descripción del Producto."
        Me.chbPermiteModificarDescCompras.UseVisualStyleBackColor = True
        '
        'txtUltimaHojaCompras
        '
        Me.txtUltimaHojaCompras.BindearPropiedadControl = Nothing
        Me.txtUltimaHojaCompras.BindearPropiedadEntidad = Nothing
        Me.txtUltimaHojaCompras.ForeColorFocus = System.Drawing.Color.Red
        Me.txtUltimaHojaCompras.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtUltimaHojaCompras.Formato = ""
        Me.txtUltimaHojaCompras.IsDecimal = False
        Me.txtUltimaHojaCompras.IsNumber = True
        Me.txtUltimaHojaCompras.IsPK = False
        Me.txtUltimaHojaCompras.IsRequired = False
        Me.txtUltimaHojaCompras.Key = ""
        Me.txtUltimaHojaCompras.LabelAsoc = Me.lblUltimaHojaCompras
        Me.txtUltimaHojaCompras.Location = New System.Drawing.Point(9, 27)
        Me.txtUltimaHojaCompras.MaxLength = 3
        Me.txtUltimaHojaCompras.Name = "txtUltimaHojaCompras"
        Me.txtUltimaHojaCompras.Size = New System.Drawing.Size(35, 20)
        Me.txtUltimaHojaCompras.TabIndex = 0
        Me.txtUltimaHojaCompras.Tag = "NROHOJALIBROIVACOMPRAS"
        Me.txtUltimaHojaCompras.Text = "1"
        Me.txtUltimaHojaCompras.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblUltimaHojaCompras
        '
        Me.lblUltimaHojaCompras.AutoSize = True
        Me.lblUltimaHojaCompras.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblUltimaHojaCompras.LabelAsoc = Nothing
        Me.lblUltimaHojaCompras.Location = New System.Drawing.Point(50, 30)
        Me.lblUltimaHojaCompras.Name = "lblUltimaHojaCompras"
        Me.lblUltimaHojaCompras.Size = New System.Drawing.Size(201, 13)
        Me.lblUltimaHojaCompras.TabIndex = 1
        Me.lblUltimaHojaCompras.Text = "Ultima hoja impresa del libro IVA Compras"
        '
        'chbComprasIgnorarPCdeCaja
        '
        Me.chbComprasIgnorarPCdeCaja.AutoSize = True
        Me.chbComprasIgnorarPCdeCaja.BindearPropiedadControl = Nothing
        Me.chbComprasIgnorarPCdeCaja.BindearPropiedadEntidad = Nothing
        Me.chbComprasIgnorarPCdeCaja.ForeColorFocus = System.Drawing.Color.Red
        Me.chbComprasIgnorarPCdeCaja.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbComprasIgnorarPCdeCaja.IsPK = False
        Me.chbComprasIgnorarPCdeCaja.IsRequired = False
        Me.chbComprasIgnorarPCdeCaja.Key = Nothing
        Me.chbComprasIgnorarPCdeCaja.LabelAsoc = Nothing
        Me.chbComprasIgnorarPCdeCaja.Location = New System.Drawing.Point(9, 134)
        Me.chbComprasIgnorarPCdeCaja.Name = "chbComprasIgnorarPCdeCaja"
        Me.chbComprasIgnorarPCdeCaja.Size = New System.Drawing.Size(115, 17)
        Me.chbComprasIgnorarPCdeCaja.TabIndex = 5
        Me.chbComprasIgnorarPCdeCaja.Tag = "COMPRASIGNORARPCDECAJA"
        Me.chbComprasIgnorarPCdeCaja.Text = "Ignorar PC de Caja"
        Me.chbComprasIgnorarPCdeCaja.UseVisualStyleBackColor = True
        '
        'chbActualizaCostosPreciosVenta
        '
        Me.chbActualizaCostosPreciosVenta.AutoSize = True
        Me.chbActualizaCostosPreciosVenta.BindearPropiedadControl = Nothing
        Me.chbActualizaCostosPreciosVenta.BindearPropiedadEntidad = Nothing
        Me.chbActualizaCostosPreciosVenta.ForeColorFocus = System.Drawing.Color.Red
        Me.chbActualizaCostosPreciosVenta.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbActualizaCostosPreciosVenta.IsPK = False
        Me.chbActualizaCostosPreciosVenta.IsRequired = False
        Me.chbActualizaCostosPreciosVenta.Key = Nothing
        Me.chbActualizaCostosPreciosVenta.LabelAsoc = Nothing
        Me.chbActualizaCostosPreciosVenta.Location = New System.Drawing.Point(389, 28)
        Me.chbActualizaCostosPreciosVenta.Name = "chbActualizaCostosPreciosVenta"
        Me.chbActualizaCostosPreciosVenta.Size = New System.Drawing.Size(198, 17)
        Me.chbActualizaCostosPreciosVenta.TabIndex = 18
        Me.chbActualizaCostosPreciosVenta.Tag = "ACTUALIZACOSTOYPRECIOVENTA"
        Me.chbActualizaCostosPreciosVenta.Text = "Actualiza costos y precios de ventas"
        Me.chbActualizaCostosPreciosVenta.UseVisualStyleBackColor = True
        '
        'chbComprasSinProductos
        '
        Me.chbComprasSinProductos.BindearPropiedadControl = Nothing
        Me.chbComprasSinProductos.BindearPropiedadEntidad = Nothing
        Me.chbComprasSinProductos.ForeColorFocus = System.Drawing.Color.Red
        Me.chbComprasSinProductos.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbComprasSinProductos.IsPK = False
        Me.chbComprasSinProductos.IsRequired = False
        Me.chbComprasSinProductos.Key = Nothing
        Me.chbComprasSinProductos.LabelAsoc = Nothing
        Me.chbComprasSinProductos.Location = New System.Drawing.Point(9, 106)
        Me.chbComprasSinProductos.Name = "chbComprasSinProductos"
        Me.chbComprasSinProductos.Size = New System.Drawing.Size(369, 21)
        Me.chbComprasSinProductos.TabIndex = 4
        Me.chbComprasSinProductos.Tag = "COMPRASSINPRODUCTOS"
        Me.chbComprasSinProductos.Text = "Sin Detallar Productos"
        Me.chbComprasSinProductos.UseVisualStyleBackColor = True
        '
        'chbVisualizaComprasAntesImprimir
        '
        Me.chbVisualizaComprasAntesImprimir.BindearPropiedadControl = Nothing
        Me.chbVisualizaComprasAntesImprimir.BindearPropiedadEntidad = Nothing
        Me.chbVisualizaComprasAntesImprimir.ForeColorFocus = System.Drawing.Color.Red
        Me.chbVisualizaComprasAntesImprimir.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbVisualizaComprasAntesImprimir.IsPK = False
        Me.chbVisualizaComprasAntesImprimir.IsRequired = False
        Me.chbVisualizaComprasAntesImprimir.Key = Nothing
        Me.chbVisualizaComprasAntesImprimir.LabelAsoc = Nothing
        Me.chbVisualizaComprasAntesImprimir.Location = New System.Drawing.Point(9, 80)
        Me.chbVisualizaComprasAntesImprimir.Name = "chbVisualizaComprasAntesImprimir"
        Me.chbVisualizaComprasAntesImprimir.Size = New System.Drawing.Size(369, 21)
        Me.chbVisualizaComprasAntesImprimir.TabIndex = 3
        Me.chbVisualizaComprasAntesImprimir.Tag = "VISUALIZACOMPROBANTESDECOMPRA"
        Me.chbVisualizaComprasAntesImprimir.Text = "Visualiza los Comprobantes de Compras antes de Imprimir"
        Me.chbVisualizaComprasAntesImprimir.UseVisualStyleBackColor = True
        '
        'chbComprasConProductosEnCero
        '
        Me.chbComprasConProductosEnCero.BindearPropiedadControl = Nothing
        Me.chbComprasConProductosEnCero.BindearPropiedadEntidad = Nothing
        Me.chbComprasConProductosEnCero.ForeColorFocus = System.Drawing.Color.Red
        Me.chbComprasConProductosEnCero.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbComprasConProductosEnCero.IsPK = False
        Me.chbComprasConProductosEnCero.IsRequired = False
        Me.chbComprasConProductosEnCero.Key = Nothing
        Me.chbComprasConProductosEnCero.LabelAsoc = Nothing
        Me.chbComprasConProductosEnCero.Location = New System.Drawing.Point(9, 53)
        Me.chbComprasConProductosEnCero.Name = "chbComprasConProductosEnCero"
        Me.chbComprasConProductosEnCero.Size = New System.Drawing.Size(369, 21)
        Me.chbComprasConProductosEnCero.TabIndex = 2
        Me.chbComprasConProductosEnCero.Tag = "COMPRASCONPRODUCTOSENCERO"
        Me.chbComprasConProductosEnCero.Text = "Permite ingresar Productos con Precio Cero"
        Me.chbComprasConProductosEnCero.UseVisualStyleBackColor = True
        '
        'lblIdentifNDEBNoGL
        '
        Me.lblIdentifNDEBNoGL.AutoSize = True
        Me.lblIdentifNDEBNoGL.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblIdentifNDEBNoGL.LabelAsoc = Nothing
        Me.lblIdentifNDEBNoGL.Location = New System.Drawing.Point(513, 377)
        Me.lblIdentifNDEBNoGL.Name = "lblIdentifNDEBNoGL"
        Me.lblIdentifNDEBNoGL.Size = New System.Drawing.Size(182, 13)
        Me.lblIdentifNDEBNoGL.TabIndex = 31
        Me.lblIdentifNDEBNoGL.Text = "Identif. de N.Debito (NO Graba Libro)"
        '
        'txtIdentifNDEBNoGL
        '
        Me.txtIdentifNDEBNoGL.BindearPropiedadControl = Nothing
        Me.txtIdentifNDEBNoGL.BindearPropiedadEntidad = Nothing
        Me.txtIdentifNDEBNoGL.ForeColorFocus = System.Drawing.Color.Red
        Me.txtIdentifNDEBNoGL.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtIdentifNDEBNoGL.Formato = ""
        Me.txtIdentifNDEBNoGL.IsDecimal = False
        Me.txtIdentifNDEBNoGL.IsNumber = False
        Me.txtIdentifNDEBNoGL.IsPK = False
        Me.txtIdentifNDEBNoGL.IsRequired = False
        Me.txtIdentifNDEBNoGL.Key = ""
        Me.txtIdentifNDEBNoGL.LabelAsoc = Me.lblIdentifNDEBNoGL
        Me.txtIdentifNDEBNoGL.Location = New System.Drawing.Point(389, 373)
        Me.txtIdentifNDEBNoGL.MaxLength = 20
        Me.txtIdentifNDEBNoGL.Name = "txtIdentifNDEBNoGL"
        Me.txtIdentifNDEBNoGL.Size = New System.Drawing.Size(118, 20)
        Me.txtIdentifNDEBNoGL.TabIndex = 30
        Me.txtIdentifNDEBNoGL.Tag = "IDNDEBNOGLPROV"
        Me.txtIdentifNDEBNoGL.Text = "COTIZACIONNDCOM"
        '
        'lblIdentifNCREDNoGL
        '
        Me.lblIdentifNCREDNoGL.AutoSize = True
        Me.lblIdentifNCREDNoGL.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblIdentifNCREDNoGL.LabelAsoc = Nothing
        Me.lblIdentifNCREDNoGL.Location = New System.Drawing.Point(513, 404)
        Me.lblIdentifNCREDNoGL.Name = "lblIdentifNCREDNoGL"
        Me.lblIdentifNCREDNoGL.Size = New System.Drawing.Size(184, 13)
        Me.lblIdentifNCREDNoGL.TabIndex = 33
        Me.lblIdentifNCREDNoGL.Text = "Identif. de N.Credito (NO Graba Libro)"
        '
        'txtIdentifNCREDNoGL
        '
        Me.txtIdentifNCREDNoGL.BindearPropiedadControl = Nothing
        Me.txtIdentifNCREDNoGL.BindearPropiedadEntidad = Nothing
        Me.txtIdentifNCREDNoGL.ForeColorFocus = System.Drawing.Color.Red
        Me.txtIdentifNCREDNoGL.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtIdentifNCREDNoGL.Formato = ""
        Me.txtIdentifNCREDNoGL.IsDecimal = False
        Me.txtIdentifNCREDNoGL.IsNumber = False
        Me.txtIdentifNCREDNoGL.IsPK = False
        Me.txtIdentifNCREDNoGL.IsRequired = False
        Me.txtIdentifNCREDNoGL.Key = ""
        Me.txtIdentifNCREDNoGL.LabelAsoc = Me.lblIdentifNCREDNoGL
        Me.txtIdentifNCREDNoGL.Location = New System.Drawing.Point(389, 400)
        Me.txtIdentifNCREDNoGL.MaxLength = 20
        Me.txtIdentifNCREDNoGL.Name = "txtIdentifNCREDNoGL"
        Me.txtIdentifNCREDNoGL.Size = New System.Drawing.Size(118, 20)
        Me.txtIdentifNCREDNoGL.TabIndex = 32
        Me.txtIdentifNCREDNoGL.Tag = "IDNCREDNOGLPROV"
        Me.txtIdentifNCREDNoGL.Text = "COTIZACIONNCCOM"
        '
        'cmbCompraPrecioCosto
        '
        Me.cmbCompraPrecioCosto.BindearPropiedadControl = Nothing
        Me.cmbCompraPrecioCosto.BindearPropiedadEntidad = Nothing
        Me.cmbCompraPrecioCosto.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbCompraPrecioCosto.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbCompraPrecioCosto.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbCompraPrecioCosto.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbCompraPrecioCosto.FormattingEnabled = True
        Me.cmbCompraPrecioCosto.IsPK = False
        Me.cmbCompraPrecioCosto.IsRequired = False
        Me.cmbCompraPrecioCosto.Key = Nothing
        Me.cmbCompraPrecioCosto.LabelAsoc = Nothing
        Me.cmbCompraPrecioCosto.Location = New System.Drawing.Point(593, 26)
        Me.cmbCompraPrecioCosto.Name = "cmbCompraPrecioCosto"
        Me.cmbCompraPrecioCosto.Size = New System.Drawing.Size(196, 21)
        Me.cmbCompraPrecioCosto.TabIndex = 19
        Me.cmbCompraPrecioCosto.Tag = ""
        '
        'txtComprasProductoLiquidacionTarjetas
        '
        Me.txtComprasProductoLiquidacionTarjetas.BindearPropiedadControl = Nothing
        Me.txtComprasProductoLiquidacionTarjetas.BindearPropiedadEntidad = Nothing
        Me.txtComprasProductoLiquidacionTarjetas.ForeColorFocus = System.Drawing.Color.Red
        Me.txtComprasProductoLiquidacionTarjetas.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtComprasProductoLiquidacionTarjetas.Formato = ""
        Me.txtComprasProductoLiquidacionTarjetas.IsDecimal = False
        Me.txtComprasProductoLiquidacionTarjetas.IsNumber = False
        Me.txtComprasProductoLiquidacionTarjetas.IsPK = False
        Me.txtComprasProductoLiquidacionTarjetas.IsRequired = False
        Me.txtComprasProductoLiquidacionTarjetas.Key = ""
        Me.txtComprasProductoLiquidacionTarjetas.LabelAsoc = Me.lblComprasProductoLiquidacionTarjetas
        Me.txtComprasProductoLiquidacionTarjetas.Location = New System.Drawing.Point(224, 394)
        Me.txtComprasProductoLiquidacionTarjetas.MaxLength = 20
        Me.txtComprasProductoLiquidacionTarjetas.Name = "txtComprasProductoLiquidacionTarjetas"
        Me.txtComprasProductoLiquidacionTarjetas.Size = New System.Drawing.Size(154, 20)
        Me.txtComprasProductoLiquidacionTarjetas.TabIndex = 17
        '
        'lblComprasProductoLiquidacionTarjetas
        '
        Me.lblComprasProductoLiquidacionTarjetas.AutoSize = True
        Me.lblComprasProductoLiquidacionTarjetas.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblComprasProductoLiquidacionTarjetas.LabelAsoc = Nothing
        Me.lblComprasProductoLiquidacionTarjetas.Location = New System.Drawing.Point(6, 398)
        Me.lblComprasProductoLiquidacionTarjetas.Name = "lblComprasProductoLiquidacionTarjetas"
        Me.lblComprasProductoLiquidacionTarjetas.Size = New System.Drawing.Size(212, 13)
        Me.lblComprasProductoLiquidacionTarjetas.TabIndex = 16
        Me.lblComprasProductoLiquidacionTarjetas.Text = "Cod. De Prod. Totalizar Cupones (Liq. Tarj.)"
        '
        'ucConfCompras
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.txtComprasProductoLiquidacionTarjetas)
        Me.Controls.Add(Me.lblComprasProductoLiquidacionTarjetas)
        Me.Controls.Add(Me.cmbCompraPrecioCosto)
        Me.Controls.Add(Me.lblIdentifNDEBNoGL)
        Me.Controls.Add(Me.txtIdentifNDEBNoGL)
        Me.Controls.Add(Me.lblIdentifNCREDNoGL)
        Me.Controls.Add(Me.txtIdentifNCREDNoGL)
        Me.Controls.Add(Me.chbComprasConservaOrdenProductos)
        Me.Controls.Add(Me.chbComprasSoloCargaProductosDelProveedor)
        Me.Controls.Add(Me.chbComprasSolicitaComprador)
        Me.Controls.Add(Me.chbExpensasPermitirCargarProductosSinConceptos)
        Me.Controls.Add(Me.chbActualizarPreciosDesdeComprasPriorizaIVAProducto)
        Me.Controls.Add(Me.chbExpensasPermiteConSinConcepto)
        Me.Controls.Add(Me.grpActualizarPreciosCalculoDesdeCompras)
        Me.Controls.Add(Me.chbComprasPosicionarNombreProducto)
        Me.Controls.Add(Me.txtComprasToleranciaIvaManual)
        Me.Controls.Add(Me.lblComprasToleranciaIvaManual)
        Me.Controls.Add(Me.chbActualizaPreciosUtilizaAjusteDecimales)
        Me.Controls.Add(Me.chbComprasPedidosInvocadosProvMantieneFormaPago)
        Me.Controls.Add(Me.chbComprasVisualizaPorcVarCosto)
        Me.Controls.Add(Me.chbComprasVisualizaCodigoProveedor)
        Me.Controls.Add(Me.chbComprasImpresionVisualizaNroSerie)
        Me.Controls.Add(Me.GroupBox5)
        Me.Controls.Add(Me.txtIdentifNDEBCheqRechCompra)
        Me.Controls.Add(Me.lblIdentifNDebCheqCheqCompra)
        Me.Controls.Add(Me.chbComprasContadoEsEnPesos)
        Me.Controls.Add(Me.chbPermiteModificarDescCompras)
        Me.Controls.Add(Me.txtUltimaHojaCompras)
        Me.Controls.Add(Me.chbComprasIgnorarPCdeCaja)
        Me.Controls.Add(Me.chbActualizaCostosPreciosVenta)
        Me.Controls.Add(Me.chbComprasSinProductos)
        Me.Controls.Add(Me.chbVisualizaComprasAntesImprimir)
        Me.Controls.Add(Me.chbComprasConProductosEnCero)
        Me.Controls.Add(Me.lblUltimaHojaCompras)
        Me.Name = "ucConfCompras"
        Me.Size = New System.Drawing.Size(800, 450)
        Me.Controls.SetChildIndex(Me.lblUltimaHojaCompras, 0)
        Me.Controls.SetChildIndex(Me.chbComprasConProductosEnCero, 0)
        Me.Controls.SetChildIndex(Me.chbVisualizaComprasAntesImprimir, 0)
        Me.Controls.SetChildIndex(Me.chbComprasSinProductos, 0)
        Me.Controls.SetChildIndex(Me.chbActualizaCostosPreciosVenta, 0)
        Me.Controls.SetChildIndex(Me.chbComprasIgnorarPCdeCaja, 0)
        Me.Controls.SetChildIndex(Me.txtUltimaHojaCompras, 0)
        Me.Controls.SetChildIndex(Me.chbPermiteModificarDescCompras, 0)
        Me.Controls.SetChildIndex(Me.chbComprasContadoEsEnPesos, 0)
        Me.Controls.SetChildIndex(Me.lblIdentifNDebCheqCheqCompra, 0)
        Me.Controls.SetChildIndex(Me.txtIdentifNDEBCheqRechCompra, 0)
        Me.Controls.SetChildIndex(Me.GroupBox5, 0)
        Me.Controls.SetChildIndex(Me.chbComprasImpresionVisualizaNroSerie, 0)
        Me.Controls.SetChildIndex(Me.chbComprasVisualizaCodigoProveedor, 0)
        Me.Controls.SetChildIndex(Me.chbComprasVisualizaPorcVarCosto, 0)
        Me.Controls.SetChildIndex(Me.chbComprasPedidosInvocadosProvMantieneFormaPago, 0)
        Me.Controls.SetChildIndex(Me.chbActualizaPreciosUtilizaAjusteDecimales, 0)
        Me.Controls.SetChildIndex(Me.lblComprasToleranciaIvaManual, 0)
        Me.Controls.SetChildIndex(Me.txtComprasToleranciaIvaManual, 0)
        Me.Controls.SetChildIndex(Me.chbComprasPosicionarNombreProducto, 0)
        Me.Controls.SetChildIndex(Me.grpActualizarPreciosCalculoDesdeCompras, 0)
        Me.Controls.SetChildIndex(Me.chbExpensasPermiteConSinConcepto, 0)
        Me.Controls.SetChildIndex(Me.chbActualizarPreciosDesdeComprasPriorizaIVAProducto, 0)
        Me.Controls.SetChildIndex(Me.chbExpensasPermitirCargarProductosSinConceptos, 0)
        Me.Controls.SetChildIndex(Me.chbComprasSolicitaComprador, 0)
        Me.Controls.SetChildIndex(Me.chbComprasSoloCargaProductosDelProveedor, 0)
        Me.Controls.SetChildIndex(Me.chbComprasConservaOrdenProductos, 0)
        Me.Controls.SetChildIndex(Me.txtIdentifNCREDNoGL, 0)
        Me.Controls.SetChildIndex(Me.lblIdentifNCREDNoGL, 0)
        Me.Controls.SetChildIndex(Me.txtIdentifNDEBNoGL, 0)
        Me.Controls.SetChildIndex(Me.lblIdentifNDEBNoGL, 0)
        Me.Controls.SetChildIndex(Me.cmbCompraPrecioCosto, 0)
        Me.Controls.SetChildIndex(Me.lblComprasProductoLiquidacionTarjetas, 0)
        Me.Controls.SetChildIndex(Me.txtComprasProductoLiquidacionTarjetas, 0)
        Me.grpActualizarPreciosCalculoDesdeCompras.ResumeLayout(False)
        Me.grpActualizarPreciosCalculoDesdeCompras.PerformLayout()
        Me.GroupBox5.ResumeLayout(False)
        Me.GroupBox5.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents chbComprasConservaOrdenProductos As Controles.CheckBox
    Friend WithEvents chbComprasSoloCargaProductosDelProveedor As Controles.CheckBox
    Friend WithEvents chbComprasSolicitaComprador As Controles.CheckBox
    Friend WithEvents chbExpensasPermitirCargarProductosSinConceptos As Controles.CheckBox
    Friend WithEvents chbActualizarPreciosDesdeComprasPriorizaIVAProducto As Controles.CheckBox
    Friend WithEvents chbExpensasPermiteConSinConcepto As Controles.CheckBox
    Friend WithEvents grpActualizarPreciosCalculoDesdeCompras As GroupBox
    Friend WithEvents radActualizarPreciosCalculoDesdeCompras_SobreCosto As RadioButton
    Friend WithEvents radActualizarPreciosCalculoDesdeCompras_SobreVenta As RadioButton
    Friend WithEvents radActualizarPreciosCalculoDesdeCompras_PorcActual As RadioButton
    Friend WithEvents chbComprasPosicionarNombreProducto As Controles.CheckBox
    Friend WithEvents txtComprasToleranciaIvaManual As Controles.TextBox
    Friend WithEvents lblComprasToleranciaIvaManual As Controles.Label
    Friend WithEvents chbActualizaPreciosUtilizaAjusteDecimales As Controles.CheckBox
    Friend WithEvents chbComprasPedidosInvocadosProvMantieneFormaPago As Controles.CheckBox
    Friend WithEvents chbComprasVisualizaPorcVarCosto As Controles.CheckBox
    Friend WithEvents chbComprasVisualizaCodigoProveedor As Controles.CheckBox
    Friend WithEvents chbComprasImpresionVisualizaNroSerie As Controles.CheckBox
    Friend WithEvents GroupBox5 As GroupBox
    Friend WithEvents txtComprasDecimalesRedondeoEnCantidad As Controles.TextBox
    Friend WithEvents lblComprasDecimalesRedondeoEnCantidad As Controles.Label
    Friend WithEvents lblComprasDecimalesMostrarEnCantidad As Controles.Label
    Friend WithEvents txtComprasDecimalesRedondeoEnPrecio As Controles.TextBox
    Friend WithEvents lblComprasDecimalesRedondeoEnPrecio As Controles.Label
    Friend WithEvents lblComprasDecimalesMostrarEnItems As Controles.Label
    Friend WithEvents lblComprasDecimalesEnTotal As Controles.Label
    Friend WithEvents lblComprasDecimalesEnTotalXProducto As Controles.Label
    Friend WithEvents txtComprasDecimalesMostrarEnCantidad As Controles.TextBox
    Friend WithEvents txtComprasDecimalesEnTotal As Controles.TextBox
    Friend WithEvents txtComprasDecimalesEnTotalXProducto As Controles.TextBox
    Friend WithEvents txtComprasDecimalesMostrarEnItems As Controles.TextBox
    Friend WithEvents txtIdentifNDEBCheqRechCompra As Controles.TextBox
    Friend WithEvents lblIdentifNDebCheqCheqCompra As Controles.Label
    Friend WithEvents chbComprasContadoEsEnPesos As Controles.CheckBox
    Friend WithEvents chbPermiteModificarDescCompras As Controles.CheckBox
    Friend WithEvents txtUltimaHojaCompras As Controles.TextBox
    Friend WithEvents lblUltimaHojaCompras As Controles.Label
    Friend WithEvents chbComprasIgnorarPCdeCaja As Controles.CheckBox
    Friend WithEvents chbActualizaCostosPreciosVenta As Controles.CheckBox
    Friend WithEvents chbComprasSinProductos As Controles.CheckBox
    Friend WithEvents chbVisualizaComprasAntesImprimir As Controles.CheckBox
    Friend WithEvents chbComprasConProductosEnCero As Controles.CheckBox
    Friend WithEvents lblIdentifNDEBNoGL As Controles.Label
    Friend WithEvents txtIdentifNDEBNoGL As Controles.TextBox
    Friend WithEvents lblIdentifNCREDNoGL As Controles.Label
    Friend WithEvents txtIdentifNCREDNoGL As Controles.TextBox
    Friend WithEvents cmbCompraPrecioCosto As Controles.ComboBox
    Friend WithEvents txtComprasProductoLiquidacionTarjetas As Controles.TextBox
    Friend WithEvents lblComprasProductoLiquidacionTarjetas As Controles.Label
End Class
