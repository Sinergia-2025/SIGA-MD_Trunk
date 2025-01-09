Public Class AduanaAgenteTransporte
   Inherits Eniac.Entidades.Entidad

   Public Enum Columnas
      IdAgenteTransporte
      NombreAgenteTransporte
      Cuit
   End Enum

   Public Sub New()
   End Sub

   Public Property IdAgenteTransporte As Integer
   Public Property NombreAgenteTransporte As String
   Public Property Cuit As String

End Class