<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CalendariosDetalle
   Inherits BaseDetalle

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
      Dim Appearance1 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridBand1 As Infragistics.Win.UltraWinGrid.UltraGridBand = New Infragistics.Win.UltraWinGrid.UltraGridBand("Band 0", -1)
      Dim UltraGridColumn1 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdCalendario")
      Dim UltraGridColumn2 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdDiaSemana")
      Dim UltraGridColumn3 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdHorario")
      Dim UltraGridColumn4 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("HoraDesde")
      Dim Appearance2 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn5 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("HoraHasta")
      Dim Appearance3 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn6 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreDiaSemana", -1, Nothing, 0, Infragistics.Win.UltraWinGrid.SortIndicator.Ascending, False)
        Dim Appearance4 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance5 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance6 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance7 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance8 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance9 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance10 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance11 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance12 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance13 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance14 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(CalendariosDetalle))
        Me.lblNombreCalendario = New Eniac.Controles.Label()
        Me.txtNombreCalendario = New Eniac.Controles.TextBox()
        Me.lblIdCalendario = New Eniac.Controles.Label()
        Me.txtIdCalendario = New Eniac.Controles.TextBox()
        Me.cmbIdSucursal = New Eniac.Controles.ComboBox()
        Me.lblIdSucursal = New Eniac.Controles.Label()
        Me.chbActivo = New Eniac.Controles.CheckBox()
        Me.chbIdSucursal = New Eniac.Controles.CheckBox()
        Me.chbUsuario = New Eniac.Controles.CheckBox()
        Me.cmbUsuario = New Eniac.Controles.ComboBox()
        Me.ChbPermitirEscritura = New System.Windows.Forms.CheckBox()
        Me.lblUsuarios = New Eniac.Controles.Label()
        Me.dgvUsuariosCalendarios = New Eniac.Controles.DataGridView()
        Me.btnQuitar = New System.Windows.Forms.Button()
        Me.btnAgregar = New System.Windows.Forms.Button()
        Me.lblUsuariosCalendario = New Eniac.Controles.Label()
        Me.cmbDiaSemana = New Eniac.Controles.ComboBox()
        Me.lblDiaSemana = New Eniac.Controles.Label()
        Me.dtpHoraHasta = New Eniac.Controles.DateTimePicker()
        Me.lblHoraHasta = New Eniac.Controles.Label()
        Me.txtLapsoPorDefecto = New Eniac.Controles.TextBox()
        Me.lblLapsoPorDefecto = New Eniac.Controles.Label()
        Me.dtpHoraDesde = New Eniac.Controles.DateTimePicker()
        Me.lblHoraDesde = New Eniac.Controles.Label()
        Me.lblLapsoPorDefectoUnidadTiempo = New Eniac.Controles.Label()
        Me.chbLapsoPorDefectoFijo = New Eniac.Controles.CheckBox()
        Me.ugDiasSemana = New Infragistics.Win.UltraWinGrid.UltraGrid()
        Me.btnEliminar = New Eniac.Controles.Button()
        Me.btnInsertar = New Eniac.Controles.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.dgvUsuarios = New Eniac.Controles.DataGridView()
        Me.Id = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Nombre = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.Label3 = New Eniac.Controles.Label()
        Me.txtDiasDesde = New Eniac.Controles.TextBox()
        Me.Label4 = New Eniac.Controles.Label()
        Me.txtDiasHasta = New Eniac.Controles.TextBox()
        Me.Label5 = New Eniac.Controles.Label()
        Me.txtCupo = New Eniac.Controles.TextBox()
        Me.lblDiasHabilitacionReserva = New Eniac.Controles.Label()
        Me.txtDiasHabilitacionReserva = New Eniac.Controles.TextBox()
        Me.bscProducto2 = New Eniac.Controles.Buscador2()
        Me.bscCodigoProducto2 = New Eniac.Controles.Buscador2()
        Me.chbProducto = New Eniac.Controles.CheckBox()
        Me.chbSesion = New Eniac.Controles.CheckBox()
        Me.chbZona = New Eniac.Controles.CheckBox()
        Me.cmbCajas = New Eniac.Controles.ComboBox()
        Me.chbCajas = New Eniac.Controles.CheckBox()
        Me.chbPublicarEnWeb = New Eniac.Controles.CheckBox()
        Me.lblTipoCalendario = New Eniac.Controles.Label()
        Me.cmbTipoCalendario = New Eniac.Controles.ComboBox()
        Me.chbSolicitaEmbarcacion = New Eniac.Controles.CheckBox()
        Me.chbSolicitaBotado = New Eniac.Controles.CheckBox()
        Me.chbNave = New Eniac.Controles.CheckBox()
        Me.cmbNave = New Eniac.Controles.ComboBox()
        Me.chbSolicitaVehiculo = New Eniac.Controles.CheckBox()
        Me.chbPermitirImpresionTurnos = New Eniac.Controles.CheckBox()
        CType(Me.dgvUsuariosCalendarios, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ugDiasSemana, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        CType(Me.dgvUsuarios, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnAceptar
        '
        Me.btnAceptar.Location = New System.Drawing.Point(800, 451)
        Me.btnAceptar.TabIndex = 32
        '
        'btnCancelar
        '
        Me.btnCancelar.Location = New System.Drawing.Point(886, 451)
        Me.btnCancelar.TabIndex = 33
        '
        'btnCopiar
        '
        Me.btnCopiar.Location = New System.Drawing.Point(699, 451)
        Me.btnCopiar.TabIndex = 35
        '
        'btnAplicar
        '
        Me.btnAplicar.Location = New System.Drawing.Point(639, 451)
        Me.btnAplicar.TabIndex = 34
        '
        'lblNombreCalendario
        '
        Me.lblNombreCalendario.AutoSize = True
        Me.lblNombreCalendario.LabelAsoc = Nothing
        Me.lblNombreCalendario.Location = New System.Drawing.Point(16, 46)
        Me.lblNombreCalendario.Name = "lblNombreCalendario"
        Me.lblNombreCalendario.Size = New System.Drawing.Size(63, 13)
        Me.lblNombreCalendario.TabIndex = 4
        Me.lblNombreCalendario.Text = "Descripción"
        '
        'txtNombreCalendario
        '
        Me.txtNombreCalendario.BindearPropiedadControl = "Text"
        Me.txtNombreCalendario.BindearPropiedadEntidad = "NombreCalendario"
        Me.txtNombreCalendario.ForeColorFocus = System.Drawing.Color.Red
        Me.txtNombreCalendario.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtNombreCalendario.Formato = ""
        Me.txtNombreCalendario.IsDecimal = False
        Me.txtNombreCalendario.IsNumber = False
        Me.txtNombreCalendario.IsPK = False
        Me.txtNombreCalendario.IsRequired = True
        Me.txtNombreCalendario.Key = ""
        Me.txtNombreCalendario.LabelAsoc = Me.lblNombreCalendario
        Me.txtNombreCalendario.Location = New System.Drawing.Point(97, 42)
        Me.txtNombreCalendario.MaxLength = 50
        Me.txtNombreCalendario.Name = "txtNombreCalendario"
        Me.txtNombreCalendario.Size = New System.Drawing.Size(223, 20)
        Me.txtNombreCalendario.TabIndex = 5
        '
        'lblIdCalendario
        '
        Me.lblIdCalendario.AutoSize = True
        Me.lblIdCalendario.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblIdCalendario.LabelAsoc = Nothing
        Me.lblIdCalendario.Location = New System.Drawing.Point(16, 19)
        Me.lblIdCalendario.Name = "lblIdCalendario"
        Me.lblIdCalendario.Size = New System.Drawing.Size(40, 13)
        Me.lblIdCalendario.TabIndex = 0
        Me.lblIdCalendario.Text = "Codigo"
        '
        'txtIdCalendario
        '
        Me.txtIdCalendario.BindearPropiedadControl = "Text"
        Me.txtIdCalendario.BindearPropiedadEntidad = "IdCalendario"
        Me.txtIdCalendario.ForeColorFocus = System.Drawing.Color.Red
        Me.txtIdCalendario.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtIdCalendario.Formato = ""
        Me.txtIdCalendario.IsDecimal = False
        Me.txtIdCalendario.IsNumber = True
        Me.txtIdCalendario.IsPK = True
        Me.txtIdCalendario.IsRequired = True
        Me.txtIdCalendario.Key = ""
        Me.txtIdCalendario.LabelAsoc = Me.lblIdCalendario
        Me.txtIdCalendario.Location = New System.Drawing.Point(97, 16)
        Me.txtIdCalendario.MaxLength = 10
        Me.txtIdCalendario.Name = "txtIdCalendario"
        Me.txtIdCalendario.Size = New System.Drawing.Size(54, 20)
        Me.txtIdCalendario.TabIndex = 1
        Me.txtIdCalendario.Text = "0"
        Me.txtIdCalendario.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'cmbIdSucursal
        '
        Me.cmbIdSucursal.BindearPropiedadControl = "SelectedValue"
        Me.cmbIdSucursal.BindearPropiedadEntidad = "IdSucursal"
        Me.cmbIdSucursal.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbIdSucursal.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbIdSucursal.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbIdSucursal.FormattingEnabled = True
        Me.cmbIdSucursal.IsPK = False
        Me.cmbIdSucursal.IsRequired = False
        Me.cmbIdSucursal.Key = Nothing
        Me.cmbIdSucursal.LabelAsoc = Me.lblIdSucursal
        Me.cmbIdSucursal.Location = New System.Drawing.Point(97, 68)
        Me.cmbIdSucursal.Name = "cmbIdSucursal"
        Me.cmbIdSucursal.Size = New System.Drawing.Size(172, 21)
        Me.cmbIdSucursal.TabIndex = 16
        '
        'lblIdSucursal
        '
        Me.lblIdSucursal.AutoSize = True
        Me.lblIdSucursal.LabelAsoc = Nothing
        Me.lblIdSucursal.Location = New System.Drawing.Point(37, 72)
        Me.lblIdSucursal.Name = "lblIdSucursal"
        Me.lblIdSucursal.Size = New System.Drawing.Size(48, 13)
        Me.lblIdSucursal.TabIndex = 15
        Me.lblIdSucursal.Text = "Sucursal"
        '
        'chbActivo
        '
        Me.chbActivo.AutoSize = True
        Me.chbActivo.BindearPropiedadControl = "Checked"
        Me.chbActivo.BindearPropiedadEntidad = "Activo"
        Me.chbActivo.ForeColorFocus = System.Drawing.Color.Red
        Me.chbActivo.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbActivo.IsPK = False
        Me.chbActivo.IsRequired = False
        Me.chbActivo.Key = Nothing
        Me.chbActivo.LabelAsoc = Nothing
        Me.chbActivo.Location = New System.Drawing.Point(907, 17)
        Me.chbActivo.Name = "chbActivo"
        Me.chbActivo.Size = New System.Drawing.Size(56, 17)
        Me.chbActivo.TabIndex = 31
        Me.chbActivo.Text = "Activo"
        Me.chbActivo.UseVisualStyleBackColor = True
        '
        'chbIdSucursal
        '
        Me.chbIdSucursal.AutoSize = True
        Me.chbIdSucursal.BindearPropiedadControl = ""
        Me.chbIdSucursal.BindearPropiedadEntidad = ""
        Me.chbIdSucursal.ForeColorFocus = System.Drawing.Color.Red
        Me.chbIdSucursal.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbIdSucursal.IsPK = False
        Me.chbIdSucursal.IsRequired = False
        Me.chbIdSucursal.Key = Nothing
        Me.chbIdSucursal.LabelAsoc = Nothing
        Me.chbIdSucursal.Location = New System.Drawing.Point(19, 71)
        Me.chbIdSucursal.Name = "chbIdSucursal"
        Me.chbIdSucursal.Size = New System.Drawing.Size(15, 14)
        Me.chbIdSucursal.TabIndex = 14
        Me.chbIdSucursal.UseVisualStyleBackColor = True
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
        Me.chbUsuario.Location = New System.Drawing.Point(275, 70)
        Me.chbUsuario.Name = "chbUsuario"
        Me.chbUsuario.Size = New System.Drawing.Size(62, 17)
        Me.chbUsuario.TabIndex = 17
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
        Me.cmbUsuario.Location = New System.Drawing.Point(340, 68)
        Me.cmbUsuario.Name = "cmbUsuario"
        Me.cmbUsuario.Size = New System.Drawing.Size(158, 21)
        Me.cmbUsuario.TabIndex = 18
        '
        'ChbPermitirEscritura
        '
        Me.ChbPermitirEscritura.AutoSize = True
        Me.ChbPermitirEscritura.Checked = True
        Me.ChbPermitirEscritura.CheckState = System.Windows.Forms.CheckState.Checked
        Me.ChbPermitirEscritura.Location = New System.Drawing.Point(219, 76)
        Me.ChbPermitirEscritura.Name = "ChbPermitirEscritura"
        Me.ChbPermitirEscritura.Size = New System.Drawing.Size(104, 17)
        Me.ChbPermitirEscritura.TabIndex = 2
        Me.ChbPermitirEscritura.Text = "Permitir Escritura"
        Me.ChbPermitirEscritura.UseVisualStyleBackColor = True
        '
        'lblUsuarios
        '
        Me.lblUsuarios.AutoSize = True
        Me.lblUsuarios.LabelAsoc = Nothing
        Me.lblUsuarios.Location = New System.Drawing.Point(19, 20)
        Me.lblUsuarios.Name = "lblUsuarios"
        Me.lblUsuarios.Size = New System.Drawing.Size(97, 13)
        Me.lblUsuarios.TabIndex = 0
        Me.lblUsuarios.Text = "Todos los Usuarios"
        '
        'dgvUsuariosCalendarios
        '
        Me.dgvUsuariosCalendarios.AllowUserToAddRows = False
        Me.dgvUsuariosCalendarios.AllowUserToDeleteRows = False
        Me.dgvUsuariosCalendarios.AllowUserToResizeColumns = False
        Me.dgvUsuariosCalendarios.AllowUserToResizeRows = False
        Me.dgvUsuariosCalendarios.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvUsuariosCalendarios.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.dgvUsuariosCalendarios.Location = New System.Drawing.Point(323, 36)
        Me.dgvUsuariosCalendarios.Name = "dgvUsuariosCalendarios"
        Me.dgvUsuariosCalendarios.RowHeadersVisible = False
        Me.dgvUsuariosCalendarios.RowHeadersWidth = 20
        Me.dgvUsuariosCalendarios.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvUsuariosCalendarios.Size = New System.Drawing.Size(182, 249)
        Me.dgvUsuariosCalendarios.TabIndex = 6
        '
        'btnQuitar
        '
        Me.btnQuitar.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.btnQuitar.Image = Global.Eniac.Win.My.Resources.Resources.delete_24
        Me.btnQuitar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnQuitar.Location = New System.Drawing.Point(224, 145)
        Me.btnQuitar.Name = "btnQuitar"
        Me.btnQuitar.Size = New System.Drawing.Size(90, 40)
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
        Me.btnAgregar.Location = New System.Drawing.Point(224, 99)
        Me.btnAgregar.Name = "btnAgregar"
        Me.btnAgregar.Size = New System.Drawing.Size(90, 40)
        Me.btnAgregar.TabIndex = 3
        Me.btnAgregar.Text = "Agregar >"
        Me.btnAgregar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnAgregar.UseVisualStyleBackColor = True
        '
        'lblUsuariosCalendario
        '
        Me.lblUsuariosCalendario.AutoSize = True
        Me.lblUsuariosCalendario.LabelAsoc = Nothing
        Me.lblUsuariosCalendario.Location = New System.Drawing.Point(320, 20)
        Me.lblUsuariosCalendario.Name = "lblUsuariosCalendario"
        Me.lblUsuariosCalendario.Size = New System.Drawing.Size(118, 13)
        Me.lblUsuariosCalendario.TabIndex = 5
        Me.lblUsuariosCalendario.Text = "Usuarios del Calendario"
        '
        'cmbDiaSemana
        '
        Me.cmbDiaSemana.BindearPropiedadControl = ""
        Me.cmbDiaSemana.BindearPropiedadEntidad = ""
        Me.cmbDiaSemana.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbDiaSemana.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbDiaSemana.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbDiaSemana.FormattingEnabled = True
        Me.cmbDiaSemana.IsPK = False
        Me.cmbDiaSemana.IsRequired = False
        Me.cmbDiaSemana.Key = Nothing
        Me.cmbDiaSemana.LabelAsoc = Me.lblDiaSemana
        Me.cmbDiaSemana.Location = New System.Drawing.Point(43, 56)
        Me.cmbDiaSemana.Name = "cmbDiaSemana"
        Me.cmbDiaSemana.Size = New System.Drawing.Size(101, 21)
        Me.cmbDiaSemana.TabIndex = 5
        '
        'lblDiaSemana
        '
        Me.lblDiaSemana.AutoSize = True
        Me.lblDiaSemana.LabelAsoc = Nothing
        Me.lblDiaSemana.Location = New System.Drawing.Point(12, 60)
        Me.lblDiaSemana.Name = "lblDiaSemana"
        Me.lblDiaSemana.Size = New System.Drawing.Size(25, 13)
        Me.lblDiaSemana.TabIndex = 4
        Me.lblDiaSemana.Text = "Día"
        '
        'dtpHoraHasta
        '
        Me.dtpHoraHasta.BindearPropiedadControl = ""
        Me.dtpHoraHasta.BindearPropiedadEntidad = ""
        Me.dtpHoraHasta.CustomFormat = "HH:mm"
        Me.dtpHoraHasta.ForeColorFocus = System.Drawing.Color.Red
        Me.dtpHoraHasta.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.dtpHoraHasta.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpHoraHasta.IsPK = False
        Me.dtpHoraHasta.IsRequired = False
        Me.dtpHoraHasta.Key = ""
        Me.dtpHoraHasta.LabelAsoc = Me.lblHoraHasta
        Me.dtpHoraHasta.Location = New System.Drawing.Point(304, 57)
        Me.dtpHoraHasta.Name = "dtpHoraHasta"
        Me.dtpHoraHasta.ShowUpDown = True
        Me.dtpHoraHasta.Size = New System.Drawing.Size(52, 20)
        Me.dtpHoraHasta.TabIndex = 9
        '
        'lblHoraHasta
        '
        Me.lblHoraHasta.AutoSize = True
        Me.lblHoraHasta.LabelAsoc = Nothing
        Me.lblHoraHasta.Location = New System.Drawing.Point(269, 61)
        Me.lblHoraHasta.Name = "lblHoraHasta"
        Me.lblHoraHasta.Size = New System.Drawing.Size(35, 13)
        Me.lblHoraHasta.TabIndex = 8
        Me.lblHoraHasta.Text = "Hasta"
        '
        'txtLapsoPorDefecto
        '
        Me.txtLapsoPorDefecto.BindearPropiedadControl = "Text"
        Me.txtLapsoPorDefecto.BindearPropiedadEntidad = "LapsoPorDefecto"
        Me.txtLapsoPorDefecto.ForeColorFocus = System.Drawing.Color.Red
        Me.txtLapsoPorDefecto.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtLapsoPorDefecto.Formato = ""
        Me.txtLapsoPorDefecto.IsDecimal = False
        Me.txtLapsoPorDefecto.IsNumber = True
        Me.txtLapsoPorDefecto.IsPK = False
        Me.txtLapsoPorDefecto.IsRequired = True
        Me.txtLapsoPorDefecto.Key = ""
        Me.txtLapsoPorDefecto.LabelAsoc = Me.lblLapsoPorDefecto
        Me.txtLapsoPorDefecto.Location = New System.Drawing.Point(107, 20)
        Me.txtLapsoPorDefecto.MaxLength = 10
        Me.txtLapsoPorDefecto.Name = "txtLapsoPorDefecto"
        Me.txtLapsoPorDefecto.Size = New System.Drawing.Size(54, 20)
        Me.txtLapsoPorDefecto.TabIndex = 1
        Me.txtLapsoPorDefecto.Text = "30"
        Me.txtLapsoPorDefecto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblLapsoPorDefecto
        '
        Me.lblLapsoPorDefecto.AutoSize = True
        Me.lblLapsoPorDefecto.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblLapsoPorDefecto.LabelAsoc = Nothing
        Me.lblLapsoPorDefecto.Location = New System.Drawing.Point(12, 24)
        Me.lblLapsoPorDefecto.Name = "lblLapsoPorDefecto"
        Me.lblLapsoPorDefecto.Size = New System.Drawing.Size(93, 13)
        Me.lblLapsoPorDefecto.TabIndex = 0
        Me.lblLapsoPorDefecto.Text = "Lapso por defecto"
        '
        'dtpHoraDesde
        '
        Me.dtpHoraDesde.BindearPropiedadControl = ""
        Me.dtpHoraDesde.BindearPropiedadEntidad = ""
        Me.dtpHoraDesde.CustomFormat = "HH:mm"
        Me.dtpHoraDesde.ForeColorFocus = System.Drawing.Color.Red
        Me.dtpHoraDesde.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.dtpHoraDesde.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpHoraDesde.IsPK = False
        Me.dtpHoraDesde.IsRequired = False
        Me.dtpHoraDesde.Key = ""
        Me.dtpHoraDesde.LabelAsoc = Me.lblHoraDesde
        Me.dtpHoraDesde.Location = New System.Drawing.Point(198, 57)
        Me.dtpHoraDesde.Name = "dtpHoraDesde"
        Me.dtpHoraDesde.ShowUpDown = True
        Me.dtpHoraDesde.Size = New System.Drawing.Size(52, 20)
        Me.dtpHoraDesde.TabIndex = 7
        '
        'lblHoraDesde
        '
        Me.lblHoraDesde.AutoSize = True
        Me.lblHoraDesde.LabelAsoc = Nothing
        Me.lblHoraDesde.Location = New System.Drawing.Point(158, 61)
        Me.lblHoraDesde.Name = "lblHoraDesde"
        Me.lblHoraDesde.Size = New System.Drawing.Size(38, 13)
        Me.lblHoraDesde.TabIndex = 6
        Me.lblHoraDesde.Text = "Desde"
        '
        'lblLapsoPorDefectoUnidadTiempo
        '
        Me.lblLapsoPorDefectoUnidadTiempo.AutoSize = True
        Me.lblLapsoPorDefectoUnidadTiempo.LabelAsoc = Nothing
        Me.lblLapsoPorDefectoUnidadTiempo.Location = New System.Drawing.Point(167, 24)
        Me.lblLapsoPorDefectoUnidadTiempo.Name = "lblLapsoPorDefectoUnidadTiempo"
        Me.lblLapsoPorDefectoUnidadTiempo.Size = New System.Drawing.Size(44, 13)
        Me.lblLapsoPorDefectoUnidadTiempo.TabIndex = 2
        Me.lblLapsoPorDefectoUnidadTiempo.Text = "Minutos"
        '
        'chbLapsoPorDefectoFijo
        '
        Me.chbLapsoPorDefectoFijo.AutoSize = True
        Me.chbLapsoPorDefectoFijo.BindearPropiedadControl = "Checked"
        Me.chbLapsoPorDefectoFijo.BindearPropiedadEntidad = "LapsoPorDefectoFijo"
        Me.chbLapsoPorDefectoFijo.ForeColorFocus = System.Drawing.Color.Red
        Me.chbLapsoPorDefectoFijo.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbLapsoPorDefectoFijo.IsPK = False
        Me.chbLapsoPorDefectoFijo.IsRequired = False
        Me.chbLapsoPorDefectoFijo.Key = Nothing
        Me.chbLapsoPorDefectoFijo.LabelAsoc = Nothing
        Me.chbLapsoPorDefectoFijo.Location = New System.Drawing.Point(254, 22)
        Me.chbLapsoPorDefectoFijo.Name = "chbLapsoPorDefectoFijo"
        Me.chbLapsoPorDefectoFijo.Size = New System.Drawing.Size(42, 17)
        Me.chbLapsoPorDefectoFijo.TabIndex = 3
        Me.chbLapsoPorDefectoFijo.Text = "Fijo"
        Me.chbLapsoPorDefectoFijo.UseVisualStyleBackColor = True
        '
        'ugDiasSemana
        '
        Appearance1.BackColor = System.Drawing.SystemColors.Window
        Appearance1.BorderColor = System.Drawing.SystemColors.InactiveCaption
        Me.ugDiasSemana.DisplayLayout.Appearance = Appearance1
        Me.ugDiasSemana.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ResizeAllColumns
        UltraGridColumn1.Header.VisiblePosition = 0
        UltraGridColumn1.Hidden = True
        UltraGridColumn2.Header.VisiblePosition = 1
        UltraGridColumn2.Hidden = True
        UltraGridColumn2.Width = 72
        UltraGridColumn3.Header.VisiblePosition = 2
        UltraGridColumn3.Hidden = True
        Appearance2.TextHAlignAsString = "Right"
        UltraGridColumn4.CellAppearance = Appearance2
        UltraGridColumn4.Header.Caption = "Desde"
        UltraGridColumn4.Header.VisiblePosition = 4
        UltraGridColumn4.Width = 105
        Appearance3.TextHAlignAsString = "Right"
        UltraGridColumn5.CellAppearance = Appearance3
        UltraGridColumn5.Header.Caption = "Hasta"
        UltraGridColumn5.Header.VisiblePosition = 5
        UltraGridColumn5.Width = 96
        UltraGridColumn6.Header.Caption = "Día"
        UltraGridColumn6.Header.VisiblePosition = 3
        UltraGridColumn6.Width = 148
        UltraGridBand1.Columns.AddRange(New Object() {UltraGridColumn1, UltraGridColumn2, UltraGridColumn3, UltraGridColumn4, UltraGridColumn5, UltraGridColumn6})
        Me.ugDiasSemana.DisplayLayout.BandsSerializer.Add(UltraGridBand1)
        Me.ugDiasSemana.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.ugDiasSemana.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.[False]
        Appearance4.BackColor = System.Drawing.SystemColors.ActiveBorder
        Appearance4.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance4.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Appearance4.BorderColor = System.Drawing.SystemColors.Window
        Me.ugDiasSemana.DisplayLayout.GroupByBox.Appearance = Appearance4
        Appearance5.ForeColor = System.Drawing.SystemColors.GrayText
        Me.ugDiasSemana.DisplayLayout.GroupByBox.BandLabelAppearance = Appearance5
        Me.ugDiasSemana.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Appearance6.BackColor = System.Drawing.SystemColors.ControlLightLight
        Appearance6.BackColor2 = System.Drawing.SystemColors.Control
        Appearance6.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance6.ForeColor = System.Drawing.SystemColors.GrayText
        Me.ugDiasSemana.DisplayLayout.GroupByBox.PromptAppearance = Appearance6
        Me.ugDiasSemana.DisplayLayout.MaxColScrollRegions = 1
        Me.ugDiasSemana.DisplayLayout.MaxRowScrollRegions = 1
        Appearance7.BackColor = System.Drawing.SystemColors.Window
        Appearance7.ForeColor = System.Drawing.SystemColors.ControlText
        Me.ugDiasSemana.DisplayLayout.Override.ActiveCellAppearance = Appearance7
        Appearance8.BackColor = System.Drawing.SystemColors.Highlight
        Appearance8.ForeColor = System.Drawing.SystemColors.HighlightText
        Me.ugDiasSemana.DisplayLayout.Override.ActiveRowAppearance = Appearance8
        Me.ugDiasSemana.DisplayLayout.Override.AllowUpdate = Infragistics.Win.DefaultableBoolean.[False]
        Me.ugDiasSemana.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted
        Me.ugDiasSemana.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted
        Appearance9.BackColor = System.Drawing.SystemColors.Window
        Me.ugDiasSemana.DisplayLayout.Override.CardAreaAppearance = Appearance9
        Appearance10.BorderColor = System.Drawing.Color.Silver
        Appearance10.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter
        Me.ugDiasSemana.DisplayLayout.Override.CellAppearance = Appearance10
        Me.ugDiasSemana.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText
        Me.ugDiasSemana.DisplayLayout.Override.CellPadding = 0
        Appearance11.BackColor = System.Drawing.SystemColors.Control
        Appearance11.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance11.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element
        Appearance11.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance11.BorderColor = System.Drawing.SystemColors.Window
        Me.ugDiasSemana.DisplayLayout.Override.GroupByRowAppearance = Appearance11
        Appearance12.TextHAlignAsString = "Left"
        Me.ugDiasSemana.DisplayLayout.Override.HeaderAppearance = Appearance12
        Me.ugDiasSemana.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
        Me.ugDiasSemana.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand
        Appearance13.BackColor = System.Drawing.SystemColors.Window
        Appearance13.BorderColor = System.Drawing.Color.Silver
        Me.ugDiasSemana.DisplayLayout.Override.RowAppearance = Appearance13
        Me.ugDiasSemana.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[False]
        Appearance14.BackColor = System.Drawing.SystemColors.ControlLight
        Me.ugDiasSemana.DisplayLayout.Override.TemplateAddRowAppearance = Appearance14
        Me.ugDiasSemana.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill
        Me.ugDiasSemana.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate
        Me.ugDiasSemana.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy
        Me.ugDiasSemana.Location = New System.Drawing.Point(15, 82)
        Me.ugDiasSemana.Name = "ugDiasSemana"
        Me.ugDiasSemana.Size = New System.Drawing.Size(351, 210)
        Me.ugDiasSemana.TabIndex = 12
        Me.ugDiasSemana.Text = "UltraGrid1"
        '
        'btnEliminar
        '
        Me.btnEliminar.Image = CType(resources.GetObject("btnEliminar.Image"), System.Drawing.Image)
        Me.btnEliminar.Location = New System.Drawing.Point(372, 99)
        Me.btnEliminar.Name = "btnEliminar"
        Me.btnEliminar.Size = New System.Drawing.Size(37, 37)
        Me.btnEliminar.TabIndex = 11
        Me.btnEliminar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnEliminar.UseVisualStyleBackColor = True
        '
        'btnInsertar
        '
        Me.btnInsertar.Image = Global.Eniac.Win.My.Resources.Resources.add_32
        Me.btnInsertar.Location = New System.Drawing.Point(372, 56)
        Me.btnInsertar.Name = "btnInsertar"
        Me.btnInsertar.Size = New System.Drawing.Size(37, 37)
        Me.btnInsertar.TabIndex = 10
        Me.btnInsertar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnInsertar.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.dgvUsuarios)
        Me.GroupBox1.Controls.Add(Me.lblUsuarios)
        Me.GroupBox1.Controls.Add(Me.btnAgregar)
        Me.GroupBox1.Controls.Add(Me.btnQuitar)
        Me.GroupBox1.Controls.Add(Me.ChbPermitirEscritura)
        Me.GroupBox1.Controls.Add(Me.dgvUsuariosCalendarios)
        Me.GroupBox1.Controls.Add(Me.lblUsuariosCalendario)
        Me.GroupBox1.Location = New System.Drawing.Point(441, 147)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(524, 298)
        Me.GroupBox1.TabIndex = 29
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Usuarios"
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
        Me.dgvUsuarios.Location = New System.Drawing.Point(19, 36)
        Me.dgvUsuarios.Name = "dgvUsuarios"
        Me.dgvUsuarios.RowHeadersVisible = False
        Me.dgvUsuarios.RowHeadersWidth = 20
        Me.dgvUsuarios.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvUsuarios.Size = New System.Drawing.Size(196, 249)
        Me.dgvUsuarios.TabIndex = 1
        '
        'Id
        '
        Me.Id.DataPropertyName = "Id"
        Me.Id.HeaderText = "Id"
        Me.Id.Name = "Id"
        Me.Id.Width = 50
        '
        'Nombre
        '
        Me.Nombre.DataPropertyName = "Nombre"
        Me.Nombre.HeaderText = "Nombre"
        Me.Nombre.Name = "Nombre"
        Me.Nombre.Width = 130
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.ugDiasSemana)
        Me.GroupBox2.Controls.Add(Me.lblHoraDesde)
        Me.GroupBox2.Controls.Add(Me.lblHoraHasta)
        Me.GroupBox2.Controls.Add(Me.btnInsertar)
        Me.GroupBox2.Controls.Add(Me.lblDiaSemana)
        Me.GroupBox2.Controls.Add(Me.btnEliminar)
        Me.GroupBox2.Controls.Add(Me.chbLapsoPorDefectoFijo)
        Me.GroupBox2.Controls.Add(Me.lblLapsoPorDefectoUnidadTiempo)
        Me.GroupBox2.Controls.Add(Me.lblLapsoPorDefecto)
        Me.GroupBox2.Controls.Add(Me.dtpHoraDesde)
        Me.GroupBox2.Controls.Add(Me.cmbDiaSemana)
        Me.GroupBox2.Controls.Add(Me.txtLapsoPorDefecto)
        Me.GroupBox2.Controls.Add(Me.dtpHoraHasta)
        Me.GroupBox2.Location = New System.Drawing.Point(14, 147)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(421, 298)
        Me.GroupBox2.TabIndex = 28
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Horarios"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Label3.LabelAsoc = Nothing
        Me.Label3.Location = New System.Drawing.Point(341, 46)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(62, 13)
        Me.Label3.TabIndex = 6
        Me.Label3.Text = "Dias Desde"
        '
        'txtDiasDesde
        '
        Me.txtDiasDesde.BindearPropiedadControl = "Text"
        Me.txtDiasDesde.BindearPropiedadEntidad = "DiasDesde"
        Me.txtDiasDesde.ForeColorFocus = System.Drawing.Color.Red
        Me.txtDiasDesde.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtDiasDesde.Formato = ""
        Me.txtDiasDesde.IsDecimal = True
        Me.txtDiasDesde.IsNumber = True
        Me.txtDiasDesde.IsPK = False
        Me.txtDiasDesde.IsRequired = False
        Me.txtDiasDesde.Key = ""
        Me.txtDiasDesde.LabelAsoc = Me.Label3
        Me.txtDiasDesde.Location = New System.Drawing.Point(409, 43)
        Me.txtDiasDesde.MaxLength = 10
        Me.txtDiasDesde.Name = "txtDiasDesde"
        Me.txtDiasDesde.Size = New System.Drawing.Size(54, 20)
        Me.txtDiasDesde.TabIndex = 7
        Me.txtDiasDesde.Text = "-7"
        Me.txtDiasDesde.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Label4.LabelAsoc = Nothing
        Me.Label4.Location = New System.Drawing.Point(478, 46)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(59, 13)
        Me.Label4.TabIndex = 8
        Me.Label4.Text = "Dias Hasta"
        '
        'txtDiasHasta
        '
        Me.txtDiasHasta.BindearPropiedadControl = "Text"
        Me.txtDiasHasta.BindearPropiedadEntidad = "DiasHasta"
        Me.txtDiasHasta.ForeColorFocus = System.Drawing.Color.Red
        Me.txtDiasHasta.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtDiasHasta.Formato = ""
        Me.txtDiasHasta.IsDecimal = False
        Me.txtDiasHasta.IsNumber = True
        Me.txtDiasHasta.IsPK = False
        Me.txtDiasHasta.IsRequired = False
        Me.txtDiasHasta.Key = ""
        Me.txtDiasHasta.LabelAsoc = Me.Label4
        Me.txtDiasHasta.Location = New System.Drawing.Point(540, 43)
        Me.txtDiasHasta.MaxLength = 10
        Me.txtDiasHasta.Name = "txtDiasHasta"
        Me.txtDiasHasta.Size = New System.Drawing.Size(54, 20)
        Me.txtDiasHasta.TabIndex = 9
        Me.txtDiasHasta.Text = "30"
        Me.txtDiasHasta.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Label5.LabelAsoc = Nothing
        Me.Label5.Location = New System.Drawing.Point(874, 46)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(32, 13)
        Me.Label5.TabIndex = 12
        Me.Label5.Text = "Cupo"
        '
        'txtCupo
        '
        Me.txtCupo.BindearPropiedadControl = "Text"
        Me.txtCupo.BindearPropiedadEntidad = "Cupo"
        Me.txtCupo.ForeColorFocus = System.Drawing.Color.Red
        Me.txtCupo.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtCupo.Formato = ""
        Me.txtCupo.IsDecimal = False
        Me.txtCupo.IsNumber = True
        Me.txtCupo.IsPK = False
        Me.txtCupo.IsRequired = False
        Me.txtCupo.Key = ""
        Me.txtCupo.LabelAsoc = Me.Label5
        Me.txtCupo.Location = New System.Drawing.Point(907, 43)
        Me.txtCupo.MaxLength = 10
        Me.txtCupo.Name = "txtCupo"
        Me.txtCupo.Size = New System.Drawing.Size(34, 20)
        Me.txtCupo.TabIndex = 13
        Me.txtCupo.Text = "1"
        Me.txtCupo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblDiasHabilitacionReserva
        '
        Me.lblDiasHabilitacionReserva.AutoSize = True
        Me.lblDiasHabilitacionReserva.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblDiasHabilitacionReserva.LabelAsoc = Nothing
        Me.lblDiasHabilitacionReserva.Location = New System.Drawing.Point(604, 46)
        Me.lblDiasHabilitacionReserva.Name = "lblDiasHabilitacionReserva"
        Me.lblDiasHabilitacionReserva.Size = New System.Drawing.Size(190, 13)
        Me.lblDiasHabilitacionReserva.TabIndex = 10
        Me.lblDiasHabilitacionReserva.Text = "Dias Permitidos de Reserva Anticipada"
        '
        'txtDiasHabilitacionReserva
        '
        Me.txtDiasHabilitacionReserva.BindearPropiedadControl = "Text"
        Me.txtDiasHabilitacionReserva.BindearPropiedadEntidad = "DiasHabilitacionReserva"
        Me.txtDiasHabilitacionReserva.ForeColorFocus = System.Drawing.Color.Red
        Me.txtDiasHabilitacionReserva.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtDiasHabilitacionReserva.Formato = ""
        Me.txtDiasHabilitacionReserva.IsDecimal = False
        Me.txtDiasHabilitacionReserva.IsNumber = True
        Me.txtDiasHabilitacionReserva.IsPK = False
        Me.txtDiasHabilitacionReserva.IsRequired = False
        Me.txtDiasHabilitacionReserva.Key = ""
        Me.txtDiasHabilitacionReserva.LabelAsoc = Me.lblDiasHabilitacionReserva
        Me.txtDiasHabilitacionReserva.Location = New System.Drawing.Point(800, 43)
        Me.txtDiasHabilitacionReserva.MaxLength = 10
        Me.txtDiasHabilitacionReserva.Name = "txtDiasHabilitacionReserva"
        Me.txtDiasHabilitacionReserva.Size = New System.Drawing.Size(54, 20)
        Me.txtDiasHabilitacionReserva.TabIndex = 11
        Me.txtDiasHabilitacionReserva.Text = "365"
        Me.txtDiasHabilitacionReserva.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
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
        Me.bscProducto2.Enabled = False
        Me.bscProducto2.FilaDevuelta = Nothing
        Me.bscProducto2.ForeColorFocus = System.Drawing.Color.Red
        Me.bscProducto2.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.bscProducto2.IsDecimal = False
        Me.bscProducto2.IsNumber = False
        Me.bscProducto2.IsPK = False
        Me.bscProducto2.IsRequired = False
        Me.bscProducto2.Key = ""
        Me.bscProducto2.LabelAsoc = Nothing
        Me.bscProducto2.Location = New System.Drawing.Point(701, 68)
        Me.bscProducto2.MaxLengh = "32767"
        Me.bscProducto2.Name = "bscProducto2"
        Me.bscProducto2.Permitido = True
        Me.bscProducto2.PermitidoNoBackColor = System.Drawing.Color.FromArgb(CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer))
        Me.bscProducto2.PermitidoNoForeColor = System.Drawing.Color.Black
        Me.bscProducto2.PermitidoSiBackColor = System.Drawing.Color.White
        Me.bscProducto2.PermitidoSiForeColor = System.Drawing.Color.Black
        Me.bscProducto2.Selecciono = False
        Me.bscProducto2.Size = New System.Drawing.Size(262, 20)
        Me.bscProducto2.TabIndex = 21
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
        Me.bscCodigoProducto2.Enabled = False
        Me.bscCodigoProducto2.FilaDevuelta = Nothing
        Me.bscCodigoProducto2.ForeColorFocus = System.Drawing.Color.Red
        Me.bscCodigoProducto2.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.bscCodigoProducto2.IsDecimal = False
        Me.bscCodigoProducto2.IsNumber = False
        Me.bscCodigoProducto2.IsPK = False
        Me.bscCodigoProducto2.IsRequired = False
        Me.bscCodigoProducto2.Key = ""
        Me.bscCodigoProducto2.LabelAsoc = Nothing
        Me.bscCodigoProducto2.Location = New System.Drawing.Point(575, 68)
        Me.bscCodigoProducto2.MaxLengh = "32767"
        Me.bscCodigoProducto2.Name = "bscCodigoProducto2"
        Me.bscCodigoProducto2.Permitido = True
        Me.bscCodigoProducto2.PermitidoNoBackColor = System.Drawing.Color.FromArgb(CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer))
        Me.bscCodigoProducto2.PermitidoNoForeColor = System.Drawing.Color.Black
        Me.bscCodigoProducto2.PermitidoSiBackColor = System.Drawing.Color.White
        Me.bscCodigoProducto2.PermitidoSiForeColor = System.Drawing.Color.Black
        Me.bscCodigoProducto2.Selecciono = False
        Me.bscCodigoProducto2.Size = New System.Drawing.Size(123, 20)
        Me.bscCodigoProducto2.TabIndex = 20
        '
        'chbProducto
        '
        Me.chbProducto.AutoSize = True
        Me.chbProducto.BindearPropiedadControl = Nothing
        Me.chbProducto.BindearPropiedadEntidad = Nothing
        Me.chbProducto.ForeColorFocus = System.Drawing.Color.Red
        Me.chbProducto.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbProducto.IsPK = False
        Me.chbProducto.IsRequired = False
        Me.chbProducto.Key = Nothing
        Me.chbProducto.LabelAsoc = Nothing
        Me.chbProducto.Location = New System.Drawing.Point(504, 70)
        Me.chbProducto.Name = "chbProducto"
        Me.chbProducto.Size = New System.Drawing.Size(69, 17)
        Me.chbProducto.TabIndex = 19
        Me.chbProducto.Text = "Producto"
        '
        'chbSesion
        '
        Me.chbSesion.AutoSize = True
        Me.chbSesion.BindearPropiedadControl = "Checked"
        Me.chbSesion.BindearPropiedadEntidad = "UtilizaSesion"
        Me.chbSesion.ForeColorFocus = System.Drawing.Color.Red
        Me.chbSesion.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbSesion.IsPK = False
        Me.chbSesion.IsRequired = False
        Me.chbSesion.Key = Nothing
        Me.chbSesion.LabelAsoc = Nothing
        Me.chbSesion.Location = New System.Drawing.Point(19, 95)
        Me.chbSesion.Name = "chbSesion"
        Me.chbSesion.Size = New System.Drawing.Size(89, 17)
        Me.chbSesion.TabIndex = 22
        Me.chbSesion.Text = "Utiliza Sesión"
        Me.chbSesion.UseVisualStyleBackColor = True
        '
        'chbZona
        '
        Me.chbZona.AutoSize = True
        Me.chbZona.BindearPropiedadControl = "Checked"
        Me.chbZona.BindearPropiedadEntidad = "UtilizaZonas"
        Me.chbZona.ForeColorFocus = System.Drawing.Color.Red
        Me.chbZona.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbZona.IsPK = False
        Me.chbZona.IsRequired = False
        Me.chbZona.Key = Nothing
        Me.chbZona.LabelAsoc = Nothing
        Me.chbZona.Location = New System.Drawing.Point(114, 95)
        Me.chbZona.Name = "chbZona"
        Me.chbZona.Size = New System.Drawing.Size(87, 17)
        Me.chbZona.TabIndex = 23
        Me.chbZona.Text = "Utiliza Zonas"
        Me.chbZona.UseVisualStyleBackColor = True
        '
        'cmbCajas
        '
        Me.cmbCajas.BindearPropiedadControl = ""
        Me.cmbCajas.BindearPropiedadEntidad = ""
        Me.cmbCajas.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbCajas.Enabled = False
        Me.cmbCajas.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbCajas.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbCajas.FormattingEnabled = True
        Me.cmbCajas.IsPK = False
        Me.cmbCajas.IsRequired = False
        Me.cmbCajas.Key = Nothing
        Me.cmbCajas.LabelAsoc = Nothing
        Me.cmbCajas.Location = New System.Drawing.Point(260, 93)
        Me.cmbCajas.Name = "cmbCajas"
        Me.cmbCajas.Size = New System.Drawing.Size(143, 21)
        Me.cmbCajas.TabIndex = 25
        '
        'chbCajas
        '
        Me.chbCajas.AutoSize = True
        Me.chbCajas.BindearPropiedadControl = Nothing
        Me.chbCajas.BindearPropiedadEntidad = Nothing
        Me.chbCajas.ForeColorFocus = System.Drawing.Color.Red
        Me.chbCajas.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbCajas.IsPK = False
        Me.chbCajas.IsRequired = False
        Me.chbCajas.Key = Nothing
        Me.chbCajas.LabelAsoc = Nothing
        Me.chbCajas.Location = New System.Drawing.Point(207, 95)
        Me.chbCajas.Name = "chbCajas"
        Me.chbCajas.Size = New System.Drawing.Size(47, 17)
        Me.chbCajas.TabIndex = 24
        Me.chbCajas.Text = "Caja"
        Me.chbCajas.UseVisualStyleBackColor = True
        '
        'chbPublicarEnWeb
        '
        Me.chbPublicarEnWeb.AutoSize = True
        Me.chbPublicarEnWeb.BindearPropiedadControl = "Checked"
        Me.chbPublicarEnWeb.BindearPropiedadEntidad = "PublicarEnWeb"
        Me.chbPublicarEnWeb.ForeColorFocus = System.Drawing.Color.Red
        Me.chbPublicarEnWeb.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbPublicarEnWeb.IsPK = False
        Me.chbPublicarEnWeb.IsRequired = False
        Me.chbPublicarEnWeb.Key = Nothing
        Me.chbPublicarEnWeb.LabelAsoc = Nothing
        Me.chbPublicarEnWeb.Location = New System.Drawing.Point(801, 17)
        Me.chbPublicarEnWeb.Name = "chbPublicarEnWeb"
        Me.chbPublicarEnWeb.Size = New System.Drawing.Size(100, 17)
        Me.chbPublicarEnWeb.TabIndex = 30
        Me.chbPublicarEnWeb.Text = "PublicarEnWeb"
        Me.chbPublicarEnWeb.UseVisualStyleBackColor = True
        '
        'lblTipoCalendario
        '
        Me.lblTipoCalendario.AutoSize = True
        Me.lblTipoCalendario.LabelAsoc = Nothing
        Me.lblTipoCalendario.Location = New System.Drawing.Point(275, 18)
        Me.lblTipoCalendario.Name = "lblTipoCalendario"
        Me.lblTipoCalendario.Size = New System.Drawing.Size(28, 13)
        Me.lblTipoCalendario.TabIndex = 2
        Me.lblTipoCalendario.Text = "Tipo"
        '
        'cmbTipoCalendario
        '
        Me.cmbTipoCalendario.BindearPropiedadControl = "SelectedValue"
        Me.cmbTipoCalendario.BindearPropiedadEntidad = "IdTipoCalendario"
        Me.cmbTipoCalendario.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbTipoCalendario.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbTipoCalendario.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbTipoCalendario.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbTipoCalendario.FormattingEnabled = True
        Me.cmbTipoCalendario.IsPK = False
        Me.cmbTipoCalendario.IsRequired = False
        Me.cmbTipoCalendario.Key = Nothing
        Me.cmbTipoCalendario.LabelAsoc = Nothing
        Me.cmbTipoCalendario.Location = New System.Drawing.Point(340, 16)
        Me.cmbTipoCalendario.Name = "cmbTipoCalendario"
        Me.cmbTipoCalendario.Size = New System.Drawing.Size(158, 21)
        Me.cmbTipoCalendario.TabIndex = 3
        '
        'chbSolicitaEmbarcacion
        '
        Me.chbSolicitaEmbarcacion.AutoSize = True
        Me.chbSolicitaEmbarcacion.BindearPropiedadControl = "Checked"
        Me.chbSolicitaEmbarcacion.BindearPropiedadEntidad = "SolicitaEmbarcacion"
        Me.chbSolicitaEmbarcacion.ForeColorFocus = System.Drawing.Color.Red
        Me.chbSolicitaEmbarcacion.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbSolicitaEmbarcacion.IsPK = False
        Me.chbSolicitaEmbarcacion.IsRequired = False
        Me.chbSolicitaEmbarcacion.Key = Nothing
        Me.chbSolicitaEmbarcacion.LabelAsoc = Nothing
        Me.chbSolicitaEmbarcacion.Location = New System.Drawing.Point(527, 95)
        Me.chbSolicitaEmbarcacion.Name = "chbSolicitaEmbarcacion"
        Me.chbSolicitaEmbarcacion.Size = New System.Drawing.Size(125, 17)
        Me.chbSolicitaEmbarcacion.TabIndex = 26
        Me.chbSolicitaEmbarcacion.Text = "Solicita Embarcación"
        Me.chbSolicitaEmbarcacion.UseVisualStyleBackColor = True
        '
        'chbSolicitaBotado
        '
        Me.chbSolicitaBotado.AutoSize = True
        Me.chbSolicitaBotado.BindearPropiedadControl = "Checked"
        Me.chbSolicitaBotado.BindearPropiedadEntidad = "SolicitaBotado"
        Me.chbSolicitaBotado.ForeColorFocus = System.Drawing.Color.Red
        Me.chbSolicitaBotado.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbSolicitaBotado.IsPK = False
        Me.chbSolicitaBotado.IsRequired = False
        Me.chbSolicitaBotado.Key = Nothing
        Me.chbSolicitaBotado.LabelAsoc = Nothing
        Me.chbSolicitaBotado.Location = New System.Drawing.Point(658, 95)
        Me.chbSolicitaBotado.Name = "chbSolicitaBotado"
        Me.chbSolicitaBotado.Size = New System.Drawing.Size(97, 17)
        Me.chbSolicitaBotado.TabIndex = 27
        Me.chbSolicitaBotado.Text = "Solicita Botado"
        Me.chbSolicitaBotado.UseVisualStyleBackColor = True
        '
        'chbNave
        '
        Me.chbNave.AutoSize = True
        Me.chbNave.BindearPropiedadControl = Nothing
        Me.chbNave.BindearPropiedadEntidad = Nothing
        Me.chbNave.ForeColorFocus = System.Drawing.Color.Red
        Me.chbNave.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbNave.IsPK = False
        Me.chbNave.IsRequired = False
        Me.chbNave.Key = Nothing
        Me.chbNave.LabelAsoc = Nothing
        Me.chbNave.Location = New System.Drawing.Point(766, 95)
        Me.chbNave.Name = "chbNave"
        Me.chbNave.Size = New System.Drawing.Size(52, 17)
        Me.chbNave.TabIndex = 36
        Me.chbNave.Text = "Nave"
        Me.chbNave.UseVisualStyleBackColor = True
        '
        'cmbNave
        '
        Me.cmbNave.BindearPropiedadControl = "SelectedValue"
        Me.cmbNave.BindearPropiedadEntidad = "IdNave"
        Me.cmbNave.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbNave.Enabled = False
        Me.cmbNave.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbNave.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbNave.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbNave.FormattingEnabled = True
        Me.cmbNave.IsPK = False
        Me.cmbNave.IsRequired = False
        Me.cmbNave.Key = Nothing
        Me.cmbNave.LabelAsoc = Nothing
        Me.cmbNave.Location = New System.Drawing.Point(824, 93)
        Me.cmbNave.Name = "cmbNave"
        Me.cmbNave.Size = New System.Drawing.Size(139, 21)
        Me.cmbNave.TabIndex = 37
        '
        'chbSolicitaVehiculo
        '
        Me.chbSolicitaVehiculo.AutoSize = True
        Me.chbSolicitaVehiculo.BindearPropiedadControl = "Checked"
        Me.chbSolicitaVehiculo.BindearPropiedadEntidad = "SolicitaVehiculo"
        Me.chbSolicitaVehiculo.ForeColorFocus = System.Drawing.Color.Red
        Me.chbSolicitaVehiculo.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbSolicitaVehiculo.IsPK = False
        Me.chbSolicitaVehiculo.IsRequired = False
        Me.chbSolicitaVehiculo.Key = Nothing
        Me.chbSolicitaVehiculo.LabelAsoc = Nothing
        Me.chbSolicitaVehiculo.Location = New System.Drawing.Point(417, 95)
        Me.chbSolicitaVehiculo.Name = "chbSolicitaVehiculo"
        Me.chbSolicitaVehiculo.Size = New System.Drawing.Size(104, 17)
        Me.chbSolicitaVehiculo.TabIndex = 38
        Me.chbSolicitaVehiculo.Text = "Solicita Vehiculo"
        Me.chbSolicitaVehiculo.UseVisualStyleBackColor = True
        '
        'chbPermitirImpresionTurnos
        '
        Me.chbPermitirImpresionTurnos.AutoSize = True
        Me.chbPermitirImpresionTurnos.BindearPropiedadControl = "Checked"
        Me.chbPermitirImpresionTurnos.BindearPropiedadEntidad = "PermiteImpresion"
        Me.chbPermitirImpresionTurnos.ForeColorFocus = System.Drawing.Color.Red
        Me.chbPermitirImpresionTurnos.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbPermitirImpresionTurnos.IsPK = False
        Me.chbPermitirImpresionTurnos.IsRequired = False
        Me.chbPermitirImpresionTurnos.Key = Nothing
        Me.chbPermitirImpresionTurnos.LabelAsoc = Nothing
        Me.chbPermitirImpresionTurnos.Location = New System.Drawing.Point(19, 121)
        Me.chbPermitirImpresionTurnos.Name = "chbPermitirImpresionTurnos"
        Me.chbPermitirImpresionTurnos.Size = New System.Drawing.Size(159, 17)
        Me.chbPermitirImpresionTurnos.TabIndex = 39
        Me.chbPermitirImpresionTurnos.Text = "Permitir Impresion de Turnos"
        Me.chbPermitirImpresionTurnos.UseVisualStyleBackColor = True
        '
        'CalendariosDetalle
        '
        Me.AcceptButton = Nothing
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(975, 486)
        Me.Controls.Add(Me.chbPermitirImpresionTurnos)
        Me.Controls.Add(Me.chbSolicitaVehiculo)
        Me.Controls.Add(Me.chbNave)
        Me.Controls.Add(Me.cmbNave)
        Me.Controls.Add(Me.chbSolicitaBotado)
        Me.Controls.Add(Me.chbSolicitaEmbarcacion)
        Me.Controls.Add(Me.lblTipoCalendario)
        Me.Controls.Add(Me.cmbTipoCalendario)
        Me.Controls.Add(Me.chbPublicarEnWeb)
        Me.Controls.Add(Me.chbCajas)
        Me.Controls.Add(Me.cmbCajas)
        Me.Controls.Add(Me.chbZona)
        Me.Controls.Add(Me.chbSesion)
        Me.Controls.Add(Me.bscProducto2)
        Me.Controls.Add(Me.bscCodigoProducto2)
        Me.Controls.Add(Me.chbProducto)
        Me.Controls.Add(Me.lblDiasHabilitacionReserva)
        Me.Controls.Add(Me.txtDiasHabilitacionReserva)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.txtCupo)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.txtDiasHasta)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txtDiasDesde)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.chbUsuario)
        Me.Controls.Add(Me.cmbUsuario)
        Me.Controls.Add(Me.chbIdSucursal)
        Me.Controls.Add(Me.chbActivo)
        Me.Controls.Add(Me.cmbIdSucursal)
        Me.Controls.Add(Me.lblIdSucursal)
        Me.Controls.Add(Me.lblNombreCalendario)
        Me.Controls.Add(Me.txtNombreCalendario)
        Me.Controls.Add(Me.lblIdCalendario)
        Me.Controls.Add(Me.txtIdCalendario)
        Me.Name = "CalendariosDetalle"
        Me.Text = "Calendario"
        Me.Controls.SetChildIndex(Me.txtIdCalendario, 0)
        Me.Controls.SetChildIndex(Me.lblIdCalendario, 0)
        Me.Controls.SetChildIndex(Me.txtNombreCalendario, 0)
        Me.Controls.SetChildIndex(Me.lblNombreCalendario, 0)
        Me.Controls.SetChildIndex(Me.lblIdSucursal, 0)
        Me.Controls.SetChildIndex(Me.cmbIdSucursal, 0)
        Me.Controls.SetChildIndex(Me.chbActivo, 0)
        Me.Controls.SetChildIndex(Me.chbIdSucursal, 0)
        Me.Controls.SetChildIndex(Me.cmbUsuario, 0)
        Me.Controls.SetChildIndex(Me.chbUsuario, 0)
        Me.Controls.SetChildIndex(Me.GroupBox1, 0)
        Me.Controls.SetChildIndex(Me.GroupBox2, 0)
        Me.Controls.SetChildIndex(Me.txtDiasDesde, 0)
        Me.Controls.SetChildIndex(Me.Label3, 0)
        Me.Controls.SetChildIndex(Me.btnAplicar, 0)
        Me.Controls.SetChildIndex(Me.btnCancelar, 0)
        Me.Controls.SetChildIndex(Me.btnAceptar, 0)
        Me.Controls.SetChildIndex(Me.btnCopiar, 0)
        Me.Controls.SetChildIndex(Me.txtDiasHasta, 0)
        Me.Controls.SetChildIndex(Me.Label4, 0)
        Me.Controls.SetChildIndex(Me.txtCupo, 0)
        Me.Controls.SetChildIndex(Me.Label5, 0)
        Me.Controls.SetChildIndex(Me.txtDiasHabilitacionReserva, 0)
        Me.Controls.SetChildIndex(Me.lblDiasHabilitacionReserva, 0)
        Me.Controls.SetChildIndex(Me.chbProducto, 0)
        Me.Controls.SetChildIndex(Me.bscCodigoProducto2, 0)
        Me.Controls.SetChildIndex(Me.bscProducto2, 0)
        Me.Controls.SetChildIndex(Me.chbSesion, 0)
        Me.Controls.SetChildIndex(Me.chbZona, 0)
        Me.Controls.SetChildIndex(Me.cmbCajas, 0)
        Me.Controls.SetChildIndex(Me.chbCajas, 0)
        Me.Controls.SetChildIndex(Me.chbPublicarEnWeb, 0)
        Me.Controls.SetChildIndex(Me.cmbTipoCalendario, 0)
        Me.Controls.SetChildIndex(Me.lblTipoCalendario, 0)
        Me.Controls.SetChildIndex(Me.chbSolicitaEmbarcacion, 0)
        Me.Controls.SetChildIndex(Me.chbSolicitaBotado, 0)
        Me.Controls.SetChildIndex(Me.cmbNave, 0)
        Me.Controls.SetChildIndex(Me.chbNave, 0)
        Me.Controls.SetChildIndex(Me.chbSolicitaVehiculo, 0)
        Me.Controls.SetChildIndex(Me.chbPermitirImpresionTurnos, 0)
        CType(Me.dgvUsuariosCalendarios, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ugDiasSemana, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.dgvUsuarios, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lblNombreCalendario As Eniac.Controles.Label
   Friend WithEvents txtNombreCalendario As Eniac.Controles.TextBox
   Friend WithEvents lblIdCalendario As Eniac.Controles.Label
   Friend WithEvents txtIdCalendario As Eniac.Controles.TextBox
   Friend WithEvents cmbIdSucursal As Eniac.Controles.ComboBox
   Friend WithEvents lblIdSucursal As Eniac.Controles.Label
   Friend WithEvents chbActivo As Eniac.Controles.CheckBox
   Friend WithEvents chbIdSucursal As Eniac.Controles.CheckBox
   Friend WithEvents chbUsuario As Eniac.Controles.CheckBox
   Friend WithEvents cmbUsuario As Eniac.Controles.ComboBox
   Friend WithEvents ChbPermitirEscritura As System.Windows.Forms.CheckBox
   Friend WithEvents lblUsuarios As Eniac.Controles.Label
   Friend WithEvents dgvUsuariosCalendarios As Eniac.Controles.DataGridView
   Protected WithEvents btnQuitar As System.Windows.Forms.Button
   Protected WithEvents btnAgregar As System.Windows.Forms.Button
   Friend WithEvents lblUsuariosCalendario As Eniac.Controles.Label
   Friend WithEvents cmbDiaSemana As Eniac.Controles.ComboBox
   Friend WithEvents lblDiaSemana As Eniac.Controles.Label
   Friend WithEvents dtpHoraHasta As Eniac.Controles.DateTimePicker
   Friend WithEvents lblHoraHasta As Eniac.Controles.Label
   Friend WithEvents txtLapsoPorDefecto As Eniac.Controles.TextBox
   Friend WithEvents lblLapsoPorDefecto As Eniac.Controles.Label
   Friend WithEvents dtpHoraDesde As Eniac.Controles.DateTimePicker
   Friend WithEvents lblHoraDesde As Eniac.Controles.Label
   Friend WithEvents lblLapsoPorDefectoUnidadTiempo As Eniac.Controles.Label
   Friend WithEvents chbLapsoPorDefectoFijo As Eniac.Controles.CheckBox
   Friend WithEvents ugDiasSemana As Infragistics.Win.UltraWinGrid.UltraGrid
   Friend WithEvents btnEliminar As Eniac.Controles.Button
   Friend WithEvents btnInsertar As Eniac.Controles.Button
   Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
   Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
   Friend WithEvents dgvUsuarios As Eniac.Controles.DataGridView
   Friend WithEvents Label3 As Eniac.Controles.Label
   Friend WithEvents txtDiasDesde As Eniac.Controles.TextBox
   Friend WithEvents Label4 As Eniac.Controles.Label
   Friend WithEvents txtDiasHasta As Eniac.Controles.TextBox
   Friend WithEvents Label5 As Eniac.Controles.Label
   Friend WithEvents txtCupo As Eniac.Controles.TextBox
   Friend WithEvents lblDiasHabilitacionReserva As Eniac.Controles.Label
   Friend WithEvents txtDiasHabilitacionReserva As Eniac.Controles.TextBox
   Friend WithEvents bscProducto2 As Eniac.Controles.Buscador2
   Friend WithEvents bscCodigoProducto2 As Eniac.Controles.Buscador2
   Friend WithEvents chbProducto As Eniac.Controles.CheckBox
   Friend WithEvents chbSesion As Eniac.Controles.CheckBox
   Friend WithEvents chbZona As Eniac.Controles.CheckBox
   Friend WithEvents Id As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents Nombre As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents cmbCajas As Eniac.Controles.ComboBox
   Friend WithEvents chbCajas As Eniac.Controles.CheckBox
   Friend WithEvents chbPublicarEnWeb As Eniac.Controles.CheckBox
   Friend WithEvents lblTipoCalendario As Eniac.Controles.Label
   Friend WithEvents cmbTipoCalendario As Eniac.Controles.ComboBox
   Friend WithEvents chbSolicitaEmbarcacion As Eniac.Controles.CheckBox
   Friend WithEvents chbSolicitaBotado As Eniac.Controles.CheckBox
   Friend WithEvents chbNave As Eniac.Controles.CheckBox
   Friend WithEvents cmbNave As Eniac.Controles.ComboBox
    Friend WithEvents chbSolicitaVehiculo As Controles.CheckBox
    Friend WithEvents chbPermitirImpresionTurnos As Controles.CheckBox
End Class
