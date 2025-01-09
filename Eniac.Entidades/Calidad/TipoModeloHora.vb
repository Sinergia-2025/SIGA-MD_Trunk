Public Class TipoModeloHora
   Inherits Eniac.Entidades.Entidad

   Public Enum Columnas
      IdListaControlTipo
      IdProductoModelo
      FechaHorasEstandar
      HorasEstandar

   End Enum

   Public Property IdListaControlTipo As Integer
   Public Property IdProductoModelo As Integer
   Public Property FechaHorasEstandar As DateTime
   Public Property HorasEstandar As Integer

End Class