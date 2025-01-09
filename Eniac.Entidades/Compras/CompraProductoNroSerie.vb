Public Class CompraProductoNroSerie
   Inherits Entidad

   Public Const NombreTabla As String = "ComprasProductosNrosSerie"

   Public Enum Columnas
      IdSucursal
      IdTipoComprobante
      Letra
      CentroEmisor
      NumeroComprobante
      Orden
      IdProveedor
      IdProducto
      NroSerie
   End Enum

   Public Property IdTipoComprobante As String
   Public Property Letra As String
   Public Property CentroEmisor As Integer
   Public Property NumeroComprobante As Long
   Public Property Orden As Integer
   Public Property IdProveedor As Long
   Public Property IdProducto As String
   Public Property NroSerie As String
End Class
