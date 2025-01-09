
Public Class TipoEmbarcacion
   Inherits Eniac.Entidades.Entidad

   Public Enum Columnas
      IdTipoEmbarcacion
      NombreTipoEmbarcacion
   End Enum

#Region "Propiedades"

   Private _idTipoEmbarcacion As Integer

   Public Property IdTipoEmbarcacion() As Integer
      Get
         Return _idTipoEmbarcacion
      End Get
      Set(ByVal value As Integer)
         _idTipoEmbarcacion = value
      End Set
   End Property

   Private _nombreTipoEmbarcacion As String

   Public Property NombreTipoEmbarcacion() As String
      Get
         Return _nombreTipoEmbarcacion
      End Get
      Set(ByVal value As String)
         _nombreTipoEmbarcacion = value
      End Set
   End Property

#End Region

End Class