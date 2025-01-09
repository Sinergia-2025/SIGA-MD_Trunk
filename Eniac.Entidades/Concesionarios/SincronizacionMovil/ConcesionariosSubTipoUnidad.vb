Public Class ConcesionariosSubTipoUnidad

   Public Const NombreTabla As String = "ConcesionarioSubTiposUnidades"

   Public Enum columnas
      IdTipoUnidadSubTipo
      Nombre
      Descripcion
      IdTipoUnidad
      SolicitaNumeroDePurtasLaterales
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

   Public Property SolicitaNumeroDePurtasLaterales As Boolean
   Public Property SolicitaCantPisos As Boolean
   Public Property SolicitaVolumen As Boolean
#End Region

End Class
