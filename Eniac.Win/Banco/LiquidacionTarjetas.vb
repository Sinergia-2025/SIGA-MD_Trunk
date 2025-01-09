Public Class LiquidacionTarjetas

#Region "Campos"

   ''Private _ComprobantesGrilla As New List(Of Entidades.CuentaCorrienteProvPago)
   ''Private _chequesPropios As List(Of Entidades.Cheque)
   ''Private _chequesTerceros As List(Of Entidades.Cheque)
   'Private _estado As Estados
   Private _publicos As Publicos
   Private _proveedorGrilla As Entidades.Proveedor
   Private _saldoCuota As Decimal = 0
   ''Private _Suc As Integer = 0
   Private _idCaja As Integer = 0
   Private _titChequesPropios As Dictionary(Of String, String)
   Private _tipoComprobante As String = "LIQUIDATARJETA"
   Private _eDepositosCuentasBancos As List(Of Entidades.DepositosCuentasBancos)
   Private _dtCupones As DataTable
   Private _idCuentaBanco As Integer
   Private _finalizoCargaDePantalla As Boolean
   Private _totalImportesCtaBancos As Decimal = 0 '-.PE-32070.-

#End Region

#Region "Overrides"
   Protected Overrides Sub OnLoad(e As EventArgs)
      MyBase.OnLoad(e)
      TryCatched(
         Sub()
            _publicos = New Publicos()

            _publicos.CargaComboCajas(cmbCajas, actual.Sucursal.Id, miraUsuario:=True, miraPC:=True, cajasModificables:=True)

            ugDetalleCupones.AgregarFiltroEnLinea({"Banco", "NumeroCupon", "NombreCliente"})

            '# Tarjetas
            _publicos.CargaComboTarjetasE(cmbTarjeta, activas:=True)
            cmbTarjeta.SelectedIndex = -1

            Nuevo()

            _finalizoCargaDePantalla = True
         End Sub)
   End Sub
   Protected Overrides Function ProcessCmdKey(ByRef msg As Message, keyData As Keys) As Boolean
      If keyData = Keys.F4 Then
         tsbGrabar.PerformClick()
      Else
         Return MyBase.ProcessCmdKey(msg, keyData)
      End If
      Return True
   End Function
#End Region

#Region "Eventos"

#Region "Eventos Toolbar"
   Private Sub tsbNuevo_Click(sender As Object, e As EventArgs) Handles tsbNuevo.Click
      TryCatched(Sub() Nuevo())
   End Sub
   Private Sub tsbGrabar_Click(sender As Object, e As EventArgs) Handles tsbGrabar.Click
      TryCatched(Sub() GrabarComprobante())
   End Sub
   Private Sub tsbSalir_Click(sender As Object, e As EventArgs) Handles tsbSalir.Click
      TryCatched(Sub() Close())
   End Sub
#End Region

