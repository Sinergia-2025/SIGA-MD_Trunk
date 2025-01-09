Public Class VentaProductoFormulaLote
   Inherits Entidad
   Public Const NombreTabla As String = "VentasProductosFormulasLotes"
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
      IdLote
      FechaVencimiento
      Cantidad
      IdDeposito
      IdUbicacion

   End Enum

   Public Property IdTipoComprobante As String
   Public Property Letra As String
   Public Property CentroEmisor As Integer
   Public Property NumeroComprobante As Long
   Public Property IdProducto As String
   Public Property Orden As Integer
   Public Property IdProductoComponente As String
   Public Property IdFormula As Integer

   Public Property IdLote As String
   Public Property FechaVencimiento As Date?
   Public Property Cantidad As Decimal
   Public Property IdDeposito As Integer
   Public Property IdUbicacion As Integer

End Class