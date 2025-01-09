<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SueldosEstadoCivilDetalle
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
      Me.txtNombreEstadoCivil = New Eniac.Controles.TextBox
      Me.lblNombreEstadoCivil = New Eniac.Controles.Label
      Me.txtIdEstadoCivil = New Eniac.Controles.TextBox
      Me.lblIdEstadoCivil = New Eniac.Controles.Label
      Me.SuspendLayout()
      '
      'btnAceptar
      '
      Me.btnAceptar.Location = New System.Drawing.Point(176, 77)
      Me.btnAceptar.TabIndex = 4
      '
      'btnCancelar
      '
      Me.btnCancelar.Location = New System.Drawing.Point(262, 77)
      Me.btnCancelar.TabIndex = 5
      '
      'txtNombreEstadoCivil
      '
      Me.txtNombreEstadoCivil.BindearPropiedadControl = "Text"
      Me.txtNombreEstadoCivil.BindearPropiedadEntidad = "NombreEstadoCivil"
      Me.txtNombreEstadoCivil.ForeColorFocus = System.Drawing.Color.Red
      Me.txtNombreEstadoCivil.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtNombreEstadoCivil.Formato = ""
      Me.txtNombreEstadoCivil.IsDecimal = False
      Me.txtNombreEstadoCivil.IsNumber = False
      Me.txtNombreEstadoCivil.IsPK = False
      Me.txtNombreEstadoCivil.IsRequired = True
      Me.txtNombreEstadoCivil.Key = ""
      Me.txtNombreEstadoCivil.LabelAsoc = Me.lblNombreEstadoCivil
      Me.txtNombreEstadoCivil.Location = New System.Drawing.Point(79, 46)
      Me.txtNombreEstadoCivil.MaxLength = 30
      Me.txtNombreEstadoCivil.Name = "txtNombreEstadoCivil"
      Me.txtNombreEstadoCivil.Size = New System.Drawing.Size(262, 20)
      Me.txtNombreEstadoCivil.TabIndex = 3
      '
      'lblNombreEstadoCivil
      '
      Me.lblNombreEstadoCivil.AutoSize = True
      Me.lblNombreEstadoCivil.Location = New System.Drawing.Point(20, 50)
      Me.lblNombreEstadoCivil.Name = "lblNombreEstadoCivil"
      Me.lblNombreEstadoCivil.Size = New System.Drawing.Size(44, 13)
      Me.lblNombreEstadoCivil.TabIndex = 2
      Me.lblNombreEstadoCivil.Text = "Nombre"
      '
      'txtIdEstadoCivil
      '
      Me.txtIdEstadoCivil.BindearPropiedadControl = "Text"
      Me.txtIdEstadoCivil.BindearPropiedadEntidad = "IdEstadoCivil"
      Me.txtIdEstadoCivil.ForeColorFocus = System.Drawing.Color.Red
      Me.txtIdEstadoCivil.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtIdEstadoCivil.Formato = ""
      Me.txtIdEstadoCivil.IsDecimal = False
      Me.txtIdEstadoCivil.IsNumber = True
      Me.txtIdEstadoCivil.IsPK = True
      Me.txtIdEstadoCivil.IsRequired = True
      Me.txtIdEstadoCivil.Key = ""
      Me.txtIdEstadoCivil.LabelAsoc = Me.lblIdEstadoCivil
      Me.txtIdEstadoCivil.Location = New System.Drawing.Point(79, 20)
      Me.txtIdEstadoCivil.MaxLength = 3
      Me.txtIdEstadoCivil.Name = "txtIdEstadoCivil"
      Me.txtIdEstadoCivil.Size = New System.Drawing.Size(58, 20)
      Me.txtIdEstadoCivil.TabIndex = 1
      '
      'lblIdEstadoCivil
      '
      Me.lblIdEstadoCivil.AutoSize = True
      Me.lblIdEstadoCivil.Location = New System.Drawing.Point(20, 24)
      Me.lblIdEstadoCivil.Name = "lblIdEstadoCivil"
      Me.lblIdEstadoCivil.Size = New System.Drawing.Size(40, 13)
      Me.lblIdEstadoCivil.TabIndex = 0
      Me.lblIdEstadoCivil.Text = "Codigo"
      '
      'SueldosEstadoCivilDetalle
      '
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.ClientSize = New System.Drawing.Size(354, 119)
      Me.Controls.Add(Me.txtNombreEstadoCivil)
      Me.Controls.Add(Me.txtIdEstadoCivil)
      Me.Controls.Add(Me.lblNombreEstadoCivil)
      Me.Controls.Add(Me.lblIdEstadoCivil)
      Me.Name = "SueldosEstadoCivilDetalle"
      Me.Text = "Estado Civil"
      Me.Controls.SetChildIndex(Me.lblIdEstadoCivil, 0)
      Me.Controls.SetChildIndex(Me.lblNombreEstadoCivil, 0)
      Me.Controls.SetChildIndex(Me.txtIdEstadoCivil, 0)
      Me.Controls.SetChildIndex(Me.btnAceptar, 0)
      Me.Controls.SetChildIndex(Me.btnCancelar, 0)
      Me.Controls.SetChildIndex(Me.txtNombreEstadoCivil, 0)
      Me.ResumeLayout(False)
      Me.PerformLayout()

   End Sub
   Friend WithEvents txtNombreEstadoCivil As Eniac.Controles.TextBox
   Friend WithEvents lblNombreEstadoCivil As Eniac.Controles.Label
   Friend WithEvents txtIdEstadoCivil As Eniac.Controles.TextBox
   Friend WithEvents lblIdEstadoCivil As Eniac.Controles.Label
End Class
