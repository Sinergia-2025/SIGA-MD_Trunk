<Serializable()>
Public Class Cargo
   Inherits Entidades.Entidad

   Public Enum Columnas
      IdCargo
      IdTipoLiquidacion
      NombreCargo
      Monto
      Activo
      ImprimeVoucher
      CantidadMeses
      ModificaImporte
      CantidadCuotas
      CuotaActual
      ModificaCantidad
      IdProducto
      IdSucursal
      CargoTemporal
   End Enum
   Public Enum ColumnasCargos
      MontoOriginal
   End Enum

   Private _idCargo As Integer = 0
   Public Property IdCargo() As Integer
      Get
         Return Me._idCargo
      End Get
      Set(ByVal value As Integer)
         Me._idCargo = value
      End Set
   End Property

   Private _idTipoLiquidacion As Integer = 0
   Public Property IdTipoLiquidacion() As Integer
      Get
         Return Me._idTipoLiquidacion
      End Get
      Set(ByVal value As Integer)
         Me._idTipoLiquidacion = value
      End Set
   End Property

   Private _nombreCargo As String = ""
   Public Property NombreCargo() As String
      Get
         Return Me._nombreCargo
      End Get
      Set(ByVal value As String)
         Me._nombreCargo = value
      End Set
   End Property

   Private _monto As Decimal = 0
   Public Property Monto() As Decimal
      Get
         Return Me._monto
      End Get
      Set(ByVal value As Decimal)
         Me._monto = value
      End Set
   End Property

   Private _activo As Boolean = False
   Public Property Activo() As Boolean
      Get
         Return _activo
      End Get
      Set(ByVal value As Boolean)
         _activo = value
      End Set
   End Property

   Private _imprimeVoucher As Boolean = False
   Public Property ImprimeVoucher() As Boolean
      Get
         Return _imprimeVoucher
      End Get
      Set(ByVal value As Boolean)
         _imprimeVoucher = value
      End Set
   End Property

   Private _cantidadMeses As Integer? = Nothing
   Public Property CantidadMeses() As Integer?
      Get
         Return Me._cantidadMeses
      End Get
      Set(ByVal value As Integer?)
         Me._cantidadMeses = value
      End Set
   End Property

   Private _modificaImporte As Boolean = False
   Public Property ModificaImporte() As Boolean
      Get
         Return _modificaImporte
      End Get
      Set(ByVal value As Boolean)
         _modificaImporte = value
      End Set
   End Property

   Private _cantidadCuotas As Integer? = Nothing
   Public Property CantidadCuotas() As Integer?
      Get
         Return Me._cantidadCuotas
      End Get
      Set(ByVal value As Integer?)
         Me._cantidadCuotas = value
      End Set
   End Property

   Private _cuotaActual As Integer? = Nothing
   Public Property CuotaActual() As Integer?
      Get
         Return Me._cuotaActual
      End Get
      Set(ByVal value As Integer?)
         Me._cuotaActual = value
      End Set
   End Property

   Private _modificaCantidad As Boolean = False
   Public Property ModificaCantidad() As Boolean
      Get
         Return _modificaCantidad
      End Get
      Set(ByVal value As Boolean)
         _modificaCantidad = value
      End Set
   End Property

   Private _producto As Eniac.Entidades.Producto
   Public Property Producto() As Eniac.Entidades.Producto
      Get
         Return _producto
      End Get
      Set(ByVal value As Eniac.Entidades.Producto)
         _producto = value
      End Set
   End Property

   Public ReadOnly Property IdProducto() As String
      Get
         If Producto Is Nothing Then Return String.Empty
         Return Producto.IdProducto
      End Get
   End Property

   Public Property CargoTemporal() As Boolean

End Class