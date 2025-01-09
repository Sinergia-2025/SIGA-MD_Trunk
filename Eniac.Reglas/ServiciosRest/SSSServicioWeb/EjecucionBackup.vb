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
   Public Class EjecucionBackup
      Inherits EjecucionBase
      Public Sub New(baseUri As String)
         MyBase.New(baseUri, "BACKUP")
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
               Dim bajarTablas As Boolean = True
               OnAvanceImportarAutomaticamente(String.Format("Procesando cliente {0} - Servidor {1} - Base {2}", cliente.CodigoCliente, cliente.NombreServidor, cliente.BaseDatos))
               For Each ejecucion As Entidades.JSonEntidades.SSSServicioWeb.Ejecuciones In cliente.EjecucionesCliente
                  If bajarTablas Then
                     OnAvanceImportarAutomaticamente(String.Format("Obteniendo lista de sucesos del cliente {0} - Servidor {1} - Base {2}", cliente.CodigoCliente, cliente.NombreServidor, cliente.BaseDatos))
                     Dim sucesos As List(Of Entidades.JSonEntidades.SSSServicioWeb.Sucesos) = ObtenerSucesosDeEjecucion(ejecucion)
                     For Each suceso As Entidades.JSonEntidades.SSSServicioWeb.Sucesos In sucesos
                        If suceso.TipoSuceso = Entidades.JSonEntidades.SSSServicioWeb.TipoSuceso.Dispositivos Then
                           OnAvanceImportarAutomaticamente(String.Format("Importando dispositivos del cliente {0} - Servidor {1} - Base {2}", cliente.CodigoCliente, cliente.NombreServidor, cliente.BaseDatos))
                           ImportarDispositivos(suceso)
                        ElseIf suceso.TipoSuceso = Entidades.JSonEntidades.SSSServicioWeb.TipoSuceso.Parametros Then
                           OnAvanceImportarAutomaticamente(String.Format("Importando parametros del cliente {0} - Servidor {1} - Base {2}", cliente.CodigoCliente, cliente.NombreServidor, cliente.BaseDatos))
                           ImportarParametros(suceso)
                        ElseIf suceso.TipoSuceso = Entidades.JSonEntidades.SSSServicioWeb.TipoSuceso.VersionBaseDatos Then
                           OnAvanceImportarAutomaticamente(String.Format("Importando Version Base de Datos del cliente {0} - Servidor {1} - Base {2}", cliente.CodigoCliente, cliente.NombreServidor, cliente.BaseDatos))
                           ImportarParametro(suceso, "VERSIONMOTORBD")
                        ElseIf suceso.TipoSuceso = Entidades.JSonEntidades.SSSServicioWeb.TipoSuceso.VersionProcesoBackup Then
                           OnAvanceImportarAutomaticamente(String.Format("Importando versión de backup del cliente {0} - Servidor {1} - Base {2}", cliente.CodigoCliente, cliente.NombreServidor, cliente.BaseDatos))
                           ImportarParametro(suceso, "VERSIONBACKUP")
                        End If

                        bajarTablas = False
                     Next
                     ActualizarClienteDesdeParametrosClientes(ejecucion.CodigoCliente)
                  End If
                  OnAvanceImportarAutomaticamente(String.Format("Grabando la ejeción del día {3} del Cliente {0} - Servidor {1} - Base {2}", cliente.CodigoCliente, cliente.NombreServidor, cliente.BaseDatos, ejecucion.FechaEjecucion))
                  GrabarEjecucion(ejecucion)
               Next
            Else
               OnAvanceImportarAutomaticamente(String.Format("ERROR: No existe Cliente con código {0}", cliente.CodigoCliente))
               Threading.Thread.Sleep(1000)
            End If         'If cache.ExisteClientePorIdRapido(cliente.CodigoCliente) Then
         Next
      End Sub

      Private Sub ImportarDispositivos(suceso As Entidades.JSonEntidades.SSSServicioWeb.Sucesos)
         Dim datos As String = suceso.Datos
         Dim lista As List(Of Entidades.JSonEntidades.SSSServicioWeb.Dispositivo)

         Dim serializer As New System.Web.Script.Serialization.JavaScriptSerializer()
         lista = serializer.Deserialize(Of List(Of Entidades.JSonEntidades.SSSServicioWeb.Dispositivo))(datos)

         Dim rCD As ClientesDispositivos = New ClientesDispositivos()
         rCD.ImportarDesdeJson(suceso.CodigoCliente, suceso.NombreServidor, suceso.BaseDatos, lista.ToArray())
      End Sub

      Private Sub ImportarParametros(suceso As Entidades.JSonEntidades.SSSServicioWeb.Sucesos)
         Dim datos As String = suceso.Datos
         Dim lista As List(Of Entidades.JSonEntidades.SSSServicioWeb.Parametro)

         Dim serializer As New System.Web.Script.Serialization.JavaScriptSerializer()
         lista = serializer.Deserialize(Of List(Of Entidades.JSonEntidades.SSSServicioWeb.Parametro))(datos)

         Dim rCD As ClientesParametros = New ClientesParametros()
         rCD.ImportarDesdeJson(suceso.CodigoCliente, suceso.NombreServidor, suceso.BaseDatos, lista.ToArray())
      End Sub

      Private Sub ImportarParametro(suceso As Entidades.JSonEntidades.SSSServicioWeb.Sucesos, idParametro As String)
         Dim datos As String = suceso.Datos
         Dim lista As List(Of String)

         Dim serializer As New System.Web.Script.Serialization.JavaScriptSerializer()
         lista = serializer.Deserialize(Of List(Of String))(datos)

         Dim rCD As ClientesParametros = New ClientesParametros()
         rCD.ImportarDesdeJson(suceso.CodigoCliente, suceso.NombreServidor, suceso.BaseDatos, idParametro, lista(0))
      End Sub

      Private Sub GrabarEjecucion(ejecucion As Entidades.JSonEntidades.SSSServicioWeb.Ejecuciones)
         Dim rCD As ClientesBackups = New ClientesBackups()
         rCD.ImportarDesdeJson(ejecucion)

         MarcarEjecucion(ejecucion)
      End Sub

      Private Sub ActualizarClienteDesdeParametrosClientes(codigoCliente As Long)
         Dim rCD As ClientesParametros = New ClientesParametros()
         rCD.ActualizarCliente(codigoCliente)
      End Sub

   End Class

End Namespace