Public Class ConcesionarioOperacionVehiculoPago
   Inherits Entidad

   Public Const NombreTabla As String = "ConcesionarioOperacionesVehiculosPagos"
   Public Enum Columnas
      IdMarca
      AnioOperacion
      NumeroOperacion
      SecuenciaOperacion
      PatenteVehiculo

   End Enum
   Public Sub New()
   End Sub

   Public Sub New(idMarca As Integer, anioOperacion As Integer, numeroOperacion As Integer, secuenciaOperacion As Integer, patenteVehiculo As String)
      Me.IdMarca = idMarca
      Me.AnioOperacion = anioOperacion
      Me.NumeroOperacion = numeroOperacion
      Me.SecuenciaOperacion = secuenciaOperacion
      Me.PatenteVehiculo = patenteVehiculo
   End Sub

   Public Property IdMarca As Integer
   Public Property AnioOperacion As Integer
   Public Property NumeroOperacion As Integer
   Public Property SecuenciaOperacion As Integer

   Public Property PatenteVehiculo As String
End Class