Namespace JSonEntidades.Turismo
   Public Class TiposVehiculos
      Inherits JSonEntidad
      Public Sub New(idEmpresa As Integer)
         MyBase.New(idEmpresa)
      End Sub

      Public Property IdTipoVehiculo As Integer
      Public Property NombreTipoVehiculo As String
      Public Property CapacidadMaxima As Integer

   End Class
End Namespace