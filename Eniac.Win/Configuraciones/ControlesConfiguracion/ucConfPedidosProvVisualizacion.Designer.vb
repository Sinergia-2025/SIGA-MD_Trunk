<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ucConfPedidosProvVisualizacion
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
      Me.GroupBox27 = New System.Windows.Forms.GroupBox()
      Me.chbPedidosProvMuestraProvHabitual = New Eniac.Controles.CheckBox()
      Me.GroupBox27.SuspendLayout()
      Me.SuspendLayout()
      '
      'GroupBox27
      '
      Me.GroupBox27.Controls.Add(Me.chbPedidosProvMuestraProvHabitual)
      Me.GroupBox27.Location = New System.Drawing.Point(7, 19)
      Me.GroupBox27.Name = "GroupBox27"
      Me.GroupBox27.Size = New System.Drawing.Size(269, 53)
      Me.GroupBox27.TabIndex = 0
      Me.GroupBox27.TabStop = False
      Me.GroupBox27.Text = "Columnas del detalle de Pedidos. Prov. a mostrar"
      '
      'chbPedidosProvMuestraProvHabitual
      '
      Me.chbPedidosProvMuestraProvHabitual.AutoSize = True
      Me.chbPedidosProvMuestraProvHabitual.BindearPropiedadControl = Nothing
      Me.chbPedidosProvMuestraProvHabitual.BindearPropiedadEntidad = Nothing
      Me.chbPedidosProvMuestraProvHabitual.Checked = True
      Me.chbPedidosProvMuestraProvHabitual.CheckState = System.Windows.Forms.CheckState.Checked
      Me.chbPedidosProvMuestraProvHabitual.ForeColorFocus = System.Drawing.Color.Red
      Me.chbPedidosProvMuestraProvHabitual.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
      Me.chbPedidosProvMuestraProvHabitual.IsPK = False
      Me.chbPedidosProvMuestraProvHabitual.IsRequired = False
      Me.chbPedidosProvMuestraProvHabitual.Key = Nothing
      Me.chbPedidosProvMuestraProvHabitual.LabelAsoc = Nothing
      Me.chbPedidosProvMuestraProvHabitual.Location = New System.Drawing.Point(6, 19)
      Me.chbPedidosProvMuestraProvHabitual.Name = "chbPedidosProvMuestraProvHabitual"
      Me.chbPedidosProvMuestraProvHabitual.Size = New System.Drawing.Size(93, 17)
      Me.chbPedidosProvMuestraProvHabitual.TabIndex = 0
      Me.chbPedidosProvMuestraProvHabitual.Tag = ""
      Me.chbPedidosProvMuestraProvHabitual.Text = "Prov. Habitual"
      Me.chbPedidosProvMuestraProvHabitual.UseVisualStyleBackColor = True
      '
      'ucConfPedidosProvVisualizacion
      '
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.Controls.Add(Me.GroupBox27)
      Me.Name = "ucConfPedidosProvVisualizacion"
      Me.Controls.SetChildIndex(Me.GroupBox27, 0)
      Me.GroupBox27.ResumeLayout(False)
      Me.GroupBox27.PerformLayout()
      Me.ResumeLayout(False)
      Me.PerformLayout()

   End Sub

   Friend WithEvents GroupBox27 As GroupBox
   Friend WithEvents chbPedidosProvMuestraProvHabitual As Controles.CheckBox
End Class
