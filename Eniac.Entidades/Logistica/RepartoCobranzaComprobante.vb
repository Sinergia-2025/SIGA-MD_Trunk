Public Class RepartoCobranzaComprobante
   Inherits Entidad

   Public Const NombreTabla As String = "RepartosCobranzasComprobantes"

   Public Enum Columnas
      IdSucursal
      IdReparto
      IdCobranza
      IdSucursalComp
      IdTipoComprobanteComp
      LetraComp
      CentroEmisorComp
      NumeroComprobanteComp
      MedioPagoSeleccionado
      SaldoComprobante
      TotalEfectivo
      TotalCuentaCorriente
      TotalCheques
      TotalNC
      TotalAplicado
      TotalReenvio

      TotalTransferencia
      IdCuentaBancaria
      FechaTransferencia

      IdSucursalRecibo
      IdTipoComprobanteRecibo
      LetraRecibo
      CentroEmisorRecibo
      NumeroComprobanteRecibo

   End Enum

   Public Sub New()
      Productos = New List(Of RepartoCobranzaProducto)()
      Cheques = New List(Of RepartoCobranzaCheque)()
      NCAplicadas = New List(Of RepartoCobranzaNCAplicada)()
   End Sub

   Public Property IdReparto As Integer
   Public Property IdCobranza As Integer
   Public Property IdSucursalComp As Integer
   Public Property IdTipoComprobanteComp As String
   Public Property LetraComp As String
   Public Property CentroEmisorComp As Short
   Public Property NumeroComprobanteComp As Long
   Public Property MedioPagoSeleccionado As String
   Public Property SaldoComprobante As Decimal
   Public Property TotalEfectivo As Decimal
   Public Property TotalTransferencia As Decimal
   Public Property IdCuentaBancaria As Integer?
   Public Property FechaTransferencia As Date?
   Public Property TotalCuentaCorriente As Decimal
   Public Property TotalCheques As Decimal
   Public Property TotalNC As Decimal
   Public Property TotalAplicado As Decimal
   Public Property TotalReenvio As Decimal

   Public Property IdSucursalRecibo As Integer
   Public Property IdTipoComprobanteRecibo As String
   Public Property LetraRecibo As String
   Public Property CentroEmisorRecibo As Short
   Public Property NumeroComprobanteRecibo As Long

   Public Property Productos As List(Of RepartoCobranzaProducto)
   Public Property Cheques As List(Of RepartoCobranzaCheque)
   Public Property NCAplicadas As List(Of RepartoCobranzaNCAplicada)

End Class