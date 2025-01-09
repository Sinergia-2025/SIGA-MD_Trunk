Public Class TipoImpresionFiscal
   Inherits Entidades.Entidad

   Public Const NombreTabla As String = "TiposImpresionesFiscales"

   Public Enum Columnas
      IdTipoImpresionFiscal
      NombreTipoImpresionFiscal
   End Enum

#Region "Propiedades"

   Public Property IdTipoImpresionFiscal As Integer
   Public Property NombreTipoImpresionFiscal As String

#End Region

End Class
