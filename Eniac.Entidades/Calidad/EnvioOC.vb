Public Class EnvioOC
   Inherits Eniac.Entidades.Entidad

   Public Const NombreTabla As String = "CalidadEnviosOC"
   Public Enum Columnas
      IdSucursal
      IdTipoComprobante
      Letra
      CentroEmisor
      NumeroPedido
      FechaEnvio
      IdUsuario
      MetodoGrabacion
      IdFuncion
      FechaReprogramacion

   End Enum

   Public Property TipoComprobante As Entidades.TipoComprobante
   Public Property Letra As String
   Public Property CentroEmisor As Integer
   Public Property NumeroPedido As Long
   Public Property FechaEnvio As DateTime
   Public Property IdUsuario As String
   Public Property FechaReprogramacion As DateTime

End Class