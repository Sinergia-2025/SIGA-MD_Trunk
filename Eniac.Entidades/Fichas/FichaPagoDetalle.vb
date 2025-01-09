<Serializable()>
Public Class FichaPagoDetalle
   Inherits Eniac.Entidades.Entidad

#Region "Constructores"

   Public Sub New(ByVal idSucursal As Int32, ByVal usuario As String, ByVal pwd As String)
      Me.IdSucursal = idSucursal
      Me.Usuario = usuario
      Me.Password = pwd
   End Sub

   Public Sub New(nroOperacion As Integer, nroCuota As Integer, importe As Decimal)
      _nroOperacion = nroOperacion
      _nroCuota = nroCuota
      _importe = importe
   End Sub

#End Region

#Region "Campos"

   Private _idCliente As Long
   Private _nroOperacion As Integer
   'Private _tipoDocumento As String
   'Private _nroDocumento As String
   Private _fechaPago As Date
   Private _importe As Decimal
   Private _IdCobrador As Integer
   Private _nroCuota As Integer
   Private _nombreCobrador As String

#End Region

#Region "Propiedades"

   Public Property IdCliente() As Long
      Get
         Return Me._idCliente
      End Get
      Set(ByVal value As Long)
         Me._idCliente = value
      End Set
   End Property

   Public Property NombreCobrador() As String
      Get
         Return _nombreCobrador
      End Get
      Set(ByVal value As String)
         _nombreCobrador = value
      End Set
   End Property
   Public Property IdCobrador() As Integer
      Get
         Return Me._IdCobrador
      End Get
      Set(ByVal value As Integer)
         Me._IdCobrador = value
      End Set
   End Property
   Public Property NroCuota() As Integer
      Get
         Return _nroCuota
      End Get
      Set(ByVal value As Integer)
         _nroCuota = value
      End Set
   End Property

   Public Property FechaPago() As Date
      Get
         Return Me._fechaPago
      End Get
      Set(ByVal value As Date)
         Me._fechaPago = value
      End Set
   End Property
   Public Property Importe() As Decimal
      Get
         Return Me._importe
      End Get
      Set(ByVal value As Decimal)
         Me._importe = value
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

   Private _fichaPagoAjuste As Entidades.FichaPagoAjuste
   Public Property FichaPagoAjuste() As Entidades.FichaPagoAjuste
      Get
         If Me._fichaPagoAjuste Is Nothing Then
            Me._fichaPagoAjuste = New Entidades.FichaPagoAjuste()
         End If
         Return _fichaPagoAjuste
      End Get
      Set(ByVal value As Entidades.FichaPagoAjuste)
         _fichaPagoAjuste = value
      End Set
   End Property

   Private _idCaja As Integer
   Public Property IdCaja() As Integer
      Get
         Return Me._idCaja
      End Get
      Set(ByVal value As Integer)
         Me._idCaja = value
      End Set
   End Property

   Private _NumeroPlanilla As Integer
   Public Property NumeroPlanilla() As Integer
      Get
         Return Me._NumeroPlanilla
      End Get
      Set(ByVal value As Integer)
         Me._NumeroPlanilla = value
      End Set
   End Property

   Private _NumeroMovimiento As Integer
   Public Property NumeroMovimiento() As Integer
      Get
         Return Me._NumeroMovimiento
      End Get
      Set(ByVal value As Integer)
         Me._NumeroMovimiento = value
      End Set
   End Property

#End Region

End Class