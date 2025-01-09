Public Class VentaProductoNroSerie
   Inherits Entidad

   Public Const NombreTabla As String = "VentasProductosNrosSerie"

   Public Enum Columnas
      IdSucursal
      IdTipoComprobante
      Letra
      CentroEmisor
      NumeroComprobante
      Orden
      IdProducto
      NroSerie
   End Enum

   Public Property IdTipoComprobante As String
   Public Property Letra As String
   Public Property CentroEmisor As Integer
   Public Property NumeroComprobante As Long
   Public Property Orden As Integer
   Public Property IdProducto As String
   Public Property NroSerie As String

End Class
