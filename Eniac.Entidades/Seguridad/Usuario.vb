<Serializable()> _
Public Class Usuario
    Inherits Eniac.Entidades.Entidad

#Region "Enum"

   Public Enum Columnas
      Id
      Nombre
      Clave
      MailServidorSMTP
      MailPuertoSalida
      MailDireccion
      MailUsuario
      MailPassword
      MailRequiereSSL
      MailRequiereAutenticacion
      MailCantxHora
      MailCantxMinuto
      UtilizaComoPredeterminado
      CorreoElectronico
      FechaUltimaModContraseña
      Activo
      NivelAutorizacion
      TipoUsuario
      NombreTipoUsuario
   End Enum

#End Region

#Region "Campos"

   Private _id As String = ""
   Private _nombre As String = ""
   Private _clave As String = ""
   Private _tipousuario As Integer = 1
   Private _nombretipousuario As String = ""

#End Region

   Public Sub New()
      NivelAutorizacion = 1
   End Sub

#Region "Propiedades"

   Public Property Id() As String
      Get
         Return _id
      End Get
      Set(ByVal value As String)
         If value.Length > 50 Then
            Throw New Exception("El ancho del id debe ser menor de 50")
         End If
         _id = value
      End Set
   End Property

   Public Property Nombre() As String
      Get
         Return _nombre
      End Get
      Set(ByVal value As String)
         _nombre = value
      End Set
   End Property

   Public Property NombreTipoUsuario() As String
      Get
         Return _nombretipousuario
      End Get
      Set(ByVal value As String)
         _nombretipousuario = value
      End Set
   End Property


   Public Property Clave() As String
      Get
         Return _clave
      End Get
      Set(ByVal value As String)
         _clave = value
      End Set
   End Property

   Public Property TipoUsuario() As Integer
      Get
         Return _tipousuario
      End Get
      Set(ByVal value As Integer)
         _tipousuario = value
      End Set
   End Property

   Private _mailConfig As Entidades.MailConfig
   Public Property MailConfig() As Entidades.MailConfig
      Get
         If Me._mailConfig Is Nothing Then
            Me._mailConfig = New Entidades.MailConfig()
         End If
         Return _mailConfig
      End Get
      Set(ByVal value As Entidades.MailConfig)
         _mailConfig = value
      End Set
   End Property

   Private _correoElectronico As String
   Public Property CorreoElectronico() As String
      Get
         Return _correoElectronico
      End Get
      Set(ByVal value As String)
         _correoElectronico = value
      End Set
   End Property

   Private _fechaUltimaModContraseña As DateTime
   Public Property FechaUltimaModContraseña() As DateTime
      Get
         Return _fechaUltimaModContraseña
      End Get
      Set(ByVal value As DateTime)
         _fechaUltimaModContraseña = value
      End Set
   End Property

   Private _activo As Boolean
   Public Property Activo() As Boolean
      Get
         Return _activo
      End Get
      Set(ByVal value As Boolean)
         _activo = value
      End Set
   End Property

   Public Property NivelAutorizacion As Short

#End Region

   Public Class Actual
      Public Shared Property Sistema As String

      Private Shared _nombre As String
      Public Shared Property Nombre() As String
         Get
            Return _nombre
         End Get
         Set(ByVal value As String)
            _nombre = value
         End Set
      End Property
      Private Shared _pwd As String
      Public Shared Property Pwd() As String
         Get
            Return _pwd
         End Get
         Set(ByVal value As String)
            _pwd = value
         End Set
      End Property
      Public Shared Property NivelAutorizacion As Short = 1

      Private Shared _sucursal As Entidades.Sucursal
      Public Shared Property Sucursal() As Eniac.Entidades.Sucursal
         Get
            Return _sucursal
         End Get
         Set(ByVal value As Eniac.Entidades.Sucursal)
            _sucursal = value
         End Set
      End Property

      Private Shared _empresa As String
      Public Shared Property Empresa() As String
         Get
            Return _empresa
         End Get
         Set(ByVal value As String)
            _empresa = value
         End Set
      End Property

      Private Shared _nombrelogo As String
      Public Shared Property NombreLogo() As String
         Get
            Return _nombrelogo
         End Get
         Set(ByVal value As String)
            _nombrelogo = value
         End Set
      End Property

      Private Shared _logo As System.Drawing.Image
      Public Shared Property Logo() As System.Drawing.Image
         Get
            Return _logo
         End Get
         Set(ByVal value As System.Drawing.Image)
            _logo = value
         End Set
      End Property

      Private Shared _mailConfig As Entidades.MailConfig
      Public Shared Property MailConfig() As Entidades.MailConfig
         Get
            Return _mailConfig
         End Get
         Set(ByVal value As Entidades.MailConfig)
            _mailConfig = value
         End Set
      End Property

      Public Shared Property CurrentUICulture As String

   End Class
End Class