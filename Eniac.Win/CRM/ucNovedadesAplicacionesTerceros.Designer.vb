<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ucNovedadesAplicacionesTerceros
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
      Me.cmbAplicacionTerceros = New Eniac.Controles.ComboBox()
      Me.GroupBox1.SuspendLayout()
      Me.SuspendLayout()
      '
      'GroupBox1
      '
      Me.GroupBox1.Controls.Add(Me.cmbAplicacionTerceros)
      Me.GroupBox1.Size = New System.Drawing.Size(190, 45)
      Me.GroupBox1.Text = "Aplicación actual"
      '
      'cmbAplicacionTerceros
      '
      Me.cmbAplicacionTerceros.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.cmbAplicacionTerceros.BindearPropiedadControl = Nothing
      Me.cmbAplicacionTerceros.BindearPropiedadEntidad = Nothing
      Me.cmbAplicacionTerceros.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cmbAplicacionTerceros.ForeColorFocus = System.Drawing.Color.Red
      Me.cmbAplicacionTerceros.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.cmbAplicacionTerceros.FormattingEnabled = True
      Me.cmbAplicacionTerceros.IsPK = False
      Me.cmbAplicacionTerceros.IsRequired = False
      Me.cmbAplicacionTerceros.Key = Nothing
      Me.cmbAplicacionTerceros.LabelAsoc = Nothing
      Me.cmbAplicacionTerceros.Location = New System.Drawing.Point(6, 19)
      Me.cmbAplicacionTerceros.Name = "cmbAplicacionTerceros"
      Me.cmbAplicacionTerceros.Size = New System.Drawing.Size(178, 21)
      Me.cmbAplicacionTerceros.TabIndex = 1
      '
      'ucNovedadesAplicacionesTerceros
      '
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.Name = "ucNovedadesAplicacionesTerceros"
      Me.Size = New System.Drawing.Size(190, 45)
      Me.GroupBox1.ResumeLayout(False)
      Me.ResumeLayout(False)

   End Sub

   Friend WithEvents cmbAplicacionTerceros As Controles.ComboBox
End Class