#Region "Eventos Cabecera"
   Private Sub cmbTarjeta_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbTarjeta.SelectedIndexChanged
      TryCatched(
         Sub()
            If _finalizoCargaDePantalla Then
               Dim tarj = cmbTarjeta.ItemSeleccionado(Of Entidades.Tarjeta)
               If tarj IsNot Nothing Then
                  Dim idCuentaBancaria = cmbTarjeta.ItemSeleccionado(Of Entidades.Tarjeta).CuentaBancaria.idCuentaContable
                  If idCuentaBancaria <> 0 Then
                     bscCodigoCuentaBancariaDestino.Text = idCuentaBancaria.ToString()
                     bscCodigoCuentaBancariaDestino.PresionarBoton()
                  Else
                     bscCuentaBancariaDestino.Text = ""
                     bscCodigoCuentaBancariaDestino.Selecciono = Nothing
                  End If
               End If
            End If
         End Sub)
   End Sub
   Private Sub bscCuentaBancariaDestino_BuscadorClick() Handles bscCuentaBancariaDestino.BuscadorClick
      TryCatched(
         Sub()
            _publicos.PreparaGrillaCuentasBancarias2(bscCuentaBancariaDestino)
            bscCuentaBancariaDestino.Datos = New Reglas.CuentasBancarias().GetFiltradoPorNombre(bscCuentaBancariaDestino.Text.Trim())
         End Sub)
   End Sub
   Private Sub bscCodigoCuentaBancariaDestino_BuscadorClick() Handles bscCodigoCuentaBancariaDestino.BuscadorClick
      TryCatched(
         Sub()
            _publicos.PreparaGrillaCuentasBancarias(bscCodigoCuentaBancariaDestino)
            bscCodigoCuentaBancariaDestino.Datos = New Reglas.CuentasBancarias().GetFiltradoPorCodigo(bscCodigoCuentaBancariaDestino.Text.ValorNumericoPorDefecto(0I))
         End Sub)
   End Sub
   Private Sub bscCuentaBancariaDestino_BuscadorSeleccion(sender As Object, e As Controles.BuscadorEventArgs) Handles bscCuentaBancariaDestino.BuscadorSeleccion, bscCodigoCuentaBancariaDestino.BuscadorSeleccion
      TryCatched(
         Sub()
            If Not e.FilaDevuelta Is Nothing Then
               CargarDatosCuentaBancariaDestino(e.FilaDevuelta)
               VerificarGrabarImprimir()
            End If
         End Sub)
   End Sub
#End Region

