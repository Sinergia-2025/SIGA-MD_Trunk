Public Class OrdenProduccionMRPPK
   Inherits Entidad
   Public Property IdTipoComprobante As String
   Public Property LetraComprobante As String
   Public Property CentroEmisor As Integer
   Public Property NumeroOrdenProduccion As Long
   Public Property Orden As Integer
   Public Property IdProducto As String
   Public Property IdProcesoProductivo As Long

End Class
Public Class OrdenProduccionMRP
   Inherits OrdenProduccionMRPPK

   Public Const NombreTabla As String = "OrdenesProduccionMRP"

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
      CodigoProcesoProductivo
      DescripcionProceso
      CostoManoObraInterna
      CostoManoObraExterna
      CostoMateriaPrima
      CostoTotalProceso
      FechaAltaProceso
      FechaModificaProceso
      FechaActualizaCostos
      TiempoTotalProceso
      IdArchivoAdjunto
      RespetaOrden
      Activo
   End Enum
#End Region

#Region "New"
   Public Sub New()
      Operaciones = New ListConBorrados(Of OrdenProduccionMRPOperacion)()
   End Sub
#End Region

#Region "Propiedades"
   Public Property CodigoProcesoProductivo As String
   Public Property DescripcionProceso As String
   Public Property CostoManoObraInterna As Decimal
   Public Property CostoManoObraExterna As Decimal
   Public Property CostoMateriaPrima As Decimal
   Public Property CostoTotalProceso As Decimal
   Public Property FechaAltaProceso As Date
   Public Property FechaModificaProceso As Date
   Public Property FechaActualizaCostos As Date
   Public Property TiempoTotalProceso As Decimal
   Public Property IdArchivoAdjunto As Integer?
   Public Property RespetaOrden As Boolean
   Public Property Activo As Boolean
   Public Property Operaciones As ListConBorrados(Of OrdenProduccionMRPOperacion)
#End Region

#Region "Propiedades no pertenecientes a la Entidad"

#End Region

End Class
