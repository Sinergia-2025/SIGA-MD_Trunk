Public Class ConcesionarioSubTipoUnidad
   Inherits Entidades.Entidad

   Public Const NombreTabla As String = "ConcesionarioSubTiposUnidades"

   Public Enum columnas
      IdSubTipoUnidad
      NombreSubTipoUnidad
      DescripcionSubTipoUnidad
      IdTipoUnidad
      SolicitaCantPuertasLaterales
      SolicitaCantPisos
      SolicitaVolumen
   End Enum

   Public Sub New()
   End Sub

#Region "Propiedades"
   Public Property IdSubTipoUnidad As Integer
   Public Property NombreSubTipoUnidad As String
   Public Property DescripcionSubTipoUnidad As String
   Public Property IdTipoUnidad As Integer

   Public Property SolicitaCantPuertasLaterales As Boolean
   Public Property SolicitaCantPisos As Boolean
   Public Property SolicitaVolumen As Boolean
#End Region

End Class
