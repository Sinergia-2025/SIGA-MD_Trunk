Imports System.ComponentModel
Imports Microsoft.Win32
Public Module CheckNetFrameworkVersion

   Public Enum NetFramworkVersion
      <Description("No 4.5 or later version detected")> NA = 0
      <Description("4.5")> Net4_5 = 378389
      <Description("4.5.1")> Net4_5_1 = 378675
      <Description("4.5.2")> Net4_5_2 = 379893
      <Description("4.6")> Net4_6 = 393295
      <Description("4.6.1")> Net4_6_1 = 394254
      <Description("4.6.2")> Net4_6_2 = 394802
      <Description("4.7")> Net4_7 = 460798
      <Description("4.7.1")> Net4_7_1 = 461308
      <Description("4.7.2")> Net4_7_2 = 461808
      <Description("4.8")> Net4_8 = 528040
      <Description("4.8.1")> Net4_8_1 = 533325
   End Enum

   Private Const subkeyVersionNetFramework As String = "SOFTWARE\Microsoft\NET Framework Setup\NDP\v4\Full\"
   Private Const releaseKey As String = "Release"

   Public Function CheckNetFrameworkInstalled() As NetFramworkVersion
      Using ndpKey = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry32).OpenSubKey(subkeyVersionNetFramework)
         Return CheckFor45PlusVersion(ndpKey)
      End Using
   End Function

   Private Function CheckFor45PlusVersion(ndpKey As RegistryKey) As NetFramworkVersion
      If ndpKey IsNot Nothing AndAlso ndpKey.GetValue(releaseKey) IsNot Nothing Then
         Return CheckFor45PlusVersion(Convert.ToInt32(ndpKey.GetValue(releaseKey)))
      End If
      Return NetFramworkVersion.NA
   End Function

   '' Checking the version using >= enables forward compatibility.
   Private Function CheckFor45PlusVersion(releaseKey As Integer) As NetFramworkVersion
      'Dim result = New NetFramworkVersion(releaseKey)
      If (releaseKey >= NetFramworkVersion.Net4_8_1) Then Return NetFramworkVersion.Net4_8_1
      If (releaseKey >= NetFramworkVersion.Net4_8) Then Return NetFramworkVersion.Net4_8
      If (releaseKey >= NetFramworkVersion.Net4_7_2) Then Return NetFramworkVersion.Net4_7_2
      If (releaseKey >= NetFramworkVersion.Net4_7_1) Then Return NetFramworkVersion.Net4_7_1
      If (releaseKey >= NetFramworkVersion.Net4_7) Then Return NetFramworkVersion.Net4_7
      If (releaseKey >= NetFramworkVersion.Net4_6_2) Then Return NetFramworkVersion.Net4_6_2
      If (releaseKey >= NetFramworkVersion.Net4_6_1) Then Return NetFramworkVersion.Net4_6_1
      If (releaseKey >= NetFramworkVersion.Net4_6) Then Return NetFramworkVersion.Net4_6
      If (releaseKey >= NetFramworkVersion.Net4_5_2) Then Return NetFramworkVersion.Net4_5_2
      If (releaseKey >= NetFramworkVersion.Net4_5_1) Then Return NetFramworkVersion.Net4_5_1
      If (releaseKey >= NetFramworkVersion.Net4_5) Then Return NetFramworkVersion.Net4_5
      ' This code should never execute. A non-null release key should mean that 4.5 Or later Is installed.
      Return NetFramworkVersion.NA
   End Function

End Module