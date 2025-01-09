Public Class EmpleadoSucursal
   Inherits Eniac.Entidades.Entidad

   Public Const NombreTabla As String = "EmpleadosSucursales"
   Public Enum Columnas
      IdSucursal
      IdEmpleado
      IdCaja
      Observacion
   End Enum

   Public Property IdEmpleado As Integer
   Public Property IdCaja As Integer?
   Public Property Observacion As String
End Class