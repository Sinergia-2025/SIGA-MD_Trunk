#Region "Option"
Option Strict On
Option Explicit On
Option Infer On
#End Region
Namespace ServiciosRest.Sincronizacion
   Public MustInherit Class SyncBase(Of T, E)
      Implements ISyncBase

#Region "Constructors"
      Protected Shared Property Serializer As System.Web.Script.Serialization.JavaScriptSerializer
      Shared Sub New()
         Serializer = New System.Web.Script.Serialization.JavaScriptSerializer()
      End Sub

      Private Property SyncConfig As Entidades.JSonEntidades.Sincronizacion.SyncConfig
      Protected Sub New(syncConfig As Entidades.JSonEntidades.Sincronizacion.SyncConfig)
         Me.SyncConfig = syncConfig
      End Sub
#End Region

#Region "Inicialización"
      Private _fechaUltimaDescarga As Func(Of DateTime?)
      Private _cargaDatos As Func(Of DateTime?, List(Of T))
      Private _newSyncRegla As Func(Of ISyncRegla(Of T, E))
      Private _esReenvioTodo As Boolean
      Private _esRecibirTotdo As Boolean
      Protected Function Inicializar(cargaDatos As Func(Of DateTime?, List(Of T)),
                                     fechaUltimaDescarga As Func(Of DateTime?),
                                     newSyncRegla As Func(Of ISyncRegla(Of T, E)),
                                     esReenvioTodo As Boolean,
                                     esRecibirTotdo As Boolean) As ISyncBase
         _cargaDatos = cargaDatos
         _fechaUltimaDescarga = fechaUltimaDescarga
         _newSyncRegla = newSyncRegla
         _esReenvioTodo = esReenvioTodo
         _esRecibirTotdo = esRecibirTotdo
         Return Me
      End Function
#End Region

#Region "Estado de Sincronización"
      Private Property Paginas As List(Of T())
      Private Property UltimaPaginaEnviada As Integer
      Private Property DatosRecibidos As SyncList(Of E)
#End Region



#Region "ISyncBase"

      Public Function SincronizarAutomaticamente(grabaArchivoLocal As Boolean, syncs As Reglas.ServiciosRest.Sincronizacion.SyncBaseCollection) As Boolean Implements ISyncBase.SincronizarAutomaticamente
         ImportarAutomaticamente(syncs)
         EnviarAutomaticamente(grabaArchivoLocal)
         Return True
      End Function


      Private Function EnviarAutomaticamente(grabaArchivoLocal As Boolean) As Boolean Implements ISyncBase.EnviarAutomaticamente
         If Not SyncConfig.IncluidoSubida Then Return True

         Dim result As Boolean = False
         If CargarDatos() Then
            result = EnviarDatos(grabaArchivoLocal)
         End If
         Return result
      End Function
      Private Function CargarDatos() As Boolean Implements ISyncBase.CargarDatos
         If Not SyncConfig.IncluidoSubida Then Return True
         OnAntesGet()
         Dim lista = _cargaDatos.Invoke(ObtenerFechaMaxima())
         OnDespuesGet(lista)
         CargarDatos(lista, SyncConfig.TamanioPaginaSubida)
         Return True
      End Function
      Public Function EnviarDatos(grabaArchivoLocal As Boolean) As Boolean Implements ISyncBase.EnviarDatos
         Try
            If Not SyncConfig.IncluidoSubida Then Return True
            Return EnviarDatos(Paginas, SyncConfig.BaseURL, grabaArchivoLocal, paginaInicial:=0)
         Catch ex As Exception
            Throw New EnviarDatosException(GetType(T), ex)
         End Try
      End Function


      Private Function ImportarAutomaticamente(syncs As Reglas.ServiciosRest.Sincronizacion.SyncBaseCollection) As Boolean Implements ISyncBase.ImportarAutomaticamente
         If Not SyncConfig.IncluidoDescarga Then Return True
         Dim result As Boolean = False
         If DescargarDatos() Then
            If ValidarDatos(syncs) Then
               result = ImportarDatos()
            End If
         End If
         Return result
      End Function
      Private Function DescargarDatos() As Boolean Implements ISyncBase.DescargarDatos
         If Not SyncConfig.IncluidoDescarga Then Return True
         If _esRecibirTotdo Then
            DescargarDatos(fechaActualizacion:=Nothing)
         Else
            DescargarDatos(_fechaUltimaDescarga.Invoke())
         End If
         Return True
      End Function
      Private Function ValidarDatos(syncs As Reglas.ServiciosRest.Sincronizacion.SyncBaseCollection) As Boolean Implements ISyncBase.ValidarDatos
         If Not SyncConfig.IncluidoDescarga Then Return True
         Return ValidarDatos(DatosRecibidos, syncs)
      End Function
      Private Function ImportarDatos() As Boolean Implements ISyncBase.ImportarDatos
         If Not SyncConfig.IncluidoDescarga Then Return True
         Return ImportarDatos(DatosRecibidos)
      End Function

      Private Function GetEntityType() As Type Implements ISyncBase.GetEntityType
         Return GetType(E)
      End Function

      Private ReadOnly Property DatosRecibidosP As IList Implements ISyncBase.DatosRecibidos
         Get
            Return DatosRecibidos
         End Get
      End Property

