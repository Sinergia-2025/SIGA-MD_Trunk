Imports System.IO

Public Interface IFtp

   Event BytesUploaded(sender As Object, e As BytesUploadedEventArgs)
   Event FileUploadBeginning(sender As Object, e As FileUploadEventArgs)
   Event FileUploadFinished(sender As Object, e As FileUploadEventArgs)

   ''event BytesDownloadedEventHandler BytesDownloaded;

   Sub Upload(fileInf As FileInfo, remotePath As String)
   Sub Upload(fileInf As FileInfo, remotePath As String, useBinary As Boolean)
   Sub Upload(localPath As String, filename As String, remotePath As String)
   Sub Upload(localPath As String, filename As String, remotePath As String, useBinary As Boolean)
   Sub Upload(fileInf As FileInfo, remotePath As String, remoteFilename As String)
   Sub Upload(fileInf As FileInfo, remotePath As String, remoteFilename As String, useBinary As Boolean)

   Sub TestFtpConfiguration(remotePath As String)

   Sub UploadDirectory(localDirectory As String, remotePath As String, useBinary As Boolean, deleteUploadedFile As Boolean)
   Sub UploadDirectory(directoryInfo As DirectoryInfo, remotePath As String, useBinary As Boolean, deleteUploadedFile As Boolean)

   Sub Download(fileInf As FileInfo, remotePath As String)
   Sub Download(fileInf As FileInfo, remotePath As String, useBinary As Boolean)
   Sub Download(localPath As String, filename As String, remotePath As String)
   Sub Download(localPath As String, filename As String, remotePath As String, useBinary As Boolean)
   Sub Download(fileInf As FileInfo, remotePath As String, remoteFilename As String)
   Sub Download(fileInf As FileInfo, remotePath As String, remoteFilename As String, useBinary As Boolean)

   Sub RenameRemote(remotePath As String, oldFilename As String, newFilename As String)

   Sub MakeDirectory(basePath As String, newDirectory As String)
   Sub MakeDirectory(newDirectoryPath As String)

   Function GetFileSize(fileName As String) As Long

   Function FileExists(fileName As String) As Boolean

   Property UsePassive As Boolean

End Interface
Public Class FileUploadEventArgs
   Inherits EventArgs
   Public Property FileName As String
   Public Property Tamanio As Long
   Public Property SubidoExitosamente As Boolean = False
   Public Sub New(fileName As String)
      _FileName = fileName
   End Sub
End Class
Public Class BeginUploadEventArgs
   Inherits EventArgs
   Public Property CantidadArchivos As Long
   Public Property TamanioTotal As Long
End Class