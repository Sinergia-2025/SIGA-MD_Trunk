Public Class ClienteDescuentoMarca
   Inherits Eniac.Entidades.Entidad
   Public Const NombreTabla As String = "ClientesDescuentosMarcas"
   Public Enum Columnas
      IdMarca
      DescuentoRecargoPorc1
      DescuentoRecargoPorc2
      IdCliente

   End Enum

   Public Property IdCliente As Long
   Public Property IdMarca As Integer
   Public Property DescuentoRecargoPorc1 As Decimal
   Public Property DescuentoRecargoPorc2 As Decimal
End Class