Public Class AFIPTipoComprobante
   Inherits Eniac.Entidades.Entidad
   Public Const NombreTabla As String = "AFIPTiposComprobantes"
   Public Enum Columnas
      IdAFIPTipoComprobante
      NombreAFIPTipoComprobante
      IdTipoComprobante
      Letra
      IdAFIPTipoDocumento
      IncluyeFechaVencimiento
   End Enum

   Public Property IdAFIPTipoComprobante As Integer
   Public Property NombreAFIPTipoComprobante As String
   Public Property IdAFIPTipoDocumento As Integer?
   Public Property IncluyeFechaVencimiento As Boolean?
   Public ReadOnly Property IncluyeFechaVencimientoAsString As String
      Get
         If IncluyeFechaVencimiento.HasValue Then
            Return If(IncluyeFechaVencimiento.Value, "SI", "NO")
         End If
         Return String.Empty
      End Get
   End Property
End Class