<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ImpresionTicketFiscalConfirmar
   Inherits BaseForm

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
      Me.components = New System.ComponentModel.Container()
      Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ImpresionTicketFiscalConfirmar))
      Me.imageList1 = New System.Windows.Forms.ImageList(Me.components)
      Me.btnAceptar = New System.Windows.Forms.Button()
      Me.btnCancelar = New System.Windows.Forms.Button()
      Me.txtTipoComprobante = New Eniac.Controles.TextBox()
      Me.lblTipoComprobante = New Eniac.Controles.Label()
      Me.txtLetra = New Eniac.Controles.TextBox()
      Me.lblLetra = New Eniac.Controles.Label()
      Me.txtEmisor = New Eniac.Controles.TextBox()
      Me.lblEmisor = New Eniac.Controles.Label()
      Me.txtNumero = New Eniac.Controles.TextBox()
      Me.lblNumero = New Eniac.Controles.Label()
      Me.txtNumeroEnPapel = New Eniac.Controles.TextBox()
      Me.lblNumeroEnPapel = New Eniac.Controles.Label()
      Me.SuspendLayout()
      '
      'imageList1
      '
      Me.imageList1.ImageStream = CType(resources.GetObject("imageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
      Me.imageList1.TransparentColor = System.Drawing.Color.Transparent
      Me.imageList1.Images.SetKeyName(0, "check2.ico")
      Me.imageList1.Images.SetKeyName(1, "delete2.ico")
      '
      'btnAceptar
      '
      Me.btnAceptar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.btnAceptar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
      Me.btnAceptar.ImageIndex = 0
      Me.btnAceptar.ImageList = Me.imageList1
      Me.btnAceptar.Location = New System.Drawing.Point(166, 136)
      Me.btnAceptar.Name = "btnAceptar"
      Me.btnAceptar.Size = New System.Drawing.Size(80, 30)
      Me.btnAceptar.TabIndex = 2
      Me.btnAceptar.Text = "&Aceptar"
      Me.btnAceptar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      Me.btnAceptar.UseVisualStyleBackColor = True
      '
      'btnCancelar
      '
      Me.btnCancelar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel
      Me.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
      Me.btnCancelar.ImageIndex = 1
      Me.btnCancelar.ImageList = Me.imageList1
      Me.btnCancelar.Location = New System.Drawing.Point(252, 136)
      Me.btnCancelar.Name = "btnCancelar"
      Me.btnCancelar.Size = New System.Drawing.Size(80, 30)
      Me.btnCancelar.TabIndex = 3
      Me.btnCancelar.Text = "&Cancelar"
      Me.btnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      Me.btnCancelar.UseVisualStyleBackColor = True
      '
      'txtTipoComprobante
      '
      Me.txtTipoComprobante.BindearPropiedadControl = Nothing
      Me.txtTipoComprobante.BindearPropiedadEntidad = Nothing
      Me.txtTipoComprobante.ForeColorFocus = System.Drawing.Color.Red
      Me.txtTipoComprobante.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtTipoComprobante.Formato = "##0"
      Me.txtTipoComprobante.IsDecimal = False
      Me.txtTipoComprobante.IsNumber = True
      Me.txtTipoComprobante.IsPK = False
      Me.txtTipoComprobante.IsRequired = False
      Me.txtTipoComprobante.Key = ""
      Me.txtTipoComprobante.LabelAsoc = Me.lblTipoComprobante
      Me.txtTipoComprobante.Location = New System.Drawing.Point(28, 51)
      Me.txtTipoComprobante.MaxLength = 8
      Me.txtTipoComprobante.Name = "txtTipoComprobante"
      Me.txtTipoComprobante.ReadOnly = True
      Me.txtTipoComprobante.Size = New System.Drawing.Size(105, 20)
      Me.txtTipoComprobante.TabIndex = 5
      Me.txtTipoComprobante.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'lblTipoComprobante
      '
      Me.lblTipoComprobante.AutoSize = True
      Me.lblTipoComprobante.ImeMode = System.Windows.Forms.ImeMode.NoControl
      Me.lblTipoComprobante.LabelAsoc = Nothing
      Me.lblTipoComprobante.Location = New System.Drawing.Point(25, 35)
      Me.lblTipoComprobante.Name = "lblTipoComprobante"
      Me.lblTipoComprobante.Size = New System.Drawing.Size(28, 13)
      Me.lblTipoComprobante.TabIndex = 4
      Me.lblTipoComprobante.Text = "Tipo"
      '
      'txtLetra
      '
      Me.txtLetra.BindearPropiedadControl = Nothing
      Me.txtLetra.BindearPropiedadEntidad = Nothing
      Me.txtLetra.ForeColorFocus = System.Drawing.Color.Red
      Me.txtLetra.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtLetra.Formato = "##0"
      Me.txtLetra.IsDecimal = False
      Me.txtLetra.IsNumber = True
      Me.txtLetra.IsPK = False
      Me.txtLetra.IsRequired = False
      Me.txtLetra.Key = ""
      Me.txtLetra.LabelAsoc = Me.lblLetra
      Me.txtLetra.Location = New System.Drawing.Point(139, 51)
      Me.txtLetra.MaxLength = 8
      Me.txtLetra.Name = "txtLetra"
      Me.txtLetra.ReadOnly = True
      Me.txtLetra.Size = New System.Drawing.Size(28, 20)
      Me.txtLetra.TabIndex = 7
      Me.txtLetra.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'lblLetra
      '
      Me.lblLetra.AutoSize = True
      Me.lblLetra.ImeMode = System.Windows.Forms.ImeMode.NoControl
      Me.lblLetra.LabelAsoc = Nothing
      Me.lblLetra.Location = New System.Drawing.Point(136, 35)
      Me.lblLetra.Name = "lblLetra"
      Me.lblLetra.Size = New System.Drawing.Size(31, 13)
      Me.lblLetra.TabIndex = 6
      Me.lblLetra.Text = "Letra"
      '
      'txtEmisor
      '
      Me.txtEmisor.BindearPropiedadControl = Nothing
      Me.txtEmisor.BindearPropiedadEntidad = Nothing
      Me.txtEmisor.ForeColorFocus = System.Drawing.Color.Red
      Me.txtEmisor.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtEmisor.Formato = "##0"
      Me.txtEmisor.IsDecimal = False
      Me.txtEmisor.IsNumber = True
      Me.txtEmisor.IsPK = False
      Me.txtEmisor.IsRequired = False
      Me.txtEmisor.Key = ""
      Me.txtEmisor.LabelAsoc = Me.lblEmisor
      Me.txtEmisor.Location = New System.Drawing.Point(173, 51)
      Me.txtEmisor.MaxLength = 8
      Me.txtEmisor.Name = "txtEmisor"
      Me.txtEmisor.ReadOnly = True
      Me.txtEmisor.Size = New System.Drawing.Size(35, 20)
      Me.txtEmisor.TabIndex = 9
      Me.txtEmisor.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'lblEmisor
      '
      Me.lblEmisor.AutoSize = True
      Me.lblEmisor.ImeMode = System.Windows.Forms.ImeMode.NoControl
      Me.lblEmisor.LabelAsoc = Nothing
      Me.lblEmisor.Location = New System.Drawing.Point(170, 35)
      Me.lblEmisor.Name = "lblEmisor"
      Me.lblEmisor.Size = New System.Drawing.Size(38, 13)
      Me.lblEmisor.TabIndex = 8
      Me.lblEmisor.Text = "Emisor"
      '
      'txtNumero
      '
      Me.txtNumero.BindearPropiedadControl = Nothing
      Me.txtNumero.BindearPropiedadEntidad = Nothing
      Me.txtNumero.ForeColorFocus = System.Drawing.Color.Red
      Me.txtNumero.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtNumero.Formato = "##0"
      Me.txtNumero.IsDecimal = False
      Me.txtNumero.IsNumber = True
      Me.txtNumero.IsPK = False
      Me.txtNumero.IsRequired = False
      Me.txtNumero.Key = ""
      Me.txtNumero.LabelAsoc = Me.lblNumero
      Me.txtNumero.Location = New System.Drawing.Point(214, 51)
      Me.txtNumero.MaxLength = 8
      Me.txtNumero.Name = "txtNumero"
      Me.txtNumero.ReadOnly = True
      Me.txtNumero.Size = New System.Drawing.Size(105, 20)
      Me.txtNumero.TabIndex = 11
      Me.txtNumero.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'lblNumero
      '
      Me.lblNumero.AutoSize = True
      Me.lblNumero.ImeMode = System.Windows.Forms.ImeMode.NoControl
      Me.lblNumero.LabelAsoc = Nothing
      Me.lblNumero.Location = New System.Drawing.Point(211, 35)
      Me.lblNumero.Name = "lblNumero"
      Me.lblNumero.Size = New System.Drawing.Size(44, 13)
      Me.lblNumero.TabIndex = 10
      Me.lblNumero.Text = "Número"
      '
      'txtNumeroEnPapel
      '
      Me.txtNumeroEnPapel.BindearPropiedadControl = Nothing
      Me.txtNumeroEnPapel.BindearPropiedadEntidad = Nothing
      Me.txtNumeroEnPapel.ForeColorFocus = System.Drawing.Color.Red
      Me.txtNumeroEnPapel.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtNumeroEnPapel.Formato = "##0"
      Me.txtNumeroEnPapel.IsDecimal = False
      Me.txtNumeroEnPapel.IsNumber = True
      Me.txtNumeroEnPapel.IsPK = False
      Me.txtNumeroEnPapel.IsRequired = False
      Me.txtNumeroEnPapel.Key = ""
      Me.txtNumeroEnPapel.LabelAsoc = Me.lblNumeroEnPapel
      Me.txtNumeroEnPapel.Location = New System.Drawing.Point(214, 97)
      Me.txtNumeroEnPapel.MaxLength = 8
      Me.txtNumeroEnPapel.Name = "txtNumeroEnPapel"
      Me.txtNumeroEnPapel.Size = New System.Drawing.Size(105, 20)
      Me.txtNumeroEnPapel.TabIndex = 1
      Me.txtNumeroEnPapel.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'lblNumeroEnPapel
      '
      Me.lblNumeroEnPapel.AutoSize = True
      Me.lblNumeroEnPapel.ImeMode = System.Windows.Forms.ImeMode.NoControl
      Me.lblNumeroEnPapel.LabelAsoc = Nothing
      Me.lblNumeroEnPapel.Location = New System.Drawing.Point(119, 100)
      Me.lblNumeroEnPapel.Name = "lblNumeroEnPapel"
      Me.lblNumeroEnPapel.Size = New System.Drawing.Size(89, 13)
      Me.lblNumeroEnPapel.TabIndex = 0
      Me.lblNumeroEnPapel.Text = "Número en Papel"
      '
      'ImpresionTicketFiscalConfirmar
      '
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.ClientSize = New System.Drawing.Size(344, 178)
      Me.Controls.Add(Me.txtNumeroEnPapel)
      Me.Controls.Add(Me.lblNumeroEnPapel)
      Me.Controls.Add(Me.txtNumero)
      Me.Controls.Add(Me.lblNumero)
      Me.Controls.Add(Me.txtEmisor)
      Me.Controls.Add(Me.lblEmisor)
      Me.Controls.Add(Me.txtLetra)
      Me.Controls.Add(Me.lblLetra)
      Me.Controls.Add(Me.txtTipoComprobante)
      Me.Controls.Add(Me.lblTipoComprobante)
      Me.Controls.Add(Me.btnAceptar)
      Me.Controls.Add(Me.btnCancelar)
      Me.Name = "ImpresionTicketFiscalConfirmar"
      Me.ShowInTaskbar = False
      Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
      Me.Text = "Controlar Info: Confirmar Número"
      Me.ResumeLayout(False)
      Me.PerformLayout()

   End Sub
   Private WithEvents imageList1 As System.Windows.Forms.ImageList
   Protected WithEvents btnAceptar As System.Windows.Forms.Button
   Protected WithEvents btnCancelar As System.Windows.Forms.Button
   Friend WithEvents txtTipoComprobante As Eniac.Controles.TextBox
   Friend WithEvents lblTipoComprobante As Eniac.Controles.Label
   Friend WithEvents txtLetra As Eniac.Controles.TextBox
   Friend WithEvents lblLetra As Eniac.Controles.Label
   Friend WithEvents txtEmisor As Eniac.Controles.TextBox
   Friend WithEvents lblEmisor As Eniac.Controles.Label
   Friend WithEvents txtNumero As Eniac.Controles.TextBox
   Friend WithEvents lblNumero As Eniac.Controles.Label
   Friend WithEvents txtNumeroEnPapel As Eniac.Controles.TextBox
   Friend WithEvents lblNumeroEnPapel As Eniac.Controles.Label
End Class
