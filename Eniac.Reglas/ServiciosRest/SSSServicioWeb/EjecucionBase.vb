#Region "Option/Imports"
Option Strict On
Option Explicit On
Option Infer On

Imports Eniac.Reglas.ServiciosRest.CobranzasMovil
Imports System.Net
Imports System.IO
Imports Eniac.Reglas.ServiciosRest.CobranzasMovil.SincronizacionSubidaMovil
Imports System.Web.Script.Serialization
#End Region
Namespace ServiciosRest.SSSServicioWeb
   Public MustInherit Class EjecucionBase
      'Public Const BaseUriLegacy As String = "http://wi531792.ferozo.com/SSSServicioWeb/api/"
      Public Const BaseUriActual As String = "http://sinergiamovil.com.ar/SSSServicioWeb/api/"

      Private Property IdEmpresa As Integer
      Private Property BaseUri As Uri
      Private Property TipoEjecucion As String

      Public Event Avance(sender As Object, e As SincronizacionSubidaMovil.SincronizacionSubidaMovilEventArgs)

      Public Sub New(baseUri As String, tipoEjecucion As String)
         'IdEmpresa = 235
         Dim codigoClienteSinergia As String = Publicos.CodigoClienteSinergia
         If Not IsNumeric(codigoClienteSinergia) Then
            Throw New Exception("No está configurado el Codigo de Empresa.")
         End If
         IdEmpresa = Integer.Parse(codigoClienteSinergia)
         Dim simovilCobranzaURLBase As String = Publicos.SimovilCobranzaURLBase
         'If String.IsNullOrWhiteSpace(simovilCobranzaURLBase) Then
         '   Throw New Exception("No está configurado la URL Base para Simovil Cobranza.")
         'End If
         'BaseUri = New Uri(simovilCobranzaURLBase)
         'BaseUri = New Uri("http://localhost:63717/api/")
         'BaseUri = New Uri("http://wi531792.ferozo.com/SSSServicioWeb/api/")
         Me.TipoEjecucion = tipoEjecucion
         Me.BaseUri = New Uri(baseUri)
      End Sub

      Public Function ObtenerEjecucion() As List(Of Entidades.JSonEntidades.SSSServicioWeb.Ejecuciones)
         Try

            Dim archWeb As New Archivos.BaseArchivosWeb(Of Entidades.JSonEntidades.SSSServicioWeb.Ejecuciones)()

            Dim headers As HeadersDictionary = New HeadersDictionary().AgregarEmpresa(IdEmpresa).AgregarVersion()

            Dim uri As Uri = New Uri(New Uri(BaseUri, Metodo.Ejecuciones.ToString()), String.Format("?tipoEjecucion={0}", TipoEjecucion))

            RaiseEvent Avance(Me, New SincronizacionSubidaMovil.SincronizacionSubidaMovilEventArgs(String.Format("Subiendo información de {0}.", Metodo.Ejecuciones.ToString()),
                                                                         "GET", uri))

            Dim result As List(Of Entidades.JSonEntidades.SSSServicioWeb.Ejecuciones)
            result = archWeb.Get(uri.ToString(), 0, Integer.MaxValue, Today, headers)

            For Each ejec As Entidades.JSonEntidades.SSSServicioWeb.Ejecuciones In result
               ejec.FechaEjecucion = ejec.FechaEjecucion.AddHours(-3)
               If ejec.FechaInicio.HasValue Then ejec.FechaInicio = ejec.FechaInicio.Value.AddHours(-3)
               If ejec.FechaFinalizacion.HasValue Then ejec.FechaFinalizacion = ejec.FechaFinalizacion.Value.AddHours(-3)
               If ejec.FechaDescarga.HasValue Then ejec.FechaDescarga = ejec.FechaDescarga.Value.AddHours(-3)
               If ejec.FechaProceso.HasValue Then ejec.FechaProceso = ejec.FechaProceso.Value.AddHours(-3)
            Next

            Return result
         Catch ex As System.Net.WebException
            NetExceptionHelper.NetExceptionHandler(ex)
            Return Nothing
         End Try
      End Function

      Public Function ObtenerSucesosDeEjecucion(ejecucion As Entidades.JSonEntidades.SSSServicioWeb.Ejecuciones) As List(Of Entidades.JSonEntidades.SSSServicioWeb.Sucesos)
         Try

            Dim archWeb As New Archivos.BaseArchivosWeb(Of Entidades.JSonEntidades.SSSServicioWeb.Sucesos)()

            Dim headers As HeadersDictionary = New HeadersDictionary().AgregarEmpresa(IdEmpresa).AgregarVersion()

            Dim uri As Uri = New Uri(BaseUri, String.Format("{0}/{1}", Metodo.Sucesos.ToString(), ejecucion.IdUnico))

            RaiseEvent Avance(Me, New SincronizacionSubidaMovil.SincronizacionSubidaMovilEventArgs(String.Format("Subiendo información de {0}.", Metodo.Ejecuciones.ToString()),
                                                                         "GET", uri))

            Dim result As List(Of Entidades.JSonEntidades.SSSServicioWeb.Sucesos)
            result = archWeb.Get(uri.ToString(), 0, Integer.MaxValue, Today, headers)

            For Each suc As Entidades.JSonEntidades.SSSServicioWeb.Sucesos In result
               suc.FechaEjecucion = suc.FechaEjecucion.AddHours(-3)
            Next

            Return result
         Catch ex As System.Net.WebException
            NetExceptionHelper.NetExceptionHandler(ex)
            Return Nothing
         End Try
      End Function

      Public Sub MarcarEjecucion(ejecucion As Entidades.JSonEntidades.SSSServicioWeb.Ejecuciones)
         RaiseEvent Avance(Me, New SincronizacionSubidaMovilEventArgs(String.Format("Actualizando información de {0}.", Metodo.Ejecuciones.ToString())))

         Try
            Dim archWeb As New Archivos.BaseArchivosWeb(Of Entidades.JSonEntidades.SSSServicioWeb.Ejecuciones)()

            Dim headers As HeadersDictionary = New HeadersDictionary().AgregarEmpresa(IdEmpresa).AgregarVersion()

            Dim uri As Uri = New Uri(BaseUri, Metodo.Ejecuciones.ToString())

            RaiseEvent Avance(Me, New SincronizacionSubidaMovilEventArgs(String.Format("Actualizando información de {0}.", Metodo.Ejecuciones.ToString()),
                                                                         "PUT", uri))
            archWeb.Put(ejecucion, uri.ToString(), headers)
         Catch ex As System.Net.WebException
            NetExceptionHelper.NetExceptionHandler(ex)
         End Try
      End Sub

      Public Event AvanceImportarAutomaticamente(sender As Object, e As AvanceImportarAutomaticamenteEventArgs)
      Protected Overridable Sub OnAvanceImportarAutomaticamente(etapa As String)
         RaiseEvent AvanceImportarAutomaticamente(Me, New AvanceImportarAutomaticamenteEventArgs(etapa))
      End Sub
      Public Class AvanceImportarAutomaticamenteEventArgs
         Inherits EventArgs
         Public Property Etapa As String
         Public Sub New(etapa As String)
            Me.Etapa = etapa
         End Sub
      End Class
      Public Sub ImportarAutomaticamente()
         Dim ejecuciones As List(Of Entidades.JSonEntidades.SSSServicioWeb.Ejecuciones)
         OnAvanceImportarAutomaticamente("Obteniendo Ejecuciones de la web")
         ejecuciones = ObtenerEjecucion()

         ProcesarEjecuciones(ejecuciones)
      End Sub

      Protected MustOverride Sub ProcesarEjecuciones(ejecuciones As List(Of Entidades.JSonEntidades.SSSServicioWeb.Ejecuciones))

      Private Enum Metodo
         Ejecuciones
         Sucesos
      End Enum
   End Class

End Namespace