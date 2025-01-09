Public Class TurismoTiposViajesABM

#Region "Overrides"

   Protected Overrides Sub OnLoad(e As EventArgs)
      MyBase.OnLoad(e)
      tsbImprimir.Visible = False
   End Sub

   Protected Overrides Function GetDetalle(estado As StateForm) As BaseDetalle
      If estado = StateForm.Actualizar Then
         Return New TurismoTiposViajesDetalle(DirectCast(GetEntidad(), Entidades.TurismoTipoViaje))
      End If
      Return New TurismoTiposViajesDetalle(New Entidades.TurismoTipoViaje())
   End Function

   Protected Overrides Function GetReglas() As Reglas.Base
      Return New Reglas.TurismoTiposViajes()
   End Function

   Protected Overrides Function GetEntidad() As Entidades.Entidad
      With dgvDatos.ActiveRow
         Return New Reglas.TurismoTiposViajes().GetUno(Integer.Parse(.Cells(Entidades.TurismoTipoViaje.Columnas.IdTipoViaje.ToString()).Value.ToString()))
      End With
   End Function

   Protected Overrides Sub FormatearGrilla()
      With dgvDatos.DisplayLayout.Bands(0)
         For Each col As UltraGridColumn In .Columns
            col.CellActivation = Activation.ActivateOnly
         Next
         Dim pos = 0I
         .Columns(Entidades.TurismoTipoViaje.Columnas.IdTipoViaje.ToString()).FormatearColumna("Código", pos, 80, HAlign.Right)
         .Columns(Entidades.TurismoTipoViaje.Columnas.DescripcionTipoViaje.ToString()).FormatearColumna("Descripción", pos, 300)
         .Columns(Entidades.TurismoTipoViaje.Columnas.CantidadDiasUltimaCuota.ToString()).FormatearColumna("Cantidad Días Ultima Cuota", pos, 80, HAlign.Right)
         .Columns(Entidades.TurismoTipoViaje.Columnas.IdInteres.ToString()).OcultoPosicion(hidden:=True, pos)
         .Columns(Entidades.Interes.Columnas.NombreInteres.ToString()).FormatearColumna("Interes", pos, 300)
      End With
      dgvDatos.AgregarFiltroEnLinea({Entidades.TurismoTipoViaje.Columnas.DescripcionTipoViaje.ToString()})
   End Sub

#End Region

End Class