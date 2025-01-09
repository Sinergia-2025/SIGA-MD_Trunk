Public Class RegimenPercepcion
   Inherits Entidad

   Public Const NombreTabla As String = "RegimenesPercepciones"

   Public Enum Columnas
      IdTipoImpuesto
      IdRegimenPercepcion
      NombreRegimenPercepcion
      CodigoAFIP
      ImporteNetoMinimo
      ImpuestoMinimo

   End Enum

   Public Sub New()
      Alicuotas = New List(Of RegimenPercepcionAlicuota)()
   End Sub

#Region "Propiedades"

   Public Property IdTipoImpuesto As String
   Public Property IdRegimenPercepcion As Integer
   Public Property NombreRegimenPercepcion As String
   Public Property CodigoAFIP As Integer
   Public Property ImporteNetoMinimo As Decimal
   Public Property ImpuestoMinimo As Decimal

   Public Property Alicuotas As List(Of RegimenPercepcionAlicuota)
#End Region

End Class