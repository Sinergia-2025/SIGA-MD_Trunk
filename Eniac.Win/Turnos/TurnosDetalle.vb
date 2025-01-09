Public Class TurnosDetalle
   Private _publicos As Publicos
   Private _categoriaFiscalEmpresa As Entidades.CategoriaFiscal
   Private _calculaDescuentoRecargo2 As Boolean

   Private _buscaVehiculos As Boolean = False

   Private _dtEmbarcaciones As DataTable
   Private _tit As Dictionary(Of String, String)

   Public Property Turno As Entidades.TurnoCalendario
   Public Property Turnos As List(Of Entidades.TurnoCalendario)
   Public Property StateForm As StateForm

   Private Property Calendario As Entidades.Calendario
   Private Property LapsoActual As Integer



#Region "Constructores"

   Public Sub New()
      ' This call is required by the Windows Form Designer.
      InitializeComponent()
   End Sub
   Public Sub New(entidad As Entidades.TurnoCalendario, turnos As List(Of Entidades.TurnoCalendario), stateForm As StateForm)
      Me.New()
      Turno = entidad
      Me.Turnos = turnos
      Me.StateForm = stateForm
   End Sub

#End Region

#Region "Overrides"
   Protected Overrides Sub OnLoad(e As System.EventArgs)
      Try
         _tit = GetColumnasVisiblesGrilla(ugEmbarcaciones)
      Catch ex As Exception
         ShowError(ex)
      End Try

      MyBase.OnLoad(e)

      Try
         _publicos = New Publicos()

         Calendario = New Reglas.Calendarios().GetUno(Turno.IdCalendario)


         _publicos.CargaComboTiposTurnos(cmbTipoTurno, Calendario.IdTipoCalendario)

         _publicos.CargaComboEstadosTurnos(cmbEstadosTurnos)
         _publicos.CargaComboDestinos(Me.cmbDestinos)

         _categoriaFiscalEmpresa = New Reglas.CategoriasFiscales().GetUno(Reglas.Publicos.CategoriaFiscalEmpresa)
         _calculaDescuentoRecargo2 = Not Reglas.Publicos.Facturacion.FacturacionDescuentoRecargo2CargaManual


         Me.txtSesion.Visible = Calendario.UtilizaSesion
         Me.lblSesion.Visible = Calendario.UtilizaSesion

         pnlEmbarcaciones.Visible = Calendario.SolicitaEmbarcacion
         pnlEmbarcacionesBotado.Visible = Calendario.SolicitaBotado

         '-- REQ-33401.- -----------------------------------------
         pnlSolicitaVehiculo.Visible = Calendario.SolicitaVehiculo
         '--------------------------------------------------------

         If Calendario.UtilizaZonas Then
            txtSesion.Visible = False
            lblSesion.Visible = False
            Me.pnlProductoZona.Visible = Calendario.UtilizaZonas
         End If

         If Not Calendario.SolicitaEmbarcacion Then
            Me.Width = 535
         End If
         '-- REQ-33401.- -----------------------------------
         flpTurnos.Height = pnlClienteTurno.Height + (If(pnlSolicitaVehiculo.Visible, pnlSolicitaVehiculo.Height, If(pnlProductoZona.Visible, 0, 28))) + pnlDatosTurno.Height + (If(pnlProductoZona.Visible, pnlProductoZona.Height, 0)) + 10
         Me.Height = flpTurnos.Height + 80
         '--------------------------------------------------


         MuestraProductoDescuentoRecargoPrecios(Reglas.Publicos.TurnosPermiteFacturarDesdeCalendario)

         If Me.StateForm = Eniac.Win.StateForm.Insertar Then

            'dtpHoraDesde.Value = Now
            'dtpHoraHasta.Value = Now.AddMinutes(Calendario.LapsoPorDefecto)
            dtpHoraDesde.Value = Turno.FechaDesde
            dtpHoraHasta.Value = Turno.FechaHasta
            cmbTipoTurno.SelectedValue = Reglas.Publicos.TurnosTipoBase
            cmbEstadosTurnos.SelectedValue = Reglas.Publicos.TurnosEstadoBase

            chbProducto.Checked = Not String.IsNullOrWhiteSpace(Calendario.IdProducto)
            If Not String.IsNullOrWhiteSpace(Calendario.IdProducto) Then
               bscCodigoProducto2.Text = Calendario.IdProducto
               bscCodigoProducto2.PresionarBoton()
            End If

            chbProducto.Checked = False
            chbProducto.Enabled = False
            bscCodigoCliente.Focus()
         Else
            '-- Oculta la ecla de Imprimir.- --
            btnImprimir.Visible = Calendario.PermiteImpresion
            '----------------------------------

            bscCodigoCliente.Text = Turno.CodigoCliente.ToString()
            bscCodigoCliente.PresionarBoton()

            '-- REQ-36030.- --------------------------------------
            CargaTurnoVehiculoInactivo(Turno.IdPatenteVehiculo.ToString())
            '------------------------------------------------------
            dtpHoraDesde.Value = Turno.FechaDesde
            dtpHoraHasta.Value = Turno.FechaHasta
            txtObservacion.Text = Turno.Observaciones
            cmbTipoTurno.SelectedValue = Turno.IdTipoTurno
            cmbEstadosTurnos.SelectedValue = Turno.IdEstadoTurno
            ' chbEfectivo.Checked = Turno.EsEfectivo

            chbProducto.Checked = Not String.IsNullOrWhiteSpace(Turno.IdProducto)
            bscCodigoProducto2.Text = Turno.IdProducto
            bscCodigoProducto2.PresionarBoton()

            txtPrecioLista.Text = If(Turno.PrecioLista.HasValue, Turno.PrecioLista.Value.ToString(), "0.00")
            txtPrecio.Text = If(Turno.Precio.HasValue, Turno.Precio.Value.ToString(), "0.00")
            txtDescRecGralPorc.Text = If(Turno.DescuentoRecargoPorcGral.HasValue, Turno.DescuentoRecargoPorcGral.Value.ToString(), "0.00")
            txtDescRecPorc1.Text = If(Turno.DescuentoRecargoPorc1.HasValue, Turno.DescuentoRecargoPorc1.Value.ToString(), "0.00")
            txtDescRecPorc2.Text = If(Turno.DescuentoRecargoPorc2.HasValue, Turno.DescuentoRecargoPorc2.Value.ToString(), "0.00")
            txtPrecioNeto.Text = If(Turno.PrecioNeto.HasValue, Turno.PrecioNeto.Value.ToString(), "0.00")
            txtSesion.Text = Turno.NumeroSesion.ToString()
            bscCodigoCliente.Focus()

            If Calendario.SolicitaEmbarcacion Then
               For Each dr As UltraGridRow In ugEmbarcaciones.Rows.GetAllNonGroupByRows()
                  If IsNumeric(dr.Cells("IdEmbarcacion").Value) AndAlso
                     Long.Parse(dr.Cells("IdEmbarcacion").Value.ToString()) = Turno.IdEmbarcacion Then
                     ugEmbarcaciones.ActiveRow = dr
                     Exit For
                  End If
               Next

               If Calendario.SolicitaBotado Then
                  txtCantidadPasajeros.Text = Turno.CantidadPasajeros.ToString()
                  cmbDestinos.SelectedValue = Turno.IdDestino
                  txtDestinoLibre.Text = Turno.DestinoLibre
                  If Turno.FechaHoraLlegada.HasValue Then
                     dtpFechaHoraLlegada.Value = Turno.FechaHoraLlegada.Value
                  Else
                     dtpFechaHoraLlegada.Value = Today
                  End If

               End If
            End If

            btnAceptar.Visible = New Reglas.TurnosCalendarios().PuedeEditar(Calendario.IdCalendario)

         End If

         dtpHoraHasta.Enabled = Not Calendario.LapsoPorDefectoFijo

         ugProductoZonas.DataSource = Turno.TurnoProducto
         FormatearGrilla()

      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

