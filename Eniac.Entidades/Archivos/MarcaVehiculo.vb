Public Class MarcaVehiculo
    Inherits Eniac.Entidades.Entidad
    Public Const NombreTabla As String = "MarcasVehiculos"
    Public Enum Columnas
      IdMarcaVehiculo
      NombreMarcaVehiculo
   End Enum

    Public Sub New()
    End Sub

   Public Property IdMarcaVehiculo As Integer
   Public Property NombreMarcaVehiculo As String

End Class
