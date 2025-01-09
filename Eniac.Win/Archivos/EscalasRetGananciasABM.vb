Option Strict Off

Public Class EscalasRetGananciasABM

#Region "Overrides"

   Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)
      MyBase.OnLoad(e)
      Me.tsbImprimir.Visible = False
   End Sub

   Protected Overrides Function GetDetalle(ByVal estado As StateForm) As Eniac.Win.BaseDetalle
      If estado = StateForm.Actualizar Then
         Return New EscalasRetGananciasDetalle(DirectCast(Me.GetEntidad(), Entidades.EscalaRetGanancias))
      End If
      Return New EscalasRetGananciasDetalle(New Entidades.EscalaRetGanancias)
   End Function

   Protected Overrides Function GetReglas() As Eniac.Reglas.Base
      Return New Reglas.EscalasRetGanancias()
   End Function

   Protected Overrides Sub Imprimir()
      MyBase.Imprimir()
   End Sub

   Protected Overrides Function GetEntidad() As Eniac.Entidades.Entidad
      MyBase.GetEntidad()
      Dim esc As Entidades.EscalaRetGanancias = New Entidades.EscalaRetGanancias

      With Me.dgvDatos.ActiveCell.Row
         esc.IdEscala = .Cells("IdEscala").Value.ToString()
         esc = New Reglas.EscalasRetGanancias().GetUno(esc.IdEscala)
         esc.Usuario = actual.Sucursal.Usuario
      End With

      Return esc

   End Function

   Protected Overrides Sub FormatearGrilla()
      With Me.dgvDatos.DisplayLayout.Bands(0)
         .Columns(Entidades.EscalaRetGanancias.Columnas.IdEscala.ToString()).Header.Caption = "Escala"
         .Columns(Entidades.EscalaRetGanancias.Columnas.IdEscala.ToString()).Width = 50
         .Columns(Entidades.EscalaRetGanancias.Columnas.IdEscala.ToString()).CellAppearance.TextHAlign = HAlign.Right

         .Columns(Entidades.EscalaRetGanancias.Columnas.MontoMasDe.ToString()).Header.Caption = "Monto Mas De"
         .Columns(Entidades.EscalaRetGanancias.Columnas.MontoMasDe.ToString()).Width = 100
         .Columns(Entidades.EscalaRetGanancias.Columnas.MontoMasDe.ToString()).CellAppearance.TextHAlign = HAlign.Right

         .Columns(Entidades.EscalaRetGanancias.Columnas.MontoA.ToString()).Header.Caption = "Monto A"
         .Columns(Entidades.EscalaRetGanancias.Columnas.MontoA.ToString()).Width = 100
         .Columns(Entidades.EscalaRetGanancias.Columnas.MontoA.ToString()).CellAppearance.TextHAlign = HAlign.Right

         .Columns(Entidades.EscalaRetGanancias.Columnas.Importe.ToString()).Header.Caption = "Importe"
         .Columns(Entidades.EscalaRetGanancias.Columnas.Importe.ToString()).Width = 100
         .Columns(Entidades.EscalaRetGanancias.Columnas.Importe.ToString()).CellAppearance.TextHAlign = HAlign.Right

         .Columns(Entidades.EscalaRetGanancias.Columnas.MasPorcentaje.ToString()).Header.Caption = "Mas %"
         .Columns(Entidades.EscalaRetGanancias.Columnas.MasPorcentaje.ToString()).Width = 100
         .Columns(Entidades.EscalaRetGanancias.Columnas.MasPorcentaje.ToString()).CellAppearance.TextHAlign = HAlign.Right

         .Columns(Entidades.EscalaRetGanancias.Columnas.SobreExcedente.ToString()).Header.Caption = "Sobre Excedente"
         .Columns(Entidades.EscalaRetGanancias.Columnas.SobreExcedente.ToString()).Width = 120
         .Columns(Entidades.EscalaRetGanancias.Columnas.SobreExcedente.ToString()).CellAppearance.TextHAlign = HAlign.Right

      End With
   End Sub

#End Region

End Class