#End Region

#Region "Eventos"

   Private Sub bscCodigoVehiculo_BuscadorClick() Handles bscCodigoVehiculo.BuscadorClick
      Dim codigoVehiculo As String = ""
      Try
         Me.Cursor = Cursors.WaitCursor
         Me._publicos.PreparaGrillaVehiculos2(Me.bscCodigoVehiculo)
         codigoVehiculo = Me.bscCodigoVehiculo.Text.Trim()
         If _buscaVehiculos Then
            bscCodigoVehiculo.Datos = New Reglas.Vehiculos().GetFiltradoPorCliente(Long.Parse(bscCodigoCliente.Text), True)
            _buscaVehiculos = False
         Else
            bscCodigoVehiculo.Datos = New Reglas.Vehiculos().GetFiltradoPorPatente(codigoVehiculo, True)
         End If
      Catch ex As Exception
         ShowError(ex)
      Finally
         Me.Cursor = Cursors.Default
      End Try
   End Sub

   Private Sub bscCodigoVehiculo_BuscadorSeleccion(sender As Object, e As Controles.BuscadorEventArgs) Handles bscCodigoVehiculo.BuscadorSeleccion
      Try
         Me.Cursor = Cursors.WaitCursor
         If Not e.FilaDevuelta Is Nothing Then
            Me.CargarDatosVehiculos(e.FilaDevuelta)
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      Finally
         Me.Cursor = Cursors.Default
      End Try

   End Sub

   Private Sub CargarDatosVehiculos(dr As DataGridViewRow)
      bscCodigoVehiculo.Text = dr.Cells(Entidades.Vehiculo.Columnas.PatenteVehiculo.ToString()).Value.ToString().Trim()
      txtMarcaVehiculo.Text = dr.Cells("NombreMarcaVehiculo").Value.ToString().Trim()
      txtModeloVehiculo.Text = dr.Cells("NombreModeloVehiculo").Value.ToString().Trim()

      Dim v = New Reglas.Vehiculos().GetUno(dr.Cells(Entidades.Vehiculo.Columnas.PatenteVehiculo.ToString()).Value.ToString().Trim())
      If v.Clientes.Count = 1 Then
         bscCodigoCliente.Text = v.Clientes(0).CodigoCliente.ToString()
         bscCodigoCliente.PresionarBoton()
      End If
   End Sub


   Private Sub bscCodigoCliente_BuscadorClick() Handles bscCodigoCliente.BuscadorClick
      Dim codigoCliente As Long = -1
      Try
         Me.Cursor = Cursors.WaitCursor
         Me._publicos.PreparaGrillaClientes2(Me.bscCodigoCliente)
         If IsNumeric(Me.bscCodigoCliente.Text) Then codigoCliente = Long.Parse(Me.bscCodigoCliente.Text.Trim())
         Me.bscCodigoCliente.Datos = New Reglas.Clientes().GetFiltradoPorCodigo(codigoCliente, True, True)
      Catch ex As Exception
         ShowError(ex)
      Finally
         Me.Cursor = Cursors.Default
      End Try
   End Sub

   Private Sub bscCodigoCliente_BuscadorSeleccion(sender As Object, e As Controles.BuscadorEventArgs) Handles bscCodigoCliente.BuscadorSeleccion, bscCliente.BuscadorSeleccion
      Try
         Me.Cursor = Cursors.WaitCursor
         If Not e.FilaDevuelta Is Nothing Then
            Me.CargarDatosCliente(e.FilaDevuelta)
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      Finally
         Me.Cursor = Cursors.Default
      End Try
   End Sub

   Private Sub bscCliente_BuscadorClick() Handles bscCliente.BuscadorClick
      Try
         Me.Cursor = Cursors.WaitCursor
         Me._publicos.PreparaGrillaClientes2(Me.bscCliente)
         Me.bscCliente.Datos = New Reglas.Clientes().GetFiltradoPorNombre(Me.bscCliente.Text.Trim(), True)
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
      Finally
         Me.Cursor = Cursors.Default
      End Try
   End Sub

   Private Sub btnAceptar_Click(sender As Object, e As EventArgs) Handles btnAceptar.Click
      Try
         Aceptar()
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

   Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
      DialogResult = Windows.Forms.DialogResult.Cancel
      Close()
   End Sub

   Private Sub dtpHoraDesde_Enter(sender As Object, e As EventArgs) Handles dtpHoraDesde.Enter
      LapsoActual = Convert.ToInt32(dtpHoraHasta.Value.Subtract(dtpHoraDesde.Value).TotalMinutes)
   End Sub

   Private Sub dtpHoraDesde_ValueChanged(sender As Object, e As EventArgs) Handles dtpHoraDesde.ValueChanged
      dtpHoraHasta.Value = dtpHoraDesde.Value.AddMinutes(LapsoActual)
   End Sub

   Private Sub txtNroSesion_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtNroSesion.KeyPress
      PresionarTab(e)
   End Sub

   Private Sub txtFluencia_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtFluencia.KeyPress
      PresionarTab(e)
   End Sub

   Private Sub ugProductoZonas_DoubleClickRow(sender As Object, e As DoubleClickRowEventArgs) Handles ugProductoZonas.DoubleClickRow
      Try
         Dim row As Entidades.TurnosCalendariosProductos = GetTurnosProductos()
         If row IsNot Nothing Then
            If Not String.IsNullOrWhiteSpace(row.IdProducto) Then
               bscCodigoZona.Text = row.IdProducto
               bscCodigoZona.PresionarBoton()
               txtNroSesion.Text = row.NumeroSesion.ToString()
               txtFluencia.Text = row.ValorFluencia.ToString()
               Turno.TurnoProducto.Remove(row)
               ugProductoZonas.Rows.Refresh(RefreshRow.ReloadData)
               txtNroSesion.Focus()
            End If
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub


