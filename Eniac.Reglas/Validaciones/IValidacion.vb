Option Strict On
Option Explicit On
Namespace Validaciones
   Public Interface IValidacion(Of T)
      Function Validar(datos As T) As ValidacionResult
   End Interface
   Public Class ValidacionResult
      Public Property [Error] As Boolean = False
      Public Property MensajeError As String
   End Class
End Namespace