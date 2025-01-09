<Serializable()> _
Public Class Antecedente
   Inherits Eniac.Entidades.Entidad

   Public Enum Columnas
      IdAntecedente
      NombreAntecedente
      IdTipoAntecedente
   End Enum

   Private _idAntecedente As Integer
   Public Property IdAntecedente() As Integer
      Get
         Return _idAntecedente
      End Get
      Set(ByVal value As Integer)
         _idAntecedente = value
      End Set
   End Property

   Private _nombreAntecedente As String
   Public Property NombreAntecedente() As String
      Get
         Return _nombreAntecedente
      End Get
      Set(ByVal value As String)
         _nombreAntecedente = value
      End Set
   End Property

   Private _tipoAntecedente As Entidades.TipoAntecedente
   Public Property TipoAntecedente() As Entidades.TipoAntecedente
      Get
         If Me._tipoAntecedente Is Nothing Then
            Me._tipoAntecedente = New Entidades.TipoAntecedente()
         End If
         Return _tipoAntecedente
      End Get
      Set(ByVal value As Entidades.TipoAntecedente)
         _tipoAntecedente = value
      End Set
   End Property

End Class