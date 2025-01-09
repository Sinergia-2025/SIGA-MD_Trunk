Public Class AnularPagosAProveedores

#Region "Campos"

   Private _ComprobantesGrilla As New List(Of Entidades.CuentaCorrienteProvPago)()
   Private _chequesPropios As List(Of Entidades.Cheque)
   Private _chequesTerceros As List(Of Entidades.Cheque)
   Private _proveedorGrilla As Entidades.Proveedor
   Private _pago As Entidades.CuentaCorrienteProv
   Private _publicos As Publicos = New Publicos()

   Dim _titComp As Dictionary(Of String, String)
   Dim _titChPr As Dictionary(Of String, String)
   Dim _titCh3r As Dictionary(Of String, String)

#End Region

#Region "Overrides"

   Protected Overrides Sub OnLoad(e As EventArgs)
      MyBase.OnLoad(e)
      TryCatched(
      Sub()
         _chequesPropios = New List(Of Entidades.Cheque)()
         _chequesTerceros = New List(Of Entidades.Cheque)()

         _publicos.CargaComboCajas(cmbCajas, actual.Sucursal.IdSucursal, miraUsuario:=True, miraPC:=Not Reglas.Publicos.CtaCteProv.PagoIgnorarPCdeCaja, cajasModificables:=True)
         _publicos.CargaComboTiposComprobantes(cmbTiposComprobantesPag, MiraPC:=True, "CTACTEPROV")

         tbcDetalle.SelectedTab = tbpPagos2
         tbcDetalle.SelectedTab = tbpPagos1
         tbcDetalle.SelectedTab = tbpComprobantes

         _titComp = GetColumnasVisiblesGrilla(ugComprobantes)
         _titChPr = GetColumnasVisiblesGrilla(ugChequesPropios)
         _titCh3r = GetColumnasVisiblesGrilla(ugChequesTerceros)

         Refrescar()

      End Sub)
   End Sub
   Protected Overrides Function ProcessCmdKey(ByRef msg As Message, keyData As Keys) As Boolean
      If keyData = Keys.F5 Then
         tsbRefrescar.PerformClick()
      ElseIf keyData = Keys.F4 Then
         tsbAnular.PerformClick()
      ElseIf keyData = Keys.F3 Then
         btnConsultar.PerformClick()
      Else
         Return MyBase.ProcessCmdKey(msg, keyData)
      End If
      Return True
   End Function

#End Region

#Region "Eventos"

#Region "Eventos Toolbar"
   Private Sub tsbRefrescar_Click(sender As Object, e As EventArgs) Handles tsbRefrescar.Click
      TryCatched(Sub() Refrescar())
   End Sub
   Private Sub tsbAnular_Click(sender As Object, e As EventArgs) Handles tsbAnular.Click
      TryCatched(Sub() AnularPago())
   End Sub
   Private Sub tsbSalir_Click(sender As Object, e As EventArgs) Handles tsbSalir.Click
      TryCatched(Sub() Close())
   End Sub
