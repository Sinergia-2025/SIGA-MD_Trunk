Namespace JSonEntidades.Concesionarios.Alcorta
   Public Class TipoUnidadEje
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
      Public Class DistribucionEjeResponse
         Public Enum Campos
            sync
         End Enum
         Public Property sync As Boolean
      End Class
   End Class
End Namespace
