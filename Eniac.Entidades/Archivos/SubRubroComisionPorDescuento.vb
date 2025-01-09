Public Class SubRubroComisionPorDescuento
   Inherits Eniac.Entidades.Entidad
   Public Const NombreTabla As String = "SubRubrosComisionesPorDescuento"
   Public Enum Columnas
      IdSubRubro
      DescuentoRecargoHasta
      Comision
   End Enum
   Public Property IdSubRubro As Integer
   Public Property DescuentoRecargoHasta As Decimal
   Public Property Comision As Decimal
End Class
