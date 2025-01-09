<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ucConfArborea
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
      Me.txtArboreaURLBase = New Eniac.Controles.TextBox()
      Me.lblArboreaURLBase = New Eniac.Controles.Label()
      Me.lblArboreaClaveToken = New Eniac.Controles.Label()
      Me.lblArboreaUsuarioToken = New Eniac.Controles.Label()
      Me.lblArboreaCategoriaCliente = New Eniac.Controles.Label()
      Me.lblArboreaCategoriaFiscalCliente = New Eniac.Controles.Label()
      Me.lblArboreaVendedor = New Eniac.Controles.Label()
      Me.cmbArboreaCategoriaCliente = New Eniac.Controles.ComboBox()
        Me.cmbArboreaVendedor = New Eniac.Controles.ComboBox()
        Me.lblArboreaProductoEnvio = New Eniac.Controles.Label()
        Me.txtArboreaProductoEnvio = New Eniac.Controles.TextBox()
        Me.lblArboreaPedidosFormaDePago = New Eniac.Controles.Label()
        Me.cmbArboreaPedidosFormaDePago = New Eniac.Controles.ComboBox()
        Me.lblArboreaPedidosCriticidad = New Eniac.Controles.Label()
        Me.cmbArboreaPedidosCriticidad = New Eniac.Controles.ComboBox()
        Me.cmbArboreaPedidosTipoComprobante = New Eniac.Controles.ComboBox()
        Me.lblArboreaPedidosTipoComprobante = New Eniac.Controles.Label()
        Me.gbPedidosArborea = New System.Windows.Forms.GroupBox()
        Me.lblArboreaCorreoNotificaciones = New Eniac.Controles.Label()
        Me.txtArboreaCorreoNotificaciones = New Eniac.Controles.TextBox()
        Me.txtArboreaUsuarioToken = New Eniac.Controles.TextBox()
        Me.txtArboreaClaveToken = New Eniac.Controles.TextBox()
        Me.txtArboreaCategoriaPrincipal = New Eniac.Controles.TextBox()
        Me.lblArboreaCategoriaPrincipal = New Eniac.Controles.Label()
        Me.cmbArboreaCategoriaFiscalCliente = New Eniac.Controles.ComboBox()
        Me.gbListadPreciosArborea = New System.Windows.Forms.GroupBox()
        Me.chbPreciosConIvaPV = New Eniac.Controles.CheckBox()
        Me.chbListaPrecio04 = New Eniac.Controles.CheckBox()
        Me.chbListaPrecio03 = New Eniac.Controles.CheckBox()
        Me.chbListaPrecio02 = New Eniac.Controles.CheckBox()
        Me.chbListaPrecio01 = New Eniac.Controles.CheckBox()
        Me.cmbListaPrecio04 = New Eniac.Controles.ComboBox()
        Me.cmbListaPrecio03 = New Eniac.Controles.ComboBox()
        Me.cmbListaPrecio02 = New Eniac.Controles.ComboBox()
        Me.cmbListaPrecio01 = New Eniac.Controles.ComboBox()
        Me.txtArboreaURLListaPrecios = New Eniac.Controles.TextBox()
        Me.lblArboreaURLListaPrecios = New Eniac.Controles.Label()
        Me.txtArboreaURLListaPreciosClientes = New Eniac.Controles.TextBox()
        Me.lblArboreaURLListaPreciosClientes = New Eniac.Controles.Label()
        Me.chbArboreaExportarSolicitudesSubida = New Eniac.Controles.CheckBox()
        Me.txtArboreaExportarSolicitudesSubidaPath = New Eniac.Controles.TextBox()
        Me.gbActualizacionesTiendaNube = New System.Windows.Forms.GroupBox()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.tpgProducto = New System.Windows.Forms.TabPage()
        Me.chbProductoPrecioEmbalaje = New Eniac.Controles.CheckBox()
        Me.lblPrecioProducto = New Eniac.Controles.Label()
        Me.cmbPrecioProducto = New Eniac.Controles.ComboBox()
        Me.lblActualizaCategorias = New Eniac.Controles.Label()
        Me.cmbActualizaCategorias = New Eniac.Controles.ComboBox()
        Me.tpgCategorias = New System.Windows.Forms.TabPage()
        Me.chbArboreaSincronizaCategorias = New Eniac.Controles.CheckBox()
        Me.tpgAtributos = New System.Windows.Forms.TabPage()
        Me.txtImportaMarcas = New Eniac.Controles.TextBox()
        Me.chbImportaMarcas = New Eniac.Controles.CheckBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.chbListaPrecioCLNuevo = New Eniac.Controles.CheckBox()
        Me.cmbListaPrecioCLNuevo = New Eniac.Controles.ComboBox()
        Me.Label1 = New Eniac.Controles.Label()
        Me.chbPreciosConIvaLP1 = New Eniac.Controles.CheckBox()
        Me.chbPreciosConIvaLP2 = New Eniac.Controles.CheckBox()
        Me.chbPreciosConIvaLP3 = New Eniac.Controles.CheckBox()
        Me.gbPedidosArborea.SuspendLayout()
        Me.gbListadPreciosArborea.SuspendLayout()
        Me.gbActualizacionesTiendaNube.SuspendLayout()
        Me.TabControl1.SuspendLayout()
        Me.tpgProducto.SuspendLayout()
        Me.tpgCategorias.SuspendLayout()
        Me.tpgAtributos.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'txtArboreaURLBase
        '
        Me.txtArboreaURLBase.BindearPropiedadControl = Nothing
        Me.txtArboreaURLBase.BindearPropiedadEntidad = Nothing
        Me.txtArboreaURLBase.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtArboreaURLBase.ForeColorFocus = System.Drawing.Color.Red
        Me.txtArboreaURLBase.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtArboreaURLBase.Formato = ""
        Me.txtArboreaURLBase.IsDecimal = False
        Me.txtArboreaURLBase.IsNumber = False
        Me.txtArboreaURLBase.IsPK = False
        Me.txtArboreaURLBase.IsRequired = False
        Me.txtArboreaURLBase.Key = ""
        Me.txtArboreaURLBase.LabelAsoc = Me.lblArboreaURLBase
        Me.txtArboreaURLBase.Location = New System.Drawing.Point(131, 6)
        Me.txtArboreaURLBase.MaxLength = 200
        Me.txtArboreaURLBase.Name = "txtArboreaURLBase"
        Me.txtArboreaURLBase.Size = New System.Drawing.Size(273, 20)
        Me.txtArboreaURLBase.TabIndex = 1
        '
        'lblArboreaURLBase
        '
        Me.lblArboreaURLBase.AutoSize = True
        Me.lblArboreaURLBase.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblArboreaURLBase.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblArboreaURLBase.LabelAsoc = Nothing
        Me.lblArboreaURLBase.Location = New System.Drawing.Point(3, 8)
        Me.lblArboreaURLBase.Name = "lblArboreaURLBase"
        Me.lblArboreaURLBase.Size = New System.Drawing.Size(56, 13)
        Me.lblArboreaURLBase.TabIndex = 0
        Me.lblArboreaURLBase.Text = "URL Base"
        '
        'lblArboreaClaveToken
        '
        Me.lblArboreaClaveToken.AutoSize = True
        Me.lblArboreaClaveToken.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblArboreaClaveToken.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblArboreaClaveToken.LabelAsoc = Nothing
        Me.lblArboreaClaveToken.Location = New System.Drawing.Point(414, 38)
        Me.lblArboreaClaveToken.Name = "lblArboreaClaveToken"
        Me.lblArboreaClaveToken.Size = New System.Drawing.Size(68, 13)
        Me.lblArboreaClaveToken.TabIndex = 6
        Me.lblArboreaClaveToken.Text = "Clave Token"
        '
        'lblArboreaUsuarioToken
        '
        Me.lblArboreaUsuarioToken.AutoSize = True
        Me.lblArboreaUsuarioToken.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblArboreaUsuarioToken.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblArboreaUsuarioToken.LabelAsoc = Nothing
        Me.lblArboreaUsuarioToken.Location = New System.Drawing.Point(414, 8)
        Me.lblArboreaUsuarioToken.Name = "lblArboreaUsuarioToken"
        Me.lblArboreaUsuarioToken.Size = New System.Drawing.Size(77, 13)
        Me.lblArboreaUsuarioToken.TabIndex = 2
        Me.lblArboreaUsuarioToken.Text = "Usuario Token"
        '
        'lblArboreaCategoriaCliente
        '
        Me.lblArboreaCategoriaCliente.AutoSize = True
        Me.lblArboreaCategoriaCliente.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblArboreaCategoriaCliente.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblArboreaCategoriaCliente.LabelAsoc = Nothing
        Me.lblArboreaCategoriaCliente.Location = New System.Drawing.Point(3, 90)
        Me.lblArboreaCategoriaCliente.Name = "lblArboreaCategoriaCliente"
        Me.lblArboreaCategoriaCliente.Size = New System.Drawing.Size(106, 13)
        Me.lblArboreaCategoriaCliente.TabIndex = 10
        Me.lblArboreaCategoriaCliente.Text = "Categoría del Cliente"
        '
        'lblArboreaCategoriaFiscalCliente
        '
        Me.lblArboreaCategoriaFiscalCliente.AutoSize = True
        Me.lblArboreaCategoriaFiscalCliente.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblArboreaCategoriaFiscalCliente.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblArboreaCategoriaFiscalCliente.LabelAsoc = Nothing
        Me.lblArboreaCategoriaFiscalCliente.Location = New System.Drawing.Point(3, 117)
        Me.lblArboreaCategoriaFiscalCliente.Name = "lblArboreaCategoriaFiscalCliente"
        Me.lblArboreaCategoriaFiscalCliente.Size = New System.Drawing.Size(119, 13)
        Me.lblArboreaCategoriaFiscalCliente.TabIndex = 12
        Me.lblArboreaCategoriaFiscalCliente.Text = "Categoría Fiscal Cliente"
        '
        'lblArboreaVendedor
        '
        Me.lblArboreaVendedor.AutoSize = True
        Me.lblArboreaVendedor.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblArboreaVendedor.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblArboreaVendedor.LabelAsoc = Nothing
        Me.lblArboreaVendedor.Location = New System.Drawing.Point(3, 144)
        Me.lblArboreaVendedor.Name = "lblArboreaVendedor"
        Me.lblArboreaVendedor.Size = New System.Drawing.Size(53, 13)
        Me.lblArboreaVendedor.TabIndex = 14
        Me.lblArboreaVendedor.Text = "Vendedor"
        '
        'cmbArboreaCategoriaCliente
        '
        Me.cmbArboreaCategoriaCliente.BindearPropiedadControl = Nothing
        Me.cmbArboreaCategoriaCliente.BindearPropiedadEntidad = Nothing
        Me.cmbArboreaCategoriaCliente.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbArboreaCategoriaCliente.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbArboreaCategoriaCliente.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbArboreaCategoriaCliente.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbArboreaCategoriaCliente.FormattingEnabled = True
        Me.cmbArboreaCategoriaCliente.IsPK = False
        Me.cmbArboreaCategoriaCliente.IsRequired = False
        Me.cmbArboreaCategoriaCliente.Key = Nothing
        Me.cmbArboreaCategoriaCliente.LabelAsoc = Nothing
        Me.cmbArboreaCategoriaCliente.Location = New System.Drawing.Point(131, 86)
        Me.cmbArboreaCategoriaCliente.Name = "cmbArboreaCategoriaCliente"
        Me.cmbArboreaCategoriaCliente.Size = New System.Drawing.Size(146, 21)
        Me.cmbArboreaCategoriaCliente.TabIndex = 11
        Me.cmbArboreaCategoriaCliente.Tag = ""
        '
        'cmbArboreaVendedor
        '
        Me.cmbArboreaVendedor.BindearPropiedadControl = Nothing
        Me.cmbArboreaVendedor.BindearPropiedadEntidad = Nothing
        Me.cmbArboreaVendedor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbArboreaVendedor.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbArboreaVendedor.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbArboreaVendedor.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbArboreaVendedor.FormattingEnabled = True
        Me.cmbArboreaVendedor.IsPK = False
        Me.cmbArboreaVendedor.IsRequired = False
        Me.cmbArboreaVendedor.Key = Nothing
        Me.cmbArboreaVendedor.LabelAsoc = Nothing
        Me.cmbArboreaVendedor.Location = New System.Drawing.Point(131, 140)
        Me.cmbArboreaVendedor.Name = "cmbArboreaVendedor"
        Me.cmbArboreaVendedor.Size = New System.Drawing.Size(146, 21)
        Me.cmbArboreaVendedor.TabIndex = 15
        Me.cmbArboreaVendedor.Tag = ""
        '
        'lblArboreaProductoEnvio
        '
        Me.lblArboreaProductoEnvio.AutoSize = True
        Me.lblArboreaProductoEnvio.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblArboreaProductoEnvio.LabelAsoc = Nothing
        Me.lblArboreaProductoEnvio.Location = New System.Drawing.Point(6, 105)
        Me.lblArboreaProductoEnvio.Name = "lblArboreaProductoEnvio"
        Me.lblArboreaProductoEnvio.Size = New System.Drawing.Size(89, 13)
        Me.lblArboreaProductoEnvio.TabIndex = 6
        Me.lblArboreaProductoEnvio.Text = "Cód. Prod. Envío"
        '
        'txtArboreaProductoEnvio
        '
        Me.txtArboreaProductoEnvio.BindearPropiedadControl = Nothing
        Me.txtArboreaProductoEnvio.BindearPropiedadEntidad = Nothing
        Me.txtArboreaProductoEnvio.ForeColorFocus = System.Drawing.Color.Red
        Me.txtArboreaProductoEnvio.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtArboreaProductoEnvio.Formato = ""
        Me.txtArboreaProductoEnvio.IsDecimal = False
        Me.txtArboreaProductoEnvio.IsNumber = False
        Me.txtArboreaProductoEnvio.IsPK = False
        Me.txtArboreaProductoEnvio.IsRequired = False
        Me.txtArboreaProductoEnvio.Key = ""
        Me.txtArboreaProductoEnvio.LabelAsoc = Me.lblArboreaUsuarioToken
        Me.txtArboreaProductoEnvio.Location = New System.Drawing.Point(121, 102)
        Me.txtArboreaProductoEnvio.MaxLength = 15
        Me.txtArboreaProductoEnvio.Name = "txtArboreaProductoEnvio"
        Me.txtArboreaProductoEnvio.Size = New System.Drawing.Size(65, 20)
        Me.txtArboreaProductoEnvio.TabIndex = 7
        Me.txtArboreaProductoEnvio.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblArboreaPedidosFormaDePago
        '
        Me.lblArboreaPedidosFormaDePago.AutoSize = True
        Me.lblArboreaPedidosFormaDePago.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblArboreaPedidosFormaDePago.LabelAsoc = Nothing
        Me.lblArboreaPedidosFormaDePago.Location = New System.Drawing.Point(6, 50)
        Me.lblArboreaPedidosFormaDePago.Name = "lblArboreaPedidosFormaDePago"
        Me.lblArboreaPedidosFormaDePago.Size = New System.Drawing.Size(79, 13)
        Me.lblArboreaPedidosFormaDePago.TabIndex = 2
        Me.lblArboreaPedidosFormaDePago.Text = "Forma de Pago"
        '
        'cmbArboreaPedidosFormaDePago
        '
        Me.cmbArboreaPedidosFormaDePago.BindearPropiedadControl = Nothing
        Me.cmbArboreaPedidosFormaDePago.BindearPropiedadEntidad = Nothing
        Me.cmbArboreaPedidosFormaDePago.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbArboreaPedidosFormaDePago.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbArboreaPedidosFormaDePago.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbArboreaPedidosFormaDePago.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbArboreaPedidosFormaDePago.FormattingEnabled = True
        Me.cmbArboreaPedidosFormaDePago.IsPK = False
        Me.cmbArboreaPedidosFormaDePago.IsRequired = False
        Me.cmbArboreaPedidosFormaDePago.Key = Nothing
        Me.cmbArboreaPedidosFormaDePago.LabelAsoc = Nothing
        Me.cmbArboreaPedidosFormaDePago.Location = New System.Drawing.Point(121, 47)
        Me.cmbArboreaPedidosFormaDePago.Name = "cmbArboreaPedidosFormaDePago"
        Me.cmbArboreaPedidosFormaDePago.Size = New System.Drawing.Size(174, 21)
        Me.cmbArboreaPedidosFormaDePago.TabIndex = 3
        Me.cmbArboreaPedidosFormaDePago.Tag = "TURISMOCATEGORIARESPONSABLE"
        '
        'lblArboreaPedidosCriticidad
        '
        Me.lblArboreaPedidosCriticidad.AutoSize = True
        Me.lblArboreaPedidosCriticidad.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblArboreaPedidosCriticidad.LabelAsoc = Nothing
        Me.lblArboreaPedidosCriticidad.Location = New System.Drawing.Point(6, 77)
        Me.lblArboreaPedidosCriticidad.Name = "lblArboreaPedidosCriticidad"
        Me.lblArboreaPedidosCriticidad.Size = New System.Drawing.Size(50, 13)
        Me.lblArboreaPedidosCriticidad.TabIndex = 4
        Me.lblArboreaPedidosCriticidad.Text = "Criticidad"
        '
        'cmbArboreaPedidosCriticidad
        '
        Me.cmbArboreaPedidosCriticidad.BindearPropiedadControl = Nothing
        Me.cmbArboreaPedidosCriticidad.BindearPropiedadEntidad = Nothing
        Me.cmbArboreaPedidosCriticidad.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbArboreaPedidosCriticidad.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbArboreaPedidosCriticidad.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbArboreaPedidosCriticidad.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbArboreaPedidosCriticidad.FormattingEnabled = True
        Me.cmbArboreaPedidosCriticidad.IsPK = False
        Me.cmbArboreaPedidosCriticidad.IsRequired = False
        Me.cmbArboreaPedidosCriticidad.Key = Nothing
        Me.cmbArboreaPedidosCriticidad.LabelAsoc = Nothing
        Me.cmbArboreaPedidosCriticidad.Location = New System.Drawing.Point(121, 74)
        Me.cmbArboreaPedidosCriticidad.Name = "cmbArboreaPedidosCriticidad"
        Me.cmbArboreaPedidosCriticidad.Size = New System.Drawing.Size(174, 21)
        Me.cmbArboreaPedidosCriticidad.TabIndex = 5
        Me.cmbArboreaPedidosCriticidad.Tag = "TURISMOCATEGORIARESPONSABLE"
        '
        'cmbArboreaPedidosTipoComprobante
        '
        Me.cmbArboreaPedidosTipoComprobante.BindearPropiedadControl = Nothing
        Me.cmbArboreaPedidosTipoComprobante.BindearPropiedadEntidad = Nothing
        Me.cmbArboreaPedidosTipoComprobante.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbArboreaPedidosTipoComprobante.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbArboreaPedidosTipoComprobante.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbArboreaPedidosTipoComprobante.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbArboreaPedidosTipoComprobante.FormattingEnabled = True
        Me.cmbArboreaPedidosTipoComprobante.IsPK = False
        Me.cmbArboreaPedidosTipoComprobante.IsRequired = False
        Me.cmbArboreaPedidosTipoComprobante.Key = Nothing
        Me.cmbArboreaPedidosTipoComprobante.LabelAsoc = Nothing
        Me.cmbArboreaPedidosTipoComprobante.Location = New System.Drawing.Point(121, 21)
        Me.cmbArboreaPedidosTipoComprobante.Name = "cmbArboreaPedidosTipoComprobante"
        Me.cmbArboreaPedidosTipoComprobante.Size = New System.Drawing.Size(174, 21)
        Me.cmbArboreaPedidosTipoComprobante.TabIndex = 1
        Me.cmbArboreaPedidosTipoComprobante.Tag = ""
        '
        'lblArboreaPedidosTipoComprobante
        '
        Me.lblArboreaPedidosTipoComprobante.AutoSize = True
        Me.lblArboreaPedidosTipoComprobante.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblArboreaPedidosTipoComprobante.LabelAsoc = Nothing
        Me.lblArboreaPedidosTipoComprobante.Location = New System.Drawing.Point(6, 24)
        Me.lblArboreaPedidosTipoComprobante.Name = "lblArboreaPedidosTipoComprobante"
        Me.lblArboreaPedidosTipoComprobante.Size = New System.Drawing.Size(109, 13)
        Me.lblArboreaPedidosTipoComprobante.TabIndex = 0
        Me.lblArboreaPedidosTipoComprobante.Text = "Tipo de Comprobante"
        '
        'gbPedidosArborea
        '
        Me.gbPedidosArborea.Controls.Add(Me.lblArboreaProductoEnvio)
        Me.gbPedidosArborea.Controls.Add(Me.txtArboreaProductoEnvio)
        Me.gbPedidosArborea.Controls.Add(Me.lblArboreaPedidosFormaDePago)
        Me.gbPedidosArborea.Controls.Add(Me.cmbArboreaPedidosFormaDePago)
        Me.gbPedidosArborea.Controls.Add(Me.lblArboreaPedidosCriticidad)
        Me.gbPedidosArborea.Controls.Add(Me.cmbArboreaPedidosCriticidad)
        Me.gbPedidosArborea.Controls.Add(Me.cmbArboreaPedidosTipoComprobante)
        Me.gbPedidosArborea.Controls.Add(Me.lblArboreaPedidosTipoComprobante)
        Me.gbPedidosArborea.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbPedidosArborea.Location = New System.Drawing.Point(320, 166)
        Me.gbPedidosArborea.Name = "gbPedidosArborea"
        Me.gbPedidosArborea.Size = New System.Drawing.Size(307, 135)
        Me.gbPedidosArborea.TabIndex = 23
        Me.gbPedidosArborea.TabStop = False
        Me.gbPedidosArborea.Text = "Pedidos"
        '
        'lblArboreaCorreoNotificaciones
        '
        Me.lblArboreaCorreoNotificaciones.AutoSize = True
        Me.lblArboreaCorreoNotificaciones.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblArboreaCorreoNotificaciones.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblArboreaCorreoNotificaciones.LabelAsoc = Nothing
        Me.lblArboreaCorreoNotificaciones.Location = New System.Drawing.Point(3, 37)
        Me.lblArboreaCorreoNotificaciones.Name = "lblArboreaCorreoNotificaciones"
        Me.lblArboreaCorreoNotificaciones.Size = New System.Drawing.Size(108, 13)
        Me.lblArboreaCorreoNotificaciones.TabIndex = 4
        Me.lblArboreaCorreoNotificaciones.Text = "Correo Notificaciones"
        '
        'txtArboreaCorreoNotificaciones
        '
        Me.txtArboreaCorreoNotificaciones.BindearPropiedadControl = Nothing
        Me.txtArboreaCorreoNotificaciones.BindearPropiedadEntidad = Nothing
        Me.txtArboreaCorreoNotificaciones.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtArboreaCorreoNotificaciones.ForeColorFocus = System.Drawing.Color.Red
        Me.txtArboreaCorreoNotificaciones.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtArboreaCorreoNotificaciones.Formato = ""
        Me.txtArboreaCorreoNotificaciones.IsDecimal = False
        Me.txtArboreaCorreoNotificaciones.IsNumber = False
        Me.txtArboreaCorreoNotificaciones.IsPK = False
        Me.txtArboreaCorreoNotificaciones.IsRequired = False
        Me.txtArboreaCorreoNotificaciones.Key = ""
        Me.txtArboreaCorreoNotificaciones.LabelAsoc = Me.lblArboreaCorreoNotificaciones
        Me.txtArboreaCorreoNotificaciones.Location = New System.Drawing.Point(131, 34)
        Me.txtArboreaCorreoNotificaciones.MaxLength = 200
        Me.txtArboreaCorreoNotificaciones.Name = "txtArboreaCorreoNotificaciones"
        Me.txtArboreaCorreoNotificaciones.Size = New System.Drawing.Size(273, 20)
        Me.txtArboreaCorreoNotificaciones.TabIndex = 5
        '
        'txtArboreaUsuarioToken
        '
        Me.txtArboreaUsuarioToken.BindearPropiedadControl = Nothing
        Me.txtArboreaUsuarioToken.BindearPropiedadEntidad = Nothing
        Me.txtArboreaUsuarioToken.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtArboreaUsuarioToken.ForeColorFocus = System.Drawing.Color.Red
        Me.txtArboreaUsuarioToken.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtArboreaUsuarioToken.Formato = ""
        Me.txtArboreaUsuarioToken.IsDecimal = False
        Me.txtArboreaUsuarioToken.IsNumber = False
        Me.txtArboreaUsuarioToken.IsPK = False
        Me.txtArboreaUsuarioToken.IsRequired = False
        Me.txtArboreaUsuarioToken.Key = ""
        Me.txtArboreaUsuarioToken.LabelAsoc = Me.lblArboreaUsuarioToken
        Me.txtArboreaUsuarioToken.Location = New System.Drawing.Point(497, 5)
        Me.txtArboreaUsuarioToken.MaxLength = 200
        Me.txtArboreaUsuarioToken.Name = "txtArboreaUsuarioToken"
        Me.txtArboreaUsuarioToken.Size = New System.Drawing.Size(401, 20)
        Me.txtArboreaUsuarioToken.TabIndex = 3
        '
        'txtArboreaClaveToken
        '
        Me.txtArboreaClaveToken.BindearPropiedadControl = Nothing
        Me.txtArboreaClaveToken.BindearPropiedadEntidad = Nothing
        Me.txtArboreaClaveToken.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtArboreaClaveToken.ForeColorFocus = System.Drawing.Color.Red
        Me.txtArboreaClaveToken.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtArboreaClaveToken.Formato = ""
        Me.txtArboreaClaveToken.IsDecimal = False
        Me.txtArboreaClaveToken.IsNumber = False
        Me.txtArboreaClaveToken.IsPK = False
        Me.txtArboreaClaveToken.IsRequired = False
        Me.txtArboreaClaveToken.Key = ""
        Me.txtArboreaClaveToken.LabelAsoc = Me.lblArboreaUsuarioToken
        Me.txtArboreaClaveToken.Location = New System.Drawing.Point(497, 32)
        Me.txtArboreaClaveToken.MaxLength = 200
        Me.txtArboreaClaveToken.Name = "txtArboreaClaveToken"
        Me.txtArboreaClaveToken.Size = New System.Drawing.Size(401, 20)
        Me.txtArboreaClaveToken.TabIndex = 7
        '
        'txtArboreaCategoriaPrincipal
        '
        Me.txtArboreaCategoriaPrincipal.BindearPropiedadControl = Nothing
        Me.txtArboreaCategoriaPrincipal.BindearPropiedadEntidad = Nothing
        Me.txtArboreaCategoriaPrincipal.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtArboreaCategoriaPrincipal.ForeColorFocus = System.Drawing.Color.Red
        Me.txtArboreaCategoriaPrincipal.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtArboreaCategoriaPrincipal.Formato = ""
        Me.txtArboreaCategoriaPrincipal.IsDecimal = False
        Me.txtArboreaCategoriaPrincipal.IsNumber = False
        Me.txtArboreaCategoriaPrincipal.IsPK = False
        Me.txtArboreaCategoriaPrincipal.IsRequired = False
        Me.txtArboreaCategoriaPrincipal.Key = ""
        Me.txtArboreaCategoriaPrincipal.LabelAsoc = Me.lblArboreaUsuarioToken
        Me.txtArboreaCategoriaPrincipal.Location = New System.Drawing.Point(131, 60)
        Me.txtArboreaCategoriaPrincipal.MaxLength = 200
        Me.txtArboreaCategoriaPrincipal.Name = "txtArboreaCategoriaPrincipal"
        Me.txtArboreaCategoriaPrincipal.Size = New System.Drawing.Size(146, 20)
        Me.txtArboreaCategoriaPrincipal.TabIndex = 9
        '
        'lblArboreaCategoriaPrincipal
        '
        Me.lblArboreaCategoriaPrincipal.AutoSize = True
        Me.lblArboreaCategoriaPrincipal.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblArboreaCategoriaPrincipal.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblArboreaCategoriaPrincipal.LabelAsoc = Nothing
        Me.lblArboreaCategoriaPrincipal.Location = New System.Drawing.Point(4, 64)
        Me.lblArboreaCategoriaPrincipal.Name = "lblArboreaCategoriaPrincipal"
        Me.lblArboreaCategoriaPrincipal.Size = New System.Drawing.Size(95, 13)
        Me.lblArboreaCategoriaPrincipal.TabIndex = 8
        Me.lblArboreaCategoriaPrincipal.Text = "Categoria Principal"
        '
        'cmbArboreaCategoriaFiscalCliente
        '
        Me.cmbArboreaCategoriaFiscalCliente.BindearPropiedadControl = Nothing
        Me.cmbArboreaCategoriaFiscalCliente.BindearPropiedadEntidad = Nothing
        Me.cmbArboreaCategoriaFiscalCliente.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbArboreaCategoriaFiscalCliente.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbArboreaCategoriaFiscalCliente.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbArboreaCategoriaFiscalCliente.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbArboreaCategoriaFiscalCliente.FormattingEnabled = True
        Me.cmbArboreaCategoriaFiscalCliente.IsPK = False
        Me.cmbArboreaCategoriaFiscalCliente.IsRequired = False
        Me.cmbArboreaCategoriaFiscalCliente.Key = Nothing
        Me.cmbArboreaCategoriaFiscalCliente.LabelAsoc = Nothing
        Me.cmbArboreaCategoriaFiscalCliente.Location = New System.Drawing.Point(131, 113)
        Me.cmbArboreaCategoriaFiscalCliente.Name = "cmbArboreaCategoriaFiscalCliente"
        Me.cmbArboreaCategoriaFiscalCliente.Size = New System.Drawing.Size(146, 21)
        Me.cmbArboreaCategoriaFiscalCliente.TabIndex = 13
        Me.cmbArboreaCategoriaFiscalCliente.Tag = ""
        '
        'gbListadPreciosArborea
        '
        Me.gbListadPreciosArborea.Controls.Add(Me.chbPreciosConIvaLP3)
        Me.gbListadPreciosArborea.Controls.Add(Me.chbPreciosConIvaLP2)
        Me.gbListadPreciosArborea.Controls.Add(Me.chbPreciosConIvaLP1)
        Me.gbListadPreciosArborea.Controls.Add(Me.chbPreciosConIvaPV)
        Me.gbListadPreciosArborea.Controls.Add(Me.chbListaPrecio04)
        Me.gbListadPreciosArborea.Controls.Add(Me.chbListaPrecio03)
        Me.gbListadPreciosArborea.Controls.Add(Me.chbListaPrecio02)
        Me.gbListadPreciosArborea.Controls.Add(Me.chbListaPrecio01)
        Me.gbListadPreciosArborea.Controls.Add(Me.cmbListaPrecio04)
        Me.gbListadPreciosArborea.Controls.Add(Me.cmbListaPrecio03)
        Me.gbListadPreciosArborea.Controls.Add(Me.cmbListaPrecio02)
        Me.gbListadPreciosArborea.Controls.Add(Me.cmbListaPrecio01)
        Me.gbListadPreciosArborea.Controls.Add(Me.Label1)
        Me.gbListadPreciosArborea.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbListadPreciosArborea.Location = New System.Drawing.Point(6, 166)
        Me.gbListadPreciosArborea.Name = "gbListadPreciosArborea"
        Me.gbListadPreciosArborea.Size = New System.Drawing.Size(305, 135)
        Me.gbListadPreciosArborea.TabIndex = 22
        Me.gbListadPreciosArborea.TabStop = False
        Me.gbListadPreciosArborea.Text = "Listas de Precios"
        '
        'chbPreciosConIvaPV
        '
        Me.chbPreciosConIvaPV.AutoSize = True
        Me.chbPreciosConIvaPV.BindearPropiedadControl = Nothing
        Me.chbPreciosConIvaPV.BindearPropiedadEntidad = Nothing
        Me.chbPreciosConIvaPV.ForeColorFocus = System.Drawing.Color.Red
        Me.chbPreciosConIvaPV.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbPreciosConIvaPV.IsPK = False
        Me.chbPreciosConIvaPV.IsRequired = False
        Me.chbPreciosConIvaPV.Key = Nothing
        Me.chbPreciosConIvaPV.LabelAsoc = Nothing
        Me.chbPreciosConIvaPV.Location = New System.Drawing.Point(281, 36)
        Me.chbPreciosConIvaPV.Name = "chbPreciosConIvaPV"
        Me.chbPreciosConIvaPV.Size = New System.Drawing.Size(15, 14)
        Me.chbPreciosConIvaPV.TabIndex = 74
        Me.chbPreciosConIvaPV.Tag = ""
        Me.chbPreciosConIvaPV.UseVisualStyleBackColor = True
        '
        'chbListaPrecio04
        '
        Me.chbListaPrecio04.AutoSize = True
        Me.chbListaPrecio04.BindearPropiedadControl = ""
        Me.chbListaPrecio04.BindearPropiedadEntidad = ""
        Me.chbListaPrecio04.ForeColorFocus = System.Drawing.Color.Red
        Me.chbListaPrecio04.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbListaPrecio04.IsPK = False
        Me.chbListaPrecio04.IsRequired = False
        Me.chbListaPrecio04.Key = Nothing
        Me.chbListaPrecio04.LabelAsoc = Nothing
        Me.chbListaPrecio04.Location = New System.Drawing.Point(9, 107)
        Me.chbListaPrecio04.Name = "chbListaPrecio04"
        Me.chbListaPrecio04.Size = New System.Drawing.Size(110, 17)
        Me.chbListaPrecio04.TabIndex = 6
        Me.chbListaPrecio04.Text = "Lista de Precios 3"
        Me.chbListaPrecio04.UseVisualStyleBackColor = True
        '
        'chbListaPrecio03
        '
        Me.chbListaPrecio03.AutoSize = True
        Me.chbListaPrecio03.BindearPropiedadControl = ""
        Me.chbListaPrecio03.BindearPropiedadEntidad = ""
        Me.chbListaPrecio03.ForeColorFocus = System.Drawing.Color.Red
        Me.chbListaPrecio03.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbListaPrecio03.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.chbListaPrecio03.IsPK = False
        Me.chbListaPrecio03.IsRequired = False
        Me.chbListaPrecio03.Key = Nothing
        Me.chbListaPrecio03.LabelAsoc = Nothing
        Me.chbListaPrecio03.Location = New System.Drawing.Point(9, 82)
        Me.chbListaPrecio03.Name = "chbListaPrecio03"
        Me.chbListaPrecio03.Size = New System.Drawing.Size(110, 17)
        Me.chbListaPrecio03.TabIndex = 4
        Me.chbListaPrecio03.Text = "Lista de Precios 2"
        Me.chbListaPrecio03.UseVisualStyleBackColor = True
        '
        'chbListaPrecio02
        '
        Me.chbListaPrecio02.AutoSize = True
        Me.chbListaPrecio02.BindearPropiedadControl = ""
        Me.chbListaPrecio02.BindearPropiedadEntidad = ""
        Me.chbListaPrecio02.ForeColorFocus = System.Drawing.Color.Red
        Me.chbListaPrecio02.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbListaPrecio02.IsPK = False
        Me.chbListaPrecio02.IsRequired = False
        Me.chbListaPrecio02.Key = Nothing
        Me.chbListaPrecio02.LabelAsoc = Nothing
        Me.chbListaPrecio02.Location = New System.Drawing.Point(9, 57)
        Me.chbListaPrecio02.Name = "chbListaPrecio02"
        Me.chbListaPrecio02.Size = New System.Drawing.Size(110, 17)
        Me.chbListaPrecio02.TabIndex = 2
        Me.chbListaPrecio02.Text = "Lista de Precios 1"
        Me.chbListaPrecio02.UseVisualStyleBackColor = True
        '
        'chbListaPrecio01
        '
        Me.chbListaPrecio01.AutoSize = True
        Me.chbListaPrecio01.BindearPropiedadControl = ""
        Me.chbListaPrecio01.BindearPropiedadEntidad = ""
        Me.chbListaPrecio01.ForeColorFocus = System.Drawing.Color.Red
        Me.chbListaPrecio01.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbListaPrecio01.IsPK = False
        Me.chbListaPrecio01.IsRequired = False
        Me.chbListaPrecio01.Key = Nothing
        Me.chbListaPrecio01.LabelAsoc = Nothing
        Me.chbListaPrecio01.Location = New System.Drawing.Point(9, 33)
        Me.chbListaPrecio01.Name = "chbListaPrecio01"
        Me.chbListaPrecio01.Size = New System.Drawing.Size(102, 17)
        Me.chbListaPrecio01.TabIndex = 0
        Me.chbListaPrecio01.Text = "Precio de Venta"
        Me.chbListaPrecio01.UseVisualStyleBackColor = True
        '
        'cmbListaPrecio04
        '
        Me.cmbListaPrecio04.BindearPropiedadControl = Nothing
        Me.cmbListaPrecio04.BindearPropiedadEntidad = Nothing
        Me.cmbListaPrecio04.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbListaPrecio04.Enabled = False
        Me.cmbListaPrecio04.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbListaPrecio04.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbListaPrecio04.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbListaPrecio04.FormattingEnabled = True
        Me.cmbListaPrecio04.IsPK = False
        Me.cmbListaPrecio04.IsRequired = False
        Me.cmbListaPrecio04.Key = Nothing
        Me.cmbListaPrecio04.LabelAsoc = Nothing
        Me.cmbListaPrecio04.Location = New System.Drawing.Point(125, 105)
        Me.cmbListaPrecio04.Name = "cmbListaPrecio04"
        Me.cmbListaPrecio04.Size = New System.Drawing.Size(146, 21)
        Me.cmbListaPrecio04.TabIndex = 7
        Me.cmbListaPrecio04.Tag = "TURISMOCATEGORIARESPONSABLE"
        '
        'cmbListaPrecio03
        '
        Me.cmbListaPrecio03.BindearPropiedadControl = Nothing
        Me.cmbListaPrecio03.BindearPropiedadEntidad = Nothing
        Me.cmbListaPrecio03.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbListaPrecio03.Enabled = False
        Me.cmbListaPrecio03.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbListaPrecio03.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbListaPrecio03.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbListaPrecio03.FormattingEnabled = True
        Me.cmbListaPrecio03.IsPK = False
        Me.cmbListaPrecio03.IsRequired = False
        Me.cmbListaPrecio03.Key = Nothing
        Me.cmbListaPrecio03.LabelAsoc = Nothing
        Me.cmbListaPrecio03.Location = New System.Drawing.Point(125, 80)
        Me.cmbListaPrecio03.Name = "cmbListaPrecio03"
        Me.cmbListaPrecio03.Size = New System.Drawing.Size(146, 21)
        Me.cmbListaPrecio03.TabIndex = 5
        Me.cmbListaPrecio03.Tag = "TURISMOCATEGORIARESPONSABLE"
        '
        'cmbListaPrecio02
        '
        Me.cmbListaPrecio02.BindearPropiedadControl = Nothing
        Me.cmbListaPrecio02.BindearPropiedadEntidad = Nothing
        Me.cmbListaPrecio02.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbListaPrecio02.Enabled = False
        Me.cmbListaPrecio02.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbListaPrecio02.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbListaPrecio02.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbListaPrecio02.FormattingEnabled = True
        Me.cmbListaPrecio02.IsPK = False
        Me.cmbListaPrecio02.IsRequired = False
        Me.cmbListaPrecio02.Key = Nothing
        Me.cmbListaPrecio02.LabelAsoc = Nothing
        Me.cmbListaPrecio02.Location = New System.Drawing.Point(125, 55)
        Me.cmbListaPrecio02.Name = "cmbListaPrecio02"
        Me.cmbListaPrecio02.Size = New System.Drawing.Size(146, 21)
        Me.cmbListaPrecio02.TabIndex = 3
        Me.cmbListaPrecio02.Tag = "TURISMOCATEGORIARESPONSABLE"
        '
        'cmbListaPrecio01
        '
        Me.cmbListaPrecio01.BindearPropiedadControl = Nothing
        Me.cmbListaPrecio01.BindearPropiedadEntidad = Nothing
        Me.cmbListaPrecio01.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbListaPrecio01.Enabled = False
        Me.cmbListaPrecio01.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbListaPrecio01.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbListaPrecio01.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbListaPrecio01.FormattingEnabled = True
        Me.cmbListaPrecio01.IsPK = False
        Me.cmbListaPrecio01.IsRequired = False
        Me.cmbListaPrecio01.Key = Nothing
        Me.cmbListaPrecio01.LabelAsoc = Nothing
        Me.cmbListaPrecio01.Location = New System.Drawing.Point(125, 31)
        Me.cmbListaPrecio01.Name = "cmbListaPrecio01"
        Me.cmbListaPrecio01.Size = New System.Drawing.Size(146, 21)
        Me.cmbListaPrecio01.TabIndex = 1
        Me.cmbListaPrecio01.Tag = ""
        '
        'txtArboreaURLListaPrecios
        '
        Me.txtArboreaURLListaPrecios.BindearPropiedadControl = Nothing
        Me.txtArboreaURLListaPrecios.BindearPropiedadEntidad = Nothing
        Me.txtArboreaURLListaPrecios.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtArboreaURLListaPrecios.ForeColorFocus = System.Drawing.Color.Red
        Me.txtArboreaURLListaPrecios.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtArboreaURLListaPrecios.Formato = ""
        Me.txtArboreaURLListaPrecios.IsDecimal = False
        Me.txtArboreaURLListaPrecios.IsNumber = False
        Me.txtArboreaURLListaPrecios.IsPK = False
        Me.txtArboreaURLListaPrecios.IsRequired = False
        Me.txtArboreaURLListaPrecios.Key = ""
        Me.txtArboreaURLListaPrecios.LabelAsoc = Me.lblArboreaUsuarioToken
        Me.txtArboreaURLListaPrecios.Location = New System.Drawing.Point(451, 60)
        Me.txtArboreaURLListaPrecios.MaxLength = 200
        Me.txtArboreaURLListaPrecios.Name = "txtArboreaURLListaPrecios"
        Me.txtArboreaURLListaPrecios.Size = New System.Drawing.Size(447, 20)
        Me.txtArboreaURLListaPrecios.TabIndex = 17
        '
        'lblArboreaURLListaPrecios
        '
        Me.lblArboreaURLListaPrecios.AutoSize = True
        Me.lblArboreaURLListaPrecios.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblArboreaURLListaPrecios.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblArboreaURLListaPrecios.LabelAsoc = Nothing
        Me.lblArboreaURLListaPrecios.Location = New System.Drawing.Point(289, 64)
        Me.lblArboreaURLListaPrecios.Name = "lblArboreaURLListaPrecios"
        Me.lblArboreaURLListaPrecios.Size = New System.Drawing.Size(92, 13)
        Me.lblArboreaURLListaPrecios.TabIndex = 16
        Me.lblArboreaURLListaPrecios.Text = "URL Lista Precios"
        '
        'txtArboreaURLListaPreciosClientes
        '
        Me.txtArboreaURLListaPreciosClientes.BindearPropiedadControl = Nothing
        Me.txtArboreaURLListaPreciosClientes.BindearPropiedadEntidad = Nothing
        Me.txtArboreaURLListaPreciosClientes.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtArboreaURLListaPreciosClientes.ForeColorFocus = System.Drawing.Color.Red
        Me.txtArboreaURLListaPreciosClientes.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtArboreaURLListaPreciosClientes.Formato = ""
        Me.txtArboreaURLListaPreciosClientes.IsDecimal = False
        Me.txtArboreaURLListaPreciosClientes.IsNumber = False
        Me.txtArboreaURLListaPreciosClientes.IsPK = False
        Me.txtArboreaURLListaPreciosClientes.IsRequired = False
        Me.txtArboreaURLListaPreciosClientes.Key = ""
        Me.txtArboreaURLListaPreciosClientes.LabelAsoc = Me.lblArboreaUsuarioToken
        Me.txtArboreaURLListaPreciosClientes.Location = New System.Drawing.Point(451, 86)
        Me.txtArboreaURLListaPreciosClientes.MaxLength = 200
        Me.txtArboreaURLListaPreciosClientes.Name = "txtArboreaURLListaPreciosClientes"
        Me.txtArboreaURLListaPreciosClientes.Size = New System.Drawing.Size(447, 20)
        Me.txtArboreaURLListaPreciosClientes.TabIndex = 19
        '
        'lblArboreaURLListaPreciosClientes
        '
        Me.lblArboreaURLListaPreciosClientes.AutoSize = True
        Me.lblArboreaURLListaPreciosClientes.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblArboreaURLListaPreciosClientes.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblArboreaURLListaPreciosClientes.LabelAsoc = Nothing
        Me.lblArboreaURLListaPreciosClientes.Location = New System.Drawing.Point(289, 90)
        Me.lblArboreaURLListaPreciosClientes.Name = "lblArboreaURLListaPreciosClientes"
        Me.lblArboreaURLListaPreciosClientes.Size = New System.Drawing.Size(132, 13)
        Me.lblArboreaURLListaPreciosClientes.TabIndex = 18
        Me.lblArboreaURLListaPreciosClientes.Text = "URL Lista Precios Clientes"
        '
        'chbArboreaExportarSolicitudesSubida
        '
        Me.chbArboreaExportarSolicitudesSubida.AutoSize = True
        Me.chbArboreaExportarSolicitudesSubida.BindearPropiedadControl = ""
        Me.chbArboreaExportarSolicitudesSubida.BindearPropiedadEntidad = ""
        Me.chbArboreaExportarSolicitudesSubida.ForeColorFocus = System.Drawing.Color.Red
        Me.chbArboreaExportarSolicitudesSubida.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbArboreaExportarSolicitudesSubida.IsPK = False
        Me.chbArboreaExportarSolicitudesSubida.IsRequired = False
        Me.chbArboreaExportarSolicitudesSubida.Key = Nothing
        Me.chbArboreaExportarSolicitudesSubida.LabelAsoc = Nothing
        Me.chbArboreaExportarSolicitudesSubida.Location = New System.Drawing.Point(292, 115)
        Me.chbArboreaExportarSolicitudesSubida.Name = "chbArboreaExportarSolicitudesSubida"
        Me.chbArboreaExportarSolicitudesSubida.Size = New System.Drawing.Size(151, 17)
        Me.chbArboreaExportarSolicitudesSubida.TabIndex = 20
        Me.chbArboreaExportarSolicitudesSubida.Text = "Exportar solicitudes subida"
        Me.chbArboreaExportarSolicitudesSubida.UseVisualStyleBackColor = True
        '
        'txtArboreaExportarSolicitudesSubidaPath
        '
        Me.txtArboreaExportarSolicitudesSubidaPath.BindearPropiedadControl = Nothing
        Me.txtArboreaExportarSolicitudesSubidaPath.BindearPropiedadEntidad = Nothing
        Me.txtArboreaExportarSolicitudesSubidaPath.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtArboreaExportarSolicitudesSubidaPath.ForeColorFocus = System.Drawing.Color.Red
        Me.txtArboreaExportarSolicitudesSubidaPath.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtArboreaExportarSolicitudesSubidaPath.Formato = ""
        Me.txtArboreaExportarSolicitudesSubidaPath.IsDecimal = False
        Me.txtArboreaExportarSolicitudesSubidaPath.IsNumber = False
        Me.txtArboreaExportarSolicitudesSubidaPath.IsPK = False
        Me.txtArboreaExportarSolicitudesSubidaPath.IsRequired = False
        Me.txtArboreaExportarSolicitudesSubidaPath.Key = ""
        Me.txtArboreaExportarSolicitudesSubidaPath.LabelAsoc = Me.lblArboreaUsuarioToken
        Me.txtArboreaExportarSolicitudesSubidaPath.Location = New System.Drawing.Point(451, 113)
        Me.txtArboreaExportarSolicitudesSubidaPath.MaxLength = 200
        Me.txtArboreaExportarSolicitudesSubidaPath.Name = "txtArboreaExportarSolicitudesSubidaPath"
        Me.txtArboreaExportarSolicitudesSubidaPath.Size = New System.Drawing.Size(447, 20)
        Me.txtArboreaExportarSolicitudesSubidaPath.TabIndex = 21
        '
        'gbActualizacionesTiendaNube
        '
        Me.gbActualizacionesTiendaNube.Controls.Add(Me.TabControl1)
        Me.gbActualizacionesTiendaNube.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbActualizacionesTiendaNube.Location = New System.Drawing.Point(7, 305)
        Me.gbActualizacionesTiendaNube.Name = "gbActualizacionesTiendaNube"
        Me.gbActualizacionesTiendaNube.Size = New System.Drawing.Size(891, 112)
        Me.gbActualizacionesTiendaNube.TabIndex = 71
        Me.gbActualizacionesTiendaNube.TabStop = False
        Me.gbActualizacionesTiendaNube.Text = "Actualizaciones"
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.tpgProducto)
        Me.TabControl1.Controls.Add(Me.tpgCategorias)
        Me.TabControl1.Controls.Add(Me.tpgAtributos)
        Me.TabControl1.Location = New System.Drawing.Point(6, 19)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(879, 87)
        Me.TabControl1.TabIndex = 0
        '
        'tpgProducto
        '
        Me.tpgProducto.BackColor = System.Drawing.SystemColors.Control
        Me.tpgProducto.Controls.Add(Me.chbProductoPrecioEmbalaje)
        Me.tpgProducto.Controls.Add(Me.lblPrecioProducto)
        Me.tpgProducto.Controls.Add(Me.cmbPrecioProducto)
        Me.tpgProducto.Controls.Add(Me.lblActualizaCategorias)
        Me.tpgProducto.Controls.Add(Me.cmbActualizaCategorias)
        Me.tpgProducto.Location = New System.Drawing.Point(4, 22)
        Me.tpgProducto.Name = "tpgProducto"
        Me.tpgProducto.Padding = New System.Windows.Forms.Padding(3)
        Me.tpgProducto.Size = New System.Drawing.Size(871, 61)
        Me.tpgProducto.TabIndex = 0
        Me.tpgProducto.Text = "Productos"
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
        Me.chbProductoPrecioEmbalaje.Location = New System.Drawing.Point(373, 13)
        Me.chbProductoPrecioEmbalaje.Name = "chbProductoPrecioEmbalaje"
        Me.chbProductoPrecioEmbalaje.Size = New System.Drawing.Size(161, 17)
        Me.chbProductoPrecioEmbalaje.TabIndex = 73
        Me.chbProductoPrecioEmbalaje.Tag = ""
        Me.chbProductoPrecioEmbalaje.Text = "Publicar Precio por Embalaje"
        Me.chbProductoPrecioEmbalaje.UseVisualStyleBackColor = True
        '
        'lblPrecioProducto
        '
        Me.lblPrecioProducto.AutoSize = True
        Me.lblPrecioProducto.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPrecioProducto.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblPrecioProducto.LabelAsoc = Nothing
        Me.lblPrecioProducto.Location = New System.Drawing.Point(17, 37)
        Me.lblPrecioProducto.Name = "lblPrecioProducto"
        Me.lblPrecioProducto.Size = New System.Drawing.Size(157, 13)
        Me.lblPrecioProducto.TabIndex = 72
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
        Me.cmbPrecioProducto.Location = New System.Drawing.Point(180, 34)
        Me.cmbPrecioProducto.Name = "cmbPrecioProducto"
        Me.cmbPrecioProducto.Size = New System.Drawing.Size(101, 21)
        Me.cmbPrecioProducto.TabIndex = 71
        Me.cmbPrecioProducto.Tag = ""
        '
        'lblActualizaCategorias
        '
        Me.lblActualizaCategorias.AutoSize = True
        Me.lblActualizaCategorias.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblActualizaCategorias.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblActualizaCategorias.LabelAsoc = Nothing
        Me.lblActualizaCategorias.Location = New System.Drawing.Point(17, 12)
        Me.lblActualizaCategorias.Name = "lblActualizaCategorias"
        Me.lblActualizaCategorias.Size = New System.Drawing.Size(125, 13)
        Me.lblActualizaCategorias.TabIndex = 70
        Me.lblActualizaCategorias.Text = "Categorías de Productos"
        '
        'cmbActualizaCategorias
        '
        Me.cmbActualizaCategorias.BindearPropiedadControl = Nothing
        Me.cmbActualizaCategorias.BindearPropiedadEntidad = Nothing
        Me.cmbActualizaCategorias.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbActualizaCategorias.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbActualizaCategorias.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbActualizaCategorias.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbActualizaCategorias.FormattingEnabled = True
        Me.cmbActualizaCategorias.IsPK = False
        Me.cmbActualizaCategorias.IsRequired = False
        Me.cmbActualizaCategorias.Key = Nothing
        Me.cmbActualizaCategorias.LabelAsoc = Me.lblActualizaCategorias
        Me.cmbActualizaCategorias.Location = New System.Drawing.Point(180, 9)
        Me.cmbActualizaCategorias.Name = "cmbActualizaCategorias"
        Me.cmbActualizaCategorias.Size = New System.Drawing.Size(166, 21)
        Me.cmbActualizaCategorias.TabIndex = 68
        Me.cmbActualizaCategorias.Tag = ""
        '
        'tpgCategorias
        '
        Me.tpgCategorias.BackColor = System.Drawing.SystemColors.Control
        Me.tpgCategorias.Controls.Add(Me.chbArboreaSincronizaCategorias)
        Me.tpgCategorias.Location = New System.Drawing.Point(4, 22)
        Me.tpgCategorias.Name = "tpgCategorias"
        Me.tpgCategorias.Padding = New System.Windows.Forms.Padding(3)
        Me.tpgCategorias.Size = New System.Drawing.Size(871, 61)
        Me.tpgCategorias.TabIndex = 1
        Me.tpgCategorias.Text = "Categorias"
        '
        'chbArboreaSincronizaCategorias
        '
        Me.chbArboreaSincronizaCategorias.AutoSize = True
        Me.chbArboreaSincronizaCategorias.BindearPropiedadControl = ""
        Me.chbArboreaSincronizaCategorias.BindearPropiedadEntidad = ""
        Me.chbArboreaSincronizaCategorias.ForeColorFocus = System.Drawing.Color.Red
        Me.chbArboreaSincronizaCategorias.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbArboreaSincronizaCategorias.IsPK = False
        Me.chbArboreaSincronizaCategorias.IsRequired = False
        Me.chbArboreaSincronizaCategorias.Key = Nothing
        Me.chbArboreaSincronizaCategorias.LabelAsoc = Nothing
        Me.chbArboreaSincronizaCategorias.Location = New System.Drawing.Point(6, 6)
        Me.chbArboreaSincronizaCategorias.Name = "chbArboreaSincronizaCategorias"
        Me.chbArboreaSincronizaCategorias.Size = New System.Drawing.Size(236, 17)
        Me.chbArboreaSincronizaCategorias.TabIndex = 1
        Me.chbArboreaSincronizaCategorias.Text = "Sincroniza Categorias (Rubros - Sub Rubros)"
        Me.chbArboreaSincronizaCategorias.UseVisualStyleBackColor = True
        '
        'tpgAtributos
        '
        Me.tpgAtributos.BackColor = System.Drawing.SystemColors.Control
        Me.tpgAtributos.Controls.Add(Me.txtImportaMarcas)
        Me.tpgAtributos.Controls.Add(Me.chbImportaMarcas)
        Me.tpgAtributos.Location = New System.Drawing.Point(4, 22)
        Me.tpgAtributos.Name = "tpgAtributos"
        Me.tpgAtributos.Size = New System.Drawing.Size(871, 61)
        Me.tpgAtributos.TabIndex = 2
        Me.tpgAtributos.Text = "Atributos"
        '
        'txtImportaMarcas
        '
        Me.txtImportaMarcas.BindearPropiedadControl = Nothing
        Me.txtImportaMarcas.BindearPropiedadEntidad = Nothing
        Me.txtImportaMarcas.ForeColorFocus = System.Drawing.Color.Red
        Me.txtImportaMarcas.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtImportaMarcas.Formato = ""
        Me.txtImportaMarcas.IsDecimal = False
        Me.txtImportaMarcas.IsNumber = True
        Me.txtImportaMarcas.IsPK = False
        Me.txtImportaMarcas.IsRequired = False
        Me.txtImportaMarcas.Key = ""
        Me.txtImportaMarcas.LabelAsoc = Me.lblArboreaUsuarioToken
        Me.txtImportaMarcas.Location = New System.Drawing.Point(235, 6)
        Me.txtImportaMarcas.MaxLength = 15
        Me.txtImportaMarcas.Name = "txtImportaMarcas"
        Me.txtImportaMarcas.Size = New System.Drawing.Size(51, 20)
        Me.txtImportaMarcas.TabIndex = 8
        Me.txtImportaMarcas.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'chbImportaMarcas
        '
        Me.chbImportaMarcas.AutoSize = True
        Me.chbImportaMarcas.BindearPropiedadControl = ""
        Me.chbImportaMarcas.BindearPropiedadEntidad = ""
        Me.chbImportaMarcas.ForeColorFocus = System.Drawing.Color.Red
        Me.chbImportaMarcas.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbImportaMarcas.IsPK = False
        Me.chbImportaMarcas.IsRequired = False
        Me.chbImportaMarcas.Key = Nothing
        Me.chbImportaMarcas.LabelAsoc = Nothing
        Me.chbImportaMarcas.Location = New System.Drawing.Point(7, 8)
        Me.chbImportaMarcas.Name = "chbImportaMarcas"
        Me.chbImportaMarcas.Size = New System.Drawing.Size(222, 17)
        Me.chbImportaMarcas.TabIndex = 2
        Me.chbImportaMarcas.Text = "Importa Marca como atributo -   Id. Parent"
        Me.chbImportaMarcas.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.chbListaPrecioCLNuevo)
        Me.GroupBox1.Controls.Add(Me.cmbListaPrecioCLNuevo)
        Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(633, 166)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(265, 135)
        Me.GroupBox1.TabIndex = 72
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Clientes"
        '
        'chbListaPrecioCLNuevo
        '
        Me.chbListaPrecioCLNuevo.AutoSize = True
        Me.chbListaPrecioCLNuevo.BindearPropiedadControl = ""
        Me.chbListaPrecioCLNuevo.BindearPropiedadEntidad = ""
        Me.chbListaPrecioCLNuevo.ForeColorFocus = System.Drawing.Color.Red
        Me.chbListaPrecioCLNuevo.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbListaPrecioCLNuevo.IsPK = False
        Me.chbListaPrecioCLNuevo.IsRequired = False
        Me.chbListaPrecioCLNuevo.Key = Nothing
        Me.chbListaPrecioCLNuevo.LabelAsoc = Nothing
        Me.chbListaPrecioCLNuevo.Location = New System.Drawing.Point(9, 29)
        Me.chbListaPrecioCLNuevo.Name = "chbListaPrecioCLNuevo"
        Me.chbListaPrecioCLNuevo.Size = New System.Drawing.Size(228, 17)
        Me.chbListaPrecioCLNuevo.TabIndex = 0
        Me.chbListaPrecioCLNuevo.Text = "Asignar a Nuevos Clientes Lista de Precios"
        Me.chbListaPrecioCLNuevo.UseVisualStyleBackColor = True
        '
        'cmbListaPrecioCLNuevo
        '
        Me.cmbListaPrecioCLNuevo.BindearPropiedadControl = Nothing
        Me.cmbListaPrecioCLNuevo.BindearPropiedadEntidad = Nothing
        Me.cmbListaPrecioCLNuevo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbListaPrecioCLNuevo.Enabled = False
        Me.cmbListaPrecioCLNuevo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbListaPrecioCLNuevo.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbListaPrecioCLNuevo.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbListaPrecioCLNuevo.FormattingEnabled = True
        Me.cmbListaPrecioCLNuevo.IsPK = False
        Me.cmbListaPrecioCLNuevo.IsRequired = False
        Me.cmbListaPrecioCLNuevo.Key = Nothing
        Me.cmbListaPrecioCLNuevo.LabelAsoc = Nothing
        Me.cmbListaPrecioCLNuevo.Location = New System.Drawing.Point(9, 52)
        Me.cmbListaPrecioCLNuevo.Name = "cmbListaPrecioCLNuevo"
        Me.cmbListaPrecioCLNuevo.Size = New System.Drawing.Size(246, 21)
        Me.cmbListaPrecioCLNuevo.TabIndex = 3
        Me.cmbListaPrecioCLNuevo.Tag = "TURISMOCATEGORIARESPONSABLE"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Label1.LabelAsoc = Nothing
        Me.Label1.Location = New System.Drawing.Point(246, 13)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(58, 13)
        Me.Label1.TabIndex = 8
        Me.Label1.Text = "Pr. IVA Inc"
        '
        'chbPreciosConIvaLP1
        '
        Me.chbPreciosConIvaLP1.AutoSize = True
        Me.chbPreciosConIvaLP1.BindearPropiedadControl = Nothing
        Me.chbPreciosConIvaLP1.BindearPropiedadEntidad = Nothing
        Me.chbPreciosConIvaLP1.ForeColorFocus = System.Drawing.Color.Red
        Me.chbPreciosConIvaLP1.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbPreciosConIvaLP1.IsPK = False
        Me.chbPreciosConIvaLP1.IsRequired = False
        Me.chbPreciosConIvaLP1.Key = Nothing
        Me.chbPreciosConIvaLP1.LabelAsoc = Nothing
        Me.chbPreciosConIvaLP1.Location = New System.Drawing.Point(281, 59)
        Me.chbPreciosConIvaLP1.Name = "chbPreciosConIvaLP1"
        Me.chbPreciosConIvaLP1.Size = New System.Drawing.Size(15, 14)
        Me.chbPreciosConIvaLP1.TabIndex = 75
        Me.chbPreciosConIvaLP1.Tag = ""
        Me.chbPreciosConIvaLP1.UseVisualStyleBackColor = True
        '
        'chbPreciosConIvaLP2
        '
        Me.chbPreciosConIvaLP2.AutoSize = True
        Me.chbPreciosConIvaLP2.BindearPropiedadControl = Nothing
        Me.chbPreciosConIvaLP2.BindearPropiedadEntidad = Nothing
        Me.chbPreciosConIvaLP2.ForeColorFocus = System.Drawing.Color.Red
        Me.chbPreciosConIvaLP2.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbPreciosConIvaLP2.IsPK = False
        Me.chbPreciosConIvaLP2.IsRequired = False
        Me.chbPreciosConIvaLP2.Key = Nothing
        Me.chbPreciosConIvaLP2.LabelAsoc = Nothing
        Me.chbPreciosConIvaLP2.Location = New System.Drawing.Point(281, 83)
        Me.chbPreciosConIvaLP2.Name = "chbPreciosConIvaLP2"
        Me.chbPreciosConIvaLP2.Size = New System.Drawing.Size(15, 14)
        Me.chbPreciosConIvaLP2.TabIndex = 76
        Me.chbPreciosConIvaLP2.Tag = ""
        Me.chbPreciosConIvaLP2.UseVisualStyleBackColor = True
        '
        'chbPreciosConIvaLP3
        '
        Me.chbPreciosConIvaLP3.AutoSize = True
        Me.chbPreciosConIvaLP3.BindearPropiedadControl = Nothing
        Me.chbPreciosConIvaLP3.BindearPropiedadEntidad = Nothing
        Me.chbPreciosConIvaLP3.ForeColorFocus = System.Drawing.Color.Red
        Me.chbPreciosConIvaLP3.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbPreciosConIvaLP3.IsPK = False
        Me.chbPreciosConIvaLP3.IsRequired = False
        Me.chbPreciosConIvaLP3.Key = Nothing
        Me.chbPreciosConIvaLP3.LabelAsoc = Nothing
        Me.chbPreciosConIvaLP3.Location = New System.Drawing.Point(281, 108)
        Me.chbPreciosConIvaLP3.Name = "chbPreciosConIvaLP3"
        Me.chbPreciosConIvaLP3.Size = New System.Drawing.Size(15, 14)
        Me.chbPreciosConIvaLP3.TabIndex = 77
        Me.chbPreciosConIvaLP3.Tag = ""
        Me.chbPreciosConIvaLP3.UseVisualStyleBackColor = True
        '
        'ucConfArborea
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.gbActualizacionesTiendaNube)
        Me.Controls.Add(Me.txtArboreaExportarSolicitudesSubidaPath)
        Me.Controls.Add(Me.chbArboreaExportarSolicitudesSubida)
        Me.Controls.Add(Me.txtArboreaURLListaPreciosClientes)
        Me.Controls.Add(Me.lblArboreaURLListaPreciosClientes)
        Me.Controls.Add(Me.txtArboreaURLListaPrecios)
        Me.Controls.Add(Me.lblArboreaURLListaPrecios)
        Me.Controls.Add(Me.gbListadPreciosArborea)
        Me.Controls.Add(Me.cmbArboreaCategoriaFiscalCliente)
        Me.Controls.Add(Me.txtArboreaCategoriaPrincipal)
        Me.Controls.Add(Me.lblArboreaCategoriaPrincipal)
        Me.Controls.Add(Me.txtArboreaClaveToken)
        Me.Controls.Add(Me.txtArboreaUsuarioToken)
        Me.Controls.Add(Me.txtArboreaURLBase)
        Me.Controls.Add(Me.lblArboreaURLBase)
        Me.Controls.Add(Me.lblArboreaClaveToken)
        Me.Controls.Add(Me.txtArboreaCorreoNotificaciones)
        Me.Controls.Add(Me.lblArboreaUsuarioToken)
        Me.Controls.Add(Me.lblArboreaCorreoNotificaciones)
        Me.Controls.Add(Me.lblArboreaCategoriaCliente)
        Me.Controls.Add(Me.gbPedidosArborea)
        Me.Controls.Add(Me.lblArboreaCategoriaFiscalCliente)
        Me.Controls.Add(Me.cmbArboreaVendedor)
        Me.Controls.Add(Me.lblArboreaVendedor)
        Me.Controls.Add(Me.cmbArboreaCategoriaCliente)
        Me.Name = "ucConfArborea"
        Me.Size = New System.Drawing.Size(905, 423)
        Me.Controls.SetChildIndex(Me.cmbArboreaCategoriaCliente, 0)
        Me.Controls.SetChildIndex(Me.lblArboreaVendedor, 0)
        Me.Controls.SetChildIndex(Me.cmbArboreaVendedor, 0)
        Me.Controls.SetChildIndex(Me.lblArboreaCategoriaFiscalCliente, 0)
        Me.Controls.SetChildIndex(Me.gbPedidosArborea, 0)
        Me.Controls.SetChildIndex(Me.lblArboreaCategoriaCliente, 0)
        Me.Controls.SetChildIndex(Me.lblArboreaCorreoNotificaciones, 0)
        Me.Controls.SetChildIndex(Me.lblArboreaUsuarioToken, 0)
        Me.Controls.SetChildIndex(Me.txtArboreaCorreoNotificaciones, 0)
        Me.Controls.SetChildIndex(Me.lblArboreaClaveToken, 0)
        Me.Controls.SetChildIndex(Me.lblArboreaURLBase, 0)
        Me.Controls.SetChildIndex(Me.txtArboreaURLBase, 0)
        Me.Controls.SetChildIndex(Me.txtArboreaUsuarioToken, 0)
        Me.Controls.SetChildIndex(Me.txtArboreaClaveToken, 0)
        Me.Controls.SetChildIndex(Me.lblArboreaCategoriaPrincipal, 0)
        Me.Controls.SetChildIndex(Me.txtArboreaCategoriaPrincipal, 0)
        Me.Controls.SetChildIndex(Me.cmbArboreaCategoriaFiscalCliente, 0)
        Me.Controls.SetChildIndex(Me.gbListadPreciosArborea, 0)
        Me.Controls.SetChildIndex(Me.lblArboreaURLListaPrecios, 0)
        Me.Controls.SetChildIndex(Me.txtArboreaURLListaPrecios, 0)
        Me.Controls.SetChildIndex(Me.lblArboreaURLListaPreciosClientes, 0)
        Me.Controls.SetChildIndex(Me.txtArboreaURLListaPreciosClientes, 0)
        Me.Controls.SetChildIndex(Me.chbArboreaExportarSolicitudesSubida, 0)
        Me.Controls.SetChildIndex(Me.txtArboreaExportarSolicitudesSubidaPath, 0)
        Me.Controls.SetChildIndex(Me.gbActualizacionesTiendaNube, 0)
        Me.Controls.SetChildIndex(Me.GroupBox1, 0)
        Me.gbPedidosArborea.ResumeLayout(False)
        Me.gbPedidosArborea.PerformLayout()
        Me.gbListadPreciosArborea.ResumeLayout(False)
        Me.gbListadPreciosArborea.PerformLayout()
        Me.gbActualizacionesTiendaNube.ResumeLayout(False)
        Me.TabControl1.ResumeLayout(False)
        Me.tpgProducto.ResumeLayout(False)
        Me.tpgProducto.PerformLayout()
        Me.tpgCategorias.ResumeLayout(False)
        Me.tpgCategorias.PerformLayout()
        Me.tpgAtributos.ResumeLayout(False)
        Me.tpgAtributos.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents txtArboreaURLBase As Controles.TextBox
   Friend WithEvents lblArboreaURLBase As Controles.Label
   Friend WithEvents lblArboreaClaveToken As Controles.Label
   Friend WithEvents lblArboreaUsuarioToken As Controles.Label
   Friend WithEvents lblArboreaCategoriaCliente As Controles.Label
   Friend WithEvents lblArboreaCategoriaFiscalCliente As Controles.Label
   Friend WithEvents lblArboreaVendedor As Controles.Label
   Friend WithEvents cmbArboreaCategoriaCliente As Controles.ComboBox
    Friend WithEvents cmbArboreaVendedor As Controles.ComboBox
    Friend WithEvents lblArboreaProductoEnvio As Controles.Label
    Friend WithEvents txtArboreaProductoEnvio As Controles.TextBox
    Friend WithEvents lblArboreaPedidosFormaDePago As Controles.Label
    Friend WithEvents cmbArboreaPedidosFormaDePago As Controles.ComboBox
    Friend WithEvents lblArboreaPedidosCriticidad As Controles.Label
    Friend WithEvents cmbArboreaPedidosCriticidad As Controles.ComboBox
    Friend WithEvents cmbArboreaPedidosTipoComprobante As Controles.ComboBox
    Friend WithEvents lblArboreaPedidosTipoComprobante As Controles.Label
    Friend WithEvents gbPedidosArborea As GroupBox
    Friend WithEvents lblArboreaCorreoNotificaciones As Controles.Label
    Friend WithEvents txtArboreaCorreoNotificaciones As Controles.TextBox
    Friend WithEvents txtArboreaUsuarioToken As Controles.TextBox
    Friend WithEvents txtArboreaClaveToken As Controles.TextBox
    Friend WithEvents txtArboreaCategoriaPrincipal As Controles.TextBox
    Friend WithEvents lblArboreaCategoriaPrincipal As Controles.Label
    Friend WithEvents cmbArboreaCategoriaFiscalCliente As Controles.ComboBox
    Friend WithEvents gbListadPreciosArborea As GroupBox
    Friend WithEvents cmbListaPrecio04 As Controles.ComboBox
    Friend WithEvents cmbListaPrecio03 As Controles.ComboBox
    Friend WithEvents cmbListaPrecio02 As Controles.ComboBox
    Friend WithEvents cmbListaPrecio01 As Controles.ComboBox
    Friend WithEvents txtArboreaURLListaPrecios As Controles.TextBox
    Friend WithEvents lblArboreaURLListaPrecios As Controles.Label
    Friend WithEvents chbListaPrecio01 As Controles.CheckBox
    Friend WithEvents chbListaPrecio04 As Controles.CheckBox
    Friend WithEvents chbListaPrecio03 As Controles.CheckBox
    Friend WithEvents chbListaPrecio02 As Controles.CheckBox
    Friend WithEvents txtArboreaURLListaPreciosClientes As Controles.TextBox
    Friend WithEvents lblArboreaURLListaPreciosClientes As Controles.Label
    Friend WithEvents chbArboreaExportarSolicitudesSubida As Controles.CheckBox
    Friend WithEvents txtArboreaExportarSolicitudesSubidaPath As Controles.TextBox
    Friend WithEvents gbActualizacionesTiendaNube As GroupBox
    Friend WithEvents TabControl1 As TabControl
    Friend WithEvents tpgProducto As TabPage
    Friend WithEvents lblActualizaCategorias As Controles.Label
    Friend WithEvents cmbActualizaCategorias As Controles.ComboBox
    Friend WithEvents lblPrecioProducto As Controles.Label
    Friend WithEvents cmbPrecioProducto As Controles.ComboBox
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents chbListaPrecioCLNuevo As Controles.CheckBox
    Friend WithEvents cmbListaPrecioCLNuevo As Controles.ComboBox
    Friend WithEvents tpgCategorias As TabPage
    Friend WithEvents chbArboreaSincronizaCategorias As Controles.CheckBox
    Friend WithEvents tpgAtributos As TabPage
    Friend WithEvents txtImportaMarcas As Controles.TextBox
    Friend WithEvents chbImportaMarcas As Controles.CheckBox
    Friend WithEvents chbProductoPrecioEmbalaje As Controles.CheckBox
    Friend WithEvents chbPreciosConIvaPV As Controles.CheckBox
    Friend WithEvents Label1 As Controles.Label
    Friend WithEvents chbPreciosConIvaLP3 As Controles.CheckBox
    Friend WithEvents chbPreciosConIvaLP2 As Controles.CheckBox
    Friend WithEvents chbPreciosConIvaLP1 As Controles.CheckBox
End Class
