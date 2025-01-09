Public Class ConcesionarioOperacionesDetalle
   Private _publicos As Publicos
   Private _categoriaFiscalEmpresa As Entidades.CategoriaFiscal
   Private _onLoad As Boolean = False

   Public ReadOnly Property Operacion As Entidades.ConcesionarioOperacion
      Get
         Return DirectCast(_entidad, Entidades.ConcesionarioOperacion)
      End Get
   End Property

   Public Sub New()
      ' This call is required by the designer.
      InitializeComponent()
      ' Add any initialization after the InitializeComponent() call.
   End Sub
   Public Sub New(entidad As Entidades.ConcesionarioOperacion)
      Me.New()
      _entidad = entidad
   End Sub

#Region "Overrides"
   Protected Overrides Sub OnLoad(e As EventArgs)
      MyBase.OnLoad(e)
      TryCatched(
         Sub()
            _onLoad = True
            _publicos = New Publicos()

            _categoriaFiscalEmpresa = New Reglas.CategoriasFiscales().GetUno(Reglas.Publicos.CategoriaFiscalEmpresa)

            _publicos.CargaComboMarcas(cmbMarca, seleccionMultiple:=False, seleccionTodos:=False)
            _publicos.CargaComboTipoDocumento(cmbTipoDocCliente)
            _publicos.CargaComboCategoriasFiscales(cmbCategoriaFiscal)

            BindearControles(_entidad)

            tbcPagosTarChe.SelectedTab = tbpPagosTarjetas
            UcMedioPagoTarjeta1.Inicializar(Operacion.Tarjetas.Cast(Of Entidades.ITarjetas), Function() New Entidades.ConcesionarioOperacionTarjeta())
            tbcPagosTarChe.SelectedTab = tbpPagosCheques
            UcMedioPagoChequesTerceros1.Inicializar(Operacion.Cheques.Cast(Of Entidades.Cheque), Function() New Entidades.Cheque())
            tbcPagosTarChe.SelectedTab = tbpVehiculosUsados
            ugVehiculosUsados.DataSource = Operacion.VehiculosPago

            If StateForm = StateForm.Insertar Then
               dtpFechaOperacion.Value = Date.Today
               txtCotizacionDolar.SetValor(New Reglas.Monedas().GetUna(Entidades.Moneda.Dolar).FactorConversion)

            Else

               cmbMarca.SelectedValue = Operacion.IdMarca
               txtAnioOperacion.SetValor(Operacion.AnioOperacion)
               txtNumeroOperacion.SetValor(Operacion.NumeroOperacion)
               txtSecuenciaOperacion.SetValor(Operacion.SecuenciaOperacion)

               If Operacion.Cliente IsNot Nothing AndAlso Operacion.Cliente.CodigoCliente <> 0 Then
                  bscCodigoCliente.Text = Operacion.Cliente.CodigoCliente.ToString()
                  bscCodigoCliente.PresionarBoton()
               End If

               If Operacion.IdCuentaBancaria <> 0 Then
                  Dim ctaBria = New Reglas.CuentasBancarias().GetUna(Operacion.IdCuentaBancaria)
                  bscCuentaBancariaTransfBanc.Text = ctaBria.NombreCuenta
                  bscCuentaBancariaTransfBanc.PresionarBoton()
               End If

               If Operacion.TipoOperacion = Entidades.ConcesionarioTipoOperacion.CeroKilometro Then
                  radCeroKm.Checked = True

                  If Not String.IsNullOrWhiteSpace(Operacion.IdProductoCeroKilometro) Then
                     bscCodigoProducto2.Text = Operacion.IdProductoCeroKilometro
                     bscCodigoProducto2.PresionarBoton()
                  End If

                  txtCantidadProducto.SetValor(Operacion.CantidadCeroKilometro.IfNull())
                  txtPrecioProducto.SetValor(Operacion.PrecioCeroKilometro.IfNull())
                  txtTotalProducto.SetValor(Operacion.ImporteCeroKilometro.IfNull())

               ElseIf Operacion.TipoOperacion = Entidades.ConcesionarioTipoOperacion.Usado Then
                  radUsado.Checked = True

                  If Not String.IsNullOrWhiteSpace(Operacion.PatenteVehiculoUsado) Then
                     bscCodigoVehiculoUsado.Text = Operacion.PatenteVehiculoUsado
                     bscCodigoVehiculoUsado.PresionarBoton()
                     bscCodigoVehiculoUsado.Permitido = False
                  End If

                  txtPrecioListaUsado.SetValor(Operacion.PrecioListaUsado.IfNull())
                  txtPrecioVentaUsado.SetValor(Operacion.ImporteUsado.IfNull())

               End If


            End If

            txtEfectivo.SetValor(Operacion.ImportePesos)
            txtTarjetas.SetValor(Operacion.ImporteTarjetas)
            txtCheques.SetValor(Operacion.ImporteCheques)

            txtTransferenciaBancaria.SetValor(Operacion.ImporteTransferencia)
            If Operacion.ImporteTransferencia <> 0 Then
               dtpFechaTransferencia.Value = Operacion.FechaTransferencia.IfNull(Date.Today)
               If Operacion.IdCuentaBancaria > 0 Then
                  bscCodigoCuentaBancariaTransfBanc.Text = Operacion.IdCuentaBancaria.ToString()
                  bscCodigoCuentaBancariaTransfBanc.PresionarBoton()
               End If
            Else
               dtpFechaTransferencia.Value = Date.Today
            End If

            Dim oUsuario = New Reglas.Usuarios()
            lnkProducto.Visible = oUsuario.TienePermisos("Productos")
            lblNombreProducto.Visible = Not lnkProducto.Visible
            llbCliente.Visible = oUsuario.TienePermisos("Clientes-PuedeUsarMasInfo")

            CalculaTotalGeneral()

            MostrarCeroKilometroUsado()
         End Sub,
         onFinallyAction:=Sub(owner) _onLoad = False)
   End Sub
   Protected Overrides Function ProcessCmdKey(ByRef msg As Message, keyData As Keys) As Boolean
      If keyData = Keys.F4 Then
         btnAceptar.PerformClick()
      ElseIf keyData = Keys.F7 Then
         btnAdicionales.PerformClick()
      ElseIf keyData = Keys.F8 Then
         btnCaracteristicas.PerformClick()
      Else
         Return MyBase.ProcessCmdKey(msg, keyData)
      End If
      Return True
   End Function
   Protected Overrides Function GetReglas() As Reglas.Base
      Return New Reglas.ConcesionarioOperaciones()
   End Function
   Protected Overrides Sub Aceptar()

      Operacion.IdMarca = cmbMarca.ValorSeleccionado(Of Integer)()
      Operacion.AnioOperacion = txtAnioOperacion.ValorNumericoPorDefecto(0I)

      If bscCodigoCliente.Selecciono Or bscCliente.Selecciono Then
         Operacion.Cliente = DirectCast(bscCodigoCliente.Tag, Entidades.ClienteLiviano)
      Else
         Operacion.Cliente = Nothing
      End If
      Operacion.TipoOperacion = If(radUsado.Checked, Entidades.ConcesionarioTipoOperacion.Usado, Entidades.ConcesionarioTipoOperacion.CeroKilometro)

      If radCeroKm.Checked Then
         If bscCodigoProducto2.Selecciono Or bscProducto2.Selecciono Then
            Operacion.IdProductoCeroKilometro = bscCodigoProducto2.Text
         Else
            Operacion.IdProductoCeroKilometro = String.Empty
         End If
         Operacion.CantidadCeroKilometro = txtCantidadProducto.ValorNumericoPorDefecto(0D)
         Operacion.PrecioCeroKilometro = txtPrecioProducto.ValorNumericoPorDefecto(0D)
         Operacion.ImporteCeroKilometro = txtTotalProducto.ValorNumericoPorDefecto(0D)


         Operacion.PatenteVehiculoUsado = String.Empty
         Operacion.PrecioListaUsado = Nothing
         Operacion.ImporteUsado = Nothing

      Else
         Operacion.IdProductoCeroKilometro = String.Empty
         Operacion.CantidadCeroKilometro = Nothing
         Operacion.PrecioCeroKilometro = Nothing
         Operacion.ImporteCeroKilometro = Nothing
         Operacion.NumeroOperacion = txtNumeroOperacion.ValorNumericoPorDefecto(0I)

         If bscCodigoVehiculoUsado.Selecciono Then
            Operacion.PatenteVehiculoUsado = bscCodigoVehiculoUsado.Text
         Else
            Operacion.PatenteVehiculoUsado = String.Empty
         End If
         Operacion.PrecioListaUsado = txtPrecioListaUsado.ValorNumericoPorDefecto(0D)
         Operacion.ImporteUsado = txtPrecioVentaUsado.ValorNumericoPorDefecto(0D)


         Operacion.IdTipoUnidadCeroKilometro = 0
         Operacion.IdSubTipoUnidadCeroKilometro = 0
         Operacion.CaracteristicaAdicionalCeroKilometro = String.Empty

         Operacion.LargoCeroKilometro = String.Empty
         Operacion.AltoCargaCeroKilometro = String.Empty
         Operacion.AltoPuertgaLateralCeroKilometro = String.Empty
         Operacion.ColorCarroceriaCeroKilometro = String.Empty
         Operacion.ColorZocaloCeroKilometro = String.Empty
         Operacion.ColorBaseCeroKilometro = String.Empty

         Operacion.PuertaTraseraCeroKilometro = Nothing
         Operacion.ParanteCeroKilometro = Nothing
         Operacion.PisoCeroKilometro = Nothing
         Operacion.MarcoCeroKilometro = Nothing
         Operacion.HerrajeCeroKilometro = Nothing

         Operacion.OtrasObservacionesCeroKilometro = String.Empty

      End If

      Operacion.ImporteTotalAdicionales = txtImporteTotalAdicionales.ValorNumericoPorDefecto(0D)
      Operacion.ImporteTotalCaracteristicas = txtImporteTotalCaracteristicas.ValorNumericoPorDefecto(0D)
      Operacion.ImporteTotal = txtTotalGeneral.ValorNumericoPorDefecto(0D)

      Operacion.ImportePesos = txtEfectivo.ValorNumericoPorDefecto(0D)
      Operacion.ImporteTarjetas = txtTarjetas.ValorNumericoPorDefecto(0D)
      Operacion.ImporteCheques = txtCheques.ValorNumericoPorDefecto(0D)

      Operacion.ImporteTransferencia = txtTransferenciaBancaria.ValorNumericoPorDefecto(0D)
      If Operacion.ImporteTransferencia <> 0 Then
         Operacion.FechaTransferencia = dtpFechaTransferencia.Value
         Operacion.IdCuentaBancaria = bscCodigoCuentaBancariaTransfBanc.Text.ValorNumericoPorDefecto(0I)
      Else
         Operacion.FechaTransferencia = Nothing
         Operacion.IdCuentaBancaria = 0
      End If

      MyBase.Aceptar()
   End Sub

   Protected Overrides Function ValidarDetalle() As String
      If Not radCeroKm.Checked And Not radUsado.Checked Then
         radCeroKm.Focus()
         Return "Debe seleccionar un tipo de operación"
      End If
      If cmbMarca.SelectedIndex = -1 Then
         cmbMarca.Focus()
         Return "Debe seleccionar una marca"
      End If
      If Not bscCodigoCliente.Selecciono Or Not bscCliente.Selecciono Then
         bscCodigoCliente.Focus()
         Return "Debe seleccionar un cliente"
      End If
      If radCeroKm.Checked Then
         If Not bscCodigoProducto2.Selecciono Or Not bscProducto2.Selecciono Then
            bscCodigoProducto2.Focus()
            Return "Debe seleccionar un producto"
         End If
      End If

      If txtTransferenciaBancaria.ValorNumericoPorDefecto(0D) <> 0 And
         Not bscCuentaBancariaTransfBanc.Selecciono Then
         bscCuentaBancariaTransfBanc.Focus()
         Return "Debe seleccionar una cuenta bancaria"
      End If

      If radCeroKm.Checked Then
         Dim prod = New Reglas.Productos().GetUno(bscCodigoProducto2.Text)
         If cmbMarca.ValorSeleccionado(Of Integer)() <> prod.IdMarca Then
            bscCodigoProducto2.Focus()
            Return "La marca de la operación no coincide con la marca del producto"
         End If
      End If

      Return MyBase.ValidarDetalle()
   End Function

