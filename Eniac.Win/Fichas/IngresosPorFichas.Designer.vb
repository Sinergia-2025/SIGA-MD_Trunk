<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class IngresosPorFichas
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
      Me.components = New System.ComponentModel.Container
      Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(IngresosPorFichas))
      Me.lblDesde = New Eniac.Controles.Label
      Me.lblHasta = New Eniac.Controles.Label
      Me.dtpDesde = New Eniac.Controles.DateTimePicker
      Me.dtpHasta = New Eniac.Controles.DateTimePicker
      Me.btnVer = New Eniac.Controles.Button
      Me.imgGrabar = New System.Windows.Forms.ImageList(Me.components)
      Me.btnCancelar = New Eniac.Controles.Button
      Me.cmbCobradores = New Eniac.Controles.ComboBox
      Me.chbConCobrador = New Eniac.Controles.CheckBox
      Me.SuspendLayout()
      '
      'lblDesde
      '
      Me.lblDesde.AutoSize = True
      Me.lblDesde.Location = New System.Drawing.Point(28, 27)
      Me.lblDesde.Name = "lblDesde"
      Me.lblDesde.Size = New System.Drawing.Size(38, 13)
      Me.lblDesde.TabIndex = 7
      Me.lblDesde.Text = "Desde"
      '
      'lblHasta
      '
      Me.lblHasta.AutoSize = True
      Me.lblHasta.Location = New System.Drawing.Point(28, 65)
      Me.lblHasta.Name = "lblHasta"
      Me.lblHasta.Size = New System.Drawing.Size(35, 13)
      Me.lblHasta.TabIndex = 8
      Me.lblHasta.Text = "Hasta"
      '
      'dtpDesde
      '
      Me.dtpDesde.BindearPropiedadControl = Nothing
      Me.dtpDesde.BindearPropiedadEntidad = Nothing
      Me.dtpDesde.CustomFormat = "dd/MM/yyyy"
      Me.dtpDesde.ForeColorFocus = System.Drawing.Color.Red
      Me.dtpDesde.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.dtpDesde.Format = System.Windows.Forms.DateTimePickerFormat.Custom
      Me.dtpDesde.IsPK = False
      Me.dtpDesde.IsRequired = False
      Me.dtpDesde.Key = ""
      Me.dtpDesde.LabelAsoc = Me.lblDesde
      Me.dtpDesde.Location = New System.Drawing.Point(72, 21)
      Me.dtpDesde.Name = "dtpDesde"
      Me.dtpDesde.Size = New System.Drawing.Size(97, 20)
      Me.dtpDesde.TabIndex = 0
      '
      'dtpHasta
      '
      Me.dtpHasta.BindearPropiedadControl = Nothing
      Me.dtpHasta.BindearPropiedadEntidad = Nothing
      Me.dtpHasta.CustomFormat = "dd/MM/yyyy"
      Me.dtpHasta.ForeColorFocus = System.Drawing.Color.Red
      Me.dtpHasta.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.dtpHasta.Format = System.Windows.Forms.DateTimePickerFormat.Custom
      Me.dtpHasta.IsPK = False
      Me.dtpHasta.IsRequired = False
      Me.dtpHasta.Key = ""
      Me.dtpHasta.LabelAsoc = Me.lblHasta
      Me.dtpHasta.Location = New System.Drawing.Point(72, 58)
      Me.dtpHasta.Name = "dtpHasta"
      Me.dtpHasta.Size = New System.Drawing.Size(97, 20)
      Me.dtpHasta.TabIndex = 1
      '
      'btnVer
      '
      Me.btnVer.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.btnVer.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
      Me.btnVer.ImageKey = "check2.ico"
      Me.btnVer.ImageList = Me.imgGrabar
      Me.btnVer.Location = New System.Drawing.Point(17, 170)
      Me.btnVer.Name = "btnVer"
      Me.btnVer.Size = New System.Drawing.Size(85, 30)
      Me.btnVer.TabIndex = 5
      Me.btnVer.Text = "&Ver"
      Me.btnVer.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      Me.btnVer.UseVisualStyleBackColor = True
      '
      'imgGrabar
      '
      Me.imgGrabar.ImageStream = CType(resources.GetObject("imgGrabar.ImageStream"), System.Windows.Forms.ImageListStreamer)
      Me.imgGrabar.TransparentColor = System.Drawing.Color.Transparent
      Me.imgGrabar.Images.SetKeyName(0, "check2.ico")
      Me.imgGrabar.Images.SetKeyName(1, "delete2.ico")
      '
      'btnCancelar
      '
      Me.btnCancelar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel
      Me.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
      Me.btnCancelar.ImageKey = "delete2.ico"
      Me.btnCancelar.ImageList = Me.imgGrabar
      Me.btnCancelar.Location = New System.Drawing.Point(108, 170)
      Me.btnCancelar.Name = "btnCancelar"
      Me.btnCancelar.Size = New System.Drawing.Size(85, 30)
      Me.btnCancelar.TabIndex = 6
      Me.btnCancelar.Text = "&Cancelar"
      Me.btnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      Me.btnCancelar.UseVisualStyleBackColor = True
      '
      'cmbCobradores
      '
      Me.cmbCobradores.BindearPropiedadControl = Nothing
      Me.cmbCobradores.BindearPropiedadEntidad = Nothing
      Me.cmbCobradores.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cmbCobradores.Enabled = False
      Me.cmbCobradores.ForeColorFocus = System.Drawing.Color.Red
      Me.cmbCobradores.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.cmbCobradores.FormattingEnabled = True
      Me.cmbCobradores.IsPK = False
      Me.cmbCobradores.IsRequired = False
      Me.cmbCobradores.Key = Nothing
      Me.cmbCobradores.LabelAsoc = Nothing
      Me.cmbCobradores.Location = New System.Drawing.Point(31, 123)
      Me.cmbCobradores.Name = "cmbCobradores"
      Me.cmbCobradores.Size = New System.Drawing.Size(149, 21)
      Me.cmbCobradores.TabIndex = 2
      '
      'chbConCobrador
      '
      Me.chbConCobrador.AutoSize = True
      Me.chbConCobrador.BindearPropiedadControl = Nothing
      Me.chbConCobrador.BindearPropiedadEntidad = Nothing
      Me.chbConCobrador.ForeColorFocus = System.Drawing.Color.Red
      Me.chbConCobrador.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
      Me.chbConCobrador.IsPK = False
      Me.chbConCobrador.IsRequired = False
      Me.chbConCobrador.Key = Nothing
      Me.chbConCobrador.LabelAsoc = Nothing
      Me.chbConCobrador.Location = New System.Drawing.Point(31, 100)
      Me.chbConCobrador.Name = "chbConCobrador"
      Me.chbConCobrador.Size = New System.Drawing.Size(88, 17)
      Me.chbConCobrador.TabIndex = 9
      Me.chbConCobrador.Text = "Por Cobrador"
      Me.chbConCobrador.UseVisualStyleBackColor = True
      '
      'IngresosPorFichas
      '
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.ClientSize = New System.Drawing.Size(216, 212)
      Me.Controls.Add(Me.chbConCobrador)
      Me.Controls.Add(Me.cmbCobradores)
      Me.Controls.Add(Me.btnVer)
      Me.Controls.Add(Me.btnCancelar)
      Me.Controls.Add(Me.dtpHasta)
      Me.Controls.Add(Me.dtpDesde)
      Me.Controls.Add(Me.lblHasta)
      Me.Controls.Add(Me.lblDesde)
      Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
      Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
      Me.MaximizeBox = False
      Me.MinimizeBox = False
      Me.Name = "IngresosPorFichas"
      Me.ShowInTaskbar = False
      Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
      Me.Text = "Ingresos por Fichas"
      Me.ResumeLayout(False)
      Me.PerformLayout()

   End Sub
   Friend WithEvents lblDesde As Eniac.Controles.Label
   Friend WithEvents lblHasta As Eniac.Controles.Label
   Friend WithEvents dtpDesde As Eniac.Controles.DateTimePicker
   Friend WithEvents dtpHasta As Eniac.Controles.DateTimePicker
   Friend WithEvents btnVer As Eniac.Controles.Button
   Friend WithEvents btnCancelar As Eniac.Controles.Button
   Friend WithEvents imgGrabar As System.Windows.Forms.ImageList
   Friend WithEvents cmbCobradores As Eniac.Controles.ComboBox
   Friend WithEvents chbConCobrador As Eniac.Controles.CheckBox
End Class
