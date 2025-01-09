Imports System.Runtime.Serialization

<DataContract> Public Class PedidoWeb
   <DataMember(Name:="id")> Public Property IdPedido As String
   <DataMember(Name:="cuitempresa")> Public Property CuitEmpresa As String
   <DataMember(Name:="estado")> Public Property Estado As String
   <DataMember(Name:="subtotal")> Public Property Subtotal As String
   <DataMember(Name:="iva1importe")> Public Property IVA1Importe As String
   <DataMember(Name:="total")> Public Property Total As String
   <DataMember(Name:="fechaFormato")> Public Property FechaFormato As String
   <DataMember(Name:="clienteCodigo")> Public Property CodigoCliente As String
   <DataMember(Name:="clienteName")> Public Property ClienteName As String
   <DataMember(Name:="vendedorCodigo")> Public Property CodigoVendedor As String
   <DataMember(Name:="vendedorName")> Public Property VendedorName As String

   <DataMember(Name:="detalle")> Public Property Detalle As List(Of PedidoWebDetalle)

End Class
