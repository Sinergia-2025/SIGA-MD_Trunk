Public Class ReservaTurismoPasajero
   Inherits Entidad

   Public Const NombreTabla As String = "ReservasTurismoPasajeros"

   Public Enum Columnas
      IdSucursal
      IdTipoReserva
      Letra
      CentroEmisor
      NumeroReserva
      IdPasajero
      IdResponsablePasajero
      IdSucursalComprobante
      IdTipoComprobante
      LetraComprobante
      CentroEmisorComprobante
      NumeroComprobante
      PorcentajeLiberado
      Costo
      NombrePasajero
      NombreResponsable
      IdClientePasajero

      IdSucursalComprobanteFact
      IdTipoComprobanteFact
      LetraComprobanteFact
      CentroEmisorComprobanteFact
      NumeroComprobanteFact

   End Enum

   Public Property IdTipoReserva As String
   Public Property Letra As String
   Public Property CentroEmisor As Short
   Public Property NumeroReserva As Long
   Public Property IdPasajero As Integer
   Public Property IdResponsablePasajero As Long
   Public Property IdTipoComprobante As String
   Public Property LetraComprobante As String
   Public Property CentroEmisorComprobante As Integer
   Public Property NumeroComprobante As Long
   Public Property PorcentajeLiberado As Decimal
   Public Property Costo As Decimal
   Public Property NombrePasajero As String
   Public Property NombreResponsable As String
   Public Property IdClientePasajero As Long

   Public Property IdSucursalComprobanteFact As Integer
   Public Property IdTipoComprobanteFact As String
   Public Property LetraComprobanteFact As String
   Public Property CentroEmisorComprobanteFact As Integer
   Public Property NumeroComprobanteFact As Long

End Class