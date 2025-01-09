Option Strict On
Option Explicit On
Option Infer On
Namespace ServiciosRest.Sincronizacion
   Public Class SyncProductosSucursalesPrecios
      Inherits SyncBase(Of Entidades.JSonEntidades.Archivos.ProductoSucursalPrecioJSonTransporte, Entidades.JSonEntidades.Archivos.ProductoSucursalPrecioJSon)

      Public Sub New()
         MyBase.New(Publicos.WebArchivos.SyncConfigProductoSucursalPrecios)
      End Sub

      Public Function InicializaDatos(esReenvio As Boolean, esRecibirTotdo As Boolean, publicarEn As Entidades.Filtros.ProductosPublicarEnFiltros) As ISyncBase
         Return Inicializar(Function(fechaActualizacion) New ProductosSucursalesPrecios().GetProductosSucursalesPreciosJSonTransporte(fechaActualizacion, publicarEn, listaPrecioPublicarenWeb:=Entidades.Publicos.SiNoTodos.SI),
                            Function() Publicos.WebArchivos.ProductosSucursalesPrecios.FechaUltimaDescarga,
                            Function() New ProductosSucursalesPrecios(),
                            esReenvio, esRecibirTotdo)
      End Function

   End Class
End Namespace