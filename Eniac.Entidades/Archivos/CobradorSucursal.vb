Public Class CobradorSucursal
   Inherits Eniac.Entidades.Entidad

   Public Const NombreTabla As String = "CobradoresSucursales"
   Public Enum Columnas
      IdSucursal
      IdCobrador
      IdCaja
      Observacion
   End Enum

   Public Property IdCobrador As Integer
   Public Property IdCaja As Integer?
   Public Property Observacion As String
End Class