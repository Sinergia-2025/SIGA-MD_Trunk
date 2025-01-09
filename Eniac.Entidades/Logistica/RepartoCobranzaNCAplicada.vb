Public Class RepartoCobranzaNCAplicada
   Inherits Entidad

   Public Const NombreTabla As String = "RepartosCobranzasNCAplicadas"

   Public Enum Columnas
      IdSucursal
      IdReparto
      IdCobranza
      IdSucursalComp
      IdTipoComprobanteComp
      LetraComp
      CentroEmisorComp
      NumeroComprobanteComp
      IdSucursalNC
      IdTipoComprobanteNC
      LetraNC
      CentroEmisorNC
      NumeroComprobanteNC
      SaldoComprobante
      ImporteAplicado

   End Enum

   Public Sub New()

   End Sub

   Public Property IdReparto As Integer
   Public Property IdCobranza As Integer
   Public Property IdSucursalComp As Integer
   Public Property IdTipoComprobanteComp As String
   Public Property LetraComp As String
   Public Property CentroEmisorComp As Short
   Public Property NumeroComprobanteComp As Long
   Public Property IdSucursalNC As Integer
   Public Property IdTipoComprobanteNC As String
   Public Property LetraNC As String
   Public Property CentroEmisorNC As Short
   Public Property NumeroComprobanteNC As Long
   Public Property SaldoComprobante As Decimal
   Public Property ImporteAplicado As Decimal

End Class