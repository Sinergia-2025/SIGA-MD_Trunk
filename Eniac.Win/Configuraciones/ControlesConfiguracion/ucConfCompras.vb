Public Class ucConfCompras

   Protected Overrides Sub OnInicializando(e As InicializarEventArgs)
      MyBase.OnInicializando(e)

      e.Publicos.CargaComboDesdeEnum(cmbCompraPrecioCosto, Entidades.Publicos.ComprasPrecioCosto.ACTUAL)

      chbExpensasPermiteConSinConcepto.Visible = Reglas.Publicos.TieneModuloExpensas
      chbExpensasPermitirCargarProductosSinConceptos.Visible = Reglas.Publicos.TieneModuloExpensas

   End Sub

   Protected Overrides Sub OnCargando(e As CancelableEventArgs)
      MyBase.OnCargando(e)

      'Compras
      'Columna 1
      txtUltimaHojaCompras.Text = Reglas.Publicos.NroHojaLibroIvaCompras.ToString()
      chbComprasConProductosEnCero.Checked = Reglas.Publicos.ComprasConProductosEnCero
      chbVisualizaComprasAntesImprimir.Checked = Reglas.Publicos.VisualizaComprobantesDeCompra
      chbComprasSinProductos.Checked = Reglas.Publicos.ComprasSinProductos
      chbComprasIgnorarPCdeCaja.Checked = Reglas.Publicos.ComprasIgnorarPCdeCaja
      chbPermiteModificarDescCompras.Checked = Reglas.Publicos.ComprasModificaDescripcionProducto
      chbComprasContadoEsEnPesos.Checked = Reglas.Publicos.ComprasContadoEsEnPesos
      chbComprasSoloCargaProductosDelProveedor.Checked = Reglas.Publicos.ComprasSoloCargaProductosDelProveedor
      txtIdentifNDEBCheqRechCompra.Text = Reglas.Publicos.IdNotaDebitoChequeRechazadoCompra
      txtComprasToleranciaIvaManual.Text = Reglas.Publicos.ComprasToleranciaIvaManual.ToString("N2")

      Dim ActualizarPreciosCalculoDesdeCompras = Reglas.Publicos.ActualizarPreciosCalculoDesdeCompras
      Select Case ActualizarPreciosCalculoDesdeCompras
         Case "ACTUAL"
            radActualizarPreciosCalculoDesdeCompras_PorcActual.Checked = True
         Case "VENTA"
            radActualizarPreciosCalculoDesdeCompras_SobreVenta.Checked = True
         Case Else
            radActualizarPreciosCalculoDesdeCompras_SobreCosto.Checked = True
      End Select

      chbActualizarPreciosDesdeComprasPriorizaIVAProducto.Checked = Reglas.Publicos.ActualizarPreciosDesdeComprasPriorizaIVAProducto
      chbComprasConservaOrdenProductos.Checked = Reglas.Publicos.ComprasConservaOrdenProductos     '-- REQ-32596.- --
      txtIdentifNDEBNoGL.Text = Reglas.Publicos.IdNotaDebitoNoGrabaLibroProv
      txtIdentifNCREDNoGL.Text = Reglas.Publicos.IdNotaCreditoNoGrabaLibroProv
      txtComprasProductoLiquidacionTarjetas.Text = Reglas.Publicos.ComprasProductoLiquidacionTarjetas


      'Columna 2
      chbActualizaCostosPreciosVenta.Checked = Reglas.Publicos.ActualizaCostoYPrecioVenta
      cmbCompraPrecioCosto.SelectedValue = Reglas.Publicos.Compras.ComprasPrecioCosto

      txtComprasDecimalesRedondeoEnPrecio.Text = Reglas.Publicos.Compras.Redondeo.ComprasDecimalesRedondeoEnPrecio.ToString()
      txtComprasDecimalesMostrarEnItems.Text = Reglas.Publicos.Compras.Redondeo.ComprasDecimalesEnPrecio.ToString()
      txtComprasDecimalesEnTotalXProducto.Text = Reglas.Publicos.Compras.Redondeo.ComprasDecimalesEnTotalXProducto.ToString()
      txtComprasDecimalesRedondeoEnCantidad.Text = Reglas.Publicos.Compras.Redondeo.ComprasDecimalesRedondeoEnCantidad.ToString()
      txtComprasDecimalesMostrarEnCantidad.Text = Reglas.Publicos.Compras.Redondeo.ComprasDecimalesMostrarEnCantidad.ToString()
      txtComprasDecimalesEnTotal.Text = Reglas.Publicos.Compras.Redondeo.ComprasDecimalesEnTotalGeneral.ToString()

      chbComprasImpresionVisualizaNroSerie.Checked = Reglas.Publicos.Compras.ComprasImpresionVisualizaNrosSerie
      chbComprasVisualizaCodigoProveedor.Checked = Reglas.Publicos.Compras.ComprasVisualizaCodigoProveedor
      chbComprasVisualizaPorcVarCosto.Checked = Reglas.Publicos.Compras.ComprasVisualizaPorcVarCosto
      chbComprasPedidosInvocadosProvMantieneFormaPago.Checked = Reglas.Publicos.MantieneFormaPagoPedidosProvInvocados
      chbActualizaPreciosUtilizaAjusteDecimales.Checked = Reglas.Publicos.ComprasActualizaPreciosUtilizaAjusteADecimales
      chbComprasPosicionarNombreProducto.Checked = Reglas.Publicos.Compras.ComprasPosicionarNombreProducto
      chbExpensasPermiteConSinConcepto.Checked = Reglas.Publicos.ExpensasPermiteConSinConcepto
      chbExpensasPermitirCargarProductosSinConceptos.Checked = Reglas.Publicos.ExpensasPermitirCargarProductosSinConceptos
      chbComprasSolicitaComprador.Checked = Reglas.Publicos.ComprasSolicitaComprador


   End Sub

   Protected Overrides Sub OnGrabando(e As CancelableEventArgs)
      MyBase.OnGrabando(e)

      'Compras
      'Columna 1
      ActualizarParametro(Entidades.Parametro.Parametros.NROHOJALIBROIVACOMPRAS, txtUltimaHojaCompras, Nothing, lblUltimaHojaCompras.Text)
      ActualizarParametro(Entidades.Parametro.Parametros.COMPRASCONPRODUCTOSENCERO, chbComprasConProductosEnCero, Nothing, chbComprasConProductosEnCero.Text)
      ActualizarParametroTexto(Entidades.Parametro.Parametros.VISUALIZACOMPROBANTESDECOMPRA, chbVisualizaComprasAntesImprimir.ToStringEspañol(), Nothing, chbVisualizaComprasAntesImprimir.Text)
      ActualizarParametro(Entidades.Parametro.Parametros.COMPRASSINPRODUCTOS, chbComprasSinProductos, Nothing, chbComprasSinProductos.Text)
      ActualizarParametro(Entidades.Parametro.Parametros.COMPRASIGNORARPCDECAJA, chbComprasIgnorarPCdeCaja, Nothing, chbComprasIgnorarPCdeCaja.Text)
      ActualizarParametro(Entidades.Parametro.Parametros.COMPRASMODIFICADESCRIPCIONPRODUCTO, chbPermiteModificarDescCompras, Nothing, chbPermiteModificarDescCompras.Text)
      ''ActualizarParametro(chbComprasContadoEsEnPesos.Tag.ToString(), chbComprasContadoEsEnPesos.Checked.ToString(), Nothing, chbFacturacionContadoEsEnPesos.Text)
      ActualizarParametro(Entidades.Parametro.Parametros.COMPRASSOLOCARGAPRODUCTOSDELPROVEEDOR, chbComprasSoloCargaProductosDelProveedor, Nothing, chbComprasSoloCargaProductosDelProveedor.Text)
      ActualizarParametro(Entidades.Parametro.Parametros.NDEBCHEQRECHCOM, txtIdentifNDEBCheqRechCompra, Nothing, lblIdentifNDebCheqCheqCompra.Text)
      ActualizarParametro(Entidades.Parametro.Parametros.COMPRASTOLERANCIAIVAMANUAL, txtComprasToleranciaIvaManual, Nothing, lblComprasToleranciaIvaManual.Text)

      Dim ActualizarPreciosCalculoDesdeCompras = If(radActualizarPreciosCalculoDesdeCompras_PorcActual.Checked, "ACTUAL", If(radActualizarPreciosCalculoDesdeCompras_SobreVenta.Checked, "VENTA", "COSTO"))
      ActualizarParametroTexto(Entidades.Parametro.Parametros.ACTUALIZARPRECIOSCALCULODESDECOMPRAS, ActualizarPreciosCalculoDesdeCompras, Nothing, grpActualizarPreciosCalculoDesdeCompras.Text)

      ActualizarParametro(Entidades.Parametro.Parametros.ACTUALIZARPRECIOSDESDECOMPRASPRIORIZAIVAPRODUCTO, chbActualizarPreciosDesdeComprasPriorizaIVAProducto, Nothing, chbActualizarPreciosDesdeComprasPriorizaIVAProducto.Text)
      ActualizarParametro(Entidades.Parametro.Parametros.COMPRASCONSERVAORDENPRODUCTOS, chbComprasConservaOrdenProductos, Nothing, chbComprasConservaOrdenProductos.Text)  '-- REG-32596.-
      ActualizarParametro(Entidades.Parametro.Parametros.COMPRASPRODUCTOLIQUIDACIONTARJETAS, txtComprasProductoLiquidacionTarjetas, Nothing, lblComprasProductoLiquidacionTarjetas.Text)


      'Columna 2
      ActualizarParametro(Entidades.Parametro.Parametros.ACTUALIZACOSTOYPRECIOVENTA, chbActualizaCostosPreciosVenta, Nothing, chbActualizaCostosPreciosVenta.Text)
      ActualizarParametro(Of Entidades.Publicos.ComprasPrecioCosto)(Entidades.Parametro.Parametros.COMPRASPRECIOCOSTO, cmbCompraPrecioCosto, Nothing, chbActualizaCostosPreciosVenta.Text + " - Precio Costo")
      ActualizarParametro(Entidades.Parametro.Parametros.COMPRASDECIMALESREDONDEOENPRECIO, txtComprasDecimalesRedondeoEnPrecio, Nothing, lblComprasDecimalesRedondeoEnPrecio.Text)
      ActualizarParametro(Entidades.Parametro.Parametros.COMPRASDECIMALESENPRECIO, txtComprasDecimalesMostrarEnItems, Nothing, lblComprasDecimalesMostrarEnItems.Text)
      ActualizarParametro(Entidades.Parametro.Parametros.COMPRASDECIMALESENTOTALXPRODUCTO, txtComprasDecimalesEnTotalXProducto, Nothing, lblComprasDecimalesEnTotalXProducto.Text)
      ActualizarParametro(Entidades.Parametro.Parametros.COMPRASDECIMALESREDONDEOENCANTIDAD, txtComprasDecimalesRedondeoEnCantidad, Nothing, lblComprasDecimalesRedondeoEnCantidad.Text)
      ActualizarParametro(Entidades.Parametro.Parametros.COMPRASDECIMALESMOSTRARENCANTIDAD, txtComprasDecimalesMostrarEnCantidad, Nothing, lblComprasDecimalesMostrarEnCantidad.Text)
      ActualizarParametro(Entidades.Parametro.Parametros.COMPRASDECIMALESENTOTALGENERAL, txtComprasDecimalesEnTotal, Nothing, lblComprasDecimalesEnTotal.Text)

      ActualizarParametro(Entidades.Parametro.Parametros.COMPRASIMPRESIONVISNROSERIE, chbComprasImpresionVisualizaNroSerie, Nothing, chbComprasImpresionVisualizaNroSerie.Text)
      ActualizarParametro(Entidades.Parametro.Parametros.VISUALIZACODIGOPROVEEDOR, chbComprasVisualizaCodigoProveedor, Nothing, chbComprasVisualizaCodigoProveedor.Text)
      ActualizarParametro(Entidades.Parametro.Parametros.VISUALIZAPORCVARCOSTO, chbComprasVisualizaPorcVarCosto, Nothing, chbComprasVisualizaPorcVarCosto.Text)
      ActualizarParametro(Entidades.Parametro.Parametros.COMPRASPEDIDOSPROVINVOCADOSMANTIENEFORMAPAGO, chbComprasPedidosInvocadosProvMantieneFormaPago, Nothing, chbComprasPedidosInvocadosProvMantieneFormaPago.Text)
      ActualizarParametro(Entidades.Parametro.Parametros.ACTUALIZAPRECIOSUTILIZAAJUSTEA, chbActualizaPreciosUtilizaAjusteDecimales, Nothing, chbActualizaPreciosUtilizaAjusteDecimales.Text)
      ActualizarParametro(Entidades.Parametro.Parametros.COMPRASPOSICIONARNOMBREPRODUCTO, chbComprasPosicionarNombreProducto, Nothing, chbComprasPosicionarNombreProducto.Text)
      ActualizarParametro(Entidades.Parametro.Parametros.EXPENSASPERMITECONSINCONCEPTO, chbExpensasPermiteConSinConcepto, Nothing, chbExpensasPermiteConSinConcepto.Text)
      ActualizarParametro(Entidades.Parametro.Parametros.EXPENSASPERMITIRCARGARPRODUCTOSSINCONCEPTOS, chbExpensasPermitirCargarProductosSinConceptos, Nothing, chbExpensasPermitirCargarProductosSinConceptos.Text)
      ActualizarParametro(Entidades.Parametro.Parametros.COMPRASSOLICITACOMPRADOR, chbComprasSolicitaComprador, Nothing, chbComprasSolicitaComprador.Text)
      ActualizarParametro(Entidades.Parametro.Parametros.IDNDEBNOGLPROV, txtIdentifNDEBNoGL, Nothing, lblIdentifNDEBNoGL.Text)
      ActualizarParametro(Entidades.Parametro.Parametros.IDNCREDNOGLPROV, txtIdentifNCREDNoGL, Nothing, lblIdentifNCREDNoGL.Text)

   End Sub


End Class