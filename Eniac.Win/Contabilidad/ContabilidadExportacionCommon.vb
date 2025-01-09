Option Strict On
Option Explicit On
Imports System.Text

Public Class ContabilidadExportacionCommon

   Public Overridable Sub GrabarArchivo(ByVal destino As String, archivo As ContabilidadExportacionArchivo)
      GrabarArchivo(destino, archivo.Lineas)
   End Sub

   Public Overridable Sub GrabarArchivo(ByVal destino As String, lineas As List(Of ContabilidadExportacionArchivoLinea))
      Try
         Dim stb As StringBuilder = New StringBuilder()

         For Each linea As ContabilidadExportacionArchivoLinea In lineas
            GetLinea(linea, stb)
            stb.AppendLine()
         Next

         My.Computer.FileSystem.WriteAllText(destino, stb.ToString(), False, System.Text.Encoding.ASCII)

      Catch ex As Exception
         Throw
      End Try
   End Sub


   Public Overridable Sub GetLinea(linea As ContabilidadExportacionArchivoLinea, stb As StringBuilder)
      With stb

      End With
   End Sub

End Class
