<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ProyectosDetalle
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
      Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ProyectosDetalle))
      Me.lblNombre = New Eniac.Controles.Label()
      Me.txtNombreProyecto = New Eniac.Controles.TextBox()
      Me.lblCodigo = New Eniac.Controles.Label()
      Me.txtIdProyecto = New Eniac.Controles.TextBox()
      Me.cmbEstado = New Eniac.Controles.ComboBox()
      Me.lblEstado = New Eniac.Controles.Label()
      Me.lblCliente = New Eniac.Controles.Label()
      Me.bscCliente = New Eniac.Controles.Buscador2()
      Me.bscCodigoCliente = New Eniac.Controles.Buscador()
      Me.lblCodigoCliente = New Eniac.Controles.Label()
      Me.dtpFechaInicio = New Eniac.Controles.DateTimePicker()
      Me.lblFechaInicio = New Eniac.Controles.Label()
      Me.dtpFechaFin = New Eniac.Controles.DateTimePicker()
      Me.lblFechaFin = New Eniac.Controles.Label()
      Me.txtHsCobradas = New Eniac.Controles.TextBox()
      Me.lblHsCobradas = New Eniac.Controles.Label()
      Me.txtPresupuestado = New Eniac.Controles.TextBox()
      Me.lblPresupuestado = New Eniac.Controles.Label()
      Me.lblPrioridadNovedad = New Eniac.Controles.Label()
      Me.Label1 = New Eniac.Controles.Label()
      Me.cmbClasificacion = New Eniac.Controles.ComboBox()
      Me.lblClienteVinculado = New Eniac.Controles.Label()
      Me.gbPrioridades = New System.Windows.Forms.GroupBox()
      Me.txtPrioridadPromedio = New Eniac.Controles.TextBox()
      Me.lblPrioridadPromedio = New Eniac.Controles.Label()
      Me.nudReplicabilidad = New System.Windows.Forms.NumericUpDown()
      Me.nudComplejidad = New System.Windows.Forms.NumericUpDown()
      Me.nudEstrategico = New System.Windows.Forms.NumericUpDown()
      Me.Label4 = New Eniac.Controles.Label()
      Me.Label5 = New Eniac.Controles.Label()
      Me.Label3 = New Eniac.Controles.Label()
      Me.nudImporte = New System.Windows.Forms.NumericUpDown()
      Me.Label2 = New Eniac.Controles.Label()
      Me.txtIdPrioridadProyecto = New Eniac.Controles.TextBox()
      Me.dtpFechaFinReal = New Eniac.Controles.DateTimePicker()
      Me.txtHsEstimadas = New Eniac.Controles.TextBox()
      Me.lblHsEstimadas = New Eniac.Controles.Label()
      Me.chbFechaFinReal = New System.Windows.Forms.CheckBox()
      Me.txtHsInformadas = New Eniac.Controles.TextBox()
      Me.lblHsInformadas = New Eniac.Controles.Label()
      Me.gbPrioridades.SuspendLayout()
      CType(Me.nudReplicabilidad, System.ComponentModel.ISupportInitialize).BeginInit()
      CType(Me.nudComplejidad, System.ComponentModel.ISupportInitialize).BeginInit()
      CType(Me.nudEstrategico, System.ComponentModel.ISupportInitialize).BeginInit()
      CType(Me.nudImporte, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.SuspendLayout()
      '
      'btnAceptar
      '
      Me.btnAceptar.Location = New System.Drawing.Point(397, 329)
      Me.btnAceptar.Margin = New System.Windows.Forms.Padding(2)
      Me.btnAceptar.TabIndex = 28
      '
      'btnCancelar
      '
      Me.btnCancelar.Location = New System.Drawing.Point(484, 329)
      Me.btnCancelar.Margin = New System.Windows.Forms.Padding(2)
      Me.btnCancelar.TabIndex = 29
      '
      'btnCopiar
      '
      Me.btnCopiar.Location = New System.Drawing.Point(296, 329)
      Me.btnCopiar.Margin = New System.Windows.Forms.Padding(2)
      Me.btnCopiar.TabIndex = 30
      '
      'btnAplicar
      '
      Me.btnAplicar.Location = New System.Drawing.Point(83, 338)
      Me.btnAplicar.TabIndex = 31
      '
      'lblNombre
      '
      Me.lblNombre.AutoSize = True
      Me.lblNombre.LabelAsoc = Nothing
      Me.lblNombre.Location = New System.Drawing.Point(130, 16)
      Me.lblNombre.Name = "lblNombre"
      Me.lblNombre.Size = New System.Drawing.Size(44, 13)
      Me.lblNombre.TabIndex = 2
      Me.lblNombre.Text = "Nombre"
      '
      'txtNombreProyecto
      '
      Me.txtNombreProyecto.BindearPropiedadControl = "Text"
      Me.txtNombreProyecto.BindearPropiedadEntidad = "NombreProyecto"
      Me.txtNombreProyecto.ForeColorFocus = System.Drawing.Color.Red
      Me.txtNombreProyecto.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtNombreProyecto.Formato = ""
      Me.txtNombreProyecto.IsDecimal = False
      Me.txtNombreProyecto.IsNumber = False
      Me.txtNombreProyecto.IsPK = False
      Me.txtNombreProyecto.IsRequired = True
      Me.txtNombreProyecto.Key = ""
      Me.txtNombreProyecto.LabelAsoc = Me.lblNombre
      Me.txtNombreProyecto.Location = New System.Drawing.Point(180, 13)
      Me.txtNombreProyecto.MaxLength = 100
      Me.txtNombreProyecto.Name = "txtNombreProyecto"
      Me.txtNombreProyecto.Size = New System.Drawing.Size(228, 20)
      Me.txtNombreProyecto.TabIndex = 3
      '
      'lblCodigo
      '
      Me.lblCodigo.AutoSize = True
      Me.lblCodigo.LabelAsoc = Nothing
      Me.lblCodigo.Location = New System.Drawing.Point(21, 16)
      Me.lblCodigo.Name = "lblCodigo"
      Me.lblCodigo.Size = New System.Drawing.Size(40, 13)
      Me.lblCodigo.TabIndex = 0
      Me.lblCodigo.Text = "Codigo"
      '
      'txtIdProyecto
      '
      Me.txtIdProyecto.BindearPropiedadControl = "Text"
      Me.txtIdProyecto.BindearPropiedadEntidad = "IdProyecto"
      Me.txtIdProyecto.ForeColorFocus = System.Drawing.Color.Red
      Me.txtIdProyecto.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtIdProyecto.Formato = ""
      Me.txtIdProyecto.IsDecimal = False
      Me.txtIdProyecto.IsNumber = True
      Me.txtIdProyecto.IsPK = True
      Me.txtIdProyecto.IsRequired = True
      Me.txtIdProyecto.Key = ""
      Me.txtIdProyecto.LabelAsoc = Me.lblCodigo
      Me.txtIdProyecto.Location = New System.Drawing.Point(67, 13)
      Me.txtIdProyecto.MaxLength = 10
      Me.txtIdProyecto.Name = "txtIdProyecto"
      Me.txtIdProyecto.Size = New System.Drawing.Size(54, 20)
      Me.txtIdProyecto.TabIndex = 1
      Me.txtIdProyecto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'cmbEstado
      '
      Me.cmbEstado.BindearPropiedadControl = "SelectedValue"
      Me.cmbEstado.BindearPropiedadEntidad = "IdEstado"
      Me.cmbEstado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cmbEstado.ForeColorFocus = System.Drawing.Color.Red
      Me.cmbEstado.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.cmbEstado.FormattingEnabled = True
      Me.cmbEstado.IsPK = False
      Me.cmbEstado.IsRequired = False
      Me.cmbEstado.Key = Nothing
      Me.cmbEstado.LabelAsoc = Me.lblEstado
      Me.cmbEstado.Location = New System.Drawing.Point(67, 43)
      Me.cmbEstado.Name = "cmbEstado"
      Me.cmbEstado.Size = New System.Drawing.Size(86, 21)
      Me.cmbEstado.TabIndex = 5
      '
      'lblEstado
      '
      Me.lblEstado.AutoSize = True
      Me.lblEstado.LabelAsoc = Nothing
      Me.lblEstado.Location = New System.Drawing.Point(21, 46)
      Me.lblEstado.Name = "lblEstado"
      Me.lblEstado.Size = New System.Drawing.Size(40, 13)
      Me.lblEstado.TabIndex = 4
      Me.lblEstado.Text = "Estado"
      '
      'lblCliente
      '
      Me.lblCliente.AutoSize = True
      Me.lblCliente.LabelAsoc = Nothing
      Me.lblCliente.Location = New System.Drawing.Point(159, 157)
      Me.lblCliente.Name = "lblCliente"
      Me.lblCliente.Size = New System.Drawing.Size(44, 13)
      Me.lblCliente.TabIndex = 12
      Me.lblCliente.Text = "&Nombre"
      '
      'bscCliente
      '
      Me.bscCliente.ActivarFiltroEnGrilla = True
      Me.bscCliente.AutoSize = True
      Me.bscCliente.BindearPropiedadControl = "Text"
      Me.bscCliente.BindearPropiedadEntidad = "Cliente.NombreCliente"
      Me.bscCliente.ConfigBuscador = Nothing
      Me.bscCliente.Datos = Nothing
      Me.bscCliente.FilaDevuelta = Nothing
      Me.bscCliente.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.bscCliente.ForeColorFocus = System.Drawing.Color.Red
      Me.bscCliente.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
      Me.bscCliente.IsDecimal = False
      Me.bscCliente.IsNumber = False
      Me.bscCliente.IsPK = False
      Me.bscCliente.IsRequired = True
      Me.bscCliente.Key = ""
      Me.bscCliente.LabelAsoc = Me.lblCliente
      Me.bscCliente.Location = New System.Drawing.Point(162, 172)
      Me.bscCliente.Margin = New System.Windows.Forms.Padding(4)
      Me.bscCliente.MaxLengh = "32767"
      Me.bscCliente.Name = "bscCliente"
      Me.bscCliente.Permitido = True
      Me.bscCliente.PermitidoNoBackColor = System.Drawing.Color.FromArgb(CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer))
      Me.bscCliente.PermitidoNoForeColor = System.Drawing.Color.Black
      Me.bscCliente.PermitidoSiBackColor = System.Drawing.Color.White
      Me.bscCliente.PermitidoSiForeColor = System.Drawing.Color.Black
      Me.bscCliente.Selecciono = False
      Me.bscCliente.Size = New System.Drawing.Size(300, 23)
      Me.bscCliente.TabIndex = 13
      '
      'bscCodigoCliente
      '
      Me.bscCodigoCliente.AyudaAncho = 608
      Me.bscCodigoCliente.BindearPropiedadControl = "Text"
      Me.bscCodigoCliente.BindearPropiedadEntidad = "Cliente.CodigoCliente"
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
      Me.bscCodigoCliente.LabelAsoc = Me.lblCodigoCliente
      Me.bscCodigoCliente.Location = New System.Drawing.Point(68, 172)
      Me.bscCodigoCliente.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
      Me.bscCodigoCliente.MaxLengh = "32767"
      Me.bscCodigoCliente.Name = "bscCodigoCliente"
      Me.bscCodigoCliente.Permitido = True
      Me.bscCodigoCliente.Selecciono = False
      Me.bscCodigoCliente.Size = New System.Drawing.Size(86, 22)
      Me.bscCodigoCliente.TabIndex = 11
      Me.bscCodigoCliente.Titulo = Nothing
      '
      'lblCodigoCliente
      '
      Me.lblCodigoCliente.AutoSize = True
      Me.lblCodigoCliente.LabelAsoc = Nothing
      Me.lblCodigoCliente.Location = New System.Drawing.Point(65, 156)
      Me.lblCodigoCliente.Name = "lblCodigoCliente"
      Me.lblCodigoCliente.Size = New System.Drawing.Size(40, 13)
      Me.lblCodigoCliente.TabIndex = 10
      Me.lblCodigoCliente.Text = "Código"
      '
      'dtpFechaInicio
      '
      Me.dtpFechaInicio.BindearPropiedadControl = "Value"
      Me.dtpFechaInicio.BindearPropiedadEntidad = "FechaInicio"
      Me.dtpFechaInicio.CustomFormat = "dd/MM/yyyy"
      Me.dtpFechaInicio.ForeColorFocus = System.Drawing.Color.Red
      Me.dtpFechaInicio.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.dtpFechaInicio.Format = System.Windows.Forms.DateTimePickerFormat.Custom
      Me.dtpFechaInicio.IsPK = False
      Me.dtpFechaInicio.IsRequired = False
      Me.dtpFechaInicio.Key = ""
      Me.dtpFechaInicio.LabelAsoc = Me.lblFechaInicio
      Me.dtpFechaInicio.Location = New System.Drawing.Point(71, 208)
      Me.dtpFechaInicio.Name = "dtpFechaInicio"
      Me.dtpFechaInicio.Size = New System.Drawing.Size(95, 20)
      Me.dtpFechaInicio.TabIndex = 15
      '
      'lblFechaInicio
      '
      Me.lblFechaInicio.AutoSize = True
      Me.lblFechaInicio.LabelAsoc = Nothing
      Me.lblFechaInicio.Location = New System.Drawing.Point(21, 211)
      Me.lblFechaInicio.Name = "lblFechaInicio"
      Me.lblFechaInicio.Size = New System.Drawing.Size(44, 13)
      Me.lblFechaInicio.TabIndex = 14
      Me.lblFechaInicio.Text = "F. Inicio"
      '
      'dtpFechaFin
      '
      Me.dtpFechaFin.BindearPropiedadControl = "Value"
      Me.dtpFechaFin.BindearPropiedadEntidad = "FechaFin"
      Me.dtpFechaFin.CustomFormat = "dd/MM/yyyy"
      Me.dtpFechaFin.ForeColorFocus = System.Drawing.Color.Red
      Me.dtpFechaFin.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.dtpFechaFin.Format = System.Windows.Forms.DateTimePickerFormat.Custom
      Me.dtpFechaFin.IsPK = False
      Me.dtpFechaFin.IsRequired = False
      Me.dtpFechaFin.Key = ""
      Me.dtpFechaFin.LabelAsoc = Me.lblFechaFin
      Me.dtpFechaFin.Location = New System.Drawing.Point(260, 208)
      Me.dtpFechaFin.Name = "dtpFechaFin"
      Me.dtpFechaFin.Size = New System.Drawing.Size(95, 20)
      Me.dtpFechaFin.TabIndex = 17
      '
      'lblFechaFin
      '
      Me.lblFechaFin.AutoSize = True
      Me.lblFechaFin.LabelAsoc = Nothing
      Me.lblFechaFin.Location = New System.Drawing.Point(176, 211)
      Me.lblFechaFin.Name = "lblFechaFin"
      Me.lblFechaFin.Size = New System.Drawing.Size(79, 13)
      Me.lblFechaFin.TabIndex = 16
      Me.lblFechaFin.Text = "F. Fin Estimada"
      '
      'txtHsCobradas
      '
      Me.txtHsCobradas.Anchor = System.Windows.Forms.AnchorStyles.Top
      Me.txtHsCobradas.BindearPropiedadControl = "Text"
      Me.txtHsCobradas.BindearPropiedadEntidad = "Estimado"
      Me.txtHsCobradas.ForeColorFocus = System.Drawing.Color.Red
      Me.txtHsCobradas.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtHsCobradas.Formato = "##,##0"
      Me.txtHsCobradas.IsDecimal = False
      Me.txtHsCobradas.IsNumber = True
      Me.txtHsCobradas.IsPK = False
      Me.txtHsCobradas.IsRequired = False
      Me.txtHsCobradas.Key = ""
      Me.txtHsCobradas.LabelAsoc = Me.lblHsCobradas
      Me.txtHsCobradas.Location = New System.Drawing.Point(110, 271)
      Me.txtHsCobradas.MaxLength = 5
      Me.txtHsCobradas.Name = "txtHsCobradas"
      Me.txtHsCobradas.Size = New System.Drawing.Size(50, 20)
      Me.txtHsCobradas.TabIndex = 23
      Me.txtHsCobradas.Text = "0"
      Me.txtHsCobradas.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'lblHsCobradas
      '
      Me.lblHsCobradas.AutoSize = True
      Me.lblHsCobradas.LabelAsoc = Nothing
      Me.lblHsCobradas.Location = New System.Drawing.Point(25, 274)
      Me.lblHsCobradas.Name = "lblHsCobradas"
      Me.lblHsCobradas.Size = New System.Drawing.Size(70, 13)
      Me.lblHsCobradas.TabIndex = 22
      Me.lblHsCobradas.Text = "HS Cobradas"
      '
      'txtPresupuestado
      '
      Me.txtPresupuestado.Anchor = System.Windows.Forms.AnchorStyles.Top
      Me.txtPresupuestado.BindearPropiedadControl = "Text"
      Me.txtPresupuestado.BindearPropiedadEntidad = "Presupuestado"
      Me.txtPresupuestado.ForeColorFocus = System.Drawing.Color.Red
      Me.txtPresupuestado.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtPresupuestado.Formato = "##0.00"
      Me.txtPresupuestado.IsDecimal = True
      Me.txtPresupuestado.IsNumber = True
      Me.txtPresupuestado.IsPK = False
      Me.txtPresupuestado.IsRequired = False
      Me.txtPresupuestado.Key = ""
      Me.txtPresupuestado.LabelAsoc = Me.lblPresupuestado
      Me.txtPresupuestado.Location = New System.Drawing.Point(456, 245)
      Me.txtPresupuestado.MaxLength = 14
      Me.txtPresupuestado.Name = "txtPresupuestado"
      Me.txtPresupuestado.Size = New System.Drawing.Size(70, 20)
      Me.txtPresupuestado.TabIndex = 27
      Me.txtPresupuestado.Text = "0.00"
      Me.txtPresupuestado.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'lblPresupuestado
      '
      Me.lblPresupuestado.AutoSize = True
      Me.lblPresupuestado.LabelAsoc = Nothing
      Me.lblPresupuestado.Location = New System.Drawing.Point(332, 248)
      Me.lblPresupuestado.Name = "lblPresupuestado"
      Me.lblPresupuestado.Size = New System.Drawing.Size(116, 13)
      Me.lblPresupuestado.TabIndex = 26
      Me.lblPresupuestado.Text = "Importe Presupuestado"
      '
      'lblPrioridadNovedad
      '
      Me.lblPrioridadNovedad.AutoSize = True
      Me.lblPrioridadNovedad.LabelAsoc = Nothing
      Me.lblPrioridadNovedad.Location = New System.Drawing.Point(409, 24)
      Me.lblPrioridadNovedad.Name = "lblPrioridadNovedad"
      Me.lblPrioridadNovedad.Size = New System.Drawing.Size(110, 13)
      Me.lblPrioridadNovedad.TabIndex = 10
      Me.lblPrioridadNovedad.Text = "Prioridad del Proyecto"
      '
      'Label1
      '
      Me.Label1.AutoSize = True
      Me.Label1.LabelAsoc = Nothing
      Me.Label1.Location = New System.Drawing.Point(177, 46)
      Me.Label1.Name = "Label1"
      Me.Label1.Size = New System.Drawing.Size(66, 13)
      Me.Label1.TabIndex = 6
      Me.Label1.Text = "Clasificación"
      '
      'cmbClasificacion
      '
      Me.cmbClasificacion.BindearPropiedadControl = "SelectedValue"
      Me.cmbClasificacion.BindearPropiedadEntidad = "Clasificacion.IdClasificacion"
      Me.cmbClasificacion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cmbClasificacion.ForeColorFocus = System.Drawing.Color.Red
      Me.cmbClasificacion.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.cmbClasificacion.FormattingEnabled = True
      Me.cmbClasificacion.IsPK = False
      Me.cmbClasificacion.IsRequired = True
      Me.cmbClasificacion.Key = Nothing
      Me.cmbClasificacion.LabelAsoc = Me.Label1
      Me.cmbClasificacion.Location = New System.Drawing.Point(249, 43)
      Me.cmbClasificacion.Name = "cmbClasificacion"
      Me.cmbClasificacion.Size = New System.Drawing.Size(74, 21)
      Me.cmbClasificacion.TabIndex = 7
      '
      'lblClienteVinculado
      '
      Me.lblClienteVinculado.AutoSize = True
      Me.lblClienteVinculado.ImeMode = System.Windows.Forms.ImeMode.NoControl
      Me.lblClienteVinculado.LabelAsoc = Nothing
      Me.lblClienteVinculado.Location = New System.Drawing.Point(22, 175)
      Me.lblClienteVinculado.Name = "lblClienteVinculado"
      Me.lblClienteVinculado.Size = New System.Drawing.Size(39, 13)
      Me.lblClienteVinculado.TabIndex = 9
      Me.lblClienteVinculado.Text = "Cliente"
      '
      'gbPrioridades
      '
      Me.gbPrioridades.Controls.Add(Me.txtPrioridadPromedio)
      Me.gbPrioridades.Controls.Add(Me.lblPrioridadPromedio)
      Me.gbPrioridades.Controls.Add(Me.nudReplicabilidad)
      Me.gbPrioridades.Controls.Add(Me.nudComplejidad)
      Me.gbPrioridades.Controls.Add(Me.nudEstrategico)
      Me.gbPrioridades.Controls.Add(Me.Label4)
      Me.gbPrioridades.Controls.Add(Me.Label5)
      Me.gbPrioridades.Controls.Add(Me.Label3)
      Me.gbPrioridades.Controls.Add(Me.nudImporte)
      Me.gbPrioridades.Controls.Add(Me.Label2)
      Me.gbPrioridades.Controls.Add(Me.txtIdPrioridadProyecto)
      Me.gbPrioridades.Controls.Add(Me.lblPrioridadNovedad)
      Me.gbPrioridades.Location = New System.Drawing.Point(24, 72)
      Me.gbPrioridades.Name = "gbPrioridades"
      Me.gbPrioridades.Size = New System.Drawing.Size(540, 81)
      Me.gbPrioridades.TabIndex = 8
      Me.gbPrioridades.TabStop = False
      Me.gbPrioridades.Text = "Prioridad"
      '
      'txtPrioridadPromedio
      '
      Me.txtPrioridadPromedio.BindearPropiedadControl = ""
      Me.txtPrioridadPromedio.BindearPropiedadEntidad = ""
      Me.txtPrioridadPromedio.ForeColorFocus = System.Drawing.Color.Red
      Me.txtPrioridadPromedio.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtPrioridadPromedio.Formato = ""
      Me.txtPrioridadPromedio.IsDecimal = True
      Me.txtPrioridadPromedio.IsNumber = True
      Me.txtPrioridadPromedio.IsPK = False
      Me.txtPrioridadPromedio.IsRequired = True
      Me.txtPrioridadPromedio.Key = ""
      Me.txtPrioridadPromedio.LabelAsoc = Nothing
      Me.txtPrioridadPromedio.Location = New System.Drawing.Point(329, 40)
      Me.txtPrioridadPromedio.MaxLength = 10
      Me.txtPrioridadPromedio.Name = "txtPrioridadPromedio"
      Me.txtPrioridadPromedio.ReadOnly = True
      Me.txtPrioridadPromedio.Size = New System.Drawing.Size(53, 20)
      Me.txtPrioridadPromedio.TabIndex = 9
      Me.txtPrioridadPromedio.TabStop = False
      Me.txtPrioridadPromedio.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'lblPrioridadPromedio
      '
      Me.lblPrioridadPromedio.AutoSize = True
      Me.lblPrioridadPromedio.LabelAsoc = Nothing
      Me.lblPrioridadPromedio.Location = New System.Drawing.Point(308, 24)
      Me.lblPrioridadPromedio.Name = "lblPrioridadPromedio"
      Me.lblPrioridadPromedio.Size = New System.Drawing.Size(95, 13)
      Me.lblPrioridadPromedio.TabIndex = 8
      Me.lblPrioridadPromedio.Text = "Prioridad Promedio"
      '
      'nudReplicabilidad
      '
      Me.nudReplicabilidad.Location = New System.Drawing.Point(237, 40)
      Me.nudReplicabilidad.Maximum = New Decimal(New Integer() {5, 0, 0, 0})
      Me.nudReplicabilidad.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
      Me.nudReplicabilidad.Name = "nudReplicabilidad"
      Me.nudReplicabilidad.ReadOnly = True
      Me.nudReplicabilidad.Size = New System.Drawing.Size(51, 20)
      Me.nudReplicabilidad.TabIndex = 7
      Me.nudReplicabilidad.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      Me.nudReplicabilidad.Value = New Decimal(New Integer() {1, 0, 0, 0})
      '
      'nudComplejidad
      '
      Me.nudComplejidad.Location = New System.Drawing.Point(164, 40)
      Me.nudComplejidad.Maximum = New Decimal(New Integer() {5, 0, 0, 0})
      Me.nudComplejidad.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
      Me.nudComplejidad.Name = "nudComplejidad"
      Me.nudComplejidad.ReadOnly = True
      Me.nudComplejidad.Size = New System.Drawing.Size(51, 20)
      Me.nudComplejidad.TabIndex = 5
      Me.nudComplejidad.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      Me.nudComplejidad.Value = New Decimal(New Integer() {1, 0, 0, 0})
      '
      'nudEstrategico
      '
      Me.nudEstrategico.Location = New System.Drawing.Point(95, 40)
      Me.nudEstrategico.Maximum = New Decimal(New Integer() {5, 0, 0, 0})
      Me.nudEstrategico.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
      Me.nudEstrategico.Name = "nudEstrategico"
      Me.nudEstrategico.ReadOnly = True
      Me.nudEstrategico.Size = New System.Drawing.Size(51, 20)
      Me.nudEstrategico.TabIndex = 3
      Me.nudEstrategico.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      Me.nudEstrategico.Value = New Decimal(New Integer() {1, 0, 0, 0})
      '
      'Label4
      '
      Me.Label4.AutoSize = True
      Me.Label4.LabelAsoc = Nothing
      Me.Label4.Location = New System.Drawing.Point(161, 24)
      Me.Label4.Name = "Label4"
      Me.Label4.Size = New System.Drawing.Size(64, 13)
      Me.Label4.TabIndex = 4
      Me.Label4.Text = "Complejidad"
      '
      'Label5
      '
      Me.Label5.AutoSize = True
      Me.Label5.LabelAsoc = Nothing
      Me.Label5.Location = New System.Drawing.Point(234, 24)
      Me.Label5.Name = "Label5"
      Me.Label5.Size = New System.Drawing.Size(73, 13)
      Me.Label5.TabIndex = 6
      Me.Label5.Text = "Replicabilidad"
      '
      'Label3
      '
      Me.Label3.AutoSize = True
      Me.Label3.LabelAsoc = Nothing
      Me.Label3.Location = New System.Drawing.Point(26, 24)
      Me.Label3.Name = "Label3"
      Me.Label3.Size = New System.Drawing.Size(42, 13)
      Me.Label3.TabIndex = 0
      Me.Label3.Text = "Importe"
      '
      'nudImporte
      '
      Me.nudImporte.Location = New System.Drawing.Point(29, 40)
      Me.nudImporte.Maximum = New Decimal(New Integer() {5, 0, 0, 0})
      Me.nudImporte.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
      Me.nudImporte.Name = "nudImporte"
      Me.nudImporte.ReadOnly = True
      Me.nudImporte.Size = New System.Drawing.Size(51, 20)
      Me.nudImporte.TabIndex = 1
      Me.nudImporte.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      Me.nudImporte.Value = New Decimal(New Integer() {1, 0, 0, 0})
      '
      'Label2
      '
      Me.Label2.AutoSize = True
      Me.Label2.LabelAsoc = Nothing
      Me.Label2.Location = New System.Drawing.Point(92, 24)
      Me.Label2.Name = "Label2"
      Me.Label2.Size = New System.Drawing.Size(60, 13)
      Me.Label2.TabIndex = 2
      Me.Label2.Text = "Estratégico"
      '
      'txtIdPrioridadProyecto
      '
      Me.txtIdPrioridadProyecto.BindearPropiedadControl = "Text"
      Me.txtIdPrioridadProyecto.BindearPropiedadEntidad = "IdPrioridadProyecto"
      Me.txtIdPrioridadProyecto.ForeColorFocus = System.Drawing.Color.Red
      Me.txtIdPrioridadProyecto.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtIdPrioridadProyecto.Formato = "N2"
      Me.txtIdPrioridadProyecto.IsDecimal = True
      Me.txtIdPrioridadProyecto.IsNumber = True
      Me.txtIdPrioridadProyecto.IsPK = False
      Me.txtIdPrioridadProyecto.IsRequired = True
      Me.txtIdPrioridadProyecto.Key = ""
      Me.txtIdPrioridadProyecto.LabelAsoc = Nothing
      Me.txtIdPrioridadProyecto.Location = New System.Drawing.Point(432, 40)
      Me.txtIdPrioridadProyecto.MaxLength = 10
      Me.txtIdPrioridadProyecto.Name = "txtIdPrioridadProyecto"
      Me.txtIdPrioridadProyecto.Size = New System.Drawing.Size(53, 20)
      Me.txtIdPrioridadProyecto.TabIndex = 11
      Me.txtIdPrioridadProyecto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'dtpFechaFinReal
      '
      Me.dtpFechaFinReal.BindearPropiedadControl = "Value"
      Me.dtpFechaFinReal.BindearPropiedadEntidad = "FechaFinReal"
      Me.dtpFechaFinReal.CustomFormat = "dd/MM/yyyy"
      Me.dtpFechaFinReal.Enabled = False
      Me.dtpFechaFinReal.ForeColorFocus = System.Drawing.Color.Red
      Me.dtpFechaFinReal.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.dtpFechaFinReal.Format = System.Windows.Forms.DateTimePickerFormat.Custom
      Me.dtpFechaFinReal.IsPK = False
      Me.dtpFechaFinReal.IsRequired = False
      Me.dtpFechaFinReal.Key = ""
      Me.dtpFechaFinReal.LabelAsoc = Nothing
      Me.dtpFechaFinReal.Location = New System.Drawing.Point(454, 208)
      Me.dtpFechaFinReal.Name = "dtpFechaFinReal"
      Me.dtpFechaFinReal.Size = New System.Drawing.Size(95, 20)
      Me.dtpFechaFinReal.TabIndex = 19
      '
      'txtHsEstimadas
      '
      Me.txtHsEstimadas.Anchor = System.Windows.Forms.AnchorStyles.Top
      Me.txtHsEstimadas.BindearPropiedadControl = "Text"
      Me.txtHsEstimadas.BindearPropiedadEntidad = "HsRealEstimadas"
      Me.txtHsEstimadas.ForeColorFocus = System.Drawing.Color.Red
      Me.txtHsEstimadas.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtHsEstimadas.Formato = "##,##0"
      Me.txtHsEstimadas.IsDecimal = False
      Me.txtHsEstimadas.IsNumber = True
      Me.txtHsEstimadas.IsPK = False
      Me.txtHsEstimadas.IsRequired = False
      Me.txtHsEstimadas.Key = ""
      Me.txtHsEstimadas.LabelAsoc = Me.lblHsEstimadas
      Me.txtHsEstimadas.Location = New System.Drawing.Point(110, 245)
      Me.txtHsEstimadas.MaxLength = 5
      Me.txtHsEstimadas.Name = "txtHsEstimadas"
      Me.txtHsEstimadas.Size = New System.Drawing.Size(50, 20)
      Me.txtHsEstimadas.TabIndex = 21
      Me.txtHsEstimadas.Text = "0"
      Me.txtHsEstimadas.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'lblHsEstimadas
      '
      Me.lblHsEstimadas.AutoSize = True
      Me.lblHsEstimadas.LabelAsoc = Nothing
      Me.lblHsEstimadas.Location = New System.Drawing.Point(25, 248)
      Me.lblHsEstimadas.Name = "lblHsEstimadas"
      Me.lblHsEstimadas.Size = New System.Drawing.Size(73, 13)
      Me.lblHsEstimadas.TabIndex = 20
      Me.lblHsEstimadas.Text = "HS Estimadas"
      '
      'chbFechaFinReal
      '
      Me.chbFechaFinReal.AutoSize = True
      Me.chbFechaFinReal.Location = New System.Drawing.Point(371, 210)
      Me.chbFechaFinReal.Name = "chbFechaFinReal"
      Me.chbFechaFinReal.Size = New System.Drawing.Size(77, 17)
      Me.chbFechaFinReal.TabIndex = 18
      Me.chbFechaFinReal.Text = "F. Fin Real"
      Me.chbFechaFinReal.UseVisualStyleBackColor = True
      '
      'txtHsInformadas
      '
      Me.txtHsInformadas.Anchor = System.Windows.Forms.AnchorStyles.Top
      Me.txtHsInformadas.BindearPropiedadControl = "Text"
      Me.txtHsInformadas.BindearPropiedadEntidad = "HsInformadas"
      Me.txtHsInformadas.ForeColorFocus = System.Drawing.Color.Red
      Me.txtHsInformadas.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtHsInformadas.Formato = "##,##0"
      Me.txtHsInformadas.IsDecimal = False
      Me.txtHsInformadas.IsNumber = True
      Me.txtHsInformadas.IsPK = False
      Me.txtHsInformadas.IsRequired = False
      Me.txtHsInformadas.Key = ""
      Me.txtHsInformadas.LabelAsoc = Me.lblHsInformadas
      Me.txtHsInformadas.Location = New System.Drawing.Point(110, 300)
      Me.txtHsInformadas.MaxLength = 5
      Me.txtHsInformadas.Name = "txtHsInformadas"
      Me.txtHsInformadas.Size = New System.Drawing.Size(50, 20)
      Me.txtHsInformadas.TabIndex = 25
      Me.txtHsInformadas.Text = "0"
      Me.txtHsInformadas.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'lblHsInformadas
      '
      Me.lblHsInformadas.AutoSize = True
      Me.lblHsInformadas.LabelAsoc = Nothing
      Me.lblHsInformadas.Location = New System.Drawing.Point(25, 303)
      Me.lblHsInformadas.Name = "lblHsInformadas"
      Me.lblHsInformadas.Size = New System.Drawing.Size(77, 13)
      Me.lblHsInformadas.TabIndex = 24
      Me.lblHsInformadas.Text = "HS Informadas"
      '
      'ProyectosDetalle
      '
      Me.AcceptButton = Nothing
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.ClientSize = New System.Drawing.Size(575, 370)
      Me.Controls.Add(Me.txtHsInformadas)
      Me.Controls.Add(Me.lblHsInformadas)
      Me.Controls.Add(Me.chbFechaFinReal)
      Me.Controls.Add(Me.txtHsEstimadas)
      Me.Controls.Add(Me.lblHsEstimadas)
      Me.Controls.Add(Me.dtpFechaFinReal)
      Me.Controls.Add(Me.gbPrioridades)
      Me.Controls.Add(Me.lblClienteVinculado)
      Me.Controls.Add(Me.lblCliente)
      Me.Controls.Add(Me.Label1)
      Me.Controls.Add(Me.bscCodigoCliente)
      Me.Controls.Add(Me.bscCliente)
      Me.Controls.Add(Me.cmbClasificacion)
      Me.Controls.Add(Me.lblCodigoCliente)
      Me.Controls.Add(Me.txtPresupuestado)
      Me.Controls.Add(Me.lblPresupuestado)
      Me.Controls.Add(Me.txtHsCobradas)
      Me.Controls.Add(Me.lblHsCobradas)
      Me.Controls.Add(Me.dtpFechaFin)
      Me.Controls.Add(Me.lblFechaFin)
      Me.Controls.Add(Me.dtpFechaInicio)
      Me.Controls.Add(Me.lblFechaInicio)
      Me.Controls.Add(Me.cmbEstado)
      Me.Controls.Add(Me.lblEstado)
      Me.Controls.Add(Me.lblNombre)
      Me.Controls.Add(Me.txtNombreProyecto)
      Me.Controls.Add(Me.lblCodigo)
      Me.Controls.Add(Me.txtIdProyecto)
      Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
      Me.Margin = New System.Windows.Forms.Padding(2)
      Me.Name = "ProyectosDetalle"
      Me.Text = "Proyecto"
      Me.Controls.SetChildIndex(Me.txtIdProyecto, 0)
      Me.Controls.SetChildIndex(Me.lblCodigo, 0)
      Me.Controls.SetChildIndex(Me.txtNombreProyecto, 0)
      Me.Controls.SetChildIndex(Me.lblNombre, 0)
      Me.Controls.SetChildIndex(Me.lblEstado, 0)
      Me.Controls.SetChildIndex(Me.cmbEstado, 0)
      Me.Controls.SetChildIndex(Me.lblFechaInicio, 0)
      Me.Controls.SetChildIndex(Me.dtpFechaInicio, 0)
      Me.Controls.SetChildIndex(Me.lblFechaFin, 0)
      Me.Controls.SetChildIndex(Me.dtpFechaFin, 0)
      Me.Controls.SetChildIndex(Me.lblHsCobradas, 0)
      Me.Controls.SetChildIndex(Me.txtHsCobradas, 0)
      Me.Controls.SetChildIndex(Me.lblPresupuestado, 0)
      Me.Controls.SetChildIndex(Me.txtPresupuestado, 0)
      Me.Controls.SetChildIndex(Me.lblCodigoCliente, 0)
      Me.Controls.SetChildIndex(Me.cmbClasificacion, 0)
      Me.Controls.SetChildIndex(Me.bscCliente, 0)
      Me.Controls.SetChildIndex(Me.bscCodigoCliente, 0)
      Me.Controls.SetChildIndex(Me.Label1, 0)
      Me.Controls.SetChildIndex(Me.lblCliente, 0)
      Me.Controls.SetChildIndex(Me.lblClienteVinculado, 0)
      Me.Controls.SetChildIndex(Me.gbPrioridades, 0)
      Me.Controls.SetChildIndex(Me.dtpFechaFinReal, 0)
      Me.Controls.SetChildIndex(Me.lblHsEstimadas, 0)
      Me.Controls.SetChildIndex(Me.txtHsEstimadas, 0)
      Me.Controls.SetChildIndex(Me.btnAplicar, 0)
      Me.Controls.SetChildIndex(Me.btnCancelar, 0)
      Me.Controls.SetChildIndex(Me.btnAceptar, 0)
      Me.Controls.SetChildIndex(Me.btnCopiar, 0)
      Me.Controls.SetChildIndex(Me.chbFechaFinReal, 0)
      Me.Controls.SetChildIndex(Me.lblHsInformadas, 0)
      Me.Controls.SetChildIndex(Me.txtHsInformadas, 0)
      Me.gbPrioridades.ResumeLayout(False)
      Me.gbPrioridades.PerformLayout()
      CType(Me.nudReplicabilidad, System.ComponentModel.ISupportInitialize).EndInit()
      CType(Me.nudComplejidad, System.ComponentModel.ISupportInitialize).EndInit()
      CType(Me.nudEstrategico, System.ComponentModel.ISupportInitialize).EndInit()
      CType(Me.nudImporte, System.ComponentModel.ISupportInitialize).EndInit()
      Me.ResumeLayout(False)
      Me.PerformLayout()

   End Sub

   Friend WithEvents lblNombre As Controles.Label
   Friend WithEvents txtNombreProyecto As Controles.TextBox
   Friend WithEvents lblCodigo As Controles.Label
   Friend WithEvents txtIdProyecto As Controles.TextBox
   Friend WithEvents cmbEstado As Controles.ComboBox
   Friend WithEvents lblEstado As Controles.Label
   Friend WithEvents lblCliente As Controles.Label
   Friend WithEvents bscCliente As Eniac.Controles.Buscador2
   Friend WithEvents bscCodigoCliente As Eniac.Controles.Buscador
   Friend WithEvents lblCodigoCliente As Eniac.Controles.Label
   Friend WithEvents dtpFechaInicio As Eniac.Controles.DateTimePicker
   Friend WithEvents lblFechaInicio As Eniac.Controles.Label
   Friend WithEvents dtpFechaFin As Eniac.Controles.DateTimePicker
   Friend WithEvents lblFechaFin As Eniac.Controles.Label
   Friend WithEvents txtHsCobradas As Eniac.Controles.TextBox
   Friend WithEvents lblHsCobradas As Eniac.Controles.Label
   Friend WithEvents txtPresupuestado As Eniac.Controles.TextBox
   Friend WithEvents lblPresupuestado As Eniac.Controles.Label
   Friend WithEvents lblPrioridadNovedad As Eniac.Controles.Label
   Friend WithEvents Label1 As Eniac.Controles.Label
   Friend WithEvents cmbClasificacion As Eniac.Controles.ComboBox
   Friend WithEvents lblClienteVinculado As Eniac.Controles.Label
   Friend WithEvents gbPrioridades As System.Windows.Forms.GroupBox
   Friend WithEvents Label4 As Eniac.Controles.Label
   Friend WithEvents Label5 As Eniac.Controles.Label
   Friend WithEvents Label3 As Eniac.Controles.Label
   Friend WithEvents nudImporte As System.Windows.Forms.NumericUpDown
   Friend WithEvents Label2 As Eniac.Controles.Label
   Friend WithEvents txtIdPrioridadProyecto As Eniac.Controles.TextBox
   Friend WithEvents nudReplicabilidad As System.Windows.Forms.NumericUpDown
   Friend WithEvents nudComplejidad As System.Windows.Forms.NumericUpDown
   Friend WithEvents nudEstrategico As System.Windows.Forms.NumericUpDown
   Friend WithEvents dtpFechaFinReal As Eniac.Controles.DateTimePicker
   Friend WithEvents txtHsEstimadas As Eniac.Controles.TextBox
   Friend WithEvents lblHsEstimadas As Eniac.Controles.Label
   Friend WithEvents chbFechaFinReal As System.Windows.Forms.CheckBox
    Friend WithEvents txtPrioridadPromedio As Controles.TextBox
    Friend WithEvents lblPrioridadPromedio As Controles.Label
    Friend WithEvents txtHsInformadas As Controles.TextBox
    Friend WithEvents lblHsInformadas As Controles.Label
End Class
