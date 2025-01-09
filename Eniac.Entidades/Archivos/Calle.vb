<Serializable()> _
Public Class Calle
   Inherits Eniac.Entidades.Entidad

   Public Enum Columnas
      IdCalle
      NombreCalle
      IdLocalidad
   End Enum

   Private _idCalle As Integer

   Public Property IdCalle() As Integer
      Get
         Return _idCalle
      End Get
      Set(ByVal value As Integer)
         _idCalle = value
      End Set
   End Property

   Private _nombreCalle As String

   Public Property NombreCalle() As String
      Get
         Return _nombreCalle
      End Get
      Set(ByVal value As String)
         _nombreCalle = value
      End Set
   End Property

   Private _localidad As Eniac.Entidades.Localidad

   Public Property Localidad() As Eniac.Entidades.Localidad
      Get
         If Me._localidad Is Nothing Then
            Me._localidad = New Eniac.Entidades.Localidad()
         End If
         Return _localidad
      End Get
      Set(ByVal value As Eniac.Entidades.Localidad)
         _localidad = value
      End Set
   End Property

End Class
