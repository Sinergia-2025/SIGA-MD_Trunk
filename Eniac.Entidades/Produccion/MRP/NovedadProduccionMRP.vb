Imports Eniac.Entidades.MRPCentroProductor

Public Class NovedadProduccionMRP
   Inherits Entidad

   Public Const NombreTabla As String = "NovedadesProduccionMRP"

#Region "Columnas"
   Public Enum Columnas
      NumeroNovedadesProducccion
      CodigoOperacion
      IdSucursal
      IdTipoComprobante
      LetraComprobante
      CentroEmisor
      NumeroOrdenProduccion
      Orden
      IdProducto
      IdProcesoProductivo
      UsuarioAlta
      FechaAlta
      FechaNovedad
      IdEmpleado
   End Enum
#End Region
   Public Sub New()
      NumeroNovedadesProducccion = 0
      TiemposNovedades = New ListConBorrados(Of NovedadProduccionMRPTiempo)()
      ProductosNecesarios = New ListConBorrados(Of NovedadProduccionMRPProducto)()
      ProductosResultantes = New ListConBorrados(Of NovedadProduccionMRPProducto)()
   End Sub

#Region "Propiedades"
   Public Property NumeroNovedadesProducccion As Integer
   Public Property CodigoOperacion As String
   Public Property IdTipoComprobante As String
   Public Property LetraComprobante As String
   Public Property CentroEmisor As Integer
   Public Property NumeroOrdenProduccion As Integer
   Public Property Orden As Integer
   Public Property IdProducto As String
   Public Property IdProcesoProductivo As Long
   Public Property UsuarioAlta As String
   Public Property FechaAlta As DateTime
   Public Property FechaNovedad As DateTime
   Public Property IdEmpleado As Integer
   Public Property IdOperacion As Integer

   Public Property TiemposNovedades As ListConBorrados(Of NovedadProduccionMRPTiempo)
   Public Property ProductosNecesarios As ListConBorrados(Of NovedadProduccionMRPProducto)
   Public Property ProductosResultantes As ListConBorrados(Of NovedadProduccionMRPProducto)

#End Region
#Region "Propiedades no Pertenecientes a la entidad"
   Public Property ClaseCentroProductor As ClaseCentrosProd
#End Region

End Class
