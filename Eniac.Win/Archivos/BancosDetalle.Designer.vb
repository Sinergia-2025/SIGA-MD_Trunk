<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class BancosDetalle
   Inherits Eniac.Win.BaseDetalle

   'Form overrides dispose to clean up the component list.
   <System.Diagnostics.DebuggerNonUserCode()> _
   Protected Overrides Sub Dispose(ByVal disposing As Boolean)
      If disposing AndAlso components IsNot Nothing Then
         components.Dispose()
      End If
      MyBase.Dispose(disposing)
   End Sub

   'Required by the Windows Form Designer
   Private components As System.ComponentModel.IContainer

   'NOTE: The following procedure is required by the Windows Form Designer
   'It can be modified using the Windows Form Designer.  
   'Do not modify it using the code editor.
   <System.Diagnostics.DebuggerStepThrough()> _
   Private Sub InitializeComponent()
      Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(BancosDetalle))
      Me.lblNombre = New Eniac.Controles.Label()
      Me.lblCodigo = New Eniac.Controles.Label()
      Me.txtCodigo = New Eniac.Controles.TextBox()
      Me.txtNombre = New Eniac.Controles.TextBox()
      Me.GroupBox1 = New System.Windows.Forms.GroupBox()
      Me.txtServicio = New Eniac.Controles.TextBox()
      Me.lblServicio = New Eniac.Controles.Label()
      Me.txtEmpresa = New Eniac.Controles.TextBox()
      Me.lblEmpresa = New Eniac.Controles.Label()
      Me.txtConvenio = New Eniac.Controles.TextBox()
      Me.lblConvenio = New Eniac.Controles.Label()
      Me.chbDebitoDirecto = New Eniac.Controles.CheckBox()
      Me.GroupBox1.SuspendLayout()
      Me.SuspendLayout()
      '
      'btnAceptar
      '
      Me.btnAceptar.Location = New System.Drawing.Point(187, 203)
      Me.btnAceptar.TabIndex = 4
      '
      'btnCancelar
      '
      Me.btnCancelar.Location = New System.Drawing.Point(273, 203)
      Me.btnCancelar.TabIndex = 4
      '
      'lblNombre
      '
      Me.lblNombre.AutoSize = True
      Me.lblNombre.Location = New System.Drawing.Point(20, 46)
      Me.lblNombre.Name = "lblNombre"
      Me.lblNombre.Size = New System.Drawing.Size(44, 13)
      Me.lblNombre.TabIndex = 6
      Me.lblNombre.Text = "Nombre"
      '
      'lblCodigo
      '
      Me.lblCodigo.AutoSize = True
      Me.lblCodigo.Location = New System.Drawing.Point(20, 20)
      Me.lblCodigo.Name = "lblCodigo"
      Me.lblCodigo.Size = New System.Drawing.Size(40, 13)
      Me.lblCodigo.TabIndex = 5
      Me.lblCodigo.Text = "Código"
      '
      'txtCodigo
      '
      Me.txtCodigo.BindearPropiedadControl = "Text"
      Me.txtCodigo.BindearPropiedadEntidad = "IdBanco"
      Me.txtCodigo.ForeColorFocus = System.Drawing.Color.Red
      Me.txtCodigo.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtCodigo.Formato = ""
      Me.txtCodigo.IsDecimal = False
      Me.txtCodigo.IsNumber = True
      Me.txtCodigo.IsPK = True
      Me.txtCodigo.IsRequired = True
      Me.txtCodigo.Key = ""
      Me.txtCodigo.LabelAsoc = Me.lblCodigo
      Me.txtCodigo.Location = New System.Drawing.Point(90, 16)
      Me.txtCodigo.MaxLength = 6
      Me.txtCodigo.Name = "txtCodigo"
      Me.txtCodigo.Size = New System.Drawing.Size(59, 20)
      Me.txtCodigo.TabIndex = 0
      Me.txtCodigo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'txtNombre
      '
      Me.txtNombre.BindearPropiedadControl = "Text"
      Me.txtNombre.BindearPropiedadEntidad = "NombreBanco"
      Me.txtNombre.ForeColorFocus = System.Drawing.Color.Red
      Me.txtNombre.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtNombre.Formato = ""
      Me.txtNombre.IsDecimal = False
      Me.txtNombre.IsNumber = False
      Me.txtNombre.IsPK = False
      Me.txtNombre.IsRequired = True
      Me.txtNombre.Key = ""
      Me.txtNombre.LabelAsoc = Me.lblNombre
      Me.txtNombre.Location = New System.Drawing.Point(90, 42)
      Me.txtNombre.MaxLength = 40
      Me.txtNombre.Name = "txtNombre"
      Me.txtNombre.Size = New System.Drawing.Size(262, 20)
      Me.txtNombre.TabIndex = 1
      '
      'GroupBox1
      '
      Me.GroupBox1.Controls.Add(Me.txtServicio)
      Me.GroupBox1.Controls.Add(Me.txtEmpresa)
      Me.GroupBox1.Controls.Add(Me.txtConvenio)
      Me.GroupBox1.Controls.Add(Me.lblEmpresa)
      Me.GroupBox1.Controls.Add(Me.lblConvenio)
      Me.GroupBox1.Controls.Add(Me.lblServicio)
      Me.GroupBox1.Location = New System.Drawing.Point(23, 97)
      Me.GroupBox1.Name = "GroupBox1"
      Me.GroupBox1.Size = New System.Drawing.Size(329, 97)
      Me.GroupBox1.TabIndex = 3
      Me.GroupBox1.TabStop = False
      '
      'txtServicio
      '
      Me.txtServicio.BindearPropiedadControl = "Text"
      Me.txtServicio.BindearPropiedadEntidad = "Servicio"
      Me.txtServicio.Enabled = False
      Me.txtServicio.ForeColorFocus = System.Drawing.Color.Red
      Me.txtServicio.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtServicio.Formato = ""
      Me.txtServicio.IsDecimal = False
      Me.txtServicio.IsNumber = False
      Me.txtServicio.IsPK = False
      Me.txtServicio.IsRequired = False
      Me.txtServicio.Key = ""
      Me.txtServicio.LabelAsoc = Me.lblServicio
      Me.txtServicio.Location = New System.Drawing.Point(64, 65)
      Me.txtServicio.MaxLength = 10
      Me.txtServicio.Name = "txtServicio"
      Me.txtServicio.Size = New System.Drawing.Size(139, 20)
      Me.txtServicio.TabIndex = 2
      '
      'lblServicio
      '
      Me.lblServicio.AutoSize = True
      Me.lblServicio.Location = New System.Drawing.Point(6, 69)
      Me.lblServicio.Name = "lblServicio"
      Me.lblServicio.Size = New System.Drawing.Size(45, 13)
      Me.lblServicio.TabIndex = 11
      Me.lblServicio.Text = "Servicio"
      '
      'txtEmpresa
      '
      Me.txtEmpresa.BindearPropiedadControl = "Text"
      Me.txtEmpresa.BindearPropiedadEntidad = "Empresa"
      Me.txtEmpresa.Enabled = False
      Me.txtEmpresa.ForeColorFocus = System.Drawing.Color.Red
      Me.txtEmpresa.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtEmpresa.Formato = ""
      Me.txtEmpresa.IsDecimal = False
      Me.txtEmpresa.IsNumber = True
      Me.txtEmpresa.IsPK = True
      Me.txtEmpresa.IsRequired = False
      Me.txtEmpresa.Key = ""
      Me.txtEmpresa.LabelAsoc = Me.lblEmpresa
      Me.txtEmpresa.Location = New System.Drawing.Point(64, 16)
      Me.txtEmpresa.MaxLength = 4
      Me.txtEmpresa.Name = "txtEmpresa"
      Me.txtEmpresa.Size = New System.Drawing.Size(59, 20)
      Me.txtEmpresa.TabIndex = 0
      Me.txtEmpresa.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'lblEmpresa
      '
      Me.lblEmpresa.AutoSize = True
      Me.lblEmpresa.Location = New System.Drawing.Point(6, 19)
      Me.lblEmpresa.Name = "lblEmpresa"
      Me.lblEmpresa.Size = New System.Drawing.Size(48, 13)
      Me.lblEmpresa.TabIndex = 9
      Me.lblEmpresa.Text = "Empresa"
      '
      'txtConvenio
      '
      Me.txtConvenio.BindearPropiedadControl = "Text"
      Me.txtConvenio.BindearPropiedadEntidad = "Convenio"
      Me.txtConvenio.Enabled = False
      Me.txtConvenio.ForeColorFocus = System.Drawing.Color.Red
      Me.txtConvenio.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtConvenio.Formato = ""
      Me.txtConvenio.IsDecimal = False
      Me.txtConvenio.IsNumber = True
      Me.txtConvenio.IsPK = True
      Me.txtConvenio.IsRequired = False
      Me.txtConvenio.Key = ""
      Me.txtConvenio.LabelAsoc = Me.lblConvenio
      Me.txtConvenio.Location = New System.Drawing.Point(64, 40)
      Me.txtConvenio.MaxLength = 5
      Me.txtConvenio.Name = "txtConvenio"
      Me.txtConvenio.Size = New System.Drawing.Size(59, 20)
      Me.txtConvenio.TabIndex = 1
      Me.txtConvenio.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'lblConvenio
      '
      Me.lblConvenio.AutoSize = True
      Me.lblConvenio.Location = New System.Drawing.Point(6, 43)
      Me.lblConvenio.Name = "lblConvenio"
      Me.lblConvenio.Size = New System.Drawing.Size(52, 13)
      Me.lblConvenio.TabIndex = 10
      Me.lblConvenio.Text = "Convenio"
      '
      'chbDebitoDirecto
      '
      Me.chbDebitoDirecto.AutoSize = True
      Me.chbDebitoDirecto.BindearPropiedadControl = "Checked"
      Me.chbDebitoDirecto.BindearPropiedadEntidad = "DebitoDirecto"
      Me.chbDebitoDirecto.ForeColorFocus = System.Drawing.Color.Red
      Me.chbDebitoDirecto.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
      Me.chbDebitoDirecto.IsPK = False
      Me.chbDebitoDirecto.IsRequired = False
      Me.chbDebitoDirecto.Key = Nothing
      Me.chbDebitoDirecto.LabelAsoc = Nothing
      Me.chbDebitoDirecto.Location = New System.Drawing.Point(23, 80)
      Me.chbDebitoDirecto.Name = "chbDebitoDirecto"
      Me.chbDebitoDirecto.Size = New System.Drawing.Size(94, 17)
      Me.chbDebitoDirecto.TabIndex = 2
      Me.chbDebitoDirecto.Text = "Débito Directo"
      Me.chbDebitoDirecto.UseVisualStyleBackColor = True
      '
      'BancosDetalle
      '
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.ClientSize = New System.Drawing.Size(362, 238)
      Me.Controls.Add(Me.chbDebitoDirecto)
      Me.Controls.Add(Me.GroupBox1)
      Me.Controls.Add(Me.txtNombre)
      Me.Controls.Add(Me.txtCodigo)
      Me.Controls.Add(Me.lblNombre)
      Me.Controls.Add(Me.lblCodigo)
      Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
      Me.Name = "BancosDetalle"
      Me.Text = "Bancos"
      Me.Controls.SetChildIndex(Me.btnCopiar, 0)
      Me.Controls.SetChildIndex(Me.btnCancelar, 0)
      Me.Controls.SetChildIndex(Me.btnAceptar, 0)
      Me.Controls.SetChildIndex(Me.lblCodigo, 0)
      Me.Controls.SetChildIndex(Me.lblNombre, 0)
      Me.Controls.SetChildIndex(Me.txtCodigo, 0)
      Me.Controls.SetChildIndex(Me.txtNombre, 0)
      Me.Controls.SetChildIndex(Me.GroupBox1, 0)
      Me.Controls.SetChildIndex(Me.chbDebitoDirecto, 0)
      Me.GroupBox1.ResumeLayout(False)
      Me.GroupBox1.PerformLayout()
      Me.ResumeLayout(False)
      Me.PerformLayout()

   End Sub
   Friend WithEvents lblNombre As Eniac.Controles.Label
   Friend WithEvents lblCodigo As Eniac.Controles.Label
   Friend WithEvents txtCodigo As Eniac.Controles.TextBox
   Friend WithEvents txtNombre As Eniac.Controles.TextBox
   Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
   Friend WithEvents chbDebitoDirecto As Eniac.Controles.CheckBox
   Friend WithEvents txtServicio As Eniac.Controles.TextBox
   Friend WithEvents txtEmpresa As Eniac.Controles.TextBox
   Friend WithEvents txtConvenio As Eniac.Controles.TextBox
   Friend WithEvents lblEmpresa As Eniac.Controles.Label
   Friend WithEvents lblConvenio As Eniac.Controles.Label
   Friend WithEvents lblServicio As Eniac.Controles.Label

End Class
