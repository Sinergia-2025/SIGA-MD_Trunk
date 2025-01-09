Option Strict Off
Public Class ucNovedadesProductos

   Public Property IdCliente As Long?

   Protected Overrides Sub OnLoad(e As EventArgs)
      MyBase.OnLoad(e)
      Try
         Me._publicos = New Publicos()
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
      End Try
   End Sub

   Private Sub bscCodigoProducto_BuscadorClick() Handles bscCodigoProducto.BuscadorClick

      Try
         Me.Cursor = Cursors.WaitCursor
         Me._publicos.PreparaGrillaProductos2(Me.bscCodigoProducto)
         Dim oP As Reglas.Productos = New Reglas.Productos()
         Me.bscCodigoProducto.Datos = oP.GetPorCodigo(Me.bscCodigoProducto.Text.Trim(), actual.Sucursal.Id, Publicos.ListaPreciosPredeterminada, "TODOS", , , , , , , , , IdCliente)
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      Finally
         Me.Cursor = Cursors.Default
      End Try
   End Sub

   Private Sub bscCodigoProyecto_BuscadorSeleccion(sender As Object, e As Controles.BuscadorEventArgs) Handles bscCodigoProducto.BuscadorSeleccion
      Try
         Me.Cursor = Cursors.WaitCursor
         If Not e.FilaDevuelta Is Nothing Then
            Me.CargarDatosProducto(e.FilaDevuelta)
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      Finally
         Me.Cursor = Cursors.Default
      End Try
   End Sub

   Private Sub bscProyecto_BuscadorClick() Handles bscProducto.BuscadorClick
      Try
         Me.Cursor = Cursors.WaitCursor
         Dim oProductos As Eniac.Reglas.Productos = New Eniac.Reglas.Productos
         Me._publicos.PreparaGrillaProductos2(Me.bscProducto)
         Me.bscProducto.Datos = oProductos.GetPorNombre(Me.bscProducto.Text.Trim(), actual.Sucursal.Id, Publicos.ListaPreciosPredeterminada, "TODOS", , , , , , , , IdCliente)
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
      Finally
         Me.Cursor = Cursors.Default
      End Try
   End Sub

   Private Sub bscProyecto_BuscadorSeleccion(sender As Object, e As Controles.BuscadorEventArgs) Handles bscProducto.BuscadorSeleccion
      Try
         Me.Cursor = Cursors.WaitCursor
         If Not e.FilaDevuelta Is Nothing Then
            Me.CargarDatosProducto(e.FilaDevuelta)
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      Finally
         Me.Cursor = Cursors.Default
      End Try
   End Sub

   Private Sub CargarDatosProducto(ByVal dr As DataGridViewRow)

      Me.bscCodigoProducto.Text = dr.Cells("IdProducto").Value.ToString().Trim()
      Me.bscProducto.Text = dr.Cells("NombreProducto").Value.ToString().Trim()
      Me.txtNroCarroceria.Text = dr.Cells(Entidades.Producto.Columnas.CalidadNroCarroceria.ToString()).Value.ToString().Trim()
      Me.txtNroChasis.Text = dr.Cells(Entidades.Producto.Columnas.CalidadNumeroChasis.ToString()).Value.ToString().Trim()

      OnSelectedChanged(Nothing)

   End Sub

   Public Property IdProductoNovedad() As String
      Get
         If Me.bscCodigoProducto.Selecciono Or Me.bscProducto.Selecciono Then
            Return Me.bscCodigoProducto.Text.Trim()
         Else
            Return String.Empty
         End If
      End Get
      Set(ByVal value As String)
         Try
            If value <> String.Empty Then
               Me.bscCodigoProducto.Text = value
               Me.bscCodigoProducto.PresionarBoton()
            Else
               Me.bscCodigoProducto.Text = String.Empty
               Me.bscCodigoProducto.Text = String.Empty
            End If
            OnSelectedChanged(Nothing)
         Catch ex As Exception
            Me.bscCodigoProducto.Text = String.Empty
            Me.bscCodigoProducto.Text = String.Empty
            OnSelectedChanged(Nothing)
            MessageBox.Show(String.Format("No se pudo recuperar el Producto: {0}", ex.Message), FindForm().Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
         End Try
      End Set
   End Property

   'Private Sub bscCodigoProducto_TextChange(sender As Object, e As EventArgs) Handles bscCodigoProducto.TextChange, bscProducto.TextChange
   '   Try
   '      Me.txtPrioridad.Clear()
   '      Me.txtClasificacion.Clear()
   '      Me.txtEstado.Text = String.Empty
   '   Catch ex As Exception
   '      MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Information)
   '   End Try

   'End Sub

End Class
