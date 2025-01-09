Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports System.IO
Imports System.Net
Imports System.Diagnostics

Public Class SimpleFtp
   Implements IFtp
   Private _ftpServerIP As String
   Private _ftpUserID As String
   Private _ftpPassword As String
   Private _defaultUseBinaryValue As Boolean


   Public Sub New()
      'Trace.WriteLineIf(FTPSwitch.Switch.TraceVerbose, "Initializing SimpleFtp.")
      _defaultUseBinaryValue = True
   End Sub
   Public Sub New(ftpServerIP As String, ftpUserID As String, ftpPassword As String)
      Me.New()
      'Trace.WriteLineIf(FTPSwitch.Switch.TraceVerbose, String.Format("ftpServerIP = {0}", ftpServerIP))
      'Trace.WriteLineIf(FTPSwitch.Switch.TraceVerbose, String.Format("ftpUserID = {0}", ftpUserID))
      'Trace.WriteLineIf(FTPSwitch.Switch.TraceVerbose, String.Format("ftpPassword = {0}", ftpPassword))

      _ftpServerIP = ftpServerIP
      _ftpUserID = ftpUserID
      _ftpPassword = ftpPassword
   End Sub

#Region "IFtp Members"
   Public Event BytesUploaded(sender As Object, e As BytesUploadedEventArgs) Implements IFtp.BytesUploaded

   Public Event FileUploadBeginning(sender As Object, e As FileUploadEventArgs) Implements IFtp.FileUploadBeginning

   Public Event FileUploadFinished(sender As Object, e As FileUploadEventArgs) Implements IFtp.FileUploadFinished

   'public event BytesDownloadedEventHandler BytesDownloaded;

