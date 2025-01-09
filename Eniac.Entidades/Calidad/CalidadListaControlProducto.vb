Public Class CalidadListaControlProducto
   Inherits Eniac.Entidades.Entidad

   Public Const NombreTabla As String = "CalidadListasControlProductos"

   Public Enum Columnas
      IdProducto
      IdListaControl
      FechaActualizacion
      IdUsuario
   End Enum


   Public Property IdProducto As String
   Public Property IdListaControl As Integer
   Public Property FechaActualizacion As DateTime
   Public Property IdUsuario As String

#Region "Propiedades no perteneciente a la Tabla"
   Public Property NombreListaControl As String
#End Region
End Class