<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ucConfProduccion
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
      Me.chbSolicitaModificarFormulaLuegoDelProducto = New Eniac.Controles.CheckBox()
      Me.GroupBox10 = New System.Windows.Forms.GroupBox()
        Me.chbProductoModeloForma = New Eniac.Controles.CheckBox()
        Me.chbOrdProdMostrarVenta = New Eniac.Controles.CheckBox()
        Me.chbOrdProdMostrarCosto = New Eniac.Controles.CheckBox()
        Me.chbOrdProdMostrarFormula = New Eniac.Controles.CheckBox()
        Me.chbOrdProdArchitrave = New Eniac.Controles.CheckBox()
        Me.chbOrdProdAnchoIntBase = New Eniac.Controles.CheckBox()
        Me.chbOrdProdLargoExtAlto = New Eniac.Controles.CheckBox()
        Me.chbDivideTamano = New Eniac.Controles.CheckBox()
        Me.chbProduccionDescuentaProdFormula = New Eniac.Controles.CheckBox()
        Me.chbProduccionRecetaUnica = New Eniac.Controles.CheckBox()
        Me.grpOrdProdImpresion = New System.Windows.Forms.GroupBox()
        Me.txtOrdProdCantidadLineaSeparacion = New Eniac.Controles.TextBox()
        Me.lblOrdProdCantidadLineaSeparacion = New Eniac.Controles.Label()
        Me.chbOrdProdImprimirComponentesNecesarios = New Eniac.Controles.CheckBox()
        Me.chbOrdProdCantidadNecesariaUnitaria = New Eniac.Controles.CheckBox()
        Me.grpCantidadDecimales = New System.Windows.Forms.GroupBox()
        Me.txtProduccionDecimalesVariablesModeloForma = New Eniac.Controles.TextBox()
        Me.lblProduccionDecimalesVariablesModeloForma = New Eniac.Controles.Label()
        Me.chbProduccionCalculaPrecioSegunPorcentaje = New Eniac.Controles.CheckBox()
        Me.GroupBox10.SuspendLayout()
        Me.grpOrdProdImpresion.SuspendLayout()
        Me.grpCantidadDecimales.SuspendLayout()
        Me.SuspendLayout()
        '
        'chbSolicitaModificarFormulaLuegoDelProducto
        '
        Me.chbSolicitaModificarFormulaLuegoDelProducto.AutoSize = True
        Me.chbSolicitaModificarFormulaLuegoDelProducto.BindearPropiedadControl = Nothing
        Me.chbSolicitaModificarFormulaLuegoDelProducto.BindearPropiedadEntidad = Nothing
        Me.chbSolicitaModificarFormulaLuegoDelProducto.ForeColorFocus = System.Drawing.Color.Red
        Me.chbSolicitaModificarFormulaLuegoDelProducto.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbSolicitaModificarFormulaLuegoDelProducto.IsPK = False
        Me.chbSolicitaModificarFormulaLuegoDelProducto.IsRequired = False
        Me.chbSolicitaModificarFormulaLuegoDelProducto.Key = Nothing
        Me.chbSolicitaModificarFormulaLuegoDelProducto.LabelAsoc = Nothing
        Me.chbSolicitaModificarFormulaLuegoDelProducto.Location = New System.Drawing.Point(38, 115)
        Me.chbSolicitaModificarFormulaLuegoDelProducto.Name = "chbSolicitaModificarFormulaLuegoDelProducto"
        Me.chbSolicitaModificarFormulaLuegoDelProducto.Size = New System.Drawing.Size(327, 17)
        Me.chbSolicitaModificarFormulaLuegoDelProducto.TabIndex = 3
        Me.chbSolicitaModificarFormulaLuegoDelProducto.Text = "Solicita Modificar Formula al agregar producto a Pedido/Factura"
        Me.chbSolicitaModificarFormulaLuegoDelProducto.UseVisualStyleBackColor = True
        '
        'GroupBox10
        '
        Me.GroupBox10.Controls.Add(Me.chbProductoModeloForma)
        Me.GroupBox10.Controls.Add(Me.chbOrdProdMostrarVenta)
        Me.GroupBox10.Controls.Add(Me.chbOrdProdMostrarCosto)
        Me.GroupBox10.Controls.Add(Me.chbOrdProdMostrarFormula)
        Me.GroupBox10.Controls.Add(Me.chbOrdProdArchitrave)
        Me.GroupBox10.Controls.Add(Me.chbOrdProdAnchoIntBase)
        Me.GroupBox10.Controls.Add(Me.chbOrdProdLargoExtAlto)
        Me.GroupBox10.Location = New System.Drawing.Point(536, 27)
        Me.GroupBox10.Name = "GroupBox10"
        Me.GroupBox10.Size = New System.Drawing.Size(325, 186)
        Me.GroupBox10.TabIndex = 4
        Me.GroupBox10.TabStop = False
        Me.GroupBox10.Text = "Columnas del detalle de Orden de Producción a mostrar"
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
        Me.chbProductoModeloForma.Location = New System.Drawing.Point(27, 156)
        Me.chbProductoModeloForma.Name = "chbProductoModeloForma"
        Me.chbProductoModeloForma.Size = New System.Drawing.Size(93, 17)
        Me.chbProductoModeloForma.TabIndex = 18
        Me.chbProductoModeloForma.Text = "Modelo Forma"
        Me.chbProductoModeloForma.UseVisualStyleBackColor = True
        '
        'chbOrdProdMostrarVenta
        '
        Me.chbOrdProdMostrarVenta.AutoSize = True
        Me.chbOrdProdMostrarVenta.BindearPropiedadControl = Nothing
        Me.chbOrdProdMostrarVenta.BindearPropiedadEntidad = Nothing
        Me.chbOrdProdMostrarVenta.Checked = True
        Me.chbOrdProdMostrarVenta.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chbOrdProdMostrarVenta.ForeColorFocus = System.Drawing.Color.Red
        Me.chbOrdProdMostrarVenta.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbOrdProdMostrarVenta.IsPK = False
        Me.chbOrdProdMostrarVenta.IsRequired = False
        Me.chbOrdProdMostrarVenta.Key = Nothing
        Me.chbOrdProdMostrarVenta.LabelAsoc = Nothing
        Me.chbOrdProdMostrarVenta.Location = New System.Drawing.Point(27, 41)
        Me.chbOrdProdMostrarVenta.Name = "chbOrdProdMostrarVenta"
        Me.chbOrdProdMostrarVenta.Size = New System.Drawing.Size(102, 17)
        Me.chbOrdProdMostrarVenta.TabIndex = 4
        Me.chbOrdProdMostrarVenta.Text = "Precio de Venta"
        Me.chbOrdProdMostrarVenta.UseVisualStyleBackColor = True
        '
        'chbOrdProdMostrarCosto
        '
        Me.chbOrdProdMostrarCosto.AutoSize = True
        Me.chbOrdProdMostrarCosto.BindearPropiedadControl = Nothing
        Me.chbOrdProdMostrarCosto.BindearPropiedadEntidad = Nothing
        Me.chbOrdProdMostrarCosto.Checked = True
        Me.chbOrdProdMostrarCosto.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chbOrdProdMostrarCosto.ForeColorFocus = System.Drawing.Color.Red
        Me.chbOrdProdMostrarCosto.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbOrdProdMostrarCosto.IsPK = False
        Me.chbOrdProdMostrarCosto.IsRequired = False
        Me.chbOrdProdMostrarCosto.Key = Nothing
        Me.chbOrdProdMostrarCosto.LabelAsoc = Nothing
        Me.chbOrdProdMostrarCosto.Location = New System.Drawing.Point(27, 19)
        Me.chbOrdProdMostrarCosto.Name = "chbOrdProdMostrarCosto"
        Me.chbOrdProdMostrarCosto.Size = New System.Drawing.Size(101, 17)
        Me.chbOrdProdMostrarCosto.TabIndex = 0
        Me.chbOrdProdMostrarCosto.Text = "Precio de Costo"
        Me.chbOrdProdMostrarCosto.UseVisualStyleBackColor = True
        '
        'chbOrdProdMostrarFormula
        '
        Me.chbOrdProdMostrarFormula.AutoSize = True
        Me.chbOrdProdMostrarFormula.BindearPropiedadControl = Nothing
        Me.chbOrdProdMostrarFormula.BindearPropiedadEntidad = Nothing
        Me.chbOrdProdMostrarFormula.Checked = True
        Me.chbOrdProdMostrarFormula.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chbOrdProdMostrarFormula.ForeColorFocus = System.Drawing.Color.Red
        Me.chbOrdProdMostrarFormula.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbOrdProdMostrarFormula.IsPK = False
        Me.chbOrdProdMostrarFormula.IsRequired = False
        Me.chbOrdProdMostrarFormula.Key = Nothing
        Me.chbOrdProdMostrarFormula.LabelAsoc = Nothing
        Me.chbOrdProdMostrarFormula.Location = New System.Drawing.Point(27, 133)
        Me.chbOrdProdMostrarFormula.Name = "chbOrdProdMostrarFormula"
        Me.chbOrdProdMostrarFormula.Size = New System.Drawing.Size(134, 17)
        Me.chbOrdProdMostrarFormula.TabIndex = 3
        Me.chbOrdProdMostrarFormula.Text = "Formula de producción"
        Me.chbOrdProdMostrarFormula.UseVisualStyleBackColor = True
        '
        'chbOrdProdArchitrave
        '
        Me.chbOrdProdArchitrave.AutoSize = True
        Me.chbOrdProdArchitrave.BindearPropiedadControl = Nothing
        Me.chbOrdProdArchitrave.BindearPropiedadEntidad = Nothing
        Me.chbOrdProdArchitrave.Checked = True
        Me.chbOrdProdArchitrave.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chbOrdProdArchitrave.ForeColorFocus = System.Drawing.Color.Red
        Me.chbOrdProdArchitrave.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbOrdProdArchitrave.IsPK = False
        Me.chbOrdProdArchitrave.IsRequired = False
        Me.chbOrdProdArchitrave.Key = Nothing
        Me.chbOrdProdArchitrave.LabelAsoc = Nothing
        Me.chbOrdProdArchitrave.Location = New System.Drawing.Point(27, 110)
        Me.chbOrdProdArchitrave.Name = "chbOrdProdArchitrave"
        Me.chbOrdProdArchitrave.Size = New System.Drawing.Size(74, 17)
        Me.chbOrdProdArchitrave.TabIndex = 2
        Me.chbOrdProdArchitrave.Text = "Architrave"
        Me.chbOrdProdArchitrave.UseVisualStyleBackColor = True
        '
        'chbOrdProdAnchoIntBase
        '
        Me.chbOrdProdAnchoIntBase.AutoSize = True
        Me.chbOrdProdAnchoIntBase.BindearPropiedadControl = Nothing
        Me.chbOrdProdAnchoIntBase.BindearPropiedadEntidad = Nothing
        Me.chbOrdProdAnchoIntBase.Checked = True
        Me.chbOrdProdAnchoIntBase.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chbOrdProdAnchoIntBase.ForeColorFocus = System.Drawing.Color.Red
        Me.chbOrdProdAnchoIntBase.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbOrdProdAnchoIntBase.IsPK = False
        Me.chbOrdProdAnchoIntBase.IsRequired = False
        Me.chbOrdProdAnchoIntBase.Key = Nothing
        Me.chbOrdProdAnchoIntBase.LabelAsoc = Nothing
        Me.chbOrdProdAnchoIntBase.Location = New System.Drawing.Point(27, 87)
        Me.chbOrdProdAnchoIntBase.Name = "chbOrdProdAnchoIntBase"
        Me.chbOrdProdAnchoIntBase.Size = New System.Drawing.Size(97, 17)
        Me.chbOrdProdAnchoIntBase.TabIndex = 2
        Me.chbOrdProdAnchoIntBase.Text = "Ancho Øi Base"
        Me.chbOrdProdAnchoIntBase.UseVisualStyleBackColor = True
        '
        'chbOrdProdLargoExtAlto
        '
        Me.chbOrdProdLargoExtAlto.AutoSize = True
        Me.chbOrdProdLargoExtAlto.BindearPropiedadControl = Nothing
        Me.chbOrdProdLargoExtAlto.BindearPropiedadEntidad = Nothing
        Me.chbOrdProdLargoExtAlto.Checked = True
        Me.chbOrdProdLargoExtAlto.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chbOrdProdLargoExtAlto.ForeColorFocus = System.Drawing.Color.Red
        Me.chbOrdProdLargoExtAlto.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbOrdProdLargoExtAlto.IsPK = False
        Me.chbOrdProdLargoExtAlto.IsRequired = False
        Me.chbOrdProdLargoExtAlto.Key = Nothing
        Me.chbOrdProdLargoExtAlto.LabelAsoc = Nothing
        Me.chbOrdProdLargoExtAlto.Location = New System.Drawing.Point(27, 64)
        Me.chbOrdProdLargoExtAlto.Name = "chbOrdProdLargoExtAlto"
        Me.chbOrdProdLargoExtAlto.Size = New System.Drawing.Size(91, 17)
        Me.chbOrdProdLargoExtAlto.TabIndex = 1
        Me.chbOrdProdLargoExtAlto.Text = "Largo Øe Alto"
        Me.chbOrdProdLargoExtAlto.UseVisualStyleBackColor = True
        '
        'chbDivideTamano
        '
        Me.chbDivideTamano.AutoSize = True
        Me.chbDivideTamano.BindearPropiedadControl = Nothing
        Me.chbDivideTamano.BindearPropiedadEntidad = Nothing
        Me.chbDivideTamano.ForeColorFocus = System.Drawing.Color.Red
        Me.chbDivideTamano.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbDivideTamano.IsPK = False
        Me.chbDivideTamano.IsRequired = False
        Me.chbDivideTamano.Key = Nothing
        Me.chbDivideTamano.LabelAsoc = Nothing
        Me.chbDivideTamano.Location = New System.Drawing.Point(38, 92)
        Me.chbDivideTamano.Name = "chbDivideTamano"
        Me.chbDivideTamano.Size = New System.Drawing.Size(305, 17)
        Me.chbDivideTamano.TabIndex = 2
        Me.chbDivideTamano.Tag = "PRODUCCIONDIVIDETAMANO"
        Me.chbDivideTamano.Text = "Divide por tamaño el calculo de la formula de componentes"
        Me.chbDivideTamano.UseVisualStyleBackColor = True
        '
        'chbProduccionDescuentaProdFormula
        '
        Me.chbProduccionDescuentaProdFormula.AutoSize = True
        Me.chbProduccionDescuentaProdFormula.BindearPropiedadControl = Nothing
        Me.chbProduccionDescuentaProdFormula.BindearPropiedadEntidad = Nothing
        Me.chbProduccionDescuentaProdFormula.ForeColorFocus = System.Drawing.Color.Red
        Me.chbProduccionDescuentaProdFormula.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbProduccionDescuentaProdFormula.IsPK = False
        Me.chbProduccionDescuentaProdFormula.IsRequired = False
        Me.chbProduccionDescuentaProdFormula.Key = Nothing
        Me.chbProduccionDescuentaProdFormula.LabelAsoc = Nothing
        Me.chbProduccionDescuentaProdFormula.Location = New System.Drawing.Point(38, 69)
        Me.chbProduccionDescuentaProdFormula.Name = "chbProduccionDescuentaProdFormula"
        Me.chbProduccionDescuentaProdFormula.Size = New System.Drawing.Size(243, 17)
        Me.chbProduccionDescuentaProdFormula.TabIndex = 1
        Me.chbProduccionDescuentaProdFormula.Tag = "PRODUCCIONDESCUENTAPRODFORMULAFACTURAR"
        Me.chbProduccionDescuentaProdFormula.Text = "Descuenta al Facturar Productos con Fórmula"
        Me.chbProduccionDescuentaProdFormula.UseVisualStyleBackColor = True
        '
        'chbProduccionRecetaUnica
        '
        Me.chbProduccionRecetaUnica.AutoSize = True
        Me.chbProduccionRecetaUnica.BindearPropiedadControl = Nothing
        Me.chbProduccionRecetaUnica.BindearPropiedadEntidad = Nothing
        Me.chbProduccionRecetaUnica.ForeColorFocus = System.Drawing.Color.Red
        Me.chbProduccionRecetaUnica.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbProduccionRecetaUnica.IsPK = False
        Me.chbProduccionRecetaUnica.IsRequired = False
        Me.chbProduccionRecetaUnica.Key = Nothing
        Me.chbProduccionRecetaUnica.LabelAsoc = Nothing
        Me.chbProduccionRecetaUnica.Location = New System.Drawing.Point(38, 46)
        Me.chbProduccionRecetaUnica.Name = "chbProduccionRecetaUnica"
        Me.chbProduccionRecetaUnica.Size = New System.Drawing.Size(149, 17)
        Me.chbProduccionRecetaUnica.TabIndex = 0
        Me.chbProduccionRecetaUnica.Tag = "PRODUCCIONRECETAUNICA"
        Me.chbProduccionRecetaUnica.Text = "Producción Receta Unica"
        Me.chbProduccionRecetaUnica.UseVisualStyleBackColor = True
        '
        'grpOrdProdImpresion
        '
        Me.grpOrdProdImpresion.Controls.Add(Me.txtOrdProdCantidadLineaSeparacion)
        Me.grpOrdProdImpresion.Controls.Add(Me.chbOrdProdImprimirComponentesNecesarios)
        Me.grpOrdProdImpresion.Controls.Add(Me.chbOrdProdCantidadNecesariaUnitaria)
        Me.grpOrdProdImpresion.Controls.Add(Me.lblOrdProdCantidadLineaSeparacion)
        Me.grpOrdProdImpresion.Location = New System.Drawing.Point(38, 147)
        Me.grpOrdProdImpresion.Name = "grpOrdProdImpresion"
        Me.grpOrdProdImpresion.Size = New System.Drawing.Size(325, 90)
        Me.grpOrdProdImpresion.TabIndex = 5
        Me.grpOrdProdImpresion.TabStop = False
        Me.grpOrdProdImpresion.Text = "Impresión"
        '
        'txtOrdProdCantidadLineaSeparacion
        '
        Me.txtOrdProdCantidadLineaSeparacion.BindearPropiedadControl = Nothing
        Me.txtOrdProdCantidadLineaSeparacion.BindearPropiedadEntidad = Nothing
        Me.txtOrdProdCantidadLineaSeparacion.Enabled = False
        Me.txtOrdProdCantidadLineaSeparacion.ForeColorFocus = System.Drawing.Color.Red
        Me.txtOrdProdCantidadLineaSeparacion.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtOrdProdCantidadLineaSeparacion.Formato = ""
        Me.txtOrdProdCantidadLineaSeparacion.IsDecimal = False
        Me.txtOrdProdCantidadLineaSeparacion.IsNumber = True
        Me.txtOrdProdCantidadLineaSeparacion.IsPK = False
        Me.txtOrdProdCantidadLineaSeparacion.IsRequired = False
        Me.txtOrdProdCantidadLineaSeparacion.Key = ""
        Me.txtOrdProdCantidadLineaSeparacion.LabelAsoc = Me.lblOrdProdCantidadLineaSeparacion
        Me.txtOrdProdCantidadLineaSeparacion.Location = New System.Drawing.Point(198, 60)
        Me.txtOrdProdCantidadLineaSeparacion.MaxLength = 3
        Me.txtOrdProdCantidadLineaSeparacion.Name = "txtOrdProdCantidadLineaSeparacion"
        Me.txtOrdProdCantidadLineaSeparacion.Size = New System.Drawing.Size(35, 20)
        Me.txtOrdProdCantidadLineaSeparacion.TabIndex = 3
        Me.txtOrdProdCantidadLineaSeparacion.Text = "0"
        Me.txtOrdProdCantidadLineaSeparacion.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'lblOrdProdCantidadLineaSeparacion
        '
        Me.lblOrdProdCantidadLineaSeparacion.AutoSize = True
        Me.lblOrdProdCantidadLineaSeparacion.LabelAsoc = Nothing
        Me.lblOrdProdCantidadLineaSeparacion.Location = New System.Drawing.Point(28, 64)
        Me.lblOrdProdCantidadLineaSeparacion.Name = "lblOrdProdCantidadLineaSeparacion"
        Me.lblOrdProdCantidadLineaSeparacion.Size = New System.Drawing.Size(159, 13)
        Me.lblOrdProdCantidadLineaSeparacion.TabIndex = 2
        Me.lblOrdProdCantidadLineaSeparacion.Tag = ""
        Me.lblOrdProdCantidadLineaSeparacion.Text = "Cantidad de linea de separación"
        '
        'chbOrdProdImprimirComponentesNecesarios
        '
        Me.chbOrdProdImprimirComponentesNecesarios.AutoSize = True
        Me.chbOrdProdImprimirComponentesNecesarios.BindearPropiedadControl = Nothing
        Me.chbOrdProdImprimirComponentesNecesarios.BindearPropiedadEntidad = Nothing
        Me.chbOrdProdImprimirComponentesNecesarios.ForeColorFocus = System.Drawing.Color.Red
        Me.chbOrdProdImprimirComponentesNecesarios.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbOrdProdImprimirComponentesNecesarios.IsPK = False
        Me.chbOrdProdImprimirComponentesNecesarios.IsRequired = False
        Me.chbOrdProdImprimirComponentesNecesarios.Key = Nothing
        Me.chbOrdProdImprimirComponentesNecesarios.LabelAsoc = Nothing
        Me.chbOrdProdImprimirComponentesNecesarios.Location = New System.Drawing.Point(12, 19)
        Me.chbOrdProdImprimirComponentesNecesarios.Name = "chbOrdProdImprimirComponentesNecesarios"
        Me.chbOrdProdImprimirComponentesNecesarios.Size = New System.Drawing.Size(251, 17)
        Me.chbOrdProdImprimirComponentesNecesarios.TabIndex = 0
        Me.chbOrdProdImprimirComponentesNecesarios.Tag = ""
        Me.chbOrdProdImprimirComponentesNecesarios.Text = "Imprimir Componentes Necesarios para Producir"
        Me.chbOrdProdImprimirComponentesNecesarios.UseVisualStyleBackColor = True
        '
        'chbOrdProdCantidadNecesariaUnitaria
        '
        Me.chbOrdProdCantidadNecesariaUnitaria.AutoSize = True
        Me.chbOrdProdCantidadNecesariaUnitaria.BindearPropiedadControl = Nothing
        Me.chbOrdProdCantidadNecesariaUnitaria.BindearPropiedadEntidad = Nothing
        Me.chbOrdProdCantidadNecesariaUnitaria.Enabled = False
        Me.chbOrdProdCantidadNecesariaUnitaria.ForeColorFocus = System.Drawing.Color.Red
        Me.chbOrdProdCantidadNecesariaUnitaria.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbOrdProdCantidadNecesariaUnitaria.IsPK = False
        Me.chbOrdProdCantidadNecesariaUnitaria.IsRequired = False
        Me.chbOrdProdCantidadNecesariaUnitaria.Key = Nothing
        Me.chbOrdProdCantidadNecesariaUnitaria.LabelAsoc = Nothing
        Me.chbOrdProdCantidadNecesariaUnitaria.Location = New System.Drawing.Point(12, 42)
        Me.chbOrdProdCantidadNecesariaUnitaria.Name = "chbOrdProdCantidadNecesariaUnitaria"
        Me.chbOrdProdCantidadNecesariaUnitaria.Size = New System.Drawing.Size(158, 17)
        Me.chbOrdProdCantidadNecesariaUnitaria.TabIndex = 1
        Me.chbOrdProdCantidadNecesariaUnitaria.Tag = ""
        Me.chbOrdProdCantidadNecesariaUnitaria.Text = "Cantidad Necesaria Unitaria"
        Me.chbOrdProdCantidadNecesariaUnitaria.UseVisualStyleBackColor = True
        '
        'grpCantidadDecimales
        '
        Me.grpCantidadDecimales.Controls.Add(Me.txtProduccionDecimalesVariablesModeloForma)
        Me.grpCantidadDecimales.Controls.Add(Me.lblProduccionDecimalesVariablesModeloForma)
        Me.grpCantidadDecimales.Location = New System.Drawing.Point(536, 228)
        Me.grpCantidadDecimales.Name = "grpCantidadDecimales"
        Me.grpCantidadDecimales.Size = New System.Drawing.Size(325, 50)
        Me.grpCantidadDecimales.TabIndex = 61
        Me.grpCantidadDecimales.TabStop = False
        Me.grpCantidadDecimales.Text = "Cantidad de decimales"
        '
        'txtProduccionDecimalesVariablesModeloForma
        '
        Me.txtProduccionDecimalesVariablesModeloForma.BindearPropiedadControl = Nothing
        Me.txtProduccionDecimalesVariablesModeloForma.BindearPropiedadEntidad = Nothing
        Me.txtProduccionDecimalesVariablesModeloForma.ForeColorFocus = System.Drawing.Color.Red
        Me.txtProduccionDecimalesVariablesModeloForma.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtProduccionDecimalesVariablesModeloForma.Formato = ""
        Me.txtProduccionDecimalesVariablesModeloForma.IsDecimal = False
        Me.txtProduccionDecimalesVariablesModeloForma.IsNumber = True
        Me.txtProduccionDecimalesVariablesModeloForma.IsPK = False
        Me.txtProduccionDecimalesVariablesModeloForma.IsRequired = False
        Me.txtProduccionDecimalesVariablesModeloForma.Key = ""
        Me.txtProduccionDecimalesVariablesModeloForma.LabelAsoc = Me.lblProduccionDecimalesVariablesModeloForma
        Me.txtProduccionDecimalesVariablesModeloForma.Location = New System.Drawing.Point(6, 19)
        Me.txtProduccionDecimalesVariablesModeloForma.MaxLength = 3
        Me.txtProduccionDecimalesVariablesModeloForma.Name = "txtProduccionDecimalesVariablesModeloForma"
        Me.txtProduccionDecimalesVariablesModeloForma.Size = New System.Drawing.Size(35, 20)
        Me.txtProduccionDecimalesVariablesModeloForma.TabIndex = 0
        Me.txtProduccionDecimalesVariablesModeloForma.Tag = ""
        Me.txtProduccionDecimalesVariablesModeloForma.Text = "2"
        Me.txtProduccionDecimalesVariablesModeloForma.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'lblProduccionDecimalesVariablesModeloForma
        '
        Me.lblProduccionDecimalesVariablesModeloForma.AutoSize = True
        Me.lblProduccionDecimalesVariablesModeloForma.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblProduccionDecimalesVariablesModeloForma.LabelAsoc = Nothing
        Me.lblProduccionDecimalesVariablesModeloForma.Location = New System.Drawing.Point(44, 23)
        Me.lblProduccionDecimalesVariablesModeloForma.Name = "lblProduccionDecimalesVariablesModeloForma"
        Me.lblProduccionDecimalesVariablesModeloForma.Size = New System.Drawing.Size(150, 13)
        Me.lblProduccionDecimalesVariablesModeloForma.TabIndex = 1
        Me.lblProduccionDecimalesVariablesModeloForma.Text = "Variables de Modelo de Forma"
        '
        'chbProduccionCalculaPrecioSegunPorcentaje
        '
        Me.chbProduccionCalculaPrecioSegunPorcentaje.AutoSize = True
        Me.chbProduccionCalculaPrecioSegunPorcentaje.BindearPropiedadControl = Nothing
        Me.chbProduccionCalculaPrecioSegunPorcentaje.BindearPropiedadEntidad = Nothing
        Me.chbProduccionCalculaPrecioSegunPorcentaje.ForeColorFocus = System.Drawing.Color.Red
        Me.chbProduccionCalculaPrecioSegunPorcentaje.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbProduccionCalculaPrecioSegunPorcentaje.IsPK = False
        Me.chbProduccionCalculaPrecioSegunPorcentaje.IsRequired = False
        Me.chbProduccionCalculaPrecioSegunPorcentaje.Key = Nothing
        Me.chbProduccionCalculaPrecioSegunPorcentaje.LabelAsoc = Nothing
        Me.chbProduccionCalculaPrecioSegunPorcentaje.Location = New System.Drawing.Point(38, 251)
        Me.chbProduccionCalculaPrecioSegunPorcentaje.Name = "chbProduccionCalculaPrecioSegunPorcentaje"
        Me.chbProduccionCalculaPrecioSegunPorcentaje.Size = New System.Drawing.Size(329, 17)
        Me.chbProduccionCalculaPrecioSegunPorcentaje.TabIndex = 62
        Me.chbProduccionCalculaPrecioSegunPorcentaje.Text = "Calcular Precio Venta Según Porcentaje Grabado en la Formula "
        Me.chbProduccionCalculaPrecioSegunPorcentaje.UseVisualStyleBackColor = True
        '
        'ucConfProduccion
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.chbProduccionCalculaPrecioSegunPorcentaje)
        Me.Controls.Add(Me.grpCantidadDecimales)
        Me.Controls.Add(Me.grpOrdProdImpresion)
        Me.Controls.Add(Me.chbSolicitaModificarFormulaLuegoDelProducto)
        Me.Controls.Add(Me.GroupBox10)
        Me.Controls.Add(Me.chbDivideTamano)
        Me.Controls.Add(Me.chbProduccionDescuentaProdFormula)
        Me.Controls.Add(Me.chbProduccionRecetaUnica)
        Me.Name = "ucConfProduccion"
        Me.Controls.SetChildIndex(Me.chbProduccionRecetaUnica, 0)
        Me.Controls.SetChildIndex(Me.chbProduccionDescuentaProdFormula, 0)
        Me.Controls.SetChildIndex(Me.chbDivideTamano, 0)
        Me.Controls.SetChildIndex(Me.GroupBox10, 0)
        Me.Controls.SetChildIndex(Me.chbSolicitaModificarFormulaLuegoDelProducto, 0)
        Me.Controls.SetChildIndex(Me.grpOrdProdImpresion, 0)
        Me.Controls.SetChildIndex(Me.grpCantidadDecimales, 0)
        Me.Controls.SetChildIndex(Me.chbProduccionCalculaPrecioSegunPorcentaje, 0)
        Me.GroupBox10.ResumeLayout(False)
        Me.GroupBox10.PerformLayout()
        Me.grpOrdProdImpresion.ResumeLayout(False)
        Me.grpOrdProdImpresion.PerformLayout()
        Me.grpCantidadDecimales.ResumeLayout(False)
        Me.grpCantidadDecimales.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents chbSolicitaModificarFormulaLuegoDelProducto As Controles.CheckBox
   Friend WithEvents GroupBox10 As GroupBox
   Friend WithEvents chbOrdProdMostrarCosto As Controles.CheckBox
   Friend WithEvents chbOrdProdMostrarFormula As Controles.CheckBox
   Friend WithEvents chbOrdProdAnchoIntBase As Controles.CheckBox
   Friend WithEvents chbOrdProdLargoExtAlto As Controles.CheckBox
   Friend WithEvents chbDivideTamano As Controles.CheckBox
   Friend WithEvents chbProduccionDescuentaProdFormula As Controles.CheckBox
   Friend WithEvents chbProduccionRecetaUnica As Controles.CheckBox
    Friend WithEvents grpOrdProdImpresion As GroupBox
    Friend WithEvents chbOrdProdImprimirComponentesNecesarios As Controles.CheckBox
    Friend WithEvents chbOrdProdCantidadNecesariaUnitaria As Controles.CheckBox
   Friend WithEvents lblOrdProdCantidadLineaSeparacion As Controles.Label
   Friend WithEvents txtOrdProdCantidadLineaSeparacion As Controles.TextBox
    Friend WithEvents grpCantidadDecimales As GroupBox
    Friend WithEvents txtProduccionDecimalesVariablesModeloForma As Controles.TextBox
    Friend WithEvents lblProduccionDecimalesVariablesModeloForma As Controles.Label
    Friend WithEvents chbOrdProdArchitrave As Controles.CheckBox
    Friend WithEvents chbOrdProdMostrarVenta As Controles.CheckBox
    Friend WithEvents chbProductoModeloForma As Controles.CheckBox
    Friend WithEvents chbProduccionCalculaPrecioSegunPorcentaje As Controles.CheckBox
End Class