#End Region

#Region "Eventos"
#Region "Eventos Buscadores"
   Private Sub bscCodigoCliente_BuscadorClick() Handles bscCodigoCliente.BuscadorClick
      TryCatched(
         Sub()
            _publicos.PreparaGrillaClientes2(bscCodigoCliente)
            Dim codigoCliente = bscCodigoCliente.Text.ValorNumericoPorDefecto(-1L)
            bscCodigoCliente.Datos = New Reglas.Clientes().GetFiltradoPorCodigo(codigoCliente, True, True)
         End Sub)
   End Sub
   Private Sub bscCliente_BuscadorClick() Handles bscCliente.BuscadorClick
      TryCatched(
         Sub()
            _publicos.PreparaGrillaClientes2(bscCliente)
            bscCliente.Datos = New Reglas.Clientes().GetFiltradoPorNombre(bscCliente.Text.Trim(), True)
         End Sub)
   End Sub
   Private Sub bscCliente_BuscadorSeleccion(sender As Object, e As Controles.BuscadorEventArgs) Handles bscCodigoCliente.BuscadorSeleccion, bscCliente.BuscadorSeleccion
      TryCatched(Sub() CargarDatosCliente(e.FilaDevuelta))
   End Sub


   Private Sub bscCodigoProducto2_BuscadorClick() Handles bscCodigoProducto2.BuscadorClick
      TryCatched(
         Sub()
            If bscCodigoCliente.Tag Is Nothing Or Not TypeOf (bscCodigoCliente.Tag) Is Entidades.ClienteLiviano Then
               Throw New Exception("Debe seleccionar primero el cliente")
            End If
            _publicos.PreparaGrillaProductos2(bscCodigoProducto2)
            Dim idProducto = bscCodigoProducto2.Text.Trim()
            Dim idListaPrecios = Reglas.Publicos.ListaPreciosPredeterminada
            Dim rProductos = New Reglas.Productos()
            Dim dt = rProductos.GetPorCodigo(idProducto, actual.Sucursal.Id, idListaPrecios, "VENTAS", soloCompuestos:=False, modalidad:="NORMAL",
                                             soloAlquilables:=False, Entidades.Producto.TiposOperaciones.NORMAL, publicarEn:=Nothing,
                                             esObservacion:=Nothing, permiteModificarDescripcion:=Nothing, idRubro:=0, idMarca:=cmbMarca.ValorSeleccionado(Of Integer), idCLiente:=0,
                                             soloProductosConStock:=False, soloBuscaPorIdProducto:=True, idProveedor:=0, SoloTipoCalidadCompras:=False)

            bscCodigoProducto2.Datos = dt
         End Sub)
   End Sub
   Private Sub bscProducto2_BuscadorClick() Handles bscProducto2.BuscadorClick
      TryCatched(
         Sub()
            If bscCodigoCliente.Tag Is Nothing Or Not TypeOf (bscCodigoCliente.Tag) Is Entidades.ClienteLiviano Then
               Throw New Exception("Debe seleccionar primero el cliente")
            End If
            _publicos.PreparaGrillaProductos2(bscProducto2)
            Dim idListaPrecios = Reglas.Publicos.ListaPreciosPredeterminada
            Dim rProductos = New Reglas.Productos()
            Dim dt = rProductos.GetPorNombre(bscProducto2.Text.Trim(), actual.Sucursal.Id, idListaPrecios, "VENTAS", soloCompuestos:=False,
                                             soloAlquilables:=False, Entidades.Producto.TiposOperaciones.NORMAL, publicarEn:=Nothing,
                                             esObservacion:=Nothing, permiteModificarDescripcion:=Nothing, idRubro:=0, idMarca:=cmbMarca.ValorSeleccionado(Of Integer), idCliente:=0,
                                             idProveedor:=0, soloTipoCalidadCompras:=False)
            bscProducto2.Datos = dt
         End Sub)
   End Sub
   Private Sub bscProducto2_BuscadorSeleccion(sender As Object, e As Controles.BuscadorEventArgs) Handles bscProducto2.BuscadorSeleccion, bscCodigoProducto2.BuscadorSeleccion
      TryCatched(Sub() CargarProducto(e.FilaDevuelta))
   End Sub

   Private Sub bscCodigoVehiculo_BuscadorClick() Handles bscCodigoVehiculo.BuscadorClick
      TryCatched(
         Sub()
            _publicos.PreparaGrillaVehiculos2(bscCodigoVehiculo)
            Dim idVehiculo = bscCodigoVehiculo.Text.ValorNumericoPorDefecto(0I)
            bscCodigoVehiculo.Datos = New Reglas.Vehiculos().GetAll()
         End Sub)
   End Sub
   Private Sub bscCodigoVehiculo_BuscadorSeleccion(sender As Object, e As Controles.BuscadorEventArgs) Handles bscCodigoVehiculo.BuscadorSeleccion
      TryCatched(Sub() CargarVehiculo(e.FilaDevuelta))
   End Sub

   Private Sub bscCodigoVehiculoUsado_BuscadorClick() Handles bscCodigoVehiculoUsado.BuscadorClick
      TryCatched(
         Sub()
            _publicos.PreparaGrillaVehiculos2(bscCodigoVehiculoUsado)
            bscCodigoVehiculoUsado.Datos = New Reglas.Vehiculos().GetFiltradoPorPatente(bscCodigoVehiculoUsado.Text, soloActivos:=True, conOperacionIngreso:=Entidades.Publicos.SiNoTodos.SI)
         End Sub)
   End Sub
   Private Sub bscCodigoVehiculoUsado_BuscadorSeleccion(sender As Object, e As Controles.BuscadorEventArgs) Handles bscCodigoVehiculoUsado.BuscadorSeleccion
      TryCatched(Sub() CargarVehiculoUsado(e.FilaDevuelta))
   End Sub


   Private Sub bscCodigoCuentaBancariaTransfBanc_BuscadorClick() Handles bscCodigoCuentaBancariaTransfBanc.BuscadorClick
      TryCatched(
         Sub()
            _publicos.PreparaGrillaCuentasBancarias2(bscCodigoCuentaBancariaTransfBanc)
            bscCodigoCuentaBancariaTransfBanc.Datos = New Reglas.CuentasBancarias().GetFiltradoPorCodigo(bscCodigoCuentaBancariaTransfBanc.Text.ValorNumericoPorDefecto(0I))
         End Sub)
   End Sub
   Private Sub bscCuentaBancariaTransfBanc_BuscadorClick() Handles bscCuentaBancariaTransfBanc.BuscadorClick
      TryCatched(
         Sub()
            _publicos.PreparaGrillaCuentasBancarias2(bscCuentaBancariaTransfBanc)
            bscCuentaBancariaTransfBanc.Datos = New Reglas.CuentasBancarias().GetFiltradoPorNombre(bscCuentaBancariaTransfBanc.Text.Trim(), Entidades.Moneda.Peso)
         End Sub)
   End Sub
   Private Sub bscCuentaBancariaTransfBanc_BuscadorSeleccion(sender As Object, e As Controles.BuscadorEventArgs) Handles bscCuentaBancariaTransfBanc.BuscadorSeleccion
      TryCatched(
         Sub()
            If Not e.FilaDevuelta Is Nothing Then
               bscCodigoCuentaBancariaTransfBanc.Text = e.FilaDevuelta.Cells("IdCuentaBancaria").Value.ToString()
               bscCuentaBancariaTransfBanc.Text = e.FilaDevuelta.Cells("NombreCuenta").Value.ToString()
               bscCuentaBancariaTransfBanc.Tag = e.FilaDevuelta.Cells("IdCuentaBancaria").Value.ToString()
               bscCodigoCuentaBancariaTransfBanc.Selecciono = True
               bscCuentaBancariaTransfBanc.Selecciono = True
               dtpFechaTransferencia.Select()
            End If
         End Sub)
   End Sub

