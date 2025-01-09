Public Class TiposCalendariosABM
#Region "Overrides"

   Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)
      MyBase.OnLoad(e)
      'Me.BotonImprimir.Visible = False
   End Sub
   Protected Overrides Function GetDetalle(ByVal estado As StateForm) As Eniac.Win.BaseDetalle
      If estado = StateForm.Actualizar Then
         Return New TiposCalendariosDetalle(DirectCast(Me.GetEntidad(), Entidades.TipoCalendario))
      End If
      Return New TiposCalendariosDetalle(New Eniac.Entidades.TipoCalendario())
   End Function
   Protected Overrides Function GetReglas() As Eniac.Reglas.Base
      Return New Eniac.Reglas.TiposCalendarios()
   End Function

   Protected Overrides Function GetEntidad() As Eniac.Entidades.Entidad
      MyBase.GetEntidad()
      With Me.dgvDatos.ActiveRow
         Return New Reglas.TiposCalendarios().GetUno(Convert.ToInt16(.Cells(Entidades.TipoCalendario.Columnas.IdTipoCalendario.ToString()).Value.ToString()))
      End With
   End Function
   Protected Overrides Sub FormatearGrilla()
      With Me.dgvDatos.DisplayLayout.Bands(0)
         Dim col As Integer = 0
         .Columns(Entidades.TipoCalendario.Columnas.IdTipoCalendario.ToString()).FormatearColumna("Código", col, 70, HAlign.Right)
         .Columns(Entidades.TipoCalendario.Columnas.NombreTipoCalendario.ToString()).FormatearColumna("Nombre", col, 200)
      End With
   End Sub

#End Region

End Class