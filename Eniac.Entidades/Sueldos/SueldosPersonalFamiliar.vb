<Serializable()>
Public Class SueldosPersonalFamiliar
   Inherits Eniac.Entidades.Entidad

   Public Enum Columnas
      idLegajo
      CuilFamiliar
      NombreFamiliar
      FechaNacimientoFamiliar
      IdTipoVinculoFamiliar
      SexoFamiliar
   End Enum

#Region "Campos"

   Private _idLegajo As Integer
   Private _CuilFamiliar As Long
   Private _NombreFamiliar As String
   Private _FechaNacimientoFamiliar As DateTime
   Private _IdTipoVinculoFamiliar As String
   Private _SexoFamiliar As String

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

   Public Property CuilFamiliar() As Long
      Get
         Return Me._CuilFamiliar
      End Get
      Set(ByVal value As Long)
         Me._CuilFamiliar = value
      End Set
   End Property

   Public Property NombreFamiliar() As String
      Get
         Return Me._NombreFamiliar
      End Get
      Set(ByVal value As String)
         Me._NombreFamiliar = value
      End Set
   End Property

   Public Property FechaNacimientoFamiliar() As DateTime
      Get
         Return Me._FechaNacimientoFamiliar
      End Get
      Set(ByVal value As DateTime)
         Me._FechaNacimientoFamiliar = value
      End Set
   End Property

   Public Property IdTipoVinculoFamiliar() As String
      Get
         Return Me._IdTipoVinculoFamiliar
      End Get
      Set(ByVal value As String)
         Me._IdTipoVinculoFamiliar = value
      End Set
   End Property

   Public Property SexoFamiliar() As String
      Get
         Return Me._SexoFamiliar
      End Get
      Set(ByVal value As String)
         Me._SexoFamiliar = value
      End Set
   End Property

#End Region

End Class