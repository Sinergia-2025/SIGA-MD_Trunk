<Serializable()> _
Public Class Actividad
   Inherits Eniac.Entidades.Entidad

   Public Enum Columnas
      IdProvincia
      IdActividad
      NombreActividad
      Porcentaje
      BaseImponible
      CodigoAfip
   End Enum

#Region "Campos"

   Private _idProvincia As String
   Private _idActividad As Integer
   Private _nombreActividad As String
   Private _porcentaje As Decimal
   Private _baseImponible As Decimal

#End Region

#Region "Propiedades"

   Public Property IdProvincia() As String
      Get
         Return Me._idProvincia
      End Get
      Set(ByVal value As String)
         Me._idProvincia = value
      End Set
   End Property

   Public Property IdActividad() As Integer
      Get
         Return _idActividad
      End Get
      Set(ByVal value As Integer)
         _idActividad = value
      End Set
   End Property
   Public Property NombreActividad() As String
      Get
         Return _nombreActividad
      End Get
      Set(ByVal value As String)
         _nombreActividad = value
      End Set
   End Property
   Public Property Porcentaje() As Decimal
      Get
         Return _porcentaje
      End Get
      Set(ByVal value As Decimal)
         _porcentaje = value
      End Set
   End Property

   Public Property BaseImponible() As Decimal
      Get
         Return _baseImponible
      End Get
      Set(ByVal value As Decimal)
         _baseImponible = value
      End Set
   End Property

   Public Property CodigoAfip() As Integer

#End Region

End Class