<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ContabilidadTiposCuentasABMDetalle
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
      Me.Label1 = New Eniac.Controles.Label
      Me.txtDecTipoCuenta = New Eniac.Controles.TextBox
      Me.lblcodigo = New Eniac.Controles.Label
      Me.txtcodigoTipoCuenta = New Eniac.Controles.TextBox
      Me.SuspendLayout()
      '
      'btnAceptar
      '
      Me.btnAceptar.Location = New System.Drawing.Point(104, 72)
      Me.btnAceptar.TabIndex = 4
      '
      'btnCancelar
      '
      Me.btnCancelar.Location = New System.Drawing.Point(190, 72)
      Me.btnCancelar.TabIndex = 5
      '
      'Label1
      '
      Me.Label1.AutoSize = True
      Me.Label1.Location = New System.Drawing.Point(12, 46)
      Me.Label1.Name = "Label1"
      Me.Label1.Size = New System.Drawing.Size(63, 13)
      Me.Label1.TabIndex = 3
      Me.Label1.Text = "Descripcion"
      '
      'txtDecTipoCuenta
      '
      Me.txtDecTipoCuenta.BindearPropiedadControl = "Text"
      Me.txtDecTipoCuenta.BindearPropiedadEntidad = "NombreTipoCuenta"
      Me.txtDecTipoCuenta.ForeColorFocus = System.Drawing.Color.Red
      Me.txtDecTipoCuenta.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtDecTipoCuenta.Formato = ""
      Me.txtDecTipoCuenta.IsDecimal = False
      Me.txtDecTipoCuenta.IsNumber = False
      Me.txtDecTipoCuenta.IsPK = False
      Me.txtDecTipoCuenta.IsRequired = True
      Me.txtDecTipoCuenta.Key = ""
      Me.txtDecTipoCuenta.LabelAsoc = Me.Label1
      Me.txtDecTipoCuenta.Location = New System.Drawing.Point(93, 42)
      Me.txtDecTipoCuenta.MaxLength = 15
      Me.txtDecTipoCuenta.Name = "txtDecTipoCuenta"
      Me.txtDecTipoCuenta.Size = New System.Drawing.Size(177, 20)
      Me.txtDecTipoCuenta.TabIndex = 2
      '
      'lblcodigo
      '
      Me.lblcodigo.AutoSize = True
      Me.lblcodigo.Location = New System.Drawing.Point(12, 20)
      Me.lblcodigo.Name = "lblcodigo"
      Me.lblcodigo.Size = New System.Drawing.Size(40, 13)
      Me.lblcodigo.TabIndex = 1
      Me.lblcodigo.Text = "Código"
      '
      'txtcodigoTipoCuenta
      '
      Me.txtcodigoTipoCuenta.BindearPropiedadControl = "Text"
      Me.txtcodigoTipoCuenta.BindearPropiedadEntidad = "IdTipoCuenta"
      Me.txtcodigoTipoCuenta.ForeColorFocus = System.Drawing.Color.Red
      Me.txtcodigoTipoCuenta.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtcodigoTipoCuenta.Formato = ""
      Me.txtcodigoTipoCuenta.IsDecimal = False
      Me.txtcodigoTipoCuenta.IsNumber = False
      Me.txtcodigoTipoCuenta.IsPK = True
      Me.txtcodigoTipoCuenta.IsRequired = True
      Me.txtcodigoTipoCuenta.Key = ""
      Me.txtcodigoTipoCuenta.LabelAsoc = Me.lblcodigo
      Me.txtcodigoTipoCuenta.Location = New System.Drawing.Point(93, 16)
      Me.txtcodigoTipoCuenta.MaxLength = 8
      Me.txtcodigoTipoCuenta.Name = "txtcodigoTipoCuenta"
      Me.txtcodigoTipoCuenta.Size = New System.Drawing.Size(91, 20)
      Me.txtcodigoTipoCuenta.TabIndex = 0
      '
      'ContabilidadTiposCuentasABMDetalle
      '
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.ClientSize = New System.Drawing.Size(292, 118)
      Me.Controls.Add(Me.Label1)
      Me.Controls.Add(Me.txtDecTipoCuenta)
      Me.Controls.Add(Me.lblcodigo)
      Me.Controls.Add(Me.txtcodigoTipoCuenta)
      Me.Name = "ContabilidadTiposCuentasABMDetalle"
      Me.Text = "Tipo de Cuenta"
      Me.Controls.SetChildIndex(Me.btnCancelar, 0)
      Me.Controls.SetChildIndex(Me.btnAceptar, 0)
      Me.Controls.SetChildIndex(Me.txtcodigoTipoCuenta, 0)
      Me.Controls.SetChildIndex(Me.lblcodigo, 0)
      Me.Controls.SetChildIndex(Me.txtDecTipoCuenta, 0)
      Me.Controls.SetChildIndex(Me.Label1, 0)
      Me.ResumeLayout(False)
      Me.PerformLayout()

   End Sub
   Friend WithEvents Label1 As Eniac.Controles.Label
   Friend WithEvents txtDecTipoCuenta As Eniac.Controles.TextBox
   Friend WithEvents lblcodigo As Eniac.Controles.Label
   Friend WithEvents txtcodigoTipoCuenta As Eniac.Controles.TextBox
End Class
