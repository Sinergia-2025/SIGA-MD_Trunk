<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Calculadora
   Inherits Form

    'Form overrides dispose to clean up the component list.
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
      Dim CalculatorButton6 As Infragistics.Win.UltraWinEditors.UltraWinCalc.CalculatorButton = New Infragistics.Win.UltraWinEditors.UltraWinCalc.CalculatorButton(15)
      Dim CalculatorButton7 As Infragistics.Win.UltraWinEditors.UltraWinCalc.CalculatorButton = New Infragistics.Win.UltraWinEditors.UltraWinCalc.CalculatorButton(16)
      Dim CalculatorButton8 As Infragistics.Win.UltraWinEditors.UltraWinCalc.CalculatorButton = New Infragistics.Win.UltraWinEditors.UltraWinCalc.CalculatorButton(17)
      Dim CalculatorButton9 As Infragistics.Win.UltraWinEditors.UltraWinCalc.CalculatorButton = New Infragistics.Win.UltraWinEditors.UltraWinCalc.CalculatorButton(18)
      Dim CalculatorButton10 As Infragistics.Win.UltraWinEditors.UltraWinCalc.CalculatorButton = New Infragistics.Win.UltraWinEditors.UltraWinCalc.CalculatorButton(19)
      Me.ulcCalculadora = New Infragistics.Win.UltraWinEditors.UltraWinCalc.UltraCalculator()
      Me.btnCerrar = New System.Windows.Forms.Button()
      Me.btnOk = New System.Windows.Forms.Button()
      CType(Me.ulcCalculadora, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.SuspendLayout()
      '
      'ulcCalculadora
      '
      CalculatorButton6.Key = "."
      CalculatorButton6.KeyCodeAlternateValue = 190
      CalculatorButton6.KeyCodeValue = 110
      CalculatorButton6.Text = ","
      CalculatorButton7.Key = "/"
      CalculatorButton7.KeyCodeAlternateValue = 111
      CalculatorButton7.KeyCodeValue = 111
      CalculatorButton8.Key = "*"
      CalculatorButton8.KeyCodeAlternateValue = 106
      CalculatorButton8.KeyCodeValue = 106
      CalculatorButton9.Key = "-"
      CalculatorButton9.KeyCodeAlternateValue = 109
      CalculatorButton9.KeyCodeValue = 109
      CalculatorButton10.Key = "+"
      CalculatorButton10.KeyCodeAlternateValue = 107
      CalculatorButton10.KeyCodeValue = 107
      Me.ulcCalculadora.Buttons.AddRange(New Infragistics.Win.UltraWinEditors.UltraWinCalc.CalculatorButton() {CalculatorButton6, CalculatorButton7, CalculatorButton8, CalculatorButton9, CalculatorButton10})
      Me.ulcCalculadora.Location = New System.Drawing.Point(12, 12)
      Me.ulcCalculadora.Name = "ulcCalculadora"
      Me.ulcCalculadora.Size = New System.Drawing.Size(256, 216)
      Me.ulcCalculadora.TabIndex = 0
      Me.ulcCalculadora.Text = "0,"
      '
      'btnCerrar
      '
      Me.btnCerrar.DialogResult = System.Windows.Forms.DialogResult.Cancel
      Me.btnCerrar.Location = New System.Drawing.Point(193, 234)
      Me.btnCerrar.Name = "btnCerrar"
      Me.btnCerrar.Size = New System.Drawing.Size(75, 23)
      Me.btnCerrar.TabIndex = 2
      Me.btnCerrar.Text = "&Cerrar"
      Me.btnCerrar.UseVisualStyleBackColor = True
      '
      'btnOk
      '
      Me.btnOk.Location = New System.Drawing.Point(112, 234)
      Me.btnOk.Name = "btnOk"
      Me.btnOk.Size = New System.Drawing.Size(75, 23)
      Me.btnOk.TabIndex = 1
      Me.btnOk.Text = "&Ok"
      Me.btnOk.UseVisualStyleBackColor = True
      '
      'Calculadora
      '
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.CancelButton = Me.btnCerrar
      Me.ClientSize = New System.Drawing.Size(284, 261)
      Me.ControlBox = False
      Me.Controls.Add(Me.btnOk)
      Me.Controls.Add(Me.btnCerrar)
      Me.Controls.Add(Me.ulcCalculadora)
      Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
      Me.MaximizeBox = False
      Me.MinimizeBox = False
      Me.Name = "Calculadora"
      Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
      Me.Text = "Calculadora"
      CType(Me.ulcCalculadora, System.ComponentModel.ISupportInitialize).EndInit()
      Me.ResumeLayout(False)

   End Sub
   Friend WithEvents ulcCalculadora As Infragistics.Win.UltraWinEditors.UltraWinCalc.UltraCalculator
   Friend WithEvents btnCerrar As System.Windows.Forms.Button
   Friend WithEvents btnOk As System.Windows.Forms.Button
End Class
