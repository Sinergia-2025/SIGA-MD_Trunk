<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FacturablesInvocadosCom
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
      Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FacturablesInvocadosCom))
      Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
      Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
      Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
      Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
      Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
      Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
      Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
      Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
      Me.imgIconos = New System.Windows.Forms.ImageList(Me.components)
      Me.dgvDetalle = New Eniac.Controles.DataGridView()
      Me.gIdSucursal = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.gFecha = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.gTipoComprobante = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.gLetra = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.gCentroEmisor = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.gNumeroComprobante = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.gImporteNeto = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.stsStado = New System.Windows.Forms.StatusStrip()
      Me.tssInfo = New System.Windows.Forms.ToolStripStatusLabel()
      Me.tspBarra = New System.Windows.Forms.ToolStripProgressBar()
      Me.tssRegistros = New System.Windows.Forms.ToolStripStatusLabel()
      Me.txtTotalNeto = New Eniac.Controles.TextBox()
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
      Me.dgvDetalle.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.gIdSucursal, Me.gFecha, Me.gTipoComprobante, Me.gLetra, Me.gCentroEmisor, Me.gNumeroComprobante, Me.gImporteNeto})
      DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
      DataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Window
      DataGridViewCellStyle7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      DataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.ControlText
      DataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight
      DataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText
      DataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
      Me.dgvDetalle.DefaultCellStyle = DataGridViewCellStyle7
      Me.dgvDetalle.Location = New System.Drawing.Point(12, 32)
      Me.dgvDetalle.Name = "dgvDetalle"
      Me.dgvDetalle.ReadOnly = True
      DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
      DataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Control
      DataGridViewCellStyle8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      DataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.WindowText
      DataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight
      DataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText
      DataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
      Me.dgvDetalle.RowHeadersDefaultCellStyle = DataGridViewCellStyle8
      Me.dgvDetalle.RowHeadersVisible = False
      Me.dgvDetalle.RowHeadersWidth = 20
      Me.dgvDetalle.Size = New System.Drawing.Size(491, 309)
      Me.dgvDetalle.TabIndex = 1
      '
      'gIdSucursal
      '
      Me.gIdSucursal.DataPropertyName = "IdSucursal"
      Me.gIdSucursal.HeaderText = "IdSucursal"
      Me.gIdSucursal.Name = "gIdSucursal"
      Me.gIdSucursal.ReadOnly = True
      Me.gIdSucursal.Visible = False
      '
      'gFecha
      '
      Me.gFecha.DataPropertyName = "Fecha"
      DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
      DataGridViewCellStyle2.Format = "dd/MM/yyyy HH:mm"
      DataGridViewCellStyle2.NullValue = Nothing
      Me.gFecha.DefaultCellStyle = DataGridViewCellStyle2
      Me.gFecha.HeaderText = "Emision"
      Me.gFecha.Name = "gFecha"
      Me.gFecha.ReadOnly = True
      Me.gFecha.Width = 105
      '
      'gTipoComprobante
      '
      Me.gTipoComprobante.DataPropertyName = "TipoComprobante"
      Me.gTipoComprobante.HeaderText = "Comprobante"
      Me.gTipoComprobante.Name = "gTipoComprobante"
      Me.gTipoComprobante.ReadOnly = True
      '
      'gLetra
      '
      Me.gLetra.DataPropertyName = "Letra"
      DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
      Me.gLetra.DefaultCellStyle = DataGridViewCellStyle3
      Me.gLetra.HeaderText = "Letra"
      Me.gLetra.Name = "gLetra"
      Me.gLetra.ReadOnly = True
      Me.gLetra.Width = 40
      '
      'gCentroEmisor
      '
      Me.gCentroEmisor.DataPropertyName = "CentroEmisor"
      DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
      Me.gCentroEmisor.DefaultCellStyle = DataGridViewCellStyle4
      Me.gCentroEmisor.HeaderText = "Emisor"
      Me.gCentroEmisor.Name = "gCentroEmisor"
      Me.gCentroEmisor.ReadOnly = True
      Me.gCentroEmisor.Width = 50
      '
      'gNumeroComprobante
      '
      Me.gNumeroComprobante.DataPropertyName = "NumeroComprobante"
      DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
      Me.gNumeroComprobante.DefaultCellStyle = DataGridViewCellStyle5
      Me.gNumeroComprobante.HeaderText = "Numero"
      Me.gNumeroComprobante.Name = "gNumeroComprobante"
      Me.gNumeroComprobante.ReadOnly = True
      Me.gNumeroComprobante.Width = 80
      '
      'gImporteNeto
      '
      Me.gImporteNeto.DataPropertyName = "ImporteNeto"
      DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
      DataGridViewCellStyle6.Format = "N2"
      DataGridViewCellStyle6.NullValue = Nothing
      Me.gImporteNeto.DefaultCellStyle = DataGridViewCellStyle6
      Me.gImporteNeto.HeaderText = "Imp. Neto"
      Me.gImporteNeto.Name = "gImporteNeto"
      Me.gImporteNeto.ReadOnly = True
      Me.gImporteNeto.Width = 90
      '
      'stsStado
      '
      Me.stsStado.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tssInfo, Me.tspBarra, Me.tssRegistros})
      Me.stsStado.Location = New System.Drawing.Point(0, 370)
      Me.stsStado.Name = "stsStado"
      Me.stsStado.Size = New System.Drawing.Size(515, 22)
      Me.stsStado.TabIndex = 20
      Me.stsStado.Text = "statusStrip1"
      '
      'tssInfo
      '
      Me.tssInfo.Name = "tssInfo"
      Me.tssInfo.Size = New System.Drawing.Size(436, 17)
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
      'txtTotalNeto
      '
      Me.txtTotalNeto.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.txtTotalNeto.BindearPropiedadControl = Nothing
      Me.txtTotalNeto.BindearPropiedadEntidad = Nothing
      Me.txtTotalNeto.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.txtTotalNeto.ForeColorFocus = System.Drawing.Color.Red
      Me.txtTotalNeto.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtTotalNeto.Formato = ""
      Me.txtTotalNeto.IsDecimal = False
      Me.txtTotalNeto.IsNumber = False
      Me.txtTotalNeto.IsPK = False
      Me.txtTotalNeto.IsRequired = False
      Me.txtTotalNeto.Key = ""
      Me.txtTotalNeto.LabelAsoc = Nothing
      Me.txtTotalNeto.Location = New System.Drawing.Point(394, 341)
      Me.txtTotalNeto.Name = "txtTotalNeto"
      Me.txtTotalNeto.ReadOnly = True
      Me.txtTotalNeto.Size = New System.Drawing.Size(90, 20)
      Me.txtTotalNeto.TabIndex = 29
      Me.txtTotalNeto.Text = "0.00"
      Me.txtTotalNeto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'tstBarra
      '
      Me.tstBarra.AllowItemReorder = True
      Me.tstBarra.ImageScalingSize = New System.Drawing.Size(22, 22)
      Me.tstBarra.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsbSalir})
      Me.tstBarra.Location = New System.Drawing.Point(0, 0)
      Me.tstBarra.Name = "tstBarra"
      Me.tstBarra.Size = New System.Drawing.Size(515, 29)
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
      Me.lblTotal.Location = New System.Drawing.Point(254, 344)
      Me.lblTotal.Name = "lblTotal"
      Me.lblTotal.Size = New System.Drawing.Size(48, 13)
      Me.lblTotal.TabIndex = 28
      Me.lblTotal.Text = "Totales :"
      '
      'FacturablesInvocadosCom
      '
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.ClientSize = New System.Drawing.Size(515, 392)
      Me.Controls.Add(Me.tstBarra)
      Me.Controls.Add(Me.txtTotalNeto)
      Me.Controls.Add(Me.lblTotal)
      Me.Controls.Add(Me.stsStado)
      Me.Controls.Add(Me.dgvDetalle)
      Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
      Me.KeyPreview = True
      Me.MaximizeBox = False
      Me.MinimizeBox = False
      Me.Name = "FacturablesInvocadosCom"
      Me.ShowInTaskbar = False
      Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
      Me.Text = "Comprobantes Invocados"
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
   Friend WithEvents txtTotalNeto As Eniac.Controles.TextBox
   Friend WithEvents imgIconos As System.Windows.Forms.ImageList
   Public WithEvents tstBarra As System.Windows.Forms.ToolStrip
   Public WithEvents tsbSalir As System.Windows.Forms.ToolStripButton
   Friend WithEvents lblTotal As Eniac.Controles.Label
   Friend WithEvents gIdSucursal As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents gFecha As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents gTipoComprobante As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents gLetra As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents gCentroEmisor As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents gNumeroComprobante As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents gImporteNeto As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
