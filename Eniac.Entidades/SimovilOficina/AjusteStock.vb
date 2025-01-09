Namespace SimovilOficina
   Public Class AjusteStock
      Inherits Entidad

      Public Property IdEjecucionAjusteStock As Guid
      Public Property IdSucursal As Integer
      Public Property IdProducto As String
      Public Property Stock As Decimal
      Public Property IdUsuario As String
      Public Property FechaAlta As Date
      Public Property Estado As EstadosAjusteStock
      Public Property MensajeError As String

   End Class
   Public Enum EstadosAjusteStock
      NUEVO
      [ERROR]
      PROCESADO
   End Enum

End Namespace