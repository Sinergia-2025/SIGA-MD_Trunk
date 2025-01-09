#Region "Option/Imports"
Option Strict On
Option Explicit On
Option Infer On
Imports System.Net
Imports System.IO
Imports System.Web.Script.Serialization
Imports actual = Eniac.Entidades.Usuario.Actual
#End Region
Namespace ServiciosRest.Turismo
   Public Class SincronizacionSubidaMovilTurismo
      Inherits SincronizacionBase

      'Private Property IdEmpresa As Integer
      'Private Property BaseUri As Uri

      Private Property NombreEmpresa As String
      Private Property CuitEmpresa As String
      Private Property IdUsuario As String
      Private Property NombreUsuario As String

      'Public Event Avance(sender As Object, e As SincronizacionSubidaMovilEventArgs)
      'Public Event Estado(sender As Object, e As SincronizacionSubidaMovilEstadoEventArgs)

      Public Sub New()
         MyBase.New(Publicos.SimovilTurismoURLBase)
         'MyBase.New("http://sinergiamovil.com.ar/simovil.turismo/api/")
         'MyBase.New("http://localhost:5404/api/")
         ''IdEmpresa = 235
         'Dim codigoClienteSinergia As String = Publicos.CodigoClienteSinergia
         'If Not IsNumeric(codigoClienteSinergia) Then
         '   Throw New Exception("No está configurado el Codigo de Empresa.")
         'End If
         'IdEmpresa = Integer.Parse(codigoClienteSinergia)
         'Dim simovilURLBase As String = Publicos.SimovilTurismoURLBase
         'If String.IsNullOrWhiteSpace(simovilURLBase) Then
         '   Throw New Exception("No está configurado la URL Base para Simovil Turismo.")
         'End If
         'BaseUri = New Uri(simovilURLBase)
         'BaseUri = New Uri("http://sinergiamovil.com.ar/simovil.turismo/api/")
         'BaseUri = New Uri("http://localhost:5404/api/")

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
            BaseUri = String.Concat(BaseUri, "/")
         End If
         Return GetVersion(New Uri(BaseUri))
      End Function
      Public Function GetVersion(BaseUri As Uri) As String
         OnAvance("Obteniendo número de versión")

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
            Throw ex
         End Try

      End Function

      Public Function GetFechaUltimaSincronizacion() As DateTime?
         OnAvance("Obteniendo Fecha de Última Sincronización")

         Dim uri As Uri = New Uri(BaseUri, "FechaUltimaSincronizacion")

         Dim wc As New WebClient()
         wc.Headers.Add(HeadersDictionary.Headers.IdEmpresa.ToString(), IdEmpresa.ToString())
         Try
            Using orResult As System.IO.Stream = wc.OpenRead(uri)
               Using reader As StreamReader = New StreamReader(orResult, New System.Text.UTF8Encoding())
                  Dim responseString As String = reader.ReadToEnd()
                  Dim result As DateTime?
                  Try
                     result = DateTime.ParseExact(responseString.Trim(""""c), Entidades.JSonEntidades.AyudanteJson.FormatoFechas, Nothing, Globalization.DateTimeStyles.None)
                  Catch ex As Exception
                     result = Nothing
                  End Try
                  Return result
               End Using
            End Using
         Catch ex As WebException
            Throw ex
         End Try

      End Function

      Public Enum AccionSincronizacion
         Subir
         Descargar
         SubirDescargar
      End Enum

      Public Sub SubirInformacion(nombreCliente As CobranzasMovil.Clientes.NombreCliente, tipoDireccion As Entidades.TipoDireccion, incluirClientes As CobranzasMovil.Clientes.IncluirClientes,
                                  accion As AccionSincronizacion)
         OnAvance("Comenzando subida de información")
         If accion = AccionSincronizacion.Subir Or accion = AccionSincronizacion.SubirDescargar Then
            SubirIndividual("Curso", New Cursos().Get(IdEmpresa))
            SubirIndividual("FormaPago", New FormasPago().Get(IdEmpresa))
            SubirIndividual("TipoVehiculo", New TiposVehiculos().Get(IdEmpresa))
            SubirIndividual("Turno", New Turnos().Get(IdEmpresa))
            SubirIndividual("Usuario", New Usuarios().Get(IdEmpresa))

            SubirIndividual("Establecimiento", New Establecimientos().Get(IdEmpresa, nombreCliente, tipoDireccion, incluirClientes))
            SubirIndividual("Programa", New Programas().Get(IdEmpresa))
         End If
         If accion = AccionSincronizacion.Descargar Or accion = AccionSincronizacion.SubirDescargar Then
            Dim rSubida = New SolicitudesReserva(BaseUri)
            AddHandler rSubida.AvanceImportarAutomaticamente, Sub(sender, e) OnAvance(e.Etapa)
            rSubida.ImportarAutomaticamente()
         End If

         OnAvance("Finalizando subida de información.")
      End Sub

      'Private Sub SubirIndividual(Of T)(metodo As Metodo, lista As List(Of T), Optional tamanoPagina As Integer = Integer.MaxValue)
      '   RaiseEvent Avance(Me, New SincronizacionSubidaMovilEventArgs(String.Format("Subiendo información de {0}.", metodo.ToString())))

      '   Try
      '      Dim archWeb As New Archivos.BaseArchivosWeb(Of T)()

      '      Dim headers As HeadersDictionary = New HeadersDictionary().AgregarEmpresa(IdEmpresa).AgregarVersion()

      '      Dim uri As Uri = New Uri(BaseUri, metodo.ToString())

      '      RaiseEvent Avance(Me, New SincronizacionSubidaMovilEventArgs(String.Format("Subiendo información de {0}.", metodo.ToString()), "DELETE", uri))
      '      archWeb.Delete(uri.ToString(), headers)
      '      RaiseEvent Avance(Me, New SincronizacionSubidaMovilEventArgs(String.Format("Subiendo información de {0}.", metodo.ToString()), "POST", uri))
      '      RaiseEvent Estado(Me, New SincronizacionSubidaMovilEstadoEventArgs(SincronizacionSubidaMovilEstadoEventArgs.EstadoEnum.Iniciando, metodo, lista.Count, 0))
      '      Dim paginas As List(Of T()) = PaginarDatos(lista, tamanoPagina)
      '      Dim countRegistros As Integer = 0
      '      For Each pagina As T() In paginas
      '         archWeb.Post(pagina, uri.ToString(), headers, binario:=False)
      '         countRegistros += pagina.Count
      '         RaiseEvent Estado(Me, New SincronizacionSubidaMovilEstadoEventArgs(SincronizacionSubidaMovilEstadoEventArgs.EstadoEnum.Subiendo, metodo, lista.Count, countRegistros))
      '      Next
      '      RaiseEvent Estado(Me, New SincronizacionSubidaMovilEstadoEventArgs(SincronizacionSubidaMovilEstadoEventArgs.EstadoEnum.Finalizado, metodo, lista.Count, countRegistros))

      '   Catch ex As System.Net.WebException
      '      RaiseEvent Estado(Me, New SincronizacionSubidaMovilEstadoEventArgs(SincronizacionSubidaMovilEstadoEventArgs.EstadoEnum.Error, metodo, lista.Count, lista.Count))
      '      NetExceptionHelper.NetExceptionHandler(ex)
      '   End Try
      'End Sub

      'Private Function PaginarDatos(Of T)(datos As List(Of T), registrosPorPagina As Integer) As List(Of T())
      '   Dim result As List(Of T()) = New List(Of T())
      '   Dim posicion As Integer = 0
      '   While posicion < datos.Count
      '      Dim pagina(Math.Min(datos.Count - posicion, registrosPorPagina) - 1) As T
      '      datos.CopyTo(posicion, pagina, 0, Math.Min(datos.Count - posicion, registrosPorPagina))
      '      result.Add(pagina)
      '      posicion += registrosPorPagina
      '   End While
      '   Return result
      'End Function

      'Public Enum Metodo
      '   Curso
      '   FormaPago
      '   TipoVehiculo
      '   Turno
      '   Usuario
      '   Establecimiento
      '   Programa
      '   SolicitudReserva
      'End Enum

      'Public Class SincronizacionSubidaMovilEventArgs
      '   Inherits EventArgs
      '   Public Sub New(mensaje As String)
      '      Me.Mensaje = mensaje
      '   End Sub
      '   Public Sub New(mensaje As String, metodo As String, url As Uri)
      '      Me.New(mensaje)
      '      Me.Metodo = metodo
      '      Me.Url = url
      '   End Sub
      '   Public Sub New(mensaje As String, metodo As String, url As Uri, tabla As Metodo, totalRegistrosSubidos As Long)
      '      Me.New(mensaje, metodo, url)
      '      Me.Tabla = tabla
      '      Me.TotalRegistrosSubidos = totalRegistrosSubidos
      '   End Sub
      '   Public Property Mensaje As String
      '   Public Property Metodo As String
      '   Public Property Url As Uri
      '   Public Property Tabla As Metodo
      '   Public Property TotalRegistrosSubidos As Long
      'End Class
      'Public Class SincronizacionSubidaMovilEstadoEventArgs
      '   Inherits EventArgs
      '   Public Enum EstadoEnum
      '      Iniciando
      '      Subiendo
      '      Finalizado
      '      [Error]
      '   End Enum
      '   Public Sub New(estado As EstadoEnum, metodo As Metodo, totalRegistros As Long, totalRegistrosSubidos As Long)
      '      Me.Estado = estado
      '      Me.Metodo = metodo
      '      Me.TotalRegistros = totalRegistros
      '      Me.TotalRegistrosSubidos = totalRegistrosSubidos
      '   End Sub
      '   Public Property Estado As EstadoEnum
      '   Public Property Metodo As Metodo
      '   Public Property TotalRegistros As Long
      '   Public Property TotalRegistrosSubidos As Long
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