Public Class AduanaDespachante
   Inherits Eniac.Entidades.Entidad

   Public Enum Columnas
      IdDespachante
      NombreDespachante
      Cuit
   End Enum

   Public Sub New()
   End Sub

   Public Property IdDespachante As Integer
   Public Property NombreDespachante As String
   Public Property Cuit As String

End Class