#End Region



#Region "CargarDatos"
      Private Sub CargarDatos(datos As List(Of T), pageSize As Integer)
         OnAntesPaginar(datos)
         Dim paginas = datos.Paginar(pageSize)
         OnDespuesPaginar(datos, paginas)
         CargarDatos(paginas)
      End Sub
      Private Sub CargarDatos(paginas As List(Of T()))
         Me.Paginas = paginas
      End Sub
#End Region

#Region "EnviarDatos"
      Private Sub ContinuarEnvio(grabaArchivoLocal As Boolean)
         EnviarDatos(Paginas, SyncConfig.BaseURL, grabaArchivoLocal, UltimaPaginaEnviada)
      End Sub

      Private Function EnviarDatos(paginas As List(Of T()), url As String, grabaArchivoLocal As Boolean, paginaInicial As Integer) As Boolean

         OnAntesEnviarDatos(url, paginaInicial)

         Dim headers As HeadersDictionary = New HeadersDictionary().AgregarCuitEmpresa().AgregarIdSucursalEmpresa().AgregarVersion()

         If grabaArchivoLocal Then
            GuardarArchivoLocal(paginas)
         End If

         If Not String.IsNullOrWhiteSpace(url) Then
            Dim servicioRest As Reglas.ServiciosRest.Archivos.BaseArchivosWeb(Of T) = New Reglas.ServiciosRest.Archivos.BaseArchivosWeb(Of T)()

            If paginaInicial = 0 And _esReenvioTodo Then
               OnAntesBorrarDatos(url)
               servicioRest.Delete(url, headers)
               OnLuegoBorrarDatos(url)
            End If

            Dim totalPaginas As Integer = paginas.Count
            For paginaActual As Integer = paginaInicial To totalPaginas - 1
               UltimaPaginaEnviada = paginaActual

               OnEnviandoDatos(url, paginaInicial, paginaActual, totalPaginas)
               servicioRest.Post(paginas(paginaActual), url, headers, binario:=False)
               OnEnvioDatosFinalizado(url, paginaInicial, paginaActual, totalPaginas)
            Next
         End If

         OnDespuesEnviarDatos(url)

         Return True

      End Function
#End Region



