<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MRPNormasFabricacionDetalle
   Inherits BaseDetalle

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
        Me.chbActivo = New Eniac.Controles.CheckBox()
        Me.txtCodigoNorma = New Eniac.Controles.TextBox()
        Me.lblCodigoCategoria = New Eniac.Controles.Label()
        Me.lblDescripcion = New Eniac.Controles.Label()
        Me.txtDescripcion = New Eniac.Controles.TextBox()
        Me.tbcNormasProduccion = New System.Windows.Forms.TabControl()
        Me.tbpDispositivos = New System.Windows.Forms.TabPage()
        Me.txtDispositivos = New Eniac.Controles.TextBox()
        Me.tblMetodos = New System.Windows.Forms.TabPage()
        Me.txtMetodos = New Eniac.Controles.TextBox()
        Me.tbpSeguridad = New System.Windows.Forms.TabPage()
        Me.txtSeguridad = New Eniac.Controles.TextBox()
        Me.tbpControlCalidad = New System.Windows.Forms.TabPage()
        Me.txtControlCalidad = New Eniac.Controles.TextBox()
        Me.tbcNormasProduccion.SuspendLayout()
        Me.tbpDispositivos.SuspendLayout()
        Me.tblMetodos.SuspendLayout()
        Me.tbpSeguridad.SuspendLayout()
        Me.tbpControlCalidad.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnAceptar
        '
        Me.btnAceptar.Location = New System.Drawing.Point(312, 336)
        Me.btnAceptar.TabIndex = 6
        '
        'btnCancelar
        '
        Me.btnCancelar.Location = New System.Drawing.Point(398, 336)
        Me.btnCancelar.TabIndex = 7
        '
        'btnCopiar
        '
        Me.btnCopiar.Location = New System.Drawing.Point(211, 336)
        '
        'btnAplicar
        '
        Me.btnAplicar.Location = New System.Drawing.Point(154, 336)
        '
        'chbActivo
        '
        Me.chbActivo.AutoSize = True
        Me.chbActivo.BindearPropiedadControl = "Checked"
        Me.chbActivo.BindearPropiedadEntidad = "Activo"
        Me.chbActivo.ForeColorFocus = System.Drawing.Color.Red
        Me.chbActivo.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbActivo.IsPK = False
        Me.chbActivo.IsRequired = False
        Me.chbActivo.Key = Nothing
        Me.chbActivo.LabelAsoc = Nothing
        Me.chbActivo.Location = New System.Drawing.Point(420, 7)
        Me.chbActivo.Name = "chbActivo"
        Me.chbActivo.Size = New System.Drawing.Size(56, 17)
        Me.chbActivo.TabIndex = 4
        Me.chbActivo.Text = "Activa"
        Me.chbActivo.UseVisualStyleBackColor = True
        '
        'txtCodigoNorma
        '
        Me.txtCodigoNorma.BindearPropiedadControl = "Text"
        Me.txtCodigoNorma.BindearPropiedadEntidad = "CodigoNormaFab"
        Me.txtCodigoNorma.ForeColorFocus = System.Drawing.Color.Red
        Me.txtCodigoNorma.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtCodigoNorma.Formato = ""
        Me.txtCodigoNorma.IsDecimal = False
        Me.txtCodigoNorma.IsNumber = False
        Me.txtCodigoNorma.IsPK = True
        Me.txtCodigoNorma.IsRequired = True
        Me.txtCodigoNorma.Key = ""
        Me.txtCodigoNorma.LabelAsoc = Me.lblCodigoCategoria
        Me.txtCodigoNorma.Location = New System.Drawing.Point(78, 6)
        Me.txtCodigoNorma.MaxLength = 12
        Me.txtCodigoNorma.Name = "txtCodigoNorma"
        Me.txtCodigoNorma.Size = New System.Drawing.Size(90, 20)
        Me.txtCodigoNorma.TabIndex = 1
        '
        'lblCodigoCategoria
        '
        Me.lblCodigoCategoria.AutoSize = True
        Me.lblCodigoCategoria.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblCodigoCategoria.LabelAsoc = Nothing
        Me.lblCodigoCategoria.Location = New System.Drawing.Point(9, 9)
        Me.lblCodigoCategoria.Name = "lblCodigoCategoria"
        Me.lblCodigoCategoria.Size = New System.Drawing.Size(40, 13)
        Me.lblCodigoCategoria.TabIndex = 0
        Me.lblCodigoCategoria.Text = "Código"
        '
        'lblDescripcion
        '
        Me.lblDescripcion.AutoSize = True
        Me.lblDescripcion.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblDescripcion.LabelAsoc = Nothing
        Me.lblDescripcion.Location = New System.Drawing.Point(9, 35)
        Me.lblDescripcion.Name = "lblDescripcion"
        Me.lblDescripcion.Size = New System.Drawing.Size(63, 13)
        Me.lblDescripcion.TabIndex = 2
        Me.lblDescripcion.Text = "Descripción"
        '
        'txtDescripcion
        '
        Me.txtDescripcion.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtDescripcion.BindearPropiedadControl = "Text"
        Me.txtDescripcion.BindearPropiedadEntidad = "Descripcion"
        Me.txtDescripcion.ForeColorFocus = System.Drawing.Color.Red
        Me.txtDescripcion.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtDescripcion.Formato = ""
        Me.txtDescripcion.IsDecimal = False
        Me.txtDescripcion.IsNumber = False
        Me.txtDescripcion.IsPK = False
        Me.txtDescripcion.IsRequired = True
        Me.txtDescripcion.Key = "NombreEmpleado"
        Me.txtDescripcion.LabelAsoc = Me.lblDescripcion
        Me.txtDescripcion.Location = New System.Drawing.Point(78, 32)
        Me.txtDescripcion.MaxLength = 100
        Me.txtDescripcion.Name = "txtDescripcion"
        Me.txtDescripcion.Size = New System.Drawing.Size(390, 20)
        Me.txtDescripcion.TabIndex = 3
        '
        'tbcNormasProduccion
        '
        Me.tbcNormasProduccion.Controls.Add(Me.tbpDispositivos)
        Me.tbcNormasProduccion.Controls.Add(Me.tblMetodos)
        Me.tbcNormasProduccion.Controls.Add(Me.tbpSeguridad)
        Me.tbcNormasProduccion.Controls.Add(Me.tbpControlCalidad)
        Me.tbcNormasProduccion.Location = New System.Drawing.Point(12, 58)
        Me.tbcNormasProduccion.Name = "tbcNormasProduccion"
        Me.tbcNormasProduccion.SelectedIndex = 0
        Me.tbcNormasProduccion.Size = New System.Drawing.Size(466, 267)
        Me.tbcNormasProduccion.TabIndex = 5
        '
        'tbpDispositivos
        '
        Me.tbpDispositivos.BackColor = System.Drawing.SystemColors.Control
        Me.tbpDispositivos.Controls.Add(Me.txtDispositivos)
        Me.tbpDispositivos.Location = New System.Drawing.Point(4, 22)
        Me.tbpDispositivos.Name = "tbpDispositivos"
        Me.tbpDispositivos.Padding = New System.Windows.Forms.Padding(3)
        Me.tbpDispositivos.Size = New System.Drawing.Size(458, 241)
        Me.tbpDispositivos.TabIndex = 0
        Me.tbpDispositivos.Text = "Dispositivos"
        '
        'txtDispositivos
        '
        Me.txtDispositivos.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtDispositivos.BindearPropiedadControl = "Text"
        Me.txtDispositivos.BindearPropiedadEntidad = "DetalleDispositivos"
        Me.txtDispositivos.ForeColorFocus = System.Drawing.Color.Red
        Me.txtDispositivos.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtDispositivos.Formato = ""
        Me.txtDispositivos.IsDecimal = False
        Me.txtDispositivos.IsNumber = False
        Me.txtDispositivos.IsPK = False
        Me.txtDispositivos.IsRequired = False
        Me.txtDispositivos.Key = "NombreEmpleado"
        Me.txtDispositivos.LabelAsoc = Me.lblDescripcion
        Me.txtDispositivos.Location = New System.Drawing.Point(6, 6)
        Me.txtDispositivos.MaxLength = 65000
        Me.txtDispositivos.Multiline = True
        Me.txtDispositivos.Name = "txtDispositivos"
        Me.txtDispositivos.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtDispositivos.Size = New System.Drawing.Size(446, 229)
        Me.txtDispositivos.TabIndex = 0
        '
        'tblMetodos
        '
        Me.tblMetodos.BackColor = System.Drawing.SystemColors.Control
        Me.tblMetodos.Controls.Add(Me.txtMetodos)
        Me.tblMetodos.Location = New System.Drawing.Point(4, 22)
        Me.tblMetodos.Name = "tblMetodos"
        Me.tblMetodos.Padding = New System.Windows.Forms.Padding(3)
        Me.tblMetodos.Size = New System.Drawing.Size(458, 241)
        Me.tblMetodos.TabIndex = 1
        Me.tblMetodos.Text = "Métodos"
        '
        'txtMetodos
        '
        Me.txtMetodos.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtMetodos.BindearPropiedadControl = "Text"
        Me.txtMetodos.BindearPropiedadEntidad = "DetalleMetodos"
        Me.txtMetodos.ForeColorFocus = System.Drawing.Color.Red
        Me.txtMetodos.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtMetodos.Formato = ""
        Me.txtMetodos.IsDecimal = False
        Me.txtMetodos.IsNumber = False
        Me.txtMetodos.IsPK = False
        Me.txtMetodos.IsRequired = False
        Me.txtMetodos.Key = "NombreEmpleado"
        Me.txtMetodos.LabelAsoc = Me.lblDescripcion
        Me.txtMetodos.Location = New System.Drawing.Point(6, 6)
        Me.txtMetodos.MaxLength = 65000
        Me.txtMetodos.Multiline = True
        Me.txtMetodos.Name = "txtMetodos"
        Me.txtMetodos.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtMetodos.Size = New System.Drawing.Size(446, 229)
        Me.txtMetodos.TabIndex = 13
        '
        'tbpSeguridad
        '
        Me.tbpSeguridad.BackColor = System.Drawing.SystemColors.Control
        Me.tbpSeguridad.Controls.Add(Me.txtSeguridad)
        Me.tbpSeguridad.Location = New System.Drawing.Point(4, 22)
        Me.tbpSeguridad.Name = "tbpSeguridad"
        Me.tbpSeguridad.Padding = New System.Windows.Forms.Padding(3)
        Me.tbpSeguridad.Size = New System.Drawing.Size(458, 241)
        Me.tbpSeguridad.TabIndex = 2
        Me.tbpSeguridad.Text = "Seguridad"
        '
        'txtSeguridad
        '
        Me.txtSeguridad.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtSeguridad.BindearPropiedadControl = "Text"
        Me.txtSeguridad.BindearPropiedadEntidad = "DetalleSeguridad"
        Me.txtSeguridad.ForeColorFocus = System.Drawing.Color.Red
        Me.txtSeguridad.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtSeguridad.Formato = ""
        Me.txtSeguridad.IsDecimal = False
        Me.txtSeguridad.IsNumber = False
        Me.txtSeguridad.IsPK = False
        Me.txtSeguridad.IsRequired = False
        Me.txtSeguridad.Key = "NombreEmpleado"
        Me.txtSeguridad.LabelAsoc = Me.lblDescripcion
        Me.txtSeguridad.Location = New System.Drawing.Point(6, 6)
        Me.txtSeguridad.MaxLength = 65000
        Me.txtSeguridad.Multiline = True
        Me.txtSeguridad.Name = "txtSeguridad"
        Me.txtSeguridad.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtSeguridad.Size = New System.Drawing.Size(446, 229)
        Me.txtSeguridad.TabIndex = 13
        '
        'tbpControlCalidad
        '
        Me.tbpControlCalidad.BackColor = System.Drawing.SystemColors.Control
        Me.tbpControlCalidad.Controls.Add(Me.txtControlCalidad)
        Me.tbpControlCalidad.Location = New System.Drawing.Point(4, 22)
        Me.tbpControlCalidad.Name = "tbpControlCalidad"
        Me.tbpControlCalidad.Padding = New System.Windows.Forms.Padding(3)
        Me.tbpControlCalidad.Size = New System.Drawing.Size(458, 241)
        Me.tbpControlCalidad.TabIndex = 3
        Me.tbpControlCalidad.Text = "Control de Calidad"
        '
        'txtControlCalidad
        '
        Me.txtControlCalidad.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtControlCalidad.BindearPropiedadControl = "Text"
        Me.txtControlCalidad.BindearPropiedadEntidad = "DetalleControlCalidad"
        Me.txtControlCalidad.ForeColorFocus = System.Drawing.Color.Red
        Me.txtControlCalidad.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtControlCalidad.Formato = ""
        Me.txtControlCalidad.IsDecimal = False
        Me.txtControlCalidad.IsNumber = False
        Me.txtControlCalidad.IsPK = False
        Me.txtControlCalidad.IsRequired = False
        Me.txtControlCalidad.Key = "NombreEmpleado"
        Me.txtControlCalidad.LabelAsoc = Me.lblDescripcion
        Me.txtControlCalidad.Location = New System.Drawing.Point(6, 6)
        Me.txtControlCalidad.MaxLength = 65000
        Me.txtControlCalidad.Multiline = True
        Me.txtControlCalidad.Name = "txtControlCalidad"
        Me.txtControlCalidad.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtControlCalidad.Size = New System.Drawing.Size(446, 229)
        Me.txtControlCalidad.TabIndex = 13
        '
        'MRPNormasFabricacionDetalle
        '
        Me.AcceptButton = Nothing
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(487, 371)
        Me.Controls.Add(Me.tbcNormasProduccion)
        Me.Controls.Add(Me.chbActivo)
        Me.Controls.Add(Me.txtCodigoNorma)
        Me.Controls.Add(Me.lblDescripcion)
        Me.Controls.Add(Me.txtDescripcion)
        Me.Controls.Add(Me.lblCodigoCategoria)
        Me.Name = "MRPNormasFabricacionDetalle"
        Me.Text = "Normas de Fabricacion"
        Me.Controls.SetChildIndex(Me.lblCodigoCategoria, 0)
        Me.Controls.SetChildIndex(Me.txtDescripcion, 0)
        Me.Controls.SetChildIndex(Me.lblDescripcion, 0)
        Me.Controls.SetChildIndex(Me.txtCodigoNorma, 0)
        Me.Controls.SetChildIndex(Me.chbActivo, 0)
        Me.Controls.SetChildIndex(Me.tbcNormasProduccion, 0)
        Me.Controls.SetChildIndex(Me.btnCancelar, 0)
        Me.Controls.SetChildIndex(Me.btnAceptar, 0)
        Me.Controls.SetChildIndex(Me.btnCopiar, 0)
        Me.Controls.SetChildIndex(Me.btnAplicar, 0)
        Me.tbcNormasProduccion.ResumeLayout(False)
        Me.tbpDispositivos.ResumeLayout(False)
        Me.tbpDispositivos.PerformLayout()
        Me.tblMetodos.ResumeLayout(False)
        Me.tblMetodos.PerformLayout()
        Me.tbpSeguridad.ResumeLayout(False)
        Me.tbpSeguridad.PerformLayout()
        Me.tbpControlCalidad.ResumeLayout(False)
        Me.tbpControlCalidad.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents chbActivo As Controles.CheckBox
    Friend WithEvents txtCodigoNorma As Controles.TextBox
    Friend WithEvents lblCodigoCategoria As Controles.Label
    Friend WithEvents lblDescripcion As Controles.Label
    Friend WithEvents txtDescripcion As Controles.TextBox
    Friend WithEvents tbcNormasProduccion As TabControl
    Friend WithEvents tbpDispositivos As TabPage
    Friend WithEvents txtDispositivos As Controles.TextBox
    Friend WithEvents tblMetodos As TabPage
    Friend WithEvents txtMetodos As Controles.TextBox
    Friend WithEvents tbpSeguridad As TabPage
    Friend WithEvents txtSeguridad As Controles.TextBox
    Friend WithEvents tbpControlCalidad As TabPage
    Friend WithEvents txtControlCalidad As Controles.TextBox
End Class
