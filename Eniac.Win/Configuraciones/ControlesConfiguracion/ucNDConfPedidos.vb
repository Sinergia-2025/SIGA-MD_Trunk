Public Class ucNDConfPedidos
   Protected Overrides Sub OnCargando(e As CancelableEventArgs)
      MyBase.OnCargando(e)

      chbPedidosPermitirModificarGestionados.Checked = Reglas.Publicos.PedidosPermitirModificarNoGestionados

   End Sub

   Protected Overrides Sub OnGrabando(e As CancelableEventArgs)
      MyBase.OnGrabando(e)

      ActualizarParametro(Entidades.Parametro.Parametros.PEDIDOSPERMITIRMODIFICARNOGESTIONADOS, chbPedidosPermitirModificarGestionados, "", chbPedidosPermitirModificarGestionados.Text)

   End Sub

End Class
