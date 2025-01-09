Public Class MediosdePagoABM

   Protected Overrides Sub OnLoad(e As EventArgs)
      MyBase.OnLoad(e)
      TryCatched(
      Sub()
         tsbNuevo.Visible = False
         tsbBorrar.Visible = False
         dgvDatos.AgregarFiltroEnLinea({Entidades.MedioDePago.Columnas.NombreMedioDePago.ToString()})
      End Sub)
   End Sub

   Protected Overrides Function GetDetalle(estado As StateForm) As BaseDetalle
      If estado = StateForm.Actualizar Then
         Return New MediosDePagoDetalle(DirectCast(GetEntidad(), Entidades.MedioDePago))
      Else
         Return New MediosDePagoDetalle(New Entidades.MedioDePago())
      End If
   End Function

   Protected Overrides Function GetReglas() As Reglas.Base
      Return New Reglas.MediosdePago()
   End Function

   Protected Overrides Function GetEntidad(drFilaGrilla As DataRow) As Entidades.Entidad
      Return New Reglas.MediosdePago().GetUna(drFilaGrilla.Field(Of Integer)(Entidades.MedioDePago.Columnas.IdMedioDePago.ToString()))
   End Function

   Protected Overrides Sub FormatearGrilla()
      Dim pos = 0I
      With dgvDatos.DisplayLayout.Bands(0)
         .Columns("IdMedioDePago").FormatearColumna("Código", pos, 50, HAlign.Right)
         .Columns("NombreMedioDePago").FormatearColumna("Nombre", pos, 200)

         .Columns("IdCuenta").FormatearColumna("Cuenta", pos, 50, HAlign.Right, Not Reglas.Publicos.TieneModuloContabilidad)
         .Columns("NombreCuenta").FormatearColumna("Nombre Cuenta Contable", pos, 200, , Not Reglas.Publicos.TieneModuloContabilidad)
      End With
   End Sub
End Class