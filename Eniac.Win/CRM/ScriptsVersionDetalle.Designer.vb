<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ScriptsVersionDetalle
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
      Me.lblAplicacion = New Eniac.Controles.Label()
      Me.lblNombre = New Eniac.Controles.Label()
      Me.txtNombre = New Eniac.Controles.TextBox()
      Me.lblOrden = New Eniac.Controles.Label()
      Me.txtOrden = New Eniac.Controles.TextBox()
      Me.txtAplicacion = New Eniac.Controles.TextBox()
      Me.lblVersion = New Eniac.Controles.Label()
      Me.txtVersion = New Eniac.Controles.TextBox()
      Me.chbObligatorio = New Eniac.Controles.CheckBox()
      Me.bscCliente = New Eniac.Controles.Buscador2()
      Me.lblCodigoCliente = New Eniac.Controles.Label()
      Me.bscCodigoCliente = New Eniac.Controles.Buscador2()
      Me.lblNombreCliente = New Eniac.Controles.Label()
      Me.chbProspecto = New Eniac.Controles.CheckBox()
      Me.btnExaminar = New System.Windows.Forms.Button()
      Me.ofgScript = New System.Windows.Forms.OpenFileDialog()
      Me.txtScript = New System.Windows.Forms.TextBox()
      Me.SuspendLayout()
      '
      'btnAceptar
      '
      Me.btnAceptar.Location = New System.Drawing.Point(554, 409)
      Me.btnAceptar.TabIndex = 12
      '
      'btnCancelar
      '
      Me.btnCancelar.Location = New System.Drawing.Point(640, 409)
      Me.btnCancelar.TabIndex = 13
      '
      'btnCopiar
      '
      Me.btnCopiar.Location = New System.Drawing.Point(453, 409)
      Me.btnCopiar.TabIndex = 11
      '
      'btnAplicar
      '
      Me.btnAplicar.Location = New System.Drawing.Point(396, 409)
      Me.btnAplicar.TabIndex = 10
      '
      'lblAplicacion
      '
      Me.lblAplicacion.AutoSize = True
      Me.lblAplicacion.LabelAsoc = Nothing
      Me.lblAplicacion.Location = New System.Drawing.Point(17, 20)
      Me.lblAplicacion.Name = "lblAplicacion"
      Me.lblAplicacion.Size = New System.Drawing.Size(56, 13)
      Me.lblAplicacion.TabIndex = 0
      Me.lblAplicacion.Text = "Aplicación"
      '
      'lblNombre
      '
      Me.lblNombre.AutoSize = True
      Me.lblNombre.LabelAsoc = Nothing
      Me.lblNombre.Location = New System.Drawing.Point(17, 72)
      Me.lblNombre.Name = "lblNombre"
      Me.lblNombre.Size = New System.Drawing.Size(44, 13)
      Me.lblNombre.TabIndex = 7
      Me.lblNombre.Text = "Nombre"
      '
      'txtNombre
      '
      Me.txtNombre.BindearPropiedadControl = "Text"
      Me.txtNombre.BindearPropiedadEntidad = "Nombre"
      Me.txtNombre.ForeColorFocus = System.Drawing.Color.Red
      Me.txtNombre.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtNombre.Formato = ""
      Me.txtNombre.IsDecimal = False
      Me.txtNombre.IsNumber = False
      Me.txtNombre.IsPK = False
      Me.txtNombre.IsRequired = True
      Me.txtNombre.Key = ""
      Me.txtNombre.LabelAsoc = Me.lblOrden
      Me.txtNombre.Location = New System.Drawing.Point(82, 65)
      Me.txtNombre.MaxLength = 100
      Me.txtNombre.Name = "txtNombre"
      Me.txtNombre.Size = New System.Drawing.Size(282, 20)
      Me.txtNombre.TabIndex = 8
      '
      'lblOrden
      '
      Me.lblOrden.AutoSize = True
      Me.lblOrden.LabelAsoc = Nothing
      Me.lblOrden.Location = New System.Drawing.Point(17, 46)
      Me.lblOrden.Name = "lblOrden"
      Me.lblOrden.Size = New System.Drawing.Size(36, 13)
      Me.lblOrden.TabIndex = 4
      Me.lblOrden.Text = "Orden"
      '
      'txtOrden
      '
      Me.txtOrden.BindearPropiedadControl = "Text"
      Me.txtOrden.BindearPropiedadEntidad = "Orden"
      Me.txtOrden.ForeColorFocus = System.Drawing.Color.Red
      Me.txtOrden.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtOrden.Formato = "#0"
      Me.txtOrden.IsDecimal = True
      Me.txtOrden.IsNumber = True
      Me.txtOrden.IsPK = True
      Me.txtOrden.IsRequired = True
      Me.txtOrden.Key = ""
      Me.txtOrden.LabelAsoc = Me.lblOrden
      Me.txtOrden.Location = New System.Drawing.Point(82, 38)
      Me.txtOrden.MaxLength = 8
      Me.txtOrden.Name = "txtOrden"
      Me.txtOrden.Size = New System.Drawing.Size(46, 20)
      Me.txtOrden.TabIndex = 5
      Me.txtOrden.Text = "0"
      Me.txtOrden.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'txtAplicacion
      '
      Me.txtAplicacion.BindearPropiedadControl = "Text"
      Me.txtAplicacion.BindearPropiedadEntidad = "Aplicacion.IdAplicacion"
      Me.txtAplicacion.Enabled = False
      Me.txtAplicacion.ForeColorFocus = System.Drawing.Color.Red
      Me.txtAplicacion.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtAplicacion.Formato = ""
      Me.txtAplicacion.IsDecimal = False
      Me.txtAplicacion.IsNumber = False
      Me.txtAplicacion.IsPK = True
      Me.txtAplicacion.IsRequired = True
      Me.txtAplicacion.Key = ""
      Me.txtAplicacion.LabelAsoc = Me.lblOrden
      Me.txtAplicacion.Location = New System.Drawing.Point(82, 13)
      Me.txtAplicacion.MaxLength = 20
      Me.txtAplicacion.Name = "txtAplicacion"
      Me.txtAplicacion.Size = New System.Drawing.Size(91, 20)
      Me.txtAplicacion.TabIndex = 1
      '
      'lblVersion
      '
      Me.lblVersion.AutoSize = True
      Me.lblVersion.LabelAsoc = Nothing
      Me.lblVersion.Location = New System.Drawing.Point(192, 20)
      Me.lblVersion.Name = "lblVersion"
      Me.lblVersion.Size = New System.Drawing.Size(42, 13)
      Me.lblVersion.TabIndex = 2
      Me.lblVersion.Text = "Versión"
      '
      'txtVersion
      '
      Me.txtVersion.BindearPropiedadControl = "Text"
      Me.txtVersion.BindearPropiedadEntidad = "Version.NroVersion"
      Me.txtVersion.Enabled = False
      Me.txtVersion.ForeColorFocus = System.Drawing.Color.Red
      Me.txtVersion.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtVersion.Formato = ""
      Me.txtVersion.IsDecimal = False
      Me.txtVersion.IsNumber = False
      Me.txtVersion.IsPK = True
      Me.txtVersion.IsRequired = True
      Me.txtVersion.Key = ""
      Me.txtVersion.LabelAsoc = Me.lblOrden
      Me.txtVersion.Location = New System.Drawing.Point(240, 13)
      Me.txtVersion.MaxLength = 50
      Me.txtVersion.Name = "txtVersion"
      Me.txtVersion.Size = New System.Drawing.Size(80, 20)
      Me.txtVersion.TabIndex = 3
      '
      'chbObligatorio
      '
      Me.chbObligatorio.AutoSize = True
      Me.chbObligatorio.BindearPropiedadControl = "Checked"
      Me.chbObligatorio.BindearPropiedadEntidad = "Obligatorio"
      Me.chbObligatorio.Checked = True
      Me.chbObligatorio.CheckState = System.Windows.Forms.CheckState.Checked
      Me.chbObligatorio.ForeColorFocus = System.Drawing.Color.Red
      Me.chbObligatorio.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
      Me.chbObligatorio.IsPK = False
      Me.chbObligatorio.IsRequired = True
      Me.chbObligatorio.Key = Nothing
      Me.chbObligatorio.LabelAsoc = Nothing
      Me.chbObligatorio.Location = New System.Drawing.Point(238, 41)
      Me.chbObligatorio.Name = "chbObligatorio"
      Me.chbObligatorio.Size = New System.Drawing.Size(76, 17)
      Me.chbObligatorio.TabIndex = 6
      Me.chbObligatorio.Text = "Obligatorio"
      Me.chbObligatorio.UseVisualStyleBackColor = True
      '
      'bscCliente
      '
      Me.bscCliente.ActivarFiltroEnGrilla = True
      Me.bscCliente.AutoSize = True
      Me.bscCliente.BindearPropiedadControl = Nothing
      Me.bscCliente.BindearPropiedadEntidad = Nothing
      Me.bscCliente.ConfigBuscador = Nothing
      Me.bscCliente.Datos = Nothing
      Me.bscCliente.Enabled = False
      Me.bscCliente.FilaDevuelta = Nothing
      Me.bscCliente.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.bscCliente.ForeColorFocus = System.Drawing.Color.Red
      Me.bscCliente.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
      Me.bscCliente.IsDecimal = False
      Me.bscCliente.IsNumber = False
      Me.bscCliente.IsPK = False
      Me.bscCliente.IsRequired = False
      Me.bscCliente.Key = ""
      Me.bscCliente.LabelAsoc = Nothing
      Me.bscCliente.Location = New System.Drawing.Point(505, 61)
      Me.bscCliente.Margin = New System.Windows.Forms.Padding(4)
      Me.bscCliente.MaxLengh = "500"
      Me.bscCliente.Name = "bscCliente"
      Me.bscCliente.Permitido = True
      Me.bscCliente.PermitidoNoBackColor = System.Drawing.Color.FromArgb(CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer))
      Me.bscCliente.PermitidoNoForeColor = System.Drawing.Color.Black
      Me.bscCliente.PermitidoSiBackColor = System.Drawing.Color.White
      Me.bscCliente.PermitidoSiForeColor = System.Drawing.Color.Black
      Me.bscCliente.Selecciono = False
      Me.bscCliente.Size = New System.Drawing.Size(215, 23)
      Me.bscCliente.TabIndex = 17
      '
      'lblCodigoCliente
      '
      Me.lblCodigoCliente.AutoSize = True
      Me.lblCodigoCliente.Enabled = False
      Me.lblCodigoCliente.LabelAsoc = Nothing
      Me.lblCodigoCliente.Location = New System.Drawing.Point(454, 41)
      Me.lblCodigoCliente.Name = "lblCodigoCliente"
      Me.lblCodigoCliente.Size = New System.Drawing.Size(40, 13)
      Me.lblCodigoCliente.TabIndex = 16
      Me.lblCodigoCliente.Text = "Código"
      '
      'bscCodigoCliente
      '
      Me.bscCodigoCliente.ActivarFiltroEnGrilla = True
      Me.bscCodigoCliente.BindearPropiedadControl = Nothing
      Me.bscCodigoCliente.BindearPropiedadEntidad = Nothing
      Me.bscCodigoCliente.ConfigBuscador = Nothing
      Me.bscCodigoCliente.Datos = Nothing
      Me.bscCodigoCliente.Enabled = False
      Me.bscCodigoCliente.FilaDevuelta = Nothing
      Me.bscCodigoCliente.ForeColorFocus = System.Drawing.Color.Red
      Me.bscCodigoCliente.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
      Me.bscCodigoCliente.IsDecimal = False
      Me.bscCodigoCliente.IsNumber = False
      Me.bscCodigoCliente.IsPK = False
      Me.bscCodigoCliente.IsRequired = False
      Me.bscCodigoCliente.Key = ""
      Me.bscCodigoCliente.LabelAsoc = Nothing
      Me.bscCodigoCliente.Location = New System.Drawing.Point(505, 34)
      Me.bscCodigoCliente.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
      Me.bscCodigoCliente.MaxLengh = "10"
      Me.bscCodigoCliente.Name = "bscCodigoCliente"
      Me.bscCodigoCliente.Permitido = True
      Me.bscCodigoCliente.PermitidoNoBackColor = System.Drawing.Color.FromArgb(CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer))
      Me.bscCodigoCliente.PermitidoNoForeColor = System.Drawing.Color.Black
      Me.bscCodigoCliente.PermitidoSiBackColor = System.Drawing.Color.White
      Me.bscCodigoCliente.PermitidoSiForeColor = System.Drawing.Color.Black
      Me.bscCodigoCliente.Selecciono = False
      Me.bscCodigoCliente.Size = New System.Drawing.Size(90, 20)
      Me.bscCodigoCliente.TabIndex = 15
      '
      'lblNombreCliente
      '
      Me.lblNombreCliente.AutoSize = True
      Me.lblNombreCliente.Enabled = False
      Me.lblNombreCliente.LabelAsoc = Nothing
      Me.lblNombreCliente.Location = New System.Drawing.Point(454, 68)
      Me.lblNombreCliente.Name = "lblNombreCliente"
      Me.lblNombreCliente.Size = New System.Drawing.Size(44, 13)
      Me.lblNombreCliente.TabIndex = 18
      Me.lblNombreCliente.Text = "&Nombre"
      '
      'chbProspecto
      '
      Me.chbProspecto.AutoSize = True
      Me.chbProspecto.BindearPropiedadControl = Nothing
      Me.chbProspecto.BindearPropiedadEntidad = Nothing
      Me.chbProspecto.ForeColorFocus = System.Drawing.Color.Red
      Me.chbProspecto.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
      Me.chbProspecto.IsPK = False
      Me.chbProspecto.IsRequired = False
      Me.chbProspecto.Key = Nothing
      Me.chbProspecto.LabelAsoc = Nothing
      Me.chbProspecto.Location = New System.Drawing.Point(461, 10)
      Me.chbProspecto.Name = "chbProspecto"
      Me.chbProspecto.Size = New System.Drawing.Size(86, 17)
      Me.chbProspecto.TabIndex = 14
      Me.chbProspecto.Text = "Solo para ...."
      Me.chbProspecto.UseVisualStyleBackColor = True
      '
      'btnExaminar
      '
      Me.btnExaminar.BackColor = System.Drawing.Color.Transparent
      Me.btnExaminar.BackgroundImage = Global.Eniac.Win.My.Resources.Resources.folder_32
      Me.btnExaminar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
      Me.btnExaminar.Location = New System.Drawing.Point(370, 58)
      Me.btnExaminar.Name = "btnExaminar"
      Me.btnExaminar.Size = New System.Drawing.Size(32, 32)
      Me.btnExaminar.TabIndex = 21
      Me.btnExaminar.UseVisualStyleBackColor = False
      '
      'ofgScript
      '
      Me.ofgScript.DefaultExt = "png"
      Me.ofgScript.Filter = "Archivos de Texto (*.sql)|*.sql|Todos los Archivos (*.*)|*.*"
      Me.ofgScript.RestoreDirectory = True
      Me.ofgScript.Title = "Seleccione un archivo"
      '
      'txtScript
      '
      Me.txtScript.Location = New System.Drawing.Point(20, 96)
      Me.txtScript.Multiline = True
      Me.txtScript.Name = "txtScript"
      Me.txtScript.Size = New System.Drawing.Size(700, 307)
      Me.txtScript.TabIndex = 22
      '
      'ScriptsVersionDetalle
      '
      Me.AcceptButton = Nothing
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.ClientSize = New System.Drawing.Size(729, 444)
      Me.Controls.Add(Me.txtScript)
      Me.Controls.Add(Me.btnExaminar)
      Me.Controls.Add(Me.bscCliente)
      Me.Controls.Add(Me.lblCodigoCliente)
      Me.Controls.Add(Me.bscCodigoCliente)
      Me.Controls.Add(Me.lblNombreCliente)
      Me.Controls.Add(Me.chbProspecto)
      Me.Controls.Add(Me.chbObligatorio)
      Me.Controls.Add(Me.txtVersion)
      Me.Controls.Add(Me.lblVersion)
      Me.Controls.Add(Me.txtAplicacion)
      Me.Controls.Add(Me.lblNombre)
      Me.Controls.Add(Me.txtNombre)
      Me.Controls.Add(Me.txtOrden)
      Me.Controls.Add(Me.lblOrden)
      Me.Controls.Add(Me.lblAplicacion)
      Me.Name = "ScriptsVersionDetalle"
      Me.Text = "Script"
      Me.Controls.SetChildIndex(Me.lblAplicacion, 0)
      Me.Controls.SetChildIndex(Me.lblOrden, 0)
      Me.Controls.SetChildIndex(Me.txtOrden, 0)
      Me.Controls.SetChildIndex(Me.txtNombre, 0)
      Me.Controls.SetChildIndex(Me.lblNombre, 0)
      Me.Controls.SetChildIndex(Me.txtAplicacion, 0)
      Me.Controls.SetChildIndex(Me.lblVersion, 0)
      Me.Controls.SetChildIndex(Me.txtVersion, 0)
      Me.Controls.SetChildIndex(Me.chbObligatorio, 0)
      Me.Controls.SetChildIndex(Me.chbProspecto, 0)
      Me.Controls.SetChildIndex(Me.lblNombreCliente, 0)
      Me.Controls.SetChildIndex(Me.bscCodigoCliente, 0)
      Me.Controls.SetChildIndex(Me.lblCodigoCliente, 0)
      Me.Controls.SetChildIndex(Me.bscCliente, 0)
      Me.Controls.SetChildIndex(Me.btnExaminar, 0)
      Me.Controls.SetChildIndex(Me.btnCancelar, 0)
      Me.Controls.SetChildIndex(Me.btnAceptar, 0)
      Me.Controls.SetChildIndex(Me.btnCopiar, 0)
      Me.Controls.SetChildIndex(Me.btnAplicar, 0)
      Me.Controls.SetChildIndex(Me.txtScript, 0)
      Me.ResumeLayout(False)
      Me.PerformLayout()

   End Sub
   Friend WithEvents lblAplicacion As Eniac.Controles.Label
   Friend WithEvents lblNombre As Eniac.Controles.Label
   Friend WithEvents txtNombre As Eniac.Controles.TextBox
   Friend WithEvents lblOrden As Eniac.Controles.Label
   Friend WithEvents txtOrden As Eniac.Controles.TextBox
   Friend WithEvents txtAplicacion As Eniac.Controles.TextBox
   Friend WithEvents lblVersion As Eniac.Controles.Label
   Friend WithEvents txtVersion As Eniac.Controles.TextBox
   Friend WithEvents chbObligatorio As Eniac.Controles.CheckBox
   Friend WithEvents bscCliente As Eniac.Controles.Buscador2
   Friend WithEvents lblCodigoCliente As Eniac.Controles.Label
   Friend WithEvents bscCodigoCliente As Eniac.Controles.Buscador2
   Friend WithEvents lblNombreCliente As Eniac.Controles.Label
   Friend WithEvents chbProspecto As Eniac.Controles.CheckBox
   Friend WithEvents btnExaminar As System.Windows.Forms.Button
   Friend WithEvents ofgScript As System.Windows.Forms.OpenFileDialog
   Friend WithEvents txtScript As System.Windows.Forms.TextBox
End Class
