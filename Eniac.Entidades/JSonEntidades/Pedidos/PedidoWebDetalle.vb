Imports System.Runtime.Serialization

<DataContract> Public Class PedidoWebDetalle
   <DataMember(Name:="codigoproducto")> Public Property CodigoProducto As String
   <DataMember(Name:="cantidad")> Public Property Cantidad As String
   <DataMember(Name:="descripcion")> Public Property Descripcion As String
   <DataMember(Name:="preciounitario")> Public Property PrecioUnitario As String
   <DataMember(Name:="descuento_porcentaje")> Public Property DescuentoPorcentaje As String
   <DataMember(Name:="descuento_importe")> Public Property DescuentoImporte As String
   <DataMember(Name:="subtotal")> Public Property Subtotal As String

End Class
