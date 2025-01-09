Public Class ContabilidadCuentasRubro

#Region "Overrides"

   Protected Overrides Sub OnLoad(e As EventArgs)
      MyBase.OnLoad(e)
      tsbImprimir.Visible = False
   End Sub

   Protected Overrides Function GetDetalle(estado As StateForm) As BaseDetalle
      If estado = StateForm.Actualizar Then
         Return New ContabilidadCuentasRubroDet(DirectCast(GetEntidad(), Entidades.ContabilidadCuentaRubro))
      End If
      Return New ContabilidadCuentasRubroDet(New Entidades.ContabilidadCuentaRubro())
   End Function

   Protected Overrides Function GetReglas() As Reglas.Base
      Return New Reglas.ContabilidadCuentasRubros()
   End Function

   Protected Overrides Function GetEntidad() As Entidades.Entidad
      MyBase.GetEntidad()
      Dim cRubro = New Entidades.ContabilidadCuentaRubro()
      Dim cRubros = New Reglas.ContabilidadCuentasRubros()

      With dgvDatos.ActiveCell.Row
         cRubro = cRubros.GetUna(Integer.Parse(.Cells(Entidades.ContabilidadCuentaRubro.Columnas.IdPlanCuenta.ToString()).Value.ToString()),
                                 Integer.Parse(.Cells(Entidades.ContabilidadCuentaRubro.Columnas.IdRubro.ToString()).Value.ToString()),
                                 .Cells(Entidades.ContabilidadCuentaRubro.Columnas.Tipo.ToString()).Value.ToString(),
                                 centroEmisor:=0)
      End With
      Return cRubro
   End Function

   Protected Overrides Sub FormatearGrilla()
      With dgvDatos.DisplayLayout.Bands(0)
         Dim pos = 0I
         .Columns(Entidades.ContabilidadCuentaRubro.Columnas.IdPlanCuenta.ToString()).FormatearColumna("Plan", pos, 50, HAlign.Right)
         .Columns("NombrePlanCuenta").FormatearColumna("Plan", pos, 80)
         .Columns(Entidades.ContabilidadCuentaRubro.Columnas.IdRubro.ToString()).FormatearColumna("Código", pos, 50, HAlign.Right)
         .Columns("nombreRubro").FormatearColumna("Rubro", pos, 150)
         .Columns(Entidades.ContabilidadCuentaRubro.Columnas.IdCuenta.ToString()).FormatearColumna("Código", pos, 80, HAlign.Right)
         .Columns("NombreCuenta").FormatearColumna("Cuenta", pos, 250)
         .Columns("CentroEmisor").FormatearColumna("Emisor", pos, 80, HAlign.Right)
         .Columns("Tipo").FormatearColumna("Tipo", pos, 80)
      End With
      dgvDatos.AgregarFiltroEnLinea({"NombreCuenta"})
   End Sub

#End Region

End Class