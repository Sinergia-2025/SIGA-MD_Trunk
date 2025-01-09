Public Class RubroComisionPorDescuento
   Inherits Eniac.Entidades.Entidad
   Public Const NombreTabla As String = "RubrosComisionesPorDescuento"
   Public Enum Columnas
      IdRubro
      DescuentoRecargoHasta
      Comision
   End Enum
   Public Property IdRubro As Integer
   Public Property DescuentoRecargoHasta As Decimal
   Public Property Comision As Decimal
End Class
