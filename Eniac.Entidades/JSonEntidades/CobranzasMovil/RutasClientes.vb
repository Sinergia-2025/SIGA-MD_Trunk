Namespace JSonEntidades.CobranzasMovil
   Public Class RutasClientes
      Public Sub New(idEmpresa As Integer)
         Me.IdEmpresa = idEmpresa
      End Sub
      Public Property IdEmpresa As Integer
      Public Property IdRuta As Integer
      Public Property Dia As Integer
      Public Property Orden As Integer
      Public Property IdCliente As Long
      Public Property EsDePedidos As Boolean
      Public Property EsDeCobranza As Boolean
   End Class
End Namespace