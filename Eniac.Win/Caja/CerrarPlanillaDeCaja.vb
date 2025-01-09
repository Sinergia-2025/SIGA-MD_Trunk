Public Class CerrarPlanillaDeCaja

#Region "Campos"

   Private _muestraSaldoActual As Boolean
   Private _muestraSaldoCierre As Boolean
   Private _muestraTransferir As Boolean
   Private _muestraDestinoTransferencia As Boolean
   Private _muestraValores As Boolean
   Private _modoCierrePlanilla As Reglas.Cajas.ModoCerrarPlanilla
   Private _publicos As Publicos

#End Region

#Region "Overrides"

   Protected Overrides Sub OnLoad(e As EventArgs)
      MyBase.OnLoad(e)
      TryCatched(
         Sub()
            _publicos = New Publicos()

            _modoCierrePlanilla = Reglas.Publicos.CierrePlanillaCajaModo
            _muestraSaldoActual = False
            _muestraTransferir = False

            lblModoPantalla.Text = Publicos.GetEnumString(_modoCierrePlanilla).ToUpper()

            'Si se va a registrar un movimiento entre cajas al cerrar se debe mostrar este grupo de controles
            _muestraSaldoCierre = _modoCierrePlanilla = Reglas.Cajas.ModoCerrarPlanilla.CierreConMovimiento
            _muestraDestinoTransferencia = _modoCierrePlanilla = Reglas.Cajas.ModoCerrarPlanilla.CierreConMovimiento

            'Si se va a registrar un movimiento entre cajas al cerrar NO debe mostrar este grupo de controles
            _muestraValores = _modoCierrePlanilla = Reglas.Cajas.ModoCerrarPlanilla.CierreCiego

            ' Poner en true para pruebas
            '_muestraSaldoActual = True
            '_muestraTransferir = True
            '_muestraSaldoCierre = True
            '_muestraValores = True
            '_muestraDestinoTransferencia = True


            'carga las cajas.
            _publicos.CargaComboCajas(cmbCajas, actual.Sucursal.Id, miraUsuario:=True, miraPC:=False, cajasModificables:=True)

            _publicos.CargaComboSucursales(cmbSucursalDestino)
            cmbSucursalDestino.SelectedValue = Reglas.Publicos.CierrePlanillaCajaIdSucursalDestino


            InicializaControlesPantalla()

            txtPesos.Focus()
         End Sub)
   End Sub

   Protected Overrides Function ProcessCmdKey(ByRef msg As Message, keyData As Keys) As Boolean
      If keyData = Keys.F5 Then
         tsbRefrescar.PerformClick()
      ElseIf keyData = Keys.F4 Then
         tsbFinalizarPlanilla.PerformClick()
      Else
         Return MyBase.ProcessCmdKey(msg, keyData)
      End If
      Return True
   End Function

#End Region

