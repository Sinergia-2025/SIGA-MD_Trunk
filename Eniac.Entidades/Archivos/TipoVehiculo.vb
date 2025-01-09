Public Class TipoVehiculo
   Inherits Eniac.Entidades.Entidad
   Public Const NombreTabla As String = "TiposVehiculos"
   Public Enum Columnas
      IdTipoVehiculo
      NombreTipoVehiculo
      CapacidadMaxima
   End Enum

   Public Sub New()
   End Sub

   Public Property IdTipoVehiculo As Integer
   Public Property NombreTipoVehiculo As String
   Public Property CapacidadMaxima As Integer
End Class