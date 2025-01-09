Public Class RepartoProductoSinDescargar
   Inherits Entidad
   Public Const NombreTabla As String = "RepartosProductosSinDescargar"
   Public Enum Columnas
      IdSucursal
      IdReparto
      IdProducto
      NombreProducto
      Cantidad
      Precio
   End Enum

   Public Property IdReparto As Integer
   Public Property IdProducto As String
   Public Property NombreProducto As String
   Public Property Cantidad As Decimal
   Public Property Precio As Decimal

End Class
