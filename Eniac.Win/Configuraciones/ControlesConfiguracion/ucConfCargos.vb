Public Class ucConfCargos

   Protected Overrides Sub OnInicializando(e As InicializarEventArgs)
      MyBase.OnInicializando(e)

      e.Publicos.CargaComboTiposComprobantes(cmbCargosConceptoExpensasTiposComprobantes, False, "VENTAS", , , , True)
      e.Publicos.CargaComboFormasDePago(cmbFormaPagoExpensas, "VENTAS")
      e.Publicos.CargaComboDesdeEnum(cmbFechaFacturaExpensas, GetType(Reglas.Publicos.FechaFacturacionEnum), , True)
      e.Publicos.CargaComboDesdeEnum(cmbPeriodoFacturaExpensas, GetType(Reglas.Publicos.PeriodoFacturacionEnum), , True)

      If Not Reglas.Publicos.TieneModuloCargos Then
         cmbCargosConceptoExpensasTiposComprobantes.SelectedIndex = 0
         cmbFechaFacturaExpensas.SelectedIndex = 0
         cmbFormaPagoExpensas.SelectedIndex = 0
         cmbPeriodoFacturaExpensas.SelectedIndex = 0
      End If

   End Sub

   Protected Overrides Sub OnCargando(e As CancelableEventArgs)
      MyBase.OnCargando(e)

      'Cargos
      cmbFormaPagoExpensas.SelectedValue = Reglas.Publicos.ExpensasFormaPago
      cmbCargosConceptoExpensasTiposComprobantes.SelectedValue = Reglas.Publicos.ExpensasTipoComprobantes
      cmbFechaFacturaExpensas.SelectedValue = Reglas.Publicos.ExpensasFechaFactura
      cmbPeriodoFacturaExpensas.SelectedValue = Reglas.Publicos.ExpensasPeriodoFactura

      chbCargosGenerarComprobantePorItem.Checked = Reglas.Publicos.CargosGenerarComprobantePorItem
      chbObservacionProductos.Checked = Reglas.Publicos.VerObservacion
      chbCargosPasajeMovimientoTomaComprobanteCompleto.Checked = Reglas.Publicos.CargosPasajeMovimientoTomaComprobanteCompleto
      chbCargosUtilizaDescRecargos.Checked = Reglas.Publicos.CargosUtilizaDescuentosRecargos
      chbCargosPermiteGenerarLiquidacionSinClientes.Checked = Reglas.Publicos.CargosPermiteGenerarLiquidacionSinClientes


   End Sub

   Protected Overrides Sub OnGrabando(e As CancelableEventArgs)
      MyBase.OnGrabando(e)

      'Cargos
      If Reglas.Publicos.TieneModuloCargos Then
         If cmbFormaPagoExpensas.SelectedIndex > -1 Then
            ActualizarParametro(Of Integer)(Entidades.Parametro.Parametros.CARGOSEXPENSASFORMAPAGO, cmbFormaPagoExpensas, Nothing, lblFormaPagoExpensas.Text)
         End If
         If cmbCargosConceptoExpensasTiposComprobantes.SelectedIndex > -1 Then
            ActualizarParametro(Of String)(Entidades.Parametro.Parametros.CARGOSEXPENSASTIPOCOMPROBANTE, cmbCargosConceptoExpensasTiposComprobantes, Nothing, lblCargosConceptoExpensasTipoComprobante.Text)
         End If
         ActualizarParametro(Of String)(Entidades.Parametro.Parametros.CARGOSEXPENSASFECHAFACTURA, cmbFechaFacturaExpensas, Nothing, lblFechaFacturaExpensas.Text)
         ActualizarParametro(Of String)(Entidades.Parametro.Parametros.CARGOSEXPENSASPERIODOFACTURA, cmbPeriodoFacturaExpensas, Nothing, lblPeriodoFacturaExpensas.Text)

         ActualizarParametro(Entidades.Parametro.Parametros.CARGOSGENERARCOMPROBANTEPORITEM, chbCargosGenerarComprobantePorItem, Nothing, chbCargosGenerarComprobantePorItem.Text)
         ActualizarParametro(Entidades.Parametro.Parametros.VEROBSERVACIONES, chbObservacionProductos, Nothing, chbObservacionProductos.Text)
         ActualizarParametro(Entidades.Parametro.Parametros.CARGOSPASAJEMOVIMIENTOTOMACOMPROBANTECOMPLETO, chbCargosPasajeMovimientoTomaComprobanteCompleto, Nothing, chbCargosPasajeMovimientoTomaComprobanteCompleto.Text)
         ActualizarParametro(Entidades.Parametro.Parametros.CARGOSUTILIZADESCUENTOSRECARGOS, chbCargosUtilizaDescRecargos, Nothing, chbCargosUtilizaDescRecargos.Text)
         ActualizarParametro(Entidades.Parametro.Parametros.CARGOSPERMITEGENERARLIQUIDACIONSINCLIENTES, chbCargosPermiteGenerarLiquidacionSinClientes, Nothing, chbCargosPermiteGenerarLiquidacionSinClientes.Text)


      End If

   End Sub

End Class