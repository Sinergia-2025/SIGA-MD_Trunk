<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CambiarTransportistaComprobante
	Inherits Eniac.Win.BaseDetalle

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
        Me.gpbTipoComprobante = New System.Windows.Forms.GroupBox()
        Me.lblTipoComprobanteNuevo = New Eniac.Controles.Label()
        Me.cmbTipoComprobanteNuevo = New Eniac.Controles.ComboBox()
        Me.txtLetra = New System.Windows.Forms.TextBox()
        Me.txtNumeroComprobante = New System.Windows.Forms.TextBox()
        Me.txtIdTipoComprobante = New System.Windows.Forms.TextBox()
        Me.gpbResponsableDistribucion = New System.Windows.Forms.GroupBox()
        Me.lblResponsableDistribucionNuevo = New Eniac.Controles.Label()
      Me.bscCodigoRDNuevo = New Eniac.Controles.Buscador2()
      Me.bscNombreRDNuevo = New Eniac.Controles.Buscador2()
      Me.lblCambioMasivoRD = New Eniac.Controles.Label()
        Me.chbTipoComprobante = New Eniac.Controles.CheckBox()
        Me.chbResponsableDistribucion = New Eniac.Controles.CheckBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtPedidosSeleccionados = New System.Windows.Forms.TextBox()
        Me.lblPedidosSeleccionados = New System.Windows.Forms.Label()
        Me.txtTotalPedidos = New System.Windows.Forms.TextBox()
        Me.lblTotalPedidos = New System.Windows.Forms.Label()
        Me.cmbCambioMasivo = New Eniac.Controles.ComboBox()
        Me.gpbTipoComprobante.SuspendLayout()
        Me.gpbResponsableDistribucion.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnAceptar
        '
        Me.btnAceptar.Location = New System.Drawing.Point(254, 253)
        '
        'btnCancelar
        '
        Me.btnCancelar.Location = New System.Drawing.Point(340, 253)
        '
        'btnCopiar
        '
        Me.btnCopiar.Location = New System.Drawing.Point(153, 253)
        '
        'btnAplicar
        '
        Me.btnAplicar.Location = New System.Drawing.Point(96, 253)
        '
        'gpbTipoComprobante
        '
        Me.gpbTipoComprobante.Controls.Add(Me.lblTipoComprobanteNuevo)
        Me.gpbTipoComprobante.Controls.Add(Me.cmbTipoComprobanteNuevo)
        Me.gpbTipoComprobante.Enabled = False
        Me.gpbTipoComprobante.Location = New System.Drawing.Point(12, 76)
        Me.gpbTipoComprobante.Name = "gpbTipoComprobante"
        Me.gpbTipoComprobante.Size = New System.Drawing.Size(408, 60)
        Me.gpbTipoComprobante.TabIndex = 0
        Me.gpbTipoComprobante.TabStop = False
        Me.gpbTipoComprobante.Text = "                                  "
        '
        'lblTipoComprobanteNuevo
        '
        Me.lblTipoComprobanteNuevo.AutoSize = True
        Me.lblTipoComprobanteNuevo.LabelAsoc = Nothing
        Me.lblTipoComprobanteNuevo.Location = New System.Drawing.Point(20, 27)
        Me.lblTipoComprobanteNuevo.Name = "lblTipoComprobanteNuevo"
        Me.lblTipoComprobanteNuevo.Size = New System.Drawing.Size(39, 13)
        Me.lblTipoComprobanteNuevo.TabIndex = 91
        Me.lblTipoComprobanteNuevo.Text = "Nuevo"
        '
        'cmbTipoComprobanteNuevo
        '
        Me.cmbTipoComprobanteNuevo.BindearPropiedadControl = "SelectedValue"
        Me.cmbTipoComprobanteNuevo.BindearPropiedadEntidad = "ventas.idformaspago"
        Me.cmbTipoComprobanteNuevo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbTipoComprobanteNuevo.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbTipoComprobanteNuevo.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbTipoComprobanteNuevo.FormattingEnabled = True
        Me.cmbTipoComprobanteNuevo.IsPK = False
        Me.cmbTipoComprobanteNuevo.IsRequired = True
        Me.cmbTipoComprobanteNuevo.Key = Nothing
        Me.cmbTipoComprobanteNuevo.LabelAsoc = Me.lblTipoComprobanteNuevo
        Me.cmbTipoComprobanteNuevo.Location = New System.Drawing.Point(82, 24)
        Me.cmbTipoComprobanteNuevo.Name = "cmbTipoComprobanteNuevo"
        Me.cmbTipoComprobanteNuevo.Size = New System.Drawing.Size(307, 21)
        Me.cmbTipoComprobanteNuevo.TabIndex = 81
        '
        'txtLetra
        '
        Me.txtLetra.Location = New System.Drawing.Point(263, 10)
        Me.txtLetra.Name = "txtLetra"
        Me.txtLetra.Size = New System.Drawing.Size(52, 20)
        Me.txtLetra.TabIndex = 80
        Me.txtLetra.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtNumeroComprobante
        '
        Me.txtNumeroComprobante.Location = New System.Drawing.Point(321, 10)
        Me.txtNumeroComprobante.Name = "txtNumeroComprobante"
        Me.txtNumeroComprobante.Size = New System.Drawing.Size(99, 20)
        Me.txtNumeroComprobante.TabIndex = 79
        Me.txtNumeroComprobante.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtIdTipoComprobante
        '
        Me.txtIdTipoComprobante.Location = New System.Drawing.Point(94, 10)
        Me.txtIdTipoComprobante.Name = "txtIdTipoComprobante"
        Me.txtIdTipoComprobante.Size = New System.Drawing.Size(163, 20)
        Me.txtIdTipoComprobante.TabIndex = 78
        '
        'gpbResponsableDistribucion
        '
        Me.gpbResponsableDistribucion.Controls.Add(Me.lblResponsableDistribucionNuevo)
        Me.gpbResponsableDistribucion.Controls.Add(Me.bscCodigoRDNuevo)
        Me.gpbResponsableDistribucion.Controls.Add(Me.bscNombreRDNuevo)
        Me.gpbResponsableDistribucion.Enabled = False
        Me.gpbResponsableDistribucion.Location = New System.Drawing.Point(12, 149)
        Me.gpbResponsableDistribucion.Name = "gpbResponsableDistribucion"
        Me.gpbResponsableDistribucion.Size = New System.Drawing.Size(408, 62)
        Me.gpbResponsableDistribucion.TabIndex = 85
        Me.gpbResponsableDistribucion.TabStop = False
        Me.gpbResponsableDistribucion.Text = "                                  "
        '
        'lblResponsableDistribucionNuevo
        '
        Me.lblResponsableDistribucionNuevo.AutoSize = True
        Me.lblResponsableDistribucionNuevo.LabelAsoc = Nothing
        Me.lblResponsableDistribucionNuevo.Location = New System.Drawing.Point(20, 31)
        Me.lblResponsableDistribucionNuevo.Name = "lblResponsableDistribucionNuevo"
        Me.lblResponsableDistribucionNuevo.Size = New System.Drawing.Size(39, 13)
        Me.lblResponsableDistribucionNuevo.TabIndex = 89
        Me.lblResponsableDistribucionNuevo.Text = "Nuevo"
      '
      'bscCodigoRDNuevo
      '
      '    Me.bscCodigoRDNuevo.AyudaAncho = 608
      Me.bscCodigoRDNuevo.BindearPropiedadControl = Nothing
        Me.bscCodigoRDNuevo.BindearPropiedadEntidad = Nothing
      'Me.bscCodigoRDNuevo.ColumnasAlineacion = Nothing
      'Me.bscCodigoRDNuevo.ColumnasAncho = Nothing
      'Me.bscCodigoRDNuevo.ColumnasFormato = Nothing
      'Me.bscCodigoRDNuevo.ColumnasOcultas = Nothing
      'Me.bscCodigoRDNuevo.ColumnasTitulos = Nothing
      Me.bscCodigoRDNuevo.Datos = Nothing
        Me.bscCodigoRDNuevo.FilaDevuelta = Nothing
        Me.bscCodigoRDNuevo.ForeColorFocus = System.Drawing.Color.Red
        Me.bscCodigoRDNuevo.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.bscCodigoRDNuevo.IsDecimal = False
        Me.bscCodigoRDNuevo.IsNumber = True
        Me.bscCodigoRDNuevo.IsPK = False
        Me.bscCodigoRDNuevo.IsRequired = False
        Me.bscCodigoRDNuevo.Key = ""
        Me.bscCodigoRDNuevo.LabelAsoc = Me.lblResponsableDistribucionNuevo
        Me.bscCodigoRDNuevo.Location = New System.Drawing.Point(82, 28)
        Me.bscCodigoRDNuevo.MaxLengh = "32767"
        Me.bscCodigoRDNuevo.Name = "bscCodigoRDNuevo"
        Me.bscCodigoRDNuevo.Permitido = True
        Me.bscCodigoRDNuevo.Selecciono = False
        Me.bscCodigoRDNuevo.Size = New System.Drawing.Size(90, 20)
        Me.bscCodigoRDNuevo.TabIndex = 87
      '  Me.bscCodigoRDNuevo.Titulo = Nothing
      '
      'bscNombreRDNuevo
      '
      '  Me.bscNombreRDNuevo.AyudaAncho = 608
      Me.bscNombreRDNuevo.BindearPropiedadControl = Nothing
        Me.bscNombreRDNuevo.BindearPropiedadEntidad = Nothing
      'Me.bscNombreRDNuevo.ColumnasAlineacion = Nothing
      'Me.bscNombreRDNuevo.ColumnasAncho = Nothing
      'Me.bscNombreRDNuevo.ColumnasFormato = Nothing
      'Me.bscNombreRDNuevo.ColumnasOcultas = Nothing
      'Me.bscNombreRDNuevo.ColumnasTitulos = Nothing
      Me.bscNombreRDNuevo.Datos = Nothing
        Me.bscNombreRDNuevo.FilaDevuelta = Nothing
        Me.bscNombreRDNuevo.ForeColorFocus = System.Drawing.Color.Red
        Me.bscNombreRDNuevo.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.bscNombreRDNuevo.IsDecimal = False
        Me.bscNombreRDNuevo.IsNumber = False
        Me.bscNombreRDNuevo.IsPK = False
        Me.bscNombreRDNuevo.IsRequired = False
        Me.bscNombreRDNuevo.Key = ""
        Me.bscNombreRDNuevo.LabelAsoc = Me.lblResponsableDistribucionNuevo
        Me.bscNombreRDNuevo.Location = New System.Drawing.Point(178, 28)
        Me.bscNombreRDNuevo.MaxLengh = "100"
        Me.bscNombreRDNuevo.Name = "bscNombreRDNuevo"
        Me.bscNombreRDNuevo.Permitido = True
        Me.bscNombreRDNuevo.Selecciono = False
        Me.bscNombreRDNuevo.Size = New System.Drawing.Size(211, 20)
        Me.bscNombreRDNuevo.TabIndex = 86
      '  Me.bscNombreRDNuevo.Titulo = Nothing
      '
      'lblCambioMasivoRD
      '
      Me.lblCambioMasivoRD.AutoSize = True
        Me.lblCambioMasivoRD.LabelAsoc = Nothing
        Me.lblCambioMasivoRD.Location = New System.Drawing.Point(9, 224)
        Me.lblCambioMasivoRD.Name = "lblCambioMasivoRD"
        Me.lblCambioMasivoRD.Size = New System.Drawing.Size(45, 13)
        Me.lblCambioMasivoRD.TabIndex = 83
        Me.lblCambioMasivoRD.Text = "Cambiar"
        '
        'chbTipoComprobante
        '
        Me.chbTipoComprobante.AutoSize = True
        Me.chbTipoComprobante.BindearPropiedadControl = Nothing
        Me.chbTipoComprobante.BindearPropiedadEntidad = Nothing
        Me.chbTipoComprobante.ForeColorFocus = System.Drawing.Color.Red
        Me.chbTipoComprobante.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbTipoComprobante.IsPK = False
        Me.chbTipoComprobante.IsRequired = False
        Me.chbTipoComprobante.Key = Nothing
        Me.chbTipoComprobante.LabelAsoc = Nothing
        Me.chbTipoComprobante.Location = New System.Drawing.Point(30, 74)
        Me.chbTipoComprobante.Name = "chbTipoComprobante"
        Me.chbTipoComprobante.Size = New System.Drawing.Size(128, 17)
        Me.chbTipoComprobante.TabIndex = 87
        Me.chbTipoComprobante.Text = "Tipo de Comprobante"
        Me.chbTipoComprobante.UseVisualStyleBackColor = True
        '
        'chbResponsableDistribucion
        '
        Me.chbResponsableDistribucion.AutoSize = True
        Me.chbResponsableDistribucion.BindearPropiedadControl = Nothing
        Me.chbResponsableDistribucion.BindearPropiedadEntidad = Nothing
        Me.chbResponsableDistribucion.ForeColorFocus = System.Drawing.Color.Red
        Me.chbResponsableDistribucion.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbResponsableDistribucion.IsPK = False
        Me.chbResponsableDistribucion.IsRequired = False
        Me.chbResponsableDistribucion.Key = Nothing
        Me.chbResponsableDistribucion.LabelAsoc = Nothing
        Me.chbResponsableDistribucion.Location = New System.Drawing.Point(30, 147)
        Me.chbResponsableDistribucion.Name = "chbResponsableDistribucion"
        Me.chbResponsableDistribucion.Size = New System.Drawing.Size(161, 17)
        Me.chbResponsableDistribucion.TabIndex = 88
        Me.chbResponsableDistribucion.Text = "Responsable de Distribución"
        Me.chbResponsableDistribucion.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(15, 13)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(73, 13)
        Me.Label1.TabIndex = 77
        Me.Label1.Text = "Pedido Activo"
        '
        'txtPedidosSeleccionados
        '
        Me.txtPedidosSeleccionados.Location = New System.Drawing.Point(139, 38)
        Me.txtPedidosSeleccionados.Name = "txtPedidosSeleccionados"
        Me.txtPedidosSeleccionados.Size = New System.Drawing.Size(89, 20)
        Me.txtPedidosSeleccionados.TabIndex = 90
        Me.txtPedidosSeleccionados.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblPedidosSeleccionados
        '
        Me.lblPedidosSeleccionados.AutoSize = True
        Me.lblPedidosSeleccionados.Location = New System.Drawing.Point(15, 42)
        Me.lblPedidosSeleccionados.Name = "lblPedidosSeleccionados"
        Me.lblPedidosSeleccionados.Size = New System.Drawing.Size(118, 13)
        Me.lblPedidosSeleccionados.TabIndex = 89
        Me.lblPedidosSeleccionados.Text = "Pedidos Seleccionados"
        '
        'txtTotalPedidos
        '
        Me.txtTotalPedidos.Location = New System.Drawing.Point(331, 41)
        Me.txtTotalPedidos.Name = "txtTotalPedidos"
        Me.txtTotalPedidos.Size = New System.Drawing.Size(89, 20)
        Me.txtTotalPedidos.TabIndex = 92
        Me.txtTotalPedidos.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblTotalPedidos
        '
        Me.lblTotalPedidos.AutoSize = True
        Me.lblTotalPedidos.Location = New System.Drawing.Point(238, 44)
        Me.lblTotalPedidos.Name = "lblTotalPedidos"
        Me.lblTotalPedidos.Size = New System.Drawing.Size(87, 13)
        Me.lblTotalPedidos.TabIndex = 91
        Me.lblTotalPedidos.Text = "Total de Pedidos"
        '
        'cmbCambioMasivo
        '
        Me.cmbCambioMasivo.BindearPropiedadControl = "SelectedValue"
        Me.cmbCambioMasivo.BindearPropiedadEntidad = "TipoCliente.IdTipoCliente"
        Me.cmbCambioMasivo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbCambioMasivo.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbCambioMasivo.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbCambioMasivo.FormattingEnabled = True
        Me.cmbCambioMasivo.IsPK = False
        Me.cmbCambioMasivo.IsRequired = True
        Me.cmbCambioMasivo.Key = Nothing
        Me.cmbCambioMasivo.LabelAsoc = Me.lblCambioMasivoRD
        Me.cmbCambioMasivo.Location = New System.Drawing.Point(60, 221)
        Me.cmbCambioMasivo.Name = "cmbCambioMasivo"
        Me.cmbCambioMasivo.Size = New System.Drawing.Size(360, 21)
        Me.cmbCambioMasivo.TabIndex = 82
        '
        'CambiarTransportistaComprobante
        '
        Me.AcceptButton = Nothing
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(432, 295)
        Me.Controls.Add(Me.txtTotalPedidos)
        Me.Controls.Add(Me.lblTotalPedidos)
        Me.Controls.Add(Me.txtPedidosSeleccionados)
        Me.Controls.Add(Me.lblPedidosSeleccionados)
        Me.Controls.Add(Me.chbResponsableDistribucion)
        Me.Controls.Add(Me.chbTipoComprobante)
        Me.Controls.Add(Me.gpbResponsableDistribucion)
        Me.Controls.Add(Me.txtLetra)
        Me.Controls.Add(Me.txtNumeroComprobante)
        Me.Controls.Add(Me.txtIdTipoComprobante)
        Me.Controls.Add(Me.lblCambioMasivoRD)
        Me.Controls.Add(Me.cmbCambioMasivo)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.gpbTipoComprobante)
        Me.Name = "CambiarTransportistaComprobante"
        Me.Text = "Modificación Transportista Comprobante"
        Me.Controls.SetChildIndex(Me.gpbTipoComprobante, 0)
        Me.Controls.SetChildIndex(Me.Label1, 0)
        Me.Controls.SetChildIndex(Me.cmbCambioMasivo, 0)
        Me.Controls.SetChildIndex(Me.lblCambioMasivoRD, 0)
        Me.Controls.SetChildIndex(Me.txtIdTipoComprobante, 0)
        Me.Controls.SetChildIndex(Me.txtNumeroComprobante, 0)
        Me.Controls.SetChildIndex(Me.txtLetra, 0)
        Me.Controls.SetChildIndex(Me.gpbResponsableDistribucion, 0)
        Me.Controls.SetChildIndex(Me.chbTipoComprobante, 0)
        Me.Controls.SetChildIndex(Me.chbResponsableDistribucion, 0)
        Me.Controls.SetChildIndex(Me.lblPedidosSeleccionados, 0)
        Me.Controls.SetChildIndex(Me.txtPedidosSeleccionados, 0)
        Me.Controls.SetChildIndex(Me.lblTotalPedidos, 0)
        Me.Controls.SetChildIndex(Me.txtTotalPedidos, 0)
        Me.Controls.SetChildIndex(Me.btnCancelar, 0)
        Me.Controls.SetChildIndex(Me.btnAceptar, 0)
        Me.Controls.SetChildIndex(Me.btnCopiar, 0)
        Me.Controls.SetChildIndex(Me.btnAplicar, 0)
        Me.gpbTipoComprobante.ResumeLayout(False)
        Me.gpbTipoComprobante.PerformLayout()
        Me.gpbResponsableDistribucion.ResumeLayout(False)
        Me.gpbResponsableDistribucion.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents gpbTipoComprobante As GroupBox
	Friend WithEvents cmbTipoComprobanteNuevo As Controles.ComboBox
	Friend WithEvents txtLetra As TextBox
	Friend WithEvents txtNumeroComprobante As TextBox
	Friend WithEvents txtIdTipoComprobante As TextBox
	Friend WithEvents gpbResponsableDistribucion As GroupBox
	Friend WithEvents lblCambioMasivoRD As Controles.Label
	Friend WithEvents cmbCambioMasivo As Controles.ComboBox
	Friend WithEvents chbTipoComprobante As Controles.CheckBox
	Friend WithEvents chbResponsableDistribucion As Controles.CheckBox
   Friend WithEvents bscCodigoRDNuevo As Controles.Buscador2
   Friend WithEvents bscNombreRDNuevo As Controles.Buscador2
   Friend WithEvents lblTipoComprobanteNuevo As Controles.Label
	Friend WithEvents lblResponsableDistribucionNuevo As Controles.Label
	Friend WithEvents Label1 As Label
	Friend WithEvents txtPedidosSeleccionados As TextBox
	Friend WithEvents lblPedidosSeleccionados As Label
	Friend WithEvents txtTotalPedidos As TextBox
	Friend WithEvents lblTotalPedidos As Label
End Class
