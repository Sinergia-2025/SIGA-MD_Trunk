<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MovimientosDeProduccion
   Inherits BaseForm

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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MovimientosDeProduccion))
        Dim Appearance1 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridBand1 As Infragistics.Win.UltraWinGrid.UltraGridBand = New Infragistics.Win.UltraWinGrid.UltraGridBand("Band 0", -1)
        Dim UltraGridColumn1 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdProduccion")
        Dim UltraGridColumn2 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Orden")
        Dim UltraGridColumn3 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdProducto")
        Dim Appearance2 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn4 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreProducto")
        Dim UltraGridColumn5 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdLote")
        Dim UltraGridColumn6 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdFormula")
        Dim UltraGridColumn7 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreFormula")
        Dim UltraGridColumn8 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("VtoLote")
        Dim Appearance3 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn9 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Cantidad")
        Dim Appearance4 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn10 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Usuario")
        Dim UltraGridColumn11 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Password")
        Dim UltraGridColumn12 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdSucursal")
        Dim UltraGridColumn13 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Produccion")
        Dim UltraGridColumn14 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdDeposito", 0)
        Dim UltraGridColumn15 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreDeposito", 1)
        Dim UltraGridColumn16 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdUbicacion", 2)
        Dim UltraGridColumn17 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreUbicacion", 3)
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
        Dim Appearance15 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Me.dtpFechaProduccion = New Eniac.Controles.DateTimePicker()
        Me.lblFecha = New Eniac.Controles.Label()
        Me.txtCantidad = New Eniac.Controles.TextBox()
        Me.btnEliminar = New Eniac.Controles.Button()
        Me.btnInsertar = New Eniac.Controles.Button()
        Me.lblCodProducto = New Eniac.Controles.Label()
        Me.lblProducto = New Eniac.Controles.Label()
        Me.lblUnidadDeMedida = New Eniac.Controles.Label()
        Me.txtTamanio = New Eniac.Controles.TextBox()
        Me.lblTamanio = New Eniac.Controles.Label()
        Me.lblCantidad = New Eniac.Controles.Label()
        Me.btnLimpiarProducto = New Eniac.Controles.Button()
        Me.txtUnidadDeMedida = New System.Windows.Forms.TextBox()
        Me.tstBarra = New System.Windows.Forms.ToolStrip()
        Me.tsbNuevo = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsbGrabar = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsbCerrar = New System.Windows.Forms.ToolStripButton()
        Me.cmbFormulas = New Eniac.Controles.ComboBox()
        Me.lblFormula = New Eniac.Controles.Label()
        Me.cmbResponsable = New Eniac.Controles.ComboBox()
        Me.lblResponsable = New Eniac.Controles.Label()
        Me.bscProducto2 = New Eniac.Controles.Buscador2()
        Me.bscCodigoProducto2 = New Eniac.Controles.Buscador2()
        Me.ugProductos = New Infragistics.Win.UltraWinGrid.UltraGrid()
        Me.lblDepositoOrigen = New Eniac.Controles.Label()
        Me.cmbDepositoOrigen = New Eniac.Controles.ComboBox()
        Me.Label1 = New Eniac.Controles.Label()
        Me.cmbUbicacionOrigen = New Eniac.Controles.ComboBox()
        Me.tstBarra.SuspendLayout()
        CType(Me.ugProductos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'dtpFechaProduccion
        '
        Me.dtpFechaProduccion.BindearPropiedadControl = Nothing
        Me.dtpFechaProduccion.BindearPropiedadEntidad = Nothing
        Me.dtpFechaProduccion.CustomFormat = "dd/MM/yyyy"
        Me.dtpFechaProduccion.ForeColorFocus = System.Drawing.Color.Red
        Me.dtpFechaProduccion.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.dtpFechaProduccion.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpFechaProduccion.IsPK = False
        Me.dtpFechaProduccion.IsRequired = False
        Me.dtpFechaProduccion.Key = ""
        Me.dtpFechaProduccion.LabelAsoc = Me.lblFecha
        Me.dtpFechaProduccion.Location = New System.Drawing.Point(860, 38)
        Me.dtpFechaProduccion.Name = "dtpFechaProduccion"
        Me.dtpFechaProduccion.Size = New System.Drawing.Size(95, 20)
        Me.dtpFechaProduccion.TabIndex = 18
        '
        'lblFecha
        '
        Me.lblFecha.AutoSize = True
        Me.lblFecha.LabelAsoc = Nothing
        Me.lblFecha.Location = New System.Drawing.Point(817, 42)
        Me.lblFecha.Name = "lblFecha"
        Me.lblFecha.Size = New System.Drawing.Size(37, 13)
        Me.lblFecha.TabIndex = 17
        Me.lblFecha.Text = "Fecha"
        '
        'txtCantidad
        '
        Me.txtCantidad.BindearPropiedadControl = Nothing
        Me.txtCantidad.BindearPropiedadEntidad = Nothing
        Me.txtCantidad.ForeColorFocus = System.Drawing.Color.Red
        Me.txtCantidad.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtCantidad.Formato = "#0.00"
        Me.txtCantidad.IsDecimal = True
        Me.txtCantidad.IsNumber = True
        Me.txtCantidad.IsPK = False
        Me.txtCantidad.IsRequired = False
        Me.txtCantidad.Key = ""
        Me.txtCantidad.LabelAsoc = Nothing
        Me.txtCantidad.Location = New System.Drawing.Point(809, 86)
        Me.txtCantidad.MaxLength = 8
        Me.txtCantidad.Name = "txtCantidad"
        Me.txtCantidad.Size = New System.Drawing.Size(62, 20)
        Me.txtCantidad.TabIndex = 11
        Me.txtCantidad.Text = "0.00"
        Me.txtCantidad.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'btnEliminar
        '
        Me.btnEliminar.Image = CType(resources.GetObject("btnEliminar.Image"), System.Drawing.Image)
        Me.btnEliminar.Location = New System.Drawing.Point(918, 69)
        Me.btnEliminar.Name = "btnEliminar"
        Me.btnEliminar.Size = New System.Drawing.Size(37, 37)
        Me.btnEliminar.TabIndex = 13
        Me.btnEliminar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnEliminar.UseVisualStyleBackColor = True
        '
        'btnInsertar
        '
        Me.btnInsertar.Image = CType(resources.GetObject("btnInsertar.Image"), System.Drawing.Image)
        Me.btnInsertar.Location = New System.Drawing.Point(878, 69)
        Me.btnInsertar.Name = "btnInsertar"
        Me.btnInsertar.Size = New System.Drawing.Size(37, 37)
        Me.btnInsertar.TabIndex = 12
        Me.btnInsertar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnInsertar.UseVisualStyleBackColor = True
        '
        'lblCodProducto
        '
        Me.lblCodProducto.AutoSize = True
        Me.lblCodProducto.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblCodProducto.LabelAsoc = Nothing
        Me.lblCodProducto.Location = New System.Drawing.Point(55, 71)
        Me.lblCodProducto.Name = "lblCodProducto"
        Me.lblCodProducto.Size = New System.Drawing.Size(40, 13)
        Me.lblCodProducto.TabIndex = 0
        Me.lblCodProducto.Text = "Código"
        '
        'lblProducto
        '
        Me.lblProducto.AutoSize = True
        Me.lblProducto.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblProducto.LabelAsoc = Nothing
        Me.lblProducto.Location = New System.Drawing.Point(188, 71)
        Me.lblProducto.Name = "lblProducto"
        Me.lblProducto.Size = New System.Drawing.Size(50, 13)
        Me.lblProducto.TabIndex = 2
        Me.lblProducto.Text = "Producto"
        '
        'lblUnidadDeMedida
        '
        Me.lblUnidadDeMedida.AutoSize = True
        Me.lblUnidadDeMedida.LabelAsoc = Nothing
        Me.lblUnidadDeMedida.Location = New System.Drawing.Point(514, 46)
        Me.lblUnidadDeMedida.Name = "lblUnidadDeMedida"
        Me.lblUnidadDeMedida.Size = New System.Drawing.Size(30, 13)
        Me.lblUnidadDeMedida.TabIndex = 6
        Me.lblUnidadDeMedida.Text = "U.M."
        '
        'txtTamanio
        '
        Me.txtTamanio.BindearPropiedadControl = "Text"
        Me.txtTamanio.BindearPropiedadEntidad = "Tamano"
        Me.txtTamanio.ForeColorFocus = System.Drawing.Color.Red
        Me.txtTamanio.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtTamanio.Formato = "#0.000"
        Me.txtTamanio.IsDecimal = True
        Me.txtTamanio.IsNumber = True
        Me.txtTamanio.IsPK = False
        Me.txtTamanio.IsRequired = False
        Me.txtTamanio.Key = ""
        Me.txtTamanio.LabelAsoc = Me.lblTamanio
        Me.txtTamanio.Location = New System.Drawing.Point(435, 62)
        Me.txtTamanio.MaxLength = 7
        Me.txtTamanio.Name = "txtTamanio"
        Me.txtTamanio.ReadOnly = True
        Me.txtTamanio.Size = New System.Drawing.Size(64, 20)
        Me.txtTamanio.TabIndex = 5
        Me.txtTamanio.TabStop = False
        Me.txtTamanio.Text = "0.000"
        Me.txtTamanio.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblTamanio
        '
        Me.lblTamanio.AutoSize = True
        Me.lblTamanio.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblTamanio.LabelAsoc = Nothing
        Me.lblTamanio.Location = New System.Drawing.Point(449, 46)
        Me.lblTamanio.Name = "lblTamanio"
        Me.lblTamanio.Size = New System.Drawing.Size(46, 13)
        Me.lblTamanio.TabIndex = 4
        Me.lblTamanio.Text = "Tamaño"
        '
        'lblCantidad
        '
        Me.lblCantidad.AutoSize = True
        Me.lblCantidad.LabelAsoc = Nothing
        Me.lblCantidad.Location = New System.Drawing.Point(814, 68)
        Me.lblCantidad.Name = "lblCantidad"
        Me.lblCantidad.Size = New System.Drawing.Size(49, 13)
        Me.lblCantidad.TabIndex = 10
        Me.lblCantidad.Text = "Cantidad"
        '
        'btnLimpiarProducto
        '
        Me.btnLimpiarProducto.Image = Global.Eniac.Win.My.Resources.Resources.refresh_32
        Me.btnLimpiarProducto.Location = New System.Drawing.Point(16, 69)
        Me.btnLimpiarProducto.Name = "btnLimpiarProducto"
        Me.btnLimpiarProducto.Size = New System.Drawing.Size(37, 37)
        Me.btnLimpiarProducto.TabIndex = 14
        Me.btnLimpiarProducto.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnLimpiarProducto.UseVisualStyleBackColor = True
        '
        'txtUnidadDeMedida
        '
        Me.txtUnidadDeMedida.Enabled = False
        Me.txtUnidadDeMedida.Location = New System.Drawing.Point(505, 62)
        Me.txtUnidadDeMedida.Name = "txtUnidadDeMedida"
        Me.txtUnidadDeMedida.ReadOnly = True
        Me.txtUnidadDeMedida.Size = New System.Drawing.Size(42, 20)
        Me.txtUnidadDeMedida.TabIndex = 7
        Me.txtUnidadDeMedida.TabStop = False
        '
        'tstBarra
        '
        Me.tstBarra.AllowItemReorder = True
        Me.tstBarra.ImageScalingSize = New System.Drawing.Size(22, 22)
        Me.tstBarra.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsbNuevo, Me.ToolStripSeparator3, Me.tsbGrabar, Me.ToolStripSeparator4, Me.tsbCerrar})
        Me.tstBarra.Location = New System.Drawing.Point(0, 0)
        Me.tstBarra.Name = "tstBarra"
        Me.tstBarra.Size = New System.Drawing.Size(974, 29)
        Me.tstBarra.TabIndex = 24
        Me.tstBarra.Text = "toolStrip1"
        '
        'tsbNuevo
        '
        Me.tsbNuevo.Image = Global.Eniac.Win.My.Resources.Resources.refresh_32
        Me.tsbNuevo.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbNuevo.Name = "tsbNuevo"
        Me.tsbNuevo.Size = New System.Drawing.Size(91, 26)
        Me.tsbNuevo.Text = "&Nuevo (F5)"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(6, 29)
        '
        'tsbGrabar
        '
        Me.tsbGrabar.Image = CType(resources.GetObject("tsbGrabar.Image"), System.Drawing.Image)
        Me.tsbGrabar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbGrabar.Name = "tsbGrabar"
        Me.tsbGrabar.Size = New System.Drawing.Size(91, 26)
        Me.tsbGrabar.Text = "&Grabar (F4)"
        '
        'ToolStripSeparator4
        '
        Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
        Me.ToolStripSeparator4.Size = New System.Drawing.Size(6, 29)
        '
        'tsbCerrar
        '
        Me.tsbCerrar.Image = CType(resources.GetObject("tsbCerrar.Image"), System.Drawing.Image)
        Me.tsbCerrar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbCerrar.Name = "tsbCerrar"
        Me.tsbCerrar.Size = New System.Drawing.Size(65, 26)
        Me.tsbCerrar.Text = "&Cerrar"
        Me.tsbCerrar.ToolTipText = "Cerrar el formulario"
        '
        'cmbFormulas
        '
        Me.cmbFormulas.BindearPropiedadControl = Nothing
        Me.cmbFormulas.BindearPropiedadEntidad = Nothing
        Me.cmbFormulas.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbFormulas.Enabled = False
        Me.cmbFormulas.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbFormulas.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbFormulas.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbFormulas.FormattingEnabled = True
        Me.cmbFormulas.IsPK = False
        Me.cmbFormulas.IsRequired = False
        Me.cmbFormulas.Key = Nothing
        Me.cmbFormulas.LabelAsoc = Me.lblFormula
        Me.cmbFormulas.Location = New System.Drawing.Point(580, 85)
        Me.cmbFormulas.Name = "cmbFormulas"
        Me.cmbFormulas.Size = New System.Drawing.Size(223, 21)
        Me.cmbFormulas.TabIndex = 9
        Me.cmbFormulas.TabStop = False
        '
        'lblFormula
        '
        Me.lblFormula.AutoSize = True
        Me.lblFormula.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblFormula.LabelAsoc = Nothing
        Me.lblFormula.Location = New System.Drawing.Point(580, 68)
        Me.lblFormula.Name = "lblFormula"
        Me.lblFormula.Size = New System.Drawing.Size(44, 13)
        Me.lblFormula.TabIndex = 8
        Me.lblFormula.Text = "Fórmula"
        '
        'cmbResponsable
        '
        Me.cmbResponsable.BindearPropiedadControl = Nothing
        Me.cmbResponsable.BindearPropiedadEntidad = Nothing
        Me.cmbResponsable.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbResponsable.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbResponsable.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbResponsable.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbResponsable.FormattingEnabled = True
        Me.cmbResponsable.IsPK = False
        Me.cmbResponsable.IsRequired = False
        Me.cmbResponsable.Key = Nothing
        Me.cmbResponsable.LabelAsoc = Me.lblResponsable
        Me.cmbResponsable.Location = New System.Drawing.Point(69, 38)
        Me.cmbResponsable.Name = "cmbResponsable"
        Me.cmbResponsable.Size = New System.Drawing.Size(171, 21)
        Me.cmbResponsable.TabIndex = 16
        '
        'lblResponsable
        '
        Me.lblResponsable.AutoSize = True
        Me.lblResponsable.LabelAsoc = Nothing
        Me.lblResponsable.Location = New System.Drawing.Point(16, 42)
        Me.lblResponsable.Name = "lblResponsable"
        Me.lblResponsable.Size = New System.Drawing.Size(47, 13)
        Me.lblResponsable.TabIndex = 15
        Me.lblResponsable.Text = "Operario"
        '
        'bscProducto2
        '
        Me.bscProducto2.ActivarFiltroEnGrilla = True
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
        Me.bscProducto2.IsRequired = False
        Me.bscProducto2.Key = ""
        Me.bscProducto2.LabelAsoc = Nothing
        Me.bscProducto2.Location = New System.Drawing.Point(191, 87)
        Me.bscProducto2.MaxLengh = "32767"
        Me.bscProducto2.Name = "bscProducto2"
        Me.bscProducto2.Permitido = True
        Me.bscProducto2.PermitidoNoBackColor = System.Drawing.Color.FromArgb(CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer))
        Me.bscProducto2.PermitidoNoForeColor = System.Drawing.Color.Black
        Me.bscProducto2.PermitidoSiBackColor = System.Drawing.Color.White
        Me.bscProducto2.PermitidoSiForeColor = System.Drawing.Color.Black
        Me.bscProducto2.Selecciono = False
        Me.bscProducto2.Size = New System.Drawing.Size(383, 20)
        Me.bscProducto2.TabIndex = 3
        '
        'bscCodigoProducto2
        '
        Me.bscCodigoProducto2.ActivarFiltroEnGrilla = True
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
        Me.bscCodigoProducto2.IsRequired = False
        Me.bscCodigoProducto2.Key = ""
        Me.bscCodigoProducto2.LabelAsoc = Nothing
        Me.bscCodigoProducto2.Location = New System.Drawing.Point(60, 86)
        Me.bscCodigoProducto2.MaxLengh = "32767"
        Me.bscCodigoProducto2.Name = "bscCodigoProducto2"
        Me.bscCodigoProducto2.Permitido = True
        Me.bscCodigoProducto2.PermitidoNoBackColor = System.Drawing.Color.FromArgb(CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer))
        Me.bscCodigoProducto2.PermitidoNoForeColor = System.Drawing.Color.Black
        Me.bscCodigoProducto2.PermitidoSiBackColor = System.Drawing.Color.White
        Me.bscCodigoProducto2.PermitidoSiForeColor = System.Drawing.Color.Black
        Me.bscCodigoProducto2.Selecciono = False
        Me.bscCodigoProducto2.Size = New System.Drawing.Size(129, 20)
        Me.bscCodigoProducto2.TabIndex = 1
        '
        'ugProductos
        '
        Me.ugProductos.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Appearance1.BackColor = System.Drawing.SystemColors.Window
        Appearance1.BorderColor = System.Drawing.SystemColors.InactiveCaption
        Me.ugProductos.DisplayLayout.Appearance = Appearance1
        UltraGridColumn1.Header.VisiblePosition = 0
        UltraGridColumn1.Hidden = True
        UltraGridColumn2.Header.VisiblePosition = 1
        UltraGridColumn2.Hidden = True
        Appearance2.TextHAlignAsString = "Right"
        UltraGridColumn3.CellAppearance = Appearance2
        UltraGridColumn3.Header.Caption = "Código"
        UltraGridColumn3.Header.VisiblePosition = 2
        UltraGridColumn3.Width = 100
        UltraGridColumn4.Header.Caption = "Descripción"
        UltraGridColumn4.Header.VisiblePosition = 3
        UltraGridColumn4.Width = 258
        UltraGridColumn5.Header.Caption = "Lote"
        UltraGridColumn5.Header.VisiblePosition = 6
        UltraGridColumn5.Width = 100
        UltraGridColumn6.Header.Caption = "Fórmula"
        UltraGridColumn6.Header.VisiblePosition = 7
        UltraGridColumn6.Hidden = True
        UltraGridColumn7.Header.Caption = "Fórmula"
        UltraGridColumn7.Header.VisiblePosition = 8
        UltraGridColumn7.Width = 177
        Appearance3.TextHAlignAsString = "Center"
        UltraGridColumn8.CellAppearance = Appearance3
        UltraGridColumn8.Format = "dd/MM/yyyy"
        UltraGridColumn8.Header.Caption = "Vencimiento"
        UltraGridColumn8.Header.VisiblePosition = 9
        UltraGridColumn8.Width = 100
        Appearance4.TextHAlignAsString = "Right"
        UltraGridColumn9.CellAppearance = Appearance4
        UltraGridColumn9.Format = "N2"
        UltraGridColumn9.Header.VisiblePosition = 10
        UltraGridColumn9.Width = 65
        UltraGridColumn10.Header.VisiblePosition = 11
        UltraGridColumn10.Hidden = True
        UltraGridColumn11.Header.VisiblePosition = 12
        UltraGridColumn11.Hidden = True
        UltraGridColumn12.Header.VisiblePosition = 13
        UltraGridColumn12.Hidden = True
        UltraGridColumn13.Header.VisiblePosition = 14
        UltraGridColumn13.Hidden = True
        UltraGridColumn14.Header.VisiblePosition = 15
        UltraGridColumn14.Hidden = True
        UltraGridColumn15.Header.Caption = "Deposito"
        UltraGridColumn15.Header.VisiblePosition = 4
        UltraGridColumn16.Header.VisiblePosition = 16
        UltraGridColumn16.Hidden = True
        UltraGridColumn17.Header.Caption = "Ubicacion"
        UltraGridColumn17.Header.VisiblePosition = 5
        UltraGridBand1.Columns.AddRange(New Object() {UltraGridColumn1, UltraGridColumn2, UltraGridColumn3, UltraGridColumn4, UltraGridColumn5, UltraGridColumn6, UltraGridColumn7, UltraGridColumn8, UltraGridColumn9, UltraGridColumn10, UltraGridColumn11, UltraGridColumn12, UltraGridColumn13, UltraGridColumn14, UltraGridColumn15, UltraGridColumn16, UltraGridColumn17})
        Me.ugProductos.DisplayLayout.BandsSerializer.Add(UltraGridBand1)
        Me.ugProductos.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.ugProductos.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.[False]
        Appearance5.BackColor = System.Drawing.SystemColors.ActiveBorder
        Appearance5.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance5.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Appearance5.BorderColor = System.Drawing.SystemColors.Window
        Me.ugProductos.DisplayLayout.GroupByBox.Appearance = Appearance5
        Appearance6.ForeColor = System.Drawing.SystemColors.GrayText
        Me.ugProductos.DisplayLayout.GroupByBox.BandLabelAppearance = Appearance6
        Me.ugProductos.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Appearance7.BackColor = System.Drawing.SystemColors.ControlLightLight
        Appearance7.BackColor2 = System.Drawing.SystemColors.Control
        Appearance7.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance7.ForeColor = System.Drawing.SystemColors.GrayText
        Me.ugProductos.DisplayLayout.GroupByBox.PromptAppearance = Appearance7
        Me.ugProductos.DisplayLayout.MaxBandDepth = 1
        Me.ugProductos.DisplayLayout.MaxColScrollRegions = 1
        Me.ugProductos.DisplayLayout.MaxRowScrollRegions = 1
        Appearance8.BackColor = System.Drawing.SystemColors.Window
        Appearance8.ForeColor = System.Drawing.SystemColors.ControlText
        Me.ugProductos.DisplayLayout.Override.ActiveCellAppearance = Appearance8
        Appearance9.BackColor = System.Drawing.SystemColors.Highlight
        Appearance9.ForeColor = System.Drawing.SystemColors.HighlightText
        Me.ugProductos.DisplayLayout.Override.ActiveRowAppearance = Appearance9
        Me.ugProductos.DisplayLayout.Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.No
        Me.ugProductos.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.[False]
        Me.ugProductos.DisplayLayout.Override.AllowUpdate = Infragistics.Win.DefaultableBoolean.[False]
        Me.ugProductos.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted
        Me.ugProductos.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted
        Appearance10.BackColor = System.Drawing.SystemColors.Window
        Me.ugProductos.DisplayLayout.Override.CardAreaAppearance = Appearance10
        Appearance11.BorderColor = System.Drawing.Color.Silver
        Appearance11.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter
        Me.ugProductos.DisplayLayout.Override.CellAppearance = Appearance11
        Me.ugProductos.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText
        Me.ugProductos.DisplayLayout.Override.CellPadding = 0
        Appearance12.BackColor = System.Drawing.SystemColors.Control
        Appearance12.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance12.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element
        Appearance12.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance12.BorderColor = System.Drawing.SystemColors.Window
        Me.ugProductos.DisplayLayout.Override.GroupByRowAppearance = Appearance12
        Appearance13.TextHAlignAsString = "Left"
        Me.ugProductos.DisplayLayout.Override.HeaderAppearance = Appearance13
        Me.ugProductos.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
        Me.ugProductos.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand
        Appearance14.BackColor = System.Drawing.SystemColors.Window
        Appearance14.BorderColor = System.Drawing.Color.Silver
        Me.ugProductos.DisplayLayout.Override.RowAppearance = Appearance14
        Me.ugProductos.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[False]
        Appearance15.BackColor = System.Drawing.SystemColors.ControlLight
        Me.ugProductos.DisplayLayout.Override.TemplateAddRowAppearance = Appearance15
        Me.ugProductos.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill
        Me.ugProductos.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate
        Me.ugProductos.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy
        Me.ugProductos.Location = New System.Drawing.Point(16, 139)
        Me.ugProductos.Name = "ugProductos"
        Me.ugProductos.Size = New System.Drawing.Size(939, 360)
        Me.ugProductos.TabIndex = 25
        Me.ugProductos.Text = "UltraGrid1"
        '
        'lblDepositoOrigen
        '
        Me.lblDepositoOrigen.AutoSize = True
        Me.lblDepositoOrigen.LabelAsoc = Nothing
        Me.lblDepositoOrigen.Location = New System.Drawing.Point(57, 116)
        Me.lblDepositoOrigen.Name = "lblDepositoOrigen"
        Me.lblDepositoOrigen.Size = New System.Drawing.Size(49, 13)
        Me.lblDepositoOrigen.TabIndex = 41
        Me.lblDepositoOrigen.Text = "Depósito"
        '
        'cmbDepositoOrigen
        '
        Me.cmbDepositoOrigen.BindearPropiedadControl = Nothing
        Me.cmbDepositoOrigen.BindearPropiedadEntidad = Nothing
        Me.cmbDepositoOrigen.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbDepositoOrigen.Enabled = False
        Me.cmbDepositoOrigen.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbDepositoOrigen.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbDepositoOrigen.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbDepositoOrigen.FormattingEnabled = True
        Me.cmbDepositoOrigen.IsPK = False
        Me.cmbDepositoOrigen.IsRequired = False
        Me.cmbDepositoOrigen.Key = Nothing
        Me.cmbDepositoOrigen.LabelAsoc = Me.lblDepositoOrigen
        Me.cmbDepositoOrigen.Location = New System.Drawing.Point(112, 112)
        Me.cmbDepositoOrigen.Name = "cmbDepositoOrigen"
        Me.cmbDepositoOrigen.Size = New System.Drawing.Size(186, 21)
        Me.cmbDepositoOrigen.TabIndex = 40
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.LabelAsoc = Nothing
        Me.Label1.Location = New System.Drawing.Point(307, 115)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(55, 13)
        Me.Label1.TabIndex = 43
        Me.Label1.Text = "Ubicacion"
        '
        'cmbUbicacionOrigen
        '
        Me.cmbUbicacionOrigen.BindearPropiedadControl = Nothing
        Me.cmbUbicacionOrigen.BindearPropiedadEntidad = Nothing
        Me.cmbUbicacionOrigen.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbUbicacionOrigen.Enabled = False
        Me.cmbUbicacionOrigen.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbUbicacionOrigen.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbUbicacionOrigen.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbUbicacionOrigen.FormattingEnabled = True
        Me.cmbUbicacionOrigen.IsPK = False
        Me.cmbUbicacionOrigen.IsRequired = False
        Me.cmbUbicacionOrigen.Key = Nothing
        Me.cmbUbicacionOrigen.LabelAsoc = Me.Label1
        Me.cmbUbicacionOrigen.Location = New System.Drawing.Point(368, 112)
        Me.cmbUbicacionOrigen.Name = "cmbUbicacionOrigen"
        Me.cmbUbicacionOrigen.Size = New System.Drawing.Size(206, 21)
        Me.cmbUbicacionOrigen.TabIndex = 42
        '
        'MovimientosDeProduccion
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(974, 511)
        Me.Controls.Add(Me.lblDepositoOrigen)
        Me.Controls.Add(Me.cmbDepositoOrigen)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.cmbUbicacionOrigen)
        Me.Controls.Add(Me.ugProductos)
        Me.Controls.Add(Me.bscProducto2)
        Me.Controls.Add(Me.bscCodigoProducto2)
        Me.Controls.Add(Me.cmbResponsable)
        Me.Controls.Add(Me.lblResponsable)
        Me.Controls.Add(Me.lblFormula)
        Me.Controls.Add(Me.cmbFormulas)
        Me.Controls.Add(Me.tstBarra)
        Me.Controls.Add(Me.txtUnidadDeMedida)
        Me.Controls.Add(Me.btnLimpiarProducto)
        Me.Controls.Add(Me.txtTamanio)
        Me.Controls.Add(Me.lblTamanio)
        Me.Controls.Add(Me.lblUnidadDeMedida)
        Me.Controls.Add(Me.lblCodProducto)
        Me.Controls.Add(Me.lblCantidad)
        Me.Controls.Add(Me.lblProducto)
        Me.Controls.Add(Me.txtCantidad)
        Me.Controls.Add(Me.btnEliminar)
        Me.Controls.Add(Me.btnInsertar)
        Me.Controls.Add(Me.lblFecha)
        Me.Controls.Add(Me.dtpFechaProduccion)
        Me.KeyPreview = True
        Me.Name = "MovimientosDeProduccion"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Movimientos de Producción"
        Me.tstBarra.ResumeLayout(False)
        Me.tstBarra.PerformLayout()
        CType(Me.ugProductos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents dtpFechaProduccion As Eniac.Controles.DateTimePicker
   Friend WithEvents lblFecha As Eniac.Controles.Label
   Friend WithEvents txtCantidad As Eniac.Controles.TextBox
    Friend WithEvents btnEliminar As Eniac.Controles.Button
    Friend WithEvents btnInsertar As Eniac.Controles.Button
    Friend WithEvents lblCodProducto As Eniac.Controles.Label
    Friend WithEvents lblProducto As Eniac.Controles.Label
    Friend WithEvents lblUnidadDeMedida As Eniac.Controles.Label
    Friend WithEvents txtTamanio As Eniac.Controles.TextBox
    Friend WithEvents lblTamanio As Eniac.Controles.Label
    Friend WithEvents lblCantidad As Eniac.Controles.Label
    Friend WithEvents btnLimpiarProducto As Eniac.Controles.Button
    Friend WithEvents txtUnidadDeMedida As System.Windows.Forms.TextBox
    Public WithEvents tstBarra As System.Windows.Forms.ToolStrip
    Public WithEvents tsbNuevo As System.Windows.Forms.ToolStripButton
    Private WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents tsbGrabar As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator4 As System.Windows.Forms.ToolStripSeparator
    Public WithEvents tsbCerrar As System.Windows.Forms.ToolStripButton
    Friend WithEvents cmbFormulas As Eniac.Controles.ComboBox
    Friend WithEvents lblFormula As Eniac.Controles.Label
    Friend WithEvents cmbResponsable As Eniac.Controles.ComboBox
    Friend WithEvents lblResponsable As Eniac.Controles.Label
    Friend WithEvents bscProducto2 As Eniac.Controles.Buscador2
    Friend WithEvents bscCodigoProducto2 As Eniac.Controles.Buscador2
    Friend WithEvents ugProductos As UltraGrid
    Friend WithEvents lblDepositoOrigen As Controles.Label
    Friend WithEvents cmbDepositoOrigen As Controles.ComboBox
    Friend WithEvents Label1 As Controles.Label
    Friend WithEvents cmbUbicacionOrigen As Controles.ComboBox
End Class
