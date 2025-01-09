Public Class ConcesionarioOperacionCheque
   Inherits Entidad

   Public Const NombreTabla As String = "ConcesionarioOperacionesCheques"
   Public Enum Columnas
      IdMarca
      AnioOperacion
      NumeroOperacion
      SecuenciaOperacion
      IdCheque

   End Enum

   Public Property IdMarca As Integer
   Public Property AnioOperacion As Integer
   Public Property NumeroOperacion As Integer
   Public Property SecuenciaOperacion As Integer

   Public Property IdCheque As Long
End Class