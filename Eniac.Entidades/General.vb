<Serializable()> _
Public Class General
   Inherits Eniac.Entidades.Entidad

   Public Enum Impreso
      Todos
      NO
      SI
   End Enum

#Region "Campos"

   Private _path As String
   Private _base As String

#End Region

#Region "Propiedades"

   Public Property Base() As String
      Get
         Return Me._base
      End Get
      Set(ByVal value As String)
         Me._base = value
      End Set
   End Property
   Public Property Path() As String
      Get
         Return _path
      End Get
      Set(ByVal value As String)
         _path = value
      End Set
   End Property


#End Region

End Class
