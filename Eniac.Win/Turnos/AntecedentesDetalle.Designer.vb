<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class AntecedentesDetalle
   Inherits Eniac.Win.BaseDetalle

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
      Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(AntecedentesDetalle))
      Me.cmbTipoAntecedente = New Eniac.Controles.ComboBox
      Me.lblActividad = New Eniac.Controles.Label
      Me.txtNombre = New Eniac.Controles.TextBox
      Me.lblNombre = New Eniac.Controles.Label
      Me.txtCodigo = New Eniac.Controles.TextBox
      Me.lblCodigo = New Eniac.Controles.Label
      Me.SuspendLayout()
      '
      'btnAceptar
      '
      Me.btnAceptar.Location = New System.Drawing.Point(155, 116)
      '
      'btnCancelar
      '
      Me.btnCancelar.Location = New System.Drawing.Point(241, 116)
      Me.btnCancelar.TabIndex = 4
      '
      'cmbTipoAntecedente
      '
      Me.cmbTipoAntecedente.BindearPropiedadControl = "SelectedValue"
      Me.cmbTipoAntecedente.BindearPropiedadEntidad = "TipoAntecedente.IdTipoAntecedente"
      Me.cmbTipoAntecedente.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cmbTipoAntecedente.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.cmbTipoAntecedente.ForeColorFocus = System.Drawing.Color.Red
      Me.cmbTipoAntecedente.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.cmbTipoAntecedente.FormattingEnabled = True
      Me.cmbTipoAntecedente.IsPK = False
      Me.cmbTipoAntecedente.IsRequired = True
      Me.cmbTipoAntecedente.Key = Nothing
      Me.cmbTipoAntecedente.LabelAsoc = Me.lblActividad
      Me.cmbTipoAntecedente.Location = New System.Drawing.Point(68, 76)
      Me.cmbTipoAntecedente.Name = "cmbTipoAntecedente"
      Me.cmbTipoAntecedente.Size = New System.Drawing.Size(181, 21)
      Me.cmbTipoAntecedente.TabIndex = 2
      '
      'lblActividad
      '
      Me.lblActividad.AutoSize = True
      Me.lblActividad.Location = New System.Drawing.Point(12, 84)
      Me.lblActividad.Name = "lblActividad"
      Me.lblActividad.Size = New System.Drawing.Size(28, 13)
      Me.lblActividad.TabIndex = 7
      Me.lblActividad.Text = "Tipo"
      '
      'txtNombre
      '
      Me.txtNombre.BindearPropiedadControl = "Text"
      Me.txtNombre.BindearPropiedadEntidad = "NombreAntecedente"
      Me.txtNombre.ForeColorFocus = System.Drawing.Color.Red
      Me.txtNombre.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtNombre.Formato = ""
      Me.txtNombre.IsDecimal = False
      Me.txtNombre.IsNumber = False
      Me.txtNombre.IsPK = False
      Me.txtNombre.IsRequired = True
      Me.txtNombre.Key = ""
      Me.txtNombre.LabelAsoc = Me.lblNombre
      Me.txtNombre.Location = New System.Drawing.Point(68, 50)
      Me.txtNombre.MaxLength = 100
      Me.txtNombre.Name = "txtNombre"
      Me.txtNombre.Size = New System.Drawing.Size(256, 20)
      Me.txtNombre.TabIndex = 1
      '
      'lblNombre
      '
      Me.lblNombre.AutoSize = True
      Me.lblNombre.Location = New System.Drawing.Point(12, 57)
      Me.lblNombre.Name = "lblNombre"
      Me.lblNombre.Size = New System.Drawing.Size(44, 13)
      Me.lblNombre.TabIndex = 6
      Me.lblNombre.Text = "Nombre"
      '
      'txtCodigo
      '
      Me.txtCodigo.BindearPropiedadControl = "Text"
      Me.txtCodigo.BindearPropiedadEntidad = "IdAntecedente"
      Me.txtCodigo.ForeColorFocus = System.Drawing.Color.Red
      Me.txtCodigo.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtCodigo.Formato = ""
      Me.txtCodigo.IsDecimal = False
      Me.txtCodigo.IsNumber = True
      Me.txtCodigo.IsPK = True
      Me.txtCodigo.IsRequired = True
      Me.txtCodigo.Key = ""
      Me.txtCodigo.LabelAsoc = Me.lblCodigo
      Me.txtCodigo.Location = New System.Drawing.Point(68, 24)
      Me.txtCodigo.MaxLength = 9
      Me.txtCodigo.Name = "txtCodigo"
      Me.txtCodigo.Size = New System.Drawing.Size(75, 20)
      Me.txtCodigo.TabIndex = 0
      Me.txtCodigo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'lblCodigo
      '
      Me.lblCodigo.AutoSize = True
      Me.lblCodigo.Location = New System.Drawing.Point(12, 31)
      Me.lblCodigo.Name = "lblCodigo"
      Me.lblCodigo.Size = New System.Drawing.Size(40, 13)
      Me.lblCodigo.TabIndex = 5
      Me.lblCodigo.Text = "Codigo"
      '
      'AntecedentesDetalle
      '
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.ClientSize = New System.Drawing.Size(330, 151)
      Me.Controls.Add(Me.cmbTipoAntecedente)
      Me.Controls.Add(Me.lblActividad)
      Me.Controls.Add(Me.txtNombre)
      Me.Controls.Add(Me.lblNombre)
      Me.Controls.Add(Me.txtCodigo)
      Me.Controls.Add(Me.lblCodigo)
      Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
      Me.Name = "AntecedentesDetalle"
      Me.Text = "Antecedente"
      Me.Controls.SetChildIndex(Me.btnCancelar, 0)
      Me.Controls.SetChildIndex(Me.btnAceptar, 0)
      Me.Controls.SetChildIndex(Me.lblCodigo, 0)
      Me.Controls.SetChildIndex(Me.txtCodigo, 0)
      Me.Controls.SetChildIndex(Me.lblNombre, 0)
      Me.Controls.SetChildIndex(Me.txtNombre, 0)
      Me.Controls.SetChildIndex(Me.lblActividad, 0)
      Me.Controls.SetChildIndex(Me.cmbTipoAntecedente, 0)
      Me.ResumeLayout(False)
      Me.PerformLayout()

   End Sub
   Friend WithEvents cmbTipoAntecedente As Eniac.Controles.ComboBox
   Friend WithEvents lblActividad As Eniac.Controles.Label
   Friend WithEvents txtNombre As Eniac.Controles.TextBox
   Friend WithEvents lblNombre As Eniac.Controles.Label
   Friend WithEvents txtCodigo As Eniac.Controles.TextBox
   Friend WithEvents lblCodigo As Eniac.Controles.Label
End Class
