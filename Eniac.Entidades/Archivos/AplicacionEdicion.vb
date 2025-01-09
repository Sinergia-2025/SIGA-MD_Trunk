Public Class AplicacionEdicion
   Inherits Eniac.Entidades.Entidad

   Public Enum Columnas
      IdAplicacion
      IdEdicion
      NombreEdicion
   End Enum

   Public Sub New()
      Modulos = New List(Of AplicacionEdicionModulo)()
   End Sub

#Region "Propiedades"
   Public Property IdAplicacion() As String
   Public Property IdEdicion() As String
   Public Property NombreEdicion() As String
   Public Property Modulos() As List(Of AplicacionEdicionModulo)
#End Region

End Class
Public Enum AplicacionEdicionParaParametros
   <Description("Plus")> PLUS
   <Description("Express")> EXPRESS
   <Description("Básica")> BASICA
   <Description("Punto de Venta")> PUNTOVENTA
End Enum