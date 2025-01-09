Namespace FilterManager
   Public Class FuncionFiltroSucursal
      Inherits Entidad

      Public Const NombreTabla As String = "FuncionesFiltrosSucursales"

      Public Enum Columnas
         IdFuncion
         IdSucursal
         IdFiltro

      End Enum

      Public Property IdFuncion As String
      Public Property IdFiltro As Integer

   End Class
End Namespace