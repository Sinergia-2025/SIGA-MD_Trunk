Public Class ucNDConfExpensas

   Protected Overrides Sub OnCargando(e As CancelableEventArgs)
      MyBase.OnCargando(e)

      'Expensas
      chbPasajeComprasIncluyeImpuestos.Checked = Publicos.PasajeComprasIncluyeImpuestos

   End Sub

   Protected Overrides Sub OnGrabando(e As CancelableEventArgs)
      MyBase.OnGrabando(e)

      'Expensas
      ActualizarParametro(Entidades.Parametro.Parametros.EXPENSASPASAJECOMPRASINCLUYEIMPUESTOS, chbPasajeComprasIncluyeImpuestos, Nothing, chbPasajeComprasIncluyeImpuestos.Text)

   End Sub

End Class