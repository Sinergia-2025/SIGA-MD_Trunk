Public Class RepartoCobranzaProducto
   Inherits Entidad

   Public Const NombreTabla As String = "RepartosCobranzasProductos"

   Public Enum Columnas
      IdSucursal
      IdReparto
      IdCobranza
      IdSucursalComp
      IdTipoComprobanteComp
      LetraComp
      CentroEmisorComp
      NumeroComprobanteComp
      IdProducto
      Orden
      CantidadDevuelta
      IdEstadoVenta

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
   Public Property IdProducto As String
   Public Property Orden As Integer
   Public Property CantidadDevuelta As Decimal
   Public Property IdEstadoVenta As Integer


   Public Property NombreEstadoNovedad As String

End Class