Public Class EnvioOCError
   Inherits Eniac.Entidades.Entidad

   Public Const NombreTabla As String = "CalidadEnviosOCErrores"
   Public Enum Columnas
      IdSucursal
      IdTipoComprobante
      Letra
      CentroEmisor
      NumeroPedido
      FechaEnvioError
      DescripcionError

   End Enum

   Public Property TipoComprobante As Entidades.TipoComprobante
   Public Property Letra As String
   Public Property CentroEmisor As Integer
   Public Property NumeroPedido As Long
   Public Property FechaEnvioError As DateTime
   Public Property DescripcionError As String

End Class