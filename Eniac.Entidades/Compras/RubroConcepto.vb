<Serializable()>
Public Class RubroConcepto
   'Inherits Eniac.Entidades.Entidad
   Inherits Eniac.Entidades.Entidad

   Public Enum Columnas
      IdRubroConcepto
      NombreRubroConcepto
   End Enum

   Private _idRubroConcepto As Integer
   Public Property NombreRubroConcepto() As String
      Get
         Return _nombreRubroConcepto
      End Get
      Set(ByVal value As String)
         _nombreRubroConcepto = value
      End Set
   End Property

   Private _nombreRubroConcepto As String
   Public Property IdRubroConcepto() As Integer
      Get
         Return _idRubroConcepto
      End Get
      Set(ByVal value As Integer)
         _idRubroConcepto = value
      End Set
   End Property

End Class