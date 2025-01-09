Public Class ReservasDetalle

#Region "Campos"

   Private _publicos As Publicos
   Private _OnLoad As Boolean = False
   Private _comprobante As Entidades.Venta
   Private _EstadoOriginal As Integer
   Private _Productos As DataTable
   Private _VisitasLugares As List(Of Entidades.ReservaTurismoProducto)
   Private _Gastronomia As List(Of Entidades.ReservaTurismoProducto)
   '  Private _Pasajeros As ListConBorrados(Of ReservaPasajero)
   Private _ConfiguracionImpresoras As Boolean
   Private _estaCargando As Boolean = True


#End Region

#Region "Constructores"

   Public Sub New()
      ' This call is required by the designer.
      InitializeComponent()
      ' Add any initialization after the InitializeComponent() call.

   End Sub
   Public Sub New(reserva As Entidades.ReservaTurismo)
      Me.New()
      _entidad = reserva
   End Sub

#End Region

#Region "Propiedades"

   Protected ReadOnly Property Reserva() As Entidades.ReservaTurismo
      Get
         Return DirectCast(_entidad, Entidades.ReservaTurismo)
      End Get
   End Property

#End Region

#Region "Overrides"

   Protected Overrides Sub OnLoad(e As EventArgs)
      If _entidad Is Nothing Then
         _entidad = New Entidades.ReservaTurismo()
      End If

      MyBase.OnLoad(e)

      TryCatched(
         Sub()
            _OnLoad = True
            _publicos = New Publicos()

            '  Me.lnlEnviarMail.Visible = Publicos.CRMPermiteEnvioMailsDesdeNovedad
            _publicos.CargaComboTiposComprobantes(cmbTipoReserva, True, "TURISMO")
            If cmbTipoReserva.Items.Count = 0 Then
               _ConfiguracionImpresoras = True
            End If
            _publicos.CargaComboEstadosTurismo(cmbEstadoTurismo)
            _publicos.CargaComboTiposVehiculos(cmbTipoVehiculo)
            _publicos.CargaComboFormasDePago(cmbFormaPago, "VENTAS", False)
            _publicos.CargaComboCursosTurismo(cmbCurso)
            _publicos.CargaComboTurnosTurismo(cmbTurno)
            _publicos.CargaComboTiposContactos(cmbCargo)
            _publicos.CargaComboTiposViajesTurismo(cmbTipoViaje)

            _publicos.CargaComboImpuestos(cmbPorcentajeIvaFacturacion)

            chbNumeroAutomatico.Checked = True
            txtNumeroReserva.ReadOnly = True

            tbcVisitas.SelectedTab = tbpPasajeros
            SetDataSourcePasajeros()
            tbcVisitas.SelectedTab = tbpFacturacion
            ugProductosFacturacion.DataSource = Reserva.Facturacion
            tbcVisitas.SelectedTab = tbpVisitas

            If StateForm = Win.StateForm.Insertar Then
               'cmbTipoReserva.SelectedIndex = 0
               ' cmbEstadoTurismo.SelectedIndex = 0

               chbNumeroAutomatico.Visible = True
               lblNumeroAutomatico.Visible = True

            Else
               bscCodigoProducto2.Text = Reserva.IdPrograma
               bscCodigoProducto2.PresionarBoton()


               Dim Establecimiento = New Reglas.Clientes()._GetUno(Reserva.IdEstablecimiento)
               bscCodigoCliente.Text = Establecimiento.CodigoCliente.ToString()
               bscCodigoCliente.PresionarBoton()

               Dim Responsable = New Reglas.ClientesContactos().GetUno(Establecimiento.IdCliente, Reserva.IdResponsable)
               bscCodigoResponsable.Text = Responsable.IdContacto.ToString()
               bscCodigoResponsable.PresionarBoton()

               cmbTipoReserva.Enabled = False
               txtLetra.Text = Reserva.Letra
               txtCentroEmisor.Text = Reserva.CentroEmisor.ToString()
               txtNumeroReserva.Text = Reserva.NumeroReserva.ToString()
               cmbTipoReserva.SelectedValue = Reserva.IdTipoReserva

               txtIdUsuarioAlta.Text = Reserva.IdUsuarioAlta

               If Reserva.BanderaColor.HasValue Then
                  btnBanderaColor.BackColor = Reserva.BanderaColor.Value
               Else
                  btnBanderaColor.BackColor = SystemColors.Control
               End If
               If Reserva.FechaViaje <> Nothing Then
                  chbFechaViaje.Checked = True
                  dtpFechaViaje.Value = Reserva.FechaViaje
               End If
               txtObservacionVendedor.Text = Reserva.ObservacionesVendedor
               txtObservacionesInternas.Text = Reserva.ObservacionesInternas
               txtErroresSincronizacion.Text = Reserva.ErroresSincronizacion

               If String.IsNullOrWhiteSpace(Reserva.ErroresSincronizacion) And tbcVisitas.TabPages.Contains(tbpErroresSincronizacion) Then
                  tbcVisitas.TabPages.Remove(tbpErroresSincronizacion)
               End If

            End If

            BindearControles(_entidad, _liSources)
            _estaCargando = False

            If StateForm = Win.StateForm.Insertar Then
               If Not _ConfiguracionImpresoras Then
                  cmbTipoReserva.SelectedIndex = 0
               End If

               Dim EstadoPorDefecto = New Reglas.EstadosTurismo().GetEstadoPorDefecto
               cmbEstadoTurismo.SelectedValue = EstadoPorDefecto

               cmbCurso.SelectedIndex = 0
               cmbTurno.SelectedIndex = 0
               If cmbTipoVehiculo.Items.Count <> 0 Then
                  cmbTipoVehiculo.SelectedIndex = 0
               Else
                  MessageBox.Show("No hay Tipos de Vehiculos definidos", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
                  Close()
               End If
               txtIdUsuarioAlta.Text = actual.Nombre
               cmbFormaPago.SelectedIndex = 0
            Else

            End If

            dtpFechaReserva.Select()

            ugProductosFacturacion.AgregarTotalesSuma({"Cantidad", "ImporteTotal"})

         End Sub,
         Sub(frm) _OnLoad = False)

   End Sub

   Protected Overrides Sub OnShown(e As EventArgs)
      MyBase.OnShown(e)
      TryCatched(Sub() MostrarSemaforoCapacidad())
   End Sub

   Protected Overrides Function ProcessCmdKey(ByRef msg As Message, keyData As Keys) As Boolean
      If keyData = Keys.F4 Then
         btnAceptar.PerformClick()
      ElseIf keyData = Keys.F12 Then
         btnCopiar.PerformClick()
      Else
         Return MyBase.ProcessCmdKey(msg, keyData)
      End If
      Return True
   End Function

   Protected Overrides Function GetReglas() As Reglas.Base
      Return New Reglas.ReservasTurismo()
   End Function

   Protected Overrides Function ValidarDetalle() As String

      Dim cantidad = txtCapacidadMax.ValorNumericoPorDefecto(0D)

      Dim estado = cmbEstadoTurismo.ItemSeleccionado(Of Entidades.EstadoTurismo)()
      Dim blnFinalizado = estado.Finalizado

      If Reserva.Pasajeros IsNot Nothing Then
         If Not estado.SolicitaPasajeros AndAlso Reserva.Pasajeros.Count > 0 Then
            Return String.Format("El estado {0} no solicita pasajeros y ya seleccionó {1}.", estado.NombreEstadoTurismo, Reserva.Pasajeros.Count)
         End If
      End If


      If bscResponsable.Text = "" Then
         Return "Debe ingresar el Responsable."
      End If

      If bscProducto2.Text = "" Then
         Return "Debe ingresar el Programa."
      End If

      If bscCliente.Text = "" Then
         Return "Debe ingresar el Cliente."
      End If

      If Not String.IsNullOrWhiteSpace(txtErroresSincronizacion.Text) Then
         If ShowPregunta("¿Desea eliminar los Errores de Sincronización?") = Windows.Forms.DialogResult.Yes Then
            Reserva.ErroresSincronizacion = String.Empty
         Else
            Reserva.ErroresSincronizacion = txtErroresSincronizacion.Text
         End If
      End If

      Return MyBase.ValidarDetalle()

   End Function

#End Region

#Region "Metodos"

   Protected Overrides Sub Aceptar()

      If StateForm = Win.StateForm.Insertar Then
         Reserva.Letra = txtLetra.Text
         If Not chbNumeroAutomatico.Checked And IsNumeric(txtNumeroReserva.Text) Then
            Reserva.NumeroReserva = Integer.Parse(txtNumeroReserva.Text)
         Else
            Reserva.NumeroReserva = 0
         End If
         Reserva.CentroEmisor = 1
         Reserva.IdUsuarioAlta = actual.Nombre
      End If

      Reserva.IdSucursal = actual.Sucursal.Id
      Reserva.Fecha = dtpFechaReserva.Value
      Reserva.IdUsuarioEstadoTurismo = actual.Nombre
      Reserva.FechaEstadoTurismo = Date.Now()
      If btnBanderaColor.BackColor.Equals(SystemColors.Control) Then
         Reserva.BanderaColor = Nothing
      Else
         Reserva.BanderaColor = btnBanderaColor.BackColor
      End If
      If bscCodigoCliente.Text <> "" Then
         Reserva.IdEstablecimiento = Long.Parse(Me.bscCodigoCliente.Tag.ToString())
      End If
      If bscCodigoResponsable.Text <> "" Then
         Reserva.IdResponsable = Integer.Parse(Me.bscCodigoResponsable.Text.ToString())
      End If
      If bscCodigoProducto2.Text <> "" Then
         Reserva.IdPrograma = bscCodigoProducto2.Text.ToString()
      End If
      Reserva.NombreTipoReserva = cmbTipoReserva.Text

      Reserva.Visitas = Me._VisitasLugares
      Reserva.Gastronomia = Me._Gastronomia
      Reserva.Pasajeros = Reserva.Pasajeros

      If chbFechaViaje.Checked Then
         Reserva.FechaViaje = dtpFechaViaje.Value
      End If

      Reserva.ObservacionesVendedor = txtObservacionVendedor.Text
      Reserva.ObservacionesInternas = txtObservacionesInternas.Text

      MyBase.Aceptar()

      If Not HayError Then

      End If

   End Sub

   Private Sub ClearCombo(cmb As ComboBox)
      If TypeOf (cmb.DataSource) Is IList Then DirectCast(cmb.DataSource, IList).Clear()
   End Sub

   Private Function MostrarMasInfo(bsc As Eniac.Controles.Buscador2) As DialogResult
      Dim clie As Entidades.Cliente = Nothing
      If bsc.Text <> "" Or bsc.Selecciono Then
         clie = New Eniac.Reglas.Clientes().GetUno(Long.Parse(bsc.Tag.ToString()), incluirFoto:=True)
      End If
      Dim result As DialogResult = Ayudante.MasInfoCliente.MostrarMasInfo.Mostrar(clie)
      If result = Windows.Forms.DialogResult.OK Then
         bsc.Text = clie.CodigoCliente.ToString()
         Dim prevPermitido As Boolean = bsc.Permitido
         bsc.PresionarBoton()
         bsc.Permitido = prevPermitido
      End If
      Return result

   End Function

   Private Sub AgregarComponente()
      Me.Cursor = Cursors.WaitCursor

      If dgvProductos.Selected.Rows.Count = 0 And dgvProductos.ActiveRow IsNot Nothing Then
         dgvProductos.ActiveRow.Selected = True
      End If
      Try
         Dim drListaCol As List(Of DataRow) = New List(Of DataRow)()
         For Each dgLista As UltraGridRow In dgvProductos.Selected.Rows
            If dgLista.ListObject IsNot Nothing AndAlso
               TypeOf (dgLista.ListObject) Is DataRowView AndAlso
               DirectCast(dgLista.ListObject, DataRowView).Row IsNot Nothing Then

               For Each item As Entidades.ReservaTurismoProducto In _VisitasLugares
                  If item.IdProducto = dgLista.Cells("IdVisita").Value.ToString() And item.IdProductoComponente = dgLista.Cells("IdActividad").Value.ToString() Then
                     Throw New Exception("La Visita ya esta existe: " & dgLista.Cells("Visita").Value.ToString())
                  End If
               Next
               drListaCol.Add(DirectCast(dgLista.ListObject, DataRowView).Row)
            End If
         Next

         Dim Visita As Entidades.ReservaTurismoProducto

         For Each drLista As DataRow In drListaCol
            Visita = New Entidades.ReservaTurismoProducto()

            Visita.IdProducto = drLista("IdVisita").ToString()
            Visita.NombreProducto = drLista("Visita").ToString()
            Visita.IdProductoComponente = drLista("IdActividad").ToString()
            Visita.NombreProducto1 = drLista("Actividad").ToString()
            Visita.IdFormula = Integer.Parse(drLista("IdFormula").ToString())

            _VisitasLugares.Add(Visita)
            dgvComponentes1.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.ExitEditMode)
            dgvComponentes1.Rows.Refresh(UltraWinGrid.RefreshRow.ReloadData)

         Next
         dgvComponentes1.DataSource = _VisitasLugares

         dgvProductos.DeleteSelectedRows(False)

         FormatearGrillaComponentes()
      Catch
         Throw
      End Try

   End Sub

   Private Sub AgregarComponenteGastronomico()
      Me.Cursor = Cursors.WaitCursor

      If ugvProductosGastronomicos.Selected.Rows.Count = 0 And ugvProductosGastronomicos.ActiveRow IsNot Nothing Then
         ugvProductosGastronomicos.ActiveRow.Selected = True
      End If
      Try
         Dim drListaCol As List(Of DataRow) = New List(Of DataRow)()
         For Each dgLista As UltraGridRow In ugvProductosGastronomicos.Selected.Rows
            If dgLista.ListObject IsNot Nothing AndAlso
               TypeOf (dgLista.ListObject) Is DataRowView AndAlso
               DirectCast(dgLista.ListObject, DataRowView).Row IsNot Nothing Then

               For Each item As Entidades.ReservaTurismoProducto In _Gastronomia
                  If item.IdProducto = dgLista.Cells("IdProducto").Value.ToString() And item.IdProductoComponente = dgLista.Cells("IdGastro").Value.ToString() Then
                     Throw New Exception("El servicio gastronómico ya esta existe: " & dgLista.Cells("Gastronomico").Value.ToString())
                  End If
               Next
               drListaCol.Add(DirectCast(dgLista.ListObject, DataRowView).Row)
            End If
         Next

         Dim Gastronomico As Entidades.ReservaTurismoProducto

         For Each drLista As DataRow In drListaCol
            Gastronomico = New Entidades.ReservaTurismoProducto()

            Gastronomico.IdProducto = Nothing
            Gastronomico.NombreProducto = Nothing
            Gastronomico.IdProductoComponente = drLista("IdGastro").ToString()
            Gastronomico.NombreProducto1 = drLista("Gastronomico").ToString()
            Gastronomico.IdFormula = Integer.Parse(drLista("IdFormula").ToString())
            Gastronomico.NombreSubRubro = drLista("NombreSubRubro").ToString()

            _Gastronomia.Add(Gastronomico)
            ugdDetalleGastronomico1.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.ExitEditMode)
            ugdDetalleGastronomico1.Rows.Refresh(UltraWinGrid.RefreshRow.ReloadData)

         Next
         Me.ugdDetalleGastronomico1.DataSource = Me._Gastronomia

         Me.ugvProductosGastronomicos.DeleteSelectedRows(False)

         Me.FormatearGrillaDetalleGastronomia()
      Catch
         Throw
      End Try

   End Sub

   Private Sub AgregarPasajeros()

      Me.Cursor = Cursors.WaitCursor
      If Reserva.Pasajeros IsNot Nothing Then
         For Each pasajero As Entidades.ReservaTurismoPasajero In Reserva.Pasajeros
            If pasajero.IdClientePasajero = Long.Parse(Me.bscCodPasajero.Tag.ToString()) Then
               Throw New Exception("El Pasajero ya esta existe: " & Me.bscPasajero.Text.ToString())
            End If
         Next
      End If

      Try
         Dim Pasajeros As Entidades.ReservaTurismoPasajero = New Entidades.ReservaTurismoPasajero

         Pasajeros.IdClientePasajero = Long.Parse(Me.bscCodPasajero.Tag.ToString())
         Pasajeros.NombrePasajero = Me.bscPasajero.Text.ToString()
         If Me.bscCodRespPasajero.Text <> "" Then
            Pasajeros.IdResponsablePasajero = Long.Parse(Me.bscCodRespPasajero.Tag.ToString())
            Pasajeros.NombreResponsable = Me.bscRespPasajero.Text.ToString()
         Else
            Pasajeros.IdResponsablePasajero = Nothing
         End If
         If chbLiberadoPasajero.Checked Then
            Pasajeros.PorcentajeLiberado = Decimal.Parse(Me.txtLiberadosPasajeros.Text.ToString())
         Else
            Pasajeros.PorcentajeLiberado = Nothing
         End If

         Pasajeros.Costo = Decimal.Parse(Me.txtCostoPasajeros.Text.ToString())

         Reserva.Pasajeros.Add(Pasajeros)

         SetDataSourcePasajeros()

      Catch
         Throw
      End Try

   End Sub

   Private Sub SetDataSourcePasajeros()
      ugPasajeros.DataSource = Reserva.Pasajeros

      ugPasajeros.PerformAction(UltraGridAction.ExitEditMode)
      ugPasajeros.Rows.Refresh(RefreshRow.ReloadData)

      MostrarSemaforoCapacidad()

      FormatearGrillaPasajeros()

      tssPasajeros.Text = ugPasajeros.CantidadRegistrosParaStatusbar
   End Sub

   Private Sub MostrarSemaforoCapacidad()
      Dim pasajeros = If(Reserva.Pasajeros Is Nothing, 0, Reserva.Pasajeros.Count)
      lblSemaforoCapacidadTransporte.Text = String.Format(lblSemaforoCapacidadTransporte.Tag.ToString(),
                                                          txtCapacidadMax.ValorNumericoPorDefecto(0I),
                                                          pasajeros,
                                                          txtCapacidadMax.ValorNumericoPorDefecto(0I) - pasajeros)
   End Sub


   Private Sub AgregarPasajerosMultiples(Pasajero As Entidades.Cliente)

      Me.Cursor = Cursors.WaitCursor
      Try
         Dim Pasajeros As Entidades.ReservaTurismoPasajero = New Entidades.ReservaTurismoPasajero

         Pasajeros.IdClientePasajero = Pasajero.IdCliente
         Pasajeros.NombrePasajero = Pasajero.NombreCliente
         Pasajeros.IdResponsablePasajero = Nothing
         Pasajeros.PorcentajeLiberado = Nothing
         Pasajeros.Costo = Decimal.Parse(Me.txtCostoPasajeros.Text.ToString())

         Reserva.Pasajeros.Add(Pasajeros)

         SetDataSourcePasajeros()

      Catch
         Throw
      Finally
         Me.Cursor = Cursors.Default
      End Try

   End Sub
   Private Sub CargarProducto(dr As DataGridViewRow)
      bscProducto2.Text = dr.Cells("NombreProducto").Value.ToString()
      bscCodigoProducto2.Text = dr.Cells("IdProducto").Value.ToString.Trim()

      dgvComponentes1.Enabled = True

      CargarProductosComponentes()

      CargarReserva(Me.bscCodigoProducto2.Text)

      EliminarProductosSeleccionados()

      EliminarGastronomiaSeleccionados()

   End Sub

   Private Sub EliminarProductosSeleccionados()
      For Each dr1 As UltraGridRow In dgvProductos.Rows
         For Each dr2 As UltraGridRow In dgvComponentes1.Rows
            If dr2.Cells("IdProductoComponente").Value Is Nothing Then
               dr2.Cells("IdProductoComponente").Value = ""
            End If
            If dr1.Cells("IdVisita").Value.ToString() = dr2.Cells("IdProducto").Value.ToString() And
                             dr1.Cells("IdActividad").Value.ToString() = dr2.Cells("IdProductoComponente").Value.ToString() Then
               dr1.Selected = True
            End If
         Next
      Next

      Me.dgvProductos.DeleteSelectedRows(False)

   End Sub

   Private Sub EliminarGastronomiaSeleccionados()
      For Each dr1 As UltraGridRow In ugvProductosGastronomicos.Rows
         For Each dr2 As UltraGridRow In ugdDetalleGastronomico1.Rows
            If dr1.Cells("IdGastro").Value.ToString() = dr2.Cells("IdProductoComponente").Value.ToString() Then
               dr1.Selected = True
            End If
         Next
      Next
      Me.ugvProductosGastronomicos.DeleteSelectedRows(False)
   End Sub

   Private Sub CargarDatosCliente(dr As DataGridViewRow)

      Me.bscCliente.Text = dr.Cells("NombreCliente").Value.ToString()
      Me.bscCodigoCliente.Text = dr.Cells("CodigoCliente").Value.ToString()
      Me.bscCodigoCliente.Tag = dr.Cells("IdCliente").Value.ToString()
      'Me.bscCliente.Enabled = False
      'Me.bscCodigoCliente.Enabled = False
      Me.txtDireccion.Text = dr.Cells("Direccion").Value.ToString()
      Me.txtLocalidad.Text = dr.Cells("NombreLocalidad").Value.ToString()
      Me.txtEmail.Text = dr.Cells("CorreoElectronico").Value.ToString()

      If Me.bscCodigoCliente.Selecciono Or Me.bscCliente.Selecciono Then
         Me.bscResponsable.Enabled = True
         Me.bscResponsable.Text = ""
         Me.bscCodigoResponsable.Text = ""
         Me.txtTelefono.Text = ""
         Me.txtEmailResponsable.Text = ""
      End If

   End Sub

   Private Sub CargarDatosResponsable(dr As DataGridViewRow)

      Me.bscResponsable.Text = dr.Cells("NombreContacto").Value.ToString()
      Me.bscCodigoResponsable.Text = dr.Cells("IdContacto").Value.ToString()
      'Me.bscResponsable.Enabled = False
      'Me.bscCodigoResponsable.Enabled = False
      Me.cmbCargo.SelectedValue = dr.Cells("IdTipoContacto").Value.ToString()
      Me.txtTelefono.Text = dr.Cells("Telefono").Value.ToString() & "-" & dr.Cells("Celular").Value.ToString()
      Me.txtEmailResponsable.Text = dr.Cells("CorreoElectronico").Value.ToString()

   End Sub

   Private Sub CargarDatosPasajero(dr As DataGridViewRow)

      Me.bscPasajero.Text = dr.Cells("NombreCliente").Value.ToString()
      Me.bscCodPasajero.Text = dr.Cells("CodigoCliente").Value.ToString()
      Me.bscCodPasajero.Tag = dr.Cells("IdCliente").Value.ToString()

      Dim idClienteCtaCte As Long = ObjectExtensions.ValorNumericoPorDefecto(dr.Cells("CodigoClienteCtaCte").Value, 0L)
      If idClienteCtaCte > 0 Then
         bscCodRespPasajero.Text = idClienteCtaCte.ToString()
         bscCodRespPasajero.PresionarBoton()
      End If

      txtCostoPasajeros.Focus()
   End Sub

   Private Sub CargarDatosRespPasajero(dr As DataGridViewRow)

      Me.bscRespPasajero.Text = dr.Cells("NombreCliente").Value.ToString()
      Me.bscCodRespPasajero.Text = dr.Cells("CodigoCliente").Value.ToString()
      Me.bscCodRespPasajero.Tag = dr.Cells("IdCliente").Value.ToString()
      chbLiberadoPasajero.Focus()

   End Sub

   Private Sub CargarProductosComponentes()

      Try

         Me.dgvProductos.Enabled = True

         Me.btnAgregarComponente.Enabled = True
         Me.btnEliminarComponente.Enabled = True
         Me.btnAgregarGastronomico.Enabled = True
         Me.btnEliminarGastronomico.Enabled = True

         Me.dgvComponentes1.Enabled = True

         'Carga grilla Productos
         Dim oproductos As Reglas.ProductosComponentes = New Reglas.ProductosComponentes()

         Dim dt2 As DataTable

         _Productos = oproductos.GetProductosComponente2(Me.bscCodigoProducto2.Text.ToString().Trim(),
                                                 Eniac.Reglas.Publicos.TurismoRubroPrograma,
                                                 Eniac.Reglas.Publicos.TurismoRubroVisita)

         dt2 = oproductos.GetProductosComponenteGastronomico(Me.bscCodigoProducto2.Text.ToString().Trim(),
                                                 Eniac.Reglas.Publicos.TurismoRubroGastronomia)

         Me.dgvProductos.DataSource = _Productos
         Me.ugvProductosGastronomicos.DataSource = dt2

         Me.FormatearGrillaProductos()
         Me.FormatearGrillaGastronomia()

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try


   End Sub

   Private Sub CargarReserva(idProducto As String)

      'Carga grilla de Componentes Productos

      Try

         Dim oComponentes As Reglas.ReservasTurismoProductos = New Reglas.ReservasTurismoProductos()
         Dim oPasajeros As Reglas.ReservasTurismoPasajeros = New Reglas.ReservasTurismoPasajeros()

         Dim idListaDePrecios As Integer = 0    'Lista Base


         Me._VisitasLugares = oComponentes.GetReservaProducto2(Reserva.IdSucursal, Reserva.IdTipoReserva, Reserva.Letra,
                                                               Reserva.CentroEmisor, Reserva.NumeroReserva, Eniac.Reglas.Publicos.TurismoFormulaVisitasID)


         Me._Gastronomia = oComponentes.GetReservaProducto2(Reserva.IdSucursal, Reserva.IdTipoReserva, Reserva.Letra,
                                                               Reserva.CentroEmisor, Reserva.NumeroReserva, Eniac.Reglas.Publicos.TurismoFormulaGastronomiaID)

         If StateForm = Win.StateForm.Actualizar And DirectCast(Me.cmbEstadoTurismo.SelectedItem, Entidades.EstadoTurismo).SolicitaPasajeros Then

            'Me._Pasajeros = oPasajeros.GetReservaPasajero2(Reserva.IdSucursal, Reserva.IdTipoReserva, Reserva.Letra,
            '                                                             Reserva.CentroEmisor, Reserva.NumeroReserva)

            SetDataSourcePasajeros()
         Else
            Dim lista As List(Of Entidades.ReservaTurismoPasajero) = New List(Of Entidades.ReservaTurismoPasajero)

            Reserva.Pasajeros = New Entidades.ListConBorrados(Of Entidades.ReservaTurismoPasajero)(lista)
         End If


         Me.dgvComponentes1.DataSource = Me._VisitasLugares
         Me.ugdDetalleGastronomico1.DataSource = _Gastronomia
         Me.tssPasajeros.Text = Me.ugPasajeros.Rows.Count & " Registros"

         Me.FormatearGrillaComponentes()
         Me.FormatearGrillaDetalleGastronomia()


      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try

   End Sub

   Private Sub FormatearGrillaProductos()
      With Me.dgvProductos.DisplayLayout.Bands(0)
         For Each columna As UltraGridColumn In .Columns
            columna.Hidden = True
         Next
         Dim col As Integer = 0
         .Columns("Visita").FormatearColumna("Visitas", col, 200)
         .Columns("Actividad").FormatearColumna("Actividades", col, 250)
      End With
      Me.LeerPreferencias()

   End Sub

   Private Sub FormatearGrillaGastronomia()
      With Me.ugvProductosGastronomicos.DisplayLayout.Bands(0)
         For Each columna As UltraGridColumn In .Columns
            columna.Hidden = True
         Next
         Dim col As Integer = 0
         .Columns("NombreSubRubro").FormatearColumna("Tipo", col, 80)
         .Columns("Gastronomico").FormatearColumna("Servicios", col, 350)
      End With
      Me.LeerPreferencias()

   End Sub

   Private Sub FormatearGrillaComponentes()
      With Me.dgvComponentes1.DisplayLayout.Bands(0)
         For Each columna As UltraGridColumn In .Columns
            columna.Hidden = True
         Next
         Dim col As Integer = 0
         .Columns("NombreProducto").FormatearColumna("Visitas", col, 200)
         .Columns("NombreProducto1").FormatearColumna("Actividades", col, 250)
      End With
      Me.LeerPreferencias()

   End Sub

   Private Sub FormatearGrillaDetalleGastronomia()
      With Me.ugdDetalleGastronomico1.DisplayLayout.Bands(0)
         For Each columna As UltraGridColumn In .Columns
            columna.Hidden = True
         Next
         Dim col As Integer = 0
         .Columns("NombreSubRubro").FormatearColumna("Tipo", col, 80)
         .Columns("NombreProducto1").FormatearColumna("Servicios", col, 350)
      End With
      Me.LeerPreferencias()

   End Sub

   Private Sub FormatearGrillaPasajeros()
      If ugPasajeros.Visible Then
         With ugPasajeros.DisplayLayout.Bands(0)
            For Each columna As UltraGridColumn In .Columns
               columna.Hidden = True
            Next
            Dim col As Integer = 0
            .Columns("NombrePasajero").FormatearColumna("Pasajero", col, 300)
            .Columns("NombreResponsable").FormatearColumna("Responsable", col, 300)
            .Columns("Costo").FormatearColumna("Costo", col, 80, HAlign.Right)
            .Columns("PorcentajeLiberado").FormatearColumna("% Liberado", col, 80, HAlign.Right, , "N2")
            .Columns("IdTipoComprobante").FormatearColumna("Comprobante", col, 100)
            .Columns("LetraComprobante").FormatearColumna("Letra", col, 50)
            .Columns("CentroEmisorComprobante").FormatearColumna("Emisor", col, 50, HAlign.Right)
            .Columns("NumeroComprobante").FormatearColumna("Numero", col, 80, HAlign.Right)

         End With
      End If
   End Sub

   Protected Overridable Sub LeerPreferencias()
      Try

         dgvProductos.AgregarFiltroEnLinea({"Visita", "Actividad"})
         ugvProductosGastronomicos.AgregarFiltroEnLinea({"Gastronomico", "NombreSubRubro"})


         Dim nameProd As String = Me.dgvProductos.FindForm().Name + "ProductosGrid.xml"
         Dim nameComp As String = Me.dgvComponentes1.FindForm().Name + "ComponentesGrid.xml"

         Dim nameProdGast As String = Me.ugvProductosGastronomicos.FindForm().Name + "ProductosGastGrid.xml"
         Dim nameCompGast As String = Me.ugdDetalleGastronomico1.FindForm().Name + "ComponentesGastGrid.xml"

         If System.IO.File.Exists(nameProd) Then
            Me.dgvProductos.DisplayLayout.LoadFromXml(nameProd)
         End If

         If System.IO.File.Exists(nameComp) Then
            Me.dgvComponentes1.DisplayLayout.LoadFromXml(nameComp)
         End If

         If System.IO.File.Exists(nameProdGast) Then
            Me.dgvProductos.DisplayLayout.LoadFromXml(nameProdGast)
         End If

         If System.IO.File.Exists(nameCompGast) Then
            Me.dgvComponentes1.DisplayLayout.LoadFromXml(nameCompGast)
         End If

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Public Sub RefrescarPasajeros()

      Me.bscCodPasajero.Text = ""
      Me.bscPasajero.Text = ""
      Me.bscCodRespPasajero.Text = ""
      Me.bscRespPasajero.Text = ""
      Me.txtCostoPasajeros.Text = Me.txtCosto.Text
      Me.chbLiberadoPasajero.Checked = False
      Me.txtLiberadosPasajeros.Text = ""

   End Sub

   Private Function GetCurrentPasajero() As Entidades.ReservaTurismoPasajero
      If ugPasajeros.ActiveRow IsNot Nothing AndAlso
         ugPasajeros.ActiveRow.ListObject IsNot Nothing AndAlso
         TypeOf (ugPasajeros.ActiveRow.ListObject) Is Entidades.ReservaTurismoPasajero Then
         Return DirectCast(ugPasajeros.ActiveRow.ListObject, Entidades.ReservaTurismoPasajero)
      End If
      Return Nothing
   End Function

   Private Sub CargarPasajeroCompleto(Pasajero As Entidades.ReservaTurismoPasajero)

      Dim Cliente As Entidades.Cliente = New Reglas.Clientes().GetUno(Pasajero.IdClientePasajero)
      Me.bscCodPasajero.Text = Cliente.CodigoCliente.ToString()
      Me.bscCodPasajero.PresionarBoton()

      If Pasajero.IdResponsablePasajero <> 0 Then
         Dim Cliente2 As Entidades.Cliente = New Reglas.Clientes().GetUno(Pasajero.IdResponsablePasajero)
         Me.bscCodRespPasajero.Text = Cliente2.CodigoCliente.ToString()
         Me.bscCodRespPasajero.PresionarBoton()
      End If

      '-- REQ-34137.- -----------------------------------
      txtCostoPasajeros.Text = Pasajero.Costo.ToString()
      '--------------------------------------------------

      If Pasajero.PorcentajeLiberado <> 0 Then
         Me.chbLiberadoPasajero.Checked = True
         Me.txtLiberadosPasajeros.Text = Pasajero.PorcentajeLiberado.ToString()
      End If


   End Sub

   Private Sub CargarPasajerosSeleccionados(PasajerosSeleccionados As List(Of Entidades.Cliente))
      For Each pas As Entidades.Cliente In PasajerosSeleccionados
         Me.AgregarPasajerosMultiples(pas)
      Next
   End Sub

