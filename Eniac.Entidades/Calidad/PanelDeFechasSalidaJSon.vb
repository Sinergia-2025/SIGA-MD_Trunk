Imports System.ComponentModel
Imports System.Runtime.CompilerServices


Namespace JSonEntidades.Archivos
   Public Class PanelDeFechasSalidaJSonTransporteEncab
      Public Property Columnas As List(Of PanelDeFechasSalidaColumnasJSon)

   End Class

   Public Class PanelDeFechasSalidaJSonTransporte

      Public Property Datos As List(Of PanelDeFechasSalidaJSon)
   End Class

   Public Class PanelDeFechasSalidaJSonTransportePeriodos
      Public Property Periodos As List(Of PanelDeFechasSalidaPeriodosJSon)

   End Class

   Public Class PanelDeFechasSalidaColumnasJSon
      Public Property IdColumna As String
      Public Property Etiqueta As String
      '  Public Property Cantidad As Integer
   End Class

   Public Class PanelDeFechasSalidaPeriodosJSon
      Public Property Periodo As String
      Public Property EtiquetaPeriodo As String
   End Class


   Public Class PanelDeFechasSalidaSeccionesJSon
      Public Property IdColumna As String
      Public Property Cantidad As Integer

   End Class
   Public Class PanelDeFechasSalidaJSon

      Public Sub New()
         Secciones = New List(Of PanelDeFechasSalidaSeccionesJSon)()
      End Sub

      Public Property FechaSalida As String
      Public Property Secciones As List(Of PanelDeFechasSalidaSeccionesJSon)

   End Class

   Public Class AuditoriaLoginActualizarEstadoJSon
      Public Property Id As String
      Public Property Estado As String
   End Class

   Public Class PanelDeFechasSalidaJSonTransporteAuditorias
      Public Property Auditorias As List(Of AuditoriaLoginActualizarEstadoJSon)

   End Class

End Namespace
