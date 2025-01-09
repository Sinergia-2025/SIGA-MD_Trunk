<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ucNovedadesSistemas
   Inherits ucNovedades

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
      Me.cmbSistema = New Eniac.Controles.ComboBox()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.cmbSistema)
        Me.GroupBox1.Size = New System.Drawing.Size(190, 43)
        Me.GroupBox1.Text = "Sistema"
        '
        'cmbSistema
        '
        Me.cmbSistema.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmbSistema.BindearPropiedadControl = Nothing
        Me.cmbSistema.BindearPropiedadEntidad = Nothing
        Me.cmbSistema.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbSistema.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbSistema.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbSistema.FormattingEnabled = True
        Me.cmbSistema.IsPK = False
        Me.cmbSistema.IsRequired = False
        Me.cmbSistema.Key = Nothing
        Me.cmbSistema.LabelAsoc = Nothing
        Me.cmbSistema.Location = New System.Drawing.Point(6, 19)
        Me.cmbSistema.Name = "cmbSistema"
        Me.cmbSistema.Size = New System.Drawing.Size(178, 21)
        Me.cmbSistema.TabIndex = 0
        '
        'ucNovedadesSistemas
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Margin = New System.Windows.Forms.Padding(0)
        Me.MinimumSize = New System.Drawing.Size(0, 0)
        Me.Name = "ucNovedadesSistemas"
        Me.Size = New System.Drawing.Size(190, 43)
        Me.GroupBox1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents cmbSistema As Eniac.Controles.ComboBox

End Class
