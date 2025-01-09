Option Strict On
Option Explicit On
Option Infer On
Namespace ServiciosRest.Sincronizacion
   Public Class SyncSubRubros
      Inherits SyncBase(Of Entidades.JSonEntidades.Archivos.SubRubroJSonTransporte, Entidades.JSonEntidades.Archivos.SubRubroJSon)

      Public Sub New()
         MyBase.New(Publicos.WebArchivos.SyncConfigSubRubro)
      End Sub

      Public Function InicializaDatos(esReenvio As Boolean, esRecibirTotdo As Boolean) As ISyncBase
         Return Inicializar(Function(fechaActualizacion) New SubRubros().GetSubRubrosJSonTransporte(fechaActualizacion),
                            Function() Publicos.WebArchivos.SubRubros.FechaUltimaDescarga,
                            Function() New SubRubros(),
                            esReenvio, esRecibirTotdo)
      End Function

   End Class
End Namespace