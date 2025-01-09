Imports Eniac.Entidades.MRPCentroProductor

Public Class MRPProcesoProductivoOperacion
   Inherits Entidad

   Public Const NombreTabla As String = "MRPProcesosProductivosOperaciones"

   Public Enum Columnas
      IdOperacion
      IdProcesoProductivo
      CodigoProcProdOperacion
      DescripcionOperacion
      IdCodigoTarea
      SucursalOperacion
      DepositoOperacion
      UbicacionOperacion
      CentroProductorOperacion
      UnidadesHora
      PAPTiemposMaquina
      PAPTiemposHHombre
      ProdTiemposMaquina
      ProdTiemposHHombre
      Proveedor
      CostoExterno
      NormasDispositivos
      NormasMetodos
      NormasSeguridad
      NormasControlCalidad
      TipoOperacionExterna
      IdOperacionExternaVinculada

   End Enum

   Public Sub New()
      IdOperacion = 0
      IdProcesoProductivo = 0
      SucursalOperacion = 0
      DepositoOperacion = 0
      UbicacionOperacion = 0
      ProductosNecesario = New ListConBorrados(Of MRPProcesoProductivoProducto)()
      ProductosResultantes = New ListConBorrados(Of MRPProcesoProductivoProducto)()
      CategoriasEmpleados = New ListConBorrados(Of MRPProcesoProductivoCategoriaEmpleado)()
   End Sub

   Public Property IdOperacion As Integer
   Public Property IdProcesoProductivo As Long
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
   Public Property TipoOperacionExterna As OperacionesExternas?
   Public Property IdOperacionExternaVinculada As Integer?

   Public Property ProductosNecesario As ListConBorrados(Of MRPProcesoProductivoProducto)
   Public Property ProductosResultantes As ListConBorrados(Of MRPProcesoProductivoProducto)
   Public Property CategoriasEmpleados As ListConBorrados(Of MRPProcesoProductivoCategoriaEmpleado)

#Region "Propiedades no pertenecientes a la Entidad"
   Public Property NombreDeposito As String
   Public Property NombreUbicacion As String
   Public Property EstadoOperacion As String

   Public Property DotacionCentroProductor As Integer
   Public Property ClaseCentroProductor As ClaseCentrosProd

   Public Property IdTareaOperacion As Integer

   Public Property IdProductoPrincipal As String
   Public Property DescripcionProductoPrincipal As String
#End Region

   Public Enum OperacionesExternas
      <Description("ENVIO")> ENVIO
      <Description("RECEPCION")> RECEPCION
   End Enum

   Public Enum EstadoAsignaTarea
      <Description("PENDIENTE")> PENDIENTE
      <Description("LIBERADA")> LIBERADA
      <Description("PAUSADA")> PAUSADA
      <Description("FINALIZADA")> FINALIZADA
   End Enum

End Class
