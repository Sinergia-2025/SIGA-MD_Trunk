Imports System.ComponentModel

Partial Class CuentasCorrientes
   Public Function GetParaSincronizacionMovilDebeHaber(mesesEnviar As Integer, sucs As IEnumerable(Of Integer)) As DataTable
      Return New SqlServer.CuentasCorrientes(da).GetParaSincronizacionMovilDebeHaber(mesesEnviar, sucs)
   End Function

   Private _cacheFormaPagoParaRecibo As Entidades.VentaFormaPago
   Public Function GetFormaPagoParaRecibo() As Entidades.VentaFormaPago
      If _cacheFormaPagoParaRecibo Is Nothing Then
         _cacheFormaPagoParaRecibo = New VentasFormasPago(da).GetUna("VENTAS", True)
      End If
      Return _cacheFormaPagoParaRecibo
   End Function

   Private _cacheImpresoras As Dictionary(Of String, Entidades.Impresora) = New Dictionary(Of String, Entidades.Impresora)()
   Private Function GetImpresora(tipoComprobante As String) As Entidades.Impresora
      If Not _cacheImpresoras.ContainsKey(tipoComprobante) Then
         Dim impresora = New Eniac.Reglas.Impresoras(da)._GetPorSucursalPCTipoComprobante(actual.Sucursal.Id, My.Computer.Name, tipoComprobante)
         _cacheImpresoras.Add(tipoComprobante, impresora)
      End If
      Return _cacheImpresoras(tipoComprobante)
   End Function
   Friend Function GrabaReciboAutomaticamente(tipoRecibo As Entidades.TipoComprobante,
                                              fechaRecibo As DateTime?,
                                              cliente As Entidades.Cliente,
                                              vendedor As Eniac.Entidades.Empleado,
                                              idCaja As Integer,
                                              observaciones As String,
                                              cotizacionDolar As Decimal?,
                                              importeEfectivo As Decimal,
                                              importeDolares As Decimal,
                                              importeTickets As Decimal,
                                              importeTransferencia As Decimal,
                                              ctaBancaria As Eniac.Entidades.CuentaBancaria,
                                              fechaTransferencia As DateTime?,
                                              cheques As List(Of Eniac.Entidades.Cheque),
                                              tarjetas As List(Of Entidades.VentaTarjeta),
                                              retenciones As List(Of Entidades.Retencion),
                                              comprobantesAfectados As List(Of Entidades.CuentaCorrientePago),
                                              numeroReparto As Integer?,
                                              idFuncion As String) As Entidades.CuentaCorriente
      Dim oCtaCte = New Entidades.CuentaCorriente()
      With oCtaCte
         .TipoComprobante = tipoRecibo

         If tipoRecibo.LetrasHabilitadas = "X" Or tipoRecibo.LetrasHabilitadas = "R" Then
            .Letra = tipoRecibo.LetrasHabilitadas
         Else
            If cliente IsNot Nothing Then
               .Letra = cliente.CategoriaFiscal.LetraFiscal
            End If
         End If

         .CentroEmisor = GetImpresora(.TipoComprobante.IdTipoComprobante).CentroEmisor
         .NumeroComprobante = 0

         'Actualiza la fecha de hoy, si se dejo la pantalla abierta mucho tiempo
         If fechaRecibo.HasValue Then
            .Fecha = fechaRecibo.Value.Date.Add(Now.TimeOfDay)
         Else
            .Fecha = Date.Now
         End If
         .FechaVencimiento = .Fecha

         .FormaPago = GetFormaPagoParaRecibo()
         .NumeroReparto = numeroReparto

         'cargo el cliente ----------
         .Cliente = cliente
         .IdCategoria = .Cliente.IdCategoria
         .Vendedor = vendedor

         .Observacion = observaciones

         'cargo los comprobantes
         .Pagos = comprobantesAfectados

         If cotizacionDolar.HasValue Then
            .CotizacionDolar = cotizacionDolar.Value
         Else
            .CotizacionDolar = 0
         End If

         'cargo el efectivo para tenerlo discriminado
         .ImportePesos = importeEfectivo
         .ImporteDolares = importeDolares
         .ImporteTickets = importeTickets

         .ImporteTransfBancaria = importeTransferencia
         .CuentaBancariaTransfBanc = ctaBancaria
         .FechaTransferencia = fechaTransferencia

         .Cheques = cheques
         .ImporteCheques = If(cheques Is Nothing, 0, cheques.Sum(Function(x) x.Importe))

         .Tarjetas = tarjetas
         .ImporteTarjetas = If(tarjetas Is Nothing, 0, tarjetas.Sum(Function(x) x.Monto))

         .Retenciones = retenciones
         .ImporteRetenciones = If(retenciones Is Nothing, 0, retenciones.Sum(Function(x) x.ImporteTotal))


         'cargo valores del comprobante
         .ImporteTotal = .ImportePesos + (.ImporteDolares * .CotizacionDolar) + .ImporteTickets + .ImporteTransfBancaria + .ImporteCheques + .ImporteTarjetas + .ImporteRetenciones

         ' '' ''cargo los cheques
         '' ''If cheques IsNot Nothing Then
         '' ''   .Cheques = New List(Of Eniac.Entidades.Cheque)() '' Me._cheques
         '' ''   For Each drCheque In cheques
         '' ''      Dim cheque As Eniac.Entidades.Cheque = New Eniac.Entidades.Cheque()

         '' ''      With cheque
         '' ''         .NumeroCheque = drCheque.NumeroCheque
         '' ''         .Banco = New Eniac.Reglas.Bancos().GetUno(drCheque.IdBanco)
         '' ''         .IdBancoSucursal = drCheque.IdBancoSucursal
         '' ''         .Localidad.IdLocalidad = drCheque.IdLocalidad
         '' ''         .FechaEmision = drCheque.FechaEmision
         '' ''         .FechaCobro = drCheque.FechaCobro
         '' ''         .Titular = drCheque.Titular
         '' ''         .Importe = drCheque.Importe
         '' ''         .Cliente.CodigoCliente = drCheque.CodigoCliente
         '' ''         .Usuario = drCheque.Usuario
         '' ''         .IdEstadoCheque = Eniac.Entidades.Cheque.Estados.ENCARTERA
         '' ''      End With

         '' ''      .Cheques.Add(cheque)
         '' ''   Next
         '' ''End If
         '' ''.ImporteCheques = importeCheque

         'cargo la caja
         .CajaDetalle.IdCaja = idCaja

         'cargo datos generales del comprobante
         .IdSucursal = actual.Sucursal.Id
         .Usuario = actual.Nombre
         .IdEstado = "NORMAL"
      End With

      My.Application.Log.WriteEntry("Recibos-Inserta registro.", TraceEventType.Verbose)
      Inserta(oCtaCte, Eniac.Entidades.Entidad.MetodoGrabacion.Automatico, idFuncion)
      My.Application.Log.WriteEntry("Recibos-Termino de Insertar registro.", TraceEventType.Verbose)

      Return oCtaCte

   End Function

   Public Sub ActualizarNumeroReparto(comprobante As Entidades.Venta, numeroReparto As Integer?)
      ActualizarNumeroReparto(comprobante.IdSucursal, comprobante.IdTipoComprobante, comprobante.LetraComprobante, comprobante.CentroEmisor, comprobante.NumeroComprobante, numeroReparto)
   End Sub
   Public Sub ActualizarNumeroReparto(idSucursal As Integer, idTipoComprobante As String, letra As String, centroEmisor As Integer, numeroComprobante As Long,
                                      numeroReparto As Integer?)
      EjecutaConTransaccion(Sub() _ActualizarNumeroReparto(idSucursal, idTipoComprobante, letra, centroEmisor, numeroComprobante, numeroReparto))
   End Sub
   Public Sub _ActualizarNumeroReparto(comprobante As Entidades.Venta, numeroReparto As Integer?)
      _ActualizarNumeroReparto(comprobante.IdSucursal, comprobante.IdTipoComprobante, comprobante.LetraComprobante, comprobante.CentroEmisor, comprobante.NumeroComprobante, numeroReparto)
   End Sub

   Public Sub _ActualizarNumeroReparto(idSucursal As Integer, idTipoComprobante As String, letra As String, centroEmisor As Integer, numeroComprobante As Long,
                                       numeroReparto As Integer?)
      Dim sql = New SqlServer.CuentasCorrientes(da)
      sql.ActualizarNumeroReparto(idSucursal, idTipoComprobante, letra, centroEmisor, numeroComprobante, numeroReparto)
   End Sub

End Class