Public Class EstadosOrdenesCalidadABM

#Region "Overrides"

   Protected Overrides Sub OnLoad(e As EventArgs)
      MyBase.OnLoad(e)
      BotonImprimir.Visible = False
   End Sub
   Protected Overrides Function GetDetalle(estado As StateForm) As BaseDetalle
      If estado = StateForm.Actualizar Then
         Return New EstadosOrdenesCalidadDetalle(DirectCast(GetEntidad(), Entidades.EstadoOrdenCalidad))
      Else
         Return New EstadosOrdenesCalidadDetalle(New Entidades.EstadoOrdenCalidad())
      End If
   End Function

   Protected Overrides Function GetReglas() As Reglas.Base
      Return New Reglas.EstadosOrdenesCalidad()
   End Function


   Protected Overrides Function GetEntidad() As Entidades.Entidad
      Dim dr = dgvDatos.FilaSeleccionada(Of DataRow)
      Return New Reglas.EstadosOrdenesCalidad().GetUno(dr.Field(Of String)(Entidades.EstadoOrdenCalidad.Columnas.IdEstadoCalidad.ToString()))
   End Function

   Protected Overrides Sub FormatearGrilla()
      With Me.dgvDatos.DisplayLayout.Bands(0)
         Dim col = 0I

         .Columns(Entidades.EstadoOrdenCalidad.Columnas.IdEstadoCalidad.ToString()).FormatearColumna("Estado", col, 120)
         .Columns(Entidades.EstadoOrdenCalidad.Columnas.TipoEstadoCalidad.ToString()).FormatearColumna("Tipo Estado", col, 120)
         .Columns(Entidades.EstadoOrdenCalidad.Columnas.Orden.ToString()).FormatearColumna("Orden", col, 60, HAlign.Right)
         .Columns(Entidades.EstadoOrdenCalidad.Columnas.BackColor.ToString()).FormatearColumna("Color Fondo", col, 80, HAlign.Right, hidden:=True)
         .Columns(Entidades.EstadoOrdenCalidad.Columnas.ForeColor.ToString()).FormatearColumna("Color Letras", col, 80, HAlign.Right, hidden:=True)

         dgvDatos.AgregarFiltroEnLinea({})
      End With

   End Sub

#End Region

   Private Sub dgvDatos_InitializeRow(sender As Object, e As InitializeRowEventArgs) Handles dgvDatos.InitializeRow
      TryCatched(
      Sub()
         Dim dr = e.Row.FilaSeleccionada(Of DataRow)()
         If dr IsNot Nothing Then
            Dim iBackColor = dr.Field(Of Integer?)(Entidades.EstadoOrdenCalidad.Columnas.BackColor.ToString())
            Dim iForeColor = dr.Field(Of Integer?)(Entidades.EstadoOrdenCalidad.Columnas.ForeColor.ToString())
            Dim colorPair = New ColorPair(iForeColor.ToArgbColor(), iBackColor.ToArgbColor())

            e.Row.Cells(Entidades.EstadoOrdenCalidad.Columnas.IdEstadoCalidad.ToString()).Color(colorPair)
         End If
      End Sub)
   End Sub

End Class