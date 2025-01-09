Public Class ZonasGeograficasABM

#Region "Overrides"

   Protected Overrides Function GetDetalle(estado As StateForm) As BaseDetalle
      If estado = StateForm.Actualizar Then
         Return New ZonasGeograficasDetalle(DirectCast(GetEntidad(), Entidades.ZonaGeografica))
      End If
      Return New ZonasGeograficasDetalle(New Entidades.ZonaGeografica())
   End Function

   Protected Overrides Function GetReglas() As Reglas.Base
      Return New Reglas.ZonasGeograficas()
   End Function

   Protected Overrides Sub Imprimir()
      MyBase.Imprimir()
      TryCatched(
         Sub()
            Using frmImprime = New VisorReportes("Eniac.Win.ZonasGeograficas.rdlc", "DSReportes_ZonasGeograficas", Me.dtDatos, True, 1) '# 1 = Cantidad Copias
               frmImprime.Text = "Zonas Geográficas"
               frmImprime.ShowDialog()
            End Using
         End Sub)
   End Sub

   Protected Overrides Function GetEntidad() As Eniac.Entidades.Entidad
      Dim zona As Entidades.ZonaGeografica
      With dgvDatos.ActiveCell.Row
         zona = New Reglas.ZonasGeograficas().GetUno((.Cells("IdZonaGeografica").Value.ToString()))
      End With
      Return zona
   End Function

   Protected Overrides Sub FormatearGrilla()
      dgvDatos.AgregarFiltroEnLinea({("NombreZonaGeografica")})

      With dgvDatos.DisplayLayout.Bands(0)
         Dim pos As Integer = 0
         .Columns("IdZonaGeografica").FormatearColumna("Código", pos, 170, HAlign.Right)
         .Columns("NombreZonaGeografica").FormatearColumna("Nombre", pos, 120, HAlign.Right)
      End With
   End Sub

#End Region

End Class