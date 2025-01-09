Public Class CRMEstadosNovedadesABM

#Region "Overrides"

   Protected Overrides Sub OnLoad(e As EventArgs)
      MyBase.OnLoad(e)
      'Me.BotonImprimir.Visible = False
   End Sub
   Protected Overrides Function GetDetalle(estado As StateForm) As BaseDetalle
      If estado = StateForm.Actualizar Then
         Return New CRMEstadosNovedadesDetalle(DirectCast(Me.GetEntidad(), Entidades.CRMEstadoNovedad))
      End If
      Return New CRMEstadosNovedadesDetalle(New Entidades.CRMEstadoNovedad())
   End Function
   Protected Overrides Function GetReglas() As Eniac.Reglas.Base
      Return New Reglas.CRMEstadosNovedades()
   End Function

   Protected Overrides Sub Borrar()
      Try
         If Me.dgvDatos.ActiveCell Is Nothing Then
            If Me.dgvDatos.ActiveRow IsNot Nothing Then
               Me.dgvDatos.ActiveCell = Me.dgvDatos.ActiveRow.Cells(0)
            End If
         End If
         If Me.dgvDatos.ActiveCell IsNot Nothing Then
            If MessageBox.Show("¿Está seguro de eliminar el registro seleccionado?", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
               Dim cl As Reglas.Base = GetReglas()
               Me._entidad = Me.GetEntidad()
               cl.Borrar(Me._entidad)
               Me.RefreshGrid()
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
      With Me.dgvDatos.ActiveRow
         Return New Reglas.CRMEstadosNovedades().GetUno(Integer.Parse(.Cells(Entidades.CRMEstadoNovedad.Columnas.IdEstadoNovedad.ToString()).Value.ToString()))
      End With
   End Function
   Protected Overrides Sub FormatearGrilla()

      With Me.dgvDatos.DisplayLayout.Bands(0)

         Dim col As Integer = 0

         .Columns(Entidades.CRMCategoriaNovedad.Columnas.IdTipoNovedad.ToString()).Hidden = True

         .Columns(Entidades.CRMTipoNovedad.Columnas.NombreTipoNovedad.ToString()).FormatearColumna("Tipo", col, 100)
         .Columns(Entidades.CRMEstadoNovedad.Columnas.IdEstadoNovedad.ToString()).FormatearColumna("Código", col, 60, HAlign.Right)
         .Columns(Entidades.CRMEstadoNovedad.Columnas.NombreEstadoNovedad.ToString()).FormatearColumna("Descripción", col, 180)
         .Columns(Entidades.CRMEstadoNovedad.Columnas.Posicion.ToString()).FormatearColumna("Posición", col, 70, HAlign.Right)
         .Columns(Entidades.CRMEstadoNovedad.Columnas.Color.ToString()).FormatearColumna("Color", col, 80, HAlign.Right)

         .Columns(Entidades.CRMEstadoNovedad.Columnas.SolicitaUsuario.ToString()).FormatearColumna("Solicita Usuario (x)", col, 70, HAlign.Center, True)
         .Columns(Entidades.CRMEstadoNovedad.Columnas.SolicitaUsuario.ToString() + "_SN").FormatearColumna("Solicita Usuario", col, 70, HAlign.Center)

         .Columns(Entidades.CRMEstadoNovedad.Columnas.ActualizaUsuarioResponsable.ToString()).FormatearColumna("Act. Responsable (x)", col, 75, HAlign.Center, True)
         .Columns(Entidades.CRMEstadoNovedad.Columnas.ActualizaUsuarioResponsable.ToString() + "_SN").FormatearColumna("Act. Responsable", col, 75, HAlign.Center)

         .Columns(Entidades.CRMEstadoNovedad.Columnas.Finalizado.ToString()).FormatearColumna("Finalizado (x)", col, 70, HAlign.Center, True)
         .Columns(Entidades.CRMEstadoNovedad.Columnas.Finalizado.ToString() + "_SN").FormatearColumna("Finalizado", col, 70, HAlign.Center)
         .Columns(Entidades.CRMEstadoNovedad.Columnas.Entregado.ToString()).FormatearColumna("Entregado", col, 70)

         .Columns(Entidades.CRMEstadoNovedad.Columnas.PorDefecto.ToString()).FormatearColumna("Pred. (x)", col, 70, HAlign.Center, True)
         .Columns(Entidades.CRMEstadoNovedad.Columnas.PorDefecto.ToString() + "_SN").FormatearColumna("Pred.", col, 70, HAlign.Center)

         .Columns(Entidades.CRMEstadoNovedad.Columnas.DiasProximoContacto.ToString()).FormatearColumna("Días Próx. Contacto", col, 70, HAlign.Right)

         .Columns(Entidades.CRMEstadoNovedad.Columnas.SolicitaProveedorService.ToString()).FormatearColumna("Solicita Proveedor (x)", col, 70, HAlign.Center, True)
         .Columns(Entidades.CRMEstadoNovedad.Columnas.SolicitaProveedorService.ToString() + "_SN").FormatearColumna("Solicita Proveedor", col, 70, HAlign.Center)

         .Columns(Entidades.CRMEstadoNovedad.Columnas.RequiereComentarios.ToString()).FormatearColumna("Requiere Comentarios (x)", col, 70, HAlign.Center, True)
         .Columns(Entidades.CRMEstadoNovedad.Columnas.RequiereComentarios.ToString() + "_SN").FormatearColumna("Requiere Comentarios", col, 70, HAlign.Center)

         .Columns(Entidades.CRMEstadoNovedad.Columnas.Imprime.ToString()).FormatearColumna("Imprime (x)", col, 70, HAlign.Center, True)
         .Columns(Entidades.CRMEstadoNovedad.Columnas.Imprime.ToString() + "_SN").FormatearColumna("Imprime", col, 70, HAlign.Center)

         .Columns(Entidades.CRMEstadoNovedad.Columnas.AcumulaContador1.ToString()).FormatearColumna("Acum. 1 (x)", col, 70, HAlign.Center, True)
         .Columns(Entidades.CRMEstadoNovedad.Columnas.AcumulaContador1.ToString() + "_SN").FormatearColumna("Acum. 1", col, 70, HAlign.Center)
         .Columns(Entidades.CRMEstadoNovedad.Columnas.AcumulaContador2.ToString()).FormatearColumna("Acum. 2 (x)", col, 70, HAlign.Center, True)
         .Columns(Entidades.CRMEstadoNovedad.Columnas.AcumulaContador2.ToString() + "_SN").FormatearColumna("Acum. 2", col, 70, HAlign.Center)
         .Columns(Entidades.CRMEstadoNovedad.Columnas.EsFacturable.ToString()).FormatearColumna("EsFacturable", col, 70, HAlign.Center, True)
         .Columns("EstadoFacturado").FormatearColumna("Estado Facturado", col, 70, HAlign.Left)
         .Columns(Entidades.CRMEstadoNovedad.Columnas.IdEstadoFacturado.ToString()).FormatearColumna("IdEstadoFacturado", col, 70, HAlign.Right, True)
         .Columns(Entidades.CRMEstadoNovedad.Columnas.AvanceEstadoFacturado.ToString()).FormatearColumna("% Avance Estado", col, 70, HAlign.Right)


         .Columns(Entidades.CRMEstadoNovedad.Columnas.Reporte.ToString()).FormatearColumna("Reporte", col, 180)
         .Columns(Entidades.CRMEstadoNovedad.Columnas.Embebido.ToString()).FormatearColumna("Embebido (x)", col, 70, HAlign.Center, True)
         .Columns(Entidades.CRMEstadoNovedad.Columnas.Embebido.ToString() + "_SN").FormatearColumna("Embebido", col, 70, HAlign.Center)
         .Columns(Entidades.CRMEstadoNovedad.Columnas.CantidadCopias.ToString()).FormatearColumna("Copias", col, 70, HAlign.Right)
         .Columns(Entidades.CRMEstadoNovedad.Columnas.IdTipoEstadoNovedad.ToString()).FormatearColumna("IdTipoEstado", col, 70, HAlign.Right, True)
         .Columns("NombreTipoEstadoNovedad").FormatearColumna("Tipo Estado", col, 90, HAlign.Left)
      End With
      dgvDatos.AgregarFiltroEnLinea({Entidades.CRMEstadoNovedad.Columnas.NombreEstadoNovedad.ToString()})

   End Sub

#End Region

#Region "Eventos"
   Private Sub dgvDatos_InitializeRow(sender As Object, e As InitializeRowEventArgs) Handles dgvDatos.InitializeRow
      TryCatched(
         Sub()
            Dim row = dgvDatos.FilaSeleccionada(Of DataRow)(e.Row)
            If row IsNot Nothing Then
               Dim colorColumnKey = Entidades.EstadoPedido.Columnas.Color.ToString()
               If row.Table.Columns.Contains(colorColumnKey) AndAlso IsNumeric(e.Row.Cells(colorColumnKey).Value) Then
                  Dim colorEstado = Color.FromArgb(Integer.Parse(e.Row.Cells(colorColumnKey).Value.ToString()))
                  e.Row.Cells(colorColumnKey).Color(colorEstado, colorEstado)
               End If
            End If
         End Sub)
   End Sub
#End Region

End Class