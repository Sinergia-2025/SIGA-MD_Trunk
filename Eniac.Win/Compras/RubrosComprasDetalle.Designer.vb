<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class RubrosComprasDetalle
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
      Me.lblNombreRubro = New Eniac.Controles.Label()
      Me.txtNombreRubro = New Eniac.Controles.TextBox()
      Me.lblIdRubro = New Eniac.Controles.Label()
      Me.txtIdRubro = New Eniac.Controles.TextBox()
      Me.SuspendLayout()
      '
      'btnAceptar
      '
      Me.btnAceptar.Location = New System.Drawing.Point(239, 71)
      Me.btnAceptar.TabIndex = 7
      '
      'btnCancelar
      '
      Me.btnCancelar.Location = New System.Drawing.Point(325, 71)
      Me.btnCancelar.TabIndex = 8
      '
      'lblNombreRubro
      '
      Me.lblNombreRubro.AutoSize = True
      Me.lblNombreRubro.Location = New System.Drawing.Point(4, 44)
      Me.lblNombreRubro.Name = "lblNombreRubro"
      Me.lblNombreRubro.Size = New System.Drawing.Size(44, 13)
      Me.lblNombreRubro.TabIndex = 3
      Me.lblNombreRubro.Text = "Nombre"
      '
      'txtNombreRubro
      '
      Me.txtNombreRubro.BindearPropiedadControl = "Text"
      Me.txtNombreRubro.BindearPropiedadEntidad = "NombreRubro"
      Me.txtNombreRubro.ForeColorFocus = System.Drawing.Color.Red
      Me.txtNombreRubro.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtNombreRubro.Formato = ""
      Me.txtNombreRubro.IsDecimal = False
      Me.txtNombreRubro.IsNumber = False
      Me.txtNombreRubro.IsPK = False
      Me.txtNombreRubro.IsRequired = True
      Me.txtNombreRubro.Key = ""
      Me.txtNombreRubro.LabelAsoc = Me.lblNombreRubro
      Me.txtNombreRubro.Location = New System.Drawing.Point(53, 40)
      Me.txtNombreRubro.MaxLength = 50
      Me.txtNombreRubro.Name = "txtNombreRubro"
      Me.txtNombreRubro.Size = New System.Drawing.Size(351, 20)
      Me.txtNombreRubro.TabIndex = 2
      '
      'lblIdRubro
      '
      Me.lblIdRubro.AutoSize = True
      Me.lblIdRubro.Location = New System.Drawing.Point(4, 16)
      Me.lblIdRubro.Name = "lblIdRubro"
      Me.lblIdRubro.Size = New System.Drawing.Size(40, 13)
      Me.lblIdRubro.TabIndex = 1
      Me.lblIdRubro.Text = "Código"
      '
      'txtIdRubro
      '
      Me.txtIdRubro.BindearPropiedadControl = "Text"
      Me.txtIdRubro.BindearPropiedadEntidad = "IdRubro"
      Me.txtIdRubro.ForeColorFocus = System.Drawing.Color.Red
      Me.txtIdRubro.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtIdRubro.Formato = ""
      Me.txtIdRubro.IsDecimal = False
      Me.txtIdRubro.IsNumber = True
      Me.txtIdRubro.IsPK = True
      Me.txtIdRubro.IsRequired = True
      Me.txtIdRubro.Key = ""
      Me.txtIdRubro.LabelAsoc = Me.lblIdRubro
      Me.txtIdRubro.Location = New System.Drawing.Point(53, 12)
      Me.txtIdRubro.MaxLength = 5
      Me.txtIdRubro.Name = "txtIdRubro"
      Me.txtIdRubro.Size = New System.Drawing.Size(60, 20)
      Me.txtIdRubro.TabIndex = 0
      Me.txtIdRubro.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'RubrosComprasDetalle
      '
      Me.AcceptButton = Nothing
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.ClientSize = New System.Drawing.Size(417, 113)
      Me.Controls.Add(Me.lblNombreRubro)
      Me.Controls.Add(Me.txtNombreRubro)
      Me.Controls.Add(Me.lblIdRubro)
      Me.Controls.Add(Me.txtIdRubro)
      Me.Name = "RubrosComprasDetalle"
      Me.Text = "Rubro de Compra"
      Me.Controls.SetChildIndex(Me.btnCancelar, 0)
      Me.Controls.SetChildIndex(Me.btnAceptar, 0)
      Me.Controls.SetChildIndex(Me.txtIdRubro, 0)
      Me.Controls.SetChildIndex(Me.lblIdRubro, 0)
      Me.Controls.SetChildIndex(Me.txtNombreRubro, 0)
      Me.Controls.SetChildIndex(Me.lblNombreRubro, 0)
      Me.ResumeLayout(False)
      Me.PerformLayout()

   End Sub
   Friend WithEvents lblNombreRubro As Eniac.Controles.Label
   Friend WithEvents txtNombreRubro As Eniac.Controles.TextBox
   Friend WithEvents lblIdRubro As Eniac.Controles.Label
   Friend WithEvents txtIdRubro As Eniac.Controles.TextBox
End Class
