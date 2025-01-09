Option Strict On
Option Explicit On
Option Infer On
Namespace ServiciosRest.Sincronizacion
   Public Class SyncRubrosCompras
      Inherits SyncBase(Of Entidades.JSonEntidades.Archivos.RubroCompraJSonTransporte, Entidades.JSonEntidades.Archivos.RubroCompraJson)

      Public Sub New()
         MyBase.New(Publicos.WebArchivos.SyncConfigRubroCompra)
      End Sub

      Public Function InicializaDatos(esReenvio As Boolean, esRecibirTotdo As Boolean) As ISyncBase
         Return Inicializar(Function(fechaActualizacion) New RubrosCompras().GetRubrosComprasJSonTransporte(),
                            Function() Publicos.WebArchivos.RubrosCompras.FechaUltimaDescarga,
                            Function() New RubrosCompras(),
                            esReenvio, esRecibirTotdo)
      End Function

   End Class
End Namespace