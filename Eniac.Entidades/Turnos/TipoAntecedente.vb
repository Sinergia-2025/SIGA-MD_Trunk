<Serializable()> _
Public Class TipoAntecedente
   Inherits Eniac.Entidades.Entidad

   Public Enum Columnas
      IdTipoAntecedente
      NombreTipoAntecedente
   End Enum

   Private _idTipoAntecedente As Integer
   Public Property IdTipoAntecedente() As Integer
      Get
         Return _idTipoAntecedente
      End Get
      Set(ByVal value As Integer)
         _idTipoAntecedente = value
      End Set
   End Property

   Private _nombreTipoAntecedente As String
   Public Property NombreTipoAntecedente() As String
      Get
         Return _nombreTipoAntecedente
      End Get
      Set(ByVal value As String)
         _nombreTipoAntecedente = value
      End Set
   End Property

End Class