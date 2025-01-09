Option Strict On
Option Explicit On
Option Infer On
Namespace ServiciosRest.Sincronizacion
   Public Class SyncProductosSucursales
      Inherits SyncBase(Of Entidades.JSonEntidades.Archivos.ProductoSucursalJSonTransporte, Entidades.JSonEntidades.Archivos.ProductoSucursalJSon)

      Public Sub New()
         MyBase.New(Publicos.WebArchivos.SyncConfigProductoSucursal)
      End Sub

      Public Function InicializaDatos(esReenvio As Boolean, esRecibirTotdo As Boolean, publicarEn As Entidades.Filtros.ProductosPublicarEnFiltros) As ISyncBase
         Return Inicializar(Function(fechaActualizacion) New ProductosSucursales().GetProductosSucursalesJSonTransporte(fechaActualizacion, publicarEn),
                            Function() Publicos.WebArchivos.ProductosSucursales.FechaUltimaDescarga,
                            Function() New ProductosSucursales(),
                            esReenvio, esRecibirTotdo)
      End Function

   End Class
End Namespace