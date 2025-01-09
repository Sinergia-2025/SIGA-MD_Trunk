Public Class CalendarioSucursal
   Inherits Eniac.Entidades.Entidad

   Public Const NombreTabla As String = "CalendariosSucursales"

   Public Enum Columnas
      IdCalendario
      IdSucursal
      IdCaja
   End Enum

   Public Sub New()
      IdSucursal = actual.Sucursal.IdSucursal
   End Sub

   Public Property IdCalendario As Integer
   Public Property IdCaja As Integer
End Class
