Imports Microsoft.Win32
Imports System.IO

Public Class AbrirTeamViewer
   Implements IComandoMenu

   Public Sub Ejecutar(owner As IWin32Window, idFuncion As String) Implements IComandoMenu.Ejecutar
      For Each regPath As String In {"SOFTWARE\\TeamViewer", "SOFTWARE\\Wow6432Node\\TeamViewer"}
         If Registry.LocalMachine.OpenSubKey(regPath) IsNot Nothing Then
            Dim oInstPath As Object = Registry.LocalMachine.OpenSubKey(regPath).GetValue("InstallationDirectory")
            Dim instPath As String = String.Empty
            If TypeOf (oInstPath) Is String Then instPath = oInstPath.ToString()
            If Not String.IsNullOrWhiteSpace(instPath) Then
               Dim fi As FileInfo = New FileInfo(System.IO.Path.Combine(instPath, "TeamViewer.exe"))
               If fi.Exists Then
                  System.Diagnostics.Process.Start(fi.FullName)
                  Exit For
               End If
            End If
         End If
      Next
   End Sub
End Class
