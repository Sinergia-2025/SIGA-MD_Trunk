<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class TimeSpanBox
    Inherits System.Windows.Forms.UserControl

    'UserControl overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
      Me.dtpHora = New System.Windows.Forms.DateTimePicker()
      Me.txtDias = New System.Windows.Forms.NumericUpDown()
      CType(Me.txtDias, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.SuspendLayout()
      '
      'dtpHora
      '
      Me.dtpHora.CustomFormat = "HH:mm:ss"
      Me.dtpHora.Dock = System.Windows.Forms.DockStyle.Fill
      Me.dtpHora.Format = System.Windows.Forms.DateTimePickerFormat.Custom
      Me.dtpHora.Location = New System.Drawing.Point(40, 0)
      Me.dtpHora.Margin = New System.Windows.Forms.Padding(0)
      Me.dtpHora.Name = "dtpHora"
      Me.dtpHora.ShowUpDown = True
      Me.dtpHora.Size = New System.Drawing.Size(70, 20)
      Me.dtpHora.TabIndex = 1
      '
      'txtDias
      '
      Me.txtDias.Dock = System.Windows.Forms.DockStyle.Left
      Me.txtDias.Location = New System.Drawing.Point(0, 0)
      Me.txtDias.Margin = New System.Windows.Forms.Padding(0)
      Me.txtDias.Name = "txtDias"
      Me.txtDias.Size = New System.Drawing.Size(40, 20)
      Me.txtDias.TabIndex = 0
      Me.txtDias.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'TimeSpanBox
      '
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.Controls.Add(Me.dtpHora)
      Me.Controls.Add(Me.txtDias)
      Me.MaximumSize = New System.Drawing.Size(65535, 20)
      Me.MinimumSize = New System.Drawing.Size(0, 20)
      Me.Name = "TimeSpanBox"
      Me.Size = New System.Drawing.Size(110, 20)
      CType(Me.txtDias, System.ComponentModel.ISupportInitialize).EndInit()
      Me.ResumeLayout(False)

   End Sub

   Private WithEvents dtpHora As DateTimePicker
    Private WithEvents txtDias As NumericUpDown
End Class
