Public Class TiposImpuestosABM

#Region "Overrides"

   Protected Overrides Sub OnLoad(e As EventArgs)
      MyBase.OnLoad(e)
      tsbImprimir.Visible = False
      tsbNuevo.Visible = False
   End Sub
   Protected Overrides Function GetDetalle(estado As StateForm) As BaseDetalle
      If estado = StateForm.Actualizar Then
         Return New TiposImpuestosDetalle(DirectCast(GetEntidad(), Entidades.TipoImpuesto))
      End If
      Return New TiposImpuestosDetalle(New Entidades.TipoImpuesto())
   End Function
   Protected Overrides Function GetReglas() As Reglas.Base
      Return New Reglas.TiposImpuestos()
   End Function
   Protected Overrides Function GetEntidad() As Entidades.Entidad
      Dim dr = dgvDatos.FilaSeleccionada(Of DataRow)()
      Return DirectCast(GetReglas(), Reglas.TiposImpuestos).GetUno(dr.Field(Of String)("IdTipoImpuesto").StringToEnum(Entidades.TipoImpuesto.Tipos.IVA))
   End Function

   Protected Overrides Sub FormatearGrilla()
      With dgvDatos.DisplayLayout.Bands(0)
         ''.SelectionMode = DataGridViewSelectionMode.FullRowSelect
         Dim pos = 0I
         .Columns(Entidades.TipoImpuesto.Columnas.IdTipoImpuesto.ToString()).FormatearColumna("Codigo", pos, 70)
         .Columns(Entidades.TipoImpuesto.Columnas.NombreTipoImpuesto.ToString()).FormatearColumna("Descripción", pos, 150)
         .Columns(Entidades.TipoImpuesto.Columnas.Tipo.ToString()).FormatearColumna("Tipo", pos, 100)

         .Columns("IdCuentaCaja").OcultoPosicion(hidden:=True, pos)
         .Columns("NombreCuentaCaja").FormatearColumna("Cuenta de Caja", pos, 150)

         .Columns(Entidades.TipoImpuesto.Columnas.AplicativoAfip).FormatearColumna("Aplicativo Afip", pos, 80)
         .Columns("CodigoArticuloInciso").FormatearColumna("Cod Art/Inc", pos, 50, HAlign.Right)
         .Columns("ArticuloInciso").FormatearColumna("Art/Inciso", pos, 50, HAlign.Right)

         'vml 10/06/13  - contabilidad
         .Columns("IdCuentaDebe").FormatearColumna("ID Cta Compras", pos, 80, , Not Reglas.Publicos.TieneModuloContabilidad)
         .Columns("NombreCuentaDebe").FormatearColumna("Cta Compras", pos, 150, , Not Reglas.Publicos.TieneModuloContabilidad)

         .Columns("IdCuentaHaber").FormatearColumna("ID Cta Ventas", pos, 80, , Not Reglas.Publicos.TieneModuloContabilidad)
         .Columns("NombreCuentaHaber").FormatearColumna("Cta Ventas", pos, 150, , Not Reglas.Publicos.TieneModuloContabilidad)

         dgvDatos.AgregarFiltroEnLinea({Entidades.TipoImpuesto.Columnas.NombreTipoImpuesto.ToString()})
      End With
   End Sub

#End Region

End Class