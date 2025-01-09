Option Strict On
Option Explicit On
Option Infer On
Namespace ServiciosRest.Sincronizacion.CRM
   Public Class SyncCRMNovedadesSeguimiento
      Inherits SyncBase(Of Entidades.JSonEntidades.Archivos.CRM.CRMNovedadSeguimientoJSonTransporte, Entidades.JSonEntidades.Archivos.CRM.CRMNovedadSeguimientoJSon)

      Public Sub New()
         MyBase.New(Publicos.WebArchivos.CRM.SyncConfigSyncNovedadesSeguimiento)
      End Sub

      Public Function InicializaDatos(esReenvio As Boolean, esRecibirTotdo As Boolean) As ISyncBase
         Return Inicializar(Function(fechaActualizacion) New CRMNovedadesSeguimiento().GetTransporte(fechaActualizacion),
                            Function() Publicos.WebArchivos.CRM.FechaUltimaDescarga.CRMNovedadesSeguimiento,
                            Function() New CRMNovedadesSeguimiento(),
                            esReenvio, esRecibirTotdo)
      End Function

   End Class
End Namespace