#Region "Upload Members"
   Public Sub Upload(localPath As String, filename As String, remotePath As String) Implements IFtp.Upload
      Upload(localPath, filename, remotePath, _defaultUseBinaryValue)
   End Sub

   Public Sub Upload(localPath As String, filename As String, remotePath As String, useBinary As Boolean) Implements IFtp.Upload

      Upload(New FileInfo(String.Format("{0}{1}{2}", localPath.Trim(Path.DirectorySeparatorChar), Path.DirectorySeparatorChar, filename)),
             remotePath,
             useBinary)
   End Sub

   Public Sub Upload(fileInf As FileInfo, remotePath As String) Implements IFtp.Upload
      Upload(fileInf, remotePath, _defaultUseBinaryValue)
   End Sub

   Public Sub Upload(fileInf As FileInfo, remotePath As String, useBinary As Boolean) Implements IFtp.Upload
      Upload(fileInf, remotePath, fileInf.Name, useBinary)
   End Sub

   Public Sub Upload(fileInf As FileInfo, remotePath As String, remoteFilename As String) Implements IFtp.Upload
      Upload(fileInf, remotePath, remoteFilename, _defaultUseBinaryValue)
   End Sub

   Public Sub TestFtpConfiguration(remotePath As String) Implements IFtp.TestFtpConfiguration
      Dim fileInfo As FileInfo = New FileInfo(Path.GetTempFileName())
      Upload(fileInfo, remotePath, "prueba.subida")
   End Sub

   Private _usePassive As Boolean
   Public Property UsePassive As Boolean Implements IFtp.UsePassive
      Get
         Return Me._usePassive
      End Get
      Set(value As Boolean)
         Me._usePassive = value
      End Set
   End Property

   Public Sub Upload(fileInf As FileInfo, remotePath As String, remoteFilename As String, useBinary As Boolean) Implements IFtp.Upload

      ''Generic.Logging.TraceHelper.WriteDobleSeparator("Upload starts.", FTPSwitch.Switch.TraceInfo)

      'Trace.WriteLineIf(FTPSwitch.Switch.TraceVerbose, String.Format("fileInf.FullName = {0}", fileInf.FullName))
      'Trace.WriteLineIf(FTPSwitch.Switch.TraceVerbose, String.Format("remotePath = {0}", remotePath))
      'Trace.WriteLineIf(FTPSwitch.Switch.TraceVerbose, String.Format("remoteFilename = {0}", remoteFilename))
      'Trace.WriteLineIf(FTPSwitch.Switch.TraceVerbose, String.Format("useBinary = {0}", useBinary))


      If (Not String.IsNullOrEmpty(remotePath)) Then remotePath += "/"
      remotePath = remotePath.Trim("/"c)

      Dim uriString As String = String.Format("ftp://{0}/{1}/{2}", _ftpServerIP, remotePath, remoteFilename)
      'Trace.WriteLineIf(FTPSwitch.Switch.TraceInfo, String.Format("UriString = {0}", uriString))
      Try

         Dim reqFTP As FtpWebRequest

         '' Create FtpWebRequest object from the Uri provided
         'Trace.WriteLineIf(FTPSwitch.Switch.TraceVerbose, "FtpWebRequest.Create")

         reqFTP = DirectCast(FtpWebRequest.Create(New Uri(uriString)), FtpWebRequest)

         '' Provide the WebPermission Credentials
         reqFTP.Credentials = New NetworkCredential(_ftpUserID, _ftpPassword)

         '' By default KeepAlive is true, where the control connection is not closed
         '' after a command is executed.
         reqFTP.KeepAlive = False

         '' Specify the command to be executed.
         reqFTP.Method = WebRequestMethods.Ftp.UploadFile

         '' Specify the data transfer type.
         reqFTP.UseBinary = useBinary

         '' Notify the server about the size of the uploaded file
         reqFTP.ContentLength = fileInf.Length

         reqFTP.UsePassive = Me.UsePassive

         '' The buffer size is set to 2kb
         Dim buffLength As Integer = 2048
         Dim buff(buffLength) As Byte
         Dim contentLen As Integer
         Dim writeLoop As Integer

         '' Opens a file stream (System.IO.FileStream) to read the file to be uploaded
         ''Trace.WriteLineIf(FTPSwitch.Switch.TraceVerbose, "FileStream opens.")
         Using fs As FileStream = fileInf.OpenRead()

            '' Stream to which the file to be upload is written
            ''Trace.WriteLineIf(FTPSwitch.Switch.TraceVerbose, "Ftp Stream opens.")
            Using strm As Stream = reqFTP.GetRequestStream()
               '' Read from the file stream 2kb at a time
               contentLen = fs.Read(buff, 0, buffLength)
               '' Till Stream content ends
               writeLoop = 0
               While (contentLen <> 0)

                  '' Write Content from the file stream to the FTP Upload Stream
                  strm.Write(buff, 0, contentLen)
                  writeLoop += 1
                  RaiseEvent BytesUploaded(Me, New BytesUploadedEventArgs(remoteFilename, reqFTP.RequestUri, buffLength * writeLoop, buffLength, fileInf.Length))
                  ''if (BytesUploaded != null) then BytesUploaded.Invoke(this, new BytesUploadedEventArgs(buffLength * writeLoop, buffLength, fileInf.Length))
                  contentLen = fs.Read(buff, 0, buffLength)
               End While
               '' Close the file stream and the Request Stream
               ''Trace.WriteLineIf(FTPSwitch.Switch.TraceVerbose, "Ftp Stream Closes.")
               strm.Close()
            End Using
            ''Trace.WriteLineIf(FTPSwitch.Switch.TraceVerbose, "FileStream Closes.")
            fs.Close()
         End Using
      Catch ex As Exception
         ''Generic.Logging.TraceHelper.WriteLine(ex, FTPSwitch.Switch)
         Throw New Exception(String.Format("Error subiendo el archivo {1}{0}Archivo remoto {2}{0}{0}{3}", Environment.NewLine, fileInf.Name, uriString, ex.Message), ex)
         'MessageBox.Show(ex.Message, "Upload Error");
      End Try

      ''Generic.Logging.TraceHelper.WriteDobleSeparator("Upload ends.", FTPSwitch.Switch.TraceInfo);
   End Sub
#End Region

