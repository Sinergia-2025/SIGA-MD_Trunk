<Serializable()> _
Public Class Localidad
   Inherits Eniac.Entidades.Entidad

   Public Enum Columnas
      IdLocalidad
      NombreLocalidad
      IdProvincia
      FechaActualizacionWeb
   End Enum
#Region "Campos"

   Private _idLocalidad As Integer
   Private _idProvincia As String
   Private _nombreLocalidad As String
   Private _nombreProvincia As String

#End Region

#Region "Propiedades"

   Public Property IdLocalidad() As Integer
      Get
         Return Me._idLocalidad
      End Get
      Set(ByVal value As Integer)
         Me._idLocalidad = value
      End Set
   End Property
   Public Property IdProvincia() As String
      Get
         Return Me._idProvincia
      End Get
      Set(ByVal value As String)
         '  If value.Length <= 4 Then
         Me._idProvincia = value
         'Else
         '   Throw New Exception("El codigo de provincia no puede tener mas de 4 caracteres")
         'End If
      End Set
   End Property

   Public Property NombreLocalidad() As String
      Get
         Return Me._nombreLocalidad
      End Get
      Set(ByVal value As String)
         Me._nombreLocalidad = value
      End Set
   End Property

   Public Property NombreProvincia() As String
      Get
         Return Me._nombreProvincia
      End Get
      Set(ByVal value As String)
         Me._nombreProvincia = value
      End Set
   End Property
#End Region

   Public Function GetCopia() As Entidades.Localidad
      Dim copia As Entidades.Localidad = New Entidades.Localidad()
      With copia
         .IdLocalidad = Me._idLocalidad
         .IdProvincia = Me._idProvincia
         .IdSucursal = Me.IdSucursal
         .NombreLocalidad = Me._nombreLocalidad
         .NombreProvincia = Me._nombreProvincia
         .Password = Me.Password
         .Usuario = Me.Usuario
      End With
      Return copia
   End Function

End Class