<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ImportarProveedoresExcel
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
      Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ImportarProveedoresExcel))
      Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
      Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
      Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
      Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
      Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
      Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
      Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
      Me.grbPendientes = New System.Windows.Forms.GroupBox()
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
      Me.tstBarra = New System.Windows.Forms.ToolStrip()
      Me.tsbRefrescar = New System.Windows.Forms.ToolStripButton()
      Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
      Me.tsbImportar = New System.Windows.Forms.ToolStripButton()
      Me.toolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
      Me.tsbSalir = New System.Windows.Forms.ToolStripButton()
      Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
      Me.tssRegistros = New System.Windows.Forms.ToolStripStatusLabel()
      Me.prbImportando = New System.Windows.Forms.ProgressBar()
      Me.Importa = New System.Windows.Forms.DataGridViewCheckBoxColumn()
      Me.Accion = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.CodigoProveedor = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.NombreProveedor = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.Direccion = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.IdLocalidadProveedor = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.NombreCategoriaFiscal = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.NombreCategoria = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.CUIT = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.TipoDocProveedor = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.NroDocProveedor = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.IngresosBrutos = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.Telefono = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.CorreoElectronico = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.NombreRubro = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.NombreCuentaCaja = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.NombreCuentaBanco = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.CuentaBanco_Entidad = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.Observacion = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.Mensaje = New System.Windows.Forms.DataGridViewTextBoxColumn()
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
      Me.cmbDescripcionCorte.Location = New System.Drawing.Point(432, 67)
      Me.cmbDescripcionCorte.Name = "cmbDescripcionCorte"
      Me.cmbDescripcionCorte.Size = New System.Drawing.Size(96, 21)
      Me.cmbDescripcionCorte.TabIndex = 13
      '
      'Label1
      '
      Me.Label1.AutoSize = True
      Me.Label1.Location = New System.Drawing.Point(334, 71)
      Me.Label1.Name = "Label1"
      Me.Label1.Size = New System.Drawing.Size(91, 13)
      Me.Label1.TabIndex = 12
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
      Me.cboAccion.Location = New System.Drawing.Point(53, 66)
      Me.cboAccion.Name = "cboAccion"
      Me.cboAccion.Size = New System.Drawing.Size(80, 21)
      Me.cboAccion.TabIndex = 9
      '
      'lblAccion
      '
      Me.lblAccion.AutoSize = True
      Me.lblAccion.Location = New System.Drawing.Point(6, 70)
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
      Me.cboEstado.Location = New System.Drawing.Point(213, 66)
      Me.cboEstado.Name = "cboEstado"
      Me.cboEstado.Size = New System.Drawing.Size(96, 21)
      Me.cboEstado.TabIndex = 11
      '
      'lblEstado
      '
      Me.lblEstado.AutoSize = True
      Me.lblEstado.Location = New System.Drawing.Point(169, 70)
      Me.lblEstado.Name = "lblEstado"
      Me.lblEstado.Size = New System.Drawing.Size(40, 13)
      Me.lblEstado.TabIndex = 10
      Me.lblEstado.Text = "Estado"
      '
      'txtRangoCeldas
      '
      Me.txtRangoCeldas.Location = New System.Drawing.Point(763, 26)
      Me.txtRangoCeldas.Name = "txtRangoCeldas"
      Me.txtRangoCeldas.Size = New System.Drawing.Size(89, 20)
      Me.txtRangoCeldas.TabIndex = 4
      Me.txtRangoCeldas.Text = "An : Pn"
      Me.txtRangoCeldas.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
      '
      'lblEjemplos
      '
      Me.lblEjemplos.AutoSize = True
      Me.lblEjemplos.Location = New System.Drawing.Point(760, 49)
      Me.lblEjemplos.Name = "lblEjemplos"
      Me.lblEjemplos.Size = New System.Drawing.Size(100, 13)
      Me.lblEjemplos.TabIndex = 5
      Me.lblEjemplos.Text = "Ejemplo:  A1 : P200"
      '
      'Label3
      '
      Me.Label3.AutoSize = True
      Me.Label3.Location = New System.Drawing.Point(672, 29)
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
      Me.txtArchivoOrigen.Size = New System.Drawing.Size(499, 20)
      Me.txtArchivoOrigen.TabIndex = 1
      '
      'lblArchivo
      '
      Me.lblArchivo.AutoSize = True
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
      Me.btnExaminar.Location = New System.Drawing.Point(560, 15)
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
      Me.btnMostrar.Location = New System.Drawing.Point(865, 35)
      Me.btnMostrar.Name = "btnMostrar"
      Me.btnMostrar.Size = New System.Drawing.Size(90, 45)
      Me.btnMostrar.TabIndex = 16
      Me.btnMostrar.Text = "&Mostrar"
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
      Me.dgvDetalle.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Importa, Me.Accion, Me.CodigoProveedor, Me.NombreProveedor, Me.Direccion, Me.IdLocalidadProveedor, Me.NombreCategoriaFiscal, Me.NombreCategoria, Me.CUIT, Me.TipoDocProveedor, Me.NroDocProveedor, Me.IngresosBrutos, Me.Telefono, Me.CorreoElectronico, Me.NombreRubro, Me.NombreCuentaCaja, Me.NombreCuentaBanco, Me.CuentaBanco_Entidad, Me.Observacion, Me.Mensaje})
      Me.dgvDetalle.Location = New System.Drawing.Point(12, 133)
      Me.dgvDetalle.Name = "dgvDetalle"
      Me.dgvDetalle.ReadOnly = True
      Me.dgvDetalle.RowHeadersWidth = 15
      Me.dgvDetalle.Size = New System.Drawing.Size(960, 379)
      Me.dgvDetalle.TabIndex = 1
      '
      'tstBarra
      '
      Me.tstBarra.AllowItemReorder = True
      Me.tstBarra.ImageScalingSize = New System.Drawing.Size(22, 22)
      Me.tstBarra.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsbRefrescar, Me.ToolStripSeparator1, Me.tsbImportar, Me.toolStripSeparator3, Me.tsbSalir})
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
      Me.StatusStrip1.TabIndex = 5
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
      Me.prbImportando.TabIndex = 3
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
      'CodigoProveedor
      '
      Me.CodigoProveedor.DataPropertyName = "CodigoProveedor"
      DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
      Me.CodigoProveedor.DefaultCellStyle = DataGridViewCellStyle2
      Me.CodigoProveedor.HeaderText = "Codigo"
      Me.CodigoProveedor.Name = "CodigoProveedor"
      Me.CodigoProveedor.ReadOnly = True
      Me.CodigoProveedor.Width = 70
      '
      'NombreProveedor
      '
      Me.NombreProveedor.DataPropertyName = "NombreProveedor"
      Me.NombreProveedor.HeaderText = "Nombre Cliente"
      Me.NombreProveedor.Name = "NombreProveedor"
      Me.NombreProveedor.ReadOnly = True
      Me.NombreProveedor.Width = 230
      '
      'Direccion
      '
      Me.Direccion.DataPropertyName = "Direccion"
      Me.Direccion.HeaderText = "Direccion"
      Me.Direccion.Name = "Direccion"
      Me.Direccion.ReadOnly = True
      Me.Direccion.Width = 200
      '
      'IdLocalidadProveedor
      '
      Me.IdLocalidadProveedor.DataPropertyName = "IdLocalidadProveedor"
      DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
      Me.IdLocalidadProveedor.DefaultCellStyle = DataGridViewCellStyle3
      Me.IdLocalidadProveedor.HeaderText = "C.P."
      Me.IdLocalidadProveedor.Name = "IdLocalidadProveedor"
      Me.IdLocalidadProveedor.ReadOnly = True
      Me.IdLocalidadProveedor.Width = 40
      '
      'NombreCategoriaFiscal
      '
      Me.NombreCategoriaFiscal.DataPropertyName = "NombreCategoriaFiscal"
      Me.NombreCategoriaFiscal.HeaderText = "Categoria Fiscal"
      Me.NombreCategoriaFiscal.Name = "NombreCategoriaFiscal"
      Me.NombreCategoriaFiscal.ReadOnly = True
      '
      'NombreCategoria
      '
      Me.NombreCategoria.DataPropertyName = "NombreCategoria"
      Me.NombreCategoria.HeaderText = "Categoria"
      Me.NombreCategoria.Name = "NombreCategoria"
      Me.NombreCategoria.ReadOnly = True
      '
      'CUIT
      '
      Me.CUIT.DataPropertyName = "CUIT"
      Me.CUIT.HeaderText = "CUIT"
      Me.CUIT.Name = "CUIT"
      Me.CUIT.ReadOnly = True
      '
      'TipoDocProveedor
      '
      Me.TipoDocProveedor.DataPropertyName = "TipoDocProveedor"
      DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
      Me.TipoDocProveedor.DefaultCellStyle = DataGridViewCellStyle4
      Me.TipoDocProveedor.HeaderText = "Tipo Doc"
      Me.TipoDocProveedor.Name = "TipoDocProveedor"
      Me.TipoDocProveedor.ReadOnly = True
      Me.TipoDocProveedor.Width = 50
      '
      'NroDocProveedor
      '
      Me.NroDocProveedor.DataPropertyName = "NroDocProveedor"
      DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
      Me.NroDocProveedor.DefaultCellStyle = DataGridViewCellStyle5
      Me.NroDocProveedor.HeaderText = "Nro. Doc."
      Me.NroDocProveedor.Name = "NroDocProveedor"
      Me.NroDocProveedor.ReadOnly = True
      Me.NroDocProveedor.Width = 80
      '
      'IngresosBrutos
      '
      Me.IngresosBrutos.DataPropertyName = "IngresosBrutos"
      DataGridViewCellStyle6.NullValue = Nothing
      Me.IngresosBrutos.DefaultCellStyle = DataGridViewCellStyle6
      Me.IngresosBrutos.HeaderText = "Ingresos Brutos"
      Me.IngresosBrutos.Name = "IngresosBrutos"
      Me.IngresosBrutos.ReadOnly = True
      '
      'Telefono
      '
      Me.Telefono.DataPropertyName = "Telefono"
      DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
      DataGridViewCellStyle7.Format = "N2"
      Me.Telefono.DefaultCellStyle = DataGridViewCellStyle7
      Me.Telefono.HeaderText = "Telefono"
      Me.Telefono.Name = "Telefono"
      Me.Telefono.ReadOnly = True
      '
      'CorreoElectronico
      '
      Me.CorreoElectronico.DataPropertyName = "CorreoElectronico"
      Me.CorreoElectronico.HeaderText = "Correo Electronico"
      Me.CorreoElectronico.Name = "CorreoElectronico"
      Me.CorreoElectronico.ReadOnly = True
      '
      'NombreRubro
      '
      Me.NombreRubro.DataPropertyName = "NombreRubro"
      Me.NombreRubro.HeaderText = "Rubro"
      Me.NombreRubro.Name = "NombreRubro"
      Me.NombreRubro.ReadOnly = True
      '
      'NombreCuentaCaja
      '
      Me.NombreCuentaCaja.DataPropertyName = "NombreCuentaCaja"
      Me.NombreCuentaCaja.HeaderText = "Cuenta Caja"
      Me.NombreCuentaCaja.Name = "NombreCuentaCaja"
      Me.NombreCuentaCaja.ReadOnly = True
      '
      'NombreCuentaBanco
      '
      Me.NombreCuentaBanco.DataPropertyName = "NombreCuentaBanco"
      Me.NombreCuentaBanco.HeaderText = "Cuenta Banco"
      Me.NombreCuentaBanco.Name = "NombreCuentaBanco"
      Me.NombreCuentaBanco.ReadOnly = True
      '
      'CuentaBanco_Entidad
      '
      Me.CuentaBanco_Entidad.DataPropertyName = "CuentaBanco_Entidad"
      Me.CuentaBanco_Entidad.HeaderText = "CuentaBanco_Entidad"
      Me.CuentaBanco_Entidad.Name = "CuentaBanco_Entidad"
      Me.CuentaBanco_Entidad.ReadOnly = True
      Me.CuentaBanco_Entidad.Visible = False
      '
      'Observacion
      '
      Me.Observacion.DataPropertyName = "Observacion"
      Me.Observacion.HeaderText = "Observacion"
      Me.Observacion.Name = "Observacion"
      Me.Observacion.ReadOnly = True
      Me.Observacion.Width = 150
      '
      'Mensaje
      '
      Me.Mensaje.DataPropertyName = "Mensaje"
      Me.Mensaje.HeaderText = "Mensaje"
      Me.Mensaje.Name = "Mensaje"
      Me.Mensaje.ReadOnly = True
      Me.Mensaje.Width = 400
      '
      'ImportarProveedoresExcel
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
      Me.Name = "ImportarProveedoresExcel"
      Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
      Me.Text = "Importar Proveedores desde Excel"
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
   Friend WithEvents CodigoProveedor As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents NombreProveedor As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents Direccion As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents IdLocalidadProveedor As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents NombreCategoriaFiscal As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents NombreCategoria As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents CUIT As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents TipoDocProveedor As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents NroDocProveedor As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents IngresosBrutos As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents Telefono As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents CorreoElectronico As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents NombreRubro As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents NombreCuentaCaja As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents NombreCuentaBanco As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents CuentaBanco_Entidad As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents Observacion As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents Mensaje As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
