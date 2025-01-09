<Serializable()>
<Description("OrdenCompra")>
Public Class OrdenCompraPedido
   Inherits Eniac.Entidades.Entidad

   Public Enum Columnas
      NumeroOrdenCompra
      IdSucursal
      IdTipoComprobante
      Letra
      CentroEmisor
      NumeroPedido
      IdCliente
   End Enum

   Public Property NumeroOrdenCompra() As Long
   Public Overloads Property IdSucursal() As Integer
   Public Property IdCliente() As Long
   Public Property TipoComprobante() As Entidades.TipoComprobante
   Public Property LetraComprobante() As String
   Public Property CentroEmisor() As Short
   Public Property NumeroPedido() As Long

End Class