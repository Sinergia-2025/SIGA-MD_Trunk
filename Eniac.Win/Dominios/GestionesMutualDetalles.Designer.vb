<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class GestionesMutualDetalles
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
      Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(GestionesMutualDetalles))
      Me.grbPlanDePagos = New System.Windows.Forms.GroupBox()
      Me.cmbTipoNovedad = New Eniac.Controles.ComboBox()
      Me.cmbTipoNotificacion = New Eniac.Controles.ComboBox()
      Me.lblLocalidad = New Eniac.Controles.Label()
      Me.txtUsuario = New Eniac.Controles.TextBox()
      Me.lblUsuario = New Eniac.Controles.Label()
      Me.dtpFecha = New Eniac.Controles.DateTimePicker()
      Me.lblFecha = New Eniac.Controles.Label()
      Me.txtDescripcion = New Eniac.Controles.TextBox()
      Me.lblDescripcion = New Eniac.Controles.Label()
      Me.grbPlanDePagos.SuspendLayout()
      Me.SuspendLayout()
      '
      'btnAceptar
      '
      Me.btnAceptar.Location = New System.Drawing.Point(185, 188)
      Me.btnAceptar.TabIndex = 0
      '
      'btnCancelar
      '
      Me.btnCancelar.Location = New System.Drawing.Point(271, 188)
      Me.btnCancelar.TabIndex = 1
      '
      'btnCopiar
      '
      Me.btnCopiar.Location = New System.Drawing.Point(97, 181)
      '
      'btnAplicar
      '
      Me.btnAplicar.Location = New System.Drawing.Point(40, 181)
      '
      'grbPlanDePagos
      '
      Me.grbPlanDePagos.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.grbPlanDePagos.Controls.Add(Me.cmbTipoNotificacion)
      Me.grbPlanDePagos.Controls.Add(Me.lblLocalidad)
      Me.grbPlanDePagos.Controls.Add(Me.txtUsuario)
      Me.grbPlanDePagos.Controls.Add(Me.lblUsuario)
      Me.grbPlanDePagos.Controls.Add(Me.dtpFecha)
      Me.grbPlanDePagos.Controls.Add(Me.lblFecha)
      Me.grbPlanDePagos.Controls.Add(Me.txtDescripcion)
      Me.grbPlanDePagos.Controls.Add(Me.lblDescripcion)
      Me.grbPlanDePagos.Controls.Add(Me.cmbTipoNovedad)
      Me.grbPlanDePagos.Location = New System.Drawing.Point(6, 3)
      Me.grbPlanDePagos.Name = "grbPlanDePagos"
      Me.grbPlanDePagos.Size = New System.Drawing.Size(345, 179)
      Me.grbPlanDePagos.TabIndex = 0
      Me.grbPlanDePagos.TabStop = False
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
      Me.cmbTipoNovedad.Location = New System.Drawing.Point(18, 19)
      Me.cmbTipoNovedad.Name = "cmbTipoNovedad"
      Me.cmbTipoNovedad.Size = New System.Drawing.Size(135, 21)
      Me.cmbTipoNovedad.TabIndex = 20
      Me.cmbTipoNovedad.TabStop = False
      Me.cmbTipoNovedad.Visible = False
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
      Me.cmbTipoNotificacion.Location = New System.Drawing.Point(171, 45)
      Me.cmbTipoNotificacion.Name = "cmbTipoNotificacion"
      Me.cmbTipoNotificacion.Size = New System.Drawing.Size(165, 21)
      Me.cmbTipoNotificacion.TabIndex = 1
      '
      'lblLocalidad
      '
      Me.lblLocalidad.AutoSize = True
      Me.lblLocalidad.LabelAsoc = Nothing
      Me.lblLocalidad.Location = New System.Drawing.Point(143, 48)
      Me.lblLocalidad.Name = "lblLocalidad"
      Me.lblLocalidad.Size = New System.Drawing.Size(28, 13)
      Me.lblLocalidad.TabIndex = 19
      Me.lblLocalidad.Text = "Tipo"
      '
      'txtUsuario
      '
      Me.txtUsuario.BindearPropiedadControl = "Text"
      Me.txtUsuario.BindearPropiedadEntidad = "IdUsuarioAlta"
      Me.txtUsuario.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.txtUsuario.ForeColorFocus = System.Drawing.Color.Red
      Me.txtUsuario.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtUsuario.Formato = ""
      Me.txtUsuario.IsDecimal = False
      Me.txtUsuario.IsNumber = False
      Me.txtUsuario.IsPK = False
      Me.txtUsuario.IsRequired = False
      Me.txtUsuario.Key = ""
      Me.txtUsuario.LabelAsoc = Me.lblUsuario
      Me.txtUsuario.Location = New System.Drawing.Point(243, 14)
      Me.txtUsuario.MaxLength = 50
      Me.txtUsuario.Name = "txtUsuario"
      Me.txtUsuario.ReadOnly = True
      Me.txtUsuario.Size = New System.Drawing.Size(93, 20)
      Me.txtUsuario.TabIndex = 2
      '
      'lblUsuario
      '
      Me.lblUsuario.AutoSize = True
      Me.lblUsuario.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.lblUsuario.LabelAsoc = Nothing
      Me.lblUsuario.Location = New System.Drawing.Point(194, 18)
      Me.lblUsuario.Name = "lblUsuario"
      Me.lblUsuario.Size = New System.Drawing.Size(43, 13)
      Me.lblUsuario.TabIndex = 17
      Me.lblUsuario.Text = "Usuario"
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
      Me.dtpFecha.Location = New System.Drawing.Point(51, 14)
      Me.dtpFecha.Name = "dtpFecha"
      Me.dtpFecha.Size = New System.Drawing.Size(99, 20)
      Me.dtpFecha.TabIndex = 0
      '
      'lblFecha
      '
      Me.lblFecha.AutoSize = True
      Me.lblFecha.LabelAsoc = Nothing
      Me.lblFecha.Location = New System.Drawing.Point(8, 18)
      Me.lblFecha.Name = "lblFecha"
      Me.lblFecha.Size = New System.Drawing.Size(37, 13)
      Me.lblFecha.TabIndex = 11
      Me.lblFecha.Text = "Fecha"
      '
      'txtDescripcion
      '
      Me.txtDescripcion.BindearPropiedadControl = "Text"
      Me.txtDescripcion.BindearPropiedadEntidad = "Descripcion"
      Me.txtDescripcion.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.txtDescripcion.ForeColorFocus = System.Drawing.Color.Red
      Me.txtDescripcion.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtDescripcion.Formato = ""
      Me.txtDescripcion.IsDecimal = False
      Me.txtDescripcion.IsNumber = False
      Me.txtDescripcion.IsPK = False
      Me.txtDescripcion.IsRequired = True
      Me.txtDescripcion.Key = ""
      Me.txtDescripcion.LabelAsoc = Me.lblDescripcion
      Me.txtDescripcion.Location = New System.Drawing.Point(6, 72)
      Me.txtDescripcion.MaxLength = 300
      Me.txtDescripcion.Multiline = True
      Me.txtDescripcion.Name = "txtDescripcion"
      Me.txtDescripcion.Size = New System.Drawing.Size(330, 100)
      Me.txtDescripcion.TabIndex = 2
      '
      'lblDescripcion
      '
      Me.lblDescripcion.AutoSize = True
      Me.lblDescripcion.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.lblDescripcion.LabelAsoc = Nothing
      Me.lblDescripcion.Location = New System.Drawing.Point(7, 56)
      Me.lblDescripcion.Name = "lblDescripcion"
      Me.lblDescripcion.Size = New System.Drawing.Size(63, 13)
      Me.lblDescripcion.TabIndex = 2
      Me.lblDescripcion.Text = "Descripcion"
      '
      'GestionesMutualDetalles
      '
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.ClientSize = New System.Drawing.Size(360, 223)
      Me.Controls.Add(Me.grbPlanDePagos)
      Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
      Me.Name = "GestionesMutualDetalles"
      Me.Text = "Gestion Mutual"
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
   Friend WithEvents txtUsuario As Eniac.Controles.TextBox
   Friend WithEvents lblUsuario As Eniac.Controles.Label
   Friend WithEvents dtpFecha As Eniac.Controles.DateTimePicker
   Friend WithEvents lblFecha As Eniac.Controles.Label
   Friend WithEvents txtDescripcion As Eniac.Controles.TextBox
   Friend WithEvents lblDescripcion As Eniac.Controles.Label
   Friend WithEvents cmbTipoNotificacion As Eniac.Controles.ComboBox
   Friend WithEvents lblLocalidad As Eniac.Controles.Label
   Friend WithEvents cmbTipoNovedad As Eniac.Controles.ComboBox
End Class
