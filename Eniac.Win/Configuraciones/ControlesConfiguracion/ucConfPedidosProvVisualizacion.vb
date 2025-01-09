Public Class ucConfPedidosProvVisualizacion
   Protected Overrides Sub OnCargando(e As CancelableEventArgs)
      MyBase.OnCargando(e)

      chbPedidosProvMuestraProvHabitual.Checked = Reglas.Publicos.PedidosProvMuestraProvHabitual

   End Sub

   Protected Overrides Sub OnGrabando(e As CancelableEventArgs)
      MyBase.OnGrabando(e)

      ActualizarParametro(Entidades.Parametro.Parametros.PEDIDOSPROVMUESTRAPROVHABITUAL, chbPedidosProvMuestraProvHabitual, Nothing, chbPedidosProvMuestraProvHabitual.Text)

   End Sub

End Class