#Region "UploadDirectory Members"

   Public Sub UploadDirectory(localDirectory As String, remotePath As String, useBinary As Boolean, deleteUploadedFile As Boolean) Implements IFtp.UploadDirectory
      UploadDirectory(New DirectoryInfo(localDirectory), remotePath, useBinary, deleteUploadedFile)
   End Sub

   Public Sub UploadDirectory(directoryInfo As DirectoryInfo, remotePath As String, useBinary As Boolean, deleteUploadedFile As Boolean) Implements IFtp.UploadDirectory
      If directoryInfo.Exists Then
         For Each localFile As FileInfo In directoryInfo.GetFiles()
            RaiseEvent FileUploadBeginning(Me, New FileUploadEventArgs(localFile.Name))
            Upload(localFile.DirectoryName, localFile.Name, remotePath, useBinary)
            If deleteUploadedFile Then
               IO.File.Delete(localFile.FullName)
            End If
            RaiseEvent FileUploadFinished(Me, New FileUploadEventArgs(localFile.Name))
         Next
      End If
   End Sub

#End Region

#Region "Download Members"
   Public Sub Download(localPath As String, filename As String, remotePath As String) Implements IFtp.Download
      Download(localPath, filename, remotePath, _defaultUseBinaryValue)
   End Sub

   Public Sub Download(localPath As String, filename As String, remotePath As String, useBinary As Boolean) Implements IFtp.Download
      Download(New FileInfo(String.Format("{0}{1}{2}", localPath.Trim(Path.DirectorySeparatorChar), Path.DirectorySeparatorChar, filename)),
               remotePath,
               useBinary)
   End Sub

   Public Sub Download(fileInf As FileInfo, remotePath As String) Implements IFtp.Download
      Download(fileInf, remotePath, _defaultUseBinaryValue)
   End Sub

   Public Sub Download(fileInf As FileInfo, remotePath As String, useBinary As Boolean) Implements IFtp.Download
      Download(fileInf, remotePath, fileInf.Name, useBinary)
   End Sub

   Public Sub Download(fileInf As FileInfo, remotePath As String, remoteFilename As String) Implements IFtp.Download
      Download(fileInf, remotePath, remoteFilename, True)
   End Sub

   Public Sub Download(fileInf As FileInfo, remotePath As String, remoteFilename As String, useBinary As Boolean) Implements IFtp.Download

      'Generic.Logging.TraceHelper.WriteDobleSeparator("Download starts.", FTPSwitch.Switch.TraceInfo)

      'Trace.WriteLineIf(FTPSwitch.Switch.TraceVerbose, String.Format("fileInf.FullName = {0}", fileInf.FullName))
      'Trace.WriteLineIf(FTPSwitch.Switch.TraceVerbose, String.Format("remotePath = {0}", remotePath))
      'Trace.WriteLineIf(FTPSwitch.Switch.TraceVerbose, String.Format("remoteFilename = {0}", remoteFilename))
      'Trace.WriteLineIf(FTPSwitch.Switch.TraceVerbose, String.Format("useBinary = {0}", useBinary))
      Try

         Dim reqFTP As FtpWebRequest
         ''filePath = <<The full path where the file is to be created.>>, 
         ''fileName = <<Name of the file to be created(Need not be the name of the file on FTP server).>>
         'Trace.WriteLineIf(FTPSwitch.Switch.TraceVerbose, "FileStream opens.");
         Using outputStream As FileStream = New FileStream(fileInf.FullName, FileMode.Create)

            If (Not String.IsNullOrEmpty(remotePath)) Then remotePath = String.Format("{0}/", remotePath.Trim("/"c))

            Dim uriString As String = String.Format("ftp:''{0}/{1}{2}", _ftpServerIP, remotePath, remoteFilename)
            'Trace.WriteLineIf(FTPSwitch.Switch.TraceInfo, string.Format("UriString = {0}", uriString));

            reqFTP = DirectCast(FtpWebRequest.Create(New Uri(uriString)), FtpWebRequest)
            reqFTP.Method = WebRequestMethods.Ftp.DownloadFile
            reqFTP.UseBinary = useBinary
            reqFTP.Credentials = New NetworkCredential(_ftpUserID, _ftpPassword)
            'Trace.WriteLineIf(FTPSwitch.Switch.TraceVerbose, "Ftp Stream opens.")
            Using response As FtpWebResponse = DirectCast(reqFTP.GetResponse(), FtpWebResponse)

               Using ftpStream As Stream = response.GetResponseStream()

                  Dim cl As Long = response.ContentLength
                  Dim readLoop As Integer = 0
                  Dim bufferSize As Integer = 2048
                  Dim readCount As Integer
                  Dim buffer(bufferSize) As Byte
                  readCount = ftpStream.Read(buffer, 0, bufferSize)
                  While (readCount > 0)

                     readLoop += 1
                     outputStream.Write(buffer, 0, readCount)
                     'if (BytesDownloaded != null) then BytesDownloaded.Invoke(this, new BytesDownloadedEventArgs(bufferSize * readLoop, readLoop, fileInf.Length))
                     readCount = ftpStream.Read(buffer, 0, bufferSize)
                  End While
                  ftpStream.Close()
               End Using
               'Trace.WriteLineIf(FTPSwitch.Switch.TraceVerbose, "Ftp Stream closes.");
               response.Close()
            End Using
            'Trace.WriteLineIf(FTPSwitch.Switch.TraceVerbose, "FileStream closes.");
            outputStream.Close()
         End Using
      Catch
         ''Generic.Logging.TraceHelper.WriteLine(ex, FTPSwitch.Switch)
         Throw
         'MessageBox.Show(ex.Message, "Upload Error");
      End Try
      ''Generic.Logging.TraceHelper.WriteDobleSeparator("Download ends.", FTPSwitch.Switch.TraceInfo);
   End Sub
