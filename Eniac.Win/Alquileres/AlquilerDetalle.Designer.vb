<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class AlquilerDetalle
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(AlquilerDetalle))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.grbDetalle = New System.Windows.Forms.GroupBox()
        Me.bscProducto2 = New Eniac.Controles.Buscador2()
        Me.bscCodigoProducto2 = New Eniac.Controles.Buscador2()
        Me.lblAlquiler = New Eniac.Controles.Label()
        Me.txtImporteAlquiler = New Eniac.Controles.TextBox()
        Me.lblCostoTraslado = New Eniac.Controles.Label()
        Me.txtImporteTraslado = New Eniac.Controles.TextBox()
        Me.lblEstado = New Eniac.Controles.Label()
        Me.txtEstado = New Eniac.Controles.TextBox()
        Me.lblNumeroContrato = New Eniac.Controles.Label()
        Me.txtNumeroContrato = New Eniac.Controles.TextBox()
        Me.dtpFechaContrato = New Eniac.Controles.DateTimePicker()
        Me.lblFechaContrato = New Eniac.Controles.Label()
        Me.dtpFinReal = New Eniac.Controles.DateTimePicker()
        Me.lblreal = New Eniac.Controles.Label()
        Me.dtpHasta = New Eniac.Controles.DateTimePicker()
        Me.lblHasta = New Eniac.Controles.Label()
        Me.dtpDesde = New Eniac.Controles.DateTimePicker()
        Me.lbldesde = New Eniac.Controles.Label()
        Me.chkRenovable = New Eniac.Controles.CheckBox()
        Me.llbCliente = New Eniac.Controles.LinkLabel()
        Me.bscCodigoCliente = New Eniac.Controles.Buscador()
        Me.lblCodigoCliente = New Eniac.Controles.Label()
        Me.bscCliente = New Eniac.Controles.Buscador()
        Me.lblNombre = New Eniac.Controles.Label()
        Me.btnEliminar = New Eniac.Controles.Button()
        Me.btnInsertar = New Eniac.Controles.Button()
        Me.btnLimpiarProducto = New Eniac.Controles.Button()
        Me.lblCodProducto = New Eniac.Controles.Label()
        Me.lblProducto = New Eniac.Controles.Label()
        Me.cmdTarifas = New System.Windows.Forms.Button()
        Me.lblMonto = New Eniac.Controles.Label()
        Me.txtMonto = New Eniac.Controles.TextBox()
        Me.lblCaracteristicas = New Eniac.Controles.Label()
        Me.bscCaractSII = New Eniac.Controles.Buscador()
        Me.lblCliente = New System.Windows.Forms.Label()
        Me.dgvProductos = New Eniac.Controles.DataGridView()
        Me.Ver = New System.Windows.Forms.DataGridViewButtonColumn()
        Me.IdProducto = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.NombreProducto = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.EquipoMarca = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.EquipoModelo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.NumeroSerie = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.caractSII = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Anio = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cmdDisponibles = New System.Windows.Forms.Button()
        Me.lblNumeroSerie = New Eniac.Controles.Label()
        Me.bscNumeroSerie = New Eniac.Controles.Buscador()
        Me.bscmodelo = New Eniac.Controles.Buscador()
        Me.lblCta = New Eniac.Controles.Label()
        Me.grbLocatario = New System.Windows.Forms.GroupBox()
        Me.txtLocatarioCargo = New Eniac.Controles.TextBox()
        Me.lblLocatarioNombre = New Eniac.Controles.Label()
        Me.lblLocatarioCargo = New Eniac.Controles.Label()
        Me.dtpHoraR = New Eniac.Controles.DateTimePicker()
        Me.lblHoraR = New Eniac.Controles.Label()
        Me.dtpHoraE = New Eniac.Controles.DateTimePicker()
        Me.lblHoraE = New Eniac.Controles.Label()
        Me.txtPersonalCapacitado = New Eniac.Controles.TextBox()
        Me.lblPersonal = New Eniac.Controles.Label()
        Me.txtLugarER = New Eniac.Controles.TextBox()
        Me.lblLugarER = New Eniac.Controles.Label()
        Me.txtLocatarioNroDocumento = New Eniac.Controles.TextBox()
        Me.lblDNI = New Eniac.Controles.Label()
        Me.txtLocatarioNombre = New Eniac.Controles.TextBox()
        Me.menucontextual = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.MenuQuitarProducto = New System.Windows.Forms.ToolStripMenuItem()
        Me.grbDetalle.SuspendLayout()
        CType(Me.dgvProductos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grbLocatario.SuspendLayout()
        Me.menucontextual.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnAceptar
        '
        Me.btnAceptar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnAceptar.Location = New System.Drawing.Point(475, 575)
        Me.btnAceptar.Size = New System.Drawing.Size(90, 36)
        Me.btnAceptar.TabIndex = 2
        Me.btnAceptar.Text = "&Guardar"
        '
        'btnCancelar
        '
        Me.btnCancelar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnCancelar.Location = New System.Drawing.Point(574, 576)
        Me.btnCancelar.Size = New System.Drawing.Size(94, 35)
        Me.btnCancelar.TabIndex = 3
        '
        'grbDetalle
        '
        Me.grbDetalle.Controls.Add(Me.bscProducto2)
        Me.grbDetalle.Controls.Add(Me.bscCodigoProducto2)
        Me.grbDetalle.Controls.Add(Me.lblAlquiler)
        Me.grbDetalle.Controls.Add(Me.txtImporteAlquiler)
        Me.grbDetalle.Controls.Add(Me.lblCostoTraslado)
        Me.grbDetalle.Controls.Add(Me.txtImporteTraslado)
        Me.grbDetalle.Controls.Add(Me.lblEstado)
        Me.grbDetalle.Controls.Add(Me.txtEstado)
        Me.grbDetalle.Controls.Add(Me.lblNumeroContrato)
        Me.grbDetalle.Controls.Add(Me.txtNumeroContrato)
        Me.grbDetalle.Controls.Add(Me.dtpFechaContrato)
        Me.grbDetalle.Controls.Add(Me.lblFechaContrato)
        Me.grbDetalle.Controls.Add(Me.dtpFinReal)
        Me.grbDetalle.Controls.Add(Me.lblreal)
        Me.grbDetalle.Controls.Add(Me.dtpHasta)
        Me.grbDetalle.Controls.Add(Me.dtpDesde)
        Me.grbDetalle.Controls.Add(Me.chkRenovable)
        Me.grbDetalle.Controls.Add(Me.lbldesde)
        Me.grbDetalle.Controls.Add(Me.lblHasta)
        Me.grbDetalle.Controls.Add(Me.llbCliente)
        Me.grbDetalle.Controls.Add(Me.bscCodigoCliente)
        Me.grbDetalle.Controls.Add(Me.bscCliente)
        Me.grbDetalle.Controls.Add(Me.lblCodigoCliente)
        Me.grbDetalle.Controls.Add(Me.lblNombre)
        Me.grbDetalle.Controls.Add(Me.btnEliminar)
        Me.grbDetalle.Controls.Add(Me.btnInsertar)
        Me.grbDetalle.Controls.Add(Me.btnLimpiarProducto)
        Me.grbDetalle.Controls.Add(Me.lblCodProducto)
        Me.grbDetalle.Controls.Add(Me.lblProducto)
        Me.grbDetalle.Controls.Add(Me.cmdTarifas)
        Me.grbDetalle.Controls.Add(Me.lblMonto)
        Me.grbDetalle.Controls.Add(Me.txtMonto)
        Me.grbDetalle.Controls.Add(Me.lblCaracteristicas)
        Me.grbDetalle.Controls.Add(Me.bscCaractSII)
        Me.grbDetalle.Controls.Add(Me.lblCliente)
        Me.grbDetalle.Controls.Add(Me.dgvProductos)
        Me.grbDetalle.Controls.Add(Me.cmdDisponibles)
        Me.grbDetalle.Controls.Add(Me.lblNumeroSerie)
        Me.grbDetalle.Controls.Add(Me.bscNumeroSerie)
        Me.grbDetalle.Controls.Add(Me.bscmodelo)
        Me.grbDetalle.Controls.Add(Me.lblCta)
        Me.grbDetalle.Location = New System.Drawing.Point(12, 12)
        Me.grbDetalle.Name = "grbDetalle"
        Me.grbDetalle.Size = New System.Drawing.Size(655, 378)
        Me.grbDetalle.TabIndex = 0
        Me.grbDetalle.TabStop = False
        Me.grbDetalle.Text = "Detalle"
        '
        'bscProducto2
        '
        Me.bscProducto2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.bscProducto2.BindearPropiedadControl = Nothing
        Me.bscProducto2.BindearPropiedadEntidad = Nothing
        Me.bscProducto2.ColumnasVisibles = CType(resources.GetObject("bscProducto2.ColumnasVisibles"), System.Collections.Generic.List(Of Eniac.Controles.ColumnaBuscador))
        Me.bscProducto2.Datos = Nothing
        Me.bscProducto2.FilaDevuelta = Nothing
        Me.bscProducto2.ForeColorFocus = System.Drawing.Color.Red
        Me.bscProducto2.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.bscProducto2.IsDecimal = False
        Me.bscProducto2.IsNumber = False
        Me.bscProducto2.IsPK = False
        Me.bscProducto2.IsRequired = False
        Me.bscProducto2.Key = ""
        Me.bscProducto2.LabelAsoc = Nothing
        Me.bscProducto2.Location = New System.Drawing.Point(197, 139)
        Me.bscProducto2.MaxLengh = "32767"
        Me.bscProducto2.Name = "bscProducto2"
        Me.bscProducto2.Permitido = True
        Me.bscProducto2.Selecciono = False
        Me.bscProducto2.Size = New System.Drawing.Size(306, 20)
        Me.bscProducto2.TabIndex = 48
        '
        'bscCodigoProducto2
        '
        Me.bscCodigoProducto2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.bscCodigoProducto2.BindearPropiedadControl = Nothing
        Me.bscCodigoProducto2.BindearPropiedadEntidad = Nothing
        Me.bscCodigoProducto2.ColumnasVisibles = CType(resources.GetObject("bscCodigoProducto2.ColumnasVisibles"), System.Collections.Generic.List(Of Eniac.Controles.ColumnaBuscador))
        Me.bscCodigoProducto2.Datos = Nothing
        Me.bscCodigoProducto2.FilaDevuelta = Nothing
        Me.bscCodigoProducto2.ForeColorFocus = System.Drawing.Color.Red
        Me.bscCodigoProducto2.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.bscCodigoProducto2.IsDecimal = False
        Me.bscCodigoProducto2.IsNumber = False
        Me.bscCodigoProducto2.IsPK = False
        Me.bscCodigoProducto2.IsRequired = False
        Me.bscCodigoProducto2.Key = ""
        Me.bscCodigoProducto2.LabelAsoc = Nothing
        Me.bscCodigoProducto2.Location = New System.Drawing.Point(43, 138)
        Me.bscCodigoProducto2.MaxLengh = "32767"
        Me.bscCodigoProducto2.Name = "bscCodigoProducto2"
        Me.bscCodigoProducto2.Permitido = True
        Me.bscCodigoProducto2.Selecciono = False
        Me.bscCodigoProducto2.Size = New System.Drawing.Size(146, 20)
        Me.bscCodigoProducto2.TabIndex = 47
        '
        'lblAlquiler
        '
        Me.lblAlquiler.AutoSize = True
        Me.lblAlquiler.Location = New System.Drawing.Point(463, 300)
        Me.lblAlquiler.Name = "lblAlquiler"
        Me.lblAlquiler.Size = New System.Drawing.Size(44, 13)
        Me.lblAlquiler.TabIndex = 41
        Me.lblAlquiler.Text = "Alquiler:"
        '
        'txtImporteAlquiler
        '
        Me.txtImporteAlquiler.BindearPropiedadControl = "Text"
        Me.txtImporteAlquiler.BindearPropiedadEntidad = "ImporteAlquiler"
        Me.txtImporteAlquiler.ForeColorFocus = System.Drawing.Color.Red
        Me.txtImporteAlquiler.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtImporteAlquiler.Formato = "##,##0.00"
        Me.txtImporteAlquiler.IsDecimal = True
        Me.txtImporteAlquiler.IsNumber = True
        Me.txtImporteAlquiler.IsPK = False
        Me.txtImporteAlquiler.IsRequired = False
        Me.txtImporteAlquiler.Key = ""
        Me.txtImporteAlquiler.LabelAsoc = Me.lblAlquiler
        Me.txtImporteAlquiler.Location = New System.Drawing.Point(511, 296)
        Me.txtImporteAlquiler.MaxLength = 8
        Me.txtImporteAlquiler.Name = "txtImporteAlquiler"
        Me.txtImporteAlquiler.Size = New System.Drawing.Size(73, 20)
        Me.txtImporteAlquiler.TabIndex = 19
        Me.txtImporteAlquiler.Text = "0.00"
        Me.txtImporteAlquiler.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblCostoTraslado
        '
        Me.lblCostoTraslado.AutoSize = True
        Me.lblCostoTraslado.Location = New System.Drawing.Point(411, 326)
        Me.lblCostoTraslado.Name = "lblCostoTraslado"
        Me.lblCostoTraslado.Size = New System.Drawing.Size(96, 13)
        Me.lblCostoTraslado.TabIndex = 39
        Me.lblCostoTraslado.Text = "Costo de Traslado:"
        '
        'txtImporteTraslado
        '
        Me.txtImporteTraslado.BindearPropiedadControl = "Text"
        Me.txtImporteTraslado.BindearPropiedadEntidad = "ImporteTraslado"
        Me.txtImporteTraslado.ForeColorFocus = System.Drawing.Color.Red
        Me.txtImporteTraslado.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtImporteTraslado.Formato = "##,##0.00"
        Me.txtImporteTraslado.IsDecimal = True
        Me.txtImporteTraslado.IsNumber = True
        Me.txtImporteTraslado.IsPK = False
        Me.txtImporteTraslado.IsRequired = False
        Me.txtImporteTraslado.Key = ""
        Me.txtImporteTraslado.LabelAsoc = Me.lblCostoTraslado
        Me.txtImporteTraslado.Location = New System.Drawing.Point(511, 322)
        Me.txtImporteTraslado.MaxLength = 8
        Me.txtImporteTraslado.Name = "txtImporteTraslado"
        Me.txtImporteTraslado.Size = New System.Drawing.Size(73, 20)
        Me.txtImporteTraslado.TabIndex = 21
        Me.txtImporteTraslado.Text = "0.00"
        Me.txtImporteTraslado.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblEstado
        '
        Me.lblEstado.AutoSize = True
        Me.lblEstado.Location = New System.Drawing.Point(493, 19)
        Me.lblEstado.Name = "lblEstado"
        Me.lblEstado.Size = New System.Drawing.Size(40, 13)
        Me.lblEstado.TabIndex = 38
        Me.lblEstado.Text = "Estado"
        '
        'txtEstado
        '
        Me.txtEstado.BindearPropiedadControl = ""
        Me.txtEstado.BindearPropiedadEntidad = ""
        Me.txtEstado.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtEstado.ForeColorFocus = System.Drawing.Color.Red
        Me.txtEstado.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtEstado.Formato = ""
        Me.txtEstado.IsDecimal = False
        Me.txtEstado.IsNumber = True
        Me.txtEstado.IsPK = False
        Me.txtEstado.IsRequired = False
        Me.txtEstado.Key = ""
        Me.txtEstado.LabelAsoc = Me.lblEstado
        Me.txtEstado.Location = New System.Drawing.Point(540, 15)
        Me.txtEstado.MaxLength = 8
        Me.txtEstado.Name = "txtEstado"
        Me.txtEstado.ReadOnly = True
        Me.txtEstado.Size = New System.Drawing.Size(96, 20)
        Me.txtEstado.TabIndex = 37
        Me.txtEstado.TabStop = False
        Me.txtEstado.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'lblNumeroContrato
        '
        Me.lblNumeroContrato.AutoSize = True
        Me.lblNumeroContrato.Location = New System.Drawing.Point(20, 19)
        Me.lblNumeroContrato.Name = "lblNumeroContrato"
        Me.lblNumeroContrato.Size = New System.Drawing.Size(44, 13)
        Me.lblNumeroContrato.TabIndex = 1
        Me.lblNumeroContrato.Text = "Numero"
        '
        'txtNumeroContrato
        '
        Me.txtNumeroContrato.BindearPropiedadControl = "Text"
        Me.txtNumeroContrato.BindearPropiedadEntidad = "NumeroContrato"
        Me.txtNumeroContrato.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNumeroContrato.ForeColorFocus = System.Drawing.Color.Red
        Me.txtNumeroContrato.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtNumeroContrato.Formato = ""
        Me.txtNumeroContrato.IsDecimal = False
        Me.txtNumeroContrato.IsNumber = True
        Me.txtNumeroContrato.IsPK = False
        Me.txtNumeroContrato.IsRequired = False
        Me.txtNumeroContrato.Key = ""
        Me.txtNumeroContrato.LabelAsoc = Me.lblNumeroContrato
        Me.txtNumeroContrato.Location = New System.Drawing.Point(67, 15)
        Me.txtNumeroContrato.MaxLength = 8
        Me.txtNumeroContrato.Name = "txtNumeroContrato"
        Me.txtNumeroContrato.ReadOnly = True
        Me.txtNumeroContrato.Size = New System.Drawing.Size(81, 20)
        Me.txtNumeroContrato.TabIndex = 0
        Me.txtNumeroContrato.TabStop = False
        Me.txtNumeroContrato.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'dtpFechaContrato
        '
        Me.dtpFechaContrato.BindearPropiedadControl = "Value"
        Me.dtpFechaContrato.BindearPropiedadEntidad = "FechaContrato"
        Me.dtpFechaContrato.CustomFormat = "dd/MM/yyyy"
        Me.dtpFechaContrato.ForeColorFocus = System.Drawing.Color.Red
        Me.dtpFechaContrato.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.dtpFechaContrato.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFechaContrato.IsPK = False
        Me.dtpFechaContrato.IsRequired = True
        Me.dtpFechaContrato.Key = ""
        Me.dtpFechaContrato.LabelAsoc = Me.lblFechaContrato
        Me.dtpFechaContrato.Location = New System.Drawing.Point(226, 15)
        Me.dtpFechaContrato.Name = "dtpFechaContrato"
        Me.dtpFechaContrato.Size = New System.Drawing.Size(96, 20)
        Me.dtpFechaContrato.TabIndex = 1
        Me.dtpFechaContrato.Value = New Date(2011, 10, 6, 0, 0, 0, 0)
        '
        'lblFechaContrato
        '
        Me.lblFechaContrato.AutoSize = True
        Me.lblFechaContrato.Location = New System.Drawing.Point(176, 19)
        Me.lblFechaContrato.Name = "lblFechaContrato"
        Me.lblFechaContrato.Size = New System.Drawing.Size(47, 13)
        Me.lblFechaContrato.TabIndex = 3
        Me.lblFechaContrato.Text = "Contrato"
        '
        'dtpFinReal
        '
        Me.dtpFinReal.BindearPropiedadControl = "Value"
        Me.dtpFinReal.BindearPropiedadEntidad = "FechaRealFin"
        Me.dtpFinReal.CustomFormat = "dd/MM/yyyy"
        Me.dtpFinReal.ForeColorFocus = System.Drawing.Color.Red
        Me.dtpFinReal.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.dtpFinReal.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFinReal.IsPK = False
        Me.dtpFinReal.IsRequired = True
        Me.dtpFinReal.Key = ""
        Me.dtpFinReal.LabelAsoc = Me.lblreal
        Me.dtpFinReal.Location = New System.Drawing.Point(540, 48)
        Me.dtpFinReal.Name = "dtpFinReal"
        Me.dtpFinReal.Size = New System.Drawing.Size(96, 20)
        Me.dtpFinReal.TabIndex = 5
        Me.dtpFinReal.Value = New Date(2011, 10, 6, 0, 0, 0, 0)
        '
        'lblreal
        '
        Me.lblreal.AutoSize = True
        Me.lblreal.Location = New System.Drawing.Point(446, 52)
        Me.lblreal.Name = "lblreal"
        Me.lblreal.Size = New System.Drawing.Size(90, 13)
        Me.lblreal.TabIndex = 10
        Me.lblreal.Text = "Finalizacion Real:"
        '
        'dtpHasta
        '
        Me.dtpHasta.BindearPropiedadControl = "Value"
        Me.dtpHasta.BindearPropiedadEntidad = "FechaHasta"
        Me.dtpHasta.CustomFormat = "dd/MM/yyyy"
        Me.dtpHasta.ForeColorFocus = System.Drawing.Color.Red
        Me.dtpHasta.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.dtpHasta.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpHasta.IsPK = False
        Me.dtpHasta.IsRequired = True
        Me.dtpHasta.Key = ""
        Me.dtpHasta.LabelAsoc = Me.lblHasta
        Me.dtpHasta.Location = New System.Drawing.Point(226, 48)
        Me.dtpHasta.Name = "dtpHasta"
        Me.dtpHasta.Size = New System.Drawing.Size(96, 20)
        Me.dtpHasta.TabIndex = 3
        Me.dtpHasta.Value = New Date(2011, 10, 6, 0, 0, 0, 0)
        '
        'lblHasta
        '
        Me.lblHasta.AutoSize = True
        Me.lblHasta.Location = New System.Drawing.Point(176, 52)
        Me.lblHasta.Name = "lblHasta"
        Me.lblHasta.Size = New System.Drawing.Size(35, 13)
        Me.lblHasta.TabIndex = 7
        Me.lblHasta.Text = "Hasta"
        '
        'dtpDesde
        '
        Me.dtpDesde.BindearPropiedadControl = "Value"
        Me.dtpDesde.BindearPropiedadEntidad = "FechaDesde"
        Me.dtpDesde.CustomFormat = "dd/MM/yyyy"
        Me.dtpDesde.ForeColorFocus = System.Drawing.Color.Red
        Me.dtpDesde.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.dtpDesde.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpDesde.IsPK = False
        Me.dtpDesde.IsRequired = True
        Me.dtpDesde.Key = ""
        Me.dtpDesde.LabelAsoc = Me.lbldesde
        Me.dtpDesde.Location = New System.Drawing.Point(67, 48)
        Me.dtpDesde.Name = "dtpDesde"
        Me.dtpDesde.Size = New System.Drawing.Size(96, 20)
        Me.dtpDesde.TabIndex = 2
        Me.dtpDesde.Value = New Date(2011, 10, 6, 0, 0, 0, 0)
        '
        'lbldesde
        '
        Me.lbldesde.AutoSize = True
        Me.lbldesde.Location = New System.Drawing.Point(20, 52)
        Me.lbldesde.Name = "lbldesde"
        Me.lbldesde.Size = New System.Drawing.Size(38, 13)
        Me.lbldesde.TabIndex = 5
        Me.lbldesde.Text = "Desde"
        '
        'chkRenovable
        '
        Me.chkRenovable.BindearPropiedadControl = "checked"
        Me.chkRenovable.BindearPropiedadEntidad = "esRenovable"
        Me.chkRenovable.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.chkRenovable.Checked = True
        Me.chkRenovable.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkRenovable.ForeColorFocus = System.Drawing.Color.Red
        Me.chkRenovable.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chkRenovable.IsPK = False
        Me.chkRenovable.IsRequired = False
        Me.chkRenovable.Key = Nothing
        Me.chkRenovable.LabelAsoc = Nothing
        Me.chkRenovable.Location = New System.Drawing.Point(339, 50)
        Me.chkRenovable.Name = "chkRenovable"
        Me.chkRenovable.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.chkRenovable.Size = New System.Drawing.Size(94, 17)
        Me.chkRenovable.TabIndex = 4
        Me.chkRenovable.Text = "Es Renovable"
        Me.chkRenovable.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.chkRenovable.UseVisualStyleBackColor = True
        '
        'llbCliente
        '
        Me.llbCliente.AutoSize = True
        Me.llbCliente.Location = New System.Drawing.Point(197, 76)
        Me.llbCliente.Name = "llbCliente"
        Me.llbCliente.Size = New System.Drawing.Size(55, 13)
        Me.llbCliente.TabIndex = 15
        Me.llbCliente.TabStop = True
        Me.llbCliente.Text = "más info..."
        '
        'bscCodigoCliente
        '
        Me.bscCodigoCliente.AyudaAncho = 140
        Me.bscCodigoCliente.BindearPropiedadControl = "Text"
        Me.bscCodigoCliente.BindearPropiedadEntidad = "NroDocCliente"
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
        Me.bscCodigoCliente.Location = New System.Drawing.Point(53, 90)
        Me.bscCodigoCliente.MaxLengh = "32767"
        Me.bscCodigoCliente.Name = "bscCodigoCliente"
        Me.bscCodigoCliente.Permitido = True
        Me.bscCodigoCliente.Selecciono = False
        Me.bscCodigoCliente.Size = New System.Drawing.Size(90, 20)
        Me.bscCodigoCliente.TabIndex = 7
        Me.bscCodigoCliente.Titulo = Nothing
        '
        'lblCodigoCliente
        '
        Me.lblCodigoCliente.AutoSize = True
        Me.lblCodigoCliente.Location = New System.Drawing.Point(52, 76)
        Me.lblCodigoCliente.Name = "lblCodigoCliente"
        Me.lblCodigoCliente.Size = New System.Drawing.Size(40, 13)
        Me.lblCodigoCliente.TabIndex = 12
        Me.lblCodigoCliente.Text = "Código"
        '
        'bscCliente
        '
        Me.bscCliente.AutoSize = True
        Me.bscCliente.AyudaAncho = 140
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
        Me.bscCliente.LabelAsoc = Me.lblNombre
        Me.bscCliente.Location = New System.Drawing.Point(150, 90)
        Me.bscCliente.Margin = New System.Windows.Forms.Padding(4)
        Me.bscCliente.MaxLengh = "32767"
        Me.bscCliente.Name = "bscCliente"
        Me.bscCliente.Permitido = True
        Me.bscCliente.Selecciono = False
        Me.bscCliente.Size = New System.Drawing.Size(300, 23)
        Me.bscCliente.TabIndex = 8
        Me.bscCliente.Titulo = Nothing
        '
        'lblNombre
        '
        Me.lblNombre.AutoSize = True
        Me.lblNombre.Location = New System.Drawing.Point(147, 76)
        Me.lblNombre.Name = "lblNombre"
        Me.lblNombre.Size = New System.Drawing.Size(44, 13)
        Me.lblNombre.TabIndex = 14
        Me.lblNombre.Text = "Nombre"
        '
        'btnEliminar
        '
        Me.btnEliminar.Image = CType(resources.GetObject("btnEliminar.Image"), System.Drawing.Image)
        Me.btnEliminar.Location = New System.Drawing.Point(613, 186)
        Me.btnEliminar.Name = "btnEliminar"
        Me.btnEliminar.Size = New System.Drawing.Size(37, 37)
        Me.btnEliminar.TabIndex = 16
        Me.btnEliminar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnEliminar.UseVisualStyleBackColor = True
        '
        'btnInsertar
        '
        Me.btnInsertar.Image = CType(resources.GetObject("btnInsertar.Image"), System.Drawing.Image)
        Me.btnInsertar.Location = New System.Drawing.Point(574, 186)
        Me.btnInsertar.Name = "btnInsertar"
        Me.btnInsertar.Size = New System.Drawing.Size(37, 37)
        Me.btnInsertar.TabIndex = 15
        Me.btnInsertar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnInsertar.UseVisualStyleBackColor = True
        '
        'btnLimpiarProducto
        '
        Me.btnLimpiarProducto.Image = Global.Eniac.Win.My.Resources.Resources.refresh_24
        Me.btnLimpiarProducto.Location = New System.Drawing.Point(10, 131)
        Me.btnLimpiarProducto.Name = "btnLimpiarProducto"
        Me.btnLimpiarProducto.Size = New System.Drawing.Size(29, 32)
        Me.btnLimpiarProducto.TabIndex = 9
        Me.btnLimpiarProducto.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnLimpiarProducto.UseVisualStyleBackColor = True
        '
        'lblCodProducto
        '
        Me.lblCodProducto.AutoSize = True
        Me.lblCodProducto.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblCodProducto.Location = New System.Drawing.Point(41, 121)
        Me.lblCodProducto.Name = "lblCodProducto"
        Me.lblCodProducto.Size = New System.Drawing.Size(40, 13)
        Me.lblCodProducto.TabIndex = 20
        Me.lblCodProducto.Text = "Código"
        '
        'lblProducto
        '
        Me.lblProducto.AutoSize = True
        Me.lblProducto.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblProducto.Location = New System.Drawing.Point(170, 120)
        Me.lblProducto.Name = "lblProducto"
        Me.lblProducto.Size = New System.Drawing.Size(50, 13)
        Me.lblProducto.TabIndex = 22
        Me.lblProducto.Text = "Producto"
        '
        'cmdTarifas
        '
        Me.cmdTarifas.Location = New System.Drawing.Point(590, 295)
        Me.cmdTarifas.Name = "cmdTarifas"
        Me.cmdTarifas.Size = New System.Drawing.Size(25, 23)
        Me.cmdTarifas.TabIndex = 20
        Me.cmdTarifas.TabStop = False
        Me.cmdTarifas.Text = "..."
        Me.cmdTarifas.UseVisualStyleBackColor = True
        '
        'lblMonto
        '
        Me.lblMonto.AutoSize = True
        Me.lblMonto.Location = New System.Drawing.Point(473, 352)
        Me.lblMonto.Name = "lblMonto"
        Me.lblMonto.Size = New System.Drawing.Size(34, 13)
        Me.lblMonto.TabIndex = 34
        Me.lblMonto.Text = "Valor:"
        '
        'txtMonto
        '
        Me.txtMonto.BindearPropiedadControl = "Text"
        Me.txtMonto.BindearPropiedadEntidad = "ImporteTotal"
        Me.txtMonto.Enabled = False
        Me.txtMonto.ForeColorFocus = System.Drawing.Color.Red
        Me.txtMonto.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtMonto.Formato = "##,##0.00"
        Me.txtMonto.IsDecimal = True
        Me.txtMonto.IsNumber = True
        Me.txtMonto.IsPK = False
        Me.txtMonto.IsRequired = False
        Me.txtMonto.Key = ""
        Me.txtMonto.LabelAsoc = Me.lblMonto
        Me.txtMonto.Location = New System.Drawing.Point(511, 348)
        Me.txtMonto.MaxLength = 8
        Me.txtMonto.Name = "txtMonto"
        Me.txtMonto.Size = New System.Drawing.Size(73, 20)
        Me.txtMonto.TabIndex = 22
        Me.txtMonto.Text = "0.00"
        Me.txtMonto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblCaracteristicas
        '
        Me.lblCaracteristicas.AutoSize = True
        Me.lblCaracteristicas.Location = New System.Drawing.Point(12, 300)
        Me.lblCaracteristicas.Name = "lblCaracteristicas"
        Me.lblCaracteristicas.Size = New System.Drawing.Size(78, 13)
        Me.lblCaracteristicas.TabIndex = 30
        Me.lblCaracteristicas.Text = "Características"
        Me.lblCaracteristicas.Visible = False
        '
        'bscCaractSII
        '
        Me.bscCaractSII.AyudaAncho = 608
        Me.bscCaractSII.BindearPropiedadControl = Nothing
        Me.bscCaractSII.BindearPropiedadEntidad = Nothing
        Me.bscCaractSII.ColumnasAlineacion = Nothing
        Me.bscCaractSII.ColumnasAncho = Nothing
        Me.bscCaractSII.ColumnasFormato = Nothing
        Me.bscCaractSII.ColumnasOcultas = Nothing
        Me.bscCaractSII.ColumnasTitulos = Nothing
        Me.bscCaractSII.Datos = Nothing
        Me.bscCaractSII.FilaDevuelta = Nothing
        Me.bscCaractSII.ForeColorFocus = System.Drawing.Color.Red
        Me.bscCaractSII.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.bscCaractSII.IsDecimal = False
        Me.bscCaractSII.IsNumber = False
        Me.bscCaractSII.IsPK = False
        Me.bscCaractSII.IsRequired = False
        Me.bscCaractSII.Key = ""
        Me.bscCaractSII.LabelAsoc = Me.lblCaracteristicas
        Me.bscCaractSII.Location = New System.Drawing.Point(94, 296)
        Me.bscCaractSII.MaxLengh = "32767"
        Me.bscCaractSII.Name = "bscCaractSII"
        Me.bscCaractSII.Permitido = True
        Me.bscCaractSII.Selecciono = False
        Me.bscCaractSII.Size = New System.Drawing.Size(350, 20)
        Me.bscCaractSII.TabIndex = 18
        Me.bscCaractSII.Titulo = Nothing
        Me.bscCaractSII.Visible = False
        '
        'lblCliente
        '
        Me.lblCliente.AutoSize = True
        Me.lblCliente.Location = New System.Drawing.Point(8, 95)
        Me.lblCliente.Name = "lblCliente"
        Me.lblCliente.Size = New System.Drawing.Size(39, 13)
        Me.lblCliente.TabIndex = 18
        Me.lblCliente.Text = "Cliente"
        '
        'dgvProductos
        '
        Me.dgvProductos.AllowUserToAddRows = False
        Me.dgvProductos.AllowUserToDeleteRows = False
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvProductos.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvProductos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvProductos.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Ver, Me.IdProducto, Me.NombreProducto, Me.EquipoMarca, Me.EquipoModelo, Me.NumeroSerie, Me.caractSII, Me.Anio})
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvProductos.DefaultCellStyle = DataGridViewCellStyle4
        Me.dgvProductos.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.dgvProductos.Location = New System.Drawing.Point(15, 229)
        Me.dgvProductos.MultiSelect = False
        Me.dgvProductos.Name = "dgvProductos"
        Me.dgvProductos.ReadOnly = True
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvProductos.RowHeadersDefaultCellStyle = DataGridViewCellStyle5
        Me.dgvProductos.RowHeadersVisible = False
        Me.dgvProductos.RowHeadersWidth = 4
        Me.dgvProductos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvProductos.Size = New System.Drawing.Size(634, 61)
        Me.dgvProductos.TabIndex = 17
        '
        'Ver
        '
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Ver.DefaultCellStyle = DataGridViewCellStyle2
        Me.Ver.HeaderText = "Ver"
        Me.Ver.Name = "Ver"
        Me.Ver.ReadOnly = True
        Me.Ver.Text = "..."
        Me.Ver.Visible = False
        Me.Ver.Width = 30
        '
        'IdProducto
        '
        Me.IdProducto.DataPropertyName = "IdProducto"
        Me.IdProducto.HeaderText = "IdProducto"
        Me.IdProducto.Name = "IdProducto"
        Me.IdProducto.ReadOnly = True
        Me.IdProducto.Visible = False
        '
        'NombreProducto
        '
        Me.NombreProducto.DataPropertyName = "NombreProducto"
        Me.NombreProducto.HeaderText = "Descripcion"
        Me.NombreProducto.Name = "NombreProducto"
        Me.NombreProducto.ReadOnly = True
        Me.NombreProducto.Width = 250
        '
        'EquipoMarca
        '
        Me.EquipoMarca.DataPropertyName = "EquipoMarca"
        Me.EquipoMarca.HeaderText = "Marca"
        Me.EquipoMarca.Name = "EquipoMarca"
        Me.EquipoMarca.ReadOnly = True
        Me.EquipoMarca.Width = 150
        '
        'EquipoModelo
        '
        Me.EquipoModelo.DataPropertyName = "EquipoModelo"
        Me.EquipoModelo.HeaderText = "Modelo"
        Me.EquipoModelo.Name = "EquipoModelo"
        Me.EquipoModelo.ReadOnly = True
        Me.EquipoModelo.Width = 150
        '
        'NumeroSerie
        '
        Me.NumeroSerie.DataPropertyName = "NumeroSerie"
        Me.NumeroSerie.HeaderText = "Numero Serie"
        Me.NumeroSerie.Name = "NumeroSerie"
        Me.NumeroSerie.ReadOnly = True
        Me.NumeroSerie.Width = 200
        '
        'caractSII
        '
        Me.caractSII.DataPropertyName = "caractSII"
        Me.caractSII.HeaderText = "Cararcteristicas"
        Me.caractSII.Name = "caractSII"
        Me.caractSII.ReadOnly = True
        Me.caractSII.Visible = False
        Me.caractSII.Width = 350
        '
        'Anio
        '
        Me.Anio.DataPropertyName = "Anio"
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.Anio.DefaultCellStyle = DataGridViewCellStyle3
        Me.Anio.HeaderText = "Año"
        Me.Anio.Name = "Anio"
        Me.Anio.ReadOnly = True
        Me.Anio.Width = 50
        '
        'cmdDisponibles
        '
        Me.cmdDisponibles.Location = New System.Drawing.Point(515, 137)
        Me.cmdDisponibles.Name = "cmdDisponibles"
        Me.cmdDisponibles.Size = New System.Drawing.Size(134, 44)
        Me.cmdDisponibles.TabIndex = 12
        Me.cmdDisponibles.Text = "Productos Disponibles..."
        Me.cmdDisponibles.UseVisualStyleBackColor = True
        '
        'lblNumeroSerie
        '
        Me.lblNumeroSerie.AutoSize = True
        Me.lblNumeroSerie.Location = New System.Drawing.Point(12, 198)
        Me.lblNumeroSerie.Name = "lblNumeroSerie"
        Me.lblNumeroSerie.Size = New System.Drawing.Size(71, 13)
        Me.lblNumeroSerie.TabIndex = 28
        Me.lblNumeroSerie.Text = "Numero Serie"
        '
        'bscNumeroSerie
        '
        Me.bscNumeroSerie.AyudaAncho = 608
        Me.bscNumeroSerie.BindearPropiedadControl = Nothing
        Me.bscNumeroSerie.BindearPropiedadEntidad = Nothing
        Me.bscNumeroSerie.ColumnasAlineacion = Nothing
        Me.bscNumeroSerie.ColumnasAncho = Nothing
        Me.bscNumeroSerie.ColumnasFormato = Nothing
        Me.bscNumeroSerie.ColumnasOcultas = Nothing
        Me.bscNumeroSerie.ColumnasTitulos = Nothing
        Me.bscNumeroSerie.Datos = Nothing
        Me.bscNumeroSerie.FilaDevuelta = Nothing
        Me.bscNumeroSerie.ForeColorFocus = System.Drawing.Color.Red
        Me.bscNumeroSerie.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.bscNumeroSerie.IsDecimal = False
        Me.bscNumeroSerie.IsNumber = False
        Me.bscNumeroSerie.IsPK = False
        Me.bscNumeroSerie.IsRequired = False
        Me.bscNumeroSerie.Key = ""
        Me.bscNumeroSerie.LabelAsoc = Me.lblNumeroSerie
        Me.bscNumeroSerie.Location = New System.Drawing.Point(94, 199)
        Me.bscNumeroSerie.MaxLengh = "32767"
        Me.bscNumeroSerie.Name = "bscNumeroSerie"
        Me.bscNumeroSerie.Permitido = True
        Me.bscNumeroSerie.Selecciono = False
        Me.bscNumeroSerie.Size = New System.Drawing.Size(398, 20)
        Me.bscNumeroSerie.TabIndex = 14
        Me.bscNumeroSerie.Titulo = Nothing
        '
        'bscmodelo
        '
        Me.bscmodelo.AyudaAncho = 608
        Me.bscmodelo.BindearPropiedadControl = Nothing
        Me.bscmodelo.BindearPropiedadEntidad = Nothing
        Me.bscmodelo.ColumnasAlineacion = Nothing
        Me.bscmodelo.ColumnasAncho = Nothing
        Me.bscmodelo.ColumnasFormato = Nothing
        Me.bscmodelo.ColumnasOcultas = Nothing
        Me.bscmodelo.ColumnasTitulos = Nothing
        Me.bscmodelo.Datos = Nothing
        Me.bscmodelo.FilaDevuelta = Nothing
        Me.bscmodelo.ForeColorFocus = System.Drawing.Color.Red
        Me.bscmodelo.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.bscmodelo.IsDecimal = False
        Me.bscmodelo.IsNumber = False
        Me.bscmodelo.IsPK = False
        Me.bscmodelo.IsRequired = False
        Me.bscmodelo.Key = ""
        Me.bscmodelo.LabelAsoc = Me.lblCta
        Me.bscmodelo.Location = New System.Drawing.Point(94, 172)
        Me.bscmodelo.MaxLengh = "32767"
        Me.bscmodelo.Name = "bscmodelo"
        Me.bscmodelo.Permitido = True
        Me.bscmodelo.Selecciono = False
        Me.bscmodelo.Size = New System.Drawing.Size(398, 20)
        Me.bscmodelo.TabIndex = 13
        Me.bscmodelo.Titulo = Nothing
        '
        'lblCta
        '
        Me.lblCta.AutoSize = True
        Me.lblCta.Location = New System.Drawing.Point(12, 172)
        Me.lblCta.Name = "lblCta"
        Me.lblCta.Size = New System.Drawing.Size(42, 13)
        Me.lblCta.TabIndex = 26
        Me.lblCta.Text = "Modelo"
        '
        'grbLocatario
        '
        Me.grbLocatario.Controls.Add(Me.txtLocatarioCargo)
        Me.grbLocatario.Controls.Add(Me.lblLocatarioCargo)
        Me.grbLocatario.Controls.Add(Me.dtpHoraR)
        Me.grbLocatario.Controls.Add(Me.dtpHoraE)
        Me.grbLocatario.Controls.Add(Me.txtPersonalCapacitado)
        Me.grbLocatario.Controls.Add(Me.lblPersonal)
        Me.grbLocatario.Controls.Add(Me.txtLugarER)
        Me.grbLocatario.Controls.Add(Me.txtLocatarioNroDocumento)
        Me.grbLocatario.Controls.Add(Me.lblDNI)
        Me.grbLocatario.Controls.Add(Me.lblLugarER)
        Me.grbLocatario.Controls.Add(Me.lblHoraE)
        Me.grbLocatario.Controls.Add(Me.lblHoraR)
        Me.grbLocatario.Controls.Add(Me.lblLocatarioNombre)
        Me.grbLocatario.Controls.Add(Me.txtLocatarioNombre)
        Me.grbLocatario.Location = New System.Drawing.Point(12, 396)
        Me.grbLocatario.Name = "grbLocatario"
        Me.grbLocatario.Size = New System.Drawing.Size(655, 171)
        Me.grbLocatario.TabIndex = 1
        Me.grbLocatario.TabStop = False
        Me.grbLocatario.Text = "Locatario"
        '
        'txtLocatarioCargo
        '
        Me.txtLocatarioCargo.BindearPropiedadControl = "Text"
        Me.txtLocatarioCargo.BindearPropiedadEntidad = "LocatarioCargo"
        Me.txtLocatarioCargo.ForeColorFocus = System.Drawing.Color.Red
        Me.txtLocatarioCargo.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtLocatarioCargo.Formato = ""
        Me.txtLocatarioCargo.IsDecimal = False
        Me.txtLocatarioCargo.IsNumber = False
        Me.txtLocatarioCargo.IsPK = False
        Me.txtLocatarioCargo.IsRequired = False
        Me.txtLocatarioCargo.Key = ""
        Me.txtLocatarioCargo.LabelAsoc = Me.lblLocatarioNombre
        Me.txtLocatarioCargo.Location = New System.Drawing.Point(124, 49)
        Me.txtLocatarioCargo.MaxLength = 20
        Me.txtLocatarioCargo.Name = "txtLocatarioCargo"
        Me.txtLocatarioCargo.Size = New System.Drawing.Size(200, 20)
        Me.txtLocatarioCargo.TabIndex = 2
        '
        'lblLocatarioNombre
        '
        Me.lblLocatarioNombre.AutoSize = True
        Me.lblLocatarioNombre.Location = New System.Drawing.Point(11, 25)
        Me.lblLocatarioNombre.Name = "lblLocatarioNombre"
        Me.lblLocatarioNombre.Size = New System.Drawing.Size(92, 13)
        Me.lblLocatarioNombre.TabIndex = 1
        Me.lblLocatarioNombre.Text = "Apellido y Nombre"
        '
        'lblLocatarioCargo
        '
        Me.lblLocatarioCargo.AutoSize = True
        Me.lblLocatarioCargo.Location = New System.Drawing.Point(68, 53)
        Me.lblLocatarioCargo.Name = "lblLocatarioCargo"
        Me.lblLocatarioCargo.Size = New System.Drawing.Size(35, 13)
        Me.lblLocatarioCargo.TabIndex = 5
        Me.lblLocatarioCargo.Text = "Cargo"
        '
        'dtpHoraR
        '
        Me.dtpHoraR.BindearPropiedadControl = "Value"
        Me.dtpHoraR.BindearPropiedadEntidad = "HoraR"
        Me.dtpHoraR.CustomFormat = "HH:mm"
        Me.dtpHoraR.ForeColorFocus = System.Drawing.Color.Red
        Me.dtpHoraR.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.dtpHoraR.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpHoraR.IsPK = False
        Me.dtpHoraR.IsRequired = False
        Me.dtpHoraR.Key = ""
        Me.dtpHoraR.LabelAsoc = Me.lblHoraR
        Me.dtpHoraR.Location = New System.Drawing.Point(359, 134)
        Me.dtpHoraR.Name = "dtpHoraR"
        Me.dtpHoraR.Size = New System.Drawing.Size(56, 20)
        Me.dtpHoraR.TabIndex = 6
        Me.dtpHoraR.Value = New Date(2012, 9, 24, 9, 0, 0, 0)
        '
        'lblHoraR
        '
        Me.lblHoraR.AutoSize = True
        Me.lblHoraR.Location = New System.Drawing.Point(292, 138)
        Me.lblHoraR.Name = "lblHoraR"
        Me.lblHoraR.Size = New System.Drawing.Size(61, 13)
        Me.lblHoraR.TabIndex = 13
        Me.lblHoraR.Text = "Hora Retiro"
        '
        'dtpHoraE
        '
        Me.dtpHoraE.BindearPropiedadControl = "Value"
        Me.dtpHoraE.BindearPropiedadEntidad = "HoraE"
        Me.dtpHoraE.CustomFormat = "HH:mm"
        Me.dtpHoraE.ForeColorFocus = System.Drawing.Color.Red
        Me.dtpHoraE.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.dtpHoraE.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpHoraE.IsPK = False
        Me.dtpHoraE.IsRequired = False
        Me.dtpHoraE.Key = ""
        Me.dtpHoraE.LabelAsoc = Me.lblHoraE
        Me.dtpHoraE.Location = New System.Drawing.Point(124, 134)
        Me.dtpHoraE.Name = "dtpHoraE"
        Me.dtpHoraE.Size = New System.Drawing.Size(56, 20)
        Me.dtpHoraE.TabIndex = 5
        Me.dtpHoraE.Value = New Date(2012, 9, 24, 9, 0, 0, 0)
        '
        'lblHoraE
        '
        Me.lblHoraE.AutoSize = True
        Me.lblHoraE.Location = New System.Drawing.Point(11, 138)
        Me.lblHoraE.Name = "lblHoraE"
        Me.lblHoraE.Size = New System.Drawing.Size(70, 13)
        Me.lblHoraE.TabIndex = 11
        Me.lblHoraE.Text = "Hora Entrega"
        '
        'txtPersonalCapacitado
        '
        Me.txtPersonalCapacitado.BindearPropiedadControl = "Text"
        Me.txtPersonalCapacitado.BindearPropiedadEntidad = "PersonalCapacitado"
        Me.txtPersonalCapacitado.ForeColorFocus = System.Drawing.Color.Red
        Me.txtPersonalCapacitado.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtPersonalCapacitado.Formato = ""
        Me.txtPersonalCapacitado.IsDecimal = False
        Me.txtPersonalCapacitado.IsNumber = False
        Me.txtPersonalCapacitado.IsPK = False
        Me.txtPersonalCapacitado.IsRequired = False
        Me.txtPersonalCapacitado.Key = ""
        Me.txtPersonalCapacitado.LabelAsoc = Me.lblPersonal
        Me.txtPersonalCapacitado.Location = New System.Drawing.Point(124, 77)
        Me.txtPersonalCapacitado.MaxLength = 50
        Me.txtPersonalCapacitado.Name = "txtPersonalCapacitado"
        Me.txtPersonalCapacitado.Size = New System.Drawing.Size(463, 20)
        Me.txtPersonalCapacitado.TabIndex = 3
        '
        'lblPersonal
        '
        Me.lblPersonal.AutoSize = True
        Me.lblPersonal.Location = New System.Drawing.Point(11, 81)
        Me.lblPersonal.Name = "lblPersonal"
        Me.lblPersonal.Size = New System.Drawing.Size(105, 13)
        Me.lblPersonal.TabIndex = 7
        Me.lblPersonal.Text = "Personal Capacitado"
        '
        'txtLugarER
        '
        Me.txtLugarER.BindearPropiedadControl = "Text"
        Me.txtLugarER.BindearPropiedadEntidad = "LugarER"
        Me.txtLugarER.ForeColorFocus = System.Drawing.Color.Red
        Me.txtLugarER.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtLugarER.Formato = ""
        Me.txtLugarER.IsDecimal = False
        Me.txtLugarER.IsNumber = False
        Me.txtLugarER.IsPK = False
        Me.txtLugarER.IsRequired = False
        Me.txtLugarER.Key = ""
        Me.txtLugarER.LabelAsoc = Me.lblLugarER
        Me.txtLugarER.Location = New System.Drawing.Point(124, 108)
        Me.txtLugarER.MaxLength = 50
        Me.txtLugarER.Name = "txtLugarER"
        Me.txtLugarER.Size = New System.Drawing.Size(463, 20)
        Me.txtLugarER.TabIndex = 4
        '
        'lblLugarER
        '
        Me.lblLugarER.AutoSize = True
        Me.lblLugarER.Location = New System.Drawing.Point(11, 112)
        Me.lblLugarER.Name = "lblLugarER"
        Me.lblLugarER.Size = New System.Drawing.Size(107, 13)
        Me.lblLugarER.TabIndex = 9
        Me.lblLugarER.Text = "Lugar Entrega/Retiro"
        '
        'txtLocatarioNroDocumento
        '
        Me.txtLocatarioNroDocumento.BindearPropiedadControl = "Text"
        Me.txtLocatarioNroDocumento.BindearPropiedadEntidad = "LocatarioNroDocumento"
        Me.txtLocatarioNroDocumento.ForeColorFocus = System.Drawing.Color.Red
        Me.txtLocatarioNroDocumento.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtLocatarioNroDocumento.Formato = ""
        Me.txtLocatarioNroDocumento.IsDecimal = False
        Me.txtLocatarioNroDocumento.IsNumber = True
        Me.txtLocatarioNroDocumento.IsPK = False
        Me.txtLocatarioNroDocumento.IsRequired = False
        Me.txtLocatarioNroDocumento.Key = ""
        Me.txtLocatarioNroDocumento.LabelAsoc = Me.lblLocatarioNombre
        Me.txtLocatarioNroDocumento.Location = New System.Drawing.Point(511, 19)
        Me.txtLocatarioNroDocumento.MaxLength = 8
        Me.txtLocatarioNroDocumento.Name = "txtLocatarioNroDocumento"
        Me.txtLocatarioNroDocumento.Size = New System.Drawing.Size(100, 20)
        Me.txtLocatarioNroDocumento.TabIndex = 1
        '
        'lblDNI
        '
        Me.lblDNI.AutoSize = True
        Me.lblDNI.Location = New System.Drawing.Point(481, 23)
        Me.lblDNI.Name = "lblDNI"
        Me.lblDNI.Size = New System.Drawing.Size(26, 13)
        Me.lblDNI.TabIndex = 3
        Me.lblDNI.Text = "DNI"
        '
        'txtLocatarioNombre
        '
        Me.txtLocatarioNombre.BindearPropiedadControl = "Text"
        Me.txtLocatarioNombre.BindearPropiedadEntidad = "LocatarioNombre"
        Me.txtLocatarioNombre.ForeColorFocus = System.Drawing.Color.Red
        Me.txtLocatarioNombre.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtLocatarioNombre.Formato = ""
        Me.txtLocatarioNombre.IsDecimal = False
        Me.txtLocatarioNombre.IsNumber = False
        Me.txtLocatarioNombre.IsPK = False
        Me.txtLocatarioNombre.IsRequired = False
        Me.txtLocatarioNombre.Key = ""
        Me.txtLocatarioNombre.LabelAsoc = Me.lblLocatarioNombre
        Me.txtLocatarioNombre.Location = New System.Drawing.Point(124, 21)
        Me.txtLocatarioNombre.MaxLength = 50
        Me.txtLocatarioNombre.Name = "txtLocatarioNombre"
        Me.txtLocatarioNombre.Size = New System.Drawing.Size(350, 20)
        Me.txtLocatarioNombre.TabIndex = 0
        '
        'menucontextual
        '
        Me.menucontextual.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MenuQuitarProducto})
        Me.menucontextual.Name = "menucontextual"
        Me.menucontextual.Size = New System.Drawing.Size(160, 26)
        '
        'MenuQuitarProducto
        '
        Me.MenuQuitarProducto.Name = "MenuQuitarProducto"
        Me.MenuQuitarProducto.Size = New System.Drawing.Size(159, 22)
        Me.MenuQuitarProducto.Text = "Quitar Producto"
        '
        'AlquilerDetalle
        '
        Me.AcceptButton = Nothing
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(677, 617)
        Me.Controls.Add(Me.grbLocatario)
        Me.Controls.Add(Me.grbDetalle)
        Me.Name = "AlquilerDetalle"
        Me.Text = "Alquiler"
        Me.Controls.SetChildIndex(Me.grbDetalle, 0)
        Me.Controls.SetChildIndex(Me.grbLocatario, 0)
        Me.Controls.SetChildIndex(Me.btnCancelar, 0)
        Me.Controls.SetChildIndex(Me.btnAceptar, 0)
        Me.grbDetalle.ResumeLayout(False)
        Me.grbDetalle.PerformLayout()
        CType(Me.dgvProductos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grbLocatario.ResumeLayout(False)
        Me.grbLocatario.PerformLayout()
        Me.menucontextual.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
   Friend WithEvents grbDetalle As System.Windows.Forms.GroupBox
   Friend WithEvents cmdDisponibles As System.Windows.Forms.Button
   Friend WithEvents lblNumeroSerie As Eniac.Controles.Label
   Friend WithEvents bscNumeroSerie As Eniac.Controles.Buscador
   Friend WithEvents bscmodelo As Eniac.Controles.Buscador
   Friend WithEvents lblCta As Eniac.Controles.Label
   Friend WithEvents dgvProductos As Eniac.Controles.DataGridView
   Friend WithEvents grbLocatario As System.Windows.Forms.GroupBox
   Friend WithEvents lblLocatarioNombre As Eniac.Controles.Label
   Friend WithEvents txtLocatarioNombre As Eniac.Controles.TextBox
   Friend WithEvents lblCliente As System.Windows.Forms.Label
   Friend WithEvents lblCaracteristicas As Eniac.Controles.Label
   Friend WithEvents bscCaractSII As Eniac.Controles.Buscador
   Friend WithEvents menucontextual As System.Windows.Forms.ContextMenuStrip
   Friend WithEvents MenuQuitarProducto As System.Windows.Forms.ToolStripMenuItem
   Friend WithEvents txtLocatarioNroDocumento As Eniac.Controles.TextBox
   Friend WithEvents lblDNI As Eniac.Controles.Label
   Friend WithEvents lblLugarER As Eniac.Controles.Label
   Friend WithEvents lblHoraE As Eniac.Controles.Label
   Friend WithEvents lblHoraR As Eniac.Controles.Label
   Friend WithEvents txtLugarER As Eniac.Controles.TextBox
   Friend WithEvents txtPersonalCapacitado As Eniac.Controles.TextBox
   Friend WithEvents lblPersonal As Eniac.Controles.Label
   Friend WithEvents cmdTarifas As System.Windows.Forms.Button
   Friend WithEvents lblMonto As Eniac.Controles.Label
   Friend WithEvents txtMonto As Eniac.Controles.TextBox
   Friend WithEvents btnLimpiarProducto As Eniac.Controles.Button
    Friend WithEvents lblCodProducto As Eniac.Controles.Label
    Friend WithEvents lblProducto As Eniac.Controles.Label
   Friend WithEvents btnEliminar As Eniac.Controles.Button
   Friend WithEvents btnInsertar As Eniac.Controles.Button
   Friend WithEvents llbCliente As Eniac.Controles.LinkLabel
   Friend WithEvents bscCodigoCliente As Eniac.Controles.Buscador
   Friend WithEvents lblCodigoCliente As Eniac.Controles.Label
   Friend WithEvents bscCliente As Eniac.Controles.Buscador
   Friend WithEvents lblNombre As Eniac.Controles.Label
   Friend WithEvents dtpHoraE As Eniac.Controles.DateTimePicker
   Friend WithEvents dtpHoraR As Eniac.Controles.DateTimePicker
   Friend WithEvents txtLocatarioCargo As Eniac.Controles.TextBox
   Friend WithEvents lblLocatarioCargo As Eniac.Controles.Label
   Friend WithEvents lblNumeroContrato As Eniac.Controles.Label
   Friend WithEvents txtNumeroContrato As Eniac.Controles.TextBox
   Friend WithEvents dtpFechaContrato As Eniac.Controles.DateTimePicker
   Friend WithEvents lblFechaContrato As Eniac.Controles.Label
   Friend WithEvents dtpFinReal As Eniac.Controles.DateTimePicker
   Friend WithEvents lblreal As Eniac.Controles.Label
   Friend WithEvents dtpHasta As Eniac.Controles.DateTimePicker
   Friend WithEvents lblHasta As Eniac.Controles.Label
   Friend WithEvents dtpDesde As Eniac.Controles.DateTimePicker
   Friend WithEvents lbldesde As Eniac.Controles.Label
   Friend WithEvents chkRenovable As Eniac.Controles.CheckBox
   Friend WithEvents lblEstado As Eniac.Controles.Label
   Friend WithEvents txtEstado As Eniac.Controles.TextBox
   Friend WithEvents Ver As System.Windows.Forms.DataGridViewButtonColumn
   Friend WithEvents IdProducto As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents NombreProducto As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents EquipoMarca As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents EquipoModelo As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents NumeroSerie As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents caractSII As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents Anio As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents lblAlquiler As Eniac.Controles.Label
   Friend WithEvents txtImporteAlquiler As Eniac.Controles.TextBox
   Friend WithEvents lblCostoTraslado As Eniac.Controles.Label
    Friend WithEvents txtImporteTraslado As Eniac.Controles.TextBox
    Friend WithEvents bscProducto2 As Eniac.Controles.Buscador2
    Friend WithEvents bscCodigoProducto2 As Eniac.Controles.Buscador2
End Class
