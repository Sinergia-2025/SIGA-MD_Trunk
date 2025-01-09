<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ConsultarCodigosLibres
   Inherits Win.BaseForm

   'Form overrides dispose to clean up the component list.
   <System.Diagnostics.DebuggerNonUserCode()> _
   Protected Overrides Sub Dispose(ByVal disposing As Boolean)
      If disposing AndAlso components IsNot Nothing Then
         components.Dispose()
      End If
      MyBase.Dispose(disposing)
   End Sub

   'Required by the Windows Form Designer
   Private components As System.ComponentModel.IContainer

   'NOTE: The following procedure is required by the Windows Form Designer
   'It can be modified using the Windows Form Designer.  
   'Do not modify it using the code editor.
   <System.Diagnostics.DebuggerStepThrough()> _
   Private Sub InitializeComponent()
      Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
      Dim DataGridViewCellStyle10 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
      Dim DataGridViewCellStyle11 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
      Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
      Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
      Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
      Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
      Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
      Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
      Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
      Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
      Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ConsultarCodigosLibres))
      Me.dgvCodigoLibres = New Eniac.Controles.DataGridView()
      Me.Col1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.Col2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.Col3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.Col4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.Col5 = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.Col6 = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.Col7 = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.Col8 = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.tspFichas = New System.Windows.Forms.ToolStrip()
      Me.tsbSalir = New System.Windows.Forms.ToolStripButton()
      Me.grbConsulta = New System.Windows.Forms.GroupBox()
      Me.cmbTabla = New Eniac.Controles.ComboBox()
      Me.txtHasta = New Eniac.Controles.TextBox()
      Me.lblHasta = New Eniac.Controles.Label()
      Me.btnConsultar = New Eniac.Controles.Button()
      Me.txtDesde = New Eniac.Controles.TextBox()
      Me.lblDesde = New Eniac.Controles.Label()
      Me.stsStado = New System.Windows.Forms.StatusStrip()
      Me.tssInfo = New System.Windows.Forms.ToolStripStatusLabel()
      Me.tspBarra = New System.Windows.Forms.ToolStripProgressBar()
      Me.tssRegistros = New System.Windows.Forms.ToolStripStatusLabel()
      CType(Me.dgvCodigoLibres, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.tspFichas.SuspendLayout()
      Me.grbConsulta.SuspendLayout()
      Me.stsStado.SuspendLayout()
      Me.SuspendLayout()
      '
      'dgvCodigoLibres
      '
      Me.dgvCodigoLibres.AllowUserToAddRows = False
      Me.dgvCodigoLibres.AllowUserToDeleteRows = False
      Me.dgvCodigoLibres.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
      DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
      DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
      DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
      DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
      DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
      Me.dgvCodigoLibres.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
      Me.dgvCodigoLibres.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
      Me.dgvCodigoLibres.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Col1, Me.Col2, Me.Col3, Me.Col4, Me.Col5, Me.Col6, Me.Col7, Me.Col8})
      DataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
      DataGridViewCellStyle10.BackColor = System.Drawing.SystemColors.Window
      DataGridViewCellStyle10.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      DataGridViewCellStyle10.ForeColor = System.Drawing.SystemColors.ControlText
      DataGridViewCellStyle10.SelectionBackColor = System.Drawing.SystemColors.Highlight
      DataGridViewCellStyle10.SelectionForeColor = System.Drawing.SystemColors.HighlightText
      DataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
      Me.dgvCodigoLibres.DefaultCellStyle = DataGridViewCellStyle10
      Me.dgvCodigoLibres.Location = New System.Drawing.Point(1, 79)
      Me.dgvCodigoLibres.MultiSelect = False
      Me.dgvCodigoLibres.Name = "dgvCodigoLibres"
      DataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
      DataGridViewCellStyle11.BackColor = System.Drawing.SystemColors.Control
      DataGridViewCellStyle11.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      DataGridViewCellStyle11.ForeColor = System.Drawing.SystemColors.WindowText
      DataGridViewCellStyle11.SelectionBackColor = System.Drawing.SystemColors.Highlight
      DataGridViewCellStyle11.SelectionForeColor = System.Drawing.SystemColors.HighlightText
      DataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
      Me.dgvCodigoLibres.RowHeadersDefaultCellStyle = DataGridViewCellStyle11
      Me.dgvCodigoLibres.RowHeadersVisible = False
      Me.dgvCodigoLibres.RowHeadersWidth = 4
      Me.dgvCodigoLibres.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
      Me.dgvCodigoLibres.Size = New System.Drawing.Size(743, 374)
      Me.dgvCodigoLibres.TabIndex = 1
      '
      'Col1
      '
      Me.Col1.DataPropertyName = "Col1"
      DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
      DataGridViewCellStyle2.Format = "#"
      DataGridViewCellStyle2.NullValue = Nothing
      Me.Col1.DefaultCellStyle = DataGridViewCellStyle2
      Me.Col1.HeaderText = "Col. 1"
      Me.Col1.Name = "Col1"
      Me.Col1.ReadOnly = True
      Me.Col1.Width = 90
      '
      'Col2
      '
      Me.Col2.DataPropertyName = "Col2"
      DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
      DataGridViewCellStyle3.Format = "#"
      DataGridViewCellStyle3.NullValue = Nothing
      Me.Col2.DefaultCellStyle = DataGridViewCellStyle3
      Me.Col2.HeaderText = "Col. 2"
      Me.Col2.Name = "Col2"
      Me.Col2.ReadOnly = True
      Me.Col2.Width = 90
      '
      'Col3
      '
      Me.Col3.DataPropertyName = "Col3"
      DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
      DataGridViewCellStyle4.Format = "#"
      Me.Col3.DefaultCellStyle = DataGridViewCellStyle4
      Me.Col3.HeaderText = "Col. 3"
      Me.Col3.Name = "Col3"
      Me.Col3.ReadOnly = True
      Me.Col3.Width = 90
      '
      'Col4
      '
      Me.Col4.DataPropertyName = "Col4"
      DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
      DataGridViewCellStyle5.Format = "#"
      Me.Col4.DefaultCellStyle = DataGridViewCellStyle5
      Me.Col4.HeaderText = "Col. 4"
      Me.Col4.Name = "Col4"
      Me.Col4.ReadOnly = True
      Me.Col4.Width = 90
      '
      'Col5
      '
      Me.Col5.DataPropertyName = "Col5"
      DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
      DataGridViewCellStyle6.Format = "#"
      Me.Col5.DefaultCellStyle = DataGridViewCellStyle6
      Me.Col5.HeaderText = "Col. 5"
      Me.Col5.Name = "Col5"
      Me.Col5.ReadOnly = True
      Me.Col5.Width = 90
      '
      'Col6
      '
      Me.Col6.DataPropertyName = "Col6"
      DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
      DataGridViewCellStyle7.Format = "#"
      Me.Col6.DefaultCellStyle = DataGridViewCellStyle7
      Me.Col6.HeaderText = "Col. 6"
      Me.Col6.Name = "Col6"
      Me.Col6.ReadOnly = True
      Me.Col6.Width = 90
      '
      'Col7
      '
      Me.Col7.DataPropertyName = "Col7"
      DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
      DataGridViewCellStyle8.Format = "#"
      Me.Col7.DefaultCellStyle = DataGridViewCellStyle8
      Me.Col7.HeaderText = "Col. 7"
      Me.Col7.Name = "Col7"
      Me.Col7.ReadOnly = True
      Me.Col7.Width = 90
      '
      'Col8
      '
      Me.Col8.DataPropertyName = "Col8"
      DataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
      DataGridViewCellStyle9.Format = "#"
      Me.Col8.DefaultCellStyle = DataGridViewCellStyle9
      Me.Col8.HeaderText = "Col. 8"
      Me.Col8.Name = "Col8"
      Me.Col8.ReadOnly = True
      Me.Col8.Width = 90
      '
      'tspFichas
      '
      Me.tspFichas.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsbSalir})
      Me.tspFichas.Location = New System.Drawing.Point(0, 0)
      Me.tspFichas.Name = "tspFichas"
      Me.tspFichas.Size = New System.Drawing.Size(747, 25)
      Me.tspFichas.TabIndex = 2
      Me.tspFichas.Text = "Números de comprobantes"
      '
      'tsbSalir
      '
      Me.tsbSalir.Image = Global.Eniac.Win.My.Resources.Resources.close_b_32
      Me.tsbSalir.ImageTransparentColor = System.Drawing.Color.Magenta
      Me.tsbSalir.Name = "tsbSalir"
      Me.tsbSalir.Size = New System.Drawing.Size(59, 22)
      Me.tsbSalir.Text = "&Cerrar"
      '
      'grbConsulta
      '
      Me.grbConsulta.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.grbConsulta.Controls.Add(Me.cmbTabla)
      Me.grbConsulta.Controls.Add(Me.txtHasta)
      Me.grbConsulta.Controls.Add(Me.btnConsultar)
      Me.grbConsulta.Controls.Add(Me.txtDesde)
      Me.grbConsulta.Controls.Add(Me.lblHasta)
      Me.grbConsulta.Controls.Add(Me.lblDesde)
      Me.grbConsulta.Location = New System.Drawing.Point(12, 28)
      Me.grbConsulta.Name = "grbConsulta"
      Me.grbConsulta.Size = New System.Drawing.Size(732, 45)
      Me.grbConsulta.TabIndex = 0
      Me.grbConsulta.TabStop = False
      '
      'cmbTabla
      '
      Me.cmbTabla.BindearPropiedadControl = Nothing
      Me.cmbTabla.BindearPropiedadEntidad = Nothing
      Me.cmbTabla.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cmbTabla.ForeColorFocus = System.Drawing.Color.Red
      Me.cmbTabla.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.cmbTabla.FormattingEnabled = True
      Me.cmbTabla.IsPK = False
      Me.cmbTabla.IsRequired = False
      Me.cmbTabla.Key = Nothing
      Me.cmbTabla.LabelAsoc = Nothing
      Me.cmbTabla.Location = New System.Drawing.Point(6, 16)
      Me.cmbTabla.Name = "cmbTabla"
      Me.cmbTabla.Size = New System.Drawing.Size(152, 21)
      Me.cmbTabla.TabIndex = 0
      '
      'txtHasta
      '
      Me.txtHasta.BindearPropiedadControl = Nothing
      Me.txtHasta.BindearPropiedadEntidad = Nothing
      Me.txtHasta.ForeColorFocus = System.Drawing.Color.Red
      Me.txtHasta.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtHasta.Formato = ""
      Me.txtHasta.IsDecimal = False
      Me.txtHasta.IsNumber = True
      Me.txtHasta.IsPK = False
      Me.txtHasta.IsRequired = False
      Me.txtHasta.Key = ""
      Me.txtHasta.LabelAsoc = Me.lblHasta
      Me.txtHasta.Location = New System.Drawing.Point(369, 16)
      Me.txtHasta.MaxLength = 9
      Me.txtHasta.Name = "txtHasta"
      Me.txtHasta.Size = New System.Drawing.Size(68, 20)
      Me.txtHasta.TabIndex = 4
      Me.txtHasta.Text = "100"
      Me.txtHasta.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'lblHasta
      '
      Me.lblHasta.AutoSize = True
      Me.lblHasta.Location = New System.Drawing.Point(306, 20)
      Me.lblHasta.Name = "lblHasta"
      Me.lblHasta.Size = New System.Drawing.Size(59, 13)
      Me.lblHasta.TabIndex = 3
      Me.lblHasta.Text = "Hasta el nº"
      '
      'btnConsultar
      '
      Me.btnConsultar.Location = New System.Drawing.Point(635, 14)
      Me.btnConsultar.Name = "btnConsultar"
      Me.btnConsultar.Size = New System.Drawing.Size(75, 23)
      Me.btnConsultar.TabIndex = 5
      Me.btnConsultar.Text = "&Consultar"
      Me.btnConsultar.UseVisualStyleBackColor = True
      '
      'txtDesde
      '
      Me.txtDesde.BindearPropiedadControl = Nothing
      Me.txtDesde.BindearPropiedadEntidad = Nothing
      Me.txtDesde.ForeColorFocus = System.Drawing.Color.Red
      Me.txtDesde.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtDesde.Formato = ""
      Me.txtDesde.IsDecimal = False
      Me.txtDesde.IsNumber = True
      Me.txtDesde.IsPK = False
      Me.txtDesde.IsRequired = False
      Me.txtDesde.Key = ""
      Me.txtDesde.LabelAsoc = Me.lblDesde
      Me.txtDesde.Location = New System.Drawing.Point(233, 16)
      Me.txtDesde.MaxLength = 9
      Me.txtDesde.Name = "txtDesde"
      Me.txtDesde.Size = New System.Drawing.Size(63, 20)
      Me.txtDesde.TabIndex = 2
      Me.txtDesde.Text = "1"
      Me.txtDesde.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'lblDesde
      '
      Me.lblDesde.AutoSize = True
      Me.lblDesde.Location = New System.Drawing.Point(167, 20)
      Me.lblDesde.Name = "lblDesde"
      Me.lblDesde.Size = New System.Drawing.Size(62, 13)
      Me.lblDesde.TabIndex = 1
      Me.lblDesde.Text = "Desde el nº"
      '
      'stsStado
      '
      Me.stsStado.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tssInfo, Me.tspBarra, Me.tssRegistros})
      Me.stsStado.Location = New System.Drawing.Point(0, 456)
      Me.stsStado.Name = "stsStado"
      Me.stsStado.Size = New System.Drawing.Size(747, 22)
      Me.stsStado.TabIndex = 14
      Me.stsStado.Text = "statusStrip1"
      '
      'tssInfo
      '
      Me.tssInfo.Name = "tssInfo"
      Me.tssInfo.Size = New System.Drawing.Size(668, 17)
      Me.tssInfo.Spring = True
      '
      'tspBarra
      '
      Me.tspBarra.Name = "tspBarra"
      Me.tspBarra.Size = New System.Drawing.Size(100, 16)
      Me.tspBarra.Style = System.Windows.Forms.ProgressBarStyle.Continuous
      Me.tspBarra.Visible = False
      '
      'tssRegistros
      '
      Me.tssRegistros.Name = "tssRegistros"
      Me.tssRegistros.Size = New System.Drawing.Size(64, 17)
      Me.tssRegistros.Text = "0 Registros"
      '
      'ConsultarCodigosLibres
      '
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.ClientSize = New System.Drawing.Size(747, 478)
      Me.Controls.Add(Me.stsStado)
      Me.Controls.Add(Me.grbConsulta)
      Me.Controls.Add(Me.tspFichas)
      Me.Controls.Add(Me.dgvCodigoLibres)
      Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
      Me.Name = "ConsultarCodigosLibres"
      Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
      Me.Text = "Consultar códigos númericos libres"
      CType(Me.dgvCodigoLibres, System.ComponentModel.ISupportInitialize).EndInit()
      Me.tspFichas.ResumeLayout(False)
      Me.tspFichas.PerformLayout()
      Me.grbConsulta.ResumeLayout(False)
      Me.grbConsulta.PerformLayout()
      Me.stsStado.ResumeLayout(False)
      Me.stsStado.PerformLayout()
      Me.ResumeLayout(False)
      Me.PerformLayout()

   End Sub
   Friend WithEvents dgvCodigoLibres As Eniac.Controles.DataGridView
   Friend WithEvents tspFichas As System.Windows.Forms.ToolStrip
   Friend WithEvents tsbSalir As System.Windows.Forms.ToolStripButton
   Friend WithEvents grbConsulta As System.Windows.Forms.GroupBox
   Friend WithEvents lblHasta As Eniac.Controles.Label
   Friend WithEvents lblDesde As Eniac.Controles.Label
   Friend WithEvents cmbTabla As Eniac.Controles.ComboBox
   Friend WithEvents txtHasta As Eniac.Controles.TextBox
   Friend WithEvents btnConsultar As Eniac.Controles.Button
   Friend WithEvents txtDesde As Eniac.Controles.TextBox
   Protected Friend WithEvents stsStado As System.Windows.Forms.StatusStrip
   Protected Friend WithEvents tssInfo As System.Windows.Forms.ToolStripStatusLabel
   Protected Friend WithEvents tspBarra As System.Windows.Forms.ToolStripProgressBar
   Protected WithEvents tssRegistros As System.Windows.Forms.ToolStripStatusLabel
   Friend WithEvents Col1 As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents Col2 As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents Col3 As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents Col4 As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents Col5 As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents Col6 As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents Col7 As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents Col8 As System.Windows.Forms.DataGridViewTextBoxColumn

End Class
