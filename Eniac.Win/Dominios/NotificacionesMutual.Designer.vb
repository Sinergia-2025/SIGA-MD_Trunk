<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class NotificacionesMutual
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
      Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(NotificacionesMutual))
      Me.tstBarra = New System.Windows.Forms.ToolStrip()
      Me.tsbEmitirCarta = New System.Windows.Forms.ToolStripButton()
      Me.tsbReimprimir = New System.Windows.Forms.ToolStripButton()
      Me.tsbCancelarCarta = New System.Windows.Forms.ToolStripButton()
      Me.toolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
      Me.tsbSalir = New System.Windows.Forms.ToolStripButton()
      Me.lblCarta = New Eniac.Controles.Label()
      Me.cmbTipoCarta = New Eniac.Controles.ComboBox()
      Me.grbTitular = New System.Windows.Forms.GroupBox()
      Me.txtPatente = New Eniac.Controles.TextBox()
      Me.lblPatente = New Eniac.Controles.Label()
      Me.txtTitular = New Eniac.Controles.TextBox()
      Me.lblTitular = New Eniac.Controles.Label()
      Me.tstBarra.SuspendLayout()
      Me.grbTitular.SuspendLayout()
      Me.SuspendLayout()
      '
      'tstBarra
      '
      Me.tstBarra.AllowItemReorder = True
      Me.tstBarra.ImageScalingSize = New System.Drawing.Size(22, 22)
      Me.tstBarra.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsbEmitirCarta, Me.tsbReimprimir, Me.tsbCancelarCarta, Me.toolStripSeparator3, Me.tsbSalir})
      Me.tstBarra.Location = New System.Drawing.Point(0, 0)
      Me.tstBarra.Name = "tstBarra"
      Me.tstBarra.Size = New System.Drawing.Size(448, 29)
      Me.tstBarra.TabIndex = 5
      Me.tstBarra.Text = "toolStrip1"
      '
      'tsbEmitirCarta
      '
      Me.tsbEmitirCarta.Image = Global.Eniac.Win.My.Resources.Resources.document_add
      Me.tsbEmitirCarta.ImageTransparentColor = System.Drawing.Color.Magenta
      Me.tsbEmitirCarta.Name = "tsbEmitirCarta"
      Me.tsbEmitirCarta.Size = New System.Drawing.Size(95, 26)
      Me.tsbEmitirCarta.Text = "Emitir Carta"
      '
      'tsbReimprimir
      '
      Me.tsbReimprimir.Image = Global.Eniac.Win.My.Resources.Resources.document_check
      Me.tsbReimprimir.ImageTransparentColor = System.Drawing.Color.Magenta
      Me.tsbReimprimir.Name = "tsbReimprimir"
      Me.tsbReimprimir.Size = New System.Drawing.Size(110, 26)
      Me.tsbReimprimir.Text = "Imprimir Carta"
      '
      'tsbCancelarCarta
      '
      Me.tsbCancelarCarta.Image = Global.Eniac.Win.My.Resources.Resources.document_delete
      Me.tsbCancelarCarta.ImageTransparentColor = System.Drawing.Color.Magenta
      Me.tsbCancelarCarta.Name = "tsbCancelarCarta"
      Me.tsbCancelarCarta.Size = New System.Drawing.Size(110, 26)
      Me.tsbCancelarCarta.Text = "Cancelar Carta"
      '
      'toolStripSeparator3
      '
      Me.toolStripSeparator3.Name = "toolStripSeparator3"
      Me.toolStripSeparator3.Size = New System.Drawing.Size(6, 29)
      '
      'tsbSalir
      '
      Me.tsbSalir.Image = Global.Eniac.Win.My.Resources.Resources.close_b_32
      Me.tsbSalir.ImageTransparentColor = System.Drawing.Color.Magenta
      Me.tsbSalir.Name = "tsbSalir"
      Me.tsbSalir.Size = New System.Drawing.Size(65, 26)
      Me.tsbSalir.Text = "&Cerrar"
      Me.tsbSalir.ToolTipText = "Cerrar el formulario"
      '
      'lblCarta
      '
      Me.lblCarta.AutoSize = True
      Me.lblCarta.LabelAsoc = Nothing
      Me.lblCarta.Location = New System.Drawing.Point(22, 51)
      Me.lblCarta.Name = "lblCarta"
      Me.lblCarta.Size = New System.Drawing.Size(32, 13)
      Me.lblCarta.TabIndex = 18
      Me.lblCarta.Text = "Carta"
      '
      'cmbTipoCarta
      '
      Me.cmbTipoCarta.BindearPropiedadControl = Nothing
      Me.cmbTipoCarta.BindearPropiedadEntidad = Nothing
      Me.cmbTipoCarta.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cmbTipoCarta.ForeColorFocus = System.Drawing.Color.Red
      Me.cmbTipoCarta.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.cmbTipoCarta.FormattingEnabled = True
      Me.cmbTipoCarta.IsPK = False
      Me.cmbTipoCarta.IsRequired = False
      Me.cmbTipoCarta.Key = Nothing
      Me.cmbTipoCarta.LabelAsoc = Nothing
      Me.cmbTipoCarta.Location = New System.Drawing.Point(60, 47)
      Me.cmbTipoCarta.Name = "cmbTipoCarta"
      Me.cmbTipoCarta.Size = New System.Drawing.Size(202, 21)
      Me.cmbTipoCarta.TabIndex = 17
      '
      'grbTitular
      '
      Me.grbTitular.Controls.Add(Me.txtPatente)
      Me.grbTitular.Controls.Add(Me.lblPatente)
      Me.grbTitular.Controls.Add(Me.txtTitular)
      Me.grbTitular.Controls.Add(Me.lblTitular)
      Me.grbTitular.Location = New System.Drawing.Point(15, 78)
      Me.grbTitular.Name = "grbTitular"
      Me.grbTitular.Size = New System.Drawing.Size(421, 93)
      Me.grbTitular.TabIndex = 20
      Me.grbTitular.TabStop = False
      Me.grbTitular.Text = "Cliente"
      '
      'txtPatente
      '
      Me.txtPatente.BindearPropiedadControl = "Text"
      Me.txtPatente.BindearPropiedadEntidad = "PatenteVehiculo"
      Me.txtPatente.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.txtPatente.ForeColorFocus = System.Drawing.Color.Red
      Me.txtPatente.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtPatente.Formato = ""
      Me.txtPatente.IsDecimal = False
      Me.txtPatente.IsNumber = False
      Me.txtPatente.IsPK = False
      Me.txtPatente.IsRequired = False
      Me.txtPatente.Key = ""
      Me.txtPatente.LabelAsoc = Me.lblPatente
      Me.txtPatente.Location = New System.Drawing.Point(89, 49)
      Me.txtPatente.MaxLength = 10
      Me.txtPatente.Name = "txtPatente"
      Me.txtPatente.ReadOnly = True
      Me.txtPatente.Size = New System.Drawing.Size(144, 20)
      Me.txtPatente.TabIndex = 3
      Me.txtPatente.TabStop = False
      '
      'lblPatente
      '
      Me.lblPatente.AutoSize = True
      Me.lblPatente.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.lblPatente.LabelAsoc = Nothing
      Me.lblPatente.Location = New System.Drawing.Point(11, 52)
      Me.lblPatente.Name = "lblPatente"
      Me.lblPatente.Size = New System.Drawing.Size(55, 13)
      Me.lblPatente.TabIndex = 4
      Me.lblPatente.Text = "Empresa"
      '
      'txtTitular
      '
      Me.txtTitular.BindearPropiedadControl = "Text"
      Me.txtTitular.BindearPropiedadEntidad = "Titular"
      Me.txtTitular.ForeColorFocus = System.Drawing.Color.Red
      Me.txtTitular.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtTitular.Formato = ""
      Me.txtTitular.IsDecimal = False
      Me.txtTitular.IsNumber = False
      Me.txtTitular.IsPK = False
      Me.txtTitular.IsRequired = False
      Me.txtTitular.Key = ""
      Me.txtTitular.LabelAsoc = Me.lblTitular
      Me.txtTitular.Location = New System.Drawing.Point(89, 19)
      Me.txtTitular.MaxLength = 50
      Me.txtTitular.Name = "txtTitular"
      Me.txtTitular.ReadOnly = True
      Me.txtTitular.Size = New System.Drawing.Size(276, 20)
      Me.txtTitular.TabIndex = 2
      Me.txtTitular.TabStop = False
      '
      'lblTitular
      '
      Me.lblTitular.AutoSize = True
      Me.lblTitular.LabelAsoc = Nothing
      Me.lblTitular.Location = New System.Drawing.Point(11, 26)
      Me.lblTitular.Name = "lblTitular"
      Me.lblTitular.Size = New System.Drawing.Size(44, 13)
      Me.lblTitular.TabIndex = 1
      Me.lblTitular.Text = "Nombre"
      '
      'NotificacionesMutual
      '
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.ClientSize = New System.Drawing.Size(448, 181)
      Me.Controls.Add(Me.grbTitular)
      Me.Controls.Add(Me.lblCarta)
      Me.Controls.Add(Me.tstBarra)
      Me.Controls.Add(Me.cmbTipoCarta)
      Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
      Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
      Me.MaximizeBox = False
      Me.MinimizeBox = False
      Me.Name = "NotificacionesMutual"
      Me.ShowInTaskbar = False
      Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
      Me.Text = "Noficaciones Mutual"
      Me.tstBarra.ResumeLayout(False)
      Me.tstBarra.PerformLayout()
      Me.grbTitular.ResumeLayout(False)
      Me.grbTitular.PerformLayout()
      Me.ResumeLayout(False)
      Me.PerformLayout()

   End Sub
   Public WithEvents tstBarra As System.Windows.Forms.ToolStrip
   Friend WithEvents tsbEmitirCarta As System.Windows.Forms.ToolStripButton
   Private WithEvents toolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
   Public WithEvents tsbSalir As System.Windows.Forms.ToolStripButton
   Friend WithEvents lblCarta As Eniac.Controles.Label
   Friend WithEvents cmbTipoCarta As Eniac.Controles.ComboBox
   Friend WithEvents grbTitular As System.Windows.Forms.GroupBox
   Friend WithEvents tsbReimprimir As System.Windows.Forms.ToolStripButton
   Friend WithEvents tsbCancelarCarta As System.Windows.Forms.ToolStripButton
   Friend WithEvents txtTitular As Eniac.Controles.TextBox
   Friend WithEvents lblTitular As Eniac.Controles.Label
   Friend WithEvents lblPatente As Eniac.Controles.Label
   Friend WithEvents txtPatente As Eniac.Controles.TextBox
End Class
