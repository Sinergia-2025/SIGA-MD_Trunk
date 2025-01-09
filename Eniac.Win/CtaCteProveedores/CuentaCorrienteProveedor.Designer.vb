<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CuentaCorrienteProveedor
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
      Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(CuentaCorrienteProveedor))
      Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
      Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
      Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
      Me.btnAceptar = New Eniac.Controles.Button()
      Me.imgGrabar = New System.Windows.Forms.ImageList(Me.components)
      Me.btnCancelar = New Eniac.Controles.Button()
      Me.grbFormaPago = New System.Windows.Forms.GroupBox()
      Me.lblRestan = New Eniac.Controles.Label()
      Me.txtRestan = New Eniac.Controles.TextBox()
      Me.dgvFormaDePago = New Eniac.Controles.DataGridView()
      Me.grpForma = New System.Windows.Forms.GroupBox()
      Me.lblDias = New Eniac.Controles.Label()
      Me.txtDias = New Eniac.Controles.TextBox()
      Me.btnEliminar = New Eniac.Controles.Button()
      Me.imgIconos = New System.Windows.Forms.ImageList(Me.components)
      Me.btnInsertar = New Eniac.Controles.Button()
      Me.dtpFechaAPagar = New Eniac.Controles.DateTimePicker()
      Me.lblFechaAPagar = New Eniac.Controles.Label()
      Me.lblMonto = New Eniac.Controles.Label()
      Me.txtMonto = New Eniac.Controles.TextBox()
      Me.lblSaldo = New Eniac.Controles.Label()
      Me.txtSaldo = New Eniac.Controles.TextBox()
      Me.MontoAPagar = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.Dias = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.FechaAPagar = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.grbFormaPago.SuspendLayout()
      CType(Me.dgvFormaDePago, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.grpForma.SuspendLayout()
      Me.SuspendLayout()
      '
      'btnAceptar
      '
      Me.btnAceptar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.btnAceptar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
      Me.btnAceptar.ImageKey = "check2.ico"
      Me.btnAceptar.ImageList = Me.imgGrabar
      Me.btnAceptar.Location = New System.Drawing.Point(238, 336)
      Me.btnAceptar.Name = "btnAceptar"
      Me.btnAceptar.Size = New System.Drawing.Size(85, 30)
      Me.btnAceptar.TabIndex = 1
      Me.btnAceptar.Text = "&Aceptar"
      Me.btnAceptar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      Me.btnAceptar.UseVisualStyleBackColor = True
      '
      'imgGrabar
      '
      Me.imgGrabar.ImageStream = CType(resources.GetObject("imgGrabar.ImageStream"), System.Windows.Forms.ImageListStreamer)
      Me.imgGrabar.TransparentColor = System.Drawing.Color.Transparent
      Me.imgGrabar.Images.SetKeyName(0, "check2.ico")
      Me.imgGrabar.Images.SetKeyName(1, "delete2.ico")
      '
      'btnCancelar
      '
      Me.btnCancelar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel
      Me.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
      Me.btnCancelar.ImageKey = "delete2.ico"
      Me.btnCancelar.ImageList = Me.imgGrabar
      Me.btnCancelar.Location = New System.Drawing.Point(329, 336)
      Me.btnCancelar.Name = "btnCancelar"
      Me.btnCancelar.Size = New System.Drawing.Size(85, 30)
      Me.btnCancelar.TabIndex = 2
      Me.btnCancelar.Text = "&Cancelar"
      Me.btnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      Me.btnCancelar.UseVisualStyleBackColor = True
      '
      'grbFormaPago
      '
      Me.grbFormaPago.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.grbFormaPago.Controls.Add(Me.lblRestan)
      Me.grbFormaPago.Controls.Add(Me.txtRestan)
      Me.grbFormaPago.Controls.Add(Me.dgvFormaDePago)
      Me.grbFormaPago.Controls.Add(Me.grpForma)
      Me.grbFormaPago.Controls.Add(Me.lblSaldo)
      Me.grbFormaPago.Controls.Add(Me.txtSaldo)
      Me.grbFormaPago.Location = New System.Drawing.Point(12, 12)
      Me.grbFormaPago.Name = "grbFormaPago"
      Me.grbFormaPago.Size = New System.Drawing.Size(402, 318)
      Me.grbFormaPago.TabIndex = 0
      Me.grbFormaPago.TabStop = False
      Me.grbFormaPago.Text = "Forma de pago"
      '
      'lblRestan
      '
      Me.lblRestan.AutoSize = True
      Me.lblRestan.Location = New System.Drawing.Point(214, 27)
      Me.lblRestan.Name = "lblRestan"
      Me.lblRestan.Size = New System.Drawing.Size(41, 13)
      Me.lblRestan.TabIndex = 2
      Me.lblRestan.Text = "Restan"
      '
      'txtRestan
      '
      Me.txtRestan.BindearPropiedadControl = Nothing
      Me.txtRestan.BindearPropiedadEntidad = Nothing
      Me.txtRestan.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.txtRestan.ForeColorFocus = System.Drawing.Color.Red
      Me.txtRestan.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtRestan.Formato = ""
      Me.txtRestan.IsDecimal = True
      Me.txtRestan.IsNumber = True
      Me.txtRestan.IsPK = False
      Me.txtRestan.IsRequired = False
      Me.txtRestan.Key = ""
      Me.txtRestan.LabelAsoc = Me.lblRestan
      Me.txtRestan.Location = New System.Drawing.Point(261, 22)
      Me.txtRestan.Name = "txtRestan"
      Me.txtRestan.ReadOnly = True
      Me.txtRestan.Size = New System.Drawing.Size(107, 23)
      Me.txtRestan.TabIndex = 3
      Me.txtRestan.TabStop = False
      Me.txtRestan.Text = "0.00"
      Me.txtRestan.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'dgvFormaDePago
      '
      Me.dgvFormaDePago.AllowUserToAddRows = False
      Me.dgvFormaDePago.AllowUserToDeleteRows = False
      Me.dgvFormaDePago.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.dgvFormaDePago.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
      Me.dgvFormaDePago.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.MontoAPagar, Me.Dias, Me.FechaAPagar})
      Me.dgvFormaDePago.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
      Me.dgvFormaDePago.Location = New System.Drawing.Point(56, 110)
      Me.dgvFormaDePago.Name = "dgvFormaDePago"
      Me.dgvFormaDePago.RowHeadersVisible = False
      Me.dgvFormaDePago.RowHeadersWidth = 20
      Me.dgvFormaDePago.Size = New System.Drawing.Size(295, 200)
      Me.dgvFormaDePago.TabIndex = 5
      '
      'grpForma
      '
      Me.grpForma.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.grpForma.Controls.Add(Me.lblDias)
      Me.grpForma.Controls.Add(Me.txtDias)
      Me.grpForma.Controls.Add(Me.btnEliminar)
      Me.grpForma.Controls.Add(Me.btnInsertar)
      Me.grpForma.Controls.Add(Me.dtpFechaAPagar)
      Me.grpForma.Controls.Add(Me.lblFechaAPagar)
      Me.grpForma.Controls.Add(Me.lblMonto)
      Me.grpForma.Controls.Add(Me.txtMonto)
      Me.grpForma.Location = New System.Drawing.Point(6, 49)
      Me.grpForma.Name = "grpForma"
      Me.grpForma.Size = New System.Drawing.Size(390, 55)
      Me.grpForma.TabIndex = 4
      Me.grpForma.TabStop = False
      '
      'lblDias
      '
      Me.lblDias.AutoSize = True
      Me.lblDias.Location = New System.Drawing.Point(89, 10)
      Me.lblDias.Name = "lblDias"
      Me.lblDias.Size = New System.Drawing.Size(30, 13)
      Me.lblDias.TabIndex = 7
      Me.lblDias.Text = "Días"
      '
      'txtDias
      '
      Me.txtDias.BindearPropiedadControl = Nothing
      Me.txtDias.BindearPropiedadEntidad = Nothing
      Me.txtDias.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.txtDias.ForeColorFocus = System.Drawing.Color.Red
      Me.txtDias.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtDias.Formato = ""
      Me.txtDias.IsDecimal = False
      Me.txtDias.IsNumber = True
      Me.txtDias.IsPK = False
      Me.txtDias.IsRequired = False
      Me.txtDias.Key = ""
      Me.txtDias.LabelAsoc = Me.lblDias
      Me.txtDias.Location = New System.Drawing.Point(85, 26)
      Me.txtDias.MaxLength = 3
      Me.txtDias.Name = "txtDias"
      Me.txtDias.Size = New System.Drawing.Size(37, 20)
      Me.txtDias.TabIndex = 1
      Me.txtDias.Text = "0"
      Me.txtDias.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'btnEliminar
      '
      Me.btnEliminar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.btnEliminar.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.btnEliminar.ImageIndex = 1
      Me.btnEliminar.ImageList = Me.imgIconos
      Me.btnEliminar.Location = New System.Drawing.Point(308, 16)
      Me.btnEliminar.Name = "btnEliminar"
      Me.btnEliminar.Size = New System.Drawing.Size(76, 33)
      Me.btnEliminar.TabIndex = 4
      Me.btnEliminar.Text = "&Eliminar"
      Me.btnEliminar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
      Me.btnEliminar.UseVisualStyleBackColor = True
      '
      'imgIconos
      '
      Me.imgIconos.ImageStream = CType(resources.GetObject("imgIconos.ImageStream"), System.Windows.Forms.ImageListStreamer)
      Me.imgIconos.TransparentColor = System.Drawing.Color.Transparent
      Me.imgIconos.Images.SetKeyName(0, "row_add.ico")
      Me.imgIconos.Images.SetKeyName(1, "row_delete.ico")
      Me.imgIconos.Images.SetKeyName(2, "disk_blue.ico")
      Me.imgIconos.Images.SetKeyName(3, "document_find.ico")
      '
      'btnInsertar
      '
      Me.btnInsertar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.btnInsertar.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.btnInsertar.ImageIndex = 0
      Me.btnInsertar.ImageList = Me.imgIconos
      Me.btnInsertar.Location = New System.Drawing.Point(229, 16)
      Me.btnInsertar.Name = "btnInsertar"
      Me.btnInsertar.Size = New System.Drawing.Size(76, 33)
      Me.btnInsertar.TabIndex = 3
      Me.btnInsertar.Text = "&Insertar"
      Me.btnInsertar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
      Me.btnInsertar.UseVisualStyleBackColor = True
      '
      'dtpFechaAPagar
      '
      Me.dtpFechaAPagar.BindearPropiedadControl = Nothing
      Me.dtpFechaAPagar.BindearPropiedadEntidad = Nothing
      Me.dtpFechaAPagar.CustomFormat = "dd/MM/yyyy"
      Me.dtpFechaAPagar.ForeColorFocus = System.Drawing.Color.Red
      Me.dtpFechaAPagar.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.dtpFechaAPagar.Format = System.Windows.Forms.DateTimePickerFormat.Custom
      Me.dtpFechaAPagar.IsPK = False
      Me.dtpFechaAPagar.IsRequired = False
      Me.dtpFechaAPagar.Key = ""
      Me.dtpFechaAPagar.LabelAsoc = Me.lblFechaAPagar
      Me.dtpFechaAPagar.Location = New System.Drawing.Point(128, 26)
      Me.dtpFechaAPagar.Name = "dtpFechaAPagar"
      Me.dtpFechaAPagar.Size = New System.Drawing.Size(96, 20)
      Me.dtpFechaAPagar.TabIndex = 2
      '
      'lblFechaAPagar
      '
      Me.lblFechaAPagar.AutoSize = True
      Me.lblFechaAPagar.Location = New System.Drawing.Point(125, 10)
      Me.lblFechaAPagar.Name = "lblFechaAPagar"
      Me.lblFechaAPagar.Size = New System.Drawing.Size(76, 13)
      Me.lblFechaAPagar.TabIndex = 5
      Me.lblFechaAPagar.Text = "Fecha a pagar"
      '
      'lblMonto
      '
      Me.lblMonto.AutoSize = True
      Me.lblMonto.Location = New System.Drawing.Point(5, 10)
      Me.lblMonto.Name = "lblMonto"
      Me.lblMonto.Size = New System.Drawing.Size(76, 13)
      Me.lblMonto.TabIndex = 4
      Me.lblMonto.Text = "Monto a pagar"
      '
      'txtMonto
      '
      Me.txtMonto.BindearPropiedadControl = Nothing
      Me.txtMonto.BindearPropiedadEntidad = Nothing
      Me.txtMonto.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.txtMonto.ForeColorFocus = System.Drawing.Color.Red
      Me.txtMonto.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtMonto.Formato = "#,##0.00"
      Me.txtMonto.IsDecimal = True
      Me.txtMonto.IsNumber = True
      Me.txtMonto.IsPK = False
      Me.txtMonto.IsRequired = False
      Me.txtMonto.Key = ""
      Me.txtMonto.LabelAsoc = Me.lblMonto
      Me.txtMonto.Location = New System.Drawing.Point(8, 26)
      Me.txtMonto.MaxLength = 20
      Me.txtMonto.Name = "txtMonto"
      Me.txtMonto.Size = New System.Drawing.Size(71, 20)
      Me.txtMonto.TabIndex = 0
      Me.txtMonto.Text = "0.00"
      Me.txtMonto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'lblSaldo
      '
      Me.lblSaldo.AutoSize = True
      Me.lblSaldo.Location = New System.Drawing.Point(15, 24)
      Me.lblSaldo.Name = "lblSaldo"
      Me.lblSaldo.Size = New System.Drawing.Size(73, 13)
      Me.lblSaldo.TabIndex = 0
      Me.lblSaldo.Text = "Saldo a pagar"
      '
      'txtSaldo
      '
      Me.txtSaldo.BindearPropiedadControl = Nothing
      Me.txtSaldo.BindearPropiedadEntidad = Nothing
      Me.txtSaldo.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.txtSaldo.ForeColorFocus = System.Drawing.Color.Red
      Me.txtSaldo.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtSaldo.Formato = ""
      Me.txtSaldo.IsDecimal = True
      Me.txtSaldo.IsNumber = True
      Me.txtSaldo.IsPK = False
      Me.txtSaldo.IsRequired = False
      Me.txtSaldo.Key = ""
      Me.txtSaldo.LabelAsoc = Me.lblSaldo
      Me.txtSaldo.Location = New System.Drawing.Point(94, 20)
      Me.txtSaldo.Name = "txtSaldo"
      Me.txtSaldo.ReadOnly = True
      Me.txtSaldo.Size = New System.Drawing.Size(107, 23)
      Me.txtSaldo.TabIndex = 1
      Me.txtSaldo.TabStop = False
      Me.txtSaldo.Text = "0.00"
      Me.txtSaldo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'MontoAPagar
      '
      Me.MontoAPagar.DataPropertyName = "MontoAPagar"
      DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
      DataGridViewCellStyle1.Format = "N2"
      DataGridViewCellStyle1.NullValue = Nothing
      Me.MontoAPagar.DefaultCellStyle = DataGridViewCellStyle1
      Me.MontoAPagar.HeaderText = "Monto a Pagar"
      Me.MontoAPagar.Name = "MontoAPagar"
      Me.MontoAPagar.Width = 120
      '
      'Dias
      '
      Me.Dias.DataPropertyName = "Dias"
      DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
      Me.Dias.DefaultCellStyle = DataGridViewCellStyle2
      Me.Dias.HeaderText = "Días"
      Me.Dias.Name = "Dias"
      Me.Dias.Width = 50
      '
      'FechaAPagar
      '
      Me.FechaAPagar.DataPropertyName = "FechaAPagar"
      DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
      DataGridViewCellStyle3.Format = "dd/MM/yyyy"
      DataGridViewCellStyle3.NullValue = Nothing
      Me.FechaAPagar.DefaultCellStyle = DataGridViewCellStyle3
      Me.FechaAPagar.HeaderText = "Fecha a Pagar"
      Me.FechaAPagar.Name = "FechaAPagar"
      '
      'CuentaCorrienteProveedor
      '
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.ClientSize = New System.Drawing.Size(426, 378)
      Me.ControlBox = False
      Me.Controls.Add(Me.grbFormaPago)
      Me.Controls.Add(Me.btnAceptar)
      Me.Controls.Add(Me.btnCancelar)
      Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
      Me.MaximizeBox = False
      Me.MinimizeBox = False
      Me.Name = "CuentaCorrienteProveedor"
      Me.ShowInTaskbar = False
      Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
      Me.Text = "Cuenta Corriente"
      Me.grbFormaPago.ResumeLayout(False)
      Me.grbFormaPago.PerformLayout()
      CType(Me.dgvFormaDePago, System.ComponentModel.ISupportInitialize).EndInit()
      Me.grpForma.ResumeLayout(False)
      Me.grpForma.PerformLayout()
      Me.ResumeLayout(False)

   End Sub
   Friend WithEvents btnAceptar As Eniac.Controles.Button
   Friend WithEvents imgGrabar As System.Windows.Forms.ImageList
   Friend WithEvents btnCancelar As Eniac.Controles.Button
   Friend WithEvents grbFormaPago As System.Windows.Forms.GroupBox
   Friend WithEvents lblSaldo As Eniac.Controles.Label
   Friend WithEvents txtSaldo As Eniac.Controles.TextBox
   Friend WithEvents grpForma As System.Windows.Forms.GroupBox
   Friend WithEvents dgvFormaDePago As Eniac.Controles.DataGridView
   Friend WithEvents dtpFechaAPagar As Eniac.Controles.DateTimePicker
   Friend WithEvents lblFechaAPagar As Eniac.Controles.Label
   Friend WithEvents lblMonto As Eniac.Controles.Label
   Friend WithEvents txtMonto As Eniac.Controles.TextBox
   Friend WithEvents lblRestan As Eniac.Controles.Label
   Friend WithEvents txtRestan As Eniac.Controles.TextBox
   Friend WithEvents btnEliminar As Eniac.Controles.Button
   Friend WithEvents imgIconos As System.Windows.Forms.ImageList
   Friend WithEvents btnInsertar As Eniac.Controles.Button
   Friend WithEvents lblDias As Eniac.Controles.Label
   Friend WithEvents txtDias As Eniac.Controles.TextBox
   Friend WithEvents MontoAPagar As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents Dias As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents FechaAPagar As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
