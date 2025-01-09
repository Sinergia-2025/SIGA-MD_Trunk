Public Class ChequesMovimientosSucursales
   Private Const SelectedColumnName As String = "Aplicar"

#Region "Campos"

   Private _publicos As Publicos
   Private _cargando As Boolean = True
   Private _idCajaOrigen As Integer = 0
   Private _idCajaDestino As Integer = 0
   Private _idSucursal As Integer = 0
   Private _idSucursalDestino As Integer = 0
   Private _planillaActual As Entidades.Caja
   Private _PlanillaActual2 As Entidades.Caja
   Private _tit As Dictionary(Of String, String)

#End Region

#Region "Overrides"

   Protected Overrides Sub OnLoad(e As EventArgs)
      MyBase.OnLoad(e)
      TryCatched(
      Sub()
         _publicos = New Publicos()

         _publicos.CargaComboSucursales(cmbSucursalDestino)
         _publicos.CargaComboDesdeEnum(cmbTodos, GetType(Reglas.Publicos.TodosEnum))

         '-- REQ-43589.- -------------------------------------------------------------------------------------------------------
         _publicos.CargaComboDesdeEnum(cmbTodosTrj, GetType(Reglas.Publicos.TodosEnum))
         _publicos.CargaComboBancos(cmbBanco)
         _publicos.CargaComboTarjetas(cmbTarjeta)
         cmbTarjeta.SelectedIndex = -1
         '----------------------------------------------------------------------------------------------------------------------
         _idSucursal = actual.Sucursal.Id
         _idSucursalDestino = actual.Sucursal.Id

         _publicos.CargaComboCajas(cmbCajasOrigen, actual.Sucursal.Id, miraUsuario:=True, miraPC:=True, cajasModificables:=True)
         _idCajaOrigen = cmbCajasOrigen.ValorSeleccionado(0I)
         _idCajaDestino = cmbCajasDestino.ValorSeleccionado(0I)

         If Reglas.Publicos.TieneModuloContabilidad Then
            '# Si utiliza módulo contable, no se permite por ahora realizar movimientos de Bancos (acordado asi con AR)
            pnlBancos.Visible = False
            pnlBancos2.Visible = False
            pnlBancos3.Visible = False
         End If

         _tit = GetColumnasVisiblesGrilla(ugDetalle)

         RefrescarDatos()

         ugDetalle.AgregarFiltroEnLinea({"NombreBanco", "NroOperacion", "Titular", "Ingreso", "NombreCliente", "Egreso", "NombreProveedor"})

         ugTarjetas.AgregarFiltroEnLinea({"NombreTarjeta", "NombreBanco", "NombreCliente"})
         ugTarjetas.AgregarTotalesSuma({"Monto"})

         _cargando = False
      End Sub)
   End Sub
   Protected Overrides Function ProcessCmdKey(ByRef msg As Message, keyData As Keys) As Boolean
      If keyData = Keys.F5 Then
         tsbRefrescar.PerformClick()
      Else
         Return MyBase.ProcessCmdKey(msg, keyData)
      End If
      Return True
   End Function
#End Region

#Region "Eventos"

#Region "Eventos Toolbar"
   Private Sub tsbRefrescar_Click(sender As Object, e As EventArgs) Handles tsbRefrescar.Click
      TryCatched(
      Sub()
         If cmbCajasOrigen.Items.Count = 0 Then
            Throw New Exception(String.Format("ATENCION: El Usuario NO tiene Caja Asociada y NO podrá continuar.{0}{0}Por favor contáctese con Sistemas.", Environment.NewLine))
         End If
         RefrescarDatos()
      End Sub)
   End Sub
   Private Sub tsbSalir_Click(sender As Object, e As EventArgs) Handles tsbSalir.Click
      TryCatched(Sub() Close())
   End Sub