#End Region

#Region "Eventos"


   Private Sub btnBanderaColor_Click(sender As Object, e As EventArgs) Handles btnBanderaColor.Click
      Try
         If btnBanderaColor.BackColor.ToArgb().Equals(SystemColors.Control.ToArgb()) Then
            btnBanderaColor.BackColor = Color.Green
         ElseIf btnBanderaColor.BackColor.ToArgb().Equals(Color.Green.ToArgb()) Then
            btnBanderaColor.BackColor = Color.Yellow
         ElseIf btnBanderaColor.BackColor.ToArgb().Equals(Color.Yellow.ToArgb()) Then
            btnBanderaColor.BackColor = Color.Red
         ElseIf btnBanderaColor.BackColor.ToArgb().Equals(Color.Red.ToArgb()) Then
            btnBanderaColor.BackColor = SystemColors.Control
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Nothing, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub


#Region "Eventos Buscadores"

#Region "BuscadoresClientes"
   Private Sub bscCodigoCliente_BuscadorClick() Handles bscCodigoCliente.BuscadorClick
      Dim codigoCliente As Long = -1
      Try
         Me._publicos.PreparaGrillaClientes2(Me.bscCodigoCliente)
         Dim oClientes As Reglas.Clientes = New Reglas.Clientes
         If Me.bscCodigoCliente.Text.Trim.Length > 0 Then
            codigoCliente = Long.Parse(Me.bscCodigoCliente.Text.Trim())
         End If
         Me.bscCodigoCliente.Datos = oClientes.GetFiltradoPorCodigo(codigoCliente, True, False)
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try

   End Sub

   Private Sub bscCodigoCliente_BuscadorSeleccion(sender As Object, e As Controles.BuscadorEventArgs) Handles bscCodigoCliente.BuscadorSeleccion
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
         Dim oClientes As Reglas.Clientes = New Reglas.Clientes
         Me.bscCliente.Datos = oClientes.GetFiltradoPorNombre(Me.bscCliente.Text.Trim(), False)
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub bscCliente_BuscadorSeleccion(sender As Object, e As Controles.BuscadorEventArgs) Handles bscCliente.BuscadorSeleccion
      Try
         If Not e.FilaDevuelta Is Nothing Then
            Me.CargarDatosCliente(e.FilaDevuelta)
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub bscCodigoResponsable_BuscadorClick() Handles bscCodigoResponsable.BuscadorClick
      Dim codigoCliente As Integer = -1
      Try
         Me._publicos.PreparaGrillaContactos(Me.bscCodigoResponsable)
         Dim oClientes As Reglas.ClientesContactos = New Reglas.ClientesContactos
         If Me.bscCodigoResponsable.Text.Trim.Length > 0 Then
            codigoCliente = Integer.Parse(Me.bscCodigoResponsable.Text.Trim())
         End If
         Me.bscCodigoResponsable.Datos = oClientes.GetClientesContactos(Long.Parse(Me.bscCodigoCliente.Tag.ToString()), codigoCliente, True)
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try

   End Sub

   Private Sub bscCodigoResponsable_BuscadorSeleccion(sender As Object, e As Controles.BuscadorEventArgs) Handles bscCodigoResponsable.BuscadorSeleccion
      Try
         If Not e.FilaDevuelta Is Nothing Then
            Me.CargarDatosResponsable(e.FilaDevuelta)

         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub bscResponsable_BuscadorClick() Handles bscResponsable.BuscadorClick
      Try
         Me._publicos.PreparaGrillaContactos(Me.bscResponsable)
         Dim oClientes As Reglas.ClientesContactos = New Reglas.ClientesContactos
         If Me.bscCodigoCliente.Text.Trim.Length > 0 Then
            Me.bscResponsable.Datos = oClientes.GetClientesContactos(Long.Parse(Me.bscCodigoCliente.Tag.ToString()))
         End If

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub bscResponsable_BuscadorSeleccion(sender As Object, e As Controles.BuscadorEventArgs) Handles bscResponsable.BuscadorSeleccion
      Try
         If Not e.FilaDevuelta Is Nothing Then
            Me.CargarDatosResponsable(e.FilaDevuelta)
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub bscCodPasajero_BuscadorClick() Handles bscCodPasajero.BuscadorClick
      Dim codigoCliente As Long = -1
      Try
         Me._publicos.PreparaGrillaClientes2(Me.bscCodPasajero)
         Dim oClientes As Reglas.Clientes = New Reglas.Clientes
         If Me.bscCodPasajero.Text.Trim.Length > 0 Then
            codigoCliente = Long.Parse(Me.bscCodPasajero.Text.Trim())
         End If
         Me.bscCodPasajero.Datos = oClientes.GetFiltradoPorCodigo(codigoCliente, True, False)
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try

   End Sub

   Private Sub bscCodPasajero_BuscadorSeleccion(sender As Object, e As Controles.BuscadorEventArgs) Handles bscCodPasajero.BuscadorSeleccion
      Try
         If Not e.FilaDevuelta Is Nothing Then
            Me.CargarDatosPasajero(e.FilaDevuelta)

         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub bscPasajero_BuscadorClick() Handles bscPasajero.BuscadorClick
      Try
         Me._publicos.PreparaGrillaClientes2(Me.bscPasajero)
         Dim oClientes As Reglas.Clientes = New Reglas.Clientes
         Me.bscPasajero.Datos = oClientes.GetFiltradoPorNombre(Me.bscPasajero.Text.Trim(), False)
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub bscPasajero_BuscadorSeleccion(sender As Object, e As Controles.BuscadorEventArgs) Handles bscPasajero.BuscadorSeleccion
      Try
         If Not e.FilaDevuelta Is Nothing Then
            Me.CargarDatosPasajero(e.FilaDevuelta)
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub bscCodRespPasajero_BuscadorClick() Handles bscCodRespPasajero.BuscadorClick
      Dim codigoCliente As Long = -1
      Try
         Me._publicos.PreparaGrillaClientes2(Me.bscCodRespPasajero)
         Dim oClientes As Reglas.Clientes = New Reglas.Clientes
         If Me.bscCodRespPasajero.Text.Trim.Length > 0 Then
            codigoCliente = Long.Parse(Me.bscCodRespPasajero.Text.Trim())
         End If
         Me.bscCodRespPasajero.Datos = oClientes.GetFiltradoPorCodigo(codigoCliente, True, False)
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try

   End Sub

   Private Sub bscCodRespPasajero_BuscadorSeleccion(sender As Object, e As Controles.BuscadorEventArgs) Handles bscCodRespPasajero.BuscadorSeleccion
      Try
         If Not e.FilaDevuelta Is Nothing Then
            Me.CargarDatosRespPasajero(e.FilaDevuelta)

         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub bscRespPasajero_BuscadorClick() Handles bscRespPasajero.BuscadorClick
      Try
         Me._publicos.PreparaGrillaClientes2(Me.bscRespPasajero)
         Dim oClientes As Reglas.Clientes = New Reglas.Clientes
         Me.bscRespPasajero.Datos = oClientes.GetFiltradoPorNombre(Me.bscRespPasajero.Text.Trim(), False)
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub bscRespPasajero_BuscadorSeleccion(sender As Object, e As Controles.BuscadorEventArgs) Handles bscRespPasajero.BuscadorSeleccion
      Try
         If Not e.FilaDevuelta Is Nothing Then
            Me.CargarDatosRespPasajero(e.FilaDevuelta)
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub



