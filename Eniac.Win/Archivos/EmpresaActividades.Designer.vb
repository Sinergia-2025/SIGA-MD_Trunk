<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class EmpresaActividades
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
      Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
      Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
      Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
      Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
      Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(EmpresaActividades))
      Me.tspFacturacion = New System.Windows.Forms.ToolStrip()
      Me.tsbRefrescar = New System.Windows.Forms.ToolStripButton()
      Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator()
      Me.tsbGrabar = New System.Windows.Forms.ToolStripButton()
      Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
      Me.tsbSalir = New System.Windows.Forms.ToolStripButton()
      Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
      Me.gpbActividades = New System.Windows.Forms.GroupBox()
      Me.chbPrincipal = New Eniac.Controles.CheckBox()
      Me.btnRefresh = New Eniac.Controles.Button()
      Me.bscActividades = New Eniac.Controles.Buscador()
      Me.lblProvincia = New Eniac.Controles.Label()
      Me.dgvDetalle = New Eniac.Controles.DataGridView()
      Me.IdProvincia = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.NombreProvincia = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.IdActividad = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.NombreActividad = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.Porcentaje = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.Principal = New System.Windows.Forms.DataGridViewCheckBoxColumn()
      Me.cmbProvincia = New Eniac.Controles.ComboBox()
      Me.btnInsertar = New Eniac.Controles.Button()
      Me.txtPorcentaje = New Eniac.Controles.TextBox()
      Me.lblDescuentoRecargoPorc1 = New Eniac.Controles.Label()
      Me.btnEliminar = New Eniac.Controles.Button()
      Me.lblActividad = New Eniac.Controles.Label()
      Me.tspFacturacion.SuspendLayout()
      Me.gpbActividades.SuspendLayout()
      CType(Me.dgvDetalle, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.SuspendLayout()
      '
      'tspFacturacion
      '
      Me.tspFacturacion.ImageScalingSize = New System.Drawing.Size(22, 22)
      Me.tspFacturacion.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsbRefrescar, Me.ToolStripSeparator4, Me.tsbGrabar, Me.ToolStripSeparator1, Me.tsbSalir, Me.ToolStripSeparator3})
      Me.tspFacturacion.Location = New System.Drawing.Point(0, 0)
      Me.tspFacturacion.Name = "tspFacturacion"
      Me.tspFacturacion.Size = New System.Drawing.Size(769, 29)
      Me.tspFacturacion.TabIndex = 1
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
      Me.tsbGrabar.Image = Global.Eniac.Win.My.Resources.Resources.diskette_32
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
      'gpbActividades
      '
      Me.gpbActividades.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.gpbActividades.Controls.Add(Me.chbPrincipal)
      Me.gpbActividades.Controls.Add(Me.btnRefresh)
      Me.gpbActividades.Controls.Add(Me.bscActividades)
      Me.gpbActividades.Controls.Add(Me.lblProvincia)
      Me.gpbActividades.Controls.Add(Me.dgvDetalle)
      Me.gpbActividades.Controls.Add(Me.cmbProvincia)
      Me.gpbActividades.Controls.Add(Me.btnInsertar)
      Me.gpbActividades.Controls.Add(Me.txtPorcentaje)
      Me.gpbActividades.Controls.Add(Me.lblDescuentoRecargoPorc1)
      Me.gpbActividades.Controls.Add(Me.btnEliminar)
      Me.gpbActividades.Controls.Add(Me.lblActividad)
      Me.gpbActividades.Location = New System.Drawing.Point(12, 39)
      Me.gpbActividades.Name = "gpbActividades"
      Me.gpbActividades.Size = New System.Drawing.Size(745, 252)
      Me.gpbActividades.TabIndex = 0
      Me.gpbActividades.TabStop = False
      Me.gpbActividades.Text = "Actividades"
      '
      'chbPrincipal
      '
      Me.chbPrincipal.AutoSize = True
      Me.chbPrincipal.BindearPropiedadControl = Nothing
      Me.chbPrincipal.BindearPropiedadEntidad = Nothing
      Me.chbPrincipal.ForeColorFocus = System.Drawing.Color.Red
      Me.chbPrincipal.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
      Me.chbPrincipal.IsPK = False
      Me.chbPrincipal.IsRequired = False
      Me.chbPrincipal.Key = Nothing
      Me.chbPrincipal.LabelAsoc = Nothing
      Me.chbPrincipal.Location = New System.Drawing.Point(585, 32)
      Me.chbPrincipal.Name = "chbPrincipal"
      Me.chbPrincipal.Size = New System.Drawing.Size(66, 17)
      Me.chbPrincipal.TabIndex = 6
      Me.chbPrincipal.Text = "Principal"
      Me.chbPrincipal.UseVisualStyleBackColor = True
      '
      'btnRefresh
      '
      Me.btnRefresh.Image = Global.Eniac.Win.My.Resources.Resources.refresh_32
      Me.btnRefresh.Location = New System.Drawing.Point(6, 22)
      Me.btnRefresh.Name = "btnRefresh"
      Me.btnRefresh.Size = New System.Drawing.Size(37, 37)
      Me.btnRefresh.TabIndex = 9
      Me.btnRefresh.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
      Me.btnRefresh.UseVisualStyleBackColor = True
      '
      'bscActividades
      '
      Me.bscActividades.AyudaAncho = 140
      Me.bscActividades.BindearPropiedadControl = Nothing
      Me.bscActividades.BindearPropiedadEntidad = Nothing
      Me.bscActividades.ColumnasAlineacion = Nothing
      Me.bscActividades.ColumnasAncho = Nothing
      Me.bscActividades.ColumnasFormato = Nothing
      Me.bscActividades.ColumnasOcultas = Nothing
      Me.bscActividades.ColumnasTitulos = Nothing
      Me.bscActividades.Datos = Nothing
      Me.bscActividades.FilaDevuelta = Nothing
      Me.bscActividades.ForeColorFocus = System.Drawing.Color.Red
      Me.bscActividades.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
      Me.bscActividades.IsDecimal = False
      Me.bscActividades.IsNumber = False
      Me.bscActividades.IsPK = False
      Me.bscActividades.IsRequired = False
      Me.bscActividades.Key = ""
      Me.bscActividades.LabelAsoc = Nothing
      Me.bscActividades.Location = New System.Drawing.Point(266, 30)
      Me.bscActividades.MaxLengh = "32767"
      Me.bscActividades.Name = "bscActividades"
      Me.bscActividades.Permitido = True
      Me.bscActividades.Selecciono = False
      Me.bscActividades.Size = New System.Drawing.Size(243, 20)
      Me.bscActividades.TabIndex = 3
      Me.bscActividades.Titulo = Nothing
      '
      'lblProvincia
      '
      Me.lblProvincia.AutoSize = True
      Me.lblProvincia.Location = New System.Drawing.Point(42, 33)
      Me.lblProvincia.Name = "lblProvincia"
      Me.lblProvincia.Size = New System.Drawing.Size(28, 13)
      Me.lblProvincia.TabIndex = 0
      Me.lblProvincia.Text = "Pcia"
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
      Me.dgvDetalle.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.IdProvincia, Me.NombreProvincia, Me.IdActividad, Me.NombreActividad, Me.Porcentaje, Me.Principal})
      DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
      DataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window
      DataGridViewCellStyle5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      DataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText
      DataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight
      DataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText
      DataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
      Me.dgvDetalle.DefaultCellStyle = DataGridViewCellStyle5
      Me.dgvDetalle.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
      Me.dgvDetalle.Location = New System.Drawing.Point(6, 65)
      Me.dgvDetalle.Name = "dgvDetalle"
      Me.dgvDetalle.ReadOnly = True
      Me.dgvDetalle.RowHeadersVisible = False
      Me.dgvDetalle.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
      Me.dgvDetalle.Size = New System.Drawing.Size(733, 181)
      Me.dgvDetalle.TabIndex = 10
      '
      'IdProvincia
      '
      Me.IdProvincia.DataPropertyName = "IdProvincia"
      DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
      Me.IdProvincia.DefaultCellStyle = DataGridViewCellStyle2
      Me.IdProvincia.HeaderText = "IdProvincia"
      Me.IdProvincia.Name = "IdProvincia"
      Me.IdProvincia.ReadOnly = True
      Me.IdProvincia.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
      Me.IdProvincia.Visible = False
      Me.IdProvincia.Width = 80
      '
      'NombreProvincia
      '
      Me.NombreProvincia.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
      Me.NombreProvincia.DataPropertyName = "NombreProvincia"
      Me.NombreProvincia.HeaderText = "Provincia"
      Me.NombreProvincia.Name = "NombreProvincia"
      Me.NombreProvincia.ReadOnly = True
      Me.NombreProvincia.Width = 150
      '
      'IdActividad
      '
      Me.IdActividad.DataPropertyName = "IdActividad"
      DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
      Me.IdActividad.DefaultCellStyle = DataGridViewCellStyle3
      Me.IdActividad.HeaderText = "Código"
      Me.IdActividad.Name = "IdActividad"
      Me.IdActividad.ReadOnly = True
      Me.IdActividad.Width = 80
      '
      'NombreActividad
      '
      Me.NombreActividad.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
      Me.NombreActividad.DataPropertyName = "NombreActividad"
      DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
      Me.NombreActividad.DefaultCellStyle = DataGridViewCellStyle4
      Me.NombreActividad.HeaderText = "Actividad"
      Me.NombreActividad.Name = "NombreActividad"
      Me.NombreActividad.ReadOnly = True
      '
      'Porcentaje
      '
      Me.Porcentaje.DataPropertyName = "Porcentaje"
      Me.Porcentaje.HeaderText = "Porcentaje"
      Me.Porcentaje.Name = "Porcentaje"
      Me.Porcentaje.ReadOnly = True
      Me.Porcentaje.Width = 70
      '
      'Principal
      '
      Me.Principal.DataPropertyName = "Principal"
      Me.Principal.HeaderText = "Principal"
      Me.Principal.Name = "Principal"
      Me.Principal.ReadOnly = True
      Me.Principal.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
      Me.Principal.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
      Me.Principal.Width = 50
      '
      'cmbProvincia
      '
      Me.cmbProvincia.BindearPropiedadControl = ""
      Me.cmbProvincia.BindearPropiedadEntidad = ""
      Me.cmbProvincia.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cmbProvincia.ForeColorFocus = System.Drawing.Color.Red
      Me.cmbProvincia.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.cmbProvincia.FormattingEnabled = True
      Me.cmbProvincia.IsPK = False
      Me.cmbProvincia.IsRequired = True
      Me.cmbProvincia.Key = Nothing
      Me.cmbProvincia.LabelAsoc = Me.lblProvincia
      Me.cmbProvincia.Location = New System.Drawing.Point(73, 29)
      Me.cmbProvincia.Name = "cmbProvincia"
      Me.cmbProvincia.Size = New System.Drawing.Size(132, 21)
      Me.cmbProvincia.TabIndex = 1
      '
      'btnInsertar
      '
      Me.btnInsertar.Image = CType(resources.GetObject("btnInsertar.Image"), System.Drawing.Image)
      Me.btnInsertar.Location = New System.Drawing.Point(657, 22)
      Me.btnInsertar.Name = "btnInsertar"
      Me.btnInsertar.Size = New System.Drawing.Size(37, 37)
      Me.btnInsertar.TabIndex = 7
      Me.btnInsertar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
      Me.btnInsertar.UseVisualStyleBackColor = True
      '
      'txtPorcentaje
      '
      Me.txtPorcentaje.BindearPropiedadControl = Nothing
      Me.txtPorcentaje.BindearPropiedadEntidad = Nothing
      Me.txtPorcentaje.ForeColorFocus = System.Drawing.Color.Red
      Me.txtPorcentaje.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtPorcentaje.Formato = "##0.00"
      Me.txtPorcentaje.IsDecimal = True
      Me.txtPorcentaje.IsNumber = True
      Me.txtPorcentaje.IsPK = False
      Me.txtPorcentaje.IsRequired = False
      Me.txtPorcentaje.Key = ""
      Me.txtPorcentaje.LabelAsoc = Me.lblDescuentoRecargoPorc1
      Me.txtPorcentaje.Location = New System.Drawing.Point(522, 30)
      Me.txtPorcentaje.Name = "txtPorcentaje"
      Me.txtPorcentaje.Size = New System.Drawing.Size(42, 20)
      Me.txtPorcentaje.TabIndex = 4
      Me.txtPorcentaje.Text = "0.00"
      Me.txtPorcentaje.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'lblDescuentoRecargoPorc1
      '
      Me.lblDescuentoRecargoPorc1.AutoSize = True
      Me.lblDescuentoRecargoPorc1.Location = New System.Drawing.Point(564, 33)
      Me.lblDescuentoRecargoPorc1.Name = "lblDescuentoRecargoPorc1"
      Me.lblDescuentoRecargoPorc1.Size = New System.Drawing.Size(15, 13)
      Me.lblDescuentoRecargoPorc1.TabIndex = 5
      Me.lblDescuentoRecargoPorc1.Text = "%"
      '
      'btnEliminar
      '
      Me.btnEliminar.Image = CType(resources.GetObject("btnEliminar.Image"), System.Drawing.Image)
      Me.btnEliminar.Location = New System.Drawing.Point(702, 22)
      Me.btnEliminar.Name = "btnEliminar"
      Me.btnEliminar.Size = New System.Drawing.Size(37, 37)
      Me.btnEliminar.TabIndex = 8
      Me.btnEliminar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
      Me.btnEliminar.UseVisualStyleBackColor = True
      '
      'lblActividad
      '
      Me.lblActividad.AutoSize = True
      Me.lblActividad.Location = New System.Drawing.Point(211, 33)
      Me.lblActividad.Name = "lblActividad"
      Me.lblActividad.Size = New System.Drawing.Size(51, 13)
      Me.lblActividad.TabIndex = 2
      Me.lblActividad.Text = "Actividad"
      '
      'EmpresaActividades
      '
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.ClientSize = New System.Drawing.Size(769, 296)
      Me.Controls.Add(Me.gpbActividades)
      Me.Controls.Add(Me.tspFacturacion)
      Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
      Me.Name = "EmpresaActividades"
      Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
      Me.Text = "Empresa - Asignación de Actividades"
      Me.tspFacturacion.ResumeLayout(False)
      Me.tspFacturacion.PerformLayout()
      Me.gpbActividades.ResumeLayout(False)
      Me.gpbActividades.PerformLayout()
      CType(Me.dgvDetalle, System.ComponentModel.ISupportInitialize).EndInit()
      Me.ResumeLayout(False)
      Me.PerformLayout()

   End Sub
   Friend WithEvents tspFacturacion As System.Windows.Forms.ToolStrip
   Public WithEvents tsbRefrescar As System.Windows.Forms.ToolStripButton
   Friend WithEvents ToolStripSeparator4 As System.Windows.Forms.ToolStripSeparator
   Friend WithEvents tsbGrabar As System.Windows.Forms.ToolStripButton
   Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
   Friend WithEvents tsbSalir As System.Windows.Forms.ToolStripButton
   Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
   Friend WithEvents gpbActividades As System.Windows.Forms.GroupBox
   Friend WithEvents btnRefresh As Eniac.Controles.Button
   Friend WithEvents bscActividades As Eniac.Controles.Buscador
   Friend WithEvents lblProvincia As Eniac.Controles.Label
   Friend WithEvents dgvDetalle As Eniac.Controles.DataGridView
   Friend WithEvents cmbProvincia As Eniac.Controles.ComboBox
   Friend WithEvents btnInsertar As Eniac.Controles.Button
   Friend WithEvents txtPorcentaje As Eniac.Controles.TextBox
   Friend WithEvents lblDescuentoRecargoPorc1 As Eniac.Controles.Label
   Friend WithEvents btnEliminar As Eniac.Controles.Button
   Friend WithEvents lblActividad As Eniac.Controles.Label
   Friend WithEvents chbPrincipal As Eniac.Controles.CheckBox
   Friend WithEvents IdProvincia As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents NombreProvincia As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents IdActividad As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents NombreActividad As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents Porcentaje As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents Principal As System.Windows.Forms.DataGridViewCheckBoxColumn
End Class
