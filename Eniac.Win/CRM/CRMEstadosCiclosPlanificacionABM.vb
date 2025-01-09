Public Class CRMEstadosCiclosPlanificacionABM

#Region "Overrides"

   Protected Overrides Sub OnLoad(e As EventArgs)
      MyBase.OnLoad(e)
      BotonImprimir.Visible = False
   End Sub
   Protected Overrides Function GetDetalle(estado As StateForm) As BaseDetalle
      If estado = StateForm.Actualizar Then
         Return New CRMEstadosCiclosPlanificacionDetalle(DirectCast(GetEntidad(), Entidades.CRMEstadoCicloPlanificacion))
      Else
         Return New CRMEstadosCiclosPlanificacionDetalle(New Entidades.CRMEstadoCicloPlanificacion())
      End If
   End Function

   Protected Overrides Function GetReglas() As Reglas.Base
      Return New Reglas.CRMEstadosCiclosPlanificacion()
   End Function


   Protected Overrides Function GetEntidad() As Entidades.Entidad
      Dim dr = dgvDatos.FilaSeleccionada(Of DataRow)
      Return New Reglas.CRMEstadosCiclosPlanificacion().GetUno(dr.Field(Of String)(Entidades.CRMEstadoCicloPlanificacion.Columnas.IdEstadoCicloPlanificacion.ToString()))
   End Function

   Protected Overrides Sub FormatearGrilla()
      With dgvDatos.DisplayLayout.Bands(0)
         Dim col = 0I

         .Columns(Entidades.CRMEstadoCicloPlanificacion.Columnas.IdEstadoCicloPlanificacion.ToString()).FormatearColumna("Estado", col, 120)
         .Columns(Entidades.CRMEstadoCicloPlanificacion.Columnas.TipoEstadoCicloPlanificacion.ToString()).FormatearColumna("Tipo Estado", col, 120)
         .Columns(Entidades.CRMEstadoCicloPlanificacion.Columnas.Orden.ToString()).FormatearColumna("Orden", col, 60, HAlign.Right)
         .Columns(Entidades.CRMEstadoCicloPlanificacion.Columnas.PorDefecto.ToString()).FormatearColumna("Por Defecto", col, 60, HAlign.Center)
         .Columns(Entidades.CRMEstadoCicloPlanificacion.Columnas.BackColor.ToString()).FormatearColumna("Color Fondo", col, 80, HAlign.Right, hidden:=True)
         .Columns(Entidades.CRMEstadoCicloPlanificacion.Columnas.ForeColor.ToString()).FormatearColumna("Color Letras", col, 80, HAlign.Right, hidden:=True)

         dgvDatos.AgregarFiltroEnLinea({})
      End With

   End Sub

#End Region

   Private Sub dgvDatos_InitializeRow(sender As Object, e As InitializeRowEventArgs) Handles dgvDatos.InitializeRow
      TryCatched(
      Sub()
         Dim dr = e.Row.FilaSeleccionada(Of DataRow)()
         If dr IsNot Nothing Then
            Dim iBackColor = dr.Field(Of Integer?)(Entidades.CRMEstadoCicloPlanificacion.Columnas.BackColor.ToString())
            Dim iForeColor = dr.Field(Of Integer?)(Entidades.CRMEstadoCicloPlanificacion.Columnas.ForeColor.ToString())
            Dim colorPair = New ColorPair(iForeColor.ToArgbColor(), iBackColor.ToArgbColor())

            e.Row.Cells(Entidades.CRMEstadoCicloPlanificacion.Columnas.IdEstadoCicloPlanificacion.ToString()).Color(colorPair)
         End If
      End Sub)
   End Sub

End Class