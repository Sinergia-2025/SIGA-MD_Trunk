Option Explicit On
Option Strict On

Imports Eniac.Win

Public Class TiposTimonelesABM

#Region "Overrides"

   Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)
      MyBase.OnLoad(e)
      Me.tsbImprimir.Visible = False
   End Sub
   Protected Overrides Function GetDetalle(ByVal estado As StateForm) As Eniac.Win.BaseDetalle
      If estado = StateForm.Actualizar Then
         Return New TiposTimonelesDetalle(DirectCast(Me.GetEntidad(), Entidades.TipoTimonel))
      End If
      Return New TiposTimonelesDetalle(New Entidades.TipoTimonel)
   End Function
   Protected Overrides Function GetReglas() As Reglas.Base
      Return New Reglas.TiposTimoneles()
   End Function
   Protected Overrides Function GetEntidad() As Entidades.Entidad
      MyBase.GetEntidad()
      Dim TipoTimonel As Entidades.TipoTimonel = New Entidades.TipoTimonel
      With Me.dgvDatos.ActiveCell.Row
         TipoTimonel.IdTipoTimonel = CInt(.Cells(Entidades.TipoTimonel.Columnas.IdTipoTimonel.ToString()).Value.ToString())
         TipoTimonel.NombreTipoTimonel = .Cells(Entidades.TipoTimonel.Columnas.NombreTipoTimonel.ToString()).Value.ToString()
         TipoTimonel.Prefijo = .Cells(Entidades.TipoTimonel.Columnas.Prefijo.ToString()).Value.ToString()
      End With
      Return TipoTimonel
   End Function
   Protected Overrides Sub FormatearGrilla()
      With Me.dgvDatos.DisplayLayout.Bands(0)
         ''.SelectionMode = DataGridViewSelectionMode.FullRowSelect
         .Columns(Entidades.TipoTimonel.Columnas.IdTipoTimonel.ToString()).Header.Caption = "Tipo"
         .Columns(Entidades.TipoTimonel.Columnas.IdTipoTimonel.ToString()).Width = 50
         .Columns(Entidades.TipoTimonel.Columnas.NombreTipoTimonel.ToString()).Header.Caption = "Descripción"
         .Columns(Entidades.TipoTimonel.Columnas.NombreTipoTimonel.ToString()).Width = 200
         .Columns(Entidades.TipoTimonel.Columnas.NombreTipoTimonel.ToString()).AutoSizeMode = Infragistics.Win.UltraWinGrid.ColumnAutoSizeMode.AllRowsInBand
         .Columns(Entidades.TipoTimonel.Columnas.Prefijo.ToString()).Header.Caption = "PreFijo"
         .Columns(Entidades.TipoTimonel.Columnas.Prefijo.ToString()).Width = 50
      End With
   End Sub

#End Region

End Class