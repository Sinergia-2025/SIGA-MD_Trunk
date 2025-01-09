Imports System
Imports System.Collections.Generic
Imports System.Net
Imports System.Runtime.Serialization.Json
Imports System.IO
Imports System.Text


Namespace ServiciosRest

   Public Class ConsultaDolar

      Private _uri As Uri

      Public Sub New(uri As Uri)
         Me._uri = uri
      End Sub

      Public Function GetValor() As Entidades.MonedaDolar
         Dim wc As WebClient = New WebClient()
         'wc.Headers.Add("token", encryptedToken)
         'Dim lec As System.IO.StreamReader = New IO.StreamReader(wc.OpenRead(Me._uri))
         Dim json As String = String.Empty
         Dim monDol As Entidades.MonedaDolar

         Try
            If Publicos.HayInternet Then
               json = wc.DownloadString(Me._uri)
            End If
            Using ms As New MemoryStream(Encoding.UTF8.GetBytes(json))
               Dim ser As DataContractJsonSerializer = New DataContractJsonSerializer(GetType(Eniac.Entidades.MonedaDolar))
               'monDol = New Entidades.MonedaDolar()
               monDol = TryCast(ser.ReadObject(ms), Entidades.MonedaDolar)

               'Dim serviceResult As Eniac.Entidades.MonedaDolar = ser.ReadObject(wc.OpenRead(Me._uri))
            End Using
         Catch ex As Exception
            'si da algun error no hago nada ya que puede ser un tema de internet
         End Try

         Return monDol
      End Function




   End Class

End Namespace