#End Region

#Region "RenameRemote Members"
   Public Sub RenameRemote(remotePath As String, oldFileName As String, newFilename As String) Implements IFtp.RenameRemote

      'Generic.Logging.TraceHelper.WriteDobleSeparator("RenameRemote starts.", FTPSwitch.Switch.TraceInfo);

      'Trace.WriteLineIf(FTPSwitch.Switch.TraceVerbose, string.Format("remotePath = {0}", remotePath));
      'Trace.WriteLineIf(FTPSwitch.Switch.TraceVerbose, string.Format("oldFileName = {0}", oldFileName));
      'Trace.WriteLineIf(FTPSwitch.Switch.TraceVerbose, string.Format("newFilename = {0}", newFilename));
      Dim reqFTP As FtpWebRequest
      Try

         If (Not String.IsNullOrEmpty(remotePath)) Then remotePath = remotePath.Trim("/"c) + "/"

         Dim uriString As String = String.Format("ftp://{0}/{1}{2}", _ftpServerIP, remotePath, oldFileName)
         'Trace.WriteLineIf(FTPSwitch.Switch.TraceInfo, string.Format("UriString = {0}", uriString));

         reqFTP = DirectCast(FtpWebRequest.Create(New Uri(uriString)), FtpWebRequest)
         reqFTP.Method = WebRequestMethods.Ftp.Rename
         reqFTP.RenameTo = newFilename
         reqFTP.UseBinary = _defaultUseBinaryValue
         reqFTP.Credentials = New NetworkCredential(_ftpUserID, _ftpPassword)
         Using response As FtpWebResponse = DirectCast(reqFTP.GetResponse(), FtpWebResponse)
            Using ftpStream As Stream = response.GetResponseStream()

               ftpStream.Close()
            End Using
            response.Close()
         End Using
      Catch
         ''Generic.Logging.TraceHelper.WriteLine(ex, FTPSwitch.Switch)
         Throw
         'MessageBox.Show(ex.Message, "Upload Error");
      End Try
      'Generic.Logging.TraceHelper.WriteDobleSeparator("RenameRemote ends.", FTPSwitch.Switch.TraceInfo);
   End Sub
#End Region

