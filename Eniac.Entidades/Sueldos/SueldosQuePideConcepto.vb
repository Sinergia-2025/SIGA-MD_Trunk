<Serializable()>
Public Class SueldosQuePideConcepto
   Inherits Eniac.Entidades.Entidad

   Public Enum Columnas
      idQuePide
      NombreQuePide
   End Enum

#Region "Campos"
   Private _idQuePide As Integer
   Private _NombreQuePide As String
#End Region

#Region "Propiedades"

   Public Property idQuePide() As Integer
      Get
         Return Me._idQuePide
      End Get
      Set(ByVal value As Integer)
         Me._idQuePide = value
      End Set
   End Property

   Public Property NombreQuePide() As String
      Get
         Return Me._NombreQuePide
      End Get
      Set(ByVal value As String)
         Me._NombreQuePide = value
      End Set
   End Property


#End Region

End Class