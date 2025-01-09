Option Strict On
Option Explicit On
Option Infer On
Namespace ServiciosRest.Sincronizacion.CRM
   Public Class SyncCRMEstadosNovedades
      Inherits SyncBase(Of Entidades.JSonEntidades.Archivos.CRM.CRMEstadoNovedadJSonTransporte, Entidades.JSonEntidades.Archivos.CRM.CRMEstadoNovedadJSon)

      Public Sub New()
         MyBase.New(Publicos.WebArchivos.CRM.SyncConfigSyncEstados)
      End Sub

      Public Function InicializaDatos(esReenvio As Boolean, esRecibirTotdo As Boolean) As ISyncBase
         Return Inicializar(Function(fechaActualizacion) New CRMEstadosNovedades().GetTransporte(),
                            Function() Publicos.WebArchivos.CRM.FechaUltimaDescarga.CRMEstadosNovedades,
                            Function() New CRMEstadosNovedades(),
                            esReenvio, esRecibirTotdo)
      End Function

   End Class
End Namespace