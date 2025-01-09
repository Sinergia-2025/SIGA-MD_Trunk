<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ucConfTurismo
   Inherits ucConfBase

   'UserControl overrides dispose to clean up the component list.
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
        Me.lblTurismoTipoComprobante = New Eniac.Controles.Label()
        Me.txtFormulaGastronomiaId = New Eniac.Controles.TextBox()
        Me.lblFormulaVisita = New Eniac.Controles.Label()
        Me.txtFormulaVisitasId = New Eniac.Controles.TextBox()
        Me.txtFormulaGastronomia = New Eniac.Controles.TextBox()
        Me.lblFormulaGastronomia = New Eniac.Controles.Label()
        Me.txtFormulaVisitas = New Eniac.Controles.TextBox()
        Me.Label25 = New Eniac.Controles.Label()
        Me.Label24 = New Eniac.Controles.Label()
        Me.Label23 = New Eniac.Controles.Label()
        Me.Label22 = New Eniac.Controles.Label()
        Me.Label21 = New Eniac.Controles.Label()
        Me.Label20 = New Eniac.Controles.Label()
        Me.lblTurismoTipoComprobanteFact = New Eniac.Controles.Label()
        Me.cmbTurismoTipoComprobanteFact = New Eniac.Controles.ComboBox()
        Me.cmbTurismoTipoComprobante = New Eniac.Controles.ComboBox()
        Me.cmbCatResponsable = New Eniac.Controles.ComboBox()
        Me.cmbCatPasajero = New Eniac.Controles.ComboBox()
        Me.cmbCatEstablecimiento = New Eniac.Controles.ComboBox()
        Me.cmbRubroGastronomia = New Eniac.Controles.ComboBox()
        Me.cmbRubroVisitas = New Eniac.Controles.ComboBox()
        Me.cmbRubroProgramas = New Eniac.Controles.ComboBox()
        Me.SuspendLayout()
        '
        'lblTurismoTipoComprobante
        '
        Me.lblTurismoTipoComprobante.AutoSize = True
        Me.lblTurismoTipoComprobante.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblTurismoTipoComprobante.LabelAsoc = Nothing
        Me.lblTurismoTipoComprobante.Location = New System.Drawing.Point(15, 293)
        Me.lblTurismoTipoComprobante.Name = "lblTurismoTipoComprobante"
        Me.lblTurismoTipoComprobante.Size = New System.Drawing.Size(205, 13)
        Me.lblTurismoTipoComprobante.TabIndex = 18
        Me.lblTurismoTipoComprobante.Text = "Tipo de Comprobante Generacion Cta Cte"
        '
        'txtFormulaGastronomiaId
        '
        Me.txtFormulaGastronomiaId.BindearPropiedadControl = Nothing
        Me.txtFormulaGastronomiaId.BindearPropiedadEntidad = Nothing
        Me.txtFormulaGastronomiaId.ForeColorFocus = System.Drawing.Color.Red
        Me.txtFormulaGastronomiaId.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtFormulaGastronomiaId.Formato = ""
        Me.txtFormulaGastronomiaId.IsDecimal = False
        Me.txtFormulaGastronomiaId.IsNumber = True
        Me.txtFormulaGastronomiaId.IsPK = False
        Me.txtFormulaGastronomiaId.IsRequired = False
        Me.txtFormulaGastronomiaId.Key = ""
        Me.txtFormulaGastronomiaId.LabelAsoc = Me.lblFormulaVisita
        Me.txtFormulaGastronomiaId.Location = New System.Drawing.Point(190, 246)
        Me.txtFormulaGastronomiaId.MaxLength = 110
        Me.txtFormulaGastronomiaId.Name = "txtFormulaGastronomiaId"
        Me.txtFormulaGastronomiaId.Size = New System.Drawing.Size(34, 20)
        Me.txtFormulaGastronomiaId.TabIndex = 16
        Me.txtFormulaGastronomiaId.Tag = "TURISMOFORMULAGASTRONOMIAID"
        Me.txtFormulaGastronomiaId.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblFormulaVisita
        '
        Me.lblFormulaVisita.AutoSize = True
        Me.lblFormulaVisita.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblFormulaVisita.LabelAsoc = Nothing
        Me.lblFormulaVisita.Location = New System.Drawing.Point(72, 223)
        Me.lblFormulaVisita.Name = "lblFormulaVisita"
        Me.lblFormulaVisita.Size = New System.Drawing.Size(77, 13)
        Me.lblFormulaVisita.TabIndex = 12
        Me.lblFormulaVisita.Text = "Fórmula Visitas"
        '
        'txtFormulaVisitasId
        '
        Me.txtFormulaVisitasId.AcceptsReturn = True
        Me.txtFormulaVisitasId.BindearPropiedadControl = Nothing
        Me.txtFormulaVisitasId.BindearPropiedadEntidad = Nothing
        Me.txtFormulaVisitasId.ForeColorFocus = System.Drawing.Color.Red
        Me.txtFormulaVisitasId.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtFormulaVisitasId.Formato = ""
        Me.txtFormulaVisitasId.IsDecimal = False
        Me.txtFormulaVisitasId.IsNumber = True
        Me.txtFormulaVisitasId.IsPK = False
        Me.txtFormulaVisitasId.IsRequired = False
        Me.txtFormulaVisitasId.Key = ""
        Me.txtFormulaVisitasId.LabelAsoc = Me.lblFormulaVisita
        Me.txtFormulaVisitasId.Location = New System.Drawing.Point(190, 220)
        Me.txtFormulaVisitasId.MaxLength = 110
        Me.txtFormulaVisitasId.Name = "txtFormulaVisitasId"
        Me.txtFormulaVisitasId.Size = New System.Drawing.Size(34, 20)
        Me.txtFormulaVisitasId.TabIndex = 13
        Me.txtFormulaVisitasId.Tag = "TURISMOFORMULAVISITASID"
        Me.txtFormulaVisitasId.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtFormulaGastronomia
        '
        Me.txtFormulaGastronomia.BindearPropiedadControl = Nothing
        Me.txtFormulaGastronomia.BindearPropiedadEntidad = Nothing
        Me.txtFormulaGastronomia.ForeColorFocus = System.Drawing.Color.Red
        Me.txtFormulaGastronomia.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtFormulaGastronomia.Formato = ""
        Me.txtFormulaGastronomia.IsDecimal = False
        Me.txtFormulaGastronomia.IsNumber = False
        Me.txtFormulaGastronomia.IsPK = False
        Me.txtFormulaGastronomia.IsRequired = False
        Me.txtFormulaGastronomia.Key = ""
        Me.txtFormulaGastronomia.LabelAsoc = Me.lblFormulaGastronomia
        Me.txtFormulaGastronomia.Location = New System.Drawing.Point(230, 246)
        Me.txtFormulaGastronomia.MaxLength = 110
        Me.txtFormulaGastronomia.Name = "txtFormulaGastronomia"
        Me.txtFormulaGastronomia.Size = New System.Drawing.Size(165, 20)
        Me.txtFormulaGastronomia.TabIndex = 17
        Me.txtFormulaGastronomia.Tag = "TURISMOFORMULAGASTRONOMIA"
        '
        'lblFormulaGastronomia
        '
        Me.lblFormulaGastronomia.AutoSize = True
        Me.lblFormulaGastronomia.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblFormulaGastronomia.LabelAsoc = Nothing
        Me.lblFormulaGastronomia.Location = New System.Drawing.Point(72, 248)
        Me.lblFormulaGastronomia.Name = "lblFormulaGastronomia"
        Me.lblFormulaGastronomia.Size = New System.Drawing.Size(106, 13)
        Me.lblFormulaGastronomia.TabIndex = 15
        Me.lblFormulaGastronomia.Text = "Fórmula Gastronomia"
        '
        'txtFormulaVisitas
        '
        Me.txtFormulaVisitas.BindearPropiedadControl = Nothing
        Me.txtFormulaVisitas.BindearPropiedadEntidad = Nothing
        Me.txtFormulaVisitas.ForeColorFocus = System.Drawing.Color.Red
        Me.txtFormulaVisitas.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtFormulaVisitas.Formato = ""
        Me.txtFormulaVisitas.IsDecimal = False
        Me.txtFormulaVisitas.IsNumber = False
        Me.txtFormulaVisitas.IsPK = False
        Me.txtFormulaVisitas.IsRequired = False
        Me.txtFormulaVisitas.Key = ""
        Me.txtFormulaVisitas.LabelAsoc = Me.lblFormulaVisita
        Me.txtFormulaVisitas.Location = New System.Drawing.Point(230, 220)
        Me.txtFormulaVisitas.MaxLength = 110
        Me.txtFormulaVisitas.Name = "txtFormulaVisitas"
        Me.txtFormulaVisitas.Size = New System.Drawing.Size(165, 20)
        Me.txtFormulaVisitas.TabIndex = 14
        Me.txtFormulaVisitas.Tag = "TURISMOFORMULAVISITAS"
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Label25.LabelAsoc = Nothing
        Me.Label25.Location = New System.Drawing.Point(36, 74)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(143, 13)
        Me.Label25.TabIndex = 4
        Me.Label25.Text = "Categoría para Responsable"
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Label24.LabelAsoc = Nothing
        Me.Label24.Location = New System.Drawing.Point(36, 47)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(122, 13)
        Me.Label24.TabIndex = 2
        Me.Label24.Text = "Categoría para Pasajero"
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Label23.LabelAsoc = Nothing
        Me.Label23.Location = New System.Drawing.Point(36, 19)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(155, 13)
        Me.Label23.TabIndex = 0
        Me.Label23.Text = "Categoría para Establecimiento"
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Label22.LabelAsoc = Nothing
        Me.Label22.Location = New System.Drawing.Point(69, 180)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(124, 13)
        Me.Label22.TabIndex = 10
        Me.Label22.Text = "Rubro para Gastronomía"
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Label21.LabelAsoc = Nothing
        Me.Label21.Location = New System.Drawing.Point(69, 153)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(118, 13)
        Me.Label21.TabIndex = 8
        Me.Label21.Tag = "0"
        Me.Label21.Text = "Rubro para Actividades"
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Label20.LabelAsoc = Nothing
        Me.Label20.Location = New System.Drawing.Point(69, 126)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(113, 13)
        Me.Label20.TabIndex = 6
        Me.Label20.Text = "Rubro para Programas"
        '
        'lblTurismoTipoComprobanteFact
        '
        Me.lblTurismoTipoComprobanteFact.AutoSize = True
        Me.lblTurismoTipoComprobanteFact.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblTurismoTipoComprobanteFact.LabelAsoc = Nothing
        Me.lblTurismoTipoComprobanteFact.Location = New System.Drawing.Point(15, 320)
        Me.lblTurismoTipoComprobanteFact.Name = "lblTurismoTipoComprobanteFact"
        Me.lblTurismoTipoComprobanteFact.Size = New System.Drawing.Size(206, 13)
        Me.lblTurismoTipoComprobanteFact.TabIndex = 20
        Me.lblTurismoTipoComprobanteFact.Text = "Tipo de Comprobante Generacion Factura"
        '
        'cmbTurismoTipoComprobanteFact
        '
        Me.cmbTurismoTipoComprobanteFact.BindearPropiedadControl = Nothing
        Me.cmbTurismoTipoComprobanteFact.BindearPropiedadEntidad = Nothing
        Me.cmbTurismoTipoComprobanteFact.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbTurismoTipoComprobanteFact.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbTurismoTipoComprobanteFact.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbTurismoTipoComprobanteFact.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbTurismoTipoComprobanteFact.FormattingEnabled = True
        Me.cmbTurismoTipoComprobanteFact.IsPK = False
        Me.cmbTurismoTipoComprobanteFact.IsRequired = False
        Me.cmbTurismoTipoComprobanteFact.Key = Nothing
        Me.cmbTurismoTipoComprobanteFact.LabelAsoc = Me.lblTurismoTipoComprobanteFact
        Me.cmbTurismoTipoComprobanteFact.Location = New System.Drawing.Point(230, 317)
        Me.cmbTurismoTipoComprobanteFact.Name = "cmbTurismoTipoComprobanteFact"
        Me.cmbTurismoTipoComprobanteFact.Size = New System.Drawing.Size(156, 21)
        Me.cmbTurismoTipoComprobanteFact.TabIndex = 21
        Me.cmbTurismoTipoComprobanteFact.Tag = "TURISMOTIPOCOMPROBANTE"
        '
        'cmbTurismoTipoComprobante
        '
        Me.cmbTurismoTipoComprobante.BindearPropiedadControl = Nothing
        Me.cmbTurismoTipoComprobante.BindearPropiedadEntidad = Nothing
        Me.cmbTurismoTipoComprobante.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbTurismoTipoComprobante.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbTurismoTipoComprobante.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbTurismoTipoComprobante.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbTurismoTipoComprobante.FormattingEnabled = True
        Me.cmbTurismoTipoComprobante.IsPK = False
        Me.cmbTurismoTipoComprobante.IsRequired = False
        Me.cmbTurismoTipoComprobante.Key = Nothing
        Me.cmbTurismoTipoComprobante.LabelAsoc = Me.lblTurismoTipoComprobante
        Me.cmbTurismoTipoComprobante.Location = New System.Drawing.Point(230, 290)
        Me.cmbTurismoTipoComprobante.Name = "cmbTurismoTipoComprobante"
        Me.cmbTurismoTipoComprobante.Size = New System.Drawing.Size(156, 21)
        Me.cmbTurismoTipoComprobante.TabIndex = 19
        Me.cmbTurismoTipoComprobante.Tag = "TURISMOTIPOCOMPROBANTE"
        '
        'cmbCatResponsable
        '
        Me.cmbCatResponsable.BindearPropiedadControl = Nothing
        Me.cmbCatResponsable.BindearPropiedadEntidad = Nothing
        Me.cmbCatResponsable.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbCatResponsable.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbCatResponsable.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbCatResponsable.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbCatResponsable.FormattingEnabled = True
        Me.cmbCatResponsable.IsPK = False
        Me.cmbCatResponsable.IsRequired = False
        Me.cmbCatResponsable.Key = Nothing
        Me.cmbCatResponsable.LabelAsoc = Me.Label25
        Me.cmbCatResponsable.Location = New System.Drawing.Point(195, 71)
        Me.cmbCatResponsable.Name = "cmbCatResponsable"
        Me.cmbCatResponsable.Size = New System.Drawing.Size(156, 21)
        Me.cmbCatResponsable.TabIndex = 5
        Me.cmbCatResponsable.Tag = "TURISMOCATEGORIARESPONSABLE"
        '
        'cmbCatPasajero
        '
        Me.cmbCatPasajero.BindearPropiedadControl = Nothing
        Me.cmbCatPasajero.BindearPropiedadEntidad = Nothing
        Me.cmbCatPasajero.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbCatPasajero.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbCatPasajero.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbCatPasajero.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbCatPasajero.FormattingEnabled = True
        Me.cmbCatPasajero.IsPK = False
        Me.cmbCatPasajero.IsRequired = False
        Me.cmbCatPasajero.Key = Nothing
        Me.cmbCatPasajero.LabelAsoc = Me.Label24
        Me.cmbCatPasajero.Location = New System.Drawing.Point(195, 44)
        Me.cmbCatPasajero.Name = "cmbCatPasajero"
        Me.cmbCatPasajero.Size = New System.Drawing.Size(156, 21)
        Me.cmbCatPasajero.TabIndex = 3
        Me.cmbCatPasajero.Tag = "TURISMOCATEGORIAPASAJEROS"
        '
        'cmbCatEstablecimiento
        '
        Me.cmbCatEstablecimiento.BindearPropiedadControl = Nothing
        Me.cmbCatEstablecimiento.BindearPropiedadEntidad = Nothing
        Me.cmbCatEstablecimiento.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbCatEstablecimiento.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbCatEstablecimiento.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbCatEstablecimiento.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbCatEstablecimiento.FormattingEnabled = True
        Me.cmbCatEstablecimiento.IsPK = False
        Me.cmbCatEstablecimiento.IsRequired = False
        Me.cmbCatEstablecimiento.Key = Nothing
        Me.cmbCatEstablecimiento.LabelAsoc = Me.Label23
        Me.cmbCatEstablecimiento.Location = New System.Drawing.Point(195, 16)
        Me.cmbCatEstablecimiento.Name = "cmbCatEstablecimiento"
        Me.cmbCatEstablecimiento.Size = New System.Drawing.Size(156, 21)
        Me.cmbCatEstablecimiento.TabIndex = 1
        Me.cmbCatEstablecimiento.Tag = "TURISMOCATEGORIAESTABLECIMIENTO"
        '
        'cmbRubroGastronomia
        '
        Me.cmbRubroGastronomia.BindearPropiedadControl = Nothing
        Me.cmbRubroGastronomia.BindearPropiedadEntidad = Nothing
        Me.cmbRubroGastronomia.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbRubroGastronomia.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbRubroGastronomia.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbRubroGastronomia.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbRubroGastronomia.FormattingEnabled = True
        Me.cmbRubroGastronomia.IsPK = False
        Me.cmbRubroGastronomia.IsRequired = False
        Me.cmbRubroGastronomia.Key = Nothing
        Me.cmbRubroGastronomia.LabelAsoc = Me.Label22
        Me.cmbRubroGastronomia.Location = New System.Drawing.Point(195, 177)
        Me.cmbRubroGastronomia.Name = "cmbRubroGastronomia"
        Me.cmbRubroGastronomia.Size = New System.Drawing.Size(156, 21)
        Me.cmbRubroGastronomia.TabIndex = 11
        Me.cmbRubroGastronomia.Tag = "TURISMORUBROGASTRONOMIA"
        '
        'cmbRubroVisitas
        '
        Me.cmbRubroVisitas.BindearPropiedadControl = Nothing
        Me.cmbRubroVisitas.BindearPropiedadEntidad = Nothing
        Me.cmbRubroVisitas.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbRubroVisitas.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbRubroVisitas.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbRubroVisitas.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbRubroVisitas.FormattingEnabled = True
        Me.cmbRubroVisitas.IsPK = False
        Me.cmbRubroVisitas.IsRequired = False
        Me.cmbRubroVisitas.Key = Nothing
        Me.cmbRubroVisitas.LabelAsoc = Me.Label21
        Me.cmbRubroVisitas.Location = New System.Drawing.Point(195, 150)
        Me.cmbRubroVisitas.Name = "cmbRubroVisitas"
        Me.cmbRubroVisitas.Size = New System.Drawing.Size(156, 21)
        Me.cmbRubroVisitas.TabIndex = 9
        Me.cmbRubroVisitas.Tag = "TURISMORUBROVISITA"
        '
        'cmbRubroProgramas
        '
        Me.cmbRubroProgramas.BindearPropiedadControl = Nothing
        Me.cmbRubroProgramas.BindearPropiedadEntidad = Nothing
        Me.cmbRubroProgramas.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbRubroProgramas.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbRubroProgramas.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbRubroProgramas.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbRubroProgramas.FormattingEnabled = True
        Me.cmbRubroProgramas.IsPK = False
        Me.cmbRubroProgramas.IsRequired = False
        Me.cmbRubroProgramas.Key = Nothing
        Me.cmbRubroProgramas.LabelAsoc = Me.Label20
        Me.cmbRubroProgramas.Location = New System.Drawing.Point(195, 123)
        Me.cmbRubroProgramas.Name = "cmbRubroProgramas"
        Me.cmbRubroProgramas.Size = New System.Drawing.Size(156, 21)
        Me.cmbRubroProgramas.TabIndex = 7
        Me.cmbRubroProgramas.Tag = "TURISMORUBROPROGRAMA"
        '
        'ucConfTurismo
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.lblTurismoTipoComprobanteFact)
        Me.Controls.Add(Me.cmbTurismoTipoComprobanteFact)
        Me.Controls.Add(Me.lblTurismoTipoComprobante)
        Me.Controls.Add(Me.txtFormulaGastronomiaId)
        Me.Controls.Add(Me.txtFormulaVisitasId)
        Me.Controls.Add(Me.txtFormulaGastronomia)
        Me.Controls.Add(Me.txtFormulaVisitas)
        Me.Controls.Add(Me.lblFormulaGastronomia)
        Me.Controls.Add(Me.lblFormulaVisita)
        Me.Controls.Add(Me.Label25)
        Me.Controls.Add(Me.Label24)
        Me.Controls.Add(Me.Label23)
        Me.Controls.Add(Me.Label22)
        Me.Controls.Add(Me.Label21)
        Me.Controls.Add(Me.Label20)
        Me.Controls.Add(Me.cmbTurismoTipoComprobante)
        Me.Controls.Add(Me.cmbCatResponsable)
        Me.Controls.Add(Me.cmbCatPasajero)
        Me.Controls.Add(Me.cmbCatEstablecimiento)
        Me.Controls.Add(Me.cmbRubroGastronomia)
        Me.Controls.Add(Me.cmbRubroVisitas)
        Me.Controls.Add(Me.cmbRubroProgramas)
        Me.Name = "ucConfTurismo"
        Me.Controls.SetChildIndex(Me.cmbRubroProgramas, 0)
        Me.Controls.SetChildIndex(Me.cmbRubroVisitas, 0)
        Me.Controls.SetChildIndex(Me.cmbRubroGastronomia, 0)
        Me.Controls.SetChildIndex(Me.cmbCatEstablecimiento, 0)
        Me.Controls.SetChildIndex(Me.cmbCatPasajero, 0)
        Me.Controls.SetChildIndex(Me.cmbCatResponsable, 0)
        Me.Controls.SetChildIndex(Me.cmbTurismoTipoComprobante, 0)
        Me.Controls.SetChildIndex(Me.Label20, 0)
        Me.Controls.SetChildIndex(Me.Label21, 0)
        Me.Controls.SetChildIndex(Me.Label22, 0)
        Me.Controls.SetChildIndex(Me.Label23, 0)
        Me.Controls.SetChildIndex(Me.Label24, 0)
        Me.Controls.SetChildIndex(Me.Label25, 0)
        Me.Controls.SetChildIndex(Me.lblFormulaVisita, 0)
        Me.Controls.SetChildIndex(Me.lblFormulaGastronomia, 0)
        Me.Controls.SetChildIndex(Me.txtFormulaVisitas, 0)
        Me.Controls.SetChildIndex(Me.txtFormulaGastronomia, 0)
        Me.Controls.SetChildIndex(Me.txtFormulaVisitasId, 0)
        Me.Controls.SetChildIndex(Me.txtFormulaGastronomiaId, 0)
        Me.Controls.SetChildIndex(Me.lblTurismoTipoComprobante, 0)
        Me.Controls.SetChildIndex(Me.cmbTurismoTipoComprobanteFact, 0)
        Me.Controls.SetChildIndex(Me.lblTurismoTipoComprobanteFact, 0)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lblTurismoTipoComprobante As Controles.Label
    Friend WithEvents txtFormulaGastronomiaId As Controles.TextBox
    Friend WithEvents lblFormulaVisita As Controles.Label
    Friend WithEvents txtFormulaVisitasId As Controles.TextBox
    Friend WithEvents txtFormulaGastronomia As Controles.TextBox
    Friend WithEvents lblFormulaGastronomia As Controles.Label
    Friend WithEvents txtFormulaVisitas As Controles.TextBox
    Friend WithEvents Label25 As Controles.Label
    Friend WithEvents Label24 As Controles.Label
    Friend WithEvents Label23 As Controles.Label
    Friend WithEvents Label22 As Controles.Label
    Friend WithEvents Label21 As Controles.Label
    Friend WithEvents Label20 As Controles.Label
    Friend WithEvents cmbTurismoTipoComprobante As Controles.ComboBox
    Friend WithEvents cmbCatResponsable As Controles.ComboBox
    Friend WithEvents cmbCatPasajero As Controles.ComboBox
    Friend WithEvents cmbCatEstablecimiento As Controles.ComboBox
    Friend WithEvents cmbRubroGastronomia As Controles.ComboBox
    Friend WithEvents cmbRubroVisitas As Controles.ComboBox
    Friend WithEvents cmbRubroProgramas As Controles.ComboBox
    Friend WithEvents lblTurismoTipoComprobanteFact As Controles.Label
    Friend WithEvents cmbTurismoTipoComprobanteFact As Controles.ComboBox
End Class
