Public Class MedioDePago
   Inherits Entidad

   Public Const NombreTabla As String = "MediodePago"

   Public Enum Columnas
      IdMedioDePago
      NombreMedioDePago
      IdCuenta

   End Enum

   Public Enum Ids As Integer
      Pesos = 1
      Dolares = 2
      Cheques = 3
      Tarjetas = 4
      Tickets = 5
      Transferencias = 6
   End Enum

   Public Property IdMedioDePago As Integer
   Public Property NombreMedioDePago As String
   Public Property IdCuenta As Long
   Public Property CuentaContable As ContabilidadCuenta
End Class