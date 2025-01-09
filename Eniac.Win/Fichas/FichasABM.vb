Option Explicit On
Option Strict On

Imports actual = Eniac.Entidades.Usuario.Actual
Imports Eniac.Win
Imports Eniac.Reglas
Imports Eniac.Entidades

Public Class FichasABM

#Region "Constantes"

   Private Const funcionActual As String = "FichasABM"
   Private Const funcionDevPago As String = "DevolverPago"
#End Region

#Region "Campos"

   Private oFichaPagos As Generic.List(Of Eniac.Entidades.FichaPago)
   Private oFichaProductos As System.Collections.Generic.List(Of Eniac.Entidades.FichaProducto)
   Private _estado As Estados
   Private _puedeDevolverPago As Boolean
   Private _publicos As Eniac.Win.Publicos
   Private _fichaAnulada As Boolean = False
   Private _primerSaldo As Decimal = 0
   Private _comentario As String = String.Empty

#End Region

#Region "Enumeraciones"

   Private Enum Estados
      Insercion
      Modificacion
   End Enum

#End Region

#Region "Overrides"

   Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)
      MyBase.OnLoad(e)

      Try

         Me._publicos = New Eniac.Win.Publicos()
         Dim oUsuario As Eniac.Reglas.Usuarios = New Eniac.Reglas.Usuarios()
         Me._puedeDevolverPago = oUsuario.TienePermisos(Eniac.Ayudantes.Common.usuario, Eniac.Entidades.Usuario.Actual.Sucursal.Id, funcionDevPago)

         Me.CargaComboFormasPago()

         Me._publicos.CargaComboEmpleados(Me.cmbCobrador, Eniac.Entidades.Publicos.TiposEmpleados.COMPRADOR)
         Me._publicos.CargaComboEmpleados(Me.cmbVendedor, Eniac.Entidades.Publicos.TiposEmpleados.VENDEDOR)

         Dim blnMiraUsuario As Boolean = True, blnMiraPC As Boolean = True, blnCajasModificables As Boolean = True
         Me._publicos.CargaComboCajas(Me.cmbCajas, Eniac.Entidades.Usuario.Actual.Sucursal.Id, blnMiraUsuario, blnMiraPC, blnCajasModificables)

         'Seguridad de la Edición de Clientes (enlace a través de la etiqueta "Más info...")
         Me.llbCliente.Visible = oUsuario.TienePermisos(Eniac.Ayudantes.Common.usuario, Eniac.Entidades.Usuario.Actual.Sucursal.Id, "Clientes-PuedeUsarMasInfo")

         Me.SeteaFichaProducto()
         Me.SeteaFichaPagos()

         Me.Nuevo()

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

#End Region

