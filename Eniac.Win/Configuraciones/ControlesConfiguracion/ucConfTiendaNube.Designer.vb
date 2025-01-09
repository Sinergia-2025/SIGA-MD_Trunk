<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ucConfTiendaNube
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
        Me.txtTiendaNubeToken = New Eniac.Controles.TextBox()
        Me.lblTiendaNubeToken = New Eniac.Controles.Label()
        Me.lblTiendaNubeURLBase = New Eniac.Controles.Label()
        Me.txtTiendaNubeCorreoNotificaciones = New Eniac.Controles.TextBox()
        Me.lblTiendaNubeCorreoNotificaciones = New Eniac.Controles.Label()
        Me.gbPedidosTiendaNube = New System.Windows.Forms.GroupBox()
        Me.lblTiendaNubeIdProductoEnvio = New Eniac.Controles.Label()
        Me.txtTiendaNubeIdProductoEnvio = New Eniac.Controles.TextBox()
        Me.lblTiendaNubePedidosFormaDePago = New Eniac.Controles.Label()
        Me.cmbTiendaNubePedidosFormaDePago = New Eniac.Controles.ComboBox()
        Me.lblTiendaNubePedidosCriticidad = New Eniac.Controles.Label()
        Me.cmbTiendaNubePedidosCriticidad = New Eniac.Controles.ComboBox()
        Me.cmbTiendaNubePedidosTipoComprobante = New Eniac.Controles.ComboBox()
        Me.lblTiendaNubePedidosTipoComprobante = New Eniac.Controles.Label()
        Me.cmbTiendaNubeVendedor = New Eniac.Controles.ComboBox()
        Me.cmbTiendaNubeCategoriaFiscalCliente = New Eniac.Controles.ComboBox()
        Me.cmbTiendaNubeCategoriaCliente = New Eniac.Controles.ComboBox()
        Me.cmbTiendaNubeListaPrecios = New Eniac.Controles.ComboBox()
        Me.lblTiendaNubeVendedor = New Eniac.Controles.Label()
        Me.lblTiendaNubeCategoriaFiscalCliente = New Eniac.Controles.Label()
        Me.lblTiendaNubeCategoriaCliente = New Eniac.Controles.Label()
        Me.txtTiendaNubeURLBase = New Eniac.Controles.TextBox()
        Me.lblTiendaNubeListaPrecios = New Eniac.Controles.Label()
        Me.gbActualizacionesTiendaNube = New System.Windows.Forms.GroupBox()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.tpgProducto = New System.Windows.Forms.TabPage()
        Me.chbProductoActivoTienda = New Eniac.Controles.CheckBox()
        Me.lblPrecioProducto = New Eniac.Controles.Label()
        Me.cmbPrecioProducto = New Eniac.Controles.ComboBox()
        Me.lblActualizaProductoDescripcion = New Eniac.Controles.Label()
        Me.cmbActualizaProductoDescripcion = New Eniac.Controles.ComboBox()
        Me.lblTiendaNubeSleepEntreSolicitudes = New Eniac.Controles.Label()
        Me.txtTiendaNubeSleepEntreSolicitudes = New Eniac.Controles.TextBox()
        Me.chbProductoPrecioEmbalaje = New Eniac.Controles.CheckBox()
        Me.gbPedidosTiendaNube.SuspendLayout()
        Me.gbActualizacionesTiendaNube.SuspendLayout()
        Me.TabControl1.SuspendLayout()
        Me.tpgProducto.SuspendLayout()
        Me.SuspendLayout()
        '
        'txtTiendaNubeToken
        '
        Me.txtTiendaNubeToken.BindearPropiedadControl = Nothing
        Me.txtTiendaNubeToken.BindearPropiedadEntidad = Nothing
        Me.txtTiendaNubeToken.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTiendaNubeToken.ForeColorFocus = System.Drawing.Color.Red
        Me.txtTiendaNubeToken.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtTiendaNubeToken.Formato = ""
        Me.txtTiendaNubeToken.IsDecimal = False
        Me.txtTiendaNubeToken.IsNumber = False
        Me.txtTiendaNubeToken.IsPK = False
        Me.txtTiendaNubeToken.IsRequired = False
        Me.txtTiendaNubeToken.Key = ""
        Me.txtTiendaNubeToken.LabelAsoc = Me.lblTiendaNubeToken
        Me.txtTiendaNubeToken.Location = New System.Drawing.Point(466, 11)
        Me.txtTiendaNubeToken.MaxLength = 200
        Me.txtTiendaNubeToken.Name = "txtTiendaNubeToken"
        Me.txtTiendaNubeToken.ReadOnly = True
        Me.txtTiendaNubeToken.Size = New System.Drawing.Size(432, 20)
        Me.txtTiendaNubeToken.TabIndex = 3
        '
        'lblTiendaNubeToken
        '
        Me.lblTiendaNubeToken.AutoSize = True
        Me.lblTiendaNubeToken.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTiendaNubeToken.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblTiendaNubeToken.LabelAsoc = Nothing
        Me.lblTiendaNubeToken.Location = New System.Drawing.Point(410, 14)
        Me.lblTiendaNubeToken.Name = "lblTiendaNubeToken"
        Me.lblTiendaNubeToken.Size = New System.Drawing.Size(38, 13)
        Me.lblTiendaNubeToken.TabIndex = 2
        Me.lblTiendaNubeToken.Text = "Token"
        '
        'lblTiendaNubeURLBase
        '
        Me.lblTiendaNubeURLBase.AutoSize = True
        Me.lblTiendaNubeURLBase.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTiendaNubeURLBase.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblTiendaNubeURLBase.LabelAsoc = Nothing
        Me.lblTiendaNubeURLBase.Location = New System.Drawing.Point(3, 14)
        Me.lblTiendaNubeURLBase.Name = "lblTiendaNubeURLBase"
        Me.lblTiendaNubeURLBase.Size = New System.Drawing.Size(56, 13)
        Me.lblTiendaNubeURLBase.TabIndex = 0
        Me.lblTiendaNubeURLBase.Text = "URL Base"
        '
        'txtTiendaNubeCorreoNotificaciones
        '
        Me.txtTiendaNubeCorreoNotificaciones.BindearPropiedadControl = Nothing
        Me.txtTiendaNubeCorreoNotificaciones.BindearPropiedadEntidad = Nothing
        Me.txtTiendaNubeCorreoNotificaciones.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTiendaNubeCorreoNotificaciones.ForeColorFocus = System.Drawing.Color.Red
        Me.txtTiendaNubeCorreoNotificaciones.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtTiendaNubeCorreoNotificaciones.Formato = ""
        Me.txtTiendaNubeCorreoNotificaciones.IsDecimal = False
        Me.txtTiendaNubeCorreoNotificaciones.IsNumber = False
        Me.txtTiendaNubeCorreoNotificaciones.IsPK = False
        Me.txtTiendaNubeCorreoNotificaciones.IsRequired = False
        Me.txtTiendaNubeCorreoNotificaciones.Key = ""
        Me.txtTiendaNubeCorreoNotificaciones.LabelAsoc = Me.lblTiendaNubeCorreoNotificaciones
        Me.txtTiendaNubeCorreoNotificaciones.Location = New System.Drawing.Point(131, 38)
        Me.txtTiendaNubeCorreoNotificaciones.MaxLength = 200
        Me.txtTiendaNubeCorreoNotificaciones.Name = "txtTiendaNubeCorreoNotificaciones"
        Me.txtTiendaNubeCorreoNotificaciones.Size = New System.Drawing.Size(273, 20)
        Me.txtTiendaNubeCorreoNotificaciones.TabIndex = 5
        '
        'lblTiendaNubeCorreoNotificaciones
        '
        Me.lblTiendaNubeCorreoNotificaciones.AutoSize = True
        Me.lblTiendaNubeCorreoNotificaciones.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTiendaNubeCorreoNotificaciones.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblTiendaNubeCorreoNotificaciones.LabelAsoc = Nothing
        Me.lblTiendaNubeCorreoNotificaciones.Location = New System.Drawing.Point(3, 41)
        Me.lblTiendaNubeCorreoNotificaciones.Name = "lblTiendaNubeCorreoNotificaciones"
        Me.lblTiendaNubeCorreoNotificaciones.Size = New System.Drawing.Size(108, 13)
        Me.lblTiendaNubeCorreoNotificaciones.TabIndex = 4
        Me.lblTiendaNubeCorreoNotificaciones.Text = "Correo Notificaciones"
        '
        'gbPedidosTiendaNube
        '
        Me.gbPedidosTiendaNube.Controls.Add(Me.lblTiendaNubeIdProductoEnvio)
        Me.gbPedidosTiendaNube.Controls.Add(Me.txtTiendaNubeIdProductoEnvio)
        Me.gbPedidosTiendaNube.Controls.Add(Me.lblTiendaNubePedidosFormaDePago)
        Me.gbPedidosTiendaNube.Controls.Add(Me.cmbTiendaNubePedidosFormaDePago)
        Me.gbPedidosTiendaNube.Controls.Add(Me.lblTiendaNubePedidosCriticidad)
        Me.gbPedidosTiendaNube.Controls.Add(Me.cmbTiendaNubePedidosCriticidad)
        Me.gbPedidosTiendaNube.Controls.Add(Me.cmbTiendaNubePedidosTipoComprobante)
        Me.gbPedidosTiendaNube.Controls.Add(Me.lblTiendaNubePedidosTipoComprobante)
        Me.gbPedidosTiendaNube.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbPedidosTiendaNube.Location = New System.Drawing.Point(292, 66)
        Me.gbPedidosTiendaNube.Name = "gbPedidosTiendaNube"
        Me.gbPedidosTiendaNube.Size = New System.Drawing.Size(606, 80)
        Me.gbPedidosTiendaNube.TabIndex = 14
        Me.gbPedidosTiendaNube.TabStop = False
        Me.gbPedidosTiendaNube.Text = "Pedidos"
        '
        'lblTiendaNubeIdProductoEnvio
        '
        Me.lblTiendaNubeIdProductoEnvio.AutoSize = True
        Me.lblTiendaNubeIdProductoEnvio.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblTiendaNubeIdProductoEnvio.LabelAsoc = Nothing
        Me.lblTiendaNubeIdProductoEnvio.Location = New System.Drawing.Point(302, 53)
        Me.lblTiendaNubeIdProductoEnvio.Name = "lblTiendaNubeIdProductoEnvio"
        Me.lblTiendaNubeIdProductoEnvio.Size = New System.Drawing.Size(89, 13)
        Me.lblTiendaNubeIdProductoEnvio.TabIndex = 6
        Me.lblTiendaNubeIdProductoEnvio.Text = "Cód. Prod. Envío"
        '
        'txtTiendaNubeIdProductoEnvio
        '
        Me.txtTiendaNubeIdProductoEnvio.BindearPropiedadControl = Nothing
        Me.txtTiendaNubeIdProductoEnvio.BindearPropiedadEntidad = Nothing
        Me.txtTiendaNubeIdProductoEnvio.ForeColorFocus = System.Drawing.Color.Red
        Me.txtTiendaNubeIdProductoEnvio.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtTiendaNubeIdProductoEnvio.Formato = ""
        Me.txtTiendaNubeIdProductoEnvio.IsDecimal = False
        Me.txtTiendaNubeIdProductoEnvio.IsNumber = False
        Me.txtTiendaNubeIdProductoEnvio.IsPK = False
        Me.txtTiendaNubeIdProductoEnvio.IsRequired = False
        Me.txtTiendaNubeIdProductoEnvio.Key = ""
        Me.txtTiendaNubeIdProductoEnvio.LabelAsoc = Me.lblTiendaNubeToken
        Me.txtTiendaNubeIdProductoEnvio.Location = New System.Drawing.Point(397, 50)
        Me.txtTiendaNubeIdProductoEnvio.MaxLength = 15
        Me.txtTiendaNubeIdProductoEnvio.Name = "txtTiendaNubeIdProductoEnvio"
        Me.txtTiendaNubeIdProductoEnvio.Size = New System.Drawing.Size(65, 20)
        Me.txtTiendaNubeIdProductoEnvio.TabIndex = 7
        Me.txtTiendaNubeIdProductoEnvio.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblTiendaNubePedidosFormaDePago
        '
        Me.lblTiendaNubePedidosFormaDePago.AutoSize = True
        Me.lblTiendaNubePedidosFormaDePago.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblTiendaNubePedidosFormaDePago.LabelAsoc = Nothing
        Me.lblTiendaNubePedidosFormaDePago.Location = New System.Drawing.Point(302, 24)
        Me.lblTiendaNubePedidosFormaDePago.Name = "lblTiendaNubePedidosFormaDePago"
        Me.lblTiendaNubePedidosFormaDePago.Size = New System.Drawing.Size(79, 13)
        Me.lblTiendaNubePedidosFormaDePago.TabIndex = 2
        Me.lblTiendaNubePedidosFormaDePago.Text = "Forma de Pago"
        '
        'cmbTiendaNubePedidosFormaDePago
        '
        Me.cmbTiendaNubePedidosFormaDePago.BindearPropiedadControl = Nothing
        Me.cmbTiendaNubePedidosFormaDePago.BindearPropiedadEntidad = Nothing
        Me.cmbTiendaNubePedidosFormaDePago.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbTiendaNubePedidosFormaDePago.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbTiendaNubePedidosFormaDePago.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbTiendaNubePedidosFormaDePago.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbTiendaNubePedidosFormaDePago.FormattingEnabled = True
        Me.cmbTiendaNubePedidosFormaDePago.IsPK = False
        Me.cmbTiendaNubePedidosFormaDePago.IsRequired = False
        Me.cmbTiendaNubePedidosFormaDePago.Key = Nothing
        Me.cmbTiendaNubePedidosFormaDePago.LabelAsoc = Nothing
        Me.cmbTiendaNubePedidosFormaDePago.Location = New System.Drawing.Point(397, 21)
        Me.cmbTiendaNubePedidosFormaDePago.Name = "cmbTiendaNubePedidosFormaDePago"
        Me.cmbTiendaNubePedidosFormaDePago.Size = New System.Drawing.Size(197, 21)
        Me.cmbTiendaNubePedidosFormaDePago.TabIndex = 3
        Me.cmbTiendaNubePedidosFormaDePago.Tag = "TURISMOCATEGORIARESPONSABLE"
        '
        'lblTiendaNubePedidosCriticidad
        '
        Me.lblTiendaNubePedidosCriticidad.AutoSize = True
        Me.lblTiendaNubePedidosCriticidad.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblTiendaNubePedidosCriticidad.LabelAsoc = Nothing
        Me.lblTiendaNubePedidosCriticidad.Location = New System.Drawing.Point(65, 53)
        Me.lblTiendaNubePedidosCriticidad.Name = "lblTiendaNubePedidosCriticidad"
        Me.lblTiendaNubePedidosCriticidad.Size = New System.Drawing.Size(50, 13)
        Me.lblTiendaNubePedidosCriticidad.TabIndex = 4
        Me.lblTiendaNubePedidosCriticidad.Text = "Criticidad"
        '
        'cmbTiendaNubePedidosCriticidad
        '
        Me.cmbTiendaNubePedidosCriticidad.BindearPropiedadControl = Nothing
        Me.cmbTiendaNubePedidosCriticidad.BindearPropiedadEntidad = Nothing
        Me.cmbTiendaNubePedidosCriticidad.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbTiendaNubePedidosCriticidad.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbTiendaNubePedidosCriticidad.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbTiendaNubePedidosCriticidad.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbTiendaNubePedidosCriticidad.FormattingEnabled = True
        Me.cmbTiendaNubePedidosCriticidad.IsPK = False
        Me.cmbTiendaNubePedidosCriticidad.IsRequired = False
        Me.cmbTiendaNubePedidosCriticidad.Key = Nothing
        Me.cmbTiendaNubePedidosCriticidad.LabelAsoc = Nothing
        Me.cmbTiendaNubePedidosCriticidad.Location = New System.Drawing.Point(121, 50)
        Me.cmbTiendaNubePedidosCriticidad.Name = "cmbTiendaNubePedidosCriticidad"
        Me.cmbTiendaNubePedidosCriticidad.Size = New System.Drawing.Size(172, 21)
        Me.cmbTiendaNubePedidosCriticidad.TabIndex = 5
        Me.cmbTiendaNubePedidosCriticidad.Tag = "TURISMOCATEGORIARESPONSABLE"
        '
        'cmbTiendaNubePedidosTipoComprobante
        '
        Me.cmbTiendaNubePedidosTipoComprobante.BindearPropiedadControl = Nothing
        Me.cmbTiendaNubePedidosTipoComprobante.BindearPropiedadEntidad = Nothing
        Me.cmbTiendaNubePedidosTipoComprobante.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbTiendaNubePedidosTipoComprobante.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbTiendaNubePedidosTipoComprobante.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbTiendaNubePedidosTipoComprobante.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbTiendaNubePedidosTipoComprobante.FormattingEnabled = True
        Me.cmbTiendaNubePedidosTipoComprobante.IsPK = False
        Me.cmbTiendaNubePedidosTipoComprobante.IsRequired = False
        Me.cmbTiendaNubePedidosTipoComprobante.Key = Nothing
        Me.cmbTiendaNubePedidosTipoComprobante.LabelAsoc = Nothing
        Me.cmbTiendaNubePedidosTipoComprobante.Location = New System.Drawing.Point(121, 21)
        Me.cmbTiendaNubePedidosTipoComprobante.Name = "cmbTiendaNubePedidosTipoComprobante"
        Me.cmbTiendaNubePedidosTipoComprobante.Size = New System.Drawing.Size(172, 21)
        Me.cmbTiendaNubePedidosTipoComprobante.TabIndex = 1
        Me.cmbTiendaNubePedidosTipoComprobante.Tag = ""
        '
        'lblTiendaNubePedidosTipoComprobante
        '
        Me.lblTiendaNubePedidosTipoComprobante.AutoSize = True
        Me.lblTiendaNubePedidosTipoComprobante.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblTiendaNubePedidosTipoComprobante.LabelAsoc = Nothing
        Me.lblTiendaNubePedidosTipoComprobante.Location = New System.Drawing.Point(6, 24)
        Me.lblTiendaNubePedidosTipoComprobante.Name = "lblTiendaNubePedidosTipoComprobante"
        Me.lblTiendaNubePedidosTipoComprobante.Size = New System.Drawing.Size(109, 13)
        Me.lblTiendaNubePedidosTipoComprobante.TabIndex = 0
        Me.lblTiendaNubePedidosTipoComprobante.Text = "Tipo de Comprobante"
        '
        'cmbTiendaNubeVendedor
        '
        Me.cmbTiendaNubeVendedor.BindearPropiedadControl = Nothing
        Me.cmbTiendaNubeVendedor.BindearPropiedadEntidad = Nothing
        Me.cmbTiendaNubeVendedor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbTiendaNubeVendedor.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbTiendaNubeVendedor.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbTiendaNubeVendedor.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbTiendaNubeVendedor.FormattingEnabled = True
        Me.cmbTiendaNubeVendedor.IsPK = False
        Me.cmbTiendaNubeVendedor.IsRequired = False
        Me.cmbTiendaNubeVendedor.Key = Nothing
        Me.cmbTiendaNubeVendedor.LabelAsoc = Nothing
        Me.cmbTiendaNubeVendedor.Location = New System.Drawing.Point(131, 126)
        Me.cmbTiendaNubeVendedor.Name = "cmbTiendaNubeVendedor"
        Me.cmbTiendaNubeVendedor.Size = New System.Drawing.Size(146, 21)
        Me.cmbTiendaNubeVendedor.TabIndex = 13
        Me.cmbTiendaNubeVendedor.Tag = ""
        '
        'cmbTiendaNubeCategoriaFiscalCliente
        '
        Me.cmbTiendaNubeCategoriaFiscalCliente.BindearPropiedadControl = Nothing
        Me.cmbTiendaNubeCategoriaFiscalCliente.BindearPropiedadEntidad = Nothing
        Me.cmbTiendaNubeCategoriaFiscalCliente.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbTiendaNubeCategoriaFiscalCliente.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbTiendaNubeCategoriaFiscalCliente.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbTiendaNubeCategoriaFiscalCliente.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbTiendaNubeCategoriaFiscalCliente.FormattingEnabled = True
        Me.cmbTiendaNubeCategoriaFiscalCliente.IsPK = False
        Me.cmbTiendaNubeCategoriaFiscalCliente.IsRequired = False
        Me.cmbTiendaNubeCategoriaFiscalCliente.Key = Nothing
        Me.cmbTiendaNubeCategoriaFiscalCliente.LabelAsoc = Nothing
        Me.cmbTiendaNubeCategoriaFiscalCliente.Location = New System.Drawing.Point(131, 100)
        Me.cmbTiendaNubeCategoriaFiscalCliente.Name = "cmbTiendaNubeCategoriaFiscalCliente"
        Me.cmbTiendaNubeCategoriaFiscalCliente.Size = New System.Drawing.Size(146, 21)
        Me.cmbTiendaNubeCategoriaFiscalCliente.TabIndex = 11
        Me.cmbTiendaNubeCategoriaFiscalCliente.Tag = ""
        '
        'cmbTiendaNubeCategoriaCliente
        '
        Me.cmbTiendaNubeCategoriaCliente.BindearPropiedadControl = Nothing
        Me.cmbTiendaNubeCategoriaCliente.BindearPropiedadEntidad = Nothing
        Me.cmbTiendaNubeCategoriaCliente.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbTiendaNubeCategoriaCliente.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbTiendaNubeCategoriaCliente.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbTiendaNubeCategoriaCliente.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbTiendaNubeCategoriaCliente.FormattingEnabled = True
        Me.cmbTiendaNubeCategoriaCliente.IsPK = False
        Me.cmbTiendaNubeCategoriaCliente.IsRequired = False
        Me.cmbTiendaNubeCategoriaCliente.Key = Nothing
        Me.cmbTiendaNubeCategoriaCliente.LabelAsoc = Nothing
        Me.cmbTiendaNubeCategoriaCliente.Location = New System.Drawing.Point(131, 74)
        Me.cmbTiendaNubeCategoriaCliente.Name = "cmbTiendaNubeCategoriaCliente"
        Me.cmbTiendaNubeCategoriaCliente.Size = New System.Drawing.Size(146, 21)
        Me.cmbTiendaNubeCategoriaCliente.TabIndex = 9
        Me.cmbTiendaNubeCategoriaCliente.Tag = ""
        '
        'cmbTiendaNubeListaPrecios
        '
        Me.cmbTiendaNubeListaPrecios.BindearPropiedadControl = Nothing
        Me.cmbTiendaNubeListaPrecios.BindearPropiedadEntidad = Nothing
        Me.cmbTiendaNubeListaPrecios.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbTiendaNubeListaPrecios.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbTiendaNubeListaPrecios.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbTiendaNubeListaPrecios.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbTiendaNubeListaPrecios.FormattingEnabled = True
        Me.cmbTiendaNubeListaPrecios.IsPK = False
        Me.cmbTiendaNubeListaPrecios.IsRequired = False
        Me.cmbTiendaNubeListaPrecios.Key = Nothing
        Me.cmbTiendaNubeListaPrecios.LabelAsoc = Nothing
        Me.cmbTiendaNubeListaPrecios.Location = New System.Drawing.Point(535, 41)
        Me.cmbTiendaNubeListaPrecios.Name = "cmbTiendaNubeListaPrecios"
        Me.cmbTiendaNubeListaPrecios.Size = New System.Drawing.Size(363, 21)
        Me.cmbTiendaNubeListaPrecios.TabIndex = 7
        Me.cmbTiendaNubeListaPrecios.Tag = ""
        '
        'lblTiendaNubeVendedor
        '
        Me.lblTiendaNubeVendedor.AutoSize = True
        Me.lblTiendaNubeVendedor.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTiendaNubeVendedor.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblTiendaNubeVendedor.LabelAsoc = Nothing
        Me.lblTiendaNubeVendedor.Location = New System.Drawing.Point(3, 129)
        Me.lblTiendaNubeVendedor.Name = "lblTiendaNubeVendedor"
        Me.lblTiendaNubeVendedor.Size = New System.Drawing.Size(53, 13)
        Me.lblTiendaNubeVendedor.TabIndex = 12
        Me.lblTiendaNubeVendedor.Text = "Vendedor"
        '
        'lblTiendaNubeCategoriaFiscalCliente
        '
        Me.lblTiendaNubeCategoriaFiscalCliente.AutoSize = True
        Me.lblTiendaNubeCategoriaFiscalCliente.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTiendaNubeCategoriaFiscalCliente.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblTiendaNubeCategoriaFiscalCliente.LabelAsoc = Nothing
        Me.lblTiendaNubeCategoriaFiscalCliente.Location = New System.Drawing.Point(3, 103)
        Me.lblTiendaNubeCategoriaFiscalCliente.Name = "lblTiendaNubeCategoriaFiscalCliente"
        Me.lblTiendaNubeCategoriaFiscalCliente.Size = New System.Drawing.Size(119, 13)
        Me.lblTiendaNubeCategoriaFiscalCliente.TabIndex = 10
        Me.lblTiendaNubeCategoriaFiscalCliente.Text = "Categoría Fiscal Cliente"
        '
        'lblTiendaNubeCategoriaCliente
        '
        Me.lblTiendaNubeCategoriaCliente.AutoSize = True
        Me.lblTiendaNubeCategoriaCliente.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTiendaNubeCategoriaCliente.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblTiendaNubeCategoriaCliente.LabelAsoc = Nothing
        Me.lblTiendaNubeCategoriaCliente.Location = New System.Drawing.Point(3, 77)
        Me.lblTiendaNubeCategoriaCliente.Name = "lblTiendaNubeCategoriaCliente"
        Me.lblTiendaNubeCategoriaCliente.Size = New System.Drawing.Size(106, 13)
        Me.lblTiendaNubeCategoriaCliente.TabIndex = 8
        Me.lblTiendaNubeCategoriaCliente.Text = "Categoría del Cliente"
        '
        'txtTiendaNubeURLBase
        '
        Me.txtTiendaNubeURLBase.BindearPropiedadControl = Nothing
        Me.txtTiendaNubeURLBase.BindearPropiedadEntidad = Nothing
        Me.txtTiendaNubeURLBase.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTiendaNubeURLBase.ForeColorFocus = System.Drawing.Color.Red
        Me.txtTiendaNubeURLBase.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtTiendaNubeURLBase.Formato = ""
        Me.txtTiendaNubeURLBase.IsDecimal = False
        Me.txtTiendaNubeURLBase.IsNumber = False
        Me.txtTiendaNubeURLBase.IsPK = False
        Me.txtTiendaNubeURLBase.IsRequired = False
        Me.txtTiendaNubeURLBase.Key = ""
        Me.txtTiendaNubeURLBase.LabelAsoc = Me.lblTiendaNubeURLBase
        Me.txtTiendaNubeURLBase.Location = New System.Drawing.Point(131, 12)
        Me.txtTiendaNubeURLBase.MaxLength = 200
        Me.txtTiendaNubeURLBase.Name = "txtTiendaNubeURLBase"
        Me.txtTiendaNubeURLBase.Size = New System.Drawing.Size(273, 20)
        Me.txtTiendaNubeURLBase.TabIndex = 1
        '
        'lblTiendaNubeListaPrecios
        '
        Me.lblTiendaNubeListaPrecios.AutoSize = True
        Me.lblTiendaNubeListaPrecios.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTiendaNubeListaPrecios.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblTiendaNubeListaPrecios.LabelAsoc = Nothing
        Me.lblTiendaNubeListaPrecios.Location = New System.Drawing.Point(410, 44)
        Me.lblTiendaNubeListaPrecios.Name = "lblTiendaNubeListaPrecios"
        Me.lblTiendaNubeListaPrecios.Size = New System.Drawing.Size(82, 13)
        Me.lblTiendaNubeListaPrecios.TabIndex = 6
        Me.lblTiendaNubeListaPrecios.Text = "Lista de Precios"
        '
        'gbActualizacionesTiendaNube
        '
        Me.gbActualizacionesTiendaNube.Controls.Add(Me.TabControl1)
        Me.gbActualizacionesTiendaNube.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbActualizacionesTiendaNube.Location = New System.Drawing.Point(6, 178)
        Me.gbActualizacionesTiendaNube.Name = "gbActualizacionesTiendaNube"
        Me.gbActualizacionesTiendaNube.Size = New System.Drawing.Size(677, 192)
        Me.gbActualizacionesTiendaNube.TabIndex = 17
        Me.gbActualizacionesTiendaNube.TabStop = False
        Me.gbActualizacionesTiendaNube.Text = "Actualizaciones"
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.tpgProducto)
        Me.TabControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControl1.Location = New System.Drawing.Point(3, 16)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(671, 173)
        Me.TabControl1.TabIndex = 0
        '
        'tpgProducto
        '
        Me.tpgProducto.BackColor = System.Drawing.SystemColors.Control
        Me.tpgProducto.Controls.Add(Me.chbProductoPrecioEmbalaje)
        Me.tpgProducto.Controls.Add(Me.chbProductoActivoTienda)
        Me.tpgProducto.Controls.Add(Me.lblPrecioProducto)
        Me.tpgProducto.Controls.Add(Me.cmbPrecioProducto)
        Me.tpgProducto.Controls.Add(Me.lblActualizaProductoDescripcion)
        Me.tpgProducto.Controls.Add(Me.cmbActualizaProductoDescripcion)
        Me.tpgProducto.Location = New System.Drawing.Point(4, 22)
        Me.tpgProducto.Name = "tpgProducto"
        Me.tpgProducto.Padding = New System.Windows.Forms.Padding(3)
        Me.tpgProducto.Size = New System.Drawing.Size(663, 147)
        Me.tpgProducto.TabIndex = 0
        Me.tpgProducto.Text = "Productos"
        '
        'chbProductoActivoTienda
        '
        Me.chbProductoActivoTienda.AutoSize = True
        Me.chbProductoActivoTienda.BindearPropiedadControl = Nothing
        Me.chbProductoActivoTienda.BindearPropiedadEntidad = Nothing
        Me.chbProductoActivoTienda.ForeColorFocus = System.Drawing.Color.Red
        Me.chbProductoActivoTienda.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbProductoActivoTienda.IsPK = False
        Me.chbProductoActivoTienda.IsRequired = False
        Me.chbProductoActivoTienda.Key = Nothing
        Me.chbProductoActivoTienda.LabelAsoc = Nothing
        Me.chbProductoActivoTienda.Location = New System.Drawing.Point(20, 72)
        Me.chbProductoActivoTienda.Name = "chbProductoActivoTienda"
        Me.chbProductoActivoTienda.Size = New System.Drawing.Size(210, 17)
        Me.chbProductoActivoTienda.TabIndex = 4
        Me.chbProductoActivoTienda.Tag = "PRODUCCIONRECETAUNICA"
        Me.chbProductoActivoTienda.Text = "Producto se publica activo en la tienda"
        Me.chbProductoActivoTienda.UseVisualStyleBackColor = True
        '
        'lblPrecioProducto
        '
        Me.lblPrecioProducto.AutoSize = True
        Me.lblPrecioProducto.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPrecioProducto.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblPrecioProducto.LabelAsoc = Nothing
        Me.lblPrecioProducto.Location = New System.Drawing.Point(17, 40)
        Me.lblPrecioProducto.Name = "lblPrecioProducto"
        Me.lblPrecioProducto.Size = New System.Drawing.Size(157, 13)
        Me.lblPrecioProducto.TabIndex = 2
        Me.lblPrecioProducto.Text = "Precio del Producto en Moneda"
        '
        'cmbPrecioProducto
        '
        Me.cmbPrecioProducto.BindearPropiedadControl = Nothing
        Me.cmbPrecioProducto.BindearPropiedadEntidad = Nothing
        Me.cmbPrecioProducto.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbPrecioProducto.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbPrecioProducto.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbPrecioProducto.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbPrecioProducto.FormattingEnabled = True
        Me.cmbPrecioProducto.IsPK = False
        Me.cmbPrecioProducto.IsRequired = False
        Me.cmbPrecioProducto.Key = Nothing
        Me.cmbPrecioProducto.LabelAsoc = Me.lblPrecioProducto
        Me.cmbPrecioProducto.Location = New System.Drawing.Point(180, 37)
        Me.cmbPrecioProducto.Name = "cmbPrecioProducto"
        Me.cmbPrecioProducto.Size = New System.Drawing.Size(101, 21)
        Me.cmbPrecioProducto.TabIndex = 3
        Me.cmbPrecioProducto.Tag = ""
        '
        'lblActualizaProductoDescripcion
        '
        Me.lblActualizaProductoDescripcion.AutoSize = True
        Me.lblActualizaProductoDescripcion.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblActualizaProductoDescripcion.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblActualizaProductoDescripcion.LabelAsoc = Nothing
        Me.lblActualizaProductoDescripcion.Location = New System.Drawing.Point(17, 12)
        Me.lblActualizaProductoDescripcion.Name = "lblActualizaProductoDescripcion"
        Me.lblActualizaProductoDescripcion.Size = New System.Drawing.Size(63, 13)
        Me.lblActualizaProductoDescripcion.TabIndex = 0
        Me.lblActualizaProductoDescripcion.Text = "Descripción"
        '
        'cmbActualizaProductoDescripcion
        '
        Me.cmbActualizaProductoDescripcion.BindearPropiedadControl = Nothing
        Me.cmbActualizaProductoDescripcion.BindearPropiedadEntidad = Nothing
        Me.cmbActualizaProductoDescripcion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbActualizaProductoDescripcion.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbActualizaProductoDescripcion.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbActualizaProductoDescripcion.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbActualizaProductoDescripcion.FormattingEnabled = True
        Me.cmbActualizaProductoDescripcion.IsPK = False
        Me.cmbActualizaProductoDescripcion.IsRequired = False
        Me.cmbActualizaProductoDescripcion.Key = Nothing
        Me.cmbActualizaProductoDescripcion.LabelAsoc = Me.lblActualizaProductoDescripcion
        Me.cmbActualizaProductoDescripcion.Location = New System.Drawing.Point(115, 9)
        Me.cmbActualizaProductoDescripcion.Name = "cmbActualizaProductoDescripcion"
        Me.cmbActualizaProductoDescripcion.Size = New System.Drawing.Size(166, 21)
        Me.cmbActualizaProductoDescripcion.TabIndex = 1
        Me.cmbActualizaProductoDescripcion.Tag = ""
        '
        'lblTiendaNubeSleepEntreSolicitudes
        '
        Me.lblTiendaNubeSleepEntreSolicitudes.AutoSize = True
        Me.lblTiendaNubeSleepEntreSolicitudes.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblTiendaNubeSleepEntreSolicitudes.LabelAsoc = Nothing
        Me.lblTiendaNubeSleepEntreSolicitudes.Location = New System.Drawing.Point(4, 155)
        Me.lblTiendaNubeSleepEntreSolicitudes.Name = "lblTiendaNubeSleepEntreSolicitudes"
        Me.lblTiendaNubeSleepEntreSolicitudes.Size = New System.Drawing.Size(258, 13)
        Me.lblTiendaNubeSleepEntreSolicitudes.TabIndex = 15
        Me.lblTiendaNubeSleepEntreSolicitudes.Text = "Tiempo de demora entre solicitudes (en milisegundos)"
        '
        'txtTiendaNubeSleepEntreSolicitudes
        '
        Me.txtTiendaNubeSleepEntreSolicitudes.BindearPropiedadControl = Nothing
        Me.txtTiendaNubeSleepEntreSolicitudes.BindearPropiedadEntidad = Nothing
        Me.txtTiendaNubeSleepEntreSolicitudes.ForeColorFocus = System.Drawing.Color.Red
        Me.txtTiendaNubeSleepEntreSolicitudes.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtTiendaNubeSleepEntreSolicitudes.Formato = ""
        Me.txtTiendaNubeSleepEntreSolicitudes.IsDecimal = False
        Me.txtTiendaNubeSleepEntreSolicitudes.IsNumber = True
        Me.txtTiendaNubeSleepEntreSolicitudes.IsPK = False
        Me.txtTiendaNubeSleepEntreSolicitudes.IsRequired = False
        Me.txtTiendaNubeSleepEntreSolicitudes.Key = ""
        Me.txtTiendaNubeSleepEntreSolicitudes.LabelAsoc = Me.lblTiendaNubeToken
        Me.txtTiendaNubeSleepEntreSolicitudes.Location = New System.Drawing.Point(292, 152)
        Me.txtTiendaNubeSleepEntreSolicitudes.MaxLength = 15
        Me.txtTiendaNubeSleepEntreSolicitudes.Name = "txtTiendaNubeSleepEntreSolicitudes"
        Me.txtTiendaNubeSleepEntreSolicitudes.Size = New System.Drawing.Size(65, 20)
        Me.txtTiendaNubeSleepEntreSolicitudes.TabIndex = 16
        Me.txtTiendaNubeSleepEntreSolicitudes.Text = "500"
        Me.txtTiendaNubeSleepEntreSolicitudes.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'chbProductoPrecioEmbalaje
        '
        Me.chbProductoPrecioEmbalaje.AutoSize = True
        Me.chbProductoPrecioEmbalaje.BindearPropiedadControl = Nothing
        Me.chbProductoPrecioEmbalaje.BindearPropiedadEntidad = Nothing
        Me.chbProductoPrecioEmbalaje.ForeColorFocus = System.Drawing.Color.Red
        Me.chbProductoPrecioEmbalaje.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbProductoPrecioEmbalaje.IsPK = False
        Me.chbProductoPrecioEmbalaje.IsRequired = False
        Me.chbProductoPrecioEmbalaje.Key = Nothing
        Me.chbProductoPrecioEmbalaje.LabelAsoc = Nothing
        Me.chbProductoPrecioEmbalaje.Location = New System.Drawing.Point(20, 95)
        Me.chbProductoPrecioEmbalaje.Name = "chbProductoPrecioEmbalaje"
        Me.chbProductoPrecioEmbalaje.Size = New System.Drawing.Size(161, 17)
        Me.chbProductoPrecioEmbalaje.TabIndex = 5
        Me.chbProductoPrecioEmbalaje.Tag = ""
        Me.chbProductoPrecioEmbalaje.Text = "Publicar Precio por Embalaje"
        Me.chbProductoPrecioEmbalaje.UseVisualStyleBackColor = True
        '
        'ucConfTiendaNube
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.lblTiendaNubeSleepEntreSolicitudes)
        Me.Controls.Add(Me.gbActualizacionesTiendaNube)
        Me.Controls.Add(Me.txtTiendaNubeSleepEntreSolicitudes)
        Me.Controls.Add(Me.txtTiendaNubeToken)
        Me.Controls.Add(Me.lblTiendaNubeURLBase)
        Me.Controls.Add(Me.txtTiendaNubeCorreoNotificaciones)
        Me.Controls.Add(Me.lblTiendaNubeCorreoNotificaciones)
        Me.Controls.Add(Me.gbPedidosTiendaNube)
        Me.Controls.Add(Me.cmbTiendaNubeVendedor)
        Me.Controls.Add(Me.cmbTiendaNubeCategoriaFiscalCliente)
        Me.Controls.Add(Me.cmbTiendaNubeCategoriaCliente)
        Me.Controls.Add(Me.cmbTiendaNubeListaPrecios)
        Me.Controls.Add(Me.lblTiendaNubeVendedor)
        Me.Controls.Add(Me.lblTiendaNubeCategoriaFiscalCliente)
        Me.Controls.Add(Me.lblTiendaNubeCategoriaCliente)
        Me.Controls.Add(Me.txtTiendaNubeURLBase)
        Me.Controls.Add(Me.lblTiendaNubeToken)
        Me.Controls.Add(Me.lblTiendaNubeListaPrecios)
        Me.Name = "ucConfTiendaNube"
        Me.Size = New System.Drawing.Size(908, 378)
        Me.Controls.SetChildIndex(Me.lblTiendaNubeListaPrecios, 0)
        Me.Controls.SetChildIndex(Me.lblTiendaNubeToken, 0)
        Me.Controls.SetChildIndex(Me.txtTiendaNubeURLBase, 0)
        Me.Controls.SetChildIndex(Me.lblTiendaNubeCategoriaCliente, 0)
        Me.Controls.SetChildIndex(Me.lblTiendaNubeCategoriaFiscalCliente, 0)
        Me.Controls.SetChildIndex(Me.lblTiendaNubeVendedor, 0)
        Me.Controls.SetChildIndex(Me.cmbTiendaNubeListaPrecios, 0)
        Me.Controls.SetChildIndex(Me.cmbTiendaNubeCategoriaCliente, 0)
        Me.Controls.SetChildIndex(Me.cmbTiendaNubeCategoriaFiscalCliente, 0)
        Me.Controls.SetChildIndex(Me.cmbTiendaNubeVendedor, 0)
        Me.Controls.SetChildIndex(Me.gbPedidosTiendaNube, 0)
        Me.Controls.SetChildIndex(Me.lblTiendaNubeCorreoNotificaciones, 0)
        Me.Controls.SetChildIndex(Me.txtTiendaNubeCorreoNotificaciones, 0)
        Me.Controls.SetChildIndex(Me.lblTiendaNubeURLBase, 0)
        Me.Controls.SetChildIndex(Me.txtTiendaNubeToken, 0)
        Me.Controls.SetChildIndex(Me.txtTiendaNubeSleepEntreSolicitudes, 0)
        Me.Controls.SetChildIndex(Me.gbActualizacionesTiendaNube, 0)
        Me.Controls.SetChildIndex(Me.lblTiendaNubeSleepEntreSolicitudes, 0)
        Me.gbPedidosTiendaNube.ResumeLayout(False)
        Me.gbPedidosTiendaNube.PerformLayout()
        Me.gbActualizacionesTiendaNube.ResumeLayout(False)
        Me.TabControl1.ResumeLayout(False)
        Me.tpgProducto.ResumeLayout(False)
        Me.tpgProducto.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents txtTiendaNubeToken As Controles.TextBox
    Friend WithEvents lblTiendaNubeToken As Controles.Label
    Friend WithEvents lblTiendaNubeURLBase As Controles.Label
    Friend WithEvents txtTiendaNubeCorreoNotificaciones As Controles.TextBox
    Friend WithEvents lblTiendaNubeCorreoNotificaciones As Controles.Label
    Friend WithEvents gbPedidosTiendaNube As GroupBox
    Friend WithEvents lblTiendaNubeIdProductoEnvio As Controles.Label
    Friend WithEvents txtTiendaNubeIdProductoEnvio As Controles.TextBox
    Friend WithEvents lblTiendaNubePedidosFormaDePago As Controles.Label
    Friend WithEvents cmbTiendaNubePedidosFormaDePago As Controles.ComboBox
    Friend WithEvents lblTiendaNubePedidosCriticidad As Controles.Label
    Friend WithEvents cmbTiendaNubePedidosCriticidad As Controles.ComboBox
    Friend WithEvents cmbTiendaNubePedidosTipoComprobante As Controles.ComboBox
    Friend WithEvents lblTiendaNubePedidosTipoComprobante As Controles.Label
    Friend WithEvents cmbTiendaNubeVendedor As Controles.ComboBox
    Friend WithEvents cmbTiendaNubeCategoriaFiscalCliente As Controles.ComboBox
    Friend WithEvents cmbTiendaNubeCategoriaCliente As Controles.ComboBox
    Friend WithEvents cmbTiendaNubeListaPrecios As Controles.ComboBox
    Friend WithEvents lblTiendaNubeVendedor As Controles.Label
    Friend WithEvents lblTiendaNubeCategoriaFiscalCliente As Controles.Label
    Friend WithEvents lblTiendaNubeCategoriaCliente As Controles.Label
    Friend WithEvents txtTiendaNubeURLBase As Controles.TextBox
    Friend WithEvents lblTiendaNubeListaPrecios As Controles.Label
    Friend WithEvents gbActualizacionesTiendaNube As GroupBox
    Friend WithEvents TabControl1 As TabControl
    Friend WithEvents tpgProducto As TabPage
    Friend WithEvents cmbActualizaProductoDescripcion As Controles.ComboBox
    Friend WithEvents lblActualizaProductoDescripcion As Controles.Label
    Friend WithEvents lblPrecioProducto As Controles.Label
    Friend WithEvents cmbPrecioProducto As Controles.ComboBox
    Friend WithEvents chbProductoActivoTienda As Controles.CheckBox
    Friend WithEvents lblTiendaNubeSleepEntreSolicitudes As Controles.Label
    Friend WithEvents txtTiendaNubeSleepEntreSolicitudes As Controles.TextBox
    Friend WithEvents chbProductoPrecioEmbalaje As Controles.CheckBox
End Class
