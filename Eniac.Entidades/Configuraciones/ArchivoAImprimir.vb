Public Class ArchivoAImprimir
   Inherits Eniac.Entidades.Entidad

   Public Enum Columnas
      IdSucursal
      NombreReporteOriginal
      ReporteSecundario
   End Enum

#Region "Propiedades"

   Private _nombreReporteOriginal As String
   Public Property NombreReporteOriginal() As String
      Get
         Return _nombreReporteOriginal
      End Get
      Set(ByVal value As String)
         _nombreReporteOriginal = value
      End Set
   End Property

   Private _reporteSecundario As String
   Public Property ReporteSecundario() As String
      Get
         Return _reporteSecundario
      End Get
      Set(ByVal value As String)
         _reporteSecundario = value
      End Set
   End Property

#End Region




End Class
