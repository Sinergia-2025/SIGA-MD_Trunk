Option Explicit On
Option Strict On

Imports Eniac.Win

Public Class CategoriasCamasABM

#Region "Overrides"

   Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)
      MyBase.OnLoad(e)
      Me.BotonImprimir.Visible = False
   End Sub

   Protected Overrides Function GetDetalle(ByVal estado As StateForm) As Eniac.Win.BaseDetalle
      If estado = StateForm.Actualizar Then
         Return New CategoriasCamasDetalle(DirectCast(Me.GetEntidad(), Eniac.Entidades.CategoriaCama))
      End If
      Return New CategoriasCamasDetalle(New Eniac.Entidades.CategoriaCama())
   End Function

   Protected Overrides Function GetReglas() As Reglas.Base
      Return New Reglas.CategoriasCamas()
   End Function

   Protected Overrides Function GetEntidad() As Entidades.Entidad
      MyBase.GetEntidad()
      Dim cate As Entidades.CategoriaCama = New Entidades.CategoriaCama
      With Me.dgvDatos.ActiveCell.Row
         cate.IdCategoriaCama = Integer.Parse(.Cells(Entidades.CategoriaCama.Columnas.IdCategoriaCama.ToString()).Value.ToString())
         cate = New Reglas.CategoriasCamas().GetUno(cate.IdCategoriaCama)
      End With
      Return cate
   End Function

   Protected Overrides Sub FormatearGrilla()

      With Me.dgvDatos.DisplayLayout.Bands(0)
         .Columns(Entidades.CategoriaCama.Columnas.IdCategoriaCama.ToString()).Header.Caption = "Código"
         .Columns(Entidades.CategoriaCama.Columnas.IdCategoriaCama.ToString()).Width = 50
         .Columns(Entidades.CategoriaCama.Columnas.IdCategoriaCama.ToString()).CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right
         .Columns(Entidades.CategoriaCama.Columnas.NombreCategoriaCama.ToString()).Header.Caption = "Nombre"
         .Columns(Entidades.CategoriaCama.Columnas.NombreCategoriaCama.ToString()).Width = 150

         .Columns(Entidades.CategoriaCama.Columnas.Alto.ToString()).Header.Caption = "Alto"
         .Columns(Entidades.CategoriaCama.Columnas.Alto.ToString()).Width = 70
         .Columns(Entidades.CategoriaCama.Columnas.Alto.ToString()).CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right
            .Columns(Entidades.CategoriaCama.Columnas.Ancho.ToString()).Header.Caption = "Ancho"
         .Columns(Entidades.CategoriaCama.Columnas.Ancho.ToString()).Width = 70
         .Columns(Entidades.CategoriaCama.Columnas.Ancho.ToString()).CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right
            .Columns(Entidades.CategoriaCama.Columnas.Largo.ToString()).Header.Caption = "Largo"
         .Columns(Entidades.CategoriaCama.Columnas.Largo.ToString()).Width = 70
         .Columns(Entidades.CategoriaCama.Columnas.Largo.ToString()).CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right

            .Columns(Entidades.CategoriaCama.Columnas.TasaMunicipal.ToString()).Header.Caption = "Tasa"
            .Columns(Entidades.CategoriaCama.Columnas.TasaMunicipal.ToString()).Width = 70
            .Columns(Entidades.CategoriaCama.Columnas.TasaMunicipal.ToString()).CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right

         If Publicos.CargosCalcularPor = "ACCION" Then
            .Columns(Entidades.CategoriaCama.Columnas.CantidadAccionesRequeridas.ToString()).Header.Caption = "Acc. Req."
            .Columns(Entidades.CategoriaCama.Columnas.CantidadAccionesRequeridas.ToString()).Width = 70
            .Columns(Entidades.CategoriaCama.Columnas.CantidadAccionesRequeridas.ToString()).CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right
         ElseIf Publicos.CargosCalcularPor = "CAMA" Then
            .Columns(Entidades.CategoriaCama.Columnas.CantidadAccionesRequeridas.ToString()).Hidden = True
         End If

         .Columns(Entidades.CategoriaCama.Columnas.ImporteExpensas.ToString()).Header.Caption = "Monto Expensas"
         .Columns(Entidades.CategoriaCama.Columnas.ImporteExpensas.ToString()).Format = "N2"
         .Columns(Entidades.CategoriaCama.Columnas.ImporteExpensas.ToString()).CellAppearance.TextHAlign = HAlign.Right

         .Columns(Entidades.CategoriaCama.Columnas.ImporteAlquiler.ToString()).Header.Caption = "Monto Alquiler"
         .Columns(Entidades.CategoriaCama.Columnas.ImporteAlquiler.ToString()).Format = "N2"
         .Columns(Entidades.CategoriaCama.Columnas.ImporteAlquiler.ToString()).CellAppearance.TextHAlign = HAlign.Right

         .Columns(Entidades.CategoriaCama.Columnas.PorcDescAlquiler.ToString()).Header.Caption = "% Desc. Alquiler"
         .Columns(Entidades.CategoriaCama.Columnas.PorcDescAlquiler.ToString()).Format = "N4"
         .Columns(Entidades.CategoriaCama.Columnas.PorcDescAlquiler.ToString()).CellAppearance.TextHAlign = HAlign.Right

         .Columns(Entidades.CategoriaCama.Columnas.ImporteGastosAdmin.ToString()).Header.Caption = "Gastos Admin."
         .Columns(Entidades.CategoriaCama.Columnas.ImporteGastosAdmin.ToString()).Format = "N2"
         .Columns(Entidades.CategoriaCama.Columnas.ImporteGastosAdmin.ToString()).CellAppearance.TextHAlign = HAlign.Right

         .Columns(Entidades.CategoriaCama.Columnas.ImporteGastosIntermAlq.ToString()).Header.Caption = "Gastos Intermed."
         .Columns(Entidades.CategoriaCama.Columnas.ImporteGastosIntermAlq.ToString()).Format = "N2"
         .Columns(Entidades.CategoriaCama.Columnas.ImporteGastosIntermAlq.ToString()).CellAppearance.TextHAlign = HAlign.Right

         .Columns(Entidades.CategoriaCama.Columnas.Largo.ToString()).Header.Caption = "Largo"
         .Columns(Entidades.CategoriaCama.Columnas.Largo.ToString()).Format = "N2"
         .Columns(Entidades.CategoriaCama.Columnas.Largo.ToString()).CellAppearance.TextHAlign = HAlign.Right

         .Columns(Entidades.CategoriaCama.Columnas.Alto.ToString()).Header.Caption = "Alto"
         .Columns(Entidades.CategoriaCama.Columnas.Alto.ToString()).Format = "N2"
         .Columns(Entidades.CategoriaCama.Columnas.Alto.ToString()).CellAppearance.TextHAlign = HAlign.Right

         .Columns(Entidades.CategoriaCama.Columnas.Ancho.ToString()).Header.Caption = "Ancho"
         .Columns(Entidades.CategoriaCama.Columnas.Ancho.ToString()).Format = "N2"
         .Columns(Entidades.CategoriaCama.Columnas.Ancho.ToString()).CellAppearance.TextHAlign = HAlign.Right
      End With

   End Sub

#End Region

End Class