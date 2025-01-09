<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CRMCategoriasNovedadesDetalle
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
      Me.cmbTipoNovedad = New Eniac.Controles.ComboBox()
      Me.lblDescripcion = New Eniac.Controles.Label()
      Me.txtNombreCategoriaNovedad = New Eniac.Controles.TextBox()
      Me.Label1 = New Eniac.Controles.Label()
      Me.lblPosicion = New Eniac.Controles.Label()
      Me.lblCodigo = New Eniac.Controles.Label()
      Me.txtPosicion = New Eniac.Controles.TextBox()
      Me.txtIdCategoriaNovedad = New Eniac.Controles.TextBox()
      Me.chbPorDefecto = New Eniac.Controles.CheckBox()
      Me.cmbReporta = New Eniac.Controles.ComboBox()
      Me.lblReporta = New Eniac.Controles.Label()
      Me.txtColor = New Eniac.Controles.TextBox()
      Me.lblColorSemadoro = New Eniac.Controles.Label()
      Me.btnColor = New System.Windows.Forms.Button()
      Me.cdColor = New System.Windows.Forms.ColorDialog()
      Me.chbPublicarEnWeb = New Eniac.Controles.CheckBox()
      Me.cmbTipoCategoriaNovedad = New Eniac.Controles.ComboBox()
      Me.Label2 = New Eniac.Controles.Label()
      Me.SuspendLayout()
      '
      'btnAceptar
      '
      Me.btnAceptar.Location = New System.Drawing.Point(196, 226)
      Me.btnAceptar.TabIndex = 17
      '
      'btnCancelar
      '
      Me.btnCancelar.Location = New System.Drawing.Point(282, 226)
      Me.btnCancelar.TabIndex = 18
      '
      'btnCopiar
      '
      Me.btnCopiar.Location = New System.Drawing.Point(95, 226)
      Me.btnCopiar.TabIndex = 19
      '
      'btnAplicar
      '
      Me.btnAplicar.Location = New System.Drawing.Point(35, 226)
      Me.btnAplicar.TabIndex = 20
      '
      'cmbTipoNovedad
      '
      Me.cmbTipoNovedad.BindearPropiedadControl = "SelectedValue"
      Me.cmbTipoNovedad.BindearPropiedadEntidad = "TipoNovedad.IdTipoNovedad"
      Me.cmbTipoNovedad.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cmbTipoNovedad.ForeColorFocus = System.Drawing.Color.Red
      Me.cmbTipoNovedad.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.cmbTipoNovedad.FormattingEnabled = True
      Me.cmbTipoNovedad.IsPK = False
      Me.cmbTipoNovedad.IsRequired = False
      Me.cmbTipoNovedad.Key = Nothing
      Me.cmbTipoNovedad.LabelAsoc = Nothing
      Me.cmbTipoNovedad.Location = New System.Drawing.Point(86, 64)
      Me.cmbTipoNovedad.Name = "cmbTipoNovedad"
      Me.cmbTipoNovedad.Size = New System.Drawing.Size(244, 21)
      Me.cmbTipoNovedad.TabIndex = 5
      '
      'lblDescripcion
      '
      Me.lblDescripcion.AutoSize = True
      Me.lblDescripcion.LabelAsoc = Nothing
      Me.lblDescripcion.Location = New System.Drawing.Point(9, 42)
      Me.lblDescripcion.Name = "lblDescripcion"
      Me.lblDescripcion.Size = New System.Drawing.Size(63, 13)
      Me.lblDescripcion.TabIndex = 2
      Me.lblDescripcion.Text = "Descripción"
      '
      'txtNombreCategoriaNovedad
      '
      Me.txtNombreCategoriaNovedad.BindearPropiedadControl = "Text"
      Me.txtNombreCategoriaNovedad.BindearPropiedadEntidad = "NombreCategoriaNovedad"
      Me.txtNombreCategoriaNovedad.ForeColorFocus = System.Drawing.Color.Red
      Me.txtNombreCategoriaNovedad.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtNombreCategoriaNovedad.Formato = ""
      Me.txtNombreCategoriaNovedad.IsDecimal = False
      Me.txtNombreCategoriaNovedad.IsNumber = False
      Me.txtNombreCategoriaNovedad.IsPK = False
      Me.txtNombreCategoriaNovedad.IsRequired = True
      Me.txtNombreCategoriaNovedad.Key = ""
      Me.txtNombreCategoriaNovedad.LabelAsoc = Me.lblDescripcion
      Me.txtNombreCategoriaNovedad.Location = New System.Drawing.Point(86, 38)
      Me.txtNombreCategoriaNovedad.MaxLength = 20
      Me.txtNombreCategoriaNovedad.Name = "txtNombreCategoriaNovedad"
      Me.txtNombreCategoriaNovedad.Size = New System.Drawing.Size(244, 20)
      Me.txtNombreCategoriaNovedad.TabIndex = 3
      '
      'Label1
      '
      Me.Label1.AutoSize = True
      Me.Label1.LabelAsoc = Nothing
      Me.Label1.Location = New System.Drawing.Point(9, 67)
      Me.Label1.Name = "Label1"
      Me.Label1.Size = New System.Drawing.Size(75, 13)
      Me.Label1.TabIndex = 4
      Me.Label1.Text = "Tipo Novedad"
      '
      'lblPosicion
      '
      Me.lblPosicion.AutoSize = True
      Me.lblPosicion.LabelAsoc = Nothing
      Me.lblPosicion.Location = New System.Drawing.Point(9, 122)
      Me.lblPosicion.Name = "lblPosicion"
      Me.lblPosicion.Size = New System.Drawing.Size(47, 13)
      Me.lblPosicion.TabIndex = 8
      Me.lblPosicion.Text = "Posición"
      '
      'lblCodigo
      '
      Me.lblCodigo.AutoSize = True
      Me.lblCodigo.LabelAsoc = Nothing
      Me.lblCodigo.Location = New System.Drawing.Point(9, 16)
      Me.lblCodigo.Name = "lblCodigo"
      Me.lblCodigo.Size = New System.Drawing.Size(40, 13)
      Me.lblCodigo.TabIndex = 0
      Me.lblCodigo.Text = "Codigo"
      '
      'txtPosicion
      '
      Me.txtPosicion.BindearPropiedadControl = "Text"
      Me.txtPosicion.BindearPropiedadEntidad = "Posicion"
      Me.txtPosicion.ForeColorFocus = System.Drawing.Color.Red
      Me.txtPosicion.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtPosicion.Formato = ""
      Me.txtPosicion.IsDecimal = False
      Me.txtPosicion.IsNumber = True
      Me.txtPosicion.IsPK = False
      Me.txtPosicion.IsRequired = True
      Me.txtPosicion.Key = ""
      Me.txtPosicion.LabelAsoc = Me.lblPosicion
      Me.txtPosicion.Location = New System.Drawing.Point(86, 118)
      Me.txtPosicion.MaxLength = 4
      Me.txtPosicion.Name = "txtPosicion"
      Me.txtPosicion.Size = New System.Drawing.Size(54, 20)
      Me.txtPosicion.TabIndex = 9
      Me.txtPosicion.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'txtIdCategoriaNovedad
      '
      Me.txtIdCategoriaNovedad.BindearPropiedadControl = "Text"
      Me.txtIdCategoriaNovedad.BindearPropiedadEntidad = "IdCategoriaNovedad"
      Me.txtIdCategoriaNovedad.ForeColorFocus = System.Drawing.Color.Red
      Me.txtIdCategoriaNovedad.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtIdCategoriaNovedad.Formato = ""
      Me.txtIdCategoriaNovedad.IsDecimal = False
      Me.txtIdCategoriaNovedad.IsNumber = True
      Me.txtIdCategoriaNovedad.IsPK = True
      Me.txtIdCategoriaNovedad.IsRequired = True
      Me.txtIdCategoriaNovedad.Key = ""
      Me.txtIdCategoriaNovedad.LabelAsoc = Me.lblCodigo
      Me.txtIdCategoriaNovedad.Location = New System.Drawing.Point(86, 12)
      Me.txtIdCategoriaNovedad.MaxLength = 10
      Me.txtIdCategoriaNovedad.Name = "txtIdCategoriaNovedad"
      Me.txtIdCategoriaNovedad.Size = New System.Drawing.Size(54, 20)
      Me.txtIdCategoriaNovedad.TabIndex = 1
      Me.txtIdCategoriaNovedad.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'chbPorDefecto
      '
      Me.chbPorDefecto.AutoSize = True
      Me.chbPorDefecto.BindearPropiedadControl = "Checked"
      Me.chbPorDefecto.BindearPropiedadEntidad = "PorDefecto"
      Me.chbPorDefecto.ForeColorFocus = System.Drawing.Color.Red
      Me.chbPorDefecto.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
      Me.chbPorDefecto.IsPK = False
      Me.chbPorDefecto.IsRequired = False
      Me.chbPorDefecto.Key = Nothing
      Me.chbPorDefecto.LabelAsoc = Nothing
      Me.chbPorDefecto.Location = New System.Drawing.Point(86, 171)
      Me.chbPorDefecto.Name = "chbPorDefecto"
      Me.chbPorDefecto.Size = New System.Drawing.Size(83, 17)
      Me.chbPorDefecto.TabIndex = 15
      Me.chbPorDefecto.Text = "Por Defecto"
      Me.chbPorDefecto.UseVisualStyleBackColor = True
      '
      'cmbReporta
      '
      Me.cmbReporta.BindearPropiedadControl = "SelectedValue"
      Me.cmbReporta.BindearPropiedadEntidad = "Reporta"
      Me.cmbReporta.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cmbReporta.ForeColorFocus = System.Drawing.Color.Red
      Me.cmbReporta.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.cmbReporta.FormattingEnabled = True
      Me.cmbReporta.IsPK = False
      Me.cmbReporta.IsRequired = False
      Me.cmbReporta.Key = Nothing
      Me.cmbReporta.LabelAsoc = Nothing
      Me.cmbReporta.Location = New System.Drawing.Point(86, 144)
      Me.cmbReporta.Name = "cmbReporta"
      Me.cmbReporta.Size = New System.Drawing.Size(83, 21)
      Me.cmbReporta.TabIndex = 14
      '
      'lblReporta
      '
      Me.lblReporta.AutoSize = True
      Me.lblReporta.LabelAsoc = Nothing
      Me.lblReporta.Location = New System.Drawing.Point(32, 149)
      Me.lblReporta.Name = "lblReporta"
      Me.lblReporta.Size = New System.Drawing.Size(45, 13)
      Me.lblReporta.TabIndex = 13
      Me.lblReporta.Text = "Reporta"
      '
      'txtColor
      '
      Me.txtColor.BindearPropiedadControl = "Key"
      Me.txtColor.BindearPropiedadEntidad = "Color"
      Me.txtColor.ForeColorFocus = System.Drawing.Color.Red
      Me.txtColor.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtColor.Formato = ""
      Me.txtColor.IsDecimal = False
      Me.txtColor.IsNumber = False
      Me.txtColor.IsPK = False
      Me.txtColor.IsRequired = False
      Me.txtColor.Key = ""
      Me.txtColor.LabelAsoc = Me.lblColorSemadoro
      Me.txtColor.Location = New System.Drawing.Point(185, 119)
      Me.txtColor.Name = "txtColor"
      Me.txtColor.ReadOnly = True
      Me.txtColor.Size = New System.Drawing.Size(82, 20)
      Me.txtColor.TabIndex = 11
      Me.txtColor.TabStop = False
      '
      'lblColorSemadoro
      '
      Me.lblColorSemadoro.AutoSize = True
      Me.lblColorSemadoro.LabelAsoc = Nothing
      Me.lblColorSemadoro.Location = New System.Drawing.Point(148, 123)
      Me.lblColorSemadoro.Name = "lblColorSemadoro"
      Me.lblColorSemadoro.Size = New System.Drawing.Size(31, 13)
      Me.lblColorSemadoro.TabIndex = 10
      Me.lblColorSemadoro.Text = "Color"
      '
      'btnColor
      '
      Me.btnColor.Location = New System.Drawing.Point(273, 118)
      Me.btnColor.Name = "btnColor"
      Me.btnColor.Size = New System.Drawing.Size(57, 23)
      Me.btnColor.TabIndex = 12
      Me.btnColor.Text = "Paleta"
      Me.btnColor.UseVisualStyleBackColor = True
      '
      'chbPublicarEnWeb
      '
      Me.chbPublicarEnWeb.AutoSize = True
      Me.chbPublicarEnWeb.BindearPropiedadControl = "Checked"
      Me.chbPublicarEnWeb.BindearPropiedadEntidad = "PublicarEnWeb"
      Me.chbPublicarEnWeb.ForeColorFocus = System.Drawing.Color.Red
      Me.chbPublicarEnWeb.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
      Me.chbPublicarEnWeb.IsPK = False
      Me.chbPublicarEnWeb.IsRequired = False
      Me.chbPublicarEnWeb.Key = Nothing
      Me.chbPublicarEnWeb.LabelAsoc = Nothing
      Me.chbPublicarEnWeb.Location = New System.Drawing.Point(86, 194)
      Me.chbPublicarEnWeb.Name = "chbPublicarEnWeb"
      Me.chbPublicarEnWeb.Size = New System.Drawing.Size(106, 17)
      Me.chbPublicarEnWeb.TabIndex = 16
      Me.chbPublicarEnWeb.Text = "Publicar En Web"
      Me.chbPublicarEnWeb.UseVisualStyleBackColor = True
      '
      'cmbTipoCategoriaNovedad
      '
      Me.cmbTipoCategoriaNovedad.BindearPropiedadControl = ""
      Me.cmbTipoCategoriaNovedad.BindearPropiedadEntidad = ""
      Me.cmbTipoCategoriaNovedad.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cmbTipoCategoriaNovedad.ForeColorFocus = System.Drawing.Color.Red
      Me.cmbTipoCategoriaNovedad.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.cmbTipoCategoriaNovedad.FormattingEnabled = True
      Me.cmbTipoCategoriaNovedad.IsPK = False
      Me.cmbTipoCategoriaNovedad.IsRequired = False
      Me.cmbTipoCategoriaNovedad.Key = Nothing
      Me.cmbTipoCategoriaNovedad.LabelAsoc = Nothing
      Me.cmbTipoCategoriaNovedad.Location = New System.Drawing.Point(86, 91)
      Me.cmbTipoCategoriaNovedad.Name = "cmbTipoCategoriaNovedad"
      Me.cmbTipoCategoriaNovedad.Size = New System.Drawing.Size(244, 21)
      Me.cmbTipoCategoriaNovedad.TabIndex = 7
      '
      'Label2
      '
      Me.Label2.AutoSize = True
      Me.Label2.LabelAsoc = Nothing
      Me.Label2.Location = New System.Drawing.Point(9, 94)
      Me.Label2.Name = "Label2"
      Me.Label2.Size = New System.Drawing.Size(54, 13)
      Me.Label2.TabIndex = 6
      Me.Label2.Text = "Categoría"
      '
      'CRMCategoriasNovedadesDetalle
      '
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.ClientSize = New System.Drawing.Size(371, 261)
      Me.Controls.Add(Me.cmbTipoCategoriaNovedad)
      Me.Controls.Add(Me.Label2)
      Me.Controls.Add(Me.chbPublicarEnWeb)
      Me.Controls.Add(Me.txtColor)
      Me.Controls.Add(Me.lblColorSemadoro)
      Me.Controls.Add(Me.btnColor)
      Me.Controls.Add(Me.cmbReporta)
      Me.Controls.Add(Me.lblReporta)
      Me.Controls.Add(Me.chbPorDefecto)
      Me.Controls.Add(Me.cmbTipoNovedad)
      Me.Controls.Add(Me.lblDescripcion)
      Me.Controls.Add(Me.txtNombreCategoriaNovedad)
      Me.Controls.Add(Me.Label1)
      Me.Controls.Add(Me.lblPosicion)
      Me.Controls.Add(Me.lblCodigo)
      Me.Controls.Add(Me.txtPosicion)
      Me.Controls.Add(Me.txtIdCategoriaNovedad)
      Me.Name = "CRMCategoriasNovedadesDetalle"
      Me.Text = "Categoria Novedad"
      Me.Controls.SetChildIndex(Me.btnAplicar, 0)
      Me.Controls.SetChildIndex(Me.btnCopiar, 0)
      Me.Controls.SetChildIndex(Me.btnCancelar, 0)
      Me.Controls.SetChildIndex(Me.btnAceptar, 0)
      Me.Controls.SetChildIndex(Me.txtIdCategoriaNovedad, 0)
      Me.Controls.SetChildIndex(Me.txtPosicion, 0)
      Me.Controls.SetChildIndex(Me.lblCodigo, 0)
      Me.Controls.SetChildIndex(Me.lblPosicion, 0)
      Me.Controls.SetChildIndex(Me.Label1, 0)
      Me.Controls.SetChildIndex(Me.txtNombreCategoriaNovedad, 0)
      Me.Controls.SetChildIndex(Me.lblDescripcion, 0)
      Me.Controls.SetChildIndex(Me.cmbTipoNovedad, 0)
      Me.Controls.SetChildIndex(Me.chbPorDefecto, 0)
      Me.Controls.SetChildIndex(Me.lblReporta, 0)
      Me.Controls.SetChildIndex(Me.cmbReporta, 0)
      Me.Controls.SetChildIndex(Me.btnColor, 0)
      Me.Controls.SetChildIndex(Me.lblColorSemadoro, 0)
      Me.Controls.SetChildIndex(Me.txtColor, 0)
      Me.Controls.SetChildIndex(Me.chbPublicarEnWeb, 0)
      Me.Controls.SetChildIndex(Me.Label2, 0)
      Me.Controls.SetChildIndex(Me.cmbTipoCategoriaNovedad, 0)
      Me.ResumeLayout(False)
      Me.PerformLayout()

   End Sub
   Friend WithEvents cmbTipoNovedad As Eniac.Controles.ComboBox
   Friend WithEvents lblDescripcion As Eniac.Controles.Label
   Friend WithEvents txtNombreCategoriaNovedad As Eniac.Controles.TextBox
   Friend WithEvents Label1 As Eniac.Controles.Label
   Friend WithEvents lblPosicion As Eniac.Controles.Label
   Friend WithEvents lblCodigo As Eniac.Controles.Label
   Friend WithEvents txtPosicion As Eniac.Controles.TextBox
   Friend WithEvents txtIdCategoriaNovedad As Eniac.Controles.TextBox
   Friend WithEvents chbPorDefecto As Eniac.Controles.CheckBox
   Friend WithEvents cmb As Eniac.Controles.ComboBox
   Friend WithEvents lblReporta As Eniac.Controles.Label
   Friend WithEvents cmbReporta As Eniac.Controles.ComboBox
   Friend WithEvents txtColor As Eniac.Controles.TextBox
   Friend WithEvents lblColorSemadoro As Eniac.Controles.Label
   Friend WithEvents btnColor As System.Windows.Forms.Button
   Friend WithEvents cdColor As System.Windows.Forms.ColorDialog
   Friend WithEvents chbPublicarEnWeb As Eniac.Controles.CheckBox
   Friend WithEvents cmbTipoCategoriaNovedad As Eniac.Controles.ComboBox
   Friend WithEvents Label2 As Eniac.Controles.Label
End Class
