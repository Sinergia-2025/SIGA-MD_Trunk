<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CargosDetalle
   Inherits Win.BaseDetalle

   'Form reemplaza a Dispose para limpiar la lista de componentes.
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

   'Requerido por el Diseñador de Windows Forms
   Private components As System.ComponentModel.IContainer

   'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
   'Se puede modificar usando el Diseñador de Windows Forms.  
   'No lo modifique con el editor de código.
   <System.Diagnostics.DebuggerStepThrough()> _
   Private Sub InitializeComponent()
      Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(CargosDetalle))
      Me.chbActivo = New Eniac.Controles.CheckBox()
      Me.lblNombre = New Eniac.Controles.Label()
      Me.txtNombre = New Eniac.Controles.TextBox()
      Me.lblId = New Eniac.Controles.Label()
      Me.txtId = New Eniac.Controles.TextBox()
      Me.lblMonto = New Eniac.Controles.Label()
      Me.txtMonto = New Eniac.Controles.TextBox()
      Me.chbImprimeVoucher = New Eniac.Controles.CheckBox()
      Me.txtCantidadMeses = New Eniac.Controles.TextBox()
      Me.lblCantidadMeses = New Eniac.Controles.Label()
      Me.chbModificaImporte = New Eniac.Controles.CheckBox()
      Me.txtCuotaActual = New Eniac.Controles.TextBox()
      Me.lblCuotaActual = New Eniac.Controles.Label()
      Me.chbCuotas = New Eniac.Controles.CheckBox()
      Me.txtCantidadCuotas = New Eniac.Controles.TextBox()
      Me.lblCantidadCuotas = New Eniac.Controles.Label()
      Me.chbModificaCantidad = New Eniac.Controles.CheckBox()
      Me.bscProducto2 = New Eniac.Controles.Buscador2()
      Me.bscCodigoProducto2 = New Eniac.Controles.Buscador2()
      Me.lblConcepto = New Eniac.Controles.Label()
      Me.cmbTiposLiquidacion = New Eniac.Controles.ComboBox()
      Me.Label1 = New Eniac.Controles.Label()
      Me.btnRefrescar = New Eniac.Controles.Button()
      Me.chbCargoTemporal = New Eniac.Controles.CheckBox()
      Me.SuspendLayout()
      '
      'btnAceptar
      '
      Me.btnAceptar.Location = New System.Drawing.Point(330, 228)
      Me.btnAceptar.TabIndex = 25
      '
      'btnCancelar
      '
      Me.btnCancelar.Location = New System.Drawing.Point(421, 228)
      Me.btnCancelar.TabIndex = 26
      '
      'btnCopiar
      '
      Me.btnCopiar.Location = New System.Drawing.Point(122, 228)
      Me.btnCopiar.TabIndex = 24
      '
      'btnAplicar
      '
      Me.btnAplicar.Location = New System.Drawing.Point(42, 199)
      Me.btnAplicar.TabIndex = 18
      '
      'chbActivo
      '
      Me.chbActivo.AutoSize = True
      Me.chbActivo.BindearPropiedadControl = "Checked"
      Me.chbActivo.BindearPropiedadEntidad = "Activo"
      Me.chbActivo.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
      Me.chbActivo.ForeColorFocus = System.Drawing.Color.Red
      Me.chbActivo.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
      Me.chbActivo.IsPK = False
      Me.chbActivo.IsRequired = False
      Me.chbActivo.Key = Nothing
      Me.chbActivo.LabelAsoc = Nothing
      Me.chbActivo.Location = New System.Drawing.Point(444, 16)
      Me.chbActivo.Name = "chbActivo"
      Me.chbActivo.Size = New System.Drawing.Size(56, 17)
      Me.chbActivo.TabIndex = 27
      Me.chbActivo.Text = "Activo"
      Me.chbActivo.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      Me.chbActivo.UseVisualStyleBackColor = True
      '
      'lblNombre
      '
      Me.lblNombre.AutoSize = True
      Me.lblNombre.LabelAsoc = Nothing
      Me.lblNombre.Location = New System.Drawing.Point(15, 71)
      Me.lblNombre.Name = "lblNombre"
      Me.lblNombre.Size = New System.Drawing.Size(44, 13)
      Me.lblNombre.TabIndex = 5
      Me.lblNombre.Text = "Nombre"
      '
      'txtNombre
      '
      Me.txtNombre.BindearPropiedadControl = "Text"
      Me.txtNombre.BindearPropiedadEntidad = "NombreCargo"
      Me.txtNombre.ForeColorFocus = System.Drawing.Color.Red
      Me.txtNombre.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtNombre.Formato = ""
      Me.txtNombre.IsDecimal = False
      Me.txtNombre.IsNumber = False
      Me.txtNombre.IsPK = False
      Me.txtNombre.IsRequired = True
      Me.txtNombre.Key = ""
      Me.txtNombre.LabelAsoc = Me.lblNombre
      Me.txtNombre.Location = New System.Drawing.Point(102, 68)
      Me.txtNombre.MaxLength = 60
      Me.txtNombre.Name = "txtNombre"
      Me.txtNombre.Size = New System.Drawing.Size(376, 20)
      Me.txtNombre.TabIndex = 6
      '
      'lblId
      '
      Me.lblId.AutoSize = True
      Me.lblId.LabelAsoc = Nothing
      Me.lblId.Location = New System.Drawing.Point(17, 20)
      Me.lblId.Name = "lblId"
      Me.lblId.Size = New System.Drawing.Size(40, 13)
      Me.lblId.TabIndex = 0
      Me.lblId.Text = "Código"
      '
      'txtId
      '
      Me.txtId.BindearPropiedadControl = "Text"
      Me.txtId.BindearPropiedadEntidad = "IdCargo"
      Me.txtId.ForeColorFocus = System.Drawing.Color.Red
      Me.txtId.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtId.Formato = ""
      Me.txtId.IsDecimal = False
      Me.txtId.IsNumber = True
      Me.txtId.IsPK = True
      Me.txtId.IsRequired = True
      Me.txtId.Key = ""
      Me.txtId.LabelAsoc = Me.lblId
      Me.txtId.Location = New System.Drawing.Point(102, 16)
      Me.txtId.MaxLength = 5
      Me.txtId.Name = "txtId"
      Me.txtId.Size = New System.Drawing.Size(88, 20)
      Me.txtId.TabIndex = 1
      '
      'lblMonto
      '
      Me.lblMonto.AutoSize = True
      Me.lblMonto.LabelAsoc = Nothing
      Me.lblMonto.Location = New System.Drawing.Point(17, 99)
      Me.lblMonto.Name = "lblMonto"
      Me.lblMonto.Size = New System.Drawing.Size(37, 13)
      Me.lblMonto.TabIndex = 7
      Me.lblMonto.Text = "Monto"
      '
      'txtMonto
      '
      Me.txtMonto.BindearPropiedadControl = "Text"
      Me.txtMonto.BindearPropiedadEntidad = "Monto"
      Me.txtMonto.ForeColorFocus = System.Drawing.Color.Red
      Me.txtMonto.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtMonto.Formato = "#,##0.00"
      Me.txtMonto.IsDecimal = True
      Me.txtMonto.IsNumber = True
      Me.txtMonto.IsPK = False
      Me.txtMonto.IsRequired = True
      Me.txtMonto.Key = ""
      Me.txtMonto.LabelAsoc = Me.lblMonto
      Me.txtMonto.Location = New System.Drawing.Point(102, 92)
      Me.txtMonto.MaxLength = 60
      Me.txtMonto.Name = "txtMonto"
      Me.txtMonto.Size = New System.Drawing.Size(87, 20)
      Me.txtMonto.TabIndex = 8
      Me.txtMonto.Text = "0.00"
      Me.txtMonto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'chbImprimeVoucher
      '
      Me.chbImprimeVoucher.AutoSize = True
      Me.chbImprimeVoucher.BindearPropiedadControl = "Checked"
      Me.chbImprimeVoucher.BindearPropiedadEntidad = "ImprimeVoucher"
      Me.chbImprimeVoucher.Enabled = False
      Me.chbImprimeVoucher.ForeColorFocus = System.Drawing.Color.Red
      Me.chbImprimeVoucher.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
      Me.chbImprimeVoucher.IsPK = False
      Me.chbImprimeVoucher.IsRequired = False
      Me.chbImprimeVoucher.Key = Nothing
      Me.chbImprimeVoucher.LabelAsoc = Nothing
      Me.chbImprimeVoucher.Location = New System.Drawing.Point(102, 148)
      Me.chbImprimeVoucher.Name = "chbImprimeVoucher"
      Me.chbImprimeVoucher.Size = New System.Drawing.Size(105, 17)
      Me.chbImprimeVoucher.TabIndex = 12
      Me.chbImprimeVoucher.Text = "Imprime Voucher"
      Me.chbImprimeVoucher.UseVisualStyleBackColor = True
      Me.chbImprimeVoucher.Visible = False
      '
      'txtCantidadMeses
      '
      Me.txtCantidadMeses.BindearPropiedadControl = "Text"
      Me.txtCantidadMeses.BindearPropiedadEntidad = "CantidadMeses"
      Me.txtCantidadMeses.ForeColorFocus = System.Drawing.Color.Red
      Me.txtCantidadMeses.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtCantidadMeses.Formato = "#,##0.00"
      Me.txtCantidadMeses.IsDecimal = False
      Me.txtCantidadMeses.IsNumber = True
      Me.txtCantidadMeses.IsPK = False
      Me.txtCantidadMeses.IsRequired = False
      Me.txtCantidadMeses.Key = ""
      Me.txtCantidadMeses.LabelAsoc = Me.lblCantidadMeses
      Me.txtCantidadMeses.Location = New System.Drawing.Point(324, 146)
      Me.txtCantidadMeses.MaxLength = 2
      Me.txtCantidadMeses.Name = "txtCantidadMeses"
      Me.txtCantidadMeses.ReadOnly = True
      Me.txtCantidadMeses.Size = New System.Drawing.Size(40, 20)
      Me.txtCantidadMeses.TabIndex = 14
      Me.txtCantidadMeses.Text = "0"
      Me.txtCantidadMeses.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      Me.txtCantidadMeses.Visible = False
      '
      'lblCantidadMeses
      '
      Me.lblCantidadMeses.AutoSize = True
      Me.lblCantidadMeses.LabelAsoc = Nothing
      Me.lblCantidadMeses.Location = New System.Drawing.Point(235, 149)
      Me.lblCantidadMeses.Name = "lblCantidadMeses"
      Me.lblCantidadMeses.Size = New System.Drawing.Size(83, 13)
      Me.lblCantidadMeses.TabIndex = 13
      Me.lblCantidadMeses.Text = "Cantidad Meses"
      Me.lblCantidadMeses.Visible = False
      '
      'chbModificaImporte
      '
      Me.chbModificaImporte.AutoSize = True
      Me.chbModificaImporte.BindearPropiedadControl = "Checked"
      Me.chbModificaImporte.BindearPropiedadEntidad = "ModificaImporte"
      Me.chbModificaImporte.ForeColorFocus = System.Drawing.Color.Red
      Me.chbModificaImporte.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
      Me.chbModificaImporte.IsPK = False
      Me.chbModificaImporte.IsRequired = False
      Me.chbModificaImporte.Key = Nothing
      Me.chbModificaImporte.LabelAsoc = Nothing
      Me.chbModificaImporte.Location = New System.Drawing.Point(102, 179)
      Me.chbModificaImporte.Name = "chbModificaImporte"
      Me.chbModificaImporte.Size = New System.Drawing.Size(104, 17)
      Me.chbModificaImporte.TabIndex = 15
      Me.chbModificaImporte.Text = "Modifica Importe"
      Me.chbModificaImporte.UseVisualStyleBackColor = True
      '
      'txtCuotaActual
      '
      Me.txtCuotaActual.BindearPropiedadControl = "Text"
      Me.txtCuotaActual.BindearPropiedadEntidad = "CuotaActual"
      Me.txtCuotaActual.ForeColorFocus = System.Drawing.Color.Red
      Me.txtCuotaActual.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtCuotaActual.Formato = "#,##0.00"
      Me.txtCuotaActual.IsDecimal = False
      Me.txtCuotaActual.IsNumber = True
      Me.txtCuotaActual.IsPK = False
      Me.txtCuotaActual.IsRequired = False
      Me.txtCuotaActual.Key = ""
      Me.txtCuotaActual.LabelAsoc = Me.lblCuotaActual
      Me.txtCuotaActual.Location = New System.Drawing.Point(339, 205)
      Me.txtCuotaActual.MaxLength = 2
      Me.txtCuotaActual.Name = "txtCuotaActual"
      Me.txtCuotaActual.ReadOnly = True
      Me.txtCuotaActual.Size = New System.Drawing.Size(40, 20)
      Me.txtCuotaActual.TabIndex = 23
      Me.txtCuotaActual.Text = "0"
      Me.txtCuotaActual.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      Me.txtCuotaActual.Visible = False
      '
      'lblCuotaActual
      '
      Me.lblCuotaActual.AutoSize = True
      Me.lblCuotaActual.LabelAsoc = Nothing
      Me.lblCuotaActual.Location = New System.Drawing.Point(296, 209)
      Me.lblCuotaActual.Name = "lblCuotaActual"
      Me.lblCuotaActual.Size = New System.Drawing.Size(37, 13)
      Me.lblCuotaActual.TabIndex = 22
      Me.lblCuotaActual.Text = "Actual"
      Me.lblCuotaActual.Visible = False
      '
      'chbCuotas
      '
      Me.chbCuotas.AutoSize = True
      Me.chbCuotas.BindearPropiedadControl = ""
      Me.chbCuotas.BindearPropiedadEntidad = ""
      Me.chbCuotas.ForeColorFocus = System.Drawing.Color.Red
      Me.chbCuotas.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
      Me.chbCuotas.IsPK = False
      Me.chbCuotas.IsRequired = False
      Me.chbCuotas.Key = Nothing
      Me.chbCuotas.LabelAsoc = Nothing
      Me.chbCuotas.Location = New System.Drawing.Point(102, 207)
      Me.chbCuotas.Name = "chbCuotas"
      Me.chbCuotas.Size = New System.Drawing.Size(59, 17)
      Me.chbCuotas.TabIndex = 19
      Me.chbCuotas.Text = "Cuotas"
      Me.chbCuotas.UseVisualStyleBackColor = True
      Me.chbCuotas.Visible = False
      '
      'txtCantidadCuotas
      '
      Me.txtCantidadCuotas.BindearPropiedadControl = "Text"
      Me.txtCantidadCuotas.BindearPropiedadEntidad = "CantidadCuotas"
      Me.txtCantidadCuotas.ForeColorFocus = System.Drawing.Color.Red
      Me.txtCantidadCuotas.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtCantidadCuotas.Formato = "#,##0.00"
      Me.txtCantidadCuotas.IsDecimal = False
      Me.txtCantidadCuotas.IsNumber = True
      Me.txtCantidadCuotas.IsPK = False
      Me.txtCantidadCuotas.IsRequired = False
      Me.txtCantidadCuotas.Key = ""
      Me.txtCantidadCuotas.LabelAsoc = Me.lblCantidadCuotas
      Me.txtCantidadCuotas.Location = New System.Drawing.Point(238, 205)
      Me.txtCantidadCuotas.MaxLength = 2
      Me.txtCantidadCuotas.Name = "txtCantidadCuotas"
      Me.txtCantidadCuotas.ReadOnly = True
      Me.txtCantidadCuotas.Size = New System.Drawing.Size(40, 20)
      Me.txtCantidadCuotas.TabIndex = 21
      Me.txtCantidadCuotas.Text = "0"
      Me.txtCantidadCuotas.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      Me.txtCantidadCuotas.Visible = False
      '
      'lblCantidadCuotas
      '
      Me.lblCantidadCuotas.AutoSize = True
      Me.lblCantidadCuotas.LabelAsoc = Nothing
      Me.lblCantidadCuotas.Location = New System.Drawing.Point(185, 209)
      Me.lblCantidadCuotas.Name = "lblCantidadCuotas"
      Me.lblCantidadCuotas.Size = New System.Drawing.Size(49, 13)
      Me.lblCantidadCuotas.TabIndex = 20
      Me.lblCantidadCuotas.Text = "Cantidad"
      Me.lblCantidadCuotas.Visible = False
      '
      'chbModificaCantidad
      '
      Me.chbModificaCantidad.AutoSize = True
      Me.chbModificaCantidad.BindearPropiedadControl = "Checked"
      Me.chbModificaCantidad.BindearPropiedadEntidad = "ModificaCantidad"
      Me.chbModificaCantidad.ForeColorFocus = System.Drawing.Color.Red
      Me.chbModificaCantidad.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
      Me.chbModificaCantidad.IsPK = False
      Me.chbModificaCantidad.IsRequired = False
      Me.chbModificaCantidad.Key = Nothing
      Me.chbModificaCantidad.LabelAsoc = Nothing
      Me.chbModificaCantidad.Location = New System.Drawing.Point(212, 179)
      Me.chbModificaCantidad.Name = "chbModificaCantidad"
      Me.chbModificaCantidad.Size = New System.Drawing.Size(111, 17)
      Me.chbModificaCantidad.TabIndex = 16
      Me.chbModificaCantidad.Text = "Modifica Cantidad"
      Me.chbModificaCantidad.UseVisualStyleBackColor = True
      '
      'bscProducto2
      '
      Me.bscProducto2.ActivarFiltroEnGrilla = True
      Me.bscProducto2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.bscProducto2.BindearPropiedadControl = Nothing
      Me.bscProducto2.BindearPropiedadEntidad = Nothing
      Me.bscProducto2.ConfigBuscador = Nothing
      Me.bscProducto2.Datos = Nothing
      Me.bscProducto2.FilaDevuelta = Nothing
      Me.bscProducto2.ForeColorFocus = System.Drawing.Color.Red
      Me.bscProducto2.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
      Me.bscProducto2.IsDecimal = False
      Me.bscProducto2.IsNumber = False
      Me.bscProducto2.IsPK = False
      Me.bscProducto2.IsRequired = True
      Me.bscProducto2.Key = ""
      Me.bscProducto2.LabelAsoc = Nothing
      Me.bscProducto2.Location = New System.Drawing.Point(223, 117)
      Me.bscProducto2.MaxLengh = "32767"
      Me.bscProducto2.Name = "bscProducto2"
      Me.bscProducto2.Permitido = True
      Me.bscProducto2.PermitidoNoBackColor = System.Drawing.Color.FromArgb(CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer))
      Me.bscProducto2.PermitidoNoForeColor = System.Drawing.Color.Black
      Me.bscProducto2.PermitidoSiBackColor = System.Drawing.Color.White
      Me.bscProducto2.PermitidoSiForeColor = System.Drawing.Color.Black
      Me.bscProducto2.Selecciono = False
      Me.bscProducto2.Size = New System.Drawing.Size(255, 20)
      Me.bscProducto2.TabIndex = 11
      '
      'bscCodigoProducto2
      '
      Me.bscCodigoProducto2.ActivarFiltroEnGrilla = True
      Me.bscCodigoProducto2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.bscCodigoProducto2.BindearPropiedadControl = Nothing
      Me.bscCodigoProducto2.BindearPropiedadEntidad = Nothing
      Me.bscCodigoProducto2.ConfigBuscador = Nothing
      Me.bscCodigoProducto2.Datos = Nothing
      Me.bscCodigoProducto2.FilaDevuelta = Nothing
      Me.bscCodigoProducto2.ForeColorFocus = System.Drawing.Color.Red
      Me.bscCodigoProducto2.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
      Me.bscCodigoProducto2.IsDecimal = False
      Me.bscCodigoProducto2.IsNumber = False
      Me.bscCodigoProducto2.IsPK = False
      Me.bscCodigoProducto2.IsRequired = True
      Me.bscCodigoProducto2.Key = ""
      Me.bscCodigoProducto2.LabelAsoc = Nothing
      Me.bscCodigoProducto2.Location = New System.Drawing.Point(102, 117)
      Me.bscCodigoProducto2.MaxLengh = "32767"
      Me.bscCodigoProducto2.Name = "bscCodigoProducto2"
      Me.bscCodigoProducto2.Permitido = True
      Me.bscCodigoProducto2.PermitidoNoBackColor = System.Drawing.Color.FromArgb(CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer))
      Me.bscCodigoProducto2.PermitidoNoForeColor = System.Drawing.Color.Black
      Me.bscCodigoProducto2.PermitidoSiBackColor = System.Drawing.Color.White
      Me.bscCodigoProducto2.PermitidoSiForeColor = System.Drawing.Color.Black
      Me.bscCodigoProducto2.Selecciono = False
      Me.bscCodigoProducto2.Size = New System.Drawing.Size(115, 20)
      Me.bscCodigoProducto2.TabIndex = 10
      '
      'lblConcepto
      '
      Me.lblConcepto.AutoSize = True
      Me.lblConcepto.LabelAsoc = Nothing
      Me.lblConcepto.Location = New System.Drawing.Point(17, 122)
      Me.lblConcepto.Name = "lblConcepto"
      Me.lblConcepto.Size = New System.Drawing.Size(50, 13)
      Me.lblConcepto.TabIndex = 9
      Me.lblConcepto.Text = "Producto"
      '
      'cmbTiposLiquidacion
      '
      Me.cmbTiposLiquidacion.BindearPropiedadControl = "SelectedValue"
      Me.cmbTiposLiquidacion.BindearPropiedadEntidad = "IdTipoLiquidacion"
      Me.cmbTiposLiquidacion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cmbTiposLiquidacion.ForeColorFocus = System.Drawing.Color.Red
      Me.cmbTiposLiquidacion.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.cmbTiposLiquidacion.FormattingEnabled = True
      Me.cmbTiposLiquidacion.IsPK = False
      Me.cmbTiposLiquidacion.IsRequired = False
      Me.cmbTiposLiquidacion.Key = Nothing
      Me.cmbTiposLiquidacion.LabelAsoc = Nothing
      Me.cmbTiposLiquidacion.Location = New System.Drawing.Point(102, 41)
      Me.cmbTiposLiquidacion.Name = "cmbTiposLiquidacion"
      Me.cmbTiposLiquidacion.Size = New System.Drawing.Size(120, 21)
      Me.cmbTiposLiquidacion.TabIndex = 3
      '
      'Label1
      '
      Me.Label1.AutoSize = True
      Me.Label1.LabelAsoc = Nothing
      Me.Label1.Location = New System.Drawing.Point(14, 45)
      Me.Label1.Name = "Label1"
      Me.Label1.Size = New System.Drawing.Size(85, 13)
      Me.Label1.TabIndex = 2
      Me.Label1.Text = "Tipo Liquidacion"
      '
      'btnRefrescar
      '
      Me.btnRefrescar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.btnRefrescar.Image = Global.Eniac.Win.My.Resources.Resources.refresh_24
      Me.btnRefrescar.Location = New System.Drawing.Point(223, 34)
      Me.btnRefrescar.Name = "btnRefrescar"
      Me.btnRefrescar.Size = New System.Drawing.Size(33, 33)
      Me.btnRefrescar.TabIndex = 4
      Me.btnRefrescar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
      Me.btnRefrescar.UseVisualStyleBackColor = True
      '
      'chbCargoTemporal
      '
      Me.chbCargoTemporal.AutoSize = True
      Me.chbCargoTemporal.BindearPropiedadControl = "Checked"
      Me.chbCargoTemporal.BindearPropiedadEntidad = "CargoTemporal"
      Me.chbCargoTemporal.ForeColorFocus = System.Drawing.Color.Red
      Me.chbCargoTemporal.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
      Me.chbCargoTemporal.IsPK = False
      Me.chbCargoTemporal.IsRequired = False
      Me.chbCargoTemporal.Key = Nothing
      Me.chbCargoTemporal.LabelAsoc = Nothing
      Me.chbCargoTemporal.Location = New System.Drawing.Point(338, 179)
      Me.chbCargoTemporal.Name = "chbCargoTemporal"
      Me.chbCargoTemporal.Size = New System.Drawing.Size(101, 17)
      Me.chbCargoTemporal.TabIndex = 17
      Me.chbCargoTemporal.Text = "Cargo Temporal"
      Me.chbCargoTemporal.UseVisualStyleBackColor = True
      '
      'CargosDetalle
      '
      Me.AcceptButton = Nothing
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.ClientSize = New System.Drawing.Size(510, 263)
      Me.Controls.Add(Me.chbCargoTemporal)
      Me.Controls.Add(Me.btnRefrescar)
      Me.Controls.Add(Me.Label1)
      Me.Controls.Add(Me.cmbTiposLiquidacion)
      Me.Controls.Add(Me.bscProducto2)
      Me.Controls.Add(Me.bscCodigoProducto2)
      Me.Controls.Add(Me.txtCantidadCuotas)
      Me.Controls.Add(Me.lblCantidadCuotas)
      Me.Controls.Add(Me.chbCuotas)
      Me.Controls.Add(Me.txtCuotaActual)
      Me.Controls.Add(Me.lblCuotaActual)
      Me.Controls.Add(Me.chbModificaCantidad)
      Me.Controls.Add(Me.chbModificaImporte)
      Me.Controls.Add(Me.txtCantidadMeses)
      Me.Controls.Add(Me.lblCantidadMeses)
      Me.Controls.Add(Me.chbImprimeVoucher)
      Me.Controls.Add(Me.txtMonto)
      Me.Controls.Add(Me.lblConcepto)
      Me.Controls.Add(Me.lblMonto)
      Me.Controls.Add(Me.chbActivo)
      Me.Controls.Add(Me.lblNombre)
      Me.Controls.Add(Me.txtNombre)
      Me.Controls.Add(Me.lblId)
      Me.Controls.Add(Me.txtId)
      Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
      Me.Name = "CargosDetalle"
      Me.Text = "Cargo"
      Me.Controls.SetChildIndex(Me.btnAplicar, 0)
      Me.Controls.SetChildIndex(Me.btnCopiar, 0)
      Me.Controls.SetChildIndex(Me.btnCancelar, 0)
      Me.Controls.SetChildIndex(Me.btnAceptar, 0)
      Me.Controls.SetChildIndex(Me.txtId, 0)
      Me.Controls.SetChildIndex(Me.lblId, 0)
      Me.Controls.SetChildIndex(Me.txtNombre, 0)
      Me.Controls.SetChildIndex(Me.lblNombre, 0)
      Me.Controls.SetChildIndex(Me.chbActivo, 0)
      Me.Controls.SetChildIndex(Me.lblMonto, 0)
      Me.Controls.SetChildIndex(Me.lblConcepto, 0)
      Me.Controls.SetChildIndex(Me.txtMonto, 0)
      Me.Controls.SetChildIndex(Me.chbImprimeVoucher, 0)
      Me.Controls.SetChildIndex(Me.lblCantidadMeses, 0)
      Me.Controls.SetChildIndex(Me.txtCantidadMeses, 0)
      Me.Controls.SetChildIndex(Me.chbModificaImporte, 0)
      Me.Controls.SetChildIndex(Me.chbModificaCantidad, 0)
      Me.Controls.SetChildIndex(Me.lblCuotaActual, 0)
      Me.Controls.SetChildIndex(Me.txtCuotaActual, 0)
      Me.Controls.SetChildIndex(Me.chbCuotas, 0)
      Me.Controls.SetChildIndex(Me.lblCantidadCuotas, 0)
      Me.Controls.SetChildIndex(Me.txtCantidadCuotas, 0)
      Me.Controls.SetChildIndex(Me.bscCodigoProducto2, 0)
      Me.Controls.SetChildIndex(Me.bscProducto2, 0)
      Me.Controls.SetChildIndex(Me.cmbTiposLiquidacion, 0)
      Me.Controls.SetChildIndex(Me.Label1, 0)
      Me.Controls.SetChildIndex(Me.btnRefrescar, 0)
      Me.Controls.SetChildIndex(Me.chbCargoTemporal, 0)
      Me.ResumeLayout(False)
      Me.PerformLayout()

   End Sub
   Friend WithEvents chbActivo As Eniac.Controles.CheckBox
   Friend WithEvents lblNombre As Eniac.Controles.Label
   Friend WithEvents txtNombre As Eniac.Controles.TextBox
   Friend WithEvents lblId As Eniac.Controles.Label
   Friend WithEvents txtId As Eniac.Controles.TextBox
   Friend WithEvents lblMonto As Eniac.Controles.Label
   Friend WithEvents txtMonto As Eniac.Controles.TextBox
   Friend WithEvents chbImprimeVoucher As Eniac.Controles.CheckBox
   Friend WithEvents txtCantidadMeses As Eniac.Controles.TextBox
   Friend WithEvents lblCantidadMeses As Eniac.Controles.Label
   Friend WithEvents chbModificaImporte As Eniac.Controles.CheckBox
   Friend WithEvents txtCuotaActual As Eniac.Controles.TextBox
   Friend WithEvents lblCuotaActual As Eniac.Controles.Label
   Friend WithEvents chbCuotas As Eniac.Controles.CheckBox
   Friend WithEvents txtCantidadCuotas As Eniac.Controles.TextBox
   Friend WithEvents lblCantidadCuotas As Eniac.Controles.Label
   Friend WithEvents chbModificaCantidad As Eniac.Controles.CheckBox
   Friend WithEvents bscProducto2 As Eniac.Controles.Buscador2
   Friend WithEvents bscCodigoProducto2 As Eniac.Controles.Buscador2
   Friend WithEvents lblConcepto As Eniac.Controles.Label
   Friend WithEvents cmbTiposLiquidacion As Eniac.Controles.ComboBox
   Friend WithEvents Label1 As Eniac.Controles.Label
   Friend WithEvents btnRefrescar As Eniac.Controles.Button
   Friend WithEvents chbCargoTemporal As Eniac.Controles.CheckBox
End Class
