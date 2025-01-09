Public Class CalidadListaControlItemGrupoABM

#Region "Overrides"

   Protected Overrides Sub OnLoad(e As EventArgs)
      MyBase.OnLoad(e)
      TryCatched(
      Sub()
         BotonImprimir.Visible = False
         dgvDatos.AgregarFiltroEnLinea({Entidades.CalidadListaControlItemGrupo.Columnas.NombreListaControlItemGrupo.ToString()})
      End Sub)
   End Sub
   Protected Overrides Function GetDetalle(estado As StateForm) As BaseDetalle
      If estado = StateForm.Actualizar Then
         Return New CalidadListaControlItemGrupoDetalle(DirectCast(Me.GetEntidad(), Entidades.CalidadListaControlItemGrupo))
      End If
      Return New CalidadListaControlItemGrupoDetalle(New Entidades.CalidadListaControlItemGrupo())
   End Function
   Protected Overrides Function GetReglas() As Reglas.Base
      Return New Reglas.CalidadListaControlItemGrupo()
   End Function

   Protected Overrides Function GetEntidad() As Entidades.Entidad
      MyBase.GetEntidad()
      Dim dr = dgvDatos.FilaSeleccionada(Of DataRow)
      Return New Reglas.CalidadListaControlItemGrupo().GetUno(dr.Field(Of String)(Entidades.CalidadListaControlItemGrupo.Columnas.IdListaControlItemGrupo.ToString()))
   End Function
   Protected Overrides Sub FormatearGrilla()
      With dgvDatos.DisplayLayout.Bands(0)
         Dim col = 0I
         .Columns(Entidades.CalidadListaControlItemGrupo.Columnas.IdListaControlItemGrupo.ToString()).FormatearColumna("Código", col, 100, HAlign.Right)
         .Columns(Entidades.CalidadListaControlItemGrupo.Columnas.NombreListaControlItemGrupo.ToString()).FormatearColumna("Nombre", col, 400)
      End With
   End Sub

#End Region
End Class