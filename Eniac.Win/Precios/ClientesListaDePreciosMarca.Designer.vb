<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ClientesListaDePreciosMarca
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
      Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
      Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
      Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ClientesListaDePreciosMarca))
      Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
      Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
      Me.bscCodigoCliente = New Eniac.Controles.Buscador()
      Me.lblCodigoCliente = New Eniac.Controles.Label()
      Me.bscCliente = New Eniac.Controles.Buscador()
      Me.lblNombre = New Eniac.Controles.Label()
      Me.bscMarca = New Eniac.Controles.Buscador()
      Me.lblMarca = New Eniac.Controles.Label()
      Me.lblListaDePrecios = New Eniac.Controles.Label()
      Me.dgvDetalle = New Eniac.Controles.DataGridView()
      Me.btnEliminar = New Eniac.Controles.Button()
      Me.btnInsertar = New Eniac.Controles.Button()
      Me.tspFacturacion = New System.Windows.Forms.ToolStrip()
      Me.tsbRefrescar = New System.Windows.Forms.ToolStripButton()
      Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator()
      Me.tsbGrabar = New System.Windows.Forms.ToolStripButton()
      Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
      Me.tsbSalir = New System.Windows.Forms.ToolStripButton()
      Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
      Me.grbCliente = New System.Windows.Forms.GroupBox()
      Me.cmbListasDePreciosCliente = New Eniac.Controles.ComboBox()
      Me.lblListaDePreciosCliente = New Eniac.Controles.Label()
      Me.cmbListasDePrecios = New Eniac.Controles.ComboBox()
      Me.IdCliente = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.CodigoCliente = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.TipoDocumento = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.NroDocumento = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.NombreCliente = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.IdMarca = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.NombreMarca = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.IdListaPrecios = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.NombreListaPrecios = New System.Windows.Forms.DataGridViewTextBoxColumn()
      CType(Me.dgvDetalle, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.tspFacturacion.SuspendLayout()
      Me.grbCliente.SuspendLayout()
      Me.SuspendLayout()
      '
      'bscCodigoCliente
      '
      Me.bscCodigoCliente.AyudaAncho = 608
      Me.bscCodigoCliente.BindearPropiedadControl = Nothing
      Me.bscCodigoCliente.BindearPropiedadEntidad = Nothing
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
      Me.bscCodigoCliente.IsNumber = True
      Me.bscCodigoCliente.IsPK = False
      Me.bscCodigoCliente.IsRequired = False
      Me.bscCodigoCliente.Key = ""
      Me.bscCodigoCliente.LabelAsoc = Me.lblCodigoCliente
      Me.bscCodigoCliente.Location = New System.Drawing.Point(10, 35)
      Me.bscCodigoCliente.MaxLengh = "32767"
      Me.bscCodigoCliente.Name = "bscCodigoCliente"
      Me.bscCodigoCliente.Permitido = True
      Me.bscCodigoCliente.Selecciono = False
      Me.bscCodigoCliente.Size = New System.Drawing.Size(90, 23)
      Me.bscCodigoCliente.TabIndex = 1
      Me.bscCodigoCliente.Titulo = Nothing
      '
      'lblCodigoCliente
      '
      Me.lblCodigoCliente.AutoSize = True
      Me.lblCodigoCliente.Location = New System.Drawing.Point(7, 19)
      Me.lblCodigoCliente.Name = "lblCodigoCliente"
      Me.lblCodigoCliente.Size = New System.Drawing.Size(40, 13)
      Me.lblCodigoCliente.TabIndex = 0
      Me.lblCodigoCliente.Text = "Código"
      '
      'bscCliente
      '
      Me.bscCliente.AutoSize = True
      Me.bscCliente.AyudaAncho = 608
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
      Me.bscCliente.Location = New System.Drawing.Point(107, 35)
      Me.bscCliente.Margin = New System.Windows.Forms.Padding(4)
      Me.bscCliente.MaxLengh = "32767"
      Me.bscCliente.Name = "bscCliente"
      Me.bscCliente.Permitido = True
      Me.bscCliente.Selecciono = False
      Me.bscCliente.Size = New System.Drawing.Size(300, 23)
      Me.bscCliente.TabIndex = 3
      Me.bscCliente.Titulo = Nothing
      '
      'lblNombre
      '
      Me.lblNombre.AutoSize = True
      Me.lblNombre.Location = New System.Drawing.Point(109, 19)
      Me.lblNombre.Name = "lblNombre"
      Me.lblNombre.Size = New System.Drawing.Size(44, 13)
      Me.lblNombre.TabIndex = 2
      Me.lblNombre.Text = "Nombre"
      '
      'bscMarca
      '
      Me.bscMarca.AyudaAncho = 608
      Me.bscMarca.BindearPropiedadControl = Nothing
      Me.bscMarca.BindearPropiedadEntidad = Nothing
      Me.bscMarca.ColumnasAlineacion = Nothing
      Me.bscMarca.ColumnasAncho = Nothing
      Me.bscMarca.ColumnasFormato = Nothing
      Me.bscMarca.ColumnasOcultas = Nothing
      Me.bscMarca.ColumnasTitulos = Nothing
      Me.bscMarca.Datos = Nothing
      Me.bscMarca.FilaDevuelta = Nothing
      Me.bscMarca.ForeColorFocus = System.Drawing.Color.Red
      Me.bscMarca.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
      Me.bscMarca.IsDecimal = False
      Me.bscMarca.IsNumber = False
      Me.bscMarca.IsPK = False
      Me.bscMarca.IsRequired = False
      Me.bscMarca.Key = ""
      Me.bscMarca.LabelAsoc = Me.lblMarca
      Me.bscMarca.Location = New System.Drawing.Point(48, 157)
      Me.bscMarca.MaxLengh = "32767"
      Me.bscMarca.Name = "bscMarca"
      Me.bscMarca.Permitido = True
      Me.bscMarca.Selecciono = False
      Me.bscMarca.Size = New System.Drawing.Size(209, 20)
      Me.bscMarca.TabIndex = 2
      Me.bscMarca.Titulo = Nothing
      '
      'lblMarca
      '
      Me.lblMarca.AutoSize = True
      Me.lblMarca.Location = New System.Drawing.Point(5, 161)
      Me.lblMarca.Name = "lblMarca"
      Me.lblMarca.Size = New System.Drawing.Size(37, 13)
      Me.lblMarca.TabIndex = 1
      Me.lblMarca.Text = "Marca"
      '
      'lblListaDePrecios
      '
      Me.lblListaDePrecios.AutoSize = True
      Me.lblListaDePrecios.Location = New System.Drawing.Point(262, 161)
      Me.lblListaDePrecios.Name = "lblListaDePrecios"
      Me.lblListaDePrecios.Size = New System.Drawing.Size(29, 13)
      Me.lblListaDePrecios.TabIndex = 3
      Me.lblListaDePrecios.Text = "Lista"
      '
      'dgvDetalle
      '
      Me.dgvDetalle.AllowUserToAddRows = False
      Me.dgvDetalle.AllowUserToDeleteRows = False
      Me.dgvDetalle.AllowUserToResizeColumns = False
      Me.dgvDetalle.AllowUserToResizeRows = False
      Me.dgvDetalle.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
      DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
      DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
      DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
      DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
      DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
      Me.dgvDetalle.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
      Me.dgvDetalle.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
      Me.dgvDetalle.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.IdCliente, Me.CodigoCliente, Me.TipoDocumento, Me.NroDocumento, Me.NombreCliente, Me.IdMarca, Me.NombreMarca, Me.IdListaPrecios, Me.NombreListaPrecios})
      DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
      DataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window
      DataGridViewCellStyle4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      DataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText
      DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight
      DataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText
      DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
      Me.dgvDetalle.DefaultCellStyle = DataGridViewCellStyle4
      Me.dgvDetalle.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
      Me.dgvDetalle.Location = New System.Drawing.Point(5, 192)
      Me.dgvDetalle.Name = "dgvDetalle"
      Me.dgvDetalle.ReadOnly = True
      Me.dgvDetalle.RowHeadersVisible = False
      Me.dgvDetalle.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
      Me.dgvDetalle.Size = New System.Drawing.Size(579, 265)
      Me.dgvDetalle.TabIndex = 7
      '
      'btnEliminar
      '
      Me.btnEliminar.Image = CType(resources.GetObject("btnEliminar.Image"), System.Drawing.Image)
      Me.btnEliminar.Location = New System.Drawing.Point(547, 149)
      Me.btnEliminar.Name = "btnEliminar"
      Me.btnEliminar.Size = New System.Drawing.Size(37, 37)
      Me.btnEliminar.TabIndex = 6
      Me.btnEliminar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
      Me.btnEliminar.UseVisualStyleBackColor = True
      '
      'btnInsertar
      '
      Me.btnInsertar.Image = CType(resources.GetObject("btnInsertar.Image"), System.Drawing.Image)
      Me.btnInsertar.Location = New System.Drawing.Point(507, 149)
      Me.btnInsertar.Name = "btnInsertar"
      Me.btnInsertar.Size = New System.Drawing.Size(37, 37)
      Me.btnInsertar.TabIndex = 5
      Me.btnInsertar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
      Me.btnInsertar.UseVisualStyleBackColor = True
      '
      'tspFacturacion
      '
      Me.tspFacturacion.ImageScalingSize = New System.Drawing.Size(22, 22)
      Me.tspFacturacion.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsbRefrescar, Me.ToolStripSeparator4, Me.tsbGrabar, Me.ToolStripSeparator1, Me.tsbSalir, Me.ToolStripSeparator3})
      Me.tspFacturacion.Location = New System.Drawing.Point(0, 0)
      Me.tspFacturacion.Name = "tspFacturacion"
      Me.tspFacturacion.Size = New System.Drawing.Size(592, 29)
      Me.tspFacturacion.TabIndex = 8
      Me.tspFacturacion.Text = "ToolStrip1"
      '
      'tsbRefrescar
      '
      Me.tsbRefrescar.Image = Global.Eniac.Win.My.Resources.Resources.refresh_32
      Me.tsbRefrescar.ImageTransparentColor = System.Drawing.Color.Magenta
      Me.tsbRefrescar.Name = "tsbRefrescar"
      Me.tsbRefrescar.Size = New System.Drawing.Size(104, 26)
      Me.tsbRefrescar.Text = "&Refrescar (F5)"
      '
      'ToolStripSeparator4
      '
      Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
      Me.ToolStripSeparator4.Size = New System.Drawing.Size(6, 29)
      '
      'tsbGrabar
      '
      Me.tsbGrabar.Enabled = False
      Me.tsbGrabar.Image = Global.Eniac.Win.My.Resources.Resources.disk_blue
      Me.tsbGrabar.ImageTransparentColor = System.Drawing.Color.Magenta
      Me.tsbGrabar.Name = "tsbGrabar"
      Me.tsbGrabar.Size = New System.Drawing.Size(91, 26)
      Me.tsbGrabar.Text = "&Grabar (F4)"
      Me.tsbGrabar.ToolTipText = "Imprimir y Grabar (F4)"
      '
      'ToolStripSeparator1
      '
      Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
      Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 29)
      '
      'tsbSalir
      '
      Me.tsbSalir.Image = Global.Eniac.Win.My.Resources.Resources.close_b_32
      Me.tsbSalir.ImageTransparentColor = System.Drawing.Color.Magenta
      Me.tsbSalir.Name = "tsbSalir"
      Me.tsbSalir.Size = New System.Drawing.Size(65, 26)
      Me.tsbSalir.Text = "&Cerrar"
      '
      'ToolStripSeparator3
      '
      Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
      Me.ToolStripSeparator3.Size = New System.Drawing.Size(6, 29)
      '
      'grbCliente
      '
      Me.grbCliente.Controls.Add(Me.cmbListasDePreciosCliente)
      Me.grbCliente.Controls.Add(Me.lblListaDePreciosCliente)
      Me.grbCliente.Controls.Add(Me.lblNombre)
      Me.grbCliente.Controls.Add(Me.lblCodigoCliente)
      Me.grbCliente.Controls.Add(Me.bscCliente)
      Me.grbCliente.Controls.Add(Me.bscCodigoCliente)
      Me.grbCliente.Location = New System.Drawing.Point(5, 37)
      Me.grbCliente.Name = "grbCliente"
      Me.grbCliente.Size = New System.Drawing.Size(579, 105)
      Me.grbCliente.TabIndex = 0
      Me.grbCliente.TabStop = False
      Me.grbCliente.Text = "Cliente"
      '
      'cmbListasDePreciosCliente
      '
      Me.cmbListasDePreciosCliente.BindearPropiedadControl = ""
      Me.cmbListasDePreciosCliente.BindearPropiedadEntidad = ""
      Me.cmbListasDePreciosCliente.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cmbListasDePreciosCliente.ForeColorFocus = System.Drawing.Color.Red
      Me.cmbListasDePreciosCliente.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.cmbListasDePreciosCliente.FormattingEnabled = True
      Me.cmbListasDePreciosCliente.IsPK = False
      Me.cmbListasDePreciosCliente.IsRequired = True
      Me.cmbListasDePreciosCliente.Key = Nothing
      Me.cmbListasDePreciosCliente.LabelAsoc = Me.lblListaDePreciosCliente
      Me.cmbListasDePreciosCliente.Location = New System.Drawing.Point(172, 63)
      Me.cmbListasDePreciosCliente.Name = "cmbListasDePreciosCliente"
      Me.cmbListasDePreciosCliente.Size = New System.Drawing.Size(204, 21)
      Me.cmbListasDePreciosCliente.TabIndex = 5
      '
      'lblListaDePreciosCliente
      '
      Me.lblListaDePreciosCliente.AutoSize = True
      Me.lblListaDePreciosCliente.Location = New System.Drawing.Point(7, 67)
      Me.lblListaDePreciosCliente.Name = "lblListaDePreciosCliente"
      Me.lblListaDePreciosCliente.Size = New System.Drawing.Size(159, 13)
      Me.lblListaDePreciosCliente.TabIndex = 4
      Me.lblListaDePreciosCliente.Text = "Lista de Precios Predeterminada"
      '
      'cmbListasDePrecios
      '
      Me.cmbListasDePrecios.BindearPropiedadControl = "SelectedValue"
      Me.cmbListasDePrecios.BindearPropiedadEntidad = "IdListaPrecios"
      Me.cmbListasDePrecios.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cmbListasDePrecios.ForeColorFocus = System.Drawing.Color.Red
      Me.cmbListasDePrecios.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.cmbListasDePrecios.FormattingEnabled = True
      Me.cmbListasDePrecios.IsPK = False
      Me.cmbListasDePrecios.IsRequired = True
      Me.cmbListasDePrecios.Key = Nothing
      Me.cmbListasDePrecios.LabelAsoc = Me.lblListaDePrecios
      Me.cmbListasDePrecios.Location = New System.Drawing.Point(297, 157)
      Me.cmbListasDePrecios.Name = "cmbListasDePrecios"
      Me.cmbListasDePrecios.Size = New System.Drawing.Size(204, 21)
      Me.cmbListasDePrecios.TabIndex = 4
      '
      'IdCliente
      '
      Me.IdCliente.DataPropertyName = "IdCliente"
      Me.IdCliente.HeaderText = "IdCliente"
      Me.IdCliente.Name = "IdCliente"
      Me.IdCliente.ReadOnly = True
      Me.IdCliente.Visible = False
      '
      'CodigoCliente
      '
      Me.CodigoCliente.DataPropertyName = "CodigoCliente"
      Me.CodigoCliente.HeaderText = "CodigoCliente"
      Me.CodigoCliente.Name = "CodigoCliente"
      Me.CodigoCliente.ReadOnly = True
      Me.CodigoCliente.Visible = False
      '
      'TipoDocumento
      '
      Me.TipoDocumento.DataPropertyName = "TipoDocumento"
      Me.TipoDocumento.HeaderText = "TipoDocumento"
      Me.TipoDocumento.Name = "TipoDocumento"
      Me.TipoDocumento.ReadOnly = True
      Me.TipoDocumento.Visible = False
      '
      'NroDocumento
      '
      Me.NroDocumento.DataPropertyName = "NroDocumento"
      Me.NroDocumento.HeaderText = "NroDocumento"
      Me.NroDocumento.Name = "NroDocumento"
      Me.NroDocumento.ReadOnly = True
      Me.NroDocumento.Visible = False
      '
      'NombreCliente
      '
      Me.NombreCliente.DataPropertyName = "NombreCliente"
      Me.NombreCliente.HeaderText = "NombreCliente"
      Me.NombreCliente.Name = "NombreCliente"
      Me.NombreCliente.ReadOnly = True
      Me.NombreCliente.Visible = False
      '
      'IdMarca
      '
      Me.IdMarca.DataPropertyName = "IdMarca"
      DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
      DataGridViewCellStyle2.NullValue = Nothing
      Me.IdMarca.DefaultCellStyle = DataGridViewCellStyle2
      Me.IdMarca.HeaderText = "Marca"
      Me.IdMarca.Name = "IdMarca"
      Me.IdMarca.ReadOnly = True
      Me.IdMarca.Visible = False
      Me.IdMarca.Width = 50
      '
      'NombreMarca
      '
      Me.NombreMarca.DataPropertyName = "NombreMarca"
      Me.NombreMarca.HeaderText = "Nombre Marca"
      Me.NombreMarca.Name = "NombreMarca"
      Me.NombreMarca.ReadOnly = True
      Me.NombreMarca.Width = 270
      '
      'IdListaPrecios
      '
      Me.IdListaPrecios.DataPropertyName = "IdListaPrecios"
      DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
      Me.IdListaPrecios.DefaultCellStyle = DataGridViewCellStyle3
      Me.IdListaPrecios.HeaderText = "Lista"
      Me.IdListaPrecios.Name = "IdListaPrecios"
      Me.IdListaPrecios.ReadOnly = True
      Me.IdListaPrecios.Visible = False
      Me.IdListaPrecios.Width = 50
      '
      'NombreListaPrecios
      '
      Me.NombreListaPrecios.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
      Me.NombreListaPrecios.DataPropertyName = "NombreListaPrecios"
      Me.NombreListaPrecios.HeaderText = "Nombre Lista de Precios"
      Me.NombreListaPrecios.Name = "NombreListaPrecios"
      Me.NombreListaPrecios.ReadOnly = True
      '
      'ClientesListaDePreciosMarca
      '
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.ClientSize = New System.Drawing.Size(592, 467)
      Me.Controls.Add(Me.cmbListasDePrecios)
      Me.Controls.Add(Me.tspFacturacion)
      Me.Controls.Add(Me.btnEliminar)
      Me.Controls.Add(Me.btnInsertar)
      Me.Controls.Add(Me.dgvDetalle)
      Me.Controls.Add(Me.lblListaDePrecios)
      Me.Controls.Add(Me.bscMarca)
      Me.Controls.Add(Me.lblMarca)
      Me.Controls.Add(Me.grbCliente)
      Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
      Me.KeyPreview = True
      Me.MaximizeBox = False
      Me.Name = "ClientesListaDePreciosMarca"
      Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
      Me.Text = "Asignación de Lista de Precios por Marca a Clientes"
      CType(Me.dgvDetalle, System.ComponentModel.ISupportInitialize).EndInit()
      Me.tspFacturacion.ResumeLayout(False)
      Me.tspFacturacion.PerformLayout()
      Me.grbCliente.ResumeLayout(False)
      Me.grbCliente.PerformLayout()
      Me.ResumeLayout(False)
      Me.PerformLayout()

   End Sub
   Friend WithEvents bscCodigoCliente As Eniac.Controles.Buscador
   Friend WithEvents lblCodigoCliente As Eniac.Controles.Label
   Friend WithEvents bscCliente As Eniac.Controles.Buscador
   Friend WithEvents lblNombre As Eniac.Controles.Label
   Friend WithEvents bscMarca As Eniac.Controles.Buscador
   Friend WithEvents lblListaDePrecios As Eniac.Controles.Label
   Friend WithEvents dgvDetalle As Eniac.Controles.DataGridView
   Friend WithEvents btnEliminar As Eniac.Controles.Button
   Friend WithEvents btnInsertar As Eniac.Controles.Button
   Friend WithEvents tspFacturacion As System.Windows.Forms.ToolStrip
   Friend WithEvents tsbSalir As System.Windows.Forms.ToolStripButton
   Public WithEvents tsbRefrescar As System.Windows.Forms.ToolStripButton
   Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
   Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
   Friend WithEvents grbCliente As System.Windows.Forms.GroupBox
   Friend WithEvents ToolStripSeparator4 As System.Windows.Forms.ToolStripSeparator
   Friend WithEvents tsbGrabar As System.Windows.Forms.ToolStripButton
   Friend WithEvents lblMarca As Eniac.Controles.Label
   Friend WithEvents cmbListasDePrecios As Eniac.Controles.ComboBox
   Friend WithEvents cmbListasDePreciosCliente As Eniac.Controles.ComboBox
   Friend WithEvents lblListaDePreciosCliente As Eniac.Controles.Label
   Friend WithEvents IdCliente As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents CodigoCliente As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents TipoDocumento As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents NroDocumento As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents NombreCliente As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents IdMarca As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents NombreMarca As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents IdListaPrecios As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents NombreListaPrecios As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
