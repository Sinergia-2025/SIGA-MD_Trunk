Public Structure ProductosSinStock
   Public Sub New(producto As Entidades.ProductoLivianoParaControlStock, cantidad As Decimal, stock As Decimal)
      Me.Producto = producto
      Me.Cantidad = cantidad
      Me.Stock = stock
   End Sub
   Public Property Producto As Entidades.ProductoLivianoParaControlStock
   Public Property Cantidad As Decimal
   Public Property Stock As Decimal
End Structure