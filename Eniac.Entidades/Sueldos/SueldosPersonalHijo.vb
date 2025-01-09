<Serializable()>
Public Class SueldosPersonalHijo
   Inherits Eniac.Entidades.Entidad

   Public Enum Columnas
      idLegajo
      CuilHijo
      NombreHijo
      FechaNacimientoHijo
   End Enum

#Region "Campos"

   Private _idLegajo As Integer
   Private _CuilHijo As Long
   Private _NombreHijo As String
   Private _FechaNacimientoHijo As DateTime

#End Region

#Region "Propiedades"

   Public Property idLegajo() As Integer
      Get
         Return Me._idLegajo
      End Get
      Set(ByVal value As Integer)
         Me._idLegajo = value
      End Set
   End Property

   Public Property CuilHijo() As Long
      Get
         Return Me._CuilHijo
      End Get
      Set(ByVal value As Long)
         Me._CuilHijo = value
      End Set
   End Property

   Public Property NombreHijo() As String
      Get
         Return Me._NombreHijo
      End Get
      Set(ByVal value As String)
         Me._NombreHijo = value
      End Set
   End Property

   Public Property FechaNacimientoHijo() As DateTime
      Get
         Return Me._FechaNacimientoHijo
      End Get
      Set(ByVal value As DateTime)
         Me._FechaNacimientoHijo = value
      End Set
   End Property

#End Region

End Class