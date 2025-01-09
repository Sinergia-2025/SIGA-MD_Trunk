Option Explicit On
Option Strict On

<Serializable()> _
Public Class MovimientoStock
   Inherits Eniac.Entidades.Entidad

   Public Enum Columnas
      IdSucursal
      IdTipoMovimiento
      NumeroMovimiento
      Orden
      IdProducto
      Cantidad
      FechaMovimiento
   End Enum

#Region "Campos"

   Private _movimientoVenta As Entidades.MovimientoVenta
   Private _movimientoCompra As Entidades.MovimientoCompra
   Private _productoSucursal As Entidades.ProductoSucursal = Nothing
   Private _orden As Integer
   Private _cantidad As Decimal = 0
   Private _fechaMovimiento As DateTime


#End Region

#Region "Propiedades"

   Public Property MovimientoVenta() As Entidades.MovimientoVenta
      Get
         If Me._movimientoVenta Is Nothing Then
            Me._movimientoVenta = New MovimientoVenta()
         End If
         Return Me._movimientoVenta
      End Get
      Set(ByVal value As Entidades.MovimientoVenta)
         Me._movimientoVenta = value
      End Set
   End Property
   Public Property MovimientoCompra() As Entidades.MovimientoCompra
      Get
         If Me._movimientoCompra Is Nothing Then
            Me._movimientoCompra = New MovimientoCompra()
         End If
         Return Me._movimientoCompra
      End Get
      Set(ByVal value As Entidades.MovimientoCompra)
         Me._movimientoCompra = value
      End Set
   End Property

   Public Property ProductoSucursal() As Entidades.ProductoSucursal
      Get
         If Me._productoSucursal Is Nothing Then
            Me._productoSucursal = New Entidades.ProductoSucursal()
         End If
         Return Me._productoSucursal
      End Get
      Set(ByVal value As Entidades.ProductoSucursal)
         Me._productoSucursal = value
      End Set
   End Property

   Public Property Orden() As Integer
      Get
         Return Me._orden
      End Get
      Set(ByVal value As Integer)
         Me._orden = value
      End Set
   End Property

   Public Property Cantidad() As Decimal
      Get
         Return Me._cantidad
      End Get
      Set(ByVal value As Decimal)
         Me._cantidad = value
      End Set
   End Property

   Public Property FechaMovimiento() As DateTime
      Get
         Return Me._fechaMovimiento
      End Get
      Set(ByVal value As DateTime)
         Me._fechaMovimiento = value
      End Set
   End Property


#End Region

End Class
