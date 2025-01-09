<Serializable()>
<Description("OrdenCompra")>
Public Class OrdenCompraOrdenProduccion
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
   Public Property IdCliente() As Long
   Public Property TipoComprobante() As Entidades.TipoComprobante
   Public Property LetraComprobante() As String
   Public Property CentroEmisor() As Short
   Public Property NumeroPedido() As Long

End Class