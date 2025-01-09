Public Class PedidoObservacionProveedor
   Inherits Entidad

   Public Enum Columnas
      IdSucursal
      IdTipoComprobante
      Letra
      CentroEmisor
      NumeroPedido
      Linea
      Observacion
   End Enum

   Public Property IdTipoComprobante As String
   Public Property Letra As String
   Public Property CentroEmisor As Integer
   Public Property NumeroPedido As Long
   Public Property Linea As Integer
   Public Property Observacion As String

End Class