#Region "Eventos Solapa Cupones"
   Private Sub btnLimpiarCupones_Click(sender As Object, e As EventArgs) Handles btnLimpiarCupones.Click
      TryCatched(Sub() LimpiarSolapaCuponesTarjeta())
   End Sub
   Private Sub btnBuscarCupones_Click(sender As Object, e As EventArgs) Handles btnBuscarCupones.Click
      If Not ValidarCupones() Then Exit Sub
      TryCatched(
         Sub()
            Dim fechaDesde = dtpFechaDesdeCupones.Value
            Dim fechaHasta = dtpFechaHastaCupones.Value
            Dim idTarjeta = cmbTarjeta.ValorSeleccionado(Of Integer)()
            Dim idCaja = cmbCajas.ValorSeleccionado(Of Integer)()

            Dim rTarjetasCupones = New Reglas.TarjetasCupones()
            _dtCupones = rTarjetasCupones.GetInformeCupones(
                                 {actual.Sucursal},
                                 idTarjetaCupon:=0,
                                 fechaIngresoDesde:=fechaDesde, fechaIngresoHasta:=fechaHasta,
                                 idEstadoTarjeta:=Entidades.TarjetaCupon.Estados.ENCARTERA.ToString(),
                                 idTarjeta:=idTarjeta, idCaja:=idCaja,
                                 fechaLiquidacionDesde:=Nothing, fechaLiquidacionHasta:=Nothing, fechaEnCarteraAl:=Nothing,
                                 numeroCupon:=0, numeroLote:=0, idBanco:=0, idCliente:=0, idSituacion:=0)
            '# Agrego la columna "Selecciono"
            _dtCupones.Columns.Add("Selecciono", GetType(Boolean))
            _dtCupones.Columns.Add("Rechazados", GetType(Boolean))

            _dtCupones.AsEnumerable().All(
               Function(dr)
                  dr("Selecciono") = False
                  dr("Rechazados") = False
                  Return True
               End Function)

            ugDetalleCupones.DataSource = _dtCupones
            chbTodosCupones.Enabled = ugDetalleCupones.Rows.Count > 0

            If _dtCupones.Rows.Count = 0 Then
               ShowMessage("NO hay registros que cumplan con la selección !!!")
            End If
         End Sub)
   End Sub
   Private Sub btnAgregarCupon_Click(sender As Object, e As EventArgs) Handles btnAgregarCupon.Click

   End Sub

   Private Sub btnDesconocimientoCupon_Click(sender As Object, e As EventArgs) Handles btnDesconocimientoCupon.Click

   End Sub
   Private Sub chbTodosCupones_CheckedChanged(sender As Object, e As EventArgs) Handles chbTodosCupones.CheckedChanged
      TryCatched(
         Sub()
            DirectCast(ugDetalleCupones.DataSource, DataTable).AsEnumerable().ToList().ForEach(Sub(dr) dr("Selecciono") = chbTodosCupones.Checked)
            '# Calculo el total de los cupones
            CalcularTotales()
            VerificarGrabarImprimir()
         End Sub)
   End Sub

   Private Sub ugDetalleCupones_AfterRowActivate(sender As Object, e As EventArgs) Handles ugDetalleCupones.AfterRowActivate
      TryCatched(
         Sub()
            If ugDetalleCupones.Rows.Count = 0 Then Exit Sub
            '# Calculo el total de los cupones
            CalcularTotales()
            VerificarGrabarImprimir()
         End Sub)
   End Sub
   Private Sub ugDetalleCupones_CellChange(sender As Object, e As CellEventArgs) Handles ugDetalleCupones.CellChange
      TryCatched(
         Sub()
            ugDetalleCupones.UpdateData()
            If ugDetalleCupones.Rows.Count = 0 Then Exit Sub

            ' Calculo total de ajustes realizados en Cuentas de Bancos
            CalcularTotales()

            VerificarGrabarImprimir()
         End Sub)
   End Sub
   Private Sub ugCuentasBancos_DoubleClickCell(sender As Object, e As DoubleClickCellEventArgs) Handles ugCuentasBancos.DoubleClickCell
      TryCatched(
         Sub()
            If ugCuentasBancos.Rows.Count = 0 Then Exit Sub

            Dim cuentaBanco = ugCuentasBancos.FilaSeleccionada(Of Entidades.DepositosCuentasBancos)(e.Cell.Row)
            If cuentaBanco IsNot Nothing Then
               bscCuentaBancoCodigo.Text = cuentaBanco.IdCuentaBanco.ToString()
               _idCuentaBanco = cuentaBanco.IdCuentaBanco
               bscCuentaBancoNombre.Text = cuentaBanco.NombreCuentaBanco
               txtImporte.Text = cuentaBanco.Importe.ToString()
               If cuentaBanco.IdTipoCuenta = "E" Then
                  optEgreso.Checked = True
                  optIngreso.Checked = Not optEgreso.Checked
               Else
                  optEgreso.Checked = False
                  optIngreso.Checked = Not optEgreso.Checked
               End If
               txtObservacionCuentaBanco.Text = cuentaBanco.Observacion

               bscCuentaBancoCodigo.Enabled = False
               bscCuentaBancoNombre.Enabled = False
               bscCuentaBancoCodigo.Selecciono = True

               '# Elimino la CB de la grilla
               _eDepositosCuentasBancos.Remove(cuentaBanco)
               ugCuentasBancos.Rows.Refresh(RefreshRow.ReloadData)

               txtImporte.Focus()
            End If
         End Sub)
   End Sub
#End Region

