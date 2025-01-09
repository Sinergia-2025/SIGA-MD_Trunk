Namespace SistemaE
   Public Class AlertaSistemaPermiso
      Inherits Entidad

      Public Const NombreTabla As String = "AlertasSistemaPermisos"
      Public Enum Columnas
         IdAlertaSistema
         IdFuncion

      End Enum

      Public Property IdAlertaSistema As Integer
      Public Property IdFuncion As String


      Public Property NombreFuncion As String               ' Solo para mostrar en pantalla
      Public Property IdFuncionPadre As String              ' Solo para mostrar en pantalla
      Public Property NombreFuncionPadre As String          ' Solo para mostrar en pantalla
      Public Property Posicion As Integer                   ' Solo para mostrar en pantalla
      Public Property Archivo As String                     ' Solo para mostrar en pantalla
      Public Property Pantalla As String                    ' Solo para mostrar en pantalla

   End Class

End Namespace