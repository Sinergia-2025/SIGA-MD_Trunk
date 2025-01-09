Option Strict On
Option Explicit On
Option Infer On
Namespace ServiciosRest.Sincronizacion
   Public Class SyncLocalidades
      Inherits SyncBase(Of Entidades.JSonEntidades.Archivos.LocalidadJSonTransporte, Entidades.JSonEntidades.Archivos.LocalidadJSon)

      Public Sub New()
         MyBase.New(Publicos.WebArchivos.SyncConfigLocalidad)
      End Sub

      Public Function InicializaDatos(esReenvio As Boolean, esRecibirTotdo As Boolean) As ISyncBase
         Return Inicializar(Function(fechaActualizacion) New Localidades().GetLocalidadesJSonTransporte(fechaActualizacion),
                            Function() Publicos.WebArchivos.Localidades.FechaUltimaDescarga,
                            Function() New Localidades(),
                            esReenvio, esRecibirTotdo)
      End Function

   End Class
End Namespace