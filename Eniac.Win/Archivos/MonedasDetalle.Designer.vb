<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MonedasDetalle
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
        Me.txtOrden = New Eniac.Controles.TextBox()
        Me.lblOrden = New Eniac.Controles.Label()
        Me.txtNombre = New Eniac.Controles.TextBox()
        Me.lblNombre = New Eniac.Controles.Label()
        Me.txtIdMoneda = New Eniac.Controles.TextBox()
        Me.lblCodigo = New Eniac.Controles.Label()
        Me.chbPDRDomingo = New Eniac.Controles.CheckBox()
        Me.SuspendLayout()
        '
        'btnAceptar
        '
        Me.btnAceptar.Location = New System.Drawing.Point(177, 121)
        '
        'btnCancelar
        '
        Me.btnCancelar.Location = New System.Drawing.Point(263, 121)
        '
        'btnCopiar
        '
        Me.btnCopiar.Location = New System.Drawing.Point(76, 121)
        '
        'btnAplicar
        '
        Me.btnAplicar.Location = New System.Drawing.Point(19, 121)
        '
        'txtOrden
        '
        Me.txtOrden.BindearPropiedadControl = "Text"
        Me.txtOrden.BindearPropiedadEntidad = "Simbolo"
        Me.txtOrden.ForeColorFocus = System.Drawing.Color.Red
        Me.txtOrden.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtOrden.Formato = ""
        Me.txtOrden.IsDecimal = False
        Me.txtOrden.IsNumber = False
        Me.txtOrden.IsPK = False
        Me.txtOrden.IsRequired = True
        Me.txtOrden.Key = ""
        Me.txtOrden.LabelAsoc = Me.lblOrden
        Me.txtOrden.Location = New System.Drawing.Point(71, 67)
        Me.txtOrden.MaxLength = 6
        Me.txtOrden.Name = "txtOrden"
        Me.txtOrden.Size = New System.Drawing.Size(59, 20)
        Me.txtOrden.TabIndex = 14
        '
        'lblOrden
        '
        Me.lblOrden.AutoSize = True
        Me.lblOrden.LabelAsoc = Nothing
        Me.lblOrden.Location = New System.Drawing.Point(12, 70)
        Me.lblOrden.Name = "lblOrden"
        Me.lblOrden.Size = New System.Drawing.Size(44, 13)
        Me.lblOrden.TabIndex = 13
        Me.lblOrden.Text = "Simbolo"
        '
        'txtNombre
        '
        Me.txtNombre.BindearPropiedadControl = "Text"
        Me.txtNombre.BindearPropiedadEntidad = "NombreMoneda"
        Me.txtNombre.ForeColorFocus = System.Drawing.Color.Red
        Me.txtNombre.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtNombre.Formato = ""
        Me.txtNombre.IsDecimal = False
        Me.txtNombre.IsNumber = False
        Me.txtNombre.IsPK = False
        Me.txtNombre.IsRequired = True
        Me.txtNombre.Key = ""
        Me.txtNombre.LabelAsoc = Me.lblNombre
        Me.txtNombre.Location = New System.Drawing.Point(71, 38)
        Me.txtNombre.MaxLength = 40
        Me.txtNombre.Name = "txtNombre"
        Me.txtNombre.Size = New System.Drawing.Size(262, 20)
        Me.txtNombre.TabIndex = 12
        '
        'lblNombre
        '
        Me.lblNombre.AutoSize = True
        Me.lblNombre.LabelAsoc = Nothing
        Me.lblNombre.Location = New System.Drawing.Point(12, 42)
        Me.lblNombre.Name = "lblNombre"
        Me.lblNombre.Size = New System.Drawing.Size(44, 13)
        Me.lblNombre.TabIndex = 11
        Me.lblNombre.Text = "Nombre"
        '
        'txtIdMoneda
        '
        Me.txtIdMoneda.BindearPropiedadControl = "Text"
        Me.txtIdMoneda.BindearPropiedadEntidad = "IdMoneda"
        Me.txtIdMoneda.ForeColorFocus = System.Drawing.Color.Red
        Me.txtIdMoneda.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtIdMoneda.Formato = ""
        Me.txtIdMoneda.IsDecimal = False
        Me.txtIdMoneda.IsNumber = True
        Me.txtIdMoneda.IsPK = True
        Me.txtIdMoneda.IsRequired = True
        Me.txtIdMoneda.Key = ""
        Me.txtIdMoneda.LabelAsoc = Me.lblCodigo
        Me.txtIdMoneda.Location = New System.Drawing.Point(71, 12)
        Me.txtIdMoneda.MaxLength = 6
        Me.txtIdMoneda.Name = "txtIdMoneda"
        Me.txtIdMoneda.Size = New System.Drawing.Size(59, 20)
        Me.txtIdMoneda.TabIndex = 10
        Me.txtIdMoneda.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblCodigo
        '
        Me.lblCodigo.AutoSize = True
        Me.lblCodigo.LabelAsoc = Nothing
        Me.lblCodigo.Location = New System.Drawing.Point(12, 16)
        Me.lblCodigo.Name = "lblCodigo"
        Me.lblCodigo.Size = New System.Drawing.Size(40, 13)
        Me.lblCodigo.TabIndex = 9
        Me.lblCodigo.Text = "Código"
        '
        'chbPDRDomingo
        '
        Me.chbPDRDomingo.AutoSize = True
        Me.chbPDRDomingo.BindearPropiedadControl = "Checked"
        Me.chbPDRDomingo.BindearPropiedadEntidad = "Predeterminada"
        Me.chbPDRDomingo.ForeColorFocus = System.Drawing.Color.Red
        Me.chbPDRDomingo.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbPDRDomingo.IsPK = False
        Me.chbPDRDomingo.IsRequired = False
        Me.chbPDRDomingo.Key = Nothing
        Me.chbPDRDomingo.LabelAsoc = Nothing
        Me.chbPDRDomingo.Location = New System.Drawing.Point(157, 70)
        Me.chbPDRDomingo.Name = "chbPDRDomingo"
        Me.chbPDRDomingo.Size = New System.Drawing.Size(100, 17)
        Me.chbPDRDomingo.TabIndex = 57
        Me.chbPDRDomingo.Text = "Predeterminada"
        Me.chbPDRDomingo.UseVisualStyleBackColor = True
        '
        'MonedasDetalle
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(352, 156)
        Me.Controls.Add(Me.chbPDRDomingo)
        Me.Controls.Add(Me.txtOrden)
        Me.Controls.Add(Me.lblOrden)
        Me.Controls.Add(Me.txtNombre)
        Me.Controls.Add(Me.txtIdMoneda)
        Me.Controls.Add(Me.lblNombre)
        Me.Controls.Add(Me.lblCodigo)
        Me.Name = "MonedasDetalle"
        Me.Text = "Monedas"
        Me.Controls.SetChildIndex(Me.btnCancelar, 0)
        Me.Controls.SetChildIndex(Me.btnAceptar, 0)
        Me.Controls.SetChildIndex(Me.btnCopiar, 0)
        Me.Controls.SetChildIndex(Me.btnAplicar, 0)
        Me.Controls.SetChildIndex(Me.lblCodigo, 0)
        Me.Controls.SetChildIndex(Me.lblNombre, 0)
        Me.Controls.SetChildIndex(Me.txtIdMoneda, 0)
        Me.Controls.SetChildIndex(Me.txtNombre, 0)
        Me.Controls.SetChildIndex(Me.lblOrden, 0)
        Me.Controls.SetChildIndex(Me.txtOrden, 0)
        Me.Controls.SetChildIndex(Me.chbPDRDomingo, 0)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents txtOrden As Controles.TextBox
    Friend WithEvents lblOrden As Controles.Label
    Friend WithEvents txtNombre As Controles.TextBox
    Friend WithEvents lblNombre As Controles.Label
    Friend WithEvents txtIdMoneda As Controles.TextBox
    Friend WithEvents lblCodigo As Controles.Label
    Friend WithEvents chbPDRDomingo As Controles.CheckBox
End Class
