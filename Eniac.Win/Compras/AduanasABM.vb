Option Explicit On
Option Strict On

Imports Eniac.Win

Public Class AduanasABM

#Region "Overrides"

   Protected Overrides Function GetDetalle(ByVal estado As StateForm) As Eniac.Win.BaseDetalle
      If estado = StateForm.Actualizar Then
         Return New AduanasDetalle(DirectCast(Me.GetEntidad(), Entidades.aduana))
      End If
      Return New AduanasDetalle(New Entidades.Aduana)
   End Function
   Protected Overrides Function GetReglas() As Eniac.Reglas.Base
      Return New Reglas.Aduanas()
   End Function

   Protected Overrides Function GetEntidad() As Eniac.Entidades.Entidad
      MyBase.GetEntidad()
      Dim aduana As Entidades.Aduana = New Entidades.Aduana
      With Me.dgvDatos.ActiveCell.Row
         aduana = New Reglas.Aduanas().GetUno(Integer.Parse(.Cells(Entidades.Aduana.Columnas.IdAduana.ToString()).Value.ToString()))
      End With
      Return aduana
   End Function

   Protected Overrides Sub FormatearGrilla()
      With Me.dgvDatos.DisplayLayout.Bands(0)
         .Columns(Entidades.Aduana.Columnas.IdAduana.ToString()).Header.Caption = "Código"
         .Columns(Entidades.Aduana.Columnas.IdAduana.ToString()).Width = 70
         .Columns(Entidades.Aduana.Columnas.NombreAduana.ToString()).Header.Caption = "Nombre"
         .Columns(Entidades.Aduana.Columnas.NombreAduana.ToString()).Width = 250
      End With
   End Sub

#End Region

End Class
