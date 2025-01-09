<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ClienteCambiarCod
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
      Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
      Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
      Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
      Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
      Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
      Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
      Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ClienteCambiarCod))
      Me.GroupBox1 = New System.Windows.Forms.GroupBox
      Me.bscNroDocRec = New Eniac.Controles.Buscador
      Me.Label5 = New Eniac.Controles.Label
      Me.cmbTipoDocRec = New Eniac.Controles.ComboBox
      Me.Label6 = New Eniac.Controles.Label
      Me.grbCliente = New System.Windows.Forms.GroupBox
      Me.Label7 = New Eniac.Controles.Label
      Me.txtLocalidad = New Eniac.Controles.TextBox
      Me.lblTelefono = New Eniac.Controles.Label
      Me.txtTelefono = New Eniac.Controles.TextBox
      Me.lblDireccion = New Eniac.Controles.Label
      Me.txtDireccion = New Eniac.Controles.TextBox
      Me.dgvOperaciones = New Eniac.Controles.DataGridView
      Me.TipoComprobante = New System.Windows.Forms.DataGridViewTextBoxColumn
      Me.Letra = New System.Windows.Forms.DataGridViewTextBoxColumn
      Me.NumeroComprobante = New System.Windows.Forms.DataGridViewTextBoxColumn
      Me.Fecha = New System.Windows.Forms.DataGridViewTextBoxColumn
      Me.SubTotal = New System.Windows.Forms.DataGridViewTextBoxColumn
      Me.TotalImpuestos = New System.Windows.Forms.DataGridViewTextBoxColumn
      Me.ImporteTotal = New System.Windows.Forms.DataGridViewTextBoxColumn
      Me.Observacion = New System.Windows.Forms.DataGridViewTextBoxColumn
      Me.Label3 = New Eniac.Controles.Label
      Me.bscCodigoCliente = New Eniac.Controles.Buscador
      Me.Label2 = New Eniac.Controles.Label
      Me.cmbTipoDoc = New Eniac.Controles.ComboBox
      Me.Label4 = New Eniac.Controles.Label
      Me.bscCliente = New Eniac.Controles.Buscador
      Me.Label1 = New Eniac.Controles.Label
      Me.tstBarra = New System.Windows.Forms.ToolStrip
      Me.tsbActualizar = New System.Windows.Forms.ToolStripButton
      Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator
      Me.tsbSalir = New System.Windows.Forms.ToolStripButton
      Me.GroupBox1.SuspendLayout()
      Me.grbCliente.SuspendLayout()
      CType(Me.dgvOperaciones, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.tstBarra.SuspendLayout()
      Me.SuspendLayout()
      '
      'GroupBox1
      '
      Me.GroupBox1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
                  Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.GroupBox1.Controls.Add(Me.bscNroDocRec)
      Me.GroupBox1.Controls.Add(Me.Label5)
      Me.GroupBox1.Controls.Add(Me.cmbTipoDocRec)
      Me.GroupBox1.Controls.Add(Me.Label6)
      Me.GroupBox1.Location = New System.Drawing.Point(8, 325)
      Me.GroupBox1.Name = "GroupBox1"
      Me.GroupBox1.Size = New System.Drawing.Size(875, 65)
      Me.GroupBox1.TabIndex = 1
      Me.GroupBox1.TabStop = False
      Me.GroupBox1.Text = "Cliente Destino"
      '
      'bscNroDocRec
      '
      Me.bscNroDocRec.AyudaAncho = 608
      Me.bscNroDocRec.BindearPropiedadControl = Nothing
      Me.bscNroDocRec.BindearPropiedadEntidad = Nothing
      Me.bscNroDocRec.ColumnasAlineacion = Nothing
      Me.bscNroDocRec.ColumnasAncho = Nothing
      Me.bscNroDocRec.ColumnasFormato = Nothing
      Me.bscNroDocRec.ColumnasOcultas = Nothing
      Me.bscNroDocRec.ColumnasTitulos = Nothing
      Me.bscNroDocRec.Datos = Nothing
      Me.bscNroDocRec.FilaDevuelta = Nothing
      Me.bscNroDocRec.ForeColorFocus = System.Drawing.Color.Red
      Me.bscNroDocRec.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
      Me.bscNroDocRec.IsDecimal = False
      Me.bscNroDocRec.IsNumber = False
      Me.bscNroDocRec.IsPK = False
      Me.bscNroDocRec.IsRequired = True
      Me.bscNroDocRec.Key = ""
      Me.bscNroDocRec.LabelAsoc = Nothing
      Me.bscNroDocRec.Location = New System.Drawing.Point(110, 36)
      Me.bscNroDocRec.MaxLengh = "32767"
      Me.bscNroDocRec.Name = "bscNroDocRec"
      Me.bscNroDocRec.Permitido = True
      Me.bscNroDocRec.Selecciono = False
      Me.bscNroDocRec.Size = New System.Drawing.Size(116, 20)
      Me.bscNroDocRec.TabIndex = 0
      Me.bscNroDocRec.Titulo = Nothing
      '
      'Label5
      '
      Me.Label5.AutoSize = True
      Me.Label5.Location = New System.Drawing.Point(110, 21)
      Me.Label5.Name = "Label5"
      Me.Label5.Size = New System.Drawing.Size(85, 13)
      Me.Label5.TabIndex = 1
      Me.Label5.Text = "Nro. Documento"
      '
      'cmbTipoDocRec
      '
      Me.cmbTipoDocRec.BindearPropiedadControl = Nothing
      Me.cmbTipoDocRec.BindearPropiedadEntidad = Nothing
      Me.cmbTipoDocRec.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cmbTipoDocRec.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.cmbTipoDocRec.ForeColorFocus = System.Drawing.Color.Red
      Me.cmbTipoDocRec.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.cmbTipoDocRec.FormattingEnabled = True
      Me.cmbTipoDocRec.IsPK = False
      Me.cmbTipoDocRec.IsRequired = False
      Me.cmbTipoDocRec.Key = Nothing
      Me.cmbTipoDocRec.LabelAsoc = Nothing
      Me.cmbTipoDocRec.Location = New System.Drawing.Point(21, 36)
      Me.cmbTipoDocRec.Name = "cmbTipoDocRec"
      Me.cmbTipoDocRec.Size = New System.Drawing.Size(83, 21)
      Me.cmbTipoDocRec.TabIndex = 2
      Me.cmbTipoDocRec.TabStop = False
      '
      'Label6
      '
      Me.Label6.AutoSize = True
      Me.Label6.Location = New System.Drawing.Point(18, 21)
      Me.Label6.Name = "Label6"
      Me.Label6.Size = New System.Drawing.Size(86, 13)
      Me.Label6.TabIndex = 3
      Me.Label6.Text = "Tipo Documento"
      '
      'grbCliente
      '
      Me.grbCliente.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                  Or System.Windows.Forms.AnchorStyles.Left) _
                  Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.grbCliente.Controls.Add(Me.Label7)
      Me.grbCliente.Controls.Add(Me.txtLocalidad)
      Me.grbCliente.Controls.Add(Me.lblTelefono)
      Me.grbCliente.Controls.Add(Me.txtTelefono)
      Me.grbCliente.Controls.Add(Me.lblDireccion)
      Me.grbCliente.Controls.Add(Me.txtDireccion)
      Me.grbCliente.Controls.Add(Me.dgvOperaciones)
      Me.grbCliente.Controls.Add(Me.Label3)
      Me.grbCliente.Controls.Add(Me.bscCodigoCliente)
      Me.grbCliente.Controls.Add(Me.Label2)
      Me.grbCliente.Controls.Add(Me.cmbTipoDoc)
      Me.grbCliente.Controls.Add(Me.Label4)
      Me.grbCliente.Controls.Add(Me.bscCliente)
      Me.grbCliente.Controls.Add(Me.Label1)
      Me.grbCliente.Location = New System.Drawing.Point(8, 42)
      Me.grbCliente.Name = "grbCliente"
      Me.grbCliente.Size = New System.Drawing.Size(875, 277)
      Me.grbCliente.TabIndex = 0
      Me.grbCliente.TabStop = False
      Me.grbCliente.Text = "Cliente Origen"
      '
      'Label7
      '
      Me.Label7.AutoSize = True
      Me.Label7.Location = New System.Drawing.Point(564, 45)
      Me.Label7.Name = "Label7"
      Me.Label7.Size = New System.Drawing.Size(53, 13)
      Me.Label7.TabIndex = 8
      Me.Label7.Text = "Localidad"
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
      Me.txtLocalidad.LabelAsoc = Me.Label7
      Me.txtLocalidad.Location = New System.Drawing.Point(627, 40)
      Me.txtLocalidad.MaxLength = 100
      Me.txtLocalidad.Name = "txtLocalidad"
      Me.txtLocalidad.ReadOnly = True
      Me.txtLocalidad.Size = New System.Drawing.Size(101, 20)
      Me.txtLocalidad.TabIndex = 9
      '
      'lblTelefono
      '
      Me.lblTelefono.AutoSize = True
      Me.lblTelefono.Location = New System.Drawing.Point(564, 71)
      Me.lblTelefono.Name = "lblTelefono"
      Me.lblTelefono.Size = New System.Drawing.Size(49, 13)
      Me.lblTelefono.TabIndex = 10
      Me.lblTelefono.Text = "Teléfono"
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
      Me.txtTelefono.Location = New System.Drawing.Point(627, 66)
      Me.txtTelefono.MaxLength = 100
      Me.txtTelefono.Name = "txtTelefono"
      Me.txtTelefono.ReadOnly = True
      Me.txtTelefono.Size = New System.Drawing.Size(189, 20)
      Me.txtTelefono.TabIndex = 11
      '
      'lblDireccion
      '
      Me.lblDireccion.AutoSize = True
      Me.lblDireccion.Location = New System.Drawing.Point(564, 20)
      Me.lblDireccion.Name = "lblDireccion"
      Me.lblDireccion.Size = New System.Drawing.Size(52, 13)
      Me.lblDireccion.TabIndex = 6
      Me.lblDireccion.Text = "Dirección"
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
      Me.txtDireccion.Location = New System.Drawing.Point(626, 16)
      Me.txtDireccion.MaxLength = 100
      Me.txtDireccion.Name = "txtDireccion"
      Me.txtDireccion.ReadOnly = True
      Me.txtDireccion.Size = New System.Drawing.Size(243, 20)
      Me.txtDireccion.TabIndex = 7
      '
      'dgvOperaciones
      '
      Me.dgvOperaciones.AllowUserToAddRows = False
      Me.dgvOperaciones.AllowUserToDeleteRows = False
      Me.dgvOperaciones.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                  Or System.Windows.Forms.AnchorStyles.Left) _
                  Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.dgvOperaciones.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.TipoComprobante, Me.Letra, Me.NumeroComprobante, Me.Fecha, Me.SubTotal, Me.TotalImpuestos, Me.ImporteTotal, Me.Observacion})
      Me.dgvOperaciones.Location = New System.Drawing.Point(12, 93)
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
      'SubTotal
      '
      Me.SubTotal.DataPropertyName = "SubTotal"
      DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
      Me.SubTotal.DefaultCellStyle = DataGridViewCellStyle4
      Me.SubTotal.HeaderText = "Neto"
      Me.SubTotal.Name = "SubTotal"
      Me.SubTotal.ReadOnly = True
      Me.SubTotal.Width = 80
      '
      'TotalImpuestos
      '
      Me.TotalImpuestos.DataPropertyName = "TotalImpuestos"
      DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
      Me.TotalImpuestos.DefaultCellStyle = DataGridViewCellStyle5
      Me.TotalImpuestos.HeaderText = "Impuestos"
      Me.TotalImpuestos.Name = "TotalImpuestos"
      Me.TotalImpuestos.ReadOnly = True
      Me.TotalImpuestos.Width = 80
      '
      'ImporteTotal
      '
      Me.ImporteTotal.DataPropertyName = "ImporteTotal"
      DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
      Me.ImporteTotal.DefaultCellStyle = DataGridViewCellStyle6
      Me.ImporteTotal.HeaderText = "Total"
      Me.ImporteTotal.Name = "ImporteTotal"
      Me.ImporteTotal.ReadOnly = True
      Me.ImporteTotal.Width = 80
      '
      'Observacion
      '
      Me.Observacion.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
      Me.Observacion.DataPropertyName = "Observacion"
      Me.Observacion.HeaderText = "Observacion"
      Me.Observacion.Name = "Observacion"
      Me.Observacion.ReadOnly = True
      '
      'Label3
      '
      Me.Label3.AutoSize = True
      Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.Label3.Location = New System.Drawing.Point(8, 69)
      Me.Label3.Name = "Label3"
      Me.Label3.Size = New System.Drawing.Size(165, 13)
      Me.Label3.TabIndex = 12
      Me.Label3.Text = "Operaciones del último año:"
      '
      'bscCodigoCliente
      '
      Me.bscCodigoCliente.AyudaAncho = 608
      Me.bscCodigoCliente.BindearPropiedadControl = Nothing
      Me.bscCodigoCliente.BindearPropiedadEntidad = Nothing
      Me.bscCodigoCliente.ColumnasAlineacion = Nothing
      Me.bscCodigoCliente.ColumnasAncho = Nothing
      Me.bscCodigoCliente.ColumnasFormato = Nothing
      Me.bscCodigoCliente.ColumnasOcultas = Nothing
      Me.bscCodigoCliente.ColumnasTitulos = Nothing
      Me.bscCodigoCliente.Datos = Nothing
      Me.bscCodigoCliente.FilaDevuelta = Nothing
      Me.bscCodigoCliente.ForeColorFocus = System.Drawing.Color.Red
      Me.bscCodigoCliente.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
      Me.bscCodigoCliente.IsDecimal = False
      Me.bscCodigoCliente.IsNumber = False
      Me.bscCodigoCliente.IsPK = False
      Me.bscCodigoCliente.IsRequired = False
      Me.bscCodigoCliente.Key = ""
      Me.bscCodigoCliente.LabelAsoc = Nothing
      Me.bscCodigoCliente.Location = New System.Drawing.Point(100, 38)
      Me.bscCodigoCliente.MaxLengh = "32767"
      Me.bscCodigoCliente.Name = "bscCodigoCliente"
      Me.bscCodigoCliente.Permitido = True
      Me.bscCodigoCliente.Selecciono = False
      Me.bscCodigoCliente.Size = New System.Drawing.Size(90, 20)
      Me.bscCodigoCliente.TabIndex = 0
      Me.bscCodigoCliente.Titulo = Nothing
      '
      'Label2
      '
      Me.Label2.AutoSize = True
      Me.Label2.Location = New System.Drawing.Point(100, 23)
      Me.Label2.Name = "Label2"
      Me.Label2.Size = New System.Drawing.Size(85, 13)
      Me.Label2.TabIndex = 1
      Me.Label2.Text = "Nro. Documento"
      '
      'cmbTipoDoc
      '
      Me.cmbTipoDoc.BindearPropiedadControl = Nothing
      Me.cmbTipoDoc.BindearPropiedadEntidad = Nothing
      Me.cmbTipoDoc.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cmbTipoDoc.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.cmbTipoDoc.ForeColorFocus = System.Drawing.Color.Red
      Me.cmbTipoDoc.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.cmbTipoDoc.FormattingEnabled = True
      Me.cmbTipoDoc.IsPK = False
      Me.cmbTipoDoc.IsRequired = False
      Me.cmbTipoDoc.Key = Nothing
      Me.cmbTipoDoc.LabelAsoc = Nothing
      Me.cmbTipoDoc.Location = New System.Drawing.Point(11, 38)
      Me.cmbTipoDoc.Name = "cmbTipoDoc"
      Me.cmbTipoDoc.Size = New System.Drawing.Size(83, 21)
      Me.cmbTipoDoc.TabIndex = 4
      Me.cmbTipoDoc.TabStop = False
      '
      'Label4
      '
      Me.Label4.AutoSize = True
      Me.Label4.Location = New System.Drawing.Point(8, 23)
      Me.Label4.Name = "Label4"
      Me.Label4.Size = New System.Drawing.Size(86, 13)
      Me.Label4.TabIndex = 5
      Me.Label4.Text = "Tipo Documento"
      '
      'bscCliente
      '
      Me.bscCliente.AutoSize = True
      Me.bscCliente.AyudaAncho = 608
      Me.bscCliente.BindearPropiedadControl = Nothing
      Me.bscCliente.BindearPropiedadEntidad = Nothing
      Me.bscCliente.ColumnasAlineacion = Nothing
      Me.bscCliente.ColumnasAncho = Nothing
      Me.bscCliente.ColumnasFormato = Nothing
      Me.bscCliente.ColumnasOcultas = Nothing
      Me.bscCliente.ColumnasTitulos = Nothing
      Me.bscCliente.Datos = Nothing
      Me.bscCliente.FilaDevuelta = Nothing
      Me.bscCliente.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.bscCliente.ForeColorFocus = System.Drawing.Color.Red
      Me.bscCliente.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
      Me.bscCliente.IsDecimal = False
      Me.bscCliente.IsNumber = False
      Me.bscCliente.IsPK = False
      Me.bscCliente.IsRequired = False
      Me.bscCliente.Key = ""
      Me.bscCliente.LabelAsoc = Nothing
      Me.bscCliente.Location = New System.Drawing.Point(222, 38)
      Me.bscCliente.Margin = New System.Windows.Forms.Padding(4)
      Me.bscCliente.MaxLengh = "32767"
      Me.bscCliente.Name = "bscCliente"
      Me.bscCliente.Permitido = True
      Me.bscCliente.Selecciono = False
      Me.bscCliente.Size = New System.Drawing.Size(336, 23)
      Me.bscCliente.TabIndex = 2
      Me.bscCliente.Titulo = Nothing
      '
      'Label1
      '
      Me.Label1.AutoSize = True
      Me.Label1.Location = New System.Drawing.Point(219, 24)
      Me.Label1.Name = "Label1"
      Me.Label1.Size = New System.Drawing.Size(44, 13)
      Me.Label1.TabIndex = 3
      Me.Label1.Text = "Nombre"
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
      'ClienteCambiarCod
      '
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.ClientSize = New System.Drawing.Size(895, 398)
      Me.Controls.Add(Me.tstBarra)
      Me.Controls.Add(Me.GroupBox1)
      Me.Controls.Add(Me.grbCliente)
      Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
      Me.Name = "ClienteCambiarCod"
      Me.ShowInTaskbar = False
      Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
      Me.Text = "Cambiar Codigo de Cliente"
      Me.GroupBox1.ResumeLayout(False)
      Me.GroupBox1.PerformLayout()
      Me.grbCliente.ResumeLayout(False)
      Me.grbCliente.PerformLayout()
      CType(Me.dgvOperaciones, System.ComponentModel.ISupportInitialize).EndInit()
      Me.tstBarra.ResumeLayout(False)
      Me.tstBarra.PerformLayout()
      Me.ResumeLayout(False)
      Me.PerformLayout()

   End Sub
   Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
   Friend WithEvents bscNroDocRec As Eniac.Controles.Buscador
   Friend WithEvents Label5 As Eniac.Controles.Label
   Friend WithEvents cmbTipoDocRec As Eniac.Controles.ComboBox
   Friend WithEvents Label6 As Eniac.Controles.Label
   Friend WithEvents grbCliente As System.Windows.Forms.GroupBox
   Friend WithEvents bscCodigoCliente As Eniac.Controles.Buscador
   Friend WithEvents Label2 As Eniac.Controles.Label
   Friend WithEvents cmbTipoDoc As Eniac.Controles.ComboBox
   Friend WithEvents Label4 As Eniac.Controles.Label
   Friend WithEvents bscCliente As Eniac.Controles.Buscador
   Friend WithEvents Label1 As Eniac.Controles.Label
   Friend WithEvents tstBarra As System.Windows.Forms.ToolStrip
   Friend WithEvents tsbActualizar As System.Windows.Forms.ToolStripButton
   Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
   Friend WithEvents tsbSalir As System.Windows.Forms.ToolStripButton
   Friend WithEvents Label3 As Eniac.Controles.Label
   Friend WithEvents dgvOperaciones As Eniac.Controles.DataGridView
   Friend WithEvents Label7 As Eniac.Controles.Label
   Friend WithEvents txtLocalidad As Eniac.Controles.TextBox
   Friend WithEvents lblTelefono As Eniac.Controles.Label
   Friend WithEvents txtTelefono As Eniac.Controles.TextBox
   Friend WithEvents lblDireccion As Eniac.Controles.Label
   Friend WithEvents txtDireccion As Eniac.Controles.TextBox
   Friend WithEvents TipoComprobante As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents Letra As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents NumeroComprobante As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents Fecha As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents SubTotal As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents TotalImpuestos As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents ImporteTotal As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents Observacion As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
