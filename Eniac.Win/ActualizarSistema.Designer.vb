<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ActualizarSistema
   Inherits BaseForm

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
      Me.txtClave = New Eniac.Controles.TextBox()
      Me.btnActualizarClave = New Eniac.Controles.Button()
      Me.lblClave = New Eniac.Controles.Label()
      Me.lblClaveActual = New Eniac.Controles.Label()
      Me.txtClaveActual = New Eniac.Controles.TextBox()
      Me.btnCopiarAlPortapapeles = New Eniac.Controles.Button()
      Me.SuspendLayout()
      '
      'txtClave
      '
      Me.txtClave.BindearPropiedadControl = Nothing
      Me.txtClave.BindearPropiedadEntidad = Nothing
      Me.txtClave.ForeColorFocus = System.Drawing.Color.Red
      Me.txtClave.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtClave.Formato = ""
      Me.txtClave.IsDecimal = False
      Me.txtClave.IsNumber = False
      Me.txtClave.IsPK = False
      Me.txtClave.IsRequired = False
      Me.txtClave.Key = ""
      Me.txtClave.LabelAsoc = Nothing
      Me.txtClave.Location = New System.Drawing.Point(12, 32)
      Me.txtClave.Name = "txtClave"
      Me.txtClave.Size = New System.Drawing.Size(439, 20)
      Me.txtClave.TabIndex = 0
      '
      'btnActualizarClave
      '
      Me.btnActualizarClave.Location = New System.Drawing.Point(457, 13)
      Me.btnActualizarClave.Name = "btnActualizarClave"
      Me.btnActualizarClave.Size = New System.Drawing.Size(148, 56)
      Me.btnActualizarClave.TabIndex = 1
      Me.btnActualizarClave.Text = "Actualizar clave"
      Me.btnActualizarClave.UseVisualStyleBackColor = True
      '
      'lblClave
      '
      Me.lblClave.AutoSize = True
      Me.lblClave.LabelAsoc = Nothing
      Me.lblClave.Location = New System.Drawing.Point(9, 16)
      Me.lblClave.Name = "lblClave"
      Me.lblClave.Size = New System.Drawing.Size(179, 13)
      Me.lblClave.TabIndex = 2
      Me.lblClave.Text = "Coloque la nueva clave del Sistema."
      '
      'lblClaveActual
      '
      Me.lblClaveActual.AutoSize = True
      Me.lblClaveActual.LabelAsoc = Nothing
      Me.lblClaveActual.Location = New System.Drawing.Point(9, 62)
      Me.lblClaveActual.Name = "lblClaveActual"
      Me.lblClaveActual.Size = New System.Drawing.Size(66, 13)
      Me.lblClaveActual.TabIndex = 4
      Me.lblClaveActual.Text = "Clave actual"
      '
      'txtClaveActual
      '
      Me.txtClaveActual.BindearPropiedadControl = Nothing
      Me.txtClaveActual.BindearPropiedadEntidad = Nothing
      Me.txtClaveActual.ForeColorFocus = System.Drawing.Color.Red
      Me.txtClaveActual.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtClaveActual.Formato = ""
      Me.txtClaveActual.IsDecimal = False
      Me.txtClaveActual.IsNumber = False
      Me.txtClaveActual.IsPK = False
      Me.txtClaveActual.IsRequired = False
      Me.txtClaveActual.Key = ""
      Me.txtClaveActual.LabelAsoc = Nothing
      Me.txtClaveActual.Location = New System.Drawing.Point(12, 78)
      Me.txtClaveActual.Name = "txtClaveActual"
      Me.txtClaveActual.ReadOnly = True
      Me.txtClaveActual.Size = New System.Drawing.Size(439, 20)
      Me.txtClaveActual.TabIndex = 3
      '
      'btnCopiarAlPortapapeles
      '
      Me.btnCopiarAlPortapapeles.Location = New System.Drawing.Point(457, 77)
      Me.btnCopiarAlPortapapeles.Name = "btnCopiarAlPortapapeles"
      Me.btnCopiarAlPortapapeles.Size = New System.Drawing.Size(148, 20)
      Me.btnCopiarAlPortapapeles.TabIndex = 5
      Me.btnCopiarAlPortapapeles.Text = "Copiar al portapeles"
      Me.btnCopiarAlPortapapeles.UseVisualStyleBackColor = True
      '
      'ActualizarSistema
      '
      Me.AcceptButton = Me.btnActualizarClave
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.ClientSize = New System.Drawing.Size(617, 101)
      Me.Controls.Add(Me.btnCopiarAlPortapapeles)
      Me.Controls.Add(Me.lblClaveActual)
      Me.Controls.Add(Me.txtClaveActual)
      Me.Controls.Add(Me.lblClave)
      Me.Controls.Add(Me.btnActualizarClave)
      Me.Controls.Add(Me.txtClave)
      Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
      Me.Name = "ActualizarSistema"
      Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
      Me.Text = "Actualización de la clave del Sistema"
      Me.ResumeLayout(False)
      Me.PerformLayout()

   End Sub
   Friend WithEvents txtClave As Eniac.Controles.TextBox
   Friend WithEvents btnActualizarClave As Eniac.Controles.Button
   Friend WithEvents lblClave As Eniac.Controles.Label
   Friend WithEvents lblClaveActual As Eniac.Controles.Label
   Friend WithEvents btnCopiarAlPortapapeles As Eniac.Controles.Button
   Private WithEvents txtClaveActual As Eniac.Controles.TextBox
End Class
