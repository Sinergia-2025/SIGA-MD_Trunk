Option Explicit On
Option Strict On

Imports Eniac.Win

Public Class TiposEmbarcacionesABM

#Region "Overrides"

   Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)
      MyBase.OnLoad(e)
      Me.tsbImprimir.Visible = False
   End Sub
   Protected Overrides Function GetDetalle(ByVal estado As StateForm) As Win.BaseDetalle
      If estado = StateForm.Actualizar Then
         Return New TiposEmbarcacionesDetalle(DirectCast(Me.GetEntidad(), Eniac.Entidades.TipoEmbarcacion))
      End If
      Return New TiposEmbarcacionesDetalle(New Eniac.Entidades.TipoEmbarcacion)
   End Function
   Protected Overrides Function GetReglas() As Eniac.Reglas.Base
      Return New Reglas.TiposEmbarcaciones()
   End Function
   Protected Overrides Function GetEntidad() As Entidades.Entidad
      MyBase.GetEntidad()
      Dim TipoEmbarcacion As Eniac.Entidades.TipoEmbarcacion = New Entidades.TipoEmbarcacion
      With Me.dgvDatos.ActiveCell.Row
         TipoEmbarcacion = New Reglas.TiposEmbarcaciones().GetUno(Integer.Parse(.Cells(Entidades.TipoEmbarcacion.Columnas.IdTipoEmbarcacion.ToString()).Value.ToString()))
      End With
      Return TipoEmbarcacion
   End Function
   Protected Overrides Sub FormatearGrilla()
      With Me.dgvDatos.DisplayLayout.Bands(0)
         ''.SelectionMode = DataGridViewSelectionMode.FullRowSelect
         .Columns(Entidades.TipoEmbarcacion.Columnas.IdTipoEmbarcacion.ToString()).Header.Caption = "Tipo"
         .Columns(Entidades.TipoEmbarcacion.Columnas.IdTipoEmbarcacion.ToString()).Width = 50
         .Columns(Entidades.TipoEmbarcacion.Columnas.NombreTipoEmbarcacion.ToString()).Header.Caption = "Descripción"
         .Columns(Entidades.TipoEmbarcacion.Columnas.NombreTipoEmbarcacion.ToString()).Width = 200
         .Columns(Entidades.TipoEmbarcacion.Columnas.NombreTipoEmbarcacion.ToString()).AutoSizeMode = Infragistics.Win.UltraWinGrid.ColumnAutoSizeMode.AllRowsInBand
      End With
   End Sub

#End Region

End Class