Public Class EmpleadoObjetivo
   Inherits Eniac.Entidades.Entidad
   Public Const NombreTabla As String = "EmpleadosObjetivos"

   Public Enum Columnas
      IdEmpleado
      PeriodoFiscal
      ImporteObjetivo

   End Enum
   Public Property IdEmpleado() As Integer
   Public Property PeriodoFiscal() As Integer
   Public Property ImporteObjetivo() As Decimal
End Class
