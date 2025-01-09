Public Class SituacionCuponesABM
#Region "Overrides"
   Protected Overrides Sub OnLoad(e As EventArgs)
      MyBase.OnLoad(e)
      Me.dgvDatos.AgregarFiltroEnLinea({"SituacionCupones"})
   End Sub
   'GET DETALLE
   Protected Overrides Function GetDetalle(estado As StateForm) As BaseDetalle
      If estado = StateForm.Actualizar Then
         Return New SituacionCuponesDetalle(DirectCast(Me.GetEntidad(), Entidades.SituacionCupon))
      End If
      Return New SituacionCuponesDetalle(New Entidades.SituacionCupon)
   End Function
   'GET REGLAS
   Protected Overrides Function GetReglas() As Reglas.Base
      Return New Reglas.SituacionCupones()
   End Function
   'GETENTIDAD
   Protected Overrides Function GetEntidad() As Entidades.Entidad
      MyBase.GetEntidad()
      Dim situacionCupon As Entidades.SituacionCupon = New Entidades.SituacionCupon()
      Dim r As Reglas.SituacionCupones = New Reglas.SituacionCupones()

      With Me.dgvDatos.ActiveCell.Row
         situacionCupon.IdSituacionCupon = Integer.Parse(.Cells("IdSituacionCupon").Value.ToString())
         situacionCupon = r.GetUno(situacionCupon.IdSituacionCupon)
      End With
      Return situacionCupon
   End Function
   'FORMATEAR GRILLA
   Protected Overrides Sub FormatearGrilla()
      With Me.dgvDatos.DisplayLayout.Bands(0)
         Dim col As Integer = 0
         .Columns(Entidades.SituacionCupon.Columnas.IdSituacionCupon.ToString()).FormatearColumna("Código", col, 80, HAlign.Right)
         .Columns(Entidades.SituacionCupon.Columnas.NombreSituacionCupon.ToString()).FormatearColumna("Nombre", col, 150, HAlign.Left)
         .Columns(Entidades.SituacionCupon.Columnas.PorDefecto.ToString()).FormatearColumna("Por Defecto", col, 80, HAlign.Center)

      End With
   End Sub
#End Region
End Class