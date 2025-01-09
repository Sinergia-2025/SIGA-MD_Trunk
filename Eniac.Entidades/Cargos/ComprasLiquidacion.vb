Public Class ComprasLiquidacion
   Inherits Eniac.Entidades.Entidad

#Region "Propiedades"

   Public Property Sucursal() As Integer
   Public Property TipoComprobante() As Eniac.Entidades.TipoComprobante
   Public Property Letra() As String
   Public Property CentroEmisor() As Short
   Public Property NumeroComprobante() As Long
   Public Property Proveedor() As Eniac.Entidades.Proveedor
   Public Property Orden() As Long
   Public Property IdConcepto() As Integer
   Public Property OrdenLiquidacion() As Long

   Public Property ImporteALiquidar() As Decimal
   Public Property Liquidado() As Boolean
   Public Property PeriodoLiquidacion() As Integer
   Public Property FechaLiquidacion() As Date

   Public ReadOnly Property IdProveedor As Long
      Get
         If Proveedor Is Nothing Then Return 0
         Return Proveedor.IdProveedor
      End Get
   End Property

   Public ReadOnly Property IdTipoComprobante As String
      Get
         If TipoComprobante Is Nothing Then Return String.Empty
         Return TipoComprobante.IdTipoComprobante
      End Get
   End Property
#End Region

End Class