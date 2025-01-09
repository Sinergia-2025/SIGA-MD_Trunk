Public Class OrdenProduccionMRPProducto
   Inherits Entidad

   Public Const NombreTabla As String = "OrdenesProduccionMRPProductos"

#Region "Columnas"
   Public Enum Columnas
      IdSucursal
      IdTipoComprobante
      LetraComprobante
      CentroEmisor
      NumeroOrdenProduccion
      Orden
      IdProducto
      IdProcesoProductivo
      IdOperacion
      IdProductoProceso
      CantidadSolicitada
      PrecioCostoProducto
      EsProductoNecesario
      IdSucursalOrigen
      IdDepositoOrigen
      IdUbicacionOrigen
      IdSucursalOP
      IdTipoComprobanteOP
      LetraComprobanteOP
      CentroEmisorOP
      NumeroOrdenProduccionOP
      OrdenOP
      IdProductoOP
      IdRequerimiento
      IdProductoRQ
      ORdenRQ
      EstadoCompra
      CantidadProcesada
      CantidadUnitaria
   End Enum
#End Region

#Region "New"
   Public Sub New()
      MRPProducto = New Entidades.MRPProcesoProductivoProducto
   End Sub
#End Region

#Region "Propiedades"
   Public Property IdTipoComprobante As String
   Public Property LetraComprobante As String
   Public Property CentroEmisor As Integer
   Public Property NumeroOrdenProduccion As Long
   Public Property Orden As Integer
   Public Property IdProducto As String
   Public Property MRPProducto As Entidades.MRPProcesoProductivoProducto
   Public Property CantidadProcesada As Decimal
   Public Property CantidadUnitaria As Decimal
   Public Property IdSucursalOrigen As Integer
   Public Property IdDepositoOrigen As Integer
   Public Property IdUbicacionOrigen As Integer
   Public Property IdSucursalOP As Integer
   Public Property IdTipoComprobanteOP As String
   Public Property LetraComprobanteOP As String
   Public Property CentroEmisorOP As Integer
   Public Property NumeroOrdenProduccionOP As Long
   Public Property OrdenOP As Integer
   Public Property IdProductoOP As String
   Public Property EstadoCompra As String
   Public Property IdRequerimiento As Long
   Public Property IdProductoRQ As String
   Public Property OrdenRQ As Integer
#End Region

#Region "Propiedades no pertenecientes a la Entidad"

#End Region

End Class