#Region "Eventos Solapa Cuentas Bancos"
   Private Sub btnLimpiarCB_Click(sender As Object, e As EventArgs) Handles btnLimpiarCB.Click
      TryCatched(
         Sub()
            bscCuentaBancoCodigo.Text = ""
            bscCuentaBancoNombre.Text = ""
            bscCuentaBancoCodigo.Enabled = True
            bscCuentaBancoNombre.Enabled = True
            txtImporte.Text = "0.00"
            optEgreso.Checked = False
            optIngreso.Checked = False
            txtObservacionCuentaBanco.Clear()

            bscCuentaBancoCodigo.FilaDevuelta = Nothing
            bscCuentaBancoNombre.FilaDevuelta = Nothing
            bscCuentaBancoCodigo.Focus()

            FormatearGrillaCuentasBancos()
         End Sub)
   End Sub
   Private Sub bscCuentaBancoCodigo_BuscadorClick() Handles bscCuentaBancoCodigo.BuscadorClick
      TryCatched(
         Sub()
            _publicos.PreparaGrillaCuentasDeBancos2(bscCuentaBancoCodigo)
            bscCuentaBancoCodigo.Datos = New Reglas.CuentasBancos().GetTodosPorCodigo(bscCuentaBancoCodigo.Text.Trim())
         End Sub)
   End Sub
   Private Sub bscCuentaBancoNombre_BuscadorClick() Handles bscCuentaBancoNombre.BuscadorClick
      TryCatched(
         Sub()
            _publicos.PreparaGrillaCuentasDeBancos2(bscCuentaBancoNombre)
            bscCuentaBancoNombre.Datos = New Reglas.CuentasBancos().GetTodosPorNombre(bscCuentaBancoNombre.Text.Trim())
         End Sub)
   End Sub
   Private Sub bscCuentaBancoNombre_BuscadorSeleccion(sender As Object, e As Controles.BuscadorEventArgs) Handles bscCuentaBancoNombre.BuscadorSeleccion, bscCuentaBancoCodigo.BuscadorSeleccion
      TryCatched(
         Sub()
            If Not bscCuentaBancoNombre.FilaDevuelta Is Nothing Then
               bscCuentaBancoNombre.Text = bscCuentaBancoNombre.FilaDevuelta.Cells(Entidades.CuentaBanco.Columnas.NombreCuentaBanco.ToString()).Value.ToString()
               bscCuentaBancoCodigo.Text = bscCuentaBancoNombre.FilaDevuelta.Cells(Entidades.CuentaBanco.Columnas.IdCuentaBanco.ToString()).Value.ToString()
               _idCuentaBanco = Integer.Parse(bscCuentaBancoNombre.FilaDevuelta.Cells(Entidades.CuentaBanco.Columnas.IdCuentaBanco.ToString()).Value.ToString())
               Dim tipoCuenta As String = bscCuentaBancoNombre.FilaDevuelta.Cells(Entidades.CuentaBanco.Columnas.IdTipoCuenta.ToString()).Value.ToString()

               '# Tipo de Cuenta
               If tipoCuenta = "Ingreso" Then
                  optIngreso.Checked = True
                  optEgreso.Checked = False
               Else
                  optIngreso.Checked = False
                  optEgreso.Checked = True
               End If

               bscCuentaBancoCodigo.Enabled = False
               bscCuentaBancoNombre.Enabled = False

               txtImporte.Focus()
            End If
         End Sub)
   End Sub
   Private Sub btnInsertarCB_Click(sender As Object, e As EventArgs) Handles btnInsertarCB.Click
      TryCatched(
         Sub()
            If Not bscCuentaBancoCodigo.Selecciono And Not bscCuentaBancoNombre.Selecciono Then Exit Sub

            If txtImporte.ValorNumericoPorDefecto(0D) = 0 Then
               txtImporte.Focus()
               ShowMessage("El importe ingresado no puede ser $0.00.")
               Exit Sub
            End If

            '# Valido que la Cuenta Banco no esté en la grilla
            If _eDepositosCuentasBancos IsNot Nothing Then
               If _eDepositosCuentasBancos.Exists(Function(x) x.IdCuentaBanco = _idCuentaBanco) Then
                  btnLimpiarCupones.Focus()
                  ShowMessage("Esta Cuenta Banco ya fué agregada.")
                  Exit Sub
               End If
            End If

            '# Armo mis variables a utilizar
            Dim importe = Decimal.Parse(txtImporte.Text)
            Dim tipoCuenta = If(optIngreso.Checked, "I", "E")
            Dim nombreCuenta = bscCuentaBancoNombre.Text
            Dim observacion = txtObservacionCuentaBanco.Text

            '# Agrego la CuentaBanco
            If _eDepositosCuentasBancos Is Nothing Then
               _eDepositosCuentasBancos = New List(Of Entidades.DepositosCuentasBancos)()
               ugCuentasBancos.DataSource = _eDepositosCuentasBancos
            End If
            _eDepositosCuentasBancos.Add(New Entidades.DepositosCuentasBancos() With
                                             {
                                                .IdCuentaBanco = _idCuentaBanco,
                                                .NombreCuentaBanco = nombreCuenta,
                                                .IdTipoCuenta = tipoCuenta,
                                                .Importe = importe,
                                                .Observacion = observacion
                                             })
            '# Recargo el Source de la grilla
            ugCuentasBancos.Rows.Refresh(RefreshRow.ReloadData)

            btnLimpiarCB_Click(sender, e)
         End Sub)
   End Sub
   Private Sub btnEliminarCB_Click(sender As Object, e As EventArgs) Handles btnEliminarCB.Click
      TryCatched(
         Sub()
            If ugCuentasBancos.Rows.Count = 0 Then Exit Sub

            Dim cuentaBanco = ugCuentasBancos.FilaSeleccionada(Of Entidades.DepositosCuentasBancos)()
            If cuentaBanco IsNot Nothing Then
               _eDepositosCuentasBancos.Remove(cuentaBanco)
               ugCuentasBancos.Rows.Refresh(RefreshRow.ReloadData)
            End If
         End Sub)
   End Sub

