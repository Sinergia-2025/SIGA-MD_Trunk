Public Class ucConfCaja
   Private _publicos As Publicos

   Protected Overrides Sub OnInicializando(e As InicializarEventArgs)
      MyBase.OnInicializando(e)
      _publicos = e.Publicos
      e.Publicos.CargaComboDesdeEnum(cmbModoCierrePlanillaCaja, GetType(Reglas.Cajas.ModoCerrarPlanilla))
      e.Publicos.CargaComboSucursales(cmbSucursalDestino)
   End Sub

   Protected Overrides Sub OnCargando(e As CancelableEventArgs)
      MyBase.OnCargando(e)
      chbCajaAcumulaVentas.Checked = Reglas.Publicos.CtaCajaVentasAcumula
      chbCajaMostrarNCIndividual.Checked = Reglas.Publicos.CajaMostrarNCIndividual
      chbCajaUtilizaSaldosDigitados.Checked = Reglas.Publicos.CajaUtilizaSaldosDigitados
      chbCajaPlanillaMuestraProductosConAlerta.Checked = Reglas.Publicos.CajaPlanillaMuestraProductosConAlerta
      chbCajaPlanillaMuestraVentasEnCtaCte.Checked = Reglas.Publicos.CajaPlanillaMuestraVentasEnCtaCte
      chbPermiteMovimientoSinSaldo.Checked = Reglas.Publicos.CajaPermitirMovSinSaldo
      chbFechaPlanillaDelDia.Checked = Reglas.Publicos.CajaPlanillaFechaDia
      chbCajaPredPorPC.Checked = Reglas.Publicos.PlanillaCajaPredPorPC

      Select Case Reglas.Publicos.OrdenarCobranzaPor
         Case rbtOrdenarCobranzaPorFecha.Tag.ToString()
            rbtOrdenarCobranzaPorFecha.Checked = True
         Case Else
            rbtOrdenarCobranzaPorVendedor.Checked = True
      End Select

      cmbSucursalDestino.SelectedValue = Reglas.Publicos.CierrePlanillaCajaIdSucursalDestino
      cmbCajasDestino.SelectedValue = Reglas.Publicos.CierrePlanillaCajaIdCajaDestino
      cmbModoCierrePlanillaCaja.SelectedValue = Reglas.Publicos.CierrePlanillaCajaModo


      txtCuentaCajaVentas.Text = Reglas.Publicos.CtaCajaVentas.ToString()
      txtCuentaCajaRecibos.Text = Reglas.Publicos.CtaCajaRecibos.ToString()
      txtCuentaCajaCompras.Text = Reglas.Publicos.CtaCajaCompras.ToString()
      txtCuentaCajaPagoProveedores.Text = Reglas.Publicos.CtaCajaPago.ToString()
      txtCuentaCajaTransfBancaria.Text = Reglas.Publicos.CtaCajaTransfBancaria.ToString()
      txtCuentaCajaDeposito.Text = Reglas.Publicos.CtaCajaDeposito.ToString()
      txtCuentaCajaMovCheques.Text = Reglas.Publicos.CtaCajaMovCheques.ToString()
      txtCuentaCajaDepositoTarjetas.Text = Reglas.Publicos.CtaCajaDepositoTarjetas.ToString()
      txtCuentaCajaExtraccionesBancarias.Text = Reglas.Publicos.CtaCajaExtraccion.ToString()
      txtCuentaCajaLiquidacionesTarjetas.Text = Reglas.Publicos.CtaCajaLiquidacionesTarjetas.ToString()
      txtCuentaCajaLiquidacionesTarjetas.Text = Reglas.Publicos.CtaCajaLiquidacionesTarjetas.ToString()

      chbNegativoImporteTotal.Checked = Reglas.Publicos.PlanillaCajaImportesNegativosTotal
      chbNegativoImportePesos.Checked = Reglas.Publicos.PlanillaCajaImportesNegativosPesos
      chbNegativoImporteTickets.Checked = Reglas.Publicos.PlanillaCajaImportesNegativosTickets
      chbNegativoImporteBancos.Checked = Reglas.Publicos.PlanillaCajaImportesNegativosBancos
      chbNegativoImporteDolares.Checked = Reglas.Publicos.PlanillaCajaImportesNegativosDolares
   End Sub

   Protected Overrides Sub OnGrabando(e As CancelableEventArgs)
      MyBase.OnGrabando(e)
      ActualizarParametro(Entidades.Parametro.Parametros.CTACAJAVENTASACUMULA, chbCajaAcumulaVentas, Nothing, chbCajaAcumulaVentas.Text)
      ActualizarParametro(Entidades.Parametro.Parametros.CAJAMOSTRARNCINDIVIDUAL, chbCajaMostrarNCIndividual, Nothing, chbCajaMostrarNCIndividual.Text)
      ActualizarParametro(Entidades.Parametro.Parametros.CAJAUTILIZASALDOSDIGITADOS, chbCajaUtilizaSaldosDigitados, Nothing, chbCajaUtilizaSaldosDigitados.Text)
      ActualizarParametro(Entidades.Parametro.Parametros.CAJAPLANILLAMUESTRAPRODUCTOSCONALERTA, chbCajaPlanillaMuestraProductosConAlerta, Nothing, chbCajaPlanillaMuestraProductosConAlerta.Text)
      ActualizarParametro(Entidades.Parametro.Parametros.CAJAPLANILLAMUESTRAVENTASENCTACTE, chbCajaPlanillaMuestraVentasEnCtaCte, Nothing, chbCajaPlanillaMuestraVentasEnCtaCte.Text)
      ActualizarParametro(Entidades.Parametro.Parametros.CAJAPERMITIRMOVSINSALDO, chbPermiteMovimientoSinSaldo, Nothing, chbPermiteMovimientoSinSaldo.Text)
      ActualizarParametro(Entidades.Parametro.Parametros.CAJAPLANILLAFECHADIA, chbFechaPlanillaDelDia, Nothing, chbFechaPlanillaDelDia.Text)
      ActualizarParametro(Entidades.Parametro.Parametros.PLANILLACAJAPREDPORPC, chbCajaPredPorPC, Nothing, chbCajaPredPorPC.Text)

      ActualizarParametroTexto(Entidades.Parametro.Parametros.ORDENARCOBRANZAPOR,
                           If(rbtOrdenarCobranzaPorFecha.Checked, rbtOrdenarCobranzaPorFecha.Tag.ToString(), rbtOrdenarCobranzaPorVendedor.Tag.ToString()),
                           Nothing, gpbOrdenarCobranzaPor.Text)

      Dim modo = cmbModoCierrePlanillaCaja.ValorSeleccionado(Of Reglas.Cajas.ModoCerrarPlanilla)()
      ActualizarParametroTexto(Entidades.Parametro.Parametros.CIERREPLANILLACAJAMODO, modo.ToString(), Nothing, lblModoCierrePlanillaCaja.Text)
      If modo = Reglas.Cajas.ModoCerrarPlanilla.CierreConMovimiento Then
         ActualizarParametro(Of Integer)(Entidades.Parametro.Parametros.CIERREPLANILLACAJAIDSUCURSALDESTINO, cmbSucursalDestino, Nothing, lblSucursalDestino.Text)
         ActualizarParametro(Of Integer)(Entidades.Parametro.Parametros.CIERREPLANILLACAJAIDCAJADESTINO, cmbCajasDestino, Nothing, lblCajaDestino.Text)
      Else
         ActualizarParametroTexto(Entidades.Parametro.Parametros.CIERREPLANILLACAJAIDSUCURSALDESTINO, "-1", Nothing, lblSucursalDestino.Text)
         ActualizarParametroTexto(Entidades.Parametro.Parametros.CIERREPLANILLACAJAIDCAJADESTINO, "-1", Nothing, lblCajaDestino.Text)
      End If


      ActualizarParametro(Entidades.Parametro.Parametros.CTACAJAVENTAS, txtCuentaCajaVentas, Nothing, lblCuentaCajaVentas.Text)
      ActualizarParametro(Entidades.Parametro.Parametros.CTACAJARECIBOS, txtCuentaCajaRecibos, Nothing, lblCuentaCajaRecibos.Text)
      ActualizarParametro(Entidades.Parametro.Parametros.CTACAJACOMPRAS, txtCuentaCajaCompras, Nothing, lblCuentaCajaCompras.Text)
      ActualizarParametro(Entidades.Parametro.Parametros.CTACAJAPAGO, txtCuentaCajaPagoProveedores, Nothing, lblCuentaCajaPagoProveedores.Text)
      ActualizarParametro(Entidades.Parametro.Parametros.CTACAJATRANSFBANCARIA, txtCuentaCajaTransfBancaria, Nothing, lblCuentaCajaTransfBancaria.Text)
      ActualizarParametro(Entidades.Parametro.Parametros.CTACAJADEPOSITO, txtCuentaCajaDeposito, Nothing, lblCuentaCajaDeposito.Text)
      ActualizarParametro(Entidades.Parametro.Parametros.CTACAJAMOVCHEQUES, txtCuentaCajaMovCheques, Nothing, lblCuentaCajaMovimientoChequesSucursales.Text)
      ActualizarParametro(Entidades.Parametro.Parametros.CTACAJADEPOSITOTARJETAS, txtCuentaCajaDepositoTarjetas, Nothing, lblCuentaCajaDepositoTarjeta.Text)
      ActualizarParametro(Entidades.Parametro.Parametros.CTACAJAEXTRACCION, txtCuentaCajaExtraccionesBancarias, Nothing, lblCuentaCajaExtraccionesBancarias.Text)
      ActualizarParametro(Entidades.Parametro.Parametros.CTACAJALIQUIDACIONTARJETA, txtCuentaCajaLiquidacionesTarjetas, Nothing, lblCuentaCajaLiquidacionesTarjetas.Text)

      ActualizarParametro(Entidades.Parametro.Parametros.CAJAIMPORTESNEGATIVOSTOTAL, chbNegativoImporteTotal, Nothing, chbNegativoImporteTotal.Text)
      ActualizarParametro(Entidades.Parametro.Parametros.CAJAIMPORTESNEGATIVOSPESOS, chbNegativoImportePesos, Nothing, chbNegativoImportePesos.Text)
      ActualizarParametro(Entidades.Parametro.Parametros.CAJAIMPORTESNEGATIVOSTICKETS, chbNegativoImporteTickets, Nothing, chbNegativoImporteTickets.Text)
      ActualizarParametro(Entidades.Parametro.Parametros.CAJAIMPORTESNEGATIVOSBANCOS, chbNegativoImporteBancos, Nothing, chbNegativoImporteBancos.Text)
      ActualizarParametro(Entidades.Parametro.Parametros.CAJAIMPORTESNEGATIVOSDOLARES, chbNegativoImporteDolares, Nothing, chbNegativoImporteDolares.Text)

   End Sub

   Protected Overrides Sub OnValidando(e As ValidacionEventArgs)
      MyBase.OnValidando(e)

      If txtCuentaCajaRecibos.Text = txtCuentaCajaVentas.Text Then
         e.AgregarError("La cuenta de Caja para Ventas es igual a la Cuenta de Caja para Recibos.")
         txtCuentaCajaVentas.Focus()
      End If

      If cmbModoCierrePlanillaCaja.ValorSeleccionado(Of Reglas.Cajas.ModoCerrarPlanilla)() = Reglas.Cajas.ModoCerrarPlanilla.CierreConMovimiento And
         (cmbSucursalDestino.SelectedIndex = -1 Or cmbCajasDestino.SelectedIndex = -1) Then
         e.AgregarError(String.Format("Debe seleccionar una sucursal/caja para el modo {0}.", cmbModoCierrePlanillaCaja.Text))
         cmbCajasDestino.Focus()
      End If

   End Sub

   Private Sub cmbSucursalDestino_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbSucursalDestino.SelectedIndexChanged
      FindForm().TryCatched(
         Sub()
            Dim _idSucursalDestino = cmbSucursalDestino.ValorSeleccionado(Of Integer)()
            _publicos.CargaComboCajas(cmbCajasDestino, _idSucursalDestino, miraUsuario:=False, miraPC:=False, cajasModificables:=False)
         End Sub)
   End Sub

   Private Sub cmbModoCierrePlanillaCaja_SelectedValueChanged(sender As Object, e As EventArgs) Handles cmbModoCierrePlanillaCaja.SelectedValueChanged
      FindForm().TryCatched(
         Sub()
            cmbSucursalDestino.Enabled = cmbModoCierrePlanillaCaja.ValorSeleccionado(Of Reglas.Cajas.ModoCerrarPlanilla)() = Reglas.Cajas.ModoCerrarPlanilla.CierreConMovimiento
            cmbCajasDestino.Enabled = cmbSucursalDestino.Enabled
         End Sub)
   End Sub
End Class