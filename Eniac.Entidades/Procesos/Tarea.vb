<Serializable()>
Public Class Tarea
   Inherits Eniac.Entidades.Entidad

#Region "Campos"

   Private _id As Integer
   Private _fecha As DateTime
   Private _tarea As String

#End Region

#Region "Propiedades"

   Public Property Id() As Integer
      Get
         Return Me._id
      End Get
      Set(ByVal value As Integer)
         Me._id = value
      End Set
   End Property
   Public Property Fecha() As DateTime
      Get
         Return Me._fecha
      End Get
      Set(ByVal value As DateTime)
         Me._fecha = value
      End Set
   End Property
   Public Property Tarea() As String
      Get
         Return Me._tarea
      End Get
      Set(ByVal value As String)
         Me._tarea = value
      End Set
   End Property

#End Region

#Region "Overrides"

   Public Overrides Function ToString() As String
      Return Me.Tarea
   End Function

#End Region

End Class