#Region "DescargarDatos"
      Private Sub DescargarDatos(fechaActualizacion As DateTime?)
         If DatosRecibidos Is Nothing Then
            DatosRecibidos = New SyncList(Of E)()
         Else
            DatosRecibidos.Clear()
         End If
         DescargarDatos(fechaActualizacion, paginaInicial:=0)
      End Sub
      Private Sub ContinuarDescargarDatos(fechaActualizacion As DateTime?)
         If DatosRecibidos Is Nothing Then
            'Si la lista es Nothing, nunca se inició una lista. Inicio desde cero como una descarga normal.
            DescargarDatos(fechaActualizacion)
         Else
            If Not DatosRecibidos.SincronizacionCompletada Then
               'Si no terminó la sincronización, la continuo desde donde quedó
               DescargarDatos(fechaActualizacion, DatosRecibidos.UltimaPaginaSincronizada)
            End If
         End If
         'En caso de que la sincronización esté marcada como finalizada, la misma no se continua. No debería haber nada para continuar
      End Sub

      Private Sub DescargarDatos(fechaActualizacion As DateTime?, paginaInicial As Integer)
         OnAntesRecibirDatos(UrlConParametros(SyncConfig.BaseURL, actual.Sucursal.Id, fechaActualizacion), paginaInicial)

         Dim headers As HeadersDictionary = New HeadersDictionary().AgregarCuitEmpresa().AgregarIdSucursalEmpresa().AgregarVersion()

         Dim servicioRest As Reglas.ServiciosRest.Archivos.BaseArchivosWeb(Of T)
         servicioRest = New Reglas.ServiciosRest.Archivos.BaseArchivosWeb(Of T)()

         Dim cantidadRegistros As Long
         Try
            Dim urlCount = UrlConParametros(String.Concat(SyncConfig.BaseURL, "count"), actual.Sucursal.Id, fechaActualizacion)
            cantidadRegistros = ObtenerCount(urlCount, headers) ' servicioRest.GetCount(urlCount, fechaActualizacion)(0).cantidadRegistros
         Catch ex As Exception
            cantidadRegistros = SyncConfig.TamanioPaginaDescarga
         End Try

         Dim totalPaginas As Long = Convert.ToInt64(Math.Ceiling(cantidadRegistros / SyncConfig.TamanioPaginaDescarga))

         Dim urlGet = String.Format("{0}&rowsToFetch={1}", UrlConParametros(SyncConfig.BaseURL, actual.Sucursal.Id, fechaActualizacion), SyncConfig.TamanioPaginaDescarga)

         Dim offset As Long = paginaInicial * SyncConfig.TamanioPaginaDescarga
         While offset < cantidadRegistros
            OnRecibiendoDatos(urlGet, paginaInicial, DatosRecibidos.Count)
            Dim pagina = servicioRest.Get(String.Concat(urlGet, String.Format("&offset={0}", offset)), offset, SyncConfig.TamanioPaginaDescarga, fechaActualizacion.IfNull(), headers)
            DatosRecibidos.AddRange(_newSyncRegla().Convertir(pagina))
            OnRecibiendoDatosFinalizado(urlGet, paginaInicial, DatosRecibidos.Count)

            offset += SyncConfig.TamanioPaginaDescarga
            paginaInicial += 1
            DatosRecibidos.UltimaPaginaSincronizada = paginaInicial
         End While

         OnDespuesRecibiendoDatos(urlGet, DatosRecibidos, paginaInicial)

         DatosRecibidos.SincronizacionCompletada = True
      End Sub
#End Region

#Region "ValidarDatos"
      Private Function ValidarDatos(datos As SyncList(Of T), syncs As Reglas.ServiciosRest.Sincronizacion.SyncBaseCollection) As Boolean
         If Not datos.SincronizacionCompletada Then
            Throw New RecibirDatosIncompletaException(GetType(T), datos.UltimaPaginaSincronizada)
         End If

         Return ValidarDatos(_newSyncRegla().Convertir(datos), syncs)
      End Function
      Private Function ValidarDatos(datos As List(Of E), syncs As Reglas.ServiciosRest.Sincronizacion.SyncBaseCollection) As Boolean
         Dim regla = _newSyncRegla()
         AddHandler regla.AvanceValidarDatos, Sub(sender, e) OnAvanceValidarDatos(e.RegistroActual, e.TotalRegistros, e.Estado)
         OnAntesValidarDatos()
         Dim result = _newSyncRegla().ValidarDatos(datos, syncs)
         OnDespuesValidarDatos()
         Return result
      End Function
#End Region

#Region "ImportarDatos"
      Private Function ImportarDatos(datos As SyncList(Of T)) As Boolean
         Return ImportarDatos(_newSyncRegla().Convertir(datos))
      End Function
      Private Function ImportarDatos(datos As List(Of E)) As Boolean
         Dim regla = _newSyncRegla()
         AddHandler regla.AvanceImportarDatos, Sub(sender, e) OnAvanceImportarDatos(e.RegistroActual, e.TotalRegistros, e.Estado)
         OnAntesImportarDatos()
         Dim result = regla.ImportarDatos(datos)
         OnDespuesImportarDatos()
         Return result
      End Function
