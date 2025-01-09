<Serializable()> _
Public Class SemaforoVentaUtilidad
   Inherits Eniac.Entidades.Entidad

#Region "Campos"

   Private _idSemaforo As Integer = 0
   Private _porcentajeHasta As Decimal = 0
   Private _colorSemaforo As Integer = 0
   Private _nombreColor As String = ""

#End Region

   Public Enum Columnas
      IdSemaforo
      PorcentajeHasta
      ColorSemaforo
      ColorLetra
      NombreColor
      IdTipoSemaforoVentaUtilidad
      Negrita
   End Enum

   Public Enum TiposSemaforos
      RENTABILIDAD
      SALDOS
      ESTRELLAS
   End Enum

#Region "Propiedades"

   Public Property Negrita As Boolean
   Public Property IdTipoSemaforoVentaUtilidad As TiposSemaforos
   Public Property ColorLetra As Integer
   Public Property IdSemaforo() As Integer
      Get
         Return Me._idSemaforo
      End Get
      Set(ByVal value As Integer)
         Me._idSemaforo = value
      End Set
   End Property

   Public Property PorcentajeHasta() As Decimal
      Get
         Return Me._porcentajeHasta
      End Get
      Set(ByVal value As Decimal)
         Me._porcentajeHasta = value
      End Set
   End Property

   Public Property ColorSemaforo() As Integer
      Get
         Return Me._colorSemaforo
      End Get
      Set(ByVal value As Integer)
         Me._colorSemaforo = value
      End Set
   End Property

   Public Property NombreColor() As String
      Get
         Return Me._nombreColor
      End Get
      Set(ByVal value As String)
         Me._nombreColor = value
      End Set
   End Property

#End Region

End Class
