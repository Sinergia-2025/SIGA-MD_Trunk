Public Class ContabilidadEstadosAsientosABM

#Region "Overrides"

   Protected Overrides Sub OnLoad(e As EventArgs)
      MyBase.OnLoad(e)
      tsbImprimir.Visible = False
   End Sub

   Protected Overrides Function GetDetalle(estado As StateForm) As BaseDetalle
      If estado = StateForm.Actualizar Then
         Return New ContabilidadEstadosAsientosDetalle(DirectCast(GetEntidad(), Entidades.ContabilidadEstadoAsiento))
      End If
      Return New ContabilidadEstadosAsientosDetalle(New Entidades.ContabilidadEstadoAsiento())
   End Function

   Protected Overrides Function GetReglas() As Reglas.Base
      Return New Reglas.ContabilidadEstadosAsientos()
   End Function

   Protected Overrides Function GetEntidad() As Entidades.Entidad
      With dgvDatos.ActiveRow
         Return New Reglas.ContabilidadEstadosAsientos().GetUno(Integer.Parse(.Cells(Entidades.ContabilidadEstadoAsiento.Columnas.IdEstadoAsiento.ToString()).Value.ToString()))
      End With
   End Function

   Protected Overrides Sub FormatearGrilla()
      With dgvDatos.DisplayLayout.Bands(0)
         For Each col As UltraGridColumn In .Columns
            col.CellActivation = Activation.ActivateOnly
         Next
         Dim pos = 0I
         .Columns(Entidades.ContabilidadEstadoAsiento.Columnas.IdEstadoAsiento.ToString()).FormatearColumna("Código", pos, 80, HAlign.Right)
         .Columns(Entidades.ContabilidadEstadoAsiento.Columnas.NombreEstadoAsiento.ToString()).FormatearColumna("Nombre", pos, 300)
         .Columns(Entidades.ContabilidadEstadoAsiento.Columnas.PorDefectoManual.ToString()).FormatearColumna("Por defecto Manual", pos, 80, HAlign.Center)
         .Columns(Entidades.ContabilidadEstadoAsiento.Columnas.PorDefectoAutomatico.ToString()).FormatearColumna("Por defecto Automático", pos, 80, HAlign.Center)
      End With
      dgvDatos.AgregarFiltroEnLinea({Entidades.ContabilidadEstadoAsiento.Columnas.NombreEstadoAsiento.ToString()})
   End Sub

#End Region

End Class