#End Region


   ''Private Sub txtTotalTarjeta_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles txtTotalTarjeta.KeyDown
   ''   TryCatched(Sub() PresionarTab(e))
   ''End Sub

#End Region

#Region "Metodos"
   Private Sub Nuevo()
      bscCuentaBancariaDestino.Text = ""
      bscCodigoCuentaBancariaDestino.Text = ""
      bscCuentaBancariaDestino.FilaDevuelta = Nothing

      '      _estado = Estados.Insercion
      txtObservacion.Clear()

      dtpFecha.Value = Date.Today
      dtpFechaAplicacion.Value = Date.Today
      txtTotalTarjeta.SetValor(0)
      txtTotal.SetValor(0)

      '# Si la pantalla es Liquidaciones de Tarjeta preparo la pantalla como al inicio. Caso contrario mantengo el comportamiento estándar.
      LimpiarSolapaCuponesTarjeta()
      '# Bancos
      LimpiarSolapaBancos()

      tsbGrabar.Enabled = False
   End Sub
   Private Sub VerificarGrabarImprimir()
      tsbGrabar.Enabled = (bscCuentaBancariaDestino.Selecciono Or bscCodigoCuentaBancariaDestino.Selecciono) And txtTotal.ValorNumericoPorDefecto(0D) > 0
   End Sub
   Private Sub GrabarComprobante()

      If ValidarDeposito() Then

         tsbGrabar.Enabled = False

         Dim oReglasDepositos = New Reglas.Depositos()

         Dim oDeposito = New Entidades.Deposito()

         With oDeposito

            .CuentaBancaria = New Reglas.CuentasBancarias().GetUna(Integer.Parse(Me.bscCuentaBancariaDestino.FilaDevuelta.Cells("IdCuentaBancaria").Value.ToString()))

            .Fecha = dtpFecha.Value
            .FechaAplicado = dtpFechaAplicacion.Value

            ''.UsoFechaCheque = optFechaCheque.Checked

            'cargo valores del comprobante
            .ImporteTotal = Decimal.Parse(txtTotal.Text)

            .Observacion = txtObservacion.Text

            '# Si el TipoComprobante es LIQUIDATARJETA, ImporteTarjetas = ImporteTotal (Importe total de los cupones liquidados)
            .ImporteTarjetas = txtTotalTarjeta.ValorNumericoPorDefecto(0D)

            '' 'cargo los Cheques Emitidos
            ''.ChequesPropios = Me._chequesPropios

            '' 'cargo los cheques de terceros

            ''.ChequesTerceros = Me._chequesTerceros

            .CotizacionDolar = txtCotizacionDolar.ValorNumericoPorDefecto(0D)

            'cargo datos generales del comprobante
            .IdSucursal = actual.Sucursal.Id
            .IdCaja = Int32.Parse(Me.cmbCajas.SelectedValue.ToString())
            .NombreCaja = Me.cmbCajas.Text
            .Usuario = actual.Nombre
            .IdEstado = "NORMAL"

            '# Posibles comprobantes: LIQUIDATARJETA / DEPOSITO
            .TipoComprobante = New Reglas.TiposComprobantes().GetUno(_tipoComprobante)

            '# Proceso la información de Cupones antes de guardarla en la propiedad.
            '# En caso que no se esté usando la pantalla de Liquidaciones de Tarjetas, la propiedad queda vacia para que luego al visualizar el reporte, éste se visualice correctamente.
            Dim dtCupones As SistemaDataSet.TarjetasCuponesDataTable = New SistemaDataSet.TarjetasCuponesDataTable
            Dim drCupones As SistemaDataSet.TarjetasCuponesRow
            If .TipoComprobante.IdTipoComprobante = "LIQUIDATARJETA" Then
               For Each e As DataRow In DirectCast(Me.ugDetalleCupones.DataSource, DataTable).Rows
                  If e("Selecciono").ToString() = Boolean.TrueString Then
                     drCupones = dtCupones.NewTarjetasCuponesRow

                     drCupones.IdTarjetaCupon = Integer.Parse(e(Entidades.DepositosTarjetasCupones.Columnas.IdTarjetaCupon.ToString()).ToString())
                     drCupones.NombreTarjeta = e(Entidades.Tarjeta.Columnas.NombreTarjeta.ToString()).ToString()
                     drCupones.NombreBanco = e("NombreBanco").ToString()
                     drCupones.IdTarjeta = Integer.Parse(e(Entidades.TarjetaCupon.Columnas.IdTarjeta.ToString()).ToString())
                     drCupones.IdBanco = Integer.Parse(e(Entidades.TarjetaCupon.Columnas.IdBanco.ToString()).ToString())
                     drCupones.FechaEmision = Date.Parse(e(Entidades.TarjetaCupon.Columnas.FechaEmision.ToString()).ToString())
                     drCupones.NumeroCupon = Integer.Parse(e(Entidades.TarjetaCupon.Columnas.NumeroCupon.ToString()).ToString())
                     drCupones.NumeroLote = Integer.Parse(e(Entidades.TarjetaCupon.Columnas.NumeroLote.ToString()).ToString())
                     drCupones.Cuotas = Integer.Parse(e(Entidades.TarjetaCupon.Columnas.Cuotas.ToString()).ToString())
                     drCupones.Monto = Decimal.Parse(e(Entidades.TarjetaCupon.Columnas.Monto.ToString()).ToString())
                     drCupones.CodigoCliente = Long.Parse(e(Entidades.Cliente.Columnas.IdCliente.ToString()).ToString())
                     drCupones.NombreCliente = e(Entidades.Cliente.Columnas.NombreCliente.ToString()).ToString()

                     dtCupones.Rows.Add(drCupones)
                  End If
               Next
            End If
            .TarjetasCupones = dtCupones

            '# Cuentas Banco asociadas
            .CuentasBancos = If(_eDepositosCuentasBancos IsNot Nothing, _eDepositosCuentasBancos, Nothing)
         End With

         oReglasDepositos.Insertar(oDeposito)

         MessageBox.Show("Se ingresó la Liquidación Número" & oDeposito.NumeroDeposito, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)

         Dim di = New DepositosImprimir()
         di.ImprimirDeposito(oDeposito)

         Nuevo()

      End If

   End Sub


