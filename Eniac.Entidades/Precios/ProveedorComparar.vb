Public Class ProveedorComparar
   Inherits Entidades.Entidad

   Public Const NombreTabla As String = "ProveedoresComparar"

   Public Enum Columnas
      IdProveedor
      IdPlantilla
      FechaActualizacion
   End Enum

#Region "Propiedades"
   Public Property IdProveedor As Long
   Public Property IdPlantilla As Integer
   Public Property FechaActualizacion As Date


   '# Solo para mostrar por pantalla.
   Public Property NombreProveedor As String

#End Region

End Class
