Public Class ConcesionarioTipoUnidadEje
   Public Const NombreTabla As String = "ConcesionarioDistribucionEjes"

   Public Enum columnas
      IdTipoUnidadDistribucionEje
      Nombre
      DescripcionEje
      IdTipoUnidad
   End Enum

   Public Sub New()
   End Sub

#Region "Propiedades"
   Public Property IdTipoUnidadDistribucionEje As Integer
   Public Property Nombre As String
   Public Property Descripcion As String
   Public Property IdTipoUnidad As Integer
#End Region
End Class
