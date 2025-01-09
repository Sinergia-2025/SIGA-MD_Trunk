Public Class MRPProductosNecesarios
   Inherits Entidad


   Public Property IdSucursal As Integer
   Public Property IdTipoComprobante As String
   Public Property LetraComprobante As String
   Public Property CentroEmisor As Integer
   Public Property NumeroOrdenProduccion As Long
   Public Property Orden As Integer
   Public Property IdProcesoProductivo As Long
   Public Property TiempoProcesoProductivo As Decimal

   Public Property IdProductoProceso As String
   Public Property NombreProductoProceso As String

   Public Property FechaEntrega As DateTime
   Public Property FechaFinaliza As DateTime

   Public Property CantidadSolicitada As Decimal

   Public Property CantidadStock As Decimal
   Public Property CantidadFabricar As Decimal
   Public Property FactorConversionCompra As Decimal                 'Se usa en Planificación de Requerimientos de Compra para calcular los Cantidad UMC
   Public ReadOnly Property CantidadUMCompraFabricar As Decimal        'Se usa en Planificación de Requerimientos de Compra para mostrar los Cantidad UMC a Comprar
      Get
         Return CantidadFabricar * FactorConversionCompra
      End Get
   End Property
   Public Property CantidadUnitaria As Decimal

   Public Property CantidadProcesoProd As Decimal

   Public Property EsProductoNecesario As Boolean

   Public Property StockMaximo As Decimal
   Public Property StockMinimo As Decimal
   Public Property DepositoDefecto As Integer


   Public Property IdCliente As Long
   Public Property NombreCliente As String

   Public Property nodoPadre As Integer
   Public Property nodo As Integer


   Public Property IdSucursalNodo As Integer
   Public Property IdTipoComprobanteNodo As String
   Public Property LetraNodo As String
   Public Property CentroEmisorNodo As Integer
   Public Property NumeroOrdenProduccionNodo As Long
   Public Property OrdenNodo As Integer


   Public Property IdResponsable As Integer
   Public Property IdCriticidad As String

   Public Property Cliente As Cliente
   Public Property Transportista As Transportista
   Public Property FormaPago As VentaFormaPago
   Public Property TipoComprobanteFact As TipoComprobante
   Public Property EstadoVisita As EstadoVisita

#Region "Propiedas externas a la entidad"
   Public Property UnidadMedidaDestino As String
   Public Property UnidadMedidaCompra As String

   Public Property IdProductoOrigen As String

   '-- REQ-42263.- ------------------------------
   Public Property ProcesoActivo As Boolean
   '---------------------------------------------
#End Region


End Class
