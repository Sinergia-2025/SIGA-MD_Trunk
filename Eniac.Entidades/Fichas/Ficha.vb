<Serializable()> _
Public Class Ficha
   Inherits Eniac.Entidades.Entidad

#Region "Constructores"

   Public Sub New()
      MyBase.New()
   End Sub
   Public Sub New(ByVal idSucursal As Int32, ByVal usuario As String, ByVal pwd As String)
      Me.New()
      Me.IdSucursal = idSucursal
      Me.Usuario = usuario
      Me.Password = pwd
   End Sub

#End Region

#Region "Campos"

   Private _IdCliente As Long
   Private _nroOperacion As Integer
   'Private _tipoDocumento As String
   'Private _nroDocumento As String
   Private _fechaOperacion As DateTime
   Private _montoTotalBruto As Decimal
   Private _anticipo As Decimal
   Private _cuotas As Integer
   Private _idFormasPago As Integer
   Private _interes As Decimal
   Private _totalNeto As Decimal
   Private _saldo As Decimal
   Private _IdVendedor As Integer
   Private _IdCobrador As Integer
   Private _idEstado As String
   Private _nroFactura As Integer
   Private _comentario As String
   Private _productos As Generic.List(Of Entidades.FichaProducto)
   Private _pagos As Generic.List(Of Entidades.FichaPago)
   Private _pagosDetalle As Generic.List(Of Entidades.FichaPagoDetalle)
   Private _nombreCobrador As String
   Private _nombreVendedor As String
   Private _esNueva As Boolean

#End Region

#Region "Propiedades"

   Public Property IdCliente() As Long
      Get
         Return Me._IdCliente
      End Get
      Set(ByVal value As Long)
         Me._IdCliente = value
      End Set
   End Property

   Public Property EsNueva() As Boolean
      Get
         Return Me._esNueva
      End Get
      Set(ByVal value As Boolean)
         Me._esNueva = value
      End Set
   End Property
   Public Property IdVendedor() As Integer
      Get
         Return _IdVendedor
      End Get
      Set(ByVal value As Integer)
         _IdVendedor = value
      End Set
   End Property

   Public Property IdCobrador() As Integer
      Get
         Return _IdCobrador
      End Get
      Set(ByVal value As Integer)
         _IdCobrador = value
      End Set
   End Property
   Public Property PagosDetalle() As Generic.List(Of Entidades.FichaPagoDetalle)
      Get
         If Me._pagosDetalle Is Nothing Then
            Me._pagosDetalle = New Generic.List(Of Entidades.FichaPagoDetalle)
         End If
         Return Me._pagosDetalle
      End Get
      Set(ByVal value As Generic.List(Of Entidades.FichaPagoDetalle))
         Me._pagosDetalle = value
      End Set
   End Property
   Public Property Pagos() As Generic.List(Of Entidades.FichaPago)
      Get
         If Me._pagos Is Nothing Then
            Me._pagos = New Generic.List(Of Entidades.FichaPago)
         End If
         Return Me._pagos
      End Get
      Set(ByVal value As Generic.List(Of Entidades.FichaPago))
         Me._pagos = value
      End Set
   End Property
   Public Property Productos() As Generic.List(Of Entidades.FichaProducto)
      Get
         If Me._productos Is Nothing Then
            Me._productos = New Generic.List(Of Entidades.FichaProducto)
         End If
         Return Me._productos
      End Get
      Set(ByVal value As Generic.List(Of Entidades.FichaProducto))
         Me._productos = value
      End Set
   End Property
   Public Property Comentario() As String
      Get
         Return Me._comentario
      End Get
      Set(ByVal value As String)
         If value.Length <= 200 Then
            Me._comentario = value
         Else
            Throw New Exception("El comentario no puede tener mas de 200 caracteres")
         End If
      End Set
   End Property
   Public Property NroFactura() As Integer
      Get
         Return Me._nroFactura
      End Get
      Set(ByVal value As Integer)
         Me._nroFactura = value
      End Set
   End Property
   Public Property NombreVendedor() As String
      Get
         Return _nombreVendedor
      End Get
      Set(ByVal value As String)
         _nombreVendedor = value
      End Set
   End Property
   Public Property IdEstado() As String
      Get
         Return Me._idEstado
      End Get
      Set(ByVal value As String)
         If value.Length <= 10 Then
            Me._idEstado = value
         Else
            Throw New Exception("El estado no puede tener mas de 10 caracteres")
         End If
      End Set
   End Property

   Public Property Saldo() As Decimal
      Get
         Return Me._saldo
      End Get
      Set(ByVal value As Decimal)
         Me._saldo = value
      End Set
   End Property

   Public Property TotalNeto() As Decimal
      Get
         Return Me._totalNeto
      End Get
      Set(ByVal value As Decimal)
         Me._totalNeto = value
      End Set
   End Property
   Public Property Interes() As Decimal
      Get
         Return Me._interes
      End Get
      Set(ByVal value As Decimal)
         Me._interes = value
      End Set
   End Property
   Public Property IdFormasPago() As Integer
      Get
         Return Me._idFormasPago
      End Get
      Set(ByVal value As Integer)
         Me._idFormasPago = value
      End Set
   End Property
   Public Property Cuotas() As Integer
      Get
         Return Me._cuotas
      End Get
      Set(ByVal value As Integer)
         Me._cuotas = value
      End Set
   End Property
   Public Property Anticipo() As Decimal
      Get
         Return Me._anticipo
      End Get
      Set(ByVal value As Decimal)
         Me._anticipo = value
      End Set
   End Property
   Public Property MontoTotalBruto() As Decimal
      Get
         Return Me._montoTotalBruto
      End Get
      Set(ByVal value As Decimal)
         Me._montoTotalBruto = value
      End Set
   End Property
   Public Property NroOperacion() As Integer
      Get
         Return Me._nroOperacion
      End Get
      Set(ByVal value As Integer)
         Me._nroOperacion = value
      End Set
   End Property
   'Public Property TipoDocumento() As String
   '   Get
   '      Return Me._tipoDocumento
   '   End Get
   '   Set(ByVal value As String)
   '      If value.Length <= 5 Then
   '         Me._tipoDocumento = value
   '      Else
   '         Throw New Exception("El tipo de documento no puede tener mas de 5 caracteres")
   '      End If
   '   End Set
   'End Property
   'Public Property NroDocumento() As String
   '   Get
   '      Return Me._nroDocumento
   '   End Get
   '   Set(ByVal value As String)
   '      If value.Length <= 12 Then
   '         Me._nroDocumento = value
   '      Else
   '         Throw New Exception("El nro. de documento no puede tener mas de 12 caracteres")
   '      End If
   '   End Set
   'End Property
   Public Property FechaOperacion() As DateTime
      Get
         Return Me._fechaOperacion
      End Get
      Set(ByVal value As DateTime)
         Me._fechaOperacion = value
      End Set
   End Property
   Public Property NombreCobrador() As String
      Get
         Return Me._nombreCobrador
      End Get
      Set(ByVal value As String)
         Me._nombreCobrador = value
      End Set
   End Property

   Private _idCaja As Integer
   Public Property IdCaja() As Integer
      Get
         Return _idCaja
      End Get
      Set(ByVal value As Integer)
         _idCaja = value
      End Set
   End Property


#End Region

End Class