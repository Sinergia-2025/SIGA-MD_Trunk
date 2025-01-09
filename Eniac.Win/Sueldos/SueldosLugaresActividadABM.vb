Public Class SueldosLugaresActividadABM


#Region "Overrides"

   Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)
      MyBase.OnLoad(e)
      Me.BotonImprimir.Visible = False
   End Sub

   Protected Overrides Function GetDetalle(ByVal estado As StateForm) As Eniac.Win.BaseDetalle
      If estado = StateForm.Actualizar Then
         Return New SueldosLugaresActividadDetalle(DirectCast(Me.GetEntidad(), Entidades.SueldosLugarActividad))
      End If
      Return New SueldosLugaresActividadDetalle(New Entidades.SueldosLugarActividad())
   End Function

   Protected Overrides Function GetReglas() As Eniac.Reglas.Base
      Return New Reglas.SueldosLugaresActividad()
   End Function

   Protected Overrides Function GetEntidad() As Eniac.Entidades.Entidad
      Dim ent As Entidades.SueldosLugarActividad = New Entidades.SueldosLugarActividad()
      With Me.dgvDatos.SelectedCells(0).OwningRow
         ent = New Reglas.SueldosLugaresActividad().GetUno(Integer.Parse(.Cells(Entidades.SueldosLugarActividad.Columnas.IdLugarActividad.ToString()).Value.ToString()))
      End With
      Return ent
   End Function

   Protected Overrides Sub FormatearGrilla()
      With Me.dgvDatos
         .Columns(Entidades.SueldosLugarActividad.Columnas.IdLugarActividad.ToString()).HeaderText = "Código"
         .Columns(Entidades.SueldosLugarActividad.Columnas.IdLugarActividad.ToString()).Width = 70
         .Columns(Entidades.SueldosLugarActividad.Columnas.IdLugarActividad.ToString()).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
         .Columns(Entidades.SueldosLugarActividad.Columnas.NombreLugarActividad.ToString()).HeaderText = "Lugar de Actividad"
         .Columns(Entidades.SueldosLugarActividad.Columnas.NombreLugarActividad.ToString()).Width = 120
         .Columns(Entidades.SueldosLugarActividad.Columnas.NombreLugarActividad.ToString()).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
      End With
   End Sub

#End Region

End Class