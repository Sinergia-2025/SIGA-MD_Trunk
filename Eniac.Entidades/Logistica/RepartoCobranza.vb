Public Class RepartoCobranza
   Inherits Entidad

   Public Const NombreTabla As String = "RepartosCobranzas"

   Public Enum Columnas
      IdSucursal
      IdReparto
      IdCobranza
      FechaRendicion
      IdCaja
      FechaAlta
      IdUsuarioAlta

   End Enum

   Public Sub New()
      Comprobantes = New List(Of RepartoCobranzaComprobante)()
   End Sub

   Public Property IdReparto As Integer
   Public Property IdCobranza As Integer
   Public Property FechaRendicion As DateTime
   Public Property IdCaja As Integer
   Public Property FechaAlta As DateTime
   Public Property IdUsuarioAlta As String

   Public Property Comprobantes As List(Of RepartoCobranzaComprobante)

End Class