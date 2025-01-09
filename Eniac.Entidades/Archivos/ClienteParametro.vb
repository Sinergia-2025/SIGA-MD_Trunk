Public Class ClienteParametro
   Inherits Eniac.Entidades.Entidad
   Public Const NombreTabla As String = "ClientesParametros"
   Public Enum Columnas
      IdCliente
      NombreServidor
      BaseDatos
      IdEmpresa
      IdParametro
      ValorParametro

   End Enum

   Public Property IdCliente As Long
   Public Property NombreServidor As String
   Public Property BaseDatos As String
   Public Property IdEmpresa As Integer
   Public Property IdParametro As String
   Public Property ValorParametro As String

End Class