<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ucConfPrecios
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
      Me.chbMuestraFechaActualiza = New Eniac.Controles.CheckBox()
      Me.grbModificarPrecioPorArribaPrecioLista = New System.Windows.Forms.GroupBox()
      Me.Label28 = New Eniac.Controles.Label()
      Me.txtPorcentajePrecioPorArribaPL = New Eniac.Controles.TextBox()
      Me.lblPorcentajePrecioPorArribaPL = New Eniac.Controles.Label()
      Me.rbtPrecioPorArribaAvisaryPermitir = New System.Windows.Forms.RadioButton()
      Me.rbtPrecioPorArribaNoPermitir = New System.Windows.Forms.RadioButton()
      Me.rbtPrecioPorArribaPermitir = New System.Windows.Forms.RadioButton()
      Me.grbModificarPrecioPorDebajoPrecioLista = New System.Windows.Forms.GroupBox()
      Me.Label27 = New Eniac.Controles.Label()
      Me.txtPorcentajePrecioPorDebajoPL = New Eniac.Controles.TextBox()
      Me.lblPorcentajePrecioPorDebajoPL = New Eniac.Controles.Label()
      Me.rbtPrecioPorDebajoAvisaryPermitir = New System.Windows.Forms.RadioButton()
      Me.rbtPrecioPorDebajoNoPermitir = New System.Windows.Forms.RadioButton()
      Me.rbtPrecioPorDebajoPermitir = New System.Windows.Forms.RadioButton()
      Me.lblMonedaParaConsultarPrecios = New Eniac.Controles.Label()
      Me.grpPreciosPriorizaCodigoYDescripcion = New System.Windows.Forms.GroupBox()
      Me.pnlCodigoDescripcion = New System.Windows.Forms.FlowLayoutPanel()
      Me.radCodigoYDescripcion = New System.Windows.Forms.RadioButton()
      Me.radCodigoODescripcion = New System.Windows.Forms.RadioButton()
      Me.chbActualizaPrecioCostoPorTipoDeCambio = New Eniac.Controles.CheckBox()
      Me.lblListaDePreciosPredeterminada = New Eniac.Controles.Label()
      Me.chbMarcarTodos = New Eniac.Controles.CheckBox()
      Me.grbFTP = New System.Windows.Forms.GroupBox()
      Me.chbFTPUtilizaCarpetaSecundaria = New Eniac.Controles.CheckBox()
      Me.txtFTPCarpetaRemota = New Eniac.Controles.TextBox()
      Me.lblCarpetaRemota = New Eniac.Controles.Label()
      Me.cmbFTPFormato = New Eniac.Controles.ComboBox()
      Me.lblFTPFormato = New Eniac.Controles.Label()
      Me.txtFTPNombreArchivo = New Eniac.Controles.TextBox()
      Me.lblFTPNombreArchivo = New Eniac.Controles.Label()
      Me.Button1 = New Eniac.Controles.Button()
      Me.chbFTPConexionPasiva = New Eniac.Controles.CheckBox()
      Me.txtFTPPassword = New Eniac.Controles.TextBox()
      Me.lblFTPPassword = New Eniac.Controles.Label()
      Me.txtFTPUsuario = New Eniac.Controles.TextBox()
      Me.lblFTPUsuario = New Eniac.Controles.Label()
      Me.txtFTPServidor = New Eniac.Controles.TextBox()
      Me.lblFTPServidor = New Eniac.Controles.Label()
      Me.grbActualizarPreciosCalculo = New System.Windows.Forms.GroupBox()
      Me.rbtDesdeFormula = New System.Windows.Forms.RadioButton()
      Me.rbtSobreCosto = New System.Windows.Forms.RadioButton()
      Me.rbtSobreVenta = New System.Windows.Forms.RadioButton()
      Me.rbtPorcActual = New System.Windows.Forms.RadioButton()
      Me.txtCantidadDecimalesEnVenta = New Eniac.Controles.TextBox()
      Me.lblCantidadDecimalesEnVenta = New Eniac.Controles.Label()
      Me.txtCotizacionDolar = New Eniac.Controles.TextBox()
      Me.lblCotizacionDolar = New Eniac.Controles.Label()
      Me.chbActualizarPreciosMostrarCodigoProductoProveedor = New Eniac.Controles.CheckBox()
      Me.chbConsultarPreciosProdNoAfectanStock = New Eniac.Controles.CheckBox()
      Me.chbConsultarPreciosConEmbalaje = New Eniac.Controles.CheckBox()
      Me.chbPreciosUnificarEntreSucursales = New Eniac.Controles.CheckBox()
      Me.chbConsultarPreciosConIVA = New Eniac.Controles.CheckBox()
      Me.chbUtilizaPrecioDeCompra = New Eniac.Controles.CheckBox()
      Me.cmbMonedaParaConsultarPrecios = New Eniac.Controles.ComboBox()
      Me.cmbListaDePreciosPredeterminada = New Eniac.Controles.ComboBox()
        Me.grbModificarPrecioPorArribaPrecioLista.SuspendLayout()
        Me.grbModificarPrecioPorDebajoPrecioLista.SuspendLayout()
        Me.grpPreciosPriorizaCodigoYDescripcion.SuspendLayout()
        Me.pnlCodigoDescripcion.SuspendLayout()
        Me.grbFTP.SuspendLayout()
        Me.grbActualizarPreciosCalculo.SuspendLayout()
        Me.SuspendLayout()
        '
        'chbMuestraFechaActualiza
        '
        Me.chbMuestraFechaActualiza.AutoSize = True
        Me.chbMuestraFechaActualiza.BindearPropiedadControl = Nothing
        Me.chbMuestraFechaActualiza.BindearPropiedadEntidad = Nothing
        Me.chbMuestraFechaActualiza.ForeColorFocus = System.Drawing.Color.Red
        Me.chbMuestraFechaActualiza.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbMuestraFechaActualiza.IsPK = False
        Me.chbMuestraFechaActualiza.IsRequired = False
        Me.chbMuestraFechaActualiza.Key = Nothing
        Me.chbMuestraFechaActualiza.LabelAsoc = Nothing
        Me.chbMuestraFechaActualiza.Location = New System.Drawing.Point(7, 32)
        Me.chbMuestraFechaActualiza.Name = "chbMuestraFechaActualiza"
        Me.chbMuestraFechaActualiza.Size = New System.Drawing.Size(350, 17)
        Me.chbMuestraFechaActualiza.TabIndex = 1
        Me.chbMuestraFechaActualiza.Tag = "MUESTRAFECHAACTUALIZA"
        Me.chbMuestraFechaActualiza.Text = "En ""Consultar Precios por Producto"" Muestra fecha de Actualización"
        Me.chbMuestraFechaActualiza.UseVisualStyleBackColor = True
        '
        'grbModificarPrecioPorArribaPrecioLista
        '
        Me.grbModificarPrecioPorArribaPrecioLista.Controls.Add(Me.Label28)
        Me.grbModificarPrecioPorArribaPrecioLista.Controls.Add(Me.txtPorcentajePrecioPorArribaPL)
        Me.grbModificarPrecioPorArribaPrecioLista.Controls.Add(Me.lblPorcentajePrecioPorArribaPL)
        Me.grbModificarPrecioPorArribaPrecioLista.Controls.Add(Me.rbtPrecioPorArribaAvisaryPermitir)
        Me.grbModificarPrecioPorArribaPrecioLista.Controls.Add(Me.rbtPrecioPorArribaNoPermitir)
        Me.grbModificarPrecioPorArribaPrecioLista.Controls.Add(Me.rbtPrecioPorArribaPermitir)
        Me.grbModificarPrecioPorArribaPrecioLista.Location = New System.Drawing.Point(450, 327)
        Me.grbModificarPrecioPorArribaPrecioLista.Name = "grbModificarPrecioPorArribaPrecioLista"
        Me.grbModificarPrecioPorArribaPrecioLista.Size = New System.Drawing.Size(438, 59)
        Me.grbModificarPrecioPorArribaPrecioLista.TabIndex = 21
        Me.grbModificarPrecioPorArribaPrecioLista.TabStop = False
        Me.grbModificarPrecioPorArribaPrecioLista.Tag = "MODIFICARPRECIOPORARRIBAPL"
        Me.grbModificarPrecioPorArribaPrecioLista.Text = "Facturacion: Modificar precio por arriba de Precio de Lista"
        '
        'Label28
        '
        Me.Label28.AutoSize = True
        Me.Label28.LabelAsoc = Nothing
        Me.Label28.Location = New System.Drawing.Point(321, 37)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(15, 13)
        Me.Label28.TabIndex = 16
        Me.Label28.Text = "%"
        '
        'txtPorcentajePrecioPorArribaPL
        '
        Me.txtPorcentajePrecioPorArribaPL.BindearPropiedadControl = Nothing
        Me.txtPorcentajePrecioPorArribaPL.BindearPropiedadEntidad = Nothing
        Me.txtPorcentajePrecioPorArribaPL.ForeColorFocus = System.Drawing.Color.Red
        Me.txtPorcentajePrecioPorArribaPL.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtPorcentajePrecioPorArribaPL.Formato = ""
        Me.txtPorcentajePrecioPorArribaPL.IsDecimal = True
        Me.txtPorcentajePrecioPorArribaPL.IsNumber = True
        Me.txtPorcentajePrecioPorArribaPL.IsPK = False
        Me.txtPorcentajePrecioPorArribaPL.IsRequired = False
        Me.txtPorcentajePrecioPorArribaPL.Key = ""
        Me.txtPorcentajePrecioPorArribaPL.LabelAsoc = Me.lblPorcentajePrecioPorArribaPL
        Me.txtPorcentajePrecioPorArribaPL.Location = New System.Drawing.Point(274, 33)
        Me.txtPorcentajePrecioPorArribaPL.MaxLength = 5
        Me.txtPorcentajePrecioPorArribaPL.Name = "txtPorcentajePrecioPorArribaPL"
        Me.txtPorcentajePrecioPorArribaPL.Size = New System.Drawing.Size(45, 20)
        Me.txtPorcentajePrecioPorArribaPL.TabIndex = 4
        Me.txtPorcentajePrecioPorArribaPL.Tag = "PORCENTAJEPORARRIBAPL"
        Me.txtPorcentajePrecioPorArribaPL.Text = "0.00"
        Me.txtPorcentajePrecioPorArribaPL.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblPorcentajePrecioPorArribaPL
        '
        Me.lblPorcentajePrecioPorArribaPL.AutoSize = True
        Me.lblPorcentajePrecioPorArribaPL.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblPorcentajePrecioPorArribaPL.LabelAsoc = Nothing
        Me.lblPorcentajePrecioPorArribaPL.Location = New System.Drawing.Point(19, 38)
        Me.lblPorcentajePrecioPorArribaPL.Name = "lblPorcentajePrecioPorArribaPL"
        Me.lblPorcentajePrecioPorArribaPL.Size = New System.Drawing.Size(238, 13)
        Me.lblPorcentajePrecioPorArribaPL.TabIndex = 3
        Me.lblPorcentajePrecioPorArribaPL.Text = "Porcentaje permitido por arriba de Precio de Lista"
        '
        'rbtPrecioPorArribaAvisaryPermitir
        '
        Me.rbtPrecioPorArribaAvisaryPermitir.AutoSize = True
        Me.rbtPrecioPorArribaAvisaryPermitir.Location = New System.Drawing.Point(181, 17)
        Me.rbtPrecioPorArribaAvisaryPermitir.Name = "rbtPrecioPorArribaAvisaryPermitir"
        Me.rbtPrecioPorArribaAvisaryPermitir.Size = New System.Drawing.Size(99, 17)
        Me.rbtPrecioPorArribaAvisaryPermitir.TabIndex = 2
        Me.rbtPrecioPorArribaAvisaryPermitir.Tag = "AVISARYPERMITIR"
        Me.rbtPrecioPorArribaAvisaryPermitir.Text = "Avisar y Permitir"
        Me.rbtPrecioPorArribaAvisaryPermitir.UseVisualStyleBackColor = True
        '
        'rbtPrecioPorArribaNoPermitir
        '
        Me.rbtPrecioPorArribaNoPermitir.AutoSize = True
        Me.rbtPrecioPorArribaNoPermitir.Location = New System.Drawing.Point(90, 17)
        Me.rbtPrecioPorArribaNoPermitir.Name = "rbtPrecioPorArribaNoPermitir"
        Me.rbtPrecioPorArribaNoPermitir.Size = New System.Drawing.Size(76, 17)
        Me.rbtPrecioPorArribaNoPermitir.TabIndex = 1
        Me.rbtPrecioPorArribaNoPermitir.Tag = "NOPERMITIR"
        Me.rbtPrecioPorArribaNoPermitir.Text = "No Permitir"
        Me.rbtPrecioPorArribaNoPermitir.UseVisualStyleBackColor = True
        '
        'rbtPrecioPorArribaPermitir
        '
        Me.rbtPrecioPorArribaPermitir.AutoSize = True
        Me.rbtPrecioPorArribaPermitir.Checked = True
        Me.rbtPrecioPorArribaPermitir.Location = New System.Drawing.Point(21, 17)
        Me.rbtPrecioPorArribaPermitir.Name = "rbtPrecioPorArribaPermitir"
        Me.rbtPrecioPorArribaPermitir.Size = New System.Drawing.Size(59, 17)
        Me.rbtPrecioPorArribaPermitir.TabIndex = 0
        Me.rbtPrecioPorArribaPermitir.TabStop = True
        Me.rbtPrecioPorArribaPermitir.Tag = "PERMITIR"
        Me.rbtPrecioPorArribaPermitir.Text = "Permitir"
        Me.rbtPrecioPorArribaPermitir.UseVisualStyleBackColor = True
        '
        'grbModificarPrecioPorDebajoPrecioLista
        '
        Me.grbModificarPrecioPorDebajoPrecioLista.Controls.Add(Me.Label27)
        Me.grbModificarPrecioPorDebajoPrecioLista.Controls.Add(Me.txtPorcentajePrecioPorDebajoPL)
        Me.grbModificarPrecioPorDebajoPrecioLista.Controls.Add(Me.lblPorcentajePrecioPorDebajoPL)
        Me.grbModificarPrecioPorDebajoPrecioLista.Controls.Add(Me.rbtPrecioPorDebajoAvisaryPermitir)
        Me.grbModificarPrecioPorDebajoPrecioLista.Controls.Add(Me.rbtPrecioPorDebajoNoPermitir)
        Me.grbModificarPrecioPorDebajoPrecioLista.Controls.Add(Me.rbtPrecioPorDebajoPermitir)
        Me.grbModificarPrecioPorDebajoPrecioLista.Location = New System.Drawing.Point(7, 327)
        Me.grbModificarPrecioPorDebajoPrecioLista.Name = "grbModificarPrecioPorDebajoPrecioLista"
        Me.grbModificarPrecioPorDebajoPrecioLista.Size = New System.Drawing.Size(438, 59)
        Me.grbModificarPrecioPorDebajoPrecioLista.TabIndex = 13
        Me.grbModificarPrecioPorDebajoPrecioLista.TabStop = False
        Me.grbModificarPrecioPorDebajoPrecioLista.Tag = "MODIFICARPRECIOPORDEBAJOPL"
        Me.grbModificarPrecioPorDebajoPrecioLista.Text = "Facturacion: Modificar precio por debajo de Precio de Lista"
        '
        'Label27
        '
        Me.Label27.AutoSize = True
        Me.Label27.LabelAsoc = Nothing
        Me.Label27.Location = New System.Drawing.Point(319, 37)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(36, 13)
        Me.Label27.TabIndex = 15
        Me.Label27.Text = "%       "
        '
        'txtPorcentajePrecioPorDebajoPL
        '
        Me.txtPorcentajePrecioPorDebajoPL.BindearPropiedadControl = Nothing
        Me.txtPorcentajePrecioPorDebajoPL.BindearPropiedadEntidad = Nothing
        Me.txtPorcentajePrecioPorDebajoPL.ForeColorFocus = System.Drawing.Color.Red
        Me.txtPorcentajePrecioPorDebajoPL.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtPorcentajePrecioPorDebajoPL.Formato = ""
        Me.txtPorcentajePrecioPorDebajoPL.IsDecimal = True
        Me.txtPorcentajePrecioPorDebajoPL.IsNumber = True
        Me.txtPorcentajePrecioPorDebajoPL.IsPK = False
        Me.txtPorcentajePrecioPorDebajoPL.IsRequired = False
        Me.txtPorcentajePrecioPorDebajoPL.Key = ""
        Me.txtPorcentajePrecioPorDebajoPL.LabelAsoc = Me.lblPorcentajePrecioPorDebajoPL
        Me.txtPorcentajePrecioPorDebajoPL.Location = New System.Drawing.Point(273, 34)
        Me.txtPorcentajePrecioPorDebajoPL.MaxLength = 5
        Me.txtPorcentajePrecioPorDebajoPL.Name = "txtPorcentajePrecioPorDebajoPL"
        Me.txtPorcentajePrecioPorDebajoPL.Size = New System.Drawing.Size(45, 20)
        Me.txtPorcentajePrecioPorDebajoPL.TabIndex = 4
        Me.txtPorcentajePrecioPorDebajoPL.Tag = "PORCENTAJEPORDEBAJOPL"
        Me.txtPorcentajePrecioPorDebajoPL.Text = "0.00"
        Me.txtPorcentajePrecioPorDebajoPL.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblPorcentajePrecioPorDebajoPL
        '
        Me.lblPorcentajePrecioPorDebajoPL.AutoSize = True
        Me.lblPorcentajePrecioPorDebajoPL.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblPorcentajePrecioPorDebajoPL.LabelAsoc = Nothing
        Me.lblPorcentajePrecioPorDebajoPL.Location = New System.Drawing.Point(21, 38)
        Me.lblPorcentajePrecioPorDebajoPL.Name = "lblPorcentajePrecioPorDebajoPL"
        Me.lblPorcentajePrecioPorDebajoPL.Size = New System.Drawing.Size(244, 13)
        Me.lblPorcentajePrecioPorDebajoPL.TabIndex = 3
        Me.lblPorcentajePrecioPorDebajoPL.Text = "Porcentaje permitido por debajo de Precio de Lista"
        '
        'rbtPrecioPorDebajoAvisaryPermitir
        '
        Me.rbtPrecioPorDebajoAvisaryPermitir.AutoSize = True
        Me.rbtPrecioPorDebajoAvisaryPermitir.Location = New System.Drawing.Point(181, 17)
        Me.rbtPrecioPorDebajoAvisaryPermitir.Name = "rbtPrecioPorDebajoAvisaryPermitir"
        Me.rbtPrecioPorDebajoAvisaryPermitir.Size = New System.Drawing.Size(99, 17)
        Me.rbtPrecioPorDebajoAvisaryPermitir.TabIndex = 2
        Me.rbtPrecioPorDebajoAvisaryPermitir.Tag = "AVISARYPERMITIR"
        Me.rbtPrecioPorDebajoAvisaryPermitir.Text = "Avisar y Permitir"
        Me.rbtPrecioPorDebajoAvisaryPermitir.UseVisualStyleBackColor = True
        '
        'rbtPrecioPorDebajoNoPermitir
        '
        Me.rbtPrecioPorDebajoNoPermitir.AutoSize = True
        Me.rbtPrecioPorDebajoNoPermitir.Location = New System.Drawing.Point(90, 17)
        Me.rbtPrecioPorDebajoNoPermitir.Name = "rbtPrecioPorDebajoNoPermitir"
        Me.rbtPrecioPorDebajoNoPermitir.Size = New System.Drawing.Size(76, 17)
        Me.rbtPrecioPorDebajoNoPermitir.TabIndex = 1
        Me.rbtPrecioPorDebajoNoPermitir.Tag = "NOPERMITIR"
        Me.rbtPrecioPorDebajoNoPermitir.Text = "No Permitir"
        Me.rbtPrecioPorDebajoNoPermitir.UseVisualStyleBackColor = True
        '
        'rbtPrecioPorDebajoPermitir
        '
        Me.rbtPrecioPorDebajoPermitir.AutoSize = True
        Me.rbtPrecioPorDebajoPermitir.Checked = True
        Me.rbtPrecioPorDebajoPermitir.Location = New System.Drawing.Point(21, 17)
        Me.rbtPrecioPorDebajoPermitir.Name = "rbtPrecioPorDebajoPermitir"
        Me.rbtPrecioPorDebajoPermitir.Size = New System.Drawing.Size(59, 17)
        Me.rbtPrecioPorDebajoPermitir.TabIndex = 0
        Me.rbtPrecioPorDebajoPermitir.TabStop = True
        Me.rbtPrecioPorDebajoPermitir.Tag = "PERMITIR"
        Me.rbtPrecioPorDebajoPermitir.Text = "Permitir"
        Me.rbtPrecioPorDebajoPermitir.UseVisualStyleBackColor = True
        '
        'lblMonedaParaConsultarPrecios
        '
        Me.lblMonedaParaConsultarPrecios.AutoSize = True
        Me.lblMonedaParaConsultarPrecios.LabelAsoc = Nothing
        Me.lblMonedaParaConsultarPrecios.Location = New System.Drawing.Point(451, 303)
        Me.lblMonedaParaConsultarPrecios.Name = "lblMonedaParaConsultarPrecios"
        Me.lblMonedaParaConsultarPrecios.Size = New System.Drawing.Size(281, 13)
        Me.lblMonedaParaConsultarPrecios.TabIndex = 19
        Me.lblMonedaParaConsultarPrecios.Text = "Al Consultar Precios mostrar el precio utilizando la Moneda"
        '
        'grpPreciosPriorizaCodigoYDescripcion
        '
        Me.grpPreciosPriorizaCodigoYDescripcion.Controls.Add(Me.pnlCodigoDescripcion)
        Me.grpPreciosPriorizaCodigoYDescripcion.Location = New System.Drawing.Point(7, 279)
        Me.grpPreciosPriorizaCodigoYDescripcion.Name = "grpPreciosPriorizaCodigoYDescripcion"
        Me.grpPreciosPriorizaCodigoYDescripcion.Size = New System.Drawing.Size(291, 42)
        Me.grpPreciosPriorizaCodigoYDescripcion.TabIndex = 12
        Me.grpPreciosPriorizaCodigoYDescripcion.TabStop = False
        Me.grpPreciosPriorizaCodigoYDescripcion.Text = "Consultar Precios: Prioriza Codigo y/o Descripcion"
        '
        'pnlCodigoDescripcion
        '
        Me.pnlCodigoDescripcion.Controls.Add(Me.radCodigoYDescripcion)
        Me.pnlCodigoDescripcion.Controls.Add(Me.radCodigoODescripcion)
        Me.pnlCodigoDescripcion.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlCodigoDescripcion.FlowDirection = System.Windows.Forms.FlowDirection.TopDown
        Me.pnlCodigoDescripcion.Location = New System.Drawing.Point(3, 16)
        Me.pnlCodigoDescripcion.Name = "pnlCodigoDescripcion"
        Me.pnlCodigoDescripcion.Size = New System.Drawing.Size(285, 23)
        Me.pnlCodigoDescripcion.TabIndex = 0
        Me.pnlCodigoDescripcion.TabStop = True
        '
        'radCodigoYDescripcion
        '
        Me.radCodigoYDescripcion.AutoSize = True
        Me.radCodigoYDescripcion.Checked = True
        Me.radCodigoYDescripcion.Location = New System.Drawing.Point(3, 3)
        Me.radCodigoYDescripcion.Name = "radCodigoYDescripcion"
        Me.radCodigoYDescripcion.Size = New System.Drawing.Size(127, 17)
        Me.radCodigoYDescripcion.TabIndex = 0
        Me.radCodigoYDescripcion.TabStop = True
        Me.radCodigoYDescripcion.Text = "Código Y Descripción"
        Me.radCodigoYDescripcion.UseVisualStyleBackColor = True
        '
        'radCodigoODescripcion
        '
        Me.radCodigoODescripcion.AutoSize = True
        Me.radCodigoODescripcion.Location = New System.Drawing.Point(136, 3)
        Me.radCodigoODescripcion.Name = "radCodigoODescripcion"
        Me.radCodigoODescripcion.Size = New System.Drawing.Size(128, 17)
        Me.radCodigoODescripcion.TabIndex = 1
        Me.radCodigoODescripcion.Text = "Código O Descripción"
        Me.radCodigoODescripcion.UseVisualStyleBackColor = True
        '
        'chbActualizaPrecioCostoPorTipoDeCambio
        '
        Me.chbActualizaPrecioCostoPorTipoDeCambio.AutoSize = True
        Me.chbActualizaPrecioCostoPorTipoDeCambio.BindearPropiedadControl = Nothing
        Me.chbActualizaPrecioCostoPorTipoDeCambio.BindearPropiedadEntidad = Nothing
        Me.chbActualizaPrecioCostoPorTipoDeCambio.ForeColorFocus = System.Drawing.Color.Red
        Me.chbActualizaPrecioCostoPorTipoDeCambio.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbActualizaPrecioCostoPorTipoDeCambio.IsPK = False
        Me.chbActualizaPrecioCostoPorTipoDeCambio.IsRequired = False
        Me.chbActualizaPrecioCostoPorTipoDeCambio.Key = Nothing
        Me.chbActualizaPrecioCostoPorTipoDeCambio.LabelAsoc = Nothing
        Me.chbActualizaPrecioCostoPorTipoDeCambio.Location = New System.Drawing.Point(454, 276)
        Me.chbActualizaPrecioCostoPorTipoDeCambio.Name = "chbActualizaPrecioCostoPorTipoDeCambio"
        Me.chbActualizaPrecioCostoPorTipoDeCambio.Size = New System.Drawing.Size(383, 17)
        Me.chbActualizaPrecioCostoPorTipoDeCambio.TabIndex = 18
        Me.chbActualizaPrecioCostoPorTipoDeCambio.Tag = ""
        Me.chbActualizaPrecioCostoPorTipoDeCambio.Text = "Pregunta si actualiza precios de costo despues de actualizar tipo de cambio"
        Me.chbActualizaPrecioCostoPorTipoDeCambio.UseVisualStyleBackColor = True
        '
        'lblListaDePreciosPredeterminada
        '
        Me.lblListaDePreciosPredeterminada.AutoSize = True
        Me.lblListaDePreciosPredeterminada.LabelAsoc = Nothing
        Me.lblListaDePreciosPredeterminada.Location = New System.Drawing.Point(4, 256)
        Me.lblListaDePreciosPredeterminada.Name = "lblListaDePreciosPredeterminada"
        Me.lblListaDePreciosPredeterminada.Size = New System.Drawing.Size(157, 13)
        Me.lblListaDePreciosPredeterminada.TabIndex = 10
        Me.lblListaDePreciosPredeterminada.Text = "Lista de precios predeterminada"
        '
        'chbMarcarTodos
        '
        Me.chbMarcarTodos.AutoSize = True
        Me.chbMarcarTodos.BindearPropiedadControl = Nothing
        Me.chbMarcarTodos.BindearPropiedadEntidad = Nothing
        Me.chbMarcarTodos.Checked = True
        Me.chbMarcarTodos.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chbMarcarTodos.ForeColorFocus = System.Drawing.Color.Red
        Me.chbMarcarTodos.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbMarcarTodos.IsPK = False
        Me.chbMarcarTodos.IsRequired = False
        Me.chbMarcarTodos.Key = Nothing
        Me.chbMarcarTodos.LabelAsoc = Nothing
        Me.chbMarcarTodos.Location = New System.Drawing.Point(7, 229)
        Me.chbMarcarTodos.Name = "chbMarcarTodos"
        Me.chbMarcarTodos.Size = New System.Drawing.Size(182, 17)
        Me.chbMarcarTodos.TabIndex = 9
        Me.chbMarcarTodos.Tag = "ACTUALIZARPRECIOSMARCARTODOS"
        Me.chbMarcarTodos.Text = "Actualizar Precios: Marcar Todos"
        Me.chbMarcarTodos.UseVisualStyleBackColor = True
        '
        'grbFTP
        '
        Me.grbFTP.Controls.Add(Me.chbFTPUtilizaCarpetaSecundaria)
        Me.grbFTP.Controls.Add(Me.txtFTPCarpetaRemota)
        Me.grbFTP.Controls.Add(Me.lblCarpetaRemota)
        Me.grbFTP.Controls.Add(Me.cmbFTPFormato)
        Me.grbFTP.Controls.Add(Me.lblFTPFormato)
        Me.grbFTP.Controls.Add(Me.txtFTPNombreArchivo)
        Me.grbFTP.Controls.Add(Me.lblFTPNombreArchivo)
        Me.grbFTP.Controls.Add(Me.Button1)
        Me.grbFTP.Controls.Add(Me.chbFTPConexionPasiva)
        Me.grbFTP.Controls.Add(Me.txtFTPPassword)
        Me.grbFTP.Controls.Add(Me.lblFTPPassword)
        Me.grbFTP.Controls.Add(Me.txtFTPUsuario)
        Me.grbFTP.Controls.Add(Me.lblFTPUsuario)
        Me.grbFTP.Controls.Add(Me.txtFTPServidor)
        Me.grbFTP.Controls.Add(Me.lblFTPServidor)
        Me.grbFTP.Location = New System.Drawing.Point(454, 56)
        Me.grbFTP.Name = "grbFTP"
        Me.grbFTP.Size = New System.Drawing.Size(417, 214)
        Me.grbFTP.TabIndex = 17
        Me.grbFTP.TabStop = False
        Me.grbFTP.Text = "FTP"
        '
        'chbFTPUtilizaCarpetaSecundaria
        '
        Me.chbFTPUtilizaCarpetaSecundaria.AutoSize = True
        Me.chbFTPUtilizaCarpetaSecundaria.BindearPropiedadControl = Nothing
        Me.chbFTPUtilizaCarpetaSecundaria.BindearPropiedadEntidad = Nothing
        Me.chbFTPUtilizaCarpetaSecundaria.ForeColorFocus = System.Drawing.Color.Red
        Me.chbFTPUtilizaCarpetaSecundaria.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbFTPUtilizaCarpetaSecundaria.IsPK = False
        Me.chbFTPUtilizaCarpetaSecundaria.IsRequired = False
        Me.chbFTPUtilizaCarpetaSecundaria.Key = Nothing
        Me.chbFTPUtilizaCarpetaSecundaria.LabelAsoc = Nothing
        Me.chbFTPUtilizaCarpetaSecundaria.Location = New System.Drawing.Point(111, 194)
        Me.chbFTPUtilizaCarpetaSecundaria.Name = "chbFTPUtilizaCarpetaSecundaria"
        Me.chbFTPUtilizaCarpetaSecundaria.Size = New System.Drawing.Size(241, 17)
        Me.chbFTPUtilizaCarpetaSecundaria.TabIndex = 14
        Me.chbFTPUtilizaCarpetaSecundaria.Tag = "FTPCARPETASECUNDARIA"
        Me.chbFTPUtilizaCarpetaSecundaria.Text = "Utiliza Carpeta Secundaria para archivos FTP"
        Me.chbFTPUtilizaCarpetaSecundaria.UseVisualStyleBackColor = True
        '
        'txtFTPCarpetaRemota
        '
        Me.txtFTPCarpetaRemota.BindearPropiedadControl = Nothing
        Me.txtFTPCarpetaRemota.BindearPropiedadEntidad = Nothing
        Me.txtFTPCarpetaRemota.ForeColorFocus = System.Drawing.Color.Red
        Me.txtFTPCarpetaRemota.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtFTPCarpetaRemota.Formato = ""
        Me.txtFTPCarpetaRemota.IsDecimal = False
        Me.txtFTPCarpetaRemota.IsNumber = False
        Me.txtFTPCarpetaRemota.IsPK = False
        Me.txtFTPCarpetaRemota.IsRequired = False
        Me.txtFTPCarpetaRemota.Key = ""
        Me.txtFTPCarpetaRemota.LabelAsoc = Me.lblCarpetaRemota
        Me.txtFTPCarpetaRemota.Location = New System.Drawing.Point(111, 141)
        Me.txtFTPCarpetaRemota.MaxLength = 110
        Me.txtFTPCarpetaRemota.Name = "txtFTPCarpetaRemota"
        Me.txtFTPCarpetaRemota.Size = New System.Drawing.Size(250, 20)
        Me.txtFTPCarpetaRemota.TabIndex = 11
        Me.txtFTPCarpetaRemota.Tag = "FTPCARPETAREMOTA"
        '
        'lblCarpetaRemota
        '
        Me.lblCarpetaRemota.AutoSize = True
        Me.lblCarpetaRemota.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblCarpetaRemota.LabelAsoc = Nothing
        Me.lblCarpetaRemota.Location = New System.Drawing.Point(4, 145)
        Me.lblCarpetaRemota.Name = "lblCarpetaRemota"
        Me.lblCarpetaRemota.Size = New System.Drawing.Size(107, 13)
        Me.lblCarpetaRemota.TabIndex = 10
        Me.lblCarpetaRemota.Text = "Carpeta Remota FTP"
        '
        'cmbFTPFormato
        '
        Me.cmbFTPFormato.BindearPropiedadControl = Nothing
        Me.cmbFTPFormato.BindearPropiedadEntidad = Nothing
        Me.cmbFTPFormato.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbFTPFormato.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbFTPFormato.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbFTPFormato.FormattingEnabled = True
        Me.cmbFTPFormato.IsPK = False
        Me.cmbFTPFormato.IsRequired = False
        Me.cmbFTPFormato.Items.AddRange(New Object() {"WEB", "DonWeb", "Para Sucursales", "Para Clientes", "Qendra", "WebExperto", "iTegra/Kretz"})
        Me.cmbFTPFormato.Key = Nothing
        Me.cmbFTPFormato.LabelAsoc = Me.lblFTPFormato
        Me.cmbFTPFormato.Location = New System.Drawing.Point(111, 167)
        Me.cmbFTPFormato.Name = "cmbFTPFormato"
        Me.cmbFTPFormato.Size = New System.Drawing.Size(120, 21)
        Me.cmbFTPFormato.TabIndex = 13
        Me.cmbFTPFormato.Tag = "FTPFORMATO"
        '
        'lblFTPFormato
        '
        Me.lblFTPFormato.AutoSize = True
        Me.lblFTPFormato.LabelAsoc = Nothing
        Me.lblFTPFormato.Location = New System.Drawing.Point(4, 173)
        Me.lblFTPFormato.Name = "lblFTPFormato"
        Me.lblFTPFormato.Size = New System.Drawing.Size(45, 13)
        Me.lblFTPFormato.TabIndex = 12
        Me.lblFTPFormato.Text = "Formato"
        '
        'txtFTPNombreArchivo
        '
        Me.txtFTPNombreArchivo.BindearPropiedadControl = Nothing
        Me.txtFTPNombreArchivo.BindearPropiedadEntidad = Nothing
        Me.txtFTPNombreArchivo.ForeColorFocus = System.Drawing.Color.Red
        Me.txtFTPNombreArchivo.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtFTPNombreArchivo.Formato = ""
        Me.txtFTPNombreArchivo.IsDecimal = False
        Me.txtFTPNombreArchivo.IsNumber = False
        Me.txtFTPNombreArchivo.IsPK = False
        Me.txtFTPNombreArchivo.IsRequired = False
        Me.txtFTPNombreArchivo.Key = ""
        Me.txtFTPNombreArchivo.LabelAsoc = Me.lblFTPNombreArchivo
        Me.txtFTPNombreArchivo.Location = New System.Drawing.Point(111, 115)
        Me.txtFTPNombreArchivo.MaxLength = 110
        Me.txtFTPNombreArchivo.Name = "txtFTPNombreArchivo"
        Me.txtFTPNombreArchivo.Size = New System.Drawing.Size(250, 20)
        Me.txtFTPNombreArchivo.TabIndex = 9
        Me.txtFTPNombreArchivo.Tag = "FTPNOMBREARCHIVO"
        '
        'lblFTPNombreArchivo
        '
        Me.lblFTPNombreArchivo.AutoSize = True
        Me.lblFTPNombreArchivo.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblFTPNombreArchivo.LabelAsoc = Nothing
        Me.lblFTPNombreArchivo.Location = New System.Drawing.Point(5, 119)
        Me.lblFTPNombreArchivo.Name = "lblFTPNombreArchivo"
        Me.lblFTPNombreArchivo.Size = New System.Drawing.Size(83, 13)
        Me.lblFTPNombreArchivo.TabIndex = 8
        Me.lblFTPNombreArchivo.Text = "Nombre Archivo"
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(233, 40)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(121, 33)
        Me.Button1.TabIndex = 4
        Me.Button1.Text = "Probar configuración"
        Me.Button1.UseVisualStyleBackColor = True
        Me.Button1.Visible = False
        '
        'chbFTPConexionPasiva
        '
        Me.chbFTPConexionPasiva.AutoSize = True
        Me.chbFTPConexionPasiva.BindearPropiedadControl = Nothing
        Me.chbFTPConexionPasiva.BindearPropiedadEntidad = Nothing
        Me.chbFTPConexionPasiva.ForeColorFocus = System.Drawing.Color.Red
        Me.chbFTPConexionPasiva.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbFTPConexionPasiva.IsPK = False
        Me.chbFTPConexionPasiva.IsRequired = False
        Me.chbFTPConexionPasiva.Key = Nothing
        Me.chbFTPConexionPasiva.LabelAsoc = Nothing
        Me.chbFTPConexionPasiva.Location = New System.Drawing.Point(111, 92)
        Me.chbFTPConexionPasiva.Name = "chbFTPConexionPasiva"
        Me.chbFTPConexionPasiva.Size = New System.Drawing.Size(105, 17)
        Me.chbFTPConexionPasiva.TabIndex = 7
        Me.chbFTPConexionPasiva.Tag = "FTPCONEXIONPASIVA"
        Me.chbFTPConexionPasiva.Text = "Conexión Pasiva"
        Me.chbFTPConexionPasiva.UseVisualStyleBackColor = True
        '
        'txtFTPPassword
        '
        Me.txtFTPPassword.BindearPropiedadControl = Nothing
        Me.txtFTPPassword.BindearPropiedadEntidad = Nothing
        Me.txtFTPPassword.ForeColorFocus = System.Drawing.Color.Red
        Me.txtFTPPassword.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtFTPPassword.Formato = ""
        Me.txtFTPPassword.IsDecimal = False
        Me.txtFTPPassword.IsNumber = False
        Me.txtFTPPassword.IsPK = False
        Me.txtFTPPassword.IsRequired = False
        Me.txtFTPPassword.Key = ""
        Me.txtFTPPassword.LabelAsoc = Me.lblFTPPassword
        Me.txtFTPPassword.Location = New System.Drawing.Point(111, 66)
        Me.txtFTPPassword.MaxLength = 110
        Me.txtFTPPassword.Name = "txtFTPPassword"
        Me.txtFTPPassword.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtFTPPassword.Size = New System.Drawing.Size(120, 20)
        Me.txtFTPPassword.TabIndex = 6
        Me.txtFTPPassword.Tag = "FTPPASSWORD"
        '
        'lblFTPPassword
        '
        Me.lblFTPPassword.AutoSize = True
        Me.lblFTPPassword.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblFTPPassword.LabelAsoc = Nothing
        Me.lblFTPPassword.Location = New System.Drawing.Point(14, 70)
        Me.lblFTPPassword.Name = "lblFTPPassword"
        Me.lblFTPPassword.Size = New System.Drawing.Size(53, 13)
        Me.lblFTPPassword.TabIndex = 5
        Me.lblFTPPassword.Text = "Password"
        '
        'txtFTPUsuario
        '
        Me.txtFTPUsuario.BindearPropiedadControl = Nothing
        Me.txtFTPUsuario.BindearPropiedadEntidad = Nothing
        Me.txtFTPUsuario.ForeColorFocus = System.Drawing.Color.Red
        Me.txtFTPUsuario.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtFTPUsuario.Formato = ""
        Me.txtFTPUsuario.IsDecimal = False
        Me.txtFTPUsuario.IsNumber = False
        Me.txtFTPUsuario.IsPK = False
        Me.txtFTPUsuario.IsRequired = False
        Me.txtFTPUsuario.Key = ""
        Me.txtFTPUsuario.LabelAsoc = Me.lblFTPUsuario
        Me.txtFTPUsuario.Location = New System.Drawing.Point(111, 40)
        Me.txtFTPUsuario.MaxLength = 110
        Me.txtFTPUsuario.Name = "txtFTPUsuario"
        Me.txtFTPUsuario.Size = New System.Drawing.Size(120, 20)
        Me.txtFTPUsuario.TabIndex = 3
        Me.txtFTPUsuario.Tag = "FTPUSUARIO"
        '
        'lblFTPUsuario
        '
        Me.lblFTPUsuario.AutoSize = True
        Me.lblFTPUsuario.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblFTPUsuario.LabelAsoc = Nothing
        Me.lblFTPUsuario.Location = New System.Drawing.Point(14, 44)
        Me.lblFTPUsuario.Name = "lblFTPUsuario"
        Me.lblFTPUsuario.Size = New System.Drawing.Size(43, 13)
        Me.lblFTPUsuario.TabIndex = 2
        Me.lblFTPUsuario.Text = "Usuario"
        '
        'txtFTPServidor
        '
        Me.txtFTPServidor.BindearPropiedadControl = Nothing
        Me.txtFTPServidor.BindearPropiedadEntidad = Nothing
        Me.txtFTPServidor.ForeColorFocus = System.Drawing.Color.Red
        Me.txtFTPServidor.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtFTPServidor.Formato = ""
        Me.txtFTPServidor.IsDecimal = False
        Me.txtFTPServidor.IsNumber = False
        Me.txtFTPServidor.IsPK = False
        Me.txtFTPServidor.IsRequired = False
        Me.txtFTPServidor.Key = ""
        Me.txtFTPServidor.LabelAsoc = Me.lblFTPServidor
        Me.txtFTPServidor.Location = New System.Drawing.Point(111, 15)
        Me.txtFTPServidor.MaxLength = 110
        Me.txtFTPServidor.Name = "txtFTPServidor"
        Me.txtFTPServidor.Size = New System.Drawing.Size(250, 20)
        Me.txtFTPServidor.TabIndex = 1
        Me.txtFTPServidor.Tag = "FTPSERVIDOR"
        '
        'lblFTPServidor
        '
        Me.lblFTPServidor.AutoSize = True
        Me.lblFTPServidor.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblFTPServidor.LabelAsoc = Nothing
        Me.lblFTPServidor.Location = New System.Drawing.Point(14, 19)
        Me.lblFTPServidor.Name = "lblFTPServidor"
        Me.lblFTPServidor.Size = New System.Drawing.Size(46, 13)
        Me.lblFTPServidor.TabIndex = 0
        Me.lblFTPServidor.Text = "Servidor"
        '
        'grbActualizarPreciosCalculo
        '
        Me.grbActualizarPreciosCalculo.Controls.Add(Me.rbtDesdeFormula)
        Me.grbActualizarPreciosCalculo.Controls.Add(Me.rbtSobreCosto)
        Me.grbActualizarPreciosCalculo.Controls.Add(Me.rbtSobreVenta)
        Me.grbActualizarPreciosCalculo.Controls.Add(Me.rbtPorcActual)
        Me.grbActualizarPreciosCalculo.Location = New System.Drawing.Point(7, 150)
        Me.grbActualizarPreciosCalculo.Name = "grbActualizarPreciosCalculo"
        Me.grbActualizarPreciosCalculo.Size = New System.Drawing.Size(384, 50)
        Me.grbActualizarPreciosCalculo.TabIndex = 7
        Me.grbActualizarPreciosCalculo.TabStop = False
        Me.grbActualizarPreciosCalculo.Tag = "ACTUALIZARPRECIOSCALCULO"
        Me.grbActualizarPreciosCalculo.Text = "Actualizar Precios cálculo"
        '
        'rbtDesdeFormula
        '
        Me.rbtDesdeFormula.AutoSize = True
        Me.rbtDesdeFormula.Location = New System.Drawing.Point(274, 22)
        Me.rbtDesdeFormula.Name = "rbtDesdeFormula"
        Me.rbtDesdeFormula.Size = New System.Drawing.Size(96, 17)
        Me.rbtDesdeFormula.TabIndex = 3
        Me.rbtDesdeFormula.Tag = "FORMULA"
        Me.rbtDesdeFormula.Text = "Desde Fórmula"
        Me.rbtDesdeFormula.UseVisualStyleBackColor = True
        '
        'rbtSobreCosto
        '
        Me.rbtSobreCosto.AutoSize = True
        Me.rbtSobreCosto.Location = New System.Drawing.Point(186, 22)
        Me.rbtSobreCosto.Name = "rbtSobreCosto"
        Me.rbtSobreCosto.Size = New System.Drawing.Size(83, 17)
        Me.rbtSobreCosto.TabIndex = 2
        Me.rbtSobreCosto.Tag = "COSTO"
        Me.rbtSobreCosto.Text = "Sobre Costo"
        Me.rbtSobreCosto.UseVisualStyleBackColor = True
        '
        'rbtSobreVenta
        '
        Me.rbtSobreVenta.AutoSize = True
        Me.rbtSobreVenta.Location = New System.Drawing.Point(97, 22)
        Me.rbtSobreVenta.Name = "rbtSobreVenta"
        Me.rbtSobreVenta.Size = New System.Drawing.Size(84, 17)
        Me.rbtSobreVenta.TabIndex = 1
        Me.rbtSobreVenta.Tag = "VENTA"
        Me.rbtSobreVenta.Text = "Sobre Venta"
        Me.rbtSobreVenta.UseVisualStyleBackColor = True
        '
        'rbtPorcActual
        '
        Me.rbtPorcActual.AutoSize = True
        Me.rbtPorcActual.Checked = True
        Me.rbtPorcActual.Location = New System.Drawing.Point(9, 22)
        Me.rbtPorcActual.Name = "rbtPorcActual"
        Me.rbtPorcActual.Size = New System.Drawing.Size(83, 17)
        Me.rbtPorcActual.TabIndex = 0
        Me.rbtPorcActual.TabStop = True
        Me.rbtPorcActual.Tag = "ACTUAL"
        Me.rbtPorcActual.Text = "Porc. Actual"
        Me.rbtPorcActual.UseVisualStyleBackColor = True
        '
        'txtCantidadDecimalesEnVenta
        '
        Me.txtCantidadDecimalesEnVenta.BindearPropiedadControl = Nothing
        Me.txtCantidadDecimalesEnVenta.BindearPropiedadEntidad = Nothing
        Me.txtCantidadDecimalesEnVenta.ForeColorFocus = System.Drawing.Color.Red
        Me.txtCantidadDecimalesEnVenta.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtCantidadDecimalesEnVenta.Formato = ""
        Me.txtCantidadDecimalesEnVenta.IsDecimal = False
        Me.txtCantidadDecimalesEnVenta.IsNumber = True
        Me.txtCantidadDecimalesEnVenta.IsPK = False
        Me.txtCantidadDecimalesEnVenta.IsRequired = False
        Me.txtCantidadDecimalesEnVenta.Key = ""
        Me.txtCantidadDecimalesEnVenta.LabelAsoc = Me.lblCantidadDecimalesEnVenta
        Me.txtCantidadDecimalesEnVenta.Location = New System.Drawing.Point(652, 30)
        Me.txtCantidadDecimalesEnVenta.MaxLength = 3
        Me.txtCantidadDecimalesEnVenta.Name = "txtCantidadDecimalesEnVenta"
        Me.txtCantidadDecimalesEnVenta.Size = New System.Drawing.Size(35, 20)
        Me.txtCantidadDecimalesEnVenta.TabIndex = 16
        Me.txtCantidadDecimalesEnVenta.Tag = "PRECIOSDECIMALESENVENTA"
        Me.txtCantidadDecimalesEnVenta.Text = "2"
        Me.txtCantidadDecimalesEnVenta.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblCantidadDecimalesEnVenta
        '
        Me.lblCantidadDecimalesEnVenta.AutoSize = True
        Me.lblCantidadDecimalesEnVenta.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblCantidadDecimalesEnVenta.LabelAsoc = Nothing
        Me.lblCantidadDecimalesEnVenta.Location = New System.Drawing.Point(451, 34)
        Me.lblCantidadDecimalesEnVenta.Name = "lblCantidadDecimalesEnVenta"
        Me.lblCantidadDecimalesEnVenta.Size = New System.Drawing.Size(195, 13)
        Me.lblCantidadDecimalesEnVenta.TabIndex = 15
        Me.lblCantidadDecimalesEnVenta.Text = "Cantidad Decimales en Precio de Venta"
        '
        'txtCotizacionDolar
        '
        Me.txtCotizacionDolar.BindearPropiedadControl = Nothing
        Me.txtCotizacionDolar.BindearPropiedadEntidad = Nothing
        Me.txtCotizacionDolar.ForeColorFocus = System.Drawing.Color.Red
        Me.txtCotizacionDolar.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtCotizacionDolar.Formato = ""
        Me.txtCotizacionDolar.IsDecimal = True
        Me.txtCotizacionDolar.IsNumber = True
        Me.txtCotizacionDolar.IsPK = False
        Me.txtCotizacionDolar.IsRequired = False
        Me.txtCotizacionDolar.Key = ""
        Me.txtCotizacionDolar.LabelAsoc = Me.lblCotizacionDolar
        Me.txtCotizacionDolar.Location = New System.Drawing.Point(111, 55)
        Me.txtCotizacionDolar.MaxLength = 5
        Me.txtCotizacionDolar.Name = "txtCotizacionDolar"
        Me.txtCotizacionDolar.Size = New System.Drawing.Size(78, 20)
        Me.txtCotizacionDolar.TabIndex = 3
        Me.txtCotizacionDolar.Tag = "PRODUCTOIVA"
        Me.txtCotizacionDolar.Text = "0.00"
        Me.txtCotizacionDolar.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblCotizacionDolar
        '
        Me.lblCotizacionDolar.AutoSize = True
        Me.lblCotizacionDolar.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblCotizacionDolar.LabelAsoc = Nothing
        Me.lblCotizacionDolar.Location = New System.Drawing.Point(4, 59)
        Me.lblCotizacionDolar.Name = "lblCotizacionDolar"
        Me.lblCotizacionDolar.Size = New System.Drawing.Size(101, 13)
        Me.lblCotizacionDolar.TabIndex = 2
        Me.lblCotizacionDolar.Text = "Cotización del Dolar"
        '
        'chbActualizarPreciosMostrarCodigoProductoProveedor
        '
        Me.chbActualizarPreciosMostrarCodigoProductoProveedor.AutoSize = True
        Me.chbActualizarPreciosMostrarCodigoProductoProveedor.BindearPropiedadControl = Nothing
        Me.chbActualizarPreciosMostrarCodigoProductoProveedor.BindearPropiedadEntidad = Nothing
        Me.chbActualizarPreciosMostrarCodigoProductoProveedor.ForeColorFocus = System.Drawing.Color.Red
        Me.chbActualizarPreciosMostrarCodigoProductoProveedor.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbActualizarPreciosMostrarCodigoProductoProveedor.IsPK = False
        Me.chbActualizarPreciosMostrarCodigoProductoProveedor.IsRequired = False
        Me.chbActualizarPreciosMostrarCodigoProductoProveedor.Key = Nothing
        Me.chbActualizarPreciosMostrarCodigoProductoProveedor.LabelAsoc = Nothing
        Me.chbActualizarPreciosMostrarCodigoProductoProveedor.Location = New System.Drawing.Point(7, 206)
        Me.chbActualizarPreciosMostrarCodigoProductoProveedor.Name = "chbActualizarPreciosMostrarCodigoProductoProveedor"
        Me.chbActualizarPreciosMostrarCodigoProductoProveedor.Size = New System.Drawing.Size(317, 17)
        Me.chbActualizarPreciosMostrarCodigoProductoProveedor.TabIndex = 8
        Me.chbActualizarPreciosMostrarCodigoProductoProveedor.Text = "Actualizar Precios: Mostrar Código de Producto del Proveedor"
        Me.chbActualizarPreciosMostrarCodigoProductoProveedor.UseVisualStyleBackColor = True
        '
        'chbConsultarPreciosProdNoAfectanStock
        '
        Me.chbConsultarPreciosProdNoAfectanStock.AutoSize = True
        Me.chbConsultarPreciosProdNoAfectanStock.BindearPropiedadControl = Nothing
        Me.chbConsultarPreciosProdNoAfectanStock.BindearPropiedadEntidad = Nothing
        Me.chbConsultarPreciosProdNoAfectanStock.ForeColorFocus = System.Drawing.Color.Red
        Me.chbConsultarPreciosProdNoAfectanStock.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbConsultarPreciosProdNoAfectanStock.IsPK = False
        Me.chbConsultarPreciosProdNoAfectanStock.IsRequired = False
        Me.chbConsultarPreciosProdNoAfectanStock.Key = Nothing
        Me.chbConsultarPreciosProdNoAfectanStock.LabelAsoc = Nothing
        Me.chbConsultarPreciosProdNoAfectanStock.Location = New System.Drawing.Point(7, 127)
        Me.chbConsultarPreciosProdNoAfectanStock.Name = "chbConsultarPreciosProdNoAfectanStock"
        Me.chbConsultarPreciosProdNoAfectanStock.Size = New System.Drawing.Size(217, 17)
        Me.chbConsultarPreciosProdNoAfectanStock.TabIndex = 6
        Me.chbConsultarPreciosProdNoAfectanStock.Tag = "CONSULTPRECOCULTARPRODNOAFECTSTOCK"
        Me.chbConsultarPreciosProdNoAfectanStock.Text = "Ocultar Productos que no afectan Stock"
        Me.chbConsultarPreciosProdNoAfectanStock.UseVisualStyleBackColor = True
        '
        'chbConsultarPreciosConEmbalaje
        '
        Me.chbConsultarPreciosConEmbalaje.AutoSize = True
        Me.chbConsultarPreciosConEmbalaje.BindearPropiedadControl = Nothing
        Me.chbConsultarPreciosConEmbalaje.BindearPropiedadEntidad = Nothing
        Me.chbConsultarPreciosConEmbalaje.ForeColorFocus = System.Drawing.Color.Red
        Me.chbConsultarPreciosConEmbalaje.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbConsultarPreciosConEmbalaje.IsPK = False
        Me.chbConsultarPreciosConEmbalaje.IsRequired = False
        Me.chbConsultarPreciosConEmbalaje.Key = Nothing
        Me.chbConsultarPreciosConEmbalaje.LabelAsoc = Nothing
        Me.chbConsultarPreciosConEmbalaje.Location = New System.Drawing.Point(7, 104)
        Me.chbConsultarPreciosConEmbalaje.Name = "chbConsultarPreciosConEmbalaje"
        Me.chbConsultarPreciosConEmbalaje.Size = New System.Drawing.Size(290, 17)
        Me.chbConsultarPreciosConEmbalaje.TabIndex = 5
        Me.chbConsultarPreciosConEmbalaje.Tag = "CONSULTARPRECIOSCONEMBALAJE"
        Me.chbConsultarPreciosConEmbalaje.Text = "Precio Costo y Venta Por Embalaje en Consultar Precios"
        Me.chbConsultarPreciosConEmbalaje.UseVisualStyleBackColor = True
        '
        'chbPreciosUnificarEntreSucursales
        '
        Me.chbPreciosUnificarEntreSucursales.AutoSize = True
        Me.chbPreciosUnificarEntreSucursales.BindearPropiedadControl = Nothing
        Me.chbPreciosUnificarEntreSucursales.BindearPropiedadEntidad = Nothing
        Me.chbPreciosUnificarEntreSucursales.ForeColorFocus = System.Drawing.Color.Red
        Me.chbPreciosUnificarEntreSucursales.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbPreciosUnificarEntreSucursales.IsPK = False
        Me.chbPreciosUnificarEntreSucursales.IsRequired = False
        Me.chbPreciosUnificarEntreSucursales.Key = Nothing
        Me.chbPreciosUnificarEntreSucursales.LabelAsoc = Nothing
        Me.chbPreciosUnificarEntreSucursales.Location = New System.Drawing.Point(454, 9)
        Me.chbPreciosUnificarEntreSucursales.Name = "chbPreciosUnificarEntreSucursales"
        Me.chbPreciosUnificarEntreSucursales.Size = New System.Drawing.Size(145, 17)
        Me.chbPreciosUnificarEntreSucursales.TabIndex = 14
        Me.chbPreciosUnificarEntreSucursales.Tag = "PRECIOSUNIFICAR"
        Me.chbPreciosUnificarEntreSucursales.Text = "Unificar Entre Sucursales"
        Me.chbPreciosUnificarEntreSucursales.UseVisualStyleBackColor = True
        '
        'chbConsultarPreciosConIVA
        '
        Me.chbConsultarPreciosConIVA.AutoSize = True
        Me.chbConsultarPreciosConIVA.BindearPropiedadControl = Nothing
        Me.chbConsultarPreciosConIVA.BindearPropiedadEntidad = Nothing
        Me.chbConsultarPreciosConIVA.ForeColorFocus = System.Drawing.Color.Red
        Me.chbConsultarPreciosConIVA.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbConsultarPreciosConIVA.IsPK = False
        Me.chbConsultarPreciosConIVA.IsRequired = False
        Me.chbConsultarPreciosConIVA.Key = Nothing
        Me.chbConsultarPreciosConIVA.LabelAsoc = Nothing
        Me.chbConsultarPreciosConIVA.Location = New System.Drawing.Point(7, 9)
        Me.chbConsultarPreciosConIVA.Name = "chbConsultarPreciosConIVA"
        Me.chbConsultarPreciosConIVA.Size = New System.Drawing.Size(149, 17)
        Me.chbConsultarPreciosConIVA.TabIndex = 0
        Me.chbConsultarPreciosConIVA.Tag = "CONSULTARPRECIOSCONIVA"
        Me.chbConsultarPreciosConIVA.Text = "Consultar Precios con IVA"
        Me.chbConsultarPreciosConIVA.UseVisualStyleBackColor = True
        '
        'chbUtilizaPrecioDeCompra
        '
        Me.chbUtilizaPrecioDeCompra.AutoSize = True
        Me.chbUtilizaPrecioDeCompra.BindearPropiedadControl = Nothing
        Me.chbUtilizaPrecioDeCompra.BindearPropiedadEntidad = Nothing
        Me.chbUtilizaPrecioDeCompra.ForeColorFocus = System.Drawing.Color.Red
        Me.chbUtilizaPrecioDeCompra.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbUtilizaPrecioDeCompra.IsPK = False
        Me.chbUtilizaPrecioDeCompra.IsRequired = False
        Me.chbUtilizaPrecioDeCompra.Key = Nothing
        Me.chbUtilizaPrecioDeCompra.LabelAsoc = Nothing
        Me.chbUtilizaPrecioDeCompra.Location = New System.Drawing.Point(7, 81)
        Me.chbUtilizaPrecioDeCompra.Name = "chbUtilizaPrecioDeCompra"
        Me.chbUtilizaPrecioDeCompra.Size = New System.Drawing.Size(152, 17)
        Me.chbUtilizaPrecioDeCompra.TabIndex = 4
        Me.chbUtilizaPrecioDeCompra.Tag = "UTILIZAPRECIODECOMPRA"
        Me.chbUtilizaPrecioDeCompra.Text = "Utiliza el Precio de Compra"
        Me.chbUtilizaPrecioDeCompra.UseVisualStyleBackColor = True
        '
        'cmbMonedaParaConsultarPrecios
        '
        Me.cmbMonedaParaConsultarPrecios.BindearPropiedadControl = Nothing
        Me.cmbMonedaParaConsultarPrecios.BindearPropiedadEntidad = Nothing
        Me.cmbMonedaParaConsultarPrecios.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbMonedaParaConsultarPrecios.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbMonedaParaConsultarPrecios.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbMonedaParaConsultarPrecios.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbMonedaParaConsultarPrecios.FormattingEnabled = True
        Me.cmbMonedaParaConsultarPrecios.IsPK = False
        Me.cmbMonedaParaConsultarPrecios.IsRequired = False
        Me.cmbMonedaParaConsultarPrecios.Items.AddRange(New Object() {"del producto"})
        Me.cmbMonedaParaConsultarPrecios.Key = Nothing
        Me.cmbMonedaParaConsultarPrecios.LabelAsoc = Me.lblMonedaParaConsultarPrecios
        Me.cmbMonedaParaConsultarPrecios.Location = New System.Drawing.Point(738, 299)
        Me.cmbMonedaParaConsultarPrecios.Name = "cmbMonedaParaConsultarPrecios"
        Me.cmbMonedaParaConsultarPrecios.Size = New System.Drawing.Size(127, 21)
        Me.cmbMonedaParaConsultarPrecios.TabIndex = 20
        '
        'cmbListaDePreciosPredeterminada
        '
        Me.cmbListaDePreciosPredeterminada.BindearPropiedadControl = Nothing
        Me.cmbListaDePreciosPredeterminada.BindearPropiedadEntidad = Nothing
        Me.cmbListaDePreciosPredeterminada.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbListaDePreciosPredeterminada.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbListaDePreciosPredeterminada.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbListaDePreciosPredeterminada.FormattingEnabled = True
        Me.cmbListaDePreciosPredeterminada.IsPK = False
        Me.cmbListaDePreciosPredeterminada.IsRequired = False
        Me.cmbListaDePreciosPredeterminada.Items.AddRange(New Object() {"WEB", "DonWeb", "Para Sucursales", "Para Clientes", "Qendra", "WebExperto", "iTegra/Kretz"})
        Me.cmbListaDePreciosPredeterminada.Key = Nothing
        Me.cmbListaDePreciosPredeterminada.LabelAsoc = Me.lblListaDePreciosPredeterminada
        Me.cmbListaDePreciosPredeterminada.Location = New System.Drawing.Point(167, 252)
        Me.cmbListaDePreciosPredeterminada.Name = "cmbListaDePreciosPredeterminada"
        Me.cmbListaDePreciosPredeterminada.Size = New System.Drawing.Size(149, 21)
        Me.cmbListaDePreciosPredeterminada.TabIndex = 11
        Me.cmbListaDePreciosPredeterminada.Tag = "LISTAPRECIOSPREDETERMINADA"
        '
        'ucConfPrecios
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.grbModificarPrecioPorArribaPrecioLista)
        Me.Controls.Add(Me.grbModificarPrecioPorDebajoPrecioLista)
        Me.Controls.Add(Me.lblMonedaParaConsultarPrecios)
        Me.Controls.Add(Me.grpPreciosPriorizaCodigoYDescripcion)
        Me.Controls.Add(Me.chbActualizaPrecioCostoPorTipoDeCambio)
        Me.Controls.Add(Me.lblListaDePreciosPredeterminada)
        Me.Controls.Add(Me.chbMarcarTodos)
        Me.Controls.Add(Me.grbFTP)
        Me.Controls.Add(Me.grbActualizarPreciosCalculo)
        Me.Controls.Add(Me.txtCotizacionDolar)
        Me.Controls.Add(Me.lblCantidadDecimalesEnVenta)
        Me.Controls.Add(Me.chbActualizarPreciosMostrarCodigoProductoProveedor)
        Me.Controls.Add(Me.chbConsultarPreciosProdNoAfectanStock)
        Me.Controls.Add(Me.chbConsultarPreciosConEmbalaje)
        Me.Controls.Add(Me.chbPreciosUnificarEntreSucursales)
        Me.Controls.Add(Me.lblCotizacionDolar)
        Me.Controls.Add(Me.chbUtilizaPrecioDeCompra)
        Me.Controls.Add(Me.cmbListaDePreciosPredeterminada)
        Me.Controls.Add(Me.txtCantidadDecimalesEnVenta)
        Me.Controls.Add(Me.cmbMonedaParaConsultarPrecios)
        Me.Controls.Add(Me.chbMuestraFechaActualiza)
        Me.Controls.Add(Me.chbConsultarPreciosConIVA)
        Me.Name = "ucConfPrecios"
        Me.Controls.SetChildIndex(Me.chbConsultarPreciosConIVA, 0)
        Me.Controls.SetChildIndex(Me.chbMuestraFechaActualiza, 0)
        Me.Controls.SetChildIndex(Me.cmbMonedaParaConsultarPrecios, 0)
        Me.Controls.SetChildIndex(Me.txtCantidadDecimalesEnVenta, 0)
        Me.Controls.SetChildIndex(Me.cmbListaDePreciosPredeterminada, 0)
        Me.Controls.SetChildIndex(Me.chbUtilizaPrecioDeCompra, 0)
        Me.Controls.SetChildIndex(Me.lblCotizacionDolar, 0)
        Me.Controls.SetChildIndex(Me.chbPreciosUnificarEntreSucursales, 0)
        Me.Controls.SetChildIndex(Me.chbConsultarPreciosConEmbalaje, 0)
        Me.Controls.SetChildIndex(Me.chbConsultarPreciosProdNoAfectanStock, 0)
        Me.Controls.SetChildIndex(Me.chbActualizarPreciosMostrarCodigoProductoProveedor, 0)
        Me.Controls.SetChildIndex(Me.lblCantidadDecimalesEnVenta, 0)
        Me.Controls.SetChildIndex(Me.txtCotizacionDolar, 0)
        Me.Controls.SetChildIndex(Me.grbActualizarPreciosCalculo, 0)
        Me.Controls.SetChildIndex(Me.grbFTP, 0)
        Me.Controls.SetChildIndex(Me.chbMarcarTodos, 0)
        Me.Controls.SetChildIndex(Me.lblListaDePreciosPredeterminada, 0)
        Me.Controls.SetChildIndex(Me.chbActualizaPrecioCostoPorTipoDeCambio, 0)
        Me.Controls.SetChildIndex(Me.grpPreciosPriorizaCodigoYDescripcion, 0)
        Me.Controls.SetChildIndex(Me.lblMonedaParaConsultarPrecios, 0)
        Me.Controls.SetChildIndex(Me.grbModificarPrecioPorDebajoPrecioLista, 0)
        Me.Controls.SetChildIndex(Me.grbModificarPrecioPorArribaPrecioLista, 0)
        Me.grbModificarPrecioPorArribaPrecioLista.ResumeLayout(False)
        Me.grbModificarPrecioPorArribaPrecioLista.PerformLayout()
        Me.grbModificarPrecioPorDebajoPrecioLista.ResumeLayout(False)
        Me.grbModificarPrecioPorDebajoPrecioLista.PerformLayout()
        Me.grpPreciosPriorizaCodigoYDescripcion.ResumeLayout(False)
        Me.pnlCodigoDescripcion.ResumeLayout(False)
        Me.pnlCodigoDescripcion.PerformLayout()
        Me.grbFTP.ResumeLayout(False)
        Me.grbFTP.PerformLayout()
        Me.grbActualizarPreciosCalculo.ResumeLayout(False)
        Me.grbActualizarPreciosCalculo.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents chbMuestraFechaActualiza As Controles.CheckBox
   Friend WithEvents grbModificarPrecioPorArribaPrecioLista As GroupBox
   Friend WithEvents Label28 As Controles.Label
   Friend WithEvents txtPorcentajePrecioPorArribaPL As Controles.TextBox
   Friend WithEvents lblPorcentajePrecioPorArribaPL As Controles.Label
   Friend WithEvents rbtPrecioPorArribaAvisaryPermitir As RadioButton
   Friend WithEvents rbtPrecioPorArribaNoPermitir As RadioButton
   Friend WithEvents rbtPrecioPorArribaPermitir As RadioButton
   Friend WithEvents grbModificarPrecioPorDebajoPrecioLista As GroupBox
   Friend WithEvents Label27 As Controles.Label
   Friend WithEvents txtPorcentajePrecioPorDebajoPL As Controles.TextBox
   Friend WithEvents lblPorcentajePrecioPorDebajoPL As Controles.Label
   Friend WithEvents rbtPrecioPorDebajoAvisaryPermitir As RadioButton
   Friend WithEvents rbtPrecioPorDebajoNoPermitir As RadioButton
   Friend WithEvents rbtPrecioPorDebajoPermitir As RadioButton
   Friend WithEvents lblMonedaParaConsultarPrecios As Controles.Label
   Friend WithEvents grpPreciosPriorizaCodigoYDescripcion As GroupBox
   Friend WithEvents pnlCodigoDescripcion As FlowLayoutPanel
   Friend WithEvents radCodigoYDescripcion As RadioButton
   Friend WithEvents radCodigoODescripcion As RadioButton
   Friend WithEvents chbActualizaPrecioCostoPorTipoDeCambio As Controles.CheckBox
   Friend WithEvents lblListaDePreciosPredeterminada As Controles.Label
   Friend WithEvents chbMarcarTodos As Controles.CheckBox
   Friend WithEvents grbFTP As GroupBox
   Friend WithEvents chbFTPUtilizaCarpetaSecundaria As Controles.CheckBox
   Friend WithEvents txtFTPCarpetaRemota As Controles.TextBox
   Friend WithEvents lblCarpetaRemota As Controles.Label
   Friend WithEvents cmbFTPFormato As Controles.ComboBox
   Friend WithEvents lblFTPFormato As Controles.Label
   Friend WithEvents txtFTPNombreArchivo As Controles.TextBox
   Friend WithEvents lblFTPNombreArchivo As Controles.Label
   Friend WithEvents Button1 As Controles.Button
   Friend WithEvents chbFTPConexionPasiva As Controles.CheckBox
   Friend WithEvents txtFTPPassword As Controles.TextBox
   Friend WithEvents lblFTPPassword As Controles.Label
   Friend WithEvents txtFTPUsuario As Controles.TextBox
   Friend WithEvents lblFTPUsuario As Controles.Label
   Friend WithEvents txtFTPServidor As Controles.TextBox
   Friend WithEvents lblFTPServidor As Controles.Label
   Friend WithEvents grbActualizarPreciosCalculo As GroupBox
   Friend WithEvents rbtDesdeFormula As RadioButton
   Friend WithEvents rbtSobreCosto As RadioButton
   Friend WithEvents rbtSobreVenta As RadioButton
   Friend WithEvents rbtPorcActual As RadioButton
   Friend WithEvents txtCantidadDecimalesEnVenta As Controles.TextBox
   Friend WithEvents lblCantidadDecimalesEnVenta As Controles.Label
   Friend WithEvents txtCotizacionDolar As Controles.TextBox
   Friend WithEvents lblCotizacionDolar As Controles.Label
   Friend WithEvents chbActualizarPreciosMostrarCodigoProductoProveedor As Controles.CheckBox
   Friend WithEvents chbConsultarPreciosProdNoAfectanStock As Controles.CheckBox
   Friend WithEvents chbConsultarPreciosConEmbalaje As Controles.CheckBox
   Friend WithEvents chbPreciosUnificarEntreSucursales As Controles.CheckBox
   Friend WithEvents chbConsultarPreciosConIVA As Controles.CheckBox
   Friend WithEvents chbUtilizaPrecioDeCompra As Controles.CheckBox
   Friend WithEvents cmbMonedaParaConsultarPrecios As Controles.ComboBox
   Friend WithEvents cmbListaDePreciosPredeterminada As Controles.ComboBox
End Class
