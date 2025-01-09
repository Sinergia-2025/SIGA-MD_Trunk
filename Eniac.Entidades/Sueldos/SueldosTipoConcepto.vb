<Serializable()> _
Public Class SueldosTipoConcepto
   Inherits Eniac.Entidades.Entidad

   Public Enum Columnas
      idTipoConcepto
      NombreTipoConcepto
      Tipo
      Orden
   End Enum

#Region "Propiedades"

   Public Property idTipoConcepto() As Integer
   Public Property NombreTipoConcepto() As String
   Public Property Orden As Integer

#End Region

End Class