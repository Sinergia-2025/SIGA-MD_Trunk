Public Class Chequera
   Inherits Entidad

   Public Const NombreTabla As String = "Chequeras"

   Public Enum Columnas
      IdChequera
      IdCuentaBancaria
      NumeroDesde
      NumeroHasta
      NombreChequera
      NumeroActual
      Descripcion
      Activo
   End Enum

   Public Property IdChequera As Integer
   Public Property IdCuentaBancaria As Integer
   Public Property NumeroDesde As Integer
   Public Property NumeroHasta As Integer
   Public Property NombreChequera As String
   Public Property NumeroActual As Integer
   Public Property Descripcion As String
   Public Property Activo As Boolean

End Class
