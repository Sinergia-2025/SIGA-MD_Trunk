<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ContabilidadPlanesCuentasDetalle
   Inherits Eniac.Win.BaseDetalle

   'Form reemplaza a Dispose para limpiar la lista de componentes.
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

   'Requerido por el Diseñador de Windows Forms
   Private components As System.ComponentModel.IContainer

   'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
   'Se puede modificar usando el Diseñador de Windows Forms.  
   'No lo modifique con el editor de código.
   <System.Diagnostics.DebuggerStepThrough()> _
   Private Sub InitializeComponent()
      Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
      Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
      Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
      Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
      Me.cmbCuenta = New Eniac.Controles.ComboBox()
      Me.lblcuenta = New Eniac.Controles.Label()
      Me.cmdAgregar = New System.Windows.Forms.Button()
      Me.fraPlanCta = New System.Windows.Forms.GroupBox()
      Me.cmdVer = New System.Windows.Forms.Button()
      Me.cmbQuitar = New System.Windows.Forms.Button()
      Me.grdPlanCuentas = New Eniac.Controles.DataGridView()
      Me.Ver = New System.Windows.Forms.DataGridViewButtonColumn()
      Me.idCuenta = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.nombreCuenta = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.lblEmpresa = New Eniac.Controles.Label()
      Me.cmbPlan = New Eniac.Controles.ComboBox()
      Me.Label1 = New Eniac.Controles.Label()
      Me.trvPlan = New System.Windows.Forms.TreeView()
      Me.Label2 = New System.Windows.Forms.Label()
      Me.chkTodas = New System.Windows.Forms.CheckBox()
      Me.fraPlanCta.SuspendLayout()
      CType(Me.grdPlanCuentas, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.SuspendLayout()
      '
      'btnAceptar
      '
      Me.btnAceptar.Location = New System.Drawing.Point(918, 434)
      Me.btnAceptar.TabIndex = 7
      '
      'btnCancelar
      '
      Me.btnCancelar.Location = New System.Drawing.Point(1004, 434)
      Me.btnCancelar.TabIndex = 8
      '
      'cmbCuenta
      '
      Me.cmbCuenta.BindearPropiedadControl = "SelectedValue"
      Me.cmbCuenta.BindearPropiedadEntidad = "idCuenta"
      Me.cmbCuenta.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cmbCuenta.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.cmbCuenta.ForeColorFocus = System.Drawing.Color.Red
      Me.cmbCuenta.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.cmbCuenta.FormattingEnabled = True
      Me.cmbCuenta.IsPK = False
      Me.cmbCuenta.IsRequired = False
      Me.cmbCuenta.Key = Nothing
      Me.cmbCuenta.LabelAsoc = Me.lblcuenta
      Me.cmbCuenta.Location = New System.Drawing.Point(89, 18)
      Me.cmbCuenta.Name = "cmbCuenta"
      Me.cmbCuenta.Size = New System.Drawing.Size(196, 21)
      Me.cmbCuenta.TabIndex = 1
      '
      'lblcuenta
      '
      Me.lblcuenta.AutoSize = True
      Me.lblcuenta.Location = New System.Drawing.Point(6, 21)
      Me.lblcuenta.Name = "lblcuenta"
      Me.lblcuenta.Size = New System.Drawing.Size(41, 13)
      Me.lblcuenta.TabIndex = 0
      Me.lblcuenta.Text = "Cuenta"
      '
      'cmdAgregar
      '
      Me.cmdAgregar.Location = New System.Drawing.Point(327, 11)
      Me.cmdAgregar.Name = "cmdAgregar"
      Me.cmdAgregar.Size = New System.Drawing.Size(75, 23)
      Me.cmdAgregar.TabIndex = 2
      Me.cmdAgregar.Text = "Agregar"
      Me.cmdAgregar.UseVisualStyleBackColor = True
      '
      'fraPlanCta
      '
      Me.fraPlanCta.Controls.Add(Me.cmdVer)
      Me.fraPlanCta.Controls.Add(Me.cmbQuitar)
      Me.fraPlanCta.Controls.Add(Me.grdPlanCuentas)
      Me.fraPlanCta.Controls.Add(Me.lblcuenta)
      Me.fraPlanCta.Controls.Add(Me.cmbCuenta)
      Me.fraPlanCta.Controls.Add(Me.cmdAgregar)
      Me.fraPlanCta.Location = New System.Drawing.Point(521, 73)
      Me.fraPlanCta.Name = "fraPlanCta"
      Me.fraPlanCta.Size = New System.Drawing.Size(560, 355)
      Me.fraPlanCta.TabIndex = 6
      Me.fraPlanCta.TabStop = False
      Me.fraPlanCta.Text = "Cuentas del Plan"
      '
      'cmdVer
      '
      Me.cmdVer.Location = New System.Drawing.Point(479, 317)
      Me.cmdVer.Name = "cmdVer"
      Me.cmdVer.Size = New System.Drawing.Size(75, 23)
      Me.cmdVer.TabIndex = 5
      Me.cmdVer.Text = "Ver Plan..."
      Me.cmdVer.UseVisualStyleBackColor = True
      '
      'cmbQuitar
      '
      Me.cmbQuitar.Location = New System.Drawing.Point(408, 11)
      Me.cmbQuitar.Name = "cmbQuitar"
      Me.cmbQuitar.Size = New System.Drawing.Size(75, 23)
      Me.cmbQuitar.TabIndex = 3
      Me.cmbQuitar.Text = "Quitar"
      Me.cmbQuitar.UseVisualStyleBackColor = True
      '
      'grdPlanCuentas
      '
      Me.grdPlanCuentas.AllowUserToAddRows = False
      Me.grdPlanCuentas.AllowUserToDeleteRows = False
      Me.grdPlanCuentas.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
      DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
      DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
      DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
      DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
      DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
      Me.grdPlanCuentas.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
      Me.grdPlanCuentas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
      Me.grdPlanCuentas.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Ver, Me.idCuenta, Me.nombreCuenta})
      DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
      DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window
      DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText
      DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
      DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
      DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
      Me.grdPlanCuentas.DefaultCellStyle = DataGridViewCellStyle3
      Me.grdPlanCuentas.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
      Me.grdPlanCuentas.Location = New System.Drawing.Point(6, 45)
      Me.grdPlanCuentas.MultiSelect = False
      Me.grdPlanCuentas.Name = "grdPlanCuentas"
      Me.grdPlanCuentas.ReadOnly = True
      DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
      DataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control
      DataGridViewCellStyle4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      DataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText
      DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight
      DataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText
      DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
      Me.grdPlanCuentas.RowHeadersDefaultCellStyle = DataGridViewCellStyle4
      Me.grdPlanCuentas.RowHeadersVisible = False
      Me.grdPlanCuentas.RowHeadersWidth = 4
      Me.grdPlanCuentas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
      Me.grdPlanCuentas.Size = New System.Drawing.Size(548, 266)
      Me.grdPlanCuentas.TabIndex = 4
      '
      'Ver
      '
      DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
      DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      DataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
      Me.Ver.DefaultCellStyle = DataGridViewCellStyle2
      Me.Ver.HeaderText = "Ver"
      Me.Ver.Name = "Ver"
      Me.Ver.ReadOnly = True
      Me.Ver.Text = "..."
      Me.Ver.Visible = False
      Me.Ver.Width = 30
      '
      'idCuenta
      '
      Me.idCuenta.DataPropertyName = "idCuenta"
      Me.idCuenta.HeaderText = "Código"
      Me.idCuenta.Name = "idCuenta"
      Me.idCuenta.ReadOnly = True
      '
      'nombreCuenta
      '
      Me.nombreCuenta.DataPropertyName = "nombreCuenta"
      Me.nombreCuenta.FillWeight = 200.0!
      Me.nombreCuenta.HeaderText = "Descripción"
      Me.nombreCuenta.Name = "nombreCuenta"
      Me.nombreCuenta.ReadOnly = True
      Me.nombreCuenta.Width = 430
      '
      'lblEmpresa
      '
      Me.lblEmpresa.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.lblEmpresa.Location = New System.Drawing.Point(12, 9)
      Me.lblEmpresa.Name = "lblEmpresa"
      Me.lblEmpresa.Size = New System.Drawing.Size(563, 22)
      Me.lblEmpresa.TabIndex = 0
      Me.lblEmpresa.Text = "Empresa"
      '
      'cmbPlan
      '
      Me.cmbPlan.BindearPropiedadControl = "SelectedValue"
      Me.cmbPlan.BindearPropiedadEntidad = "IdPlanCuenta"
      Me.cmbPlan.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cmbPlan.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.cmbPlan.ForeColorFocus = System.Drawing.Color.Red
      Me.cmbPlan.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.cmbPlan.FormattingEnabled = True
      Me.cmbPlan.IsPK = False
      Me.cmbPlan.IsRequired = True
      Me.cmbPlan.Key = Nothing
      Me.cmbPlan.LabelAsoc = Me.Label1
      Me.cmbPlan.Location = New System.Drawing.Point(610, 46)
      Me.cmbPlan.Name = "cmbPlan"
      Me.cmbPlan.Size = New System.Drawing.Size(196, 21)
      Me.cmbPlan.TabIndex = 5
      '
      'Label1
      '
      Me.Label1.AutoSize = True
      Me.Label1.Location = New System.Drawing.Point(518, 49)
      Me.Label1.Name = "Label1"
      Me.Label1.Size = New System.Drawing.Size(80, 13)
      Me.Label1.TabIndex = 4
      Me.Label1.Text = "Plan de Cuenta"
      '
      'trvPlan
      '
      Me.trvPlan.Location = New System.Drawing.Point(15, 74)
      Me.trvPlan.Name = "trvPlan"
      Me.trvPlan.Size = New System.Drawing.Size(445, 355)
      Me.trvPlan.TabIndex = 2
      '
      'Label2
      '
      Me.Label2.AutoSize = True
      Me.Label2.Location = New System.Drawing.Point(12, 54)
      Me.Label2.Name = "Label2"
      Me.Label2.Size = New System.Drawing.Size(103, 13)
      Me.Label2.TabIndex = 1
      Me.Label2.Text = "Cuentas del Sistema"
      '
      'chkTodas
      '
      Me.chkTodas.AutoSize = True
      Me.chkTodas.Location = New System.Drawing.Point(374, 50)
      Me.chkTodas.Name = "chkTodas"
      Me.chkTodas.Size = New System.Drawing.Size(86, 17)
      Me.chkTodas.TabIndex = 3
      Me.chkTodas.Text = "Pasar Todas"
      Me.chkTodas.UseVisualStyleBackColor = True
      '
      'ContabilidadPlanesCuentasDetalle
      '
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.ClientSize = New System.Drawing.Size(1093, 469)
      Me.Controls.Add(Me.chkTodas)
      Me.Controls.Add(Me.Label2)
      Me.Controls.Add(Me.trvPlan)
      Me.Controls.Add(Me.Label1)
      Me.Controls.Add(Me.cmbPlan)
      Me.Controls.Add(Me.lblEmpresa)
      Me.Controls.Add(Me.fraPlanCta)
      Me.Name = "ContabilidadPlanesCuentasDetalle"
      Me.Text = "Cuentas por Plan"
      Me.Controls.SetChildIndex(Me.fraPlanCta, 0)
      Me.Controls.SetChildIndex(Me.lblEmpresa, 0)
      Me.Controls.SetChildIndex(Me.btnCancelar, 0)
      Me.Controls.SetChildIndex(Me.btnAceptar, 0)
      Me.Controls.SetChildIndex(Me.cmbPlan, 0)
      Me.Controls.SetChildIndex(Me.Label1, 0)
      Me.Controls.SetChildIndex(Me.trvPlan, 0)
      Me.Controls.SetChildIndex(Me.Label2, 0)
      Me.Controls.SetChildIndex(Me.chkTodas, 0)
      Me.fraPlanCta.ResumeLayout(False)
      Me.fraPlanCta.PerformLayout()
      CType(Me.grdPlanCuentas, System.ComponentModel.ISupportInitialize).EndInit()
      Me.ResumeLayout(False)
      Me.PerformLayout()

   End Sub
   Friend WithEvents cmbCuenta As Eniac.Controles.ComboBox
   Friend WithEvents cmdAgregar As System.Windows.Forms.Button
   Friend WithEvents fraPlanCta As System.Windows.Forms.GroupBox
   Friend WithEvents cmbQuitar As System.Windows.Forms.Button
   Friend WithEvents grdPlanCuentas As Eniac.Controles.DataGridView
   Friend WithEvents lblEmpresa As Eniac.Controles.Label
   Friend WithEvents lblcuenta As Eniac.Controles.Label
   Friend WithEvents cmbPlan As Eniac.Controles.ComboBox
   Friend WithEvents Label1 As Eniac.Controles.Label
   Friend WithEvents trvPlan As System.Windows.Forms.TreeView
   Friend WithEvents Label2 As System.Windows.Forms.Label
   Friend WithEvents chkTodas As System.Windows.Forms.CheckBox
   Friend WithEvents cmdVer As System.Windows.Forms.Button
   Friend WithEvents Ver As System.Windows.Forms.DataGridViewButtonColumn
   Friend WithEvents idCuenta As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents nombreCuenta As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
