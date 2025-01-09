Option Strict On
Option Explicit On
Option Infer On
Namespace ServiciosRest.Sincronizacion.CRM
   Public Class SyncCRMNovedades
      Inherits SyncBase(Of Entidades.JSonEntidades.Archivos.CRM.CRMNovedadJSonTransporte, Entidades.JSonEntidades.Archivos.CRM.CRMNovedadJSon)

      Public Sub New()
         MyBase.New(Publicos.WebArchivos.CRM.SyncConfigSyncNovedades)
      End Sub

      Public Function InicializaDatos(esReenvio As Boolean, esRecibirTotdo As Boolean) As ISyncBase
         Return Inicializar(Function(fechaActualizacion) New CRMNovedades().GetTransporte(fechaActualizacion),
                            Function() Publicos.WebArchivos.CRM.FechaUltimaDescarga.CRMNovedades,
                            Function() New CRMNovedades(),
                            esReenvio, esRecibirTotdo)
      End Function

   End Class
End Namespace