<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class RenumerarPedidos
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
      Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(RenumerarPedidos))
      Me.btnAceptar = New System.Windows.Forms.Button()
      Me.imageList1 = New System.Windows.Forms.ImageList(Me.components)
      Me.btnCancelar = New System.Windows.Forms.Button()
      Me.lblNumero = New Eniac.Controles.Label()
      Me.txtNumero = New Eniac.Controles.TextBox()
      Me.lblLetra = New Eniac.Controles.Label()
      Me.txtLetra = New Eniac.Controles.TextBox()
      Me.lblTipoComprobante = New Eniac.Controles.Label()
      Me.lblEmisor = New Eniac.Controles.Label()
      Me.txtEmisor = New Eniac.Controles.TextBox()
      Me.txtTipoComprobante = New Eniac.Controles.TextBox()
      Me.SuspendLayout()
      '
      'btnAceptar
      '
      Me.btnAceptar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.btnAceptar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
      Me.btnAceptar.ImageIndex = 0
      Me.btnAceptar.ImageList = Me.imageList1
      Me.btnAceptar.Location = New System.Drawing.Point(199, 63)
      Me.btnAceptar.Name = "btnAceptar"
      Me.btnAceptar.Size = New System.Drawing.Size(80, 30)
      Me.btnAceptar.TabIndex = 2
      Me.btnAceptar.Text = "&Aceptar"
      Me.btnAceptar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      Me.btnAceptar.UseVisualStyleBackColor = True
      '
      'imageList1
      '
      Me.imageList1.ImageStream = CType(resources.GetObject("imageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
      Me.imageList1.TransparentColor = System.Drawing.Color.Transparent
      Me.imageList1.Images.SetKeyName(0, "check2.ico")
      Me.imageList1.Images.SetKeyName(1, "delete2.ico")
      '
      'btnCancelar
      '
      Me.btnCancelar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel
      Me.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
      Me.btnCancelar.ImageIndex = 1
      Me.btnCancelar.ImageList = Me.imageList1
      Me.btnCancelar.Location = New System.Drawing.Point(285, 63)
      Me.btnCancelar.Name = "btnCancelar"
      Me.btnCancelar.Size = New System.Drawing.Size(80, 30)
      Me.btnCancelar.TabIndex = 3
      Me.btnCancelar.Text = "&Cancelar"
      Me.btnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      Me.btnCancelar.UseVisualStyleBackColor = True
      '
      'lblNumero
      '
      Me.lblNumero.AutoSize = True
      Me.lblNumero.ImeMode = System.Windows.Forms.ImeMode.NoControl
      Me.lblNumero.Location = New System.Drawing.Point(280, 16)
      Me.lblNumero.Name = "lblNumero"
      Me.lblNumero.Size = New System.Drawing.Size(44, 13)
      Me.lblNumero.TabIndex = 0
      Me.lblNumero.Text = "Número"
      '
      'txtNumero
      '
      Me.txtNumero.BindearPropiedadControl = Nothing
      Me.txtNumero.BindearPropiedadEntidad = Nothing
      Me.txtNumero.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
      Me.txtNumero.ForeColorFocus = System.Drawing.Color.Red
      Me.txtNumero.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtNumero.Formato = ""
      Me.txtNumero.IsDecimal = False
      Me.txtNumero.IsNumber = True
      Me.txtNumero.IsPK = False
      Me.txtNumero.IsRequired = False
      Me.txtNumero.Key = ""
      Me.txtNumero.LabelAsoc = Me.lblNumero
      Me.txtNumero.Location = New System.Drawing.Point(283, 32)
      Me.txtNumero.MaxLength = 8
      Me.txtNumero.Name = "txtNumero"
      Me.txtNumero.Size = New System.Drawing.Size(81, 20)
      Me.txtNumero.TabIndex = 1
      Me.txtNumero.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
      '
      'lblLetra
      '
      Me.lblLetra.AutoSize = True
      Me.lblLetra.ImeMode = System.Windows.Forms.ImeMode.NoControl
      Me.lblLetra.Location = New System.Drawing.Point(201, 16)
      Me.lblLetra.Name = "lblLetra"
      Me.lblLetra.Size = New System.Drawing.Size(28, 13)
      Me.lblLetra.TabIndex = 6
      Me.lblLetra.Text = "Tipo"
      '
      'txtLetra
      '
      Me.txtLetra.BindearPropiedadControl = Nothing
      Me.txtLetra.BindearPropiedadEntidad = Nothing
      Me.txtLetra.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
      Me.txtLetra.ForeColorFocus = System.Drawing.Color.Red
      Me.txtLetra.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtLetra.Formato = ""
      Me.txtLetra.IsDecimal = False
      Me.txtLetra.IsNumber = False
      Me.txtLetra.IsPK = False
      Me.txtLetra.IsRequired = False
      Me.txtLetra.Key = ""
      Me.txtLetra.LabelAsoc = Me.lblLetra
      Me.txtLetra.Location = New System.Drawing.Point(204, 32)
      Me.txtLetra.Name = "txtLetra"
      Me.txtLetra.ReadOnly = True
      Me.txtLetra.Size = New System.Drawing.Size(25, 20)
      Me.txtLetra.TabIndex = 7
      Me.txtLetra.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
      '
      'lblTipoComprobante
      '
      Me.lblTipoComprobante.AutoSize = True
      Me.lblTipoComprobante.ImeMode = System.Windows.Forms.ImeMode.NoControl
      Me.lblTipoComprobante.Location = New System.Drawing.Point(11, 16)
      Me.lblTipoComprobante.Name = "lblTipoComprobante"
      Me.lblTipoComprobante.Size = New System.Drawing.Size(94, 13)
      Me.lblTipoComprobante.TabIndex = 4
      Me.lblTipoComprobante.Text = "&Tipo Comprobante"
      '
      'lblEmisor
      '
      Me.lblEmisor.AutoSize = True
      Me.lblEmisor.ImeMode = System.Windows.Forms.ImeMode.NoControl
      Me.lblEmisor.Location = New System.Drawing.Point(232, 16)
      Me.lblEmisor.Name = "lblEmisor"
      Me.lblEmisor.Size = New System.Drawing.Size(38, 13)
      Me.lblEmisor.TabIndex = 8
      Me.lblEmisor.Text = "Emisor"
      '
      'txtEmisor
      '
      Me.txtEmisor.BindearPropiedadControl = Nothing
      Me.txtEmisor.BindearPropiedadEntidad = Nothing
      Me.txtEmisor.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
      Me.txtEmisor.ForeColorFocus = System.Drawing.Color.Red
      Me.txtEmisor.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtEmisor.Formato = ""
      Me.txtEmisor.IsDecimal = False
      Me.txtEmisor.IsNumber = True
      Me.txtEmisor.IsPK = False
      Me.txtEmisor.IsRequired = False
      Me.txtEmisor.Key = ""
      Me.txtEmisor.LabelAsoc = Me.lblEmisor
      Me.txtEmisor.Location = New System.Drawing.Point(235, 32)
      Me.txtEmisor.MaxLength = 8
      Me.txtEmisor.Name = "txtEmisor"
      Me.txtEmisor.ReadOnly = True
      Me.txtEmisor.Size = New System.Drawing.Size(42, 20)
      Me.txtEmisor.TabIndex = 9
      Me.txtEmisor.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
      '
      'txtTipoComprobante
      '
      Me.txtTipoComprobante.BindearPropiedadControl = Nothing
      Me.txtTipoComprobante.BindearPropiedadEntidad = Nothing
      Me.txtTipoComprobante.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
      Me.txtTipoComprobante.ForeColorFocus = System.Drawing.Color.Red
      Me.txtTipoComprobante.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtTipoComprobante.Formato = ""
      Me.txtTipoComprobante.IsDecimal = False
      Me.txtTipoComprobante.IsNumber = False
      Me.txtTipoComprobante.IsPK = False
      Me.txtTipoComprobante.IsRequired = False
      Me.txtTipoComprobante.Key = ""
      Me.txtTipoComprobante.LabelAsoc = Nothing
      Me.txtTipoComprobante.Location = New System.Drawing.Point(12, 32)
      Me.txtTipoComprobante.Name = "txtTipoComprobante"
      Me.txtTipoComprobante.ReadOnly = True
      Me.txtTipoComprobante.Size = New System.Drawing.Size(186, 20)
      Me.txtTipoComprobante.TabIndex = 5
      Me.txtTipoComprobante.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
      '
      'RenumerarPedidos
      '
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.CancelButton = Me.btnCancelar
      Me.ClientSize = New System.Drawing.Size(377, 105)
      Me.ControlBox = False
      Me.Controls.Add(Me.lblEmisor)
      Me.Controls.Add(Me.txtEmisor)
      Me.Controls.Add(Me.lblNumero)
      Me.Controls.Add(Me.txtTipoComprobante)
      Me.Controls.Add(Me.txtNumero)
      Me.Controls.Add(Me.lblLetra)
      Me.Controls.Add(Me.txtLetra)
      Me.Controls.Add(Me.lblTipoComprobante)
      Me.Controls.Add(Me.btnAceptar)
      Me.Controls.Add(Me.btnCancelar)
      Me.Name = "RenumerarPedidos"
      Me.ShowInTaskbar = False
      Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
      Me.Text = "Nuevo número de pedido"
      Me.ResumeLayout(False)
      Me.PerformLayout()

   End Sub
   Protected WithEvents btnAceptar As System.Windows.Forms.Button
   Private WithEvents imageList1 As System.Windows.Forms.ImageList
   Protected WithEvents btnCancelar As System.Windows.Forms.Button
   Friend WithEvents lblNumero As Eniac.Controles.Label
   Friend WithEvents txtNumero As Eniac.Controles.TextBox
   Friend WithEvents lblLetra As Eniac.Controles.Label
   Friend WithEvents txtLetra As Eniac.Controles.TextBox
   Friend WithEvents lblTipoComprobante As Eniac.Controles.Label
   Friend WithEvents lblEmisor As Eniac.Controles.Label
   Friend WithEvents txtEmisor As Eniac.Controles.TextBox
   Friend WithEvents txtTipoComprobante As Eniac.Controles.TextBox
End Class
