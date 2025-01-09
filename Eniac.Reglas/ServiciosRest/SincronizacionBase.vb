#Region "Option/Imports"
Option Strict On
Option Explicit On
'Option Infer On
#End Region
Namespace ServiciosRest
   Public Class SincronizacionBase
      Private _IdEmpresa As Integer
      Protected Property IdEmpresa As Integer
         Get
            Return _IdEmpresa
         End Get
         Private Set(value As Integer)
            _IdEmpresa = value
         End Set
      End Property
      Private _BaseUri As Uri
      Protected Property BaseUri As Uri
         Get
            Return _BaseUri
         End Get
         Private Set(value As Uri)
            _BaseUri = value
         End Set
      End Property

      Protected Sub New(BaseUriString As String)
         Dim codigoClienteSinergia As String = Publicos.CodigoClienteSinergia
         If Not IsNumeric(codigoClienteSinergia) Then
            Throw New Exception("No está configurado el Codigo de Empresa.")
         End If
         IdEmpresa = Integer.Parse(codigoClienteSinergia)

         Me.BaseUri = New Uri(BaseUriString)
      End Sub

      Public Event Avance(sender As Object, e As SincronizacionEventArgs)
      Public Event Estado(sender As Object, e As SincronizacionEstadoEventArgs)

      Protected Overridable Sub OnAvance(mensaje As String)
         RaiseEvent Avance(Me, New SincronizacionEventArgs(mensaje))
      End Sub
      Protected Overridable Sub OnAvance(metodo As String, accion As String, uri As Uri)
         RaiseEvent Avance(Me, New SincronizacionEventArgs(String.Format("Subiendo información de {0}.", metodo), accion, uri))
      End Sub
      Protected Overridable Sub OnEstado(estado As SincronizacionEstadoEventArgs.EstadoEnum, metodo As String, total As Integer, current As Integer)
         RaiseEvent Estado(Me, New SincronizacionEstadoEventArgs(estado, metodo, total, current))
      End Sub

      Protected Sub SubirIndividual(Of T)(metodo As String, lista As List(Of T), Optional tamanoPagina As Integer = Integer.MaxValue, Optional binario As Boolean = False)
         RaiseEvent Avance(Me, New SincronizacionEventArgs(String.Format("Subiendo información de {0}.", metodo.ToString())))

         Try
            Dim archWeb As New Archivos.BaseArchivosWeb(Of T)()

            Dim headers As HeadersDictionary = New HeadersDictionary().AgregarEmpresa(IdEmpresa).AgregarVersion()

            Dim metodoUrl As String = metodo.ToString()
            If binario Then
               metodoUrl = String.Concat(metodoUrl, "/", "binary")
            End If

            Dim uri As Uri = New Uri(BaseUri, metodoUrl)

            OnAvance(metodo, "DELETE", uri)
            archWeb.Delete(uri.ToString(), headers)
            OnAvance(metodo, "POST", uri)
            OnEstado(SincronizacionEstadoEventArgs.EstadoEnum.Iniciando, metodo, lista.Count, 0)
            Dim paginas As List(Of T()) = PaginarDatos(lista, tamanoPagina)
            Dim countRegistros As Integer = 0
            'For Each pagina As T() In paginas
            Dim paginasCount As Integer = paginas.Count
            For i As Integer = 0 To paginasCount - 1
               Dim pagina As T() = paginas(i)
               OnAvance(String.Format("Subiendo información de {0} - Página {1} de {2}.", metodo, i + 1, paginasCount))
               archWeb.Post(pagina, uri.ToString(), headers, binario)
               countRegistros += pagina.Count
               OnEstado(SincronizacionEstadoEventArgs.EstadoEnum.Subiendo, metodo, lista.Count, countRegistros)
            Next
            OnEstado(SincronizacionEstadoEventArgs.EstadoEnum.Finalizado, metodo, lista.Count, countRegistros)

         Catch ex As System.Net.WebException
            OnEstado(SincronizacionEstadoEventArgs.EstadoEnum.Error, metodo, lista.Count, lista.Count)
            NetExceptionHelper.NetExceptionHandler(ex)
         End Try
      End Sub

      Private Function PaginarDatos(Of T)(datos As List(Of T), registrosPorPagina As Integer) As List(Of T())
         Dim result As List(Of T()) = New List(Of T())
         Dim posicion As Integer = 0
         While posicion < datos.Count
            Dim pagina(Math.Min(datos.Count - posicion, registrosPorPagina) - 1) As T
            datos.CopyTo(posicion, pagina, 0, Math.Min(datos.Count - posicion, registrosPorPagina))
            result.Add(pagina)
            posicion += registrosPorPagina
         End While
         Return result
      End Function

   End Class

   Public Class SincronizacionEventArgs
      Inherits EventArgs
      Public Sub New(mensaje As String)
         Me.Mensaje = mensaje
      End Sub
      Public Sub New(mensaje As String, metodo As String, url As Uri)
         Me.New(mensaje)
         Me.Metodo = metodo
         Me.Url = url
      End Sub
      Public Sub New(mensaje As String, metodo As String, url As Uri, tabla As String, totalRegistrosSubidos As Long)
         Me.New(mensaje, metodo, url)
         Me.Tabla = tabla
         Me.TotalRegistrosSubidos = totalRegistrosSubidos
      End Sub
      Public Property Mensaje As String
      Public Property Metodo As String
      Public Property Url As Uri
      Public Property Tabla As String
      Public Property TotalRegistrosSubidos As Long
   End Class
   Public Class SincronizacionEstadoEventArgs
      Inherits EventArgs
      Public Enum EstadoEnum
         Iniciando
         Subiendo
         Descargando
         Finalizado
         [Error]
      End Enum
      Public Sub New(estado As EstadoEnum, metodo As String, totalRegistros As Long, totalRegistrosSubidos As Long)
         Me.Estado = estado
         Me.Metodo = metodo
         Me.TotalRegistros = totalRegistros
         Me.TotalRegistrosSubidos = totalRegistrosSubidos
      End Sub
      Public Property Estado As EstadoEnum
      Public Property Metodo As String
      Public Property TotalRegistros As Long
      Public Property TotalRegistrosSubidos As Long
   End Class
End Namespace