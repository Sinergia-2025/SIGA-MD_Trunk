Public Class CalidadListasControlItemsABM

#Region "Overrides"

   Protected Overrides Sub OnLoad(e As EventArgs)
      MyBase.OnLoad(e)
      TryCatched(
      Sub()
         BotonImprimir.Visible = False
         dgvDatos.AgregarFiltroEnLinea({Entidades.CalidadListaControlItem.Columnas.NombreListaControlItem.ToString()})
      End Sub)
   End Sub
   Protected Overrides Function GetDetalle(estado As StateForm) As BaseDetalle
      If estado = StateForm.Actualizar Then
         Return New CalidadListasControlItemsDetalle(DirectCast(GetEntidad(), Entidades.CalidadListaControlItem))
      End If
      Return New CalidadListasControlItemsDetalle(New Entidades.CalidadListaControlItem())
   End Function
   Protected Overrides Function GetReglas() As Reglas.Base
      Return New Reglas.CalidadListasControlItems()
   End Function

   Protected Overrides Function GetEntidad() As Entidades.Entidad
      MyBase.GetEntidad()
      Dim dr = dgvDatos.FilaSeleccionada(Of DataRow)
      Return New Reglas.CalidadListasControlItems().GetUno(dr.Field(Of Integer)(Entidades.CalidadListaControlItem.Columnas.IdListaControlItem.ToString()))
   End Function
   Protected Overrides Sub FormatearGrilla()
      With dgvDatos.DisplayLayout.Bands(0)
         Dim col = 0I
         .Columns(Entidades.CalidadListaControlItem.Columnas.IdListaControlItem.ToString()).FormatearColumna("Código", col, 100, HAlign.Right)
         .Columns(Entidades.CalidadListaControlItem.Columnas.NombreListaControlItem.ToString()).FormatearColumna("Nombre", col, 300)

         .Columns(Entidades.CalidadListaControlItem.Columnas.IdListaControlItemGrupo.ToString()).FormatearColumna("Código Grupo", col, 80, hidden:=True)
         .Columns(Entidades.CalidadListaControlItemGrupo.Columnas.NombreListaControlItemGrupo.ToString()).FormatearColumna("Grupo", col, 100)

         .Columns(Entidades.CalidadListaControlItem.Columnas.IdListaControlItemSubGrupo.ToString()).FormatearColumna("Código SubGrupo", col, 80, hidden:=True)
         .Columns(Entidades.CalidadListaControlItemSubGrupo.Columnas.NombreListaControlItemSubGrupo.ToString()).FormatearColumna("SubGrupo", col, 100)

         .Columns(Entidades.CalidadListaControlItem.Columnas.NivelInspeccion.ToString()).FormatearColumna("Nivel Inspección", col, 60, HAlign.Center)
         .Columns(Entidades.CalidadListaControlItem.Columnas.ValorAQL.ToString()).FormatearColumna("AQL", col, 80, HAlign.Right)
         .Columns(Entidades.CalidadListaControlItem.Columnas.Observacion.ToString()).FormatearColumna("Obsercación", col, 300)
      End With
   End Sub

#End Region
End Class