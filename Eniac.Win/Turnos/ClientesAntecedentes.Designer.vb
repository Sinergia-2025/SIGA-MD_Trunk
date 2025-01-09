<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ClientesAntecedentes
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
      Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ClientesAntecedentes))
      Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
      Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
      Me.tstBarra = New System.Windows.Forms.ToolStrip()
      Me.tsbRefrescar = New System.Windows.Forms.ToolStripButton()
      Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
      Me.tsbGrabar = New System.Windows.Forms.ToolStripButton()
      Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
      Me.tsbCerrar = New System.Windows.Forms.ToolStripButton()
      Me.grbFiltros = New System.Windows.Forms.GroupBox()
      Me.bscCodigoCliente = New Eniac.Controles.Buscador2()
      Me.lblCodigoCliente = New Eniac.Controles.Label()
      Me.bscCliente = New Eniac.Controles.Buscador2()
      Me.lblNombre = New Eniac.Controles.Label()
      Me.picImagen = New System.Windows.Forms.PictureBox()
      Me.lsbTiposAntecedentes = New System.Windows.Forms.ListBox()
      Me.grbTiposAntecedentes = New System.Windows.Forms.GroupBox()
      Me.CheckBox1 = New System.Windows.Forms.CheckBox()
      Me.dgvAntecedentes = New Eniac.Controles.DataGridView()
      Me.colIdAntecedente = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.colNombreAntecedente = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.colValor = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.colFechaActualizacion = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.tstBarra.SuspendLayout()
      Me.grbFiltros.SuspendLayout()
      CType(Me.picImagen, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.grbTiposAntecedentes.SuspendLayout()
      CType(Me.dgvAntecedentes, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.SuspendLayout()
      '
      'tstBarra
      '
      Me.tstBarra.AllowItemReorder = True
      Me.tstBarra.ImageScalingSize = New System.Drawing.Size(22, 22)
      Me.tstBarra.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsbRefrescar, Me.ToolStripSeparator2, Me.tsbGrabar, Me.ToolStripSeparator1, Me.tsbCerrar})
      Me.tstBarra.Location = New System.Drawing.Point(0, 0)
      Me.tstBarra.Name = "tstBarra"
      Me.tstBarra.Size = New System.Drawing.Size(877, 29)
      Me.tstBarra.TabIndex = 3
      '
      'tsbRefrescar
      '
      Me.tsbRefrescar.Image = Global.Eniac.Win.My.Resources.Resources.refresh_32
      Me.tsbRefrescar.ImageTransparentColor = System.Drawing.Color.Magenta
      Me.tsbRefrescar.Name = "tsbRefrescar"
      Me.tsbRefrescar.Size = New System.Drawing.Size(104, 26)
      Me.tsbRefrescar.Text = "&Refrescar (F5)"
      '
      'ToolStripSeparator2
      '
      Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
      Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 29)
      '
      'tsbGrabar
      '
      Me.tsbGrabar.Image = Global.Eniac.Win.My.Resources.Resources.diskette_32
      Me.tsbGrabar.ImageTransparentColor = System.Drawing.Color.Magenta
      Me.tsbGrabar.Name = "tsbGrabar"
      Me.tsbGrabar.Size = New System.Drawing.Size(68, 26)
      Me.tsbGrabar.Text = "&Grabar"
      Me.tsbGrabar.Visible = False
      '
      'ToolStripSeparator1
      '
      Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
      Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 29)
      Me.ToolStripSeparator1.Visible = False
      '
      'tsbCerrar
      '
      Me.tsbCerrar.Image = Global.Eniac.Win.My.Resources.Resources.close_b_32
      Me.tsbCerrar.ImageTransparentColor = System.Drawing.Color.Magenta
      Me.tsbCerrar.Name = "tsbCerrar"
      Me.tsbCerrar.Size = New System.Drawing.Size(65, 26)
      Me.tsbCerrar.Text = "&Cerrar"
      '
      'grbFiltros
      '
      Me.grbFiltros.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
      Me.grbFiltros.Controls.Add(Me.bscCodigoCliente)
      Me.grbFiltros.Controls.Add(Me.bscCliente)
      Me.grbFiltros.Controls.Add(Me.lblCodigoCliente)
      Me.grbFiltros.Controls.Add(Me.lblNombre)
      Me.grbFiltros.Controls.Add(Me.picImagen)
      Me.grbFiltros.Location = New System.Drawing.Point(12, 35)
      Me.grbFiltros.Name = "grbFiltros"
      Me.grbFiltros.Size = New System.Drawing.Size(249, 377)
      Me.grbFiltros.TabIndex = 4
      Me.grbFiltros.TabStop = False
      Me.grbFiltros.Text = "Cliente"
      '
      'bscCodigoCliente
      '
      Me.bscCodigoCliente.ActivarFiltroEnGrilla = True
      Me.bscCodigoCliente.BindearPropiedadControl = Nothing
      Me.bscCodigoCliente.BindearPropiedadEntidad = Nothing
      Me.bscCodigoCliente.ColumnasCondiciones = CType(resources.GetObject("bscCodigoCliente.ColumnasCondiciones"), System.Collections.Generic.List(Of Eniac.Controles.ColumnaCondicion))
      Me.bscCodigoCliente.ColumnasVisibles = CType(resources.GetObject("bscCodigoCliente.ColumnasVisibles"), System.Collections.Generic.List(Of Eniac.Controles.ColumnaBuscador))
      Me.bscCodigoCliente.Datos = Nothing
      Me.bscCodigoCliente.FilaDevuelta = Nothing
      Me.bscCodigoCliente.ForeColorFocus = System.Drawing.Color.Red
      Me.bscCodigoCliente.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
      Me.bscCodigoCliente.IsDecimal = False
      Me.bscCodigoCliente.IsNumber = False
      Me.bscCodigoCliente.IsPK = False
      Me.bscCodigoCliente.IsRequired = False
      Me.bscCodigoCliente.Key = ""
      Me.bscCodigoCliente.LabelAsoc = Me.lblCodigoCliente
      Me.bscCodigoCliente.Location = New System.Drawing.Point(12, 36)
      Me.bscCodigoCliente.MaxLengh = "32767"
      Me.bscCodigoCliente.Name = "bscCodigoCliente"
      Me.bscCodigoCliente.Permitido = True
      Me.bscCodigoCliente.Selecciono = False
      Me.bscCodigoCliente.Size = New System.Drawing.Size(133, 20)
      Me.bscCodigoCliente.TabIndex = 43
      '
      'lblCodigoCliente
      '
      Me.lblCodigoCliente.AutoSize = True
      Me.lblCodigoCliente.Location = New System.Drawing.Point(11, 21)
      Me.lblCodigoCliente.Name = "lblCodigoCliente"
      Me.lblCodigoCliente.Size = New System.Drawing.Size(40, 13)
      Me.lblCodigoCliente.TabIndex = 42
      Me.lblCodigoCliente.Text = "Código"
      '
      'bscCliente
      '
      Me.bscCliente.ActivarFiltroEnGrilla = True
      Me.bscCliente.AutoSize = True
      Me.bscCliente.BindearPropiedadControl = Nothing
      Me.bscCliente.BindearPropiedadEntidad = Nothing
      Me.bscCliente.ColumnasCondiciones = CType(resources.GetObject("bscCliente.ColumnasCondiciones"), System.Collections.Generic.List(Of Eniac.Controles.ColumnaCondicion))
      Me.bscCliente.ColumnasVisibles = CType(resources.GetObject("bscCliente.ColumnasVisibles"), System.Collections.Generic.List(Of Eniac.Controles.ColumnaBuscador))
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
      Me.bscCliente.Location = New System.Drawing.Point(12, 83)
      Me.bscCliente.Margin = New System.Windows.Forms.Padding(4)
      Me.bscCliente.MaxLengh = "32767"
      Me.bscCliente.Name = "bscCliente"
      Me.bscCliente.Permitido = True
      Me.bscCliente.Selecciono = False
      Me.bscCliente.Size = New System.Drawing.Size(227, 23)
      Me.bscCliente.TabIndex = 45
      '
      'lblNombre
      '
      Me.lblNombre.AutoSize = True
      Me.lblNombre.Location = New System.Drawing.Point(9, 68)
      Me.lblNombre.Name = "lblNombre"
      Me.lblNombre.Size = New System.Drawing.Size(79, 13)
      Me.lblNombre.TabIndex = 44
      Me.lblNombre.Text = "Nombre Cliente"
      '
      'picImagen
      '
      Me.picImagen.InitialImage = Nothing
      Me.picImagen.Location = New System.Drawing.Point(8, 128)
      Me.picImagen.Name = "picImagen"
      Me.picImagen.Size = New System.Drawing.Size(231, 200)
      Me.picImagen.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
      Me.picImagen.TabIndex = 40
      Me.picImagen.TabStop = False
      '
      'lsbTiposAntecedentes
      '
      Me.lsbTiposAntecedentes.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.lsbTiposAntecedentes.FormattingEnabled = True
      Me.lsbTiposAntecedentes.Location = New System.Drawing.Point(6, 41)
      Me.lsbTiposAntecedentes.Name = "lsbTiposAntecedentes"
      Me.lsbTiposAntecedentes.Size = New System.Drawing.Size(170, 329)
      Me.lsbTiposAntecedentes.TabIndex = 13
      '
      'grbTiposAntecedentes
      '
      Me.grbTiposAntecedentes.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
      Me.grbTiposAntecedentes.Controls.Add(Me.CheckBox1)
      Me.grbTiposAntecedentes.Controls.Add(Me.lsbTiposAntecedentes)
      Me.grbTiposAntecedentes.Location = New System.Drawing.Point(267, 35)
      Me.grbTiposAntecedentes.Name = "grbTiposAntecedentes"
      Me.grbTiposAntecedentes.Size = New System.Drawing.Size(182, 376)
      Me.grbTiposAntecedentes.TabIndex = 14
      Me.grbTiposAntecedentes.TabStop = False
      Me.grbTiposAntecedentes.Text = "Tipos de Antecedentes"
      '
      'CheckBox1
      '
      Me.CheckBox1.AutoSize = True
      Me.CheckBox1.Location = New System.Drawing.Point(8, 22)
      Me.CheckBox1.Name = "CheckBox1"
      Me.CheckBox1.Size = New System.Drawing.Size(83, 17)
      Me.CheckBox1.TabIndex = 14
      Me.CheckBox1.Text = "Con Valores"
      Me.CheckBox1.UseVisualStyleBackColor = True
      '
      'dgvAntecedentes
      '
      Me.dgvAntecedentes.AllowUserToAddRows = False
      Me.dgvAntecedentes.AllowUserToDeleteRows = False
      Me.dgvAntecedentes.AllowUserToOrderColumns = True
      Me.dgvAntecedentes.AllowUserToResizeRows = False
      DataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
      Me.dgvAntecedentes.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle3
      Me.dgvAntecedentes.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.dgvAntecedentes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
      Me.dgvAntecedentes.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colIdAntecedente, Me.colNombreAntecedente, Me.colValor, Me.colFechaActualizacion})
      Me.dgvAntecedentes.Location = New System.Drawing.Point(455, 36)
      Me.dgvAntecedentes.Name = "dgvAntecedentes"
      Me.dgvAntecedentes.RowHeadersVisible = False
      Me.dgvAntecedentes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
      Me.dgvAntecedentes.Size = New System.Drawing.Size(410, 376)
      Me.dgvAntecedentes.TabIndex = 15
      '
      'colIdAntecedente
      '
      Me.colIdAntecedente.DataPropertyName = "IdAntecedente"
      Me.colIdAntecedente.HeaderText = "IdAntecedente"
      Me.colIdAntecedente.Name = "colIdAntecedente"
      Me.colIdAntecedente.Visible = False
      '
      'colNombreAntecedente
      '
      Me.colNombreAntecedente.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
      Me.colNombreAntecedente.DataPropertyName = "NombreAntecedente"
      Me.colNombreAntecedente.HeaderText = "Antecedente"
      Me.colNombreAntecedente.Name = "colNombreAntecedente"
      Me.colNombreAntecedente.ReadOnly = True
      '
      'colValor
      '
      Me.colValor.DataPropertyName = "Valor"
      Me.colValor.HeaderText = "Valor"
      Me.colValor.MaxInputLength = 100
      Me.colValor.Name = "colValor"
      Me.colValor.Width = 150
      '
      'colFechaActualizacion
      '
      Me.colFechaActualizacion.DataPropertyName = "FechaActualizacion"
      DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
      DataGridViewCellStyle4.Format = "dd/MM/yyyy"
      Me.colFechaActualizacion.DefaultCellStyle = DataGridViewCellStyle4
      Me.colFechaActualizacion.HeaderText = "Fecha Act."
      Me.colFechaActualizacion.Name = "colFechaActualizacion"
      Me.colFechaActualizacion.ReadOnly = True
      Me.colFechaActualizacion.Width = 90
      '
      'ClientesAntecedentes
      '
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.ClientSize = New System.Drawing.Size(877, 424)
      Me.Controls.Add(Me.dgvAntecedentes)
      Me.Controls.Add(Me.grbTiposAntecedentes)
      Me.Controls.Add(Me.grbFiltros)
      Me.Controls.Add(Me.tstBarra)
      Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
      Me.KeyPreview = True
      Me.Name = "ClientesAntecedentes"
      Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
      Me.Text = "Antecedentes de Clientes"
      Me.tstBarra.ResumeLayout(False)
      Me.tstBarra.PerformLayout()
      Me.grbFiltros.ResumeLayout(False)
      Me.grbFiltros.PerformLayout()
      CType(Me.picImagen, System.ComponentModel.ISupportInitialize).EndInit()
      Me.grbTiposAntecedentes.ResumeLayout(False)
      Me.grbTiposAntecedentes.PerformLayout()
      CType(Me.dgvAntecedentes, System.ComponentModel.ISupportInitialize).EndInit()
      Me.ResumeLayout(False)
      Me.PerformLayout()

   End Sub
   Friend WithEvents tstBarra As System.Windows.Forms.ToolStrip
   Friend WithEvents tsbRefrescar As System.Windows.Forms.ToolStripButton
   Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
   Friend WithEvents tsbCerrar As System.Windows.Forms.ToolStripButton
   Friend WithEvents grbFiltros As System.Windows.Forms.GroupBox
   Friend WithEvents picImagen As System.Windows.Forms.PictureBox
   Friend WithEvents lsbTiposAntecedentes As System.Windows.Forms.ListBox
   Friend WithEvents grbTiposAntecedentes As System.Windows.Forms.GroupBox
   Friend WithEvents dgvAntecedentes As Eniac.Controles.DataGridView
   Friend WithEvents colIdAntecedente As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents colNombreAntecedente As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents colValor As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents colFechaActualizacion As System.Windows.Forms.DataGridViewTextBoxColumn
   Protected WithEvents bscCodigoCliente As Eniac.Controles.Buscador2
   Protected WithEvents lblCodigoCliente As Eniac.Controles.Label
   Protected WithEvents bscCliente As Eniac.Controles.Buscador2
   Protected WithEvents lblNombre As Eniac.Controles.Label
   Friend WithEvents CheckBox1 As System.Windows.Forms.CheckBox
   Friend WithEvents tsbGrabar As System.Windows.Forms.ToolStripButton
   Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
End Class
