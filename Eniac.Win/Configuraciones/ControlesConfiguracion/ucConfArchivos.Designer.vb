<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ucConfArchivos
   Inherits ucConfBase

   'UserControl overrides dispose to clean up the component list.
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
        Me.lblAbrirArchivoExportado = New Eniac.Controles.Label()
        Me.cmbAbrirArchivoExportado = New Eniac.Controles.ComboBox()
        Me.chbPoliticasSeguridadClaves = New Eniac.Controles.CheckBox()
        Me.lblTamañoMaximoImagenes = New Eniac.Controles.Label()
        Me.chbEmpleadoUtilizaGeolocalizacion = New Eniac.Controles.CheckBox()
        Me.txtTamañoMaximoImagenes = New Eniac.Controles.TextBox()
        Me.SuspendLayout()
        '
        'lblAbrirArchivoExportado
        '
        Me.lblAbrirArchivoExportado.AutoSize = True
        Me.lblAbrirArchivoExportado.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblAbrirArchivoExportado.LabelAsoc = Nothing
        Me.lblAbrirArchivoExportado.Location = New System.Drawing.Point(4, 372)
        Me.lblAbrirArchivoExportado.Name = "lblAbrirArchivoExportado"
        Me.lblAbrirArchivoExportado.Size = New System.Drawing.Size(130, 13)
        Me.lblAbrirArchivoExportado.TabIndex = 73
        Me.lblAbrirArchivoExportado.Text = "Al Exportar abrir el archivo"
        '
        'cmbAbrirArchivoExportado
        '
        Me.cmbAbrirArchivoExportado.BindearPropiedadControl = Nothing
        Me.cmbAbrirArchivoExportado.BindearPropiedadEntidad = Nothing
        Me.cmbAbrirArchivoExportado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbAbrirArchivoExportado.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbAbrirArchivoExportado.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbAbrirArchivoExportado.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbAbrirArchivoExportado.FormattingEnabled = True
        Me.cmbAbrirArchivoExportado.IsPK = False
        Me.cmbAbrirArchivoExportado.IsRequired = False
        Me.cmbAbrirArchivoExportado.Key = Nothing
        Me.cmbAbrirArchivoExportado.LabelAsoc = Me.lblAbrirArchivoExportado
        Me.cmbAbrirArchivoExportado.Location = New System.Drawing.Point(140, 368)
        Me.cmbAbrirArchivoExportado.Name = "cmbAbrirArchivoExportado"
        Me.cmbAbrirArchivoExportado.Size = New System.Drawing.Size(243, 21)
        Me.cmbAbrirArchivoExportado.TabIndex = 74
        Me.cmbAbrirArchivoExportado.Tag = ""
        '
        'chbPoliticasSeguridadClaves
        '
        Me.chbPoliticasSeguridadClaves.BindearPropiedadControl = Nothing
        Me.chbPoliticasSeguridadClaves.BindearPropiedadEntidad = Nothing
        Me.chbPoliticasSeguridadClaves.ForeColorFocus = System.Drawing.Color.Red
        Me.chbPoliticasSeguridadClaves.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbPoliticasSeguridadClaves.IsPK = False
        Me.chbPoliticasSeguridadClaves.IsRequired = False
        Me.chbPoliticasSeguridadClaves.Key = Nothing
        Me.chbPoliticasSeguridadClaves.LabelAsoc = Nothing
        Me.chbPoliticasSeguridadClaves.Location = New System.Drawing.Point(7, 109)
        Me.chbPoliticasSeguridadClaves.Name = "chbPoliticasSeguridadClaves"
        Me.chbPoliticasSeguridadClaves.Size = New System.Drawing.Size(228, 27)
        Me.chbPoliticasSeguridadClaves.TabIndex = 70
        Me.chbPoliticasSeguridadClaves.Tag = "POLITICASSEGURIDADCLAVES"
        Me.chbPoliticasSeguridadClaves.Text = "Politicas de Seguridad en las Claves"
        Me.chbPoliticasSeguridadClaves.UseVisualStyleBackColor = True
        '
        'lblTamañoMaximoImagenes
        '
        Me.lblTamañoMaximoImagenes.AutoSize = True
        Me.lblTamañoMaximoImagenes.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblTamañoMaximoImagenes.LabelAsoc = Nothing
        Me.lblTamañoMaximoImagenes.Location = New System.Drawing.Point(77, 50)
        Me.lblTamañoMaximoImagenes.Name = "lblTamañoMaximoImagenes"
        Me.lblTamañoMaximoImagenes.Size = New System.Drawing.Size(198, 13)
        Me.lblTamañoMaximoImagenes.TabIndex = 68
        Me.lblTamañoMaximoImagenes.Text = "Tamaño máximo de Imagenes (en Bytes)"
        '
        'chbEmpleadoUtilizaGeolocalizacion
        '
        Me.chbEmpleadoUtilizaGeolocalizacion.BindearPropiedadControl = Nothing
        Me.chbEmpleadoUtilizaGeolocalizacion.BindearPropiedadEntidad = Nothing
        Me.chbEmpleadoUtilizaGeolocalizacion.ForeColorFocus = System.Drawing.Color.Red
        Me.chbEmpleadoUtilizaGeolocalizacion.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbEmpleadoUtilizaGeolocalizacion.IsPK = False
        Me.chbEmpleadoUtilizaGeolocalizacion.IsRequired = False
        Me.chbEmpleadoUtilizaGeolocalizacion.Key = Nothing
        Me.chbEmpleadoUtilizaGeolocalizacion.LabelAsoc = Nothing
        Me.chbEmpleadoUtilizaGeolocalizacion.Location = New System.Drawing.Point(7, 75)
        Me.chbEmpleadoUtilizaGeolocalizacion.Name = "chbEmpleadoUtilizaGeolocalizacion"
        Me.chbEmpleadoUtilizaGeolocalizacion.Size = New System.Drawing.Size(202, 28)
        Me.chbEmpleadoUtilizaGeolocalizacion.TabIndex = 69
        Me.chbEmpleadoUtilizaGeolocalizacion.Tag = "EMPLEADOUTILIZAGEOLOCALIZACION"
        Me.chbEmpleadoUtilizaGeolocalizacion.Text = "Empleado Utiliza Geolocalización"
        Me.chbEmpleadoUtilizaGeolocalizacion.UseVisualStyleBackColor = True
        '
        'txtTamañoMaximoImagenes
        '
        Me.txtTamañoMaximoImagenes.BindearPropiedadControl = Nothing
        Me.txtTamañoMaximoImagenes.BindearPropiedadEntidad = Nothing
        Me.txtTamañoMaximoImagenes.ForeColorFocus = System.Drawing.Color.Red
        Me.txtTamañoMaximoImagenes.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtTamañoMaximoImagenes.Formato = ""
        Me.txtTamañoMaximoImagenes.IsDecimal = False
        Me.txtTamañoMaximoImagenes.IsNumber = True
        Me.txtTamañoMaximoImagenes.IsPK = False
        Me.txtTamañoMaximoImagenes.IsRequired = False
        Me.txtTamañoMaximoImagenes.Key = ""
        Me.txtTamañoMaximoImagenes.LabelAsoc = Me.lblTamañoMaximoImagenes
        Me.txtTamañoMaximoImagenes.Location = New System.Drawing.Point(7, 46)
        Me.txtTamañoMaximoImagenes.MaxLength = 11
        Me.txtTamañoMaximoImagenes.Name = "txtTamañoMaximoImagenes"
        Me.txtTamañoMaximoImagenes.Size = New System.Drawing.Size(62, 20)
        Me.txtTamañoMaximoImagenes.TabIndex = 67
        Me.txtTamañoMaximoImagenes.Tag = "TAMAÑOMAXIMOIMAGENES"
        Me.txtTamañoMaximoImagenes.Text = "400000"
        Me.txtTamañoMaximoImagenes.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'ucConfArchivos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.lblAbrirArchivoExportado)
        Me.Controls.Add(Me.cmbAbrirArchivoExportado)
        Me.Controls.Add(Me.chbPoliticasSeguridadClaves)
        Me.Controls.Add(Me.lblTamañoMaximoImagenes)
        Me.Controls.Add(Me.chbEmpleadoUtilizaGeolocalizacion)
        Me.Controls.Add(Me.txtTamañoMaximoImagenes)
        Me.Name = "ucConfArchivos"
        Me.Controls.SetChildIndex(Me.txtTamañoMaximoImagenes, 0)
        Me.Controls.SetChildIndex(Me.chbEmpleadoUtilizaGeolocalizacion, 0)
        Me.Controls.SetChildIndex(Me.lblTamañoMaximoImagenes, 0)
        Me.Controls.SetChildIndex(Me.chbPoliticasSeguridadClaves, 0)
        Me.Controls.SetChildIndex(Me.cmbAbrirArchivoExportado, 0)
        Me.Controls.SetChildIndex(Me.lblAbrirArchivoExportado, 0)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents lblAbrirArchivoExportado As Controles.Label
   Friend WithEvents cmbAbrirArchivoExportado As Controles.ComboBox
	Friend WithEvents chbPoliticasSeguridadClaves As Controles.CheckBox
	Friend WithEvents lblTamañoMaximoImagenes As Controles.Label
	Friend WithEvents chbEmpleadoUtilizaGeolocalizacion As Controles.CheckBox
	Friend WithEvents txtTamañoMaximoImagenes As Controles.TextBox
End Class
