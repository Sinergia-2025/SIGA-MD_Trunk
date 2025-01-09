Public Class ucConfPedidosWeb

   Protected Overrides Sub OnCargando(e As CancelableEventArgs)
      MyBase.OnCargando(e)

      'POST
      txtPedidosURLWebPOST.Text = Reglas.Publicos.PedidosURLWebPOST
      txtEstadoPedidoPendienteWebPOST.Text = Reglas.Publicos.EstadoPedidoPendienteWebPOST
      txtEstadoPedidoEnviadoWebPOST.Text = Reglas.Publicos.EstadoPedidoEnviadoWebPOST
      txtTOKENTalkiu.Text = Reglas.Publicos.PedidosTalkiuToken
      txtURLGETProposal.Text = Reglas.Publicos.PedidosTalkiuGET

   End Sub

   Protected Overrides Sub OnGrabando(e As CancelableEventArgs)
      MyBase.OnGrabando(e)

      ActualizarParametro(Entidades.Parametro.Parametros.PEDIDOSURLWEBPOST, txtPedidosURLWebPOST, Nothing, lblPedidosURLWebPOST.Text)
      ActualizarParametro(Entidades.Parametro.Parametros.ESTADOPEDIDOPENDIENTEWEBPOST, txtEstadoPedidoPendienteWebPOST, Nothing, lblEstadoPedidoPendienteWebPOST.Text)
      ActualizarParametro(Entidades.Parametro.Parametros.ESTADOPEDIDOENVIADOWEBPOST, txtEstadoPedidoEnviadoWebPOST, Nothing, lblEstadoPedidoEnviadoWebPOST.Text)
      ActualizarParametro(Entidades.Parametro.Parametros.PEDIDOTALKIUTOKEN, txtTOKENTalkiu, Nothing, lblTOKENTalkiu.Text)
      ActualizarParametro(Entidades.Parametro.Parametros.PEDIDOTALKIUGET, txtURLGETProposal, Nothing, lblURLGETProposal.Text)

   End Sub

End Class
