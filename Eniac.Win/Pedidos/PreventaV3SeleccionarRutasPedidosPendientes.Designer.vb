<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PreventaV3SeleccionarRutasPedidosPendientes
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
      Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(PreventaV3SeleccionarRutasPedidosPendientes))
      Me.imageList1 = New System.Windows.Forms.ImageList(Me.components)
      Me.btnAceptar = New System.Windows.Forms.Button()
      Me.btnCancelar = New System.Windows.Forms.Button()
      Me.radTodas = New Eniac.Controles.RadioButton()
      Me.radSeleccionadas = New Eniac.Controles.RadioButton()
      Me.chbRutas = New Eniac.Controles.CheckedListBox()
      Me.bkwObtenerRutas = New System.ComponentModel.BackgroundWorker()
      Me.lblEstadoAvance = New Eniac.Controles.Label()
      Me.lblTiposComprobantesFact = New Eniac.Controles.Label()
      Me.cmbTiposComprobantesFact = New Eniac.Win.ComboBoxTiposComprobantes()
      Me.SuspendLayout()
      '
      'imageList1
      '
      Me.imageList1.ImageStream = CType(resources.GetObject("imageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
      Me.imageList1.TransparentColor = System.Drawing.Color.Transparent
      Me.imageList1.Images.SetKeyName(0, "check2.ico")
      Me.imageList1.Images.SetKeyName(1, "delete2.ico")
      '
      'btnAceptar
      '
      Me.btnAceptar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.btnAceptar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
      Me.btnAceptar.ImageIndex = 0
      Me.btnAceptar.ImageList = Me.imageList1
      Me.btnAceptar.Location = New System.Drawing.Point(169, 384)
      Me.btnAceptar.Name = "btnAceptar"
      Me.btnAceptar.Size = New System.Drawing.Size(80, 30)
      Me.btnAceptar.TabIndex = 5
      Me.btnAceptar.Text = "&Aceptar"
      Me.btnAceptar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      Me.btnAceptar.UseVisualStyleBackColor = True
      '
      'btnCancelar
      '
      Me.btnCancelar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel
      Me.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
      Me.btnCancelar.ImageIndex = 1
      Me.btnCancelar.ImageList = Me.imageList1
      Me.btnCancelar.Location = New System.Drawing.Point(255, 384)
      Me.btnCancelar.Name = "btnCancelar"
      Me.btnCancelar.Size = New System.Drawing.Size(80, 30)
      Me.btnCancelar.TabIndex = 4
      Me.btnCancelar.Text = "&Cancelar"
      Me.btnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      Me.btnCancelar.UseVisualStyleBackColor = True
      '
      'radTodas
      '
      Me.radTodas.AutoSize = True
      Me.radTodas.BindearPropiedadControl = Nothing
      Me.radTodas.BindearPropiedadEntidad = Nothing
      Me.radTodas.Checked = True
      Me.radTodas.ForeColorFocus = System.Drawing.Color.Red
      Me.radTodas.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
      Me.radTodas.IsPK = False
      Me.radTodas.IsRequired = False
      Me.radTodas.Key = Nothing
      Me.radTodas.LabelAsoc = Nothing
      Me.radTodas.Location = New System.Drawing.Point(12, 12)
      Me.radTodas.Name = "radTodas"
      Me.radTodas.Size = New System.Drawing.Size(152, 17)
      Me.radTodas.TabIndex = 6
      Me.radTodas.TabStop = True
      Me.radTodas.Text = "Todas las rutas disponibles"
      Me.radTodas.UseVisualStyleBackColor = True
      '
      'radSeleccionadas
      '
      Me.radSeleccionadas.AutoSize = True
      Me.radSeleccionadas.BindearPropiedadControl = Nothing
      Me.radSeleccionadas.BindearPropiedadEntidad = Nothing
      Me.radSeleccionadas.ForeColorFocus = System.Drawing.Color.Red
      Me.radSeleccionadas.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
      Me.radSeleccionadas.IsPK = False
      Me.radSeleccionadas.IsRequired = False
      Me.radSeleccionadas.Key = Nothing
      Me.radSeleccionadas.LabelAsoc = Nothing
      Me.radSeleccionadas.Location = New System.Drawing.Point(12, 35)
      Me.radSeleccionadas.Name = "radSeleccionadas"
      Me.radSeleccionadas.Size = New System.Drawing.Size(232, 17)
      Me.radSeleccionadas.TabIndex = 7
      Me.radSeleccionadas.Text = "Solo las rutas seleccionadas a continuación"
      Me.radSeleccionadas.UseVisualStyleBackColor = True
      '
      'chbRutas
      '
      Me.chbRutas.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.chbRutas.CheckOnClick = True
      Me.chbRutas.ForeColorFocus = System.Drawing.Color.Red
      Me.chbRutas.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.chbRutas.FormattingEnabled = True
      Me.chbRutas.IsPK = False
      Me.chbRutas.IsRequired = False
      Me.chbRutas.Key = Nothing
      Me.chbRutas.LabelAsoc = Nothing
      Me.chbRutas.Location = New System.Drawing.Point(12, 58)
      Me.chbRutas.Name = "chbRutas"
      Me.chbRutas.Size = New System.Drawing.Size(323, 289)
      Me.chbRutas.TabIndex = 8
      '
      'bkwObtenerRutas
      '
      Me.bkwObtenerRutas.WorkerReportsProgress = True
      Me.bkwObtenerRutas.WorkerSupportsCancellation = True
      '
      'lblEstadoAvance
      '
      Me.lblEstadoAvance.BackColor = System.Drawing.SystemColors.Window
      Me.lblEstadoAvance.LabelAsoc = Nothing
      Me.lblEstadoAvance.Location = New System.Drawing.Point(14, 80)
      Me.lblEstadoAvance.Name = "lblEstadoAvance"
      Me.lblEstadoAvance.Size = New System.Drawing.Size(319, 25)
      Me.lblEstadoAvance.TabIndex = 9
      Me.lblEstadoAvance.Text = "Cargando..."
      Me.lblEstadoAvance.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
      '
      'lblTiposComprobantesFact
      '
      Me.lblTiposComprobantesFact.Anchor = System.Windows.Forms.AnchorStyles.Bottom
      Me.lblTiposComprobantesFact.AutoSize = True
      Me.lblTiposComprobantesFact.ImeMode = System.Windows.Forms.ImeMode.NoControl
      Me.lblTiposComprobantesFact.LabelAsoc = Nothing
      Me.lblTiposComprobantesFact.Location = New System.Drawing.Point(11, 358)
      Me.lblTiposComprobantesFact.Name = "lblTiposComprobantesFact"
      Me.lblTiposComprobantesFact.Size = New System.Drawing.Size(121, 13)
      Me.lblTiposComprobantesFact.TabIndex = 65
      Me.lblTiposComprobantesFact.Text = "Comprobante a Facturar"
      '
      'cmbTiposComprobantesFact
      '
      Me.cmbTiposComprobantesFact.BindearPropiedadControl = Nothing
      Me.cmbTiposComprobantesFact.BindearPropiedadEntidad = Nothing
      Me.cmbTiposComprobantesFact.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cmbTiposComprobantesFact.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
      Me.cmbTiposComprobantesFact.ForeColorFocus = System.Drawing.Color.Red
      Me.cmbTiposComprobantesFact.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.cmbTiposComprobantesFact.FormattingEnabled = True
      Me.cmbTiposComprobantesFact.IsPK = False
      Me.cmbTiposComprobantesFact.IsRequired = False
      Me.cmbTiposComprobantesFact.ItemHeight = 13
      Me.cmbTiposComprobantesFact.Key = Nothing
      Me.cmbTiposComprobantesFact.LabelAsoc = Nothing
      Me.cmbTiposComprobantesFact.Location = New System.Drawing.Point(138, 355)
      Me.cmbTiposComprobantesFact.Name = "cmbTiposComprobantesFact"
      Me.cmbTiposComprobantesFact.Size = New System.Drawing.Size(197, 21)
      Me.cmbTiposComprobantesFact.TabIndex = 66
      '
      'PreventaV3SeleccionarRutasPedidosPendientes
      '
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.ClientSize = New System.Drawing.Size(347, 426)
      Me.Controls.Add(Me.cmbTiposComprobantesFact)
      Me.Controls.Add(Me.lblTiposComprobantesFact)
      Me.Controls.Add(Me.lblEstadoAvance)
      Me.Controls.Add(Me.chbRutas)
      Me.Controls.Add(Me.radSeleccionadas)
      Me.Controls.Add(Me.radTodas)
      Me.Controls.Add(Me.btnAceptar)
      Me.Controls.Add(Me.btnCancelar)
      Me.Name = "PreventaV3SeleccionarRutasPedidosPendientes"
      Me.ShowInTaskbar = False
      Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
      Me.Text = "Selección de Rutas a descargar"
      Me.ResumeLayout(False)
      Me.PerformLayout()

   End Sub
   Private WithEvents imageList1 As System.Windows.Forms.ImageList
   Protected WithEvents btnAceptar As System.Windows.Forms.Button
   Protected WithEvents btnCancelar As System.Windows.Forms.Button
   Friend WithEvents radTodas As Eniac.Controles.RadioButton
   Friend WithEvents radSeleccionadas As Eniac.Controles.RadioButton
   Friend WithEvents chbRutas As Eniac.Controles.CheckedListBox
   Friend WithEvents bkwObtenerRutas As System.ComponentModel.BackgroundWorker
   Friend WithEvents lblEstadoAvance As Eniac.Controles.Label
    Friend WithEvents lblTiposComprobantesFact As Controles.Label
   Friend WithEvents cmbTiposComprobantesFact As ComboBoxTiposComprobantes
End Class
