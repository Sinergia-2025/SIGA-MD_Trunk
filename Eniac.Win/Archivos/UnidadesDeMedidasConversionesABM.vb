Public Class UnidadesDeMedidasConversionesABM

#Region "Overrides"
   Protected Overrides Sub OnLoad(e As EventArgs)
      MyBase.OnLoad(e)
      TryCatched(
      Sub()
         tsbImprimir.Visible = False
      End Sub)
   End Sub
   Protected Overrides Function GetDetalle(estado As StateForm) As BaseDetalle
      If estado = StateForm.Actualizar Then
         Return New UnidadesDeMedidasConversionesDetalle(DirectCast(GetEntidad(), Entidades.UnidadDeMedidaConversion))
      End If
      Return New UnidadesDeMedidasConversionesDetalle(New Entidades.UnidadDeMedidaConversion())
   End Function

   Protected Overrides Function GetReglas() As Reglas.Base
      Return New Reglas.UnidadesDeMedidasConversiones()
   End Function

   Protected Overrides Function GetEntidad() As Entidades.Entidad
      Dim dr = dgvDatos.FilaSeleccionada(Of DataRow)()
      Return New Reglas.UnidadesDeMedidasConversiones().GetUno(dr.Field(Of String)(Entidades.UnidadDeMedidaConversion.Columnas.IdUnidadMedidaDesde.ToString()),
                                                               dr.Field(Of String)(Entidades.UnidadDeMedidaConversion.Columnas.IdUnidadMedidaHacia.ToString()))
   End Function

   Protected Overrides Sub FormatearGrilla()
      With dgvDatos.DisplayLayout.Bands(0)
         Dim pos = 0I
         .Columns(Entidades.UnidadDeMedidaConversion.Columnas.IdUnidadMedidaDesde.ToString()).FormatearColumna("Código UM Desde", pos, 80)
         .Columns("NombreUnidadDeMedidaDesde").FormatearColumna("UM Desde", pos, 150)
         .Columns(Entidades.UnidadDeMedidaConversion.Columnas.IdUnidadMedidaHacia.ToString()).FormatearColumna("Código UM Hacia", pos, 80)
         .Columns("NombreUnidadDeMedidaHacia").FormatearColumna("UM Hacia", pos, 150)
         .Columns(Entidades.UnidadDeMedidaConversion.Columnas.FactorConversion.ToString()).FormatearColumna("Factor de Conversión", pos, 80, HAlign.Right)
         .Columns(Entidades.UnidadDeMedidaConversion.Columnas.Fija.ToString()).FormatearColumna("Fija", pos, 60, HAlign.Center)
      End With
      dgvDatos.AgregarFiltroEnLinea({})
   End Sub

#End Region

End Class