Public Class ProductoOferta
   Inherits Eniac.Entidades.Entidad
   Public Const NombreTabla As String = "ProductosOfertas"
   Public Enum Columnas
      IdProducto
      IdOferta
      PrecioOferta
      LimiteStock
      CantidadConsumida
      FechaDesde
      FechaHasta
      Activa
   End Enum
   Public Property IdProducto As String
   Public Property IdOferta As Integer
   Public Property FechaDesde As Date
   Public Property FechaHasta As Date
   Public Property LimiteStock As Decimal
   Public Property CantidadConsumida As Decimal
   Public Property PrecioOferta As Decimal
   Public Property Activa As Boolean

   'Public Property ProductosOfertas() As List(Of ProductosOfertas)

End Class
