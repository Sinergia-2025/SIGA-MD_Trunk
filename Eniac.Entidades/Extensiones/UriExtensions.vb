Namespace Extensiones
   Public Module UriExtensions
      <Extension()>
      Public Function ToString(uri As Uri, params As Dictionary(Of String, String)) As String
         If params.AnySecure() Then
            Dim p = String.Join("&", params.ToList().ConvertAll(Function(x) String.Format("{0}={1}", x.Key, x.Value)))
            Return String.Format("{0}?{1}", uri.ToString(), p)
         Else
            Return uri.ToString()
         End If
      End Function
   End Module
End Namespace