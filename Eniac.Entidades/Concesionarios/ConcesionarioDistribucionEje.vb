Public Class ConcesionarioDistribucionEje
   Inherits Entidades.Entidad

   Public Const NombreTabla As String = "ConcesionarioDistribucionEjes"

   Public Enum columnas
      IdEje
      NombreEje
      DescripcionEje
      IdTipoUnidad
   End Enum

   Public Sub New()
   End Sub

#Region "Propiedades"
   Public Property IdEje As Integer
   Public Property NombreEje As String
   Public Property DescripcionEje As String
   Public Property IdTipoUnidad As Integer
#End Region
End Class
