<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ImportarClientesCalidad
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
      Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
      Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
      Dim DataGridViewCellStyle10 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
      Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ImportarClientesCalidad))
      Me.grbPendientes = New System.Windows.Forms.GroupBox()
      Me.chbImportarChasisEnUso = New Eniac.Controles.CheckBox()
      Me.chbImportarChasis = New Eniac.Controles.CheckBox()
      Me.ChbImportarModelos = New Eniac.Controles.CheckBox()
      Me.chbImportarClientes = New Eniac.Controles.CheckBox()
      Me.cboAccion = New Eniac.Controles.ComboBox()
      Me.lblAccion = New Eniac.Controles.Label()
      Me.cboEstado = New Eniac.Controles.ComboBox()
      Me.lblEstado = New Eniac.Controles.Label()
      Me.cmbDescripcionCorte = New Eniac.Controles.ComboBox()
      Me.Label1 = New Eniac.Controles.Label()
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
      Me.Mensaje = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.CodigoCliente = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.CodigoClienteLetras = New System.Windows.Forms.DataGridViewTextBoxColumn()
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
      Me.tstBarra = New System.Windows.Forms.ToolStrip()
      Me.tsbRefrescar = New System.Windows.Forms.ToolStripButton()
      Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
      Me.tsbImportar = New System.Windows.Forms.ToolStripButton()
      Me.tsbGrabar = New System.Windows.Forms.ToolStripButton()
      Me.toolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
      Me.tsbSalir = New System.Windows.Forms.ToolStripButton()
      Me.prbImportando = New System.Windows.Forms.ProgressBar()
      Me.TabControl1 = New System.Windows.Forms.TabControl()
      Me.TabPage1 = New System.Windows.Forms.TabPage()
      Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
      Me.tssRegistros = New System.Windows.Forms.ToolStripStatusLabel()
      Me.TabPage2 = New System.Windows.Forms.TabPage()
      Me.StatusStrip2 = New System.Windows.Forms.StatusStrip()
      Me.tssRegistrosModelos = New System.Windows.Forms.ToolStripStatusLabel()
      Me.dgvModelos = New Eniac.Controles.DataGridView()
      Me.DataGridViewCheckBoxColumn1 = New System.Windows.Forms.DataGridViewCheckBoxColumn()
      Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.CodigoProductoModelo = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.NombreProductoModelo = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.TabPage3 = New System.Windows.Forms.TabPage()
      Me.StatusStrip3 = New System.Windows.Forms.StatusStrip()
      Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel()
      Me.dgvChasis = New Eniac.Controles.DataGridView()
      Me.DataGridViewCheckBoxColumn2 = New System.Windows.Forms.DataGridViewCheckBoxColumn()
      Me.DataGridViewTextBoxColumn3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.DataGridViewTextBoxColumn4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.DataGridViewTextBoxColumn5 = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.DataGridViewTextBoxColumn6 = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.NumeroChasis = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.NroDeMotor = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.tbpChasisEnUso = New System.Windows.Forms.TabPage()
      Me.StatusStrip4 = New System.Windows.Forms.StatusStrip()
      Me.ToolStripStatusLabel2 = New System.Windows.Forms.ToolStripStatusLabel()
      Me.dgvChasisEnUso = New Eniac.Controles.DataGridView()
      Me.DataGridViewCheckBoxColumn3 = New System.Windows.Forms.DataGridViewCheckBoxColumn()
      Me.DataGridViewTextBoxColumn7 = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.DataGridViewTextBoxColumn8 = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.DataGridViewTextBoxColumn9 = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.DataGridViewTextBoxColumn10 = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.DataGridViewTextBoxColumn11 = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.DataGridViewTextBoxColumn12 = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.grbPendientes.SuspendLayout()
      CType(Me.dgvDetalle, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.tstBarra.SuspendLayout()
      Me.TabControl1.SuspendLayout()
      Me.TabPage1.SuspendLayout()
      Me.StatusStrip1.SuspendLayout()
      Me.TabPage2.SuspendLayout()
      Me.StatusStrip2.SuspendLayout()
      CType(Me.dgvModelos, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.TabPage3.SuspendLayout()
      Me.StatusStrip3.SuspendLayout()
      CType(Me.dgvChasis, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.tbpChasisEnUso.SuspendLayout()
      Me.StatusStrip4.SuspendLayout()
      CType(Me.dgvChasisEnUso, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.SuspendLayout()
      '
      'grbPendientes
      '
      Me.grbPendientes.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.grbPendientes.Controls.Add(Me.chbImportarChasisEnUso)
      Me.grbPendientes.Controls.Add(Me.chbImportarChasis)
      Me.grbPendientes.Controls.Add(Me.ChbImportarModelos)
      Me.grbPendientes.Controls.Add(Me.chbImportarClientes)
      Me.grbPendientes.Controls.Add(Me.cboAccion)
      Me.grbPendientes.Controls.Add(Me.lblAccion)
      Me.grbPendientes.Controls.Add(Me.cboEstado)
      Me.grbPendientes.Controls.Add(Me.lblEstado)
      Me.grbPendientes.Controls.Add(Me.cmbDescripcionCorte)
      Me.grbPendientes.Controls.Add(Me.Label1)
      Me.grbPendientes.Controls.Add(Me.txtRangoCeldas)
      Me.grbPendientes.Controls.Add(Me.lblEjemplos)
      Me.grbPendientes.Controls.Add(Me.Label3)
      Me.grbPendientes.Controls.Add(Me.txtArchivoOrigen)
      Me.grbPendientes.Controls.Add(Me.lblArchivo)
      Me.grbPendientes.Controls.Add(Me.btnExaminar)
      Me.grbPendientes.Location = New System.Drawing.Point(12, 25)
      Me.grbPendientes.Name = "grbPendientes"
      Me.grbPendientes.Size = New System.Drawing.Size(954, 59)
      Me.grbPendientes.TabIndex = 0
      Me.grbPendientes.TabStop = False
      '
      'chbImportarChasisEnUso
      '
      Me.chbImportarChasisEnUso.AutoSize = True
      Me.chbImportarChasisEnUso.BindearPropiedadControl = Nothing
      Me.chbImportarChasisEnUso.BindearPropiedadEntidad = Nothing
      Me.chbImportarChasisEnUso.ForeColorFocus = System.Drawing.Color.Red
      Me.chbImportarChasisEnUso.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
      Me.chbImportarChasisEnUso.IsPK = False
      Me.chbImportarChasisEnUso.IsRequired = False
      Me.chbImportarChasisEnUso.Key = Nothing
      Me.chbImportarChasisEnUso.LabelAsoc = Nothing
      Me.chbImportarChasisEnUso.Location = New System.Drawing.Point(781, 27)
      Me.chbImportarChasisEnUso.Name = "chbImportarChasisEnUso"
      Me.chbImportarChasisEnUso.Size = New System.Drawing.Size(133, 17)
      Me.chbImportarChasisEnUso.TabIndex = 19
      Me.chbImportarChasisEnUso.Text = "Importar Chasis en uso"
      Me.chbImportarChasisEnUso.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
      Me.chbImportarChasisEnUso.UseVisualStyleBackColor = True
      Me.chbImportarChasisEnUso.Visible = False
      '
      'chbImportarChasis
      '
      Me.chbImportarChasis.AutoSize = True
      Me.chbImportarChasis.BindearPropiedadControl = Nothing
      Me.chbImportarChasis.BindearPropiedadEntidad = Nothing
      Me.chbImportarChasis.Checked = True
      Me.chbImportarChasis.CheckState = System.Windows.Forms.CheckState.Checked
      Me.chbImportarChasis.ForeColorFocus = System.Drawing.Color.Red
      Me.chbImportarChasis.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
      Me.chbImportarChasis.IsPK = False
      Me.chbImportarChasis.IsRequired = False
      Me.chbImportarChasis.Key = Nothing
      Me.chbImportarChasis.LabelAsoc = Nothing
      Me.chbImportarChasis.Location = New System.Drawing.Point(264, 25)
      Me.chbImportarChasis.Name = "chbImportarChasis"
      Me.chbImportarChasis.Size = New System.Drawing.Size(98, 17)
      Me.chbImportarChasis.TabIndex = 18
      Me.chbImportarChasis.Text = "Importar Chasis"
      Me.chbImportarChasis.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
      Me.chbImportarChasis.UseVisualStyleBackColor = True
      '
      'ChbImportarModelos
      '
      Me.ChbImportarModelos.AutoSize = True
      Me.ChbImportarModelos.BindearPropiedadControl = Nothing
      Me.ChbImportarModelos.BindearPropiedadEntidad = Nothing
      Me.ChbImportarModelos.Checked = True
      Me.ChbImportarModelos.CheckState = System.Windows.Forms.CheckState.Checked
      Me.ChbImportarModelos.ForeColorFocus = System.Drawing.Color.Red
      Me.ChbImportarModelos.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
      Me.ChbImportarModelos.IsPK = False
      Me.ChbImportarModelos.IsRequired = False
      Me.ChbImportarModelos.Key = Nothing
      Me.ChbImportarModelos.LabelAsoc = Nothing
      Me.ChbImportarModelos.Location = New System.Drawing.Point(135, 25)
      Me.ChbImportarModelos.Name = "ChbImportarModelos"
      Me.ChbImportarModelos.Size = New System.Drawing.Size(107, 17)
      Me.ChbImportarModelos.TabIndex = 17
      Me.ChbImportarModelos.Text = "Importar Modelos"
      Me.ChbImportarModelos.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
      Me.ChbImportarModelos.UseVisualStyleBackColor = True
      '
      'chbImportarClientes
      '
      Me.chbImportarClientes.AutoSize = True
      Me.chbImportarClientes.BindearPropiedadControl = Nothing
      Me.chbImportarClientes.BindearPropiedadEntidad = Nothing
      Me.chbImportarClientes.Checked = True
      Me.chbImportarClientes.CheckState = System.Windows.Forms.CheckState.Checked
      Me.chbImportarClientes.ForeColorFocus = System.Drawing.Color.Red
      Me.chbImportarClientes.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
      Me.chbImportarClientes.IsPK = False
      Me.chbImportarClientes.IsRequired = False
      Me.chbImportarClientes.Key = Nothing
      Me.chbImportarClientes.LabelAsoc = Nothing
      Me.chbImportarClientes.Location = New System.Drawing.Point(13, 25)
      Me.chbImportarClientes.Name = "chbImportarClientes"
      Me.chbImportarClientes.Size = New System.Drawing.Size(104, 17)
      Me.chbImportarClientes.TabIndex = 16
      Me.chbImportarClientes.Text = "Importar Clientes"
      Me.chbImportarClientes.UseVisualStyleBackColor = True
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
      Me.cboAccion.Location = New System.Drawing.Point(499, 23)
      Me.cboAccion.Name = "cboAccion"
      Me.cboAccion.Size = New System.Drawing.Size(80, 21)
      Me.cboAccion.TabIndex = 9
      '
      'lblAccion
      '
      Me.lblAccion.AutoSize = True
      Me.lblAccion.LabelAsoc = Nothing
      Me.lblAccion.Location = New System.Drawing.Point(452, 27)
      Me.lblAccion.Name = "lblAccion"
      Me.lblAccion.Size = New System.Drawing.Size(40, 13)
      Me.lblAccion.TabIndex = 8
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
      Me.cboEstado.Location = New System.Drawing.Point(659, 23)
      Me.cboEstado.Name = "cboEstado"
      Me.cboEstado.Size = New System.Drawing.Size(96, 21)
      Me.cboEstado.TabIndex = 11
      '
      'lblEstado
      '
      Me.lblEstado.AutoSize = True
      Me.lblEstado.LabelAsoc = Nothing
      Me.lblEstado.Location = New System.Drawing.Point(615, 27)
      Me.lblEstado.Name = "lblEstado"
      Me.lblEstado.Size = New System.Drawing.Size(40, 13)
      Me.lblEstado.TabIndex = 10
      Me.lblEstado.Text = "Estado"
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
      Me.cmbDescripcionCorte.Location = New System.Drawing.Point(439, 72)
      Me.cmbDescripcionCorte.Name = "cmbDescripcionCorte"
      Me.cmbDescripcionCorte.Size = New System.Drawing.Size(96, 21)
      Me.cmbDescripcionCorte.TabIndex = 13
      Me.cmbDescripcionCorte.Visible = False
      '
      'Label1
      '
      Me.Label1.AutoSize = True
      Me.Label1.LabelAsoc = Nothing
      Me.Label1.Location = New System.Drawing.Point(341, 76)
      Me.Label1.Name = "Label1"
      Me.Label1.Size = New System.Drawing.Size(91, 13)
      Me.Label1.TabIndex = 12
      Me.Label1.Text = "Descripción Corte"
      Me.Label1.Visible = False
      '
      'txtRangoCeldas
      '
      Me.txtRangoCeldas.Location = New System.Drawing.Point(758, 62)
      Me.txtRangoCeldas.Name = "txtRangoCeldas"
      Me.txtRangoCeldas.Size = New System.Drawing.Size(89, 20)
      Me.txtRangoCeldas.TabIndex = 4
      Me.txtRangoCeldas.Text = "An : Sn"
      Me.txtRangoCeldas.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
      Me.txtRangoCeldas.Visible = False
      '
      'lblEjemplos
      '
      Me.lblEjemplos.AutoSize = True
      Me.lblEjemplos.LabelAsoc = Nothing
      Me.lblEjemplos.Location = New System.Drawing.Point(755, 76)
      Me.lblEjemplos.Name = "lblEjemplos"
      Me.lblEjemplos.Size = New System.Drawing.Size(100, 13)
      Me.lblEjemplos.TabIndex = 5
      Me.lblEjemplos.Text = "Ejemplo:  A1 : S200"
      Me.lblEjemplos.Visible = False
      '
      'Label3
      '
      Me.Label3.AutoSize = True
      Me.Label3.LabelAsoc = Nothing
      Me.Label3.Location = New System.Drawing.Point(667, 65)
      Me.Label3.Name = "Label3"
      Me.Label3.Size = New System.Drawing.Size(88, 13)
      Me.Label3.TabIndex = 3
      Me.Label3.Text = "Rango de celdas"
      Me.Label3.Visible = False
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
      Me.txtArchivoOrigen.Location = New System.Drawing.Point(57, 60)
      Me.txtArchivoOrigen.Name = "txtArchivoOrigen"
      Me.txtArchivoOrigen.Size = New System.Drawing.Size(499, 20)
      Me.txtArchivoOrigen.TabIndex = 1
      Me.txtArchivoOrigen.Visible = False
      '
      'lblArchivo
      '
      Me.lblArchivo.AutoSize = True
      Me.lblArchivo.LabelAsoc = Nothing
      Me.lblArchivo.Location = New System.Drawing.Point(10, 63)
      Me.lblArchivo.Name = "lblArchivo"
      Me.lblArchivo.Size = New System.Drawing.Size(43, 13)
      Me.lblArchivo.TabIndex = 0
      Me.lblArchivo.Text = "Archivo"
      Me.lblArchivo.Visible = False
      '
      'btnExaminar
      '
      Me.btnExaminar.Image = Global.Eniac.Win.My.Resources.Resources.folder_32
      Me.btnExaminar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
      Me.btnExaminar.Location = New System.Drawing.Point(562, 63)
      Me.btnExaminar.Name = "btnExaminar"
      Me.btnExaminar.Size = New System.Drawing.Size(104, 40)
      Me.btnExaminar.TabIndex = 2
      Me.btnExaminar.Text = "&Examinar..."
      Me.btnExaminar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      Me.btnExaminar.UseVisualStyleBackColor = True
      Me.btnExaminar.Visible = False
      '
      'btnMostrar
      '
      Me.btnMostrar.Image = Global.Eniac.Win.My.Resources.Resources.view
      Me.btnMostrar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
      Me.btnMostrar.Location = New System.Drawing.Point(805, 177)
      Me.btnMostrar.Name = "btnMostrar"
      Me.btnMostrar.Size = New System.Drawing.Size(90, 45)
      Me.btnMostrar.TabIndex = 16
      Me.btnMostrar.Text = "&Mostrar"
      Me.btnMostrar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      Me.btnMostrar.UseVisualStyleBackColor = False
      Me.btnMostrar.Visible = False
      '
      'dgvDetalle
      '
      Me.dgvDetalle.AllowUserToAddRows = False
      Me.dgvDetalle.AllowUserToDeleteRows = False
      Me.dgvDetalle.AllowUserToResizeRows = False
      Me.dgvDetalle.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
      Me.dgvDetalle.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Importa, Me.Accion, Me.Mensaje, Me.CodigoCliente, Me.CodigoClienteLetras, Me.NombreCliente, Me.Direccion, Me.IdLocalidad, Me.Telefono, Me.Celular, Me.CorreoElectronico, Me.NombreCategoria, Me.NombreCategoriaFiscal, Me.NombreVendedor, Me.NombreListaPrecios, Me.NombreZonaGeografica, Me.CUIT, Me.TipoDocCliente, Me.NroDocCliente, Me.FechaAlta, Me.NombreDeFantasia, Me.Twitter, Me.Observacion})
      Me.dgvDetalle.Location = New System.Drawing.Point(3, 3)
      Me.dgvDetalle.Name = "dgvDetalle"
      Me.dgvDetalle.ReadOnly = True
      Me.dgvDetalle.RowHeadersWidth = 15
      Me.dgvDetalle.Size = New System.Drawing.Size(947, 374)
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
      'Mensaje
      '
      Me.Mensaje.DataPropertyName = "Mensaje"
      Me.Mensaje.HeaderText = "Mensaje"
      Me.Mensaje.Name = "Mensaje"
      Me.Mensaje.ReadOnly = True
      Me.Mensaje.Width = 250
      '
      'CodigoCliente
      '
      Me.CodigoCliente.DataPropertyName = "CodigoCliente"
      DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
      Me.CodigoCliente.DefaultCellStyle = DataGridViewCellStyle2
      Me.CodigoCliente.HeaderText = "Codigo"
      Me.CodigoCliente.Name = "CodigoCliente"
      Me.CodigoCliente.ReadOnly = True
      Me.CodigoCliente.Visible = False
      Me.CodigoCliente.Width = 70
      '
      'CodigoClienteLetras
      '
      Me.CodigoClienteLetras.DataPropertyName = "CodigoClienteLetras"
      Me.CodigoClienteLetras.HeaderText = "Codigo Letras"
      Me.CodigoClienteLetras.Name = "CodigoClienteLetras"
      Me.CodigoClienteLetras.ReadOnly = True
      Me.CodigoClienteLetras.Width = 70
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
      'tstBarra
      '
      Me.tstBarra.AllowItemReorder = True
      Me.tstBarra.ImageScalingSize = New System.Drawing.Size(22, 22)
      Me.tstBarra.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsbRefrescar, Me.ToolStripSeparator1, Me.tsbImportar, Me.tsbGrabar, Me.toolStripSeparator3, Me.tsbSalir})
      Me.tstBarra.Location = New System.Drawing.Point(0, 0)
      Me.tstBarra.Name = "tstBarra"
      Me.tstBarra.Size = New System.Drawing.Size(984, 29)
      Me.tstBarra.TabIndex = 0
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
      Me.tsbImportar.Image = Global.Eniac.Win.My.Resources.Resources.administrator_add_32
      Me.tsbImportar.ImageTransparentColor = System.Drawing.Color.Magenta
      Me.tsbImportar.Name = "tsbImportar"
      Me.tsbImportar.Size = New System.Drawing.Size(143, 26)
      Me.tsbImportar.Text = "&Leer Tablas Bejerman"
      '
      'tsbGrabar
      '
      Me.tsbGrabar.Enabled = False
      Me.tsbGrabar.Image = Global.Eniac.Win.My.Resources.Resources.diskette_32
      Me.tsbGrabar.ImageTransparentColor = System.Drawing.Color.Magenta
      Me.tsbGrabar.Name = "tsbGrabar"
      Me.tsbGrabar.Size = New System.Drawing.Size(68, 26)
      Me.tsbGrabar.Text = "&Grabar"
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
      'prbImportando
      '
      Me.prbImportando.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.prbImportando.Location = New System.Drawing.Point(12, 532)
      Me.prbImportando.Name = "prbImportando"
      Me.prbImportando.Size = New System.Drawing.Size(960, 23)
      Me.prbImportando.Style = System.Windows.Forms.ProgressBarStyle.Continuous
      Me.prbImportando.TabIndex = 3
      '
      'TabControl1
      '
      Me.TabControl1.Controls.Add(Me.TabPage1)
      Me.TabControl1.Controls.Add(Me.TabPage2)
      Me.TabControl1.Controls.Add(Me.TabPage3)
      Me.TabControl1.Controls.Add(Me.tbpChasisEnUso)
      Me.TabControl1.Location = New System.Drawing.Point(12, 87)
      Me.TabControl1.Name = "TabControl1"
      Me.TabControl1.SelectedIndex = 0
      Me.TabControl1.Size = New System.Drawing.Size(961, 431)
      Me.TabControl1.TabIndex = 17
      '
      'TabPage1
      '
      Me.TabPage1.Controls.Add(Me.StatusStrip1)
      Me.TabPage1.Controls.Add(Me.dgvDetalle)
      Me.TabPage1.Location = New System.Drawing.Point(4, 22)
      Me.TabPage1.Name = "TabPage1"
      Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
      Me.TabPage1.Size = New System.Drawing.Size(953, 405)
      Me.TabPage1.TabIndex = 0
      Me.TabPage1.Text = "Clientes"
      Me.TabPage1.UseVisualStyleBackColor = True
      '
      'StatusStrip1
      '
      Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tssRegistros})
      Me.StatusStrip1.Location = New System.Drawing.Point(3, 380)
      Me.StatusStrip1.Name = "StatusStrip1"
      Me.StatusStrip1.Size = New System.Drawing.Size(947, 22)
      Me.StatusStrip1.TabIndex = 6
      Me.StatusStrip1.Text = "StatusStrip1"
      '
      'tssRegistros
      '
      Me.tssRegistros.Name = "tssRegistros"
      Me.tssRegistros.Size = New System.Drawing.Size(932, 17)
      Me.tssRegistros.Spring = True
      Me.tssRegistros.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'TabPage2
      '
      Me.TabPage2.Controls.Add(Me.StatusStrip2)
      Me.TabPage2.Controls.Add(Me.dgvModelos)
      Me.TabPage2.Location = New System.Drawing.Point(4, 22)
      Me.TabPage2.Name = "TabPage2"
      Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
      Me.TabPage2.Size = New System.Drawing.Size(953, 405)
      Me.TabPage2.TabIndex = 1
      Me.TabPage2.Text = "Modelos"
      Me.TabPage2.UseVisualStyleBackColor = True
      '
      'StatusStrip2
      '
      Me.StatusStrip2.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tssRegistrosModelos})
      Me.StatusStrip2.Location = New System.Drawing.Point(3, 380)
      Me.StatusStrip2.Name = "StatusStrip2"
      Me.StatusStrip2.Size = New System.Drawing.Size(947, 22)
      Me.StatusStrip2.TabIndex = 7
      Me.StatusStrip2.Text = "StatusStrip2"
      '
      'tssRegistrosModelos
      '
      Me.tssRegistrosModelos.Name = "tssRegistrosModelos"
      Me.tssRegistrosModelos.Size = New System.Drawing.Size(932, 17)
      Me.tssRegistrosModelos.Spring = True
      Me.tssRegistrosModelos.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'dgvModelos
      '
      Me.dgvModelos.AllowUserToAddRows = False
      Me.dgvModelos.AllowUserToDeleteRows = False
      Me.dgvModelos.AllowUserToResizeRows = False
      Me.dgvModelos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
      Me.dgvModelos.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewCheckBoxColumn1, Me.DataGridViewTextBoxColumn1, Me.DataGridViewTextBoxColumn2, Me.CodigoProductoModelo, Me.NombreProductoModelo})
      Me.dgvModelos.Location = New System.Drawing.Point(3, 3)
      Me.dgvModelos.Name = "dgvModelos"
      Me.dgvModelos.ReadOnly = True
      Me.dgvModelos.RowHeadersWidth = 15
      Me.dgvModelos.Size = New System.Drawing.Size(947, 374)
      Me.dgvModelos.TabIndex = 2
      '
      'DataGridViewCheckBoxColumn1
      '
      Me.DataGridViewCheckBoxColumn1.DataPropertyName = "Importa"
      Me.DataGridViewCheckBoxColumn1.HeaderText = "Pasa"
      Me.DataGridViewCheckBoxColumn1.Name = "DataGridViewCheckBoxColumn1"
      Me.DataGridViewCheckBoxColumn1.ReadOnly = True
      Me.DataGridViewCheckBoxColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
      Me.DataGridViewCheckBoxColumn1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic
      Me.DataGridViewCheckBoxColumn1.Width = 40
      '
      'DataGridViewTextBoxColumn1
      '
      Me.DataGridViewTextBoxColumn1.DataPropertyName = "Accion"
      DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
      Me.DataGridViewTextBoxColumn1.DefaultCellStyle = DataGridViewCellStyle8
      Me.DataGridViewTextBoxColumn1.HeaderText = "Accion"
      Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
      Me.DataGridViewTextBoxColumn1.ReadOnly = True
      Me.DataGridViewTextBoxColumn1.Width = 50
      '
      'DataGridViewTextBoxColumn2
      '
      Me.DataGridViewTextBoxColumn2.DataPropertyName = "Mensaje"
      Me.DataGridViewTextBoxColumn2.HeaderText = "Mensaje"
      Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
      Me.DataGridViewTextBoxColumn2.ReadOnly = True
      Me.DataGridViewTextBoxColumn2.Width = 250
      '
      'CodigoProductoModelo
      '
      Me.CodigoProductoModelo.DataPropertyName = "CodigoProductoModelo"
      Me.CodigoProductoModelo.HeaderText = "Codigo Modelo"
      Me.CodigoProductoModelo.Name = "CodigoProductoModelo"
      Me.CodigoProductoModelo.ReadOnly = True
      '
      'NombreProductoModelo
      '
      Me.NombreProductoModelo.DataPropertyName = "NombreProductoModelo"
      Me.NombreProductoModelo.HeaderText = "Nombre Modelo"
      Me.NombreProductoModelo.Name = "NombreProductoModelo"
      Me.NombreProductoModelo.ReadOnly = True
      Me.NombreProductoModelo.Width = 350
      '
      'TabPage3
      '
      Me.TabPage3.BackColor = System.Drawing.SystemColors.Control
      Me.TabPage3.Controls.Add(Me.StatusStrip3)
      Me.TabPage3.Controls.Add(Me.dgvChasis)
      Me.TabPage3.Location = New System.Drawing.Point(4, 22)
      Me.TabPage3.Name = "TabPage3"
      Me.TabPage3.Size = New System.Drawing.Size(953, 405)
      Me.TabPage3.TabIndex = 2
      Me.TabPage3.Text = "Chasis"
      '
      'StatusStrip3
      '
      Me.StatusStrip3.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripStatusLabel1})
      Me.StatusStrip3.Location = New System.Drawing.Point(0, 383)
      Me.StatusStrip3.Name = "StatusStrip3"
      Me.StatusStrip3.Size = New System.Drawing.Size(953, 22)
      Me.StatusStrip3.TabIndex = 8
      Me.StatusStrip3.Text = "StatusStrip3"
      '
      'ToolStripStatusLabel1
      '
      Me.ToolStripStatusLabel1.Name = "ToolStripStatusLabel1"
      Me.ToolStripStatusLabel1.Size = New System.Drawing.Size(938, 17)
      Me.ToolStripStatusLabel1.Spring = True
      Me.ToolStripStatusLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'dgvChasis
      '
      Me.dgvChasis.AllowUserToAddRows = False
      Me.dgvChasis.AllowUserToDeleteRows = False
      Me.dgvChasis.AllowUserToResizeRows = False
      Me.dgvChasis.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
      Me.dgvChasis.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewCheckBoxColumn2, Me.DataGridViewTextBoxColumn3, Me.DataGridViewTextBoxColumn4, Me.DataGridViewTextBoxColumn5, Me.DataGridViewTextBoxColumn6, Me.NumeroChasis, Me.NroDeMotor})
      Me.dgvChasis.Location = New System.Drawing.Point(3, 3)
      Me.dgvChasis.Name = "dgvChasis"
      Me.dgvChasis.ReadOnly = True
      Me.dgvChasis.RowHeadersWidth = 15
      Me.dgvChasis.Size = New System.Drawing.Size(947, 377)
      Me.dgvChasis.TabIndex = 3
      '
      'DataGridViewCheckBoxColumn2
      '
      Me.DataGridViewCheckBoxColumn2.DataPropertyName = "Importa"
      Me.DataGridViewCheckBoxColumn2.HeaderText = "Pasa"
      Me.DataGridViewCheckBoxColumn2.Name = "DataGridViewCheckBoxColumn2"
      Me.DataGridViewCheckBoxColumn2.ReadOnly = True
      Me.DataGridViewCheckBoxColumn2.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
      Me.DataGridViewCheckBoxColumn2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic
      Me.DataGridViewCheckBoxColumn2.Width = 40
      '
      'DataGridViewTextBoxColumn3
      '
      Me.DataGridViewTextBoxColumn3.DataPropertyName = "Accion"
      DataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
      Me.DataGridViewTextBoxColumn3.DefaultCellStyle = DataGridViewCellStyle9
      Me.DataGridViewTextBoxColumn3.HeaderText = "Accion"
      Me.DataGridViewTextBoxColumn3.Name = "DataGridViewTextBoxColumn3"
      Me.DataGridViewTextBoxColumn3.ReadOnly = True
      Me.DataGridViewTextBoxColumn3.Width = 50
      '
      'DataGridViewTextBoxColumn4
      '
      Me.DataGridViewTextBoxColumn4.DataPropertyName = "Mensaje"
      Me.DataGridViewTextBoxColumn4.HeaderText = "Mensaje"
      Me.DataGridViewTextBoxColumn4.Name = "DataGridViewTextBoxColumn4"
      Me.DataGridViewTextBoxColumn4.ReadOnly = True
      Me.DataGridViewTextBoxColumn4.Width = 250
      '
      'DataGridViewTextBoxColumn5
      '
      Me.DataGridViewTextBoxColumn5.DataPropertyName = "IdProducto"
      Me.DataGridViewTextBoxColumn5.HeaderText = "Chasis"
      Me.DataGridViewTextBoxColumn5.Name = "DataGridViewTextBoxColumn5"
      Me.DataGridViewTextBoxColumn5.ReadOnly = True
      '
      'DataGridViewTextBoxColumn6
      '
      Me.DataGridViewTextBoxColumn6.DataPropertyName = "NombreProducto"
      Me.DataGridViewTextBoxColumn6.HeaderText = "Nombre Chasis"
      Me.DataGridViewTextBoxColumn6.Name = "DataGridViewTextBoxColumn6"
      Me.DataGridViewTextBoxColumn6.ReadOnly = True
      Me.DataGridViewTextBoxColumn6.Width = 200
      '
      'NumeroChasis
      '
      Me.NumeroChasis.DataPropertyName = "NumeroChasis"
      Me.NumeroChasis.HeaderText = "Numero Chasis"
      Me.NumeroChasis.Name = "NumeroChasis"
      Me.NumeroChasis.ReadOnly = True
      Me.NumeroChasis.Width = 150
      '
      'NroDeMotor
      '
      Me.NroDeMotor.DataPropertyName = "NroDeMotor"
      Me.NroDeMotor.HeaderText = "Nro. de Motor"
      Me.NroDeMotor.Name = "NroDeMotor"
      Me.NroDeMotor.ReadOnly = True
      '
      'tbpChasisEnUso
      '
      Me.tbpChasisEnUso.BackColor = System.Drawing.SystemColors.Control
      Me.tbpChasisEnUso.Controls.Add(Me.StatusStrip4)
      Me.tbpChasisEnUso.Controls.Add(Me.dgvChasisEnUso)
      Me.tbpChasisEnUso.Location = New System.Drawing.Point(4, 22)
      Me.tbpChasisEnUso.Name = "tbpChasisEnUso"
      Me.tbpChasisEnUso.Size = New System.Drawing.Size(953, 405)
      Me.tbpChasisEnUso.TabIndex = 3
      Me.tbpChasisEnUso.Text = "Chasis en Uso"
      '
      'StatusStrip4
      '
      Me.StatusStrip4.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripStatusLabel2})
      Me.StatusStrip4.Location = New System.Drawing.Point(0, 383)
      Me.StatusStrip4.Name = "StatusStrip4"
      Me.StatusStrip4.Size = New System.Drawing.Size(953, 22)
      Me.StatusStrip4.TabIndex = 9
      Me.StatusStrip4.Text = "StatusStrip4"
      '
      'ToolStripStatusLabel2
      '
      Me.ToolStripStatusLabel2.Name = "ToolStripStatusLabel2"
      Me.ToolStripStatusLabel2.Size = New System.Drawing.Size(938, 17)
      Me.ToolStripStatusLabel2.Spring = True
      Me.ToolStripStatusLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'dgvChasisEnUso
      '
      Me.dgvChasisEnUso.AllowUserToAddRows = False
      Me.dgvChasisEnUso.AllowUserToDeleteRows = False
      Me.dgvChasisEnUso.AllowUserToResizeRows = False
      Me.dgvChasisEnUso.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
      Me.dgvChasisEnUso.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewCheckBoxColumn3, Me.DataGridViewTextBoxColumn7, Me.DataGridViewTextBoxColumn8, Me.DataGridViewTextBoxColumn9, Me.DataGridViewTextBoxColumn10, Me.DataGridViewTextBoxColumn11, Me.DataGridViewTextBoxColumn12})
      Me.dgvChasisEnUso.Location = New System.Drawing.Point(3, 2)
      Me.dgvChasisEnUso.Name = "dgvChasisEnUso"
      Me.dgvChasisEnUso.ReadOnly = True
      Me.dgvChasisEnUso.RowHeadersWidth = 15
      Me.dgvChasisEnUso.Size = New System.Drawing.Size(947, 377)
      Me.dgvChasisEnUso.TabIndex = 4
      '
      'DataGridViewCheckBoxColumn3
      '
      Me.DataGridViewCheckBoxColumn3.DataPropertyName = "Importa"
      Me.DataGridViewCheckBoxColumn3.HeaderText = "Pasa"
      Me.DataGridViewCheckBoxColumn3.Name = "DataGridViewCheckBoxColumn3"
      Me.DataGridViewCheckBoxColumn3.ReadOnly = True
      Me.DataGridViewCheckBoxColumn3.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
      Me.DataGridViewCheckBoxColumn3.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic
      Me.DataGridViewCheckBoxColumn3.Width = 40
      '
      'DataGridViewTextBoxColumn7
      '
      Me.DataGridViewTextBoxColumn7.DataPropertyName = "Accion"
      DataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
      Me.DataGridViewTextBoxColumn7.DefaultCellStyle = DataGridViewCellStyle10
      Me.DataGridViewTextBoxColumn7.HeaderText = "Accion"
      Me.DataGridViewTextBoxColumn7.Name = "DataGridViewTextBoxColumn7"
      Me.DataGridViewTextBoxColumn7.ReadOnly = True
      Me.DataGridViewTextBoxColumn7.Width = 50
      '
      'DataGridViewTextBoxColumn8
      '
      Me.DataGridViewTextBoxColumn8.DataPropertyName = "Mensaje"
      Me.DataGridViewTextBoxColumn8.HeaderText = "Mensaje"
      Me.DataGridViewTextBoxColumn8.Name = "DataGridViewTextBoxColumn8"
      Me.DataGridViewTextBoxColumn8.ReadOnly = True
      Me.DataGridViewTextBoxColumn8.Width = 250
      '
      'DataGridViewTextBoxColumn9
      '
      Me.DataGridViewTextBoxColumn9.DataPropertyName = "IdProducto"
      Me.DataGridViewTextBoxColumn9.HeaderText = "Chasis"
      Me.DataGridViewTextBoxColumn9.Name = "DataGridViewTextBoxColumn9"
      Me.DataGridViewTextBoxColumn9.ReadOnly = True
      '
      'DataGridViewTextBoxColumn10
      '
      Me.DataGridViewTextBoxColumn10.DataPropertyName = "NombreProducto"
      Me.DataGridViewTextBoxColumn10.HeaderText = "Nombre Chasis"
      Me.DataGridViewTextBoxColumn10.Name = "DataGridViewTextBoxColumn10"
      Me.DataGridViewTextBoxColumn10.ReadOnly = True
      Me.DataGridViewTextBoxColumn10.Width = 200
      '
      'DataGridViewTextBoxColumn11
      '
      Me.DataGridViewTextBoxColumn11.DataPropertyName = "NumeroChasis"
      Me.DataGridViewTextBoxColumn11.HeaderText = "Numero Chasis"
      Me.DataGridViewTextBoxColumn11.Name = "DataGridViewTextBoxColumn11"
      Me.DataGridViewTextBoxColumn11.ReadOnly = True
      Me.DataGridViewTextBoxColumn11.Width = 150
      '
      'DataGridViewTextBoxColumn12
      '
      Me.DataGridViewTextBoxColumn12.DataPropertyName = "NroDeMotor"
      Me.DataGridViewTextBoxColumn12.HeaderText = "Nro. de Motor"
      Me.DataGridViewTextBoxColumn12.Name = "DataGridViewTextBoxColumn12"
      Me.DataGridViewTextBoxColumn12.ReadOnly = True
      '
      'ImportarClientesCalidad
      '
      Me.AcceptButton = Me.btnMostrar
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.ClientSize = New System.Drawing.Size(984, 562)
      Me.Controls.Add(Me.TabControl1)
      Me.Controls.Add(Me.prbImportando)
      Me.Controls.Add(Me.tstBarra)
      Me.Controls.Add(Me.grbPendientes)
      Me.Controls.Add(Me.btnMostrar)
      Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
      Me.KeyPreview = True
      Me.Name = "ImportarClientesCalidad"
      Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
      Me.Text = "Importar Tablas Bejerman"
      Me.grbPendientes.ResumeLayout(False)
      Me.grbPendientes.PerformLayout()
      CType(Me.dgvDetalle, System.ComponentModel.ISupportInitialize).EndInit()
      Me.tstBarra.ResumeLayout(False)
      Me.tstBarra.PerformLayout()
      Me.TabControl1.ResumeLayout(False)
      Me.TabPage1.ResumeLayout(False)
      Me.TabPage1.PerformLayout()
      Me.StatusStrip1.ResumeLayout(False)
      Me.StatusStrip1.PerformLayout()
      Me.TabPage2.ResumeLayout(False)
      Me.TabPage2.PerformLayout()
      Me.StatusStrip2.ResumeLayout(False)
      Me.StatusStrip2.PerformLayout()
      CType(Me.dgvModelos, System.ComponentModel.ISupportInitialize).EndInit()
      Me.TabPage3.ResumeLayout(False)
      Me.TabPage3.PerformLayout()
      Me.StatusStrip3.ResumeLayout(False)
      Me.StatusStrip3.PerformLayout()
      CType(Me.dgvChasis, System.ComponentModel.ISupportInitialize).EndInit()
      Me.tbpChasisEnUso.ResumeLayout(False)
      Me.tbpChasisEnUso.PerformLayout()
      Me.StatusStrip4.ResumeLayout(False)
      Me.StatusStrip4.PerformLayout()
      CType(Me.dgvChasisEnUso, System.ComponentModel.ISupportInitialize).EndInit()
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
    Friend WithEvents tsbGrabar As System.Windows.Forms.ToolStripButton
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
    Friend WithEvents tsbImportar As System.Windows.Forms.ToolStripButton
    Friend WithEvents Importa As DataGridViewCheckBoxColumn
    Friend WithEvents Accion As DataGridViewTextBoxColumn
    Friend WithEvents Mensaje As DataGridViewTextBoxColumn
    Friend WithEvents CodigoCliente As DataGridViewTextBoxColumn
    Friend WithEvents CodigoClienteLetras As DataGridViewTextBoxColumn
    Friend WithEvents NombreCliente As DataGridViewTextBoxColumn
    Friend WithEvents Direccion As DataGridViewTextBoxColumn
    Friend WithEvents IdLocalidad As DataGridViewTextBoxColumn
    Friend WithEvents Telefono As DataGridViewTextBoxColumn
    Friend WithEvents Celular As DataGridViewTextBoxColumn
    Friend WithEvents CorreoElectronico As DataGridViewTextBoxColumn
    Friend WithEvents NombreCategoria As DataGridViewTextBoxColumn
    Friend WithEvents NombreCategoriaFiscal As DataGridViewTextBoxColumn
    Friend WithEvents NombreVendedor As DataGridViewTextBoxColumn
    Friend WithEvents NombreListaPrecios As DataGridViewTextBoxColumn
    Friend WithEvents NombreZonaGeografica As DataGridViewTextBoxColumn
    Friend WithEvents CUIT As DataGridViewTextBoxColumn
    Friend WithEvents TipoDocCliente As DataGridViewTextBoxColumn
    Friend WithEvents NroDocCliente As DataGridViewTextBoxColumn
    Friend WithEvents FechaAlta As DataGridViewTextBoxColumn
    Friend WithEvents NombreDeFantasia As DataGridViewTextBoxColumn
    Friend WithEvents Twitter As DataGridViewTextBoxColumn
    Friend WithEvents Observacion As DataGridViewTextBoxColumn
    Friend WithEvents ChbImportarModelos As Controles.CheckBox
    Friend WithEvents chbImportarClientes As Controles.CheckBox
    Friend WithEvents TabControl1 As TabControl
    Friend WithEvents TabPage1 As TabPage
    Friend WithEvents TabPage2 As TabPage
    Friend WithEvents dgvModelos As Controles.DataGridView
    Friend WithEvents StatusStrip1 As StatusStrip
    Friend WithEvents tssRegistros As ToolStripStatusLabel
    Friend WithEvents DataGridViewCheckBoxColumn1 As DataGridViewCheckBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn1 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn2 As DataGridViewTextBoxColumn
    Friend WithEvents CodigoProductoModelo As DataGridViewTextBoxColumn
    Friend WithEvents NombreProductoModelo As DataGridViewTextBoxColumn
    Friend WithEvents StatusStrip2 As StatusStrip
    Friend WithEvents tssRegistrosModelos As ToolStripStatusLabel
   Friend WithEvents chbImportarChasis As Controles.CheckBox
   Friend WithEvents TabPage3 As TabPage
   Friend WithEvents dgvChasis As Controles.DataGridView
   Friend WithEvents StatusStrip3 As StatusStrip
   Friend WithEvents ToolStripStatusLabel1 As ToolStripStatusLabel
   Friend WithEvents DataGridViewCheckBoxColumn2 As DataGridViewCheckBoxColumn
   Friend WithEvents DataGridViewTextBoxColumn3 As DataGridViewTextBoxColumn
   Friend WithEvents DataGridViewTextBoxColumn4 As DataGridViewTextBoxColumn
   Friend WithEvents DataGridViewTextBoxColumn5 As DataGridViewTextBoxColumn
   Friend WithEvents DataGridViewTextBoxColumn6 As DataGridViewTextBoxColumn
   Friend WithEvents NumeroChasis As DataGridViewTextBoxColumn
   Friend WithEvents NroDeMotor As DataGridViewTextBoxColumn
   Friend WithEvents chbImportarChasisEnUso As Controles.CheckBox
   Friend WithEvents tbpChasisEnUso As TabPage
   Friend WithEvents StatusStrip4 As StatusStrip
   Friend WithEvents ToolStripStatusLabel2 As ToolStripStatusLabel
   Friend WithEvents dgvChasisEnUso As Controles.DataGridView
   Friend WithEvents DataGridViewCheckBoxColumn3 As DataGridViewCheckBoxColumn
   Friend WithEvents DataGridViewTextBoxColumn7 As DataGridViewTextBoxColumn
   Friend WithEvents DataGridViewTextBoxColumn8 As DataGridViewTextBoxColumn
   Friend WithEvents DataGridViewTextBoxColumn9 As DataGridViewTextBoxColumn
   Friend WithEvents DataGridViewTextBoxColumn10 As DataGridViewTextBoxColumn
   Friend WithEvents DataGridViewTextBoxColumn11 As DataGridViewTextBoxColumn
   Friend WithEvents DataGridViewTextBoxColumn12 As DataGridViewTextBoxColumn
End Class
