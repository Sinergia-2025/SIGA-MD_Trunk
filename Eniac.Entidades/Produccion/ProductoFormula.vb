Public Class ProductoFormula
   Inherits Entidad
   Public Enum Columnas
      IdProducto
      IdFormula
      NombreFormula
      PorcentajeGanancia
   End Enum

   Public Property IdProducto As String
   Public Property IdFormula As Integer
   Public Property NombreFormula As String
   Public Property PorcentajeGanancia As Decimal
End Class