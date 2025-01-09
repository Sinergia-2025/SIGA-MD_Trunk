Public Class ClienteDescuentoSubRubro
   Inherits Entidad
   Public Const NombreTabla As String = "ClientesDescuentosSubRubros"
   Public Enum Columnas
      IdSubRubro
      DescuentoRecargo
      IdCliente
   End Enum
   Public Property IdCliente As Long
   Public Property IdSubRubro As Integer
   Public Property DescuentoRecargo As Decimal
End Class