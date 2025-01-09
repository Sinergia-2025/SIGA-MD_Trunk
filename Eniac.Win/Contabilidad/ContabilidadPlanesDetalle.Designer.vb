<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ContabilidadPlanesDetalle
   Inherits Eniac.Win.BaseDetalle

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
      Me.lblDescripcion = New Eniac.Controles.Label
      Me.txtNombrePlanCuenta = New Eniac.Controles.TextBox
      Me.lblCodigo = New Eniac.Controles.Label
      Me.txtIdPlanCuenta = New Eniac.Controles.TextBox
      Me.SuspendLayout()
      '
      'btnAceptar
      '
      Me.btnAceptar.Location = New System.Drawing.Point(151, 87)
      Me.btnAceptar.TabIndex = 4
      '
      'btnCancelar
      '
      Me.btnCancelar.Location = New System.Drawing.Point(237, 87)
      Me.btnCancelar.TabIndex = 5
      '
      'lblDescripcion
      '
      Me.lblDescripcion.AutoSize = True
      Me.lblDescripcion.Location = New System.Drawing.Point(19, 50)
      Me.lblDescripcion.Name = "lblDescripcion"
      Me.lblDescripcion.Size = New System.Drawing.Size(63, 13)
      Me.lblDescripcion.TabIndex = 3
      Me.lblDescripcion.Text = "Descripción"
      '
      'txtNombrePlanCuenta
      '
      Me.txtNombrePlanCuenta.BindearPropiedadControl = "Text"
      Me.txtNombrePlanCuenta.BindearPropiedadEntidad = "NombrePlanCuenta"
      Me.txtNombrePlanCuenta.ForeColorFocus = System.Drawing.Color.Red
      Me.txtNombrePlanCuenta.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtNombrePlanCuenta.Formato = ""
      Me.txtNombrePlanCuenta.IsDecimal = False
      Me.txtNombrePlanCuenta.IsNumber = False
      Me.txtNombrePlanCuenta.IsPK = False
      Me.txtNombrePlanCuenta.IsRequired = True
      Me.txtNombrePlanCuenta.Key = ""
      Me.txtNombrePlanCuenta.LabelAsoc = Me.lblDescripcion
      Me.txtNombrePlanCuenta.Location = New System.Drawing.Point(92, 46)
      Me.txtNombrePlanCuenta.MaxLength = 25
      Me.txtNombrePlanCuenta.Name = "txtNombrePlanCuenta"
      Me.txtNombrePlanCuenta.Size = New System.Drawing.Size(225, 20)
      Me.txtNombrePlanCuenta.TabIndex = 2
      '
      'lblCodigo
      '
      Me.lblCodigo.AutoSize = True
      Me.lblCodigo.Location = New System.Drawing.Point(19, 24)
      Me.lblCodigo.Name = "lblCodigo"
      Me.lblCodigo.Size = New System.Drawing.Size(40, 13)
      Me.lblCodigo.TabIndex = 1
      Me.lblCodigo.Text = "Codigo"
      '
      'txtIdPlanCuenta
      '
      Me.txtIdPlanCuenta.BindearPropiedadControl = "Text"
      Me.txtIdPlanCuenta.BindearPropiedadEntidad = "IdPlanCuenta"
      Me.txtIdPlanCuenta.ForeColorFocus = System.Drawing.Color.Red
      Me.txtIdPlanCuenta.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtIdPlanCuenta.Formato = ""
      Me.txtIdPlanCuenta.IsDecimal = False
      Me.txtIdPlanCuenta.IsNumber = True
      Me.txtIdPlanCuenta.IsPK = True
      Me.txtIdPlanCuenta.IsRequired = True
      Me.txtIdPlanCuenta.Key = ""
      Me.txtIdPlanCuenta.LabelAsoc = Me.lblCodigo
      Me.txtIdPlanCuenta.Location = New System.Drawing.Point(92, 20)
      Me.txtIdPlanCuenta.MaxLength = 2
      Me.txtIdPlanCuenta.Name = "txtIdPlanCuenta"
      Me.txtIdPlanCuenta.Size = New System.Drawing.Size(54, 20)
      Me.txtIdPlanCuenta.TabIndex = 0
      '
      'ContabilidadPlanesDetalle
      '
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.ClientSize = New System.Drawing.Size(346, 129)
      Me.Controls.Add(Me.lblDescripcion)
      Me.Controls.Add(Me.txtNombrePlanCuenta)
      Me.Controls.Add(Me.lblCodigo)
      Me.Controls.Add(Me.txtIdPlanCuenta)
      Me.Name = "ContabilidadPlanesDetalle"
      Me.Text = "Plan"
      Me.Controls.SetChildIndex(Me.btnCancelar, 0)
      Me.Controls.SetChildIndex(Me.btnAceptar, 0)
      Me.Controls.SetChildIndex(Me.txtIdPlanCuenta, 0)
      Me.Controls.SetChildIndex(Me.lblCodigo, 0)
      Me.Controls.SetChildIndex(Me.txtNombrePlanCuenta, 0)
      Me.Controls.SetChildIndex(Me.lblDescripcion, 0)
      Me.ResumeLayout(False)
      Me.PerformLayout()

   End Sub
   Friend WithEvents lblDescripcion As Eniac.Controles.Label
   Friend WithEvents txtNombrePlanCuenta As Eniac.Controles.TextBox
   Friend WithEvents lblCodigo As Eniac.Controles.Label
   Friend WithEvents txtIdPlanCuenta As Eniac.Controles.TextBox
End Class