#End Region

#Region "BuscadoresProductos"
   Private Sub bscCodigoProducto2_BuscadorClick() Handles bscCodigoProducto2.BuscadorClick
      Try
         Dim oProductos As Reglas.Productos = New Reglas.Productos
         Me._publicos.PreparaGrillaProductos2(Me.bscCodigoProducto2)
         Me.bscCodigoProducto2.Datos = oProductos.GetPorCodigo(Me.bscCodigoProducto2.Text.Trim(), actual.Sucursal.Id, Publicos.ListaPreciosPredeterminada, "VENTAS", , , , , , , , Reglas.Publicos.TurismoRubroPrograma)
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
         Dim oProductos As Reglas.Productos = New Reglas.Productos
         Me._publicos.PreparaGrillaProductos2(Me.bscProducto2)
         Me.bscProducto2.Datos = oProductos.GetPorNombre(Me.bscProducto2.Text.Trim(), actual.Sucursal.Id, Publicos.ListaPreciosPredeterminada, "VENTAS", , , , , , , Reglas.Publicos.TurismoRubroPrograma)
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

#End Region

#End Region

   Private Sub llbCliente_LinkClicked(sender As System.Object, e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles llbCliente.LinkClicked
      Try
         MostrarMasInfo(Me.bscCodigoCliente)
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

   Private Sub lnlEnviarMail_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lnlEnviarMail.LinkClicked
      'Try
      '   Dim ma As MensajeMail = New MensajeMail()
      '   ma.txtDestinatarios.Text = DirectCast(Me.cmbIdUsuarioAsignado.SelectedItem, Entidades.Usuario).CorreoElectronico
      '   ma.txtAsunto.Text = Me.cmbTipoNovedad.Text + " - " + Me.txtIdNovedad.Text + " - " + Me.txtDescripcion.Text
      '   ma.chbCopiaASiMismo.Checked = False
      '   ma.Show()
      '   ma.txtCuerpo.Focus()

      'Catch ex As Exception
      '   MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      'End Try
   End Sub

   Private Sub chbNumeroAutomatico_CheckedChanged(sender As Object, e As EventArgs) Handles chbNumeroAutomatico.CheckedChanged
      txtNumeroReserva.ReadOnly = chbNumeroAutomatico.Checked
   End Sub

   Private Sub btnPreferenciasProductos_Click(sender As Object, e As EventArgs) Handles btnPreferenciasProductos.Click
      Try
         Dim pre As Preferencias = New Preferencias(Me.dgvProductos, True)
         pre.SufijoXML = "Productos"
         pre.ShowDialog()
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub btnPreferenciasComponentes_Click(sender As Object, e As EventArgs) Handles btnPreferenciasComponentes.Click
      Try
         Dim pre As Preferencias = New Preferencias(Me.dgvComponentes1, True)
         pre.SufijoXML = "Componentes"
         pre.ShowDialog()
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub btnAgregarComponente_Click(sender As System.Object, e As System.EventArgs) Handles btnAgregarComponente.Click
      Try

         Me.AgregarComponente()

      Catch ex As Exception
         ShowError(ex)
      Finally
         Me.Cursor = Cursors.Default
      End Try
   End Sub

   Private Sub btnEliminarComponente_Click(sender As System.Object, e As System.EventArgs) Handles btnEliminarComponente.Click
      Try

         If dgvComponentes1.Selected.Rows.Count = 0 And dgvComponentes1.ActiveRow IsNot Nothing Then
            dgvComponentes1.ActiveRow.Selected = True
         End If

         If Me.dgvComponentes1.ActiveCell IsNot Nothing Then
            Me.dgvComponentes1.ActiveRow = Me.dgvComponentes1.ActiveCell.Row
         End If
         If Me.dgvComponentes1.ActiveCell IsNot Nothing Or Me.dgvComponentes1.ActiveRow IsNot Nothing Then
            Me.dgvComponentes1.DeleteSelectedRows(True)
         End If

         Me.CargarProductosComponentes()
         Me.EliminarProductosSeleccionados()
         Me.EliminarGastronomiaSeleccionados()

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try

   End Sub

   Private Sub btnAgregarGastronomico_Click(sender As Object, e As EventArgs) Handles btnAgregarGastronomico.Click
      Try
         Me.AgregarComponenteGastronomico()
      Catch ex As Exception
         ShowError(ex)
      Finally
         Me.Cursor = Cursors.Default
      End Try
   End Sub

   Private Sub btnEliminarGastronomico_Click(sender As Object, e As EventArgs) Handles btnEliminarGastronomico.Click

      Try
         If ugdDetalleGastronomico1.Selected.Rows.Count = 0 And ugdDetalleGastronomico1.ActiveRow IsNot Nothing Then
            ugdDetalleGastronomico1.ActiveRow.Selected = True
         End If

         If Me.ugdDetalleGastronomico1.ActiveCell IsNot Nothing Then
            Me.ugdDetalleGastronomico1.ActiveRow = Me.ugdDetalleGastronomico1.ActiveCell.Row
         End If
         If Me.ugdDetalleGastronomico1.ActiveCell IsNot Nothing Or Me.ugdDetalleGastronomico1.ActiveRow IsNot Nothing Then
            Me.ugdDetalleGastronomico1.DeleteSelectedRows(True)
         End If

         Me.CargarProductosComponentes()
         Me.EliminarProductosSeleccionados()
         Me.EliminarGastronomiaSeleccionados()
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try

   End Sub

   Private Sub btnPreferenciasGast_Click(sender As Object, e As EventArgs) Handles btnPreferenciasGast.Click
      Try
         Dim pre As Preferencias = New Preferencias(Me.ugvProductosGastronomicos, True)
         pre.SufijoXML = "ProductosGast"
         pre.ShowDialog()
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub btnPreferenciasDetGast_Click(sender As Object, e As EventArgs) Handles btnPreferenciasDetGast.Click
      Try
         Dim pre As Preferencias = New Preferencias(Me.ugdDetalleGastronomico1, True)
         pre.SufijoXML = "ComponentesGast"
         pre.ShowDialog()
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub llbPasajero_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles llbPasajero.LinkClicked
      Try
         MostrarMasInfo(Me.bscCodPasajero)
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

   Private Sub lblRespPasajero_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lblRespPasajero.LinkClicked
      Try
         MostrarMasInfo(Me.bscCodRespPasajero)
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

   Private Sub btnInsertarAdjunto_Click(sender As Object, e As EventArgs) Handles btnInsertarPasajeros.Click
      Try
         If Not bscCodPasajero.Selecciono And Not bscPasajero.Selecciono Then
            MessageBox.Show("No selecciono el pasajero.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
         End If
         If Me.txtCostoPasajeros.Text = "" Then
            MessageBox.Show("No ingresó el costo.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
         End If
         If Me.chbLiberadoPasajero.Checked And txtLiberadosPasajeros.Text = "" Then
            MessageBox.Show("No ingresó el porcentaje de Liberado.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
         End If
         Me.AgregarPasajeros()
         Me.RefrescarPasajeros()
      Catch ex As Exception
         ShowError(ex)
      Finally
         Me.Cursor = Cursors.Default
      End Try
   End Sub

   Private Sub ReservasDetalle_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown

      If _ConfiguracionImpresoras Then
         MessageBox.Show("No Existe la PC en Configuraciones/Impresoras", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
         Me.Close()
      End If

   End Sub

   Private Sub cmbTipoReserva_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbTipoReserva.SelectedIndexChanged
      'Try
      If Me._estaCargando Then Exit Sub
      If StateForm = Win.StateForm.Insertar Then
         txtLetra.Text = DirectCast(Me.cmbTipoReserva.SelectedItem, Entidades.TipoComprobante).LetrasHabilitadas

         'Try
         Dim oImpresoras As New Reglas.Impresoras
         txtCentroEmisor.Text = oImpresoras.GetPorSucursalPCTipoComprobante(actual.Sucursal.Id, My.Computer.Name, DirectCast(Me.cmbTipoReserva.SelectedItem, Entidades.TipoComprobante).IdTipoComprobante).CentroEmisor.ToString()
         '   Catch ex As Exception
         'MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
         'Exit Sub
         'End Try

         Dim oVentasNumeros As New Reglas.VentasNumeros
         Me.txtNumeroReserva.Text = oVentasNumeros.GetProximoNumero(actual.Sucursal,
                                                                    DirectCast(Me.cmbTipoReserva.SelectedItem, Entidades.TipoComprobante).IdTipoComprobante,
                                                                    Me.txtLetra.Text,
                                                                    Short.Parse(Me.txtCentroEmisor.Text.ToString())).ToString()
      End If

   End Sub
   Private Sub chbLiberadoPasajero_CheckedChanged(sender As Object, e As EventArgs) Handles chbLiberadoPasajero.CheckedChanged
      Me.txtLiberadosPasajeros.Enabled = Me.chbLiberadoPasajero.Checked
      If Me.chbLiberadoPasajero.Checked = False Then
         Me.txtLiberadosPasajeros.Text = ""
      End If
   End Sub

   Private Sub txtCosto_TextChanged(sender As Object, e As EventArgs) Handles txtCosto.TextChanged
      Me.txtCostoPasajeros.Text = Me.txtCosto.Text
   End Sub
   Private Sub btnEliminarPasajero_Click(sender As Object, e As EventArgs) Handles btnEliminarPasajero.Click
      Try
         Dim Pasajero As Entidades.ReservaTurismoPasajero = GetCurrentPasajero()
         If Pasajero IsNot Nothing Then
            If ShowPregunta("¿Desea eliminar el pasajero seleccionado?") = Windows.Forms.DialogResult.Yes Then
               If Pasajero.IdTipoComprobante = "" Then
                  Reserva.Pasajeros.Remove(Pasajero)
                  ugPasajeros.Rows.Refresh(UltraWinGrid.RefreshRow.ReloadData)
               Else
                  MessageBox.Show("No se puede eliminar el Pasajero, ya se emitió el comprobante.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
               End If

            End If
         End If
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

   Private Sub ugPasajeros_DoubleClickCell(sender As Object, e As DoubleClickCellEventArgs) Handles ugPasajeros.DoubleClickCell
      Try
         Me.Cursor = Cursors.WaitCursor

         If e.Cell.Row.Index > -1 Then

            'Limpia los textbox, y demas controles
            Me.RefrescarPasajeros()

            Dim Pasajero As Entidades.ReservaTurismoPasajero = GetCurrentPasajero()
            If Pasajero IsNot Nothing Then
               If Pasajero.IdTipoComprobante = "" Then
                  'Carga el Comprobante seleccionado de la grilla en los textbox 
                  Me.CargarPasajeroCompleto(Pasajero)

                  'Elimina el comprobantede la grilla
                  Reserva.Pasajeros.Remove(Pasajero)
                  ugPasajeros.Rows.Refresh(UltraWinGrid.RefreshRow.ReloadData)
               Else
                  MessageBox.Show("No se puede modificar el Pasajero, ya se emitió el comprobante.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
               End If
            End If

            Me.bscPasajero.Focus()
         End If

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      Finally
         Me.Cursor = Cursors.Default
      End Try
   End Sub

   Private Sub cmbEstadoTurismo_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbEstadoTurismo.SelectedIndexChanged
      Try

         If Me._estaCargando And StateForm = Win.StateForm.Insertar Then Exit Sub
         If Not DirectCast(Me.cmbEstadoTurismo.SelectedItem, Entidades.EstadoTurismo).SolicitaPasajeros Then
            If Me.tbcVisitas.TabPages.Contains(Me.tbpPasajeros) Then
               Me.tbcVisitas.TabPages.Remove(Me.tbpPasajeros)
            End If
            chbFechaViaje.Visible = False
            dtpFechaViaje.Visible = False
         Else
            If Not Me.tbcVisitas.TabPages.Contains(Me.tbpPasajeros) Then
               Me.tbcVisitas.TabPages.Insert(Me.tbcVisitas.TabPages.IndexOf(tbpObservaciones) + 1, Me.tbpPasajeros)
            End If
            chbFechaViaje.Visible = True
            dtpFechaViaje.Visible = True
         End If

      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

   Private Sub chbFechaViaje_CheckedChanged(sender As Object, e As EventArgs) Handles chbFechaViaje.CheckedChanged
      Me.dtpFechaViaje.Enabled = Me.chbFechaViaje.Checked
      If Me.chbFechaViaje.Checked = False Then
         Me.dtpFechaViaje.Value = Date.Now
      End If
   End Sub
   Private Sub btnSeleccionMultiple_Click(sender As Object, e As EventArgs) Handles btnSeleccionMultiple.Click
      TryCatched(
         Sub()
            Using oPasajeroAyuda = New PasajerosAyuda(Reserva.Pasajeros)
               oPasajeroAyuda.ShowDialog()
               CargarPasajerosSeleccionados(oPasajeroAyuda.PasajerosSeleccionados)
            End Using
         End Sub)
   End Sub

   Private Sub txtCostoPasajeros_KeyDown(sender As Object, e As KeyEventArgs) Handles txtCostoPasajeros.KeyDown, chbLiberadoPasajero.KeyDown, txtLiberadosPasajeros.KeyDown
      TryCatched(
         Sub()
            PresionarTab(e)
            If sender.Equals(txtCostoPasajeros) Then
               PresionarTab(e)
            End If
            If e.Control And e.KeyCode = Keys.Add Then
               btnInsertarPasajeros.PerformClick()
            End If
         End Sub)
   End Sub

   Private Sub btnInsertarPasajeros_KeyDown(sender As Object, e As KeyEventArgs) Handles btnInsertarPasajeros.KeyDown
      TryCatched(Sub() If e.KeyCode = Keys.Enter Then btnInsertarPasajeros.PerformClick())
   End Sub

   Private Sub txtCapacidadMax_Leave(sender As Object, e As EventArgs) Handles txtCapacidadMax.Leave
      TryCatched(Sub() SetDataSourcePasajeros())
   End Sub
#End Region

#Region "Facturacion"

#Region "Facturacion Eventos"
   Private Sub bscCodigoProductoFacturacion2_BuscadorClick() Handles bscCodigoProductoFacturacion2.BuscadorClick
      TryCatched(
         Sub()
            _publicos.PreparaGrillaProductos2(bscCodigoProductoFacturacion2)
            Dim rProductos = New Reglas.Productos()
            Dim dt = rProductos.GetPorCodigo(bscCodigoProductoFacturacion2.Text.Trim(), actual.Sucursal.Id, Reglas.Publicos.ListaPreciosPredeterminada, "VENTAS", soloBuscaPorIdProducto:=True)
            bscCodigoProductoFacturacion2.Datos = dt
         End Sub)
   End Sub
   Private Sub bscNombreProductoFacturacion2_BuscadorClick() Handles bscNombreProductoFacturacion2.BuscadorClick
      TryCatched(
         Sub()
            _publicos.PreparaGrillaProductos2(bscNombreProductoFacturacion2)
            Dim rProductos = New Reglas.Productos
            bscNombreProductoFacturacion2.Datos = rProductos.GetPorNombre(bscNombreProductoFacturacion2.Text.Trim(), actual.Sucursal.Id, Reglas.Publicos.ListaPreciosPredeterminada, "VENTAS")
         End Sub)
   End Sub
   Private Sub bscCodigoProductoFacturacion2_BuscadorSeleccion(sender As Object, e As Controles.BuscadorEventArgs) Handles bscCodigoProductoFacturacion2.BuscadorSeleccion, bscNombreProductoFacturacion2.BuscadorSeleccion
      TryCatched(Sub() CargarProductoFacturacion(e.FilaDevuelta))
   End Sub
   Private Sub lnkProducto_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lnkProducto.LinkClicked
      TryCatched(
         Sub()
            Dim prod = New Entidades.Producto()
            If Not String.IsNullOrWhiteSpace(bscCodigoProductoFacturacion2.Text) Then
               prod = New Reglas.Productos().GetUno(bscCodigoProductoFacturacion2.Text, accion:=Reglas.Base.AccionesSiNoExisteRegistro.Vacio)
            End If
            Using pr = New ProductosDetalle(prod)
               pr.StateForm = If(String.IsNullOrWhiteSpace(prod.IdProducto), StateForm.Insertar, StateForm.Actualizar)
               pr.CierraAutomaticamente = True
               If pr.ShowDialog() = Windows.Forms.DialogResult.OK Then
                  bscCodigoProductoFacturacion2.Text = pr.IdProducto
                  bscCodigoProductoFacturacion2.PresionarBoton()
               End If
            End Using
         End Sub)
   End Sub

   Private Sub txtFacturacion_KeyDown(sender As Object, e As KeyEventArgs) Handles txtCantidadFacturacion.KeyDown, txtPrecioFacturacion.KeyDown
      PresionarTab(e)
      PresionarInsertarProducto(e)
   End Sub

   Private Sub txtCantidadFacturacion_Leave(sender As Object, e As EventArgs) Handles txtCantidadFacturacion.Leave
      TryCatched(Sub() CalcularTotalProducto())
   End Sub
   Private Sub txtPrecioFacturacion_Leave(sender As Object, e As EventArgs) Handles txtPrecioFacturacion.Leave
      TryCatched(Sub() CalcularTotalProducto())
   End Sub

   Private Sub ugProductosFacturacion_DoubleClickRow(sender As Object, e As DoubleClickRowEventArgs) Handles ugProductosFacturacion.DoubleClickRow
      TryCatched(Sub() EditarFacturable())
   End Sub

   Private Sub btnLimpiarProductoFacturacion_Click(sender As Object, e As EventArgs) Handles btnLimpiarProductoFacturacion.Click
      TryCatched(Sub() LimpiarCamposProductos())
   End Sub
   Private Sub btnInsertarFacturacion_Click(sender As Object, e As EventArgs) Handles btnInsertarFacturacion.Click
      TryCatched(Sub() ValidarInsertarProductoFacturacion())
   End Sub
   Private Sub btnEliminarFacturacion_Click(sender As Object, e As EventArgs) Handles btnEliminarFacturacion.Click
      TryCatched(Sub() EliminarFacturable())
   End Sub


#End Region

#Region "Facturacion Métodos"
   Private Function CargarProductoFacturacionCompleto() As Entidades.ReservaTurismoProductoFacturacion
      Dim dr = ugProductosFacturacion.FilaSeleccionada(Of Entidades.ReservaTurismoProductoFacturacion)()
      If dr IsNot Nothing Then
         bscCodigoProductoFacturacion2.Text = dr.IdProducto
         bscCodigoProductoFacturacion2.PresionarBoton()

         txtCantidadFacturacion.SetValor(dr.Cantidad)
         cmbPorcentajeIvaFacturacion.SelectedItem = dr.AlicuotaIVA
         txtPrecioFacturacion.SetValor(dr.Precio)
         CalcularTotalProducto()

         txtCantidadFacturacion.Focus()

      End If
      Return dr
   End Function
   Private Sub CargarProductoFacturacion(dr As DataGridViewRow)
      If dr IsNot Nothing Then
         bscCodigoProductoFacturacion2.Text = dr.Cells("IdProducto").Value.ToString.Trim()
         bscNombreProductoFacturacion2.Text = dr.Cells("NombreProducto").Value.ToString()

         bscCodigoProductoFacturacion2.Permitido = False
         bscNombreProductoFacturacion2.Permitido = False

         bscCodigoProductoFacturacion2.FilaDevuelta = dr
         bscNombreProductoFacturacion2.FilaDevuelta = dr

         bscCodigoProductoFacturacion2.Selecciono = True
         bscNombreProductoFacturacion2.Selecciono = True

         cmbPorcentajeIvaFacturacion.Text = dr.Cells("Alicuota").Value.ToString()
         cmbPorcentajeIvaFacturacion.Tag = cmbPorcentajeIvaFacturacion.Text

         Dim Producto = New Reglas.Productos().GetUno(dr.Cells("IdProducto").Value.ToString.Trim())

         If Producto.ImporteImpuestoInterno <> 0 Then
            ShowMessage(String.Format("El producto seleccionado {0} - {1} tiene configurado Impuesto Interno Fijo. No se podrá agregar el producto al Comprobante.", Producto.IdProducto, Producto.NombreProducto))
         End If

         '----------------------------------------------------------------------------------------------------------------------------------

         Dim PrecioPorEmbalaje As Boolean = Boolean.Parse(dr.Cells("PrecioPorEmbalaje").Value.ToString())
         Dim establecimiento = New Reglas.Clientes().GetUno(Long.Parse(bscCodigoCliente.Tag.ToString()))
         Dim categoriaFiscalEmpresa = New Reglas.CategoriasFiscales().GetUno(Reglas.Publicos.CategoriaFiscalEmpresa)
         Dim cotizacionDolar = New Reglas.Monedas().GetUna(Entidades.Moneda.Dolar).FactorConversion

         Dim p = FacturacionAyudantes.GetPrecio(Decimal.Parse(dr.Cells("PrecioVentaSinIVA").Value.ToString()), Decimal.Parse(dr.Cells("PrecioVentaConIVA").Value.ToString()),
                                                Producto, establecimiento, dtpFechaReserva.Value, 0, categoriaFiscalEmpresa, codigoBarrasCompleto:=String.Empty,
                                                cotizacionDolar, modalidad:=Entidades.Producto.Modalidades.NORMAL, valorRedondeo:=2, obtienePrecioConIVA:=True,
                                                  FormaDePago:=Nothing)

         txtPrecioFacturacion.SetValor(p)
         txtCantidadFacturacion.SetValor(1)

         txtCantidadFacturacion.Focus()
         txtCantidadFacturacion.SelectAll()
      End If
   End Sub
   Private Sub CalcularTotalProducto()
      txtCantidadFacturacion.SetValor(txtCantidadFacturacion.ValorNumericoPorDefecto(1D))
      txtPrecioFacturacion.SetValor(txtPrecioFacturacion.ValorNumericoPorDefecto(0D))

      txtTotalProductoFacturacion.SetValor(txtPrecioFacturacion.ValorNumericoPorDefecto(0D) * txtCantidadFacturacion.ValorNumericoPorDefecto(1D))
   End Sub
   Private Sub CalcularTotales()
      txtCosto.SetValor(Reserva.Facturacion.SumSecure(Function(f) f.ImporteTotal).IfNull())
   End Sub

   Private Sub LimpiarCamposProductos()

      bscCodigoProductoFacturacion2.Permitido = True
      bscCodigoProductoFacturacion2.Text = String.Empty
      bscCodigoProductoFacturacion2.Selecciono = False
      bscCodigoProductoFacturacion2.FilaDevuelta = Nothing

      bscNombreProductoFacturacion2.Permitido = True
      bscNombreProductoFacturacion2.Text = String.Empty
      bscNombreProductoFacturacion2.Selecciono = False
      bscNombreProductoFacturacion2.FilaDevuelta = Nothing

      txtCantidadFacturacion.SetValor(1D)
      cmbPorcentajeIvaFacturacion.SelectedValue = Reglas.Publicos.ProductoIVA
      txtPrecioFacturacion.SetValor(0D)
      txtTotalProductoFacturacion.SetValor(0D)

      CalcularTotalProducto()
   End Sub
   Private Sub ValidarInsertarProductoFacturacion()
      If ValidarProductoFacturacion() Then
         InsertarProductoFacturacion()
      End If
   End Sub
   Private Function ValidarProductoFacturacion() As Boolean
      If Not bscCodigoProductoFacturacion2.Selecciono And Not bscNombreProductoFacturacion2.Selecciono Then
         ShowMessage("No eligió un Producto ó falto pulsar ENTER.")
         bscCodigoProductoFacturacion2.Focus()
         Return False
      End If

      If txtCantidadFacturacion.ValorNumericoPorDefecto(0D) = 0 Then
         ShowMessage("No puede ingresar un producto con precio cero.")
         txtCantidadFacturacion.Focus()
         Return False
      End If

      If cmbPorcentajeIvaFacturacion.SelectedIndex < 0 Then
         ShowMessage("No seleccionó una alicuota de IVA.")
         cmbPorcentajeIvaFacturacion.Focus()
         Return False
      End If

      If txtTotalProductoFacturacion.ValorNumericoPorDefecto(0D) = 0 Then
         ShowMessage("No puede ingresar un producto con precio cero.")
         txtPrecioFacturacion.Focus()
         Return False
      End If

      Return True
   End Function
   Private Sub InsertarProductoFacturacion()

      Dim producto = New Reglas.Productos().GetUno(bscCodigoProductoFacturacion2.Text)
      If producto.ImporteImpuestoInterno <> 0 Then
         Throw New Exception(String.Format("El producto seleccionado {0} - {1} tiene configurado Impuesto Interno Fijo. No se puede agregar el producto al Comprobane.", producto.IdProducto, producto.NombreProducto))
      End If

      'Fuerzo los calculos porque pudo no pasar Insertar sin los tab en los campos de descuento.
      CalcularTotalProducto()
      '------------------------------------------------------------------------------------------

      'cargo los valores de los controles a variables locales---------------------
      Dim detalle = New Entidades.ReservaTurismoProductoFacturacion()

      Dim alicuotaIVA = cmbPorcentajeIvaFacturacion.ValorSeleccionado(Of Decimal)
      Dim precioProducto = txtPrecioFacturacion.ValorNumericoPorDefecto(0D)
      Dim cantidad = txtCantidadFacturacion.ValorNumericoPorDefecto(1D)
      Dim importeTotal = txtTotalProductoFacturacion.ValorNumericoPorDefecto(0D)
      Dim orden = 1

      detalle.IdProducto = bscCodigoProductoFacturacion2.Text
      detalle.NombreProducto = bscNombreProductoFacturacion2.Text
      detalle.Orden = orden
      detalle.Cantidad = cantidad
      detalle.Precio = precioProducto
      detalle.AlicuotaIVA = alicuotaIVA
      detalle.ImporteTotal = importeTotal

      AgregarFacturable(detalle)
      LimpiarCamposProductos()
      CalcularTotales()
   End Sub
   Private Sub AgregarFacturable(detalle As Entidades.ReservaTurismoProductoFacturacion)
      Reserva.Facturacion.Add(detalle)
      ugProductosFacturacion.Rows.Refresh(RefreshRow.ReloadData)

      Dim uRow = ugProductosFacturacion.Rows.GetRowWithListIndex(Reserva.Facturacion.IndexOf(detalle))
      If uRow IsNot Nothing Then
         If ugProductosFacturacion.ActiveRowScrollRegion.IsActiveScrollRegion Then
            ugProductosFacturacion.ActiveRowScrollRegion.ScrollRowIntoView(uRow)

            ugProductosFacturacion.Selected.Rows.Clear()

            uRow.Activated = True
            uRow.Selected = True

         End If
      End If
   End Sub
   Private Sub EliminarFacturable()
      Dim dr = ugProductosFacturacion.FilaSeleccionada(Of Entidades.ReservaTurismoProductoFacturacion)()
      If dr IsNot Nothing Then
         If ShowPregunta("¿Esta seguro de eliminar el producto seleccionado?") = Windows.Forms.DialogResult.Yes Then
            EliminarFacturable(dr)
         End If
      End If
   End Sub

   Private Sub EliminarFacturable(dr As Entidades.ReservaTurismoProductoFacturacion)
      Dim rowIndex = Reserva.Facturacion.IndexOf(dr)
      Reserva.Facturacion.Remove(dr)
      ugProductosFacturacion.Rows.Refresh(RefreshRow.ReloadData)

      If Reserva.Facturacion.Count > 0 Then
         Dim uRow = ugProductosFacturacion.Rows.GetRowWithListIndex(Math.Min(rowIndex, Reserva.Facturacion.Count - 1))
         If uRow IsNot Nothing Then
            If ugProductosFacturacion.ActiveRowScrollRegion.IsActiveScrollRegion Then
               ugProductosFacturacion.ActiveRowScrollRegion.ScrollRowIntoView(uRow)

               ugProductosFacturacion.Selected.Rows.Clear()

               uRow.Activated = True
               uRow.Selected = True

            End If
         End If
      End If
   End Sub

   Private Sub EditarFacturable()
      LimpiarCamposProductos()
      EliminarFacturable(CargarProductoFacturacionCompleto())
   End Sub

   Private Sub PresionarInsertarProducto(e As KeyEventArgs)
      TryCatched(Sub() If e.KeyCode = Keys.Add And e.Control Then btnInsertarFacturacion.PerformClick())
   End Sub

#End Region

#End Region

End Class