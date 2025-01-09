Public Class ModificarPagosProveedores
   Implements IConParametros
#Region "Campos"
   Private _publicos As Eniac.Win.Publicos
   Private _modalidadPantalla As Entidades.ModalidadPantalla = Entidades.ModalidadPantalla.Modificar
   Private _recibo As Eniac.Entidades.CuentaCorrienteProv

   Private _proveedorGrilla As Entidades.Proveedor

   Private _tipoTipoComprobante As String
   Private _esCopia As Boolean
   Private _ComprobantesGrilla As New System.Collections.Generic.List(Of Entidades.CuentaCorrienteProvPago)
   Private _tit As Dictionary(Of String, String) = New Dictionary(Of String, String)()
   Private _cheques As List(Of Entidades.Cheque)
   Private _chequesPropios As List(Of Entidades.Cheque)
   Private _chequesTerceros As List(Of Entidades.Cheque)
   Private _retenciones As List(Of Entidades.Retencion)
#End Region

#Region "Overrides/Overloads"

   Protected Overrides Sub OnLoad(e As EventArgs)
      MyBase.OnLoad(e)

      Try

         _tit = New Dictionary(Of String, String)()
         For Each col As DataGridViewColumn In dgvComprobantes.Columns
            If col.Visible Then
               _tit.Add(col.Name, String.Empty)
            End If
         Next

         Me._cheques = New List(Of Entidades.Cheque)
         Me._chequesPropios = New List(Of Entidades.Cheque)
         Me._chequesTerceros = New List(Of Entidades.Cheque)
         Me._retenciones = New List(Of Entidades.Retencion)

         Me._publicos = New Eniac.Win.Publicos()

         Me._publicos.CargaComboCajas(Me.cmbCajas, actual.Sucursal.IdSucursal, MiraUsuario:=True, MiraPC:=Not Reglas.Publicos.CtaCte.ReciboIgnorarPCdeCaja, CajasModificables:=True)

         Me._publicos.CargaComboTiposComprobantes(Me.cmbTiposComprobantesPag, True, "CTACTECLIE")

         Me.Refrescar()

         If _recibo IsNot Nothing Then

            Me._publicos.CargaComboTiposComprobantes(Me.cmbTiposComprobantesPag, True, "CTACTEPROV", , , , , , , , , , _recibo.TipoComprobante.GrabaLibro)

            cmbTiposComprobantesPag.SelectedValue = _recibo.TipoComprobante.IdTipoComprobante
            txtLetra.Text = _recibo.Letra
            txtEmisor.Text = _recibo.CentroEmisor.ToString()
            txtNroPago.Text = _recibo.NumeroComprobante.ToString()
            MostrarRecibo()


            '-- REQ-31744.- -----------------------------------------
            bscCuentaBancariaTransfBanc.Enabled = _recibo.CuentaBancariaTransfBanc IsNot Nothing AndAlso Not String.IsNullOrWhiteSpace(_recibo.CuentaBancariaTransfBanc.NombreCuenta)
            bscCuentaBancariaTransfBanc.Text = _recibo.CuentaBancariaTransfBanc.NombreCuenta
            txtTransferenciaBancaria.Text = _recibo.ImporteTransfBancaria.ToString("#,##0.00")
            '--------------------------------------------------------
            txtEfectivo.Text = _recibo.ImportePesos.ToString("#,##0.00")
            txtTarjetas.Text = _recibo.ImporteTarjetas.ToString("#,##0.00")
            txtTickets.Text = _recibo.ImporteTickets.ToString("#,##0.00")
            txtRetenciones.Text = _recibo.ImporteRetenciones.ToString("#,##0.00")
            '--------------------------------------------------------

            'cmbTiposComprobantesPag.Enabled = False
            'txtLetra.ReadOnly = True
            'txtEmisor.ReadOnly = True
            'txtObservacion.ReadOnly = False

            Text = "Modificar Recibo de Pago a Proveedor"
         End If
      Catch ex As Exception

      End Try

   End Sub

   Protected Overrides Sub OnShown(e As EventArgs)
      MyBase.OnShown(e)
      If cmbTiposComprobantesPag.Items.Count = 0 Then
         MessageBox.Show("No Existe la PC en Configuraciones/Impresoras", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End If
   End Sub

   Public Overloads Function ShowDialog(owner As Form, recibo As Entidades.CuentaCorrienteProv, modalidadPantalla As Entidades.ModalidadPantalla) As DialogResult
      ShowInTaskbar = False
      _recibo = recibo
      _modalidadPantalla = modalidadPantalla
      Return ShowDialog(owner)
   End Function

#End Region

#Region "Eventos"


   Private Sub tsbGrabar_Click(sender As Object, e As EventArgs) Handles tsbGrabar.Click
      Try

         If _recibo.CentroEmisor <> Short.Parse(txtEmisor.Text) Or _recibo.NumeroComprobante <> Long.Parse(txtNroPago.Text) Then
            If ShowPregunta(String.Format("¿Está seguro de cambiar el Emisor y/o Número del {1}?{0}{0}Esto acción va a recrear el comprobante.",
                                          Environment.NewLine, cmbTiposComprobantesPag.Text)) = Windows.Forms.DialogResult.No Then
               txtNroPago.Focus()
               Exit Sub
            End If
         End If

         GrabarComprobante()

         DialogResult = Windows.Forms.DialogResult.OK
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub tsbRefrescar_Click(sender As Object, e As EventArgs) Handles tsbRefrescar.Click
      Try
         Refrescar()
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub tsbSalir_Click(sender As Object, e As EventArgs) Handles tsbSalir.Click
      Me.Close()
   End Sub

#End Region

#Region "Eventos Buscadores"
   Private Sub bscCuentaBancariaTransfBanc_BuscadorClick() Handles bscCuentaBancariaTransfBanc.BuscadorClick

      Try
         Me._publicos.PreparaGrillaCuentasBancarias(Me.bscCuentaBancariaTransfBanc)
         Dim oCBancarias As Reglas.CuentasBancarias = New Reglas.CuentasBancarias()
         Me.bscCuentaBancariaTransfBanc.Datos = oCBancarias.GetFiltradoPorNombre(Me.bscCuentaBancariaTransfBanc.Text.Trim())
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try

   End Sub

   Private Sub bscCuentaBancariaTransfBanc_BuscadorSeleccion(ByVal sender As System.Object, ByVal e As Eniac.Controles.BuscadorEventArgs) Handles bscCuentaBancariaTransfBanc.BuscadorSeleccion

      Try
         If Not e.FilaDevuelta Is Nothing Then
            'Me.CargarDatosCuentasBancarias(e.FilaDevuelta)
            Me.bscCuentaBancariaTransfBanc.Text = e.FilaDevuelta.Cells("NombreCuenta").Value.ToString()
            bscCuentaBancariaTransfBanc.Tag = e.FilaDevuelta.Cells("IdCuentaBancaria").Value
            Me.bscCuentaBancariaTransfBanc.Focus()
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try

   End Sub
#End Region

#Region "Metodos"
   Private Sub GrabarComprobante()
      '-- REQ-31744.- --------------------------------------
      With Me._recibo
         .Observacion = txtObservacion.Text
         If IsNumeric(bscCuentaBancariaTransfBanc.Tag) Then
            .CuentaBancariaTransfBanc = New Reglas.CuentasBancarias().GetUna(Integer.Parse(Me.bscCuentaBancariaTransfBanc.Tag.ToString()))
         End If
         _recibo.Fecha = dtpFechaEmision.Value

         With DirectCast(_recibo, Entidades.IComprobanteModificable)
            If _recibo.TipoComprobante.IdTipoComprobante <> cmbTiposComprobantesPag.SelectedValue.ToString() Or
               _recibo.Letra <> txtLetra.Text Or
               _recibo.CentroEmisor <> Short.Parse(txtEmisor.Text) Or _recibo.NumeroComprobante <> Long.Parse(txtNroPago.Text) Then
               .IdSucursalNuevo = _recibo.IdSucursal
               .IdTipoComprobanteNuevo = cmbTiposComprobantesPag.SelectedValue.ToString()
               .LetraNuevo = txtLetra.Text
               .CentroEmisorNuevo = Short.Parse(txtEmisor.Text)
               .NumeroComprobanteNuevo = Long.Parse(txtNroPago.Text)
            Else
               .LimpiaModificable()
            End If
         End With
      End With
      '-----------------------------------------------------

      Dim oReglasCtaCteProv As Reglas.CuentasCorrientesProv = New Reglas.CuentasCorrientesProv()

      '-- REQ-31744.- --------------------------------------
      oReglasCtaCteProv.ModificaRecibo(_recibo)
      '-----------------------------------------------------

      MessageBox.Show("Se Modificó el Pago número " & _recibo.NumeroComprobante, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      tsbSalir.PerformClick()

      Me.Refrescar()
   End Sub


   Public Sub SetParametros(parametros As String) Implements IConParametros.SetParametros
      _tipoTipoComprobante = parametros
   End Sub
   Public Function GetParametrosDisponibles() As String Implements IConParametros.GetParametrosDisponibles
      Return "Pendiente documentar"
   End Function

   Private Sub MostrarRecibo()

      txtCategoriaFiscal.Text = _recibo.Proveedor.CategoriaFiscal.NombreCategoriaFiscal
      txtDireccion.Text = _recibo.Proveedor.DireccionProveedor
      txtLocalidad.Text = _recibo.Proveedor.NombreLocalidad

      txtCodigoProveedor.Text = _recibo.Proveedor.CodigoProveedor.ToString()
      txtNombreProveedor.Text = _recibo.Proveedor.NombreProveedor

      dtpFechaEmision.Value = _recibo.Fecha
      'recibo
      txtObservacion.Text = _recibo.Observacion

      cmbCajas.Text = New Reglas.CajasNombres().GetUna(actual.Sucursal.IdSucursal, Me._recibo.CajaDetalle.IdCaja).NombreCaja
      CargaComprobantes(_recibo)
      CargaPagosEfvoYChequesPropios(_recibo)
      CargaPagosChequesTerceros(_recibo)
      CalcularComprobantes()
      CalcularPagos()

      cmbCajas.Enabled = False
      'txtLetra.ReadOnly = True
      'txtEmisor.ReadOnly = True
      'txtNroPago.ReadOnly = True
   End Sub

   Private Sub CargaComprobantes(ByVal Recibo As Entidades.CuentaCorrienteProv)
      _ComprobantesGrilla.Clear()

      For Each CCPP As Entidades.CuentaCorrienteProvPago In Recibo.Pagos

         Dim o = New Entidades.CuentaCorrienteProvPago()

         With o
            .TipoComprobante = CCPP.TipoComprobante
            .Letra = CCPP.Letra
            .CentroEmisor = CCPP.CentroEmisor
            .NumeroComprobante = CCPP.NumeroComprobante
            .Cuota = CCPP.Cuota
            .Fecha = CCPP.Fecha
            .FechaVencimiento = CCPP.FechaVencimiento
            .ImporteCuota = CCPP.ImporteCuota
            .SaldoCuota = CCPP.SaldoCuota
            .Paga = CCPP.Paga
            .DescuentoRecargo = CCPP.DescuentoRecargo
            .DescuentoRecargoPorc = CCPP.DescuentoRecargoPorc
            .MercEnviada = CCPP.MercEnviada
         End With

         _ComprobantesGrilla.Add(o)
      Next

      dgvComprobantes.DataSource = _ComprobantesGrilla.ToArray()

      If Me.dgvComprobantes.Rows.Count > 0 Then
         Me.dgvComprobantes.FirstDisplayedScrollingRowIndex = Me.dgvComprobantes.Rows.Count - 1
      End If

      Me.dgvComprobantes.Refresh()
      'Me.CalcularComprobantes()

   End Sub

   Private Sub CargaPagosEfvoYChequesPropios(ByVal Recibo As Entidades.CuentaCorrienteProv)

      '-- Efectivo.- --
      '-- Transferencias.- --
      '-- Cheques Propios.- --
      CargaPagosChequesPropios(Recibo)
   End Sub

   Private Sub CargaPagosTransferenciaBancaria(ByVal Recibo As Entidades.CuentaCorrienteProv)


   End Sub
   Private Sub CargaPagosChequesPropios(ByVal Recibo As Entidades.CuentaCorrienteProv)
      Me._chequesPropios.Clear()

      Dim o As Entidades.Cheque
      Dim TotalCheques As Decimal = 0

      For Each Cheq As Entidades.Cheque In Recibo.ChequesPropios

         o = New Entidades.Cheque()

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

         Me._chequesPropios.Add(o)
      Next

      If Recibo.ChequesPropios.Count > 0 Then
         'Cheques propios
         Me.dgvChequesPropios.DataSource = _chequesPropios.ToArray()
         Me.dgvChequesPropios.FirstDisplayedScrollingRowIndex = Me.dgvChequesPropios.Rows.Count - 1
         Me.dgvChequesPropios.Refresh()
      End If

      Me.txtChequesPropios.Text = TotalCheques.ToString("#,##0.00")
   End Sub
   Private Sub CargaPagosChequesTerceros(ByVal Recibo As Entidades.CuentaCorrienteProv)

      Me._chequesTerceros.Clear()

      Dim o As Entidades.Cheque
      Dim TotalCheques As Decimal = 0

      For Each Cheq As Entidades.Cheque In Recibo.ChequesTerceros

         o = New Entidades.Cheque()

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

         Me._chequesTerceros.Add(o)

      Next

      If Recibo.ChequesTerceros.Count > 0 Then
         'Cheques 3ros
         Me.dgvChequesTerceros.DataSource = _chequesTerceros.ToArray()
         Me.dgvChequesTerceros.FirstDisplayedScrollingRowIndex = Me.dgvChequesTerceros.Rows.Count - 1
         Me.dgvChequesTerceros.Refresh()
      End If

      Me.txtChequesTerceros.Text = TotalCheques.ToString("#,##0.00")
   End Sub

   Private Sub CalcularComprobantes()
      Dim bruto As Decimal = 0

      For i As Integer = 0 To Me._ComprobantesGrilla.Count - 1
         bruto += Me._ComprobantesGrilla(i).Paga
      Next

      bruto = Math.Round(bruto, 2)

      Me.txtComprobantes.Text = bruto.ToString("#,##0.00")
      Me.txtDiferencia.Text = (Decimal.Parse(Me.txtComprobantes.Text) - Decimal.Parse(Me.txtTotalPago.Text)).ToString("#,##0.00")
      Me.VerificarGrabarImprimir()
   End Sub
   Private Sub CalcularPagos()
      Dim pago As Decimal = 0

      For i As Integer = 0 To Me._chequesPropios.Count - 1
         pago += Me._chequesPropios(i).Importe
      Next

      For i As Integer = 0 To Me._chequesTerceros.Count - 1
         pago += Me._chequesTerceros(i).Importe
      Next


      Dim dolaresConvertidos As Decimal = If(IsNumeric(txtDolares.Text), Decimal.Parse(txtDolares.Text), 0) * If(IsNumeric(_recibo.CotizacionDolar), _recibo.CotizacionDolar, 0)


      pago = Math.Round(pago, 2) + Decimal.Parse(Me.txtEfectivo.Text) + Decimal.Parse(Me.txtTarjetas.Text) + Decimal.Parse(Me.txtTickets.Text) +
               Decimal.Parse(Me.txtTransferenciaBancaria.Text) + Decimal.Parse(Me.txtRetenciones.Text) + dolaresConvertidos

      Me.txtTotalPago.Text = pago.ToString("#,##0.00")
      Me.txtDiferencia.Text = (Decimal.Parse(Me.txtComprobantes.Text) - Decimal.Parse(Me.txtTotalPago.Text)).ToString("#,##0.00")
      Me.VerificarGrabarImprimir()
   End Sub

   Private Sub VerificarGrabarImprimir()
      'Me.tsbGrabar.Enabled = (Decimal.Parse(Me.txtDiferencia.Text) <= 0)
   End Sub

   Private Sub Refrescar()
      Me.txtObservacion.Text = String.Empty
   End Sub

   Private Sub cmbTiposComprobantesPag_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbTiposComprobantesPag.SelectedIndexChanged
      Try
         If Me.cmbTiposComprobantesPag.SelectedValue IsNot Nothing Then

            'Si es X/R siempre debe tener esa letra, sino dejo la del Cliente
            If DirectCast(Me.cmbTiposComprobantesPag.SelectedItem, Entidades.TipoComprobante).LetrasHabilitadas = "X" Or
               DirectCast(Me.cmbTiposComprobantesPag.SelectedItem, Entidades.TipoComprobante).LetrasHabilitadas = "R" Then
               Me.txtLetra.Text = DirectCast(Me.cmbTiposComprobantesPag.SelectedItem, Entidades.TipoComprobante).LetrasHabilitadas
            Else
               'If Me._clienteGrilla IsNot Nothing Then
               '   Me.txtLetra.Text = Me._clienteGrilla.CategoriaFiscal.LetraFiscal
               'Else
               Me.txtLetra.Text = ""
               'End If
            End If

         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub txtNroPago_TextChanged(sender As Object, e As EventArgs) Handles txtNroPago.TextChanged

   End Sub

   'Private Sub btnConsultar_Click(sender As Object, e As EventArgs) Handles btnConsultar.Click

   'End Sub

#End Region

End Class