#Region "Eventos"

   Private Sub tsbRefrescar_Click(sender As Object, e As EventArgs) Handles tsbRefrescar.Click
      TryCatched(Sub() CargarPlanillaActual(txtPesos))
   End Sub
   Private Sub tsbFinalizarPlanilla_Click(sender As Object, e As EventArgs) Handles tsbFinalizarPlanilla.Click
      TryCatched(Sub() FinalizarPlanilla())
   End Sub
   Private Sub tsbCerrar_Click(sender As Object, e As EventArgs) Handles tsbCerrar.Click
      TryCatched(Sub() Close())
   End Sub


   Private Sub cmbCajas_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbCajas.SelectedIndexChanged
      TryCatched(Sub() CargarPlanillaActual(nextFocus:=Nothing))
   End Sub
   Private Sub cmbSucursalDestino_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbSucursalDestino.SelectedIndexChanged
      TryCatched(
         Sub()
            Dim _idSucursalDestino = cmbSucursalDestino.ValorSeleccionado(Of Integer)()
            _publicos.CargaComboCajas(cmbCajasDestino, _idSucursalDestino, miraUsuario:=False, miraPC:=False, cajasModificables:=False)
            If cmbSucursalDestino.ValorSeleccionado(Of Integer) = Reglas.Publicos.CierrePlanillaCajaIdSucursalDestino Then
               cmbCajasDestino.SelectedValue = Reglas.Publicos.CierrePlanillaCajaIdCajaDestino
            Else
               cmbCajasDestino.SelectedIndex = -1
            End If
         End Sub)
   End Sub

   '-- REQ-35591.- ------------------------------------------------------------------------------------------------------
   Private Sub Controles_KeyDown(sender As Object, e As KeyEventArgs) Handles txtTicketsTransferir.KeyDown, txtTicketsSaldoCierre.KeyDown, txtTicketsSaldoActual.KeyDown, txtTickets.KeyDown, txtTarjetasTransferir.KeyDown, txtTarjetasSaldoActual.KeyDown, txtTarjetas.KeyDown, txtPesosTransferir.KeyDown, txtPesosSaldoCierre.KeyDown, txtPesosSaldoActual.KeyDown, txtPesos.KeyDown, txtPACFecha.KeyDown, txtNroPlanillaActual.KeyDown, txtDolaresTransferir.KeyDown, txtDolaresSaldoCierre.KeyDown, txtDolaresSaldoActual.KeyDown, txtDolares.KeyDown, txtCotizacionDolaresSaldoCierre.KeyDown, txtChequesTransferir.KeyDown, txtChequesSaldoActual.KeyDown, txtCheques.KeyDown, txtBancosTransferir.KeyDown, txtBancosSaldoCierre.KeyDown, txtBancosSaldoActual.KeyDown, txtBancosDolaresTransferir.KeyDown, txtBancosDolaresSaldoCierre.KeyDown, txtBancosDolaresSaldoActual.KeyDown, txtBancosDolares.KeyDown, txtBancos.KeyDown, cmbSucursalDestino.KeyDown, cmbCajasDestino.KeyDown, cmbCajas.KeyDown, chbEntregaCupones.KeyDown, chbEntregaCheques.KeyDown
      TryCatched(Sub() PresionarTab(e))
   End Sub
   '---------------------------------------------------------------------------------------------------------------------

   Private Sub txtSaldoCierre_Leave(sender As Object, e As EventArgs) Handles txtPesosSaldoCierre.Leave,
                                                                              txtTicketsSaldoCierre.Leave,
                                                                              txtDolaresSaldoCierre.Leave,
                                                                              txtBancosSaldoCierre.Leave,
                                                                              txtBancosDolaresSaldoCierre.Leave,
                                                                              chbEntregaCheques.CheckedChanged,
                                                                              chbEntregaCupones.CheckedChanged
      TryCatched(Sub() CalculaValoresParaMovimientoEntreCajas())
   End Sub

#End Region

