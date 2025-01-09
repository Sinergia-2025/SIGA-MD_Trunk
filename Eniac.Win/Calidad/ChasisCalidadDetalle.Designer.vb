<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class ChasisCalidadDetalle
   Inherits BaseDetalle

   'Form overrides dispose to clean up the component list.
   <System.Diagnostics.DebuggerNonUserCode()>
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
   <System.Diagnostics.DebuggerStepThrough()>
   Private Sub InitializeComponent()
      Me.txtIdProducto = New Eniac.Controles.TextBox()
      Me.lblIdProducto = New Eniac.Controles.Label()
      Me.TBCFechas = New System.Windows.Forms.TabControl()
      Me.tbpObservaciones = New System.Windows.Forms.TabPage()
      Me.txtObservacion = New Eniac.Controles.TextBox()
      Me.lblNumeroChasis = New Eniac.Controles.Label()
      Me.txtNroCarroceria = New Eniac.Controles.TextBox()
      Me.lblNroCarroceria = New Eniac.Controles.Label()
      Me.Label8 = New Eniac.Controles.Label()
      Me.Label9 = New Eniac.Controles.Label()
      Me.bscNroChasis = New Eniac.Controles.Buscador2()
      Me.txtNroMotor = New Eniac.Controles.TextBox()
      Me.bscModelo = New Eniac.Controles.Buscador2()
      Me.lblModelo = New Eniac.Controles.Label()
      Me.grpDetalle = New System.Windows.Forms.GroupBox()
      Me.btnActualizarNroMotor = New Eniac.Controles.Button()
      Me.cmbTipoServicio = New Eniac.Controles.ComboBox()
      Me.TBCFechas.SuspendLayout()
      Me.tbpObservaciones.SuspendLayout()
      Me.grpDetalle.SuspendLayout()
      Me.SuspendLayout()
      '
      'btnAceptar
      '
      Me.btnAceptar.Location = New System.Drawing.Point(357, 315)
      Me.btnAceptar.TabIndex = 4
      '
      'btnCancelar
      '
      Me.btnCancelar.Location = New System.Drawing.Point(443, 315)
      Me.btnCancelar.TabIndex = 5
      '
      'btnCopiar
      '
      Me.btnCopiar.Location = New System.Drawing.Point(256, 315)
      '
      'btnAplicar
      '
      Me.btnAplicar.Location = New System.Drawing.Point(195, 315)
      Me.btnAplicar.TabIndex = 2
      '
      'txtIdProducto
      '
      Me.txtIdProducto.BindearPropiedadControl = "Text"
      Me.txtIdProducto.BindearPropiedadEntidad = "IdProducto"
      Me.txtIdProducto.Enabled = False
      Me.txtIdProducto.ForeColorFocus = System.Drawing.Color.Red
      Me.txtIdProducto.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtIdProducto.Formato = ""
      Me.txtIdProducto.IsDecimal = False
      Me.txtIdProducto.IsNumber = False
      Me.txtIdProducto.IsPK = True
      Me.txtIdProducto.IsRequired = True
      Me.txtIdProducto.Key = ""
      Me.txtIdProducto.LabelAsoc = Me.lblIdProducto
      Me.txtIdProducto.Location = New System.Drawing.Point(57, 11)
      Me.txtIdProducto.MaxLength = 15
      Me.txtIdProducto.Name = "txtIdProducto"
      Me.txtIdProducto.ReadOnly = True
      Me.txtIdProducto.Size = New System.Drawing.Size(119, 20)
      Me.txtIdProducto.TabIndex = 0
      Me.txtIdProducto.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
      '
      'lblIdProducto
      '
      Me.lblIdProducto.AutoSize = True
      Me.lblIdProducto.LabelAsoc = Nothing
      Me.lblIdProducto.Location = New System.Drawing.Point(13, 12)
      Me.lblIdProducto.Name = "lblIdProducto"
      Me.lblIdProducto.Size = New System.Drawing.Size(40, 13)
      Me.lblIdProducto.TabIndex = 6
      Me.lblIdProducto.Text = "Código"
      '
      'TBCFechas
      '
      Me.TBCFechas.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.TBCFechas.Controls.Add(Me.tbpObservaciones)
      Me.TBCFechas.Location = New System.Drawing.Point(7, 181)
      Me.TBCFechas.Name = "TBCFechas"
      Me.TBCFechas.SelectedIndex = 0
      Me.TBCFechas.Size = New System.Drawing.Size(518, 128)
      Me.TBCFechas.TabIndex = 9
      '
      'tbpObservaciones
      '
      Me.tbpObservaciones.Controls.Add(Me.txtObservacion)
      Me.tbpObservaciones.Location = New System.Drawing.Point(4, 22)
      Me.tbpObservaciones.Name = "tbpObservaciones"
      Me.tbpObservaciones.Padding = New System.Windows.Forms.Padding(3)
      Me.tbpObservaciones.Size = New System.Drawing.Size(510, 102)
      Me.tbpObservaciones.TabIndex = 1
      Me.tbpObservaciones.Text = "Observaciones"
      Me.tbpObservaciones.UseVisualStyleBackColor = True
      '
      'txtObservacion
      '
      Me.txtObservacion.BindearPropiedadControl = "Text"
      Me.txtObservacion.BindearPropiedadEntidad = "CalidadObservaciones"
      Me.txtObservacion.Dock = System.Windows.Forms.DockStyle.Fill
      Me.txtObservacion.ForeColorFocus = System.Drawing.Color.Red
      Me.txtObservacion.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtObservacion.Formato = ""
      Me.txtObservacion.IsDecimal = False
      Me.txtObservacion.IsNumber = False
      Me.txtObservacion.IsPK = False
      Me.txtObservacion.IsRequired = False
      Me.txtObservacion.Key = ""
      Me.txtObservacion.LabelAsoc = Nothing
      Me.txtObservacion.Location = New System.Drawing.Point(3, 3)
      Me.txtObservacion.MaxLength = 1000
      Me.txtObservacion.Multiline = True
      Me.txtObservacion.Name = "txtObservacion"
      Me.txtObservacion.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
      Me.txtObservacion.Size = New System.Drawing.Size(504, 96)
      Me.txtObservacion.TabIndex = 0
      '
      'lblNumeroChasis
      '
      Me.lblNumeroChasis.AutoSize = True
      Me.lblNumeroChasis.LabelAsoc = Nothing
      Me.lblNumeroChasis.Location = New System.Drawing.Point(13, 52)
      Me.lblNumeroChasis.Name = "lblNumeroChasis"
      Me.lblNumeroChasis.Size = New System.Drawing.Size(93, 13)
      Me.lblNumeroChasis.TabIndex = 7
      Me.lblNumeroChasis.Text = "Número de Chasis"
      '
      'txtNroCarroceria
      '
      Me.txtNroCarroceria.BindearPropiedadControl = "Text"
      Me.txtNroCarroceria.BindearPropiedadEntidad = "CalidadNroCarroceria"
      Me.txtNroCarroceria.Enabled = False
      Me.txtNroCarroceria.ForeColorFocus = System.Drawing.Color.Red
      Me.txtNroCarroceria.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtNroCarroceria.Formato = ""
      Me.txtNroCarroceria.IsDecimal = False
      Me.txtNroCarroceria.IsNumber = True
      Me.txtNroCarroceria.IsPK = False
      Me.txtNroCarroceria.IsRequired = True
      Me.txtNroCarroceria.Key = ""
      Me.txtNroCarroceria.LabelAsoc = Me.lblNroCarroceria
      Me.txtNroCarroceria.Location = New System.Drawing.Point(152, 104)
      Me.txtNroCarroceria.MaxLength = 9
      Me.txtNroCarroceria.Name = "txtNroCarroceria"
      Me.txtNroCarroceria.ReadOnly = True
      Me.txtNroCarroceria.Size = New System.Drawing.Size(79, 20)
      Me.txtNroCarroceria.TabIndex = 4
      Me.txtNroCarroceria.Text = "0"
      Me.txtNroCarroceria.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'lblNroCarroceria
      '
      Me.lblNroCarroceria.AutoSize = True
      Me.lblNroCarroceria.LabelAsoc = Nothing
      Me.lblNroCarroceria.Location = New System.Drawing.Point(13, 108)
      Me.lblNroCarroceria.Name = "lblNroCarroceria"
      Me.lblNroCarroceria.Size = New System.Drawing.Size(112, 13)
      Me.lblNroCarroceria.TabIndex = 9
      Me.lblNroCarroceria.Text = "Número de Carrocería"
      '
      'Label8
      '
      Me.Label8.AutoSize = True
      Me.Label8.LabelAsoc = Nothing
      Me.Label8.Location = New System.Drawing.Point(191, 15)
      Me.Label8.Name = "Label8"
      Me.Label8.Size = New System.Drawing.Size(31, 13)
      Me.Label8.TabIndex = 7
      Me.Label8.Text = "Tipo "
      '
      'Label9
      '
      Me.Label9.AutoSize = True
      Me.Label9.LabelAsoc = Nothing
      Me.Label9.Location = New System.Drawing.Point(14, 79)
      Me.Label9.Name = "Label9"
      Me.Label9.Size = New System.Drawing.Size(89, 13)
      Me.Label9.TabIndex = 8
      Me.Label9.Text = "Número de Motor"
      '
      'bscNroChasis
      '
      Me.bscNroChasis.ActivarFiltroEnGrilla = True
      Me.bscNroChasis.AutoSize = True
      Me.bscNroChasis.BindearPropiedadControl = ""
      Me.bscNroChasis.BindearPropiedadEntidad = ""
      Me.bscNroChasis.ConfigBuscador = Nothing
      Me.bscNroChasis.Datos = Nothing
      Me.bscNroChasis.FilaDevuelta = Nothing
      Me.bscNroChasis.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.bscNroChasis.ForeColorFocus = System.Drawing.Color.Red
      Me.bscNroChasis.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
      Me.bscNroChasis.IsDecimal = False
      Me.bscNroChasis.IsNumber = False
      Me.bscNroChasis.IsPK = False
      Me.bscNroChasis.IsRequired = False
      Me.bscNroChasis.Key = ""
      Me.bscNroChasis.LabelAsoc = Nothing
      Me.bscNroChasis.Location = New System.Drawing.Point(106, 48)
      Me.bscNroChasis.Margin = New System.Windows.Forms.Padding(4)
      Me.bscNroChasis.MaxLengh = "32767"
      Me.bscNroChasis.Name = "bscNroChasis"
      Me.bscNroChasis.Permitido = True
      Me.bscNroChasis.PermitidoNoBackColor = System.Drawing.Color.FromArgb(CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer))
      Me.bscNroChasis.PermitidoNoForeColor = System.Drawing.Color.Black
      Me.bscNroChasis.PermitidoSiBackColor = System.Drawing.Color.White
      Me.bscNroChasis.PermitidoSiForeColor = System.Drawing.Color.Black
      Me.bscNroChasis.Selecciono = False
      Me.bscNroChasis.Size = New System.Drawing.Size(227, 23)
      Me.bscNroChasis.TabIndex = 2
      '
      'txtNroMotor
      '
      Me.txtNroMotor.BindearPropiedadControl = ""
      Me.txtNroMotor.BindearPropiedadEntidad = ""
      Me.txtNroMotor.ForeColorFocus = System.Drawing.Color.Red
      Me.txtNroMotor.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtNroMotor.Formato = ""
      Me.txtNroMotor.IsDecimal = False
      Me.txtNroMotor.IsNumber = False
      Me.txtNroMotor.IsPK = False
      Me.txtNroMotor.IsRequired = False
      Me.txtNroMotor.Key = ""
      Me.txtNroMotor.LabelAsoc = Nothing
      Me.txtNroMotor.Location = New System.Drawing.Point(106, 76)
      Me.txtNroMotor.MaxLength = 50
      Me.txtNroMotor.Name = "txtNroMotor"
      Me.txtNroMotor.Size = New System.Drawing.Size(199, 20)
      Me.txtNroMotor.TabIndex = 3
      '
      'bscModelo
      '
      Me.bscModelo.ActivarFiltroEnGrilla = True
      Me.bscModelo.AutoSize = True
      Me.bscModelo.BindearPropiedadControl = ""
      Me.bscModelo.BindearPropiedadEntidad = ""
      Me.bscModelo.ConfigBuscador = Nothing
      Me.bscModelo.Datos = Nothing
      Me.bscModelo.FilaDevuelta = Nothing
      Me.bscModelo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.bscModelo.ForeColorFocus = System.Drawing.Color.Red
      Me.bscModelo.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
      Me.bscModelo.IsDecimal = False
      Me.bscModelo.IsNumber = False
      Me.bscModelo.IsPK = False
      Me.bscModelo.IsRequired = False
      Me.bscModelo.Key = ""
      Me.bscModelo.LabelAsoc = Nothing
      Me.bscModelo.Location = New System.Drawing.Point(106, 19)
      Me.bscModelo.Margin = New System.Windows.Forms.Padding(4)
      Me.bscModelo.MaxLengh = "32767"
      Me.bscModelo.Name = "bscModelo"
      Me.bscModelo.Permitido = True
      Me.bscModelo.PermitidoNoBackColor = System.Drawing.Color.FromArgb(CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer))
      Me.bscModelo.PermitidoNoForeColor = System.Drawing.Color.Black
      Me.bscModelo.PermitidoSiBackColor = System.Drawing.Color.White
      Me.bscModelo.PermitidoSiForeColor = System.Drawing.Color.Black
      Me.bscModelo.Selecciono = False
      Me.bscModelo.Size = New System.Drawing.Size(350, 23)
      Me.bscModelo.TabIndex = 1
      '
      'lblModelo
      '
      Me.lblModelo.AutoSize = True
      Me.lblModelo.LabelAsoc = Nothing
      Me.lblModelo.Location = New System.Drawing.Point(14, 22)
      Me.lblModelo.Name = "lblModelo"
      Me.lblModelo.Size = New System.Drawing.Size(42, 13)
      Me.lblModelo.TabIndex = 6
      Me.lblModelo.Text = "Modelo"
      '
      'grpDetalle
      '
      Me.grpDetalle.Controls.Add(Me.bscModelo)
      Me.grpDetalle.Controls.Add(Me.txtNroCarroceria)
      Me.grpDetalle.Controls.Add(Me.lblNroCarroceria)
      Me.grpDetalle.Controls.Add(Me.lblModelo)
      Me.grpDetalle.Controls.Add(Me.btnActualizarNroMotor)
      Me.grpDetalle.Controls.Add(Me.lblNumeroChasis)
      Me.grpDetalle.Controls.Add(Me.txtNroMotor)
      Me.grpDetalle.Controls.Add(Me.Label9)
      Me.grpDetalle.Controls.Add(Me.bscNroChasis)
      Me.grpDetalle.Location = New System.Drawing.Point(7, 39)
      Me.grpDetalle.Name = "grpDetalle"
      Me.grpDetalle.Size = New System.Drawing.Size(519, 135)
      Me.grpDetalle.TabIndex = 8
      Me.grpDetalle.TabStop = False
      '
      'btnActualizarNroMotor
      '
      Me.btnActualizarNroMotor.Image = Global.Eniac.Win.My.Resources.Resources.refresh_16
      Me.btnActualizarNroMotor.ImeMode = System.Windows.Forms.ImeMode.NoControl
      Me.btnActualizarNroMotor.Location = New System.Drawing.Point(305, 76)
      Me.btnActualizarNroMotor.Name = "btnActualizarNroMotor"
      Me.btnActualizarNroMotor.Size = New System.Drawing.Size(28, 21)
      Me.btnActualizarNroMotor.TabIndex = 10
      Me.btnActualizarNroMotor.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
      Me.btnActualizarNroMotor.UseVisualStyleBackColor = True
      '
      'cmbTipoServicio
      '
      Me.cmbTipoServicio.BindearPropiedadControl = "SelectedValue"
      Me.cmbTipoServicio.BindearPropiedadEntidad = "IdProductoTipoServicio"
      Me.cmbTipoServicio.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cmbTipoServicio.Enabled = False
      Me.cmbTipoServicio.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.cmbTipoServicio.ForeColorFocus = System.Drawing.Color.Red
      Me.cmbTipoServicio.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.cmbTipoServicio.FormattingEnabled = True
      Me.cmbTipoServicio.IsPK = False
      Me.cmbTipoServicio.IsRequired = True
      Me.cmbTipoServicio.Key = Nothing
      Me.cmbTipoServicio.LabelAsoc = Nothing
      Me.cmbTipoServicio.Location = New System.Drawing.Point(227, 10)
      Me.cmbTipoServicio.Name = "cmbTipoServicio"
      Me.cmbTipoServicio.Size = New System.Drawing.Size(119, 21)
      Me.cmbTipoServicio.TabIndex = 1
      '
      'ChasisCalidadDetalle
      '
      Me.AcceptButton = Nothing
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.ClientSize = New System.Drawing.Size(532, 350)
      Me.Controls.Add(Me.grpDetalle)
      Me.Controls.Add(Me.cmbTipoServicio)
      Me.Controls.Add(Me.TBCFechas)
      Me.Controls.Add(Me.txtIdProducto)
      Me.Controls.Add(Me.lblIdProducto)
      Me.Controls.Add(Me.Label8)
      Me.Name = "ChasisCalidadDetalle"
      Me.Text = "Chasis"
      Me.Controls.SetChildIndex(Me.Label8, 0)
      Me.Controls.SetChildIndex(Me.btnAplicar, 0)
      Me.Controls.SetChildIndex(Me.btnCancelar, 0)
      Me.Controls.SetChildIndex(Me.btnAceptar, 0)
      Me.Controls.SetChildIndex(Me.btnCopiar, 0)
      Me.Controls.SetChildIndex(Me.lblIdProducto, 0)
      Me.Controls.SetChildIndex(Me.txtIdProducto, 0)
      Me.Controls.SetChildIndex(Me.TBCFechas, 0)
      Me.Controls.SetChildIndex(Me.cmbTipoServicio, 0)
      Me.Controls.SetChildIndex(Me.grpDetalle, 0)
      Me.TBCFechas.ResumeLayout(False)
      Me.tbpObservaciones.ResumeLayout(False)
      Me.tbpObservaciones.PerformLayout()
      Me.grpDetalle.ResumeLayout(False)
      Me.grpDetalle.PerformLayout()
      Me.ResumeLayout(False)
      Me.PerformLayout()

   End Sub
   Friend WithEvents txtIdProducto As Eniac.Controles.TextBox
   Friend WithEvents lblIdProducto As Eniac.Controles.Label
   Friend WithEvents TBCFechas As System.Windows.Forms.TabControl
   Friend WithEvents tbpObservaciones As System.Windows.Forms.TabPage
   Friend WithEvents txtObservacion As Eniac.Controles.TextBox
   Friend WithEvents lblNumeroChasis As Eniac.Controles.Label
   Friend WithEvents txtNroCarroceria As Eniac.Controles.TextBox
   Friend WithEvents lblNroCarroceria As Eniac.Controles.Label
   Friend WithEvents cmbTipoServicio As Eniac.Controles.ComboBox
   Friend WithEvents Label8 As Eniac.Controles.Label
   Friend WithEvents Label9 As Eniac.Controles.Label
   Friend WithEvents bscNroChasis As Eniac.Controles.Buscador2
   Friend WithEvents txtNroMotor As Eniac.Controles.TextBox
   Friend WithEvents bscModelo As Controles.Buscador2
   Friend WithEvents lblModelo As Controles.Label
   Friend WithEvents grpDetalle As GroupBox
   Friend WithEvents btnActualizarNroMotor As Controles.Button
End Class
