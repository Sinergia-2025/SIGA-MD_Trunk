<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ProveedorCambiarCod
   Inherits Eniac.Win.BaseForm

   'Form reemplaza a Dispose para limpiar la lista de componentes.
   <System.Diagnostics.DebuggerNonUserCode()> _
   Protected Overrides Sub Dispose(ByVal disposing As Boolean)
      If disposing AndAlso components IsNot Nothing Then
         components.Dispose()
      End If
      MyBase.Dispose(disposing)
   End Sub

   'Requerido por el Diseñador de Windows Forms
   Private components As System.ComponentModel.IContainer

   'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
   'Se puede modificar usando el Diseñador de Windows Forms.  
   'No lo modifique con el editor de código.
   <System.Diagnostics.DebuggerStepThrough()> _
   Private Sub InitializeComponent()
      Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
      Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
      Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
      Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
      Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
      Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
      Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
      Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
      Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ProveedorCambiarCod))
      Me.GroupBox1 = New System.Windows.Forms.GroupBox()
      Me.bscCodigoProveedorRec = New Eniac.Controles.Buscador()
      Me.lblCodigoProveedorRec = New Eniac.Controles.Label()
      Me.grbProveedor = New System.Windows.Forms.GroupBox()
      Me.txtLocalidad = New Eniac.Controles.TextBox()
      Me.txtTelefono = New Eniac.Controles.TextBox()
      Me.lblTelefono = New Eniac.Controles.Label()
      Me.txtDireccion = New Eniac.Controles.TextBox()
      Me.lblDireccion = New Eniac.Controles.Label()
      Me.dgvOperaciones = New Eniac.Controles.DataGridView()
      Me.TipoComprobante = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.Letra = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.NumeroComprobante = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.Fecha = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.Neto210 = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.DescuentoRecargo = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.Iva210 = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.Iva105 = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.ImporteTotal = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.Observacion = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.Label1 = New Eniac.Controles.Label()
      Me.bscCodigoProveedor = New Eniac.Controles.Buscador()
      Me.lblCodigoProveedor = New Eniac.Controles.Label()
      Me.bscProveedor = New Eniac.Controles.Buscador()
      Me.lblNombreProveedor = New Eniac.Controles.Label()
      Me.Label3 = New Eniac.Controles.Label()
      Me.tstBarra = New System.Windows.Forms.ToolStrip()
      Me.tsbActualizar = New System.Windows.Forms.ToolStripButton()
      Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
      Me.tsbSalir = New System.Windows.Forms.ToolStripButton()
      Me.GroupBox1.SuspendLayout()
      Me.grbProveedor.SuspendLayout()
      CType(Me.dgvOperaciones, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.tstBarra.SuspendLayout()
      Me.SuspendLayout()
      '
      'GroupBox1
      '
      Me.GroupBox1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.GroupBox1.Controls.Add(Me.bscCodigoProveedorRec)
      Me.GroupBox1.Controls.Add(Me.lblCodigoProveedorRec)
      Me.GroupBox1.Location = New System.Drawing.Point(8, 326)
      Me.GroupBox1.Name = "GroupBox1"
      Me.GroupBox1.Size = New System.Drawing.Size(875, 62)
      Me.GroupBox1.TabIndex = 1
      Me.GroupBox1.TabStop = False
      Me.GroupBox1.Text = "Proveedor Destino"
      '
      'bscCodigoProveedorRec
      '
      Me.bscCodigoProveedorRec.AyudaAncho = 608
      Me.bscCodigoProveedorRec.BindearPropiedadControl = Nothing
      Me.bscCodigoProveedorRec.BindearPropiedadEntidad = Nothing
      Me.bscCodigoProveedorRec.ColumnasAlineacion = Nothing
      Me.bscCodigoProveedorRec.ColumnasAncho = Nothing
      Me.bscCodigoProveedorRec.ColumnasFormato = Nothing
      Me.bscCodigoProveedorRec.ColumnasOcultas = Nothing
      Me.bscCodigoProveedorRec.ColumnasTitulos = Nothing
      Me.bscCodigoProveedorRec.Datos = Nothing
      Me.bscCodigoProveedorRec.FilaDevuelta = Nothing
      Me.bscCodigoProveedorRec.ForeColorFocus = System.Drawing.Color.Red
      Me.bscCodigoProveedorRec.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
      Me.bscCodigoProveedorRec.IsDecimal = False
      Me.bscCodigoProveedorRec.IsNumber = False
      Me.bscCodigoProveedorRec.IsPK = False
      Me.bscCodigoProveedorRec.IsRequired = True
      Me.bscCodigoProveedorRec.Key = ""
      Me.bscCodigoProveedorRec.LabelAsoc = Nothing
      Me.bscCodigoProveedorRec.Location = New System.Drawing.Point(11, 33)
      Me.bscCodigoProveedorRec.MaxLengh = "32767"
      Me.bscCodigoProveedorRec.Name = "bscCodigoProveedorRec"
      Me.bscCodigoProveedorRec.Permitido = True
      Me.bscCodigoProveedorRec.Selecciono = False
      Me.bscCodigoProveedorRec.Size = New System.Drawing.Size(116, 20)
      Me.bscCodigoProveedorRec.TabIndex = 0
      Me.bscCodigoProveedorRec.Titulo = Nothing
      '
      'lblCodigoProveedorRec
      '
      Me.lblCodigoProveedorRec.AutoSize = True
      Me.lblCodigoProveedorRec.Location = New System.Drawing.Point(11, 18)
      Me.lblCodigoProveedorRec.Name = "lblCodigoProveedorRec"
      Me.lblCodigoProveedorRec.Size = New System.Drawing.Size(85, 13)
      Me.lblCodigoProveedorRec.TabIndex = 1
      Me.lblCodigoProveedorRec.Text = "Nro. Documento"
      '
      'grbProveedor
      '
      Me.grbProveedor.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.grbProveedor.Controls.Add(Me.txtLocalidad)
      Me.grbProveedor.Controls.Add(Me.txtTelefono)
      Me.grbProveedor.Controls.Add(Me.txtDireccion)
      Me.grbProveedor.Controls.Add(Me.dgvOperaciones)
      Me.grbProveedor.Controls.Add(Me.Label1)
      Me.grbProveedor.Controls.Add(Me.lblTelefono)
      Me.grbProveedor.Controls.Add(Me.lblDireccion)
      Me.grbProveedor.Controls.Add(Me.bscCodigoProveedor)
      Me.grbProveedor.Controls.Add(Me.bscProveedor)
      Me.grbProveedor.Controls.Add(Me.lblCodigoProveedor)
      Me.grbProveedor.Controls.Add(Me.lblNombreProveedor)
      Me.grbProveedor.Controls.Add(Me.Label3)
      Me.grbProveedor.Location = New System.Drawing.Point(8, 42)
      Me.grbProveedor.Name = "grbProveedor"
      Me.grbProveedor.Size = New System.Drawing.Size(875, 278)
      Me.grbProveedor.TabIndex = 0
      Me.grbProveedor.TabStop = False
      Me.grbProveedor.Text = "Proveedor Origen"
      '
      'txtLocalidad
      '
      Me.txtLocalidad.BindearPropiedadControl = ""
      Me.txtLocalidad.BindearPropiedadEntidad = ""
      Me.txtLocalidad.ForeColorFocus = System.Drawing.Color.Red
      Me.txtLocalidad.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtLocalidad.Formato = ""
      Me.txtLocalidad.IsDecimal = False
      Me.txtLocalidad.IsNumber = False
      Me.txtLocalidad.IsPK = False
      Me.txtLocalidad.IsRequired = False
      Me.txtLocalidad.Key = ""
      Me.txtLocalidad.LabelAsoc = Nothing
      Me.txtLocalidad.Location = New System.Drawing.Point(615, 39)
      Me.txtLocalidad.MaxLength = 100
      Me.txtLocalidad.Name = "txtLocalidad"
      Me.txtLocalidad.ReadOnly = True
      Me.txtLocalidad.Size = New System.Drawing.Size(101, 20)
      Me.txtLocalidad.TabIndex = 9
      '
      'txtTelefono
      '
      Me.txtTelefono.BindearPropiedadControl = ""
      Me.txtTelefono.BindearPropiedadEntidad = ""
      Me.txtTelefono.ForeColorFocus = System.Drawing.Color.Red
      Me.txtTelefono.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtTelefono.Formato = ""
      Me.txtTelefono.IsDecimal = False
      Me.txtTelefono.IsNumber = False
      Me.txtTelefono.IsPK = False
      Me.txtTelefono.IsRequired = False
      Me.txtTelefono.Key = ""
      Me.txtTelefono.LabelAsoc = Me.lblTelefono
      Me.txtTelefono.Location = New System.Drawing.Point(615, 65)
      Me.txtTelefono.MaxLength = 100
      Me.txtTelefono.Name = "txtTelefono"
      Me.txtTelefono.ReadOnly = True
      Me.txtTelefono.Size = New System.Drawing.Size(189, 20)
      Me.txtTelefono.TabIndex = 11
      '
      'lblTelefono
      '
      Me.lblTelefono.AutoSize = True
      Me.lblTelefono.Location = New System.Drawing.Point(556, 69)
      Me.lblTelefono.Name = "lblTelefono"
      Me.lblTelefono.Size = New System.Drawing.Size(49, 13)
      Me.lblTelefono.TabIndex = 10
      Me.lblTelefono.Text = "Teléfono"
      '
      'txtDireccion
      '
      Me.txtDireccion.BindearPropiedadControl = ""
      Me.txtDireccion.BindearPropiedadEntidad = ""
      Me.txtDireccion.ForeColorFocus = System.Drawing.Color.Red
      Me.txtDireccion.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtDireccion.Formato = ""
      Me.txtDireccion.IsDecimal = False
      Me.txtDireccion.IsNumber = False
      Me.txtDireccion.IsPK = False
      Me.txtDireccion.IsRequired = True
      Me.txtDireccion.Key = ""
      Me.txtDireccion.LabelAsoc = Me.lblDireccion
      Me.txtDireccion.Location = New System.Drawing.Point(614, 15)
      Me.txtDireccion.MaxLength = 100
      Me.txtDireccion.Name = "txtDireccion"
      Me.txtDireccion.ReadOnly = True
      Me.txtDireccion.Size = New System.Drawing.Size(243, 20)
      Me.txtDireccion.TabIndex = 7
      '
      'lblDireccion
      '
      Me.lblDireccion.AutoSize = True
      Me.lblDireccion.Location = New System.Drawing.Point(556, 18)
      Me.lblDireccion.Name = "lblDireccion"
      Me.lblDireccion.Size = New System.Drawing.Size(52, 13)
      Me.lblDireccion.TabIndex = 6
      Me.lblDireccion.Text = "Dirección"
      '
      'dgvOperaciones
      '
      Me.dgvOperaciones.AllowUserToAddRows = False
      Me.dgvOperaciones.AllowUserToDeleteRows = False
      Me.dgvOperaciones.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.dgvOperaciones.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.TipoComprobante, Me.Letra, Me.NumeroComprobante, Me.Fecha, Me.Neto210, Me.DescuentoRecargo, Me.Iva210, Me.Iva105, Me.ImporteTotal, Me.Observacion})
      Me.dgvOperaciones.Location = New System.Drawing.Point(12, 96)
      Me.dgvOperaciones.Name = "dgvOperaciones"
      Me.dgvOperaciones.ReadOnly = True
      Me.dgvOperaciones.Size = New System.Drawing.Size(850, 174)
      Me.dgvOperaciones.TabIndex = 13
      '
      'TipoComprobante
      '
      Me.TipoComprobante.DataPropertyName = "IdTipoComprobante"
      Me.TipoComprobante.HeaderText = "Tipo Comp."
      Me.TipoComprobante.Name = "TipoComprobante"
      Me.TipoComprobante.ReadOnly = True
      Me.TipoComprobante.Width = 80
      '
      'Letra
      '
      Me.Letra.DataPropertyName = "Letra"
      DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
      Me.Letra.DefaultCellStyle = DataGridViewCellStyle1
      Me.Letra.HeaderText = "Letra"
      Me.Letra.Name = "Letra"
      Me.Letra.ReadOnly = True
      Me.Letra.Width = 40
      '
      'NumeroComprobante
      '
      Me.NumeroComprobante.DataPropertyName = "NumeroComprobante"
      DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
      Me.NumeroComprobante.DefaultCellStyle = DataGridViewCellStyle2
      Me.NumeroComprobante.HeaderText = "Comprobante"
      Me.NumeroComprobante.Name = "NumeroComprobante"
      Me.NumeroComprobante.ReadOnly = True
      '
      'Fecha
      '
      Me.Fecha.DataPropertyName = "Fecha"
      DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
      Me.Fecha.DefaultCellStyle = DataGridViewCellStyle3
      Me.Fecha.HeaderText = "Fecha"
      Me.Fecha.Name = "Fecha"
      Me.Fecha.ReadOnly = True
      '
      'Neto210
      '
      Me.Neto210.DataPropertyName = "Neto210"
      DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
      Me.Neto210.DefaultCellStyle = DataGridViewCellStyle4
      Me.Neto210.HeaderText = "Neto 21%"
      Me.Neto210.Name = "Neto210"
      Me.Neto210.ReadOnly = True
      Me.Neto210.Width = 80
      '
      'DescuentoRecargo
      '
      Me.DescuentoRecargo.DataPropertyName = "DescuentoRecargo"
      DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
      Me.DescuentoRecargo.DefaultCellStyle = DataGridViewCellStyle5
      Me.DescuentoRecargo.HeaderText = "Desc/Recargo"
      Me.DescuentoRecargo.Name = "DescuentoRecargo"
      Me.DescuentoRecargo.ReadOnly = True
      Me.DescuentoRecargo.Width = 80
      '
      'Iva210
      '
      Me.Iva210.DataPropertyName = "Iva210"
      DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
      Me.Iva210.DefaultCellStyle = DataGridViewCellStyle6
      Me.Iva210.HeaderText = "Iva 21%"
      Me.Iva210.Name = "Iva210"
      Me.Iva210.ReadOnly = True
      Me.Iva210.Width = 80
      '
      'Iva105
      '
      Me.Iva105.DataPropertyName = "Iva105"
      DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
      Me.Iva105.DefaultCellStyle = DataGridViewCellStyle7
      Me.Iva105.HeaderText = "Iva 10.5%"
      Me.Iva105.Name = "Iva105"
      Me.Iva105.ReadOnly = True
      Me.Iva105.Width = 80
      '
      'ImporteTotal
      '
      Me.ImporteTotal.DataPropertyName = "ImporteTotal"
      DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
      Me.ImporteTotal.DefaultCellStyle = DataGridViewCellStyle8
      Me.ImporteTotal.HeaderText = "Total"
      Me.ImporteTotal.Name = "ImporteTotal"
      Me.ImporteTotal.ReadOnly = True
      Me.ImporteTotal.Width = 80
      '
      'Observacion
      '
      Me.Observacion.DataPropertyName = "Observacion"
      Me.Observacion.HeaderText = "Observacion"
      Me.Observacion.Name = "Observacion"
      Me.Observacion.ReadOnly = True
      '
      'Label1
      '
      Me.Label1.AutoSize = True
      Me.Label1.Location = New System.Drawing.Point(556, 43)
      Me.Label1.Name = "Label1"
      Me.Label1.Size = New System.Drawing.Size(53, 13)
      Me.Label1.TabIndex = 8
      Me.Label1.Text = "Localidad"
      '
      'bscCodigoProveedor
      '
      Me.bscCodigoProveedor.AyudaAncho = 608
      Me.bscCodigoProveedor.BindearPropiedadControl = Nothing
      Me.bscCodigoProveedor.BindearPropiedadEntidad = Nothing
      Me.bscCodigoProveedor.ColumnasAlineacion = Nothing
      Me.bscCodigoProveedor.ColumnasAncho = Nothing
      Me.bscCodigoProveedor.ColumnasFormato = Nothing
      Me.bscCodigoProveedor.ColumnasOcultas = Nothing
      Me.bscCodigoProveedor.ColumnasTitulos = Nothing
      Me.bscCodigoProveedor.Datos = Nothing
      Me.bscCodigoProveedor.FilaDevuelta = Nothing
      Me.bscCodigoProveedor.ForeColorFocus = System.Drawing.Color.Red
      Me.bscCodigoProveedor.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
      Me.bscCodigoProveedor.IsDecimal = False
      Me.bscCodigoProveedor.IsNumber = False
      Me.bscCodigoProveedor.IsPK = False
      Me.bscCodigoProveedor.IsRequired = False
      Me.bscCodigoProveedor.Key = ""
      Me.bscCodigoProveedor.LabelAsoc = Me.lblCodigoProveedor
      Me.bscCodigoProveedor.Location = New System.Drawing.Point(12, 40)
      Me.bscCodigoProveedor.MaxLengh = "32767"
      Me.bscCodigoProveedor.Name = "bscCodigoProveedor"
      Me.bscCodigoProveedor.Permitido = True
      Me.bscCodigoProveedor.Selecciono = False
      Me.bscCodigoProveedor.Size = New System.Drawing.Size(116, 20)
      Me.bscCodigoProveedor.TabIndex = 0
      Me.bscCodigoProveedor.Titulo = Nothing
      '
      'lblCodigoProveedor
      '
      Me.lblCodigoProveedor.AutoSize = True
      Me.lblCodigoProveedor.Location = New System.Drawing.Point(11, 25)
      Me.lblCodigoProveedor.Name = "lblCodigoProveedor"
      Me.lblCodigoProveedor.Size = New System.Drawing.Size(85, 13)
      Me.lblCodigoProveedor.TabIndex = 1
      Me.lblCodigoProveedor.Text = "Nro. Documento"
      '
      'bscProveedor
      '
      Me.bscProveedor.AyudaAncho = 608
      Me.bscProveedor.BindearPropiedadControl = Nothing
      Me.bscProveedor.BindearPropiedadEntidad = Nothing
      Me.bscProveedor.ColumnasAlineacion = Nothing
      Me.bscProveedor.ColumnasAncho = Nothing
      Me.bscProveedor.ColumnasFormato = Nothing
      Me.bscProveedor.ColumnasOcultas = Nothing
      Me.bscProveedor.ColumnasTitulos = Nothing
      Me.bscProveedor.Datos = Nothing
      Me.bscProveedor.FilaDevuelta = Nothing
      Me.bscProveedor.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.bscProveedor.ForeColorFocus = System.Drawing.Color.Red
      Me.bscProveedor.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
      Me.bscProveedor.IsDecimal = False
      Me.bscProveedor.IsNumber = False
      Me.bscProveedor.IsPK = False
      Me.bscProveedor.IsRequired = False
      Me.bscProveedor.Key = ""
      Me.bscProveedor.LabelAsoc = Me.lblNombreProveedor
      Me.bscProveedor.Location = New System.Drawing.Point(132, 40)
      Me.bscProveedor.Margin = New System.Windows.Forms.Padding(4)
      Me.bscProveedor.MaxLengh = "32767"
      Me.bscProveedor.Name = "bscProveedor"
      Me.bscProveedor.Permitido = True
      Me.bscProveedor.Selecciono = False
      Me.bscProveedor.Size = New System.Drawing.Size(319, 20)
      Me.bscProveedor.TabIndex = 2
      Me.bscProveedor.Titulo = Nothing
      '
      'lblNombreProveedor
      '
      Me.lblNombreProveedor.AutoSize = True
      Me.lblNombreProveedor.Location = New System.Drawing.Point(131, 25)
      Me.lblNombreProveedor.Name = "lblNombreProveedor"
      Me.lblNombreProveedor.Size = New System.Drawing.Size(44, 13)
      Me.lblNombreProveedor.TabIndex = 3
      Me.lblNombreProveedor.Text = "Nombre"
      '
      'Label3
      '
      Me.Label3.AutoSize = True
      Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.Label3.Location = New System.Drawing.Point(8, 75)
      Me.Label3.Name = "Label3"
      Me.Label3.Size = New System.Drawing.Size(165, 13)
      Me.Label3.TabIndex = 12
      Me.Label3.Text = "Operaciones del último año:"
      '
      'tstBarra
      '
      Me.tstBarra.ImageScalingSize = New System.Drawing.Size(22, 22)
      Me.tstBarra.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsbActualizar, Me.ToolStripSeparator1, Me.tsbSalir})
      Me.tstBarra.Location = New System.Drawing.Point(0, 0)
      Me.tstBarra.Name = "tstBarra"
      Me.tstBarra.Size = New System.Drawing.Size(895, 29)
      Me.tstBarra.TabIndex = 2
      Me.tstBarra.Text = "ToolStrip1"
      '
      'tsbActualizar
      '
      Me.tsbActualizar.Image = Global.Eniac.Win.My.Resources.Resources.check2
      Me.tsbActualizar.ImageTransparentColor = System.Drawing.Color.Magenta
      Me.tsbActualizar.Name = "tsbActualizar"
      Me.tsbActualizar.Size = New System.Drawing.Size(85, 26)
      Me.tsbActualizar.Text = "&Actualizar"
      Me.tsbActualizar.ToolTipText = "Refrescar el formulario"
      '
      'ToolStripSeparator1
      '
      Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
      Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 29)
      '
      'tsbSalir
      '
      Me.tsbSalir.Image = Global.Eniac.Win.My.Resources.Resources.redo
      Me.tsbSalir.ImageTransparentColor = System.Drawing.Color.Magenta
      Me.tsbSalir.Name = "tsbSalir"
      Me.tsbSalir.Size = New System.Drawing.Size(65, 26)
      Me.tsbSalir.Text = "&Cerrar"
      Me.tsbSalir.ToolTipText = "Cerrar el formulario de Tareas"
      '
      'ProveedorCambiarCod
      '
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.ClientSize = New System.Drawing.Size(895, 398)
      Me.Controls.Add(Me.tstBarra)
      Me.Controls.Add(Me.GroupBox1)
      Me.Controls.Add(Me.grbProveedor)
      Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
      Me.Name = "ProveedorCambiarCod"
      Me.ShowInTaskbar = False
      Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
      Me.Text = "Cambiar Codigo de Proveedor"
      Me.GroupBox1.ResumeLayout(False)
      Me.GroupBox1.PerformLayout()
      Me.grbProveedor.ResumeLayout(False)
      Me.grbProveedor.PerformLayout()
      CType(Me.dgvOperaciones, System.ComponentModel.ISupportInitialize).EndInit()
      Me.tstBarra.ResumeLayout(False)
      Me.tstBarra.PerformLayout()
      Me.ResumeLayout(False)
      Me.PerformLayout()

   End Sub
   Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
   Friend WithEvents bscCodigoProveedorRec As Eniac.Controles.Buscador
   Friend WithEvents lblCodigoProveedorRec As Eniac.Controles.Label
   Friend WithEvents grbProveedor As System.Windows.Forms.GroupBox
   Friend WithEvents tstBarra As System.Windows.Forms.ToolStrip
   Friend WithEvents tsbActualizar As System.Windows.Forms.ToolStripButton
   Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
   Friend WithEvents tsbSalir As System.Windows.Forms.ToolStripButton
   Friend WithEvents Label3 As Eniac.Controles.Label
   Friend WithEvents bscCodigoProveedor As Eniac.Controles.Buscador
   Friend WithEvents lblCodigoProveedor As Eniac.Controles.Label
   Friend WithEvents bscProveedor As Eniac.Controles.Buscador
   Friend WithEvents lblNombreProveedor As Eniac.Controles.Label
   Friend WithEvents lblDireccion As Eniac.Controles.Label
   Friend WithEvents lblTelefono As Eniac.Controles.Label
   Friend WithEvents dgvOperaciones As Eniac.Controles.DataGridView
   Friend WithEvents Label1 As Eniac.Controles.Label
   Friend WithEvents txtLocalidad As Eniac.Controles.TextBox
   Friend WithEvents txtTelefono As Eniac.Controles.TextBox
   Friend WithEvents txtDireccion As Eniac.Controles.TextBox
   Friend WithEvents TipoComprobante As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents Letra As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents NumeroComprobante As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents Fecha As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents Neto210 As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents DescuentoRecargo As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents Iva210 As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents Iva105 As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents ImporteTotal As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents Observacion As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
