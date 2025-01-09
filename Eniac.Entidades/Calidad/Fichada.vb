Public Class Fichada
   Inherits Entidad

   Public Const NombreTabla As String = "CalidadFichadas"

   Public Enum Columnas
      IdFichada
      FichadaTarjeta
      FichadaFecha
      FichadaHora
      IdNodo
      IdLegajo

   End Enum

   Public Property IdFichada As Integer
   Public Property FichadaTarjeta As String
   Public Property FichadaFecha As Date
   Public Property FichadaHora As DateTime
   Public Property IdNodo As Integer
   Public Property IdLegajo As Integer

End Class
