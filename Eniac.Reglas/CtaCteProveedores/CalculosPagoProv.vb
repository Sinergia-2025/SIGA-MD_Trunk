Public Class CalculosPagoProv
   Public Shared Function CalcularPromedioPago(fechaAplicacionPago As Date,
                                               comprobantes As IEnumerable(Of Entidades.CuentaCorrienteProvPago),
                                               pesos As Decimal, dolares As Decimal, tarjetas As Decimal, tickets As Decimal,
                                               transferencia As Decimal, fechaTransf As Date?,
                                               chequesPropios As IEnumerable(Of Entidades.Cheque),
                                               chequesTerceros As IEnumerable(Of Entidades.Cheque),
                                               retenciones As IEnumerable(Of Entidades.RetencionCompra)) As CalculosPagoProvResult

      Dim pagos = New List(Of Tuple(Of String, Date, Decimal))()
      pagos.AddRange(chequesPropios.ToList().ConvertAll(Function(c) PagosTuple.Parse(c)))
      pagos.AddRange(chequesTerceros.ToList().ConvertAll(Function(c) PagosTuple.Parse(c)))
      If pesos <> 0 Then
         pagos.Add(New PagosTuple("Pesos", fechaAplicacionPago, pesos))
      End If
      If dolares <> 0 Then
         pagos.Add(New PagosTuple("Dolares", fechaAplicacionPago, dolares))
      End If
      If tarjetas <> 0 Then
         pagos.Add(New PagosTuple("Tarjetas", fechaAplicacionPago, tarjetas))
      End If
      If tickets <> 0 Then
         pagos.Add(New PagosTuple("Tickets", fechaAplicacionPago, tickets))
      End If
      If transferencia <> 0 AndAlso fechaTransf.HasValue Then
         pagos.Add(New PagosTuple("Transferencia", fechaTransf.Value, transferencia))
      End If
      pagos.AddRange(retenciones.ToList().ConvertAll(Function(r) PagosTuple.Parse(r)))

      Return CalcularPromedioPago(fechaAplicacionPago, comprobantes, pagos)
   End Function
   Public Shared Function CalcularPromedioPago(fechaAplicacionPago As Date,
                                               comprobantes As IEnumerable(Of Entidades.CuentaCorrienteProvPago),
                                               pagos As IEnumerable(Of Tuple(Of String, Date, Decimal))) As CalculosPagoProvResult
      Dim result = New CalculosPagoProvResult(fechaAplicacionPago)
      result.Comprobantes.AddRange(comprobantes.ToList().ConvertAll(Function(c) Convert(result, c)))
      result.Pagos.AddRange(pagos.ToList().ConvertAll(Function(p) Convert(result, p)))
      Return result
   End Function
   Private Shared Function Convert(result As CalculosPagoProvResult, origen As Entidades.CuentaCorrienteProvPago) As CalculosPagoProvComprobante
      Return New CalculosPagoProvComprobante(origen.Fecha, origen.ImporteCuota, origen.SaldoCuota, origen.Paga,
                                             AddressOf result.CalculaPrimarPago)
   End Function
   Private Shared Function Convert(result As CalculosPagoProvResult, origen As Tuple(Of String, Date, Decimal)) As CalculosPagoProvMediosPago
      Return New CalculosPagoProvMediosPago(origen.Item1, origen.Item2, origen.Item3, AddressOf result.GetFechaPromedioComprobantes)
   End Function
End Class
Public Class PagosTuple
   Inherits Tuple(Of String, Date, Decimal)
   Public Sub New(item1 As String, item2 As Date, item3 As Decimal)
      MyBase.New(item1, item2, item3)
   End Sub
   Public Shared Function Parse(c As Entidades.Cheque) As PagosTuple
      Return New PagosTuple(String.Format("{0} {1}", c.NombreBanco, c.NumeroCheque), c.FechaCobro, c.Importe)
   End Function
   Public Shared Function Parse(r As Entidades.RetencionCompra) As PagosTuple
      Return New PagosTuple(r.NombreTipoImpuesto, r.FechaEmision, r.ImporteTotal)
   End Function
