Public Class ucConfMercadoLibre
   Protected Overrides Sub OnInicializando(e As InicializarEventArgs)
      MyBase.OnInicializando(e)
      '-- Carga el combo de Mercado Libre.- -----
      Dim blnMiraUsuario As Boolean = False, blnMiraPC As Boolean = Not Reglas.Publicos.CtaCteProv.PagoIgnorarPCdeCaja, blnCajasModificables As Boolean = False
      '# Mercado Libre
      e.Publicos.CargaComboCategorias(cmbMercadoLibreCategoriaCliente, False, False)
      e.Publicos.CargaComboCategoriasFiscales(cmbMercadoLibreCategoriaFiscalCliente)
      e.Publicos.CargaComboListaDePrecios(cmbMercadoLibreListaPrecios, True, Nothing)
      e.Publicos.CargaComboEmpleados(cmbMercadoLibreVendedor, Entidades.Publicos.TiposEmpleados.VENDEDOR)
      e.Publicos.CargaComboCajas(cmbCajasML, actual.Sucursal.IdSucursal, blnMiraUsuario, blnMiraPC, blnCajasModificables)
      e.Publicos.CargaComboTiposComprobantes(cmbMercadoLibrePedidosTipoComprobante, True, "VENTAS")
      e.Publicos.CargaComboFormasDePago(cmbMercadoLibrePedidosFormaDePago)
      e.Publicos.CargaComboCriticidades(cmbMercadoLibrePedidosCriticidad)
      '------------------------------------------
   End Sub

   Protected Overrides Sub OnCargando(e As CancelableEventArgs)
      MyBase.OnCargando(e)
      '--------------------------------------------------------------------------------------------------------------------------------------------
      txtMercadoLibreURLBase.Text = Reglas.Publicos.TiendasWeb.MercadoLibre.MercadoLibreURLBase
      txtMercadoLibreToken.Text = Reglas.Publicos.TiendasWeb.MercadoLibre.MercadoLibreToken
      txtMercadoLibreCorreoNotificaciones.Text = Reglas.Publicos.TiendasWeb.MercadoLibre.MercadoLibreCorreoNotificaciones
      txtMercadoLibreIdProductoEnvio.Text = Reglas.Publicos.TiendasWeb.MercadoLibre.MercadoLibreIdProductoEnvio
      txtCodigoRefreshTokenML.Text = Reglas.Publicos.TiendasWeb.MercadoLibre.MercadoLibreCodigoRefreshTokenML
      txtFechaRefreshTokenML.Text = Reglas.Publicos.TiendasWeb.MercadoLibre.MercadoLibreFechaRefreshTokenML
      txtCodigoImagenDefaultML.Text = Reglas.Publicos.TiendasWeb.MercadoLibre.MercadoLibreImagenDefaultML
      txtCodigoResellerML.Text = Reglas.Publicos.TiendasWeb.MercadoLibre.MercadoLibreCodigoResellerML
      txtCategoriaDefaultML.Text = Reglas.Publicos.TiendasWeb.MercadoLibre.MercadoLibreCategoriaDefaultML
      txtCodigoAplicationIDML.Text = Reglas.Publicos.TiendasWeb.MercadoLibre.MercadoLibreCodigoAppIdML
      txtCodigoClientSecretML.Text = Reglas.Publicos.TiendasWeb.MercadoLibre.MercadoLibreCodigoSecretML
      If Reglas.Publicos.TiendasWeb.MercadoLibre.MercadoLibreListaDePrecios = -1 Then
         cmbMercadoLibreListaPrecios.SelectedIndex = -1
      Else
         cmbMercadoLibreListaPrecios.SelectedValue = Reglas.Publicos.TiendasWeb.MercadoLibre.MercadoLibreListaDePrecios
      End If
      cmbMercadoLibreCategoriaCliente.SelectedValue = Reglas.Publicos.TiendasWeb.MercadoLibre.MercadoLibreCategoriaCliente
      cmbMercadoLibreCategoriaFiscalCliente.SelectedValue = Reglas.Publicos.TiendasWeb.MercadoLibre.MercadoLibreCategoriaFiscalCliente
      cmbMercadoLibreVendedor.SelectedValue = Reglas.Publicos.TiendasWeb.MercadoLibre.MercadoLibreVendedor
      cmbCajasML.SelectedValue = Reglas.Publicos.TiendasWeb.MercadoLibre.MercadoLibreCajaDefault
      cmbMercadoLibrePedidosTipoComprobante.SelectedValue = Reglas.Publicos.TiendasWeb.MercadoLibre.MercadoLibrePedidosTipoComprobante
      cmbMercadoLibrePedidosCriticidad.SelectedValue = Reglas.Publicos.TiendasWeb.MercadoLibre.MercadoLibrePedidosCriticidad
      cmbMercadoLibrePedidosFormaDePago.SelectedValue = Reglas.Publicos.TiendasWeb.MercadoLibre.MercadoLibrePedidosFormaDePago
      chbProductoPrecioEmbalaje.Checked = Reglas.Publicos.TiendasWeb.MercadoLibre.MercadoLibrePrecioPorEmbalaje
      '--------------------------------------------------------------------------------------------------------------------------------------------
   End Sub

   Protected Overrides Sub OnGrabando(e As CancelableEventArgs)
      MyBase.OnGrabando(e)
      '# Mercado Libre
      ActualizarParametro(Entidades.Parametro.Parametros.MERCADOLIBREURLBASE, txtMercadoLibreURLBase, Nothing, txtMercadoLibreURLBase.Text)
      ActualizarParametro(Entidades.Parametro.Parametros.MERCADOLIBRETOKEN, txtMercadoLibreToken, Nothing, lblMercadoLibreToken.Text)
      ActualizarParametro(Entidades.Parametro.Parametros.MERCADOLIBRECORREONOTIFICACIONES, txtMercadoLibreCorreoNotificaciones, Nothing, lblMercadoLibreCorreoNotificaciones.Text)
      ActualizarParametro(Entidades.Parametro.Parametros.MERCADOLIBREIDPRODUCTOENVIO, txtMercadoLibreIdProductoEnvio, Nothing, lblMercadoLibreIdProductoEnvio.Text)
      ActualizarParametro(Entidades.Parametro.Parametros.MERCADOLIBREREFRESHTOKEN, txtCodigoRefreshTokenML, Nothing, lblCodigoRefreshTokenML.Text)
      ActualizarParametro(Entidades.Parametro.Parametros.MERCADOLIBREFECHATOKEN, txtFechaRefreshTokenML, Nothing, lblFechaRefreshTokenML.Text)
      ActualizarParametro(Entidades.Parametro.Parametros.MERCADOLIBREIMAGENDEFAULT, txtCodigoImagenDefaultML, Nothing, lblCodigoImagenDefaultML.Text)
      ActualizarParametro(Entidades.Parametro.Parametros.MERCADOLIBRECODIGORESELLER, txtCodigoResellerML, Nothing, lblCodigoResellerML.Text)
      ActualizarParametro(Entidades.Parametro.Parametros.MERCADOLIBRECATEGORIADEFAULT, txtCategoriaDefaultML, Nothing, lblCategoriaDefaultML.Text)
      ActualizarParametro(Entidades.Parametro.Parametros.MERCADOLIBREAPPID, txtCodigoAplicationIDML, Nothing, lblCodigoAplicationIDML.Text)
      ActualizarParametro(Entidades.Parametro.Parametros.MERCADOLIBRESECRETKEY, txtCodigoClientSecretML, Nothing, lblCodigoClientSecretML.Text)
      If cmbMercadoLibreListaPrecios.SelectedIndex > -1 Then
         '# Si la lista de precios fue modificada, se elimina la fecha de sincronización de la tabla de Fechas Sincronizaciones para que al momento de realizar una nueva subida se actualicen todos los precios de los productos subidos
         If Reglas.Publicos.TiendasWeb.MercadoLibre.MercadoLibreListaDePrecios <> CInt(cmbMercadoLibreListaPrecios.SelectedValue) Then
            Dim rFechasSincronizaciones As Reglas.FechasSincronizaciones = New Reglas.FechasSincronizaciones()
            rFechasSincronizaciones.Borrar(New Entidades.FechaSincronizacion With {.SistemaDestino = "MERCADOLIBRE", .Tabla = "PRODUCTOS"})
         End If
         ActualizarParametro(Of Integer)(Entidades.Parametro.Parametros.MERCADOLIBRELISTAPRECIOS, cmbMercadoLibreListaPrecios, Nothing, lblMercadoLibreListaPrecios.Text)
      End If
      If cmbMercadoLibreCategoriaCliente.SelectedIndex > -1 Then
         ActualizarParametro(Of Integer)(Entidades.Parametro.Parametros.MERCADOLIBRECATEGORIACLIENTE, cmbMercadoLibreCategoriaCliente, Nothing, lblMercadoLibreCategoriaCliente.Text)
      End If
      If cmbMercadoLibreCategoriaFiscalCliente.SelectedIndex > -1 Then
         '-- REQ-32999.- ----------------------------------------
         ActualizarParametro(Of Short)(Entidades.Parametro.Parametros.MERCADOLIBRECATEGORIAFISCALCLIENTE, cmbMercadoLibreCategoriaFiscalCliente, Nothing, lblMercadoLibreCategoriaFiscalCliente.Text)
      End If
      If cmbMercadoLibreVendedor.SelectedIndex > -1 Then
         ActualizarParametro(Of Integer)(Entidades.Parametro.Parametros.MERCADOLIBREVENDEDOR, cmbMercadoLibreVendedor, Nothing, lblMercadoLibreVendedor.Text)
      End If
      If cmbCajasML.SelectedIndex > -1 Then
         ActualizarParametro(Of Integer)(Entidades.Parametro.Parametros.MERCADOLIBRECAJADEFAULT, cmbCajasML, Nothing, lblCajasML.Text)
      End If

      If cmbMercadoLibrePedidosTipoComprobante.SelectedIndex > -1 Then
         ActualizarParametro(Of String)(Entidades.Parametro.Parametros.MERCADOLIBREPEDIDOSTIPOCOMPROBANTE, cmbMercadoLibrePedidosTipoComprobante, Nothing, lblMercadoLibrePedidosTipoComprobante.Text)
      End If
      If cmbMercadoLibrePedidosCriticidad.SelectedIndex > -1 Then
         ActualizarParametro(Of String)(Entidades.Parametro.Parametros.MERCADOLIBREPEDIDOSCRITICIDAD, cmbMercadoLibrePedidosCriticidad, Nothing, lblMercadoLibrePedidosCriticidad.Text)
      End If
      If cmbMercadoLibrePedidosFormaDePago.SelectedIndex > -1 Then
         ActualizarParametro(Of Integer)(Entidades.Parametro.Parametros.MERCADOLIBREPEDIDOSFORMADEPAGO, cmbMercadoLibrePedidosFormaDePago, Nothing, lblMercadoLibrePedidosFormaDePago.Text)
      End If
      ActualizarParametro(Entidades.Parametro.Parametros.MERCADOLIBREPRECIOPOREMBALAJE, chbProductoPrecioEmbalaje, Nothing, chbProductoPrecioEmbalaje.Text)

      '---------------------
   End Sub
End Class
