Public Class CRMMotivosNovedadesABM

#Region "Overrides"

   Protected Overrides Sub OnLoad(e As EventArgs)
      MyBase.OnLoad(e)
   End Sub
   Protected Overrides Function GetDetalle(estado As StateForm) As BaseDetalle
      If estado = StateForm.Actualizar Then
         Return New CRMMotivosNovedadesDetalle(DirectCast(GetEntidad(), Entidades.CRMMotivoNovedad))
      End If
      Return New CRMMotivosNovedadesDetalle(New Entidades.CRMMotivoNovedad())
   End Function
   Protected Overrides Function GetReglas() As Reglas.Base
      Return New Reglas.CRMMotivosNovedades()
   End Function

   Protected Overrides Sub Borrar()
      Try
         If dgvDatos.ActiveCell Is Nothing Then
            If dgvDatos.ActiveRow IsNot Nothing Then
               dgvDatos.ActiveCell = dgvDatos.ActiveRow.Cells(0)
            End If
         End If
         If dgvDatos.ActiveCell IsNot Nothing Then
            If MessageBox.Show("¿Está seguro de eliminar el registro seleccionado?", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
               Dim cl As Reglas.Base = GetReglas()
               Me._entidad = GetEntidad()
               cl.Borrar(_entidad)
               RefreshGrid()
            End If
         End If
      Catch ex As Exception
         If ex.Message.Contains("The DELETE statement conflicted with the REFERENCE constraint") Then
            MessageBox.Show("El registro NO se puede eliminar porque esta siendo utilizado.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
         Else
            MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
         End If
      End Try
   End Sub

   Protected Overrides Function GetEntidad() As Eniac.Entidades.Entidad
      MyBase.GetEntidad()
      With dgvDatos.ActiveRow
         Return New Reglas.CRMMotivosNovedades().GetUno(Integer.Parse(.Cells(Entidades.CRMMotivoNovedad.Columnas.IdMotivoNovedad.ToString()).Value.ToString()))
      End With
   End Function
   Protected Overrides Sub FormatearGrilla()
      With dgvDatos.DisplayLayout.Bands(0)
         Dim pos = 0I

         .Columns(Entidades.CRMTipoNovedad.Columnas.NombreTipoNovedad.ToString()).FormatearColumna("Tipo", pos, 100)
         .Columns(Entidades.CRMMotivoNovedad.Columnas.IdMotivoNovedad.ToString()).FormatearColumna("Código", pos, 60, HAlign.Right)
         .Columns(Entidades.CRMMotivoNovedad.Columnas.NombreMotivoNovedad.ToString()).FormatearColumna("Descripción", pos, 180)
         .Columns(Entidades.CRMMotivoNovedad.Columnas.Posicion.ToString()).FormatearColumna("Posición", pos, 70, HAlign.Right)

         .Columns(Entidades.CRMMotivoNovedad.Columnas.IdTipoNovedad.ToString()).Hidden = True
      End With

      dgvDatos.AgregarFiltroEnLinea({Entidades.CRMMotivoNovedad.Columnas.NombreMotivoNovedad.ToString()})
   End Sub

#End Region

End Class