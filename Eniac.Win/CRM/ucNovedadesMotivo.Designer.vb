<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ucNovedadesMotivo
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
      Me.cmbMotivoNovedad = New Eniac.Controles.ComboBox()
      Me.GroupBox1.SuspendLayout()
      Me.SuspendLayout()
      '
      'GroupBox1
      '
      Me.GroupBox1.Controls.Add(Me.cmbMotivoNovedad)
      Me.GroupBox1.Size = New System.Drawing.Size(190, 45)
      Me.GroupBox1.Text = "Motivo"
      '
      'cmbMotivoNovedad
      '
      Me.cmbMotivoNovedad.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.cmbMotivoNovedad.BindearPropiedadControl = Nothing
      Me.cmbMotivoNovedad.BindearPropiedadEntidad = Nothing
      Me.cmbMotivoNovedad.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cmbMotivoNovedad.ForeColorFocus = System.Drawing.Color.Red
      Me.cmbMotivoNovedad.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.cmbMotivoNovedad.FormattingEnabled = True
      Me.cmbMotivoNovedad.IsPK = False
      Me.cmbMotivoNovedad.IsRequired = False
      Me.cmbMotivoNovedad.Key = Nothing
      Me.cmbMotivoNovedad.LabelAsoc = Nothing
      Me.cmbMotivoNovedad.Location = New System.Drawing.Point(6, 19)
      Me.cmbMotivoNovedad.Name = "cmbMotivoNovedad"
      Me.cmbMotivoNovedad.Size = New System.Drawing.Size(178, 21)
      Me.cmbMotivoNovedad.TabIndex = 2
      '
      'ucNovedadesMotivo
      '
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.Name = "ucNovedadesMotivo"
      Me.Size = New System.Drawing.Size(190, 45)
      Me.GroupBox1.ResumeLayout(False)
      Me.ResumeLayout(False)

   End Sub

   Friend WithEvents cmbMotivoNovedad As Controles.ComboBox
End Class
