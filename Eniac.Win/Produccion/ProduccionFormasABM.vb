Public Class ProduccionFormasABM

#Region "Overrides"

   Protected Overrides Sub OnLoad(e As EventArgs)
      MyBase.OnLoad(e)
   End Sub
   Protected Overrides Function GetDetalle(estado As StateForm) As Eniac.Win.BaseDetalle
      If estado = StateForm.Actualizar Then
         Return New ProduccionFormasDetalle(DirectCast(GetEntidad(), Entidades.ProduccionForma))
      End If
      Return New ProduccionFormasDetalle(New Entidades.ProduccionForma())
   End Function
   Protected Overrides Function GetReglas() As Reglas.Base
      Return New Reglas.ProduccionFormas()
   End Function

   Protected Overrides Function GetEntidad() As Entidades.Entidad
      With dgvDatos.ActiveRow
         Return New Reglas.ProduccionFormas().GetUno(Integer.Parse(.Cells("IdProduccionForma").Value.ToString()))
      End With
   End Function
   Protected Overrides Sub FormatearGrilla()
      With dgvDatos.DisplayLayout.Bands(0)
         For Each columna In .Columns.OfType(Of UltraGridColumn)
            columna.Hidden = True
         Next
         Dim col = 0I
         .Columns(Entidades.ProduccionForma.Columnas.IdProduccionForma.ToString()).FormatearColumna("Código", col, 70, HAlign.Right)
         .Columns(Entidades.ProduccionForma.Columnas.NombreProduccionForma.ToString()).FormatearColumna("Nombre Forma", col, 300)
         .Columns(Entidades.ProduccionForma.Columnas.FormulaCalculoKilaje.ToString()).FormatearColumna("Fórmula", col, 500)
      End With
      dgvDatos.AgregarFiltroEnLinea({Entidades.ProduccionForma.Columnas.NombreProduccionForma.ToString(),
                                     Entidades.ProduccionForma.Columnas.FormulaCalculoKilaje.ToString()})
   End Sub

#End Region

End Class