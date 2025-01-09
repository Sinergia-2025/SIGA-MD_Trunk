Public Class TiposObservacionesABM
#Region "Overrides"
   Protected Overrides Function GetDetalle(ByVal estado As StateForm) As BaseDetalle
      If estado = StateForm.Actualizar Then
         Return New TiposObservacionesDetalle(DirectCast(Me.GetEntidad(), Entidades.TipoObservacion))
      End If
      Return New TiposObservacionesDetalle(New Entidades.TipoObservacion)
   End Function

   Protected Overrides Function GetReglas() As Reglas.Base
      Return New Reglas.TiposObservaciones()
   End Function
   Protected Overrides Function GetEntidad() As Eniac.Entidades.Entidad
      Dim TipoObservacion = New Eniac.Entidades.TipoObservacion
      With dgvDatos.ActiveRow
         TipoObservacion = New Reglas.TiposObservaciones().GetUno(Short.Parse(.Cells("IdObservaciones").Value.ToString()))
      End With
      Return TipoObservacion
   End Function
   Protected Overrides Sub FormatearGrilla()
      With dgvDatos.DisplayLayout.Bands(0)
         Dim col As Integer = 0
         .Columns(Entidades.TipoObservacion.Columnas.IdObservaciones.ToString()).FormatearColumna("Código", col, 80, HAlign.Right)
         .Columns(Entidades.TipoObservacion.Columnas.Descripcion.ToString()).FormatearColumna("Descripcion", col, 400)
         .Columns(Entidades.TipoObservacion.Columnas.Activa.ToString()).FormatearColumna("Activa", col, 80)
         .Columns(Entidades.TipoObservacion.Columnas.PorDefecto.ToString()).FormatearColumna("Por Defecto", col, 90)
      End With
      dgvDatos.AgregarFiltroEnLinea({"Descripcion", "IdObservaciones"})
   End Sub
#End Region
End Class