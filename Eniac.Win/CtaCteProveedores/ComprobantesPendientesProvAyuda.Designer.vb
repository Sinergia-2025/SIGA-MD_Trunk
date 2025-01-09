<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ComprobantesPendientesProvAyuda
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
      Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
      Dim DataGridViewCellStyle13 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
      Dim DataGridViewCellStyle14 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
      Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
      Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
      Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
      Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
      Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
      Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
      Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
      Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
      Dim DataGridViewCellStyle10 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
      Dim DataGridViewCellStyle11 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
      Dim DataGridViewCellStyle12 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
      Me.btnCancelar = New Eniac.Controles.Button()
      Me.btnAceptar = New Eniac.Controles.Button()
      Me.stsStado = New System.Windows.Forms.StatusStrip()
      Me.tssInfo = New System.Windows.Forms.ToolStripStatusLabel()
      Me.tspBarra = New System.Windows.Forms.ToolStripProgressBar()
      Me.tssRegistros = New System.Windows.Forms.ToolStripStatusLabel()
      Me.txtTotal = New Eniac.Controles.TextBox()
      Me.lblTotal = New Eniac.Controles.Label()
      Me.chbTodos = New Eniac.Controles.CheckBox()
      Me.dgvDetalle = New Eniac.Controles.DataGridView()
      Me.Check = New System.Windows.Forms.DataGridViewCheckBoxColumn()
      Me.gcoIdTipoComprobante = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.gcoLetra = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.gcoCentroEmisor = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.gcoNumeroComprobante = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.gcoCuota = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.gcoFechaEmision = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.gcoFechaVencimiento = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.FormaDePago = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.FomaPagoDesc = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.gcoImporteCuota = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.MercEnviada = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.gcoSaldoCuota = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.gcoPaga = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.gcoDescuentoRecargoPorc = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.gcoDescuentoRecargo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.gcoPassword = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.gcoUsuario = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.gcoIdSucursal = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.gcoTipoComprobante = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.gcoCuentaCorriente = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.stsStado.SuspendLayout()
        CType(Me.dgvDetalle, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnCancelar
        '
        Me.btnCancelar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancelar.Image = Global.Eniac.Win.My.Resources.Resources.close_b_24
        Me.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCancelar.Location = New System.Drawing.Point(736, 463)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(85, 30)
        Me.btnCancelar.TabIndex = 6
        Me.btnCancelar.Text = "&Cancelar"
        Me.btnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnCancelar.UseVisualStyleBackColor = True
        '
        'btnAceptar
        '
        Me.btnAceptar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnAceptar.Image = Global.Eniac.Win.My.Resources.Resources.ok_24
        Me.btnAceptar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnAceptar.Location = New System.Drawing.Point(645, 463)
        Me.btnAceptar.Name = "btnAceptar"
        Me.btnAceptar.Size = New System.Drawing.Size(85, 30)
        Me.btnAceptar.TabIndex = 5
        Me.btnAceptar.Text = "&Aceptar"
        Me.btnAceptar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnAceptar.UseVisualStyleBackColor = True
        '
        'stsStado
        '
        Me.stsStado.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tssInfo, Me.tspBarra, Me.tssRegistros})
        Me.stsStado.Location = New System.Drawing.Point(0, 506)
        Me.stsStado.Name = "stsStado"
        Me.stsStado.Size = New System.Drawing.Size(832, 22)
        Me.stsStado.TabIndex = 7
        Me.stsStado.Text = "statusStrip1"
        '
        'tssInfo
        '
        Me.tssInfo.Name = "tssInfo"
        Me.tssInfo.Size = New System.Drawing.Size(753, 17)
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
        'txtTotal
        '
        Me.txtTotal.BindearPropiedadControl = Nothing
        Me.txtTotal.BindearPropiedadEntidad = Nothing
        Me.txtTotal.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotal.ForeColorFocus = System.Drawing.Color.Red
        Me.txtTotal.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtTotal.Formato = ""
        Me.txtTotal.IsDecimal = False
        Me.txtTotal.IsNumber = False
        Me.txtTotal.IsPK = False
        Me.txtTotal.IsRequired = False
        Me.txtTotal.Key = ""
        Me.txtTotal.LabelAsoc = Nothing
        Me.txtTotal.Location = New System.Drawing.Point(630, 437)
        Me.txtTotal.Name = "txtTotal"
        Me.txtTotal.ReadOnly = True
        Me.txtTotal.Size = New System.Drawing.Size(90, 20)
        Me.txtTotal.TabIndex = 4
        Me.txtTotal.Text = "0.00"
        Me.txtTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblTotal
        '
        Me.lblTotal.AutoSize = True
        Me.lblTotal.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotal.LabelAsoc = Nothing
        Me.lblTotal.Location = New System.Drawing.Point(582, 440)
        Me.lblTotal.Name = "lblTotal"
        Me.lblTotal.Size = New System.Drawing.Size(44, 13)
        Me.lblTotal.TabIndex = 3
        Me.lblTotal.Text = "Total :"
        '
        'chbTodos
        '
        Me.chbTodos.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.chbTodos.BindearPropiedadControl = Nothing
        Me.chbTodos.BindearPropiedadEntidad = Nothing
        Me.chbTodos.ForeColorFocus = System.Drawing.Color.Red
        Me.chbTodos.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbTodos.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.chbTodos.ImageIndex = 1
        Me.chbTodos.IsPK = False
        Me.chbTodos.IsRequired = False
        Me.chbTodos.Key = Nothing
        Me.chbTodos.LabelAsoc = Nothing
        Me.chbTodos.Location = New System.Drawing.Point(12, 439)
        Me.chbTodos.Name = "chbTodos"
        Me.chbTodos.Size = New System.Drawing.Size(126, 24)
        Me.chbTodos.TabIndex = 2
        Me.chbTodos.Text = "Chequear Todos"
        Me.chbTodos.UseVisualStyleBackColor = True
        '
        'dgvDetalle
        '
        Me.dgvDetalle.AllowUserToAddRows = False
        Me.dgvDetalle.AllowUserToDeleteRows = False
        Me.dgvDetalle.AllowUserToResizeRows = False
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvDetalle.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvDetalle.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvDetalle.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Check, Me.gcoIdTipoComprobante, Me.gcoLetra, Me.gcoCentroEmisor, Me.gcoNumeroComprobante, Me.gcoCuota, Me.gcoFechaEmision, Me.gcoFechaVencimiento, Me.FormaDePago, Me.FomaPagoDesc, Me.gcoImporteCuota, Me.MercEnviada, Me.gcoSaldoCuota, Me.gcoPaga, Me.gcoDescuentoRecargoPorc, Me.gcoDescuentoRecargo, Me.gcoPassword, Me.gcoUsuario, Me.gcoIdSucursal, Me.gcoTipoComprobante, Me.gcoCuentaCorriente})
        DataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle13.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle13.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle13.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle13.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle13.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle13.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvDetalle.DefaultCellStyle = DataGridViewCellStyle13
        Me.dgvDetalle.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnKeystroke
        Me.dgvDetalle.Location = New System.Drawing.Point(12, 24)
        Me.dgvDetalle.MultiSelect = False
        Me.dgvDetalle.Name = "dgvDetalle"
        DataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle14.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle14.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle14.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle14.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle14.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle14.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvDetalle.RowHeadersDefaultCellStyle = DataGridViewCellStyle14
        Me.dgvDetalle.RowHeadersVisible = False
        Me.dgvDetalle.RowHeadersWidth = 20
        Me.dgvDetalle.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvDetalle.Size = New System.Drawing.Size(813, 403)
        Me.dgvDetalle.TabIndex = 27
        '
        'Check
        '
        Me.Check.DataPropertyName = "Check"
        Me.Check.HeaderText = "Sel."
        Me.Check.Name = "Check"
        Me.Check.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Check.Width = 30
        '
        'gcoIdTipoComprobante
        '
        Me.gcoIdTipoComprobante.DataPropertyName = "IdTipoComprobante"
        Me.gcoIdTipoComprobante.HeaderText = "Tipo"
        Me.gcoIdTipoComprobante.Name = "gcoIdTipoComprobante"
        Me.gcoIdTipoComprobante.ReadOnly = True
        Me.gcoIdTipoComprobante.Width = 200
        '
        'gcoLetra
        '
        Me.gcoLetra.DataPropertyName = "Letra"
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.gcoLetra.DefaultCellStyle = DataGridViewCellStyle2
        Me.gcoLetra.HeaderText = "Let."
        Me.gcoLetra.Name = "gcoLetra"
        Me.gcoLetra.ReadOnly = True
        Me.gcoLetra.Width = 30
        '
        'gcoCentroEmisor
        '
        Me.gcoCentroEmisor.DataPropertyName = "CentroEmisor"
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.gcoCentroEmisor.DefaultCellStyle = DataGridViewCellStyle3
        Me.gcoCentroEmisor.HeaderText = "Emis."
        Me.gcoCentroEmisor.Name = "gcoCentroEmisor"
        Me.gcoCentroEmisor.Width = 40
        '
        'gcoNumeroComprobante
        '
        Me.gcoNumeroComprobante.DataPropertyName = "NumeroComprobante"
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.gcoNumeroComprobante.DefaultCellStyle = DataGridViewCellStyle4
        Me.gcoNumeroComprobante.HeaderText = "Numero"
        Me.gcoNumeroComprobante.Name = "gcoNumeroComprobante"
        Me.gcoNumeroComprobante.Width = 70
        '
        'gcoCuota
        '
        Me.gcoCuota.DataPropertyName = "Cuota"
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.gcoCuota.DefaultCellStyle = DataGridViewCellStyle5
        Me.gcoCuota.HeaderText = "Cta."
        Me.gcoCuota.Name = "gcoCuota"
        Me.gcoCuota.Width = 30
        '
        'gcoFechaEmision
        '
        Me.gcoFechaEmision.DataPropertyName = "Fecha"
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle6.Format = "dd/MM/yyyy"
        Me.gcoFechaEmision.DefaultCellStyle = DataGridViewCellStyle6
        Me.gcoFechaEmision.HeaderText = "Emision"
        Me.gcoFechaEmision.Name = "gcoFechaEmision"
        Me.gcoFechaEmision.Width = 75
        '
        'gcoFechaVencimiento
        '
        Me.gcoFechaVencimiento.DataPropertyName = "FechaVencimiento"
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle7.Format = "dd/MM/yyyy"
        DataGridViewCellStyle7.NullValue = Nothing
        Me.gcoFechaVencimiento.DefaultCellStyle = DataGridViewCellStyle7
        Me.gcoFechaVencimiento.HeaderText = "Vencimiento"
        Me.gcoFechaVencimiento.Name = "gcoFechaVencimiento"
        Me.gcoFechaVencimiento.Width = 75
        '
        'FormaDePago
        '
        Me.FormaDePago.DataPropertyName = "FormaPago"
        Me.FormaDePago.HeaderText = "Forma Pago"
        Me.FormaDePago.Name = "FormaDePago"
        Me.FormaDePago.Visible = False
        Me.FormaDePago.Width = 90
        '
        'FomaPagoDesc
        '
        Me.FomaPagoDesc.DataPropertyName = "FormasPagoDescripcion"
        Me.FomaPagoDesc.HeaderText = "Forma de Pago"
        Me.FomaPagoDesc.Name = "FomaPagoDesc"
        Me.FomaPagoDesc.Visible = False
        Me.FomaPagoDesc.Width = 120
        '
        'gcoImporteCuota
        '
        Me.gcoImporteCuota.DataPropertyName = "ImporteCuota"
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle8.Format = "N2"
        DataGridViewCellStyle8.NullValue = Nothing
        Me.gcoImporteCuota.DefaultCellStyle = DataGridViewCellStyle8
        Me.gcoImporteCuota.HeaderText = "Importe"
        Me.gcoImporteCuota.Name = "gcoImporteCuota"
        Me.gcoImporteCuota.Width = 75
        '
        'MercEnviada
        '
        Me.MercEnviada.DataPropertyName = "MercEnviada"
        Me.MercEnviada.HeaderText = "Mercadería Enviada"
        Me.MercEnviada.Name = "MercEnviada"
        Me.MercEnviada.ReadOnly = True
        '
        'gcoSaldoCuota
        '
        Me.gcoSaldoCuota.DataPropertyName = "SaldoCuota"
        DataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle9.Format = "N2"
        DataGridViewCellStyle9.NullValue = Nothing
        Me.gcoSaldoCuota.DefaultCellStyle = DataGridViewCellStyle9
        Me.gcoSaldoCuota.HeaderText = "Saldo"
        Me.gcoSaldoCuota.Name = "gcoSaldoCuota"
        Me.gcoSaldoCuota.Width = 75
        '
        'gcoPaga
        '
        Me.gcoPaga.DataPropertyName = "Paga"
        DataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle10.Format = "N2"
        DataGridViewCellStyle10.NullValue = Nothing
        Me.gcoPaga.DefaultCellStyle = DataGridViewCellStyle10
        Me.gcoPaga.HeaderText = "Paga"
        Me.gcoPaga.Name = "gcoPaga"
        Me.gcoPaga.Visible = False
        Me.gcoPaga.Width = 75
        '
        'gcoDescuentoRecargoPorc
        '
        Me.gcoDescuentoRecargoPorc.DataPropertyName = "DescuentoRecargoPorc"
        DataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle11.Format = "N2"
        Me.gcoDescuentoRecargoPorc.DefaultCellStyle = DataGridViewCellStyle11
        Me.gcoDescuentoRecargoPorc.HeaderText = "% D/R"
        Me.gcoDescuentoRecargoPorc.Name = "gcoDescuentoRecargoPorc"
        Me.gcoDescuentoRecargoPorc.Visible = False
        Me.gcoDescuentoRecargoPorc.Width = 65
        '
        'gcoDescuentoRecargo
        '
        Me.gcoDescuentoRecargo.DataPropertyName = "DescuentoRecargo"
        DataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle12.Format = "N2"
        Me.gcoDescuentoRecargo.DefaultCellStyle = DataGridViewCellStyle12
        Me.gcoDescuentoRecargo.HeaderText = "$ D/R"
        Me.gcoDescuentoRecargo.Name = "gcoDescuentoRecargo"
        Me.gcoDescuentoRecargo.Visible = False
        Me.gcoDescuentoRecargo.Width = 70
        '
        'gcoPassword
        '
        Me.gcoPassword.DataPropertyName = "Password"
        Me.gcoPassword.HeaderText = "Password"
        Me.gcoPassword.Name = "gcoPassword"
        Me.gcoPassword.Visible = False
        '
        'gcoUsuario
        '
        Me.gcoUsuario.DataPropertyName = "Usuario"
        Me.gcoUsuario.HeaderText = "Usuario"
        Me.gcoUsuario.Name = "gcoUsuario"
        Me.gcoUsuario.Visible = False
        '
        'gcoIdSucursal
        '
        Me.gcoIdSucursal.DataPropertyName = "IdSucursal"
        Me.gcoIdSucursal.HeaderText = "IdSucursal"
        Me.gcoIdSucursal.Name = "gcoIdSucursal"
        Me.gcoIdSucursal.Visible = False
        '
        'gcoTipoComprobante
        '
        Me.gcoTipoComprobante.DataPropertyName = "TipoComprobante"
        Me.gcoTipoComprobante.HeaderText = "TipoComprobante"
        Me.gcoTipoComprobante.Name = "gcoTipoComprobante"
        Me.gcoTipoComprobante.Visible = False
        '
        'gcoCuentaCorriente
        '
        Me.gcoCuentaCorriente.DataPropertyName = "CuentaCorrienteProv"
        Me.gcoCuentaCorriente.HeaderText = "CuentaCorriente"
        Me.gcoCuentaCorriente.Name = "gcoCuentaCorriente"
        Me.gcoCuentaCorriente.Visible = False
        '
        'ComprobantesPendientesProvAyuda
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(832, 528)
        Me.Controls.Add(Me.dgvDetalle)
        Me.Controls.Add(Me.chbTodos)
        Me.Controls.Add(Me.txtTotal)
        Me.Controls.Add(Me.lblTotal)
        Me.Controls.Add(Me.stsStado)
        Me.Controls.Add(Me.btnCancelar)
        Me.Controls.Add(Me.btnAceptar)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "ComprobantesPendientesProvAyuda"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Ayuda de Comprobantes a Seleccionar"
        Me.stsStado.ResumeLayout(False)
        Me.stsStado.PerformLayout()
        CType(Me.dgvDetalle, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnCancelar As Eniac.Controles.Button
    Friend WithEvents btnAceptar As Eniac.Controles.Button
    Protected Friend WithEvents stsStado As System.Windows.Forms.StatusStrip
    Protected Friend WithEvents tssInfo As System.Windows.Forms.ToolStripStatusLabel
    Protected Friend WithEvents tspBarra As System.Windows.Forms.ToolStripProgressBar
    Protected WithEvents tssRegistros As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents txtTotal As Eniac.Controles.TextBox
    Friend WithEvents lblTotal As Eniac.Controles.Label
    Friend WithEvents chbTodos As Eniac.Controles.CheckBox
    Friend WithEvents dgvDetalle As Eniac.Controles.DataGridView
    Friend WithEvents Check As DataGridViewCheckBoxColumn
    Friend WithEvents gcoIdTipoComprobante As DataGridViewTextBoxColumn
    Friend WithEvents gcoLetra As DataGridViewTextBoxColumn
    Friend WithEvents gcoCentroEmisor As DataGridViewTextBoxColumn
    Friend WithEvents gcoNumeroComprobante As DataGridViewTextBoxColumn
    Friend WithEvents gcoCuota As DataGridViewTextBoxColumn
    Friend WithEvents gcoFechaEmision As DataGridViewTextBoxColumn
    Friend WithEvents gcoFechaVencimiento As DataGridViewTextBoxColumn
    Friend WithEvents FormaDePago As DataGridViewTextBoxColumn
    Friend WithEvents FomaPagoDesc As DataGridViewTextBoxColumn
    Friend WithEvents gcoImporteCuota As DataGridViewTextBoxColumn
    Friend WithEvents MercEnviada As DataGridViewCheckBoxColumn
    Friend WithEvents gcoSaldoCuota As DataGridViewTextBoxColumn
    Friend WithEvents gcoPaga As DataGridViewTextBoxColumn
    Friend WithEvents gcoDescuentoRecargoPorc As DataGridViewTextBoxColumn
    Friend WithEvents gcoDescuentoRecargo As DataGridViewTextBoxColumn
    Friend WithEvents gcoPassword As DataGridViewTextBoxColumn
    Friend WithEvents gcoUsuario As DataGridViewTextBoxColumn
    Friend WithEvents gcoIdSucursal As DataGridViewTextBoxColumn
    Friend WithEvents gcoTipoComprobante As DataGridViewTextBoxColumn
    Friend WithEvents gcoCuentaCorriente As DataGridViewTextBoxColumn
End Class
