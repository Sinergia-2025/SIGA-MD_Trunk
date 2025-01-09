Option Explicit On
Option Strict On

Imports Eniac.Reglas
Imports Eniac.Service.Reglas
Imports actual = Eniac.Entidades.Usuario.Actual

Public Class ProductosRecepcionF

#Region "Campos"

   Private _publicos As Eniac.Win.Publicos

#End Region

#Region "Overrides"

   Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)
      MyBase.OnLoad(e)
      Try

         Me._publicos = New Eniac.Win.Publicos()
         Dim oUsuario As Eniac.Reglas.Usuarios = New Eniac.Reglas.Usuarios()

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

#End Region

#Region "Eventos"

   Private Sub ProductosRecepcionF_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyUp
      If e.KeyCode = Keys.F5 Then
         Me.tsbRefrescar_Click(Me.tsbRefrescar, New EventArgs())
      End If
   End Sub

   Private Sub tsbRefrescar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbRefrescar.Click
      Try
         Me.LimpiarCampos()
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub tsbRecibir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbRecibir.Click
      Try
         If Me.dgvProductos.SelectedRows.Count > 0 Then
            Dim nota As Eniac.Entidades.RecepcionNotaF = New Eniac.Entidades.RecepcionNotaF()
            Dim regE As Eniac.Reglas.RecepcionEstadosF = New Eniac.Reglas.RecepcionEstadosF()

            With nota
               'siempre obtengo el estado 10 (Devuelto), es el primer estado que va a tomar el producto
               .Estado = regE.GetUno(10)
               'cargo el producto
               .Producto = DirectCast(New Eniac.Reglas.Productos().GetUno(Me.dgvProductos.SelectedRows(0).Cells("IdProducto").Value.ToString()), Eniac.Entidades.Producto)
               'cargo la ficha
               .Ficha = New Eniac.Reglas.Fichas().GetUna(Long.Parse(Me.bscCodigoCliente.Tag.ToString()), Int32.Parse(Me.dgvProductos.SelectedRows(0).Cells("NroOperacion").Value.ToString()), Int32.Parse(Me.dgvProductos.SelectedRows(0).Cells("IdSucursal").Value.ToString()))
               'cargo la cantidad de productos que compro
               .CantidadProductos = Decimal.Parse(Me.dgvProductos.SelectedRows(0).Cells("Cantidad").Value.ToString())
               'cargo el cliente
               .Cliente = New Eniac.Reglas.Clientes().GetUno(Long.Parse(Me.bscCodigoCliente.Tag.ToString()))
               .IdSucursal = actual.Sucursal.Id
               .Usuario = actual.Nombre
            End With

            Dim recNota As Eniac.Reglas.RecepcionNotasF = New Eniac.Reglas.RecepcionNotasF()

            If recNota.ExisteLaNota(nota.Ficha.IdSucursal, nota.Cliente.IdCliente, nota.Ficha.NroOperacion, nota.Producto.IdProducto) Then
               If MessageBox.Show("Ya existe una nota para este articulo, desea continuar?", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                  'abre el formulario de nota de recepcion enviandole la nota
                  Dim frm As NotaRecepcionF = New NotaRecepcionF(nota)
                  frm.ShowDialog()
               End If
            Else
               'abre el formulario de nota de recepcion enviandole la nota
               Dim frm As NotaRecepcionF = New NotaRecepcionF(nota)
               frm.ShowDialog()
            End If
         End If

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub tsbSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbSalir.Click
      Me.Close()
   End Sub

   Private Sub btnConsultar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnConsultar.Click
      Try
         If Me.Validar() Then
            Me.Cursor = Cursors.WaitCursor
            Me.tslRegistros.Text = "0 Registros"
            Me.tspBarra.Visible = True
            Me.Refresh()

            Dim oPro As Reglas.ProductosRecepcionF = New Reglas.ProductosRecepcionF()
            Me.dgvProductos.DataSource = oPro.GetProductosVendidos(actual.Sucursal.Id, Long.Parse(Me.bscCodigoCliente.Tag.ToString()), Me.dtpFechaDesde.Value, Me.dtpFechaHasta.Value)

            Me.tslRegistros.Text = Me.dgvProductos.RowCount.ToString() + " Registros"

            Me.dgvProductos.Focus()
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      Finally
         Me.tspBarra.Visible = False
         Me.Cursor = Cursors.Default
      End Try
   End Sub

   Private Sub bscNroDoc_BuscadorClick() Handles bscCodigoCliente.BuscadorClick
      Try
         Me._publicos.PreparaGrillaClientes2(Me.bscCodigoCliente)
         Dim oClientes As Clientes = New Clientes
         Dim codigoCliente As Long = -1
         If Me.bscCodigoCliente.Text.Trim.Length > 0 Then
            codigoCliente = Long.Parse(Me.bscCodigoCliente.Text.Trim())
         End If
         Me.bscCodigoCliente.Datos = oClientes.GetFiltradoPorCodigo(codigoCliente, True, False)
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub bscNroDoc_BuscadorSeleccion(ByVal sender As Object, ByVal e As Controles.BuscadorEventArgs) Handles bscCodigoCliente.BuscadorSeleccion
      Try
         If Not e.FilaDevuelta Is Nothing Then
            Me.CargarDatosCliente(e.FilaDevuelta)
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub bscCliente_BuscadorClick() Handles bscCliente.BuscadorClick
      Try
         Me._publicos.PreparaGrillaClientes2(Me.bscCliente)
         Dim oClientes As Clientes = New Clientes
         Me.bscCliente.Datos = oClientes.GetFiltradoPorNombre(Me.bscCliente.Text.Trim(), True)

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub bscCliente_BuscadorSeleccion(ByVal sender As Object, ByVal e As Controles.BuscadorEventArgs) Handles bscCliente.BuscadorSeleccion
      Try
         If Not e.FilaDevuelta Is Nothing Then
            Me.CargarDatosCliente(e.FilaDevuelta)
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub dgvProductos_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgvProductos.SelectionChanged
      Me.tsbRecibir.Enabled = True
   End Sub

#End Region

#Region "Metodos"

   Private Sub LimpiarCampos()

      Me.tsbRecibir.Enabled = False

      Me.bscCodigoCliente.Text = String.Empty
      Me.bscCodigoCliente.Enabled = True
      Me.bscCliente.Text = String.Empty
      Me.bscCliente.Enabled = True
      Me.txtDireccion.Text = String.Empty
      'Me.txtCP.Text = String.Empty
      Me.txtLocalidad.Text = String.Empty
      Me.txtTelefono.Text = String.Empty
      Me.dtpFechaDesde.Value = Date.Now
      Me.dtpFechaHasta.Value = Date.Now

      If Not Me.dgvProductos.DataSource Is Nothing Then
         DirectCast(Me.dgvProductos.DataSource, DataTable).Rows.Clear()
      End If

      Me.bscCodigoCliente.Focus()

   End Sub

   Private Function Validar() As Boolean
      If Not (Me.bscCliente.Selecciono Or Me.bscCodigoCliente.Selecciono) Then
         MessageBox.Show("Debe seleccionar un cliente", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
         Me.bscCodigoCliente.Focus()
         Return False
      End If
      Return True
   End Function

   Private Sub CargarDatosCliente(ByVal dr As DataGridViewRow)
      Me.bscCliente.Text = dr.Cells("NombreCliente").Value.ToString()
      Me.bscCodigoCliente.Text = dr.Cells("CodigoCliente").Value.ToString()
      Me.bscCodigoCliente.Tag = dr.Cells("IdCliente").Value.ToString()
      Me.txtDireccion.Text = dr.Cells("Direccion").Value.ToString()
      'Me.txtCP.Text = dr.Cells("IdLocalidad").Value.ToString()
      Me.txtLocalidad.Text = dr.Cells("NombreLocalidad").Value.ToString()
      Me.txtTelefono.Text = dr.Cells("Telefono").Value.ToString()
      Dim oFichas As Eniac.Reglas.Fichas = New Eniac.Reglas.Fichas()
      Me.bscCliente.Enabled = False
      Me.bscCodigoCliente.Enabled = False
      Me.btnConsultar.Focus()
   End Sub

#End Region

End Class