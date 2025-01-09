Public Class MRPCategoriaEmpleado
   Inherits Entidad

   Public Const NombreTabla As String = "MRPCategoriasEmpleados"

   Public Enum Columnas
      IdCategoriaEmpleado
      CodigoCategoriaEmpleado
      Descripcion
      ValorHoraProduccion
      Activo
   End Enum

   Public Property IdCategoriaEmpleado As Integer
   Public Property CodigoCategoriaEmpleado As String
   Public Property Descripcion As String
   Public Property ValorHoraProduccion As Decimal
   Public Property Activo As Boolean

   Public Sub New()
      IdCategoriaEmpleado = 0
      CodigoCategoriaEmpleado = String.Empty
      Descripcion = String.Empty
      ValorHoraProduccion = 0
      Activo = True
   End Sub
End Class
