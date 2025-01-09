Public Class OrdenProduccionObservacion
   Inherits Eniac.Entidades.Entidad

   Public Enum Columnas
      IdSucursal
      IdTipoComprobante
      Letra
      CentroEmisor
      NumeroOrdenProduccion
      Linea
      Observacion
   End Enum

   Public Property IdTipoComprobante As String
   Public Property Letra As String
   Public Property CentroEmisor As Integer
   Public Property NumeroOrdenProduccion As Long
   Public Property Linea As Integer
   Public Property Observacion As String

End Class