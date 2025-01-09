Option Explicit On
Option Strict On
Imports Eniac.Win

Public Class ContabilidadCentrosCostosABM

#Region "Overrides"

   Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)
      MyBase.OnLoad(e)
   End Sub

   Protected Overrides Sub Borrar()

      If Integer.Parse(Me.dgvDatos.ActiveRow.Cells(Entidades.ContabilidadCentroCosto.Columnas.IdCentroCosto.ToString()).Value.ToString()) = 1 Then
         ShowMessage("Este centro de costo no se puede eliminar")
      Else
         MyBase.Borrar()
      End If

   End Sub
   Protected Overrides Function GetDetalle(ByVal estado As StateForm) As Eniac.Win.BaseDetalle
      If estado = StateForm.Actualizar Then
         Return New ContabilidadCentrosCostosDetalle(DirectCast(Me.GetEntidad(), Entidades.ContabilidadCentroCosto))
      End If
      Return New ContabilidadCentrosCostosDetalle(New Entidades.ContabilidadCentroCosto)
   End Function

   Protected Overrides Function GetReglas() As Eniac.Reglas.Base
      Return New Reglas.ContabilidadCentrosCostos()
   End Function

   Protected Overrides Function GetEntidad() As Eniac.Entidades.Entidad

      Dim CentroCosto As Entidades.ContabilidadCentroCosto = New Entidades.ContabilidadCentroCosto
      Dim CentrosCostos As Reglas.ContabilidadCentrosCostos = New Reglas.ContabilidadCentrosCostos()

      With Me.dgvDatos.ActiveRow
         CentroCosto = CentrosCostos.GetUna(Integer.Parse(.Cells(Entidades.ContabilidadCentroCosto.Columnas.IdCentroCosto.ToString()).Value.ToString()))
      End With

      Return CentroCosto

   End Function

   Protected Overrides Sub FormatearGrilla()
      With Me.dgvDatos.DisplayLayout.Bands(0)
         .Columns(Entidades.ContabilidadCentroCosto.Columnas.IdCentroCosto.ToString()).Header.Caption = "Código CC"
         .Columns(Entidades.ContabilidadCentroCosto.Columnas.IdCentroCosto.ToString()).Width = 85
         .Columns(Entidades.ContabilidadCentroCosto.Columnas.IdCentroCosto.ToString()).CellAppearance.TextHAlign = HAlign.Right
         .Columns(Entidades.ContabilidadCentroCosto.Columnas.NombreCentroCosto.ToString()).Header.Caption = "Descripción CC"
         .Columns(Entidades.ContabilidadCentroCosto.Columnas.NombreCentroCosto.ToString()).Width = 250
         Me.dgvDatos.DisplayLayout.AutoFitStyle = UltraWinGrid.AutoFitStyle.ExtendLastColumn
      End With
   End Sub

#End Region

End Class