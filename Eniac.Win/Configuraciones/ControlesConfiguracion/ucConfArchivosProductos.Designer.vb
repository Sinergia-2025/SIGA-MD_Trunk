<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ucConfArchivosProductos
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
      Me.gpbPublicarEn = New System.Windows.Forms.GroupBox()
        Me.chbArborea = New Eniac.Controles.CheckBox()
        Me.chbMercadoLibre = New Eniac.Controles.CheckBox()
        Me.chbTiendaNube = New Eniac.Controles.CheckBox()
        Me.chbAppEmpresarial = New Eniac.Controles.CheckBox()
        Me.chbSincronizacionSucursal = New Eniac.Controles.CheckBox()
        Me.chbAppGestión = New Eniac.Controles.CheckBox()
        Me.chbListaPreciosClientes = New Eniac.Controles.CheckBox()
        Me.chbBalanza = New Eniac.Controles.CheckBox()
        Me.chbWebCarrito = New Eniac.Controles.CheckBox()
        Me.chbHABILITACODIGOPRODUCTONUMERICO = New Eniac.Controles.CheckBox()
        Me.txtUbicacionProductoPorDefecto = New Eniac.Controles.TextBox()
        Me.lblUbicacionPorDefecto = New Eniac.Controles.Label()
        Me.lblCaracterProductoObservacion = New Eniac.Controles.Label()
        Me.txtCantidadCaracteresProductoObservacion = New Eniac.Controles.TextBox()
        Me.chbProductoBuscarPorCodigoExacto = New Eniac.Controles.CheckBox()
        Me.chbEditaProductoModificaHistorial = New Eniac.Controles.CheckBox()
        Me.chbBuscarProductoPorCodigoProveedorHabitual = New Eniac.Controles.CheckBox()
        Me.chbProductoBusquedaCombinaCodigoNombre = New Eniac.Controles.CheckBox()
        Me.lblProductoFormatoLikeBuscarPorNombre = New Eniac.Controles.Label()
        Me.lblProductoFormatoLikeBuscarPorCodigo = New Eniac.Controles.Label()
        Me.chbProductoUtilizaProductoWeb = New Eniac.Controles.CheckBox()
        Me.txtProductoIVA = New Eniac.Controles.TextBox()
        Me.lblProductoIVA = New Eniac.Controles.Label()
        Me.chbProductoUtilizaNombreCorto = New Eniac.Controles.CheckBox()
        Me.chbProductoCodigoNumerico = New Eniac.Controles.CheckBox()
        Me.chbProductoUtilizaCantidadesEnteras = New Eniac.Controles.CheckBox()
        Me.chkProductoUtilizaCodigoLargo = New Eniac.Controles.CheckBox()
        Me.chbProductoCodigoDeBarras = New Eniac.Controles.CheckBox()
        Me.chbProductoCodigoQuitarBlancos = New Eniac.Controles.CheckBox()
        Me.chbProductoPermiteEsBonificable = New Eniac.Controles.CheckBox()
        Me.chbProductoPermiteEsCambiable = New Eniac.Controles.CheckBox()
        Me.chbProductoEmbalajeInverso = New Eniac.Controles.CheckBox()
        Me.cmbProductoFormatoLikeBuscarPorNombre = New Eniac.Controles.ComboBox()
        Me.cmbProductoFormatoLikeBuscarPorCodigo = New Eniac.Controles.ComboBox()
        Me.lblCaracteresProductoCBPesoCantidad = New Eniac.Controles.Label()
        Me.txtCaracteresProductoCBPesoCantidad = New Eniac.Controles.TextBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.lblProductosCantidadComprasSolapaCompras = New Eniac.Controles.Label()
        Me.lblProductosCantidadComprasSolapaCompras2 = New Eniac.Controles.Label()
        Me.txtProductosCantidadComprasSolapaCompras = New Eniac.Controles.TextBox()
        Me.chkOcultarProductosInactivosABMProductos = New Eniac.Controles.CheckBox()
        Me.chbProductoPermiteEsDevolucion = New Eniac.Controles.CheckBox()
        Me.gpbPublicarEn.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'gpbPublicarEn
        '
        Me.gpbPublicarEn.Controls.Add(Me.chbArborea)
        Me.gpbPublicarEn.Controls.Add(Me.chbMercadoLibre)
        Me.gpbPublicarEn.Controls.Add(Me.chbTiendaNube)
        Me.gpbPublicarEn.Controls.Add(Me.chbAppEmpresarial)
        Me.gpbPublicarEn.Controls.Add(Me.chbSincronizacionSucursal)
        Me.gpbPublicarEn.Controls.Add(Me.chbAppGestión)
        Me.gpbPublicarEn.Controls.Add(Me.chbListaPreciosClientes)
        Me.gpbPublicarEn.Controls.Add(Me.chbBalanza)
        Me.gpbPublicarEn.Controls.Add(Me.chbWebCarrito)
        Me.gpbPublicarEn.Location = New System.Drawing.Point(446, 190)
        Me.gpbPublicarEn.Name = "gpbPublicarEn"
        Me.gpbPublicarEn.Size = New System.Drawing.Size(339, 120)
        Me.gpbPublicarEn.TabIndex = 27
        Me.gpbPublicarEn.TabStop = False
        Me.gpbPublicarEn.Text = "Publicar en..."
        '
        'chbArborea
        '
        Me.chbArborea.BindearPropiedadControl = Nothing
        Me.chbArborea.BindearPropiedadEntidad = Nothing
        Me.chbArborea.ForeColorFocus = System.Drawing.Color.Red
        Me.chbArborea.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbArborea.IsPK = False
        Me.chbArborea.IsRequired = False
        Me.chbArborea.Key = Nothing
        Me.chbArborea.LabelAsoc = Nothing
        Me.chbArborea.Location = New System.Drawing.Point(234, 47)
        Me.chbArborea.Name = "chbArborea"
        Me.chbArborea.Size = New System.Drawing.Size(103, 20)
        Me.chbArborea.TabIndex = 5
        Me.chbArborea.Tag = ""
        Me.chbArborea.Text = "Arborea"
        Me.chbArborea.UseVisualStyleBackColor = True
        '
        'chbMercadoLibre
        '
        Me.chbMercadoLibre.BindearPropiedadControl = Nothing
        Me.chbMercadoLibre.BindearPropiedadEntidad = Nothing
        Me.chbMercadoLibre.ForeColorFocus = System.Drawing.Color.Red
        Me.chbMercadoLibre.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbMercadoLibre.IsPK = False
        Me.chbMercadoLibre.IsRequired = False
        Me.chbMercadoLibre.Key = Nothing
        Me.chbMercadoLibre.LabelAsoc = Nothing
        Me.chbMercadoLibre.Location = New System.Drawing.Point(123, 47)
        Me.chbMercadoLibre.Name = "chbMercadoLibre"
        Me.chbMercadoLibre.Size = New System.Drawing.Size(100, 20)
        Me.chbMercadoLibre.TabIndex = 4
        Me.chbMercadoLibre.Tag = ""
        Me.chbMercadoLibre.Text = "Mercado Libre"
        Me.chbMercadoLibre.UseVisualStyleBackColor = True
        '
        'chbTiendaNube
        '
        Me.chbTiendaNube.BindearPropiedadControl = Nothing
        Me.chbTiendaNube.BindearPropiedadEntidad = Nothing
        Me.chbTiendaNube.ForeColorFocus = System.Drawing.Color.Red
        Me.chbTiendaNube.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbTiendaNube.IsPK = False
        Me.chbTiendaNube.IsRequired = False
        Me.chbTiendaNube.Key = Nothing
        Me.chbTiendaNube.LabelAsoc = Nothing
        Me.chbTiendaNube.Location = New System.Drawing.Point(11, 47)
        Me.chbTiendaNube.Name = "chbTiendaNube"
        Me.chbTiendaNube.Size = New System.Drawing.Size(100, 20)
        Me.chbTiendaNube.TabIndex = 3
        Me.chbTiendaNube.Tag = ""
        Me.chbTiendaNube.Text = "Tienda Nube"
        Me.chbTiendaNube.UseVisualStyleBackColor = True
        '
        'chbAppEmpresarial
        '
        Me.chbAppEmpresarial.BindearPropiedadControl = Nothing
        Me.chbAppEmpresarial.BindearPropiedadEntidad = Nothing
        Me.chbAppEmpresarial.ForeColorFocus = System.Drawing.Color.Red
        Me.chbAppEmpresarial.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbAppEmpresarial.IsPK = False
        Me.chbAppEmpresarial.IsRequired = False
        Me.chbAppEmpresarial.Key = Nothing
        Me.chbAppEmpresarial.LabelAsoc = Nothing
        Me.chbAppEmpresarial.Location = New System.Drawing.Point(234, 26)
        Me.chbAppEmpresarial.Name = "chbAppEmpresarial"
        Me.chbAppEmpresarial.Size = New System.Drawing.Size(103, 20)
        Me.chbAppEmpresarial.TabIndex = 2
        Me.chbAppEmpresarial.Tag = "PRODUCTOPUBLICARAPPEMPRESARIAL"
        Me.chbAppEmpresarial.Text = "App Empresarial"
        Me.chbAppEmpresarial.UseVisualStyleBackColor = True
        '
        'chbSincronizacionSucursal
        '
        Me.chbSincronizacionSucursal.BindearPropiedadControl = Nothing
        Me.chbSincronizacionSucursal.BindearPropiedadEntidad = Nothing
        Me.chbSincronizacionSucursal.ForeColorFocus = System.Drawing.Color.Red
        Me.chbSincronizacionSucursal.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbSincronizacionSucursal.IsPK = False
        Me.chbSincronizacionSucursal.IsRequired = False
        Me.chbSincronizacionSucursal.Key = Nothing
        Me.chbSincronizacionSucursal.LabelAsoc = Nothing
        Me.chbSincronizacionSucursal.Location = New System.Drawing.Point(123, 70)
        Me.chbSincronizacionSucursal.Name = "chbSincronizacionSucursal"
        Me.chbSincronizacionSucursal.Size = New System.Drawing.Size(150, 20)
        Me.chbSincronizacionSucursal.TabIndex = 7
        Me.chbSincronizacionSucursal.Tag = "PRODUCTOPUBLICARSINCRONIZACIONSUCURSAL"
        Me.chbSincronizacionSucursal.Text = "Sincronización a Sucursal"
        Me.chbSincronizacionSucursal.UseVisualStyleBackColor = True
        '
        'chbAppGestión
        '
        Me.chbAppGestión.BindearPropiedadControl = Nothing
        Me.chbAppGestión.BindearPropiedadEntidad = Nothing
        Me.chbAppGestión.ForeColorFocus = System.Drawing.Color.Red
        Me.chbAppGestión.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbAppGestión.IsPK = False
        Me.chbAppGestión.IsRequired = False
        Me.chbAppGestión.Key = Nothing
        Me.chbAppGestión.LabelAsoc = Nothing
        Me.chbAppGestión.Location = New System.Drawing.Point(123, 26)
        Me.chbAppGestión.Name = "chbAppGestión"
        Me.chbAppGestión.Size = New System.Drawing.Size(100, 20)
        Me.chbAppGestión.TabIndex = 1
        Me.chbAppGestión.Tag = "PRODUCTOPUBLICARAPPGESTION"
        Me.chbAppGestión.Text = "App Gestión"
        Me.chbAppGestión.UseVisualStyleBackColor = True
        '
        'chbListaPreciosClientes
        '
        Me.chbListaPreciosClientes.BindearPropiedadControl = Nothing
        Me.chbListaPreciosClientes.BindearPropiedadEntidad = Nothing
        Me.chbListaPreciosClientes.ForeColorFocus = System.Drawing.Color.Red
        Me.chbListaPreciosClientes.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbListaPreciosClientes.IsPK = False
        Me.chbListaPreciosClientes.IsRequired = False
        Me.chbListaPreciosClientes.Key = Nothing
        Me.chbListaPreciosClientes.LabelAsoc = Nothing
        Me.chbListaPreciosClientes.Location = New System.Drawing.Point(11, 93)
        Me.chbListaPreciosClientes.Name = "chbListaPreciosClientes"
        Me.chbListaPreciosClientes.Size = New System.Drawing.Size(169, 20)
        Me.chbListaPreciosClientes.TabIndex = 8
        Me.chbListaPreciosClientes.Tag = "PRODUCTOPUBLICARLISTAPRECIOCLIENTES"
        Me.chbListaPreciosClientes.Text = "Lista de Precios para Clientes"
        Me.chbListaPreciosClientes.UseVisualStyleBackColor = True
        '
        'chbBalanza
        '
        Me.chbBalanza.BindearPropiedadControl = Nothing
        Me.chbBalanza.BindearPropiedadEntidad = Nothing
        Me.chbBalanza.ForeColorFocus = System.Drawing.Color.Red
        Me.chbBalanza.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbBalanza.IsPK = False
        Me.chbBalanza.IsRequired = False
        Me.chbBalanza.Key = Nothing
        Me.chbBalanza.LabelAsoc = Nothing
        Me.chbBalanza.Location = New System.Drawing.Point(11, 70)
        Me.chbBalanza.Name = "chbBalanza"
        Me.chbBalanza.Size = New System.Drawing.Size(100, 20)
        Me.chbBalanza.TabIndex = 6
        Me.chbBalanza.Tag = "PRODUCTOPUBLICARBALANZA"
        Me.chbBalanza.Text = "Balanza"
        Me.chbBalanza.UseVisualStyleBackColor = True
        '
        'chbWebCarrito
        '
        Me.chbWebCarrito.BindearPropiedadControl = Nothing
        Me.chbWebCarrito.BindearPropiedadEntidad = Nothing
        Me.chbWebCarrito.ForeColorFocus = System.Drawing.Color.Red
        Me.chbWebCarrito.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbWebCarrito.IsPK = False
        Me.chbWebCarrito.IsRequired = False
        Me.chbWebCarrito.Key = Nothing
        Me.chbWebCarrito.LabelAsoc = Nothing
        Me.chbWebCarrito.Location = New System.Drawing.Point(11, 26)
        Me.chbWebCarrito.Name = "chbWebCarrito"
        Me.chbWebCarrito.Size = New System.Drawing.Size(100, 20)
        Me.chbWebCarrito.TabIndex = 0
        Me.chbWebCarrito.Tag = "PRODUCTOPUBLICARWEBCARRITO"
        Me.chbWebCarrito.Text = "Web / Carrito"
        Me.chbWebCarrito.UseVisualStyleBackColor = True
        '
        'chbHABILITACODIGOPRODUCTONUMERICO
        '
        Me.chbHABILITACODIGOPRODUCTONUMERICO.BindearPropiedadControl = Nothing
        Me.chbHABILITACODIGOPRODUCTONUMERICO.BindearPropiedadEntidad = Nothing
        Me.chbHABILITACODIGOPRODUCTONUMERICO.ForeColorFocus = System.Drawing.Color.Red
        Me.chbHABILITACODIGOPRODUCTONUMERICO.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbHABILITACODIGOPRODUCTONUMERICO.IsPK = False
        Me.chbHABILITACODIGOPRODUCTONUMERICO.IsRequired = False
        Me.chbHABILITACODIGOPRODUCTONUMERICO.Key = Nothing
        Me.chbHABILITACODIGOPRODUCTONUMERICO.LabelAsoc = Nothing
        Me.chbHABILITACODIGOPRODUCTONUMERICO.Location = New System.Drawing.Point(55, 52)
        Me.chbHABILITACODIGOPRODUCTONUMERICO.Name = "chbHABILITACODIGOPRODUCTONUMERICO"
        Me.chbHABILITACODIGOPRODUCTONUMERICO.Size = New System.Drawing.Size(259, 20)
        Me.chbHABILITACODIGOPRODUCTONUMERICO.TabIndex = 3
        Me.chbHABILITACODIGOPRODUCTONUMERICO.Tag = "HABILITACODIGOPRODUCTONUMERICO"
        Me.chbHABILITACODIGOPRODUCTONUMERICO.Text = "Permite modificar Código de Producto Numérico"
        Me.chbHABILITACODIGOPRODUCTONUMERICO.UseVisualStyleBackColor = True
        '
        'txtUbicacionProductoPorDefecto
        '
        Me.txtUbicacionProductoPorDefecto.AcceptsReturn = True
        Me.txtUbicacionProductoPorDefecto.BindearPropiedadControl = Nothing
        Me.txtUbicacionProductoPorDefecto.BindearPropiedadEntidad = Nothing
        Me.txtUbicacionProductoPorDefecto.ForeColorFocus = System.Drawing.Color.Red
        Me.txtUbicacionProductoPorDefecto.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtUbicacionProductoPorDefecto.Formato = ""
        Me.txtUbicacionProductoPorDefecto.IsDecimal = False
        Me.txtUbicacionProductoPorDefecto.IsNumber = False
        Me.txtUbicacionProductoPorDefecto.IsPK = False
        Me.txtUbicacionProductoPorDefecto.IsRequired = False
        Me.txtUbicacionProductoPorDefecto.Key = ""
        Me.txtUbicacionProductoPorDefecto.LabelAsoc = Me.lblUbicacionPorDefecto
        Me.txtUbicacionProductoPorDefecto.Location = New System.Drawing.Point(580, 104)
        Me.txtUbicacionProductoPorDefecto.Name = "txtUbicacionProductoPorDefecto"
        Me.txtUbicacionProductoPorDefecto.Size = New System.Drawing.Size(122, 20)
        Me.txtUbicacionProductoPorDefecto.TabIndex = 24
        '
        'lblUbicacionPorDefecto
        '
        Me.lblUbicacionPorDefecto.AutoSize = True
        Me.lblUbicacionPorDefecto.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblUbicacionPorDefecto.LabelAsoc = Nothing
        Me.lblUbicacionPorDefecto.Location = New System.Drawing.Point(443, 108)
        Me.lblUbicacionPorDefecto.Name = "lblUbicacionPorDefecto"
        Me.lblUbicacionPorDefecto.Size = New System.Drawing.Size(114, 13)
        Me.lblUbicacionPorDefecto.TabIndex = 23
        Me.lblUbicacionPorDefecto.Text = "Ubicación por Defecto"
        '
        'lblCaracterProductoObservacion
        '
        Me.lblCaracterProductoObservacion.AutoSize = True
        Me.lblCaracterProductoObservacion.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblCaracterProductoObservacion.LabelAsoc = Nothing
        Me.lblCaracterProductoObservacion.Location = New System.Drawing.Point(496, 161)
        Me.lblCaracterProductoObservacion.Name = "lblCaracterProductoObservacion"
        Me.lblCaracterProductoObservacion.Size = New System.Drawing.Size(289, 13)
        Me.lblCaracterProductoObservacion.TabIndex = 22
        Me.lblCaracterProductoObservacion.Text = "Cantidad Maxima de Caracteres de Productos Observación "
        '
        'txtCantidadCaracteresProductoObservacion
        '
        Me.txtCantidadCaracteresProductoObservacion.BindearPropiedadControl = Nothing
        Me.txtCantidadCaracteresProductoObservacion.BindearPropiedadEntidad = Nothing
        Me.txtCantidadCaracteresProductoObservacion.ForeColorFocus = System.Drawing.Color.Red
        Me.txtCantidadCaracteresProductoObservacion.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtCantidadCaracteresProductoObservacion.Formato = "#0.00"
        Me.txtCantidadCaracteresProductoObservacion.IsDecimal = False
        Me.txtCantidadCaracteresProductoObservacion.IsNumber = True
        Me.txtCantidadCaracteresProductoObservacion.IsPK = False
        Me.txtCantidadCaracteresProductoObservacion.IsRequired = False
        Me.txtCantidadCaracteresProductoObservacion.Key = ""
        Me.txtCantidadCaracteresProductoObservacion.LabelAsoc = Me.lblCaracterProductoObservacion
        Me.txtCantidadCaracteresProductoObservacion.Location = New System.Drawing.Point(446, 157)
        Me.txtCantidadCaracteresProductoObservacion.MaxLength = 4
        Me.txtCantidadCaracteresProductoObservacion.Name = "txtCantidadCaracteresProductoObservacion"
        Me.txtCantidadCaracteresProductoObservacion.Size = New System.Drawing.Size(45, 20)
        Me.txtCantidadCaracteresProductoObservacion.TabIndex = 21
        Me.txtCantidadCaracteresProductoObservacion.Tag = "PRODUCTOIVA"
        Me.txtCantidadCaracteresProductoObservacion.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'chbProductoBuscarPorCodigoExacto
        '
        Me.chbProductoBuscarPorCodigoExacto.BindearPropiedadControl = Nothing
        Me.chbProductoBuscarPorCodigoExacto.BindearPropiedadEntidad = Nothing
        Me.chbProductoBuscarPorCodigoExacto.ForeColorFocus = System.Drawing.Color.Red
        Me.chbProductoBuscarPorCodigoExacto.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbProductoBuscarPorCodigoExacto.IsPK = False
        Me.chbProductoBuscarPorCodigoExacto.IsRequired = False
        Me.chbProductoBuscarPorCodigoExacto.Key = Nothing
        Me.chbProductoBuscarPorCodigoExacto.LabelAsoc = Nothing
        Me.chbProductoBuscarPorCodigoExacto.Location = New System.Drawing.Point(55, 184)
        Me.chbProductoBuscarPorCodigoExacto.Name = "chbProductoBuscarPorCodigoExacto"
        Me.chbProductoBuscarPorCodigoExacto.Size = New System.Drawing.Size(321, 26)
        Me.chbProductoBuscarPorCodigoExacto.TabIndex = 10
        Me.chbProductoBuscarPorCodigoExacto.Tag = ""
        Me.chbProductoBuscarPorCodigoExacto.Text = "Al buscar por código buscar primero código exacto"
        Me.chbProductoBuscarPorCodigoExacto.UseVisualStyleBackColor = True
        '
        'chbEditaProductoModificaHistorial
        '
        Me.chbEditaProductoModificaHistorial.BindearPropiedadControl = Nothing
        Me.chbEditaProductoModificaHistorial.BindearPropiedadEntidad = Nothing
        Me.chbEditaProductoModificaHistorial.ForeColorFocus = System.Drawing.Color.Red
        Me.chbEditaProductoModificaHistorial.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbEditaProductoModificaHistorial.IsPK = False
        Me.chbEditaProductoModificaHistorial.IsRequired = False
        Me.chbEditaProductoModificaHistorial.Key = Nothing
        Me.chbEditaProductoModificaHistorial.LabelAsoc = Nothing
        Me.chbEditaProductoModificaHistorial.Location = New System.Drawing.Point(445, 0)
        Me.chbEditaProductoModificaHistorial.Name = "chbEditaProductoModificaHistorial"
        Me.chbEditaProductoModificaHistorial.Size = New System.Drawing.Size(403, 26)
        Me.chbEditaProductoModificaHistorial.TabIndex = 18
        Me.chbEditaProductoModificaHistorial.Tag = ""
        Me.chbEditaProductoModificaHistorial.Text = "Edita Producto Normal Modifica el Nombre en el Historial"
        Me.chbEditaProductoModificaHistorial.UseVisualStyleBackColor = True
        '
        'chbBuscarProductoPorCodigoProveedorHabitual
        '
        Me.chbBuscarProductoPorCodigoProveedorHabitual.BindearPropiedadControl = Nothing
        Me.chbBuscarProductoPorCodigoProveedorHabitual.BindearPropiedadEntidad = Nothing
        Me.chbBuscarProductoPorCodigoProveedorHabitual.ForeColorFocus = System.Drawing.Color.Red
        Me.chbBuscarProductoPorCodigoProveedorHabitual.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbBuscarProductoPorCodigoProveedorHabitual.IsPK = False
        Me.chbBuscarProductoPorCodigoProveedorHabitual.IsRequired = False
        Me.chbBuscarProductoPorCodigoProveedorHabitual.Key = Nothing
        Me.chbBuscarProductoPorCodigoProveedorHabitual.LabelAsoc = Nothing
        Me.chbBuscarProductoPorCodigoProveedorHabitual.Location = New System.Drawing.Point(55, 216)
        Me.chbBuscarProductoPorCodigoProveedorHabitual.Name = "chbBuscarProductoPorCodigoProveedorHabitual"
        Me.chbBuscarProductoPorCodigoProveedorHabitual.Size = New System.Drawing.Size(321, 26)
        Me.chbBuscarProductoPorCodigoProveedorHabitual.TabIndex = 11
        Me.chbBuscarProductoPorCodigoProveedorHabitual.Tag = ""
        Me.chbBuscarProductoPorCodigoProveedorHabitual.Text = "Busca Producto por Código de Proveedor Habitual"
        Me.chbBuscarProductoPorCodigoProveedorHabitual.UseVisualStyleBackColor = True
        '
        'chbProductoBusquedaCombinaCodigoNombre
        '
        Me.chbProductoBusquedaCombinaCodigoNombre.BindearPropiedadControl = Nothing
        Me.chbProductoBusquedaCombinaCodigoNombre.BindearPropiedadEntidad = Nothing
        Me.chbProductoBusquedaCombinaCodigoNombre.ForeColorFocus = System.Drawing.Color.Red
        Me.chbProductoBusquedaCombinaCodigoNombre.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbProductoBusquedaCombinaCodigoNombre.IsPK = False
        Me.chbProductoBusquedaCombinaCodigoNombre.IsRequired = False
        Me.chbProductoBusquedaCombinaCodigoNombre.Key = Nothing
        Me.chbProductoBusquedaCombinaCodigoNombre.LabelAsoc = Nothing
        Me.chbProductoBusquedaCombinaCodigoNombre.Location = New System.Drawing.Point(55, 158)
        Me.chbProductoBusquedaCombinaCodigoNombre.Name = "chbProductoBusquedaCombinaCodigoNombre"
        Me.chbProductoBusquedaCombinaCodigoNombre.Size = New System.Drawing.Size(335, 20)
        Me.chbProductoBusquedaCombinaCodigoNombre.TabIndex = 9
        Me.chbProductoBusquedaCombinaCodigoNombre.Tag = ""
        Me.chbProductoBusquedaCombinaCodigoNombre.Text = "Al buscar por nombre combinar la búsqueda con el código"
        Me.chbProductoBusquedaCombinaCodigoNombre.UseVisualStyleBackColor = True
        '
        'lblProductoFormatoLikeBuscarPorNombre
        '
        Me.lblProductoFormatoLikeBuscarPorNombre.AutoSize = True
        Me.lblProductoFormatoLikeBuscarPorNombre.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblProductoFormatoLikeBuscarPorNombre.LabelAsoc = Nothing
        Me.lblProductoFormatoLikeBuscarPorNombre.Location = New System.Drawing.Point(52, 135)
        Me.lblProductoFormatoLikeBuscarPorNombre.Name = "lblProductoFormatoLikeBuscarPorNombre"
        Me.lblProductoFormatoLikeBuscarPorNombre.Size = New System.Drawing.Size(133, 13)
        Me.lblProductoFormatoLikeBuscarPorNombre.TabIndex = 7
        Me.lblProductoFormatoLikeBuscarPorNombre.Text = "Al buscar por nombre usar:"
        '
        'lblProductoFormatoLikeBuscarPorCodigo
        '
        Me.lblProductoFormatoLikeBuscarPorCodigo.AutoSize = True
        Me.lblProductoFormatoLikeBuscarPorCodigo.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblProductoFormatoLikeBuscarPorCodigo.LabelAsoc = Nothing
        Me.lblProductoFormatoLikeBuscarPorCodigo.Location = New System.Drawing.Point(52, 108)
        Me.lblProductoFormatoLikeBuscarPorCodigo.Name = "lblProductoFormatoLikeBuscarPorCodigo"
        Me.lblProductoFormatoLikeBuscarPorCodigo.Size = New System.Drawing.Size(130, 13)
        Me.lblProductoFormatoLikeBuscarPorCodigo.TabIndex = 5
        Me.lblProductoFormatoLikeBuscarPorCodigo.Text = "Al buscar por código usar:"
        '
        'chbProductoUtilizaProductoWeb
        '
        Me.chbProductoUtilizaProductoWeb.BindearPropiedadControl = Nothing
        Me.chbProductoUtilizaProductoWeb.BindearPropiedadEntidad = Nothing
        Me.chbProductoUtilizaProductoWeb.ForeColorFocus = System.Drawing.Color.Red
        Me.chbProductoUtilizaProductoWeb.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbProductoUtilizaProductoWeb.IsPK = False
        Me.chbProductoUtilizaProductoWeb.IsRequired = False
        Me.chbProductoUtilizaProductoWeb.Key = Nothing
        Me.chbProductoUtilizaProductoWeb.LabelAsoc = Nothing
        Me.chbProductoUtilizaProductoWeb.Location = New System.Drawing.Point(55, 378)
        Me.chbProductoUtilizaProductoWeb.Name = "chbProductoUtilizaProductoWeb"
        Me.chbProductoUtilizaProductoWeb.Size = New System.Drawing.Size(277, 20)
        Me.chbProductoUtilizaProductoWeb.TabIndex = 17
        Me.chbProductoUtilizaProductoWeb.Tag = "PRODUCTOUTILIZAPRODUCTOWEB"
        Me.chbProductoUtilizaProductoWeb.Text = "Producto Utiliza Producto Web"
        Me.chbProductoUtilizaProductoWeb.UseVisualStyleBackColor = True
        '
        'txtProductoIVA
        '
        Me.txtProductoIVA.BindearPropiedadControl = Nothing
        Me.txtProductoIVA.BindearPropiedadEntidad = Nothing
        Me.txtProductoIVA.ForeColorFocus = System.Drawing.Color.Red
        Me.txtProductoIVA.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtProductoIVA.Formato = "#0.00"
        Me.txtProductoIVA.IsDecimal = True
        Me.txtProductoIVA.IsNumber = True
        Me.txtProductoIVA.IsPK = False
        Me.txtProductoIVA.IsRequired = False
        Me.txtProductoIVA.Key = ""
        Me.txtProductoIVA.LabelAsoc = Me.lblProductoIVA
        Me.txtProductoIVA.Location = New System.Drawing.Point(55, 0)
        Me.txtProductoIVA.MaxLength = 5
        Me.txtProductoIVA.Name = "txtProductoIVA"
        Me.txtProductoIVA.Size = New System.Drawing.Size(45, 20)
        Me.txtProductoIVA.TabIndex = 0
        Me.txtProductoIVA.Tag = "PRODUCTOIVA"
        Me.txtProductoIVA.Text = "21,00"
        Me.txtProductoIVA.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblProductoIVA
        '
        Me.lblProductoIVA.AutoSize = True
        Me.lblProductoIVA.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblProductoIVA.LabelAsoc = Nothing
        Me.lblProductoIVA.Location = New System.Drawing.Point(105, 4)
        Me.lblProductoIVA.Name = "lblProductoIVA"
        Me.lblProductoIVA.Size = New System.Drawing.Size(134, 13)
        Me.lblProductoIVA.TabIndex = 1
        Me.lblProductoIVA.Text = "IVA del Producto en el Alta"
        '
        'chbProductoUtilizaNombreCorto
        '
        Me.chbProductoUtilizaNombreCorto.BindearPropiedadControl = Nothing
        Me.chbProductoUtilizaNombreCorto.BindearPropiedadEntidad = Nothing
        Me.chbProductoUtilizaNombreCorto.ForeColorFocus = System.Drawing.Color.Red
        Me.chbProductoUtilizaNombreCorto.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbProductoUtilizaNombreCorto.IsPK = False
        Me.chbProductoUtilizaNombreCorto.IsRequired = False
        Me.chbProductoUtilizaNombreCorto.Key = Nothing
        Me.chbProductoUtilizaNombreCorto.LabelAsoc = Nothing
        Me.chbProductoUtilizaNombreCorto.Location = New System.Drawing.Point(55, 274)
        Me.chbProductoUtilizaNombreCorto.Name = "chbProductoUtilizaNombreCorto"
        Me.chbProductoUtilizaNombreCorto.Size = New System.Drawing.Size(274, 20)
        Me.chbProductoUtilizaNombreCorto.TabIndex = 13
        Me.chbProductoUtilizaNombreCorto.Tag = "PRODUCTOUTILIZANOMBRECORTO"
        Me.chbProductoUtilizaNombreCorto.Text = "Producto Utiliza Nombre Corto"
        Me.chbProductoUtilizaNombreCorto.UseVisualStyleBackColor = True
        '
        'chbProductoCodigoNumerico
        '
        Me.chbProductoCodigoNumerico.BindearPropiedadControl = Nothing
        Me.chbProductoCodigoNumerico.BindearPropiedadEntidad = Nothing
        Me.chbProductoCodigoNumerico.ForeColorFocus = System.Drawing.Color.Red
        Me.chbProductoCodigoNumerico.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbProductoCodigoNumerico.IsPK = False
        Me.chbProductoCodigoNumerico.IsRequired = False
        Me.chbProductoCodigoNumerico.Key = Nothing
        Me.chbProductoCodigoNumerico.LabelAsoc = Nothing
        Me.chbProductoCodigoNumerico.Location = New System.Drawing.Point(55, 26)
        Me.chbProductoCodigoNumerico.Name = "chbProductoCodigoNumerico"
        Me.chbProductoCodigoNumerico.Size = New System.Drawing.Size(274, 20)
        Me.chbProductoCodigoNumerico.TabIndex = 2
        Me.chbProductoCodigoNumerico.Tag = "PRODUCTOCODIGONUMERICO"
        Me.chbProductoCodigoNumerico.Text = "Código de Producto es Numérico"
        Me.chbProductoCodigoNumerico.UseVisualStyleBackColor = True
        '
        'chbProductoUtilizaCantidadesEnteras
        '
        Me.chbProductoUtilizaCantidadesEnteras.BindearPropiedadControl = Nothing
        Me.chbProductoUtilizaCantidadesEnteras.BindearPropiedadEntidad = Nothing
        Me.chbProductoUtilizaCantidadesEnteras.ForeColorFocus = System.Drawing.Color.Red
        Me.chbProductoUtilizaCantidadesEnteras.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbProductoUtilizaCantidadesEnteras.IsPK = False
        Me.chbProductoUtilizaCantidadesEnteras.IsRequired = False
        Me.chbProductoUtilizaCantidadesEnteras.Key = Nothing
        Me.chbProductoUtilizaCantidadesEnteras.LabelAsoc = Nothing
        Me.chbProductoUtilizaCantidadesEnteras.Location = New System.Drawing.Point(55, 300)
        Me.chbProductoUtilizaCantidadesEnteras.Name = "chbProductoUtilizaCantidadesEnteras"
        Me.chbProductoUtilizaCantidadesEnteras.Size = New System.Drawing.Size(274, 20)
        Me.chbProductoUtilizaCantidadesEnteras.TabIndex = 14
        Me.chbProductoUtilizaCantidadesEnteras.Tag = "PRODUCTOUTILIZACANTIDADESENTERAS"
        Me.chbProductoUtilizaCantidadesEnteras.Text = "Producto Utiliza Solo Cantidades Enteras"
        Me.chbProductoUtilizaCantidadesEnteras.UseVisualStyleBackColor = True
        '
        'chkProductoUtilizaCodigoLargo
        '
        Me.chkProductoUtilizaCodigoLargo.BindearPropiedadControl = Nothing
        Me.chkProductoUtilizaCodigoLargo.BindearPropiedadEntidad = Nothing
        Me.chkProductoUtilizaCodigoLargo.ForeColorFocus = System.Drawing.Color.Red
        Me.chkProductoUtilizaCodigoLargo.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chkProductoUtilizaCodigoLargo.IsPK = False
        Me.chkProductoUtilizaCodigoLargo.IsRequired = False
        Me.chkProductoUtilizaCodigoLargo.Key = Nothing
        Me.chkProductoUtilizaCodigoLargo.LabelAsoc = Nothing
        Me.chkProductoUtilizaCodigoLargo.Location = New System.Drawing.Point(55, 248)
        Me.chkProductoUtilizaCodigoLargo.Name = "chkProductoUtilizaCodigoLargo"
        Me.chkProductoUtilizaCodigoLargo.Size = New System.Drawing.Size(274, 20)
        Me.chkProductoUtilizaCodigoLargo.TabIndex = 12
        Me.chkProductoUtilizaCodigoLargo.Tag = ""
        Me.chkProductoUtilizaCodigoLargo.Text = "Producto Utiliza Codigo Largo"
        Me.chkProductoUtilizaCodigoLargo.UseVisualStyleBackColor = True
        '
        'chbProductoCodigoDeBarras
        '
        Me.chbProductoCodigoDeBarras.BindearPropiedadControl = Nothing
        Me.chbProductoCodigoDeBarras.BindearPropiedadEntidad = Nothing
        Me.chbProductoCodigoDeBarras.ForeColorFocus = System.Drawing.Color.Red
        Me.chbProductoCodigoDeBarras.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbProductoCodigoDeBarras.IsPK = False
        Me.chbProductoCodigoDeBarras.IsRequired = False
        Me.chbProductoCodigoDeBarras.Key = Nothing
        Me.chbProductoCodigoDeBarras.LabelAsoc = Nothing
        Me.chbProductoCodigoDeBarras.Location = New System.Drawing.Point(55, 326)
        Me.chbProductoCodigoDeBarras.Name = "chbProductoCodigoDeBarras"
        Me.chbProductoCodigoDeBarras.Size = New System.Drawing.Size(274, 20)
        Me.chbProductoCodigoDeBarras.TabIndex = 15
        Me.chbProductoCodigoDeBarras.Tag = "PRODUCTOUTILIZACODIGODEBARRAS"
        Me.chbProductoCodigoDeBarras.Text = "Producto Utiliza Código de Barras"
        Me.chbProductoCodigoDeBarras.UseVisualStyleBackColor = True
        '
        'chbProductoCodigoQuitarBlancos
        '
        Me.chbProductoCodigoQuitarBlancos.BindearPropiedadControl = Nothing
        Me.chbProductoCodigoQuitarBlancos.BindearPropiedadEntidad = Nothing
        Me.chbProductoCodigoQuitarBlancos.ForeColorFocus = System.Drawing.Color.Red
        Me.chbProductoCodigoQuitarBlancos.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbProductoCodigoQuitarBlancos.IsPK = False
        Me.chbProductoCodigoQuitarBlancos.IsRequired = False
        Me.chbProductoCodigoQuitarBlancos.Key = Nothing
        Me.chbProductoCodigoQuitarBlancos.LabelAsoc = Nothing
        Me.chbProductoCodigoQuitarBlancos.Location = New System.Drawing.Point(55, 78)
        Me.chbProductoCodigoQuitarBlancos.Name = "chbProductoCodigoQuitarBlancos"
        Me.chbProductoCodigoQuitarBlancos.Size = New System.Drawing.Size(274, 20)
        Me.chbProductoCodigoQuitarBlancos.TabIndex = 4
        Me.chbProductoCodigoQuitarBlancos.Tag = "PRODUCTOCODIGOQUITARBLANCOS"
        Me.chbProductoCodigoQuitarBlancos.Text = "Codigo de Producto quitar blancos para búsqueda "
        Me.chbProductoCodigoQuitarBlancos.UseVisualStyleBackColor = True
        '
        'chbProductoPermiteEsBonificable
        '
        Me.chbProductoPermiteEsBonificable.BindearPropiedadControl = Nothing
        Me.chbProductoPermiteEsBonificable.BindearPropiedadEntidad = Nothing
        Me.chbProductoPermiteEsBonificable.ForeColorFocus = System.Drawing.Color.Red
        Me.chbProductoPermiteEsBonificable.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbProductoPermiteEsBonificable.IsPK = False
        Me.chbProductoPermiteEsBonificable.IsRequired = False
        Me.chbProductoPermiteEsBonificable.Key = Nothing
        Me.chbProductoPermiteEsBonificable.LabelAsoc = Nothing
        Me.chbProductoPermiteEsBonificable.Location = New System.Drawing.Point(445, 53)
        Me.chbProductoPermiteEsBonificable.Name = "chbProductoPermiteEsBonificable"
        Me.chbProductoPermiteEsBonificable.Size = New System.Drawing.Size(274, 20)
        Me.chbProductoPermiteEsBonificable.TabIndex = 20
        Me.chbProductoPermiteEsBonificable.Text = "Producto se puede usar como Bonificado"
        Me.chbProductoPermiteEsBonificable.UseVisualStyleBackColor = True
        '
        'chbProductoPermiteEsCambiable
        '
        Me.chbProductoPermiteEsCambiable.BindearPropiedadControl = Nothing
        Me.chbProductoPermiteEsCambiable.BindearPropiedadEntidad = Nothing
        Me.chbProductoPermiteEsCambiable.ForeColorFocus = System.Drawing.Color.Red
        Me.chbProductoPermiteEsCambiable.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbProductoPermiteEsCambiable.IsPK = False
        Me.chbProductoPermiteEsCambiable.IsRequired = False
        Me.chbProductoPermiteEsCambiable.Key = Nothing
        Me.chbProductoPermiteEsCambiable.LabelAsoc = Nothing
        Me.chbProductoPermiteEsCambiable.Location = New System.Drawing.Point(445, 27)
        Me.chbProductoPermiteEsCambiable.Name = "chbProductoPermiteEsCambiable"
        Me.chbProductoPermiteEsCambiable.Size = New System.Drawing.Size(274, 20)
        Me.chbProductoPermiteEsCambiable.TabIndex = 19
        Me.chbProductoPermiteEsCambiable.Text = "Producto se puede usar como Cambio"
        Me.chbProductoPermiteEsCambiable.UseVisualStyleBackColor = True
        '
        'chbProductoEmbalajeInverso
        '
        Me.chbProductoEmbalajeInverso.BindearPropiedadControl = Nothing
        Me.chbProductoEmbalajeInverso.BindearPropiedadEntidad = Nothing
        Me.chbProductoEmbalajeInverso.ForeColorFocus = System.Drawing.Color.Red
        Me.chbProductoEmbalajeInverso.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbProductoEmbalajeInverso.IsPK = False
        Me.chbProductoEmbalajeInverso.IsRequired = False
        Me.chbProductoEmbalajeInverso.Key = Nothing
        Me.chbProductoEmbalajeInverso.LabelAsoc = Nothing
        Me.chbProductoEmbalajeInverso.Location = New System.Drawing.Point(55, 352)
        Me.chbProductoEmbalajeInverso.Name = "chbProductoEmbalajeInverso"
        Me.chbProductoEmbalajeInverso.Size = New System.Drawing.Size(274, 20)
        Me.chbProductoEmbalajeInverso.TabIndex = 16
        Me.chbProductoEmbalajeInverso.Tag = "PRODUCTOUTILIZAEMBALAJEARRIBA"
        Me.chbProductoEmbalajeInverso.Text = "Producto Utiliza el Embalaje hacia arriba"
        Me.chbProductoEmbalajeInverso.UseVisualStyleBackColor = True
        '
        'cmbProductoFormatoLikeBuscarPorNombre
        '
        Me.cmbProductoFormatoLikeBuscarPorNombre.BindearPropiedadControl = Nothing
        Me.cmbProductoFormatoLikeBuscarPorNombre.BindearPropiedadEntidad = Nothing
        Me.cmbProductoFormatoLikeBuscarPorNombre.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbProductoFormatoLikeBuscarPorNombre.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbProductoFormatoLikeBuscarPorNombre.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbProductoFormatoLikeBuscarPorNombre.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbProductoFormatoLikeBuscarPorNombre.FormattingEnabled = True
        Me.cmbProductoFormatoLikeBuscarPorNombre.IsPK = False
        Me.cmbProductoFormatoLikeBuscarPorNombre.IsRequired = False
        Me.cmbProductoFormatoLikeBuscarPorNombre.Key = Nothing
        Me.cmbProductoFormatoLikeBuscarPorNombre.LabelAsoc = Me.lblProductoFormatoLikeBuscarPorNombre
        Me.cmbProductoFormatoLikeBuscarPorNombre.Location = New System.Drawing.Point(188, 131)
        Me.cmbProductoFormatoLikeBuscarPorNombre.Name = "cmbProductoFormatoLikeBuscarPorNombre"
        Me.cmbProductoFormatoLikeBuscarPorNombre.Size = New System.Drawing.Size(243, 21)
        Me.cmbProductoFormatoLikeBuscarPorNombre.TabIndex = 8
        Me.cmbProductoFormatoLikeBuscarPorNombre.Tag = ""
        '
        'cmbProductoFormatoLikeBuscarPorCodigo
        '
        Me.cmbProductoFormatoLikeBuscarPorCodigo.BindearPropiedadControl = Nothing
        Me.cmbProductoFormatoLikeBuscarPorCodigo.BindearPropiedadEntidad = Nothing
        Me.cmbProductoFormatoLikeBuscarPorCodigo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbProductoFormatoLikeBuscarPorCodigo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbProductoFormatoLikeBuscarPorCodigo.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbProductoFormatoLikeBuscarPorCodigo.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbProductoFormatoLikeBuscarPorCodigo.FormattingEnabled = True
        Me.cmbProductoFormatoLikeBuscarPorCodigo.IsPK = False
        Me.cmbProductoFormatoLikeBuscarPorCodigo.IsRequired = False
        Me.cmbProductoFormatoLikeBuscarPorCodigo.Key = Nothing
        Me.cmbProductoFormatoLikeBuscarPorCodigo.LabelAsoc = Me.lblProductoFormatoLikeBuscarPorCodigo
        Me.cmbProductoFormatoLikeBuscarPorCodigo.Location = New System.Drawing.Point(188, 104)
        Me.cmbProductoFormatoLikeBuscarPorCodigo.Name = "cmbProductoFormatoLikeBuscarPorCodigo"
        Me.cmbProductoFormatoLikeBuscarPorCodigo.Size = New System.Drawing.Size(243, 21)
        Me.cmbProductoFormatoLikeBuscarPorCodigo.TabIndex = 6
        Me.cmbProductoFormatoLikeBuscarPorCodigo.Tag = ""
        '
        'lblCaracteresProductoCBPesoCantidad
        '
        Me.lblCaracteresProductoCBPesoCantidad.AutoSize = True
        Me.lblCaracteresProductoCBPesoCantidad.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblCaracteresProductoCBPesoCantidad.LabelAsoc = Nothing
        Me.lblCaracteresProductoCBPesoCantidad.Location = New System.Drawing.Point(496, 135)
        Me.lblCaracteresProductoCBPesoCantidad.Name = "lblCaracteresProductoCBPesoCantidad"
        Me.lblCaracteresProductoCBPesoCantidad.Size = New System.Drawing.Size(393, 13)
        Me.lblCaracteresProductoCBPesoCantidad.TabIndex = 26
        Me.lblCaracteresProductoCBPesoCantidad.Text = "Caracteres para el código de producto en cód. de barra con PRECIO/CANTIDAD"
        '
        'txtCaracteresProductoCBPesoCantidad
        '
        Me.txtCaracteresProductoCBPesoCantidad.BindearPropiedadControl = Nothing
        Me.txtCaracteresProductoCBPesoCantidad.BindearPropiedadEntidad = Nothing
        Me.txtCaracteresProductoCBPesoCantidad.ForeColorFocus = System.Drawing.Color.Red
        Me.txtCaracteresProductoCBPesoCantidad.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtCaracteresProductoCBPesoCantidad.Formato = "#0.00"
        Me.txtCaracteresProductoCBPesoCantidad.IsDecimal = False
        Me.txtCaracteresProductoCBPesoCantidad.IsNumber = True
        Me.txtCaracteresProductoCBPesoCantidad.IsPK = False
        Me.txtCaracteresProductoCBPesoCantidad.IsRequired = False
        Me.txtCaracteresProductoCBPesoCantidad.Key = ""
        Me.txtCaracteresProductoCBPesoCantidad.LabelAsoc = Me.lblCaracteresProductoCBPesoCantidad
        Me.txtCaracteresProductoCBPesoCantidad.Location = New System.Drawing.Point(446, 131)
        Me.txtCaracteresProductoCBPesoCantidad.MaxLength = 4
        Me.txtCaracteresProductoCBPesoCantidad.Name = "txtCaracteresProductoCBPesoCantidad"
        Me.txtCaracteresProductoCBPesoCantidad.Size = New System.Drawing.Size(45, 20)
        Me.txtCaracteresProductoCBPesoCantidad.TabIndex = 25
        Me.txtCaracteresProductoCBPesoCantidad.Tag = "PRODUCTOIVA"
        Me.txtCaracteresProductoCBPesoCantidad.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.lblProductosCantidadComprasSolapaCompras)
        Me.GroupBox1.Controls.Add(Me.lblProductosCantidadComprasSolapaCompras2)
        Me.GroupBox1.Controls.Add(Me.txtProductosCantidadComprasSolapaCompras)
        Me.GroupBox1.Location = New System.Drawing.Point(445, 318)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(340, 49)
        Me.GroupBox1.TabIndex = 28
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Solapa Compras"
        '
        'lblProductosCantidadComprasSolapaCompras
        '
        Me.lblProductosCantidadComprasSolapaCompras.AutoSize = True
        Me.lblProductosCantidadComprasSolapaCompras.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblProductosCantidadComprasSolapaCompras.LabelAsoc = Nothing
        Me.lblProductosCantidadComprasSolapaCompras.Location = New System.Drawing.Point(9, 23)
        Me.lblProductosCantidadComprasSolapaCompras.Name = "lblProductosCantidadComprasSolapaCompras"
        Me.lblProductosCantidadComprasSolapaCompras.Size = New System.Drawing.Size(77, 13)
        Me.lblProductosCantidadComprasSolapaCompras.TabIndex = 0
        Me.lblProductosCantidadComprasSolapaCompras.Text = "Mostrar últimas"
        '
        'lblProductosCantidadComprasSolapaCompras2
        '
        Me.lblProductosCantidadComprasSolapaCompras2.AutoSize = True
        Me.lblProductosCantidadComprasSolapaCompras2.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblProductosCantidadComprasSolapaCompras2.LabelAsoc = Nothing
        Me.lblProductosCantidadComprasSolapaCompras2.Location = New System.Drawing.Point(143, 23)
        Me.lblProductosCantidadComprasSolapaCompras2.Name = "lblProductosCantidadComprasSolapaCompras2"
        Me.lblProductosCantidadComprasSolapaCompras2.Size = New System.Drawing.Size(129, 13)
        Me.lblProductosCantidadComprasSolapaCompras2.TabIndex = 2
        Me.lblProductosCantidadComprasSolapaCompras2.Text = "Compras (0 oculta solapa)"
        '
        'txtProductosCantidadComprasSolapaCompras
        '
        Me.txtProductosCantidadComprasSolapaCompras.BindearPropiedadControl = Nothing
        Me.txtProductosCantidadComprasSolapaCompras.BindearPropiedadEntidad = Nothing
        Me.txtProductosCantidadComprasSolapaCompras.ForeColorFocus = System.Drawing.Color.Red
        Me.txtProductosCantidadComprasSolapaCompras.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtProductosCantidadComprasSolapaCompras.Formato = "#0.00"
        Me.txtProductosCantidadComprasSolapaCompras.IsDecimal = False
        Me.txtProductosCantidadComprasSolapaCompras.IsNumber = True
        Me.txtProductosCantidadComprasSolapaCompras.IsPK = False
        Me.txtProductosCantidadComprasSolapaCompras.IsRequired = False
        Me.txtProductosCantidadComprasSolapaCompras.Key = ""
        Me.txtProductosCantidadComprasSolapaCompras.LabelAsoc = Me.lblProductosCantidadComprasSolapaCompras
        Me.txtProductosCantidadComprasSolapaCompras.Location = New System.Drawing.Point(92, 19)
        Me.txtProductosCantidadComprasSolapaCompras.MaxLength = 4
        Me.txtProductosCantidadComprasSolapaCompras.Name = "txtProductosCantidadComprasSolapaCompras"
        Me.txtProductosCantidadComprasSolapaCompras.Size = New System.Drawing.Size(45, 20)
        Me.txtProductosCantidadComprasSolapaCompras.TabIndex = 1
        Me.txtProductosCantidadComprasSolapaCompras.Tag = ""
        Me.txtProductosCantidadComprasSolapaCompras.Text = "0"
        Me.txtProductosCantidadComprasSolapaCompras.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'chkOcultarProductosInactivosABMProductos
        '
        Me.chkOcultarProductosInactivosABMProductos.BindearPropiedadControl = Nothing
        Me.chkOcultarProductosInactivosABMProductos.BindearPropiedadEntidad = Nothing
        Me.chkOcultarProductosInactivosABMProductos.ForeColorFocus = System.Drawing.Color.Red
        Me.chkOcultarProductosInactivosABMProductos.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chkOcultarProductosInactivosABMProductos.IsPK = False
        Me.chkOcultarProductosInactivosABMProductos.IsRequired = False
        Me.chkOcultarProductosInactivosABMProductos.Key = Nothing
        Me.chkOcultarProductosInactivosABMProductos.LabelAsoc = Nothing
        Me.chkOcultarProductosInactivosABMProductos.Location = New System.Drawing.Point(445, 377)
        Me.chkOcultarProductosInactivosABMProductos.Name = "chkOcultarProductosInactivosABMProductos"
        Me.chkOcultarProductosInactivosABMProductos.Size = New System.Drawing.Size(277, 20)
        Me.chkOcultarProductosInactivosABMProductos.TabIndex = 29
        Me.chkOcultarProductosInactivosABMProductos.Text = "Ocultar Producto inactivo en Grilla de ABM"
        Me.chkOcultarProductosInactivosABMProductos.UseVisualStyleBackColor = True
        '
        'chbProductoPermiteEsDevolucion
        '
        Me.chbProductoPermiteEsDevolucion.BindearPropiedadControl = Nothing
        Me.chbProductoPermiteEsDevolucion.BindearPropiedadEntidad = Nothing
        Me.chbProductoPermiteEsDevolucion.ForeColorFocus = System.Drawing.Color.Red
        Me.chbProductoPermiteEsDevolucion.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbProductoPermiteEsDevolucion.IsPK = False
        Me.chbProductoPermiteEsDevolucion.IsRequired = False
        Me.chbProductoPermiteEsDevolucion.Key = Nothing
        Me.chbProductoPermiteEsDevolucion.LabelAsoc = Nothing
        Me.chbProductoPermiteEsDevolucion.Location = New System.Drawing.Point(445, 78)
        Me.chbProductoPermiteEsDevolucion.Name = "chbProductoPermiteEsDevolucion"
        Me.chbProductoPermiteEsDevolucion.Size = New System.Drawing.Size(274, 20)
        Me.chbProductoPermiteEsDevolucion.TabIndex = 59
        Me.chbProductoPermiteEsDevolucion.Text = "Producto se puede usar como Devolución"
        Me.chbProductoPermiteEsDevolucion.UseVisualStyleBackColor = True
        '
        'ucConfArchivosProductos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.chbProductoPermiteEsDevolucion)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.lblCaracteresProductoCBPesoCantidad)
        Me.Controls.Add(Me.txtCaracteresProductoCBPesoCantidad)
        Me.Controls.Add(Me.gpbPublicarEn)
        Me.Controls.Add(Me.chbHABILITACODIGOPRODUCTONUMERICO)
        Me.Controls.Add(Me.txtUbicacionProductoPorDefecto)
        Me.Controls.Add(Me.lblUbicacionPorDefecto)
        Me.Controls.Add(Me.lblCaracterProductoObservacion)
        Me.Controls.Add(Me.txtCantidadCaracteresProductoObservacion)
        Me.Controls.Add(Me.chbProductoBuscarPorCodigoExacto)
        Me.Controls.Add(Me.chbEditaProductoModificaHistorial)
        Me.Controls.Add(Me.chbBuscarProductoPorCodigoProveedorHabitual)
        Me.Controls.Add(Me.chbProductoBusquedaCombinaCodigoNombre)
        Me.Controls.Add(Me.lblProductoFormatoLikeBuscarPorNombre)
        Me.Controls.Add(Me.lblProductoFormatoLikeBuscarPorCodigo)
        Me.Controls.Add(Me.chkOcultarProductosInactivosABMProductos)
        Me.Controls.Add(Me.chbProductoUtilizaProductoWeb)
        Me.Controls.Add(Me.txtProductoIVA)
        Me.Controls.Add(Me.chbProductoUtilizaNombreCorto)
        Me.Controls.Add(Me.chbProductoCodigoNumerico)
        Me.Controls.Add(Me.chbProductoUtilizaCantidadesEnteras)
        Me.Controls.Add(Me.chkProductoUtilizaCodigoLargo)
        Me.Controls.Add(Me.chbProductoCodigoDeBarras)
        Me.Controls.Add(Me.chbProductoCodigoQuitarBlancos)
        Me.Controls.Add(Me.lblProductoIVA)
        Me.Controls.Add(Me.chbProductoPermiteEsBonificable)
        Me.Controls.Add(Me.chbProductoPermiteEsCambiable)
        Me.Controls.Add(Me.chbProductoEmbalajeInverso)
        Me.Controls.Add(Me.cmbProductoFormatoLikeBuscarPorNombre)
        Me.Controls.Add(Me.cmbProductoFormatoLikeBuscarPorCodigo)
        Me.Name = "ucConfArchivosProductos"
        Me.Controls.SetChildIndex(Me.cmbProductoFormatoLikeBuscarPorCodigo, 0)
        Me.Controls.SetChildIndex(Me.cmbProductoFormatoLikeBuscarPorNombre, 0)
        Me.Controls.SetChildIndex(Me.chbProductoEmbalajeInverso, 0)
        Me.Controls.SetChildIndex(Me.chbProductoPermiteEsCambiable, 0)
        Me.Controls.SetChildIndex(Me.chbProductoPermiteEsBonificable, 0)
        Me.Controls.SetChildIndex(Me.lblProductoIVA, 0)
        Me.Controls.SetChildIndex(Me.chbProductoCodigoQuitarBlancos, 0)
        Me.Controls.SetChildIndex(Me.chbProductoCodigoDeBarras, 0)
        Me.Controls.SetChildIndex(Me.chkProductoUtilizaCodigoLargo, 0)
        Me.Controls.SetChildIndex(Me.chbProductoUtilizaCantidadesEnteras, 0)
        Me.Controls.SetChildIndex(Me.chbProductoCodigoNumerico, 0)
        Me.Controls.SetChildIndex(Me.chbProductoUtilizaNombreCorto, 0)
        Me.Controls.SetChildIndex(Me.txtProductoIVA, 0)
        Me.Controls.SetChildIndex(Me.chbProductoUtilizaProductoWeb, 0)
        Me.Controls.SetChildIndex(Me.chkOcultarProductosInactivosABMProductos, 0)
        Me.Controls.SetChildIndex(Me.lblProductoFormatoLikeBuscarPorCodigo, 0)
        Me.Controls.SetChildIndex(Me.lblProductoFormatoLikeBuscarPorNombre, 0)
        Me.Controls.SetChildIndex(Me.chbProductoBusquedaCombinaCodigoNombre, 0)
        Me.Controls.SetChildIndex(Me.chbBuscarProductoPorCodigoProveedorHabitual, 0)
        Me.Controls.SetChildIndex(Me.chbEditaProductoModificaHistorial, 0)
        Me.Controls.SetChildIndex(Me.chbProductoBuscarPorCodigoExacto, 0)
        Me.Controls.SetChildIndex(Me.txtCantidadCaracteresProductoObservacion, 0)
        Me.Controls.SetChildIndex(Me.lblCaracterProductoObservacion, 0)
        Me.Controls.SetChildIndex(Me.lblUbicacionPorDefecto, 0)
        Me.Controls.SetChildIndex(Me.txtUbicacionProductoPorDefecto, 0)
        Me.Controls.SetChildIndex(Me.chbHABILITACODIGOPRODUCTONUMERICO, 0)
        Me.Controls.SetChildIndex(Me.gpbPublicarEn, 0)
        Me.Controls.SetChildIndex(Me.txtCaracteresProductoCBPesoCantidad, 0)
        Me.Controls.SetChildIndex(Me.lblCaracteresProductoCBPesoCantidad, 0)
        Me.Controls.SetChildIndex(Me.GroupBox1, 0)
        Me.Controls.SetChildIndex(Me.chbProductoPermiteEsDevolucion, 0)
        Me.gpbPublicarEn.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents gpbPublicarEn As GroupBox
   Friend WithEvents chbAppEmpresarial As Controles.CheckBox
   Friend WithEvents chbSincronizacionSucursal As Controles.CheckBox
   Friend WithEvents chbAppGestión As Controles.CheckBox
   Friend WithEvents chbListaPreciosClientes As Controles.CheckBox
   Friend WithEvents chbBalanza As Controles.CheckBox
   Friend WithEvents chbWebCarrito As Controles.CheckBox
   Friend WithEvents chbHABILITACODIGOPRODUCTONUMERICO As Controles.CheckBox
   Friend WithEvents txtUbicacionProductoPorDefecto As Controles.TextBox
   Friend WithEvents lblUbicacionPorDefecto As Controles.Label
   Friend WithEvents lblCaracterProductoObservacion As Controles.Label
   Friend WithEvents txtCantidadCaracteresProductoObservacion As Controles.TextBox
   Friend WithEvents chbProductoBuscarPorCodigoExacto As Controles.CheckBox
   Friend WithEvents chbEditaProductoModificaHistorial As Controles.CheckBox
   Friend WithEvents chbBuscarProductoPorCodigoProveedorHabitual As Controles.CheckBox
   Friend WithEvents chbProductoBusquedaCombinaCodigoNombre As Controles.CheckBox
   Friend WithEvents lblProductoFormatoLikeBuscarPorNombre As Controles.Label
   Friend WithEvents lblProductoFormatoLikeBuscarPorCodigo As Controles.Label
   Friend WithEvents chbProductoUtilizaProductoWeb As Controles.CheckBox
   Friend WithEvents txtProductoIVA As Controles.TextBox
   Friend WithEvents lblProductoIVA As Controles.Label
   Friend WithEvents chbProductoUtilizaNombreCorto As Controles.CheckBox
   Friend WithEvents chbProductoCodigoNumerico As Controles.CheckBox
   Friend WithEvents chbProductoUtilizaCantidadesEnteras As Controles.CheckBox
   Friend WithEvents chkProductoUtilizaCodigoLargo As Controles.CheckBox
   Friend WithEvents chbProductoCodigoDeBarras As Controles.CheckBox
   Friend WithEvents chbProductoCodigoQuitarBlancos As Controles.CheckBox
   Friend WithEvents chbProductoPermiteEsBonificable As Controles.CheckBox
   Friend WithEvents chbProductoPermiteEsCambiable As Controles.CheckBox
   Friend WithEvents chbProductoEmbalajeInverso As Controles.CheckBox
   Friend WithEvents cmbProductoFormatoLikeBuscarPorNombre As Controles.ComboBox
   Friend WithEvents cmbProductoFormatoLikeBuscarPorCodigo As Controles.ComboBox
    Friend WithEvents lblCaracteresProductoCBPesoCantidad As Controles.Label
    Friend WithEvents txtCaracteresProductoCBPesoCantidad As Controles.TextBox
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents lblProductosCantidadComprasSolapaCompras As Controles.Label
    Friend WithEvents lblProductosCantidadComprasSolapaCompras2 As Controles.Label
    Friend WithEvents txtProductosCantidadComprasSolapaCompras As Controles.TextBox
    Friend WithEvents chbArborea As Controles.CheckBox
    Friend WithEvents chbMercadoLibre As Controles.CheckBox
    Friend WithEvents chbTiendaNube As Controles.CheckBox
    Friend WithEvents chkOcultarProductosInactivosABMProductos As Controles.CheckBox
    Friend WithEvents chbProductoPermiteEsDevolucion As Controles.CheckBox
End Class
