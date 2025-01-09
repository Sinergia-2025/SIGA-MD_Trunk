<Serializable()>
Public Class FichaPago
   Inherits Eniac.Entidades.Entidad

#Region "Constructores"

   Public Sub New(ByVal idSucursal As Int32, ByVal usuario As String, ByVal pwd As String)
      Me.IdSucursal = idSucursal
      Me.Usuario = usuario
      Me.Password = pwd
   End Sub

#End Region

#Region "Campos"

   Private _idCliente As Long
   Private _nroOperacion As Integer
   'Private _tipoDocumento As String
   'Private _nroDocumento As String
   Private _nroCuota As Integer
   Private _fechaVencimiento As DateTime
   Private _importe As Decimal
   Private _saldo As Decimal

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

   Public Property NroCuota() As Integer
      Get
         Return Me._nroCuota
      End Get
      Set(ByVal value As Integer)
         Me._nroCuota = value
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
   Public Property Importe() As Decimal
      Get
         Return Me._importe
      End Get
      Set(ByVal value As Decimal)
         Me._importe = value
      End Set
   End Property
   Public Property FechaVencimiento() As DateTime
      Get
         Return Me._fechaVencimiento
      End Get
      Set(ByVal value As DateTime)
         Me._fechaVencimiento = value
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


   'Pertenecientes a CuentaCorrientePago para la pantalla de FichasABM2
   Public Property ImporteCapital As Decimal
   Public Property ImporteInteres As Decimal
   Public Property ReferenciaCuota As Long

#End Region

End Class