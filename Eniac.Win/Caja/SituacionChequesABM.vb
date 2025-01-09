Public Class SituacionChequesABM
#Region "Overrides"
   Protected Overrides Sub OnLoad(e As EventArgs)
      MyBase.OnLoad(e)
      Me.dgvDatos.AgregarFiltroEnLinea({"SituacionCheque"})
   End Sub

   'GET DETALLE
   Protected Overrides Function GetDetalle(estado As StateForm) As BaseDetalle
      If estado = StateForm.Actualizar Then
         Return New SituacionChequesDetalle(DirectCast(Me.GetEntidad(), Entidades.SituacionCheque))
      End If
      Return New SituacionChequesDetalle(New Entidades.SituacionCheque)
   End Function
   'GET REGLAS
   Protected Overrides Function GetReglas() As Reglas.Base
      Return New Reglas.SituacionCheques()
   End Function
   'GETENTIDAD
   Protected Overrides Function GetEntidad() As Entidades.Entidad
      MyBase.GetEntidad()
      Dim situacionCheque As Entidades.SituacionCheque = New Entidades.SituacionCheque()
      Dim r As Reglas.SituacionCheques = New Reglas.SituacionCheques()

      With Me.dgvDatos.ActiveCell.Row
         situacionCheque.IdSituacionCheque = Integer.Parse(.Cells("IdSituacionCheque").Value.ToString())
         situacionCheque = r.GetUno(situacionCheque.IdSituacionCheque)
      End With
      Return situacionCheque
   End Function
   'FORMATEAR GRILLA
   Protected Overrides Sub FormatearGrilla()
      With Me.dgvDatos.DisplayLayout.Bands(0)
         Dim col As Integer = 0
         .Columns(Entidades.SituacionCheque.Columnas.IdSituacionCheque.ToString()).FormatearColumna("Código", col, 80, HAlign.Right)
         .Columns(Entidades.SituacionCheque.Columnas.NombreSituacionCheque.ToString()).FormatearColumna("Nombre", col, 150, HAlign.Left)
         .Columns(Entidades.SituacionCheque.Columnas.PorDefecto.ToString()).FormatearColumna("Por Defecto", col, 80, HAlign.Center)

      End With
   End Sub
#End Region
End Class