Imports System.Web.Script.Serialization

Namespace JSonEntidades.SiMovilPedidos
   Public Class PedidoSiMovilJSon

      Public Property IdEmpresa As Integer
      Public Property IdDispositivo As String
      Public Property IdPedido As Long
      Public Property IdRuta As Integer
      Public Property FechaPedido As Date
      Public Property CodigoCliente As Long
      Public Property IdEstadoVisita As Integer
      Public Property Observacion As String
      Public Property IdPlazoEntrega As Integer
      Public Property FechaEnvioWeb As Date
      Public Property FechaRecepcionWeb As Date
      Public Property FechaDescargaSiga As Nullable(Of Date)
      Public Property FechaProcesoSiga As Nullable(Of Date)
      Public Property Procesado As Boolean
      Public Property IdUnicoPedidos As System.Guid
      Public Property IdTipoComprobante As String
      Public Property NroVersionRemoto As String

      Public Property PedidosProductos As List(Of SiMovilPedidos.PedidoProductoSiMovilJSon)

#Region "Propiedades utilizadas en las grilla"
      <ScriptIgnore>
      Public Property NombreCliente As String
      <ScriptIgnore>
      Public Property NombreRuta As String
#End Region
   End Class
End Namespace