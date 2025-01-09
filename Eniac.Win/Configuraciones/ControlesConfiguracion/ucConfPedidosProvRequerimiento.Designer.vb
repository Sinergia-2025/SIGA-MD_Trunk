<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ucConfPedidosProvRequerimiento
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
      Me.chbRequerimientoPermiteFechaEntregaDistintas = New Eniac.Controles.CheckBox()
      Me.SuspendLayout()
      '
      'chbRequerimientoPermiteFechaEntregaDistintas
      '
      Me.chbRequerimientoPermiteFechaEntregaDistintas.AutoSize = True
      Me.chbRequerimientoPermiteFechaEntregaDistintas.BindearPropiedadControl = Nothing
      Me.chbRequerimientoPermiteFechaEntregaDistintas.BindearPropiedadEntidad = Nothing
      Me.chbRequerimientoPermiteFechaEntregaDistintas.ForeColorFocus = System.Drawing.Color.Red
      Me.chbRequerimientoPermiteFechaEntregaDistintas.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
      Me.chbRequerimientoPermiteFechaEntregaDistintas.IsPK = False
      Me.chbRequerimientoPermiteFechaEntregaDistintas.IsRequired = False
      Me.chbRequerimientoPermiteFechaEntregaDistintas.Key = Nothing
      Me.chbRequerimientoPermiteFechaEntregaDistintas.LabelAsoc = Nothing
      Me.chbRequerimientoPermiteFechaEntregaDistintas.Location = New System.Drawing.Point(24, 46)
      Me.chbRequerimientoPermiteFechaEntregaDistintas.Name = "chbRequerimientoPermiteFechaEntregaDistintas"
      Me.chbRequerimientoPermiteFechaEntregaDistintas.Size = New System.Drawing.Size(258, 17)
      Me.chbRequerimientoPermiteFechaEntregaDistintas.TabIndex = 60
      Me.chbRequerimientoPermiteFechaEntregaDistintas.Text = "Permite Fecha de Entrega Distintas en Productos"
      Me.chbRequerimientoPermiteFechaEntregaDistintas.UseVisualStyleBackColor = True
      '
      'ucConfPedidosProvRequerimiento
      '
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.Controls.Add(Me.chbRequerimientoPermiteFechaEntregaDistintas)
      Me.Name = "ucConfPedidosProvRequerimiento"
      Me.Controls.SetChildIndex(Me.chbRequerimientoPermiteFechaEntregaDistintas, 0)
      Me.ResumeLayout(False)
      Me.PerformLayout()

   End Sub

   Friend WithEvents chbRequerimientoPermiteFechaEntregaDistintas As Controles.CheckBox
End Class
