Public Class ucConfVentas2

   Protected Overrides Sub OnInicializando(e As InicializarEventArgs)
      MyBase.OnInicializando(e)
      e.Publicos.CargaComboDesdeEnum(cmbBusquedaClienteDefault, GetType(Entidades.Publicos.BusquedasClientesFacturacion), , , Not New Reglas.Generales().ExisteTabla("Embarcaciones"))
   End Sub
   Protected Overrides Sub OnCargando(e As CancelableEventArgs)
      MyBase.OnCargando(e)

      Select Case Reglas.Publicos.Facturacion.FacturacionOfreceCalcularVuelto
         Case rbtFacturacionRapidaVueltoOfrecer.Tag.ToString()
            rbtFacturacionRapidaVueltoOfrecer.Checked = True
         Case rbtFacturacionRapidaVueltoNoOfrecer.Tag.ToString()
            rbtFacturacionRapidaVueltoNoOfrecer.Checked = True
         Case Else
            rbtFacturacionRapidaVueltoDirecto.Checked = True
      End Select

      chbFacturacionIgnorarPCdeCaja.Checked = Reglas.Publicos.Facturacion.FacturacionIgnorarPCdeCaja
      chbFacturacionRemitoTranspUtilizaLote.Checked = Reglas.Publicos.Facturacion.FacturacionRemitoTranspUtilizaLote
      chbFacturacionRemitoTranspCalculaBultos.Checked = Reglas.Publicos.Facturacion.FacturacionRemitoTranspCalculaBultos

      Select Case Publicos.ControlaEventosdeLimiteDeCreditoDeClientes
         Case "Permitir"
            rbtPermitirFacturarCreditoLimite.Checked = True
         Case "No Permitir"
            rbtNoPermitirFacturarCreditoLimite.Checked = True
         Case Else
            rbtAvisarPermitirFacturarCreditoLimite.Checked = True
      End Select

      Select Case Publicos.ControlaDiasVtoDeCreditoDeClientes
         Case "Permitir"
            rbtPermitirFacturarLimiteDiasVto.Checked = True
         Case "No Permitir"
            rbtNoPermitirFacturarLimiteDiasVto.Checked = True
         Case Else
            rbtAvisarPermitirFacturarLimiteDiasVto.Checked = True
      End Select

      chbFacturacionIgnorarUltimoDigitoCB.Checked = Reglas.Publicos.Facturacion.FacturacionIgnorarUltimoDigitoCB
      chbFacturacionAvisaProductosEnCero.Checked = Reglas.Publicos.Facturacion.FacturacionAvisaProductosEnCero
      chbPorCtaOrden.Checked = Reglas.Publicos.Facturacion.FactPorCtaOrden
      chbSaldoContemplaHora.Checked = Reglas.Publicos.Facturacion.SaldoContemplaHora
      chbSaldoTomaActual.Checked = Reglas.Publicos.Facturacion.SaldoTomaActualAlImprimir


      'Columna 2
      txtDescuentoMaximo.Text = Reglas.Publicos.Facturacion.DescuentoMaximo.ToString()
      chbPermiteModificarCliente.Checked = Reglas.Publicos.Facturacion.PermiteModificarClienteFacturacion
      txtDiasInvocacionComprobantes.Text = Reglas.Publicos.Facturacion.FacturacionDiasInvocacionComprobantes.ToString()

      cmbCalculoComisionVendedor.Text = Reglas.Publicos.CalculoComisionVendedor

      '-- REQ-33678.- ------------------------------------------
      cmbBusquedaClienteDefault.Text = Reglas.Publicos.BusquedaClienteFacturacion
      '---------------------------------------------------------
      Select Case Reglas.Publicos.ComisionVendedor
         Case rbtComisionVendedorRubroMarca.Tag.ToString()
            rbtComisionVendedorRubroMarca.Checked = True
         Case Else
            rbtComisionVendedorMarcaRubro.Checked = True
      End Select

      chbFacturacionComprobanteGrabaLibroNoFuerzaConsFinal.Checked = Reglas.Publicos.Facturacion.FacturacionGrabaLibroNoFuerzaConsFinal
      chbFacturacionPermiteCantidadNegativa.Checked = Reglas.Publicos.Facturacion.FacturacionPermiteCantidadNegativa
      chbFacturacionPermiteCantidadNegativaAcumulada.Checked = Reglas.Publicos.Facturacion.FacturacionPermiteCantidadNegativaAcumulada
      chbFacturacionModificaDescriProdCantidad.Checked = Reglas.Publicos.Facturacion.FacturacionModificaDescriProdCantidad
      chbFacturacionModificaDescripSolicKilos.Checked = Reglas.Publicos.Facturacion.FacturacionModificaDescripSolicitaKilos
      chbFacturacionModificaDescripSolicitaPrecio.Checked = Reglas.Publicos.Facturacion.FacturacionModificaDescripSolicitaPrecio

      txtControlTopeCF.Text = Reglas.Publicos.Facturacion.FacturacionControlaTopeCF.ToString()
      chbFacturacionControlaDNIConsumidorFinal.Checked = Reglas.Publicos.Facturacion.FacturacionControlaDNIClienteConsumidorFinal

      chbSimulaPercepcionNGLibro.Checked = Reglas.Publicos.FacturacionSimulaPercepcionesComprobanteNGLibro

   End Sub

   Protected Overrides Sub OnGrabando(e As CancelableEventArgs)
      MyBase.OnGrabando(e)

      ActualizarParametroTexto(Entidades.Parametro.Parametros.FACTURACIONOFRECECALCULARVUELTO,
                           If(rbtFacturacionRapidaVueltoOfrecer.Checked, rbtFacturacionRapidaVueltoOfrecer.Tag.ToString(),
                              If(rbtFacturacionRapidaVueltoNoOfrecer.Checked, rbtFacturacionRapidaVueltoNoOfrecer.Tag.ToString(),
                                 rbtFacturacionRapidaVueltoDirecto.Tag.ToString())),
                           Nothing, grbFacturacionRapidaOfreceCalcularVuelto.Text)

      ActualizarParametro(Entidades.Parametro.Parametros.FACTURACIONIGNORARPCDECAJA, chbFacturacionIgnorarPCdeCaja, Nothing, chbFacturacionIgnorarPCdeCaja.Text)
      ActualizarParametro(Entidades.Parametro.Parametros.FACTURACIONREMITOTRANSPUTILIZALOTE, chbFacturacionRemitoTranspUtilizaLote, Nothing, chbFacturacionRemitoTranspUtilizaLote.Text)
      ActualizarParametro(Entidades.Parametro.Parametros.FACTURACIONREMITOTRANSPCALCULABULTOS, chbFacturacionRemitoTranspCalculaBultos, Nothing, chbFacturacionRemitoTranspCalculaBultos.Text)

      ActualizarParametroTexto(Entidades.Parametro.Parametros.CONTROLAEVENTOSDELIMITEDECREDITODECLIENTES,
                           If(rbtPermitirFacturarCreditoLimite.Checked, rbtPermitirFacturarCreditoLimite.Text,
                              If(rbtNoPermitirFacturarCreditoLimite.Checked, rbtNoPermitirFacturarCreditoLimite.Text,
                                 rbtAvisarPermitirFacturarCreditoLimite.Text)),
                           Nothing, String.Concat(grbPermitirControlarLimiteCredito.Text, " - ", lblCreditoLimite.Text))

      ActualizarParametroTexto(Entidades.Parametro.Parametros.CONTROLADIASVTODECREDITODECLIENTES,
                           If(rbtPermitirFacturarLimiteDiasVto.Checked, rbtPermitirFacturarLimiteDiasVto.Text,
                              If(rbtNoPermitirFacturarLimiteDiasVto.Checked, rbtNoPermitirFacturarLimiteDiasVto.Text,
                                 rbtAvisarPermitirFacturarLimiteDiasVto.Text)),
                           Nothing, String.Concat(grbPermitirControlarLimiteCredito.Text, " - ", lblLimiteDiasVto.Text))

      ActualizarParametro(Entidades.Parametro.Parametros.FACTURACIONIGNORARULTIMODIGITOCB, chbFacturacionIgnorarUltimoDigitoCB, Nothing, chbFacturacionIgnorarUltimoDigitoCB.Text)
      ActualizarParametro(Entidades.Parametro.Parametros.FACTURACIONAVISAPRODUCTOSENCERO, chbFacturacionAvisaProductosEnCero, Nothing, chbFacturacionAvisaProductosEnCero.Text)
      ActualizarParametro(Entidades.Parametro.Parametros.FACTURACIONPORCUENTAYORDEN, chbPorCtaOrden, Nothing, chbPorCtaOrden.Text)
      ActualizarParametro(Entidades.Parametro.Parametros.FACTURACIONSALDOCONTEMPLAHORA, chbSaldoContemplaHora, Nothing, chbSaldoContemplaHora.Text)
      ActualizarParametro(Entidades.Parametro.Parametros.SALDOTOMAACTUALALIMPRIMIR, chbSaldoTomaActual, Nothing, chbSaldoTomaActual.Text)


      'Columna 2

      ActualizarParametro(Entidades.Parametro.Parametros.DESCUENTOMAXIMO, txtDescuentoMaximo, Nothing, lblDescuentoMaximo.Text)

      ActualizarParametro(Entidades.Parametro.Parametros.FACTURACIONPERMITEMODIFICARCLIENTE, chbPermiteModificarCliente, Nothing, chbPermiteModificarCliente.Text)
      ActualizarParametro(Entidades.Parametro.Parametros.FACTURACIONDIASINVOCACIONCOMPROBANTES, txtDiasInvocacionComprobantes, Nothing, lblDiasInvocacionComprobantes.Text)

      '-- REQ-33678.- ---------------------------------------------------------------------
      ActualizarParametroTexto(Entidades.Parametro.Parametros.BUSQUEDACLIENTEFACTURACION, cmbBusquedaClienteDefault.Text, Nothing, lblBusquedaClienteDefault.Text)
      '------------------------------------------------------------------------------------


      ActualizarParametroTexto(Entidades.Parametro.Parametros.CALCULOCOMISIONVENDEDOR, cmbCalculoComisionVendedor.Text, Nothing, lblCalculoComisionVendedor.Text)
      ActualizarParametroTexto(Entidades.Parametro.Parametros.COMISIONVENDEDOR,
                           If(rbtComisionVendedorMarcaRubro.Checked, rbtComisionVendedorMarcaRubro.Tag.ToString(), rbtComisionVendedorRubroMarca.Tag.ToString()),
                           Nothing, grpComisionVendedor.Text)

      ActualizarParametro(Entidades.Parametro.Parametros.FACTURACIONGRABALIBRONOFUERZACONSFINAL, chbFacturacionComprobanteGrabaLibroNoFuerzaConsFinal, Nothing, chbFacturacionComprobanteGrabaLibroNoFuerzaConsFinal.Text)
      ActualizarParametro(Entidades.Parametro.Parametros.FACTURACIONPERMITECANTIDADNEGATIVA, chbFacturacionPermiteCantidadNegativa, Nothing, chbFacturacionPermiteCantidadNegativa.Text)
      ActualizarParametro(Entidades.Parametro.Parametros.FACTURACIONPERMITECANTIDADNEGATIVAACUMULADA, chbFacturacionPermiteCantidadNegativaAcumulada, Nothing, chbFacturacionPermiteCantidadNegativaAcumulada.Text)
      ActualizarParametro(Entidades.Parametro.Parametros.FACTURACIONMODIFICADESCRIPRODCANTIDAD, chbFacturacionModificaDescriProdCantidad, Nothing, chbFacturacionModificaDescriProdCantidad.Text)
      ActualizarParametro(Entidades.Parametro.Parametros.FACTURACIONMODIFICADESCRIPSOLICITAKILOS, chbFacturacionModificaDescripSolicKilos, Nothing, chbFacturacionModificaDescripSolicKilos.Text)
      ActualizarParametro(Entidades.Parametro.Parametros.FACTURACIONMODIFICADESCRIPSOLICITAPRECIO, chbFacturacionModificaDescripSolicitaPrecio, Nothing, chbFacturacionModificaDescripSolicitaPrecio.Text)
      ActualizarParametro(Entidades.Parametro.Parametros.FACTURACIONCLIENTECONTROLADNICF, chbFacturacionControlaDNIConsumidorFinal, Nothing, chbFacturacionControlaDNIConsumidorFinal.Text)
      ActualizarParametro(Entidades.Parametro.Parametros.FACTURACIONCONTROLATOPECF, txtControlTopeCF, Nothing, lblTopeCF.Text)

      ActualizarParametro(Entidades.Parametro.Parametros.FACTURACIONIMULAPERCEPCIONNGLIBRO, chbSimulaPercepcionNGLibro, Nothing, chbSimulaPercepcionNGLibro.Text)

   End Sub

End Class