Public Class ProductosClientes
   Inherits Eniac.Entidades.Entidad
   Public Const NombreTabla As String = "ProductosClientes"
   Public Enum Columnas
      IdProducto
      IdCliente
   End Enum
   Public Property IdProducto As String
   Public Property IdCliente As Long
End Class