<Serializable()> _
Public Class TipoContacto
   Inherits Eniac.Entidades.Entidad

   Public Enum Columnas
      IdTipoContacto
      NombreTipoContacto
      NombreAbrevTipoContacto
   End Enum

#Region "Propiedades"

   Private _IdTipoContacto As Integer
   Public Property IdTipoContacto() As Integer
      Get
         Return Me._IdTipoContacto
      End Get
      Set(ByVal value As Integer)
         Me._IdTipoContacto = value
      End Set
   End Property

   Private _NombreTipoContacto As String
   Public Property NombreTipoContacto() As String
      Get
         Return Me._NombreTipoContacto
      End Get
      Set(ByVal value As String)
         Me._NombreTipoContacto = value
      End Set
   End Property

   Private _NombreAbrevTipoContacto As String
   Public Property NombreAbrevTipoContacto() As String
      Get
         Return Me._NombreAbrevTipoContacto
      End Get
      Set(ByVal value As String)
         Me._NombreAbrevTipoContacto = value
      End Set
   End Property

#End Region

End Class