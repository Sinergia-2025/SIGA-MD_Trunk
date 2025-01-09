<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CorreoPrueba
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
      Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(CorreoPrueba))
      Me.Label1 = New System.Windows.Forms.Label()
      Me.txtCorreoDePrueba = New System.Windows.Forms.TextBox()
      Me.btnCancelar = New Eniac.Controles.Button()
      Me.btnAceptar = New Eniac.Controles.Button()
      Me.SuspendLayout()
      '
      'Label1
      '
      Me.Label1.AutoSize = True
      Me.Label1.Location = New System.Drawing.Point(12, 26)
      Me.Label1.Name = "Label1"
      Me.Label1.Size = New System.Drawing.Size(38, 13)
      Me.Label1.TabIndex = 0
      Me.Label1.Text = "Correo"
      '
      'txtCorreoDePrueba
      '
      Me.txtCorreoDePrueba.Location = New System.Drawing.Point(56, 23)
      Me.txtCorreoDePrueba.Name = "txtCorreoDePrueba"
      Me.txtCorreoDePrueba.Size = New System.Drawing.Size(347, 20)
      Me.txtCorreoDePrueba.TabIndex = 1
      '
      'btnCancelar
      '
      Me.btnCancelar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel
      Me.btnCancelar.Image = Global.Eniac.Win.My.Resources.Resources.delete_24
      Me.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
      Me.btnCancelar.Location = New System.Drawing.Point(318, 58)
      Me.btnCancelar.Name = "btnCancelar"
      Me.btnCancelar.Size = New System.Drawing.Size(85, 30)
      Me.btnCancelar.TabIndex = 23
      Me.btnCancelar.Text = "&Cancelar"
      Me.btnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      Me.btnCancelar.UseVisualStyleBackColor = True
      '
      'btnAceptar
      '
      Me.btnAceptar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.btnAceptar.Image = Global.Eniac.Win.My.Resources.Resources.ok_24
      Me.btnAceptar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
      Me.btnAceptar.Location = New System.Drawing.Point(227, 58)
      Me.btnAceptar.Name = "btnAceptar"
      Me.btnAceptar.Size = New System.Drawing.Size(85, 30)
      Me.btnAceptar.TabIndex = 22
      Me.btnAceptar.Text = "&Aceptar"
      Me.btnAceptar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      Me.btnAceptar.UseVisualStyleBackColor = True
      '
      'CorreoPrueba
      '
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.ClientSize = New System.Drawing.Size(412, 100)
      Me.Controls.Add(Me.btnCancelar)
      Me.Controls.Add(Me.btnAceptar)
      Me.Controls.Add(Me.txtCorreoDePrueba)
      Me.Controls.Add(Me.Label1)
      Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
      Me.Name = "CorreoPrueba"
      Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
      Me.Text = "Correo de Prueba"
      Me.ResumeLayout(False)
      Me.PerformLayout()

   End Sub
   Friend WithEvents Label1 As System.Windows.Forms.Label
   Friend WithEvents txtCorreoDePrueba As System.Windows.Forms.TextBox
   Friend WithEvents btnCancelar As Eniac.Controles.Button
   Friend WithEvents btnAceptar As Eniac.Controles.Button
End Class
