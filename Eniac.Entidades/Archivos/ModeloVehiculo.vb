Public Class ModeloVehiculo
    Inherits Eniac.Entidades.Entidad
    Public Const NombreTabla As String = "ModelosVehiculos"
    Public Enum Columnas
        IdModeloVehiculo
        NombreModeloVehiculo
        IdMarcaVehiculo
    End Enum

    Public Sub New()
    End Sub


    Public Property IdModeloVehiculo As Integer
    Public Property NombreModeloVehiculo As String
    Public Property IdMarcaVehiculo As Integer

End Class