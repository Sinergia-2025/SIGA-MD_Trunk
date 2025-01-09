Option Explicit On
Option Strict On

Imports Eniac.Win

Public Class AduanasDestinacionesABM

#Region "Overrides"

   Protected Overrides Function GetDetalle(ByVal estado As StateForm) As Eniac.Win.BaseDetalle
      If estado = StateForm.Actualizar Then
         Return New AduanasDestinacionesDetalle(DirectCast(Me.GetEntidad(), Entidades.AduanaDestinacion))
      End If
      Return New AduanasDestinacionesDetalle(New Entidades.AduanaDestinacion)
   End Function
   Protected Overrides Function GetReglas() As Eniac.Reglas.Base
      Return New Reglas.AduanasDestinaciones()
   End Function
   Protected Overrides Function GetEntidad() As Eniac.Entidades.Entidad
      MyBase.GetEntidad()
      Dim aduana As Entidades.AduanaDestinacion = New Entidades.AduanaDestinacion
      With Me.dgvDatos.ActiveCell.Row
         aduana = New Reglas.AduanasDestinaciones().GetUno(.Cells(Entidades.AduanaDestinacion.Columnas.IdDestinacion.ToString()).Value.ToString())
      End With
      Return aduana
   End Function

   Protected Overrides Sub FormatearGrilla()
      With Me.dgvDatos.DisplayLayout.Bands(0)
         .Columns(Entidades.AduanaDestinacion.Columnas.IdDestinacion.ToString()).Header.Caption = "Código"
         .Columns(Entidades.AduanaDestinacion.Columnas.IdDestinacion.ToString()).Width = 70
         .Columns(Entidades.AduanaDestinacion.Columnas.NombreDestinacion.ToString()).Header.Caption = "Nombre"
         .Columns(Entidades.AduanaDestinacion.Columnas.NombreDestinacion.ToString()).Width = 400
         .Columns(Entidades.AduanaDestinacion.Columnas.RegimenArancelario.ToString()).Header.Caption = "Reg. Arancelario"
         .Columns(Entidades.AduanaDestinacion.Columnas.RegimenArancelario.ToString()).Width = 150
      End With
   End Sub

#End Region

End Class
