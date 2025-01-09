Public Class PedidoObservacion
   Inherits Eniac.Entidades.Entidad

   Public Enum Columnas
      IdSucursal
      IdTipoComprobante
      Letra
      CentroEmisor
      NumeroPedido
      Linea
      Observacion
      IdTipoObservacion
      DescripcionTipoObservacion
   End Enum

   Public Property IdTipoComprobante As String
   Public Property Letra As String
   Public Property CentroEmisor As Integer
   Public Property NumeroPedido As Long
   Public Property Linea As Integer
   Public Property Observacion As String
   Public Property IdTipoObservacion As Short
   Public Property DescripcionTipoObservacion As String

End Class