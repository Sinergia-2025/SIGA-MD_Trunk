Public Class MRPProcesoProductivo
   Inherits Entidad

   Public Const NombreTabla As String = "MRPProcesosProductivos"

   Public Enum Columnas
      IdProcesoProductivo
      IdProductoProceso
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

   Public Sub New()
      Operaciones = New ListConBorrados(Of MRPProcesoProductivoOperacion)()
   End Sub
   Public Property IdProcesoProductivo As Long
   Public Property IdProductoProceso As String
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

   Public Property Operaciones As ListConBorrados(Of MRPProcesoProductivoOperacion)

   Public Function Copiar() As MRPProcesoProductivo
      Return Clonar(Me)
   End Function

#Region "Propiedades no pertenecientes a la Entidad"
   Public Property NombreProducto As String
   Public Property TotalTiempoProceso As TimeSpan

   Public Property NewCostoManoObraInterna As Decimal
   Public Property NewCostoManoObraExterna As Decimal
   Public Property NewCostoMateriaPrima As Decimal
   Public Property NewCostoTotalProceso As Decimal
   Public Property CostoProductoSucursal As Decimal

#End Region

End Class
