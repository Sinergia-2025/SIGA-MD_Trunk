<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ucConfPedidosProvPedidosProv
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
      Me.chbPedidosProveedoresConservaOrdenProductos = New Eniac.Controles.CheckBox()
      Me.GroupBox11 = New System.Windows.Forms.GroupBox()
      Me.cmbEstadoPedidoProvPostVinculacion = New Eniac.Controles.ComboBox()
      Me.lblEstadoPedidoProvPostVinculacion = New Eniac.Controles.Label()
      Me.cmbEstadoPedidoPostVinculacion = New Eniac.Controles.ComboBox()
      Me.lblEstadoPedidoPostVinculacion = New Eniac.Controles.Label()
      Me.cmbEstadoPedidoProvPreVinculacion = New Eniac.Controles.ComboBox()
      Me.lblEstadoPedidoProvPreVinculacion = New Eniac.Controles.Label()
      Me.cmbEstadoPedidoPreVinculacion = New Eniac.Controles.ComboBox()
      Me.lblEstadoPedidoPreVinculacion = New Eniac.Controles.Label()
      Me.chbPedidosProvPendientesFacturarAutomatico = New Eniac.Controles.CheckBox()
      Me.chbGeneraPedidoProvModificaPrecioCosto = New Eniac.Controles.CheckBox()
      Me.chbPedidoProvSinPrecio = New Eniac.Controles.CheckBox()
      Me.grpEstadoPedidoProveedor = New System.Windows.Forms.GroupBox()
      Me.cmbPedidoProveedorEstadoNuevo = New Eniac.Controles.ComboBox()
      Me.lblPedidoProveedorEstadoNuevo = New Eniac.Controles.Label()
        Me.lblPedidoProveedorEstadoAFacturar = New Eniac.Controles.Label()
        Me.cmbPedidoProveedorEstadoAnulado = New Eniac.Controles.ComboBox()
        Me.lblPedidoProveedorEstadoAnulado = New Eniac.Controles.Label()
        Me.lblPedidoProveedorEstadoFacturado = New Eniac.Controles.Label()
        Me.chbGenerarPedidosStockSeleccionaTrue = New Eniac.Controles.CheckBox()
        Me.chbImpresionMuestraCodigoProveedor = New Eniac.Controles.CheckBox()
        Me.Label1 = New Eniac.Controles.Label()
        Me.GroupBox11.SuspendLayout()
        Me.grpEstadoPedidoProveedor.SuspendLayout()
        Me.SuspendLayout()
        '
        'chbPedidosProveedoresConservaOrdenProductos
        '
        Me.chbPedidosProveedoresConservaOrdenProductos.AutoSize = True
        Me.chbPedidosProveedoresConservaOrdenProductos.BindearPropiedadControl = Nothing
        Me.chbPedidosProveedoresConservaOrdenProductos.BindearPropiedadEntidad = Nothing
        Me.chbPedidosProveedoresConservaOrdenProductos.ForeColorFocus = System.Drawing.Color.Red
        Me.chbPedidosProveedoresConservaOrdenProductos.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbPedidosProveedoresConservaOrdenProductos.IsPK = False
        Me.chbPedidosProveedoresConservaOrdenProductos.IsRequired = False
        Me.chbPedidosProveedoresConservaOrdenProductos.Key = Nothing
        Me.chbPedidosProveedoresConservaOrdenProductos.LabelAsoc = Nothing
        Me.chbPedidosProveedoresConservaOrdenProductos.Location = New System.Drawing.Point(31, 317)
        Me.chbPedidosProveedoresConservaOrdenProductos.Name = "chbPedidosProveedoresConservaOrdenProductos"
        Me.chbPedidosProveedoresConservaOrdenProductos.Size = New System.Drawing.Size(237, 17)
        Me.chbPedidosProveedoresConservaOrdenProductos.TabIndex = 6
        Me.chbPedidosProveedoresConservaOrdenProductos.Text = "Conserva Orden de los Productos en la Grilla"
        Me.chbPedidosProveedoresConservaOrdenProductos.UseVisualStyleBackColor = True
        '
        'GroupBox11
        '
        Me.GroupBox11.Controls.Add(Me.cmbEstadoPedidoProvPostVinculacion)
        Me.GroupBox11.Controls.Add(Me.cmbEstadoPedidoPostVinculacion)
        Me.GroupBox11.Controls.Add(Me.lblEstadoPedidoProvPostVinculacion)
        Me.GroupBox11.Controls.Add(Me.lblEstadoPedidoPostVinculacion)
        Me.GroupBox11.Controls.Add(Me.cmbEstadoPedidoProvPreVinculacion)
        Me.GroupBox11.Controls.Add(Me.lblEstadoPedidoProvPreVinculacion)
        Me.GroupBox11.Controls.Add(Me.cmbEstadoPedidoPreVinculacion)
        Me.GroupBox11.Controls.Add(Me.lblEstadoPedidoPreVinculacion)
        Me.GroupBox11.Location = New System.Drawing.Point(445, 41)
        Me.GroupBox11.Name = "GroupBox11"
        Me.GroupBox11.Size = New System.Drawing.Size(397, 138)
        Me.GroupBox11.TabIndex = 7
        Me.GroupBox11.TabStop = False
        Me.GroupBox11.Text = "Vinculación de Pedidos"
        '
        'cmbEstadoPedidoProvPostVinculacion
        '
        Me.cmbEstadoPedidoProvPostVinculacion.BindearPropiedadControl = Nothing
        Me.cmbEstadoPedidoProvPostVinculacion.BindearPropiedadEntidad = Nothing
        Me.cmbEstadoPedidoProvPostVinculacion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbEstadoPedidoProvPostVinculacion.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbEstadoPedidoProvPostVinculacion.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbEstadoPedidoProvPostVinculacion.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbEstadoPedidoProvPostVinculacion.FormattingEnabled = True
        Me.cmbEstadoPedidoProvPostVinculacion.IsPK = False
        Me.cmbEstadoPedidoProvPostVinculacion.IsRequired = False
        Me.cmbEstadoPedidoProvPostVinculacion.Key = Nothing
        Me.cmbEstadoPedidoProvPostVinculacion.LabelAsoc = Me.lblEstadoPedidoProvPostVinculacion
        Me.cmbEstadoPedidoProvPostVinculacion.Location = New System.Drawing.Point(269, 105)
        Me.cmbEstadoPedidoProvPostVinculacion.Name = "cmbEstadoPedidoProvPostVinculacion"
        Me.cmbEstadoPedidoProvPostVinculacion.Size = New System.Drawing.Size(122, 21)
        Me.cmbEstadoPedidoProvPostVinculacion.TabIndex = 7
        Me.cmbEstadoPedidoProvPostVinculacion.Tag = "PEDIDOSESTADOAREMITIR"
        '
        'lblEstadoPedidoProvPostVinculacion
        '
        Me.lblEstadoPedidoProvPostVinculacion.AutoSize = True
        Me.lblEstadoPedidoProvPostVinculacion.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblEstadoPedidoProvPostVinculacion.LabelAsoc = Nothing
        Me.lblEstadoPedidoProvPostVinculacion.Location = New System.Drawing.Point(12, 110)
        Me.lblEstadoPedidoProvPostVinculacion.Name = "lblEstadoPedidoProvPostVinculacion"
        Me.lblEstadoPedidoProvPostVinculacion.Size = New System.Drawing.Size(251, 13)
        Me.lblEstadoPedidoProvPostVinculacion.TabIndex = 6
        Me.lblEstadoPedidoProvPostVinculacion.Text = "Estado del Pedido de Proveedores post vinculación"
        '
        'cmbEstadoPedidoPostVinculacion
        '
        Me.cmbEstadoPedidoPostVinculacion.BindearPropiedadControl = Nothing
        Me.cmbEstadoPedidoPostVinculacion.BindearPropiedadEntidad = Nothing
        Me.cmbEstadoPedidoPostVinculacion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbEstadoPedidoPostVinculacion.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbEstadoPedidoPostVinculacion.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbEstadoPedidoPostVinculacion.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbEstadoPedidoPostVinculacion.FormattingEnabled = True
        Me.cmbEstadoPedidoPostVinculacion.IsPK = False
        Me.cmbEstadoPedidoPostVinculacion.IsRequired = False
        Me.cmbEstadoPedidoPostVinculacion.Key = Nothing
        Me.cmbEstadoPedidoPostVinculacion.LabelAsoc = Me.lblEstadoPedidoPostVinculacion
        Me.cmbEstadoPedidoPostVinculacion.Location = New System.Drawing.Point(269, 51)
        Me.cmbEstadoPedidoPostVinculacion.Name = "cmbEstadoPedidoPostVinculacion"
        Me.cmbEstadoPedidoPostVinculacion.Size = New System.Drawing.Size(122, 21)
        Me.cmbEstadoPedidoPostVinculacion.TabIndex = 3
        Me.cmbEstadoPedidoPostVinculacion.Tag = "PEDIDOSESTADOAREMITIR"
        '
        'lblEstadoPedidoPostVinculacion
        '
        Me.lblEstadoPedidoPostVinculacion.AutoSize = True
        Me.lblEstadoPedidoPostVinculacion.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblEstadoPedidoPostVinculacion.LabelAsoc = Nothing
        Me.lblEstadoPedidoPostVinculacion.Location = New System.Drawing.Point(12, 56)
        Me.lblEstadoPedidoPostVinculacion.Name = "lblEstadoPedidoPostVinculacion"
        Me.lblEstadoPedidoPostVinculacion.Size = New System.Drawing.Size(223, 13)
        Me.lblEstadoPedidoPostVinculacion.TabIndex = 2
        Me.lblEstadoPedidoPostVinculacion.Text = "Estado del Pedido de Cliente post vinculación"
        '
        'cmbEstadoPedidoProvPreVinculacion
        '
        Me.cmbEstadoPedidoProvPreVinculacion.BindearPropiedadControl = Nothing
        Me.cmbEstadoPedidoProvPreVinculacion.BindearPropiedadEntidad = Nothing
        Me.cmbEstadoPedidoProvPreVinculacion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbEstadoPedidoProvPreVinculacion.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbEstadoPedidoProvPreVinculacion.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbEstadoPedidoProvPreVinculacion.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbEstadoPedidoProvPreVinculacion.FormattingEnabled = True
        Me.cmbEstadoPedidoProvPreVinculacion.IsPK = False
        Me.cmbEstadoPedidoProvPreVinculacion.IsRequired = False
        Me.cmbEstadoPedidoProvPreVinculacion.Key = Nothing
        Me.cmbEstadoPedidoProvPreVinculacion.LabelAsoc = Me.lblEstadoPedidoProvPreVinculacion
        Me.cmbEstadoPedidoProvPreVinculacion.Location = New System.Drawing.Point(269, 78)
        Me.cmbEstadoPedidoProvPreVinculacion.Name = "cmbEstadoPedidoProvPreVinculacion"
        Me.cmbEstadoPedidoProvPreVinculacion.Size = New System.Drawing.Size(122, 21)
        Me.cmbEstadoPedidoProvPreVinculacion.TabIndex = 5
        Me.cmbEstadoPedidoProvPreVinculacion.Tag = "PEDIDOSESTADOAREMITIR"
        '
        'lblEstadoPedidoProvPreVinculacion
        '
        Me.lblEstadoPedidoProvPreVinculacion.AutoSize = True
        Me.lblEstadoPedidoProvPreVinculacion.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblEstadoPedidoProvPreVinculacion.LabelAsoc = Nothing
        Me.lblEstadoPedidoProvPreVinculacion.Location = New System.Drawing.Point(12, 83)
        Me.lblEstadoPedidoProvPreVinculacion.Name = "lblEstadoPedidoProvPreVinculacion"
        Me.lblEstadoPedidoProvPreVinculacion.Size = New System.Drawing.Size(246, 13)
        Me.lblEstadoPedidoProvPreVinculacion.TabIndex = 4
        Me.lblEstadoPedidoProvPreVinculacion.Text = "Estado del Pedido de Proveedores pre vinculación"
        '
        'cmbEstadoPedidoPreVinculacion
        '
        Me.cmbEstadoPedidoPreVinculacion.BindearPropiedadControl = Nothing
        Me.cmbEstadoPedidoPreVinculacion.BindearPropiedadEntidad = Nothing
        Me.cmbEstadoPedidoPreVinculacion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbEstadoPedidoPreVinculacion.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbEstadoPedidoPreVinculacion.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbEstadoPedidoPreVinculacion.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbEstadoPedidoPreVinculacion.FormattingEnabled = True
        Me.cmbEstadoPedidoPreVinculacion.IsPK = False
        Me.cmbEstadoPedidoPreVinculacion.IsRequired = False
        Me.cmbEstadoPedidoPreVinculacion.Key = Nothing
        Me.cmbEstadoPedidoPreVinculacion.LabelAsoc = Me.lblEstadoPedidoPreVinculacion
        Me.cmbEstadoPedidoPreVinculacion.Location = New System.Drawing.Point(269, 24)
        Me.cmbEstadoPedidoPreVinculacion.Name = "cmbEstadoPedidoPreVinculacion"
        Me.cmbEstadoPedidoPreVinculacion.Size = New System.Drawing.Size(122, 21)
        Me.cmbEstadoPedidoPreVinculacion.TabIndex = 1
        Me.cmbEstadoPedidoPreVinculacion.Tag = "PEDIDOSESTADOAREMITIR"
        '
        'lblEstadoPedidoPreVinculacion
        '
        Me.lblEstadoPedidoPreVinculacion.AutoSize = True
        Me.lblEstadoPedidoPreVinculacion.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblEstadoPedidoPreVinculacion.LabelAsoc = Nothing
        Me.lblEstadoPedidoPreVinculacion.Location = New System.Drawing.Point(12, 29)
        Me.lblEstadoPedidoPreVinculacion.Name = "lblEstadoPedidoPreVinculacion"
        Me.lblEstadoPedidoPreVinculacion.Size = New System.Drawing.Size(218, 13)
        Me.lblEstadoPedidoPreVinculacion.TabIndex = 0
        Me.lblEstadoPedidoPreVinculacion.Text = "Estado del Pedido de Cliente pre vinculación"
        '
        'chbPedidosProvPendientesFacturarAutomatico
        '
        Me.chbPedidosProvPendientesFacturarAutomatico.AutoSize = True
        Me.chbPedidosProvPendientesFacturarAutomatico.BindearPropiedadControl = Nothing
        Me.chbPedidosProvPendientesFacturarAutomatico.BindearPropiedadEntidad = Nothing
        Me.chbPedidosProvPendientesFacturarAutomatico.ForeColorFocus = System.Drawing.Color.Red
        Me.chbPedidosProvPendientesFacturarAutomatico.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbPedidosProvPendientesFacturarAutomatico.IsPK = False
        Me.chbPedidosProvPendientesFacturarAutomatico.IsRequired = False
        Me.chbPedidosProvPendientesFacturarAutomatico.Key = Nothing
        Me.chbPedidosProvPendientesFacturarAutomatico.LabelAsoc = Nothing
        Me.chbPedidosProvPendientesFacturarAutomatico.Location = New System.Drawing.Point(31, 37)
        Me.chbPedidosProvPendientesFacturarAutomatico.Name = "chbPedidosProvPendientesFacturarAutomatico"
        Me.chbPedidosProvPendientesFacturarAutomatico.Size = New System.Drawing.Size(264, 17)
        Me.chbPedidosProvPendientesFacturarAutomatico.TabIndex = 0
        Me.chbPedidosProvPendientesFacturarAutomatico.Tag = "PEDIDOSPROVFACTURARAUTOMATICO"
        Me.chbPedidosProvPendientesFacturarAutomatico.Text = "Pedidos Pendientes: Facturados Autómaticamente"
        Me.chbPedidosProvPendientesFacturarAutomatico.UseVisualStyleBackColor = True
        '
        'chbGeneraPedidoProvModificaPrecioCosto
        '
        Me.chbGeneraPedidoProvModificaPrecioCosto.BindearPropiedadControl = Nothing
        Me.chbGeneraPedidoProvModificaPrecioCosto.BindearPropiedadEntidad = Nothing
        Me.chbGeneraPedidoProvModificaPrecioCosto.ForeColorFocus = System.Drawing.Color.Red
        Me.chbGeneraPedidoProvModificaPrecioCosto.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbGeneraPedidoProvModificaPrecioCosto.IsPK = False
        Me.chbGeneraPedidoProvModificaPrecioCosto.IsRequired = False
        Me.chbGeneraPedidoProvModificaPrecioCosto.Key = Nothing
        Me.chbGeneraPedidoProvModificaPrecioCosto.LabelAsoc = Nothing
        Me.chbGeneraPedidoProvModificaPrecioCosto.Location = New System.Drawing.Point(31, 287)
        Me.chbGeneraPedidoProvModificaPrecioCosto.Name = "chbGeneraPedidoProvModificaPrecioCosto"
        Me.chbGeneraPedidoProvModificaPrecioCosto.Size = New System.Drawing.Size(356, 24)
        Me.chbGeneraPedidoProvModificaPrecioCosto.TabIndex = 5
        Me.chbGeneraPedidoProvModificaPrecioCosto.Tag = ""
        Me.chbGeneraPedidoProvModificaPrecioCosto.Text = "Generar Pedido a Proveedor desde Stock - Modifica Precio de Costo"
        Me.chbGeneraPedidoProvModificaPrecioCosto.UseVisualStyleBackColor = True
        '
        'chbPedidoProvSinPrecio
        '
        Me.chbPedidoProvSinPrecio.AutoSize = True
        Me.chbPedidoProvSinPrecio.BindearPropiedadControl = Nothing
        Me.chbPedidoProvSinPrecio.BindearPropiedadEntidad = Nothing
        Me.chbPedidoProvSinPrecio.ForeColorFocus = System.Drawing.Color.Red
        Me.chbPedidoProvSinPrecio.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbPedidoProvSinPrecio.IsPK = False
        Me.chbPedidoProvSinPrecio.IsRequired = False
        Me.chbPedidoProvSinPrecio.Key = Nothing
        Me.chbPedidoProvSinPrecio.LabelAsoc = Nothing
        Me.chbPedidoProvSinPrecio.Location = New System.Drawing.Point(31, 60)
        Me.chbPedidoProvSinPrecio.Name = "chbPedidoProvSinPrecio"
        Me.chbPedidoProvSinPrecio.Size = New System.Drawing.Size(190, 17)
        Me.chbPedidoProvSinPrecio.TabIndex = 1
        Me.chbPedidoProvSinPrecio.Tag = "PEDIDOSPROVCONPRODUCTOSENCERO"
        Me.chbPedidoProvSinPrecio.Text = "Puede Ingresar Pedidos Sin Precio"
        Me.chbPedidoProvSinPrecio.UseVisualStyleBackColor = True
        '
        'grpEstadoPedidoProveedor
        '
        Me.grpEstadoPedidoProveedor.Controls.Add(Me.cmbPedidoProveedorEstadoNuevo)
        Me.grpEstadoPedidoProveedor.Controls.Add(Me.lblPedidoProveedorEstadoNuevo)
        Me.grpEstadoPedidoProveedor.Controls.Add(Me.cmbPedidoProveedorEstadoAnulado)
        Me.grpEstadoPedidoProveedor.Controls.Add(Me.lblPedidoProveedorEstadoAnulado)
        Me.grpEstadoPedidoProveedor.Controls.Add(Me.Label1)
        Me.grpEstadoPedidoProveedor.Controls.Add(Me.lblPedidoProveedorEstadoAFacturar)
        Me.grpEstadoPedidoProveedor.Controls.Add(Me.lblPedidoProveedorEstadoFacturado)
        Me.grpEstadoPedidoProveedor.Location = New System.Drawing.Point(31, 139)
        Me.grpEstadoPedidoProveedor.Name = "grpEstadoPedidoProveedor"
        Me.grpEstadoPedidoProveedor.Size = New System.Drawing.Size(262, 132)
        Me.grpEstadoPedidoProveedor.TabIndex = 4
        Me.grpEstadoPedidoProveedor.TabStop = False
        Me.grpEstadoPedidoProveedor.Text = "Estados de Pedido..."
        '
        'cmbPedidoProveedorEstadoNuevo
        '
        Me.cmbPedidoProveedorEstadoNuevo.BindearPropiedadControl = Nothing
        Me.cmbPedidoProveedorEstadoNuevo.BindearPropiedadEntidad = Nothing
        Me.cmbPedidoProveedorEstadoNuevo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbPedidoProveedorEstadoNuevo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbPedidoProveedorEstadoNuevo.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbPedidoProveedorEstadoNuevo.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbPedidoProveedorEstadoNuevo.FormattingEnabled = True
        Me.cmbPedidoProveedorEstadoNuevo.IsPK = False
        Me.cmbPedidoProveedorEstadoNuevo.IsRequired = False
        Me.cmbPedidoProveedorEstadoNuevo.Key = Nothing
        Me.cmbPedidoProveedorEstadoNuevo.LabelAsoc = Me.lblPedidoProveedorEstadoNuevo
        Me.cmbPedidoProveedorEstadoNuevo.Location = New System.Drawing.Point(111, 19)
        Me.cmbPedidoProveedorEstadoNuevo.Name = "cmbPedidoProveedorEstadoNuevo"
        Me.cmbPedidoProveedorEstadoNuevo.Size = New System.Drawing.Size(122, 21)
        Me.cmbPedidoProveedorEstadoNuevo.TabIndex = 1
        Me.cmbPedidoProveedorEstadoNuevo.Tag = ""
        '
        'lblPedidoProveedorEstadoNuevo
        '
        Me.lblPedidoProveedorEstadoNuevo.AutoSize = True
        Me.lblPedidoProveedorEstadoNuevo.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblPedidoProveedorEstadoNuevo.LabelAsoc = Nothing
        Me.lblPedidoProveedorEstadoNuevo.Location = New System.Drawing.Point(18, 22)
        Me.lblPedidoProveedorEstadoNuevo.Name = "lblPedidoProveedorEstadoNuevo"
        Me.lblPedidoProveedorEstadoNuevo.Size = New System.Drawing.Size(42, 13)
        Me.lblPedidoProveedorEstadoNuevo.TabIndex = 0
        Me.lblPedidoProveedorEstadoNuevo.Text = "Nuevo:"
        '
        'lblPedidoProveedorEstadoAFacturar
        '
        Me.lblPedidoProveedorEstadoAFacturar.AutoSize = True
        Me.lblPedidoProveedorEstadoAFacturar.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblPedidoProveedorEstadoAFacturar.LabelAsoc = Nothing
        Me.lblPedidoProveedorEstadoAFacturar.Location = New System.Drawing.Point(18, 49)
        Me.lblPedidoProveedorEstadoAFacturar.Name = "lblPedidoProveedorEstadoAFacturar"
        Me.lblPedidoProveedorEstadoAFacturar.Size = New System.Drawing.Size(81, 13)
        Me.lblPedidoProveedorEstadoAFacturar.TabIndex = 2
        Me.lblPedidoProveedorEstadoAFacturar.Text = "que se Factura:"
        '
        'cmbPedidoProveedorEstadoAnulado
        '
        Me.cmbPedidoProveedorEstadoAnulado.BindearPropiedadControl = Nothing
        Me.cmbPedidoProveedorEstadoAnulado.BindearPropiedadEntidad = Nothing
        Me.cmbPedidoProveedorEstadoAnulado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbPedidoProveedorEstadoAnulado.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbPedidoProveedorEstadoAnulado.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbPedidoProveedorEstadoAnulado.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbPedidoProveedorEstadoAnulado.FormattingEnabled = True
        Me.cmbPedidoProveedorEstadoAnulado.IsPK = False
        Me.cmbPedidoProveedorEstadoAnulado.IsRequired = False
        Me.cmbPedidoProveedorEstadoAnulado.Key = Nothing
        Me.cmbPedidoProveedorEstadoAnulado.LabelAsoc = Me.lblPedidoProveedorEstadoAnulado
        Me.cmbPedidoProveedorEstadoAnulado.Location = New System.Drawing.Point(111, 100)
        Me.cmbPedidoProveedorEstadoAnulado.Name = "cmbPedidoProveedorEstadoAnulado"
        Me.cmbPedidoProveedorEstadoAnulado.Size = New System.Drawing.Size(122, 21)
        Me.cmbPedidoProveedorEstadoAnulado.TabIndex = 7
        Me.cmbPedidoProveedorEstadoAnulado.Tag = "PEDIDOSESTADOAREMITIR"
        '
        'lblPedidoProveedorEstadoAnulado
        '
        Me.lblPedidoProveedorEstadoAnulado.AutoSize = True
        Me.lblPedidoProveedorEstadoAnulado.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblPedidoProveedorEstadoAnulado.LabelAsoc = Nothing
        Me.lblPedidoProveedorEstadoAnulado.Location = New System.Drawing.Point(18, 103)
        Me.lblPedidoProveedorEstadoAnulado.Name = "lblPedidoProveedorEstadoAnulado"
        Me.lblPedidoProveedorEstadoAnulado.Size = New System.Drawing.Size(49, 13)
        Me.lblPedidoProveedorEstadoAnulado.TabIndex = 6
        Me.lblPedidoProveedorEstadoAnulado.Text = "Anulado:"
        '
        'lblPedidoProveedorEstadoFacturado
        '
        Me.lblPedidoProveedorEstadoFacturado.AutoSize = True
        Me.lblPedidoProveedorEstadoFacturado.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblPedidoProveedorEstadoFacturado.LabelAsoc = Nothing
        Me.lblPedidoProveedorEstadoFacturado.Location = New System.Drawing.Point(18, 76)
        Me.lblPedidoProveedorEstadoFacturado.Name = "lblPedidoProveedorEstadoFacturado"
        Me.lblPedidoProveedorEstadoFacturado.Size = New System.Drawing.Size(90, 13)
        Me.lblPedidoProveedorEstadoFacturado.TabIndex = 4
        Me.lblPedidoProveedorEstadoFacturado.Text = "luego de Factura:"
        '
        'chbGenerarPedidosStockSeleccionaTrue
        '
        Me.chbGenerarPedidosStockSeleccionaTrue.AutoSize = True
        Me.chbGenerarPedidosStockSeleccionaTrue.BindearPropiedadControl = Nothing
        Me.chbGenerarPedidosStockSeleccionaTrue.BindearPropiedadEntidad = Nothing
        Me.chbGenerarPedidosStockSeleccionaTrue.ForeColorFocus = System.Drawing.Color.Red
        Me.chbGenerarPedidosStockSeleccionaTrue.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbGenerarPedidosStockSeleccionaTrue.IsPK = False
        Me.chbGenerarPedidosStockSeleccionaTrue.IsRequired = False
        Me.chbGenerarPedidosStockSeleccionaTrue.Key = Nothing
        Me.chbGenerarPedidosStockSeleccionaTrue.LabelAsoc = Nothing
        Me.chbGenerarPedidosStockSeleccionaTrue.Location = New System.Drawing.Point(31, 83)
        Me.chbGenerarPedidosStockSeleccionaTrue.Name = "chbGenerarPedidosStockSeleccionaTrue"
        Me.chbGenerarPedidosStockSeleccionaTrue.Size = New System.Drawing.Size(262, 17)
        Me.chbGenerarPedidosStockSeleccionaTrue.TabIndex = 2
        Me.chbGenerarPedidosStockSeleccionaTrue.Text = "Generar Pedidos de Stock selecciona al consultar"
        Me.chbGenerarPedidosStockSeleccionaTrue.UseVisualStyleBackColor = True
        '
        'chbImpresionMuestraCodigoProveedor
        '
        Me.chbImpresionMuestraCodigoProveedor.BindearPropiedadControl = Nothing
        Me.chbImpresionMuestraCodigoProveedor.BindearPropiedadEntidad = Nothing
        Me.chbImpresionMuestraCodigoProveedor.ForeColorFocus = System.Drawing.Color.Red
        Me.chbImpresionMuestraCodigoProveedor.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbImpresionMuestraCodigoProveedor.IsPK = False
        Me.chbImpresionMuestraCodigoProveedor.IsRequired = False
        Me.chbImpresionMuestraCodigoProveedor.Key = Nothing
        Me.chbImpresionMuestraCodigoProveedor.LabelAsoc = Nothing
        Me.chbImpresionMuestraCodigoProveedor.Location = New System.Drawing.Point(31, 106)
        Me.chbImpresionMuestraCodigoProveedor.Name = "chbImpresionMuestraCodigoProveedor"
        Me.chbImpresionMuestraCodigoProveedor.Size = New System.Drawing.Size(265, 24)
        Me.chbImpresionMuestraCodigoProveedor.TabIndex = 3
        Me.chbImpresionMuestraCodigoProveedor.Tag = "PEDIDOSPROVIMPRESIONMUESTRACODIGOPROV"
        Me.chbImpresionMuestraCodigoProveedor.Text = "Impresión muestra codigo del Proveedor"
        Me.chbImpresionMuestraCodigoProveedor.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label1.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Label1.LabelAsoc = Nothing
        Me.Label1.Location = New System.Drawing.Point(111, 49)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(122, 45)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Estos estados ahora se configuran en el ABM de estados"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'ucConfPedidosProvPedidosProv
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.chbPedidosProveedoresConservaOrdenProductos)
        Me.Controls.Add(Me.GroupBox11)
        Me.Controls.Add(Me.chbPedidosProvPendientesFacturarAutomatico)
        Me.Controls.Add(Me.chbGeneraPedidoProvModificaPrecioCosto)
        Me.Controls.Add(Me.chbPedidoProvSinPrecio)
        Me.Controls.Add(Me.grpEstadoPedidoProveedor)
        Me.Controls.Add(Me.chbGenerarPedidosStockSeleccionaTrue)
        Me.Controls.Add(Me.chbImpresionMuestraCodigoProveedor)
        Me.Name = "ucConfPedidosProvPedidosProv"
        Me.Controls.SetChildIndex(Me.chbImpresionMuestraCodigoProveedor, 0)
        Me.Controls.SetChildIndex(Me.chbGenerarPedidosStockSeleccionaTrue, 0)
        Me.Controls.SetChildIndex(Me.grpEstadoPedidoProveedor, 0)
        Me.Controls.SetChildIndex(Me.chbPedidoProvSinPrecio, 0)
        Me.Controls.SetChildIndex(Me.chbGeneraPedidoProvModificaPrecioCosto, 0)
        Me.Controls.SetChildIndex(Me.chbPedidosProvPendientesFacturarAutomatico, 0)
        Me.Controls.SetChildIndex(Me.GroupBox11, 0)
        Me.Controls.SetChildIndex(Me.chbPedidosProveedoresConservaOrdenProductos, 0)
        Me.GroupBox11.ResumeLayout(False)
        Me.GroupBox11.PerformLayout()
        Me.grpEstadoPedidoProveedor.ResumeLayout(False)
        Me.grpEstadoPedidoProveedor.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents chbPedidosProveedoresConservaOrdenProductos As Controles.CheckBox
   Friend WithEvents GroupBox11 As GroupBox
   Friend WithEvents cmbEstadoPedidoProvPostVinculacion As Controles.ComboBox
   Friend WithEvents lblEstadoPedidoProvPostVinculacion As Controles.Label
   Friend WithEvents cmbEstadoPedidoPostVinculacion As Controles.ComboBox
   Friend WithEvents lblEstadoPedidoPostVinculacion As Controles.Label
   Friend WithEvents cmbEstadoPedidoProvPreVinculacion As Controles.ComboBox
   Friend WithEvents lblEstadoPedidoProvPreVinculacion As Controles.Label
   Friend WithEvents cmbEstadoPedidoPreVinculacion As Controles.ComboBox
   Friend WithEvents lblEstadoPedidoPreVinculacion As Controles.Label
   Friend WithEvents chbPedidosProvPendientesFacturarAutomatico As Controles.CheckBox
   Friend WithEvents chbGeneraPedidoProvModificaPrecioCosto As Controles.CheckBox
   Friend WithEvents chbPedidoProvSinPrecio As Controles.CheckBox
   Friend WithEvents grpEstadoPedidoProveedor As GroupBox
   Friend WithEvents cmbPedidoProveedorEstadoNuevo As Controles.ComboBox
   Friend WithEvents lblPedidoProveedorEstadoNuevo As Controles.Label
    Friend WithEvents lblPedidoProveedorEstadoAFacturar As Controles.Label
    Friend WithEvents cmbPedidoProveedorEstadoAnulado As Controles.ComboBox
    Friend WithEvents lblPedidoProveedorEstadoAnulado As Controles.Label
    Friend WithEvents lblPedidoProveedorEstadoFacturado As Controles.Label
    Friend WithEvents chbGenerarPedidosStockSeleccionaTrue As Controles.CheckBox
    Friend WithEvents chbImpresionMuestraCodigoProveedor As Controles.CheckBox
    Friend WithEvents Label1 As Controles.Label
End Class
