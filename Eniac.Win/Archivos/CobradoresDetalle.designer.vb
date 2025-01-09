<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CobradoresDetalle
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
      Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(CobradoresDetalle))
      Me.txtIdCobrador = New Eniac.Controles.TextBox()
      Me.lblIdCobrador = New Eniac.Controles.Label()
      Me.lblNombreCobrador = New Eniac.Controles.Label()
      Me.txtNombreCobrador = New Eniac.Controles.TextBox()
      Me.chbDebitoDirecto = New Eniac.Controles.CheckBox()
      Me.cmbBanco = New Eniac.Controles.ComboBox()
      Me.lblBanco = New Eniac.Controles.Label()
      Me.txtIdDispositivo = New Eniac.Controles.TextBox()
      Me.lblIdDispositivo = New Eniac.Controles.Label()
      Me.chbCaja = New Eniac.Controles.CheckBox()
      Me.cmbCaja = New Eniac.Controles.ComboBox()
      Me.lblCaja = New Eniac.Controles.Label()
      Me.lblObservacion = New Eniac.Controles.Label()
      Me.txtObservacion = New Eniac.Controles.TextBox()
      Me.SuspendLayout()
      '
      'btnAceptar
      '
      Me.btnAceptar.Location = New System.Drawing.Point(225, 185)
      Me.btnAceptar.TabIndex = 14
      '
      'btnCancelar
      '
      Me.btnCancelar.Location = New System.Drawing.Point(311, 185)
      Me.btnCancelar.TabIndex = 15
      '
      'btnCopiar
      '
      Me.btnCopiar.Location = New System.Drawing.Point(124, 185)
      Me.btnCopiar.TabIndex = 17
      '
      'btnAplicar
      '
      Me.btnAplicar.Location = New System.Drawing.Point(64, 185)
      Me.btnAplicar.TabIndex = 16
      '
      'txtIdCobrador
      '
      Me.txtIdCobrador.BindearPropiedadControl = "Text"
      Me.txtIdCobrador.BindearPropiedadEntidad = "IdCobrador"
      Me.txtIdCobrador.ForeColorFocus = System.Drawing.Color.Red
      Me.txtIdCobrador.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtIdCobrador.Formato = ""
      Me.txtIdCobrador.IsDecimal = False
      Me.txtIdCobrador.IsNumber = False
      Me.txtIdCobrador.IsPK = True
      Me.txtIdCobrador.IsRequired = True
      Me.txtIdCobrador.Key = ""
      Me.txtIdCobrador.LabelAsoc = Me.lblIdCobrador
      Me.txtIdCobrador.Location = New System.Drawing.Point(94, 17)
      Me.txtIdCobrador.MaxLength = 4
      Me.txtIdCobrador.Name = "txtIdCobrador"
      Me.txtIdCobrador.Size = New System.Drawing.Size(62, 20)
      Me.txtIdCobrador.TabIndex = 1
      Me.txtIdCobrador.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'lblIdCobrador
      '
      Me.lblIdCobrador.AutoSize = True
      Me.lblIdCobrador.Location = New System.Drawing.Point(14, 20)
      Me.lblIdCobrador.Name = "lblIdCobrador"
      Me.lblIdCobrador.Size = New System.Drawing.Size(40, 13)
      Me.lblIdCobrador.TabIndex = 0
      Me.lblIdCobrador.Text = "Codigo"
      '
      'lblNombreCobrador
      '
      Me.lblNombreCobrador.AutoSize = True
      Me.lblNombreCobrador.Location = New System.Drawing.Point(14, 48)
      Me.lblNombreCobrador.Name = "lblNombreCobrador"
      Me.lblNombreCobrador.Size = New System.Drawing.Size(44, 13)
      Me.lblNombreCobrador.TabIndex = 2
      Me.lblNombreCobrador.Text = "Nombre"
      '
      'txtNombreCobrador
      '
      Me.txtNombreCobrador.BindearPropiedadControl = "Text"
      Me.txtNombreCobrador.BindearPropiedadEntidad = "NombreCobrador"
      Me.txtNombreCobrador.ForeColorFocus = System.Drawing.Color.Red
      Me.txtNombreCobrador.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtNombreCobrador.Formato = ""
      Me.txtNombreCobrador.IsDecimal = False
      Me.txtNombreCobrador.IsNumber = False
      Me.txtNombreCobrador.IsPK = False
      Me.txtNombreCobrador.IsRequired = True
      Me.txtNombreCobrador.Key = ""
      Me.txtNombreCobrador.LabelAsoc = Me.lblNombreCobrador
      Me.txtNombreCobrador.Location = New System.Drawing.Point(94, 45)
      Me.txtNombreCobrador.MaxLength = 50
      Me.txtNombreCobrador.Name = "txtNombreCobrador"
      Me.txtNombreCobrador.Size = New System.Drawing.Size(297, 20)
      Me.txtNombreCobrador.TabIndex = 3
      '
      'chbDebitoDirecto
      '
      Me.chbDebitoDirecto.AutoSize = True
      Me.chbDebitoDirecto.BindearPropiedadControl = "Checked"
      Me.chbDebitoDirecto.BindearPropiedadEntidad = "DebitoDirecto"
      Me.chbDebitoDirecto.ForeColorFocus = System.Drawing.Color.Red
      Me.chbDebitoDirecto.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
      Me.chbDebitoDirecto.IsPK = False
      Me.chbDebitoDirecto.IsRequired = False
      Me.chbDebitoDirecto.Key = Nothing
      Me.chbDebitoDirecto.LabelAsoc = Nothing
      Me.chbDebitoDirecto.Location = New System.Drawing.Point(14, 75)
      Me.chbDebitoDirecto.Name = "chbDebitoDirecto"
      Me.chbDebitoDirecto.Size = New System.Drawing.Size(94, 17)
      Me.chbDebitoDirecto.TabIndex = 4
      Me.chbDebitoDirecto.Text = "Débito Directo"
      Me.chbDebitoDirecto.UseVisualStyleBackColor = True
      '
      'cmbBanco
      '
      Me.cmbBanco.BindearPropiedadControl = "SelectedValue"
      Me.cmbBanco.BindearPropiedadEntidad = "idBanco"
      Me.cmbBanco.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cmbBanco.Enabled = False
      Me.cmbBanco.ForeColorFocus = System.Drawing.Color.Red
      Me.cmbBanco.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.cmbBanco.FormattingEnabled = True
      Me.cmbBanco.IsPK = False
      Me.cmbBanco.IsRequired = False
      Me.cmbBanco.Key = Nothing
      Me.cmbBanco.LabelAsoc = Me.lblBanco
      Me.cmbBanco.Location = New System.Drawing.Point(166, 71)
      Me.cmbBanco.Name = "cmbBanco"
      Me.cmbBanco.Size = New System.Drawing.Size(225, 21)
      Me.cmbBanco.TabIndex = 6
      '
      'lblBanco
      '
      Me.lblBanco.AutoSize = True
      Me.lblBanco.Location = New System.Drawing.Point(124, 76)
      Me.lblBanco.Name = "lblBanco"
      Me.lblBanco.Size = New System.Drawing.Size(38, 13)
      Me.lblBanco.TabIndex = 5
      Me.lblBanco.Text = "Banco"
      '
      'txtIdDispositivo
      '
      Me.txtIdDispositivo.BindearPropiedadControl = "Text"
      Me.txtIdDispositivo.BindearPropiedadEntidad = "IdDispositivo"
      Me.txtIdDispositivo.ForeColorFocus = System.Drawing.Color.Red
      Me.txtIdDispositivo.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtIdDispositivo.Formato = ""
      Me.txtIdDispositivo.IsDecimal = False
      Me.txtIdDispositivo.IsNumber = False
      Me.txtIdDispositivo.IsPK = False
      Me.txtIdDispositivo.IsRequired = False
      Me.txtIdDispositivo.Key = ""
      Me.txtIdDispositivo.LabelAsoc = Me.lblIdDispositivo
      Me.txtIdDispositivo.Location = New System.Drawing.Point(94, 99)
      Me.txtIdDispositivo.MaxLength = 50
      Me.txtIdDispositivo.Name = "txtIdDispositivo"
      Me.txtIdDispositivo.Size = New System.Drawing.Size(297, 20)
      Me.txtIdDispositivo.TabIndex = 8
      '
      'lblIdDispositivo
      '
      Me.lblIdDispositivo.AutoSize = True
      Me.lblIdDispositivo.Location = New System.Drawing.Point(14, 102)
      Me.lblIdDispositivo.Name = "lblIdDispositivo"
      Me.lblIdDispositivo.Size = New System.Drawing.Size(70, 13)
      Me.lblIdDispositivo.TabIndex = 7
      Me.lblIdDispositivo.Text = "Id Dispositivo"
      '
      'chbCaja
      '
      Me.chbCaja.AutoSize = True
      Me.chbCaja.BindearPropiedadControl = ""
      Me.chbCaja.BindearPropiedadEntidad = ""
      Me.chbCaja.ForeColorFocus = System.Drawing.Color.Red
      Me.chbCaja.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
      Me.chbCaja.IsPK = False
      Me.chbCaja.IsRequired = False
      Me.chbCaja.Key = Nothing
      Me.chbCaja.LabelAsoc = Nothing
      Me.chbCaja.Location = New System.Drawing.Point(14, 128)
      Me.chbCaja.Name = "chbCaja"
      Me.chbCaja.Size = New System.Drawing.Size(15, 14)
      Me.chbCaja.TabIndex = 9
      Me.chbCaja.UseVisualStyleBackColor = True
      '
      'cmbCaja
      '
      Me.cmbCaja.BindearPropiedadControl = "SelectedValue"
      Me.cmbCaja.BindearPropiedadEntidad = "CobradorSucursal.IdCaja"
      Me.cmbCaja.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cmbCaja.Enabled = False
      Me.cmbCaja.ForeColorFocus = System.Drawing.Color.Red
      Me.cmbCaja.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.cmbCaja.FormattingEnabled = True
      Me.cmbCaja.IsPK = False
      Me.cmbCaja.IsRequired = False
      Me.cmbCaja.Key = Nothing
      Me.cmbCaja.LabelAsoc = Me.lblCaja
      Me.cmbCaja.Location = New System.Drawing.Point(94, 125)
      Me.cmbCaja.Name = "cmbCaja"
      Me.cmbCaja.Size = New System.Drawing.Size(157, 21)
      Me.cmbCaja.TabIndex = 11
      '
      'lblCaja
      '
      Me.lblCaja.AutoSize = True
      Me.lblCaja.Location = New System.Drawing.Point(34, 129)
      Me.lblCaja.Name = "lblCaja"
      Me.lblCaja.Size = New System.Drawing.Size(28, 13)
      Me.lblCaja.TabIndex = 10
      Me.lblCaja.Text = "Caja"
      '
      'lblObservacion
      '
      Me.lblObservacion.AutoSize = True
      Me.lblObservacion.Location = New System.Drawing.Point(14, 155)
      Me.lblObservacion.Name = "lblObservacion"
      Me.lblObservacion.Size = New System.Drawing.Size(78, 13)
      Me.lblObservacion.TabIndex = 12
      Me.lblObservacion.Text = "Observaciones"
      '
      'txtObservacion
      '
      Me.txtObservacion.BindearPropiedadControl = "Text"
      Me.txtObservacion.BindearPropiedadEntidad = "Observacion"
      Me.txtObservacion.ForeColorFocus = System.Drawing.Color.Red
      Me.txtObservacion.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtObservacion.Formato = ""
      Me.txtObservacion.IsDecimal = False
      Me.txtObservacion.IsNumber = False
      Me.txtObservacion.IsPK = False
      Me.txtObservacion.IsRequired = False
      Me.txtObservacion.Key = ""
      Me.txtObservacion.LabelAsoc = Me.lblObservacion
      Me.txtObservacion.Location = New System.Drawing.Point(94, 152)
      Me.txtObservacion.MaxLength = 100
      Me.txtObservacion.Name = "txtObservacion"
      Me.txtObservacion.Size = New System.Drawing.Size(297, 20)
      Me.txtObservacion.TabIndex = 13
      '
      'CobradoresDetalle
      '
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.ClientSize = New System.Drawing.Size(404, 220)
      Me.Controls.Add(Me.lblObservacion)
      Me.Controls.Add(Me.txtObservacion)
      Me.Controls.Add(Me.lblCaja)
      Me.Controls.Add(Me.lblBanco)
      Me.Controls.Add(Me.cmbCaja)
      Me.Controls.Add(Me.chbCaja)
      Me.Controls.Add(Me.cmbBanco)
      Me.Controls.Add(Me.chbDebitoDirecto)
      Me.Controls.Add(Me.lblIdDispositivo)
      Me.Controls.Add(Me.lblNombreCobrador)
      Me.Controls.Add(Me.txtIdDispositivo)
      Me.Controls.Add(Me.txtNombreCobrador)
      Me.Controls.Add(Me.lblIdCobrador)
      Me.Controls.Add(Me.txtIdCobrador)
      Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
      Me.Name = "CobradoresDetalle"
      Me.Text = "Cobrador"
      Me.Controls.SetChildIndex(Me.btnAplicar, 0)
      Me.Controls.SetChildIndex(Me.btnCopiar, 0)
      Me.Controls.SetChildIndex(Me.txtIdCobrador, 0)
      Me.Controls.SetChildIndex(Me.lblIdCobrador, 0)
      Me.Controls.SetChildIndex(Me.btnCancelar, 0)
      Me.Controls.SetChildIndex(Me.btnAceptar, 0)
      Me.Controls.SetChildIndex(Me.txtNombreCobrador, 0)
      Me.Controls.SetChildIndex(Me.txtIdDispositivo, 0)
      Me.Controls.SetChildIndex(Me.lblNombreCobrador, 0)
      Me.Controls.SetChildIndex(Me.lblIdDispositivo, 0)
      Me.Controls.SetChildIndex(Me.chbDebitoDirecto, 0)
      Me.Controls.SetChildIndex(Me.cmbBanco, 0)
      Me.Controls.SetChildIndex(Me.chbCaja, 0)
      Me.Controls.SetChildIndex(Me.cmbCaja, 0)
      Me.Controls.SetChildIndex(Me.lblBanco, 0)
      Me.Controls.SetChildIndex(Me.lblCaja, 0)
      Me.Controls.SetChildIndex(Me.txtObservacion, 0)
      Me.Controls.SetChildIndex(Me.lblObservacion, 0)
      Me.ResumeLayout(False)
      Me.PerformLayout()

   End Sub
   Friend WithEvents txtIdCobrador As Eniac.Controles.TextBox
   Friend WithEvents lblIdCobrador As Eniac.Controles.Label
   Friend WithEvents lblNombreCobrador As Eniac.Controles.Label
   Friend WithEvents txtNombreCobrador As Eniac.Controles.TextBox
   Friend WithEvents chbDebitoDirecto As Eniac.Controles.CheckBox
   Friend WithEvents cmbBanco As Eniac.Controles.ComboBox
   Friend WithEvents lblBanco As Eniac.Controles.Label
   Friend WithEvents txtIdDispositivo As Eniac.Controles.TextBox
   Friend WithEvents lblIdDispositivo As Eniac.Controles.Label
   Friend WithEvents chbCaja As Eniac.Controles.CheckBox
   Friend WithEvents cmbCaja As Eniac.Controles.ComboBox
   Friend WithEvents lblCaja As Eniac.Controles.Label
   Friend WithEvents lblObservacion As Eniac.Controles.Label
   Friend WithEvents txtObservacion As Eniac.Controles.TextBox

End Class
