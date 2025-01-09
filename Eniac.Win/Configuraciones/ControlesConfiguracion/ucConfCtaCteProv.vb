Public Class ucConfCtaCteProv

   Protected Overrides Sub OnCargando(e As CancelableEventArgs)
      MyBase.OnCargando(e)

      'Cta. Cte. PROVEEDORES
      chbVisualizaPagoAntesImprimir.Checked = Reglas.Publicos.CtaCteProv.VisualizaPagoAProveedor
      chbPermitePagoSinAplicarComprobantes.Checked = Reglas.Publicos.CtaCteProv.PermitePagoSinAplicarComprobantes
      chbPagoSolicitaFecha.Checked = Reglas.Publicos.CtaCteProv.PagoSolicitaFecha
      chbPagoIgnorarPCdeCaja.Checked = Reglas.Publicos.CtaCteProv.PagoIgnorarPCdeCaja
      chbCCPDHVistaContable.Checked = Reglas.Publicos.CtaCteProv.CtaCteProveedoresDHVistaContable
      chbRetencionesGananciasCalculoRecursivo.Checked = Reglas.Publicos.CtaCteProv.RetencionesGananciasCalculoRecursivo
      txtRetencionesGananciasCalculoRecursivo.Text = Reglas.Publicos.CtaCteProv.RetencionesGananciasCalculoRecursivoCantidadRepeticiones.ToString()
      chbCCPRNCNDAutomatica.Checked = Reglas.Publicos.CtaCteProv.RealizaNCNDAutomaticaDescRec
      txtIdProductoDescuentoRecargo.Text = Reglas.Publicos.CtaCteProv.IDProductoDescuentoRecargo
      chbCCPRImputacionAutomaticaDRFormaPago.Checked = Reglas.Publicos.CtaCteProv.ImputacionAutomaticaDRFormaPago

      'Columna 2
      chbUtilizaCuotasVencCCProveedores.Checked = Reglas.Publicos.CtaCteProv.UtilizaCuotasVencimientoCtaCteProveedores
      chbCtaCteProveedoresSeparar.Checked = Reglas.Publicos.CtaCteProv.CtaCteProveedoresSeparar
      chbCtaCteProveedoresPermiteComprobantesEmisionPosterior.Checked = Reglas.Publicos.CtaCteProv.CtaCteProveedoresPermitirComprobantesEmisionPosterior
      chbPagoProvConciliaAutomaticamenteTransferencias.Checked = Reglas.Publicos.CtaCteProv.PagoProvConciliaAutomaticamenteTransferencias
      chbMostrarObservaciondeComprobantes.Checked = Reglas.Publicos.CtaCteProv.MostrarObservaciondeComprobantes


      'Impresiones
      chbPagoImprimeSaldo.Checked = Reglas.Publicos.CtaCteProv.PagoImprimeSaldo
      chbPagoImprimeTotalImporte.Checked = Reglas.Publicos.CtaCteProv.PagoImprimeTotalImporte
      chbPagoImprimeTotalSaldo.Checked = Reglas.Publicos.CtaCteProv.PagoImprimeTotalSaldo
      chbPagoImprimeTotalDescRec.Checked = Reglas.Publicos.CtaCteProv.PagoImprimeTotalDescRec


   End Sub

   Protected Overrides Sub OnGrabando(e As CancelableEventArgs)
      MyBase.OnGrabando(e)

      'Cta. Cte. PROVEEDORES
      ActualizarParametro(Entidades.Parametro.Parametros.VISUALIZAPAGOAPROVEEDOR, chbVisualizaPagoAntesImprimir, Nothing, chbVisualizaPagoAntesImprimir.Text)
      ActualizarParametro(Entidades.Parametro.Parametros.PERMITEPAGOSINAPLICARCOMPROBANTES, chbPermitePagoSinAplicarComprobantes, Nothing, chbPermitePagoSinAplicarComprobantes.Text)
      ActualizarParametro(Entidades.Parametro.Parametros.PAGOSOLICITAFECHA, chbPagoSolicitaFecha, Nothing, chbPagoSolicitaFecha.Text)
      ActualizarParametro(Entidades.Parametro.Parametros.PAGOIGNORARPCDECAJA, chbPagoIgnorarPCdeCaja, Nothing, chbPagoIgnorarPCdeCaja.Text)
      ActualizarParametro(Entidades.Parametro.Parametros.CTACTEPROVEEDORESDHVISTACONTABLE, chbCCPDHVistaContable, Nothing, chbCCPDHVistaContable.Text)
      ActualizarParametro(Entidades.Parametro.Parametros.RETENCIONESGANANCIASCALCULORECURSIVO, chbRetencionesGananciasCalculoRecursivo, Nothing, chbRetencionesGananciasCalculoRecursivo.Text)
      ActualizarParametro(Entidades.Parametro.Parametros.RETENCIONESGANANCIASCALCULORECURSIVOREPETIR, txtRetencionesGananciasCalculoRecursivo, Nothing, chbRetencionesGananciasCalculoRecursivo.Text + "Cantidad")
      ActualizarParametro(Entidades.Parametro.Parametros.CTACTEPROVREALIZANCNDDESCREC, chbCCPRNCNDAutomatica, Nothing, chbCCPRNCNDAutomatica.Text)
      ActualizarParametro(Entidades.Parametro.Parametros.IDPRODUCTODESCUENTORECARGOPROV, txtIdProductoDescuentoRecargo, Nothing, lblIdProductoDescuentoRecargo.Text)
      ActualizarParametro(Entidades.Parametro.Parametros.CTACTEPROVIMPUTACIONAUTOMATICADRFORMAPAGO, chbCCPRImputacionAutomaticaDRFormaPago, Nothing, chbCCPRImputacionAutomaticaDRFormaPago.Text)


      'Columna 2
      ActualizarParametro(Entidades.Parametro.Parametros.UTILIZACUOTASOVENCIMIENTOCCPROVEEDORES, chbUtilizaCuotasVencCCProveedores, Nothing, chbUtilizaCuotasVencCCProveedores.Text)
      ActualizarParametro(Entidades.Parametro.Parametros.CTACTEPROVEEDORESSEPARAR, chbCtaCteProveedoresSeparar, Nothing, chbCtaCteProveedoresSeparar.Text)
      ActualizarParametro(Entidades.Parametro.Parametros.CtaCteProveedoresEmisionPosterior, chbCtaCteProveedoresPermiteComprobantesEmisionPosterior, Nothing, chbCtaCteProveedoresPermiteComprobantesEmisionPosterior.Text)
      ActualizarParametro(Entidades.Parametro.Parametros.PAGOPROVCONCILIAAUTOMATICAMENTETRANSFERENCIAS, chbPagoProvConciliaAutomaticamenteTransferencias, Nothing, chbPagoProvConciliaAutomaticamenteTransferencias.Text)
      ActualizarParametro(Entidades.Parametro.Parametros.MOSTRAROBSERVACIONDECOMPROBANTES, chbMostrarObservaciondeComprobantes, Nothing, chbMostrarObservaciondeComprobantes.Text)


      'Impresiones
      ActualizarParametro(Entidades.Parametro.Parametros.PAGOIMPRIMESALDO, chbPagoImprimeSaldo, Nothing, chbPagoImprimeSaldo.Text)
      ActualizarParametro(Entidades.Parametro.Parametros.PAGOIMPRIMETOTALIMPORTE, chbPagoImprimeTotalImporte, Nothing, chbPagoImprimeTotalImporte.Text)
      ActualizarParametro(Entidades.Parametro.Parametros.PAGOIMPRIMETOTALSALDO, chbPagoImprimeTotalSaldo, Nothing, chbPagoImprimeTotalSaldo.Text)
      ActualizarParametro(Entidades.Parametro.Parametros.PAGOIMPRIMETOTALDESCREC, chbPagoImprimeTotalDescRec, Nothing, chbPagoImprimeTotalDescRec.Text)


   End Sub

End Class