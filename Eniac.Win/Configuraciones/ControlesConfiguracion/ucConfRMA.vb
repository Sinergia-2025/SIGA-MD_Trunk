Public Class ucConfRMA
   Private _publicos As Publicos
   Protected Overrides Sub OnInicializando(e As InicializarEventArgs)
      MyBase.OnInicializando(e)

      '-- Carga el combo de lista de precios.- --
      e.Publicos.CargaComboListasDePrecios(cmbListaPrecioFacturar, seleccionMultiple:=False, seleccionTodos:=False)
      '-- Carga los combos de Tipos de Movimientos.- --
      e.Publicos.CargaComboTiposMovimientos(cmbMovimientoConsumo)
      e.Publicos.CargaComboTiposMovimientos(cmbMovimientoReversado)
      e.Publicos.CargaComboTiposMovimientos(cmbMovimientoReserva)
      e.Publicos.CargaComboTiposMovimientos(cmbMovimientoDevReserva)
      e.Publicos.CargaComboFormaDePago(cmbFormaPago, tipo:="VENTAS", esContado:=False, seleccionMultiple:=False, seleccionTodos:=False)
      '------------------------------------------
      e.Publicos.CargaComboDepositos(cmbDepositoOrigen, actual.Sucursal.IdSucursal, miraUsuario:=False, permiteEscritura:=False, Entidades.Publicos.SiNoTodos.SI,
                                     False, tipos:={Entidades.SucursalDeposito.TiposDepositos.RESERVADO})
      If DirectCast(cmbDepositoOrigen.DataSource, DataTable).Count > 0 Then
         cmbDepositoOrigen.SelectedIndex = 0
      End If

   End Sub
   Protected Overrides Sub OnCargando(e As CancelableEventArgs)
      MyBase.OnCargando(e)

      chbImprime1copiaNR.Checked = Reglas.Publicos.Imprime1copiaNR
      txtCRMNovedadesProductoFacturable.Text = Reglas.Publicos.CRMNovedadesProductoFacturable.ToString()
      txtCRMNovedadesObservacionFacturable.Text = Reglas.Publicos.CRMNovedadesObservacionFacturable.ToString()
      txtRMACantidadMesesHistorico.Text = Reglas.Publicos.RMACantidadMesesHistorico.ToString()

      cmbListaPrecioFacturar.SelectedValue = Reglas.Publicos.CRMListaPrecioFacturar
      cmbMovimientoConsumo.SelectedValue = Reglas.Publicos.CRMNovedadesMovimientoConsumo
      cmbMovimientoReversado.SelectedValue = Reglas.Publicos.CRMNovedadesMovimientoReversado
      cmbFormaPago.SelectedValue = Reglas.Publicos.CRMNovedadesFormaDePago
      chkCopiarSaldoComoEfectivoAlFacturar.Checked = Reglas.Publicos.CRMNovedadesCopiarSaldoComoEfectivoAlFacturar
      chbProductosRepNoFactura.Checked = Reglas.Publicos.RMAProductosConsumidosNoFactura
      cmbDepositoOrigen.SelectedValue = Reglas.Publicos.CRMNovedadesDepositoReserva
      cmbUbicacionOrigen.SelectedValue = Reglas.Publicos.CRMNovedadesUbicacionReserva
      cmbMovimientoReserva.SelectedValue = Reglas.Publicos.CRMNovedadesMovimientoReserva
      cmbMovimientoDevReserva.SelectedValue = Reglas.Publicos.CRMNovedadesMovimientoDevReserva

   End Sub

   Protected Overrides Sub OnGrabando(e As CancelableEventArgs)
      MyBase.OnGrabando(e)

      ActualizarParametro(Entidades.Parametro.Parametros.SERVICEIMPRIMEUNACOPIANR, chbImprime1copiaNR, Nothing, chbImprime1copiaNR.Text)
      ActualizarParametro(Entidades.Parametro.Parametros.CRMNOVEDADESPRODUCTOFACTURABLE, txtCRMNovedadesProductoFacturable, Nothing, lblCRMNovedadesProductoFacturable.Text)
      ActualizarParametro(Entidades.Parametro.Parametros.CRMNOVEDADESOBSERVACIONFACTURABLE, txtCRMNovedadesObservacionFacturable, Nothing, lblCRMNovedadesObservacionFacturable.Text)
      ActualizarParametro(Entidades.Parametro.Parametros.RMACANTIDADMESESHISTORICO, txtRMACantidadMesesHistorico, Nothing, lblRMACantidadMesesHistorico.Text)

      ActualizarParametro(Of Integer)(Entidades.Parametro.Parametros.CRMNOVEDADESLISTAPRECIOFACTURAR, cmbListaPrecioFacturar, Nothing, lblListaPrecioFacturar.Text)
      ActualizarParametro(Of String)(Entidades.Parametro.Parametros.CRMMOVIMIENTOCONSUMO, cmbMovimientoConsumo, Nothing, lblMovimientoConsumo.Text)
      ActualizarParametro(Of String)(Entidades.Parametro.Parametros.CRMMOVIMIENTOREVERSADO, cmbMovimientoReversado, Nothing, lblMovimientoReversado.Text)

      If cmbFormaPago.SelectedIndex > -1 Then
         ActualizarParametro(Of Integer)(Entidades.Parametro.Parametros.CRMNOVEDADESFORMADEPAGO, cmbFormaPago, Nothing, lblFormaPago.Text)
      Else
         ActualizarParametroTexto(Entidades.Parametro.Parametros.CRMNOVEDADESFORMADEPAGO, "0", Nothing, lblFormaPago.Text)
      End If

      ActualizarParametro(Entidades.Parametro.Parametros.CRMNOVEDADESCOPIARSALDOCOMOEFECTIVOALFACTURAR, chkCopiarSaldoComoEfectivoAlFacturar, Nothing, chkCopiarSaldoComoEfectivoAlFacturar.Text)
      ActualizarParametro(Entidades.Parametro.Parametros.RMAPRODUCTOSCONSUMIDOSNOFACTURA, chbProductosRepNoFactura, Nothing, chbProductosRepNoFactura.Text)

      ActualizarParametro(Of Integer)(Entidades.Parametro.Parametros.CRMNOVEDADESDEPOSITORESERVA, cmbDepositoOrigen, Nothing, lblDepositoOrigen.Text)
      ActualizarParametro(Of Integer)(Entidades.Parametro.Parametros.CRMNOVEDADESUBICACIONRESERVA, cmbUbicacionOrigen, Nothing, lblUbicacionReserva.Text)

      ActualizarParametro(Of String)(Entidades.Parametro.Parametros.CRMMOVIMIENTORESERVA, cmbMovimientoReserva, Nothing, lblMovimientoReserva.Text)
      ActualizarParametro(Of String)(Entidades.Parametro.Parametros.CRMMOVIMIENTODEVRESERVA, cmbMovimientoDevReserva, Nothing, lblMovimientoDevReserva.Text)

   End Sub
   Private Sub cmbDepositoOrigen_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbDepositoOrigen.SelectedIndexChanged
      Dim vDepo = If(cmbDepositoOrigen.SelectedValue Is Nothing, 1, Integer.Parse(cmbDepositoOrigen.SelectedValue.ToString()))
      _publicos = New Publicos()
      _Publicos.CargaComboUbicaciones(cmbUbicacionOrigen, vDepo, actual.Sucursal.IdSucursal)
   End Sub
End Class
