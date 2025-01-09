Imports System.Runtime.CompilerServices
Namespace Extensiones
   Public Module DateTimePickerExtensions
      <Extension>
      Public Function Valor(dtp As DateTimePicker, chb As CheckBox) As Date?
         Return dtp.Valor(chb.Checked)
      End Function
      <Extension>
      Public Function Valor(dtp As DateTimePicker) As Date?
         Return dtp.Valor(dtp.Checked)
      End Function
      <Extension>
      Public Function Valor(dtp As DateTimePicker, checked As Boolean) As Date?
         Return dtp.Valor(checked, defaultValue:=Nothing)
      End Function
      <Extension>
      Public Function Valor(dtp As DateTimePicker, checked As Boolean, defaultValue As Date?) As Date?
         If checked Then
            Return dtp.Value
         Else
            Return defaultValue
         End If
      End Function
   End Module
End Namespace