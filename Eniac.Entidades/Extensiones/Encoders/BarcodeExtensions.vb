#Region "Imports"
Imports System.Drawing.Imaging
Imports System.Runtime.CompilerServices
#End Region
Namespace Extensiones.Encoders
   Public Module BarcodeExtensions
      <Extension()>
      Public Function ToCode128(toEncode As String) As String
         Return EncodeCode128(toEncode)
      End Function
      '------------------------------------------------------------------------------------------
      Public Function EncodeCode128(toEncode As String) As String
         toEncode = toEncode.Replace(" ", "")
         Dim encoded As StringBuilder = New StringBuilder()

         ''Start code
         encoded.Append(Convert.ToChar(204))
         Dim sum As Integer = 104
         For i As Integer = 0 To toEncode.Length - 1
            sum = sum + (Convert.ToInt32(Convert.ToChar(toEncode(i))) - 32) * (i + 1)
            encoded.Append(toEncode(i))
         Next

         sum = sum Mod 103
         'sum = sum + 32

         ''Checksum between 94 and 103 are encoded in the 200 - 206 range
         If sum < 95 Then
            sum += 32
         Else
            sum += 100
         End If
         'If sum > 94 And sum < 103 Then
         '   sum = sum + 105
         'End If

         ''Checksum
         encoded.Append(Convert.ToChar(sum))
         ''Stop code
         encoded.Append(Convert.ToChar(206))

         Return encoded.ToString()
      End Function
      '------------------------------------------------------------------------------------------

      <Extension()>
      Public Function ToIDAutomationHL25S(toEncode As String) As String
         Return EncodeIDAutomationHL25S(toEncode)
      End Function
      Public Function EncodeIDAutomationHL25S(dataToEncode As String) As String

         'NOTE: I2of5 requires an even number of digits
         'Change the next line to connect to your data source; for example:
         'DataToEncode = ({Table.Field})
         ' DataToEncode = "04441001000331112100199800000000000000000000514001234191"
         Dim I As Integer
         Dim CurrentCharNum As Integer
         Dim StringLength As Integer
         Dim OnlyCorrectData As String
         Dim DataToPrint As String = ""
         dataToEncode = RTrim(LTrim(dataToEncode))
         OnlyCorrectData = ""
         StringLength = Len(dataToEncode)
         For I = 1 To StringLength
            If IsNumeric(Mid(dataToEncode, I, 1)) Then OnlyCorrectData = OnlyCorrectData & Mid(dataToEncode, I, 1)
         Next I
         dataToEncode = OnlyCorrectData
         If (Len(dataToEncode) Mod 2) = 1 Then dataToEncode = dataToEncode & "0"
         StringLength = Len(dataToEncode)
         For I = 1 To StringLength Step 2
            CurrentCharNum = CInt(Val((Mid(dataToEncode, I, 2))))
            If CurrentCharNum < 94 Then DataToPrint = DataToPrint & Chr(CurrentCharNum + 33)
            If CurrentCharNum > 93 Then DataToPrint = DataToPrint & Chr(CurrentCharNum + 103)
         Next I
         Return Chr(203) & DataToPrint & Chr(204) '& " "

      End Function

   End Module

End Namespace