Option Strict On
Option Explicit On
Option Infer On
Namespace ServiciosRest.Sincronizacion
   Public Class SyncMarcas
      Inherits SyncBase(Of Entidades.JSonEntidades.Archivos.MarcaJSonTransporte, Entidades.JSonEntidades.Archivos.MarcaJSon)

      Public Sub New()
         MyBase.New(Publicos.WebArchivos.SyncConfigMarca)
      End Sub

      Public Function InicializaDatos(esReenvio As Boolean, esRecibirTotdo As Boolean) As ISyncBase
         Return Inicializar(Function(fechaActualizacion) New Marcas().GetMarcasJSonTransporte(),
                            Function() Publicos.WebArchivos.Marcas.FechaUltimaDescarga,
                            Function() New Marcas(),
                            esReenvio, esRecibirTotdo)
      End Function

   End Class
End Namespace