<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ConsultarLotes
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
   '<System.Diagnostics.DebuggerStepThrough()> _
   Private Sub InitializeComponent()
      Me.components = New System.ComponentModel.Container()
      Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ConsultarLotes))
      Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
      Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
      Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
      Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
      Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
      Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
      Me.imgIconos = New System.Windows.Forms.ImageList(Me.components)
      Me.dgvDetalle = New Eniac.Controles.DataGridView()
      Me.colIdProducto = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.colNombreProducto = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.colIdLote = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.colFechaVencimiento = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.colCantidad = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.stsStado = New System.Windows.Forms.StatusStrip()
      Me.tssInfo = New System.Windows.Forms.ToolStripStatusLabel()
      Me.tspBarra = New System.Windows.Forms.ToolStripProgressBar()
      Me.tssRegistros = New System.Windows.Forms.ToolStripStatusLabel()
      Me.txtTotalCantidad = New Eniac.Controles.TextBox()
      Me.tstBarra = New System.Windows.Forms.ToolStrip()
      Me.tsbSalir = New System.Windows.Forms.ToolStripButton()
      Me.lblTotal = New Eniac.Controles.Label()
      CType(Me.dgvDetalle, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.stsStado.SuspendLayout()
      Me.tstBarra.SuspendLayout()
      Me.SuspendLayout()
      '
      'imgIconos
      '
      Me.imgIconos.ImageStream = CType(resources.GetObject("imgIconos.ImageStream"), System.Windows.Forms.ImageListStreamer)
      Me.imgIconos.TransparentColor = System.Drawing.Color.Transparent
      Me.imgIconos.Images.SetKeyName(0, "find.ico")
      Me.imgIconos.Images.SetKeyName(1, "check2.ico")
      Me.imgIconos.Images.SetKeyName(2, "delete2.ico")
      '
      'dgvDetalle
      '
      Me.dgvDetalle.AllowUserToAddRows = False
      Me.dgvDetalle.AllowUserToDeleteRows = False
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
      Me.dgvDetalle.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colIdProducto, Me.colNombreProducto, Me.colIdLote, Me.colFechaVencimiento, Me.colCantidad})
      DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
      DataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window
      DataGridViewCellStyle5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      DataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText
      DataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight
      DataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText
      DataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
      Me.dgvDetalle.DefaultCellStyle = DataGridViewCellStyle5
      Me.dgvDetalle.Location = New System.Drawing.Point(12, 32)
      Me.dgvDetalle.Name = "dgvDetalle"
      Me.dgvDetalle.ReadOnly = True
      DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
      DataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control
      DataGridViewCellStyle6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      DataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText
      DataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight
      DataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText
      DataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
      Me.dgvDetalle.RowHeadersDefaultCellStyle = DataGridViewCellStyle6
      Me.dgvDetalle.RowHeadersVisible = False
      Me.dgvDetalle.RowHeadersWidth = 20
      Me.dgvDetalle.Size = New System.Drawing.Size(699, 319)
      Me.dgvDetalle.TabIndex = 1
      '
      'colIdProducto
      '
      Me.colIdProducto.DataPropertyName = "IdProducto"
      DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
      DataGridViewCellStyle2.Format = "N2"
      DataGridViewCellStyle2.NullValue = Nothing
      Me.colIdProducto.DefaultCellStyle = DataGridViewCellStyle2
      Me.colIdProducto.HeaderText = "Cod. Producto"
      Me.colIdProducto.Name = "colIdProducto"
      Me.colIdProducto.ReadOnly = True
      Me.colIdProducto.Width = 110
      '
      'colNombreProducto
      '
      Me.colNombreProducto.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
      Me.colNombreProducto.DataPropertyName = "NombreProducto"
      Me.colNombreProducto.HeaderText = "Producto"
      Me.colNombreProducto.Name = "colNombreProducto"
      Me.colNombreProducto.ReadOnly = True
      '
      'colIdLote
      '
      Me.colIdLote.DataPropertyName = "IdLote"
      Me.colIdLote.HeaderText = "Lote"
      Me.colIdLote.Name = "colIdLote"
      Me.colIdLote.ReadOnly = True
      Me.colIdLote.Width = 140
      '
      'colFechaVencimiento
      '
      Me.colFechaVencimiento.DataPropertyName = "FechaVencimiento"
      DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
      DataGridViewCellStyle3.Format = "dd/MM/yyyy"
      Me.colFechaVencimiento.DefaultCellStyle = DataGridViewCellStyle3
      Me.colFechaVencimiento.HeaderText = "Vencimiento"
      Me.colFechaVencimiento.Name = "colFechaVencimiento"
      Me.colFechaVencimiento.ReadOnly = True
      Me.colFechaVencimiento.Width = 80
      '
      'colCantidad
      '
      Me.colCantidad.DataPropertyName = "Cantidad"
      DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
      DataGridViewCellStyle4.Format = "N2"
      DataGridViewCellStyle4.NullValue = Nothing
      Me.colCantidad.DefaultCellStyle = DataGridViewCellStyle4
      Me.colCantidad.HeaderText = "Cantidad"
      Me.colCantidad.Name = "colCantidad"
      Me.colCantidad.ReadOnly = True
      Me.colCantidad.Width = 80
      '
      'stsStado
      '
      Me.stsStado.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tssInfo, Me.tspBarra, Me.tssRegistros})
      Me.stsStado.Location = New System.Drawing.Point(0, 380)
      Me.stsStado.Name = "stsStado"
      Me.stsStado.Size = New System.Drawing.Size(723, 22)
      Me.stsStado.TabIndex = 20
      Me.stsStado.Text = "statusStrip1"
      '
      'tssInfo
      '
      Me.tssInfo.Name = "tssInfo"
      Me.tssInfo.Size = New System.Drawing.Size(644, 17)
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
      'txtTotalCantidad
      '
      Me.txtTotalCantidad.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.txtTotalCantidad.BindearPropiedadControl = Nothing
      Me.txtTotalCantidad.BindearPropiedadEntidad = Nothing
      Me.txtTotalCantidad.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.txtTotalCantidad.ForeColorFocus = System.Drawing.Color.Red
      Me.txtTotalCantidad.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtTotalCantidad.Formato = ""
      Me.txtTotalCantidad.IsDecimal = False
      Me.txtTotalCantidad.IsNumber = False
      Me.txtTotalCantidad.IsPK = False
      Me.txtTotalCantidad.IsRequired = False
      Me.txtTotalCantidad.Key = ""
      Me.txtTotalCantidad.LabelAsoc = Nothing
      Me.txtTotalCantidad.Location = New System.Drawing.Point(631, 351)
      Me.txtTotalCantidad.Name = "txtTotalCantidad"
      Me.txtTotalCantidad.ReadOnly = True
      Me.txtTotalCantidad.Size = New System.Drawing.Size(80, 20)
      Me.txtTotalCantidad.TabIndex = 29
      Me.txtTotalCantidad.Text = "0.00"
      Me.txtTotalCantidad.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'tstBarra
      '
      Me.tstBarra.AllowItemReorder = True
      Me.tstBarra.ImageScalingSize = New System.Drawing.Size(22, 22)
      Me.tstBarra.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsbSalir})
      Me.tstBarra.Location = New System.Drawing.Point(0, 0)
      Me.tstBarra.Name = "tstBarra"
      Me.tstBarra.Size = New System.Drawing.Size(723, 29)
      Me.tstBarra.TabIndex = 30
      Me.tstBarra.Text = "toolStrip1"
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
      'lblTotal
      '
      Me.lblTotal.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.lblTotal.AutoSize = True
      Me.lblTotal.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.lblTotal.Location = New System.Drawing.Point(591, 354)
      Me.lblTotal.Name = "lblTotal"
      Me.lblTotal.Size = New System.Drawing.Size(37, 13)
      Me.lblTotal.TabIndex = 28
      Me.lblTotal.Text = "Total :"
      '
      'ConsultarLotes
      '
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.ClientSize = New System.Drawing.Size(723, 402)
      Me.Controls.Add(Me.tstBarra)
      Me.Controls.Add(Me.txtTotalCantidad)
      Me.Controls.Add(Me.lblTotal)
      Me.Controls.Add(Me.stsStado)
      Me.Controls.Add(Me.dgvDetalle)
      Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
      Me.KeyPreview = True
      Me.MaximizeBox = False
      Me.MinimizeBox = False
      Me.Name = "ConsultarLotes"
      Me.ShowInTaskbar = False
      Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
      Me.Text = "Consulta de Lotes"
      CType(Me.dgvDetalle, System.ComponentModel.ISupportInitialize).EndInit()
      Me.stsStado.ResumeLayout(False)
      Me.stsStado.PerformLayout()
      Me.tstBarra.ResumeLayout(False)
      Me.tstBarra.PerformLayout()
      Me.ResumeLayout(False)
      Me.PerformLayout()

   End Sub
   Friend WithEvents dgvDetalle As Eniac.Controles.DataGridView
   Protected Friend WithEvents stsStado As System.Windows.Forms.StatusStrip
   Protected Friend WithEvents tssInfo As System.Windows.Forms.ToolStripStatusLabel
   Protected Friend WithEvents tspBarra As System.Windows.Forms.ToolStripProgressBar
   Protected WithEvents tssRegistros As System.Windows.Forms.ToolStripStatusLabel
   Friend WithEvents txtTotalCantidad As Eniac.Controles.TextBox
   Friend WithEvents imgIconos As System.Windows.Forms.ImageList
   Public WithEvents tstBarra As System.Windows.Forms.ToolStrip
   Public WithEvents tsbSalir As System.Windows.Forms.ToolStripButton
   Friend WithEvents lblTotal As Eniac.Controles.Label
   Friend WithEvents colIdProducto As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents colNombreProducto As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents colIdLote As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents colFechaVencimiento As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents colCantidad As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