#Region "Metodos Calcula Totales"
   Private Sub CalcularTotalCupones()
      Dim pago = DirectCast(ugDetalleCupones.DataSource, DataTable).AsEnumerable().
                     Where(Function(dr) dr.Field(Of Boolean)("Selecciono")).
                     SumSecure(Function(dr) dr.Field(Of Decimal)(Entidades.TarjetaCupon.Columnas.Monto.ToString())).IfNull()

      Dim rech = DirectCast(ugDetalleCupones.DataSource, DataTable).AsEnumerable().
                     Where(Function(dr) dr.Field(Of Boolean)("Rechazados") And dr.Field(Of String)(Entidades.TarjetaCupon.Columnas.IdEstadoTarjeta.ToString()) <> Entidades.TarjetaCupon.Estados.LIQUIDADO.ToString()).
                     SumSecure(Function(dr) dr.Field(Of Decimal)(Entidades.TarjetaCupon.Columnas.Monto.ToString())).IfNull()

      Dim desc = DirectCast(ugDetalleCupones.DataSource, DataTable).AsEnumerable().
                     Where(Function(dr) dr.Field(Of Boolean)("Rechazados") And dr.Field(Of String)(Entidades.TarjetaCupon.Columnas.IdEstadoTarjeta.ToString()) <> Entidades.TarjetaCupon.Estados.LIQUIDADO.ToString()).
                     SumSecure(Function(dr) dr.Field(Of Decimal)(Entidades.TarjetaCupon.Columnas.Monto.ToString())).IfNull()

      txtCuponesCobrados.SetValor(pago)
      txtCuponesRechazados.SetValor(rech)
      txtCuponesDesconocidos.SetValor(desc)

      txtTotalCupones.SetValor(pago + rech + desc)
   End Sub
   Private Sub CalcularTotalCuentasDeBancos() '-.PE-32070.-
      Dim col = DirectCast(ugDetalleCupones.DataSource, List(Of Entidades.DepositosCuentasBancos))
      Dim ingreso = col.Where(Function(dr) dr.IdTipoCuenta = "I").SumSecure(Function(dr) dr.Importe).IfNull()
      Dim egreso = col.Where(Function(dr) dr.IdTipoCuenta = "E").SumSecure(Function(dr) dr.Importe).IfNull() * -1

      txtCuentasBancoIngresos.SetValor(ingreso)
      txtCuentasBancoEgresos.SetValor(egreso)

      txtTotalCuentasBanco.SetValor(ingreso + egreso)
   End Sub
   Private Sub CalcularTotalCompras()

   End Sub
   Private Sub CalcularTotales()
      CalcularTotalCupones()
      CalcularTotalCuentasDeBancos()
      CalcularTotalCompras()

      txtTotalGeneral.SetValor(txtTotalCupones.ValorNumericoPorDefecto(0D) + txtTotalCuentasBanco.ValorNumericoPorDefecto(0D) + txtTotalCompra.ValorNumericoPorDefecto(0D))
   End Sub
