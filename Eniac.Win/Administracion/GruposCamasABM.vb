Public Class GruposCamasABM

#Region "Overrides"

   Protected Overrides Sub OnLoad(e As EventArgs)
      MyBase.OnLoad(e)
      Me.tsbImprimir.Visible = False
   End Sub

   Protected Overrides Function GetDetalle(estado As StateForm) As BaseDetalle
      If estado = StateForm.Actualizar Then
         Return New GruposCamasDetalle(DirectCast(GetEntidad(), Entidades.GrupoCama))
      End If
      Return New GruposCamasDetalle(New Entidades.GrupoCama())
   End Function

   Protected Overrides Function GetReglas() As Reglas.Base
      Return New Reglas.GruposCamas()
   End Function

   Protected Overrides Function GetEntidad() As Entidades.Entidad
      With dgvDatos.ActiveRow
         Return New Reglas.GruposCamas().GetUno(Integer.Parse(.Cells(Entidades.GrupoCama.Columnas.IdGrupoCama.ToString()).Value.ToString()))
      End With
   End Function

   Protected Overrides Sub FormatearGrilla()
      With dgvDatos.DisplayLayout.Bands(0)
         For Each col As UltraGridColumn In .Columns
            col.CellActivation = Activation.ActivateOnly
         Next

         Dim pos = 0I
         .Columns(Entidades.GrupoCama.Columnas.IdGrupoCama.ToString()).FormatearColumna("Código", pos, 80, HAlign.Right)
         .Columns(Entidades.GrupoCama.Columnas.NombreGrupoCama.ToString()).FormatearColumna("Nombre", pos, 300)
      End With

      dgvDatos.AgregarFiltroEnLinea({Entidades.GrupoCama.Columnas.NombreGrupoCama.ToString()})
   End Sub

#End Region

End Class