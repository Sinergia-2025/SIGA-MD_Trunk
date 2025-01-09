Public Class TiposAtributosProductosABM

#Region "Overrides"
   Protected Overrides Function GetDetalle(ByVal estado As StateForm) As BaseDetalle
      If estado = StateForm.Actualizar Then
         Return New TiposAtributosProductosDetalle(DirectCast(Me.GetEntidad(), Entidades.TipoAtributoProducto))
      End If
      Return New TiposAtributosProductosDetalle(New Entidades.TipoAtributoProducto)
   End Function

   Protected Overrides Function GetReglas() As Reglas.Base
      Return New Reglas.TiposAtributosProductos()
   End Function
   Protected Overrides Function GetEntidad() As Eniac.Entidades.Entidad
      Dim TipoAtributoProducto = New Eniac.Entidades.TipoAtributoProducto
      With dgvDatos.ActiveRow
         TipoAtributoProducto = New Reglas.TiposAtributosProductos().GetUno(Short.Parse(.Cells("IdTipoAtributoProducto").Value.ToString()))
      End With
      Return TipoAtributoProducto
   End Function
   Protected Overrides Sub FormatearGrilla()
      With dgvDatos.DisplayLayout.Bands(0)
         Dim col As Integer = 0
         .Columns(Entidades.TipoAtributoProducto.Columnas.IdTipoAtributoProducto.ToString()).FormatearColumna("Código", col, 80, HAlign.Right)
         .Columns(Entidades.TipoAtributoProducto.Columnas.Descripcion.ToString()).FormatearColumna("Descripcion", col, 400)
      End With
      dgvDatos.AgregarFiltroEnLinea({"Descripcion", "IdTipoAtributoProducto"})
   End Sub
#End Region

End Class