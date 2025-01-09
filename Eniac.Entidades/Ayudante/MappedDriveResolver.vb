Imports System.Management
Namespace Ayudante
   ''' <summary>
   ''' A static class to help with resolving a mapped drive path to a UNC network path.
   ''' If a local drive path or a UNC network path are passed in, they will just be returned.
   ''' </summary>
   ''' <example>
   ''' using System;
   ''' using System.IO;
   ''' using System.Management;    // Reference System.Management.dll
   ''' 
   ''' // Example/Test paths, these will need to be adjusted to match your environment. 
   ''' string[] paths = new string[] {
   '''     @"Z:\ShareName\Sub-Folder",
   '''     @"\\ACME-FILE\ShareName\Sub-Folder",
   '''     @"\\ACME.COM\ShareName\Sub-Folder", // DFS
   '''     @"C:\Temp",
   '''     @"\\localhost\c$\temp",
   '''     @"\\workstation\Temp",
   '''     @"Z:", // Mapped drive pointing to \\workstation\Temp
   '''     @"C:\",
   '''     @"Temp",
   '''     @".\Temp",
   '''     @"..\Temp",
   '''     "",
   '''     "    ",
   '''     null
   ''' };
   ''' 
   ''' foreach (var curPath in paths) {
   '''     try {
   '''         Console.WriteLine(string.Format("{0} = {1}",
   '''             curPath,
   '''             MappedDriveResolver.ResolveToUNC(curPath))
   '''         );
   '''     }
   '''     catch (Exception ex) {
   '''         Console.WriteLine(string.Format("{0} = {1}",
   '''             curPath,
   '''             ex.Message)
   '''         );
   '''     }
   ''' }
   ''' </example>
   Public Class MappedDriveResolver

#Region "Singleton"
      Private Shared _instancia As MappedDriveResolver
      Private Shared _lockObject As Object = New Object()
      Public Shared ReadOnly Property Instancia As MappedDriveResolver
         Get
            If _instancia Is Nothing Then
               SyncLock _lockObject
                  If _instancia Is Nothing Then
                     _instancia = New MappedDriveResolver()
                  End If
               End SyncLock
            End If
            Return _instancia
         End Get
      End Property
      Private Sub New()
      End Sub
#End Region

      ''' <summary>
      ''' Resolves the given path to a full UNC path if the path is a mapped drive.
      ''' Otherwise, just returns the given path.
      ''' </summary>
      ''' <param name="path">The path to resolve.</param>
      ''' <returns></returns>
      Public Function ResolveToUNC(path As String) As String
         If String.IsNullOrWhiteSpace(path) Then
            Throw New ArgumentNullException("The path argument was null or whitespace.")
         End If

         If (Not IO.Path.IsPathRooted(path)) Then
            Throw New ArgumentException(String.Format("The path '{0}' was not a rooted path and ResolveToUNC does not support relative paths.", path))
         End If

         '' Is the path already in the UNC format?
         If path.StartsWith("\\") Then
            Return path
         End If

         Dim rootPath As String = ResolveToRootUNC(path)

         If (path.StartsWith(rootPath)) Then
            Return path '' Local drive, no resolving occurred
         Else
            Return path.Replace(GetDriveLetter(path), rootPath)
         End If
      End Function


      ''' <summary>
      ''' Resolves the given path to a root UNC path if the path is a mapped drive.
      ''' Otherwise, just returns the given path.
      ''' </summary>
      ''' <param name="path">The path to resolve.</param>
      ''' <returns></returns>
      Private Function ResolveToRootUNC(path As String) As String
         If (String.IsNullOrWhiteSpace(path)) Then
            Throw New ArgumentNullException("The path argument was null or whitespace.")
         End If

         If (Not IO.Path.IsPathRooted(path)) Then
            Throw New ArgumentException(String.Format("The path '{0}' was not a rooted path and ResolveToRootUNC does not support relative paths.", path))
         End If

         If (path.StartsWith("\\")) Then
            Return IO.Directory.GetDirectoryRoot(path)
         End If


         '' Get just the drive letter for WMI call
         Dim driveletter As String = GetDriveLetter(path)

         '' Query WMI if the drive letter is a network drive, and if so the UNC path for it
         Using mo As ManagementObject = New ManagementObject()
            mo.Path = New ManagementPath(String.Format("Win32_LogicalDisk='{0}'", driveletter))

            Dim driveType As IO.DriveType = CType(DirectCast(mo("DriveType"), UInteger), IO.DriveType)
            Dim networkRoot As String = Convert.ToString(mo("ProviderName"))

            If driveType = IO.DriveType.Network Then
               Return networkRoot
            Else
               Return driveletter + IO.Path.DirectorySeparatorChar
            End If
         End Using
      End Function

      ''' <summary>
      ''' Checks if the given path is a network drive.
      ''' </summary>
      ''' <param name="path">The path to check.</param>
      ''' <returns></returns>
      Private Function IsNetworkDrive(path As String) As Boolean
         If (String.IsNullOrWhiteSpace(path)) Then
            Throw New ArgumentNullException("The path argument was null or whitespace.")
         End If

         If (Not IO.Path.IsPathRooted(path)) Then
            Throw New ArgumentException(String.Format("The path '{0}' was not a rooted path and ResolveToRootUNC does not support relative paths.", path))
         End If

         If (path.StartsWith("\\")) Then
            Return True
         End If

         '' Get just the drive letter for WMI call
         Dim driveletter As String = GetDriveLetter(path)

         '' Query WMI if the drive letter is a network drive
         Using mo As ManagementObject = New ManagementObject()
            mo.Path = New ManagementPath(String.Format("Win32_LogicalDisk='{0}'", driveletter))
            Dim driveType As IO.DriveType = CType(DirectCast(mo("DriveType"), UInteger), IO.DriveType)
            Return driveType = IO.DriveType.Network
         End Using

      End Function

      ''' <summary>
      ''' Given a path will extract just the drive letter with volume separator.
      ''' </summary>
      ''' <param name="path"></param>
      ''' <returns>C:</returns>
      Private Function GetDriveLetter(path As String) As String
         If (String.IsNullOrWhiteSpace(path)) Then
            Throw New ArgumentNullException("The path argument was null or whitespace.")
         End If

         If (Not IO.Path.IsPathRooted(path)) Then
            Throw New ArgumentException(String.Format("The path '{0}' was not a rooted path and GetDriveLetter does not support relative paths.", path))
         End If

         If (path.StartsWith("\\")) Then
            Throw New ArgumentException("A UNC path was passed to GetDriveLetter")
         End If

         Return IO.Directory.GetDirectoryRoot(path).Replace(IO.Path.DirectorySeparatorChar.ToString(), "")

      End Function

   End Class
End Namespace