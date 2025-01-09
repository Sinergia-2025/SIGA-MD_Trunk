<Serializable()>
Public Class Produccion
   Inherits Entidad

   Public Enum Columnas
      IdSucursal
      IdProduccion
      Fecha
      Usuario
      IdEstado
      IdResponsable

   End Enum

   Public Sub New()
      Productos = New List(Of ProduccionProducto)()
      ProductosLotes = New List(Of ProductoLote)()
      IdEstado = String.Empty
   End Sub

   Public Property IdProduccion As Integer
   Public Property Fecha As Date
   Public Property IdEstado As String
   Public Property Responsable As Empleado
   Public Property Productos As List(Of ProduccionProducto)
   Public Property ProductosLotes As List(Of ProductoLote)

End Class