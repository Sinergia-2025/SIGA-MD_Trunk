Public Class ProduccionForma
   Inherits Entidad
   Public Const NombreTabla As String = "ProduccionFormas"
   Public Enum Columnas
      IdProduccionForma
      NombreProduccionForma
      FormulaCalculoKilaje
   End Enum

   Public Property IdProduccionForma As Integer
   Public Property NombreProduccionForma As String
   Public Property FormulaCalculoKilaje As String

End Class