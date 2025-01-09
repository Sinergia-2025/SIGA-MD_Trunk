<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class CRMCiclosPlanificacionDetalle
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
      Me.components = New System.ComponentModel.Container()
      Me.cmbEstadoCicloPlanificacion = New Eniac.Controles.ComboBox()
      Me.lblNombre = New Eniac.Controles.Label()
      Me.txtNombreCicloPlanificacion = New Eniac.Controles.TextBox()
      Me.lblEstadoCicloPlanificacion = New Eniac.Controles.Label()
        Me.lblCodigo = New Eniac.Controles.Label()
        Me.txtIdCicloPlanificacion = New Eniac.Controles.TextBox()
        Me.cdColor = New System.Windows.Forms.ColorDialog()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.lblFechaInicio = New Eniac.Controles.Label()
        Me.dtpFechaInicio = New Eniac.Controles.DateTimePicker()
        Me.dtpFechaCierre = New Eniac.Controles.DateTimePicker()
        Me.lblFechaCierre = New Eniac.Controles.Label()
        Me.dtpFechaFinalizacion = New Eniac.Controles.DateTimePicker()
        Me.lblFechaFinalizacion = New Eniac.Controles.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.pnlUsuarios = New System.Windows.Forms.Panel()
        Me.txtFechaActualizacion = New Eniac.Controles.TextBox()
        Me.txtIdUsuarioActualizacion = New Eniac.Controles.TextBox()
        Me.lblActualizacion = New Eniac.Controles.Label()
        Me.txtFechaAlta = New Eniac.Controles.TextBox()
        Me.txtIdUsuarioAlta = New Eniac.Controles.TextBox()
        Me.lblAlta = New Eniac.Controles.Label()
        Me.Panel1.SuspendLayout()
        Me.pnlUsuarios.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnAceptar
        '
        Me.btnAceptar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnAceptar.Location = New System.Drawing.Point(423, 1)
        Me.btnAceptar.Margin = New System.Windows.Forms.Padding(4)
        Me.btnAceptar.TabIndex = 0
        '
        'btnCancelar
        '
        Me.btnCancelar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCancelar.Location = New System.Drawing.Point(509, 1)
        Me.btnCancelar.Margin = New System.Windows.Forms.Padding(4)
        Me.btnCancelar.TabIndex = 1
        '
        'btnCopiar
        '
        Me.btnCopiar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCopiar.Location = New System.Drawing.Point(322, 1)
        Me.btnCopiar.Margin = New System.Windows.Forms.Padding(4)
        '
        'btnAplicar
        '
        Me.btnAplicar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnAplicar.Location = New System.Drawing.Point(263, 1)
        Me.btnAplicar.Margin = New System.Windows.Forms.Padding(4)
        Me.btnAplicar.TabIndex = 2
        '
        'cmbEstadoCicloPlanificacion
        '
        Me.cmbEstadoCicloPlanificacion.BindearPropiedadControl = "SelectedValue"
        Me.cmbEstadoCicloPlanificacion.BindearPropiedadEntidad = "EstadoCicloPlanificacion.IdEstadoCicloPlanificacion"
        Me.cmbEstadoCicloPlanificacion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbEstadoCicloPlanificacion.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbEstadoCicloPlanificacion.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbEstadoCicloPlanificacion.FormattingEnabled = True
        Me.cmbEstadoCicloPlanificacion.IsPK = False
        Me.cmbEstadoCicloPlanificacion.IsRequired = False
        Me.cmbEstadoCicloPlanificacion.Key = Nothing
        Me.cmbEstadoCicloPlanificacion.LabelAsoc = Nothing
        Me.cmbEstadoCicloPlanificacion.Location = New System.Drawing.Point(106, 64)
        Me.cmbEstadoCicloPlanificacion.Name = "cmbEstadoCicloPlanificacion"
        Me.cmbEstadoCicloPlanificacion.Size = New System.Drawing.Size(150, 21)
        Me.cmbEstadoCicloPlanificacion.TabIndex = 5
        '
        'lblNombre
        '
        Me.lblNombre.AutoSize = True
        Me.lblNombre.LabelAsoc = Nothing
        Me.lblNombre.Location = New System.Drawing.Point(29, 42)
        Me.lblNombre.Name = "lblNombre"
        Me.lblNombre.Size = New System.Drawing.Size(44, 13)
        Me.lblNombre.TabIndex = 2
        Me.lblNombre.Text = "Nombre"
        '
        'txtNombreCicloPlanificacion
        '
        Me.txtNombreCicloPlanificacion.BindearPropiedadControl = "Text"
        Me.txtNombreCicloPlanificacion.BindearPropiedadEntidad = "NombreCicloPlanificacion"
        Me.txtNombreCicloPlanificacion.ForeColorFocus = System.Drawing.Color.Red
        Me.txtNombreCicloPlanificacion.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtNombreCicloPlanificacion.Formato = ""
        Me.txtNombreCicloPlanificacion.IsDecimal = False
        Me.txtNombreCicloPlanificacion.IsNumber = False
        Me.txtNombreCicloPlanificacion.IsPK = False
        Me.txtNombreCicloPlanificacion.IsRequired = True
        Me.txtNombreCicloPlanificacion.Key = ""
        Me.txtNombreCicloPlanificacion.LabelAsoc = Me.lblNombre
        Me.txtNombreCicloPlanificacion.Location = New System.Drawing.Point(106, 38)
        Me.txtNombreCicloPlanificacion.MaxLength = 20
        Me.txtNombreCicloPlanificacion.Name = "txtNombreCicloPlanificacion"
        Me.txtNombreCicloPlanificacion.Size = New System.Drawing.Size(263, 20)
        Me.txtNombreCicloPlanificacion.TabIndex = 3
        '
        'lblEstadoCicloPlanificacion
        '
        Me.lblEstadoCicloPlanificacion.AutoSize = True
        Me.lblEstadoCicloPlanificacion.LabelAsoc = Nothing
        Me.lblEstadoCicloPlanificacion.Location = New System.Drawing.Point(29, 67)
        Me.lblEstadoCicloPlanificacion.Name = "lblEstadoCicloPlanificacion"
        Me.lblEstadoCicloPlanificacion.Size = New System.Drawing.Size(40, 13)
        Me.lblEstadoCicloPlanificacion.TabIndex = 4
        Me.lblEstadoCicloPlanificacion.Text = "Estado"
        '
        'lblCodigo
        '
        Me.lblCodigo.AutoSize = True
        Me.lblCodigo.LabelAsoc = Nothing
        Me.lblCodigo.Location = New System.Drawing.Point(29, 16)
        Me.lblCodigo.Name = "lblCodigo"
        Me.lblCodigo.Size = New System.Drawing.Size(40, 13)
        Me.lblCodigo.TabIndex = 0
        Me.lblCodigo.Text = "Codigo"
        '
        'txtIdCicloPlanificacion
        '
        Me.txtIdCicloPlanificacion.BindearPropiedadControl = "Text"
        Me.txtIdCicloPlanificacion.BindearPropiedadEntidad = "IdCicloPlanificacion"
        Me.txtIdCicloPlanificacion.ForeColorFocus = System.Drawing.Color.Red
        Me.txtIdCicloPlanificacion.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtIdCicloPlanificacion.Formato = ""
        Me.txtIdCicloPlanificacion.IsDecimal = False
        Me.txtIdCicloPlanificacion.IsNumber = True
        Me.txtIdCicloPlanificacion.IsPK = True
        Me.txtIdCicloPlanificacion.IsRequired = True
        Me.txtIdCicloPlanificacion.Key = ""
        Me.txtIdCicloPlanificacion.LabelAsoc = Me.lblCodigo
        Me.txtIdCicloPlanificacion.Location = New System.Drawing.Point(106, 12)
        Me.txtIdCicloPlanificacion.MaxLength = 10
        Me.txtIdCicloPlanificacion.Name = "txtIdCicloPlanificacion"
        Me.txtIdCicloPlanificacion.Size = New System.Drawing.Size(54, 20)
        Me.txtIdCicloPlanificacion.TabIndex = 1
        Me.txtIdCicloPlanificacion.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblFechaInicio
        '
        Me.lblFechaInicio.AutoSize = True
        Me.lblFechaInicio.LabelAsoc = Nothing
        Me.lblFechaInicio.Location = New System.Drawing.Point(29, 95)
        Me.lblFechaInicio.Name = "lblFechaInicio"
        Me.lblFechaInicio.Size = New System.Drawing.Size(65, 13)
        Me.lblFechaInicio.TabIndex = 6
        Me.lblFechaInicio.Text = "Fecha Inicio"
        '
        'dtpFechaInicio
        '
        Me.dtpFechaInicio.BindearPropiedadControl = "Value"
        Me.dtpFechaInicio.BindearPropiedadEntidad = "FechaInicio"
        Me.dtpFechaInicio.CustomFormat = "dd/MM/yyyy"
        Me.dtpFechaInicio.ForeColorFocus = System.Drawing.Color.Red
        Me.dtpFechaInicio.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.dtpFechaInicio.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpFechaInicio.IsPK = False
        Me.dtpFechaInicio.IsRequired = True
        Me.dtpFechaInicio.Key = ""
        Me.dtpFechaInicio.LabelAsoc = Me.lblFechaInicio
        Me.dtpFechaInicio.Location = New System.Drawing.Point(106, 91)
        Me.dtpFechaInicio.Name = "dtpFechaInicio"
        Me.dtpFechaInicio.Size = New System.Drawing.Size(100, 20)
        Me.dtpFechaInicio.TabIndex = 7
        '
        'dtpFechaCierre
        '
        Me.dtpFechaCierre.BindearPropiedadControl = "Value"
        Me.dtpFechaCierre.BindearPropiedadEntidad = "FechaCierre"
        Me.dtpFechaCierre.CustomFormat = "dd/MM/yyyy"
        Me.dtpFechaCierre.ForeColorFocus = System.Drawing.Color.Red
        Me.dtpFechaCierre.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.dtpFechaCierre.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpFechaCierre.IsPK = False
        Me.dtpFechaCierre.IsRequired = False
        Me.dtpFechaCierre.Key = ""
        Me.dtpFechaCierre.LabelAsoc = Me.lblFechaCierre
        Me.dtpFechaCierre.Location = New System.Drawing.Point(289, 91)
        Me.dtpFechaCierre.Name = "dtpFechaCierre"
        Me.dtpFechaCierre.Size = New System.Drawing.Size(100, 20)
        Me.dtpFechaCierre.TabIndex = 9
        '
        'lblFechaCierre
        '
        Me.lblFechaCierre.AutoSize = True
        Me.lblFechaCierre.LabelAsoc = Nothing
        Me.lblFechaCierre.Location = New System.Drawing.Point(212, 95)
        Me.lblFechaCierre.Name = "lblFechaCierre"
        Me.lblFechaCierre.Size = New System.Drawing.Size(67, 13)
        Me.lblFechaCierre.TabIndex = 8
        Me.lblFechaCierre.Text = "Fecha Cierre"
        '
        'dtpFechaFinalizacion
        '
        Me.dtpFechaFinalizacion.BindearPropiedadControl = "Value"
        Me.dtpFechaFinalizacion.BindearPropiedadEntidad = "FechaFinalizacion"
        Me.dtpFechaFinalizacion.CustomFormat = "dd/MM/yyyy"
        Me.dtpFechaFinalizacion.ForeColorFocus = System.Drawing.Color.Red
        Me.dtpFechaFinalizacion.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.dtpFechaFinalizacion.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpFechaFinalizacion.IsPK = False
        Me.dtpFechaFinalizacion.IsRequired = False
        Me.dtpFechaFinalizacion.Key = ""
        Me.dtpFechaFinalizacion.LabelAsoc = Me.lblFechaFinalizacion
        Me.dtpFechaFinalizacion.Location = New System.Drawing.Point(472, 91)
        Me.dtpFechaFinalizacion.Name = "dtpFechaFinalizacion"
        Me.dtpFechaFinalizacion.Size = New System.Drawing.Size(100, 20)
        Me.dtpFechaFinalizacion.TabIndex = 11
        '
        'lblFechaFinalizacion
        '
        Me.lblFechaFinalizacion.AutoSize = True
        Me.lblFechaFinalizacion.LabelAsoc = Nothing
        Me.lblFechaFinalizacion.Location = New System.Drawing.Point(395, 95)
        Me.lblFechaFinalizacion.Name = "lblFechaFinalizacion"
        Me.lblFechaFinalizacion.Size = New System.Drawing.Size(54, 13)
        Me.lblFechaFinalizacion.TabIndex = 10
        Me.lblFechaFinalizacion.Text = "Fecha Fin"
        '
        'Panel1
        '
        Me.Panel1.AutoSize = True
        Me.Panel1.Controls.Add(Me.btnAceptar)
        Me.Panel1.Controls.Add(Me.btnCancelar)
        Me.Panel1.Controls.Add(Me.btnCopiar)
        Me.Panel1.Controls.Add(Me.btnAplicar)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel1.Location = New System.Drawing.Point(0, 145)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(593, 35)
        Me.Panel1.TabIndex = 13
        '
        'pnlUsuarios
        '
        Me.pnlUsuarios.AutoSize = True
        Me.pnlUsuarios.Controls.Add(Me.txtFechaActualizacion)
        Me.pnlUsuarios.Controls.Add(Me.txtIdUsuarioActualizacion)
        Me.pnlUsuarios.Controls.Add(Me.lblActualizacion)
        Me.pnlUsuarios.Controls.Add(Me.txtFechaAlta)
        Me.pnlUsuarios.Controls.Add(Me.txtIdUsuarioAlta)
        Me.pnlUsuarios.Controls.Add(Me.lblAlta)
        Me.pnlUsuarios.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnlUsuarios.Location = New System.Drawing.Point(0, 119)
        Me.pnlUsuarios.Name = "pnlUsuarios"
        Me.pnlUsuarios.Size = New System.Drawing.Size(593, 26)
        Me.pnlUsuarios.TabIndex = 12
        '
        'txtFechaActualizacion
        '
        Me.txtFechaActualizacion.BindearPropiedadControl = "Text"
        Me.txtFechaActualizacion.BindearPropiedadEntidad = "FechaActualizacion"
        Me.txtFechaActualizacion.ForeColorFocus = System.Drawing.Color.Red
        Me.txtFechaActualizacion.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtFechaActualizacion.Formato = "dd/MM/yyyy HH:mm"
        Me.txtFechaActualizacion.IsDecimal = False
        Me.txtFechaActualizacion.IsNumber = False
        Me.txtFechaActualizacion.IsPK = False
        Me.txtFechaActualizacion.IsRequired = False
        Me.txtFechaActualizacion.Key = ""
        Me.txtFechaActualizacion.LabelAsoc = Nothing
        Me.txtFechaActualizacion.Location = New System.Drawing.Point(461, 3)
        Me.txtFechaActualizacion.Name = "txtFechaActualizacion"
        Me.txtFechaActualizacion.ReadOnly = True
        Me.txtFechaActualizacion.Size = New System.Drawing.Size(120, 20)
        Me.txtFechaActualizacion.TabIndex = 5
        '
        'txtIdUsuarioActualizacion
        '
        Me.txtIdUsuarioActualizacion.BindearPropiedadControl = "Text"
        Me.txtIdUsuarioActualizacion.BindearPropiedadEntidad = "IdUsuarioActualizacion"
        Me.txtIdUsuarioActualizacion.ForeColorFocus = System.Drawing.Color.Red
        Me.txtIdUsuarioActualizacion.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtIdUsuarioActualizacion.Formato = ""
        Me.txtIdUsuarioActualizacion.IsDecimal = False
        Me.txtIdUsuarioActualizacion.IsNumber = False
        Me.txtIdUsuarioActualizacion.IsPK = False
        Me.txtIdUsuarioActualizacion.IsRequired = False
        Me.txtIdUsuarioActualizacion.Key = ""
        Me.txtIdUsuarioActualizacion.LabelAsoc = Nothing
        Me.txtIdUsuarioActualizacion.Location = New System.Drawing.Point(355, 3)
        Me.txtIdUsuarioActualizacion.Name = "txtIdUsuarioActualizacion"
        Me.txtIdUsuarioActualizacion.ReadOnly = True
        Me.txtIdUsuarioActualizacion.Size = New System.Drawing.Size(100, 20)
        Me.txtIdUsuarioActualizacion.TabIndex = 4
        '
        'lblActualizacion
        '
        Me.lblActualizacion.AutoSize = True
        Me.lblActualizacion.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblActualizacion.LabelAsoc = Nothing
        Me.lblActualizacion.Location = New System.Drawing.Point(279, 7)
        Me.lblActualizacion.Name = "lblActualizacion"
        Me.lblActualizacion.Size = New System.Drawing.Size(70, 13)
        Me.lblActualizacion.TabIndex = 3
        Me.lblActualizacion.Text = "Actualización"
        '
        'txtFechaAlta
        '
        Me.txtFechaAlta.BindearPropiedadControl = "Text"
        Me.txtFechaAlta.BindearPropiedadEntidad = "FechaAlta"
        Me.txtFechaAlta.ForeColorFocus = System.Drawing.Color.Red
        Me.txtFechaAlta.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtFechaAlta.Formato = "dd/MM/yyyy HH:mm"
        Me.txtFechaAlta.IsDecimal = False
        Me.txtFechaAlta.IsNumber = False
        Me.txtFechaAlta.IsPK = False
        Me.txtFechaAlta.IsRequired = False
        Me.txtFechaAlta.Key = ""
        Me.txtFechaAlta.LabelAsoc = Nothing
        Me.txtFechaAlta.Location = New System.Drawing.Point(146, 3)
        Me.txtFechaAlta.Name = "txtFechaAlta"
        Me.txtFechaAlta.ReadOnly = True
        Me.txtFechaAlta.Size = New System.Drawing.Size(120, 20)
        Me.txtFechaAlta.TabIndex = 2
        '
        'txtIdUsuarioAlta
        '
        Me.txtIdUsuarioAlta.BindearPropiedadControl = "Text"
        Me.txtIdUsuarioAlta.BindearPropiedadEntidad = "IdUsuarioAlta"
        Me.txtIdUsuarioAlta.ForeColorFocus = System.Drawing.Color.Red
        Me.txtIdUsuarioAlta.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtIdUsuarioAlta.Formato = ""
        Me.txtIdUsuarioAlta.IsDecimal = False
        Me.txtIdUsuarioAlta.IsNumber = False
        Me.txtIdUsuarioAlta.IsPK = False
        Me.txtIdUsuarioAlta.IsRequired = False
        Me.txtIdUsuarioAlta.Key = ""
        Me.txtIdUsuarioAlta.LabelAsoc = Nothing
        Me.txtIdUsuarioAlta.Location = New System.Drawing.Point(40, 3)
        Me.txtIdUsuarioAlta.Name = "txtIdUsuarioAlta"
        Me.txtIdUsuarioAlta.ReadOnly = True
        Me.txtIdUsuarioAlta.Size = New System.Drawing.Size(100, 20)
        Me.txtIdUsuarioAlta.TabIndex = 1
        '
        'lblAlta
        '
        Me.lblAlta.AutoSize = True
        Me.lblAlta.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblAlta.LabelAsoc = Nothing
        Me.lblAlta.Location = New System.Drawing.Point(9, 7)
        Me.lblAlta.Name = "lblAlta"
        Me.lblAlta.Size = New System.Drawing.Size(25, 13)
        Me.lblAlta.TabIndex = 0
        Me.lblAlta.Text = "Alta"
        '
        'CRMCiclosPlanificacionDetalle
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(593, 180)
        Me.Controls.Add(Me.pnlUsuarios)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.lblFechaFinalizacion)
        Me.Controls.Add(Me.lblFechaCierre)
        Me.Controls.Add(Me.lblFechaInicio)
        Me.Controls.Add(Me.dtpFechaFinalizacion)
        Me.Controls.Add(Me.dtpFechaCierre)
        Me.Controls.Add(Me.dtpFechaInicio)
        Me.Controls.Add(Me.cmbEstadoCicloPlanificacion)
        Me.Controls.Add(Me.lblNombre)
        Me.Controls.Add(Me.txtNombreCicloPlanificacion)
        Me.Controls.Add(Me.lblEstadoCicloPlanificacion)
        Me.Controls.Add(Me.lblCodigo)
        Me.Controls.Add(Me.txtIdCicloPlanificacion)
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "CRMCiclosPlanificacionDetalle"
        Me.Text = "Ciclo Planificación"
        Me.Panel1.ResumeLayout(False)
        Me.pnlUsuarios.ResumeLayout(False)
        Me.pnlUsuarios.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cmbEstadoCicloPlanificacion As Eniac.Controles.ComboBox
   Friend WithEvents lblNombre As Eniac.Controles.Label
   Friend WithEvents txtNombreCicloPlanificacion As Eniac.Controles.TextBox
   Friend WithEvents lblEstadoCicloPlanificacion As Eniac.Controles.Label
    Friend WithEvents lblCodigo As Eniac.Controles.Label
    Friend WithEvents txtIdCicloPlanificacion As Eniac.Controles.TextBox
    Friend WithEvents cdColor As System.Windows.Forms.ColorDialog
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents lblFechaInicio As Controles.Label
    Friend WithEvents dtpFechaInicio As Controles.DateTimePicker
    Friend WithEvents dtpFechaCierre As Controles.DateTimePicker
    Friend WithEvents lblFechaCierre As Controles.Label
    Friend WithEvents dtpFechaFinalizacion As Controles.DateTimePicker
    Friend WithEvents lblFechaFinalizacion As Controles.Label
    Friend WithEvents Panel1 As Panel
    Friend WithEvents pnlUsuarios As Panel
    Friend WithEvents txtFechaActualizacion As Controles.TextBox
    Friend WithEvents txtIdUsuarioActualizacion As Controles.TextBox
    Friend WithEvents lblActualizacion As Controles.Label
    Friend WithEvents txtFechaAlta As Controles.TextBox
    Friend WithEvents txtIdUsuarioAlta As Controles.TextBox
    Friend WithEvents lblAlta As Controles.Label
End Class
