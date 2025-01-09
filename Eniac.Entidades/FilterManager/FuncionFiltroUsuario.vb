Namespace FilterManager
   Public Class FuncionFiltroUsuario
      Inherits Entidad

      Public Const NombreTabla As String = "FuncionesFiltrosUsuarios"

      Public Enum Columnas
         IdFuncion
         IdUsuario
         IdSucursal
         IdFiltro

      End Enum

      Public Property IdFuncion As String
      Public Property IdFiltro As Integer

   End Class
End Namespace