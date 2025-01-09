Option Strict On
Option Explicit On
Option Infer On
Namespace ServiciosRest.Sincronizacion
   Public Class SyncRubros
      Inherits SyncBase(Of Entidades.JSonEntidades.Archivos.RubroJSonTransporte, Entidades.JSonEntidades.Archivos.RubroJSon)

      Public Sub New()
         MyBase.New(Publicos.WebArchivos.SyncConfigRubro)
      End Sub

      Public Function InicializaDatos(esReenvio As Boolean, esRecibirTotdo As Boolean) As ISyncBase
         Return Inicializar(Function(fechaActualizacion) New Rubros().GetRubrosJSonTransporte(fechaActualizacion),
                            Function() Publicos.WebArchivos.Rubros.FechaUltimaDescarga,
                            Function() New Rubros(),
                            esReenvio, esRecibirTotdo)
      End Function

   End Class
End Namespace