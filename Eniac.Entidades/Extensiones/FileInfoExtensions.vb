Namespace Extensiones
   Public Module FileInfoExtensions
      <Extension>
      Public Function Tamaño(valor As IO.FileInfo) As TamañoArchivo
         Return New TamañoArchivo(valor.Length)
      End Function

      <Extension>
      Public Function CalculateMD5(fileInfo As IO.FileInfo) As String
         If fileInfo.Exists Then
            Using md5 = Security.Cryptography.MD5.Create()
               Using stream = fileInfo.Open(IO.FileMode.Open)
                  Dim hash = md5.ComputeHash(stream)
                  Return BitConverter.ToString(hash).Replace("-", "").ToLowerInvariant()
               End Using
            End Using
         Else
            Return Nothing
         End If
      End Function
   End Module
End Namespace