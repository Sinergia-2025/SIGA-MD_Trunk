#Region "Option/Imports"
Option Strict On
Option Explicit On
Option Infer On
Imports System.Net
Imports System.IO
Imports System.Web.Script.Serialization
Imports actual = Eniac.Entidades.Usuario.Actual
Imports Eniac.Reglas.Base
Imports Eniac.Entidades.JSonEntidades.SSSServicioWeb
#End Region
Namespace ServiciosRest.CobranzasMovil
   Public Class SincronizacionSubidaMovil
      Private Property IdEmpresa As Integer
      Private Property BaseUri As Uri
      Private Property BaseUriTurnos As Uri

      Private Property NombreEmpresa As String
      Private Property CuitEmpresa As String
      Private Property IdUsuario As String
      Private Property NombreUsuario As String

      Public Event Avance(sender As Object, e As SincronizacionSubidaMovilEventArgs)
      Public Event Estado(sender As Object, e As SincronizacionSubidaMovilEstadoEventArgs)

      Private serializer As New JavaScriptSerializer()

      Public Sub New()
         'IdEmpresa = 235
         Dim codigoClienteSinergia As String = Publicos.CodigoClienteSinergia
         If Not IsNumeric(codigoClienteSinergia) Then
            Throw New Exception("No está configurado el Codigo de Empresa.")
         End If
         IdEmpresa = Integer.Parse(codigoClienteSinergia)
         Dim simovilCobranzaURLBase As String = Publicos.SimovilCobranzaURLBase
         If String.IsNullOrWhiteSpace(simovilCobranzaURLBase) Then
            Throw New Exception("No está configurado la URL Base para Simovil Cobranza.")
         End If
         BaseUri = New Uri(simovilCobranzaURLBase)
         'BaseUri = New Uri("http://localhost:5468/api/")
         'BaseUri = New Uri("http://w1021701.ferozo.com/api/")

         Dim simovilGestionTurnosURLBase As String = Publicos.SimovilGestionTurnosURLBase
         If String.IsNullOrWhiteSpace(simovilGestionTurnosURLBase) Then
            BaseUriTurnos = BaseUri
         Else
            BaseUriTurnos = New Uri(simovilGestionTurnosURLBase)
         End If

         NombreEmpresa = Publicos.NombreEmpresa
         CuitEmpresa = Publicos.CuitEmpresa
         IdUsuario = actual.Nombre
         NombreUsuario = New Reglas.Usuarios().GetUno(actual.Nombre).Nombre
      End Sub

      Public Function GetVersion() As String
         Return GetVersion(BaseUri)
      End Function
      Public Function GetVersion(BaseUri As String) As String
         If Not BaseUri.EndsWith("/") Then
#Disable Warning BC42025 ' Access of shared member, constant member, enum member or nested type through an instance
            BaseUri = BaseUri.Concat("/")
