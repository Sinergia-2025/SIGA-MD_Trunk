Option Strict On
Option Explicit On
Option Infer On
Namespace ServiciosRest.Sincronizacion
   Public Class SyncProductos
      Inherits SyncBase(Of Entidades.JSonEntidades.Archivos.ProductoJSonTransporte, Entidades.JSonEntidades.Archivos.ProductoJSon)

      Public Sub New()
         MyBase.New(Publicos.WebArchivos.SyncConfigProducto)
      End Sub

      Public Function InicializaDatos(esReenvio As Boolean, esRecibirTotdo As Boolean, publicarEn As Entidades.Filtros.ProductosPublicarEnFiltros) As ISyncBase
         Return Inicializar(Function(fechaActualizacion) New Productos().GetProductosJSonTransporte(fechaActualizacion, publicarEn),
                            Function() Publicos.WebArchivos.Productos.FechaUltimaDescarga,
                            Function() New Productos(),
                            esReenvio, esRecibirTotdo)
      End Function

   End Class
End Namespace