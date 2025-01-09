Imports System.Runtime.CompilerServices

Namespace Extensions
   Module AFIPFEExtensions
      <Extension()>
      Public Sub WriteXML(Of T)(afipfe As AFIPFE, path As String, obj As T)
         Try
            IO.Directory.CreateDirectory(Publicos.FacturaElectronica.FactElecGuardarLogPath)
            Dim s = New Xml.Serialization.XmlSerializer(obj.GetType())
            Using w = IO.File.OpenWrite(IO.Path.Combine(Publicos.FacturaElectronica.FactElecGuardarLogPath, String.Concat(path, ".xml")))
               s.Serialize(w, obj)
            End Using
         Catch ex As Exception
            afipfe.WriteError(path, ex)
         End Try
      End Sub
      <Extension()>
      Public Sub WriteError(afipfe As AFIPFE, path As String, ex As Exception)
         IO.File.WriteAllText(String.Concat(path, ".err"), ex.ToString())
      End Sub

   End Module
End Namespace