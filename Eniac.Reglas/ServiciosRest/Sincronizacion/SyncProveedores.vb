Option Strict On
Option Explicit On
Option Infer On
Namespace ServiciosRest.Sincronizacion
   Public Class SyncProveedores
      Inherits SyncBase(Of Entidades.JSonEntidades.Archivos.ProveedorJSonTransporte, Entidades.JSonEntidades.Archivos.ProveedorJSon)

      Public Sub New()
         MyBase.New(Publicos.WebArchivos.SyncConfigProveedor)
      End Sub

      Public Function InicializaDatos(esReenvio As Boolean, esRecibirTotdo As Boolean) As ISyncBase
         Return Inicializar(Function(fechaActualizacion) New Proveedores().GetProveedoresJSonTransporte(),
                            Function() Publicos.WebArchivos.Proveedores.FechaUltimaDescarga,
                            Function() New Proveedores(),
                            esReenvio, esRecibirTotdo)
      End Function

   End Class
End Namespace