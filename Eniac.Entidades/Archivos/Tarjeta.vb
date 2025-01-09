Public Class Tarjeta
   Inherits Entidad
   Public Const NombreTabla As String = "Tarjetas"

   Public Enum Columnas
      IdTarjeta
      NombreTarjeta
      TipoTarjeta
      Habilitada
      Acreditacion
      IdCuentaBancaria
      CantDiasAcredit
      PagoPosVenta
      PagoPosCorte
      DiaCorte
      PagoDiaMes
      DiaMes
      IdCuentaContable
      PorcIntereses
      CantidadCuotas
      IdProveedor
   End Enum

#Region "Propiedades"

   Private _idTarjeta As Integer
   Public Property IdTarjeta() As Integer
      Get
         Return _idTarjeta
      End Get
      Set(ByVal value As Integer)
         _idTarjeta = value
      End Set
   End Property

   Private _nombreTarjeta As String
   Public Property NombreTarjeta() As String
      Get
         Return _nombreTarjeta
      End Get
      Set(ByVal value As String)
         _nombreTarjeta = value
      End Set
   End Property

   Public Enum TiposTarjetas
      Debito
      Credito
   End Enum

   Private _tipoTarjeta As TiposTarjetas
   Public Property TipoTarjeta() As TiposTarjetas
      Get
         Return _tipoTarjeta
      End Get
      Set(ByVal value As TiposTarjetas)
         _tipoTarjeta = value
      End Set
   End Property

   Private _habilitada As Boolean
   Public Property Habilitada() As Boolean
      Get
         Return _habilitada
      End Get
      Set(ByVal value As Boolean)
         _habilitada = value
      End Set
   End Property

   Private _acreditacion As Boolean
   Public Property Acreditacion() As Boolean
      Get
         Return _acreditacion
      End Get
      Set(ByVal value As Boolean)
         _acreditacion = value
      End Set
   End Property

   Private _cuentaBancaria As Entidades.CuentaBancaria
   Public Property CuentaBancaria() As Entidades.CuentaBancaria
      Get
         If Me._cuentaBancaria Is Nothing Then
            Me._cuentaBancaria = New Entidades.CuentaBancaria()
         End If
         Return Me._cuentaBancaria
      End Get
      Set(ByVal value As Entidades.CuentaBancaria)
         Me._cuentaBancaria = value
      End Set
   End Property

   Private _cantDiasAcredit As Integer
   Public Property CantDiasAcredit() As Integer
      Get
         Return _cantDiasAcredit
      End Get
      Set(ByVal value As Integer)
         _cantDiasAcredit = value
      End Set
   End Property

   Private _pagoposventa As Boolean
   Public Property PagoPosVenta() As Boolean
      Get
         Return _pagoposventa
      End Get
      Set(ByVal value As Boolean)
         _pagoposventa = value
      End Set
   End Property

   Private _pagoposcorte As Boolean
   Public Property PagoPosCorte() As Boolean
      Get
         Return _pagoposcorte
      End Get
      Set(ByVal value As Boolean)
         _pagoposcorte = value
      End Set
   End Property

   Private _diaCorte As Integer
   Public Property DiaCorte() As Integer
      Get
         Return _diaCorte
      End Get
      Set(ByVal value As Integer)
         _diaCorte = value
      End Set
   End Property

   Private _pagoDiaMes As Boolean
   Public Property PagoDiaMes() As Boolean
      Get
         Return _pagoDiaMes
      End Get
      Set(ByVal value As Boolean)
         _pagoDiaMes = value
      End Set
   End Property

   Private _diaMes As Integer
   Public Property DiaMes() As Integer
      Get
         Return _diaMes
      End Get
      Set(ByVal value As Integer)
         _diaMes = value
      End Set
   End Property

   Private _cuentaContable As ContabilidadCuenta
   Public Property CuentaContable() As ContabilidadCuenta
      Get
         Return _cuentaContable
      End Get
      Set(ByVal value As ContabilidadCuenta)
         _cuentaContable = value
      End Set
   End Property

   Public Property PorcIntereses() As Decimal
   Public Property CantidadCuotas() As Integer
   Public Property IdProveedor() As Integer
   Public Property CodigoProveedor() As Integer
   Public Property NombreProveedor() As String

#End Region

End Class
