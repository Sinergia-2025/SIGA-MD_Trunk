<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class AlertasMutualDetalle
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
      Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(AlertasMutualDetalle))
      Me.grbPlanDePagos = New System.Windows.Forms.GroupBox()
      Me.cmbTipoNotificacion = New Eniac.Controles.ComboBox()
      Me.lblLocalidad = New Eniac.Controles.Label()
      Me.chbPrioridadAlta = New Eniac.Controles.CheckBox()
      Me.chbDesactivar = New Eniac.Controles.CheckBox()
      Me.dtpFecha = New Eniac.Controles.DateTimePicker()
      Me.lblFecha = New Eniac.Controles.Label()
      Me.txtMotivo = New Eniac.Controles.TextBox()
      Me.lblMotivo = New Eniac.Controles.Label()
      Me.cmbTipoNovedad = New Eniac.Controles.ComboBox()
      Me.grbPlanDePagos.SuspendLayout()
      Me.SuspendLayout()
      '
      'btnAceptar
      '
      Me.btnAceptar.Location = New System.Drawing.Point(190, 220)
      Me.btnAceptar.TabIndex = 0
      '
      'btnCancelar
      '
      Me.btnCancelar.Location = New System.Drawing.Point(276, 220)
      Me.btnCancelar.TabIndex = 1
      '
      'btnCopiar
      '
      Me.btnCopiar.Location = New System.Drawing.Point(100, 199)
      '
      'btnAplicar
      '
      Me.btnAplicar.Location = New System.Drawing.Point(43, 199)
      '
      'grbPlanDePagos
      '
      Me.grbPlanDePagos.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.grbPlanDePagos.Controls.Add(Me.cmbTipoNotificacion)
      Me.grbPlanDePagos.Controls.Add(Me.lblLocalidad)
      Me.grbPlanDePagos.Controls.Add(Me.chbPrioridadAlta)
      Me.grbPlanDePagos.Controls.Add(Me.chbDesactivar)
      Me.grbPlanDePagos.Controls.Add(Me.dtpFecha)
      Me.grbPlanDePagos.Controls.Add(Me.lblFecha)
      Me.grbPlanDePagos.Controls.Add(Me.txtMotivo)
      Me.grbPlanDePagos.Controls.Add(Me.lblMotivo)
      Me.grbPlanDePagos.Controls.Add(Me.cmbTipoNovedad)
      Me.grbPlanDePagos.Location = New System.Drawing.Point(9, 12)
      Me.grbPlanDePagos.Name = "grbPlanDePagos"
      Me.grbPlanDePagos.Size = New System.Drawing.Size(347, 202)
      Me.grbPlanDePagos.TabIndex = 0
      Me.grbPlanDePagos.TabStop = False
      '
      'cmbTipoNotificacion
      '
      Me.cmbTipoNotificacion.BindearPropiedadControl = "SelectedValue"
      Me.cmbTipoNotificacion.BindearPropiedadEntidad = "CategoriaNovedad.IdCategoriaNovedad"
      Me.cmbTipoNotificacion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cmbTipoNotificacion.ForeColorFocus = System.Drawing.Color.Red
      Me.cmbTipoNotificacion.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.cmbTipoNotificacion.FormattingEnabled = True
      Me.cmbTipoNotificacion.IsPK = False
      Me.cmbTipoNotificacion.IsRequired = True
      Me.cmbTipoNotificacion.Key = Nothing
      Me.cmbTipoNotificacion.LabelAsoc = Me.lblLocalidad
      Me.cmbTipoNotificacion.Location = New System.Drawing.Point(170, 171)
      Me.cmbTipoNotificacion.Name = "cmbTipoNotificacion"
      Me.cmbTipoNotificacion.Size = New System.Drawing.Size(165, 21)
      Me.cmbTipoNotificacion.TabIndex = 5
      '
      'lblLocalidad
      '
      Me.lblLocalidad.AutoSize = True
      Me.lblLocalidad.LabelAsoc = Nothing
      Me.lblLocalidad.Location = New System.Drawing.Point(136, 175)
      Me.lblLocalidad.Name = "lblLocalidad"
      Me.lblLocalidad.Size = New System.Drawing.Size(28, 13)
      Me.lblLocalidad.TabIndex = 13
      Me.lblLocalidad.Text = "Tipo"
      '
      'chbPrioridadAlta
      '
      Me.chbPrioridadAlta.AutoSize = True
      Me.chbPrioridadAlta.BindearPropiedadControl = "Checked"
      Me.chbPrioridadAlta.BindearPropiedadEntidad = "Priorizado"
      Me.chbPrioridadAlta.ForeColorFocus = System.Drawing.Color.Red
      Me.chbPrioridadAlta.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
      Me.chbPrioridadAlta.IsPK = False
      Me.chbPrioridadAlta.IsRequired = False
      Me.chbPrioridadAlta.Key = Nothing
      Me.chbPrioridadAlta.LabelAsoc = Nothing
      Me.chbPrioridadAlta.Location = New System.Drawing.Point(247, 22)
      Me.chbPrioridadAlta.Name = "chbPrioridadAlta"
      Me.chbPrioridadAlta.Size = New System.Drawing.Size(88, 17)
      Me.chbPrioridadAlta.TabIndex = 2
      Me.chbPrioridadAlta.Text = "Prioridad Alta"
      Me.chbPrioridadAlta.UseVisualStyleBackColor = True
      '
      'chbDesactivar
      '
      Me.chbDesactivar.AutoSize = True
      Me.chbDesactivar.BindearPropiedadControl = "Checked"
      Me.chbDesactivar.BindearPropiedadEntidad = "RevisionAdministrativa"
      Me.chbDesactivar.ForeColorFocus = System.Drawing.Color.Red
      Me.chbDesactivar.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
      Me.chbDesactivar.IsPK = False
      Me.chbDesactivar.IsRequired = False
      Me.chbDesactivar.Key = Nothing
      Me.chbDesactivar.LabelAsoc = Nothing
      Me.chbDesactivar.Location = New System.Drawing.Point(6, 173)
      Me.chbDesactivar.Name = "chbDesactivar"
      Me.chbDesactivar.Size = New System.Drawing.Size(77, 17)
      Me.chbDesactivar.TabIndex = 4
      Me.chbDesactivar.Text = "Desactivar"
      Me.chbDesactivar.UseVisualStyleBackColor = True
      '
      'dtpFecha
      '
      Me.dtpFecha.BindearPropiedadControl = "Value"
      Me.dtpFecha.BindearPropiedadEntidad = "FechaNovedad"
      Me.dtpFecha.CustomFormat = "dd/MM/yyyy"
      Me.dtpFecha.ForeColorFocus = System.Drawing.Color.Red
      Me.dtpFecha.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.dtpFecha.Format = System.Windows.Forms.DateTimePickerFormat.Custom
      Me.dtpFecha.IsPK = True
      Me.dtpFecha.IsRequired = False
      Me.dtpFecha.Key = ""
      Me.dtpFecha.LabelAsoc = Me.lblFecha
      Me.dtpFecha.Location = New System.Drawing.Point(51, 20)
      Me.dtpFecha.Name = "dtpFecha"
      Me.dtpFecha.Size = New System.Drawing.Size(99, 20)
      Me.dtpFecha.TabIndex = 1
      '
      'lblFecha
      '
      Me.lblFecha.AutoSize = True
      Me.lblFecha.LabelAsoc = Nothing
      Me.lblFecha.Location = New System.Drawing.Point(8, 24)
      Me.lblFecha.Name = "lblFecha"
      Me.lblFecha.Size = New System.Drawing.Size(37, 13)
      Me.lblFecha.TabIndex = 11
      Me.lblFecha.Text = "Fecha"
      '
      'txtMotivo
      '
      Me.txtMotivo.BindearPropiedadControl = "Text"
      Me.txtMotivo.BindearPropiedadEntidad = "Descripcion"
      Me.txtMotivo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.txtMotivo.ForeColorFocus = System.Drawing.Color.Red
      Me.txtMotivo.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtMotivo.Formato = ""
      Me.txtMotivo.IsDecimal = False
      Me.txtMotivo.IsNumber = False
      Me.txtMotivo.IsPK = True
      Me.txtMotivo.IsRequired = True
      Me.txtMotivo.Key = ""
      Me.txtMotivo.LabelAsoc = Me.lblMotivo
      Me.txtMotivo.Location = New System.Drawing.Point(6, 59)
      Me.txtMotivo.MaxLength = 300
      Me.txtMotivo.Multiline = True
      Me.txtMotivo.Name = "txtMotivo"
      Me.txtMotivo.Size = New System.Drawing.Size(330, 100)
      Me.txtMotivo.TabIndex = 3
      '
      'lblMotivo
      '
      Me.lblMotivo.AutoSize = True
      Me.lblMotivo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.lblMotivo.LabelAsoc = Nothing
      Me.lblMotivo.Location = New System.Drawing.Point(6, 43)
      Me.lblMotivo.Name = "lblMotivo"
      Me.lblMotivo.Size = New System.Drawing.Size(39, 13)
      Me.lblMotivo.TabIndex = 2
      Me.lblMotivo.Text = "Motivo"
      '
      'cmbTipoNovedad
      '
      Me.cmbTipoNovedad.BindearPropiedadControl = "SelectedValue"
      Me.cmbTipoNovedad.BindearPropiedadEntidad = "TipoNovedad.IdTipoNovedad"
      Me.cmbTipoNovedad.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cmbTipoNovedad.Enabled = False
      Me.cmbTipoNovedad.ForeColorFocus = System.Drawing.Color.Red
      Me.cmbTipoNovedad.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.cmbTipoNovedad.FormattingEnabled = True
      Me.cmbTipoNovedad.IsPK = False
      Me.cmbTipoNovedad.IsRequired = False
      Me.cmbTipoNovedad.Key = Nothing
      Me.cmbTipoNovedad.LabelAsoc = Nothing
      Me.cmbTipoNovedad.Location = New System.Drawing.Point(6, 19)
      Me.cmbTipoNovedad.Name = "cmbTipoNovedad"
      Me.cmbTipoNovedad.Size = New System.Drawing.Size(135, 21)
      Me.cmbTipoNovedad.TabIndex = 21
      Me.cmbTipoNovedad.TabStop = False
      Me.cmbTipoNovedad.Visible = False
      '
      'AlertasMutualDetalle
      '
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.ClientSize = New System.Drawing.Size(365, 255)
      Me.Controls.Add(Me.grbPlanDePagos)
      Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
      Me.Name = "AlertasMutualDetalle"
      Me.Text = "Alerta Mutual"
      Me.Controls.SetChildIndex(Me.btnCopiar, 0)
      Me.Controls.SetChildIndex(Me.btnAplicar, 0)
      Me.Controls.SetChildIndex(Me.btnCancelar, 0)
      Me.Controls.SetChildIndex(Me.btnAceptar, 0)
      Me.Controls.SetChildIndex(Me.grbPlanDePagos, 0)
      Me.grbPlanDePagos.ResumeLayout(False)
      Me.grbPlanDePagos.PerformLayout()
      Me.ResumeLayout(False)

   End Sub
   Friend WithEvents grbPlanDePagos As System.Windows.Forms.GroupBox
   Friend WithEvents dtpFecha As Eniac.Controles.DateTimePicker
   Friend WithEvents lblFecha As Eniac.Controles.Label
   Friend WithEvents txtMotivo As Eniac.Controles.TextBox
   Friend WithEvents lblMotivo As Eniac.Controles.Label
   Friend WithEvents chbDesactivar As Eniac.Controles.CheckBox
   Friend WithEvents chbPrioridadAlta As Eniac.Controles.CheckBox
   Friend WithEvents cmbTipoNotificacion As Eniac.Controles.ComboBox
   Friend WithEvents lblLocalidad As Eniac.Controles.Label
   Friend WithEvents cmbTipoNovedad As Eniac.Controles.ComboBox
End Class
