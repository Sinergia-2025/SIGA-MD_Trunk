Option Strict On
Option Explicit On
Namespace Ayudante
   Public Class Validadores
      Public Property Owner As Form
      Public Sub New(owner As Form)
         Me.Owner = owner
      End Sub
      Public Function ValidaCuit(cuit As String) As Boolean
         Return ValidaCuit(cuit, False, Entidades.Ayudante.Validadores.ValidarExistenciaEn.Ninguno, Nothing, AccionExistente.Cancelar)
      End Function
      Public Function ValidaCuit(cuit As String, validaExistencia As Boolean, donde As Entidades.Ayudante.Validadores.ValidarExistenciaEn,
                                 primaryKeyActual As Object(), accion As AccionExistente) As Boolean
         If cuit.Trim().Length < 11 Then
            ShowMessage(String.Format("El número de CUIT ingresado es inválido, deben ser 11 dígitos numéricos y posee {0}.", cuit.Trim().Length))
            Return False
         End If
         If Not Publicos.EsCuitValido(cuit) Then
            ShowMessage("El número de CUIT ingresado es inválido.")
            Return False
         End If
         If validaExistencia Then
            Dim validarRegla As Boolean = New Reglas.Ayudante.Validadores().ValidaCuit(cuit, donde, primaryKeyActual)
            If Not validarRegla Then
               If accion = AccionExistente.Cancelar Then
                  ShowMessage(String.Format("El número de CUIT ingresado ya fué utilizado para otro {0}.", Publicos.GetEnumString(donde)))
                  Return False
               ElseIf accion = AccionExistente.Preguntar Then
                  If ShowPregunta(String.Format("El número de CUIT ingresado ya fué utilizado para otro {0}. ¿Desea utilizarlo de todas maneras?", Publicos.GetEnumString(donde))) = DialogResult.No Then
                     Return False
                  End If
               ElseIf accion = AccionExistente.Continuar Then
                  ShowMessage(String.Format("El número de CUIT ingresado ya fué utilizado para otro {0}.", Publicos.GetEnumString(donde)))
                  'Si es continuar no debemos hacer nada, directamente lo da como válido (usado en los leave de los campos)
               End If
            End If
         End If
         Return True
      End Function

      Private Function ShowMessage(mensaje As String) As DialogResult
         Return MessageBox.Show(mensaje, Owner.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Function

      Private Function ShowPregunta(mensaje As String) As DialogResult
         Return MessageBox.Show(mensaje, Owner.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question)
      End Function

      Public Enum AccionExistente
         Cancelar
         Preguntar
         Continuar
      End Enum

   End Class
End Namespace