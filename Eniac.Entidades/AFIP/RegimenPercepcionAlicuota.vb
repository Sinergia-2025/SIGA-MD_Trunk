Public Class RegimenPercepcionAlicuota
   Inherits Entidad

   Public Const NombreTabla As String = "RegimenesPercepcionesAlicuotas"

   Public Enum Columnas
      IdTipoImpuesto
      IdRegimenPercepcion
      AlicuotaPercepcion

   End Enum

   Public Sub New()
      AlicuotaPercepcion = -1
   End Sub

#Region "Propiedades"

   Public Property IdTipoImpuesto As String
   Public Property IdRegimenPercepcion As Integer
   Public Property AlicuotaPercepcion As Decimal

#End Region

End Class