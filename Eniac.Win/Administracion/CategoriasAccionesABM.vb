Option Explicit On
Option Strict On
Imports Eniac.Win.Ayudante
Public Class CategoriasAccionesABM
#Region "Overrides"

   Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)
      MyBase.OnLoad(e)
      Me.BotonImprimir.Visible = False
   End Sub

   Protected Overrides Function GetDetalle(ByVal estado As StateForm) As Eniac.Win.BaseDetalle
      If estado = StateForm.Actualizar Then
         Return New CategoriasAccionesDetalle(DirectCast(Me.GetEntidad(), Entidades.CategoriaAccion))
      End If
      Return New CategoriasAccionesDetalle(New Entidades.CategoriaAccion)
   End Function

   Protected Overrides Function GetReglas() As Reglas.Base
      Return New Reglas.CategoriasAcciones()
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
      Dim cate As Entidades.CategoriaAccion = New Entidades.CategoriaAccion
      With Me.dgvDatos.ActiveCell.Row
         cate.IdCategoriaAccion = Integer.Parse(.Cells(Entidades.CategoriaAccion.Columnas.IdCategoriaAccion.ToString()).Value.ToString())
         cate = New Reglas.CategoriasAcciones().GetUno(cate.IdCategoriaAccion)
      End With
      Return cate
   End Function

   Protected Overrides Sub FormatearGrilla()
      With Me.dgvDatos.DisplayLayout.Bands(0)
         Grilla.FormatearColumna(.Columns(Entidades.CategoriaAccion.Columnas.IdCategoriaAccion.ToString()),
                                 "Código", 0, 50, HAlign.Right)
         Grilla.FormatearColumna(.Columns(Entidades.CategoriaAccion.Columnas.NombreCategoriaAccion.ToString()),
                                 "Nombre", 1, 150)
         Grilla.FormatearColumna(.Columns(Entidades.CategoriaAccion.Columnas.Pies.ToString()),
                                 "Pies", 2, 50, HAlign.Right)
         Grilla.FormatearColumna(.Columns(Entidades.CategoriaAccion.Columnas.CoeficienteDistribucionExpensas.ToString()),
                                 "Coeficiente p/ Expensas", 3, 100, HAlign.Right, , "N5")
      End With
   End Sub
#End Region
End Class