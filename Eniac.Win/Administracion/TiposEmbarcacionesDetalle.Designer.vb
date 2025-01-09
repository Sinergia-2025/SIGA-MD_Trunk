<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class TiposEmbarcacionesDetalle
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
      Me.lblNombreTipoEmbarcacion = New Eniac.Controles.Label()
      Me.txtDescripcion = New Eniac.Controles.TextBox()
      Me.lblIdTipoEmbarcacion = New Eniac.Controles.Label()
      Me.txtIdTipoEmbarcacion = New Eniac.Controles.TextBox()
      Me.SuspendLayout()
      '
      'btnAceptar
      '
      Me.btnAceptar.Location = New System.Drawing.Point(223, 74)
      Me.btnAceptar.TabIndex = 5
      '
      'btnCancelar
      '
      Me.btnCancelar.Location = New System.Drawing.Point(316, 74)
      Me.btnCancelar.TabIndex = 6
      '
      'lblNombreTipoEmbarcacion
      '
      Me.lblNombreTipoEmbarcacion.AutoSize = True
      Me.lblNombreTipoEmbarcacion.Location = New System.Drawing.Point(27, 46)
      Me.lblNombreTipoEmbarcacion.Name = "lblNombreTipoEmbarcacion"
      Me.lblNombreTipoEmbarcacion.Size = New System.Drawing.Size(63, 13)
      Me.lblNombreTipoEmbarcacion.TabIndex = 3
      Me.lblNombreTipoEmbarcacion.Text = "Descripción"
      '
      'txtDescripcion
      '
      Me.txtDescripcion.BindearPropiedadControl = "Text"
      Me.txtDescripcion.BindearPropiedadEntidad = "NombreTipoEmbarcacion"
      Me.txtDescripcion.ForeColorFocus = System.Drawing.Color.Red
      Me.txtDescripcion.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtDescripcion.Formato = ""
      Me.txtDescripcion.IsDecimal = False
      Me.txtDescripcion.IsNumber = False
      Me.txtDescripcion.IsPK = False
      Me.txtDescripcion.IsRequired = True
      Me.txtDescripcion.Key = ""
      Me.txtDescripcion.LabelAsoc = Me.lblNombreTipoEmbarcacion
      Me.txtDescripcion.Location = New System.Drawing.Point(110, 42)
      Me.txtDescripcion.MaxLength = 30
      Me.txtDescripcion.Name = "txtDescripcion"
      Me.txtDescripcion.Size = New System.Drawing.Size(203, 20)
      Me.txtDescripcion.TabIndex = 2
      '
      'lblIdTipoEmbarcacion
      '
      Me.lblIdTipoEmbarcacion.AutoSize = True
      Me.lblIdTipoEmbarcacion.Location = New System.Drawing.Point(27, 18)
      Me.lblIdTipoEmbarcacion.Name = "lblIdTipoEmbarcacion"
      Me.lblIdTipoEmbarcacion.Size = New System.Drawing.Size(40, 13)
      Me.lblIdTipoEmbarcacion.TabIndex = 1
      Me.lblIdTipoEmbarcacion.Text = "Codigo"
      '
      'txtIdTipoEmbarcacion
      '
      Me.txtIdTipoEmbarcacion.BindearPropiedadControl = "Text"
      Me.txtIdTipoEmbarcacion.BindearPropiedadEntidad = "IdTipoEmbarcacion"
      Me.txtIdTipoEmbarcacion.ForeColorFocus = System.Drawing.Color.Red
      Me.txtIdTipoEmbarcacion.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtIdTipoEmbarcacion.Formato = ""
      Me.txtIdTipoEmbarcacion.IsDecimal = False
      Me.txtIdTipoEmbarcacion.IsNumber = True
      Me.txtIdTipoEmbarcacion.IsPK = True
      Me.txtIdTipoEmbarcacion.IsRequired = True
      Me.txtIdTipoEmbarcacion.Key = ""
      Me.txtIdTipoEmbarcacion.LabelAsoc = Me.lblIdTipoEmbarcacion
      Me.txtIdTipoEmbarcacion.Location = New System.Drawing.Point(110, 14)
      Me.txtIdTipoEmbarcacion.MaxLength = 2
      Me.txtIdTipoEmbarcacion.Name = "txtIdTipoEmbarcacion"
      Me.txtIdTipoEmbarcacion.Size = New System.Drawing.Size(30, 20)
      Me.txtIdTipoEmbarcacion.TabIndex = 0
      '
      'TiposEmbarcacionesDetalle
      '
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.ClientSize = New System.Drawing.Size(408, 110)
      Me.Controls.Add(Me.lblNombreTipoEmbarcacion)
      Me.Controls.Add(Me.txtDescripcion)
      Me.Controls.Add(Me.lblIdTipoEmbarcacion)
      Me.Controls.Add(Me.txtIdTipoEmbarcacion)
      Me.Name = "TiposEmbarcacionesDetalle"
      Me.Text = "Tipo de Embarcación"
      Me.Controls.SetChildIndex(Me.btnCancelar, 0)
      Me.Controls.SetChildIndex(Me.btnAceptar, 0)
      Me.Controls.SetChildIndex(Me.txtIdTipoEmbarcacion, 0)
      Me.Controls.SetChildIndex(Me.lblIdTipoEmbarcacion, 0)
      Me.Controls.SetChildIndex(Me.txtDescripcion, 0)
      Me.Controls.SetChildIndex(Me.lblNombreTipoEmbarcacion, 0)
      Me.ResumeLayout(False)
      Me.PerformLayout()

   End Sub
   Friend WithEvents lblNombreTipoEmbarcacion As Eniac.Controles.Label
   Friend WithEvents txtDescripcion As Eniac.Controles.TextBox
   Friend WithEvents lblIdTipoEmbarcacion As Eniac.Controles.Label
   Friend WithEvents txtIdTipoEmbarcacion As Eniac.Controles.TextBox
End Class
