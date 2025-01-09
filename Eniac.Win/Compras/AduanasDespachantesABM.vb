Option Explicit On
Option Strict On

Imports Eniac.Win

Public Class AduanasDespachantesABM

#Region "Overrides"

   Protected Overrides Function GetDetalle(ByVal estado As StateForm) As Eniac.Win.BaseDetalle
      If estado = StateForm.Actualizar Then
         Return New AduanasDespachantesDetalle(DirectCast(Me.GetEntidad(), Entidades.AduanaDespachante))
      End If
      Return New AduanasDespachantesDetalle(New Entidades.AduanaDespachante)
   End Function
   Protected Overrides Function GetReglas() As Eniac.Reglas.Base
      Return New Reglas.AduanasDespachantes()
   End Function
   Protected Overrides Function GetEntidad() As Eniac.Entidades.Entidad
      MyBase.GetEntidad()
      Dim aduana As Entidades.AduanaDespachante = New Entidades.AduanaDespachante
      With Me.dgvDatos.ActiveCell.Row
         aduana = New Reglas.AduanasDespachantes().GetUno(Integer.Parse(.Cells(Entidades.AduanaDespachante.Columnas.IdDespachante.ToString()).Value.ToString()))
      End With
      Return aduana
   End Function

   Protected Overrides Sub FormatearGrilla()
      With Me.dgvDatos.DisplayLayout.Bands(0)
         .Columns(Entidades.AduanaDespachante.Columnas.IdDespachante.ToString()).Header.Caption = "Código"
         .Columns(Entidades.AduanaDespachante.Columnas.IdDespachante.ToString()).Width = 70
         .Columns(Entidades.AduanaDespachante.Columnas.NombreDespachante.ToString()).Header.Caption = "Nombre"
         .Columns(Entidades.AduanaDespachante.Columnas.NombreDespachante.ToString()).Width = 250
         .Columns(Entidades.AduanaDespachante.Columnas.Cuit.ToString()).Header.Caption = "CUIT"
         .Columns(Entidades.AduanaDespachante.Columnas.Cuit.ToString()).Width = 100
      End With
   End Sub

#End Region

End Class
