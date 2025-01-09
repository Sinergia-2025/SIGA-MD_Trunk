Public Class CalidadListasControlItemsSubGruposABM

#Region "Overrides"

   Protected Overrides Sub OnLoad(e As EventArgs)
      MyBase.OnLoad(e)
      TryCatched(
      Sub()
         BotonImprimir.Visible = False
         dgvDatos.AgregarFiltroEnLinea({Entidades.CalidadListaControlItemSubGrupo.Columnas.NombreListaControlItemSubGrupo.ToString()})
      End Sub)
   End Sub
   Protected Overrides Function GetDetalle(estado As StateForm) As BaseDetalle
      If estado = StateForm.Actualizar Then
         Return New CalidadListasControlItemsSubGruposDetalle(DirectCast(GetEntidad(), Entidades.CalidadListaControlItemSubGrupo))
      End If
      Return New CalidadListasControlItemsSubGruposDetalle(New Entidades.CalidadListaControlItemSubGrupo())
   End Function
   Protected Overrides Function GetReglas() As Eniac.Reglas.Base
      Return New Reglas.CalidadListasControlItemsSubGrupos()
   End Function

   Protected Overrides Function GetEntidad() As Entidades.Entidad
      MyBase.GetEntidad()
      Dim dr = dgvDatos.FilaSeleccionada(Of DataRow)
      Return New Reglas.CalidadListasControlItemsSubGrupos().GetUno(dr.Field(Of String)(Entidades.CalidadListaControlItemSubGrupo.Columnas.IdListaControlItemGrupo.ToString()),
                                                                    dr.Field(Of String)(Entidades.CalidadListaControlItemSubGrupo.Columnas.IdListaControlItemSubGrupo.ToString()))
   End Function
   Protected Overrides Sub FormatearGrilla()
      With dgvDatos.DisplayLayout.Bands(0)
         Dim col As Integer = 0
         .Columns(Entidades.CalidadListaControlItemSubGrupo.Columnas.IdListaControlItemGrupo.ToString()).FormatearColumna("Código Grupo", col, 100, HAlign.Right)
         .Columns(Entidades.CalidadListaControlItemGrupo.Columnas.NombreListaControlItemGrupo.ToString()).FormatearColumna("Grupo", col, 300)
         .Columns(Entidades.CalidadListaControlItemSubGrupo.Columnas.IdListaControlItemSubGrupo.ToString()).FormatearColumna("Código", col, 100, HAlign.Right)
         .Columns(Entidades.CalidadListaControlItemSubGrupo.Columnas.NombreListaControlItemSubGrupo.ToString()).FormatearColumna("SubGrupo", col, 300)
      End With
   End Sub

#End Region
End Class