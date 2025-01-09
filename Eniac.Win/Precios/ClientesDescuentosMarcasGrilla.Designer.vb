<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ClientesDescuentosMarcasGrilla
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
      Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
      Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
      Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
      Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
      Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ClientesDescuentosMarcasGrilla))
      Me.bscCodigoCliente = New Eniac.Controles.Buscador()
      Me.lblCodigoCliente = New Eniac.Controles.Label()
      Me.bscCliente = New Eniac.Controles.Buscador()
      Me.lblNombre = New Eniac.Controles.Label()
      Me.dgvDetalle = New Eniac.Controles.DataGridView()
        Me.IdCliente = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.IdMarca = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Marca = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DescuentoRecargoPorc1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DescuentoRecargoPorc2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.tspFacturacion = New System.Windows.Forms.ToolStrip()
        Me.tsbRefrescar = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsbGrabar = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsbSalir = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.grbCliente = New System.Windows.Forms.GroupBox()
        Me.txtDescuentoRecargoPorc2 = New Eniac.Controles.TextBox()
        Me.lblDescuentoRecargoPorc2 = New Eniac.Controles.Label()
        Me.btnDescuentoRecargoPorc1 = New Eniac.Controles.Button()
        Me.txtDescuentoRecargoPorc1 = New Eniac.Controles.TextBox()
        Me.lblDescuentoRecargoPorc1 = New Eniac.Controles.Label()
        Me.btnDescuentoRecargoPorc2 = New Eniac.Controles.Button()
        CType(Me.dgvDetalle, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tspFacturacion.SuspendLayout()
        Me.grbCliente.SuspendLayout()
        Me.SuspendLayout()
        '
        'bscCodigoCliente
        '
        Me.bscCodigoCliente.AyudaAncho = 136
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
        Me.bscCodigoCliente.Location = New System.Drawing.Point(12, 32)
        Me.bscCodigoCliente.MaxLengh = "32767"
        Me.bscCodigoCliente.Name = "bscCodigoCliente"
        Me.bscCodigoCliente.Permitido = True
        Me.bscCodigoCliente.Selecciono = False
        Me.bscCodigoCliente.Size = New System.Drawing.Size(90, 23)
        Me.bscCodigoCliente.TabIndex = 0
        Me.bscCodigoCliente.Titulo = Nothing
        '
        'lblCodigoCliente
        '
        Me.lblCodigoCliente.AutoSize = True
        Me.lblCodigoCliente.LabelAsoc = Nothing
        Me.lblCodigoCliente.Location = New System.Drawing.Point(9, 16)
        Me.lblCodigoCliente.Name = "lblCodigoCliente"
        Me.lblCodigoCliente.Size = New System.Drawing.Size(40, 13)
        Me.lblCodigoCliente.TabIndex = 1
        Me.lblCodigoCliente.Text = "Código"
        '
        'bscCliente
        '
        Me.bscCliente.AutoSize = True
        Me.bscCliente.AyudaAncho = 136
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
        Me.bscCliente.Location = New System.Drawing.Point(109, 32)
        Me.bscCliente.Margin = New System.Windows.Forms.Padding(4)
        Me.bscCliente.MaxLengh = "32767"
        Me.bscCliente.Name = "bscCliente"
        Me.bscCliente.Permitido = True
        Me.bscCliente.Selecciono = False
        Me.bscCliente.Size = New System.Drawing.Size(300, 23)
        Me.bscCliente.TabIndex = 2
        Me.bscCliente.Titulo = Nothing
        '
        'lblNombre
        '
        Me.lblNombre.AutoSize = True
        Me.lblNombre.LabelAsoc = Nothing
        Me.lblNombre.Location = New System.Drawing.Point(106, 16)
        Me.lblNombre.Name = "lblNombre"
        Me.lblNombre.Size = New System.Drawing.Size(44, 13)
        Me.lblNombre.TabIndex = 3
        Me.lblNombre.Text = "Nombre"
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
        Me.dgvDetalle.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.IdCliente, Me.IdMarca, Me.Marca, Me.DescuentoRecargoPorc1, Me.DescuentoRecargoPorc2})
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvDetalle.DefaultCellStyle = DataGridViewCellStyle5
        Me.dgvDetalle.Location = New System.Drawing.Point(17, 154)
        Me.dgvDetalle.Name = "dgvDetalle"
        Me.dgvDetalle.RowHeadersVisible = False
        Me.dgvDetalle.Size = New System.Drawing.Size(557, 313)
        Me.dgvDetalle.TabIndex = 7
        '
        'IdCliente
        '
        Me.IdCliente.DataPropertyName = "IdCliente"
        Me.IdCliente.HeaderText = "IdCliente"
        Me.IdCliente.Name = "IdCliente"
        Me.IdCliente.ReadOnly = True
        Me.IdCliente.Visible = False
        '
        'IdMarca
        '
        Me.IdMarca.DataPropertyName = "IdMarca"
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.IdMarca.DefaultCellStyle = DataGridViewCellStyle2
        Me.IdMarca.HeaderText = "Codigo"
        Me.IdMarca.Name = "IdMarca"
        Me.IdMarca.ReadOnly = True
        Me.IdMarca.Width = 80
        '
        'Marca
        '
        Me.Marca.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.Marca.DataPropertyName = "NombreMarca"
        Me.Marca.HeaderText = "Nombre Marca"
        Me.Marca.Name = "Marca"
        Me.Marca.ReadOnly = True
        '
        'DescuentoRecargoPorc1
        '
        Me.DescuentoRecargoPorc1.DataPropertyName = "DescuentoRecargoPorc1"
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle3.Format = "N2"
        Me.DescuentoRecargoPorc1.DefaultCellStyle = DataGridViewCellStyle3
        Me.DescuentoRecargoPorc1.HeaderText = "% D/R 1"
        Me.DescuentoRecargoPorc1.Name = "DescuentoRecargoPorc1"
        Me.DescuentoRecargoPorc1.Width = 80
        '
        'DescuentoRecargoPorc2
        '
        Me.DescuentoRecargoPorc2.DataPropertyName = "DescuentoRecargoPorc2"
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle4.Format = "N2"
        Me.DescuentoRecargoPorc2.DefaultCellStyle = DataGridViewCellStyle4
        Me.DescuentoRecargoPorc2.HeaderText = "% D/R 2"
        Me.DescuentoRecargoPorc2.Name = "DescuentoRecargoPorc2"
        Me.DescuentoRecargoPorc2.Width = 80
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
        Me.grbCliente.Controls.Add(Me.lblNombre)
        Me.grbCliente.Controls.Add(Me.lblCodigoCliente)
        Me.grbCliente.Controls.Add(Me.bscCliente)
        Me.grbCliente.Controls.Add(Me.bscCodigoCliente)
        Me.grbCliente.Location = New System.Drawing.Point(5, 38)
        Me.grbCliente.Name = "grbCliente"
        Me.grbCliente.Size = New System.Drawing.Size(579, 62)
        Me.grbCliente.TabIndex = 0
        Me.grbCliente.TabStop = False
        Me.grbCliente.Text = "Cliente"
        '
        'txtDescuentoRecargoPorc2
        '
        Me.txtDescuentoRecargoPorc2.BindearPropiedadControl = Nothing
        Me.txtDescuentoRecargoPorc2.BindearPropiedadEntidad = Nothing
        Me.txtDescuentoRecargoPorc2.ForeColorFocus = System.Drawing.Color.Red
        Me.txtDescuentoRecargoPorc2.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtDescuentoRecargoPorc2.Formato = "##0.00"
        Me.txtDescuentoRecargoPorc2.IsDecimal = True
        Me.txtDescuentoRecargoPorc2.IsNumber = True
        Me.txtDescuentoRecargoPorc2.IsPK = False
        Me.txtDescuentoRecargoPorc2.IsRequired = False
        Me.txtDescuentoRecargoPorc2.Key = ""
        Me.txtDescuentoRecargoPorc2.LabelAsoc = Me.lblDescuentoRecargoPorc2
        Me.txtDescuentoRecargoPorc2.Location = New System.Drawing.Point(352, 115)
        Me.txtDescuentoRecargoPorc2.Name = "txtDescuentoRecargoPorc2"
        Me.txtDescuentoRecargoPorc2.Size = New System.Drawing.Size(50, 20)
        Me.txtDescuentoRecargoPorc2.TabIndex = 5
        Me.txtDescuentoRecargoPorc2.Text = "0.00"
        Me.txtDescuentoRecargoPorc2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblDescuentoRecargoPorc2
        '
        Me.lblDescuentoRecargoPorc2.AutoSize = True
        Me.lblDescuentoRecargoPorc2.LabelAsoc = Nothing
        Me.lblDescuentoRecargoPorc2.Location = New System.Drawing.Point(301, 119)
        Me.lblDescuentoRecargoPorc2.Name = "lblDescuentoRecargoPorc2"
        Me.lblDescuentoRecargoPorc2.Size = New System.Drawing.Size(48, 13)
        Me.lblDescuentoRecargoPorc2.TabIndex = 4
        Me.lblDescuentoRecargoPorc2.Text = "% D/R 2"
        '
        'btnDescuentoRecargoPorc1
        '
        Me.btnDescuentoRecargoPorc1.Image = Global.Eniac.Win.My.Resources.Resources.gear_run
        Me.btnDescuentoRecargoPorc1.Location = New System.Drawing.Point(197, 107)
        Me.btnDescuentoRecargoPorc1.Name = "btnDescuentoRecargoPorc1"
        Me.btnDescuentoRecargoPorc1.Size = New System.Drawing.Size(37, 37)
        Me.btnDescuentoRecargoPorc1.TabIndex = 3
        Me.btnDescuentoRecargoPorc1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnDescuentoRecargoPorc1.UseVisualStyleBackColor = True
        '
        'txtDescuentoRecargoPorc1
        '
        Me.txtDescuentoRecargoPorc1.BindearPropiedadControl = Nothing
        Me.txtDescuentoRecargoPorc1.BindearPropiedadEntidad = Nothing
        Me.txtDescuentoRecargoPorc1.ForeColorFocus = System.Drawing.Color.Red
        Me.txtDescuentoRecargoPorc1.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtDescuentoRecargoPorc1.Formato = "##0.00"
        Me.txtDescuentoRecargoPorc1.IsDecimal = True
        Me.txtDescuentoRecargoPorc1.IsNumber = True
        Me.txtDescuentoRecargoPorc1.IsPK = False
        Me.txtDescuentoRecargoPorc1.IsRequired = False
        Me.txtDescuentoRecargoPorc1.Key = ""
        Me.txtDescuentoRecargoPorc1.LabelAsoc = Me.lblDescuentoRecargoPorc1
        Me.txtDescuentoRecargoPorc1.Location = New System.Drawing.Point(136, 115)
        Me.txtDescuentoRecargoPorc1.Name = "txtDescuentoRecargoPorc1"
        Me.txtDescuentoRecargoPorc1.Size = New System.Drawing.Size(50, 20)
        Me.txtDescuentoRecargoPorc1.TabIndex = 2
        Me.txtDescuentoRecargoPorc1.Text = "0.00"
        Me.txtDescuentoRecargoPorc1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblDescuentoRecargoPorc1
        '
        Me.lblDescuentoRecargoPorc1.AutoSize = True
        Me.lblDescuentoRecargoPorc1.LabelAsoc = Nothing
        Me.lblDescuentoRecargoPorc1.Location = New System.Drawing.Point(85, 119)
        Me.lblDescuentoRecargoPorc1.Name = "lblDescuentoRecargoPorc1"
        Me.lblDescuentoRecargoPorc1.Size = New System.Drawing.Size(48, 13)
        Me.lblDescuentoRecargoPorc1.TabIndex = 1
        Me.lblDescuentoRecargoPorc1.Text = "% D/R 1"
        '
        'btnDescuentoRecargoPorc2
        '
        Me.btnDescuentoRecargoPorc2.Image = Global.Eniac.Win.My.Resources.Resources.gear_run
        Me.btnDescuentoRecargoPorc2.Location = New System.Drawing.Point(411, 106)
        Me.btnDescuentoRecargoPorc2.Name = "btnDescuentoRecargoPorc2"
        Me.btnDescuentoRecargoPorc2.Size = New System.Drawing.Size(37, 37)
        Me.btnDescuentoRecargoPorc2.TabIndex = 6
        Me.btnDescuentoRecargoPorc2.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnDescuentoRecargoPorc2.UseVisualStyleBackColor = True
        '
        'ClientesDescuentosMarcasGrilla
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(592, 481)
        Me.Controls.Add(Me.btnDescuentoRecargoPorc2)
        Me.Controls.Add(Me.txtDescuentoRecargoPorc2)
        Me.Controls.Add(Me.lblDescuentoRecargoPorc2)
        Me.Controls.Add(Me.btnDescuentoRecargoPorc1)
        Me.Controls.Add(Me.txtDescuentoRecargoPorc1)
        Me.Controls.Add(Me.lblDescuentoRecargoPorc1)
        Me.Controls.Add(Me.tspFacturacion)
        Me.Controls.Add(Me.dgvDetalle)
        Me.Controls.Add(Me.grbCliente)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.Name = "ClientesDescuentosMarcasGrilla"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Clientes - Asignación de Descuentos por Marcas (Grilla)"
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
   Friend WithEvents dgvDetalle As Eniac.Controles.DataGridView
   Friend WithEvents tspFacturacion As System.Windows.Forms.ToolStrip
   Friend WithEvents tsbSalir As System.Windows.Forms.ToolStripButton
   Public WithEvents tsbRefrescar As System.Windows.Forms.ToolStripButton
   Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
   Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
   Friend WithEvents grbCliente As System.Windows.Forms.GroupBox
   Friend WithEvents ToolStripSeparator4 As System.Windows.Forms.ToolStripSeparator
   Friend WithEvents tsbGrabar As System.Windows.Forms.ToolStripButton
   Friend WithEvents txtDescuentoRecargoPorc2 As Eniac.Controles.TextBox
   Friend WithEvents lblDescuentoRecargoPorc2 As Eniac.Controles.Label
   Friend WithEvents btnDescuentoRecargoPorc1 As Eniac.Controles.Button
   Friend WithEvents txtDescuentoRecargoPorc1 As Eniac.Controles.TextBox
   Friend WithEvents lblDescuentoRecargoPorc1 As Eniac.Controles.Label
   Friend WithEvents btnDescuentoRecargoPorc2 As Eniac.Controles.Button
   Friend WithEvents IdCliente As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents IdMarca As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents Marca As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents DescuentoRecargoPorc1 As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents DescuentoRecargoPorc2 As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
