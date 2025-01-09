Public Class ucConfSueldos

   Protected Overrides Sub OnCargando(e As CancelableEventArgs)
      MyBase.OnCargando(e)

      'Sueldos
      txtSueldosConceptoAguinaldo.Text = Reglas.Publicos.SueldosConceptoAguinaldo.ToString()

   End Sub

   Protected Overrides Sub OnGrabando(e As CancelableEventArgs)
      MyBase.OnGrabando(e)

      'Sueldos
      ActualizarParametro(Entidades.Parametro.Parametros.SUELDOS_CONCEPTO_AGUINALDO, txtSueldosConceptoAguinaldo, Nothing, lblSueldosConceptoAguinaldo.Text)

   End Sub

End Class
