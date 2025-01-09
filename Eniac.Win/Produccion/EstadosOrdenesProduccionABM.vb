Public Class EstadosOrdenesProduccionABM

#Region "Overrides"

   Protected Overrides Sub OnLoad(e As EventArgs)
      MyBase.OnLoad(e)
      tsbImprimir.Visible = False
   End Sub

   Protected Overrides Function GetDetalle(estado As StateForm) As BaseDetalle
      If estado = StateForm.Actualizar Then
         Return New EstadosOrdenesProduccionDetalle(DirectCast(GetEntidad(), Entidades.EstadoOrdenProduccion))
      End If
      Return New EstadosOrdenesProduccionDetalle(New Entidades.EstadoOrdenProduccion)
   End Function

   Protected Overrides Function GetReglas() As Reglas.Base
      Return New Reglas.EstadosOrdenesProduccion()
   End Function

   Protected Overrides Function GetEntidad() As Entidades.Entidad
      Dim estado = New Entidades.EstadoOrdenProduccion
      Dim eStados = New Reglas.EstadosOrdenesProduccion()
      With dgvDatos.ActiveRow
         estado = eStados.GetUno(.Cells(Entidades.EstadoOrdenProduccion.Columnas.IdEstado.ToString()).Value.ToString())
      End With
      Return Estado
   End Function

   Protected Overrides Sub FormatearGrilla()
      With dgvDatos.DisplayLayout.Bands(0)
         Dim col = 0I

         .Columns(Entidades.EstadoOrdenProduccion.Columnas.IdEstado.ToString()).FormatearColumna("Estado", col, 100)
         .Columns(Entidades.EstadoOrdenProduccion.Columnas.IdTipoComprobante.ToString()).FormatearColumna("Comprobante", col, 100)
         .Columns(Entidades.EstadoOrdenProduccion.Columnas.IdTipoEstado.ToString()).FormatearColumna("Tipo Estado", col, 100)
         .Columns(Entidades.EstadoOrdenProduccion.Columnas.Orden.ToString()).FormatearColumna("Orden", col, 60)

         .Columns("IdDeposito").OcultoPosicion(hidden:=True, col)
         .Columns(Entidades.EstadoOrdenProduccion.Columnas.NombreDeposito.ToString()).FormatearColumna("Depósito", col, 100)
         .Columns("IdUbicacion").OcultoPosicion(hidden:=True, col)
         .Columns(Entidades.EstadoOrdenProduccion.Columnas.NombreUbicacion.ToString()).FormatearColumna("Ubicación", col, 100)

         .Columns(Entidades.EstadoOrdenProduccion.Columnas.Color.ToString()).FormatearColumna("Color", col, 80, HAlign.Right)

         .Columns(Entidades.EstadoOrdenProduccion.Columnas.ReservaMateriaPrima.ToString()).FormatearColumna("Reserva MP", col, 80, HAlign.Center)
         .Columns(Entidades.EstadoOrdenProduccion.Columnas.GeneraProductoTerminado.ToString()).FormatearColumna("Genera PT", col, 80, HAlign.Center)

         .Columns(Entidades.EstadoOrdenProduccion.Columnas.TipoEstadoPedido.ToString()).FormatearColumna("Tipo Pedido", col, 80, , True)
         .Columns(Entidades.EstadoOrdenProduccion.Columnas.IdEstadoPedido.ToString()).FormatearColumna("Estado Pedido", col, 100)

         dgvDatos.AgregarFiltroEnLinea({})
      End With
   End Sub

   Protected Overrides Function ValidaBorrado(entidad As Entidades.Entidad) As Boolean
      Dim result As Boolean = MyBase.ValidaBorrado(entidad)
      Dim estado As Entidades.EstadoOrdenProduccion = DirectCast(entidad, Entidades.EstadoOrdenProduccion)
      If result Then
         If estado.IdEstado = Entidades.EstadoOrdenProduccion.ESTADO_ALTA Or estado.IdEstado = Entidades.EstadoOrdenProduccion.ESTADO_ANULADO Then
            ShowMessage(String.Format("El Estado {0} no se puede borrar", estado.IdEstado))
            Return False
         End If
      End If
      Return result
   End Function

#End Region

   Private Sub dgvDatos_InitializeRow(sender As Object, e As InitializeRowEventArgs) Handles dgvDatos.InitializeRow
      TryCatched(
      Sub()
         Dim row = e.Row.FilaSeleccionada(Of DataRow)()
         If row IsNot Nothing Then
            Dim colorColumnKey As String = Entidades.EstadoOrdenProduccion.Columnas.Color.ToString()
            If row.Table.Columns.Contains(colorColumnKey) AndAlso IsNumeric(e.Row.Cells(colorColumnKey).Value) Then
               Dim colorEstado = Color.FromArgb(Integer.Parse(e.Row.Cells(colorColumnKey).Value.ToString()))
               e.Row.Cells(colorColumnKey).Color(Nothing, colorEstado)
            End If
         End If
      End Sub)
   End Sub

End Class