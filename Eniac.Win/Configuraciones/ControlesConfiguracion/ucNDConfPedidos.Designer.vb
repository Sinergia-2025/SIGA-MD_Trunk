<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ucNDConfPedidos
   Inherits ucConfBase

   'UserControl overrides dispose to clean up the component list.
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
      Me.chbPedidosPermitirModificarGestionados = New Eniac.Controles.CheckBox()
      Me.SuspendLayout()
      '
      'chbPedidosPermitirModificarGestionados
      '
      Me.chbPedidosPermitirModificarGestionados.AutoSize = True
      Me.chbPedidosPermitirModificarGestionados.BindearPropiedadControl = Nothing
      Me.chbPedidosPermitirModificarGestionados.BindearPropiedadEntidad = Nothing
      Me.chbPedidosPermitirModificarGestionados.ForeColorFocus = System.Drawing.Color.Red
      Me.chbPedidosPermitirModificarGestionados.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
      Me.chbPedidosPermitirModificarGestionados.IsPK = False
      Me.chbPedidosPermitirModificarGestionados.IsRequired = False
      Me.chbPedidosPermitirModificarGestionados.Key = Nothing
      Me.chbPedidosPermitirModificarGestionados.LabelAsoc = Nothing
      Me.chbPedidosPermitirModificarGestionados.Location = New System.Drawing.Point(18, 46)
      Me.chbPedidosPermitirModificarGestionados.Name = "chbPedidosPermitirModificarGestionados"
      Me.chbPedidosPermitirModificarGestionados.Size = New System.Drawing.Size(205, 17)
      Me.chbPedidosPermitirModificarGestionados.TabIndex = 60
      Me.chbPedidosPermitirModificarGestionados.Tag = ""
      Me.chbPedidosPermitirModificarGestionados.Text = "Permitir modificar pedidos gestionados"
      Me.chbPedidosPermitirModificarGestionados.UseVisualStyleBackColor = True
      '
      'ucNDConfigPedidos
      '
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.Controls.Add(Me.chbPedidosPermitirModificarGestionados)
      Me.Name = "ucNDConfigPedidos"
      Me.Controls.SetChildIndex(Me.chbPedidosPermitirModificarGestionados, 0)
      Me.ResumeLayout(False)
      Me.PerformLayout()

   End Sub

   Friend WithEvents chbPedidosPermitirModificarGestionados As Controles.CheckBox
End Class
