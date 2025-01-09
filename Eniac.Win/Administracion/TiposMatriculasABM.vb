Option Explicit On
Option Strict On

Imports Eniac.Win

Public Class TiposMatriculasABM

#Region "Overrides"

   Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)
      MyBase.OnLoad(e)
      Me.tsbImprimir.Visible = False
   End Sub
   Protected Overrides Function GetDetalle(ByVal estado As StateForm) As Eniac.Win.BaseDetalle
      If estado = StateForm.Actualizar Then
         Return New TiposMatriculasDetalle(DirectCast(Me.GetEntidad(), Entidades.TipoMatricula))
      End If
      Return New TiposMatriculasDetalle(New Entidades.TipoMatricula)
   End Function
   Protected Overrides Function GetReglas() As Reglas.Base
      Return New Reglas.TiposMatriculas()
   End Function
   Protected Overrides Function GetEntidad() As Entidades.Entidad
      MyBase.GetEntidad()
      Dim TipoMatricula As Entidades.TipoMatricula = New Entidades.TipoMatricula
      With Me.dgvDatos.ActiveCell.Row
         TipoMatricula = New Reglas.TiposMatriculas().GetUno(Integer.Parse(.Cells(Entidades.TipoMatricula.Columnas.IdTipoMatricula.ToString()).Value.ToString()))
      End With
      Return TipoMatricula
   End Function
   Protected Overrides Sub FormatearGrilla()
      With Me.dgvDatos.DisplayLayout.Bands(0)
         ''.SelectionMode = DataGridViewSelectionMode.FullRowSelect
         .Columns(Entidades.TipoMatricula.Columnas.IdTipoMatricula.ToString()).Header.Caption = "Tipo"
         .Columns(Entidades.TipoMatricula.Columnas.IdTipoMatricula.ToString()).Width = 50
         .Columns(Entidades.TipoMatricula.Columnas.NombreTipoMatricula.ToString()).Header.Caption = "Descripción"
         .Columns(Entidades.TipoMatricula.Columnas.NombreTipoMatricula.ToString()).Width = 200
         .Columns(Entidades.TipoMatricula.Columnas.NombreTipoMatricula.ToString()).AutoSizeMode = Infragistics.Win.UltraWinGrid.ColumnAutoSizeMode.AllRowsInBand
         .Columns(Entidades.TipoMatricula.Columnas.TieneNumeros.ToString()).Header.Caption = "Numeros"
         .Columns(Entidades.TipoMatricula.Columnas.TieneNumeros.ToString()).Width = 60
      End With
   End Sub

#End Region

End Class