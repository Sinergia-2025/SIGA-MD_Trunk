<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ImportarClientesExcel
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
      Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
      Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
      Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
      Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
      Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
      Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
      Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
      Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ImportarClientesExcel))
      Me.grbPendientes = New System.Windows.Forms.GroupBox()
      Me.cmbTipoNovedad = New Eniac.Controles.ComboBox()
      Me.chbCrearCRM = New Eniac.Controles.CheckBox()
      Me.cmbDescripcionCorte = New Eniac.Controles.ComboBox()
      Me.Label1 = New Eniac.Controles.Label()
      Me.cboAccion = New Eniac.Controles.ComboBox()
      Me.lblAccion = New Eniac.Controles.Label()
      Me.cboEstado = New Eniac.Controles.ComboBox()
      Me.lblEstado = New Eniac.Controles.Label()
      Me.txtRangoCeldas = New System.Windows.Forms.TextBox()
      Me.lblEjemplos = New Eniac.Controles.Label()
      Me.Label3 = New Eniac.Controles.Label()
      Me.txtArchivoOrigen = New Eniac.Controles.TextBox()
      Me.lblArchivo = New Eniac.Controles.Label()
      Me.btnExaminar = New Eniac.Controles.Button()
      Me.btnMostrar = New Eniac.Controles.Button()
      Me.dgvDetalle = New Eniac.Controles.DataGridView()
      Me.Importa = New System.Windows.Forms.DataGridViewCheckBoxColumn()
      Me.Accion = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.CodigoCliente = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.NombreCliente = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.Direccion = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.IdLocalidad = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.Telefono = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.Celular = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.CorreoElectronico = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.NombreCategoria = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.NombreCategoriaFiscal = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.NombreVendedor = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.NombreListaPrecios = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.NombreZonaGeografica = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.CUIT = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.TipoDocCliente = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.NroDocCliente = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.FechaAlta = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.NombreDeFantasia = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.Twitter = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.Observacion = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.Sexo = New System.Windows.Forms.DataGridViewTextBoxColumn()
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
        Me.grbPendientes.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grbPendientes.Controls.Add(Me.cmbTipoNovedad)
        Me.grbPendientes.Controls.Add(Me.chbCrearCRM)
        Me.grbPendientes.Controls.Add(Me.cmbDescripcionCorte)
        Me.grbPendientes.Controls.Add(Me.Label1)
        Me.grbPendientes.Controls.Add(Me.cboAccion)
        Me.grbPendientes.Controls.Add(Me.lblAccion)
        Me.grbPendientes.Controls.Add(Me.cboEstado)
        Me.grbPendientes.Controls.Add(Me.lblEstado)
        Me.grbPendientes.Controls.Add(Me.txtRangoCeldas)
        Me.grbPendientes.Controls.Add(Me.lblEjemplos)
        Me.grbPendientes.Controls.Add(Me.Label3)
        Me.grbPendientes.Controls.Add(Me.txtArchivoOrigen)
        Me.grbPendientes.Controls.Add(Me.lblArchivo)
        Me.grbPendientes.Controls.Add(Me.btnExaminar)
        Me.grbPendientes.Controls.Add(Me.btnMostrar)
        Me.grbPendientes.Location = New System.Drawing.Point(12, 25)
        Me.grbPendientes.Name = "grbPendientes"
        Me.grbPendientes.Size = New System.Drawing.Size(961, 102)
        Me.grbPendientes.TabIndex = 0
        Me.grbPendientes.TabStop = False
        '
        'cmbTipoNovedad
        '
        Me.cmbTipoNovedad.BindearPropiedadControl = ""
        Me.cmbTipoNovedad.BindearPropiedadEntidad = ""
        Me.cmbTipoNovedad.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbTipoNovedad.Enabled = False
        Me.cmbTipoNovedad.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbTipoNovedad.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbTipoNovedad.FormattingEnabled = True
        Me.cmbTipoNovedad.IsPK = False
        Me.cmbTipoNovedad.IsRequired = False
        Me.cmbTipoNovedad.Key = Nothing
        Me.cmbTipoNovedad.LabelAsoc = Nothing
        Me.cmbTipoNovedad.Location = New System.Drawing.Point(633, 66)
        Me.cmbTipoNovedad.Name = "cmbTipoNovedad"
        Me.cmbTipoNovedad.Size = New System.Drawing.Size(146, 21)
        Me.cmbTipoNovedad.TabIndex = 13
        '
        'chbCrearCRM
        '
        Me.chbCrearCRM.AutoSize = True
        Me.chbCrearCRM.BindearPropiedadControl = Nothing
        Me.chbCrearCRM.BindearPropiedadEntidad = Nothing
        Me.chbCrearCRM.ForeColorFocus = System.Drawing.Color.Red
        Me.chbCrearCRM.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbCrearCRM.IsPK = False
        Me.chbCrearCRM.IsRequired = False
        Me.chbCrearCRM.Key = Nothing
        Me.chbCrearCRM.LabelAsoc = Nothing
        Me.chbCrearCRM.Location = New System.Drawing.Point(499, 68)
        Me.chbCrearCRM.Name = "chbCrearCRM"
        Me.chbCrearCRM.Size = New System.Drawing.Size(128, 17)
        Me.chbCrearCRM.TabIndex = 12
        Me.chbCrearCRM.Text = "Crear CRM en tablero"
        Me.chbCrearCRM.UseVisualStyleBackColor = True
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
        Me.cmbDescripcionCorte.Location = New System.Drawing.Point(393, 66)
        Me.cmbDescripcionCorte.Name = "cmbDescripcionCorte"
        Me.cmbDescripcionCorte.Size = New System.Drawing.Size(96, 21)
        Me.cmbDescripcionCorte.TabIndex = 11
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.LabelAsoc = Nothing
        Me.Label1.Location = New System.Drawing.Point(295, 70)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(91, 13)
        Me.Label1.TabIndex = 10
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
        Me.cboAccion.Location = New System.Drawing.Point(55, 66)
        Me.cboAccion.Name = "cboAccion"
        Me.cboAccion.Size = New System.Drawing.Size(80, 21)
        Me.cboAccion.TabIndex = 7
        '
        'lblAccion
        '
        Me.lblAccion.AutoSize = True
        Me.lblAccion.LabelAsoc = Nothing
        Me.lblAccion.Location = New System.Drawing.Point(6, 70)
        Me.lblAccion.Name = "lblAccion"
        Me.lblAccion.Size = New System.Drawing.Size(40, 13)
        Me.lblAccion.TabIndex = 6
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
        Me.cboEstado.Location = New System.Drawing.Point(189, 66)
        Me.cboEstado.Name = "cboEstado"
        Me.cboEstado.Size = New System.Drawing.Size(96, 21)
        Me.cboEstado.TabIndex = 9
        '
        'lblEstado
        '
        Me.lblEstado.AutoSize = True
        Me.lblEstado.LabelAsoc = Nothing
        Me.lblEstado.Location = New System.Drawing.Point(145, 70)
        Me.lblEstado.Name = "lblEstado"
        Me.lblEstado.Size = New System.Drawing.Size(40, 13)
        Me.lblEstado.TabIndex = 8
        Me.lblEstado.Text = "Estado"
        '
        'txtRangoCeldas
        '
        Me.txtRangoCeldas.Location = New System.Drawing.Point(753, 26)
        Me.txtRangoCeldas.Name = "txtRangoCeldas"
        Me.txtRangoCeldas.Size = New System.Drawing.Size(89, 20)
        Me.txtRangoCeldas.TabIndex = 4
        Me.txtRangoCeldas.Text = "An : Tn"
        Me.txtRangoCeldas.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'lblEjemplos
        '
        Me.lblEjemplos.AutoSize = True
        Me.lblEjemplos.LabelAsoc = Nothing
        Me.lblEjemplos.Location = New System.Drawing.Point(741, 49)
        Me.lblEjemplos.Name = "lblEjemplos"
        Me.lblEjemplos.Size = New System.Drawing.Size(101, 13)
        Me.lblEjemplos.TabIndex = 5
        Me.lblEjemplos.Text = "Ejemplo:  A1 : U200"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.LabelAsoc = Nothing
        Me.Label3.Location = New System.Drawing.Point(662, 29)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(88, 13)
        Me.Label3.TabIndex = 3
        Me.Label3.Text = "Rango de celdas"
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
        Me.txtArchivoOrigen.Location = New System.Drawing.Point(55, 26)
        Me.txtArchivoOrigen.Name = "txtArchivoOrigen"
        Me.txtArchivoOrigen.Size = New System.Drawing.Size(491, 20)
        Me.txtArchivoOrigen.TabIndex = 1
        '
        'lblArchivo
        '
        Me.lblArchivo.AutoSize = True
        Me.lblArchivo.LabelAsoc = Nothing
        Me.lblArchivo.Location = New System.Drawing.Point(6, 30)
        Me.lblArchivo.Name = "lblArchivo"
        Me.lblArchivo.Size = New System.Drawing.Size(43, 13)
        Me.lblArchivo.TabIndex = 0
        Me.lblArchivo.Text = "Archivo"
        '
        'btnExaminar
        '
        Me.btnExaminar.Image = Global.Eniac.Win.My.Resources.Resources.folder_32
        Me.btnExaminar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnExaminar.Location = New System.Drawing.Point(552, 15)
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
        Me.btnMostrar.Location = New System.Drawing.Point(848, 35)
        Me.btnMostrar.Name = "btnMostrar"
        Me.btnMostrar.Size = New System.Drawing.Size(107, 45)
        Me.btnMostrar.TabIndex = 14
        Me.btnMostrar.Text = "&Mostrar (F4)"
        Me.btnMostrar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnMostrar.UseVisualStyleBackColor = False
        '
        'dgvDetalle
        '
        Me.dgvDetalle.AllowUserToAddRows = False
        Me.dgvDetalle.AllowUserToDeleteRows = False
        Me.dgvDetalle.AllowUserToResizeRows = False
        Me.dgvDetalle.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvDetalle.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvDetalle.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Importa, Me.Accion, Me.CodigoCliente, Me.NombreCliente, Me.Direccion, Me.IdLocalidad, Me.Telefono, Me.Celular, Me.CorreoElectronico, Me.NombreCategoria, Me.NombreCategoriaFiscal, Me.NombreVendedor, Me.NombreListaPrecios, Me.NombreZonaGeografica, Me.CUIT, Me.TipoDocCliente, Me.NroDocCliente, Me.FechaAlta, Me.NombreDeFantasia, Me.Twitter, Me.Observacion, Me.Sexo, Me.Mensaje})
        Me.dgvDetalle.Location = New System.Drawing.Point(12, 133)
        Me.dgvDetalle.Name = "dgvDetalle"
        Me.dgvDetalle.ReadOnly = True
        Me.dgvDetalle.RowHeadersWidth = 15
        Me.dgvDetalle.Size = New System.Drawing.Size(960, 379)
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
        Me.Accion.Width = 50
        '
        'CodigoCliente
        '
        Me.CodigoCliente.DataPropertyName = "CodigoCliente"
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.CodigoCliente.DefaultCellStyle = DataGridViewCellStyle2
        Me.CodigoCliente.HeaderText = "Codigo"
        Me.CodigoCliente.Name = "CodigoCliente"
        Me.CodigoCliente.ReadOnly = True
        Me.CodigoCliente.Width = 70
        '
        'NombreCliente
        '
        Me.NombreCliente.DataPropertyName = "NombreCliente"
        Me.NombreCliente.HeaderText = "Nombre Cliente"
        Me.NombreCliente.Name = "NombreCliente"
        Me.NombreCliente.ReadOnly = True
        Me.NombreCliente.Width = 230
        '
        'Direccion
        '
        Me.Direccion.DataPropertyName = "Direccion"
        Me.Direccion.HeaderText = "Direccion"
        Me.Direccion.Name = "Direccion"
        Me.Direccion.ReadOnly = True
        Me.Direccion.Width = 200
        '
        'IdLocalidad
        '
        Me.IdLocalidad.DataPropertyName = "IdLocalidad"
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.IdLocalidad.DefaultCellStyle = DataGridViewCellStyle3
        Me.IdLocalidad.HeaderText = "C.P."
        Me.IdLocalidad.Name = "IdLocalidad"
        Me.IdLocalidad.ReadOnly = True
        Me.IdLocalidad.Width = 40
        '
        'Telefono
        '
        Me.Telefono.DataPropertyName = "Telefono"
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle4.Format = "N2"
        Me.Telefono.DefaultCellStyle = DataGridViewCellStyle4
        Me.Telefono.HeaderText = "Telefono"
        Me.Telefono.Name = "Telefono"
        Me.Telefono.ReadOnly = True
        '
        'Celular
        '
        Me.Celular.DataPropertyName = "Celular"
        DataGridViewCellStyle5.NullValue = Nothing
        Me.Celular.DefaultCellStyle = DataGridViewCellStyle5
        Me.Celular.HeaderText = "Celular"
        Me.Celular.Name = "Celular"
        Me.Celular.ReadOnly = True
        '
        'CorreoElectronico
        '
        Me.CorreoElectronico.DataPropertyName = "CorreoElectronico"
        Me.CorreoElectronico.HeaderText = "Correo Electronico"
        Me.CorreoElectronico.Name = "CorreoElectronico"
        Me.CorreoElectronico.ReadOnly = True
        '
        'NombreCategoria
        '
        Me.NombreCategoria.DataPropertyName = "NombreCategoria"
        Me.NombreCategoria.HeaderText = "Categoria"
        Me.NombreCategoria.Name = "NombreCategoria"
        Me.NombreCategoria.ReadOnly = True
        '
        'NombreCategoriaFiscal
        '
        Me.NombreCategoriaFiscal.DataPropertyName = "NombreCategoriaFiscal"
        Me.NombreCategoriaFiscal.HeaderText = "Categoria Fiscal"
        Me.NombreCategoriaFiscal.Name = "NombreCategoriaFiscal"
        Me.NombreCategoriaFiscal.ReadOnly = True
        '
        'NombreVendedor
        '
        Me.NombreVendedor.DataPropertyName = "NombreVendedor"
        Me.NombreVendedor.HeaderText = "Vendedor"
        Me.NombreVendedor.Name = "NombreVendedor"
        Me.NombreVendedor.ReadOnly = True
        '
        'NombreListaPrecios
        '
        Me.NombreListaPrecios.DataPropertyName = "NombreListaPrecios"
        Me.NombreListaPrecios.HeaderText = "Lista de Precios"
        Me.NombreListaPrecios.Name = "NombreListaPrecios"
        Me.NombreListaPrecios.ReadOnly = True
        '
        'NombreZonaGeografica
        '
        Me.NombreZonaGeografica.DataPropertyName = "NombreZonaGeografica"
        Me.NombreZonaGeografica.HeaderText = "Zona Geografica"
        Me.NombreZonaGeografica.Name = "NombreZonaGeografica"
        Me.NombreZonaGeografica.ReadOnly = True
        '
        'CUIT
        '
        Me.CUIT.DataPropertyName = "CUIT"
        Me.CUIT.HeaderText = "CUIT"
        Me.CUIT.Name = "CUIT"
        Me.CUIT.ReadOnly = True
        '
        'TipoDocCliente
        '
        Me.TipoDocCliente.DataPropertyName = "TipoDocCliente"
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.TipoDocCliente.DefaultCellStyle = DataGridViewCellStyle6
        Me.TipoDocCliente.HeaderText = "Tipo Doc"
        Me.TipoDocCliente.Name = "TipoDocCliente"
        Me.TipoDocCliente.ReadOnly = True
        Me.TipoDocCliente.Width = 50
        '
        'NroDocCliente
        '
        Me.NroDocCliente.DataPropertyName = "NroDocCliente"
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.NroDocCliente.DefaultCellStyle = DataGridViewCellStyle7
        Me.NroDocCliente.HeaderText = "Nro. Doc."
        Me.NroDocCliente.Name = "NroDocCliente"
        Me.NroDocCliente.ReadOnly = True
        Me.NroDocCliente.Width = 80
        '
        'FechaAlta
        '
        Me.FechaAlta.DataPropertyName = "FechaAlta"
        Me.FechaAlta.HeaderText = "Fecha Alta"
        Me.FechaAlta.Name = "FechaAlta"
        Me.FechaAlta.ReadOnly = True
        '
        'NombreDeFantasia
        '
        Me.NombreDeFantasia.DataPropertyName = "NombreDeFantasia"
        Me.NombreDeFantasia.HeaderText = "Nombre Fantasia"
        Me.NombreDeFantasia.Name = "NombreDeFantasia"
        Me.NombreDeFantasia.ReadOnly = True
        '
        'Twitter
        '
        Me.Twitter.DataPropertyName = "Twitter"
        Me.Twitter.HeaderText = "Twitter"
        Me.Twitter.Name = "Twitter"
        Me.Twitter.ReadOnly = True
        '
        'Observacion
        '
        Me.Observacion.DataPropertyName = "Observacion"
        Me.Observacion.HeaderText = "Observacion"
        Me.Observacion.Name = "Observacion"
        Me.Observacion.ReadOnly = True
        Me.Observacion.Width = 150
        '
        'Sexo
        '
        Me.Sexo.DataPropertyName = "Sexo"
        Me.Sexo.HeaderText = "Sexo"
        Me.Sexo.Name = "Sexo"
        Me.Sexo.ReadOnly = True
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
        Me.prbImportando.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.prbImportando.Location = New System.Drawing.Point(12, 514)
        Me.prbImportando.Name = "prbImportando"
        Me.prbImportando.Size = New System.Drawing.Size(960, 23)
        Me.prbImportando.Style = System.Windows.Forms.ProgressBarStyle.Continuous
        Me.prbImportando.TabIndex = 2
        '
        'ImportarClientesExcel
        '
        Me.AcceptButton = Me.btnMostrar
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(984, 562)
        Me.Controls.Add(Me.prbImportando)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.tstBarra)
        Me.Controls.Add(Me.dgvDetalle)
        Me.Controls.Add(Me.grbPendientes)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.Name = "ImportarClientesExcel"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Importar Clientes desde Excel"
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
   Friend WithEvents txtRangoCeldas As System.Windows.Forms.TextBox
   Friend WithEvents lblEjemplos As Eniac.Controles.Label
   Friend WithEvents Label3 As Eniac.Controles.Label
   Friend WithEvents cboEstado As Eniac.Controles.ComboBox
   Friend WithEvents lblEstado As Eniac.Controles.Label
   Friend WithEvents cboAccion As Eniac.Controles.ComboBox
   Friend WithEvents lblAccion As Eniac.Controles.Label
   Friend WithEvents cmbDescripcionCorte As Eniac.Controles.ComboBox
   Friend WithEvents Label1 As Eniac.Controles.Label
   Friend WithEvents Importa As System.Windows.Forms.DataGridViewCheckBoxColumn
   Friend WithEvents Accion As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents CodigoCliente As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents NombreCliente As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents Direccion As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents IdLocalidad As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents Telefono As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents Celular As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents CorreoElectronico As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents NombreCategoria As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents NombreCategoriaFiscal As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents NombreVendedor As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents NombreListaPrecios As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents NombreZonaGeografica As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents CUIT As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents TipoDocCliente As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents NroDocCliente As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents FechaAlta As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents NombreDeFantasia As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents Twitter As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents Observacion As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents Sexo As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents Mensaje As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents chbCrearCRM As Controles.CheckBox
   Friend WithEvents cmbTipoNovedad As Controles.ComboBox
End Class
