Public Class UnidadDeMedidaConversion
   Inherits Entidad

   Public Const NombreTabla As String = "UnidadesDeMedidasConversiones"

   Public Enum Columnas
      IdUnidadMedidaDesde
      IdUnidadMedidaHacia
      FactorConversion
      Fija

   End Enum

   Public Sub New()
      Fija = True
   End Sub

   Public Property IdUnidadMedidaDesde As String
   Public Property IdUnidadMedidaHacia As String
   Public Property FactorConversion As Decimal
   Public Property Fija As Boolean

End Class