#Region "Eventos"

   Private Sub FichasABM_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyUp
      Select Case e.KeyCode
         Case Keys.F5
            Me.tsbNuevo.PerformClick()
            Me.tsbNuevo_Click(Me.tsbNuevo, New EventArgs())
         Case Keys.D
            If e.Alt Then
               Me.bscDireccion.Focus()
            End If
      End Select
   End Sub

   Private Sub txtComentario_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtComentario.GotFocus
      If Me._estado = Estados.Modificacion Then
         Me._comentario = Me.txtComentario.Text
      End If
   End Sub

   Private Sub txtComentario_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtComentario.LostFocus
      If Me._estado = Estados.Modificacion Then
         If Me._comentario.Trim() <> Me.txtComentario.Text.Trim() Then
            If MessageBox.Show("Modifica el comentario?", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
               Dim oReg As Eniac.Reglas.Fichas = New Eniac.Reglas.Fichas()

               Dim ficha As Eniac.Entidades.Ficha = New Eniac.Entidades.Ficha(actual.Sucursal.Id, actual.Nombre, actual.Pwd)
               With ficha
                  .IdCliente = Long.Parse(bscCodigoCliente.Tag.ToString())
                  .FechaOperacion = Me.dtpFecha.Value
                  .NroOperacion = Integer.Parse(Me.txtNroOperacion.Text)
                  .Comentario = Me.txtComentario.Text
               End With
               oReg.ActualizarComentario(ficha)
            Else
               Me.txtComentario.Text = Me._comentario
            End If
         End If
      End If
   End Sub

   Private Sub dtgProductos_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dtgProductos.CellDoubleClick
      Try
         Dim res As DialogResult
         Select Case Me._estado
            Case Estados.Modificacion
               If Me.dtpEntrego.Checked Then
                  res = MessageBox.Show("Desea modificar la fecha de entrega al " & Me.dtpEntrego.Value.ToString("dd/MM/yyyy") & " ?", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question)
               Else
                  res = MessageBox.Show("Desea anular la fecha de entrega?", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question)
               End If
               If res = Windows.Forms.DialogResult.Yes Then
                  If Me.dtpEntrego.Checked Then
                     Me.dtgProductos.Rows(e.RowIndex).Cells("FechaEntrega").Value = Me.dtpEntrego.Value
                  Else
                     Me.dtgProductos.Rows(e.RowIndex).Cells("FechaEntrega").Value = Nothing
                  End If
                  Dim oFichaProd As Eniac.Reglas.FichasProductos = New Eniac.Reglas.FichasProductos()
                  oFichaProd.ActualizarFechaEntrega(Me.oFichaProductos(e.RowIndex))
               End If
            Case Estados.Insercion
               'limpia los campos
               Me.LimpiarCamposProductos()
               'carga los textbox con los valores de la grilla
               Me.CargarProductoCompleto(Me.dtgProductos.Rows(e.RowIndex))
               'elimina el item de la grilla
               Me.EliminarProducto()
               'hace foco en la cantidad
               Me.txtCantidad.Focus()
         End Select

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub CargarProductoCompleto(ByVal dr As DataGridViewRow)
      Dim oProductos As Productos = New Productos()
      Dim oProv As Proveedores = New Proveedores()

      Me.bscProducto.Text = dr.Cells("ProductoDesc").Value.ToString()
      Me.bscProducto.Datos = oProductos.GetPorCodigo(dr.Cells("IdProducto").Value.ToString().Trim(), actual.Sucursal.Id, Publicos.ListaPreciosPredeterminada, "VENTAS")
      Me.bscProducto.PresionarBoton()

      If dr.Cells("FechaEntrega").Value IsNot Nothing Then
         Me.dtpEntrego.Value = Date.Parse(dr.Cells("FechaEntrega").Value.ToString())
      End If

      Me.txtPrecio.Text = Decimal.Round(Decimal.Parse(dr.Cells("Precio").Value.ToString()), 2).ToString("#,##0.00")
      ''Me.txtStock.Text = dr.Cells("Stock").Value.ToString()
      Me.txtCantidad.Text = dr.Cells("Cantidad").Value.ToString()
      Me.txtGarantia.Text = dr.Cells("Garantia").Value.ToString()

      If DirectCast(dr.Cells("NombreProveedor").Value, Proveedor).IdProveedor <> 0 Then
         Me.bscProveedor.Text = DirectCast(dr.Cells("NombreProveedor").Value, Proveedor).NombreProveedor
         Me.bscProveedor.Datos = oProv.GetFiltradoPorCodigo(DirectCast(dr.Cells("NombreProveedor").Value, Proveedor).CodigoProveedor, False)
         Me.bscProveedor.PresionarBoton()
      End If

      Me.txtTotalProducto.Text = dr.Cells("Importe").Value.ToString()
   End Sub

   Private Sub tsbAnular_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbAnular.Click
      Try
         If Me.ValidarAnulacionFicha() Then
            If MessageBox.Show("Esta seguro de anular esta ficha?", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.Yes Then
               Me.Cursor = Cursors.WaitCursor
               Dim oFicha As Eniac.Reglas.Fichas = New Eniac.Reglas.Fichas()
               Dim oFic As Eniac.Entidades.Ficha = New Eniac.Entidades.Ficha(actual.Sucursal.Id, actual.Nombre, actual.Pwd)
               With oFic
                  .IdCliente = Long.Parse(Me.bscCodigoCliente.Tag.ToString())
                  .NroOperacion = Integer.Parse(Me.txtNroOperacion.Text)
                  .FechaOperacion = Me.dtpFecha.Value
                  .IdEstado = "INACTIVO"
               End With
               oFicha.ActualizarEstado(oFic)
               MessageBox.Show("La ficha fue anulada con exito!!", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
               Me.Nuevo()
            End If
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      Finally
         Me.Cursor = Cursors.Default
      End Try
   End Sub

   Private Sub tsbRevisado_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbRevisado.Click
      Dim oFicha As Eniac.Reglas.Fichas = New Eniac.Reglas.Fichas()
      Dim oFic As Eniac.Entidades.Ficha = New Eniac.Entidades.Ficha(actual.Sucursal.Id, actual.Nombre, actual.Pwd)
      With oFic
         .NroOperacion = Integer.Parse(Me.txtNroOperacion.Text)
         .IdCliente = Long.Parse(Me.bscCodigoCliente.Tag.ToString())
      End With
      oFicha.ActualizarRevisar(oFic)
      MessageBox.Show("Ficha revisada ok!!!", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      Me.tsbRevisado.Visible = False
   End Sub

   Private Sub tsbImpFichaCliente_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbImpFichaCliente.Click
      Me.ImprimirFichaCliente()
   End Sub

   Private Sub tsbNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbNuevo.Click
      Me.Nuevo()
   End Sub

   Private Sub txtNroOperacion_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtNroOperacion.Leave

   End Sub

   Private Sub tsbSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbSalir.Click
      Me.Close()
   End Sub

   Private Sub txtAnticipo_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtAnticipo.Leave
      If Me.txtAnticipo.Text.Trim().Length = 0 Then
         Me.txtAnticipo.Text = "0.00"
      End If
      Me.CalcularSubTotal()
   End Sub

   Private Sub txtIntereses_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtIntereses.Leave
      If Me.txtIntereses.Text.Trim().Length = 0 Then
         Me.txtIntereses.Text = "0.00"
      End If
      Me.CalcularImporteCuota()
      Me.CalcularTotal()
      Me.CargarGrillaCuotas()
   End Sub

   Private Sub tbpPagos_MouseClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs)
      Me.txtBruto.Focus()
   End Sub

   Private Sub txtAnticipo_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtAnticipo.LostFocus
      If Me.txtAnticipo.Text.Length = 0 Then Me.txtAnticipo.Text = "0"
      If Me.txtBruto.Text.Length = 0 Then Me.txtBruto.Text = "0"
      If Decimal.Parse(Me.txtBruto.Text) <> 0 Then
         Me.txtSubTotal.Text = (Decimal.Parse(Me.txtBruto.Text) - Decimal.Parse(Me.txtAnticipo.Text)).ToString()
      End If
   End Sub

   Private Sub bscCodigoCliente_BuscadorClick() Handles bscCodigoCliente.BuscadorClick
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

   Private Sub bscCodigoCliente_BuscadorSeleccion(ByVal sender As Object, ByVal e As Controles.BuscadorEventArgs) Handles bscCodigoCliente.BuscadorSeleccion
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
         Me.bscCliente.Datos = oClientes.GetFiltradoPorNombre(Me.bscCliente.Text.Trim(), False)

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

   Private Sub llbCliente_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles llbCliente.LinkClicked

      Try
         If Me.bscCodigoCliente.Selecciono Or Me.bscCliente.Selecciono Then

            Dim clie As Eniac.Entidades.Cliente = New Eniac.Entidades.Cliente

            clie = New Eniac.Reglas.Clientes().GetUno(Long.Parse(Me.bscCodigoCliente.Tag.ToString()))
            clie.Usuario = actual.Nombre

            Dim PantCliente As ClientesDetalle = New ClientesDetalle(clie)
            PantCliente.StateForm = Eniac.Win.StateForm.Actualizar
            PantCliente.CierraAutomaticamente = True
            PantCliente.ShowDialog()
            'If PantCliente.ShowDialog() = Windows.Forms.DialogResult.OK Then
            '   Me.bscCodigoCliente.Text = PantCliente.txtIDXXXX.Text
            '   Me.bscCodigoCliente.PresionarBoton()
            'End If
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try

   End Sub

   Private Sub bscDireccion_BuscadorClick() Handles bscDireccion.BuscadorClick

      Try

         Me._publicos.PreparaGrillaClientes(Me.bscDireccion)
         Dim oClientes As Clientes = New Clientes

         Dim bus As Eniac.Entidades.Buscar = New Eniac.Entidades.Buscar
         bus.Columna = Eniac.Entidades.Cliente.Columnas.Direccion.ToString()
         bus.Valor = Me.bscDireccion.Text

         'Me.bscDireccion.Datos = oClientes.Buscar(bus).Tables(0)
         Me.bscDireccion.Datos = oClientes.Buscar(bus)

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try

   End Sub

   Private Sub bscDireccion_BuscadorSeleccion(ByVal sender As Object, ByVal e As Controles.BuscadorEventArgs) Handles bscDireccion.BuscadorSeleccion
      Try
         If Not e.FilaDevuelta Is Nothing Then
            Me.Nuevo()
            Me.CargarDatosCliente(e.FilaDevuelta)
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub btnInsertar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnInsertar.Click
      If Not Me.bscProducto.FilaDevuelta Is Nothing And Me.txtCantidad.Text <> "" Then
         If Me.ValidarInsertaProducto() Then
            Me.InsertarProducto()
         End If
      End If
   End Sub
   Private Sub InsertarProducto()
      Dim oFichaProd As Eniac.Entidades.FichaProducto = New Eniac.Entidades.FichaProducto(actual.Sucursal.Id, actual.Nombre, actual.Pwd)
      With oFichaProd
         .IdProducto = Me.bscProducto.FilaDevuelta.Cells("IdProducto").Value.ToString().Trim()
         .ProductoDesc = Me.bscProducto.FilaDevuelta.Cells("NombreProducto").Value.ToString()
         .Precio = Convert.ToDecimal(Me.txtPrecio.Text.Trim())
         .Cantidad = Integer.Parse(Me.txtCantidad.Text)
         .IdCliente = Long.Parse(Me.bscCodigoCliente.Tag.ToString())
         .NroOperacion = Integer.Parse(Me.txtNroOperacion.Text)
         If Me.dtpEntrego.Checked Then
            .FechaEntrega = Me.dtpEntrego.Value
         Else
            .FechaEntrega = Nothing
         End If
         .Garantia = Integer.Parse(Me.txtGarantia.Text)
         If Not Me.bscProveedor.FilaDevuelta Is Nothing Then
            .Proveedor = New Proveedores().GetUno(Long.Parse(Me.bscProveedor.FilaDevuelta.Cells("IdProveedor").Value.ToString()))
         End If
      End With
      Me.oFichaProductos.Add(oFichaProd)

      Me.dtgProductos.DataSource = oFichaProductos.ToArray()
      Me.dtgProductos.FirstDisplayedScrollingRowIndex = Me.dtgProductos.Rows.Count - 1

      Me.CalcularTotalProducto()
      Me.LimpiarCamposProductos()
      Me.CalcularBruto()
      Me.Refresh()
      Me.bscProducto.Focus()
   End Sub
   Private Sub btnEliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEliminar.Click
      Try
         Me.EliminarProducto()
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub
   Private Sub EliminarProducto()
      If Me.dtgProductos.SelectedRows.Count > 0 Then
         Me.oFichaProductos.RemoveAt(Me.dtgProductos.SelectedRows(0).Index)
      End If
      Me.dtgProductos.DataSource = Me.oFichaProductos.ToArray()
      Me.CalcularBruto()
   End Sub
   Private Sub bscProducto_BuscadorClick() Handles bscProducto.BuscadorClick
      Try
         Me._publicos.PreparaGrillaProductos2(Me.bscProducto)
         Dim oProductos As Productos = New Productos
         Me.bscProducto.Datos = oProductos.GetPorNombre(Me.bscProducto.Text.Trim(), actual.Sucursal.Id, Publicos.ListaPreciosPredeterminada, "VENTAS")
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub
   Private Sub bscProducto_BuscadorSeleccion(ByVal sender As Object, ByVal e As Controles.BuscadorEventArgs) Handles bscProducto.BuscadorSeleccion
      Try
         If Not e.FilaDevuelta Is Nothing Then
            Me.bscProducto.Text = e.FilaDevuelta.Cells("NombreProducto").Value.ToString()
            Me.txtPrecio.Text = Decimal.Round(Decimal.Parse(e.FilaDevuelta.Cells("PrecioVenta").Value.ToString()), 2).ToString("#,##0.00")
            Me.txtStock.Text = e.FilaDevuelta.Cells("Stock").Value.ToString()
            Me.txtCantidad.Text = "1"
            Me.txtGarantia.Text = e.FilaDevuelta.Cells("MesesGarantia").Value.ToString()
            Me.txtCantidad.Focus()
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub
   Private Sub txtPrecio_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtPrecio.LostFocus
      If Me.txtPrecio.Text.Trim().Length = 0 Then
         Me.txtPrecio.Text = "0"
      End If
      Me.CalcularTotalProducto()
   End Sub
   Private Sub txtCantidad_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtCantidad.LostFocus
      Me.CalcularTotalProducto()
   End Sub
   Private Sub llbOperacion_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles llbOperacion.LinkClicked
      Me._primerSaldo = 0
      Me.VerOperaciones(True)
   End Sub
   Private Sub tsbPago_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbPago.Click
      Dim oPagos As Pagos
      If Me.cmbCobrador.SelectedIndex <> -1 Then
         oPagos = New Pagos(Integer.Parse(Me.cmbCajas.SelectedValue.ToString()), Pagos.TipoPago.Pago, Integer.Parse(Me.txtNroOperacion.Text), Long.Parse(Me.bscCodigoCliente.Tag.ToString()), Me.cmbCobrador.SelectedValue.ToString(), Me._primerSaldo)
      Else
         oPagos = New Pagos(Integer.Parse(Me.cmbCajas.SelectedValue.ToString()), Pagos.TipoPago.Pago, Integer.Parse(Me.txtNroOperacion.Text), Long.Parse(Me.bscCodigoCliente.Tag.ToString()), Nothing, Me._primerSaldo)
      End If

      oPagos.ShowDialog()
      Me.RecuperarDatosDeFicha()
   End Sub
   Private Sub btnGrabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGrabar.Click
      Try
         Me.GrabarFicha()
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub
   Private Sub txtBruto_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtBruto.LostFocus
      If Me.txtBruto.Text.Trim().Length = 0 Then
         Me.txtBruto.Text = "0"
      End If
   End Sub
   Private Sub tbcFichas_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tbcFichas.Click
      If Me.tbcFichas.SelectedTab Is Me.tbpPagos Then
         Me.txtAnticipo.Focus()
      End If
   End Sub
   Private Sub txtCuotas_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtCuotas.Leave
      TryCatched(
      Sub()
         If String.IsNullOrEmpty(txtCuotas.Text.Trim()) Then
            txtCuotas.Text = "1"
         End If
         CalcularIntereses()
         CalcularImporteCuota()
         CalcularTotal()
         CargarGrillaCuotas()
      End Sub)
   End Sub
   Private Sub tsbImprimirFicha_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbImprimirFicha.Click
      Me.ImprimirFicha()
   End Sub
   Private Sub tsbDevolverPago_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbDevolverPago.Click
      Dim oPagos As Pagos
      If Me.cmbCobrador.SelectedIndex <> -1 Then
         oPagos = New Pagos(Integer.Parse(Me.cmbCajas.SelectedValue.ToString()), Pagos.TipoPago.Devolucion, Integer.Parse(Me.txtNroOperacion.Text), Long.Parse(Me.bscCodigoCliente.Tag.ToString()), Me.cmbCobrador.SelectedValue.ToString(), 0)
      Else
         oPagos = New Pagos(Integer.Parse(Me.cmbCajas.SelectedValue.ToString()), Pagos.TipoPago.Devolucion, Integer.Parse(Me.txtNroOperacion.Text), Long.Parse(Me.bscCodigoCliente.Tag.ToString()), Nothing, 0)
      End If
      oPagos.ShowDialog()
      Me.RecuperarDatosDeFicha()
   End Sub
   Private Sub bscProveedor_BuscadorClick() Handles bscProveedor.BuscadorClick
      Try
         Dim oProveedores As Proveedores = New Proveedores()
         Me._publicos.PreparaGrillaProveedores(Me.bscProveedor)
         Me.bscProveedor.Datos = oProveedores.GetFiltradoPorNombre(Me.bscProveedor.Text.Trim())
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub
   Private Sub bscProveedor_BuscadorSeleccion(ByVal sender As Object, ByVal e As Controles.BuscadorEventArgs) Handles bscProveedor.BuscadorSeleccion
      Try
         If Not e.FilaDevuelta Is Nothing Then
            Me.bscProveedor.Text = e.FilaDevuelta.Cells("NombreProveedor").Value.ToString()
            Me.btnInsertar.Focus()
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub txtCantidad_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtCantidad.KeyDown
      If e.KeyCode = Keys.Enter Then
         Me.txtPrecio.Focus()
      End If
   End Sub

   Private Sub txtPrecio_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtPrecio.KeyDown
      If e.KeyCode = Keys.Enter Then
         Me.dtpEntrego.Focus()
      End If
   End Sub

   Private Sub dtpEntrego_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dtpEntrego.KeyDown
      If e.KeyCode = Keys.Enter Then
         Me.txtGarantia.Focus()
      End If
   End Sub

   Private Sub txtGarantia_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtGarantia.KeyDown
      If e.KeyCode = Keys.Enter Then
         Me.bscProveedor.Focus()
      End If
   End Sub

#End Region

#Region "Metodos"

   Private Function ValidarAnulacionFicha() As Boolean
      If Me.bscCodigoCliente.Text.Length = 0 Then
         MessageBox.Show("Debe cargar un Nro. de documento.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
         Me.bscCodigoCliente.Focus()
         Return False
      End If
      Return True
   End Function

   Private Function ValidarFicha() As Boolean
      If Me.bscCodigoCliente.Text.Trim().Length = 0 Then
         MessageBox.Show("Falta cargar el Nro. de Documento.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
         Me.bscCodigoCliente.Focus()
         Return False
      End If
      If Me.bscCliente.Text.Trim().Length = 0 Then
         MessageBox.Show("Falta cargar el Nombre del cliente.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
         Me.bscCliente.Focus()
         Return False
      End If
      'If Me.dtProductos.Rows.Count = 0 Then
      If Me.oFichaProductos.Count = 0 Then
         MessageBox.Show("No se cargo ningún producto.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
         Me.bscProducto.Focus()
         Return False
      End If
      If Me.txtTotal.Text.Length = 0 Then
         MessageBox.Show("No se calcularon los precios de la operación.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
         Me.bscProducto.Focus()
         Return False
      End If
      If Me.cmbCobrador.SelectedIndex = -1 Then
         MessageBox.Show("Falta cargar el cobrador.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
         Me.cmbCobrador.Focus()
         Return False
      End If
      If Me.cmbVendedor.SelectedIndex = -1 Then
         MessageBox.Show("Falta cargar el vendedor.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
         Me.cmbVendedor.Focus()
         Return False
      End If

      Return True
   End Function

   Private Sub GrabarFicha()
      If Me.ValidarFicha() Then
         Dim oFichas As Eniac.Reglas.Fichas = New Eniac.Reglas.Fichas()
         Dim oEnt As Eniac.Entidades.Ficha = New Eniac.Entidades.Ficha(actual.Sucursal.Id, actual.Nombre, actual.Pwd)
         With oEnt
            .EsNueva = True
            .IdCliente = Long.Parse(Me.bscCodigoCliente.Tag.ToString())
            .NroOperacion = Integer.Parse(Me.txtNroOperacion.Text)
            .FechaOperacion = Me.dtpFecha.Value
            .MontoTotalBruto = Decimal.Parse(Me.txtBruto.Text)
            .Anticipo = Decimal.Parse(Me.txtAnticipo.Text)
            .Cuotas = Integer.Parse(Me.txtCuotas.Text)
            .IdFormasPago = Integer.Parse(Me.cmbFormaPago.SelectedValue.ToString())
            .Interes = Decimal.Parse(Me.txtIntereses.Text)
            .TotalNeto = Decimal.Parse(Me.txtTotal.Text)
            .Saldo = Decimal.Parse(Me.txtTotalCuotas.Text)
            If Me.cmbCobrador.SelectedIndex <> -1 Then
               .IdCobrador = DirectCast(Me.cmbCobrador.SelectedItem, Empleado).IdEmpleado
            End If
            .Comentario = Me.txtComentario.Text
            .IdEstado = "ACTIVO"
            .NroFactura = 0
            .Pagos = Me.oFichaPagos
            .Productos = Me.oFichaProductos
            If Me.cmbVendedor.SelectedIndex <> -1 Then
               .IdVendedor = DirectCast(Me.cmbVendedor.SelectedItem, Empleado).IdEmpleado
            End If
            .IdCaja = 0
            If Me.cmbCajas.SelectedIndex <> -1 Then
               .IdCaja = Integer.Parse(Me.cmbCajas.SelectedValue.ToString())
            End If
            .Usuario = Ayudantes.Common.usuario

         End With
         oFichas.Insertar(oEnt)

         MessageBox.Show("La ficha Nro. " & Me.txtNroOperacion.Text & Convert.ToChar(Keys.Enter) & "de " & Me.bscCliente.Text & Convert.ToChar(Keys.Enter) & " fue grabada con éxito", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)

         If MessageBox.Show("¿Quiere imprimir la ficha y el anticipo?", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
            Me.ImprimirFicha()
         End If

         If MessageBox.Show("¿Quiere imprimir la ficha para el cliente?", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
            Me.ImprimirFichaCliente()
         End If

         Me.Nuevo()
      End If
   End Sub

   Private Sub CargaComboFormasPago()
      Dim oFormasPago As Eniac.Reglas.FichasFormasPago = New Eniac.Reglas.FichasFormasPago()

      With Me.cmbFormaPago
         .DisplayMember = "DescripcionFormasPago"
         .ValueMember = "IdFormasPago"
         .DataSource = oFormasPago.GetAll()
         .SelectedValue = 1
      End With
   End Sub

   Private Sub SeteaFichaProducto()
      Me.oFichaProductos = New System.Collections.Generic.List(Of Eniac.Entidades.FichaProducto)
   End Sub

   Private Sub SeteaFichaPagos()
      Me.oFichaPagos = New System.Collections.Generic.List(Of Eniac.Entidades.FichaPago)
   End Sub

   ''' <summary>
   ''' Calcula el total del producto a vender
   ''' </summary>
   ''' <remarks></remarks>
   Private Sub CalcularTotalProducto()
      Me.txtTotalProducto.Text = (Convert.ToDecimal(Me.txtPrecio.Text) * Convert.ToDecimal(Me.txtCantidad.Text)).ToString()
   End Sub

   Private Sub LimpiarCamposProductos()
      Me.bscProducto.Text = ""
      Me.bscProducto.FilaDevuelta = Nothing
      Me.bscProveedor.Text = String.Empty
      Me.bscProveedor.FilaDevuelta = Nothing
      Me.txtPrecio.Text = "0.00"
      Me.txtStock.Text = "0"
      Me.txtCantidad.Text = "0"
      Me.txtTotalProducto.Text = "0.00"
      Me.dtpEntrego.Value = DateTime.Now
      Me.txtGarantia.Text = "0"
   End Sub

   Private Sub CalcularBruto()
      Dim bruto As Decimal = 0
      For i As Integer = 0 To Me.oFichaProductos.Count - 1
         bruto += Convert.ToDecimal(Me.oFichaProductos(i).Importe)
      Next
      'For Each dr As DataRow In Me.dtProductos.Rows
      '    bruto += Convert.ToDecimal(dr("Importe"))
      'Next
      Me.txtBruto.Text = bruto.ToString("#0.00")
   End Sub

   Private Sub CalcularIntereses()

      Dim oInteres As Eniac.Reglas.InteresesDias = New Eniac.Reglas.InteresesDias()
      If Me.txtCuotas.Text.Length = 0 Then Me.txtCuotas.Text = "1"
      Dim interes As Decimal = 0
      Dim cliente As Entidades.Cliente = New Reglas.Clientes().GetUnoPorCodigo(Long.Parse(Me.bscCodigoCliente.Text.ToString()))
      Dim categoria As Entidades.Categoria = New Reglas.Categorias().GetUno(cliente.IdCategoria)

      If Not String.IsNullOrEmpty(Me.txtCuotas.Text) Then

         interes = Decimal.Parse(Me.txtSubTotal.Text) * oInteres.GetInteres(Integer.Parse(Me.cmbFormaPago.SelectedValue.ToString()), Integer.Parse(Me.txtCuotas.Text), categoria.IdInteres) / 100

         Me.txtIntereses.Text = interes.ToString("#0.00")
      Else
         Me.txtIntereses.Text = "0.00"
      End If

   End Sub

   Private Sub CalcularImporteCuota()
      Dim cuota As Decimal = 0
      Dim cantcuota As Decimal = 1
      If Me.txtCuotas.Text.Length <> 0 Then
         cantcuota = Decimal.Parse(Me.txtCuotas.Text)
      End If
      cuota = Decimal.Parse(Me.txtSubTotal.Text) + Decimal.Parse(Me.txtIntereses.Text)
      cuota = cuota / cantcuota
      Me.txtImpCuota.Text = cuota.ToString("#0.00")
      Me.txtTotalCuotas.Text = (cuota * cantcuota).ToString("#0.00")
   End Sub

   Private Sub CalcularTotal()
      Dim total As Decimal = 0
      If Not String.IsNullOrEmpty(Me.txtCuotas.Text) Then
         total = (Decimal.Parse(Me.txtImpCuota.Text) * Decimal.Parse(Me.txtCuotas.Text)) + Decimal.Parse(Me.txtAnticipo.Text)
      Else
         total = Decimal.Parse(Me.txtImpCuota.Text) + Decimal.Parse(Me.txtAnticipo.Text)
      End If
      Me.txtTotal.Text = total.ToString("#0.00")
   End Sub

   Private Sub CalcularSubTotal()
      If Me.txtBruto.Text.Length = 0 Then Me.txtBruto.Text = "0"
      Me.txtSubTotal.Text = (Decimal.Parse(Me.txtBruto.Text) - Decimal.Parse(Me.txtAnticipo.Text)).ToString("#,##0.00")
   End Sub

   Private Sub CargarGrillaCuotas()
      Me.oFichaPagos.Clear()
      If Not String.IsNullOrEmpty(Me.txtCuotas.Text) Then
         Dim DiasCC As Integer = New Reglas.FichasFormasPago().GetUna(Integer.Parse(Me.cmbFormaPago.SelectedValue.ToString())).Dias
         For i As Integer = 0 To Integer.Parse(Me.txtCuotas.Text) - 1
            Dim pag As Eniac.Entidades.FichaPago = New Eniac.Entidades.FichaPago(actual.Sucursal.Id, actual.Nombre, actual.Pwd)
            'pag.FechaVencimiento = Me.dtpFecha.Value.AddDays((i + 1) * Double.Parse(Me.cmbFormaPago.SelectedItem(2).ToString()))
            pag.FechaVencimiento = Me.dtpFecha.Value.AddDays((i + 1) * DiasCC)
            pag.Importe = Decimal.Parse(Me.txtImpCuota.Text)
            pag.Saldo = Decimal.Parse(Me.txtImpCuota.Text)
            pag.IdCliente = Long.Parse(Me.bscCodigoCliente.Tag.ToString())
            pag.NroOperacion = Integer.Parse(Me.txtNroOperacion.Text)
            pag.NroCuota = i + 1
            Me.oFichaPagos.Add(pag)
         Next
      Else
         Dim pag As Eniac.Entidades.FichaPago = New Eniac.Entidades.FichaPago(actual.Sucursal.Id, actual.Nombre, actual.Pwd)
         pag.FechaVencimiento = Me.dtpFecha.Value
         pag.Importe = Decimal.Parse(Me.txtImpCuota.Text)
         pag.Saldo = Decimal.Parse(Me.txtImpCuota.Text)
         pag.IdCliente = Long.Parse(Me.bscCodigoCliente.Tag.ToString())
         If Me.txtNroOperacion.Text.Length > 0 Then
            pag.NroOperacion = Integer.Parse(Me.txtNroOperacion.Text)
         End If
         Me.oFichaPagos.Add(pag)
      End If
      Me.dgvCuotas.DataSource = Me.oFichaPagos.ToArray()
   End Sub

   Private Sub CargarDatosCliente(ByVal dr As DataGridViewRow)
      Me.bscCliente.Text = dr.Cells("NombreCliente").Value.ToString.Trim()
      Me.bscCodigoCliente.Text = dr.Cells("CodigoCliente").Value.ToString.Trim()
      Me.bscCodigoCliente.Tag = dr.Cells("IdCliente").Value.ToString.Trim()
      Me.bscDireccion.Text = dr.Cells("Direccion").Value.ToString.Trim()
      'Me.bscDireccion.Enabled = True
      Me.txtCP.Text = dr.Cells("IdLocalidad").Value.ToString()
      Me.txtLocalidad.Text = dr.Cells("NombreLocalidad").Value.ToString()
      Me.txtTelefono.Text = dr.Cells("Telefono").Value.ToString() & " " & dr.Cells("Celular").Value.ToString()
      Dim oFichas As Eniac.Reglas.Fichas = New Eniac.Reglas.Fichas()
      Me.txtNroOperacion.Text = oFichas.GetProximoNroOperacionDelCliente(Long.Parse(dr.Cells("IdCliente").Value.ToString()), actual.Sucursal.Id).ToString()
      Me.txtNroOperacion.ReadOnly = False
      Me.VerOperaciones(False)
      Me.tbcFichas.Enabled = True
      Me.bscCliente.Enabled = False
      Me.bscCodigoCliente.Enabled = False
      Me.txtComentario.Focus()
   End Sub

   Private Sub VerOperaciones(ByVal todas As Boolean)
      Dim oOperPend As FichasPendientes = New FichasPendientes(Long.Parse(Me.bscCodigoCliente.Tag.ToString()), todas)
      If oOperPend.HayRegistro Then
         If todas Then
            oOperPend.Text += " de " & Me.bscCliente.Text
         Else
            oOperPend.Text += " pendientes de " & Me.bscCliente.Text
         End If
         oOperPend.ShowDialog()
         If oOperPend.Selecciono Then
            Me.txtNroOperacion.Text = oOperPend.NroOperacion
            Me.txtNroOperacion.ReadOnly = True
            'Alguna PC paso el control de la fecha maxima y tiene fecha larga asi que le actualizo el maximo.
            Me.dtpFecha.MaxDate = oOperPend.FechaOperacion
            Me.dtpFecha.Value = oOperPend.FechaOperacion
            Me.PrepararFichaParaPago()
         End If
      End If
   End Sub

   Private Sub PrepararFichaParaPago()
      Me.RecuperarDatosDeFicha()
      Me.txtComentario.Enabled = True
      Me.cmbCobrador.Enabled = False
      Me.cmbVendedor.Enabled = False
      Me.tbcFichas.SelectedTab = Me.tbpPagos
      Me.btnInsertar.Enabled = False
      Me.btnEliminar.Enabled = False
      Me.btnGrabar.Enabled = False
      Me.bscCliente.Enabled = False
      Me.bscCodigoCliente.Enabled = False
      Me.dtpFecha.Enabled = False
      Me.grbTotales.Enabled = False
   End Sub

   Private Sub RecuperarDatosDeFicha()
      Dim oFichas As Eniac.Reglas.Fichas = New Eniac.Reglas.Fichas()
      Dim oFicha As Eniac.Entidades.Ficha = oFichas.GetUna(Long.Parse(Me.bscCodigoCliente.Tag.ToString()), Integer.Parse(Me.txtNroOperacion.Text), actual.Sucursal.Id)
      With oFicha
         Me._estado = Estados.Modificacion
         Me._fichaAnulada = (.IdEstado = "INACTIVO")
         Me.txtBruto.Text = .MontoTotalBruto.ToString("0.00")
         Me.txtAnticipo.Text = .Anticipo.ToString("0.00")
         Me.txtComentario.Text = .Comentario
         Me.txtSubTotal.Text = (.MontoTotalBruto - .Anticipo).ToString("0.00")
         Me.txtCuotas.Text = .Cuotas.ToString()
         Me.cmbFormaPago.SelectedValue = .IdFormasPago
         Me.txtIntereses.Text = .Interes.ToString("0.00")
         Me.txtTotal.Text = .TotalNeto.ToString("0.00")
         oFichaProductos = .Productos
         Me.dtgProductos.DataSource = oFichaProductos
         If .PagosDetalle.Count <> 0 Then
            Me.dgvPagos.Visible = True
            Me.dgvPagos.DataSource = .PagosDetalle
         Else
            Me.dgvPagos.Visible = False
         End If
         Me.CalcularImporteCuota()
         Me.oFichaPagos = .Pagos
         Me.dgvCuotas.DataSource = Me.oFichaPagos.ToArray()
         For i As Integer = 0 To .Pagos.Count - 1
            If .Pagos(i).Saldo <> 0 Then
               Me._primerSaldo = .Pagos(i).Saldo
               Me.dgvCuotas.FirstDisplayedScrollingRowIndex = i
               Me.dgvCuotas.Focus()
               Exit For
            End If
         Next
         Me.cmbCobrador.SelectedValue = .IdCobrador
         Me.cmbVendedor.SelectedValue = .IdVendedor
         Me.txtSaldo.Text = .Saldo.ToString("#,##0.00")
         Me.tsbAnular.Enabled = (Not Me._fichaAnulada) And (Double.Parse(Me.txtSaldo.Text) = Double.Parse(Me.txtTotalCuotas.Text))
         Me.tsbImprimirFicha.Enabled = Not Me._fichaAnulada
         Me.tsbImpFichaCliente.Enabled = Not Me._fichaAnulada
         Me.tsbPago.Enabled = Not Me._fichaAnulada
         If Me._fichaAnulada Then
            Me.tsbDevolverPago.Enabled = False
            Me.Text = "Fichas - ANULADA !!!!!!!!!!!!!!"
         Else
            Me.tsbDevolverPago.Enabled = Me._puedeDevolverPago
            Me.Text = "Fichas"
         End If

         .IdCliente = Long.Parse(Me.bscCodigoCliente.Tag.ToString())

         Me.tsbRevisado.Visible = oFichas.HayQueRevisar(oFicha)

         'si esta operacion tiene cartas emitidas se van a mostrar
         Dim dtCa As DataTable = oFichas.GetCartasEmitidas(oFicha)
         If dtCa.Rows.Count > 0 Then
            If Me.tbcFichas.TabPages.IndexOf(Me.tbpCartasEmitidas) = -1 Then
               Me.dgvCartasEmitidas.DataSource = dtCa
               Me.tbcFichas.TabPages.Add(Me.tbpCartasEmitidas)
            End If
         Else
            If Me.tbcFichas.TabPages.IndexOf(Me.tbpCartasEmitidas) > -1 Then
               Me.tbcFichas.TabPages.Remove(Me.tbpCartasEmitidas)
            End If
         End If

      End With

   End Sub

   Private Sub Nuevo()
      Me._estado = Estados.Insercion
      Me.Text = "Fichas"
      Me.txtSaldo.Text = "0.00"
      Me.cmbCobrador.Enabled = True
      Me.cmbVendedor.Enabled = True
      Me.txtSubTotal.Enabled = True
      Me.txtTotal.Enabled = True
      Me.txtAnticipo.Enabled = True
      Me.txtComentario.Enabled = True
      Me.tsbPago.Enabled = False
      Me.tsbDevolverPago.Enabled = False
      Me.tbcFichas.SelectedTab = Me.tbpProductos
      'Me.dgvPagos.DataSource = New Entidades.FichaPagoDetalle()
      Me.dgvPagos.Visible = False
      Me.tbcFichas.Enabled = True
      Me.bscCodigoCliente.Text = String.Empty
      Me.bscCliente.Text = String.Empty
      Me.bscProveedor.Text = String.Empty
      Me.bscProveedor.FilaDevuelta = Nothing
      Me.txtBruto.Enabled = True
      Me.bscCliente.Enabled = True
      Me.bscCodigoCliente.Enabled = True
      Me.dtpFecha.Enabled = True
      Me.txtNroOperacion.Text = "0"
      Me.txtNroOperacion.ReadOnly = True
      Me.oFichaProductos.Clear()
      Me.dtgProductos.DataSource = Me.oFichaProductos.ToArray()
      Me.txtCP.Text = String.Empty
      Me.txtLocalidad.Text = String.Empty
      Me.txtTelefono.Text = String.Empty
      Me.txtBruto.Text = "0"
      Me.txtAnticipo.Text = String.Empty
      Me.txtTotal.Text = String.Empty
      Me.oFichaPagos.Clear()
      Me.dgvCuotas.DataSource = Me.oFichaPagos.ToArray()
      Me.bscDireccion.Text = String.Empty
      'Me.bscDireccion.Enabled = False
      Me.txtComentario.Text = String.Empty

      'valido que no puedan ingresar la fecha de la ficha mayor a 3 dias de la fecha de hoy
      'los 3 dias son por si quieren facturar el viernes las cosas del sabado o domingo
      Me.dtpFecha.MaxDate = Date.Now.AddDays(3)

      Me.dtpFecha.Value = Date.Now
      Me.txtSubTotal.Text = "0"
      Me.txtTotalCuotas.Text = String.Empty
      Me.bscProducto.Text = String.Empty
      Me.txtStock.Text = String.Empty
      Me.txtCantidad.Text = "0"
      Me.txtPrecio.Text = "0"
      Me.txtTotalProducto.Text = "0"
      Me.dtpEntrego.Enabled = True
      Me.dtpEntrego.Checked = True
      Me.txtCuotas.Text = "1"
      Me.txtIntereses.Text = String.Empty
      Me.txtImpCuota.Text = String.Empty
      Me.btnInsertar.Enabled = True
      Me.btnEliminar.Enabled = True
      Me.btnGrabar.Enabled = True
      Me.grbTotales.Enabled = True
      Me.tbcFichas.Enabled = False
      If Me.cmbCobrador.Items.Count > 0 Then
         Me.cmbCobrador.SelectedIndex = 0
      Else
         Me.cmbCobrador.SelectedIndex = -1
      End If
      If Me.cmbVendedor.Items.Count > 0 Then
         Me.cmbVendedor.SelectedIndex = 0
      Else
         Me.cmbVendedor.SelectedIndex = -1
      End If
      Me.cmbCajas.SelectedIndex = 0
      Me.tsbAnular.Enabled = False
      Me.tsbImprimirFicha.Enabled = False
      Me.tsbImpFichaCliente.Enabled = False
      Me.tsbRevisado.Visible = False

      'eliminar la pestana de las cartas emitidas
      If Me.tbcFichas.TabPages.IndexOf(Me.tbpCartasEmitidas) > -1 Then
         Me.tbcFichas.TabPages.Remove(Me.tbpCartasEmitidas)
      End If

      Me._primerSaldo = 0

      Me.bscCodigoCliente.Focus()
   End Sub

   Private Sub ImprimirFicha()
      Try
         Me.Cursor = Cursors.WaitCursor
         Dim dtFic As FichasDataSet.FichasProductosDataTable = New FichasDataSet.FichasProductosDataTable()
         Dim drF As FichasDataSet.FichasProductosRow
         For Each fp As Eniac.Entidades.FichaProducto In oFichaProductos
            drF = dtFic.NewFichasProductosRow()
            drF.ProductoDesc = fp.ProductoDesc
            drF.Cantidad = fp.Cantidad
            drF.Precio = fp.Precio
            dtFic.AddFichasProductosRow(drF)
         Next

         Dim pagare As String = String.Empty
         pagare = Me.txtCuotas.Text & " cuotas de $ " & Me.txtImpCuota.Text & " cada una.------------------------------"

         Dim parm As System.Collections.Generic.List(Of Microsoft.Reporting.WinForms.ReportParameter) = New System.Collections.Generic.List(Of Microsoft.Reporting.WinForms.ReportParameter)

         parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("NombreEmpresa", Eniac.Win.Publicos.NombreEmpresaImpresion))
         parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("Fecha", Me.dtpFecha.Text))
         parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("TipoYNroDoc", Me.bscCodigoCliente.Text))
         parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("NroOperacion", Me.txtNroOperacion.Text))
         parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("NombreYApellido", Me.bscCliente.Text))
         parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("Direccion", Me.bscDireccion.Text))
         parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("Telefono", Me.txtTelefono.Text))
         parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("Localidad", Me.txtLocalidad.Text))
         parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("Saldo", Me.txtTotalCuotas.Text))
         parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("Pagaremos", pagare))
         parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("Anticipo", Me.txtAnticipo.Text))

         Dim frmImprime As VisorReportes = New VisorReportes("Eniac.Win.Ficha.rdlc", "FichasDataSet_FichasProductos", dtFic, parm, 1) '# 1 = Cantidad de Copias
         frmImprime.Text = "Ficha"
         frmImprime.ShowDialog()
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      Finally
         Me.Cursor = Cursors.Default
      End Try
   End Sub

   Private Sub ImprimirFichaCliente()
      Try
         Me.Cursor = Cursors.WaitCursor
         Dim dtFic As FichasDataSet.FichasProductosDataTable = New FichasDataSet.FichasProductosDataTable()
         Dim drF As FichasDataSet.FichasProductosRow
         For Each fp As Eniac.Entidades.FichaProducto In oFichaProductos
            drF = dtFic.NewFichasProductosRow()
            drF.ProductoDesc = fp.ProductoDesc
            drF.Cantidad = fp.Cantidad
            drF.Precio = fp.Precio
            dtFic.AddFichasProductosRow(drF)
         Next

         Dim dtPag As FichasDataSet.FichasPagosDataTable = New FichasDataSet.FichasPagosDataTable()
         Dim drP As FichasDataSet.FichasPagosRow = Nothing
         Dim cont As Integer = 5
         Dim contMax As Integer = 5
         For Each fp As Eniac.Entidades.FichaPago In Me.oFichaPagos
            If cont = contMax Then
               drP = dtPag.NewFichasPagosRow()
               cont = 0
            End If
            If cont = 0 Then
               drP.NroOperacion = fp.NroOperacion
               'drP.IdCliente = fp.IdCliente
               drP.TipoDocumento = ""
               drP.NroDocumento = ""
               drP.NroCuota = fp.NroCuota
               drP.FechaVencimiento = fp.FechaVencimiento
               drP.Importe = fp.Importe
            End If
            If cont = 1 Then
               drP.NroCuota1 = fp.NroCuota
               drP.FechaVencimiento1 = fp.FechaVencimiento
               drP.Importe1 = fp.Importe
            End If
            If cont = 2 Then
               drP.NroCuota2 = fp.NroCuota
               drP.FechaVencimiento2 = fp.FechaVencimiento
               drP.Importe2 = fp.Importe
            End If
            If cont = 3 Then
               drP.NroCuota3 = fp.NroCuota
               drP.FechaVencimiento3 = fp.FechaVencimiento
               drP.Importe3 = fp.Importe
            End If
            If cont = 4 Then
               drP.NroCuota4 = fp.NroCuota
               drP.FechaVencimiento4 = fp.FechaVencimiento
               drP.Importe4 = fp.Importe
            End If
            cont += 1
            If cont = contMax Then
               dtPag.AddFichasPagosRow(drP)
            End If
         Next
         If cont <> contMax Then
            dtPag.AddFichasPagosRow(drP)
         End If

         Dim parm As System.Collections.Generic.List(Of Microsoft.Reporting.WinForms.ReportParameter) = New System.Collections.Generic.List(Of Microsoft.Reporting.WinForms.ReportParameter)

         parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("NombreEmpresa", Eniac.Win.Publicos.NombreEmpresaImpresion))
         parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("NombreYApellido", Me.bscCliente.Text))
         parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("Fecha", Me.dtpFecha.Text))
         parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("NroOperacion", Me.txtNroOperacion.Text))

         Dim frmImprime As VisorReportes = New VisorReportes("Eniac.Win.FichaCliente.rdlc", "FichasDataSet_FichasProductos", dtFic, "FichasDataSet_FichasPagos", dtPag, parm, 1) '# 1 = Cantidad de Copias
         frmImprime.Text = "Ficha Cliente"
         frmImprime.ShowDialog()
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      Finally
         Me.Cursor = Cursors.Default
      End Try
   End Sub

   Private Function ValidarInsertaProducto() As Boolean
      If Double.Parse(Me.txtPrecio.Text) <= 0 Then
         MessageBox.Show("No puede ingresar un producto con precio cero.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
         Me.txtPrecio.Focus()
         Return False
      End If
      Return True
   End Function

#End Region

End Class