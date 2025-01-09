Public Class OrdenProduccionMRPCategoriaEmpleado
   Inherits Entidad

   Public Const NombreTabla As String = "OrdenesProduccionMRPCategoriasEmpleados"

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
      IdCategoriaEmpleado
      CantidadCategoria
      ValorHoraCategoria
   End Enum
#End Region

#Region "New"
   Public Sub New()
      MRPCategoriaEmpleado = New Entidades.MRPProcesoProductivoCategoriaEmpleado()
   End Sub
#End Region

#Region "Propiedades"
   Public Property IdTipoComprobante As String
   Public Property LetraComprobante As String
   Public Property CentroEmisor As Integer
   Public Property NumeroOrdenProduccion As Long
   Public Property Orden As Integer
   Public Property IdProducto As String
   Public Property MRPCategoriaEmpleado As Entidades.MRPProcesoProductivoCategoriaEmpleado
#End Region

#Region "Propiedades no pertenecientes a la Entidad"

#End Region

End Class
