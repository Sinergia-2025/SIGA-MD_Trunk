<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ParametrosDelUsuarioCargarNuevoCertificado
   Inherits BaseForm

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
      Me.components = New System.ComponentModel.Container()
      Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ParametrosDelUsuarioCargarNuevoCertificado))
      Me.txtArchivoCertificado = New Eniac.Controles.TextBox()
      Me.lblArchivoCertificado = New Eniac.Controles.Label()
      Me.ofdCertificado = New System.Windows.Forms.OpenFileDialog()
      Me.btnBuscarArchivo = New System.Windows.Forms.Button()
      Me.lblVencimientoCertificado = New Eniac.Controles.Label()
      Me.dtpVencimientoCertificado = New Eniac.Controles.DateTimePicker()
      Me.btnAceptar = New System.Windows.Forms.Button()
      Me.imageList1 = New System.Windows.Forms.ImageList(Me.components)
      Me.btnCancelar = New System.Windows.Forms.Button()
      Me.SuspendLayout()
      '
      'txtArchivoCertificado
      '
      Me.txtArchivoCertificado.BindearPropiedadControl = Nothing
      Me.txtArchivoCertificado.BindearPropiedadEntidad = Nothing
      Me.txtArchivoCertificado.ForeColorFocus = System.Drawing.Color.Red
      Me.txtArchivoCertificado.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtArchivoCertificado.Formato = ""
      Me.txtArchivoCertificado.IsDecimal = False
      Me.txtArchivoCertificado.IsNumber = False
      Me.txtArchivoCertificado.IsPK = False
      Me.txtArchivoCertificado.IsRequired = False
      Me.txtArchivoCertificado.Key = ""
      Me.txtArchivoCertificado.LabelAsoc = Me.lblArchivoCertificado
      Me.txtArchivoCertificado.Location = New System.Drawing.Point(177, 12)
      Me.txtArchivoCertificado.Name = "txtArchivoCertificado"
      Me.txtArchivoCertificado.Size = New System.Drawing.Size(308, 20)
      Me.txtArchivoCertificado.TabIndex = 9
      Me.txtArchivoCertificado.Tag = "UBICACIONPDFSFE"
      '
      'lblArchivoCertificado
      '
      Me.lblArchivoCertificado.AutoSize = True
      Me.lblArchivoCertificado.ForeColor = System.Drawing.SystemColors.WindowText
      Me.lblArchivoCertificado.LabelAsoc = Nothing
      Me.lblArchivoCertificado.Location = New System.Drawing.Point(12, 15)
      Me.lblArchivoCertificado.Name = "lblArchivoCertificado"
      Me.lblArchivoCertificado.Size = New System.Drawing.Size(113, 13)
      Me.lblArchivoCertificado.TabIndex = 8
      Me.lblArchivoCertificado.Text = "Archivo del Certificado"
      '
      'ofdCertificado
      '
      Me.ofdCertificado.Filter = "Certificado files|*.p12"
      '
      'btnBuscarArchivo
      '
      Me.btnBuscarArchivo.Image = Global.Eniac.Win.My.Resources.Resources.folder_16
      Me.btnBuscarArchivo.Location = New System.Drawing.Point(491, 10)
      Me.btnBuscarArchivo.Name = "btnBuscarArchivo"
      Me.btnBuscarArchivo.Size = New System.Drawing.Size(23, 23)
      Me.btnBuscarArchivo.TabIndex = 11
      Me.btnBuscarArchivo.UseVisualStyleBackColor = True
      '
      'lblVencimientoCertificado
      '
      Me.lblVencimientoCertificado.AutoSize = True
      Me.lblVencimientoCertificado.ForeColor = System.Drawing.SystemColors.WindowText
      Me.lblVencimientoCertificado.LabelAsoc = Nothing
      Me.lblVencimientoCertificado.Location = New System.Drawing.Point(12, 41)
      Me.lblVencimientoCertificado.Name = "lblVencimientoCertificado"
      Me.lblVencimientoCertificado.Size = New System.Drawing.Size(159, 13)
      Me.lblVencimientoCertificado.TabIndex = 12
      Me.lblVencimientoCertificado.Text = "Fecha Estimada de Vencimiento"
      '
      'dtpVencimientoCertificado
      '
      Me.dtpVencimientoCertificado.BindearPropiedadControl = Nothing
      Me.dtpVencimientoCertificado.BindearPropiedadEntidad = Nothing
      Me.dtpVencimientoCertificado.Checked = False
      Me.dtpVencimientoCertificado.CustomFormat = "dd/MM/yyyy"
      Me.dtpVencimientoCertificado.ForeColorFocus = System.Drawing.Color.Red
      Me.dtpVencimientoCertificado.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.dtpVencimientoCertificado.Format = System.Windows.Forms.DateTimePickerFormat.Custom
      Me.dtpVencimientoCertificado.IsPK = False
      Me.dtpVencimientoCertificado.IsRequired = False
      Me.dtpVencimientoCertificado.Key = ""
      Me.dtpVencimientoCertificado.LabelAsoc = Nothing
      Me.dtpVencimientoCertificado.Location = New System.Drawing.Point(177, 38)
      Me.dtpVencimientoCertificado.Name = "dtpVencimientoCertificado"
      Me.dtpVencimientoCertificado.Size = New System.Drawing.Size(104, 20)
      Me.dtpVencimientoCertificado.TabIndex = 13
      Me.dtpVencimientoCertificado.Tag = "FACTELECTGENERATIONTIME"
      '
      'btnAceptar
      '
      Me.btnAceptar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.btnAceptar.DialogResult = System.Windows.Forms.DialogResult.Cancel
      Me.btnAceptar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
      Me.btnAceptar.ImageIndex = 0
      Me.btnAceptar.ImageList = Me.imageList1
      Me.btnAceptar.Location = New System.Drawing.Point(352, 67)
      Me.btnAceptar.Name = "btnAceptar"
      Me.btnAceptar.Size = New System.Drawing.Size(80, 30)
      Me.btnAceptar.TabIndex = 15
      Me.btnAceptar.Text = "&Aceptar"
      Me.btnAceptar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      Me.btnAceptar.UseVisualStyleBackColor = True
      '
      'imageList1
      '
      Me.imageList1.ImageStream = CType(resources.GetObject("imageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
      Me.imageList1.TransparentColor = System.Drawing.Color.Transparent
      Me.imageList1.Images.SetKeyName(0, "check2.ico")
      Me.imageList1.Images.SetKeyName(1, "delete2.ico")
      '
      'btnCancelar
      '
      Me.btnCancelar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel
      Me.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
      Me.btnCancelar.ImageIndex = 1
      Me.btnCancelar.ImageList = Me.imageList1
      Me.btnCancelar.Location = New System.Drawing.Point(438, 67)
      Me.btnCancelar.Name = "btnCancelar"
      Me.btnCancelar.Size = New System.Drawing.Size(80, 30)
      Me.btnCancelar.TabIndex = 14
      Me.btnCancelar.Text = "&Cancelar"
      Me.btnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      Me.btnCancelar.UseVisualStyleBackColor = True
      '
      'ParametrosDelUsuarioCargarNuevoCertificado
      '
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.CancelButton = Me.btnCancelar
      Me.ClientSize = New System.Drawing.Size(530, 109)
      Me.Controls.Add(Me.btnAceptar)
      Me.Controls.Add(Me.btnCancelar)
      Me.Controls.Add(Me.lblVencimientoCertificado)
      Me.Controls.Add(Me.dtpVencimientoCertificado)
      Me.Controls.Add(Me.btnBuscarArchivo)
      Me.Controls.Add(Me.txtArchivoCertificado)
      Me.Controls.Add(Me.lblArchivoCertificado)
      Me.Name = "ParametrosDelUsuarioCargarNuevoCertificado"
      Me.ShowInTaskbar = False
      Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
      Me.Text = "Cargar Nuevo Certificado"
      Me.ResumeLayout(False)
      Me.PerformLayout()

   End Sub
   Friend WithEvents txtArchivoCertificado As Eniac.Controles.TextBox
   Friend WithEvents lblArchivoCertificado As Eniac.Controles.Label
   Friend WithEvents ofdCertificado As System.Windows.Forms.OpenFileDialog
   Friend WithEvents btnBuscarArchivo As System.Windows.Forms.Button
   Friend WithEvents lblVencimientoCertificado As Eniac.Controles.Label
   Friend WithEvents dtpVencimientoCertificado As Eniac.Controles.DateTimePicker
   Protected WithEvents btnAceptar As System.Windows.Forms.Button
   Private WithEvents imageList1 As System.Windows.Forms.ImageList
   Protected WithEvents btnCancelar As System.Windows.Forms.Button
End Class
