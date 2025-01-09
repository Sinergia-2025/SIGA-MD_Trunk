
Public Class CategoriaAccion
   Inherits Eniac.Entidades.Entidad

   Public Enum Columnas
      IdCategoriaAccion
      NombreCategoriaAccion
      Pies
      CoeficienteDistribucionExpensas
   End Enum

   Public Property IdCategoriaAccion As Integer
   Public Property NombreCategoriaAccion As String
   Public Property Pies As Integer
   Public Property CoeficienteDistribucionExpensas As Decimal

End Class