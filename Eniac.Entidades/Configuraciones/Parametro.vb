<Serializable()>
Public Class Parametro
   Inherits Entidad

   Public Const NombreTabla As String = "Parametros"

   Public Enum Columnas
      IdEmpresa
      IdParametro
      ValorParametro
      CategoriaParametro
      DescripcionParametro
      UbicacionParametro

   End Enum

#Region "Propiedades"

   Public Property IdEmpresa As Integer
   Public Property IdParametro As String
   Public Property DescripcionParametro As String
   Public Property ValorParametro As String
   Public Property CategoriaParametro As String
   Public Property UbicacionParametro As String

#End Region

End Class