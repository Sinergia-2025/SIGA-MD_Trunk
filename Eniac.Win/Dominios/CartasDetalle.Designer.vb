<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CartasDetalle
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
      Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(CartasDetalle))
      Me.txtId = New Eniac.Controles.TextBox()
      Me.lblId = New Eniac.Controles.Label()
      Me.txtNombre = New Eniac.Controles.TextBox()
      Me.lblNombre = New Eniac.Controles.Label()
      Me.txtDias = New Eniac.Controles.TextBox()
      Me.lblDias = New Eniac.Controles.Label()
      Me.lblTexto = New Eniac.Controles.Label()
      Me.txtFirma = New Eniac.Controles.TextBox()
      Me.lbFirma = New Eniac.Controles.Label()
      Me.txtTexto = New Eniac.Controles.TextBox()
      Me.txtTexto2 = New Eniac.Controles.TextBox()
      Me.lblTexto2 = New Eniac.Controles.Label()
      Me.txtProxima = New Eniac.Controles.TextBox()
      Me.lblProxima = New Eniac.Controles.Label()
      Me.chbMiraAnoEnCurso = New Eniac.Controles.CheckBox()
      Me.txtTextoRTF = New System.Windows.Forms.RichTextBox()
      Me.txtTexto2RTF = New System.Windows.Forms.RichTextBox()
      Me.chbEsHTML = New Eniac.Controles.CheckBox()
      Me.TextBox1 = New Eniac.Controles.TextBox()
      Me.Label1 = New Eniac.Controles.Label()
      Me.SuspendLayout()
      '
      'btnAceptar
      '
      Me.btnAceptar.Location = New System.Drawing.Point(357, 480)
      Me.btnAceptar.TabIndex = 7
      '
      'btnCancelar
      '
      Me.btnCancelar.Location = New System.Drawing.Point(443, 480)
      Me.btnCancelar.TabIndex = 8
      '
      'txtId
      '
      Me.txtId.BindearPropiedadControl = "Text"
      Me.txtId.BindearPropiedadEntidad = "IdCarta"
      Me.txtId.ForeColorFocus = System.Drawing.Color.Red
      Me.txtId.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtId.Formato = ""
      Me.txtId.IsDecimal = False
      Me.txtId.IsNumber = True
      Me.txtId.IsPK = True
      Me.txtId.IsRequired = True
      Me.txtId.Key = ""
      Me.txtId.LabelAsoc = Me.lblId
      Me.txtId.Location = New System.Drawing.Point(72, 12)
      Me.txtId.MaxLength = 9
      Me.txtId.Name = "txtId"
      Me.txtId.Size = New System.Drawing.Size(54, 20)
      Me.txtId.TabIndex = 0
      Me.txtId.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'lblId
      '
      Me.lblId.AutoSize = True
      Me.lblId.Location = New System.Drawing.Point(10, 16)
      Me.lblId.Name = "lblId"
      Me.lblId.Size = New System.Drawing.Size(16, 13)
      Me.lblId.TabIndex = 13
      Me.lblId.Text = "Id"
      '
      'txtNombre
      '
      Me.txtNombre.BindearPropiedadControl = "Text"
      Me.txtNombre.BindearPropiedadEntidad = "NombreCarta"
      Me.txtNombre.ForeColorFocus = System.Drawing.Color.Red
      Me.txtNombre.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtNombre.Formato = ""
      Me.txtNombre.IsDecimal = False
      Me.txtNombre.IsNumber = False
      Me.txtNombre.IsPK = False
      Me.txtNombre.IsRequired = True
      Me.txtNombre.Key = ""
      Me.txtNombre.LabelAsoc = Me.lblNombre
      Me.txtNombre.Location = New System.Drawing.Point(238, 12)
      Me.txtNombre.MaxLength = 50
      Me.txtNombre.Name = "txtNombre"
      Me.txtNombre.Size = New System.Drawing.Size(275, 20)
      Me.txtNombre.TabIndex = 1
      '
      'lblNombre
      '
      Me.lblNombre.AutoSize = True
      Me.lblNombre.Location = New System.Drawing.Point(176, 16)
      Me.lblNombre.Name = "lblNombre"
      Me.lblNombre.Size = New System.Drawing.Size(44, 13)
      Me.lblNombre.TabIndex = 14
      Me.lblNombre.Text = "Nombre"
      '
      'txtDias
      '
      Me.txtDias.BindearPropiedadControl = "Text"
      Me.txtDias.BindearPropiedadEntidad = "DiasDefault"
      Me.txtDias.ForeColorFocus = System.Drawing.Color.Red
      Me.txtDias.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtDias.Formato = ""
      Me.txtDias.IsDecimal = False
      Me.txtDias.IsNumber = True
      Me.txtDias.IsPK = False
      Me.txtDias.IsRequired = True
      Me.txtDias.Key = ""
      Me.txtDias.LabelAsoc = Me.lblDias
      Me.txtDias.Location = New System.Drawing.Point(72, 39)
      Me.txtDias.MaxLength = 50
      Me.txtDias.Name = "txtDias"
      Me.txtDias.Size = New System.Drawing.Size(54, 20)
      Me.txtDias.TabIndex = 2
      '
      'lblDias
      '
      Me.lblDias.AutoSize = True
      Me.lblDias.Location = New System.Drawing.Point(10, 43)
      Me.lblDias.Name = "lblDias"
      Me.lblDias.Size = New System.Drawing.Size(28, 13)
      Me.lblDias.TabIndex = 16
      Me.lblDias.Text = "Dias"
      '
      'lblTexto
      '
      Me.lblTexto.AutoSize = True
      Me.lblTexto.Location = New System.Drawing.Point(10, 106)
      Me.lblTexto.Name = "lblTexto"
      Me.lblTexto.Size = New System.Drawing.Size(53, 13)
      Me.lblTexto.TabIndex = 18
      Me.lblTexto.Text = "Texto P.1"
      '
      'txtFirma
      '
      Me.txtFirma.BindearPropiedadControl = "Text"
      Me.txtFirma.BindearPropiedadEntidad = "Firma"
      Me.txtFirma.ForeColorFocus = System.Drawing.Color.Red
      Me.txtFirma.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtFirma.Formato = ""
      Me.txtFirma.IsDecimal = False
      Me.txtFirma.IsNumber = False
      Me.txtFirma.IsPK = False
      Me.txtFirma.IsRequired = True
      Me.txtFirma.Key = ""
      Me.txtFirma.LabelAsoc = Me.lbFirma
      Me.txtFirma.Location = New System.Drawing.Point(72, 445)
      Me.txtFirma.MaxLength = 50
      Me.txtFirma.Name = "txtFirma"
      Me.txtFirma.Size = New System.Drawing.Size(272, 20)
      Me.txtFirma.TabIndex = 6
      '
      'lbFirma
      '
      Me.lbFirma.AutoSize = True
      Me.lbFirma.Location = New System.Drawing.Point(10, 449)
      Me.lbFirma.Name = "lbFirma"
      Me.lbFirma.Size = New System.Drawing.Size(32, 13)
      Me.lbFirma.TabIndex = 20
      Me.lbFirma.Text = "Firma"
      '
      'txtTexto
      '
      Me.txtTexto.BindearPropiedadControl = "Text"
      Me.txtTexto.BindearPropiedadEntidad = "Texto"
      Me.txtTexto.ForeColorFocus = System.Drawing.Color.Red
      Me.txtTexto.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtTexto.Formato = ""
      Me.txtTexto.IsDecimal = False
      Me.txtTexto.IsNumber = False
      Me.txtTexto.IsPK = False
      Me.txtTexto.IsRequired = True
      Me.txtTexto.Key = ""
      Me.txtTexto.LabelAsoc = Me.lblTexto
      Me.txtTexto.Location = New System.Drawing.Point(455, 31)
      Me.txtTexto.MaxLength = 1000
      Me.txtTexto.Multiline = True
      Me.txtTexto.Name = "txtTexto"
      Me.txtTexto.Size = New System.Drawing.Size(0, 0)
      Me.txtTexto.TabIndex = 4
      '
      'txtTexto2
      '
      Me.txtTexto2.BindearPropiedadControl = "Text"
      Me.txtTexto2.BindearPropiedadEntidad = "Texto2"
      Me.txtTexto2.ForeColorFocus = System.Drawing.Color.Red
      Me.txtTexto2.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtTexto2.Formato = ""
      Me.txtTexto2.IsDecimal = False
      Me.txtTexto2.IsNumber = False
      Me.txtTexto2.IsPK = False
      Me.txtTexto2.IsRequired = False
      Me.txtTexto2.Key = ""
      Me.txtTexto2.LabelAsoc = Me.lblTexto2
      Me.txtTexto2.Location = New System.Drawing.Point(486, 30)
      Me.txtTexto2.MaxLength = 1000
      Me.txtTexto2.Multiline = True
      Me.txtTexto2.Name = "txtTexto2"
      Me.txtTexto2.Size = New System.Drawing.Size(0, 0)
      Me.txtTexto2.TabIndex = 5
      '
      'lblTexto2
      '
      Me.lblTexto2.AutoSize = True
      Me.lblTexto2.Location = New System.Drawing.Point(10, 278)
      Me.lblTexto2.Name = "lblTexto2"
      Me.lblTexto2.Size = New System.Drawing.Size(53, 13)
      Me.lblTexto2.TabIndex = 23
      Me.lblTexto2.Text = "Texto P.2"
      '
      'txtProxima
      '
      Me.txtProxima.BindearPropiedadControl = "Text"
      Me.txtProxima.BindearPropiedadEntidad = "ProximaCarta"
      Me.txtProxima.ForeColorFocus = System.Drawing.Color.Red
      Me.txtProxima.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtProxima.Formato = ""
      Me.txtProxima.IsDecimal = False
      Me.txtProxima.IsNumber = True
      Me.txtProxima.IsPK = False
      Me.txtProxima.IsRequired = False
      Me.txtProxima.Key = ""
      Me.txtProxima.LabelAsoc = Me.lblProxima
      Me.txtProxima.Location = New System.Drawing.Point(238, 39)
      Me.txtProxima.MaxLength = 50
      Me.txtProxima.Name = "txtProxima"
      Me.txtProxima.Size = New System.Drawing.Size(54, 20)
      Me.txtProxima.TabIndex = 3
      '
      'lblProxima
      '
      Me.lblProxima.AutoSize = True
      Me.lblProxima.Location = New System.Drawing.Point(176, 43)
      Me.lblProxima.Name = "lblProxima"
      Me.lblProxima.Size = New System.Drawing.Size(59, 13)
      Me.lblProxima.TabIndex = 26
      Me.lblProxima.Text = "Prox. Carta"
      '
      'chbMiraAnoEnCurso
      '
      Me.chbMiraAnoEnCurso.AutoSize = True
      Me.chbMiraAnoEnCurso.BindearPropiedadControl = "Checked"
      Me.chbMiraAnoEnCurso.BindearPropiedadEntidad = "MiraAnoEnCurso"
      Me.chbMiraAnoEnCurso.ForeColorFocus = System.Drawing.Color.Red
      Me.chbMiraAnoEnCurso.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
      Me.chbMiraAnoEnCurso.IsPK = False
      Me.chbMiraAnoEnCurso.IsRequired = False
      Me.chbMiraAnoEnCurso.Key = Nothing
      Me.chbMiraAnoEnCurso.LabelAsoc = Nothing
      Me.chbMiraAnoEnCurso.Location = New System.Drawing.Point(386, 41)
      Me.chbMiraAnoEnCurso.Name = "chbMiraAnoEnCurso"
      Me.chbMiraAnoEnCurso.Size = New System.Drawing.Size(127, 17)
      Me.chbMiraAnoEnCurso.TabIndex = 28
      Me.chbMiraAnoEnCurso.Text = "Incluye Año en Curso"
      Me.chbMiraAnoEnCurso.UseVisualStyleBackColor = True
      '
      'txtTextoRTF
      '
      Me.txtTextoRTF.Location = New System.Drawing.Point(72, 109)
      Me.txtTextoRTF.Name = "txtTextoRTF"
      Me.txtTextoRTF.Size = New System.Drawing.Size(441, 154)
      Me.txtTextoRTF.TabIndex = 29
      Me.txtTextoRTF.Text = ""
      '
      'txtTexto2RTF
      '
      Me.txtTexto2RTF.Location = New System.Drawing.Point(72, 279)
      Me.txtTexto2RTF.Name = "txtTexto2RTF"
      Me.txtTexto2RTF.Size = New System.Drawing.Size(441, 160)
      Me.txtTexto2RTF.TabIndex = 30
      Me.txtTexto2RTF.Text = ""
      '
      'chbEsHTML
      '
      Me.chbEsHTML.AutoSize = True
      Me.chbEsHTML.BindearPropiedadControl = "Checked"
      Me.chbEsHTML.BindearPropiedadEntidad = "EsHTML"
      Me.chbEsHTML.ForeColorFocus = System.Drawing.Color.Red
      Me.chbEsHTML.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
      Me.chbEsHTML.IsPK = False
      Me.chbEsHTML.IsRequired = False
      Me.chbEsHTML.Key = Nothing
      Me.chbEsHTML.LabelAsoc = Nothing
      Me.chbEsHTML.Location = New System.Drawing.Point(402, 447)
      Me.chbEsHTML.Name = "chbEsHTML"
      Me.chbEsHTML.Size = New System.Drawing.Size(111, 17)
      Me.chbEsHTML.TabIndex = 31
      Me.chbEsHTML.Text = "Mantiene Formato"
      Me.chbEsHTML.UseVisualStyleBackColor = True
      '
      'TextBox1
      '
      Me.TextBox1.BindearPropiedadControl = "Text"
      Me.TextBox1.BindearPropiedadEntidad = "Tipo"
      Me.TextBox1.ForeColorFocus = System.Drawing.Color.Red
      Me.TextBox1.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.TextBox1.Formato = ""
      Me.TextBox1.IsDecimal = False
      Me.TextBox1.IsNumber = False
      Me.TextBox1.IsPK = False
      Me.TextBox1.IsRequired = True
      Me.TextBox1.Key = ""
      Me.TextBox1.LabelAsoc = Me.Label1
      Me.TextBox1.Location = New System.Drawing.Point(238, 66)
      Me.TextBox1.MaxLength = 50
      Me.TextBox1.Name = "TextBox1"
      Me.TextBox1.Size = New System.Drawing.Size(131, 20)
      Me.TextBox1.TabIndex = 32
      '
      'Label1
      '
      Me.Label1.AutoSize = True
      Me.Label1.Location = New System.Drawing.Point(177, 69)
      Me.Label1.Name = "Label1"
      Me.Label1.Size = New System.Drawing.Size(28, 13)
      Me.Label1.TabIndex = 33
      Me.Label1.Text = "Tipo"
      '
      'CartasDetalle
      '
      Me.AcceptButton = Nothing
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.ClientSize = New System.Drawing.Size(532, 515)
      Me.Controls.Add(Me.TextBox1)
      Me.Controls.Add(Me.Label1)
      Me.Controls.Add(Me.chbEsHTML)
      Me.Controls.Add(Me.txtTexto2RTF)
      Me.Controls.Add(Me.txtTextoRTF)
      Me.Controls.Add(Me.chbMiraAnoEnCurso)
      Me.Controls.Add(Me.txtProxima)
      Me.Controls.Add(Me.lblProxima)
      Me.Controls.Add(Me.txtTexto2)
      Me.Controls.Add(Me.lblTexto2)
      Me.Controls.Add(Me.txtTexto)
      Me.Controls.Add(Me.txtFirma)
      Me.Controls.Add(Me.lbFirma)
      Me.Controls.Add(Me.lblTexto)
      Me.Controls.Add(Me.txtDias)
      Me.Controls.Add(Me.lblDias)
      Me.Controls.Add(Me.txtNombre)
      Me.Controls.Add(Me.lblNombre)
      Me.Controls.Add(Me.txtId)
      Me.Controls.Add(Me.lblId)
      Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
      Me.Name = "CartasDetalle"
      Me.Text = " Carta"
      Me.Controls.SetChildIndex(Me.btnCancelar, 0)
      Me.Controls.SetChildIndex(Me.btnAceptar, 0)
      Me.Controls.SetChildIndex(Me.lblId, 0)
      Me.Controls.SetChildIndex(Me.txtId, 0)
      Me.Controls.SetChildIndex(Me.lblNombre, 0)
      Me.Controls.SetChildIndex(Me.txtNombre, 0)
      Me.Controls.SetChildIndex(Me.lblDias, 0)
      Me.Controls.SetChildIndex(Me.txtDias, 0)
      Me.Controls.SetChildIndex(Me.lblTexto, 0)
      Me.Controls.SetChildIndex(Me.lbFirma, 0)
      Me.Controls.SetChildIndex(Me.txtFirma, 0)
      Me.Controls.SetChildIndex(Me.txtTexto, 0)
      Me.Controls.SetChildIndex(Me.lblTexto2, 0)
      Me.Controls.SetChildIndex(Me.txtTexto2, 0)
      Me.Controls.SetChildIndex(Me.lblProxima, 0)
      Me.Controls.SetChildIndex(Me.txtProxima, 0)
      Me.Controls.SetChildIndex(Me.chbMiraAnoEnCurso, 0)
      Me.Controls.SetChildIndex(Me.txtTextoRTF, 0)
      Me.Controls.SetChildIndex(Me.txtTexto2RTF, 0)
      Me.Controls.SetChildIndex(Me.chbEsHTML, 0)
      Me.Controls.SetChildIndex(Me.Label1, 0)
      Me.Controls.SetChildIndex(Me.TextBox1, 0)
      Me.ResumeLayout(False)
      Me.PerformLayout()

   End Sub
   Friend WithEvents txtId As Eniac.Controles.TextBox
   Friend WithEvents lblId As Eniac.Controles.Label
   Friend WithEvents txtNombre As Eniac.Controles.TextBox
   Friend WithEvents lblNombre As Eniac.Controles.Label
   Friend WithEvents txtDias As Eniac.Controles.TextBox
   Friend WithEvents lblDias As Eniac.Controles.Label
   Friend WithEvents lblTexto As Eniac.Controles.Label
   Friend WithEvents txtFirma As Eniac.Controles.TextBox
   Friend WithEvents lbFirma As Eniac.Controles.Label
   Friend WithEvents txtTexto As Eniac.Controles.TextBox
   Friend WithEvents txtTexto2 As Eniac.Controles.TextBox
   Friend WithEvents lblTexto2 As Eniac.Controles.Label
   Friend WithEvents txtProxima As Eniac.Controles.TextBox
   Friend WithEvents lblProxima As Eniac.Controles.Label
   Friend WithEvents chbMiraAnoEnCurso As Eniac.Controles.CheckBox
   Friend WithEvents txtTextoRTF As System.Windows.Forms.RichTextBox
   Friend WithEvents txtTexto2RTF As System.Windows.Forms.RichTextBox
   Friend WithEvents chbEsHTML As Eniac.Controles.CheckBox
   Friend WithEvents TextBox1 As Eniac.Controles.TextBox
   Friend WithEvents Label1 As Eniac.Controles.Label
End Class
