#Region "Options/Imports"
Option Strict On
Option Explicit On
Imports System.Net
Imports System.IO
Imports System.Text
#End Region
Namespace ServiciosRest.Archivos
   <Obsolete("", True)>
   Public Class ClientesWebSiga(Of T)
      'Inherits BaseArchivosWeb(Of T) ' Entidades.JSonEntidades.Archivos.ClienteJSon)

      'Protected Overrides Function GetURLPost() As String
      '   Return "http://www.plumasaloe.com.ar/rest-siga/index.php/api/sigacliente/"
      'End Function

      'Protected Overrides Function GetURLDelete() As String
      '   Return "http://www.plumasaloe.com.ar/rest-siga/index.php/api/sigacliente/CuitEmpresa/23238857449/"
      'End Function

      'Protected Overrides Function GetURLGet() As String
      '   Return "http://www.plumasaloe.com.ar/rest-siga/index.php/api/sigacliente/CuitEmpresa/23238857449/"
      'End Function
   End Class
End Namespace