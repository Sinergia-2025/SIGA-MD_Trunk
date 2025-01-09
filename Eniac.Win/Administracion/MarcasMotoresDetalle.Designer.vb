<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MarcasMotoresDetalle
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
      Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MarcasMotoresDetalle))
      Me.lblNombre = New Eniac.Controles.Label()
      Me.txtMarcaMotor = New Eniac.Controles.TextBox()
      Me.lblId = New Eniac.Controles.Label()
      Me.txtIdMarcaMotor = New Eniac.Controles.TextBox()
      Me.SuspendLayout()
      '
      'btnAceptar
      '
      Me.btnAceptar.Location = New System.Drawing.Point(195, 84)
      Me.btnAceptar.TabIndex = 5
      '
      'btnCancelar
      '
      Me.btnCancelar.Location = New System.Drawing.Point(291, 84)
      Me.btnCancelar.TabIndex = 6
      '
      'lblNombre
      '
      Me.lblNombre.AutoSize = True
      Me.lblNombre.Location = New System.Drawing.Point(28, 45)
      Me.lblNombre.Name = "lblNombre"
      Me.lblNombre.Size = New System.Drawing.Size(44, 13)
      Me.lblNombre.TabIndex = 3
      Me.lblNombre.Text = "Nombre"
      '
      'txtMarcaMotor
      '
      Me.txtMarcaMotor.BindearPropiedadControl = "Text"
      Me.txtMarcaMotor.BindearPropiedadEntidad = "NombreMarcaMotor"
      Me.txtMarcaMotor.ForeColorFocus = System.Drawing.Color.Red
      Me.txtMarcaMotor.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtMarcaMotor.Formato = ""
      Me.txtMarcaMotor.IsDecimal = False
      Me.txtMarcaMotor.IsNumber = False
      Me.txtMarcaMotor.IsPK = False
      Me.txtMarcaMotor.IsRequired = True
      Me.txtMarcaMotor.Key = ""
      Me.txtMarcaMotor.LabelAsoc = Me.lblNombre
      Me.txtMarcaMotor.Location = New System.Drawing.Point(106, 41)
      Me.txtMarcaMotor.MaxLength = 30
      Me.txtMarcaMotor.Name = "txtMarcaMotor"
      Me.txtMarcaMotor.Size = New System.Drawing.Size(275, 20)
      Me.txtMarcaMotor.TabIndex = 2
      '
      'lblId
      '
      Me.lblId.AutoSize = True
      Me.lblId.Location = New System.Drawing.Point(28, 17)
      Me.lblId.Name = "lblId"
      Me.lblId.Size = New System.Drawing.Size(40, 13)
      Me.lblId.TabIndex = 1
      Me.lblId.Text = "Código"
      '
      'txtIdMarcaMotor
      '
      Me.txtIdMarcaMotor.BindearPropiedadControl = "Text"
      Me.txtIdMarcaMotor.BindearPropiedadEntidad = "IdMarcaMotor"
      Me.txtIdMarcaMotor.ForeColorFocus = System.Drawing.Color.Red
      Me.txtIdMarcaMotor.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtIdMarcaMotor.Formato = ""
      Me.txtIdMarcaMotor.IsDecimal = False
      Me.txtIdMarcaMotor.IsNumber = True
      Me.txtIdMarcaMotor.IsPK = True
      Me.txtIdMarcaMotor.IsRequired = True
      Me.txtIdMarcaMotor.Key = ""
      Me.txtIdMarcaMotor.LabelAsoc = Me.lblId
      Me.txtIdMarcaMotor.Location = New System.Drawing.Point(106, 13)
      Me.txtIdMarcaMotor.MaxLength = 4
      Me.txtIdMarcaMotor.Name = "txtIdMarcaMotor"
      Me.txtIdMarcaMotor.Size = New System.Drawing.Size(55, 20)
      Me.txtIdMarcaMotor.TabIndex = 0
      Me.txtIdMarcaMotor.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'MarcasMotoresDetalle
      '
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.ClientSize = New System.Drawing.Size(390, 131)
      Me.Controls.Add(Me.lblNombre)
      Me.Controls.Add(Me.txtMarcaMotor)
      Me.Controls.Add(Me.lblId)
      Me.Controls.Add(Me.txtIdMarcaMotor)
      Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
      Me.Name = "MarcasMotoresDetalle"
      Me.Text = "Marca de Motor"
      Me.Controls.SetChildIndex(Me.btnCancelar, 0)
      Me.Controls.SetChildIndex(Me.btnAceptar, 0)
      Me.Controls.SetChildIndex(Me.txtIdMarcaMotor, 0)
      Me.Controls.SetChildIndex(Me.lblId, 0)
      Me.Controls.SetChildIndex(Me.txtMarcaMotor, 0)
      Me.Controls.SetChildIndex(Me.lblNombre, 0)
      Me.ResumeLayout(False)
      Me.PerformLayout()

   End Sub
   Friend WithEvents lblNombre As Eniac.Controles.Label
   Friend WithEvents txtMarcaMotor As Eniac.Controles.TextBox
   Friend WithEvents lblId As Eniac.Controles.Label
   Friend WithEvents txtIdMarcaMotor As Eniac.Controles.TextBox

End Class
