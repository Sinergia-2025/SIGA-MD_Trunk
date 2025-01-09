<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CuentaCorriente
    Inherits BaseForm

    'Form overrides dispose to clean up the component list.
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
      Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(CuentaCorriente))
      Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
      Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
      Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
      Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
      Me.btnAceptar = New Eniac.Controles.Button()
      Me.btnCancelar = New Eniac.Controles.Button()
      Me.grbFormaPago = New System.Windows.Forms.GroupBox()
      Me.btnLimpiarProducto = New Eniac.Controles.Button()
      Me.grbVariasCuotas = New System.Windows.Forms.GroupBox()
      Me.txtPrimeraCuota = New Eniac.Controles.TextBox()
      Me.lblCuotas = New Eniac.Controles.Label()
      Me.chbPrimerCuota = New System.Windows.Forms.CheckBox()
      Me.chbDiaFijo = New System.Windows.Forms.CheckBox()
      Me.txtCuotas = New Eniac.Controles.TextBox()
      Me.cmbFormaPago = New Eniac.Controles.ComboBox()
      Me.lblFormaPago = New Eniac.Controles.Label()
      Me.btnEliminarVC = New Eniac.Controles.Button()
      Me.btnInsertarVC = New Eniac.Controles.Button()
      Me.dtpPrimerVencimiento = New Eniac.Controles.DateTimePicker()
      Me.lblPrimerVencimiento = New Eniac.Controles.Label()
      Me.lblRestan = New Eniac.Controles.Label()
      Me.txtRestan = New Eniac.Controles.TextBox()
      Me.dgvCuotas = New Eniac.Controles.DataGridView()
      Me.MontoAPagar = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.Cuota = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.Dias = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.FechaAPagar = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.grbUnaCuota = New System.Windows.Forms.GroupBox()
      Me.btnEliminar = New Eniac.Controles.Button()
      Me.btnInsertar = New Eniac.Controles.Button()
      Me.lblDias = New Eniac.Controles.Label()
      Me.txtDias = New Eniac.Controles.TextBox()
      Me.dtpFechaAPagar = New Eniac.Controles.DateTimePicker()
      Me.lblFechaAPagar = New Eniac.Controles.Label()
      Me.lblMonto = New Eniac.Controles.Label()
      Me.txtMonto = New Eniac.Controles.TextBox()
      Me.lblSaldo = New Eniac.Controles.Label()
      Me.txtSaldo = New Eniac.Controles.TextBox()
      Me.grbFormaPago.SuspendLayout()
      Me.grbVariasCuotas.SuspendLayout()
      CType(Me.dgvCuotas, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.grbUnaCuota.SuspendLayout()
      Me.SuspendLayout()
      '
      'btnAceptar
      '
      Me.btnAceptar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.btnAceptar.AutoSize = True
      Me.btnAceptar.Image = Global.Eniac.Win.My.Resources.Resources.ok_24
      Me.btnAceptar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
      Me.btnAceptar.Location = New System.Drawing.Point(238, 474)
      Me.btnAceptar.Name = "btnAceptar"
      Me.btnAceptar.Size = New System.Drawing.Size(85, 38)
      Me.btnAceptar.TabIndex = 1
      Me.btnAceptar.Text = "&Aceptar"
      Me.btnAceptar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      Me.btnAceptar.UseVisualStyleBackColor = True
      '
      'btnCancelar
      '
      Me.btnCancelar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.btnCancelar.AutoSize = True
      Me.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel
      Me.btnCancelar.Image = Global.Eniac.Win.My.Resources.Resources.close_a_16
      Me.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
      Me.btnCancelar.Location = New System.Drawing.Point(329, 474)
      Me.btnCancelar.Name = "btnCancelar"
      Me.btnCancelar.Size = New System.Drawing.Size(85, 38)
      Me.btnCancelar.TabIndex = 2
      Me.btnCancelar.Text = "&Cancelar"
      Me.btnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      Me.btnCancelar.UseVisualStyleBackColor = True
      '
      'grbFormaPago
      '
      Me.grbFormaPago.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.grbFormaPago.Controls.Add(Me.btnLimpiarProducto)
      Me.grbFormaPago.Controls.Add(Me.grbVariasCuotas)
      Me.grbFormaPago.Controls.Add(Me.lblRestan)
      Me.grbFormaPago.Controls.Add(Me.txtRestan)
      Me.grbFormaPago.Controls.Add(Me.dgvCuotas)
      Me.grbFormaPago.Controls.Add(Me.grbUnaCuota)
      Me.grbFormaPago.Controls.Add(Me.lblSaldo)
      Me.grbFormaPago.Controls.Add(Me.txtSaldo)
      Me.grbFormaPago.Location = New System.Drawing.Point(12, 12)
      Me.grbFormaPago.Name = "grbFormaPago"
      Me.grbFormaPago.Size = New System.Drawing.Size(402, 456)
      Me.grbFormaPago.TabIndex = 0
      Me.grbFormaPago.TabStop = False
      Me.grbFormaPago.Text = "Forma de pago"
      '
      'btnLimpiarProducto
      '
      Me.btnLimpiarProducto.Image = Global.Eniac.Win.My.Resources.Resources.refresh_32
      Me.btnLimpiarProducto.Location = New System.Drawing.Point(6, 230)
      Me.btnLimpiarProducto.Name = "btnLimpiarProducto"
      Me.btnLimpiarProducto.Size = New System.Drawing.Size(37, 37)
      Me.btnLimpiarProducto.TabIndex = 29
      Me.btnLimpiarProducto.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
      Me.btnLimpiarProducto.UseVisualStyleBackColor = True
      '
      'grbVariasCuotas
      '
      Me.grbVariasCuotas.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.grbVariasCuotas.Controls.Add(Me.txtPrimeraCuota)
      Me.grbVariasCuotas.Controls.Add(Me.chbPrimerCuota)
      Me.grbVariasCuotas.Controls.Add(Me.chbDiaFijo)
      Me.grbVariasCuotas.Controls.Add(Me.txtCuotas)
      Me.grbVariasCuotas.Controls.Add(Me.lblCuotas)
      Me.grbVariasCuotas.Controls.Add(Me.cmbFormaPago)
      Me.grbVariasCuotas.Controls.Add(Me.lblFormaPago)
      Me.grbVariasCuotas.Controls.Add(Me.btnEliminarVC)
      Me.grbVariasCuotas.Controls.Add(Me.btnInsertarVC)
      Me.grbVariasCuotas.Controls.Add(Me.dtpPrimerVencimiento)
      Me.grbVariasCuotas.Controls.Add(Me.lblPrimerVencimiento)
      Me.grbVariasCuotas.Location = New System.Drawing.Point(6, 51)
      Me.grbVariasCuotas.Name = "grbVariasCuotas"
      Me.grbVariasCuotas.Size = New System.Drawing.Size(390, 99)
      Me.grbVariasCuotas.TabIndex = 4
      Me.grbVariasCuotas.TabStop = False
      Me.grbVariasCuotas.Text = "Automático"
      '
      'txtPrimeraCuota
      '
      Me.txtPrimeraCuota.BindearPropiedadControl = Nothing
      Me.txtPrimeraCuota.BindearPropiedadEntidad = Nothing
      Me.txtPrimeraCuota.Enabled = False
      Me.txtPrimeraCuota.ForeColorFocus = System.Drawing.Color.Red
      Me.txtPrimeraCuota.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtPrimeraCuota.Formato = ""
      Me.txtPrimeraCuota.IsDecimal = True
      Me.txtPrimeraCuota.IsNumber = True
      Me.txtPrimeraCuota.IsPK = False
      Me.txtPrimeraCuota.IsRequired = False
      Me.txtPrimeraCuota.Key = ""
      Me.txtPrimeraCuota.LabelAsoc = Me.lblCuotas
      Me.txtPrimeraCuota.Location = New System.Drawing.Point(306, 65)
      Me.txtPrimeraCuota.MaxLength = 15
      Me.txtPrimeraCuota.Name = "txtPrimeraCuota"
      Me.txtPrimeraCuota.Size = New System.Drawing.Size(78, 20)
      Me.txtPrimeraCuota.TabIndex = 11
      Me.txtPrimeraCuota.Text = "0.00"
      Me.txtPrimeraCuota.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'lblCuotas
      '
      Me.lblCuotas.AutoSize = True
      Me.lblCuotas.Location = New System.Drawing.Point(256, 20)
      Me.lblCuotas.Name = "lblCuotas"
      Me.lblCuotas.Size = New System.Drawing.Size(40, 13)
      Me.lblCuotas.TabIndex = 5
      Me.lblCuotas.Text = "Cuotas"
      '
      'chbPrimerCuota
      '
      Me.chbPrimerCuota.AutoSize = True
      Me.chbPrimerCuota.Location = New System.Drawing.Point(228, 67)
      Me.chbPrimerCuota.Name = "chbPrimerCuota"
      Me.chbPrimerCuota.Size = New System.Drawing.Size(75, 17)
      Me.chbPrimerCuota.TabIndex = 10
      Me.chbPrimerCuota.Text = "1er. Cuota"
      Me.chbPrimerCuota.UseVisualStyleBackColor = True
      '
      'chbDiaFijo
      '
      Me.chbDiaFijo.AutoSize = True
      Me.chbDiaFijo.Location = New System.Drawing.Point(150, 67)
      Me.chbDiaFijo.Name = "chbDiaFijo"
      Me.chbDiaFijo.Size = New System.Drawing.Size(63, 17)
      Me.chbDiaFijo.TabIndex = 8
      Me.chbDiaFijo.Text = "Día Fijo"
      Me.chbDiaFijo.UseVisualStyleBackColor = True
      '
      'txtCuotas
      '
      Me.txtCuotas.BindearPropiedadControl = Nothing
      Me.txtCuotas.BindearPropiedadEntidad = Nothing
      Me.txtCuotas.ForeColorFocus = System.Drawing.Color.Red
      Me.txtCuotas.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtCuotas.Formato = ""
      Me.txtCuotas.IsDecimal = False
      Me.txtCuotas.IsNumber = True
      Me.txtCuotas.IsPK = False
      Me.txtCuotas.IsRequired = False
      Me.txtCuotas.Key = ""
      Me.txtCuotas.LabelAsoc = Me.lblCuotas
      Me.txtCuotas.Location = New System.Drawing.Point(254, 36)
      Me.txtCuotas.MaxLength = 4
      Me.txtCuotas.Name = "txtCuotas"
      Me.txtCuotas.Size = New System.Drawing.Size(46, 20)
      Me.txtCuotas.TabIndex = 4
      Me.txtCuotas.Text = "1"
      Me.txtCuotas.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'cmbFormaPago
      '
      Me.cmbFormaPago.BindearPropiedadControl = Nothing
      Me.cmbFormaPago.BindearPropiedadEntidad = Nothing
      Me.cmbFormaPago.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cmbFormaPago.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.cmbFormaPago.ForeColorFocus = System.Drawing.Color.Red
      Me.cmbFormaPago.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.cmbFormaPago.FormattingEnabled = True
      Me.cmbFormaPago.IsPK = False
      Me.cmbFormaPago.IsRequired = False
      Me.cmbFormaPago.Key = Nothing
      Me.cmbFormaPago.LabelAsoc = Me.lblFormaPago
      Me.cmbFormaPago.Location = New System.Drawing.Point(12, 36)
      Me.cmbFormaPago.Name = "cmbFormaPago"
      Me.cmbFormaPago.Size = New System.Drawing.Size(130, 21)
      Me.cmbFormaPago.TabIndex = 0
      '
      'lblFormaPago
      '
      Me.lblFormaPago.AutoSize = True
      Me.lblFormaPago.Location = New System.Drawing.Point(9, 22)
      Me.lblFormaPago.Name = "lblFormaPago"
      Me.lblFormaPago.Size = New System.Drawing.Size(79, 13)
      Me.lblFormaPago.TabIndex = 1
      Me.lblFormaPago.Text = "Forma de &Pago"
      '
      'btnEliminarVC
      '
      Me.btnEliminarVC.Image = CType(resources.GetObject("btnEliminarVC.Image"), System.Drawing.Image)
      Me.btnEliminarVC.Location = New System.Drawing.Point(347, 22)
      Me.btnEliminarVC.Name = "btnEliminarVC"
      Me.btnEliminarVC.Size = New System.Drawing.Size(37, 37)
      Me.btnEliminarVC.TabIndex = 7
      Me.btnEliminarVC.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
      Me.btnEliminarVC.UseVisualStyleBackColor = True
      '
      'btnInsertarVC
      '
      Me.btnInsertarVC.Image = CType(resources.GetObject("btnInsertarVC.Image"), System.Drawing.Image)
      Me.btnInsertarVC.Location = New System.Drawing.Point(306, 22)
      Me.btnInsertarVC.Name = "btnInsertarVC"
      Me.btnInsertarVC.Size = New System.Drawing.Size(37, 37)
      Me.btnInsertarVC.TabIndex = 6
      Me.btnInsertarVC.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
      Me.btnInsertarVC.UseVisualStyleBackColor = True
      '
      'dtpPrimerVencimiento
      '
      Me.dtpPrimerVencimiento.BindearPropiedadControl = Nothing
      Me.dtpPrimerVencimiento.BindearPropiedadEntidad = Nothing
      Me.dtpPrimerVencimiento.CustomFormat = "dd/MM/yyyy"
      Me.dtpPrimerVencimiento.ForeColorFocus = System.Drawing.Color.Red
      Me.dtpPrimerVencimiento.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.dtpPrimerVencimiento.Format = System.Windows.Forms.DateTimePickerFormat.Custom
      Me.dtpPrimerVencimiento.IsPK = False
      Me.dtpPrimerVencimiento.IsRequired = False
      Me.dtpPrimerVencimiento.Key = ""
      Me.dtpPrimerVencimiento.LabelAsoc = Me.lblPrimerVencimiento
      Me.dtpPrimerVencimiento.Location = New System.Drawing.Point(150, 37)
      Me.dtpPrimerVencimiento.Name = "dtpPrimerVencimiento"
      Me.dtpPrimerVencimiento.Size = New System.Drawing.Size(96, 20)
      Me.dtpPrimerVencimiento.TabIndex = 2
      '
      'lblPrimerVencimiento
      '
      Me.lblPrimerVencimiento.AutoSize = True
      Me.lblPrimerVencimiento.Location = New System.Drawing.Point(147, 22)
      Me.lblPrimerVencimiento.Name = "lblPrimerVencimiento"
      Me.lblPrimerVencimiento.Size = New System.Drawing.Size(97, 13)
      Me.lblPrimerVencimiento.TabIndex = 3
      Me.lblPrimerVencimiento.Text = "Primer Vencimiento"
      '
      'lblRestan
      '
      Me.lblRestan.AutoSize = True
      Me.lblRestan.Location = New System.Drawing.Point(173, 26)
      Me.lblRestan.Name = "lblRestan"
      Me.lblRestan.Size = New System.Drawing.Size(41, 13)
      Me.lblRestan.TabIndex = 2
      Me.lblRestan.Text = "Restan"
      '
      'txtRestan
      '
      Me.txtRestan.BindearPropiedadControl = Nothing
      Me.txtRestan.BindearPropiedadEntidad = Nothing
      Me.txtRestan.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.txtRestan.ForeColorFocus = System.Drawing.Color.Red
      Me.txtRestan.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtRestan.Formato = ""
      Me.txtRestan.IsDecimal = True
      Me.txtRestan.IsNumber = True
      Me.txtRestan.IsPK = False
      Me.txtRestan.IsRequired = False
      Me.txtRestan.Key = ""
      Me.txtRestan.LabelAsoc = Me.lblRestan
      Me.txtRestan.Location = New System.Drawing.Point(220, 22)
      Me.txtRestan.Name = "txtRestan"
      Me.txtRestan.ReadOnly = True
      Me.txtRestan.Size = New System.Drawing.Size(100, 23)
      Me.txtRestan.TabIndex = 3
      Me.txtRestan.TabStop = False
      Me.txtRestan.Text = "0.00"
      Me.txtRestan.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'dgvCuotas
      '
      Me.dgvCuotas.AllowUserToAddRows = False
      Me.dgvCuotas.AllowUserToDeleteRows = False
      Me.dgvCuotas.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.dgvCuotas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
      Me.dgvCuotas.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.MontoAPagar, Me.Cuota, Me.Dias, Me.FechaAPagar})
      Me.dgvCuotas.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
      Me.dgvCuotas.Location = New System.Drawing.Point(53, 230)
      Me.dgvCuotas.Name = "dgvCuotas"
      Me.dgvCuotas.RowHeadersVisible = False
      Me.dgvCuotas.RowHeadersWidth = 20
      Me.dgvCuotas.Size = New System.Drawing.Size(305, 218)
      Me.dgvCuotas.TabIndex = 6
      '
      'MontoAPagar
      '
      Me.MontoAPagar.DataPropertyName = "MontoAPagar"
      DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
      DataGridViewCellStyle1.Format = "N2"
      DataGridViewCellStyle1.NullValue = Nothing
      Me.MontoAPagar.DefaultCellStyle = DataGridViewCellStyle1
      Me.MontoAPagar.HeaderText = "Monto"
      Me.MontoAPagar.Name = "MontoAPagar"
      Me.MontoAPagar.Width = 90
      '
      'Cuota
      '
      Me.Cuota.DataPropertyName = "Cuota"
      DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
      Me.Cuota.DefaultCellStyle = DataGridViewCellStyle2
      Me.Cuota.HeaderText = "Cuota"
      Me.Cuota.Name = "Cuota"
      Me.Cuota.Width = 50
      '
      'Dias
      '
      Me.Dias.DataPropertyName = "Dias"
      DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
      Me.Dias.DefaultCellStyle = DataGridViewCellStyle3
      Me.Dias.HeaderText = "Días"
      Me.Dias.Name = "Dias"
      Me.Dias.Width = 50
      '
      'FechaAPagar
      '
      Me.FechaAPagar.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
      Me.FechaAPagar.DataPropertyName = "FechaAPagar"
      DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
      DataGridViewCellStyle4.Format = "dd/MM/yyyy"
      DataGridViewCellStyle4.NullValue = Nothing
      Me.FechaAPagar.DefaultCellStyle = DataGridViewCellStyle4
      Me.FechaAPagar.HeaderText = "Vencimiento"
      Me.FechaAPagar.Name = "FechaAPagar"
      '
      'grbUnaCuota
      '
      Me.grbUnaCuota.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.grbUnaCuota.Controls.Add(Me.btnEliminar)
      Me.grbUnaCuota.Controls.Add(Me.btnInsertar)
      Me.grbUnaCuota.Controls.Add(Me.lblDias)
      Me.grbUnaCuota.Controls.Add(Me.txtDias)
      Me.grbUnaCuota.Controls.Add(Me.dtpFechaAPagar)
      Me.grbUnaCuota.Controls.Add(Me.lblFechaAPagar)
      Me.grbUnaCuota.Controls.Add(Me.lblMonto)
      Me.grbUnaCuota.Controls.Add(Me.txtMonto)
      Me.grbUnaCuota.Location = New System.Drawing.Point(6, 159)
      Me.grbUnaCuota.Name = "grbUnaCuota"
      Me.grbUnaCuota.Size = New System.Drawing.Size(390, 68)
      Me.grbUnaCuota.TabIndex = 5
      Me.grbUnaCuota.TabStop = False
      Me.grbUnaCuota.Text = "Manual"
      '
      'btnEliminar
      '
      Me.btnEliminar.Image = CType(resources.GetObject("btnEliminar.Image"), System.Drawing.Image)
      Me.btnEliminar.Location = New System.Drawing.Point(347, 22)
      Me.btnEliminar.Name = "btnEliminar"
      Me.btnEliminar.Size = New System.Drawing.Size(37, 37)
      Me.btnEliminar.TabIndex = 7
      Me.btnEliminar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
      Me.btnEliminar.UseVisualStyleBackColor = True
      '
      'btnInsertar
      '
      Me.btnInsertar.Image = CType(resources.GetObject("btnInsertar.Image"), System.Drawing.Image)
      Me.btnInsertar.Location = New System.Drawing.Point(306, 22)
      Me.btnInsertar.Name = "btnInsertar"
      Me.btnInsertar.Size = New System.Drawing.Size(37, 37)
      Me.btnInsertar.TabIndex = 6
      Me.btnInsertar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
      Me.btnInsertar.UseVisualStyleBackColor = True
      '
      'lblDias
      '
      Me.lblDias.AutoSize = True
      Me.lblDias.Location = New System.Drawing.Point(96, 22)
      Me.lblDias.Name = "lblDias"
      Me.lblDias.Size = New System.Drawing.Size(30, 13)
      Me.lblDias.TabIndex = 3
      Me.lblDias.Text = "Días"
      '
      'txtDias
      '
      Me.txtDias.BindearPropiedadControl = Nothing
      Me.txtDias.BindearPropiedadEntidad = Nothing
      Me.txtDias.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.txtDias.ForeColorFocus = System.Drawing.Color.Red
      Me.txtDias.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtDias.Formato = ""
      Me.txtDias.IsDecimal = False
      Me.txtDias.IsNumber = True
      Me.txtDias.IsPK = False
      Me.txtDias.IsRequired = False
      Me.txtDias.Key = ""
      Me.txtDias.LabelAsoc = Me.lblDias
      Me.txtDias.Location = New System.Drawing.Point(92, 37)
      Me.txtDias.MaxLength = 3
      Me.txtDias.Name = "txtDias"
      Me.txtDias.Size = New System.Drawing.Size(37, 20)
      Me.txtDias.TabIndex = 2
      Me.txtDias.Text = "0"
      Me.txtDias.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'dtpFechaAPagar
      '
      Me.dtpFechaAPagar.BindearPropiedadControl = Nothing
      Me.dtpFechaAPagar.BindearPropiedadEntidad = Nothing
      Me.dtpFechaAPagar.CustomFormat = "dd/MM/yyyy"
      Me.dtpFechaAPagar.ForeColorFocus = System.Drawing.Color.Red
      Me.dtpFechaAPagar.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.dtpFechaAPagar.Format = System.Windows.Forms.DateTimePickerFormat.Custom
      Me.dtpFechaAPagar.IsPK = False
      Me.dtpFechaAPagar.IsRequired = False
      Me.dtpFechaAPagar.Key = ""
      Me.dtpFechaAPagar.LabelAsoc = Me.lblFechaAPagar
      Me.dtpFechaAPagar.Location = New System.Drawing.Point(135, 37)
      Me.dtpFechaAPagar.Name = "dtpFechaAPagar"
      Me.dtpFechaAPagar.Size = New System.Drawing.Size(96, 20)
      Me.dtpFechaAPagar.TabIndex = 4
      '
      'lblFechaAPagar
      '
      Me.lblFechaAPagar.AutoSize = True
      Me.lblFechaAPagar.Location = New System.Drawing.Point(132, 22)
      Me.lblFechaAPagar.Name = "lblFechaAPagar"
      Me.lblFechaAPagar.Size = New System.Drawing.Size(76, 13)
      Me.lblFechaAPagar.TabIndex = 5
      Me.lblFechaAPagar.Text = "Fecha a pagar"
      '
      'lblMonto
      '
      Me.lblMonto.AutoSize = True
      Me.lblMonto.Location = New System.Drawing.Point(12, 22)
      Me.lblMonto.Name = "lblMonto"
      Me.lblMonto.Size = New System.Drawing.Size(76, 13)
      Me.lblMonto.TabIndex = 1
      Me.lblMonto.Text = "Monto a pagar"
      '
      'txtMonto
      '
      Me.txtMonto.BindearPropiedadControl = Nothing
      Me.txtMonto.BindearPropiedadEntidad = Nothing
      Me.txtMonto.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.txtMonto.ForeColorFocus = System.Drawing.Color.Red
      Me.txtMonto.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtMonto.Formato = "#,##0.00"
      Me.txtMonto.IsDecimal = True
      Me.txtMonto.IsNumber = True
      Me.txtMonto.IsPK = False
      Me.txtMonto.IsRequired = False
      Me.txtMonto.Key = ""
      Me.txtMonto.LabelAsoc = Me.lblMonto
      Me.txtMonto.Location = New System.Drawing.Point(15, 37)
      Me.txtMonto.MaxLength = 15
      Me.txtMonto.Name = "txtMonto"
      Me.txtMonto.Size = New System.Drawing.Size(71, 20)
      Me.txtMonto.TabIndex = 0
      Me.txtMonto.Text = "0.00"
      Me.txtMonto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'lblSaldo
      '
      Me.lblSaldo.AutoSize = True
      Me.lblSaldo.Location = New System.Drawing.Point(15, 24)
      Me.lblSaldo.Name = "lblSaldo"
      Me.lblSaldo.Size = New System.Drawing.Size(34, 13)
      Me.lblSaldo.TabIndex = 0
      Me.lblSaldo.Text = "Saldo"
      '
      'txtSaldo
      '
      Me.txtSaldo.BindearPropiedadControl = Nothing
      Me.txtSaldo.BindearPropiedadEntidad = Nothing
      Me.txtSaldo.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.txtSaldo.ForeColorFocus = System.Drawing.Color.Red
      Me.txtSaldo.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtSaldo.Formato = ""
      Me.txtSaldo.IsDecimal = True
      Me.txtSaldo.IsNumber = True
      Me.txtSaldo.IsPK = False
      Me.txtSaldo.IsRequired = False
      Me.txtSaldo.Key = ""
      Me.txtSaldo.LabelAsoc = Me.lblSaldo
      Me.txtSaldo.Location = New System.Drawing.Point(53, 20)
      Me.txtSaldo.Name = "txtSaldo"
      Me.txtSaldo.ReadOnly = True
      Me.txtSaldo.Size = New System.Drawing.Size(100, 23)
      Me.txtSaldo.TabIndex = 1
      Me.txtSaldo.TabStop = False
      Me.txtSaldo.Text = "0.00"
      Me.txtSaldo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'CuentaCorriente
      '
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.ClientSize = New System.Drawing.Size(426, 516)
      Me.ControlBox = False
      Me.Controls.Add(Me.grbFormaPago)
      Me.Controls.Add(Me.btnAceptar)
      Me.Controls.Add(Me.btnCancelar)
      Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
      Me.MaximizeBox = False
      Me.MinimizeBox = False
      Me.Name = "CuentaCorriente"
      Me.ShowInTaskbar = False
      Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
      Me.Text = "Cuenta Corriente"
      Me.grbFormaPago.ResumeLayout(False)
      Me.grbFormaPago.PerformLayout()
      Me.grbVariasCuotas.ResumeLayout(False)
      Me.grbVariasCuotas.PerformLayout()
      CType(Me.dgvCuotas, System.ComponentModel.ISupportInitialize).EndInit()
      Me.grbUnaCuota.ResumeLayout(False)
      Me.grbUnaCuota.PerformLayout()
      Me.ResumeLayout(False)
      Me.PerformLayout()

   End Sub
   Friend WithEvents btnAceptar As Eniac.Controles.Button
   Friend WithEvents btnCancelar As Eniac.Controles.Button
   Friend WithEvents grbFormaPago As System.Windows.Forms.GroupBox
   Friend WithEvents lblSaldo As Eniac.Controles.Label
   Friend WithEvents txtSaldo As Eniac.Controles.TextBox
   Friend WithEvents grbUnaCuota As System.Windows.Forms.GroupBox
   Friend WithEvents dgvCuotas As Eniac.Controles.DataGridView
   Friend WithEvents dtpFechaAPagar As Eniac.Controles.DateTimePicker
   Friend WithEvents lblFechaAPagar As Eniac.Controles.Label
   Friend WithEvents lblMonto As Eniac.Controles.Label
   Friend WithEvents txtMonto As Eniac.Controles.TextBox
   Friend WithEvents lblRestan As Eniac.Controles.Label
   Friend WithEvents txtRestan As Eniac.Controles.TextBox
   Friend WithEvents lblDias As Eniac.Controles.Label
   Friend WithEvents txtDias As Eniac.Controles.TextBox
   Friend WithEvents btnEliminar As Eniac.Controles.Button
   Friend WithEvents btnInsertar As Eniac.Controles.Button
   Friend WithEvents grbVariasCuotas As System.Windows.Forms.GroupBox
   Friend WithEvents btnEliminarVC As Eniac.Controles.Button
   Friend WithEvents btnInsertarVC As Eniac.Controles.Button
   Friend WithEvents dtpPrimerVencimiento As Eniac.Controles.DateTimePicker
   Friend WithEvents lblPrimerVencimiento As Eniac.Controles.Label
   Friend WithEvents cmbFormaPago As Eniac.Controles.ComboBox
   Friend WithEvents lblFormaPago As Eniac.Controles.Label
   Friend WithEvents txtCuotas As Eniac.Controles.TextBox
   Friend WithEvents lblCuotas As Eniac.Controles.Label
   Friend WithEvents MontoAPagar As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents Cuota As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents Dias As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents FechaAPagar As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents txtPrimeraCuota As Eniac.Controles.TextBox
   Friend WithEvents chbPrimerCuota As System.Windows.Forms.CheckBox
   Friend WithEvents chbDiaFijo As System.Windows.Forms.CheckBox
   Friend WithEvents btnLimpiarProducto As Eniac.Controles.Button
End Class
