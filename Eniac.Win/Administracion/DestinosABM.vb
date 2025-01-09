Option Explicit On
Option Strict On

Imports Eniac.Win
Imports Eniac.Entidades

Public Class DestinosABM

#Region "Overrides"

   Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)
      MyBase.OnLoad(e)
      Me.BotonImprimir.Visible = False
   End Sub

   Protected Overrides Function GetDetalle(ByVal estado As StateForm) As Eniac.Win.BaseDetalle
      If estado = StateForm.Actualizar Then
         Return New DestinosDetalle(DirectCast(Me.GetEntidad(), Eniac.Entidades.Destino))
      End If
      Return New DestinosDetalle(New Eniac.Entidades.Destino)
   End Function

   Protected Overrides Function GetReglas() As Reglas.Base
      Return New Reglas.Destinos()
   End Function

   Protected Overrides Function GetEntidad() As Entidades.Entidad
      MyBase.GetEntidad()
      Dim Destino As Entidades.Destino = New Entidades.Destino
      With Me.dgvDatos.ActiveCell.Row
         Destino.IdDestino = Short.Parse(.Cells(Destino.Columnas.IdDestino.ToString()).Value.ToString())
         Destino = New Reglas.Destinos().GetUno(Destino.IdDestino)
      End With
      Return Destino
   End Function

   Protected Overrides Sub FormatearGrilla()
      With Me.dgvDatos.DisplayLayout.Bands(0)
         .Columns(Entidades.Destino.Columnas.IdDestino.ToString()).Header.Caption = "Código"
         .Columns(Entidades.Destino.Columnas.IdDestino.ToString()).Width = 50
         .Columns(Entidades.Destino.Columnas.IdDestino.ToString()).CellAppearance.TextHAlign = HAlign.Right
         .Columns(Entidades.Destino.Columnas.NombreDestino.ToString()).Header.Caption = "Nombre"
         .Columns(Entidades.Destino.Columnas.NombreDestino.ToString()).Width = 150
         .Columns(Entidades.Destino.Columnas.EsLibre.ToString()).Header.Caption = "Es Libre"
         .Columns(Entidades.Destino.Columnas.EsLibre.ToString()).Width = 70
         '.Columns(Eniac.SiSeN.Entidades.Destino.Columnas.EsLibre.ToString()).CellAppearance.TextHAlign = HAlign.Center
      End With
   End Sub

#End Region

End Class