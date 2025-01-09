<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ProvinciasDetalle
   Inherits Eniac.Win.BaseDetalle

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
      Me.lblProvincia = New Eniac.Controles.Label()
      Me.txtProvincia = New Eniac.Controles.TextBox()
      Me.txtIngBrutos = New Eniac.Controles.TextBox()
      Me.lblIngBrutos = New Eniac.Controles.Label()
      Me.lblAgenteIngBrutos = New Eniac.Controles.Label()
      Me.txtAgenteIngBrutos = New Eniac.Controles.TextBox()
      Me.chbEsAgentePercepcion = New Eniac.Controles.CheckBox()
      Me.lblIdProvincia = New Eniac.Controles.Label()
      Me.txtIdProvincia = New Eniac.Controles.TextBox()
      Me.GroupBox2 = New System.Windows.Forms.GroupBox()
      Me.UcCuentasVentas = New Eniac.Win.ucCuentas()
      Me.GroupBox1 = New System.Windows.Forms.GroupBox()
      Me.UcCuentasCompras = New Eniac.Win.ucCuentas()
      Me.txtJurisdiccion = New Eniac.Controles.TextBox()
      Me.lblJurisdiccion = New Eniac.Controles.Label()
      Me.cmbPais = New Eniac.Controles.ComboBox()
      Me.lblPais = New Eniac.Controles.Label()
      Me.GroupBox2.SuspendLayout()
      Me.GroupBox1.SuspendLayout()
      Me.SuspendLayout()
      '
      'btnAceptar
      '
      Me.btnAceptar.Location = New System.Drawing.Point(301, 316)
      Me.btnAceptar.TabIndex = 15
      '
      'btnCancelar
      '
      Me.btnCancelar.Location = New System.Drawing.Point(387, 316)
      Me.btnCancelar.TabIndex = 16
      '
      'btnCopiar
      '
      Me.btnCopiar.Location = New System.Drawing.Point(200, 316)
      Me.btnCopiar.TabIndex = 18
      '
      'btnAplicar
      '
      Me.btnAplicar.Location = New System.Drawing.Point(140, 315)
      Me.btnAplicar.TabIndex = 17
      '
      'lblProvincia
      '
      Me.lblProvincia.AutoSize = True
      Me.lblProvincia.Enabled = False
      Me.lblProvincia.ForeColor = System.Drawing.SystemColors.WindowText
      Me.lblProvincia.Location = New System.Drawing.Point(8, 40)
      Me.lblProvincia.Name = "lblProvincia"
      Me.lblProvincia.Size = New System.Drawing.Size(51, 13)
      Me.lblProvincia.TabIndex = 2
      Me.lblProvincia.Text = "Provincia"
      '
      'txtProvincia
      '
      Me.txtProvincia.BindearPropiedadControl = "Text"
      Me.txtProvincia.BindearPropiedadEntidad = "NombreProvincia"
      Me.txtProvincia.ForeColorFocus = System.Drawing.Color.Red
      Me.txtProvincia.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtProvincia.Formato = ""
      Me.txtProvincia.IsDecimal = False
      Me.txtProvincia.IsNumber = False
      Me.txtProvincia.IsPK = False
      Me.txtProvincia.IsRequired = True
      Me.txtProvincia.Key = ""
      Me.txtProvincia.LabelAsoc = Me.lblProvincia
      Me.txtProvincia.Location = New System.Drawing.Point(125, 37)
      Me.txtProvincia.MaxLength = 50
      Me.txtProvincia.Name = "txtProvincia"
      Me.txtProvincia.Size = New System.Drawing.Size(155, 20)
      Me.txtProvincia.TabIndex = 3
      '
      'txtIngBrutos
      '
      Me.txtIngBrutos.BindearPropiedadControl = "Text"
      Me.txtIngBrutos.BindearPropiedadEntidad = "IngBrutos"
      Me.txtIngBrutos.Enabled = False
      Me.txtIngBrutos.ForeColorFocus = System.Drawing.Color.Red
      Me.txtIngBrutos.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtIngBrutos.Formato = ""
      Me.txtIngBrutos.IsDecimal = False
      Me.txtIngBrutos.IsNumber = False
      Me.txtIngBrutos.IsPK = False
      Me.txtIngBrutos.IsRequired = False
      Me.txtIngBrutos.Key = ""
      Me.txtIngBrutos.LabelAsoc = Me.lblIngBrutos
      Me.txtIngBrutos.Location = New System.Drawing.Point(125, 115)
      Me.txtIngBrutos.MaxLength = 20
      Me.txtIngBrutos.Name = "txtIngBrutos"
      Me.txtIngBrutos.Size = New System.Drawing.Size(155, 20)
      Me.txtIngBrutos.TabIndex = 8
      '
      'lblIngBrutos
      '
      Me.lblIngBrutos.AutoSize = True
      Me.lblIngBrutos.Location = New System.Drawing.Point(8, 118)
      Me.lblIngBrutos.Name = "lblIngBrutos"
      Me.lblIngBrutos.Size = New System.Drawing.Size(80, 13)
      Me.lblIngBrutos.TabIndex = 7
      Me.lblIngBrutos.Text = "Ingresos Brutos"
      '
      'lblAgenteIngBrutos
      '
      Me.lblAgenteIngBrutos.AutoSize = True
      Me.lblAgenteIngBrutos.Location = New System.Drawing.Point(8, 147)
      Me.lblAgenteIngBrutos.Name = "lblAgenteIngBrutos"
      Me.lblAgenteIngBrutos.Size = New System.Drawing.Size(117, 13)
      Me.lblAgenteIngBrutos.TabIndex = 9
      Me.lblAgenteIngBrutos.Text = "Agente Ingresos Brutos"
      '
      'txtAgenteIngBrutos
      '
      Me.txtAgenteIngBrutos.BindearPropiedadControl = "Text"
      Me.txtAgenteIngBrutos.BindearPropiedadEntidad = "AgenteIngBrutos"
      Me.txtAgenteIngBrutos.Enabled = False
      Me.txtAgenteIngBrutos.ForeColorFocus = System.Drawing.Color.Red
      Me.txtAgenteIngBrutos.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtAgenteIngBrutos.Formato = ""
      Me.txtAgenteIngBrutos.IsDecimal = False
      Me.txtAgenteIngBrutos.IsNumber = False
      Me.txtAgenteIngBrutos.IsPK = False
      Me.txtAgenteIngBrutos.IsRequired = False
      Me.txtAgenteIngBrutos.Key = ""
      Me.txtAgenteIngBrutos.LabelAsoc = Me.lblAgenteIngBrutos
      Me.txtAgenteIngBrutos.Location = New System.Drawing.Point(125, 144)
      Me.txtAgenteIngBrutos.MaxLength = 20
      Me.txtAgenteIngBrutos.Name = "txtAgenteIngBrutos"
      Me.txtAgenteIngBrutos.Size = New System.Drawing.Size(155, 20)
      Me.txtAgenteIngBrutos.TabIndex = 10
      '
      'chbEsAgentePercepcion
      '
      Me.chbEsAgentePercepcion.AutoSize = True
      Me.chbEsAgentePercepcion.BindearPropiedadControl = "Checked"
      Me.chbEsAgentePercepcion.BindearPropiedadEntidad = "EsAgentePercepcion"
      Me.chbEsAgentePercepcion.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
      Me.chbEsAgentePercepcion.ForeColorFocus = System.Drawing.Color.Red
      Me.chbEsAgentePercepcion.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
      Me.chbEsAgentePercepcion.IsPK = False
      Me.chbEsAgentePercepcion.IsRequired = False
      Me.chbEsAgentePercepcion.Key = Nothing
      Me.chbEsAgentePercepcion.LabelAsoc = Nothing
      Me.chbEsAgentePercepcion.Location = New System.Drawing.Point(125, 91)
      Me.chbEsAgentePercepcion.Name = "chbEsAgentePercepcion"
      Me.chbEsAgentePercepcion.RightToLeft = System.Windows.Forms.RightToLeft.Yes
      Me.chbEsAgentePercepcion.Size = New System.Drawing.Size(132, 17)
      Me.chbEsAgentePercepcion.TabIndex = 6
      Me.chbEsAgentePercepcion.Text = "Es Agente Percepción"
      Me.chbEsAgentePercepcion.UseVisualStyleBackColor = True
      '
      'lblIdProvincia
      '
      Me.lblIdProvincia.AutoSize = True
      Me.lblIdProvincia.Location = New System.Drawing.Point(8, 14)
      Me.lblIdProvincia.Name = "lblIdProvincia"
      Me.lblIdProvincia.Size = New System.Drawing.Size(40, 13)
      Me.lblIdProvincia.TabIndex = 0
      Me.lblIdProvincia.Text = "Código"
      '
      'txtIdProvincia
      '
      Me.txtIdProvincia.BindearPropiedadControl = "Text"
      Me.txtIdProvincia.BindearPropiedadEntidad = "IdProvincia"
      Me.txtIdProvincia.ForeColorFocus = System.Drawing.Color.Red
      Me.txtIdProvincia.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtIdProvincia.Formato = ""
      Me.txtIdProvincia.IsDecimal = False
      Me.txtIdProvincia.IsNumber = False
      Me.txtIdProvincia.IsPK = True
      Me.txtIdProvincia.IsRequired = False
      Me.txtIdProvincia.Key = ""
      Me.txtIdProvincia.LabelAsoc = Me.lblIdProvincia
      Me.txtIdProvincia.Location = New System.Drawing.Point(125, 11)
      Me.txtIdProvincia.MaxLength = 2
      Me.txtIdProvincia.Name = "txtIdProvincia"
      Me.txtIdProvincia.Size = New System.Drawing.Size(74, 20)
      Me.txtIdProvincia.TabIndex = 1
      '
      'GroupBox2
      '
      Me.GroupBox2.Controls.Add(Me.UcCuentasVentas)
      Me.GroupBox2.Location = New System.Drawing.Point(11, 256)
      Me.GroupBox2.Name = "GroupBox2"
      Me.GroupBox2.Size = New System.Drawing.Size(458, 48)
      Me.GroupBox2.TabIndex = 14
      Me.GroupBox2.TabStop = False
      Me.GroupBox2.Text = "Ventas / Emisión de Recibos"
      '
      'UcCuentasVentas
      '
      Me.UcCuentasVentas.Cuenta = Nothing
      Me.UcCuentasVentas.Location = New System.Drawing.Point(6, 19)
      Me.UcCuentasVentas.Name = "UcCuentasVentas"
      Me.UcCuentasVentas.Size = New System.Drawing.Size(444, 20)
      Me.UcCuentasVentas.TabIndex = 0
      '
      'GroupBox1
      '
      Me.GroupBox1.Controls.Add(Me.UcCuentasCompras)
      Me.GroupBox1.Location = New System.Drawing.Point(11, 201)
      Me.GroupBox1.Name = "GroupBox1"
      Me.GroupBox1.Size = New System.Drawing.Size(458, 49)
      Me.GroupBox1.TabIndex = 13
      Me.GroupBox1.TabStop = False
      Me.GroupBox1.Text = "Compras / Pago a Proveedores"
      '
      'UcCuentasCompras
      '
      Me.UcCuentasCompras.Cuenta = Nothing
      Me.UcCuentasCompras.Location = New System.Drawing.Point(6, 19)
      Me.UcCuentasCompras.Name = "UcCuentasCompras"
      Me.UcCuentasCompras.Size = New System.Drawing.Size(444, 20)
      Me.UcCuentasCompras.TabIndex = 0
      '
      'txtJurisdiccion
      '
      Me.txtJurisdiccion.BindearPropiedadControl = "Text"
      Me.txtJurisdiccion.BindearPropiedadEntidad = "Jurisdiccion"
      Me.txtJurisdiccion.ForeColorFocus = System.Drawing.Color.Red
      Me.txtJurisdiccion.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtJurisdiccion.Formato = ""
      Me.txtJurisdiccion.IsDecimal = False
      Me.txtJurisdiccion.IsNumber = True
      Me.txtJurisdiccion.IsPK = False
      Me.txtJurisdiccion.IsRequired = True
      Me.txtJurisdiccion.Key = ""
      Me.txtJurisdiccion.LabelAsoc = Me.lblJurisdiccion
      Me.txtJurisdiccion.Location = New System.Drawing.Point(125, 172)
      Me.txtJurisdiccion.MaxLength = 6
      Me.txtJurisdiccion.Name = "txtJurisdiccion"
      Me.txtJurisdiccion.Size = New System.Drawing.Size(74, 20)
      Me.txtJurisdiccion.TabIndex = 12
      Me.txtJurisdiccion.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'lblJurisdiccion
      '
      Me.lblJurisdiccion.AutoSize = True
      Me.lblJurisdiccion.Location = New System.Drawing.Point(8, 175)
      Me.lblJurisdiccion.Name = "lblJurisdiccion"
      Me.lblJurisdiccion.Size = New System.Drawing.Size(62, 13)
      Me.lblJurisdiccion.TabIndex = 11
      Me.lblJurisdiccion.Text = "Jurisdicción"
      '
      'cmbPais
      '
      Me.cmbPais.BindearPropiedadControl = "SelectedValue"
      Me.cmbPais.BindearPropiedadEntidad = "IdPais"
      Me.cmbPais.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cmbPais.ForeColorFocus = System.Drawing.Color.Red
      Me.cmbPais.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.cmbPais.FormattingEnabled = True
      Me.cmbPais.IsPK = False
      Me.cmbPais.IsRequired = False
      Me.cmbPais.Key = Nothing
      Me.cmbPais.LabelAsoc = Nothing
      Me.cmbPais.Location = New System.Drawing.Point(125, 63)
      Me.cmbPais.Name = "cmbPais"
      Me.cmbPais.Size = New System.Drawing.Size(155, 21)
      Me.cmbPais.TabIndex = 5
      '
      'lblPais
      '
      Me.lblPais.AutoSize = True
      Me.lblPais.Location = New System.Drawing.Point(8, 66)
      Me.lblPais.Name = "lblPais"
      Me.lblPais.Size = New System.Drawing.Size(29, 13)
      Me.lblPais.TabIndex = 4
      Me.lblPais.Text = "País"
      '
      'ProvinciasDetalle
      '
      Me.AcceptButton = Nothing
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.ClientSize = New System.Drawing.Size(476, 351)
      Me.Controls.Add(Me.cmbPais)
      Me.Controls.Add(Me.lblPais)
      Me.Controls.Add(Me.txtJurisdiccion)
      Me.Controls.Add(Me.lblJurisdiccion)
      Me.Controls.Add(Me.GroupBox2)
      Me.Controls.Add(Me.GroupBox1)
      Me.Controls.Add(Me.chbEsAgentePercepcion)
      Me.Controls.Add(Me.lblProvincia)
      Me.Controls.Add(Me.txtProvincia)
      Me.Controls.Add(Me.txtAgenteIngBrutos)
      Me.Controls.Add(Me.lblAgenteIngBrutos)
      Me.Controls.Add(Me.txtIdProvincia)
      Me.Controls.Add(Me.lblIdProvincia)
      Me.Controls.Add(Me.txtIngBrutos)
      Me.Controls.Add(Me.lblIngBrutos)
      Me.Name = "ProvinciasDetalle"
      Me.Text = "Provincia"
      Me.Controls.SetChildIndex(Me.btnAplicar, 0)
      Me.Controls.SetChildIndex(Me.btnCancelar, 0)
      Me.Controls.SetChildIndex(Me.btnAceptar, 0)
      Me.Controls.SetChildIndex(Me.btnCopiar, 0)
      Me.Controls.SetChildIndex(Me.lblIngBrutos, 0)
      Me.Controls.SetChildIndex(Me.txtIngBrutos, 0)
      Me.Controls.SetChildIndex(Me.lblIdProvincia, 0)
      Me.Controls.SetChildIndex(Me.txtIdProvincia, 0)
      Me.Controls.SetChildIndex(Me.lblAgenteIngBrutos, 0)
      Me.Controls.SetChildIndex(Me.txtAgenteIngBrutos, 0)
      Me.Controls.SetChildIndex(Me.txtProvincia, 0)
      Me.Controls.SetChildIndex(Me.lblProvincia, 0)
      Me.Controls.SetChildIndex(Me.chbEsAgentePercepcion, 0)
      Me.Controls.SetChildIndex(Me.GroupBox1, 0)
      Me.Controls.SetChildIndex(Me.GroupBox2, 0)
      Me.Controls.SetChildIndex(Me.lblJurisdiccion, 0)
      Me.Controls.SetChildIndex(Me.txtJurisdiccion, 0)
      Me.Controls.SetChildIndex(Me.lblPais, 0)
      Me.Controls.SetChildIndex(Me.cmbPais, 0)
      Me.GroupBox2.ResumeLayout(False)
      Me.GroupBox1.ResumeLayout(False)
      Me.ResumeLayout(False)
      Me.PerformLayout()

   End Sub
   Friend WithEvents lblProvincia As Eniac.Controles.Label
   Friend WithEvents txtProvincia As Eniac.Controles.TextBox
   Friend WithEvents txtIngBrutos As Eniac.Controles.TextBox
   Friend WithEvents lblIngBrutos As Eniac.Controles.Label
   Friend WithEvents lblAgenteIngBrutos As Eniac.Controles.Label
   Friend WithEvents txtAgenteIngBrutos As Eniac.Controles.TextBox
   Friend WithEvents chbEsAgentePercepcion As Eniac.Controles.CheckBox
   Friend WithEvents lblIdProvincia As Eniac.Controles.Label
   Friend WithEvents txtIdProvincia As Eniac.Controles.TextBox
   Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
   Friend WithEvents UcCuentasVentas As Eniac.Win.ucCuentas
   Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
   Friend WithEvents UcCuentasCompras As Eniac.Win.ucCuentas
   Friend WithEvents txtJurisdiccion As Eniac.Controles.TextBox
   Friend WithEvents lblJurisdiccion As Eniac.Controles.Label
   Friend WithEvents cmbPais As Eniac.Controles.ComboBox
   Friend WithEvents lblPais As Eniac.Controles.Label
End Class