#End Region

   Private Sub radCeroKm_CheckedChanged(sender As Object, e As EventArgs) Handles radCeroKm.CheckedChanged
      TryCatched(Sub() MostrarCeroKilometroUsado())
   End Sub
   Private Sub radUsado_CheckedChanged(sender As Object, e As EventArgs) Handles radUsado.CheckedChanged
      TryCatched(Sub() MostrarCeroKilometroUsado())
   End Sub
   Private Sub dtpFechaOperacion_ValueChanged(sender As Object, e As EventArgs) Handles dtpFechaOperacion.ValueChanged
      TryCatched(Sub() MostrarAnioOperacion())
   End Sub


   Private Sub txtPrecioVentaUsado_Leave(sender As Object, e As EventArgs) Handles txtPrecioVentaUsado.Leave
      TryCatched(Sub() CalculaTotalGeneral())
   End Sub
   Private Sub txtPrecioVentaUsado_KeyDown(sender As Object, e As KeyEventArgs) Handles txtPrecioVentaUsado.KeyDown
      TryCatched(
         Sub()
            If e.KeyCode = Keys.Enter Then
               btnAdicionales.Select()
            End If
         End Sub)
   End Sub

   Private Sub txtCantidadProducto_Leave(sender As Object, e As EventArgs) Handles txtCantidadProducto.Leave, txtPrecioProducto.Leave
      TryCatched(Sub() CalculaTotalGeneral())
   End Sub
   Private Sub txtCantidadProducto_KeyDown(sender As Object, e As KeyEventArgs) Handles txtCantidadProducto.KeyDown
      PresionarTab(e)
   End Sub
   Private Sub txtPrecioProducto_KeyDown(sender As Object, e As KeyEventArgs) Handles txtPrecioProducto.KeyDown
      TryCatched(
         Sub()
            If e.KeyCode = Keys.Enter Then
               btnAdicionales.Select()
            End If
         End Sub)
   End Sub



   Private Sub btnCaracteristicas_Click(sender As Object, e As EventArgs) Handles btnCaracteristicas.Click
      TryCatched(Sub() MostrarCaracteristicas())
   End Sub
   Private Sub btnAdicionales_Click(sender As Object, e As EventArgs) Handles btnAdicionales.Click
      TryCatched(Sub() MostrarAdicionales())
   End Sub


   Private Sub UcMedioPagoTarjeta1_AfterRefreshGrid(sender As Object, e As ucMedioPagoTarjeta.RefreshGridEventArgs) Handles UcMedioPagoTarjeta1.AfterRefreshGrid
      TryCatched(Sub() CalculaTotalMedioPago())
   End Sub
   Private Sub UcMedioPagoChequesTerceros1_AfterRefreshGrid(sender As Object, e As ucMedioPagoChequesTerceros.RefreshGridEventArgs) Handles UcMedioPagoChequesTerceros1.AfterRefreshGrid
      TryCatched(Sub() CalculaTotalMedioPago())
   End Sub
   Private Sub txtEfectivo_Leave(sender As Object, e As EventArgs) Handles txtEfectivo.Leave
      TryCatched(Sub() CalculaTotalMedioPago())
   End Sub
   Private Sub txtTransferenciaBancaria_Leave(sender As Object, e As EventArgs) Handles txtTransferenciaBancaria.Leave
      TryCatched(Sub() CalculaTotalMedioPago())
   End Sub
   Private Sub txtEfectivo_KeyDown(sender As Object, e As KeyEventArgs) Handles txtTransferenciaBancaria.KeyDown, txtEfectivo.KeyDown, dtpFechaTransferencia.KeyDown
      PresionarTab(e)
   End Sub

   Private Sub btnInsertarVehiculosUsados_Click(sender As Object, e As EventArgs) Handles btnInsertarVehiculosUsados.Click
      TryCatched(Sub() InsertarVehiculosUsados())
   End Sub
   Private Sub btnEditarVehiculosUsados_Click(sender As Object, e As EventArgs) Handles btnEditarVehiculosUsados.Click
      TryCatched(Sub() EditarVehiculosUsados())
   End Sub
   Private Sub btnAgregarVehiculoUsado_Click(sender As Object, e As EventArgs) Handles btnAgregarVehiculoUsado.Click
      TryCatched(Sub() AgregarVehiculosUsados())
   End Sub
   Private Sub btnEliminarVehiculosUsados_Click(sender As Object, e As EventArgs) Handles btnEliminarVehiculosUsados.Click
      TryCatched(Sub() EliminarVehiculosUsados())
   End Sub

   Private Sub ugVehiculosUsados_DoubleClickCell(sender As Object, e As DoubleClickCellEventArgs) Handles ugVehiculosUsados.DoubleClickCell
      TryCatched(Sub() EditarVehiculosUsados())
   End Sub


