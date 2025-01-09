<Serializable()>
Public Class ZonaGeografica
   Inherits Entidad

   Public Const TableName As String = "ZonaGeografica"
   Public Enum Columnas
      IdZonaGeografica
      NombreZonaGeografica
   End Enum

   Public Property IdZonaGeografica As String
   Public Property NombreZonaGeografica As String

End Class