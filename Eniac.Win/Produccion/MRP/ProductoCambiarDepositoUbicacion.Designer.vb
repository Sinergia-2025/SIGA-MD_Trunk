<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ProductoCambiarDepositoUbicacion
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
      Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ProductoCambiarDepositoUbicacion))
      Me.imageList1 = New System.Windows.Forms.ImageList(Me.components)
      Me.btnAceptar = New System.Windows.Forms.Button()
      Me.btnCancelar = New System.Windows.Forms.Button()
      Me.cmbUbicacionNuevo = New Eniac.Controles.ComboBox()
      Me.cmbDepositoNuevo = New Eniac.Controles.ComboBox()
      Me.lblDepositoNuevo = New Eniac.Controles.Label()
      Me.lblUbicacionNuevo = New Eniac.Controles.Label()
      Me.txtProducto = New Eniac.Controles.TextBox()
      Me.lblProducto = New Eniac.Controles.Label()
      Me.lblDepositoActual = New Eniac.Controles.Label()
      Me.txtDepositoActual = New Eniac.Controles.TextBox()
      Me.lblUbicacionActual = New Eniac.Controles.Label()
      Me.txtUbicacionActual = New Eniac.Controles.TextBox()
      Me.lblCantidad = New Eniac.Controles.Label()
      Me.txtCantidad = New Eniac.Controles.TextBox()
      Me.grpActual = New System.Windows.Forms.GroupBox()
      Me.pnlLayoutActual = New System.Windows.Forms.TableLayoutPanel()
      Me.pnlProducto = New System.Windows.Forms.Panel()
      Me.grpNuevo = New System.Windows.Forms.GroupBox()
        Me.pnlLayoutNuevo = New System.Windows.Forms.TableLayoutPanel()
        Me.lblCantidadNuevo = New Eniac.Controles.Label()
        Me.txtCantidadNuevo = New Eniac.Controles.TextBox()
        Me.pnlAcciones = New System.Windows.Forms.Panel()
        Me.grpActual.SuspendLayout()
        Me.pnlLayoutActual.SuspendLayout()
        Me.pnlProducto.SuspendLayout()
        Me.grpNuevo.SuspendLayout()
        Me.pnlLayoutNuevo.SuspendLayout()
        Me.pnlAcciones.SuspendLayout()
        Me.SuspendLayout()
        '
        'imageList1
        '
        Me.imageList1.ImageStream = CType(resources.GetObject("imageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.imageList1.TransparentColor = System.Drawing.Color.Transparent
        Me.imageList1.Images.SetKeyName(0, "check2.ico")
        Me.imageList1.Images.SetKeyName(1, "delete2.ico")
        '
        'btnAceptar
        '
        Me.btnAceptar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnAceptar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnAceptar.ImageIndex = 0
        Me.btnAceptar.ImageList = Me.imageList1
        Me.btnAceptar.Location = New System.Drawing.Point(229, 4)
        Me.btnAceptar.Name = "btnAceptar"
        Me.btnAceptar.Size = New System.Drawing.Size(80, 30)
        Me.btnAceptar.TabIndex = 5
        Me.btnAceptar.Text = "&Aceptar"
        Me.btnAceptar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnAceptar.UseVisualStyleBackColor = True
        '
        'btnCancelar
        '
        Me.btnCancelar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCancelar.ImageIndex = 1
        Me.btnCancelar.ImageList = Me.imageList1
        Me.btnCancelar.Location = New System.Drawing.Point(315, 4)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(80, 30)
        Me.btnCancelar.TabIndex = 4
        Me.btnCancelar.Text = "&Cancelar"
        Me.btnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnCancelar.UseVisualStyleBackColor = True
        '
        'cmbUbicacionNuevo
        '
        Me.cmbUbicacionNuevo.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmbUbicacionNuevo.BindearPropiedadControl = Nothing
        Me.cmbUbicacionNuevo.BindearPropiedadEntidad = Nothing
        Me.cmbUbicacionNuevo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbUbicacionNuevo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.cmbUbicacionNuevo.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbUbicacionNuevo.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbUbicacionNuevo.FormattingEnabled = True
        Me.cmbUbicacionNuevo.IsPK = False
        Me.cmbUbicacionNuevo.IsRequired = False
        Me.cmbUbicacionNuevo.Key = Nothing
        Me.cmbUbicacionNuevo.LabelAsoc = Me.lblUbicacionNuevo
        Me.cmbUbicacionNuevo.Location = New System.Drawing.Point(103, 30)
        Me.cmbUbicacionNuevo.Name = "cmbUbicacionNuevo"
        Me.cmbUbicacionNuevo.Size = New System.Drawing.Size(291, 21)
        Me.cmbUbicacionNuevo.TabIndex = 73
        '
        'cmbDepositoNuevo
        '
        Me.cmbDepositoNuevo.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmbDepositoNuevo.BindearPropiedadControl = Nothing
        Me.cmbDepositoNuevo.BindearPropiedadEntidad = Nothing
        Me.cmbDepositoNuevo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbDepositoNuevo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.cmbDepositoNuevo.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbDepositoNuevo.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbDepositoNuevo.FormattingEnabled = True
        Me.cmbDepositoNuevo.IsPK = False
        Me.cmbDepositoNuevo.IsRequired = False
        Me.cmbDepositoNuevo.Key = Nothing
        Me.cmbDepositoNuevo.LabelAsoc = Me.lblDepositoNuevo
        Me.cmbDepositoNuevo.Location = New System.Drawing.Point(103, 3)
        Me.cmbDepositoNuevo.Name = "cmbDepositoNuevo"
        Me.cmbDepositoNuevo.Size = New System.Drawing.Size(291, 21)
        Me.cmbDepositoNuevo.TabIndex = 74
        '
        'lblDepositoNuevo
        '
        Me.lblDepositoNuevo.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lblDepositoNuevo.AutoSize = True
        Me.lblDepositoNuevo.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblDepositoNuevo.LabelAsoc = Nothing
        Me.lblDepositoNuevo.Location = New System.Drawing.Point(3, 7)
        Me.lblDepositoNuevo.Name = "lblDepositoNuevo"
        Me.lblDepositoNuevo.Size = New System.Drawing.Size(84, 13)
        Me.lblDepositoNuevo.TabIndex = 71
        Me.lblDepositoNuevo.Text = "Depósito Nuevo"
        '
        'lblUbicacionNuevo
        '
        Me.lblUbicacionNuevo.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lblUbicacionNuevo.AutoSize = True
        Me.lblUbicacionNuevo.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblUbicacionNuevo.LabelAsoc = Nothing
        Me.lblUbicacionNuevo.Location = New System.Drawing.Point(3, 34)
        Me.lblUbicacionNuevo.Name = "lblUbicacionNuevo"
        Me.lblUbicacionNuevo.Size = New System.Drawing.Size(90, 13)
        Me.lblUbicacionNuevo.TabIndex = 72
        Me.lblUbicacionNuevo.Text = "Ubicación Nuevo"
        '
        'txtProducto
        '
        Me.txtProducto.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtProducto.BindearPropiedadControl = ""
        Me.txtProducto.BindearPropiedadEntidad = ""
        Me.txtProducto.ForeColorFocus = System.Drawing.Color.Red
        Me.txtProducto.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtProducto.Formato = ""
        Me.txtProducto.IsDecimal = False
        Me.txtProducto.IsNumber = True
        Me.txtProducto.IsPK = False
        Me.txtProducto.IsRequired = False
        Me.txtProducto.Key = ""
        Me.txtProducto.LabelAsoc = Nothing
        Me.txtProducto.Location = New System.Drawing.Point(100, 16)
        Me.txtProducto.MaxLength = 8
        Me.txtProducto.Name = "txtProducto"
        Me.txtProducto.ReadOnly = True
        Me.txtProducto.Size = New System.Drawing.Size(297, 20)
        Me.txtProducto.TabIndex = 83
        '
        'lblProducto
        '
        Me.lblProducto.AutoSize = True
        Me.lblProducto.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblProducto.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblProducto.LabelAsoc = Nothing
        Me.lblProducto.Location = New System.Drawing.Point(6, 20)
        Me.lblProducto.Name = "lblProducto"
        Me.lblProducto.Size = New System.Drawing.Size(50, 13)
        Me.lblProducto.TabIndex = 82
        Me.lblProducto.Text = "Producto"
        '
        'lblDepositoActual
        '
        Me.lblDepositoActual.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lblDepositoActual.AutoSize = True
        Me.lblDepositoActual.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblDepositoActual.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblDepositoActual.LabelAsoc = Nothing
        Me.lblDepositoActual.Location = New System.Drawing.Point(3, 6)
        Me.lblDepositoActual.Name = "lblDepositoActual"
        Me.lblDepositoActual.Size = New System.Drawing.Size(82, 13)
        Me.lblDepositoActual.TabIndex = 82
        Me.lblDepositoActual.Text = "Depósito Actual"
        '
        'txtDepositoActual
        '
        Me.txtDepositoActual.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtDepositoActual.BindearPropiedadControl = ""
        Me.txtDepositoActual.BindearPropiedadEntidad = ""
        Me.txtDepositoActual.ForeColorFocus = System.Drawing.Color.Red
        Me.txtDepositoActual.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtDepositoActual.Formato = ""
        Me.txtDepositoActual.IsDecimal = False
        Me.txtDepositoActual.IsNumber = True
        Me.txtDepositoActual.IsPK = False
        Me.txtDepositoActual.IsRequired = False
        Me.txtDepositoActual.Key = ""
        Me.txtDepositoActual.LabelAsoc = Nothing
        Me.txtDepositoActual.Location = New System.Drawing.Point(103, 3)
        Me.txtDepositoActual.MaxLength = 8
        Me.txtDepositoActual.Name = "txtDepositoActual"
        Me.txtDepositoActual.ReadOnly = True
        Me.txtDepositoActual.Size = New System.Drawing.Size(291, 20)
        Me.txtDepositoActual.TabIndex = 83
        '
        'lblUbicacionActual
        '
        Me.lblUbicacionActual.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lblUbicacionActual.AutoSize = True
        Me.lblUbicacionActual.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblUbicacionActual.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblUbicacionActual.LabelAsoc = Nothing
        Me.lblUbicacionActual.Location = New System.Drawing.Point(3, 32)
        Me.lblUbicacionActual.Name = "lblUbicacionActual"
        Me.lblUbicacionActual.Size = New System.Drawing.Size(88, 13)
        Me.lblUbicacionActual.TabIndex = 82
        Me.lblUbicacionActual.Text = "Ubicación Actual"
        '
        'txtUbicacionActual
        '
        Me.txtUbicacionActual.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtUbicacionActual.BindearPropiedadControl = ""
        Me.txtUbicacionActual.BindearPropiedadEntidad = ""
        Me.txtUbicacionActual.ForeColorFocus = System.Drawing.Color.Red
        Me.txtUbicacionActual.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtUbicacionActual.Formato = ""
        Me.txtUbicacionActual.IsDecimal = False
        Me.txtUbicacionActual.IsNumber = True
        Me.txtUbicacionActual.IsPK = False
        Me.txtUbicacionActual.IsRequired = False
        Me.txtUbicacionActual.Key = ""
        Me.txtUbicacionActual.LabelAsoc = Nothing
        Me.txtUbicacionActual.Location = New System.Drawing.Point(103, 29)
        Me.txtUbicacionActual.MaxLength = 8
        Me.txtUbicacionActual.Name = "txtUbicacionActual"
        Me.txtUbicacionActual.ReadOnly = True
        Me.txtUbicacionActual.Size = New System.Drawing.Size(291, 20)
        Me.txtUbicacionActual.TabIndex = 83
        '
        'lblCantidad
        '
        Me.lblCantidad.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lblCantidad.AutoSize = True
        Me.lblCantidad.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblCantidad.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblCantidad.LabelAsoc = Nothing
        Me.lblCantidad.Location = New System.Drawing.Point(3, 58)
        Me.lblCantidad.Name = "lblCantidad"
        Me.lblCantidad.Size = New System.Drawing.Size(49, 13)
        Me.lblCantidad.TabIndex = 82
        Me.lblCantidad.Text = "Cantidad"
        '
        'txtCantidad
        '
        Me.txtCantidad.BindearPropiedadControl = ""
        Me.txtCantidad.BindearPropiedadEntidad = ""
        Me.txtCantidad.ForeColorFocus = System.Drawing.Color.Red
        Me.txtCantidad.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtCantidad.Formato = "N2"
        Me.txtCantidad.IsDecimal = False
        Me.txtCantidad.IsNumber = True
        Me.txtCantidad.IsPK = False
        Me.txtCantidad.IsRequired = False
        Me.txtCantidad.Key = ""
        Me.txtCantidad.LabelAsoc = Nothing
        Me.txtCantidad.Location = New System.Drawing.Point(103, 55)
        Me.txtCantidad.MaxLength = 8
        Me.txtCantidad.Name = "txtCantidad"
        Me.txtCantidad.ReadOnly = True
        Me.txtCantidad.Size = New System.Drawing.Size(80, 20)
        Me.txtCantidad.TabIndex = 83
        Me.txtCantidad.Text = "0.00"
        Me.txtCantidad.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'grpActual
        '
        Me.grpActual.Controls.Add(Me.pnlLayoutActual)
        Me.grpActual.Dock = System.Windows.Forms.DockStyle.Top
        Me.grpActual.Location = New System.Drawing.Point(0, 49)
        Me.grpActual.Name = "grpActual"
        Me.grpActual.Size = New System.Drawing.Size(403, 103)
        Me.grpActual.TabIndex = 84
        Me.grpActual.TabStop = False
        Me.grpActual.Text = "Depósito/Ubicación Actual"
        '
        'pnlLayoutActual
        '
        Me.pnlLayoutActual.ColumnCount = 2
        Me.pnlLayoutActual.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100.0!))
        Me.pnlLayoutActual.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.pnlLayoutActual.Controls.Add(Me.lblCantidad, 0, 2)
        Me.pnlLayoutActual.Controls.Add(Me.txtCantidad, 1, 2)
        Me.pnlLayoutActual.Controls.Add(Me.lblUbicacionActual, 0, 1)
        Me.pnlLayoutActual.Controls.Add(Me.txtUbicacionActual, 1, 1)
        Me.pnlLayoutActual.Controls.Add(Me.txtDepositoActual, 1, 0)
        Me.pnlLayoutActual.Controls.Add(Me.lblDepositoActual, 0, 0)
        Me.pnlLayoutActual.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlLayoutActual.Location = New System.Drawing.Point(3, 16)
        Me.pnlLayoutActual.Name = "pnlLayoutActual"
        Me.pnlLayoutActual.RowCount = 4
        Me.pnlLayoutActual.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.pnlLayoutActual.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.pnlLayoutActual.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.pnlLayoutActual.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.pnlLayoutActual.Size = New System.Drawing.Size(397, 84)
        Me.pnlLayoutActual.TabIndex = 85
        '
        'pnlProducto
        '
        Me.pnlProducto.AutoSize = True
        Me.pnlProducto.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.pnlProducto.Controls.Add(Me.txtProducto)
        Me.pnlProducto.Controls.Add(Me.lblProducto)
        Me.pnlProducto.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlProducto.Location = New System.Drawing.Point(0, 0)
        Me.pnlProducto.Name = "pnlProducto"
        Me.pnlProducto.Padding = New System.Windows.Forms.Padding(0, 10, 0, 10)
        Me.pnlProducto.Size = New System.Drawing.Size(403, 49)
        Me.pnlProducto.TabIndex = 85
        '
        'grpNuevo
        '
        Me.grpNuevo.Controls.Add(Me.pnlLayoutNuevo)
        Me.grpNuevo.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grpNuevo.Location = New System.Drawing.Point(0, 152)
        Me.grpNuevo.Name = "grpNuevo"
        Me.grpNuevo.Size = New System.Drawing.Size(403, 137)
        Me.grpNuevo.TabIndex = 86
        Me.grpNuevo.TabStop = False
        Me.grpNuevo.Text = "Depósito/Ubicación Nuevo"
        '
        'pnlLayoutNuevo
        '
        Me.pnlLayoutNuevo.ColumnCount = 2
        Me.pnlLayoutNuevo.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100.0!))
        Me.pnlLayoutNuevo.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.pnlLayoutNuevo.Controls.Add(Me.lblCantidadNuevo, 0, 2)
        Me.pnlLayoutNuevo.Controls.Add(Me.cmbDepositoNuevo, 1, 0)
        Me.pnlLayoutNuevo.Controls.Add(Me.txtCantidadNuevo, 1, 2)
        Me.pnlLayoutNuevo.Controls.Add(Me.lblDepositoNuevo, 0, 0)
        Me.pnlLayoutNuevo.Controls.Add(Me.cmbUbicacionNuevo, 1, 1)
        Me.pnlLayoutNuevo.Controls.Add(Me.lblUbicacionNuevo, 0, 1)
        Me.pnlLayoutNuevo.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlLayoutNuevo.Location = New System.Drawing.Point(3, 16)
        Me.pnlLayoutNuevo.Name = "pnlLayoutNuevo"
        Me.pnlLayoutNuevo.RowCount = 4
        Me.pnlLayoutNuevo.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.pnlLayoutNuevo.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.pnlLayoutNuevo.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.pnlLayoutNuevo.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.pnlLayoutNuevo.Size = New System.Drawing.Size(397, 118)
        Me.pnlLayoutNuevo.TabIndex = 0
        '
        'lblCantidadNuevo
        '
        Me.lblCantidadNuevo.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lblCantidadNuevo.AutoSize = True
        Me.lblCantidadNuevo.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblCantidadNuevo.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblCantidadNuevo.LabelAsoc = Nothing
        Me.lblCantidadNuevo.Location = New System.Drawing.Point(3, 60)
        Me.lblCantidadNuevo.Name = "lblCantidadNuevo"
        Me.lblCantidadNuevo.Size = New System.Drawing.Size(49, 13)
        Me.lblCantidadNuevo.TabIndex = 82
        Me.lblCantidadNuevo.Text = "Cantidad"
        '
        'txtCantidadNuevo
        '
        Me.txtCantidadNuevo.BindearPropiedadControl = ""
        Me.txtCantidadNuevo.BindearPropiedadEntidad = ""
        Me.txtCantidadNuevo.ForeColorFocus = System.Drawing.Color.Red
        Me.txtCantidadNuevo.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtCantidadNuevo.Formato = "N2"
        Me.txtCantidadNuevo.IsDecimal = False
        Me.txtCantidadNuevo.IsNumber = True
        Me.txtCantidadNuevo.IsPK = False
        Me.txtCantidadNuevo.IsRequired = False
        Me.txtCantidadNuevo.Key = ""
        Me.txtCantidadNuevo.LabelAsoc = Nothing
        Me.txtCantidadNuevo.Location = New System.Drawing.Point(103, 57)
        Me.txtCantidadNuevo.MaxLength = 8
        Me.txtCantidadNuevo.Name = "txtCantidadNuevo"
        Me.txtCantidadNuevo.ReadOnly = True
        Me.txtCantidadNuevo.Size = New System.Drawing.Size(80, 20)
        Me.txtCantidadNuevo.TabIndex = 83
        Me.txtCantidadNuevo.Text = "0.00"
        Me.txtCantidadNuevo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'pnlAcciones
        '
        Me.pnlAcciones.AutoSize = True
        Me.pnlAcciones.Controls.Add(Me.btnAceptar)
        Me.pnlAcciones.Controls.Add(Me.btnCancelar)
        Me.pnlAcciones.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnlAcciones.Location = New System.Drawing.Point(0, 252)
        Me.pnlAcciones.Name = "pnlAcciones"
        Me.pnlAcciones.Size = New System.Drawing.Size(403, 37)
        Me.pnlAcciones.TabIndex = 87
        '
        'ProductoCambiarDepositoUbicacion
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(403, 289)
        Me.Controls.Add(Me.pnlAcciones)
        Me.Controls.Add(Me.grpNuevo)
        Me.Controls.Add(Me.grpActual)
        Me.Controls.Add(Me.pnlProducto)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "ProductoCambiarDepositoUbicacion"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Cambiar Depósito/Ubicación"
        Me.grpActual.ResumeLayout(False)
        Me.pnlLayoutActual.ResumeLayout(False)
        Me.pnlLayoutActual.PerformLayout()
        Me.pnlProducto.ResumeLayout(False)
        Me.pnlProducto.PerformLayout()
        Me.grpNuevo.ResumeLayout(False)
        Me.pnlLayoutNuevo.ResumeLayout(False)
        Me.pnlLayoutNuevo.PerformLayout()
        Me.pnlAcciones.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Private WithEvents imageList1 As ImageList
   Protected WithEvents btnAceptar As Button
   Protected WithEvents btnCancelar As Button
   Friend WithEvents cmbUbicacionNuevo As Controles.ComboBox
   Friend WithEvents cmbDepositoNuevo As Controles.ComboBox
   Friend WithEvents lblDepositoNuevo As Controles.Label
   Friend WithEvents lblUbicacionNuevo As Controles.Label
   Friend WithEvents txtProducto As Controles.TextBox
   Friend WithEvents lblProducto As Controles.Label
   Friend WithEvents lblDepositoActual As Controles.Label
   Friend WithEvents txtDepositoActual As Controles.TextBox
   Friend WithEvents lblUbicacionActual As Controles.Label
   Friend WithEvents txtUbicacionActual As Controles.TextBox
   Friend WithEvents lblCantidad As Controles.Label
   Friend WithEvents txtCantidad As Controles.TextBox
   Friend WithEvents grpActual As GroupBox
   Friend WithEvents pnlLayoutActual As TableLayoutPanel
   Friend WithEvents pnlProducto As Panel
   Friend WithEvents grpNuevo As GroupBox
   Friend WithEvents pnlLayoutNuevo As TableLayoutPanel
   Friend WithEvents lblCantidadNuevo As Controles.Label
   Friend WithEvents txtCantidadNuevo As Controles.TextBox
   Friend WithEvents pnlAcciones As Panel
End Class
