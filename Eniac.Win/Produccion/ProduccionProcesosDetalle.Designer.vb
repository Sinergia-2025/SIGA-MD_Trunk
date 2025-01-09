<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ProduccionProcesosDetalle
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
      Me.txtNombreProduccionProceso = New Eniac.Controles.TextBox()
      Me.lblNombreProduccionProceso = New Eniac.Controles.Label()
      Me.txtIdProduccionProceso = New Eniac.Controles.TextBox()
      Me.lblIdProduccionProceso = New Eniac.Controles.Label()
      Me.SuspendLayout()
      '
      'btnAceptar
      '
      Me.btnAceptar.Location = New System.Drawing.Point(211, 86)
      Me.btnAceptar.TabIndex = 5
      '
      'btnCancelar
      '
      Me.btnCancelar.Location = New System.Drawing.Point(297, 86)
      Me.btnCancelar.TabIndex = 6
      '
      'btnCopiar
      '
      Me.btnCopiar.Location = New System.Drawing.Point(110, 86)
      Me.btnCopiar.TabIndex = 4
      '
      'txtNombreProduccionProceso
      '
      Me.txtNombreProduccionProceso.BindearPropiedadControl = "Text"
      Me.txtNombreProduccionProceso.BindearPropiedadEntidad = "NombreProduccionProceso"
      Me.txtNombreProduccionProceso.ForeColorFocus = System.Drawing.Color.Red
      Me.txtNombreProduccionProceso.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtNombreProduccionProceso.Formato = ""
      Me.txtNombreProduccionProceso.IsDecimal = False
      Me.txtNombreProduccionProceso.IsNumber = False
      Me.txtNombreProduccionProceso.IsPK = False
      Me.txtNombreProduccionProceso.IsRequired = True
      Me.txtNombreProduccionProceso.Key = ""
      Me.txtNombreProduccionProceso.LabelAsoc = Me.lblNombreProduccionProceso
      Me.txtNombreProduccionProceso.Location = New System.Drawing.Point(98, 38)
      Me.txtNombreProduccionProceso.MaxLength = 30
      Me.txtNombreProduccionProceso.Name = "txtNombreProduccionProceso"
      Me.txtNombreProduccionProceso.Size = New System.Drawing.Size(250, 20)
      Me.txtNombreProduccionProceso.TabIndex = 3
      '
      'lblNombreProduccionProceso
      '
      Me.lblNombreProduccionProceso.AutoSize = True
      Me.lblNombreProduccionProceso.LabelAsoc = Nothing
      Me.lblNombreProduccionProceso.Location = New System.Drawing.Point(28, 42)
      Me.lblNombreProduccionProceso.Name = "lblNombreProduccionProceso"
      Me.lblNombreProduccionProceso.Size = New System.Drawing.Size(44, 13)
      Me.lblNombreProduccionProceso.TabIndex = 2
      Me.lblNombreProduccionProceso.Text = "Nombre"
      '
      'txtIdProduccionProceso
      '
      Me.txtIdProduccionProceso.BindearPropiedadControl = "Text"
      Me.txtIdProduccionProceso.BindearPropiedadEntidad = "IdProduccionProceso"
      Me.txtIdProduccionProceso.ForeColorFocus = System.Drawing.Color.Red
      Me.txtIdProduccionProceso.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtIdProduccionProceso.Formato = ""
      Me.txtIdProduccionProceso.IsDecimal = False
      Me.txtIdProduccionProceso.IsNumber = True
      Me.txtIdProduccionProceso.IsPK = True
      Me.txtIdProduccionProceso.IsRequired = True
      Me.txtIdProduccionProceso.Key = ""
      Me.txtIdProduccionProceso.LabelAsoc = Me.lblIdProduccionProceso
      Me.txtIdProduccionProceso.Location = New System.Drawing.Point(98, 12)
      Me.txtIdProduccionProceso.Name = "txtIdProduccionProceso"
      Me.txtIdProduccionProceso.Size = New System.Drawing.Size(61, 20)
      Me.txtIdProduccionProceso.TabIndex = 1
      Me.txtIdProduccionProceso.Text = "0"
      Me.txtIdProduccionProceso.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'lblIdProduccionProceso
      '
      Me.lblIdProduccionProceso.AutoSize = True
      Me.lblIdProduccionProceso.LabelAsoc = Nothing
      Me.lblIdProduccionProceso.Location = New System.Drawing.Point(28, 16)
      Me.lblIdProduccionProceso.Name = "lblIdProduccionProceso"
      Me.lblIdProduccionProceso.Size = New System.Drawing.Size(40, 13)
      Me.lblIdProduccionProceso.TabIndex = 0
      Me.lblIdProduccionProceso.Text = "Código"
      '
      'ProduccionProcesosDetalle
      '
      Me.AcceptButton = Nothing
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.ClientSize = New System.Drawing.Size(386, 121)
      Me.Controls.Add(Me.txtNombreProduccionProceso)
      Me.Controls.Add(Me.txtIdProduccionProceso)
      Me.Controls.Add(Me.lblNombreProduccionProceso)
      Me.Controls.Add(Me.lblIdProduccionProceso)
      Me.Name = "ProduccionProcesosDetalle"
      Me.Text = "Proceso"
      Me.Controls.SetChildIndex(Me.btnAplicar, 0)
      Me.Controls.SetChildIndex(Me.btnCancelar, 0)
      Me.Controls.SetChildIndex(Me.btnAceptar, 0)
      Me.Controls.SetChildIndex(Me.btnCopiar, 0)
      Me.Controls.SetChildIndex(Me.lblIdProduccionProceso, 0)
      Me.Controls.SetChildIndex(Me.lblNombreProduccionProceso, 0)
      Me.Controls.SetChildIndex(Me.txtIdProduccionProceso, 0)
      Me.Controls.SetChildIndex(Me.txtNombreProduccionProceso, 0)
      Me.ResumeLayout(False)
      Me.PerformLayout()

   End Sub
   Friend WithEvents txtNombreProduccionProceso As Eniac.Controles.TextBox
   Friend WithEvents lblNombreProduccionProceso As Eniac.Controles.Label
   Friend WithEvents txtIdProduccionProceso As Eniac.Controles.TextBox
   Friend WithEvents lblIdProduccionProceso As Eniac.Controles.Label
End Class
