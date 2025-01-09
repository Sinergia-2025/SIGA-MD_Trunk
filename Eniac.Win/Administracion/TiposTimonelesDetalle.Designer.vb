<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class TiposTimonelesDetalle
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
      Me.lblNombreTipoTimonel = New Eniac.Controles.Label()
      Me.txtDescripcion = New Eniac.Controles.TextBox()
      Me.lblIdTipoTimonel = New Eniac.Controles.Label()
      Me.txtIdTipoTimonel = New Eniac.Controles.TextBox()
      Me.lblPreFijo = New Eniac.Controles.Label()
      Me.txtPreFijo = New Eniac.Controles.TextBox()
      Me.SuspendLayout()
      '
      'btnAceptar
      '
      Me.btnAceptar.Location = New System.Drawing.Point(230, 106)
      Me.btnAceptar.TabIndex = 4
      '
      'btnCancelar
      '
      Me.btnCancelar.Location = New System.Drawing.Point(323, 106)
      Me.btnCancelar.TabIndex = 5
      '
      'lblNombreTipoTimonel
      '
      Me.lblNombreTipoTimonel.AutoSize = True
      Me.lblNombreTipoTimonel.Location = New System.Drawing.Point(23, 45)
      Me.lblNombreTipoTimonel.Name = "lblNombreTipoTimonel"
      Me.lblNombreTipoTimonel.Size = New System.Drawing.Size(63, 13)
      Me.lblNombreTipoTimonel.TabIndex = 3
      Me.lblNombreTipoTimonel.Text = "Descripción"
      '
      'txtDescripcion
      '
      Me.txtDescripcion.BindearPropiedadControl = "Text"
      Me.txtDescripcion.BindearPropiedadEntidad = "NombreTipoTimonel"
      Me.txtDescripcion.ForeColorFocus = System.Drawing.Color.Red
      Me.txtDescripcion.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtDescripcion.Formato = ""
      Me.txtDescripcion.IsDecimal = False
      Me.txtDescripcion.IsNumber = False
      Me.txtDescripcion.IsPK = False
      Me.txtDescripcion.IsRequired = True
      Me.txtDescripcion.Key = ""
      Me.txtDescripcion.LabelAsoc = Me.lblNombreTipoTimonel
      Me.txtDescripcion.Location = New System.Drawing.Point(121, 41)
      Me.txtDescripcion.MaxLength = 30
      Me.txtDescripcion.Name = "txtDescripcion"
      Me.txtDescripcion.Size = New System.Drawing.Size(263, 20)
      Me.txtDescripcion.TabIndex = 2
      '
      'lblIdTipoTimonel
      '
      Me.lblIdTipoTimonel.AutoSize = True
      Me.lblIdTipoTimonel.Location = New System.Drawing.Point(23, 19)
      Me.lblIdTipoTimonel.Name = "lblIdTipoTimonel"
      Me.lblIdTipoTimonel.Size = New System.Drawing.Size(40, 13)
      Me.lblIdTipoTimonel.TabIndex = 1
      Me.lblIdTipoTimonel.Text = "Codigo"
      '
      'txtIdTipoTimonel
      '
      Me.txtIdTipoTimonel.BindearPropiedadControl = "Text"
      Me.txtIdTipoTimonel.BindearPropiedadEntidad = "IdTipoTimonel"
      Me.txtIdTipoTimonel.ForeColorFocus = System.Drawing.Color.Red
      Me.txtIdTipoTimonel.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtIdTipoTimonel.Formato = ""
      Me.txtIdTipoTimonel.IsDecimal = False
      Me.txtIdTipoTimonel.IsNumber = False
      Me.txtIdTipoTimonel.IsPK = True
      Me.txtIdTipoTimonel.IsRequired = True
      Me.txtIdTipoTimonel.Key = ""
      Me.txtIdTipoTimonel.LabelAsoc = Me.lblIdTipoTimonel
      Me.txtIdTipoTimonel.Location = New System.Drawing.Point(121, 15)
      Me.txtIdTipoTimonel.MaxLength = 5
      Me.txtIdTipoTimonel.Name = "txtIdTipoTimonel"
      Me.txtIdTipoTimonel.Size = New System.Drawing.Size(59, 20)
      Me.txtIdTipoTimonel.TabIndex = 0
      '
      'lblPreFijo
      '
      Me.lblPreFijo.AutoSize = True
      Me.lblPreFijo.Location = New System.Drawing.Point(23, 71)
      Me.lblPreFijo.Name = "lblPreFijo"
      Me.lblPreFijo.Size = New System.Drawing.Size(73, 13)
      Me.lblPreFijo.TabIndex = 7
      Me.lblPreFijo.Text = "PreFijo Carnet"
      '
      'txtPreFijo
      '
      Me.txtPreFijo.BindearPropiedadControl = "Text"
      Me.txtPreFijo.BindearPropiedadEntidad = "PreFijo"
      Me.txtPreFijo.ForeColorFocus = System.Drawing.Color.Red
      Me.txtPreFijo.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtPreFijo.Formato = ""
      Me.txtPreFijo.IsDecimal = False
      Me.txtPreFijo.IsNumber = False
      Me.txtPreFijo.IsPK = False
      Me.txtPreFijo.IsRequired = True
      Me.txtPreFijo.Key = ""
      Me.txtPreFijo.LabelAsoc = Me.lblPreFijo
      Me.txtPreFijo.Location = New System.Drawing.Point(121, 67)
      Me.txtPreFijo.MaxLength = 5
      Me.txtPreFijo.Name = "txtPreFijo"
      Me.txtPreFijo.Size = New System.Drawing.Size(59, 20)
      Me.txtPreFijo.TabIndex = 6
      '
      'TiposTimonelesDetalle
      '
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.ClientSize = New System.Drawing.Size(415, 142)
      Me.Controls.Add(Me.lblPreFijo)
      Me.Controls.Add(Me.txtPreFijo)
      Me.Controls.Add(Me.lblNombreTipoTimonel)
      Me.Controls.Add(Me.txtDescripcion)
      Me.Controls.Add(Me.lblIdTipoTimonel)
      Me.Controls.Add(Me.txtIdTipoTimonel)
      Me.Name = "TiposTimonelesDetalle"
      Me.Text = "Tipo de Timonel"
      Me.Controls.SetChildIndex(Me.btnCancelar, 0)
      Me.Controls.SetChildIndex(Me.btnAceptar, 0)
      Me.Controls.SetChildIndex(Me.txtIdTipoTimonel, 0)
      Me.Controls.SetChildIndex(Me.lblIdTipoTimonel, 0)
      Me.Controls.SetChildIndex(Me.txtDescripcion, 0)
      Me.Controls.SetChildIndex(Me.lblNombreTipoTimonel, 0)
      Me.Controls.SetChildIndex(Me.txtPreFijo, 0)
      Me.Controls.SetChildIndex(Me.lblPreFijo, 0)
      Me.ResumeLayout(False)
      Me.PerformLayout()

   End Sub
   Friend WithEvents lblNombreTipoTimonel As Eniac.Controles.Label
   Friend WithEvents txtDescripcion As Eniac.Controles.TextBox
   Friend WithEvents lblIdTipoTimonel As Eniac.Controles.Label
   Friend WithEvents txtIdTipoTimonel As Eniac.Controles.TextBox
   Friend WithEvents lblPreFijo As Eniac.Controles.Label
   Friend WithEvents txtPreFijo As Eniac.Controles.TextBox
End Class
