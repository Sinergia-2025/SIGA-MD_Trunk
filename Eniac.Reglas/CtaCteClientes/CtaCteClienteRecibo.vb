Public Class CtaCteClienteRecibo

   Public Function GetCtaCteCliente(idTipoComprobante As String, letraRecibo As String, numeroComprobante As Long,
                                    fecha As Date,
                                    idFormaPago As Integer,
                                    cliente As Entidades.Cliente, vendedor As Entidades.Empleado, cobrador As Entidades.Empleado,
                                    observaciones As String,
                                    importeTotal As Decimal,
                                    importeEfectivo As Decimal, importeDolares As Decimal, importeTarjetas As Decimal, importeTransferencia As Decimal,
                                    idCuentaBancaria As Integer, idCaja As Integer,
                                    pagos As List(Of Entidades.CuentaCorrientePago), cheques As List(Of Entidades.Cheque), tarjetas As List(Of Entidades.VentaTarjeta), retenciones As List(Of Entidades.Retencion),
                                    nroOrdenCompra As Long) As Entidades.CuentaCorriente
      Dim da = New Datos.DataAccess()
      Try
         da.OpenConection()
         Return GetCtaCteCliente(idTipoComprobante, letraRecibo, numeroComprobante,
                                 fecha,
                                 idFormaPago,
                                 cliente, vendedor, cobrador,
                                 observaciones,
                                 importeTotal,
                                 importeEfectivo, importeDolares, importeTarjetas, importeTransferencia,
                                 idCuentaBancaria,
                                 idCaja,
                                 pagos, cheques, tarjetas, retenciones,
                                 da,
                                 nroOrdenCompra)
      Finally
         da.CloseConection()
      End Try
   End Function

   Public Function GetCtaCteCliente(idTipoComprobante As String, letraRecibo As String, numeroComprobante As Long, fecha As Date,
                                    idFormaPago As Integer, cliente As Entidades.Cliente, vendedor As Entidades.Empleado, cobrador As Entidades.Empleado,
                                    observaciones As String,
                                    importeTotal As Decimal, importeEfectivo As Decimal, importeDolares As Decimal, importeTarjetas As Decimal, importeTransferencia As Decimal,
                                    idCuentaBancaria As Integer, idCaja As Integer,
                                    pagos As List(Of Entidades.CuentaCorrientePago),
                                    cheques As List(Of Entidades.Cheque),
                                    tarjetas As List(Of Entidades.VentaTarjeta),
                                    retenciones As List(Of Entidades.Retencion),
                                    da As Datos.DataAccess,
                                    nroOrdenCompra As Long) As Entidades.CuentaCorriente


      Dim eCtaCte = New Entidades.CuentaCorriente()

      With eCtaCte

         .TipoComprobante = New TiposComprobantes(da).GetUno(idTipoComprobante)
         .Letra = letraRecibo
         .CentroEmisor = New Impresoras(da)._GetPorSucursalPCTipoComprobante(actual.Sucursal.Id, My.Computer.Name, idTipoComprobante).CentroEmisor
         .NumeroComprobante = numeroComprobante

         'Actualiza la fecha de hoy, si se dejo la pantalla abierta mucho tiempo
         .Fecha = fecha
         .FechaVencimiento = .Fecha
         .FormaPago = New Reglas.VentasFormasPago(da).GetUna(idFormaPago)

         'cargo el cliente ----------
         .Cliente = cliente
         .Cobrador = cobrador
         .EstadoCliente = .Cliente.EstadoCliente
         .Vendedor = vendedor

         '-- REQ-35634.- ---------------------
         .NumeroOrdenCompra = nroOrdenCompra
         '------------------------------------

         .Observacion = observaciones

         'cargo valores del comprobante
         .ImporteTotal = importeTotal

         'cargo los comprobantes
         .Pagos = pagos

         'Dolares y Tickets no es automatico (por el momento)
         .ImportePesos = importeEfectivo
         .ImporteDolares = importeDolares
         .ImporteTickets = 0
         .ImporteTarjetas = importeTarjetas

         'cargo los cheques
         .Cheques = cheques

         Dim tot As Decimal = 0
         For Each ch In .Cheques
            tot += ch.Importe
         Next

         .ImporteCheques = tot

         .Tarjetas = tarjetas

         If importeTransferencia <> 0 Then
            .ImporteTransfBancaria = importeTransferencia
            .CuentaBancariaTransfBanc = New CuentasBancarias(da).GetUna(idCuentaBancaria)
            .FechaTransferencia = fecha
         End If

         'cargo las Retenciones
         .Retenciones = retenciones

         'cargo la caja
         .CajaDetalle.IdCaja = idCaja
         '
         '-- Cotizacion.- -REQ-34456-
         .CotizacionDolar = Decimal.Parse(New Reglas.Monedas().GetUna(Entidades.Moneda.Dolar).FactorConversion.ToString("N2"))

         'cargo datos generales del comprobante
         .IdSucursal = actual.Sucursal.Id
         .Usuario = actual.Nombre

         If cliente.IdClienteCtaCte > 0 Then
            .IdClienteCtaCte = cliente.IdClienteCtaCte
         Else
            .IdClienteCtaCte = cliente.IdCliente
         End If

         .IdCategoria = cliente.IdCategoria

         Dim CtaCte = New CuentasCorrientes(da)
         Dim saldo = 0D

         If Reglas.Publicos.CtaCte.CtaCteClientesSeparar Then
            'carga el saldo del cliente de la cuenta corriente 
            Dim strComprobantesAsociados = New TiposComprobantes(da).GetUno(.TipoComprobante.IdTipoComprobante).ComprobantesAsociados
            saldo = CtaCte.GetSaldoCliente({New Entidades.Sucursal() With {.Id = .IdSucursal}}, cliente.IdCliente,
                                           fechaSaldo:=Nothing, contemplaHora:=False, comprobantesAsociados:=strComprobantesAsociados, grabaLibro:=Nothing,
                                           comprobantesExcluidos:=Nothing, numeroComprobanteFinalizaCon:=String.Empty, excluirPreComprobantes:=False,
                                            IdCama:=0, IdEmbarcacion:=0)
            .SaldoCtaCte = saldo - .ImporteTotal
         Else
            saldo = CtaCte.GetSaldoCliente({New Entidades.Sucursal() With {.Id = .IdSucursal}}, cliente.IdCliente,
                                           fechaSaldo:=Nothing, contemplaHora:=False, comprobantesAsociados:="TODOS", grabaLibro:=Nothing,
                                           comprobantesExcluidos:=Nothing, numeroComprobanteFinalizaCon:=String.Empty, excluirPreComprobantes:=False,
                                           IdCama:=0, IdEmbarcacion:=0)
            .SaldoCtaCte = saldo - .ImporteTotal
         End If

      End With

      Return eCtaCte

   End Function

End Class