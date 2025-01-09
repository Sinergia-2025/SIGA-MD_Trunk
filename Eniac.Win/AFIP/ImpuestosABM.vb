Public Class ImpuestosABM

#Region "Overrides"
   Protected Overrides Sub OnLoad(e As EventArgs)
      MyBase.OnLoad(e)
      TryCatched(Sub() tsbImprimir.Visible = False)
   End Sub
   Protected Overrides Function GetDetalle(estado As StateForm) As BaseDetalle
      If estado = StateForm.Actualizar Then
         Return New ImpuestosDetalle(DirectCast(GetEntidad(), Entidades.Impuesto))
      End If
      Return New ImpuestosDetalle(New Entidades.Impuesto())
   End Function
   Protected Overrides Function GetReglas() As Reglas.Base
      Return New Reglas.Impuestos()
   End Function
   Protected Overrides Function GetEntidad() As Entidades.Entidad
      Dim dr = dgvDatos.FilaSeleccionada(Of DataRow)()
      Return DirectCast(GetReglas(), Reglas.Impuestos).GetUno(dr.Field(Of String)("IdTipoImpuesto"), dr.Field(Of Decimal)("Alicuota"))
   End Function
   Protected Overrides Sub FormatearGrilla()
      With dgvDatos.DisplayLayout.Bands(0)
         Dim pos = 0I
         .Columns("IdTipoImpuesto").FormatearColumna("Tipo", pos, 90)
         .Columns("NombreTipoImpuesto").FormatearColumna("Nombre", pos, 150)
         .Columns("Alicuota").FormatearColumna("Alicuota", pos, 60, HAlign.Right)

         .Columns("Activo").FormatearColumna("Activo", pos, 50, HAlign.Center)

         .Columns("IdTipoImpuestoPIVA").FormatearColumna("Tipo PIVA", pos, 90)
         .Columns("NombreTipoImpuestoPIVA").FormatearColumna("Nombre PIVA", pos, 150)
         .Columns("AlicuotaPIVA").FormatearColumna("Alicuota PIVA", pos, 60, HAlign.Right)

         Dim tieneContabilidad = Reglas.Publicos.TieneModuloContabilidad
         .Columns(Entidades.Impuesto.Columnas.IdCuentaCompras.ToString()).FormatearColumna("ID Cta Compras", pos, 80, HAlign.Right, Not tieneContabilidad)
         .Columns(Entidades.Impuesto.ColumnasDescripcion.NombreCuentaCompras.ToString()).FormatearColumna("Cuenta Compras", pos, 150, , Not tieneContabilidad)
         .Columns(Entidades.Impuesto.Columnas.IdCuentaVentas.ToString()).FormatearColumna("ID Cta Ventas", pos, 80, HAlign.Right, Not tieneContabilidad)
         .Columns(Entidades.Impuesto.ColumnasDescripcion.NombreCuentaVentas.ToString()).FormatearColumna("Cuenta Ventas", pos, 150, , Not tieneContabilidad)

         dgvDatos.AgregarFiltroEnLinea({"NombreTipoImpuesto", "NombreTipoImpuestoPIVA",
                                        Entidades.Impuesto.ColumnasDescripcion.NombreCuentaCompras.ToString(),
                                        Entidades.Impuesto.ColumnasDescripcion.NombreCuentaVentas.ToString()})
      End With
   End Sub
#End Region

End Class