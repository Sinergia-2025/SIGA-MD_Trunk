Public Class ucConfPedidosProvRequerimiento
   Protected Overrides Sub OnCargando(e As CancelableEventArgs)
      MyBase.OnCargando(e)

      chbRequerimientoPermiteFechaEntregaDistintas.Checked = Reglas.Publicos.RequerimientoCompraPermiteFechaEntregaDistintas

   End Sub

   Protected Overrides Sub OnGrabando(e As CancelableEventArgs)
      MyBase.OnGrabando(e)

      ActualizarParametro(Entidades.Parametro.Parametros.REQCOMPRAPERMITEFECHAENTREGADISTINTAS, chbRequerimientoPermiteFechaEntregaDistintas, Nothing)

   End Sub

End Class