#End Region

   Private Sub cmbSucursalOrigen_SelectedIndexChanged(sender As Object, e As EventArgs)
      TryCatched(Sub() RefrescarDatos())
   End Sub
   Private Sub cmbSucursalDestino_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbSucursalDestino.SelectedIndexChanged
      TryCatched(
      Sub()
         _idSucursalDestino = cmbSucursalDestino.ValorSeleccionado(0I)
         _publicos.CargaComboCajas(cmbCajasDestino, _idSucursalDestino, miraUsuario:=False, miraPC:=False, cajasModificables:=False)
      End Sub,
      onErrorAction:=
      Sub(owner, ex)
         ShowError(ex)
         cmbCajasDestino.SelectedIndex = -1
      End Sub)
   End Sub
   Private Sub cmbCajasOrigen_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbCajasOrigen.SelectedIndexChanged
      TryCatched(
      Sub()
         _idCajaOrigen = cmbCajasOrigen.ValorSeleccionado(0I)
         CargarCajaOrigen()
      End Sub)
   End Sub
   Private Sub cmbCajasDestino_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbCajasDestino.SelectedIndexChanged
      TryCatched(
      Sub()
         _idCajaDestino = cmbCajasDestino.ValorSeleccionado(0I)
         CargarCajaDestino()

         '# Seguridad para visualizar o no los saldos de la caja destino
         SeguridadMostrarSaldosDeCuentaDestino(_idCajaDestino, cmbSucursalDestino.ValorSeleccionado(Of Integer)(), actual.Nombre)
      End Sub)
   End Sub

   Private Sub btnConsultar_Click(sender As Object, e As EventArgs) Handles btnConsultar.Click
      TryCatched(
      Sub()
         If cmbCajasOrigen.Items.Count = 0 Then
            Throw New Exception(String.Format("ATENCION: El Usuario NO tiene Caja Asociada y NO podrá continuar.{0}{0}Por favor contáctese con Sistemas.", Environment.NewLine))
         End If

         CargaGrillaDetalle()

         If ugDetalle.Count > 0 Then
            btnConsultar.Focus()
         Else
            ShowMessage("ATENCION: NO hay registros que cumplan con la selección !!!")
         End If
      End Sub)
   End Sub
   Private Sub btnMover_Click(sender As Object, e As EventArgs) Handles btnMover.Click
      TryCatched(Sub() Mover())
   End Sub

#Region "Marcar/Desmarcar Todos"
   Private Sub btnTodos_Click(sender As Object, e As EventArgs) Handles btnTodos.Click
      TryCatched(Sub() ugDetalle.MarcarDesmarcar(cmbTodos, SelectedColumnName))
   End Sub
   Private Sub btnTodosTrj_Click(sender As Object, e As EventArgs) Handles btnTodosTrj.Click
      TryCatched(Sub() ugTarjetas.MarcarDesmarcar(cmbTodosTrj, SelectedColumnName))
   End Sub
#End Region

   Private Sub dtpFechaCobroDesde_KeyDown(sender As Object, e As KeyEventArgs) Handles dtpFechaCobroDesde.KeyDown, dtpFechaCobroHasta.KeyDown
      PresionarTab(e)
   End Sub

#End Region

