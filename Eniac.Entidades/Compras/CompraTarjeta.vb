Public Class CompraTarjeta
   Inherits Entidad
   Public Const NombreTabla As String = "ComprasTarjetas"
   Public Enum Columnas
      IdSucursal
      IdTipoComprobante
      Letra
      CentroEmisor
      NumeroComprobante
      IdProveedor
      IdTarjetaCupon
      IdEstadoTarjeta
      IdEstadoTarjetaAnt

   End Enum

   Public Property IdTipoComprobante As String
   Public Property Letra As String
   Public Property CentroEmisor As Integer
   Public Property NumeroComprobante As Long
   Public Property IdProveedor As Long
   Public Property TarjetaCupon As TarjetaCupon
   Public Property IdEstadoTarjeta As TarjetaCupon.Estados
   Public Property IdEstadoTarjetaAnt As TarjetaCupon.Estados

#Region "ReadOnly Propiedades"
   Public ReadOnly Property IdTarjetaCupon As Integer
      Get
         If TarjetaCupon Is Nothing Then Return 0
         Return TarjetaCupon.IdTarjetaCupon
      End Get
   End Property
#End Region

End Class