Public Class VentaProductoFormulaNroSerie
   Inherits Entidad
   Public Const NombreTabla As String = "VentasProductosFormulasNrosSerie"
   Public Enum Columnas
      IdSucursal
      IdTipoComprobante
      Letra
      CentroEmisor
      NumeroComprobante
      IdProducto
      Orden
      IdProductoComponente
      IdFormula
      NroSerie

   End Enum

   Public Property IdTipoComprobante As String
   Public Property Letra As String
   Public Property CentroEmisor As Integer
   Public Property NumeroComprobante As Long
   Public Property IdProducto As String
   Public Property Orden As Integer
   Public Property IdProductoComponente As String
   Public Property IdFormula As Integer

   Public Property NroSerie As String

End Class