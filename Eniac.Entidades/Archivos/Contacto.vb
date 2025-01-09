<Serializable()> _
Public Class Contacto
   Inherits Eniac.Entidades.Entidad

   Public Enum Columnas
      IdContacto
      NombreContacto
      Direccion
      IdLocalidad
      NombreLocalidad
      Cuit
      TipoDocContacto
      NroDocContacto
      IdCategoriaFiscal
      NombreCategoriaFiscal
      Telefono
      Celular
      IdZonaGeografica
      NombreZonaGeografica
      FechaNacimiento
      CorreoElectronico
      NombreTrabajo
      DireccionTrabajo
      TelefonoTrabajo
      CorreoTrabajo
      IdLocalidadTrabajo
      NombreLocalidadTrabajo
      FechaIngresoTrabajo
      FechaAlta
      Observacion
      Activo
      Foto
      PaginaWeb
   End Enum

#Region "Campos"

   Private _IdContacto As Long
   Private _nombreContacto As String = ""
   Private _direccion As String = ""
   Private _idLocalidad As Integer = 0
   Private _nombreLocalidad As String = String.Empty
   Private _localidad As Entidades.Localidad
   Private _categoriaFiscal As Entidades.CategoriaFiscal
   Private _telefono As String = ""
   Private _celular As String = ""
   Private _fechaNacimiento As Date = DateTime.Now
   Private _correoElectronico As String = ""
   Private _fechaAlta As DateTime = Date.Now
   Private _cuit As String = String.Empty
   Private _tipoDocContacto As String = ""
   Private _nroDocContacto As Long = 0
   Private _observacion As String = String.Empty
   Private _direcciones As DataTable
   Private _GeoLocalizacionLat As Double
   Private _GeoLocalizacionLng As Double
   Private _zonaGeografica As Entidades.ZonaGeografica
   Private _activo As Boolean
   Private _foto As System.Drawing.Image
   Private _paginaWeb As String
   Private _IdTipoContacto As Integer
   Private _Privado As Boolean

#End Region

#Region "Propiedades"

#Region "Primaria"

   Public Property IdContacto() As Long
      Get
         Return _IdContacto
      End Get
      Set(ByVal value As Long)
         _IdContacto = value
      End Set
   End Property

#End Region


   Public Property CategoriaFiscal() As Entidades.CategoriaFiscal
      Get
         If _categoriaFiscal Is Nothing Then
            _categoriaFiscal = New Entidades.CategoriaFiscal()
         End If
         Return _categoriaFiscal
      End Get
      Set(ByVal value As Entidades.CategoriaFiscal)
         _categoriaFiscal = value
      End Set
   End Property

   Public Property NombreContacto() As String
      Get
         Return Me._nombreContacto
      End Get
      Set(ByVal value As String)
         If value.Length > 100 Then
            Throw New Exception("El ancho del nombre del contacto no puede exceder los 100 caracteres")
         Else
            Me._nombreContacto = value.Trim()
         End If
      End Set
   End Property

   Public Property Direccion() As String
      Get
         Return Me._direccion
      End Get
      Set(ByVal value As String)
         If value.Length > 100 Then
            System.Windows.Forms.MessageBox.Show("El ancho de la dirección no puede exceder los 100 caracteres")
            Throw New Exception("El ancho de la dirección no puede exceder los 100 caracteres")
         Else
            Me._direccion = value.Trim()
         End If
      End Set
   End Property

   Public ReadOnly Property IdLocalidad() As Integer
      Get
         Return Me.Localidad.IdLocalidad
      End Get
   End Property

   Public ReadOnly Property NombreLocalidad() As String
      Get
         Return Me.Localidad.NombreLocalidad
      End Get
   End Property

   Public Property Localidad() As Entidades.Localidad
      Get
         If Me._localidad Is Nothing Then
            Me._localidad = New Entidades.Localidad()
         End If
         Return Me._localidad
      End Get
      Set(ByVal value As Entidades.Localidad)
         Me._localidad = value
      End Set
   End Property

   Public Property Telefono() As String
      Get
         Return Me._telefono
      End Get
      Set(ByVal value As String)
         Me._telefono = value.Trim()
      End Set
   End Property

   Public Property Celular() As String
      Get
         Return Me._celular
      End Get
      Set(ByVal value As String)
         Me._celular = value.Trim()
      End Set
   End Property

   Public Property FechaNacimiento() As DateTime
      Get
         Return Me._fechaNacimiento
      End Get
      Set(ByVal value As DateTime)
         Me._fechaNacimiento = value
      End Set
   End Property

   Public Property CorreoElectronico() As String
      Get
         Return Me._correoElectronico
      End Get
      Set(ByVal value As String)
         Me._correoElectronico = value.Trim()
      End Set
   End Property

   Public Property FechaAlta() As DateTime
      Get
         Return Me._fechaAlta
      End Get
      Set(ByVal value As DateTime)
         Me._fechaAlta = value
      End Set
   End Property

   Public Property Cuit() As String
      Get
         Return Me._cuit
      End Get
      Set(ByVal value As String)
         Me._cuit = value.Trim()
      End Set
   End Property

   Public Property TipoDocContacto() As String
      Get
         Return Me._tipoDocContacto
      End Get
      Set(ByVal value As String)
         Me._tipoDocContacto = value
      End Set
   End Property

   Public Property NroDocContacto() As Long
      Get
         Return Me._nroDocContacto
      End Get
      Set(ByVal value As Long)
         Me._nroDocContacto = value
      End Set
   End Property

   Public Property Observacion() As String
      Get
         Return Me._observacion
      End Get
      Set(ByVal value As String)
         Me._observacion = value.Trim()
      End Set
   End Property

   Public Property ZonaGeografica() As Entidades.ZonaGeografica
      Get
         If Me._zonaGeografica Is Nothing Then
            Me._zonaGeografica = New Entidades.ZonaGeografica()
         End If
         Return _zonaGeografica
      End Get
      Set(ByVal value As Entidades.ZonaGeografica)
         _zonaGeografica = value
      End Set
   End Property

   Public Property Activo() As Boolean
      Get
         Return Me._activo
      End Get
      Set(ByVal value As Boolean)
         Me._activo = value
      End Set
   End Property

   Public Property Foto() As System.Drawing.Image
      Get
         Return _foto
      End Get
      Set(ByVal value As System.Drawing.Image)
         _foto = value
      End Set
   End Property

   Public Property Direcciones() As DataTable
      Get
         Return Me._direcciones
      End Get
      Set(ByVal value As DataTable)
         Me._direcciones = value
      End Set
   End Property

   Public Property GeoLocalizacionLat() As Double
      Get
         Return _GeoLocalizacionLat
      End Get
      Set(ByVal value As Double)
         _GeoLocalizacionLat = value
      End Set
   End Property

   Public Property GeoLocalizacionLng() As Double
      Get
         Return _GeoLocalizacionLng
      End Get
      Set(ByVal value As Double)
         _GeoLocalizacionLng = value
      End Set
   End Property

   Public Property PaginaWeb() As String
      Get
         Return _paginaWeb
      End Get
      Set(ByVal value As String)
         _paginaWeb = value
      End Set
   End Property

   Public Property IdTipoContacto() As Integer
      Get
         Return Me._IdTipoContacto
      End Get
      Set(ByVal value As Integer)
         Me._IdTipoContacto = value
      End Set
   End Property

   Public Property Privado() As Boolean
      Get
         Return _Privado
      End Get
      Set(ByVal value As Boolean)
         _Privado = value
      End Set
   End Property

#End Region

End Class