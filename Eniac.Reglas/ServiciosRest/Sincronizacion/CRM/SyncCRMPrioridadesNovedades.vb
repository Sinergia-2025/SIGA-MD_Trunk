Option Strict On
Option Explicit On
Option Infer On
Namespace ServiciosRest.Sincronizacion.CRM
   Public Class SyncCRMPrioridadesNovedades
      Inherits SyncBase(Of Entidades.JSonEntidades.Archivos.CRM.CRMPrioridadNovedadJSonTransporte, Entidades.JSonEntidades.Archivos.CRM.CRMPrioridadNovedadJSon)

      Public Sub New()
         MyBase.New(Publicos.WebArchivos.CRM.SyncConfigSyncPrioridades)
      End Sub

      Public Function InicializaDatos(esReenvio As Boolean, esRecibirTotdo As Boolean) As ISyncBase
         Return Inicializar(Function(fechaActualizacion) New CRMPrioridadesNovedades().GetTransporte(),
                            Function() Publicos.WebArchivos.CRM.FechaUltimaDescarga.CRMPrioridadesNovedades,
                            Function() New CRMPrioridadesNovedades(),
                            esReenvio, esRecibirTotdo)
      End Function

   End Class
End Namespace