#Region "Metodos"
   Private Sub RefrescarDatos()

      dtpFechaCobroDesde.Value = Date.Today.AddDays(-30)
      dtpFechaCobroHasta.Value = Date.Today.AddDays(30)
      '-- REQ-43589.- ------------------------------------------
      dtpDesdeEmision.Value = Date.Today.AddDays(-30)
      dtpHastaEmision.Value = Date.Today.AddDays(30)
      chbNumeroCupon.Checked = False
      chbNumeroLote.Checked = False
      chbBanco.Checked = False
      chbTarjeta.Checked = False
      chbCliente.Checked = False
      ugTarjetas.ClearFilas()
      '---------------------------------------------------------
      dtpFecha.Value = Date.Now

      cmbCajasOrigen.SelectedIndex = 0

      ugDetalle.ClearFilas()


      cmbSucursalDestino.SelectedValue = actual.Sucursal.Id
      cmbCajasDestino.SelectedIndex = 0

      CargarCajaOrigen()
      CargarCajaDestino()

      txtPesos.SetValor(0D)
      txtTickets.SetValor(0D)
      txtDolares.SetValor(0D)
      txtBancos.SetValor(0D)

      txtCotizacionDolares.SetValor(New Reglas.Monedas().GetUna(Entidades.Moneda.Dolar).FactorConversion)

   End Sub
   Private Sub CargaGrillaDetalle()
      Dim estadoCheque = New Reglas.EstadosCheques().GetUno(Entidades.Cheque.Estados.ENCARTERA.ToString())

      _idCajaOrigen = cmbCajasOrigen.ValorSeleccionado(0I)

      '# MF Cajas
      Dim rCajasNombres As Reglas.CajasNombres = New Reglas.CajasNombres
      Dim caja = rCajasNombres.GetUna(actual.Sucursal.Id, cmbCajasOrigen.ValorSeleccionado(0I))

      Dim rCheques = New Reglas.Cheques()
      Dim dtDetalle = rCheques.GetInforme({actual.Sucursal}, {caja}, {estadoCheque},
                                          dtpFechaCobroDesde.Value, dtpFechaCobroHasta.Value,
                                          fechaEnCarteraAl:=Nothing, numero:=0, idBanco:=0, idLocalidad:=0, esPropio:=False,
                                          idCliente:=0, idProveedor:=0, titular:=String.Empty,
                                          fechaIngresoDesde:=Nothing, fechaIngresoHasta:=Nothing, idCuentaBancaria:=0,
                                          orden:=Entidades.Cheque.Ordenamiento.FECHACOBRO, tipoCheque:=String.Empty,
                                          conciliado:=Nothing, observacion:=String.Empty)

      dtDetalle.Columns.Add(SelectedColumnName, GetType(Boolean))
      dtDetalle.AsEnumerable().ToList().ForEach(Sub(dr) dr(SelectedColumnName) = False)

      ugDetalle.DataSource = dtDetalle
      AjustarColumnasGrilla(ugDetalle, _tit)
   End Sub

   Private Sub CargaGrillaTarjetas()

      _idCajaOrigen = cmbCajasOrigen.ValorSeleccionado(0I)

      Dim rCajasNombres As Reglas.CajasNombres = New Reglas.CajasNombres
      Dim caja = rCajasNombres.GetUna(actual.Sucursal.Id, cmbCajasOrigen.ValorSeleccionado(0I))

      Dim rTarjetas = New Reglas.TarjetasCupones()

      Dim dtDetalleTrj = rTarjetas.GetInformeCupones({actual.Sucursal},
                                                  0,
                                                  If(chbFechaEmision.Checked, dtpDesdeEmision.Value, Date.Now),
                                                  If(chbFechaEmision.Checked, dtpHastaEmision.Value, Date.Now),
                                                  Entidades.TarjetaCupon.Estados.ENCARTERA.ToString(),
                                                  Nothing,
                                                  Nothing,
                                                  If(chbNumeroCupon.Checked, Integer.Parse(txtNumeroCupon.Text()), 0),
                                                  If(chbNumeroLote.Checked, Integer.Parse(txtNumeroLote.Text), 0),
                                                  Nothing,
                                                  caja.IdCaja,
                                                  If(chbBanco.Checked, Integer.Parse(cmbBanco.SelectedValue.ToString()), 0),
                                                  If(chbCliente.Checked, Integer.Parse(bscCodigoCliente.Tag.ToString()), 0),
                                                  If(chbTarjeta.Checked, Integer.Parse(cmbBanco.SelectedValue.ToString()), 0),
                                                  0)
      dtDetalleTrj.Columns.Add(SelectedColumnName, GetType(Boolean))
      dtDetalleTrj.AsEnumerable().ToList().ForEach(Sub(dr) dr(SelectedColumnName) = False)

      ugTarjetas.DataSource = dtDetalleTrj
      FormatearGrilla()

   End Sub

   Public Sub FormatearGrilla()
      With ugTarjetas.DisplayLayout.Bands(0)
         .OcultaTodasLasColumnas()

         Dim col As Integer = 0
         .Columns("Aplicar").FormatearColumna("", col, 30, HAlign.Center,,,, Activation.AllowEdit)
         .Columns("NombreTarjeta").FormatearColumna("Tarjeta", col, 150, HAlign.Left)
         .Columns("NombreBanco").FormatearColumna("Banco", col, 150, HAlign.Left)
         .Columns("NumeroLote").FormatearColumna("Lote", col, 50, HAlign.Right)
         .Columns("NumeroCupon").FormatearColumna("Cupón", col, 50, HAlign.Right)
         .Columns("Cuotas").FormatearColumna("Cuotas", col, 50, HAlign.Right)
         .Columns("Monto").FormatearColumna("Monto", col, 90, HAlign.Right)
         .Columns("FechaEmision").FormatearColumna("Fecha Emision", col, 90, HAlign.Center)
         .Columns("IdEstadoTarjeta").FormatearColumna("Estado", col, 90, HAlign.Left)
         .Columns("CodigoCliente").FormatearColumna("Código", col, 90, HAlign.Right)
         .Columns("NombreCliente").FormatearColumna("Cliente", col, 180, HAlign.Left)
         .Columns("NombreSituacionCupon").FormatearColumna("Situacion", col, 100, HAlign.Left)
      End With
      ugTarjetas.AgregarFiltroEnLinea({"NombreTarjeta", "NombreBanco", "NombreCliente"})
      ugTarjetas.AgregarTotalesSuma({"Monto"})
   End Sub

   Private Sub Mover()
      If cmbCajasOrigen.Items.Count = 0 Then
         Throw New Exception(String.Format("ATENCION: El Usuario NO tiene Caja Asociada y NO podrá continuar.{0}{0}Por favor contáctese con Sistemas.", Environment.NewLine))
      End If

      If cmbSucursalDestino.SelectedIndex = -1 Then
         ShowMessage("Debe seleccionar una Sucursal de Destino.")
         cmbSucursalDestino.Focus()
         Exit Sub
      End If

      If cmbSucursalDestino.ValorSeleccionado(0I) = actual.Sucursal.Id And
            cmbCajasDestino.ValorSeleccionado(0I) = cmbCajasOrigen.ValorSeleccionado(0I) Then
         ShowMessage("No puede Mover a la misma Caja.")
         Exit Sub
      End If

      Dim pesos = 0D
      Dim tarjetas = 0D
      Dim tickets = 0D
      Dim dolares = 0D
      Dim bancos = 0D

      Dim rCheques = New Reglas.Cheques()
      Dim rTarjetas = New Reglas.TarjetasCupones()

      Dim rCajas = New Reglas.Cajas()
      ugDetalle.UpdateData()

      Dim cheques = New List(Of Entidades.Cheque)()
      For Each dr In ugDetalle.DataSource(Of DataTable).Where(Function(dr1) dr1.Field(Of Boolean)(SelectedColumnName))
         Dim che = rCheques.GetUno(dr.Field(Of Long)("IdCheque"))
         che.IdSucursal2 = Integer.Parse(Me.cmbSucursalDestino.SelectedValue.ToString())
         cheques.Add(che)
      Next

      If txtPesos.ValorNumericoPorDefecto(0D) <> 0 Then
         If txtPesos.ValorNumericoPorDefecto(0D) > txtPACEfectivo.Text.ValorNumericoPorDefecto(0D) Then
            If Publicos.PermitirMovimientoCajasSinSaldo() Then
               pesos = txtPesos.ValorNumericoPorDefecto(0D)
            Else
               Throw New Exception(String.Format("No puede Mover mas de: {0} Pesos", txtPACEfectivo.Text.ValorNumericoPorDefecto(0D)))
            End If
         Else
            pesos = txtPesos.ValorNumericoPorDefecto(0D)
         End If
      End If

      Dim cupones = New List(Of Entidades.TarjetaCupon)()
      For Each dr In ugTarjetas.DataSource(Of DataTable).Where(Function(dr1) dr1.Field(Of Boolean)(SelectedColumnName))
         Dim trj = rTarjetas.GetUno(dr.Field(Of Integer)("IdTarjetaCupon"))
         trj.IdSucursal2 = Integer.Parse(Me.cmbSucursalDestino.SelectedValue.ToString())
         cupones.Add(trj)
      Next
      tarjetas = ugTarjetas.DataSource(Of DataTable).Sum(Function(x) x.Field(Of Decimal)("Monto"))

      If txtTickets.ValorNumericoPorDefecto(0D) <> 0 Then
         If txtTickets.ValorNumericoPorDefecto(0D) > txtPACTickets.Text.ValorNumericoPorDefecto(0D) Then
            Throw New Exception(String.Format("No puede Mover mas de: {0} en Tickets", txtPACTickets.Text.ValorNumericoPorDefecto(0D)))
         Else
            tickets = txtTickets.ValorNumericoPorDefecto(0D)
         End If

      End If

      If txtDolares.ValorNumericoPorDefecto(0D) <> 0 Then
         If txtDolares.ValorNumericoPorDefecto(0D) > txtPACDolares.Text.ValorNumericoPorDefecto(0D) Then
            Throw New Exception(String.Format("No puede Mover mas de: {0} en Dólares", txtPACDolares.Text.ValorNumericoPorDefecto(0D)))
         Else
            dolares = txtDolares.ValorNumericoPorDefecto(0D)
         End If

      End If

      If txtBancos.ValorNumericoPorDefecto(0D) <> 0 Then
         If txtBancos.ValorNumericoPorDefecto(0D) > txtPACBancos.Text.ValorNumericoPorDefecto(0D) Then
            Throw New Exception(String.Format("No puede Mover mas de: {0} en Bancos", txtPACBancos.Text.ValorNumericoPorDefecto(0D)))
         Else
            bancos = txtBancos.ValorNumericoPorDefecto(0D)
         End If
      End If

      Dim cotizacionDolar = txtCotizacionDolares.ValorNumericoPorDefecto(0D)

      ' controlo los topes
      Dim rCaja = New Reglas.CajasNombres()
      Dim totalCaja = txtPACEfectivo2.Text.ValorNumericoPorDefecto(0D) + txtPesos.Text.ValorNumericoPorDefecto(0D)
      Dim observacion = txtObservacion.Text

      Dim caja = rCaja.GetUna(_idSucursalDestino, cmbCajasDestino.ValorSeleccionado(0I))
      If caja.TopeAviso > 0 And totalCaja >= caja.TopeAviso And totalCaja < caja.TopeBloqueo Then
         ShowMessage(String.Format("Superó el Limite Recomendado de {0:N2}, y está por llegar al Límite Permitido en Caja de {1:N2}", caja.TopeAviso, caja.TopeBloqueo))
      ElseIf caja.TopeBloqueo > 0 And totalCaja >= caja.TopeBloqueo Then
         Throw New Exception(String.Format("Llegó al Límite Permitido en Caja de {0:N2}", caja.TopeBloqueo))
      End If

      If cheques.Count > 0 Or pesos <> 0 Or tickets <> 0 Or dolares <> 0 Or bancos <> 0 Or cupones.Count > 0 Then
         Dim moviEntreCaj = rCajas.MoverEntreCajas(pesos, tarjetas, tickets, dolares, bancos, cotizacionDolar, cheques, cupones,
                                                   actual.Sucursal.Id, cmbCajasOrigen.ValorSeleccionado(0I),
                                                   cmbSucursalDestino.ValorSeleccionado(0I),
                                                   cmbCajasDestino.ValorSeleccionado(0I),
                                                   actual.Nombre, dtpFecha.Value, observacion,
                                                   Entidades.Moneda.Peso)

         Dim mensaje As String
         If actual.Sucursal.IdSucursal <> cmbSucursalDestino.ValorSeleccionado(0I) Then
            mensaje = String.Format("Sucursal: {0} - Caja: {1}", cmbSucursalDestino.Text, cmbCajasDestino.Text)
         Else
            mensaje = String.Format("Caja: {0}", cmbCajasDestino.Text)
         End If
         ShowMessage(String.Format("Se hicieron los Movimientos a la {0}", mensaje))

         ImprimirMovimiento(moviEntreCaj)
         RefrescarDatos()
      Else
         ShowMessage("No seleccionó ningun Cheque y/o Cupon, ni ingreso Importes a mover.")
      End If
   End Sub

   Private Sub CargarCajaOrigen()
      Dim rCaja = New Reglas.Cajas()
      Dim planilla = rCaja.GetPlanillaActual(Me._idSucursal, Me._idCajaOrigen)
      If planilla IsNot Nothing Then
         With planilla
            If _planillaActual Is Nothing Then
               _planillaActual = New Entidades.Caja(_idSucursal, actual.Nombre, actual.Pwd)
            End If

            _planillaActual = planilla

            Dim sPesos = rCaja.GetSaldoPesos(_idSucursal, _idCajaOrigen, _planillaActual.NumeroPlanilla)
            Dim sDolares = rCaja.GetSaldoDolares(_idSucursal, _idCajaOrigen, _planillaActual.NumeroPlanilla)
            Dim sTickets = rCaja.GetSaldoTickets(_idSucursal, _idCajaOrigen, _planillaActual.NumeroPlanilla)
            Dim sCheques = rCaja.GetSaldoCheques(_idSucursal, _idCajaOrigen, _planillaActual.NumeroPlanilla)
            Dim sTarjetas = rCaja.GetSaldoTarjetas(_idSucursal, _idCajaOrigen, _planillaActual.NumeroPlanilla)
            Dim sBancos = rCaja.GetSaldoBancos(_idSucursal, _idCajaOrigen, _planillaActual.NumeroPlanilla)

            txtPACEfectivo.Text = (_planillaActual.PesosSaldoInicial + sPesos).ToString("N2")
            txtPACDolares.Text = (_planillaActual.DolaresSaldoInicial + sDolares).ToString("N2")
            txtPACTickets.Text = (_planillaActual.TicketsSaldoInicial + sTickets).ToString("N2")
            txtPACCheques.Text = (_planillaActual.ChequesSaldoInicial + sCheques).ToString("N2")
            txtPACTarjetas.Text = (_planillaActual.TarjetasSaldoInicial + sTarjetas).ToString("N2")
            txtPACBancos.Text = (_planillaActual.BancosSaldoInicial + sBancos).ToString("N2")
         End With
      End If
   End Sub
   Private Sub CargarCajaDestino()
      Dim rCaja2 = New Reglas.Cajas()
      Dim planilla2 = rCaja2.GetPlanillaActual(Me._idSucursalDestino, Me._idCajaDestino)
      If planilla2 IsNot Nothing Then
         With planilla2
            If _PlanillaActual2 Is Nothing Then
               _PlanillaActual2 = New Entidades.Caja(_idSucursalDestino, actual.Nombre, actual.Pwd)
            End If

            _PlanillaActual2 = planilla2

            Dim sPesos2 = rCaja2.GetSaldoPesos(_idSucursal, _idCajaDestino, _PlanillaActual2.NumeroPlanilla)
            Dim sDolares2 = rCaja2.GetSaldoDolares(_idSucursal, _idCajaDestino, _PlanillaActual2.NumeroPlanilla)
            Dim sTickets2 = rCaja2.GetSaldoTickets(_idSucursal, _idCajaDestino, _PlanillaActual2.NumeroPlanilla)
            Dim sCheques2 = rCaja2.GetSaldoCheques(_idSucursal, _idCajaDestino, _PlanillaActual2.NumeroPlanilla)
            Dim sTarjetas2 = rCaja2.GetSaldoTarjetas(_idSucursal, _idCajaDestino, _PlanillaActual2.NumeroPlanilla)
            Dim sBancos2 = rCaja2.GetSaldoBancos(_idSucursal, _idCajaDestino, _PlanillaActual2.NumeroPlanilla)

            txtPACEfectivo2.Text = (_PlanillaActual2.PesosSaldoInicial + sPesos2).ToString("N2")
            txtPACDolares2.Text = (_PlanillaActual2.DolaresSaldoInicial + sDolares2).ToString("N2")
            txtPACTickets2.Text = (_PlanillaActual2.TicketsSaldoInicial + sTickets2).ToString("N2")
            txtPACCheques2.Text = (_PlanillaActual2.ChequesSaldoInicial + sCheques2).ToString("N2")
            txtPACTarjetas2.Text = (_PlanillaActual2.TarjetasSaldoInicial + sTarjetas2).ToString("N2")
            txtPACBancos2.Text = (_PlanillaActual2.BancosSaldoInicial + sBancos2).ToString("N2")
         End With
      End If
   End Sub

   Private Sub SeguridadMostrarSaldosDeCuentaDestino(idCaja As Integer, idSucursal As Integer, idUsuario As String)
      '# Valido que el usuario tenga permisos para ver los saldos de la Caja Destino
      Dim rCajasUsuarios = New Reglas.CajasUsuarios
      pnlSaldosCuentaDestino.Visible = (rCajasUsuarios.GetCajaPorUsuario(idCaja, idSucursal, idUsuario)).Any()
   End Sub

   Private Sub ImprimirMovimiento(moviEntreCaj As Entidades.CajaDetalles)
      TryCatched(
      Sub()
         Dim imp = New ImprimirMovimientoCaja()
         imp.Imprimir(moviEntreCaj.IdSucursal, moviEntreCaj.IdCaja, moviEntreCaj.NumeroPlanilla, moviEntreCaj.NumeroMovimiento, visualiza:=True)
      End Sub)
   End Sub


   Private Sub chbFechaEmision_CheckedChanged(sender As Object, e As EventArgs) Handles chbFechaEmision.CheckedChanged
      TryCatched(Sub() chbFechaEmision.FiltroCheckedChanged(chbMesCompleto, dtpDesdeEmision, dtpHastaEmision))
   End Sub
   Private Sub chbMesCompleto_CheckedChanged(sender As Object, e As EventArgs) Handles chbMesCompleto.CheckedChanged
      TryCatched(Sub() chbMesCompleto.FiltroCheckedChangedMesCompleto(dtpDesdeEmision, dtpHastaEmision))
   End Sub

