Imports System.Web.Script.Serialization

Namespace JSonEntidades.SiMovilPedidos
   Public Class PedidoProductoSiMovilJSon
      Public Property IdEmpresa As Integer
      Public Property IdDispositivo As String
      Public Property IdPedido As Long
      Public Property Orden As Integer
      Public Property IdProducto As String
      Public Property Cantidad As Decimal
      Public Property Precio As Decimal
      Public Property IdPlazoEntrega As Integer
      Public Property IdListaPrecios As Integer
      Public Property CantidadCambio As Decimal
      Public Property CantidadBonif As Decimal
      Public Property CantidadDevolucion As Decimal

      Public Property NotaCambio As String
      Public Property NotaBonif As String
      Public Property NotaDevolucion As String

      Public Property Descuento As Decimal

#Region "Propiedades utilizadas en las grilla"
      <ScriptIgnore>
      Public Property NombreProducto As String
      <ScriptIgnore>
      Public Property NombreListaPrecios As String
#End Region
   End Class
End Namespace