<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ConsultaNumeracionVentas
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
      Me.components = New System.ComponentModel.Container()
      Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ConsultaNumeracionVentas))
      Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
      Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
      Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
      Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
      Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
      Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
      Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
      Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
      Me.imgIconos = New System.Windows.Forms.ImageList(Me.components)
      Me.tspFichas = New System.Windows.Forms.ToolStrip()
      Me.tsbRefrescar = New System.Windows.Forms.ToolStripButton()
      Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
      Me.tsbSalir = New System.Windows.Forms.ToolStripButton()
      Me.dtgVentas = New Eniac.Controles.DataGridView()
      Me.IdTipoComprobante = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.TipoComprobante = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.LetraFiscal = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.CentroEmisor = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.Numero = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.Fecha = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.IdTipoComprobanteRelacionado = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.ComparteEntreSucursales = New System.Windows.Forms.DataGridViewCheckBoxColumn()
      Me.EsRecibo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.pnlGeneral = New System.Windows.Forms.Panel()
        Me.tspFichas.SuspendLayout()
        CType(Me.dtgVentas, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlGeneral.SuspendLayout()
        Me.SuspendLayout()
        '
        'imgIconos
        '
        Me.imgIconos.ImageStream = CType(resources.GetObject("imgIconos.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.imgIconos.TransparentColor = System.Drawing.Color.Transparent
        Me.imgIconos.Images.SetKeyName(0, "row_add.ico")
        Me.imgIconos.Images.SetKeyName(1, "row_delete.ico")
        Me.imgIconos.Images.SetKeyName(2, "disk_blue.ico")
        '
        'tspFichas
        '
        Me.tspFichas.ImageScalingSize = New System.Drawing.Size(24, 24)
        Me.tspFichas.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsbRefrescar, Me.ToolStripSeparator1, Me.tsbSalir})
        Me.tspFichas.Location = New System.Drawing.Point(0, 0)
        Me.tspFichas.Name = "tspFichas"
        Me.tspFichas.Size = New System.Drawing.Size(884, 31)
        Me.tspFichas.TabIndex = 3
        Me.tspFichas.Text = "Números de comprobantes"
        '
        'tsbRefrescar
        '
        Me.tsbRefrescar.Image = Global.Eniac.Win.My.Resources.Resources.refresh_32
        Me.tsbRefrescar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbRefrescar.Name = "tsbRefrescar"
        Me.tsbRefrescar.Size = New System.Drawing.Size(106, 28)
        Me.tsbRefrescar.Text = "&Refrescar (F5)"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 31)
        '
        'tsbSalir
        '
        Me.tsbSalir.Image = Global.Eniac.Win.My.Resources.Resources.close_b_32
        Me.tsbSalir.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbSalir.Name = "tsbSalir"
        Me.tsbSalir.Size = New System.Drawing.Size(67, 28)
        Me.tsbSalir.Text = "&Cerrar"
        '
        'dtgVentas
        '
        Me.dtgVentas.AllowUserToAddRows = False
        Me.dtgVentas.AllowUserToDeleteRows = False
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dtgVentas.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dtgVentas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dtgVentas.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.IdTipoComprobante, Me.TipoComprobante, Me.LetraFiscal, Me.CentroEmisor, Me.Numero, Me.Fecha, Me.IdTipoComprobanteRelacionado, Me.ComparteEntreSucursales, Me.EsRecibo})
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dtgVentas.DefaultCellStyle = DataGridViewCellStyle7
        Me.dtgVentas.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dtgVentas.Location = New System.Drawing.Point(10, 10)
        Me.dtgVentas.MultiSelect = False
        Me.dtgVentas.Name = "dtgVentas"
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dtgVentas.RowHeadersDefaultCellStyle = DataGridViewCellStyle8
        Me.dtgVentas.RowHeadersVisible = False
        Me.dtgVentas.RowHeadersWidth = 4
        Me.dtgVentas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.dtgVentas.Size = New System.Drawing.Size(864, 510)
        Me.dtgVentas.TabIndex = 12
        '
        'IdTipoComprobante
        '
        Me.IdTipoComprobante.DataPropertyName = "IdTipoComprobante"
        Me.IdTipoComprobante.HeaderText = "IdTipoComprobante"
        Me.IdTipoComprobante.Name = "IdTipoComprobante"
        Me.IdTipoComprobante.Visible = False
        '
        'TipoComprobante
        '
        Me.TipoComprobante.DataPropertyName = "TipoComprobante"
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        Me.TipoComprobante.DefaultCellStyle = DataGridViewCellStyle2
        Me.TipoComprobante.HeaderText = "Tipo Comprobante"
        Me.TipoComprobante.Name = "TipoComprobante"
        Me.TipoComprobante.ReadOnly = True
        Me.TipoComprobante.Width = 200
        '
        'LetraFiscal
        '
        Me.LetraFiscal.DataPropertyName = "LetraFiscal"
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.LetraFiscal.DefaultCellStyle = DataGridViewCellStyle3
        Me.LetraFiscal.HeaderText = "Letra"
        Me.LetraFiscal.Name = "LetraFiscal"
        Me.LetraFiscal.ReadOnly = True
        Me.LetraFiscal.Width = 50
        '
        'CentroEmisor
        '
        Me.CentroEmisor.DataPropertyName = "CentroEmisor"
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.CentroEmisor.DefaultCellStyle = DataGridViewCellStyle4
        Me.CentroEmisor.HeaderText = "Emisor"
        Me.CentroEmisor.Name = "CentroEmisor"
        Me.CentroEmisor.ReadOnly = True
        Me.CentroEmisor.Width = 50
        '
        'Numero
        '
        Me.Numero.DataPropertyName = "Numero"
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle5.Format = "N0"
        DataGridViewCellStyle5.NullValue = Nothing
        Me.Numero.DefaultCellStyle = DataGridViewCellStyle5
        Me.Numero.HeaderText = "Ultimo Número"
        Me.Numero.Name = "Numero"
        Me.Numero.ReadOnly = True
        '
        'Fecha
        '
        Me.Fecha.DataPropertyName = "Fecha"
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle6.Format = "dd/MM/yyyy"
        Me.Fecha.DefaultCellStyle = DataGridViewCellStyle6
        Me.Fecha.HeaderText = "Fecha"
        Me.Fecha.Name = "Fecha"
        Me.Fecha.Width = 90
        '
        'IdTipoComprobanteRelacionado
        '
        Me.IdTipoComprobanteRelacionado.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.IdTipoComprobanteRelacionado.DataPropertyName = "IdTipoComprobanteRelacionado"
        Me.IdTipoComprobanteRelacionado.HeaderText = "Tipos de Comprobantes Relacionados"
        Me.IdTipoComprobanteRelacionado.Name = "IdTipoComprobanteRelacionado"
        '
        'ComparteEntreSucursales
        '
        Me.ComparteEntreSucursales.DataPropertyName = "ComparteEntreSucursales"
        Me.ComparteEntreSucursales.HeaderText = "Comparte"
        Me.ComparteEntreSucursales.Name = "ComparteEntreSucursales"
        Me.ComparteEntreSucursales.ReadOnly = True
        Me.ComparteEntreSucursales.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.ComparteEntreSucursales.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.ComparteEntreSucursales.Width = 60
        '
        'EsRecibo
        '
        Me.EsRecibo.DataPropertyName = "EsRecibo"
        Me.EsRecibo.HeaderText = "Recibo"
        Me.EsRecibo.Name = "EsRecibo"
        Me.EsRecibo.Visible = False
        '
        'pnlGeneral
        '
        Me.pnlGeneral.Controls.Add(Me.dtgVentas)
        Me.pnlGeneral.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlGeneral.Location = New System.Drawing.Point(0, 31)
        Me.pnlGeneral.Name = "pnlGeneral"
        Me.pnlGeneral.Padding = New System.Windows.Forms.Padding(10)
        Me.pnlGeneral.Size = New System.Drawing.Size(884, 530)
        Me.pnlGeneral.TabIndex = 13
        '
        'ConsultaNumeracionVentas
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(884, 561)
        Me.Controls.Add(Me.pnlGeneral)
        Me.Controls.Add(Me.tspFichas)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.Name = "ConsultaNumeracionVentas"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Consulta de Numeración"
        Me.tspFichas.ResumeLayout(False)
        Me.tspFichas.PerformLayout()
        CType(Me.dtgVentas, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlGeneral.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents imgIconos As System.Windows.Forms.ImageList
   Friend WithEvents tspFichas As System.Windows.Forms.ToolStrip
   Friend WithEvents tsbSalir As System.Windows.Forms.ToolStripButton
   Friend WithEvents dtgVentas As Eniac.Controles.DataGridView
   Public WithEvents tsbRefrescar As System.Windows.Forms.ToolStripButton
   Private WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
   Friend WithEvents IdTipoComprobante As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents TipoComprobante As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents LetraFiscal As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents CentroEmisor As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents Numero As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents Fecha As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents IdTipoComprobanteRelacionado As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents ComparteEntreSucursales As System.Windows.Forms.DataGridViewCheckBoxColumn
   Friend WithEvents EsRecibo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents pnlGeneral As Panel
End Class
