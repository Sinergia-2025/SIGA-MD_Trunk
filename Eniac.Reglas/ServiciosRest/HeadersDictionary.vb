Namespace ServiciosRest
   Public Class HeadersDictionary
      Inherits Dictionary(Of String, String)
      Public Enum Headers
         IdEmpresa
         CuitEmpresa
         IdSucursalEmpresa
         DeviceId
         Version
         VersionAPI
         Authorization
      End Enum

      Private _version As Version

      Public Function Agregar(key As String, value As String) As HeadersDictionary
         Add(key, value)
         Return Me
      End Function

      Public Function Agregar(key As Headers, value As String) As HeadersDictionary
         Return Agregar(key.ToString(), value)
      End Function

      Public Function AgregarCuitEmpresa() As HeadersDictionary
         Return AgregarCuitEmpresa(Publicos.CuitEmpresa)
      End Function
      Public Function AgregarIdSucursalEmpresa() As HeadersDictionary
         Return AgregarIdSucursalEmpresa(actual.Sucursal.Id)
      End Function

      Public Function AgregarEmpresa(idEmpresa As Integer) As HeadersDictionary
         Return Agregar(Headers.IdEmpresa, idEmpresa.ToString())
      End Function
      Public Function AgregarCuitEmpresa(cuitEmpresa As String) As HeadersDictionary
         Return Agregar(Headers.CuitEmpresa, cuitEmpresa)
      End Function
      Public Function AgregarIdSucursalEmpresa(idSucursalEmpresa As Integer) As HeadersDictionary
         Return Agregar(Headers.IdSucursalEmpresa, idSucursalEmpresa.ToString())
      End Function

      Public Function AgregarAuthorization(authorization As String) As HeadersDictionary
         Return Agregar(Headers.Authorization, authorization)
      End Function

      Public Function AgregarVersion() As HeadersDictionary
         If _version Is Nothing Then _version = Reflection.Assembly.GetExecutingAssembly().GetName().Version
         Return Agregar(Headers.Version, _version.ToString())
      End Function


      Public Function ToCurl(stb As StringBuilder) As StringBuilder
         AsEnumerable().ToList().ForEach(Sub(h) ToCurl(stb, h.Key, h.Value))
         Return stb
      End Function
      Public Shared Function ToCurl(stb As StringBuilder, key As String, value As String) As StringBuilder
         Return stb.AppendFormatLine(" --header '{0}: {1}' \", key, value)
      End Function

   End Class
End Namespace