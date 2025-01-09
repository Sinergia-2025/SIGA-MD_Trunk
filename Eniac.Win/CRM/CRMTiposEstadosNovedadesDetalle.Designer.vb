<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CRMTiposEstadosNovedadesDetalle
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
      Me.lblDescripcion = New Eniac.Controles.Label()
      Me.txtNombreTipoEstadoNovedad = New Eniac.Controles.TextBox()
      Me.lblCodigo = New Eniac.Controles.Label()
      Me.txtIdTipoEstadoNovedad = New Eniac.Controles.TextBox()
      Me.txtPosicion = New Eniac.Controles.TextBox()
      Me.lblPosicion = New Eniac.Controles.Label()
      Me.cmbTipoNovedad = New Eniac.Controles.ComboBox()
      Me.Label1 = New Eniac.Controles.Label()
      Me.SuspendLayout()
      '
      'btnAceptar
      '
      Me.btnAceptar.Location = New System.Drawing.Point(195, 159)
      Me.btnAceptar.Margin = New System.Windows.Forms.Padding(5)
      Me.btnAceptar.TabIndex = 9
      '
      'btnCancelar
      '
      Me.btnCancelar.Location = New System.Drawing.Point(309, 159)
      Me.btnCancelar.Margin = New System.Windows.Forms.Padding(5)
      Me.btnCancelar.TabIndex = 10
      '
      'btnCopiar
      '
      Me.btnCopiar.Location = New System.Drawing.Point(60, 159)
      Me.btnCopiar.Margin = New System.Windows.Forms.Padding(5)
      Me.btnCopiar.TabIndex = 11
      '
      'btnAplicar
      '
      Me.btnAplicar.Location = New System.Drawing.Point(71, 223)
      '
      'lblDescripcion
      '
      Me.lblDescripcion.AutoSize = True
      Me.lblDescripcion.LabelAsoc = Nothing
      Me.lblDescripcion.Location = New System.Drawing.Point(12, 52)
      Me.lblDescripcion.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
      Me.lblDescripcion.Name = "lblDescripcion"
      Me.lblDescripcion.Size = New System.Drawing.Size(82, 17)
      Me.lblDescripcion.TabIndex = 2
      Me.lblDescripcion.Text = "Descripción"
      '
      'txtNombreTipoEstadoNovedad
      '
      Me.txtNombreTipoEstadoNovedad.BindearPropiedadControl = "Text"
      Me.txtNombreTipoEstadoNovedad.BindearPropiedadEntidad = "NombreTipoEstadoNovedad"
      Me.txtNombreTipoEstadoNovedad.ForeColorFocus = System.Drawing.Color.Red
      Me.txtNombreTipoEstadoNovedad.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtNombreTipoEstadoNovedad.Formato = ""
      Me.txtNombreTipoEstadoNovedad.IsDecimal = False
      Me.txtNombreTipoEstadoNovedad.IsNumber = False
      Me.txtNombreTipoEstadoNovedad.IsPK = False
      Me.txtNombreTipoEstadoNovedad.IsRequired = True
      Me.txtNombreTipoEstadoNovedad.Key = ""
      Me.txtNombreTipoEstadoNovedad.LabelAsoc = Me.lblDescripcion
      Me.txtNombreTipoEstadoNovedad.Location = New System.Drawing.Point(115, 47)
      Me.txtNombreTipoEstadoNovedad.Margin = New System.Windows.Forms.Padding(4)
      Me.txtNombreTipoEstadoNovedad.MaxLength = 20
      Me.txtNombreTipoEstadoNovedad.Name = "txtNombreTipoEstadoNovedad"
      Me.txtNombreTipoEstadoNovedad.Size = New System.Drawing.Size(300, 22)
      Me.txtNombreTipoEstadoNovedad.TabIndex = 3
      '
      'lblCodigo
      '
      Me.lblCodigo.AutoSize = True
      Me.lblCodigo.LabelAsoc = Nothing
      Me.lblCodigo.Location = New System.Drawing.Point(12, 20)
      Me.lblCodigo.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
      Me.lblCodigo.Name = "lblCodigo"
      Me.lblCodigo.Size = New System.Drawing.Size(52, 17)
      Me.lblCodigo.TabIndex = 0
      Me.lblCodigo.Text = "Codigo"
      '
      'txtIdTipoEstadoNovedad
      '
      Me.txtIdTipoEstadoNovedad.BindearPropiedadControl = "Text"
      Me.txtIdTipoEstadoNovedad.BindearPropiedadEntidad = "IdTipoEstadoNovedad"
      Me.txtIdTipoEstadoNovedad.ForeColorFocus = System.Drawing.Color.Red
      Me.txtIdTipoEstadoNovedad.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtIdTipoEstadoNovedad.Formato = ""
      Me.txtIdTipoEstadoNovedad.IsDecimal = False
      Me.txtIdTipoEstadoNovedad.IsNumber = True
      Me.txtIdTipoEstadoNovedad.IsPK = True
      Me.txtIdTipoEstadoNovedad.IsRequired = True
      Me.txtIdTipoEstadoNovedad.Key = ""
      Me.txtIdTipoEstadoNovedad.LabelAsoc = Me.lblCodigo
      Me.txtIdTipoEstadoNovedad.Location = New System.Drawing.Point(115, 15)
      Me.txtIdTipoEstadoNovedad.Margin = New System.Windows.Forms.Padding(4)
      Me.txtIdTipoEstadoNovedad.Name = "txtIdTipoEstadoNovedad"
      Me.txtIdTipoEstadoNovedad.Size = New System.Drawing.Size(71, 22)
      Me.txtIdTipoEstadoNovedad.TabIndex = 1
      Me.txtIdTipoEstadoNovedad.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
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
      Me.txtPosicion.Location = New System.Drawing.Point(115, 112)
      Me.txtPosicion.Margin = New System.Windows.Forms.Padding(4)
      Me.txtPosicion.MaxLength = 4
      Me.txtPosicion.Name = "txtPosicion"
      Me.txtPosicion.Size = New System.Drawing.Size(71, 22)
      Me.txtPosicion.TabIndex = 7
      Me.txtPosicion.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'lblPosicion
      '
      Me.lblPosicion.AutoSize = True
      Me.lblPosicion.LabelAsoc = Nothing
      Me.lblPosicion.Location = New System.Drawing.Point(12, 117)
      Me.lblPosicion.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
      Me.lblPosicion.Name = "lblPosicion"
      Me.lblPosicion.Size = New System.Drawing.Size(61, 17)
      Me.lblPosicion.TabIndex = 6
      Me.lblPosicion.Text = "Posición"
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
      Me.cmbTipoNovedad.Location = New System.Drawing.Point(115, 79)
      Me.cmbTipoNovedad.Margin = New System.Windows.Forms.Padding(4)
      Me.cmbTipoNovedad.Name = "cmbTipoNovedad"
      Me.cmbTipoNovedad.Size = New System.Drawing.Size(300, 24)
      Me.cmbTipoNovedad.TabIndex = 5
      '
      'Label1
      '
      Me.Label1.AutoSize = True
      Me.Label1.LabelAsoc = Nothing
      Me.Label1.Location = New System.Drawing.Point(12, 82)
      Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
      Me.Label1.Name = "Label1"
      Me.Label1.Size = New System.Drawing.Size(97, 17)
      Me.Label1.TabIndex = 4
      Me.Label1.Text = "Tipo Novedad"
      '
      'CRMTiposEstadosNovedadesDetalle
      '
      Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.ClientSize = New System.Drawing.Size(428, 202)
      Me.Controls.Add(Me.cmbTipoNovedad)
      Me.Controls.Add(Me.lblDescripcion)
      Me.Controls.Add(Me.txtNombreTipoEstadoNovedad)
      Me.Controls.Add(Me.Label1)
      Me.Controls.Add(Me.lblPosicion)
      Me.Controls.Add(Me.lblCodigo)
      Me.Controls.Add(Me.txtPosicion)
      Me.Controls.Add(Me.txtIdTipoEstadoNovedad)
      Me.Margin = New System.Windows.Forms.Padding(5)
      Me.Name = "CRMTiposEstadosNovedadesDetalle"
      Me.Text = "Tipo Estado Novedad"
      Me.Controls.SetChildIndex(Me.btnAplicar, 0)
      Me.Controls.SetChildIndex(Me.btnCopiar, 0)
      Me.Controls.SetChildIndex(Me.btnCancelar, 0)
      Me.Controls.SetChildIndex(Me.btnAceptar, 0)
      Me.Controls.SetChildIndex(Me.txtIdTipoEstadoNovedad, 0)
      Me.Controls.SetChildIndex(Me.txtPosicion, 0)
      Me.Controls.SetChildIndex(Me.lblCodigo, 0)
      Me.Controls.SetChildIndex(Me.lblPosicion, 0)
      Me.Controls.SetChildIndex(Me.Label1, 0)
      Me.Controls.SetChildIndex(Me.txtNombreTipoEstadoNovedad, 0)
      Me.Controls.SetChildIndex(Me.lblDescripcion, 0)
      Me.Controls.SetChildIndex(Me.cmbTipoNovedad, 0)
      Me.ResumeLayout(False)
      Me.PerformLayout()

   End Sub
   Friend WithEvents lblDescripcion As Eniac.Controles.Label
   Friend WithEvents txtNombreTipoEstadoNovedad As Eniac.Controles.TextBox
   Friend WithEvents lblCodigo As Eniac.Controles.Label
   Friend WithEvents txtIdTipoEstadoNovedad As Eniac.Controles.TextBox
   Friend WithEvents txtPosicion As Eniac.Controles.TextBox
   Friend WithEvents lblPosicion As Eniac.Controles.Label
   Friend WithEvents cmbTipoNovedad As Eniac.Controles.ComboBox
   Friend WithEvents Label1 As Eniac.Controles.Label
End Class
