Public Class ConfiguracionesAplicacion
   Public Property EjecutaAlerta As Boolean
   Public Property EjecutaAsync As Boolean

   Public Property MinutosEjecucionAlertas As Integer

   Public Sub New()
      EjecutaAlerta = True
      EjecutaAsync = True
      'minutos
      MinutosEjecucionAlertas = 60
   End Sub

End Class