<Serializable()>
Public Class CajaNombre
   Inherits Eniac.Entidades.Entidad

   Public Enum Columnas
      IdSucursal
      IdCaja
      NombreCaja
      NombrePC
      IdPlanCuenta
      TopeAviso
      TopeBloqueo
      IdCuentaContable
      IdUsuario
      Color
      IdTipoComprobanteF3
      IdTipoComprobanteF4
      IdTipoComprobanteF10Origen
      IdTipoComprobanteF10Destino
   End Enum

#Region "Propiedades"

   Private _idPlanCuenta As Integer
   Public Property IdPlanCuenta() As Integer
      Get
         Return Me._idPlanCuenta
      End Get
      Set(ByVal value As Integer)
         Me._idPlanCuenta = value
      End Set
   End Property

   Private _idCuentaContable As Long
   Public Property IdCuentaContable() As Long
      Get
         Return Me._idCuentaContable
      End Get
      Set(ByVal value As Long)
         Me._idCuentaContable = value
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

   Private _nombreCaja As String
   Public Property NombreCaja() As String
      Get
         Return Me._nombreCaja
      End Get
      Set(ByVal value As String)
         Me._nombreCaja = value
      End Set
   End Property

   Private _nombrePC As String
   Public Property NombrePC() As String
      Get
         Return Me._nombrePC
      End Get
      Set(ByVal value As String)
         Me._nombrePC = value
      End Set
   End Property

   Private _nombreSucursal As String
   Public Property NombreSucursal() As String
      Get
         Return _nombreSucursal
      End Get
      Set(ByVal value As String)
         _nombreSucursal = value
      End Set
   End Property

   Private _topeAviso As Decimal = 0
   Public Property TopeAviso() As Decimal
      Get
         Return Me._topeAviso
      End Get
      Set(ByVal value As Decimal)
         Me._topeAviso = value
      End Set
   End Property

   Private _topeBloqueo As Decimal = 0
   Public Property TopeBloqueo() As Decimal
      Get
         Return Me._topeBloqueo
      End Get
      Set(ByVal value As Decimal)
         Me._topeBloqueo = value
      End Set
   End Property

   Private _idUsuario As String
   Public Property IdUsuario() As String
      Get
         Return Me._idUsuario
      End Get
      Set(ByVal value As String)
         Me._idUsuario = value
      End Set
   End Property

   Public Property Color As Integer?

   Public Overrides Function ToString() As String
      Return Me.NombreSucursal + " - " + Me.NombreCaja
   End Function

   Public Property IdTipoComprobanteF3 As String
   Public Property IdTipoComprobanteF4 As String
   Public Property IdTipoComprobanteF10Origen As String
   Public Property IdTipoComprobanteF10Destino As String

#End Region

End Class