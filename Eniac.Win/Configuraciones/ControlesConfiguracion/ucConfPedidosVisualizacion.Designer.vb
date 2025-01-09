<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ucConfPedidosVisualizacion
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
      Me.GroupBox6 = New System.Windows.Forms.GroupBox()
        Me.lblVisualizaPrecioPedido = New Eniac.Controles.Label()
        Me.cmbVisualizaPrecioPedido = New Eniac.Controles.ComboBox()
        Me.lblMonedaPrecioPorTamano = New Eniac.Controles.Label()
        Me.chbPedidosMuestraProvHabitual = New Eniac.Controles.CheckBox()
        Me.chbPedidosMostrarCriticidad = New Eniac.Controles.CheckBox()
        Me.cmbMonedaPrecioPorTamano = New Eniac.Controles.ComboBox()
        Me.chbPedidosMostrarUM = New Eniac.Controles.CheckBox()
        Me.chbPedidosMostrarNota = New Eniac.Controles.CheckBox()
        Me.chbPedidosMostrarFormula = New Eniac.Controles.CheckBox()
        Me.chbPedidosMostrarUrlPlanoDetalle = New Eniac.Controles.CheckBox()
        Me.chbProductoModeloForma = New Eniac.Controles.CheckBox()
        Me.chbProductoArchitrave = New Eniac.Controles.CheckBox()
        Me.chbProductoAnchoIntBase = New Eniac.Controles.CheckBox()
        Me.chbProductoLargoExtAlto = New Eniac.Controles.CheckBox()
        Me.chbProductoProduccionForma = New Eniac.Controles.CheckBox()
        Me.chbProductoProduccionProceso = New Eniac.Controles.CheckBox()
        Me.chbProductoSAE = New Eniac.Controles.CheckBox()
        Me.chbProductoEspPulgadas = New Eniac.Controles.CheckBox()
        Me.chbProductoEspmm = New Eniac.Controles.CheckBox()
        Me.chbPedidosMostrarTamano = New Eniac.Controles.CheckBox()
        Me.chbPedidosMostrarPrecioVentaPorTamano = New Eniac.Controles.CheckBox()
        Me.chbPedidosMostrarSemaforoRentabilidadDetalle = New Eniac.Controles.CheckBox()
        Me.chbPedidosMostrarMoneda = New Eniac.Controles.CheckBox()
        Me.chbPedidosMostrarCosto = New Eniac.Controles.CheckBox()
        Me.GroupBox13 = New System.Windows.Forms.GroupBox()
        Me.txtPedidosDecimalesMostrarLargoAncho = New Eniac.Controles.TextBox()
        Me.lblPedidosDecimalesMostrarLargoAncho = New Eniac.Controles.Label()
        Me.chbPedidosMuestraTotalMasIVA = New Eniac.Controles.CheckBox()
        Me.GroupBox6.SuspendLayout()
        Me.GroupBox13.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox6
        '
        Me.GroupBox6.Controls.Add(Me.chbPedidosMuestraTotalMasIVA)
        Me.GroupBox6.Controls.Add(Me.lblVisualizaPrecioPedido)
        Me.GroupBox6.Controls.Add(Me.cmbVisualizaPrecioPedido)
        Me.GroupBox6.Controls.Add(Me.chbPedidosMuestraProvHabitual)
        Me.GroupBox6.Controls.Add(Me.chbPedidosMostrarCriticidad)
        Me.GroupBox6.Controls.Add(Me.cmbMonedaPrecioPorTamano)
        Me.GroupBox6.Controls.Add(Me.lblMonedaPrecioPorTamano)
        Me.GroupBox6.Controls.Add(Me.chbPedidosMostrarUM)
        Me.GroupBox6.Controls.Add(Me.chbPedidosMostrarNota)
        Me.GroupBox6.Controls.Add(Me.chbPedidosMostrarFormula)
        Me.GroupBox6.Controls.Add(Me.chbPedidosMostrarUrlPlanoDetalle)
        Me.GroupBox6.Controls.Add(Me.chbProductoModeloForma)
        Me.GroupBox6.Controls.Add(Me.chbProductoArchitrave)
        Me.GroupBox6.Controls.Add(Me.chbProductoAnchoIntBase)
        Me.GroupBox6.Controls.Add(Me.chbProductoLargoExtAlto)
        Me.GroupBox6.Controls.Add(Me.chbProductoProduccionForma)
        Me.GroupBox6.Controls.Add(Me.chbProductoProduccionProceso)
        Me.GroupBox6.Controls.Add(Me.chbProductoSAE)
        Me.GroupBox6.Controls.Add(Me.chbProductoEspPulgadas)
        Me.GroupBox6.Controls.Add(Me.chbProductoEspmm)
        Me.GroupBox6.Controls.Add(Me.chbPedidosMostrarTamano)
        Me.GroupBox6.Controls.Add(Me.chbPedidosMostrarPrecioVentaPorTamano)
        Me.GroupBox6.Controls.Add(Me.chbPedidosMostrarSemaforoRentabilidadDetalle)
        Me.GroupBox6.Controls.Add(Me.chbPedidosMostrarMoneda)
        Me.GroupBox6.Controls.Add(Me.chbPedidosMostrarCosto)
        Me.GroupBox6.Location = New System.Drawing.Point(33, 80)
        Me.GroupBox6.Name = "GroupBox6"
        Me.GroupBox6.Size = New System.Drawing.Size(454, 277)
        Me.GroupBox6.TabIndex = 1
        Me.GroupBox6.TabStop = False
        Me.GroupBox6.Text = "Columnas del detalle de pedidos a mostrar"
        '
        'lblVisualizaPrecioPedido
        '
        Me.lblVisualizaPrecioPedido.AutoSize = True
        Me.lblVisualizaPrecioPedido.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblVisualizaPrecioPedido.LabelAsoc = Nothing
        Me.lblVisualizaPrecioPedido.Location = New System.Drawing.Point(14, 226)
        Me.lblVisualizaPrecioPedido.Name = "lblVisualizaPrecioPedido"
        Me.lblVisualizaPrecioPedido.Size = New System.Drawing.Size(143, 13)
        Me.lblVisualizaPrecioPedido.TabIndex = 2
        Me.lblVisualizaPrecioPedido.Text = "Visualiza Precios en Dólares "
        '
        'cmbVisualizaPrecioPedido
        '
        Me.cmbVisualizaPrecioPedido.BindearPropiedadControl = Nothing
        Me.cmbVisualizaPrecioPedido.BindearPropiedadEntidad = Nothing
        Me.cmbVisualizaPrecioPedido.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbVisualizaPrecioPedido.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbVisualizaPrecioPedido.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbVisualizaPrecioPedido.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbVisualizaPrecioPedido.FormattingEnabled = True
        Me.cmbVisualizaPrecioPedido.IsPK = False
        Me.cmbVisualizaPrecioPedido.IsRequired = False
        Me.cmbVisualizaPrecioPedido.Key = Nothing
        Me.cmbVisualizaPrecioPedido.LabelAsoc = Me.lblMonedaPrecioPorTamano
        Me.cmbVisualizaPrecioPedido.Location = New System.Drawing.Point(163, 223)
        Me.cmbVisualizaPrecioPedido.Name = "cmbVisualizaPrecioPedido"
        Me.cmbVisualizaPrecioPedido.Size = New System.Drawing.Size(145, 21)
        Me.cmbVisualizaPrecioPedido.TabIndex = 23
        '
        'lblMonedaPrecioPorTamano
        '
        Me.lblMonedaPrecioPorTamano.AutoSize = True
        Me.lblMonedaPrecioPorTamano.LabelAsoc = Nothing
        Me.lblMonedaPrecioPorTamano.Location = New System.Drawing.Point(170, 66)
        Me.lblMonedaPrecioPorTamano.Name = "lblMonedaPrecioPorTamano"
        Me.lblMonedaPrecioPorTamano.Size = New System.Drawing.Size(49, 13)
        Me.lblMonedaPrecioPorTamano.TabIndex = 3
        Me.lblMonedaPrecioPorTamano.Text = "Moneda:"
        '
        'chbPedidosMuestraProvHabitual
        '
        Me.chbPedidosMuestraProvHabitual.AutoSize = True
        Me.chbPedidosMuestraProvHabitual.BindearPropiedadControl = Nothing
        Me.chbPedidosMuestraProvHabitual.BindearPropiedadEntidad = Nothing
        Me.chbPedidosMuestraProvHabitual.Checked = True
        Me.chbPedidosMuestraProvHabitual.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chbPedidosMuestraProvHabitual.ForeColorFocus = System.Drawing.Color.Red
        Me.chbPedidosMuestraProvHabitual.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbPedidosMuestraProvHabitual.IsPK = False
        Me.chbPedidosMuestraProvHabitual.IsRequired = False
        Me.chbPedidosMuestraProvHabitual.Key = Nothing
        Me.chbPedidosMuestraProvHabitual.LabelAsoc = Nothing
        Me.chbPedidosMuestraProvHabitual.Location = New System.Drawing.Point(314, 248)
        Me.chbPedidosMuestraProvHabitual.Name = "chbPedidosMuestraProvHabitual"
        Me.chbPedidosMuestraProvHabitual.Size = New System.Drawing.Size(93, 17)
        Me.chbPedidosMuestraProvHabitual.TabIndex = 21
        Me.chbPedidosMuestraProvHabitual.Tag = ""
        Me.chbPedidosMuestraProvHabitual.Text = "Prov. Habitual"
        Me.chbPedidosMuestraProvHabitual.UseVisualStyleBackColor = True
        '
        'chbPedidosMostrarCriticidad
        '
        Me.chbPedidosMostrarCriticidad.AutoSize = True
        Me.chbPedidosMostrarCriticidad.BindearPropiedadControl = Nothing
        Me.chbPedidosMostrarCriticidad.BindearPropiedadEntidad = Nothing
        Me.chbPedidosMostrarCriticidad.Checked = True
        Me.chbPedidosMostrarCriticidad.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chbPedidosMostrarCriticidad.ForeColorFocus = System.Drawing.Color.Red
        Me.chbPedidosMostrarCriticidad.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbPedidosMostrarCriticidad.IsPK = False
        Me.chbPedidosMostrarCriticidad.IsRequired = False
        Me.chbPedidosMostrarCriticidad.Key = Nothing
        Me.chbPedidosMostrarCriticidad.LabelAsoc = Nothing
        Me.chbPedidosMostrarCriticidad.Location = New System.Drawing.Point(17, 110)
        Me.chbPedidosMostrarCriticidad.Name = "chbPedidosMostrarCriticidad"
        Me.chbPedidosMostrarCriticidad.Size = New System.Drawing.Size(69, 17)
        Me.chbPedidosMostrarCriticidad.TabIndex = 6
        Me.chbPedidosMostrarCriticidad.Tag = "PEDIDOSMOSTRARCRITICIDAD"
        Me.chbPedidosMostrarCriticidad.Text = "Criticidad"
        Me.chbPedidosMostrarCriticidad.UseVisualStyleBackColor = True
        '
        'cmbMonedaPrecioPorTamano
        '
        Me.cmbMonedaPrecioPorTamano.BindearPropiedadControl = Nothing
        Me.cmbMonedaPrecioPorTamano.BindearPropiedadEntidad = Nothing
        Me.cmbMonedaPrecioPorTamano.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbMonedaPrecioPorTamano.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbMonedaPrecioPorTamano.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbMonedaPrecioPorTamano.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbMonedaPrecioPorTamano.FormattingEnabled = True
        Me.cmbMonedaPrecioPorTamano.IsPK = False
        Me.cmbMonedaPrecioPorTamano.IsRequired = False
        Me.cmbMonedaPrecioPorTamano.Key = Nothing
        Me.cmbMonedaPrecioPorTamano.LabelAsoc = Me.lblMonedaPrecioPorTamano
        Me.cmbMonedaPrecioPorTamano.Location = New System.Drawing.Point(225, 62)
        Me.cmbMonedaPrecioPorTamano.Name = "cmbMonedaPrecioPorTamano"
        Me.cmbMonedaPrecioPorTamano.Size = New System.Drawing.Size(83, 21)
        Me.cmbMonedaPrecioPorTamano.TabIndex = 4
        '
        'chbPedidosMostrarUM
        '
        Me.chbPedidosMostrarUM.AutoSize = True
        Me.chbPedidosMostrarUM.BindearPropiedadControl = Nothing
        Me.chbPedidosMostrarUM.BindearPropiedadEntidad = Nothing
        Me.chbPedidosMostrarUM.Checked = True
        Me.chbPedidosMostrarUM.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chbPedidosMostrarUM.ForeColorFocus = System.Drawing.Color.Red
        Me.chbPedidosMostrarUM.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbPedidosMostrarUM.IsPK = False
        Me.chbPedidosMostrarUM.IsRequired = False
        Me.chbPedidosMostrarUM.Key = Nothing
        Me.chbPedidosMostrarUM.LabelAsoc = Nothing
        Me.chbPedidosMostrarUM.Location = New System.Drawing.Point(17, 42)
        Me.chbPedidosMostrarUM.Name = "chbPedidosMostrarUM"
        Me.chbPedidosMostrarUM.Size = New System.Drawing.Size(113, 17)
        Me.chbPedidosMostrarUM.TabIndex = 1
        Me.chbPedidosMostrarUM.Text = "Unidad de Medida"
        Me.chbPedidosMostrarUM.UseVisualStyleBackColor = True
        '
        'chbPedidosMostrarNota
        '
        Me.chbPedidosMostrarNota.AutoSize = True
        Me.chbPedidosMostrarNota.BindearPropiedadControl = Nothing
        Me.chbPedidosMostrarNota.BindearPropiedadEntidad = Nothing
        Me.chbPedidosMostrarNota.Checked = True
        Me.chbPedidosMostrarNota.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chbPedidosMostrarNota.ForeColorFocus = System.Drawing.Color.Red
        Me.chbPedidosMostrarNota.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbPedidosMostrarNota.IsPK = False
        Me.chbPedidosMostrarNota.IsRequired = False
        Me.chbPedidosMostrarNota.Key = Nothing
        Me.chbPedidosMostrarNota.LabelAsoc = Nothing
        Me.chbPedidosMostrarNota.Location = New System.Drawing.Point(314, 225)
        Me.chbPedidosMostrarNota.Name = "chbPedidosMostrarNota"
        Me.chbPedidosMostrarNota.Size = New System.Drawing.Size(49, 17)
        Me.chbPedidosMostrarNota.TabIndex = 20
        Me.chbPedidosMostrarNota.Text = "Nota"
        Me.chbPedidosMostrarNota.UseVisualStyleBackColor = True
        '
        'chbPedidosMostrarFormula
        '
        Me.chbPedidosMostrarFormula.AutoSize = True
        Me.chbPedidosMostrarFormula.BindearPropiedadControl = Nothing
        Me.chbPedidosMostrarFormula.BindearPropiedadEntidad = Nothing
        Me.chbPedidosMostrarFormula.Checked = True
        Me.chbPedidosMostrarFormula.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chbPedidosMostrarFormula.ForeColorFocus = System.Drawing.Color.Red
        Me.chbPedidosMostrarFormula.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbPedidosMostrarFormula.IsPK = False
        Me.chbPedidosMostrarFormula.IsRequired = False
        Me.chbPedidosMostrarFormula.Key = Nothing
        Me.chbPedidosMostrarFormula.LabelAsoc = Nothing
        Me.chbPedidosMostrarFormula.Location = New System.Drawing.Point(314, 202)
        Me.chbPedidosMostrarFormula.Name = "chbPedidosMostrarFormula"
        Me.chbPedidosMostrarFormula.Size = New System.Drawing.Size(134, 17)
        Me.chbPedidosMostrarFormula.TabIndex = 19
        Me.chbPedidosMostrarFormula.Text = "Formula de producción"
        Me.chbPedidosMostrarFormula.UseVisualStyleBackColor = True
        '
        'chbPedidosMostrarUrlPlanoDetalle
        '
        Me.chbPedidosMostrarUrlPlanoDetalle.AutoSize = True
        Me.chbPedidosMostrarUrlPlanoDetalle.BindearPropiedadControl = Nothing
        Me.chbPedidosMostrarUrlPlanoDetalle.BindearPropiedadEntidad = Nothing
        Me.chbPedidosMostrarUrlPlanoDetalle.Checked = True
        Me.chbPedidosMostrarUrlPlanoDetalle.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chbPedidosMostrarUrlPlanoDetalle.ForeColorFocus = System.Drawing.Color.Red
        Me.chbPedidosMostrarUrlPlanoDetalle.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbPedidosMostrarUrlPlanoDetalle.IsPK = False
        Me.chbPedidosMostrarUrlPlanoDetalle.IsRequired = False
        Me.chbPedidosMostrarUrlPlanoDetalle.Key = Nothing
        Me.chbPedidosMostrarUrlPlanoDetalle.LabelAsoc = Nothing
        Me.chbPedidosMostrarUrlPlanoDetalle.Location = New System.Drawing.Point(314, 179)
        Me.chbPedidosMostrarUrlPlanoDetalle.Name = "chbPedidosMostrarUrlPlanoDetalle"
        Me.chbPedidosMostrarUrlPlanoDetalle.Size = New System.Drawing.Size(78, 17)
        Me.chbPedidosMostrarUrlPlanoDetalle.TabIndex = 18
        Me.chbPedidosMostrarUrlPlanoDetalle.Text = "URL Plano"
        Me.chbPedidosMostrarUrlPlanoDetalle.UseVisualStyleBackColor = True
        '
        'chbProductoModeloForma
        '
        Me.chbProductoModeloForma.AutoSize = True
        Me.chbProductoModeloForma.BindearPropiedadControl = Nothing
        Me.chbProductoModeloForma.BindearPropiedadEntidad = Nothing
        Me.chbProductoModeloForma.Checked = True
        Me.chbProductoModeloForma.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chbProductoModeloForma.ForeColorFocus = System.Drawing.Color.Red
        Me.chbProductoModeloForma.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbProductoModeloForma.IsPK = False
        Me.chbProductoModeloForma.IsRequired = False
        Me.chbProductoModeloForma.Key = Nothing
        Me.chbProductoModeloForma.LabelAsoc = Nothing
        Me.chbProductoModeloForma.Location = New System.Drawing.Point(314, 155)
        Me.chbProductoModeloForma.Name = "chbProductoModeloForma"
        Me.chbProductoModeloForma.Size = New System.Drawing.Size(93, 17)
        Me.chbProductoModeloForma.TabIndex = 17
        Me.chbProductoModeloForma.Text = "Modelo Forma"
        Me.chbProductoModeloForma.UseVisualStyleBackColor = True
        '
        'chbProductoArchitrave
        '
        Me.chbProductoArchitrave.AutoSize = True
        Me.chbProductoArchitrave.BindearPropiedadControl = Nothing
        Me.chbProductoArchitrave.BindearPropiedadEntidad = Nothing
        Me.chbProductoArchitrave.Checked = True
        Me.chbProductoArchitrave.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chbProductoArchitrave.ForeColorFocus = System.Drawing.Color.Red
        Me.chbProductoArchitrave.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbProductoArchitrave.IsPK = False
        Me.chbProductoArchitrave.IsRequired = False
        Me.chbProductoArchitrave.Key = Nothing
        Me.chbProductoArchitrave.LabelAsoc = Nothing
        Me.chbProductoArchitrave.Location = New System.Drawing.Point(314, 132)
        Me.chbProductoArchitrave.Name = "chbProductoArchitrave"
        Me.chbProductoArchitrave.Size = New System.Drawing.Size(74, 17)
        Me.chbProductoArchitrave.TabIndex = 16
        Me.chbProductoArchitrave.Text = "Architrave"
        Me.chbProductoArchitrave.UseVisualStyleBackColor = True
        '
        'chbProductoAnchoIntBase
        '
        Me.chbProductoAnchoIntBase.AutoSize = True
        Me.chbProductoAnchoIntBase.BindearPropiedadControl = Nothing
        Me.chbProductoAnchoIntBase.BindearPropiedadEntidad = Nothing
        Me.chbProductoAnchoIntBase.Checked = True
        Me.chbProductoAnchoIntBase.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chbProductoAnchoIntBase.ForeColorFocus = System.Drawing.Color.Red
        Me.chbProductoAnchoIntBase.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbProductoAnchoIntBase.IsPK = False
        Me.chbProductoAnchoIntBase.IsRequired = False
        Me.chbProductoAnchoIntBase.Key = Nothing
        Me.chbProductoAnchoIntBase.LabelAsoc = Nothing
        Me.chbProductoAnchoIntBase.Location = New System.Drawing.Point(314, 109)
        Me.chbProductoAnchoIntBase.Name = "chbProductoAnchoIntBase"
        Me.chbProductoAnchoIntBase.Size = New System.Drawing.Size(97, 17)
        Me.chbProductoAnchoIntBase.TabIndex = 15
        Me.chbProductoAnchoIntBase.Text = "Ancho Øi Base"
        Me.chbProductoAnchoIntBase.UseVisualStyleBackColor = True
        '
        'chbProductoLargoExtAlto
        '
        Me.chbProductoLargoExtAlto.AutoSize = True
        Me.chbProductoLargoExtAlto.BindearPropiedadControl = Nothing
        Me.chbProductoLargoExtAlto.BindearPropiedadEntidad = Nothing
        Me.chbProductoLargoExtAlto.Checked = True
        Me.chbProductoLargoExtAlto.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chbProductoLargoExtAlto.ForeColorFocus = System.Drawing.Color.Red
        Me.chbProductoLargoExtAlto.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbProductoLargoExtAlto.IsPK = False
        Me.chbProductoLargoExtAlto.IsRequired = False
        Me.chbProductoLargoExtAlto.Key = Nothing
        Me.chbProductoLargoExtAlto.LabelAsoc = Nothing
        Me.chbProductoLargoExtAlto.Location = New System.Drawing.Point(314, 86)
        Me.chbProductoLargoExtAlto.Name = "chbProductoLargoExtAlto"
        Me.chbProductoLargoExtAlto.Size = New System.Drawing.Size(91, 17)
        Me.chbProductoLargoExtAlto.TabIndex = 14
        Me.chbProductoLargoExtAlto.Text = "Largo Øe Alto"
        Me.chbProductoLargoExtAlto.UseVisualStyleBackColor = True
        '
        'chbProductoProduccionForma
        '
        Me.chbProductoProduccionForma.AutoSize = True
        Me.chbProductoProduccionForma.BindearPropiedadControl = Nothing
        Me.chbProductoProduccionForma.BindearPropiedadEntidad = Nothing
        Me.chbProductoProduccionForma.Checked = True
        Me.chbProductoProduccionForma.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chbProductoProduccionForma.ForeColorFocus = System.Drawing.Color.Red
        Me.chbProductoProduccionForma.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbProductoProduccionForma.IsPK = False
        Me.chbProductoProduccionForma.IsRequired = False
        Me.chbProductoProduccionForma.Key = Nothing
        Me.chbProductoProduccionForma.LabelAsoc = Nothing
        Me.chbProductoProduccionForma.Location = New System.Drawing.Point(314, 65)
        Me.chbProductoProduccionForma.Name = "chbProductoProduccionForma"
        Me.chbProductoProduccionForma.Size = New System.Drawing.Size(55, 17)
        Me.chbProductoProduccionForma.TabIndex = 13
        Me.chbProductoProduccionForma.Text = "Forma"
        Me.chbProductoProduccionForma.UseVisualStyleBackColor = True
        '
        'chbProductoProduccionProceso
        '
        Me.chbProductoProduccionProceso.AutoSize = True
        Me.chbProductoProduccionProceso.BindearPropiedadControl = Nothing
        Me.chbProductoProduccionProceso.BindearPropiedadEntidad = Nothing
        Me.chbProductoProduccionProceso.Checked = True
        Me.chbProductoProduccionProceso.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chbProductoProduccionProceso.ForeColorFocus = System.Drawing.Color.Red
        Me.chbProductoProduccionProceso.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbProductoProduccionProceso.IsPK = False
        Me.chbProductoProduccionProceso.IsRequired = False
        Me.chbProductoProduccionProceso.Key = Nothing
        Me.chbProductoProduccionProceso.LabelAsoc = Nothing
        Me.chbProductoProduccionProceso.Location = New System.Drawing.Point(314, 42)
        Me.chbProductoProduccionProceso.Name = "chbProductoProduccionProceso"
        Me.chbProductoProduccionProceso.Size = New System.Drawing.Size(65, 17)
        Me.chbProductoProduccionProceso.TabIndex = 12
        Me.chbProductoProduccionProceso.Text = "Proceso"
        Me.chbProductoProduccionProceso.UseVisualStyleBackColor = True
        '
        'chbProductoSAE
        '
        Me.chbProductoSAE.AutoSize = True
        Me.chbProductoSAE.BindearPropiedadControl = Nothing
        Me.chbProductoSAE.BindearPropiedadEntidad = Nothing
        Me.chbProductoSAE.Checked = True
        Me.chbProductoSAE.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chbProductoSAE.ForeColorFocus = System.Drawing.Color.Red
        Me.chbProductoSAE.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbProductoSAE.IsPK = False
        Me.chbProductoSAE.IsRequired = False
        Me.chbProductoSAE.Key = Nothing
        Me.chbProductoSAE.LabelAsoc = Nothing
        Me.chbProductoSAE.Location = New System.Drawing.Point(314, 19)
        Me.chbProductoSAE.Name = "chbProductoSAE"
        Me.chbProductoSAE.Size = New System.Drawing.Size(47, 17)
        Me.chbProductoSAE.TabIndex = 11
        Me.chbProductoSAE.Text = "SAE"
        Me.chbProductoSAE.UseVisualStyleBackColor = True
        '
        'chbProductoEspPulgadas
        '
        Me.chbProductoEspPulgadas.AutoSize = True
        Me.chbProductoEspPulgadas.BindearPropiedadControl = Nothing
        Me.chbProductoEspPulgadas.BindearPropiedadEntidad = Nothing
        Me.chbProductoEspPulgadas.Checked = True
        Me.chbProductoEspPulgadas.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chbProductoEspPulgadas.ForeColorFocus = System.Drawing.Color.Red
        Me.chbProductoEspPulgadas.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbProductoEspPulgadas.IsPK = False
        Me.chbProductoEspPulgadas.IsRequired = False
        Me.chbProductoEspPulgadas.Key = Nothing
        Me.chbProductoEspPulgadas.LabelAsoc = Nothing
        Me.chbProductoEspPulgadas.Location = New System.Drawing.Point(17, 179)
        Me.chbProductoEspPulgadas.Name = "chbProductoEspPulgadas"
        Me.chbProductoEspPulgadas.Size = New System.Drawing.Size(55, 17)
        Me.chbProductoEspPulgadas.TabIndex = 9
        Me.chbProductoEspPulgadas.Text = "Esp. """
        Me.chbProductoEspPulgadas.UseVisualStyleBackColor = True
        '
        'chbProductoEspmm
        '
        Me.chbProductoEspmm.AutoSize = True
        Me.chbProductoEspmm.BindearPropiedadControl = Nothing
        Me.chbProductoEspmm.BindearPropiedadEntidad = Nothing
        Me.chbProductoEspmm.Checked = True
        Me.chbProductoEspmm.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chbProductoEspmm.ForeColorFocus = System.Drawing.Color.Red
        Me.chbProductoEspmm.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbProductoEspmm.IsPK = False
        Me.chbProductoEspmm.IsRequired = False
        Me.chbProductoEspmm.Key = Nothing
        Me.chbProductoEspmm.LabelAsoc = Nothing
        Me.chbProductoEspmm.Location = New System.Drawing.Point(17, 202)
        Me.chbProductoEspmm.Name = "chbProductoEspmm"
        Me.chbProductoEspmm.Size = New System.Drawing.Size(66, 17)
        Me.chbProductoEspmm.TabIndex = 10
        Me.chbProductoEspmm.Text = "Esp. mm"
        Me.chbProductoEspmm.UseVisualStyleBackColor = True
        '
        'chbPedidosMostrarTamano
        '
        Me.chbPedidosMostrarTamano.AutoSize = True
        Me.chbPedidosMostrarTamano.BindearPropiedadControl = Nothing
        Me.chbPedidosMostrarTamano.BindearPropiedadEntidad = Nothing
        Me.chbPedidosMostrarTamano.Checked = True
        Me.chbPedidosMostrarTamano.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chbPedidosMostrarTamano.ForeColorFocus = System.Drawing.Color.Red
        Me.chbPedidosMostrarTamano.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbPedidosMostrarTamano.IsPK = False
        Me.chbPedidosMostrarTamano.IsRequired = False
        Me.chbPedidosMostrarTamano.Key = Nothing
        Me.chbPedidosMostrarTamano.LabelAsoc = Nothing
        Me.chbPedidosMostrarTamano.Location = New System.Drawing.Point(17, 19)
        Me.chbPedidosMostrarTamano.Name = "chbPedidosMostrarTamano"
        Me.chbPedidosMostrarTamano.Size = New System.Drawing.Size(65, 17)
        Me.chbPedidosMostrarTamano.TabIndex = 0
        Me.chbPedidosMostrarTamano.Text = "Tamaño"
        Me.chbPedidosMostrarTamano.UseVisualStyleBackColor = True
        '
        'chbPedidosMostrarPrecioVentaPorTamano
        '
        Me.chbPedidosMostrarPrecioVentaPorTamano.AutoSize = True
        Me.chbPedidosMostrarPrecioVentaPorTamano.BindearPropiedadControl = Nothing
        Me.chbPedidosMostrarPrecioVentaPorTamano.BindearPropiedadEntidad = Nothing
        Me.chbPedidosMostrarPrecioVentaPorTamano.Checked = True
        Me.chbPedidosMostrarPrecioVentaPorTamano.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chbPedidosMostrarPrecioVentaPorTamano.ForeColorFocus = System.Drawing.Color.Red
        Me.chbPedidosMostrarPrecioVentaPorTamano.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbPedidosMostrarPrecioVentaPorTamano.IsPK = False
        Me.chbPedidosMostrarPrecioVentaPorTamano.IsRequired = False
        Me.chbPedidosMostrarPrecioVentaPorTamano.Key = Nothing
        Me.chbPedidosMostrarPrecioVentaPorTamano.LabelAsoc = Nothing
        Me.chbPedidosMostrarPrecioVentaPorTamano.Location = New System.Drawing.Point(17, 65)
        Me.chbPedidosMostrarPrecioVentaPorTamano.Name = "chbPedidosMostrarPrecioVentaPorTamano"
        Me.chbPedidosMostrarPrecioVentaPorTamano.Size = New System.Drawing.Size(147, 17)
        Me.chbPedidosMostrarPrecioVentaPorTamano.TabIndex = 2
        Me.chbPedidosMostrarPrecioVentaPorTamano.Text = "Precio Venta por Tamaño"
        Me.chbPedidosMostrarPrecioVentaPorTamano.UseVisualStyleBackColor = True
        '
        'chbPedidosMostrarSemaforoRentabilidadDetalle
        '
        Me.chbPedidosMostrarSemaforoRentabilidadDetalle.AutoSize = True
        Me.chbPedidosMostrarSemaforoRentabilidadDetalle.BindearPropiedadControl = Nothing
        Me.chbPedidosMostrarSemaforoRentabilidadDetalle.BindearPropiedadEntidad = Nothing
        Me.chbPedidosMostrarSemaforoRentabilidadDetalle.Checked = True
        Me.chbPedidosMostrarSemaforoRentabilidadDetalle.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chbPedidosMostrarSemaforoRentabilidadDetalle.ForeColorFocus = System.Drawing.Color.Red
        Me.chbPedidosMostrarSemaforoRentabilidadDetalle.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbPedidosMostrarSemaforoRentabilidadDetalle.IsPK = False
        Me.chbPedidosMostrarSemaforoRentabilidadDetalle.IsRequired = False
        Me.chbPedidosMostrarSemaforoRentabilidadDetalle.Key = Nothing
        Me.chbPedidosMostrarSemaforoRentabilidadDetalle.LabelAsoc = Nothing
        Me.chbPedidosMostrarSemaforoRentabilidadDetalle.Location = New System.Drawing.Point(17, 156)
        Me.chbPedidosMostrarSemaforoRentabilidadDetalle.Name = "chbPedidosMostrarSemaforoRentabilidadDetalle"
        Me.chbPedidosMostrarSemaforoRentabilidadDetalle.Size = New System.Drawing.Size(198, 17)
        Me.chbPedidosMostrarSemaforoRentabilidadDetalle.TabIndex = 8
        Me.chbPedidosMostrarSemaforoRentabilidadDetalle.Text = "Rentabilidad / Contribución Marginal"
        Me.chbPedidosMostrarSemaforoRentabilidadDetalle.UseVisualStyleBackColor = True
        '
        'chbPedidosMostrarMoneda
        '
        Me.chbPedidosMostrarMoneda.AutoSize = True
        Me.chbPedidosMostrarMoneda.BindearPropiedadControl = Nothing
        Me.chbPedidosMostrarMoneda.BindearPropiedadEntidad = Nothing
        Me.chbPedidosMostrarMoneda.Checked = True
        Me.chbPedidosMostrarMoneda.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chbPedidosMostrarMoneda.ForeColorFocus = System.Drawing.Color.Red
        Me.chbPedidosMostrarMoneda.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbPedidosMostrarMoneda.IsPK = False
        Me.chbPedidosMostrarMoneda.IsRequired = False
        Me.chbPedidosMostrarMoneda.Key = Nothing
        Me.chbPedidosMostrarMoneda.LabelAsoc = Nothing
        Me.chbPedidosMostrarMoneda.Location = New System.Drawing.Point(17, 133)
        Me.chbPedidosMostrarMoneda.Name = "chbPedidosMostrarMoneda"
        Me.chbPedidosMostrarMoneda.Size = New System.Drawing.Size(65, 17)
        Me.chbPedidosMostrarMoneda.TabIndex = 7
        Me.chbPedidosMostrarMoneda.Text = "Moneda"
        Me.chbPedidosMostrarMoneda.UseVisualStyleBackColor = True
        '
        'chbPedidosMostrarCosto
        '
        Me.chbPedidosMostrarCosto.AutoSize = True
        Me.chbPedidosMostrarCosto.BindearPropiedadControl = Nothing
        Me.chbPedidosMostrarCosto.BindearPropiedadEntidad = Nothing
        Me.chbPedidosMostrarCosto.Checked = True
        Me.chbPedidosMostrarCosto.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chbPedidosMostrarCosto.ForeColorFocus = System.Drawing.Color.Red
        Me.chbPedidosMostrarCosto.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbPedidosMostrarCosto.IsPK = False
        Me.chbPedidosMostrarCosto.IsRequired = False
        Me.chbPedidosMostrarCosto.Key = Nothing
        Me.chbPedidosMostrarCosto.LabelAsoc = Nothing
        Me.chbPedidosMostrarCosto.Location = New System.Drawing.Point(17, 88)
        Me.chbPedidosMostrarCosto.Name = "chbPedidosMostrarCosto"
        Me.chbPedidosMostrarCosto.Size = New System.Drawing.Size(101, 17)
        Me.chbPedidosMostrarCosto.TabIndex = 5
        Me.chbPedidosMostrarCosto.Text = "Precio de Costo"
        Me.chbPedidosMostrarCosto.UseVisualStyleBackColor = True
        '
        'GroupBox13
        '
        Me.GroupBox13.Controls.Add(Me.txtPedidosDecimalesMostrarLargoAncho)
        Me.GroupBox13.Controls.Add(Me.lblPedidosDecimalesMostrarLargoAncho)
        Me.GroupBox13.Location = New System.Drawing.Point(33, 22)
        Me.GroupBox13.Name = "GroupBox13"
        Me.GroupBox13.Size = New System.Drawing.Size(380, 52)
        Me.GroupBox13.TabIndex = 0
        Me.GroupBox13.TabStop = False
        Me.GroupBox13.Text = "Cantidad de decimales"
        '
        'txtPedidosDecimalesMostrarLargoAncho
        '
        Me.txtPedidosDecimalesMostrarLargoAncho.BindearPropiedadControl = Nothing
        Me.txtPedidosDecimalesMostrarLargoAncho.BindearPropiedadEntidad = Nothing
        Me.txtPedidosDecimalesMostrarLargoAncho.ForeColorFocus = System.Drawing.Color.Red
        Me.txtPedidosDecimalesMostrarLargoAncho.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtPedidosDecimalesMostrarLargoAncho.Formato = ""
        Me.txtPedidosDecimalesMostrarLargoAncho.IsDecimal = False
        Me.txtPedidosDecimalesMostrarLargoAncho.IsNumber = True
        Me.txtPedidosDecimalesMostrarLargoAncho.IsPK = False
        Me.txtPedidosDecimalesMostrarLargoAncho.IsRequired = False
        Me.txtPedidosDecimalesMostrarLargoAncho.Key = ""
        Me.txtPedidosDecimalesMostrarLargoAncho.LabelAsoc = Me.lblPedidosDecimalesMostrarLargoAncho
        Me.txtPedidosDecimalesMostrarLargoAncho.Location = New System.Drawing.Point(6, 19)
        Me.txtPedidosDecimalesMostrarLargoAncho.MaxLength = 3
        Me.txtPedidosDecimalesMostrarLargoAncho.Name = "txtPedidosDecimalesMostrarLargoAncho"
        Me.txtPedidosDecimalesMostrarLargoAncho.Size = New System.Drawing.Size(35, 20)
        Me.txtPedidosDecimalesMostrarLargoAncho.TabIndex = 0
        Me.txtPedidosDecimalesMostrarLargoAncho.Text = "4"
        Me.txtPedidosDecimalesMostrarLargoAncho.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'lblPedidosDecimalesMostrarLargoAncho
        '
        Me.lblPedidosDecimalesMostrarLargoAncho.AutoSize = True
        Me.lblPedidosDecimalesMostrarLargoAncho.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblPedidosDecimalesMostrarLargoAncho.LabelAsoc = Nothing
        Me.lblPedidosDecimalesMostrarLargoAncho.Location = New System.Drawing.Point(44, 23)
        Me.lblPedidosDecimalesMostrarLargoAncho.Name = "lblPedidosDecimalesMostrarLargoAncho"
        Me.lblPedidosDecimalesMostrarLargoAncho.Size = New System.Drawing.Size(129, 13)
        Me.lblPedidosDecimalesMostrarLargoAncho.TabIndex = 1
        Me.lblPedidosDecimalesMostrarLargoAncho.Text = "Mostrar en Largo y Ancho"
        '
        'chbPedidosMuestraTotalMasIVA
        '
        Me.chbPedidosMuestraTotalMasIVA.AutoSize = True
        Me.chbPedidosMuestraTotalMasIVA.BindearPropiedadControl = Nothing
        Me.chbPedidosMuestraTotalMasIVA.BindearPropiedadEntidad = Nothing
        Me.chbPedidosMuestraTotalMasIVA.Checked = True
        Me.chbPedidosMuestraTotalMasIVA.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chbPedidosMuestraTotalMasIVA.ForeColorFocus = System.Drawing.Color.Red
        Me.chbPedidosMuestraTotalMasIVA.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbPedidosMuestraTotalMasIVA.IsPK = False
        Me.chbPedidosMuestraTotalMasIVA.IsRequired = False
        Me.chbPedidosMuestraTotalMasIVA.Key = Nothing
        Me.chbPedidosMuestraTotalMasIVA.LabelAsoc = Nothing
        Me.chbPedidosMuestraTotalMasIVA.Location = New System.Drawing.Point(17, 248)
        Me.chbPedidosMuestraTotalMasIVA.Name = "chbPedidosMuestraTotalMasIVA"
        Me.chbPedidosMuestraTotalMasIVA.Size = New System.Drawing.Size(167, 17)
        Me.chbPedidosMuestraTotalMasIVA.TabIndex = 24
        Me.chbPedidosMuestraTotalMasIVA.Text = "Mostrar Importe Total con IVA"
        Me.chbPedidosMuestraTotalMasIVA.UseVisualStyleBackColor = True
        '
        'ucConfPedidosVisualizacion
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.GroupBox6)
        Me.Controls.Add(Me.GroupBox13)
        Me.Name = "ucConfPedidosVisualizacion"
        Me.Controls.SetChildIndex(Me.GroupBox13, 0)
        Me.Controls.SetChildIndex(Me.GroupBox6, 0)
        Me.GroupBox6.ResumeLayout(False)
        Me.GroupBox6.PerformLayout()
        Me.GroupBox13.ResumeLayout(False)
        Me.GroupBox13.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents GroupBox6 As GroupBox
   Friend WithEvents chbPedidosMuestraProvHabitual As Controles.CheckBox
   Friend WithEvents chbPedidosMostrarCriticidad As Controles.CheckBox
   Friend WithEvents cmbMonedaPrecioPorTamano As Controles.ComboBox
   Friend WithEvents lblMonedaPrecioPorTamano As Controles.Label
   Friend WithEvents chbPedidosMostrarUM As Controles.CheckBox
   Friend WithEvents chbPedidosMostrarNota As Controles.CheckBox
   Friend WithEvents chbPedidosMostrarFormula As Controles.CheckBox
   Friend WithEvents chbPedidosMostrarUrlPlanoDetalle As Controles.CheckBox
   Friend WithEvents chbProductoAnchoIntBase As Controles.CheckBox
   Friend WithEvents chbProductoLargoExtAlto As Controles.CheckBox
   Friend WithEvents chbProductoProduccionForma As Controles.CheckBox
   Friend WithEvents chbProductoProduccionProceso As Controles.CheckBox
   Friend WithEvents chbProductoSAE As Controles.CheckBox
   Friend WithEvents chbProductoEspPulgadas As Controles.CheckBox
   Friend WithEvents chbProductoEspmm As Controles.CheckBox
   Friend WithEvents chbPedidosMostrarTamano As Controles.CheckBox
   Friend WithEvents chbPedidosMostrarPrecioVentaPorTamano As Controles.CheckBox
   Friend WithEvents chbPedidosMostrarSemaforoRentabilidadDetalle As Controles.CheckBox
   Friend WithEvents chbPedidosMostrarMoneda As Controles.CheckBox
   Friend WithEvents chbPedidosMostrarCosto As Controles.CheckBox
   Friend WithEvents GroupBox13 As GroupBox
   Friend WithEvents txtPedidosDecimalesMostrarLargoAncho As Controles.TextBox
   Friend WithEvents lblPedidosDecimalesMostrarLargoAncho As Controles.Label
   Friend WithEvents chbProductoModeloForma As Controles.CheckBox
   Friend WithEvents chbProductoArchitrave As Controles.CheckBox
    Friend WithEvents lblVisualizaPrecioPedido As Controles.Label
    Friend WithEvents cmbVisualizaPrecioPedido As Controles.ComboBox
    Friend WithEvents chbPedidosMuestraTotalMasIVA As Controles.CheckBox
End Class
