<Serializable()>
Public Class RecepcionEstadoF
   Inherits Eniac.Entidades.Entidad

#Region "Campos"

   Private _nombreEstado As String = String.Empty
   Private _idEstado As Integer = 0

#End Region

#Region "Propiedades"

   Public Property NombreEstado() As String
      Get
         Return _nombreEstado
      End Get
      Set(ByVal value As String)
         _nombreEstado = value
      End Set
   End Property

   Public Property IdEstado() As Integer
      Get
         Return _idEstado
      End Get
      Set(ByVal value As Integer)
         _idEstado = value
      End Set
   End Property

#End Region

End Class