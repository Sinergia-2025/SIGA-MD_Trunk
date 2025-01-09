Option Strict On
Option Explicit On
Option Infer On
Namespace ServiciosRest.Sincronizacion
   Public Class SyncSubSubRubros
      Inherits SyncBase(Of Entidades.JSonEntidades.Archivos.SubSubRubroJSonTransporte, Entidades.JSonEntidades.Archivos.SubSubRubroJSon)

      Public Sub New()
         MyBase.New(Publicos.WebArchivos.SyncConfigSubSubRubro)
      End Sub

      Public Function InicializaDatos(esReenvio As Boolean, esRecibirTotdo As Boolean) As ISyncBase
         Return Inicializar(Function(fechaActualizacion) New SubSubRubros().GetSubSubSubRubrosJsonTransporte(fechaActualizacion),
                            Function() Publicos.WebArchivos.SubSubRubros.FechaUltimaDescarga,
                            Function() New SubSubRubros(),
                            esReenvio, esRecibirTotdo)
      End Function

   End Class
End Namespace