Public Class ucConfVentas4

   Protected Overrides Sub OnInicializando(e As InicializarEventArgs)
      MyBase.OnInicializando(e)
      e.Publicos.CargaComboDesdeEnum(cmbVendedorComprobanteInvocado, GetType(Entidades.Publicos.VendedorComprobanteInvocado), , True)
      e.Publicos.CargaComboDesdeEnum(cmbCotizacionDolarComprobanteInvocado, GetType(Entidades.Publicos.CotizacionDolarComprobanteInvocado))
      e.Publicos.CargaComboDesdeEnum(cmbCotizacionDolarPedidoInvocado, GetType(Entidades.Publicos.CotizacionDolarComprobanteInvocado))
      e.Publicos.CargaComboDesdeEnum(cmbCotizacionDolarComprobantePesosInvocado, GetType(Entidades.Publicos.CotizacionDolarComprobanteInvocado))
      e.Publicos.CargaComboDesdeEnum(cmbCotizacionDolarPedidoPesosInvocado, GetType(Entidades.Publicos.CotizacionDolarComprobanteInvocado))
   End Sub

   Protected Overrides Sub OnCargando(e As CancelableEventArgs)
      MyBase.OnCargando(e)

      '------------------------------------------------------------------------------------------------------
      chkUtilizaInteresesTarjetas.Checked = Reglas.Publicos.UtilizaInteresesTarjetas
      chbFacturacionCargarReciboNC.Checked = Reglas.Publicos.CargaReciboLuegoDeNC
      chbFacturacionSolicitaNumeroComprobante.Checked = Reglas.Publicos.Facturacion.FacturacionSolicitaNumeroDeComprobante
      chbFacturacionSolicitaFormaDePago.Checked = Reglas.Publicos.Facturacion.FacturacionSolicitaFormaDePago
      chbFacturacionSolicitaListaDePrecio.Checked = Reglas.Publicos.Facturacion.FacturacionSolicitaListaDePrecios
      chbFacturacionSolicitaDiaFijo.Checked = Reglas.Publicos.Facturacion.FacturacionCtaCteSolicitaDiaFijo
      chbFacturacionDescuentoImpIntIgualado.Checked = Reglas.Publicos.Facturacion.FacturacionDescuentoImpIntIgualado
      chbFacturacionCoeficienteNegativoRecuperaPrecioUltimaVenta.Checked = Reglas.Publicos.Facturacion.FacturacionCoeficienteNegativoRecuperaPrecioUltimaVenta
      chbEnvioMasivoComprobantesAdjuntaCtaCte.Checked = Reglas.Publicos.EnvioMasivoComprobantesAdjuntaCtaCte
      '-- REQ-36082.- ---------------------------------------------------------------------------------------
      chbFacturacionUtilizaCanje.Checked = Reglas.Publicos.Facturacion.FacturacionUtilizaCanje
      '-- REQ-36082.- ---------------------------------------------------------------------------------------
      chbFacturacionCantidadPorDefecto.Checked = Reglas.Publicos.Facturacion.FacturacionCantidadPorDefecto
      '------------------------------------------------------------------------------------------------------

      'Columna 2

      chbFacturacionDescuentosAgrupaCantidadesPorRubro.Checked = Reglas.Publicos.Facturacion.FacturacionDescuentosAgrupaCantidadesPorRubro
      chbFacturacionDescuentoRecargo2CargaManual.Checked = Reglas.Publicos.Facturacion.FacturacionDescuentoRecargo2CargaManual
      chbSiTieneDescRecPorCantidadIgnoraOtros.Checked = Reglas.Publicos.SiTieneDescRecPorCantidadIgnoraOtros
      chbFacturacionPedidosInvocadosMantieneFormaPago.Checked = Reglas.Publicos.MantieneFormaPagoPedidosInvocados
      chbFacturacionInvocadosMantieneFormaPago.Checked = Reglas.Publicos.MantieneFormaPagoInvocados
      '-- REQ-33460.- -------------------------------------------------------------------------------
      chbFacturacionInvocadosRelacionaCabecera.Checked = Reglas.Publicos.Facturacion.FacturacionRelacionaCabecera
      '----------------------------------------------------------------------------------------------
      chbFacturacionInvocarPedidosDeOtrasSucursales.Checked = Reglas.Publicos.Facturacion.FacturacionInvocarPedidosDeOtrasSucursales
      chbFacturacionPermiteCambiarClienteVinculado.Checked = Reglas.Publicos.Facturacion.FacturacionPermiteCambiarClienteVinculado
      chbFacturacionSolicitaVendedorPorClave.Checked = Reglas.Publicos.Facturacion.FacturacionSolicitaVendedorPorClave
      chbFacturacionValidarCuponLote.Checked = Reglas.Publicos.Facturacion.FacturacionTarjetasValidaCuponLote
      '-- REQ-33202.- ---------------------------------------------------------------------------------------
      chbFacturacionAgrupaProductos.Checked = Reglas.Publicos.Facturacion.FacturacionAgrupaCantidadesProductos
      chbFacturacionPermiteAplicarSaldoCtaCte.Checked = Reglas.Publicos.Facturacion.FacturacionPermiteAplicarSaldoCtaCte
      '-- REQ-33223.- ---------------------------------------------------------------------------------------
      txtRangoFechaInvocaPedido.Text = Reglas.Publicos.Facturacion.FacturacionRangoFechaFiltroInvocarPedidos.ToString()
      '------------------------------------------------------------------------------------------------------
      '-- REQ-33678.- ------------------------------------------
      cmbVendedorComprobanteInvocado.SelectedValue = Reglas.Publicos.Facturacion.MantieneVendedorInvocados
      '---------------------------------------------------------
      cmbCotizacionDolarComprobanteInvocado.SelectedValue = Reglas.Publicos.Facturacion.CotizacionDolarComprobanteInvocado
      cmbCotizacionDolarPedidoInvocado.SelectedValue = Reglas.Publicos.Facturacion.CotizacionDolarPedidoInvocado

      cmbCotizacionDolarComprobantePesosInvocado.SelectedValue = Reglas.Publicos.Facturacion.CotizacionDolarComprobantePesosInvocado
      cmbCotizacionDolarPedidoPesosInvocado.SelectedValue = Reglas.Publicos.Facturacion.CotizacionDolarPedidoPesosInvocado
   End Sub

   Protected Overrides Sub OnGrabando(e As CancelableEventArgs)
      MyBase.OnGrabando(e)

      ActualizarParametro(Entidades.Parametro.Parametros.FACTURACIONUTILIZAINTERESESTARJETAS, chkUtilizaInteresesTarjetas, Nothing, chkUtilizaInteresesTarjetas.Text)
      ActualizarParametro(Entidades.Parametro.Parametros.FACTURACIONCARGARECIBOLUEGONC, chbFacturacionCargarReciboNC, Nothing, chbFacturacionCargarReciboNC.Text)
      ActualizarParametro(Entidades.Parametro.Parametros.FACTURACIONSOLICITANUMERODECOMPROBANTE, chbFacturacionSolicitaNumeroComprobante, Nothing, chbFacturacionSolicitaNumeroComprobante.Text)
      ActualizarParametro(Entidades.Parametro.Parametros.FACTURACIONSOLICITAFORMADEPAGO, chbFacturacionSolicitaFormaDePago, Nothing, chbFacturacionSolicitaFormaDePago.Text)
      ActualizarParametro(Entidades.Parametro.Parametros.FACTURACIONSOLICITALISTADEPRECIOS, chbFacturacionSolicitaListaDePrecio, Nothing, chbFacturacionSolicitaListaDePrecio.Text)
      ActualizarParametro(Entidades.Parametro.Parametros.FACTURACIONCTACTESOLICITADIAFIJO, chbFacturacionSolicitaDiaFijo, Nothing, chbFacturacionSolicitaDiaFijo.Text)
      ActualizarParametro(Entidades.Parametro.Parametros.FACTURACIONDESCUENTOIMPINTIGUALADO, chbFacturacionDescuentoImpIntIgualado, Nothing, chbFacturacionDescuentoImpIntIgualado.Text)
      ActualizarParametro(Entidades.Parametro.Parametros.FACTURACIONCOEFNEGATIVORECUPERAPRECIOULTIMAVENTA, chbFacturacionCoeficienteNegativoRecuperaPrecioUltimaVenta, Nothing, chbFacturacionCoeficienteNegativoRecuperaPrecioUltimaVenta.Text)
      ActualizarParametro(Entidades.Parametro.Parametros.ENVIOMASIVOCOMPROBANTESADJUNTACTACTE, chbEnvioMasivoComprobantesAdjuntaCtaCte, Nothing, chbEnvioMasivoComprobantesAdjuntaCtaCte.Text)


      'Columna 2

      ActualizarParametro(Entidades.Parametro.Parametros.FACTURACIONDESCUENTOSAGRUPACANTIDADESPORRUBRO, chbFacturacionDescuentosAgrupaCantidadesPorRubro, Nothing, chbFacturacionDescuentosAgrupaCantidadesPorRubro.Text)
      ActualizarParametro(Entidades.Parametro.Parametros.FACTURACIONDESCUENTORECARGO2CARGAMANUAL, chbFacturacionDescuentoRecargo2CargaManual, Nothing, chbFacturacionDescuentoRecargo2CargaManual.Text)
      ActualizarParametro(Entidades.Parametro.Parametros.SITIENEDESCRECPORCANTIDADIGNORAOTROS, chbSiTieneDescRecPorCantidadIgnoraOtros, Nothing, chbSiTieneDescRecPorCantidadIgnoraOtros.Text)
      ActualizarParametro(Entidades.Parametro.Parametros.FACTURACIONPEDIDOSINVOCADOSMANTIENEFORMAPAGO, chbFacturacionPedidosInvocadosMantieneFormaPago, Nothing, chbFacturacionPedidosInvocadosMantieneFormaPago.Text)
      ActualizarParametro(Entidades.Parametro.Parametros.FACTURACIONINVOCADOSMANTIENEFORMAPAGO, chbFacturacionInvocadosMantieneFormaPago, Nothing, chbFacturacionInvocadosMantieneFormaPago.Text)
      '-- REQ-33460.- -------------------------------------------------------------------------------
      ActualizarParametro(Entidades.Parametro.Parametros.FACTURACIONINVOCADOSRELACIONACABECERA, chbFacturacionInvocadosRelacionaCabecera, Nothing, chbFacturacionInvocadosRelacionaCabecera.Text)
      '----------------------------------------------------------------------------------------------
      ActualizarParametro(Entidades.Parametro.Parametros.FACTURACIONINVOCARPEDIDOSDEOTRASSUCURSALES, chbFacturacionInvocarPedidosDeOtrasSucursales, Nothing, chbFacturacionInvocarPedidosDeOtrasSucursales.Text)
      ActualizarParametro(Entidades.Parametro.Parametros.FACTURACIONPERMITECAMBIARCLIENTEVINCULADO, chbFacturacionPermiteCambiarClienteVinculado, Nothing, chbFacturacionPermiteCambiarClienteVinculado.Text)
      ActualizarParametro(Entidades.Parametro.Parametros.FACTURACIONSOLICITAVENDEDORPORCLAVE, chbFacturacionSolicitaVendedorPorClave, Nothing, chbFacturacionSolicitaVendedorPorClave.Text)
      ActualizarParametro(Entidades.Parametro.Parametros.FACTURACIONTARJETASVALIDACUPONLOTE, chbFacturacionValidarCuponLote, Nothing, chbFacturacionValidarCuponLote.Text)
      '-- REQ-36082.- ---------------------------------------------------------------------------------------
      ActualizarParametro(Entidades.Parametro.Parametros.FACTURACIONUTILIZACANJE, chbFacturacionUtilizaCanje, Nothing, chbFacturacionUtilizaCanje.Text)
      '-- REQ-38566.- ---------------------------------------------------------------------------------------
      ActualizarParametro(Entidades.Parametro.Parametros.FACTURACIONCANTIDADDEFECTO, chbFacturacionCantidadPorDefecto, Nothing, chbFacturacionCantidadPorDefecto.Text)
      '------------------------------------------------------------------------------------------------------
      ActualizarParametro(Entidades.Parametro.Parametros.FACTURACIONAGRUPACANTIDADESPRODUCTOS, chbFacturacionAgrupaProductos, Nothing, chbFacturacionAgrupaProductos.Text)
      ActualizarParametro(Entidades.Parametro.Parametros.FACTURACIONPERMITEAPLICARSALDOCTACTE, chbFacturacionPermiteAplicarSaldoCtaCte, Nothing, chbFacturacionPermiteAplicarSaldoCtaCte.Text)
      '-- REQ-33223.- ---------------------------------------------------------------------------------------
      ActualizarParametro(Entidades.Parametro.Parametros.FACTURACIONRANGOFECHAFILTROINVOCARPEDIDOS, txtRangoFechaInvocaPedido, Nothing, lblRangoFechaInvocaPedido.Text)
      '-- REQ-33678.- ---------------------------------------------------------------------
      If cmbVendedorComprobanteInvocado.SelectedIndex > -1 Then
         ActualizarParametro(Of String)(Entidades.Parametro.Parametros.FACTURACIONINVOCADOSMANTIENEVENDEDOR, cmbVendedorComprobanteInvocado, Nothing, lblVendedorComprobanteInvocado.Text)
      End If
      '------------------------------------------------------------------------------------
      ActualizarParametro(Of Entidades.Publicos.CotizacionDolarComprobanteInvocado)(Entidades.Parametro.Parametros.COTIZACIONDOLARCOMPROBANTEINVOCADO, cmbCotizacionDolarComprobanteInvocado, Nothing, lblCotizacionDolarComprobanteInvocado.Text)
      ActualizarParametro(Of Entidades.Publicos.CotizacionDolarComprobanteInvocado)(Entidades.Parametro.Parametros.COTIZACIONDOLARPEDIDOINVOCADO, cmbCotizacionDolarPedidoInvocado, Nothing, lblCotizacionDolarPedidoInvocado.Text)

      ActualizarParametro(Of Entidades.Publicos.CotizacionDolarComprobanteInvocado)(Entidades.Parametro.Parametros.COTIZACIONDOLARCOMPROBANTEPESOSINVOCADO, cmbCotizacionDolarComprobantePesosInvocado, Nothing, lblCotizacionDolarComprobantePesosInvocado.Text)
      ActualizarParametro(Of Entidades.Publicos.CotizacionDolarComprobanteInvocado)(Entidades.Parametro.Parametros.COTIZACIONDOLARPEDIDOPESOSINVOCADO, cmbCotizacionDolarPedidoPesosInvocado, Nothing, lblCotizacionDolarPedidoPesosInvocado.Text)

   End Sub

End Class