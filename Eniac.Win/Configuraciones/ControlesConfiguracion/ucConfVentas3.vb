Public Class ucConfVentas3
   Protected Overrides Sub OnInicializando(e As InicializarEventArgs)
      MyBase.OnInicializando(e)

      e.Publicos.CargaComboMonedas1(cmbMonedaPorDefecto)

   End Sub

   Protected Overrides Sub OnCargando(e As CancelableEventArgs)
      MyBase.OnCargando(e)

      txtCantidadEnterosCotizacionDolar.Text = Reglas.Publicos.Facturacion.FacturacionCantidadEnterosEnCotizacionDolar
      txtCantidadEnterosCantidad.Text = Reglas.Publicos.Facturacion.FacturacionCantidadEnterosEnCantidad.ToString()

      txtFacturacionDecimalesRedondeoEnPrecio.Text = Reglas.Publicos.Facturacion.Redondeo.FacturacionDecimalesRedondeoEnPrecio.ToString()
      txtFacturacionDecimalesMostrarEnItems.Text = Reglas.Publicos.Facturacion.Redondeo.FacturacionDecimalesEnPrecio.ToString()
      txtFacturacionDecimalesGrabarDetalleEnPrecio.Text = Reglas.Publicos.Facturacion.Redondeo.FacturacionDecimalesGrabarDetalleEnPrecio.ToString()
      txtFacturacionDecimalesEnTotalXProducto.Text = Reglas.Publicos.Facturacion.Redondeo.FacturacionDecimalesEnTotalXProducto.ToString()

      txtFacturacionDecimalesRedondeoEnCantidad.Text = Reglas.Publicos.Facturacion.Redondeo.FacturacionDecimalesRedondeoEnCantidad.ToString()
      txtFacturacionDecimalesMostrarEnCantidad.Text = Reglas.Publicos.Facturacion.Redondeo.FacturacionDecimalesMostrarEnCantidad.ToString()
      txtFacturacionDecimalesEnDescRec.Text = Reglas.Publicos.Facturacion.Redondeo.FacturacionDecimalesEnDescRec.ToString()
      txtCantidadDecimalesCotizacionDolar.Text = Reglas.Publicos.Facturacion.FacturacionCantidadDecimalesEnCotizacionDolar

      txtFacturacionCantidadCaracteresObservaciones.Text = Reglas.Publicos.Facturacion.FacturacionCantidadCaracteresObservaciones.ToString()

      chbFacturacionPosicionarNombreProducto.Checked = Reglas.Publicos.Facturacion.FacturacionPermitePosicionarNombreProducto
      chbFacturacionRapidaRecalcularEfectivoAlCargarTarjeta.Checked = Reglas.Publicos.Facturacion.Rapida.FacturacionRapidaRecalcularEfectivoAlCargarTarjeta

      Select Case Publicos.ValorPorDefectoEnResumenDeVentas
         Case "PorFechas"
            rdbPorFechas.Checked = True
         Case "PorPeriodoFiscal"
            rdbPorPeriodoFiscal.Checked = True
         Case Else
            rdbAmbos.Checked = True
      End Select

      txtCantidadLineasEvaluarDescRecarg.Text = Reglas.Publicos.CantidadLineasDeProductosAEvaluarParaDescRecarg.ToString()
      txtPorcentajeDescRecargPorLineaDeProducto.Text = Reglas.Publicos.PorcentajeDeDescRecargPorLineaDeProducto.ToString()
      chbFacturacionProductoModificaDescripcionCargaPrecioActual.Checked = Reglas.Publicos.Facturacion.FacturacionProductoModificaDescripcionCargaPrecioActual


      'Columna 2
      txtReemplazarComprobanteTipoComprobanteOrigen.Text = Reglas.Publicos.ReemplazarComprobanteTipoComprobanteOrigen
      txtReemplazarComprobanteTipoComprobanteDestino.Text = Reglas.Publicos.ReemplazarComprobanteTipoComprobanteDestino
      chbReemplazarComprobanteReaplicaRecibos.Checked = Reglas.Publicos.ReemplazarComprobanteReaplicaRecibos

      chbFacturacionSeleccionLoteManual.Checked = Reglas.Publicos.Facturacion.FacturacionSeleccionManualLoteProducto
      chbProductoCodigoBarraPrecioRespetaEtiqueta.Checked = Reglas.Publicos.Facturacion.ProductoCodigoBarraPrecioRespetaEtiqueta()
      chbFacturacionModDescripcionAcumulaProd.Checked = Reglas.Publicos.Facturacion.FacturacionModificaDescriAcumulaProducto
      chbFacturacionSaldoIncluyeCh3ros.Checked = Reglas.Publicos.Facturacion.FacturacionSaldoCtaCteIncluyeCh3ros
      chbInfVentasAfectaCaja.Checked = Publicos.FacturacionInformeVentasAfectaCajaSI
      chbFacturacionDetallaChTarjetaFactura.Checked = Reglas.Publicos.Facturacion.FacturacionDetallaChequesyTarjetas
      txtCantidadItemsAMostrar.Text = Reglas.Publicos.Facturacion.CantMaxItemsDetallaChequesyTarjetas.ToString()

      txtFacturacionEnvioMailCopiaOculta.Text = Reglas.Publicos.Facturacion.FacturacionEnvioMailCopiaOculta
      txtFacturacionAsuntoEnvioMasivoEmail.Text = Reglas.Publicos.Facturacion.FacturacionAsuntoEnvioMasivoEmail
      cmbMonedaPorDefecto.SelectedValue = Reglas.Publicos.Facturacion.FacturacionMonedaPorDefecto

      txtCodigoProductoInvocacionMasiva.Text = Reglas.Publicos.CodigoProductoDRInvocacionMasiva.ToString()
      txtPorcentajeDRInvocacionMasiva.Text = Reglas.Publicos.PorcentajeDRInvocacionMasiva.ToString()

   End Sub

   Protected Overrides Sub OnValidando(e As ValidacionEventArgs)
      MyBase.OnValidando(e)

      If txtFacturacionDecimalesRedondeoEnPrecio.ValorNumericoPorDefecto(0I) < 4 Then
         e.AgregarError("El Redondeo en Precio no puede ser menor a 4")
         txtFacturacionDecimalesRedondeoEnPrecio.Focus()
      End If

      Dim facturacionCantidadCaracteresObservaciones = txtFacturacionCantidadCaracteresObservaciones.ValorNumericoPorDefecto(0I)
      If facturacionCantidadCaracteresObservaciones > 999 Then
         e.AgregarError("Cantidad caracteres en Observaciones ser mayor a 999")
         txtFacturacionCantidadCaracteresObservaciones.Focus()
      End If
      If facturacionCantidadCaracteresObservaciones < 1 Then
         e.AgregarError("Cantidad caracteres en Observaciones ser menor a 1")
         txtFacturacionCantidadCaracteresObservaciones.Focus()
      End If

   End Sub

   Protected Overrides Sub OnGrabando(e As CancelableEventArgs)
      MyBase.OnGrabando(e)

      ' # Cotización Dolar
      ActualizarParametro(Entidades.Parametro.Parametros.FACTURACIONCANTIDADENTEROSENCOTIZACIONDOLAR, txtCantidadEnterosCotizacionDolar, Nothing, lblCantidadEnterosCotizacionDolar.Text)
      ActualizarParametro(Entidades.Parametro.Parametros.FACTURACIONCANTIDADENTEROSENCANTIDAD, txtCantidadEnterosCantidad, Nothing, String.Format("{0} en {1}", grpCantidadEnteros.Text, lblCantidadEnterosCantidad.Text))

      ActualizarParametro(Entidades.Parametro.Parametros.FACTURACIONDECIMALESREDONDEOENPRECIO, txtFacturacionDecimalesRedondeoEnPrecio, Nothing, lblFacturacionDecimalesRedondeoEnPrecio.Text)
      ActualizarParametro(Entidades.Parametro.Parametros.FACTURACIONDECIMALESENPRECIO, txtFacturacionDecimalesMostrarEnItems, Nothing, lblFacturacionDecimalesMostrarEnItems.Text)
      ActualizarParametro(Entidades.Parametro.Parametros.FACTURACIONDECIMALESENTOTALXPRODUCTO, txtFacturacionDecimalesEnTotalXProducto, Nothing, lblFacturacionDecimalesEnTotalXProducto.Text)
      ActualizarParametro(Entidades.Parametro.Parametros.FACTURACIONDECIMALESGRABARDETALLEENPRECIO, txtFacturacionDecimalesGrabarDetalleEnPrecio, Nothing, lblFacturacionDecimalesGrabarDetalleEnPrecio.Text)

      ActualizarParametro(Entidades.Parametro.Parametros.FACTURACIONDECIMALESREDONDEOENCANTIDAD, txtFacturacionDecimalesRedondeoEnCantidad, Nothing, lblFacturacionDecimalesRedondeoEnCantidad.Text)
      ActualizarParametro(Entidades.Parametro.Parametros.FACTURACIONDECIMALESMOSTRARENCANTIDAD, txtFacturacionDecimalesMostrarEnCantidad, Nothing, lblFacturacionDecimalesMostrarEnCantidad.Text)
      ActualizarParametro(Entidades.Parametro.Parametros.FACTURACIONDECIMALESENDESCREC, txtFacturacionDecimalesEnDescRec, Nothing, lblFacturacionCantidadDecimalesDescRec.Text)
      ActualizarParametro(Entidades.Parametro.Parametros.FACTURACIONCANTIDADDECIMALESENCOTIZACIONDOLAR, txtCantidadDecimalesCotizacionDolar, Nothing, txtCantidadDecimalesCotizacionDolar.Text)

      ActualizarParametro(Entidades.Parametro.Parametros.FACTURACIONCANTIDADCARACTERESOBSERVACIONES, txtFacturacionCantidadCaracteresObservaciones, Nothing, lblFacturacionCantidadCaracteresObservaciones.Text)

      ActualizarParametro(Entidades.Parametro.Parametros.FACTURACIONPOSICIONNOMBREPRODUCTO, chbFacturacionPosicionarNombreProducto, Nothing, chbFacturacionPosicionarNombreProducto.Text)
      ActualizarParametro(Entidades.Parametro.Parametros.FACTURACIONRAPIDARECALCULAREFECTIVOALCARGARTARJETA, chbFacturacionRapidaRecalcularEfectivoAlCargarTarjeta, Nothing, chbFacturacionRapidaRecalcularEfectivoAlCargarTarjeta.Text)

      ActualizarParametroTexto(Entidades.Parametro.Parametros.VALORPORDEFECTOENRESUMENDEVENTAS,
                               If(rdbPorFechas.Checked, "PorFechas", If(rdbPorPeriodoFiscal.Checked, "PorPeriodoFiscal", "PorAmbos")),
                               Nothing, grpValorDefectoInfResumenVentas.Text)

      ActualizarParametroTexto(Entidades.Parametro.Parametros.CANTIDADLINEASDEPRODUCTOAEVALUARPARADESCRECARGO, txtCantidadLineasEvaluarDescRecarg.ValorNumericoPorDefecto(0I).ToString(), Nothing, grpDescRecargPorCantidadLinea.Text)
      ActualizarParametroTexto(Entidades.Parametro.Parametros.PORCENTAJEDEDESCRECARGOPORLINEADEPRODUCTO, txtPorcentajeDescRecargPorLineaDeProducto.ValorNumericoPorDefecto(0D).ToString(), Nothing, grpDescRecargPorCantidadLinea.Text)
      ActualizarParametro(Entidades.Parametro.Parametros.FACTURACIONPRODUCTOMODIFDESCRIPCARGAPRECIOACTUAL, chbFacturacionProductoModificaDescripcionCargaPrecioActual, Nothing, chbFacturacionProductoModificaDescripcionCargaPrecioActual.Text)


      'Columna 2

      ActualizarParametro(Entidades.Parametro.Parametros.REEMPLAZARCOMPROBANTETIPOCOMPROBANTEORIGEN, txtReemplazarComprobanteTipoComprobanteOrigen, Nothing, lblReemplazarComprobanteTipoComprobanteOrigen.Text)
      ActualizarParametro(Entidades.Parametro.Parametros.REEMPLAZARCOMPROBANTETIPOCOMPROBANTEDESTINO, txtReemplazarComprobanteTipoComprobanteDestino, Nothing, lblReemplazarComprobanteTipoComprobanteDestino.Text)
      ActualizarParametro(Entidades.Parametro.Parametros.REEMPLAZARCOMPROBANTEREAPLICARECIBOS, chbReemplazarComprobanteReaplicaRecibos, Nothing, chbReemplazarComprobanteReaplicaRecibos.Text)

      ActualizarParametro(Entidades.Parametro.Parametros.FACTURACIONSELECCIONLOTEMANUAL, chbFacturacionSeleccionLoteManual, Nothing, chbFacturacionSeleccionLoteManual.Text)
      ActualizarParametro(Entidades.Parametro.Parametros.PRODUCTOCODIGOBARRAPRECIORESPETAETIQUETA, chbProductoCodigoBarraPrecioRespetaEtiqueta, Nothing, chbProductoCodigoBarraPrecioRespetaEtiqueta.Text)
      ActualizarParametro(Entidades.Parametro.Parametros.FACTURACIONMODDESCACUMULAPRODUCTOS, chbFacturacionModDescripcionAcumulaProd, Nothing, chbFacturacionModDescripcionAcumulaProd.Text)
      ActualizarParametro(Entidades.Parametro.Parametros.FACTURACIONSALDOCTACTEINCLUYECH3ROS, chbFacturacionSaldoIncluyeCh3ros, Nothing, chbFacturacionSaldoIncluyeCh3ros.Text)
      ActualizarParametro(Entidades.Parametro.Parametros.FACTURACIONINFORMEVENTASSI, chbInfVentasAfectaCaja, Nothing, chbInfVentasAfectaCaja.Text)
      ActualizarParametro(Entidades.Parametro.Parametros.FACTURACIONDETALLACHEQUESYTARJETAS, chbFacturacionDetallaChTarjetaFactura, Nothing, chbFacturacionDetallaChTarjetaFactura.Text)
      ActualizarParametro(Entidades.Parametro.Parametros.FACTURACIONITEMSDETALLACHEQUESYTARJETAS, txtCantidadItemsAMostrar, Nothing, lblCantidadItemsAMostrarObs.Text)

      ActualizarParametro(Entidades.Parametro.Parametros.FACTURACIONENVIOMAILCOPIAOCULTA, txtFacturacionEnvioMailCopiaOculta, Nothing, lblFacturacionEnvioMailCopiaOculta.Text)
      ActualizarParametro(Entidades.Parametro.Parametros.FACTURACIONASUNTOENVIOMASIVOEMAIL, txtFacturacionAsuntoEnvioMasivoEmail, Nothing, lblFacturacionAsuntoEnvioMasivoEmail.Text)
      ActualizarParametro(Of Integer)(Entidades.Parametro.Parametros.FACTURACIONMONEDAPORDEFECTO, cmbMonedaPorDefecto, Nothing, lblMonedaPorDefecto.Text)

      ActualizarParametro(Entidades.Parametro.Parametros.CODIGOPRODUCTODRINVOCACIONMASIVA, txtCodigoProductoInvocacionMasiva, Nothing, lblCodigoProductoInvocacionMasiva.Text)
      ActualizarParametro(Entidades.Parametro.Parametros.PORCENTAJEDRINVOCACIONMASIVA, txtPorcentajeDRInvocacionMasiva, Nothing, lblPorcentajeDRInvocacionMasiva.Text)

   End Sub

End Class