#Region "Make Directory Members"
   Public Sub MakeDirectory(basePath As String, newDirectory As String) Implements IFtp.MakeDirectory
      MakeDirectory(basePath.Trim("/"c) + "/" + newDirectory)
   End Sub

   Public Sub MakeDirectory(newDirectoryPath As String) Implements IFtp.MakeDirectory
      'Generic.Logging.TraceHelper.WriteDobleSeparator("MakeDirectory starts.", FTPSwitch.Switch.TraceInfo);

      'Trace.WriteLineIf(FTPSwitch.Switch.TraceVerbose, string.Format("newDirectoryPath = {0}", newDirectoryPath));
      Dim reqFTP As FtpWebRequest
      Try
         Dim uriString As String = String.Format("ftp://{0}/{1}", _ftpServerIP, newDirectoryPath)
         'Trace.WriteLineIf(FTPSwitch.Switch.TraceInfo, String.Format("UriString = {0}", uriString))

         '' dirName = name of the directory to create.
         reqFTP = DirectCast(FtpWebRequest.Create(New Uri(uriString)), FtpWebRequest)
         reqFTP.Method = WebRequestMethods.Ftp.MakeDirectory
         reqFTP.UseBinary = _defaultUseBinaryValue
         reqFTP.Credentials = New NetworkCredential(_ftpUserID, _ftpPassword)
         Using response As FtpWebResponse = DirectCast(reqFTP.GetResponse(), FtpWebResponse)
            Using ftpStream As Stream = response.GetResponseStream()
               ftpStream.Close()
            End Using
            response.Close()
         End Using
      Catch
         ''Generic.Logging.TraceHelper.WriteLine(ex, FTPSwitch.Switch)
         Throw
         'MessageBox.Show(ex.Message, "Upload Error");
      End Try
      'Generic.Logging.TraceHelper.WriteDobleSeparator("MakeDirectory ends.", FTPSwitch.Switch.TraceInfo);
   End Sub
#End Region

#Region "GetFileSize Members"
   Public Function GetFileSize(fileName As String) As Long Implements IFtp.GetFileSize

      'Generic.Logging.TraceHelper.WriteDobleSeparator("GetFileSize starts.", FTPSwitch.Switch.TraceInfo);
      'Trace.WriteLineIf(FTPSwitch.Switch.TraceVerbose, string.Format("fileName = {0}", fileName));
      Dim fileSize As Long = 0
      Try
         Dim reqFTP As FtpWebRequest
         Dim uriString As String = String.Format("ftp://{0}/{1}", _ftpServerIP, fileName)
         'Trace.WriteLineIf(FTPSwitch.Switch.TraceInfo, string.Format("UriString = {0}", uriString));

         reqFTP = DirectCast(FtpWebRequest.Create(New Uri(uriString)), FtpWebRequest)
         reqFTP.Method = WebRequestMethods.Ftp.GetFileSize
         reqFTP.UseBinary = _defaultUseBinaryValue
         reqFTP.Credentials = New NetworkCredential(_ftpUserID, _ftpPassword)
         Using response As FtpWebResponse = DirectCast(reqFTP.GetResponse(), FtpWebResponse)
            Using ftpStream As Stream = response.GetResponseStream()
               fileSize = response.ContentLength
               ftpStream.Close()
            End Using
            response.Close()
         End Using
      Catch
         ''Generic.Logging.TraceHelper.WriteLine(ex, FTPSwitch.Switch)
         Throw
         'MessageBox.Show(ex.Message, "Upload Error");
      End Try
      'Generic.Logging.TraceHelper.WriteDobleSeparator("GetFileSize ends.", FTPSwitch.Switch.TraceInfo);
      Return fileSize
   End Function
#End Region

#Region "FileExists Members"
   Public Function FileExists(fileName As String) As Boolean Implements IFtp.FileExists
      'Generic.Logging.TraceHelper.WriteDobleSeparator("FileExists starts.", FTPSwitch.Switch.TraceInfo);
      'Trace.WriteLineIf(FTPSwitch.Switch.TraceVerbose, string.Format("fileName = {0}", fileName));
      Dim result As Boolean
      Try
         result = GetFileSize(fileName) > -1
      Catch
         ''Generic.Logging.TraceHelper.WriteLine(ex, FTPSwitch.Switch)
         Return False
         'MessageBox.Show(ex.Message, "Upload Error");
      End Try
      'Generic.Logging.TraceHelper.WriteDobleSeparator("FileExists ends.", FTPSwitch.Switch.TraceInfo);
      Return result
   End Function
#End Region
#End Region

End Class