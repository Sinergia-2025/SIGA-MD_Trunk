Public Class CalidadListasControlABM

#Region "Overrides"

   Protected Overrides Sub OnLoad(e As EventArgs)
      MyBase.OnLoad(e)
      'Me.BotonImprimir.Visible = False
   End Sub
   Protected Overrides Function GetDetalle(estado As StateForm) As BaseDetalle
      If estado = StateForm.Actualizar Then
         Return New CalidadListasControlDetalle(DirectCast(GetEntidad(), Entidades.CalidadListaControl))
      End If
      Return New CalidadListasControlDetalle(New Entidades.CalidadListaControl())
   End Function
   Protected Overrides Function GetReglas() As Reglas.Base
      Return New Reglas.CalidadListasControl()
   End Function

   Protected Overrides Function GetEntidad() As Entidades.Entidad
      MyBase.GetEntidad()
      Dim dr = dgvDatos.FilaSeleccionada(Of DataRow)
      Return New Reglas.CalidadListasControl().GetUno(dr.Field(Of Integer)(Entidades.CalidadListaControl.Columnas.IdListaControl.ToString()), cargaItems:=True)
   End Function
   Protected Overrides Sub FormatearGrilla()

      With dgvDatos.DisplayLayout.Bands(0)
         Dim col = 0I

         .Columns(Entidades.CalidadListaControl.Columnas.IdListaControlTipo.ToString()).FormatearColumna("Código Tipo Lista Control", col, 80, HAlign.Right, hidden:=True)
         .Columns(Entidades.CalidadListaControlTipo.Columnas.NombreListaControlTipo.ToString()).FormatearColumna("Tipo", col, 80)

         .Columns(Entidades.CalidadListaControl.Columnas.IdListaControl.ToString()).FormatearColumna("Código", col, 100)
         .Columns(Entidades.CalidadListaControl.Columnas.NombreListaControl.ToString()).FormatearColumna("Nombre Lista de Control", col, 300)

         .Columns(Entidades.CalidadListaControl.Columnas.Orden.ToString()).FormatearColumna("Orden", col, 100, HAlign.Right)
      End With
      dgvDatos.AgregarFiltroEnLinea({Entidades.CalidadListaControl.Columnas.NombreListaControl.ToString()})
   End Sub

#End Region

End Class