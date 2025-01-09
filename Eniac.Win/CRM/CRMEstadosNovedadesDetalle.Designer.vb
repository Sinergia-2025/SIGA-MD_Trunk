<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CRMEstadosNovedadesDetalle
   Inherits BaseDetalle

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
      Me.cmbTipoNovedad = New Eniac.Controles.ComboBox()
      Me.lblDescripcion = New Eniac.Controles.Label()
      Me.txtNombreEstadoNovedad = New Eniac.Controles.TextBox()
      Me.Label1 = New Eniac.Controles.Label()
      Me.lblPosicion = New Eniac.Controles.Label()
      Me.lblCodigo = New Eniac.Controles.Label()
      Me.txtPosicion = New Eniac.Controles.TextBox()
      Me.txtIdEstadoNovedad = New Eniac.Controles.TextBox()
      Me.chbSolicitaUsuario = New Eniac.Controles.CheckBox()
      Me.chbFinalizado = New Eniac.Controles.CheckBox()
      Me.chbPorDefecto = New Eniac.Controles.CheckBox()
      Me.txtColor = New Eniac.Controles.TextBox()
      Me.lblColorSemadoro = New Eniac.Controles.Label()
      Me.btnColor = New System.Windows.Forms.Button()
      Me.cdColor = New System.Windows.Forms.ColorDialog()
      Me.chbDiasProximoContacto = New Eniac.Controles.CheckBox()
      Me.txtDiasProximoContacto = New Eniac.Controles.TextBox()
      Me.chbActualizaUsuarioResponsable = New Eniac.Controles.CheckBox()
      Me.chbSolicitaProveedor = New Eniac.Controles.CheckBox()
      Me.chbImprime = New Eniac.Controles.CheckBox()
      Me.txtReporte = New Eniac.Controles.TextBox()
      Me.Label2 = New Eniac.Controles.Label()
      Me.chbArchivoEmbebido = New Eniac.Controles.CheckBox()
      Me.chbAcumulaContador1 = New Eniac.Controles.CheckBox()
      Me.chbAcumulaContador2 = New Eniac.Controles.CheckBox()
      Me.chbEsFacturable = New Eniac.Controles.CheckBox()
      Me.Label3 = New Eniac.Controles.Label()
      Me.txtCantidadCopias = New Eniac.Controles.TextBox()
      Me.cmbTipoEstadoNovedad = New Eniac.Controles.ComboBox()
      Me.lbl_tipoEstado = New Eniac.Controles.Label()
      Me.cmbEntregado = New Eniac.Controles.ComboBox()
      Me.lblEntregado = New Eniac.Controles.Label()
      Me.cmbEstadoFacturado = New Eniac.Controles.ComboBox()
      Me.txtAvanceEstadoFacturado = New Eniac.Controles.TextBox()
      Me.Label4 = New System.Windows.Forms.Label()
      Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
      Me.pFacturable = New System.Windows.Forms.Panel()
      Me.lblEstadoLuego = New System.Windows.Forms.Label()
      Me.chbControlarStockConsumido = New Eniac.Controles.CheckBox()
        Me.chbRequiereComentarios = New Eniac.Controles.CheckBox()
        Me.pFacturable.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnAceptar
        '
        Me.btnAceptar.Location = New System.Drawing.Point(410, 299)
        Me.btnAceptar.Margin = New System.Windows.Forms.Padding(4)
        Me.btnAceptar.TabIndex = 35
        '
        'btnCancelar
        '
        Me.btnCancelar.Location = New System.Drawing.Point(496, 299)
        Me.btnCancelar.Margin = New System.Windows.Forms.Padding(4)
        Me.btnCancelar.TabIndex = 36
        '
        'btnCopiar
        '
        Me.btnCopiar.Location = New System.Drawing.Point(309, 299)
        Me.btnCopiar.Margin = New System.Windows.Forms.Padding(4)
        Me.btnCopiar.TabIndex = 38
        '
        'btnAplicar
        '
        Me.btnAplicar.Location = New System.Drawing.Point(250, 299)
        Me.btnAplicar.Margin = New System.Windows.Forms.Padding(4)
        Me.btnAplicar.TabIndex = 37
        '
        'cmbTipoNovedad
        '
        Me.cmbTipoNovedad.BindearPropiedadControl = "SelectedValue"
        Me.cmbTipoNovedad.BindearPropiedadEntidad = "TipoNovedad.IdTipoNovedad"
        Me.cmbTipoNovedad.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbTipoNovedad.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbTipoNovedad.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbTipoNovedad.FormattingEnabled = True
        Me.cmbTipoNovedad.IsPK = False
        Me.cmbTipoNovedad.IsRequired = False
        Me.cmbTipoNovedad.Key = Nothing
        Me.cmbTipoNovedad.LabelAsoc = Nothing
        Me.cmbTipoNovedad.Location = New System.Drawing.Point(86, 64)
        Me.cmbTipoNovedad.Name = "cmbTipoNovedad"
        Me.cmbTipoNovedad.Size = New System.Drawing.Size(150, 21)
        Me.cmbTipoNovedad.TabIndex = 5
        '
        'lblDescripcion
        '
        Me.lblDescripcion.AutoSize = True
        Me.lblDescripcion.LabelAsoc = Nothing
        Me.lblDescripcion.Location = New System.Drawing.Point(9, 42)
        Me.lblDescripcion.Name = "lblDescripcion"
        Me.lblDescripcion.Size = New System.Drawing.Size(63, 13)
        Me.lblDescripcion.TabIndex = 2
        Me.lblDescripcion.Text = "Descripción"
        '
        'txtNombreEstadoNovedad
        '
        Me.txtNombreEstadoNovedad.BindearPropiedadControl = "Text"
        Me.txtNombreEstadoNovedad.BindearPropiedadEntidad = "NombreEstadoNovedad"
        Me.txtNombreEstadoNovedad.ForeColorFocus = System.Drawing.Color.Red
        Me.txtNombreEstadoNovedad.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtNombreEstadoNovedad.Formato = ""
        Me.txtNombreEstadoNovedad.IsDecimal = False
        Me.txtNombreEstadoNovedad.IsNumber = False
        Me.txtNombreEstadoNovedad.IsPK = False
        Me.txtNombreEstadoNovedad.IsRequired = True
        Me.txtNombreEstadoNovedad.Key = ""
        Me.txtNombreEstadoNovedad.LabelAsoc = Me.lblDescripcion
        Me.txtNombreEstadoNovedad.Location = New System.Drawing.Point(86, 38)
        Me.txtNombreEstadoNovedad.MaxLength = 20
        Me.txtNombreEstadoNovedad.Name = "txtNombreEstadoNovedad"
        Me.txtNombreEstadoNovedad.Size = New System.Drawing.Size(263, 20)
        Me.txtNombreEstadoNovedad.TabIndex = 3
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.LabelAsoc = Nothing
        Me.Label1.Location = New System.Drawing.Point(9, 67)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(75, 13)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "Tipo Novedad"
        '
        'lblPosicion
        '
        Me.lblPosicion.AutoSize = True
        Me.lblPosicion.LabelAsoc = Nothing
        Me.lblPosicion.Location = New System.Drawing.Point(9, 94)
        Me.lblPosicion.Name = "lblPosicion"
        Me.lblPosicion.Size = New System.Drawing.Size(47, 13)
        Me.lblPosicion.TabIndex = 6
        Me.lblPosicion.Text = "Posición"
        '
        'lblCodigo
        '
        Me.lblCodigo.AutoSize = True
        Me.lblCodigo.LabelAsoc = Nothing
        Me.lblCodigo.Location = New System.Drawing.Point(9, 16)
        Me.lblCodigo.Name = "lblCodigo"
        Me.lblCodigo.Size = New System.Drawing.Size(40, 13)
        Me.lblCodigo.TabIndex = 0
        Me.lblCodigo.Text = "Codigo"
        '
        'txtPosicion
        '
        Me.txtPosicion.BindearPropiedadControl = "Text"
        Me.txtPosicion.BindearPropiedadEntidad = "Posicion"
        Me.txtPosicion.ForeColorFocus = System.Drawing.Color.Red
        Me.txtPosicion.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtPosicion.Formato = ""
        Me.txtPosicion.IsDecimal = False
        Me.txtPosicion.IsNumber = True
        Me.txtPosicion.IsPK = False
        Me.txtPosicion.IsRequired = True
        Me.txtPosicion.Key = ""
        Me.txtPosicion.LabelAsoc = Me.lblPosicion
        Me.txtPosicion.Location = New System.Drawing.Point(86, 91)
        Me.txtPosicion.MaxLength = 4
        Me.txtPosicion.Name = "txtPosicion"
        Me.txtPosicion.Size = New System.Drawing.Size(54, 20)
        Me.txtPosicion.TabIndex = 7
        Me.txtPosicion.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtIdEstadoNovedad
        '
        Me.txtIdEstadoNovedad.BindearPropiedadControl = "Text"
        Me.txtIdEstadoNovedad.BindearPropiedadEntidad = "IdEstadoNovedad"
        Me.txtIdEstadoNovedad.ForeColorFocus = System.Drawing.Color.Red
        Me.txtIdEstadoNovedad.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtIdEstadoNovedad.Formato = ""
        Me.txtIdEstadoNovedad.IsDecimal = False
        Me.txtIdEstadoNovedad.IsNumber = True
        Me.txtIdEstadoNovedad.IsPK = True
        Me.txtIdEstadoNovedad.IsRequired = True
        Me.txtIdEstadoNovedad.Key = ""
        Me.txtIdEstadoNovedad.LabelAsoc = Me.lblCodigo
        Me.txtIdEstadoNovedad.Location = New System.Drawing.Point(86, 12)
        Me.txtIdEstadoNovedad.MaxLength = 10
        Me.txtIdEstadoNovedad.Name = "txtIdEstadoNovedad"
        Me.txtIdEstadoNovedad.Size = New System.Drawing.Size(54, 20)
        Me.txtIdEstadoNovedad.TabIndex = 1
        Me.txtIdEstadoNovedad.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'chbSolicitaUsuario
        '
        Me.chbSolicitaUsuario.AutoSize = True
        Me.chbSolicitaUsuario.BindearPropiedadControl = "Checked"
        Me.chbSolicitaUsuario.BindearPropiedadEntidad = "SolicitaUsuario"
        Me.chbSolicitaUsuario.ForeColorFocus = System.Drawing.Color.Red
        Me.chbSolicitaUsuario.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbSolicitaUsuario.IsPK = False
        Me.chbSolicitaUsuario.IsRequired = False
        Me.chbSolicitaUsuario.Key = Nothing
        Me.chbSolicitaUsuario.LabelAsoc = Nothing
        Me.chbSolicitaUsuario.Location = New System.Drawing.Point(86, 164)
        Me.chbSolicitaUsuario.Name = "chbSolicitaUsuario"
        Me.chbSolicitaUsuario.Size = New System.Drawing.Size(99, 17)
        Me.chbSolicitaUsuario.TabIndex = 18
        Me.chbSolicitaUsuario.Text = "Solicita Usuario"
        Me.chbSolicitaUsuario.UseVisualStyleBackColor = True
        '
        'chbFinalizado
        '
        Me.chbFinalizado.AutoSize = True
        Me.chbFinalizado.BindearPropiedadControl = "Checked"
        Me.chbFinalizado.BindearPropiedadEntidad = "Finalizado"
        Me.chbFinalizado.ForeColorFocus = System.Drawing.Color.Red
        Me.chbFinalizado.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbFinalizado.IsPK = False
        Me.chbFinalizado.IsRequired = False
        Me.chbFinalizado.Key = Nothing
        Me.chbFinalizado.LabelAsoc = Nothing
        Me.chbFinalizado.Location = New System.Drawing.Point(86, 118)
        Me.chbFinalizado.Name = "chbFinalizado"
        Me.chbFinalizado.Size = New System.Drawing.Size(73, 17)
        Me.chbFinalizado.TabIndex = 16
        Me.chbFinalizado.Text = "Finalizado"
        Me.chbFinalizado.UseVisualStyleBackColor = True
        '
        'chbPorDefecto
        '
        Me.chbPorDefecto.AutoSize = True
        Me.chbPorDefecto.BindearPropiedadControl = "Checked"
        Me.chbPorDefecto.BindearPropiedadEntidad = "PorDefecto"
        Me.chbPorDefecto.ForeColorFocus = System.Drawing.Color.Red
        Me.chbPorDefecto.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbPorDefecto.IsPK = False
        Me.chbPorDefecto.IsRequired = False
        Me.chbPorDefecto.Key = Nothing
        Me.chbPorDefecto.LabelAsoc = Nothing
        Me.chbPorDefecto.Location = New System.Drawing.Point(86, 141)
        Me.chbPorDefecto.Name = "chbPorDefecto"
        Me.chbPorDefecto.Size = New System.Drawing.Size(83, 17)
        Me.chbPorDefecto.TabIndex = 17
        Me.chbPorDefecto.Text = "Por Defecto"
        Me.chbPorDefecto.UseVisualStyleBackColor = True
        '
        'txtColor
        '
        Me.txtColor.BindearPropiedadControl = "Key"
        Me.txtColor.BindearPropiedadEntidad = "Color"
        Me.txtColor.Enabled = False
        Me.txtColor.ForeColorFocus = System.Drawing.Color.Red
        Me.txtColor.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtColor.Formato = ""
        Me.txtColor.IsDecimal = False
        Me.txtColor.IsNumber = False
        Me.txtColor.IsPK = False
        Me.txtColor.IsRequired = False
        Me.txtColor.Key = ""
        Me.txtColor.LabelAsoc = Me.lblColorSemadoro
        Me.txtColor.Location = New System.Drawing.Point(425, 37)
        Me.txtColor.Name = "txtColor"
        Me.txtColor.ReadOnly = True
        Me.txtColor.Size = New System.Drawing.Size(82, 20)
        Me.txtColor.TabIndex = 11
        Me.txtColor.TabStop = False
        '
        'lblColorSemadoro
        '
        Me.lblColorSemadoro.AutoSize = True
        Me.lblColorSemadoro.LabelAsoc = Nothing
        Me.lblColorSemadoro.Location = New System.Drawing.Point(389, 41)
        Me.lblColorSemadoro.Name = "lblColorSemadoro"
        Me.lblColorSemadoro.Size = New System.Drawing.Size(31, 13)
        Me.lblColorSemadoro.TabIndex = 10
        Me.lblColorSemadoro.Text = "Color"
        '
        'btnColor
        '
        Me.btnColor.Location = New System.Drawing.Point(513, 36)
        Me.btnColor.Name = "btnColor"
        Me.btnColor.Size = New System.Drawing.Size(62, 23)
        Me.btnColor.TabIndex = 12
        Me.btnColor.Text = "Paleta"
        Me.btnColor.UseVisualStyleBackColor = True
        '
        'chbDiasProximoContacto
        '
        Me.chbDiasProximoContacto.AutoSize = True
        Me.chbDiasProximoContacto.BindearPropiedadControl = "Checked"
        Me.chbDiasProximoContacto.BindearPropiedadEntidad = "DiasProximoContacto"
        Me.chbDiasProximoContacto.ForeColorFocus = System.Drawing.Color.Red
        Me.chbDiasProximoContacto.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbDiasProximoContacto.IsPK = False
        Me.chbDiasProximoContacto.IsRequired = False
        Me.chbDiasProximoContacto.Key = Nothing
        Me.chbDiasProximoContacto.LabelAsoc = Nothing
        Me.chbDiasProximoContacto.Location = New System.Drawing.Point(86, 187)
        Me.chbDiasProximoContacto.Name = "chbDiasProximoContacto"
        Me.chbDiasProximoContacto.Size = New System.Drawing.Size(135, 17)
        Me.chbDiasProximoContacto.TabIndex = 19
        Me.chbDiasProximoContacto.Text = "Días Próximo Contacto"
        Me.chbDiasProximoContacto.UseVisualStyleBackColor = True
        '
        'txtDiasProximoContacto
        '
        Me.txtDiasProximoContacto.BindearPropiedadControl = "Text"
        Me.txtDiasProximoContacto.BindearPropiedadEntidad = "DiasProximoContacto"
        Me.txtDiasProximoContacto.Enabled = False
        Me.txtDiasProximoContacto.ForeColorFocus = System.Drawing.Color.Red
        Me.txtDiasProximoContacto.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtDiasProximoContacto.Formato = ""
        Me.txtDiasProximoContacto.IsDecimal = False
        Me.txtDiasProximoContacto.IsNumber = True
        Me.txtDiasProximoContacto.IsPK = False
        Me.txtDiasProximoContacto.IsRequired = False
        Me.txtDiasProximoContacto.Key = ""
        Me.txtDiasProximoContacto.LabelAsoc = Nothing
        Me.txtDiasProximoContacto.Location = New System.Drawing.Point(227, 184)
        Me.txtDiasProximoContacto.MaxLength = 2
        Me.txtDiasProximoContacto.Name = "txtDiasProximoContacto"
        Me.txtDiasProximoContacto.Size = New System.Drawing.Size(54, 20)
        Me.txtDiasProximoContacto.TabIndex = 20
        Me.txtDiasProximoContacto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'chbActualizaUsuarioResponsable
        '
        Me.chbActualizaUsuarioResponsable.AutoSize = True
        Me.chbActualizaUsuarioResponsable.BindearPropiedadControl = "Checked"
        Me.chbActualizaUsuarioResponsable.BindearPropiedadEntidad = "ActualizaUsuarioResponsable"
        Me.chbActualizaUsuarioResponsable.ForeColorFocus = System.Drawing.Color.Red
        Me.chbActualizaUsuarioResponsable.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbActualizaUsuarioResponsable.IsPK = False
        Me.chbActualizaUsuarioResponsable.IsRequired = False
        Me.chbActualizaUsuarioResponsable.Key = Nothing
        Me.chbActualizaUsuarioResponsable.LabelAsoc = Nothing
        Me.chbActualizaUsuarioResponsable.Location = New System.Drawing.Point(358, 118)
        Me.chbActualizaUsuarioResponsable.Name = "chbActualizaUsuarioResponsable"
        Me.chbActualizaUsuarioResponsable.Size = New System.Drawing.Size(173, 17)
        Me.chbActualizaUsuarioResponsable.TabIndex = 23
        Me.chbActualizaUsuarioResponsable.Text = "Actualiza Usuario Responsable"
        Me.chbActualizaUsuarioResponsable.UseVisualStyleBackColor = True
        '
        'chbSolicitaProveedor
        '
        Me.chbSolicitaProveedor.AutoSize = True
        Me.chbSolicitaProveedor.BindearPropiedadControl = "Checked"
        Me.chbSolicitaProveedor.BindearPropiedadEntidad = "SolicitaProveedorService"
        Me.chbSolicitaProveedor.ForeColorFocus = System.Drawing.Color.Red
        Me.chbSolicitaProveedor.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbSolicitaProveedor.IsPK = False
        Me.chbSolicitaProveedor.IsRequired = False
        Me.chbSolicitaProveedor.Key = Nothing
        Me.chbSolicitaProveedor.LabelAsoc = Nothing
        Me.chbSolicitaProveedor.Location = New System.Drawing.Point(86, 210)
        Me.chbSolicitaProveedor.Name = "chbSolicitaProveedor"
        Me.chbSolicitaProveedor.Size = New System.Drawing.Size(112, 17)
        Me.chbSolicitaProveedor.TabIndex = 21
        Me.chbSolicitaProveedor.Text = "Solicita Proveedor"
        Me.chbSolicitaProveedor.UseVisualStyleBackColor = True
        '
        'chbImprime
        '
        Me.chbImprime.AutoSize = True
        Me.chbImprime.BindearPropiedadControl = "Checked"
        Me.chbImprime.BindearPropiedadEntidad = "Imprime"
        Me.chbImprime.ForeColorFocus = System.Drawing.Color.Red
        Me.chbImprime.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbImprime.IsPK = False
        Me.chbImprime.IsRequired = False
        Me.chbImprime.Key = Nothing
        Me.chbImprime.LabelAsoc = Nothing
        Me.chbImprime.Location = New System.Drawing.Point(12, 271)
        Me.chbImprime.Name = "chbImprime"
        Me.chbImprime.Size = New System.Drawing.Size(62, 17)
        Me.chbImprime.TabIndex = 29
        Me.chbImprime.Text = "Imprime"
        Me.chbImprime.UseVisualStyleBackColor = True
        '
        'txtReporte
        '
        Me.txtReporte.BindearPropiedadControl = "Text"
        Me.txtReporte.BindearPropiedadEntidad = "Reporte"
        Me.txtReporte.ForeColorFocus = System.Drawing.Color.Red
        Me.txtReporte.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtReporte.Formato = ""
        Me.txtReporte.IsDecimal = False
        Me.txtReporte.IsNumber = False
        Me.txtReporte.IsPK = False
        Me.txtReporte.IsRequired = False
        Me.txtReporte.Key = ""
        Me.txtReporte.LabelAsoc = Me.Label2
        Me.txtReporte.Location = New System.Drawing.Point(86, 269)
        Me.txtReporte.Name = "txtReporte"
        Me.txtReporte.Size = New System.Drawing.Size(223, 20)
        Me.txtReporte.TabIndex = 31
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.LabelAsoc = Nothing
        Me.Label2.Location = New System.Drawing.Point(83, 253)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(45, 13)
        Me.Label2.TabIndex = 30
        Me.Label2.Text = "Reporte"
        '
        'chbArchivoEmbebido
        '
        Me.chbArchivoEmbebido.AutoSize = True
        Me.chbArchivoEmbebido.BindearPropiedadControl = "Checked"
        Me.chbArchivoEmbebido.BindearPropiedadEntidad = "Embebido"
        Me.chbArchivoEmbebido.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.chbArchivoEmbebido.ForeColorFocus = System.Drawing.Color.Red
        Me.chbArchivoEmbebido.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbArchivoEmbebido.IsPK = False
        Me.chbArchivoEmbebido.IsRequired = False
        Me.chbArchivoEmbebido.Key = Nothing
        Me.chbArchivoEmbebido.LabelAsoc = Nothing
        Me.chbArchivoEmbebido.Location = New System.Drawing.Point(314, 271)
        Me.chbArchivoEmbebido.Name = "chbArchivoEmbebido"
        Me.chbArchivoEmbebido.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.chbArchivoEmbebido.Size = New System.Drawing.Size(73, 17)
        Me.chbArchivoEmbebido.TabIndex = 32
        Me.chbArchivoEmbebido.Text = "Embebido"
        Me.chbArchivoEmbebido.UseVisualStyleBackColor = True
        '
        'chbAcumulaContador1
        '
        Me.chbAcumulaContador1.AutoSize = True
        Me.chbAcumulaContador1.BindearPropiedadControl = "Checked"
        Me.chbAcumulaContador1.BindearPropiedadEntidad = "AcumulaContador1"
        Me.chbAcumulaContador1.ForeColorFocus = System.Drawing.Color.Red
        Me.chbAcumulaContador1.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbAcumulaContador1.IsPK = False
        Me.chbAcumulaContador1.IsRequired = False
        Me.chbAcumulaContador1.Key = Nothing
        Me.chbAcumulaContador1.LabelAsoc = Nothing
        Me.chbAcumulaContador1.Location = New System.Drawing.Point(358, 142)
        Me.chbAcumulaContador1.Name = "chbAcumulaContador1"
        Me.chbAcumulaContador1.Size = New System.Drawing.Size(122, 17)
        Me.chbAcumulaContador1.TabIndex = 24
        Me.chbAcumulaContador1.Text = "Acumula Contador 1"
        Me.chbAcumulaContador1.UseVisualStyleBackColor = True
        '
        'chbAcumulaContador2
        '
        Me.chbAcumulaContador2.AutoSize = True
        Me.chbAcumulaContador2.BindearPropiedadControl = "Checked"
        Me.chbAcumulaContador2.BindearPropiedadEntidad = "AcumulaContador2"
        Me.chbAcumulaContador2.ForeColorFocus = System.Drawing.Color.Red
        Me.chbAcumulaContador2.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbAcumulaContador2.IsPK = False
        Me.chbAcumulaContador2.IsRequired = False
        Me.chbAcumulaContador2.Key = Nothing
        Me.chbAcumulaContador2.LabelAsoc = Nothing
        Me.chbAcumulaContador2.Location = New System.Drawing.Point(358, 165)
        Me.chbAcumulaContador2.Name = "chbAcumulaContador2"
        Me.chbAcumulaContador2.Size = New System.Drawing.Size(122, 17)
        Me.chbAcumulaContador2.TabIndex = 25
        Me.chbAcumulaContador2.Text = "Acumula Contador 2"
        Me.chbAcumulaContador2.UseVisualStyleBackColor = True
        '
        'chbEsFacturable
        '
        Me.chbEsFacturable.AutoSize = True
        Me.chbEsFacturable.BindearPropiedadControl = "Checked"
        Me.chbEsFacturable.BindearPropiedadEntidad = "EsFacturable"
        Me.chbEsFacturable.ForeColorFocus = System.Drawing.Color.Red
        Me.chbEsFacturable.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbEsFacturable.IsPK = False
        Me.chbEsFacturable.IsRequired = False
        Me.chbEsFacturable.Key = Nothing
        Me.chbEsFacturable.LabelAsoc = Nothing
        Me.chbEsFacturable.Location = New System.Drawing.Point(358, 188)
        Me.chbEsFacturable.Name = "chbEsFacturable"
        Me.chbEsFacturable.Size = New System.Drawing.Size(91, 17)
        Me.chbEsFacturable.TabIndex = 26
        Me.chbEsFacturable.Text = "Es Facturable"
        Me.chbEsFacturable.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.LabelAsoc = Nothing
        Me.Label3.Location = New System.Drawing.Point(387, 253)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(39, 13)
        Me.Label3.TabIndex = 33
        Me.Label3.Text = "Copias"
        '
        'txtCantidadCopias
        '
        Me.txtCantidadCopias.BindearPropiedadControl = "Text"
        Me.txtCantidadCopias.BindearPropiedadEntidad = "CantidadCopias"
        Me.txtCantidadCopias.ForeColorFocus = System.Drawing.Color.Red
        Me.txtCantidadCopias.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtCantidadCopias.Formato = ""
        Me.txtCantidadCopias.IsDecimal = False
        Me.txtCantidadCopias.IsNumber = True
        Me.txtCantidadCopias.IsPK = False
        Me.txtCantidadCopias.IsRequired = True
        Me.txtCantidadCopias.Key = ""
        Me.txtCantidadCopias.LabelAsoc = Me.Label3
        Me.txtCantidadCopias.Location = New System.Drawing.Point(390, 269)
        Me.txtCantidadCopias.MaxLength = 5
        Me.txtCantidadCopias.Name = "txtCantidadCopias"
        Me.txtCantidadCopias.Size = New System.Drawing.Size(33, 20)
        Me.txtCantidadCopias.TabIndex = 34
        Me.txtCantidadCopias.Text = "1"
        Me.txtCantidadCopias.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'cmbTipoEstadoNovedad
        '
        Me.cmbTipoEstadoNovedad.BindearPropiedadControl = ""
        Me.cmbTipoEstadoNovedad.BindearPropiedadEntidad = ""
        Me.cmbTipoEstadoNovedad.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbTipoEstadoNovedad.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbTipoEstadoNovedad.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbTipoEstadoNovedad.FormattingEnabled = True
        Me.cmbTipoEstadoNovedad.IsPK = False
        Me.cmbTipoEstadoNovedad.IsRequired = False
        Me.cmbTipoEstadoNovedad.Key = Nothing
        Me.cmbTipoEstadoNovedad.LabelAsoc = Nothing
        Me.cmbTipoEstadoNovedad.Location = New System.Drawing.Point(425, 11)
        Me.cmbTipoEstadoNovedad.Name = "cmbTipoEstadoNovedad"
        Me.cmbTipoEstadoNovedad.Size = New System.Drawing.Size(150, 21)
        Me.cmbTipoEstadoNovedad.TabIndex = 9
        '
        'lbl_tipoEstado
        '
        Me.lbl_tipoEstado.AutoSize = True
        Me.lbl_tipoEstado.LabelAsoc = Nothing
        Me.lbl_tipoEstado.Location = New System.Drawing.Point(355, 14)
        Me.lbl_tipoEstado.Name = "lbl_tipoEstado"
        Me.lbl_tipoEstado.Size = New System.Drawing.Size(64, 13)
        Me.lbl_tipoEstado.TabIndex = 8
        Me.lbl_tipoEstado.Text = "Tipo Estado"
        '
        'cmbEntregado
        '
        Me.cmbEntregado.BindearPropiedadControl = "SelectedValue"
        Me.cmbEntregado.BindearPropiedadEntidad = "Entregado"
        Me.cmbEntregado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbEntregado.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbEntregado.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbEntregado.FormattingEnabled = True
        Me.cmbEntregado.IsPK = False
        Me.cmbEntregado.IsRequired = False
        Me.cmbEntregado.Key = Nothing
        Me.cmbEntregado.LabelAsoc = Nothing
        Me.cmbEntregado.Location = New System.Drawing.Point(425, 63)
        Me.cmbEntregado.Name = "cmbEntregado"
        Me.cmbEntregado.Size = New System.Drawing.Size(150, 21)
        Me.cmbEntregado.TabIndex = 14
        '
        'lblEntregado
        '
        Me.lblEntregado.AutoSize = True
        Me.lblEntregado.LabelAsoc = Nothing
        Me.lblEntregado.Location = New System.Drawing.Point(355, 67)
        Me.lblEntregado.Name = "lblEntregado"
        Me.lblEntregado.Size = New System.Drawing.Size(56, 13)
        Me.lblEntregado.TabIndex = 13
        Me.lblEntregado.Text = "Entregado"
        '
        'cmbEstadoFacturado
        '
        Me.cmbEstadoFacturado.BindearPropiedadControl = "SelectedValue"
        Me.cmbEstadoFacturado.BindearPropiedadEntidad = "IdEstadoFacturado"
        Me.cmbEstadoFacturado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbEstadoFacturado.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbEstadoFacturado.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbEstadoFacturado.FormattingEnabled = True
        Me.cmbEstadoFacturado.IsPK = False
        Me.cmbEstadoFacturado.IsRequired = False
        Me.cmbEstadoFacturado.Key = Nothing
        Me.cmbEstadoFacturado.LabelAsoc = Nothing
        Me.cmbEstadoFacturado.Location = New System.Drawing.Point(3, 3)
        Me.cmbEstadoFacturado.Name = "cmbEstadoFacturado"
        Me.cmbEstadoFacturado.Size = New System.Drawing.Size(150, 21)
        Me.cmbEstadoFacturado.TabIndex = 0
        '
        'txtAvanceEstadoFacturado
        '
        Me.txtAvanceEstadoFacturado.BindearPropiedadControl = "Text"
        Me.txtAvanceEstadoFacturado.BindearPropiedadEntidad = "AvanceEstadoFacturado"
        Me.txtAvanceEstadoFacturado.ForeColorFocus = System.Drawing.Color.Red
        Me.txtAvanceEstadoFacturado.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtAvanceEstadoFacturado.Formato = ""
        Me.txtAvanceEstadoFacturado.IsDecimal = True
        Me.txtAvanceEstadoFacturado.IsNumber = True
        Me.txtAvanceEstadoFacturado.IsPK = False
        Me.txtAvanceEstadoFacturado.IsRequired = False
        Me.txtAvanceEstadoFacturado.Key = ""
        Me.txtAvanceEstadoFacturado.LabelAsoc = Nothing
        Me.txtAvanceEstadoFacturado.Location = New System.Drawing.Point(159, 3)
        Me.txtAvanceEstadoFacturado.MaxLength = 6
        Me.txtAvanceEstadoFacturado.Name = "txtAvanceEstadoFacturado"
        Me.txtAvanceEstadoFacturado.Size = New System.Drawing.Size(41, 20)
        Me.txtAvanceEstadoFacturado.TabIndex = 1
        Me.txtAvanceEstadoFacturado.Text = "1"
        Me.txtAvanceEstadoFacturado.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.ToolTip1.SetToolTip(Me.txtAvanceEstadoFacturado, "Avance del estado al ser facturado.")
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(206, 6)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(15, 13)
        Me.Label4.TabIndex = 2
        Me.Label4.Text = "%"
        '
        'pFacturable
        '
        Me.pFacturable.Controls.Add(Me.cmbEstadoFacturado)
        Me.pFacturable.Controls.Add(Me.Label4)
        Me.pFacturable.Controls.Add(Me.txtAvanceEstadoFacturado)
        Me.pFacturable.Location = New System.Drawing.Point(355, 205)
        Me.pFacturable.Name = "pFacturable"
        Me.pFacturable.Size = New System.Drawing.Size(228, 27)
        Me.pFacturable.TabIndex = 28
        Me.pFacturable.Visible = False
        '
        'lblEstadoLuego
        '
        Me.lblEstadoLuego.AutoSize = True
        Me.lblEstadoLuego.Location = New System.Drawing.Point(283, 211)
        Me.lblEstadoLuego.Name = "lblEstadoLuego"
        Me.lblEstadoLuego.Size = New System.Drawing.Size(69, 13)
        Me.lblEstadoLuego.TabIndex = 27
        Me.lblEstadoLuego.Text = "Estado luego"
        Me.lblEstadoLuego.Visible = False
        '
        'chbControlarStockConsumido
        '
        Me.chbControlarStockConsumido.AutoSize = True
        Me.chbControlarStockConsumido.BindearPropiedadControl = "Checked"
        Me.chbControlarStockConsumido.BindearPropiedadEntidad = "ControlaStockConsumido"
        Me.chbControlarStockConsumido.ForeColorFocus = System.Drawing.Color.Red
        Me.chbControlarStockConsumido.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbControlarStockConsumido.IsPK = False
        Me.chbControlarStockConsumido.IsRequired = False
        Me.chbControlarStockConsumido.Key = Nothing
        Me.chbControlarStockConsumido.LabelAsoc = Nothing
        Me.chbControlarStockConsumido.Location = New System.Drawing.Point(358, 93)
        Me.chbControlarStockConsumido.Name = "chbControlarStockConsumido"
        Me.chbControlarStockConsumido.Size = New System.Drawing.Size(154, 17)
        Me.chbControlarStockConsumido.TabIndex = 15
        Me.chbControlarStockConsumido.Text = "Controlar Stock Consumido"
        Me.chbControlarStockConsumido.UseVisualStyleBackColor = True
        '
        'chbRequiereComentarios
        '
        Me.chbRequiereComentarios.AutoSize = True
        Me.chbRequiereComentarios.BindearPropiedadControl = "Checked"
        Me.chbRequiereComentarios.BindearPropiedadEntidad = "RequiereComentarios"
        Me.chbRequiereComentarios.ForeColorFocus = System.Drawing.Color.Red
        Me.chbRequiereComentarios.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbRequiereComentarios.IsPK = False
        Me.chbRequiereComentarios.IsRequired = False
        Me.chbRequiereComentarios.Key = Nothing
        Me.chbRequiereComentarios.LabelAsoc = Nothing
        Me.chbRequiereComentarios.Location = New System.Drawing.Point(86, 233)
        Me.chbRequiereComentarios.Name = "chbRequiereComentarios"
        Me.chbRequiereComentarios.Size = New System.Drawing.Size(130, 17)
        Me.chbRequiereComentarios.TabIndex = 22
        Me.chbRequiereComentarios.Text = "Requiere Comentarios"
        Me.chbRequiereComentarios.UseVisualStyleBackColor = True
        '
        'CRMEstadosNovedadesDetalle
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(585, 333)
        Me.Controls.Add(Me.chbControlarStockConsumido)
        Me.Controls.Add(Me.lblEstadoLuego)
        Me.Controls.Add(Me.pFacturable)
        Me.Controls.Add(Me.cmbEntregado)
        Me.Controls.Add(Me.lblEntregado)
        Me.Controls.Add(Me.cmbTipoEstadoNovedad)
        Me.Controls.Add(Me.lbl_tipoEstado)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txtCantidadCopias)
        Me.Controls.Add(Me.chbEsFacturable)
        Me.Controls.Add(Me.chbAcumulaContador2)
        Me.Controls.Add(Me.chbAcumulaContador1)
        Me.Controls.Add(Me.chbArchivoEmbebido)
        Me.Controls.Add(Me.txtReporte)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.chbImprime)
        Me.Controls.Add(Me.chbRequiereComentarios)
        Me.Controls.Add(Me.chbSolicitaProveedor)
        Me.Controls.Add(Me.chbActualizaUsuarioResponsable)
        Me.Controls.Add(Me.txtColor)
        Me.Controls.Add(Me.lblColorSemadoro)
        Me.Controls.Add(Me.btnColor)
        Me.Controls.Add(Me.chbDiasProximoContacto)
        Me.Controls.Add(Me.chbPorDefecto)
        Me.Controls.Add(Me.chbFinalizado)
        Me.Controls.Add(Me.chbSolicitaUsuario)
        Me.Controls.Add(Me.cmbTipoNovedad)
        Me.Controls.Add(Me.lblDescripcion)
        Me.Controls.Add(Me.txtNombreEstadoNovedad)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.lblPosicion)
        Me.Controls.Add(Me.lblCodigo)
        Me.Controls.Add(Me.txtDiasProximoContacto)
        Me.Controls.Add(Me.txtPosicion)
        Me.Controls.Add(Me.txtIdEstadoNovedad)
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "CRMEstadosNovedadesDetalle"
        Me.Text = "Estado Novedad"
        Me.Controls.SetChildIndex(Me.txtIdEstadoNovedad, 0)
        Me.Controls.SetChildIndex(Me.txtPosicion, 0)
        Me.Controls.SetChildIndex(Me.txtDiasProximoContacto, 0)
        Me.Controls.SetChildIndex(Me.lblCodigo, 0)
        Me.Controls.SetChildIndex(Me.lblPosicion, 0)
        Me.Controls.SetChildIndex(Me.Label1, 0)
        Me.Controls.SetChildIndex(Me.txtNombreEstadoNovedad, 0)
        Me.Controls.SetChildIndex(Me.lblDescripcion, 0)
        Me.Controls.SetChildIndex(Me.cmbTipoNovedad, 0)
        Me.Controls.SetChildIndex(Me.chbSolicitaUsuario, 0)
        Me.Controls.SetChildIndex(Me.chbFinalizado, 0)
        Me.Controls.SetChildIndex(Me.chbPorDefecto, 0)
        Me.Controls.SetChildIndex(Me.chbDiasProximoContacto, 0)
        Me.Controls.SetChildIndex(Me.btnColor, 0)
        Me.Controls.SetChildIndex(Me.lblColorSemadoro, 0)
        Me.Controls.SetChildIndex(Me.txtColor, 0)
        Me.Controls.SetChildIndex(Me.btnAplicar, 0)
        Me.Controls.SetChildIndex(Me.btnCopiar, 0)
        Me.Controls.SetChildIndex(Me.btnCancelar, 0)
        Me.Controls.SetChildIndex(Me.btnAceptar, 0)
        Me.Controls.SetChildIndex(Me.chbActualizaUsuarioResponsable, 0)
        Me.Controls.SetChildIndex(Me.chbSolicitaProveedor, 0)
        Me.Controls.SetChildIndex(Me.chbRequiereComentarios, 0)
        Me.Controls.SetChildIndex(Me.chbImprime, 0)
        Me.Controls.SetChildIndex(Me.Label2, 0)
        Me.Controls.SetChildIndex(Me.txtReporte, 0)
        Me.Controls.SetChildIndex(Me.chbArchivoEmbebido, 0)
        Me.Controls.SetChildIndex(Me.chbAcumulaContador1, 0)
        Me.Controls.SetChildIndex(Me.chbAcumulaContador2, 0)
        Me.Controls.SetChildIndex(Me.chbEsFacturable, 0)
        Me.Controls.SetChildIndex(Me.txtCantidadCopias, 0)
        Me.Controls.SetChildIndex(Me.Label3, 0)
        Me.Controls.SetChildIndex(Me.lbl_tipoEstado, 0)
        Me.Controls.SetChildIndex(Me.cmbTipoEstadoNovedad, 0)
        Me.Controls.SetChildIndex(Me.lblEntregado, 0)
        Me.Controls.SetChildIndex(Me.cmbEntregado, 0)
        Me.Controls.SetChildIndex(Me.pFacturable, 0)
        Me.Controls.SetChildIndex(Me.lblEstadoLuego, 0)
        Me.Controls.SetChildIndex(Me.chbControlarStockConsumido, 0)
        Me.pFacturable.ResumeLayout(False)
        Me.pFacturable.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cmbTipoNovedad As Eniac.Controles.ComboBox
   Friend WithEvents lblDescripcion As Eniac.Controles.Label
   Friend WithEvents txtNombreEstadoNovedad As Eniac.Controles.TextBox
   Friend WithEvents Label1 As Eniac.Controles.Label
   Friend WithEvents lblPosicion As Eniac.Controles.Label
   Friend WithEvents lblCodigo As Eniac.Controles.Label
   Friend WithEvents txtPosicion As Eniac.Controles.TextBox
   Friend WithEvents txtIdEstadoNovedad As Eniac.Controles.TextBox
   Friend WithEvents chbSolicitaUsuario As Eniac.Controles.CheckBox
   Friend WithEvents chbFinalizado As Eniac.Controles.CheckBox
   Friend WithEvents chbPorDefecto As Eniac.Controles.CheckBox
   Friend WithEvents txtColor As Eniac.Controles.TextBox
   Friend WithEvents lblColorSemadoro As Eniac.Controles.Label
   Friend WithEvents btnColor As System.Windows.Forms.Button
   Friend WithEvents cdColor As System.Windows.Forms.ColorDialog
   Friend WithEvents chbDiasProximoContacto As Eniac.Controles.CheckBox
   Friend WithEvents txtDiasProximoContacto As Eniac.Controles.TextBox
   Friend WithEvents chbActualizaUsuarioResponsable As Eniac.Controles.CheckBox
   Friend WithEvents chbSolicitaProveedor As Eniac.Controles.CheckBox
   Friend WithEvents chbImprime As Eniac.Controles.CheckBox
   Friend WithEvents txtReporte As Eniac.Controles.TextBox
   Friend WithEvents Label2 As Eniac.Controles.Label
   Friend WithEvents chbArchivoEmbebido As Eniac.Controles.CheckBox
   Friend WithEvents chbAcumulaContador1 As Eniac.Controles.CheckBox
   Friend WithEvents chbAcumulaContador2 As Eniac.Controles.CheckBox
   Friend WithEvents chbEsFacturable As Eniac.Controles.CheckBox
   Friend WithEvents Label3 As Eniac.Controles.Label
   Friend WithEvents txtCantidadCopias As Eniac.Controles.TextBox
   Friend WithEvents cmbTipoEstadoNovedad As Eniac.Controles.ComboBox
   Friend WithEvents lbl_tipoEstado As Eniac.Controles.Label
   Friend WithEvents cmbEntregado As Eniac.Controles.ComboBox
   Friend WithEvents lblEntregado As Eniac.Controles.Label
   Friend WithEvents cmbEstadoFacturado As Eniac.Controles.ComboBox
   Friend WithEvents txtAvanceEstadoFacturado As Eniac.Controles.TextBox
   Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
   Friend WithEvents Label4 As System.Windows.Forms.Label
   Friend WithEvents pFacturable As System.Windows.Forms.Panel
   Friend WithEvents lblEstadoLuego As System.Windows.Forms.Label
    Friend WithEvents chbControlarStockConsumido As Controles.CheckBox
    Friend WithEvents chbRequiereComentarios As Controles.CheckBox
End Class
