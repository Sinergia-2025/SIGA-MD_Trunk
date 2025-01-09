Option Explicit On
Option Strict On

Imports Eniac.Win

Public Class AduanasAgentesTransporteABM

#Region "Overrides"

   Protected Overrides Function GetDetalle(ByVal estado As StateForm) As Eniac.Win.BaseDetalle
      If estado = StateForm.Actualizar Then
         Return New AduanasAgentesTransporteDetalle(DirectCast(Me.GetEntidad(), Entidades.AduanaAgenteTransporte))
      End If
      Return New AduanasAgentesTransporteDetalle(New Entidades.AduanaAgenteTransporte)
   End Function
   Protected Overrides Function GetReglas() As Eniac.Reglas.Base
      Return New Reglas.AduanasAgentesTransporte()
   End Function
   Protected Overrides Function GetEntidad() As Eniac.Entidades.Entidad
      MyBase.GetEntidad()
      Dim aduana As Entidades.AduanaAgenteTransporte = New Entidades.AduanaAgenteTransporte
      With Me.dgvDatos.ActiveCell.Row
         aduana = New Reglas.AduanasAgentesTransporte().GetUno(Integer.Parse(.Cells(Entidades.AduanaAgenteTransporte.Columnas.IdAgenteTransporte.ToString()).Value.ToString()))
      End With
      Return aduana
   End Function

   Protected Overrides Sub FormatearGrilla()
      With Me.dgvDatos.DisplayLayout.Bands(0)
         .Columns(Entidades.AduanaAgenteTransporte.Columnas.IdAgenteTransporte.ToString()).Header.Caption = "Código"
         .Columns(Entidades.AduanaAgenteTransporte.Columnas.IdAgenteTransporte.ToString()).Width = 70
         .Columns(Entidades.AduanaAgenteTransporte.Columnas.NombreAgenteTransporte.ToString()).Header.Caption = "Nombre"
         .Columns(Entidades.AduanaAgenteTransporte.Columnas.NombreAgenteTransporte.ToString()).Width = 250
         .Columns(Entidades.AduanaAgenteTransporte.Columnas.Cuit.ToString()).Header.Caption = "CUIT"
         .Columns(Entidades.AduanaAgenteTransporte.Columnas.Cuit.ToString()).Width = 100
      End With
   End Sub

#End Region

End Class
