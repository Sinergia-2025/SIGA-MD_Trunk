Imports Eniac.Entidades.MRPProcesoProductivoOperacion

Public Class OrdenProduccionMRPOperacion_PK
   Inherits Entidad

   Public Property IdTipoComprobante As String
   Public Property LetraComprobante As String
   Public Property CentroEmisor As Integer
   Public Property NumeroOrdenProduccion As Long
   Public Property Orden As Integer
   Public Property IdProducto As String

   Public Property IdProcesoProductivo As Long
   Public Property IdOperacion As Integer

End Class
Public Class OrdenProduccionMRPOperacion
   Inherits OrdenProduccionMRPOperacion_PK

   Public Const NombreTabla As String = "OrdenesProduccionMRPOperaciones"

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
      CodigoProcProdOperacion
      DescripcionOperacion
      IdCodigoTarea
      SucursalOperacion
      DepositoOperacion
      UbicacionOperacion
      CentroProductorOperacion
      PAPTiemposMaquina
      PAPTiemposHHombre
      ProdTiemposMaquina
      ProdTiemposHHombre
      Proveedor
      NormasDispositivos
      NormasMetodos
      NormasSeguridad
      NormasControlCalidad
      CostoExterno
      UnidadesHora

      IdEstadoTarea
      FechaComienzo
      IdEmpleado

      TipoOperacionExterna
      IdOperacionExternaVinculada

      'NombreProducto
      'IdCentroProductor
      'DescripcionCentro
      'NombreProveedor
      'IdCliente
      'NombreCliente
      'FechaEstado
      'Masivo
   End Enum
#End Region

#Region "New"
   Public Sub New()
      ProductosNecesarios = New ListConBorrados(Of OrdenProduccionMRPProducto)()
      ProductosResultantes = New ListConBorrados(Of OrdenProduccionMRPProducto)()
      CategoriasEmpleados = New ListConBorrados(Of OrdenProduccionMRPCategoriaEmpleado)()
   End Sub
#End Region

#Region "Propiedades"
   'Public Property IdTipoComprobante As String
   'Public Property LetraComprobante As String
   'Public Property CentroEmisor As Integer
   'Public Property NumeroOrdenProduccion As Long
   'Public Property Orden As Integer
   'Public Property IdProducto As String

   'Public Property IdProcesoProductivo As Long
   'Public Property IdOperacion As Integer
   Public Property CodigoProcProdOperacion As String
   Public Property DescripcionOperacion As String
   Public Property IdCodigoTarea As Integer
   Public Property SucursalOperacion As Integer
   Public Property DepositoOperacion As Integer
   Public Property UbicacionOperacion As Integer
   Public Property CentroProductorOperacion As Integer
   Public Property UnidadesHora As Decimal
   Public Property PAPTiemposMaquina As Decimal
   Public Property PAPTiemposHHombre As Decimal
   Public Property ProdTiemposMaquina As Decimal
   Public Property ProdTiemposHHombre As Decimal
   Public Property Proveedor As Long
   Public Property CostoExterno As Decimal
   Public Property NormasDispositivos As String
   Public Property NormasMetodos As String
   Public Property NormasSeguridad As String
   Public Property NormasControlCalidad As String

   Public Property IdEstadoTarea As String
   Public Property FechaComienzo As Date
   Public Property IdEmpleado As Integer

   Public Property TipoOperacionExterna As OperacionesExternas?
   Public Property IdOperacionExternaVinculada As Integer?

   Public Property ProductosNecesarios As ListConBorrados(Of OrdenProduccionMRPProducto)
   Public Property ProductosResultantes As ListConBorrados(Of OrdenProduccionMRPProducto)
   Public Property CategoriasEmpleados As ListConBorrados(Of OrdenProduccionMRPCategoriaEmpleado)
#End Region

#Region "Propiedades no pertenecientes a la Entidad"
   Public Property NombreProducto As String        ' FK Productos
   <Obsolete("Usar CentroProductorOperacion")>
   Public Property IdCentroProductor As Integer
   Public Property DescripcionCentro As String     ' FK MRPCentrosProductores
   Public Property CodigoProveedor As Long         ' FK Proveedores
   Public Property NombreProveedor As String       ' FK Proveedores

   Public Property IdCliente As Long               ' FK OrdenesProduccion
   Public Property CodigoCliente As Long           ' FK OrdenesProduccion -> Clientes
   Public Property NombreCliente As String         ' FK OrdenesProduccion -> Clientes
   'Public Property FechaEstado As Date             ' FK OrdenesProduccionEstados

   Public Property Masivo As Boolean               ' Para selección masiva en pantalla

#Region "Propiedades Para Impresion de Hoja de Ruta"
   Public Property CantidadOP As Decimal
   Public Property FechaEntrega As DateTime
   Public Property NumeroPedido As Integer
   Public Property LineaPedido As Integer

#End Region

#End Region

End Class