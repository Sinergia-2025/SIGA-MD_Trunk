<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ImportarFormulasExcel
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
        Dim DataGridViewCellStyle22 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle23 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle24 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle25 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle26 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle27 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle28 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ImportarFormulasExcel))
        Me.grbPendientes = New System.Windows.Forms.GroupBox()
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
        Me.IdProducto = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.NombreProducto = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.NombreFormula = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.NombreMarca = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.NombreRubro = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.IVA = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PrecioCosto = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Moneda = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.IdProductoComponente = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.NombreProductoComponente = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.NombreFormulaComponente = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Cantidad = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Principal = New System.Windows.Forms.DataGridViewTextBoxColumn()
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
        Me.grbPendientes.Size = New System.Drawing.Size(1005, 102)
        Me.grbPendientes.TabIndex = 0
        Me.grbPendientes.TabStop = False
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
        Me.cboEstado.Location = New System.Drawing.Point(55, 64)
        Me.cboEstado.Name = "cboEstado"
        Me.cboEstado.Size = New System.Drawing.Size(96, 21)
        Me.cboEstado.TabIndex = 11
        '
        'lblEstado
        '
        Me.lblEstado.AutoSize = True
        Me.lblEstado.LabelAsoc = Nothing
        Me.lblEstado.Location = New System.Drawing.Point(11, 68)
        Me.lblEstado.Name = "lblEstado"
        Me.lblEstado.Size = New System.Drawing.Size(40, 13)
        Me.lblEstado.TabIndex = 10
        Me.lblEstado.Text = "Estado"
        '
        'txtRangoCeldas
        '
        Me.txtRangoCeldas.Location = New System.Drawing.Point(787, 16)
        Me.txtRangoCeldas.Name = "txtRangoCeldas"
        Me.txtRangoCeldas.Size = New System.Drawing.Size(89, 20)
        Me.txtRangoCeldas.TabIndex = 4
        Me.txtRangoCeldas.Text = "An : Hn"
        Me.txtRangoCeldas.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'lblEjemplos
        '
        Me.lblEjemplos.AutoSize = True
        Me.lblEjemplos.LabelAsoc = Nothing
        Me.lblEjemplos.Location = New System.Drawing.Point(752, 43)
        Me.lblEjemplos.Name = "lblEjemplos"
        Me.lblEjemplos.Size = New System.Drawing.Size(95, 13)
        Me.lblEjemplos.TabIndex = 5
        Me.lblEjemplos.Text = "Ejemplo:  A1 : H50"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.LabelAsoc = Nothing
        Me.Label3.Location = New System.Drawing.Point(695, 16)
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
        Me.btnExaminar.ImageKey = "folder.ico"
        Me.btnExaminar.Location = New System.Drawing.Point(593, 16)
        Me.btnExaminar.Name = "btnExaminar"
        Me.btnExaminar.Size = New System.Drawing.Size(96, 40)
        Me.btnExaminar.TabIndex = 2
        Me.btnExaminar.Text = "&Examinar..."
        Me.btnExaminar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnExaminar.UseVisualStyleBackColor = True
        '
        'btnMostrar
        '
        Me.btnMostrar.Image = Global.Eniac.Win.My.Resources.Resources.view
        Me.btnMostrar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnMostrar.ImageKey = "row_add.ico"
        Me.btnMostrar.Location = New System.Drawing.Point(897, 43)
        Me.btnMostrar.Name = "btnMostrar"
        Me.btnMostrar.Size = New System.Drawing.Size(92, 45)
        Me.btnMostrar.TabIndex = 12
        Me.btnMostrar.Text = "&Mostrar"
        Me.btnMostrar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnMostrar.UseVisualStyleBackColor = True
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
        Me.dgvDetalle.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Importa, Me.Accion, Me.IdProducto, Me.NombreProducto, Me.NombreFormula, Me.NombreMarca, Me.NombreRubro, Me.IVA, Me.PrecioCosto, Me.Moneda, Me.IdProductoComponente, Me.NombreProductoComponente, Me.NombreFormulaComponente, Me.Cantidad, Me.Principal, Me.Mensaje})
        Me.dgvDetalle.Location = New System.Drawing.Point(12, 133)
        Me.dgvDetalle.Name = "dgvDetalle"
        Me.dgvDetalle.ReadOnly = True
        Me.dgvDetalle.RowHeadersWidth = 15
        Me.dgvDetalle.Size = New System.Drawing.Size(1004, 408)
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
        DataGridViewCellStyle22.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.Accion.DefaultCellStyle = DataGridViewCellStyle22
        Me.Accion.HeaderText = "Accion"
        Me.Accion.Name = "Accion"
        Me.Accion.ReadOnly = True
        Me.Accion.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.Accion.Visible = False
        Me.Accion.Width = 50
        '
        'IdProducto
        '
        Me.IdProducto.DataPropertyName = "IdProducto"
        DataGridViewCellStyle23.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.IdProducto.DefaultCellStyle = DataGridViewCellStyle23
        Me.IdProducto.HeaderText = "Codigo Producto"
        Me.IdProducto.Name = "IdProducto"
        Me.IdProducto.ReadOnly = True
        Me.IdProducto.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'NombreProducto
        '
        Me.NombreProducto.DataPropertyName = "NombreProducto"
        Me.NombreProducto.HeaderText = "Nombre Producto"
        Me.NombreProducto.Name = "NombreProducto"
        Me.NombreProducto.ReadOnly = True
        Me.NombreProducto.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.NombreProducto.Width = 200
        '
        'NombreFormula
        '
        Me.NombreFormula.DataPropertyName = "NombreFormula"
        Me.NombreFormula.HeaderText = "Fórmula"
        Me.NombreFormula.Name = "NombreFormula"
        Me.NombreFormula.ReadOnly = True
        Me.NombreFormula.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'NombreMarca
        '
        Me.NombreMarca.DataPropertyName = "NombreMarca"
        Me.NombreMarca.HeaderText = "Nombre Marca"
        Me.NombreMarca.Name = "NombreMarca"
        Me.NombreMarca.ReadOnly = True
        Me.NombreMarca.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.NombreMarca.Visible = False
        Me.NombreMarca.Width = 120
        '
        'NombreRubro
        '
        Me.NombreRubro.DataPropertyName = "NombreRubro"
        Me.NombreRubro.HeaderText = "Nombre Rubro"
        Me.NombreRubro.Name = "NombreRubro"
        Me.NombreRubro.ReadOnly = True
        Me.NombreRubro.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.NombreRubro.Visible = False
        Me.NombreRubro.Width = 120
        '
        'IVA
        '
        Me.IVA.DataPropertyName = "IVA"
        DataGridViewCellStyle24.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle24.Format = "N2"
        Me.IVA.DefaultCellStyle = DataGridViewCellStyle24
        Me.IVA.HeaderText = "IVA"
        Me.IVA.Name = "IVA"
        Me.IVA.ReadOnly = True
        Me.IVA.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.IVA.Visible = False
        Me.IVA.Width = 50
        '
        'PrecioCosto
        '
        Me.PrecioCosto.DataPropertyName = "PrecioCosto"
        DataGridViewCellStyle25.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle25.Format = "N2"
        Me.PrecioCosto.DefaultCellStyle = DataGridViewCellStyle25
        Me.PrecioCosto.HeaderText = "Precio Costo"
        Me.PrecioCosto.Name = "PrecioCosto"
        Me.PrecioCosto.ReadOnly = True
        Me.PrecioCosto.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.PrecioCosto.Visible = False
        Me.PrecioCosto.Width = 70
        '
        'Moneda
        '
        Me.Moneda.DataPropertyName = "Moneda"
        Me.Moneda.HeaderText = "Moneda"
        Me.Moneda.Name = "Moneda"
        Me.Moneda.ReadOnly = True
        Me.Moneda.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.Moneda.Visible = False
        Me.Moneda.Width = 60
        '
        'IdProductoComponente
        '
        Me.IdProductoComponente.DataPropertyName = "IdProductoComponente"
        DataGridViewCellStyle26.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.IdProductoComponente.DefaultCellStyle = DataGridViewCellStyle26
        Me.IdProductoComponente.HeaderText = "Codigo Componente"
        Me.IdProductoComponente.Name = "IdProductoComponente"
        Me.IdProductoComponente.ReadOnly = True
        Me.IdProductoComponente.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'NombreProductoComponente
        '
        Me.NombreProductoComponente.DataPropertyName = "NombreProductoComponente"
        Me.NombreProductoComponente.HeaderText = "Nombre Producto Componente"
        Me.NombreProductoComponente.Name = "NombreProductoComponente"
        Me.NombreProductoComponente.ReadOnly = True
        Me.NombreProductoComponente.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.NombreProductoComponente.Width = 200
        '
        'NombreFormulaComponente
        '
        Me.NombreFormulaComponente.DataPropertyName = "NombreFormulaComponente"
        Me.NombreFormulaComponente.HeaderText = "Nombre Formula Componente"
        Me.NombreFormulaComponente.Name = "NombreFormulaComponente"
        Me.NombreFormulaComponente.ReadOnly = True
        Me.NombreFormulaComponente.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'Cantidad
        '
        Me.Cantidad.DataPropertyName = "Cantidad"
        DataGridViewCellStyle27.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle27.Format = "N4"
        DataGridViewCellStyle27.NullValue = Nothing
        Me.Cantidad.DefaultCellStyle = DataGridViewCellStyle27
        Me.Cantidad.HeaderText = "Cantidad"
        Me.Cantidad.Name = "Cantidad"
        Me.Cantidad.ReadOnly = True
        Me.Cantidad.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.Cantidad.Width = 70
        '
        'Principal
        '
        Me.Principal.DataPropertyName = "Principal"
        DataGridViewCellStyle28.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.Principal.DefaultCellStyle = DataGridViewCellStyle28
        Me.Principal.HeaderText = "Principal"
        Me.Principal.Name = "Principal"
        Me.Principal.ReadOnly = True
        Me.Principal.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Principal.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.Principal.Width = 75
        '
        'Mensaje
        '
        Me.Mensaje.DataPropertyName = "Mensaje"
        Me.Mensaje.HeaderText = "Mensaje"
        Me.Mensaje.Name = "Mensaje"
        Me.Mensaje.ReadOnly = True
        Me.Mensaje.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.Mensaje.Width = 200
        '
        'tstBarra
        '
        Me.tstBarra.AllowItemReorder = True
        Me.tstBarra.ImageScalingSize = New System.Drawing.Size(22, 22)
        Me.tstBarra.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsbRefrescar, Me.ToolStripSeparator1, Me.tsbImportar, Me.toolStripSeparator3, Me.tsbSalir})
        Me.tstBarra.Location = New System.Drawing.Point(0, 0)
        Me.tstBarra.Name = "tstBarra"
        Me.tstBarra.Size = New System.Drawing.Size(1028, 29)
        Me.tstBarra.TabIndex = 0
        Me.tstBarra.Text = "toolStrip1"
        '
        'tsbRefrescar
        '
        Me.tsbRefrescar.Image = Global.Eniac.Win.My.Resources.Resources.refresh_24
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
        Me.tsbSalir.Image = Global.Eniac.Win.My.Resources.Resources.close_b_24
        Me.tsbSalir.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbSalir.Name = "tsbSalir"
        Me.tsbSalir.Size = New System.Drawing.Size(65, 26)
        Me.tsbSalir.Text = "&Cerrar"
        Me.tsbSalir.ToolTipText = "Cerrar el formulario"
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tssRegistros})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 569)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(1028, 22)
        Me.StatusStrip1.TabIndex = 5
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'tssRegistros
        '
        Me.tssRegistros.Name = "tssRegistros"
        Me.tssRegistros.Size = New System.Drawing.Size(1013, 17)
        Me.tssRegistros.Spring = True
        Me.tssRegistros.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'prbImportando
        '
        Me.prbImportando.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.prbImportando.Location = New System.Drawing.Point(12, 543)
        Me.prbImportando.Name = "prbImportando"
        Me.prbImportando.Size = New System.Drawing.Size(1004, 23)
        Me.prbImportando.Style = System.Windows.Forms.ProgressBarStyle.Continuous
        Me.prbImportando.TabIndex = 3
        '
        'ImportarFormulasExcel
        '
        Me.AcceptButton = Me.btnMostrar
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1028, 591)
        Me.Controls.Add(Me.prbImportando)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.tstBarra)
        Me.Controls.Add(Me.dgvDetalle)
        Me.Controls.Add(Me.grbPendientes)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.Name = "ImportarFormulasExcel"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Importar Formulas desde Excel"
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
    Friend WithEvents Importa As DataGridViewCheckBoxColumn
    Friend WithEvents Accion As DataGridViewTextBoxColumn
    Friend WithEvents IdProducto As DataGridViewTextBoxColumn
    Friend WithEvents NombreProducto As DataGridViewTextBoxColumn
    Friend WithEvents NombreFormula As DataGridViewTextBoxColumn
    Friend WithEvents NombreMarca As DataGridViewTextBoxColumn
    Friend WithEvents NombreRubro As DataGridViewTextBoxColumn
    Friend WithEvents IVA As DataGridViewTextBoxColumn
    Friend WithEvents PrecioCosto As DataGridViewTextBoxColumn
    Friend WithEvents Moneda As DataGridViewTextBoxColumn
    Friend WithEvents IdProductoComponente As DataGridViewTextBoxColumn
    Friend WithEvents NombreProductoComponente As DataGridViewTextBoxColumn
    Friend WithEvents NombreFormulaComponente As DataGridViewTextBoxColumn
    Friend WithEvents Cantidad As DataGridViewTextBoxColumn
    Friend WithEvents Principal As DataGridViewTextBoxColumn
    Friend WithEvents Mensaje As DataGridViewTextBoxColumn
End Class
