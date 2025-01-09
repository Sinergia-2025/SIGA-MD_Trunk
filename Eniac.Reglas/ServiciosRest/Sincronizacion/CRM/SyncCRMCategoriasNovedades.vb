Option Strict On
Option Explicit On
Option Infer On
Namespace ServiciosRest.Sincronizacion.CRM
   Public Class SyncCRMCategoriasNovedades
      Inherits SyncBase(Of Entidades.JSonEntidades.Archivos.CRM.CRMCategoriaNovedadJSonTransporte, Entidades.JSonEntidades.Archivos.CRM.CRMCategoriaNovedadJSon)

      Public Sub New()
         MyBase.New(Publicos.WebArchivos.CRM.SyncConfigSyncCategorias)
      End Sub

      Public Function InicializaDatos(esReenvio As Boolean, esRecibirTotdo As Boolean) As ISyncBase
         Return Inicializar(Function(fechaActualizacion) New CRMCategoriasNovedades().GetTransporte(),
                            Function() Publicos.WebArchivos.CRM.FechaUltimaDescarga.CRMCategoriasNovedades,
                            Function() New CRMCategoriasNovedades(),
                            esReenvio, esRecibirTotdo)
      End Function

   End Class
End Namespace