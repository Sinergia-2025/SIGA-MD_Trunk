Public Class ucNDConfPrecios

   Protected Overrides Sub OnCargando(e As CancelableEventArgs)
      MyBase.OnCargando(e)

      'Precios
      chbPreciosConIVA.Checked = Reglas.Publicos.PreciosConIVA

   End Sub

   Protected Overrides Sub OnGrabando(e As CancelableEventArgs)
      MyBase.OnGrabando(e)

      'Precios
      ActualizarParametroTexto(Entidades.Parametro.Parametros.PRECIOCONIVA, If(chbPreciosConIVA.Checked, "SI", "NO"), Nothing, chbPreciosConIVA.Text)

   End Sub

End Class