Imports System.Web.Script.Serialization
Namespace SimovilOficina
   Public Class VincularSimovilOficina
      Public Function GetInfoParaVinculacion() As String
         Dim codigoClienteSinergia As String = Publicos.CodigoClienteSinergia
         If Not IsNumeric(codigoClienteSinergia) Then
            Throw New Exception("No está configurado el Codigo de Empresa.")
         End If
         Dim URLProduccion = Publicos.SimovilOficinaURLProduccion ' "http://sinergiamovil.com.ar/simovil.oficina"
         Dim URLTesting = Publicos.SimovilOficinaURLTesting       ' "http://sinergiamovil.com.ar/simovil.oficina.test"

         Return GetInfoParaVinculacion(Integer.Parse(codigoClienteSinergia), actual.Sucursal.Id, URLProduccion, URLTesting)
      End Function
      Public Function GetInfoParaVinculacion(codigoEmpresa As Long, idSucursal As Integer, urlProduccion As String, urlTesting As String) As String
         Dim info = New With {.CodigoEmpresa = codigoEmpresa,
                              .IdSucursal = idSucursal,
                              .URLProduccion = urlProduccion,
                              .URLTesting = urlTesting}
         Dim valor = New JavaScriptSerializer().Serialize(info)
         valor = New Ayudantes.Criptografia().EncryptString128Bit(valor, "clave")
         Return valor
      End Function

   End Class
End Namespace