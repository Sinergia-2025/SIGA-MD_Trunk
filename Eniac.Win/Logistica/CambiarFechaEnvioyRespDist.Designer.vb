<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CambiarFechaEnvioyRespDist
    Inherits System.Windows.Forms.Form

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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(CambiarFechaEnvioyRespDist))
        Me.tstBarra = New System.Windows.Forms.ToolStrip()
        Me.tsbGrabar = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsbCerrar = New System.Windows.Forms.ToolStripButton()
        Me.dtpFechaEnvioNueva = New Eniac.Controles.DateTimePicker()
        Me.dtpFechaEnvio = New Eniac.Controles.DateTimePicker()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtLetra = New System.Windows.Forms.TextBox()
        Me.txtNumeroComprobante = New System.Windows.Forms.TextBox()
        Me.txtIdTipoComprobante = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cmbRespDistribucionNuevo = New Eniac.Controles.ComboBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.cmbRespDistribucion = New Eniac.Controles.ComboBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.tstBarra.SuspendLayout()
        Me.SuspendLayout()
        '
        'tstBarra
        '
        Me.tstBarra.AllowItemReorder = True
        Me.tstBarra.ImageScalingSize = New System.Drawing.Size(22, 22)
        Me.tstBarra.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsbGrabar, Me.ToolStripSeparator2, Me.tsbCerrar})
        Me.tstBarra.Location = New System.Drawing.Point(0, 0)
        Me.tstBarra.Name = "tstBarra"
        Me.tstBarra.Size = New System.Drawing.Size(635, 29)
        Me.tstBarra.TabIndex = 56
        Me.tstBarra.Text = "toolStrip1"
        '
        'tsbGrabar
        '
      Me.tsbGrabar.Image = Global.Eniac.Win.My.Resources.Resources.diskette_32
        Me.tsbGrabar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbGrabar.Name = "tsbGrabar"
        Me.tsbGrabar.Size = New System.Drawing.Size(68, 26)
        Me.tsbGrabar.Text = "&Grabar"
        Me.tsbGrabar.ToolTipText = "Cerrar el formulario"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 29)
        '
        'tsbCerrar
        '
        Me.tsbCerrar.Image = CType(resources.GetObject("tsbCerrar.Image"), System.Drawing.Image)
        Me.tsbCerrar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbCerrar.Name = "tsbCerrar"
        Me.tsbCerrar.Size = New System.Drawing.Size(65, 26)
        Me.tsbCerrar.Text = "&Cerrar"
        Me.tsbCerrar.ToolTipText = "Cerrar el formulario"
        '
        'dtpFechaEnvioNueva
        '
        Me.dtpFechaEnvioNueva.BindearPropiedadControl = Nothing
        Me.dtpFechaEnvioNueva.BindearPropiedadEntidad = Nothing
        Me.dtpFechaEnvioNueva.CustomFormat = "dd/MM/yyyy"
        Me.dtpFechaEnvioNueva.ForeColorFocus = System.Drawing.Color.Red
        Me.dtpFechaEnvioNueva.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.dtpFechaEnvioNueva.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpFechaEnvioNueva.IsPK = False
        Me.dtpFechaEnvioNueva.IsRequired = False
        Me.dtpFechaEnvioNueva.Key = ""
        Me.dtpFechaEnvioNueva.LabelAsoc = Nothing
        Me.dtpFechaEnvioNueva.Location = New System.Drawing.Point(149, 128)
        Me.dtpFechaEnvioNueva.Name = "dtpFechaEnvioNueva"
        Me.dtpFechaEnvioNueva.Size = New System.Drawing.Size(97, 20)
        Me.dtpFechaEnvioNueva.TabIndex = 68
        '
        'dtpFechaEnvio
        '
        Me.dtpFechaEnvio.BindearPropiedadControl = Nothing
        Me.dtpFechaEnvio.BindearPropiedadEntidad = Nothing
        Me.dtpFechaEnvio.CustomFormat = "dd/MM/yyyy"
        Me.dtpFechaEnvio.Enabled = False
        Me.dtpFechaEnvio.ForeColorFocus = System.Drawing.Color.Red
        Me.dtpFechaEnvio.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.dtpFechaEnvio.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpFechaEnvio.IsPK = False
        Me.dtpFechaEnvio.IsRequired = False
        Me.dtpFechaEnvio.Key = ""
        Me.dtpFechaEnvio.LabelAsoc = Nothing
        Me.dtpFechaEnvio.Location = New System.Drawing.Point(149, 93)
        Me.dtpFechaEnvio.Name = "dtpFechaEnvio"
        Me.dtpFechaEnvio.Size = New System.Drawing.Size(97, 20)
        Me.dtpFechaEnvio.TabIndex = 67
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(9, 131)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(119, 13)
        Me.Label3.TabIndex = 66
        Me.Label3.Text = "Fecha de Envío Nueva"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(9, 95)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(84, 13)
        Me.Label2.TabIndex = 65
        Me.Label2.Text = "Fecha de Envío"
        '
        'txtLetra
        '
        Me.txtLetra.Enabled = False
        Me.txtLetra.Location = New System.Drawing.Point(185, 49)
        Me.txtLetra.Name = "txtLetra"
        Me.txtLetra.Size = New System.Drawing.Size(44, 20)
        Me.txtLetra.TabIndex = 64
        Me.txtLetra.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtNumeroComprobante
        '
        Me.txtNumeroComprobante.Enabled = False
        Me.txtNumeroComprobante.Location = New System.Drawing.Point(235, 49)
        Me.txtNumeroComprobante.Name = "txtNumeroComprobante"
        Me.txtNumeroComprobante.Size = New System.Drawing.Size(87, 20)
        Me.txtNumeroComprobante.TabIndex = 63
        Me.txtNumeroComprobante.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtIdTipoComprobante
        '
        Me.txtIdTipoComprobante.Enabled = False
        Me.txtIdTipoComprobante.Location = New System.Drawing.Point(54, 49)
        Me.txtIdTipoComprobante.Name = "txtIdTipoComprobante"
        Me.txtIdTipoComprobante.Size = New System.Drawing.Size(125, 20)
        Me.txtIdTipoComprobante.TabIndex = 62
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(8, 52)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(40, 13)
        Me.Label1.TabIndex = 61
        Me.Label1.Text = "Pedido"
        '
        'cmbRespDistribucionNuevo
        '
        Me.cmbRespDistribucionNuevo.BindearPropiedadControl = "SelectedValue"
      Me.cmbRespDistribucionNuevo.BindearPropiedadEntidad = "TipoCliente.IdTipoCliente"
        Me.cmbRespDistribucionNuevo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbRespDistribucionNuevo.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbRespDistribucionNuevo.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbRespDistribucionNuevo.FormattingEnabled = True
        Me.cmbRespDistribucionNuevo.IsPK = False
        Me.cmbRespDistribucionNuevo.IsRequired = True
        Me.cmbRespDistribucionNuevo.Key = Nothing
        Me.cmbRespDistribucionNuevo.LabelAsoc = Nothing
        Me.cmbRespDistribucionNuevo.Location = New System.Drawing.Point(429, 128)
        Me.cmbRespDistribucionNuevo.Name = "cmbRespDistribucionNuevo"
        Me.cmbRespDistribucionNuevo.Size = New System.Drawing.Size(181, 21)
        Me.cmbRespDistribucionNuevo.TabIndex = 72
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(261, 131)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(162, 13)
        Me.Label4.TabIndex = 71
        Me.Label4.Text = "Responsable Distribución Nuevo"
        '
        'cmbRespDistribucion
        '
        Me.cmbRespDistribucion.BindearPropiedadControl = "SelectedValue"
      Me.cmbRespDistribucion.BindearPropiedadEntidad = "TipoCliente.IdTipoCliente"
        Me.cmbRespDistribucion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbRespDistribucion.Enabled = False
        Me.cmbRespDistribucion.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbRespDistribucion.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbRespDistribucion.FormattingEnabled = True
        Me.cmbRespDistribucion.IsPK = False
        Me.cmbRespDistribucion.IsRequired = True
        Me.cmbRespDistribucion.Key = Nothing
        Me.cmbRespDistribucion.LabelAsoc = Nothing
        Me.cmbRespDistribucion.Location = New System.Drawing.Point(429, 92)
        Me.cmbRespDistribucion.Name = "cmbRespDistribucion"
        Me.cmbRespDistribucion.Size = New System.Drawing.Size(181, 21)
        Me.cmbRespDistribucion.TabIndex = 70
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(261, 95)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(127, 13)
        Me.Label5.TabIndex = 69
        Me.Label5.Text = "Responsable Distribución"
        '
        'CambiarFechaEnvioyRespDist
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(635, 193)
        Me.Controls.Add(Me.cmbRespDistribucionNuevo)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.cmbRespDistribucion)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.dtpFechaEnvioNueva)
        Me.Controls.Add(Me.dtpFechaEnvio)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtLetra)
        Me.Controls.Add(Me.txtNumeroComprobante)
        Me.Controls.Add(Me.txtIdTipoComprobante)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.tstBarra)
        Me.Name = "CambiarFechaEnvioyRespDist"
        Me.Text = "CambiarFechaEnvioyRespDist"
        Me.tstBarra.ResumeLayout(False)
        Me.tstBarra.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Public WithEvents tstBarra As System.Windows.Forms.ToolStrip
    Public WithEvents tsbGrabar As System.Windows.Forms.ToolStripButton
    Private WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Public WithEvents tsbCerrar As System.Windows.Forms.ToolStripButton
    Friend WithEvents dtpFechaEnvioNueva As Eniac.Controles.DateTimePicker
    Friend WithEvents dtpFechaEnvio As Eniac.Controles.DateTimePicker
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtLetra As System.Windows.Forms.TextBox
    Friend WithEvents txtNumeroComprobante As System.Windows.Forms.TextBox
    Friend WithEvents txtIdTipoComprobante As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cmbRespDistribucionNuevo As Eniac.Controles.ComboBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents cmbRespDistribucion As Eniac.Controles.ComboBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
End Class
