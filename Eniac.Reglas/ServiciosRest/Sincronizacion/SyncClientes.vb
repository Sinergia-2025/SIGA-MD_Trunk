Option Strict On
Option Explicit On
Option Infer On
Namespace ServiciosRest.Sincronizacion
   Public Class SyncClientes
      Inherits SyncBase(Of Entidades.JSonEntidades.Archivos.ClienteJSonTransporte, Entidades.JSonEntidades.Archivos.ClienteJSon)

      Public Sub New()
         MyBase.New(Publicos.WebArchivos.SyncConfigCliente)
      End Sub

      Public Function InicializaDatos(esReenvio As Boolean, esRecibirTotdo As Boolean) As ISyncBase
         Return Inicializar(Function(fechaActualizacion) New Clientes().GetClientesJSonTransporte(fechaActualizacion, Entidades.Cliente.ModoClienteProspecto.Cliente),
                            Function() Publicos.WebArchivos.Clientes.FechaUltimaDescarga,
                            Function() New Clientes(),
                            esReenvio, esRecibirTotdo)
      End Function

   End Class
End Namespace