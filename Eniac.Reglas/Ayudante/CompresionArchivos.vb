Imports System.IO
Imports System.IO.Compression

Public Class CompresionArchivos
   Public Shared Sub Comprimir(origen As IO.FileInfo, destino As String)
      Using stmOrigen As FileStream = origen.OpenRead()
         Comprimir(stmOrigen, destino)
      End Using
   End Sub
   Public Shared Sub Comprimir(stmOrigen As Stream, destino As String)
      Using stmDestino As FileStream = File.Create(destino)
         Using gstmCompresor As New GZipStream(stmDestino, CompressionMode.Compress)
            stmOrigen.CopyTo(gstmCompresor)
         End Using
      End Using
   End Sub
End Class