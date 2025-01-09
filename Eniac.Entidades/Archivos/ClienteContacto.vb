Public Class ClienteContacto
   Inherits Entidad

   Public Const NombreTabla As String = "ClientesContactos"
   Public Enum Columnas
      IdCliente
      IdContacto
      NombreContacto
      Direccion
      IdLocalidad
      Telefono
      CorreoElectronico
      Celular
      Observacion
      Activo
      IdUsuario
      IdTipoContacto
   End Enum
   Public Property IdCliente As Long
   Public Property IdContacto As Integer
   Public Property NombreContacto As String
   Public Property Direccion As String

   Private _localidad As Localidad
   Public Property Localidad As Localidad
      Get
         If _localidad Is Nothing Then _localidad = New Localidad()
         Return _localidad
      End Get
      Set(value As Localidad)
         _localidad = value
      End Set
   End Property
   Public Property Telefono As String
   Public Property CorreoElectronico As String
   Public Property Celular As String
   Public Property Observacion As String
   Public Property Activo As Boolean
   Public Property IdUsuario As String

   Dim _tipoContacto As TipoContacto
   Public Property TipoContacto As TipoContacto
      Get
         If _tipoContacto Is Nothing Then _tipoContacto = New TipoContacto()
         Return _tipoContacto
      End Get
      Set(value As TipoContacto)
         _tipoContacto = value
      End Set
   End Property


#Region "ReadOnly Properties"
   Public ReadOnly Property NombreTipoContacto As String
      Get
         If TipoContacto Is Nothing Then Return String.Empty
         Return TipoContacto.NombreTipoContacto
      End Get
   End Property

   Public ReadOnly Property NombreLocalidad As String
      Get
         If Localidad Is Nothing Then Return String.Empty
         Return Localidad.NombreLocalidad
      End Get
   End Property
#End Region

End Class