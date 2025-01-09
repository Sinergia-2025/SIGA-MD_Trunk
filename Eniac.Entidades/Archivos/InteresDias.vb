Public Class InteresDias
   Inherits Entidad

   Public Const NombreTabla As String = "InteresesDias"

   Public Enum Columnas
      IdInteres
      DiasDesde
      DiasHasta
      Interes
   End Enum

#Region "Propiedades"
   Public Property IdInteres As Integer
   Public Property DiasDesde As Integer
   Public Property DiasHasta As Integer
   Public Property Interes As Decimal
#End Region

End Class
