Public Class PedidoProductoProveedor
   Inherits Entidad

   Public Const NombreTabla As String = "PedidosProductosProveedores"

   Public Enum Columnas
      IdSucursal
      IdTipoComprobante
      Letra
      CentroEmisor
      NumeroPedido
      IdProducto
      Orden

      IdProveedor
      Cantidad
      CostoLista
      Costo
      CostoNeto

      DescuentoRecargoPorc
      DescuentoRecargoPorc2
      DescuentoRecargoProducto

      DescRecGeneral
      DescRecGeneralProducto

      AlicuotaImpuesto
      ImporteImpuesto

      ImpuestoInterno
      ImporteImpuestoInterno
      PorcImpuestoInterno

      ImporteTotal
      ImporteTotalNeto

      NombreProducto
      CantPendiente
      CantEntregada
      CantEnProceso
      CantAnulada
      IdTipoImpuesto
      FechaActualizacion
      IdUnidadDeMedidaCompra
      CantidadUMCompra
      FactorConversionCompra
      PrecioPorUMCompra

      CostoConImpuestos
      CostoNetoConImpuestos
      ImporteTotalConImpuestos
      ImporteTotalNetoConImpuestos
      IdUnidadDeMedida
      'Precio
      'IdListaPrecios
      'NombreListaPrecios
   End Enum
   'Public Property Precio As Decimal
   'Public Property IdListaPrecios As Integer
   'Public Property NombreListaPrecios As String

   Public Sub New()
      Proveedor = New Proveedor()
      PedidosEstados = New List(Of PedidoEstadoProveedor)()
   End Sub

   Public ReadOnly Property IdTipoComprobante As String
      Get
         If TipoComprobante Is Nothing Then Return String.Empty
         Return TipoComprobante.IdTipoComprobante
      End Get
   End Property
   Public Property TipoComprobante As Entidades.TipoComprobante
   Public Property Letra As String
   Public Property CentroEmisor As Integer
   Public Property NumeroPedido As Long
   Public Property Producto As Entidades.Producto
   Public Property Orden As Integer

   Public Property Proveedor As Proveedor

   Public Property Cantidad As Decimal
   Public Property CostoLista As Decimal
   Public Property Costo As Decimal
   Public Property CostoNeto As Decimal

   Public Property DescuentoRecargoPorc As Decimal
   Public Property DescuentoRecargoPorc2 As Decimal
   Public Property DescuentoRecargoProducto As Decimal

   Public Property DescRecGeneral As Decimal
   Public Property DescRecGeneralProducto As Decimal

   Public Property TipoImpuesto As TipoImpuesto
   Public Property AlicuotaImpuesto As Decimal
   Public Property ImporteImpuesto As Decimal

   Public Property ImpuestoInterno As Decimal
   Public Property ImporteImpuestoInterno As Decimal
   Public Property PorcImpuestoInterno As Decimal


   Public Property ImporteTotal As Decimal
   Public Property ImporteTotalNeto As Decimal

   Public Property CantPendiente As Decimal
   Public Property CantEntregada As Decimal
   Public Property CantEnProceso As Decimal
   Public Property CantAnulada As Decimal

   Public Property FechaActualizacion As Date

   Public Property IdUnidadDeMedidaCompra As String
   Public Property CantidadUMCompra As Decimal
   Public Property FactorConversionCompra As Decimal
   Public Property PrecioPorUMCompra As Decimal


   Public Property CostoConImpuestos As Decimal
   Public Property CostoNetoConImpuestos As Decimal
   Public Property ImporteTotalConImpuestos As Decimal
   Public Property ImporteTotalNetoConImpuestos As Decimal
   Public Property CodigoProductoProveedor As String

   Public Property IdUnidadDeMedida As String
   ''TODO: Agregar el campo en BD
   'Public Property CantPendiente As Decimal

   Public Property PedidosEstados As List(Of PedidoEstadoProveedor)


#Region "Propiedades para Insertar PedidosEstados"
   Public Property IdCriticidad() As String
   Public Property FechaEntrega() As Date
#End Region


#Region "Propiedades de Calculo"
   Public Property Stock As Decimal
#End Region

#Region "Propiedades ReadOnly"
   Public ReadOnly Property IdTipoImpuesto As Entidades.TipoImpuesto.Tipos
      Get
         If TipoImpuesto Is Nothing Then Return Nothing
         Return TipoImpuesto.IdTipoImpuesto
      End Get
   End Property

   Public ReadOnly Property IdProducto As String
      Get
         If Producto Is Nothing Then Return String.Empty
         Return Producto.IdProducto
      End Get
   End Property

   Public Property NombreProducto() As String
      Get
         If Producto Is Nothing Then Return String.Empty
         Return Producto.NombreProducto
      End Get
      Set(value As String)
         Producto.NombreProducto = value
      End Set
   End Property

#End Region

End Class