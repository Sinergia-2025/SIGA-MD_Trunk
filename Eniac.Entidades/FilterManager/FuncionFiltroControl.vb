Namespace FilterManager
   Public Class FuncionFiltroControl
      Inherits Entidad

      Public Const NombreTabla As String = "FuncionesFiltrosControles"

      Public Enum Columnas
         IdFuncion
         IdFiltro
         NombreControl
         ValorControl

      End Enum

      Public Property IdFuncion As String
      Public Property IdFiltro As Integer
      Public Property NombreControl As String
      Public Property ValorControl As String

   End Class
End Namespace