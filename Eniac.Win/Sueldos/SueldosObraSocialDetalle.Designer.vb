<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SueldosObraSocialDetalle
    Inherits BaseDetalle

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
      Me.txtNombreObraSocial = New Eniac.Controles.TextBox
      Me.lblNombre = New Eniac.Controles.Label
      Me.txtIdObraSocial = New Eniac.Controles.TextBox
      Me.lblIdObraSocial = New Eniac.Controles.Label
      Me.SuspendLayout()
      '
      'btnAceptar
      '
      Me.btnAceptar.Location = New System.Drawing.Point(172, 97)
      Me.btnAceptar.TabIndex = 4
      '
      'btnCancelar
      '
      Me.btnCancelar.Location = New System.Drawing.Point(258, 97)
      Me.btnCancelar.TabIndex = 5
      '
      'txtNombreObraSocial
      '
      Me.txtNombreObraSocial.BindearPropiedadControl = "Text"
      Me.txtNombreObraSocial.BindearPropiedadEntidad = "NombreObraSocial"
      Me.txtNombreObraSocial.ForeColorFocus = System.Drawing.Color.Red
      Me.txtNombreObraSocial.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtNombreObraSocial.Formato = ""
      Me.txtNombreObraSocial.IsDecimal = False
      Me.txtNombreObraSocial.IsNumber = False
      Me.txtNombreObraSocial.IsPK = False
      Me.txtNombreObraSocial.IsRequired = True
      Me.txtNombreObraSocial.Key = ""
      Me.txtNombreObraSocial.LabelAsoc = Me.lblNombre
      Me.txtNombreObraSocial.Location = New System.Drawing.Point(77, 48)
      Me.txtNombreObraSocial.MaxLength = 25
      Me.txtNombreObraSocial.Name = "txtNombreObraSocial"
      Me.txtNombreObraSocial.Size = New System.Drawing.Size(262, 20)
      Me.txtNombreObraSocial.TabIndex = 3
      '
      'lblNombre
      '
      Me.lblNombre.AutoSize = True
      Me.lblNombre.Location = New System.Drawing.Point(17, 52)
      Me.lblNombre.Name = "lblNombre"
      Me.lblNombre.Size = New System.Drawing.Size(44, 13)
      Me.lblNombre.TabIndex = 2
      Me.lblNombre.Text = "Nombre"
      '
      'txtIdObraSocial
      '
      Me.txtIdObraSocial.BindearPropiedadControl = "Text"
      Me.txtIdObraSocial.BindearPropiedadEntidad = "IdObraSocial"
      Me.txtIdObraSocial.ForeColorFocus = System.Drawing.Color.Red
      Me.txtIdObraSocial.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtIdObraSocial.Formato = ""
      Me.txtIdObraSocial.IsDecimal = False
      Me.txtIdObraSocial.IsNumber = True
      Me.txtIdObraSocial.IsPK = True
      Me.txtIdObraSocial.IsRequired = True
      Me.txtIdObraSocial.Key = ""
      Me.txtIdObraSocial.LabelAsoc = Me.lblIdObraSocial
      Me.txtIdObraSocial.Location = New System.Drawing.Point(77, 23)
      Me.txtIdObraSocial.MaxLength = 3
      Me.txtIdObraSocial.Name = "txtIdObraSocial"
      Me.txtIdObraSocial.Size = New System.Drawing.Size(64, 20)
      Me.txtIdObraSocial.TabIndex = 1
      '
      'lblIdObraSocial
      '
      Me.lblIdObraSocial.AutoSize = True
      Me.lblIdObraSocial.Location = New System.Drawing.Point(17, 27)
      Me.lblIdObraSocial.Name = "lblIdObraSocial"
      Me.lblIdObraSocial.Size = New System.Drawing.Size(40, 13)
      Me.lblIdObraSocial.TabIndex = 0
      Me.lblIdObraSocial.Text = "Codigo"
      '
      'SueldosObraSocialDetalle
      '
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.ClientSize = New System.Drawing.Size(350, 139)
      Me.Controls.Add(Me.txtNombreObraSocial)
      Me.Controls.Add(Me.txtIdObraSocial)
      Me.Controls.Add(Me.lblNombre)
      Me.Controls.Add(Me.lblIdObraSocial)
      Me.Name = "SueldosObraSocialDetalle"
      Me.Text = "Obra Social"
      Me.Controls.SetChildIndex(Me.lblIdObraSocial, 0)
      Me.Controls.SetChildIndex(Me.lblNombre, 0)
      Me.Controls.SetChildIndex(Me.txtIdObraSocial, 0)
      Me.Controls.SetChildIndex(Me.btnAceptar, 0)
      Me.Controls.SetChildIndex(Me.btnCancelar, 0)
      Me.Controls.SetChildIndex(Me.txtNombreObraSocial, 0)
      Me.ResumeLayout(False)
      Me.PerformLayout()

   End Sub
   Friend WithEvents txtNombreObraSocial As Eniac.Controles.TextBox
   Friend WithEvents lblNombre As Eniac.Controles.Label
   Friend WithEvents txtIdObraSocial As Eniac.Controles.TextBox
   Friend WithEvents lblIdObraSocial As Eniac.Controles.Label
End Class
