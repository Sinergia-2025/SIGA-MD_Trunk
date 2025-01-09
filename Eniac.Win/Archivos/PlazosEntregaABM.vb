Public Class PlazosEntregaABM
#Region "Overrides"
   Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)
      MyBase.OnLoad(e)
      Me.tsbImprimir.Visible = False
   End Sub

   Protected Overrides Function GetDetalle(ByVal estado As StateForm) As BaseDetalle
      If estado = StateForm.Actualizar Then
         Return New PlazosEntregaDetalle(DirectCast(Me.GetEntidad(), Entidades.PlazoEntrega))
      End If
      Return New PlazosEntregaDetalle(New Entidades.PlazoEntrega)
   End Function

   Protected Overrides Function GetReglas() As Reglas.Base
      Return New Reglas.PlazosEntregas()
   End Function
   Protected Overrides Function GetEntidad() As Eniac.Entidades.Entidad
      Dim ePlazosEntregas = New Entidades.PlazoEntrega
      With dgvDatos.ActiveRow
         ePlazosEntregas = New Reglas.PlazosEntregas().GetUno(Integer.Parse(.Cells("IdPlazoEntrega").Value.ToString()))
      End With
      Return ePlazosEntregas
   End Function
   Protected Overrides Sub FormatearGrilla()
      With dgvDatos.DisplayLayout.Bands(0)
         Dim col As Integer = 0
         .Columns(Entidades.PlazoEntrega.Columnas.IdPlazoEntrega.ToString()).FormatearColumna("Código", col, 60, HAlign.Right)
         .Columns(Entidades.PlazoEntrega.Columnas.DescripcionPlazoentrega.ToString()).FormatearColumna("Descripción", col, 200)
         .Columns(Entidades.PlazoEntrega.Columnas.ActivoPlazoEntrega.ToString()).FormatearColumna("Activo", col, 90, HAlign.Right)
      End With
      dgvDatos.AgregarFiltroEnLinea({"DescripcionPlazoentrega", "IdPlazoEntrega"})
   End Sub
#End Region
End Class