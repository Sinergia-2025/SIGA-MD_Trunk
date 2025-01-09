<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class VersionesDetalle
   Inherits BaseDetalle

   'Form reemplaza a Dispose para limpiar la lista de componentes.
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

   'Requerido por el Diseñador de Windows Forms
   Private components As System.ComponentModel.IContainer

   'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
   'Se puede modificar usando el Diseñador de Windows Forms.  
   'No lo modifique con el editor de código.
   <System.Diagnostics.DebuggerStepThrough()> _
   Private Sub InitializeComponent()
      Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(VersionesDetalle))
      Me.txtVersion = New Eniac.Controles.TextBox()
      Me.lblNombre = New Eniac.Controles.Label()
      Me.lblCodigo = New Eniac.Controles.Label()
      Me.Label1 = New Eniac.Controles.Label()
      Me.cmbAplicacionBase = New Eniac.Controles.ComboBox()
      Me.btnLimpiar = New System.Windows.Forms.Button()
      Me.cmbAplicacion = New Eniac.Controles.ComboBox()
      Me.txtVersionApBase = New Eniac.Controles.TextBox()
      Me.Label2 = New Eniac.Controles.Label()
      Me.txtVersionReport = New Eniac.Controles.TextBox()
      Me.Label3 = New Eniac.Controles.Label()
      Me.txtVersionFramework = New Eniac.Controles.TextBox()
      Me.Label4 = New Eniac.Controles.Label()
      Me.txtVersionLenguaje = New Eniac.Controles.TextBox()
      Me.Label5 = New Eniac.Controles.Label()
      Me.Label6 = New Eniac.Controles.Label()
      Me.dtpFechaVersion = New Eniac.Controles.DateTimePicker()
      Me.SuspendLayout()
      '
      'btnAceptar
      '
      Me.btnAceptar.Location = New System.Drawing.Point(262, 187)
      Me.btnAceptar.TabIndex = 17
      '
      'btnCancelar
      '
      Me.btnCancelar.Location = New System.Drawing.Point(348, 187)
      Me.btnCancelar.TabIndex = 18
      '
      'btnCopiar
      '
      Me.btnCopiar.Location = New System.Drawing.Point(179, 289)
      '
      'btnAplicar
      '
      Me.btnAplicar.Location = New System.Drawing.Point(122, 289)
      '
      'txtVersion
      '
      Me.txtVersion.BindearPropiedadControl = "Text"
      Me.txtVersion.BindearPropiedadEntidad = "NroVersion"
      Me.txtVersion.ForeColorFocus = System.Drawing.Color.Red
      Me.txtVersion.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtVersion.Formato = ""
      Me.txtVersion.IsDecimal = False
      Me.txtVersion.IsNumber = False
      Me.txtVersion.IsPK = True
      Me.txtVersion.IsRequired = True
      Me.txtVersion.Key = ""
      Me.txtVersion.LabelAsoc = Me.lblNombre
      Me.txtVersion.Location = New System.Drawing.Point(79, 49)
      Me.txtVersion.MaxLength = 40
      Me.txtVersion.Name = "txtVersion"
      Me.txtVersion.Size = New System.Drawing.Size(120, 20)
      Me.txtVersion.TabIndex = 3
      '
      'lblNombre
      '
      Me.lblNombre.AccessibleRole = System.Windows.Forms.AccessibleRole.None
      Me.lblNombre.AutoSize = True
      Me.lblNombre.Location = New System.Drawing.Point(17, 53)
      Me.lblNombre.Name = "lblNombre"
      Me.lblNombre.Size = New System.Drawing.Size(42, 13)
      Me.lblNombre.TabIndex = 2
      Me.lblNombre.Text = "Versión"
      '
      'lblCodigo
      '
      Me.lblCodigo.AutoSize = True
      Me.lblCodigo.Location = New System.Drawing.Point(17, 21)
      Me.lblCodigo.Name = "lblCodigo"
      Me.lblCodigo.Size = New System.Drawing.Size(56, 13)
      Me.lblCodigo.TabIndex = 0
      Me.lblCodigo.Text = "Aplicación"
      '
      'Label1
      '
      Me.Label1.AutoSize = True
      Me.Label1.Location = New System.Drawing.Point(17, 84)
      Me.Label1.Name = "Label1"
      Me.Label1.Size = New System.Drawing.Size(50, 13)
      Me.Label1.TabIndex = 6
      Me.Label1.Text = "Ap. Base"
      '
      'cmbAplicacionBase
      '
      Me.cmbAplicacionBase.BindearPropiedadControl = "SelectedValue"
      Me.cmbAplicacionBase.BindearPropiedadEntidad = "IdAplicacionBase"
      Me.cmbAplicacionBase.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cmbAplicacionBase.ForeColorFocus = System.Drawing.Color.Red
      Me.cmbAplicacionBase.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.cmbAplicacionBase.FormattingEnabled = True
      Me.cmbAplicacionBase.IsPK = False
      Me.cmbAplicacionBase.IsRequired = False
      Me.cmbAplicacionBase.Key = Nothing
      Me.cmbAplicacionBase.LabelAsoc = Nothing
      Me.cmbAplicacionBase.Location = New System.Drawing.Point(79, 81)
      Me.cmbAplicacionBase.Name = "cmbAplicacionBase"
      Me.cmbAplicacionBase.Size = New System.Drawing.Size(120, 21)
      Me.cmbAplicacionBase.TabIndex = 7
      '
      'btnLimpiar
      '
      Me.btnLimpiar.Image = Global.Eniac.Win.My.Resources.Resources.refresh_24
      Me.btnLimpiar.Location = New System.Drawing.Point(205, 79)
      Me.btnLimpiar.Name = "btnLimpiar"
      Me.btnLimpiar.Size = New System.Drawing.Size(26, 26)
      Me.btnLimpiar.TabIndex = 8
      Me.btnLimpiar.UseVisualStyleBackColor = True
      '
      'cmbAplicacion
      '
      Me.cmbAplicacion.BindearPropiedadControl = "SelectedValue"
      Me.cmbAplicacion.BindearPropiedadEntidad = "IdAplicacion"
      Me.cmbAplicacion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cmbAplicacion.ForeColorFocus = System.Drawing.Color.Red
      Me.cmbAplicacion.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.cmbAplicacion.FormattingEnabled = True
      Me.cmbAplicacion.IsPK = True
      Me.cmbAplicacion.IsRequired = True
      Me.cmbAplicacion.Key = Nothing
      Me.cmbAplicacion.LabelAsoc = Nothing
      Me.cmbAplicacion.Location = New System.Drawing.Point(79, 16)
      Me.cmbAplicacion.Name = "cmbAplicacion"
      Me.cmbAplicacion.Size = New System.Drawing.Size(120, 21)
      Me.cmbAplicacion.TabIndex = 1
      '
      'txtVersionApBase
      '
      Me.txtVersionApBase.BindearPropiedadControl = "Text"
      Me.txtVersionApBase.BindearPropiedadEntidad = "NroVersionAplicacionBase"
      Me.txtVersionApBase.ForeColorFocus = System.Drawing.Color.Red
      Me.txtVersionApBase.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtVersionApBase.Formato = ""
      Me.txtVersionApBase.IsDecimal = False
      Me.txtVersionApBase.IsNumber = False
      Me.txtVersionApBase.IsPK = False
      Me.txtVersionApBase.IsRequired = False
      Me.txtVersionApBase.Key = ""
      Me.txtVersionApBase.LabelAsoc = Me.Label2
      Me.txtVersionApBase.Location = New System.Drawing.Point(333, 82)
      Me.txtVersionApBase.MaxLength = 40
      Me.txtVersionApBase.Name = "txtVersionApBase"
      Me.txtVersionApBase.Size = New System.Drawing.Size(95, 20)
      Me.txtVersionApBase.TabIndex = 10
      '
      'Label2
      '
      Me.Label2.AccessibleRole = System.Windows.Forms.AccessibleRole.None
      Me.Label2.AutoSize = True
      Me.Label2.Location = New System.Drawing.Point(239, 84)
      Me.Label2.Name = "Label2"
      Me.Label2.Size = New System.Drawing.Size(88, 13)
      Me.Label2.TabIndex = 9
      Me.Label2.Text = "Versión Ap. Base"
      '
      'txtVersionReport
      '
      Me.txtVersionReport.BindearPropiedadControl = "Text"
      Me.txtVersionReport.BindearPropiedadEntidad = "VersionReportViewer"
      Me.txtVersionReport.ForeColorFocus = System.Drawing.Color.Red
      Me.txtVersionReport.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtVersionReport.Formato = ""
      Me.txtVersionReport.IsDecimal = False
      Me.txtVersionReport.IsNumber = False
      Me.txtVersionReport.IsPK = False
      Me.txtVersionReport.IsRequired = True
      Me.txtVersionReport.Key = ""
      Me.txtVersionReport.LabelAsoc = Me.Label3
      Me.txtVersionReport.Location = New System.Drawing.Point(127, 137)
      Me.txtVersionReport.MaxLength = 40
      Me.txtVersionReport.Name = "txtVersionReport"
      Me.txtVersionReport.Size = New System.Drawing.Size(104, 20)
      Me.txtVersionReport.TabIndex = 14
      '
      'Label3
      '
      Me.Label3.AccessibleRole = System.Windows.Forms.AccessibleRole.None
      Me.Label3.AutoSize = True
      Me.Label3.Location = New System.Drawing.Point(17, 140)
      Me.Label3.Name = "Label3"
      Me.Label3.Size = New System.Drawing.Size(109, 13)
      Me.Label3.TabIndex = 13
      Me.Label3.Text = "Versión ReportViewer"
      '
      'txtVersionFramework
      '
      Me.txtVersionFramework.BindearPropiedadControl = "Text"
      Me.txtVersionFramework.BindearPropiedadEntidad = "VersionFramework"
      Me.txtVersionFramework.ForeColorFocus = System.Drawing.Color.Red
      Me.txtVersionFramework.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtVersionFramework.Formato = ""
      Me.txtVersionFramework.IsDecimal = False
      Me.txtVersionFramework.IsNumber = False
      Me.txtVersionFramework.IsPK = False
      Me.txtVersionFramework.IsRequired = True
      Me.txtVersionFramework.Key = ""
      Me.txtVersionFramework.LabelAsoc = Me.Label4
      Me.txtVersionFramework.Location = New System.Drawing.Point(127, 111)
      Me.txtVersionFramework.MaxLength = 40
      Me.txtVersionFramework.Name = "txtVersionFramework"
      Me.txtVersionFramework.Size = New System.Drawing.Size(104, 20)
      Me.txtVersionFramework.TabIndex = 12
      '
      'Label4
      '
      Me.Label4.AccessibleRole = System.Windows.Forms.AccessibleRole.None
      Me.Label4.AutoSize = True
      Me.Label4.Location = New System.Drawing.Point(17, 114)
      Me.Label4.Name = "Label4"
      Me.Label4.Size = New System.Drawing.Size(97, 13)
      Me.Label4.TabIndex = 11
      Me.Label4.Text = "Versión Framework"
      '
      'txtVersionLenguaje
      '
      Me.txtVersionLenguaje.BindearPropiedadControl = "Text"
      Me.txtVersionLenguaje.BindearPropiedadEntidad = "VersionLenguaje"
      Me.txtVersionLenguaje.ForeColorFocus = System.Drawing.Color.Red
      Me.txtVersionLenguaje.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtVersionLenguaje.Formato = ""
      Me.txtVersionLenguaje.IsDecimal = False
      Me.txtVersionLenguaje.IsNumber = False
      Me.txtVersionLenguaje.IsPK = False
      Me.txtVersionLenguaje.IsRequired = True
      Me.txtVersionLenguaje.Key = ""
      Me.txtVersionLenguaje.LabelAsoc = Me.Label5
      Me.txtVersionLenguaje.Location = New System.Drawing.Point(127, 163)
      Me.txtVersionLenguaje.MaxLength = 40
      Me.txtVersionLenguaje.Name = "txtVersionLenguaje"
      Me.txtVersionLenguaje.Size = New System.Drawing.Size(104, 20)
      Me.txtVersionLenguaje.TabIndex = 16
      '
      'Label5
      '
      Me.Label5.AccessibleRole = System.Windows.Forms.AccessibleRole.None
      Me.Label5.AutoSize = True
      Me.Label5.Location = New System.Drawing.Point(17, 166)
      Me.Label5.Name = "Label5"
      Me.Label5.Size = New System.Drawing.Size(89, 13)
      Me.Label5.TabIndex = 15
      Me.Label5.Text = "Versión Lenguaje"
      '
      'Label6
      '
      Me.Label6.AccessibleRole = System.Windows.Forms.AccessibleRole.None
      Me.Label6.AutoSize = True
      Me.Label6.Location = New System.Drawing.Point(217, 53)
      Me.Label6.Name = "Label6"
      Me.Label6.Size = New System.Drawing.Size(78, 13)
      Me.Label6.TabIndex = 4
      Me.Label6.Text = "Fecha Versión "
      '
      'dtpFechaVersion
      '
      Me.dtpFechaVersion.BindearPropiedadControl = "Value"
      Me.dtpFechaVersion.BindearPropiedadEntidad = "VersionFecha"
      Me.dtpFechaVersion.CustomFormat = "dd/MM/yyyy HH:mm"
      Me.dtpFechaVersion.ForeColorFocus = System.Drawing.Color.Red
      Me.dtpFechaVersion.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.dtpFechaVersion.Format = System.Windows.Forms.DateTimePickerFormat.Custom
      Me.dtpFechaVersion.IsPK = False
      Me.dtpFechaVersion.IsRequired = True
      Me.dtpFechaVersion.Key = ""
      Me.dtpFechaVersion.LabelAsoc = Nothing
      Me.dtpFechaVersion.Location = New System.Drawing.Point(301, 50)
      Me.dtpFechaVersion.Name = "dtpFechaVersion"
      Me.dtpFechaVersion.Size = New System.Drawing.Size(127, 20)
      Me.dtpFechaVersion.TabIndex = 5
      '
      'VersionesDetalle
      '
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.ClientSize = New System.Drawing.Size(440, 229)
      Me.Controls.Add(Me.dtpFechaVersion)
      Me.Controls.Add(Me.Label6)
      Me.Controls.Add(Me.txtVersionLenguaje)
      Me.Controls.Add(Me.Label5)
      Me.Controls.Add(Me.txtVersionFramework)
      Me.Controls.Add(Me.Label4)
      Me.Controls.Add(Me.txtVersionReport)
      Me.Controls.Add(Me.Label3)
      Me.Controls.Add(Me.txtVersionApBase)
      Me.Controls.Add(Me.Label2)
      Me.Controls.Add(Me.cmbAplicacion)
      Me.Controls.Add(Me.btnLimpiar)
      Me.Controls.Add(Me.cmbAplicacionBase)
      Me.Controls.Add(Me.Label1)
      Me.Controls.Add(Me.txtVersion)
      Me.Controls.Add(Me.lblNombre)
      Me.Controls.Add(Me.lblCodigo)
      Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
      Me.Name = "VersionesDetalle"
      Me.Text = "Versión"
      Me.Controls.SetChildIndex(Me.btnCopiar, 0)
      Me.Controls.SetChildIndex(Me.btnAplicar, 0)
      Me.Controls.SetChildIndex(Me.lblCodigo, 0)
      Me.Controls.SetChildIndex(Me.lblNombre, 0)
      Me.Controls.SetChildIndex(Me.btnAceptar, 0)
      Me.Controls.SetChildIndex(Me.btnCancelar, 0)
      Me.Controls.SetChildIndex(Me.txtVersion, 0)
      Me.Controls.SetChildIndex(Me.Label1, 0)
      Me.Controls.SetChildIndex(Me.cmbAplicacionBase, 0)
      Me.Controls.SetChildIndex(Me.btnLimpiar, 0)
      Me.Controls.SetChildIndex(Me.cmbAplicacion, 0)
      Me.Controls.SetChildIndex(Me.Label2, 0)
      Me.Controls.SetChildIndex(Me.txtVersionApBase, 0)
      Me.Controls.SetChildIndex(Me.Label3, 0)
      Me.Controls.SetChildIndex(Me.txtVersionReport, 0)
      Me.Controls.SetChildIndex(Me.Label4, 0)
      Me.Controls.SetChildIndex(Me.txtVersionFramework, 0)
      Me.Controls.SetChildIndex(Me.Label5, 0)
      Me.Controls.SetChildIndex(Me.txtVersionLenguaje, 0)
      Me.Controls.SetChildIndex(Me.Label6, 0)
      Me.Controls.SetChildIndex(Me.dtpFechaVersion, 0)
      Me.ResumeLayout(False)
      Me.PerformLayout()

   End Sub
   Friend WithEvents txtVersion As Eniac.Controles.TextBox
   Friend WithEvents lblNombre As Eniac.Controles.Label
   Friend WithEvents lblCodigo As Eniac.Controles.Label
   Friend WithEvents Label1 As Eniac.Controles.Label
   Friend WithEvents cmbAplicacionBase As Eniac.Controles.ComboBox
   Friend WithEvents Button1 As System.Windows.Forms.Button
   Friend WithEvents btnLimpiar As System.Windows.Forms.Button
   Friend WithEvents cmbAplicacion As Eniac.Controles.ComboBox
   Friend WithEvents txtVersionApBase As Eniac.Controles.TextBox
   Friend WithEvents Label2 As Eniac.Controles.Label
   Friend WithEvents txtVersionReport As Eniac.Controles.TextBox
   Friend WithEvents Label3 As Eniac.Controles.Label
   Friend WithEvents txtVersionFramework As Eniac.Controles.TextBox
   Friend WithEvents Label4 As Eniac.Controles.Label
   Friend WithEvents txtVersionLenguaje As Eniac.Controles.TextBox
   Friend WithEvents Label5 As Eniac.Controles.Label
   Friend WithEvents Label6 As Eniac.Controles.Label
   Friend WithEvents dtpFechaVersion As Eniac.Controles.DateTimePicker
End Class
