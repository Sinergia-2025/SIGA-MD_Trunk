Imports Eniac.Entidades

Public Class Depositos
   Inherits Base

#Region "Constructores"

   Public Sub New()
      Me.New(New Datos.DataAccess())
   End Sub
   Public Sub New(accesoDatos As Datos.DataAccess)
      NombreEntidad = "Depositos"
      da = accesoDatos
   End Sub

#End Region

#Region "Metodos"

   Public Function GetProximoNumero(idSucursal As Integer, idTipoComprobante As String) As Integer
      Return New SqlServer.Depositos(da).GetCodigoMaximo(idSucursal, idTipoComprobante) + 1
   End Function

   Friend Sub GrabaDeposito(ent As Entidades.Deposito)

      Dim sql = New SqlServer.Depositos(da)

      Dim IdCuentaBancariaDestino As Integer = 0
      If ent.CuentaBancariaDestino IsNot Nothing Then
         IdCuentaBancariaDestino = ent.CuentaBancariaDestino.IdCuentaBancaria
      End If

      sql.Depositos_I(ent.IdSucursal, ent.NumeroDeposito, ent.CuentaBancaria.IdCuentaBancaria, ent.Fecha, ent.FechaAplicado,
                      ent.UsoFechaCheque, ent.ImporteTotal, ent.Observacion, ent.ImportePesos, ent.ImporteDolares,
                      ent.ImporteCheques, ent.ImporteTarjetas, ent.ImporteTickets, ent.IdEstado, ent.IdCaja,
                      ent.IdEjercicio, ent.IdPlanCuenta, ent.IdAsiento, ent.TipoComprobante.IdTipoComprobante, IdCuentaBancariaDestino,
                      ent.CotizacionDolar)

      '# Si el depósito fué de Cupones
      'Dim eDepositosTarjCupon As Entidades.DepositosTarjetasCupones
      Dim rDepositosTarjCupon = New DepositosTarjetasCupones(da)
      Dim rTarjetasCupones = New TarjetasCupones(da)
      If ent.TarjetasCupones IsNot Nothing Then
         If ent.TarjetasCupones.Rows.Count > 0 Then
            For Each dr As DataRow In ent.TarjetasCupones.Rows
               Dim eDepositosTarjCupon = New Entidades.DepositosTarjetasCupones()

               eDepositosTarjCupon.IdSucursal = ent.IdSucursal
               eDepositosTarjCupon.NumeroDeposito = ent.NumeroDeposito
               eDepositosTarjCupon.IdTipoComprobante = ent.TipoComprobante.IdTipoComprobante
               eDepositosTarjCupon.IdTarjetaCupon = dr.Field(Of Integer)(Entidades.DepositosTarjetasCupones.Columnas.IdTarjetaCupon.ToString())

               '# Registro el cupón en DepositosTarjetasCupones
               rDepositosTarjCupon._Inserta(eDepositosTarjCupon)

               '# Actualiza el estado del Cupón a ACREDITADO
               rTarjetasCupones.ActualizaEstado(eDepositosTarjCupon.IdTarjetaCupon, nuevoEstado:=Entidades.TarjetaCupon.Estados.ACREDITADO)
            Next
         End If
      End If

   End Sub

   Friend Sub ActualizaDeposito(ent As Entidades.Deposito)

      Dim sql As SqlServer.Depositos = New SqlServer.Depositos(da)

      Dim IdCuentaBancariaDestino As Integer = 0
      If ent.CuentaBancariaDestino IsNot Nothing Then
         IdCuentaBancariaDestino = ent.CuentaBancariaDestino.IdCuentaBancaria
      End If

      sql.Depositos_I(ent.IdSucursal, ent.NumeroDeposito, ent.CuentaBancaria.IdCuentaBancaria, ent.Fecha, ent.FechaAplicado,
                      ent.UsoFechaCheque, ent.ImporteTotal, ent.Observacion, ent.ImportePesos, ent.ImporteDolares,
                      ent.ImporteCheques, ent.ImporteTarjetas, ent.ImporteTickets, ent.IdEstado, ent.IdCaja,
                      ent.IdEjercicio, ent.IdPlanCuenta, ent.IdAsiento, ent.TipoComprobante.IdTipoComprobante, IdCuentaBancariaDestino,
                      ent.CotizacionDolar)

   End Sub

   Public Function GetPorRangoFechas(idSucursal As Integer, desde As Date, hasta As Date,
                                     idCuentaBancaria As Integer, idEstado As String, idCaja As Integer, idTipoComprobante As String) As DataTable
      Return New SqlServer.Depositos(da).GetPorRangoFechas(idSucursal, desde, hasta, idCuentaBancaria, idEstado, idCaja, idTipoComprobante)
   End Function

   Public Function GetTodos() As List(Of Entidades.Deposito)
      Return CargaLista(New SqlServer.Depositos(da).Depositos_GA(),
                        Sub(o, dr) CargarUna(dr, o), Function() New Entidades.Deposito())
   End Function

   Public Function GetUna(idSucursal As Integer, numeroDeposito As Long, idTipoComprobante As String) As Entidades.Deposito
      Return CargaEntidad(New SqlServer.Depositos(da).Depositos_G1(idSucursal, numeroDeposito, idTipoComprobante),
                          Sub(o, dr) CargarUna(dr, o), Function() New Entidades.Deposito(),
                          AccionesSiNoExisteRegistro.Excepcion, Function() String.Format("No existe el Deposito con sucursal {0} número deposito {1} tipo {2}",
                                                                                         idSucursal, numeroDeposito, idTipoComprobante))
   End Function


#End Region

