<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ucConfBase
   Inherits System.Windows.Forms.UserControl

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
      Me.lblErrorEnCarga = New Eniac.Controles.Label()
        Me.SuspendLayout()
        '
        'lblErrorEnCarga
        '
        Me.lblErrorEnCarga.AutoSize = True
        Me.lblErrorEnCarga.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblErrorEnCarga.ForeColor = System.Drawing.Color.Red
        Me.lblErrorEnCarga.LabelAsoc = Nothing
        Me.lblErrorEnCarga.Location = New System.Drawing.Point(3, 3)
        Me.lblErrorEnCarga.Name = "lblErrorEnCarga"
        Me.lblErrorEnCarga.Size = New System.Drawing.Size(348, 40)
        Me.lblErrorEnCarga.TabIndex = 58
        Me.lblErrorEnCarga.Text = "Error cargando parámetros de esta solapa" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "No se podrán grabar los parámetros"
        Me.lblErrorEnCarga.Visible = False
        '
        'ucConfBase
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.lblErrorEnCarga)
        Me.Name = "ucConfBase"
        Me.Size = New System.Drawing.Size(900, 400)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents lblErrorEnCarga As Controles.Label
End Class
