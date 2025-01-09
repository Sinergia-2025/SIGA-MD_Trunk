<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ucConfVentasFacturacionRapida
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
      Me.chbFacturacionRapidaAgrupaProductos = New Eniac.Controles.CheckBox()
      Me.chbFacturacionImpresionFiscalSincronica = New Eniac.Controles.CheckBox()
      Me.grbFacturacionPagoTarjetaTeclaRapidaF3 = New System.Windows.Forms.GroupBox()
      Me.lblTarBanco = New Eniac.Controles.Label()
      Me.bscFacturacionCodigoBancoTarjeta = New Eniac.Controles.Buscador()
      Me.lblTarBancoNombre = New Eniac.Controles.Label()
      Me.cmbFacturacionContadoTarjeta = New Eniac.Controles.ComboBox()
      Me.lblTarTarjeta = New Eniac.Controles.Label()
      Me.chbFacturacionContadoEsEnTarjeta = New Eniac.Controles.CheckBox()
      Me.bscFacturacionBancoTarjeta = New Eniac.Controles.Buscador()
      Me.chbFacturacionRapidaModifDescRecGralPorc = New Eniac.Controles.CheckBox()
      Me.chbFactRapidaAbrirCajaCompNoFiscal = New Eniac.Controles.CheckBox()
      Me.chbFacturacionRapidaSolicitaCantidad = New Eniac.Controles.CheckBox()
      Me.chbFacturacionRapidaReempComp = New Eniac.Controles.CheckBox()
        Me.chbPermiteModificarCliente = New Eniac.Controles.CheckBox()
        Me.grbFacturacionPagoTarjetaTeclaRapidaF3.SuspendLayout()
        Me.SuspendLayout()
        '
        'chbFacturacionRapidaAgrupaProductos
        '
        Me.chbFacturacionRapidaAgrupaProductos.AutoSize = True
        Me.chbFacturacionRapidaAgrupaProductos.BindearPropiedadControl = Nothing
        Me.chbFacturacionRapidaAgrupaProductos.BindearPropiedadEntidad = Nothing
        Me.chbFacturacionRapidaAgrupaProductos.ForeColorFocus = System.Drawing.Color.Red
        Me.chbFacturacionRapidaAgrupaProductos.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbFacturacionRapidaAgrupaProductos.IsPK = False
        Me.chbFacturacionRapidaAgrupaProductos.IsRequired = False
        Me.chbFacturacionRapidaAgrupaProductos.Key = Nothing
        Me.chbFacturacionRapidaAgrupaProductos.LabelAsoc = Nothing
        Me.chbFacturacionRapidaAgrupaProductos.Location = New System.Drawing.Point(35, 144)
        Me.chbFacturacionRapidaAgrupaProductos.Name = "chbFacturacionRapidaAgrupaProductos"
        Me.chbFacturacionRapidaAgrupaProductos.Size = New System.Drawing.Size(304, 17)
        Me.chbFacturacionRapidaAgrupaProductos.TabIndex = 5
        Me.chbFacturacionRapidaAgrupaProductos.Text = "Facturación Rápida agrupa productos con el mismo código"
        Me.chbFacturacionRapidaAgrupaProductos.UseVisualStyleBackColor = True
        '
        'chbFacturacionImpresionFiscalSincronica
        '
        Me.chbFacturacionImpresionFiscalSincronica.AutoSize = True
        Me.chbFacturacionImpresionFiscalSincronica.BindearPropiedadControl = Nothing
        Me.chbFacturacionImpresionFiscalSincronica.BindearPropiedadEntidad = Nothing
        Me.chbFacturacionImpresionFiscalSincronica.ForeColorFocus = System.Drawing.Color.Red
        Me.chbFacturacionImpresionFiscalSincronica.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbFacturacionImpresionFiscalSincronica.IsPK = False
        Me.chbFacturacionImpresionFiscalSincronica.IsRequired = False
        Me.chbFacturacionImpresionFiscalSincronica.Key = Nothing
        Me.chbFacturacionImpresionFiscalSincronica.LabelAsoc = Nothing
        Me.chbFacturacionImpresionFiscalSincronica.Location = New System.Drawing.Point(35, 121)
        Me.chbFacturacionImpresionFiscalSincronica.Name = "chbFacturacionImpresionFiscalSincronica"
        Me.chbFacturacionImpresionFiscalSincronica.Size = New System.Drawing.Size(225, 17)
        Me.chbFacturacionImpresionFiscalSincronica.TabIndex = 4
        Me.chbFacturacionImpresionFiscalSincronica.Tag = "FACTURACIONIMPRESIONFISCALSINCRONICA"
        Me.chbFacturacionImpresionFiscalSincronica.Text = "Facturación - Impresión Fiscal (Sincrónica)"
        Me.chbFacturacionImpresionFiscalSincronica.UseVisualStyleBackColor = True
        '
        'grbFacturacionPagoTarjetaTeclaRapidaF3
        '
        Me.grbFacturacionPagoTarjetaTeclaRapidaF3.Controls.Add(Me.lblTarBanco)
        Me.grbFacturacionPagoTarjetaTeclaRapidaF3.Controls.Add(Me.bscFacturacionCodigoBancoTarjeta)
        Me.grbFacturacionPagoTarjetaTeclaRapidaF3.Controls.Add(Me.cmbFacturacionContadoTarjeta)
        Me.grbFacturacionPagoTarjetaTeclaRapidaF3.Controls.Add(Me.lblTarTarjeta)
        Me.grbFacturacionPagoTarjetaTeclaRapidaF3.Controls.Add(Me.chbFacturacionContadoEsEnTarjeta)
        Me.grbFacturacionPagoTarjetaTeclaRapidaF3.Controls.Add(Me.bscFacturacionBancoTarjeta)
        Me.grbFacturacionPagoTarjetaTeclaRapidaF3.Controls.Add(Me.lblTarBancoNombre)
        Me.grbFacturacionPagoTarjetaTeclaRapidaF3.Location = New System.Drawing.Point(406, 29)
        Me.grbFacturacionPagoTarjetaTeclaRapidaF3.Name = "grbFacturacionPagoTarjetaTeclaRapidaF3"
        Me.grbFacturacionPagoTarjetaTeclaRapidaF3.Size = New System.Drawing.Size(460, 69)
        Me.grbFacturacionPagoTarjetaTeclaRapidaF3.TabIndex = 7
        Me.grbFacturacionPagoTarjetaTeclaRapidaF3.TabStop = False
        '
        'lblTarBanco
        '
        Me.lblTarBanco.AutoSize = True
        Me.lblTarBanco.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblTarBanco.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblTarBanco.LabelAsoc = Nothing
        Me.lblTarBanco.Location = New System.Drawing.Point(163, 23)
        Me.lblTarBanco.Name = "lblTarBanco"
        Me.lblTarBanco.Size = New System.Drawing.Size(38, 13)
        Me.lblTarBanco.TabIndex = 3
        Me.lblTarBanco.Text = "Banco"
        '
        'bscFacturacionCodigoBancoTarjeta
        '
        Me.bscFacturacionCodigoBancoTarjeta.AyudaAncho = 608
        Me.bscFacturacionCodigoBancoTarjeta.BindearPropiedadControl = Nothing
        Me.bscFacturacionCodigoBancoTarjeta.BindearPropiedadEntidad = Nothing
        Me.bscFacturacionCodigoBancoTarjeta.ColumnasAlineacion = Nothing
        Me.bscFacturacionCodigoBancoTarjeta.ColumnasAncho = Nothing
        Me.bscFacturacionCodigoBancoTarjeta.ColumnasFormato = Nothing
        Me.bscFacturacionCodigoBancoTarjeta.ColumnasOcultas = Nothing
        Me.bscFacturacionCodigoBancoTarjeta.ColumnasTitulos = Nothing
        Me.bscFacturacionCodigoBancoTarjeta.Datos = Nothing
        Me.bscFacturacionCodigoBancoTarjeta.Enabled = False
        Me.bscFacturacionCodigoBancoTarjeta.FilaDevuelta = Nothing
        Me.bscFacturacionCodigoBancoTarjeta.ForeColorFocus = System.Drawing.Color.Red
        Me.bscFacturacionCodigoBancoTarjeta.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.bscFacturacionCodigoBancoTarjeta.IsDecimal = False
        Me.bscFacturacionCodigoBancoTarjeta.IsNumber = False
        Me.bscFacturacionCodigoBancoTarjeta.IsPK = False
        Me.bscFacturacionCodigoBancoTarjeta.IsRequired = False
        Me.bscFacturacionCodigoBancoTarjeta.Key = ""
        Me.bscFacturacionCodigoBancoTarjeta.LabelAsoc = Me.lblTarBancoNombre
        Me.bscFacturacionCodigoBancoTarjeta.Location = New System.Drawing.Point(166, 38)
        Me.bscFacturacionCodigoBancoTarjeta.MaxLengh = "32767"
        Me.bscFacturacionCodigoBancoTarjeta.Name = "bscFacturacionCodigoBancoTarjeta"
        Me.bscFacturacionCodigoBancoTarjeta.Permitido = True
        Me.bscFacturacionCodigoBancoTarjeta.Selecciono = False
        Me.bscFacturacionCodigoBancoTarjeta.Size = New System.Drawing.Size(82, 20)
        Me.bscFacturacionCodigoBancoTarjeta.TabIndex = 4
        Me.bscFacturacionCodigoBancoTarjeta.Titulo = Nothing
        '
        'lblTarBancoNombre
        '
        Me.lblTarBancoNombre.AutoSize = True
        Me.lblTarBancoNombre.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblTarBancoNombre.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblTarBancoNombre.LabelAsoc = Nothing
        Me.lblTarBancoNombre.Location = New System.Drawing.Point(251, 23)
        Me.lblTarBancoNombre.Name = "lblTarBancoNombre"
        Me.lblTarBancoNombre.Size = New System.Drawing.Size(78, 13)
        Me.lblTarBancoNombre.TabIndex = 5
        Me.lblTarBancoNombre.Text = "Nombre Banco"
        '
        'cmbFacturacionContadoTarjeta
        '
        Me.cmbFacturacionContadoTarjeta.BindearPropiedadControl = ""
        Me.cmbFacturacionContadoTarjeta.BindearPropiedadEntidad = ""
        Me.cmbFacturacionContadoTarjeta.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbFacturacionContadoTarjeta.Enabled = False
        Me.cmbFacturacionContadoTarjeta.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbFacturacionContadoTarjeta.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbFacturacionContadoTarjeta.FormattingEnabled = True
        Me.cmbFacturacionContadoTarjeta.IsPK = False
        Me.cmbFacturacionContadoTarjeta.IsRequired = False
        Me.cmbFacturacionContadoTarjeta.Key = Nothing
        Me.cmbFacturacionContadoTarjeta.LabelAsoc = Me.lblTarTarjeta
        Me.cmbFacturacionContadoTarjeta.Location = New System.Drawing.Point(13, 38)
        Me.cmbFacturacionContadoTarjeta.Name = "cmbFacturacionContadoTarjeta"
        Me.cmbFacturacionContadoTarjeta.Size = New System.Drawing.Size(147, 21)
        Me.cmbFacturacionContadoTarjeta.TabIndex = 2
        '
        'lblTarTarjeta
        '
        Me.lblTarTarjeta.AutoSize = True
        Me.lblTarTarjeta.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblTarTarjeta.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblTarTarjeta.LabelAsoc = Nothing
        Me.lblTarTarjeta.Location = New System.Drawing.Point(10, 24)
        Me.lblTarTarjeta.Name = "lblTarTarjeta"
        Me.lblTarTarjeta.Size = New System.Drawing.Size(40, 13)
        Me.lblTarTarjeta.TabIndex = 1
        Me.lblTarTarjeta.Text = "Tarjeta"
        '
        'chbFacturacionContadoEsEnTarjeta
        '
        Me.chbFacturacionContadoEsEnTarjeta.BindearPropiedadControl = Nothing
        Me.chbFacturacionContadoEsEnTarjeta.BindearPropiedadEntidad = Nothing
        Me.chbFacturacionContadoEsEnTarjeta.ForeColorFocus = System.Drawing.Color.Red
        Me.chbFacturacionContadoEsEnTarjeta.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbFacturacionContadoEsEnTarjeta.IsPK = False
        Me.chbFacturacionContadoEsEnTarjeta.IsRequired = False
        Me.chbFacturacionContadoEsEnTarjeta.Key = Nothing
        Me.chbFacturacionContadoEsEnTarjeta.LabelAsoc = Nothing
        Me.chbFacturacionContadoEsEnTarjeta.Location = New System.Drawing.Point(13, -4)
        Me.chbFacturacionContadoEsEnTarjeta.Name = "chbFacturacionContadoEsEnTarjeta"
        Me.chbFacturacionContadoEsEnTarjeta.Size = New System.Drawing.Size(317, 24)
        Me.chbFacturacionContadoEsEnTarjeta.TabIndex = 0
        Me.chbFacturacionContadoEsEnTarjeta.Tag = ""
        Me.chbFacturacionContadoEsEnTarjeta.Text = "Facturación permite cobro con tarjeta automáticamente (F3)"
        Me.chbFacturacionContadoEsEnTarjeta.UseVisualStyleBackColor = True
        '
        'bscFacturacionBancoTarjeta
        '
        Me.bscFacturacionBancoTarjeta.AyudaAncho = 608
        Me.bscFacturacionBancoTarjeta.BindearPropiedadControl = Nothing
        Me.bscFacturacionBancoTarjeta.BindearPropiedadEntidad = Nothing
        Me.bscFacturacionBancoTarjeta.ColumnasAlineacion = Nothing
        Me.bscFacturacionBancoTarjeta.ColumnasAncho = Nothing
        Me.bscFacturacionBancoTarjeta.ColumnasFormato = Nothing
        Me.bscFacturacionBancoTarjeta.ColumnasOcultas = Nothing
        Me.bscFacturacionBancoTarjeta.ColumnasTitulos = Nothing
        Me.bscFacturacionBancoTarjeta.Datos = Nothing
        Me.bscFacturacionBancoTarjeta.Enabled = False
        Me.bscFacturacionBancoTarjeta.FilaDevuelta = Nothing
        Me.bscFacturacionBancoTarjeta.ForeColorFocus = System.Drawing.Color.Red
        Me.bscFacturacionBancoTarjeta.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.bscFacturacionBancoTarjeta.IsDecimal = False
        Me.bscFacturacionBancoTarjeta.IsNumber = False
        Me.bscFacturacionBancoTarjeta.IsPK = False
        Me.bscFacturacionBancoTarjeta.IsRequired = False
        Me.bscFacturacionBancoTarjeta.Key = ""
        Me.bscFacturacionBancoTarjeta.LabelAsoc = Me.lblTarBancoNombre
        Me.bscFacturacionBancoTarjeta.Location = New System.Drawing.Point(254, 38)
        Me.bscFacturacionBancoTarjeta.MaxLengh = "32767"
        Me.bscFacturacionBancoTarjeta.Name = "bscFacturacionBancoTarjeta"
        Me.bscFacturacionBancoTarjeta.Permitido = True
        Me.bscFacturacionBancoTarjeta.Selecciono = False
        Me.bscFacturacionBancoTarjeta.Size = New System.Drawing.Size(193, 20)
        Me.bscFacturacionBancoTarjeta.TabIndex = 6
        Me.bscFacturacionBancoTarjeta.Titulo = Nothing
        '
        'chbFacturacionRapidaModifDescRecGralPorc
        '
        Me.chbFacturacionRapidaModifDescRecGralPorc.AutoSize = True
        Me.chbFacturacionRapidaModifDescRecGralPorc.BindearPropiedadControl = Nothing
        Me.chbFacturacionRapidaModifDescRecGralPorc.BindearPropiedadEntidad = Nothing
        Me.chbFacturacionRapidaModifDescRecGralPorc.ForeColorFocus = System.Drawing.Color.Red
        Me.chbFacturacionRapidaModifDescRecGralPorc.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbFacturacionRapidaModifDescRecGralPorc.IsPK = False
        Me.chbFacturacionRapidaModifDescRecGralPorc.IsRequired = False
        Me.chbFacturacionRapidaModifDescRecGralPorc.Key = Nothing
        Me.chbFacturacionRapidaModifDescRecGralPorc.LabelAsoc = Nothing
        Me.chbFacturacionRapidaModifDescRecGralPorc.Location = New System.Drawing.Point(35, 98)
        Me.chbFacturacionRapidaModifDescRecGralPorc.Name = "chbFacturacionRapidaModifDescRecGralPorc"
        Me.chbFacturacionRapidaModifDescRecGralPorc.Size = New System.Drawing.Size(258, 17)
        Me.chbFacturacionRapidaModifDescRecGralPorc.TabIndex = 3
        Me.chbFacturacionRapidaModifDescRecGralPorc.Tag = ""
        Me.chbFacturacionRapidaModifDescRecGralPorc.Text = "Permite modificar el Descuento/Recargo General"
        Me.chbFacturacionRapidaModifDescRecGralPorc.UseVisualStyleBackColor = True
        '
        'chbFactRapidaAbrirCajaCompNoFiscal
        '
        Me.chbFactRapidaAbrirCajaCompNoFiscal.AutoSize = True
        Me.chbFactRapidaAbrirCajaCompNoFiscal.BindearPropiedadControl = Nothing
        Me.chbFactRapidaAbrirCajaCompNoFiscal.BindearPropiedadEntidad = Nothing
        Me.chbFactRapidaAbrirCajaCompNoFiscal.Checked = True
        Me.chbFactRapidaAbrirCajaCompNoFiscal.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chbFactRapidaAbrirCajaCompNoFiscal.ForeColorFocus = System.Drawing.Color.Red
        Me.chbFactRapidaAbrirCajaCompNoFiscal.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbFactRapidaAbrirCajaCompNoFiscal.IsPK = False
        Me.chbFactRapidaAbrirCajaCompNoFiscal.IsRequired = False
        Me.chbFactRapidaAbrirCajaCompNoFiscal.Key = Nothing
        Me.chbFactRapidaAbrirCajaCompNoFiscal.LabelAsoc = Nothing
        Me.chbFactRapidaAbrirCajaCompNoFiscal.Location = New System.Drawing.Point(35, 29)
        Me.chbFactRapidaAbrirCajaCompNoFiscal.Name = "chbFactRapidaAbrirCajaCompNoFiscal"
        Me.chbFactRapidaAbrirCajaCompNoFiscal.Size = New System.Drawing.Size(300, 17)
        Me.chbFactRapidaAbrirCajaCompNoFiscal.TabIndex = 0
        Me.chbFactRapidaAbrirCajaCompNoFiscal.Tag = "FACTURACIONABRIRCAJACOMPNOFISCAL"
        Me.chbFactRapidaAbrirCajaCompNoFiscal.Text = "Facturación Rapida Abrir caja con Comprobante No Fiscal"
        Me.chbFactRapidaAbrirCajaCompNoFiscal.UseVisualStyleBackColor = True
        '
        'chbFacturacionRapidaSolicitaCantidad
        '
        Me.chbFacturacionRapidaSolicitaCantidad.AutoSize = True
        Me.chbFacturacionRapidaSolicitaCantidad.BindearPropiedadControl = Nothing
        Me.chbFacturacionRapidaSolicitaCantidad.BindearPropiedadEntidad = Nothing
        Me.chbFacturacionRapidaSolicitaCantidad.ForeColorFocus = System.Drawing.Color.Red
        Me.chbFacturacionRapidaSolicitaCantidad.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbFacturacionRapidaSolicitaCantidad.IsPK = False
        Me.chbFacturacionRapidaSolicitaCantidad.IsRequired = False
        Me.chbFacturacionRapidaSolicitaCantidad.Key = Nothing
        Me.chbFacturacionRapidaSolicitaCantidad.LabelAsoc = Nothing
        Me.chbFacturacionRapidaSolicitaCantidad.Location = New System.Drawing.Point(35, 75)
        Me.chbFacturacionRapidaSolicitaCantidad.Name = "chbFacturacionRapidaSolicitaCantidad"
        Me.chbFacturacionRapidaSolicitaCantidad.Size = New System.Drawing.Size(201, 17)
        Me.chbFacturacionRapidaSolicitaCantidad.TabIndex = 2
        Me.chbFacturacionRapidaSolicitaCantidad.Text = "Facturación Rápida Solicita Cantidad"
        Me.chbFacturacionRapidaSolicitaCantidad.UseVisualStyleBackColor = True
        '
        'chbFacturacionRapidaReempComp
        '
        Me.chbFacturacionRapidaReempComp.AutoSize = True
        Me.chbFacturacionRapidaReempComp.BindearPropiedadControl = Nothing
        Me.chbFacturacionRapidaReempComp.BindearPropiedadEntidad = Nothing
        Me.chbFacturacionRapidaReempComp.ForeColorFocus = System.Drawing.Color.Red
        Me.chbFacturacionRapidaReempComp.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbFacturacionRapidaReempComp.IsPK = False
        Me.chbFacturacionRapidaReempComp.IsRequired = False
        Me.chbFacturacionRapidaReempComp.Key = Nothing
        Me.chbFacturacionRapidaReempComp.LabelAsoc = Nothing
        Me.chbFacturacionRapidaReempComp.Location = New System.Drawing.Point(35, 52)
        Me.chbFacturacionRapidaReempComp.Name = "chbFacturacionRapidaReempComp"
        Me.chbFacturacionRapidaReempComp.Size = New System.Drawing.Size(275, 17)
        Me.chbFacturacionRapidaReempComp.TabIndex = 1
        Me.chbFacturacionRapidaReempComp.Tag = "FACTURACIONRAPIDAREEMPLAZARCOMP"
        Me.chbFacturacionRapidaReempComp.Text = "Utiliza Reemplazar Comprobantes Facturación rápida"
        Me.chbFacturacionRapidaReempComp.UseVisualStyleBackColor = True
        '
        'chbPermiteModificarCliente
        '
        Me.chbPermiteModificarCliente.AutoSize = True
        Me.chbPermiteModificarCliente.BindearPropiedadControl = Nothing
        Me.chbPermiteModificarCliente.BindearPropiedadEntidad = Nothing
        Me.chbPermiteModificarCliente.ForeColorFocus = System.Drawing.Color.Red
        Me.chbPermiteModificarCliente.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbPermiteModificarCliente.IsPK = False
        Me.chbPermiteModificarCliente.IsRequired = False
        Me.chbPermiteModificarCliente.Key = Nothing
        Me.chbPermiteModificarCliente.LabelAsoc = Nothing
        Me.chbPermiteModificarCliente.Location = New System.Drawing.Point(35, 167)
        Me.chbPermiteModificarCliente.Name = "chbPermiteModificarCliente"
        Me.chbPermiteModificarCliente.Size = New System.Drawing.Size(216, 17)
        Me.chbPermiteModificarCliente.TabIndex = 6
        Me.chbPermiteModificarCliente.Tag = "FACTURACIONPERMITEMODIFICARCLIENTE"
        Me.chbPermiteModificarCliente.Text = "Permite Modificar Cliente en Facturación"
        Me.chbPermiteModificarCliente.UseVisualStyleBackColor = True
        '
        'ucConfVentasFacturacionRapida
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.chbPermiteModificarCliente)
        Me.Controls.Add(Me.chbFacturacionRapidaAgrupaProductos)
        Me.Controls.Add(Me.chbFacturacionImpresionFiscalSincronica)
        Me.Controls.Add(Me.grbFacturacionPagoTarjetaTeclaRapidaF3)
        Me.Controls.Add(Me.chbFacturacionRapidaModifDescRecGralPorc)
        Me.Controls.Add(Me.chbFactRapidaAbrirCajaCompNoFiscal)
        Me.Controls.Add(Me.chbFacturacionRapidaSolicitaCantidad)
        Me.Controls.Add(Me.chbFacturacionRapidaReempComp)
        Me.Name = "ucConfVentasFacturacionRapida"
        Me.Controls.SetChildIndex(Me.chbFacturacionRapidaReempComp, 0)
        Me.Controls.SetChildIndex(Me.chbFacturacionRapidaSolicitaCantidad, 0)
        Me.Controls.SetChildIndex(Me.chbFactRapidaAbrirCajaCompNoFiscal, 0)
        Me.Controls.SetChildIndex(Me.chbFacturacionRapidaModifDescRecGralPorc, 0)
        Me.Controls.SetChildIndex(Me.grbFacturacionPagoTarjetaTeclaRapidaF3, 0)
        Me.Controls.SetChildIndex(Me.chbFacturacionImpresionFiscalSincronica, 0)
        Me.Controls.SetChildIndex(Me.chbFacturacionRapidaAgrupaProductos, 0)
        Me.Controls.SetChildIndex(Me.chbPermiteModificarCliente, 0)
        Me.grbFacturacionPagoTarjetaTeclaRapidaF3.ResumeLayout(False)
        Me.grbFacturacionPagoTarjetaTeclaRapidaF3.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents chbFacturacionRapidaAgrupaProductos As Controles.CheckBox
   Friend WithEvents chbFacturacionImpresionFiscalSincronica As Controles.CheckBox
   Friend WithEvents grbFacturacionPagoTarjetaTeclaRapidaF3 As GroupBox
   Friend WithEvents lblTarBanco As Controles.Label
   Friend WithEvents bscFacturacionCodigoBancoTarjeta As Controles.Buscador
   Friend WithEvents lblTarBancoNombre As Controles.Label
   Friend WithEvents cmbFacturacionContadoTarjeta As Controles.ComboBox
   Friend WithEvents lblTarTarjeta As Controles.Label
   Friend WithEvents chbFacturacionContadoEsEnTarjeta As Controles.CheckBox
   Friend WithEvents bscFacturacionBancoTarjeta As Controles.Buscador
   Friend WithEvents chbFacturacionRapidaModifDescRecGralPorc As Controles.CheckBox
   Friend WithEvents chbFactRapidaAbrirCajaCompNoFiscal As Controles.CheckBox
   Friend WithEvents chbFacturacionRapidaSolicitaCantidad As Controles.CheckBox
   Friend WithEvents chbFacturacionRapidaReempComp As Controles.CheckBox
    Friend WithEvents chbPermiteModificarCliente As Controles.CheckBox
End Class
