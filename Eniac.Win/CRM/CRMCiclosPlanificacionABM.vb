Public Class CRMCiclosPlanificacionABM

#Region "Overrides"

   Protected Overrides Sub OnLoad(e As EventArgs)
      MyBase.OnLoad(e)
      'Me.BotonImprimir.Visible = False
   End Sub
   Protected Overrides Function GetDetalle(estado As StateForm) As BaseDetalle
      If estado = StateForm.Actualizar Then
         Return New CRMCiclosPlanificacionDetalle(DirectCast(GetEntidad(), Entidades.CRMCicloPlanificacion))
      End If
      Return New CRMCiclosPlanificacionDetalle(GetRegla().NewEntidad())
   End Function
   Protected Overrides Function GetReglas() As Reglas.Base
      Return GetRegla()
   End Function
   Private Function GetRegla() As Reglas.CRMCiclosPlanificacion
      Return New Reglas.CRMCiclosPlanificacion()
   End Function

   Protected Overrides Function GetEntidad() As Entidades.Entidad
      MyBase.GetEntidad()
      Return GetRegla().GetEntidad(dgvDatos.FilaSeleccionada(Of DataRow)())
   End Function
   Protected Overrides Sub FormatearGrilla()

      With dgvDatos.DisplayLayout.Bands(0)
         .OcultaTodasLasColumnas()

         Dim pos = 0I
         .Columns(Entidades.CRMCicloPlanificacion.Columnas.IdCicloPlanificacion.ToString()).FormatearColumna("Código", pos, 60, HAlign.Right)
         .Columns(Entidades.CRMCicloPlanificacion.Columnas.NombreCicloPlanificacion.ToString()).FormatearColumna("Nombre", pos, 180)
         .Columns(Entidades.CRMCicloPlanificacion.Columnas.IdEstadoCicloPlanificacion.ToString()).FormatearColumna("Estado", pos, 120)

         .Columns(Entidades.CRMCicloPlanificacion.Columnas.FechaInicio.ToString()).FormatearColumna("Fecha Inicio", pos, 70, HAlign.Center, , Formatos.Format.FechaSinHora)
         .Columns(Entidades.CRMCicloPlanificacion.Columnas.FechaCierre.ToString()).FormatearColumna("Fecha Cierre", pos, 70, HAlign.Center, , Formatos.Format.FechaSinHora)
         .Columns(Entidades.CRMCicloPlanificacion.Columnas.FechaFinalizacion.ToString()).FormatearColumna("Fecha Fin", pos, 70, HAlign.Center, , Formatos.Format.FechaSinHora)

         .Columns(Entidades.CRMCicloPlanificacion.Columnas.IdUsuarioAlta.ToString()).FormatearColumna("Usuario Alta", pos, 120)
         .Columns(Entidades.CRMCicloPlanificacion.Columnas.FechaAlta.ToString()).FormatearColumna("Fecha Alta", pos, 120, HAlign.Center, , Formatos.Format.FechaCompleta)
         .Columns(Entidades.CRMCicloPlanificacion.Columnas.IdUsuarioActualizacion.ToString()).FormatearColumna("Usuario Actualización", pos, 120)
         .Columns(Entidades.CRMCicloPlanificacion.Columnas.FechaActualizacion.ToString()).FormatearColumna("Fecha Actualización", pos, 120, HAlign.Center, , Formatos.Format.FechaCompleta)

      End With
      dgvDatos.AgregarFiltroEnLinea({Entidades.CRMCicloPlanificacion.Columnas.NombreCicloPlanificacion.ToString()})

   End Sub

#End Region

#Region "Eventos"
   Private Sub dgvDatos_InitializeRow(sender As Object, e As InitializeRowEventArgs) Handles dgvDatos.InitializeRow
      TryCatched(
      Sub()
         Dim dr = e.Row.FilaSeleccionada(Of DataRow)()
         If dr IsNot Nothing Then
            Dim colorBackColumnKey = Entidades.CRMEstadoCicloPlanificacion.Columnas.BackColor.ToString()
            Dim colorForeColumnKey = Entidades.CRMEstadoCicloPlanificacion.Columnas.ForeColor.ToString()

            Dim color = ColorPair.FromInteger(dr.Field(Of Integer?)(colorForeColumnKey), dr.Field(Of Integer?)(colorBackColumnKey))
            e.Row.Cells(Entidades.CRMCicloPlanificacion.Columnas.IdEstadoCicloPlanificacion.ToString()).Color(color)
         End If
      End Sub)
   End Sub
#End Region

End Class