Public Class ucConfAppMovilesSoporte
   Protected Overrides Sub OnCargando(e As CancelableEventArgs)
      MyBase.OnCargando(e)

      'Simovil Soporte
      txtSimovilSoporteUsuarioDefault.Text = Reglas.Publicos.SimovilSoporteUsuarioDefault

   End Sub

   Protected Overrides Sub OnGrabando(e As CancelableEventArgs)
      MyBase.OnGrabando(e)

      'Simovil Soporte
      ActualizarParametro(Entidades.Parametro.Parametros.SIMOVILSOPORTEUSUARIODEFAULT, txtSimovilSoporteUsuarioDefault, Nothing, lblSimovilSoporteUsuarioDefault.Text)

   End Sub

End Class