#Region "Eventos Buscador Clientes"
   Private Sub chbCliente_CheckedChanged(sender As Object, e As EventArgs) Handles chbCliente.CheckedChanged
      TryCatched(Sub()
                    Me.bscCodigoCliente.Enabled = Me.chbCliente.Checked
                    Me.bscNombreCliente.Enabled = Me.chbCliente.Checked

                    Me.bscCodigoCliente.Text = String.Empty
                    Me.bscCodigoCliente.Tag = Nothing
                    Me.bscNombreCliente.Text = String.Empty

                    Me.bscCodigoCliente.Focus()
                 End Sub)
   End Sub
   Private Sub bscCodigoCliente_BuscadorClick() Handles bscCodigoCliente.BuscadorClick
      TryCatched(
      Sub()
         _publicos.PreparaGrillaClientes2(bscCodigoCliente)
         Dim codigoCliente = bscCodigoCliente.Text.ValorNumericoPorDefecto(-1L)
         bscCodigoCliente.Datos = New Reglas.Clientes().GetFiltradoPorCodigo(codigoCliente, True, False)
      End Sub)
   End Sub
   Private Sub bscNombreCliente_BuscadorClick() Handles bscNombreCliente.BuscadorClick
      TryCatched(
      Sub()
         _publicos.PreparaGrillaClientes2(bscNombreCliente)
         bscNombreCliente.Datos = New Reglas.Clientes().GetFiltradoPorNombre(bscNombreCliente.Text.Trim(), True)
      End Sub)
   End Sub
   Private Sub bscCodigoCliente_BuscadorSeleccion(sender As Object, e As Controles.BuscadorEventArgs) Handles bscCodigoCliente.BuscadorSeleccion, bscNombreCliente.BuscadorSeleccion
      TryCatched(Sub() CargarDatosCliente(e.FilaDevuelta))
   End Sub
   Private Sub CargarDatosCliente(dr As DataGridViewRow)
      If dr IsNot Nothing Then
         bscNombreCliente.Text = dr.Cells("NombreCliente").Value.ToString()
         bscCodigoCliente.Text = dr.Cells("CodigoCliente").Value.ToString().Trim()
         bscCodigoCliente.Tag = dr.Cells("IdCliente").Value.ToString()
         bscNombreCliente.Permitido = False
         bscCodigoCliente.Permitido = False
      End If
   End Sub