#Region "Overrides"

   Public Overrides Sub Insertar(entd As Entidades.Entidad)
      EjecutaConTransaccion(Sub() _Insertar(DirectCast(entd, Entidades.Deposito)))
   End Sub

   Public Sub _Insertar(ent As Entidades.Deposito)
      'ent.TipoComprobante = New Reglas.TiposComprobantes(da).GetUno("DEPOSITO")

      ent.NumeroDeposito = GetProximoNumero(ent.IdSucursal, ent.TipoComprobante.IdTipoComprobante)

      GrabaDeposito(ent)

      Dim rDepositoCheque = New DepositosCheques(da)
      Dim rCheqPropio = New Cheques(da)
      Dim TotalCheqPropios = 0D

      For Each cheq In ent.ChequesPropios

         'Grabo el cheque primero luego cuando grabe caja, para propios NO se relaciona el cheque con el movimiento.
         cheq.IdSucursal = ent.IdSucursal
         cheq.IdEstadoCheque = Entidades.Cheque.Estados.DEPOSITADO

         rCheqPropio.EjecutaSP(cheq, TipoSP._I)

         TotalCheqPropios = TotalCheqPropios + cheq.Importe

         'graba la relacion entre el Deposito y el cheque
         rDepositoCheque.GrabaDepositoCheque(ent, cheq)

      Next

      Dim decTotalCheq = 0D

      For Each cheq In ent.ChequesTerceros

         decTotalCheq = decTotalCheq + cheq.Importe
         cheq.IdSucursal = ent.IdSucursal
         cheq.IdEstadoCheque = Entidades.Cheque.Estados.DEPOSITADO

         'graba la relacion entre el Deposito y el cheque
         rDepositoCheque.GrabaDepositoCheque(ent, cheq)

      Next

      'si el cliente compro el modulo de caja registro el movimiento de efectivo y/o cheques entregados
      If Publicos.TieneModuloCaja Then  ' Boolean.Parse(New Eniac.Reglas.Parametros().GetValor("MODULOCAJA")) Then

         'Solo grabo en Caja si hay otro tipo de valores, los propios no se registran.
         If ent.ImporteTotal <> TotalCheqPropios Or ent.TipoComprobante.IdTipoComprobante = "EXTRACCION" Then

            Dim deta = New Entidades.CajaDetalles(ent.IdSucursal, ent.Usuario, ent.Password)
            Dim rCaj = New Cajas(da)
            Dim rCajaDet = New CajaDetalles(da)

            With deta
               .IdSucursal = ent.IdSucursal
               .IdCaja = ent.IdCaja
               .FechaMovimiento = ent.Fecha
               .NumeroPlanilla = rCaj.GetPlanillaActual(ent.IdSucursal, ent.IdCaja).NumeroPlanilla
               .ImportePesos = ent.ImportePesos
               .ImporteDolares = ent.ImporteDolares
               If ent.TipoComprobante.IdTipoComprobante = "EXTRACCION" Then
                  .ImportePesos += TotalCheqPropios
               End If
               .ImporteCheques = decTotalCheq
               .ImporteTickets = ent.ImporteTickets
               .ImporteTarjetas = ent.ImporteTarjetas
               .Observacion = Strings.Left(ent.TipoComprobante.Descripcion & " - " & ent.NumeroDeposito.ToString() & IIf(ent.ChequesTerceros.Count > 0, " - Cantidad Cheq. Tercero: " & ent.ChequesTerceros.Count.ToString(), "").ToString(), 100)

               .CotizacionDolar = ent.CotizacionDolar
               .IdMonedaImporteBancos = ent.CuentaBancaria.Moneda.IdMoneda

               '# Case TRANSFERENCIA
               If ent.TipoComprobante.IdTipoComprobante = "TRANSFERENCIA" Then
                  .ImporteBancos = .ImportePesos
                  .ImportePesos = 0
                  .IdCuentaCaja = Publicos.CtaCajaExtraccion
                  .IdTipoMovimiento = "E"c
                  .Observacion = String.Format("{0}. Origen: {1} / Destino: {2}", .Observacion, ent.CuentaBancaria.NombreCuenta, ent.CuentaBancariaDestino.NombreCuenta).Truncar(100)
               End If

               '# Case LIQUIDATARJETA hago un Egreso de la caja configurada en parámetros (CTACAJALIQUIDACIONTARJETA). Caso contrario mantengo el comportamiento estándar.
               If ent.TipoComprobante.IdTipoComprobante = "LIQUIDATARJETA" Then
                  .IdCuentaCaja = Publicos.CtaCajaLiquidacionesTarjetas
                  .IdTipoMovimiento = "E"c
               End If

               '# Case DEPOSITO
               If ent.TipoComprobante.IdTipoComprobante = "DEPOSITO" Then
                  .IdCuentaCaja = Publicos.CtaCajaDeposito
                  .IdTipoMovimiento = "E"c
               End If

               '# Case EXTRACCION
               If ent.TipoComprobante.IdTipoComprobante = "EXTRACCION" Then
                  .IdCuentaCaja = Publicos.CtaCajaExtraccion
                  .IdTipoMovimiento = "I"c
               End If

               .EsModificable = False
               .GeneraContabilidad = False
               .Usuario = actual.Nombre

               '# Se agrega el Tipo de Comprobante y Número de Depósito
               .IdTipoComprobante = ent.TipoComprobante.IdTipoComprobante
               .NumeroDeposito = ent.NumeroDeposito

            End With

            'Por ahora marco los cheques con el movimiento, aunque en realidad no lo sume en el movimiento de Caja.
            '-- REG-44127.- ------------------------------------------------------------------------------------------------------------------
            Dim lTarjetasCupones = New List(Of TarjetaCupon)
            If ent.TarjetasCupones IsNot Nothing Then
               Dim rCupones = New TarjetasCupones(da)
               For Each dr As DataRow In ent.TarjetasCupones.Rows
                  lTarjetasCupones.Add(rCupones.GetUno(dr.Field(Of Integer)("idTarjetaCupon")))
               Next
            End If
            '----------------------------------------------------------------------------------------------------------------------------------
            rCajaDet.AgregaMovimiento(deta, ConvierteChequesTercerosEnArray(ent.ChequesTerceros),
                                      ConvierteChequesPropiosEnArray(ent.ChequesPropios), ConvierteTarjetasCuponesEnArray(lTarjetasCupones))

            If ent.TipoComprobante.IdTipoComprobante = "TRANSFERENCIA" Then
               Dim deta2 = deta.Clonar(deta)
               With deta2
                  .ImporteBancos = ent.ImportePesos
                  .IdCuentaCaja = Publicos.CtaCajaDeposito
                  .IdTipoMovimiento = "I"c

                  rCajaDet.AgregaMovimiento(deta2, ConvierteChequesTercerosEnArray(ent.ChequesTerceros), ConvierteChequesPropiosEnArray(ent.ChequesPropios))
               End With
            End If

            If ent.TipoComprobante.IdTipoComprobante = "EXTRACCION" Then
               Dim deta3 As Entidades.CajaDetalles = deta.Clonar(deta)
               With deta3
                  .ImporteBancos = ent.ImportePesos + ent.ImporteDolares + TotalCheqPropios
                  .ImportePesos = 0
                  .ImporteDolares = 0
                  .ImporteCheques = 0
                  .ImporteRetenciones = 0
                  .ImporteTarjetas = 0
                  .ImporteTickets = 0

                  .IdCuentaCaja = Publicos.CtaCajaExtraccion
                  .IdTipoMovimiento = "E"c

                  rCajaDet.AgregaMovimiento(deta3, {}, {}) 'ConvierteChequesTercerosEnArray(ent.ChequesTerceros), ConvierteChequesPropiosEnArray(ent.ChequesPropios))
               End With
            End If

            If ent.TipoComprobante.IdTipoComprobante = "DEPOSITO" Then
               Dim deta3 As Entidades.CajaDetalles = deta.Clonar(deta)
               With deta3
                  .ImporteBancos = ent.ImportePesos + ent.ImporteDolares + ent.ImporteCheques + ent.ImporteTarjetas + ent.ImporteTickets
                  .ImportePesos = 0
                  .ImporteDolares = 0
                  .ImporteCheques = 0
                  .ImporteRetenciones = 0
                  .ImporteTarjetas = 0
                  .ImporteTickets = 0

                  .IdCuentaCaja = Publicos.CtaCajaDeposito
                  .IdTipoMovimiento = "I"c

                  rCajaDet.AgregaMovimiento(deta3, {}, {}) 'ConvierteChequesTercerosEnArray(ent.ChequesTerceros), ConvierteChequesPropiosEnArray(ent.ChequesPropios))
               End With
            End If

         End If

      End If


      'si el Cliente compro el modulo de Banco registro el movimiento de Cheques Propios entregados

      If Publicos.TieneModuloBanco Then  ' Boolean.Parse(New Eniac.Reglas.Parametros().GetValor("MODULOBANCO")) Then

         Dim entLibroBanco = New Entidades.LibroBanco(actual.Sucursal.Id, actual.Nombre, actual.Pwd)
         Dim rLibBanco = New Reglas.LibroBancos(da)
         Dim oLibroBancos = New Reglas.LibroBancos(da)


         'Registro la entrada del Cheque en la cuenta destino
         For Each cheq In ent.ChequesTerceros

            'oLibroBancos = New Reglas.LibroBancos(da)

            With entLibroBanco
               .IdSucursal = cheq.IdSucursal
               .IdCuentaBancaria = ent.CuentaBancaria.IdCuentaBancaria
               .NumeroMovimiento = rLibBanco.GetProximoNumeroDeMovimiento(.IdSucursal, .IdCuentaBancaria)
               .IdCuentaBanco = Publicos.CtaBancoDeposito
               .IdTipoMovimiento = "I"
               .Importe = cheq.Importe
               .FechaMovimiento = ent.Fecha
               .IdCheque = cheq.IdCheque
               If ent.UsoFechaCheque Then
                  .FechaAplicado = cheq.FechaCobro
               Else
                  .FechaAplicado = ent.FechaAplicado
               End If
               .Observacion = Strings.Left(ent.TipoComprobante.Descripcion & " - " & ent.NumeroDeposito.ToString() & ". Origen: " & ent.CuentaBancaria.NombreCuenta & " - " & ent.Observacion, 100)
               .Conciliado = False
               .IdTipoComprobante = ent.TipoComprobante.IdTipoComprobante
               .NumeroDeposito = ent.NumeroDeposito
            End With

            oLibroBancos.AgregaMovimiento(entLibroBanco)

         Next

         'Por cada Cheque Propio tiene que hacer la salida en una cuenta y la entrada en otra.
         For Each cheq In ent.ChequesPropios

            'oLibroBancos = New Reglas.LibroBancos(da)

            'Registro la Salida de la cuenta Origen
            With entLibroBanco
               .IdSucursal = cheq.IdSucursal
               .IdCuentaBancaria = cheq.CuentaBancaria.IdCuentaBancaria
               .NumeroMovimiento = rLibBanco.GetProximoNumeroDeMovimiento(.IdSucursal, .IdCuentaBancaria)

               If ent.TipoComprobante.IdTipoComprobante = "DEPOSITO" Then
                  .IdCuentaBanco = Publicos.CtaBancoDeposito
               Else
                  .IdCuentaBanco = Publicos.CtaBancoExtraccion
               End If

               .IdTipoMovimiento = "E"
               .Importe = cheq.Importe * (-1)
               .FechaMovimiento = ent.Fecha
               .IdCheque = cheq.IdCheque
               .FechaAplicado = cheq.FechaCobro
               .Observacion = Strings.Left(ent.TipoComprobante.Descripcion & " - " & ent.NumeroDeposito.ToString() & " - " & ent.Observacion, 100)
               .Conciliado = False
               .IdTipoComprobante = ent.TipoComprobante.IdTipoComprobante
               .NumeroDeposito = ent.NumeroDeposito
            End With

            oLibroBancos.AgregaMovimiento(entLibroBanco)

            'Registro la Entrada en la cuenta Destino. Solo hago los cambios
            If ent.TipoComprobante.IdTipoComprobante <> "EXTRACCION" Then
               With entLibroBanco
                  .IdCuentaBancaria = ent.CuentaBancaria.IdCuentaBancaria
                  .NumeroMovimiento = rLibBanco.GetProximoNumeroDeMovimiento(.IdSucursal, .IdCuentaBancaria)
                  .IdTipoMovimiento = "I"
                  .Importe = cheq.Importe
                  .IdTipoComprobante = ent.TipoComprobante.IdTipoComprobante
                  .NumeroDeposito = ent.NumeroDeposito
               End With

               oLibroBancos.AgregaMovimiento(entLibroBanco)
            End If

         Next

         'Agrego el Movimiento por Deposito de Efectivo.
         If ent.ImportePesos > 0 Or ent.ImporteDolares > 0 Then

            'oLibroBancos = New Reglas.LibroBancos(da)

            With entLibroBanco
               .IdSucursal = ent.IdSucursal
               .IdCuentaBancaria = ent.CuentaBancaria.IdCuentaBancaria
               .NumeroMovimiento = rLibBanco.GetProximoNumeroDeMovimiento(.IdSucursal, .IdCuentaBancaria)
               If ent.TipoComprobante.IdTipoComprobante = "TRANSFERENCIA" Then
                  .Importe = ent.ImportePesos
                  .IdCuentaBanco = Publicos.CtaBancoExtraccion
                  .IdTipoMovimiento = "E"c
               Else
                  If ent.TipoComprobante.IdTipoComprobante = "DEPOSITO" Then
                     .IdCuentaBanco = Publicos.CtaBancoDeposito
                     .IdTipoMovimiento = "I"
                  Else
                     .IdCuentaBanco = Publicos.CtaBancoExtraccion
                     .IdTipoMovimiento = "E"
                  End If
                  .Importe = ent.ImportePesos + ent.ImporteDolares
               End If
               .FechaMovimiento = ent.Fecha
               .IdCheque = Nothing
               .FechaAplicado = ent.FechaAplicado
               If ent.TipoComprobante.IdTipoComprobante = "TRANSFERENCIA" Then
                  .Observacion = String.Format("{0} - {1}. Destino: {2} - {3}", ent.TipoComprobante.Descripcion, ent.NumeroDeposito, ent.CuentaBancariaDestino.NombreCuenta, ent.Observacion).Truncar(100)
               Else
                  .Observacion = String.Format("{0} - {1} - Efectivo - {2}", ent.TipoComprobante.Descripcion, ent.NumeroDeposito, ent.Observacion).Truncar(100)
               End If
               .Conciliado = False

               '# Se agrega el Tipo de Comprobante y Número de Depósito
               .IdTipoComprobante = ent.TipoComprobante.IdTipoComprobante
               .NumeroDeposito = ent.NumeroDeposito
            End With

            oLibroBancos.AgregaMovimiento(entLibroBanco)

            If ent.TipoComprobante.IdTipoComprobante = "TRANSFERENCIA" Then
               Dim entLibroBanco2 = entLibroBanco.Clonar(entLibroBanco)
               With entLibroBanco2
                  .IdCuentaBancaria = ent.CuentaBancariaDestino.IdCuentaBancaria
                  .NumeroMovimiento = rLibBanco.GetProximoNumeroDeMovimiento(.IdSucursal, .IdCuentaBancaria)

                  .Importe = ent.ImportePesos
                  .IdCuentaBanco = Publicos.CtaBancoDeposito
                  .IdTipoMovimiento = "I"c
                  .Observacion = Strings.Left(ent.TipoComprobante.Descripcion & " - " & ent.NumeroDeposito.ToString() & ". Origen: " & ent.CuentaBancaria.NombreCuenta & " - " & ent.Observacion, 100)

                  oLibroBancos.AgregaMovimiento(entLibroBanco2)
               End With
            End If

         End If

         'Agrego el Movimiento por Deposito de Efectivo.
         If ent.ImporteTarjetas > 0 Then

            'oLibroBancos = New Reglas.LibroBancos(da)

            With entLibroBanco
               .IdSucursal = ent.IdSucursal
               .IdCuentaBancaria = ent.CuentaBancaria.IdCuentaBancaria
               .NumeroMovimiento = rLibBanco.GetProximoNumeroDeMovimiento(.IdSucursal, .IdCuentaBancaria)

               '# Case LIQUIDATARJETA hago un ingreso en la Cuenta Banco configurada por parámetros.
               If ent.TipoComprobante.IdTipoComprobante = "LIQUIDATARJETA" Then
                  .IdCuentaBanco = Publicos.CtaBancoLiquidacionesTarjetas
               Else
                  .IdCuentaBanco = Publicos.CtaBancoDeposito
               End If
               .IdTipoMovimiento = "I"
               .Importe = ent.ImporteTarjetas
               .FechaMovimiento = ent.Fecha
               .IdCheque = Nothing
               .FechaAplicado = ent.FechaAplicado
               .Observacion = Strings.Left(ent.TipoComprobante.Descripcion & " - " & ent.NumeroDeposito.ToString() & " - Tarjetas - " & ent.Observacion, 100)
               .Conciliado = False
               .IdTipoComprobante = ent.TipoComprobante.IdTipoComprobante
               .NumeroDeposito = ent.NumeroDeposito
            End With

            oLibroBancos.AgregaMovimiento(entLibroBanco)
         End If

         '# Tomo la misma entidad usada anteriormente
         Dim rDepositosCuentasBancos = New Reglas.DepositosCuentasBancos(da)
         For Each eDCB In ent.CuentasBancos

            '# Por cada Cuenta Banco vinculada a la Liquidación/Depósito, se registra el movimiento de I/E en LibrosBancos.
            entLibroBanco.NumeroMovimiento = rLibBanco.GetProximoNumeroDeMovimiento(ent.IdSucursal, ent.CuentaBancaria.IdCuentaBancaria)
            entLibroBanco.IdCuentaBanco = eDCB.IdCuentaBanco
            entLibroBanco.IdTipoMovimiento = eDCB.IdTipoCuenta
            entLibroBanco.IdCheque = Nothing
            entLibroBanco.Importe = eDCB.Importe
            entLibroBanco.Observacion = Strings.Left(ent.TipoComprobante.Descripcion & " - " & ent.NumeroDeposito.ToString() & " - " & eDCB.Observacion, 100)

            oLibroBancos.AgregaMovimiento(entLibroBanco)

            '# Por cada Cuenta Banco vinculada a la Liquidación, se registra el movimiento de I/E en DepositosCuentasBancos
            eDCB.IdSucursal = entLibroBanco.IdSucursal
            eDCB.IdTipoComprobante = entLibroBanco.IdTipoComprobante
            eDCB.NumeroDeposito = entLibroBanco.NumeroDeposito.Value
            eDCB.Importe = If(eDCB.IdTipoCuenta = "I", eDCB.Importe, eDCB.Importe * -1)

            rDepositosCuentasBancos._Inserta(eDCB)
         Next

      End If

      'vml 05/02/13 Contabilidad
      'If Boolean.Parse(New Reglas.Parametros().GetValor("MODULOCONTABILIDAD")) Then
      '    CargarContabilidad(ent)
      'End If
      If Publicos.TieneModuloContabilidad And Publicos.ContabilidadEjecutarEnLinea Then
         Dim ctbl = New Contabilidad(da)
         ctbl.RegistraContabilidad(ent)
      End If

   End Sub

