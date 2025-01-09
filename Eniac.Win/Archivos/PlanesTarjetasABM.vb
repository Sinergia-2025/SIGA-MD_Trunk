Option Strict On
Option Explicit On
Imports Infragistics.Win.UltraWinGrid

Public Class PlanesTarjetasABM

#Region "Overrides"

   Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)
      MyBase.OnLoad(e)
   End Sub
   Protected Overrides Function GetDetalle(ByVal estado As StateForm) As Eniac.Win.BaseDetalle
      If estado = StateForm.Actualizar Then
         Return New PlanesTarjetasDetalle(DirectCast(Me.GetEntidad(), Entidades.PlanTarjeta))
      End If
      Return New PlanesTarjetasDetalle(New Entidades.PlanTarjeta())
   End Function
   Protected Overrides Function GetReglas() As Eniac.Reglas.Base
      Return New Eniac.Reglas.PlanesTarjetas()
   End Function

   Protected Overrides Function GetEntidad() As Eniac.Entidades.Entidad
      With Me.dgvDatos.ActiveRow
         Return New Reglas.PlanesTarjetas().GetUno(Int32.Parse(.Cells("IdPlanTarjeta").Value.ToString()))
      End With
   End Function
   Protected Overrides Sub FormatearGrilla()
      With Me.dgvDatos.DisplayLayout.Bands(0)
         For Each columna As UltraGridColumn In .Columns
            columna.Hidden = True
         Next

         .Columns(Entidades.PlanTarjeta.Columnas.IdPlanTarjeta.ToString()).Hidden = False
         .Columns(Entidades.PlanTarjeta.Columnas.IdPlanTarjeta.ToString()).Header.VisiblePosition = 0
         .Columns(Entidades.PlanTarjeta.Columnas.IdPlanTarjeta.ToString()).Header.Caption = "Código"
         .Columns(Entidades.PlanTarjeta.Columnas.IdPlanTarjeta.ToString()).CellAppearance.TextHAlign = HAlign.Right

         .Columns(Entidades.PlanTarjeta.Columnas.NombrePlanTarjeta.ToString()).Hidden = False
         .Columns(Entidades.PlanTarjeta.Columnas.NombrePlanTarjeta.ToString()).Header.VisiblePosition = 1
         .Columns(Entidades.PlanTarjeta.Columnas.NombrePlanTarjeta.ToString()).Header.Caption = "Nombre Plan"
         .Columns(Entidades.PlanTarjeta.Columnas.NombrePlanTarjeta.ToString()).Width = 300

         .Columns(Entidades.PlanTarjeta.Columnas.CuotasDesde.ToString()).Hidden = False
         .Columns(Entidades.PlanTarjeta.Columnas.CuotasDesde.ToString()).Header.VisiblePosition = 2
         .Columns(Entidades.PlanTarjeta.Columnas.CuotasDesde.ToString()).Header.Caption = "Desde"
         .Columns(Entidades.PlanTarjeta.Columnas.CuotasDesde.ToString()).Width = 60
         .Columns(Entidades.PlanTarjeta.Columnas.CuotasDesde.ToString()).CellAppearance.TextHAlign = HAlign.Center

         .Columns(Entidades.PlanTarjeta.Columnas.CuotasHasta.ToString()).Hidden = False
         .Columns(Entidades.PlanTarjeta.Columnas.CuotasHasta.ToString()).Header.VisiblePosition = 3
         .Columns(Entidades.PlanTarjeta.Columnas.CuotasHasta.ToString()).Header.Caption = "Hasta"
         .Columns(Entidades.PlanTarjeta.Columnas.CuotasHasta.ToString()).Width = 60
         .Columns(Entidades.PlanTarjeta.Columnas.CuotasHasta.ToString()).CellAppearance.TextHAlign = HAlign.Center

         .Columns(Entidades.PlanTarjeta.Columnas.PorcDescRec.ToString()).Hidden = False
         .Columns(Entidades.PlanTarjeta.Columnas.PorcDescRec.ToString()).Header.VisiblePosition = 4
         .Columns(Entidades.PlanTarjeta.Columnas.PorcDescRec.ToString()).Header.Caption = "D/R"
         .Columns(Entidades.PlanTarjeta.Columnas.PorcDescRec.ToString()).Width = 60
         .Columns(Entidades.PlanTarjeta.Columnas.PorcDescRec.ToString()).CellAppearance.TextHAlign = HAlign.Right
         .Columns(Entidades.PlanTarjeta.Columnas.PorcDescRec.ToString()).Format = "N2"

         .Columns(Entidades.PlanTarjeta.Columnas.IdTarjeta.ToString()).Header.Caption = "Código Tarjeta"
         .Columns(Entidades.PlanTarjeta.Columnas.IdTarjeta.ToString()).CellAppearance.TextHAlign = HAlign.Right

         .Columns(Entidades.Tarjeta.Columnas.NombreTarjeta.ToString()).Hidden = False
         .Columns(Entidades.Tarjeta.Columnas.NombreTarjeta.ToString()).Header.VisiblePosition = 5
         .Columns(Entidades.Tarjeta.Columnas.NombreTarjeta.ToString()).Header.Caption = "Tarjeta"
         .Columns(Entidades.Tarjeta.Columnas.NombreTarjeta.ToString()).Width = 150

         .Columns(Entidades.PlanTarjeta.Columnas.IdBanco.ToString()).Header.Caption = "Código Banco"
         .Columns(Entidades.PlanTarjeta.Columnas.IdBanco.ToString()).CellAppearance.TextHAlign = HAlign.Right

         .Columns("NombreBanco").Hidden = False
         .Columns("NombreBanco").Header.VisiblePosition = 6
         .Columns("NombreBanco").Header.Caption = "Banco"
         .Columns("NombreBanco").Width = 150

         .Columns(Entidades.PlanTarjeta.Columnas.Activo.ToString()).Hidden = False
         .Columns(Entidades.PlanTarjeta.Columnas.Activo.ToString()).Header.VisiblePosition = 7
         .Columns(Entidades.PlanTarjeta.Columnas.Activo.ToString()).Header.Caption = "Activo"
         .Columns(Entidades.PlanTarjeta.Columnas.Activo.ToString()).Width = 60
         .Columns(Entidades.PlanTarjeta.Columnas.Activo.ToString()).CellAppearance.TextHAlign = HAlign.Center

      End With
   End Sub

#End Region

End Class
