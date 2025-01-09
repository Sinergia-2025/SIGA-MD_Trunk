Option Strict On
Option Explicit On

Public Class ContabilidadRenumeracionAsientos
   Private _publicos As Publicos

   Protected Overrides Sub OnLoad(e As EventArgs)
      MyBase.OnLoad(e)

      Try
         _publicos = New Publicos()

         _publicos.CargaComboContabilidadEjercicio(cmbEjercicio)


         Refrescar()

      Catch ex As Exception
         ShowError(ex)
      End Try

   End Sub

   Private Sub tsbRefrescar_Click(sender As Object, e As EventArgs) Handles tsbRefrescar.Click
      Try
         Refrescar()
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub
   Private Sub tsbGenerarAsientos_Click(sender As Object, e As EventArgs) Handles tsbGenerarAsientos.Click
      Try
         If ValidaEjecucion() Then
            Dim sw As Stopwatch = New Stopwatch()

            If ShowPregunta(String.Format("¿Desea renumerar los asientos del ejercicio {0}?", cmbEjercicio.Text), MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.Yes Then
               Cursor = Cursors.WaitCursor
               sw.Start()
               RenumerarAsientos()
               sw.Stop()

               Refrescar()

               ShowMessage(String.Format("Renumeración realizado con Exito!!! Tiempo transcurrido: {0}", sw.Elapsed.ToString()))
            End If
         End If
      Catch ex As Exception
         ShowError(ex)
      Finally
         Cursor = Cursors.Default
      End Try
   End Sub

   Private Sub tsbSalir_Click(sender As Object, e As EventArgs) Handles tsbSalir.Click
      Close()
   End Sub


   Private Sub Refrescar()
      cmbEjercicio.SelectedIndex = -1
   End Sub


   Private Function ValidaEjecucion() As Boolean
      If cmbEjercicio.SelectedIndex = -1 Then
         ShowMessage("Debe seleccionar un Ejercicio Contable")
         cmbEjercicio.Focus()
         Return False
      End If

      Return True
   End Function

   Private Sub RenumerarAsientos()
      Dim idEjercicio As Integer = ObjectExtensions.ValorNumericoPorDefecto(cmbEjercicio.SelectedValue, 0I)
      Dim rAsientos As Reglas.ContabilidadAsientos = New Reglas.ContabilidadAsientos()

      AddHandler rAsientos.AvanceRenumerarAsientos, Sub(sender, e)
                                                       tssInfo.Text = e.Estado
                                                       Application.DoEvents()
                                                    End Sub
      rAsientos.EjecutaRenumerarAsientos(idEjercicio)
      tssInfo.Text = String.Empty
   End Sub

End Class