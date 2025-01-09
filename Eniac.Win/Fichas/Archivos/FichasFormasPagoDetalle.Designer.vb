<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FichasFormasPagoDetalle
   Inherits Win.BaseDetalle

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
      Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FichasFormasPagoDetalle))
      Me.lblDias = New Eniac.Controles.Label
      Me.lblDescripcion = New Eniac.Controles.Label
      Me.lblId = New Eniac.Controles.Label
      Me.txtId = New Eniac.Controles.TextBox
      Me.txtDescripcion = New Eniac.Controles.TextBox
      Me.txtDias = New Eniac.Controles.TextBox
      Me.SuspendLayout()
      '
      'btnAceptar
      '
      Me.btnAceptar.Location = New System.Drawing.Point(141, 109)
      '
      'btnCancelar
      '
      Me.btnCancelar.Location = New System.Drawing.Point(227, 109)
      Me.btnCancelar.TabIndex = 4
      '
      'lblDias
      '
      Me.lblDias.AutoSize = True
      Me.lblDias.Location = New System.Drawing.Point(20, 75)
      Me.lblDias.Name = "lblDias"
      Me.lblDias.Size = New System.Drawing.Size(30, 13)
      Me.lblDias.TabIndex = 7
      Me.lblDias.Text = "Días"
      '
      'lblDescripcion
      '
      Me.lblDescripcion.AutoSize = True
      Me.lblDescripcion.Location = New System.Drawing.Point(20, 49)
      Me.lblDescripcion.Name = "lblDescripcion"
      Me.lblDescripcion.Size = New System.Drawing.Size(63, 13)
      Me.lblDescripcion.TabIndex = 6
      Me.lblDescripcion.Text = "Descripción"
      '
      'lblId
      '
      Me.lblId.AutoSize = True
      Me.lblId.Location = New System.Drawing.Point(20, 23)
      Me.lblId.Name = "lblId"
      Me.lblId.Size = New System.Drawing.Size(16, 13)
      Me.lblId.TabIndex = 5
      Me.lblId.Text = "Id"
      '
      'txtId
      '
      Me.txtId.BindearPropiedadControl = "Text"
      Me.txtId.BindearPropiedadEntidad = "IdFormasPago"
      Me.txtId.ForeColorFocus = System.Drawing.Color.Red
      Me.txtId.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtId.Formato = ""
      Me.txtId.IsDecimal = False
      Me.txtId.IsNumber = True
      Me.txtId.IsPK = True
      Me.txtId.IsRequired = True
      Me.txtId.Key = ""
      Me.txtId.LabelAsoc = Me.lblId
      Me.txtId.Location = New System.Drawing.Point(90, 16)
      Me.txtId.MaxLength = 6
      Me.txtId.Name = "txtId"
      Me.txtId.Size = New System.Drawing.Size(59, 20)
      Me.txtId.TabIndex = 0
      Me.txtId.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'txtDescripcion
      '
      Me.txtDescripcion.BindearPropiedadControl = "Text"
      Me.txtDescripcion.BindearPropiedadEntidad = "DescripcionFormasPago"
      Me.txtDescripcion.ForeColorFocus = System.Drawing.Color.Red
      Me.txtDescripcion.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtDescripcion.Formato = ""
      Me.txtDescripcion.IsDecimal = False
      Me.txtDescripcion.IsNumber = False
      Me.txtDescripcion.IsPK = False
      Me.txtDescripcion.IsRequired = False
      Me.txtDescripcion.Key = ""
      Me.txtDescripcion.LabelAsoc = Me.lblDescripcion
      Me.txtDescripcion.Location = New System.Drawing.Point(90, 42)
      Me.txtDescripcion.MaxLength = 50
      Me.txtDescripcion.Name = "txtDescripcion"
      Me.txtDescripcion.Size = New System.Drawing.Size(219, 20)
      Me.txtDescripcion.TabIndex = 1
      '
      'txtDias
      '
      Me.txtDias.BindearPropiedadControl = "Text"
      Me.txtDias.BindearPropiedadEntidad = "Dias"
      Me.txtDias.ForeColorFocus = System.Drawing.Color.Red
      Me.txtDias.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtDias.Formato = ""
      Me.txtDias.IsDecimal = False
      Me.txtDias.IsNumber = True
      Me.txtDias.IsPK = False
      Me.txtDias.IsRequired = False
      Me.txtDias.Key = ""
      Me.txtDias.LabelAsoc = Me.lblDias
      Me.txtDias.Location = New System.Drawing.Point(90, 68)
      Me.txtDias.MaxLength = 5
      Me.txtDias.Name = "txtDias"
      Me.txtDias.Size = New System.Drawing.Size(59, 20)
      Me.txtDias.TabIndex = 2
      Me.txtDias.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'FormasPagoDetalle
      '
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.ClientSize = New System.Drawing.Size(316, 144)
      Me.Controls.Add(Me.txtDias)
      Me.Controls.Add(Me.txtDescripcion)
      Me.Controls.Add(Me.txtId)
      Me.Controls.Add(Me.lblDias)
      Me.Controls.Add(Me.lblDescripcion)
      Me.Controls.Add(Me.lblId)
      Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
      Me.Name = "FichasFormasPagoDetalle"
      Me.Text = "Forma de pago"
      Me.Controls.SetChildIndex(Me.btnCancelar, 0)
      Me.Controls.SetChildIndex(Me.btnAceptar, 0)
      Me.Controls.SetChildIndex(Me.lblId, 0)
      Me.Controls.SetChildIndex(Me.lblDescripcion, 0)
      Me.Controls.SetChildIndex(Me.lblDias, 0)
      Me.Controls.SetChildIndex(Me.txtId, 0)
      Me.Controls.SetChildIndex(Me.txtDescripcion, 0)
      Me.Controls.SetChildIndex(Me.txtDias, 0)
      Me.ResumeLayout(False)
      Me.PerformLayout()

   End Sub
   Friend WithEvents lblDias As Eniac.Controles.Label
   Friend WithEvents lblDescripcion As Eniac.Controles.Label
   Friend WithEvents lblId As Eniac.Controles.Label
   Friend WithEvents txtId As Eniac.Controles.TextBox
   Friend WithEvents txtDescripcion As Eniac.Controles.TextBox
   Friend WithEvents txtDias As Eniac.Controles.TextBox

End Class
