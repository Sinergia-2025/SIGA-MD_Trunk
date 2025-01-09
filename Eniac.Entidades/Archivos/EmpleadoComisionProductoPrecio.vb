Public Class EmpleadoComisionProductoPrecio
   Inherits Eniac.Entidades.Entidad
   Public Const NombreTabla As String = "EmpleadoComisionProductoPrecio"

   Public Enum Columnas
      IdEmpleado
      IdProducto
      IdListaPrecios
      Comision
   End Enum


   ' Public Property Empleado() As Empleado
   Public Property IdEmpleado As Integer
   '  Public Property Producto As Producto
   Public Property IdProducto As String
   Public Property NombreProducto As String
   '  Public Property ListaDePrecios() As ListaDePrecios
   Public Property IdListaPrecios As Integer
   Public Property NombreListaPrecios As String
   Public Property Comision As Decimal

End Class