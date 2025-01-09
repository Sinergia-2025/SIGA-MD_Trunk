Option Explicit On
Option Strict On

Imports Eniac.Win

Public Class CategoriasImagenesABM

#Region "Overrides"

   Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)
      MyBase.OnLoad(e)
      Me.BotonImprimir.Visible = False
      Me.dgvDatos.DisplayLayout.Bands(0).Columns("Foto").Style = UltraWinGrid.ColumnStyle.Image
      Me.dgvDatos.DisplayLayout.Bands(0).Columns("FotoReverso").Style = UltraWinGrid.ColumnStyle.Image
   End Sub

   Protected Overrides Function GetDetalle(ByVal estado As StateForm) As Eniac.Win.BaseDetalle
      If estado = StateForm.Actualizar Then
         Return New CategoriasImagenesDetalle(DirectCast(Me.GetEntidad(), Eniac.Entidades.CategoriaImagen))
      End If
      Return New CategoriasImagenesDetalle(New Eniac.Entidades.CategoriaImagen)
   End Function

   Protected Overrides Function GetReglas() As Reglas.Base
      Return New Reglas.CategoriasImagenes()
   End Function

   Protected Overrides Function GetEntidad() As Entidades.Entidad
      MyBase.GetEntidad()
      Dim cate As Entidades.CategoriaImagen = New Entidades.CategoriaImagen
      With Me.dgvDatos.ActiveCell.Row
         cate.IdCategoriaImagen = Integer.Parse(.Cells(Entidades.CategoriaImagen.Columnas.IdCategoriaImagen.ToString()).Value.ToString())
         cate = New Reglas.CategoriasImagenes().GetUno(cate.IdCategoriaImagen)
      End With
      Return cate
   End Function

   Protected Overrides Sub FormatearGrilla()

      With Me.dgvDatos.DisplayLayout.Bands(0)
         .Columns(Entidades.CategoriaImagen.Columnas.IdCategoriaImagen.ToString()).Header.Caption = "Código"
         .Columns(Entidades.CategoriaImagen.Columnas.IdCategoriaImagen.ToString()).Width = 50

         .Columns(Entidades.CategoriaImagen.Columnas.IdCategoria.ToString()).Hidden = True
         .Columns(Entidades.CategoriaImagen.Columnas.IdTipoNave.ToString()).Hidden = True

         .Columns("NombreCategoria").Header.Caption = "Categoría"
         .Columns("NombreCategoria").Width = 150

         .Columns("NombreTipoNave").Header.Caption = "Tipo Nave"
         .Columns("NombreTipoNave").Width = 150

         .Columns("ColorFuente").Style = UltraWinGrid.ColumnStyle.Color
         .Columns("ColorFuente").Header.Caption = "Color Fuente"

         .Columns("ColorFuenteVto").Style = UltraWinGrid.ColumnStyle.Color
         .Columns("ColorFuenteVto").Header.Caption = "Color Fuente Vto"

         .Columns("FotoReverso").Header.Caption = "Foto R"
         .Columns("FotoReverso").Width = 100

         .Columns("Foto").Width = 100

      End With

   End Sub

#End Region

End Class