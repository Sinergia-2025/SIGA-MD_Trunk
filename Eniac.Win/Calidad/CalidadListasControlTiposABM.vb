Public Class CalidadListasControlTiposABM

#Region "Overrides"

   Protected Overrides Sub OnLoad(e As EventArgs)
      MyBase.OnLoad(e)
      TryCatched(
      Sub()
         BotonImprimir.Visible = False
         dgvDatos.AgregarFiltroEnLinea({Entidades.CalidadListaControlTipo.Columnas.NombreListaControlTipo.ToString()})
      End Sub)
   End Sub

   Protected Overrides Function GetDetalle(estado As StateForm) As Eniac.Win.BaseDetalle
      If estado = StateForm.Actualizar Then
         Return New CalidadListasControlTiposDetalle(DirectCast(GetEntidad(), Entidades.CalidadListaControlTipo))
      End If
      Return New CalidadListasControlTiposDetalle(New Entidades.CalidadListaControlTipo())
   End Function

   Protected Overrides Function GetReglas() As Reglas.Base
      Return New Reglas.CalidadListasControlTipos()
   End Function

   Protected Overrides Function GetEntidad() As Eniac.Entidades.Entidad
      MyBase.GetEntidad()
      Dim dr = dgvDatos.FilaSeleccionada(Of DataRow)
      Return New Reglas.CalidadListasControlTipos().GetUno(dr.Field(Of Integer)(Entidades.CalidadListaControlTipo.Columnas.IdListaControlTipo.ToString()))
   End Function

   Protected Overrides Sub FormatearGrilla()
      With Me.dgvDatos.DisplayLayout.Bands(0)
         Dim pos = 0I
         .Columns(Entidades.CalidadListaControlTipo.Columnas.IdListaControlTipo.ToString()).FormatearColumna("Código", pos, 80, HAlign.Right)
         .Columns(Entidades.CalidadListaControlTipo.Columnas.NombreListaControlTipo.ToString()).FormatearColumna("Tipo", pos, 150)
      End With
   End Sub
#End Region

End Class