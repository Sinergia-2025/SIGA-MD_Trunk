Public Class ucNDConfStock

   Protected Overrides Sub OnCargando(e As CancelableEventArgs)
      MyBase.OnCargando(e)

      'Stock
      chbUtilizaStockReservado.Checked = Reglas.Publicos.UtilizaStockReservado
      chbUtilizaStockDefectuoso.Checked = Reglas.Publicos.UtilizaStockDefectuoso
      chbUtilizaStockFuturo.Checked = Reglas.Publicos.UtilizaStockFuturo
      chbUtilizaStockFuturoReservado.Checked = Reglas.Publicos.UtilizaStockFuturoReservado

   End Sub

   Protected Overrides Sub OnGrabando(e As CancelableEventArgs)
      MyBase.OnGrabando(e)

      'Stock
      ActualizarParametro(Entidades.Parametro.Parametros.UTILIZASTOCKRESERVADO, chbUtilizaStockReservado, Nothing, chbUtilizaStockReservado.Text)
      ActualizarParametro(Entidades.Parametro.Parametros.UTILIZASTOCKDEFECTUOSO, chbUtilizaStockDefectuoso, Nothing, chbUtilizaStockDefectuoso.Text)
      ActualizarParametro(Entidades.Parametro.Parametros.UTILIZASTOCKFUTURO, chbUtilizaStockFuturo, Nothing, chbUtilizaStockFuturo.Text)
      ActualizarParametro(Entidades.Parametro.Parametros.UTILIZASTOCKFUTURORESERVADO, chbUtilizaStockFuturoReservado, Nothing, chbUtilizaStockFuturoReservado.Text)

   End Sub

End Class