#End Region

#Region "Metodos Privados"

   Private Sub CargarUna(dr As DataRow, o As Entidades.Deposito)

      With o
         .IdSucursal = Integer.Parse(dr("IdSucursal").ToString())
         .NumeroDeposito = Long.Parse(dr("NumeroDeposito").ToString())
         .TipoComprobante = New Reglas.TiposComprobantes(da).GetUno(dr("IdTipoComprobante").ToString())
         .CuentaBancaria = New Reglas.CuentasBancarias().GetUna(Int32.Parse(dr("IdCuentaBancaria").ToString()))
         .Fecha = Date.Parse(dr("Fecha").ToString())
         .FechaAplicado = Date.Parse(dr("FechaAplicado").ToString())
         .UsoFechaCheque = Boolean.Parse(dr("UsoFechaCheque").ToString())

         'cargo valores del comprobante
         .ImporteTotal = Decimal.Parse(dr("ImporteTotal").ToString())
         .Observacion = dr("Observacion").ToString()

         'cargo el efectivo para tenerlo discriminado
         .ImportePesos = Decimal.Parse(dr("ImportePesos").ToString())
         .ImporteTarjetas = Decimal.Parse(dr("ImporteTarjetas").ToString())
         .ImporteCheques = Decimal.Parse(dr("ImporteCheques").ToString())

         'TODO: ACTUALMENTE en CERO.
         .ImporteDolares = Decimal.Parse(dr("ImporteDolares").ToString())

         'TODO: ACTUALMENTE en CERO.
         .ImporteTickets = Decimal.Parse(dr("ImporteTickets").ToString())

         .CotizacionDolar = dr.Field(Of Decimal)("CotizacionDolar")

         'cargo los Cheques Emitidos
         .ChequesPropios = New Reglas.Cheques(da).GetPorDeposito(.IdSucursal, .TipoComprobante.IdTipoComprobante, .NumeroDeposito, esPropio:=True)

         'cargo los cheques de terceros
         .ChequesTerceros = New Reglas.Cheques(da).GetPorDeposito(.IdSucursal, .TipoComprobante.IdTipoComprobante, .NumeroDeposito, esPropio:=False)

         .IdEstado = dr("IdEstado").ToString()

         If Not String.IsNullOrEmpty(dr("IdCaja").ToString()) Then
            .IdCaja = Integer.Parse(dr("IdCaja").ToString())
            .NombreCaja = dr("NombreCaja").ToString()
         End If

         If Not IsDBNull(dr("IdEjercicio")) Then
            .IdEjercicio = Integer.Parse(dr("IdEjercicio").ToString())
         End If
         If Not IsDBNull(dr("IdPlanCuenta")) Then
            .IdPlanCuenta = Integer.Parse(dr("IdPlanCuenta").ToString())
         End If
         If Not IsDBNull(dr("IdAsiento")) Then
            .IdAsiento = Integer.Parse(dr("IdAsiento").ToString())
         End If

         If Not String.IsNullOrEmpty(dr("IdCuentaBancariaDestino").ToString()) AndAlso (Integer.Parse(dr("IdCuentaBancariaDestino").ToString()) <> 0) Then
            .CuentaBancariaDestino = New Reglas.CuentasBancarias().GetUna(Integer.Parse(dr("IdCuentaBancariaDestino").ToString()))
         End If

         '# Cargo las Cuentas de Banco y los Cupones (en caso que existan)
         Dim rDepositosTarjetasCupones As Reglas.DepositosTarjetasCupones = New Reglas.DepositosTarjetasCupones(da)
         Dim rDepositosCuentasBanco As Reglas.DepositosCuentasBancos = New Reglas.DepositosCuentasBancos(da)

         .TarjetasCupones = rDepositosTarjetasCupones.GetAll(.IdSucursal, .NumeroDeposito, .TipoComprobante.IdTipoComprobante, IdTarjetaCupon:=Nothing)

         .CuentasBancos = rDepositosCuentasBanco.GetTodas(.IdSucursal, .NumeroDeposito, .TipoComprobante.IdTipoComprobante, idCuentaBanco:=Nothing)

      End With

   End Sub

   Private Function ConvierteChequesPropiosEnArray(ChequesPropios As List(Of Entidades.Cheque)) As IEnumerable(Of Entidades.Cheque)
      Dim eCheques = New List(Of Entidades.Cheque)()
      For Each cheq In ChequesPropios
         eCheques.Add(cheq)
      Next
      Return eCheques
   End Function

   Private Function ConvierteChequesTercerosEnArray(ChequesTerceros As List(Of Entidades.Cheque)) As IEnumerable(Of Entidades.Cheque)
      Dim eCheques = New List(Of Entidades.Cheque)()
      For Each cheq In ChequesTerceros
         eCheques.Add(cheq)
      Next
      Return eCheques
   End Function

   Private Function ConvierteTarjetasCuponesEnArray(TarjetasCupones As List(Of Entidades.TarjetaCupon)) As IEnumerable(Of Entidades.TarjetaCupon)
      Dim eTarjetas = New List(Of Entidades.TarjetaCupon)()
      For Each Trjs In TarjetasCupones
         eTarjetas.Add(Trjs)
      Next
      Return eTarjetas
   End Function
