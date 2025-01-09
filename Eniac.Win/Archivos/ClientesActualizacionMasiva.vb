Public Class ClientesActualizacionMasiva

#Region "Campos"

   Private _publicos As Publicos
   Private _Clientes As List(Of Entidades.Cliente)

#End Region

#Region "Overrides"

   Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)

      Try

         MyBase.OnLoad(e)

         Me._publicos = New Publicos()
         Me._Clientes = New List(Of Entidades.Cliente)


         Me._publicos.CargaComboEmpleados(Me.cmbVendedor, Entidades.Publicos.TiposEmpleados.VENDEDOR)
         Me.cmbVendedor.SelectedIndex = -1
         Me._publicos.CargaComboEmpleados(Me.cmbNuevoVendedor, Entidades.Publicos.TiposEmpleados.VENDEDOR)
         Me.cmbNuevoVendedor.SelectedIndex = -1

         Me._publicos.CargaComboZonasGeograficas(Me.cmbZonaGeografica)
         Me.cmbZonaGeografica.SelectedIndex = -1
         Me._publicos.CargaComboZonasGeograficas(Me.cmbNuevaZonaGeografica)
         Me.cmbNuevaZonaGeografica.SelectedIndex = -1

         Me._publicos.CargaComboCategorias(Me.cmbCategoria)
         Me._publicos.CargaComboCategorias(Me.cmbNuevaCategoria)

         Me._publicos.CargaComboListaDePrecios(Me.cmbListaDePrecios)
         Me.cmbListaDePrecios.SelectedIndex = -1
         Me._publicos.CargaComboListaDePrecios(Me.cmbNuevaListaDePrecios)
         Me.cmbNuevaListaDePrecios.SelectedIndex = -1

         Me._publicos.CargaComboFormasDePago(Me.cmbFormaPago, "VENTAS")
         Me.cmbFormaPago.SelectedIndex = -1
         Me._publicos.CargaComboFormasDePago(Me.cmbNuevaFormaPago, "VENTAS")
         Me.cmbNuevaFormaPago.SelectedIndex = -1

         _publicos.CargaComboTransportistas(cmbNuevoTransportista)

         Me.cmbActivo.Items.Insert(0, "TODOS")
         Me.cmbActivo.Items.Insert(1, "SI")
         Me.cmbActivo.Items.Insert(2, "NO")
         Me.cmbActivo.SelectedIndex = 0

         Me.cmbNuevoActivo.Items.Insert(0, "SI")
         Me.cmbNuevoActivo.Items.Insert(1, "NO")
         Me.cmbNuevoActivo.SelectedIndex = -1

         Me.cmbRecibeNotificaciones.Items.Insert(0, "SI")
         Me.cmbRecibeNotificaciones.Items.Insert(1, "NO")
         Me.cmbRecibeNotificaciones.SelectedIndex = -1

         Me.cmbRecibeNotificacionesTwo.Items.Insert(0, "TODOS")
         Me.cmbRecibeNotificacionesTwo.Items.Insert(1, "SI")
         Me.cmbRecibeNotificacionesTwo.Items.Insert(2, "NO")
         Me.cmbRecibeNotificacionesTwo.SelectedIndex = 0

         Me.cmbPublicaEnWeb.Items.Insert(0, "TODOS")
         Me.cmbPublicaEnWeb.Items.Insert(1, "SI")
         Me.cmbPublicaEnWeb.Items.Insert(2, "NO")
         Me.cmbPublicaEnWeb.SelectedIndex = 0

         Me.cmbNuevoPublicaEnWeb.Items.Insert(0, "SI")
         Me.cmbNuevoPublicaEnWeb.Items.Insert(1, "NO")
         Me.cmbNuevoPublicaEnWeb.SelectedIndex = -1

         Me._publicos.CargaComboTiposComprobantes(Me.cmbTiposComprobantes, False, "VENTAS", , , "", True)
         Me._publicos.CargaComboTiposComprobantes(Me.cmbNuevoComprobante, False, "VENTAS", , , "", True)


         Me.cmbTipoCliente.Initializar(False, True, True, IdFuncion)
         Me._publicos.CargaComboTipoClientes(Me.cmbTipoCliente, True, True, IdFuncion)
         Me.cmbTipoCliente.SelectedIndex = 0

         Me._publicos.CargaComboTipoClientes(Me.cmbNuevoTipoCliente, False, False, IdFuncion)
         Me.cmbNuevoTipoCliente.SelectedIndex = -1

         Me._publicos.CargaComboEmpleados(Me.cmbCobrador, Entidades.Publicos.TiposEmpleados.COBRADOR)
         Me.cmbCobrador.SelectedIndex = -1

         Me._publicos.CargaComboEmpleados(Me.cmbNuevoCobrador, Entidades.Publicos.TiposEmpleados.COBRADOR)
         Me.cmbNuevoCobrador.SelectedIndex = -1

         Me._publicos.CargaComboEstadosClientes(Me.cmbEstadoCliente)
         Me.cmbEstadoCliente.SelectedIndex = -1

         Me._publicos.CargaComboEstadosClientes(Me.cmbNuevoEstadoCliente)
         Me.cmbNuevoEstadoCliente.SelectedIndex = -1

         Me._publicos.CargaComboDesdeEnum(Me.cmbTodos, GetType(Reglas.Publicos.TodosEnum))

         Me._publicos.CargaComboDesdeEnum(CmbAlicuota2deProducto, GetType(Entidades.Cliente.Alicuota2DeProductoSegun))
         Me.CmbAlicuota2deProducto.SelectedIndex = -1
         Me._publicos.CargaComboDesdeEnum(CmbNuevoAlicuota2deProducto, GetType(Entidades.Cliente.Alicuota2DeProductoSegun))
         Me.CmbNuevoAlicuota2deProducto.SelectedIndex = -1

         '-.PE-31491.-
         Me._publicos.CargaComboCategoriasFiscales(Me.cmbCategoriaFiscal)
         Me._publicos.CargaComboCategoriasFiscales(Me.cmbNuevaCategoriaFiscal)

         Me.chbAlicuota2deProducto.Visible = Publicos.ProductoUtilizaAlicuota2
         CmbAlicuota2deProducto.Visible = Me.chbAlicuota2deProducto.Visible

         Me.chbNuevoAlicuota2deProducto.Visible = Me.chbAlicuota2deProducto.Visible
         CmbNuevoAlicuota2deProducto.Visible = Me.chbAlicuota2deProducto.Visible

         Me.ugDetalle.DisplayLayout.Bands(0).Columns("Alicuota2deProducto").Hidden = Not Me.chbAlicuota2deProducto.Visible

         Ayudante.Grilla.AgregarFiltroEnLinea(ugDetalle, {"CodigoCliente", "NombreCliente", "Direccion"})

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try

   End Sub

#End Region

