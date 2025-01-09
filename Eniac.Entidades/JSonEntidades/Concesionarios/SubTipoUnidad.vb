Namespace JSonEntidades.Concesionarios.Alcorta
   Public Class SubTipoUnidad
      Public Enum columnas
         IdTipoUnidadSubTipo
         Nombre
         Descripcion
         IdTipoUnidad
         SolicitaCantPuertasLaterales
         SolicitaCantPisos
         SolicitaVolumen
      End Enum

      Public Sub New()
      End Sub

#Region "Propiedades"
      Public Property IdTipoUnidadSubTipo As Integer
      Public Property Nombre As String
      Public Property Descripcion As String
      Public Property IdTipoUnidad As Integer

      Public Property SolicitaCantPuertasLaterales As Boolean
      Public Property SolicitaCantPisos As Boolean
      Public Property SolicitaVolumen As Boolean
#End Region

   End Class

   Public Class SubTipoUnidadResponse
      Public Enum Campos
         sync
      End Enum
      Public Property sync As Boolean
   End Class

End Namespace
