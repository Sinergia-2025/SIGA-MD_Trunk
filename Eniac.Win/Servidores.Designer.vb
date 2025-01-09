<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Servidores
    Inherits BaseForm

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
      Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Servidores))
      Me.cmbServidores = New Eniac.Controles.ComboBox
      Me.lblSucursal = New Eniac.Controles.Label
      Me.btnOk = New System.Windows.Forms.Button
      Me.SuspendLayout()
      '
      'cmbServidores
      '
      Me.cmbServidores.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.cmbServidores.BindearPropiedadControl = Nothing
      Me.cmbServidores.BindearPropiedadEntidad = Nothing
      Me.cmbServidores.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cmbServidores.ForeColorFocus = System.Drawing.Color.Red
      Me.cmbServidores.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.cmbServidores.FormattingEnabled = True
      Me.cmbServidores.IsPK = False
      Me.cmbServidores.IsRequired = False
      Me.cmbServidores.Key = Nothing
      Me.cmbServidores.LabelAsoc = Nothing
      Me.cmbServidores.Location = New System.Drawing.Point(12, 30)
      Me.cmbServidores.Name = "cmbServidores"
      Me.cmbServidores.Size = New System.Drawing.Size(232, 21)
      Me.cmbServidores.TabIndex = 18
      '
      'lblSucursal
      '
      Me.lblSucursal.AutoSize = True
      Me.lblSucursal.Location = New System.Drawing.Point(40, 16)
      Me.lblSucursal.Name = "lblSucursal"
      Me.lblSucursal.Size = New System.Drawing.Size(176, 13)
      Me.lblSucursal.TabIndex = 19
      Me.lblSucursal.Text = "Seleccione el servidor a conectarse"
      '
      'btnOk
      '
      Me.btnOk.Location = New System.Drawing.Point(250, 30)
      Me.btnOk.Name = "btnOk"
      Me.btnOk.Size = New System.Drawing.Size(32, 23)
      Me.btnOk.TabIndex = 20
      Me.btnOk.Text = "Ok"
      Me.btnOk.UseVisualStyleBackColor = True
      '
      'Servidores
      '
      Me.AcceptButton = Me.btnOk
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.ClientSize = New System.Drawing.Size(288, 65)
      Me.ControlBox = False
      Me.Controls.Add(Me.btnOk)
      Me.Controls.Add(Me.lblSucursal)
      Me.Controls.Add(Me.cmbServidores)
      Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
      Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
      Me.MaximizeBox = False
      Me.MinimizeBox = False
      Me.Name = "Servidores"
      Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
      Me.Text = "Servidores"
      Me.ResumeLayout(False)
      Me.PerformLayout()

   End Sub
   Public WithEvents cmbServidores As Eniac.Controles.ComboBox
   Public WithEvents lblSucursal As Eniac.Controles.Label
   Friend WithEvents btnOk As System.Windows.Forms.Button
End Class
