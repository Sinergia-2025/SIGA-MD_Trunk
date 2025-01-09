Public Class RolesABM

#Region "Overrides"

   Protected Overrides Function GetDetalle(estado As StateForm) As BaseDetalle
      If estado = StateForm.Actualizar Then
         Return New RolesDetalle(DirectCast(GetEntidad(), Entidades.Rol))
      End If
      Return New RolesDetalle(New Entidades.Rol())
   End Function
   Protected Overrides Function GetReglas() As Reglas.Base
      Return New Reglas.Roles()
   End Function
   Protected Overrides Sub Imprimir()
      MyBase.Imprimir()
      TryCatched(
         Sub()
            Dim frmImprime = New VisorReportes("Eniac.Win.Roles.rdlc", "MarinzaldiDataSet_Clientes", dtDatos, True, cantidadCopias:=1)
            frmImprime.Text = "Roles"
            frmImprime.Show()
         End Sub)
   End Sub
   Protected Overrides Function GetEntidad() As Entidades.Entidad
      With dgvDatos.ActiveCell.Row
         Return New Reglas.Roles().GetUno(.FilaSeleccionada(Of DataRow).Field(Of String)(Entidades.Rol.Columnas.Id.ToString()))
      End With
   End Function
   Protected Overrides Sub FormatearGrilla()
      With dgvDatos.DisplayLayout.Bands(0)
         Dim pos = 0I
         .Columns("Id").FormatearColumna("Id", pos, 80)
         .Columns("Nombre").FormatearColumna("Nombre", pos, 150)
         .Columns("Descripcion").FormatearColumna("Descripción", pos, 250)
      End With
      dgvDatos.AgregarFiltroEnLinea({"Nombre", "Descripción"})
   End Sub

#End Region

End Class