#End Region


   Private Sub btnConsultar_Click(sender As Object, e As EventArgs) Handles btnConsultar.Click
      TryCatched(
      Sub()
         If String.IsNullOrWhiteSpace(txtLetra.Text) Then
            ShowMessage("ATENCION: Debe cargar la Letra del Recibo a Anular")
            txtLetra.Focus()
            Exit Sub
         End If
         If txtEmisor.ValorNumericoPorDefecto(0I) <= 0 Then
            ShowMessage("ATENCION: Debe cargar el Emisor del Recibo a Anular")
            txtEmisor.Focus()
            Exit Sub
         End If
         If txtNroPago.ValorNumericoPorDefecto(0L) <= 0 Then
            ShowMessage("ATENCION: Debe cargar el Numero del Recibo a Anular")
            txtNroPago.Focus()
            Exit Sub
         End If

         Dim rCtaCte = New Reglas.CuentasCorrientesProv

         'Si no lo encuentra, lanza un ERROR indicando que no existe el comprobante en cuenta corriente.
         _pago = rCtaCte.GetUno(actual.Sucursal.Id, cmbTiposComprobantesPag.SelectedValue.ToString(), txtLetra.Text, txtEmisor.ValorNumericoPorDefecto(0I), txtNroPago.ValorNumericoPorDefecto(0L))

         If _pago.ImporteTotal = 0 And _pago.Observacion = "***ANULADO***" Then
            ShowMessage("ATENCION: el Pago ya se encuentra Anulado")
            tsbAnular.Enabled = False
            Exit Sub
         End If

         txtFechaEmision.Text = _pago.Fecha.ToString("dd/MM/yyyy")

         txtEfectivo.Text = _pago.ImportePesos.ToString("#,##0.00")
         txtTarjetas.Text = _pago.ImporteTarjetas.ToString("#,##0.00")
         txtTickets.Text = _pago.ImporteTickets.ToString("#,##0.00")
         txtTransferenciaBancaria.Text = _pago.ImporteTransfBancaria.ToString("#,##0.00")
         txtCuentaBancariaTransfBanc.Text = _pago.CuentaBancariaTransfBanc.NombreCuenta
         txtRetenciones.Text = _pago.ImporteRetenciones.ToString("#,##0.00")
         txtDolares.Text = _pago.ImporteDolares.ToString("#,##0.00")

         CargarDatosProveedor(_pago)
         CargarComprobantes(_pago)
         CargarChequesPropios(_pago)
         CargarChequesTerceros(_pago)

         CalcularPagos()

         For cont = 1 To _pago.ChequesTerceros.Count
            If _pago.ChequesTerceros.Item(cont - 1).NroMovimientoEgreso = 0 Then
               Dim mensaje = "ATENCION: el Pago tiene al menos este cheque re-ingresado, NO puede ANULARLO..."
               mensaje += Chr(13) & Chr(13)
               mensaje += "Banco: " & _pago.ChequesTerceros.Item(cont - 1).Banco.NombreBanco & " / "
               mensaje += "Suc. Bco: " & _pago.ChequesTerceros.Item(cont - 1).IdBancoSucursal.ToString() & " / "
               mensaje += "Loc. Bco: " & _pago.ChequesTerceros.Item(cont - 1).Localidad.NombreLocalidad & " / "
               mensaje += "Numero Cheq.: " & _pago.ChequesTerceros.Item(cont - 1).NumeroCheque.ToString()

               ShowMessage(mensaje)
               tsbAnular.Enabled = False
               Exit Sub
            End If
         Next

         cmbCajas.Text = New Reglas.CajasNombres().GetUna(actual.Sucursal.IdSucursal, _pago.CajaDetalle.IdCaja).NombreCaja

         'Solo deja cambiar la caja si fue completo en Efectivo.
         cmbCajas.Enabled = (_pago.ImportePesos = _pago.ImporteTotal)

         txtLetra.ReadOnly = True
         txtEmisor.ReadOnly = True
         txtNroPago.ReadOnly = True
         btnConsultar.Enabled = False
      End Sub)
   End Sub

   Private Sub tbcDetalle_SelectedIndexChanged(sender As Object, e As EventArgs) Handles tbcDetalle.SelectedIndexChanged
      TryCatched(
      Sub()
         Select Case tbcDetalle.SelectedTab.Name
            Case "tbpComprobantes"
               ugComprobantes.Focus()
            Case "tbpPagos1"
               txtEfectivo.Focus()
            Case "tbpPagos2"
               ugChequesTerceros.Focus()
         End Select
      End Sub)
   End Sub

   Private Sub txtEfectivo_KeyUp(sender As Object, e As KeyEventArgs) Handles txtEfectivo.KeyUp, txtRetenciones.KeyUp, txtEmisor.KeyUp, txtNroPago.KeyUp, txtTarjetas.KeyUp, txtChequesPropios.KeyUp,
                                                                              txtTickets.KeyUp, txtTransferenciaBancaria.KeyUp, txtCuentaBancariaTransfBanc.KeyUp, txtChequesTerceros.KeyUp
      PresionarTab(e)
   End Sub
   Private Sub txtLetra_KeyUp(sender As Object, e As KeyEventArgs) Handles txtLetra.KeyUp
      txtLetra.Text = txtLetra.Text.ToUpper()
      PresionarTab(e)
   End Sub
   Private Sub txtComprobantes_Leave(sender As Object, e As EventArgs) Handles txtComprobantes.Leave
      TryCatched(
       Sub()
          If txtComprobantes.Text.Trim().Length = 0 Then
             txtComprobantes.Text = "0"
          End If
       End Sub)
   End Sub

   Private Sub cmbTiposComprobantesPag_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbTiposComprobantesPag.SelectedIndexChanged
      TryCatched(
       Sub()
          If cmbTiposComprobantesPag.SelectedValue IsNot Nothing Then
             Dim tpCompPag = cmbTiposComprobantesPag.ItemSeleccionado(Of Entidades.TipoComprobante)
             'Si es X/R siempre debe tener esa letra, sino dejo la del Cliente
             If tpCompPag.LetrasHabilitadas = "X" Or tpCompPag.LetrasHabilitadas = "R" Then
                txtLetra.Text = tpCompPag.LetrasHabilitadas
             Else
                If _proveedorGrilla IsNot Nothing Then
                   txtLetra.Text = _proveedorGrilla.CategoriaFiscal.LetraFiscal
                Else
                   txtLetra.Text = ""
                End If
             End If
          End If
       End Sub)
   End Sub

