Imports System.Runtime.Serialization

<DataContract> Public Class PedidoWebEstadoResponse
   <DataMember(Name:="status")> Public Property Status As String
   <DataMember(Name:="id")> Public Property IdPedido As String
   <DataMember(Name:="message")> Public Property Message As String
End Class
