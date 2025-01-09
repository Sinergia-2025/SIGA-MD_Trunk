Imports Eniac.Win

Public Class ObservacionesABM

#Region "Overrides"

   Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)
      MyBase.OnLoad(e)
      Me.tsbImprimir.Visible = False
   End Sub
   Protected Overrides Function GetDetalle(ByVal estado As StateForm) As Eniac.Win.BaseDetalle
      If estado = StateForm.Actualizar Then
         Return New ObservacionesDetalle(DirectCast(Me.GetEntidad(), Eniac.Entidades.Observacion))
      End If
      Return New ObservacionesDetalle(New Entidades.Observacion)
   End Function
   Protected Overrides Function GetReglas() As Eniac.Reglas.Base
      Return New Reglas.Observaciones()
   End Function

   Protected Overrides Function GetEntidad() As Eniac.Entidades.Entidad

      Dim Observacion As Entidades.Observacion = New Entidades.Observacion
      With Me.dgvDatos.ActiveCell.Row
         Observacion = New Reglas.Observaciones().GetUno(Integer.Parse(.Cells("IdObservacion").Value.ToString()))
      End With
      Return Observacion

   End Function


   Protected Overrides Sub FormatearGrilla()

      Grilla.AgregarFiltroEnLinea(dgvDatos, {("DetalleObservacion")})

      With Me.dgvDatos.DisplayLayout.Bands(0)
         Dim pos As Integer = 0

         .Columns("IdObservacion").FormatearColumna("Código", pos, 50, HAlign.Right)
         .Columns("DetalleObservacion").FormatearColumna("Observacion", pos, 350, HAlign.Right)
         .Columns("Tipo").FormatearColumna("Tipo", pos, 80, HAlign.Right)

      End With
   End Sub

#End Region

End Class