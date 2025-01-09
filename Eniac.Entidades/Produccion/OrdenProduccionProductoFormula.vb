Public Class OrdenProduccionProductoFormula
   Inherits Entidad
   Public Const NombreTabla As String = "OrdenesProduccionProductosFormulas"
   Public Enum Columnas
      IdSucursal
      IdTipoComprobante
      Letra
      CentroEmisor
      NumeroOrdenProduccion
      IdProducto
      Orden
      IdProductoElaborado
      IdUnicoNodoProductoElaborado
      IdProductoComponente
      IdUnicoNodoProductoComponente
      IdFormula
      SecuenciaFormula
      NombreProductoElaborado
      NombreProductoComponente
      NombreFormula
      PrecioCosto
      PrecioVenta
      Cantidad
      CantidadEnFormula
      SegunCalculoForma
      ImporteCosto
      ImporteVenta
      FormulaCalculoKilaje

   End Enum

   Public Property IdTipoComprobante As String
   Public Property Letra As String
   Public Property CentroEmisor As Integer
   Public Property NumeroOrdenProduccion As Long
   Public Property IdProducto As String
   Public Property Orden As Integer
   Public Property IdProductoElaborado As String
   Public Property IdUnicoNodoProductoElaborado As String
   Public Property IdProductoComponente As String
   Public Property IdUnicoNodoProductoComponente As String
   Public Property IdFormula As Integer
   Public Property SecuenciaFormula As Integer
   Public Property NombreProductoElaborado As String
   Public Property NombreProductoComponente As String
   Public Property NombreFormula As String
   Public Property PrecioCosto As Decimal
   Public Property PrecioVenta As Decimal
   Public Property Cantidad As Decimal
   Public Property CantidadEnFormula As Decimal
   Public Property SegunCalculoForma As Boolean
   Public Property ImporteCosto As Decimal
   Public Property ImporteVenta As Decimal
   Public Property FormulaCalculoKilaje As String
   Public Property IdDepositoDefecto As Integer                ' Datos del Producto. No se persiste. Solo para procesos. Puede no estar disponible.
   Public Property IdUbicacionDefecto As Integer               ' Datos del Producto. No se persiste. Solo para procesos. Puede no estar disponible.

End Class