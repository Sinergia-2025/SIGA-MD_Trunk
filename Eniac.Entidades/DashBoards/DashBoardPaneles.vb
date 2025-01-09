Public Class DashBoardPaneles
   Inherits Entidad

   Public Const NombreTabla As String = "DashBoardsPaneles"
   Public Enum Columnas
      IdDashBoard
      Nombre
      TipoDashBoard
      Titulo
      Comentario
      SentenciaSQL
      AutoRefresh
      TipoRefresh
      TimerRefresh
      ImagenDashBoard
      ValorObjetivo
      ValorMinimo
      Area3DStyle
      ModeloDashBoard
      ShowValueLabel
      AxisTitleX
      AxisTitleY
      Estado
      Orden
      Descripcion
      VisualizaLeyenda
      Modelo
   End Enum

   Public Property IdDashBoard As Integer
   Public Property Nombre As String
   Public Property TipoDashBoard As DashBoardTipo
   Public Property Titulo As String
   Public Property Comentario As String
   Public Property SentenciaSQL As String
   Public Property AutoRefresh As Boolean
   Public Property TipoRefresh As Integer
   Public Property TimerRefresh As Integer
   Public Property ImagenDashBoard As Byte()
   Public Property ValorObjetivo As Decimal
   Public Property ValorMinimo As Decimal
   Public Property Area3DStyle As Boolean?
   Public Property ModeloDashBoard As DashBoardModelo
   Public Property ShowValueLabel As Boolean?
   Public Property AxisTitleX As String
   Public Property AxisTitleY As String
   Public Property Estado As Boolean
   Public Property Orden As Integer
   Public Property Descripcion As String
   Public Property VisualizaLeyenda As Boolean
   Public Property Modelo As String

End Class
