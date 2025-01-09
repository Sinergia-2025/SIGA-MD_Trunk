Public Class BytesUploadedEventArgs
   Public Property FileName As String
   Public Property LoadedBytes As Long
   Public Property BufferSize As Long
   Public Property TotalBytes As Long
   Public Property Uri As Uri

   Public Sub New(fileName As String, uri As Uri, loadedBytes As Long, bufferSize As Long, totalBytes As Long)
      Me.FileName = fileName
      Me.Uri = uri
      Me.LoadedBytes = loadedBytes
      Me.BufferSize = bufferSize
      Me.TotalBytes = totalBytes
   End Sub

   Public Function Percentage() As Decimal
      Return (Convert.ToDecimal(LoadedBytes) / Convert.ToDecimal(TotalBytes)) * 100
   End Function
   Public Function PercentageAsInteger() As Integer
      Return Convert.ToInt32(Math.Truncate(Percentage))
   End Function
End Class