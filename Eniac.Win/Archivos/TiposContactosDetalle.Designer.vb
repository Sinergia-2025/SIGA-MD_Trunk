<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class TiposContactosDetalle
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
      Me.lblNombre = New Eniac.Controles.Label()
      Me.lblCodigo = New Eniac.Controles.Label()
      Me.txtIdTipoContacto = New Eniac.Controles.TextBox()
      Me.txtNombreTipoContacto = New Eniac.Controles.TextBox()
      Me.txtNombreTipoContactoAbrev = New Eniac.Controles.TextBox()
      Me.Label1 = New Eniac.Controles.Label()
      Me.SuspendLayout()
      '
      'btnAceptar
      '
      Me.btnAceptar.Location = New System.Drawing.Point(175, 93)
      Me.btnAceptar.TabIndex = 6
      '
      'btnCancelar
      '
      Me.btnCancelar.Location = New System.Drawing.Point(261, 93)
      Me.btnCancelar.TabIndex = 7
      '
      'lblNombre
      '
      Me.lblNombre.AutoSize = True
      Me.lblNombre.Location = New System.Drawing.Point(20, 46)
      Me.lblNombre.Name = "lblNombre"
      Me.lblNombre.Size = New System.Drawing.Size(44, 13)
      Me.lblNombre.TabIndex = 2
      Me.lblNombre.Text = "Nombre"
      '
      'lblCodigo
      '
      Me.lblCodigo.AutoSize = True
      Me.lblCodigo.Location = New System.Drawing.Point(20, 20)
      Me.lblCodigo.Name = "lblCodigo"
      Me.lblCodigo.Size = New System.Drawing.Size(40, 13)
      Me.lblCodigo.TabIndex = 0
      Me.lblCodigo.Text = "Código"
      '
      'txtIdTipoContacto
      '
      Me.txtIdTipoContacto.BindearPropiedadControl = "Text"
      Me.txtIdTipoContacto.BindearPropiedadEntidad = "IdTipoContacto"
      Me.txtIdTipoContacto.ForeColorFocus = System.Drawing.Color.Red
      Me.txtIdTipoContacto.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtIdTipoContacto.Formato = ""
      Me.txtIdTipoContacto.IsDecimal = False
      Me.txtIdTipoContacto.IsNumber = True
      Me.txtIdTipoContacto.IsPK = True
      Me.txtIdTipoContacto.IsRequired = True
      Me.txtIdTipoContacto.Key = ""
      Me.txtIdTipoContacto.LabelAsoc = Me.lblCodigo
      Me.txtIdTipoContacto.Location = New System.Drawing.Point(79, 16)
      Me.txtIdTipoContacto.MaxLength = 6
      Me.txtIdTipoContacto.Name = "txtIdTipoContacto"
      Me.txtIdTipoContacto.Size = New System.Drawing.Size(59, 20)
      Me.txtIdTipoContacto.TabIndex = 1
      Me.txtIdTipoContacto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'txtNombreTipoContacto
      '
      Me.txtNombreTipoContacto.BindearPropiedadControl = "Text"
      Me.txtNombreTipoContacto.BindearPropiedadEntidad = "NombreTipoContacto"
      Me.txtNombreTipoContacto.ForeColorFocus = System.Drawing.Color.Red
      Me.txtNombreTipoContacto.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtNombreTipoContacto.Formato = ""
      Me.txtNombreTipoContacto.IsDecimal = False
      Me.txtNombreTipoContacto.IsNumber = False
      Me.txtNombreTipoContacto.IsPK = False
      Me.txtNombreTipoContacto.IsRequired = True
      Me.txtNombreTipoContacto.Key = ""
      Me.txtNombreTipoContacto.LabelAsoc = Me.lblNombre
      Me.txtNombreTipoContacto.Location = New System.Drawing.Point(79, 42)
      Me.txtNombreTipoContacto.MaxLength = 20
      Me.txtNombreTipoContacto.Name = "txtNombreTipoContacto"
      Me.txtNombreTipoContacto.Size = New System.Drawing.Size(262, 20)
      Me.txtNombreTipoContacto.TabIndex = 3
      '
      'txtNombreTipoContactoAbrev
      '
      Me.txtNombreTipoContactoAbrev.BindearPropiedadControl = "Text"
      Me.txtNombreTipoContactoAbrev.BindearPropiedadEntidad = "NombreAbrevTipoContacto"
      Me.txtNombreTipoContactoAbrev.ForeColorFocus = System.Drawing.Color.Red
      Me.txtNombreTipoContactoAbrev.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtNombreTipoContactoAbrev.Formato = ""
      Me.txtNombreTipoContactoAbrev.IsDecimal = False
      Me.txtNombreTipoContactoAbrev.IsNumber = False
      Me.txtNombreTipoContactoAbrev.IsPK = False
      Me.txtNombreTipoContactoAbrev.IsRequired = True
      Me.txtNombreTipoContactoAbrev.Key = ""
      Me.txtNombreTipoContactoAbrev.LabelAsoc = Me.Label1
      Me.txtNombreTipoContactoAbrev.Location = New System.Drawing.Point(104, 68)
      Me.txtNombreTipoContactoAbrev.MaxLength = 2
      Me.txtNombreTipoContactoAbrev.Name = "txtNombreTipoContactoAbrev"
      Me.txtNombreTipoContactoAbrev.Size = New System.Drawing.Size(34, 20)
      Me.txtNombreTipoContactoAbrev.TabIndex = 5
      '
      'Label1
      '
      Me.Label1.AutoSize = True
      Me.Label1.Location = New System.Drawing.Point(20, 72)
      Me.Label1.Name = "Label1"
      Me.Label1.Size = New System.Drawing.Size(78, 13)
      Me.Label1.TabIndex = 4
      Me.Label1.Text = "Nombre Abrev."
      '
      'TiposContactosDetalle
      '
      Me.AcceptButton = Nothing
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.ClientSize = New System.Drawing.Size(350, 128)
      Me.Controls.Add(Me.txtNombreTipoContactoAbrev)
      Me.Controls.Add(Me.Label1)
      Me.Controls.Add(Me.txtNombreTipoContacto)
      Me.Controls.Add(Me.txtIdTipoContacto)
      Me.Controls.Add(Me.lblNombre)
      Me.Controls.Add(Me.lblCodigo)
      Me.Name = "TiposContactosDetalle"
      Me.Text = "Tipo de Contacto"
      Me.Controls.SetChildIndex(Me.lblCodigo, 0)
      Me.Controls.SetChildIndex(Me.lblNombre, 0)
      Me.Controls.SetChildIndex(Me.txtIdTipoContacto, 0)
      Me.Controls.SetChildIndex(Me.txtNombreTipoContacto, 0)
      Me.Controls.SetChildIndex(Me.btnCancelar, 0)
      Me.Controls.SetChildIndex(Me.btnAceptar, 0)
      Me.Controls.SetChildIndex(Me.Label1, 0)
      Me.Controls.SetChildIndex(Me.txtNombreTipoContactoAbrev, 0)
      Me.ResumeLayout(False)
      Me.PerformLayout()

   End Sub
   Friend WithEvents lblNombre As Eniac.Controles.Label
   Friend WithEvents lblCodigo As Eniac.Controles.Label
   Friend WithEvents txtIdTipoContacto As Eniac.Controles.TextBox
   Friend WithEvents txtNombreTipoContacto As Eniac.Controles.TextBox
   Friend WithEvents txtNombreTipoContactoAbrev As Eniac.Controles.TextBox
   Friend WithEvents Label1 As Eniac.Controles.Label

End Class
