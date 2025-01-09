Public Class ProductoDeposito
   Inherits Entidad

   Public Const NombreTabla As String = "ProductosDepositos"
   Public Enum Columnas
      IdProducto
      IdSucursal
      IdDeposito
      Stock
      Stock2
      FechaActualizacion
      idUbicacion
   End Enum

   Public Property IdProducto As String
   Public Property IdSucursal As Integer
   Public Property IdDeposito As Integer
   Public Property Stock As Decimal
   Public Property Stock2 As Decimal
   Public Property FechaActualizacion As DateTime
   Public Property IdUbicacion As Integer
End Class
