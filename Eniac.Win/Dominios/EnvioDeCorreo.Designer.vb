<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class EnvioDeCorreo
   Inherits BaseForm

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
      Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(EnvioDeCorreo))
      Me.tstBarra = New System.Windows.Forms.ToolStrip()
      Me.tsbRefrescar = New System.Windows.Forms.ToolStripButton()
      Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
      Me.tsbEnviarCorreos = New System.Windows.Forms.ToolStripButton()
      Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
      Me.tsbSalir = New System.Windows.Forms.ToolStripButton()
      Me.rtbCuerpoMail = New System.Windows.Forms.RichTextBox()
      Me.lblCuerpo = New Eniac.Controles.Label()
      Me.lblAsunto = New Eniac.Controles.Label()
      Me.grbEnvio = New System.Windows.Forms.GroupBox()
      Me.txtCorreo = New System.Windows.Forms.TextBox()
      Me.lblCorreo = New Eniac.Controles.Label()
      Me.btnExaminar4 = New Eniac.Controles.Button()
      Me.txtArchivo4 = New Eniac.Controles.TextBox()
      Me.lblArchivo4 = New Eniac.Controles.Label()
      Me.btnExaminar3 = New Eniac.Controles.Button()
      Me.txtArchivo3 = New Eniac.Controles.TextBox()
      Me.lblArchivo3 = New Eniac.Controles.Label()
      Me.btnExaminar2 = New Eniac.Controles.Button()
      Me.txtArchivo2 = New Eniac.Controles.TextBox()
      Me.lblArchivo2 = New Eniac.Controles.Label()
      Me.btnExaminar1 = New Eniac.Controles.Button()
      Me.txtArchivo1 = New Eniac.Controles.TextBox()
      Me.lblArchivo1 = New Eniac.Controles.Label()
      Me.txtAsuntoMail = New System.Windows.Forms.TextBox()
      Me.stsStado = New System.Windows.Forms.StatusStrip()
      Me.tslTexto = New System.Windows.Forms.ToolStripStatusLabel()
      Me.tspBarra = New System.Windows.Forms.ToolStripProgressBar()
      Me.tssRegistros = New System.Windows.Forms.ToolStripStatusLabel()
      Me.tstBarra.SuspendLayout()
      Me.grbEnvio.SuspendLayout()
      Me.stsStado.SuspendLayout()
      Me.SuspendLayout()
      '
      'tstBarra
      '
      Me.tstBarra.AllowItemReorder = True
      Me.tstBarra.ImageScalingSize = New System.Drawing.Size(22, 22)
      Me.tstBarra.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsbRefrescar, Me.ToolStripSeparator1, Me.tsbEnviarCorreos, Me.ToolStripSeparator2, Me.tsbSalir})
      Me.tstBarra.Location = New System.Drawing.Point(0, 0)
      Me.tstBarra.Name = "tstBarra"
      Me.tstBarra.Size = New System.Drawing.Size(541, 29)
      Me.tstBarra.TabIndex = 5
      Me.tstBarra.Text = "toolStrip1"
      '
      'tsbRefrescar
      '
      Me.tsbRefrescar.Image = CType(resources.GetObject("tsbRefrescar.Image"), System.Drawing.Image)
      Me.tsbRefrescar.ImageTransparentColor = System.Drawing.Color.Magenta
      Me.tsbRefrescar.Name = "tsbRefrescar"
      Me.tsbRefrescar.Size = New System.Drawing.Size(104, 26)
      Me.tsbRefrescar.Text = "&Refrescar (F5)"
      '
      'ToolStripSeparator1
      '
      Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
      Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 29)
      '
      'tsbEnviarCorreos
      '
      Me.tsbEnviarCorreos.ForeColor = System.Drawing.Color.Black
      Me.tsbEnviarCorreos.Image = Global.Eniac.Win.My.Resources.Resources.mail_next_32
      Me.tsbEnviarCorreos.ImageTransparentColor = System.Drawing.Color.Magenta
      Me.tsbEnviarCorreos.Name = "tsbEnviarCorreos"
      Me.tsbEnviarCorreos.Size = New System.Drawing.Size(65, 26)
      Me.tsbEnviarCorreos.Text = "&Enviar"
      Me.tsbEnviarCorreos.ToolTipText = "Enviar Correos"
      '
      'ToolStripSeparator2
      '
      Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
      Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 29)
      '
      'tsbSalir
      '
      Me.tsbSalir.Image = CType(resources.GetObject("tsbSalir.Image"), System.Drawing.Image)
      Me.tsbSalir.ImageTransparentColor = System.Drawing.Color.Magenta
      Me.tsbSalir.Name = "tsbSalir"
      Me.tsbSalir.Size = New System.Drawing.Size(65, 26)
      Me.tsbSalir.Text = "&Cerrar"
      Me.tsbSalir.ToolTipText = "Cerrar el formulario"
      '
      'rtbCuerpoMail
      '
      Me.rtbCuerpoMail.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.rtbCuerpoMail.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
      Me.rtbCuerpoMail.Location = New System.Drawing.Point(60, 77)
      Me.rtbCuerpoMail.Name = "rtbCuerpoMail"
      Me.rtbCuerpoMail.Size = New System.Drawing.Size(432, 149)
      Me.rtbCuerpoMail.TabIndex = 3
      Me.rtbCuerpoMail.Text = ""
      '
      'lblCuerpo
      '
      Me.lblCuerpo.AutoSize = True
      Me.lblCuerpo.LabelAsoc = Nothing
      Me.lblCuerpo.Location = New System.Drawing.Point(16, 77)
      Me.lblCuerpo.Name = "lblCuerpo"
      Me.lblCuerpo.Size = New System.Drawing.Size(41, 13)
      Me.lblCuerpo.TabIndex = 2
      Me.lblCuerpo.Text = "Cuerpo"
      '
      'lblAsunto
      '
      Me.lblAsunto.AutoSize = True
      Me.lblAsunto.LabelAsoc = Nothing
      Me.lblAsunto.Location = New System.Drawing.Point(16, 50)
      Me.lblAsunto.Name = "lblAsunto"
      Me.lblAsunto.Size = New System.Drawing.Size(40, 13)
      Me.lblAsunto.TabIndex = 0
      Me.lblAsunto.Text = "Asunto"
      '
      'grbEnvio
      '
      Me.grbEnvio.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.grbEnvio.Controls.Add(Me.txtCorreo)
      Me.grbEnvio.Controls.Add(Me.lblCorreo)
      Me.grbEnvio.Controls.Add(Me.btnExaminar4)
      Me.grbEnvio.Controls.Add(Me.txtArchivo4)
      Me.grbEnvio.Controls.Add(Me.lblArchivo4)
      Me.grbEnvio.Controls.Add(Me.btnExaminar3)
      Me.grbEnvio.Controls.Add(Me.txtArchivo3)
      Me.grbEnvio.Controls.Add(Me.lblArchivo3)
      Me.grbEnvio.Controls.Add(Me.btnExaminar2)
      Me.grbEnvio.Controls.Add(Me.txtArchivo2)
      Me.grbEnvio.Controls.Add(Me.lblArchivo2)
      Me.grbEnvio.Controls.Add(Me.btnExaminar1)
      Me.grbEnvio.Controls.Add(Me.txtArchivo1)
      Me.grbEnvio.Controls.Add(Me.lblArchivo1)
      Me.grbEnvio.Controls.Add(Me.txtAsuntoMail)
      Me.grbEnvio.Controls.Add(Me.lblCuerpo)
      Me.grbEnvio.Controls.Add(Me.lblAsunto)
      Me.grbEnvio.Controls.Add(Me.rtbCuerpoMail)
      Me.grbEnvio.Location = New System.Drawing.Point(12, 41)
      Me.grbEnvio.Name = "grbEnvio"
      Me.grbEnvio.Size = New System.Drawing.Size(512, 346)
      Me.grbEnvio.TabIndex = 3
      Me.grbEnvio.TabStop = False
      Me.grbEnvio.Text = "Datos de Envío"
      '
      'txtCorreo
      '
      Me.txtCorreo.Location = New System.Drawing.Point(60, 21)
      Me.txtCorreo.Name = "txtCorreo"
      Me.txtCorreo.Size = New System.Drawing.Size(432, 20)
      Me.txtCorreo.TabIndex = 1
      '
      'lblCorreo
      '
      Me.lblCorreo.AutoSize = True
      Me.lblCorreo.LabelAsoc = Nothing
      Me.lblCorreo.Location = New System.Drawing.Point(16, 24)
      Me.lblCorreo.Name = "lblCorreo"
      Me.lblCorreo.Size = New System.Drawing.Size(38, 13)
      Me.lblCorreo.TabIndex = 6
      Me.lblCorreo.Text = "Correo"
      '
      'btnExaminar4
      '
      Me.btnExaminar4.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
      Me.btnExaminar4.Image = Global.Eniac.Win.My.Resources.Resources.add_16
      Me.btnExaminar4.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
      Me.btnExaminar4.Location = New System.Drawing.Point(410, 315)
      Me.btnExaminar4.Name = "btnExaminar4"
      Me.btnExaminar4.Size = New System.Drawing.Size(82, 20)
      Me.btnExaminar4.TabIndex = 15
      Me.btnExaminar4.Text = "Examinar"
      Me.btnExaminar4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      Me.btnExaminar4.UseVisualStyleBackColor = True
      '
      'txtArchivo4
      '
      Me.txtArchivo4.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
      Me.txtArchivo4.BindearPropiedadControl = "Text"
      Me.txtArchivo4.BindearPropiedadEntidad = "CantidadProductos"
      Me.txtArchivo4.ForeColorFocus = System.Drawing.Color.Red
      Me.txtArchivo4.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtArchivo4.Formato = ""
      Me.txtArchivo4.IsDecimal = False
      Me.txtArchivo4.IsNumber = False
      Me.txtArchivo4.IsPK = False
      Me.txtArchivo4.IsRequired = False
      Me.txtArchivo4.Key = ""
      Me.txtArchivo4.LabelAsoc = Me.lblArchivo4
      Me.txtArchivo4.Location = New System.Drawing.Point(60, 316)
      Me.txtArchivo4.Name = "txtArchivo4"
      Me.txtArchivo4.Size = New System.Drawing.Size(348, 20)
      Me.txtArchivo4.TabIndex = 14
      '
      'lblArchivo4
      '
      Me.lblArchivo4.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
      Me.lblArchivo4.AutoSize = True
      Me.lblArchivo4.LabelAsoc = Nothing
      Me.lblArchivo4.Location = New System.Drawing.Point(6, 320)
      Me.lblArchivo4.Name = "lblArchivo4"
      Me.lblArchivo4.Size = New System.Drawing.Size(52, 13)
      Me.lblArchivo4.TabIndex = 13
      Me.lblArchivo4.Text = "Archivo 4"
      '
      'btnExaminar3
      '
      Me.btnExaminar3.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
      Me.btnExaminar3.Image = Global.Eniac.Win.My.Resources.Resources.add_16
      Me.btnExaminar3.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
      Me.btnExaminar3.Location = New System.Drawing.Point(410, 288)
      Me.btnExaminar3.Name = "btnExaminar3"
      Me.btnExaminar3.Size = New System.Drawing.Size(82, 20)
      Me.btnExaminar3.TabIndex = 12
      Me.btnExaminar3.Text = "Examinar"
      Me.btnExaminar3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      Me.btnExaminar3.UseVisualStyleBackColor = True
      '
      'txtArchivo3
      '
      Me.txtArchivo3.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
      Me.txtArchivo3.BindearPropiedadControl = "Text"
      Me.txtArchivo3.BindearPropiedadEntidad = "CantidadProductos"
      Me.txtArchivo3.ForeColorFocus = System.Drawing.Color.Red
      Me.txtArchivo3.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtArchivo3.Formato = ""
      Me.txtArchivo3.IsDecimal = False
      Me.txtArchivo3.IsNumber = False
      Me.txtArchivo3.IsPK = False
      Me.txtArchivo3.IsRequired = False
      Me.txtArchivo3.Key = ""
      Me.txtArchivo3.LabelAsoc = Me.lblArchivo3
      Me.txtArchivo3.Location = New System.Drawing.Point(60, 289)
      Me.txtArchivo3.Name = "txtArchivo3"
      Me.txtArchivo3.Size = New System.Drawing.Size(348, 20)
      Me.txtArchivo3.TabIndex = 11
      '
      'lblArchivo3
      '
      Me.lblArchivo3.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
      Me.lblArchivo3.AutoSize = True
      Me.lblArchivo3.LabelAsoc = Nothing
      Me.lblArchivo3.Location = New System.Drawing.Point(6, 293)
      Me.lblArchivo3.Name = "lblArchivo3"
      Me.lblArchivo3.Size = New System.Drawing.Size(52, 13)
      Me.lblArchivo3.TabIndex = 10
      Me.lblArchivo3.Text = "Archivo 3"
      '
      'btnExaminar2
      '
      Me.btnExaminar2.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
      Me.btnExaminar2.Image = Global.Eniac.Win.My.Resources.Resources.add_16
      Me.btnExaminar2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
      Me.btnExaminar2.Location = New System.Drawing.Point(410, 261)
      Me.btnExaminar2.Name = "btnExaminar2"
      Me.btnExaminar2.Size = New System.Drawing.Size(82, 20)
      Me.btnExaminar2.TabIndex = 9
      Me.btnExaminar2.Text = "Examinar"
      Me.btnExaminar2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      Me.btnExaminar2.UseVisualStyleBackColor = True
      '
      'txtArchivo2
      '
      Me.txtArchivo2.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
      Me.txtArchivo2.BindearPropiedadControl = "Text"
      Me.txtArchivo2.BindearPropiedadEntidad = "CantidadProductos"
      Me.txtArchivo2.ForeColorFocus = System.Drawing.Color.Red
      Me.txtArchivo2.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtArchivo2.Formato = ""
      Me.txtArchivo2.IsDecimal = False
      Me.txtArchivo2.IsNumber = False
      Me.txtArchivo2.IsPK = False
      Me.txtArchivo2.IsRequired = False
      Me.txtArchivo2.Key = ""
      Me.txtArchivo2.LabelAsoc = Me.lblArchivo2
      Me.txtArchivo2.Location = New System.Drawing.Point(60, 262)
      Me.txtArchivo2.Name = "txtArchivo2"
      Me.txtArchivo2.Size = New System.Drawing.Size(348, 20)
      Me.txtArchivo2.TabIndex = 8
      '
      'lblArchivo2
      '
      Me.lblArchivo2.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
      Me.lblArchivo2.AutoSize = True
      Me.lblArchivo2.LabelAsoc = Nothing
      Me.lblArchivo2.Location = New System.Drawing.Point(6, 266)
      Me.lblArchivo2.Name = "lblArchivo2"
      Me.lblArchivo2.Size = New System.Drawing.Size(52, 13)
      Me.lblArchivo2.TabIndex = 7
      Me.lblArchivo2.Text = "Archivo 2"
      '
      'btnExaminar1
      '
      Me.btnExaminar1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
      Me.btnExaminar1.Image = Global.Eniac.Win.My.Resources.Resources.add_16
      Me.btnExaminar1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
      Me.btnExaminar1.Location = New System.Drawing.Point(410, 233)
      Me.btnExaminar1.Name = "btnExaminar1"
      Me.btnExaminar1.Size = New System.Drawing.Size(82, 20)
      Me.btnExaminar1.TabIndex = 6
      Me.btnExaminar1.Text = "Examinar"
      Me.btnExaminar1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      Me.btnExaminar1.UseVisualStyleBackColor = True
      '
      'txtArchivo1
      '
      Me.txtArchivo1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
      Me.txtArchivo1.BindearPropiedadControl = "Text"
      Me.txtArchivo1.BindearPropiedadEntidad = "CantidadProductos"
      Me.txtArchivo1.ForeColorFocus = System.Drawing.Color.Red
      Me.txtArchivo1.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtArchivo1.Formato = ""
      Me.txtArchivo1.IsDecimal = False
      Me.txtArchivo1.IsNumber = False
      Me.txtArchivo1.IsPK = False
      Me.txtArchivo1.IsRequired = False
      Me.txtArchivo1.Key = ""
      Me.txtArchivo1.LabelAsoc = Me.lblArchivo1
      Me.txtArchivo1.Location = New System.Drawing.Point(60, 234)
      Me.txtArchivo1.Name = "txtArchivo1"
      Me.txtArchivo1.Size = New System.Drawing.Size(348, 20)
      Me.txtArchivo1.TabIndex = 5
      '
      'lblArchivo1
      '
      Me.lblArchivo1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
      Me.lblArchivo1.AutoSize = True
      Me.lblArchivo1.LabelAsoc = Nothing
      Me.lblArchivo1.Location = New System.Drawing.Point(6, 238)
      Me.lblArchivo1.Name = "lblArchivo1"
      Me.lblArchivo1.Size = New System.Drawing.Size(52, 13)
      Me.lblArchivo1.TabIndex = 4
      Me.lblArchivo1.Text = "Archivo 1"
      '
      'txtAsuntoMail
      '
      Me.txtAsuntoMail.Location = New System.Drawing.Point(60, 47)
      Me.txtAsuntoMail.Name = "txtAsuntoMail"
      Me.txtAsuntoMail.Size = New System.Drawing.Size(432, 20)
      Me.txtAsuntoMail.TabIndex = 2
      '
      'stsStado
      '
      Me.stsStado.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tslTexto, Me.tspBarra, Me.tssRegistros})
      Me.stsStado.Location = New System.Drawing.Point(0, 405)
      Me.stsStado.Name = "stsStado"
      Me.stsStado.Size = New System.Drawing.Size(541, 22)
      Me.stsStado.TabIndex = 4
      Me.stsStado.Text = "statusStrip1"
      '
      'tslTexto
      '
      Me.tslTexto.Name = "tslTexto"
      Me.tslTexto.Size = New System.Drawing.Size(462, 17)
      Me.tslTexto.Spring = True
      '
      'tspBarra
      '
      Me.tspBarra.Name = "tspBarra"
      Me.tspBarra.Size = New System.Drawing.Size(100, 16)
      Me.tspBarra.Style = System.Windows.Forms.ProgressBarStyle.Continuous
      Me.tspBarra.Visible = False
      '
      'tssRegistros
      '
      Me.tssRegistros.Name = "tssRegistros"
      Me.tssRegistros.Size = New System.Drawing.Size(64, 17)
      Me.tssRegistros.Text = "0 Registros"
      '
      'EnvioDeCorreo
      '
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.ClientSize = New System.Drawing.Size(541, 427)
      Me.Controls.Add(Me.stsStado)
      Me.Controls.Add(Me.grbEnvio)
      Me.Controls.Add(Me.tstBarra)
      Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
      Me.KeyPreview = True
      Me.Name = "EnvioDeCorreo"
      Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
      Me.Text = "Envío de Correos"
      Me.tstBarra.ResumeLayout(False)
      Me.tstBarra.PerformLayout()
      Me.grbEnvio.ResumeLayout(False)
      Me.grbEnvio.PerformLayout()
      Me.stsStado.ResumeLayout(False)
      Me.stsStado.PerformLayout()
      Me.ResumeLayout(False)
      Me.PerformLayout()

   End Sub
   Public WithEvents tstBarra As System.Windows.Forms.ToolStrip
   Public WithEvents tsbRefrescar As System.Windows.Forms.ToolStripButton
   Private WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
   Friend WithEvents tsbEnviarCorreos As System.Windows.Forms.ToolStripButton
   Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
   Public WithEvents tsbSalir As System.Windows.Forms.ToolStripButton
   Friend WithEvents rtbCuerpoMail As System.Windows.Forms.RichTextBox
   Friend WithEvents lblCuerpo As Eniac.Controles.Label
   Friend WithEvents lblAsunto As Eniac.Controles.Label
   Friend WithEvents grbEnvio As System.Windows.Forms.GroupBox
   Friend WithEvents txtAsuntoMail As System.Windows.Forms.TextBox
   Protected Friend WithEvents stsStado As System.Windows.Forms.StatusStrip
   Protected Friend WithEvents tslTexto As System.Windows.Forms.ToolStripStatusLabel
   Protected Friend WithEvents tspBarra As System.Windows.Forms.ToolStripProgressBar
   Protected WithEvents tssRegistros As System.Windows.Forms.ToolStripStatusLabel
   Friend WithEvents txtArchivo1 As Eniac.Controles.TextBox
   Friend WithEvents lblArchivo1 As Eniac.Controles.Label
   Friend WithEvents btnExaminar1 As Eniac.Controles.Button
   Friend WithEvents btnExaminar4 As Eniac.Controles.Button
   Friend WithEvents txtArchivo4 As Eniac.Controles.TextBox
   Friend WithEvents lblArchivo4 As Eniac.Controles.Label
   Friend WithEvents btnExaminar3 As Eniac.Controles.Button
   Friend WithEvents txtArchivo3 As Eniac.Controles.TextBox
   Friend WithEvents lblArchivo3 As Eniac.Controles.Label
   Friend WithEvents btnExaminar2 As Eniac.Controles.Button
   Friend WithEvents txtArchivo2 As Eniac.Controles.TextBox
   Friend WithEvents lblArchivo2 As Eniac.Controles.Label
   Friend WithEvents txtCorreo As System.Windows.Forms.TextBox
   Friend WithEvents lblCorreo As Eniac.Controles.Label
End Class