#Region "Eventos"

   Private Sub ActualizacionMasivaClientesVendedores_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyUp
      If e.KeyCode = Keys.F5 Then
         Me.tsbRefrescar_Click(Me.tsbRefrescar, New EventArgs())
      End If
   End Sub

   Private Sub tsbRefrescar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbRefrescar.Click
      Try
         Me.Cursor = Cursors.WaitCursor

         Me.RefrescarDatosGrilla()

         Me.tssRegistros.Text = Me.ugDetalle.Rows.Count.ToString() & " Registros"

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)

      Finally
         Me.Cursor = Cursors.Default
      End Try
   End Sub

   Private Sub tsbAplicar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbAplicar.Click

      Try
         ugDetalle.UpdateData()
         If Me.chbNuevoVendedor.Checked And Me.cmbNuevoVendedor.SelectedIndex = -1 Then
            MessageBox.Show("ATENCION: Activo el Nuevo Vendedor pero No seleccionó uno.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.cmbNuevoVendedor.Focus()
            Exit Sub
         End If

         If Me.chbNuevaZonaGeografica.Checked And Me.cmbNuevaZonaGeografica.SelectedIndex = -1 Then
            MessageBox.Show("ATENCION: Activo la Nueva Zona Geográfica pero No seleccionó una.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.cmbNuevaZonaGeografica.Focus()
            Exit Sub
         End If

         If Me.chbNuevaCategoria.Checked And Me.cmbNuevaCategoria.SelectedIndex = -1 Then
            MessageBox.Show("ATENCION: Activo la Nueva Categoría pero No seleccionó una.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.cmbNuevaCategoria.Focus()
            Exit Sub
         End If

         If Me.chbNuevaListaDePrecios.Checked And Me.cmbNuevaListaDePrecios.SelectedIndex = -1 Then
            MessageBox.Show("ATENCION: Activo la Nueva Lista de Precios pero No seleccionó una.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.cmbNuevaListaDePrecios.Focus()
            Exit Sub
         End If

         If Me.chbNuevoActivo.Checked And Me.cmbNuevoActivo.SelectedIndex = -1 Then
            MessageBox.Show("ATENCION: Activo el Nuevo Estado pero No seleccionó uno.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.cmbNuevoActivo.Focus()
            Exit Sub
         End If
         If Me.chbNuevoRecibeNotificaciones.Checked And Me.cmbRecibeNotificaciones.SelectedIndex = -1 Then
            MessageBox.Show("ATENCION: Activo Recibe Notificaciones pero No seleccionó uno.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.chbNuevoRecibeNotificaciones.Focus()
            Exit Sub
         End If

         If Me.chbNuevaFormaPago.Checked And Me.cmbNuevaFormaPago.SelectedIndex = -1 Then
            MessageBox.Show("ATENCION: Activo la Nueva Forma de Pago pero No seleccionó uno.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.cmbNuevaFormaPago.Focus()
            Exit Sub
         End If

         If Me.chbNuevoComprobante.Checked And Me.cmbNuevoComprobante.SelectedIndex = -1 Then
            MessageBox.Show("ATENCION: Activo el Nuevo Tipo de Comprobante pero No seleccionó uno.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.cmbNuevoComprobante.Focus()
            Exit Sub
         End If
         If Me.chbNuevaLocalidad.Checked And Not Me.bscNuevoCodigoLocalidad.Selecciono And Not Me.bscNuevoNombreLocalidad.Selecciono Then
            MessageBox.Show("ATENCION: Activo la Nueva Localidad pero No seleccionó una.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.bscNuevoCodigoLocalidad.Focus()
            Exit Sub
         End If
         If Me.chbNuevoNivelAutorizacion.Checked And String.IsNullOrWhiteSpace(Me.txtNuevoNivelAutorizacion.Text) Then
            MessageBox.Show("ATENCION: Activo el Nuevo Nivel de Autorizacion pero No ingreso un valor", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.txtNuevoNivelAutorizacion.Focus()
            Exit Sub
         End If

         If chbNuevoTransportista.Checked And cmbNuevoTransportista.SelectedIndex = -1 Then
            MessageBox.Show("ATENCION: Activo el Nuevo Transportista pero No seleccionó uno.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.cmbNuevoTransportista.Focus()
            Exit Sub
         End If
         If chbNuevoAlicuota2deProducto.Checked And CmbNuevoAlicuota2deProducto.SelectedIndex = -1 Then
            MessageBox.Show("ATENCION: Activo la Nueva Alicuota 2 del Producto pero No seleccionó una.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.CmbNuevoAlicuota2deProducto.Focus()
            Exit Sub
         End If
         If chbNuevoTipoCliente.Checked And cmbNuevoTipoCliente.SelectedIndex = -1 Then
            MessageBox.Show("ATENCION: Activo el Nuevo Tipo de Cliente pero No seleccionó uno.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.cmbNuevoTipoCliente.Focus()
            Exit Sub
         End If

         If Me.chbNuevoPublicaEnWeb.Checked And Me.cmbNuevoPublicaEnWeb.SelectedIndex = -1 Then
            MessageBox.Show("ATENCION: Activo Publicar en Web pero No seleccionó uno.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.chbNuevoPublicaEnWeb.Focus()
            Exit Sub
         End If

         If Not Me.chbNuevoVendedor.Checked And
            Not Me.chbNuevaZonaGeografica.Checked And
            Not Me.chbNuevaCategoria.Checked And
            Not Me.chbNuevaListaDePrecios.Checked And
            Not Me.chbNuevoActivo.Checked And
            Not Me.chbNuevoRecibeNotificaciones.Checked And
            Not Me.chbNuevaFormaPago.Checked And
            Not Me.chbNuevoDescuentoRecargo.Checked And
            Not Me.chbNuevoComprobante.Checked And
            Not Me.chbNuevoEstado.Checked And
            Not Me.chbNuevoCobrador.Checked And
            Not Me.chbNuevaCantidadVisitas.Checked And
            Not Me.chbNuevaLocalidad.Checked And
            Not Me.chbNuevoNivelAutorizacion.Checked And
            Not Me.chbNuevoTransportista.Checked And
            Not Me.chbNuevoAlicuota2deProducto.Checked And
            Not Me.chbNuevoTipoCliente.Checked And
            Not Me.chbNuevoPublicaEnWeb.Checked And
            Not Me.chbNuevoDiasLimiteVtoFact.Checked And
            Not Me.chbNuevoLimiteCredito.Checked And
            Not Me.chbNuevaCategoriaFiscal.Checked Then

            MessageBox.Show("ATENCION: No seleccionó Ninguna Caraterística a Ajustar.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            'Me.bscMarca.Focus()
            Exit Sub
         End If


         If Me.ugDetalle.Rows.Count = 0 Then Exit Sub

         Me.Cursor = Cursors.WaitCursor

         Me.AplicarCambios()

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      Finally
         Me.Cursor = Cursors.Default
      End Try

   End Sub

   Private Sub tsbSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbSalir.Click
      Me.Close()
   End Sub

   Private Sub chbVendedor_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chbVendedor.CheckedChanged

      Me.cmbVendedor.Enabled = Me.chbVendedor.Checked

      If Not Me.chbVendedor.Checked Then
         Me.cmbVendedor.SelectedIndex = -1
      Else
         If Me.cmbVendedor.Items.Count > 0 Then
            Me.cmbVendedor.SelectedIndex = 0
         End If

         Me.cmbVendedor.Focus()

      End If

   End Sub

   Private Sub chbZonaGeografica_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chbZonaGeografica.CheckedChanged

      Me.cmbZonaGeografica.Enabled = Me.chbZonaGeografica.Checked

      If Not Me.chbZonaGeografica.Checked Then
         Me.cmbZonaGeografica.SelectedIndex = -1
      Else
         If Me.cmbZonaGeografica.Items.Count > 0 Then
            Me.cmbZonaGeografica.SelectedIndex = 0
         End If

         Me.cmbZonaGeografica.Focus()

      End If

   End Sub

   Private Sub bscCodigoCliente_BuscadorClick() Handles bscCodigoCliente.BuscadorClick, bscCodigoCliente.BuscadorClick
      Dim codigoCliente As Long = -1
      Try
         Me._publicos.PreparaGrillaClientes(Me.bscCodigoCliente)
         Dim oClientes As Reglas.Clientes = New Reglas.Clientes
         If Me.bscCodigoCliente.Text.Trim.Length > 0 Then
            codigoCliente = Long.Parse(Me.bscCodigoCliente.Text.Trim())
         End If
         Me.bscCodigoCliente.Datos = oClientes.GetFiltradoPorCodigo(codigoCliente, True, False)
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try

   End Sub

   Private Sub bscCodigoCliente_BuscadorSeleccion(ByVal sender As Object, ByVal e As Controles.BuscadorEventArgs) Handles bscCodigoCliente.BuscadorSeleccion, bscCodigoCliente.BuscadorSeleccion
      Try
         If Not e.FilaDevuelta Is Nothing Then
            Me.CargarDatosCliente(e.FilaDevuelta)
            Me.btnConsultar.Focus()
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub bscCliente_BuscadorClick() Handles bscCliente.BuscadorClick
      Try
         Me._publicos.PreparaGrillaClientes(Me.bscCliente)
         Dim oClientes As Reglas.Clientes = New Reglas.Clientes
         Me.bscCliente.Datos = oClientes.GetFiltradoPorNombre(Me.bscCliente.Text.Trim(), False)
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub bscCliente_BuscadorSeleccion(ByVal sender As Object, ByVal e As Controles.BuscadorEventArgs) Handles bscCliente.BuscadorSeleccion
      Try
         If Not e.FilaDevuelta Is Nothing Then
            Me.CargarDatosCliente(e.FilaDevuelta)
            Me.btnConsultar.Focus()
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub chbCliente_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chbCliente.CheckedChanged

      Me.bscCodigoCliente.Enabled = Me.chbCliente.Checked
      Me.bscCliente.Enabled = Me.chbCliente.Checked

      Me.bscCodigoCliente.Text = String.Empty
      Me.bscCodigoCliente.Tag = Nothing

      Me.bscCliente.Text = String.Empty

      Me.bscCodigoCliente.Focus()

   End Sub

   Private Sub chbCategoria_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chbCategoria.CheckedChanged

      Me.cmbCategoria.Enabled = Me.chbCategoria.Checked

      If Not Me.chbCategoria.Checked Then
         Me.cmbCategoria.SelectedIndex = -1
      Else
         If Me.cmbCategoria.Items.Count > 0 Then
            Me.cmbCategoria.SelectedIndex = 0
         End If

         Me.cmbCategoria.Focus()

      End If

   End Sub

   Private Sub chbListaDePrecios_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chbListaDePrecios.CheckedChanged

      Me.cmbListaDePrecios.Enabled = Me.chbListaDePrecios.Checked

      If Not Me.chbListaDePrecios.Checked Then
         Me.cmbListaDePrecios.SelectedIndex = -1
      Else
         If Me.cmbListaDePrecios.Items.Count > 0 Then
            Me.cmbListaDePrecios.SelectedIndex = 0
         End If

         Me.cmbListaDePrecios.Focus()

      End If

   End Sub

   Private Sub chbFormaPago_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chbFormaPago.CheckedChanged
      Me.cmbFormaPago.Enabled = Me.chbFormaPago.Checked
      If Not Me.chbFormaPago.Checked Then
         Me.cmbFormaPago.SelectedIndex = -1
      Else
         Me.cmbFormaPago.Focus()
      End If
   End Sub

   Private Sub chbDescuentoRecargo_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chbDescuentoRecargo.CheckedChanged
      Me.txtDescuentoRecargoPorc.Enabled = Me.chbDescuentoRecargo.Checked
      If Not Me.chbDescuentoRecargo.Checked Then
         Me.txtDescuentoRecargoPorc.Text = "0.00"
      Else
         Me.txtDescuentoRecargoPorc.Focus()
      End If
   End Sub
   Private Sub chbNivelAutorizacion_CheckedChanged(sender As Object, e As EventArgs) Handles chbNivelAutorizacion.CheckedChanged
      Me.txtNivelAutorizacion.Enabled = Me.chbNivelAutorizacion.Checked
      If Not Me.chbNivelAutorizacion.Checked Then
         Me.txtNivelAutorizacion.Text = ""
      Else
         Me.txtNivelAutorizacion.Focus()
      End If
   End Sub
   Private Sub btnConsultar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnConsultar.Click

      Try

         If Me.chbCliente.Checked And Not Me.bscCodigoCliente.Selecciono And Not Me.bscCliente.Selecciono Then
            MessageBox.Show("ATENCION: No seleccionó un Cliente aunque activó ese Filtro", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.bscCodigoCliente.Focus()
            Exit Sub
         End If

         Me.Cursor = Cursors.WaitCursor

         Me.cmbTodos.SelectedIndex = 0

         Me.CargaGrillaDetalle()

         If ugDetalle.Rows.Count > 0 Then
            Me.btnConsultar.Focus()
         Else
            Me.Cursor = Cursors.Default
            MessageBox.Show("ATENCION: NO hay registros que cumplan con la selección !!!", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
         End If

      Catch ex As Exception
         Me.tssRegistros.Text = "0 Registros"
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)

      Finally
         Me.Cursor = Cursors.Default
      End Try

   End Sub

   Private Sub chbNuevoVendedor_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chbNuevoVendedor.CheckedChanged
      Me.cmbNuevoVendedor.Enabled = Me.chbNuevoVendedor.Checked
      If Not Me.chbNuevoVendedor.Checked Then
         Me.cmbNuevoVendedor.SelectedIndex = -1
      Else
         Me.cmbNuevoVendedor.Focus()
      End If
   End Sub

   Private Sub chbNuevaZonaGeografica_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chbNuevaZonaGeografica.CheckedChanged
      Me.cmbNuevaZonaGeografica.Enabled = Me.chbNuevaZonaGeografica.Checked
      If Not Me.chbNuevaZonaGeografica.Checked Then
         Me.cmbNuevaZonaGeografica.SelectedIndex = -1
      Else
         Me.cmbNuevaZonaGeografica.Focus()
      End If
   End Sub

   Private Sub chbNuevaCategoria_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chbNuevaCategoria.CheckedChanged
      Me.cmbNuevaCategoria.Enabled = Me.chbNuevaCategoria.Checked
      If Not Me.chbNuevaCategoria.Checked Then
         Me.cmbNuevaCategoria.SelectedIndex = -1
      Else
         Me.cmbNuevaCategoria.Focus()
      End If
   End Sub

   Private Sub chbNuevaListaDePrecios_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chbNuevaListaDePrecios.CheckedChanged
      Me.cmbNuevaListaDePrecios.Enabled = Me.chbNuevaListaDePrecios.Checked
      If Not Me.chbNuevaListaDePrecios.Checked Then
         Me.cmbNuevaListaDePrecios.SelectedIndex = -1
      Else
         Me.cmbNuevaListaDePrecios.Focus()
      End If
   End Sub

   Private Sub chbNuevaFormaPago_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chbNuevaFormaPago.CheckedChanged
      Me.cmbNuevaFormaPago.Enabled = Me.chbNuevaFormaPago.Checked
      If Not Me.chbNuevaFormaPago.Checked Then
         Me.cmbNuevaFormaPago.SelectedIndex = -1
      Else
         Me.cmbNuevaFormaPago.Focus()
      End If
   End Sub

   Private Sub chbNuevoDescuentoRecargo_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chbNuevoDescuentoRecargo.CheckedChanged
      Me.txtNuevoDescuentoRecargoPorc.Enabled = Me.chbNuevoDescuentoRecargo.Checked
      If Not Me.chbNuevoDescuentoRecargo.Checked Then
         Me.txtNuevoDescuentoRecargoPorc.Text = "0.00"
      Else
         Me.txtNuevoDescuentoRecargoPorc.Focus()
      End If
   End Sub

   Private Sub chbNuevoActivo_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chbNuevoActivo.CheckedChanged
      Me.cmbNuevoActivo.Enabled = Me.chbNuevoActivo.Checked
      If Not Me.chbNuevoActivo.Checked Then
         Me.cmbNuevoActivo.SelectedIndex = -1
      Else
         Me.cmbNuevoActivo.Focus()
      End If
   End Sub
   Private Sub chbRecibeNotificaciones_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chbNuevoRecibeNotificaciones.CheckedChanged
      Me.cmbRecibeNotificaciones.Enabled = Me.chbNuevoRecibeNotificaciones.Checked
      If Not Me.chbNuevoRecibeNotificaciones.Checked Then
         Me.cmbRecibeNotificaciones.SelectedIndex = -1
      Else
         Me.cmbRecibeNotificaciones.Focus()
      End If
   End Sub

   Private Sub chbCantidadVisitas_CheckedChanged(sender As Object, e As EventArgs) Handles chbNuevaCantidadVisitas.CheckedChanged
      Me.txtNuevaCantidadVisitas.Enabled = Me.chbNuevaCantidadVisitas.Checked
      If Not Me.chbNuevaCantidadVisitas.Checked Then
         Me.txtNuevaCantidadVisitas.Text = "0"
      Else
         Me.txtNuevaCantidadVisitas.Text = Publicos.ClientesCantidadVisitasPordefecto.ToString()
         Me.txtNuevaCantidadVisitas.Focus()
      End If
   End Sub
   Private Sub chbNuevoNivelAutorizacion_CheckedChanged(sender As Object, e As EventArgs) Handles chbNuevoNivelAutorizacion.CheckedChanged
      Me.txtNuevoNivelAutorizacion.Enabled = Me.chbNuevoNivelAutorizacion.Checked
      If Not Me.chbNuevoNivelAutorizacion.Checked Then
         Me.txtNuevoNivelAutorizacion.Text = ""
      Else
         Me.txtNuevoNivelAutorizacion.Focus()
      End If
   End Sub

   Private Sub chbComprobanteFacturacion_CheckedChanged(sender As Object, e As EventArgs) Handles chbComprobanteFacturacion.CheckedChanged
      Me.cmbTiposComprobantes.Enabled = Me.chbComprobanteFacturacion.Checked

      If Not Me.chbComprobanteFacturacion.Checked Then
         Me.cmbTiposComprobantes.SelectedIndex = -1
      Else
         If Me.cmbTiposComprobantes.Items.Count > 0 Then
            Me.cmbTiposComprobantes.SelectedIndex = 0
         End If

         Me.cmbTiposComprobantes.Focus()

      End If
   End Sub

   Private Sub chbNuevoComprobante_CheckedChanged(sender As Object, e As EventArgs) Handles chbNuevoComprobante.CheckedChanged
      Me.cmbNuevoComprobante.Enabled = Me.chbNuevoComprobante.Checked
      If Not Me.chbNuevoComprobante.Checked Then
         Me.cmbNuevoComprobante.SelectedIndex = -1
      Else
         Me.cmbNuevoComprobante.Focus()
      End If
   End Sub

   Private Sub chbEstado_CheckedChanged(sender As Object, e As EventArgs) Handles chbEstado.CheckedChanged
      Me.cmbEstadoCliente.Enabled = Me.chbEstado.Checked

      If Not Me.chbEstado.Checked Then
         Me.cmbEstadoCliente.SelectedIndex = -1
      Else
         If Me.cmbEstadoCliente.Items.Count > 0 Then
            Me.cmbEstadoCliente.SelectedIndex = 0
         End If

         Me.cmbEstadoCliente.Focus()
      End If

   End Sub

   Private Sub chbCobrador_CheckedChanged(sender As Object, e As EventArgs) Handles chbCobrador.CheckedChanged
      Me.cmbCobrador.Enabled = Me.chbCobrador.Checked

      If Not Me.chbCobrador.Checked Then
         Me.cmbCobrador.SelectedIndex = -1
      Else
         If Me.cmbCobrador.Items.Count > 0 Then
            Me.cmbCobrador.SelectedIndex = 0
         End If

         Me.cmbCobrador.Focus()
      End If

   End Sub

   Private Sub chbNuevoEstado_CheckedChanged(sender As Object, e As EventArgs) Handles chbNuevoEstado.CheckedChanged
      Me.cmbNuevoEstadoCliente.Enabled = Me.chbNuevoEstado.Checked
      If Not Me.chbNuevoEstado.Checked Then
         Me.cmbNuevoEstadoCliente.SelectedIndex = -1
      Else
         Me.cmbNuevoEstadoCliente.Focus()
      End If
   End Sub

   Private Sub chbNuevoCobrador_CheckedChanged(sender As Object, e As EventArgs) Handles chbNuevoCobrador.CheckedChanged
      Me.cmbNuevoCobrador.Enabled = Me.chbNuevoCobrador.Checked
      If Not Me.chbNuevoCobrador.Checked Then
         Me.cmbNuevoCobrador.SelectedIndex = -1
      Else
         Me.cmbNuevoCobrador.Focus()
      End If
   End Sub
   Private Sub chbLocalidad_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chbNuevaLocalidad.CheckedChanged

      Me.bscNuevoCodigoLocalidad.Enabled = Me.chbNuevaLocalidad.Checked
      Me.bscNuevoNombreLocalidad.Enabled = Me.chbNuevaLocalidad.Checked

      Me.bscNuevoCodigoLocalidad.Text = String.Empty
      Me.bscNuevoNombreLocalidad.Text = String.Empty

      If Me.chbNuevaLocalidad.Checked Then
         Me.bscNuevoCodigoLocalidad.Focus()
      End If

   End Sub

   Private Sub bscCodigoLocalidad_BuscadorClick() Handles bscNuevoCodigoLocalidad.BuscadorClick
      Try
         Dim oLocalidades As Reglas.Localidades = New Reglas.Localidades
         Me._publicos.PreparaGrillaLocalidades(Me.bscNuevoCodigoLocalidad)
         Me.bscNuevoCodigoLocalidad.Datos = oLocalidades.GetPorCodigo(Integer.Parse("0" & Me.bscNuevoCodigoLocalidad.Text))
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub bscCodigoLocalidad_BuscadorSeleccion(ByVal sender As Object, ByVal e As Controles.BuscadorEventArgs) Handles bscNuevoCodigoLocalidad.BuscadorSeleccion
      Try
         If Not e.FilaDevuelta Is Nothing Then
            Me.CargarLocalidad(e.FilaDevuelta)
            Me.btnConsultar.Focus()
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub bscNombreLocalidad_BuscadorClick() Handles bscNuevoNombreLocalidad.BuscadorClick
      Try
         Dim oLocalidades As Reglas.Localidades = New Reglas.Localidades
         Me._publicos.PreparaGrillaLocalidades(Me.bscNuevoNombreLocalidad)
         Me.bscNuevoNombreLocalidad.Datos = oLocalidades.GetPorNombre(Me.bscNuevoNombreLocalidad.Text.Trim())
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub bscNombreLocalidad_BuscadorSeleccion(ByVal sender As Object, ByVal e As Controles.BuscadorEventArgs) Handles bscNuevoNombreLocalidad.BuscadorSeleccion
      Try
         If Not e.FilaDevuelta Is Nothing Then
            Me.CargarLocalidad(e.FilaDevuelta)
            Me.btnConsultar.Focus()
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub chbNuevoTransportista_CheckedChanged(sender As Object, e As EventArgs) Handles chbNuevoTransportista.CheckedChanged
      Try
         chbNuevoTransportista.FiltroCheckedChanged(cmbNuevoTransportista)
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

   Private Sub chbAlicuota2deProducto_CheckedChanged(sender As Object, e As EventArgs) Handles chbAlicuota2deProducto.CheckedChanged
      Me.CmbAlicuota2deProducto.Enabled = Me.chbAlicuota2deProducto.Checked

      If Not Me.chbAlicuota2deProducto.Checked Then
         Me.CmbAlicuota2deProducto.SelectedIndex = -1
      Else
         If Me.CmbAlicuota2deProducto.Items.Count > 0 Then
            Me.CmbAlicuota2deProducto.SelectedIndex = 0
         End If

         Me.CmbAlicuota2deProducto.Focus()

      End If
   End Sub
   Private Sub chbNuevoAlicuota2deProducto_CheckedChanged(sender As Object, e As EventArgs) Handles chbNuevoAlicuota2deProducto.CheckedChanged
      Me.CmbNuevoAlicuota2deProducto.Enabled = Me.chbNuevoAlicuota2deProducto.Checked

      If Not Me.chbNuevoAlicuota2deProducto.Checked Then
         Me.CmbNuevoAlicuota2deProducto.SelectedIndex = -1
      Else
         If Me.CmbNuevoAlicuota2deProducto.Items.Count > 0 Then
            Me.CmbNuevoAlicuota2deProducto.SelectedIndex = 0
         End If

         Me.CmbNuevoAlicuota2deProducto.Focus()

      End If
   End Sub

   Private Sub chbTipoCliente_CheckedChanged(sender As Object, e As EventArgs) Handles chbNuevoTipoCliente.CheckedChanged
      Me.cmbNuevoTipoCliente.Enabled = Me.chbNuevoTipoCliente.Checked
      If Not Me.chbNuevoTipoCliente.Checked Then
         Me.cmbNuevoTipoCliente.SelectedIndex = -1
      End If
   End Sub

   Private Sub chbNuevoPublicaEnWeb_CheckedChanged(sender As Object, e As EventArgs) Handles chbNuevoPublicaEnWeb.CheckedChanged
      Me.cmbNuevoPublicaEnWeb.Enabled = Me.chbNuevoPublicaEnWeb.Checked
      If Not Me.chbNuevoPublicaEnWeb.Checked Then
         Me.cmbNuevoPublicaEnWeb.SelectedIndex = -1
      Else
         Me.cmbNuevoPublicaEnWeb.Focus()
      End If
   End Sub

   Private Sub chbNuevoDiasLimiteVtoFact_CheckedChanged(sender As Object, e As EventArgs) Handles chbNuevoDiasLimiteVtoFact.CheckedChanged
      Me.txtNuevoLimiteDiasVtoFactura.Enabled = Me.chbNuevoDiasLimiteVtoFact.Checked
      If Not Me.chbNuevoDiasLimiteVtoFact.Checked Then
         Me.txtNuevoLimiteDiasVtoFactura.Text = ""
      Else
         Me.txtNuevoLimiteDiasVtoFactura.Focus()
      End If
   End Sub

   Private Sub chbNuevoLimiteCredito_CheckedChanged(sender As Object, e As EventArgs) Handles chbNuevoLimiteCredito.CheckedChanged
      Me.txtNuevoLimiteDeCredito.Enabled = Me.chbNuevoLimiteCredito.Checked
      If Not Me.chbNuevoLimiteCredito.Checked Then
         Me.txtNuevoLimiteDeCredito.Text = ""
      Else
         Me.txtNuevoLimiteDeCredito.Focus()
      End If
   End Sub

   Private Sub chbNuevaCategoriaFiscal_CheckedChanged(sender As Object, e As EventArgs) Handles chbNuevaCategoriaFiscal.CheckedChanged
      Me.cmbNuevaCategoriaFiscal.Enabled = Me.chbNuevaCategoriaFiscal.Checked

      If Not Me.chbNuevaCategoriaFiscal.Checked Then
         Me.cmbNuevaCategoriaFiscal.SelectedIndex = -1
      Else
         Me.cmbNuevaCategoriaFiscal.Focus()
      End If
   End Sub

   Private Sub chbCategoriaFiscal_CheckedChanged(sender As Object, e As EventArgs) Handles chbCategoriaFiscal.CheckedChanged
      Me.cmbCategoriaFiscal.Enabled = Me.chbCategoriaFiscal.Checked

      If Not Me.chbCategoriaFiscal.Checked Then
         Me.cmbCategoriaFiscal.SelectedIndex = -1
      Else
         If Me.cmbCategoriaFiscal.Items.Count > 0 Then
            Me.cmbCategoriaFiscal.SelectedIndex = 0
         End If

         Me.cmbCategoriaFiscal.Focus()
      End If
   End Sub

#End Region

#Region "Metodos"

   Private Sub CargarDatosCliente(ByVal dr As DataGridViewRow)

      Me.bscCliente.Text = dr.Cells("NombreCliente").Value.ToString()
      Me.bscCodigoCliente.Text = dr.Cells("CodigoCliente").Value.ToString()
      Me.bscCodigoCliente.Tag = dr.Cells("IdCliente").Value.ToString()
      Me.bscCliente.Enabled = False
      Me.bscCodigoCliente.Enabled = False

   End Sub

   Private Sub RefrescarDatosGrilla()

      Me.chbCliente.Checked = False
      Me.chbVendedor.Checked = False
      Me.chbZonaGeografica.Checked = False
      Me.chbCategoria.Checked = False
      Me.chbListaDePrecios.Checked = False
      Me.cmbActivo.SelectedIndex = 0
      Me.chbFormaPago.Checked = False
      Me.chbDescuentoRecargo.Checked = False
      Me.chbComprobanteFacturacion.Checked = False
      Me.chbNivelAutorizacion.Checked = False
      Me.chbAlicuota2deProducto.Checked = False
      Me.chbNuevoAlicuota2deProducto.Checked = False
      Me.cmbPublicaEnWeb.SelectedIndex = 0
      If Not Me.ugDetalle.DataSource Is Nothing Then
         DirectCast(Me.ugDetalle.DataSource, DataTable).Rows.Clear()
      End If
      Me.chbCategoriaFiscal.Checked = False

      Me.cmbTodos.SelectedIndex = 0

      Me.cmbTipoCliente.SelectedIndex = 0

      Me.chbNuevoTipoCliente.Checked = False
      Me.chbNuevoVendedor.Checked = False
      Me.chbNuevaZonaGeografica.Checked = False
      Me.chbNuevaCategoria.Checked = False
      Me.chbNuevaListaDePrecios.Checked = False
      Me.chbNuevoActivo.Checked = False
      Me.chbNuevoRecibeNotificaciones.Checked = False
      Me.chbNuevaFormaPago.Checked = False
      Me.chbNuevoDescuentoRecargo.Checked = False
      Me.chbNuevoComprobante.Checked = False
      Me.chbNuevoCobrador.Checked = False
      Me.chbNuevoEstado.Checked = False
      Me.chbEstado.Checked = False
      Me.chbCobrador.Checked = False
      Me.chbNuevaCantidadVisitas.Checked = False
      Me.chbNuevaLocalidad.Checked = False
      Me.chbNuevoNivelAutorizacion.Checked = False
      Me.chbNuevoPublicaEnWeb.Checked = False
      Me.chbNuevoDiasLimiteVtoFact.Checked = False
      Me.chbNuevoLimiteCredito.Checked = False
      Me.chbNuevaCategoriaFiscal.Checked = False
      Me.btnConsultar.Focus()

   End Sub

   Private Sub CargaGrillaDetalle()

      Try

         Dim oRegClientes As Reglas.Clientes = New Reglas.Clientes()

         Dim Total1 As Decimal = 0
         Dim Total2 As Decimal = 0

         Dim IdVendedor As Integer = 0

         Dim idZonaGeografica As String = String.Empty

         Dim desde As Date = Nothing
         Dim hasta As Date = Nothing

         Dim idCliente As Long = 0

         Dim idFormaPago As Integer = 0
         Dim descPorRecargo As Decimal? = Nothing

         Dim idCategoria As Integer = 0

         Dim idCobrador As Integer = 0

         Dim idEstado As Integer = 0

         Dim idListaDePrecios As Integer = -1
         Dim idTipoComprobante As String = ""
         Dim nivelAutorizacion As Short? = Nothing
         Dim alicuota2deProducto As String = String.Empty

         Dim idCategoriaFiscal As Integer = 0

         If Me.cmbVendedor.Enabled Then
            IdVendedor = DirectCast(Me.cmbVendedor.SelectedItem, Entidades.Empleado).IdEmpleado
         End If

         If Me.cmbZonaGeografica.Enabled Then
            idZonaGeografica = Me.cmbZonaGeografica.SelectedValue.ToString()
         End If

         If Me.bscCodigoCliente.Text.Length > 0 Then
            idCliente = Long.Parse(Me.bscCodigoCliente.Tag.ToString())
         End If

         If Me.cmbCategoria.Enabled Then
            idCategoria = Integer.Parse(Me.cmbCategoria.SelectedValue.ToString())
         End If

         If Me.cmbListaDePrecios.Enabled Then
            idListaDePrecios = Integer.Parse(Me.cmbListaDePrecios.SelectedValue.ToString())
         End If

         If Me.cmbFormaPago.Enabled Then
            idFormaPago = Integer.Parse(Me.cmbFormaPago.SelectedValue.ToString())
         End If

         If Me.txtDescuentoRecargoPorc.Enabled Then
            descPorRecargo = Decimal.Parse(Me.txtDescuentoRecargoPorc.Text)
         End If

         If Me.cmbTiposComprobantes.Enabled Then
            idTipoComprobante = Me.cmbTiposComprobantes.SelectedValue.ToString()
         End If

         If Me.cmbEstadoCliente.Enabled Then
            idEstado = Integer.Parse(Me.cmbEstadoCliente.SelectedValue.ToString())
         End If

         If Me.cmbCobrador.Enabled Then
            idCobrador = DirectCast(Me.cmbCobrador.SelectedItem, Entidades.Empleado).IdEmpleado
         End If

         'If Me.cmbCobrador.Enabled Then
         '   idCobrador = Me.cmbCobrador.SelectedValue.ToString()
         'End If

         If IsNumeric(txtNivelAutorizacion.Text) Then
            nivelAutorizacion = Short.Parse(txtNivelAutorizacion.Text)
         End If

         If Me.chbAlicuota2deProducto.Checked Then
            alicuota2deProducto = Me.CmbAlicuota2deProducto.SelectedValue.ToString()
         End If

         If Me.chbCategoriaFiscal.Checked Then
            idCategoriaFiscal = Integer.Parse(Me.cmbCategoriaFiscal.SelectedValue.ToString())
         End If

         Dim dtDetalle As DataTable
         Dim dt As DataTable
         Dim drCl As DataRow

         dtDetalle = oRegClientes.GetPorFiltrosVarios(IdVendedor,
                                                      idCliente,
                                                      idZonaGeografica,
                                                      idCategoria,
                                                      idListaDePrecios,
                                                      idFormaPago,
                                                      descPorRecargo,
                                                      Me.cmbActivo.Text,
                                                      idTipoComprobante,
                                                      idCobrador,
                                                      idEstado,
                                                      Me.cmbRecibeNotificacionesTwo.Text,
                                                      nivelAutorizacion,
                                                      alicuota2deProducto,
                                                      Me.cmbTipoCliente.GetTipoClientes(),
                                                      Me.cmbPublicaEnWeb.Text,
                                                      idCategoriaFiscal)

         dt = Me.CrearDT()

         For Each dr As DataRow In dtDetalle.Rows

            drCl = dt.NewRow()
            drCl("Selec") = False
            drCl("IdCliente") = Long.Parse(dr("IdCliente").ToString())
            drCl("CodigoCliente") = Long.Parse(dr("CodigoCliente").ToString())
            drCl("NombreCliente") = dr("NombreCliente").ToString()
            drCl("CUIT") = dr("CUIT").ToString()
            drCl("NombreZonaGeografica") = dr("NombreZonaGeografica").ToString()
            drCl("NombreCategoria") = dr("NombreCategoria").ToString()
            drCl("NombreListaPrecios") = dr("NombreListaPrecios").ToString()
            drCl("IdVendedor") = dr("IdVendedor").ToString()
            drCl("NombreVendedor") = dr("NombreVendedor").ToString()
            drCl("DescripcionFormasPago") = dr("DescripcionFormasPago")
            drCl("DescuentoRecargoPorc") = dr("DescuentoRecargoPorc")
            drCl("Activo") = dr("Activo")
            drCl("Descripcion") = dr("Descripcion")
            drCl("NombreCobrador") = dr("NombreCobrador")
            drCl("IdTransportista") = dr("IdTransportista")
            drCl("NombreTransportista") = dr("NombreTransportista")
            drCl("NombreEstadoCliente") = dr("NombreEstadoCliente")
            drCl("CantidadVisitas") = dr("CantidadVisitas")
            drCl("NombreLocalidad") = dr("NombreLocalidad")
            drCl("RecibeNotificaciones") = dr("RecibeNotificaciones")
            drCl("Direccion") = dr("Direccion")
            drCl("NivelAutorizacion") = dr("NivelAutorizacion")
            drCl("Alicuota2deProducto") = dr("Alicuota2deProducto")
            drCl(Entidades.TipoCliente.Columnas.IdTipoCliente.ToString()) = dr.Field(Of Integer)(Entidades.TipoCliente.Columnas.IdTipoCliente.ToString()).ToString()
            drCl(Entidades.TipoCliente.Columnas.NombreTipoCliente.ToString()) = dr.Field(Of String)(Entidades.TipoCliente.Columnas.NombreTipoCliente.ToString())
            drCl("PublicarEnWeb") = dr("PublicarEnWeb")
            drCl("LimiteDiasVtoFactura") = dr("LimiteDiasVtoFactura")
            drCl("LimiteDeCredito") = dr("LimiteDeCredito")
            drCl("NombreCategoriaFiscal") = dr("NombreCategoriaFiscal") '-.PE-31491.-
            dt.Rows.Add(drCl)

         Next

         Me.ugDetalle.DataSource = dt

         Me.tssRegistros.Text = Me.ugDetalle.Rows.Count & " Registros"

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      Finally
         Me.Cursor = Cursors.Default
      End Try

   End Sub

   Private Function CrearDT() As DataTable

      Dim dtTemp As DataTable = New DataTable()

      With dtTemp
         .Columns.Add("Selec", System.Type.GetType("System.Boolean"))
         .Columns.Add("IdCliente", System.Type.GetType("System.Int64"))
         .Columns.Add("CodigoCliente", System.Type.GetType("System.Int64"))
         .Columns.Add("NombreCliente", System.Type.GetType("System.String"))
         .Columns.Add("CUIT", System.Type.GetType("System.String"))
         .Columns.Add("NombreZonaGeografica", System.Type.GetType("System.String"))
         .Columns.Add("NombreCategoria", System.Type.GetType("System.String"))
         .Columns.Add("NombreListaPrecios", System.Type.GetType("System.String"))
         .Columns.Add("IdVendedor", System.Type.GetType("System.Int32"))
         .Columns.Add("NombreVendedor", System.Type.GetType("System.String"))
         .Columns.Add("DescripcionFormasPago", System.Type.GetType("System.String"))
         .Columns.Add("DescuentoRecargoPorc", System.Type.GetType("System.String"))
         .Columns.Add("Activo", System.Type.GetType("System.Boolean"))
         .Columns.Add("Descripcion", System.Type.GetType("System.String"))
         .Columns.Add("NombreCobrador", System.Type.GetType("System.String"))
         .Columns.Add("IdTransportista", GetType(Integer))
         .Columns.Add("NombreTransportista", GetType(String))
         .Columns.Add("NombreEstadoCliente", System.Type.GetType("System.String"))
         .Columns.Add("CantidadVisitas", GetType(Integer))
         .Columns.Add("NombreLocalidad", System.Type.GetType("System.String"))
         .Columns.Add("RecibeNotificaciones", System.Type.GetType("System.Boolean"))
         .Columns.Add("Direccion", System.Type.GetType("System.String"))
         .Columns.Add("NivelAutorizacion", System.Type.GetType("System.Int16"))
         .Columns.Add("Alicuota2deProducto", System.Type.GetType("System.String"))
         .Columns.Add(Entidades.TipoCliente.Columnas.IdTipoCliente.ToString(), GetType(Int32))
         .Columns.Add(Entidades.TipoCliente.Columnas.NombreTipoCliente.ToString(), GetType(String))
         .Columns.Add("PublicarEnWeb", System.Type.GetType("System.Boolean"))
         .Columns.Add("LimiteDiasVtoFactura", GetType(Int32))
         .Columns.Add("LimiteDeCredito", GetType(Decimal))
         .Columns.Add("NombreCategoriaFiscal", System.Type.GetType("System.String")) '-.PE-31491.-
      End With

      Return dtTemp

   End Function

   Private Sub AplicarCambios()

      Me._Clientes.Clear()

      Dim oVendedor As Entidades.Empleado = Nothing
      Dim IdZonaGeografica As String = String.Empty
      Dim IdCategoria As Integer = -1
      Dim IdListaDePrecios As Integer = -1
      Dim blnActivo As Boolean = Nothing
      Dim blnReciboNotificaciones As Boolean = Nothing
      Dim blnPublicarEnWeb As Boolean = Nothing
      Dim IdTipoComprobante As String = String.Empty
      Dim oCobrador As Entidades.Empleado = Nothing
      '    Dim IdCobrador As Integer = -1
      Dim IdEstado As Integer = -1
      Dim Idlocalidad As Integer = -1
      Dim idTipoCliente As Integer = -1
      Dim idCategoriaFiscal As Integer = -1


      If Me.chbNuevoTipoCliente.Checked Then
         idTipoCliente = Integer.Parse(Me.cmbNuevoTipoCliente.SelectedValue.ToString())
      End If

      If Me.chbNuevoVendedor.Checked Then
         oVendedor = DirectCast(Me.cmbNuevoVendedor.SelectedItem, Entidades.Empleado)
      End If

      If Me.chbNuevaZonaGeografica.Checked Then
         IdZonaGeografica = Me.cmbNuevaZonaGeografica.SelectedValue.ToString()
      End If

      If Me.chbNuevaCategoria.Checked Then
         IdCategoria = Integer.Parse(Me.cmbNuevaCategoria.SelectedValue.ToString())
      End If

      If Me.chbNuevaListaDePrecios.Checked Then
         IdListaDePrecios = Integer.Parse(Me.cmbNuevaListaDePrecios.SelectedValue.ToString())
      End If

      If Me.chbNuevoActivo.Checked Then
         blnActivo = Boolean.Parse(IIf(Me.cmbNuevoActivo.Text = "SI", "True", "False").ToString())
      End If

      If Me.chbNuevoRecibeNotificaciones.Checked Then
         blnReciboNotificaciones = Boolean.Parse(IIf(Me.cmbRecibeNotificaciones.Text = "SI", "True", "False").ToString())
      End If

      If Me.chbNuevoComprobante.Checked Then
         IdTipoComprobante = Me.cmbNuevoComprobante.SelectedValue.ToString()
      End If

      If Me.chbNuevoCobrador.Checked Then
         oCobrador = DirectCast(Me.cmbNuevoCobrador.SelectedItem, Entidades.Empleado)
      End If

      'If Me.chbNuevoCobrador.Checked Then
      '   IdCobrador = Integer.Parse(Me.cmbNuevoCobrador.SelectedValue.ToString())
      'End If

      If Me.chbNuevoEstado.Checked Then
         IdEstado = Integer.Parse(Me.cmbNuevoEstadoCliente.SelectedValue.ToString())
      End If
      If Me.chbNuevaLocalidad.Checked Then
         Idlocalidad = Integer.Parse(Me.bscNuevoCodigoLocalidad.Text)
      End If

      If Me.chbNuevoPublicaEnWeb.Checked Then
         blnPublicarEnWeb = Boolean.Parse(IIf(Me.cmbNuevoPublicaEnWeb.Text = "SI", "True", "False").ToString())
      End If

      '-.PE-31491.-
      If Me.chbNuevaCategoriaFiscal.Checked Then
         idCategoriaFiscal = Integer.Parse(Me.cmbNuevaCategoriaFiscal.SelectedValue.ToString())
      End If

      Dim oCliente As Entidades.Cliente

      For Each dr As UltraGridRow In Me.ugDetalle.Rows

         If dr.Cells("Selec").Value IsNot Nothing Then

            If Boolean.Parse(dr.Cells("Selec").Value.ToString()) Then

               oCliente = New Entidades.Cliente()

               With oCliente
                  .IdCliente = Long.Parse(dr.Cells("IdCliente").Value.ToString())
                  .IdCategoria = IdCategoria
                  .ZonaGeografica.IdZonaGeografica = IdZonaGeografica
                  .IdListaPrecios = IdListaDePrecios
                  .Vendedor = oVendedor
                  .IdCategoriaFiscal = idCategoriaFiscal


                  If Me.chbNuevaFormaPago.Checked Then
                     .IdFormasPago = Integer.Parse(Me.cmbNuevaFormaPago.SelectedValue.ToString())
                  End If

                  If Me.chbNuevoDescuentoRecargo.Checked Then
                     .CambioDescuentoRecargoPorc = True
                     .DescuentoRecargoPorc = Decimal.Parse(Me.txtNuevoDescuentoRecargoPorc.Text)
                  End If

                  If Me.chbNuevoActivo.Checked Then
                     .Activo = blnActivo
                  Else
                     .Activo = Boolean.Parse(dr.Cells("Activo").Value.ToString())
                  End If
                  .IdTipoComprobante = IdTipoComprobante
                  If Me.chbNuevoCobrador.Checked Then
                     .Cobrador = oCobrador
                  End If
                  If Me.chbNuevoEstado.Checked Then
                     .EstadoCliente = New Reglas.EstadosClientes().GetUno(IdEstado)
                  End If

                  If chbNuevaCantidadVisitas.Checked Then
                     .CantidadVisitas = Integer.Parse(txtNuevaCantidadVisitas.Text)
                  Else
                     .CantidadVisitas = -1
                  End If
                  If chbNuevaLocalidad.Checked Then
                     .Localidad = New Reglas.Localidades().GetUna(Idlocalidad)
                  End If
                  If Me.chbNuevoRecibeNotificaciones.Checked Then
                     .RecibeNotificaciones = blnReciboNotificaciones
                  Else
                     .RecibeNotificaciones = Boolean.Parse(dr.Cells("RecibeNotificaciones").Value.ToString())
                  End If

                  If Me.chbNuevoNivelAutorizacion.Checked Then
                     .NivelAutorizacion = Short.Parse(Me.txtNuevoNivelAutorizacion.Text)
                  Else
                     .NivelAutorizacion = Short.Parse(dr.Cells("NivelAutorizacion").Value.ToString())
                  End If

                  If chbNuevoTransportista.Checked Then
                     .IdTransportista = Integer.Parse(cmbNuevoTransportista.SelectedValue.ToString())
                     'Else
                     '   .IdTransportista = Integer.Parse(dr.Cells("IdTransportista").Value.ToString())
                  End If

                  ' # Tipo de Cliente
                  .TipoCliente.IdTipoCliente = If(idTipoCliente <> -1, idTipoCliente, -1)

                  If Me.chbNuevoAlicuota2deProducto.Checked Then
                     .Alicuota2deProducto = DirectCast([Enum].Parse(GetType(Entidades.Cliente.Alicuota2DeProductoSegun), Me.CmbNuevoAlicuota2deProducto.SelectedValue.ToString()), Entidades.Cliente.Alicuota2DeProductoSegun)
                  Else
                     .Alicuota2deProducto = DirectCast([Enum].Parse(GetType(Entidades.Cliente.Alicuota2DeProductoSegun), dr.Cells("Alicuota2deProducto").Value.ToString()), Entidades.Cliente.Alicuota2DeProductoSegun)
                  End If

                  If Me.chbNuevoPublicaEnWeb.Checked Then
                     .PublicarEnWeb = blnPublicarEnWeb
                  Else
                     .PublicarEnWeb = Boolean.Parse(dr.Cells("PublicarEnWeb").Value.ToString())
                  End If

                  If Me.chbNuevoDiasLimiteVtoFact.Checked Then
                     .LimiteDiasVtoFactura = Integer.Parse(Me.txtNuevoLimiteDiasVtoFactura.Text)
                  Else
                     .LimiteDiasVtoFactura = Integer.Parse(dr.Cells("LimiteDiasVtoFactura").Value.ToString())
                  End If

                  If Me.chbNuevoLimiteCredito.Checked Then
                     .LimiteDeCredito = Decimal.Parse(Me.txtNuevoLimiteDeCredito.Text)
                  Else
                     .LimiteDeCredito = Decimal.Parse(dr.Cells("LimiteDeCredito").Value.ToString())
                  End If

               End With

               Me._Clientes.Add(oCliente)

            End If
         End If
      Next

      If Me._Clientes.Count > 0 Then
         If MessageBox.Show("¿ Está Seguro de cambiar datos a " & Me._Clientes.Count.ToString() & " Cliente(s) ? ", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) <> Windows.Forms.DialogResult.Yes Then
            Exit Sub
         End If
         Dim regClientes As Reglas.Clientes = New Reglas.Clientes()
         regClientes.ActualizacionMasiva(Me._Clientes)
         MessageBox.Show("Se Cambió Exitosamente " & Me._Clientes.Count.ToString() & " Cliente(s) !!", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
         Me.btnConsultar_Click(Me.btnConsultar, New EventArgs())
      Else
         MessageBox.Show("ATENCION: No Marcó Ningún Cliente !!", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
      End If

   End Sub

   Private Sub CargarLocalidad(ByVal dr As DataGridViewRow)
      Me.bscNuevoCodigoLocalidad.Text = dr.Cells("IdLocalidad").Value.ToString()
      Me.bscNuevoNombreLocalidad.Text = dr.Cells("NombreLocalidad").Value.ToString()
      Me.bscNuevoNombreLocalidad.Enabled = False
      Me.bscNuevoCodigoLocalidad.Enabled = False
   End Sub

#End Region

#Region "Marcar/Desmarcar Todos"
   Private Sub btnTodos_Click(sender As Object, e As EventArgs) Handles btnTodos.Click
      TryCatched(Sub() ugDetalle.MarcarDesmarcar(cmbTodos, "Selec"))
   End Sub
#End Region


End Class