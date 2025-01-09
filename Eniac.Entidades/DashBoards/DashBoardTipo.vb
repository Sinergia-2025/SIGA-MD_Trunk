Public Class DashBoardTipo
   Inherits Entidad

   Public Const NombreTabla As String = "DashBoardsTipos"
   Public Enum Columnas
      IdDashTipos
      Descripcion
      NombreObjeto
      Estados
      LocationX
      LocationY
   End Enum

   Public Property IdDashTipos As Integer
   Public Property Descripcion As String
   Public Property NombreObjeto As String
   Public Property Estados As Boolean
   Public Property LocationX As Integer?
   Public Property LocationY As Integer?

End Class
