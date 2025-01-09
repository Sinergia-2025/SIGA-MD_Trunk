Public Class ucConfEstadisticas

   Protected Overrides Sub OnCargando(e As CancelableEventArgs)
      MyBase.OnCargando(e)

      'Estadisticas
      txtMinutosTableroComando.Text = Reglas.Publicos.MinutosTableroComando.ToString()

   End Sub

   Protected Overrides Sub OnGrabando(e As CancelableEventArgs)
      MyBase.OnGrabando(e)

      'Estadisticas
      ActualizarParametro(Entidades.Parametro.Parametros.MINUTOSTABLEROCOMANDO, txtMinutosTableroComando, Nothing, lblMinutosTableroComando.Text)

   End Sub

End Class