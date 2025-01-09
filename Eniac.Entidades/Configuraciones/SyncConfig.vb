Namespace JSonEntidades.Sincronizacion
   Public Class SyncConfig
      Public Property EndPointName As String
      Public Property BaseURL As String
      Public Property ArchivoExportarFormat As String

      Public Property IncluidoSubida As Boolean
      Public Property TamanioPaginaSubida As Integer

      Public Property IncluidoDescarga As Boolean
      Public Property TamanioPaginaDescarga As Integer

      Public Property IncluidoSubidaKey As Entidades.Parametro.Parametros
      Public Property TamanioPaginaSubidaKey As Entidades.Parametro.Parametros
      Public Property IncluidoDescargaKey As Entidades.Parametro.Parametros
      Public Property TamanioPaginaDescargaKey As Entidades.Parametro.Parametros

      '   ArchivoExportarFormat = "d:\Temp\_json\@@nombretabla@@\@@nombretabla@@_{0:00000000}.json".Replace("@@nombretabla@@", GetType(T).Name)
      '   BaseURL = "http://localhost:14209/api/"

      Public Sub New(endPointName As String, baseURL As String, archivoExportarPath As String,
                     incluidoSubida As Boolean, tamanioPaginaSubida As Integer,
                     incluidoDescarga As Boolean, tamanioPaginaDescarga As Integer,
                     incluidoSubidaKey As Entidades.Parametro.Parametros,
                     tamanioPaginaSubidaKey As Entidades.Parametro.Parametros,
                     incluidoDescargaKey As Entidades.Parametro.Parametros,
                     tamanioPaginaDescargaKey As Entidades.Parametro.Parametros)
         Me.EndPointName = endPointName
         Me.BaseURL = String.Concat(baseURL.TrimEnd("/"c), "/", endPointName, "/")
         Me.ArchivoExportarFormat = String.Concat(archivoExportarPath.TrimEnd("\"c), "\@@nombretabla@@\@@nombretabla@@_{0:00000000}.json").Replace("@@nombretabla@@", endPointName)
         Me.IncluidoSubida = incluidoSubida
         Me.TamanioPaginaSubida = tamanioPaginaSubida
         Me.IncluidoDescarga = incluidoDescarga
         Me.TamanioPaginaDescarga = tamanioPaginaDescarga

         Me.IncluidoSubidaKey = incluidoSubidaKey
         Me.TamanioPaginaSubidaKey = tamanioPaginaSubidaKey

         Me.IncluidoDescargaKey = incluidoDescargaKey
         Me.TamanioPaginaDescargaKey = tamanioPaginaDescargaKey
      End Sub

   End Class
End Namespace