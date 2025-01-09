<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class CRMMotivosNovedadesDetalle
   Inherits BaseDetalle

   'Form overrides dispose to clean up the component list.
   <System.Diagnostics.DebuggerNonUserCode()>
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
   <System.Diagnostics.DebuggerStepThrough()>
   Private Sub InitializeComponent()
      Me.cmbTipoNovedad = New Eniac.Controles.ComboBox()
      Me.lblDescripcion = New Eniac.Controles.Label()
      Me.txtNombreCategoriaNovedad = New Eniac.Controles.TextBox()
      Me.Label1 = New Eniac.Controles.Label()
      Me.lblPosicion = New Eniac.Controles.Label()
      Me.lblCodigo = New Eniac.Controles.Label()
      Me.txtPosicion = New Eniac.Controles.TextBox()
      Me.txtIdCategoriaNovedad = New Eniac.Controles.TextBox()
      Me.cdColor = New System.Windows.Forms.ColorDialog()
      Me.SuspendLayout()
      '
      'btnAceptar
      '
      Me.btnAceptar.Location = New System.Drawing.Point(196, 126)
      Me.btnAceptar.TabIndex = 8
      '
      'btnCancelar
      '
      Me.btnCancelar.Location = New System.Drawing.Point(282, 126)
      Me.btnCancelar.TabIndex = 9
      '
      'btnCopiar
      '
      Me.btnCopiar.Location = New System.Drawing.Point(95, 126)
      Me.btnCopiar.TabIndex = 11
      '
      'btnAplicar
      '
      Me.btnAplicar.Location = New System.Drawing.Point(35, 126)
      Me.btnAplicar.TabIndex = 10
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
      Me.txtNombreCategoriaNovedad.BindearPropiedadEntidad = "NombreMotivoNovedad"
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
      Me.lblPosicion.Location = New System.Drawing.Point(9, 95)
      Me.lblPosicion.Name = "lblPosicion"
      Me.lblPosicion.Size = New System.Drawing.Size(47, 13)
      Me.lblPosicion.TabIndex = 6
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
      Me.txtPosicion.Location = New System.Drawing.Point(86, 91)
      Me.txtPosicion.MaxLength = 4
      Me.txtPosicion.Name = "txtPosicion"
      Me.txtPosicion.Size = New System.Drawing.Size(54, 20)
      Me.txtPosicion.TabIndex = 7
      Me.txtPosicion.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'txtIdCategoriaNovedad
      '
      Me.txtIdCategoriaNovedad.BindearPropiedadControl = "Text"
      Me.txtIdCategoriaNovedad.BindearPropiedadEntidad = "IdMotivoNovedad"
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
      'CRMMotivosNovedadesDetalle
      '
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.ClientSize = New System.Drawing.Size(371, 161)
      Me.Controls.Add(Me.cmbTipoNovedad)
      Me.Controls.Add(Me.lblDescripcion)
      Me.Controls.Add(Me.txtNombreCategoriaNovedad)
      Me.Controls.Add(Me.Label1)
      Me.Controls.Add(Me.lblPosicion)
      Me.Controls.Add(Me.lblCodigo)
      Me.Controls.Add(Me.txtPosicion)
      Me.Controls.Add(Me.txtIdCategoriaNovedad)
      Me.Name = "CRMMotivosNovedadesDetalle"
      Me.Text = "Motivo Novedad"
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
   Friend WithEvents cmb As Eniac.Controles.ComboBox
   Friend WithEvents cdColor As System.Windows.Forms.ColorDialog
End Class
