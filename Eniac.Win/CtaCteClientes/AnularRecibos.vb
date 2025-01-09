''' <summary>
''' ####  SE USA PARA MODIFICAR RECIBOS ####
''' </summary>
Public Class AnularRecibos

#Region "Campos"

   Private _ComprobantesGrilla As New List(Of Entidades.CuentaCorrientePago)()
   Private _cheques As List(Of Entidades.Cheque)
   Private _clienteGrilla As Entidades.Cliente
   Private _recibo As Entidades.CuentaCorriente
   Private _retenciones As List(Of Entidades.Retencion)
   Private _publicos As Publicos
   Private _tit As Dictionary(Of String, String) = New Dictionary(Of String, String)()
   Private _modalidadPantalla As Entidades.ModalidadPantalla = Entidades.ModalidadPantalla.Anular

#End Region

#Region "Overrides/Overloads"

   Protected Overrides Sub OnLoad(e As EventArgs)
      MyBase.OnLoad(e)
      TryCatched(
         Sub()
            _tit = GetColumnasVisiblesGrilla(dgvComprobantes)

            _cheques = New List(Of Entidades.Cheque)
            _retenciones = New List(Of Entidades.Retencion)

            _publicos = New Publicos()

            _publicos.CargaComboCajas(cmbCajas, actual.Sucursal.IdSucursal, miraUsuario:=True, miraPC:=Not Reglas.Publicos.CtaCte.ReciboIgnorarPCdeCaja, cajasModificables:=True)

            _publicos.CargaComboTiposComprobantes(cmbTiposComprobantesRec, True, "CTACTECLIE")

            '-.PE-31462.-
            _publicos.CargaComboEmpleados(cmbVendedor, Entidades.Publicos.TiposEmpleados.VENDEDOR)

            Refrescar()

            tsbAnular.Visible = _modalidadPantalla = Entidades.ModalidadPantalla.Anular
            tsbGrabar.Visible = _modalidadPantalla = Entidades.ModalidadPantalla.Modificar
            '-.PE-31462.- Se muestra ComboBox en el caso de ModalidadPantalla.Modificar, y en el caso de Anular se muestra el txtBox
            If _modalidadPantalla = Entidades.ModalidadPantalla.Modificar Then
               txtNombreVendedor.ReadOnly = False
               txtNombreVendedor.Visible = False
               cmbVendedor.Visible = True
            End If

            tsbRefrescar.Visible = _recibo Is Nothing

            If _recibo IsNot Nothing Then

               _publicos.CargaComboTiposComprobantes(cmbTiposComprobantesRec, True, "CTACTECLIE", , , , , , , , , , _recibo.TipoComprobante.GrabaLibro)

               cmbTiposComprobantesRec.SelectedValue = _recibo.TipoComprobante.IdTipoComprobante
               txtLetra.Text = _recibo.Letra
               txtEmisor.Text = _recibo.CentroEmisor.ToString()
               txtNroRecibo.Text = _recibo.NumeroComprobante.ToString()
               MostrarRecibo()

               txtObservacion.ReadOnly = False
               bscCuentaBancariaTransfBanc.Enabled = _recibo.CuentaBancariaTransfBanc IsNot Nothing AndAlso Not String.IsNullOrWhiteSpace(_recibo.CuentaBancariaTransfBanc.NombreCuenta)
               dtpFechaTransferencia.Enabled = bscCuentaBancariaTransfBanc.Enabled
               cmbTiposComprobantesRec.Enabled = True
               txtLetra.ReadOnly = False
               txtEmisor.ReadOnly = False
               txtNroRecibo.ReadOnly = False

               ToolTip1.SetToolTip(bscNroOrdenDeCompra, Nothing)
               If _recibo.Pagos.Any() Then
                  chbNroOrdenDeCompra.Enabled = False
                  bscNroOrdenDeCompra.Permitido = False
               Else
                  Try
                     Dim rCtaCte = New Reglas.CuentasCorrientes()
                     rCtaCte.ComprobanteConPagoAPlicado(_recibo)
                  Catch ex As Exception
                     chbNroOrdenDeCompra.Enabled = False
                     bscNroOrdenDeCompra.Permitido = False
                     ToolTip1.SetToolTip(bscNroOrdenDeCompra, ex.Message)
                  End Try
               End If

               Text = "Modificar Recibo"

            End If
         End Sub)
   End Sub

   Protected Overrides Sub OnShown(e As EventArgs)
      MyBase.OnShown(e)
      TryCatched(
         Sub()
            If cmbTiposComprobantesRec.Items.Count = 0 Then
               ShowMessage("No Existe la PC en Configuraciones/Impresoras")
            End If
         End Sub)
   End Sub

   Public Overloads Function ShowDialog(owner As Form, recibo As Entidades.CuentaCorriente, modalidadPantalla As Entidades.ModalidadPantalla) As DialogResult
      ShowInTaskbar = False
      _recibo = recibo
      _modalidadPantalla = modalidadPantalla
      Return ShowDialog(owner)
   End Function

   Protected Overrides Function ProcessCmdKey(ByRef msg As Message, keyData As Keys) As Boolean
      If keyData = Keys.F5 Then
         tsbRefrescar.PerformClick()
      ElseIf keyData = Keys.F4 And tsbAnular.Enabled And tsbAnular.Visible Then
         tsbAnular.PerformClick()
      ElseIf keyData = Keys.F4 And tsbGrabar.Enabled And tsbGrabar.Visible Then
         tsbGrabar.PerformClick()
      ElseIf keyData = Keys.Escape And _modalidadPantalla = Entidades.ModalidadPantalla.Anular Then
         DialogResult = DialogResult.Cancel
         Close()
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
      TryCatched(Sub() AnularRecibo())
   End Sub

   Private Sub tsbGrabar_Click(sender As Object, e As EventArgs) Handles tsbGrabar.Click
      TryCatched(
         Sub()
            Dim sistema As Entidades.Sistema = Publicos.GetSistema()

            'If DateDiff(DateInterval.Day, Me.dtpDesde.Value, sistema.FechaVencimiento) < 0 Then
            '   MessageBox.Show("La fecha es mayor a la validez del sistema, el " & sistema.FechaVencimiento.ToString("dd/MM/yyyy") & ".", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            '   Me.dtpDesde.Focus()
            '   Exit Sub
            'End If

            If chbNroOrdenDeCompra.Checked AndAlso Not bscNroOrdenDeCompra.Selecciono Then
               ShowMessage("Debe seleccionar la Orden de Compra")
               bscNroOrdenDeCompra.Focus()
               Exit Sub
            End If

            If _recibo.CentroEmisor <> Short.Parse(txtEmisor.Text) Or _recibo.NumeroComprobante <> Long.Parse(txtNroRecibo.Text) Then
               If ShowPregunta(String.Format("¿Está seguro de cambiar el Emisor y/o Número del {1}?{0}{0}Esto acción va a recrear el comprobante.",
                                             Environment.NewLine, cmbTiposComprobantesRec.Text)) = Windows.Forms.DialogResult.No Then
                  txtNroRecibo.Focus()
                  Exit Sub
               End If
            End If

            If String.IsNullOrWhiteSpace(txtLetra.Text) Then
               ShowMessage("Debe cargar una Letra")
               txtLetra.Focus()
               Exit Sub
            End If
            If txtLetra.Text = "Ñ" Or txtLetra.Text = "ñ" Then
               ShowMessage("Letra no puede ser Ñ")
               txtLetra.Focus()
               Exit Sub
            End If
            If Not RegularExpressions.Regex.IsMatch(txtLetra.Text, "[A-Z][a-z]*") Then
               ShowMessage("La Letra debe ser una letra entre A y Z")
               txtLetra.Focus()
               Exit Sub
            End If
            GrabarDatos()
            DialogResult = DialogResult.OK
         End Sub)
   End Sub

   Private Sub tsbSalir_Click(sender As Object, e As EventArgs) Handles tsbSalir.Click
      TryCatched(
         Sub()
            DialogResult = DialogResult.Cancel
            Close()
         End Sub)
   End Sub
#End Region

   Private Sub btnConsultar_Click(sender As Object, e As EventArgs) Handles btnConsultar.Click
      TryCatched(
         Sub()

            If Me.txtLetra.Text.Trim() = "" Then
               MessageBox.Show("ATENCION: Debe cargar la Letra del Recibo a Anular", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
               Me.txtLetra.Focus()
               Exit Sub
            End If

            If Integer.Parse("0" & Me.txtEmisor.Text) <= 0 Then
               MessageBox.Show("ATENCION: Debe cargar el Emisor del Recibo a Anular", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
               Me.txtEmisor.Focus()
               Exit Sub
            End If

            If Long.Parse("0" & Me.txtNroRecibo.Text) <= 0 Then
               MessageBox.Show("ATENCION: Debe cargar el Numero del Recibo a Anular", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
               Exit Sub
            End If

            Dim oCtaCte As New Reglas.CuentasCorrientes

            'Si no lo encuentra, lanza un ERROR indicando que no existe el comprobante en cuenta corriente.
            _recibo = oCtaCte.GetUna(actual.Sucursal.Id, Me.cmbTiposComprobantesRec.SelectedValue.ToString(), Me.txtLetra.Text, Integer.Parse(Me.txtEmisor.Text), Long.Parse(Me.txtNroRecibo.Text))
            _recibo.Usuario = Entidades.Usuario.Actual.Nombre

            MostrarRecibo()

         End Sub)
   End Sub

#Region "Eventos KeyUp"

   Private Sub txtEfectivo_KeyUp(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles txtEfectivo.KeyUp
      Me.PresionarTab(e)
   End Sub

   Private Sub txtLetra_KeyUp(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles txtLetra.KeyUp
      Me.txtLetra.Text = Me.txtLetra.Text.ToUpper()
      Me.PresionarTab(e)
   End Sub

   Private Sub txtEmisor_KeyUp(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles txtEmisor.KeyUp
      Me.PresionarTab(e)
   End Sub

   Private Sub txtNroRecibo_KeyUp(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles txtNroRecibo.KeyUp
      Me.PresionarTab(e)
   End Sub

   Private Sub txtTarjetas_KeyUp(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles txtTarjetas.KeyUp
      Me.PresionarTab(e)
   End Sub

   Private Sub txtCheques_KeyUp(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles txtCheques.KeyUp
      Me.PresionarTab(e)
   End Sub

   Private Sub txtTransferenciaBancaria_KeyUp(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles txtTransferenciaBancaria.KeyUp
      Me.PresionarTab(e)
   End Sub

   Private Sub txtCuentaBancariaTransfBanc_KeyUp(sender As Object, e As System.Windows.Forms.KeyEventArgs)
      Me.PresionarTab(e)
   End Sub

   Private Sub txtRetenciones_KeyUp(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles txtRetenciones.KeyUp
      Me.PresionarTab(e)
   End Sub

#End Region

   Private Sub tbcDetalle_SelectedIndexChanged(sender As Object, e As EventArgs) Handles tbcDetalle.SelectedIndexChanged
      Try
         Select Case Me.tbcDetalle.SelectedTab.Name
            Case "tbpComprobantes"
               Me.dgvComprobantes.Focus()
            Case "tbpPagos"
               Me.txtEfectivo.Focus()
         End Select
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub cmbTiposComprobantesRec_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbTiposComprobantesRec.SelectedIndexChanged
      Try
         If Me.cmbTiposComprobantesRec.SelectedValue IsNot Nothing Then

            'Si es X/R siempre debe tener esa letra, sino dejo la del Cliente
            If DirectCast(Me.cmbTiposComprobantesRec.SelectedItem, Entidades.TipoComprobante).LetrasHabilitadas = "X" Or
               DirectCast(Me.cmbTiposComprobantesRec.SelectedItem, Entidades.TipoComprobante).LetrasHabilitadas = "R" Then
               Me.txtLetra.Text = DirectCast(Me.cmbTiposComprobantesRec.SelectedItem, Entidades.TipoComprobante).LetrasHabilitadas
            Else
               If Me._clienteGrilla IsNot Nothing Then
                  Me.txtLetra.Text = Me._clienteGrilla.CategoriaFiscal.LetraFiscal
               Else
                  Me.txtLetra.Text = ""
               End If
            End If

         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub txtComprobantes_LostFocus(sender As Object, e As EventArgs) Handles txtComprobantes.LostFocus
      If Not IsNumeric(Me.txtComprobantes.Text) Then
         Me.txtComprobantes.Text = "0"
      End If
   End Sub

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

   Private Sub bscCuentaBancariaTransfBanc_BuscadorSeleccion(sender As Object, e As Eniac.Controles.BuscadorEventArgs) Handles bscCuentaBancariaTransfBanc.BuscadorSeleccion

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

   Private Sub chbNroOrdenDeCompra_CheckedChanged(sender As Object, e As EventArgs) Handles chbNroOrdenDeCompra.CheckedChanged
      TryCatched(Sub() chbNroOrdenDeCompra.FiltroCheckedChanged(usaPermitido:=True, bscNroOrdenDeCompra))
   End Sub

   Private Sub bscNroOrdenDeCompra_BuscadorClick() Handles bscNroOrdenDeCompra.BuscadorClick
      TryCatched(
         Sub()
            _publicos.PreparaGrillaOrdenDeCompra(bscNroOrdenDeCompra)
            Dim nroOrdenDeCompra = bscNroOrdenDeCompra.Text.ValorNumericoPorDefecto(0L)
            bscNroOrdenDeCompra.Datos = New Reglas.OrdenesCompra().GetPorCodigo(actual.Sucursal.Id, nroOrdenDeCompra)
         End Sub)
   End Sub

   Private Sub bscNroOrdenDeCompra_BuscadorSeleccion(sender As Object, e As Controles.BuscadorEventArgs) Handles bscNroOrdenDeCompra.BuscadorSeleccion
      TryCatched(
         Sub()
            If e.FilaDevuelta IsNot Nothing Then
               bscNroOrdenDeCompra.Text = e.FilaDevuelta.Cells("NumeroOrdenCompra").Value.ToString()
               bscNroOrdenDeCompra.Permitido = False
            End If
         End Sub)
   End Sub

#End Region

#Region "Metodos"

   Private Sub Refrescar()

      If cmbTiposComprobantesRec.Items.Count > 0 Then
         cmbTiposComprobantesRec.SelectedIndex = -1   'Fuerzo el evento de Changed
         cmbTiposComprobantesRec.SelectedIndex = 0
      Else
         cmbTiposComprobantesRec.SelectedIndex = -1
      End If

      txtLetra.ReadOnly = False
      txtEmisor.ReadOnly = False
      txtNroRecibo.ReadOnly = False
      btnConsultar.Enabled = True

      txtTotalPago.Enabled = True
      tbcDetalle.SelectedTab = Me.tbpComprobantes
      tbcDetalle.Enabled = True
      txtCodigoCliente.Text = String.Empty
      txtNombreCliente.Text = String.Empty
      txtComprobantes.Enabled = True
      txtObservacion.Text = String.Empty


      _publicos.CargaComboCajas(Me.cmbCajas, actual.Sucursal.IdSucursal, miraUsuario:=True, miraPC:=Not Reglas.Publicos.CtaCte.ReciboIgnorarPCdeCaja, cajasModificables:=True)
      cmbCajas.Enabled = False

      _ComprobantesGrilla.Clear()
      dgvComprobantes.DataSource = Me._ComprobantesGrilla.ToArray()
      AjustarColumnasGrilla(dgvComprobantes, _tit)
      txtLocalidad.Text = String.Empty
      txtComprobantes.Text = "0.00"
      txtDireccion.Text = String.Empty
      txtNombreVendedor.Text = String.Empty

      dtpFechaEmision.Value = Date.Now

      'Me.txtLetra.Text = "X"
      txtEmisor.Text = String.Empty
      txtNroRecibo.Text = String.Empty
      txtTotalPago.Text = "0.00"
      txtCategoriaFiscal.Text = String.Empty
      HabilitaToolbar(False)
      txtEfectivo.Text = "0.00"
      txtRetenciones.Text = "0.00"
      txtTarjetas.Text = "0.00"
      txtTransferenciaBancaria.Text = "0.00"
      bscCuentaBancariaTransfBanc.Text = String.Empty
      txtSaldoActual.Text = "0.00"
      txtDiferencia.Text = "0.00"

      _cheques.Clear()
      dgvCheques.DataSource = Me._cheques.ToArray()

      _retenciones.Clear()
      dgvRetenciones.DataSource = Me._retenciones.ToArray()

      tbcDetalle.SelectedTab = Me.tbpComprobantes

      _clienteGrilla = Nothing

      '-.PE-31462.-
      cmbVendedor.SelectedIndex = -1

      txtLetra.Focus()

   End Sub

   Private Sub MostrarRecibo()
      If _modalidadPantalla = Entidades.ModalidadPantalla.Anular AndAlso Me._recibo.ImporteTotal = 0 And Me._recibo.Observacion = "***ANULADO***" Then
         MessageBox.Show("ATENCION: el Recibo ya se encuentra Anulado", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
         HabilitaToolbar(False)
         Exit Sub
      End If

      dtpFechaEmision.Value = Me._recibo.Fecha

      If Me._recibo.FechaTransferencia.HasValue Then
         Me.dtpFechaTransferencia.Value = Me._recibo.FechaTransferencia.Value.Date
      End If


      Me.txtEfectivo.Text = Me._recibo.ImportePesos.ToString("#,##0.00")
      Me.txtTarjetas.Text = Me._recibo.ImporteTarjetas.ToString("#,##0.00")
      Me.txtCheques.Text = Me._recibo.ImporteCheques.ToString("#,##0.00")
      Me.txtTransferenciaBancaria.Text = Me._recibo.ImporteTransfBancaria.ToString("#,##0.00")

      Me.bscCuentaBancariaTransfBanc.Text = Me._recibo.CuentaBancariaTransfBanc.NombreCuenta
      If Not String.IsNullOrWhiteSpace(_recibo.CuentaBancariaTransfBanc.NombreCuenta) Then
         Me.bscCuentaBancariaTransfBanc.PresionarBoton()
      End If
      Me.txtRetenciones.Text = Me._recibo.ImporteRetenciones.ToString("#,##0.00")

      If _recibo.NumeroOrdenCompra <> 0 Then
         chbNroOrdenDeCompra.Checked = True
         bscNroOrdenDeCompra.Text = _recibo.NumeroOrdenCompra.ToString()
         bscNroOrdenDeCompra.Permitido = True
         bscNroOrdenDeCompra.PresionarBoton()
         bscNroOrdenDeCompra.Permitido = False
      Else
         chbNroOrdenDeCompra.Checked = False
         bscNroOrdenDeCompra.Text = String.Empty
      End If

      Me.CargarDatosCliente(Me._recibo)

      Me.txtNombreVendedor.Text = Me._recibo.Vendedor.NombreEmpleado
      txtObservacion.Text = _recibo.Observacion

      'PE-31462
      Me.cmbVendedor.SelectedValue = Me._recibo.Vendedor.IdEmpleado

      Me.CargarComprobantes(Me._recibo)
      Me.CargarCheques(Me._recibo)
      Me.CargarRetenciones(Me._recibo)
      Me.CalcularPagos()

      If _modalidadPantalla = Entidades.ModalidadPantalla.Anular Then
         Dim Cont As Integer = 0

         For Cont = 1 To Me._recibo.Cheques.Count
            'If Me._recibo.Cheques.Item(Cont - 1).NroMovimientoEgreso > 0 Then
            If Me._recibo.Cheques.Item(Cont - 1).IdEstadoCheque <> Entidades.Cheque.Estados.ENCARTERA Then
               Dim stbMensaje As StringBuilder = New StringBuilder()
               stbMensaje.AppendLine("ATENCION: el Recibo tiene al menos este cheque entregado, NO puede ANULARLO...").AppendLine()
               stbMensaje.AppendFormatLine("Banco: {0} / Suc. Bco: {1} / Loc. Bco: {2} / Numero Cheq.: {3}",
                                        _recibo.Cheques.Item(Cont - 1).Banco.NombreBanco,
                                        _recibo.Cheques.Item(Cont - 1).IdBancoSucursal,
                                        _recibo.Cheques.Item(Cont - 1).Localidad.NombreLocalidad,
                                        _recibo.Cheques.Item(Cont - 1).NumeroCheque)

               MessageBox.Show(stbMensaje.ToString(), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
               HabilitaToolbar(False)
               Exit Sub
            End If
         Next
      End If

      Me.cmbCajas.Text = New Reglas.CajasNombres().GetUna(actual.Sucursal.IdSucursal, Me._recibo.CajaDetalle.IdCaja).NombreCaja

      'Solo deja cambiar la caja si fue completo en Efectivo.
      'Me.cmbCajas.Enabled = (Me._recibo.ImportePesos = Me._recibo.ImporteTotal)

      Me.txtLetra.ReadOnly = True
      Me.txtEmisor.ReadOnly = True
      Me.txtNroRecibo.ReadOnly = True
      Me.btnConsultar.Enabled = False
   End Sub

   Private Sub AnularRecibo()

      If Me.ValidarOperacion() Then

         Dim oCtaCte As Reglas.CuentasCorrientes = New Reglas.CuentasCorrientes()

         If Me.cmbCajas.Enabled = True Then
            If Me._recibo.CajaDetalle.IdCaja <> Integer.Parse(Me.cmbCajas.SelectedValue.ToString()) Then
               If MessageBox.Show("ATENCION: El Recibo " & Me._recibo.NumeroComprobante & " tiene una Caja distinta, esta seguro de aplicarlo a otra caja?!!", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) = Windows.Forms.DialogResult.No Then
                  Exit Sub
               End If
               Me._recibo.CajaDetalle.IdCaja = Integer.Parse(Me.cmbCajas.SelectedValue.ToString())
            End If
         End If

         oCtaCte.AnularRecibo(Me._recibo)

         MessageBox.Show("Se Anulo el Recibo número " & Me._recibo.NumeroComprobante, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)

         Me.Refrescar()

      End If

   End Sub

   Private Sub GrabarDatos()
      With Me._recibo
         .Observacion = txtObservacion.Text
         If IsNumeric(bscCuentaBancariaTransfBanc.Tag) Then
            .CuentaBancariaTransfBanc = New Reglas.CuentasBancarias().GetUna(Integer.Parse(Me.bscCuentaBancariaTransfBanc.Tag.ToString()))
         End If

         _recibo.Fecha = dtpFechaEmision.Value
         _recibo.FechaTransferencia = dtpFechaTransferencia.Value

         With DirectCast(_recibo, Entidades.IComprobanteModificable)
            If _recibo.TipoComprobante.IdTipoComprobante <> cmbTiposComprobantesRec.SelectedValue.ToString() Or
               _recibo.Letra <> txtLetra.Text Or
               _recibo.CentroEmisor <> Short.Parse(txtEmisor.Text) Or _recibo.NumeroComprobante <> Long.Parse(txtNroRecibo.Text) Then
               .IdSucursalNuevo = _recibo.IdSucursal
               .IdTipoComprobanteNuevo = cmbTiposComprobantesRec.SelectedValue.ToString()
               .LetraNuevo = txtLetra.Text
               .CentroEmisorNuevo = Short.Parse(txtEmisor.Text)
               .NumeroComprobanteNuevo = Long.Parse(txtNroRecibo.Text)
            Else
               .LimpiaModificable()
            End If
         End With

         _recibo.Vendedor.IdEmpleado = CInt(cmbVendedor.SelectedValue)
         _recibo.NumeroOrdenCompra = bscNroOrdenDeCompra.Text.ValorNumericoPorDefecto(0L)

      End With

      Dim reg As Reglas.CuentasCorrientes = New Reglas.CuentasCorrientes()

      reg.ModificaRecibo(Me._recibo)

      MessageBox.Show("Se grabo correctamente!!", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)

      Me.Close()

   End Sub

   Private Sub CalcularComprobantes()

      Dim TotalComprobantes As Decimal = 0
      Dim TotalNCND As Decimal = 0

      For i As Integer = 0 To Me._ComprobantesGrilla.Count - 1

         TotalComprobantes += Me._ComprobantesGrilla(i).Paga

         If Me._ComprobantesGrilla(i).DescuentoRecargoPorc <> 0 Then
            TotalNCND += Me._ComprobantesGrilla(i).DescuentoRecargo
         End If

      Next

      'TotalComprobantes = Math.Round(TotalComprobantes, 2)

      Me.txtComprobantes.Text = TotalComprobantes.ToString("#,##0.00")

      Me.txtDiferencia.Text = (Decimal.Parse(Me.txtComprobantes.Text) - Decimal.Parse(Me.txtTotalPago.Text)).ToString("#,##0.00")

      Me.txtTotalNCND.Text = TotalNCND.ToString("#,##0.00")

      Me.VerificarGrabarImprimir()

   End Sub

   Private Sub VerificarGrabarImprimir()

      Dim ImporteTope As Decimal

      If cmbTiposComprobantesRec.SelectedItem IsNot Nothing Then
         ImporteTope = DirectCast(Me.cmbTiposComprobantesRec.SelectedItem, Entidades.TipoComprobante).ImporteTope

         Select Case True
            'Recibos Aplicados 100%, Recibos con Anticipos o Minutas
            Case ImporteTope >= 0 And Decimal.Parse(Me.txtDiferencia.Text) <= 0
               HabilitaToolbar(True)

               'Desembolsos Aplicados 100% o con Anticipo
            Case ImporteTope < 0 And Decimal.Parse(Me.txtDiferencia.Text) >= 0
               HabilitaToolbar(True)

            Case Else
               HabilitaToolbar(False)

         End Select
      Else
         HabilitaToolbar(False)
      End If

   End Sub

   Private Sub CalcularPagos()

      Dim pago As Decimal = 0

      'For i As Integer = 0 To Me._cheques.Count - 1
      '   pago += Me._cheques(i).Importe
      'Next

      pago = Decimal.Parse(Me.txtEfectivo.Text) + Decimal.Parse(Me.txtTarjetas.Text) + Decimal.Parse(Me.txtTransferenciaBancaria.Text) + +Decimal.Parse(Me.txtCheques.Text) + Decimal.Parse(Me.txtRetenciones.Text)

      Me.txtTotalPago.Text = pago.ToString("#,##0.00")

      Me.txtDiferencia.Text = (Decimal.Parse(Me.txtComprobantes.Text) - Decimal.Parse(Me.txtTotalPago.Text)).ToString("#,##0.00")

      Me.VerificarGrabarImprimir()

   End Sub

   Private Sub CargarDatosCliente(Recibo As Entidades.CuentaCorriente)

      txtCodigoCliente.Text = Recibo.Cliente.CodigoCliente.ToString()
      txtCodigoCliente.Tag = Recibo.Cliente.IdCliente.ToString()
      txtNombreCliente.Text = Recibo.Cliente.NombreCliente

      txtDireccion.Text = Recibo.Cliente.Direccion
      txtLocalidad.Text = Recibo.Cliente.NombreLocalidad

      txtCategoriaFiscal.Text = Recibo.Cliente.CategoriaFiscal.NombreCategoriaFiscal
      txtCategoriaFiscal.Tag = Recibo.Cliente.CategoriaFiscal.IdCategoriaFiscal

      tbcDetalle.Enabled = True

      Dim oCliente = New Reglas.Clientes()
      _clienteGrilla = oCliente.GetUnoPorCodigo(Long.Parse(Me.txtCodigoCliente.Text))

      'carga el saldo del cliente de la cuenta corriente
      Dim oCtaCte = New Reglas.CuentasCorrientes()
      txtSaldoActual.Text = oCtaCte.GetSaldoCliente({actual.Sucursal},
                                                    _clienteGrilla.IdCliente,
                                                    fechaSaldo:=Nothing, contemplaHora:=False, comprobantesAsociados:="TODOS", grabaLibro:=Nothing,
                                                    comprobantesExcluidos:=Nothing, numeroComprobanteFinalizaCon:=Nothing, excluirPreComprobantes:=False,
                                                    IdCama:=0, IdEmbarcacion:=0).ToString("N2")

   End Sub

   Private Sub CargarComprobantes(Recibo As Entidades.CuentaCorriente)
      _ComprobantesGrilla.Clear()

      For Each CCP In Recibo.Pagos
         Dim o = New Entidades.CuentaCorrientePago()
         With o
            .TipoComprobante = CCP.TipoComprobante
            .Letra = CCP.Letra
            .CentroEmisor = CCP.CentroEmisor
            .NumeroComprobante = CCP.NumeroComprobante
            .Cuota = CCP.Cuota
            .FechaEmision = CCP.FechaEmision
            .FechaVencimiento = CCP.FechaVencimiento
            .ImporteCuota = CCP.ImporteCuota
            .SaldoCuota = CCP.SaldoCuota
            .Paga = CCP.Paga
            .DescuentoRecargoPorc = CCP.DescuentoRecargoPorc
            .DescuentoRecargo = CCP.DescuentoRecargo
            .IdSucursal = CCP.IdSucursal
            .Usuario = actual.Nombre
         End With

         _ComprobantesGrilla.Add(o)
      Next

      dgvComprobantes.DataSource = _ComprobantesGrilla.ToArray()
      AjustarColumnasGrilla(dgvComprobantes, _tit)

      If dgvComprobantes.Rows.Count > 0 Then
         dgvComprobantes.FirstDisplayedScrollingRowIndex = dgvComprobantes.Rows.Count - 1
      End If

      dgvComprobantes.Refresh()
      CalcularComprobantes()

   End Sub

   Private Sub CargarCheques(Recibo As Entidades.CuentaCorriente)
      If Recibo.Cheques.Count > 0 Then
         dgvCheques.DataSource = Recibo.Cheques.ToArray()
         dgvCheques.FirstDisplayedScrollingRowIndex = Me.dgvCheques.Rows.Count - 1
         dgvCheques.Refresh()
      End If
   End Sub

   Private Sub CargarRetenciones(Recibo As Entidades.CuentaCorriente)
      If Recibo.Retenciones.Count > 0 Then
         dgvRetenciones.DataSource = Recibo.Retenciones.ToArray()
         dgvRetenciones.FirstDisplayedScrollingRowIndex = Me.dgvRetenciones.Rows.Count - 1
         dgvRetenciones.Refresh()
      End If
   End Sub

   Private Function ValidarOperacion() As Boolean
      'Generó un ANTICIPO
      If Decimal.Parse(Me.txtDiferencia.Text) <> 0 Then
         'If DirectCast(Me.cmbTiposComprobantesRec.SelectedItem, Entidades.TipoComprobante).GrabaLibro Then
         '   TipoAnticipo = Entidades.TipoComprobante.Tipos.ANTICIPO.ToString()
         'Else
         '   TipoAnticipo = Entidades.TipoComprobante.Tipos.ANTICIPOPROV.ToString()
         'End If
         Dim TipoAnticipo = DirectCast(Me.cmbTiposComprobantesRec.SelectedItem, Entidades.TipoComprobante).IdTipoComprobanteSecundario

         Dim oCtaCte = New Reglas.CuentasCorrientes
         Dim Antic = oCtaCte.GetUna(actual.Sucursal.Id, TipoAnticipo, Me.txtLetra.Text, Integer.Parse(Me.txtEmisor.Text), Long.Parse(Me.txtNroRecibo.Text))

         'El Saldo viene con el saldo cambiado, pero por las dudas le saco el signo a ambos.
         If Math.Abs(Antic.ImporteTotal) <> Math.Abs(Antic.Saldo) Then
            MessageBox.Show("El Recibo actual generó un ANTICIPO y tiene pago aplicado, debe anular primero el Recibo que lo afectó", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return False
         End If

      End If

      Return True
   End Function

   Private Sub HabilitaToolbar(habilita As Boolean)
      tsbAnular.Enabled = habilita
      tsbGrabar.Enabled = habilita
   End Sub

#End Region

End Class