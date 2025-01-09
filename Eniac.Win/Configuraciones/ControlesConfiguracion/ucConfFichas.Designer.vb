<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ucConfFichas
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
      Me.grpFichasSinReferenciaCuota = New System.Windows.Forms.GroupBox()
      Me.rbtFichasSinReferenciaCuota_AvisarPermitir = New System.Windows.Forms.RadioButton()
      Me.rbtFichasSinReferenciaCuota_NoPermitir = New System.Windows.Forms.RadioButton()
      Me.rbtFichasSinReferenciaCuota_Permitir = New System.Windows.Forms.RadioButton()
      Me.chbFichasImprimeCobrosFormatoRecibo = New Eniac.Controles.CheckBox()
      Me.chbFichasPreguntaReemplazarComprobante = New Eniac.Controles.CheckBox()
      Me.chbFichasPermiteCambiarFormaDePago = New Eniac.Controles.CheckBox()
      Me.chbFichasActualizaPreciosDeVenta = New Eniac.Controles.CheckBox()
      Me.grpFichasSinReferenciaCuota.SuspendLayout()
      Me.SuspendLayout()
      '
      'grpFichasSinReferenciaCuota
      '
      Me.grpFichasSinReferenciaCuota.Controls.Add(Me.rbtFichasSinReferenciaCuota_AvisarPermitir)
      Me.grpFichasSinReferenciaCuota.Controls.Add(Me.rbtFichasSinReferenciaCuota_NoPermitir)
      Me.grpFichasSinReferenciaCuota.Controls.Add(Me.rbtFichasSinReferenciaCuota_Permitir)
      Me.grpFichasSinReferenciaCuota.Location = New System.Drawing.Point(24, 159)
      Me.grpFichasSinReferenciaCuota.Name = "grpFichasSinReferenciaCuota"
      Me.grpFichasSinReferenciaCuota.Size = New System.Drawing.Size(319, 53)
      Me.grpFichasSinReferenciaCuota.TabIndex = 63
      Me.grpFichasSinReferenciaCuota.TabStop = False
      Me.grpFichasSinReferenciaCuota.Text = "Fichas Sin Referencia de Cuota"
      '
      'rbtFichasSinReferenciaCuota_AvisarPermitir
      '
      Me.rbtFichasSinReferenciaCuota_AvisarPermitir.AutoSize = True
      Me.rbtFichasSinReferenciaCuota_AvisarPermitir.Location = New System.Drawing.Point(201, 24)
      Me.rbtFichasSinReferenciaCuota_AvisarPermitir.Name = "rbtFichasSinReferenciaCuota_AvisarPermitir"
      Me.rbtFichasSinReferenciaCuota_AvisarPermitir.Size = New System.Drawing.Size(99, 17)
      Me.rbtFichasSinReferenciaCuota_AvisarPermitir.TabIndex = 2
      Me.rbtFichasSinReferenciaCuota_AvisarPermitir.Tag = "AVISARYPERMITIR"
      Me.rbtFichasSinReferenciaCuota_AvisarPermitir.Text = "Avisar y Permitir"
      Me.rbtFichasSinReferenciaCuota_AvisarPermitir.UseVisualStyleBackColor = True
      '
      'rbtFichasSinReferenciaCuota_NoPermitir
      '
      Me.rbtFichasSinReferenciaCuota_NoPermitir.AutoSize = True
      Me.rbtFichasSinReferenciaCuota_NoPermitir.Location = New System.Drawing.Point(99, 24)
      Me.rbtFichasSinReferenciaCuota_NoPermitir.Name = "rbtFichasSinReferenciaCuota_NoPermitir"
      Me.rbtFichasSinReferenciaCuota_NoPermitir.Size = New System.Drawing.Size(76, 17)
      Me.rbtFichasSinReferenciaCuota_NoPermitir.TabIndex = 1
      Me.rbtFichasSinReferenciaCuota_NoPermitir.Tag = "NOPERMITIR"
      Me.rbtFichasSinReferenciaCuota_NoPermitir.Text = "No Permitir"
      Me.rbtFichasSinReferenciaCuota_NoPermitir.UseVisualStyleBackColor = True
      '
      'rbtFichasSinReferenciaCuota_Permitir
      '
      Me.rbtFichasSinReferenciaCuota_Permitir.AutoSize = True
      Me.rbtFichasSinReferenciaCuota_Permitir.Checked = True
      Me.rbtFichasSinReferenciaCuota_Permitir.Location = New System.Drawing.Point(21, 24)
      Me.rbtFichasSinReferenciaCuota_Permitir.Name = "rbtFichasSinReferenciaCuota_Permitir"
      Me.rbtFichasSinReferenciaCuota_Permitir.Size = New System.Drawing.Size(59, 17)
      Me.rbtFichasSinReferenciaCuota_Permitir.TabIndex = 0
      Me.rbtFichasSinReferenciaCuota_Permitir.TabStop = True
      Me.rbtFichasSinReferenciaCuota_Permitir.Tag = "PERMITIR"
      Me.rbtFichasSinReferenciaCuota_Permitir.Text = "Permitir"
      Me.rbtFichasSinReferenciaCuota_Permitir.UseVisualStyleBackColor = True
      '
      'chbFichasImprimeCobrosFormatoRecibo
      '
      Me.chbFichasImprimeCobrosFormatoRecibo.BindearPropiedadControl = Nothing
      Me.chbFichasImprimeCobrosFormatoRecibo.BindearPropiedadEntidad = Nothing
      Me.chbFichasImprimeCobrosFormatoRecibo.ForeColorFocus = System.Drawing.Color.Red
      Me.chbFichasImprimeCobrosFormatoRecibo.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
      Me.chbFichasImprimeCobrosFormatoRecibo.IsPK = False
      Me.chbFichasImprimeCobrosFormatoRecibo.IsRequired = False
      Me.chbFichasImprimeCobrosFormatoRecibo.Key = Nothing
      Me.chbFichasImprimeCobrosFormatoRecibo.LabelAsoc = Nothing
      Me.chbFichasImprimeCobrosFormatoRecibo.Location = New System.Drawing.Point(24, 127)
      Me.chbFichasImprimeCobrosFormatoRecibo.Name = "chbFichasImprimeCobrosFormatoRecibo"
      Me.chbFichasImprimeCobrosFormatoRecibo.Size = New System.Drawing.Size(336, 26)
      Me.chbFichasImprimeCobrosFormatoRecibo.TabIndex = 62
      Me.chbFichasImprimeCobrosFormatoRecibo.Tag = ""
      Me.chbFichasImprimeCobrosFormatoRecibo.Text = "Imprimir Anticipo y Cobros con el mismo formato que los Recibos"
      Me.chbFichasImprimeCobrosFormatoRecibo.UseVisualStyleBackColor = True
      '
      'chbFichasPreguntaReemplazarComprobante
      '
      Me.chbFichasPreguntaReemplazarComprobante.BindearPropiedadControl = Nothing
      Me.chbFichasPreguntaReemplazarComprobante.BindearPropiedadEntidad = Nothing
      Me.chbFichasPreguntaReemplazarComprobante.ForeColorFocus = System.Drawing.Color.Red
      Me.chbFichasPreguntaReemplazarComprobante.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
      Me.chbFichasPreguntaReemplazarComprobante.IsPK = False
      Me.chbFichasPreguntaReemplazarComprobante.IsRequired = False
      Me.chbFichasPreguntaReemplazarComprobante.Key = Nothing
      Me.chbFichasPreguntaReemplazarComprobante.LabelAsoc = Nothing
      Me.chbFichasPreguntaReemplazarComprobante.Location = New System.Drawing.Point(24, 95)
      Me.chbFichasPreguntaReemplazarComprobante.Name = "chbFichasPreguntaReemplazarComprobante"
      Me.chbFichasPreguntaReemplazarComprobante.Size = New System.Drawing.Size(311, 26)
      Me.chbFichasPreguntaReemplazarComprobante.TabIndex = 61
      Me.chbFichasPreguntaReemplazarComprobante.Tag = ""
      Me.chbFichasPreguntaReemplazarComprobante.Text = "Preguntar si desea Reemplazar Comprobante"
      Me.chbFichasPreguntaReemplazarComprobante.UseVisualStyleBackColor = True
      '
      'chbFichasPermiteCambiarFormaDePago
      '
      Me.chbFichasPermiteCambiarFormaDePago.BindearPropiedadControl = Nothing
      Me.chbFichasPermiteCambiarFormaDePago.BindearPropiedadEntidad = Nothing
      Me.chbFichasPermiteCambiarFormaDePago.ForeColorFocus = System.Drawing.Color.Red
      Me.chbFichasPermiteCambiarFormaDePago.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
      Me.chbFichasPermiteCambiarFormaDePago.IsPK = False
      Me.chbFichasPermiteCambiarFormaDePago.IsRequired = False
      Me.chbFichasPermiteCambiarFormaDePago.Key = Nothing
      Me.chbFichasPermiteCambiarFormaDePago.LabelAsoc = Nothing
      Me.chbFichasPermiteCambiarFormaDePago.Location = New System.Drawing.Point(24, 63)
      Me.chbFichasPermiteCambiarFormaDePago.Name = "chbFichasPermiteCambiarFormaDePago"
      Me.chbFichasPermiteCambiarFormaDePago.Size = New System.Drawing.Size(311, 26)
      Me.chbFichasPermiteCambiarFormaDePago.TabIndex = 60
      Me.chbFichasPermiteCambiarFormaDePago.Tag = ""
      Me.chbFichasPermiteCambiarFormaDePago.Text = "Permite Cambiar la Forma de Pago"
      Me.chbFichasPermiteCambiarFormaDePago.UseVisualStyleBackColor = True
      '
      'chbFichasActualizaPreciosDeVenta
      '
      Me.chbFichasActualizaPreciosDeVenta.BindearPropiedadControl = Nothing
      Me.chbFichasActualizaPreciosDeVenta.BindearPropiedadEntidad = Nothing
      Me.chbFichasActualizaPreciosDeVenta.ForeColorFocus = System.Drawing.Color.Red
      Me.chbFichasActualizaPreciosDeVenta.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
      Me.chbFichasActualizaPreciosDeVenta.IsPK = False
      Me.chbFichasActualizaPreciosDeVenta.IsRequired = False
      Me.chbFichasActualizaPreciosDeVenta.Key = Nothing
      Me.chbFichasActualizaPreciosDeVenta.LabelAsoc = Nothing
      Me.chbFichasActualizaPreciosDeVenta.Location = New System.Drawing.Point(24, 31)
      Me.chbFichasActualizaPreciosDeVenta.Name = "chbFichasActualizaPreciosDeVenta"
      Me.chbFichasActualizaPreciosDeVenta.Size = New System.Drawing.Size(311, 26)
      Me.chbFichasActualizaPreciosDeVenta.TabIndex = 59
      Me.chbFichasActualizaPreciosDeVenta.Tag = "ACTUALIZAPRECIOSDEVENTA"
      Me.chbFichasActualizaPreciosDeVenta.Text = "Actualiza los precios de Venta si cambia la Lista de Precios"
      Me.chbFichasActualizaPreciosDeVenta.UseVisualStyleBackColor = True
      '
      'ucConfFichas
      '
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.Controls.Add(Me.grpFichasSinReferenciaCuota)
      Me.Controls.Add(Me.chbFichasImprimeCobrosFormatoRecibo)
      Me.Controls.Add(Me.chbFichasPreguntaReemplazarComprobante)
      Me.Controls.Add(Me.chbFichasPermiteCambiarFormaDePago)
      Me.Controls.Add(Me.chbFichasActualizaPreciosDeVenta)
      Me.Name = "ucConfFichas"
      Me.Controls.SetChildIndex(Me.chbFichasActualizaPreciosDeVenta, 0)
      Me.Controls.SetChildIndex(Me.chbFichasPermiteCambiarFormaDePago, 0)
      Me.Controls.SetChildIndex(Me.chbFichasPreguntaReemplazarComprobante, 0)
      Me.Controls.SetChildIndex(Me.chbFichasImprimeCobrosFormatoRecibo, 0)
      Me.Controls.SetChildIndex(Me.grpFichasSinReferenciaCuota, 0)
      Me.grpFichasSinReferenciaCuota.ResumeLayout(False)
      Me.grpFichasSinReferenciaCuota.PerformLayout()
      Me.ResumeLayout(False)
      Me.PerformLayout()

   End Sub

   Friend WithEvents grpFichasSinReferenciaCuota As GroupBox
   Friend WithEvents rbtFichasSinReferenciaCuota_AvisarPermitir As RadioButton
   Friend WithEvents rbtFichasSinReferenciaCuota_NoPermitir As RadioButton
   Friend WithEvents rbtFichasSinReferenciaCuota_Permitir As RadioButton
   Friend WithEvents chbFichasImprimeCobrosFormatoRecibo As Controles.CheckBox
   Friend WithEvents chbFichasPreguntaReemplazarComprobante As Controles.CheckBox
   Friend WithEvents chbFichasPermiteCambiarFormaDePago As Controles.CheckBox
   Friend WithEvents chbFichasActualizaPreciosDeVenta As Controles.CheckBox
End Class
