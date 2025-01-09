<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Sincronizacion
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
      Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Sincronizacion))
      Me.btnSincronizar = New Eniac.Controles.Button
      Me.lblSucursalOrigen = New Eniac.Controles.Label
      Me.txtSucursalOrigen = New Eniac.Controles.TextBox
      Me.lblDatosAEnviar = New Eniac.Controles.Label
      Me.txtDatosAEnviar = New Eniac.Controles.TextBox
      Me.ToolStrip1 = New System.Windows.Forms.ToolStrip
      Me.tsbSalir = New System.Windows.Forms.ToolStripButton
      Me.lblProcesando = New Eniac.Controles.Label
      Me.prbProgreso = New System.Windows.Forms.ProgressBar
      Me.txtDatosRecibidos = New Eniac.Controles.TextBox
      Me.lblDatosRecibidos = New Eniac.Controles.Label
      Me.lblHaciendo = New Eniac.Controles.Label
      Me.ToolStrip1.SuspendLayout()
      Me.SuspendLayout()
      '
      'btnSincronizar
      '
      Me.btnSincronizar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.btnSincronizar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
      Me.btnSincronizar.Location = New System.Drawing.Point(154, 173)
      Me.btnSincronizar.Name = "btnSincronizar"
      Me.btnSincronizar.Size = New System.Drawing.Size(169, 67)
      Me.btnSincronizar.TabIndex = 0
      Me.btnSincronizar.Text = "Sincronizar"
      Me.btnSincronizar.UseVisualStyleBackColor = True
      '
      'lblSucursalOrigen
      '
      Me.lblSucursalOrigen.AutoSize = True
      Me.lblSucursalOrigen.Location = New System.Drawing.Point(12, 55)
      Me.lblSucursalOrigen.Name = "lblSucursalOrigen"
      Me.lblSucursalOrigen.Size = New System.Drawing.Size(85, 13)
      Me.lblSucursalOrigen.TabIndex = 1
      Me.lblSucursalOrigen.Text = "Sucursal Origen:"
      '
      'txtSucursalOrigen
      '
      Me.txtSucursalOrigen.BindearPropiedadControl = Nothing
      Me.txtSucursalOrigen.BindearPropiedadEntidad = Nothing
      Me.txtSucursalOrigen.Enabled = False
      Me.txtSucursalOrigen.ForeColorFocus = System.Drawing.Color.Red
      Me.txtSucursalOrigen.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtSucursalOrigen.Formato = ""
      Me.txtSucursalOrigen.IsDecimal = False
      Me.txtSucursalOrigen.IsNumber = False
      Me.txtSucursalOrigen.IsPK = False
      Me.txtSucursalOrigen.IsRequired = False
      Me.txtSucursalOrigen.Key = ""
      Me.txtSucursalOrigen.LabelAsoc = Me.lblSucursalOrigen
      Me.txtSucursalOrigen.Location = New System.Drawing.Point(94, 48)
      Me.txtSucursalOrigen.Name = "txtSucursalOrigen"
      Me.txtSucursalOrigen.Size = New System.Drawing.Size(229, 20)
      Me.txtSucursalOrigen.TabIndex = 2
      '
      'lblDatosAEnviar
      '
      Me.lblDatosAEnviar.AutoSize = True
      Me.lblDatosAEnviar.Location = New System.Drawing.Point(12, 83)
      Me.lblDatosAEnviar.Name = "lblDatosAEnviar"
      Me.lblDatosAEnviar.Size = New System.Drawing.Size(79, 13)
      Me.lblDatosAEnviar.TabIndex = 3
      Me.lblDatosAEnviar.Text = "Datos a enviar:"
      '
      'txtDatosAEnviar
      '
      Me.txtDatosAEnviar.BindearPropiedadControl = Nothing
      Me.txtDatosAEnviar.BindearPropiedadEntidad = Nothing
      Me.txtDatosAEnviar.Enabled = False
      Me.txtDatosAEnviar.ForeColorFocus = System.Drawing.Color.Red
      Me.txtDatosAEnviar.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtDatosAEnviar.Formato = ""
      Me.txtDatosAEnviar.IsDecimal = False
      Me.txtDatosAEnviar.IsNumber = False
      Me.txtDatosAEnviar.IsPK = False
      Me.txtDatosAEnviar.IsRequired = False
      Me.txtDatosAEnviar.Key = ""
      Me.txtDatosAEnviar.LabelAsoc = Me.lblDatosAEnviar
      Me.txtDatosAEnviar.Location = New System.Drawing.Point(94, 76)
      Me.txtDatosAEnviar.Name = "txtDatosAEnviar"
      Me.txtDatosAEnviar.Size = New System.Drawing.Size(52, 20)
      Me.txtDatosAEnviar.TabIndex = 4
      Me.txtDatosAEnviar.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'ToolStrip1
      '
      Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsbSalir})
      Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
      Me.ToolStrip1.Name = "ToolStrip1"
      Me.ToolStrip1.Size = New System.Drawing.Size(335, 25)
      Me.ToolStrip1.TabIndex = 5
      Me.ToolStrip1.Text = "ToolStrip1"
      '
      'tsbSalir
      '
      Me.tsbSalir.Image = Global.Eniac.Win.My.Resources.Resources.redo
      Me.tsbSalir.ImageTransparentColor = System.Drawing.Color.Magenta
      Me.tsbSalir.Name = "tsbSalir"
      Me.tsbSalir.Size = New System.Drawing.Size(59, 22)
      Me.tsbSalir.Text = "&Cerrar"
      '
      'lblProcesando
      '
      Me.lblProcesando.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.lblProcesando.AutoSize = True
      Me.lblProcesando.Location = New System.Drawing.Point(12, 149)
      Me.lblProcesando.Name = "lblProcesando"
      Me.lblProcesando.Size = New System.Drawing.Size(73, 13)
      Me.lblProcesando.TabIndex = 6
      Me.lblProcesando.Text = "Procesando..."
      '
      'prbProgreso
      '
      Me.prbProgreso.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.prbProgreso.Location = New System.Drawing.Point(94, 139)
      Me.prbProgreso.Name = "prbProgreso"
      Me.prbProgreso.Size = New System.Drawing.Size(229, 23)
      Me.prbProgreso.TabIndex = 7
      '
      'txtDatosRecibidos
      '
      Me.txtDatosRecibidos.BindearPropiedadControl = Nothing
      Me.txtDatosRecibidos.BindearPropiedadEntidad = Nothing
      Me.txtDatosRecibidos.Enabled = False
      Me.txtDatosRecibidos.ForeColorFocus = System.Drawing.Color.Red
      Me.txtDatosRecibidos.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtDatosRecibidos.Formato = ""
      Me.txtDatosRecibidos.IsDecimal = False
      Me.txtDatosRecibidos.IsNumber = False
      Me.txtDatosRecibidos.IsPK = False
      Me.txtDatosRecibidos.IsRequired = False
      Me.txtDatosRecibidos.Key = ""
      Me.txtDatosRecibidos.LabelAsoc = Me.lblDatosRecibidos
      Me.txtDatosRecibidos.Location = New System.Drawing.Point(94, 104)
      Me.txtDatosRecibidos.Name = "txtDatosRecibidos"
      Me.txtDatosRecibidos.Size = New System.Drawing.Size(52, 20)
      Me.txtDatosRecibidos.TabIndex = 9
      Me.txtDatosRecibidos.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'lblDatosRecibidos
      '
      Me.lblDatosRecibidos.AutoSize = True
      Me.lblDatosRecibidos.Location = New System.Drawing.Point(12, 111)
      Me.lblDatosRecibidos.Name = "lblDatosRecibidos"
      Me.lblDatosRecibidos.Size = New System.Drawing.Size(83, 13)
      Me.lblDatosRecibidos.TabIndex = 8
      Me.lblDatosRecibidos.Text = "Datos recibidos:"
      '
      'lblHaciendo
      '
      Me.lblHaciendo.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.lblHaciendo.AutoSize = True
      Me.lblHaciendo.Location = New System.Drawing.Point(171, 122)
      Me.lblHaciendo.Name = "lblHaciendo"
      Me.lblHaciendo.Size = New System.Drawing.Size(0, 13)
      Me.lblHaciendo.TabIndex = 10
      '
      'Sincronizacion
      '
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.ClientSize = New System.Drawing.Size(335, 252)
      Me.Controls.Add(Me.lblHaciendo)
      Me.Controls.Add(Me.txtDatosRecibidos)
      Me.Controls.Add(Me.lblDatosRecibidos)
      Me.Controls.Add(Me.prbProgreso)
      Me.Controls.Add(Me.lblProcesando)
      Me.Controls.Add(Me.ToolStrip1)
      Me.Controls.Add(Me.txtDatosAEnviar)
      Me.Controls.Add(Me.lblDatosAEnviar)
      Me.Controls.Add(Me.txtSucursalOrigen)
      Me.Controls.Add(Me.lblSucursalOrigen)
      Me.Controls.Add(Me.btnSincronizar)
      Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
      Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
      Me.KeyPreview = True
      Me.MaximizeBox = False
      Me.MinimizeBox = False
      Me.Name = "Sincronizacion"
      Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
      Me.Text = "Sincronización"
      Me.ToolStrip1.ResumeLayout(False)
      Me.ToolStrip1.PerformLayout()
      Me.ResumeLayout(False)
      Me.PerformLayout()

   End Sub
   Friend WithEvents btnSincronizar As Eniac.Controles.Button
   Friend WithEvents lblSucursalOrigen As Eniac.Controles.Label
   Friend WithEvents txtSucursalOrigen As Eniac.Controles.TextBox
   Friend WithEvents lblDatosAEnviar As Eniac.Controles.Label
   Friend WithEvents txtDatosAEnviar As Eniac.Controles.TextBox
   Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
   Friend WithEvents tsbSalir As System.Windows.Forms.ToolStripButton
   Friend WithEvents lblProcesando As Eniac.Controles.Label
   Friend WithEvents prbProgreso As System.Windows.Forms.ProgressBar
   Friend WithEvents txtDatosRecibidos As Eniac.Controles.TextBox
   Friend WithEvents lblDatosRecibidos As Eniac.Controles.Label
   Friend WithEvents lblHaciendo As Eniac.Controles.Label
End Class
