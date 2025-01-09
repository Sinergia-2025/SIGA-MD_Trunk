<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class EscalasRetGananciasDetalle
   Inherits Eniac.Win.BaseDetalle

   'Form reemplaza a Dispose para limpiar la lista de componentes.
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

   'Requerido por el Diseñador de Windows Forms
   Private components As System.ComponentModel.IContainer

   'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
   'Se puede modificar usando el Diseñador de Windows Forms.  
   'No lo modifique con el editor de código.
   <System.Diagnostics.DebuggerStepThrough()> _
   Private Sub InitializeComponent()
      Me.lblIdRegimen = New Eniac.Controles.Label()
      Me.txtRegimen = New Eniac.Controles.TextBox()
      Me.lblAlicuota = New Eniac.Controles.Label()
      Me.txtRetenerIns = New Eniac.Controles.TextBox()
      Me.Label1 = New Eniac.Controles.Label()
      Me.txtRetenerNoIns = New Eniac.Controles.TextBox()
      Me.Label2 = New Eniac.Controles.Label()
      Me.txtMontoExceder = New Eniac.Controles.TextBox()
      Me.lblMontoMinInscripto = New Eniac.Controles.Label()
      Me.txtImporteMinimoInscripto = New Eniac.Controles.TextBox()
      Me.lblMontoMinNoInscripto = New Eniac.Controles.Label()
      Me.txtMontoMinimoNoInscripto = New Eniac.Controles.TextBox()
      Me.Label3 = New System.Windows.Forms.Label()
      Me.SuspendLayout()
      '
      'btnAceptar
      '
      Me.btnAceptar.Location = New System.Drawing.Point(242, 237)
      Me.btnAceptar.TabIndex = 8
      '
      'btnCancelar
      '
      Me.btnCancelar.Location = New System.Drawing.Point(328, 237)
      Me.btnCancelar.TabIndex = 9
      '
      'lblIdRegimen
      '
      Me.lblIdRegimen.AutoSize = True
      Me.lblIdRegimen.Location = New System.Drawing.Point(28, 43)
      Me.lblIdRegimen.Name = "lblIdRegimen"
      Me.lblIdRegimen.Size = New System.Drawing.Size(39, 13)
      Me.lblIdRegimen.TabIndex = 10
      Me.lblIdRegimen.Tag = ""
      Me.lblIdRegimen.Text = "Escala"
      '
      'txtRegimen
      '
      Me.txtRegimen.BindearPropiedadControl = "Text"
      Me.txtRegimen.BindearPropiedadEntidad = "IdEscala"
      Me.txtRegimen.ForeColorFocus = System.Drawing.Color.Red
      Me.txtRegimen.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtRegimen.Formato = ""
      Me.txtRegimen.IsDecimal = False
      Me.txtRegimen.IsNumber = True
      Me.txtRegimen.IsPK = True
      Me.txtRegimen.IsRequired = True
      Me.txtRegimen.Key = ""
      Me.txtRegimen.LabelAsoc = Me.lblIdRegimen
      Me.txtRegimen.Location = New System.Drawing.Point(149, 40)
      Me.txtRegimen.MaxLength = 10
      Me.txtRegimen.Name = "txtRegimen"
      Me.txtRegimen.Size = New System.Drawing.Size(59, 20)
      Me.txtRegimen.TabIndex = 0
      Me.txtRegimen.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'lblAlicuota
      '
      Me.lblAlicuota.AutoSize = True
      Me.lblAlicuota.Location = New System.Drawing.Point(28, 79)
      Me.lblAlicuota.Name = "lblAlicuota"
      Me.lblAlicuota.Size = New System.Drawing.Size(77, 13)
      Me.lblAlicuota.TabIndex = 12
      Me.lblAlicuota.Text = "Monto Más De"
      '
      'txtRetenerIns
      '
      Me.txtRetenerIns.BindearPropiedadControl = "Text"
      Me.txtRetenerIns.BindearPropiedadEntidad = "MontoMasDe"
      Me.txtRetenerIns.ForeColorFocus = System.Drawing.Color.Red
      Me.txtRetenerIns.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtRetenerIns.Formato = "##0.00"
      Me.txtRetenerIns.IsDecimal = True
      Me.txtRetenerIns.IsNumber = True
      Me.txtRetenerIns.IsPK = False
      Me.txtRetenerIns.IsRequired = False
      Me.txtRetenerIns.Key = ""
      Me.txtRetenerIns.LabelAsoc = Me.lblAlicuota
      Me.txtRetenerIns.Location = New System.Drawing.Point(149, 76)
      Me.txtRetenerIns.MaxLength = 10
      Me.txtRetenerIns.Name = "txtRetenerIns"
      Me.txtRetenerIns.Size = New System.Drawing.Size(103, 20)
      Me.txtRetenerIns.TabIndex = 2
      Me.txtRetenerIns.Text = "0.00"
      Me.txtRetenerIns.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'Label1
      '
      Me.Label1.AutoSize = True
      Me.Label1.Location = New System.Drawing.Point(28, 105)
      Me.Label1.Name = "Label1"
      Me.Label1.Size = New System.Drawing.Size(47, 13)
      Me.Label1.TabIndex = 13
      Me.Label1.Text = "Monto A"
      '
      'txtRetenerNoIns
      '
      Me.txtRetenerNoIns.BindearPropiedadControl = "Text"
      Me.txtRetenerNoIns.BindearPropiedadEntidad = "MontoA"
      Me.txtRetenerNoIns.ForeColorFocus = System.Drawing.Color.Red
      Me.txtRetenerNoIns.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtRetenerNoIns.Formato = "##0.00"
      Me.txtRetenerNoIns.IsDecimal = True
      Me.txtRetenerNoIns.IsNumber = True
      Me.txtRetenerNoIns.IsPK = False
      Me.txtRetenerNoIns.IsRequired = False
      Me.txtRetenerNoIns.Key = ""
      Me.txtRetenerNoIns.LabelAsoc = Me.Label1
      Me.txtRetenerNoIns.Location = New System.Drawing.Point(149, 102)
      Me.txtRetenerNoIns.MaxLength = 10
      Me.txtRetenerNoIns.Name = "txtRetenerNoIns"
      Me.txtRetenerNoIns.Size = New System.Drawing.Size(103, 20)
      Me.txtRetenerNoIns.TabIndex = 3
      Me.txtRetenerNoIns.Text = "0.00"
      Me.txtRetenerNoIns.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'Label2
      '
      Me.Label2.AutoSize = True
      Me.Label2.Location = New System.Drawing.Point(28, 131)
      Me.Label2.Name = "Label2"
      Me.Label2.Size = New System.Drawing.Size(42, 13)
      Me.Label2.TabIndex = 14
      Me.Label2.Text = "Importe"
      '
      'txtMontoExceder
      '
      Me.txtMontoExceder.BindearPropiedadControl = "Text"
      Me.txtMontoExceder.BindearPropiedadEntidad = "Importe"
      Me.txtMontoExceder.ForeColorFocus = System.Drawing.Color.Red
      Me.txtMontoExceder.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtMontoExceder.Formato = "##0.00"
      Me.txtMontoExceder.IsDecimal = True
      Me.txtMontoExceder.IsNumber = True
      Me.txtMontoExceder.IsPK = False
      Me.txtMontoExceder.IsRequired = False
      Me.txtMontoExceder.Key = ""
      Me.txtMontoExceder.LabelAsoc = Me.Label2
      Me.txtMontoExceder.Location = New System.Drawing.Point(149, 128)
      Me.txtMontoExceder.MaxLength = 20
      Me.txtMontoExceder.Name = "txtMontoExceder"
      Me.txtMontoExceder.Size = New System.Drawing.Size(103, 20)
      Me.txtMontoExceder.TabIndex = 4
      Me.txtMontoExceder.Text = "0.00"
      Me.txtMontoExceder.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'lblMontoMinInscripto
      '
      Me.lblMontoMinInscripto.AutoSize = True
      Me.lblMontoMinInscripto.Location = New System.Drawing.Point(28, 157)
      Me.lblMontoMinInscripto.Name = "lblMontoMinInscripto"
      Me.lblMontoMinInscripto.Size = New System.Drawing.Size(81, 13)
      Me.lblMontoMinInscripto.TabIndex = 15
      Me.lblMontoMinInscripto.Text = "Mas Porcentaje"
      '
      'txtImporteMinimoInscripto
      '
      Me.txtImporteMinimoInscripto.BindearPropiedadControl = "Text"
      Me.txtImporteMinimoInscripto.BindearPropiedadEntidad = "MasPorcentaje"
      Me.txtImporteMinimoInscripto.ForeColorFocus = System.Drawing.Color.Red
      Me.txtImporteMinimoInscripto.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtImporteMinimoInscripto.Formato = "##0.00"
      Me.txtImporteMinimoInscripto.IsDecimal = True
      Me.txtImporteMinimoInscripto.IsNumber = True
      Me.txtImporteMinimoInscripto.IsPK = False
      Me.txtImporteMinimoInscripto.IsRequired = False
      Me.txtImporteMinimoInscripto.Key = ""
      Me.txtImporteMinimoInscripto.LabelAsoc = Me.lblMontoMinInscripto
      Me.txtImporteMinimoInscripto.Location = New System.Drawing.Point(149, 154)
      Me.txtImporteMinimoInscripto.MaxLength = 10
      Me.txtImporteMinimoInscripto.Name = "txtImporteMinimoInscripto"
      Me.txtImporteMinimoInscripto.Size = New System.Drawing.Size(59, 20)
      Me.txtImporteMinimoInscripto.TabIndex = 5
      Me.txtImporteMinimoInscripto.Text = "0.00"
      Me.txtImporteMinimoInscripto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'lblMontoMinNoInscripto
      '
      Me.lblMontoMinNoInscripto.AutoSize = True
      Me.lblMontoMinNoInscripto.Location = New System.Drawing.Point(28, 183)
      Me.lblMontoMinNoInscripto.Name = "lblMontoMinNoInscripto"
      Me.lblMontoMinNoInscripto.Size = New System.Drawing.Size(89, 13)
      Me.lblMontoMinNoInscripto.TabIndex = 16
      Me.lblMontoMinNoInscripto.Text = "Sobre Excedente"
      '
      'txtMontoMinimoNoInscripto
      '
      Me.txtMontoMinimoNoInscripto.BindearPropiedadControl = "Text"
      Me.txtMontoMinimoNoInscripto.BindearPropiedadEntidad = "SobreExcedente"
      Me.txtMontoMinimoNoInscripto.ForeColorFocus = System.Drawing.Color.Red
      Me.txtMontoMinimoNoInscripto.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtMontoMinimoNoInscripto.Formato = "##0.00"
      Me.txtMontoMinimoNoInscripto.IsDecimal = True
      Me.txtMontoMinimoNoInscripto.IsNumber = True
      Me.txtMontoMinimoNoInscripto.IsPK = False
      Me.txtMontoMinimoNoInscripto.IsRequired = False
      Me.txtMontoMinimoNoInscripto.Key = ""
      Me.txtMontoMinimoNoInscripto.LabelAsoc = Me.lblMontoMinNoInscripto
      Me.txtMontoMinimoNoInscripto.Location = New System.Drawing.Point(149, 180)
      Me.txtMontoMinimoNoInscripto.MaxLength = 10
      Me.txtMontoMinimoNoInscripto.Name = "txtMontoMinimoNoInscripto"
      Me.txtMontoMinimoNoInscripto.Size = New System.Drawing.Size(103, 20)
      Me.txtMontoMinimoNoInscripto.TabIndex = 6
      Me.txtMontoMinimoNoInscripto.Text = "0.00"
      Me.txtMontoMinimoNoInscripto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'Label3
      '
      Me.Label3.AutoSize = True
      Me.Label3.Location = New System.Drawing.Point(213, 158)
      Me.Label3.Name = "Label3"
      Me.Label3.Size = New System.Drawing.Size(15, 13)
      Me.Label3.TabIndex = 17
      Me.Label3.Text = "%"
      '
      'EscalasRetGananciasDetalle
      '
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.ClientSize = New System.Drawing.Size(417, 272)
      Me.Controls.Add(Me.Label3)
      Me.Controls.Add(Me.lblMontoMinNoInscripto)
      Me.Controls.Add(Me.txtMontoMinimoNoInscripto)
      Me.Controls.Add(Me.lblMontoMinInscripto)
      Me.Controls.Add(Me.txtImporteMinimoInscripto)
      Me.Controls.Add(Me.Label2)
      Me.Controls.Add(Me.txtMontoExceder)
      Me.Controls.Add(Me.Label1)
      Me.Controls.Add(Me.txtRetenerNoIns)
      Me.Controls.Add(Me.lblAlicuota)
      Me.Controls.Add(Me.txtRetenerIns)
      Me.Controls.Add(Me.lblIdRegimen)
      Me.Controls.Add(Me.txtRegimen)
      Me.Name = "EscalasRetGananciasDetalle"
      Me.Text = "Escalas Retención Impuesto a las Ganancias"
      Me.Controls.SetChildIndex(Me.btnCancelar, 0)
      Me.Controls.SetChildIndex(Me.btnAceptar, 0)
      Me.Controls.SetChildIndex(Me.txtRegimen, 0)
      Me.Controls.SetChildIndex(Me.lblIdRegimen, 0)
      Me.Controls.SetChildIndex(Me.txtRetenerIns, 0)
      Me.Controls.SetChildIndex(Me.lblAlicuota, 0)
      Me.Controls.SetChildIndex(Me.txtRetenerNoIns, 0)
      Me.Controls.SetChildIndex(Me.Label1, 0)
      Me.Controls.SetChildIndex(Me.txtMontoExceder, 0)
      Me.Controls.SetChildIndex(Me.Label2, 0)
      Me.Controls.SetChildIndex(Me.txtImporteMinimoInscripto, 0)
      Me.Controls.SetChildIndex(Me.lblMontoMinInscripto, 0)
      Me.Controls.SetChildIndex(Me.txtMontoMinimoNoInscripto, 0)
      Me.Controls.SetChildIndex(Me.lblMontoMinNoInscripto, 0)
      Me.Controls.SetChildIndex(Me.Label3, 0)
      Me.ResumeLayout(False)
      Me.PerformLayout()

   End Sub
   Friend WithEvents lblIdRegimen As Eniac.Controles.Label
   Friend WithEvents txtRegimen As Eniac.Controles.TextBox
   Friend WithEvents lblAlicuota As Eniac.Controles.Label
   Friend WithEvents txtRetenerIns As Eniac.Controles.TextBox
   Friend WithEvents Label1 As Eniac.Controles.Label
   Friend WithEvents txtRetenerNoIns As Eniac.Controles.TextBox
   Friend WithEvents Label2 As Eniac.Controles.Label
   Friend WithEvents txtMontoExceder As Eniac.Controles.TextBox
   Friend WithEvents lblMontoMinInscripto As Eniac.Controles.Label
   Friend WithEvents txtImporteMinimoInscripto As Eniac.Controles.TextBox
   Friend WithEvents lblMontoMinNoInscripto As Eniac.Controles.Label
   Friend WithEvents txtMontoMinimoNoInscripto As Eniac.Controles.TextBox
   Friend WithEvents Label3 As System.Windows.Forms.Label
End Class
