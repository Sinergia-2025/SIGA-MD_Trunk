Public Class ReservaTurismoProductoFacturacion
   Inherits Entidad

   Public Const NombreTabla As String = "ReservasTurismoProductosFacturacion"

   Public Enum Columnas
      IdSucursal
      IdTipoReserva
      Letra
      CentroEmisor
      NumeroReserva
      IdProducto
      Orden
      Cantidad
      Precio
      AlicuotaIVA
      ImporteTotal
   End Enum

   Public Property IdTipoReserva As String
   Public Property Letra As String
   Public Property CentroEmisor As Short
   Public Property NumeroReserva As Long
   Public Property IdProducto As String
   Public Property NombreProducto As String     'No persistido. Solo para mistrar en grillas
   Public Property Orden As Integer
   Public Property Cantidad As Decimal
   Public Property Precio As Decimal
   Public Property AlicuotaIVA As Decimal
   Public Property ImporteTotal As Decimal

End Class