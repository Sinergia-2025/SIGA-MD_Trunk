Public Class VehiculoCliente
   Inherits Entidad
   Public Const NombreTabla As String = "VehiculosClientes"
   Public Enum Columnas
      PatenteVehiculo
      IdCliente

   End Enum

   Public Sub New()
   End Sub

   Public Property PatenteVehiculo As String
   Public Property IdCliente As Long

   Public Property CodigoCliente As Long        ' Solo para mostrar en pantalla, no se persiste
   Public Property TipoDocCliente As String     ' Solo para mostrar en pantalla, no se persiste
   Public Property NroDocCliente As Long        ' Solo para mostrar en pantalla, no se persiste
   Public Property NombreCliente As String      ' Solo para mostrar en pantalla, no se persiste

End Class