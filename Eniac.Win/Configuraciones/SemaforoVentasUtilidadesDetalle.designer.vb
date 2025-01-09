<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SemaforoVentasUtilidadesDetalle
   Inherits Eniac.Win.BaseDetalle

   'Form overrides dispose to clean up the component list.
   <System.Diagnostics.DebuggerNonUserCode()> _
   Protected Overrides Sub Dispose(ByVal disposing As Boolean)
      If disposing AndAlso components IsNot Nothing Then
         components.Dispose()
      End If
      MyBase.Dispose(disposing)
   End Sub

   'Required by the Windows Form Designer
   Private components As System.ComponentModel.IContainer

   'NOTE: The following procedure is required by the Windows Form Designer
   'It can be modified using the Windows Form Designer.  
   'Do not modify it using the code editor.
   <System.Diagnostics.DebuggerStepThrough()> _
   Private Sub InitializeComponent()
      Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(SemaforoVentasUtilidadesDetalle))
      Me.txtIdSemaforo = New Eniac.Controles.TextBox()
      Me.lblIdSemaforo = New Eniac.Controles.Label()
      Me.btnColorSemadoro = New System.Windows.Forms.Button()
      Me.lblColorSemadoro = New Eniac.Controles.Label()
      Me.ColorDialog1 = New System.Windows.Forms.ColorDialog()
      Me.txtColorSemadoro = New Eniac.Controles.TextBox()
      Me.txtPorcentajeHasta = New Eniac.Controles.TextBox()
      Me.lblPorcentajeHasta = New Eniac.Controles.Label()
      Me.txtNombreColor = New Eniac.Controles.TextBox()
      Me.lblNombreColor = New Eniac.Controles.Label()
      Me.cmbTipoSemaforo = New Eniac.Controles.ComboBox()
      Me.Label1 = New Eniac.Controles.Label()
      Me.txtColorSemaforoLetra = New Eniac.Controles.TextBox()
      Me.Label2 = New Eniac.Controles.Label()
      Me.btnPaletaColorLetra = New System.Windows.Forms.Button()
      Me.ColorDialog2 = New System.Windows.Forms.ColorDialog()
      Me.chbNegrita = New Eniac.Controles.CheckBox()
      Me.txtEjemplo = New Eniac.Controles.TextBox()
      Me.lblEjemplo = New Eniac.Controles.Label()
        Me.SuspendLayout()
        '
        'btnAceptar
        '
        Me.btnAceptar.Location = New System.Drawing.Point(165, 214)
        Me.btnAceptar.TabIndex = 17
        '
        'btnCancelar
        '
        Me.btnCancelar.Location = New System.Drawing.Point(251, 214)
        Me.btnCancelar.TabIndex = 18
        '
        'btnCopiar
        '
        Me.btnCopiar.Location = New System.Drawing.Point(129, 281)
        '
        'btnAplicar
        '
        Me.btnAplicar.Location = New System.Drawing.Point(72, 281)
        '
        'txtIdSemaforo
        '
        Me.txtIdSemaforo.BindearPropiedadControl = "Text"
        Me.txtIdSemaforo.BindearPropiedadEntidad = "IdSemaforo"
        Me.txtIdSemaforo.ForeColorFocus = System.Drawing.Color.Red
        Me.txtIdSemaforo.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtIdSemaforo.Formato = ""
        Me.txtIdSemaforo.IsDecimal = False
        Me.txtIdSemaforo.IsNumber = True
        Me.txtIdSemaforo.IsPK = True
        Me.txtIdSemaforo.IsRequired = True
        Me.txtIdSemaforo.Key = ""
        Me.txtIdSemaforo.LabelAsoc = Me.lblIdSemaforo
        Me.txtIdSemaforo.Location = New System.Drawing.Point(116, 13)
        Me.txtIdSemaforo.MaxLength = 8
        Me.txtIdSemaforo.Name = "txtIdSemaforo"
        Me.txtIdSemaforo.Size = New System.Drawing.Size(56, 20)
        Me.txtIdSemaforo.TabIndex = 1
        Me.txtIdSemaforo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblIdSemaforo
        '
        Me.lblIdSemaforo.AutoSize = True
        Me.lblIdSemaforo.LabelAsoc = Nothing
        Me.lblIdSemaforo.Location = New System.Drawing.Point(15, 20)
        Me.lblIdSemaforo.Name = "lblIdSemaforo"
        Me.lblIdSemaforo.Size = New System.Drawing.Size(40, 13)
        Me.lblIdSemaforo.TabIndex = 0
        Me.lblIdSemaforo.Text = "Codigo"
        '
        'btnColorSemadoro
        '
        Me.btnColorSemadoro.Location = New System.Drawing.Point(204, 92)
        Me.btnColorSemadoro.Name = "btnColorSemadoro"
        Me.btnColorSemadoro.Size = New System.Drawing.Size(57, 23)
        Me.btnColorSemadoro.TabIndex = 8
        Me.btnColorSemadoro.Text = "Paleta"
        Me.btnColorSemadoro.UseVisualStyleBackColor = True
        '
        'lblColorSemadoro
        '
        Me.lblColorSemadoro.AutoSize = True
        Me.lblColorSemadoro.LabelAsoc = Nothing
        Me.lblColorSemadoro.Location = New System.Drawing.Point(15, 99)
        Me.lblColorSemadoro.Name = "lblColorSemadoro"
        Me.lblColorSemadoro.Size = New System.Drawing.Size(64, 13)
        Me.lblColorSemadoro.TabIndex = 6
        Me.lblColorSemadoro.Text = "Color Fondo"
        '
        'txtColorSemadoro
        '
        Me.txtColorSemadoro.BindearPropiedadControl = "Key"
        Me.txtColorSemadoro.BindearPropiedadEntidad = "ColorSemaforo"
        Me.txtColorSemadoro.ForeColorFocus = System.Drawing.Color.Red
        Me.txtColorSemadoro.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtColorSemadoro.Formato = ""
        Me.txtColorSemadoro.IsDecimal = False
        Me.txtColorSemadoro.IsNumber = False
        Me.txtColorSemadoro.IsPK = False
        Me.txtColorSemadoro.IsRequired = False
        Me.txtColorSemadoro.Key = ""
        Me.txtColorSemadoro.LabelAsoc = Me.lblColorSemadoro
        Me.txtColorSemadoro.Location = New System.Drawing.Point(116, 92)
        Me.txtColorSemadoro.Name = "txtColorSemadoro"
        Me.txtColorSemadoro.Size = New System.Drawing.Size(82, 20)
        Me.txtColorSemadoro.TabIndex = 7
        '
        'txtPorcentajeHasta
        '
        Me.txtPorcentajeHasta.BindearPropiedadControl = "Text"
        Me.txtPorcentajeHasta.BindearPropiedadEntidad = "PorcentajeHasta"
        Me.txtPorcentajeHasta.ForeColorFocus = System.Drawing.Color.Red
        Me.txtPorcentajeHasta.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtPorcentajeHasta.Formato = "##,##0.00"
        Me.txtPorcentajeHasta.IsDecimal = True
        Me.txtPorcentajeHasta.IsNumber = True
        Me.txtPorcentajeHasta.IsPK = False
        Me.txtPorcentajeHasta.IsRequired = True
        Me.txtPorcentajeHasta.Key = ""
        Me.txtPorcentajeHasta.LabelAsoc = Me.lblPorcentajeHasta
        Me.txtPorcentajeHasta.Location = New System.Drawing.Point(116, 66)
        Me.txtPorcentajeHasta.MaxLength = 8
        Me.txtPorcentajeHasta.Name = "txtPorcentajeHasta"
        Me.txtPorcentajeHasta.Size = New System.Drawing.Size(56, 20)
        Me.txtPorcentajeHasta.TabIndex = 5
        Me.txtPorcentajeHasta.Text = "0.00"
        Me.txtPorcentajeHasta.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblPorcentajeHasta
        '
        Me.lblPorcentajeHasta.AutoSize = True
        Me.lblPorcentajeHasta.LabelAsoc = Nothing
        Me.lblPorcentajeHasta.Location = New System.Drawing.Point(15, 73)
        Me.lblPorcentajeHasta.Name = "lblPorcentajeHasta"
        Me.lblPorcentajeHasta.Size = New System.Drawing.Size(35, 13)
        Me.lblPorcentajeHasta.TabIndex = 4
        Me.lblPorcentajeHasta.Text = "Hasta"
        '
        'txtNombreColor
        '
        Me.txtNombreColor.BindearPropiedadControl = "Text"
        Me.txtNombreColor.BindearPropiedadEntidad = "NombreColor"
        Me.txtNombreColor.ForeColorFocus = System.Drawing.Color.Red
        Me.txtNombreColor.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtNombreColor.Formato = ""
        Me.txtNombreColor.IsDecimal = False
        Me.txtNombreColor.IsNumber = False
        Me.txtNombreColor.IsPK = False
        Me.txtNombreColor.IsRequired = True
        Me.txtNombreColor.Key = ""
        Me.txtNombreColor.LabelAsoc = Me.lblNombreColor
        Me.txtNombreColor.Location = New System.Drawing.Point(116, 174)
        Me.txtNombreColor.MaxLength = 15
        Me.txtNombreColor.Name = "txtNombreColor"
        Me.txtNombreColor.Size = New System.Drawing.Size(145, 20)
        Me.txtNombreColor.TabIndex = 16
        '
        'lblNombreColor
        '
        Me.lblNombreColor.AutoSize = True
        Me.lblNombreColor.LabelAsoc = Nothing
        Me.lblNombreColor.Location = New System.Drawing.Point(15, 181)
        Me.lblNombreColor.Name = "lblNombreColor"
        Me.lblNombreColor.Size = New System.Drawing.Size(71, 13)
        Me.lblNombreColor.TabIndex = 15
        Me.lblNombreColor.Text = "Nombre Color"
        '
        'cmbTipoSemaforo
        '
        Me.cmbTipoSemaforo.BindearPropiedadControl = "SelectedValue"
        Me.cmbTipoSemaforo.BindearPropiedadEntidad = "IdTipoSemaforoVentaUtilidad"
        Me.cmbTipoSemaforo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbTipoSemaforo.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbTipoSemaforo.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbTipoSemaforo.FormattingEnabled = True
        Me.cmbTipoSemaforo.IsPK = False
        Me.cmbTipoSemaforo.IsRequired = False
        Me.cmbTipoSemaforo.Key = Nothing
        Me.cmbTipoSemaforo.LabelAsoc = Nothing
        Me.cmbTipoSemaforo.Location = New System.Drawing.Point(116, 39)
        Me.cmbTipoSemaforo.Name = "cmbTipoSemaforo"
        Me.cmbTipoSemaforo.Size = New System.Drawing.Size(121, 21)
        Me.cmbTipoSemaforo.TabIndex = 3
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.LabelAsoc = Nothing
        Me.Label1.Location = New System.Drawing.Point(15, 47)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(28, 13)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Tipo"
        '
        'txtColorSemaforoLetra
        '
        Me.txtColorSemaforoLetra.BindearPropiedadControl = "Key"
        Me.txtColorSemaforoLetra.BindearPropiedadEntidad = "ColorLetra"
        Me.txtColorSemaforoLetra.ForeColorFocus = System.Drawing.Color.Red
        Me.txtColorSemaforoLetra.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtColorSemaforoLetra.Formato = ""
        Me.txtColorSemaforoLetra.IsDecimal = False
        Me.txtColorSemaforoLetra.IsNumber = False
        Me.txtColorSemaforoLetra.IsPK = False
        Me.txtColorSemaforoLetra.IsRequired = False
        Me.txtColorSemaforoLetra.Key = ""
        Me.txtColorSemaforoLetra.LabelAsoc = Me.Label2
        Me.txtColorSemaforoLetra.Location = New System.Drawing.Point(116, 121)
        Me.txtColorSemaforoLetra.Name = "txtColorSemaforoLetra"
        Me.txtColorSemaforoLetra.Size = New System.Drawing.Size(82, 20)
        Me.txtColorSemaforoLetra.TabIndex = 10
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.LabelAsoc = Nothing
        Me.Label2.Location = New System.Drawing.Point(15, 128)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(58, 13)
        Me.Label2.TabIndex = 9
        Me.Label2.Text = "Color Letra"
        '
        'btnPaletaColorLetra
        '
        Me.btnPaletaColorLetra.Location = New System.Drawing.Point(204, 121)
        Me.btnPaletaColorLetra.Name = "btnPaletaColorLetra"
        Me.btnPaletaColorLetra.Size = New System.Drawing.Size(57, 23)
        Me.btnPaletaColorLetra.TabIndex = 11
        Me.btnPaletaColorLetra.Text = "Paleta"
        Me.btnPaletaColorLetra.UseVisualStyleBackColor = True
        '
        'chbNegrita
        '
        Me.chbNegrita.AutoSize = True
        Me.chbNegrita.BindearPropiedadControl = "Checked"
        Me.chbNegrita.BindearPropiedadEntidad = "Negrita"
        Me.chbNegrita.ForeColorFocus = System.Drawing.Color.Red
        Me.chbNegrita.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbNegrita.IsPK = False
        Me.chbNegrita.IsRequired = False
        Me.chbNegrita.Key = Nothing
        Me.chbNegrita.LabelAsoc = Nothing
        Me.chbNegrita.Location = New System.Drawing.Point(267, 125)
        Me.chbNegrita.Name = "chbNegrita"
        Me.chbNegrita.Size = New System.Drawing.Size(60, 17)
        Me.chbNegrita.TabIndex = 12
        Me.chbNegrita.Text = "Negrita"
        Me.chbNegrita.UseVisualStyleBackColor = True
        '
        'txtEjemplo
        '
        Me.txtEjemplo.BindearPropiedadControl = ""
        Me.txtEjemplo.BindearPropiedadEntidad = ""
        Me.txtEjemplo.ForeColorFocus = System.Drawing.Color.Red
        Me.txtEjemplo.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtEjemplo.Formato = ""
        Me.txtEjemplo.IsDecimal = True
        Me.txtEjemplo.IsNumber = False
        Me.txtEjemplo.IsPK = False
        Me.txtEjemplo.IsRequired = False
        Me.txtEjemplo.Key = ""
        Me.txtEjemplo.LabelAsoc = Me.lblEjemplo
        Me.txtEjemplo.Location = New System.Drawing.Point(116, 148)
        Me.txtEjemplo.MaxLength = 15
        Me.txtEjemplo.Name = "txtEjemplo"
        Me.txtEjemplo.Size = New System.Drawing.Size(145, 20)
        Me.txtEjemplo.TabIndex = 14
        Me.txtEjemplo.TabStop = False
        Me.txtEjemplo.Text = "999.999,99"
        Me.txtEjemplo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblEjemplo
        '
        Me.lblEjemplo.AutoSize = True
        Me.lblEjemplo.LabelAsoc = Nothing
        Me.lblEjemplo.Location = New System.Drawing.Point(15, 155)
        Me.lblEjemplo.Name = "lblEjemplo"
        Me.lblEjemplo.Size = New System.Drawing.Size(44, 13)
        Me.lblEjemplo.TabIndex = 13
        Me.lblEjemplo.Text = "Ejemplo"
        '
        'SemaforoVentasUtilidadesDetalle
        '
        Me.AcceptButton = Nothing
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.ClientSize = New System.Drawing.Size(341, 251)
        Me.Controls.Add(Me.txtEjemplo)
        Me.Controls.Add(Me.lblEjemplo)
        Me.Controls.Add(Me.chbNegrita)
        Me.Controls.Add(Me.txtColorSemaforoLetra)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.btnPaletaColorLetra)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.cmbTipoSemaforo)
        Me.Controls.Add(Me.txtNombreColor)
        Me.Controls.Add(Me.lblNombreColor)
        Me.Controls.Add(Me.txtPorcentajeHasta)
        Me.Controls.Add(Me.lblPorcentajeHasta)
        Me.Controls.Add(Me.txtColorSemadoro)
        Me.Controls.Add(Me.lblColorSemadoro)
        Me.Controls.Add(Me.btnColorSemadoro)
        Me.Controls.Add(Me.txtIdSemaforo)
        Me.Controls.Add(Me.lblIdSemaforo)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "SemaforoVentasUtilidadesDetalle"
        Me.Text = "Semaforo"
        Me.Controls.SetChildIndex(Me.btnCopiar, 0)
        Me.Controls.SetChildIndex(Me.btnAplicar, 0)
        Me.Controls.SetChildIndex(Me.btnCancelar, 0)
        Me.Controls.SetChildIndex(Me.btnAceptar, 0)
        Me.Controls.SetChildIndex(Me.lblIdSemaforo, 0)
        Me.Controls.SetChildIndex(Me.txtIdSemaforo, 0)
        Me.Controls.SetChildIndex(Me.btnColorSemadoro, 0)
        Me.Controls.SetChildIndex(Me.lblColorSemadoro, 0)
        Me.Controls.SetChildIndex(Me.txtColorSemadoro, 0)
        Me.Controls.SetChildIndex(Me.lblPorcentajeHasta, 0)
        Me.Controls.SetChildIndex(Me.txtPorcentajeHasta, 0)
        Me.Controls.SetChildIndex(Me.lblNombreColor, 0)
        Me.Controls.SetChildIndex(Me.txtNombreColor, 0)
        Me.Controls.SetChildIndex(Me.cmbTipoSemaforo, 0)
        Me.Controls.SetChildIndex(Me.Label1, 0)
        Me.Controls.SetChildIndex(Me.btnPaletaColorLetra, 0)
        Me.Controls.SetChildIndex(Me.Label2, 0)
        Me.Controls.SetChildIndex(Me.txtColorSemaforoLetra, 0)
        Me.Controls.SetChildIndex(Me.chbNegrita, 0)
        Me.Controls.SetChildIndex(Me.lblEjemplo, 0)
        Me.Controls.SetChildIndex(Me.txtEjemplo, 0)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtIdSemaforo As Eniac.Controles.TextBox
   Friend WithEvents lblIdSemaforo As Eniac.Controles.Label
   Friend WithEvents btnColorSemadoro As System.Windows.Forms.Button
   Friend WithEvents lblColorSemadoro As Eniac.Controles.Label
   Friend WithEvents ColorDialog1 As System.Windows.Forms.ColorDialog
   Friend WithEvents txtColorSemadoro As Eniac.Controles.TextBox
   Friend WithEvents txtPorcentajeHasta As Eniac.Controles.TextBox
   Friend WithEvents lblPorcentajeHasta As Eniac.Controles.Label
   Friend WithEvents txtNombreColor As Eniac.Controles.TextBox
   Friend WithEvents lblNombreColor As Eniac.Controles.Label
   Friend WithEvents cmbTipoSemaforo As Eniac.Controles.ComboBox
   Friend WithEvents Label1 As Eniac.Controles.Label
   Friend WithEvents txtColorSemaforoLetra As Eniac.Controles.TextBox
   Friend WithEvents Label2 As Eniac.Controles.Label
   Friend WithEvents btnPaletaColorLetra As System.Windows.Forms.Button
   Friend WithEvents ColorDialog2 As System.Windows.Forms.ColorDialog
   Friend WithEvents chbNegrita As Eniac.Controles.CheckBox
   Friend WithEvents txtEjemplo As Eniac.Controles.TextBox
   Friend WithEvents lblEjemplo As Eniac.Controles.Label

End Class
