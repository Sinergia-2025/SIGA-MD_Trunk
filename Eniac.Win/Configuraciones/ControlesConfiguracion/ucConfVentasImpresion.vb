Public Class ucConfVentasImpresion

   Protected Overrides Sub OnCargando(e As CancelableEventArgs)
      MyBase.OnCargando(e)

      chbImprimeTicketNoFiscal.Checked = Reglas.Publicos.Facturacion.Impresion.FacturacionImprimeTicketNoFiscalCtaCte
      chbImpresionMiraOrdenProductos.Checked = Reglas.Publicos.Facturacion.Impresion.ImpresionComprobantesMiraOrdenProductos
      chbImpresionMasivaOrdenInverso.Checked = Reglas.Publicos.Facturacion.Impresion.ImpresionMasivaOrdenInverso
      chbMuestraVendedorImpresion.Checked = Reglas.Publicos.Facturacion.Impresion.MuestraVendedorImpresion
      chbMuestraSaldoImpresion.Checked = Reglas.Publicos.Facturacion.Impresion.MuestraSaldoImpresion
      chbMuestraSaldoImpresionUnificado.Checked = Reglas.Publicos.Facturacion.Impresion.MuestraSaldoImpresionUnificado
      chbImpresionMuestraTotalKilos.Checked = Reglas.Publicos.Facturacion.Impresion.ImpresionMuestraTotalKilos
      chbImpresionMuestraTotalProductos.Checked = Reglas.Publicos.Facturacion.Impresion.ImpresionMuestraTotalProductos
      chbVentasImpresionVisualizaNroSerie.Checked = Reglas.Publicos.Facturacion.Impresion.VentasImpresionVisualizaNrosSerie
      chbVentasImpresionMuestraLoteObservacion.Checked = Reglas.Publicos.Facturacion.Impresion.VentasImpresionMuestraLoteObservacion
      '-- REQ-34813.- --------------------------------------------------------------------------------------------------------------
      chbVentasImpresionVisualizaValidezPresupuesto.Checked = Reglas.Publicos.Facturacion.Impresion.VentasImpresionMuestraValidezPresupuesto
      '-----------------------------------------------------------------------------------------------------------------------------
      chbFacturacionimprimeReciboVentasCtaCte.Checked = Reglas.Publicos.Facturacion.Impresion.FacturacionimprimeReciboVentasCtaCte
      txtFacturacionMargenIzquierdo.Text = Reglas.Publicos.Facturacion.Impresion.FacturacionImpresionMargenIzquierdo.ToString()
      txtFacturacionMargenDerecho.Text = Reglas.Publicos.Facturacion.Impresion.FacturacionImpresionMargenDerecho.ToString()
      '-- REQ-35923.- --------------------------------------------------------------------------------------------------------------
      chbFacturacionimprimeMuestraHoraVenta.Checked = Reglas.Publicos.Facturacion.Impresion.VentasImpresionMuestraHoraVenta
      '-----------------------------------------------------------------------------------------------------------------------------
      '-- REQ-39925.- --------------------------------------------------------------------------------------------------------------
      chbFacturacionImprimeComponentes.Checked = Reglas.Publicos.Facturacion.Impresion.VentasImpresionImprimeComponentes
      chbfacturacionImprimeCantidadComponentes.Checked = Reglas.Publicos.Facturacion.Impresion.VentasImpresionImprimeCantidadComponentes
      txtCantidadLineasSeparacion.Text = Reglas.Publicos.Facturacion.Impresion.FacturacionImpresionCantidadLineasSeparacion.ToString()

      '-----------------------------------------------------------------------------------------------------------------------------
   End Sub

   Protected Overrides Sub OnGrabando(e As CancelableEventArgs)
      MyBase.OnGrabando(e)

      ActualizarParametro(Entidades.Parametro.Parametros.FACTURACIONIMPRIMETICKETNOFISCAL, chbImprimeTicketNoFiscal, Nothing, chbImprimeTicketNoFiscal.Text)
      ActualizarParametro(Entidades.Parametro.Parametros.FACTURACIONIMPRESIONORDENPRODUCTOS, chbImpresionMiraOrdenProductos, Nothing, chbImpresionMiraOrdenProductos.Text)
      ActualizarParametro(Entidades.Parametro.Parametros.IMPRESIONMASIVAORDENINVERSO, chbImpresionMasivaOrdenInverso, Nothing, chbImpresionMasivaOrdenInverso.Text)
      ActualizarParametro(Entidades.Parametro.Parametros.FACTURACIONMUESTRAVENDEDORIMPRESION, chbMuestraVendedorImpresion, Nothing, chbMuestraVendedorImpresion.Text)
      ActualizarParametro(Entidades.Parametro.Parametros.FACTURACIONMUESTRASALDOCTACTEIMPRESION, chbMuestraSaldoImpresion, Nothing, chbMuestraSaldoImpresion.Text)
      ActualizarParametro(Entidades.Parametro.Parametros.FACTURACIONMUESTRASALDOCTACTEIMPRESIONUNIFICADO, chbMuestraSaldoImpresionUnificado, Nothing, chbMuestraSaldoImpresionUnificado.Text)
      ActualizarParametro(Entidades.Parametro.Parametros.IMPRESIONMUESTRATOTALKILOS, chbImpresionMuestraTotalKilos, Nothing, chbImpresionMuestraTotalKilos.Text)
      ActualizarParametro(Entidades.Parametro.Parametros.IMPRESIONMUESTRATOTALPRODUCTOS, chbImpresionMuestraTotalProductos, Nothing, chbImpresionMuestraTotalProductos.Text)
      ActualizarParametro(Entidades.Parametro.Parametros.VENTASIMPRESIONVISNROSERIE, chbVentasImpresionVisualizaNroSerie, Nothing, chbVentasImpresionVisualizaNroSerie.Text)
      ActualizarParametro(Entidades.Parametro.Parametros.VENTASIMPRESIONMUESTRALOTEOBSERVACION, chbVentasImpresionMuestraLoteObservacion, Nothing, chbVentasImpresionMuestraLoteObservacion.Text)
      '-- REQ-34813.- --------------------------------------------------------------------------------------------------------------
      ActualizarParametro(Entidades.Parametro.Parametros.VENTASIMPRESIONMUESTRAVALIDEZPRESUPUESTO, chbVentasImpresionVisualizaValidezPresupuesto, Nothing, chbVentasImpresionVisualizaValidezPresupuesto.Text)
      '-- REQ-35923.- --------------------------------------------------------------------------------------------------------------
      ActualizarParametro(Entidades.Parametro.Parametros.VENTASIMPRESIONMUESTRAHORAVENTA, chbFacturacionimprimeMuestraHoraVenta, Nothing, chbFacturacionimprimeMuestraHoraVenta.Text)
      '-----------------------------------------------------------------------------------------------------------------------------
      ActualizarParametro(Entidades.Parametro.Parametros.FACTURACIONIMPRIMERECIBOVENTASCTACTE, chbFacturacionimprimeReciboVentasCtaCte, Nothing, chbFacturacionimprimeReciboVentasCtaCte.Text)
      ActualizarParametro(Entidades.Parametro.Parametros.FACTURACIONMARGENDERECHO, txtFacturacionMargenDerecho, Nothing, lblMargenDerecho.Text)
      ActualizarParametro(Entidades.Parametro.Parametros.FACTURACIONMARGENIZQUIERDO, txtFacturacionMargenIzquierdo, Nothing, lblMargenIzquierdo.Text)
      '-- REQ-39925.- --------------------------------------------------------------------------------------------------------------
      ActualizarParametro(Entidades.Parametro.Parametros.VENTASIMPRESIONIMPRIMECOMPONENTES, chbFacturacionImprimeComponentes, Nothing, chbFacturacionImprimeComponentes.Text)
      ActualizarParametro(Entidades.Parametro.Parametros.VENTASIMPRESIONIMPRIMECANTCOMPONENTES, chbfacturacionImprimeCantidadComponentes, Nothing, chbfacturacionImprimeCantidadComponentes.Text)
      ActualizarParametro(Entidades.Parametro.Parametros.VENTASIMPRESIONIMPRIMECANTLINEASSEPARACION, txtCantidadLineasSeparacion, Nothing, lblCantidadLineasSeparacion.Text)
      '-----------------------------------------------------------------------------------------------------------------------------


   End Sub

End Class
