Option Strict On
Option Explicit On
Option Infer On
Namespace ServiciosRest.Sincronizacion.CRM
   Public Class SyncCRMMetodosResolucionesNovedades
      Inherits SyncBase(Of Entidades.JSonEntidades.Archivos.CRM.CRMMetodoResolucionNovedadJSonTransporte, Entidades.JSonEntidades.Archivos.CRM.CRMMetodoResolucionNovedadJSon)

      Public Sub New()
         MyBase.New(Publicos.WebArchivos.CRM.SyncConfigSyncMetodosResoluciones)
      End Sub

      Public Function InicializaDatos(esReenvio As Boolean, esRecibirTotdo As Boolean) As ISyncBase
         Return Inicializar(Function(fechaActualizacion) New CRMMetodosResolucionesNovedades().GetTransporte(),
                            Function() Publicos.WebArchivos.CRM.FechaUltimaDescarga.CRMMetodosResolucionesNovedades,
                            Function() New CRMMetodosResolucionesNovedades(),
                            esReenvio, esRecibirTotdo)
      End Function

   End Class
End Namespace