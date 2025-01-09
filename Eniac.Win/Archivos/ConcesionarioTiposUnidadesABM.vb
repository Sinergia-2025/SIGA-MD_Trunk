Public Class ConcesionarioTiposUnidadesABM
#Region "Overrides"
   Protected Overrides Sub OnLoad(ByVal e As EventArgs)
      MyBase.OnLoad(e)
      Me.dgvDatos.AgregarFiltroEnLinea({"NombreTipoUnidad"})
   End Sub

   'GET DETALLE
   Protected Overrides Function GetDetalle(ByVal estado As StateForm) As Win.BaseDetalle
      If estado = StateForm.Actualizar Then
         Return New ConcesionarioTiposUnidadesDetalle(DirectCast(Me.GetEntidad(), Entidades.ConcesionarioTipoUnidad))
      End If
      Return New ConcesionarioTiposUnidadesDetalle(New Entidades.ConcesionarioTipoUnidad)
   End Function
   'GET REGLLAS
   Protected Overrides Function GetReglas() As Reglas.Base
      Return New Reglas.ConcesionarioTiposUnidades()
   End Function
   'GET ENTIDAD
   Protected Overrides Function GetEntidad() As Entidades.Entidad
      MyBase.GetEntidad()
      Dim tipoUnidad As Entidades.ConcesionarioTipoUnidad = New Entidades.ConcesionarioTipoUnidad()
      Dim r As Reglas.ConcesionarioTiposUnidades = New Reglas.ConcesionarioTiposUnidades()

      With Me.dgvDatos.ActiveCell.Row
         tipoUnidad.IdTipoUnidad = Integer.Parse(.Cells("IdTipoUnidad").Value.ToString())
         tipoUnidad = r.GetUno(tipoUnidad.IdTipoUnidad)
      End With
      Return tipoUnidad
   End Function
   'IMPRIMIR
   Protected Overrides Sub Imprimir()
      MyBase.Imprimir()
      'Try
      '   Me.Cursor = Cursors.WaitCursor
      '   Dim frmImprime As VisorReportes = New VisorReportes("Eniac.Win.TiposUnidades.rdlc", "SistemaDataSet_TiposUnidades", Me.dtDatos, True, 1) '# 1 = Cantidad Copias
      '   frmImprime.Text = "TiposUnidades"
      '   frmImprime.Show()
      '   Me.Cursor = Cursors.Default
      'Catch ex As Exception
      '   MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      'End Try
   End Sub
   'FORMATEAR GRILLA
   Protected Overrides Sub FormatearGrilla()
      With Me.dgvDatos.DisplayLayout.Bands(0)
         Dim col As Integer = 0
         .Columns(Eniac.Entidades.ConcesionarioTipoUnidad.columnas.IdTipoUnidad.ToString()).FormatearColumna("Código", col, 80)
         .Columns(Eniac.Entidades.ConcesionarioTipoUnidad.columnas.NombreTipoUnidad.ToString()).FormatearColumna("Nombre", col, 150)
         .Columns(Eniac.Entidades.ConcesionarioTipoUnidad.columnas.DescripcionTipoUnidad.ToString()).FormatearColumna("Descripción", col, 250)
         .Columns(Eniac.Entidades.ConcesionarioTipoUnidad.columnas.MuestraEnCerokm.ToString()).FormatearColumna("Muestra en Cero Km", col, 90)
         .Columns(Eniac.Entidades.ConcesionarioTipoUnidad.columnas.MuestraEnUsado.ToString()).FormatearColumna("Muestra en Usados", col, 90)
         .Columns(Eniac.Entidades.ConcesionarioTipoUnidad.columnas.SolicitaDistribucionEje.ToString()).FormatearColumna("Solicita Distribucion Eje", col, 90)
      End With
   End Sub
#End Region
End Class