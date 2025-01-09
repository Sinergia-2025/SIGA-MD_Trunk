<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CajasNombresDetalle
   Inherits Eniac.Win.BaseDetalle

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
      Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(CajasNombresDetalle))
      Me.Label1 = New Eniac.Controles.Label()
      Me.txtIdCaja = New Eniac.Controles.TextBox()
      Me.lblNombreMarca = New Eniac.Controles.Label()
      Me.txtNombreCaja = New Eniac.Controles.TextBox()
      Me.btnQuitar = New System.Windows.Forms.Button()
      Me.btnAgregar = New System.Windows.Forms.Button()
      Me.dgvUsuariosCajas = New Eniac.Controles.DataGridView()
      Me.dgvUsuarios = New Eniac.Controles.DataGridView()
      Me.lblUsuarios = New Eniac.Controles.Label()
      Me.Label2 = New Eniac.Controles.Label()
      Me.GroupBox1 = New System.Windows.Forms.GroupBox()
      Me.chbColor = New Eniac.Controles.CheckBox()
      Me.txtColor = New Eniac.Controles.TextBox()
      Me.btnColor = New System.Windows.Forms.Button()
      Me.chbUsuario = New Eniac.Controles.CheckBox()
      Me.cmbUsuario = New Eniac.Controles.ComboBox()
      Me.txtTopeBloqueo = New Eniac.Controles.TextBox()
      Me.lblTopeBloqueo = New Eniac.Controles.Label()
      Me.cmbSucursales = New Eniac.Controles.ComboBox()
      Me.lblIdSucursal = New Eniac.Controles.Label()
      Me.txtTopeAviso = New Eniac.Controles.TextBox()
      Me.lblTopeAviso = New Eniac.Controles.Label()
      Me.chbNombrePC = New Eniac.Controles.CheckBox()
      Me.txtNombrePC = New Eniac.Controles.TextBox()
      Me.gpoContabilidad = New System.Windows.Forms.GroupBox()
      Me.lblDebe = New Eniac.Controles.Label()
      Me.lblDesc = New Eniac.Controles.Label()
      Me.bscCodCuenta = New Eniac.Controles.Buscador()
      Me.Label3 = New Eniac.Controles.Label()
      Me.bscDescCuenta = New Eniac.Controles.Buscador()
      Me.cmbPlan = New Eniac.Controles.ComboBox()
      Me.ChbPermitirEscritura = New System.Windows.Forms.CheckBox()
      Me.cdColor = New System.Windows.Forms.ColorDialog()
      Me.chbTeclaF3 = New Eniac.Controles.CheckBox()
      Me.cmbComprobantesF3 = New Eniac.Controles.ComboBox()
      Me.chbTeclaF4 = New Eniac.Controles.CheckBox()
      Me.cmbComprobantesF4 = New Eniac.Controles.ComboBox()
      Me.grbTeclasFacturacionRapida = New System.Windows.Forms.GroupBox()
      Me.cmbComprobantesF7Origen = New Eniac.Controles.ComboBox()
      Me.chbTeclaF10 = New Eniac.Controles.CheckBox()
      Me.cmbComprobantesF7Destino = New Eniac.Controles.ComboBox()
      Me.Id = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.Nombre = New System.Windows.Forms.DataGridViewTextBoxColumn()
      CType(Me.dgvUsuariosCajas, System.ComponentModel.ISupportInitialize).BeginInit()
      CType(Me.dgvUsuarios, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.GroupBox1.SuspendLayout()
      Me.gpoContabilidad.SuspendLayout()
      Me.grbTeclasFacturacionRapida.SuspendLayout()
      Me.SuspendLayout()
      '
      'btnAceptar
      '
      Me.btnAceptar.Location = New System.Drawing.Point(426, 511)
      Me.btnAceptar.TabIndex = 8
      '
      'btnCancelar
      '
      Me.btnCancelar.Location = New System.Drawing.Point(512, 511)
      Me.btnCancelar.TabIndex = 9
      '
      'btnCopiar
      '
      Me.btnCopiar.Location = New System.Drawing.Point(325, 511)
      Me.btnCopiar.TabIndex = 10
      '
      'btnAplicar
      '
      Me.btnAplicar.Location = New System.Drawing.Point(265, 511)
      Me.btnAplicar.TabIndex = 11
      '
      'Label1
      '
      Me.Label1.AutoSize = True
      Me.Label1.LabelAsoc = Nothing
      Me.Label1.Location = New System.Drawing.Point(12, 20)
      Me.Label1.Name = "Label1"
      Me.Label1.Size = New System.Drawing.Size(28, 13)
      Me.Label1.TabIndex = 0
      Me.Label1.Text = "Caja"
      '
      'txtIdCaja
      '
      Me.txtIdCaja.BindearPropiedadControl = "Text"
      Me.txtIdCaja.BindearPropiedadEntidad = "IdCaja"
      Me.txtIdCaja.ForeColorFocus = System.Drawing.Color.Red
      Me.txtIdCaja.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtIdCaja.Formato = ""
      Me.txtIdCaja.IsDecimal = False
      Me.txtIdCaja.IsNumber = True
      Me.txtIdCaja.IsPK = True
      Me.txtIdCaja.IsRequired = True
      Me.txtIdCaja.Key = ""
      Me.txtIdCaja.LabelAsoc = Nothing
      Me.txtIdCaja.Location = New System.Drawing.Point(98, 16)
      Me.txtIdCaja.MaxLength = 9
      Me.txtIdCaja.Name = "txtIdCaja"
      Me.txtIdCaja.Size = New System.Drawing.Size(77, 20)
      Me.txtIdCaja.TabIndex = 1
      Me.txtIdCaja.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'lblNombreMarca
      '
      Me.lblNombreMarca.AutoSize = True
      Me.lblNombreMarca.LabelAsoc = Nothing
      Me.lblNombreMarca.Location = New System.Drawing.Point(12, 47)
      Me.lblNombreMarca.Name = "lblNombreMarca"
      Me.lblNombreMarca.Size = New System.Drawing.Size(44, 13)
      Me.lblNombreMarca.TabIndex = 4
      Me.lblNombreMarca.Text = "Nombre"
      '
      'txtNombreCaja
      '
      Me.txtNombreCaja.BindearPropiedadControl = "Text"
      Me.txtNombreCaja.BindearPropiedadEntidad = "NombreCaja"
      Me.txtNombreCaja.ForeColorFocus = System.Drawing.Color.Red
      Me.txtNombreCaja.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtNombreCaja.Formato = ""
      Me.txtNombreCaja.IsDecimal = False
      Me.txtNombreCaja.IsNumber = False
      Me.txtNombreCaja.IsPK = False
      Me.txtNombreCaja.IsRequired = True
      Me.txtNombreCaja.Key = ""
      Me.txtNombreCaja.LabelAsoc = Me.lblNombreMarca
      Me.txtNombreCaja.Location = New System.Drawing.Point(98, 43)
      Me.txtNombreCaja.MaxLength = 30
      Me.txtNombreCaja.Name = "txtNombreCaja"
      Me.txtNombreCaja.Size = New System.Drawing.Size(234, 20)
      Me.txtNombreCaja.TabIndex = 5
      '
      'btnQuitar
      '
      Me.btnQuitar.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
      Me.btnQuitar.Image = Global.Eniac.Win.My.Resources.Resources.delete_24
      Me.btnQuitar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
      Me.btnQuitar.Location = New System.Drawing.Point(263, 252)
      Me.btnQuitar.Name = "btnQuitar"
      Me.btnQuitar.Size = New System.Drawing.Size(98, 40)
      Me.btnQuitar.TabIndex = 4
      Me.btnQuitar.Text = "< Quitar"
      Me.btnQuitar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      Me.btnQuitar.UseVisualStyleBackColor = True
      '
      'btnAgregar
      '
      Me.btnAgregar.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
      Me.btnAgregar.Image = Global.Eniac.Win.My.Resources.Resources.add_24
      Me.btnAgregar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
      Me.btnAgregar.Location = New System.Drawing.Point(263, 206)
      Me.btnAgregar.Name = "btnAgregar"
      Me.btnAgregar.Size = New System.Drawing.Size(98, 40)
      Me.btnAgregar.TabIndex = 3
      Me.btnAgregar.Text = "Agregar >"
      Me.btnAgregar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
      Me.btnAgregar.UseVisualStyleBackColor = True
      '
      'dgvUsuariosCajas
      '
      Me.dgvUsuariosCajas.AllowUserToAddRows = False
      Me.dgvUsuariosCajas.AllowUserToDeleteRows = False
      Me.dgvUsuariosCajas.AllowUserToResizeColumns = False
      Me.dgvUsuariosCajas.AllowUserToResizeRows = False
      Me.dgvUsuariosCajas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
      Me.dgvUsuariosCajas.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
      Me.dgvUsuariosCajas.Location = New System.Drawing.Point(364, 155)
      Me.dgvUsuariosCajas.Name = "dgvUsuariosCajas"
      Me.dgvUsuariosCajas.RowHeadersVisible = False
      Me.dgvUsuariosCajas.RowHeadersWidth = 20
      Me.dgvUsuariosCajas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
      Me.dgvUsuariosCajas.Size = New System.Drawing.Size(225, 220)
      Me.dgvUsuariosCajas.TabIndex = 5
      '
      'dgvUsuarios
      '
      Me.dgvUsuarios.AllowUserToAddRows = False
      Me.dgvUsuarios.AllowUserToDeleteRows = False
      Me.dgvUsuarios.AllowUserToResizeColumns = False
      Me.dgvUsuarios.AllowUserToResizeRows = False
      Me.dgvUsuarios.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
      Me.dgvUsuarios.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Id, Me.Nombre})
      Me.dgvUsuarios.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
      Me.dgvUsuarios.Location = New System.Drawing.Point(19, 155)
      Me.dgvUsuarios.Name = "dgvUsuarios"
      Me.dgvUsuarios.RowHeadersVisible = False
      Me.dgvUsuarios.RowHeadersWidth = 20
      Me.dgvUsuarios.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
      Me.dgvUsuarios.Size = New System.Drawing.Size(240, 220)
      Me.dgvUsuarios.TabIndex = 1
      '
      'lblUsuarios
      '
      Me.lblUsuarios.AutoSize = True
      Me.lblUsuarios.LabelAsoc = Nothing
      Me.lblUsuarios.Location = New System.Drawing.Point(16, 139)
      Me.lblUsuarios.Name = "lblUsuarios"
      Me.lblUsuarios.Size = New System.Drawing.Size(48, 13)
      Me.lblUsuarios.TabIndex = 12
      Me.lblUsuarios.Text = "Usuarios"
      '
      'Label2
      '
      Me.Label2.AutoSize = True
      Me.Label2.LabelAsoc = Nothing
      Me.Label2.Location = New System.Drawing.Point(362, 139)
      Me.Label2.Name = "Label2"
      Me.Label2.Size = New System.Drawing.Size(98, 13)
      Me.Label2.TabIndex = 13
      Me.Label2.Text = "Usuarios de la Caja"
      '
      'GroupBox1
      '
      Me.GroupBox1.Controls.Add(Me.chbColor)
      Me.GroupBox1.Controls.Add(Me.txtColor)
      Me.GroupBox1.Controls.Add(Me.btnColor)
      Me.GroupBox1.Controls.Add(Me.chbUsuario)
      Me.GroupBox1.Controls.Add(Me.cmbUsuario)
      Me.GroupBox1.Controls.Add(Me.txtTopeBloqueo)
      Me.GroupBox1.Controls.Add(Me.lblTopeBloqueo)
      Me.GroupBox1.Controls.Add(Me.cmbSucursales)
      Me.GroupBox1.Controls.Add(Me.lblIdSucursal)
      Me.GroupBox1.Controls.Add(Me.txtTopeAviso)
      Me.GroupBox1.Controls.Add(Me.lblTopeAviso)
      Me.GroupBox1.Controls.Add(Me.chbNombrePC)
      Me.GroupBox1.Controls.Add(Me.txtNombrePC)
      Me.GroupBox1.Controls.Add(Me.Label1)
      Me.GroupBox1.Controls.Add(Me.txtIdCaja)
      Me.GroupBox1.Controls.Add(Me.txtNombreCaja)
      Me.GroupBox1.Controls.Add(Me.lblNombreMarca)
      Me.GroupBox1.Location = New System.Drawing.Point(19, 12)
      Me.GroupBox1.Name = "GroupBox1"
      Me.GroupBox1.Size = New System.Drawing.Size(573, 123)
      Me.GroupBox1.TabIndex = 0
      Me.GroupBox1.TabStop = False
      Me.GroupBox1.Text = "Caja"
      '
      'chbColor
      '
      Me.chbColor.AutoSize = True
      Me.chbColor.BindearPropiedadControl = Nothing
      Me.chbColor.BindearPropiedadEntidad = Nothing
      Me.chbColor.ForeColorFocus = System.Drawing.Color.Red
      Me.chbColor.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
      Me.chbColor.IsPK = False
      Me.chbColor.IsRequired = False
      Me.chbColor.Key = Nothing
      Me.chbColor.LabelAsoc = Nothing
      Me.chbColor.Location = New System.Drawing.Point(346, 97)
      Me.chbColor.Name = "chbColor"
      Me.chbColor.Size = New System.Drawing.Size(50, 17)
      Me.chbColor.TabIndex = 17
      Me.chbColor.Text = "Color"
      Me.chbColor.UseVisualStyleBackColor = True
      '
      'txtColor
      '
      Me.txtColor.BindearPropiedadControl = "Key"
      Me.txtColor.BindearPropiedadEntidad = "Color"
      Me.txtColor.ForeColorFocus = System.Drawing.Color.Red
      Me.txtColor.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtColor.Formato = ""
      Me.txtColor.IsDecimal = False
      Me.txtColor.IsNumber = False
      Me.txtColor.IsPK = False
      Me.txtColor.IsRequired = False
      Me.txtColor.Key = ""
      Me.txtColor.LabelAsoc = Nothing
      Me.txtColor.Location = New System.Drawing.Point(418, 95)
      Me.txtColor.Name = "txtColor"
      Me.txtColor.ReadOnly = True
      Me.txtColor.Size = New System.Drawing.Size(82, 20)
      Me.txtColor.TabIndex = 15
      Me.txtColor.TabStop = False
      '
      'btnColor
      '
      Me.btnColor.Location = New System.Drawing.Point(507, 94)
      Me.btnColor.Name = "btnColor"
      Me.btnColor.Size = New System.Drawing.Size(57, 23)
      Me.btnColor.TabIndex = 16
      Me.btnColor.Text = "Paleta"
      Me.btnColor.UseVisualStyleBackColor = True
      '
      'chbUsuario
      '
      Me.chbUsuario.AutoSize = True
      Me.chbUsuario.BindearPropiedadControl = Nothing
      Me.chbUsuario.BindearPropiedadEntidad = Nothing
      Me.chbUsuario.ForeColorFocus = System.Drawing.Color.Red
      Me.chbUsuario.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
      Me.chbUsuario.IsPK = False
      Me.chbUsuario.IsRequired = False
      Me.chbUsuario.Key = Nothing
      Me.chbUsuario.LabelAsoc = Nothing
      Me.chbUsuario.Location = New System.Drawing.Point(12, 97)
      Me.chbUsuario.Name = "chbUsuario"
      Me.chbUsuario.Size = New System.Drawing.Size(62, 17)
      Me.chbUsuario.TabIndex = 12
      Me.chbUsuario.Text = "Usuario"
      Me.chbUsuario.UseVisualStyleBackColor = True
      '
      'cmbUsuario
      '
      Me.cmbUsuario.BindearPropiedadControl = "SelectedValue"
      Me.cmbUsuario.BindearPropiedadEntidad = "IdUsuario"
      Me.cmbUsuario.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cmbUsuario.Enabled = False
      Me.cmbUsuario.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.cmbUsuario.ForeColorFocus = System.Drawing.Color.Red
      Me.cmbUsuario.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.cmbUsuario.FormattingEnabled = True
      Me.cmbUsuario.IsPK = False
      Me.cmbUsuario.IsRequired = False
      Me.cmbUsuario.Key = Nothing
      Me.cmbUsuario.LabelAsoc = Nothing
      Me.cmbUsuario.Location = New System.Drawing.Point(98, 95)
      Me.cmbUsuario.Name = "cmbUsuario"
      Me.cmbUsuario.Size = New System.Drawing.Size(159, 21)
      Me.cmbUsuario.TabIndex = 13
      '
      'txtTopeBloqueo
      '
      Me.txtTopeBloqueo.BindearPropiedadControl = "Text"
      Me.txtTopeBloqueo.BindearPropiedadEntidad = "TopeBloqueo"
      Me.txtTopeBloqueo.ForeColorFocus = System.Drawing.Color.Red
      Me.txtTopeBloqueo.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtTopeBloqueo.Formato = "##,##0.00"
      Me.txtTopeBloqueo.IsDecimal = True
      Me.txtTopeBloqueo.IsNumber = True
      Me.txtTopeBloqueo.IsPK = False
      Me.txtTopeBloqueo.IsRequired = False
      Me.txtTopeBloqueo.Key = ""
      Me.txtTopeBloqueo.LabelAsoc = Me.lblTopeBloqueo
      Me.txtTopeBloqueo.Location = New System.Drawing.Point(418, 69)
      Me.txtTopeBloqueo.MaxLength = 8
      Me.txtTopeBloqueo.Name = "txtTopeBloqueo"
      Me.txtTopeBloqueo.Size = New System.Drawing.Size(72, 20)
      Me.txtTopeBloqueo.TabIndex = 11
      Me.txtTopeBloqueo.Text = "0.00"
      Me.txtTopeBloqueo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'lblTopeBloqueo
      '
      Me.lblTopeBloqueo.AutoSize = True
      Me.lblTopeBloqueo.LabelAsoc = Nothing
      Me.lblTopeBloqueo.Location = New System.Drawing.Point(343, 73)
      Me.lblTopeBloqueo.Name = "lblTopeBloqueo"
      Me.lblTopeBloqueo.Size = New System.Drawing.Size(74, 13)
      Me.lblTopeBloqueo.TabIndex = 10
      Me.lblTopeBloqueo.Text = "Tope Bloqueo"
      '
      'cmbSucursales
      '
      Me.cmbSucursales.BindearPropiedadControl = "SelectedValue"
      Me.cmbSucursales.BindearPropiedadEntidad = "IdSucursal"
      Me.cmbSucursales.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cmbSucursales.ForeColorFocus = System.Drawing.Color.Red
      Me.cmbSucursales.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.cmbSucursales.FormattingEnabled = True
      Me.cmbSucursales.IsPK = True
      Me.cmbSucursales.IsRequired = True
      Me.cmbSucursales.Key = Nothing
      Me.cmbSucursales.LabelAsoc = Me.lblIdSucursal
      Me.cmbSucursales.Location = New System.Drawing.Point(338, 16)
      Me.cmbSucursales.Name = "cmbSucursales"
      Me.cmbSucursales.Size = New System.Drawing.Size(167, 21)
      Me.cmbSucursales.TabIndex = 3
      Me.cmbSucursales.TabStop = False
      Me.cmbSucursales.Visible = False
      '
      'lblIdSucursal
      '
      Me.lblIdSucursal.AutoSize = True
      Me.lblIdSucursal.LabelAsoc = Nothing
      Me.lblIdSucursal.Location = New System.Drawing.Point(286, 20)
      Me.lblIdSucursal.Name = "lblIdSucursal"
      Me.lblIdSucursal.Size = New System.Drawing.Size(48, 13)
      Me.lblIdSucursal.TabIndex = 2
      Me.lblIdSucursal.Text = "Sucursal"
      Me.lblIdSucursal.Visible = False
      '
      'txtTopeAviso
      '
      Me.txtTopeAviso.BindearPropiedadControl = "Text"
      Me.txtTopeAviso.BindearPropiedadEntidad = "TopeAviso"
      Me.txtTopeAviso.ForeColorFocus = System.Drawing.Color.Red
      Me.txtTopeAviso.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtTopeAviso.Formato = "##,##0.00"
      Me.txtTopeAviso.IsDecimal = True
      Me.txtTopeAviso.IsNumber = True
      Me.txtTopeAviso.IsPK = False
      Me.txtTopeAviso.IsRequired = False
      Me.txtTopeAviso.Key = ""
      Me.txtTopeAviso.LabelAsoc = Me.lblTopeAviso
      Me.txtTopeAviso.Location = New System.Drawing.Point(418, 43)
      Me.txtTopeAviso.MaxLength = 8
      Me.txtTopeAviso.Name = "txtTopeAviso"
      Me.txtTopeAviso.Size = New System.Drawing.Size(72, 20)
      Me.txtTopeAviso.TabIndex = 7
      Me.txtTopeAviso.Text = "0.00"
      Me.txtTopeAviso.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'lblTopeAviso
      '
      Me.lblTopeAviso.AutoSize = True
      Me.lblTopeAviso.LabelAsoc = Nothing
      Me.lblTopeAviso.Location = New System.Drawing.Point(343, 47)
      Me.lblTopeAviso.Name = "lblTopeAviso"
      Me.lblTopeAviso.Size = New System.Drawing.Size(61, 13)
      Me.lblTopeAviso.TabIndex = 6
      Me.lblTopeAviso.Text = "Tope Aviso"
      '
      'chbNombrePC
      '
      Me.chbNombrePC.AutoSize = True
      Me.chbNombrePC.BindearPropiedadControl = Nothing
      Me.chbNombrePC.BindearPropiedadEntidad = Nothing
      Me.chbNombrePC.ForeColorFocus = System.Drawing.Color.Red
      Me.chbNombrePC.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
      Me.chbNombrePC.IsPK = False
      Me.chbNombrePC.IsRequired = False
      Me.chbNombrePC.Key = Nothing
      Me.chbNombrePC.LabelAsoc = Nothing
      Me.chbNombrePC.Location = New System.Drawing.Point(12, 71)
      Me.chbNombrePC.Name = "chbNombrePC"
      Me.chbNombrePC.Size = New System.Drawing.Size(80, 17)
      Me.chbNombrePC.TabIndex = 8
      Me.chbNombrePC.Text = "Nombre PC"
      Me.chbNombrePC.UseVisualStyleBackColor = True
      '
      'txtNombrePC
      '
      Me.txtNombrePC.BindearPropiedadControl = "Text"
      Me.txtNombrePC.BindearPropiedadEntidad = "NombrePC"
      Me.txtNombrePC.Enabled = False
      Me.txtNombrePC.ForeColorFocus = System.Drawing.Color.Red
      Me.txtNombrePC.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtNombrePC.Formato = ""
      Me.txtNombrePC.IsDecimal = False
      Me.txtNombrePC.IsNumber = False
      Me.txtNombrePC.IsPK = False
      Me.txtNombrePC.IsRequired = False
      Me.txtNombrePC.Key = ""
      Me.txtNombrePC.LabelAsoc = Nothing
      Me.txtNombrePC.Location = New System.Drawing.Point(98, 69)
      Me.txtNombrePC.MaxLength = 20
      Me.txtNombrePC.Name = "txtNombrePC"
      Me.txtNombrePC.Size = New System.Drawing.Size(159, 20)
      Me.txtNombrePC.TabIndex = 9
      '
      'gpoContabilidad
      '
      Me.gpoContabilidad.Controls.Add(Me.lblDebe)
      Me.gpoContabilidad.Controls.Add(Me.lblDesc)
      Me.gpoContabilidad.Controls.Add(Me.bscCodCuenta)
      Me.gpoContabilidad.Controls.Add(Me.Label3)
      Me.gpoContabilidad.Controls.Add(Me.bscDescCuenta)
      Me.gpoContabilidad.Controls.Add(Me.cmbPlan)
      Me.gpoContabilidad.Location = New System.Drawing.Point(278, 381)
      Me.gpoContabilidad.Name = "gpoContabilidad"
      Me.gpoContabilidad.Size = New System.Drawing.Size(314, 126)
      Me.gpoContabilidad.TabIndex = 7
      Me.gpoContabilidad.TabStop = False
      Me.gpoContabilidad.Text = "Contabilidad"
      '
      'lblDebe
      '
      Me.lblDebe.AutoSize = True
      Me.lblDebe.LabelAsoc = Nothing
      Me.lblDebe.Location = New System.Drawing.Point(10, 47)
      Me.lblDebe.Name = "lblDebe"
      Me.lblDebe.Size = New System.Drawing.Size(77, 13)
      Me.lblDebe.TabIndex = 2
      Me.lblDebe.Text = "Cuenta Código"
      '
      'lblDesc
      '
      Me.lblDesc.AutoSize = True
      Me.lblDesc.LabelAsoc = Nothing
      Me.lblDesc.Location = New System.Drawing.Point(10, 73)
      Me.lblDesc.Name = "lblDesc"
      Me.lblDesc.Size = New System.Drawing.Size(100, 13)
      Me.lblDesc.TabIndex = 5
      Me.lblDesc.Text = "Cuenta Descripción"
      '
      'bscCodCuenta
      '
      Me.bscCodCuenta.AyudaAncho = 608
      Me.bscCodCuenta.BindearPropiedadControl = "Text"
      Me.bscCodCuenta.BindearPropiedadEntidad = "idCuentacontable"
      Me.bscCodCuenta.ColumnasAlineacion = Nothing
      Me.bscCodCuenta.ColumnasAncho = Nothing
      Me.bscCodCuenta.ColumnasFormato = Nothing
      Me.bscCodCuenta.ColumnasOcultas = Nothing
      Me.bscCodCuenta.ColumnasTitulos = Nothing
      Me.bscCodCuenta.Datos = Nothing
      Me.bscCodCuenta.FilaDevuelta = Nothing
      Me.bscCodCuenta.ForeColorFocus = System.Drawing.Color.Red
      Me.bscCodCuenta.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
      Me.bscCodCuenta.IsDecimal = False
      Me.bscCodCuenta.IsNumber = True
      Me.bscCodCuenta.IsPK = False
      Me.bscCodCuenta.IsRequired = False
      Me.bscCodCuenta.Key = ""
      Me.bscCodCuenta.LabelAsoc = Nothing
      Me.bscCodCuenta.Location = New System.Drawing.Point(114, 43)
      Me.bscCodCuenta.MaxLengh = "32767"
      Me.bscCodCuenta.Name = "bscCodCuenta"
      Me.bscCodCuenta.Permitido = True
      Me.bscCodCuenta.Selecciono = False
      Me.bscCodCuenta.Size = New System.Drawing.Size(95, 20)
      Me.bscCodCuenta.TabIndex = 3
      Me.bscCodCuenta.Titulo = Nothing
      '
      'Label3
      '
      Me.Label3.AutoSize = True
      Me.Label3.LabelAsoc = Nothing
      Me.Label3.Location = New System.Drawing.Point(10, 20)
      Me.Label3.Name = "Label3"
      Me.Label3.Size = New System.Drawing.Size(85, 13)
      Me.Label3.TabIndex = 0
      Me.Label3.Text = "Plan de Cuentas"
      '
      'bscDescCuenta
      '
      Me.bscDescCuenta.AyudaAncho = 608
      Me.bscDescCuenta.BindearPropiedadControl = ""
      Me.bscDescCuenta.BindearPropiedadEntidad = ""
      Me.bscDescCuenta.ColumnasAlineacion = Nothing
      Me.bscDescCuenta.ColumnasAncho = Nothing
      Me.bscDescCuenta.ColumnasFormato = Nothing
      Me.bscDescCuenta.ColumnasOcultas = Nothing
      Me.bscDescCuenta.ColumnasTitulos = Nothing
      Me.bscDescCuenta.Datos = Nothing
      Me.bscDescCuenta.FilaDevuelta = Nothing
      Me.bscDescCuenta.ForeColorFocus = System.Drawing.Color.Red
      Me.bscDescCuenta.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
      Me.bscDescCuenta.IsDecimal = False
      Me.bscDescCuenta.IsNumber = False
      Me.bscDescCuenta.IsPK = False
      Me.bscDescCuenta.IsRequired = False
      Me.bscDescCuenta.Key = ""
      Me.bscDescCuenta.LabelAsoc = Me.lblDesc
      Me.bscDescCuenta.Location = New System.Drawing.Point(114, 69)
      Me.bscDescCuenta.MaxLengh = "32767"
      Me.bscDescCuenta.Name = "bscDescCuenta"
      Me.bscDescCuenta.Permitido = True
      Me.bscDescCuenta.Selecciono = False
      Me.bscDescCuenta.Size = New System.Drawing.Size(191, 20)
      Me.bscDescCuenta.TabIndex = 4
      Me.bscDescCuenta.Titulo = Nothing
      '
      'cmbPlan
      '
      Me.cmbPlan.BindearPropiedadControl = "SelectedValue"
      Me.cmbPlan.BindearPropiedadEntidad = "IdPlanCuenta"
      Me.cmbPlan.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cmbPlan.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.cmbPlan.ForeColorFocus = System.Drawing.Color.Red
      Me.cmbPlan.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.cmbPlan.FormattingEnabled = True
      Me.cmbPlan.IsPK = False
      Me.cmbPlan.IsRequired = False
      Me.cmbPlan.Key = Nothing
      Me.cmbPlan.LabelAsoc = Me.Label3
      Me.cmbPlan.Location = New System.Drawing.Point(114, 16)
      Me.cmbPlan.Name = "cmbPlan"
      Me.cmbPlan.Size = New System.Drawing.Size(163, 21)
      Me.cmbPlan.TabIndex = 1
      '
      'ChbPermitirEscritura
      '
      Me.ChbPermitirEscritura.AutoSize = True
      Me.ChbPermitirEscritura.Checked = True
      Me.ChbPermitirEscritura.CheckState = System.Windows.Forms.CheckState.Checked
      Me.ChbPermitirEscritura.Location = New System.Drawing.Point(263, 190)
      Me.ChbPermitirEscritura.Name = "ChbPermitirEscritura"
      Me.ChbPermitirEscritura.Size = New System.Drawing.Size(104, 17)
      Me.ChbPermitirEscritura.TabIndex = 2
      Me.ChbPermitirEscritura.Text = "Permitir Escritura"
      Me.ChbPermitirEscritura.UseVisualStyleBackColor = True
      '
      'chbTeclaF3
      '
      Me.chbTeclaF3.AutoSize = True
      Me.chbTeclaF3.BindearPropiedadControl = Nothing
      Me.chbTeclaF3.BindearPropiedadEntidad = Nothing
      Me.chbTeclaF3.ForeColorFocus = System.Drawing.Color.Red
      Me.chbTeclaF3.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
      Me.chbTeclaF3.IsPK = False
      Me.chbTeclaF3.IsRequired = False
      Me.chbTeclaF3.Key = Nothing
      Me.chbTeclaF3.LabelAsoc = Nothing
      Me.chbTeclaF3.Location = New System.Drawing.Point(18, 18)
      Me.chbTeclaF3.Name = "chbTeclaF3"
      Me.chbTeclaF3.Size = New System.Drawing.Size(68, 17)
      Me.chbTeclaF3.TabIndex = 0
      Me.chbTeclaF3.Text = "Tecla F3"
      Me.chbTeclaF3.UseVisualStyleBackColor = True
      '
      'cmbComprobantesF3
      '
      Me.cmbComprobantesF3.BindearPropiedadControl = "SelectedValue"
      Me.cmbComprobantesF3.BindearPropiedadEntidad = "IdTipoComprobanteF3"
      Me.cmbComprobantesF3.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cmbComprobantesF3.Enabled = False
      Me.cmbComprobantesF3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.cmbComprobantesF3.ForeColorFocus = System.Drawing.Color.Red
      Me.cmbComprobantesF3.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.cmbComprobantesF3.FormattingEnabled = True
      Me.cmbComprobantesF3.IsPK = False
      Me.cmbComprobantesF3.IsRequired = False
      Me.cmbComprobantesF3.Key = Nothing
      Me.cmbComprobantesF3.LabelAsoc = Nothing
      Me.cmbComprobantesF3.Location = New System.Drawing.Point(89, 16)
      Me.cmbComprobantesF3.Name = "cmbComprobantesF3"
      Me.cmbComprobantesF3.Size = New System.Drawing.Size(159, 21)
      Me.cmbComprobantesF3.TabIndex = 1
      '
      'chbTeclaF4
      '
      Me.chbTeclaF4.AutoSize = True
      Me.chbTeclaF4.BindearPropiedadControl = Nothing
      Me.chbTeclaF4.BindearPropiedadEntidad = Nothing
      Me.chbTeclaF4.ForeColorFocus = System.Drawing.Color.Red
      Me.chbTeclaF4.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
      Me.chbTeclaF4.IsPK = False
      Me.chbTeclaF4.IsRequired = False
      Me.chbTeclaF4.Key = Nothing
      Me.chbTeclaF4.LabelAsoc = Nothing
      Me.chbTeclaF4.Location = New System.Drawing.Point(18, 45)
      Me.chbTeclaF4.Name = "chbTeclaF4"
      Me.chbTeclaF4.Size = New System.Drawing.Size(68, 17)
      Me.chbTeclaF4.TabIndex = 2
      Me.chbTeclaF4.Text = "Tecla F4"
      Me.chbTeclaF4.UseVisualStyleBackColor = True
      '
      'cmbComprobantesF4
      '
      Me.cmbComprobantesF4.BindearPropiedadControl = "SelectedValue"
      Me.cmbComprobantesF4.BindearPropiedadEntidad = "IdTipoComprobanteF4"
      Me.cmbComprobantesF4.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cmbComprobantesF4.Enabled = False
      Me.cmbComprobantesF4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.cmbComprobantesF4.ForeColorFocus = System.Drawing.Color.Red
      Me.cmbComprobantesF4.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.cmbComprobantesF4.FormattingEnabled = True
      Me.cmbComprobantesF4.IsPK = False
      Me.cmbComprobantesF4.IsRequired = False
      Me.cmbComprobantesF4.Key = Nothing
      Me.cmbComprobantesF4.LabelAsoc = Nothing
      Me.cmbComprobantesF4.Location = New System.Drawing.Point(89, 43)
      Me.cmbComprobantesF4.Name = "cmbComprobantesF4"
      Me.cmbComprobantesF4.Size = New System.Drawing.Size(159, 21)
      Me.cmbComprobantesF4.TabIndex = 3
      '
      'grbTeclasFacturacionRapida
      '
      Me.grbTeclasFacturacionRapida.Controls.Add(Me.cmbComprobantesF7Origen)
      Me.grbTeclasFacturacionRapida.Controls.Add(Me.cmbComprobantesF3)
      Me.grbTeclasFacturacionRapida.Controls.Add(Me.chbTeclaF10)
      Me.grbTeclasFacturacionRapida.Controls.Add(Me.chbTeclaF4)
      Me.grbTeclasFacturacionRapida.Controls.Add(Me.chbTeclaF3)
      Me.grbTeclasFacturacionRapida.Controls.Add(Me.cmbComprobantesF7Destino)
      Me.grbTeclasFacturacionRapida.Controls.Add(Me.cmbComprobantesF4)
      Me.grbTeclasFacturacionRapida.Location = New System.Drawing.Point(11, 381)
      Me.grbTeclasFacturacionRapida.Name = "grbTeclasFacturacionRapida"
      Me.grbTeclasFacturacionRapida.Size = New System.Drawing.Size(265, 126)
      Me.grbTeclasFacturacionRapida.TabIndex = 6
      Me.grbTeclasFacturacionRapida.TabStop = False
      Me.grbTeclasFacturacionRapida.Text = "Teclas Facturación Rápida"
      '
      'cmbComprobantesF7Origen
      '
      Me.cmbComprobantesF7Origen.BindearPropiedadControl = "SelectedValue"
      Me.cmbComprobantesF7Origen.BindearPropiedadEntidad = "IdTipoComprobanteF10Origen"
      Me.cmbComprobantesF7Origen.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cmbComprobantesF7Origen.Enabled = False
      Me.cmbComprobantesF7Origen.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.cmbComprobantesF7Origen.ForeColorFocus = System.Drawing.Color.Red
      Me.cmbComprobantesF7Origen.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.cmbComprobantesF7Origen.FormattingEnabled = True
      Me.cmbComprobantesF7Origen.IsPK = False
      Me.cmbComprobantesF7Origen.IsRequired = False
      Me.cmbComprobantesF7Origen.Key = Nothing
      Me.cmbComprobantesF7Origen.LabelAsoc = Nothing
      Me.cmbComprobantesF7Origen.Location = New System.Drawing.Point(89, 70)
      Me.cmbComprobantesF7Origen.Name = "cmbComprobantesF7Origen"
      Me.cmbComprobantesF7Origen.Size = New System.Drawing.Size(159, 21)
      Me.cmbComprobantesF7Origen.TabIndex = 5
      '
      'chbTeclaF10
      '
      Me.chbTeclaF10.AutoSize = True
      Me.chbTeclaF10.BindearPropiedadControl = Nothing
      Me.chbTeclaF10.BindearPropiedadEntidad = Nothing
      Me.chbTeclaF10.ForeColorFocus = System.Drawing.Color.Red
      Me.chbTeclaF10.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
      Me.chbTeclaF10.IsPK = False
      Me.chbTeclaF10.IsRequired = False
      Me.chbTeclaF10.Key = Nothing
      Me.chbTeclaF10.LabelAsoc = Nothing
      Me.chbTeclaF10.Location = New System.Drawing.Point(18, 72)
      Me.chbTeclaF10.Name = "chbTeclaF10"
      Me.chbTeclaF10.Size = New System.Drawing.Size(74, 17)
      Me.chbTeclaF10.TabIndex = 4
      Me.chbTeclaF10.Text = "Tecla F10"
      Me.chbTeclaF10.UseVisualStyleBackColor = True
      '
      'cmbComprobantesF7Destino
      '
      Me.cmbComprobantesF7Destino.BindearPropiedadControl = "SelectedValue"
      Me.cmbComprobantesF7Destino.BindearPropiedadEntidad = "IdTipoComprobanteF10Destino"
      Me.cmbComprobantesF7Destino.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cmbComprobantesF7Destino.Enabled = False
      Me.cmbComprobantesF7Destino.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.cmbComprobantesF7Destino.ForeColorFocus = System.Drawing.Color.Red
      Me.cmbComprobantesF7Destino.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.cmbComprobantesF7Destino.FormattingEnabled = True
      Me.cmbComprobantesF7Destino.IsPK = False
      Me.cmbComprobantesF7Destino.IsRequired = False
      Me.cmbComprobantesF7Destino.Key = Nothing
      Me.cmbComprobantesF7Destino.LabelAsoc = Nothing
      Me.cmbComprobantesF7Destino.Location = New System.Drawing.Point(89, 97)
      Me.cmbComprobantesF7Destino.Name = "cmbComprobantesF7Destino"
      Me.cmbComprobantesF7Destino.Size = New System.Drawing.Size(159, 21)
      Me.cmbComprobantesF7Destino.TabIndex = 6
      '
      'Id
      '
      Me.Id.DataPropertyName = "Id"
      Me.Id.HeaderText = "Id"
      Me.Id.Name = "Id"
      Me.Id.Width = 60
      '
      'Nombre
      '
      Me.Nombre.DataPropertyName = "Nombre"
      Me.Nombre.HeaderText = "Nombre"
      Me.Nombre.Name = "Nombre"
      Me.Nombre.Width = 150
      '
      'CajasNombresDetalle
      '
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
      Me.ClientSize = New System.Drawing.Size(601, 546)
      Me.Controls.Add(Me.grbTeclasFacturacionRapida)
      Me.Controls.Add(Me.dgvUsuariosCajas)
      Me.Controls.Add(Me.ChbPermitirEscritura)
      Me.Controls.Add(Me.gpoContabilidad)
      Me.Controls.Add(Me.GroupBox1)
      Me.Controls.Add(Me.Label2)
      Me.Controls.Add(Me.lblUsuarios)
      Me.Controls.Add(Me.btnQuitar)
      Me.Controls.Add(Me.btnAgregar)
      Me.Controls.Add(Me.dgvUsuarios)
      Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
      Me.Name = "CajasNombresDetalle"
      Me.Text = "Cajas Definición"
      Me.Controls.SetChildIndex(Me.btnAplicar, 0)
      Me.Controls.SetChildIndex(Me.dgvUsuarios, 0)
      Me.Controls.SetChildIndex(Me.btnAgregar, 0)
      Me.Controls.SetChildIndex(Me.btnQuitar, 0)
      Me.Controls.SetChildIndex(Me.lblUsuarios, 0)
      Me.Controls.SetChildIndex(Me.Label2, 0)
      Me.Controls.SetChildIndex(Me.GroupBox1, 0)
      Me.Controls.SetChildIndex(Me.gpoContabilidad, 0)
      Me.Controls.SetChildIndex(Me.ChbPermitirEscritura, 0)
      Me.Controls.SetChildIndex(Me.dgvUsuariosCajas, 0)
      Me.Controls.SetChildIndex(Me.btnCopiar, 0)
      Me.Controls.SetChildIndex(Me.btnCancelar, 0)
      Me.Controls.SetChildIndex(Me.btnAceptar, 0)
      Me.Controls.SetChildIndex(Me.grbTeclasFacturacionRapida, 0)
      CType(Me.dgvUsuariosCajas, System.ComponentModel.ISupportInitialize).EndInit()
      CType(Me.dgvUsuarios, System.ComponentModel.ISupportInitialize).EndInit()
      Me.GroupBox1.ResumeLayout(False)
      Me.GroupBox1.PerformLayout()
      Me.gpoContabilidad.ResumeLayout(False)
      Me.gpoContabilidad.PerformLayout()
      Me.grbTeclasFacturacionRapida.ResumeLayout(False)
      Me.grbTeclasFacturacionRapida.PerformLayout()
      Me.ResumeLayout(False)
      Me.PerformLayout()

   End Sub
   Friend WithEvents Label1 As Eniac.Controles.Label
   Friend WithEvents txtIdCaja As Eniac.Controles.TextBox
   Friend WithEvents lblNombreMarca As Eniac.Controles.Label
   Friend WithEvents txtNombreCaja As Eniac.Controles.TextBox
   Protected WithEvents btnQuitar As System.Windows.Forms.Button
   Protected WithEvents btnAgregar As System.Windows.Forms.Button
   Friend WithEvents dgvUsuariosCajas As Eniac.Controles.DataGridView
   Friend WithEvents dgvUsuarios As Eniac.Controles.DataGridView
   Friend WithEvents lblUsuarios As Eniac.Controles.Label
   Friend WithEvents Label2 As Eniac.Controles.Label
   Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
   Friend WithEvents txtNombrePC As Eniac.Controles.TextBox
   Friend WithEvents cmbSucursales As Eniac.Controles.ComboBox
   Friend WithEvents lblIdSucursal As Eniac.Controles.Label
   Friend WithEvents chbNombrePC As Eniac.Controles.CheckBox
   Friend WithEvents txtTopeBloqueo As Eniac.Controles.TextBox
   Friend WithEvents lblTopeBloqueo As Eniac.Controles.Label
   Friend WithEvents txtTopeAviso As Eniac.Controles.TextBox
   Friend WithEvents lblTopeAviso As Eniac.Controles.Label
   Friend WithEvents gpoContabilidad As System.Windows.Forms.GroupBox
   Friend WithEvents lblDebe As Eniac.Controles.Label
   Friend WithEvents lblDesc As Eniac.Controles.Label
   Friend WithEvents bscDescCuenta As Eniac.Controles.Buscador
   Friend WithEvents bscCodCuenta As Eniac.Controles.Buscador
   Friend WithEvents Label3 As Eniac.Controles.Label
   Friend WithEvents cmbPlan As Eniac.Controles.ComboBox
   Friend WithEvents chbUsuario As Eniac.Controles.CheckBox
   Friend WithEvents cmbUsuario As Eniac.Controles.ComboBox
   Friend WithEvents ChbPermitirEscritura As System.Windows.Forms.CheckBox
   Friend WithEvents txtColor As Eniac.Controles.TextBox
   Friend WithEvents btnColor As System.Windows.Forms.Button
   Friend WithEvents cdColor As System.Windows.Forms.ColorDialog
   Friend WithEvents chbColor As Eniac.Controles.CheckBox
   Friend WithEvents chbTeclaF3 As Eniac.Controles.CheckBox
   Friend WithEvents cmbComprobantesF3 As Eniac.Controles.ComboBox
   Friend WithEvents chbTeclaF4 As Eniac.Controles.CheckBox
   Friend WithEvents cmbComprobantesF4 As Eniac.Controles.ComboBox
   Friend WithEvents grbTeclasFacturacionRapida As System.Windows.Forms.GroupBox
   Friend WithEvents chbTeclaF10 As Eniac.Controles.CheckBox
   Friend WithEvents cmbComprobantesF7Destino As Eniac.Controles.ComboBox
   Friend WithEvents cmbComprobantesF7Origen As Eniac.Controles.ComboBox
   Friend WithEvents Id As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents Nombre As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
