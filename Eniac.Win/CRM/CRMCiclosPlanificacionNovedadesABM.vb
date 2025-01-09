Public Class CRMCiclosPlanificacionNovedadesABM

#Region "Overrides"

   Protected Overrides Sub OnLoad(e As EventArgs)
      MyBase.OnLoad(e)
      'Me.BotonImprimir.Visible = False
   End Sub
   Protected Overrides Function GetDetalle(estado As StateForm) As BaseDetalle
      If estado = StateForm.Actualizar Then
         Return New CRMCiclosPlanificacionNovedadesDetalle(DirectCast(GetEntidad(), Entidades.CRMCicloPlanificacionNovedad))
      End If
      Return New CRMCiclosPlanificacionNovedadesDetalle(New Entidades.CRMCicloPlanificacionNovedad())
   End Function
   Protected Overrides Function GetReglas() As Reglas.Base
      Return GetRegla()
   End Function
   Protected Function GetRegla() As Reglas.CRMCiclosPlanificacionNovedades
      Return New Reglas.CRMCiclosPlanificacionNovedades()
   End Function

   Protected Overrides Function GetEntidad() As Entidades.Entidad
      MyBase.GetEntidad()
      Dim dr = dgvDatos.FilaSeleccionada(Of DataRow)()
      Return GetRegla().GetUno(dr.Field(Of Integer)(Entidades.CRMCicloPlanificacionNovedad.Columnas.IdCicloPlanificacion.ToString()),
                               dr.Field(Of String)(Entidades.CRMCicloPlanificacionNovedad.Columnas.IdTipoNovedad.ToString()),
                               dr.Field(Of String)(Entidades.CRMCicloPlanificacionNovedad.Columnas.Letra.ToString()),
                               dr.Field(Of Short)(Entidades.CRMCicloPlanificacionNovedad.Columnas.CentroEmisor.ToString()),
                               dr.Field(Of Long)(Entidades.CRMCicloPlanificacionNovedad.Columnas.IdNovedad.ToString()))
   End Function
   Protected Overrides Sub FormatearGrilla()

      With dgvDatos.DisplayLayout.Bands(0)
         Dim pos = 0I
         .Columns(Entidades.CRMCicloPlanificacionNovedad.Columnas.IdCicloPlanificacion.ToString()).FormatearColumna("Código Ciclo", pos, 80, HAlign.Right, hidden:=True)
         .Columns(Entidades.CRMCicloPlanificacion.Columnas.NombreCicloPlanificacion.ToString()).FormatearColumna("Ciclo", pos, 180)
         .Columns(Entidades.CRMCicloPlanificacionNovedad.Columnas.IdTipoNovedad.ToString()).FormatearColumna("Código Tipo", pos, 100, hidden:=True)
         .Columns(Entidades.CRMTipoNovedad.Columnas.NombreTipoNovedad.ToString()).FormatearColumna("Tipo", pos, 100)
         .Columns(Entidades.CRMCicloPlanificacionNovedad.Columnas.Letra.ToString()).FormatearColumna("L.", pos, 30, HAlign.Center)
         .Columns(Entidades.CRMCicloPlanificacionNovedad.Columnas.CentroEmisor.ToString()).FormatearColumna("Emisor", pos, 60, HAlign.Right)
         .Columns(Entidades.CRMCicloPlanificacionNovedad.Columnas.IdNovedad.ToString()).FormatearColumna("Número", pos, 80, HAlign.Right)
         .Columns(Entidades.CRMCicloPlanificacionNovedad.Columnas.Orden.ToString()).FormatearColumna("Órden", pos, 60, HAlign.Right)
         .Columns(Entidades.CRMCicloPlanificacionNovedad.Columnas.TipoPlanificacion.ToString()).FormatearColumna("Tipo", pos, 70, HAlign.Center)
         .Columns(Entidades.CRMCicloPlanificacionNovedad.Columnas.Planificada.ToString()).FormatearColumna("Planif.", pos, 60, HAlign.Center)

         .Columns(Entidades.CRMCicloPlanificacion.Columnas.IdEstadoCicloPlanificacion.ToString()).FormatearColumna("Estado Ciclo", pos, 120)
         .Columns(Entidades.CRMCicloPlanificacion.Columnas.FechaInicio.ToString()).FormatearColumna("Fecha Inicio", pos, 100, HAlign.Center, , Formatos.Format.FechaSinHora)
         .Columns(Entidades.CRMCicloPlanificacion.Columnas.FechaCierre.ToString()).FormatearColumna("Fecha Cierre", pos, 100, HAlign.Center, , Formatos.Format.FechaSinHora)
         .Columns(Entidades.CRMCicloPlanificacion.Columnas.FechaFinalizacion.ToString()).FormatearColumna("Fecha Fin", pos, 100, HAlign.Center, , Formatos.Format.FechaSinHora)

         .Columns(Entidades.CRMCicloPlanificacionNovedad.Columnas.IdEstadoNovedadInicio.ToString()).OcultoPosicion(hidden:=True, pos)
         .Columns(Entidades.CRMCicloPlanificacionNovedad.Columnas.IdEstadoNovedadCierre.ToString()).OcultoPosicion(hidden:=True, pos)
         .Columns(Entidades.CRMCicloPlanificacionNovedad.Columnas.IdEstadoNovedadFinal.ToString()).OcultoPosicion(hidden:=True, pos)

         .Columns("NombreEstadoNovedadInicio").FormatearColumna("Estado Inicio", pos, 100, HAlign.Center)
         .Columns("NombreEstadoNovedadCierre").FormatearColumna("Estado Cierre", pos, 100, HAlign.Center)
         .Columns("NombreEstadoNovedadFinal").FormatearColumna("Estado Fin", pos, 100, HAlign.Center)

         .Columns(Entidades.CRMEstadoCicloPlanificacion.Columnas.BackColor.ToString()).OcultoPosicion(hidden:=True, pos)
         .Columns(Entidades.CRMEstadoCicloPlanificacion.Columnas.ForeColor.ToString()).OcultoPosicion(hidden:=True, pos)

         .Columns(Entidades.CRMCicloPlanificacionNovedad.Columnas.IdUsuarioAlta.ToString()).FormatearColumna("Usuario Alta", pos, 120)
         .Columns(Entidades.CRMCicloPlanificacionNovedad.Columnas.FechaAlta.ToString()).FormatearColumna("Fecha Alta", pos, 120, HAlign.Center, , Formatos.Format.FechaCompleta)
         .Columns(Entidades.CRMCicloPlanificacionNovedad.Columnas.IdUsuarioActualizacion.ToString()).FormatearColumna("Usuario Actualización", pos, 120)
         .Columns(Entidades.CRMCicloPlanificacionNovedad.Columnas.FechaActualizacion.ToString()).FormatearColumna("Fecha Actualización", pos, 120, HAlign.Center, , Formatos.Format.FechaCompleta)

      End With

      dgvDatos.AgregarFiltroEnLinea({Entidades.CRMCicloPlanificacion.Columnas.NombreCicloPlanificacion.ToString()})
   End Sub

#End Region

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


End Class