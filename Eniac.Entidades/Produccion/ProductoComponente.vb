<Serializable()>
Public Class ProductoComponente
   Inherits Entidad

   Public Const NombreTabla As String = "ProductosComponentes"
   Public Enum Columnas
      IdProducto
      IdProductoComponente
      Cantidad
      IdFormula
      SegunCalculoForma
      IdFormulaComponente
      IdUnidadDeMedidaProduccion
      CantidadUMProduccion
      FactorConversionProduccion
   End Enum

   Public Sub New()
      IdProducto = String.Empty
      IdProductoComponente = String.Empty
      IdUnidadDeMedidaProduccion = String.Empty
   End Sub

   Public Property IdProducto As String
   Public Property IdProductoComponente As String
   Public Property Cantidad As Decimal
   Public Property IdFormula As Integer
   Public Property SegunCalculoForma As Boolean
   Public Property IdFormulaComponente As Integer

   Public Property IdUnidadDeMedidaProduccion As String
   Public Property CantidadUMProduccion As Decimal
   Public Property FactorConversionProduccion As Decimal

End Class