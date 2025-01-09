<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CRMPrioridadesNovedadesDetalle
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
      Me.txtNombrePlanCuenta = New Eniac.Controles.TextBox()
      Me.lblCodigo = New Eniac.Controles.Label()
      Me.txtIdPlanCuenta = New Eniac.Controles.TextBox()
      Me.txtPosicion = New Eniac.Controles.TextBox()
      Me.lblPosicion = New Eniac.Controles.Label()
      Me.cmbTipoNovedad = New Eniac.Controles.ComboBox()
      Me.Label1 = New Eniac.Controles.Label()
      Me.chbPorDefecto = New Eniac.Controles.CheckBox()
      Me.SuspendLayout()
      '
      'btnAceptar
      '
      Me.btnAceptar.Location = New System.Drawing.Point(146, 147)
      Me.btnAceptar.TabIndex = 9
      '
      'btnCancelar
      '
      Me.btnCancelar.Location = New System.Drawing.Point(232, 147)
      Me.btnCancelar.TabIndex = 10
      '
      'btnCopiar
      '
      Me.btnCopiar.Location = New System.Drawing.Point(45, 147)
      Me.btnCopiar.TabIndex = 11
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
      'txtNombrePlanCuenta
      '
      Me.txtNombrePlanCuenta.BindearPropiedadControl = "Text"
      Me.txtNombrePlanCuenta.BindearPropiedadEntidad = "NombrePrioridadNovedad"
      Me.txtNombrePlanCuenta.ForeColorFocus = System.Drawing.Color.Red
      Me.txtNombrePlanCuenta.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtNombrePlanCuenta.Formato = ""
      Me.txtNombrePlanCuenta.IsDecimal = False
      Me.txtNombrePlanCuenta.IsNumber = False
      Me.txtNombrePlanCuenta.IsPK = False
      Me.txtNombrePlanCuenta.IsRequired = True
      Me.txtNombrePlanCuenta.Key = ""
      Me.txtNombrePlanCuenta.LabelAsoc = Me.lblDescripcion
      Me.txtNombrePlanCuenta.Location = New System.Drawing.Point(86, 38)
      Me.txtNombrePlanCuenta.MaxLength = 20
      Me.txtNombrePlanCuenta.Name = "txtNombrePlanCuenta"
      Me.txtNombrePlanCuenta.Size = New System.Drawing.Size(226, 20)
      Me.txtNombrePlanCuenta.TabIndex = 3
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
      'txtIdPlanCuenta
      '
      Me.txtIdPlanCuenta.BindearPropiedadControl = "Text"
      Me.txtIdPlanCuenta.BindearPropiedadEntidad = "IdPrioridadNovedad"
      Me.txtIdPlanCuenta.ForeColorFocus = System.Drawing.Color.Red
      Me.txtIdPlanCuenta.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtIdPlanCuenta.Formato = ""
      Me.txtIdPlanCuenta.IsDecimal = False
      Me.txtIdPlanCuenta.IsNumber = True
      Me.txtIdPlanCuenta.IsPK = True
      Me.txtIdPlanCuenta.IsRequired = True
      Me.txtIdPlanCuenta.Key = ""
      Me.txtIdPlanCuenta.LabelAsoc = Me.lblCodigo
      Me.txtIdPlanCuenta.Location = New System.Drawing.Point(86, 12)
      Me.txtIdPlanCuenta.Name = "txtIdPlanCuenta"
      Me.txtIdPlanCuenta.Size = New System.Drawing.Size(54, 20)
      Me.txtIdPlanCuenta.TabIndex = 1
      Me.txtIdPlanCuenta.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
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
      Me.cmbTipoNovedad.Size = New System.Drawing.Size(226, 21)
      Me.cmbTipoNovedad.TabIndex = 5
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
      Me.chbPorDefecto.Location = New System.Drawing.Point(86, 117)
      Me.chbPorDefecto.Name = "chbPorDefecto"
      Me.chbPorDefecto.Size = New System.Drawing.Size(83, 17)
      Me.chbPorDefecto.TabIndex = 8
      Me.chbPorDefecto.Text = "Por Defecto"
      Me.chbPorDefecto.UseVisualStyleBackColor = True
      '
      'CRMPrioridadesNovedadesDetalle
      '
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.ClientSize = New System.Drawing.Size(321, 182)
      Me.Controls.Add(Me.chbPorDefecto)
      Me.Controls.Add(Me.cmbTipoNovedad)
      Me.Controls.Add(Me.lblDescripcion)
      Me.Controls.Add(Me.txtNombrePlanCuenta)
      Me.Controls.Add(Me.Label1)
      Me.Controls.Add(Me.lblPosicion)
      Me.Controls.Add(Me.lblCodigo)
      Me.Controls.Add(Me.txtPosicion)
      Me.Controls.Add(Me.txtIdPlanCuenta)
      Me.Name = "CRMPrioridadesNovedadesDetalle"
      Me.Text = "Prioridad Novedad"
      Me.Controls.SetChildIndex(Me.btnAplicar, 0)
      Me.Controls.SetChildIndex(Me.btnCopiar, 0)
      Me.Controls.SetChildIndex(Me.btnCancelar, 0)
      Me.Controls.SetChildIndex(Me.btnAceptar, 0)
      Me.Controls.SetChildIndex(Me.txtIdPlanCuenta, 0)
      Me.Controls.SetChildIndex(Me.txtPosicion, 0)
      Me.Controls.SetChildIndex(Me.lblCodigo, 0)
      Me.Controls.SetChildIndex(Me.lblPosicion, 0)
      Me.Controls.SetChildIndex(Me.Label1, 0)
      Me.Controls.SetChildIndex(Me.txtNombrePlanCuenta, 0)
      Me.Controls.SetChildIndex(Me.lblDescripcion, 0)
      Me.Controls.SetChildIndex(Me.cmbTipoNovedad, 0)
      Me.Controls.SetChildIndex(Me.chbPorDefecto, 0)
      Me.ResumeLayout(False)
      Me.PerformLayout()

   End Sub
   Friend WithEvents lblDescripcion As Eniac.Controles.Label
   Friend WithEvents txtNombrePlanCuenta As Eniac.Controles.TextBox
   Friend WithEvents lblCodigo As Eniac.Controles.Label
   Friend WithEvents txtIdPlanCuenta As Eniac.Controles.TextBox
   Friend WithEvents txtPosicion As Eniac.Controles.TextBox
   Friend WithEvents lblPosicion As Eniac.Controles.Label
   Friend WithEvents cmbTipoNovedad As Eniac.Controles.ComboBox
   Friend WithEvents Label1 As Eniac.Controles.Label
   Friend WithEvents chbPorDefecto As Eniac.Controles.CheckBox
End Class