End Class
Public Class CalculosPagoProvResult
   Public Property FechaAplicacionPago As Date

   Public Sub New(fechaAplicacionPago As Date)
      _FechaAplicacionPago = fechaAplicacionPago.Date
      Comprobantes = New List(Of CalculosPagoProvComprobante)
      Pagos = New List(Of CalculosPagoProvMediosPago)
   End Sub

   Public ReadOnly Property Comprobantes As ICollection(Of CalculosPagoProvComprobante)
   Public ReadOnly Property Pagos As ICollection(Of CalculosPagoProvMediosPago)

   Public ReadOnly Property ImporteTotalPagar As Decimal
      Get
         Return Comprobantes.SumSecure(Function(c) c.Paga).IfNull()
      End Get
   End Property
   Public ReadOnly Property ImporteTotalPonderado As Decimal
      Get
         Return Comprobantes.SumSecure(Function(c) c.ImportePonderado).IfNull()
      End Get
   End Property
   Public ReadOnly Property ImportePagoTotalPonderado As Decimal
      Get
         Return Pagos.SumSecure(Function(c) c.ImportePonderado).IfNull()
      End Get
   End Property
   Public ReadOnly Property DiasPromedioEmision As Decimal
      Get
         Return If(ImporteTotalPagar = 0, 0D, ImporteTotalPonderado / ImporteTotalPagar)
      End Get
   End Property
   Public ReadOnly Property FechaPrimerPago As Date?
      Get
         Return CalculaPrimarPago()
      End Get
   End Property
   Public ReadOnly Property FechaPromedioComprobantes As Date
      Get
         Return FechaPrimerPago.IfNull(FechaAplicacionPago).AddDays(Math.Round(DiasPromedioEmision, 0) - 1)
      End Get
   End Property
   Public ReadOnly Property DiasPromedioPago As Decimal
      Get
         Return If(ImporteTotalPagar = 0, 0, ImportePagoTotalPonderado / ImporteTotalPagar)
      End Get
   End Property
   Public ReadOnly Property FechaPromedioPago As Date
      Get
         Return FechaAplicacionPago.AddDays(Math.Round(DiasPromedioPago, 0))
      End Get
   End Property

   Public Function CalculaPrimarPago() As Date?
      If Comprobantes Is Nothing Then Return Nothing
      Return Comprobantes.MinSecure(Function(c) c.FechaEmision)
   End Function

   Public Function GetFechaPromedioComprobantes() As Date
      Return FechaPromedioComprobantes
   End Function

End Class
Public Class CalculosPagoProvComprobante
   Private Property FechaPrimerPago As Func(Of Date?)
   Public Property FechaEmision As Date
   Public Property ImporteTotal As Decimal
   Public Property Saldo As Decimal
   Public Property Paga As Decimal

   Public Sub New(fechaEmision As Date, importeTotal As Decimal, saldo As Decimal, paga As Decimal, fechaPrimerPago As Func(Of Date?))
      _FechaPrimerPago = fechaPrimerPago
      _FechaEmision = fechaEmision.Date
      _ImporteTotal = importeTotal
      _Saldo = saldo
      _Paga = paga
   End Sub

   Public ReadOnly Property DiasFechaComprobante As Integer
      Get
         If FechaPrimerPago().Invoke().HasValue Then
            Return Math.Round(FechaEmision.Subtract(FechaPrimerPago().Invoke().Value).TotalDays, 0).ToInteger()
         End If
         Return 0
      End Get
   End Property
   Public ReadOnly Property ImportePonderado As Decimal
      Get
         Return Paga * DiasFechaComprobante
      End Get
   End Property
End Class
Public Class CalculosPagoProvMediosPago
   Private Property FechaPromedioComprobantes As Func(Of Date?)
   Public Property ReferenciaMedioPago As String
   Public Property FechaCobro As Date
   Public Property Importe As Decimal

   Public Sub New(referenciaMedioPago As String, fechaCobro As Date, importe As Decimal, fechaPromedioComprobantes As Func(Of Date?))
      _ReferenciaMedioPago = referenciaMedioPago
      _FechaCobro = fechaCobro.Date
      _Importe = importe
      _FechaPromedioComprobantes = fechaPromedioComprobantes
   End Sub

   Public ReadOnly Property DiasFechaMedioPago As Integer
      Get
         If FechaPromedioComprobantes().Invoke().HasValue Then
            Return Math.Round(FechaCobro.Date.Subtract(FechaPromedioComprobantes().Invoke().Value).TotalDays, 0).ToInteger()
         End If
         Return 0
      End Get
   End Property
   Public ReadOnly Property ImportePonderado As Decimal
      Get
         Return Importe * DiasFechaMedioPago
      End Get
   End Property

End Class