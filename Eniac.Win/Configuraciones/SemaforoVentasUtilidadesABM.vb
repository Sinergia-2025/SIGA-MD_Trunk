Public Class SemaforoVentasUtilidadesABM

#Region "Overrides"
   Protected Overrides Function GetDetalle(ByVal estado As StateForm) As Eniac.Win.BaseDetalle
      If estado = StateForm.Actualizar Then
         Return New SemaforoVentasUtilidadesDetalle(DirectCast(Me.GetEntidad(), Entidades.SemaforoVentaUtilidad))
      End If
      Return New SemaforoVentasUtilidadesDetalle(New Entidades.SemaforoVentaUtilidad)
   End Function

   Protected Overrides Function GetReglas() As Eniac.Reglas.Base
      Return New Reglas.SemaforoVentasUtilidades()
   End Function

   Protected Overrides Function GetEntidad() As Eniac.Entidades.Entidad
      Return New Reglas.SemaforoVentasUtilidades().GetUno(CInt(dgvDatos.ActiveRow.Cells(Entidades.SemaforoVentaUtilidad.Columnas.IdSemaforo.ToString()).Value))
   End Function

   Protected Overrides Sub FormatearGrilla()

      With Me.dgvDatos.DisplayLayout.Bands(0)
         For Each columna As UltraGridColumn In .Columns
            columna.Hidden = True
         Next
         Dim pos As Integer = 0
         .Columns("IdSemaforo").FormatearColumna("Código", pos, 70, HAlign.Right)
         .Columns("IdTipoSemaforoVentaUtilidad").FormatearColumna("Tipo", pos, 100, HAlign.Left)
         .Columns("PorcentajeHasta").FormatearColumna("Porc. Hasta", pos, 90, HAlign.Right)
         .Columns("ColorSemaforo").FormatearColumna("Color Semáforo", pos, 90, HAlign.Right, True)
         .Columns("ColorLetra").FormatearColumna("Color Letra", pos, 90, HAlign.Right, True)
         .Columns("NombreColor").FormatearColumna("Nombre Color", pos, 100, HAlign.Left)
         .Columns("Negrita").FormatearColumna("Negrita", pos, 70, HAlign.Center)
      End With

      AgregarFiltroEnLinea(Me.dgvDatos, {})
   End Sub

#End Region

End Class