#End Region

#Region "Metodos Publicos"
   Public Sub AnularDepositos(tablaAnular As DataTable, IdCaja As Integer, IdTipoComprobante As String)
      EjecutaConTransaccion(Sub() _AnularDepositos(tablaAnular, IdCaja, IdTipoComprobante))
   End Sub
   Public Sub _AnularDepositos(tablaAnular As DataTable, IdCaja As Integer, IdTipoComprobante As String)
      Dim sql = New SqlServer.Depositos(da)
      For Each filaAnula As DataRow In tablaAnular.Rows
         Dim deposito = New Entidades.Deposito()
         Dim odepositoCheques = New DepositosCheques(da)
         Dim rCheque = New Cheques(da)

         Dim sqlLibroBancos = New SqlServer.LibroBancos(da)
         Dim sqlCheq = New SqlServer.Cheques(da)
         Dim TotalCheqPropios = 0D
         Dim oDepositoCheque = New DepositosCheques(da)


         deposito = New Depositos(da).GetUna(actual.Sucursal.Id, Integer.Parse(filaAnula("NumeroDeposito").ToString), IdTipoComprobante)

         If deposito.IdCaja = 0 Then
            Throw New Exception("El Deposito NO puede anularse porque No tiene Caja Asignada, Deposito Nro: " & deposito.NumeroDeposito)
            Exit Sub
         End If

         If deposito.ImportePesos = deposito.ImporteTotal Then
            deposito.IdCaja = IdCaja
         End If

         deposito.IdEstado = "ANULADO"
         deposito.Observacion = "*** ANULADO ***"
         sql.AnularDeposito(deposito.IdSucursal, deposito.NumeroDeposito, deposito.TipoComprobante.IdTipoComprobante, deposito.IdEstado, deposito.Observacion)

         For Each cheq In deposito.ChequesPropios
            cheq.IdSucursal = deposito.IdSucursal

            sqlLibroBancos.LibroBancos_DNroCheque(cheq.IdSucursal, cheq.Banco.IdBanco, cheq.IdBancoSucursal, cheq.Localidad.IdLocalidad, cheq.NumeroCheque)

            TotalCheqPropios = TotalCheqPropios + cheq.Importe

            oDepositoCheque.EliminaDepositoCheque(deposito, cheq)

            'rCheque.EjecutaSP(cheq, TipoSP._D)
            cheq.IdEstadoCheque = Entidades.Cheque.Estados.ANULADO
            rCheque._Modifica(cheq)

         Next


         Dim decTotalCheq As Decimal = 0

         For Each cheq In deposito.ChequesTerceros

            decTotalCheq = decTotalCheq + cheq.Importe

            oDepositoCheque.EliminaDepositoCheque(deposito, cheq)

            cheq.IdSucursal = deposito.IdSucursal

            ''Lo vuelvo a dejar en Cartera
            'cheq.NroPlanillaEgreso = 0
            'cheq.NroMovimientoEgreso = 0

            'rCheque.EjecutaSP(cheq, TipoSP._U)

            'Para que lo tome el asiento de Caja que se hace posteriormente.
            cheq.IdEstadoCheque = cheq.IdEstadoChequeAnt

            'Dim eCheque = rCheque.RecuperarEstadosChequeAnteriores(cheq.IdCheque)

            'sqlCheq.Cheques_VuelveEstadoAnt(cheq.IdSucursal,
            '                                cheq.Banco.IdBanco,
            '                                cheq.IdBancoSucursal,
            '                                cheq.Localidad.IdLocalidad,
            '                                cheq.NumeroCheque,
            '                                actual.Nombre,
            '                                eCheque.IdEstadoCheque.ToString(),
            '                                eCheque.IdEstadoChequeAnt.ToString(),
            '                                cheq.IdCheque,
            '                                limpiaPlanillaCaja:=True)


            '' '-- REQ-28357 --
            '' '# Recupero los estados de los cheques anteriores
            ''Dim eCheque As Entidades.Cheque = rCheque.RecuperarEstadosChequeAnteriores(cheq.IdCheque)

            ''sqlCheq.Cheques_VuelveEstadoAnt(cheq.IdSucursal,
            ''                                cheq.Banco.IdBanco,
            ''                                cheq.IdBancoSucursal,
            ''                                cheq.Localidad.IdLocalidad,
            ''                                cheq.NumeroCheque,
            ''                                actual.Nombre,
            ''                                eCheque.IdEstadoCheque.ToString(),
            ''                                eCheque.IdEstadoChequeAnt.ToString(),
            ''                                cheq.IdCheque)

            sqlLibroBancos.LibroBancos_DPorCheque(cheq.IdCheque)

         Next


         If Publicos.TieneModuloCaja Then  ' Boolean.Parse(New Eniac.Reglas.Parametros().GetValor("MODULOCAJA")) Then

            'Solo grabo en Caja si hay otro tipo de valores, los propios no se registran.
            If deposito.ImporteTotal <> TotalCheqPropios Or deposito.TipoComprobante.IdTipoComprobante = "EXTRACCION" Then

               Dim deta = New Entidades.CajaDetalles(deposito.IdSucursal, deposito.Usuario, deposito.Password)
               Dim caj = New Cajas(da)
               Dim cajaDet = New CajaDetalles(da)

               With deta
                  .IdSucursal = deposito.IdSucursal
                  .IdCaja = deposito.IdCaja
                  .FechaMovimiento = deposito.Fecha
                  .NumeroPlanilla = caj.GetPlanillaActual(deposito.IdSucursal, deposito.IdCaja).NumeroPlanilla
                  .ImportePesos = deposito.ImportePesos
                  .ImporteDolares = deposito.ImporteDolares
                  If deposito.TipoComprobante.IdTipoComprobante = "EXTRACCION" Then
                     .ImportePesos += TotalCheqPropios
                  End If
                  .ImporteCheques = decTotalCheq
                  .ImporteTickets = deposito.ImporteTickets
                  .ImporteTarjetas = deposito.ImporteTarjetas
                  .Observacion = Strings.Left("ANULA: " & deposito.TipoComprobante.Descripcion & " - " & deposito.NumeroDeposito.ToString() & IIf(deposito.ChequesTerceros.Count > 0, " - Cantidad Cheq. Tercero: " & deposito.ChequesTerceros.Count.ToString(), "").ToString(), 100)

                  .CotizacionDolar = deposito.CotizacionDolar
                  .IdMonedaImporteBancos = deposito.CuentaBancaria.Moneda.IdMoneda

                  '# DEPOSITO 
                  If deposito.TipoComprobante.IdTipoComprobante = "DEPOSITO" Then
                     .IdCuentaCaja = Publicos.CtaCajaDeposito
                     .IdTipoMovimiento = "I"c
                  End If

                  '# LIQUIDACION 
                  If deposito.TipoComprobante.IdTipoComprobante = "LIQUIDATARJETA" Then
                     .IdCuentaCaja = Publicos.CtaCajaLiquidacionesTarjetas
                     .IdTipoMovimiento = "I"c
                  End If

                  '# EXTRACCION
                  If deposito.TipoComprobante.IdTipoComprobante = "EXTRACCION" Then
                     .IdCuentaCaja = Publicos.CtaCajaExtraccion
                     .IdTipoMovimiento = "E"c
                  End If

                  .EsModificable = False
                  .GeneraContabilidad = False
                  .Usuario = actual.Nombre
                  .IdTipoComprobante = deposito.TipoComprobante.IdTipoComprobante
                  .NumeroDeposito = deposito.NumeroDeposito
               End With

               'Por ahora marco los cheques con el movimiento, aunque en realidad no lo sume en el movimiento de Caja.
               cajaDet.AgregaMovimiento(deta, ConvierteChequesTercerosEnArray(deposito.ChequesTerceros), ConvierteChequesPropiosEnArray(deposito.ChequesPropios))

               'Dim a = 1

               'deposito.ChequesTerceros.ForEach(
               '   Sub(cheq)
               '      Dim eCheque = rCheque.RecuperarEstadosChequeAnteriores(cheq.IdCheque, top:=3)

               '      sqlCheq.Cheques_VuelveEstadoAnt(cheq.IdSucursal,
               '                             cheq.Banco.IdBanco,
               '                             cheq.IdBancoSucursal,
               '                             cheq.Localidad.IdLocalidad,
               '                             cheq.NumeroCheque,
               '                             actual.Nombre,
               '                             eCheque.IdEstadoCheque.ToString(),
               '                             eCheque.IdEstadoChequeAnt.ToString(),
               '                             cheq.IdCheque,
               '                             limpiaPlanillaCaja:=True)
               '   End Sub)


               If deposito.TipoComprobante.IdTipoComprobante = "TRANSFERENCIA" Then
                  Dim deta2 = deta.Clonar(deta)
                  With deta2
                     .ImporteBancos = deposito.ImportePesos
                     .IdCuentaCaja = Publicos.CtaCajaDeposito
                     .IdTipoMovimiento = "E"c

                     cajaDet.AgregaMovimiento(deta2, ConvierteChequesTercerosEnArray(deposito.ChequesTerceros), ConvierteChequesPropiosEnArray(deposito.ChequesPropios))
                  End With
               End If

               If deposito.TipoComprobante.IdTipoComprobante = "EXTRACCION" Then
                  Dim deta3 As Entidades.CajaDetalles = deta.Clonar(deta)
                  With deta3
                     .ImporteBancos = deposito.ImportePesos + deposito.ImporteDolares + TotalCheqPropios
                     .ImportePesos = 0
                     .ImporteDolares = 0
                     .ImporteCheques = 0
                     .ImporteRetenciones = 0
                     .ImporteTarjetas = 0
                     .ImporteTickets = 0

                     .IdCuentaCaja = Publicos.CtaCajaExtraccion
                     .IdTipoMovimiento = "I"c

                     cajaDet.AgregaMovimiento(deta3, {}, {}) 'ConvierteChequesTercerosEnArray(deposito.ChequesTerceros), ConvierteChequesPropiosEnArray(deposito.ChequesPropios))
                  End With
               End If

               If deposito.TipoComprobante.IdTipoComprobante = "DEPOSITO" Then
                  Dim deta3 As Entidades.CajaDetalles = deta.Clonar(deta)
                  With deta3
                     .ImporteBancos = deposito.ImportePesos + deposito.ImporteDolares + deposito.ImporteCheques + deposito.ImporteTarjetas + deposito.ImporteTickets
                     .ImportePesos = 0
                     .ImporteDolares = 0
                     .ImporteCheques = 0
                     .ImporteRetenciones = 0
                     .ImporteTarjetas = 0
                     .ImporteTickets = 0

                     .IdCuentaCaja = Publicos.CtaCajaDeposito
                     .IdTipoMovimiento = "E"c

                     cajaDet.AgregaMovimiento(deta3, {}, {}) 'ConvierteChequesTercerosEnArray(deposito.ChequesTerceros), ConvierteChequesPropiosEnArray(deposito.ChequesPropios))
                  End With
               End If

            End If
         End If


         'si el Cliente compro el modulo de Banco registro el movimiento de Cheques Propios entregados

         If Publicos.TieneModuloBanco Then  ' Boolean.Parse(New Eniac.Reglas.Parametros().GetValor("MODULOBANCO")) Then

            Dim oLibroBancos As LibroBancos '= New Reglas.LibroBancos(da)
            Dim entLibroBanco = New Entidades.LibroBanco(actual.Sucursal.Id, actual.Nombre, actual.Pwd)
            Dim oLibBanco = New LibroBancos(da)

            oLibroBancos = New Reglas.LibroBancos(da)


            'Agrego el Movimiento por Deposito de Efectivo.
            If deposito.ImportePesos > 0 Or deposito.ImporteDolares > 0 Then

               'oLibroBancos = New Reglas.LibroBancos(da)

               With entLibroBanco
                  .IdSucursal = deposito.IdSucursal
                  .IdCuentaBancaria = deposito.CuentaBancaria.IdCuentaBancaria
                  .NumeroMovimiento = oLibBanco.GetProximoNumeroDeMovimiento(.IdSucursal, .IdCuentaBancaria)

                  '# DEPOSITO
                  If deposito.TipoComprobante.IdTipoComprobante = "DEPOSITO" Then
                     .IdCuentaBanco = Publicos.CtaBancoDeposito
                     .IdTipoMovimiento = "E"
                  End If

                  '# EXTRACCION
                  If deposito.TipoComprobante.IdTipoComprobante = "EXTRACCION" Then
                     .IdCuentaBanco = Publicos.CtaBancoExtraccion
                     .IdTipoMovimiento = "I"
                  End If

                  .Importe = deposito.ImportePesos + deposito.ImporteDolares
                  .FechaMovimiento = deposito.Fecha
                  .IdCheque = Nothing
                  .FechaAplicado = deposito.FechaAplicado
                  .Observacion = Strings.Left("ANULA: " & deposito.TipoComprobante.Descripcion & " - " & deposito.NumeroDeposito.ToString() & " - Efectivo - " & deposito.Observacion, 100)
                  .Conciliado = False
                  .NumeroDeposito = deposito.NumeroDeposito
                  .IdTipoComprobante = deposito.TipoComprobante.IdTipoComprobante
               End With

               oLibroBancos.AgregaMovimiento(entLibroBanco)

            End If

            'Agrego el Movimiento por Deposito de Efectivo.
            If deposito.ImporteTarjetas > 0 Then

               'oLibroBancos = New Reglas.LibroBancos(da)

               With entLibroBanco
                  .IdSucursal = deposito.IdSucursal
                  .IdCuentaBancaria = deposito.CuentaBancaria.IdCuentaBancaria
                  .NumeroMovimiento = oLibBanco.GetProximoNumeroDeMovimiento(.IdSucursal, .IdCuentaBancaria)

                  '# LIQUIDACION
                  If deposito.TipoComprobante.IdTipoComprobante = "LIQUIDATARJETA" Then
                     .IdCuentaBanco = Publicos.CtaBancoLiquidacionesTarjetas
                  End If

                  '# DEPOSITO
                  If deposito.TipoComprobante.IdTipoComprobante = "DEPOSITO" Then
                     .IdCuentaBanco = Publicos.CtaBancoDeposito
                  End If

                  '# EXTRACCION
                  If deposito.TipoComprobante.IdTipoComprobante = "EXTRACCION" Then
                     .IdCuentaBanco = Publicos.CtaBancoExtraccion
                  End If

                  .IdTipoMovimiento = "E"
                  .Importe = deposito.ImporteTarjetas
                  .FechaMovimiento = deposito.Fecha
                  .IdCheque = Nothing
                  .FechaAplicado = deposito.FechaAplicado
                  .Observacion = Strings.Left("ANULA: " & deposito.TipoComprobante.Descripcion & " - " & deposito.NumeroDeposito.ToString() & " - Tarjetas - " & deposito.Observacion, 100)
                  .Conciliado = False
                  .IdTipoComprobante = deposito.TipoComprobante.IdTipoComprobante
                  .NumeroDeposito = deposito.NumeroDeposito
               End With

               oLibroBancos.AgregaMovimiento(entLibroBanco)

            End If

            '# Contra movimiento para cada Cuenta Banco vinculada
            If deposito.CuentasBancos.Count > 0 Then

               With entLibroBanco

                  For Each dcb As Entidades.DepositosCuentasBancos In deposito.CuentasBancos

                     .IdSucursal = deposito.IdSucursal
                     .IdCuentaBancaria = deposito.CuentaBancaria.IdCuentaBancaria
                     .NumeroMovimiento = oLibBanco.GetProximoNumeroDeMovimiento(.IdSucursal, .IdCuentaBancaria)
                     .IdCuentaBanco = dcb.IdCuentaBanco
                     .IdTipoMovimiento = If(dcb.IdTipoCuenta = "E", "I", "E")
                     .Importe = dcb.Importe
                     .FechaMovimiento = deposito.Fecha
                     .IdCheque = Nothing
                     .FechaAplicado = deposito.FechaAplicado
                     .Observacion = Strings.Left("ANULA: " & deposito.TipoComprobante.Descripcion & " - " & deposito.NumeroDeposito.ToString() & " - Tarjetas - " & deposito.Observacion, 100)
                     .Conciliado = False
                     .IdTipoComprobante = deposito.TipoComprobante.IdTipoComprobante
                     .NumeroDeposito = deposito.NumeroDeposito

                     oLibroBancos.AgregaMovimiento(entLibroBanco)
                  Next

               End With
            End If


            '# Borrar las Cuentas de Banco
            oLibroBancos.EliminarDepositosCuentasBancos(deposito.IdSucursal, deposito.NumeroDeposito, deposito.TipoComprobante.IdTipoComprobante)

         End If

         '# Anulación de Cupones
         Dim rTarjetasCupones As Reglas.TarjetasCupones = New Reglas.TarjetasCupones(da)
         Dim idSucursal As Integer = deposito.IdSucursal
         Dim numeroDeposito As Long = Long.Parse(filaAnula(Entidades.DepositosTarjetasCupones.Columnas.NumeroDeposito.ToString()).ToString())

         rTarjetasCupones.AnularCupones(idSucursal, numeroDeposito, IdTipoComprobante)

         'If Publicos.TieneModuloContabilidad And Publicos.ContabilidadEjecutarEnLinea AndAlso
         If Publicos.TieneModuloContabilidad AndAlso
            deposito.IdEjercicio.HasValue AndAlso deposito.IdPlanCuenta.HasValue AndAlso deposito.IdAsiento.HasValue Then
            Dim ctbl As Contabilidad = New Contabilidad(da)
            ctbl.AnularAsiento(deposito.IdEjercicio.Value, deposito.IdPlanCuenta.Value, deposito.IdAsiento.Value, Today)
         End If

      Next

   End Sub

#End Region

End Class