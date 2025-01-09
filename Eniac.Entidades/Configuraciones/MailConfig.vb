<Serializable()> _
Public Class MailConfig
   Inherits Entidades.Entidad

   Private _servidorSMTP As String
   Public Property ServidorSMTP() As String
      Get
         Return _servidorSMTP
      End Get
      Set(ByVal value As String)
         _servidorSMTP = value
      End Set
   End Property

   Private _puertoSalida As Integer
   Public Property PuertoSalida() As Integer
      Get
         Return _puertoSalida
      End Get
      Set(ByVal value As Integer)
         _puertoSalida = value
      End Set
   End Property

   Private _direccion As String
   Public Property Direccion() As String
      Get
         Return _direccion
      End Get
      Set(ByVal value As String)
         _direccion = value
      End Set
   End Property

   Private _usuarioMail As String
   Public Property UsuarioMail() As String
      Get
         Return _usuarioMail
      End Get
      Set(ByVal value As String)
         _usuarioMail = value
      End Set
   End Property

   Private _clave As String
   Public Property Clave() As String
      Get
         Return _clave
      End Get
      Set(ByVal value As String)
         _clave = value
      End Set
   End Property

   Private _requiereSSL As Boolean
   Public Property RequiereSSL() As Boolean
      Get
         Return _requiereSSL
      End Get
      Set(ByVal value As Boolean)
         _requiereSSL = value
      End Set
   End Property

   Private _requiereAutenticacion As Boolean
   Public Property RequiereAutenticacion() As Boolean
      Get
         Return _requiereAutenticacion
      End Get
      Set(ByVal value As Boolean)
         _requiereAutenticacion = value
      End Set
   End Property

   Private _cantidadXHora As Integer
   Public Property CantidadXHora() As Integer
      Get
         Return _cantidadXHora
      End Get
      Set(ByVal value As Integer)
         _cantidadXHora = value
      End Set
   End Property

   Private _cantidadXMinuto As Integer
   Public Property CantidadXMinuto() As Integer
      Get
         Return _cantidadXMinuto
      End Get
      Set(ByVal value As Integer)
         _cantidadXMinuto = value
      End Set
   End Property

   Private _utilizaComoPredeterminado As Boolean
   Public Property UtilizaComoPredeterminado() As Boolean
      Get
         Return _utilizaComoPredeterminado
      End Get
      Set(ByVal value As Boolean)
         _utilizaComoPredeterminado = value
      End Set
   End Property

   Public Function CalcularTiempoEntreCorreos(intCantidad As Integer) As Integer
      If Entidades.Usuario.Actual.MailConfig.UtilizaComoPredeterminado Then
         Return CalcularTiempoEntreCorreos(Entidades.Usuario.Actual.MailConfig, intCantidad)
      Else
         Return CalcularTiempoEntreCorreos(Me, intCantidad)
      End If
   End Function
   Private Function CalcularTiempoEntreCorreos(mailConfig As MailConfig, intCantidad As Integer) As Integer
      'Al 12/02/2015 Son 2 reglas, 150 maximo por hora y 15 maximo por minuto.
      'Se baja a 120 por hora y 12 por minutos.

      '30 Segundos = 30 x 1000 = 120 Correos por Horas
      Dim intTiempoEntreCorreos As Integer
      If intCantidad <= mailConfig.CantidadXHora Then ' 120 Then
         '60 segundos dividido la cantidad de mail por minuto (12) = 1 mail cada 5 segundos
         intTiempoEntreCorreos = Convert.ToInt32(60000 / mailConfig.CantidadXMinuto) ' 5000
      Else
         '3600 segundos (1 hora) dividido la cantidad de mail por hora (120) = 1 mail cada 30 segundos
         intTiempoEntreCorreos = Convert.ToInt32(3600000 / mailConfig.CantidadXHora) '30000
      End If
      Return intTiempoEntreCorreos
   End Function

End Class
