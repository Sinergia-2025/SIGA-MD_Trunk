Public Class VentaColaImpresion
   Inherits Eniac.Entidades.Entidad

   Public Enum Columnas
      IdVentaColaImpresion
      NombreColaImpresion
      Activa
   End Enum

   Public Sub New()

   End Sub

#Region "Propiedades"
   Public Property IdVentaColaImpresion As Integer
   Public Property NombreColaImpresion As String
   Public Property Activa As Boolean
#End Region

End Class