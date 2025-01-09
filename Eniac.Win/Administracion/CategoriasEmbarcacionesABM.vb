Option Explicit On
Option Strict On

Imports Eniac.Win

Public Class CategoriasEmbarcacionesABM

#Region "Overrides"

   Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)
      MyBase.OnLoad(e)
      Me.BotonImprimir.Visible = False
   End Sub

   Protected Overrides Function GetDetalle(ByVal estado As StateForm) As BaseDetalle
      If estado = StateForm.Actualizar Then
         Return New CategoriasEmbarcacionesDetalle(DirectCast(Me.GetEntidad(), Entidades.CategoriaEmbarcacion))
      End If
      Return New CategoriasEmbarcacionesDetalle(New Entidades.CategoriaEmbarcacion)
   End Function

   Protected Overrides Function GetReglas() As Reglas.Base
      Return New Reglas.CategoriasEmbarcaciones()
   End Function

   'Protected Overrides Sub Imprimir()
   '   MyBase.Imprimir()
   '   Try
   '      Me.Cursor = Cursors.WaitCursor
   '      Dim frmImprime As VisorReportes = New VisorReportes("Eniac.SiSeN.Win.CategoriasCamas.rdlc", "SistemaDataSet_CategoriasCamas", Me.dtDatos, True)
   '      frmImprime.Text = "Categorias Camas"
   '      frmImprime.Show()
   '      Me.Cursor = Cursors.Default
   '   Catch ex As Exception
   '      MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
   '   End Try
   'End Sub

   Protected Overrides Function GetEntidad() As Entidades.Entidad
      MyBase.GetEntidad()
      Dim cate As Entidades.CategoriaEmbarcacion = New Entidades.CategoriaEmbarcacion
      With Me.dgvDatos.ActiveCell.Row
         cate.IdCategoriaEmbarcacion = Integer.Parse(.Cells(Entidades.CategoriaEmbarcacion.Columnas.IdCategoriaEmbarcacion.ToString()).Value.ToString())
         cate = New Reglas.CategoriasEmbarcaciones().GetUno(cate.IdCategoriaEmbarcacion)
      End With
      Return cate
   End Function

   Protected Overrides Sub FormatearGrilla()
      With Me.dgvDatos.DisplayLayout.Bands(0)
         .Columns(Entidades.CategoriaEmbarcacion.Columnas.IdCategoriaEmbarcacion.ToString()).Header.Caption = "Código"
         .Columns(Entidades.CategoriaEmbarcacion.Columnas.IdCategoriaEmbarcacion.ToString()).Width = 50
         .Columns(Entidades.CategoriaEmbarcacion.Columnas.IdCategoriaEmbarcacion.ToString()).CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right
         .Columns(Entidades.CategoriaEmbarcacion.Columnas.NombreCategoriaEmbarcacion.ToString()).Header.Caption = "Nombre"
         .Columns(Entidades.CategoriaEmbarcacion.Columnas.NombreCategoriaEmbarcacion.ToString()).Width = 150
         .Columns(Entidades.CategoriaEmbarcacion.Columnas.IdTipoEmbarcacion.ToString()).Hidden = True
         .Columns(Entidades.CategoriaEmbarcacion.Columnas.NombreTipoEmbarcacion.ToString()).Header.Caption = "Tipo"
         .Columns(Entidades.CategoriaEmbarcacion.Columnas.NombreTipoEmbarcacion.ToString()).Width = 100
         .Columns(Entidades.CategoriaEmbarcacion.Columnas.ImporteExpensas.ToString()).Header.Caption = "$ Expensas"
         .Columns(Entidades.CategoriaEmbarcacion.Columnas.ImporteExpensas.ToString()).Width = 80
         .Columns(Entidades.CategoriaEmbarcacion.Columnas.ImporteExpensas.ToString()).CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right
         .Columns(Entidades.CategoriaEmbarcacion.Columnas.ImporteExpensas.ToString()).Format = "N2"
         .Columns(Entidades.CategoriaEmbarcacion.Columnas.ImporteAlquiler.ToString()).Header.Caption = "$ Alquiler"
         .Columns(Entidades.CategoriaEmbarcacion.Columnas.ImporteAlquiler.ToString()).Width = 80
         .Columns(Entidades.CategoriaEmbarcacion.Columnas.ImporteAlquiler.ToString()).CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right
         .Columns(Entidades.CategoriaEmbarcacion.Columnas.ImporteAlquiler.ToString()).Format = "N2"
         .Columns(Entidades.CategoriaEmbarcacion.Columnas.PorcDescAlquiler.ToString()).Header.Caption = "% D.Alq."
         .Columns(Entidades.CategoriaEmbarcacion.Columnas.PorcDescAlquiler.ToString()).Width = 70
         .Columns(Entidades.CategoriaEmbarcacion.Columnas.PorcDescAlquiler.ToString()).CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right
         .Columns(Entidades.CategoriaEmbarcacion.Columnas.PorcDescAlquiler.ToString()).Format = "N4"
         .Columns(Entidades.CategoriaEmbarcacion.Columnas.ImporteGastosAdmin.ToString()).Header.Caption = "$ Gtos. Admin."
         .Columns(Entidades.CategoriaEmbarcacion.Columnas.ImporteGastosAdmin.ToString()).Width = 80
         .Columns(Entidades.CategoriaEmbarcacion.Columnas.ImporteGastosAdmin.ToString()).CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right
         .Columns(Entidades.CategoriaEmbarcacion.Columnas.ImporteGastosAdmin.ToString()).Format = "N2"
         .Columns(Entidades.CategoriaEmbarcacion.Columnas.ImporteGastosIntermAlq.ToString()).Header.Caption = "$ Gtos. Int. Alquiler"
         .Columns(Entidades.CategoriaEmbarcacion.Columnas.ImporteGastosIntermAlq.ToString()).Width = 80
         .Columns(Entidades.CategoriaEmbarcacion.Columnas.ImporteGastosIntermAlq.ToString()).CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right
         .Columns(Entidades.CategoriaEmbarcacion.Columnas.ImporteGastosIntermAlq.ToString()).Format = "N2"
         'PE-31303
         .Columns(Entidades.Categoria.Columnas.IdInteres.ToString()).Hidden = True
         .Columns(Eniac.Entidades.Interes.Columnas.NombreInteres.ToString()).Header.Caption = "Interés"
         .Columns(Eniac.Entidades.Interes.Columnas.NombreInteres.ToString()).Width = 280
         '-.PE-31514.- 
         .Columns(Eniac.Entidades.Interes.Columnas.NombreInteres.ToString()).Hidden = True
      End With
   End Sub

#End Region

End Class