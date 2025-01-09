Public Class ProductoUbicacion
   Inherits Entidad

   Public Const NombreTabla As String = "ProductosUbicaciones"
   Public Enum Columnas
      IdProducto
      IdSucursal
      IdDeposito
      IdUbicacion
      Stock
      Stock2
      FechaActualizacion
   End Enum

   Public Property IdProducto As String
   Public Property IdSucursal As Integer
   Public Property IdDeposito As Integer
   Public Property IdUbicacion As Integer
   Public Property Stock As Decimal
   Public Property Stock2 As Decimal
   Public Property FechaActualizacion As DateTime

End Class
