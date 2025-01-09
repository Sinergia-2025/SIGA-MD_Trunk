<Serializable()>
Public Class SueldosObraSocial

   Inherits Eniac.Entidades.Entidad

   Public Enum Columnas
      idObraSocial
      NombreObraSocial
   End Enum

#Region "Campos"

   Private _idObraSocial As Integer
   Private _NombreObraSocial As String

#End Region

#Region "Propiedades"
   Public Property idObraSocial() As Integer
      Get
         Return Me._idObraSocial
      End Get
      Set(ByVal value As Integer)
         Me._idObraSocial = value
      End Set
   End Property

   Public Property NombreObraSocial() As String
      Get
         Return Me._NombreObraSocial
      End Get
      Set(ByVal value As String)
         Me._NombreObraSocial = value
      End Set
   End Property


#End Region

End Class