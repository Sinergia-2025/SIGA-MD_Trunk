<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class AplicacionesModulosDetalle
   Inherits BaseDetalle

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
      Me.txtIdEmpresa = New Eniac.Controles.TextBox()
      Me.lblIdEmpresa = New Eniac.Controles.Label()
      Me.lblNombreEmpresa = New Eniac.Controles.Label()
      Me.txtNombreEmpresa = New Eniac.Controles.TextBox()
      Me.SuspendLayout()
      '
      'btnAceptar
      '
      Me.btnAceptar.Location = New System.Drawing.Point(224, 85)
      Me.btnAceptar.TabIndex = 6
      '
      'btnCancelar
      '
      Me.btnCancelar.Location = New System.Drawing.Point(310, 85)
      Me.btnCancelar.TabIndex = 7
      '
      'btnCopiar
      '
      Me.btnCopiar.Location = New System.Drawing.Point(123, 85)
      Me.btnCopiar.TabIndex = 9
      '
      'btnAplicar
      '
      Me.btnAplicar.Location = New System.Drawing.Point(66, 85)
      Me.btnAplicar.TabIndex = 8
      '
      'txtIdEmpresa
      '
      Me.txtIdEmpresa.BindearPropiedadControl = "Text"
      Me.txtIdEmpresa.BindearPropiedadEntidad = "IdModulo"
      Me.txtIdEmpresa.ForeColorFocus = System.Drawing.Color.Red
      Me.txtIdEmpresa.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtIdEmpresa.Formato = ""
      Me.txtIdEmpresa.IsDecimal = False
      Me.txtIdEmpresa.IsNumber = True
      Me.txtIdEmpresa.IsPK = True
      Me.txtIdEmpresa.IsRequired = True
      Me.txtIdEmpresa.Key = ""
      Me.txtIdEmpresa.LabelAsoc = Me.lblIdEmpresa
      Me.txtIdEmpresa.Location = New System.Drawing.Point(86, 12)
      Me.txtIdEmpresa.MaxLength = 4
      Me.txtIdEmpresa.Name = "txtIdEmpresa"
      Me.txtIdEmpresa.Size = New System.Drawing.Size(46, 20)
      Me.txtIdEmpresa.TabIndex = 1
      Me.txtIdEmpresa.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'lblIdEmpresa
      '
      Me.lblIdEmpresa.AutoSize = True
      Me.lblIdEmpresa.LabelAsoc = Nothing
      Me.lblIdEmpresa.Location = New System.Drawing.Point(36, 15)
      Me.lblIdEmpresa.Name = "lblIdEmpresa"
      Me.lblIdEmpresa.Size = New System.Drawing.Size(40, 13)
      Me.lblIdEmpresa.TabIndex = 0
      Me.lblIdEmpresa.Text = "Codigo"
      '
      'lblNombreEmpresa
      '
      Me.lblNombreEmpresa.AutoSize = True
      Me.lblNombreEmpresa.LabelAsoc = Nothing
      Me.lblNombreEmpresa.Location = New System.Drawing.Point(36, 43)
      Me.lblNombreEmpresa.Name = "lblNombreEmpresa"
      Me.lblNombreEmpresa.Size = New System.Drawing.Size(44, 13)
      Me.lblNombreEmpresa.TabIndex = 2
      Me.lblNombreEmpresa.Text = "Nombre"
      '
      'txtNombreEmpresa
      '
      Me.txtNombreEmpresa.BindearPropiedadControl = "Text"
      Me.txtNombreEmpresa.BindearPropiedadEntidad = "NombreModulo"
      Me.txtNombreEmpresa.ForeColorFocus = System.Drawing.Color.Red
      Me.txtNombreEmpresa.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtNombreEmpresa.Formato = ""
      Me.txtNombreEmpresa.IsDecimal = False
      Me.txtNombreEmpresa.IsNumber = False
      Me.txtNombreEmpresa.IsPK = False
      Me.txtNombreEmpresa.IsRequired = True
      Me.txtNombreEmpresa.Key = ""
      Me.txtNombreEmpresa.LabelAsoc = Me.lblNombreEmpresa
      Me.txtNombreEmpresa.Location = New System.Drawing.Point(86, 40)
      Me.txtNombreEmpresa.MaxLength = 100
      Me.txtNombreEmpresa.Name = "txtNombreEmpresa"
      Me.txtNombreEmpresa.Size = New System.Drawing.Size(289, 20)
      Me.txtNombreEmpresa.TabIndex = 3
      '
      'AplicacionesModulosDetalle
      '
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.ClientSize = New System.Drawing.Size(399, 120)
      Me.Controls.Add(Me.txtIdEmpresa)
      Me.Controls.Add(Me.lblIdEmpresa)
      Me.Controls.Add(Me.lblNombreEmpresa)
      Me.Controls.Add(Me.txtNombreEmpresa)
      Me.Name = "AplicacionesModulosDetalle"
      Me.Text = "Módulo"
      Me.Controls.SetChildIndex(Me.btnCancelar, 0)
      Me.Controls.SetChildIndex(Me.btnAceptar, 0)
      Me.Controls.SetChildIndex(Me.btnCopiar, 0)
      Me.Controls.SetChildIndex(Me.btnAplicar, 0)
      Me.Controls.SetChildIndex(Me.txtNombreEmpresa, 0)
      Me.Controls.SetChildIndex(Me.lblNombreEmpresa, 0)
      Me.Controls.SetChildIndex(Me.lblIdEmpresa, 0)
      Me.Controls.SetChildIndex(Me.txtIdEmpresa, 0)
      Me.ResumeLayout(False)
      Me.PerformLayout()

   End Sub
   Friend WithEvents txtIdEmpresa As Eniac.Controles.TextBox
   Friend WithEvents lblIdEmpresa As Eniac.Controles.Label
   Friend WithEvents lblNombreEmpresa As Eniac.Controles.Label
   Friend WithEvents txtNombreEmpresa As Eniac.Controles.TextBox
End Class
