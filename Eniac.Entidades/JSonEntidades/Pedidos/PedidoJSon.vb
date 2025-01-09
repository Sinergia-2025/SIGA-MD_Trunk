Namespace JSonEntidades.Pedidos
   Public Class PedidoJSon
      Public Property id As Long
      Public Property CuitEmpresa As String
      Public Property IdSucursal As Integer
      Public Property IdTipoComprobante As String
      Public Property Letra As String
      Public Property CentroEmisor As Integer
      Public Property NumeroPedido As Long

      Public Property FechaPedido As String
      Public Property Observacion As String
      Public Property IdUsuario As String
      Public Property DescuentoRecargo As Decimal
      Public Property DescuentoRecargoPorc As Decimal
      Public Property IdCliente As Long
      Public Property IdVendedor As Integer
      Public Property TipoDocVendedor As String
      Public Property NroDocVendedor As String
      Public Property IdFormasPago As Integer?
      Public Property IdTransportista As Integer?
      Public Property CotizacionDolar As Decimal?
      Public Property IdTipoComprobanteFact As String
      Public Property ImporteBruto As Decimal
      Public Property SubTotal As Decimal
      Public Property TotalImpuestos As Decimal
      Public Property TotalImpuestoInterno As Decimal
      Public Property ImporteTotal As Decimal
      Public Property IdEstadoVisita As Integer
      Public Property NumeroOrdenCompra As Long?
      Public Property Kilos As Decimal
      Public Property IdMoneda As Integer
      Public Property IdClienteVinculado As Long?

      Public Property ObservacionInterna As String
      Public Property Palets As Integer
      Public Property NroVersionAplicacion As String
      Public Property NroVersionRemoto As String
      Public Property IdPedidoTiendaNube As String
      Public Property IdPedidoMercadoLibre As String
      Public Property IdLocalidad As Integer?
      Public Property Direccion As String
      Public Property Cuit As String
      Public Property TipoDocCliente As String
      Public Property NroDocCliente As Long?
      Public Property NombreClienteGenerico As String

      Public Property PedidosProductos As List(Of Pedidos.PedidoProductoJSon)
      'Public Property detalle As List(Of Pedidos.PedidoProductoJSon)

      Public Property IdDomicilio As Integer?

   End Class
End Namespace