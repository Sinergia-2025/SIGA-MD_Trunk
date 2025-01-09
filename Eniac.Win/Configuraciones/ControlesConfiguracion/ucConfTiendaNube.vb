Public Class ucConfTiendaNube

   Protected Overrides Sub OnInicializando(e As InicializarEventArgs)
      MyBase.OnInicializando(e)
      '-- Carga el combo de Tienda Nube.- -----
      e.Publicos.CargaComboListaDePrecios(cmbTiendaNubeListaPrecios, True, Nothing)
      e.Publicos.CargaComboCategorias(cmbTiendaNubeCategoriaCliente, False, False)
      e.Publicos.CargaComboCategoriasFiscales(cmbTiendaNubeCategoriaFiscalCliente)
      e.Publicos.CargaComboEmpleados(cmbTiendaNubeVendedor, Entidades.Publicos.TiposEmpleados.VENDEDOR)
      e.Publicos.CargaComboTiposComprobantes(cmbTiendaNubePedidosTipoComprobante, True, "VENTAS")
      e.Publicos.CargaComboFormasDePago(cmbTiendaNubePedidosFormaDePago)
      e.Publicos.CargaComboCriticidades(cmbTiendaNubePedidosCriticidad)
      '-- REQ-36468.- -----------------------------------------------------------------------------------------------------------------------------
      e.Publicos.CargaComboDesdeEnum(cmbActualizaProductoDescripcion, GetType(Reglas.Publicos.ActualizarTiendasWeb), , True)
      '-- REQ-38417.- -----------------------------------------------------------------------------------------------------------------------------
      e.Publicos.CargaComboDesdeEnum(cmbPrecioProducto, GetType(Reglas.Publicos.MonedaProductoTiendasWeb), , True)
      '--------------------------------------------------------------------------------------------------------------------------------------------


   End Sub

   Protected Overrides Sub OnCargando(e As CancelableEventArgs)
      MyBase.OnCargando(e)
      '--------------------------------------------------------------------------------------------------------------------------------------------
      txtTiendaNubeURLBase.Text = Reglas.Publicos.TiendasWeb.TiendaNube.TiendaNubeURLBase
      txtTiendaNubeToken.Text = Reglas.Publicos.TiendasWeb.TiendaNube.TiendaNubeToken
      txtTiendaNubeCorreoNotificaciones.Text = Reglas.Publicos.TiendasWeb.TiendaNube.TiendaNubeCorreoNotificaciones
      txtTiendaNubeIdProductoEnvio.Text = Reglas.Publicos.TiendasWeb.TiendaNube.TiendaNubeIdProductoEnvio
      If Reglas.Publicos.TiendasWeb.TiendaNube.TiendaNubeListaDePrecios = -1 Then
         cmbTiendaNubeListaPrecios.SelectedIndex = -1
      Else
         cmbTiendaNubeListaPrecios.SelectedValue = Reglas.Publicos.TiendasWeb.TiendaNube.TiendaNubeListaDePrecios
      End If
      cmbTiendaNubeCategoriaCliente.SelectedValue = Reglas.Publicos.TiendasWeb.TiendaNube.TiendaNubeCategoriaCliente
      cmbTiendaNubeCategoriaFiscalCliente.SelectedValue = Reglas.Publicos.TiendasWeb.TiendaNube.TiendaNubeCategoriaFiscalCliente
      cmbTiendaNubeVendedor.SelectedValue = Reglas.Publicos.TiendasWeb.TiendaNube.TiendaNubeVendedor
      cmbTiendaNubePedidosTipoComprobante.SelectedValue = Reglas.Publicos.TiendasWeb.TiendaNube.TiendaNubePedidosTipoComprobante
      cmbTiendaNubePedidosCriticidad.SelectedValue = Reglas.Publicos.TiendasWeb.TiendaNube.TiendaNubePedidosCriticidad
      cmbTiendaNubePedidosFormaDePago.SelectedValue = Reglas.Publicos.TiendasWeb.TiendaNube.TiendaNubePedidosFormaDePago
      txtTiendaNubeSleepEntreSolicitudes.SetValor(Reglas.Publicos.TiendasWeb.TiendaNube.TiendaNubeSleepEntreSolicitudes)

      '-- REQ-36468.- -----------------------------------------------------------------------------------------------------------------------------
      cmbActualizaProductoDescripcion.SelectedValue = Reglas.Publicos.ActualizacionProductoDescripcion
      '-- REQ-38417.- -----------------------------------------------------------------------------------------------------------------------------
      cmbPrecioProducto.SelectedValue = Reglas.Publicos.PrecioProductoTN
      '--------------------------------------------------------------------------------------------------------------------------------------------
      chbProductoActivoTienda.Checked = Reglas.Publicos.ProductoActivoenTienda
      chbProductoPrecioEmbalaje.Checked = Reglas.Publicos.ProductoPrecioPorEmbalajeTN
   End Sub

   Protected Overrides Sub OnGrabando(e As CancelableEventArgs)
      MyBase.OnGrabando(e)
      '--------------------------------------------------------------------------------------------------------------------------------------------
      ActualizarParametro(Entidades.Parametro.Parametros.TIENDANUBEURLBASE, txtTiendaNubeURLBase, Nothing, lblTiendaNubeURLBase.Text)
      ActualizarParametro(Entidades.Parametro.Parametros.TIENDANUBETOKEN, txtTiendaNubeToken, Nothing, lblTiendaNubeToken.Text)
      ActualizarParametro(Entidades.Parametro.Parametros.TIENDANUBECORREONOTIFICACIONES, txtTiendaNubeCorreoNotificaciones, Nothing, lblTiendaNubeCorreoNotificaciones.Text)
      ActualizarParametro(Entidades.Parametro.Parametros.TIENDANUBEIDPRODUCTOENVIO, txtTiendaNubeIdProductoEnvio, Nothing, lblTiendaNubeIdProductoEnvio.Text)
      If cmbTiendaNubeListaPrecios.SelectedIndex > -1 Then
         '# Si la lista de precios fue modificada, se elimina la fecha de sincronización de la tabla de Fechas Sincronizaciones para que al momento de realizar una nueva subida se actualicen todos los precios de los productos subidos
         If Reglas.Publicos.TiendasWeb.TiendaNube.TiendaNubeListaDePrecios <> CInt(cmbTiendaNubeListaPrecios.SelectedValue) Then
            Dim rFechasSincronizaciones As Reglas.FechasSincronizaciones = New Reglas.FechasSincronizaciones()
            rFechasSincronizaciones.Borrar(New Entidades.FechaSincronizacion With {.SistemaDestino = "TIENDANUBE", .Tabla = "PRODUCTOS"})
         End If
         ActualizarParametro(Of Integer)(Entidades.Parametro.Parametros.TIENDANUBELISTAPRECIOS, cmbTiendaNubeListaPrecios, Nothing, lblTiendaNubeListaPrecios.Text)
      End If
      If cmbTiendaNubeCategoriaCliente.SelectedIndex > -1 Then
         ActualizarParametro(Of Integer)(Entidades.Parametro.Parametros.TIENDANUBECATEGORIACLIENTE, cmbTiendaNubeCategoriaCliente, Nothing, lblTiendaNubeCategoriaCliente.Text)
      End If
      If cmbTiendaNubeCategoriaFiscalCliente.SelectedIndex > -1 Then
         '-- REQ-32999.- ----------------------------------------
         ActualizarParametro(Of Short)(Entidades.Parametro.Parametros.TIENDANUBECATEGORIAFISCALCLIENTE, cmbTiendaNubeCategoriaFiscalCliente, Nothing, lblTiendaNubeCategoriaFiscalCliente.Text)
      End If
      If cmbTiendaNubeVendedor.SelectedIndex > -1 Then
         ActualizarParametro(Of Integer)(Entidades.Parametro.Parametros.TIENDANUBEVENDEDOR, cmbTiendaNubeVendedor, Nothing, lblTiendaNubeVendedor.Text)
      End If
      If cmbTiendaNubePedidosTipoComprobante.SelectedIndex > -1 Then
         ActualizarParametro(Of String)(Entidades.Parametro.Parametros.TIENDANUBEPEDIDOSTIPOCOMPROBANTE, cmbTiendaNubePedidosTipoComprobante, Nothing, lblTiendaNubePedidosTipoComprobante.Text)
      End If
      If cmbTiendaNubePedidosCriticidad.SelectedIndex > -1 Then
         ActualizarParametro(Of String)(Entidades.Parametro.Parametros.TIENDANUBEPEDIDOSCRITICIDAD, cmbTiendaNubePedidosCriticidad, Nothing, lblTiendaNubePedidosCriticidad.Text)
      End If
      If cmbTiendaNubePedidosFormaDePago.SelectedIndex > -1 Then
         '-- REQ-32999.- ----------------------------------------
         ActualizarParametro(Of Integer)(Entidades.Parametro.Parametros.TIENDANUBEPEDIDOSFORMADEPAGO, cmbTiendaNubePedidosFormaDePago, Nothing, lblTiendaNubePedidosFormaDePago.Text)
      End If
      If cmbActualizaProductoDescripcion.SelectedIndex > -1 Then
         '-- REQ-36468.- -------------------------------------------------------------------------------------------------------------------------
         ActualizarParametro(Of String)(Entidades.Parametro.Parametros.TIENDANUBEACTUALIZAPRODUCTODESCRIPCION, cmbActualizaProductoDescripcion, Nothing, lblActualizaProductoDescripcion.Text)
      End If
      If cmbPrecioProducto.SelectedIndex > -1 Then
         '-- REQ-38417.- -------------------------------------------------------------------------------------------------------------------------
         ActualizarParametro(Of String)(Entidades.Parametro.Parametros.TIENDANUBEPRECIOPRODUCTO, cmbPrecioProducto, Nothing, lblPrecioProducto.Text)
      End If
      '--------------------------------------------------------------------------------------------------------------------------------------------
      ActualizarParametro(Entidades.Parametro.Parametros.TIENDANUBEPRODUCTOACTIVOWEB, chbProductoActivoTienda, Nothing, chbProductoActivoTienda.Text)
      ActualizarParametro(Entidades.Parametro.Parametros.TIENDANUBESLEEPENTRESOLICITUDES, txtTiendaNubeSleepEntreSolicitudes, Nothing, lblTiendaNubeSleepEntreSolicitudes.Text)
      ActualizarParametro(Entidades.Parametro.Parametros.TIENDANUBEPRECIOPOREMBALAJE, chbProductoPrecioEmbalaje, Nothing, chbProductoPrecioEmbalaje.Text)

   End Sub
End Class