#Region "Metodos Privados"

   Private Sub CalculaValoresParaMovimientoEntreCajas()
      If _modoCierrePlanilla = Reglas.Cajas.ModoCerrarPlanilla.CierreConMovimiento Then
         txtPesos.SetValor(txtPesosSaldoCierre.ValorNumericoPorDefecto(0D))
         txtCheques.SetValor(0)
         txtTarjetas.SetValor(0)
         txtTickets.SetValor(txtTicketsSaldoCierre.ValorNumericoPorDefecto(0D))
         txtBancos.SetValor(txtBancosSaldoCierre.ValorNumericoPorDefecto(0D))
         txtDolares.SetValor(txtDolaresSaldoCierre.ValorNumericoPorDefecto(0D))
         txtBancosDolares.SetValor(txtBancosDolaresSaldoCierre.ValorNumericoPorDefecto(0D))

         txtPesosTransferir.SetValor(txtPesosSaldoActual.ValorNumericoPorDefecto(0D) - txtPesosSaldoCierre.ValorNumericoPorDefecto(0D))
         txtChequesTransferir.SetValor(If(chbEntregaCheques.Checked, txtChequesSaldoActual.ValorNumericoPorDefecto(0D), 0D))
         txtTarjetasTransferir.SetValor(If(chbEntregaCupones.Checked, txtTarjetasSaldoActual.ValorNumericoPorDefecto(0D), 0D))
         txtTicketsTransferir.SetValor(txtTicketsSaldoActual.ValorNumericoPorDefecto(0D) - txtTicketsSaldoCierre.ValorNumericoPorDefecto(0D))
         txtBancosTransferir.SetValor(txtBancosSaldoActual.ValorNumericoPorDefecto(0D) - txtBancosSaldoCierre.ValorNumericoPorDefecto(0D))
         txtDolaresTransferir.SetValor(txtDolaresSaldoActual.ValorNumericoPorDefecto(0D) - txtDolaresSaldoCierre.ValorNumericoPorDefecto(0D))
         txtBancosDolaresTransferir.SetValor(txtBancosDolaresSaldoActual.ValorNumericoPorDefecto(0D) - txtBancosDolaresSaldoCierre.ValorNumericoPorDefecto(0D))
      End If
   End Sub

   Private Sub CargarPlanillaActual(nextFocus As Control)
      If cmbCajas.SelectedIndex > -1 Then
         Dim idCaja = cmbCajas.ValorSeleccionado(Of Integer)()
         Dim oPlanilla = New Reglas.Cajas().GetPlanillaActualONuevaConSaldoFinalCalculado(actual.Sucursal.Id, idCaja)
         If oPlanilla IsNot Nothing Then
            txtNroPlanillaActual.Text = oPlanilla.NumeroPlanilla.ToString()
            txtPACFecha.Text = oPlanilla.FechaPlanilla.ToString("dd/MM/yyyy")

            txtPesosSaldoActual.SetValor(oPlanilla.PesosSaldoFinal)
            txtChequesSaldoActual.SetValor(oPlanilla.ChequesSaldoFinal)
            txtTarjetasSaldoActual.SetValor(oPlanilla.TarjetasSaldoFinal)
            txtTicketsSaldoActual.SetValor(oPlanilla.TicketsSaldoFinal)
            txtBancosSaldoActual.SetValor(oPlanilla.BancosSaldoFinal)
            txtDolaresSaldoActual.SetValor(oPlanilla.DolaresSaldoFinal)
            txtBancosDolaresSaldoActual.SetValor(oPlanilla.BancosDolaresSaldoFinal)

            txtPesosSaldoCierre.SetValor(0)
            chbEntregaCheques.Checked = True
            chbEntregaCupones.Checked = True
            txtTicketsSaldoCierre.SetValor(0)
            txtBancosSaldoCierre.SetValor(0)
            txtDolaresSaldoCierre.SetValor(0)
            txtBancosDolaresSaldoCierre.SetValor(0)

            Dim cotDolar = New Reglas.Monedas().GetUna(Entidades.Moneda.Dolar).FactorConversion
            txtCotizacionDolaresSaldoCierre.SetValor(cotDolar)

            txtPesosTransferir.SetValor(0)
            txtChequesTransferir.SetValor(0)
            txtTarjetasTransferir.SetValor(0)
            txtTicketsTransferir.SetValor(0)
            txtBancosTransferir.SetValor(0)
            txtDolaresTransferir.SetValor(0)
            txtBancosDolaresTransferir.SetValor(0)

            txtPesos.SetValor(0)
            txtCheques.SetValor(0)
            txtTarjetas.SetValor(0)
            txtTickets.SetValor(0)
            txtBancos.SetValor(0)
            txtDolares.SetValor(0)
            txtBancosDolares.SetValor(0)
         End If
         If nextFocus IsNot Nothing Then
            nextFocus.Select()
         End If
         CalculaValoresParaMovimientoEntreCajas()
      End If
   End Sub

   Private Sub FinalizarPlanilla()
      If cmbCajas.SelectedIndex > -1 Then
         Dim idCaja = cmbCajas.ValorSeleccionado(Of Integer)()

         If txtPesos.ValorNumericoPorDefecto(0D) = 0 Then
            If ShowPregunta("¿ Esta seguro de cerrar la planilla con Pesos en Cero ?", MessageBoxDefaultButton.Button2) = DialogResult.No Then
               Exit Sub
            End If
         End If

         Dim mensaje = "¿Cerrar la planilla implica abrir una nueva y convertirla en actual, realmente desea cerrar la planilla actual? "

         If ShowPregunta(mensaje) = Windows.Forms.DialogResult.Yes Then

            Dim oCaja = New Reglas.Cajas()

            Dim decSaldoChequesReal = oCaja.GetSaldoChequesFinal(actual.Sucursal.Id, idCaja, txtNroPlanillaActual.Text.ValorNumericoPorDefecto(0I))
            Dim oCheques = New Reglas.Cheques()
            If oCheques.GetSaldoChequesEnCartera(actual.Sucursal.Id, idCaja) <> decSaldoChequesReal Then
               Dim stb = New StringBuilder("Tiene Diferenia en el Saldo de Cheques con aquellos EN CARTERA.").AppendLine().AppendLine()
               stb.Append("NO podra Finalizar la Planilla. Por favor contactese con Sistemas!!")
               ShowMessage(stb.ToString())
               Exit Sub
            End If

            '-- REQ-43585.- ------------------------------------------------------------------------------------------------------------
            Dim decSaldoTarjetaReal = oCaja.GetSaldoTarjetasFinal(actual.Sucursal.Id, idCaja, txtNroPlanillaActual.Text.ValorNumericoPorDefecto(0I))
            Dim oCupones = New Reglas.TarjetasCupones()
            If oCupones.GetSaldoCuponesEnCartera(actual.Sucursal.Id, idCaja) <> decSaldoTarjetaReal Then
               Dim stb = New StringBuilder("Tiene Diferenia en el Saldo de Tarjetas con aquellas EN CARTERA.").AppendLine().AppendLine()
               stb.Append("NO podra Finalizar la Planilla. Por favor contactese con Sistemas!!")
               ShowMessage(stb.ToString())
               Exit Sub
            End If
            '---------------------------------------------------------------------------------------------------------------------------

            oCaja.CerrarPlanilla(actual.Sucursal.Id, idCaja, txtNroPlanillaActual.Text.ValorNumericoPorDefecto(0I),
                                 txtPesos.ValorNumericoPorDefecto(0D), txtDolares.ValorNumericoPorDefecto(0D),
                                 txtTickets.ValorNumericoPorDefecto(0D), txtCheques.ValorNumericoPorDefecto(0D),
                                 txtTarjetas.ValorNumericoPorDefecto(0D), 0D,
                                 txtBancos.ValorNumericoPorDefecto(0D), txtBancosDolares.ValorNumericoPorDefecto(0D),
                                 cmbSucursalDestino.ValorSeleccionado(Of Integer?)(_modoCierrePlanilla = Reglas.Cajas.ModoCerrarPlanilla.CierreConMovimiento, Nothing),
                                 cmbCajasDestino.ValorSeleccionado(Of Integer?)(_modoCierrePlanilla = Reglas.Cajas.ModoCerrarPlanilla.CierreConMovimiento, Nothing),
                                 txtPesosTransferir.ValorNumericoPorDefecto(0D),
                                 chbEntregaCheques.Checked, chbEntregaCupones.Checked,
                                 txtTicketsTransferir.ValorNumericoPorDefecto(0D), txtBancosTransferir.ValorNumericoPorDefecto(0D),
                                 txtDolaresTransferir.ValorNumericoPorDefecto(0D), txtBancosDolaresTransferir.ValorNumericoPorDefecto(0D),
                                 txtCotizacionDolaresSaldoCierre.ValorNumericoPorDefecto(0D))

            ShowMessage("¡¡ Caja Finalizada Correctamente !!")
            Close()
         End If
      End If

   End Sub


   Private Sub InicializaControlesPantalla()
      lblSaldoActual.Visible = _muestraSaldoActual
      txtPesosSaldoActual.Visible = _muestraSaldoActual
      txtChequesSaldoActual.Visible = _muestraSaldoActual
      txtTarjetasSaldoActual.Visible = _muestraSaldoActual
      txtTicketsSaldoActual.Visible = _muestraSaldoActual
      txtBancosSaldoActual.Visible = _muestraSaldoActual
      txtDolaresSaldoActual.Visible = _muestraSaldoActual
      txtBancosDolaresSaldoActual.Visible = _muestraSaldoActual

      lblSaldoCierre.Visible = _muestraSaldoCierre
      txtPesosSaldoCierre.Visible = _muestraSaldoCierre
      chbEntregaCheques.Visible = _muestraSaldoCierre
      chbEntregaCupones.Visible = _muestraSaldoCierre
      txtTicketsSaldoCierre.Visible = _muestraSaldoCierre
      txtBancosSaldoCierre.Visible = _muestraSaldoCierre
      txtDolaresSaldoCierre.Visible = _muestraSaldoCierre
      txtBancosDolaresSaldoCierre.Visible = _muestraSaldoCierre
      txtCotizacionDolaresSaldoCierre.Visible = _muestraSaldoCierre
      lblCotizacionDolares.Visible = _muestraSaldoCierre

      lblSaldoFinal.Visible = _muestraTransferir
      txtPesosTransferir.Visible = _muestraTransferir
      txtChequesTransferir.Visible = _muestraTransferir
      txtTarjetasTransferir.Visible = _muestraTransferir
      txtTicketsTransferir.Visible = _muestraTransferir
      txtBancosTransferir.Visible = _muestraTransferir
      txtDolaresTransferir.Visible = _muestraTransferir
      txtBancosDolaresTransferir.Visible = _muestraTransferir


      lblSucursalDestino.Visible = _muestraDestinoTransferencia
      lblCajaDestino.Visible = _muestraDestinoTransferencia
      cmbSucursalDestino.Visible = _muestraDestinoTransferencia
      cmbCajasDestino.Visible = _muestraDestinoTransferencia


      lblValores.Visible = _muestraValores
      txtPesos.Visible = _muestraValores
      txtCheques.Visible = _muestraValores
      txtTarjetas.Visible = _muestraValores
      txtTickets.Visible = _muestraValores
      txtBancos.Visible = _muestraValores
      txtDolares.Visible = _muestraValores
      txtBancosDolares.Visible = _muestraValores

   End Sub

#End Region

End Class