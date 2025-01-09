<Serializable()>
Public Class VentaNumero
   Inherits Eniac.Entidades.Entidad

   Public Enum Columnas
      IdTipoComprobante
      LetraFiscal
      CentroEmisor
      IdSucursal
      Numero
      IdTipoComprobanteRelacionado
      Fecha
      IdEmpresa
   End Enum

   Public Sub New()
      Me.IdEmpresa = Eniac.Entidades.Usuario.Actual.Sucursal.IdEmpresa
   End Sub

#Region "Propiedades"
   Public Property IdEmpresa As Integer

   Public Property IdTipoComprobante As String
   Public Property LetraFiscal As String
   Public Property CentroEmisor As Short
   Public Property Numero As Long

   Public Property Fecha As Date
   Public Property IdTipoComprobanteRelacionado As String

#End Region

End Class