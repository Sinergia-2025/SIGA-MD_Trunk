<Serializable()> _
Public Class Observacion
   Inherits Eniac.Entidades.Entidad

   Public Enum Columnas
      IdObservacion
      DetalleObservacion
      Tipo
   End Enum
   Public Sub New()
      Tipo = "VENTA"
   End Sub
#Region "Propiedades"

   Private _idObservacion As Integer
   Public Property IdObservacion() As Integer
      Get
         Return Me._idObservacion
      End Get
      Set(ByVal value As Integer)
         Me._idObservacion = value
      End Set
   End Property

   Private _detalleObservacion As String
   Public Property DetalleObservacion() As String
      Get
         Return Me._detalleObservacion
      End Get
      Set(ByVal value As String)
         Me._detalleObservacion = value
      End Set
   End Property

   Private _tipo As String
   Public Property Tipo() As String
      Get
         Return Me._tipo
      End Get
      Set(ByVal value As String)
         Me._tipo = value
      End Set
   End Property

#End Region


   Public Shared Function GetNombreTipo(tipo As String) As String
      Dim result As String = ""
      Select Case tipo
         Case "VENTA"
            result = "VENTA"
         Case "COMPRA"
            result = "COMPRA"
         Case "NOTA"
            result = "NOTA NORMAL"
         Case "BONIF"
            result = "NOTA BONIFICACION"
         Case "CAMBIO"
            result = "NOTA CAMBIO"
      End Select
      Return result
   End Function

End Class