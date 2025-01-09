Option Strict On
Option Explicit On
Imports actual = Eniac.Entidades.Usuario.Actual
Namespace Validaciones.Impositivo
   Public Class ValidarDigitoVerificador
      Private Shared _lockObject As Object = New Object()
      Private Shared _instancia As IValidarDigitoVerificador
      Public Shared Function Instancia() As IValidarDigitoVerificador
         If _instancia Is Nothing Then
            SyncLock _lockObject
               If _instancia Is Nothing Then
                  _instancia = NewInstance()
               End If
            End SyncLock
         End If
         Return _instancia
      End Function
      Private Shared Function NewInstance() As IValidarDigitoVerificador
         Dim result As IValidarDigitoVerificador
         Select Case actual.CurrentUICulture
            Case "es-AR"
               result = New ValidarDigitoVerificadorEsAR()
            Case "es-PY"
               result = New ValidarDigitoVerificadorEsPY()
            Case Else
               'Si no está definida la cultura, levanto la de Argentina
               result = New ValidarDigitoVerificadorEsAR()
         End Select
         Return result
      End Function
      Public Shared Sub ResetInstancia()
         SyncLock _lockObject
            _instancia = Nothing
         End SyncLock
      End Sub
   End Class
End Namespace