#Region "Eventos Links"
   Private Sub lnkProducto_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lnkProducto.LinkClicked
      TryCatched(
         Sub()
            Using pr = New ProductosDetalle(New Entidades.Producto())
               pr.StateForm = StateForm.Insertar
               pr.CierraAutomaticamente = True
               If pr.ShowDialog() = Windows.Forms.DialogResult.OK Then
                  bscCodigoProducto2.Text = pr.IdProducto
                  bscCodigoProducto2.PresionarBoton()
               End If
            End Using
         End Sub)
   End Sub
   Private Sub llbCliente_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles llbCliente.LinkClicked
      TryCatched(Sub() MostrarMasInfo())
   End Sub
   Private Function MostrarMasInfo() As DialogResult
      Dim clie As Entidades.Cliente = Nothing
      If bscCodigoCliente.Selecciono Or bscCliente.Selecciono Then
         If bscCodigoCliente.Tag Is Nothing Or TypeOf (bscCodigoCliente.Tag) Is Entidades.ClienteLiviano Then
            clie = New Reglas.Clientes().GetUno(DirectCast(bscCodigoCliente.Tag, Entidades.ClienteLiviano).IdCliente, incluirFoto:=True)
         End If
      End If
      Dim result = MasInfoCliente.MostrarMasInfo.Mostrar(clie)
      If result = Windows.Forms.DialogResult.OK Then
         bscCodigoCliente.Text = clie.CodigoCliente.ToString()
         Dim prevPermitido = bscCodigoCliente.Permitido
         bscCodigoCliente.PresionarBoton()
         bscCodigoCliente.Permitido = prevPermitido
      End If
      Return result
   End Function

