Public Class CRMTiposNovedadesObjetivosABM

#Region "Overrides"

   Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)
      MyBase.OnLoad(e)
      'Me.BotonImprimir.Visible = False
   End Sub
   Protected Overrides Function GetDetalle(ByVal estado As StateForm) As Eniac.Win.BaseDetalle
      If estado = StateForm.Actualizar Then
         Return New CRMTiposNovedadesObjetivosDetalle(DirectCast(Me.GetEntidad(), Entidades.CRMTipoNovedadObjetivo))
      End If
      Return New CRMTiposNovedadesObjetivosDetalle(New Eniac.Entidades.CRMTipoNovedadObjetivo())
   End Function
   Protected Overrides Function GetReglas() As Eniac.Reglas.Base
      Return New Eniac.Reglas.CRMTiposNovedadesObjetivos()
   End Function

   Protected Overrides Function GetEntidad() As Eniac.Entidades.Entidad
      MyBase.GetEntidad()
      With Me.dgvDatos.ActiveRow
         Return New Reglas.CRMTiposNovedadesObjetivos().GetUno(.Cells(Entidades.CRMTipoNovedadObjetivo.Columnas.IdTipoNovedad.ToString()).Value.ToString(),
                                                               Integer.Parse(.Cells(Entidades.CRMTipoNovedadObjetivo.Columnas.PeriodoObjetivo.ToString()).Value.ToString()).FromPeriodo())
      End With
   End Function
   Protected Overrides Sub FormatearGrilla()

      With Me.dgvDatos.DisplayLayout.Bands(0)

         Dim col As Integer = 0

         .Columns(Entidades.CRMTipoNovedadObjetivo.Columnas.IdTipoNovedad.ToString()).Hidden = True
         .Columns(Entidades.CRMTipoNovedad.Columnas.NombreTipoNovedad.ToString()).FormatearColumna("Tipo", col, 100)

         .Columns(Entidades.CRMTipoNovedadObjetivo.Columnas.PeriodoObjetivo.ToString()).FormatearColumna("Periodo", col, 80, HAlign.Right)
         .Columns(Entidades.CRMTipoNovedadObjetivo.Columnas.IdUsuarioActualizacion.ToString()).FormatearColumna("Usuario Actualización", col, 180)
         .Columns(Entidades.CRMTipoNovedadObjetivo.Columnas.FechaActualizacion.ToString()).FormatearColumna("Fecha Última Actualización", col, 80, HAlign.Center, , "dd/MM/yyyy")
      End With
      dgvDatos.AgregarFiltroEnLinea({Entidades.CRMTipoNovedad.Columnas.NombreTipoNovedad.ToString()})

   End Sub

#End Region

   '#Region "Eventos"
   '   Private Sub dgvDatos_InitializeRow(sender As Object, e As UltraWinGrid.InitializeRowEventArgs) Handles dgvDatos.InitializeRow
   '      Try
   '         If e.Row IsNot Nothing AndAlso
   '            e.Row.ListObject IsNot Nothing AndAlso
   '            TypeOf (e.Row.ListObject) Is DataRowView AndAlso
   '            DirectCast(e.Row.ListObject, DataRowView).Row IsNot Nothing Then
   '            Dim row As DataRow = DirectCast(e.Row.ListObject, DataRowView).Row
   '            Dim colorColumnKey As String = Entidades.EstadoPedido.Columnas.Color.ToString()
   '            If row.Table.Columns.Contains(colorColumnKey) AndAlso IsNumeric(e.Row.Cells(colorColumnKey).Value) Then
   '               Dim colorEstado As Color = Color.FromArgb(Integer.Parse(e.Row.Cells(colorColumnKey).Value.ToString()))
   '               e.Row.Cells(colorColumnKey).Appearance.BackColor = colorEstado
   '               e.Row.Cells(colorColumnKey).Appearance.ForeColor = colorEstado
   '               e.Row.Cells(colorColumnKey).ActiveAppearance.BackColor = colorEstado
   '               e.Row.Cells(colorColumnKey).ActiveAppearance.ForeColor = colorEstado
   '            End If
   '         End If
   '      Catch ex As Exception
   '         ShowError(ex)
   '      End Try
   '   End Sub
   '#End Region

End Class