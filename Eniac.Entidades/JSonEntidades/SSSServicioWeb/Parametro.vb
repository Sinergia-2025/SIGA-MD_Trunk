Namespace JSonEntidades.SSSServicioWeb
   Public Class Parametro
      Public Const NombreTabla As String = "Parametros"
      Public Enum Columnas
         IdEmpresa
         IdParametro
         ValorParametro
      End Enum

      Public Sub New()
         IdEmpresa = 1
      End Sub

      Public Property IdEmpresa As Integer
      Public Property IdParametro As String
      Public Property ValorParametro As String

   End Class

End Namespace