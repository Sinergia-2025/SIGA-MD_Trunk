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
   Public Class EjecucionActualizador
      Inherits EjecucionBase
      Public Sub New(baseUri As String)
         MyBase.New(baseUri, "ACTUALIZADOR")
      End Sub

      Protected Overrides Sub ProcesarEjecuciones(ejecuciones As List(Of Entidades.JSonEntidades.SSSServicioWeb.Ejecuciones))
         OnAvanceImportarAutomaticamente("Procesando lista de clientes")
         Dim clientes = (From e In ejecuciones
                         Order By e.CodigoCliente, e.NombreServidor, e.BaseDatos, e.FechaEjecucion Descending
                         Group By e.CodigoCliente, e.NombreServidor, e.BaseDatos
                         Into EjecucionesCliente = Group).ToList()

         Dim cache As BusquedasCacheadas = New BusquedasCacheadas()
         OnAvanceImportarAutomaticamente("Preparando cache de clientes")
         cache.ExisteClientePorCodigoRapido(-1)
         For Each cliente In clientes
            If cache.ExisteClientePorCodigoRapido(cliente.CodigoCliente) Then
               'Dim bajarTablas As Boolean = True
               OnAvanceImportarAutomaticamente(String.Format("Procesando cliente {0} - Servidor {1} - Base {2}", cliente.CodigoCliente, cliente.NombreServidor, cliente.BaseDatos))
               For Each ejecucion As Entidades.JSonEntidades.SSSServicioWeb.Ejecuciones In cliente.EjecucionesCliente
                  'If bajarTablas Then
                  OnAvanceImportarAutomaticamente(String.Format("Obteniendo lista de sucesos del cliente {0} - Servidor {1} - Base {2}", cliente.CodigoCliente, cliente.NombreServidor, cliente.BaseDatos))
                  Dim sucesos As List(Of Entidades.JSonEntidades.SSSServicioWeb.Sucesos) = ObtenerSucesosDeEjecucion(ejecucion)
                  GrabarEjecucion(ejecucion, sucesos)
               Next
            Else
               OnAvanceImportarAutomaticamente(String.Format("ERROR: No existe Cliente con código {0}", cliente.CodigoCliente))
               Threading.Thread.Sleep(1000)
            End If         'If cache.ExisteClientePorIdRapido(cliente.CodigoCliente) Then
         Next

      End Sub

      Public Sub GrabarEjecucion(ejecucion As Entidades.JSonEntidades.SSSServicioWeb.Ejecuciones, sucesos As List(Of Entidades.JSonEntidades.SSSServicioWeb.Sucesos))
         Dim rCD As ClientesActualizaciones = New ClientesActualizaciones()
         rCD.ImportarDesdeJson(ejecucion, sucesos)

         'MarcarEjecucion(ejecucion)
      End Sub

   End Class
End Namespace