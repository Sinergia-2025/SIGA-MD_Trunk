<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MRPAQLBDetalle
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
      Me.txtLimiteCalidadAceptable = New Eniac.Controles.TextBox()
      Me.lblLimiteCalidadAceptable = New Eniac.Controles.Label()
      Me.lblCodigoNivel = New Eniac.Controles.Label()
      Me.txtCodigoNivel = New Eniac.Controles.TextBox()
      Me.txtTamanoMuestreo = New Eniac.Controles.TextBox()
      Me.lblTamanoMuestreo = New Eniac.Controles.Label()
      Me.txtCantidadAceptacion = New Eniac.Controles.TextBox()
      Me.lblCantidadAceptacion = New Eniac.Controles.Label()
      Me.txtCantidadRechazo = New Eniac.Controles.TextBox()
      Me.lblCantidadRechazo = New Eniac.Controles.Label()
        Me.SuspendLayout()
        '
        'btnAceptar
        '
        Me.btnAceptar.Location = New System.Drawing.Point(87, 180)
        Me.btnAceptar.TabIndex = 10
        '
        'btnCancelar
        '
        Me.btnCancelar.Location = New System.Drawing.Point(173, 180)
        Me.btnCancelar.TabIndex = 11
        '
        'btnCopiar
        '
        Me.btnCopiar.Location = New System.Drawing.Point(-14, 180)
        Me.btnCopiar.TabIndex = 13
        '
        'btnAplicar
        '
        Me.btnAplicar.Location = New System.Drawing.Point(-71, 180)
        Me.btnAplicar.TabIndex = 12
        '
        'txtLimiteCalidadAceptable
        '
        Me.txtLimiteCalidadAceptable.BindearPropiedadControl = "Text"
        Me.txtLimiteCalidadAceptable.BindearPropiedadEntidad = "LimiteCalidadAceptable"
        Me.txtLimiteCalidadAceptable.ForeColorFocus = System.Drawing.Color.Red
        Me.txtLimiteCalidadAceptable.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtLimiteCalidadAceptable.Formato = "N4"
        Me.txtLimiteCalidadAceptable.IsDecimal = True
        Me.txtLimiteCalidadAceptable.IsNumber = True
        Me.txtLimiteCalidadAceptable.IsPK = True
        Me.txtLimiteCalidadAceptable.IsRequired = True
        Me.txtLimiteCalidadAceptable.Key = ""
        Me.txtLimiteCalidadAceptable.LabelAsoc = Me.lblLimiteCalidadAceptable
        Me.txtLimiteCalidadAceptable.Location = New System.Drawing.Point(177, 25)
        Me.txtLimiteCalidadAceptable.MaxLength = 12
        Me.txtLimiteCalidadAceptable.Name = "txtLimiteCalidadAceptable"
        Me.txtLimiteCalidadAceptable.Size = New System.Drawing.Size(65, 20)
        Me.txtLimiteCalidadAceptable.TabIndex = 1
        Me.txtLimiteCalidadAceptable.Text = "0.0000"
        Me.txtLimiteCalidadAceptable.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblLimiteCalidadAceptable
        '
        Me.lblLimiteCalidadAceptable.AutoSize = True
        Me.lblLimiteCalidadAceptable.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblLimiteCalidadAceptable.LabelAsoc = Nothing
        Me.lblLimiteCalidadAceptable.Location = New System.Drawing.Point(31, 29)
        Me.lblLimiteCalidadAceptable.Name = "lblLimiteCalidadAceptable"
        Me.lblLimiteCalidadAceptable.Size = New System.Drawing.Size(140, 13)
        Me.lblLimiteCalidadAceptable.TabIndex = 0
        Me.lblLimiteCalidadAceptable.Text = "Límite de Calidad Aceptable"
        '
        'lblCodigoNivel
        '
        Me.lblCodigoNivel.AutoSize = True
        Me.lblCodigoNivel.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblCodigoNivel.LabelAsoc = Nothing
        Me.lblCodigoNivel.Location = New System.Drawing.Point(31, 55)
        Me.lblCodigoNivel.Name = "lblCodigoNivel"
        Me.lblCodigoNivel.Size = New System.Drawing.Size(82, 13)
        Me.lblCodigoNivel.TabIndex = 2
        Me.lblCodigoNivel.Text = "Código de Nivel"
        '
        'txtCodigoNivel
        '
        Me.txtCodigoNivel.BindearPropiedadControl = "Text"
        Me.txtCodigoNivel.BindearPropiedadEntidad = "CodigoNivel"
        Me.txtCodigoNivel.ForeColorFocus = System.Drawing.Color.Red
        Me.txtCodigoNivel.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtCodigoNivel.Formato = ""
        Me.txtCodigoNivel.IsDecimal = False
        Me.txtCodigoNivel.IsNumber = False
        Me.txtCodigoNivel.IsPK = True
        Me.txtCodigoNivel.IsRequired = True
        Me.txtCodigoNivel.Key = ""
        Me.txtCodigoNivel.LabelAsoc = Me.lblCodigoNivel
        Me.txtCodigoNivel.Location = New System.Drawing.Point(177, 51)
        Me.txtCodigoNivel.MaxLength = 1
        Me.txtCodigoNivel.Name = "txtCodigoNivel"
        Me.txtCodigoNivel.Size = New System.Drawing.Size(30, 20)
        Me.txtCodigoNivel.TabIndex = 3
        '
        'txtTamanoMuestreo
        '
        Me.txtTamanoMuestreo.BindearPropiedadControl = "Text"
        Me.txtTamanoMuestreo.BindearPropiedadEntidad = "TamanoMuestreo"
        Me.txtTamanoMuestreo.ForeColorFocus = System.Drawing.Color.Red
        Me.txtTamanoMuestreo.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtTamanoMuestreo.Formato = ""
        Me.txtTamanoMuestreo.IsDecimal = False
        Me.txtTamanoMuestreo.IsNumber = True
        Me.txtTamanoMuestreo.IsPK = False
        Me.txtTamanoMuestreo.IsRequired = True
        Me.txtTamanoMuestreo.Key = ""
        Me.txtTamanoMuestreo.LabelAsoc = Me.lblTamanoMuestreo
        Me.txtTamanoMuestreo.Location = New System.Drawing.Point(177, 77)
        Me.txtTamanoMuestreo.MaxLength = 12
        Me.txtTamanoMuestreo.Name = "txtTamanoMuestreo"
        Me.txtTamanoMuestreo.Size = New System.Drawing.Size(65, 20)
        Me.txtTamanoMuestreo.TabIndex = 5
        Me.txtTamanoMuestreo.Text = "0"
        Me.txtTamanoMuestreo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblTamanoMuestreo
        '
        Me.lblTamanoMuestreo.AutoSize = True
        Me.lblTamanoMuestreo.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblTamanoMuestreo.LabelAsoc = Nothing
        Me.lblTamanoMuestreo.Location = New System.Drawing.Point(31, 81)
        Me.lblTamanoMuestreo.Name = "lblTamanoMuestreo"
        Me.lblTamanoMuestreo.Size = New System.Drawing.Size(93, 13)
        Me.lblTamanoMuestreo.TabIndex = 4
        Me.lblTamanoMuestreo.Text = "Tamaño Muestreo"
        '
        'txtCantidadAceptacion
        '
        Me.txtCantidadAceptacion.BindearPropiedadControl = "Text"
        Me.txtCantidadAceptacion.BindearPropiedadEntidad = "CantidadAceptacion"
        Me.txtCantidadAceptacion.ForeColorFocus = System.Drawing.Color.Red
        Me.txtCantidadAceptacion.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtCantidadAceptacion.Formato = ""
        Me.txtCantidadAceptacion.IsDecimal = False
        Me.txtCantidadAceptacion.IsNumber = True
        Me.txtCantidadAceptacion.IsPK = False
        Me.txtCantidadAceptacion.IsRequired = True
        Me.txtCantidadAceptacion.Key = ""
        Me.txtCantidadAceptacion.LabelAsoc = Me.lblCantidadAceptacion
        Me.txtCantidadAceptacion.Location = New System.Drawing.Point(177, 103)
        Me.txtCantidadAceptacion.MaxLength = 12
        Me.txtCantidadAceptacion.Name = "txtCantidadAceptacion"
        Me.txtCantidadAceptacion.Size = New System.Drawing.Size(65, 20)
        Me.txtCantidadAceptacion.TabIndex = 7
        Me.txtCantidadAceptacion.Text = "0"
        Me.txtCantidadAceptacion.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblCantidadAceptacion
        '
        Me.lblCantidadAceptacion.AutoSize = True
        Me.lblCantidadAceptacion.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblCantidadAceptacion.LabelAsoc = Nothing
        Me.lblCantidadAceptacion.Location = New System.Drawing.Point(31, 107)
        Me.lblCantidadAceptacion.Name = "lblCantidadAceptacion"
        Me.lblCantidadAceptacion.Size = New System.Drawing.Size(106, 13)
        Me.lblCantidadAceptacion.TabIndex = 6
        Me.lblCantidadAceptacion.Text = "Cantidad Aceptación"
        '
        'txtCantidadRechazo
        '
        Me.txtCantidadRechazo.BindearPropiedadControl = "Text"
        Me.txtCantidadRechazo.BindearPropiedadEntidad = "CantidadRechazo"
        Me.txtCantidadRechazo.ForeColorFocus = System.Drawing.Color.Red
        Me.txtCantidadRechazo.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtCantidadRechazo.Formato = ""
        Me.txtCantidadRechazo.IsDecimal = False
        Me.txtCantidadRechazo.IsNumber = True
        Me.txtCantidadRechazo.IsPK = False
        Me.txtCantidadRechazo.IsRequired = True
        Me.txtCantidadRechazo.Key = ""
        Me.txtCantidadRechazo.LabelAsoc = Me.lblCantidadRechazo
        Me.txtCantidadRechazo.Location = New System.Drawing.Point(177, 129)
        Me.txtCantidadRechazo.MaxLength = 12
        Me.txtCantidadRechazo.Name = "txtCantidadRechazo"
        Me.txtCantidadRechazo.Size = New System.Drawing.Size(65, 20)
        Me.txtCantidadRechazo.TabIndex = 9
        Me.txtCantidadRechazo.Text = "0"
        Me.txtCantidadRechazo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblCantidadRechazo
        '
        Me.lblCantidadRechazo.AutoSize = True
        Me.lblCantidadRechazo.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblCantidadRechazo.LabelAsoc = Nothing
        Me.lblCantidadRechazo.Location = New System.Drawing.Point(31, 133)
        Me.lblCantidadRechazo.Name = "lblCantidadRechazo"
        Me.lblCantidadRechazo.Size = New System.Drawing.Size(95, 13)
        Me.lblCantidadRechazo.TabIndex = 8
        Me.lblCantidadRechazo.Text = "Cantidad Rechazo"
        '
        'MRPAQLBDetalle
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(262, 215)
        Me.Controls.Add(Me.txtCantidadRechazo)
        Me.Controls.Add(Me.lblCantidadRechazo)
        Me.Controls.Add(Me.txtCantidadAceptacion)
        Me.Controls.Add(Me.lblCantidadAceptacion)
        Me.Controls.Add(Me.txtTamanoMuestreo)
        Me.Controls.Add(Me.lblTamanoMuestreo)
        Me.Controls.Add(Me.txtLimiteCalidadAceptable)
        Me.Controls.Add(Me.lblLimiteCalidadAceptable)
        Me.Controls.Add(Me.lblCodigoNivel)
        Me.Controls.Add(Me.txtCodigoNivel)
        Me.Name = "MRPAQLBDetalle"
        Me.Text = "MRP AQL B"
        Me.Controls.SetChildIndex(Me.btnCancelar, 0)
        Me.Controls.SetChildIndex(Me.btnAceptar, 0)
        Me.Controls.SetChildIndex(Me.btnCopiar, 0)
        Me.Controls.SetChildIndex(Me.btnAplicar, 0)
        Me.Controls.SetChildIndex(Me.txtCodigoNivel, 0)
        Me.Controls.SetChildIndex(Me.lblCodigoNivel, 0)
        Me.Controls.SetChildIndex(Me.lblLimiteCalidadAceptable, 0)
        Me.Controls.SetChildIndex(Me.txtLimiteCalidadAceptable, 0)
        Me.Controls.SetChildIndex(Me.lblTamanoMuestreo, 0)
        Me.Controls.SetChildIndex(Me.txtTamanoMuestreo, 0)
        Me.Controls.SetChildIndex(Me.lblCantidadAceptacion, 0)
        Me.Controls.SetChildIndex(Me.txtCantidadAceptacion, 0)
        Me.Controls.SetChildIndex(Me.lblCantidadRechazo, 0)
        Me.Controls.SetChildIndex(Me.txtCantidadRechazo, 0)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents txtLimiteCalidadAceptable As Controles.TextBox
   Friend WithEvents lblLimiteCalidadAceptable As Controles.Label
   Friend WithEvents lblCodigoNivel As Controles.Label
   Friend WithEvents txtCodigoNivel As Controles.TextBox
   Friend WithEvents txtTamanoMuestreo As Controles.TextBox
   Friend WithEvents lblTamanoMuestreo As Controles.Label
   Friend WithEvents txtCantidadAceptacion As Controles.TextBox
   Friend WithEvents lblCantidadAceptacion As Controles.Label
   Friend WithEvents txtCantidadRechazo As Controles.TextBox
   Friend WithEvents lblCantidadRechazo As Controles.Label
End Class
