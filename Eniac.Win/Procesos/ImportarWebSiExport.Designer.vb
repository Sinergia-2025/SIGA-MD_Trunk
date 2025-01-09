<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class ImportarWebSiExport
    Inherits System.Windows.Forms.Form

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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ImportarWebSiExport))
        Dim DataGridViewCellStyle13 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle14 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle15 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle16 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.tstBarra = New System.Windows.Forms.ToolStrip()
        Me.tsbRefrescar = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsbImportar = New System.Windows.Forms.ToolStripButton()
        Me.toolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsbSalir = New System.Windows.Forms.ToolStripButton()
        Me.grbPendientes = New System.Windows.Forms.GroupBox()
        Me.cmbCartuchos = New Eniac.Controles.ComboBox()
        Me.lblCartuchos = New Eniac.Controles.Label()
        Me.btnEjecutar = New Eniac.Controles.Button()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.tssInfo = New System.Windows.Forms.ToolStripStatusLabel()
        Me.tpbBarra = New System.Windows.Forms.ToolStripProgressBar()
        Me.dgvCartuchos = New Eniac.Controles.DataGridView()
        Me.Mensaje = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Tabla = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Registros = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Importados = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Actualizados = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ConErrores = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.rtbBajando = New System.Windows.Forms.RichTextBox()
        Me.tbcPantallas = New System.Windows.Forms.TabControl()
        Me.tbpInfo = New System.Windows.Forms.TabPage()
        Me.tbpCartuchos = New System.Windows.Forms.TabPage()
        Me.tbpErrores = New System.Windows.Forms.TabPage()
        Me.rtbErrores = New System.Windows.Forms.RichTextBox()
        Me.tssInfo2 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.tstBarra.SuspendLayout()
        Me.grbPendientes.SuspendLayout()
        Me.StatusStrip1.SuspendLayout()
        CType(Me.dgvCartuchos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tbcPantallas.SuspendLayout()
        Me.tbpInfo.SuspendLayout()
        Me.tbpCartuchos.SuspendLayout()
        Me.tbpErrores.SuspendLayout()
        Me.SuspendLayout()
        '
        'tstBarra
        '
        Me.tstBarra.AllowItemReorder = True
        Me.tstBarra.ImageScalingSize = New System.Drawing.Size(22, 22)
        Me.tstBarra.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsbRefrescar, Me.ToolStripSeparator1, Me.tsbImportar, Me.toolStripSeparator3, Me.tsbSalir})
        Me.tstBarra.Location = New System.Drawing.Point(0, 0)
        Me.tstBarra.Name = "tstBarra"
        Me.tstBarra.Size = New System.Drawing.Size(839, 34)
        Me.tstBarra.TabIndex = 5
        Me.tstBarra.Text = "toolStrip1"
        '
        'tsbRefrescar
        '
        Me.tsbRefrescar.Image = Global.Eniac.Win.My.Resources.Resources.refresh_32
        Me.tsbRefrescar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbRefrescar.Name = "tsbRefrescar"
        Me.tsbRefrescar.Size = New System.Drawing.Size(143, 33)
        Me.tsbRefrescar.Text = "&Refrescar (F5)"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 38)
        '
        'tsbImportar
        '
        Me.tsbImportar.Image = CType(resources.GetObject("tsbImportar.Image"), System.Drawing.Image)
        Me.tsbImportar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbImportar.Name = "tsbImportar"
        Me.tsbImportar.Size = New System.Drawing.Size(108, 29)
        Me.tsbImportar.Text = "&Importar"
        '
        'toolStripSeparator3
        '
        Me.toolStripSeparator3.Name = "toolStripSeparator3"
        Me.toolStripSeparator3.Size = New System.Drawing.Size(6, 38)
        '
        'tsbSalir
        '
        Me.tsbSalir.Image = Global.Eniac.Win.My.Resources.Resources.close_b_32
        Me.tsbSalir.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbSalir.Name = "tsbSalir"
        Me.tsbSalir.Size = New System.Drawing.Size(85, 33)
        Me.tsbSalir.Text = "&Cerrar"
        Me.tsbSalir.ToolTipText = "Cerrar el formulario"
        '
        'grbPendientes
        '
        Me.grbPendientes.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grbPendientes.Controls.Add(Me.cmbCartuchos)
        Me.grbPendientes.Controls.Add(Me.lblCartuchos)
        Me.grbPendientes.Controls.Add(Me.btnEjecutar)
        Me.grbPendientes.Location = New System.Drawing.Point(14, 32)
        Me.grbPendientes.Name = "grbPendientes"
        Me.grbPendientes.Size = New System.Drawing.Size(809, 67)
        Me.grbPendientes.TabIndex = 6
        Me.grbPendientes.TabStop = False
        '
        'cmbCartuchos
        '
        Me.cmbCartuchos.BindearPropiedadControl = Nothing
        Me.cmbCartuchos.BindearPropiedadEntidad = Nothing
        Me.cmbCartuchos.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbCartuchos.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbCartuchos.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbCartuchos.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbCartuchos.FormattingEnabled = True
        Me.cmbCartuchos.IsPK = False
        Me.cmbCartuchos.IsRequired = False
        Me.cmbCartuchos.Key = Nothing
        Me.cmbCartuchos.LabelAsoc = Me.lblCartuchos
        Me.cmbCartuchos.Location = New System.Drawing.Point(63, 23)
        Me.cmbCartuchos.Name = "cmbCartuchos"
        Me.cmbCartuchos.Size = New System.Drawing.Size(145, 28)
        Me.cmbCartuchos.TabIndex = 13
        '
        'lblCartuchos
        '
        Me.lblCartuchos.AutoSize = True
        Me.lblCartuchos.LabelAsoc = Nothing
        Me.lblCartuchos.Location = New System.Drawing.Point(6, 28)
        Me.lblCartuchos.Name = "lblCartuchos"
        Me.lblCartuchos.Size = New System.Drawing.Size(55, 13)
        Me.lblCartuchos.TabIndex = 12
        Me.lblCartuchos.Text = "Cartuchos"
        '
        'btnEjecutar
        '
        Me.btnEjecutar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnEjecutar.Image = Global.Eniac.Win.My.Resources.Resources.world_down_64
        Me.btnEjecutar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnEjecutar.Location = New System.Drawing.Point(227, 14)
        Me.btnEjecutar.Name = "btnEjecutar"
        Me.btnEjecutar.Size = New System.Drawing.Size(159, 48)
        Me.btnEjecutar.TabIndex = 2
        Me.btnEjecutar.Text = "&Bajar de la Web"
        Me.btnEjecutar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnEjecutar.UseVisualStyleBackColor = True
        '
        'StatusStrip1
        '
        Me.StatusStrip1.ImageScalingSize = New System.Drawing.Size(24, 24)
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tssInfo2, Me.tssInfo, Me.tpbBarra})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 417)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(839, 24)
        Me.StatusStrip1.TabIndex = 8
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'tssInfo
        '
        Me.tssInfo.Name = "tssInfo"
        Me.tssInfo.Size = New System.Drawing.Size(674, 21)
        Me.tssInfo.Spring = True
        Me.tssInfo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'tpbBarra
        '
        Me.tpbBarra.Name = "tpbBarra"
        Me.tpbBarra.Size = New System.Drawing.Size(100, 20)
        '
        'dgvCartuchos
        '
        Me.dgvCartuchos.AllowUserToAddRows = False
        Me.dgvCartuchos.AllowUserToDeleteRows = False
        Me.dgvCartuchos.AllowUserToResizeRows = False
        Me.dgvCartuchos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvCartuchos.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Mensaje, Me.Tabla, Me.Registros, Me.Importados, Me.Actualizados, Me.ConErrores})
        Me.dgvCartuchos.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvCartuchos.Location = New System.Drawing.Point(3, 3)
        Me.dgvCartuchos.Name = "dgvCartuchos"
        Me.dgvCartuchos.ReadOnly = True
        Me.dgvCartuchos.RowHeadersWidth = 15
        Me.dgvCartuchos.Size = New System.Drawing.Size(809, 279)
        Me.dgvCartuchos.TabIndex = 7
        '
        'Mensaje
        '
        Me.Mensaje.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.Mensaje.DataPropertyName = "Proceso"
        Me.Mensaje.HeaderText = "Proceso"
        Me.Mensaje.MinimumWidth = 8
        Me.Mensaje.Name = "Mensaje"
        Me.Mensaje.ReadOnly = True
        '
        'Tabla
        '
        Me.Tabla.DataPropertyName = "Tabla"
        Me.Tabla.HeaderText = "Tabla"
        Me.Tabla.MinimumWidth = 8
        Me.Tabla.Name = "Tabla"
        Me.Tabla.ReadOnly = True
        Me.Tabla.Width = 150
        '
        'Registros
        '
        Me.Registros.DataPropertyName = "Registros"
        DataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.Registros.DefaultCellStyle = DataGridViewCellStyle13
        Me.Registros.HeaderText = "Registros"
        Me.Registros.MinimumWidth = 8
        Me.Registros.Name = "Registros"
        Me.Registros.ReadOnly = True
        Me.Registros.Width = 150
        '
        'Importados
        '
        Me.Importados.DataPropertyName = "Insertados"
        DataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.Importados.DefaultCellStyle = DataGridViewCellStyle14
        Me.Importados.HeaderText = "Insertados"
        Me.Importados.MinimumWidth = 8
        Me.Importados.Name = "Importados"
        Me.Importados.ReadOnly = True
        Me.Importados.Width = 150
        '
        'Actualizados
        '
        Me.Actualizados.DataPropertyName = "Actualizados"
        DataGridViewCellStyle15.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.Actualizados.DefaultCellStyle = DataGridViewCellStyle15
        Me.Actualizados.HeaderText = "Actualizados"
        Me.Actualizados.MinimumWidth = 8
        Me.Actualizados.Name = "Actualizados"
        Me.Actualizados.ReadOnly = True
        Me.Actualizados.Width = 150
        '
        'ConErrores
        '
        Me.ConErrores.DataPropertyName = "ConErrores"
        DataGridViewCellStyle16.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.ConErrores.DefaultCellStyle = DataGridViewCellStyle16
        Me.ConErrores.HeaderText = "Con Errores"
        Me.ConErrores.MinimumWidth = 8
        Me.ConErrores.Name = "ConErrores"
        Me.ConErrores.ReadOnly = True
        Me.ConErrores.Width = 150
        '
        'rtbBajando
        '
        Me.rtbBajando.Dock = System.Windows.Forms.DockStyle.Fill
        Me.rtbBajando.Location = New System.Drawing.Point(3, 3)
        Me.rtbBajando.Name = "rtbBajando"
        Me.rtbBajando.ReadOnly = True
        Me.rtbBajando.Size = New System.Drawing.Size(809, 279)
        Me.rtbBajando.TabIndex = 9
        Me.rtbBajando.Text = ""
        '
        'tbcPantallas
        '
        Me.tbcPantallas.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tbcPantallas.Controls.Add(Me.tbpInfo)
        Me.tbcPantallas.Controls.Add(Me.tbpCartuchos)
        Me.tbcPantallas.Controls.Add(Me.tbpErrores)
        Me.tbcPantallas.Location = New System.Drawing.Point(4, 105)
        Me.tbcPantallas.Name = "tbcPantallas"
        Me.tbcPantallas.SelectedIndex = 0
        Me.tbcPantallas.Size = New System.Drawing.Size(823, 311)
        Me.tbcPantallas.TabIndex = 10
        '
        'tbpInfo
        '
        Me.tbpInfo.Controls.Add(Me.rtbBajando)
        Me.tbpInfo.Location = New System.Drawing.Point(4, 22)
        Me.tbpInfo.Name = "tbpInfo"
        Me.tbpInfo.Padding = New System.Windows.Forms.Padding(3)
        Me.tbpInfo.Size = New System.Drawing.Size(815, 285)
        Me.tbpInfo.TabIndex = 1
        Me.tbpInfo.Text = "Info"
        Me.tbpInfo.UseVisualStyleBackColor = True
        '
        'tbpCartuchos
        '
        Me.tbpCartuchos.Controls.Add(Me.dgvCartuchos)
        Me.tbpCartuchos.Location = New System.Drawing.Point(4, 22)
        Me.tbpCartuchos.Name = "tbpCartuchos"
        Me.tbpCartuchos.Padding = New System.Windows.Forms.Padding(3)
        Me.tbpCartuchos.Size = New System.Drawing.Size(815, 285)
        Me.tbpCartuchos.TabIndex = 0
        Me.tbpCartuchos.Text = "Cartuchos"
        Me.tbpCartuchos.UseVisualStyleBackColor = True
        '
        'tbpErrores
        '
        Me.tbpErrores.Controls.Add(Me.rtbErrores)
        Me.tbpErrores.Location = New System.Drawing.Point(4, 22)
        Me.tbpErrores.Name = "tbpErrores"
        Me.tbpErrores.Size = New System.Drawing.Size(815, 285)
        Me.tbpErrores.TabIndex = 2
        Me.tbpErrores.Text = "Errores"
        Me.tbpErrores.UseVisualStyleBackColor = True
        '
        'rtbErrores
        '
        Me.rtbErrores.Dock = System.Windows.Forms.DockStyle.Fill
        Me.rtbErrores.Location = New System.Drawing.Point(0, 0)
        Me.rtbErrores.Name = "rtbErrores"
        Me.rtbErrores.ReadOnly = True
        Me.rtbErrores.Size = New System.Drawing.Size(815, 285)
        Me.rtbErrores.TabIndex = 10
        Me.rtbErrores.Text = ""
        '
        'tssInfo2
        '
        Me.tssInfo2.Name = "tssInfo2"
        Me.tssInfo2.Size = New System.Drawing.Size(0, 21)
        '
        'ImportarWebSiExport
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(839, 441)
        Me.Controls.Add(Me.tbcPantallas)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.grbPendientes)
        Me.Controls.Add(Me.tstBarra)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(2)
        Me.Name = "ImportarWebSiExport"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Importar Web SiExport"
        Me.tstBarra.ResumeLayout(False)
        Me.tstBarra.PerformLayout()
        Me.grbPendientes.ResumeLayout(False)
        Me.grbPendientes.PerformLayout()
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        CType(Me.dgvCartuchos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tbcPantallas.ResumeLayout(False)
        Me.tbpInfo.ResumeLayout(False)
        Me.tbpCartuchos.ResumeLayout(False)
        Me.tbpErrores.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Public WithEvents tstBarra As ToolStrip
    Public WithEvents tsbRefrescar As ToolStripButton
    Private WithEvents ToolStripSeparator1 As ToolStripSeparator
    Friend WithEvents tsbImportar As ToolStripButton
    Private WithEvents toolStripSeparator3 As ToolStripSeparator
    Public WithEvents tsbSalir As ToolStripButton
    Friend WithEvents grbPendientes As GroupBox
    Friend WithEvents cmbCartuchos As Controles.ComboBox
    Friend WithEvents lblCartuchos As Controles.Label
    Friend WithEvents btnEjecutar As Controles.Button
    Friend WithEvents StatusStrip1 As StatusStrip
    Friend WithEvents dgvCartuchos As Controles.DataGridView
    Friend WithEvents rtbBajando As RichTextBox
    Friend WithEvents tbcPantallas As TabControl
    Friend WithEvents tbpCartuchos As TabPage
    Friend WithEvents tbpInfo As TabPage
    Friend WithEvents tssInfo As ToolStripStatusLabel
    Friend WithEvents tbpErrores As TabPage
    Friend WithEvents rtbErrores As RichTextBox
    Friend WithEvents tpbBarra As ToolStripProgressBar
    Friend WithEvents Mensaje As DataGridViewTextBoxColumn
    Friend WithEvents Tabla As DataGridViewTextBoxColumn
    Friend WithEvents Registros As DataGridViewTextBoxColumn
    Friend WithEvents Importados As DataGridViewTextBoxColumn
    Friend WithEvents Actualizados As DataGridViewTextBoxColumn
    Friend WithEvents ConErrores As DataGridViewTextBoxColumn
    Friend WithEvents tssInfo2 As ToolStripStatusLabel
End Class
