Public Class CuentaCorrienteRetencion
   Inherits Entidad
   Public Const NombreTabla As String = "CuentasCorrientesRetenciones"

   Public Enum Columnas
      IdSucursal
      IdTipoComprobante
      Letra
      CentroEmisor
      NumeroComprobante
      IdTipoImpuesto
      EmisorRetencion
      NumeroRetencion
      IdCliente
      IdRetencion

   End Enum

   Public Property IdTipoComprobante As String
   Public Property Letra As String
   Public Property CentroEmisor As Integer
   Public Property NumeroComprobante As Long

   Public Property IdTipoImpuesto As TipoImpuesto
   Public Property EmisorRetencion As Integer
   Public Property NumeroRetencion As Long
   Public Property IdCliente As Long

   Public Property IdRetencion As Integer

End Class