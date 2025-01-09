Imports Eniac.Reglas.ServiciosRest.Turismo.SincronizacionSubidaMovilTurismo

Public Class SincronizacionSubidaMovilTurismoSincronizar

   Public Property AccionSeleccionada As AccionSincronizacion?

   Private Sub btnSubir_Click(sender As Object, e As EventArgs) Handles btnSubir.Click
      Aceptar(AccionSincronizacion.Subir)
   End Sub

   Private Sub btnDescargar_Click(sender As Object, e As EventArgs) Handles btnDescargar.Click
      Aceptar(AccionSincronizacion.Descargar)
   End Sub

   Private Sub btnSubirDescargar_Click(sender As Object, e As EventArgs) Handles btnSubirDescargar.Click
      Aceptar(AccionSincronizacion.SubirDescargar)
   End Sub

   Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
      Cancelar()
   End Sub

   Private Sub Aceptar(acc As AccionSincronizacion)
      Try
         AccionSeleccionada = acc
         DialogResult = Windows.Forms.DialogResult.OK
         Close()
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub
   Private Sub Cancelar()
      Try
         AccionSeleccionada = Nothing
         DialogResult = Windows.Forms.DialogResult.Cancel
         Close()
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

End Class