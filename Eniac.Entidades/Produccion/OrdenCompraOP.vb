<Serializable()>
<Description("OrdenCompra")>
Public Class OrdenCompraOP
   Inherits Eniac.Entidades.Entidad

   Public Enum Columnas
      NumeroOrdenCompra
      IdProveedor
      IdFormasPago
      FechaPedidos
      Usuario

   End Enum

   Public Property NumeroOrdenCompra() As Long
   Public Property IdProveedor() As Long
   Public Property IdFormasPago() As Integer
   Public Property FechaPedidos() As DateTime

End Class