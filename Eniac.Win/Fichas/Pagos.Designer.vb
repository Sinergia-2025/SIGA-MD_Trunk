<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Pagos
   Inherits Eniac.Win.BaseForm

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
      Me.components = New System.ComponentModel.Container
      Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Pagos))
      Me.imgGrabar = New System.Windows.Forms.ImageList(Me.components)
      Me.cmbCobrador = New Eniac.Controles.ComboBox
      Me.lblCobrador = New Eniac.Controles.Label
      Me.dtpFecha = New Eniac.Controles.DateTimePicker
      Me.lblFecha = New Eniac.Controles.Label
      Me.lblImporte = New Eniac.Controles.Label
      Me.txtImporte = New Eniac.Controles.TextBox
      Me.btnGrabar = New Eniac.Controles.Button
      Me.btnCancelar = New Eniac.Controles.Button
      Me.lblInteres = New Eniac.Controles.Label
      Me.txtInteres = New Eniac.Controles.TextBox
      Me.lblConcepto = New Eniac.Controles.Label
      Me.txtConcepto = New Eniac.Controles.TextBox
      Me.grbCajas = New System.Windows.Forms.GroupBox
      Me.lblCaja = New Eniac.Controles.Label
      Me.txtCaja = New Eniac.Controles.MaskedTextBox
      Me.grbCajas.SuspendLayout()
      Me.SuspendLayout()
      '
      'imgGrabar
      '
      Me.imgGrabar.ImageStream = CType(resources.GetObject("imgGrabar.ImageStream"), System.Windows.Forms.ImageListStreamer)
      Me.imgGrabar.TransparentColor = System.Drawing.Color.Transparent
      Me.imgGrabar.Images.SetKeyName(0, "check2.ico")
      Me.imgGrabar.Images.SetKeyName(1, "delete2.ico")
      '
      'cmbCobrador
      '
      Me.cmbCobrador.BindearPropiedadControl = Nothing
      Me.cmbCobrador.BindearPropiedadEntidad = Nothing
      Me.cmbCobrador.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cmbCobrador.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.cmbCobrador.ForeColorFocus = System.Drawing.Color.Red
      Me.cmbCobrador.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.cmbCobrador.FormattingEnabled = True
      Me.cmbCobrador.IsPK = False
      Me.cmbCobrador.IsRequired = False
      Me.cmbCobrador.Key = Nothing
      Me.cmbCobrador.LabelAsoc = Me.lblCobrador
      Me.cmbCobrador.Location = New System.Drawing.Point(73, 124)
      Me.cmbCobrador.Name = "cmbCobrador"
      Me.cmbCobrador.Size = New System.Drawing.Size(181, 21)
      Me.cmbCobrador.TabIndex = 4
      '
      'lblCobrador
      '
      Me.lblCobrador.AutoSize = True
      Me.lblCobrador.Location = New System.Drawing.Point(17, 127)
      Me.lblCobrador.Name = "lblCobrador"
      Me.lblCobrador.Size = New System.Drawing.Size(50, 13)
      Me.lblCobrador.TabIndex = 11
      Me.lblCobrador.Text = "Cobrador"
      '
      'dtpFecha
      '
      Me.dtpFecha.BindearPropiedadControl = Nothing
      Me.dtpFecha.BindearPropiedadEntidad = Nothing
      Me.dtpFecha.CustomFormat = "dd/MM/yyyy"
      Me.dtpFecha.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.dtpFecha.ForeColorFocus = System.Drawing.Color.Red
      Me.dtpFecha.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.dtpFecha.Format = System.Windows.Forms.DateTimePickerFormat.Custom
      Me.dtpFecha.IsPK = False
      Me.dtpFecha.IsRequired = False
      Me.dtpFecha.Key = ""
      Me.dtpFecha.LabelAsoc = Me.lblFecha
      Me.dtpFecha.Location = New System.Drawing.Point(16, 90)
      Me.dtpFecha.Name = "dtpFecha"
      Me.dtpFecha.Size = New System.Drawing.Size(96, 20)
      Me.dtpFecha.TabIndex = 0
      '
      'lblFecha
      '
      Me.lblFecha.AutoSize = True
      Me.lblFecha.Location = New System.Drawing.Point(13, 74)
      Me.lblFecha.Name = "lblFecha"
      Me.lblFecha.Size = New System.Drawing.Size(37, 13)
      Me.lblFecha.TabIndex = 7
      Me.lblFecha.Text = "Fecha"
      '
      'lblImporte
      '
      Me.lblImporte.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.lblImporte.AutoSize = True
      Me.lblImporte.Location = New System.Drawing.Point(112, 74)
      Me.lblImporte.Name = "lblImporte"
      Me.lblImporte.Size = New System.Drawing.Size(42, 13)
      Me.lblImporte.TabIndex = 8
      Me.lblImporte.Text = "Importe"
      '
      'txtImporte
      '
      Me.txtImporte.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.txtImporte.BindearPropiedadControl = Nothing
      Me.txtImporte.BindearPropiedadEntidad = Nothing
      Me.txtImporte.ForeColorFocus = System.Drawing.Color.Red
      Me.txtImporte.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtImporte.Formato = ""
      Me.txtImporte.IsDecimal = True
      Me.txtImporte.IsNumber = True
      Me.txtImporte.IsPK = False
      Me.txtImporte.IsRequired = False
      Me.txtImporte.Key = ""
      Me.txtImporte.LabelAsoc = Me.lblImporte
      Me.txtImporte.Location = New System.Drawing.Point(115, 90)
      Me.txtImporte.Name = "txtImporte"
      Me.txtImporte.Size = New System.Drawing.Size(67, 20)
      Me.txtImporte.TabIndex = 1
      Me.txtImporte.Text = "0.00"
      Me.txtImporte.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'btnGrabar
      '
      Me.btnGrabar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.btnGrabar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
      Me.btnGrabar.ImageKey = "check2.ico"
      Me.btnGrabar.ImageList = Me.imgGrabar
      Me.btnGrabar.Location = New System.Drawing.Point(216, 154)
      Me.btnGrabar.Name = "btnGrabar"
      Me.btnGrabar.Size = New System.Drawing.Size(85, 30)
      Me.btnGrabar.TabIndex = 5
      Me.btnGrabar.Text = "Grabar"
      Me.btnGrabar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      Me.btnGrabar.UseVisualStyleBackColor = True
      '
      'btnCancelar
      '
      Me.btnCancelar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel
      Me.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
      Me.btnCancelar.ImageKey = "delete2.ico"
      Me.btnCancelar.ImageList = Me.imgGrabar
      Me.btnCancelar.Location = New System.Drawing.Point(307, 154)
      Me.btnCancelar.Name = "btnCancelar"
      Me.btnCancelar.Size = New System.Drawing.Size(85, 30)
      Me.btnCancelar.TabIndex = 6
      Me.btnCancelar.Text = "Cancelar"
      Me.btnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      Me.btnCancelar.UseVisualStyleBackColor = True
      '
      'lblInteres
      '
      Me.lblInteres.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.lblInteres.AutoSize = True
      Me.lblInteres.Location = New System.Drawing.Point(186, 74)
      Me.lblInteres.Name = "lblInteres"
      Me.lblInteres.Size = New System.Drawing.Size(39, 13)
      Me.lblInteres.TabIndex = 9
      Me.lblInteres.Text = "Interes"
      '
      'txtInteres
      '
      Me.txtInteres.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.txtInteres.BindearPropiedadControl = Nothing
      Me.txtInteres.BindearPropiedadEntidad = Nothing
      Me.txtInteres.ForeColorFocus = System.Drawing.Color.Red
      Me.txtInteres.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtInteres.Formato = ""
      Me.txtInteres.IsDecimal = True
      Me.txtInteres.IsNumber = True
      Me.txtInteres.IsPK = False
      Me.txtInteres.IsRequired = False
      Me.txtInteres.Key = ""
      Me.txtInteres.LabelAsoc = Me.lblInteres
      Me.txtInteres.Location = New System.Drawing.Point(189, 90)
      Me.txtInteres.Name = "txtInteres"
      Me.txtInteres.Size = New System.Drawing.Size(67, 20)
      Me.txtInteres.TabIndex = 2
      Me.txtInteres.Text = "0.00"
      Me.txtInteres.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'lblConcepto
      '
      Me.lblConcepto.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.lblConcepto.AutoSize = True
      Me.lblConcepto.Location = New System.Drawing.Point(265, 10)
      Me.lblConcepto.Name = "lblConcepto"
      Me.lblConcepto.Size = New System.Drawing.Size(53, 13)
      Me.lblConcepto.TabIndex = 10
      Me.lblConcepto.Text = "Concepto"
      '
      'txtConcepto
      '
      Me.txtConcepto.BindearPropiedadControl = Nothing
      Me.txtConcepto.BindearPropiedadEntidad = Nothing
      Me.txtConcepto.ForeColorFocus = System.Drawing.Color.Red
      Me.txtConcepto.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtConcepto.Formato = ""
      Me.txtConcepto.IsDecimal = False
      Me.txtConcepto.IsNumber = False
      Me.txtConcepto.IsPK = False
      Me.txtConcepto.IsRequired = False
      Me.txtConcepto.Key = ""
      Me.txtConcepto.LabelAsoc = Me.lblConcepto
      Me.txtConcepto.Location = New System.Drawing.Point(268, 26)
      Me.txtConcepto.Multiline = True
      Me.txtConcepto.Name = "txtConcepto"
      Me.txtConcepto.ReadOnly = True
      Me.txtConcepto.Size = New System.Drawing.Size(124, 122)
      Me.txtConcepto.TabIndex = 3
      '
      'grbCajas
      '
      Me.grbCajas.Controls.Add(Me.txtCaja)
      Me.grbCajas.Controls.Add(Me.lblCaja)
      Me.grbCajas.Location = New System.Drawing.Point(15, 19)
      Me.grbCajas.Name = "grbCajas"
      Me.grbCajas.Size = New System.Drawing.Size(244, 45)
      Me.grbCajas.TabIndex = 17
      Me.grbCajas.TabStop = False
      '
      'lblCaja
      '
      Me.lblCaja.AutoSize = True
      Me.lblCaja.Location = New System.Drawing.Point(11, 20)
      Me.lblCaja.Name = "lblCaja"
      Me.lblCaja.Size = New System.Drawing.Size(28, 13)
      Me.lblCaja.TabIndex = 16
      Me.lblCaja.Text = "Caja"
      '
      'txtCaja
      '
      Me.txtCaja.BindearPropiedadControl = Nothing
      Me.txtCaja.BindearPropiedadEntidad = Nothing
      Me.txtCaja.ForeColorFocus = System.Drawing.Color.Red
      Me.txtCaja.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtCaja.IsDecimal = False
      Me.txtCaja.IsNumber = True
      Me.txtCaja.IsPK = False
      Me.txtCaja.IsRequired = False
      Me.txtCaja.Key = ""
      Me.txtCaja.LabelAsoc = Me.lblCaja
      Me.txtCaja.Location = New System.Drawing.Point(50, 16)
      Me.txtCaja.Name = "txtCaja"
      Me.txtCaja.ReadOnly = True
      Me.txtCaja.Size = New System.Drawing.Size(155, 20)
      Me.txtCaja.TabIndex = 17
      '
      'Pagos
      '
      Me.AcceptButton = Me.btnGrabar
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.CancelButton = Me.btnCancelar
      Me.ClientSize = New System.Drawing.Size(415, 196)
      Me.Controls.Add(Me.grbCajas)
      Me.Controls.Add(Me.txtConcepto)
      Me.Controls.Add(Me.lblConcepto)
      Me.Controls.Add(Me.lblInteres)
      Me.Controls.Add(Me.txtInteres)
      Me.Controls.Add(Me.cmbCobrador)
      Me.Controls.Add(Me.dtpFecha)
      Me.Controls.Add(Me.lblFecha)
      Me.Controls.Add(Me.lblImporte)
      Me.Controls.Add(Me.txtImporte)
      Me.Controls.Add(Me.lblCobrador)
      Me.Controls.Add(Me.btnGrabar)
      Me.Controls.Add(Me.btnCancelar)
      Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
      Me.MaximizeBox = False
      Me.MinimizeBox = False
      Me.Name = "Pagos"
      Me.ShowInTaskbar = False
      Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
      Me.Text = "Pagos"
      Me.grbCajas.ResumeLayout(False)
      Me.grbCajas.PerformLayout()
      Me.ResumeLayout(False)
      Me.PerformLayout()

   End Sub
   Friend WithEvents btnGrabar As Eniac.Controles.Button
   Friend WithEvents imgGrabar As System.Windows.Forms.ImageList
   Friend WithEvents btnCancelar As Eniac.Controles.Button
   Friend WithEvents lblImporte As Eniac.Controles.Label
   Friend WithEvents txtImporte As Eniac.Controles.TextBox
   Friend WithEvents lblCobrador As Eniac.Controles.Label
   Friend WithEvents dtpFecha As Eniac.Controles.DateTimePicker
   Friend WithEvents lblFecha As Eniac.Controles.Label
   Friend WithEvents cmbCobrador As Eniac.Controles.ComboBox
   Friend WithEvents lblInteres As Eniac.Controles.Label
   Friend WithEvents txtInteres As Eniac.Controles.TextBox
   Friend WithEvents lblConcepto As Eniac.Controles.Label
   Friend WithEvents txtConcepto As Eniac.Controles.TextBox
   Friend WithEvents grbCajas As System.Windows.Forms.GroupBox
   Friend WithEvents lblCaja As Eniac.Controles.Label
   Friend WithEvents txtCaja As Eniac.Controles.MaskedTextBox
End Class
