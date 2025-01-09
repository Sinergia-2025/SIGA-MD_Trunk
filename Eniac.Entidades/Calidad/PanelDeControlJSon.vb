Imports System.ComponentModel
Imports System.Runtime.CompilerServices


Namespace JSonEntidades.Archivos
   Public Class PanelDeControlJSonTransporteEncab
      Public Property Columnas As List(Of PanelDeControlColumnasJSon)
      ' Public Property Datos As List(Of PanelDeControlJSon)
   End Class

   Public Class PanelDeControlJSonTransporte
      ' Public Property Columnas As List(Of PanelDeControlColumnasJSon)
      Public Property Datos As List(Of PanelDeControlJSon)
   End Class


   Public Class PanelDeControlColumnasJSon
      Public Property IdColumna As String
      Public Property Etiqueta As String
      Public Property Cantidad As Integer
   End Class
   Public Class PanelDeControlSeccionesJSon
      Public Property IdColumna As String
      Public Property Fecha As String
      '  Public Property Color As Tuple(Of Integer, Integer, Integer)
      Public Property Color As String
      Public Sub New()
         Dim r As Integer = Drawing.Color.FromArgb(-1).R
         Dim g As Integer = Drawing.Color.FromArgb(-1).G
         Dim b As Integer = Drawing.Color.FromArgb(-1).B
         '    Color = New Tuple(Of Integer, Integer, Integer)(r, g, b)
         ' Color = r.ToString() & "," & g.ToString & "," & b.ToString
      End Sub
   End Class
   Public Class PanelDeControlJSon

      Public Sub New()
         Secciones = New List(Of PanelDeControlSeccionesJSon)()
      End Sub

      Public Property Codigo As String
      Public Property TipoModelo As String
      Public Property Modelo As String
      Public Property Cliente As String
      Public Property FechaIngreso As String
      Public Property FechaEntregaReProg As String
      Public Property FechaLiberado As String
      Public Property Secciones As List(Of PanelDeControlSeccionesJSon)

   End Class


End Namespace