#End Region

#Region "Metodos"

   Private Sub CalcularComprobantes()
      Dim bruto = Math.Round(_ComprobantesGrilla.SumSecure(Function(p) p.Paga).IfNull(), 2)
      txtComprobantes.SetValor(bruto)
      txtDiferencia.SetValor(txtComprobantes.ValorNumericoPorDefecto(0D) - txtTotalPago.ValorNumericoPorDefecto(0D))
      VerificarGrabarImprimir()
   End Sub

   Private Sub VerificarGrabarImprimir()
      tsbAnular.Enabled = txtDiferencia.ValorNumericoPorDefecto(0D) <= 0
   End Sub

   Private Sub CalcularPagos()
      Dim pago = _chequesPropios.SumSecure(Function(ch) ch.Importe).IfNull() +
                 _chequesTerceros.SumSecure(Function(ch) ch.Importe).IfNull()

      Dim dolaresConvertidos = txtDolares.ValorNumericoPorDefecto(0D) * _pago.CotizacionDolar
      Dim transfConvertidos = txtTransferenciaBancaria.ValorNumericoPorDefecto(0D)
      If _pago.CuentaBancariaTransfBanc.Moneda.IdMoneda = Entidades.Moneda.Dolar Then
         transfConvertidos *= _pago.CotizacionDolar
      End If

      pago = Math.Round(pago, 2) + txtEfectivo.ValorNumericoPorDefecto(0D) + txtTarjetas.ValorNumericoPorDefecto(0D) + txtTickets.ValorNumericoPorDefecto(0D) +
             transfConvertidos + txtRetenciones.ValorNumericoPorDefecto(0D) + dolaresConvertidos

      txtTotalPago.SetValor(pago)
      txtDiferencia.SetValor(txtComprobantes.ValorNumericoPorDefecto(0D) - txtTotalPago.ValorNumericoPorDefecto(0D))
      VerificarGrabarImprimir()
   End Sub

   Private Sub CargarDatosProveedor(Pago As Entidades.CuentaCorrienteProv)
      Dim rProveedor = New Reglas.Proveedores()
      _proveedorGrilla = rProveedor._GetUno(Pago.Proveedor.IdProveedor)

      txtCodigoProveedor.Text = _proveedorGrilla.CodigoProveedor.ToString()
      txtNombreProveedor.Text = _proveedorGrilla.NombreProveedor

      txtDireccion.Text = _proveedorGrilla.DireccionProveedor
      txtLocalidad.Text = _proveedorGrilla.NombreLocalidad

      txtCategoriaFiscal.Text = _proveedorGrilla.CategoriaFiscal.NombreCategoriaFiscal
      txtCategoriaFiscal.Tag = _proveedorGrilla.CategoriaFiscal.IdCategoriaFiscal

      tbcDetalle.Enabled = True

      'carga el saldo del Proveedor de la cuenta corriente

      Dim rCtaCte = New Reglas.CuentasCorrientesProv()
      txtSaldoActual.SetValor(rCtaCte.GetSaldoProveedor(actual.Sucursal.Id, _proveedorGrilla))

   End Sub

   Private Sub Refrescar()

      If cmbTiposComprobantesPag.Items.Count > 0 Then
         cmbTiposComprobantesPag.SelectedIndex = -1   'Fuerzo el evento de Changed
         cmbTiposComprobantesPag.SelectedIndex = 0
      Else
         cmbTiposComprobantesPag.SelectedIndex = -1
      End If

      txtLetra.ReadOnly = False
      txtEmisor.ReadOnly = False
      txtNroPago.ReadOnly = False
      btnConsultar.Enabled = True

      txtTotalPago.Enabled = True
      tbcDetalle.SelectedTab = Me.tbpComprobantes
      tbcDetalle.Enabled = True
      txtCodigoProveedor.Text = String.Empty
      txtNombreProveedor.Text = String.Empty
      txtComprobantes.Enabled = True
      txtObservacion.Text = String.Empty

      _publicos.CargaComboCajas(cmbCajas, actual.Sucursal.IdSucursal, miraUsuario:=True, miraPC:=Not Reglas.Publicos.CtaCteProv.PagoIgnorarPCdeCaja, cajasModificables:=True)
      cmbCajas.Enabled = True

      _ComprobantesGrilla.Clear()
      ugComprobantes.ClearFilas()

      txtLocalidad.Text = String.Empty
      txtComprobantes.Text = "0.00"
      txtDireccion.Text = String.Empty
      txtFechaEmision.Text = String.Empty
      'txtLetra.Text = "X"
      txtEmisor.Text = String.Empty
      txtNroPago.Text = String.Empty
      txtTotalPago.Text = "0.00"
      txtCategoriaFiscal.Text = String.Empty
      tsbAnular.Enabled = False
      txtEfectivo.Text = "0.00"
      txtTarjetas.Text = "0.00"
      txtTickets.Text = "0.00"
      txtTransferenciaBancaria.Text = "0.00"
      txtCuentaBancariaTransfBanc.Text = String.Empty
      txtRetenciones.Text = "0.00"

      txtSaldoActual.Text = "0.00"
      txtDiferencia.Text = "0.00"

      _chequesPropios.Clear()
      ugChequesPropios.ClearFilas()

      _chequesTerceros.Clear()
      ugChequesTerceros.ClearFilas()

      tbcDetalle.SelectedTab = tbpComprobantes

      _proveedorGrilla = Nothing

      txtLetra.Focus()

   End Sub

   Private Sub CargarComprobantes(Pago As Entidades.CuentaCorrienteProv)
      _ComprobantesGrilla.Clear()

      For Each CCP In Pago.Pagos

         Dim o = New Entidades.CuentaCorrienteProvPago()
         With o
            .TipoComprobante = CCP.TipoComprobante
            .Letra = CCP.Letra
            .CentroEmisor = CCP.CentroEmisor
            .NumeroComprobante = CCP.NumeroComprobante
            .Cuota = CCP.Cuota
            .Fecha = CCP.Fecha
            .FechaVencimiento = CCP.FechaVencimiento
            .ImporteCuota = CCP.ImporteCuota
            .SaldoCuota = CCP.SaldoCuota
            .Paga = CCP.Paga
            .IdSucursal = CCP.IdSucursal
            .Usuario = actual.Nombre
         End With

         _ComprobantesGrilla.Add(o)

      Next

      ugComprobantes.DataSource = _ComprobantesGrilla
      ugComprobantes.Rows.Refresh(RefreshRow.ReloadData)
      AjustarColumnasGrilla(ugComprobantes, _titComp)

      CalcularComprobantes()

   End Sub

   Private Sub CargarChequesPropios(Pago As Entidades.CuentaCorrienteProv)
      _chequesPropios.Clear()
      Dim TotalCheques As Decimal = 0
      For Each Cheq In Pago.ChequesPropios

         Dim o = New Entidades.Cheque()
         With o
            .IdSucursal = actual.Sucursal.Id
            .Banco = Cheq.Banco
            .IdBancoSucursal = Cheq.IdBancoSucursal
            .Localidad.IdLocalidad = Cheq.Localidad.IdLocalidad
            .NumeroCheque = Cheq.NumeroCheque
            .FechaEmision = Cheq.FechaEmision
            .FechaCobro = Cheq.FechaCobro
            .Titular = Cheq.Titular
            .Importe = Cheq.Importe
            .NroPlanillaIngreso = Cheq.NroPlanillaIngreso
            .NroMovimientoIngreso = Cheq.NroMovimientoIngreso
            .NroPlanillaEgreso = Cheq.NroPlanillaEgreso
            .NroMovimientoEgreso = Cheq.NroMovimientoEgreso
            .EsPropio = True
            .CuentaBancaria = Cheq.CuentaBancaria
            .Usuario = actual.Nombre
         End With

         TotalCheques = TotalCheques + o.Importe

         _chequesPropios.Add(o)
      Next

      If _chequesPropios.Count > 0 Then
         ugChequesPropios.DataSource = _chequesPropios
         ugChequesPropios.Rows.Refresh(RefreshRow.ReloadData)
         AjustarColumnasGrilla(ugChequesPropios, _titChPr)
      End If

      txtChequesPropios.SetValor(TotalCheques)

   End Sub

   Private Sub CargarChequesTerceros(Pago As Entidades.CuentaCorrienteProv)
      _chequesTerceros.Clear()
      Dim TotalCheques As Decimal = 0
      For Each Cheq In Pago.ChequesTerceros

         Dim o = New Entidades.Cheque()
         With o
            .IdSucursal = actual.Sucursal.Id
            .Banco = Cheq.Banco
            .IdBancoSucursal = Cheq.IdBancoSucursal
            .Localidad.IdLocalidad = Cheq.Localidad.IdLocalidad
            .NumeroCheque = Cheq.NumeroCheque
            .FechaEmision = Cheq.FechaEmision
            .FechaCobro = Cheq.FechaCobro
            .Titular = Cheq.Titular
            .Importe = Cheq.Importe
            .NroPlanillaIngreso = Cheq.NroPlanillaIngreso
            .NroMovimientoIngreso = Cheq.NroMovimientoIngreso
            .NroPlanillaEgreso = Cheq.NroPlanillaEgreso
            .NroMovimientoEgreso = Cheq.NroMovimientoEgreso
            .Usuario = actual.Nombre
         End With
         TotalCheques = TotalCheques + o.Importe

         _chequesTerceros.Add(o)
      Next

      If _chequesTerceros.Count > 0 Then
         ugChequesTerceros.DataSource = _chequesTerceros
         ugChequesTerceros.Rows.Refresh(RefreshRow.ReloadData)
         AjustarColumnasGrilla(ugChequesTerceros, _titCh3r)
      End If

      txtChequesTerceros.SetValor(TotalCheques)

   End Sub

   Private Sub AnularPago()
      If ValidarOperacion() Then
         If cmbCajas.Enabled = True Then
            If _pago.CajaDetalle.IdCaja <> cmbCajas.ValorSeleccionado(Of Integer) Then
               If ShowPregunta(String.Format("ATENCION: El Pago {0} tiene una Caja distinta, esta seguro de aplicarlo a otra caja?!!", _pago.NumeroComprobante)) = Windows.Forms.DialogResult.No Then
                  Exit Sub
               End If
               _pago.CajaDetalle.IdCaja = cmbCajas.ValorSeleccionado(Of Integer)
            End If
         End If
         For Each ch In _pago.ChequesPropios
            If _pago.CajaDetalle.IdCaja <> ch.IdCajaEgreso Then
               ShowMessage(String.Format("ATENCION: El Cheque {0}- Nro: {1} no se encuentra en la caja del recibo a anular, debe moverlo a la caja original.", ch.NombreBanco, ch.NumeroCheque))
               Exit Sub
            End If
         Next
         For Each ch In _pago.ChequesTerceros
            If _pago.CajaDetalle.IdCaja <> ch.IdCajaEgreso Then
               ShowMessage(String.Format("ATENCION: El Cheque {0}- Nro: {1} no se encuentra en la caja del recibo a anular, debe moverlo a la caja original.", ch.NombreBanco, ch.NumeroCheque))
               Exit Sub
            End If
         Next

         Dim rCtaCteProv = New Reglas.CuentasCorrientesProv()
         rCtaCteProv.AnularPago(_pago)

         ShowMessage(String.Format("Se Anulo el Pago número {0}", _pago.NumeroComprobante))

         Refrescar()
      End If
   End Sub

   Private Function ValidarOperacion() As Boolean
      'Generó un ANTICIPO
      If txtDiferencia.ValorNumericoPorDefecto(0D) <> 0 Then
         Dim oTipoComprobante = New Reglas.TiposComprobantes().GetUno(cmbTiposComprobantesPag.SelectedValue.ToString())

         Dim rCtaCte = New Reglas.CuentasCorrientesProv
         Dim antic = rCtaCte.GetUna(actual.Sucursal.Id, _proveedorGrilla.IdProveedor, oTipoComprobante.IdTipoComprobanteSecundario, txtLetra.Text, txtEmisor.ValorNumericoPorDefecto(0I), txtNroPago.ValorNumericoPorDefecto(0L))

         'El Saldo viene con el saldo cambiado, pero por las dudas le saco el signo a ambos.
         If Math.Abs(Antic.ImporteTotal) <> Math.Abs(Antic.Saldo) Then
            ShowMessage("El Pago actual generó un ANTICIPO y se encuentra aplicado, debe anular primero el Pago que lo afectó")
            Return False
         End If
      End If
      Return True
   End Function
#End Region
End Class