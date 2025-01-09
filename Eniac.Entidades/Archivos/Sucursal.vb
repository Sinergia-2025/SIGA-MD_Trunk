Imports System.ComponentModel

<Serializable()>
Public Class Sucursal
   Inherits Eniac.Entidades.Entidad

   Public Const NombreTabla As String = "Sucursales"

   Public Enum Columnas
      IdSucursal
      Nombre
      Direccion
      IdLocalidad
      Telefono
      Correo
      FechaInicioActiv
      EstoyAca
      SoyLaCentral
      Id
      IdSucursalAsociada
      ColorSucursal
      LogoSucursal
      DireccionComercial
      IdLocalidadComercial
      RedesSociales
      IdSucursalAsociadaPrecios
      PublicarEnWeb
      IdEmpresa
   End Enum

   Public Enum ValoresFijosIdSucursal As Integer
      <Description("(Selección Multiple)")> SeleccionMultiple = -1
      <Description("(Todos)")> Todos = -2
   End Enum

#Region "Campos"

   Private _id As Int32 = 0
   Private _nombre As String = ""
   Private _direccion As String = ""
   Private _localidad As Entidades.Localidad = Nothing
   Private _telefono As String = String.Empty
   Private _correo As String = String.Empty
   Private _fechaInicioActiv As DateTime = Nothing
   Private _estoyAca As Boolean = False
   Private _soyLaCentral As Boolean = False
   Private _idSucursalAsociada As Int32 = 0
   Private _colorsucursal As Int32 = 0
   Private _logoSucursal As System.Drawing.Image
   Private _direccionComercial As String = ""
   Private _localidadComercial As Entidades.Localidad = Nothing
   Private _redesSociales As String = String.Empty

#End Region

#Region "Propiedades"

   Public Property Id() As Int32
      Get
         Return _id
      End Get
      Set(ByVal value As Int32)
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
   Public Property Direccion() As String
      Get
         Return _direccion
      End Get
      Set(ByVal value As String)
         _direccion = value
      End Set
   End Property
   Public Property Localidad() As Entidades.Localidad
      Get
         If _localidad Is Nothing Then
            _localidad = New Entidades.Localidad()
         End If
         Return _localidad
      End Get
      Set(ByVal value As Entidades.Localidad)
         _localidad = value
      End Set
   End Property
   Public Property Telefono() As String
      Get
         Return Me._telefono
      End Get
      Set(ByVal value As String)
         Me._telefono = value
      End Set
   End Property
   Public Property Correo() As String
      Get
         Return _correo
      End Get
      Set(ByVal value As String)
         _correo = value
      End Set
   End Property
   Public Property FechaInicioActiv() As DateTime
      Get
         Return _fechaInicioActiv
      End Get
      Set(ByVal value As DateTime)
         _fechaInicioActiv = value
      End Set
   End Property
   Public Property EstoyAca() As Boolean
      Get
         Return _estoyAca
      End Get
      Set(ByVal value As Boolean)
         _estoyAca = value
      End Set
   End Property
   Public Property SoyLaCentral() As Boolean
      Get
         Return _soyLaCentral
      End Get
      Set(ByVal value As Boolean)
         _soyLaCentral = value
      End Set
   End Property
   Public Property IdSucursalAsociada() As Int32
      Get
         Return _idSucursalAsociada
      End Get
      Set(ByVal value As Int32)
         _idSucursalAsociada = value
      End Set
   End Property
   Public Property NombreSucursalAsociada As String               ' No se persiste. Solo para mostrar en pantalla

   Public Property ColorSucursal() As Int32
      Get
         Return _colorsucursal
      End Get
      Set(ByVal value As Int32)
         _colorsucursal = value
      End Set
   End Property

   Public Property LogoSucursal() As System.Drawing.Image
      Get
         Return _logoSucursal
      End Get
      Set(ByVal value As System.Drawing.Image)
         _logoSucursal = value
      End Set
   End Property
   Public Property DireccionComercial() As String
      Get
         Return _direccionComercial
      End Get
      Set(ByVal value As String)
         _direccionComercial = value
      End Set
   End Property
   Public Property LocalidadComercial() As Entidades.Localidad
      Get
         If _localidadComercial Is Nothing Then
            _localidadComercial = New Entidades.Localidad()
         End If
         Return _localidadComercial
      End Get
      Set(ByVal value As Entidades.Localidad)
         _localidadComercial = value
      End Set
   End Property

   Public Property RedesSociales() As String
      Get
         Return _redesSociales
      End Get
      Set(ByVal value As String)
         _redesSociales = value
      End Set
   End Property

   Public Property IdSucursalAsociadaPrecios As Integer
   Public Property PublicarEnWeb As Boolean

   Private _Empresa As Entidades.Empresa
   Public Property Empresa As Entidades.Empresa
      Get
         If _Empresa Is Nothing Then _Empresa = New Empresa()
         Return _Empresa
      End Get
      Set(value As Entidades.Empresa)
         _Empresa = value
      End Set
   End Property

   '# Formas de Pago distinguidas por sucursal
   Private _FormasDePago As List(Of Entidades.VentasFormasPagoSucursales)
   Public Property FormasDePago As List(Of Entidades.VentasFormasPagoSucursales)
      Get
         If _FormasDePago Is Nothing Then _FormasDePago = New List(Of Entidades.VentasFormasPagoSucursales)
         Return _FormasDePago
      End Get
      Set(value As List(Of Entidades.VentasFormasPagoSucursales))
         _FormasDePago = value
      End Set
   End Property
#End Region

#Region "Propiedades ReadOnly"
   Public Property IdEmpresa As Integer
      Get
         Return Empresa.IdEmpresa
      End Get
      Set(value As Integer)
         Empresa.IdEmpresa = value
      End Set
   End Property

   Public ReadOnly Property NombreEmpresa As String
      Get
         Return Empresa.NombreEmpresa
      End Get
   End Property
#End Region

#Region "Overrides"


   Public Overrides Function ToString() As String
      Return Me.Nombre & " - " & Me.Id.ToString()
   End Function

#End Region

   Public Function GetCopia() As Entidades.Sucursal
      Dim copia As Entidades.Sucursal = New Entidades.Sucursal()
      With copia
         .ColorSucursal = Me._colorsucursal
         .Correo = Me._correo
         .Direccion = Me._direccion
         .EstoyAca = Me._estoyAca
         .FechaInicioActiv = Me._fechaInicioActiv
         .Id = Me._id
         .IdSucursal = Me.IdSucursal
         .IdSucursalAsociada = Me._idSucursalAsociada
         .LogoSucursal = Me._logoSucursal

         If Me._localidad IsNot Nothing Then
            .Localidad = Me._localidad.GetCopia()
         End If
         .DireccionComercial = Me._direccionComercial
         If Me._localidadComercial IsNot Nothing Then
            .LocalidadComercial = Me._localidadComercial.GetCopia()
         End If
         .RedesSociales = Me._redesSociales
         .IdSucursalAsociadaPrecios = Me._IdSucursalAsociadaPrecios
         .PublicarEnWeb = Me._PublicarEnWeb
         .Empresa = _Empresa.Clonar(_Empresa)
      End With

      Return copia
   End Function

End Class