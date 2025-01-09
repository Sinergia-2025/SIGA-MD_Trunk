Public Class ucConfGenerales
   Protected Overrides Sub OnCargando(e As CancelableEventArgs)
      MyBase.OnCargando(e)

      'Generales
      Dim generalesSubtotalesEnGrillas = Reglas.Publicos.Generales.SubtotalesEnGrillas
      Select Case generalesSubtotalesEnGrillas
         Case Reglas.Publicos.Generales.UbicacionSubtotalesEnGrillas.InGroupByRows
            radGeneralesSubtotalesEnGrillas_FilaAgrupador.Checked = True
         Case Reglas.Publicos.Generales.UbicacionSubtotalesEnGrillas.GroupByRowsFooter
            radGeneralesSubtotalesEnGrillas_FinalDelGrupo.Checked = True
         Case Else

      End Select

   End Sub

   Protected Overrides Sub OnGrabando(e As CancelableEventArgs)
      MyBase.OnGrabando(e)

      'Generales
      Dim generalesSubtotalesEnGrillas As Reglas.Publicos.Generales.UbicacionSubtotalesEnGrillas
      If radGeneralesSubtotalesEnGrillas_FilaAgrupador.Checked Then
         generalesSubtotalesEnGrillas = Reglas.Publicos.Generales.UbicacionSubtotalesEnGrillas.InGroupByRows
      ElseIf radGeneralesSubtotalesEnGrillas_FinalDelGrupo.Checked Then
         generalesSubtotalesEnGrillas = Reglas.Publicos.Generales.UbicacionSubtotalesEnGrillas.GroupByRowsFooter
      Else
         generalesSubtotalesEnGrillas = Reglas.Publicos.Generales.UbicacionSubtotalesEnGrillas.InGroupByRows
      End If
      ActualizarParametroTexto(Entidades.Parametro.Parametros.GENERALESSUBTOTALESENGRILLAS, generalesSubtotalesEnGrillas.ToString(), Nothing, "Mostrar los totales de los grupos en...")

   End Sub

   Private Sub radGeneralesSubtotalesEnGrillas_CheckedChanged(sender As Object, e As EventArgs) Handles radGeneralesSubtotalesEnGrillas_FinalDelGrupo.CheckedChanged, radGeneralesSubtotalesEnGrillas_FilaAgrupador.CheckedChanged
      If Inicializada Then
         FindForm().TryCatched(
            Sub()
               If radGeneralesSubtotalesEnGrillas_FilaAgrupador.Checked Then
                  picGeneralesSubtotalesEnGrillas.Image = My.Resources.ParametrosGeneralesTotalesCabeceraGrupo
               ElseIf radGeneralesSubtotalesEnGrillas_FinalDelGrupo.Checked Then
                  picGeneralesSubtotalesEnGrillas.Image = My.Resources.ParametrosGeneralesTotalesPieGrupo
               Else
                  picGeneralesSubtotalesEnGrillas.Image = picGeneralesSubtotalesEnGrillas.ErrorImage
               End If
            End Sub)
      End If
   End Sub

End Class