#End Region
   Private Sub chbNumeroCupon_CheckedChanged(sender As Object, e As EventArgs) Handles chbNumeroCupon.CheckedChanged
      TryCatched(Sub() chbNumeroCupon.FiltroCheckedChanged(txtNumeroCupon))
   End Sub

   Private Sub chbNumeroLote_CheckedChanged(sender As Object, e As EventArgs) Handles chbNumeroLote.CheckedChanged
      TryCatched(Sub() chbNumeroLote.FiltroCheckedChanged(txtNumeroLote))
   End Sub

   Private Sub chbBanco_CheckedChanged(sender As Object, e As EventArgs) Handles chbBanco.CheckedChanged
      TryCatched(Sub() chbBanco.FiltroCheckedChanged(cmbBanco))
   End Sub

   Private Sub chbTarjeta_CheckedChanged(sender As Object, e As EventArgs) Handles chbTarjeta.CheckedChanged
      TryCatched(Sub() chbTarjeta.FiltroCheckedChanged(cmbTarjeta))
   End Sub

   Private Sub btnConsultarTrj_Click(sender As Object, e As EventArgs) Handles btnConsultarTrj.Click
      TryCatched(
         Sub()
            If cmbCajasOrigen.Items.Count = 0 Then
               Throw New Exception(String.Format("ATENCION: El Usuario NO tiene Caja Asociada y NO podrá continuar.{0}{0}Por favor contáctese con Sistemas.", Environment.NewLine))
            End If

            CargaGrillaTarjetas()

            If ugTarjetas.Count > 0 Then
               btnConsultarTrj.Focus()
            Else
               ShowMessage("ATENCION: NO hay registros que cumplan con la selección !!!")
            End If
         End Sub)
   End Sub


#End Region

End Class