#End Region


   Public Function ValidarCupones() As Boolean

      If cmbTarjeta.SelectedIndex = -1 Then
         ShowMessage("ATENCIÓN: Debe seleccionar una Tarjeta.")
         cmbTarjeta.Focus()
         Return False
      End If

      '# Valido que la tarjeta tenga una cuenta bancaria asociada. Caso contrario, no se permite continuar.
      Dim rTarjeta = New Reglas.Tarjetas()
      Dim eTarjeta = rTarjeta.GetUno(Integer.Parse(Me.cmbTarjeta.SelectedValue.ToString()))
      If eTarjeta.CuentaBancaria.IdCuentaBancaria = 0 Then
         bscCuentaBancariaDestino.Text = ""
         ShowMessage("La Tarjeta seleccionada no tiene asociada una Cuenta Bancaria Destino. Debe asociar una para poder continuar.")
         cmbTarjeta.SelectedIndex = -1
         Return False
      End If

      Return True
   End Function
   Private Function ValidarDeposito() As Boolean

      'If Me.cmbTipoDoc.SelectedIndex = -1 Then
      '   MessageBox.Show("Falta cargar el tipo de documento del Proveedor", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      '   Me.cmbTipoDoc.Focus()
      '   Return False
      'End If

      'If Me.bscCodigoCliente.Text.Trim().Length = 0 Then
      '   MessageBox.Show("Falta cargar el Nro. de Documento del Proveedor", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      '   Me.bscCodigoCliente.Focus()
      '   Return False
      'End If

      ''For i As Integer = 0 To _chequesPropios.Count - 1
      ''   If _chequesPropios(i).CuentaBancaria.IdCuentaBancaria = Integer.Parse(Me.bscCuentaBancariaDestino.FilaDevuelta.Cells("IdCuentaBancaria").Value.ToString()) Then
      ''      MessageBox.Show("Existe al menos un cheque que coincide con la Cuenta Bancaria Destino, NO es posible Grabar el Depósito", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop)
      ''      Return False
      ''   End If
      ''Next

      Return True

   End Function

   Private Sub LimpiarSolapaCuponesTarjeta()

      '# Fechas
      dtpFechaDesdeCupones.Value = Date.Now.AddMonths(-1)
      dtpFechaHastaCupones.Value = Date.Now

      ugDetalleCupones.ClearFilas()

      '# En caso de que la función provenga de Liquidaciones Tarjetas.
      '# Quitar solapas de Cheques
      tbcDetalle.SelectedTab = tbpCupones

      '# De los TXT y Labels del pie de la página, dejar solamente visible el de Total
      chbTodosCupones.Checked = False
      chbTodosCupones.Enabled = False

   End Sub
   Private Sub LimpiarSolapaBancos()

      '# Cuentas de Banco
      bscCuentaBancoCodigo.FilaDevuelta = Nothing
      bscCuentaBancoNombre.FilaDevuelta = Nothing
      txtImporte.Text = "0.00"
      txtObservacionCuentaBanco.Clear()
      optIngreso.Checked = False
      optEgreso.Checked = False

      '# Grilla
      If _eDepositosCuentasBancos IsNot Nothing Then
         _eDepositosCuentasBancos.Clear()
         ugCuentasBancos.Rows.Refresh(RefreshRow.ReloadData)
      End If
      If _dtCupones IsNot Nothing Then
         _dtCupones.Clear()
         ugDetalleCupones.Rows.Refresh(RefreshRow.ReloadData)
      End If

   End Sub

   Private Sub CargarDatosCuentaBancariaDestino(dr As DataGridViewRow)
      bscCodigoCuentaBancariaDestino.Text = dr.Cells("IdCuentaBancaria").Value.ToString()
      bscCuentaBancariaDestino.Text = dr.Cells("NombreCuenta").Value.ToString()
      bscCodigoCuentaBancariaDestino.FilaDevuelta = dr
      bscCuentaBancariaDestino.FilaDevuelta = dr
      bscCodigoCuentaBancariaDestino.Selecciono = True
      bscCuentaBancariaDestino.Selecciono = True
      VerificarGrabarImprimir()
   End Sub

   Private Sub FormatearGrillaCuentasBancos()
      For Each col As UltraGridColumn In ugCuentasBancos.DisplayLayout.Bands(0).Columns
         col.Hidden = False
         If col.Key = Entidades.DepositosCuentasBancos.Columnas.NumeroDeposito.ToString() Or
            col.Key = Entidades.DepositosCuentasBancos.Columnas.IdSucursal.ToString() Or
            col.Key = "Password" Or
            col.Key = "Usuario" Or
            col.Key = Entidades.DepositosCuentasBancos.Columnas.IdTipoComprobante.ToString() Then
            col.Hidden = True
         End If
      Next
   End Sub

#End Region

End Class