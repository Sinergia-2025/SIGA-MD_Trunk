<TestClass()> Public Class NetFrameworkTests
   Private Const subkey As String = "SOFTWARE\Microsoft\NET Framework Setup\NDP\v4\Full\"
   <TestMethod()> Public Sub CheckNetFrameworkInstalled()
      Using ndpKey = Microsoft.Win32.RegistryKey.OpenBaseKey(Microsoft.Win32.RegistryHive.LocalMachine, Microsoft.Win32.RegistryView.Registry32).OpenSubKey(subkey)
         If ndpKey IsNot Nothing AndAlso ndpKey.GetValue("Release") IsNot Nothing Then
            Dim value = ndpKey.GetValue("Release")
            Dim version = CheckFor45PlusVersion(Convert.ToInt32(ndpKey.GetValue("Release")))
            Console.WriteLine(String.Format(".NET Framework Version: {0}", version))
         Else
            Console.WriteLine(".NET Framework Version 4.5 or later is not detected.")
         End If
      End Using
   End Sub

   '' Checking the version using >= enables forward compatibility.
   Private Shared Function CheckFor45PlusVersion(releaseKey As Integer) As String
      If (releaseKey >= 528040) Then Return "4.8 or later"
      If (releaseKey >= 461808) Then Return "4.7.2"
      If (releaseKey >= 461308) Then Return "4.7.1"
      If (releaseKey >= 460798) Then Return "4.7"
      If (releaseKey >= 394802) Then Return "4.6.2"
      If (releaseKey >= 394254) Then Return "4.6.1"
      If (releaseKey >= 393295) Then Return "4.6"
      If (releaseKey >= 379893) Then Return "4.5.2"
      If (releaseKey >= 378675) Then Return "4.5.1"
      If (releaseKey >= 378389) Then Return "4.5"
      '' This code should never execute. A non-null release key should mean
      '' that 4.5 Or later Is installed.
      Return "No 4.5 or later version detected"
   End Function

End Class
