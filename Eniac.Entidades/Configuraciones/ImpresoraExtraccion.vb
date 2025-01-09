Public Class ImpresoraExtraccion
   Inherits Entidad

   Public Const NombreTabla As String = "ImpresorasExtracciones"

   Public Enum Columnas
      IdSucursal
      IdImpresora
      Secuencia
      ZetaDesde
      ZetaHasta
      FechaExtraccionDesde
      FechaExtraccionHasta
      FechaExtraccion
      IdUsuarioExtraccion
      NombreArchivo
      MD5Archivo

   End Enum

   Public Property IdImpresora As String
   Public Property Secuencia As Integer

   Public Property ZetaDesde As Long
   Public Property ZetaHasta As Long

   Public Property FechaExtraccionDesde As Date
   Public Property FechaExtraccionHasta As Date

   Public Property FechaExtraccion As Date
   Public Property IdUsuarioExtraccion As String

   Public Property NombreArchivo As String
   Public Property MD5Archivo As String


End Class