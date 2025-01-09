<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ucConfVentasImpresion
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
        Me.chbMuestraVendedorImpresion = New Eniac.Controles.CheckBox()
        Me.Label2 = New Eniac.Controles.Label()
        Me.Label1 = New Eniac.Controles.Label()
        Me.lblMargenDerecho = New Eniac.Controles.Label()
        Me.lblMargenIzquierdo = New Eniac.Controles.Label()
        Me.txtFacturacionMargenDerecho = New Eniac.Controles.TextBox()
        Me.txtFacturacionMargenIzquierdo = New Eniac.Controles.TextBox()
        Me.chbMuestraSaldoImpresion = New Eniac.Controles.CheckBox()
        Me.chbImpresionMuestraTotalKilos = New Eniac.Controles.CheckBox()
        Me.chbImpresionMuestraTotalProductos = New Eniac.Controles.CheckBox()
        Me.chbImpresionMasivaOrdenInverso = New Eniac.Controles.CheckBox()
        Me.chbImprimeTicketNoFiscal = New Eniac.Controles.CheckBox()
        Me.chbImpresionMiraOrdenProductos = New Eniac.Controles.CheckBox()
        Me.chbVentasImpresionVisualizaNroSerie = New Eniac.Controles.CheckBox()
        Me.chbVentasImpresionMuestraLoteObservacion = New Eniac.Controles.CheckBox()
        Me.chbVentasImpresionVisualizaValidezPresupuesto = New Eniac.Controles.CheckBox()
        Me.chbMuestraSaldoImpresionUnificado = New Eniac.Controles.CheckBox()
        Me.chbFacturacionimprimeReciboVentasCtaCte = New Eniac.Controles.CheckBox()
        Me.chbFacturacionimprimeMuestraHoraVenta = New Eniac.Controles.CheckBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.txtCantidadLineasSeparacion = New Eniac.Controles.TextBox()
        Me.lblCantidadLineasSeparacion = New Eniac.Controles.Label()
        Me.chbfacturacionImprimeCantidadComponentes = New Eniac.Controles.CheckBox()
        Me.chbFacturacionImprimeComponentes = New Eniac.Controles.CheckBox()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'chbMuestraVendedorImpresion
        '
        Me.chbMuestraVendedorImpresion.AutoSize = True
        Me.chbMuestraVendedorImpresion.BindearPropiedadControl = Nothing
        Me.chbMuestraVendedorImpresion.BindearPropiedadEntidad = Nothing
        Me.chbMuestraVendedorImpresion.ForeColorFocus = System.Drawing.Color.Red
        Me.chbMuestraVendedorImpresion.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbMuestraVendedorImpresion.IsPK = False
        Me.chbMuestraVendedorImpresion.IsRequired = False
        Me.chbMuestraVendedorImpresion.Key = Nothing
        Me.chbMuestraVendedorImpresion.LabelAsoc = Nothing
        Me.chbMuestraVendedorImpresion.Location = New System.Drawing.Point(57, 87)
        Me.chbMuestraVendedorImpresion.Name = "chbMuestraVendedorImpresion"
        Me.chbMuestraVendedorImpresion.Size = New System.Drawing.Size(176, 17)
        Me.chbMuestraVendedorImpresion.TabIndex = 3
        Me.chbMuestraVendedorImpresion.Tag = "FACTURACIONMUESTRAVENDEDORIMPRESION"
        Me.chbMuestraVendedorImpresion.Text = "Muestra Vendedor en Impresión"
        Me.chbMuestraVendedorImpresion.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Label2.LabelAsoc = Nothing
        Me.Label2.Location = New System.Drawing.Point(636, 20)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(23, 13)
        Me.Label2.TabIndex = 14
        Me.Label2.Text = "mm"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Label1.LabelAsoc = Nothing
        Me.Label1.Location = New System.Drawing.Point(809, 20)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(23, 13)
        Me.Label1.TabIndex = 17
        Me.Label1.Text = "mm"
        '
        'lblMargenDerecho
        '
        Me.lblMargenDerecho.AutoSize = True
        Me.lblMargenDerecho.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblMargenDerecho.LabelAsoc = Nothing
        Me.lblMargenDerecho.Location = New System.Drawing.Point(668, 20)
        Me.lblMargenDerecho.Name = "lblMargenDerecho"
        Me.lblMargenDerecho.Size = New System.Drawing.Size(110, 13)
        Me.lblMargenDerecho.TabIndex = 15
        Me.lblMargenDerecho.Text = "Imp. Margen Derecho"
        '
        'lblMargenIzquierdo
        '
        Me.lblMargenIzquierdo.AutoSize = True
        Me.lblMargenIzquierdo.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblMargenIzquierdo.LabelAsoc = Nothing
        Me.lblMargenIzquierdo.Location = New System.Drawing.Point(485, 20)
        Me.lblMargenIzquierdo.Name = "lblMargenIzquierdo"
        Me.lblMargenIzquierdo.Size = New System.Drawing.Size(112, 13)
        Me.lblMargenIzquierdo.TabIndex = 12
        Me.lblMargenIzquierdo.Text = "Imp. Margen Izquierdo"
        '
        'txtFacturacionMargenDerecho
        '
        Me.txtFacturacionMargenDerecho.BindearPropiedadControl = Nothing
        Me.txtFacturacionMargenDerecho.BindearPropiedadEntidad = Nothing
        Me.txtFacturacionMargenDerecho.ForeColorFocus = System.Drawing.Color.Red
        Me.txtFacturacionMargenDerecho.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtFacturacionMargenDerecho.Formato = "N0"
        Me.txtFacturacionMargenDerecho.IsDecimal = False
        Me.txtFacturacionMargenDerecho.IsNumber = True
        Me.txtFacturacionMargenDerecho.IsPK = False
        Me.txtFacturacionMargenDerecho.IsRequired = False
        Me.txtFacturacionMargenDerecho.Key = ""
        Me.txtFacturacionMargenDerecho.LabelAsoc = Me.lblMargenDerecho
        Me.txtFacturacionMargenDerecho.Location = New System.Drawing.Point(775, 16)
        Me.txtFacturacionMargenDerecho.MaxLength = 3
        Me.txtFacturacionMargenDerecho.Name = "txtFacturacionMargenDerecho"
        Me.txtFacturacionMargenDerecho.Size = New System.Drawing.Size(34, 20)
        Me.txtFacturacionMargenDerecho.TabIndex = 16
        Me.txtFacturacionMargenDerecho.Tag = "FACTURACIONMARGENDERECHO"
        Me.txtFacturacionMargenDerecho.Text = "5"
        Me.txtFacturacionMargenDerecho.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtFacturacionMargenIzquierdo
        '
        Me.txtFacturacionMargenIzquierdo.BindearPropiedadControl = Nothing
        Me.txtFacturacionMargenIzquierdo.BindearPropiedadEntidad = Nothing
        Me.txtFacturacionMargenIzquierdo.ForeColorFocus = System.Drawing.Color.Red
        Me.txtFacturacionMargenIzquierdo.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtFacturacionMargenIzquierdo.Formato = "N0"
        Me.txtFacturacionMargenIzquierdo.IsDecimal = False
        Me.txtFacturacionMargenIzquierdo.IsNumber = True
        Me.txtFacturacionMargenIzquierdo.IsPK = False
        Me.txtFacturacionMargenIzquierdo.IsRequired = False
        Me.txtFacturacionMargenIzquierdo.Key = ""
        Me.txtFacturacionMargenIzquierdo.LabelAsoc = Me.lblMargenIzquierdo
        Me.txtFacturacionMargenIzquierdo.Location = New System.Drawing.Point(601, 16)
        Me.txtFacturacionMargenIzquierdo.MaxLength = 3
        Me.txtFacturacionMargenIzquierdo.Name = "txtFacturacionMargenIzquierdo"
        Me.txtFacturacionMargenIzquierdo.Size = New System.Drawing.Size(34, 20)
        Me.txtFacturacionMargenIzquierdo.TabIndex = 13
        Me.txtFacturacionMargenIzquierdo.Tag = "FACTURACIONMARGENIZQUIERDO"
        Me.txtFacturacionMargenIzquierdo.Text = "5"
        Me.txtFacturacionMargenIzquierdo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'chbMuestraSaldoImpresion
        '
        Me.chbMuestraSaldoImpresion.AutoSize = True
        Me.chbMuestraSaldoImpresion.BindearPropiedadControl = Nothing
        Me.chbMuestraSaldoImpresion.BindearPropiedadEntidad = Nothing
        Me.chbMuestraSaldoImpresion.ForeColorFocus = System.Drawing.Color.Red
        Me.chbMuestraSaldoImpresion.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbMuestraSaldoImpresion.IsPK = False
        Me.chbMuestraSaldoImpresion.IsRequired = False
        Me.chbMuestraSaldoImpresion.Key = Nothing
        Me.chbMuestraSaldoImpresion.LabelAsoc = Nothing
        Me.chbMuestraSaldoImpresion.Location = New System.Drawing.Point(57, 110)
        Me.chbMuestraSaldoImpresion.Name = "chbMuestraSaldoImpresion"
        Me.chbMuestraSaldoImpresion.Size = New System.Drawing.Size(157, 17)
        Me.chbMuestraSaldoImpresion.TabIndex = 4
        Me.chbMuestraSaldoImpresion.Tag = "FACTURACIONMUESTRASALDOCTACTEIMPRESION"
        Me.chbMuestraSaldoImpresion.Text = "Muestra Saldo en Impresión"
        Me.chbMuestraSaldoImpresion.UseVisualStyleBackColor = True
        '
        'chbImpresionMuestraTotalKilos
        '
        Me.chbImpresionMuestraTotalKilos.AutoSize = True
        Me.chbImpresionMuestraTotalKilos.BindearPropiedadControl = Nothing
        Me.chbImpresionMuestraTotalKilos.BindearPropiedadEntidad = Nothing
        Me.chbImpresionMuestraTotalKilos.ForeColorFocus = System.Drawing.Color.Red
        Me.chbImpresionMuestraTotalKilos.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbImpresionMuestraTotalKilos.IsPK = False
        Me.chbImpresionMuestraTotalKilos.IsRequired = False
        Me.chbImpresionMuestraTotalKilos.Key = Nothing
        Me.chbImpresionMuestraTotalKilos.LabelAsoc = Nothing
        Me.chbImpresionMuestraTotalKilos.Location = New System.Drawing.Point(57, 133)
        Me.chbImpresionMuestraTotalKilos.Name = "chbImpresionMuestraTotalKilos"
        Me.chbImpresionMuestraTotalKilos.Size = New System.Drawing.Size(194, 17)
        Me.chbImpresionMuestraTotalKilos.TabIndex = 6
        Me.chbImpresionMuestraTotalKilos.Text = "Muestra Total de Kilos en Impresión"
        Me.chbImpresionMuestraTotalKilos.UseVisualStyleBackColor = True
        '
        'chbImpresionMuestraTotalProductos
        '
        Me.chbImpresionMuestraTotalProductos.AutoSize = True
        Me.chbImpresionMuestraTotalProductos.BindearPropiedadControl = Nothing
        Me.chbImpresionMuestraTotalProductos.BindearPropiedadEntidad = Nothing
        Me.chbImpresionMuestraTotalProductos.ForeColorFocus = System.Drawing.Color.Red
        Me.chbImpresionMuestraTotalProductos.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbImpresionMuestraTotalProductos.IsPK = False
        Me.chbImpresionMuestraTotalProductos.IsRequired = False
        Me.chbImpresionMuestraTotalProductos.Key = Nothing
        Me.chbImpresionMuestraTotalProductos.LabelAsoc = Nothing
        Me.chbImpresionMuestraTotalProductos.Location = New System.Drawing.Point(57, 156)
        Me.chbImpresionMuestraTotalProductos.Name = "chbImpresionMuestraTotalProductos"
        Me.chbImpresionMuestraTotalProductos.Size = New System.Drawing.Size(212, 17)
        Me.chbImpresionMuestraTotalProductos.TabIndex = 7
        Me.chbImpresionMuestraTotalProductos.Tag = "FACTURACIONMUESTRASALDOCTACTEIMPRESION"
        Me.chbImpresionMuestraTotalProductos.Text = "Muestra Total de Articulos en Impresión"
        Me.chbImpresionMuestraTotalProductos.UseVisualStyleBackColor = True
        '
        'chbImpresionMasivaOrdenInverso
        '
        Me.chbImpresionMasivaOrdenInverso.AutoSize = True
        Me.chbImpresionMasivaOrdenInverso.BindearPropiedadControl = Nothing
        Me.chbImpresionMasivaOrdenInverso.BindearPropiedadEntidad = Nothing
        Me.chbImpresionMasivaOrdenInverso.ForeColorFocus = System.Drawing.Color.Red
        Me.chbImpresionMasivaOrdenInverso.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbImpresionMasivaOrdenInverso.IsPK = False
        Me.chbImpresionMasivaOrdenInverso.IsRequired = False
        Me.chbImpresionMasivaOrdenInverso.Key = Nothing
        Me.chbImpresionMasivaOrdenInverso.LabelAsoc = Nothing
        Me.chbImpresionMasivaOrdenInverso.Location = New System.Drawing.Point(57, 64)
        Me.chbImpresionMasivaOrdenInverso.Name = "chbImpresionMasivaOrdenInverso"
        Me.chbImpresionMasivaOrdenInverso.Size = New System.Drawing.Size(181, 17)
        Me.chbImpresionMasivaOrdenInverso.TabIndex = 2
        Me.chbImpresionMasivaOrdenInverso.Tag = "IMPRESIONMASIVAORDENINVERSO"
        Me.chbImpresionMasivaOrdenInverso.Text = "Impresion Masiva: Orden Inverso"
        Me.chbImpresionMasivaOrdenInverso.UseVisualStyleBackColor = True
        '
        'chbImprimeTicketNoFiscal
        '
        Me.chbImprimeTicketNoFiscal.AutoSize = True
        Me.chbImprimeTicketNoFiscal.BindearPropiedadControl = Nothing
        Me.chbImprimeTicketNoFiscal.BindearPropiedadEntidad = Nothing
        Me.chbImprimeTicketNoFiscal.ForeColorFocus = System.Drawing.Color.Red
        Me.chbImprimeTicketNoFiscal.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbImprimeTicketNoFiscal.IsPK = False
        Me.chbImprimeTicketNoFiscal.IsRequired = False
        Me.chbImprimeTicketNoFiscal.Key = Nothing
        Me.chbImprimeTicketNoFiscal.LabelAsoc = Nothing
        Me.chbImprimeTicketNoFiscal.Location = New System.Drawing.Point(57, 18)
        Me.chbImprimeTicketNoFiscal.Name = "chbImprimeTicketNoFiscal"
        Me.chbImprimeTicketNoFiscal.Size = New System.Drawing.Size(250, 17)
        Me.chbImprimeTicketNoFiscal.TabIndex = 0
        Me.chbImprimeTicketNoFiscal.Tag = "FACTURACIONIMPRIMETICKETNOFISCAL"
        Me.chbImprimeTicketNoFiscal.Text = "Imprime Ticket no Fiscal en Ventas de Cta. Cte."
        Me.chbImprimeTicketNoFiscal.UseVisualStyleBackColor = True
        '
        'chbImpresionMiraOrdenProductos
        '
        Me.chbImpresionMiraOrdenProductos.AutoSize = True
        Me.chbImpresionMiraOrdenProductos.BindearPropiedadControl = Nothing
        Me.chbImpresionMiraOrdenProductos.BindearPropiedadEntidad = Nothing
        Me.chbImpresionMiraOrdenProductos.ForeColorFocus = System.Drawing.Color.Red
        Me.chbImpresionMiraOrdenProductos.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbImpresionMiraOrdenProductos.IsPK = False
        Me.chbImpresionMiraOrdenProductos.IsRequired = False
        Me.chbImpresionMiraOrdenProductos.Key = Nothing
        Me.chbImpresionMiraOrdenProductos.LabelAsoc = Nothing
        Me.chbImpresionMiraOrdenProductos.Location = New System.Drawing.Point(57, 41)
        Me.chbImpresionMiraOrdenProductos.Name = "chbImpresionMiraOrdenProductos"
        Me.chbImpresionMiraOrdenProductos.Size = New System.Drawing.Size(279, 17)
        Me.chbImpresionMiraOrdenProductos.TabIndex = 1
        Me.chbImpresionMiraOrdenProductos.Tag = "FACTURACIONIMPRESIONORDENPRODUCTOS"
        Me.chbImpresionMiraOrdenProductos.Text = "Impresión de Comprobantes mira Orden de productos."
        Me.chbImpresionMiraOrdenProductos.UseVisualStyleBackColor = True
        '
        'chbVentasImpresionVisualizaNroSerie
        '
        Me.chbVentasImpresionVisualizaNroSerie.AutoSize = True
        Me.chbVentasImpresionVisualizaNroSerie.BindearPropiedadControl = Nothing
        Me.chbVentasImpresionVisualizaNroSerie.BindearPropiedadEntidad = Nothing
        Me.chbVentasImpresionVisualizaNroSerie.ForeColorFocus = System.Drawing.Color.Red
        Me.chbVentasImpresionVisualizaNroSerie.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbVentasImpresionVisualizaNroSerie.IsPK = False
        Me.chbVentasImpresionVisualizaNroSerie.IsRequired = False
        Me.chbVentasImpresionVisualizaNroSerie.Key = Nothing
        Me.chbVentasImpresionVisualizaNroSerie.LabelAsoc = Nothing
        Me.chbVentasImpresionVisualizaNroSerie.Location = New System.Drawing.Point(57, 179)
        Me.chbVentasImpresionVisualizaNroSerie.Name = "chbVentasImpresionVisualizaNroSerie"
        Me.chbVentasImpresionVisualizaNroSerie.Size = New System.Drawing.Size(229, 17)
        Me.chbVentasImpresionVisualizaNroSerie.TabIndex = 8
        Me.chbVentasImpresionVisualizaNroSerie.Tag = "VENTASIMPRESIONVISNROSERIE"
        Me.chbVentasImpresionVisualizaNroSerie.Text = "Impresión Comprobante muestra Nros Serie"
        Me.chbVentasImpresionVisualizaNroSerie.UseVisualStyleBackColor = True
        '
        'chbVentasImpresionMuestraLoteObservacion
        '
        Me.chbVentasImpresionMuestraLoteObservacion.AutoSize = True
        Me.chbVentasImpresionMuestraLoteObservacion.BindearPropiedadControl = Nothing
        Me.chbVentasImpresionMuestraLoteObservacion.BindearPropiedadEntidad = Nothing
        Me.chbVentasImpresionMuestraLoteObservacion.ForeColorFocus = System.Drawing.Color.Red
        Me.chbVentasImpresionMuestraLoteObservacion.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbVentasImpresionMuestraLoteObservacion.IsPK = False
        Me.chbVentasImpresionMuestraLoteObservacion.IsRequired = False
        Me.chbVentasImpresionMuestraLoteObservacion.Key = Nothing
        Me.chbVentasImpresionMuestraLoteObservacion.LabelAsoc = Nothing
        Me.chbVentasImpresionMuestraLoteObservacion.Location = New System.Drawing.Point(57, 202)
        Me.chbVentasImpresionMuestraLoteObservacion.Name = "chbVentasImpresionMuestraLoteObservacion"
        Me.chbVentasImpresionMuestraLoteObservacion.Size = New System.Drawing.Size(325, 17)
        Me.chbVentasImpresionMuestraLoteObservacion.TabIndex = 9
        Me.chbVentasImpresionMuestraLoteObservacion.Text = "Al imprimir agregar los lotes de los productos como Observacion"
        Me.chbVentasImpresionMuestraLoteObservacion.UseVisualStyleBackColor = True
        '
        'chbVentasImpresionVisualizaValidezPresupuesto
        '
        Me.chbVentasImpresionVisualizaValidezPresupuesto.AutoSize = True
        Me.chbVentasImpresionVisualizaValidezPresupuesto.BindearPropiedadControl = Nothing
        Me.chbVentasImpresionVisualizaValidezPresupuesto.BindearPropiedadEntidad = Nothing
        Me.chbVentasImpresionVisualizaValidezPresupuesto.ForeColorFocus = System.Drawing.Color.Red
        Me.chbVentasImpresionVisualizaValidezPresupuesto.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbVentasImpresionVisualizaValidezPresupuesto.IsPK = False
        Me.chbVentasImpresionVisualizaValidezPresupuesto.IsRequired = False
        Me.chbVentasImpresionVisualizaValidezPresupuesto.Key = Nothing
        Me.chbVentasImpresionVisualizaValidezPresupuesto.LabelAsoc = Nothing
        Me.chbVentasImpresionVisualizaValidezPresupuesto.Location = New System.Drawing.Point(57, 225)
        Me.chbVentasImpresionVisualizaValidezPresupuesto.Name = "chbVentasImpresionVisualizaValidezPresupuesto"
        Me.chbVentasImpresionVisualizaValidezPresupuesto.Size = New System.Drawing.Size(292, 17)
        Me.chbVentasImpresionVisualizaValidezPresupuesto.TabIndex = 10
        Me.chbVentasImpresionVisualizaValidezPresupuesto.Text = "Visualizar la fecha y Leyenda de validez del presupuesto"
        Me.chbVentasImpresionVisualizaValidezPresupuesto.UseVisualStyleBackColor = True
        '
        'chbMuestraSaldoImpresionUnificado
        '
        Me.chbMuestraSaldoImpresionUnificado.AutoSize = True
        Me.chbMuestraSaldoImpresionUnificado.BindearPropiedadControl = Nothing
        Me.chbMuestraSaldoImpresionUnificado.BindearPropiedadEntidad = Nothing
        Me.chbMuestraSaldoImpresionUnificado.ForeColorFocus = System.Drawing.Color.Red
        Me.chbMuestraSaldoImpresionUnificado.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbMuestraSaldoImpresionUnificado.IsPK = False
        Me.chbMuestraSaldoImpresionUnificado.IsRequired = False
        Me.chbMuestraSaldoImpresionUnificado.Key = Nothing
        Me.chbMuestraSaldoImpresionUnificado.LabelAsoc = Nothing
        Me.chbMuestraSaldoImpresionUnificado.Location = New System.Drawing.Point(220, 111)
        Me.chbMuestraSaldoImpresionUnificado.Name = "chbMuestraSaldoImpresionUnificado"
        Me.chbMuestraSaldoImpresionUnificado.Size = New System.Drawing.Size(71, 17)
        Me.chbMuestraSaldoImpresionUnificado.TabIndex = 5
        Me.chbMuestraSaldoImpresionUnificado.Tag = ""
        Me.chbMuestraSaldoImpresionUnificado.Text = "Unificado"
        Me.chbMuestraSaldoImpresionUnificado.UseVisualStyleBackColor = True
        '
        'chbFacturacionimprimeReciboVentasCtaCte
        '
        Me.chbFacturacionimprimeReciboVentasCtaCte.AutoSize = True
        Me.chbFacturacionimprimeReciboVentasCtaCte.BindearPropiedadControl = Nothing
        Me.chbFacturacionimprimeReciboVentasCtaCte.BindearPropiedadEntidad = Nothing
        Me.chbFacturacionimprimeReciboVentasCtaCte.ForeColorFocus = System.Drawing.Color.Red
        Me.chbFacturacionimprimeReciboVentasCtaCte.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbFacturacionimprimeReciboVentasCtaCte.IsPK = False
        Me.chbFacturacionimprimeReciboVentasCtaCte.IsRequired = False
        Me.chbFacturacionimprimeReciboVentasCtaCte.Key = Nothing
        Me.chbFacturacionimprimeReciboVentasCtaCte.LabelAsoc = Nothing
        Me.chbFacturacionimprimeReciboVentasCtaCte.Location = New System.Drawing.Point(57, 248)
        Me.chbFacturacionimprimeReciboVentasCtaCte.Name = "chbFacturacionimprimeReciboVentasCtaCte"
        Me.chbFacturacionimprimeReciboVentasCtaCte.Size = New System.Drawing.Size(294, 17)
        Me.chbFacturacionimprimeReciboVentasCtaCte.TabIndex = 11
        Me.chbFacturacionimprimeReciboVentasCtaCte.Tag = ""
        Me.chbFacturacionimprimeReciboVentasCtaCte.Text = "Imprimir Recibo si se vende a Cuenta Corriente con pago"
        Me.chbFacturacionimprimeReciboVentasCtaCte.UseVisualStyleBackColor = True
        '
        'chbFacturacionimprimeMuestraHoraVenta
        '
        Me.chbFacturacionimprimeMuestraHoraVenta.AutoSize = True
        Me.chbFacturacionimprimeMuestraHoraVenta.BindearPropiedadControl = Nothing
        Me.chbFacturacionimprimeMuestraHoraVenta.BindearPropiedadEntidad = Nothing
        Me.chbFacturacionimprimeMuestraHoraVenta.ForeColorFocus = System.Drawing.Color.Red
        Me.chbFacturacionimprimeMuestraHoraVenta.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbFacturacionimprimeMuestraHoraVenta.IsPK = False
        Me.chbFacturacionimprimeMuestraHoraVenta.IsRequired = False
        Me.chbFacturacionimprimeMuestraHoraVenta.Key = Nothing
        Me.chbFacturacionimprimeMuestraHoraVenta.LabelAsoc = Nothing
        Me.chbFacturacionimprimeMuestraHoraVenta.Location = New System.Drawing.Point(57, 271)
        Me.chbFacturacionimprimeMuestraHoraVenta.Name = "chbFacturacionimprimeMuestraHoraVenta"
        Me.chbFacturacionimprimeMuestraHoraVenta.Size = New System.Drawing.Size(147, 17)
        Me.chbFacturacionimprimeMuestraHoraVenta.TabIndex = 59
        Me.chbFacturacionimprimeMuestraHoraVenta.Tag = ""
        Me.chbFacturacionimprimeMuestraHoraVenta.Text = "Muestra Hora de la Venta"
        Me.chbFacturacionimprimeMuestraHoraVenta.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.txtCantidadLineasSeparacion)
        Me.GroupBox1.Controls.Add(Me.chbfacturacionImprimeCantidadComponentes)
        Me.GroupBox1.Controls.Add(Me.lblCantidadLineasSeparacion)
        Me.GroupBox1.Controls.Add(Me.chbFacturacionImprimeComponentes)
        Me.GroupBox1.Location = New System.Drawing.Point(57, 300)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(260, 86)
        Me.GroupBox1.TabIndex = 60
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Impresión Fórmula"
        '
        'txtCantidadLineasSeparacion
        '
        Me.txtCantidadLineasSeparacion.BindearPropiedadControl = Nothing
        Me.txtCantidadLineasSeparacion.BindearPropiedadEntidad = Nothing
        Me.txtCantidadLineasSeparacion.ForeColorFocus = System.Drawing.Color.Red
        Me.txtCantidadLineasSeparacion.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtCantidadLineasSeparacion.Formato = "N0"
        Me.txtCantidadLineasSeparacion.IsDecimal = False
        Me.txtCantidadLineasSeparacion.IsNumber = True
        Me.txtCantidadLineasSeparacion.IsPK = False
        Me.txtCantidadLineasSeparacion.IsRequired = False
        Me.txtCantidadLineasSeparacion.Key = ""
        Me.txtCantidadLineasSeparacion.LabelAsoc = Me.lblCantidadLineasSeparacion
        Me.txtCantidadLineasSeparacion.Location = New System.Drawing.Point(195, 56)
        Me.txtCantidadLineasSeparacion.MaxLength = 3
        Me.txtCantidadLineasSeparacion.Name = "txtCantidadLineasSeparacion"
        Me.txtCantidadLineasSeparacion.Size = New System.Drawing.Size(34, 20)
        Me.txtCantidadLineasSeparacion.TabIndex = 62
        Me.txtCantidadLineasSeparacion.Tag = "FACTURACIONIMPRESIONCANTLINEASSEP"
        Me.txtCantidadLineasSeparacion.Text = "1"
        Me.txtCantidadLineasSeparacion.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'lblCantidadLineasSeparacion
        '
        Me.lblCantidadLineasSeparacion.AutoSize = True
        Me.lblCantidadLineasSeparacion.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblCantidadLineasSeparacion.LabelAsoc = Nothing
        Me.lblCantidadLineasSeparacion.Location = New System.Drawing.Point(26, 62)
        Me.lblCantidadLineasSeparacion.Name = "lblCantidadLineasSeparacion"
        Me.lblCantidadLineasSeparacion.Size = New System.Drawing.Size(166, 13)
        Me.lblCantidadLineasSeparacion.TabIndex = 61
        Me.lblCantidadLineasSeparacion.Text = "Cantidad de líneas de separación"
        '
        'chbfacturacionImprimeCantidadComponentes
        '
        Me.chbfacturacionImprimeCantidadComponentes.AutoSize = True
        Me.chbfacturacionImprimeCantidadComponentes.BindearPropiedadControl = Nothing
        Me.chbfacturacionImprimeCantidadComponentes.BindearPropiedadEntidad = Nothing
        Me.chbfacturacionImprimeCantidadComponentes.ForeColorFocus = System.Drawing.Color.Red
        Me.chbfacturacionImprimeCantidadComponentes.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbfacturacionImprimeCantidadComponentes.IsPK = False
        Me.chbfacturacionImprimeCantidadComponentes.IsRequired = False
        Me.chbfacturacionImprimeCantidadComponentes.Key = Nothing
        Me.chbfacturacionImprimeCantidadComponentes.LabelAsoc = Nothing
        Me.chbfacturacionImprimeCantidadComponentes.Location = New System.Drawing.Point(10, 42)
        Me.chbfacturacionImprimeCantidadComponentes.Name = "chbfacturacionImprimeCantidadComponentes"
        Me.chbfacturacionImprimeCantidadComponentes.Size = New System.Drawing.Size(156, 17)
        Me.chbfacturacionImprimeCantidadComponentes.TabIndex = 62
        Me.chbfacturacionImprimeCantidadComponentes.Tag = ""
        Me.chbfacturacionImprimeCantidadComponentes.Text = "Cantidad necesaria Unitaria"
        Me.chbfacturacionImprimeCantidadComponentes.UseVisualStyleBackColor = True
        '
        'chbFacturacionImprimeComponentes
        '
        Me.chbFacturacionImprimeComponentes.AutoSize = True
        Me.chbFacturacionImprimeComponentes.BindearPropiedadControl = Nothing
        Me.chbFacturacionImprimeComponentes.BindearPropiedadEntidad = Nothing
        Me.chbFacturacionImprimeComponentes.ForeColorFocus = System.Drawing.Color.Red
        Me.chbFacturacionImprimeComponentes.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbFacturacionImprimeComponentes.IsPK = False
        Me.chbFacturacionImprimeComponentes.IsRequired = False
        Me.chbFacturacionImprimeComponentes.Key = Nothing
        Me.chbFacturacionImprimeComponentes.LabelAsoc = Nothing
        Me.chbFacturacionImprimeComponentes.Location = New System.Drawing.Point(10, 19)
        Me.chbFacturacionImprimeComponentes.Name = "chbFacturacionImprimeComponentes"
        Me.chbFacturacionImprimeComponentes.Size = New System.Drawing.Size(248, 17)
        Me.chbFacturacionImprimeComponentes.TabIndex = 61
        Me.chbFacturacionImprimeComponentes.Tag = ""
        Me.chbFacturacionImprimeComponentes.Text = "Imprimir Componentes necesarios para producir"
        Me.chbFacturacionImprimeComponentes.UseVisualStyleBackColor = True
        '
        'ucConfVentasImpresion
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.chbFacturacionimprimeMuestraHoraVenta)
        Me.Controls.Add(Me.chbMuestraSaldoImpresionUnificado)
        Me.Controls.Add(Me.chbVentasImpresionVisualizaValidezPresupuesto)
        Me.Controls.Add(Me.chbVentasImpresionMuestraLoteObservacion)
        Me.Controls.Add(Me.chbVentasImpresionVisualizaNroSerie)
        Me.Controls.Add(Me.chbImpresionMiraOrdenProductos)
        Me.Controls.Add(Me.chbImprimeTicketNoFiscal)
        Me.Controls.Add(Me.chbFacturacionimprimeReciboVentasCtaCte)
        Me.Controls.Add(Me.chbImpresionMasivaOrdenInverso)
        Me.Controls.Add(Me.chbImpresionMuestraTotalProductos)
        Me.Controls.Add(Me.chbImpresionMuestraTotalKilos)
        Me.Controls.Add(Me.chbMuestraSaldoImpresion)
        Me.Controls.Add(Me.txtFacturacionMargenIzquierdo)
        Me.Controls.Add(Me.txtFacturacionMargenDerecho)
        Me.Controls.Add(Me.lblMargenIzquierdo)
        Me.Controls.Add(Me.lblMargenDerecho)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.chbMuestraVendedorImpresion)
        Me.Name = "ucConfVentasImpresion"
        Me.Controls.SetChildIndex(Me.chbMuestraVendedorImpresion, 0)
        Me.Controls.SetChildIndex(Me.Label2, 0)
        Me.Controls.SetChildIndex(Me.Label1, 0)
        Me.Controls.SetChildIndex(Me.lblMargenDerecho, 0)
        Me.Controls.SetChildIndex(Me.lblMargenIzquierdo, 0)
        Me.Controls.SetChildIndex(Me.txtFacturacionMargenDerecho, 0)
        Me.Controls.SetChildIndex(Me.txtFacturacionMargenIzquierdo, 0)
        Me.Controls.SetChildIndex(Me.chbMuestraSaldoImpresion, 0)
        Me.Controls.SetChildIndex(Me.chbImpresionMuestraTotalKilos, 0)
        Me.Controls.SetChildIndex(Me.chbImpresionMuestraTotalProductos, 0)
        Me.Controls.SetChildIndex(Me.chbImpresionMasivaOrdenInverso, 0)
        Me.Controls.SetChildIndex(Me.chbFacturacionimprimeReciboVentasCtaCte, 0)
        Me.Controls.SetChildIndex(Me.chbImprimeTicketNoFiscal, 0)
        Me.Controls.SetChildIndex(Me.chbImpresionMiraOrdenProductos, 0)
        Me.Controls.SetChildIndex(Me.chbVentasImpresionVisualizaNroSerie, 0)
        Me.Controls.SetChildIndex(Me.chbVentasImpresionMuestraLoteObservacion, 0)
        Me.Controls.SetChildIndex(Me.chbVentasImpresionVisualizaValidezPresupuesto, 0)
        Me.Controls.SetChildIndex(Me.chbMuestraSaldoImpresionUnificado, 0)
        Me.Controls.SetChildIndex(Me.chbFacturacionimprimeMuestraHoraVenta, 0)
        Me.Controls.SetChildIndex(Me.GroupBox1, 0)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents chbMuestraVendedorImpresion As Controles.CheckBox
   Friend WithEvents Label2 As Controles.Label
   Friend WithEvents Label1 As Controles.Label
   Friend WithEvents lblMargenDerecho As Controles.Label
   Friend WithEvents lblMargenIzquierdo As Controles.Label
   Friend WithEvents txtFacturacionMargenDerecho As Controles.TextBox
   Friend WithEvents txtFacturacionMargenIzquierdo As Controles.TextBox
   Friend WithEvents chbMuestraSaldoImpresion As Controles.CheckBox
   Friend WithEvents chbImpresionMuestraTotalKilos As Controles.CheckBox
   Friend WithEvents chbImpresionMuestraTotalProductos As Controles.CheckBox
   Friend WithEvents chbImpresionMasivaOrdenInverso As Controles.CheckBox
   Friend WithEvents chbImprimeTicketNoFiscal As Controles.CheckBox
   Friend WithEvents chbImpresionMiraOrdenProductos As Controles.CheckBox
   Friend WithEvents chbVentasImpresionVisualizaNroSerie As Controles.CheckBox
   Friend WithEvents chbVentasImpresionMuestraLoteObservacion As Controles.CheckBox
    Friend WithEvents chbVentasImpresionVisualizaValidezPresupuesto As Controles.CheckBox
	Friend WithEvents chbMuestraSaldoImpresionUnificado As Controles.CheckBox
    Friend WithEvents chbFacturacionimprimeReciboVentasCtaCte As Controles.CheckBox
    Friend WithEvents chbFacturacionimprimeMuestraHoraVenta As Controles.CheckBox
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents txtCantidadLineasSeparacion As Controles.TextBox
    Friend WithEvents lblCantidadLineasSeparacion As Controles.Label
    Friend WithEvents chbfacturacionImprimeCantidadComponentes As Controles.CheckBox
    Friend WithEvents chbFacturacionImprimeComponentes As Controles.CheckBox
End Class
