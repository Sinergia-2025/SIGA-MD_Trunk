Public Class ParametrosSucursalesABM

#Region "Overrides"
   Protected Overrides Function GetDetalle(estado As StateForm) As Eniac.Win.BaseDetalle
      If estado = StateForm.Actualizar Then
         Return New ParametrosSucursalesDetalle(DirectCast(GetEntidad(), Entidades.ParametroSucursal))
      End If
      Return New ParametrosSucursalesDetalle(New Entidades.ParametroSucursal() With {.IdSucursal = actual.Sucursal.Id, .IdEmpresa = actual.Sucursal.IdEmpresa})
   End Function

   Protected Overrides Function GetReglas() As Reglas.Base
      Return New Reglas.ParametrosSucursales()
   End Function

   Protected Overrides Function GetEntidad() As Entidades.Entidad
      Return New Reglas.ParametrosSucursales().GetUno(dgvDatos.ActiveRow.Cells("IdParametro").Value.ToString())
   End Function

   Protected Overrides Sub FormatearGrilla()
      With Me.dgvDatos.DisplayLayout.Bands(0)
         For Each columna As UltraGridColumn In .Columns
            columna.Hidden = True
         Next
         Dim pos As Integer = 0
         .Columns("IdParametro").FormatearColumna("Código", pos, 250)
         .Columns("DescripcionParametro").FormatearColumna("Descripción", pos, 390)
         .Columns("ValorParametro").FormatearColumna("Valor", pos, 150)
         .Columns("CategoriaParametro").FormatearColumna("Categoría", pos, 150)
         .Columns("ValorParametroOriginal").FormatearColumna("Valor Empresa", pos, 150)
         .Columns("UbicacionParametro").FormatearColumna("Ubicación", pos, 400)
      End With
      dgvDatos.AgregarFiltroEnLinea({"IdParametro", "ValorParametro", "DescripcionParametro", "CategoriaParametro", "ValorParametroOriginal", "UbicacionParametro"})
   End Sub
#End Region

End Class