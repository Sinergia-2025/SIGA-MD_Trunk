<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ContabilidadEstadosAsientosDetalle
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
      Me.chbPorDefectoManual = New Eniac.Controles.CheckBox()
      Me.chbPorDefectoAutomatico = New Eniac.Controles.CheckBox()
      Me.txtNombre = New Eniac.Controles.TextBox()
      Me.lblNombre = New Eniac.Controles.Label()
      Me.txtCodigo = New Eniac.Controles.TextBox()
      Me.lblCodigo = New Eniac.Controles.Label()
      Me.SuspendLayout()
      '
      'btnAceptar
      '
      Me.btnAceptar.Location = New System.Drawing.Point(179, 119)
      Me.btnAceptar.TabIndex = 6
      '
      'btnCancelar
      '
      Me.btnCancelar.Location = New System.Drawing.Point(265, 119)
      Me.btnCancelar.TabIndex = 7
      '
      'btnCopiar
      '
      Me.btnCopiar.Location = New System.Drawing.Point(78, 119)
      Me.btnCopiar.TabIndex = 9
      '
      'btnAplicar
      '
      Me.btnAplicar.Location = New System.Drawing.Point(21, 119)
      Me.btnAplicar.TabIndex = 8
      '
      'chbPorDefectoManual
      '
      Me.chbPorDefectoManual.AutoSize = True
      Me.chbPorDefectoManual.BindearPropiedadControl = "Checked"
      Me.chbPorDefectoManual.BindearPropiedadEntidad = "PorDefectoManual"
      Me.chbPorDefectoManual.ForeColorFocus = System.Drawing.Color.Red
      Me.chbPorDefectoManual.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
      Me.chbPorDefectoManual.IsPK = False
      Me.chbPorDefectoManual.IsRequired = False
      Me.chbPorDefectoManual.Key = Nothing
      Me.chbPorDefectoManual.LabelAsoc = Nothing
      Me.chbPorDefectoManual.Location = New System.Drawing.Point(13, 64)
      Me.chbPorDefectoManual.Name = "chbPorDefectoManual"
      Me.chbPorDefectoManual.Size = New System.Drawing.Size(121, 17)
      Me.chbPorDefectoManual.TabIndex = 4
      Me.chbPorDefectoManual.Text = "Por Defecto Manual"
      Me.chbPorDefectoManual.UseVisualStyleBackColor = True
      '
      'chbPorDefectoAutomatico
      '
      Me.chbPorDefectoAutomatico.AutoSize = True
      Me.chbPorDefectoAutomatico.BindearPropiedadControl = "Checked"
      Me.chbPorDefectoAutomatico.BindearPropiedadEntidad = "PorDefectoAutomatico"
      Me.chbPorDefectoAutomatico.ForeColorFocus = System.Drawing.Color.Red
      Me.chbPorDefectoAutomatico.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
      Me.chbPorDefectoAutomatico.IsPK = False
      Me.chbPorDefectoAutomatico.IsRequired = False
      Me.chbPorDefectoAutomatico.Key = Nothing
      Me.chbPorDefectoAutomatico.LabelAsoc = Nothing
      Me.chbPorDefectoAutomatico.Location = New System.Drawing.Point(13, 87)
      Me.chbPorDefectoAutomatico.Name = "chbPorDefectoAutomatico"
      Me.chbPorDefectoAutomatico.Size = New System.Drawing.Size(139, 17)
      Me.chbPorDefectoAutomatico.TabIndex = 5
      Me.chbPorDefectoAutomatico.Text = "Por Defecto Automático"
      Me.chbPorDefectoAutomatico.UseVisualStyleBackColor = True
      '
      'txtNombre
      '
      Me.txtNombre.BindearPropiedadControl = "Text"
      Me.txtNombre.BindearPropiedadEntidad = "NombreEstadoAsiento"
      Me.txtNombre.ForeColorFocus = System.Drawing.Color.Red
      Me.txtNombre.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtNombre.Formato = ""
      Me.txtNombre.IsDecimal = False
      Me.txtNombre.IsNumber = False
      Me.txtNombre.IsPK = False
      Me.txtNombre.IsRequired = True
      Me.txtNombre.Key = ""
      Me.txtNombre.LabelAsoc = Me.lblNombre
      Me.txtNombre.Location = New System.Drawing.Point(80, 38)
      Me.txtNombre.MaxLength = 30
      Me.txtNombre.Name = "txtNombre"
      Me.txtNombre.Size = New System.Drawing.Size(250, 20)
      Me.txtNombre.TabIndex = 3
      '
      'lblNombre
      '
      Me.lblNombre.AutoSize = True
      Me.lblNombre.LabelAsoc = Nothing
      Me.lblNombre.Location = New System.Drawing.Point(10, 42)
      Me.lblNombre.Name = "lblNombre"
      Me.lblNombre.Size = New System.Drawing.Size(44, 13)
      Me.lblNombre.TabIndex = 2
      Me.lblNombre.Text = "Nombre"
      '
      'txtCodigo
      '
      Me.txtCodigo.BindearPropiedadControl = "Text"
      Me.txtCodigo.BindearPropiedadEntidad = "IdEstadoAsiento"
      Me.txtCodigo.ForeColorFocus = System.Drawing.Color.Red
      Me.txtCodigo.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtCodigo.Formato = ""
      Me.txtCodigo.IsDecimal = False
      Me.txtCodigo.IsNumber = True
      Me.txtCodigo.IsPK = True
      Me.txtCodigo.IsRequired = True
      Me.txtCodigo.Key = ""
      Me.txtCodigo.LabelAsoc = Me.lblCodigo
      Me.txtCodigo.Location = New System.Drawing.Point(80, 12)
      Me.txtCodigo.Name = "txtCodigo"
      Me.txtCodigo.Size = New System.Drawing.Size(61, 20)
      Me.txtCodigo.TabIndex = 1
      Me.txtCodigo.Text = "0"
      Me.txtCodigo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'lblCodigo
      '
      Me.lblCodigo.AutoSize = True
      Me.lblCodigo.LabelAsoc = Nothing
      Me.lblCodigo.Location = New System.Drawing.Point(10, 16)
      Me.lblCodigo.Name = "lblCodigo"
      Me.lblCodigo.Size = New System.Drawing.Size(40, 13)
      Me.lblCodigo.TabIndex = 0
      Me.lblCodigo.Text = "Código"
      '
      'ContabilidadEstadosAsientosDetalle
      '
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.ClientSize = New System.Drawing.Size(354, 154)
      Me.Controls.Add(Me.txtNombre)
      Me.Controls.Add(Me.txtCodigo)
      Me.Controls.Add(Me.lblNombre)
      Me.Controls.Add(Me.lblCodigo)
      Me.Controls.Add(Me.chbPorDefectoAutomatico)
      Me.Controls.Add(Me.chbPorDefectoManual)
      Me.Name = "ContabilidadEstadosAsientosDetalle"
      Me.Text = "Estado Asiento"
      Me.Controls.SetChildIndex(Me.btnCancelar, 0)
      Me.Controls.SetChildIndex(Me.btnAceptar, 0)
      Me.Controls.SetChildIndex(Me.btnCopiar, 0)
      Me.Controls.SetChildIndex(Me.btnAplicar, 0)
      Me.Controls.SetChildIndex(Me.chbPorDefectoManual, 0)
      Me.Controls.SetChildIndex(Me.chbPorDefectoAutomatico, 0)
      Me.Controls.SetChildIndex(Me.lblCodigo, 0)
      Me.Controls.SetChildIndex(Me.lblNombre, 0)
      Me.Controls.SetChildIndex(Me.txtCodigo, 0)
      Me.Controls.SetChildIndex(Me.txtNombre, 0)
      Me.ResumeLayout(False)
      Me.PerformLayout()

   End Sub
   Friend WithEvents chbPorDefectoManual As Controles.CheckBox
   Friend WithEvents chbPorDefectoAutomatico As Controles.CheckBox
   Friend WithEvents txtNombre As Controles.TextBox
   Friend WithEvents lblNombre As Controles.Label
   Friend WithEvents txtCodigo As Controles.TextBox
   Friend WithEvents lblCodigo As Controles.Label
End Class