#End Region

#End Region

#Region "Métodos Privados"
   Private Sub CargarDatosCliente(dr As DataGridViewRow)
      If dr IsNot Nothing Then
         Dim idCliente = Long.Parse(dr.Cells("IdCliente").Value.ToString())
         Dim cliente = New Reglas.Clientes().GetUnoLiviando(idCliente)

         bscCliente.Text = cliente.NombreCliente
         bscCodigoCliente.Text = cliente.CodigoCliente.ToString()
         bscCodigoCliente.Tag = cliente

         bscCodigoCliente.Selecciono = True
         bscCliente.Selecciono = True

         cmbCategoriaFiscal.SelectedValue = cliente.IdCategoriaFiscal

         txtCUITCliente.Text = cliente.Cuit
         cmbTipoDocCliente.Text = cliente.TipoDocCliente
         txtNroDocCliente.Text = cliente.NroDocCliente.ToString()

         txtTelefonos.Text = String.Format("{0} {1}", cliente.Telefono, cliente.Celular)

         If radCeroKm.Checked Then
            bscCodigoProducto2.Focus()
         Else

         End If

      End If
   End Sub
   Private Sub CargarProducto(dr As DataGridViewRow)
      If dr IsNot Nothing Then
         Dim producto = New Reglas.Productos().GetUno(dr.Cells("IdProducto").Value.ToString.Trim())

         bscCodigoProducto2.Text = producto.IdProducto
         bscProducto2.Text = producto.NombreProducto
         bscCodigoProducto2.Tag = producto

         bscCodigoProducto2.FilaDevuelta = dr
         bscProducto2.FilaDevuelta = dr

         bscCodigoProducto2.Selecciono = True
         bscProducto2.Selecciono = True

         txtCantidadProducto.SetValor(1)

         'Dim cliente = DirectCast(bscCodigoCliente.Tag, Entidades.ClienteLiviano)
         Dim _nroOferta As Integer

         Dim p = FacturacionAyudantes.GetPrecio(Decimal.Parse(dr.Cells("PrecioVentaSinIVA").Value.ToString()),
                                                Decimal.Parse(dr.Cells("PrecioVentaConIVA").Value.ToString()),
                                                producto, New Entidades.Cliente(), dtpFechaOperacion.Value, _nroOferta, _categoriaFiscalEmpresa, codigoBarrasCompleto:=String.Empty,
                                                cotizacionDolar:=txtCotizacionDolar.ValorNumericoPorDefecto(1D), Entidades.Producto.Modalidades.NORMAL,
                                                valorRedondeo:=Reglas.Publicos.Facturacion.Redondeo.FacturacionDecimalesRedondeoEnPrecio,
                                                obtienePrecioConIVA:=True, FormaDePago:=Nothing)

         txtPrecioProducto.SetValor(p)

         CalculaTotalGeneral()

         txtPrecioProducto.Select()

      End If
   End Sub
   Private Sub CargarVehiculo(dr As DataGridViewRow)
      If dr IsNot Nothing Then
         Dim vehiculo = New Reglas.Vehiculos().GetUno(dr.Cells("PatenteVehiculo").Value.ToString())

         If Operacion.VehiculosPago.Any(Function(v) v.PatenteVehiculo = vehiculo.PatenteVehiculo) Then
            Throw New Exception(String.Format("El vehículo con Patente {0} ya se encuentra en la operación", vehiculo.PatenteVehiculo))
         End If
         Operacion.VehiculosPago.Add(vehiculo)
         ugVehiculosUsados.Rows.Refresh(RefreshRow.FireInitializeRow)
         CalculaTotalMedioPago()
      End If
   End Sub
   Private Sub CargarVehiculoUsado(dr As DataGridViewRow)
      If dr IsNot Nothing Then
         Dim vehiculo = New Reglas.Vehiculos().GetUno(dr.Cells("PatenteVehiculo").Value.ToString())

         If Operacion.VehiculosPago.Any(Function(v) v.PatenteVehiculo = vehiculo.PatenteVehiculo) Then
            Throw New Exception(String.Format("El vehículo que está vendiendo con Patente {0} se encuentra como pago de la operación", vehiculo.PatenteVehiculo))
         End If

         bscCodigoVehiculoUsado.Text = vehiculo.PatenteVehiculo
         bscCodigoVehiculoUsado.Tag = vehiculo
         txtMarcaUsado.Text = vehiculo.DescripMarcaVehiculo
         txtModeloUsado.Text = vehiculo.DescripModeloVehiculo

         If Not _onLoad Then
            txtPrecioListaUsado.SetValor(vehiculo.PrecioLista)
         End If

         If vehiculo.IdMarcaOperacionIngreso.HasValue Then
            cmbMarca.SelectedValue = vehiculo.IdMarcaOperacionIngreso.Value
         End If
         If vehiculo.AnioOperacionIngreso.HasValue Then
            txtAnioOperacion.SetValor(vehiculo.AnioOperacionIngreso.Value)
         End If
         If vehiculo.NumeroOperacionIngreso.HasValue Then
            txtNumeroOperacion.SetValor(vehiculo.NumeroOperacionIngreso.Value)
         End If
         'If vehiculo.SecuenciaOperacionIngreso.HasValue Then
         '   txtSecuenciaOperacion.SetValor(vehiculo.SecuenciaOperacionIngreso.Value)
         'End If

         CalculaTotalGeneral()
      End If
   End Sub
   Private Sub MostrarCeroKilometroUsado()
      If radCeroKm.Checked Then
         If Not tbcUnidadVendida.TabPages.Contains(tbp0Km) Then
            tbcUnidadVendida.TabPages.Add(tbp0Km)
         End If
         If tbcUnidadVendida.TabPages.Contains(tbpUsado) Then
            tbcUnidadVendida.TabPages.Remove(tbpUsado)
         End If
      ElseIf radUsado.Checked Then
         If Not tbcUnidadVendida.TabPages.Contains(tbpUsado) Then
            tbcUnidadVendida.TabPages.Add(tbpUsado)
         End If
         If tbcUnidadVendida.TabPages.Contains(tbp0Km) Then
            tbcUnidadVendida.TabPages.Remove(tbp0Km)
         End If
      Else
         If tbcUnidadVendida.TabPages.Contains(tbpUsado) Then
            tbcUnidadVendida.TabPages.Remove(tbpUsado)
         End If
         If tbcUnidadVendida.TabPages.Contains(tbp0Km) Then
            tbcUnidadVendida.TabPages.Remove(tbp0Km)
         End If
      End If

      btnAdicionales.Visible = radCeroKm.Checked
      txtImporteTotalAdicionales.Visible = radCeroKm.Checked
      txtImporteTotalCaracteristicas.Visible = radCeroKm.Checked

      cmbMarca.Enabled = radCeroKm.Checked AndAlso StateForm = StateForm.Insertar
      MostrarAnioOperacion()

   End Sub
   Private Sub MostrarAnioOperacion()
      If radCeroKm.Checked Then
         txtAnioOperacion.Text = dtpFechaOperacion.Value.Year.ToString()
      Else
         txtAnioOperacion.Text = Operacion.AnioOperacion.ToString()
      End If
   End Sub

   Private Sub CalcularImporteVehiculo()
      txtTotalProducto.SetValor(txtCantidadProducto.ValorNumericoPorDefecto(0D) * txtPrecioProducto.ValorNumericoPorDefecto(0D))
   End Sub
   Private Sub CalcularImporteAdicionales()
      txtImporteTotalAdicionales.SetValor(If(radCeroKm.Checked, Operacion.Adicionales.SumSecure(Function(a) a.PrecioAdicional).IfNull(), 0D))
   End Sub
   Private Sub CalcularImporteCaracteristicas()
      txtImporteTotalCaracteristicas.SetValor(If(radCeroKm.Checked, 0D, 0D))
   End Sub
   Private Sub CalculaTotalGeneral()
      CalcularImporteVehiculo()
      CalcularImporteCaracteristicas()
      CalcularImporteAdicionales()
      txtTotalGeneral.SetValor(If(radCeroKm.Checked, txtImporteTotalCaracteristicas.ValorNumericoPorDefecto(0D), txtPrecioVentaUsado.ValorNumericoPorDefecto(0D)) +
                               txtImporteTotalAdicionales.ValorNumericoPorDefecto(0D) + txtTotalProducto.ValorNumericoPorDefecto(0D))
      CalculaTotalMedioPago()
   End Sub

   Private Sub CalculaTotalTarjetas()
      txtTarjetas.SetValor(UcMedioPagoTarjeta1.Tarjetas.SumSecure(Function(t) t.Monto).IfNull())
   End Sub
   Private Sub CalculaTotalCheques()
      txtCheques.SetValor(UcMedioPagoChequesTerceros1.Cheques.SumSecure(Function(t) t.Importe).IfNull())
   End Sub
   Private Sub CalculaTotalVehiculosUsados()
      txtUsados.SetValor(Operacion.VehiculosPago.SumSecure(Function(v) v.PrecioCompra).IfNull())
   End Sub
   Public Sub CalculaTotalMedioPago()
      CalculaTotalTarjetas()
      CalculaTotalCheques()
      CalculaTotalVehiculosUsados()
      txtTotalPago.SetValor(txtEfectivo.ValorNumericoPorDefecto(0D) + txtTransferenciaBancaria.ValorNumericoPorDefecto(0D) +
                            txtCheques.ValorNumericoPorDefecto(0D) + txtTarjetas.ValorNumericoPorDefecto(0D) +
                            txtUsados.ValorNumericoPorDefecto(0D))

      txtDiferencia.SetValor(txtTotalGeneral.ValorNumericoPorDefecto(0D) - txtTotalPago.ValorNumericoPorDefecto(0D))
   End Sub

   Private Sub InsertarVehiculosUsados()
      Using frm = New VehiculosDetalle(New Entidades.Vehiculo())
         frm.IdFuncion = IdFuncion
         frm.StateForm = StateForm.Insertar
         frm.GuardaNuevoEnBase = False
         frm.CierraAutomaticamente = True

         If frm.ShowDialog(Me) = DialogResult.OK Then
            Operacion.VehiculosPago.Add(frm.Vehiculo)
            'Operacion.VehiculosPago.Add(New Reglas.Vehiculos().GetUno(frm.Vehiculo.PatenteVehiculo))
            ugVehiculosUsados.Rows.Refresh(RefreshRow.FireInitializeRow)
            CalculaTotalMedioPago()
         End If
      End Using
   End Sub
   Private Sub EditarVehiculosUsados()
      Dim dr = ugVehiculosUsados.FilaSeleccionada(Of Entidades.Vehiculo)
      If dr IsNot Nothing Then
         ugVehiculosUsados.PerformAction(UltraGridAction.ExitEditMode)
         ugVehiculosUsados.ActiveRow.CancelUpdate()
         Using frm = New VehiculosDetalle(dr)
            frm.IdFuncion = IdFuncion
            frm.StateForm = StateForm.Actualizar
            frm.GuardaNuevoEnBase = False
            frm.CierraAutomaticamente = True

            If frm.ShowDialog(Me) = DialogResult.OK Then
               'Operacion.VehiculosPago.Add(frm.Vehiculo)
               'Operacion.VehiculosPago.Add(New Reglas.Vehiculos().GetUno(frm.Vehiculo.PatenteVehiculo))
               ugVehiculosUsados.Rows.Refresh(RefreshRow.FireInitializeRow)
               CalculaTotalMedioPago()
            End If
         End Using
      End If
   End Sub
   Private Sub AgregarVehiculosUsados()
      bscCodigoVehiculo.Visible = True
      bscCodigoVehiculo.PresionarBoton()
      bscCodigoVehiculo.Visible = False
      CalculaTotalMedioPago()
   End Sub
   Private Sub EliminarVehiculosUsados()
      Dim dr = ugVehiculosUsados.FilaSeleccionada(Of Entidades.Vehiculo)()
      If dr IsNot Nothing Then
         If ShowPregunta(String.Format("¿Desea eliminar el vehículo con patente {0}?", dr.PatenteVehiculo)) = DialogResult.Yes Then
            Operacion.VehiculosPago.Remove(dr)
            ugVehiculosUsados.Rows.Refresh(RefreshRow.FireInitializeRow)
            CalculaTotalMedioPago()
         End If
      Else
         Throw New Exception("Seleccione un vehículo para eliminar")
      End If
   End Sub


   Private Sub MostrarCaracteristicas()
      If radCeroKm.Checked Then
         MostrarCaracteristicasCeroKilometro()
      ElseIf radUsado.Checked Then
         MostrarCaracteristicasUsado()
      End If
   End Sub
   Private Sub MostrarCaracteristicasCeroKilometro()
      Using frm = New ConcesionarioOperacionesCaracteristicas()
         If frm.ShowDialog(Me, Operacion) = DialogResult.OK Then
            CalculaTotalGeneral()
         End If
      End Using
   End Sub
   Private Sub MostrarCaracteristicasUsado()
      If bscCodigoVehiculoUsado.Selecciono AndAlso Not String.IsNullOrWhiteSpace(bscCodigoVehiculoUsado.Text) Then
         Dim v = New Reglas.Vehiculos().GetUno(bscCodigoVehiculoUsado.Text)
         Using frm = New VehiculosDetalle(v)
            frm.IdFuncion = IdFuncion
            frm.StateForm = StateForm.Consultar
            frm.ShowDialog(Me)
         End Using
      End If
   End Sub
   Private Sub MostrarAdicionales()
      Using frm = New ConcesionarioOperacionesAdicionales()
         If frm.ShowDialog(Me, Operacion) = DialogResult.OK Then
            CalculaTotalGeneral()
         End If
      End Using
   End Sub

#End Region

End Class