#Region "Eventos Buscadores"
   Private Sub bscCodigoProducto2_BuscadorClick() Handles bscCodigoProducto2.BuscadorClick
      Try
         Dim oProductos As Eniac.Reglas.Productos = New Eniac.Reglas.Productos
         Me._publicos.PreparaGrillaProductos2(Me.bscCodigoProducto2)
         Me.bscCodigoProducto2.Datos = oProductos.GetPorCodigo(Me.bscCodigoProducto2.Text.Trim(), actual.Sucursal.Id, Publicos.ListaPreciosPredeterminada, "TODOS")
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub bscCodigoProducto2_BuscadorSeleccion(sender As Object, e As Controles.BuscadorEventArgs) Handles bscCodigoProducto2.BuscadorSeleccion
      Try
         If Not e.FilaDevuelta Is Nothing Then
            Me.CargarProducto(e.FilaDevuelta)
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub bscProducto2_BuscadorClick() Handles bscProducto2.BuscadorClick
      Try
         Dim oProductos As Eniac.Reglas.Productos = New Eniac.Reglas.Productos
         Me._publicos.PreparaGrillaProductos2(Me.bscProducto2)
         Me.bscProducto2.Datos = oProductos.GetPorNombre(Me.bscProducto2.Text.Trim(), actual.Sucursal.Id, Publicos.ListaPreciosPredeterminada, "TODOS")
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub bscProducto2_BuscadorSeleccion(sender As Object, e As Controles.BuscadorEventArgs) Handles bscProducto2.BuscadorSeleccion
      Try
         If Not e.FilaDevuelta Is Nothing Then
            Me.CargarProducto(e.FilaDevuelta)
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub chbProducto_CheckedChanged(sender As Object, e As EventArgs) Handles chbProducto.CheckedChanged
      Try
         HabilitaProductoDescuentoRecargoPrecios(chbProducto.Checked)
         If chbProducto.Checked Then
            bscCodigoProducto2.Focus()
         End If
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

   Private Sub txtPrecio_Leave(sender As Object, e As EventArgs) Handles txtPrecio.Leave
      Try
         RecalculaPrecioNeto()
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

   Private Sub txtDescRecGralPorc_Leave(sender As Object, e As EventArgs) Handles txtDescRecGralPorc.Leave
      Try
         RecalculaPrecioNeto()
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

   Private Sub txtDescRecPorc1_Leave(sender As Object, e As EventArgs) Handles txtDescRecPorc1.Leave
      Try
         RecalculaPrecioNeto()
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

   Private Sub txtDescRecPorc2_Leave(sender As Object, e As EventArgs) Handles txtDescRecPorc2.Leave
      Try
         RecalculaPrecioNeto()
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

   Private Sub bscCodigoZona_BuscadorClick() Handles bscCodigoZona.BuscadorClick
      Try
         Dim oProductos As Eniac.Reglas.Productos = New Eniac.Reglas.Productos
         Me._publicos.PreparaGrillaProductos2(Me.bscCodigoZona)
         Dim rubro As Integer = Reglas.Publicos.TurnosProductoZona
         Me.bscCodigoZona.Datos = oProductos.GetPorCodigo(Me.bscCodigoZona.Text.Trim(), actual.Sucursal.Id, Publicos.ListaPreciosPredeterminada, "TODOS", False, "Normal", False, Entidades.Producto.TiposOperaciones.NORMAL, Nothing, True, True, rubro)
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub
   Private Sub bscCodigoZona_BuscadorSeleccion(sender As Object, e As Controles.BuscadorEventArgs) Handles bscCodigoZona.BuscadorSeleccion
      Try
         If Not e.FilaDevuelta Is Nothing Then
            Me.CargarZonas(e.FilaDevuelta)
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub
   Private Sub bscZonas_BuscadorClick() Handles bscZonas.BuscadorClick
      Try
         Dim oProductos As Eniac.Reglas.Productos = New Eniac.Reglas.Productos
         Me._publicos.PreparaGrillaProductos2(Me.bscZonas)
         Dim rubro As Integer = Reglas.Publicos.TurnosProductoZona
         Me.bscZonas.Datos = oProductos.GetPorNombre(Me.bscZonas.Text.Trim(), actual.Sucursal.Id, Publicos.ListaPreciosPredeterminada, "TODOS", False, False, Entidades.Producto.TiposOperaciones.NORMAL, Nothing, True, True, rubro)
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub
   Private Sub bscZonas_BuscadorSeleccion(sender As Object, e As Controles.BuscadorEventArgs) Handles bscZonas.BuscadorSeleccion
      Try
         If Not e.FilaDevuelta Is Nothing Then
            Me.CargarZonas(e.FilaDevuelta)
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub btnInsertar_Click(sender As Object, e As EventArgs) Handles btnInsertar.Click
      Try
         If Not Me.bscCodigoZona.Selecciono And Not Me.bscZonas.Selecciono Then
            MessageBox.Show("Debe seleccionar una Zona.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.bscCodigoZona.Focus()
            Return
         End If
         If String.IsNullOrEmpty(Me.bscCodigoZona.Text) Or String.IsNullOrEmpty(Me.bscZonas.Text) Then
            MessageBox.Show("Debe seleccionar un Zona.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.bscCodigoZona.Focus()
            Return
         End If
         If String.IsNullOrEmpty(Me.txtNroSesion.Text) Then
            MessageBox.Show("Ingrese un valor valido de número de Sesión", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.txtNroSesion.Focus()
            Return
         End If
         If Integer.Parse(Me.txtNroSesion.Text) < 1 Then
            MessageBox.Show("Ingrese un valor valido de número de Sesión", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.txtSesion.Focus()
            Return
         End If
         If String.IsNullOrEmpty(Me.txtFluencia.Text) Then
            MessageBox.Show("Ingrese un valor valido de Fluencia", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.txtFluencia.Focus()
            Return
         End If
         If Integer.Parse(Me.txtFluencia.Text) < 0 Then
            MessageBox.Show("Ingrese un valor valido de Fluencia", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.txtFluencia.Focus()
            Return
         End If

         For Each existeZona As Entidades.TurnosCalendariosProductos In Turno.TurnoProducto
            If existeZona.IdProducto = bscCodigoZona.Text Then
               Throw New Exception("La Zona seleccionada ya se encuentra en la colección.")
               bscCodigoZona.Focus()
            End If
         Next

         InsertarProductosTurnos()

         Me.bscCodigoZona.Text = ""
         Me.bscZonas.Text = ""
         Me.txtNroSesion.Text = ""
         Me.txtFluencia.Text = ""
         bscCodigoZona.Focus()

      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

   Private Sub btnInsertar_KeyPress(sender As Object, e As KeyPressEventArgs) Handles btnInsertar.KeyPress
      PresionarTab(e)
   End Sub

   Private Sub btnEliminar_Click(sender As Object, e As EventArgs) Handles btnEliminar.Click
      Try
         Dim _turnosProductos As Entidades.TurnosCalendariosProductos = GetTurnosProductos()
         If _turnosProductos IsNot Nothing Then
            Turno.TurnoProducto.Remove(_turnosProductos)
            Me.ugProductoZonas.Rows.Refresh(UltraWinGrid.RefreshRow.ReloadData)
         End If
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

#End Region

#End Region

#Region "Metodos"
   ''' <summary>
   ''' Muestra los datos de un vehiculo desactivado pero presente en turno.-
   ''' </summary>
   ''' <param name="codPatente">Patente del Vehiculo</param>
   Private Sub CargaTurnoVehiculoInactivo(codPatente As String)
      Dim Vehiculo = New Reglas.Vehiculos().GetUno(codPatente)

      _buscaVehiculos = False

      bscCodigoVehiculo.Text = Vehiculo.PatenteVehiculo
      txtMarcaVehiculo.Text = Vehiculo.DescripMarcaVehiculo
      txtModeloVehiculo.Text = Vehiculo.DescripModeloVehiculo

   End Sub

   Protected Overridable Sub CargarDatosCliente(dr As DataGridViewRow)
      Me.bscCliente.Text = dr.Cells(Entidades.Cliente.Columnas.NombreCliente.ToString()).Value.ToString()
      Me.bscCodigoCliente.Text = dr.Cells(Entidades.Cliente.Columnas.CodigoCliente.ToString()).Value.ToString().Trim()
      Me.bscCodigoCliente.Tag = dr.Cells(Entidades.Cliente.Columnas.IdCliente.ToString()).Value.ToString()
      Me.bscCliente.Tag = New Reglas.Clientes().GetUno(Long.Parse(dr.Cells(Entidades.Cliente.Columnas.IdCliente.ToString()).Value.ToString()))

      chbProducto.Enabled = True
      If bscCodigoProducto2.Visible And (bscCodigoProducto2.Selecciono Or bscProducto2.Selecciono) Then
         chbProducto.Checked = True
         If Not String.IsNullOrWhiteSpace(bscCodigoProducto2.Text) Then
            bscCodigoProducto2.PresionarBoton()
         End If
      End If

      If Calendario.SolicitaEmbarcacion Then
         Me.CargarEmbarcaciones()
      End If

      If Calendario.SolicitaVehiculo Then
         _buscaVehiculos = True
      End If
      'If _dtEmbarcaciones.Rows.Count = 0 Then
      '   Throw New Exception("El Cliente seleccionado NO tiene Embarcaciones Asociadas.")
      'End If

   End Sub

   Private Sub CargarEmbarcaciones()
      Try
         Dim embar = New Reglas.Embarcaciones()

         _dtEmbarcaciones = embar.GetPorCodigoCliente(Long.Parse(Me.bscCodigoCliente.Text), String.Empty, Nothing)
         Me.ugEmbarcaciones.DataSource = _dtEmbarcaciones
         AjustarColumnasGrilla(ugEmbarcaciones, _tit)

         If Me.ugEmbarcaciones.Rows.Count > 0 Then
            Me.ugEmbarcaciones.ActiveRow = Me.ugEmbarcaciones.Rows(0)
         End If

      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub


   Private Sub Aceptar()
      If Validar() Then

         Turno.IdCliente = DirectCast(bscCliente.Tag, Entidades.Cliente).IdCliente
         Turno.CodigoCliente = DirectCast(bscCliente.Tag, Entidades.Cliente).CodigoCliente
         Turno.NombreCliente = DirectCast(bscCliente.Tag, Entidades.Cliente).NombreCliente
         Turno.FechaDesde = dtpHoraDesde.Value
         Turno.FechaHasta = dtpHoraHasta.Value
         Turno.Observaciones = txtObservacion.Text
         Turno.IdTipoTurno = DirectCast(cmbTipoTurno.SelectedItem, Entidades.TipoTurno).IdTipoTurno
         Turno.IdEstadoTurno = DirectCast(cmbEstadosTurnos.SelectedItem, Entidades.EstadoTurno).IdEstadoTurno
         ' Turno.EsEfectivo = chbEfectivo.Checked

         If Not chbProducto.Checked Then
            Turno.IdProducto = String.Empty
            Turno.PrecioLista = Nothing
            Turno.Precio = Nothing
            Turno.DescuentoRecargoPorcGral = Nothing
            Turno.DescuentoRecargoPorc1 = Nothing
            Turno.DescuentoRecargoPorc2 = Nothing
            Turno.PrecioNeto = Nothing
         Else
            Turno.IdProducto = bscCodigoProducto2.Text
            Turno.PrecioLista = If(IsNumeric(txtPrecioLista.Text), Decimal.Parse(txtPrecioLista.Text), 0)
            Turno.Precio = If(IsNumeric(txtPrecio.Text), Decimal.Parse(txtPrecio.Text), 0)
            Turno.DescuentoRecargoPorcGral = If(IsNumeric(txtDescRecGralPorc.Text), Decimal.Parse(txtDescRecGralPorc.Text), 0)
            Turno.DescuentoRecargoPorc1 = If(IsNumeric(txtDescRecPorc1.Text), Decimal.Parse(txtDescRecPorc1.Text), 0)
            Turno.DescuentoRecargoPorc2 = If(IsNumeric(txtDescRecPorc2.Text), Decimal.Parse(txtDescRecPorc2.Text), 0)
            Turno.PrecioNeto = If(IsNumeric(txtPrecioNeto.Text), Decimal.Parse(txtPrecioNeto.Text), 0)
         End If
         Turno.NumeroSesion = Integer.Parse(Me.txtSesion.Text)

         If Calendario.SolicitaEmbarcacion Then
            Dim drEmbarcacion = ugEmbarcaciones.FilaSeleccionada(Of DataRow)()
            Dim idEmbarcacion = Long.Parse(drEmbarcacion("IdEmbarcacion").ToString())

            Dim embarcacion = New Reglas.Embarcaciones().GetUnoLiviano(idEmbarcacion)

            Turno.IdEmbarcacion = embarcacion.IdEmbarcacion
            Turno.CodigoEmbarcacion = embarcacion.CodigoEmbarcacion
            Turno.NombreEmbarcacion = embarcacion.NombreEmbarcacion

            If Calendario.SolicitaBotado Then
               Turno.CantidadPasajeros = txtCantidadPasajeros.ValorNumericoPorDefecto(0I)
               Turno.IdDestino = cmbDestinos.ValorSeleccionado(Of Short)()
               Turno.DestinoLibre = txtDestinoLibre.Text
               Turno.FechaHoraLlegada = dtpFechaHoraLlegada.Value

            End If

         End If

         If Calendario.SolicitaVehiculo Then
            Turno.IdPatenteVehiculo = bscCodigoVehiculo.Text
         End If


         AceptarDatosAdicionales()


         If Me.StateForm = Eniac.Win.StateForm.Insertar And Calendario.PermiteImpresion Then
            ImprimeTicketTurno()
         End If

         DialogResult = Windows.Forms.DialogResult.OK
         Close()
      End If
   End Sub

   Protected Overridable Sub AceptarDatosAdicionales()

   End Sub

   Protected Overridable Function ValidarDatosAdicionales() As Boolean
      Return True
   End Function

   Private Function Validar() As Boolean

      If Me.bscCodigoCliente.Text.Trim().Length = 0 Then
         ShowMessage("Falta cargar el Código del cliente.")
         Me.bscCodigoCliente.Focus()
         Return False
      End If
      If Me.bscCliente.Text.Trim().Length = 0 Then
         ShowMessage("Falta cargar el Nombre del cliente.")
         Me.bscCliente.Focus()
         Return False
      End If

      If bscCliente.Tag Is Nothing Then
         ShowMessage("Falta seleccionar un cliente.")
         Me.bscCodigoCliente.Focus()
         Return False
      End If

      If DirectCast(bscCliente.Tag, Entidades.Cliente).CodigoCliente <> Long.Parse(bscCodigoCliente.Text) Then
         bscCodigoCliente.PresionarBoton()
         Return Validar()
      End If
      If Not Calendario.UtilizaZonas Then
         If Calendario.UtilizaSesion Then
            If Me.txtSesion.Text = "0" Then
               ShowMessage("Falta ingresar el Numero de Sesion.")
               Me.txtSesion.Focus()
               Return False
            End If
         End If
      End If

      If cmbTipoTurno.SelectedIndex < 0 Then
         ShowMessage("Falta seleccionar un tipo de turno.")
         Me.cmbTipoTurno.Focus()
         Return False
      End If

      If cmbEstadosTurnos.SelectedIndex < 0 Then
         ShowMessage("Falta seleccionar un estado de turno.")
         Me.cmbEstadosTurnos.Focus()
         Return False
      End If

      If dtpHoraHasta.Value < dtpHoraDesde.Value Then
         ShowMessage("La fecha Hasta debe ser superior a la fecha Desde.")
         Me.dtpHoraHasta.Focus()
         Return False
      End If

      If Not ControlaCupoDisponible(Turnos, Turno, dtpHoraDesde.Value, dtpHoraHasta.Value, Calendario.Cupo) Then
         If ShowPregunta("El cupo está completo para este rando de hora. ¿Desea ingresar un sobreturno?") = Windows.Forms.DialogResult.No Then
            dtpHoraHasta.Focus()
            Return False
         End If
      End If

      Dim maxDate As DateTime = Today.AddDays(Calendario.DiasHabilitacionReserva)
      If dtpHoraDesde.Value.Date > maxDate Then
         ShowMessage(String.Format("No puede hacer una reserva con tanta anticipación. La fecha máxima para reservar hoy es {0:dd/MM/yyyy}", maxDate))
         Me.dtpHoraDesde.Focus()
         Return False
      End If

      If chbProducto.Checked Then
         If Not bscCodigoProducto2.Selecciono And Not bscProducto2.Selecciono Then
            ShowMessage("Falta seleccionar un producto.")
            Me.bscCodigoProducto2.Focus()
            Return False
         End If
      End If

      'For Each turExistente As Entidades.TurnoCalendario In Turnos
      '   If Not turExistente.Equals(Turno) Then
      '      If turExistente.FechaDesde < dtpHoraHasta.Value And turExistente.FechaHasta > dtpHoraDesde.Value Then
      '         If Not ShowPregunta(String.Format("El período para el turno se superpone con el turno de {1} ({0}) de {2:dd/MM/yyyy HH:mm} a {3:dd/MM/yyyy HHmm}.",
      '                                           turExistente.CodigoCliente, turExistente.NombreCliente,
      '                                           turExistente.FechaDesde, turExistente.FechaHasta)) = Windows.Forms.DialogResult.Yes Then
      '            Me.dtpHoraHasta.Focus()
      '            Return False
      '         End If
      '      End If
      '   End If
      'Next

      If Calendario.SolicitaEmbarcacion Then

         Dim drEmbarcacion As DataRow = ugEmbarcaciones.FilaSeleccionada(Of DataRow)()
         If drEmbarcacion Is Nothing Then
            ShowMessage("Debe seleccionar una embarcación.")
            Me.ugEmbarcaciones.Focus()
            Return False
         End If

         If Not Calendario.SolicitaBotado Then
            If Me.cmbTipoTurno.SelectedValue.ToString() = Reglas.Publicos.SiSeN.TipoTurnoParaRecepcion Then
               If drEmbarcacion("Estado").ToString() <> Entidades.Embarcacion.Estados.ALTA.ToString() And
                  drEmbarcacion("Estado").ToString() <> Entidades.Embarcacion.Estados.SALIDA.ToString() Then
                  ShowMessage("ATENCION: El Estado de la Embarcación NO Permite la Recepción.")
                  Me.ugEmbarcaciones.Focus()
                  Return False
               End If
            ElseIf Me.cmbTipoTurno.SelectedValue.ToString() = Reglas.Publicos.SiSeN.TipoTurnoParaSalida Then
               If drEmbarcacion("Situacion").ToString() <> Entidades.Embarcacion.Situaciones.ENGUARDERIA.ToString() Then
                  ShowMessage("ATENCION: La Situacion de la Embarcación NO Permite la Salida.")
                  Me.ugEmbarcaciones.Focus()
                  Return False
               End If
            End If
         End If

      End If

      If Calendario.SolicitaVehiculo Then
         If Me.bscCodigoVehiculo.Text.Trim().Length = 0 Then
            ShowMessage("El vehiculo es requerido")
            Me.bscCodigoVehiculo.Focus()
            Return False
         End If

      End If

      Return ValidarDatosAdicionales()
   End Function

   Private Sub HabilitaProductoDescuentoRecargoPrecios(habilita As Boolean)
      chbProducto.Enabled = habilita
      bscCodigoProducto2.Enabled = habilita
      bscProducto2.Enabled = habilita
      txtPrecioLista.Enabled = habilita
      txtPrecio.Enabled = habilita
      txtDescRecGralPorc.Enabled = habilita
      txtDescRecPorc1.Enabled = habilita
      txtDescRecPorc2.Enabled = habilita
      txtPrecioNeto.Enabled = habilita
   End Sub
   Private Sub MuestraProductoDescuentoRecargoPrecios(visible As Boolean)
      chbProducto.Visible = visible
      bscCodigoProducto2.Visible = visible
      bscProducto2.Visible = visible
      txtPrecioLista.Enabled = False
      lblPrecio.Visible = visible
      txtPrecio.Visible = visible
      lblDescRecGralPorc.Visible = visible
      txtDescRecGralPorc.Visible = visible
      lblDescRecPorc1.Visible = visible
      txtDescRecPorc1.Visible = visible
      lblDescRecPorc2.Visible = visible
      txtDescRecPorc2.Visible = visible
      lblPrecioNeto.Visible = visible
      txtPrecioNeto.Visible = visible
   End Sub

   Private Sub CargarProducto(dr As DataGridViewRow)
      Me.bscCodigoProducto2.Text = dr.Cells("IdProducto").Value.ToString.Trim()
      Me.bscProducto2.Text = dr.Cells("NombreProducto").Value.ToString()

      If TypeOf (bscCliente.Tag) Is Entidades.Cliente Then
         Dim producto As Entidades.Producto = New Reglas.Productos().GetUno(dr.Cells("IdProducto").Value.ToString.Trim())

         Dim precioVentaSinIVA As Decimal = Decimal.Parse(dr.Cells("PrecioVentaSinIVA").Value.ToString())
         Dim precioVentaConIVA As Decimal = Decimal.Parse(dr.Cells("PrecioVentaConIVA").Value.ToString())

         If Boolean.Parse(dr.Cells("PrecioPorEmbalaje").Value.ToString()) Then
            precioVentaSinIVA = precioVentaSinIVA / Integer.Parse(dr.Cells("Embalaje").Value.ToString())
            precioVentaConIVA = precioVentaConIVA / Integer.Parse(dr.Cells("Embalaje").Value.ToString())
         End If

         If DirectCast(bscCliente.Tag, Entidades.Cliente).CategoriaFiscal.IvaDiscriminado And
            _categoriaFiscalEmpresa.IvaDiscriminado Then
            txtPrecio.Text = precioVentaSinIVA.ToString("N" + Reglas.Publicos.Facturacion.Redondeo.FacturacionDecimalesEnPrecio.ToString())
         Else
            txtPrecio.Text = precioVentaConIVA.ToString("N" + Reglas.Publicos.Facturacion.Redondeo.FacturacionDecimalesEnPrecio.ToString())
         End If

         txtPrecioLista.Text = txtPrecio.Text

         'If Integer.Parse(dr.Cells("IdMoneda").Value.ToString()) = 2 Then
         '   precioVentaSinIVA = Decimal.Round(precioVentaSinIVA * Decimal.Parse(Me.txtCotizacionDolar.Text), Me._decimalesRedondeoEnPrecio)
         '   precioVentaConIVA = Decimal.Round(precioVentaConIVA * Decimal.Parse(Me.txtCotizacionDolar.Text), Me._decimalesRedondeoEnPrecio)
         'End If

         Dim descuentosRecargosProd As Reglas.DescuentoRecargoProducto
         descuentosRecargosProd = New Reglas.CalculosDescuentosRecargos().DescuentoRecargo(DirectCast(bscCliente.Tag, Entidades.Cliente),
                                                                                           producto.IdProducto, 1, 2)

         Me.txtDescRecPorc1.Text = descuentosRecargosProd.DescuentoRecargo1.ToString("N" + Reglas.Publicos.Facturacion.Redondeo.FacturacionDecimalesEnPrecio.ToString())
         If _calculaDescuentoRecargo2 Then
            Me.txtDescRecPorc2.Text = descuentosRecargosProd.DescuentoRecargo2.ToString("N" + Reglas.Publicos.Facturacion.Redondeo.FacturacionDecimalesEnPrecio.ToString())
         End If

         Dim descRecGralPorc As Decimal = New Reglas.CalculosDescuentosRecargos().DescuentoRecargo(DirectCast(bscCliente.Tag, Entidades.Cliente), grabaLibro:=True, esPreElectronico:=True, formaPago:=Nothing,
                                                                                                   cantidadLineasVenta:=1) 'Es un solo concepto por factura a generar. No se cargan varios productos.
         Me.txtDescRecGralPorc.Text = descRecGralPorc.ToString("N" + Reglas.Publicos.Facturacion.Redondeo.FacturacionDecimalesEnPrecio.ToString())

         RecalculaPrecioNeto()

      End If
   End Sub

   Public Sub RecalculaPrecioNeto()
      Dim precioNeto As Decimal = Decimal.Parse(txtPrecio.Text)
      precioNeto = precioNeto * (1 + (Decimal.Parse(txtDescRecPorc1.Text) / 100))
      precioNeto = precioNeto * (1 + (Decimal.Parse(txtDescRecPorc2.Text) / 100))
      precioNeto = precioNeto * (1 + (Decimal.Parse(txtDescRecGralPorc.Text) / 100))
      txtPrecioNeto.Text = precioNeto.ToString("N" + Reglas.Publicos.Facturacion.Redondeo.FacturacionDecimalesEnPrecio.ToString())
   End Sub

   Public Shared Function ControlaCupoDisponible(turnos As List(Of Entidades.TurnoCalendario),
                                                  turnoActual As Entidades.TurnoCalendario,
                                                  fechaHoraDesde As DateTime,
                                                  fechaHoraHasta As DateTime,
                                                  cupo As Integer) As Boolean
      Return New Reglas.TurnosCalendarios().ControlaCupoDisponible(turnos, turnoActual, fechaHoraDesde, fechaHoraHasta, cupo)
      'Dim contCupos As Integer = 0
      'For Each turExistente As Entidades.TurnoCalendario In turnos
      '   If turExistente.IdTurno <> turnoActual.IdTurno Then
      '      If turExistente.FechaDesde < fechaHoraHasta And turExistente.FechaHasta > fechaHoraDesde Then
      '         contCupos += 1
      '      End If
      '   End If
      'Next
      'Return contCupos < cupo
   End Function

   Private Sub CargarZonas(dr As DataGridViewRow)

      If Me.bscCodigoCliente.Text.Trim().Length = 0 Then
         ShowMessage("Falta cargar el Código del cliente.")
         Me.bscCodigoCliente.Focus()
         Return
      End If
      If Me.bscCliente.Text.Trim().Length = 0 Then
         ShowMessage("Falta cargar el Nombre del cliente.")
         Me.bscCliente.Focus()
         Return
      End If

      If bscCliente.Tag Is Nothing Then
         ShowMessage("Falta seleccionar un cliente.")
         Me.bscCodigoCliente.Focus()
         Return
      End If

      Me.bscCodigoZona.Text = dr.Cells("IdProducto").Value.ToString.Trim()
      Me.bscZonas.Text = dr.Cells("NombreProducto").Value.ToString()
      Me.txtNroSesion.Text = (GetNroMayorZona(Long.Parse(Me.bscCodigoCliente.Tag.ToString()), bscCodigoZona.Text, Date.Parse(dtpHoraDesde.Text)) + 1).ToString()
      Me.txtNroSesion.Focus()

   End Sub

   Private Sub InsertarProductosTurnos()
      Dim _TurnosCalendariosProductos As Entidades.TurnosCalendariosProductos = New Entidades.TurnosCalendariosProductos

      _TurnosCalendariosProductos.IdTurno = 1
      _TurnosCalendariosProductos.IdProducto = bscCodigoZona.Text
      _TurnosCalendariosProductos.Orden = If(Turno.TurnoProducto.Count = 0, 0, Turno.TurnoProducto.Max(Function(x) x.Orden)) + 1
      _TurnosCalendariosProductos.NombreProducto = bscZonas.Text
      _TurnosCalendariosProductos.NumeroSesion = Integer.Parse(Me.txtNroSesion.Text)
      _TurnosCalendariosProductos.ValorFluencia = Integer.Parse(Me.txtFluencia.Text)


      Turno.TurnoProducto.Add(_TurnosCalendariosProductos)

      Me.ugProductoZonas.Rows.Refresh(UltraWinGrid.RefreshRow.ReloadData)
   End Sub

   Public Sub FormatearGrilla()
      ugProductoZonas.DisplayLayout.UseFixedHeaders = True
      ugProductoZonas.DisplayLayout.Override.FixedHeaderIndicator = FixedHeaderIndicator.None
      Dim pos As Integer = 0
      With Me.ugProductoZonas.DisplayLayout.Bands(0)

         For Each columna As UltraGridColumn In .Columns
            columna.Hidden = True
            columna.CellActivation = Activation.NoEdit
         Next

         FormatearColumna(.Columns("IdProducto"), "Código", pos, 50, HAlign.Right)
         FormatearColumna(.Columns("NombreProducto"), "Zona", pos, 260, HAlign.Left)
         FormatearColumna(.Columns("NumeroSesion"), "Sesión", pos, 70, HAlign.Right)
         FormatearColumna(.Columns("ValorFluencia"), "Fluencia", pos, 70, HAlign.Right)
      End With
   End Sub

   Private Function GetTurnosProductos() As Entidades.TurnosCalendariosProductos
      If ugProductoZonas.ActiveRow IsNot Nothing AndAlso
         ugProductoZonas.ActiveRow.ListObject IsNot Nothing AndAlso
         TypeOf (ugProductoZonas.ActiveRow.ListObject) Is Entidades.TurnosCalendariosProductos Then
         Return DirectCast(ugProductoZonas.ActiveRow.ListObject, Entidades.TurnosCalendariosProductos)
      End If
      Return Nothing
   End Function

   Private Function GetNroMayorZona(idCliente As Long, idProducto As String, FechaDesde As Date) As Integer
      Dim valMax As Integer = 0
      'If Me.StateForm = 1 Then
      valMax = New Reglas.TurnosCalendariosProductos().GetZonaCliente(idCliente, idProducto, FechaDesde)
      'End If
      Return valMax
   End Function

#End Region


   Private Sub cmbDestinos_SelectedValueChanged(sender As Object, e As EventArgs) Handles cmbDestinos.SelectedValueChanged
      TryCatched(Sub()
                    Dim destino = cmbDestinos.ItemSeleccionado(Of Entidades.Destino)()
                    txtDestinoLibre.Enabled = destino IsNot Nothing AndAlso destino.EsLibre
                 End Sub)
   End Sub

   Private Sub LnkABMVehiculo_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LnkABMVehiculo.LinkClicked
      Try
         Dim Vehiculo = New VehiculosDetalle(New Entidades.Vehiculo())
         Vehiculo.StateForm = StateForm.Insertar
         Vehiculo.CierraAutomaticamente = True
         Vehiculo.CodigoCliente = bscCodigoCliente.Text.ValorNumericoPorDefecto(0L)
         If Vehiculo.ShowDialog() = Windows.Forms.DialogResult.OK Then
            bscCodigoVehiculo.Text = Vehiculo.IdPatente
            bscCodigoVehiculo.PresionarBoton()
            bscCodigoCliente.PresionarBoton()
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub btnImprimir_Click(sender As Object, e As EventArgs) Handles btnImprimir.Click
      TryCatched(Sub() ImprimeTicketTurno())
   End Sub

   Private Sub ImprimeTicketTurno()
      Dim rep = New ImpresionTurnos()
      rep.ImprimeTurno(Turno)
   End Sub

   Private Sub lnkCliente_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lnkCliente.LinkClicked
      Try
         Dim ClientePant = New ClientesDetalle(New Entidades.Cliente())
         ClientePant.StateForm = StateForm.Insertar
         ClientePant.CierraAutomaticamente = True
         If ClientePant.ShowDialog() = Windows.Forms.DialogResult.OK Then
            bscCodigoCliente.Text = ClientePant.Cliente.CodigoCliente.ToString()
            bscCodigoCliente.PresionarBoton()

         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

End Class