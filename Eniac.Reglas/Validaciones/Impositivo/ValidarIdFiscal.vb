Option Strict On
Option Explicit On
Imports actual = Eniac.Entidades.Usuario.Actual
Namespace Validaciones.Impositivo
   Public Class ValidarIdFiscal
      Private Shared _lockObject As Object = New Object()
      Private Shared _instancia As IValidarIdFiscal
      Public Shared Function Instancia() As IValidarIdFiscal
         If _instancia Is Nothing Then
            SyncLock _lockObject
               If _instancia Is Nothing Then
                  _instancia = NewInstance()
               End If
            End SyncLock
         End If
         Return _instancia
      End Function

      Private Shared Function NewInstance() As IValidarIdFiscal
         Dim result As IValidarIdFiscal
         Select Case actual.CurrentUICulture
            Case "es-AR"
               result = New ValidarIdFiscalEsAR()
            Case "es-PY"
               result = New ValidarIdFiscalEsPY()
            Case Else
               'Si no está definida la cultura, levanto la de Argentina
               result = New ValidarIdFiscalEsAR()
         End Select
         Return result
      End Function

   End Class
End Namespace