Namespace JSonEntidades.Pedidos
   Public Class PedidoProductoJSon
      Public Property CuitEmpresa As String
      Public Property IdSucursal As Integer
      Public Property IdTipoComprobante As String
      Public Property Letra As String
      Public Property CentroEmisor As Integer
      Public Property NumeroPedido As Long

      Public Property IdProducto As String
      Public Property Cantidad As Decimal
      Public Property Precio As Decimal
      Public Property Costo As Decimal
      Public Property ImporteTotal As Decimal
      Public Property NombreProducto As String
      Public Property CantEntregada As Decimal
      Public Property CantEnProceso As Decimal
      Public Property Orden As Integer
      Public Property DescuentoRecargoProducto As Decimal
      Public Property DescuentoRecargoPorc2 As Decimal?
      Public Property DescuentoRecargoPorc As Decimal?
      Public Property IdTipoImpuesto As String
      Public Property AlicuotaImpuesto As Decimal
      Public Property ImporteImpuesto As Decimal
      Public Property PrecioLista As Decimal
      Public Property FechaActualizacion As String
      Public Property IdListaPrecios As Integer
      Public Property NombreListaPrecios As String
      Public Property ImporteImpuestoInterno As Decimal
      Public Property PorcImpuestoInterno As Decimal
      Public Property PrecioNeto As Decimal
      Public Property ImporteTotalNeto As Decimal
      Public Property DescRecGeneral As Decimal
      Public Property DescRecGeneralProducto As Decimal
      Public Property Kilos As Decimal
      Public Property IdCriticidad As String
      Public Property FechaEntrega As String
      Public Property CantAnulada As Decimal
      Public Property CantPendiente As Decimal
      Public Property PrecioConImpuestos As Decimal
      Public Property PrecioNetoConImpuestos As Decimal
      Public Property ImporteTotalConImpuestos As Decimal
      Public Property ImporteTotalNetoConImpuestos As Decimal
      Public Property PrecioVentaPorTamano As Decimal
      Public Property Tamano As Decimal?
      Public Property IdUnidadDeMedida As String
      Public Property IdMoneda As Integer?
      Public Property ModificoPrecioManualmente As Boolean
      Public Property CantidadManual As Decimal
      Public Property Conversion As Decimal
      'Del Turco
      Public Property IdPlazoEntrega As Integer
      Public Property ModificoDescuentos As Boolean

   End Class
End Namespace