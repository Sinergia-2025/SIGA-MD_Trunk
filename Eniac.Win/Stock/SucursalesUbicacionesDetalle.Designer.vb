<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SucursalesUbicacionesDetalle
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
        Me.gpbDepositos = New System.Windows.Forms.GroupBox()
        Me.cmbEstadosUbicaciones = New Eniac.Controles.ComboBox()
        Me.Label2 = New Eniac.Controles.Label()
        Me.cmbDepositos = New Eniac.Controles.ComboBox()
        Me.Label1 = New Eniac.Controles.Label()
        Me.chbActivo = New Eniac.Controles.CheckBox()
        Me.cmbSucursales = New Eniac.Controles.ComboBox()
        Me.lblSucursalDeposito = New Eniac.Controles.Label()
        Me.lblCodigoDeposito = New Eniac.Controles.Label()
        Me.txtCodigoUbicacion = New Eniac.Controles.TextBox()
        Me.txtNombreUbicacion = New Eniac.Controles.TextBox()
        Me.lblNombreDeposito = New Eniac.Controles.Label()
        Me.gpbDepositos.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnAceptar
        '
        Me.btnAceptar.Location = New System.Drawing.Point(247, 189)
        Me.btnAceptar.TabIndex = 1
        '
        'btnCancelar
        '
        Me.btnCancelar.Location = New System.Drawing.Point(333, 189)
        '
        'btnCopiar
        '
        Me.btnCopiar.Location = New System.Drawing.Point(146, 189)
        Me.btnCopiar.TabIndex = 4
        '
        'btnAplicar
        '
        Me.btnAplicar.Location = New System.Drawing.Point(89, 189)
        Me.btnAplicar.TabIndex = 3
        '
        'gpbDepositos
        '
        Me.gpbDepositos.Controls.Add(Me.cmbEstadosUbicaciones)
        Me.gpbDepositos.Controls.Add(Me.Label2)
        Me.gpbDepositos.Controls.Add(Me.cmbDepositos)
        Me.gpbDepositos.Controls.Add(Me.Label1)
        Me.gpbDepositos.Controls.Add(Me.chbActivo)
        Me.gpbDepositos.Controls.Add(Me.cmbSucursales)
        Me.gpbDepositos.Controls.Add(Me.lblSucursalDeposito)
        Me.gpbDepositos.Controls.Add(Me.lblCodigoDeposito)
        Me.gpbDepositos.Controls.Add(Me.txtCodigoUbicacion)
        Me.gpbDepositos.Controls.Add(Me.txtNombreUbicacion)
        Me.gpbDepositos.Controls.Add(Me.lblNombreDeposito)
        Me.gpbDepositos.Location = New System.Drawing.Point(12, 12)
        Me.gpbDepositos.Name = "gpbDepositos"
        Me.gpbDepositos.Size = New System.Drawing.Size(400, 164)
        Me.gpbDepositos.TabIndex = 0
        Me.gpbDepositos.TabStop = False
        Me.gpbDepositos.Text = "Ubicaciones"
        '
        'cmbEstadosUbicaciones
        '
        Me.cmbEstadosUbicaciones.BindearPropiedadControl = "SelectedValue"
        Me.cmbEstadosUbicaciones.BindearPropiedadEntidad = "EstadoUbicacion"
        Me.cmbEstadosUbicaciones.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbEstadosUbicaciones.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbEstadosUbicaciones.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbEstadosUbicaciones.FormattingEnabled = True
        Me.cmbEstadosUbicaciones.IsPK = False
        Me.cmbEstadosUbicaciones.IsRequired = False
        Me.cmbEstadosUbicaciones.Key = Nothing
        Me.cmbEstadosUbicaciones.LabelAsoc = Me.Label2
        Me.cmbEstadosUbicaciones.Location = New System.Drawing.Point(80, 126)
        Me.cmbEstadosUbicaciones.Name = "cmbEstadosUbicaciones"
        Me.cmbEstadosUbicaciones.Size = New System.Drawing.Size(198, 21)
        Me.cmbEstadosUbicaciones.TabIndex = 9
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.LabelAsoc = Nothing
        Me.Label2.Location = New System.Drawing.Point(26, 129)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(40, 13)
        Me.Label2.TabIndex = 8
        Me.Label2.Text = "Estado"
        '
        'cmbDepositos
        '
        Me.cmbDepositos.BindearPropiedadControl = "SelectedValue"
        Me.cmbDepositos.BindearPropiedadEntidad = "IdDeposito"
        Me.cmbDepositos.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbDepositos.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbDepositos.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbDepositos.FormattingEnabled = True
        Me.cmbDepositos.IsPK = True
        Me.cmbDepositos.IsRequired = False
        Me.cmbDepositos.Key = Nothing
        Me.cmbDepositos.LabelAsoc = Me.Label1
        Me.cmbDepositos.Location = New System.Drawing.Point(80, 47)
        Me.cmbDepositos.Name = "cmbDepositos"
        Me.cmbDepositos.Size = New System.Drawing.Size(198, 21)
        Me.cmbDepositos.TabIndex = 3
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.LabelAsoc = Nothing
        Me.Label1.Location = New System.Drawing.Point(26, 50)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(49, 13)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Depósito"
        '
        'chbActivo
        '
        Me.chbActivo.AutoSize = True
        Me.chbActivo.BindearPropiedadControl = "Checked"
        Me.chbActivo.BindearPropiedadEntidad = "Activo"
        Me.chbActivo.ForeColorFocus = System.Drawing.Color.Red
        Me.chbActivo.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbActivo.IsPK = False
        Me.chbActivo.IsRequired = False
        Me.chbActivo.Key = Nothing
        Me.chbActivo.LabelAsoc = Nothing
        Me.chbActivo.Location = New System.Drawing.Point(321, 22)
        Me.chbActivo.Name = "chbActivo"
        Me.chbActivo.Size = New System.Drawing.Size(56, 17)
        Me.chbActivo.TabIndex = 10
        Me.chbActivo.Text = "Activa"
        Me.chbActivo.UseVisualStyleBackColor = True
        '
        'cmbSucursales
        '
        Me.cmbSucursales.BindearPropiedadControl = "SelectedValue"
        Me.cmbSucursales.BindearPropiedadEntidad = "IdSucursal"
        Me.cmbSucursales.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbSucursales.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbSucursales.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbSucursales.FormattingEnabled = True
        Me.cmbSucursales.IsPK = True
        Me.cmbSucursales.IsRequired = False
        Me.cmbSucursales.Key = Nothing
        Me.cmbSucursales.LabelAsoc = Me.lblSucursalDeposito
        Me.cmbSucursales.Location = New System.Drawing.Point(80, 20)
        Me.cmbSucursales.Name = "cmbSucursales"
        Me.cmbSucursales.Size = New System.Drawing.Size(198, 21)
        Me.cmbSucursales.TabIndex = 1
        '
        'lblSucursalDeposito
        '
        Me.lblSucursalDeposito.AutoSize = True
        Me.lblSucursalDeposito.LabelAsoc = Nothing
        Me.lblSucursalDeposito.Location = New System.Drawing.Point(26, 23)
        Me.lblSucursalDeposito.Name = "lblSucursalDeposito"
        Me.lblSucursalDeposito.Size = New System.Drawing.Size(48, 13)
        Me.lblSucursalDeposito.TabIndex = 0
        Me.lblSucursalDeposito.Text = "Sucursal"
        '
        'lblCodigoDeposito
        '
        Me.lblCodigoDeposito.AutoSize = True
        Me.lblCodigoDeposito.LabelAsoc = Nothing
        Me.lblCodigoDeposito.Location = New System.Drawing.Point(26, 78)
        Me.lblCodigoDeposito.Name = "lblCodigoDeposito"
        Me.lblCodigoDeposito.Size = New System.Drawing.Size(40, 13)
        Me.lblCodigoDeposito.TabIndex = 4
        Me.lblCodigoDeposito.Text = "Código"
        '
        'txtCodigoUbicacion
        '
        Me.txtCodigoUbicacion.BindearPropiedadControl = "Text"
        Me.txtCodigoUbicacion.BindearPropiedadEntidad = "CodigoUbicacion"
        Me.txtCodigoUbicacion.ForeColorFocus = System.Drawing.Color.Red
        Me.txtCodigoUbicacion.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtCodigoUbicacion.Formato = ""
        Me.txtCodigoUbicacion.IsDecimal = False
        Me.txtCodigoUbicacion.IsNumber = False
        Me.txtCodigoUbicacion.IsPK = True
        Me.txtCodigoUbicacion.IsRequired = True
        Me.txtCodigoUbicacion.Key = ""
        Me.txtCodigoUbicacion.LabelAsoc = Me.lblCodigoDeposito
        Me.txtCodigoUbicacion.Location = New System.Drawing.Point(80, 74)
        Me.txtCodigoUbicacion.MaxLength = 30
        Me.txtCodigoUbicacion.Name = "txtCodigoUbicacion"
        Me.txtCodigoUbicacion.Size = New System.Drawing.Size(110, 20)
        Me.txtCodigoUbicacion.TabIndex = 5
        '
        'txtNombreUbicacion
        '
        Me.txtNombreUbicacion.BindearPropiedadControl = "Text"
        Me.txtNombreUbicacion.BindearPropiedadEntidad = "NombreUbicacion"
        Me.txtNombreUbicacion.ForeColorFocus = System.Drawing.Color.Red
        Me.txtNombreUbicacion.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtNombreUbicacion.Formato = ""
        Me.txtNombreUbicacion.IsDecimal = False
        Me.txtNombreUbicacion.IsNumber = False
        Me.txtNombreUbicacion.IsPK = False
        Me.txtNombreUbicacion.IsRequired = True
        Me.txtNombreUbicacion.Key = ""
        Me.txtNombreUbicacion.LabelAsoc = Me.lblNombreDeposito
        Me.txtNombreUbicacion.Location = New System.Drawing.Point(80, 100)
        Me.txtNombreUbicacion.MaxLength = 50
        Me.txtNombreUbicacion.Name = "txtNombreUbicacion"
        Me.txtNombreUbicacion.Size = New System.Drawing.Size(297, 20)
        Me.txtNombreUbicacion.TabIndex = 7
        '
        'lblNombreDeposito
        '
        Me.lblNombreDeposito.AutoSize = True
        Me.lblNombreDeposito.LabelAsoc = Nothing
        Me.lblNombreDeposito.Location = New System.Drawing.Point(26, 103)
        Me.lblNombreDeposito.Name = "lblNombreDeposito"
        Me.lblNombreDeposito.Size = New System.Drawing.Size(44, 13)
        Me.lblNombreDeposito.TabIndex = 6
        Me.lblNombreDeposito.Text = "Nombre"
        '
        'SucursalesUbicacionesDetalle
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(422, 224)
        Me.Controls.Add(Me.gpbDepositos)
        Me.Name = "SucursalesUbicacionesDetalle"
        Me.Text = "Sucursales Ubicaciones Detalle"
        Me.Controls.SetChildIndex(Me.btnCancelar, 0)
        Me.Controls.SetChildIndex(Me.btnAceptar, 0)
        Me.Controls.SetChildIndex(Me.btnCopiar, 0)
        Me.Controls.SetChildIndex(Me.btnAplicar, 0)
        Me.Controls.SetChildIndex(Me.gpbDepositos, 0)
        Me.gpbDepositos.ResumeLayout(False)
        Me.gpbDepositos.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents gpbDepositos As GroupBox
    Friend WithEvents chbActivo As Controles.CheckBox
    Friend WithEvents cmbSucursales As Controles.ComboBox
    Friend WithEvents lblSucursalDeposito As Controles.Label
    Friend WithEvents lblCodigoDeposito As Controles.Label
    Friend WithEvents txtCodigoUbicacion As Controles.TextBox
    Friend WithEvents txtNombreUbicacion As Controles.TextBox
    Friend WithEvents lblNombreDeposito As Controles.Label
    Friend WithEvents cmbEstadosUbicaciones As Controles.ComboBox
    Friend WithEvents Label2 As Controles.Label
    Friend WithEvents cmbDepositos As Controles.ComboBox
    Friend WithEvents Label1 As Controles.Label
End Class
