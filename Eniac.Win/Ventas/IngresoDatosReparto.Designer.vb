<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class IngresoDatosReparto
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
      Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(IngresoDatosReparto))
      Me.bscTransportista = New Eniac.Controles.Buscador()
      Me.lblTransportista = New Eniac.Controles.Label()
      Me.Label1 = New Eniac.Controles.Label()
      Me.txtNumero = New Eniac.Controles.TextBox()
      Me.Label2 = New Eniac.Controles.Label()
      Me.dtpDesde = New Eniac.Controles.DateTimePicker()
      Me.tstBarra = New System.Windows.Forms.ToolStrip()
      Me.tsbGrabar = New System.Windows.Forms.ToolStripButton()
      Me.tss4 = New System.Windows.Forms.ToolStripSeparator()
      Me.tsbSalir = New System.Windows.Forms.ToolStripButton()
      Me.tstBarra.SuspendLayout()
      Me.SuspendLayout()
      '
      'bscTransportista
      '
      Me.bscTransportista.AutoSize = True
      Me.bscTransportista.AyudaAncho = 140
      Me.bscTransportista.BindearPropiedadControl = Nothing
      Me.bscTransportista.BindearPropiedadEntidad = Nothing
      Me.bscTransportista.ColumnasAlineacion = Nothing
      Me.bscTransportista.ColumnasAncho = Nothing
      Me.bscTransportista.ColumnasFormato = Nothing
      Me.bscTransportista.ColumnasOcultas = Nothing
      Me.bscTransportista.ColumnasTitulos = Nothing
      Me.bscTransportista.Datos = Nothing
      Me.bscTransportista.FilaDevuelta = Nothing
      Me.bscTransportista.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.bscTransportista.ForeColorFocus = System.Drawing.Color.Red
      Me.bscTransportista.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
      Me.bscTransportista.IsDecimal = False
      Me.bscTransportista.IsNumber = False
      Me.bscTransportista.IsPK = False
      Me.bscTransportista.IsRequired = False
      Me.bscTransportista.Key = ""
      Me.bscTransportista.LabelAsoc = Me.lblTransportista
      Me.bscTransportista.Location = New System.Drawing.Point(87, 94)
      Me.bscTransportista.Margin = New System.Windows.Forms.Padding(4)
      Me.bscTransportista.MaxLengh = "32767"
      Me.bscTransportista.Name = "bscTransportista"
      Me.bscTransportista.Permitido = True
      Me.bscTransportista.Selecciono = False
      Me.bscTransportista.Size = New System.Drawing.Size(303, 23)
      Me.bscTransportista.TabIndex = 7
      Me.bscTransportista.Titulo = Nothing
      '
      'lblTransportista
      '
      Me.lblTransportista.AutoSize = True
      Me.lblTransportista.ForeColor = System.Drawing.SystemColors.ControlText
      Me.lblTransportista.Location = New System.Drawing.Point(13, 96)
      Me.lblTransportista.Name = "lblTransportista"
      Me.lblTransportista.Size = New System.Drawing.Size(68, 13)
      Me.lblTransportista.TabIndex = 6
      Me.lblTransportista.Text = "Transportista"
      '
      'Label1
      '
      Me.Label1.AutoSize = True
      Me.Label1.ForeColor = System.Drawing.SystemColors.ControlText
      Me.Label1.Location = New System.Drawing.Point(13, 61)
      Me.Label1.Name = "Label1"
      Me.Label1.Size = New System.Drawing.Size(68, 13)
      Me.Label1.TabIndex = 8
      Me.Label1.Text = "Nro. Reparto"
      '
      'txtNumero
      '
      Me.txtNumero.BindearPropiedadControl = Nothing
      Me.txtNumero.BindearPropiedadEntidad = Nothing
      Me.txtNumero.Enabled = False
      Me.txtNumero.ForeColorFocus = System.Drawing.Color.Red
      Me.txtNumero.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtNumero.Formato = "##0"
      Me.txtNumero.IsDecimal = False
      Me.txtNumero.IsNumber = True
      Me.txtNumero.IsPK = False
      Me.txtNumero.IsRequired = False
      Me.txtNumero.Key = ""
      Me.txtNumero.LabelAsoc = Nothing
      Me.txtNumero.Location = New System.Drawing.Point(87, 58)
      Me.txtNumero.MaxLength = 8
      Me.txtNumero.Name = "txtNumero"
      Me.txtNumero.ReadOnly = True
      Me.txtNumero.Size = New System.Drawing.Size(73, 20)
      Me.txtNumero.TabIndex = 9
      Me.txtNumero.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'Label2
      '
      Me.Label2.AutoSize = True
      Me.Label2.ForeColor = System.Drawing.SystemColors.ControlText
      Me.Label2.Location = New System.Drawing.Point(13, 133)
      Me.Label2.Name = "Label2"
      Me.Label2.Size = New System.Drawing.Size(69, 13)
      Me.Label2.TabIndex = 10
      Me.Label2.Text = "Fecha Envío"
      '
      'dtpDesde
      '
      Me.dtpDesde.BindearPropiedadControl = Nothing
      Me.dtpDesde.BindearPropiedadEntidad = Nothing
      Me.dtpDesde.CustomFormat = "dd/MM/yyyy HH:mm"
      Me.dtpDesde.ForeColorFocus = System.Drawing.Color.Red
      Me.dtpDesde.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.dtpDesde.Format = System.Windows.Forms.DateTimePickerFormat.Custom
      Me.dtpDesde.IsPK = False
      Me.dtpDesde.IsRequired = False
      Me.dtpDesde.Key = ""
      Me.dtpDesde.LabelAsoc = Nothing
      Me.dtpDesde.Location = New System.Drawing.Point(87, 129)
      Me.dtpDesde.Name = "dtpDesde"
      Me.dtpDesde.Size = New System.Drawing.Size(125, 20)
      Me.dtpDesde.TabIndex = 11
      '
      'tstBarra
      '
      Me.tstBarra.AllowItemReorder = True
      Me.tstBarra.ImageScalingSize = New System.Drawing.Size(22, 22)
      Me.tstBarra.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsbGrabar, Me.tss4, Me.tsbSalir})
      Me.tstBarra.Location = New System.Drawing.Point(0, 0)
      Me.tstBarra.Name = "tstBarra"
      Me.tstBarra.Size = New System.Drawing.Size(409, 29)
      Me.tstBarra.TabIndex = 12
      Me.tstBarra.Text = "toolStrip1"
      '
      'tsbGrabar
      '
      Me.tsbGrabar.Image = Global.Eniac.Win.My.Resources.Resources.diskette_32
      Me.tsbGrabar.ImageTransparentColor = System.Drawing.Color.Magenta
      Me.tsbGrabar.Name = "tsbGrabar"
      Me.tsbGrabar.Size = New System.Drawing.Size(68, 26)
      Me.tsbGrabar.Text = "Grabar"
      Me.tsbGrabar.ToolTipText = "Imprimir"
      '
      'tss4
      '
      Me.tss4.Name = "tss4"
      Me.tss4.Size = New System.Drawing.Size(6, 29)
      '
      'tsbSalir
      '
      Me.tsbSalir.Image = Global.Eniac.Win.My.Resources.Resources.close_b_32
      Me.tsbSalir.ImageTransparentColor = System.Drawing.Color.Magenta
      Me.tsbSalir.Name = "tsbSalir"
      Me.tsbSalir.Size = New System.Drawing.Size(79, 26)
      Me.tsbSalir.Text = "&Cancelar"
      Me.tsbSalir.ToolTipText = "Cerrar el formulario"
      '
      'IngresoDatosReparto
      '
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.ClientSize = New System.Drawing.Size(409, 178)
      Me.Controls.Add(Me.tstBarra)
      Me.Controls.Add(Me.dtpDesde)
      Me.Controls.Add(Me.Label2)
      Me.Controls.Add(Me.txtNumero)
      Me.Controls.Add(Me.Label1)
      Me.Controls.Add(Me.bscTransportista)
      Me.Controls.Add(Me.lblTransportista)
      Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
      Me.Name = "IngresoDatosReparto"
      Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
      Me.Text = "Ingreso de Datos del Reparto"
      Me.tstBarra.ResumeLayout(False)
      Me.tstBarra.PerformLayout()
      Me.ResumeLayout(False)
      Me.PerformLayout()

   End Sub
   Friend WithEvents bscTransportista As Eniac.Controles.Buscador
   Friend WithEvents lblTransportista As Eniac.Controles.Label
   Friend WithEvents Label1 As Eniac.Controles.Label
   Friend WithEvents txtNumero As Eniac.Controles.TextBox
   Friend WithEvents Label2 As Eniac.Controles.Label
   Friend WithEvents dtpDesde As Eniac.Controles.DateTimePicker
   Public WithEvents tstBarra As System.Windows.Forms.ToolStrip
   Friend WithEvents tsbGrabar As System.Windows.Forms.ToolStripButton
   Private WithEvents tss4 As System.Windows.Forms.ToolStripSeparator
   Public WithEvents tsbSalir As System.Windows.Forms.ToolStripButton
End Class
