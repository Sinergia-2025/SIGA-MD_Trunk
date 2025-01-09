<Serializable()>
Public Class SueldosEstadoCivil
   Inherits Eniac.Entidades.Entidad

   Public Enum Columnas
      idEstadoCivil
      NombreEstadoCivil
   End Enum

   Private _idEstadoCivil As Integer
   Public Property idEstadoCivil() As Integer
      Get
         Return Me._idEstadoCivil
      End Get
      Set(ByVal value As Integer)
         Me._idEstadoCivil = value
      End Set
   End Property

   Private _NombreEstadoCivil As String
   Public Property NombreEstadoCivil() As String
      Get
         Return Me._NombreEstadoCivil
      End Get
      Set(ByVal value As String)
         Me._NombreEstadoCivil = value
      End Set
   End Property

End Class