Public Class ConcesionarioTipoUnidad
   Inherits Entidades.Entidad

   Public Const NombreTabla = "ConcesionarioTiposUnidades"

   Public Enum columnas
      IdTipoUnidad
      NombreTipoUnidad
      DescripcionTipoUnidad
      MuestraEnCerokm
      MuestraEnUsado
      SolicitaDistribucionEje
   End Enum

#Region "Propiedades"
   Public Property IdTipoUnidad As Integer
   Public Property NombreTipoUnidad As String
   Public Property DescripcionTipoUnidad As String
   Public Property MuestraEnCerokm As Boolean
   Public Property MuestraEnUsado As Boolean
   Public Property SolicitaDistribucionEje As Boolean
#End Region
End Class
