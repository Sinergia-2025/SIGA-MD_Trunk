Public Class AplicacionFuncion
   Inherits Entidad
   Public Const NombreTabla As String = "AplicacionesFunciones"

   Public Enum Columnas
      IdAplicacion
      IdFuncion
      NombreFuncion
      IdFuncionPadre

   End Enum


   Public Property IdAplicacion As String
   Public Property IdFuncion As String
   Public Property NombreFuncion As String
   Public Property IdFuncionPadre As String


End Class