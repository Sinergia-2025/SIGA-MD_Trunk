Option Strict On
Option Explicit On
Option Infer On
Namespace ServiciosRest.Sincronizacion.CRM
   Public Class SyncCRMTiposComentariosNovedades
      Inherits SyncBase(Of Entidades.JSonEntidades.Archivos.CRM.CRMTipoComentarioNovedadJSonTransporte, Entidades.JSonEntidades.Archivos.CRM.CRMTipoComentarioNovedadJSon)

      Public Sub New()
         MyBase.New(Publicos.WebArchivos.CRM.SyncConfigSyncTiposComentarios)
      End Sub

      Public Function InicializaDatos(esReenvio As Boolean, esRecibirTotdo As Boolean) As ISyncBase
         Return Inicializar(Function(fechaActualizacion) New CRMTiposComentariosNovedades().GetTransporte(),
                            Function() Publicos.WebArchivos.CRM.FechaUltimaDescarga.CRMTiposComentariosNovedades,
                            Function() New CRMTiposComentariosNovedades(),
                            esReenvio, esRecibirTotdo)
      End Function

   End Class
End Namespace