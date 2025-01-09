Public Class ucConfCtaCteClienteGeneral

   Protected Overrides Sub OnCargando(e As CancelableEventArgs)
      MyBase.OnCargando(e)

      'Cta. Cte. CLIENTES
      chbVisualizaReciboAntesImprimir.Checked = Reglas.Publicos.VisualizaReciboDeCliente
      chbPermiteReciboSinAplicarComprobantes.Checked = Reglas.Publicos.CtaCte.VisualizaReciboDeCliente
      chbReciboSolicitaFecha.Checked = Reglas.Publicos.CtaCte.ReciboSolicitaFecha
      chbReciboUtilizaDescuentoRecargo.Checked = Reglas.Publicos.CtaCte.ReciboUtilizaDescuentoRecargo
      txtIdProductoDescuentoRecargo.Text = Reglas.Publicos.CtaCte.IDProductoDescuentoRecargo
      chbReciboIgnorarPCdeCaja.Checked = Reglas.Publicos.CtaCte.ReciboIgnorarPCdeCaja
      txtCategoriaCliente.Text = Reglas.Publicos.CtaCte.CategoriaClientePredeterminada
      'txtInteresesAdicionalProporcionalDiario    ¿¿'??
      chkInteresesCalculoCompletoPrimerPago.Checked = Reglas.Publicos.CtaCte.InteresesCalculoCompletoPrimerPago
      chkMontoAplicadoIncluyeIntereses.Checked = Reglas.Publicos.CtaCte.InteresesMontoAplicadoIncluyeIntereses
      chbPermiteModificarImporteInteresesRecibo.Checked = Reglas.Publicos.CtaCte.PermiteModificarImporteInteresesRecibo
      chbUtilizaCuotasVencCCClientes.Checked = Reglas.Publicos.CtaCte.UtilizaCuotasVencimientoCtaCteClientes
      chbReciboAplicaSaldoEnPesos.Checked = Reglas.Publicos.CtaCte.ReciboAplicaSaldoEnPesos
      chbValidaEmisorElectronicoRecibos.Checked = Reglas.Publicos.CtaCte.ValidaEmisorElectronicoEnRecibos
      chbReciboConciliaAutomaticamenteTransferencias.Checked = Reglas.Publicos.CtaCte.ReciboConciliaAutomaticamenteTransferencias
      chbEnviaMailRecibo.Checked = Reglas.Publicos.CtaCte.RecibosEnviaMailCliente


      'Columna 2
      chbCtaCteClientesSeparar.Checked = Reglas.Publicos.CtaCte.CtaCteClientesSeparar
      chbCtaCteClientesPriorizarNCyANT.Checked = Reglas.Publicos.CtaCte.CtaCteClientesPriorizarNCsyAnticipos
      chbCtaCteClientesPermiteComprobantesEmisionPosterior.Checked = Reglas.Publicos.CtaCte.CtaCteClientesPermitirComprobantesEmisionPosterior
      chbCtaCteClientesCalcularPromedios.Checked = Reglas.Publicos.CtaCte.CtaCteClientesCalcularPromedios
      chbCategoriaClienteRecibos.Checked = Reglas.Publicos.CtaCte.ContemplaCategoriaClienteRecibo
      chbCtaCteClientesReciboMuestraSaldosEnImpresion.Checked = Reglas.Publicos.CtaCte.ReciboMuestraSaldoImpresion
      chbReciboMantieneNumModificada.Checked = Reglas.Publicos.CtaCte.RecibosMantieneNumeracionModificada
      chbReciboComparteNumeracionEntreSucursales.Checked = Reglas.Publicos.CtaCte.ReciboComparteNumeracionEntreSucursales
      '-- REQ-31947.- --------------------------------------------------------------------
      chbCalculoInteresFuturo.Checked = Reglas.Publicos.CtaCte.ReciboCalculoInteresFuturos
      '-----------------------------------------------------------------------------------
      txtMontoMinimoInteres.Text = Reglas.Publicos.CtaCte.MontoMinimoInteresPermitido.ToString()
      chbPintaCuotaCtaCteClientes.Checked = Reglas.Publicos.CtaCte.PintaColumaCuotaCtaCteCliente
      txtFacturacionAsuntoEnvioMasivoEmailCtaCte.Text = Reglas.Publicos.CtaCte.FacturacionAsuntoEnvioMasivoEmailCtaCte
      txtCantidadDiasVencimiento.Text = Reglas.Publicos.CtaCte.CantidadDiasVencimientoMail.ToString()
      '-- REQ-33040.- ------------------
      txtCantidadDiasDHRecibos.Text = Reglas.Publicos.CtaCte.CantidadDiasDHRecibos.ToString()
      '---------------------------------


   End Sub

   Protected Overrides Sub OnGrabando(e As CancelableEventArgs)
      MyBase.OnGrabando(e)

      'Cta. Cte. CLIENTES
      ActualizarParametro(Entidades.Parametro.Parametros.VISUALIZARECIBO, chbVisualizaReciboAntesImprimir, Nothing, chbVisualizaReciboAntesImprimir.Text)
      ActualizarParametro(Entidades.Parametro.Parametros.PERMITERECIBOSINAPLICARCOMPROBANTES, chbPermiteReciboSinAplicarComprobantes, Nothing, chbPermiteReciboSinAplicarComprobantes.Text)
      ActualizarParametro(Entidades.Parametro.Parametros.RECIBOSOLICITAFECHA, chbReciboSolicitaFecha, Nothing, chbReciboSolicitaFecha.Text)
      ActualizarParametro(Entidades.Parametro.Parametros.RECIBOUTILIZADESCUENTORECARGO, chbReciboUtilizaDescuentoRecargo, Nothing, chbReciboUtilizaDescuentoRecargo.Text)
      ActualizarParametro(Entidades.Parametro.Parametros.IDPRODUCTODESCUENTORECARGO, txtIdProductoDescuentoRecargo, Nothing, lblIdProductoDescuentoRecargo.Text)
      ActualizarParametro(Entidades.Parametro.Parametros.RECIBOIGNORARPCDECAJA, chbReciboIgnorarPCdeCaja, Nothing, chbReciboIgnorarPCdeCaja.Text)
      ActualizarParametro(Entidades.Parametro.Parametros.CTACTECATEGORIACLIENTE, txtCategoriaCliente, Nothing, lblCategoriaCliente.Text)
      ActualizarParametro(Entidades.Parametro.Parametros.INTERESESADICIONALPROPORCIONALDIARIO, txtInteresesAdicionalProporcionalDiario, Nothing, lblInteresesAdicionalProporcionalDiario.Text)
      ActualizarParametro(Entidades.Parametro.Parametros.INTERESESCALCULOCOMPLETOPRIMERPAGO, chkInteresesCalculoCompletoPrimerPago, Nothing, chkInteresesCalculoCompletoPrimerPago.Text)
      ActualizarParametro(Entidades.Parametro.Parametros.INTERESESMONTOAPLICADOINCLUYEINTERESES, chkMontoAplicadoIncluyeIntereses, Nothing, chkMontoAplicadoIncluyeIntereses.Text)
      ActualizarParametro(Entidades.Parametro.Parametros.RECIBOPERMITEMODIFICARIMPORTEINTERESES, chbPermiteModificarImporteInteresesRecibo, Nothing, chbPermiteModificarImporteInteresesRecibo.Text)
      ActualizarParametro(Entidades.Parametro.Parametros.UTILIZACUOTASOVENCIMIENTOCCCLIENTES, chbUtilizaCuotasVencCCClientes, Nothing, chbUtilizaCuotasVencCCClientes.Text)
      ActualizarParametro(Entidades.Parametro.Parametros.RECIBOAPLICASALDOENPESOS, chbReciboAplicaSaldoEnPesos, Nothing, chbReciboAplicaSaldoEnPesos.Text)
      ActualizarParametro(Entidades.Parametro.Parametros.VALIDAEMISORELECTRONICOENRECIBOS, chbValidaEmisorElectronicoRecibos, Nothing, chbValidaEmisorElectronicoRecibos.Text)
      ActualizarParametro(Entidades.Parametro.Parametros.RECIBOCONCILIAAUTOMATICAMENTETRANSFERENCIAS, chbReciboConciliaAutomaticamenteTransferencias, Nothing, chbReciboConciliaAutomaticamenteTransferencias.Text)
      ActualizarParametro(Entidades.Parametro.Parametros.ENVIAMAILCLIENTERECIBO, chbEnviaMailRecibo, Nothing, chbEnviaMailRecibo.Text)

      'Columna 2
      ActualizarParametro(Entidades.Parametro.Parametros.CTACTECLIENTESSEPARAR, chbCtaCteClientesSeparar, Nothing, chbCtaCteClientesSeparar.Text)
      ActualizarParametro(Entidades.Parametro.Parametros.CTACTECLIENTESPRIORIZARNCSYANTICIPOS, chbCtaCteClientesPriorizarNCyANT, Nothing, chbCtaCteClientesPriorizarNCyANT.Text)
      ActualizarParametro(Entidades.Parametro.Parametros.CTACTECLIENTESEMISIONPOSTERIOR, chbCtaCteClientesPermiteComprobantesEmisionPosterior, Nothing, chbCtaCteClientesPermiteComprobantesEmisionPosterior.Text)
      ActualizarParametro(Entidades.Parametro.Parametros.CtaCteClientesCalcularPromedios, chbCtaCteClientesCalcularPromedios, Nothing, chbCtaCteClientesCalcularPromedios.Text)
      ActualizarParametro(Entidades.Parametro.Parametros.CTACTECATEGORIACLIENTESRECIBO, chbCategoriaClienteRecibos, Nothing, chbCategoriaClienteRecibos.Text)
      ActualizarParametro(Entidades.Parametro.Parametros.RECIBOMUESTRASALDOCTACTEIMPRESION, chbCtaCteClientesReciboMuestraSaldosEnImpresion, Nothing, chbCtaCteClientesReciboMuestraSaldosEnImpresion.Text)
      ActualizarParametro(Entidades.Parametro.Parametros.RECIBOMANTIENENUMMODIFICADA, chbReciboMantieneNumModificada, Nothing, chbReciboMantieneNumModificada.Text)
      ActualizarParametro(Entidades.Parametro.Parametros.RECIBOCOMPARTENUMERACIONENTRESUCURSALES, chbReciboComparteNumeracionEntreSucursales, Nothing, chbReciboComparteNumeracionEntreSucursales.Text)
      '-- REQ-31947.- --------------------------------------------------------------------
      ActualizarParametro(Entidades.Parametro.Parametros.RECIBOCALCULOINTERESESFUTURO, chbCalculoInteresFuturo, Nothing, chbCalculoInteresFuturo.Text)
      '-----------------------------------------------------------------------------------
      ActualizarParametro(Entidades.Parametro.Parametros.RECIBOMONTOMINIMOINTERESPERMITO, txtMontoMinimoInteres, Nothing, lblMontoMinimoInteres.Text)
      ActualizarParametro(Entidades.Parametro.Parametros.CTACTECLIENTEPINTACUOTA, chbPintaCuotaCtaCteClientes, Nothing, chbPintaCuotaCtaCteClientes.Text)
      ActualizarParametro(Entidades.Parametro.Parametros.FACTURACIONASUNTOENVIOMASIVOEMAILCTACTE, txtFacturacionAsuntoEnvioMasivoEmailCtaCte, Nothing, lblFacturacionAsuntoEnvioMasivoEmailCtaCte.Text)
      ActualizarParametro(Entidades.Parametro.Parametros.CTACTECANTDIASVENCICOMPMAIL, txtCantidadDiasVencimiento, Nothing, lblCantidadDiasvto.Text)
      '-- REQ-33040.- ------------------
      ActualizarParametro(Entidades.Parametro.Parametros.CTACTECANTDIASDHRECIBOS, txtCantidadDiasDHRecibos, Nothing, lblCantidadDiasDHRecibos.Text)
      '---------------------------------


   End Sub

End Class