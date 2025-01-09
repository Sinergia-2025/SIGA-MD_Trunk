<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ucConfVentasCajero
   Inherits ucConfBase

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
      Me.chbCajeroIgnorarTipoComprobanteCliente = New Eniac.Controles.CheckBox()
      Me.Label12 = New Eniac.Controles.Label()
      Me.lblIdentifNDebCheqCheq = New Eniac.Controles.Label()
      Me.lblTipoComprobanteEnviadoCajero = New Eniac.Controles.Label()
      Me.txtTiempoDeActAutomatica = New Eniac.Controles.TextBox()
      Me.txtIdentifNDEBCheqRech = New Eniac.Controles.TextBox()
      Me.chbCajerosActualizacionAutomatica = New Eniac.Controles.CheckBox()
      Me.lblTipoComprobanteGeneradoCajero = New Eniac.Controles.Label()
      Me.chbCajerosAbrirVariasVentanasFacturacion = New Eniac.Controles.CheckBox()
      Me.txtTipoComprobanteEnviadoCajero = New Eniac.Controles.TextBox()
      Me.lblCajeroGenera = New Eniac.Controles.Label()
      Me.txtTipoComprobanteGeneradoCajero = New Eniac.Controles.TextBox()
      Me.chbCajeroSeleccionMultiple = New Eniac.Controles.CheckBox()
      Me.cmbCajeroGenera = New Eniac.Controles.ComboBox()
      Me.SuspendLayout()
      '
      'chbCajeroIgnorarTipoComprobanteCliente
      '
      Me.chbCajeroIgnorarTipoComprobanteCliente.AutoSize = True
      Me.chbCajeroIgnorarTipoComprobanteCliente.BindearPropiedadControl = Nothing
      Me.chbCajeroIgnorarTipoComprobanteCliente.BindearPropiedadEntidad = Nothing
      Me.chbCajeroIgnorarTipoComprobanteCliente.ForeColorFocus = System.Drawing.Color.Red
      Me.chbCajeroIgnorarTipoComprobanteCliente.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
      Me.chbCajeroIgnorarTipoComprobanteCliente.IsPK = False
      Me.chbCajeroIgnorarTipoComprobanteCliente.IsRequired = False
      Me.chbCajeroIgnorarTipoComprobanteCliente.Key = Nothing
      Me.chbCajeroIgnorarTipoComprobanteCliente.LabelAsoc = Nothing
      Me.chbCajeroIgnorarTipoComprobanteCliente.Location = New System.Drawing.Point(571, 162)
      Me.chbCajeroIgnorarTipoComprobanteCliente.Name = "chbCajeroIgnorarTipoComprobanteCliente"
      Me.chbCajeroIgnorarTipoComprobanteCliente.Size = New System.Drawing.Size(201, 17)
      Me.chbCajeroIgnorarTipoComprobanteCliente.TabIndex = 72
      Me.chbCajeroIgnorarTipoComprobanteCliente.Text = "Ignorar Tipo Comprobante del Cliente"
      Me.chbCajeroIgnorarTipoComprobanteCliente.UseVisualStyleBackColor = True
      '
      'Label12
      '
      Me.Label12.AutoSize = True
      Me.Label12.ForeColor = System.Drawing.SystemColors.WindowText
      Me.Label12.LabelAsoc = Nothing
      Me.Label12.Location = New System.Drawing.Point(252, 49)
      Me.Label12.Name = "Label12"
      Me.Label12.Size = New System.Drawing.Size(123, 13)
      Me.Label12.TabIndex = 62
      Me.Label12.Text = "Tiempo de Actualizacion"
      '
      'lblIdentifNDebCheqCheq
      '
      Me.lblIdentifNDebCheqCheq.AutoSize = True
      Me.lblIdentifNDebCheqCheq.ForeColor = System.Drawing.SystemColors.WindowText
      Me.lblIdentifNDebCheqCheq.LabelAsoc = Nothing
      Me.lblIdentifNDebCheqCheq.Location = New System.Drawing.Point(14, 111)
      Me.lblIdentifNDebCheqCheq.Name = "lblIdentifNDebCheqCheq"
      Me.lblIdentifNDebCheqCheq.Size = New System.Drawing.Size(200, 13)
      Me.lblIdentifNDebCheqCheq.TabIndex = 66
      Me.lblIdentifNDebCheqCheq.Text = "Identif. de N.Debito Cheque  Rechazado"
      '
      'lblTipoComprobanteEnviadoCajero
      '
      Me.lblTipoComprobanteEnviadoCajero.AutoSize = True
      Me.lblTipoComprobanteEnviadoCajero.ForeColor = System.Drawing.SystemColors.WindowText
      Me.lblTipoComprobanteEnviadoCajero.LabelAsoc = Nothing
      Me.lblTipoComprobanteEnviadoCajero.Location = New System.Drawing.Point(14, 137)
      Me.lblTipoComprobanteEnviadoCajero.Name = "lblTipoComprobanteEnviadoCajero"
      Me.lblTipoComprobanteEnviadoCajero.Size = New System.Drawing.Size(317, 13)
      Me.lblTipoComprobanteEnviadoCajero.TabIndex = 68
      Me.lblTipoComprobanteEnviadoCajero.Text = "Tipos de comprobantes que se envian a Cajero (separado por "";"")"
      '
      'txtTiempoDeActAutomatica
      '
      Me.txtTiempoDeActAutomatica.BindearPropiedadControl = Nothing
      Me.txtTiempoDeActAutomatica.BindearPropiedadEntidad = Nothing
      Me.txtTiempoDeActAutomatica.ForeColorFocus = System.Drawing.Color.Red
      Me.txtTiempoDeActAutomatica.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtTiempoDeActAutomatica.Formato = "#0"
      Me.txtTiempoDeActAutomatica.IsDecimal = True
      Me.txtTiempoDeActAutomatica.IsNumber = True
      Me.txtTiempoDeActAutomatica.IsPK = False
      Me.txtTiempoDeActAutomatica.IsRequired = False
      Me.txtTiempoDeActAutomatica.Key = ""
      Me.txtTiempoDeActAutomatica.LabelAsoc = Nothing
      Me.txtTiempoDeActAutomatica.Location = New System.Drawing.Point(214, 45)
      Me.txtTiempoDeActAutomatica.MaxLength = 6
      Me.txtTiempoDeActAutomatica.Name = "txtTiempoDeActAutomatica"
      Me.txtTiempoDeActAutomatica.Size = New System.Drawing.Size(35, 20)
      Me.txtTiempoDeActAutomatica.TabIndex = 61
      Me.txtTiempoDeActAutomatica.Tag = ""
      Me.txtTiempoDeActAutomatica.Text = "0"
      Me.txtTiempoDeActAutomatica.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
      '
      'txtIdentifNDEBCheqRech
      '
      Me.txtIdentifNDEBCheqRech.BindearPropiedadControl = Nothing
      Me.txtIdentifNDEBCheqRech.BindearPropiedadEntidad = Nothing
      Me.txtIdentifNDEBCheqRech.ForeColorFocus = System.Drawing.Color.Red
      Me.txtIdentifNDEBCheqRech.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtIdentifNDEBCheqRech.Formato = ""
      Me.txtIdentifNDEBCheqRech.IsDecimal = False
      Me.txtIdentifNDEBCheqRech.IsNumber = False
      Me.txtIdentifNDEBCheqRech.IsPK = False
      Me.txtIdentifNDEBCheqRech.IsRequired = False
      Me.txtIdentifNDEBCheqRech.Key = ""
      Me.txtIdentifNDEBCheqRech.LabelAsoc = Me.lblIdentifNDebCheqCheq
      Me.txtIdentifNDEBCheqRech.Location = New System.Drawing.Point(337, 108)
      Me.txtIdentifNDEBCheqRech.MaxLength = 200
      Me.txtIdentifNDEBCheqRech.Name = "txtIdentifNDEBCheqRech"
      Me.txtIdentifNDEBCheqRech.Size = New System.Drawing.Size(550, 20)
      Me.txtIdentifNDEBCheqRech.TabIndex = 67
      Me.txtIdentifNDEBCheqRech.Tag = "NDEBCHEQRECH"
      Me.txtIdentifNDEBCheqRech.Text = "NDEBCHEQRECH"
      '
      'chbCajerosActualizacionAutomatica
      '
      Me.chbCajerosActualizacionAutomatica.BindearPropiedadControl = Nothing
      Me.chbCajerosActualizacionAutomatica.BindearPropiedadEntidad = Nothing
      Me.chbCajerosActualizacionAutomatica.ForeColorFocus = System.Drawing.Color.Red
      Me.chbCajerosActualizacionAutomatica.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
      Me.chbCajerosActualizacionAutomatica.IsPK = False
      Me.chbCajerosActualizacionAutomatica.IsRequired = False
      Me.chbCajerosActualizacionAutomatica.Key = Nothing
      Me.chbCajerosActualizacionAutomatica.LabelAsoc = Nothing
      Me.chbCajerosActualizacionAutomatica.Location = New System.Drawing.Point(17, 44)
      Me.chbCajerosActualizacionAutomatica.Name = "chbCajerosActualizacionAutomatica"
      Me.chbCajerosActualizacionAutomatica.Size = New System.Drawing.Size(308, 24)
      Me.chbCajerosActualizacionAutomatica.TabIndex = 60
      Me.chbCajerosActualizacionAutomatica.Tag = ""
      Me.chbCajerosActualizacionAutomatica.Text = "Permitir Actualizacion Automatica"
      Me.chbCajerosActualizacionAutomatica.UseVisualStyleBackColor = True
      '
      'lblTipoComprobanteGeneradoCajero
      '
      Me.lblTipoComprobanteGeneradoCajero.AutoSize = True
      Me.lblTipoComprobanteGeneradoCajero.ForeColor = System.Drawing.SystemColors.WindowText
      Me.lblTipoComprobanteGeneradoCajero.LabelAsoc = Nothing
      Me.lblTipoComprobanteGeneradoCajero.Location = New System.Drawing.Point(14, 163)
      Me.lblTipoComprobanteGeneradoCajero.Name = "lblTipoComprobanteGeneradoCajero"
      Me.lblTipoComprobanteGeneradoCajero.Size = New System.Drawing.Size(231, 13)
      Me.lblTipoComprobanteGeneradoCajero.TabIndex = 70
      Me.lblTipoComprobanteGeneradoCajero.Text = "Tipos de comprobantes generado desde Cajero"
      '
      'chbCajerosAbrirVariasVentanasFacturacion
      '
      Me.chbCajerosAbrirVariasVentanasFacturacion.BindearPropiedadControl = Nothing
      Me.chbCajerosAbrirVariasVentanasFacturacion.BindearPropiedadEntidad = Nothing
      Me.chbCajerosAbrirVariasVentanasFacturacion.ForeColorFocus = System.Drawing.Color.Red
      Me.chbCajerosAbrirVariasVentanasFacturacion.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
      Me.chbCajerosAbrirVariasVentanasFacturacion.IsPK = False
      Me.chbCajerosAbrirVariasVentanasFacturacion.IsRequired = False
      Me.chbCajerosAbrirVariasVentanasFacturacion.Key = Nothing
      Me.chbCajerosAbrirVariasVentanasFacturacion.LabelAsoc = Nothing
      Me.chbCajerosAbrirVariasVentanasFacturacion.Location = New System.Drawing.Point(17, 14)
      Me.chbCajerosAbrirVariasVentanasFacturacion.Name = "chbCajerosAbrirVariasVentanasFacturacion"
      Me.chbCajerosAbrirVariasVentanasFacturacion.Size = New System.Drawing.Size(308, 24)
      Me.chbCajerosAbrirVariasVentanasFacturacion.TabIndex = 59
      Me.chbCajerosAbrirVariasVentanasFacturacion.Tag = ""
      Me.chbCajerosAbrirVariasVentanasFacturacion.Text = "Permitir Abrir Varias Ventanas de Facturacion"
      Me.chbCajerosAbrirVariasVentanasFacturacion.UseVisualStyleBackColor = True
      '
      'txtTipoComprobanteEnviadoCajero
      '
      Me.txtTipoComprobanteEnviadoCajero.BindearPropiedadControl = Nothing
      Me.txtTipoComprobanteEnviadoCajero.BindearPropiedadEntidad = Nothing
      Me.txtTipoComprobanteEnviadoCajero.ForeColorFocus = System.Drawing.Color.Red
      Me.txtTipoComprobanteEnviadoCajero.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtTipoComprobanteEnviadoCajero.Formato = ""
      Me.txtTipoComprobanteEnviadoCajero.IsDecimal = False
      Me.txtTipoComprobanteEnviadoCajero.IsNumber = False
      Me.txtTipoComprobanteEnviadoCajero.IsPK = False
      Me.txtTipoComprobanteEnviadoCajero.IsRequired = False
      Me.txtTipoComprobanteEnviadoCajero.Key = ""
      Me.txtTipoComprobanteEnviadoCajero.LabelAsoc = Me.lblTipoComprobanteEnviadoCajero
      Me.txtTipoComprobanteEnviadoCajero.Location = New System.Drawing.Point(337, 134)
      Me.txtTipoComprobanteEnviadoCajero.MaxLength = 110
      Me.txtTipoComprobanteEnviadoCajero.Name = "txtTipoComprobanteEnviadoCajero"
      Me.txtTipoComprobanteEnviadoCajero.Size = New System.Drawing.Size(550, 20)
      Me.txtTipoComprobanteEnviadoCajero.TabIndex = 69
      '
      'lblCajeroGenera
      '
      Me.lblCajeroGenera.AutoSize = True
      Me.lblCajeroGenera.ForeColor = System.Drawing.SystemColors.WindowText
      Me.lblCajeroGenera.LabelAsoc = Nothing
      Me.lblCajeroGenera.Location = New System.Drawing.Point(14, 77)
      Me.lblCajeroGenera.Name = "lblCajeroGenera"
      Me.lblCajeroGenera.Size = New System.Drawing.Size(120, 13)
      Me.lblCajeroGenera.TabIndex = 63
      Me.lblCajeroGenera.Text = "Al cobrar Cajero Genera"
      '
      'txtTipoComprobanteGeneradoCajero
      '
      Me.txtTipoComprobanteGeneradoCajero.BindearPropiedadControl = Nothing
      Me.txtTipoComprobanteGeneradoCajero.BindearPropiedadEntidad = Nothing
      Me.txtTipoComprobanteGeneradoCajero.ForeColorFocus = System.Drawing.Color.Red
      Me.txtTipoComprobanteGeneradoCajero.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtTipoComprobanteGeneradoCajero.Formato = ""
      Me.txtTipoComprobanteGeneradoCajero.IsDecimal = False
      Me.txtTipoComprobanteGeneradoCajero.IsNumber = False
      Me.txtTipoComprobanteGeneradoCajero.IsPK = False
      Me.txtTipoComprobanteGeneradoCajero.IsRequired = False
      Me.txtTipoComprobanteGeneradoCajero.Key = ""
      Me.txtTipoComprobanteGeneradoCajero.LabelAsoc = Me.lblTipoComprobanteGeneradoCajero
      Me.txtTipoComprobanteGeneradoCajero.Location = New System.Drawing.Point(337, 160)
      Me.txtTipoComprobanteGeneradoCajero.MaxLength = 20
      Me.txtTipoComprobanteGeneradoCajero.Name = "txtTipoComprobanteGeneradoCajero"
      Me.txtTipoComprobanteGeneradoCajero.Size = New System.Drawing.Size(228, 20)
      Me.txtTipoComprobanteGeneradoCajero.TabIndex = 71
      '
      'chbCajeroSeleccionMultiple
      '
      Me.chbCajeroSeleccionMultiple.AutoSize = True
      Me.chbCajeroSeleccionMultiple.BindearPropiedadControl = Nothing
      Me.chbCajeroSeleccionMultiple.BindearPropiedadEntidad = Nothing
      Me.chbCajeroSeleccionMultiple.ForeColorFocus = System.Drawing.Color.Red
      Me.chbCajeroSeleccionMultiple.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
      Me.chbCajeroSeleccionMultiple.IsPK = False
      Me.chbCajeroSeleccionMultiple.IsRequired = False
      Me.chbCajeroSeleccionMultiple.Key = Nothing
      Me.chbCajeroSeleccionMultiple.LabelAsoc = Nothing
      Me.chbCajeroSeleccionMultiple.Location = New System.Drawing.Point(255, 76)
      Me.chbCajeroSeleccionMultiple.Name = "chbCajeroSeleccionMultiple"
      Me.chbCajeroSeleccionMultiple.Size = New System.Drawing.Size(182, 17)
      Me.chbCajeroSeleccionMultiple.TabIndex = 65
      Me.chbCajeroSeleccionMultiple.Text = "Cajero: Permitir selección múltiple"
      Me.chbCajeroSeleccionMultiple.UseVisualStyleBackColor = True
      '
      'cmbCajeroGenera
      '
      Me.cmbCajeroGenera.BindearPropiedadControl = Nothing
      Me.cmbCajeroGenera.BindearPropiedadEntidad = Nothing
      Me.cmbCajeroGenera.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cmbCajeroGenera.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.cmbCajeroGenera.ForeColorFocus = System.Drawing.Color.Red
      Me.cmbCajeroGenera.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.cmbCajeroGenera.FormattingEnabled = True
      Me.cmbCajeroGenera.IsPK = False
      Me.cmbCajeroGenera.IsRequired = False
      Me.cmbCajeroGenera.Items.AddRange(New Object() {"FACTURACION", "LISTADO"})
      Me.cmbCajeroGenera.Key = Nothing
      Me.cmbCajeroGenera.LabelAsoc = Me.lblCajeroGenera
      Me.cmbCajeroGenera.Location = New System.Drawing.Point(140, 74)
      Me.cmbCajeroGenera.Name = "cmbCajeroGenera"
      Me.cmbCajeroGenera.Size = New System.Drawing.Size(109, 21)
      Me.cmbCajeroGenera.TabIndex = 64
      '
      'ucConfVentasCajero
      '
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.Controls.Add(Me.chbCajeroIgnorarTipoComprobanteCliente)
      Me.Controls.Add(Me.Label12)
      Me.Controls.Add(Me.lblIdentifNDebCheqCheq)
      Me.Controls.Add(Me.lblTipoComprobanteEnviadoCajero)
      Me.Controls.Add(Me.txtTiempoDeActAutomatica)
      Me.Controls.Add(Me.txtIdentifNDEBCheqRech)
      Me.Controls.Add(Me.chbCajerosActualizacionAutomatica)
      Me.Controls.Add(Me.lblTipoComprobanteGeneradoCajero)
      Me.Controls.Add(Me.chbCajerosAbrirVariasVentanasFacturacion)
      Me.Controls.Add(Me.txtTipoComprobanteEnviadoCajero)
      Me.Controls.Add(Me.lblCajeroGenera)
      Me.Controls.Add(Me.txtTipoComprobanteGeneradoCajero)
      Me.Controls.Add(Me.chbCajeroSeleccionMultiple)
      Me.Controls.Add(Me.cmbCajeroGenera)
      Me.Name = "ucConfVentasCajero"
      Me.Controls.SetChildIndex(Me.cmbCajeroGenera, 0)
      Me.Controls.SetChildIndex(Me.chbCajeroSeleccionMultiple, 0)
      Me.Controls.SetChildIndex(Me.txtTipoComprobanteGeneradoCajero, 0)
      Me.Controls.SetChildIndex(Me.lblCajeroGenera, 0)
      Me.Controls.SetChildIndex(Me.txtTipoComprobanteEnviadoCajero, 0)
      Me.Controls.SetChildIndex(Me.chbCajerosAbrirVariasVentanasFacturacion, 0)
      Me.Controls.SetChildIndex(Me.lblTipoComprobanteGeneradoCajero, 0)
      Me.Controls.SetChildIndex(Me.chbCajerosActualizacionAutomatica, 0)
      Me.Controls.SetChildIndex(Me.txtIdentifNDEBCheqRech, 0)
      Me.Controls.SetChildIndex(Me.txtTiempoDeActAutomatica, 0)
      Me.Controls.SetChildIndex(Me.lblTipoComprobanteEnviadoCajero, 0)
      Me.Controls.SetChildIndex(Me.lblIdentifNDebCheqCheq, 0)
      Me.Controls.SetChildIndex(Me.Label12, 0)
      Me.Controls.SetChildIndex(Me.chbCajeroIgnorarTipoComprobanteCliente, 0)
      Me.ResumeLayout(False)
      Me.PerformLayout()

   End Sub

   Friend WithEvents chbCajeroIgnorarTipoComprobanteCliente As Controles.CheckBox
   Friend WithEvents Label12 As Controles.Label
   Friend WithEvents lblIdentifNDebCheqCheq As Controles.Label
   Friend WithEvents lblTipoComprobanteEnviadoCajero As Controles.Label
   Friend WithEvents txtTiempoDeActAutomatica As Controles.TextBox
   Friend WithEvents txtIdentifNDEBCheqRech As Controles.TextBox
   Friend WithEvents chbCajerosActualizacionAutomatica As Controles.CheckBox
   Friend WithEvents lblTipoComprobanteGeneradoCajero As Controles.Label
   Friend WithEvents chbCajerosAbrirVariasVentanasFacturacion As Controles.CheckBox
   Friend WithEvents txtTipoComprobanteEnviadoCajero As Controles.TextBox
   Friend WithEvents lblCajeroGenera As Controles.Label
   Friend WithEvents txtTipoComprobanteGeneradoCajero As Controles.TextBox
   Friend WithEvents chbCajeroSeleccionMultiple As Controles.CheckBox
   Friend WithEvents cmbCajeroGenera As Controles.ComboBox
End Class