#Enable Warning BC42025 ' Access of shared member, constant member, enum member or nested type through an instance
         End If
         Return GetVersion(New Uri(BaseUri))
      End Function
      Public Function GetVersion(BaseUri As Uri) As String
         RaiseEvent Avance(Me, New SincronizacionSubidaMovilEventArgs("Obteniendo número de versión"))

         Dim uri As Uri = New Uri(BaseUri, "Version")

         Dim wc As New WebClient()
         Try
            Using orResult As System.IO.Stream = wc.OpenRead(uri)
               Using reader As StreamReader = New StreamReader(orResult, New System.Text.UTF8Encoding())
                  Dim responseString As String = reader.ReadToEnd()
                  Return responseString.Trim(""""c)
               End Using
            End Using
         Catch ex As WebException
            'If ex.Response IsNot Nothing AndAlso TypeOf (ex.Response) Is HttpWebResponse Then
            '   Dim response As HttpWebResponse = DirectCast(ex.Response, HttpWebResponse)
            '   If response.StatusCode = HttpStatusCode.NotFound Then
            '      Throw New Exception("No se han encontrado pedidos en la Web.", ex)
            '   End If
            'End If
            Throw ex
         End Try

      End Function

      Public Function GetFechaUltimaSincronizacion() As DateTime?
         RaiseEvent Avance(Me, New SincronizacionSubidaMovilEventArgs("Obteniendo Fecha de Última Sincronización"))

         Dim uri As Uri = New Uri(BaseUri, "FechaUltimaSincronizacion")

         Dim wc As New WebClient()
         wc.Headers.Add(HeadersDictionary.Headers.IdEmpresa.ToString(), IdEmpresa.ToString())
         Try
            Using orResult = wc.OpenRead(uri)
               Using reader = New StreamReader(orResult, New System.Text.UTF8Encoding())
                  Dim responseString As String = reader.ReadToEnd()
                  Dim result As Date?
                  Try
                     result = Date.ParseExact(responseString.Trim(""""c), Entidades.JSonEntidades.AyudanteJson.FormatoFechas, Nothing, Globalization.DateTimeStyles.None)
                  Catch ex As Exception
                     result = Nothing
                  End Try
                  Return result
               End Using
            End Using
         Catch ex As WebException
            'If ex.Response IsNot Nothing AndAlso TypeOf (ex.Response) Is HttpWebResponse Then
            '   Dim response As HttpWebResponse = DirectCast(ex.Response, HttpWebResponse)
            '   If response.StatusCode = HttpStatusCode.NotFound Then
            '      Throw New Exception("No se han encontrado pedidos en la Web.", ex)
            '   End If
            'End If
            Throw ex
         End Try

      End Function

      Public Function ObtenerCobranzas(sucursales As IEnumerable(Of Integer)) As List(Of Entidades.JSonEntidades.CobranzasMovil.Cobranzas)
         RaiseEvent Avance(Me, New SincronizacionSubidaMovilEventArgs(String.Format("Obteniendo información de {0}.", Metodo.Cobranzas.ToString())))

         Try
            Dim archWeb = New Archivos.BaseArchivosWeb(Of Entidades.JSonEntidades.CobranzasMovil.Cobranzas)()

            Dim headers = New HeadersDictionary().AgregarEmpresa(IdEmpresa).AgregarVersion()

            Dim uri = New Uri(BaseUri, Metodo.CobranzasPendientes.ToString()).ToString()

            If sucursales IsNot Nothing Then
               uri = String.Format("{0}?sucursales={1}", uri, String.Join(",", sucursales.ToList()))
            End If

            RaiseEvent Avance(Me, New SincronizacionSubidaMovilEventArgs(String.Format("Subiendo información de {0}.", Metodo.CobranzasPendientes.ToString()),
                                                                         "GET", New System.Uri(uri)))

            Dim result = archWeb.Get(uri, 0, Integer.MaxValue, Today, headers)
            Return result
         Catch ex As WebException
            NetExceptionHelper.NetExceptionHandler(ex)
            Throw
         End Try

      End Function

      Public Sub MarcarCobranza(cobranza As Entidades.JSonEntidades.CobranzasMovil.Cobranzas)
         RaiseEvent Avance(Me, New SincronizacionSubidaMovilEventArgs(String.Format("Actualizando información de {0}.", Metodo.Cobranzas.ToString())))

         Try
            Dim archWeb = New Archivos.BaseArchivosWeb(Of Entidades.JSonEntidades.CobranzasMovil.Cobranzas)()

            Dim headers = New HeadersDictionary().AgregarEmpresa(IdEmpresa).AgregarVersion()

            Dim uri = New Uri(BaseUri, Metodo.Cobranzas.ToString())

            RaiseEvent Avance(Me, New SincronizacionSubidaMovilEventArgs(String.Format("Actualizando información de {0}.", Metodo.Cobranzas.ToString()),
                                                                         "PUT", uri))
            archWeb.Put(cobranza, uri.ToString(), headers)
         Catch ex As System.Net.WebException
            NetExceptionHelper.NetExceptionHandler(ex)
         End Try
      End Sub

      Public Sub SubirInformacion(nombreCliente As Clientes.NombreCliente, tipoDireccion As Entidades.TipoDireccion, incluirClientes As Clientes.IncluirClientes,
                                  exportarConIVA As Boolean, soloProductosConStock As Boolean, incluirSucursales As Entidades.JSonEntidades.CobranzasMovil.SucursalesSincronizar)
         RaiseEvent Avance(Me, New SincronizacionSubidaMovilEventArgs("Comenzando subida de información"))

         '-- REQ-41757.- ----------------------------------------------------------------------------------------------
         Dim mensaje As String = String.Empty
         Dim validaUsr = New MovilRutas()

         If Not validaUsr.ValidaCantidadRutasUsuarios(mensaje) Then
            RaiseEvent Estado(Me, New SincronizacionSubidaMovilEstadoEventArgs(SincronizacionSubidaMovilEstadoEventArgs.EstadoEnum.Error, Metodo.ValidaLicenciaUsuarios, 0, 0))
            Throw New Exception(mensaje)
         End If
         '-------------------------------------------------------------------------------------------------------------

         Dim sucursales = New Sucursales().GetTodosParaSincronizarSegunIncluir(incluirSucursales).ConvertAll(Function(s) s.IdSucursal).ToArray()

         SubirRutas()
         SubirRutasClientes(incluirClientes)
         SubirClientes(nombreCliente, tipoDireccion, incluirClientes)

         'If Publicos.Simovil.Subida.IncluirCuentasCorrientes Then
         SubirConfiguraciones()
         'End If

         Dim puedeSubirCtaCte As Boolean = True
         Dim ejecucion As Entidades.JSonEntidades.CobranzasMovil.Temp_Ejecuciones = Nothing

         If Publicos.Simovil.Subida.IncluirCuentasCorrientes Or Publicos.Simovil.Subida.IncluirCuentasCorrientesDebeHaber Then
            If Publicos.Simovil.Subida.IncluirCuentasCorrientesDebeHaber Then
               Try
                  ejecucion = EjecutarProceso(Of Integer(), Entidades.JSonEntidades.CobranzasMovil.Temp_Ejecuciones)(Metodo.TempEjecucion_Nueva, sucursales)
                  '-- Inicia Borrado Bach de CuentasCorrientesDebeHaber.- ------------------------------------------------------------------------------------------
                  EjecutarProceso(Of Entidades.JSonEntidades.CobranzasMovil.Temp_Ejecuciones, Boolean)(Metodo.TempEjecucion_DBorrarCtasCtesDebeHaber, ejecucion)
                  '-------------------------------------------------------------------------------------------------------------------------------------------------
               Catch ex As Exception
                  ejecucion = Nothing
               End Try
            End If
            Dim cobranzasSinProcesar = ObtenerCobranzas(If(ejecucion IsNot Nothing, sucursales, Nothing))
            puedeSubirCtaCte = cobranzasSinProcesar.Count = 0
         End If

         If Publicos.Simovil.Subida.IncluirCuentasCorrientes Then
            If puedeSubirCtaCte Then
               SubirCuentasCorrientes()
            Else
               RaiseEvent Estado(Me, New SincronizacionSubidaMovilEstadoEventArgs(SincronizacionSubidaMovilEstadoEventArgs.EstadoEnum.Error, Metodo.CuentasCorrientes, 0, 0))
               Throw New Exception("No puede sincronizar la Cuenta Corriente porque existen cobranzas sin registrar")
            End If
         End If
         If Publicos.Simovil.Subida.IncluirCuentasCorrientesDebeHaber Then
            If puedeSubirCtaCte Then
               SubirCuentasCorrientesDebeHaber(ejecucion)
               If ejecucion IsNot Nothing Then
                  EjecutarProceso(Of Entidades.JSonEntidades.CobranzasMovil.Temp_Ejecuciones, Boolean)(Metodo.TempEjecucion_Finalizar, ejecucion)
                  '-- Inicia Borrado Bach de CuentasCorrientesDebeHaber.- ------------------------------------------------------------------------------------------
                  EjecutarProceso(Of Entidades.JSonEntidades.CobranzasMovil.Temp_Ejecuciones, Boolean)(Metodo.TempEjecucion_DBorrarCtasCtesDebeHaberTemp, ejecucion)
                  '-------------------------------------------------------------------------------------------------------------------------------------------------
               End If
            Else
               RaiseEvent Estado(Me, New SincronizacionSubidaMovilEstadoEventArgs(SincronizacionSubidaMovilEstadoEventArgs.EstadoEnum.Error, Metodo.CuentasCorrientesDebeHaber, 0, 0))
               Throw New Exception("No puede sincronizar la Cuenta Corriente Debe/Haber porque existen cobranzas sin registrar")
            End If
         End If
         If Publicos.Simovil.Subida.IncluirRubros Then
            SubirRubros()
         End If
         If Publicos.Simovil.Subida.IncluirProductos Then
            SubirProductos(exportarConIVA, soloProductosConStock)
         End If
         If Publicos.Simovil.Subida.IncluirProductosPrecios Then
            SubirProductosPrecios(exportarConIVA, soloProductosConStock)
            SubirRutasListasDePrecios()
         End If
         If Publicos.Simovil.Subida.IncluirProductosClientes Then
            SubirProductosClientes(incluirClientes, exportarConIVA, soloProductosConStock)
         End If
         If Publicos.Simovil.Subida.IncluirUsuarios Then
            SubirUsuarios()
         End If

         If Publicos.Simovil.Subida.IncluirCalendarios Then
            SubirCalendarios()
         End If
         If Publicos.Simovil.Subida.IncluirEmbarcaciones Then
            SubirEmbarcaciones()
         End If
         If Publicos.Simovil.Subida.IncluirDestinos Then
            SubirDestinos()
         End If

         RaiseEvent Avance(Me, New SincronizacionSubidaMovilEventArgs("Finalizando subida de información."))
      End Sub

      Private Sub SubirRutas()
         SubirIndividual(Metodo.Rutas, New Rutas().GetRutas(IdEmpresa), Publicos.Simovil.Subida.PaginaRutas)
      End Sub

      Private Sub SubirRutasClientes(incluirClientes As Clientes.IncluirClientes)
         SubirIndividual(Metodo.RutasClientes, New RutasClientes().GetRutasClientes(IdEmpresa, incluirClientes), Publicos.Simovil.Subida.PaginaRutasClientes)
      End Sub

      Private Sub SubirClientes(nombreCliente As Clientes.NombreCliente, tipoDireccion As Entidades.TipoDireccion, incluirClientes As Clientes.IncluirClientes)
         SubirIndividual(Metodo.Clientes, New Clientes().GetClientes(IdEmpresa, nombreCliente, tipoDireccion, incluirClientes), Publicos.Simovil.Subida.PaginaClientes)
      End Sub

      Private Sub SubirConfiguraciones()
         SubirIndividual(Metodo.EmpresasConfiguraciones, New EmpresasConfiguraciones().GetConfiguraciones(IdEmpresa))
      End Sub

      Private Sub SubirCuentasCorrientes()
         SubirIndividual(Metodo.CuentasCorrientes, New CuentasCorrientes().GetCuentasCorrientes(IdEmpresa), Publicos.Simovil.Subida.PaginaCuentasCorrientes)
      End Sub

      Private Sub SubirCuentasCorrientesDebeHaber(ejecucion As Entidades.JSonEntidades.CobranzasMovil.Temp_Ejecuciones)
         Dim datos = New CuentasCorrientes().GetCuentasCorrientesDebeHaber(IdEmpresa, ejecucion)
         Dim mthd = If(ejecucion Is Nothing, Metodo.CuentasCorrientesDebeHaber, Metodo.TempCuentasCorrientesDebeHaber)
         SubirIndividual(mthd, datos, Publicos.Simovil.Subida.PaginaCuentasCorrientesDebeHaber)
      End Sub

      Private Sub SubirRubros()
         SubirIndividual(Metodo.Rubros, New Rubros().GetRubros(IdEmpresa), Publicos.Simovil.Subida.PaginaRubros)
      End Sub
      Private Sub SubirProductos(exportarConIVA As Boolean, soloProductosConStock As Boolean)
         SubirIndividual(Metodo.Productos, New Productos().GetProductos(IdEmpresa, exportarConIVA, soloProductosConStock), Publicos.Simovil.Subida.PaginaProductos)
      End Sub
      Private Sub SubirProductosClientes(incluirClientes As Clientes.IncluirClientes, exportarConIVA As Boolean, soloProductosConStock As Boolean)
         SubirIndividual(Metodo.ProductosClientes, New ProductosClientes().GetProductosClientes(IdEmpresa, incluirClientes, exportarConIVA, soloProductosConStock), 100)
      End Sub
      Private Sub SubirProductosPrecios(exportarConIVA As Boolean, soloProductosConStock As Boolean)
         SubirIndividual(Metodo.ProductosPrecios, New ProductosPrecios().GetProductosPrecios(IdEmpresa, exportarConIVA, soloProductosConStock), Publicos.Simovil.Subida.PaginaProductosPrecios)
      End Sub
      Private Sub SubirRutasListasDePrecios()
         SubirIndividual(Metodo.RutasListasDePrecios, New RutasListasDePrecios().GetRutasListasDePrecios(IdEmpresa), Reglas.Publicos.Simovil.Subida.PaginaRutasListasPrecios)
      End Sub
      Private Sub SubirUsuarios()
         SubirIndividual(Metodo.Usuarios, New Usuarios().GetUsuarios(IdEmpresa))
      End Sub

      Public Sub SubirCalendarios()
         SubirIndividual(Metodo.Calendarios, New Calendarios().GetParaMovil(IdEmpresa))
      End Sub

      Public Sub SubirEmbarcaciones()
         SubirIndividual(Metodo.Embarcaciones, New Embarcaciones().GetParaMovil(IdEmpresa))
      End Sub
      Public Sub SubirDestinos()
         SubirIndividual(Metodo.Destinos, New Destinos().GetParaMovil(IdEmpresa))
      End Sub

      Public Sub ExportarArchivosEnviar(Of T)(metodo As Metodo, paginas As List(Of T()))

         If Publicos.Simovil.Subida.ExportarArchivosEnviar Then
            Dim idx = 0I
            paginas.ForEach(
            Sub(p)
               Dim arch = New FileInfo(Path.Combine(Publicos.Simovil.Subida.PathExportarArchivosEnviar, String.Format("{0}\{0}_{1:00000000}.json", metodo, idx)))
               If Not arch.Directory.Exists Then
                  arch.Directory.Create()
               End If

               Dim currentMax = serializer.MaxJsonLength

               Dim data = String.Empty
               Dim iLoop = 2I
               Dim ex1 As Exception = Nothing
               While iLoop < 10
                  Try
                     data = serializer.Serialize(p)
                     Exit While
                  Catch ex As Exception
                     serializer.MaxJsonLength = currentMax * (iLoop)
                     If ex1 Is Nothing Then
                        ex1 = ex
                     End If
                  End Try
               End While

               File.WriteAllText(arch.FullName, data)

               If ex1 IsNot Nothing Then
                  Throw New Exception(String.Format("Error serializando la página {1} de {0}. Se pudo serializar con MaxJsonLength = {2}: {3}",
                                                    metodo, idx, serializer.MaxJsonLength, ex1.Message), ex1)
               End If

               serializer.MaxJsonLength = currentMax
               idx += 1
            End Sub)
         End If
      End Sub

      Private Function EjecutarProceso(Of TData, TResult)(metodo As Metodo, data As TData) As TResult
         RaiseEvent Avance(Me, New SincronizacionSubidaMovilEventArgs(String.Format("Ejecutando proceso {0}.", metodo.ToString())))

         Try
            Dim archWeb = New Archivos.BaseArchivosWeb(Of TData)()

            Dim headers As HeadersDictionary = New HeadersDictionary().AgregarEmpresa(IdEmpresa).AgregarVersion()

            Dim uri As Uri = New Uri(BaseUri, metodo.ToString().Replace("_", "/"))

            Return archWeb.Post(Of TResult)(data, uri.ToString(), headers, binario:=False)
         Catch ex As System.Net.WebException
            'RaiseEvent Estado(Me, New SincronizacionSubidaMovilEstadoEventArgs(SincronizacionSubidaMovilEstadoEventArgs.EstadoEnum.Error, metodo, lista.Count, lista.Count))
            NetExceptionHelper.NetExceptionHandler(ex)
         End Try
         Return Nothing
      End Function

      Private Sub SubirIndividual(Of T)(metodo As Metodo, lista As List(Of T), Optional tamanoPagina As Integer = Integer.MaxValue)
         RaiseEvent Avance(Me, New SincronizacionSubidaMovilEventArgs(String.Format("Subiendo información de {0}.", metodo.ToString())))

         Try
            Dim archWeb As New Archivos.BaseArchivosWeb(Of T)()

            Dim headers As HeadersDictionary = New HeadersDictionary().AgregarEmpresa(IdEmpresa).AgregarVersion()

            Dim uri As Uri = New Uri(BaseUri, metodo.ToString())

            If metodo = SincronizacionSubidaMovil.Metodo.Calendarios Or metodo = SincronizacionSubidaMovil.Metodo.Embarcaciones Or metodo = SincronizacionSubidaMovil.Metodo.Destinos Then
               uri = New Uri(BaseUriTurnos, metodo.ToString())
            Else
               uri = New Uri(BaseUri, metodo.ToString())
            End If

            RaiseEvent Avance(Me, New SincronizacionSubidaMovilEventArgs(String.Format("Subiendo información de {0}.", metodo.ToString()), "DELETE", uri))
            archWeb.Delete(uri.ToString(), headers)
            RaiseEvent Avance(Me, New SincronizacionSubidaMovilEventArgs(String.Format("Subiendo información de {0}.", metodo.ToString()), "POST", uri))
            RaiseEvent Estado(Me, New SincronizacionSubidaMovilEstadoEventArgs(SincronizacionSubidaMovilEstadoEventArgs.EstadoEnum.Iniciando, metodo, lista.Count, 0))
            Dim paginas As List(Of T()) = PaginarDatos(lista, tamanoPagina)

            ExportarArchivosEnviar(metodo, paginas)

            Dim countRegistros As Integer = 0
            For Each pagina As T() In paginas
               archWeb.Post(pagina, uri.ToString(), headers, binario:=False)
               countRegistros += pagina.Count
               RaiseEvent Estado(Me, New SincronizacionSubidaMovilEstadoEventArgs(SincronizacionSubidaMovilEstadoEventArgs.EstadoEnum.Subiendo, metodo, lista.Count, countRegistros))
            Next
            RaiseEvent Estado(Me, New SincronizacionSubidaMovilEstadoEventArgs(SincronizacionSubidaMovilEstadoEventArgs.EstadoEnum.Finalizado, metodo, lista.Count, countRegistros))

         Catch ex As System.Net.WebException
            RaiseEvent Estado(Me, New SincronizacionSubidaMovilEstadoEventArgs(SincronizacionSubidaMovilEstadoEventArgs.EstadoEnum.Error, metodo, lista.Count, lista.Count))
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


      'Private Function GetResponseMessage(response As WebResponse) As String
      '   Dim strErrorResponse As String
      '   Using stm As Stream = response.GetResponseStream()
      '      Using sr As New StreamReader(stm)
      '         strErrorResponse = sr.ReadToEnd()
      '      End Using
      '   End Using
      '   Return strErrorResponse
      'End Function

      'Private Sub NetExceptionHandler(ex As System.Net.WebException)
      '   Dim errorResponse As ErrorResponse = Nothing
      '   Try
      '      If TypeOf (ex.Response) Is HttpWebResponse AndAlso DirectCast(ex.Response, HttpWebResponse).StatusCode = HttpStatusCode.BadRequest Then
      '         errorResponse = TryCast(New JavaScriptSerializer().Deserialize(GetResponseMessage(ex.Response), GetType(ErrorResponse)), ErrorResponse)
      '      ElseIf TypeOf (ex.Response) Is HttpWebResponse AndAlso DirectCast(ex.Response, HttpWebResponse).StatusCode = HttpStatusCode.InternalServerError Then
      '         Dim strErrorResponse As String = GetResponseMessage(ex.Response)

      '         Try
      '            Dim Mensaje As String
      '            Mensaje = String.Format("{3} {0}Método {1} {2}{0}{0}Excepcion WebService: {0}{4}",
      '                                    Environment.NewLine,
      '                                    DirectCast(ex.Response, HttpWebResponse).Method,
      '                                    DirectCast(ex.Response, HttpWebResponse).ResponseUri,
      '                                    ex.Message,
      '                                    strErrorResponse)
      '            My.Application.Log.WriteEntry(Mensaje, TraceEventType.Error)
      '         Catch
      '         End Try


      '      End If         'If ex.Response.StatusCode = HttpStatusCode.BadRequest Then
      '   Catch innerEx As Exception
      '      Throw New BadRequestMessageDeserializeException(innerEx, ex)
      '   End Try

      '   If errorResponse IsNot Nothing Then
      '      Throw New Exception(String.Format("{0} - {1}", errorResponse.CodigoError, errorResponse.MensajeError), ex)
      '   Else
      '      Throw ex
      '   End If
      'End Sub


      Public Enum Metodo
         Clientes
         EmpresasConfiguraciones
         CuentasCorrientes
         CuentasCorrientesDebeHaber
         Rutas
         RutasClientes
         RutasListasDePrecios
         Rubros
         Productos
         ProductosPrecios
         ProductosClientes
         Cobranzas
         CobranzasPendientes
         Usuarios
         '-- 
         ValidaLicenciaUsuarios

         Calendarios
         Embarcaciones
         Destinos

         TempEjecucion_DBorrarCtasCtesDebeHaber
         TempEjecucion_DBorrarCtasCtesDebeHaberTemp

         TempCuentasCorrientesDebeHaber
         TempEjecucion_Nueva
         TempEjecucion_Finalizar
      End Enum

      Public Class SincronizacionSubidaMovilEventArgs
         Inherits EventArgs
         Public Sub New(mensaje As String)
            Me.Mensaje = mensaje
         End Sub
         Public Sub New(mensaje As String, metodo As String, url As Uri)
            Me.New(mensaje)
            Me.Metodo = metodo
            Me.Url = url
         End Sub
         Public Sub New(mensaje As String, metodo As String, url As Uri, tabla As Metodo, totalRegistrosSubidos As Long)
            Me.New(mensaje, metodo, url)
            Me.Tabla = tabla
            Me.TotalRegistrosSubidos = totalRegistrosSubidos
         End Sub
         Public Property Mensaje As String
         Public Property Metodo As String
         Public Property Url As Uri
         Public Property Tabla As Metodo
         Public Property TotalRegistrosSubidos As Long
      End Class
      Public Class SincronizacionSubidaMovilEstadoEventArgs
         Inherits EventArgs
         Public Enum EstadoEnum
            Iniciando
            Subiendo
            Finalizado
            [Error]
         End Enum
         Public Sub New(estado As EstadoEnum, metodo As Metodo, totalRegistros As Long, totalRegistrosSubidos As Long)
            Me.Estado = estado
            Me.Metodo = metodo
            Me.TotalRegistros = totalRegistros
            Me.TotalRegistrosSubidos = totalRegistrosSubidos
         End Sub
         Public Property Estado As EstadoEnum
         Public Property Metodo As Metodo
         Public Property TotalRegistros As Long
         Public Property TotalRegistrosSubidos As Long
      End Class

      'Public Class ErrorResponse
      '   Public Property CodigoError As Integer
      '   Public Property MensajeError As String
      'End Class

      'Public Class BadRequestMessageDeserializeException
      '   Inherits Exception
      '   Public Sub New(ex As Exception, exWeb As WebException)
      '      MyBase.New(String.Format("Error obteniendo el mensaje de error del BadReques: {0}", ex.Message), ex)
      '      InnerExceptionWeb = exWeb
      '   End Sub

      '   Public Property InnerExceptionWeb As WebException

      'End Class

      Public Function GetInfoParaVinculacion() As String
         Return GetInfoParaVinculacion(IdEmpresa, NombreEmpresa, CuitEmpresa, NombreUsuario)
      End Function
      Public Function GetInfoParaVinculacion(codigoCliente As Long, nombreCliente As String, cuitCliente As String, nombreUsuario As String) As String
         Dim info = New With {.BaseURL = BaseUri,
                              .CodigoEmpresa = codigoCliente,
                              .NombreEmpresa = nombreCliente,
                              .Cuit = cuitCliente,
                              .NombreUsuario = nombreUsuario,
                              .IdUsuario = IdUsuario}
         Return New JavaScriptSerializer().Serialize(info)
      End Function

   End Class
End Namespace