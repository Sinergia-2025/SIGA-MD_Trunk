Option Strict On
Option Explicit On
Option Infer On
Namespace ServiciosRest.Sincronizacion.CRM
   Public Class SyncCRMMediosComunicacionesNovedades
      Inherits SyncBase(Of Entidades.JSonEntidades.Archivos.CRM.CRMMedioComunicacionNovedadJSonTransporte, Entidades.JSonEntidades.Archivos.CRM.CRMMedioComunicacionNovedadJSon)

      Public Sub New()
         MyBase.New(Publicos.WebArchivos.CRM.SyncConfigSyncMediosComunicaciones)
      End Sub

      Public Function InicializaDatos(esReenvio As Boolean, esRecibirTotdo As Boolean) As ISyncBase
         Return Inicializar(Function(fechaActualizacion) New CRMMediosComunicacionesNovedades().GetTransporte(),
                            Function() Publicos.WebArchivos.CRM.FechaUltimaDescarga.CRMMediosComunicacionesNovedades,
                            Function() New CRMMediosComunicacionesNovedades(),
                            esReenvio, esRecibirTotdo)
      End Function

   End Class
End Namespace