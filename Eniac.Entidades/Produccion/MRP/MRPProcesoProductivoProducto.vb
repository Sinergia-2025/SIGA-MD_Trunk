Public Class MRPProcesoProductivoProducto
   Inherits Entidad

   Public Const NombreTabla As String = "MRPProcesosProductivosProductos"
   Public Enum Columnas
      IdOperacion
      IdProcesoProductivo
      IdProductoProceso
      CantidadSolicitada
      PrecioCostoProducto
      EsProductoNecesario
      IdSucursalOrigen
      IdDepositoOrigen
      IdUbicacionOrigen
   End Enum

   Public Property IdOperacion As Integer
   Public Property IdProcesoProductivo As Long
   Public Property IdProductoProceso As String
   Public Property CantidadSolicitada As Decimal
   Public Property PrecioCostoProducto As Decimal
   Public Property EsProductoNecesario As Boolean
   Public Property IdSucursalOrigen As Integer
   Public Property IdDepositoOrigen As Integer
   Public Property IdUbicacionOrigen As Integer


#Region "Propiedades no pertenecientes a la Entidad"
   Public Property CodigoProcProdOperacion As String
   Public Property NombreProducto As String
   Public Property UnidadMedidaProd As String
   Public Property NombreDeposito As String
   Public Property NombreUbicacion As String
   Public Property CostosProducto As Decimal
   Public Property NewPrecioCostoProducto As Decimal
   Public Property NewCostosProducto As Decimal
   Public Property FechaUltimaActualizacion As Date
   Public Property EstadoValorGrilla As String

   Public Property IdProveedor As Long
   Public Property NombreProveedor As String

   Public Property CodigoProcesoProductivo As String
   Public Property NombreProcesoProductivo As String

   Public Property IdMonedaProducto As Integer
   Public Property NombreMonedaProducto As String
   Public Property CostosProductoMoneda As Decimal
   Public Property CotizaProductoMoneda As Decimal
#End Region

End Class
