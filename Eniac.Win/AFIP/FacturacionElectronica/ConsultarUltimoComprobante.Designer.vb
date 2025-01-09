<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class ConsultarUltimoComprobante
    Inherits BaseForm

    'Form reemplaza a Dispose para limpiar la lista de componentes.
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

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.tstBarra = New System.Windows.Forms.ToolStrip()
        Me.tsbAplicar = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsbSalir = New System.Windows.Forms.ToolStripButton()
        Me.stsStado = New System.Windows.Forms.StatusStrip()
        Me.tssInfo = New System.Windows.Forms.ToolStripStatusLabel()
        Me.tspBarra = New System.Windows.Forms.ToolStripProgressBar()
        Me.tssRegistros = New System.Windows.Forms.ToolStripStatusLabel()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.lblEmisor = New Eniac.Controles.Label()
        Me.lblLetra = New Eniac.Controles.Label()
        Me.lblTipoComprobante = New Eniac.Controles.Label()
        Me.txtUltimoNroComprobante = New Eniac.Controles.TextBox()
        Me.cmbTiposComprobantes = New Eniac.Controles.ComboBox()
        Me.txtEmisor = New Eniac.Controles.TextBox()
        Me.btnObtener = New Eniac.Controles.Button()
        Me.cmbLetra = New Eniac.Controles.ComboBox()
        Me.grbDatosComprobante = New System.Windows.Forms.GroupBox()
        Me.lblIVA = New Eniac.Controles.Label()
        Me.txtIVA = New Eniac.Controles.TextBox()
        Me.lblNeto = New Eniac.Controles.Label()
        Me.txtNeto = New Eniac.Controles.TextBox()
        Me.lblObservaciones = New Eniac.Controles.Label()
        Me.txtObservaciones = New Eniac.Controles.TextBox()
        Me.lblImporteTotal = New Eniac.Controles.Label()
        Me.txtImporteTotal = New Eniac.Controles.TextBox()
        Me.lblVenCAE = New Eniac.Controles.Label()
        Me.txtVenCAE = New Eniac.Controles.TextBox()
        Me.lblCAE = New Eniac.Controles.Label()
        Me.txtCAE = New Eniac.Controles.TextBox()
        Me.lblCliente = New Eniac.Controles.Label()
        Me.txtCliente = New Eniac.Controles.TextBox()
        Me.lblNroDoc = New Eniac.Controles.Label()
        Me.txtNroDoc = New Eniac.Controles.TextBox()
        Me.lblTipoDoc = New Eniac.Controles.Label()
        Me.txtTipoDoc = New Eniac.Controles.TextBox()
        Me.lblFecha = New Eniac.Controles.Label()
        Me.txtFecha = New Eniac.Controles.TextBox()
        Me.tstBarra.SuspendLayout()
        Me.stsStado.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.grbDatosComprobante.SuspendLayout()
        Me.SuspendLayout()
        '
        'tstBarra
        '
        Me.tstBarra.AllowItemReorder = True
        Me.tstBarra.ImageScalingSize = New System.Drawing.Size(22, 22)
        Me.tstBarra.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsbAplicar, Me.ToolStripSeparator1, Me.tsbSalir})
        Me.tstBarra.Location = New System.Drawing.Point(0, 0)
        Me.tstBarra.Name = "tstBarra"
        Me.tstBarra.Size = New System.Drawing.Size(534, 29)
        Me.tstBarra.TabIndex = 3
        Me.tstBarra.Text = "toolStrip1"
        '
        'tsbAplicar
        '
        Me.tsbAplicar.Image = Global.Eniac.Win.My.Resources.Resources.note_edit
        Me.tsbAplicar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbAplicar.Name = "tsbAplicar"
        Me.tsbAplicar.Size = New System.Drawing.Size(132, 26)
        Me.tsbAplicar.Text = "&Aplicar último nro."
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 29)
        '
        'tsbSalir
        '
        Me.tsbSalir.Image = Global.Eniac.Win.My.Resources.Resources.close_b_32
        Me.tsbSalir.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbSalir.Name = "tsbSalir"
        Me.tsbSalir.Size = New System.Drawing.Size(65, 26)
        Me.tsbSalir.Text = "&Cerrar"
        Me.tsbSalir.ToolTipText = "Cerrar el formulario"
        '
        'stsStado
        '
        Me.stsStado.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tssInfo, Me.tspBarra, Me.tssRegistros})
        Me.stsStado.Location = New System.Drawing.Point(0, 319)
        Me.stsStado.Name = "stsStado"
        Me.stsStado.Size = New System.Drawing.Size(534, 22)
        Me.stsStado.TabIndex = 2
        Me.stsStado.Text = "statusStrip1"
        '
        'tssInfo
        '
        Me.tssInfo.Name = "tssInfo"
        Me.tssInfo.Size = New System.Drawing.Size(519, 17)
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
        Me.tssRegistros.Size = New System.Drawing.Size(0, 17)
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.lblEmisor)
        Me.GroupBox1.Controls.Add(Me.lblLetra)
        Me.GroupBox1.Controls.Add(Me.lblTipoComprobante)
        Me.GroupBox1.Controls.Add(Me.txtUltimoNroComprobante)
        Me.GroupBox1.Controls.Add(Me.cmbTiposComprobantes)
        Me.GroupBox1.Controls.Add(Me.txtEmisor)
        Me.GroupBox1.Controls.Add(Me.btnObtener)
        Me.GroupBox1.Controls.Add(Me.cmbLetra)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 32)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(505, 88)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Último número de comprobante"
        '
        'lblEmisor
        '
        Me.lblEmisor.AutoSize = True
        Me.lblEmisor.LabelAsoc = Nothing
        Me.lblEmisor.Location = New System.Drawing.Point(234, 26)
        Me.lblEmisor.Name = "lblEmisor"
        Me.lblEmisor.Size = New System.Drawing.Size(38, 13)
        Me.lblEmisor.TabIndex = 4
        Me.lblEmisor.Text = "Emisor"
        '
        'lblLetra
        '
        Me.lblLetra.AutoSize = True
        Me.lblLetra.LabelAsoc = Nothing
        Me.lblLetra.Location = New System.Drawing.Point(178, 26)
        Me.lblLetra.Name = "lblLetra"
        Me.lblLetra.Size = New System.Drawing.Size(31, 13)
        Me.lblLetra.TabIndex = 2
        Me.lblLetra.Text = "Letra"
        '
        'lblTipoComprobante
        '
        Me.lblTipoComprobante.AutoSize = True
        Me.lblTipoComprobante.LabelAsoc = Nothing
        Me.lblTipoComprobante.Location = New System.Drawing.Point(14, 26)
        Me.lblTipoComprobante.Name = "lblTipoComprobante"
        Me.lblTipoComprobante.Size = New System.Drawing.Size(94, 13)
        Me.lblTipoComprobante.TabIndex = 0
        Me.lblTipoComprobante.Text = "Tipo Comprobante"
        '
        'txtUltimoNroComprobante
        '
        Me.txtUltimoNroComprobante.BindearPropiedadControl = Nothing
        Me.txtUltimoNroComprobante.BindearPropiedadEntidad = Nothing
        Me.txtUltimoNroComprobante.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtUltimoNroComprobante.ForeColorFocus = System.Drawing.Color.Red
        Me.txtUltimoNroComprobante.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtUltimoNroComprobante.Formato = ""
        Me.txtUltimoNroComprobante.IsDecimal = False
        Me.txtUltimoNroComprobante.IsNumber = False
        Me.txtUltimoNroComprobante.IsPK = False
        Me.txtUltimoNroComprobante.IsRequired = False
        Me.txtUltimoNroComprobante.Key = ""
        Me.txtUltimoNroComprobante.LabelAsoc = Nothing
        Me.txtUltimoNroComprobante.Location = New System.Drawing.Point(380, 37)
        Me.txtUltimoNroComprobante.Name = "txtUltimoNroComprobante"
        Me.txtUltimoNroComprobante.ReadOnly = True
        Me.txtUltimoNroComprobante.Size = New System.Drawing.Size(107, 26)
        Me.txtUltimoNroComprobante.TabIndex = 7
        Me.txtUltimoNroComprobante.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'cmbTiposComprobantes
        '
        Me.cmbTiposComprobantes.BindearPropiedadControl = Nothing
        Me.cmbTiposComprobantes.BindearPropiedadEntidad = Nothing
        Me.cmbTiposComprobantes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbTiposComprobantes.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.cmbTiposComprobantes.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbTiposComprobantes.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbTiposComprobantes.FormattingEnabled = True
        Me.cmbTiposComprobantes.IsPK = False
        Me.cmbTiposComprobantes.IsRequired = False
        Me.cmbTiposComprobantes.Key = Nothing
        Me.cmbTiposComprobantes.LabelAsoc = Me.lblTipoComprobante
        Me.cmbTiposComprobantes.Location = New System.Drawing.Point(17, 42)
        Me.cmbTiposComprobantes.Name = "cmbTiposComprobantes"
        Me.cmbTiposComprobantes.Size = New System.Drawing.Size(154, 21)
        Me.cmbTiposComprobantes.TabIndex = 1
        '
        'txtEmisor
        '
        Me.txtEmisor.BackColor = System.Drawing.Color.White
        Me.txtEmisor.BindearPropiedadControl = Nothing
        Me.txtEmisor.BindearPropiedadEntidad = Nothing
        Me.txtEmisor.ForeColorFocus = System.Drawing.Color.Red
        Me.txtEmisor.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtEmisor.Formato = "#"
        Me.txtEmisor.IsDecimal = False
        Me.txtEmisor.IsNumber = True
        Me.txtEmisor.IsPK = False
        Me.txtEmisor.IsRequired = True
        Me.txtEmisor.Key = ""
        Me.txtEmisor.LabelAsoc = Me.lblEmisor
        Me.txtEmisor.Location = New System.Drawing.Point(231, 42)
        Me.txtEmisor.MaxLength = 4
        Me.txtEmisor.Name = "txtEmisor"
        Me.txtEmisor.Size = New System.Drawing.Size(41, 20)
        Me.txtEmisor.TabIndex = 5
        Me.txtEmisor.Text = "0"
        Me.txtEmisor.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'btnObtener
        '
        Me.btnObtener.Image = Global.Eniac.Win.My.Resources.Resources.view
        Me.btnObtener.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnObtener.Location = New System.Drawing.Point(278, 26)
        Me.btnObtener.Name = "btnObtener"
        Me.btnObtener.Size = New System.Drawing.Size(96, 45)
        Me.btnObtener.TabIndex = 6
        Me.btnObtener.Text = "&Consultar"
        Me.btnObtener.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnObtener.UseVisualStyleBackColor = True
        '
        'cmbLetra
        '
        Me.cmbLetra.BindearPropiedadControl = Nothing
        Me.cmbLetra.BindearPropiedadEntidad = Nothing
        Me.cmbLetra.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbLetra.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbLetra.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbLetra.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbLetra.FormattingEnabled = True
        Me.cmbLetra.IsPK = False
        Me.cmbLetra.IsRequired = False
        Me.cmbLetra.Key = Nothing
        Me.cmbLetra.LabelAsoc = Me.lblLetra
        Me.cmbLetra.Location = New System.Drawing.Point(177, 42)
        Me.cmbLetra.Name = "cmbLetra"
        Me.cmbLetra.Size = New System.Drawing.Size(48, 21)
        Me.cmbLetra.TabIndex = 3
        '
        'grbDatosComprobante
        '
        Me.grbDatosComprobante.Controls.Add(Me.lblIVA)
        Me.grbDatosComprobante.Controls.Add(Me.txtIVA)
        Me.grbDatosComprobante.Controls.Add(Me.lblNeto)
        Me.grbDatosComprobante.Controls.Add(Me.txtNeto)
        Me.grbDatosComprobante.Controls.Add(Me.lblObservaciones)
        Me.grbDatosComprobante.Controls.Add(Me.txtObservaciones)
        Me.grbDatosComprobante.Controls.Add(Me.lblImporteTotal)
        Me.grbDatosComprobante.Controls.Add(Me.txtImporteTotal)
        Me.grbDatosComprobante.Controls.Add(Me.lblVenCAE)
        Me.grbDatosComprobante.Controls.Add(Me.txtVenCAE)
        Me.grbDatosComprobante.Controls.Add(Me.lblCAE)
        Me.grbDatosComprobante.Controls.Add(Me.txtCAE)
        Me.grbDatosComprobante.Controls.Add(Me.lblCliente)
        Me.grbDatosComprobante.Controls.Add(Me.txtCliente)
        Me.grbDatosComprobante.Controls.Add(Me.lblNroDoc)
        Me.grbDatosComprobante.Controls.Add(Me.txtNroDoc)
        Me.grbDatosComprobante.Controls.Add(Me.lblTipoDoc)
        Me.grbDatosComprobante.Controls.Add(Me.txtTipoDoc)
        Me.grbDatosComprobante.Controls.Add(Me.lblFecha)
        Me.grbDatosComprobante.Controls.Add(Me.txtFecha)
        Me.grbDatosComprobante.Location = New System.Drawing.Point(13, 126)
        Me.grbDatosComprobante.Name = "grbDatosComprobante"
        Me.grbDatosComprobante.Size = New System.Drawing.Size(504, 184)
        Me.grbDatosComprobante.TabIndex = 1
        Me.grbDatosComprobante.TabStop = False
        Me.grbDatosComprobante.Text = "Datos Comprobante"
        '
        'lblIVA
        '
        Me.lblIVA.AutoSize = True
        Me.lblIVA.LabelAsoc = Nothing
        Me.lblIVA.Location = New System.Drawing.Point(318, 59)
        Me.lblIVA.Name = "lblIVA"
        Me.lblIVA.Size = New System.Drawing.Size(24, 13)
        Me.lblIVA.TabIndex = 24
        Me.lblIVA.Text = "IVA"
        '
        'txtIVA
        '
        Me.txtIVA.BackColor = System.Drawing.Color.White
        Me.txtIVA.BindearPropiedadControl = Nothing
        Me.txtIVA.BindearPropiedadEntidad = Nothing
        Me.txtIVA.ForeColorFocus = System.Drawing.Color.Red
        Me.txtIVA.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtIVA.Formato = "#"
        Me.txtIVA.IsDecimal = False
        Me.txtIVA.IsNumber = False
        Me.txtIVA.IsPK = False
        Me.txtIVA.IsRequired = False
        Me.txtIVA.Key = ""
        Me.txtIVA.LabelAsoc = Me.lblIVA
        Me.txtIVA.Location = New System.Drawing.Point(321, 75)
        Me.txtIVA.MaxLength = 4
        Me.txtIVA.Name = "txtIVA"
        Me.txtIVA.ReadOnly = True
        Me.txtIVA.Size = New System.Drawing.Size(83, 20)
        Me.txtIVA.TabIndex = 7
        Me.txtIVA.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblNeto
        '
        Me.lblNeto.AutoSize = True
        Me.lblNeto.LabelAsoc = Nothing
        Me.lblNeto.Location = New System.Drawing.Point(229, 59)
        Me.lblNeto.Name = "lblNeto"
        Me.lblNeto.Size = New System.Drawing.Size(30, 13)
        Me.lblNeto.TabIndex = 22
        Me.lblNeto.Text = "Neto"
        '
        'txtNeto
        '
        Me.txtNeto.BackColor = System.Drawing.Color.White
        Me.txtNeto.BindearPropiedadControl = Nothing
        Me.txtNeto.BindearPropiedadEntidad = Nothing
        Me.txtNeto.ForeColorFocus = System.Drawing.Color.Red
        Me.txtNeto.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtNeto.Formato = "#"
        Me.txtNeto.IsDecimal = False
        Me.txtNeto.IsNumber = False
        Me.txtNeto.IsPK = False
        Me.txtNeto.IsRequired = False
        Me.txtNeto.Key = ""
        Me.txtNeto.LabelAsoc = Me.lblNeto
        Me.txtNeto.Location = New System.Drawing.Point(232, 75)
        Me.txtNeto.MaxLength = 4
        Me.txtNeto.Name = "txtNeto"
        Me.txtNeto.ReadOnly = True
        Me.txtNeto.Size = New System.Drawing.Size(83, 20)
        Me.txtNeto.TabIndex = 6
        Me.txtNeto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblObservaciones
        '
        Me.lblObservaciones.AutoSize = True
        Me.lblObservaciones.LabelAsoc = Nothing
        Me.lblObservaciones.Location = New System.Drawing.Point(13, 102)
        Me.lblObservaciones.Name = "lblObservaciones"
        Me.lblObservaciones.Size = New System.Drawing.Size(78, 13)
        Me.lblObservaciones.TabIndex = 20
        Me.lblObservaciones.Text = "Observaciones"
        '
        'txtObservaciones
        '
        Me.txtObservaciones.BackColor = System.Drawing.Color.White
        Me.txtObservaciones.BindearPropiedadControl = Nothing
        Me.txtObservaciones.BindearPropiedadEntidad = Nothing
        Me.txtObservaciones.ForeColorFocus = System.Drawing.Color.Red
        Me.txtObservaciones.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtObservaciones.Formato = "#"
        Me.txtObservaciones.IsDecimal = False
        Me.txtObservaciones.IsNumber = False
        Me.txtObservaciones.IsPK = False
        Me.txtObservaciones.IsRequired = False
        Me.txtObservaciones.Key = ""
        Me.txtObservaciones.LabelAsoc = Me.lblObservaciones
        Me.txtObservaciones.Location = New System.Drawing.Point(16, 118)
        Me.txtObservaciones.MaxLength = 4
        Me.txtObservaciones.Multiline = True
        Me.txtObservaciones.Name = "txtObservaciones"
        Me.txtObservaciones.ReadOnly = True
        Me.txtObservaciones.Size = New System.Drawing.Size(482, 60)
        Me.txtObservaciones.TabIndex = 9
        '
        'lblImporteTotal
        '
        Me.lblImporteTotal.AutoSize = True
        Me.lblImporteTotal.LabelAsoc = Nothing
        Me.lblImporteTotal.Location = New System.Drawing.Point(412, 59)
        Me.lblImporteTotal.Name = "lblImporteTotal"
        Me.lblImporteTotal.Size = New System.Drawing.Size(64, 13)
        Me.lblImporteTotal.TabIndex = 18
        Me.lblImporteTotal.Text = "Monto Total"
        '
        'txtImporteTotal
        '
        Me.txtImporteTotal.BackColor = System.Drawing.Color.White
        Me.txtImporteTotal.BindearPropiedadControl = Nothing
        Me.txtImporteTotal.BindearPropiedadEntidad = Nothing
        Me.txtImporteTotal.ForeColorFocus = System.Drawing.Color.Red
        Me.txtImporteTotal.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtImporteTotal.Formato = "#"
        Me.txtImporteTotal.IsDecimal = False
        Me.txtImporteTotal.IsNumber = False
        Me.txtImporteTotal.IsPK = False
        Me.txtImporteTotal.IsRequired = False
        Me.txtImporteTotal.Key = ""
        Me.txtImporteTotal.LabelAsoc = Me.lblImporteTotal
        Me.txtImporteTotal.Location = New System.Drawing.Point(415, 75)
        Me.txtImporteTotal.MaxLength = 4
        Me.txtImporteTotal.Name = "txtImporteTotal"
        Me.txtImporteTotal.ReadOnly = True
        Me.txtImporteTotal.Size = New System.Drawing.Size(83, 20)
        Me.txtImporteTotal.TabIndex = 8
        Me.txtImporteTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblVenCAE
        '
        Me.lblVenCAE.AutoSize = True
        Me.lblVenCAE.LabelAsoc = Nothing
        Me.lblVenCAE.Location = New System.Drawing.Point(140, 59)
        Me.lblVenCAE.Name = "lblVenCAE"
        Me.lblVenCAE.Size = New System.Drawing.Size(59, 13)
        Me.lblVenCAE.TabIndex = 16
        Me.lblVenCAE.Text = "Venc. CAE"
        '
        'txtVenCAE
        '
        Me.txtVenCAE.BackColor = System.Drawing.Color.White
        Me.txtVenCAE.BindearPropiedadControl = Nothing
        Me.txtVenCAE.BindearPropiedadEntidad = Nothing
        Me.txtVenCAE.ForeColorFocus = System.Drawing.Color.Red
        Me.txtVenCAE.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtVenCAE.Formato = "#"
        Me.txtVenCAE.IsDecimal = False
        Me.txtVenCAE.IsNumber = False
        Me.txtVenCAE.IsPK = False
        Me.txtVenCAE.IsRequired = False
        Me.txtVenCAE.Key = ""
        Me.txtVenCAE.LabelAsoc = Me.lblVenCAE
        Me.txtVenCAE.Location = New System.Drawing.Point(143, 75)
        Me.txtVenCAE.MaxLength = 4
        Me.txtVenCAE.Name = "txtVenCAE"
        Me.txtVenCAE.ReadOnly = True
        Me.txtVenCAE.Size = New System.Drawing.Size(83, 20)
        Me.txtVenCAE.TabIndex = 5
        '
        'lblCAE
        '
        Me.lblCAE.AutoSize = True
        Me.lblCAE.LabelAsoc = Nothing
        Me.lblCAE.Location = New System.Drawing.Point(13, 59)
        Me.lblCAE.Name = "lblCAE"
        Me.lblCAE.Size = New System.Drawing.Size(28, 13)
        Me.lblCAE.TabIndex = 14
        Me.lblCAE.Text = "CAE"
        '
        'txtCAE
        '
        Me.txtCAE.BackColor = System.Drawing.Color.White
        Me.txtCAE.BindearPropiedadControl = Nothing
        Me.txtCAE.BindearPropiedadEntidad = Nothing
        Me.txtCAE.ForeColorFocus = System.Drawing.Color.Red
        Me.txtCAE.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtCAE.Formato = "#"
        Me.txtCAE.IsDecimal = False
        Me.txtCAE.IsNumber = False
        Me.txtCAE.IsPK = False
        Me.txtCAE.IsRequired = False
        Me.txtCAE.Key = ""
        Me.txtCAE.LabelAsoc = Me.lblCAE
        Me.txtCAE.Location = New System.Drawing.Point(16, 75)
        Me.txtCAE.MaxLength = 4
        Me.txtCAE.Name = "txtCAE"
        Me.txtCAE.ReadOnly = True
        Me.txtCAE.Size = New System.Drawing.Size(118, 20)
        Me.txtCAE.TabIndex = 4
        '
        'lblCliente
        '
        Me.lblCliente.AutoSize = True
        Me.lblCliente.LabelAsoc = Nothing
        Me.lblCliente.Location = New System.Drawing.Point(262, 18)
        Me.lblCliente.Name = "lblCliente"
        Me.lblCliente.Size = New System.Drawing.Size(39, 13)
        Me.lblCliente.TabIndex = 12
        Me.lblCliente.Text = "Cliente"
        '
        'txtCliente
        '
        Me.txtCliente.BackColor = System.Drawing.Color.White
        Me.txtCliente.BindearPropiedadControl = Nothing
        Me.txtCliente.BindearPropiedadEntidad = Nothing
        Me.txtCliente.ForeColorFocus = System.Drawing.Color.Red
        Me.txtCliente.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtCliente.Formato = "#"
        Me.txtCliente.IsDecimal = False
        Me.txtCliente.IsNumber = False
        Me.txtCliente.IsPK = False
        Me.txtCliente.IsRequired = False
        Me.txtCliente.Key = ""
        Me.txtCliente.LabelAsoc = Me.lblCliente
        Me.txtCliente.Location = New System.Drawing.Point(265, 34)
        Me.txtCliente.MaxLength = 4
        Me.txtCliente.Name = "txtCliente"
        Me.txtCliente.ReadOnly = True
        Me.txtCliente.Size = New System.Drawing.Size(233, 20)
        Me.txtCliente.TabIndex = 3
        '
        'lblNroDoc
        '
        Me.lblNroDoc.AutoSize = True
        Me.lblNroDoc.LabelAsoc = Nothing
        Me.lblNroDoc.Location = New System.Drawing.Point(173, 18)
        Me.lblNroDoc.Name = "lblNroDoc"
        Me.lblNroDoc.Size = New System.Drawing.Size(53, 13)
        Me.lblNroDoc.TabIndex = 10
        Me.lblNroDoc.Text = "Nro. Doc."
        '
        'txtNroDoc
        '
        Me.txtNroDoc.BackColor = System.Drawing.Color.White
        Me.txtNroDoc.BindearPropiedadControl = Nothing
        Me.txtNroDoc.BindearPropiedadEntidad = Nothing
        Me.txtNroDoc.ForeColorFocus = System.Drawing.Color.Red
        Me.txtNroDoc.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtNroDoc.Formato = "#"
        Me.txtNroDoc.IsDecimal = False
        Me.txtNroDoc.IsNumber = False
        Me.txtNroDoc.IsPK = False
        Me.txtNroDoc.IsRequired = False
        Me.txtNroDoc.Key = ""
        Me.txtNroDoc.LabelAsoc = Me.lblNroDoc
        Me.txtNroDoc.Location = New System.Drawing.Point(176, 34)
        Me.txtNroDoc.MaxLength = 4
        Me.txtNroDoc.Name = "txtNroDoc"
        Me.txtNroDoc.ReadOnly = True
        Me.txtNroDoc.Size = New System.Drawing.Size(83, 20)
        Me.txtNroDoc.TabIndex = 2
        '
        'lblTipoDoc
        '
        Me.lblTipoDoc.AutoSize = True
        Me.lblTipoDoc.LabelAsoc = Nothing
        Me.lblTipoDoc.Location = New System.Drawing.Point(102, 18)
        Me.lblTipoDoc.Name = "lblTipoDoc"
        Me.lblTipoDoc.Size = New System.Drawing.Size(54, 13)
        Me.lblTipoDoc.TabIndex = 8
        Me.lblTipoDoc.Text = "Tipo Doc."
        '
        'txtTipoDoc
        '
        Me.txtTipoDoc.BackColor = System.Drawing.Color.White
        Me.txtTipoDoc.BindearPropiedadControl = Nothing
        Me.txtTipoDoc.BindearPropiedadEntidad = Nothing
        Me.txtTipoDoc.ForeColorFocus = System.Drawing.Color.Red
        Me.txtTipoDoc.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtTipoDoc.Formato = "#"
        Me.txtTipoDoc.IsDecimal = False
        Me.txtTipoDoc.IsNumber = False
        Me.txtTipoDoc.IsPK = False
        Me.txtTipoDoc.IsRequired = False
        Me.txtTipoDoc.Key = ""
        Me.txtTipoDoc.LabelAsoc = Me.lblTipoDoc
        Me.txtTipoDoc.Location = New System.Drawing.Point(105, 34)
        Me.txtTipoDoc.MaxLength = 4
        Me.txtTipoDoc.Name = "txtTipoDoc"
        Me.txtTipoDoc.ReadOnly = True
        Me.txtTipoDoc.Size = New System.Drawing.Size(65, 20)
        Me.txtTipoDoc.TabIndex = 1
        '
        'lblFecha
        '
        Me.lblFecha.AutoSize = True
        Me.lblFecha.LabelAsoc = Nothing
        Me.lblFecha.Location = New System.Drawing.Point(13, 18)
        Me.lblFecha.Name = "lblFecha"
        Me.lblFecha.Size = New System.Drawing.Size(37, 13)
        Me.lblFecha.TabIndex = 6
        Me.lblFecha.Text = "Fecha"
        '
        'txtFecha
        '
        Me.txtFecha.BackColor = System.Drawing.Color.White
        Me.txtFecha.BindearPropiedadControl = Nothing
        Me.txtFecha.BindearPropiedadEntidad = Nothing
        Me.txtFecha.ForeColorFocus = System.Drawing.Color.Red
        Me.txtFecha.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtFecha.Formato = "#"
        Me.txtFecha.IsDecimal = False
        Me.txtFecha.IsNumber = False
        Me.txtFecha.IsPK = False
        Me.txtFecha.IsRequired = False
        Me.txtFecha.Key = ""
        Me.txtFecha.LabelAsoc = Me.lblFecha
        Me.txtFecha.Location = New System.Drawing.Point(16, 34)
        Me.txtFecha.MaxLength = 4
        Me.txtFecha.Name = "txtFecha"
        Me.txtFecha.ReadOnly = True
        Me.txtFecha.Size = New System.Drawing.Size(83, 20)
        Me.txtFecha.TabIndex = 0
        '
        'ConsultarUltimoComprobante
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(534, 341)
        Me.Controls.Add(Me.grbDatosComprobante)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.stsStado)
        Me.Controls.Add(Me.tstBarra)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "ConsultarUltimoComprobante"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Consultar Ultimo Comprobante en AFIP"
        Me.tstBarra.ResumeLayout(False)
        Me.tstBarra.PerformLayout()
        Me.stsStado.ResumeLayout(False)
        Me.stsStado.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.grbDatosComprobante.ResumeLayout(False)
        Me.grbDatosComprobante.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Public WithEvents tstBarra As System.Windows.Forms.ToolStrip
    Public WithEvents tsbSalir As System.Windows.Forms.ToolStripButton
    Protected Friend WithEvents stsStado As System.Windows.Forms.StatusStrip
    Protected Friend WithEvents tssInfo As System.Windows.Forms.ToolStripStatusLabel
    Protected Friend WithEvents tspBarra As System.Windows.Forms.ToolStripProgressBar
    Protected WithEvents tssRegistros As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents txtUltimoNroComprobante As Eniac.Controles.TextBox
    Friend WithEvents btnObtener As Eniac.Controles.Button
    Friend WithEvents cmbTiposComprobantes As Eniac.Controles.ComboBox
    Friend WithEvents txtEmisor As Eniac.Controles.TextBox
    Friend WithEvents cmbLetra As Eniac.Controles.ComboBox
    Friend WithEvents lblTipoComprobante As Eniac.Controles.Label
    Friend WithEvents lblEmisor As Eniac.Controles.Label
    Friend WithEvents lblLetra As Eniac.Controles.Label
    Friend WithEvents tsbAplicar As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents grbDatosComprobante As System.Windows.Forms.GroupBox
    Friend WithEvents lblFecha As Eniac.Controles.Label
    Friend WithEvents txtFecha As Eniac.Controles.TextBox
    Friend WithEvents lblTipoDoc As Eniac.Controles.Label
    Friend WithEvents txtTipoDoc As Eniac.Controles.TextBox
    Friend WithEvents lblCliente As Eniac.Controles.Label
    Friend WithEvents txtCliente As Eniac.Controles.TextBox
    Friend WithEvents lblNroDoc As Eniac.Controles.Label
    Friend WithEvents txtNroDoc As Eniac.Controles.TextBox
    Friend WithEvents lblVenCAE As Eniac.Controles.Label
    Friend WithEvents txtVenCAE As Eniac.Controles.TextBox
    Friend WithEvents lblCAE As Eniac.Controles.Label
    Friend WithEvents txtCAE As Eniac.Controles.TextBox
    Friend WithEvents lblImporteTotal As Eniac.Controles.Label
    Friend WithEvents txtImporteTotal As Eniac.Controles.TextBox
    Friend WithEvents lblObservaciones As Eniac.Controles.Label
    Friend WithEvents txtObservaciones As Eniac.Controles.TextBox
    Friend WithEvents lblIVA As Eniac.Controles.Label
    Friend WithEvents txtIVA As Eniac.Controles.TextBox
    Friend WithEvents lblNeto As Eniac.Controles.Label
    Friend WithEvents txtNeto As Eniac.Controles.TextBox
End Class