#End Region



#Region "Auxiliares"
      Private Sub GuardarArchivoLocal(paginas As List(Of T()))
         If Not String.IsNullOrWhiteSpace(SyncConfig.ArchivoExportarFormat) Then
            For numeroPagina = 0 To paginas.Count - 1
               Dim nombreArchivo = New IO.FileInfo(String.Format(SyncConfig.ArchivoExportarFormat, numeroPagina + 1))
               If numeroPagina = 0 Then
                  nombreArchivo.Directory.Create()
               End If
               IO.File.WriteAllText(nombreArchivo.FullName, Serializer.Serialize(paginas(numeroPagina)))
            Next
         End If
      End Sub

      Private Function ObtenerFechaMaxima() As DateTime?
         Dim fechaActualizacion As DateTime? = Nothing
         If Not _esReenvioTodo Then
            fechaActualizacion = ObtenerFechaMaxima(String.Concat(SyncConfig.BaseURL, "max"))
         End If
         Return fechaActualizacion
      End Function
      Private Function ObtenerFechaMaxima(url As String) As DateTime?
         OnObteniendoFechaUltimaActualizacion(url)

         Dim headers As HeadersDictionary = New HeadersDictionary().AgregarCuitEmpresa().AgregarIdSucursalEmpresa().AgregarVersion()

         Dim servicioRest = New Reglas.ServiciosRest.Archivos.BaseArchivosWeb(Of DateTime)()
         Dim result As DateTime? = Nothing
         If Not String.IsNullOrWhiteSpace(url) Then
            'tssInfo.Text = String.Format("Obteniendo última fecha de {0}.", key)
            'Application.DoEvents()
            Try
               Dim fechas = servicioRest.Get(url, 0, Integer.MaxValue, Today, headers)
               If fechas.Count > 0 Then
                  result = fechas(0)
               End If
            Catch ex As Exception
               result = Nothing
            End Try
         End If
         OnLuegoObteniendoFechaUltimaActualizacion(url, result)
         Return result
      End Function

      Private Function ObtenerCount(url As String) As Long
         Return ObtenerCount(url, New HeadersDictionary().AgregarCuitEmpresa().AgregarIdSucursalEmpresa().AgregarVersion())
      End Function
      Private Function ObtenerCount(url As String, headers As HeadersDictionary) As Long
         OnObtenerCantidadRegistros(url)

         Dim servicioRest = New Reglas.ServiciosRest.Archivos.BaseArchivosWeb(Of Long)()
         Dim result As Long? = Nothing
         If Not String.IsNullOrWhiteSpace(url) Then
            Try
               Dim cantidades = servicioRest.Get(url, 0, Integer.MaxValue, Today, headers)
               If cantidades.Count > 0 Then
                  result = cantidades(0)
               End If
            Catch ex As Exception
               result = Nothing
            End Try
         End If

         OnLuegoObtenerCantidadRegistros(url, result.IfNull())
         Return result.IfNull()
      End Function

      Private Function UrlConParametros(baseUrl As String, notFromIdSucursal As Integer?, fechaActualizacion As DateTime?) As String
         Dim stbUrl = New StringBuilder(baseUrl.TrimEnd("/"c))
         Dim separadorParametro As String = "?"
         If notFromIdSucursal.HasValue Then
            stbUrl.AppendFormat("{0}notFromIdSucursalEmpresa={1}", separadorParametro, actual.Sucursal.Id)
            separadorParametro = "&"
         End If
         If fechaActualizacion.HasValue Then
            stbUrl.AppendFormat("{0}fechaActualizacion={1}", separadorParametro, fechaActualizacion.ToStringFormatoURL())
            separadorParametro = "&"
         End If
         Return stbUrl.ToString()
      End Function
#End Region

   End Class

   Public Class SyncList(Of T)
      Inherits List(Of T)

      Public Property UltimaPaginaSincronizada As Integer
      Public Property SincronizacionCompletada As Boolean = False

   End Class


End Namespace