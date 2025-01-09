<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class ucConfVentas1
    Inherits ucConfBase

    'UserControl overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.chbGrabaLibroNoIncluyeRecargoGeneral = New Eniac.Controles.CheckBox()
        Me.chbFacturacionModificaDescRecProductoPorMonto = New Eniac.Controles.CheckBox()
        Me.chbFacturacionModificaDescRecGralPorc = New Eniac.Controles.CheckBox()
        Me.chbFacturacionSolicitaComprobante = New Eniac.Controles.CheckBox()
        Me.chbFacturacionSolicitaVendedor = New Eniac.Controles.CheckBox()
        Me.chbFacturacionInvocarDeOtroCliente = New Eniac.Controles.CheckBox()
        Me.txtDiasPresupuesto = New Eniac.Controles.TextBox()
        Me.lblDiasPresupuesto = New Eniac.Controles.Label()
        Me.lblUltimaHojaVentas = New Eniac.Controles.Label()
        Me.txtUltimaHojaVentas = New Eniac.Controles.TextBox()
        Me.chbFacturacionModificaNumeroComprobante = New Eniac.Controles.CheckBox()
        Me.chbFacturacionModificaDescripcionProducto = New Eniac.Controles.CheckBox()
        Me.lblVentaPrecioCosto = New Eniac.Controles.Label()
        Me.chbFacturacionModificaPrecioProducto = New Eniac.Controles.CheckBox()
        Me.lblFacturacionSemaforoCalculoMuestra = New Eniac.Controles.Label()
        Me.lblFacturacionMantieneElClienteDefault = New Eniac.Controles.Label()
        Me.lblIdentifNDEBGL = New Eniac.Controles.Label()
        Me.txtFacturacionMantieneElClienteDefault = New Eniac.Controles.TextBox()
        Me.txtIdentifNDEBGL = New Eniac.Controles.TextBox()
        Me.lblIdentifNCREDGL = New Eniac.Controles.Label()
        Me.txtIdentifNCREDGL = New Eniac.Controles.TextBox()
        Me.lblIdentifNDEBNoGL = New Eniac.Controles.Label()
        Me.txtIdentifNDEBNoGL = New Eniac.Controles.TextBox()
        Me.lblIdentifNCREDNoGL = New Eniac.Controles.Label()
        Me.cmbFacturacionSemaforoCalculoMuestra = New Eniac.Controles.ComboBox()
        Me.cmbVentaPrecioVenta = New Eniac.Controles.ComboBox()
        Me.txtIdentifNCREDNoGL = New Eniac.Controles.TextBox()
        Me.chbFacturacionContadoEsEnPesos = New Eniac.Controles.CheckBox()
        Me.chbFacturacionTicketIncluyeRecargoGeneral = New Eniac.Controles.CheckBox()
        Me.chbFacturacionPermitirFechaNumAnterior = New Eniac.Controles.CheckBox()
        Me.chbFacturacionPermiteFacturarEnOtrasMonedas = New Eniac.Controles.CheckBox()
        Me.chbFacturacionRapidaMantieneElComprobante = New Eniac.Controles.CheckBox()
        Me.chbFacturacionPresupuestoIncluyeRecargoGeneral = New Eniac.Controles.CheckBox()
        Me.chbFacturacionModificaDescRecargoProducto = New Eniac.Controles.CheckBox()
        Me.chbFacturacionRapidaMantieneElCliente = New Eniac.Controles.CheckBox()
        Me.chbVisualizaVentasAntesImprimir = New Eniac.Controles.CheckBox()
        Me.chbActualizaPreciosDeVenta = New Eniac.Controles.CheckBox()
        Me.chbVentasConProductosEnCero = New Eniac.Controles.CheckBox()
        Me.chbVisualizaSemaforoUtilidad = New Eniac.Controles.CheckBox()
        Me.lblVentaPrecioVenta = New Eniac.Controles.Label()
        Me.chbFacturacionInvocarInvocador = New Eniac.Controles.CheckBox()
        Me.cmbVentaPrecioCosto = New Eniac.Controles.ComboBox()
        Me.lblVentaPrecioCostoMeses = New Eniac.Controles.Label()
        Me.txtVentaPrecioCostoMeses = New Eniac.Controles.TextBox()
        Me.chbFacturacionPermitirFechaFutura = New Eniac.Controles.CheckBox()
        Me.SuspendLayout()
        '
        'chbGrabaLibroNoIncluyeRecargoGeneral
        '
        Me.chbGrabaLibroNoIncluyeRecargoGeneral.BindearPropiedadControl = Nothing
        Me.chbGrabaLibroNoIncluyeRecargoGeneral.BindearPropiedadEntidad = Nothing
        Me.chbGrabaLibroNoIncluyeRecargoGeneral.ForeColorFocus = System.Drawing.Color.Red
        Me.chbGrabaLibroNoIncluyeRecargoGeneral.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbGrabaLibroNoIncluyeRecargoGeneral.IsPK = False
        Me.chbGrabaLibroNoIncluyeRecargoGeneral.IsRequired = False
        Me.chbGrabaLibroNoIncluyeRecargoGeneral.Key = Nothing
        Me.chbGrabaLibroNoIncluyeRecargoGeneral.LabelAsoc = Nothing
        Me.chbGrabaLibroNoIncluyeRecargoGeneral.Location = New System.Drawing.Point(8, 368)
        Me.chbGrabaLibroNoIncluyeRecargoGeneral.Name = "chbGrabaLibroNoIncluyeRecargoGeneral"
        Me.chbGrabaLibroNoIncluyeRecargoGeneral.Size = New System.Drawing.Size(265, 24)
        Me.chbGrabaLibroNoIncluyeRecargoGeneral.TabIndex = 21
        Me.chbGrabaLibroNoIncluyeRecargoGeneral.Tag = ""
        Me.chbGrabaLibroNoIncluyeRecargoGeneral.Text = " Graba Libro No:  Incluye Recargo General"
        Me.chbGrabaLibroNoIncluyeRecargoGeneral.UseVisualStyleBackColor = True
        '
        'chbFacturacionModificaDescRecProductoPorMonto
        '
        Me.chbFacturacionModificaDescRecProductoPorMonto.BindearPropiedadControl = Nothing
        Me.chbFacturacionModificaDescRecProductoPorMonto.BindearPropiedadEntidad = Nothing
        Me.chbFacturacionModificaDescRecProductoPorMonto.ForeColorFocus = System.Drawing.Color.Red
        Me.chbFacturacionModificaDescRecProductoPorMonto.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbFacturacionModificaDescRecProductoPorMonto.IsPK = False
        Me.chbFacturacionModificaDescRecProductoPorMonto.IsRequired = False
        Me.chbFacturacionModificaDescRecProductoPorMonto.Key = Nothing
        Me.chbFacturacionModificaDescRecProductoPorMonto.LabelAsoc = Nothing
        Me.chbFacturacionModificaDescRecProductoPorMonto.Location = New System.Drawing.Point(9, 170)
        Me.chbFacturacionModificaDescRecProductoPorMonto.Name = "chbFacturacionModificaDescRecProductoPorMonto"
        Me.chbFacturacionModificaDescRecProductoPorMonto.Size = New System.Drawing.Size(350, 24)
        Me.chbFacturacionModificaDescRecProductoPorMonto.TabIndex = 9
        Me.chbFacturacionModificaDescRecProductoPorMonto.Tag = ""
        Me.chbFacturacionModificaDescRecProductoPorMonto.Text = "Permite modificar el Descuento/Recargo del Producto por Monto."
        Me.chbFacturacionModificaDescRecProductoPorMonto.UseVisualStyleBackColor = True
        '
        'chbFacturacionModificaDescRecGralPorc
        '
        Me.chbFacturacionModificaDescRecGralPorc.BindearPropiedadControl = Nothing
        Me.chbFacturacionModificaDescRecGralPorc.BindearPropiedadEntidad = Nothing
        Me.chbFacturacionModificaDescRecGralPorc.ForeColorFocus = System.Drawing.Color.Red
        Me.chbFacturacionModificaDescRecGralPorc.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbFacturacionModificaDescRecGralPorc.IsPK = False
        Me.chbFacturacionModificaDescRecGralPorc.IsRequired = False
        Me.chbFacturacionModificaDescRecGralPorc.Key = Nothing
        Me.chbFacturacionModificaDescRecGralPorc.LabelAsoc = Nothing
        Me.chbFacturacionModificaDescRecGralPorc.Location = New System.Drawing.Point(9, 126)
        Me.chbFacturacionModificaDescRecGralPorc.Name = "chbFacturacionModificaDescRecGralPorc"
        Me.chbFacturacionModificaDescRecGralPorc.Size = New System.Drawing.Size(289, 24)
        Me.chbFacturacionModificaDescRecGralPorc.TabIndex = 7
        Me.chbFacturacionModificaDescRecGralPorc.Tag = ""
        Me.chbFacturacionModificaDescRecGralPorc.Text = "Permite modificar el Descuento/Recargo General"
        Me.chbFacturacionModificaDescRecGralPorc.UseVisualStyleBackColor = True
        '
        'chbFacturacionSolicitaComprobante
        '
        Me.chbFacturacionSolicitaComprobante.BindearPropiedadControl = Nothing
        Me.chbFacturacionSolicitaComprobante.BindearPropiedadEntidad = Nothing
        Me.chbFacturacionSolicitaComprobante.ForeColorFocus = System.Drawing.Color.Red
        Me.chbFacturacionSolicitaComprobante.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbFacturacionSolicitaComprobante.IsPK = False
        Me.chbFacturacionSolicitaComprobante.IsRequired = False
        Me.chbFacturacionSolicitaComprobante.Key = Nothing
        Me.chbFacturacionSolicitaComprobante.LabelAsoc = Nothing
        Me.chbFacturacionSolicitaComprobante.Location = New System.Drawing.Point(425, 374)
        Me.chbFacturacionSolicitaComprobante.Name = "chbFacturacionSolicitaComprobante"
        Me.chbFacturacionSolicitaComprobante.Size = New System.Drawing.Size(316, 24)
        Me.chbFacturacionSolicitaComprobante.TabIndex = 43
        Me.chbFacturacionSolicitaComprobante.Tag = "FACTURACIONSOLICITACOMPROBANTE"
        Me.chbFacturacionSolicitaComprobante.Text = "Solicita el Comprobante luego de Cargar el Cliente."
        Me.chbFacturacionSolicitaComprobante.UseVisualStyleBackColor = True
        '
        'chbFacturacionSolicitaVendedor
        '
        Me.chbFacturacionSolicitaVendedor.BindearPropiedadControl = Nothing
        Me.chbFacturacionSolicitaVendedor.BindearPropiedadEntidad = Nothing
        Me.chbFacturacionSolicitaVendedor.ForeColorFocus = System.Drawing.Color.Red
        Me.chbFacturacionSolicitaVendedor.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbFacturacionSolicitaVendedor.IsPK = False
        Me.chbFacturacionSolicitaVendedor.IsRequired = False
        Me.chbFacturacionSolicitaVendedor.Key = Nothing
        Me.chbFacturacionSolicitaVendedor.LabelAsoc = Nothing
        Me.chbFacturacionSolicitaVendedor.Location = New System.Drawing.Point(425, 344)
        Me.chbFacturacionSolicitaVendedor.Name = "chbFacturacionSolicitaVendedor"
        Me.chbFacturacionSolicitaVendedor.Size = New System.Drawing.Size(316, 24)
        Me.chbFacturacionSolicitaVendedor.TabIndex = 42
        Me.chbFacturacionSolicitaVendedor.Tag = "FACTURACIONSOLICITAVENDEDOR"
        Me.chbFacturacionSolicitaVendedor.Text = "Solicita el Vendedor luego de Cargar el Cliente."
        Me.chbFacturacionSolicitaVendedor.UseVisualStyleBackColor = True
        '
        'chbFacturacionInvocarDeOtroCliente
        '
        Me.chbFacturacionInvocarDeOtroCliente.BindearPropiedadControl = Nothing
        Me.chbFacturacionInvocarDeOtroCliente.BindearPropiedadEntidad = Nothing
        Me.chbFacturacionInvocarDeOtroCliente.ForeColorFocus = System.Drawing.Color.Red
        Me.chbFacturacionInvocarDeOtroCliente.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbFacturacionInvocarDeOtroCliente.IsPK = False
        Me.chbFacturacionInvocarDeOtroCliente.IsRequired = False
        Me.chbFacturacionInvocarDeOtroCliente.Key = Nothing
        Me.chbFacturacionInvocarDeOtroCliente.LabelAsoc = Nothing
        Me.chbFacturacionInvocarDeOtroCliente.Location = New System.Drawing.Point(425, 314)
        Me.chbFacturacionInvocarDeOtroCliente.Name = "chbFacturacionInvocarDeOtroCliente"
        Me.chbFacturacionInvocarDeOtroCliente.Size = New System.Drawing.Size(316, 24)
        Me.chbFacturacionInvocarDeOtroCliente.TabIndex = 41
        Me.chbFacturacionInvocarDeOtroCliente.Tag = "FACTURACIONINVOCARDEOTROCLIENTE"
        Me.chbFacturacionInvocarDeOtroCliente.Text = "Permite Invocar un Comprobante de Otro Cliente."
        Me.chbFacturacionInvocarDeOtroCliente.UseVisualStyleBackColor = True
        '
        'txtDiasPresupuesto
        '
        Me.txtDiasPresupuesto.BindearPropiedadControl = Nothing
        Me.txtDiasPresupuesto.BindearPropiedadEntidad = Nothing
        Me.txtDiasPresupuesto.ForeColorFocus = System.Drawing.Color.Red
        Me.txtDiasPresupuesto.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtDiasPresupuesto.Formato = ""
        Me.txtDiasPresupuesto.IsDecimal = False
        Me.txtDiasPresupuesto.IsNumber = True
        Me.txtDiasPresupuesto.IsPK = False
        Me.txtDiasPresupuesto.IsRequired = False
        Me.txtDiasPresupuesto.Key = ""
        Me.txtDiasPresupuesto.LabelAsoc = Me.lblDiasPresupuesto
        Me.txtDiasPresupuesto.Location = New System.Drawing.Point(7, 5)
        Me.txtDiasPresupuesto.MaxLength = 3
        Me.txtDiasPresupuesto.Name = "txtDiasPresupuesto"
        Me.txtDiasPresupuesto.Size = New System.Drawing.Size(35, 20)
        Me.txtDiasPresupuesto.TabIndex = 0
        Me.txtDiasPresupuesto.Tag = "DIASVALIDEZPRESUPUESTO"
        Me.txtDiasPresupuesto.Text = "7"
        Me.txtDiasPresupuesto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblDiasPresupuesto
        '
        Me.lblDiasPresupuesto.AutoSize = True
        Me.lblDiasPresupuesto.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblDiasPresupuesto.LabelAsoc = Nothing
        Me.lblDiasPresupuesto.Location = New System.Drawing.Point(48, 12)
        Me.lblDiasPresupuesto.Name = "lblDiasPresupuesto"
        Me.lblDiasPresupuesto.Size = New System.Drawing.Size(275, 13)
        Me.lblDiasPresupuesto.TabIndex = 1
        Me.lblDiasPresupuesto.Text = "Cantidad de dias a sumar para la validez del presupuesto"
        '
        'lblUltimaHojaVentas
        '
        Me.lblUltimaHojaVentas.AutoSize = True
        Me.lblUltimaHojaVentas.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblUltimaHojaVentas.LabelAsoc = Nothing
        Me.lblUltimaHojaVentas.Location = New System.Drawing.Point(48, 41)
        Me.lblUltimaHojaVentas.Name = "lblUltimaHojaVentas"
        Me.lblUltimaHojaVentas.Size = New System.Drawing.Size(193, 13)
        Me.lblUltimaHojaVentas.TabIndex = 3
        Me.lblUltimaHojaVentas.Text = "Ultima hoja impresa del libro IVA Ventas"
        '
        'txtUltimaHojaVentas
        '
        Me.txtUltimaHojaVentas.BindearPropiedadControl = Nothing
        Me.txtUltimaHojaVentas.BindearPropiedadEntidad = Nothing
        Me.txtUltimaHojaVentas.ForeColorFocus = System.Drawing.Color.Red
        Me.txtUltimaHojaVentas.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtUltimaHojaVentas.Formato = ""
        Me.txtUltimaHojaVentas.IsDecimal = False
        Me.txtUltimaHojaVentas.IsNumber = True
        Me.txtUltimaHojaVentas.IsPK = False
        Me.txtUltimaHojaVentas.IsRequired = False
        Me.txtUltimaHojaVentas.Key = ""
        Me.txtUltimaHojaVentas.LabelAsoc = Me.lblUltimaHojaVentas
        Me.txtUltimaHojaVentas.Location = New System.Drawing.Point(7, 34)
        Me.txtUltimaHojaVentas.MaxLength = 3
        Me.txtUltimaHojaVentas.Name = "txtUltimaHojaVentas"
        Me.txtUltimaHojaVentas.Size = New System.Drawing.Size(35, 20)
        Me.txtUltimaHojaVentas.TabIndex = 2
        Me.txtUltimaHojaVentas.Tag = "NROHOJALIBROIVAVENTAS"
        Me.txtUltimaHojaVentas.Text = "1"
        Me.txtUltimaHojaVentas.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'chbFacturacionModificaNumeroComprobante
        '
        Me.chbFacturacionModificaNumeroComprobante.BindearPropiedadControl = Nothing
        Me.chbFacturacionModificaNumeroComprobante.BindearPropiedadEntidad = Nothing
        Me.chbFacturacionModificaNumeroComprobante.ForeColorFocus = System.Drawing.Color.Red
        Me.chbFacturacionModificaNumeroComprobante.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbFacturacionModificaNumeroComprobante.IsPK = False
        Me.chbFacturacionModificaNumeroComprobante.IsRequired = False
        Me.chbFacturacionModificaNumeroComprobante.Key = Nothing
        Me.chbFacturacionModificaNumeroComprobante.LabelAsoc = Nothing
        Me.chbFacturacionModificaNumeroComprobante.Location = New System.Drawing.Point(9, 60)
        Me.chbFacturacionModificaNumeroComprobante.Name = "chbFacturacionModificaNumeroComprobante"
        Me.chbFacturacionModificaNumeroComprobante.Size = New System.Drawing.Size(281, 24)
        Me.chbFacturacionModificaNumeroComprobante.TabIndex = 4
        Me.chbFacturacionModificaNumeroComprobante.Tag = "FACTURACIONMODIFICANUMEROCOMPROBANTE"
        Me.chbFacturacionModificaNumeroComprobante.Text = "Permite modificar el numero de comprobante a emitir"
        Me.chbFacturacionModificaNumeroComprobante.UseVisualStyleBackColor = True
        '
        'chbFacturacionModificaDescripcionProducto
        '
        Me.chbFacturacionModificaDescripcionProducto.BindearPropiedadControl = Nothing
        Me.chbFacturacionModificaDescripcionProducto.BindearPropiedadEntidad = Nothing
        Me.chbFacturacionModificaDescripcionProducto.ForeColorFocus = System.Drawing.Color.Red
        Me.chbFacturacionModificaDescripcionProducto.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbFacturacionModificaDescripcionProducto.IsPK = False
        Me.chbFacturacionModificaDescripcionProducto.IsRequired = False
        Me.chbFacturacionModificaDescripcionProducto.Key = Nothing
        Me.chbFacturacionModificaDescripcionProducto.LabelAsoc = Nothing
        Me.chbFacturacionModificaDescripcionProducto.Location = New System.Drawing.Point(9, 82)
        Me.chbFacturacionModificaDescripcionProducto.Name = "chbFacturacionModificaDescripcionProducto"
        Me.chbFacturacionModificaDescripcionProducto.Size = New System.Drawing.Size(265, 24)
        Me.chbFacturacionModificaDescripcionProducto.TabIndex = 5
        Me.chbFacturacionModificaDescripcionProducto.Tag = "FACTURACIONMODIFICADESCRIPCIONPRODUCTO"
        Me.chbFacturacionModificaDescripcionProducto.Text = "Permite modificar la descripción del Producto."
        Me.chbFacturacionModificaDescripcionProducto.UseVisualStyleBackColor = True
        '
        'lblVentaPrecioCosto
        '
        Me.lblVentaPrecioCosto.AutoSize = True
        Me.lblVentaPrecioCosto.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblVentaPrecioCosto.LabelAsoc = Nothing
        Me.lblVentaPrecioCosto.Location = New System.Drawing.Point(523, 236)
        Me.lblVentaPrecioCosto.Name = "lblVentaPrecioCosto"
        Me.lblVentaPrecioCosto.Size = New System.Drawing.Size(82, 13)
        Me.lblVentaPrecioCosto.TabIndex = 35
        Me.lblVentaPrecioCosto.Text = "Precio de Costo"
        '
        'chbFacturacionModificaPrecioProducto
        '
        Me.chbFacturacionModificaPrecioProducto.BindearPropiedadControl = Nothing
        Me.chbFacturacionModificaPrecioProducto.BindearPropiedadEntidad = Nothing
        Me.chbFacturacionModificaPrecioProducto.ForeColorFocus = System.Drawing.Color.Red
        Me.chbFacturacionModificaPrecioProducto.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbFacturacionModificaPrecioProducto.IsPK = False
        Me.chbFacturacionModificaPrecioProducto.IsRequired = False
        Me.chbFacturacionModificaPrecioProducto.Key = Nothing
        Me.chbFacturacionModificaPrecioProducto.LabelAsoc = Nothing
        Me.chbFacturacionModificaPrecioProducto.Location = New System.Drawing.Point(9, 104)
        Me.chbFacturacionModificaPrecioProducto.Name = "chbFacturacionModificaPrecioProducto"
        Me.chbFacturacionModificaPrecioProducto.Size = New System.Drawing.Size(328, 24)
        Me.chbFacturacionModificaPrecioProducto.TabIndex = 6
        Me.chbFacturacionModificaPrecioProducto.Tag = "FACTURACIONMODIFICAPRECIOPRODUCTO"
        Me.chbFacturacionModificaPrecioProducto.Text = "Permite modificar el Precio del Producto."
        Me.chbFacturacionModificaPrecioProducto.UseVisualStyleBackColor = True
        '
        'lblFacturacionSemaforoCalculoMuestra
        '
        Me.lblFacturacionSemaforoCalculoMuestra.AutoSize = True
        Me.lblFacturacionSemaforoCalculoMuestra.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblFacturacionSemaforoCalculoMuestra.LabelAsoc = Nothing
        Me.lblFacturacionSemaforoCalculoMuestra.Location = New System.Drawing.Point(640, 149)
        Me.lblFacturacionSemaforoCalculoMuestra.Name = "lblFacturacionSemaforoCalculoMuestra"
        Me.lblFacturacionSemaforoCalculoMuestra.Size = New System.Drawing.Size(82, 13)
        Me.lblFacturacionSemaforoCalculoMuestra.TabIndex = 30
        Me.lblFacturacionSemaforoCalculoMuestra.Text = "Muestra cálculo"
        '
        'lblFacturacionMantieneElClienteDefault
        '
        Me.lblFacturacionMantieneElClienteDefault.AutoSize = True
        Me.lblFacturacionMantieneElClienteDefault.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblFacturacionMantieneElClienteDefault.LabelAsoc = Nothing
        Me.lblFacturacionMantieneElClienteDefault.Location = New System.Drawing.Point(655, 54)
        Me.lblFacturacionMantieneElClienteDefault.Name = "lblFacturacionMantieneElClienteDefault"
        Me.lblFacturacionMantieneElClienteDefault.Size = New System.Drawing.Size(102, 13)
        Me.lblFacturacionMantieneElClienteDefault.TabIndex = 24
        Me.lblFacturacionMantieneElClienteDefault.Text = "Código Cliente pred."
        '
        'lblIdentifNDEBGL
        '
        Me.lblIdentifNDEBGL.AutoSize = True
        Me.lblIdentifNDEBGL.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblIdentifNDEBGL.LabelAsoc = Nothing
        Me.lblIdentifNDEBGL.Location = New System.Drawing.Point(131, 200)
        Me.lblIdentifNDEBGL.Name = "lblIdentifNDEBGL"
        Me.lblIdentifNDEBGL.Size = New System.Drawing.Size(163, 13)
        Me.lblIdentifNDEBGL.TabIndex = 11
        Me.lblIdentifNDEBGL.Text = "Identif. de N.Debito (Graba Libro)"
        '
        'txtFacturacionMantieneElClienteDefault
        '
        Me.txtFacturacionMantieneElClienteDefault.BindearPropiedadControl = Nothing
        Me.txtFacturacionMantieneElClienteDefault.BindearPropiedadEntidad = Nothing
        Me.txtFacturacionMantieneElClienteDefault.ForeColorFocus = System.Drawing.Color.Red
        Me.txtFacturacionMantieneElClienteDefault.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtFacturacionMantieneElClienteDefault.Formato = ""
        Me.txtFacturacionMantieneElClienteDefault.IsDecimal = False
        Me.txtFacturacionMantieneElClienteDefault.IsNumber = True
        Me.txtFacturacionMantieneElClienteDefault.IsPK = False
        Me.txtFacturacionMantieneElClienteDefault.IsRequired = False
        Me.txtFacturacionMantieneElClienteDefault.Key = ""
        Me.txtFacturacionMantieneElClienteDefault.LabelAsoc = Nothing
        Me.txtFacturacionMantieneElClienteDefault.Location = New System.Drawing.Point(763, 51)
        Me.txtFacturacionMantieneElClienteDefault.MaxLength = 8
        Me.txtFacturacionMantieneElClienteDefault.Name = "txtFacturacionMantieneElClienteDefault"
        Me.txtFacturacionMantieneElClienteDefault.Size = New System.Drawing.Size(70, 20)
        Me.txtFacturacionMantieneElClienteDefault.TabIndex = 25
        Me.txtFacturacionMantieneElClienteDefault.Text = "1"
        Me.txtFacturacionMantieneElClienteDefault.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtIdentifNDEBGL
        '
        Me.txtIdentifNDEBGL.BindearPropiedadControl = Nothing
        Me.txtIdentifNDEBGL.BindearPropiedadEntidad = Nothing
        Me.txtIdentifNDEBGL.ForeColorFocus = System.Drawing.Color.Red
        Me.txtIdentifNDEBGL.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtIdentifNDEBGL.Formato = ""
        Me.txtIdentifNDEBGL.IsDecimal = False
        Me.txtIdentifNDEBGL.IsNumber = False
        Me.txtIdentifNDEBGL.IsPK = False
        Me.txtIdentifNDEBGL.IsRequired = False
        Me.txtIdentifNDEBGL.Key = ""
        Me.txtIdentifNDEBGL.LabelAsoc = Me.lblIdentifNDEBGL
        Me.txtIdentifNDEBGL.Location = New System.Drawing.Point(7, 196)
        Me.txtIdentifNDEBGL.MaxLength = 20
        Me.txtIdentifNDEBGL.Name = "txtIdentifNDEBGL"
        Me.txtIdentifNDEBGL.Size = New System.Drawing.Size(118, 20)
        Me.txtIdentifNDEBGL.TabIndex = 10
        Me.txtIdentifNDEBGL.Tag = "IDNDEBGL"
        Me.txtIdentifNDEBGL.Text = "NDEB"
        '
        'lblIdentifNCREDGL
        '
        Me.lblIdentifNCREDGL.AutoSize = True
        Me.lblIdentifNCREDGL.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblIdentifNCREDGL.LabelAsoc = Nothing
        Me.lblIdentifNCREDGL.Location = New System.Drawing.Point(131, 227)
        Me.lblIdentifNCREDGL.Name = "lblIdentifNCREDGL"
        Me.lblIdentifNCREDGL.Size = New System.Drawing.Size(165, 13)
        Me.lblIdentifNCREDGL.TabIndex = 13
        Me.lblIdentifNCREDGL.Text = "Identif. de N.Credito (Graba Libro)"
        '
        'txtIdentifNCREDGL
        '
        Me.txtIdentifNCREDGL.BindearPropiedadControl = Nothing
        Me.txtIdentifNCREDGL.BindearPropiedadEntidad = Nothing
        Me.txtIdentifNCREDGL.ForeColorFocus = System.Drawing.Color.Red
        Me.txtIdentifNCREDGL.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtIdentifNCREDGL.Formato = ""
        Me.txtIdentifNCREDGL.IsDecimal = False
        Me.txtIdentifNCREDGL.IsNumber = False
        Me.txtIdentifNCREDGL.IsPK = False
        Me.txtIdentifNCREDGL.IsRequired = False
        Me.txtIdentifNCREDGL.Key = ""
        Me.txtIdentifNCREDGL.LabelAsoc = Me.lblIdentifNCREDGL
        Me.txtIdentifNCREDGL.Location = New System.Drawing.Point(7, 223)
        Me.txtIdentifNCREDGL.MaxLength = 20
        Me.txtIdentifNCREDGL.Name = "txtIdentifNCREDGL"
        Me.txtIdentifNCREDGL.Size = New System.Drawing.Size(118, 20)
        Me.txtIdentifNCREDGL.TabIndex = 12
        Me.txtIdentifNCREDGL.Tag = "IDNCREDGL"
        Me.txtIdentifNCREDGL.Text = "NCRED"
        '
        'lblIdentifNDEBNoGL
        '
        Me.lblIdentifNDEBNoGL.AutoSize = True
        Me.lblIdentifNDEBNoGL.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblIdentifNDEBNoGL.LabelAsoc = Nothing
        Me.lblIdentifNDEBNoGL.Location = New System.Drawing.Point(131, 254)
        Me.lblIdentifNDEBNoGL.Name = "lblIdentifNDEBNoGL"
        Me.lblIdentifNDEBNoGL.Size = New System.Drawing.Size(182, 13)
        Me.lblIdentifNDEBNoGL.TabIndex = 15
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
        Me.txtIdentifNDEBNoGL.Location = New System.Drawing.Point(7, 250)
        Me.txtIdentifNDEBNoGL.MaxLength = 20
        Me.txtIdentifNDEBNoGL.Name = "txtIdentifNDEBNoGL"
        Me.txtIdentifNDEBNoGL.Size = New System.Drawing.Size(118, 20)
        Me.txtIdentifNDEBNoGL.TabIndex = 14
        Me.txtIdentifNDEBNoGL.Tag = "IDNDEBNOGL"
        Me.txtIdentifNDEBNoGL.Text = "NDEB-COTIZACION"
        '
        'lblIdentifNCREDNoGL
        '
        Me.lblIdentifNCREDNoGL.AutoSize = True
        Me.lblIdentifNCREDNoGL.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblIdentifNCREDNoGL.LabelAsoc = Nothing
        Me.lblIdentifNCREDNoGL.Location = New System.Drawing.Point(131, 281)
        Me.lblIdentifNCREDNoGL.Name = "lblIdentifNCREDNoGL"
        Me.lblIdentifNCREDNoGL.Size = New System.Drawing.Size(184, 13)
        Me.lblIdentifNCREDNoGL.TabIndex = 17
        Me.lblIdentifNCREDNoGL.Text = "Identif. de N.Credito (NO Graba Libro)"
        '
        'cmbFacturacionSemaforoCalculoMuestra
        '
        Me.cmbFacturacionSemaforoCalculoMuestra.BindearPropiedadControl = Nothing
        Me.cmbFacturacionSemaforoCalculoMuestra.BindearPropiedadEntidad = Nothing
        Me.cmbFacturacionSemaforoCalculoMuestra.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbFacturacionSemaforoCalculoMuestra.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbFacturacionSemaforoCalculoMuestra.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbFacturacionSemaforoCalculoMuestra.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbFacturacionSemaforoCalculoMuestra.FormattingEnabled = True
        Me.cmbFacturacionSemaforoCalculoMuestra.IsPK = False
        Me.cmbFacturacionSemaforoCalculoMuestra.IsRequired = False
        Me.cmbFacturacionSemaforoCalculoMuestra.Items.AddRange(New Object() {"ACTUAL", "ULTIMO"})
        Me.cmbFacturacionSemaforoCalculoMuestra.Key = Nothing
        Me.cmbFacturacionSemaforoCalculoMuestra.LabelAsoc = Me.lblFacturacionSemaforoCalculoMuestra
        Me.cmbFacturacionSemaforoCalculoMuestra.Location = New System.Drawing.Point(728, 146)
        Me.cmbFacturacionSemaforoCalculoMuestra.Name = "cmbFacturacionSemaforoCalculoMuestra"
        Me.cmbFacturacionSemaforoCalculoMuestra.Size = New System.Drawing.Size(166, 21)
        Me.cmbFacturacionSemaforoCalculoMuestra.TabIndex = 31
        '
        'cmbVentaPrecioVenta
        '
        Me.cmbVentaPrecioVenta.BindearPropiedadControl = Nothing
        Me.cmbVentaPrecioVenta.BindearPropiedadEntidad = Nothing
        Me.cmbVentaPrecioVenta.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbVentaPrecioVenta.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbVentaPrecioVenta.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbVentaPrecioVenta.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbVentaPrecioVenta.FormattingEnabled = True
        Me.cmbVentaPrecioVenta.IsPK = False
        Me.cmbVentaPrecioVenta.IsRequired = False
        Me.cmbVentaPrecioVenta.Items.AddRange(New Object() {"ACTUAL", "ULTIMO"})
        Me.cmbVentaPrecioVenta.Key = Nothing
        Me.cmbVentaPrecioVenta.LabelAsoc = Nothing
        Me.cmbVentaPrecioVenta.Location = New System.Drawing.Point(425, 259)
        Me.cmbVentaPrecioVenta.Name = "cmbVentaPrecioVenta"
        Me.cmbVentaPrecioVenta.Size = New System.Drawing.Size(92, 21)
        Me.cmbVentaPrecioVenta.TabIndex = 38
        Me.cmbVentaPrecioVenta.Tag = "VENTASPRECIOVENTA"
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
        Me.txtIdentifNCREDNoGL.Location = New System.Drawing.Point(7, 277)
        Me.txtIdentifNCREDNoGL.MaxLength = 20
        Me.txtIdentifNCREDNoGL.Name = "txtIdentifNCREDNoGL"
        Me.txtIdentifNCREDNoGL.Size = New System.Drawing.Size(118, 20)
        Me.txtIdentifNCREDNoGL.TabIndex = 16
        Me.txtIdentifNCREDNoGL.Tag = "IDNCREDNOGL"
        Me.txtIdentifNCREDNoGL.Text = "DEV-COTIZACION"
        '
        'chbFacturacionContadoEsEnPesos
        '
        Me.chbFacturacionContadoEsEnPesos.BindearPropiedadControl = Nothing
        Me.chbFacturacionContadoEsEnPesos.BindearPropiedadEntidad = Nothing
        Me.chbFacturacionContadoEsEnPesos.ForeColorFocus = System.Drawing.Color.Red
        Me.chbFacturacionContadoEsEnPesos.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbFacturacionContadoEsEnPesos.IsPK = False
        Me.chbFacturacionContadoEsEnPesos.IsRequired = False
        Me.chbFacturacionContadoEsEnPesos.Key = Nothing
        Me.chbFacturacionContadoEsEnPesos.LabelAsoc = Nothing
        Me.chbFacturacionContadoEsEnPesos.Location = New System.Drawing.Point(8, 304)
        Me.chbFacturacionContadoEsEnPesos.Name = "chbFacturacionContadoEsEnPesos"
        Me.chbFacturacionContadoEsEnPesos.Size = New System.Drawing.Size(265, 24)
        Me.chbFacturacionContadoEsEnPesos.TabIndex = 18
        Me.chbFacturacionContadoEsEnPesos.Tag = "FACTURACIONCONTADOESENPESOS"
        Me.chbFacturacionContadoEsEnPesos.Text = "Comprobante en Contado es en Pesos"
        Me.chbFacturacionContadoEsEnPesos.UseVisualStyleBackColor = True
        '
        'chbFacturacionTicketIncluyeRecargoGeneral
        '
        Me.chbFacturacionTicketIncluyeRecargoGeneral.BindearPropiedadControl = Nothing
        Me.chbFacturacionTicketIncluyeRecargoGeneral.BindearPropiedadEntidad = Nothing
        Me.chbFacturacionTicketIncluyeRecargoGeneral.ForeColorFocus = System.Drawing.Color.Red
        Me.chbFacturacionTicketIncluyeRecargoGeneral.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbFacturacionTicketIncluyeRecargoGeneral.IsPK = False
        Me.chbFacturacionTicketIncluyeRecargoGeneral.IsRequired = False
        Me.chbFacturacionTicketIncluyeRecargoGeneral.Key = Nothing
        Me.chbFacturacionTicketIncluyeRecargoGeneral.LabelAsoc = Nothing
        Me.chbFacturacionTicketIncluyeRecargoGeneral.Location = New System.Drawing.Point(8, 325)
        Me.chbFacturacionTicketIncluyeRecargoGeneral.Name = "chbFacturacionTicketIncluyeRecargoGeneral"
        Me.chbFacturacionTicketIncluyeRecargoGeneral.Size = New System.Drawing.Size(265, 24)
        Me.chbFacturacionTicketIncluyeRecargoGeneral.TabIndex = 19
        Me.chbFacturacionTicketIncluyeRecargoGeneral.Tag = "FACTURACIONTICKETINCLUYERECARGOGENERAL"
        Me.chbFacturacionTicketIncluyeRecargoGeneral.Text = "Ticket: incluye Recargo General"
        Me.chbFacturacionTicketIncluyeRecargoGeneral.UseVisualStyleBackColor = True
        '
        'chbFacturacionPermitirFechaNumAnterior
        '
        Me.chbFacturacionPermitirFechaNumAnterior.BindearPropiedadControl = Nothing
        Me.chbFacturacionPermitirFechaNumAnterior.BindearPropiedadEntidad = Nothing
        Me.chbFacturacionPermitirFechaNumAnterior.Checked = True
        Me.chbFacturacionPermitirFechaNumAnterior.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chbFacturacionPermitirFechaNumAnterior.ForeColorFocus = System.Drawing.Color.Red
        Me.chbFacturacionPermitirFechaNumAnterior.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbFacturacionPermitirFechaNumAnterior.IsPK = False
        Me.chbFacturacionPermitirFechaNumAnterior.IsRequired = False
        Me.chbFacturacionPermitirFechaNumAnterior.Key = Nothing
        Me.chbFacturacionPermitirFechaNumAnterior.LabelAsoc = Nothing
        Me.chbFacturacionPermitirFechaNumAnterior.Location = New System.Drawing.Point(425, 3)
        Me.chbFacturacionPermitirFechaNumAnterior.Name = "chbFacturacionPermitirFechaNumAnterior"
        Me.chbFacturacionPermitirFechaNumAnterior.Size = New System.Drawing.Size(308, 22)
        Me.chbFacturacionPermitirFechaNumAnterior.TabIndex = 22
        Me.chbFacturacionPermitirFechaNumAnterior.Tag = "FACTURACIONCOMPROBFECHNUMANTERIOR"
        Me.chbFacturacionPermitirFechaNumAnterior.Text = "Permitir Comprobantes con Fecha Anterior"
        Me.chbFacturacionPermitirFechaNumAnterior.UseVisualStyleBackColor = True
        '
        'chbFacturacionPermiteFacturarEnOtrasMonedas
        '
        Me.chbFacturacionPermiteFacturarEnOtrasMonedas.BindearPropiedadControl = Nothing
        Me.chbFacturacionPermiteFacturarEnOtrasMonedas.BindearPropiedadEntidad = Nothing
        Me.chbFacturacionPermiteFacturarEnOtrasMonedas.ForeColorFocus = System.Drawing.Color.Red
        Me.chbFacturacionPermiteFacturarEnOtrasMonedas.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbFacturacionPermiteFacturarEnOtrasMonedas.IsPK = False
        Me.chbFacturacionPermiteFacturarEnOtrasMonedas.IsRequired = False
        Me.chbFacturacionPermiteFacturarEnOtrasMonedas.Key = Nothing
        Me.chbFacturacionPermiteFacturarEnOtrasMonedas.LabelAsoc = Nothing
        Me.chbFacturacionPermiteFacturarEnOtrasMonedas.Location = New System.Drawing.Point(425, 95)
        Me.chbFacturacionPermiteFacturarEnOtrasMonedas.Name = "chbFacturacionPermiteFacturarEnOtrasMonedas"
        Me.chbFacturacionPermiteFacturarEnOtrasMonedas.Size = New System.Drawing.Size(316, 24)
        Me.chbFacturacionPermiteFacturarEnOtrasMonedas.TabIndex = 27
        Me.chbFacturacionPermiteFacturarEnOtrasMonedas.Text = "Facturación Permite Facturar en Otras Monedas"
        Me.chbFacturacionPermiteFacturarEnOtrasMonedas.UseVisualStyleBackColor = True
        '
        'chbFacturacionRapidaMantieneElComprobante
        '
        Me.chbFacturacionRapidaMantieneElComprobante.BindearPropiedadControl = Nothing
        Me.chbFacturacionRapidaMantieneElComprobante.BindearPropiedadEntidad = Nothing
        Me.chbFacturacionRapidaMantieneElComprobante.ForeColorFocus = System.Drawing.Color.Red
        Me.chbFacturacionRapidaMantieneElComprobante.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbFacturacionRapidaMantieneElComprobante.IsPK = False
        Me.chbFacturacionRapidaMantieneElComprobante.IsRequired = False
        Me.chbFacturacionRapidaMantieneElComprobante.Key = Nothing
        Me.chbFacturacionRapidaMantieneElComprobante.LabelAsoc = Nothing
        Me.chbFacturacionRapidaMantieneElComprobante.Location = New System.Drawing.Point(425, 70)
        Me.chbFacturacionRapidaMantieneElComprobante.Name = "chbFacturacionRapidaMantieneElComprobante"
        Me.chbFacturacionRapidaMantieneElComprobante.Size = New System.Drawing.Size(316, 24)
        Me.chbFacturacionRapidaMantieneElComprobante.TabIndex = 26
        Me.chbFacturacionRapidaMantieneElComprobante.Tag = "FACTURACIONMANTIENECOMPROBANTE"
        Me.chbFacturacionRapidaMantieneElComprobante.Text = "Facturación Mantiene el Comprobante"
        Me.chbFacturacionRapidaMantieneElComprobante.UseVisualStyleBackColor = True
        '
        'chbFacturacionPresupuestoIncluyeRecargoGeneral
        '
        Me.chbFacturacionPresupuestoIncluyeRecargoGeneral.BindearPropiedadControl = Nothing
        Me.chbFacturacionPresupuestoIncluyeRecargoGeneral.BindearPropiedadEntidad = Nothing
        Me.chbFacturacionPresupuestoIncluyeRecargoGeneral.ForeColorFocus = System.Drawing.Color.Red
        Me.chbFacturacionPresupuestoIncluyeRecargoGeneral.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbFacturacionPresupuestoIncluyeRecargoGeneral.IsPK = False
        Me.chbFacturacionPresupuestoIncluyeRecargoGeneral.IsRequired = False
        Me.chbFacturacionPresupuestoIncluyeRecargoGeneral.Key = Nothing
        Me.chbFacturacionPresupuestoIncluyeRecargoGeneral.LabelAsoc = Nothing
        Me.chbFacturacionPresupuestoIncluyeRecargoGeneral.Location = New System.Drawing.Point(8, 346)
        Me.chbFacturacionPresupuestoIncluyeRecargoGeneral.Name = "chbFacturacionPresupuestoIncluyeRecargoGeneral"
        Me.chbFacturacionPresupuestoIncluyeRecargoGeneral.Size = New System.Drawing.Size(265, 24)
        Me.chbFacturacionPresupuestoIncluyeRecargoGeneral.TabIndex = 20
        Me.chbFacturacionPresupuestoIncluyeRecargoGeneral.Tag = "FACTURACIONPRESUPUESTOINCLUYERECARGOGENERAL"
        Me.chbFacturacionPresupuestoIncluyeRecargoGeneral.Text = "Presupuesto: incluye Recargo General"
        Me.chbFacturacionPresupuestoIncluyeRecargoGeneral.UseVisualStyleBackColor = True
        '
        'chbFacturacionModificaDescRecargoProducto
        '
        Me.chbFacturacionModificaDescRecargoProducto.BindearPropiedadControl = Nothing
        Me.chbFacturacionModificaDescRecargoProducto.BindearPropiedadEntidad = Nothing
        Me.chbFacturacionModificaDescRecargoProducto.ForeColorFocus = System.Drawing.Color.Red
        Me.chbFacturacionModificaDescRecargoProducto.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbFacturacionModificaDescRecargoProducto.IsPK = False
        Me.chbFacturacionModificaDescRecargoProducto.IsRequired = False
        Me.chbFacturacionModificaDescRecargoProducto.Key = Nothing
        Me.chbFacturacionModificaDescRecargoProducto.LabelAsoc = Nothing
        Me.chbFacturacionModificaDescRecargoProducto.Location = New System.Drawing.Point(9, 148)
        Me.chbFacturacionModificaDescRecargoProducto.Name = "chbFacturacionModificaDescRecargoProducto"
        Me.chbFacturacionModificaDescRecargoProducto.Size = New System.Drawing.Size(289, 24)
        Me.chbFacturacionModificaDescRecargoProducto.TabIndex = 8
        Me.chbFacturacionModificaDescRecargoProducto.Tag = "FACTURACIONMODIFICADESCRECPRODUCTO"
        Me.chbFacturacionModificaDescRecargoProducto.Text = "Permite modificar el Descuento/Recargo del Producto."
        Me.chbFacturacionModificaDescRecargoProducto.UseVisualStyleBackColor = True
        '
        'chbFacturacionRapidaMantieneElCliente
        '
        Me.chbFacturacionRapidaMantieneElCliente.AutoSize = True
        Me.chbFacturacionRapidaMantieneElCliente.BindearPropiedadControl = Nothing
        Me.chbFacturacionRapidaMantieneElCliente.BindearPropiedadEntidad = Nothing
        Me.chbFacturacionRapidaMantieneElCliente.ForeColorFocus = System.Drawing.Color.Red
        Me.chbFacturacionRapidaMantieneElCliente.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbFacturacionRapidaMantieneElCliente.IsPK = False
        Me.chbFacturacionRapidaMantieneElCliente.IsRequired = False
        Me.chbFacturacionRapidaMantieneElCliente.Key = Nothing
        Me.chbFacturacionRapidaMantieneElCliente.LabelAsoc = Nothing
        Me.chbFacturacionRapidaMantieneElCliente.Location = New System.Drawing.Point(425, 51)
        Me.chbFacturacionRapidaMantieneElCliente.Name = "chbFacturacionRapidaMantieneElCliente"
        Me.chbFacturacionRapidaMantieneElCliente.Size = New System.Drawing.Size(175, 17)
        Me.chbFacturacionRapidaMantieneElCliente.TabIndex = 23
        Me.chbFacturacionRapidaMantieneElCliente.Tag = "FACTURACIONMANTIENECLIENTE"
        Me.chbFacturacionRapidaMantieneElCliente.Text = "Facturación Mantiene el Cliente"
        Me.chbFacturacionRapidaMantieneElCliente.UseVisualStyleBackColor = True
        '
        'chbVisualizaVentasAntesImprimir
        '
        Me.chbVisualizaVentasAntesImprimir.BindearPropiedadControl = Nothing
        Me.chbVisualizaVentasAntesImprimir.BindearPropiedadEntidad = Nothing
        Me.chbVisualizaVentasAntesImprimir.ForeColorFocus = System.Drawing.Color.Red
        Me.chbVisualizaVentasAntesImprimir.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbVisualizaVentasAntesImprimir.IsPK = False
        Me.chbVisualizaVentasAntesImprimir.IsRequired = False
        Me.chbVisualizaVentasAntesImprimir.Key = Nothing
        Me.chbVisualizaVentasAntesImprimir.LabelAsoc = Nothing
        Me.chbVisualizaVentasAntesImprimir.Location = New System.Drawing.Point(425, 121)
        Me.chbVisualizaVentasAntesImprimir.Name = "chbVisualizaVentasAntesImprimir"
        Me.chbVisualizaVentasAntesImprimir.Size = New System.Drawing.Size(297, 20)
        Me.chbVisualizaVentasAntesImprimir.TabIndex = 28
        Me.chbVisualizaVentasAntesImprimir.Tag = "VISUALIZACOMPROBANTESDEVENTA"
        Me.chbVisualizaVentasAntesImprimir.Text = "Visualiza los comprobantes de Ventas antes de imprimir"
        Me.chbVisualizaVentasAntesImprimir.UseVisualStyleBackColor = True
        '
        'chbActualizaPreciosDeVenta
        '
        Me.chbActualizaPreciosDeVenta.BindearPropiedadControl = Nothing
        Me.chbActualizaPreciosDeVenta.BindearPropiedadEntidad = Nothing
        Me.chbActualizaPreciosDeVenta.ForeColorFocus = System.Drawing.Color.Red
        Me.chbActualizaPreciosDeVenta.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbActualizaPreciosDeVenta.IsPK = False
        Me.chbActualizaPreciosDeVenta.IsRequired = False
        Me.chbActualizaPreciosDeVenta.Key = Nothing
        Me.chbActualizaPreciosDeVenta.LabelAsoc = Nothing
        Me.chbActualizaPreciosDeVenta.Location = New System.Drawing.Point(425, 173)
        Me.chbActualizaPreciosDeVenta.Name = "chbActualizaPreciosDeVenta"
        Me.chbActualizaPreciosDeVenta.Size = New System.Drawing.Size(311, 26)
        Me.chbActualizaPreciosDeVenta.TabIndex = 32
        Me.chbActualizaPreciosDeVenta.Tag = "ACTUALIZAPRECIOSDEVENTA"
        Me.chbActualizaPreciosDeVenta.Text = "Actualiza los precios de Venta si cambia la Lista de Precios"
        Me.chbActualizaPreciosDeVenta.UseVisualStyleBackColor = True
        '
        'chbVentasConProductosEnCero
        '
        Me.chbVentasConProductosEnCero.BindearPropiedadControl = Nothing
        Me.chbVentasConProductosEnCero.BindearPropiedadEntidad = Nothing
        Me.chbVentasConProductosEnCero.ForeColorFocus = System.Drawing.Color.Red
        Me.chbVentasConProductosEnCero.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbVentasConProductosEnCero.IsPK = False
        Me.chbVentasConProductosEnCero.IsRequired = False
        Me.chbVentasConProductosEnCero.Key = Nothing
        Me.chbVentasConProductosEnCero.LabelAsoc = Nothing
        Me.chbVentasConProductosEnCero.Location = New System.Drawing.Point(425, 205)
        Me.chbVentasConProductosEnCero.Name = "chbVentasConProductosEnCero"
        Me.chbVentasConProductosEnCero.Size = New System.Drawing.Size(246, 21)
        Me.chbVentasConProductosEnCero.TabIndex = 33
        Me.chbVentasConProductosEnCero.Tag = "VENTASCONPRODUCTOSENCERO"
        Me.chbVentasConProductosEnCero.Text = "Permite ingresar productos con precio cero"
        Me.chbVentasConProductosEnCero.UseVisualStyleBackColor = True
        '
        'chbVisualizaSemaforoUtilidad
        '
        Me.chbVisualizaSemaforoUtilidad.BindearPropiedadControl = Nothing
        Me.chbVisualizaSemaforoUtilidad.BindearPropiedadEntidad = Nothing
        Me.chbVisualizaSemaforoUtilidad.ForeColorFocus = System.Drawing.Color.Red
        Me.chbVisualizaSemaforoUtilidad.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbVisualizaSemaforoUtilidad.IsPK = False
        Me.chbVisualizaSemaforoUtilidad.IsRequired = False
        Me.chbVisualizaSemaforoUtilidad.Key = Nothing
        Me.chbVisualizaSemaforoUtilidad.LabelAsoc = Nothing
        Me.chbVisualizaSemaforoUtilidad.Location = New System.Drawing.Point(425, 147)
        Me.chbVisualizaSemaforoUtilidad.Name = "chbVisualizaSemaforoUtilidad"
        Me.chbVisualizaSemaforoUtilidad.Size = New System.Drawing.Size(194, 20)
        Me.chbVisualizaSemaforoUtilidad.TabIndex = 29
        Me.chbVisualizaSemaforoUtilidad.Tag = "FACTURACIONVISUALIZASEMAFOROUTILIDAD"
        Me.chbVisualizaSemaforoUtilidad.Text = "Visualiza el Semaforo de Utilidad"
        Me.chbVisualizaSemaforoUtilidad.UseVisualStyleBackColor = True
        '
        'lblVentaPrecioVenta
        '
        Me.lblVentaPrecioVenta.AutoSize = True
        Me.lblVentaPrecioVenta.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblVentaPrecioVenta.LabelAsoc = Nothing
        Me.lblVentaPrecioVenta.Location = New System.Drawing.Point(523, 263)
        Me.lblVentaPrecioVenta.Name = "lblVentaPrecioVenta"
        Me.lblVentaPrecioVenta.Size = New System.Drawing.Size(83, 13)
        Me.lblVentaPrecioVenta.TabIndex = 39
        Me.lblVentaPrecioVenta.Text = "Precio de Venta"
        '
        'chbFacturacionInvocarInvocador
        '
        Me.chbFacturacionInvocarInvocador.BindearPropiedadControl = Nothing
        Me.chbFacturacionInvocarInvocador.BindearPropiedadEntidad = Nothing
        Me.chbFacturacionInvocarInvocador.ForeColorFocus = System.Drawing.Color.Red
        Me.chbFacturacionInvocarInvocador.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbFacturacionInvocarInvocador.IsPK = False
        Me.chbFacturacionInvocarInvocador.IsRequired = False
        Me.chbFacturacionInvocarInvocador.Key = Nothing
        Me.chbFacturacionInvocarInvocador.LabelAsoc = Nothing
        Me.chbFacturacionInvocarInvocador.Location = New System.Drawing.Point(425, 284)
        Me.chbFacturacionInvocarInvocador.Name = "chbFacturacionInvocarInvocador"
        Me.chbFacturacionInvocarInvocador.Size = New System.Drawing.Size(316, 24)
        Me.chbFacturacionInvocarInvocador.TabIndex = 40
        Me.chbFacturacionInvocarInvocador.Tag = "FACTURACIONINVOCARINVOCADOR"
        Me.chbFacturacionInvocarInvocador.Text = "Permite Invocar un Comprobante que Invoco a Otro/s ."
        Me.chbFacturacionInvocarInvocador.UseVisualStyleBackColor = True
        '
        'cmbVentaPrecioCosto
        '
        Me.cmbVentaPrecioCosto.BindearPropiedadControl = Nothing
        Me.cmbVentaPrecioCosto.BindearPropiedadEntidad = Nothing
        Me.cmbVentaPrecioCosto.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbVentaPrecioCosto.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbVentaPrecioCosto.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbVentaPrecioCosto.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbVentaPrecioCosto.FormattingEnabled = True
        Me.cmbVentaPrecioCosto.IsPK = False
        Me.cmbVentaPrecioCosto.IsRequired = False
        Me.cmbVentaPrecioCosto.Items.AddRange(New Object() {"ACTUAL", "PROMPOND"})
        Me.cmbVentaPrecioCosto.Key = Nothing
        Me.cmbVentaPrecioCosto.LabelAsoc = Nothing
        Me.cmbVentaPrecioCosto.Location = New System.Drawing.Point(425, 232)
        Me.cmbVentaPrecioCosto.Name = "cmbVentaPrecioCosto"
        Me.cmbVentaPrecioCosto.Size = New System.Drawing.Size(92, 21)
        Me.cmbVentaPrecioCosto.TabIndex = 34
        Me.cmbVentaPrecioCosto.Tag = "VENTASPRECIOVENTA"
        '
        'lblVentaPrecioCostoMeses
        '
        Me.lblVentaPrecioCostoMeses.AutoSize = True
        Me.lblVentaPrecioCostoMeses.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblVentaPrecioCostoMeses.LabelAsoc = Nothing
        Me.lblVentaPrecioCostoMeses.Location = New System.Drawing.Point(663, 236)
        Me.lblVentaPrecioCostoMeses.Name = "lblVentaPrecioCostoMeses"
        Me.lblVentaPrecioCostoMeses.Size = New System.Drawing.Size(37, 13)
        Me.lblVentaPrecioCostoMeses.TabIndex = 37
        Me.lblVentaPrecioCostoMeses.Text = "meses"
        '
        'txtVentaPrecioCostoMeses
        '
        Me.txtVentaPrecioCostoMeses.BindearPropiedadControl = Nothing
        Me.txtVentaPrecioCostoMeses.BindearPropiedadEntidad = Nothing
        Me.txtVentaPrecioCostoMeses.ForeColorFocus = System.Drawing.Color.Red
        Me.txtVentaPrecioCostoMeses.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtVentaPrecioCostoMeses.Formato = ""
        Me.txtVentaPrecioCostoMeses.IsDecimal = False
        Me.txtVentaPrecioCostoMeses.IsNumber = True
        Me.txtVentaPrecioCostoMeses.IsPK = False
        Me.txtVentaPrecioCostoMeses.IsRequired = False
        Me.txtVentaPrecioCostoMeses.Key = ""
        Me.txtVentaPrecioCostoMeses.LabelAsoc = Me.lblVentaPrecioCostoMeses
        Me.txtVentaPrecioCostoMeses.Location = New System.Drawing.Point(622, 232)
        Me.txtVentaPrecioCostoMeses.MaxLength = 3
        Me.txtVentaPrecioCostoMeses.Name = "txtVentaPrecioCostoMeses"
        Me.txtVentaPrecioCostoMeses.Size = New System.Drawing.Size(35, 20)
        Me.txtVentaPrecioCostoMeses.TabIndex = 36
        Me.txtVentaPrecioCostoMeses.Tag = ""
        Me.txtVentaPrecioCostoMeses.Text = "0"
        Me.txtVentaPrecioCostoMeses.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'chbFacturacionPermitirFechaFutura
        '
        Me.chbFacturacionPermitirFechaFutura.BindearPropiedadControl = Nothing
        Me.chbFacturacionPermitirFechaFutura.BindearPropiedadEntidad = Nothing
        Me.chbFacturacionPermitirFechaFutura.Checked = True
        Me.chbFacturacionPermitirFechaFutura.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chbFacturacionPermitirFechaFutura.ForeColorFocus = System.Drawing.Color.Red
        Me.chbFacturacionPermitirFechaFutura.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbFacturacionPermitirFechaFutura.IsPK = False
        Me.chbFacturacionPermitirFechaFutura.IsRequired = False
        Me.chbFacturacionPermitirFechaFutura.Key = Nothing
        Me.chbFacturacionPermitirFechaFutura.LabelAsoc = Nothing
        Me.chbFacturacionPermitirFechaFutura.Location = New System.Drawing.Point(425, 26)
        Me.chbFacturacionPermitirFechaFutura.Name = "chbFacturacionPermitirFechaFutura"
        Me.chbFacturacionPermitirFechaFutura.Size = New System.Drawing.Size(308, 22)
        Me.chbFacturacionPermitirFechaFutura.TabIndex = 59
        Me.chbFacturacionPermitirFechaFutura.Tag = "FACTURACIONCOMPROBFECHNUMANTERIOR"
        Me.chbFacturacionPermitirFechaFutura.Text = "Permitir Comprobantes con Fecha Futura"
        Me.chbFacturacionPermitirFechaFutura.UseVisualStyleBackColor = True
        '
        'ucConfVentas1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.chbFacturacionPermitirFechaFutura)
        Me.Controls.Add(Me.lblVentaPrecioCostoMeses)
        Me.Controls.Add(Me.txtVentaPrecioCostoMeses)
        Me.Controls.Add(Me.cmbVentaPrecioCosto)
        Me.Controls.Add(Me.chbGrabaLibroNoIncluyeRecargoGeneral)
        Me.Controls.Add(Me.chbFacturacionModificaDescRecProductoPorMonto)
        Me.Controls.Add(Me.chbFacturacionModificaDescRecGralPorc)
        Me.Controls.Add(Me.chbFacturacionSolicitaComprobante)
        Me.Controls.Add(Me.chbFacturacionSolicitaVendedor)
        Me.Controls.Add(Me.chbFacturacionInvocarDeOtroCliente)
        Me.Controls.Add(Me.txtDiasPresupuesto)
        Me.Controls.Add(Me.lblDiasPresupuesto)
        Me.Controls.Add(Me.lblUltimaHojaVentas)
        Me.Controls.Add(Me.txtUltimaHojaVentas)
        Me.Controls.Add(Me.chbFacturacionModificaNumeroComprobante)
        Me.Controls.Add(Me.chbFacturacionModificaDescripcionProducto)
        Me.Controls.Add(Me.lblVentaPrecioCosto)
        Me.Controls.Add(Me.chbFacturacionModificaPrecioProducto)
        Me.Controls.Add(Me.lblFacturacionSemaforoCalculoMuestra)
        Me.Controls.Add(Me.lblFacturacionMantieneElClienteDefault)
        Me.Controls.Add(Me.lblIdentifNDEBGL)
        Me.Controls.Add(Me.txtFacturacionMantieneElClienteDefault)
        Me.Controls.Add(Me.txtIdentifNDEBGL)
        Me.Controls.Add(Me.lblIdentifNCREDGL)
        Me.Controls.Add(Me.txtIdentifNCREDGL)
        Me.Controls.Add(Me.lblIdentifNDEBNoGL)
        Me.Controls.Add(Me.txtIdentifNDEBNoGL)
        Me.Controls.Add(Me.lblIdentifNCREDNoGL)
        Me.Controls.Add(Me.cmbFacturacionSemaforoCalculoMuestra)
        Me.Controls.Add(Me.cmbVentaPrecioVenta)
        Me.Controls.Add(Me.txtIdentifNCREDNoGL)
        Me.Controls.Add(Me.chbFacturacionContadoEsEnPesos)
        Me.Controls.Add(Me.chbFacturacionTicketIncluyeRecargoGeneral)
        Me.Controls.Add(Me.chbFacturacionPermitirFechaNumAnterior)
        Me.Controls.Add(Me.chbFacturacionPermiteFacturarEnOtrasMonedas)
        Me.Controls.Add(Me.chbFacturacionRapidaMantieneElComprobante)
        Me.Controls.Add(Me.chbFacturacionPresupuestoIncluyeRecargoGeneral)
        Me.Controls.Add(Me.chbFacturacionModificaDescRecargoProducto)
        Me.Controls.Add(Me.chbFacturacionRapidaMantieneElCliente)
        Me.Controls.Add(Me.chbVisualizaVentasAntesImprimir)
        Me.Controls.Add(Me.chbActualizaPreciosDeVenta)
        Me.Controls.Add(Me.chbVentasConProductosEnCero)
        Me.Controls.Add(Me.chbVisualizaSemaforoUtilidad)
        Me.Controls.Add(Me.lblVentaPrecioVenta)
        Me.Controls.Add(Me.chbFacturacionInvocarInvocador)
        Me.Name = "ucConfVentas1"
        Me.Controls.SetChildIndex(Me.chbFacturacionInvocarInvocador, 0)
        Me.Controls.SetChildIndex(Me.lblVentaPrecioVenta, 0)
        Me.Controls.SetChildIndex(Me.chbVisualizaSemaforoUtilidad, 0)
        Me.Controls.SetChildIndex(Me.chbVentasConProductosEnCero, 0)
        Me.Controls.SetChildIndex(Me.chbActualizaPreciosDeVenta, 0)
        Me.Controls.SetChildIndex(Me.chbVisualizaVentasAntesImprimir, 0)
        Me.Controls.SetChildIndex(Me.chbFacturacionRapidaMantieneElCliente, 0)
        Me.Controls.SetChildIndex(Me.chbFacturacionModificaDescRecargoProducto, 0)
        Me.Controls.SetChildIndex(Me.chbFacturacionPresupuestoIncluyeRecargoGeneral, 0)
        Me.Controls.SetChildIndex(Me.chbFacturacionRapidaMantieneElComprobante, 0)
        Me.Controls.SetChildIndex(Me.chbFacturacionPermiteFacturarEnOtrasMonedas, 0)
        Me.Controls.SetChildIndex(Me.chbFacturacionPermitirFechaNumAnterior, 0)
        Me.Controls.SetChildIndex(Me.chbFacturacionTicketIncluyeRecargoGeneral, 0)
        Me.Controls.SetChildIndex(Me.chbFacturacionContadoEsEnPesos, 0)
        Me.Controls.SetChildIndex(Me.txtIdentifNCREDNoGL, 0)
        Me.Controls.SetChildIndex(Me.cmbVentaPrecioVenta, 0)
        Me.Controls.SetChildIndex(Me.cmbFacturacionSemaforoCalculoMuestra, 0)
        Me.Controls.SetChildIndex(Me.lblIdentifNCREDNoGL, 0)
        Me.Controls.SetChildIndex(Me.txtIdentifNDEBNoGL, 0)
        Me.Controls.SetChildIndex(Me.lblIdentifNDEBNoGL, 0)
        Me.Controls.SetChildIndex(Me.txtIdentifNCREDGL, 0)
        Me.Controls.SetChildIndex(Me.lblIdentifNCREDGL, 0)
        Me.Controls.SetChildIndex(Me.txtIdentifNDEBGL, 0)
        Me.Controls.SetChildIndex(Me.txtFacturacionMantieneElClienteDefault, 0)
        Me.Controls.SetChildIndex(Me.lblIdentifNDEBGL, 0)
        Me.Controls.SetChildIndex(Me.lblFacturacionMantieneElClienteDefault, 0)
        Me.Controls.SetChildIndex(Me.lblFacturacionSemaforoCalculoMuestra, 0)
        Me.Controls.SetChildIndex(Me.chbFacturacionModificaPrecioProducto, 0)
        Me.Controls.SetChildIndex(Me.lblVentaPrecioCosto, 0)
        Me.Controls.SetChildIndex(Me.chbFacturacionModificaDescripcionProducto, 0)
        Me.Controls.SetChildIndex(Me.chbFacturacionModificaNumeroComprobante, 0)
        Me.Controls.SetChildIndex(Me.txtUltimaHojaVentas, 0)
        Me.Controls.SetChildIndex(Me.lblUltimaHojaVentas, 0)
        Me.Controls.SetChildIndex(Me.lblDiasPresupuesto, 0)
        Me.Controls.SetChildIndex(Me.txtDiasPresupuesto, 0)
        Me.Controls.SetChildIndex(Me.chbFacturacionInvocarDeOtroCliente, 0)
        Me.Controls.SetChildIndex(Me.chbFacturacionSolicitaVendedor, 0)
        Me.Controls.SetChildIndex(Me.chbFacturacionSolicitaComprobante, 0)
        Me.Controls.SetChildIndex(Me.chbFacturacionModificaDescRecGralPorc, 0)
        Me.Controls.SetChildIndex(Me.chbFacturacionModificaDescRecProductoPorMonto, 0)
        Me.Controls.SetChildIndex(Me.chbGrabaLibroNoIncluyeRecargoGeneral, 0)
        Me.Controls.SetChildIndex(Me.cmbVentaPrecioCosto, 0)
        Me.Controls.SetChildIndex(Me.txtVentaPrecioCostoMeses, 0)
        Me.Controls.SetChildIndex(Me.lblVentaPrecioCostoMeses, 0)
        Me.Controls.SetChildIndex(Me.chbFacturacionPermitirFechaFutura, 0)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents chbGrabaLibroNoIncluyeRecargoGeneral As Controles.CheckBox
    Friend WithEvents chbFacturacionModificaDescRecProductoPorMonto As Controles.CheckBox
    Friend WithEvents chbFacturacionModificaDescRecGralPorc As Controles.CheckBox
    Friend WithEvents chbFacturacionSolicitaComprobante As Controles.CheckBox
    Friend WithEvents chbFacturacionSolicitaVendedor As Controles.CheckBox
    Friend WithEvents chbFacturacionInvocarDeOtroCliente As Controles.CheckBox
    Friend WithEvents txtDiasPresupuesto As Controles.TextBox
    Friend WithEvents lblDiasPresupuesto As Controles.Label
    Friend WithEvents lblUltimaHojaVentas As Controles.Label
    Friend WithEvents txtUltimaHojaVentas As Controles.TextBox
    Friend WithEvents chbFacturacionModificaNumeroComprobante As Controles.CheckBox
    Friend WithEvents chbFacturacionModificaDescripcionProducto As Controles.CheckBox
    Friend WithEvents lblVentaPrecioCosto As Controles.Label
    Friend WithEvents chbFacturacionModificaPrecioProducto As Controles.CheckBox
    Friend WithEvents lblFacturacionSemaforoCalculoMuestra As Controles.Label
    Friend WithEvents lblFacturacionMantieneElClienteDefault As Controles.Label
    Friend WithEvents lblIdentifNDEBGL As Controles.Label
    Friend WithEvents txtFacturacionMantieneElClienteDefault As Controles.TextBox
    Friend WithEvents txtIdentifNDEBGL As Controles.TextBox
    Friend WithEvents lblIdentifNCREDGL As Controles.Label
    Friend WithEvents txtIdentifNCREDGL As Controles.TextBox
    Friend WithEvents lblIdentifNDEBNoGL As Controles.Label
    Friend WithEvents txtIdentifNDEBNoGL As Controles.TextBox
    Friend WithEvents lblIdentifNCREDNoGL As Controles.Label
    Friend WithEvents cmbFacturacionSemaforoCalculoMuestra As Controles.ComboBox
    Friend WithEvents cmbVentaPrecioVenta As Controles.ComboBox
    Friend WithEvents txtIdentifNCREDNoGL As Controles.TextBox
    Friend WithEvents chbFacturacionContadoEsEnPesos As Controles.CheckBox
    Friend WithEvents chbFacturacionTicketIncluyeRecargoGeneral As Controles.CheckBox
    Friend WithEvents chbFacturacionPermitirFechaNumAnterior As Controles.CheckBox
    Friend WithEvents chbFacturacionPermiteFacturarEnOtrasMonedas As Controles.CheckBox
    Friend WithEvents chbFacturacionRapidaMantieneElComprobante As Controles.CheckBox
    Friend WithEvents chbFacturacionPresupuestoIncluyeRecargoGeneral As Controles.CheckBox
    Friend WithEvents chbFacturacionModificaDescRecargoProducto As Controles.CheckBox
    Friend WithEvents chbFacturacionRapidaMantieneElCliente As Controles.CheckBox
    Friend WithEvents chbVisualizaVentasAntesImprimir As Controles.CheckBox
    Friend WithEvents chbActualizaPreciosDeVenta As Controles.CheckBox
    Friend WithEvents chbVentasConProductosEnCero As Controles.CheckBox
    Friend WithEvents chbVisualizaSemaforoUtilidad As Controles.CheckBox
    Friend WithEvents lblVentaPrecioVenta As Controles.Label
    Friend WithEvents chbFacturacionInvocarInvocador As Controles.CheckBox
    Friend WithEvents cmbVentaPrecioCosto As Controles.ComboBox
    Friend WithEvents lblVentaPrecioCostoMeses As Controles.Label
    Friend WithEvents txtVentaPrecioCostoMeses As Controles.TextBox
    Friend WithEvents chbFacturacionPermitirFechaFutura As Controles.CheckBox
End Class
