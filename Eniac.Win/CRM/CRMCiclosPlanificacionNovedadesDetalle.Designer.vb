<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class CRMCiclosPlanificacionNovedadesDetalle
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
      Me.cmbTipoPlanificacion = New Eniac.Controles.ComboBox()
        Me.lblTipoPlanificacion = New Eniac.Controles.Label()
        Me.lblEstadoInicio = New Eniac.Controles.Label()
        Me.txtEstadoInicio = New Eniac.Controles.TextBox()
        Me.lblOrden = New Eniac.Controles.Label()
        Me.txtOrden = New Eniac.Controles.TextBox()
        Me.chbPlanificada = New Eniac.Controles.CheckBox()
        Me.cdColor = New System.Windows.Forms.ColorDialog()
        Me.lblCicloPlanificacion = New Eniac.Controles.Label()
        Me.bscNombreCicloPlanificacion = New Eniac.Controles.Buscador2()
        Me.bscIdCicloPlanificacion = New Eniac.Controles.Buscador2()
        Me.txtCentroEmisor = New Eniac.Controles.TextBox()
        Me.lblNovedad = New Eniac.Controles.Label()
        Me.txtLetra = New Eniac.Controles.TextBox()
        Me.bscIdNovedad = New Eniac.Controles.Buscador2()
        Me.cmbIdTipoNovedad = New Eniac.Controles.ComboBox()
        Me.txtEstadoCierre = New Eniac.Controles.TextBox()
        Me.lblEstadoCierre = New Eniac.Controles.Label()
        Me.txtEstadoFin = New Eniac.Controles.TextBox()
        Me.lblEstadoFin = New Eniac.Controles.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.pnlUsuarios = New System.Windows.Forms.Panel()
        Me.txtFechaActualizacion = New Eniac.Controles.TextBox()
        Me.txtIdUsuarioActualizacion = New Eniac.Controles.TextBox()
        Me.lblActualizacion = New Eniac.Controles.Label()
        Me.txtFechaAlta = New Eniac.Controles.TextBox()
        Me.txtIdUsuarioAlta = New Eniac.Controles.TextBox()
        Me.lblAlta = New Eniac.Controles.Label()
        Me.lblFechaFinalizacion = New Eniac.Controles.Label()
        Me.lblFechaCierre = New Eniac.Controles.Label()
        Me.lblFechaInicio = New Eniac.Controles.Label()
        Me.dtpFechaFinalizacion = New Eniac.Controles.DateTimePicker()
        Me.dtpFechaCierre = New Eniac.Controles.DateTimePicker()
        Me.dtpFechaInicio = New Eniac.Controles.DateTimePicker()
        Me.lblEstadoCicloPlanificacion = New Eniac.Controles.Label()
        Me.txtEstadoCicloPlanificacion = New Eniac.Controles.TextBox()
        Me.Panel1.SuspendLayout()
        Me.pnlUsuarios.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnAceptar
        '
        Me.btnAceptar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnAceptar.Location = New System.Drawing.Point(419, 0)
        Me.btnAceptar.TabIndex = 0
        '
        'btnCancelar
        '
        Me.btnCancelar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCancelar.Location = New System.Drawing.Point(505, 0)
        Me.btnCancelar.TabIndex = 1
        '
        'btnCopiar
        '
        Me.btnCopiar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCopiar.Location = New System.Drawing.Point(318, 0)
        '
        'btnAplicar
        '
        Me.btnAplicar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnAplicar.Location = New System.Drawing.Point(258, 0)
        Me.btnAplicar.TabIndex = 2
        '
        'cmbTipoPlanificacion
        '
        Me.cmbTipoPlanificacion.BindearPropiedadControl = "SelectedValue"
        Me.cmbTipoPlanificacion.BindearPropiedadEntidad = "TipoPlanificacion"
        Me.cmbTipoPlanificacion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbTipoPlanificacion.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbTipoPlanificacion.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbTipoPlanificacion.FormattingEnabled = True
        Me.cmbTipoPlanificacion.IsPK = False
        Me.cmbTipoPlanificacion.IsRequired = False
        Me.cmbTipoPlanificacion.Key = Nothing
        Me.cmbTipoPlanificacion.LabelAsoc = Me.lblTipoPlanificacion
        Me.cmbTipoPlanificacion.Location = New System.Drawing.Point(119, 155)
        Me.cmbTipoPlanificacion.Name = "cmbTipoPlanificacion"
        Me.cmbTipoPlanificacion.Size = New System.Drawing.Size(161, 21)
        Me.cmbTipoPlanificacion.TabIndex = 19
        '
        'lblTipoPlanificacion
        '
        Me.lblTipoPlanificacion.AutoSize = True
        Me.lblTipoPlanificacion.LabelAsoc = Nothing
        Me.lblTipoPlanificacion.Location = New System.Drawing.Point(22, 158)
        Me.lblTipoPlanificacion.Name = "lblTipoPlanificacion"
        Me.lblTipoPlanificacion.Size = New System.Drawing.Size(91, 13)
        Me.lblTipoPlanificacion.TabIndex = 18
        Me.lblTipoPlanificacion.Text = "Tipo Planificación"
        '
        'lblEstadoInicio
        '
        Me.lblEstadoInicio.AutoSize = True
        Me.lblEstadoInicio.LabelAsoc = Nothing
        Me.lblEstadoInicio.Location = New System.Drawing.Point(22, 186)
        Me.lblEstadoInicio.Name = "lblEstadoInicio"
        Me.lblEstadoInicio.Size = New System.Drawing.Size(79, 13)
        Me.lblEstadoInicio.TabIndex = 21
        Me.lblEstadoInicio.Text = "Estado al Inicio"
        '
        'txtEstadoInicio
        '
        Me.txtEstadoInicio.BindearPropiedadControl = ""
        Me.txtEstadoInicio.BindearPropiedadEntidad = ""
        Me.txtEstadoInicio.ForeColorFocus = System.Drawing.Color.Red
        Me.txtEstadoInicio.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtEstadoInicio.Formato = ""
        Me.txtEstadoInicio.IsDecimal = False
        Me.txtEstadoInicio.IsNumber = False
        Me.txtEstadoInicio.IsPK = False
        Me.txtEstadoInicio.IsRequired = False
        Me.txtEstadoInicio.Key = ""
        Me.txtEstadoInicio.LabelAsoc = Me.lblEstadoInicio
        Me.txtEstadoInicio.Location = New System.Drawing.Point(119, 182)
        Me.txtEstadoInicio.MaxLength = 20
        Me.txtEstadoInicio.Name = "txtEstadoInicio"
        Me.txtEstadoInicio.ReadOnly = True
        Me.txtEstadoInicio.Size = New System.Drawing.Size(161, 20)
        Me.txtEstadoInicio.TabIndex = 22
        '
        'lblOrden
        '
        Me.lblOrden.AutoSize = True
        Me.lblOrden.LabelAsoc = Nothing
        Me.lblOrden.Location = New System.Drawing.Point(22, 133)
        Me.lblOrden.Name = "lblOrden"
        Me.lblOrden.Size = New System.Drawing.Size(36, 13)
        Me.lblOrden.TabIndex = 16
        Me.lblOrden.Text = "Órden"
        '
        'txtOrden
        '
        Me.txtOrden.BindearPropiedadControl = "Text"
        Me.txtOrden.BindearPropiedadEntidad = "Orden"
        Me.txtOrden.ForeColorFocus = System.Drawing.Color.Red
        Me.txtOrden.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtOrden.Formato = ""
        Me.txtOrden.IsDecimal = False
        Me.txtOrden.IsNumber = True
        Me.txtOrden.IsPK = False
        Me.txtOrden.IsRequired = True
        Me.txtOrden.Key = ""
        Me.txtOrden.LabelAsoc = Me.lblOrden
        Me.txtOrden.Location = New System.Drawing.Point(119, 129)
        Me.txtOrden.MaxLength = 4
        Me.txtOrden.Name = "txtOrden"
        Me.txtOrden.Size = New System.Drawing.Size(54, 20)
        Me.txtOrden.TabIndex = 17
        Me.txtOrden.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'chbPlanificada
        '
        Me.chbPlanificada.AutoSize = True
        Me.chbPlanificada.BindearPropiedadControl = "Checked"
        Me.chbPlanificada.BindearPropiedadEntidad = "Planificada"
        Me.chbPlanificada.ForeColorFocus = System.Drawing.Color.Red
        Me.chbPlanificada.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbPlanificada.IsPK = False
        Me.chbPlanificada.IsRequired = False
        Me.chbPlanificada.Key = Nothing
        Me.chbPlanificada.LabelAsoc = Nothing
        Me.chbPlanificada.Location = New System.Drawing.Point(286, 157)
        Me.chbPlanificada.Name = "chbPlanificada"
        Me.chbPlanificada.Size = New System.Drawing.Size(78, 17)
        Me.chbPlanificada.TabIndex = 20
        Me.chbPlanificada.Text = "Planificada"
        Me.chbPlanificada.UseVisualStyleBackColor = True
        '
        'lblCicloPlanificacion
        '
        Me.lblCicloPlanificacion.AutoSize = True
        Me.lblCicloPlanificacion.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblCicloPlanificacion.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblCicloPlanificacion.LabelAsoc = Nothing
        Me.lblCicloPlanificacion.Location = New System.Drawing.Point(22, 15)
        Me.lblCicloPlanificacion.Name = "lblCicloPlanificacion"
        Me.lblCicloPlanificacion.Size = New System.Drawing.Size(30, 13)
        Me.lblCicloPlanificacion.TabIndex = 0
        Me.lblCicloPlanificacion.Text = "Ciclo"
        '
        'bscNombreCicloPlanificacion
        '
        Me.bscNombreCicloPlanificacion.ActivarFiltroEnGrilla = True
        Me.bscNombreCicloPlanificacion.BindearPropiedadControl = Nothing
        Me.bscNombreCicloPlanificacion.BindearPropiedadEntidad = Nothing
        Me.bscNombreCicloPlanificacion.ConfigBuscador = Nothing
        Me.bscNombreCicloPlanificacion.Datos = Nothing
        Me.bscNombreCicloPlanificacion.FilaDevuelta = Nothing
        Me.bscNombreCicloPlanificacion.ForeColorFocus = System.Drawing.Color.Red
        Me.bscNombreCicloPlanificacion.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.bscNombreCicloPlanificacion.IsDecimal = False
        Me.bscNombreCicloPlanificacion.IsNumber = False
        Me.bscNombreCicloPlanificacion.IsPK = False
        Me.bscNombreCicloPlanificacion.IsRequired = True
        Me.bscNombreCicloPlanificacion.Key = ""
        Me.bscNombreCicloPlanificacion.LabelAsoc = Me.lblCicloPlanificacion
        Me.bscNombreCicloPlanificacion.Location = New System.Drawing.Point(226, 13)
        Me.bscNombreCicloPlanificacion.MaxLengh = "32767"
        Me.bscNombreCicloPlanificacion.Name = "bscNombreCicloPlanificacion"
        Me.bscNombreCicloPlanificacion.Permitido = True
        Me.bscNombreCicloPlanificacion.PermitidoNoBackColor = System.Drawing.Color.FromArgb(CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer))
        Me.bscNombreCicloPlanificacion.PermitidoNoForeColor = System.Drawing.Color.Black
        Me.bscNombreCicloPlanificacion.PermitidoSiBackColor = System.Drawing.Color.White
        Me.bscNombreCicloPlanificacion.PermitidoSiForeColor = System.Drawing.Color.Black
        Me.bscNombreCicloPlanificacion.Selecciono = False
        Me.bscNombreCicloPlanificacion.Size = New System.Drawing.Size(234, 20)
        Me.bscNombreCicloPlanificacion.TabIndex = 2
        '
        'bscIdCicloPlanificacion
        '
        Me.bscIdCicloPlanificacion.ActivarFiltroEnGrilla = True
        Me.bscIdCicloPlanificacion.BindearPropiedadControl = "Text"
        Me.bscIdCicloPlanificacion.BindearPropiedadEntidad = "IdCicloPlanificacion"
        Me.bscIdCicloPlanificacion.ConfigBuscador = Nothing
        Me.bscIdCicloPlanificacion.Datos = Nothing
        Me.bscIdCicloPlanificacion.FilaDevuelta = Nothing
        Me.bscIdCicloPlanificacion.ForeColorFocus = System.Drawing.Color.Red
        Me.bscIdCicloPlanificacion.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.bscIdCicloPlanificacion.IsDecimal = False
        Me.bscIdCicloPlanificacion.IsNumber = False
        Me.bscIdCicloPlanificacion.IsPK = False
        Me.bscIdCicloPlanificacion.IsRequired = True
        Me.bscIdCicloPlanificacion.Key = ""
        Me.bscIdCicloPlanificacion.LabelAsoc = Me.lblCicloPlanificacion
        Me.bscIdCicloPlanificacion.Location = New System.Drawing.Point(119, 12)
        Me.bscIdCicloPlanificacion.MaxLengh = "32767"
        Me.bscIdCicloPlanificacion.Name = "bscIdCicloPlanificacion"
        Me.bscIdCicloPlanificacion.Permitido = True
        Me.bscIdCicloPlanificacion.PermitidoNoBackColor = System.Drawing.Color.FromArgb(CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer))
        Me.bscIdCicloPlanificacion.PermitidoNoForeColor = System.Drawing.Color.Black
        Me.bscIdCicloPlanificacion.PermitidoSiBackColor = System.Drawing.Color.White
        Me.bscIdCicloPlanificacion.PermitidoSiForeColor = System.Drawing.Color.Black
        Me.bscIdCicloPlanificacion.Selecciono = False
        Me.bscIdCicloPlanificacion.Size = New System.Drawing.Size(101, 20)
        Me.bscIdCicloPlanificacion.TabIndex = 1
        '
        'txtCentroEmisor
        '
        Me.txtCentroEmisor.BindearPropiedadControl = "Text"
        Me.txtCentroEmisor.BindearPropiedadEntidad = "CentroEmisor"
        Me.txtCentroEmisor.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCentroEmisor.ForeColorFocus = System.Drawing.Color.Red
        Me.txtCentroEmisor.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtCentroEmisor.Formato = ""
        Me.txtCentroEmisor.IsDecimal = False
        Me.txtCentroEmisor.IsNumber = True
        Me.txtCentroEmisor.IsPK = False
        Me.txtCentroEmisor.IsRequired = True
        Me.txtCentroEmisor.Key = ""
        Me.txtCentroEmisor.LabelAsoc = Me.lblNovedad
        Me.txtCentroEmisor.Location = New System.Drawing.Point(310, 93)
        Me.txtCentroEmisor.Name = "txtCentroEmisor"
        Me.txtCentroEmisor.ReadOnly = True
        Me.txtCentroEmisor.Size = New System.Drawing.Size(35, 20)
        Me.txtCentroEmisor.TabIndex = 14
        Me.txtCentroEmisor.TabStop = False
        Me.txtCentroEmisor.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblNovedad
        '
        Me.lblNovedad.AutoSize = True
        Me.lblNovedad.LabelAsoc = Nothing
        Me.lblNovedad.Location = New System.Drawing.Point(22, 95)
        Me.lblNovedad.Name = "lblNovedad"
        Me.lblNovedad.Size = New System.Drawing.Size(51, 13)
        Me.lblNovedad.TabIndex = 11
        Me.lblNovedad.Text = "Novedad"
        '
        'txtLetra
        '
        Me.txtLetra.BindearPropiedadControl = "Text"
        Me.txtLetra.BindearPropiedadEntidad = "Letra"
        Me.txtLetra.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtLetra.ForeColorFocus = System.Drawing.Color.Red
        Me.txtLetra.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtLetra.Formato = ""
        Me.txtLetra.IsDecimal = False
        Me.txtLetra.IsNumber = False
        Me.txtLetra.IsPK = False
        Me.txtLetra.IsRequired = True
        Me.txtLetra.Key = ""
        Me.txtLetra.LabelAsoc = Me.lblNovedad
        Me.txtLetra.Location = New System.Drawing.Point(286, 93)
        Me.txtLetra.Name = "txtLetra"
        Me.txtLetra.ReadOnly = True
        Me.txtLetra.Size = New System.Drawing.Size(18, 20)
        Me.txtLetra.TabIndex = 13
        Me.txtLetra.TabStop = False
        Me.txtLetra.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'bscIdNovedad
        '
        Me.bscIdNovedad.ActivarFiltroEnGrilla = True
        Me.bscIdNovedad.BindearPropiedadControl = "Text"
        Me.bscIdNovedad.BindearPropiedadEntidad = "IdNovedad"
        Me.bscIdNovedad.ConfigBuscador = Nothing
        Me.bscIdNovedad.Datos = Nothing
        Me.bscIdNovedad.FilaDevuelta = Nothing
        Me.bscIdNovedad.ForeColorFocus = System.Drawing.Color.Red
        Me.bscIdNovedad.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.bscIdNovedad.IsDecimal = False
        Me.bscIdNovedad.IsNumber = False
        Me.bscIdNovedad.IsPK = False
        Me.bscIdNovedad.IsRequired = True
        Me.bscIdNovedad.Key = ""
        Me.bscIdNovedad.LabelAsoc = Me.lblNovedad
        Me.bscIdNovedad.Location = New System.Drawing.Point(351, 93)
        Me.bscIdNovedad.MaxLengh = "32767"
        Me.bscIdNovedad.Name = "bscIdNovedad"
        Me.bscIdNovedad.Permitido = True
        Me.bscIdNovedad.PermitidoNoBackColor = System.Drawing.Color.FromArgb(CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer))
        Me.bscIdNovedad.PermitidoNoForeColor = System.Drawing.Color.Black
        Me.bscIdNovedad.PermitidoSiBackColor = System.Drawing.Color.White
        Me.bscIdNovedad.PermitidoSiForeColor = System.Drawing.Color.Black
        Me.bscIdNovedad.Selecciono = False
        Me.bscIdNovedad.Size = New System.Drawing.Size(109, 20)
        Me.bscIdNovedad.TabIndex = 15
        '
        'cmbIdTipoNovedad
        '
        Me.cmbIdTipoNovedad.BindearPropiedadControl = "SelectedValue"
        Me.cmbIdTipoNovedad.BindearPropiedadEntidad = "IdTipoNovedad"
        Me.cmbIdTipoNovedad.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbIdTipoNovedad.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbIdTipoNovedad.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbIdTipoNovedad.FormattingEnabled = True
        Me.cmbIdTipoNovedad.IsPK = False
        Me.cmbIdTipoNovedad.IsRequired = True
        Me.cmbIdTipoNovedad.Key = Nothing
        Me.cmbIdTipoNovedad.LabelAsoc = Me.lblNovedad
        Me.cmbIdTipoNovedad.Location = New System.Drawing.Point(119, 92)
        Me.cmbIdTipoNovedad.Name = "cmbIdTipoNovedad"
        Me.cmbIdTipoNovedad.Size = New System.Drawing.Size(161, 21)
        Me.cmbIdTipoNovedad.TabIndex = 12
        '
        'txtEstadoCierre
        '
        Me.txtEstadoCierre.BindearPropiedadControl = ""
        Me.txtEstadoCierre.BindearPropiedadEntidad = ""
        Me.txtEstadoCierre.ForeColorFocus = System.Drawing.Color.Red
        Me.txtEstadoCierre.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtEstadoCierre.Formato = ""
        Me.txtEstadoCierre.IsDecimal = False
        Me.txtEstadoCierre.IsNumber = False
        Me.txtEstadoCierre.IsPK = False
        Me.txtEstadoCierre.IsRequired = False
        Me.txtEstadoCierre.Key = ""
        Me.txtEstadoCierre.LabelAsoc = Me.lblEstadoCierre
        Me.txtEstadoCierre.Location = New System.Drawing.Point(119, 208)
        Me.txtEstadoCierre.MaxLength = 20
        Me.txtEstadoCierre.Name = "txtEstadoCierre"
        Me.txtEstadoCierre.ReadOnly = True
        Me.txtEstadoCierre.Size = New System.Drawing.Size(161, 20)
        Me.txtEstadoCierre.TabIndex = 24
        '
        'lblEstadoCierre
        '
        Me.lblEstadoCierre.AutoSize = True
        Me.lblEstadoCierre.LabelAsoc = Nothing
        Me.lblEstadoCierre.Location = New System.Drawing.Point(22, 212)
        Me.lblEstadoCierre.Name = "lblEstadoCierre"
        Me.lblEstadoCierre.Size = New System.Drawing.Size(81, 13)
        Me.lblEstadoCierre.TabIndex = 23
        Me.lblEstadoCierre.Text = "Estado al Cierre"
        '
        'txtEstadoFin
        '
        Me.txtEstadoFin.BindearPropiedadControl = ""
        Me.txtEstadoFin.BindearPropiedadEntidad = ""
        Me.txtEstadoFin.ForeColorFocus = System.Drawing.Color.Red
        Me.txtEstadoFin.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtEstadoFin.Formato = ""
        Me.txtEstadoFin.IsDecimal = False
        Me.txtEstadoFin.IsNumber = False
        Me.txtEstadoFin.IsPK = False
        Me.txtEstadoFin.IsRequired = False
        Me.txtEstadoFin.Key = ""
        Me.txtEstadoFin.LabelAsoc = Me.lblEstadoFin
        Me.txtEstadoFin.Location = New System.Drawing.Point(119, 234)
        Me.txtEstadoFin.MaxLength = 20
        Me.txtEstadoFin.Name = "txtEstadoFin"
        Me.txtEstadoFin.ReadOnly = True
        Me.txtEstadoFin.Size = New System.Drawing.Size(161, 20)
        Me.txtEstadoFin.TabIndex = 26
        '
        'lblEstadoFin
        '
        Me.lblEstadoFin.AutoSize = True
        Me.lblEstadoFin.LabelAsoc = Nothing
        Me.lblEstadoFin.Location = New System.Drawing.Point(22, 238)
        Me.lblEstadoFin.Name = "lblEstadoFin"
        Me.lblEstadoFin.Size = New System.Drawing.Size(68, 13)
        Me.lblEstadoFin.TabIndex = 25
        Me.lblEstadoFin.Text = "Estado al Fin"
        '
        'Panel1
        '
        Me.Panel1.AutoSize = True
        Me.Panel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.Panel1.Controls.Add(Me.btnAceptar)
        Me.Panel1.Controls.Add(Me.btnCancelar)
        Me.Panel1.Controls.Add(Me.btnCopiar)
        Me.Panel1.Controls.Add(Me.btnAplicar)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel1.Location = New System.Drawing.Point(0, 296)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(588, 33)
        Me.Panel1.TabIndex = 28
        '
        'pnlUsuarios
        '
        Me.pnlUsuarios.AutoSize = True
        Me.pnlUsuarios.Controls.Add(Me.txtFechaActualizacion)
        Me.pnlUsuarios.Controls.Add(Me.txtIdUsuarioActualizacion)
        Me.pnlUsuarios.Controls.Add(Me.lblActualizacion)
        Me.pnlUsuarios.Controls.Add(Me.txtFechaAlta)
        Me.pnlUsuarios.Controls.Add(Me.txtIdUsuarioAlta)
        Me.pnlUsuarios.Controls.Add(Me.lblAlta)
        Me.pnlUsuarios.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnlUsuarios.Location = New System.Drawing.Point(0, 270)
        Me.pnlUsuarios.Name = "pnlUsuarios"
        Me.pnlUsuarios.Size = New System.Drawing.Size(588, 26)
        Me.pnlUsuarios.TabIndex = 27
        '
        'txtFechaActualizacion
        '
        Me.txtFechaActualizacion.BindearPropiedadControl = "Text"
        Me.txtFechaActualizacion.BindearPropiedadEntidad = "FechaActualizacion"
        Me.txtFechaActualizacion.ForeColorFocus = System.Drawing.Color.Red
        Me.txtFechaActualizacion.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtFechaActualizacion.Formato = "dd/MM/yyyy HH:mm"
        Me.txtFechaActualizacion.IsDecimal = False
        Me.txtFechaActualizacion.IsNumber = False
        Me.txtFechaActualizacion.IsPK = False
        Me.txtFechaActualizacion.IsRequired = False
        Me.txtFechaActualizacion.Key = ""
        Me.txtFechaActualizacion.LabelAsoc = Nothing
        Me.txtFechaActualizacion.Location = New System.Drawing.Point(461, 3)
        Me.txtFechaActualizacion.Name = "txtFechaActualizacion"
        Me.txtFechaActualizacion.ReadOnly = True
        Me.txtFechaActualizacion.Size = New System.Drawing.Size(120, 20)
        Me.txtFechaActualizacion.TabIndex = 5
        '
        'txtIdUsuarioActualizacion
        '
        Me.txtIdUsuarioActualizacion.BindearPropiedadControl = "Text"
        Me.txtIdUsuarioActualizacion.BindearPropiedadEntidad = "IdUsuarioActualizacion"
        Me.txtIdUsuarioActualizacion.ForeColorFocus = System.Drawing.Color.Red
        Me.txtIdUsuarioActualizacion.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtIdUsuarioActualizacion.Formato = ""
        Me.txtIdUsuarioActualizacion.IsDecimal = False
        Me.txtIdUsuarioActualizacion.IsNumber = False
        Me.txtIdUsuarioActualizacion.IsPK = False
        Me.txtIdUsuarioActualizacion.IsRequired = False
        Me.txtIdUsuarioActualizacion.Key = ""
        Me.txtIdUsuarioActualizacion.LabelAsoc = Nothing
        Me.txtIdUsuarioActualizacion.Location = New System.Drawing.Point(355, 3)
        Me.txtIdUsuarioActualizacion.Name = "txtIdUsuarioActualizacion"
        Me.txtIdUsuarioActualizacion.ReadOnly = True
        Me.txtIdUsuarioActualizacion.Size = New System.Drawing.Size(100, 20)
        Me.txtIdUsuarioActualizacion.TabIndex = 4
        '
        'lblActualizacion
        '
        Me.lblActualizacion.AutoSize = True
        Me.lblActualizacion.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblActualizacion.LabelAsoc = Nothing
        Me.lblActualizacion.Location = New System.Drawing.Point(279, 7)
        Me.lblActualizacion.Name = "lblActualizacion"
        Me.lblActualizacion.Size = New System.Drawing.Size(70, 13)
        Me.lblActualizacion.TabIndex = 3
        Me.lblActualizacion.Text = "Actualización"
        '
        'txtFechaAlta
        '
        Me.txtFechaAlta.BindearPropiedadControl = "Text"
        Me.txtFechaAlta.BindearPropiedadEntidad = "FechaAlta"
        Me.txtFechaAlta.ForeColorFocus = System.Drawing.Color.Red
        Me.txtFechaAlta.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtFechaAlta.Formato = "dd/MM/yyyy HH:mm"
        Me.txtFechaAlta.IsDecimal = False
        Me.txtFechaAlta.IsNumber = False
        Me.txtFechaAlta.IsPK = False
        Me.txtFechaAlta.IsRequired = False
        Me.txtFechaAlta.Key = ""
        Me.txtFechaAlta.LabelAsoc = Nothing
        Me.txtFechaAlta.Location = New System.Drawing.Point(146, 3)
        Me.txtFechaAlta.Name = "txtFechaAlta"
        Me.txtFechaAlta.ReadOnly = True
        Me.txtFechaAlta.Size = New System.Drawing.Size(120, 20)
        Me.txtFechaAlta.TabIndex = 2
        '
        'txtIdUsuarioAlta
        '
        Me.txtIdUsuarioAlta.BindearPropiedadControl = "Text"
        Me.txtIdUsuarioAlta.BindearPropiedadEntidad = "IdUsuarioAlta"
        Me.txtIdUsuarioAlta.ForeColorFocus = System.Drawing.Color.Red
        Me.txtIdUsuarioAlta.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtIdUsuarioAlta.Formato = ""
        Me.txtIdUsuarioAlta.IsDecimal = False
        Me.txtIdUsuarioAlta.IsNumber = False
        Me.txtIdUsuarioAlta.IsPK = False
        Me.txtIdUsuarioAlta.IsRequired = False
        Me.txtIdUsuarioAlta.Key = ""
        Me.txtIdUsuarioAlta.LabelAsoc = Nothing
        Me.txtIdUsuarioAlta.Location = New System.Drawing.Point(40, 3)
        Me.txtIdUsuarioAlta.Name = "txtIdUsuarioAlta"
        Me.txtIdUsuarioAlta.ReadOnly = True
        Me.txtIdUsuarioAlta.Size = New System.Drawing.Size(100, 20)
        Me.txtIdUsuarioAlta.TabIndex = 1
        '
        'lblAlta
        '
        Me.lblAlta.AutoSize = True
        Me.lblAlta.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblAlta.LabelAsoc = Nothing
        Me.lblAlta.Location = New System.Drawing.Point(9, 7)
        Me.lblAlta.Name = "lblAlta"
        Me.lblAlta.Size = New System.Drawing.Size(25, 13)
        Me.lblAlta.TabIndex = 0
        Me.lblAlta.Text = "Alta"
        '
        'lblFechaFinalizacion
        '
        Me.lblFechaFinalizacion.AutoSize = True
        Me.lblFechaFinalizacion.LabelAsoc = Nothing
        Me.lblFechaFinalizacion.Location = New System.Drawing.Point(408, 70)
        Me.lblFechaFinalizacion.Name = "lblFechaFinalizacion"
        Me.lblFechaFinalizacion.Size = New System.Drawing.Size(54, 13)
        Me.lblFechaFinalizacion.TabIndex = 9
        Me.lblFechaFinalizacion.Text = "Fecha Fin"
        '
        'lblFechaCierre
        '
        Me.lblFechaCierre.AutoSize = True
        Me.lblFechaCierre.LabelAsoc = Nothing
        Me.lblFechaCierre.Location = New System.Drawing.Point(225, 70)
        Me.lblFechaCierre.Name = "lblFechaCierre"
        Me.lblFechaCierre.Size = New System.Drawing.Size(67, 13)
        Me.lblFechaCierre.TabIndex = 7
        Me.lblFechaCierre.Text = "Fecha Cierre"
        '
        'lblFechaInicio
        '
        Me.lblFechaInicio.AutoSize = True
        Me.lblFechaInicio.LabelAsoc = Nothing
        Me.lblFechaInicio.Location = New System.Drawing.Point(22, 70)
        Me.lblFechaInicio.Name = "lblFechaInicio"
        Me.lblFechaInicio.Size = New System.Drawing.Size(65, 13)
        Me.lblFechaInicio.TabIndex = 5
        Me.lblFechaInicio.Text = "Fecha Inicio"
        '
        'dtpFechaFinalizacion
        '
        Me.dtpFechaFinalizacion.BindearPropiedadControl = ""
        Me.dtpFechaFinalizacion.BindearPropiedadEntidad = ""
        Me.dtpFechaFinalizacion.CustomFormat = "dd/MM/yyyy"
        Me.dtpFechaFinalizacion.Enabled = False
        Me.dtpFechaFinalizacion.ForeColorFocus = System.Drawing.Color.Red
        Me.dtpFechaFinalizacion.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.dtpFechaFinalizacion.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpFechaFinalizacion.IsPK = False
        Me.dtpFechaFinalizacion.IsRequired = False
        Me.dtpFechaFinalizacion.Key = ""
        Me.dtpFechaFinalizacion.LabelAsoc = Me.lblFechaFinalizacion
        Me.dtpFechaFinalizacion.Location = New System.Drawing.Point(468, 66)
        Me.dtpFechaFinalizacion.Name = "dtpFechaFinalizacion"
        Me.dtpFechaFinalizacion.Size = New System.Drawing.Size(100, 20)
        Me.dtpFechaFinalizacion.TabIndex = 10
        Me.dtpFechaFinalizacion.TabStop = False
        '
        'dtpFechaCierre
        '
        Me.dtpFechaCierre.BindearPropiedadControl = ""
        Me.dtpFechaCierre.BindearPropiedadEntidad = ""
        Me.dtpFechaCierre.CustomFormat = "dd/MM/yyyy"
        Me.dtpFechaCierre.Enabled = False
        Me.dtpFechaCierre.ForeColorFocus = System.Drawing.Color.Red
        Me.dtpFechaCierre.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.dtpFechaCierre.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpFechaCierre.IsPK = False
        Me.dtpFechaCierre.IsRequired = False
        Me.dtpFechaCierre.Key = ""
        Me.dtpFechaCierre.LabelAsoc = Me.lblFechaCierre
        Me.dtpFechaCierre.Location = New System.Drawing.Point(302, 66)
        Me.dtpFechaCierre.Name = "dtpFechaCierre"
        Me.dtpFechaCierre.Size = New System.Drawing.Size(100, 20)
        Me.dtpFechaCierre.TabIndex = 8
        Me.dtpFechaCierre.TabStop = False
        '
        'dtpFechaInicio
        '
        Me.dtpFechaInicio.BindearPropiedadControl = ""
        Me.dtpFechaInicio.BindearPropiedadEntidad = ""
        Me.dtpFechaInicio.CustomFormat = "dd/MM/yyyy"
        Me.dtpFechaInicio.Enabled = False
        Me.dtpFechaInicio.ForeColorFocus = System.Drawing.Color.Red
        Me.dtpFechaInicio.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.dtpFechaInicio.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpFechaInicio.IsPK = False
        Me.dtpFechaInicio.IsRequired = True
        Me.dtpFechaInicio.Key = ""
        Me.dtpFechaInicio.LabelAsoc = Me.lblFechaInicio
        Me.dtpFechaInicio.Location = New System.Drawing.Point(119, 66)
        Me.dtpFechaInicio.Name = "dtpFechaInicio"
        Me.dtpFechaInicio.Size = New System.Drawing.Size(100, 20)
        Me.dtpFechaInicio.TabIndex = 6
        Me.dtpFechaInicio.TabStop = False
        '
        'lblEstadoCicloPlanificacion
        '
        Me.lblEstadoCicloPlanificacion.AutoSize = True
        Me.lblEstadoCicloPlanificacion.LabelAsoc = Nothing
        Me.lblEstadoCicloPlanificacion.Location = New System.Drawing.Point(22, 42)
        Me.lblEstadoCicloPlanificacion.Name = "lblEstadoCicloPlanificacion"
        Me.lblEstadoCicloPlanificacion.Size = New System.Drawing.Size(40, 13)
        Me.lblEstadoCicloPlanificacion.TabIndex = 3
        Me.lblEstadoCicloPlanificacion.Text = "Estado"
        '
        'txtEstadoCicloPlanificacion
        '
        Me.txtEstadoCicloPlanificacion.BindearPropiedadControl = ""
        Me.txtEstadoCicloPlanificacion.BindearPropiedadEntidad = ""
        Me.txtEstadoCicloPlanificacion.ForeColorFocus = System.Drawing.Color.Red
        Me.txtEstadoCicloPlanificacion.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtEstadoCicloPlanificacion.Formato = ""
        Me.txtEstadoCicloPlanificacion.IsDecimal = False
        Me.txtEstadoCicloPlanificacion.IsNumber = False
        Me.txtEstadoCicloPlanificacion.IsPK = False
        Me.txtEstadoCicloPlanificacion.IsRequired = True
        Me.txtEstadoCicloPlanificacion.Key = ""
        Me.txtEstadoCicloPlanificacion.LabelAsoc = Nothing
        Me.txtEstadoCicloPlanificacion.Location = New System.Drawing.Point(119, 40)
        Me.txtEstadoCicloPlanificacion.MaxLength = 20
        Me.txtEstadoCicloPlanificacion.Name = "txtEstadoCicloPlanificacion"
        Me.txtEstadoCicloPlanificacion.ReadOnly = True
        Me.txtEstadoCicloPlanificacion.Size = New System.Drawing.Size(161, 20)
        Me.txtEstadoCicloPlanificacion.TabIndex = 4
        Me.txtEstadoCicloPlanificacion.TabStop = False
        '
        'CRMCiclosPlanificacionNovedadesDetalle
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(588, 329)
        Me.Controls.Add(Me.lblFechaFinalizacion)
        Me.Controls.Add(Me.lblFechaCierre)
        Me.Controls.Add(Me.lblFechaInicio)
        Me.Controls.Add(Me.dtpFechaFinalizacion)
        Me.Controls.Add(Me.dtpFechaCierre)
        Me.Controls.Add(Me.dtpFechaInicio)
        Me.Controls.Add(Me.lblEstadoCicloPlanificacion)
        Me.Controls.Add(Me.pnlUsuarios)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.txtCentroEmisor)
        Me.Controls.Add(Me.txtLetra)
        Me.Controls.Add(Me.bscIdNovedad)
        Me.Controls.Add(Me.lblNovedad)
        Me.Controls.Add(Me.cmbIdTipoNovedad)
        Me.Controls.Add(Me.lblCicloPlanificacion)
        Me.Controls.Add(Me.bscNombreCicloPlanificacion)
        Me.Controls.Add(Me.bscIdCicloPlanificacion)
        Me.Controls.Add(Me.chbPlanificada)
        Me.Controls.Add(Me.cmbTipoPlanificacion)
        Me.Controls.Add(Me.lblEstadoFin)
        Me.Controls.Add(Me.lblEstadoCierre)
        Me.Controls.Add(Me.lblEstadoInicio)
        Me.Controls.Add(Me.txtEstadoFin)
        Me.Controls.Add(Me.txtEstadoCierre)
        Me.Controls.Add(Me.txtEstadoCicloPlanificacion)
        Me.Controls.Add(Me.txtEstadoInicio)
        Me.Controls.Add(Me.lblTipoPlanificacion)
        Me.Controls.Add(Me.lblOrden)
        Me.Controls.Add(Me.txtOrden)
        Me.Name = "CRMCiclosPlanificacionNovedadesDetalle"
        Me.Text = "Novedad del Ciclo de Planificación"
        Me.Panel1.ResumeLayout(False)
        Me.pnlUsuarios.ResumeLayout(False)
        Me.pnlUsuarios.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cmbTipoPlanificacion As Eniac.Controles.ComboBox
   Friend WithEvents lblEstadoInicio As Eniac.Controles.Label
   Friend WithEvents txtEstadoInicio As Eniac.Controles.TextBox
   Friend WithEvents lblTipoPlanificacion As Eniac.Controles.Label
   Friend WithEvents lblOrden As Eniac.Controles.Label
    Friend WithEvents txtOrden As Eniac.Controles.TextBox
    Friend WithEvents chbPlanificada As Eniac.Controles.CheckBox
    Friend WithEvents cmb As Eniac.Controles.ComboBox
    Friend WithEvents cdColor As System.Windows.Forms.ColorDialog
    Friend WithEvents lblCicloPlanificacion As Controles.Label
    Friend WithEvents bscNombreCicloPlanificacion As Controles.Buscador2
    Friend WithEvents bscIdCicloPlanificacion As Controles.Buscador2
    Friend WithEvents txtCentroEmisor As Controles.TextBox
    Friend WithEvents txtLetra As Controles.TextBox
    Friend WithEvents bscIdNovedad As Controles.Buscador2
    Friend WithEvents lblNovedad As Controles.Label
    Friend WithEvents cmbIdTipoNovedad As Controles.ComboBox
    Friend WithEvents txtEstadoCierre As Controles.TextBox
    Friend WithEvents lblEstadoCierre As Controles.Label
    Friend WithEvents txtEstadoFin As Controles.TextBox
    Friend WithEvents lblEstadoFin As Controles.Label
    Friend WithEvents Panel1 As Panel
    Friend WithEvents pnlUsuarios As Panel
    Friend WithEvents txtFechaActualizacion As Controles.TextBox
    Friend WithEvents txtIdUsuarioActualizacion As Controles.TextBox
    Friend WithEvents lblActualizacion As Controles.Label
    Friend WithEvents txtFechaAlta As Controles.TextBox
    Friend WithEvents txtIdUsuarioAlta As Controles.TextBox
    Friend WithEvents lblAlta As Controles.Label
    Friend WithEvents lblFechaFinalizacion As Controles.Label
    Friend WithEvents lblFechaCierre As Controles.Label
    Friend WithEvents lblFechaInicio As Controles.Label
    Friend WithEvents dtpFechaFinalizacion As Controles.DateTimePicker
    Friend WithEvents dtpFechaCierre As Controles.DateTimePicker
    Friend WithEvents dtpFechaInicio As Controles.DateTimePicker
    Friend WithEvents lblEstadoCicloPlanificacion As Controles.Label
    Friend WithEvents txtEstadoCicloPlanificacion As Controles.TextBox
End Class
