Public Class ucNDConfCtaCteProv
   Protected Overrides Sub OnCargando(e As CancelableEventArgs)
      MyBase.OnCargando(e)

      'Cta. Cte. PROVEEDORES
      chbMuestraObs.Checked = Reglas.Publicos.CtaCteProv.MostrarObservaciondeComprobantes

   End Sub

   Protected Overrides Sub OnGrabando(e As CancelableEventArgs)
      MyBase.OnGrabando(e)

      'Cta. Cte. PROVEEDORES
      ActualizarParametro(Entidades.Parametro.Parametros.MOSTRAROBSERVACIONDECOMPROBANTES, chbMuestraObs, Nothing, chbMuestraObs.Text)

   End Sub

End Class