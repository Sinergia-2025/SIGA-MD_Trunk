<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class ImportarProductosExcel
    Inherits BaseForm

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ImportarProductosExcel))
        Me.grbPendientes = New System.Windows.Forms.GroupBox()
        Me.chkCreaUbicaciones = New System.Windows.Forms.CheckBox()
        Me.txtRangoCeldasFilaDesde = New Eniac.Controles.TextBox()
        Me.txtRangoCeldasColumnaHasta = New Eniac.Controles.TextBox()
        Me.txtRangoCeldasFilaHasta = New Eniac.Controles.TextBox()
        Me.txtRangoCeldasColumnaDesde = New Eniac.Controles.TextBox()
        Me.lblEjemplos = New Eniac.Controles.Label()
        Me.Label6 = New Eniac.Controles.Label()
        Me.cmbListaPrecios = New Eniac.Controles.ComboBox()
        Me.Label4 = New Eniac.Controles.Label()
        Me.Label2 = New Eniac.Controles.Label()
        Me.txtPrefijo = New Eniac.Controles.TextBox()
        Me.cmbDescripcionCorte = New Eniac.Controles.ComboBox()
        Me.Label1 = New Eniac.Controles.Label()
        Me.cboAccion = New Eniac.Controles.ComboBox()
        Me.lblAccion = New Eniac.Controles.Label()
        Me.cboEstado = New Eniac.Controles.ComboBox()
        Me.lblEstado = New Eniac.Controles.Label()
        Me.cboDescripcion = New Eniac.Controles.ComboBox()
        Me.lblDescripcionProducto = New Eniac.Controles.Label()
        Me.txtArchivoOrigen = New Eniac.Controles.TextBox()
        Me.lblArchivo = New Eniac.Controles.Label()
        Me.btnExaminar = New Eniac.Controles.Button()
        Me.btnMostrar = New Eniac.Controles.Button()
        Me.dgvDetalle = New Eniac.Controles.DataGridView()
        Me.Importa = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.Accion = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CodigoProducto = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.IdProductoNumerico = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.NombreProducto = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.NombreProducto2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.NombreMarca = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.NombreRubro = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.NombreSubRubro = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.NombreSubSubRubro = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.IVA = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PrecioCosto = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PrecioVenta = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Moneda = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CodigoDeBarras = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Porcentaje = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.NombreProveedorHabitual = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CodigoProductoProveedorHabitual = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Mensaje = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.tstBarra = New System.Windows.Forms.ToolStrip()
        Me.tsbRefrescar = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsbImportar = New System.Windows.Forms.ToolStripButton()
        Me.toolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsbSalir = New System.Windows.Forms.ToolStripButton()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.tssRegistros = New System.Windows.Forms.ToolStripStatusLabel()
        Me.prbImportando = New System.Windows.Forms.ProgressBar()
        Me.grbPendientes.SuspendLayout()
        CType(Me.dgvDetalle, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tstBarra.SuspendLayout()
        Me.StatusStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'grbPendientes
        '
        Me.grbPendientes.Controls.Add(Me.chkCreaUbicaciones)
        Me.grbPendientes.Controls.Add(Me.txtRangoCeldasFilaDesde)
        Me.grbPendientes.Controls.Add(Me.txtRangoCeldasColumnaHasta)
        Me.grbPendientes.Controls.Add(Me.txtRangoCeldasFilaHasta)
        Me.grbPendientes.Controls.Add(Me.txtRangoCeldasColumnaDesde)
        Me.grbPendientes.Controls.Add(Me.lblEjemplos)
        Me.grbPendientes.Controls.Add(Me.Label6)
        Me.grbPendientes.Controls.Add(Me.cmbListaPrecios)
        Me.grbPendientes.Controls.Add(Me.Label4)
        Me.grbPendientes.Controls.Add(Me.Label2)
        Me.grbPendientes.Controls.Add(Me.txtPrefijo)
        Me.grbPendientes.Controls.Add(Me.cmbDescripcionCorte)
        Me.grbPendientes.Controls.Add(Me.Label1)
        Me.grbPendientes.Controls.Add(Me.cboAccion)
        Me.grbPendientes.Controls.Add(Me.lblAccion)
        Me.grbPendientes.Controls.Add(Me.cboEstado)
        Me.grbPendientes.Controls.Add(Me.lblEstado)
        Me.grbPendientes.Controls.Add(Me.cboDescripcion)
        Me.grbPendientes.Controls.Add(Me.lblDescripcionProducto)
        Me.grbPendientes.Controls.Add(Me.txtArchivoOrigen)
        Me.grbPendientes.Controls.Add(Me.lblArchivo)
        Me.grbPendientes.Controls.Add(Me.btnExaminar)
        Me.grbPendientes.Controls.Add(Me.btnMostrar)
        Me.grbPendientes.Dock = System.Windows.Forms.DockStyle.Top
        Me.grbPendientes.Location = New System.Drawing.Point(0, 29)
        Me.grbPendientes.Name = "grbPendientes"
        Me.grbPendientes.Size = New System.Drawing.Size(984, 100)
        Me.grbPendientes.TabIndex = 0
        Me.grbPendientes.TabStop = False
        '
        'chkCreaUbicaciones
        '
        Me.chkCreaUbicaciones.Location = New System.Drawing.Point(653, 76)
        Me.chkCreaUbicaciones.Name = "chkCreaUbicaciones"
        Me.chkCreaUbicaciones.Size = New System.Drawing.Size(181, 16)
        Me.chkCreaUbicaciones.TabIndex = 22
        Me.chkCreaUbicaciones.Text = "Dar de alta nuevas Ubicaciones."
        '
        'txtRangoCeldasFilaDesde
        '
        Me.txtRangoCeldasFilaDesde.BindearPropiedadControl = Nothing
        Me.txtRangoCeldasFilaDesde.BindearPropiedadEntidad = Nothing
        Me.txtRangoCeldasFilaDesde.ForeColorFocus = System.Drawing.Color.Red
        Me.txtRangoCeldasFilaDesde.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtRangoCeldasFilaDesde.Formato = ""
        Me.txtRangoCeldasFilaDesde.IsDecimal = False
        Me.txtRangoCeldasFilaDesde.IsNumber = False
        Me.txtRangoCeldasFilaDesde.IsPK = False
        Me.txtRangoCeldasFilaDesde.IsRequired = False
        Me.txtRangoCeldasFilaDesde.Key = ""
        Me.txtRangoCeldasFilaDesde.LabelAsoc = Nothing
        Me.txtRangoCeldasFilaDesde.Location = New System.Drawing.Point(747, 22)
        Me.txtRangoCeldasFilaDesde.Name = "txtRangoCeldasFilaDesde"
        Me.txtRangoCeldasFilaDesde.Size = New System.Drawing.Size(21, 20)
        Me.txtRangoCeldasFilaDesde.TabIndex = 5
        Me.txtRangoCeldasFilaDesde.TabStop = False
        Me.txtRangoCeldasFilaDesde.Text = "4"
        Me.txtRangoCeldasFilaDesde.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtRangoCeldasColumnaHasta
        '
        Me.txtRangoCeldasColumnaHasta.BindearPropiedadControl = Nothing
        Me.txtRangoCeldasColumnaHasta.BindearPropiedadEntidad = Nothing
        Me.txtRangoCeldasColumnaHasta.ForeColorFocus = System.Drawing.Color.Red
        Me.txtRangoCeldasColumnaHasta.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtRangoCeldasColumnaHasta.Formato = ""
        Me.txtRangoCeldasColumnaHasta.IsDecimal = False
        Me.txtRangoCeldasColumnaHasta.IsNumber = False
        Me.txtRangoCeldasColumnaHasta.IsPK = False
        Me.txtRangoCeldasColumnaHasta.IsRequired = False
        Me.txtRangoCeldasColumnaHasta.Key = ""
        Me.txtRangoCeldasColumnaHasta.LabelAsoc = Nothing
        Me.txtRangoCeldasColumnaHasta.Location = New System.Drawing.Point(769, 22)
        Me.txtRangoCeldasColumnaHasta.Name = "txtRangoCeldasColumnaHasta"
        Me.txtRangoCeldasColumnaHasta.ReadOnly = True
        Me.txtRangoCeldasColumnaHasta.Size = New System.Drawing.Size(17, 20)
        Me.txtRangoCeldasColumnaHasta.TabIndex = 6
        Me.txtRangoCeldasColumnaHasta.TabStop = False
        Me.txtRangoCeldasColumnaHasta.Text = ":Q"
        Me.txtRangoCeldasColumnaHasta.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtRangoCeldasFilaHasta
        '
        Me.txtRangoCeldasFilaHasta.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.txtRangoCeldasFilaHasta.BindearPropiedadControl = Nothing
        Me.txtRangoCeldasFilaHasta.BindearPropiedadEntidad = Nothing
        Me.txtRangoCeldasFilaHasta.ForeColorFocus = System.Drawing.Color.Red
        Me.txtRangoCeldasFilaHasta.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtRangoCeldasFilaHasta.Formato = ""
        Me.txtRangoCeldasFilaHasta.IsDecimal = False
        Me.txtRangoCeldasFilaHasta.IsNumber = False
        Me.txtRangoCeldasFilaHasta.IsPK = False
        Me.txtRangoCeldasFilaHasta.IsRequired = False
        Me.txtRangoCeldasFilaHasta.Key = ""
        Me.txtRangoCeldasFilaHasta.LabelAsoc = Nothing
        Me.txtRangoCeldasFilaHasta.Location = New System.Drawing.Point(788, 22)
        Me.txtRangoCeldasFilaHasta.Name = "txtRangoCeldasFilaHasta"
        Me.txtRangoCeldasFilaHasta.Size = New System.Drawing.Size(46, 20)
        Me.txtRangoCeldasFilaHasta.TabIndex = 7
        '
        'txtRangoCeldasColumnaDesde
        '
        Me.txtRangoCeldasColumnaDesde.BindearPropiedadControl = Nothing
        Me.txtRangoCeldasColumnaDesde.BindearPropiedadEntidad = Nothing
        Me.txtRangoCeldasColumnaDesde.ForeColorFocus = System.Drawing.Color.Red
        Me.txtRangoCeldasColumnaDesde.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtRangoCeldasColumnaDesde.Formato = ""
        Me.txtRangoCeldasColumnaDesde.IsDecimal = False
        Me.txtRangoCeldasColumnaDesde.IsNumber = False
        Me.txtRangoCeldasColumnaDesde.IsPK = False
        Me.txtRangoCeldasColumnaDesde.IsRequired = False
        Me.txtRangoCeldasColumnaDesde.Key = ""
        Me.txtRangoCeldasColumnaDesde.LabelAsoc = Nothing
        Me.txtRangoCeldasColumnaDesde.Location = New System.Drawing.Point(724, 22)
        Me.txtRangoCeldasColumnaDesde.Name = "txtRangoCeldasColumnaDesde"
        Me.txtRangoCeldasColumnaDesde.Size = New System.Drawing.Size(21, 20)
        Me.txtRangoCeldasColumnaDesde.TabIndex = 4
        Me.txtRangoCeldasColumnaDesde.TabStop = False
        Me.txtRangoCeldasColumnaDesde.Text = "A"
        Me.txtRangoCeldasColumnaDesde.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'lblEjemplos
        '
        Me.lblEjemplos.AutoSize = True
        Me.lblEjemplos.LabelAsoc = Nothing
        Me.lblEjemplos.Location = New System.Drawing.Point(838, 26)
        Me.lblEjemplos.Name = "lblEjemplos"
        Me.lblEjemplos.Size = New System.Drawing.Size(67, 13)
        Me.lblEjemplos.TabIndex = 8
        Me.lblEjemplos.Text = "Ej:  A1:Q200"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.LabelAsoc = Nothing
        Me.Label6.Location = New System.Drawing.Point(676, 26)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(42, 13)
        Me.Label6.TabIndex = 3
        Me.Label6.Text = "Rango:"
        '
        'cmbListaPrecios
        '
        Me.cmbListaPrecios.BindearPropiedadControl = Nothing
        Me.cmbListaPrecios.BindearPropiedadEntidad = Nothing
        Me.cmbListaPrecios.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbListaPrecios.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbListaPrecios.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbListaPrecios.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbListaPrecios.FormattingEnabled = True
        Me.cmbListaPrecios.IsPK = False
        Me.cmbListaPrecios.IsRequired = False
        Me.cmbListaPrecios.Key = Nothing
        Me.cmbListaPrecios.LabelAsoc = Me.Label4
        Me.cmbListaPrecios.Location = New System.Drawing.Point(501, 75)
        Me.cmbListaPrecios.Name = "cmbListaPrecios"
        Me.cmbListaPrecios.Size = New System.Drawing.Size(126, 21)
        Me.cmbListaPrecios.TabIndex = 20
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.LabelAsoc = Nothing
        Me.Label4.Location = New System.Drawing.Point(416, 79)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(82, 13)
        Me.Label4.TabIndex = 19
        Me.Label4.Text = "Lista de Precios"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.LabelAsoc = Nothing
        Me.Label2.Location = New System.Drawing.Point(415, 52)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(39, 13)
        Me.Label2.TabIndex = 17
        Me.Label2.Text = "Prefijo:"
        '
        'txtPrefijo
        '
        Me.txtPrefijo.BindearPropiedadControl = Nothing
        Me.txtPrefijo.BindearPropiedadEntidad = Nothing
        Me.txtPrefijo.ForeColorFocus = System.Drawing.Color.Red
        Me.txtPrefijo.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtPrefijo.Formato = ""
        Me.txtPrefijo.IsDecimal = False
        Me.txtPrefijo.IsNumber = False
        Me.txtPrefijo.IsPK = False
        Me.txtPrefijo.IsRequired = False
        Me.txtPrefijo.Key = ""
        Me.txtPrefijo.LabelAsoc = Nothing
        Me.txtPrefijo.Location = New System.Drawing.Point(455, 48)
        Me.txtPrefijo.MaxLength = 5
        Me.txtPrefijo.Name = "txtPrefijo"
        Me.txtPrefijo.Size = New System.Drawing.Size(52, 20)
        Me.txtPrefijo.TabIndex = 18
        '
        'cmbDescripcionCorte
        '
        Me.cmbDescripcionCorte.BindearPropiedadControl = Nothing
        Me.cmbDescripcionCorte.BindearPropiedadEntidad = Nothing
        Me.cmbDescripcionCorte.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbDescripcionCorte.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbDescripcionCorte.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbDescripcionCorte.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbDescripcionCorte.FormattingEnabled = True
        Me.cmbDescripcionCorte.IsPK = False
        Me.cmbDescripcionCorte.IsRequired = False
        Me.cmbDescripcionCorte.Key = Nothing
        Me.cmbDescripcionCorte.LabelAsoc = Me.Label1
        Me.cmbDescripcionCorte.Location = New System.Drawing.Point(289, 75)
        Me.cmbDescripcionCorte.Name = "cmbDescripcionCorte"
        Me.cmbDescripcionCorte.Size = New System.Drawing.Size(96, 21)
        Me.cmbDescripcionCorte.TabIndex = 16
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.LabelAsoc = Nothing
        Me.Label1.Location = New System.Drawing.Point(195, 79)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(91, 13)
        Me.Label1.TabIndex = 15
        Me.Label1.Text = "Descripción Corte"
        '
        'cboAccion
        '
        Me.cboAccion.BindearPropiedadControl = Nothing
        Me.cboAccion.BindearPropiedadEntidad = Nothing
        Me.cboAccion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboAccion.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboAccion.ForeColorFocus = System.Drawing.Color.Red
        Me.cboAccion.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cboAccion.FormattingEnabled = True
        Me.cboAccion.IsPK = False
        Me.cboAccion.IsRequired = False
        Me.cboAccion.Key = Nothing
        Me.cboAccion.LabelAsoc = Me.lblAccion
        Me.cboAccion.Location = New System.Drawing.Point(72, 75)
        Me.cboAccion.Name = "cboAccion"
        Me.cboAccion.Size = New System.Drawing.Size(96, 21)
        Me.cboAccion.TabIndex = 12
        '
        'lblAccion
        '
        Me.lblAccion.AutoSize = True
        Me.lblAccion.LabelAsoc = Nothing
        Me.lblAccion.Location = New System.Drawing.Point(6, 79)
        Me.lblAccion.Name = "lblAccion"
        Me.lblAccion.Size = New System.Drawing.Size(40, 13)
        Me.lblAccion.TabIndex = 11
        Me.lblAccion.Text = "Accion"
        '
        'cboEstado
        '
        Me.cboEstado.BindearPropiedadControl = Nothing
        Me.cboEstado.BindearPropiedadEntidad = Nothing
        Me.cboEstado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboEstado.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboEstado.ForeColorFocus = System.Drawing.Color.Red
        Me.cboEstado.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cboEstado.FormattingEnabled = True
        Me.cboEstado.IsPK = False
        Me.cboEstado.IsRequired = False
        Me.cboEstado.Key = Nothing
        Me.cboEstado.LabelAsoc = Me.lblEstado
        Me.cboEstado.Location = New System.Drawing.Point(289, 48)
        Me.cboEstado.Name = "cboEstado"
        Me.cboEstado.Size = New System.Drawing.Size(96, 21)
        Me.cboEstado.TabIndex = 14
        '
        'lblEstado
        '
        Me.lblEstado.AutoSize = True
        Me.lblEstado.LabelAsoc = Nothing
        Me.lblEstado.Location = New System.Drawing.Point(198, 52)
        Me.lblEstado.Name = "lblEstado"
        Me.lblEstado.Size = New System.Drawing.Size(40, 13)
        Me.lblEstado.TabIndex = 13
        Me.lblEstado.Text = "Estado"
        '
        'cboDescripcion
        '
        Me.cboDescripcion.BindearPropiedadControl = Nothing
        Me.cboDescripcion.BindearPropiedadEntidad = Nothing
        Me.cboDescripcion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboDescripcion.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboDescripcion.ForeColorFocus = System.Drawing.Color.Red
        Me.cboDescripcion.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cboDescripcion.FormattingEnabled = True
        Me.cboDescripcion.IsPK = False
        Me.cboDescripcion.IsRequired = False
        Me.cboDescripcion.Key = Nothing
        Me.cboDescripcion.LabelAsoc = Me.lblDescripcionProducto
        Me.cboDescripcion.Location = New System.Drawing.Point(72, 48)
        Me.cboDescripcion.Name = "cboDescripcion"
        Me.cboDescripcion.Size = New System.Drawing.Size(96, 21)
        Me.cboDescripcion.TabIndex = 10
        '
        'lblDescripcionProducto
        '
        Me.lblDescripcionProducto.AutoSize = True
        Me.lblDescripcionProducto.LabelAsoc = Nothing
        Me.lblDescripcionProducto.Location = New System.Drawing.Point(6, 52)
        Me.lblDescripcionProducto.Name = "lblDescripcionProducto"
        Me.lblDescripcionProducto.Size = New System.Drawing.Size(63, 13)
        Me.lblDescripcionProducto.TabIndex = 9
        Me.lblDescripcionProducto.Text = "Descripcion"
        '
        'txtArchivoOrigen
        '
        Me.txtArchivoOrigen.BindearPropiedadControl = "Text"
        Me.txtArchivoOrigen.BindearPropiedadEntidad = "CantidadProductos"
        Me.txtArchivoOrigen.ForeColorFocus = System.Drawing.Color.Red
        Me.txtArchivoOrigen.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtArchivoOrigen.Formato = ""
        Me.txtArchivoOrigen.IsDecimal = False
        Me.txtArchivoOrigen.IsNumber = False
        Me.txtArchivoOrigen.IsPK = False
        Me.txtArchivoOrigen.IsRequired = False
        Me.txtArchivoOrigen.Key = ""
        Me.txtArchivoOrigen.LabelAsoc = Nothing
        Me.txtArchivoOrigen.Location = New System.Drawing.Point(55, 22)
        Me.txtArchivoOrigen.Name = "txtArchivoOrigen"
        Me.txtArchivoOrigen.Size = New System.Drawing.Size(499, 20)
        Me.txtArchivoOrigen.TabIndex = 1
        '
        'lblArchivo
        '
        Me.lblArchivo.AutoSize = True
        Me.lblArchivo.LabelAsoc = Nothing
        Me.lblArchivo.Location = New System.Drawing.Point(6, 26)
        Me.lblArchivo.Name = "lblArchivo"
        Me.lblArchivo.Size = New System.Drawing.Size(43, 13)
        Me.lblArchivo.TabIndex = 0
        Me.lblArchivo.Text = "Archivo"
        '
        'btnExaminar
        '
        Me.btnExaminar.Image = Global.Eniac.Win.My.Resources.Resources.folder_32
        Me.btnExaminar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnExaminar.Location = New System.Drawing.Point(559, 12)
        Me.btnExaminar.Name = "btnExaminar"
        Me.btnExaminar.Size = New System.Drawing.Size(104, 40)
        Me.btnExaminar.TabIndex = 2
        Me.btnExaminar.Text = "&Examinar..."
        Me.btnExaminar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnExaminar.UseVisualStyleBackColor = True
        '
        'btnMostrar
        '
        Me.btnMostrar.Image = Global.Eniac.Win.My.Resources.Resources.view
        Me.btnMostrar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnMostrar.Location = New System.Drawing.Point(860, 51)
        Me.btnMostrar.Name = "btnMostrar"
        Me.btnMostrar.Size = New System.Drawing.Size(112, 45)
        Me.btnMostrar.TabIndex = 21
        Me.btnMostrar.Text = "&Mostrar (F3)"
        Me.btnMostrar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnMostrar.UseVisualStyleBackColor = False
        '
        'dgvDetalle
        '
        Me.dgvDetalle.AllowUserToAddRows = False
        Me.dgvDetalle.AllowUserToDeleteRows = False
        Me.dgvDetalle.AllowUserToResizeRows = False
        Me.dgvDetalle.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvDetalle.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Importa, Me.Accion, Me.CodigoProducto, Me.IdProductoNumerico, Me.NombreProducto, Me.NombreProducto2, Me.NombreMarca, Me.NombreRubro, Me.NombreSubRubro, Me.NombreSubSubRubro, Me.IVA, Me.PrecioCosto, Me.PrecioVenta, Me.Moneda, Me.CodigoDeBarras, Me.Porcentaje, Me.NombreProveedorHabitual, Me.CodigoProductoProveedorHabitual, Me.Mensaje})
        Me.dgvDetalle.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvDetalle.Location = New System.Drawing.Point(0, 129)
        Me.dgvDetalle.Name = "dgvDetalle"
        Me.dgvDetalle.ReadOnly = True
        Me.dgvDetalle.RowHeadersWidth = 15
        Me.dgvDetalle.Size = New System.Drawing.Size(984, 382)
        Me.dgvDetalle.TabIndex = 1
        '
        'Importa
        '
        Me.Importa.DataPropertyName = "Importa"
        Me.Importa.HeaderText = "Pasa"
        Me.Importa.Name = "Importa"
        Me.Importa.ReadOnly = True
        Me.Importa.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Importa.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic
        Me.Importa.Width = 40
        '
        'Accion
        '
        Me.Accion.DataPropertyName = "Accion"
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.Accion.DefaultCellStyle = DataGridViewCellStyle1
        Me.Accion.HeaderText = "Accion"
        Me.Accion.Name = "Accion"
        Me.Accion.ReadOnly = True
        Me.Accion.Width = 40
        '
        'CodigoProducto
        '
        Me.CodigoProducto.DataPropertyName = "CodigoProducto"
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.CodigoProducto.DefaultCellStyle = DataGridViewCellStyle2
        Me.CodigoProducto.HeaderText = "Codigo Prod."
        Me.CodigoProducto.Name = "CodigoProducto"
        Me.CodigoProducto.ReadOnly = True
        '
        'IdProductoNumerico
        '
        Me.IdProductoNumerico.DataPropertyName = "IdProductoNumerico"
        Me.IdProductoNumerico.HeaderText = "Cód. Producto Numérico"
        Me.IdProductoNumerico.Name = "IdProductoNumerico"
        Me.IdProductoNumerico.ReadOnly = True
        '
        'NombreProducto
        '
        Me.NombreProducto.DataPropertyName = "NombreProducto"
        Me.NombreProducto.HeaderText = "Nombre Producto"
        Me.NombreProducto.Name = "NombreProducto"
        Me.NombreProducto.ReadOnly = True
        Me.NombreProducto.Width = 300
        '
        'NombreProducto2
        '
        Me.NombreProducto2.DataPropertyName = "NombreProducto2"
        Me.NombreProducto2.HeaderText = "Nombre Producto Ext."
        Me.NombreProducto2.Name = "NombreProducto2"
        Me.NombreProducto2.ReadOnly = True
        Me.NombreProducto2.Visible = False
        '
        'NombreMarca
        '
        Me.NombreMarca.DataPropertyName = "NombreMarca"
        Me.NombreMarca.HeaderText = "Nombre Marca"
        Me.NombreMarca.Name = "NombreMarca"
        Me.NombreMarca.ReadOnly = True
        Me.NombreMarca.Width = 120
        '
        'NombreRubro
        '
        Me.NombreRubro.DataPropertyName = "NombreRubro"
        Me.NombreRubro.HeaderText = "Nombre Rubro"
        Me.NombreRubro.Name = "NombreRubro"
        Me.NombreRubro.ReadOnly = True
        Me.NombreRubro.Width = 120
        '
        'NombreSubRubro
        '
        Me.NombreSubRubro.DataPropertyName = "NombreSubRubro"
        Me.NombreSubRubro.HeaderText = "Nombre SubRubro"
        Me.NombreSubRubro.Name = "NombreSubRubro"
        Me.NombreSubRubro.ReadOnly = True
        Me.NombreSubRubro.Width = 120
        '
        'NombreSubSubRubro
        '
        Me.NombreSubSubRubro.DataPropertyName = "NombreSubSubRubro"
        Me.NombreSubSubRubro.HeaderText = "Nombre SubSub Rubro"
        Me.NombreSubSubRubro.Name = "NombreSubSubRubro"
        Me.NombreSubSubRubro.ReadOnly = True
        '
        'IVA
        '
        Me.IVA.DataPropertyName = "IVA"
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle3.Format = "N2"
        Me.IVA.DefaultCellStyle = DataGridViewCellStyle3
        Me.IVA.HeaderText = "IVA"
        Me.IVA.Name = "IVA"
        Me.IVA.ReadOnly = True
        Me.IVA.Width = 50
        '
        'PrecioCosto
        '
        Me.PrecioCosto.DataPropertyName = "PrecioCosto"
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle4.Format = "N2"
        Me.PrecioCosto.DefaultCellStyle = DataGridViewCellStyle4
        Me.PrecioCosto.HeaderText = "Precio Costo"
        Me.PrecioCosto.Name = "PrecioCosto"
        Me.PrecioCosto.ReadOnly = True
        Me.PrecioCosto.Width = 70
        '
        'PrecioVenta
        '
        Me.PrecioVenta.DataPropertyName = "PrecioVenta"
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle5.Format = "N2"
        DataGridViewCellStyle5.NullValue = Nothing
        Me.PrecioVenta.DefaultCellStyle = DataGridViewCellStyle5
        Me.PrecioVenta.HeaderText = "Precio Venta"
        Me.PrecioVenta.Name = "PrecioVenta"
        Me.PrecioVenta.ReadOnly = True
        Me.PrecioVenta.Width = 70
        '
        'Moneda
        '
        Me.Moneda.DataPropertyName = "Moneda"
        Me.Moneda.HeaderText = "Moneda"
        Me.Moneda.Name = "Moneda"
        Me.Moneda.ReadOnly = True
        Me.Moneda.Width = 60
        '
        'CodigoDeBarras
        '
        Me.CodigoDeBarras.DataPropertyName = "CodigoDeBarras"
        Me.CodigoDeBarras.HeaderText = "Codigo de Barras"
        Me.CodigoDeBarras.Name = "CodigoDeBarras"
        Me.CodigoDeBarras.ReadOnly = True
        '
        'Porcentaje
        '
        Me.Porcentaje.DataPropertyName = "Porcentaje"
        Me.Porcentaje.HeaderText = "Porcentaje"
        Me.Porcentaje.Name = "Porcentaje"
        Me.Porcentaje.ReadOnly = True
        Me.Porcentaje.Visible = False
        '
        'NombreProveedorHabitual
        '
        Me.NombreProveedorHabitual.DataPropertyName = "NombreProveedorHabitual"
        Me.NombreProveedorHabitual.HeaderText = "Nombre Proveedor Habitual"
        Me.NombreProveedorHabitual.Name = "NombreProveedorHabitual"
        Me.NombreProveedorHabitual.ReadOnly = True
        '
        'CodigoProductoProveedorHabitual
        '
        Me.CodigoProductoProveedorHabitual.DataPropertyName = "CodigoProductoProveedorHabitual"
        Me.CodigoProductoProveedorHabitual.HeaderText = "Codigo Producto Prov. Hab."
        Me.CodigoProductoProveedorHabitual.Name = "CodigoProductoProveedorHabitual"
        Me.CodigoProductoProveedorHabitual.ReadOnly = True
        '
        'Mensaje
        '
        Me.Mensaje.DataPropertyName = "Mensaje"
        Me.Mensaje.HeaderText = "Mensaje"
        Me.Mensaje.Name = "Mensaje"
        Me.Mensaje.ReadOnly = True
        Me.Mensaje.Width = 400
        '
        'tstBarra
        '
        Me.tstBarra.AllowItemReorder = True
        Me.tstBarra.ImageScalingSize = New System.Drawing.Size(22, 22)
        Me.tstBarra.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsbRefrescar, Me.ToolStripSeparator1, Me.tsbImportar, Me.toolStripSeparator3, Me.tsbSalir})
        Me.tstBarra.Location = New System.Drawing.Point(0, 0)
        Me.tstBarra.Name = "tstBarra"
        Me.tstBarra.Size = New System.Drawing.Size(984, 29)
        Me.tstBarra.TabIndex = 4
        Me.tstBarra.Text = "toolStrip1"
        '
        'tsbRefrescar
        '
        Me.tsbRefrescar.Image = Global.Eniac.Win.My.Resources.Resources.refresh_32
        Me.tsbRefrescar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbRefrescar.Name = "tsbRefrescar"
        Me.tsbRefrescar.Size = New System.Drawing.Size(104, 26)
        Me.tsbRefrescar.Text = "&Refrescar (F5)"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 29)
        '
        'tsbImportar
        '
        Me.tsbImportar.Image = CType(resources.GetObject("tsbImportar.Image"), System.Drawing.Image)
        Me.tsbImportar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbImportar.Name = "tsbImportar"
        Me.tsbImportar.Size = New System.Drawing.Size(79, 26)
        Me.tsbImportar.Text = "&Importar"
        '
        'toolStripSeparator3
        '
        Me.toolStripSeparator3.Name = "toolStripSeparator3"
        Me.toolStripSeparator3.Size = New System.Drawing.Size(6, 29)
        '
        'tsbSalir
        '
        Me.tsbSalir.Image = Global.Eniac.Win.My.Resources.Resources.close_b_32
        Me.tsbSalir.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbSalir.Name = "tsbSalir"
        Me.tsbSalir.Size = New System.Drawing.Size(65, 26)
        Me.tsbSalir.Text = "&Cerrar"
        Me.tsbSalir.ToolTipText = "Cerrar el formulario"
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tssRegistros})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 540)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(984, 22)
        Me.StatusStrip1.TabIndex = 3
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'tssRegistros
        '
        Me.tssRegistros.Name = "tssRegistros"
        Me.tssRegistros.Size = New System.Drawing.Size(969, 17)
        Me.tssRegistros.Spring = True
        Me.tssRegistros.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'prbImportando
        '
        Me.prbImportando.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.prbImportando.Location = New System.Drawing.Point(0, 511)
        Me.prbImportando.Name = "prbImportando"
        Me.prbImportando.Size = New System.Drawing.Size(984, 29)
        Me.prbImportando.Style = System.Windows.Forms.ProgressBarStyle.Continuous
        Me.prbImportando.TabIndex = 2
        '
        'ImportarProductosExcel
        '
        Me.AcceptButton = Me.btnMostrar
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(984, 562)
        Me.Controls.Add(Me.dgvDetalle)
        Me.Controls.Add(Me.grbPendientes)
        Me.Controls.Add(Me.prbImportando)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.tstBarra)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.Name = "ImportarProductosExcel"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Importar Productos desde Excel"
        Me.grbPendientes.ResumeLayout(False)
        Me.grbPendientes.PerformLayout()
        CType(Me.dgvDetalle, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tstBarra.ResumeLayout(False)
        Me.tstBarra.PerformLayout()
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents grbPendientes As System.Windows.Forms.GroupBox
    Friend WithEvents btnMostrar As Eniac.Controles.Button
    Friend WithEvents dgvDetalle As Eniac.Controles.DataGridView
    Public WithEvents tstBarra As System.Windows.Forms.ToolStrip
    Private WithEvents toolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Public WithEvents tsbSalir As System.Windows.Forms.ToolStripButton
    Public WithEvents tsbRefrescar As System.Windows.Forms.ToolStripButton
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents tssRegistros As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents tsbImportar As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnExaminar As Eniac.Controles.Button
    Friend WithEvents lblArchivo As Eniac.Controles.Label
    Friend WithEvents txtArchivoOrigen As Eniac.Controles.TextBox
    Private WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents prbImportando As System.Windows.Forms.ProgressBar
    Friend WithEvents lblDescripcionProducto As Eniac.Controles.Label
    Friend WithEvents cboDescripcion As Eniac.Controles.ComboBox
    Friend WithEvents cboEstado As Eniac.Controles.ComboBox
    Friend WithEvents lblEstado As Eniac.Controles.Label
    Friend WithEvents cboAccion As Eniac.Controles.ComboBox
    Friend WithEvents lblAccion As Eniac.Controles.Label
    Friend WithEvents cmbDescripcionCorte As Eniac.Controles.ComboBox
    Friend WithEvents Label1 As Eniac.Controles.Label
    Friend WithEvents Label2 As Eniac.Controles.Label
    Friend WithEvents txtPrefijo As Eniac.Controles.TextBox
    Friend WithEvents cmbListaPrecios As Eniac.Controles.ComboBox
    Friend WithEvents Label4 As Eniac.Controles.Label
    Friend WithEvents Importa As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents Accion As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CodigoProducto As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents IdProductoNumerico As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents NombreProducto As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents NombreProducto2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents NombreMarca As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents NombreRubro As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents NombreSubRubro As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents NombreSubSubRubro As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents IVA As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PrecioCosto As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PrecioVenta As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Moneda As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CodigoDeBarras As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Porcentaje As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents NombreProveedorHabitual As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CodigoProductoProveedorHabitual As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Mensaje As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents txtRangoCeldasFilaDesde As Controles.TextBox
    Friend WithEvents txtRangoCeldasColumnaHasta As Controles.TextBox
    Friend WithEvents txtRangoCeldasFilaHasta As Controles.TextBox
    Friend WithEvents txtRangoCeldasColumnaDesde As Controles.TextBox
    Friend WithEvents lblEjemplos As Controles.Label
    Friend WithEvents Label6 As Controles.Label
    Friend WithEvents chkCreaUbicaciones As CheckBox
End Class
