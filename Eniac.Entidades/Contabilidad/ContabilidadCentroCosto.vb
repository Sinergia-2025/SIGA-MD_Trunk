<Serializable()>
<Description("ContabilidadCentroCosto")>
Public Class ContabilidadCentroCosto
   Inherits Eniac.Entidades.Entidad

   Public Enum Columnas
      IdCentroCosto
      NombreCentroCosto
   End Enum

   Private _idCentroCosto As Integer
   Public Property IdCentroCosto() As Integer
      Get
         Return _idCentroCosto
      End Get
      Set(ByVal value As Integer)
         _idCentroCosto = value
      End Set
   End Property

   Private _nombreCentroCosto As String
   Public Property NombreCentroCosto() As String
      Get
         Return _nombreCentroCosto
      End Get
      Set(ByVal value As String)
         _nombreCentroCosto = value
      End Set
   End Property

End Class