<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ContabilidadEjerciciosDetalle
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
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.lblCodigo = New Eniac.Controles.Label()
        Me.txtcodigoEjercicio = New Eniac.Controles.TextBox()
        Me.lblHasta = New Eniac.Controles.Label()
        Me.lbldesde = New Eniac.Controles.Label()
        Me.chkCerrado = New Eniac.Controles.CheckBox()
        Me.dtpDesde = New Eniac.Controles.DateTimePicker()
        Me.dtpHasta = New Eniac.Controles.DateTimePicker()
        Me.grdPeriodos = New Eniac.Controles.DataGridView()
        Me.Ver = New System.Windows.Forms.DataGridViewButtonColumn()
        Me.IdEjercicio = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.IdPeriodo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cerrado = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.CoeficienteAjustePorInflacion = New System.Windows.Forms.DataGridViewTextBoxColumn()
        CType(Me.grdPeriodos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnAceptar
        '
        Me.btnAceptar.Location = New System.Drawing.Point(139, 415)
        Me.btnAceptar.TabIndex = 8
        '
        'btnCancelar
        '
        Me.btnCancelar.Location = New System.Drawing.Point(225, 415)
        Me.btnCancelar.TabIndex = 9
        '
        'btnCopiar
        '
        Me.btnCopiar.Location = New System.Drawing.Point(39, 415)
        '
        'btnAplicar
        '
        Me.btnAplicar.Location = New System.Drawing.Point(13, 415)
        '
        'lblCodigo
        '
        Me.lblCodigo.AutoSize = True
        Me.lblCodigo.LabelAsoc = Nothing
        Me.lblCodigo.Location = New System.Drawing.Point(12, 23)
        Me.lblCodigo.Name = "lblCodigo"
        Me.lblCodigo.Size = New System.Drawing.Size(40, 13)
        Me.lblCodigo.TabIndex = 1
        Me.lblCodigo.Text = "Código"
        '
        'txtcodigoEjercicio
        '
        Me.txtcodigoEjercicio.BindearPropiedadControl = "Text"
        Me.txtcodigoEjercicio.BindearPropiedadEntidad = "IdEjercicio"
        Me.txtcodigoEjercicio.Enabled = False
        Me.txtcodigoEjercicio.ForeColorFocus = System.Drawing.Color.Red
        Me.txtcodigoEjercicio.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtcodigoEjercicio.Formato = ""
        Me.txtcodigoEjercicio.IsDecimal = False
        Me.txtcodigoEjercicio.IsNumber = False
        Me.txtcodigoEjercicio.IsPK = True
        Me.txtcodigoEjercicio.IsRequired = True
        Me.txtcodigoEjercicio.Key = ""
        Me.txtcodigoEjercicio.LabelAsoc = Me.lblCodigo
        Me.txtcodigoEjercicio.Location = New System.Drawing.Point(87, 14)
        Me.txtcodigoEjercicio.MaxLength = 4
        Me.txtcodigoEjercicio.Name = "txtcodigoEjercicio"
        Me.txtcodigoEjercicio.Size = New System.Drawing.Size(49, 20)
        Me.txtcodigoEjercicio.TabIndex = 0
        '
        'lblHasta
        '
        Me.lblHasta.AutoSize = True
        Me.lblHasta.LabelAsoc = Nothing
        Me.lblHasta.Location = New System.Drawing.Point(177, 44)
        Me.lblHasta.Name = "lblHasta"
        Me.lblHasta.Size = New System.Drawing.Size(35, 13)
        Me.lblHasta.TabIndex = 5
        Me.lblHasta.Text = "Hasta"
        '
        'lbldesde
        '
        Me.lbldesde.AutoSize = True
        Me.lbldesde.LabelAsoc = Nothing
        Me.lbldesde.Location = New System.Drawing.Point(10, 44)
        Me.lbldesde.Name = "lbldesde"
        Me.lbldesde.Size = New System.Drawing.Size(71, 13)
        Me.lbldesde.TabIndex = 3
        Me.lbldesde.Text = "Fecha Desde"
        '
        'chkCerrado
        '
        Me.chkCerrado.BindearPropiedadControl = "Checked"
        Me.chkCerrado.BindearPropiedadEntidad = "Cerrado"
        Me.chkCerrado.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.chkCerrado.ForeColorFocus = System.Drawing.Color.Red
        Me.chkCerrado.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chkCerrado.IsPK = False
        Me.chkCerrado.IsRequired = False
        Me.chkCerrado.Key = Nothing
        Me.chkCerrado.LabelAsoc = Nothing
        Me.chkCerrado.Location = New System.Drawing.Point(95, 69)
        Me.chkCerrado.Name = "chkCerrado"
        Me.chkCerrado.Size = New System.Drawing.Size(151, 17)
        Me.chkCerrado.TabIndex = 6
        Me.chkCerrado.Text = "Cerrar Ejercicio Completo"
        Me.chkCerrado.TextAlign = System.Drawing.ContentAlignment.BottomLeft
        Me.chkCerrado.UseVisualStyleBackColor = True
        '
        'dtpDesde
        '
        Me.dtpDesde.BindearPropiedadControl = ""
        Me.dtpDesde.BindearPropiedadEntidad = ""
        Me.dtpDesde.CustomFormat = "MM/yyyy"
        Me.dtpDesde.Enabled = False
        Me.dtpDesde.ForeColorFocus = System.Drawing.Color.Red
        Me.dtpDesde.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.dtpDesde.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpDesde.IsPK = False
        Me.dtpDesde.IsRequired = True
        Me.dtpDesde.Key = ""
        Me.dtpDesde.LabelAsoc = Me.lbldesde
        Me.dtpDesde.Location = New System.Drawing.Point(87, 40)
        Me.dtpDesde.Name = "dtpDesde"
        Me.dtpDesde.Size = New System.Drawing.Size(80, 20)
        Me.dtpDesde.TabIndex = 2
        Me.dtpDesde.Value = New Date(2011, 10, 6, 0, 0, 0, 0)
        '
        'dtpHasta
        '
        Me.dtpHasta.BindearPropiedadControl = ""
        Me.dtpHasta.BindearPropiedadEntidad = ""
        Me.dtpHasta.CustomFormat = "MM/yyyy"
        Me.dtpHasta.Enabled = False
        Me.dtpHasta.ForeColorFocus = System.Drawing.Color.Red
        Me.dtpHasta.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.dtpHasta.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpHasta.IsPK = False
        Me.dtpHasta.IsRequired = True
        Me.dtpHasta.Key = ""
        Me.dtpHasta.LabelAsoc = Me.lblHasta
        Me.dtpHasta.Location = New System.Drawing.Point(218, 40)
        Me.dtpHasta.Name = "dtpHasta"
        Me.dtpHasta.Size = New System.Drawing.Size(80, 20)
        Me.dtpHasta.TabIndex = 4
        Me.dtpHasta.Value = New Date(2011, 10, 6, 0, 0, 0, 0)
        '
        'grdPeriodos
        '
        Me.grdPeriodos.AllowUserToAddRows = False
        Me.grdPeriodos.AllowUserToDeleteRows = False
        Me.grdPeriodos.AllowUserToResizeColumns = False
        Me.grdPeriodos.AllowUserToResizeRows = False
        Me.grdPeriodos.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.grdPeriodos.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.grdPeriodos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grdPeriodos.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Ver, Me.IdEjercicio, Me.IdPeriodo, Me.cerrado, Me.CoeficienteAjustePorInflacion})
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.grdPeriodos.DefaultCellStyle = DataGridViewCellStyle6
        Me.grdPeriodos.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.grdPeriodos.Location = New System.Drawing.Point(15, 92)
        Me.grdPeriodos.MultiSelect = False
        Me.grdPeriodos.Name = "grdPeriodos"
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.grdPeriodos.RowHeadersDefaultCellStyle = DataGridViewCellStyle7
        Me.grdPeriodos.RowHeadersVisible = False
        Me.grdPeriodos.RowHeadersWidth = 4
        Me.grdPeriodos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.grdPeriodos.Size = New System.Drawing.Size(283, 317)
        Me.grdPeriodos.TabIndex = 7
        '
        'Ver
        '
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Ver.DefaultCellStyle = DataGridViewCellStyle2
        Me.Ver.HeaderText = "Ver"
        Me.Ver.Name = "Ver"
        Me.Ver.Text = "..."
        Me.Ver.Visible = False
        Me.Ver.Width = 30
        '
        'IdEjercicio
        '
        Me.IdEjercicio.DataPropertyName = "IdEjercicio"
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.IdEjercicio.DefaultCellStyle = DataGridViewCellStyle3
        Me.IdEjercicio.HeaderText = "Ejercicio"
        Me.IdEjercicio.Name = "IdEjercicio"
        Me.IdEjercicio.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.IdEjercicio.Visible = False
        '
        'IdPeriodo
        '
        Me.IdPeriodo.DataPropertyName = "IdPeriodo"
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.IdPeriodo.DefaultCellStyle = DataGridViewCellStyle4
        Me.IdPeriodo.HeaderText = "Período [Mes]"
        Me.IdPeriodo.Name = "IdPeriodo"
        Me.IdPeriodo.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'cerrado
        '
        Me.cerrado.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.cerrado.DataPropertyName = "cerrado"
        Me.cerrado.HeaderText = "Cerrado"
        Me.cerrado.Name = "cerrado"
        Me.cerrado.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.cerrado.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        '
        'CoeficienteAjustePorInflacion
        '
        Me.CoeficienteAjustePorInflacion.DataPropertyName = "CoeficienteAjustePorInflacion"
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle5.Format = "N4"
        Me.CoeficienteAjustePorInflacion.DefaultCellStyle = DataGridViewCellStyle5
        Me.CoeficienteAjustePorInflacion.HeaderText = "Coef. Ajuste Inflación"
        Me.CoeficienteAjustePorInflacion.Name = "CoeficienteAjustePorInflacion"
        '
        'ContabilidadEjerciciosDetalle
        '
        Me.AcceptButton = Nothing
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(317, 457)
        Me.Controls.Add(Me.grdPeriodos)
        Me.Controls.Add(Me.dtpHasta)
        Me.Controls.Add(Me.dtpDesde)
        Me.Controls.Add(Me.chkCerrado)
        Me.Controls.Add(Me.lbldesde)
        Me.Controls.Add(Me.lblHasta)
        Me.Controls.Add(Me.lblCodigo)
        Me.Controls.Add(Me.txtcodigoEjercicio)
        Me.Name = "ContabilidadEjerciciosDetalle"
        Me.Text = "Ejercicio Contable"
        Me.Controls.SetChildIndex(Me.btnAplicar, 0)
        Me.Controls.SetChildIndex(Me.btnCopiar, 0)
        Me.Controls.SetChildIndex(Me.btnCancelar, 0)
        Me.Controls.SetChildIndex(Me.btnAceptar, 0)
        Me.Controls.SetChildIndex(Me.txtcodigoEjercicio, 0)
        Me.Controls.SetChildIndex(Me.lblCodigo, 0)
        Me.Controls.SetChildIndex(Me.lblHasta, 0)
        Me.Controls.SetChildIndex(Me.lbldesde, 0)
        Me.Controls.SetChildIndex(Me.chkCerrado, 0)
        Me.Controls.SetChildIndex(Me.dtpDesde, 0)
        Me.Controls.SetChildIndex(Me.dtpHasta, 0)
        Me.Controls.SetChildIndex(Me.grdPeriodos, 0)
        CType(Me.grdPeriodos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lblCodigo As Eniac.Controles.Label
   Friend WithEvents txtcodigoEjercicio As Eniac.Controles.TextBox
   Friend WithEvents lblHasta As Eniac.Controles.Label
   Friend WithEvents lbldesde As Eniac.Controles.Label
   Friend WithEvents chkCerrado As Eniac.Controles.CheckBox
   Friend WithEvents dtpDesde As Eniac.Controles.DateTimePicker
   Friend WithEvents dtpHasta As Eniac.Controles.DateTimePicker
   Friend WithEvents grdPeriodos As Eniac.Controles.DataGridView
    Friend WithEvents Ver As DataGridViewButtonColumn
    Friend WithEvents IdEjercicio As DataGridViewTextBoxColumn
    Friend WithEvents IdPeriodo As DataGridViewTextBoxColumn
    Friend WithEvents cerrado As DataGridViewCheckBoxColumn
    Friend WithEvents CoeficienteAjustePorInflacion As DataGridViewTextBoxColumn
End Class
