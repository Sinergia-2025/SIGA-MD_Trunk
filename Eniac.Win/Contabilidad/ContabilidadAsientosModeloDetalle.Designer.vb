<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ContabilidadAsientosModeloDetalle
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
      Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ContabilidadAsientosModeloDetalle))
      Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
      Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
      Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
      Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
      Me.Label1 = New Eniac.Controles.Label()
      Me.cmbPlan = New Eniac.Controles.ComboBox()
      Me.txtnombreModelo = New Eniac.Controles.TextBox()
      Me.lbloncept = New Eniac.Controles.Label()
      Me.lblNro = New Eniac.Controles.Label()
      Me.txtidmodelo = New Eniac.Controles.TextBox()
      Me.GroupBox1 = New System.Windows.Forms.GroupBox()
      Me.btnEliminar = New Eniac.Controles.Button()
      Me.btnInsertar = New Eniac.Controles.Button()
      Me.cmdPlan = New System.Windows.Forms.Button()
      Me.lblDesc = New Eniac.Controles.Label()
      Me.bscDescripcion = New Eniac.Controles.Buscador()
      Me.bscCodCuenta = New Eniac.Controles.Buscador()
      Me.lblCta = New Eniac.Controles.Label()
      Me.grdAsientosDetalle = New Eniac.Controles.DataGridView()
      Me.Ver = New System.Windows.Forms.DataGridViewButtonColumn()
      Me.cuenta = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.GroupBox1.SuspendLayout()
      CType(Me.grdAsientosDetalle, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.SuspendLayout()
      '
      'btnAceptar
      '
      Me.btnAceptar.Location = New System.Drawing.Point(343, 355)
      Me.btnAceptar.TabIndex = 4
      '
      'btnCancelar
      '
      Me.btnCancelar.Location = New System.Drawing.Point(429, 355)
      Me.btnCancelar.TabIndex = 5
      '
      'Label1
      '
      Me.Label1.AutoSize = True
      Me.Label1.Location = New System.Drawing.Point(172, 25)
      Me.Label1.Name = "Label1"
      Me.Label1.Size = New System.Drawing.Size(80, 13)
      Me.Label1.TabIndex = 8
      Me.Label1.Text = "Plan de Cuenta"
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
      Me.cmbPlan.IsPK = True
      Me.cmbPlan.IsRequired = True
      Me.cmbPlan.Key = Nothing
      Me.cmbPlan.LabelAsoc = Me.Label1
      Me.cmbPlan.Location = New System.Drawing.Point(256, 21)
      Me.cmbPlan.Name = "cmbPlan"
      Me.cmbPlan.Size = New System.Drawing.Size(227, 21)
      Me.cmbPlan.TabIndex = 9
      '
      'txtnombreModelo
      '
      Me.txtnombreModelo.BindearPropiedadControl = "Text"
      Me.txtnombreModelo.BindearPropiedadEntidad = "Nombreasiento"
      Me.txtnombreModelo.ForeColorFocus = System.Drawing.Color.Red
      Me.txtnombreModelo.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtnombreModelo.Formato = ""
      Me.txtnombreModelo.IsDecimal = False
      Me.txtnombreModelo.IsNumber = False
      Me.txtnombreModelo.IsPK = False
      Me.txtnombreModelo.IsRequired = True
      Me.txtnombreModelo.Key = ""
      Me.txtnombreModelo.LabelAsoc = Me.lbloncept
      Me.txtnombreModelo.Location = New System.Drawing.Point(72, 53)
      Me.txtnombreModelo.MaxLength = 50
      Me.txtnombreModelo.Name = "txtnombreModelo"
      Me.txtnombreModelo.Size = New System.Drawing.Size(411, 20)
      Me.txtnombreModelo.TabIndex = 1
      '
      'lbloncept
      '
      Me.lbloncept.AutoSize = True
      Me.lbloncept.Location = New System.Drawing.Point(13, 53)
      Me.lbloncept.Name = "lbloncept"
      Me.lbloncept.Size = New System.Drawing.Size(44, 13)
      Me.lbloncept.TabIndex = 0
      Me.lbloncept.Text = "Nombre"
      '
      'lblNro
      '
      Me.lblNro.AutoSize = True
      Me.lblNro.Location = New System.Drawing.Point(13, 25)
      Me.lblNro.Name = "lblNro"
      Me.lblNro.Size = New System.Drawing.Size(44, 13)
      Me.lblNro.TabIndex = 6
      Me.lblNro.Text = "Número"
      '
      'txtidmodelo
      '
      Me.txtidmodelo.BindearPropiedadControl = "Text"
      Me.txtidmodelo.BindearPropiedadEntidad = "idasiento"
      Me.txtidmodelo.ForeColorFocus = System.Drawing.Color.Red
      Me.txtidmodelo.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtidmodelo.Formato = ""
      Me.txtidmodelo.IsDecimal = False
      Me.txtidmodelo.IsNumber = False
      Me.txtidmodelo.IsPK = True
      Me.txtidmodelo.IsRequired = True
      Me.txtidmodelo.Key = ""
      Me.txtidmodelo.LabelAsoc = Me.lblNro
      Me.txtidmodelo.Location = New System.Drawing.Point(72, 21)
      Me.txtidmodelo.MaxLength = 8
      Me.txtidmodelo.Name = "txtidmodelo"
      Me.txtidmodelo.ReadOnly = True
      Me.txtidmodelo.Size = New System.Drawing.Size(79, 20)
      Me.txtidmodelo.TabIndex = 7
      '
      'GroupBox1
      '
      Me.GroupBox1.Controls.Add(Me.btnEliminar)
      Me.GroupBox1.Controls.Add(Me.btnInsertar)
      Me.GroupBox1.Controls.Add(Me.cmdPlan)
      Me.GroupBox1.Controls.Add(Me.lblDesc)
      Me.GroupBox1.Controls.Add(Me.bscDescripcion)
      Me.GroupBox1.Controls.Add(Me.bscCodCuenta)
      Me.GroupBox1.Controls.Add(Me.lblCta)
      Me.GroupBox1.Location = New System.Drawing.Point(16, 92)
      Me.GroupBox1.Name = "GroupBox1"
      Me.GroupBox1.Size = New System.Drawing.Size(477, 98)
      Me.GroupBox1.TabIndex = 2
      Me.GroupBox1.TabStop = False
      Me.GroupBox1.Text = "Cuenta"
      '
      'btnEliminar
      '
      Me.btnEliminar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.btnEliminar.Image = CType(resources.GetObject("btnEliminar.Image"), System.Drawing.Image)
      Me.btnEliminar.Location = New System.Drawing.Point(430, 47)
      Me.btnEliminar.Name = "btnEliminar"
      Me.btnEliminar.Size = New System.Drawing.Size(37, 37)
      Me.btnEliminar.TabIndex = 6
      Me.btnEliminar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
      Me.btnEliminar.UseVisualStyleBackColor = True
      '
      'btnInsertar
      '
      Me.btnInsertar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.btnInsertar.Image = CType(resources.GetObject("btnInsertar.Image"), System.Drawing.Image)
      Me.btnInsertar.Location = New System.Drawing.Point(393, 47)
      Me.btnInsertar.Name = "btnInsertar"
      Me.btnInsertar.Size = New System.Drawing.Size(37, 37)
      Me.btnInsertar.TabIndex = 5
      Me.btnInsertar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
      Me.btnInsertar.UseVisualStyleBackColor = True
      '
      'cmdPlan
      '
      Me.cmdPlan.Location = New System.Drawing.Point(10, 16)
      Me.cmdPlan.Name = "cmdPlan"
      Me.cmdPlan.Size = New System.Drawing.Size(103, 23)
      Me.cmdPlan.TabIndex = 0
      Me.cmdPlan.TabStop = False
      Me.cmdPlan.Text = "Ver Plan..."
      Me.cmdPlan.UseVisualStyleBackColor = True
      '
      'lblDesc
      '
      Me.lblDesc.AutoSize = True
      Me.lblDesc.Location = New System.Drawing.Point(107, 47)
      Me.lblDesc.Name = "lblDesc"
      Me.lblDesc.Size = New System.Drawing.Size(63, 13)
      Me.lblDesc.TabIndex = 3
      Me.lblDesc.Text = "Descripción"
      '
      'bscDescripcion
      '
      Me.bscDescripcion.AyudaAncho = 608
      Me.bscDescripcion.BindearPropiedadControl = Nothing
      Me.bscDescripcion.BindearPropiedadEntidad = Nothing
      Me.bscDescripcion.ColumnasAlineacion = Nothing
      Me.bscDescripcion.ColumnasAncho = Nothing
      Me.bscDescripcion.ColumnasFormato = Nothing
      Me.bscDescripcion.ColumnasOcultas = Nothing
      Me.bscDescripcion.ColumnasTitulos = Nothing
      Me.bscDescripcion.Datos = Nothing
      Me.bscDescripcion.FilaDevuelta = Nothing
      Me.bscDescripcion.ForeColorFocus = System.Drawing.Color.Red
      Me.bscDescripcion.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
      Me.bscDescripcion.IsDecimal = False
      Me.bscDescripcion.IsNumber = False
      Me.bscDescripcion.IsPK = False
      Me.bscDescripcion.IsRequired = False
      Me.bscDescripcion.Key = ""
      Me.bscDescripcion.LabelAsoc = Me.lblDesc
      Me.bscDescripcion.Location = New System.Drawing.Point(110, 63)
      Me.bscDescripcion.MaxLengh = "32767"
      Me.bscDescripcion.Name = "bscDescripcion"
      Me.bscDescripcion.Permitido = True
      Me.bscDescripcion.Selecciono = False
      Me.bscDescripcion.Size = New System.Drawing.Size(275, 20)
      Me.bscDescripcion.TabIndex = 4
      Me.bscDescripcion.Titulo = Nothing
      '
      'bscCodCuenta
      '
      Me.bscCodCuenta.AyudaAncho = 608
      Me.bscCodCuenta.BindearPropiedadControl = Nothing
      Me.bscCodCuenta.BindearPropiedadEntidad = Nothing
      Me.bscCodCuenta.ColumnasAlineacion = Nothing
      Me.bscCodCuenta.ColumnasAncho = Nothing
      Me.bscCodCuenta.ColumnasFormato = Nothing
      Me.bscCodCuenta.ColumnasOcultas = Nothing
      Me.bscCodCuenta.ColumnasTitulos = Nothing
      Me.bscCodCuenta.Datos = Nothing
      Me.bscCodCuenta.FilaDevuelta = Nothing
      Me.bscCodCuenta.ForeColorFocus = System.Drawing.Color.Red
      Me.bscCodCuenta.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
      Me.bscCodCuenta.IsDecimal = False
      Me.bscCodCuenta.IsNumber = True
      Me.bscCodCuenta.IsPK = False
      Me.bscCodCuenta.IsRequired = False
      Me.bscCodCuenta.Key = ""
      Me.bscCodCuenta.LabelAsoc = Me.lblCta
      Me.bscCodCuenta.Location = New System.Drawing.Point(10, 63)
      Me.bscCodCuenta.MaxLengh = "32767"
      Me.bscCodCuenta.Name = "bscCodCuenta"
      Me.bscCodCuenta.Permitido = True
      Me.bscCodCuenta.Selecciono = False
      Me.bscCodCuenta.Size = New System.Drawing.Size(95, 20)
      Me.bscCodCuenta.TabIndex = 2
      Me.bscCodCuenta.Titulo = Nothing
      '
      'lblCta
      '
      Me.lblCta.AutoSize = True
      Me.lblCta.Location = New System.Drawing.Point(7, 42)
      Me.lblCta.Name = "lblCta"
      Me.lblCta.Size = New System.Drawing.Size(40, 13)
      Me.lblCta.TabIndex = 1
      Me.lblCta.Text = "Código"
      '
      'grdAsientosDetalle
      '
      Me.grdAsientosDetalle.AllowUserToAddRows = False
      Me.grdAsientosDetalle.AllowUserToDeleteRows = False
      Me.grdAsientosDetalle.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
      DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
      DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
      DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
      DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
      DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
      Me.grdAsientosDetalle.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
      Me.grdAsientosDetalle.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
      Me.grdAsientosDetalle.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Ver, Me.cuenta})
      DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
      DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window
      DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText
      DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
      DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
      DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
      Me.grdAsientosDetalle.DefaultCellStyle = DataGridViewCellStyle3
      Me.grdAsientosDetalle.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
      Me.grdAsientosDetalle.Location = New System.Drawing.Point(16, 196)
      Me.grdAsientosDetalle.MultiSelect = False
      Me.grdAsientosDetalle.Name = "grdAsientosDetalle"
      Me.grdAsientosDetalle.ReadOnly = True
      DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
      DataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control
      DataGridViewCellStyle4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      DataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText
      DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight
      DataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText
      DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
      Me.grdAsientosDetalle.RowHeadersDefaultCellStyle = DataGridViewCellStyle4
      Me.grdAsientosDetalle.RowHeadersVisible = False
      Me.grdAsientosDetalle.RowHeadersWidth = 4
      Me.grdAsientosDetalle.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
      Me.grdAsientosDetalle.Size = New System.Drawing.Size(477, 142)
      Me.grdAsientosDetalle.TabIndex = 3
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
      'cuenta
      '
      Me.cuenta.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
      Me.cuenta.DataPropertyName = "Cuenta"
      Me.cuenta.HeaderText = "Cuenta [cod - desc]"
      Me.cuenta.Name = "cuenta"
      Me.cuenta.ReadOnly = True
      '
      'ContabilidadAsientosModeloDetalle
      '
      Me.AcceptButton = Nothing
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.ClientSize = New System.Drawing.Size(518, 390)
      Me.Controls.Add(Me.grdAsientosDetalle)
      Me.Controls.Add(Me.GroupBox1)
      Me.Controls.Add(Me.Label1)
      Me.Controls.Add(Me.cmbPlan)
      Me.Controls.Add(Me.txtnombreModelo)
      Me.Controls.Add(Me.lbloncept)
      Me.Controls.Add(Me.lblNro)
      Me.Controls.Add(Me.txtidmodelo)
      Me.Name = "ContabilidadAsientosModeloDetalle"
      Me.Text = "Asiento Modelo"
      Me.Controls.SetChildIndex(Me.btnCancelar, 0)
      Me.Controls.SetChildIndex(Me.btnAceptar, 0)
      Me.Controls.SetChildIndex(Me.txtidmodelo, 0)
      Me.Controls.SetChildIndex(Me.lblNro, 0)
      Me.Controls.SetChildIndex(Me.lbloncept, 0)
      Me.Controls.SetChildIndex(Me.txtnombreModelo, 0)
      Me.Controls.SetChildIndex(Me.cmbPlan, 0)
      Me.Controls.SetChildIndex(Me.Label1, 0)
      Me.Controls.SetChildIndex(Me.GroupBox1, 0)
      Me.Controls.SetChildIndex(Me.grdAsientosDetalle, 0)
      Me.GroupBox1.ResumeLayout(False)
      Me.GroupBox1.PerformLayout()
      CType(Me.grdAsientosDetalle, System.ComponentModel.ISupportInitialize).EndInit()
      Me.ResumeLayout(False)
      Me.PerformLayout()

   End Sub
    Friend WithEvents Label1 As Eniac.Controles.Label
    Friend WithEvents cmbPlan As Eniac.Controles.ComboBox
    Friend WithEvents txtnombreModelo As Eniac.Controles.TextBox
    Friend WithEvents lbloncept As Eniac.Controles.Label
    Friend WithEvents lblNro As Eniac.Controles.Label
    Friend WithEvents txtidmodelo As Eniac.Controles.TextBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents btnEliminar As Eniac.Controles.Button
    Friend WithEvents btnInsertar As Eniac.Controles.Button
    Friend WithEvents cmdPlan As System.Windows.Forms.Button
    Friend WithEvents lblDesc As Eniac.Controles.Label
    Friend WithEvents bscDescripcion As Eniac.Controles.Buscador
    Friend WithEvents bscCodCuenta As Eniac.Controles.Buscador
    Friend WithEvents lblCta As Eniac.Controles.Label
    Friend WithEvents grdAsientosDetalle As Eniac.Controles.DataGridView
    Friend WithEvents Ver As System.Windows.Forms.DataGridViewButtonColumn
    Friend WithEvents cuenta As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
