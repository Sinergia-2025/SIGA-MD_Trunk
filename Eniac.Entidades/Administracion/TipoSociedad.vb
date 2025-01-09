
Public Class TipoSociedad
   Inherits Eniac.Entidades.Entidad

   Public Const NombreTabla = "TiposSociedades"
   Public Enum Columnas
      IdTipoSociedad
      NombreTipoSociedad
   End Enum

#Region "Propiedades"

   Private _idTipoSociedad As Integer

   Public Property IdTipoSociedad() As Integer
      Get
         Return _idTipoSociedad
      End Get
      Set(ByVal value As Integer)
         _idTipoSociedad = value
      End Set
   End Property

   Private _nombreTipoSociedad As String

   Public Property NombreTipoSociedad() As String
      Get
         Return _nombreTipoSociedad
      End Get
      Set(ByVal value As String)
         _nombreTipoSociedad = value
      End Set
   End Property

#End Region

End Class