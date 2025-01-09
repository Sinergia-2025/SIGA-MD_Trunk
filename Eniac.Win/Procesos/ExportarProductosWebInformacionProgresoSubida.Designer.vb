<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ExportarProductosWebInformacionProgresoSubida
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
      Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
      Me.BackgroundWorker1 = New System.ComponentModel.BackgroundWorker()
      Me.lblTiempoEstimado = New Eniac.Controles.Label()
      Me.lblTiempoTranscurrido = New Eniac.Controles.Label()
      Me.lblSubiendo = New Eniac.Controles.Label()
      Me.lblTamanio = New Eniac.Controles.Label()
      Me.lblNombreArchivo = New Eniac.Controles.Label()
      Me.txtSubiendoTamanioArchivos = New Eniac.Controles.TextBox()
      Me.txtTiempoEstimado = New Eniac.Controles.TextBox()
      Me.txtTiempoTranscurrido = New Eniac.Controles.TextBox()
      Me.txtSubiendoCantidadArchivos = New Eniac.Controles.TextBox()
      Me.txtTamanio = New Eniac.Controles.TextBox()
      Me.txtNombreArchivo = New Eniac.Controles.TextBox()
      Me.btnCerrar = New System.Windows.Forms.Button()
      Me.txtTiempoFinalizacion = New Eniac.Controles.TextBox()
      Me.lblTiempoFinalizacion = New Eniac.Controles.Label()
      Me.SuspendLayout()
      '
      'Timer1
      '
      '
      'BackgroundWorker1
      '
      Me.BackgroundWorker1.WorkerReportsProgress = True
      Me.BackgroundWorker1.WorkerSupportsCancellation = True
      '
      'lblTiempoEstimado
      '
      Me.lblTiempoEstimado.AutoSize = True
      Me.lblTiempoEstimado.ForeColor = System.Drawing.SystemColors.WindowText
      Me.lblTiempoEstimado.Location = New System.Drawing.Point(25, 140)
      Me.lblTiempoEstimado.Name = "lblTiempoEstimado"
      Me.lblTiempoEstimado.Size = New System.Drawing.Size(87, 13)
      Me.lblTiempoEstimado.TabIndex = 2
      Me.lblTiempoEstimado.Text = "Tiempo estimado"
      '
      'lblTiempoTranscurrido
      '
      Me.lblTiempoTranscurrido.AutoSize = True
      Me.lblTiempoTranscurrido.ForeColor = System.Drawing.SystemColors.WindowText
      Me.lblTiempoTranscurrido.Location = New System.Drawing.Point(25, 114)
      Me.lblTiempoTranscurrido.Name = "lblTiempoTranscurrido"
      Me.lblTiempoTranscurrido.Size = New System.Drawing.Size(100, 13)
      Me.lblTiempoTranscurrido.TabIndex = 2
      Me.lblTiempoTranscurrido.Text = "Tiempo transcurrido"
      '
      'lblSubiendo
      '
      Me.lblSubiendo.AutoSize = True
      Me.lblSubiendo.ForeColor = System.Drawing.SystemColors.WindowText
      Me.lblSubiendo.Location = New System.Drawing.Point(25, 88)
      Me.lblSubiendo.Name = "lblSubiendo"
      Me.lblSubiendo.Size = New System.Drawing.Size(52, 13)
      Me.lblSubiendo.TabIndex = 2
      Me.lblSubiendo.Text = "Subiendo"
      '
      'lblTamanio
      '
      Me.lblTamanio.AutoSize = True
      Me.lblTamanio.ForeColor = System.Drawing.SystemColors.WindowText
      Me.lblTamanio.Location = New System.Drawing.Point(25, 41)
      Me.lblTamanio.Name = "lblTamanio"
      Me.lblTamanio.Size = New System.Drawing.Size(84, 13)
      Me.lblTamanio.TabIndex = 2
      Me.lblTamanio.Text = "Tamaño archivo"
      '
      'lblNombreArchivo
      '
      Me.lblNombreArchivo.AutoSize = True
      Me.lblNombreArchivo.ForeColor = System.Drawing.SystemColors.WindowText
      Me.lblNombreArchivo.Location = New System.Drawing.Point(25, 15)
      Me.lblNombreArchivo.Name = "lblNombreArchivo"
      Me.lblNombreArchivo.Size = New System.Drawing.Size(82, 13)
      Me.lblNombreArchivo.TabIndex = 2
      Me.lblNombreArchivo.Text = "Nombre archivo"
      '
      'txtSubiendoTamanioArchivos
      '
      Me.txtSubiendoTamanioArchivos.BindearPropiedadControl = Nothing
      Me.txtSubiendoTamanioArchivos.BindearPropiedadEntidad = Nothing
      Me.txtSubiendoTamanioArchivos.ForeColorFocus = System.Drawing.Color.Red
      Me.txtSubiendoTamanioArchivos.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtSubiendoTamanioArchivos.Formato = ""
      Me.txtSubiendoTamanioArchivos.IsDecimal = False
      Me.txtSubiendoTamanioArchivos.IsNumber = False
      Me.txtSubiendoTamanioArchivos.IsPK = False
      Me.txtSubiendoTamanioArchivos.IsRequired = False
      Me.txtSubiendoTamanioArchivos.Key = ""
      Me.txtSubiendoTamanioArchivos.LabelAsoc = Nothing
      Me.txtSubiendoTamanioArchivos.Location = New System.Drawing.Point(211, 85)
      Me.txtSubiendoTamanioArchivos.MaxLength = 15
      Me.txtSubiendoTamanioArchivos.Name = "txtSubiendoTamanioArchivos"
      Me.txtSubiendoTamanioArchivos.ReadOnly = True
      Me.txtSubiendoTamanioArchivos.Size = New System.Drawing.Size(129, 20)
      Me.txtSubiendoTamanioArchivos.TabIndex = 3
      '
      'txtTiempoEstimado
      '
      Me.txtTiempoEstimado.BindearPropiedadControl = Nothing
      Me.txtTiempoEstimado.BindearPropiedadEntidad = Nothing
      Me.txtTiempoEstimado.ForeColorFocus = System.Drawing.Color.Red
      Me.txtTiempoEstimado.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtTiempoEstimado.Formato = ""
      Me.txtTiempoEstimado.IsDecimal = False
      Me.txtTiempoEstimado.IsNumber = False
      Me.txtTiempoEstimado.IsPK = False
      Me.txtTiempoEstimado.IsRequired = False
      Me.txtTiempoEstimado.Key = ""
      Me.txtTiempoEstimado.LabelAsoc = Me.lblTiempoEstimado
      Me.txtTiempoEstimado.Location = New System.Drawing.Point(137, 137)
      Me.txtTiempoEstimado.MaxLength = 15
      Me.txtTiempoEstimado.Name = "txtTiempoEstimado"
      Me.txtTiempoEstimado.ReadOnly = True
      Me.txtTiempoEstimado.Size = New System.Drawing.Size(68, 20)
      Me.txtTiempoEstimado.TabIndex = 3
      '
      'txtTiempoTranscurrido
      '
      Me.txtTiempoTranscurrido.BindearPropiedadControl = Nothing
      Me.txtTiempoTranscurrido.BindearPropiedadEntidad = Nothing
      Me.txtTiempoTranscurrido.ForeColorFocus = System.Drawing.Color.Red
      Me.txtTiempoTranscurrido.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtTiempoTranscurrido.Formato = ""
      Me.txtTiempoTranscurrido.IsDecimal = False
      Me.txtTiempoTranscurrido.IsNumber = False
      Me.txtTiempoTranscurrido.IsPK = False
      Me.txtTiempoTranscurrido.IsRequired = False
      Me.txtTiempoTranscurrido.Key = ""
      Me.txtTiempoTranscurrido.LabelAsoc = Me.lblTiempoTranscurrido
      Me.txtTiempoTranscurrido.Location = New System.Drawing.Point(137, 111)
      Me.txtTiempoTranscurrido.MaxLength = 15
      Me.txtTiempoTranscurrido.Name = "txtTiempoTranscurrido"
      Me.txtTiempoTranscurrido.ReadOnly = True
      Me.txtTiempoTranscurrido.Size = New System.Drawing.Size(68, 20)
      Me.txtTiempoTranscurrido.TabIndex = 3
      '
      'txtSubiendoCantidadArchivos
      '
      Me.txtSubiendoCantidadArchivos.BindearPropiedadControl = Nothing
      Me.txtSubiendoCantidadArchivos.BindearPropiedadEntidad = Nothing
      Me.txtSubiendoCantidadArchivos.ForeColorFocus = System.Drawing.Color.Red
      Me.txtSubiendoCantidadArchivos.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtSubiendoCantidadArchivos.Formato = ""
      Me.txtSubiendoCantidadArchivos.IsDecimal = False
      Me.txtSubiendoCantidadArchivos.IsNumber = False
      Me.txtSubiendoCantidadArchivos.IsPK = False
      Me.txtSubiendoCantidadArchivos.IsRequired = False
      Me.txtSubiendoCantidadArchivos.Key = ""
      Me.txtSubiendoCantidadArchivos.LabelAsoc = Me.lblSubiendo
      Me.txtSubiendoCantidadArchivos.Location = New System.Drawing.Point(137, 85)
      Me.txtSubiendoCantidadArchivos.MaxLength = 15
      Me.txtSubiendoCantidadArchivos.Name = "txtSubiendoCantidadArchivos"
      Me.txtSubiendoCantidadArchivos.ReadOnly = True
      Me.txtSubiendoCantidadArchivos.Size = New System.Drawing.Size(68, 20)
      Me.txtSubiendoCantidadArchivos.TabIndex = 3
      '
      'txtTamanio
      '
      Me.txtTamanio.BindearPropiedadControl = Nothing
      Me.txtTamanio.BindearPropiedadEntidad = Nothing
      Me.txtTamanio.ForeColorFocus = System.Drawing.Color.Red
      Me.txtTamanio.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtTamanio.Formato = ""
      Me.txtTamanio.IsDecimal = False
      Me.txtTamanio.IsNumber = False
      Me.txtTamanio.IsPK = False
      Me.txtTamanio.IsRequired = False
      Me.txtTamanio.Key = ""
      Me.txtTamanio.LabelAsoc = Me.lblTamanio
      Me.txtTamanio.Location = New System.Drawing.Point(137, 38)
      Me.txtTamanio.MaxLength = 15
      Me.txtTamanio.Name = "txtTamanio"
      Me.txtTamanio.ReadOnly = True
      Me.txtTamanio.Size = New System.Drawing.Size(83, 20)
      Me.txtTamanio.TabIndex = 3
      '
      'txtNombreArchivo
      '
      Me.txtNombreArchivo.BindearPropiedadControl = Nothing
      Me.txtNombreArchivo.BindearPropiedadEntidad = Nothing
      Me.txtNombreArchivo.ForeColorFocus = System.Drawing.Color.Red
      Me.txtNombreArchivo.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtNombreArchivo.Formato = ""
      Me.txtNombreArchivo.IsDecimal = False
      Me.txtNombreArchivo.IsNumber = False
      Me.txtNombreArchivo.IsPK = False
      Me.txtNombreArchivo.IsRequired = False
      Me.txtNombreArchivo.Key = ""
      Me.txtNombreArchivo.LabelAsoc = Me.lblNombreArchivo
      Me.txtNombreArchivo.Location = New System.Drawing.Point(137, 12)
      Me.txtNombreArchivo.MaxLength = 15
      Me.txtNombreArchivo.Name = "txtNombreArchivo"
      Me.txtNombreArchivo.ReadOnly = True
      Me.txtNombreArchivo.Size = New System.Drawing.Size(203, 20)
      Me.txtNombreArchivo.TabIndex = 3
      '
      'btnCerrar
      '
      Me.btnCerrar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.btnCerrar.Location = New System.Drawing.Point(265, 166)
      Me.btnCerrar.Name = "btnCerrar"
      Me.btnCerrar.Size = New System.Drawing.Size(75, 23)
      Me.btnCerrar.TabIndex = 4
      Me.btnCerrar.Text = "Cerrar"
      Me.btnCerrar.UseVisualStyleBackColor = True
      Me.btnCerrar.Visible = False
      '
      'txtTiempoFinalizacion
      '
      Me.txtTiempoFinalizacion.BindearPropiedadControl = Nothing
      Me.txtTiempoFinalizacion.BindearPropiedadEntidad = Nothing
      Me.txtTiempoFinalizacion.ForeColorFocus = System.Drawing.Color.Red
      Me.txtTiempoFinalizacion.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtTiempoFinalizacion.Formato = ""
      Me.txtTiempoFinalizacion.IsDecimal = False
      Me.txtTiempoFinalizacion.IsNumber = False
      Me.txtTiempoFinalizacion.IsPK = False
      Me.txtTiempoFinalizacion.IsRequired = False
      Me.txtTiempoFinalizacion.Key = ""
      Me.txtTiempoFinalizacion.LabelAsoc = Me.lblTiempoFinalizacion
      Me.txtTiempoFinalizacion.Location = New System.Drawing.Point(137, 163)
      Me.txtTiempoFinalizacion.MaxLength = 15
      Me.txtTiempoFinalizacion.Name = "txtTiempoFinalizacion"
      Me.txtTiempoFinalizacion.ReadOnly = True
      Me.txtTiempoFinalizacion.Size = New System.Drawing.Size(68, 20)
      Me.txtTiempoFinalizacion.TabIndex = 3
      '
      'lblTiempoFinalizacion
      '
      Me.lblTiempoFinalizacion.AutoSize = True
      Me.lblTiempoFinalizacion.ForeColor = System.Drawing.SystemColors.WindowText
      Me.lblTiempoFinalizacion.Location = New System.Drawing.Point(25, 166)
      Me.lblTiempoFinalizacion.Name = "lblTiempoFinalizacion"
      Me.lblTiempoFinalizacion.Size = New System.Drawing.Size(106, 13)
      Me.lblTiempoFinalizacion.TabIndex = 2
      Me.lblTiempoFinalizacion.Text = "Tiempo para terminar"
      '
      'ExportarProductosWebInformacionProgresoSubida
      '
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.ClientSize = New System.Drawing.Size(352, 201)
      Me.ControlBox = False
      Me.Controls.Add(Me.btnCerrar)
      Me.Controls.Add(Me.lblTiempoFinalizacion)
      Me.Controls.Add(Me.lblTiempoEstimado)
      Me.Controls.Add(Me.lblTiempoTranscurrido)
      Me.Controls.Add(Me.lblSubiendo)
      Me.Controls.Add(Me.lblTamanio)
      Me.Controls.Add(Me.lblNombreArchivo)
      Me.Controls.Add(Me.txtSubiendoTamanioArchivos)
      Me.Controls.Add(Me.txtTiempoFinalizacion)
      Me.Controls.Add(Me.txtTiempoEstimado)
      Me.Controls.Add(Me.txtTiempoTranscurrido)
      Me.Controls.Add(Me.txtSubiendoCantidadArchivos)
      Me.Controls.Add(Me.txtTamanio)
      Me.Controls.Add(Me.txtNombreArchivo)
      Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
      Me.Name = "ExportarProductosWebInformacionProgresoSubida"
      Me.ShowInTaskbar = False
      Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
      Me.Text = "Avance"
      Me.ResumeLayout(False)
      Me.PerformLayout()

   End Sub
   Friend WithEvents lblNombreArchivo As Eniac.Controles.Label
   Friend WithEvents txtNombreArchivo As Eniac.Controles.TextBox
   Friend WithEvents txtTamanio As Eniac.Controles.TextBox
   Friend WithEvents lblTamanio As Eniac.Controles.Label
   Friend WithEvents txtSubiendoCantidadArchivos As Eniac.Controles.TextBox
   Friend WithEvents lblSubiendo As Eniac.Controles.Label
   Friend WithEvents txtSubiendoTamanioArchivos As Eniac.Controles.TextBox
   Friend WithEvents txtTiempoTranscurrido As Eniac.Controles.TextBox
   Friend WithEvents lblTiempoTranscurrido As Eniac.Controles.Label
   Friend WithEvents txtTiempoEstimado As Eniac.Controles.TextBox
   Friend WithEvents lblTiempoEstimado As Eniac.Controles.Label
   Friend WithEvents Timer1 As System.Windows.Forms.Timer
   Friend WithEvents BackgroundWorker1 As System.ComponentModel.BackgroundWorker
   Friend WithEvents btnCerrar As System.Windows.Forms.Button
   Friend WithEvents txtTiempoFinalizacion As Eniac.Controles.TextBox
   Friend WithEvents lblTiempoFinalizacion As Eniac.Controles.Label
End Class
